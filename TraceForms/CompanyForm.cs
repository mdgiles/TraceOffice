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


using DevExpress.XtraGrid.Columns;

using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraEditors.Repository;

using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;

using DevExpress.XtraGrid;

namespace TraceForms
{
    
    public partial class CompanyForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        const string colName = "colCODE";
        public  FlextourEntities context;

        public CompanyForm(FlexInterfaces.Core.ICoreSys sys)
        {
             InitializeComponent();
             Connect(sys);
             CompanyBindingSource.DataSource = context.COMPANY;
             cODETextEdit.Properties.ReadOnly = true;
             GridViewCompany.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = false;
             enableNavigator(false);
        }

        void enableNavigator(bool value)
        {
            bindingNavigatorMoveNextItem.Enabled = value;
            bindingNavigatorMoveLastItem.Enabled = value;
            bindingNavigatorMoveFirstItem.Enabled = value;
            bindingNavigatorMovePreviousItem.Enabled = value;
        }



        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);
        }

        private void setValues()
        {
            GridViewCompany.SetFocusedRowCellValue("CODE", string.Empty);
            GridViewCompany.SetFocusedRowCellValue("TYPE", string.Empty);
            GridViewCompany.SetFocusedRowCellValue("NAME", string.Empty);         
        }
     

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            GridViewCompany.ClearColumnsFilter();
            if (CompanyBindingSource.Current == null)
            {
                //fake query in order to create a link between the database table and the binding source
                CompanyBindingSource.DataSource = from opt in context.COMPANY where opt.CODE == "KJM9" select opt;
                CompanyBindingSource.AddNew();
                if (GridViewCompany.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewCompany.FocusedRowHandle = GridViewCompany.RowCount - 1;
                setValues();
                cODETextEdit.Focus();
                cODETextEdit.Properties.ReadOnly = false;
                GridViewCompany.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = true;
                newRec = true;
                return;
            }

            cODETextEdit.Focus();

          //  bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewCompany.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( COMPANY)CompanyBindingSource.Current);
                CompanyBindingSource.AddNew();
                if (GridViewCompany.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewCompany.FocusedRowHandle = GridViewCompany.RowCount - 1;
                setValues();
                cODETextEdit.Focus();
                 cODETextEdit.Properties.ReadOnly  = false;
                GridViewCompany.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = true;
                newRec = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (CompanyBindingSource.Current == null)
                return;
            GridViewCompany.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                modified = false;
                newRec = false;
                CompanyBindingSource.RemoveCurrent();
                errorProvider1.Clear();
                context.SaveChanges();
                cODETextEdit.Properties.ReadOnly = true;
                GridViewCompany.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = false;
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);
               
            }
            currentVal = cODETextEdit.Text;
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
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((COMPANY)CompanyBindingSource.Current).checkAll, CompanyBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, CompanyBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, CompanyBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }

        private void cOMPANYBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (CompanyBindingSource.Current == null)
                return;
            GridViewCompany.CloseEditor();
            cODETextEdit.Focus();

            bool temp = newRec;
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            if (checkForms())
            {
                cODETextEdit.Focus();
                cODETextEdit.Properties.ReadOnly = true;
                GridViewCompany.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = false;
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
            }

            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (COMPANY)CompanyBindingSource.Current);
              
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool move()
        {
            GridViewCompany.CloseEditor();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            cODETextEdit.Focus();
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( COMPANY)CompanyBindingSource.Current);
                cODETextEdit.Properties.ReadOnly = true;
                GridViewCompany.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = false;
                newRec = false;
                modified = false;
                return true;
            }
            return false;
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (move())
                CompanyBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                CompanyBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                CompanyBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                CompanyBindingSource.MoveLast();
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {        
            if (CompanyBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (COMPANY)CompanyBindingSource.Current);
                cODETextEdit.Properties.ReadOnly = true;
                GridViewCompany.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = false;
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (COMPANY)CompanyBindingSource.Current);
           
                e.Allow = false;

            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewCompany.IsFilterRow(e.RowHandle))
                modified = true;
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }

        private void CompanyForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            temp = newRec;
            if (!temp && checkForms())
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( COMPANY)CompanyBindingSource.Current);

            cODETextEdit.Properties.ReadOnly = true;
            GridViewCompany.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = false;
        }

        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }
  
        private void nAMETextBox_Leave(object sender, EventArgs e)
        {
            if (CompanyBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((COMPANY)CompanyBindingSource.Current).checkName, CompanyBindingSource);
            }
        }

        private void cODETextEdit_Leave(object sender, EventArgs e)
        {
            if (CompanyBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((COMPANY)CompanyBindingSource.Current).checkCode, CompanyBindingSource);
            }
               
        }

        private void tYPETextEdit_Leave(object sender, EventArgs e)
        {
            if (CompanyBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((COMPANY)CompanyBindingSource.Current).checkType, CompanyBindingSource);
            }
        }

        private void CompanyForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewCompany.IsFilterRow(GridViewCompany.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewCompany.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewCompany.GetFocusedDisplayText()))
                value = GridViewCompany.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.NAME like '{0}%'", GridViewCompany.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "NAME"));
                var special = context.COMPANY.Where(query);
               
                if (!string.IsNullOrWhiteSpace(GridViewCompany.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE")))
                {
                    query = String.Format("it.{0} like '{1}%'", "CODE", GridViewCompany.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                    special = special.Where(query);
                }
              
                int count = special.Count();
                if (count > 0)
                {
                    CompanyBindingSource.DataSource = special;
                    GridViewCompany.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewCompany.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void CompanyBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (CompanyBindingSource.Current != null)
                enableNavigator(true);
            else
                enableNavigator(false);
        }
             
    }
}