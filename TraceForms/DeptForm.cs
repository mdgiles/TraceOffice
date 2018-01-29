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
    
    public partial class DeptForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool createNew = false;
        public bool modified = false;
        public bool newRec = false;
        public bool addNew = false;
        public bool temp = false;
        public bool refresh = false;
        public bool cancelled = false;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        const string colName = "colCode";
        public  FlextourEntities context;
        public DeptForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
            LoadLookups();

          //  DeptBindingSource.DataSource = context.Dept;
            DeptBindingSource.DataSource = from opt in context.Dept where opt.Code == "KJM9" select opt;

        }
        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);
        }

        private void setReadOnly(bool value)
        {
            codeTextBox.Properties.ReadOnly = value;
            GridViewDept.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = !value;
        }

        private void LoadLookups()
        {
            setReadOnly(true);
            enableNavigator(false);
            
        }

        void enableNavigator(bool value)
        {
            bindingNavigatorMoveNextItem.Enabled = value;
            bindingNavigatorMoveLastItem.Enabled = value;
            bindingNavigatorMoveFirstItem.Enabled = value;
            bindingNavigatorMovePreviousItem.Enabled = value;
        }
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            GridViewDept.ClearColumnsFilter();
            if (DeptBindingSource.Current == null)
            {
                //fake query in order to create a link between the database table and the binding source
                DeptBindingSource.AddNew();
                if (GridViewDept.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewDept.FocusedRowHandle = GridViewDept.RowCount - 1;
               //setValues();
                codeTextBox.Focus();
                setReadOnly(false);
               // lockGrid(false);
                newRec = true;
                return;
            }
            codeTextBox.Focus();
            //bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewDept.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (Dept)DeptBindingSource.Current);
                DeptBindingSource.AddNew();
                if (GridViewDept.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewDept.FocusedRowHandle = GridViewDept.RowCount - 1;
              //  setValues();
                codeTextBox.Focus();
                setReadOnly(false);
              //  lockGrid(false);
                newRec = true;
            }
            //////////////////////
          
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            
            if (DeptBindingSource.Current == null)
                return;

            GridViewDept.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                modified = false;
                newRec = false;
                DeptBindingSource.RemoveCurrent();
                errorProvider1.Clear();
                context.SaveChanges();
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);
            }

            //ockGrid(true);
            setReadOnly(true);
            codeTextBox.Focus();
            currentVal = codeTextBox.Text;
            modified = false;
            newRec = false;
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }



        private void deptBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
          
            ////////////////////////
            if (DeptBindingSource.Current == null)
                return;

            GridViewDept.CloseEditor();
                codeTextBox.Focus();
                bool temp = newRec;
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            if (checkForms())
            {
                codeTextBox.Focus();
                //lockGrid(true);
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
                setReadOnly(true);
            }
            
            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (Dept)DeptBindingSource.Current);
              
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool checkForms()
        {
            if (!modified && !newRec)
                return true;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((Dept)DeptBindingSource.Current).checkAll, DeptBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, DeptBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, DeptBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }

        private bool move()
        {
            GridViewDept.CloseEditor();
            codeTextBox.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (Dept)DeptBindingSource.Current);
                //lockGrid(true);
                newRec = false;
                modified = false;
                return true;
                setReadOnly(true);
            }
            return false;
        }


        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (move())
                DeptBindingSource.MoveFirst();            
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                DeptBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                DeptBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                DeptBindingSource.MoveLast();
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            temp = newRec;
            bool temp2 = modified;
            if (checkForms())
            {
                e.Allow = true;
                if ((!temp) && temp2)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (Dept)DeptBindingSource.Current);


                setReadOnly(true);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (Dept)DeptBindingSource.Current);
         
                e.Allow = false;

            }
        }

        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text.ToString();
        }

        private void codeTextBox_Leave(object sender, EventArgs e)
        {
            if (DeptBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((Dept)DeptBindingSource.Current).checkCode, DeptBindingSource);
            }
        
        }

        private void descTextBox_Leave(object sender, EventArgs e)
        {
            if (DeptBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((Dept)DeptBindingSource.Current).checkDesc, DeptBindingSource);
            }
        }

        private void DeptForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewDept.IsFilterRow(e.RowHandle))
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
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( Dept)DeptBindingSource.Current);

            setReadOnly(true);
        }

        private void DeptBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (DeptBindingSource.Current != null)
                enableNavigator(true);
            else
                enableNavigator(false);
        }

        private void DeptForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewDept.IsFilterRow(GridViewDept.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewDept.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewDept.GetFocusedDisplayText()))
                value = GridViewDept.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.Code like '{0}%'", GridViewDept.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Code"));
                var special = context.Dept.Where(query);

                if (!string.IsNullOrWhiteSpace(GridViewDept.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Desc")))
                {
                    query = String.Format("it.{0} like '{1}%'", "[Desc]", GridViewDept.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Desc"));
                    special = special.Where(query);
                }

                int count = special.Count();
                if (count > 0)
                {
                    DeptBindingSource.DataSource = special;
                    GridViewDept.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                    GridViewDept.FocusedRowHandle = 0;
                    GridViewDept.FocusedColumn.FieldName = colName;
                    GridViewDept.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewDept.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }




    }
}