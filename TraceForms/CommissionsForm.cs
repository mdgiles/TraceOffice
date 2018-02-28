using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FlexModel;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq.Dynamic;
using DevExpress.XtraEditors.Repository;
using System.Reflection;

namespace TraceForms
{
    
    public partial class CommissionsForm : DevExpress.XtraEditors.XtraForm
    {
        public string _currentVal;
        public bool _modified = false;
        public bool _newRec = false;
        public  FlextourEntities _context;
        public COMPROD2 _selectedRecord;
        public Timer _actionConfirmation;
        public bool _ignoreLeaveRow = false, _ignorePositionChange = false;
        string _username;
        List<CommLevel> _rules;
        List<ImageComboBoxItem> _agencyMarkupRules;
        List<ImageComboBoxItem> _agencyCommRules;
        List<ImageComboBoxItem> _hotelMarkupRules;
        List<ImageComboBoxItem> _hotelCommRules;
        List<ImageComboBoxItem> _packMarkupRules;
        List<ImageComboBoxItem> _packCommRules;
        List<ImageComboBoxItem> _compMarkupRules;
        List<ImageComboBoxItem> _compCommRules;
        List<CodeName> _operatorLookup;
        List<CodeName> _packtypeLookup;
        List<CodeName> _servtypeLookup;
        List<CodeName> _regionLookup;
        List<CodeName> _countryLookup;
        List<CodeName> _languageLookup;
        List<CodeName> _citycodLookup;
        List<CodeName> _hotelLookup;
        List<CodeName> _packLookup;
        List<CodeName> _compLookup;
        List<CodeName> _agencyLookup;

        public CommissionsForm(FlexInterfaces.Core.ICoreSys sys)
        {
            try {
                InitializeComponent();
                Connect(sys);
                LoadLookups();
                SetReadOnly(true);
                EnableNavigator(false);
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
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = null };

            _rules = _context.CommLevel.OrderBy(cl => cl.RecType).ThenBy(cl => cl.Type).ThenBy(cl => cl.Description).ToList();

            _agencyMarkupRules = new List<ImageComboBoxItem>();
            _agencyMarkupRules.Add(loadBlank);
            _agencyMarkupRules.AddRange(_rules.Where(cl => cl.RecType == "M" && cl.Type == "AGY")
                .OrderBy(cl => cl.Description)
                .Select(cl => new ImageComboBoxItem() { Description = cl.Description, Value = cl.ID }));

            _agencyCommRules = new List<ImageComboBoxItem>();
            _agencyCommRules.Add(loadBlank);
            _agencyCommRules.AddRange(_rules.Where(cl => cl.RecType == "C" && cl.Type == "AGY")
                .OrderBy(cl => cl.Description)
                .Select(cl => new ImageComboBoxItem() { Description = cl.Description, Value = cl.ID }));

            _hotelMarkupRules = new List<ImageComboBoxItem>();
            _hotelMarkupRules.Add(loadBlank);
            _hotelMarkupRules.AddRange(_rules.Where(cl => cl.RecType == "M" && cl.Type == "HTL")
                .OrderBy(cl => cl.Description)
                .Select(cl => new ImageComboBoxItem() { Description = cl.Description, Value = cl.ID }));

            _hotelCommRules = new List<ImageComboBoxItem>();
            _hotelCommRules.Add(loadBlank);
            _hotelCommRules.AddRange(_rules.Where(cl => cl.RecType == "C" && cl.Type == "HTL")
                .OrderBy(cl => cl.Description)
                .Select(cl => new ImageComboBoxItem() { Description = cl.Description, Value = cl.ID }));

            _packMarkupRules = new List<ImageComboBoxItem>();
            _packMarkupRules.Add(loadBlank);
            _packMarkupRules.AddRange(_rules.Where(cl => cl.RecType == "M" && cl.Type == "PKG")
                .OrderBy(cl => cl.Description)
                .Select(cl => new ImageComboBoxItem() { Description = cl.Description, Value = cl.ID }));

            _packCommRules = new List<ImageComboBoxItem>();
            _packCommRules.Add(loadBlank);
            _packCommRules.AddRange(_rules.Where(cl => cl.RecType == "C" && cl.Type == "PKG")
                .OrderBy(cl => cl.Description)
                .Select(cl => new ImageComboBoxItem() { Description = cl.Description, Value = cl.ID }));

            _compMarkupRules = new List<ImageComboBoxItem>();
            _compMarkupRules.Add(loadBlank);
            _compMarkupRules.AddRange(_rules.Where(cl => cl.RecType == "M" && cl.Type == "PKG")
                .OrderBy(cl => cl.Description)
                .Select(cl => new ImageComboBoxItem() { Description = cl.Description, Value = cl.ID }));

            _compCommRules = new List<ImageComboBoxItem>();
            _compCommRules.Add(loadBlank);
            _compCommRules.AddRange(_rules.Where(cl => cl.RecType == "C" && cl.Type == "PKG")
                .OrderBy(cl => cl.Description)
                .Select(cl => new ImageComboBoxItem() { Description = cl.Description, Value = cl.ID }));

            //EF will try to execute the entire projection on the sql side, which knows nothing about ImageComboBoxItem so it will
            //error. Putting AsEnumerable beforehand will tell EF to execute sql side up to there and return results, then the
            //rest will be EF client side
            var cats = _context.ROOMCOD
                .OrderBy(r => r.CODE)
                .Select(r => new CodeName() { Code = r.CODE, Name = r.DESC }).ToList();
            cats.Add(new CodeName("", ""));
            gridLookupEditCategory.Properties.DisplayMember = "DisplayName";
            gridLookupEditCategory.Properties.ValueMember = "Code";
            gridLookupEditCategory.Properties.DataSource = cats;

            _hotelLookup = new List<CodeName>();
            //_hotelLookup.Add(loadBlank);
            _hotelLookup.AddRange(_context.HOTEL
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.NAME }));

