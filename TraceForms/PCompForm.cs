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
using DevExpress.XtraGrid.Columns;
using FlexModel;
using Custom_SearchLookupEdit;
using DevExpress.Data;
using System.Diagnostics;

namespace TraceForms
{
    
    public partial class PCompForm : DevExpress.XtraEditors.XtraForm
    {
        FlextourEntities _context;
        PCOMP _selectedRecord;
        Timer _actionConfirmation;
        bool _ignoreLeaveRow = false, _ignorePositionChange = false;
        string _username;

        List<CodeName> _hotels;
        IQueryable<CodeName> _airports;
        IQueryable<CodeName> _busstations;
        IQueryable<CodeName> _trainstations;
        IQueryable<CodeName> _seaports;
        IQueryable<CodeName> _waypoints;
        IQueryable<CodeName> _services;
        List<CodeName> _categories;
        List<CodeName> _specialVals;

        public PCompForm(FlexInterfaces.Core.ICoreSys sys)
        {
            try {
                InitializeComponent();
                Connect(sys);
                LoadLookups();
                SetAllFieldsEnabledState(true);
            }
            catch (Exception ex) {
                this.DisplayError(ex);
            }
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            _context = new FlextourEntities(sys.Settings.EFConnectionString);
            _username = sys.User.Name;
        }

        private void LoadLookups()
        {
            _busstations = _context.BusStation.OrderBy(x => x.Code).Select(x => new CodeName() { Code = x.Code, Name = x.Name });
            _waypoints = _context.WAYPOINT.OrderBy(x => x.CODE).Select(x => new CodeName() { Code = x.CODE, Name = x.DESC });
            _trainstations = _context.TrainStation.OrderBy(x => x.Code).Select(x => new CodeName() { Code = x.Code, Name = x.Name });
            _seaports = _context.SeaPort.OrderBy(x => x.Code).Select(x => new CodeName() { Code = x.Code, Name = x.Name });
            _airports = _context.Airport.OrderBy(x => x.Code).Select(x => new CodeName() { Code = x.Code, Name = x.Name });
            _services = _context.COMP.Where(x => x.Inactive != "Y").OrderBy(x => x.CODE)
                .Select(x => new CodeName() { Code = x.CODE, Name = x.NAME });

            _hotels = _context.HOTEL.Where(x => x.INACTIVE != "Y").OrderBy(x => x.CODE)
                .Select(x => new CodeName() { Code = x.CODE, Name = x.NAME }).ToList();
            _hotels.Insert(0, new CodeName());      //null is valid for a hotel

            SearchLookupEditCode.Properties.DataSource = _context.PACK.Where(x => x.Inactive != "Y").OrderBy(x => x.CODE)
                .Select(x => new CodeName() { Code = x.CODE, Name = x.NAME });
            var cities = _context.CITYCOD.OrderBy(x => x.CODE).Select(x => new CodeName() { Code = x.CODE, Name = x.NAME });
            SearchLookupEditArvArrivalCity.Properties.DataSource = cities;
            SearchLookupEditArvDepartureCity.Properties.DataSource = cities;
            SearchLookupEditDepDepartureCity.Properties.DataSource = cities;
            SearchLookupEditArvArrivalCity.Properties.DataSource = cities;
            SearchLookupEditMeal.Properties.DataSource = _context.MEALCOD.OrderBy(x => x.CODE)
                .Select(x => new CodeName() { Code = x.CODE, Name = x.DESC });
            SearchLookupEditOperator.Properties.DataSource = _context.OPERATOR.OrderBy(x => x.CODE)
                .Select(x => new CodeName() { Code = x.CODE, Name = x.NAME });
            var cats = _context.ROOMCOD.OrderBy(x => x.CODE).Select(x => new CodeName() { Code = x.CODE, Name = x.DESC }).ToList();
            SearchLookupEditCategory.Properties.DataSource = cats;

            //Create a list with a blank category for item category because item category can contain a category that
            //does not match what's in the list.  Although blank is not allowed, the ProcessNewValue event fires after
            //the Leave event, and until ProcessNewValue has fired, a new value is not posted to the binding source.  
            //Thus, validation in the Leave event returns no error for an empty value, because unless it is in the lookup
            //list is is considered a new value, and thus _selectedRecord still holds the prior (non-empty) value.
            //The counter-intuitive way around this is to have an empty value in the lookup list so that it can immediately 
            //be validated as an error.
            _categories = new List<CodeName>(cats);
            _categories.Insert(0, new CodeName());
            GridLookupEditItemCategory.Properties.DataSource = _categories;

            _specialVals = _context.SpecialValue.OrderBy(x => x.Code)
                .Select(x => new CodeName() { Code = x.Code, Name = x.Name }).ToList();
            _specialVals.Insert(0, new CodeName());
            SearchLookupEditSpecialValue.Properties.DataSource = _specialVals;
            GridLookupEditItemSpecialValue.Properties.DataSource = _specialVals;

            //Set up a merged grouping for the key fields and sort by day and line
            GridViewLookup.SortInfo.ClearAndAddRange(
                new[] { new GridMergedColumnSortInfo(new[] { colCODE, colCAT, colRatePlan, colDepartureTime },
                    new[] { ColumnSortOrder.Ascending, ColumnSortOrder.Ascending, ColumnSortOrder.Ascending, ColumnSortOrder.Ascending}),
                new GridColumnSortInfo(colDAY, ColumnSortOrder.Ascending), new GridColumnSortInfo(colLINE, ColumnSortOrder.Ascending)}, 1);
        }

