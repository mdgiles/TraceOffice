using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FlexModel;
using DevExpress.XtraTreeList;
using System.Linq;
using DevExpress.XtraTreeList.Nodes;
using System.Collections;
using DevExpress.XtraEditors.Repository;
using System.Runtime.InteropServices;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraGrid;
using FlexInterfaces.Core;
using System.Data.Entity.Core.Objects;
using DevExpress.XtraEditors.Popup;
using DevExpress.Utils.Win;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraVerticalGrid.Rows;

namespace TraceForms
{
     
    public partial class AmenAssignForm : DevExpress.XtraEditors.XtraForm
    {
        FlextourEntities _context;
        AMENASSGN _selectedRecord;
        Timer _actionConfirmation;
        ICoreSys _sys;
        IList<AMENASSGN> _assigned = new List<AMENASSGN>();
        IList<AMENASSGN> _unassigned = new List<AMENASSGN>();
        IEnumerable<AMENITY> _amenities;
        List<CodeName> _roomcodCats = new List<CodeName>();
        List<CodeName> _allCats = new List<CodeName>();
        List<CodeName> _assignedCats;
        List<CodeName> _allRatePlans = new List<CodeName>();
        List<CodeName> _assignedRatePlans;
        List<CodeName> _assignedRatePlansFirst;
        public ImageComboBoxItemCollection hotelVals;
        public ImageComboBoxItemCollection pkgVals;
        public ImageComboBoxItemCollection compVals;
        public Timer rowStatusSave;
        public string modifiedSvcCode;
        Dictionary<string, List<CodeName>> _lookups = new Dictionary<string, List<CodeName>>();
        Dictionary<string, List<CodeName>> _allTypedRatePlans = new Dictionary<string, List<CodeName>>();

        public AmenAssignForm(FlexInterfaces.Core.ICoreSys sys)
        {
            try {
                InitializeComponent();
                Connect(sys);
                LoadLookups();
                EnableAssign(false);
                EnableUnassign(false);
                SetReadOnly(true);
                if (GridLookupEditCategory.Properties.PopupView is GridView view) {
                    view.RowStyle += GridLookupEditCategory_RowStyle;
                }
                if (GridLookUpEditRatePlan.Properties.PopupView is GridView view2) {
                    view2.RowStyle += GridLookUpEditRatePlan_RowStyle;
                }

                //treeList2.ParentFieldName = "PARENT_CODE";
                //treeList2.KeyFieldName = "CODE";
                //treeList1.KeyFieldName = "CODE";
                //treeList1.ParentFieldName = "PARENT_CODE";
            } catch (Exception ex) {
                DisplayHelper.DisplayError(this, ex);
            }
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            _context = new FlextourEntities(sys.Settings.EFConnectionString);
            _sys = sys;
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

        private void EnableAssign(bool enabled)
        {
            BarButtonItemAssign.Enabled = enabled;
            SimpleButtonAssign2.Enabled = enabled;
        }

        private void EnableUnassign(bool enabled)
        {
            BarButtonItemUnassign.Enabled = enabled;
            SimpleButtonUnassign2.Enabled = enabled;
        }

        private void LoadLookups()
        {
            BarButtonItemAssign.Enabled = false;
            _roomcodCats = _context.ROOMCOD
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.DESC }).ToList();
            _allCats.AddRange(_roomcodCats);

            var rpHotels = new List<CodeName>();
            rpHotels.AddRange(_context.SpecialValue
                .OrderBy(o => o.Code)
                .Where(r => r.Type == "HTL")
                .Select(s => new CodeName() { Code = s.Code, Name = s.Name }).ToList());
            _allTypedRatePlans.Add("HTL", rpHotels);

            var rpPkgs = new List<CodeName>();
            rpPkgs.AddRange(_context.SpecialValue
                .OrderBy(o => o.Code)
                .Where(r => r.Type == "PKG")
                .Select(s => new CodeName() { Code = s.Code, Name = s.Name }).ToList());
            _allTypedRatePlans.Add("PKG", rpPkgs);

