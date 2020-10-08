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
        IEnumerable<AMENITY> _amenities;
        List<CodeName> _roomcodCats = new List<CodeName>();
        List<CodeName> _allCats = new List<CodeName>();
        List<CodeName> _assignedCats;
        public ImageComboBoxItemCollection hotelVals;
        public ImageComboBoxItemCollection pkgVals;
        public ImageComboBoxItemCollection compVals;
        public Timer rowStatusSave;
        public List<string> modifiedRecs;
        public string modifiedSvcCode;
        Dictionary<String, List<CodeName>> _lookups = new Dictionary<String, List<CodeName>>();

        public AmenAssignForm(FlexInterfaces.Core.ICoreSys sys)
        {
            try {
                InitializeComponent();
                Connect(sys);
                LoadLookups();
                SetReadOnly(true);
                GridView view = GridLookupEditCategory.Properties.PopupView as GridView;
                if (view != null) {
                    view.RowStyle += GridLookupEditCategory_RowStyle;
                }
                //treeList2.ParentFieldName = "PARENT_CODE";
                //treeList2.KeyFieldName = "CODE";
                //treeList1.KeyFieldName = "CODE";
                //treeList1.ParentFieldName = "PARENT_CODE";
                modifiedRecs = new List<string>();
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

        private void LoadLookups()
        {
            PropertyGridControlAmenityData.Visible = false;
            BarButtonItemAssign.Enabled = false;
            _roomcodCats = _context.ROOMCOD
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.DESC }).ToList();
            _allCats.AddRange(_roomcodCats);

            var hotels = new List<CodeName> {
                new CodeName(null)
            };
            hotels.AddRange(_context.HOTEL
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }).ToList());
            _lookups.Add("HTL", hotels);

            var comps = new List<CodeName> {
                new CodeName(null)
            };
            comps.AddRange(_context.COMP
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }).ToList());
            _lookups.Add("OPT", comps);

            var pkgs = new List<CodeName> {
                new CodeName(null)
            };
            pkgs.AddRange(_context.PACK
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }).ToList());
            _lookups.Add("PKG", pkgs);
            //lockGrid(true);
        }

        void SetReadOnly(bool value)
        {
            GridLookupEditCategory.Enabled = !value;
            SearchLookupEditCode.Enabled = !value;
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
            string code = SearchLookupEditCode.EditValue.ToStringEmptyIfNull();
            string cat = GridLookupEditCategory.EditValue.ToStringEmptyIfNull();
            string displayText = SearchLookupEditCode.Properties.GetDisplayText(code);

            LoadAssigned(code, cat);
            AssignRequired(code, cat, displayText);
            LoadTreeListAssigned(displayText);
        }

        void ClearBindings()
        {
            _selectedRecord = null;
            //BindingSourceSupplierProduct.Clear();
            SetReadOnly(true);
            BarButtonItemDelete.Enabled = false;
            BarButtonItemSave.Enabled = false;
            BindingSource.DataSource = typeof(AMENASSGN);
        }

        void SetBindings()
        {
            if (BindingSource.Current == null) {
                ClearBindings();
            }
            else {
                _selectedRecord = ((AMENASSGN)BindingSource.Current);
                SetReadOnlyKeyFields(false);
                BarButtonItemDelete.Enabled = true;
                BarButtonItemSave.Enabled = true;
            }
            ErrorProvider.Clear();
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
                            if (newRecs.Any()) {
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
                    //if (!ValidateAll())Not sure AmenAssign needs any model validation
                    //    return false;

                    if (_selectedRecord.EntityState == System.Data.Entity.EntityState.Detached) {
                        _context.AMENASSGN.AddObject(_selectedRecord);
                    }
                    

                    _context.SaveChanges();
                    //EntityInstantFeedbackSource.Refresh();
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

        private void RefreshRecord()
        {
            //A Detached record has not yet been added to the context
            //An Added record has been added but not yet saved, most likely because there was
            //an error in SaveRecord, in which case we should not retrieve it from the db
            if (_selectedRecord != null && _selectedRecord.EntityState != System.Data.Entity.EntityState.Detached
                && _selectedRecord.EntityState != System.Data.Entity.EntityState.Added) {
                _context.Refresh(RefreshMode.StoreWins, _selectedRecord);
                SetReadOnly(true);
            }
        }

        private void BarButtonItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SaveRecords(false))
                RefreshRecord();
        }

        private void RemoveRecord()
        {
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

        private void FinalizeBindings()
        {
            BindingSource.EndEdit();
            GridLookupEditCategory.DataBindings[0].WriteValue();
            SetItemCategoryLookup(GridLookupEditCategory.Text);
        }

        private void AssignRequired(string code, string cat, string displayText)
        {
            string svcType = ComboBoxEditSvcType.Text;//When selecting a category other than a blank one, program crashes with no error message.
            List<AMENITY> missingBlankCat = new List<AMENITY>();
            if (!string.IsNullOrEmpty(cat)) {
                //var assignedCodes = _assigned.Select(p => p.CODE);
                missingBlankCat = _context.AMENITY.Where(a => a.SVC_TYPE == svcType && a.REQUIRE_ENTRY == true
                        && !a.AMENASSGN.Any(aa => aa.SVC_CODE == code && aa.CODE == a.CODE && string.IsNullOrEmpty(aa.SVC_CAT)))
                    .ToList();//rate plan bookmark
            }
            var required = _amenities.Where(a => a.SVC_TYPE == svcType && a.REQUIRE_ENTRY == true 
                && missingBlankCat.Any(r => r.CODE == a.CODE)
                && !_assigned.Any(aa => aa.CODE == a.CODE)).ToList();
            
            if (required.Any())
            {
                DialogResult select = MessageBox.Show("There are required amenities which are not currently assigned to this product.  Would you like to automatically assign them now?", Name, MessageBoxButtons.YesNo);

                if (select == DialogResult.Yes)
                {
                    foreach (var value in required)
                    {
                        //int sort = (int)value.SORT_ORDER;

                        //if ((from amenAssn in context.AMENASSGN where amenAssn.SVC_CODE == code && amenAssn.SVC_TYPE == ComboBoxEditSvcType.Text && amenAssn.CODE == value.CODE select amenAssn).Count() == 0)
                        AssignNode(code, cat, value);
                        LoadTreeListAssigned(displayText);//Immediately reloading the tree list after adding a node will remove the added node.
                        //Additionally, this ^ routine is called immediately after AssignRequired on the SearchButton click.  Rework logic so that we don't unassign required.
                    }
                }
            }//if (collection.Count() > 0)
            //    MessageBox.Show("This works");
           // AssignNode(parentNode, currentCode, itemCode, cat);
        }

        private void DisplayAdditionalAttributes()
        {
            _selectedRecord = (AMENASSGN)TreeListAssigned.GetFocusedRow();

            //string value = (treeList2.FocusedNode.GetValue(colAmenityCode)).ToString();
            //BindingSource.DataSource = _selectedRecord;
            //BindingSource.DataSource = from oa in context.AMENASSGN
            //                          where oa.SVC_CODE == code && oa.SVC_CAT == cat && oa.CODE == value
            //                          select oa;

            //gridControl1.DataSource = from c in context.AMENITY
            //                          join oa in context.AMENASSGN on c.CODE equals oa.CODE
            //                          where oa.SVC_CODE == code && oa.SVC_CAT == cat && oa.CODE == value
            //                          select oa;

            if (_selectedRecord == null || _selectedRecord.AMENITY == null) {
                PropertyGridControlAmenityData.Visible = false;
                return;
            }

            SetCustomDataFormat("rowItem1", _selectedRecord.AMENITY.ITEM_DESC1, _selectedRecord.AMENITY.ITEM_FORMAT1);
            SetCustomDataFormat("rowItem2", _selectedRecord.AMENITY.ITEM_DESC2, _selectedRecord.AMENITY.ITEM_FORMAT2);

            TreeListAssigned.Height -= 200;
            PropertyGridControlAmenityData.SelectedObject = _selectedRecord;
            PropertyGridControlAmenityData.Visible = true;
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

            //string val = (treeList2.FocusedNode.GetValue(colItemDesc1d)).ToString();
            //var case1 = _amenities.Where(c => c.ITEM_DESC1 == val).Select(c => c.ITEM_FORMAT1);
            //var case1 = (from c in _context.AMENITY where c.ITEM_DESC1 == val select new { c.ITEM_FORMAT1} );
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


        //private void CheckedChanged(object sender, System.EventArgs e)
        //{
        //    CheckEdit edit = sender as CheckEdit;
        //    if (edit.Checked)
        //    {
        //        gridView1.SetFocusedRowCellValue("ITEM1", true);

        //    }
        //}
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
            if (e.Column.FieldName == "ITEM_DESC1")
            {
                if (e.Node.Level == 0 || e.Node.HasChildren)
                {
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                }

                if (Convert.ToBoolean(e.Node.GetValue(colReqEntry)))
                    e.Appearance.ForeColor = Color.Red;

                if (!string.IsNullOrWhiteSpace(e.Node.GetValue(columnItem1).ToStringEmptyIfNull()))
                    e.Appearance.ForeColor = Color.Blue;
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
            //TreeList tree = sender as TreeList;
            //TreeListHitInfo hi = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition));
            if (TreeListUnassigned.FocusedNode != null)
            {
                //process hi.Node here
                // string parentNode = treeList1.FocusedNode.RootNode.GetDisplayText(colParentCodes);
                var row = (AMENITY)TreeListUnassigned.GetFocusedRow();
                string itemCode = SearchLookupEditCode.EditValue.ToString();
                string displayText = SearchLookupEditCode.Properties.GetDisplayText(itemCode);
                string cat = string.Empty;
                if (!string.IsNullOrWhiteSpace(GridLookupEditCategory.Text))
                    cat = GridLookupEditCategory.EditValue.ToString();
                //int sort = Convert.ToInt32(treeList1.FocusedNode.RootNode.GetDisplayText(colSORT_ORDER));
                AssignNode(itemCode, cat, row);
                LoadTreeListAssigned(displayText);
            }

            //string parentNode = treeList1.FocusedNode.RootNode.GetDisplayText(colCode);
            //string currentCode = treeList1.FocusedNode.GetDisplayText(colCode);
            //string itemCode = ImageComboBoxEditCode.EditValue.ToString();
            //string cat = string.Empty;
            //if (!string.IsNullOrWhiteSpace(ImageComboBoxEditCategory.Text))
            //    cat = ImageComboBoxEditCategory.EditValue.ToString();

            //if ((from amenRec in context.AMENASSGN where amenRec.CODE == parentNode && amenRec.SVC_CODE == itemCode && amenRec.SVC_TYPE == sVC_TYPEComboBoxEdit.Text && amenRec.SVC_CAT == cat select amenRec).Count() == 0)
            //{
            //    int? sort = Convert.ToInt32(treeList1.FocusedNode.RootNode.GetDisplayText(colSORT_ORDER));
            //    AddNode(parentNode, itemCode, cat, sort);
            //} 
            //int? order = Convert.ToInt32(treeList1.FocusedNode.GetDisplayText(colSORT_ORDER));
            //AddNode(currentCode, itemCode, cat, order);
            //loadTreelist(itemCode, cat);
          
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

        private void LoadTreeListAssigned(string displayText)
        {
            TreeListAssigned.ResetAutoFilterConditions();
            //treeList2.FilterConditions.Clear();

            //LoadAssigned(code, cat);

            //treeList2.DataSource = from c in context.AMENITY
            //                       from oa in context.AMENASSGN
            //                       where oa.SVC_CODE == code && oa.SVC_CAT == cat && c.CODE == oa.CODE && c.SVC_TYPE == ComboBoxEditSvcType.Text &&  oa.SVC_TYPE == ComboBoxEditSvcType.Text
            //                       select new { c.SVC_TYPE, oa.CODE, oa.SVC_CODE, c.PARENT_CODE, c.ITEM_DESC1, oa.SORT_ORDER, c.ITEM_FORMAT1, c.REQUIRE_ENTRY, oa.ITEM1 };

            TreeListAssigned.ParentFieldName = "AMENITY.PARENT_CODE";
            TreeListAssigned.KeyFieldName = "CODE";
            TreeListAssigned.BeginSort();
            TreeListAssigned.Columns["AMENITY.SORT_ORDER"].SortOrder = SortOrder.Ascending;
            TreeListAssigned.EndSort();
            TreeListAssigned.ExpandAll();
            colItemDesc1d.Caption = "Amenities for " + displayText;
            TreeListAssigned.MoveFirst();
        }

        private void LoadAssigned(string code, string cat)
        {
            _assigned = _context.AMENASSGN.Include(aa => aa.AMENITY)
                .Where(aa => aa.SVC_CODE == code && aa.SVC_TYPE == ComboBoxEditSvcType.Text && aa.SVC_CAT == cat).ToList();
            TreeListAssigned.DataSource = _assigned;
        }

        private void TreeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {//Leaving this event here even though it does nothing so that I have something to put a breakpoint on

        }

        private void BarButtonItemUses_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                    //Removed the grid this was connected to, so commenting out in case it's needed again

            //string code = treeList1.FocusedNode.GetDisplayText(colCode);
            //if(ComboBoxEditSvcType.Text == "HTL")
            //{
            //    gridControl2.DataSource = from amenAssignRec in context.AMENASSGN
            //                              from hotelRec in context.HOTEL
            //                              where amenAssignRec.SVC_TYPE == ComboBoxEditSvcType.Text && amenAssignRec.CODE == code && hotelRec.CODE == amenAssignRec.SVC_CODE
            //                              orderby hotelRec.CODE
            //                              select new { hotelRec.CODE, hotelRec.NAME, amenAssignRec.SVC_CAT };                                  
            //}
            //if (ComboBoxEditSvcType.Text == "OPT")
            //{
            //    gridControl2.DataSource = from amenAssignRec in context.AMENASSGN
            //                              from compRec in context.COMP
            //                              where amenAssignRec.SVC_TYPE == ComboBoxEditSvcType.Text && amenAssignRec.CODE == code && compRec.CODE == amenAssignRec.SVC_CODE
            //                              orderby compRec.CODE
            //                              select new { compRec.CODE, compRec.NAME, amenAssignRec.SVC_CAT };
            //}

            //if (ComboBoxEditSvcType.Text == "PKG")
            //{
            //    gridControl2.DataSource = from amenAssignRec in context.AMENASSGN
            //                              from packRec in context.PACK
            //                              where amenAssignRec.SVC_TYPE == ComboBoxEditSvcType.Text && amenAssignRec.CODE == code && packRec.CODE == amenAssignRec.SVC_CODE
            //                              orderby packRec.CODE
            //                              select new { packRec.CODE, packRec.NAME, amenAssignRec.SVC_CAT };
            //}

            //gridView2.MoveFirst();
            ////Point p = new System.Drawing.Point(CenterToScreen);
            ////popupControlContainer1.ShowPopup(CenterToScreen);
            //popupControlContainer1.Location = new System.Drawing.Point(329, 126);
            //popupControlContainer1.Show();
        }

        private void SearchLookupEditCode_EditValueChanged(object sender, EventArgs e)
        {
            string code = SearchLookupEditCode.EditValue.ToStringEmptyIfNull();
            BarButtonItemAssign.Enabled = !string.IsNullOrEmpty(SearchLookupEditCode.EditValue.ToStringEmptyIfNull());
            GridLookupEditCategory.Enabled = !string.IsNullOrEmpty(SearchLookupEditCode.EditValue.ToStringEmptyIfNull());

            //We want the categories which have amenities assigned at the top of the list
            _assignedCats = _context.AMENASSGN
                .Include(aa => aa.ROOMCOD).DefaultIfEmpty()
                .Where(c => c.SVC_CODE == code)
                .GroupBy(c => new { Cat = c.SVC_CAT, CatName = (c.ROOMCOD != null) ? c.ROOMCOD.DESC : ""})
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
        }

        private void GridLookupEditItemCategory_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {
            SetItemCategoryLookup(e.DisplayValue.ToString());
            e.Handled = true;
        }

        private void SetItemCategoryLookup(object itemCat)
        {
            string cat = itemCat.ToStringEmptyIfNull();

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
            if (TreeListAssigned.FocusedNode != null) {
                var amenity = (AMENASSGN)TreeListAssigned.GetFocusedRow();
                    if (amenity != null && (amenity.EntityState & System.Data.Entity.EntityState.Deleted) != System.Data.Entity.EntityState.Deleted) {
                        _context.AMENASSGN.DeleteObject(amenity);
                    }
                _assigned.Remove(amenity);
                TreeListAssigned.RefreshDataSource();
            }
            else {
                MessageBox.Show("Please select a node to unassign.");
            }

            //AMENASSGN rec = (from amenRec in context.AMENASSGN where amenRec.SVC_CODE == itemCode && amenRec.CODE == code && amenRec.SVC_CAT == cat && amenRec.SVC_TYPE == ComboBoxEditSvcType.Text select amenRec).FirstOrDefault();
            //context.AMENASSGN.DeleteObject(rec);
            //context.SaveChanges();
        }

        private void BarButtonItemAssign_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TreeListUnassigned.FocusedNode != null) {
                //process hi.Node here
                var amenity = (AMENITY)TreeListUnassigned.GetFocusedRow();
                string itemCode = SearchLookupEditCode.EditValue.ToString();
                string cat = GridLookupEditCategory.EditValue.ToStringEmptyIfNull();

                AssignNode(itemCode, cat, amenity);
            }
            else
                MessageBox.Show("Please select a node to assign.");
        }

        private void AssignNode(string itemCode, string cat, AMENITY amenity)
        {
            //var parentCode = _amenities.Where(a => a.CODE == currentCode).Select(a => a.PARENT_CODE).FirstOrDefault();
            //var parentNode = (from amen in context.AMENITY where amen.CODE == currentCode select new { amen.PARENT_CODE, amen.SORT_ORDER }).FirstOrDefault();
            //int sorts = (int)parentNode.SORT_ORDER;


            //Parent node needs to be assigned when a child node is assigned
            //Check if parent node is already assigned
            var parent = _amenities.FirstOrDefault(r => r.CODE == amenity.PARENT_CODE);
            if (parent != null) {
                AssignNode(itemCode, cat, parent);
            }
            AMENASSGN rec = new AMENASSGN {
                CODE = amenity.CODE,
                SVC_CODE = itemCode,
                SVC_TYPE = ComboBoxEditSvcType.Text,
                SVC_CAT = cat,
                SVC_ROOM = string.Empty,
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
            if (TreeListAssigned.FocusedNode != null) {
                //LoadTreeListAssigned(itemCode, cat, displayText);
                var amenity = (AMENASSGN)TreeListAssigned.GetFocusedRow();
                //if (!amenity.IsNew()) {
                if (amenity != null && (amenity.EntityState & System.Data.Entity.EntityState.Deleted) != System.Data.Entity.EntityState.Deleted) {
                    _context.AMENASSGN.DeleteObject(amenity);
                }
                //}
                _assigned.Remove(amenity);
                TreeListAssigned.RefreshDataSource();
            }
            else {
                MessageBox.Show("Please select a node to unassign.");
            }
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

        private void SimpleButtonAssign2_Click(object sender, EventArgs e)
        {
            if (TreeListUnassigned.FocusedNode != null) {
                var amenity = (AMENITY)TreeListUnassigned.GetFocusedRow();
                string itemCode = SearchLookupEditCode.EditValue.ToString();
                string cat = GridLookupEditCategory.EditValue.ToStringEmptyIfNull();

                AssignNode(itemCode, cat, amenity);
            }
            else
                MessageBox.Show("Please select a node to assign.");
        }
    }
}