using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using FlexModel;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Popup;
using DevExpress.Utils.Win;
using DevExpress.XtraGrid.Views.Grid;
using Custom_SearchLookupEdit;
using DevExpress.Data.Async.Helpers;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects.DataClasses;

namespace TraceForms
{

    public partial class PRatesForm : DevExpress.XtraEditors.XtraForm
    {
        FlextourEntities _context;
        PRATES _selectedRecord;
        List<PACK> _packages;
        Timer _actionConfirmation;
        bool _ignoreLeaveRow = false, _ignorePositionChange = false;
        FlexInterfaces.Core.ICoreSys _sys;

        public PRatesForm(FlexInterfaces.Core.ICoreSys sys)
        {
            try {
                InitializeComponent();
                _sys = sys;
                Connect(sys);
                LoadLookups();
                SetReadOnly(true);
                GridViewLookup.FocusedRowHandle = DevExpress.Data.BaseListSourceDataController.FilterRow;
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
            List<CodeName> lookup;
            //EF will try to execute the entire projection on the sql side, which knows nothing about string.format so it will
            //error. Putting AsEnumerable beforehand will tell EF to execute sql side up to there and return results, then the
            //rest will be EF client side

            lookup = new List<CodeName>();
            lookup.AddRange(_context.HOTEL
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.NAME }));
            lookup.Insert(0, new CodeName());
            SearchLookupEditHotelCode.Properties.DataSource = lookup;

            _packages = _context.PACK
                .OrderBy(t => t.CODE).ToList();
            lookup = new List<CodeName>();
            lookup.AddRange(_packages.Select(t => new CodeName() { Code = t.CODE, Name = t.NAME }));
            SearchLookupEditCode.Properties.DataSource = lookup;

            lookup = new List<CodeName>();
            lookup.AddRange(_context.AGY
                .OrderBy(t => t.NO)
                .Select(t => new CodeName() { Code = t.NO, Name = t.NAME }));
            SearchLookupEditAgency.Properties.DataSource = lookup;

