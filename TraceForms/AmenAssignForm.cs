using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraEditors;
using FlexModel;
using DevExpress.XtraEditors.Controls;
using System.Runtime.InteropServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using FlexModel;
using DevExpress.XtraEditors.Controls;
using System.Linq;
using DevExpress.XtraGrid.Columns;
using System.Runtime.InteropServices;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraEditors.Repository;
using System.Data;
using System.Drawing;
using System.Text;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
namespace TraceForms
{
     
    public partial class AmenAssignForm : DevExpress.XtraEditors.XtraForm
    {
        public ImageComboBoxItemCollection hotelVals;
        public ImageComboBoxItemCollection pkgVals;
        public ImageComboBoxItemCollection compVals;
        public ImageComboBoxItemCollection airVals;
        public ImageComboBoxItemCollection cruVals;
        public ImageComboBoxItemCollection carVals;
        public bool modified = false;
        public FlextourEntities context;
        public Timer rowStatusSave;
        public List<string> modifiedRecs;
        public string modifiedSvcCode;
        public AmenAssignForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);
            //treeList2.ParentFieldName = "PARENT_CODE";
            //treeList2.KeyFieldName = "CODE";
            //treeList1.KeyFieldName = "CODE";
            //treeList1.ParentFieldName = "PARENT_CODE";
            LoadLookups();
            modifiedRecs = new System.Collections.Generic.List<string>();
            
        }
        private void LoadLookups()
        {
            hotelVals = new ImageComboBoxItemCollection(ImageComboBoxEditCode.Properties);
            compVals = new ImageComboBoxItemCollection(ImageComboBoxEditCode.Properties);
            pkgVals = new ImageComboBoxItemCollection(ImageComboBoxEditCode.Properties);
            airVals = new ImageComboBoxItemCollection(ImageComboBoxEditCode.Properties);
            carVals = new ImageComboBoxItemCollection(ImageComboBoxEditCode.Properties);
            cruVals = new ImageComboBoxItemCollection(ImageComboBoxEditCode.Properties);
            //lockGrid(true);
            var cats = from catRec in context.ROOMCOD orderby catRec.CODE ascending select new { catRec.CODE, catRec.DESC };
            var comps = from compRec in context.COMP orderby compRec.CODE ascending select new { compRec.CODE, compRec.NAME };
            var hotels = from hotRec in context.HOTEL orderby hotRec.CODE ascending select new { hotRec.CODE, hotRec.NAME };
            var pkgs = from pkgRec in context.PACK orderby pkgRec.CODE ascending select new { pkgRec.CODE, pkgRec.NAME };
            var airs = from airRec in context.AIR orderby airRec.CODE ascending select new { airRec.CODE, airRec.NAME };
            var cars = from carRec in context.CARINFO orderby carRec.CODE ascending select new { carRec.CODE, carRec.NAME };
            var crus = from cruRec in context.CRU orderby cruRec.CODE ascending select new { cruRec.CODE, cruRec.NAME };
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxEditCategory.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCode.Properties.Items.Add(loadBlank);
         
            foreach (var result in cats)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.DESC.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCategory.Properties.Items.Add(load);
            }
            foreach (var result in comps)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                //ImageComboBoxEditCode.Properties.Items.Add(load);
                compVals.Add(load);
            }
            foreach (var result in hotels)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                //ImageComboBoxEditAgency.Properties.Items.Add(load);
                hotelVals.Add(load);
            }

            foreach (var result in pkgs)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                //ImageComboBoxEditAgency.Properties.Items.Add(load);
                pkgVals.Add(load);
            }

            foreach (var result in cars)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                //ImageComboBoxEditAgency.Properties.Items.Add(load);
                carVals.Add(load);
            }

            foreach (var result in crus)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                //ImageComboBoxEditAgency.Properties.Items.Add(load);
                cruVals.Add(load);
            }

            foreach (var result in airs)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                //ImageComboBoxEditAgency.Properties.Items.Add(load);
                airVals.Add(load);
            }


        }
        private void sVC_TYPEComboBoxEdit_TextChanged(object sender, EventArgs e)
        {
            ImageComboBoxEditCode.Properties.Items.Clear();
           
            if (sVC_TYPEComboBoxEdit.Text == "HTL")
            {

                treeList1.FilterConditions.Clear();
                AmenityBindingSource.DataSource = from c in context.AMENITY where c.SVC_TYPE == "HTL" select c;
                colITEM_DESC1.Caption = "HOTEL AMENITIES";
                treeList1.BeginSort();
                treeList1.Columns["SORT_ORDER"].SortOrder = SortOrder.Ascending;
                treeList1.EndSort();
                treeList1.ExpandAll();
                ImageComboBoxEditCode.Properties.Items.AddRange(hotelVals);
                treeList1.MoveFirst();

            }
            if (sVC_TYPEComboBoxEdit.Text == "PKG")
            {
                treeList1.FilterConditions.Clear();
                AmenityBindingSource.DataSource = from c in context.AMENITY where c.SVC_TYPE == "PKG" select c;
                colITEM_DESC1.Caption = "PACKAGE AMENITIES";
                treeList1.BeginSort();
                treeList1.Columns["SORT_ORDER"].SortOrder = SortOrder.Ascending;
                treeList1.EndSort();
                treeList1.ExpandAll();
                ImageComboBoxEditCode.Properties.Items.AddRange(pkgVals);
                treeList1.MoveFirst();
            }
            if (sVC_TYPEComboBoxEdit.Text == "CAR")
            {
                treeList1.FilterConditions.Clear();
                AmenityBindingSource.DataSource = from c in context.AMENITY where c.SVC_TYPE == "CAR" select c;
                colITEM_DESC1.Caption = "CAR AMENITIES";
                treeList1.BeginSort();
                treeList1.Columns["SORT_ORDER"].SortOrder = SortOrder.Ascending;
                treeList1.EndSort();
                treeList1.ExpandAll();
                ImageComboBoxEditCode.Properties.Items.AddRange(carVals);
                treeList1.MoveFirst();
            }
            if (sVC_TYPEComboBoxEdit.Text == "OPT")
            {
                treeList1.FilterConditions.Clear();
                AmenityBindingSource.DataSource = from c in context.AMENITY where c.SVC_TYPE == "OPT" select c;
                colITEM_DESC1.Caption = "OPTIONAL SERVICE AMENITIES";
                treeList1.BeginSort();
                treeList1.Columns["SORT_ORDER"].SortOrder = SortOrder.Ascending;
                treeList1.EndSort();
                treeList1.ExpandAll();
                ImageComboBoxEditCode.Properties.Items.AddRange(compVals);
                treeList1.MoveFirst();
            }
            if (sVC_TYPEComboBoxEdit.Text == "CRU")
            {
                treeList1.FilterConditions.Clear();
                AmenityBindingSource.DataSource = from c in context.AMENITY where c.SVC_TYPE == "CRU" select c;
                colITEM_DESC1.Caption = "CRUISE AMENITIES";
                treeList1.BeginSort();
                treeList1.Columns["SORT_ORDER"].SortOrder = SortOrder.Ascending;
                treeList1.EndSort();
                treeList1.ExpandAll();
                ImageComboBoxEditCode.Properties.Items.AddRange(cruVals);
                treeList1.MoveFirst();
            }
            if (sVC_TYPEComboBoxEdit.Text == "AIR")
            {
                treeList1.FilterConditions.Clear();
                AmenityBindingSource.DataSource = from c in context.AMENITY where c.SVC_TYPE == "AIR" select c;
                colITEM_DESC1.Caption = "AIR AMENITIES";
                treeList1.BeginSort();
                treeList1.Columns["SORT_ORDER"].SortOrder = SortOrder.Ascending;
                treeList1.EndSort();
                treeList1.ExpandAll();
                ImageComboBoxEditCode.Properties.Items.AddRange(airVals);
                treeList1.MoveFirst();
            }
        }

        private void AmenAssignForm_Load(object sender, EventArgs e)
        {
            //AmenityBindingSource.DataSource = context.AMENITY;
            //AmenAssgnBindingSource.DataSource = context.AMENASSGN;
           
        }

       

      

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (modified)
            {
                DialogResult select = DevExpress.XtraEditors.XtraMessageBox.Show("Do you want to confirm these changes?", Name, MessageBoxButtons.YesNoCancel);
               
                if (select == DialogResult.Yes)////keep changes
                {
                    modified = false;
                    modifiedSvcCode = string.Empty;
                    modifiedRecs.Clear();
                }
                else if (select == DialogResult.No)
                {
                    modified = false;
                    foreach (string val in modifiedRecs)
                    {
                        var unwanted = from amen in context.AMENASSGN where amen.SVC_CODE == modifiedSvcCode && amen.CODE == val select amen;
                        foreach (AMENASSGN record in unwanted)
                            context.AMENASSGN.DeleteObject(record);
                    }
                    context.SaveChanges();
                    modifiedSvcCode = string.Empty;
                    modifiedRecs.Clear();
                }               
            }
            string code = string.Empty;
            if(!string.IsNullOrWhiteSpace(ImageComboBoxEditCode.Text))
                code = ImageComboBoxEditCode.EditValue.ToString();
            string cat = string.Empty;
            if (!string.IsNullOrWhiteSpace(ImageComboBoxEditCategory.Text))
                cat = ImageComboBoxEditCategory.EditValue.ToString();

            checkRequired(code, cat);
            loadTreelist(code, cat);
        }

        private void checkRequired(string code, string cat)
        {
            bool missing = false;
            var collection = from amenRec in context.AMENITY
                             where amenRec.SVC_TYPE == sVC_TYPEComboBoxEdit.Text && amenRec.REQUIRE_ENTRY == true 
                             select new { amenRec.PARENT_CODE, amenRec.CODE, amenRec.SORT_ORDER };
           
            foreach (var value in collection)
            {
                if ((from amenAssn in context.AMENASSGN where amenAssn.SVC_CODE == code && amenAssn.SVC_TYPE == sVC_TYPEComboBoxEdit.Text && amenAssn.CODE == value.CODE select amenAssn).Count() == 0)
                    missing = true;
            }

            if (missing)
            {
                DialogResult select = MessageBox.Show("There are required amenities which are not currently to this service.  Would you like to automatically assign them now ?", Name, MessageBoxButtons.YesNo);

                if (select == DialogResult.Yes)
                {
                    foreach (var value in collection)
                    {
                        int sort = (int)value.SORT_ORDER;
                        if ((from amenAssn in context.AMENASSGN where amenAssn.SVC_CODE == code && amenAssn.SVC_TYPE == sVC_TYPEComboBoxEdit.Text && amenAssn.CODE == value.CODE select amenAssn).Count() == 0)
                        {
                            AssignNode(value.CODE, code, cat, sort);
                            loadTreelist(code, cat);
                        }
                    }
                }
            }//if (collection.Count() > 0)
            //    MessageBox.Show("This works");
           // AssignNode(parentNode, currentCode, itemCode, cat);
        }
        private void gridLoad()
        {
            string code = string.Empty;
            if (!string.IsNullOrWhiteSpace(ImageComboBoxEditCode.Text))
                code = ImageComboBoxEditCode.EditValue.ToString();
            string cat = string.Empty;
            if (!string.IsNullOrWhiteSpace(ImageComboBoxEditCategory.Text))
                cat = ImageComboBoxEditCategory.EditValue.ToString();
            string value = (treeList2.FocusedNode.GetValue(colAmenityCode)).ToString();
            AmenAssgnBindingSource.DataSource = from oa in context.AMENASSGN
                                      where oa.SVC_CODE == code && oa.SVC_CAT == cat && oa.CODE == value
                                      select oa;
            
            //gridControl1.DataSource = from c in context.AMENITY
            //                          join oa in context.AMENASSGN on c.CODE equals oa.CODE
            //                          where oa.SVC_CODE == code && oa.SVC_CAT == cat && oa.CODE == value
            //                          select oa;

            string val = (treeList2.FocusedNode.GetValue(colItemDesc1d)).ToString();
            var case1 = (from c in context.AMENITY where c.ITEM_DESC1 == val select new { c.ITEM_FORMAT1} );
            foreach(var val1 in case1)
            {
                switch (val1.ITEM_FORMAT1)
                {
                    case "Yes/No":
                        gridControl1.Visible = true;
                        RepositoryItemCheckEdit check = new RepositoryItemCheckEdit();
                        check.ValueUnchecked = "False";
                        check.ValueChecked = "True";
                        check.ValueGrayed = string.Empty;                        
                        gridControl1.RepositoryItems.Add(check);
                        colITEM1.ColumnEdit = check;
                        colITEM1.Caption = val;
                        break;
                    case "Date":
                        gridControl1.Visible = true;
                        RepositoryItemDateEdit date = new RepositoryItemDateEdit();
                        gridControl1.RepositoryItems.Add(date);
                        colITEM1.ColumnEdit = date;
                        colITEM1.Caption = val;
                        break;
                    case "Time":
                        gridControl1.Visible = true;
                        RepositoryItemTimeEdit time = new RepositoryItemTimeEdit();
                        gridControl1.RepositoryItems.Add(time);
                        colITEM1.ColumnEdit = time;
                        colITEM1.Caption = val;
                        break;
                    case "Text":
                        gridControl1.Visible = true;
                        RepositoryItemTextEdit text = new RepositoryItemTextEdit();
                        gridControl1.RepositoryItems.Add(text);
                        colITEM1.ColumnEdit = text;
                        colITEM1.Caption = val;
                        break;
                    case "Currency":
                        gridControl1.Visible = true;
                        RepositoryItemSpinEdit spin = new RepositoryItemSpinEdit();
                        gridControl1.RepositoryItems.Add(spin);
                        colITEM1.ColumnEdit = spin;
                        colITEM1.Caption = val;
                        break;
                    case "Integer":
                        gridControl1.Visible = true;
                        RepositoryItemTextEdit integer = new RepositoryItemTextEdit();
                        gridControl1.RepositoryItems.Add(integer);
                        colITEM1.ColumnEdit = integer;
                        colITEM1.Caption = val;
                        break;
                    case "Decimal":
                        gridControl1.Visible = true;
                        RepositoryItemTextEdit decimal1 = new RepositoryItemTextEdit();
                        gridControl1.RepositoryItems.Add(decimal1);
                        colITEM1.ColumnEdit = decimal1;
                        colITEM1.Caption = val;
                        break;               
                    case "":
                        gridControl1.Visible = false;
                        break;
                }

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
        private void treeList2_AfterFocusNode(object sender, NodeEventArgs e)
        {
            gridLoad();
        }

        private void AmenAssignForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (modified)
            {
                DialogResult select = DevExpress.XtraEditors.XtraMessageBox.Show("Do you want to confirm these changes?", Name, MessageBoxButtons.YesNoCancel);

                if (select == DialogResult.Yes)////keep changes
                {
                    e.Cancel = false;
                    this.Dispose();
                }
                else if (select == DialogResult.No)
                {
                    foreach (string val in modifiedRecs)
                    {
                        var unwanted = from amen in context.AMENASSGN where amen.SVC_CODE == modifiedSvcCode && amen.CODE == val select amen;
                        foreach (AMENASSGN record in unwanted)
                            context.AMENASSGN.DeleteObject(record);
                    }
                    context.SaveChanges();
                    modified = false;
                    modifiedSvcCode = string.Empty;
                    modifiedRecs.Clear();
                    e.Cancel = false;
                    this.Dispose();
                }
            }
            else
            {
                e.Cancel = false;
                this.Dispose();
            }
             
             



            //////////////////////////////////
            //////////////////////////////////////
            ///////////////////////////////
            if (modified)
            {
                DialogResult select = DevExpress.XtraEditors.XtraMessageBox.Show("There are unsaved changes. Are you sure want to exit?", Name, MessageBoxButtons.YesNo);
                if (select == DialogResult.Yes)
                {
                    e.Cancel = false;
                    this.Dispose();
                }
                else if (select == DialogResult.No)
                    e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                this.Dispose();
            }
        }

        private void treeList2_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "ITEM_DESC1")
            {
                if (e.Node.Level == 0 || e.Node.HasChildren)
                {
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                }

                if (Convert.ToBoolean(e.Node.GetValue(colReqEntry)))
                    e.Appearance.ForeColor = Color.Red;

                if (!string.IsNullOrWhiteSpace(Convert.ToString(e.Node.GetValue(columnItem1))))
                    e.Appearance.ForeColor = Color.Blue;
            }
        }

        private void treeList1_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
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

        private void treeList1_DoubleClick(object sender, System.EventArgs e)
        {
            TreeList tree = sender as TreeList;
            TreeListHitInfo hi = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition));
            if (treeList1.FocusedNode != null)
            {
                //process hi.Node here
               // string parentNode = treeList1.FocusedNode.RootNode.GetDisplayText(colParentCodes);
                string currentCode = treeList1.FocusedNode.GetDisplayText(colCode);
                string itemCode = ImageComboBoxEditCode.EditValue.ToString();
                string cat = string.Empty;
                if (!string.IsNullOrWhiteSpace(ImageComboBoxEditCategory.Text))
                    cat = ImageComboBoxEditCategory.EditValue.ToString();
                int sort = Convert.ToInt32(treeList1.FocusedNode.RootNode.GetDisplayText(colSORT_ORDER));
                modified = true;
                AssignNode( currentCode, itemCode, cat, sort);
                loadTreelist(itemCode, cat);
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

        private void AddNode(string amenCode, string item, string category, int? sortOrder)
        {
            AMENASSGN rec = new FlexModel.AMENASSGN();
            rec.CODE = amenCode;
            rec.SVC_CODE = item;
            rec.SVC_TYPE = sVC_TYPEComboBoxEdit.Text;
            rec.SVC_CAT = category;
            rec.SVC_ROOM = string.Empty;
            rec.SORT_ORDER = sortOrder;
            rec.ITEM2 = string.Empty;
            rec.ITEM1 = string.Empty;
            if ((from amenRec in context.AMENASSGN where amenRec.CODE == rec.CODE && amenRec.SVC_CODE == rec.SVC_CODE && amenRec.SVC_TYPE == rec.SVC_TYPE && amenRec.SVC_CAT == rec.SVC_CAT && amenRec.SVC_ROOM == rec.SVC_ROOM select amenRec).Count() == 0)
                context.AMENASSGN.AddObject(rec);
            else
            {
                MessageBox.Show("You are attempting to add a an amenity that has already been added.");
                return;
            }
            context.SaveChanges();
            

        }

        private void loadTreelist(string code, string cat)
        {
            treeList2.FilterConditions.Clear();
            treeList2.DataSource = from c in context.AMENITY
                                   from oa in context.AMENASSGN
                                   where oa.SVC_CODE == code && oa.SVC_CAT == cat && c.CODE == oa.CODE && c.SVC_TYPE == sVC_TYPEComboBoxEdit.Text &&  oa.SVC_TYPE == sVC_TYPEComboBoxEdit.Text
                                   select new { c.SVC_TYPE, oa.CODE, oa.SVC_CODE, c.PARENT_CODE, c.ITEM_DESC1, oa.SORT_ORDER, c.ITEM_FORMAT1, c.REQUIRE_ENTRY, oa.ITEM1 };

            treeList2.ParentFieldName = "PARENT_CODE";
            treeList2.KeyFieldName = "CODE";
            treeList2.BeginSort();
            treeList2.Columns["SORT_ORDER"].SortOrder = SortOrder.Ascending;
            treeList2.EndSort();
            treeList2.ExpandAll();
            colItemDesc1d.Caption = code + " AMENITIES";
            treeList2.MoveFirst();
        }

        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {

        }

        private void viewMatchingToolStripMenuItem_Click(object sender, System.EventArgs e)
        {   
            string code = treeList1.FocusedNode.GetDisplayText(colCode);
            if(sVC_TYPEComboBoxEdit.Text == "HTL")
            {
                gridControl2.DataSource = from amenAssignRec in context.AMENASSGN
                                          from hotelRec in context.HOTEL
                                          where amenAssignRec.SVC_TYPE == sVC_TYPEComboBoxEdit.Text && amenAssignRec.CODE == code && hotelRec.CODE == amenAssignRec.SVC_CODE
                                          orderby hotelRec.CODE
                                          select new { hotelRec.CODE, hotelRec.NAME, amenAssignRec.SVC_CAT };
                                    
            }
            if (sVC_TYPEComboBoxEdit.Text == "OPT")
            {
                gridControl2.DataSource = from amenAssignRec in context.AMENASSGN
                                          from compRec in context.COMP
                                          where amenAssignRec.SVC_TYPE == sVC_TYPEComboBoxEdit.Text && amenAssignRec.CODE == code && compRec.CODE == amenAssignRec.SVC_CODE
                                          orderby compRec.CODE
                                          select new { compRec.CODE, compRec.NAME, amenAssignRec.SVC_CAT };
            }

            if (sVC_TYPEComboBoxEdit.Text == "PKG")
            {
                gridControl2.DataSource = from amenAssignRec in context.AMENASSGN
                                          from packRec in context.PACK
                                          where amenAssignRec.SVC_TYPE == sVC_TYPEComboBoxEdit.Text && amenAssignRec.CODE == code && packRec.CODE == amenAssignRec.SVC_CODE
                                          orderby packRec.CODE
                                          select new { packRec.CODE, packRec.NAME, amenAssignRec.SVC_CAT };
            }
            if (sVC_TYPEComboBoxEdit.Text == "CAR")
            {
                gridControl2.DataSource = from amenAssignRec in context.AMENASSGN
                                          from carRec in context.CARINFO
                                          where amenAssignRec.SVC_TYPE == sVC_TYPEComboBoxEdit.Text && amenAssignRec.CODE == code && carRec.CODE == amenAssignRec.SVC_CODE
                                          orderby carRec.CODE
                                          select new { carRec.CODE, carRec.NAME, amenAssignRec.SVC_CAT };
            }
            if (sVC_TYPEComboBoxEdit.Text == "AIR")
            {
                gridControl2.DataSource = from amenAssignRec in context.AMENASSGN
                                          from airRec in context.AIR
                                          where amenAssignRec.SVC_TYPE == sVC_TYPEComboBoxEdit.Text && amenAssignRec.CODE == code && airRec.CODE == amenAssignRec.SVC_CODE
                                          orderby airRec.CODE
                                          select new { airRec.CODE, airRec.NAME, amenAssignRec.SVC_CAT };
            }
            if (sVC_TYPEComboBoxEdit.Text == "CRU")
            {
                gridControl2.DataSource = from amenAssignRec in context.AMENASSGN
                                          from cruRec in context.CRU
                                          where amenAssignRec.SVC_TYPE == sVC_TYPEComboBoxEdit.Text && amenAssignRec.CODE == code && cruRec.CODE == amenAssignRec.SVC_CODE
                                          orderby cruRec.CODE
                                          select new { cruRec.CODE, cruRec.NAME, amenAssignRec.SVC_CAT };
            }

            gridView2.MoveFirst();
            //Point p = new System.Drawing.Point(CenterToScreen);
            //popupControlContainer1.ShowPopup(CenterToScreen);
            popupControlContainer1.Location = new System.Drawing.Point(329, 126);
            popupControlContainer1.Show();
        }

        private bool checkForms()
        {
            if (!modified)
                return true;
            bool ok1 = validCheck.checkAll(Controls, errorProvider1, ((AMENASSGN)AmenAssgnBindingSource.Current).checkAll, AmenAssgnBindingSource);
            if (ok1)
                return validCheck.saveRec(ref modified, true, ref modified, context, AmenAssgnBindingSource, this.Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref modified, context, AmenAssgnBindingSource, this.Name, errorProvider1, Cursor);
                return false;
            }
        }


        private void aMENASSGNBindingNavigatorSaveItem_Click(object sender, System.EventArgs e)
        {

            //if (checkForms())
            //{
            //    modified = false;
            //    panelControlStatus.Visible = true;
            //    LabelStatus.Text = "Record Saved";
            //    rowStatusSave = new Timer();
            //    rowStatusSave.Interval = 3000;
            //    rowStatusSave.Start();
            //    rowStatusSave.Tick += TimedEventSave;
            //}
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            modified = true;
        }


        private void TimedEventSave(object sender, EventArgs e)
        {
            if (sender == rowStatusSave)
                panelControlStatus.Visible = false;
            //LabelStatus.Text = "";
            rowStatusSave.Stop();
        }

        private void DelRow_Click(object sender, System.EventArgs e)
        {
            string code = treeList2.FocusedNode.GetDisplayText(colCode);
            string itemCode = ImageComboBoxEditCode.EditValue.ToString();
            string cat = string.Empty;
            if (!string.IsNullOrWhiteSpace(ImageComboBoxEditCategory.Text))
                cat = ImageComboBoxEditCategory.EditValue.ToString();

            AMENASSGN rec = (from amenRec in context.AMENASSGN where amenRec.SVC_CODE == itemCode && amenRec.CODE == code && amenRec.SVC_CAT == cat && amenRec.SVC_TYPE == sVC_TYPEComboBoxEdit.Text select amenRec).FirstOrDefault();
            context.AMENASSGN.DeleteObject(rec);
            context.SaveChanges();
            loadTreelist(itemCode, cat);
        }

        private void OkButton_Click(object sender, System.EventArgs e)
        {
            if (modified)
            {
                DialogResult select = DevExpress.XtraEditors.XtraMessageBox.Show("Do you want to confirm these changes?", Name, MessageBoxButtons.YesNoCancel);

                if (select == DialogResult.Yes)////keep changes
                {
                    modified = false;
                    modifiedSvcCode = string.Empty;
                    modifiedRecs.Clear();
                }
                else if (select == DialogResult.No)
                {
                    foreach (string val in modifiedRecs)
                    {
                        var unwanted = from amen in context.AMENASSGN where amen.SVC_CODE == modifiedSvcCode && amen.CODE == val select amen;
                        foreach (AMENASSGN record in unwanted)
                            context.AMENASSGN.DeleteObject(record);
                    }
                    context.SaveChanges();
                    modified = false;
                    modifiedSvcCode = string.Empty;
                    modifiedRecs.Clear();
                }
            }
            string code = string.Empty;
            code = gridView2.GetFocusedRowCellDisplayText("CODE");
           
            string cat = string.Empty;
            cat = gridView2.GetFocusedRowCellDisplayText("SVC_CAT");

            popupControlContainer1.Hide();
            ImageComboBoxEditCode.EditValue = code;
            loadTreelist(code, cat);
        }

        private void CancelButton_Click(object sender, System.EventArgs e)
        {
            popupControlContainer1.Hide();

        }

        private void treeList1_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //TreeList tree = sender as TreeList;
            //TreeListHitInfo hi = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition));
            //if (treeList1.FocusedNode != null)
            //{
            //    //process hi.Node here
            //    string parentNode = treeList1.FocusedNode.RootNode.GetDisplayText(colCode);
            //    string currentCode = treeList1.FocusedNode.GetDisplayText(colCode);
            //    string itemCode = ImageComboBoxEditCode.EditValue.ToString();
            //    string cat = string.Empty;
            //    if (!string.IsNullOrWhiteSpace(ImageComboBoxEditCategory.Text))
            //        cat = ImageComboBoxEditCategory.EditValue.ToString();

            //    if ((from amenRec in context.AMENASSGN where amenRec.CODE == parentNode && amenRec.SVC_CODE == itemCode && amenRec.SVC_TYPE == sVC_TYPEComboBoxEdit.Text && amenRec.SVC_CAT == cat select amenRec).Count() == 0)
            //    {
            //        int? sort = Convert.ToInt32(treeList1.FocusedNode.RootNode.GetDisplayText(colSORT_ORDER));
            //        AddNode(parentNode, itemCode, cat, sort);
            //    }
            //    int? order = Convert.ToInt32(treeList1.FocusedNode.GetDisplayText(colSORT_ORDER));
            //    AddNode(currentCode, itemCode, cat, order);
            //    loadTreelist(itemCode, cat);

            //}
        }

        private void AssignButton_Click(object sender, System.EventArgs e)
        {
            if (treeList1.FocusedNode != null)
            {
                //process hi.Node here
                string parentNode = treeList1.FocusedNode.RootNode.GetDisplayText(colCode);
                string currentCode = treeList1.FocusedNode.GetDisplayText(colCode);
                string itemCode = ImageComboBoxEditCode.EditValue.ToString();
                string cat = string.Empty;
                if (!string.IsNullOrWhiteSpace(ImageComboBoxEditCategory.Text))
                    cat = ImageComboBoxEditCategory.EditValue.ToString();
                int sort = Convert.ToInt32(treeList1.FocusedNode.RootNode.GetDisplayText(colSORT_ORDER));
                modified = true;
                AssignNode(currentCode, itemCode, cat, sort);
                loadTreelist(itemCode, cat);
            }
            else
                MessageBox.Show("Please select a node to assign.");
        }

        private void AssignNode(string currentCode, string itemCode, string cat, int sort)
        {
           
            
            var parentNode = (from amen in context.AMENITY where amen.CODE == currentCode select new { amen.PARENT_CODE, amen.SORT_ORDER }).FirstOrDefault();
            int sorts = (int)parentNode.SORT_ORDER;

            if ((from amenRec in context.AMENASSGN where amenRec.CODE == parentNode.PARENT_CODE && amenRec.SVC_CODE == itemCode && amenRec.SVC_TYPE == sVC_TYPEComboBoxEdit.Text && amenRec.SVC_CAT == cat select amenRec).Count() == 0)
            {
                //int? sort = Convert.ToInt32(treeList1.FocusedNode.RootNode.GetDisplayText(colSORT_ORDER));
                // string newParent = (from amen in context.AMENITY where amen.CODE == parentNode select new { amen.PARENT_CODE }).First().ToString();
                //(string amenCode, string item, string category, int? sortOrder)
                //AddNode(currentCode, itemCode, cat, sort);
                AssignNode(parentNode.PARENT_CODE, itemCode, cat, sorts);
               

            }
            
                AMENASSGN rec = new FlexModel.AMENASSGN();
                rec.CODE = currentCode;
                rec.SVC_CODE = itemCode;
                rec.SVC_TYPE = sVC_TYPEComboBoxEdit.Text;
                rec.SVC_CAT = cat;
                rec.SVC_ROOM = string.Empty;
                rec.SORT_ORDER = sort;
                rec.ITEM2 = string.Empty;
                rec.ITEM1 = string.Empty;
                if ((from amenRec in context.AMENASSGN where amenRec.CODE == rec.CODE && amenRec.SVC_CODE == rec.SVC_CODE && amenRec.SVC_TYPE == rec.SVC_TYPE && amenRec.SVC_CAT == rec.SVC_CAT && amenRec.SVC_ROOM == rec.SVC_ROOM select amenRec).Count() == 0)
                {
                    context.AMENASSGN.AddObject(rec);
                    modifiedRecs.Add(rec.CODE);
                    modifiedSvcCode = rec.SVC_CODE;
                }
                else
                {
                    // MessageBox.Show("You are attempting to add a an amenity that has already been added.");
                    // return;
                }
                context.SaveChanges();

            
               // int? order = Convert.ToInt32(treeList1.FocusedNode.GetDisplayText(colSORT_ORDER));
                
                //return true;
               //return AssignNode(currentCode, itemCode, cat, sort);
            
            
            

        }
    }
}