        private void PCompForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsModified(_selectedRecord)) {
                DialogResult select = this.QuestionYesNo("There are unsaved changes. Are you sure want to exit?");
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

        void SetAllFieldsEnabledState(bool value)
        {
            foreach (Control control in SplitContainerControl.Panel2.Controls) {
                control.Enabled = !value;
            }
        }

        void SetReadOnlyKeyFields(bool value)
        {
            SearchLookupEditCode.ReadOnly = value;
            SearchLookupEditCategory.ReadOnly = value;
            SearchLookupEditSpecialValue.ReadOnly = value;
            TimeEditDepartureTime.ReadOnly = value;
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

        private void GridViewLookup_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            //If the user selects a row, edits, then selects the auto-filter row, then selects a different row,
            //this event will fire for the auto-filter row, so we cannot ignore it because there is still a record
            //that may need to be saved. 
            if (!_ignoreLeaveRow && IsModified(_selectedRecord)) {
                e.Allow = SaveRecord(true);
            }
        }

        private bool SaveRecord(bool prompt, MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel)
        {
            try {
                if (_selectedRecord == null)
                    return true;

                FinalizeBindings();
                bool newRec = _selectedRecord.IsNew();
                bool modified = newRec || IsModified(_selectedRecord);

                if (modified) {
                    if (prompt) {
                        DialogResult result = this.Question("Do you want to save these changes?", buttons);
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
                        _context.PCOMP.AddObject(_selectedRecord);
                    }
                    SetUpdateFields(_selectedRecord);
                    _context.SaveChanges();
                    ShowActionConfirmation("Record Saved");
                }
                return true;
            }
            catch (Exception ex) {
                this.DisplayError(ex);
                RefreshRecord();        //pull it back from db because that is its current state
                                        //We must also Load and rebind the related entities from the db because context.Refresh doesn't do that
                SetBindings();
                return false;
            }
        }

        private void DeleteRecord()
        {
            if (_selectedRecord == null)
                return;

            try {
                if (this.QuestionYesNo("Are you sure you want to delete this record?") == DialogResult.Yes) {
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
                            _context.PCOMP.DeleteObject(_selectedRecord);
                        _context.SaveChanges();
                    }
                    //If the list is filtered, there will be rows in the binding source
                    //that are not visible, and they can become selected if the last visible row
                    //is deleted, so handle that by checking rowcount.
                    if (GridViewLookup.DataRowCount == 0) {
                        ClearBindings();
                    }
                    _ignorePositionChange = false;
                    _ignoreLeaveRow = false;
                    SetBindings();
                    ShowActionConfirmation("Record Deleted");
                }
            }
            catch (Exception ex) {
                this.DisplayError(ex);
                _ignoreLeaveRow = false;
                _ignorePositionChange = false;
                RefreshRecord();        //pull it back from db because that is it's current state
                //We must also Load and rebind the related entities from the db because context.Refresh doesn't do that
                SetBindings();
            }
        }

        private void FinalizeBindings()
        {
            //Leave event of control doesn't fire when Save button is clicked, and for the GridLookupEditItem controls
            //that is when the value in the editor is manually posted back to the data source. Thus we need to manually update
            //the data source here, but first we have to make sure all the other fields in the data source are posted back,
            //otherwise updating _selectedRecord will cause the entity framework to fire a property changed notification
            //which will undo edits on any unposted controls
            BindingSource.EndEdit();
            GridLookupEditItemCategory.DataBindings[0].WriteValue();
            SetItemCategoryLookup(GridLookupEditItemCategory.Text);
            GridLookupEditItemSpecialValue.DataBindings[0].WriteValue();
            SetItemSpecialValueLookup(GridLookupEditItemSpecialValue.Text);
        }

        private bool IsModified(PCOMP record)
        {
            //Type-specific routine that takes into account relationships that should also be considered
            //when deciding if there are unsaved changes.  The entity properties also return true if the
            //record is new or deleted.
            return record.IsModified(_context);
        }

        void SetBindings()
        {
            //It would be nice to be able to check DataRowCount here and clear the bindings if there are no
            //records displaying in the grid, but because this method is invoked when the current record changes
            //in the binding source, it happens before the grid updates, so checking DataRowCount here is not accurate.
            //Checking BindingSource.Count is also not relevant, because the grid may have filters applied
            ErrorProvider.Clear();
            if (BindingSource.Current == null) {
                ClearBindings();
            }
            else {
                _selectedRecord = ((PCOMP)BindingSource.Current);
                SetAllFieldsEnabledState(false);
                SetReadOnlyKeyFields(true);
                SetButtonEnabledState(true);
                ItemChanged(_selectedRecord.CODE1);
            }
        }

        private void SetItemCategoryLookup(object itemCat)
        {
            string cat = itemCat.ToStringEmptyIfNull();

            if (string.IsNullOrEmpty(cat) || _categories.Any(c => c.Code == cat)) {
                GridLookupEditItemCategory.Properties.DataSource = _categories;
            }
            else {
                //If the value of category isn't in ROOMCOD, add it to the list
                //We allow non-matching categories so that API products can be booked
                //Do not set DataSource because it's already bound to the list, so just changing the list is sufficient
                //Also settings DataSource from ProcessNewValue is forbidden and throws a NullReferenceException
                var newCat = new CodeName(cat);
                _categories.Add(newCat);
            }
        }

