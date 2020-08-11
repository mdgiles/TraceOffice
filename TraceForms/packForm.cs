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
using FlexCommissions;

namespace TraceForms
{
    public partial class PackForm : DevExpress.XtraEditors.XtraForm
    {
        FlextourEntities _context;
        PACK _selectedRecord;
        Timer _actionConfirmation;
        bool _ignoreLeaveRow = false, _ignorePositionChange = false;
        ICoreSys _sys;
        RepositoryItemImageComboBox _supplierCombo = new RepositoryItemImageComboBox();
        RepositoryItemImageComboBox _operatorCombo = new RepositoryItemImageComboBox();
        Dictionary<String, List<CodeName>> _locationLookups = new Dictionary<String, List<CodeName>>();
        private readonly DateTime _baseDate = new DateTime(1900, 1, 1);

        public PackForm(FlexInterfaces.Core.ICoreSys sys)
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
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            var cities = new List<CodeName> {
                new CodeName(null)
            };
            cities.AddRange(_context.CITYCOD
                .OrderBy(o => o.NAME)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }).ToList());
            SearchLookupEditCity.Properties.DataSource = cities;
            _locationLookups.Add("CTY", cities);

            var hotels = new List<CodeName> {
                new CodeName(null)
            };
            hotels.AddRange(_context.HOTEL
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }).ToList());
            _locationLookups.Add("HTL", hotels);

            var waypoints = new List<CodeName> {
                new CodeName(null)
            };
            waypoints.AddRange(_context.WAYPOINT
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.DESC }).ToList());
            _locationLookups.Add("WAY", waypoints);

            var depcities = new List<CodeName> {
                new CodeName(null)
            };
            depcities.AddRange(_context.CITYCOD
                .OrderBy(o => o.NAME)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }).ToList());
            SearchLookupEditDepCity.Properties.DataSource = depcities;

            var pkgtypes = new List<CodeName> {
                new CodeName(null)
            };
            pkgtypes.AddRange(_context.PACKTYPE
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.DESC }).ToList());
            SearchLookupEditPkgType.Properties.DataSource = pkgtypes;

            var languages = new List<CodeName> {
                new CodeName(null)
            };
            languages.AddRange(_context.LANGUAGE
                .OrderBy(o => o.NAME)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }).ToList());
            ImageComboBoxEditLanguage.Properties.DataSource = languages;

            var operators = new List<CodeName> {
                new CodeName(null)
            };
            operators.AddRange(_context.OPERATOR
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }).ToList());
            SearchLookupEditOperator.Properties.DataSource = operators;

            var categories = new List<CodeName> {
                new CodeName(null)
            };
            categories.AddRange(_context.ROOMCOD
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.DESC }).ToList());
            RepositoryItemSearchLookUpEditDefaultCat.DataSource = categories;

            var agencies = new List<CodeName> {
                new CodeName(null)
            };
            agencies.AddRange(_context.AGY
                .OrderBy(o => o.NO)
                .Select(s => new CodeName() { Code = s.NO, Name = s.NAME }).ToList());
            SearchLookupEditAgency.Properties.DataSource = agencies;

            var regions = new List<CodeName> {
                new CodeName(null)
            };
            regions.AddRange(_context.REGION
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.DESC }).ToList());
            SearchLookupEditRegion.Properties.DataSource = regions;

            var alternates = new List<CodeName> {
                new CodeName(null)
            };
            alternates.AddRange(_context.PACK
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }).ToList());
            SearchLookupEditAltern1.Properties.DataSource = alternates;
            SearchLookupEditAltern2.Properties.DataSource = alternates;
            SearchLookupEditAltern3.Properties.DataSource = alternates;

            _supplierCombo.Items.Add(loadBlank);
            _supplierCombo.Items.AddRange(_context.Supplier
                            .OrderBy(o => o.Name).AsEnumerable()
                            .Select(s => new ImageComboBoxItem() { Description = s.Name, Value = s.GUID })
                            .ToList());
            GridControlSupplierProduct.RepositoryItems.Add(_supplierCombo);        //per DX recommendation to avoid memory leaks

            _operatorCombo.Items.Add(loadBlank);
            _operatorCombo.Items.AddRange(_context.OPERATOR
                            .OrderBy(o => o.NAME).AsEnumerable()
                            .Select(s => new ImageComboBoxItem() { Description = $"{s.CODE} ({s.NAME})", Value = s.CODE })
                            .ToList());
            GridControlSupplierProduct.RepositoryItems.Add(_operatorCombo);        //per DX recommendation to avoid memory leaks

            BindingSourceUserFields.DataSource = _context.USERFIELDS
                .Where(u => (u.VISIBLE ?? false) && u.LINK_TABLE == "PACK")
                .OrderBy(u => u.POSITION);
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
                        _context.PACK.AddObject(_selectedRecord);
                    }
                    SetUpdateFields(_selectedRecord);
                    _context.SaveChanges();
                    if (newRec || nameChanged) {
                        AccountingAPI.InvokeForProduct(_sys.Settings.TourAccountingURL, "PKG", _selectedRecord.CODE);
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

        private void SetUpdateFields(PACK record)
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
                            _context.PACK.DeleteObject(_selectedRecord);
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

        private void EntityInstantFeedbackSource_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            FlextourEntities context = new FlextourEntities(Connection.EFConnectionString);
            e.QueryableSource = context.PACK;
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
                    PACK record = (PACK)proxy.OriginalRow;
                    BindingSource.DataSource = _context.PACK.Where(c => c.CODE == record.CODE);
                    TextEditCode.ReadOnly = false;
                }
                else {
                    ClearBindings();
                }
            }
        }

        private bool IsModified(PACK record)
        {
            //Type-specific routine that takes into account relationships that should also be considered
            //when deciding if there are unsaved changes.  The entity properties also return true if the
            //record is new or deleted.
            if (record == null)
                return false;
            return record.IsModified(_context)
                || record.SupplierProduct.IsModified(_context)
                || record.SupplierCategory.IsModified(_context);
        }

        void ClearBindings()
        {
            _ignoreLeaveRow = true;
            _ignorePositionChange = true;
            _selectedRecord = null;
            BindingSourceSupplierProduct.Clear();
            SetReadOnly(true);
            BarButtonItemDelete.Enabled = false;
            BarButtonItemUpdateWebsite.Enabled = false;
            BarButtonItemSave.Enabled = false;
            BindingSource.DataSource = typeof(PACK);
            GridViewUserFields.LayoutChanged();     //forces the CustomUnboundColumnData event to fire to clear the custom fields
            _ignoreLeaveRow = false;
            _ignorePositionChange = false;
        }

        void SetBindings()
        {
            if (BindingSource.Current == null) {
                ClearBindings();
            }
            else {
                _selectedRecord = ((PACK)BindingSource.Current);
                LoadAndBindSupplierProducts();
                LoadAndBindSupplierCategories();
                SetReadOnly(false);
                SetReadOnlyKeyFields(true);
                BarButtonItemDelete.Enabled = true;
                BarButtonItemUpdateWebsite.Enabled = true;
                BarButtonItemSave.Enabled = true;
                GridViewUserFields.LayoutChanged();     //forces the CustomUnboundColumnData event to fire to display the custom fields
            }
            ErrorProvider.Clear();
        }

        private void FinalizeBindings()
        {
            BindingSource.EndEdit();
            GridViewSupplierProduct.CloseEditor();
            GridViewSupplierProduct.UpdateCurrentRow();
            GridViewSupplierCategory.CloseEditor();
            GridViewSupplierCategory.UpdateCurrentRow();
            GridViewUserFields.CloseEditor();
            GridViewUserFields.UpdateCurrentRow();
            //Set the city code for each mapping just in case
            for (int rowCtr = 0; rowCtr < GridViewSupplierCategory.DataRowCount; rowCtr++) {
                SupplierCategory suppCat = (SupplierCategory)GridViewSupplierCategory.GetRow(rowCtr);
                suppCat.Product_Type = "PKG";
                suppCat.Product_Code = TextEditCode.Text ?? string.Empty;
                //Empty string represents no category mapping, but it needs to be null for the foreign key
                if (string.IsNullOrWhiteSpace(suppCat.Roomcod_Code)) {
                    suppCat.Roomcod_Code = null;
                }
            }
            BindingSourceSupplierCategory.EndEdit();

            //Set the city code for each mapping just in case
            for (int rowCtr = 0; rowCtr < GridViewSupplierProduct.DataRowCount; rowCtr++) {
                SupplierProduct suppProduct = (SupplierProduct)GridViewSupplierProduct.GetRow(rowCtr);
                suppProduct.Product_Type = "PKG";
                suppProduct.Product_Code_Internal = TextEditCode.Text ?? string.Empty;
            }
            BindingSourceSupplierProduct.EndEdit();
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
            SetErrorInfo(_selectedRecord.ValidateCode, TextEditCode);
            SetErrorInfo(_selectedRecord.ValidateName, TextEditName);
            SetErrorInfo(_selectedRecord.ValidateLang, ImageComboBoxEditLanguage);
            SetErrorInfo(_selectedRecord.ValidateCity, SearchLookupEditCity);
            SetErrorInfo(_selectedRecord.ValidateCity, SearchLookupEditDepCity);
            SetErrorInfo(_selectedRecord.ValidateRegion, SearchLookupEditRegion);
            SetErrorInfo(_selectedRecord.ValidateOper, SearchLookupEditOperator);
            SetErrorInfo(_selectedRecord.ValidateNts, SpinEditNights);
            SetErrorInfo(_selectedRecord.ValidateOper, SearchLookupEditOperator);
            SetErrorInfo(_selectedRecord.ValidateServicesOnly, CheckEditServicesOnly);
            SetErrorInfo(_selectedRecord.ValidateRateBasis, ImageComboBoxEditRateBasis);
            SetErrorInfo(_selectedRecord.ValidateRstrCode, ImageComboBoxEditRestricCode);
            SetErrorInfo(_selectedRecord.ValidateAltern1, SearchLookupEditAltern1);
            SetErrorInfo(_selectedRecord.ValidateAltern2, SearchLookupEditAltern2);
            SetErrorInfo(_selectedRecord.ValidateAltern3, SearchLookupEditAltern3);
            SetErrorInfo(_selectedRecord.ValidatePkgType, SearchLookupEditPkgType);
            SetErrorInfo(_selectedRecord.ValidateMaxSgl, SpinEditMaxSgl);
            SetErrorInfo(_selectedRecord.ValidateMaxDbl, SpinEditMaxDbl);
            SetErrorInfo(_selectedRecord.ValidateMaxTpl, SpinEditMaxTpl);
            SetErrorInfo(_selectedRecord.ValidateMaxQua, SpinEditMaxQua);
            SetErrorInfo(_selectedRecord.ValidateMaxOth, SpinEditMaxOth);
            SetErrorInfo(_selectedRecord.ValidateInclude1, TextEditInclude1);
            SetErrorInfo(_selectedRecord.ValidateInclude2, TextEditInclude2);
            SetErrorInfo(_selectedRecord.ValidateInclude3, TextEditInclude3);
            SetErrorInfo(_selectedRecord.ValidateInclude4, TextEditInclude4);
            SetErrorInfo(_selectedRecord.ValidateInclude5, TextEditInclude5);
            SetErrorInfo(_selectedRecord.ValidateInclude6, TextEditInclude6);
            SetErrorInfo(_selectedRecord.ValidateSupplierProducts, GridControlSupplierProduct);
            SetErrorInfo(_selectedRecord.ValidateSupplierCategories, GridControlSupplierCategory);
        }

        private void SetErrorInfo(Func<String> validationMethod, object sender)
        {
            BindingSource.EndEdit();
            if (validationMethod != null) {
                string error = validationMethod.Invoke();
                ErrorProvider.SetError((Control)sender, error);
            }
        }

        private void SearchLookupEditCode_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCode, sender);
        }

        private void SearchLookupEditName_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateName, sender);
        }

        private void SpinEditNights_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateNts, sender);
        }

        private void ImageComboBoxEditRateBasis_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateRateBasis, sender);
        }

        private void ImageComboBoxEditRestricCode_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateRstrCode, sender);
        }

        private void SearchLookupEditAltern1_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateAltern1, sender);
        }

        private void SearchLookupEditEditAltern2_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateAltern2, sender);
        }

        private void SearchLookupEditAltern3_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateAltern3, sender);
        }

        private void SearchLookupEditOperatorSearch_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateOper, sender);
        }

        private void SearchLookupEditPkgTypeSearch_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidatePkgType, sender);
        }

        private void ImageComboBoxEditRegionSearch_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateRegion, sender);
        }

        private void SpinEditMaxSgl_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateMaxSgl, sender);
        }

        private void SpinEditMaxDbl_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateMaxDbl, sender);
        }

        private void SpinEditMaxTpl_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateMaxTpl, sender);
        }

        private void SpinEditMaxQua_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateMaxQua, sender);
        }

        private void SpinEditMaxOth_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateMaxOth, sender);
        }

        private void TextEditInclude1_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateInclude1, sender);
        }

        private void TextEditInclude2_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateInclude2, sender);
        }

        private void TextEditInclude3_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateInclude3, sender);
        }

        private void TextEditInclude4_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateInclude4, sender);
        }

        private void TextEditInclude5_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateInclude5, sender);
        }

        private void TextEditInclude6_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateInclude6, sender);
        }

        private void packForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            //If the current record is changing as a result of removing a record to delete it, and it is the last
            //record in the table, then SetBindings will clear the bindings, which will cause the delete
            //to fail because the associated entities will become detached when their BindingSources are cleared.
            //Thus we have a flag which is set in that case to ignore this event.
            if (!_ignorePositionChange)
                SetBindings();
        }

        private void gridViewUserFields_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column == GridColumnCustomValue) {
                string fieldName = GridViewUserFields.GetRowCellValue(e.ListSourceRowIndex, "LINK_COLUMN").ToString();
                if (e.IsGetData) {
                    e.Value = _selectedRecord.GetPropertyValue(fieldName);
                }
                else if (e.IsSetData && _selectedRecord != null) {
                    //FinalizeBindings();
                    _selectedRecord.SetPropertyValue(fieldName, e.Value);
                }
            }
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            DateTime? date;
            if (ButtonEditDate.Text == "") {
                date = null;
            }
            else {
                date = Convert.ToDateTime(ButtonEditDate.Text);
            }

            string agency;
            string source;
            if (string.IsNullOrWhiteSpace(SearchLookupEditAgency.Text))
                agency = _sys.Settings.DefaultAgency;
            else
                agency = SearchLookupEditAgency.Text;

            if (string.IsNullOrWhiteSpace(ComboBoxEditSource.Text))
                source = "ALL";
            else
                source = ComboBoxEditSource.Text;

            UpdateCommMarkupGrid(agency, date, source);//refactor to method
        }

        private void SearchLookupEditCity_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCity, sender);
        }

        private void UpdateCommMarkupGrid(string agency, DateTime? date, string source)
        {
            List<IComprod2> commRecs;
            List<IComprod2> commRecsAgy;
            List<ICommLevel> commLevel;

            commRecs = (from rec in _context.COMPROD2
                            where (rec.TYPE == "PKG") && (!(rec.Inactive ?? true)) && (((rec.START_DATE ?? DateTime.MinValue) <= (date ?? DateTime.MaxValue)) 
                            && ((rec.END_DATE ?? DateTime.MaxValue) >= (date ?? DateTime.MinValue)))
                            select rec).ToList<IComprod2>();
            commRecsAgy = (from rec in _context.COMPROD2
                                where (rec.TYPE == "AGY") && (!(rec.Inactive ?? true)) && (((rec.START_DATE ?? DateTime.MinValue) <= (date ?? DateTime.MaxValue))
                            && ((rec.END_DATE ?? DateTime.MaxValue) >= (date ?? DateTime.MinValue)))
                           select rec).ToList<IComprod2>();
            commLevel = (from rec in _context.CommLevel select rec).ToList<ICommLevel>();

            foreach (COMPROD2 rec in commRecs) {
                rec.SetProductRulePosition(commLevel);
            }
            foreach (COMPROD2 rec in commRecsAgy) {
                rec.SetProductRulePosition(commLevel);
            }

            using (FlextourEntities context2 = new FlextourEntities(Connection.EFConnectionString)) {
                IList<Commission> commQuery1 = new List<Commission>();
                IList<Commission> commQuery2 = new List<Commission>();
                commQuery1 = Commissions.GetProductCommissions(context2, "C", TextEditCode.Text.TrimEnd(), "PKG", commRecs, commLevel, null, date, null, null, agency, source);
                commQuery2 = Commissions.GetAgencyCommissions(context2, "C", commRecsAgy, commLevel, agency, date, null, null, source);
                IList<Commission> mergedList = (commQuery1.Union(commQuery2)).ToList();
                GridControlCommissions.DataSource = mergedList;
                commQuery1 = Commissions.GetProductCommissions(context2, "M", TextEditCode.Text.TrimEnd(), "PKG", commRecs, commLevel, null, date, null, null, agency, source);
                commQuery2 = Commissions.GetAgencyCommissions(context2, "M", commRecsAgy, commLevel, agency, date, null, null, source);
                mergedList = (commQuery1.Union(commQuery2)).ToList();
                GridControlMarkups.DataSource = mergedList;
            }
        }

        private void SearchLookupEditLanguage_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateLang, sender);
        }

        private void CheckEditServicesOnly_Modified(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateInclude2, sender);
        }

        private void BarButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _ignoreLeaveRow = true;       //so that when the grid row changes it doesn't try to save again
            if (SaveRecord(true)) {
                //For some reason when there is no existing record in the binding source the Add method does not
                //trigger the CurrentChanged event, but AddNew does so use that instead
                _selectedRecord = (PACK)BindingSource.AddNew();
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

        private void MappingAddButton_Click(object sender, EventArgs e)
        {
            SupplierProduct suppProduct = new SupplierProduct {
                Product_Code_Internal = TextEditCode.Text ?? string.Empty,
                Product_Type = "PKG"
            };
            _selectedRecord.SupplierProduct.Add(suppProduct);
            BindSupplierProducts();
            GridViewSupplierProduct.FocusedRowHandle = BindingSourceSupplierProduct.Count - 1;
        }

        private void MappingDelButton_Click(object sender, EventArgs e)
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

        void BindSupplierProducts()
        {
            GridControlSupplierProduct.DataSource = BindingSourceSupplierProduct;
            GridControlSupplierProduct.RefreshDataSource();
        }

        private void GridViewSupplierProduct_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        void GridViewSupplierProduct_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column == gridColumnSupplierGuid) {
                e.RepositoryItem = _supplierCombo;
            }
            else if (e.Column == colPickup_Location_Default) {
                string type = GridViewSupplierProduct.GetRowCellDisplayText(e.RowHandle, "Pickup_LocationType_Default");
                if (_locationLookups.ContainsKey(type)) {
                    RepositoryItemSearchLookUpEditDefaultPUpLoc.DataSource = _locationLookups[type];
                }
                else {
                    RepositoryItemSearchLookUpEditDefaultPUpLoc.DataSource = null;
                }
            }
            else if (e.Column == colDropoff_Location_Default) {
                string type = GridViewSupplierProduct.GetRowCellDisplayText(e.RowHandle, "Dropoff_LocationType_Default");
                if (_locationLookups.ContainsKey(type)) {
                    RepositoryItemSearchLookUpEditDefaultDropLoc.DataSource = _locationLookups[type];
                }
                else {
                    RepositoryItemSearchLookUpEditDefaultDropLoc.DataSource = null;
                }
            }
        }

        private void GridViewSupplierProduct_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            //Clear the associated time when the pickup or dropoff location changes because we want staff to be conscious
            //that time should probably change if the location changes (downside is that if the time was supposed to be the
            //same and they were not paying attention they may not remember what it was before it was cleared)
            if (e.Column == colPickup_LocationType_Default) {
                GridViewSupplierProduct.SetRowCellValue(e.RowHandle, colPickup_Location_Default, null);
                GridViewSupplierProduct.SetRowCellValue(e.RowHandle, colPickup_Time_Default, null);
            }
            else if (e.Column == colDropoff_LocationType_Default) {
                GridViewSupplierProduct.SetRowCellValue(e.RowHandle, colDropoff_Location_Default, null);
                GridViewSupplierProduct.SetRowCellValue(e.RowHandle, colDropoff_Time_Default, null);
            }
            else if (e.Column == colPickup_Location_Default) {
                GridViewSupplierProduct.SetRowCellValue(e.RowHandle, colPickup_Time_Default, null);
            }
            else if (e.Column == colDropoff_Location_Default) {
                GridViewSupplierProduct.SetRowCellValue(e.RowHandle, colDropoff_Time_Default, null);
            }
        }

        void LoadAndBindSupplierCategories()
        {
            //Load the related entities. DO NOT do another db query using context.whatever because they
            //will not be associated with the parent entity, and new items will not be added to the relationship
            //so foreign key errors will result. Can't load the related entities on a detached or added (but not saved)
            //entity.
            if (_selectedRecord.EntityState != EntityState.Detached) {
                _selectedRecord.SupplierCategory.Load(MergeOption.OverwriteChanges);
            }
            //Don't do any LINQ operations on the entitycollection, just bind directly to it, otherwise
            //it appears to bind as unassociated with the context and you have to manually add/delete
            //rows from the bindingsource to the context (but changes work fine)
            BindingSourceSupplierCategory.DataSource = _selectedRecord.SupplierCategory;
            BindSupplierCategories();
        }

        void BindSupplierCategories()
        {
            GridControlSupplierCategory.DataSource = BindingSourceSupplierCategory;
            GridControlSupplierCategory.RefreshDataSource();
        }

        private void SimpleButtonAddSupplierCategory_Click(object sender, EventArgs e)
        {
            SupplierCategory cat = new SupplierCategory {
                Product_Code = TextEditCode.Text ?? string.Empty,
                Product_Type = "PKG"
            };
            _selectedRecord.SupplierCategory.Add(cat);
            _context.SupplierCategory.AddObject(cat);//Added this so that the delete routine doesn't crash when attempting to delete an unsaved mapping
            BindSupplierCategories();
            GridViewSupplierCategory.FocusedRowHandle = BindingSourceSupplierCategory.Count - 1;
        }

        private void SimpleButtonDelSupplierCategory_Click(object sender, EventArgs e)
        {
            if (GridViewSupplierCategory.FocusedRowHandle >= 0) {
                SupplierCategory cat = (SupplierCategory)GridViewSupplierCategory.GetFocusedRow();
                BindingSourceSupplierCategory.Remove(cat);
                //Removing from the bindingsource just removes the object from its parent, but does not mark
                //it for deletion, effectively orphaning it.  This will cause foreign key errors when saving.
                //To flag for deletion, delete it from the context as well.
                _context.SupplierCategory.DeleteObject(cat);
                BindSupplierCategories();
            }
        }

        private void GridViewSupplierCategory_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column == colSupplierCategory_Supplier_GUID) {
                e.RepositoryItem = _supplierCombo;
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

        private void GridViewSupplierCategory_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box       
        }

        private void PackForm_Shown(object sender, EventArgs e)
        {
            GridViewLookup.FocusedRowHandle = DevExpress.Data.BaseListSourceDataController.FilterRow;
            GridControlLookup.Focus();
        }

        private void GridControlSupplierProduct_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateSupplierProducts, sender);
        }

        private void GridControlSupplierCategory_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateSupplierCategories, sender);
        }

        private void SearchLookUpEditDepCity_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateDepartureCity, sender);
        }

        private void BarButtonItemUpdateWebsite_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string reportType = string.Join(",", _sys.Settings.MainMediaReport, _sys.Settings.WarningMediaReport);
            _context.usp_RefreshSingleProduct("PKG", TextEditCode.Text, reportType, _sys.Settings.FeaturedMediaSection,
                _sys.Settings.MainMediaReport, _sys.Settings.MainMediaSection);
            ShowActionConfirmation("Website Updated");
        }

        private void RepositoryItemTimeEditDefault_EditValueChanged(object sender, EventArgs e)
        {
            TimeEdit edit = sender as TimeEdit;
            DateTime dt = (DateTime)edit.EditValue;
            dt = new DateTime(_baseDate.Year, _baseDate.Month, _baseDate.Day, dt.Hour, dt.Minute, dt.Second);
            edit.EditValue = dt;
        }

        private void GridViewSupplierCategory_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            view.ClearColumnErrors();
            if (view.GetRowCellValue(e.RowHandle, colSupplierCategory_Supplier_GUID) == null) {
                e.Valid = false;
                view.SetColumnError(colSupplierCategory_Supplier_GUID, "Please select a Supplier from the dropdown for the Supplier Category record.");
            }
            if (string.IsNullOrEmpty(view.GetRowCellValue(e.RowHandle, colSupplierCategory_Code).ToString())) {
                e.Valid = false;
                view.SetColumnError(colSupplierCategory_Code, "Please enter a Code for the Supplier Category record.");
            }
        }
    }
}
