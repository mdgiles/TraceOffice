using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects.DataClasses;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.Data.Async.Helpers;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Popup;
using DevExpress.Utils.Win;
using DevExpress.XtraGrid.Views.Grid;
using FlexModel;
using Custom_SearchLookupEdit;

namespace TraceForms
{  
    public partial class CpRatesForm : DevExpress.XtraEditors.XtraForm
    {
        FlextourEntities _context;
        CPRATES _selectedRecord;
        Timer _actionConfirmation;
        bool _ignoreLeaveRow = false, _ignorePositionChange = false;
        Dictionary<String, List<CodeName>> _productLookups;
        FlexInterfaces.Core.ICoreSys _sys;

        public CpRatesForm(FlexInterfaces.Core.ICoreSys sys)
        {
            try {
                InitializeComponent();
                Connect(sys);
                LoadLookups();
                _sys = sys;
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
            CodeName loadBlank = new CodeName(string.Empty);

            _productLookups = new Dictionary<String, List<CodeName>>();

            List<CodeName> lookup;
            //EF will try to execute the entire projection on the sql side, which knows nothing about string.format so it will
            //error. Putting AsEnumerable beforehand will tell EF to execute sql side up to there and return results, then the
            //rest will be EF client side

            lookup = new List<CodeName>();
            lookup.AddRange(_context.AGY
                .OrderBy(t => t.NO)
                .Select(t => new CodeName() { Code = t.NO, Name = t.NAME }));
            SearchLookupEditAgency.Properties.DataSource = lookup;

            lookup = new List<CodeName>();
            lookup.AddRange(_context.COMP
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.NAME }));
            SearchLookupEditCode.Properties.DataSource = lookup;

