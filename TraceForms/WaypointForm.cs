using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using FlexModel;
using Custom_SearchLookupEdit;
using System.Collections.Generic;
using DevExpress.XtraEditors.Popup;
using DevExpress.Utils.Win;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Map;
using DevExpress.XtraMap;
using DevExpress.Data.Async.Helpers;
using DevExpress.XtraEditors.Repository;
using System.Reflection;

namespace TraceForms
{

    public partial class WaypointForm : DevExpress.XtraEditors.XtraForm
    {
        FlextourEntities _context;
        WAYPOINT _selectedRecord, _previousRecord;
        Timer _actionConfirmation;
        bool _ignoreLeaveRow = false, _ignorePositionChange = false;
        RepositoryItemImageComboBox _supplierCombo = new RepositoryItemImageComboBox();

        public WaypointForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
            LoadLookups();
            SetReadOnly(true);
            SetMapProperties();         //Mapping
        }

        void SetReadOnly(bool value)
        {
            foreach (Control control in SplitContainerControl.Panel2.Controls) {
                control.Enabled = !value;
            }
        }

        void SetReadOnlyKeyFields(bool value)
        {
            TextEditCode.ReadOnly = value;
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            _context = new FlextourEntities(sys.Settings.EFConnectionString);
        }

        private void LoadLookups()
        {
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            var cities = new List<CodeName> {
                new CodeName(null)
            };
            cities.AddRange(_context.CITYCOD
                .OrderBy(o => o.NAME)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }).ToList());
            SearchLookupEditCity.Properties.DataSource = cities;

            var states = new List<CodeName> {
                new CodeName(null)
            };
            states.AddRange(_context.State
                .OrderBy(o => o.Code)
                .Select(s => new CodeName() { Code = s.Code, Name = s.State1 }).ToList());
            SearchLookupEditState.Properties.DataSource = states;

            var countries = new List<CodeName> {
                new CodeName(null)
            };
            countries.AddRange(_context.COUNTRY
                .OrderBy(o => o.NAME)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }).ToList());
            SearchLookupEditCountry.Properties.DataSource = countries;

            _supplierCombo.Items.Add(loadBlank);
            _supplierCombo.Items.AddRange(_context.Supplier
                            .OrderBy(o => o.Name).AsEnumerable()
                            .Select(s => new ImageComboBoxItem() { Description = s.Name, Value = s.GUID })
                            .ToList());
            GridControlSupplierProduct.RepositoryItems.Add(_supplierCombo);        //per DX recommendation to avoid memory leaks
        }

        private void ShowActionConfirmation(string confirmation)
        {
            PanelControlStatus.Visible = true;
            LabelStatus.Text = confirmation;
            _actionConfirmation = new Timer {
                Interval = 3000
            };
            _actionConfirmation.Start();
            _actionConfirmation.Tick += TimedEvent;
        }

        private void TimedEvent(object sender, EventArgs e)
        {
            PanelControlStatus.Visible = false;
            _actionConfirmation.Stop();
        }

        private void RemoveRecord()
        {
            if (_selectedRecord.IsNew()) {
                //If you clear the bindingsource for child records where the parent entity is tracked by
                //the context, it will lose tracking for the child entities and cascade operations like
                //delete will fail
                BindingSourceSupplierProduct.Clear();
            }
            //Note that cascade delete must be set on the FK in the db in order for the related
            //entities to be deleted.  This is a db function, not an EF function. However in addition
            //the model must know about the delete, otherwise the relationships in the context will
            //get messed up.  So after adding the cascade rule to the FK, the model must be updated,
            //and in order to refresh a relationship the tables must be deleted and re-added
            //Otherwise, we could do a delete loop
            //If using DbContext instead of ObjectContext, we could do eg
            //_context.SupplierCity.RemoveRange(_selectedRecord.SupplierCity)
            BindingSource.RemoveCurrent();
        }

        private void RefreshRecord()
        {
            //A Detached record has not yet been added to the context
            //An Added record has been added but not yet saved, most likely because there was
            //an error in SaveRecord, in which case we should not retrieve it from the db
            if (_selectedRecord != null && _selectedRecord.EntityState != EntityState.Detached
                && _selectedRecord.EntityState != EntityState.Added) {
                _context.Refresh(RefreshMode.StoreWins, _selectedRecord);
                SetReadOnlyKeyFields(true);
            }
        }

        private bool SaveRecord(bool prompt)
        {
            try {
                if (_selectedRecord == null)
                    return true;

                FinalizeBindings();
                bool newRec = _selectedRecord.IsNew();
                bool modified = newRec || IsModified(_selectedRecord);

                if (modified) {
                    if (prompt) {
                        DialogResult result = DisplayHelper.QuestionYesNoCancel(this, "Do you want to save these changes?");
                        if (result == DialogResult.No) {
                            if (newRec) {
                                RemoveRecord();
                            }
                            else {
                                RefreshRecord();
                            }  
                            return true;
                        }
                        else if (result == DialogResult.Cancel) {
                            return false;
                        }
                        //If we prompted then it's because the user is changing the selected record so we don't need
                        //to keep track of the previously selected record
                        _previousRecord = null;
                    }
                    else {
                        //If we didn't prompt then the user has clicked the Save button where the expectation is that
                        //the currently selected row will remain selected.  However EntityInstantFeedbackSource does not have
                        //a way to refresh a single record and refreshing the data source causes the focused row to be reset
                        //back to the top row.  Therefore we store the value of the previous selection and set the row focus
                        //back in GridView AsyncCompleted.  This means there will be a flash of the incorrect top row being
                        //displayed before being set back to the previously selected row. DevExpress have no way around this.
                        _previousRecord = _selectedRecord;
                    }
                    if (!ValidateAll())
                        return false;

                    if (_selectedRecord.EntityState == System.Data.Entity.EntityState.Detached) {
                        _context.WAYPOINT.AddObject(_selectedRecord);
                    }
                    _context.SaveChanges();
                    EntityInstantFeedbackSource.Refresh();
                    ShowActionConfirmation("Record Saved");
                }
                return true;
            }
            catch (Exception ex) {
                var objectStateManager = _context.ObjectStateManager;
                var fieldInfo = objectStateManager.GetType().GetField("_entriesWithConceptualNulls", BindingFlags.Instance | BindingFlags.NonPublic);
                var conceptualNulls = fieldInfo.GetValue(objectStateManager);

                DisplayHelper.DisplayError(this, ex);
                RefreshRecord();        //pull it back from db because that is its current state
                                        //We must also Load and rebind the related entities from the db because context.Refresh doesn't do that
                SetBindings();
                return false;
            }
        }

        private bool IsModified(WAYPOINT record)
        {
            //Type-specific routine that takes into account relationships that should also be considered
            //when deciding if there are unsaved changes.  The entity properties also return true if the
            //record is new or deleted.
            if (record == null)
                return false;
            return record.IsModified(_context)
                || record.SupplierProduct.IsModified(_context)
                || record.GeoCode.IsModified(_context);     //Mapping

        }

        private void FinalizeBindings()
        {
            BindingSource.EndEdit();
            GridViewSupplierProduct.CloseEditor();
            GridViewSupplierProduct.UpdateCurrentRow();
            //Set the code for each mapping just in case
            for (int rowCtr = 0; rowCtr < GridViewSupplierProduct.DataRowCount; rowCtr++) {
                SupplierProduct suppProd = (SupplierProduct)GridViewSupplierProduct.GetRow(rowCtr);
                suppProd.Product_Type = "WAY";
                suppProd.Product_Code_Internal = TextEditCode.Text ?? string.Empty;
            }
            BindingSourceSupplierProduct.EndEdit();
        }

        void SetBindings()
        {
            if (BindingSource.Current == null) {
                ClearBindings();
            }
            else {
                _selectedRecord = ((WAYPOINT)BindingSource.Current);
                LoadAndBindSupplierProducts();
                SetReadOnly(false);
                SetReadOnlyKeyFields(true);
                BarButtonItemDelete.Enabled = true;
                BarButtonItemSave.Enabled = true;
                ShowMapData(_selectedRecord);           //Mapping
            }
            ErrorProvider.Clear();
        }

        void LoadAndBindSupplierProducts()
        {
            //Load the related entities. DO NOT do another db query using context.whatever because they
            //will not be associated with the parent entity, and new items will not be added to the relationship
            //so foreign key errors will result. Can't load the related entities on a detached or added (but not saved)
            //entity.
            if (_selectedRecord.EntityState != EntityState.Detached) {
                _selectedRecord.SupplierProduct.Load(MergeOption.OverwriteChanges);
            }
            //Don't do any LINQ operations on the entitycollection, just bind directly to it, otherwise
            //it appears to bind as unassociated with the context and you have to manually add/delete
            //rows from the bindingsource to the context (but changes work fine)
            BindingSourceSupplierProduct.DataSource = _selectedRecord.SupplierProduct;
            BindSupplierProducts();
        }

        void BindSupplierProducts()
        {
            GridControlSupplierProduct.DataSource = BindingSourceSupplierProduct;
            GridControlSupplierProduct.RefreshDataSource();
        }

        void GridViewSupplierProduct_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column == gridColumnSupplierGuid) {
                e.RepositoryItem = _supplierCombo;
            }
        }

        private void ButtonAddMapping_Click(object sender, EventArgs e)
        {
            SupplierProduct suppProduct = new SupplierProduct {
                Product_Code_Internal = TextEditCode.Text ?? string.Empty,
                Product_Type = "WAY"
            };
            _selectedRecord.SupplierProduct.Add(suppProduct);
            BindSupplierProducts();
            GridViewSupplierProduct.FocusedRowHandle = BindingSourceSupplierProduct.Count - 1;
        }

        private void ButtonDeleteMapping_Click(object sender, EventArgs e)
        {
            if (GridViewSupplierProduct.FocusedRowHandle >= 0) {
                SupplierProduct suppProduct = (SupplierProduct)GridViewSupplierProduct.GetFocusedRow();
                _selectedRecord.SupplierProduct.Remove(suppProduct);
                //Removing from the collection just removes the object from its parent, but does not mark
                //it for deletion, effectively orphaning it.  This will cause foreign key errors when saving.
                //To flag for deletion, delete it from the context as well.
                if (!suppProduct.IsNew()) {
                    _context.SupplierProduct.DeleteObject(suppProduct);
                }
                BindSupplierProducts();
            }
        }

        private bool ValidateAll()
        {
            bool suppProductsInvalid = false;
            if (BindingSourceSupplierProduct.List.Count > 0) {
                suppProductsInvalid = BindingSourceSupplierProduct.List.Cast<SupplierProduct>().Any(b => !b.Validate());
            }

            if (!_selectedRecord.Validate() || suppProductsInvalid) {
                ShowMainControlErrors();
                DisplayHelper.DisplayWarning(this, "Errors were found. Please resolve them and try again.");
                return false;
            }
            else {
                ErrorProvider.Clear();
                return true;
            }
        }

        private void ShowMainControlErrors()
        {
            //The error indicators inside the grids are handled by binding, but errors on the main form must
            //be set manually
            SetErrorInfo(_selectedRecord.ValidateCode, TextEditCode);
            SetErrorInfo(_selectedRecord.ValidateDesc, TextEditDesc);
            SetErrorInfo(_selectedRecord.ValidateAddress1, TextEditAddress1);
            SetErrorInfo(_selectedRecord.ValidateAddress2, TextEditAddress2);
            SetErrorInfo(_selectedRecord.ValidateAddress3, TextEditAddress3);
            SetErrorInfo(_selectedRecord.ValidateTown, TextEditTown);
            SetErrorInfo(_selectedRecord.ValidateZip, TextEditZip);
            SetErrorInfo(_selectedRecord.ValidateCity, SearchLookupEditCity);
            SetErrorInfo(_selectedRecord.ValidateCountry, SearchLookupEditCountry);
            SetErrorInfo(_selectedRecord.ValidateState, SearchLookupEditState);
            SetErrorInfo(_selectedRecord.ValidateDistance, SpinEditDistance);
            SetErrorInfo(_selectedRecord.ValidateDuration, SpinEditDuration);
            SetErrorInfo(_selectedRecord.ValidateMappings, GridControlSupplierProduct);
        }

        private void SetErrorInfo(Func<String> validationMethod, object sender)
        {
            BindingSource.EndEdit();
            if (validationMethod != null) {
                string error = validationMethod.Invoke();
                ErrorProvider.SetError((Control)sender, error);
            }
        }

        private void GridViewLookup_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            //If the user selects a row, edits, then selects the auto-filter row, then selects a different row,
            //this event will fire for the auto-filter row, so we cannot ignore it because there is still a record
            //that may need to be saved. 
            if (!_ignoreLeaveRow && IsModified(_selectedRecord)) {
                e.Allow = SaveRecord(true);
            }
        }

        private void DeleteRecord()
        {
            if (_selectedRecord == null)
                return;

            try {
                if (DisplayHelper.QuestionYesNo(this, "Are you sure you want to delete this record?") == DialogResult.Yes) {
                    //ignoreLeaveRow and ignorePositionChange are set because when removing a record, the bindingsource_currentchanged 
                    //and gridview_beforeleaverow events will fire as the current record is removed out from under them.
                    //We do not want these events to perform their usual code of checking whether there are changes in the active
                    //record that should be saved before proceeding, because we know we have just deleted the active record.
                    _ignoreLeaveRow = true;
                    _ignorePositionChange = true;
                    RemoveRecord();
                    if (!_selectedRecord.IsNew()) {
                        //Apparently a record which has just been added is not flagged for deletion by BindingSource.RemoveCurrent,
                        //(the EntityState remains unchanged).  It seems like it is not tracked by the context even though it is, because
                        //the EntityState changes for modification. So if this is a deletion and the entity is not flagged for deletion, 
                        //delete it manually.
                        if (_selectedRecord != null && (_selectedRecord.EntityState & EntityState.Deleted) != EntityState.Deleted)
                            _context.WAYPOINT.DeleteObject(_selectedRecord);
                        _context.SaveChanges();
                    }
                    if (GridViewLookup.DataRowCount == 0) {
                        ClearBindings();
                    }
                    _ignoreLeaveRow = false;
                    _ignorePositionChange = false;
                    SetBindings();
                    EntityInstantFeedbackSource.Refresh();
                    ShowActionConfirmation("Record Deleted");
                }
            }
            catch (Exception ex) {
                DisplayHelper.DisplayError(this, ex);
                _ignoreLeaveRow = false;
                _ignorePositionChange = false;
                RefreshRecord();        //pull it back from db because that is it's current state
                //We must also Load and rebind the related entities from the db because context.Refresh doesn't do that
                SetBindings();
            }
        }

        void ClearBindings()
        {
            _ignoreLeaveRow = true;
            _ignorePositionChange = true;
            _selectedRecord = null;
            BindingSourceSupplierProduct.Clear();
            SetReadOnly(true);
            BarButtonItemDelete.Enabled = false;
            BarButtonItemSave.Enabled = false;
            BindingSource.DataSource = typeof(WAYPOINT);
            ClearMapData();                 //Mapping
            _ignoreLeaveRow = false;
            _ignorePositionChange = false;
        }

        private void TextEditCode_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCode, sender);
        }

        private void TextEditDesc_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateDesc, sender);
        }

        private void WAYPOINTForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsModified(_selectedRecord)) {
                DialogResult select = DisplayHelper.QuestionYesNo(this, "There are unsaved changes. Are you sure you want to exit?");
                if (select == DialogResult.Yes) {
                    e.Cancel = false;
                    _context.Dispose();
                    Dispose();
                }
                else
                    e.Cancel = true;
            }
            else {
                e.Cancel = false;
                _context.Dispose();
                Dispose();
            }
        }

        private void SearchLookupEditState_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateState, sender);
        }

        private void SearchLookupEditCity_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCity, sender);
        }

        private void SearchLookupEditCountry_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateState, sender);
        }

        private void TextEditAddress1_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateAddress1, sender);
        }

        private void TextEditAddress2_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateAddress2, sender);
        }

        private void TextEditAddress3_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateAddress3, sender);
        }

        private void TextEditTown_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateTown, sender);
        }

        private void TextEditZip_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateZip, sender);
        }

        private void BindingSource_CurrentChanged(object sender, System.EventArgs e)
        {
            //If the current record is changing as a result of removing a record to delete it, and it is the last
            //record in the table, then SetBindings will clear the bindings, which will cause the delete
            //to fail because the associated entities will become detached when their BindingSources are cleared.
            //Thus we have a flag which is set in that case to ignore this event.
            if (!_ignorePositionChange)
                SetBindings();
        }

        private void SpinEditDistance_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateDistance, sender);
        }

        private void SpinEditDurationEdit_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateDistance, sender);
        }

        private void BarButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _ignoreLeaveRow = true;       //so that when the grid row changes it doesn't try to save again
            if (SaveRecord(true)) {
                //For some reason when there is no existing record in the binding source the Add method does not
                //trigger the CurrentChanged event, but AddNew does so use that instead
                _selectedRecord = (WAYPOINT)BindingSource.AddNew();
                //With the instant feedback data source, the new row is not immediately added to the grid, so move
                //the focused row to the filter row just so that no other existing row is visually highlighted
                GridViewLookup.FocusedRowHandle = DevExpress.Data.BaseListSourceDataController.FilterRow;
                SetReadOnlyKeyFields(false);
                TextEditCode.Focus();
                SetReadOnly(false);
            }
            ErrorProvider.Clear();
            _ignoreLeaveRow = false;
        }

        private void BarButtonItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteRecord();
        }

        private void BarButtonItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SaveRecord(false))
                RefreshRecord();
        }

        private void EntityInstantFeedbackSource_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            FlextourEntities context = new FlextourEntities(Connection.EFConnectionString);
            e.QueryableSource = context.WAYPOINT;
            e.Tag = context;
        }

        private void EntityInstantFeedbackSource_DismissQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            ((FlextourEntities)e.Tag).Dispose();
        }

        private void GridViewLookup_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (!_ignoreLeaveRow) {
                GridView view = (GridView)sender;
                object row = view.GetRow(e.FocusedRowHandle);
                if (row != null && row.GetType() != typeof(DevExpress.Data.NotLoadedObject)) {
                    ReadonlyThreadSafeProxyForObjectFromAnotherThread proxy = (ReadonlyThreadSafeProxyForObjectFromAnotherThread)view.GetRow(e.FocusedRowHandle);
                    WAYPOINT record = (WAYPOINT)proxy.OriginalRow;
                    BindingSource.DataSource = _context.WAYPOINT.Where(c => c.CODE == record.CODE)
                        .Include(c => c.GeoCode);
                }
                else {
                    ClearBindings();
                }
            }
        }

        private void GridViewLookup_ColumnFilterChanged(object sender, EventArgs e)
        {
            if (GridViewLookup.DataRowCount == 0) {
                ClearBindings();
            }
        }

        private void GridControlSupplierProduct_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateMappings, sender);
        }

        private void PopupForm_KeyUp(object sender, KeyEventArgs e)
        {
            bool gotMatch = false;
            PopupSearchLookUpEditForm popupForm = sender as PopupSearchLookUpEditForm;
            if (e.KeyData == Keys.Enter) {
                string searchText = popupForm.Properties.View.FindFilterText;
                if (!string.IsNullOrEmpty(searchText)) {
                    GridView view = popupForm.OwnerEdit.Properties.View;
                    //If there is a match is on the ValueMember (Code) column, that should take precedence
                    //This needs to be case insensitive, but there is no case insensitive lookup, so we have to iterate the rows
                    //int row = view.LocateByValue(popupForm.OwnerEdit.Properties.ValueMember, searchText);
                    for (int row = 0; row < view.DataRowCount; row++) {
                        CodeName codeName = (CodeName)view.GetRow(row);
                        if (codeName.Code.Equals(searchText.Trim('"'), StringComparison.OrdinalIgnoreCase)) {
                            view.FocusedRowHandle = row;
                            gotMatch = true;
                            break;
                        }
                    }
                    if (!gotMatch) {
                        view.FocusedRowHandle = 0;
                    }
                    popupForm.OwnerEdit.ClosePopup();
                }
            }
        }

        private void SearchLookupEdit_Popup(object sender, EventArgs e)
        {
            //Hide the Find button because it doesn't do anything when auto - filtering, except it
            //is useful to let the user know the purpose of the filter field, because it has no label
            //LayoutControl lc = ((sender as IPopupControl).PopupWindow.Controls[2].Controls[0] as LayoutControl);
            //((lc.Items[0] as LayoutControlGroup).Items[1] as LayoutControlGroup).Items[1].Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            PopupSearchLookUpEditForm popupForm = (sender as IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            popupForm.KeyPreview = true;
            popupForm.KeyUp -= PopupForm_KeyUp;
            popupForm.KeyUp += PopupForm_KeyUp;

            //SearchLookUpEdit currentSearch = (SearchLookUpEdit)sender;
        }

        private void SearchLookupEditCity_Closed(object sender, ClosedEventArgs e)
        {
            //Normal is when a user selects a value
            if (e.CloseMode == PopupCloseMode.Normal) {
                //CustomSearchLookUpEdit box = (CustomSearchLookUpEdit)sender;
                if (SearchLookupEditCity.EditValue != null) {
                    string value = SearchLookupEditCity.EditValue.ToString();
                    var city = _context.CITYCOD.FirstOrDefault(s => s.CODE == value);
                    if (string.IsNullOrEmpty(TextEditTown.Text)) {
                        TextEditTown.EditValue = city.NAME;
                    }
                    //If the city is linked to a state and/or country, default the state and/or country for the city
                    if (!string.IsNullOrEmpty(city?.State_Code)) {
                        SearchLookupEditState.EditValue = city.State_Code;
                    }
                    if (!string.IsNullOrEmpty(city?.Country_Code)) {
                        SearchLookupEditCountry.EditValue = city.Country_Code;
                    }
                }
            }
        }

        private void SearchLookupEditState_Closed(object sender, ClosedEventArgs e)
        {
            //Normal is when a user selects a value
            if (e.CloseMode == PopupCloseMode.Normal) {
                //CustomSearchLookUpEdit box = (CustomSearchLookUpEdit)sender;
                if (SearchLookupEditState.EditValue != null) {
                    string value = SearchLookupEditState.EditValue.ToString();
                    var state = _context.State.FirstOrDefault(s => s.Code == value);
                    //If the state is linked to a country, default the country for the city
                    if (!string.IsNullOrEmpty(state?.Country)) {
                        SearchLookupEditCountry.EditValue = state.Country;
                    }
                }
            }
        }

        private void SearchLookupEdit_UpdateDisplayFilter(object sender, Custom_SearchLookupEdit.DisplayFilterEventArgs e)
        {
            //Users did not like have to type quotes in order to get an exact match of entered terms rather than any word being matched
            //https://www.devexpress.com/Support/Center/Example/Details/E3135/how-to-implement-an-event-allowing-you-to-customize-a-filter-string-produced-by-the-find
            //Also requires the custom inherited version of the SearchLookupEdit in the Custom_SearchLookupEdit namespace
            if (!string.IsNullOrEmpty(e.FilterText)) {
                e.FilterText = '"' + e.FilterText + '"';
            }
        }

        #region "Mapping"
        MapPushpin _pin;
        delegate void DoSearch();
        IAsyncResult _asyncResult;

        private void SetMapProperties()
        {
            BingSearchDataProvider.SearchCompleted += new BingSearchCompletedEventHandler(SearchDataProvider_SearchCompleted);
            BingMapDataProvider.BingKey = Configurator.BingMapsAPIKey;
            BingSearchDataProvider.BingKey = Configurator.BingMapsAPIKey;
        }

        private void MapControl_MouseDown(object sender, MouseEventArgs e)
        {
            MapHitInfo info = this.MapControl.CalcHitInfo(e.Location);
            if (info.InMapPushpin) {
                MapControl.EnableScrolling = false;
                foreach (object obj in info.HitObjects) {
                    if (obj.GetType() == typeof(MapPushpin))
                        _pin = (MapPushpin)obj;
                }
            }
        }

        private void MapControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (_pin != null) {
                CoordPoint point = MapControl.ScreenPointToCoordPoint(new MapPoint(e.X, e.Y));
                _pin.Location = point;
            }
        }

        private void MapControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (_pin != null) {
                CoordPoint point = MapControl.ScreenPointToCoordPoint(new MapPoint(e.X, e.Y));
                _pin.Location = point;
                MapControl.EnableScrolling = true;
                DisplayPointCoordinates((GeoPoint)point);
                SaveMapData();
                _pin = null;
            }
        }

        private void AddOrMovePushpin(GeoCode geoCode)
        {
            GeoPoint geoPoint = new GeoPoint(geoCode.PushLat, geoCode.PushLong);

            MapPushpin pin = AddOrMovePushpin(geoPoint);

            //Since we only have one pin this isn't really necessary, but just showing how to add an attribute to a pushpin
            //which can later be used to match when retrieving the pin
            MapItemAttribute attrib = pin.Attributes.FirstOrDefault(a => a.Name == "id");
            if (attrib == null) {
                pin.Attributes.Add(new MapItemAttribute() {
                    Name = "id",
                    Type = typeof(int),
                    Value = geoCode.GeoCodeId
                });
            }
            else {
                attrib.Value = geoCode.GeoCodeId;
            }
        }

        private MapPushpin AddOrMovePushpin(GeoPoint geoPoint)
        {
            MapItem item = MapItemStorage.Items.FirstOrDefault();
            MapPushpin pin;
            if (item == null) {
                pin = new MapPushpin();
                MapItemStorage.Items.Add(pin);
            }
            else {
                pin = (MapPushpin)item;
            }
            pin.Location = geoPoint;
            MapControl.CenterPoint = geoPoint;
            DisplayPointCoordinates(geoPoint);

            return pin;
        }

        private void DisplayPointCoordinates(GeoPoint point)
        {
            LabelControlLat.Text = point.Latitude == 0 ? string.Empty : point.Latitude.ToString();
            LabelControlLon.Text = point.Longitude == 0 ? string.Empty : point.Longitude.ToString();
        }

        private void SearchDataProvider_SearchCompleted(object sender, BingSearchCompletedEventArgs e)
        {
            SearchRequestResult result = e.RequestResult;
            if (result.ResultCode == RequestResultCode.Success) {
                //List<LocationInformation> regions = result.SearchResults;
                //Really we should display all the returned regions for disambiguation, but we're just going with the best match
                //which is the first one
                LocationInformation region = result.SearchResults.FirstOrDefault();
                AddOrMovePushpin(region.Location);
                MapControl.ZoomLevel = 13;
                SaveMapData();
            }

            if (result.ResultCode == RequestResultCode.BadRequest)
                this.DisplayWarning("The Bing Search service does not work for this location.");

        }

        private void SimpleButtonPlot_Click(object sender, EventArgs e)
        {
            _asyncResult = BeginInvoke((DoSearch)SearchAsync);
        }

        private void SearchAsync()
        {
            EndInvoke(_asyncResult);
            string search = $"{TextEditAddress1.Text}, {SearchLookupEditState.EditValue}, {(SearchLookupEditCountry.EditValue as CodeName)?.Name}";
            BingSearchDataProvider.Search(search);
        }

        private void ShowMapData(WAYPOINT record)
        {
            GeoCode geoCode = record?.GeoCode ?? new GeoCode();
            AddOrMovePushpin(geoCode);
            //If a bounding box has been given, then use it
            if (geoCode.NorthLat != 0) {
                var topLeft = new GeoPoint(geoCode.NorthLat, geoCode.WestLong);
                var bottomRight = new GeoPoint(geoCode.SouthLat, geoCode.EastLong);
                MapControl.ZoomToRegion(topLeft, bottomRight, 0);
            }
            else {
                //If there there is no bounding box, zoom all the way out if this is a new record, otherwise go to the 
                //default zoom level
                MapControl.ZoomLevel = (geoCode.GeoCodeId == 0) ? 1 : 13;
            }
        }

        private void ClearMapData()
        {
            MapItemStorage.Items.Clear();
            MapControl.ZoomLevel = 1;
        }

        private void WaypointForm_Shown(object sender, EventArgs e)
        {
            GridViewLookup.FocusedRowHandle = DevExpress.Data.BaseListSourceDataController.FilterRow;
            GridControlLookup.Focus();
        }

        private void SaveMapData()
        {
            MapItem item = MapItemStorage.Items.FirstOrDefault();
            if (item != null) {
                MapPushpin pin = (MapPushpin)item;
                GeoPoint location = (GeoPoint)pin.Location;
                //If lat and long are zero, then there was no geocode to begin with and the user didn't specify one
                //during the edit, so don't update the values
                if (location.Longitude != 0 || location.Latitude != 0) {
                    if (_selectedRecord.GeoCode == null) {
                        _selectedRecord.GeoCode = new GeoCode();
                    }
                    GeoCode geoCode = _selectedRecord.GeoCode;
                    geoCode.PushLat = location.Latitude;
                    geoCode.PushLong = location.Longitude;
                    geoCode.ManualChecked = true;
                    CoordPoint p1 = MapControl.ScreenPointToCoordPoint(new MapPoint());
                    CoordPoint p2 = MapControl.ScreenPointToCoordPoint(new MapPoint(MapControl.Width, MapControl.Height));
                    GeoPoint gp1 = (GeoPoint)p1;
                    GeoPoint gp2 = (GeoPoint)p2;
                    geoCode.NorthLat = gp1.Latitude;
                    geoCode.WestLong = gp1.Longitude;
                    geoCode.SouthLat = gp2.Latitude;
                    geoCode.EastLong = gp2.Longitude;
                }
            }
        }
        #endregion
    }
}