        private void SetItemSpecialValueLookup(object itemVal)
        {
            string val = itemVal.ToStringEmptyIfNull();

            if (string.IsNullOrEmpty(val) || _specialVals.Any(c => c.Code == val)) {
                GridLookupEditItemSpecialValue.Properties.DataSource = _specialVals;
            }
            else {
                //If the value of rate plan isn't in SpecialValue, add it to the list
                //We allow non-matching rate plans so that API products can be booked
                //Do not set DataSource because it's already bound to the list, so just changing the list is sufficient
                //Also settings DataSource from ProcessNewValue is forbidden and throws a NullReferenceException
                var newVal = new CodeName(val);
                _specialVals.Add(newVal);
            }
        }

        private void SetButtonEnabledState(bool state)
        {
            BarButtonItemDelete.Enabled = state;
            BarButtonItemSave.Enabled = state;
            SimpleButtonClone.Enabled = state;
            SimpleButtonUp.Enabled = state;
            SimpleButtonDown.Enabled = state;
        }

        private bool ValidateAll()
        {
            if (!_selectedRecord.Validate()) {
                ShowMainControlErrors();
                this.DisplayWarning("Errors were found. Please resolve them and try again.");
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
            SetErrorInfo(_selectedRecord.ValidateCode, SearchLookupEditCode);
            SetErrorInfo(_selectedRecord.ValidateCategory, SearchLookupEditCategory);
            SetErrorInfo(_selectedRecord.ValidateSpecialValue, SearchLookupEditSpecialValue);
            SetErrorInfo(_selectedRecord.ValidateDepartureTime, TimeEditDepartureTime);
            SetErrorInfo(_selectedRecord.ValidateItemType, ComboBoxEditItemType);
            SetErrorInfo(_selectedRecord.ValidateDay, SpinEditDay);
            SetErrorInfo(_selectedRecord.ValidateLine, SpinEditLine);
            SetErrorInfo(_selectedRecord.ValidateItemCode, SearchLookupEditItemCode);
            SetErrorInfo(_selectedRecord.ValidateSupplierProductId, SearchLookupEditSupplierProduct);
            SetErrorInfo(_selectedRecord.ValidateItemCategory, GridLookupEditItemCategory);
            SetErrorInfo(_selectedRecord.ValidateUpdateInventory, ImageComboBoxEditUpdateInvt);
            SetErrorInfo(_selectedRecord.ValidateNights, SpinEditNights);
            SetErrorInfo(_selectedRecord.ValidateItemSpecialValue, GridLookupEditItemSpecialValue);
            SetErrorInfo(_selectedRecord.ValidateServiceTime, TimeEditServiceTime);
            SetErrorInfo(_selectedRecord.ValidateMeal, SearchLookupEditMeal);
            SetErrorInfo(_selectedRecord.ValidateOperator, SearchLookupEditOperator);
            SetErrorInfo(_selectedRecord.ValidatePickupType, ComboBoxEditPickupType);
            SetErrorInfo(_selectedRecord.ValidatePickupLocation, SearchLookupEditPickupLocation);
            SetErrorInfo(_selectedRecord.ValidatePickupInfoRequired, CheckEditPickupInfoRequired);
            SetErrorInfo(_selectedRecord.ValidateDropoffType, ComboBoxEditDropoffType);
            SetErrorInfo(_selectedRecord.ValidateDropoffLocation, SearchLookupEditDropoffLocation);
            SetErrorInfo(_selectedRecord.ValidateDropoffInfoRequired, CheckEditDropoffInfoRequired);
        }

        private void SetErrorInfo(Func<String> validationMethod, object sender)
        {
            BindingSource.EndEdit();        //force changes back into context for validation
            if (validationMethod != null) {
                string error = validationMethod.Invoke();
                ErrorProvider.SetError((Control)sender, error);
            }
        }

        void ClearBindings()
        {
            _ignoreLeaveRow = true;
            _ignorePositionChange = true;
            _selectedRecord = null;
            SetAllFieldsEnabledState(true);
            SetButtonEnabledState(false);
            BindingSource.DataSource = typeof(PCOMP);
            _ignoreLeaveRow = false;
            _ignorePositionChange = false;
        }

        private void GridViewLookup_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void PCompForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewLookup.IsFilterRow(GridViewLookup.FocusedRowHandle)) {
                ExecuteQuery();
                e.Handled = true;
            }
        }

        private void ExecuteQuery()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string query = "1=1";
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in GridViewLookup.VisibleColumns)
                {
                    string value = GridViewLookup.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, col.FieldName);
                    if (!string.IsNullOrEmpty(value))
                    {
                        query += $" and it.[{col.FieldName}] like '%{value}%'";
                    }
                }
                query += " order by it.CODE, it.CAT, it.SpecialValue_Code, it.DepartureTime, it.DAY, it.LINE";

                var records = _context.PCOMP.Where(query);
                GridViewLookup.DataSourceChanged += GridViewLookup_DataSourceChanged;
                //When the datasource is set, it automatically selects the first row even though the grid does not automatically select a row
                //Also the grid databinding may not have finished by the time BindingSource_CurrentChanged fires.
                //Thus we want to ignore the BindingSource_CurrentChanged event and allow the GridViewLookup_DataSourceChanged 
                //to handle selecting a record
                _ignorePositionChange = true;
                BindingSource.DataSource = records;
                GridViewLookup.ClearColumnsFilter();
                _ignorePositionChange = false;
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.DisplayError(ex);
            }
        }

        private void BarButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _ignoreLeaveRow = true;       //so that when the grid row changes it doesn't try to save again
            if (SaveRecord(true)) {
                _selectedRecord = new PCOMP();
                BindingSource.Add(_selectedRecord);
                GridViewLookup.FocusedRowHandle = GridViewLookup.FindRow(_selectedRecord);
                SetReadOnlyKeyFields(false);
                SetAllFieldsEnabledState(false);
                //If New is selected from an already blank record, the changed event will not fire on the editors
                //which control specific field enabling/disabling for HTL/OPT flags etc, so manually invoke
                //those routines here to disable those fields
                ItemTypeChanged(string.Empty);
                PackageChanged(string.Empty);
                SearchLookupEditCode.Focus();
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

        private void BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            //If the current record is changing as a result of removing a record to delete it, and it is the last
            //record in the table, then SetBindings will clear the bindings, which will cause the delete
            //to fail because the associated entities will become detached when their BindingSources are cleared.
            //Thus we have a flag which is set in that case to ignore this event.
            if (!_ignorePositionChange)
                SetBindings();
        }

        //This will fire in response to both a user selecting a value from the popup or from the value changing because of databinding
        //However, for the change in databinding it fires before BindingSource_CurrentRowChanged, so _selectedRecord will still be the 
        //prior value. Thus this is also invoked from BindingSource_CurrentRowChanged.
        private void ItemChanged(string code)
        {
            //If the product is empty (ie blank hotel) do not allow supplier, cat, rate plan etc to be entered
            if (string.IsNullOrEmpty(code)) {
                ClearProductKeyFields(true);
                SetProductKeyFieldsState(false, true);
            }
            else {
                SetProductKeyFieldsState(true, true);
                SetItemCategoryLookup(_selectedRecord.CAT1);
                SetItemSpecialValueLookup(_selectedRecord.SpecialValue_Code_Item);
                //The dropdown query does not take into account resdate or svcdate, so that users can see if there
                //are expired mappings.  The validation does take this into account and will not allow it to be saved.
                var suppProds = _context.SupplierProduct.Where(sp => sp.Product_Type == ComboBoxEditItemType.Text 
                    && sp.Product_Code_Internal == code && !sp.Inactive)
                    .Include(sp => sp.Supplier)
                    .ToList();
                if (suppProds.Count > 0) {
                    suppProds.Insert(0, null);
                }
                SearchLookupEditSupplierProduct.Properties.DataSource = suppProds;
            }

            if (ComboBoxEditItemType.Text == "OPT" && !string.IsNullOrEmpty(code)) {
                COMP rec = _context.COMP.FirstOrDefault(c => c.CODE == code);
                if (rec != null) {
                    SetPickupDropoffArvDepState(rec);
                }
            }
        }

        //This will fire only in response to the user selecting a value from the popup
        //in which case we want to default various info
        private void ItemChangedByUser()
        {
            string code = SearchLookupEditItemCode.EditValue?.ToString();

            if (ComboBoxEditItemType.Text == "HTL" && !string.IsNullOrEmpty(code)) {
                HOTEL rec = _context.HOTEL.FirstOrDefault(h => h.CODE == code);
                if (rec != null)
                    SearchLookupEditOperator.EditValue = rec.OPER;
            }

            //if (ComboBoxEditItemType.Text == "CAR") {
            //    SearchLookupEditCarOffice.Properties.DataSource = _context.CAROFF.Where(x => x.CODE == code).OrderBy(x => x.OFF).Select(x => new CodeName(x.OFF, x.NAME));
            //}

            if (ComboBoxEditItemType.Text == "OPT") {
                ClearPickupDropoffInfo();

                if (!string.IsNullOrEmpty(code)) {
                    COMP rec = _context.COMP.FirstOrDefault(c => c.CODE == code);
                    if (rec != null) {
                        SearchLookupEditOperator.EditValue = rec.OPER;
                        bool hasPickup = rec.PUDRP_REQ == "B" || rec.PUDRP_REQ == "P";
                        bool hasDropoff = rec.PUDRP_REQ == "B" || rec.PUDRP_REQ == "D";

                        if (hasPickup || hasDropoff) {
                            //Automatically set the pickup info to the prior hotel, and dropoff info to the next hotel
                            int currDay = (int)SpinEditDay.Value;
                            int currLine = (int)SpinEditLine.Value;
                            string cat = SearchLookupEditCategory.EditValue.ToString();
                            DateTime? time = TimeEditDepartureTime.EditValue as DateTime?;
                            string specialValue = SearchLookupEditSpecialValue.EditValue as string;

                            if (hasPickup) {
                                //previous hotel different day
                                PCOMP previousRec = _context.PCOMP.Where(p => p.CODE == code && p.CAT == cat && p.DepartureTime == time && p.SpecialValue_Code == specialValue
                                    && p.DAY <= currDay && p.LINE < currLine && p.TYPE == "HTL").OrderByDescending(p => p.DAY).FirstOrDefault();

                                if (previousRec != null) {
                                    ComboBoxEditPickupType.EditValue = "HTL";
                                    SearchLookupEditPickupLocation.EditValue = previousRec.CODE1;
                                }
                            }

                            if (hasDropoff) {
                                ///next hotel 
                                PCOMP nextRec = _context.PCOMP.Where(p => p.CODE == code && p.CAT == cat && p.DepartureTime == time && p.SpecialValue_Code == specialValue
                                    && p.DAY > currDay && p.TYPE == "HTL").OrderByDescending(p => p.DAY).FirstOrDefault();
                                if (nextRec != null) {
                                    ComboBoxEditDropoffType.EditValue = "HTL";
                                    SearchLookupEditDropoffLocation.EditValue = nextRec.CODE1;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ClearProductKeyFields(bool includeSupplierProduct)
        {
            if (includeSupplierProduct) {
                SearchLookupEditSupplierProduct.Properties.DataSource = null;
                SearchLookupEditSupplierProduct.EditValue = null;
            }
            GridLookupEditItemCategory.Properties.DataSource = null;
            GridLookupEditItemCategory.EditValue = null;
            GridLookupEditItemSpecialValue.Properties.DataSource = null;
            GridLookupEditItemSpecialValue.EditValue = null;
        }

        private void SetProductKeyFieldsState(bool enabled, bool includeSupplierProduct)
        {
            if (includeSupplierProduct) {
                SearchLookupEditSupplierProduct.Enabled = enabled;
            }
            GridLookupEditItemCategory.Enabled = enabled;
            SearchLookupEditSpecialValue.Enabled = enabled;
        }

        private void SetPickupDropoffArvDepState(COMP rec)
        {
            bool hasPickup = rec.PUDRP_REQ == "B" || rec.PUDRP_REQ == "P";
            bool hasDropoff = rec.PUDRP_REQ == "B" || rec.PUDRP_REQ == "D";
            SetPickupInfoState(hasPickup);
            SetDropoffInfoState(hasDropoff);
            bool hasArvInfo = rec.Require_ArvInfo == "Y" || rec.TRSFR_TYP == "I" || rec.TRSFR_TYP == "B" || rec.TRSFR_TYP == "M";
            bool hasDepInfo = rec.Require_DepInfo == "Y" || rec.TRSFR_TYP == "O" || rec.TRSFR_TYP == "B";
            SetArrivalInfoState(hasArvInfo);
            SetDepartureInfoState(hasDepInfo);
        }

        private void ClearPickupDropoffInfo()
        {
            ClearPickupLocation();
            ClearDropoffLocation();
            CheckEditDropoffInfoProhibited.Checked = false;
            CheckEditPickupInfoProhibited.Checked = false;
            CheckEditPickupInfoRequired.Checked = false;
            CheckEditDropoffInfoRequired.Checked = false;
            CheckEditPrivateCar.Checked = false;
            SearchLookupEditCarOffice.EditValue = null;
        }

        private void ClearPickupLocation()
        {
            ComboBoxEditPickupType.EditValue = null;
            SearchLookupEditPickupLocation.EditValue = null;
        }

        private void ClearDropoffLocation()
        {
            ComboBoxEditDropoffType.EditValue = null;
            SearchLookupEditDropoffLocation.EditValue = null;
        }

        private void ClearArrivalDepartureInfo()
        {
            SearchLookupEditDepDepartureCity.EditValue = null;
            SearchLookupEditDepArrivalCity.EditValue = null;
            TextEditDepFlight.EditValue = null;
            TextEditDepDepartureTime.EditValue = null;
            TextEditDepArrivalTime.EditValue = null;
            ComboBoxEditDepTransfer.EditValue = null;
            SearchLookupEditArvArrivalCity.EditValue = null;
            SearchLookupEditArvDepartureCity.EditValue = null;
            TextEditArvFlight.EditValue = null;
            TextEditArvDepartureTime.EditValue = null;
            TextEditArvArrivalTime.EditValue = null;
            ComboBoxEditArvTransfer.EditValue = null;
        }

        private void SetDepartureInfoState(bool enabled)
        {
            SearchLookupEditDepDepartureCity.Enabled = enabled;
            SearchLookupEditDepArrivalCity.Enabled = enabled;
            TextEditDepFlight.Enabled = enabled;
            TextEditDepDepartureTime.Enabled = enabled;
            TextEditDepArrivalTime.Enabled = enabled;
            ComboBoxEditDepTransfer.Enabled = enabled;
        }

        private void SetArrivalInfoState(bool enabled)
        {
            SearchLookupEditArvArrivalCity.Enabled = enabled;
            SearchLookupEditArvDepartureCity.Enabled = enabled;
            TextEditArvFlight.Enabled = enabled;
            TextEditArvDepartureTime.Enabled = enabled;
            TextEditArvArrivalTime.Enabled = enabled;
            ComboBoxEditArvTransfer.Enabled = enabled;
        }

        private void SetPickupInfoState(bool enabled)
        {
            SetPickupLocationState(enabled);
            CheckEditPickupInfoRequired.Enabled = enabled;
            CheckEditPickupInfoProhibited.Enabled = enabled;
        }

        private void SetPickupLocationState(bool enabled)
        {
            SearchLookupEditPickupLocation.Enabled = enabled;
            ComboBoxEditPickupType.Enabled = enabled;
        }

        private void SetDropoffInfoState(bool enabled)
        {
            SetDropoffLocationState(enabled);
            CheckEditDropoffInfoRequired.Enabled = enabled;
            CheckEditDropoffInfoProhibited.Enabled = enabled;
        }

        private void SetDropoffLocationState(bool enabled)
        {
            SearchLookupEditDropoffLocation.Enabled = enabled;
            ComboBoxEditDropoffType.Enabled = enabled;
        }

        private void ChangeLocationType(ComboBoxEdit comboType, SearchLookUpEdit location)
        {
            location.Properties.DataSource = null;
            if (comboType.EditValue != null) {
                string type = comboType.EditValue.ToString();
                switch (type) {
                    case "HTL":
                        location.Properties.DataSource = _hotels;
                        break;
                    case "OPT":
                        location.Properties.DataSource = _services;
                        break;
                    case "WAY":
                        location.Properties.DataSource = _waypoints;
                        break;
                    case "BUS":
                        location.Properties.DataSource = _busstations;
                        break;
                    case "TRN":
                        location.Properties.DataSource = _trainstations;
                        break;
                    case "CRU":
                        location.Properties.DataSource = _seaports;
                        break;
                    case "AIR":
                        location.Properties.DataSource = _airports;
                        break;
                }
            }
        }

        private void SupplierProductChangedByUser()
        {
            int? id = (int?)SearchLookupEditSupplierProduct.EditValue;
            if (id != null) {
                SupplierProduct rec = _context.SupplierProduct.FirstOrDefault(sp => sp.ID == id);
                if (rec != null)
                    SearchLookupEditOperator.EditValue = rec.Operator_Code;
            }
        }

        private void TimeEditServiceTime_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateServiceTime, sender);
        }

        private void ImageComboBoxEditUpdateInvt_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateUpdateInventory, sender);
        }

        private void TextEditDepFlight_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateDepFlight, sender);
        }

        private void TextEditDepDepartureTime_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateDepDepartureTime, sender);
        }

        private void TextEditDepArrivalTime_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateDepArrivalTime, sender);
        }

        private void ComboBoxEditDepTransfer_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateDepTransfer, sender);
        }

        private void TextEditArvFlight_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateArvFlight, sender);
        }

        private void TextEditArvDepartureTime_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateArvDepartureTime, sender);
        }

        private void TextEditArvArrivalTime_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateArvArrivalTime, sender);
        }

        private void ComboBoxEditArvTransfer_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateArvTransfer, sender);
        }

        private void ItemTypeChanged(string type)
        {
            SearchLookupEditItemCode.Properties.DataSource = null;
            SearchLookupEditItemCode.EditValue = null;
            switch (type) {
                case "":
                    PanelControlPickupDropoff.Visible = false;
                    TimeEditServiceTime.EditValue = null;
                    TimeEditServiceTime.Enabled = false;
                    TimeEditServiceTime.Visible = false;
                    ComboBoxEditRoom.Enabled = true;
                    SpinEditNights.Enabled = true;
                    SpinEditNights.Enabled = false;
                    SpinEditNights.EditValue = null;
                    SetPickupInfoState(false);
                    SetDropoffInfoState(false);
                    SetArrivalInfoState(false);
                    SetDepartureInfoState(false);
                    break;
                case "HTL":
                    PanelControlPickupDropoff.Visible = false;
                    SearchLookupEditItemCode.Properties.DataSource = _hotels;
                    TimeEditServiceTime.EditValue = null;
                    TimeEditServiceTime.Enabled = false;
                    TimeEditServiceTime.Visible = false;
                    ComboBoxEditRoom.Enabled = true;
                    SpinEditNights.Enabled = true;
                    SetPickupInfoState(false);
                    SetDropoffInfoState(false);
                    SetArrivalInfoState(false);
                    SetDepartureInfoState(false);
                    break;
                case "OPT":
                    PanelControlPickupDropoff.Visible = true;
                    TimeEditServiceTime.Visible = true;
                    SearchLookupEditItemCode.Properties.DataSource = _services;
                    TimeEditServiceTime.Enabled = true;
                    ComboBoxEditRoom.Enabled = false;
                    SpinEditNights.Enabled = false;
                    SpinEditNights.EditValue = null;
                    break;
            }
        }

        private void ComboBoxEditItemType_EditValueChanged(object sender, EventArgs e)
        {
            ItemTypeChanged(ComboBoxEditItemType.Text);
        }

        private void SearchLookupEditCode_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCode, sender);
        }

        private void SearchLookupEditCategory_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCategory, sender);
        }

        private void SearchLookupEditItemCode_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateItemCode, sender);
        }

        private void GridLookupEditItemCategory_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null) {
                //https://www.devexpress.com/Support/Center/Question/Details/T656198/gridlookupedit-processnewvalue-post-new-value
                GridLookupEditItemCategory.DataBindings[0].WriteValue();
                SetErrorInfo(_selectedRecord.ValidateItemCategory, sender);
            }
        }

        private void SearchLookupEditEditMeal_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateMeal, sender);
        }

        private void SearchLookupEditOperator_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateOperator, sender);
        }

        private void SearchLookupEditCarOffice_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCarOffice, sender);
        }

        private void SearchLookupEditPickupLocation_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidatePickupLocation, sender);
        }

        private void SearchLookupEditDropoffLocation_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateDropoffLocation, sender);
        }

        private void SearchLookupEditDepDepartureCity_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateDepDepartureCity, sender);
        }

        private void SearchLookupEditDepArrivalCity_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateDepArrivalCity, sender);
        }

        private void SearchLookupEditArvDepartureCity_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateArvDepartureCity, sender);
        }

        private void SearchLookupEditArvArrivalCity_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateArvArrivalCity, sender);
        }

        private void ComboBoxEditDropoffType_EditValueChanged(object sender, EventArgs e)
        {
            ChangeLocationType(ComboBoxEditDropoffType, SearchLookupEditDropoffLocation);
        }

        private void ComboBoxEditPickupType_EditValueChanged(object sender, EventArgs e)
        {
            ChangeLocationType(ComboBoxEditPickupType, SearchLookupEditPickupLocation);
        }

        private void SpinEditDay_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateDay, sender);
        }

        private void SearchLookupEditSpecialValue_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateSpecialValue, sender);
        }

        private void SpinEditLine_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateLine, sender);
        }

        private void SearchLookupEditItemCode_EditValueChanged(object sender, EventArgs e)
        {
            string code = SearchLookupEditItemCode.EditValue?.ToString();
            //This event fires before BindingSource.CurrentChanged (gahhhh!), but associated lookups can't change until
            //after BindingSource.CurrentChanged otherwise _selectedRecord isn't set to the right value
            if (_selectedRecord.CODE1 == code) {
                ItemChanged(code);
            }
        }

        private void SpinEditNights_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateNights, sender);
        }

        private void ComboBoxEditPickupType_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidatePickupType, sender);
        }

        private void ComboBoxEditDropoffType_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateDropoffType, sender);
        }

        private void ComboBoxEditItemType_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateItemType, sender);
        }

        private void TimeEditDepartureTime_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateDepartureTime, sender);
        }

        private void SimpleButtonClone_Click(object sender, EventArgs e)
        {
            //Create a new blank record with the same key values, not a full clone
            _ignoreLeaveRow = true;       //so that when the grid row changes it doesn't try to save again
            //Do not allow the user to perform this operation without saving the current record first. Do this by
            //not offering the "No" option in the save prompt. If the user could say No to saving the current record, 
            //it would result in either retrieving the previously saved version of the record from the db,
            //or discarding a new record, either of which may mean different values would be cloned from what the user is expecting 
            //based on what is on the screen
            if (SaveRecord(true, MessageBoxButtons.OKCancel)) {
                _selectedRecord = new PCOMP {
                    CODE = _selectedRecord.CODE,
                    CAT = _selectedRecord.CAT,
                    SpecialValue_Code = _selectedRecord.SpecialValue_Code,
                    DepartureTime = _selectedRecord.DepartureTime,
                    DAY = _selectedRecord.DAY,
                    LINE = (short)(GetLastLineForDay(_selectedRecord) + 1)
                };
                BindingSource.Add(_selectedRecord);
                GridViewLookup.FocusedRowHandle = GridViewLookup.FindRow(_selectedRecord);
                SimpleButtonClone.Enabled = false;
                ComboBoxEditItemType.Focus();
                SetAllFieldsEnabledState(false);
            }
            _ignoreLeaveRow = false;
        }

        private short GetLastLineForDay(PCOMP item)
        {
            return GetLastLineForDay(item, item.DAY);
        }

        private short GetLastLineForDay(PCOMP item, short day)
        {
            var pcomp = _context.PCOMP.Where(p => p.CODE == item.CODE && p.CAT == item.CAT
                && p.SpecialValue_Code == item.SpecialValue_Code && p.DepartureTime == item.DepartureTime
                && p.DAY == day)
                .OrderByDescending(p => p.LINE)
                .FirstOrDefault();
            if (pcomp == null) {
                return 0;
            }
            else {
                return pcomp.LINE;
            }
        }

        private (short day, short line) GetLastDayAndLineNumber(PCOMP item)
        {
            var next = _context.PCOMP.Where(p => p.CODE == item.CODE && p.CAT == item.CAT
                && p.SpecialValue_Code == item.SpecialValue_Code && p.DepartureTime == item.DepartureTime)
                .OrderByDescending(p => p.DAY).ThenByDescending(p => p.LINE)
                .FirstOrDefault();
            if (next == null) {
                return (1, 0);
            }
            else {
                return (next.DAY, next.LINE);
            }
        }

        private PCOMP GetPriorComponent(PCOMP item)
        {
            return _context.PCOMP.Where(p => p.CODE == item.CODE && p.CAT == item.CAT
                && p.SpecialValue_Code == item.SpecialValue_Code && p.DepartureTime == item.DepartureTime
                && (p.DAY < item.DAY || (p.DAY == item.DAY && p.LINE < item.LINE)))
                .OrderByDescending(p => p.DAY).ThenByDescending(p => p.LINE)
                .FirstOrDefault();
        }

        private PCOMP GetNextComponent(PCOMP item)
        {
            return _context.PCOMP.Where(p => p.CODE == item.CODE && p.CAT == item.CAT
                && p.SpecialValue_Code == item.SpecialValue_Code && p.DepartureTime == item.DepartureTime
                && (p.DAY > item.DAY || (p.DAY == item.DAY && p.LINE > item.LINE)))
                .OrderBy(p => p.DAY).ThenBy(p => p.LINE)
                .FirstOrDefault();
        }

        private void SimpleButtonUp_Click(object sender, EventArgs e)
        {
            //Do not allow the user to perform this operation without saving the current record first. Do this by
            //not offering the "No" option in the save prompt. If the user could say No to saving the current record, 
            //it would result in either retrieving the previously saved version of the record from the db,
            //or discarding a new record, either of which may mean the user would end up with a different position
            //from what they were expecting based on what is on the screen
            if (SaveRecord(true, MessageBoxButtons.OKCancel)) {
                PCOMP item = GetPriorComponent(_selectedRecord);
                //If there is no next component then the current record is the last one already
                SwapDayAndLine(item, _selectedRecord);
            }
        }

        private void SimpleButtonDown_Click(object sender, EventArgs e)
        {
            //Do not allow the user to perform this operation without saving the current record first. Do this by
            //not offering the "No" option in the save prompt. If the user could say No to saving the current record, 
            //it would result in either retrieving the previously saved version of the record from the db,
            //or discarding a new record, either of which may mean the user would end up with a different position
            //from what they were expecting based on what is on the screen
            if (SaveRecord(true, MessageBoxButtons.OKCancel)) {
                PCOMP item = GetNextComponent(_selectedRecord);
                //If there is no next component then the current record is the last one already
                SwapDayAndLine(item, _selectedRecord);
            }
        }

        private void SwapDayAndLine(PCOMP first, PCOMP second)
        {
            if (first == null || second == null)
                return;

            //Changing day or line will fire GridView_BeforeLeaveRow because the grid keeps the focus on the same
            //row even when it moves in the sort order. This is what we want, except that it will prompt about
            //saving the record, which we don't want, so disable that
            _ignoreLeaveRow = true;
            short val = first.DAY;
            first.DAY = second.DAY;
            second.DAY = val;
            val = first.LINE;
            first.LINE = second.LINE;
            second.LINE = val;
            SetUpdateFields(first);
            SetUpdateFields(second);
            _context.SaveChanges();
            _ignoreLeaveRow = false;
        }

        private void SetUpdateFields(PCOMP record)
        {
            record.LAST_UPD = DateTime.Now;
            record.UPD_INIT = _username;
        }

        private void CheckEditPickupInfoRequired_CheckedChanged(object sender, EventArgs e)
        {
            //If changes aren't forced back into the context, then when the context PropertyChanged event fires
            //when changing the value of the other checkbox, this checkbox will rebind to its prior value which
            //is not yet in the context. 
            BindingSource.EndEdit();
            if (CheckEditPickupInfoRequired.Checked) {
                CheckEditPickupInfoProhibited.Checked = false;
            }
            SetErrorInfo(_selectedRecord.ValidatePickupInfoRequired, sender);
        }

        private void CheckEditPickupInfoProhibited_CheckedChanged(object sender, EventArgs e)
        {
            BindingSource.EndEdit();
            SetPickupLocationState(!CheckEditPickupInfoProhibited.Checked);
            if (CheckEditPickupInfoProhibited.Checked) {
                CheckEditPickupInfoRequired.Checked = false;
                ClearPickupLocation();
            }
        }

        private void CheckEditDropoffInfoRequired_CheckedChanged(object sender, EventArgs e)
        {
            BindingSource.EndEdit();
            if (CheckEditDropoffInfoRequired.Checked) {
                CheckEditDropoffInfoProhibited.Checked = false;
            }
            SetErrorInfo(_selectedRecord.ValidateDropoffInfoRequired, sender);
        }

        private void CheckEditDropoffInfoProhibited_CheckedChanged(object sender, EventArgs e)
        {
            BindingSource.EndEdit();
            SetDropoffLocationState(!CheckEditPickupInfoProhibited.Checked);
            if (CheckEditDropoffInfoProhibited.Checked) {
                CheckEditDropoffInfoRequired.Checked = false;
                ClearDropoffLocation();
            }
        }

        private void GridViewLookup_DataSourceChanged(object sender, EventArgs e)
        {
            GridViewLookup.DataSourceChanged -= GridViewLookup_DataSourceChanged;
            if (GridViewLookup.DataRowCount == 0) {
                ClearBindings();
                this.DisplayInfo("No matching records found.");
            }
            else {
                GridViewLookup.FocusedRowHandle = 0;
                SetBindings();
            }
        }

        private void SearchLookupEditItemCode_Closed(object sender, ClosedEventArgs e)
        {
            if (e.CloseMode == PopupCloseMode.Normal) {
                ItemChangedByUser();
            }
        }

        private void SearchLookupEditCode_EditValueChanged(object sender, EventArgs e)
        {
            string code = SearchLookupEditCode.EditValue.ToStringEmptyIfNull();
            PackageChanged(code);
        }

        private void LookupEdit_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ((sender as LookUpEditBase).Properties.DataSource == null)
                e.Cancel = true;
            else
                e.Cancel = false;
        }

        private void GridLookupEditItemCategory_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {
            SetItemCategoryLookup(e.DisplayValue.ToString());
            e.Handled = true;
        }

        private void SearchLookUpEditSupplierProduct_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateSupplierProductId, sender);
        }

        private void SearchLookUpEditSupplierProduct_Closed(object sender, ClosedEventArgs e)
        {
            if (e.CloseMode == PopupCloseMode.Normal) {
                SupplierProductChangedByUser();
            }
        }

        private void GridLookUpEditItemSpecialValue_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null) {
                //https://www.devexpress.com/Support/Center/Question/Details/T656198/gridlookupedit-processnewvalue-post-new-value
                GridLookupEditItemSpecialValue.DataBindings[0].WriteValue();
                SetErrorInfo(_selectedRecord.ValidateItemSpecialValue, sender);
            }
        }

        private void GridLookUpEditItemSpecialValue_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {
            SetItemSpecialValueLookup(e.DisplayValue.ToString());
            e.Handled = true;
        }

        private void SearchLookupEditSupplierProduct_EditValueChanged(object sender, EventArgs e)
        {
            //If an external product is selected, inventory will not be updated
            //Sometimes DevExpress converts EditValue to a new empty object {}, not a null, so hence check whether it is null
            //or empty when converted to string, rather than just null
            if (SearchLookupEditSupplierProduct.EditValue.IsNullOrEmpty()) {
                ImageComboBoxEditUpdateInvt.Enabled = true;
            }
            else {
                ImageComboBoxEditUpdateInvt.Enabled = false;
                ImageComboBoxEditUpdateInvt.EditValue = "N";
            }
        }

        private void PackageChanged(string code)
        {
            TimeEditDepartureTime.Enabled = false;
            ComboBoxEditItemType.Properties.Items.Clear();
            ComboBoxEditItemType.Properties.Items.Add("OPT");
            if (!string.IsNullOrEmpty(code)) {
                PACK pkg = _context.PACK.FirstOrDefault(p => p.CODE == code);
                if (pkg != null) {
                    if (!pkg.ServicesOnly) {
                        ComboBoxEditItemType.Properties.Items.Add("HTL");
                    }
                    TimeEditDepartureTime.Enabled = pkg.MultipleTimes;
                    if (!pkg.MultipleTimes)
                        TimeEditDepartureTime.EditValue = null;
                }
            }
        }
    }
}