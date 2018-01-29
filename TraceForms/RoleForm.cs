using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FlexModel;
using DevExpress.XtraEditors.Controls;
using System.Linq;
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
      
    public partial class RoleForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool createNew;
        public bool modified = false;
        public bool newRec = false;
        public bool addNew = false;
        public bool temp = false;
        public bool refresh = false;
        public bool cancelled = false;
        const string colName = "colCODE";
        const string colName1 = "colTYPE";
        public  FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public ImageComboBoxItemCollection opers;
        public ImageComboBoxItemCollection htls;
        public ImageComboBoxItemCollection agys;
        public RoleForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
            LoadLookups();
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);           
        }

        private void LoadLookups()
        {
            //opers = new ImageComboBoxItemCollection(ImageComboBoxEditCode.Properties);
            //htls = new ImageComboBoxItemCollection(ImageComboBoxEditCode.Properties);
            //agys = new ImageComboBoxItemCollection(ImageComboBoxEditCode.Properties);
            setReadOnly(true);
            //var agy = from agyRec in context.AGY orderby agyRec.NO ascending select new { agyRec.NO, agyRec.NAME };            
            //var operators = from compRec in context.OPERATOR orderby compRec.CODE ascending select new { compRec.CODE, compRec.NAME };
            //var hotels = from hotRec in context.HOTEL orderby hotRec.CODE ascending select new { hotRec.CODE, hotRec.NAME };
            //ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };           
            //ImageComboBoxEditCode.Properties.Items.Add(loadBlank);
            //agys.Add(loadBlank);
            //opers.Add(loadBlank);
            //htls.Add(loadBlank);
            //foreach (var result in agy)
            //{
            //    ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.NO.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.NO.TrimEnd() };
                
            //    agys.Add(load);
            //}
            
            //foreach (var result in operators)
            //{
            //    ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                
            //    opers.Add(load);
            //}
            //foreach (var result in hotels)
            //{
            //    ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                
            //    htls.Add(load);
            //}
            enableNavigator(false);
           
        }

        void enableNavigator(bool value)
        {
            bindingNavigatorMoveNextItem.Enabled = value;
            bindingNavigatorMoveLastItem.Enabled = value;
            bindingNavigatorMoveFirstItem.Enabled = value;
            bindingNavigatorMovePreviousItem.Enabled = value;
        }

        private void setReadOnly(bool val)
        {
            TextEditCode.Properties.ReadOnly = val;
            tYPEComboBoxEdit.Properties.ReadOnly = val;         
            GridViewRole.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = !val;
            GridViewRole.Columns.ColumnByName(colName1).OptionsColumn.AllowEdit = !val;
        }   
     
        private void tYPEComboBoxEdit_TextChanged_1(object sender, EventArgs e)
        {
            //ImageComboBoxEditCode.Properties.Items.Clear();
            //if (this.tYPEComboBoxEdit.Text == "Hotel")
            //{
            //    ImageComboBoxEditCode.Properties.Items.AddRange(htls);
            //}

            //if (this.tYPEComboBoxEdit.Text == "Operator")
            //{
            //    ImageComboBoxEditCode.Properties.Items.AddRange(opers);
            //}

            //if (this.tYPEComboBoxEdit.Text == "Agency")
            //{
            //    ImageComboBoxEditCode.Properties.Items.AddRange(agys);
            //}
        }

        private bool checkForms()
        {
            if (!modified && !newRec)
                return true;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((ROLE)RoleBindingSource.Current).checkAll, RoleBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, RoleBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, RoleBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            GridViewRole.ClearColumnsFilter();
            if (RoleBindingSource.Current == null)
            {
                //fake query in order to create a link between the database table and the binding source
                RoleBindingSource.DataSource = from opt in context.ROLE where opt.CODE == "KJM9" select opt;
                RoleBindingSource.AddNew();
                if (GridViewRole.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewRole.FocusedRowHandle = GridViewRole.RowCount - 1;
                tYPEComboBoxEdit.Focus();
                setReadOnly(false);
                newRec = true;
                return;
            }
            tYPEComboBoxEdit.Focus();
            //bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewRole.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( ROLE)RoleBindingSource.Current);
                RoleBindingSource.AddNew();
                if (GridViewRole.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewRole.FocusedRowHandle = GridViewRole.RowCount - 1;
                tYPEComboBoxEdit.Focus();
                setReadOnly(false);
                newRec = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (RoleBindingSource.Current == null)
                return;
            GridViewRole.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
            
                modified = false;
                newRec = false;
                RoleBindingSource.RemoveCurrent();
                errorProvider1.Clear();
                context.SaveChanges();
                setReadOnly(true);
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);
              
            }
            currentVal = tYPEComboBoxEdit.Text;

        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }


        private void BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (RoleBindingSource.Current == null)
                return;

            GridViewRole.CloseEditor();
            tYPEComboBoxEdit.Focus();
           // bindingNavigatorPositionItem.Focus();//trigger field leave eventoo
            bool temp = newRec;
            if (checkForms())
            {
                tYPEComboBoxEdit.Focus();
                setReadOnly(true);
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
            }

            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (ROLE)RoleBindingSource.Current);
            
        }
        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }


        private bool move()
        {
            GridViewRole.CloseEditor();
            tYPEComboBoxEdit.Focus();
           // bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( ROLE)RoleBindingSource.Current);
                setReadOnly(true);
                newRec = false;
                modified = false;
                return true;
            }
            return false;
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (move())
                RoleBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())                
                RoleBindingSource.MovePrevious();
            
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())               
                RoleBindingSource.MoveNext();
            
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                RoleBindingSource.MoveLast();
            
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (RoleBindingSource.Current == null)
            {
                e.Allow = true;
                return;
            }

            temp = newRec;
            bool temp2 = modified;
            if (checkForms())
            {
                e.Allow = true;
                if ((!temp) && temp2)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (ROLE)RoleBindingSource.Current);


                setReadOnly(true);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (ROLE)RoleBindingSource.Current);
         
                e.Allow = false;
            }
        }

        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        private void codeTextBox_Leave(object sender, EventArgs e)
        {
          
           
        }

        private void descTextBox_Leave(object sender, EventArgs e)
        {
            if (RoleBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((ROLE)RoleBindingSource.Current).checkDesc, RoleBindingSource);
            }
        }

        private void type_Leave(object sender, EventArgs e)
        {
            if (RoleBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((ROLE)RoleBindingSource.Current).checkType, RoleBindingSource);
            }
           
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewRole.IsFilterRow(e.RowHandle))
                modified = true;
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            temp = newRec;
            if (!temp && checkForms())
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( ROLE)RoleBindingSource.Current);

            setReadOnly(true);
        }

        private void RoleForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void RoleForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewRole.IsFilterRow(GridViewRole.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewRole.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewRole.GetFocusedDisplayText()))
                value = GridViewRole.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.CODE like '{0}%'", GridViewRole.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                var special = context.ROLE.Where(query);

                if (!string.IsNullOrWhiteSpace(GridViewRole.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "DESC")))
                {
                    query = String.Format("it.{0} like '{1}%'", "[DESC]", GridViewRole.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "DESC"));
                    special = special.Where(query);
                }
                if (!string.IsNullOrWhiteSpace(GridViewRole.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "TYPE")))
                {
                    query = String.Format("it.{0} like '{1}%'", "[TYPE]", GridViewRole.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "TYPE"));
                    special = special.Where(query);
                }
                int count = special.Count();
                if (count > 0)
                {
                    RoleBindingSource.DataSource = special;
                    GridViewRole.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                    GridViewRole.FocusedRowHandle = 0;
                    GridViewRole.FocusedColumn.FieldName = colName;
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewRole.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void ImageComboBoxEditCode_Leave(object sender, System.EventArgs e)
        {
            if (RoleBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((ROLE)RoleBindingSource.Current).checkCode, RoleBindingSource);
            }
        }

        private void RoleBindingSource_CurrentChanged(object sender, System.EventArgs e)
        {
            if (RoleBindingSource.Current != null)
                enableNavigator(true);
            else
                enableNavigator(false);
        }
    }
}

