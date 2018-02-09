using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using FlexModel;
using Custom_SearchLookupEdit;

namespace TraceForms
{
    public partial class CityCodeForm : XtraForm
    {
        FlextourEntities _context;
        CITYCOD _selectedRecord;
        Timer _actionConfirmation;
        bool _ignoreLeaveRow = false, _ignorePositionChange = false;

        RepositoryItemImageComboBox _supplierCombo = new RepositoryItemImageComboBox();
        RepositoryItemCustomSearchLookUpEdit _operatorSearch = new RepositoryItemCustomSearchLookUpEdit();

        public CityCodeForm(FlexInterfaces.Core.ICoreSys sys)
        {
            try {
                InitializeComponent();
                Connect(sys);
                LoadLookups();
                SetReadOnly(true);
            }
            catch (Exception ex) {
                DisplayHelper.DisplayError(this, ex);
            }
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            _context = new FlextourEntities(sys.Settings.EFConnectionString);
        }

        private void LoadLookups()
        {
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = null };

            var lookup = new List<CodeName> {
                new CodeName(null)
            };
            lookup.AddRange(_context.CITYCOD
                            .OrderBy(o => o.CODE)
                            .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }));
            SearchLookupEditLinkCode.Properties.DataSource = lookup;

            lookup = new List<CodeName> {
                new CodeName(null)
            };
            lookup.AddRange(_context.State
                .OrderBy(o => o.Code)
                .Select(s => new CodeName() { Code = s.Code, Name = s.State1 }));
            _operatorSearch.DataSource = lookup;
            SearchLookupEditState.Properties.DataSource = lookup;

            lookup = new List<CodeName> {
                new CodeName(null)
            };
            lookup.AddRange(_context.COUNTRY
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }));
            SearchLookupEditCountry.Properties.DataSource = lookup;

            _supplierCombo.Items.Add(loadBlank);
            _supplierCombo.Items.AddRange(_context.Supplier
                            .OrderBy(o => o.Name).AsEnumerable()
                            .Select(s => new ImageComboBoxItem() { Description = s.Name, Value = s.GUID })
                            .ToList());
            GridControlSupplierCity.RepositoryItems.Add(_supplierCombo);        //per DX recommendation to avoid memory leaks

            lookup = new List<CodeName> {
                new CodeName(null)
            };
            lookup.AddRange(_context.OPERATOR
                            .OrderBy(o => o.CODE)
                            .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }));
            RepositoryItemCustomSearchLookUpEditOperator.DataSource = lookup;
            //var col = _operatorSearch.View.Columns.Add();
            //col.FieldName = "Code";
            //col = _operatorSearch.View.Columns.Add();
            //col.FieldName = "Name";
            //_operatorSearch.DisplayMember = "DisplayName";
            //_operatorSearch.ValueMember = "Code";
            //_operatorSearch.NullText = string.Empty;
            //_operatorSearch.BestFitMode = BestFitMode.BestFitResizePopup;
            //_operatorSearch.DataSource = lookup;
            //_operatorSearch.View.BestFitColumns();
            //_operatorSearch.Popup += new EventHandler(SearchLookupEdit_Popup);
            //GridControlSupplierCity.RepositoryItems.Add(_operatorSearch);		//per DX recommendation to avoid memory leaks
        }

        private void CityCodeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsModified(_selectedRecord)) {
                DialogResult select = DisplayHelper.QuestionYesNo(this, "There are unsaved changes. Are you sure want to exit?");
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

        private void DeleteRecord()
        {
            if (_selectedRecord == null) return;

            try {
                if (DisplayHelper.QuestionYesNo(this, "Are you sure you want to delete this record?") == DialogResult.Yes) {
                    _ignoreLeaveRow = true;
                    _ignorePositionChange = true;
                    RemoveRecord();
                    if (!_selectedRecord.IsNew()) {
                        //Apparently a record which has just been added is not flagged for deletion by BindingSource.RemoveCurrent,
                        //(the EntityState remains unchanged).  It seems like it is not tracked by the context even though it is, because
                        //the EntityState changes for modification. So if this is a deletion and the entity is not flagged for deletion, 
                        //delete it manually.
                        if (_selectedRecord != null && (_selectedRecord.EntityState & EntityState.Deleted) != EntityState.Deleted)
                            _context.CITYCOD.DeleteObject(_selectedRecord);
                        _context.SaveChanges();
                    }
                    _ignoreLeaveRow = false;
                    _ignorePositionChange = false;
                    if (GridViewLookup.RowCount == 0) {
                        ClearBindings();
                    }
                    SetBindings();
                    ShowActionConfirmation("Record Deleted");
                }
            }
            catch (Exception ex) {
                DisplayHelper.DisplayError(this, ex);
                RefreshRecord();        //pull it back from db because that is it's current state
                //We must also Load and rebind the related entities from the db because context.Refresh doesn't do that
                SetBindings();
            }
        }

        void ClearBindings()
        {
            BindingSource.DataSource = typeof(CITYCOD);
        }

        private bool SaveRecord(bool prompt)
        {
            try {
                if (_selectedRecord == null) return true;

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
                    }
                    if (!ValidateAll())
                        return false;

                    if (_selectedRecord.EntityState == EntityState.Detached) {
                        _context.CITYCOD.AddObject(_selectedRecord);
                    }
                    _context.SaveChanges();
                    ShowActionConfirmation("Record Saved");
                }
                return true;
            }
            catch (Exception ex) {
                DisplayHelper.DisplayError(this, ex);
                RefreshRecord();        //pull it back from db because that is its current state
                                        //We must also Load and rebind the related entities from the db because context.Refresh doesn't do that
                SetBindings();
                return false;
            }
        }

        private bool IsModified(CITYCOD record)
        {
            //Type-specific routine that takes into account relationships that should also be considered
            //when deciding if there are unsaved changes.  The entity properties also return true if the
            //record is new or deleted.
            return record.IsModified(_context) || record.SupplierCity.IsModified(_context);
        }

        private bool ValidateAll()
        {
            bool suppCitiesInvalid = false;
            if (BindingSourceSupplierCity.List.Count > 0) {
                suppCitiesInvalid = BindingSourceSupplierCity.List.Cast<SupplierCity>().Any(b => !b.Validate());
            }

            if (!_selectedRecord.Validate() || suppCitiesInvalid) {
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
            SetErrorInfo(_selectedRecord.ValidateName, TextEditName);
            SetErrorInfo(_selectedRecord.ValidateLinkCode, SearchLookupEditLinkCode);
            SetErrorInfo(_selectedRecord.ValidateState, SearchLookupEditState);
            SetErrorInfo(_selectedRecord.ValidateCountry, SearchLookupEditCountry);
            SetErrorInfo(_selectedRecord.ValidateLatitude, SpinEditLat);
            SetErrorInfo(_selectedRecord.ValidateLongitude, SpinEditLong);
            SetErrorInfo(_selectedRecord.ValidateSupplierCities, GridControlSupplierCity);
        }

        private void SetErrorInfo(Func<String> validationMethod, object sender)
        {
            BindingSource.EndEdit();        //force changes back into context for validation
            if (validationMethod != null) {
                string error = validationMethod.Invoke();
                ErrorProvider.SetError((Control)sender, error);
            }
        }

        private void FinalizeBindings()
        {
            BindingSource.EndEdit();
            GridViewSupplierCity.CloseEditor();
            GridViewSupplierCity.UpdateCurrentRow();
            //Set the city code for each mapping just in case
            for (int rowCtr = 0; rowCtr < GridViewSupplierCity.DataRowCount; rowCtr++) {
                SupplierCity suppCity = (SupplierCity)GridViewSupplierCity.GetRow(rowCtr);
                suppCity.Citycod_Code = TextEditCode.Text;
            }
            BindingSourceSupplierCity.EndEdit();
        }

        void SetBindings()
        {
            //If the route list is filtered, there will be rows in the binding source
            //that are not visible, and they can become selected if the last visible row
            //is deleted, so handle that by checking rowcount.
            if (BindingSource.Current == null) {
                _selectedRecord = null;
                BindingSourceSupplierCity.Clear();
                SetReadOnly(true);
            }
            else {
                _selectedRecord = ((CITYCOD)BindingSource.Current);
                LoadAndBindSupplierCities();
                SetReadOnly(false);
                SetReadOnlyKeyFields(true);
            }
            ErrorProvider.Clear();
        }

        void LoadAndBindSupplierCities()
        {
            //Load the related entities. DO NOT do another db query using context.whatever because they
            //will not be associated with the parent entity, and new items will not be added to the relationship
            //so foreign key errors will result. Can't load the related entities on a detached or added (but not saved)
            //entity.
            if (_selectedRecord.EntityState != EntityState.Detached) {
                _selectedRecord.SupplierCity.Load(MergeOption.OverwriteChanges);
            }
            //Don't do any LINQ operations on the entitycollection, just bind directly to it, otherwise
            //it appears to bind as unassociated with the context and you have to manually add/delete
            //rows from the bindingsource to the context (but changes work fine)
            BindingSourceSupplierCity.DataSource = _selectedRecord.SupplierCity;
            BindSupplierCities();
        }

        void SetReadOnly(bool value)
        {
            foreach (Control control in splitContainerControl.Panel2.Controls) {
                control.Enabled = !value;
            }
        }

        void SetReadOnlyKeyFields(bool value)
        {
            TextEditCode.ReadOnly = value;
        }

        private void ShowActionConfirmation(string confirmation)
        {
            PanelControlStatus.Visible = true;
            LabelStatus.Text = confirmation;
            _actionConfirmation = new Timer();
            _actionConfirmation.Interval = 3000;
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
                BindingSourceSupplierCity.Clear();
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

        private void TextEditCode_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCode, sender);
        }

        private void TextEditName_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateName, sender);
        }

        private void TextEditLinkCode_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateLinkCode, sender);
        }

        private void CityCodeForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewLookup.IsFilterRow(GridViewLookup.FocusedRowHandle)) {
                ExecuteQuery();
                e.Handled = true;
            }
        }

        private void ExecuteQuery()
        {
            Cursor = Cursors.WaitCursor;
            string query = "1=1";
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in GridViewLookup.VisibleColumns) {
                string value = GridViewLookup.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, col.FieldName);
                if (!string.IsNullOrEmpty(value)) {
                    query += $" and it.{col.FieldName} like '%{value}%'";
                }
            }

            var records = _context.CITYCOD.Where(query);
            if (records.Count() > 0) {
                BindingSource.DataSource = records;
                GridViewLookup.ClearColumnsFilter();
            }
            else {
                ClearBindings();
                DisplayHelper.DisplayInfo(this, "No matching records found.");
            }
            Cursor = Cursors.Default;
        }

        private void longTextEdit_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateLongitude, sender);
        }

        private void latTextEdit_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateLatitude, sender);
        }

        private void gridViewLookup_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            //If the user selects a row, edits, then selects the auto-filter row, then selects a different row,
            //this event will fire for the auto-filter row, so we cannot ignore it because there is still a record
            //that may need to be saved. 
            if (!_ignoreLeaveRow && IsModified(_selectedRecord)) {
                e.Allow = SaveRecord(true);
            }
        }

        private void bindingSource_CurrentChanged(object sender, EventArgs e)
        {
            //If the current record is changing as a result of removing a record to delete it, and it is the last
            //record in the table, then SetBindings will clear the bindings, which will cause the delete
            //to fail because the associated entities will become detached when their BindingSources are cleared.
            //Thus we have a flag which is set in that case to ignore this event.
            if (!_ignorePositionChange)
                SetBindings();
        }

        private void imageComboBoxEditState_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateState, sender);
        }

        private void ImageComboBoxEditCountry_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCountry, sender);
        }

        void BindSupplierCities()
        {
            GridControlSupplierCity.DataSource = BindingSourceSupplierCity;
            GridControlSupplierCity.RefreshDataSource();
        }

        private void ButtonAddMapping_Click(object sender, EventArgs e)
        {
            SupplierCity suppCity = new SupplierCity();
            suppCity.Citycod_Code = TextEditCode.Text;
            _selectedRecord.SupplierCity.Add(suppCity);
            BindSupplierCities();
            GridViewSupplierCity.FocusedRowHandle = BindingSourceSupplierCity.Count - 1;
        }

        private void ButtonDeleteMapping_Click(object sender, EventArgs e)
        {
            if (GridViewSupplierCity.FocusedRowHandle >= 0) {
                SupplierCity suppCity = (SupplierCity)GridViewSupplierCity.GetFocusedRow();
                _selectedRecord.SupplierCity.Remove(suppCity);
                //Removing from the collection just removes the object from its parent, but does not mark
                //it for deletion, effectively orphaning it.  This will cause foreign key errors when saving.
                //To flag for deletion, delete it from the context as well.
                _context.SupplierCity.DeleteObject(suppCity);
                BindSupplierCities();
            }
        }

        private void CityCodeForm_Shown(object sender, EventArgs e)
        {
            GridViewLookup.FocusedRowHandle = DevExpress.Data.CurrencyDataController.FilterRow;
            GridControlLookup.Focus();
        }

        private void GridViewLookup_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void GridViewLookup_ColumnFilterChanged(object sender, EventArgs e)
        {
            if (GridViewLookup.DataRowCount == 0) {
                ClearBindings();
            }
        }

        private void GridControlSupplierCity_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateSupplierCities, sender);
        }

        private void GridViewSupplierCity_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column == gridColumnSupplierGuid) { 
                e.RepositoryItem = _supplierCombo;
            }
            //else if (e.Column == gridColumnOperator) {
            //    e.RepositoryItem = _operatorSearch;
            //}
        }

        private void imageComboBoxEditState_SelectedValueChanged(object sender, EventArgs e)
        {
            ImageComboBoxEdit box = (ImageComboBoxEdit)sender;
            if (box.EditValue != null) {
                string value = box.EditValue.ToString();
                var state = _context.State.FirstOrDefault(s => s.Code == value);
                //If the state is linked to a country, default the country for the city
                if (!string.IsNullOrEmpty(state?.Country)) {
                    SearchLookupEditCountry.EditValue = state.Country;
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

        private void SearchLookupEdit_UpdateDisplayFilter(object sender, Custom_SearchLookupEdit.DisplayFilterEventArgs e)
        {
            //Users did not like have to type quotes in order to get an exact match of entered terms rather than any word being matched
            //https://www.devexpress.com/Support/Center/Example/Details/E3135/how-to-implement-an-event-allowing-you-to-customize-a-filter-string-produced-by-the-find
            //Also requires the custom inherited version of the SearchLookupEdit in the Custom_SearchLookupEdit namespace
            if (!string.IsNullOrEmpty(e.FilterText)) {
                e.FilterText = '"' + e.FilterText + '"';
            }
        }

        private void BarButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _ignoreLeaveRow = true;       //so that when the grid row changes it doesn't try to save again
            if (SaveRecord(true)) {
                GridViewLookup.ClearColumnsFilter();    //so that the new record will show even if it doesn't match the filter
                BindingSource.AddNew();
                //if (GridViewRoute.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                GridViewLookup.FocusedRowHandle = GridViewLookup.RowCount - 1;
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

        void PopupForm_KeyUp(object sender, KeyEventArgs e)
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
                        if (codeName.Code.Equals(searchText, StringComparison.OrdinalIgnoreCase)) {
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
    }
}
