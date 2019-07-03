using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using FlexModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Security.Permissions;
using Microsoft.Win32;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.Management;
using System.IO;
using FlexModel;
using System.Xml;
using System.Linq;
using DevExpress.XtraGrid.Columns;
using System.Runtime.InteropServices;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraEditors.Repository;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraGrid;



using System.Xml;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FlexModel;
using System.Linq;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System.Collections;
using System.Runtime.InteropServices;
namespace TraceForms
{

    public partial class AmenityForm : DevExpress.XtraEditors.XtraForm
    {
        public string imagesRoot;
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        public FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public AmenityForm(FlexCore.CoreSys _sys)
        {
            InitializeComponent();

            Connection.EFConnectionString = _sys.Settings.EFConnectionString;
            context = new FlextourEntities(_sys.Settings.EFConnectionString);
            _sys.Connect("");
            imagesRoot = _sys.Settings.ImagesRoot;
            _sys.Disconnect();
            modified = false;
            newRec = false;
            
            setreadonly(true);
            enableNavigator(false);
            sVCComboBoxEdit.Focus();
        }

        void setreadonly(bool valid)
        {
            TextEditCode.Properties.ReadOnly = valid;
        }

        void setItems(bool valid)
        {
            TextEditItem_Desc1.Properties.ReadOnly = valid;
            TextEditItem_Desc2.Properties.ReadOnly = valid;
            ComboBoxEditItem_Format1.Properties.ReadOnly = valid;
            ComboBoxEditItem_Format2.Properties.ReadOnly = valid;
            CheckEditRequire_Entry.Properties.ReadOnly = valid;
            CheckEditSearchable.Properties.ReadOnly = valid;
            CheckEditSupplier_Entry.Properties.ReadOnly = valid;

        }