            _packLookup = new List<CodeName>();
            _packLookup.AddRange(_context.PACK
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.NAME }));

            _compLookup = new List<CodeName>();
            _compLookup.AddRange(_context.COMP
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.NAME }));

            _servtypeLookup = new List<CodeName>();
            _servtypeLookup.AddRange(_context.SERVTYPE
                .OrderBy(t => t.TYPE)
                .Select(t => new CodeName() { Code = t.TYPE, Name = t.DESCRIP }));

            _packtypeLookup = new List<CodeName>();
            _packtypeLookup.AddRange(_context.PACKTYPE
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.DESC }));

            _regionLookup = new List<CodeName>();
            _regionLookup.AddRange(_context.REGION
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.DESC }));

            _operatorLookup = new List<CodeName>();
            _operatorLookup.AddRange(_context.OPERATOR
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.NAME }));

            _citycodLookup = new List<CodeName>();
            _citycodLookup.AddRange(_context.CITYCOD
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.NAME }));

            _countryLookup = new List<CodeName>();
            _countryLookup.AddRange(_context.COUNTRY
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.NAME }));

            _languageLookup = new List<CodeName>();
            _languageLookup.AddRange(_context.LANGUAGE
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.NAME }));

            _agencyLookup = new List<CodeName>();
            _agencyLookup.AddRange(_context.AGY
                .OrderBy(t => t.NO)
                .Select(t => new CodeName() { Code = t.NO, Name = t.NAME }));

            lookupEditExclusionProduct.Properties.DataSource = _hotelLookup;
            lookupEditExclusionProduct.Properties.DisplayMember = "DisplayName";
            lookupEditExclusionProduct.Properties.ValueMember = "Code";

            lookupEditExclusionAgency.Properties.DataSource = _agencyLookup;
            lookupEditExclusionAgency.Properties.DisplayMember = "DisplayName";
            lookupEditExclusionAgency.Properties.ValueMember = "Code";
        }

        private bool Modified
        {
            get {
                return _modified;
            }
            set {
                _modified = value;
                if (value && bindingSource.Current != null)
                {
                    //NB: Before updating any property on the entity, any pending edits must be committed 
                    //with bindingSource.EndEdit, other when the properties are set the form bindings are
                    //automatically refreshed, which causes any pending edits to be lost.  In this form,
                    //SetErrorInfo takes care of it.
                    COMPROD2 comprod = (COMPROD2)bindingSource.Current;
                    comprod.LAST_UPD = DateTime.Now;
                    comprod.UPD_INIT = _username;
                }
            }
        }

        private void enterControl(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(CheckEdit)) {
                _currentVal = ((CheckEdit)sender).Checked.ToString();
            }
            else {
                _currentVal = ((Control)sender).Text;
            }
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_modified || _newRec) {
                DialogResult select = XtraMessageBox.Show("There are unsaved changes. Are you sure want to exit?", 
                    Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (select == DialogResult.Yes) {
                    e.Cancel = false;
                    Dispose();
                }
                else 
                    e.Cancel = true;
            }
            else {
                e.Cancel = false;
                Dispose();
            }
        }

        void EnableNavigator(bool value)
        {
            bindingNavigatorMoveNextItem.Enabled = value;
            bindingNavigatorMoveLastItem.Enabled = value;
            bindingNavigatorMoveFirstItem.Enabled = value;
            bindingNavigatorMovePreviousItem.Enabled = value;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _ignoreLeaveRow = true;       //so that when the grid row changes it doesn't try to save again
            if (SaveRecord(true)) {
                gridViewLookup.ClearColumnsFilter();
                _newRec = true;
                bindingSource.AddNew();
                gridViewLookup.FocusedRowHandle = gridViewLookup.RowCount - 1;
                imageComboBoxEditRecType.Focus();
                SetReadOnly(false);
            }
            errorProvider.Clear();
            _ignoreLeaveRow = false;
        }

        private void DeleteRecord()
        {
            if (_selectedRecord == null) return;

            try {
                if (XtraMessageBox.Show("Are you sure you want to delete this record?", 
                    Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    _ignoreLeaveRow = true;
                    _ignorePositionChange = true;
                    RemoveRecord();
                    if (!_newRec) {
                        //Apparently a record which has just been added is not flagged for deletion by BindingSource.RemoveCurrent,
                        //(the EntityState remains unchanged).  It seems like it is not tracked by the context even though it is, because
                        //the EntityState changes for modification. So if this is a deletion and the entity is not flagged for deletion, 
                        //delete it manually.
                        if (_selectedRecord != null && (_selectedRecord.EntityState & EntityState.Deleted) != EntityState.Deleted)
                            _context.COMPROD2.DeleteObject(_selectedRecord);
                        _context.SaveChanges();
                    }
                    Modified = false;
                    _newRec = false;
                    if (gridViewLookup.RowCount == 0) {
                        ClearBindings();
                    }
                    _ignoreLeaveRow = false;
                    _ignorePositionChange = false;
                    SetBindings();
                    ShowActionConfirmation("Record Deleted");
                }
                _currentVal = imageComboBoxEditRecType.Text;
            }
            catch (Exception ex) {
                this.DisplayError(ex);
                RefreshRecord();        //pull it back from db because that is it's current state
                //We must also Load and rebind the related entities from the db because context.Refresh doesn't do that
                SetBindings();
            }
        }

        void ClearBindings()
        {
            bindingSource.DataSource = typeof(COMPROD2);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DeleteRecord();
        }

        private bool SaveRecord(bool prompt)
        {
            try {
                if (_selectedRecord == null) return true;

                //Call to make sure the modified flag is set, because the Save button doesn't take focus so the Leave event
                //won't fire on the active control
                SetErrorInfo(null, ActiveControl, true);

                if (_modified || _newRec) {
                    if (prompt) {
                        DialogResult result = XtraMessageBox.Show("Do you want to confirm these changes?", Text, 
                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.No) {
                            if (_newRec) {
                                RemoveRecord();
                            }
                            else {
                                RefreshRecord();
                            }
                            Modified = false;
                            _newRec = false;
                            return true;
                        }
                        if (result == DialogResult.Cancel) {
                            return false;
                        }
                    }
                    if (!ValidateAll())
                        return false;

                    if (_selectedRecord.EntityState == EntityState.Detached) {
                        _context.COMPROD2.AddObject(_selectedRecord);
                    }
                    _context.SaveChanges();
                    ShowActionConfirmation("Record Saved");
                    _newRec = false;
                    Modified = false;
                }
                return true;
            }
            catch (Exception ex) {
                if (ex.InnerException != null && ex.InnerException.Message.StartsWith("Cannot insert duplicate key row"))
                {
                    this.DisplayError("This record is a duplicate of an existing record");
                }
                else
                {
                    this.DisplayError(ex);
                }
                RefreshRecord();        //pull it back from db because that is its current state
                                        //We must also Load and rebind the related entities from the db because context.Refresh doesn't do that
                SetBindings();
                return false;
            }
        }

        private bool ValidateAll()
        {
            if (!_selectedRecord.Validate()) {
                ShowMainControlErrors();
                this.DisplayWarning("Errors were found. Please resolve them and try again.");
                return false;
            }
            else {
                errorProvider.Clear();
               return true;
            }
        }

        private void ShowMainControlErrors()
        {
            //The error indicators inside the grids are handled by binding, but errors on the main form must
            //be set manually
            SetErrorInfo(_selectedRecord.ValidateRecType, imageComboBoxEditRecType, false);
            SetErrorInfo(_selectedRecord.ValidatePlatform, imageComboBoxEditPlatform, false);
            SetErrorInfo(_selectedRecord.ValidateFlags, checkEditAvailability, false);
            SetErrorInfo(_selectedRecord.ValidateFlags, checkEditImports, false);
            SetErrorInfo(_selectedRecord.ValidateType, comboBoxEditType, false);
            SetErrorInfo(_selectedRecord.ValidateProduct, gridLookUpEditProductValue, false);
            SetErrorInfo(_selectedRecord.ValidateCategory, gridLookupEditCategory, false);
            SetErrorInfo(_selectedRecord.ValidateAgency, gridLookUpEditAgencyValue, false);
            SetErrorInfo(_selectedRecord.ValidateServiceDates, dateEditStartDate, false);
            SetErrorInfo(_selectedRecord.ValidateServiceDates, dateEditEndDate, false);
            SetErrorInfo(_selectedRecord.ValidateBookingDates, dateEditResDateStart, false);
            SetErrorInfo(_selectedRecord.ValidateBookingDates, dateEditResDateEnd, false);
            SetErrorInfo(_selectedRecord.ValidateExclusion, checkEditExclusion, false);
            SetErrorInfo(_selectedRecord.ValidateExclusionProduct, lookupEditExclusionProduct, false);
            SetErrorInfo(_selectedRecord.ValidateExclusionAgency, lookupEditExclusionAgency, false);
            SetErrorInfo(_selectedRecord.ValidateCustomerPercentage, spinEditCommPct, false);
            SetErrorInfo(_selectedRecord.ValidateSupplierPercentage, spinEditSupplierPercentage, false);
        }

        private void SetErrorInfo(Func<String> validationMethod, object sender, bool fromControlLeave)
        {
            //force changes back into context for validation. 
            //NB: This must be done before setting Modified = true, because that sets other properties directly
            // on the entity, which in turn refreshes the form bindings, which cause any pending edits to be lost
            bindingSource.EndEdit();
            if (_selectedRecord != null && sender != null) {        //just in case focus somehow gets to a control even tho there is no active record
                //When validating all values prior to save, we don't want to check the prior value
                if (fromControlLeave) {
                    if (sender.GetType() == typeof(CheckEdit)) {
                        if (_currentVal != ((CheckEdit)sender).Checked.ToString()) {
                            Modified = true;
                        }
                    }
                    else {
                        if (_currentVal != ((Control)sender).Text) {
                            Modified = true;
                        }
                    }
                }
                //Put this here to save the current value of the control into currentVal in the cases
                //where this event was fired without a new control gaining focus, ie when the Save
                //button is clicked. 
                enterControl(sender, new EventArgs());
                if (validationMethod != null) {
                    string error = validationMethod.Invoke();
                    errorProvider.SetError((Control)sender, error);
                }
            }
        }

        void SetBindings()
        {
            if (bindingSource.Current == null) {
                _selectedRecord = null;
                EnableNavigator(false);
                SetReadOnly(true);
            }
            else {
                _selectedRecord = ((COMPROD2)bindingSource.Current);
                EnableNavigator(true);
                SetReadOnly(false);
            }
            errorProvider.Clear();
        }

        void SetReadOnly(bool value)
        {
            foreach (Control control in splitContainerControl.Panel2.Controls) {
                control.Enabled = !value;
            }
        }

        private void ShowActionConfirmation(string confirmation)
        {
            panelControlStatus.Visible = true;
            labelStatus.Text = confirmation;
            _actionConfirmation = new Timer();
            _actionConfirmation.Interval = 3000;
            _actionConfirmation.Start();
            _actionConfirmation.Tick += TimedEvent;
        }

        private void TimedEvent(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            _actionConfirmation.Stop();
        }

        private void RemoveRecord()
        {
            bindingSource.RemoveCurrent();
        }

        private void RefreshRecord()
        {
            //A Detached record has not yet been added to the context
            //An Added record has been added but not yet saved, most likely because there was
            //an error in SaveRecord, in which case we should not retrieve it from the db
            if (_selectedRecord != null && _selectedRecord.EntityState != EntityState.Detached
                && _selectedRecord.EntityState != EntityState.Added) {
                _context.Refresh(RefreshMode.StoreWins, _selectedRecord);
            }
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord(false))
                RefreshRecord();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord(true))
                bindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord(true))
                bindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord(true))
                bindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord(true))
                bindingSource.MoveLast();
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && gridViewLookup.IsFilterRow(gridViewLookup.FocusedRowHandle)) {
                ExecuteQuery();
                e.Handled = true;
            }
        }

        private void ExecuteQuery()
        {
            try {
                Cursor = Cursors.WaitCursor;
                string colName = gridViewLookup.FocusedColumn.FieldName;
                string value = String.Empty;
                value = gridViewLookup.GetFocusedDisplayText();
                IQueryable<COMPROD2> results = _context.COMPROD2;

                //We must use a different variable for each filter column value because the Where is lazily
                //executed, and using the same variable will result in the values of earlier variables
                //being replaced at the time of execution
                string val = gridViewLookup.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, colRecType);
                if (!string.IsNullOrEmpty(val)) {
                    results = results.Where(c => c.RecType == val);
                }

                string val1 = gridViewLookup.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, colTYPE);
                if (!string.IsNullOrEmpty(val1)) {
                    results = results.Where(c => c.TYPE.StartsWith(val1));
                }

                string val2 = gridViewLookup.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, colProductRule);
                if (!string.IsNullOrEmpty(val2)) {
                    results = results.Where(c => c.CommLevel1 != null && c.CommLevel1.Description.Contains(val2));
                }

                string val3 = gridViewLookup.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, colCODE);
                if (!string.IsNullOrEmpty(val3)) {
                    results = results.Where(c => c.CODE.StartsWith(val3));
                }

                string val4 = gridViewLookup.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, colAgencyRule);
                if (!string.IsNullOrEmpty(val4)) {
                    results = results.Where(c => c.CommLevel != null && c.CommLevel.Description.Contains(val4));
                }

                string val5 = gridViewLookup.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, colAGENCY);
                if (!string.IsNullOrEmpty(val5)) {
                    results = results.Where(c => c.AGENCY.StartsWith(val5));
                }

                results = results.OrderBy(c => c.RecType).ThenBy(c => c.TYPE);
                if (results.Count() > 0) {
                    bindingSource.DataSource = results;
                    gridViewLookup.ClearColumnsFilter();
                }
                else { 
                    ClearBindings();
                    this.DisplayInfo("No matching records found.");
                }
            }
            catch (Exception ex) {
                this.DisplayError(ex);
            }
            finally {
                Cursor = Cursors.Default;
            }
        }

        private void gridViewLookup_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            //If the user selects a row, edits, then selects the auto-filter row, then selects a different row,
            //this event will fire for the auto-filter row, so we cannot ignore it because there is still a record
            //that may need to be saved. 
            if (!_ignoreLeaveRow && _selectedRecord != null && (Modified || _newRec)) {
                e.Allow = SaveRecord(true);
            }
        }

        private void bindingSource_CurrentChanged(object sender, EventArgs e)
        {
            //If the current record is changing as a result of removing a record to delete it, and it is the last
            //record in the table, then SetBindings will clear the bindings, which will cause the delete
            //to fail because the associated entities will become detached when their BindingSources are cleared.
            //Thus we have a flag which is set in that case to ignore this event.
            if (!_ignorePositionChange) {
                SetBindings();
                //HACK: Devexpress GridLookupEdit doesn't materialize the view for the dropdown unless it is shown
                //which means the bound value doesn't match anything in the dropdown, so it doesn't show
                if (_selectedRecord != null && !string.IsNullOrEmpty(_selectedRecord.RecType) 
                    && !string.IsNullOrEmpty(_selectedRecord.TYPE)) {
                    //LoadRuleLists();
                    gridLookUpEditProductValue.ShowPopup();
                    gridLookUpEditProductValue.ClosePopup();
                    gridLookUpEditAgencyValue.ShowPopup();
                    gridLookUpEditAgencyValue.ClosePopup();
                    //gridLookUpEditAgencyValue grabs the focus after ClosePopup, so now we have to set the focus where we want it
                    //and make sure the current value has been saved to check for changes later
                    imageComboBoxEditRecType.Focus();
                    enterControl(imageComboBoxEditRecType, new EventArgs());
                }
                Modified = false;
            }
        }

        private void Form_Shown(object sender, EventArgs e)
        {
            gridViewLookup.FocusedRowHandle = DevExpress.Data.CurrencyDataController.FilterRow;
            gridControlLookup.Focus();
        }

        private void gridViewLookup_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void gridViewLookup_ColumnFilterChanged(object sender, EventArgs e)
        {
            if (gridViewLookup.DataRowCount == 0) {
                ClearBindings();
            }
        }

        private void comboBoxEditType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRuleLists();                   //no need to load agency if the type has changed
        }

        private void LoadRuleLists()
        {
            imageComboBoxEditAgencyRule.Properties.Items.Clear();
            if (imageComboBoxEditRecType.Text.StartsWith("C")) {
                imageComboBoxEditAgencyRule.Properties.Items.AddRange(_agencyCommRules);
            }
            else if (imageComboBoxEditRecType.Text.StartsWith("M")) {
                imageComboBoxEditAgencyRule.Properties.Items.AddRange(_agencyMarkupRules);
            }
            LoadAgencyValues();

            //Supplier values are only valid for hotels for markup rules
            bool supplierValid = (comboBoxEditType.Text == "HTL" && imageComboBoxEditRecType.Text.StartsWith("M"));
            SetSupplierFieldsState(supplierValid);

            imageComboBoxEditProductRule.Properties.Items.Clear();
            SetProductFieldsState(comboBoxEditType.Text != "AGY", true);

            if (comboBoxEditType.Text != "AGY") {
                switch (comboBoxEditType.Text) {
                    case "HTL":
                        if (imageComboBoxEditRecType.Text.StartsWith("C")) {
                            imageComboBoxEditProductRule.Properties.Items.AddRange(_hotelCommRules);
                        }
                        else if (imageComboBoxEditRecType.Text.StartsWith("M")) {
                            imageComboBoxEditProductRule.Properties.Items.AddRange(_hotelMarkupRules);
                        }
                        break;
                    case "PKG":
                        if (imageComboBoxEditRecType.Text.StartsWith("C")) {
                            imageComboBoxEditProductRule.Properties.Items.AddRange(_packCommRules);
                        }
                        else if (imageComboBoxEditRecType.Text.StartsWith("M")) {
                            imageComboBoxEditProductRule.Properties.Items.AddRange(_packMarkupRules);
                        }
                        break;
                    case "OPT":
                        if (imageComboBoxEditRecType.Text.StartsWith("C")) {
                            imageComboBoxEditProductRule.Properties.Items.AddRange(_compCommRules);
                        }
                        else if (imageComboBoxEditRecType.Text.StartsWith("M")) {
                            imageComboBoxEditProductRule.Properties.Items.AddRange(_compMarkupRules);
                        }
                        break;
                }
                LoadProductValues();
            }
        }

        private void SetProductFieldsState(bool enable, bool includeRuleLookup)
        {
            if (includeRuleLookup) {
                imageComboBoxEditProductRule.Enabled = enable;
                imageComboBoxEditProductRule.ReadOnly = !enable;
            }
            gridLookUpEditProductValue.Enabled = enable;
            gridLookUpEditProductValue.ReadOnly = !enable;
            gridLookupEditCategory.Enabled = enable;
            gridLookupEditCategory.ReadOnly = !enable;
            if (!enable) {
                if (includeRuleLookup) {
                    imageComboBoxEditProductRule.EditValue = null;
                }
                gridLookupEditCategory.EditValue = null;
                gridLookUpEditProductValue.EditValue = null;
            }
        }

        private void SetAgencyFieldsState(bool enable, bool includeRuleLookup)
        {
            if (includeRuleLookup) {
                imageComboBoxEditAgencyRule.Enabled = enable;
                imageComboBoxEditAgencyRule.ReadOnly = !enable;
            }
            gridLookUpEditAgencyValue.Enabled = enable;
            gridLookUpEditAgencyValue.ReadOnly = !enable;
            if (!enable) {
                gridLookUpEditAgencyValue.EditValue = null;
                if (includeRuleLookup) {
                    imageComboBoxEditAgencyRule.EditValue = null;
                }
            }
        }

        private void imageComboBoxEditRecType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRuleLists();
            groupControlCustomer.Text = "Customer " + imageComboBoxEditRecType.Text;
            groupControlSupplier.Text = "Supplier " + imageComboBoxEditRecType.Text;
        }

        private void gridLookUpEditProductValue_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {
            if (!string.IsNullOrEmpty(imageComboBoxEditProductRule.Text) 
                && e.DisplayValue != null && !string.IsNullOrEmpty(e.DisplayValue.ToString())) {
                CodeName codeName = new CodeName(e.DisplayValue.ToString());
                bindingSourceCodeNameProduct.Add(codeName);
                e.Handled = true;
            }
        }

        private void imageComboBoxEditRecType_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateRecType, sender, true);
        }

        private void comboBoxEditType_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateType, sender, true);
        }

        private void textEditSupplierPromo_Leave(object sender, EventArgs e)
        {
            SetErrorInfo(null, sender, true);
        }

        private void textEditCustomerPromo_Leave(object sender, EventArgs e)
        {
            SetErrorInfo(null, sender, true);
        }

        private void imageComboBoxEditProductRule_Leave(object sender, EventArgs e)
        {
            SetErrorInfo(null, sender, true);
        }

        private void gridLookUpEditProductValue_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateProduct, sender, true);
        }

        private void imageComboBoxEditCategory_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCategory, sender, true);
        }

        private void imageComboBoxEditAgencyRule_Leave(object sender, EventArgs e)
        {
            SetErrorInfo(null, sender, true);
        }

        private void gridLookUpEditAgencyValue_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateAgency, sender, true);
        }

        private void dateEditStartDate_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateServiceDates, sender, true);
        }

        private void dateEditEndDate_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateServiceDates, sender, true);
        }

        private void dateEditResDateStart_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateBookingDates, sender, true);
        }

        private void dateEditResDateEnd_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateBookingDates, sender, true);
        }

        private void lookupEditExclusionProduct_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateExclusionProduct, sender, true);
        }

        private void lookupEditExclusionAgency_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateExclusionAgency, sender, true);
        }

        private void textEditCommPct_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCustomerPercentage, sender, true);
        }

        private void textEditFlatAmount_Leave(object sender, EventArgs e)
        {
            SetErrorInfo(null, sender, true);
        }

        private void imageComboBoxEditProductRule_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProductValues();
        }

        private void LoadProductValues()
        {
            try {
                bindingSourceCodeNameProduct.DataSource = null;
                if (string.IsNullOrEmpty(imageComboBoxEditProductRule.Text)) {
                    //If no rule is specified, use specific products
                    switch (comboBoxEditType.Text) {
                        case "HTL":
                            bindingSourceCodeNameProduct.DataSource = _hotelLookup;
                            break;
                        case "PKG":
                            bindingSourceCodeNameProduct.DataSource = _packLookup;
                            break;
                        case "OPT":
                            bindingSourceCodeNameProduct.DataSource = _compLookup;
                            break;
                    }
                }
                else {
                    int id = (int)imageComboBoxEditProductRule.EditValue;
                    var rule = _rules.FirstOrDefault(r => r.ID == id);
                    if (rule != null) {
                        //The user cannot select a value if the rule is a query
                        SetProductFieldsState(string.IsNullOrEmpty(rule.Query), false);

                        //set the default value from the rule if specified
                        if (spinEditCommPct.Value == 0 && (rule.Comm_Pct ?? 0) > 0) {
                            spinEditCommPct.Value = (decimal)rule.Comm_Pct;
                        }

                        if (string.IsNullOrEmpty(rule.Query)) {
                            if (string.IsNullOrEmpty(rule.Lookup_Table)) {
                                //TODO: check the USERFIELDS table for the link to the LOOKUP table

                                //If no lookup table is provided, use distinct values from the link table and field
                                IQueryable table = (IQueryable)(_context.GetType()).GetProperty(rule.Link_Table).GetValue(_context, null);
                                //The "new" constructor is not invoking an overloaded constructor but is parsed by System.Linq.Dynamic
                                //to locate the correct type and populate the property/ies. Unless the names match, the property names must
                                //be aliased to match the destination class, since this is not invoking a parameterized constructor 
                                //even though it looks like that.
                                List<CodeName> values = table.Select<CodeName>("new CodeName(" + rule.Link_Column + " as Code)").Distinct().ToList();
                                //Add other values from COMPROD2 records that use this same rule
                                var otherVals = _context.COMPROD2.Where(c => c.CommLevel_ID_Product == rule.ID).DistinctBy(c => c.CODE);
                                values.AddRange(otherVals.Where(c => !values.Any(v => v.Code == c.CODE)).Select(c => new CodeName() { Code = c.CODE }));
                                //remove blanks and nulls
                                values = values.Where(v => !string.IsNullOrWhiteSpace(v.Code)).OrderBy(v => v.Code).ToList();
                                //add value from the rule in case it is not used anywhere in the values from the table, because
                                //otherwise the DevExpress GridLookupEdit will not display it
                                if (!values.Any(v => v.Code == _selectedRecord.CODE)) {
                                    values.Add(new CodeName(_selectedRecord.CODE));
                                }
                                bindingSourceCodeNameProduct.DataSource = values;
                            }
                            switch (rule.Lookup_Table) {
                                case "OPERATOR":
                                    bindingSourceCodeNameProduct.DataSource = _operatorLookup;
                                    break;
                                case "SERVTYPE":
                                    bindingSourceCodeNameProduct.DataSource = _servtypeLookup;
                                    break;
                                case "PACKTYPE":
                                    bindingSourceCodeNameProduct.DataSource = _packtypeLookup;
                                    break;
                                case "REGION":
                                    bindingSourceCodeNameProduct.DataSource = _regionLookup;
                                    break;
                                case "COUNTRY":
                                    bindingSourceCodeNameProduct.DataSource = _countryLookup;
                                    break;
                                case "LOOKUP":
                                    bindingSourceCodeNameProduct.DataSource = _context.LOOKUP
                                        .Where(l => l.RECTYPE == rule.Link_Rectype)
                                        .OrderBy(l => l.CODE)
                                        .Select(l => new CodeName() { Code = l.CODE, Name = l.DESC });
                                    break;
                                case "CITYCOD":
                                    bindingSourceCodeNameProduct.DataSource = _citycodLookup;
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) {
                this.DisplayError(ex);
            }
        }

        private void LoadAgencyValues()
        {
            try {
                bindingSourceCodeNameAgency.DataSource = null;
                if (string.IsNullOrEmpty(imageComboBoxEditAgencyRule.Text)) {
                    //If no rule is specified, use specific agencies
                    bindingSourceCodeNameAgency.DataSource = _agencyLookup;
                }
                else {
                    int id = (int)imageComboBoxEditAgencyRule.EditValue;
                    var rule = _rules.FirstOrDefault(r => r.ID == id);
                    if (rule != null) {
                        //The user cannot select a value if the rule is a query
                        SetAgencyFieldsState(string.IsNullOrEmpty(rule.Query), false);

                        if (string.IsNullOrEmpty(rule.Query)) {
                            if (string.IsNullOrEmpty(rule.Lookup_Table)) {
                                //TODO: check the USERFIELDS table for the link to the LOOKUP table

                                //If no lookup table is provided, use distinct values from the link table and field
                                IQueryable table = (IQueryable)(_context.GetType()).GetProperty(rule.Link_Table).GetValue(_context, null);
                                //The "new" constructor is not invoking an overloaded constructor but is parsed by System.Linq.Dynamic
                                //to locate the correct type and populate the property/ies. Unless the names match, the property names must
                                //be aliased to match the destination class, since this is not invoking a parameterized constructor 
                                //even though it looks like that.
                                var values = table.Select<CodeName>("new CodeName(" + rule.Link_Column + " as Code)").Distinct().ToList();
                                //Add other values from COMPROD2 records that use this same rule
                                var otherVals = _context.COMPROD2.Where(c => c.CommLevel_ID_Agency == rule.ID).DistinctBy(c => c.CODE);
                                values.AddRange(otherVals.Where(c => !values.Any(v => v.Code == c.CODE)).Select(c => new CodeName() { Code = c.CODE }));
                                //remove blanks and nulls
                                values = values.Where(v => !string.IsNullOrWhiteSpace(v.Code)).OrderBy(v => v.Code).ToList();
                                //add value from the rule in case it is not used anywhere in the values from the table, because
                                //otherwise the DevExpress GridLookupEdit will not display it
                                if (!values.Any(v => v.Code == _selectedRecord.CODE)) {
                                    values.Add(new CodeName(_selectedRecord.CODE));
                                }
                                bindingSourceCodeNameAgency.DataSource = values;
                            }
                            switch (rule.Lookup_Table) {
                                case "COUNTRY":
                                    bindingSourceCodeNameAgency.DataSource = _countryLookup;
                                    break;
                                case "LOOKUP":
                                    bindingSourceCodeNameAgency.DataSource = _context.LOOKUP
                                        .Where(l => l.RECTYPE == rule.Link_Rectype)
                                        .OrderBy(l => l.CODE)
                                        .Select(l => new CodeName() { Code = l.CODE, Name = l.DESC });
                                    break;
                                case "LANGUAGE":
                                    bindingSourceCodeNameAgency.DataSource = _languageLookup;
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) {
                this.DisplayError(ex);
            }
        }

        private void imageComboBoxEditAgencyRule_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAgencyValues();
        }

        private void checkEditExclusion_CheckedChanged(object sender, EventArgs e)
        {
            SetErrorInfo(_selectedRecord.ValidateExclusion, sender, true);
            lookupEditExclusionProduct.Enabled = (checkEditExclusion.Checked && comboBoxEditType.Text != "AGY");
            lookupEditExclusionProduct.ReadOnly = !checkEditExclusion.Checked;
            lookupEditExclusionAgency.Enabled = checkEditExclusion.Checked;
            lookupEditExclusionAgency.ReadOnly = !checkEditExclusion.Checked;
            spinEditCommPct.Enabled = !checkEditExclusion.Checked;
            spinEditCommPct.ReadOnly = checkEditExclusion.Checked;
            spinEditFlatAmount.Enabled = !checkEditExclusion.Checked;
            spinEditFlatAmount.ReadOnly = checkEditExclusion.Checked;
            spinEditSupplierPercentage.Enabled = !checkEditExclusion.Checked;
            spinEditSupplierPercentage.ReadOnly = checkEditExclusion.Checked;
            spinEditSupplierFlatAmount.Enabled = !checkEditExclusion.Checked;
            spinEditSupplierFlatAmount.ReadOnly = checkEditExclusion.Checked;
            textEditCustomerPromo.Enabled = !checkEditExclusion.Checked;
            textEditCustomerPromo.ReadOnly = checkEditExclusion.Checked;
            textEditSupplierPromo.Enabled = !checkEditExclusion.Checked;
            textEditSupplierPromo.ReadOnly = checkEditExclusion.Checked;
            if (checkEditExclusion.Checked) {
                spinEditCommPct.Value = 0;
                spinEditFlatAmount.Value = 0;
                spinEditSupplierFlatAmount.Value = 0;
                spinEditSupplierPercentage.Value = 0;
                textEditSupplierPromo.Text = string.Empty;
                textEditCustomerPromo.Text = string.Empty;
            }
        }

        private void checkEditAvailability_CheckedChanged(object sender, EventArgs e)
        {
            SetErrorInfo(_selectedRecord.ValidateFlags, sender, true);
        }

        private void checkEditImports_CheckedChanged(object sender, EventArgs e)
        {
            SetErrorInfo(_selectedRecord.ValidateFlags, sender, true);
        }

        private void checkEditInactive_CheckedChanged(object sender, EventArgs e)
        {
            SetErrorInfo(null, sender, true);
        }

        private void gridLookUpEditAgencyValue_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {
            if (!string.IsNullOrEmpty(imageComboBoxEditAgencyRule.Text)
                && e.DisplayValue != null && !string.IsNullOrEmpty(e.DisplayValue.ToString())) {
                CodeName codeName = new CodeName(e.DisplayValue.ToString());
                bindingSourceCodeNameAgency.Add(codeName);
                e.Handled = true;
            }
        }

        private void SetSupplierFieldsState(bool enabled)
        {
            spinEditSupplierFlatAmount.Enabled = enabled;
            spinEditSupplierFlatAmount.ReadOnly = !enabled;
            spinEditSupplierPercentage.Enabled = enabled;
            spinEditSupplierPercentage.ReadOnly = !enabled;
            textEditSupplierPromo.Enabled = enabled;
            textEditSupplierPromo.ReadOnly = !enabled;
            if (!enabled) {
                spinEditSupplierFlatAmount.EditValue = null;
                spinEditSupplierPercentage.EditValue = null;
                textEditSupplierPromo.Text = string.Empty;
            }
            groupControlSupplier.Visible = enabled;
        }

        private void imageComboBoxEditPlatform_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidatePlatform, sender, true);
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            //We never want users to be able to type in a record position number but the binding navigator
            //has built in behaviour that keeps enabling the position so the only way to prevent editing
            //is to disable it in the Enter event
            bindingNavigatorPositionItem.Enabled = false;       
        }

    }
}