            lookup = new List<CodeName>();
            lookup.AddRange(_context.ROOMCOD
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.DESC }));
            SearchLookupEditCategory.Properties.DataSource = lookup;

            var specialVals = _context.SpecialValue.Where(a => a.Type == "PKG").OrderBy(x => x.Code)
            .Select(x => new CodeName() { Code = x.Code, Name = x.Name }).ToList();
            specialVals.Insert(0, new CodeName());
            SearchLookupEditSpecialValue.Properties.DataSource = specialVals;
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
            SearchLookupEditAgency.ReadOnly = value;
            SearchLookupEditCategory.ReadOnly = value;
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
                    }
                    if (!ValidateAll())
                        return false;

                    if (_selectedRecord.EntityState == EntityState.Detached) {
                        _context.PRATES.AddObject(_selectedRecord);
                    }
                    SetUpdateFields(_selectedRecord);
                    _context.SaveChanges();
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

        private void SetUpdateFields(PRATES record)
        {
            record.LAST_UPD = DateTime.Now;
            record.UPD_INIT = _sys.User.Name;
        }

        private bool IsModified(PRATES record)
        {
            //Type-specific routine that takes into account relationships that should also be considered
            //when deciding if there are unsaved changes.  The entity properties also return true if the
            //record is new or deleted.
            if (record == null)
                return false;
            return record.IsModified(_context);
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
                WarningProvider.Clear();
                return true;
            }
        }

        private void ShowMainControlErrors()
        {
            //The error indicators inside the grids are handled by binding, but errors on the main form must
            //be set manually
            SetErrorInfo(_selectedRecord.ValidateCode, SearchLookupEditCode);
            SetErrorInfo(_selectedRecord.ValidateCategory, SearchLookupEditCategory);
            SetErrorInfo(_selectedRecord.ValidateAgency, SearchLookupEditAgency);
            SetErrorInfo(_selectedRecord.ValidateHotel, SearchLookupEditHotelCode);
            SetErrorInfo(_selectedRecord.ValidateStart, DateEditStartDate);
            SetErrorInfo(_selectedRecord.ValidateSeason, TextEditSeason);
            SetErrorInfo(_selectedRecord.ValidateEnd, DateEditEndDate);
            SetErrorInfo(_selectedRecord.ValidateResStart, DateEditResStartDate);
            SetErrorInfo(_selectedRecord.ValidateResEnd, DateEditResEndDate);
            SetErrorInfo(_selectedRecord.ValidateSpecialValue, SearchLookupEditSpecialValue);
            SetErrorInfo(_selectedRecord.ValidateStart, DateEditStartDate);
            SetErrorInfo(_selectedRecord.ValidateEnd, DateEditEndDate);
            SetErrorAndWarningInfo(_selectedRecord.ValidateNetSgl, SpinEditNetSgl);
            SetErrorAndWarningInfo(_selectedRecord.ValidateNetDbl, SpinEditNetDbl);
            SetErrorAndWarningInfo(_selectedRecord.ValidateNetTpl, SpinEditNetTpl);
            SetErrorAndWarningInfo(_selectedRecord.ValidateNetQua, SpinEditNetQua);
            SetErrorAndWarningInfo(_selectedRecord.ValidateNetOth, SpinEditNetOth);
            SetErrorAndWarningInfo(_selectedRecord.ValidateNetChd, SpinEditNetChd);
            SetErrorAndWarningInfo(_selectedRecord.ValidateNetJr, SpinEditNetJr);
            SetErrorAndWarningInfo(_selectedRecord.ValidateNetSr, SpinEditNetSr);
            SetErrorAndWarningInfo(_selectedRecord.ValidateGrossSgl, SpinEditGrossSgl);
            SetErrorAndWarningInfo(_selectedRecord.ValidateGrossDbl, SpinEditGrossDbl);
            SetErrorAndWarningInfo(_selectedRecord.ValidateGrossTpl, SpinEditGrossTpl);
            SetErrorAndWarningInfo(_selectedRecord.ValidateGrossQua, SpinEditGrossQuad);
            SetErrorAndWarningInfo(_selectedRecord.ValidateGrossOth, SpinEditGrossOth);
            SetErrorAndWarningInfo(_selectedRecord.ValidateGrossChd, SpinEditGrossChd);
            SetErrorAndWarningInfo(_selectedRecord.ValidateGrossJr, SpinEditGrossJr);
            SetErrorInfo(_selectedRecord.ValidateGrossSenior, SpinEditGrossSr);
            SetErrorAndWarningInfo(_selectedRecord.ValidateRetailSgl, SpinEditRetailSgl);
            SetErrorAndWarningInfo(_selectedRecord.ValidateRetailDbl, SpinEditRetailDbl);
            SetErrorAndWarningInfo(_selectedRecord.ValidateRetailTpl, SpinEditRetailTpl);
            SetErrorAndWarningInfo(_selectedRecord.ValidateRetailQua, SpinEditRetailQua);
            SetErrorAndWarningInfo(_selectedRecord.ValidateRetailOth, SpinEditRetailOth);
            SetErrorAndWarningInfo(_selectedRecord.ValidateRetailChd, SpinEditRetailChd);
            SetErrorAndWarningInfo(_selectedRecord.ValidateRetailJr, SpinEditRetailJr);
            SetErrorAndWarningInfo(_selectedRecord.ValidateRetailSr, SpinEditRetailSr);
            SetErrorAndWarningInfo(_selectedRecord.ValidateExtraGrossSgl, SpinEditExtraGrossSgl);
            SetErrorAndWarningInfo(_selectedRecord.ValidateExtraGrossDbl, SpinEditExtraGrossDbl);
            SetErrorAndWarningInfo(_selectedRecord.ValidateExtraGrossTpl, SpinEditExtraGrossTpl);
            SetErrorAndWarningInfo(_selectedRecord.ValidateExtraGrossQua, SpinEditExtraGrossQua);
            SetErrorAndWarningInfo(_selectedRecord.ValidateExtraGrossOth, SpinEditExtraGrossOth);
            SetErrorAndWarningInfo(_selectedRecord.ValidateExtraGrossChd, SpinEditExtraGrossChd);
            SetErrorAndWarningInfo(_selectedRecord.ValidateExtraGrossJr, SpinEditExtraGrossJr);
            SetErrorAndWarningInfo(_selectedRecord.ValidateExtraNetSgl, SpinEditExtraNetSgl);
            SetErrorAndWarningInfo(_selectedRecord.ValidateExtraNetDbl, SpinEditExtraNetDbl);
            SetErrorAndWarningInfo(_selectedRecord.ValidateExtraNetTpl, SpinEditExtraNetTpl);
            SetErrorAndWarningInfo(_selectedRecord.ValidateExtraNetQua, SpinEditExtraNetQua);
            SetErrorAndWarningInfo(_selectedRecord.ValidateExtraNetOth, SpinEditExtraNetOth);
            SetErrorAndWarningInfo(_selectedRecord.ValidateExtraNetChd, SpinEditExtraNetChd);
            SetErrorAndWarningInfo(_selectedRecord.ValidateExtraNetJr, SpinEditExtraNetJr);
            SetErrorInfo(_selectedRecord.ValidateMaxSgl, SpinEditMaxSgl);
            SetErrorInfo(_selectedRecord.ValidateMaxDbl, SpinEditMaxDbl);
            SetErrorInfo(_selectedRecord.ValidateMaxTpl, SpinEditMaxTpl);
            SetErrorInfo(_selectedRecord.ValidateMaxQua, SpinEditMaxQua);
            SetErrorInfo(_selectedRecord.ValidateMaxOth, SpinEditMaxOth);
            SetErrorAndWarningInfo(_selectedRecord.ValidateChildLimit, SpinEditChildLimit);
            SetErrorAndWarningInfo(_selectedRecord.ValidateJrLimit, SpinEditJrLimit);
            SetErrorAndWarningInfo(_selectedRecord.ValidateSeniorLimit, SpinEditSrLimit);
        }

        private void SetErrorAndWarningInfo(Func<(String, String)> validationMethod, object sender)
        {
            BindingSource.EndEdit();        //force changes back into context for validation
            if (validationMethod != null) {
                ErrorProvider.SetError((Control)sender, string.Empty);
                WarningProvider.SetError((Control)sender, string.Empty);
                (string error, string warning) result = validationMethod.Invoke();
                if (!string.IsNullOrEmpty(result.error)) {
                    ErrorProvider.SetError((Control)sender, result.error);
                }
                else if (!string.IsNullOrEmpty(result.warning)) {
                    WarningProvider.SetError((Control)sender, result.warning);
                }
            }
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
        }

        void SetBindings()
        {
            if (BindingSource.Current == null) {
                ClearBindings();
            }
            else {
                SetFieldAndButtonStates(isExistingRecord: true);
            }
            ErrorProvider.Clear();
            WarningProvider.Clear();
        }

        private void SetFieldAndButtonStates(bool isExistingRecord)
        {
            _selectedRecord = ((PRATES)BindingSource.Current);
            SetReadOnly(false);
            SetReadOnlyKeyFields(isExistingRecord);
            BarButtonItemDelete.Enabled = true;
            BarButtonItemSave.Enabled = true;
            BarButtonItemShowOverlapping.Enabled = true;
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
                            _context.PRATES.DeleteObject(_selectedRecord);
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
            SetReadOnly(true);
            BarButtonItemDelete.Enabled = false;
            BarButtonItemSave.Enabled = false;
            BarButtonItemShowOverlapping.Enabled = false;
            BindingSource.DataSource = typeof(PRATES);
            _ignoreLeaveRow = false;
            _ignorePositionChange = false;
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

        private void PRatesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsModified(_selectedRecord))
            {
                DialogResult select = DisplayHelper.QuestionYesNo(this, "There are unsaved changes. Are you sure want to exit?");
                if (select == DialogResult.Yes) {
                    e.Cancel = false;
                    _context.Dispose();
                    Dispose();
                }
                else
                    e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                this.Dispose();
            }
        }

        private void DateEditStartDate_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateStart, sender);
        }

        private void DateEditResStartDate_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateResStart, sender);
        }

        private void DateEditEndDate_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateEnd, sender);
        }

        private void TextEditHL_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateSeason, sender);
        }

        private void ComboBoxEditYear_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateYear, sender);
        }

        private void TextEditDesc_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateDesc, sender);
        }

        private void DateEditResEndDate_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateResEnd, sender);
        }

        private void TextEditCommPct_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateComm, sender);
        }

        private void SpinEditGrossSingle_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateGrossSgl, sender);
            }

        private void SpinEditNetSingle_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateNetSgl, sender);
        }

        private void TextEditExtraGrossSingle_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateExtraGrossSgl, sender);
        }

        private void TextEditExtraSingleNet_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateExtraNetSgl, sender);
        }

        private void TextEditMaxSingle_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateMaxSgl, sender);
        }

        private void TextEditGrossDouble_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateGrossDbl, sender);
        }

        private void TextEditNetDouble_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateNetDbl, sender);
        }

        private void TextEditExtraGrossDouble_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateExtraGrossDbl, sender);
        }

        private void TextEditExtraNetDouble_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateExtraNetDbl, sender);
        }

        private void TextEditMaxDouble_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateMaxDbl, sender);
        }

        private void TextEditGrossTriple_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateGrossTpl, sender);         
        }

        private void TextEditNetTriple_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateNetTpl, sender);
        }

        private void TextEditExtraGrossTriple_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateExtraGrossTpl, sender);
        }

        private void TextEditExtraNetTriple_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateExtraNetTpl, sender);
        }

        private void TextEditMaxTriple_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateMaxTpl, sender);
        }

        private void TextEditGrossQuad_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateGrossQua, sender);
        }

        private void TextEditNetQua_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateNetQua, sender);
        }

        private void TextEditExtraGrossQua_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateExtraGrossQua, sender);
        }

        private void TextEditExtraNetQua_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateExtraNetQua, sender);
        }

        private void TextEditMaxQuad_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateMaxQua, sender);
        }

        private void TextEditOtherGross_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateGrossOth, sender);
        }

        private void TextEditOtherNet_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateNetOth, sender);
        }

        private void TextEditExtraOtherGross_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateExtraGrossOth, sender);
        }

        private void TextEditExtraNetOth_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateExtraNetOth, sender);
        }

        private void TextEditMaxOth_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateMaxOth, sender);
        }

        private void TextEditGrossChild_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateGrossChd, sender);
        }

        private void SpinEditNetChd_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateNetChd, sender);
        }

        private void SpinEditExtraGrossChd_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateExtraGrossChd, sender);
        }

        private void SpinEditExtraNetChd_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateExtraNetChd, sender);
        }

        private void SpinEditLimitChd_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateChildLimit, sender);
        }

        private void SpinEditGrossJr_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateGrossJr, sender);
        }

        private void SpinEditNetJr_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateNetJr, sender);
        }

        private void SpinEditExtraGrossJr_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateExtraGrossJr, sender);
        }

        private void SpinEditExtraNetJr_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateExtraNetJr, sender);
        }

        private void SpinEditJrLimt_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateJrLimit, sender);
        }

        private void overlappingRatesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SearchLookupEditCode_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCode, sender);
        }

        private void SearchLookupEditAgency_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateAgency, sender);
        }

        private void ImageComboBoxEditHotelCode_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateHotel, sender);
        }

        private void SearchLookupEditCategory_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCategory, sender);
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

        private void GridViewLookup_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (!_ignoreLeaveRow) {
                GridView view = (GridView)sender;
                object row = view.GetRow(e.FocusedRowHandle);
                if (row != null && row.GetType() != typeof(DevExpress.Data.NotLoadedObject)) {
                    ReadonlyThreadSafeProxyForObjectFromAnotherThread proxy = (ReadonlyThreadSafeProxyForObjectFromAnotherThread)view.GetRow(e.FocusedRowHandle);
                    PRATES record = (PRATES)proxy.OriginalRow;
                    BindingSource.DataSource = _context.PRATES.Where(c => c.ID == record.ID);
                }
                else {
                    ClearBindings();
                }
            }
        }

        private void ImageComboBoxEditAgency_TextChanged(object sender, System.EventArgs e)
        {
            string agency = SearchLookupEditAgency.EditValue.ToString();
            if (agency == "TARIFF")
            {
                SpinEditCommPct.Enabled = true;
                CheckEditCommFlg.Enabled = true;
            }
            else
            {
                SpinEditCommPct.Enabled = false;
                CheckEditCommFlg.Enabled = false;
                CheckEditCommFlg.Checked = false;
                SpinEditCommPct.Value = 0;
            }

        }

        private void SpinEditRetailSingle_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateRetailSgl, sender);
        }

        private void SpinEditRetailDouble_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateRetailDbl, sender);
        }

        private void SpinEditRetailTriple_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateRetailTpl, sender);
        }

        private void SpinEditRetailQuad_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateRetailQua, sender);
        }

        private void SpinEditRetailOther_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateRetailOth, sender);
        }

        private void SpinEditRetailChild_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateRetailChd, sender);
        }

        private void SpinEditRetailJunior_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateRetailJr, sender);
        }

        private void SpinEditRetailSenior_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateRetailSr, sender);
        }

        private void SpinEditSeniorAgeLimit_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateSeniorLimit, sender);
        }

        private void SpinEditGrossSenior_Leave(object sender, EventArgs e)
        {
            //if (_selectedRecord != null)
            //    SetErrorAndWarningInfo(_selectedRecord.ValidateGrossSenior, sender);

            //if (SpinEditGrossSr.Value < SpinEditNetSr.Value)
            //{
            //    DialogResult select = XtraMessageBox.Show("The gross rate is less than the cost. Is this this correct?", "Gross Rate", MessageBoxButtons.YesNo);
            //    if (select == DialogResult.No)
            //    {
            //        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
            //        SpinEditNetJr.Focus();
            //        return;
            //    }
            //}
        }

        private void SpinEditCostSenior_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorAndWarningInfo(_selectedRecord.ValidateNetSr, sender);
        }

        private void LookupEdit_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ((sender as LookUpEditBase).Properties.DataSource == null)
                e.Cancel = true;
            else
                e.Cancel = false;
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

        private void SearchLookupEditCode_EditValueChanged(object sender, EventArgs e)
        {
            PACK package = _packages.FirstOrDefault(p => p.CODE == SearchLookupEditCode.EditValue.ToStringEmptyIfNull());
            if (package != null) {
                SetControlStateEnabled(TimeEditTime, package.MultipleTimes, null);
                //Disable all the room rates except for single, and relabel the single as Adult
                //The single rate will be interpreted as per person
                foreach (BaseControl control in PanelControlRoomRates.Controls) {
                    SetControlStateEnabled(control, !package.ServicesOnly, null);
                }
                foreach (BaseControl control in PanelControlExtraNights.Controls) {
                    SetControlStateEnabled(control, !package.ServicesOnly, null);
                }
                SetControlStateEnabled(SearchLookupEditHotelCode, !package.ServicesOnly, null);
                LabelControlSingleLabel.Text = package.ServicesOnly ? "Adult" : "Single";
            }
        }

        private void SetControlStateEnabled(BaseControl control, bool enabled, object disabledVal)
        {
            control.Enabled = enabled;
            if (!control.Enabled && control.GetType() == typeof(BaseEdit)) {
                ((BaseEdit)control).EditValue = disabledVal;
            }
        }

        private void BarButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _ignoreLeaveRow = true;       //so that when the grid row changes it doesn't try to save again
            if (SaveRecord(true)) {
                //For some reason when there is no existing record in the binding source the Add method does not
                //trigger the CurrentChanged event
                BindingSource.AddNew();
                //With the instant feedback data source, the new row is not immediately added to the grid, so move
                //the focused row to the filter row just so that no other existing row is visually highlighted
                GridViewLookup.FocusedRowHandle = DevExpress.Data.BaseListSourceDataController.FilterRow;
                SetFieldAndButtonStates(isExistingRecord: false);
                SearchLookupEditCode.Focus();
            }
            ErrorProvider.Clear();
            WarningProvider.Clear();
            _ignoreLeaveRow = false;
        }

        private void BarButtonItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteRecord();
        }

        private void EntityInstantFeedbackSource_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            FlextourEntities context = new FlextourEntities(Connection.EFConnectionString);
            e.QueryableSource = context.PRATES;
            e.Tag = context;
        }

        private void EntityInstantFeedbackSource_DismissQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            ((FlextourEntities)e.Tag).Dispose();
        }

        private void BarToggleSwitchItemGrid_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (BarToggleSwitchItemGrid.Checked) {
                GridViewLookup.Columns["END_DATE"].Visible = true;
                GridViewLookup.Columns["END_DATE"].VisibleIndex = 4;
                GridViewLookup.Columns["ResDate_Start"].Visible = true;
                GridViewLookup.Columns["ResDate_Start"].VisibleIndex = 5;
                GridViewLookup.Columns["ResDate_End"].Visible = true;
                GridViewLookup.Columns["ResDate_End"].VisibleIndex = 6;
                GridViewLookup.Columns["Inactive"].Visible = true;
                GridViewLookup.Columns["Inactive"].VisibleIndex = 7;
                GridViewLookup.Columns["AGENCY"].Visible = true;
                GridViewLookup.Columns["AGENCY"].VisibleIndex = 8;
                GridViewLookup.Columns["CODE"].Width = 65;
            }
            else {
                GridViewLookup.Columns["AGENCY"].Visible = false;
                GridViewLookup.Columns["ResDate_Start"].Visible = false;
                GridViewLookup.Columns["ResDate_End"].Visible = false;
                GridViewLookup.Columns["END_DATE"].Visible = false;
                GridViewLookup.Columns["Inactive"].Visible = false;
            }
        }

        private void SearchLookupEditSpecialValue_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateSpecialValue, sender);
        }

        private void BarButtonItemShowOverlapping_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime? svcStart = DateEditStartDate.DateTime;
            DateTime? svcEnd = (DateEditEndDate.DateTime == DateTime.MinValue ? DateTime.MaxValue : (DateTime?)DateEditEndDate.DateTime);
            DateTime resStart = DateEditResStartDate.DateTime;
            DateTime resEnd = (DateEditResEndDate.DateTime == DateTime.MinValue ? DateTime.MaxValue : DateEditResEndDate.DateTime);
            string code = SearchLookupEditCode.EditValue.ToString();
            string agency = SearchLookupEditAgency.EditValue.ToString();
            string cat = SearchLookupEditCategory.EditValue.ToString();
            DateTime? time = (TimeEditTime.Time == DateTime.MinValue ? null : (DateTime?)TimeEditTime.Time);
            string hcode = SearchLookupEditHotelCode.EditValue.ToString();
            bool inactive = (bool)CheckEditInactive.EditValue;
            if (!inactive) {
                //The sql I want to determine date overlaps:
                //start between c.START_DATE and c.END_DATE OR end between c.START_DATE and c.END_DATE OR
                //c.START_DATE between start and end OR c.END_DATE between start and end
                var overlaps = from c in _context.PRATES
                           where c.CODE == code && c.ID != _selectedRecord.ID && c.AGENCY == agency && c.CAT == cat && c.HCODE == hcode && c.Inactive == false
                            && c.DepartureTime == time && ((svcStart >= c.START_DATE && svcStart <= c.END_DATE) || (svcEnd >= c.START_DATE && svcEnd <= c.END_DATE)
                               || (c.START_DATE >= svcStart && c.START_DATE <= svcEnd) || (c.END_DATE >= svcStart && c.END_DATE <= svcEnd))
                               && ((resStart >= (c.ResDate_Start ?? DateTime.MinValue) && resStart <= (c.ResDate_End ?? DateTime.MaxValue) 
                               || (resEnd >= (c.ResDate_Start ?? DateTime.MinValue) && resEnd <= (c.ResDate_End ?? DateTime.MaxValue))
                               || ((c.ResDate_Start ?? DateTime.MinValue) >= resStart && (c.ResDate_Start ?? DateTime.MinValue) <= resEnd) 
                               || ((c.ResDate_End ?? DateTime.MaxValue) >= resStart && (c.ResDate_End ?? DateTime.MaxValue) <= resEnd)))
                           select c;
                if (overlaps.Count() > 0) {
                    GridControl2.DataSource = overlaps;
                    PopupContainerControl1.Top = LabelCode.Top;
                    PopupContainerControl1.Left = LabelCode.Left;
                    PopupContainerControl1.BringToFront();
                    PopupContainerControl1.Show();
                    return;
                }
            }

            MessageBox.Show("No other rate sheets overlap the current rate sheet.");
        }

        private void SimpleButtonClosePopup_Click(object sender, EventArgs e)
        {
            PopupContainerControl1.Hide();
        }

        private void PRatesForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) {

            }
        }

        private void BarButtonItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SaveRecord(false))
                RefreshRecord();
        }
    }
}