        private void AmenityForm_Load(object sender, EventArgs e)
        {
            //sVC_TYPEComboBoxEdit.Focus();
            //treeList1.KeyFieldName = "CODE";
            //treeList1.ParentFieldName = "PARENT_CODE";
            sVCComboBoxEdit.Focus();
        }

        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        private void sVC_TYPEComboBoxEdit_TextChanged(object sender, EventArgs e)
        {
            if (newRec == true)
                return;

            if (sVCComboBoxEdit.Text == "HTL")
            {
                treeList1.ResetAutoFilterConditions();
                //treeList1.FilterConditions.Clear();
                AmenityBindingSource.DataSource = from c in context.AMENITY where c.SVC_TYPE == "HTL" orderby c.SORT_ORDER select c;
                colITEM_DESC1.Caption = "HOTEL AMENITIES";
                //  treeList1.BeginSort();
                treeList1.Columns["SORT_ORDER"].SortOrder = SortOrder.Ascending;
                //    treeList1.EndSort();
                treeList1.ExpandAll();
                sVCComboBoxEdit.Focus();
                treeList1.MoveFirst();

            }
            if (sVCComboBoxEdit.Text == "PKG")
            {
                treeList1.ResetAutoFilterConditions();
                //treeList1.FilterConditions.Clear();
                AmenityBindingSource.DataSource = from c in context.AMENITY where c.SVC_TYPE == "PKG" orderby c.SORT_ORDER select c;
                // treeList1.BeginSort();
                treeList1.Columns["SORT_ORDER"].SortOrder = SortOrder.Ascending;
                //  treeList1.EndSort();
                colITEM_DESC1.Caption = "PACKAGE AMENITIES";
                treeList1.ExpandAll();
                sVCComboBoxEdit.Focus();
                treeList1.MoveFirst();
            }
            //if (sVCComboBoxEdit.Text == "CAR")
            //{
            //    treeList1.FilterConditions.Clear();
            //    AmenityBindingSource.DataSource = from c in context.AMENITY where c.SVC_TYPE == "CAR" orderby c.SORT_ORDER select c;
            //    //treeList1.BeginSort();
            //    colITEM_DESC1.Caption = "CAR AMENITIES";
            //    treeList1.Columns["SORT_ORDER"].SortOrder = SortOrder.Ascending;
            //    // treeList1.EndSort();
            //    treeList1.ExpandAll();
            //    sVCComboBoxEdit.Focus();
            //    treeList1.MoveFirst();
            //}
            if (sVCComboBoxEdit.Text == "OPT")
            {
                treeList1.ResetAutoFilterConditions();
                //treeList1.FilterConditions.Clear();
                AmenityBindingSource.DataSource = from c in context.AMENITY where c.SVC_TYPE == "OPT" orderby c.SORT_ORDER select c;
                //treeList1.BeginSort();
                treeList1.Columns["SORT_ORDER"].SortOrder = SortOrder.Ascending;
                //treeList1.EndSort();
                colITEM_DESC1.Caption = "OPTIONAL SERVICE AMENITIES";
                treeList1.ExpandAll();
                sVCComboBoxEdit.Focus();
                treeList1.MoveFirst();
            }
            //if (sVCComboBoxEdit.Text == "CRU")
            //{
            //    treeList1.FilterConditions.Clear();
            //    AmenityBindingSource.DataSource = from c in context.AMENITY where c.SVC_TYPE == "CRU" orderby c.SORT_ORDER  select c;
            //    //treeList1.BeginSort();
            //    treeList1.Columns["SORT_ORDER"].SortOrder = SortOrder.Ascending;
            //    //treeList1.EndSort();
            //    colITEM_DESC1.Caption = "CRUISE AMENITIES";
            //    treeList1.ExpandAll();
            //    sVCComboBoxEdit.Focus();
            //    treeList1.MoveFirst();
            //}
            //if (sVCComboBoxEdit.Text == "AIR")
            //{
            //    treeList1.FilterConditions.Clear();
            //    AmenityBindingSource.DataSource = from c in context.AMENITY where c.SVC_TYPE == "AIR" orderby c.SORT_ORDER select c;
            //    //treeList1.BeginSort();
            //    treeList1.Columns["SORT_ORDER"].SortOrder = SortOrder.Ascending;
            //    //treeList1.EndSort();
            //    treeList1.ExpandAll();
            //    colITEM_DESC1.Caption = "AIR AMENITIES";
            //    sVCComboBoxEdit.Focus();
            //    treeList1.MoveFirst();
            //}
            sVCComboBoxEdit.Focus();
            modified = false;
            if (newRec)
                sVC_TYPETextEdit.Text = sVCComboBoxEdit.Text;
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {
            ///ARGHHHHH TREELIST I WILL BE BACK LATER///////////////
            if (AmenityBindingSource.Current != null)
            {
                if (treeList1.FocusedNode.PrevVisibleNode == null)
                    return;
                if (treeList1.FocusedNode.PrevNode == null)
                    return;

                if (treeList1.FocusedNode.PrevNode.HasChildren == true)
                {
                    do
                    {
                        string one = treeList1.FocusedNode.GetValue(colSORT_ORDER).ToString();
                        string two = treeList1.FocusedNode.PrevNode.GetValue(colSORT_ORDER).ToString();
                        string one2 = treeList1.FocusedNode.GetValue(colITEM_DESC1).ToString();
                        string two2 = treeList1.FocusedNode.PrevNode.GetValue(colITEM_DESC1).ToString();
                        int two1 = int.Parse(two);
                        int f2 = treeList1.FocusedNode.Nodes.Count;
                        int f3 = two1 + f2 + 1;
                        treeList1.FocusedNode.PrevNode.SetValue(colSORT_ORDER, f3);
                        treeList1.FocusedNode.SetValue(colSORT_ORDER, two1);

                        treeList1.Refresh();
                        if (treeList1.FocusedNode.PrevVisibleNode == null)
                            return;
                        if (treeList1.FocusedNode.PrevNode == null)
                            return;
                    } while (treeList1.FocusedNode.PrevNode.Visible == false);
                    return;
                }

                if (treeList1.FocusedNode.PrevNode.HasChildren == false)
                {
                    string one3 = treeList1.FocusedNode.GetValue(colSORT_ORDER).ToString();
                    string two3 = treeList1.FocusedNode.PrevNode.GetValue(colSORT_ORDER).ToString();
                    int one1 = int.Parse(one3);
                    int two4 = int.Parse(two3);
                    int dif = one1 - two4;
                    one1 -= dif;
                    two4 += dif;
                    one3 = one1.ToString();
                    two3 = two4.ToString();
                    treeList1.FocusedNode.SetValue(colSORT_ORDER, one3);
                    treeList1.FocusedNode.PrevNode.SetValue(colSORT_ORDER, two3);
                    treeList1.Refresh();
                }
            }
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {
            if (AmenityBindingSource.Current != null)
            {
                if (treeList1.FocusedNode.NextVisibleNode == null)
                    return;
                if (treeList1.FocusedNode.NextNode == null)
                    return;

                if (treeList1.FocusedNode.NextNode.HasChildren == true)
                {
                    do
                    {
                        string one = treeList1.FocusedNode.GetValue(colSORT_ORDER).ToString();
                        string two = treeList1.FocusedNode.NextNode.GetValue(colSORT_ORDER).ToString();
                        int one1 = int.Parse(one);
                        int f2 = treeList1.FocusedNode.NextNode.Nodes.Count;
                        int f3 = one1 + f2 + 1;
                        treeList1.FocusedNode.NextNode.SetValue(colSORT_ORDER, one);
                        treeList1.FocusedNode.SetValue(colSORT_ORDER, f3);
                        treeList1.Refresh();
                        if (treeList1.FocusedNode.NextVisibleNode == null)
                            return;
                        if (treeList1.FocusedNode.NextNode == null)
                            return;
                    } while (treeList1.FocusedNode.NextNode.Visible == false);
                    return;
                }

                if (treeList1.FocusedNode.NextNode.HasChildren == false)
                {
                    string one3 = treeList1.FocusedNode.GetValue(colSORT_ORDER).ToString();
                    string two3 = treeList1.FocusedNode.NextNode.GetValue(colSORT_ORDER).ToString();
                    int one1 = int.Parse(one3);
                    int two4 = int.Parse(two3);
                    int dif = two4 - one1;
                    one1 += dif;
                    two4 -= dif;
                    one3 = one1.ToString();
                    two3 = two4.ToString();
                    treeList1.FocusedNode.NextNode.SetValue(colSORT_ORDER, two3);
                    treeList1.FocusedNode.SetValue(colSORT_ORDER, one3);
                    treeList1.Refresh();
                }
            }
        } 

        void setValues()
        {
            gridView1.SetFocusedRowCellValue("CODE", string.Empty);
            gridView1.SetFocusedRowCellValue("PARENT_CODE", string.Empty);
            gridView1.SetFocusedRowCellValue("SVC_TYPE", sVCComboBoxEdit.Text);            
            gridView1.SetFocusedRowCellValue("USER_DEC1", 0);
            gridView1.SetFocusedRowCellValue("USER_DEC2", 0);
            gridView1.SetFocusedRowCellValue("USER_INT1", 0);
            gridView1.SetFocusedRowCellValue("USER_INT2", 0);                      
            gridView1.SetFocusedRowCellValue("ITEM_FORMAT1", string.Empty);
            gridView1.SetFocusedRowCellValue("ITEM_FORMAT2", string.Empty);
            gridView1.SetFocusedRowCellValue("ITEM_DESC2", string.Empty);
            gridView1.SetFocusedRowCellValue("USER_TXT1", string.Empty);
            gridView1.SetFocusedRowCellValue("USER_TXT2", string.Empty);
            gridView1.SetFocusedRowCellValue("USER_TXT3", string.Empty);
            gridView1.SetFocusedRowCellValue("USER_TXT4", string.Empty);
            gridView1.SetFocusedRowCellValue("IMAGE", string.Empty);
            gridView1.SetFocusedRowCellValue("ITEM_DESC1", string.Empty);
            gridView1.SetFocusedRowCellValue("HEADER", false);
            gridView1.SetFocusedRowCellValue("REQUIRE_ENTRY", false);
            gridView1.SetFocusedRowCellValue("SEARCHABLE", false);
            gridView1.SetFocusedRowCellValue("SUPPLIER_ENTRY", false);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(sVCComboBoxEdit.Text))
            {
                MessageBox.Show("Please select a valid service type before attempting to add a new record.");
                return;
            }
            string pCode = TextEditCode.Text;
            decimal sOrder = sORT_ORDERSpinEdit.Value;
            sOrder += 1;
            int val = 0;

            if (treeList1.Nodes.Count > 0)
                val = treeList1.FocusedNode.Nodes.Count;

            sVCComboBoxEdit.Focus();
            temp = newRec;
            if (checkForms())
            {
                if (AmenityBindingSource.Current != null)
                {
                    if (!temp)
                        context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (AMENITY)AmenityBindingSource.Current);
                }
                AmenityBindingSource.AddNew();
                sVCComboBoxEdit.Focus();
                setValues();
                setreadonly(false);
                setItems(false);
                newRec = true;
            }

            sVC_TYPETextEdit.Text = sVCComboBoxEdit.Text;
            pARENT_CODETextEdit.Text = pCode;
            sORT_ORDERSpinEdit.Value = sOrder + val;

        }



        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (AmenityBindingSource.Current == null)
                return;
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                modified = false;
                newRec = false;
                AmenityBindingSource.RemoveCurrent();
                errorProvider1.Clear();
                context.SaveChanges();
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);
                setreadonly(true);
                
            }
        
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }

        private bool checkForms()
        {
            if (!modified && !newRec)
                return true;
            bool validateMain = validCheck.checkAll(xtraScrollableControl1.Controls, errorProvider1, ((AMENITY)AmenityBindingSource.Current).checkAll, AmenityBindingSource);


            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, AmenityBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, AmenityBindingSource, Name, errorProvider1, Cursor);
                return false;
            }


        }


        private void aMENITYBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            sVCComboBoxEdit.Focus();
            if (AmenityBindingSource.Current == null)
                return;            
          
            ((AMENITY)AmenityBindingSource.Current).ImagesRoot = imagesRoot; // right before call to validCheck.saveRoutine
            bool temp = newRec;
            if (checkForms())
            {
               
                newRec = false;
                treeList1.Refresh();
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
                setreadonly(true);
                //codeTextEdit.Properties.ReadOnly = true;
                //gridView1.Columns.ColumnByName(colName1).OptionsColumn.AllowEdit = false;
            }

            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (AMENITY)AmenityBindingSource.Current);

        }


        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }


        private bool move()
        {
            sVCComboBoxEdit.Focus();
            
            temp = newRec;
            ((AMENITY)AmenityBindingSource.Current).ImagesRoot = imagesRoot;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (AMENITY)AmenityBindingSource.Current);
                newRec = false;
                modified = false;
                setreadonly(true);
                return true;
            }
            return false;
        }
        private void iMAGETextEdit_TextChanged(object sender, EventArgs e)
        {
            pictureEdit1.Image = null;
            Image pic = null;
            try
            {
                pic = new Bitmap(imagesRoot + ButtonEditImage.Text);
                errorProvider1.SetError(ButtonEditImage, "");
            }
            catch
            {
                try
                {
                    pic = new Bitmap(ButtonEditImage.Text);
                    errorProvider1.SetError(ButtonEditImage, "");
                }
                catch
                {
                    //if (string.IsNullOrWhiteSpace(path.Text))
                    //    errorProvider1.SetError(path, "");
                    //else
                    //    errorProvider1.SetError(path, "Invalid image file");
                    return;
                }
            }
            pictureEdit1.Image = pic;
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (move())
                AmenityBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                AmenityBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                AmenityBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                AmenityBindingSource.MoveLast();
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            //temp = newRec;
            //((AMENITY)AmenityBindingSource.Current).ImagesRoot = imagesRoot;
            //if (!temp && checkForms())
            //    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (AMENITY)AmenityBindingSource.Current);
        }

        private void AmenityForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (modified || newRec)
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

        private void sVC_TYPEComboBoxEdit_Leave(object sender, EventArgs e)
        {
            //if (AmenityBindingSource.Current != null)
            //{
            //    if (currentVal != ((Control)sender).Text)
            //        modified = true;
            //    validCheck.check(sender, errorProvider1, ((AMENITY)AmenityBindingSource.Current).checkType, AmenityBindingSource);
            //}
        }

        private void cODETextEdit_Leave(object sender, EventArgs e)
        {
            if (AmenityBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((AMENITY)AmenityBindingSource.Current).checkCode, AmenityBindingSource);
            }
        }

        private void iTEM_DESC1TextEdit_Leave(object sender, EventArgs e)
        {
            if (AmenityBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((AMENITY)AmenityBindingSource.Current).checkDesc1, AmenityBindingSource);
            }

        }

        private void iTEM_FORMAT1ComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (AmenityBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((AMENITY)AmenityBindingSource.Current).checkFormat1, AmenityBindingSource);
            }
        }

        private void iTEM_DESC2TextEdit_Leave(object sender, EventArgs e)
        {
            if (AmenityBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((AMENITY)AmenityBindingSource.Current).checkDesc2, AmenityBindingSource);
            }

        }

        private void iTEM_FORMAT2ComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (AmenityBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((AMENITY)AmenityBindingSource.Current).checkFormat2, AmenityBindingSource);
            }
        }

        private void iMAGETextEdit_Leave(object sender, EventArgs e)
        {
            if (AmenityBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((AMENITY)AmenityBindingSource.Current).checkImagePath, AmenityBindingSource);
            }
        }

        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {

        }

        private void treeList1_GetSelectImage(object sender, GetSelectImageEventArgs e)
        {

        }

        private void treeList1_CustomFilterDisplayText(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {

        }

        private void treeList1_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "ITEM_DESC1")
            {
                if (e.Node.Level == 0 || e.Node.HasChildren)
                {
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                }
            }
        }

        private void propogateOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // update amenassgn set sort_order = (select sort_order from amenity where
            //amenity.code = amenassgn.code and amenity.svc_type =  cboType  )
            var propogatedRecs = from assignRec in context.AMENASSGN
                                 from amenityRec in context.AMENITY
                                 where amenityRec.SVC_TYPE == sVCComboBoxEdit.Text && assignRec.SVC_TYPE == sVCComboBoxEdit.Text && assignRec.CODE == amenityRec.CODE
                                 select new { amenityRec.CODE, amenityRec.SORT_ORDER };
            Dictionary<string, int> amenitySort = new Dictionary<string, int>();
            foreach (var val in propogatedRecs)
                amenitySort[val.CODE] = (int)val.SORT_ORDER;
            foreach (AMENASSGN rec in context.AMENASSGN)
            {
                if (amenitySort.ContainsKey(rec.CODE))
                    rec.SORT_ORDER = amenitySort[rec.CODE];
            }
            context.SaveChanges();

        }

        private void propogateDeletionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //delete from amenassgn where svc_type =   cboType  and code not in 
            //(select code from amenity where svc_type =  cboType  )
            var propogatedRecs = from assignRec in context.AMENASSGN
                                 from amenityRec in context.AMENITY
                                 where amenityRec.SVC_TYPE == sVCComboBoxEdit.Text && assignRec.SVC_TYPE == sVCComboBoxEdit.Text && assignRec.CODE != amenityRec.CODE
                                 select assignRec;
            foreach (AMENASSGN rec in propogatedRecs)
            {
                context.AMENASSGN.DeleteObject(rec);
            }

            context.SaveChanges();
        }

        private void AmenityBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (AmenityBindingSource.Current != null)
            {
                enableNavigator(true);
                if (CheckEditHeader.Checked)
                {
                    setItems(true);
                    TextEditItem_Desc1.Properties.ReadOnly = false;
                }
                else
                {
                    setItems(false);

                }


            }
            else
                enableNavigator(false);
        }

        void enableNavigator(bool value)
        {
            bindingNavigatorMoveNextItem.Enabled = value;
            bindingNavigatorMoveLastItem.Enabled = value;
            bindingNavigatorMoveFirstItem.Enabled = value;
            bindingNavigatorMovePreviousItem.Enabled = value;
        }

        private void iMAGEButtonEdit_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog() { Title = "Open Image", InitialDirectory = imagesRoot })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (dlg.FileName.ToLower().IndexOf(imagesRoot.ToLower()) != -1)
                        ButtonEditImage.Text = dlg.FileName.Substring(imagesRoot.Length);
                    else
                        ButtonEditImage.Text = dlg.FileName;
                }
            }
        }

        private void AmenityForm_Shown(object sender, System.EventArgs e)
        {
            sVCComboBoxEdit.Focus();
        }

        private void treeList1_BeforeFocusNode(object sender, BeforeFocusNodeEventArgs e)
        {
            

            if (modified || newRec)
            {
                if (checkForms())
                {
                    e.CanFocus = true;
                }
                else
                    e.CanFocus = false;
            }
        }

        private void CheckEditSearchable_Click(object sender, System.EventArgs e)
        {
            modified = true;
        }
    }
}