            var rpComps = new List<CodeName>();
            rpComps.AddRange(_context.SpecialValue
                .OrderBy(o => o.Code)
                .Where(r => r.Type == "OPT")
                .Select(s => new CodeName() { Code = s.Code, Name = s.Name }).ToList());
            _allTypedRatePlans.Add("OPT", rpComps);

            var hotels = new List<CodeName>();
            hotels.AddRange(_context.HOTEL
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }).ToList());
            _lookups.Add("HTL", hotels);

            var comps = new List<CodeName>();
            comps.AddRange(_context.COMP
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }).ToList());
            _lookups.Add("OPT", comps);

            var pkgs = new List<CodeName>();
            pkgs.AddRange(_context.PACK
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }).ToList());
            _lookups.Add("PKG", pkgs);
            //lockGrid(true);
        }

        void SetReadOnly(bool value)
        {
            GridLookUpEditRatePlan.Enabled = !value;
            GridLookupEditCategory.Enabled = !value;
            SearchLookupEditCode.Enabled = !value;
            SimpleButtonSearch.Enabled = !value;
        }

        void SetReadOnlyKeyFields(bool value)
        {
            SearchLookupEditCode.Enabled = !value;
        }

        private void ComboBoxEditSvcType_TextChanged(object sender, EventArgs e)
        {
            SearchLookupEditCode.Properties.DataSource = null;
            string type = ComboBoxEditSvcType.Text;

            if (_lookups.ContainsKey(type)) {
                SearchLookupEditCode.Enabled = true;
                SearchLookupEditCode.Properties.DataSource = _lookups[type];
            }
            else {
                SearchLookupEditCode.Properties.DataSource = null;
            }

            GridLookUpEditRatePlan.Properties.DataSource = null;

            _amenities = _context.AMENITY.Where(a => a.SVC_TYPE == type).OrderBy(a => a.SORT_ORDER);
            TreeListUnassigned.DataSource = _amenities;
            AmenityBindingSource.DataSource = _amenities;

            if ("HTLPKGOPT".Contains(type)) {
                TreeListUnassigned.ResetAutoFilterConditions();
                TreeListUnassigned.BeginSort();
                TreeListUnassigned.Columns["SORT_ORDER"].SortOrder = SortOrder.Ascending;
                TreeListUnassigned.EndSort();
                TreeListUnassigned.ExpandAll();
                TreeListUnassigned.MoveFirst();

                if (type == "HTL") {
                    colITEM_DESC1.Caption = "Hotel Amenities";
                }
                if (type == "PKG") {
                    colITEM_DESC1.Caption = "Package Amenities";
                }
                if (type == "OPT") {
                    colITEM_DESC1.Caption = "Optional Service Amenities";
                }
            }
        }

        private void AmenAssignForm_Load(object sender, EventArgs e)
        {
            //AmenityBindingSource.DataSource = context.AMENITY;
            //AmenAssgnBindingSource.DataSource = context.AMENASSGN;          
        }

        private void SimpleButtonSearch_Click(object sender, EventArgs e)
        {
            if (_assigned.IsModified(_context)) {
                if (SaveRecords(true)) {
                    DisplayAssigned();
                } else {
                    return;
                }
            } else {
                DisplayAssigned();
            }
            EnableAssign(true);
        }

        private void DisplayAssigned()
        {
            string code = SearchLookupEditCode.EditValue.ToString();
            string cat = GridLookupEditCategory.EditValue.ToStringNullIfNull();
            string ratePlan = GridLookUpEditRatePlan.EditValue.ToStringNullIfNull();
            string displayText = SearchLookupEditCode.Properties.GetDisplayText(code);

            LoadAssigned(code, cat, ratePlan);
            AssignRequired(code, cat, displayText, ratePlan);
            OrderTreeListAssigned(displayText);
            EnableUnassign(_assigned.Any());
        }

        private bool SaveRecords(bool prompt)
        {
            try {
                if (_selectedRecord == null)
                    return true;

                FinalizeBindings();
                var newRecs = _assigned.Where(a => a.IsNew());
                bool modified = _assigned.IsModified(_context);

                if (modified) {
                    if (prompt) {
                        DialogResult result = DisplayHelper.QuestionYesNoCancel(this, "Do you want to save these changes?");
                        if (result == DialogResult.No) {
                            RefreshRecords();
                            return true;
                        }
                        else if (result == DialogResult.Cancel) {
                            return false;
                        }
                    }
                    if (!ValidateAll())
                        return false;

                    _context.SaveChanges();
                    //EntityInstantFeedbackSource.Refresh();
                    ShowActionConfirmation("Changes Saved");
                }
                return true;
            }
            catch (Exception ex) {
                DisplayHelper.DisplayError(this, ex);
                RefreshRecords();        //pull it back from db because that is its current state
                                        //We must also Load and rebind the related entities from the db because context.Refresh doesn't do that
                return false;
            }
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

            SetErrorInfo(_selectedRecord.ValidateSvcType, ComboBoxEditSvcType);
            SetErrorInfo(_selectedRecord.ValidateRequireEntry, PropertyGridControlAmenityData);
            SetErrorInfo(_selectedRecord.ValidateSvcCat, GridLookupEditCategory);
            SetErrorInfo(_selectedRecord.ValidateSvcRoom, GridLookUpEditRatePlan);
        }

        private void SetErrorInfo(Func<String> validationMethod, object sender)
        {
            BindingSource.EndEdit();
            if (validationMethod != null) {
                string error = validationMethod.Invoke();
                ErrorProvider.SetError((Control)sender, error);
            }
        }

        private void RefreshRecords()
        {
            //A Detached record has not yet been added to the context
            //An Added record has been added but not yet saved, most likely because there was
            //an error in SaveRecord, in which case we should not retrieve it from the db
            if (_selectedRecord != null && _selectedRecord.EntityState != System.Data.Entity.EntityState.Detached
                && _selectedRecord.EntityState != System.Data.Entity.EntityState.Added) {
                //var newAssignments = _assigned.Where(a => a.IsNew());//Make a collection of everything that IsNew, and delete it
                //foreach (var newAssign in newAssignments) {
                //    _assigned.Remove(newAssign);
                //}
                //_context.Refresh(RefreshMode.StoreWins, _unassigned);

                //_context.Dispose();
                //_context = new FlextourEntities(_sys.Settings.EFConnectionString);

                UndoingChangesObjectContext(_context);
            }
        }

        public static void UndoingChangesObjectContext(ObjectContext Context)
        {
            IEnumerable<object> collection = from e in Context.ObjectStateManager.GetObjectStateEntries
                                        (System.Data.Entity.EntityState.Modified | System.Data.Entity.EntityState.Deleted)
                                             select e.Entity;
            Context.Refresh(RefreshMode.StoreWins, collection);

            IEnumerable<object> AddedCollection = from e in Context.ObjectStateManager.GetObjectStateEntries
                                                        (System.Data.Entity.EntityState.Added)
                                                  select e.Entity;
            foreach (object addedEntity in AddedCollection) {
                if (addedEntity != null) {
                    Context.Detach(addedEntity);
                }
            }
        }

        private void BarButtonItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveRecords(false);
        }

        private void FinalizeBindings()
        {
            BindingSource.EndEdit();
            GridLookupEditCategory.DataBindings[0].WriteValue();
            SetItemCategoryLookup(GridLookupEditCategory.Text);
        }

        private void AssignRequired(string code, string cat, string displayText, string ratePlan)
        {
            string svcType = ComboBoxEditSvcType.Text;
            bool bothBlank = string.IsNullOrEmpty(cat) && string.IsNullOrEmpty(ratePlan);
            List<AMENITY> missingBlankCatOrRatePlan = new List<AMENITY>();
            if (!bothBlank) {
                //This is where we put all the required amenities that are not assigned to blank category AND blank rate plan
                missingBlankCatOrRatePlan = _context.AMENITY.Where(a => a.SVC_TYPE == svcType && a.REQUIRE_ENTRY == true
                        && !a.AMENASSGN.Any(aa => aa.SVC_CODE == code && aa.CODE == a.CODE && string.IsNullOrEmpty(aa.SVC_CAT) && string.IsNullOrEmpty(aa.SVC_ROOM)))
                        .ToList();
            }
            
            List<AMENITY> required = new List<AMENITY>();
            try {//Collect all the required amenities that are not assigned already
                required = _amenities.Where(a => a.SVC_TYPE == svcType && a.REQUIRE_ENTRY == true
                                                && (missingBlankCatOrRatePlan.Any(r => r.CODE == a.CODE) || bothBlank)
                                                && !_assigned.Any(aa => aa.CODE == a.CODE)).ToList();
            }
            catch (Exception ex) {
                DisplayHelper.DisplayError(this, ex);
            }
            
            if (required.Any())
            {
                DialogResult select = MessageBox.Show("There are required amenities which are not currently assigned to this product.  Would you like to automatically assign them now?", Name, MessageBoxButtons.YesNo);

                if (select == DialogResult.Yes)
                {
                    foreach (var value in required)
                    {
                        //int sort = (int)value.SORT_ORDER;

                        //if ((from amenAssn in context.AMENASSGN where amenAssn.SVC_CODE == code && amenAssn.SVC_TYPE == ComboBoxEditSvcType.Text && amenAssn.CODE == value.CODE select amenAssn).Count() == 0)
                        AssignNode(code, cat, value, ratePlan);
                    }
                    OrderTreeListAssigned(displayText);
                }
            }
        }

        private void DisplayAdditionalAttributes()
        {
            _selectedRecord = (AMENASSGN)TreeListAssigned.GetFocusedRow();

            if (_selectedRecord == null || _selectedRecord.AMENITY == null) {
                PropertyGridControlAmenityData.Visible = false;
                LabelControlAttributes.Visible = false;
                return;
            }

            SetCustomDataFormat("rowItem1", _selectedRecord.AMENITY.ITEM_DESC1, _selectedRecord.AMENITY.ITEM_FORMAT1);
            SetCustomDataFormat("rowItem2", _selectedRecord.AMENITY.ITEM_DESC2, _selectedRecord.AMENITY.ITEM_FORMAT2);

            PropertyGridControlAmenityData.SelectedObject = _selectedRecord;
            PropertyGridControlAmenityData.Visible = true;
            LabelControlAttributes.Visible = true;
            rowAgeFrom.Visible = _selectedRecord.AMENITY.UseAgeFields;
            rowAgeTo.Visible = _selectedRecord.AMENITY.UseAgeFields;
            rowFromDate.Visible = _selectedRecord.AMENITY.UseDateFields;
            rowToDate.Visible = _selectedRecord.AMENITY.UseDateFields;
            rowHasFee.Visible = _selectedRecord.AMENITY.UseFeeFields;
            rowFeeType.Visible = _selectedRecord.AMENITY.UseFeeFields;
            rowFeeAmount.Visible = _selectedRecord.AMENITY.UseFeeFields;
            rowFeeCurrency_Code.Visible = _selectedRecord.AMENITY.UseFeeFields;
            rowDistance.Visible = _selectedRecord.AMENITY.UseDistanceFields;
            rowDistanceUnits.Visible = _selectedRecord.AMENITY.UseDistanceFields;
            rowNumber.Visible = _selectedRecord.AMENITY.UseNumber;
            rowToTime.Visible = _selectedRecord.AMENITY.UseTimeFields;
            rowFromTime.Visible = _selectedRecord.AMENITY.UseTimeFields;
        }

        private void SetCustomDataFormat(string key, string name, string format)
        {
            var row = PropertyGridControlAmenityData.Rows[key];
            row.Properties.Caption = name;
            row.Visible = !string.IsNullOrEmpty(format);
            if (row.Visible == false) {
                return;
            }
            switch (format) {
                case "Yes/No":
                    RepositoryItemCheckEdit check = new RepositoryItemCheckEdit {
                        ValueUnchecked = "False",
                        ValueChecked = "True",
                        ValueGrayed = string.Empty
                    };
                    //PropertyGridControlAmenityData.RepositoryItems.Add(check);
                    row.Properties.RowEdit = check;
                    break;
                case "Date":
                    RepositoryItemDateEdit date = new RepositoryItemDateEdit();
                    row.Properties.RowEdit = date;
                    break;
                case "Time":
                    RepositoryItemTimeEdit time = new RepositoryItemTimeEdit();
                    row.Properties.RowEdit = time;
                    break;
                case "Text":
                    RepositoryItemTextEdit text = new RepositoryItemTextEdit();
                    row.Properties.RowEdit = text;
                    break;
                case "Currency":
                    RepositoryItemSpinEdit spin = new RepositoryItemSpinEdit {
                        IsFloatValue = true,
                        EditMask = "f"
                    };
                    row.Properties.RowEdit = spin;
                    break;
                case "Integer":
                    RepositoryItemSpinEdit integerSpin = new RepositoryItemSpinEdit();
                    row.Properties.RowEdit = integerSpin;
                    break;
                case "Decimal":
                    RepositoryItemSpinEdit decimalSpin = new RepositoryItemSpinEdit { 
                        IsFloatValue = true,
                        EditMask = "f"
                    };
                    row.Properties.RowEdit = decimalSpin;
                    break;
                case "":
                    break;
            }
        }

        private void TreeListAssigned_AfterFocusNode(object sender, NodeEventArgs e)
        {
            DisplayAdditionalAttributes();
        }

        private void AmenAssignForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_assigned.IsModified(_context)) {
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

        private void TreeListAssigned_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            if (e.Column == colItemDesc1Assgn)
            {
                if (e.Node.Level == 0 || e.Node.HasChildren)
                {
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                }

                var row = (AMENASSGN)TreeListAssigned.GetRow(e.Node.Id);

                if (Convert.ToBoolean(e.Node.GetValue(colReqEntryAssgn))) {
                    e.Appearance.ForeColor = Color.Red;
                }
                else if (row.HasData) {
                    e.Appearance.ForeColor = Color.Blue;
                }
            }
        }

        private void TreeListUnassigned_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "ITEM_DESC1")
            {
                if (e.Node.Level == 0 || e.Node.HasChildren)
                {
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                }
             
                if(Convert.ToBoolean(e.Node.GetValue(colREQUIRE_ENTRY)))
                    e.Appearance.ForeColor = Color.Red;
            }
        }

        private void TreeListUnassigned_DoubleClick(object sender, System.EventArgs e)
        {
            if (TreeListUnassigned.FocusedNode != null)
            {
                var row = (AMENITY)TreeListUnassigned.GetFocusedRow();
                string itemCode = SearchLookupEditCode.EditValue.ToString();
                string cat = GridLookupEditCategory.EditValue.ToStringNullIfNull();
                string ratePlan = GridLookUpEditRatePlan.EditValue.ToStringNullIfNull();

                AssignNode(itemCode, cat, row, ratePlan);
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

        private void OrderTreeListAssigned(string displayText)
        {
            TreeListAssigned.ResetAutoFilterConditions();
            TreeListAssigned.ParentFieldName = "AMENITY.PARENT_CODE";
            TreeListAssigned.KeyFieldName = "CODE";
            TreeListAssigned.BeginSort();
            TreeListAssigned.Columns["AMENITY.SORT_ORDER"].SortOrder = SortOrder.Ascending;
            TreeListAssigned.EndSort();
            TreeListAssigned.ExpandAll();
            colItemDesc1Assgn.Caption = "Amenities for " + displayText;
            TreeListAssigned.MoveFirst();
        }

        private void LoadAssigned(string code, string cat, string ratePlan)
        {
            _assigned = _context.AMENASSGN.Include(aa => aa.AMENITY)
                .Where(aa => aa.SVC_CODE == code && aa.SVC_TYPE == ComboBoxEditSvcType.Text && aa.SVC_CAT == cat && aa.SVC_ROOM == ratePlan).ToList();
            TreeListAssigned.DataSource = _assigned;
        }

        private void TreeListUnassigned_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {//Leaving the two FocusedNodeChanged events here even though they do nothing so that I have something to put a breakpoint on

        }

        private void TreeListAssigned_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {

        }

        private void SearchLookupEditCode_EditValueChanged(object sender, EventArgs e)
        {
            string code = SearchLookupEditCode.EditValue.ToStringEmptyIfNull();
            GridLookupEditCategory.Enabled = !string.IsNullOrEmpty(code);
            GridLookUpEditRatePlan.Enabled = !string.IsNullOrEmpty(code);
            SimpleButtonSearch.Enabled = !string.IsNullOrEmpty(code);

            //We want the categories which have amenities assigned at the top of the list
            _assignedCats = _context.AMENASSGN
                .Include(aa => aa.ROOMCOD).DefaultIfEmpty()
                .Where(c => c.SVC_CODE == code)
                .GroupBy(c => new { Cat = c.SVC_CAT, CatName = (c.ROOMCOD != null) ? c.ROOMCOD.DESC : "" })
                .OrderBy(o => o.Key.Cat)
                .Select(s => new CodeName() { Code = string.IsNullOrEmpty(s.Key.Cat) ? null : s.Key.Cat, Name = s.Key.CatName }).ToList();
            //The first one of all should be the blank cat, which should be there whether there
            //are amenities assigned to it or not, so we add it manually
            _allCats = new List<CodeName> {
                new CodeName(null, "No category")
            };
            //Now add the categories which have amenities assigned
            _allCats.AddRange(_assignedCats.Where(a => a.Code != null));
            //Now add all the other categories from ROOMCOD 
            _allCats.AddRange(_roomcodCats.Except(_assignedCats.Where(a => a.Code != null)));
            GridLookupEditCategory.Properties.DataSource = _allCats;

            SetRatePlanDataSource(code);
        }

        private void SetRatePlanDataSource(string code)
        {
            //We want the rate plans which have amenities assigned at the top of the list
            QueryRatePlan(code, null, ComboBoxEditSvcType.Text);

            if (_allTypedRatePlans.ContainsKey("")) {
                _allRatePlans = _allTypedRatePlans[""];
            }
            _allRatePlans.AddRange(_allTypedRatePlans[ComboBoxEditSvcType.Text]);

            //The first one of all should be the blank rate plan, which should be there whether there
            //are amenities assigned to it or not, so we add it manually
            _assignedRatePlansFirst = new List<CodeName> {
                new CodeName(null, "No rate plan")
            };
            //Now add the rate plans which have amenities assigned
            _assignedRatePlansFirst.AddRange(_assignedRatePlans.Where(a => a.Code != null));
            //Now add all the other rate plans with the same type
            _assignedRatePlansFirst.AddRange(_allRatePlans.Except(_assignedRatePlans.Where(a => a.Code != null)));
            GridLookUpEditRatePlan.Properties.DataSource = _assignedRatePlansFirst;
        }

        private void QueryRatePlan(string code, string cat, string type)
        {
            _assignedRatePlans = _context.AMENASSGN
                .Include(aa => aa.SpecialValue).DefaultIfEmpty()
                .Where(c => c.SVC_CODE == code && c.SVC_CAT == cat && c.SVC_TYPE == type)
                .GroupBy(c => new { Rate = c.SVC_ROOM, RateName = (c.SpecialValue != null) ? c.SpecialValue.Name : "" })
                .OrderBy(o => o.Key.Rate)
                .Select(s => new CodeName() { Code = string.IsNullOrEmpty(s.Key.Rate) ? null : s.Key.Rate, Name = s.Key.RateName }).ToList();
        }

        private void GridLookupEditRatePlan_ProcessNewValue(object sender, ProcessNewValueEventArgs e) 
        {
            SetRatePlanLookup(e.DisplayValue.ToStringEmptyIfNull());
            e.Handled = true;
            SetRatePlanDataSource(SearchLookupEditCode.EditValue.ToString());
        }

        private void SetRatePlanLookup(string ratePlan)
        {
            string type = ComboBoxEditSvcType.EditValue.ToStringEmptyIfNull();

            if (string.IsNullOrEmpty(ratePlan) || _allTypedRatePlans[type].Any(c => c.Code == ratePlan)) {
                GridLookUpEditRatePlan.Properties.DataSource = _assignedRatePlansFirst;
            }
            else {
                //If the value of category isn't in the list, add it to the list
                //We allow non-matching categories so that API products can be booked
                //Do not set DataSource because it's already bound to the list, so just changing the list is sufficient
                //Also settings DataSource from ProcessNewValue is forbidden and throws a NullReferenceException

                var listNewPlan = new List<CodeName> {                    
                    new CodeName(ratePlan, ratePlan)
                };
                if (!_allTypedRatePlans.ContainsKey("")) {
                    _allTypedRatePlans.Add("", listNewPlan);
                }
                else {
                    _allTypedRatePlans[""] = listNewPlan;
                }
            }
        }

        private void GridLookupEditItemCategory_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {
            SetItemCategoryLookup(e.DisplayValue.ToString());
            e.Handled = true;
        }

        private void SetItemCategoryLookup(object itemCat)
        {
            string cat = itemCat.ToStringNullIfNull();

            if (string.IsNullOrEmpty(cat) || _allCats.Any(c => c.Code == cat)) {
                GridLookupEditCategory.Properties.DataSource = _allCats;
            }
            else {
                //If the value of category isn't in the list, add it to the list
                //We allow non-matching categories so that API products can be booked
                //Do not set DataSource because it's already bound to the list, so just changing the list is sufficient
                //Also settings DataSource from ProcessNewValue is forbidden and throws a NullReferenceException
                var newCat = new CodeName(cat);
                _allCats.Add(newCat);
            }
        }

        private void LookupEdit_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ((sender as LookUpEditBase).Properties.DataSource == null)
                e.Cancel = true;
            else
                e.Cancel = false;
        }

        private void BarButtonItemUnassign_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UnassignNode();
        }

        private void BarButtonItemAssign_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TreeListUnassigned.FocusedNode != null) {
                //process hi.Node here
                var amenity = (AMENITY)TreeListUnassigned.GetFocusedRow();
                string itemCode = SearchLookupEditCode.EditValue.ToStringNullIfNull();
                string cat = GridLookupEditCategory.EditValue.ToStringNullIfNull();
                string ratePlan = GridLookUpEditRatePlan.EditValue.ToStringNullIfNull();

                AssignNode(itemCode, cat, amenity, ratePlan);
            }
            else
                MessageBox.Show("Please select a node to assign.");
        }

        private void AssignNode(string itemCode, string cat, AMENITY amenity, string ratePlan)
        {
            //var parentCode = _amenities.Where(a => a.CODE == currentCode).Select(a => a.PARENT_CODE).FirstOrDefault();
            //var parentNode = (from amen in context.AMENITY where amen.CODE == currentCode select new { amen.PARENT_CODE, amen.SORT_ORDER }).FirstOrDefault();
            //int sorts = (int)parentNode.SORT_ORDER;


            //Parent node needs to be assigned when a child node is assigned
            //Check if parent node is already assigned
            var parent = _amenities.FirstOrDefault(r => r.CODE == amenity.PARENT_CODE);
            if (parent != null && !_assigned.Any(a => a.CODE == parent.CODE)) {
                AssignNode(itemCode, cat, parent, ratePlan);
            }
            AMENASSGN rec = new AMENASSGN {
                CODE = amenity.CODE,
                SVC_CODE = itemCode,
                SVC_TYPE = ComboBoxEditSvcType.Text,
                SVC_CAT = cat,
                SVC_ROOM = ratePlan,
                ITEM2 = string.Empty,
                ITEM1 = string.Empty,
                AMENITY = amenity
            };

            if (!_assigned.Any(a => a.CODE == rec.CODE)) {
                _assigned.Add(rec);
                TreeListAssigned.RefreshDataSource();
            }
            else
            {
                // MessageBox.Show("You are attempting to add a an amenity that has already been added.");
                // return;
            }
            //context.SaveChanges();
            // int? order = Convert.ToInt32(treeList1.FocusedNode.GetDisplayText(colSORT_ORDER));                
            //return true;
            //return AssignNode(currentCode, itemCode, cat, sort);
        }

        private void SimpleButtonUnassign2_Click(object sender, EventArgs e)
        {
            UnassignNode();
        }

        private void UnassignNode()
        {
            if (TreeListAssigned.FocusedNode != null) {
                var node = TreeListAssigned.FocusedNode;

                if (node.HasChildren) {
                    var children = node.Nodes;
                    foreach (TreeListNode child in children) {
                        var row = (AMENASSGN)TreeListAssigned.GetRow(child.Id);
                        Unassign(row);
                    }
                }

                var amenity = (AMENASSGN)TreeListAssigned.GetFocusedRow();

                Unassign(amenity);
            }
            if (TreeListAssigned.Nodes.Count == 0) {
                EnableUnassign(false);
            }
            else if (TreeListAssigned.FocusedNode != null) {
                MessageBox.Show("Please select a node to unassign.");
            }
        }

        private void Unassign(AMENASSGN amenity)
        {
            if (amenity != null && (amenity.EntityState & System.Data.Entity.EntityState.Deleted) != System.Data.Entity.EntityState.Deleted) {
                _context.AMENASSGN.DeleteObject(amenity);
                _unassigned.Add(amenity);
            }

            _assigned.Remove(amenity);
            TreeListAssigned.RefreshDataSource();
        }

        private void GridLookupEditCategory_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle != GridControl.InvalidRowHandle) {
                var row = (CodeName)GridLookupEditCategory.Properties.View.GetRow(e.RowHandle);
                if (row != null && _assignedCats.Any(c => c.Code == row.Code)) {
                    e.Appearance.Font = new Font(GridLookupEditCategory.Properties.View.Appearance.Row.Font, System.Drawing.FontStyle.Bold);
                }
                else {
                    e.Appearance.Font = new Font(GridLookupEditCategory.Properties.View.Appearance.Row.Font, System.Drawing.FontStyle.Regular);
                }
            }
        }

        private void GridLookUpEditRatePlan_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle != GridControl.InvalidRowHandle) {
                var row = (CodeName)GridLookUpEditRatePlan.Properties.View.GetRow(e.RowHandle);
                if (row != null && _assignedRatePlans.Any(c => c.Code == row.Code)) {
                    e.Appearance.Font = new Font(GridLookUpEditRatePlan.Properties.View.Appearance.Row.Font, System.Drawing.FontStyle.Bold);
                }
                else {
                    e.Appearance.Font = new Font(GridLookUpEditRatePlan.Properties.View.Appearance.Row.Font, System.Drawing.FontStyle.Regular);
                }
            }
        }

        private void SimpleButtonAssign2_Click(object sender, EventArgs e)
        {
            if (TreeListUnassigned.FocusedNode != null) {
                var amenity = (AMENITY)TreeListUnassigned.GetFocusedRow();
                string itemCode = SearchLookupEditCode.EditValue.ToString();
                string cat = GridLookupEditCategory.EditValue.ToStringNullIfNull();
                string ratePlan = GridLookUpEditRatePlan.EditValue.ToStringNullIfNull();

                AssignNode(itemCode, cat, amenity, ratePlan);
            }
            else
                MessageBox.Show("Please select a node to assign.");
        }

        private void GridLookupEditCategory_EditValueChanged(object sender, EventArgs e)
        {
            QueryRatePlan(SearchLookupEditCode.EditValue.ToStringEmptyIfNull(), GridLookupEditCategory.EditValue.ToStringEmptyIfNull(), ComboBoxEditSvcType.Text);
        }

        private void TreeListAssigned_BeforeFocusNode(object sender, BeforeFocusNodeEventArgs e)
        {
            if (TreeListAssigned.FocusedNode != null) {
                if (_selectedRecord != null)
                    SetErrorInfo(_selectedRecord.ValidateRequireEntry, PropertyGridControlAmenityData);
            }
        }

        private void GridLookupEditCategory_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateSvcCat, sender);
        }

        private void GridLookUpEditRatePlan_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateSvcRoom, sender);
        }

        private void ComboBoxEditSvcType_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateSvcType, sender);
        }

        private void PropertyGridControlAmenityData_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateRequireEntry, sender);
        }
    }
}