            lookup = new List<CodeName>();
            lookup.AddRange(_context.ROOMCOD
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.DESC }));
            SearchLookupEditCategory.Properties.DataSource = lookup;
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

        private void GridViewLookup_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            //If the user selects a row, edits, then selects the auto-filter row, then selects a different row,
            //this event will fire for the auto-filter row, so we cannot ignore it because there is still a record
            //that may need to be saved. 
            if (!_ignoreLeaveRow && IsModified(_selectedRecord)) {
                e.Allow = SaveRecord(true);
            }
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
                        _context.CPRATES.AddObject(_selectedRecord);
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

        private void SetUpdateFields(CPRATES record)
        {
            record.LAST_UPD = DateTime.Now;
            record.UPD_INIT = _sys.User.Name;
        }

        private bool IsModified(CPRATES record)
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
            SetErrorInfo(_selectedRecord.ValidateStart, DateEditStart);
            SetErrorInfo(_selectedRecord.ValidateEnd, DateEditEnd);
            SetErrorInfo(_selectedRecord.ValidateResStart, DateEditResStart);
            SetErrorInfo(_selectedRecord.ValidateResEnd, DateEditResEnd);
            SetErrorInfo(_selectedRecord.ValidateSeason, TextEditSeason);
            SetErrorInfo(_selectedRecord.ValidateYear, ComboBoxEditYear);
            SetErrorInfo(_selectedRecord.ValidateDesc, TextEditDesc);
            SetErrorInfo(_selectedRecord.ValidateTransfer, ComboBoxEditTransportType);
            SetErrorInfo(_selectedRecord.ValidateComm, SpinEditCommPct);
            SetErrorInfo(_selectedRecord.ValidateDays, SpinEditRouteDays);
            SetErrorInfo(_selectedRecord.ValidateNbrPpl1, SpinEditPp1);
            SetErrorInfo(_selectedRecord.ValidateNbrPpl2, SpinEditPp2);
            SetErrorInfo(_selectedRecord.ValidateNbrPpl3, SpinEditPp3);
            SetErrorInfo(_selectedRecord.ValidateNbrPpl4, SpinEditPp4);
            SetErrorInfo(_selectedRecord.ValidateNbrPpl5, SpinEditPp5);
            SetErrorInfo(_selectedRecord.ValidateNbrPpl6, SpinEditPp6);
            SetErrorInfo(_selectedRecord.ValidateNbrPpl7, SpinEditPp7);
            SetErrorInfo(_selectedRecord.ValidateNbrPpl8, SpinEditPp8);
            SetErrorInfo(_selectedRecord.ValidateNbrPpl9, SpinEditPp9);
            SetErrorInfo(_selectedRecord.ValidateNbrPpl10, SpinEditPp10);
            SetErrorInfo(_selectedRecord.ValidateGrossPpl1, SpinEditGpp1);
            SetErrorInfo(_selectedRecord.ValidateGrossPpl2, SpinEditGpp2);
            SetErrorInfo(_selectedRecord.ValidateGrossPpl3, SpinEditGpp3);
            SetErrorInfo(_selectedRecord.ValidateGrossPpl4, SpinEditGpp4);
            SetErrorInfo(_selectedRecord.ValidateGrossPpl5, SpinEditGpp5);
            SetErrorInfo(_selectedRecord.ValidateGrossPpl6, SpinEditGpp6);
            SetErrorInfo(_selectedRecord.ValidateGrossPpl7, SpinEditGpp7);
            SetErrorInfo(_selectedRecord.ValidateGrossPpl8, SpinEditGpp8);
            SetErrorInfo(_selectedRecord.ValidateGrossPpl9, SpinEditGpp9);
            SetErrorInfo(_selectedRecord.ValidateGrossPpl10, SpinEditGpp10);
            SetErrorInfo(_selectedRecord.ValidateNetPpl1, SpinEditNpp1);
            SetErrorInfo(_selectedRecord.ValidateNetPpl2, SpinEditNpp2);
            SetErrorInfo(_selectedRecord.ValidateNetPpl3, SpinEditNpp3);
            SetErrorInfo(_selectedRecord.ValidateNetPpl4, SpinEditNpp4);
            SetErrorInfo(_selectedRecord.ValidateNetPpl5, SpinEditNpp5);
            SetErrorInfo(_selectedRecord.ValidateNetPpl6, SpinEditNpp6);
            SetErrorInfo(_selectedRecord.ValidateNetPpl7, SpinEditNpp7);
            SetErrorInfo(_selectedRecord.ValidateNetPpl8, SpinEditNpp8);
            SetErrorInfo(_selectedRecord.ValidateNetPpl9, SpinEditNpp9);
            SetErrorInfo(_selectedRecord.ValidateNetPpl10, SpinEditNpp10);
            SetErrorInfo(_selectedRecord.ValidateRetail1, SpinEditRetail1);
            SetErrorInfo(_selectedRecord.ValidateRetail2, SpinEditRetail2);
            SetErrorInfo(_selectedRecord.ValidateRetail3, SpinEditRetail3);
            SetErrorInfo(_selectedRecord.ValidateRetail4, SpinEditRetail4);
            SetErrorInfo(_selectedRecord.ValidateRetail5, SpinEditRetail5);
            SetErrorInfo(_selectedRecord.ValidateRetail6, SpinEditRetail6);
            SetErrorInfo(_selectedRecord.ValidateRetail7, SpinEditRetail7);
            SetErrorInfo(_selectedRecord.ValidateRetail8, SpinEditRetail8);
            SetErrorInfo(_selectedRecord.ValidateRetail9, SpinEditRetail9);
            SetErrorInfo(_selectedRecord.ValidateRetail10, SpinEditRetail10);
            SetErrorInfo(_selectedRecord.ValidateChildAgeLimit, TextEditChildLimit);
            SetErrorInfo(_selectedRecord.ValidateJrAgeLimit, TextEditJrLimit);
            SetErrorInfo(_selectedRecord.ValidateSeniorAgeLimit, SpinEditSrLimit);
            SetErrorInfo(_selectedRecord.ValidateChildVendor, TextEditChildVendorCode);
            SetErrorInfo(_selectedRecord.ValidateJrVendor, TextEditJrVendorCode);
            SetErrorInfo(_selectedRecord.ValidateSeniorVendor, TextEditSrVendorCode);
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
        }

        private void SetFieldAndButtonStates(bool isExistingRecord)
        {
            _selectedRecord = ((CPRATES)BindingSource.Current);
            SetReadOnly(false);
            SetReadOnlyKeyFields(isExistingRecord);
            BarButtonItemDelete.Enabled = true;
            BarButtonItemSave.Enabled = true;
            BarButtonItemOverlapping.Enabled = true;
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
                            _context.CPRATES.DeleteObject(_selectedRecord);
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
            BarButtonItemOverlapping.Enabled = false;
            BindingSource.DataSource = typeof(CPRATES);
            _ignoreLeaveRow = false;
            _ignorePositionChange = false;
        }

        private void CpRatesForm_FormClosing(object sender, FormClosingEventArgs e)
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
     
        private void DateEditStart_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateStart, sender);
        }

        private void TimeEditTime_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateTime, sender);
        }

        private void DateEditResStart_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateResStart, sender);
        }

        private void DateEditEnd_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateEnd, sender);
        }

        private void DateEditResEnd_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateResEnd, sender);
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

        private void ComboBoxEditTransportType_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateTransfer, sender);
        }

        private void TextEditVendor_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateVendor, sender);
        }

        private void TextEditPp1_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateNbrPpl1, sender);
        }

        private void TextEditPp2_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateNbrPpl2, sender);
        }

        private void TextEditPp3_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateNbrPpl3, sender);
        }

        private void TextEditPp4_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateNbrPpl4, sender);
        }

        private void TextEditPp5_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateNbrPpl5, sender);
        }

        private void TextEditPp6_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateNbrPpl6, sender);
        }

        private void TextEditPp7_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateNbrPpl7, sender);
        }

        private void TextEditPp8_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateNbrPpl8, sender);
        }

        private void TextEditPp9_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateNbrPpl9, sender);
        }

        private void TextEditPp10_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateNbrPpl10, sender);
        }

        private void TextEditGpp1_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateGrossPpl1, sender);

            if (SpinEditGpp1.Value < SpinEditNpp1.Value)
            {
                DialogResult select = XtraMessageBox.Show("The gross is less than the cost. Is this correct?", "Gross", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered to be higher than the cost.");
                    SpinEditGpp1.Focus();
                    return;
                }
            }
        }

        private void TextEditGpp2_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateGrossPpl2, sender);

            if (SpinEditGpp2.Value < SpinEditNpp2.Value)
            {
                DialogResult select = XtraMessageBox.Show("The gross is less than the cost. Is this correct?", "Gross", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered to be higher than the cost.");
                    SpinEditGpp2.Focus();
                    return;
                }
            }
        }

        private void TextEditGpp3_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateGrossPpl3, sender);

            if (SpinEditGpp3.Value < SpinEditNpp3.Value)
            {
                DialogResult select = XtraMessageBox.Show("The gross is less than the cost. Is this correct?", "Gross", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered to be higher than the cost.");
                    SpinEditGpp3.Focus();
                    return;
                }
            }
        }

        private void TextEditGpp4_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateGrossPpl4, sender);

            if (SpinEditGpp4.Value < SpinEditNpp4.Value)
            {
                DialogResult select = XtraMessageBox.Show("The gross is less than the cost. Is this correct?", "Gross", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered to be higher than the cost.");
                    SpinEditGpp4.Focus();
                    return;
                }
            }
        }

        private void TextEditGpp5_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateGrossPpl5, sender);

            if (SpinEditGpp5.Value < SpinEditNpp5.Value)
            {
                DialogResult select = XtraMessageBox.Show("The gross is less than the cost. Is this correct?", "Gross", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered to be higher than the cost.");
                    SpinEditGpp5.Focus();
                    return;
                }
            }
        }

        private void TextEditGpp6_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateGrossPpl6, sender);

            if (SpinEditGpp6.Value < SpinEditNpp6.Value)
            {
                DialogResult select = XtraMessageBox.Show("The gross is less than the cost. Is this correct?", "Gross", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered to be higher than the cost.");
                    SpinEditGpp6.Focus();
                    return;
                }
            }
        }

        private void TextEditGpp7_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateGrossPpl7, sender);

            if (SpinEditGpp7.Value < SpinEditNpp7.Value)
            {
                DialogResult select = XtraMessageBox.Show("The gross is less than the cost. Is this correct?", "Gross", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered to be higher than the cost.");
                    SpinEditGpp7.Focus();
                    return;
                }
            }
        }

        private void TextEditGpp8_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateGrossPpl8, sender);

            if (SpinEditGpp8.Value < SpinEditNpp8.Value)
            {
                DialogResult select = XtraMessageBox.Show("The gross is less than the cost. Is this correct?", "Gross", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered to be higher than the cost.");
                    SpinEditGpp8.Focus();
                    return;
                }
            }
        }

        private void TextEditGpp9_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateGrossPpl9, sender);

            if (SpinEditGpp9.Value < SpinEditNpp9.Value)
            {
                DialogResult select = XtraMessageBox.Show("The gross is less than the cost. Is this correct?", "Gross", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered to be higher than the cost.");
                    SpinEditGpp9.Focus();
                    return;
                }
            }
        }

        private void TextEditGpp10_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateGrossPpl10, sender);

            if (SpinEditGpp10.Value < SpinEditNpp10.Value)
            {
                DialogResult select = XtraMessageBox.Show("The gross is less than the cost. Is this correct?", "Gross", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered to be higher than the cost.");
                    SpinEditGpp10.Focus();
                    return;
                }
            }
        }

        private void TextEditNpp1_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateNetPpl1, sender);
        }

        private void TextEditNpp2_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateNetPpl2, sender);
        }       

        private void TextEditNpp3_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateNetPpl3, sender);
        }

        private void TextEditNpp4_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateNetPpl4, sender);
        }

        private void TextEditNpp5_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateNetPpl5, sender);
        }

        private void TextEditNpp6_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateNetPpl6, sender);
        }

        private void TextEditNpp7_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateNetPpl7, sender);
        }

        private void TextEditNpp8_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateNetPpl8, sender);
        }

        private void TextEditNpp9_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateNetPpl9, sender);
        }

        private void TextEditNpp10_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateNetPpl10, sender);
        }

        private void TextEditChdGRate_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateChildGross, sender);

            if (SpinEditGrossChild.Value < SpinEditCostChild.Value)
            {
                DialogResult select = XtraMessageBox.Show("The gross is less than the cost. Is this correct?", "Child Junior Rate", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered to be higher than the cost.");
                    SpinEditCostChild.Focus();
                    return;
                }
            }
        }

        /*
        *   //supposed to be a message box
                if ((JR_GRATE == 0 || JR_GRATE == null))
                    throw new ValidationException("JR_LIMIT" + ":" + "You have entered a junior age limit with no corresponding rate.");

               //supposed to be a message box
               if((CHD_GRATE == 0 || CHD_GRATE == null))
                   throw new ValidationException("CHD_LIMIT" + ":" + "You have entered a child age limit with no corresponding rate."); */

        private void TextEditChdNRate_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateChildNet, sender);
        }

        private void TextEditChdLimit_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateChildAgeLimit, sender);

            if ((SpinEditGrossChild.Value == 0 && SpinEditCostChild.Value == 0) || (string.IsNullOrWhiteSpace(SpinEditGrossChild.Text) && string.IsNullOrWhiteSpace(SpinEditCostChild.Text)))
            {
                bool isNumericAge = int.TryParse(TextEditChildLimit.Text, out int age);
                //2 is a typical age for the upper limit of free children, so allow up to that age without warning
                if (isNumericAge && age > 2) {
                    DialogResult select = XtraMessageBox.Show("You have entered a child age limit with no corresponding rate. Is this correct?", "Child Limit", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No) {
                        XtraMessageBox.Show("Please correct the values entered.");
                        SpinEditGrossChild.Focus();
                        return;
                    }
                }

            }
        }

        private void TextEditJrGRate_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateJrGross, sender);

            if (SpinEditGrossJr.Value < SpinEditCostJr.Value)
            {
                DialogResult select = XtraMessageBox.Show("The gross is less than the cost. Is this correct?", "Junior Gross Rate", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                    SpinEditGrossJr.Focus();
                    return;
                }
            }
        }

        private void TextEditJrNRate_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateJrNet, sender);
        }

        private void TextEditJrLimit_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateJrAgeLimit, sender);

            if ((SpinEditGrossJr.Value == 0 && SpinEditCostJr.Value == 0) || (string.IsNullOrWhiteSpace(SpinEditGrossJr.Text) && string.IsNullOrWhiteSpace(SpinEditCostJr.Text)))
            {
                if (!string.IsNullOrWhiteSpace(TextEditJrLimit.Text) && validCheck.IsNumeric(TextEditJrLimit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("You have entered a junior age limit with no corresponding rate. Is this correct?", "Junior Limit", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the values entered.");
                        SpinEditGrossJr.Focus();
                        return;
                    }
                }
            }
        }

        private void TextEditVendorCodeJr_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateJrVendor, sender);
        }

        private void TextEditCommPct_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateComm, sender);
        }

        private void TextEditVendorCodeChd_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateChildVendor, sender);
        }

        private void EntityInstantFeedbackSource_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            FlextourEntities context = new FlextourEntities(Connection.EFConnectionString);
            e.QueryableSource = context.CPRATES;
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
                    CPRATES record = (CPRATES)proxy.OriginalRow;
                    BindingSource.DataSource = _context.CPRATES.Where(c => c.ID == record.ID);
                }
                else {
                    ClearBindings();
                }
            }
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

        private void SearchLookupEditCategory_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCategory, sender);
        }

        private void SearchLookupEditSpecialValue_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateSpecialValue, sender);
        }

        private void CpRateBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            //If the current record is changing as a result of removing a record to delete it, and it is the last
            //record in the table, then SetBindings will clear the bindings, which will cause the delete
            //to fail because the associated entities will become detached when their BindingSources are cleared.
            //Thus we have a flag which is set in that case to ignore this event.
            if (!_ignorePositionChange)
                SetBindings();
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
            if (e.KeyData == Keys.Enter && popupForm != null) {
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

        private void SpinEditRouteDays_Leave(object sender, EventArgs e)
		{
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateDays, sender);
        }

        private void SimpleButtonClosePopup_Click(object sender, EventArgs e)
		{
			popupContainerControl1.Hide();
		}

        private void SpinEditRetailChild_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateChildRetail, sender);

            if (SpinEditRetailChild.Value < SpinEditCostChild.Value)
            {
                DialogResult select = XtraMessageBox.Show("The retail rate is less than the cost. Is this correct?", "Child Retail Rate", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                    SpinEditRetailChild.Focus();
                    return;
                }
            }
        }

        private void SpinEditRetailJunior_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateJuniorRetail, sender);

            if (SpinEditRetailJunior.Value < SpinEditCostJr.Value)
            {
                DialogResult select = XtraMessageBox.Show("The retail rate is less than the cost. Is this correct?", "Junior Retail Rate", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                    SpinEditRetailJunior.Focus();
                    return;
                }
            }            
        }

        private void SpinEditRetailSenior_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateSeniorRetail, sender);

            if (SpinEditRetailSenior.Value < SpinEditCostSenior.Value)
            {
                DialogResult select = XtraMessageBox.Show("The retail rate is less than the cost. Is this correct?", "Senior Retail Rate", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                    SpinEditRetailSenior.Focus();
                    return;
                }
            }           
        }

        private void SpinEditGrossSenior_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateSeniorGross, sender);

            if (SpinEditGrossSenior.Value < SpinEditCostSenior.Value)
            {
                DialogResult select = XtraMessageBox.Show("The gross is less than the cost. Is this correct?", "Senior Gross Rate", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                    SpinEditGrossSenior.Focus();
                    return;
                }
            }           
        }

        private void SpinEditCostSenior_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateSeniorCost, sender);
        }

        private void SpinEditSeniorAge_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateSeniorAgeLimit, sender);

            if (SpinEditSrLimit.Value > 0 && SpinEditCostSenior.Value == 0 && SpinEditGrossSenior.Value == 0)
            {
                DialogResult select = XtraMessageBox.Show("You have entered a senior age limit with no corresponding rate. Is this correct?", "Senior Limit", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the values entered.");
                    SpinEditSrLimit.Focus();
                    return;
                }
            }
        }

        private void SpinEditRetail1_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateRetail1, sender);

            if (SpinEditRetail1.Value < SpinEditNpp1.Value)
            {
                DialogResult select = XtraMessageBox.Show("The retail rate is less than the cost. Is this correct?", "Retail Rate", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                    SpinEditRetail1.Focus();
                    return;
                }
            }
        }

        private void SpinEditRetail2_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateRetail2, sender);
            if (SpinEditRetail2.Value < SpinEditNpp2.Value)
            {
                DialogResult select = XtraMessageBox.Show("The retail rate is less than the cost. Is this correct?", "Retail Rate", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                    SpinEditRetail2.Focus();
                    return;
                }
            }
        }

        private void SpinEditRetail3_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateRetail3, sender);

            if (SpinEditRetail3.Value < SpinEditNpp3.Value)
            {
                DialogResult select = XtraMessageBox.Show("The retail rate is less than the cost. Is this correct?", "Retail Rate", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                    SpinEditRetail3.Focus();
                    return;
                }
            }
        }

        private void SpinEditRetail4_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateRetail4, sender);

            if (SpinEditRetail4.Value < SpinEditNpp4.Value)
            {
                DialogResult select = XtraMessageBox.Show("The retail rate is less than the cost. Is this correct?", "Retail Rate", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                    SpinEditRetail4.Focus();
                    return;
                }
            }
        }

        private void SpinEditRetail5_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateRetail5, sender);

            if (SpinEditRetail5.Value < SpinEditNpp5.Value)
            {
                DialogResult select = XtraMessageBox.Show("The retail rate is less than the cost. Is this correct?", "Retail Rate", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                    SpinEditRetail5.Focus();
                    return;
                }
            }
        }

        private void SpinEditRetail6_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateRetail6, sender);

            if (SpinEditRetail6.Value < SpinEditNpp6.Value)
            {
                DialogResult select = XtraMessageBox.Show("The retail rate is less than the cost. Is this correct?", "Retail Rate", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                    SpinEditRetail6.Focus();
                    return;
                }
            }
        }

        private void SpinEditRetail7_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateRetail7, sender);

            if (SpinEditRetail7.Value < SpinEditNpp7.Value)
            {
                DialogResult select = XtraMessageBox.Show("The retail rate is less than the cost. Is this correct?", "Retail Rate", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                    SpinEditRetail7.Focus();
                    return;
                }
            }
        }

        private void SpinEditRetail8_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateRetail8, sender);

            if (SpinEditRetail8.Value < SpinEditNpp8.Value)
            {
                DialogResult select = XtraMessageBox.Show("The retail rate is less than the cost. Is this correct?", "Retail Rate", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                    SpinEditRetail8.Focus();
                    return;
                }
            }
        }

        private void SpinEditRetail9_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateRetail9, sender);

            if (SpinEditRetail9.Value < SpinEditNpp9.Value)
            {
                DialogResult select = XtraMessageBox.Show("The retail rate is less than the cost. Is this correct?", "Retail Rate", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                    SpinEditRetail9.Focus();
                    return;
                }
            }
        }

        private void SpinEditRetail10_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateRetail10, sender);

            if (SpinEditRetail10.Value < SpinEditNpp10.Value)
            {
                DialogResult select = XtraMessageBox.Show("The retail rate is less than the cost. Is this correct?", "Retail Rate", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                    SpinEditRetail10.Focus();
                    return;
                }
            }
        }

        private void CheckEditCommFlg_EditValueChanged(object sender, EventArgs e)
        {
            if (CheckEditCommFlg.Checked)
                SpinEditCommPct.Enabled = true;
            else
                SpinEditCommPct.Enabled = false;
        }

        private void BarButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _ignoreLeaveRow = true;       //so that when the grid row changes it doesn't try to save again
            if (SaveRecord(true)) {
                //For some reason when there is no existing record in the binding source the Add method does not
                //trigger the CurrentChanged event, but AddNew does so use that instead
                BindingSource.AddNew();
                //With the instant feedback data source, the new row is not immediately added to the grid, so move
                //the focused row to the filter row just so that no other existing row is visually highlighted
                GridViewLookup.FocusedRowHandle = DevExpress.Data.BaseListSourceDataController.FilterRow;
                SetFieldAndButtonStates(isExistingRecord: false);
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

        private void BarStaticItemExpandGrid_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void BarButtonItemOverlapping_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime? svcStart = DateEditStart.DateTime;
            DateTime? svcEnd = (DateEditEnd.DateTime == DateTime.MinValue ? DateTime.MaxValue : (DateTime?)DateEditEnd.DateTime);
            DateTime resStart = DateEditResStart.DateTime;
            DateTime resEnd = (DateEditResEnd.DateTime == DateTime.MinValue ? DateTime.MaxValue : DateEditResEnd.DateTime);
            string code = SearchLookupEditCode.EditValue.ToString();
            string agency = SearchLookupEditAgency.EditValue.ToString();
            string cat = SearchLookupEditCategory.EditValue.ToString();
            string time = TimeEditTime.Text;
            decimal busTourStops = SpinEditRouteStops.Value;
            decimal busTourDays = SpinEditRouteDays.Value;
            bool inactive = (bool)CheckEditInactive.EditValue;
            if (!inactive) {
                //The sql I want to determine date overlaps:
                //start between c.START_DATE and c.END_DATE OR end between c.START_DATE and c.END_DATE OR
                //c.START_DATE between start and end OR c.END_DATE between start and end
                var overlaps = from c in _context.CPRATES
                           where c.CODE == code && c.ID != _selectedRecord.ID && c.AGENCY == agency && c.CAT == cat && c.Inactive == false
                            && c.Time == time && ((svcStart >= c.START_DATE && svcStart <= c.END_DATE) || (svcEnd >= c.START_DATE && svcEnd <= c.END_DATE)
                               || (c.START_DATE >= svcStart && c.START_DATE <= svcEnd) || (c.END_DATE >= svcStart && c.END_DATE <= svcEnd))
                               && ((resStart >= (c.ResDate_Start ?? DateTime.MinValue) && resStart <= (c.ResDate_End ?? DateTime.MaxValue)
                               || (resEnd >= (c.ResDate_Start ?? DateTime.MinValue) && resEnd <= (c.ResDate_End ?? DateTime.MaxValue))
                               || ((c.ResDate_Start ?? DateTime.MinValue) >= resStart && (c.ResDate_Start ?? DateTime.MinValue) <= resEnd)
                               || ((c.ResDate_End ?? DateTime.MaxValue) >= resStart && (c.ResDate_End ?? DateTime.MaxValue) <= resEnd)))
                           select c;
                if (overlaps.Count() > 0) { 
                    gridControl2.DataSource = overlaps;
                    popupContainerControl1.Top = LabelCode.Top;
                    popupContainerControl1.Left = LabelCode.Left;
                    popupContainerControl1.BringToFront();
                    popupContainerControl1.Show();
                    return;
                }
            }

            MessageBox.Show("No other rate sheets overlap the current rate sheet.");
        }

        private void DateEditStart_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            if (e.Value as DateTime? == DateTime.MinValue) {
                e.DisplayText = string.Empty;
            }
        }

        private void ImageComboBoxEditAgency_EditValueChanged(object sender, EventArgs e)
        {
            string agency = SearchLookupEditAgency.EditValue.ToString();
            if (agency == _sys.Settings.DefaultAgency)
            {
                CheckEditCommFlg.Enabled = true;
            }
            else
            {
                SpinEditCommPct.Enabled = false;
                SpinEditCommPct.Value = 0;
                CheckEditCommFlg.Enabled = false;
                CheckEditCommFlg.EditValue = "N";      //the db field is char(1) Y/N
            }
        }
    }
}