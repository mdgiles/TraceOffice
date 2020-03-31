using System.ComponentModel;
using System.Runtime.InteropServices;
using FlexEntities.Entities;
using DevExpress.XtraGrid.Views.Base;
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
using DevExpress.Data.Async.Helpers;
using FlexInterfaces.Core;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Drawing;
using DevExpress.XtraMap;
using DevExpress.Map;
using FlexCommissions;

namespace TraceForms
{
     
    public partial class BusTableForm : DevExpress.XtraEditors.XtraForm
    {
        BUSTABLE _selectedRecord;
        ICoreSys _sys;
        FlextourEntities _context;
        Timer _actionConfirmation;
        bool _ignoreLeaveRow = false, _ignorePositionChange = false;
        Dictionary<string, List<CodeName>> _locationLookups;
        Dictionary<string, List<CodeName>> _typeLookups;

        public BusTableForm(FlexInterfaces.Core.ICoreSys sys)
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
            _sys = sys;
        }

        private void LoadLookups()
        {
            CodeName loadBlank = new CodeName(string.Empty);

            _locationLookups = new Dictionary<string, List<CodeName>>();
            _typeLookups = new Dictionary<string, List<CodeName>>();

            List<CodeName> lookup;
            //EF will try to execute the entire projection on the sql side, which knows nothing about string.format so it will
            //error. Putting AsEnumerable beforehand will tell EF to execute sql side up to there and return results, then the
            //rest will be EF client side

            lookup = new List<CodeName>();
            lookup.AddRange(_context.HOTEL
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.NAME }));
            _locationLookups.Add("HTL", lookup);

            lookup = new List<CodeName>();
            lookup.AddRange(_context.WAYPOINT
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.DESC }));
            _locationLookups.Add("WAY", lookup);

            lookup = new List<CodeName>();
            lookup.AddRange(_context.CITYCOD
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.NAME }));
            _locationLookups.Add("CTY", lookup);

            lookup = new List<CodeName>();
            lookup.AddRange(_context.COMP
                .Where(c => c.TRSFR_TYP == "O" || c.TRSFR_TYP == "I")
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.NAME }));
            _typeLookups.Add("OPT", lookup);

            lookup = new List<CodeName>();
            lookup.AddRange(_context.PACK
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.NAME }));
            _typeLookups.Add("PKG", lookup);

            var categories = new List<CodeName> {
                new CodeName(null)
            };
            categories.AddRange(_context.ROOMCOD
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.DESC }).ToList());
            SearchLookUpEditCategory.Properties.DataSource = categories;
        }

        void SetReadOnly(bool value)
        {
            foreach (Control control in SplitContainerControl.Panel2.Controls) {
                control.Enabled = !value;
            }
        }

        void SetReadOnlyKeyFields(bool value)
        {
            SearchLookupEditCode.ReadOnly = value;
        }

        private bool SaveRecord(bool prompt)
        {
            try {
                if (_selectedRecord == null)
                    return true;

                FinalizeBindings();
                bool newRec = _selectedRecord.IsNew();
                bool modified = newRec || IsModified(_selectedRecord);
                bool nameChanged = _selectedRecord.IsModified(_context, "NAME");

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
                        _context.BUSTABLE.AddObject(_selectedRecord);
                    }
                    SetUpdateFields(_selectedRecord);
                    _context.SaveChanges();
                    if (newRec || nameChanged) {
                        AccountingAPI.InvokeForProduct(_sys.Settings.TourAccountingURL, "OPT", _selectedRecord.CODE);
                    }
                    EntityInstantFeedbackSource.Refresh();
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

        void SetBindings()
        {
            if (BindingSource.Current == null) {
                ClearBindings();
            }
            else {
                _selectedRecord = ((BUSTABLE)BindingSource.Current);
                SetReadOnly(false);
                SetReadOnlyKeyFields(true);
                BarButtonItemDelete.Enabled = true;
                BarButtonItemSave.Enabled = true;
            }
            ErrorProvider.Clear();
        }

        void ClearBindings()
        {
            _ignoreLeaveRow = true;
            _ignorePositionChange = true;
            _selectedRecord = null;
            SetReadOnly(true);
            BarButtonItemDelete.Enabled = false;
            BarButtonItemSave.Enabled = false;
            BindingSource.DataSource = typeof(BUSTABLE);
            _ignoreLeaveRow = false;
            _ignorePositionChange = false;
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

        private void RemoveRecord()
        {
            BindingSource.RemoveCurrent();
        }

        private bool IsModified(BUSTABLE record)
        {
            //Type-specific routine that takes into account relationships that should also be considered
            //when deciding if there are unsaved changes.  The entity properties also return true if the
            //record is new or deleted.
            if (record == null)
                return false;
            return record.IsModified(_context);
        }

        private void FinalizeBindings()
        {
            BindingSource.EndEdit();
        }

        private bool ValidateAll()
        {
            if (!_selectedRecord.Validate()) {
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
            SetErrorInfo(_selectedRecord.ValidateCode, SearchLookupEditCode);
            SetErrorInfo(_selectedRecord.ValidateType, ComboBoxEditType);
            SetErrorInfo(_selectedRecord.ValidateInOut, ImageComboBoxEditInOut);
            SetErrorInfo(_selectedRecord.ValidatePupDrp, ImageComboBoxEditPupDrp);
            SetErrorInfo(_selectedRecord.ValidateStart, DateEditStartDate);
            SetErrorInfo(_selectedRecord.ValidateEnd, DateEditEndDate);
            SetErrorInfo(_selectedRecord.ValidateLocType, ComboBoxEditLocationType);
            SetErrorInfo(_selectedRecord.ValidateLocation, SearchLookupEditLocation);
            SetErrorInfo(_selectedRecord.ValidateStartTime, TimeEditStartTime);
            SetErrorInfo(_selectedRecord.ValidateEndTime, TimeEditEndTime);
        }

        private void SetErrorInfo(Func<String> validationMethod, object sender)
        {
            BindingSource.EndEdit();
            if (validationMethod != null) {
                string error = validationMethod.Invoke();
                ErrorProvider.SetError((Control)sender, error);
            }
        }

        private void BusTableForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void GridViewLookup_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            //If the user selects a row, edits, then selects the auto-filter row, then selects a different row,
            //this event will fire for the auto-filter row, so we cannot ignore it because there is still a record
            //that may need to be saved. 
            if (!_ignoreLeaveRow && IsModified(_selectedRecord)) {
                e.Allow = SaveRecord(true);
            }
        }
        
        private void ComboBoxEditType_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateType, sender);
        }

        private void ComboBoxEditInOut_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateInOut, sender);
        }

        private void ComboBoxEditPupDrp_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidatePupDrp, sender);
        }

        private void DateEditStartDate_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateStart, sender);
        }

        private void DateEditEndDate_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateEnd, sender);
        }

        private void ComboBoxEditLocationType_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateLocType, sender);
        }

        private void TimeEditStartTime_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateStartTime, sender);
        }

        private void TimeEditEndTime_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateEndTime, sender);
        }

        private void ComboBoxEditType_TextChanged(object sender, EventArgs e)
        {
            SearchLookupEditCode.Enabled = true;
            string type = ComboBoxEditType.Text;
            LoadCodeLookupValues(type, SearchLookupEditCode);
        }

        private void LoadCodeLookupValues(string type, SearchLookUpEdit editor)
        {
            if (_typeLookups.ContainsKey(type)) {
                editor.Properties.DataSource = _typeLookups[type];
            }
            else {
                editor.Properties.DataSource = null;
            }
        }

        private void ComboBoxEditLocationType_TextChanged(object sender, EventArgs e)
        {
            SearchLookupEditLocation.Enabled = true;
            string type = ComboBoxEditLocationType.Text;
            LoadLocationLookupValues(type, SearchLookupEditLocation);
        }

        private void LoadLocationLookupValues(string type, SearchLookUpEdit editor)
        {
            if (_locationLookups.ContainsKey(type)) {
                editor.Properties.DataSource = _locationLookups[type];
            }
            else {
                editor.Properties.DataSource = null;
            }
        }

        private void DateEditStartDate_TextChanged(object sender, EventArgs e)
        {
            DateEditStartDate.Text = validCheck.convertDate(DateEditStartDate.Text);
        }

        private void DateEditEndDate_TextChanged(object sender, EventArgs e)
        {
            DateEditEndDate.Text = validCheck.convertDate(DateEditEndDate.Text);
        }

        private void ImageComboBoxEditCode_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCode, sender);
        }

        private void ImageComboBoxEditLocation_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateLocation, sender);
        }

        private void SetUpdateFields(BUSTABLE record)
        {
            record.LAST_UPD = DateTime.Now;
            record.UPD_INIT = _sys.User.Name;
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
                            _context.BUSTABLE.DeleteObject(_selectedRecord);
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

        private void BindingSource_CurrentChanged(object sender, System.EventArgs e)
        {
            //If the current record is changing as a result of removing a record to delete it, and it is the last
            //record in the table, then SetBindings will clear the bindings, which will cause the delete
            //to fail because the associated entities will become detached when their BindingSources are cleared.
            //Thus we have a flag which is set in that case to ignore this event.
            if (!_ignorePositionChange)
                SetBindings();
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

        private void BarButtonItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteRecord();
        }

        private void EntityInstantFeedbackSource_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            FlextourEntities context = new FlextourEntities(Connection.EFConnectionString);
            e.QueryableSource = context.BUSTABLE;
            e.Tag = context;
        }

        private void EntityInstantFeedbackSource_DismissQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            ((FlextourEntities)e.Tag).Dispose();
        }

        private void BarButtonItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SaveRecord(false))
                RefreshRecord();
        }

        private void GridViewLookup_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (!_ignoreLeaveRow) {
                GridView view = (GridView)sender;
                object row = view.GetRow(e.FocusedRowHandle);
                if (row != null && row.GetType() != typeof(DevExpress.Data.NotLoadedObject)) {
                    ReadonlyThreadSafeProxyForObjectFromAnotherThread proxy = (ReadonlyThreadSafeProxyForObjectFromAnotherThread)view.GetRow(e.FocusedRowHandle);
                    BUSTABLE record = (BUSTABLE)proxy.OriginalRow;
                    BindingSource.DataSource = _context.BUSTABLE.Where(c => c.CODE == record.CODE);
                    SearchLookupEditCode.ReadOnly = false;
                }
                else {
                    ClearBindings();
                }
            }
        }

        private void TimeEditServiceTime_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateServiceTime, sender);
        }

        private void SearchLookUpEditCategory_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCategory, sender);
        }

        private void BarButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _ignoreLeaveRow = true;       //so that when the grid row changes it doesn't try to save again
            if (SaveRecord(true)) {
                //For some reason when there is no existing record in the binding source the Add method does not
                //trigger the CurrentChanged event, but AddNew does so use that instead
                _selectedRecord = (BUSTABLE)BindingSource.AddNew();
                //With the instant feedback data source, the new row is not immediately added to the grid, so move
                //the focused row to the filter row just so that no other existing row is visually highlighted
                GridViewLookup.FocusedRowHandle = DevExpress.Data.BaseListSourceDataController.FilterRow;
                SetReadOnlyKeyFields(false);
                ComboBoxEditType.Focus();
                SetReadOnly(false);
            }
            ErrorProvider.Clear();
            _ignoreLeaveRow = false;
        }
    }
}