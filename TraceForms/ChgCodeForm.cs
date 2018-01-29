using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FlexModel;
using System.ComponentModel.DataAnnotations;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
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
     
    public partial class ChgCodeForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;       
        public bool temp = false;      
        const string colName = "colCODE";
        public FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public ChgCodeForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys); 
            
            cODETextEdit.Properties.ReadOnly = true;
            GridViewChgCode.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = false;
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

        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }


        private bool move()
        {
            GridViewChgCode.CloseEditor();
            cODETextEdit.Focus();
           // bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( CHGCODE)ChgCodeBindingSource.Current);
                cODETextEdit.Properties.ReadOnly = true;
                GridViewChgCode.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = false;
                newRec = false;
                modified = false;
                return true;
            }
            return false;
        }

    

        private void ChgCodeForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void setValues()
        {
            GridViewChgCode.SetFocusedRowCellValue("CODE", string.Empty);
            GridViewChgCode.SetFocusedRowCellValue("DESCRIPTION", string.Empty);
            GridViewChgCode.SetFocusedRowCellValue("CONF", "N");
            GridViewChgCode.SetFocusedRowCellValue("DATAFLEX_FILL_01", string.Empty);
            GridViewChgCode.SetFocusedRowCellValue("DATAFLEX_FILL_02", string.Empty);         
        }
     

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            GridViewChgCode.ClearColumnsFilter();
            if (ChgCodeBindingSource.Current == null)
            {
                //fake query in order to create a link between the database table and the binding source
                ChgCodeBindingSource.DataSource = from opt in context.CHGCODE where opt.CODE == "KJM9" select opt;
                ChgCodeBindingSource.AddNew();
                if (GridViewChgCode.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewChgCode.FocusedRowHandle = GridViewChgCode.RowCount - 1;
                setValues();
                cODETextEdit.Focus();
                cODETextEdit.Properties.ReadOnly = false;
                GridViewChgCode.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = true;
                newRec = true;
                return;
            }
            cODETextEdit.Focus();

           // bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewChgCode.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( CHGCODE)ChgCodeBindingSource.Current);
                ChgCodeBindingSource.AddNew();
                if (GridViewChgCode.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewChgCode.FocusedRowHandle = GridViewChgCode.RowCount - 1;
                setValues();
                cODETextEdit.Focus();
                cODETextEdit.Properties.ReadOnly = false;
                GridViewChgCode.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = true;
                newRec = true;
            }

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (ChgCodeBindingSource.Current == null)
                return;
            GridViewChgCode.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                modified = false;
                newRec = false;
                ChgCodeBindingSource.RemoveCurrent();
                errorProvider1.Clear();
                context.SaveChanges();
                cODETextEdit.Properties.ReadOnly = true;
                GridViewChgCode.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = false;
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);

            }
            currentVal = cODETextEdit.Text;
            //i am right here
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
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((CHGCODE)ChgCodeBindingSource.Current).checkAll, ChgCodeBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, ChgCodeBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, ChgCodeBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }

        private void cHGCODEBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

            if (ChgCodeBindingSource.Current == null)
                return;
            GridViewChgCode.CloseEditor();
            cODETextEdit.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            bool temp = newRec;
            if (checkForms())
            {
                cODETextEdit.Focus();
                cODETextEdit.Properties.ReadOnly = true;
                GridViewChgCode.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = false;
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
            }

            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CHGCODE)ChgCodeBindingSource.Current);
              

        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (move())
                ChgCodeBindingSource.MoveFirst();
           

        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                ChgCodeBindingSource.MovePrevious();
           

        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                ChgCodeBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                ChgCodeBindingSource.MoveLast(); 
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {

            if (ChgCodeBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CHGCODE)ChgCodeBindingSource.Current);


                cODETextEdit.Properties.ReadOnly = true;
                GridViewChgCode.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = false;
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CHGCODE)ChgCodeBindingSource.Current);
         
                e.Allow = false;

            }

        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewChgCode.IsFilterRow(e.RowHandle))
                modified = true;
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            temp = newRec;
             if (!temp && checkForms())
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( CHGCODE)ChgCodeBindingSource.Current);

            cODETextEdit.Properties.ReadOnly = true;
            GridViewChgCode.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = false;

        }

        private void cODETextEdit_Leave(object sender, EventArgs e)
        {
            if (ChgCodeBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((CHGCODE)ChgCodeBindingSource.Current).checkCode, ChgCodeBindingSource);
            }
           
        }

        private void dESCRIPTIONTextEdit_Leave(object sender, EventArgs e)
        {
            if (ChgCodeBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((CHGCODE)ChgCodeBindingSource.Current).checkDesc, ChgCodeBindingSource);
            }

        }

        private void ChgCodeForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewChgCode.IsFilterRow(GridViewChgCode.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewChgCode.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewChgCode.GetFocusedDisplayText()))
                value = GridViewChgCode.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.DESCRIPTION like '{0}%'", GridViewChgCode.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "DESCRIPTION"));
                var special = context.CHGCODE.Where(query);
                
                if (!string.IsNullOrWhiteSpace(GridViewChgCode.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE")))
                {
                    query = String.Format("it.{0} like '{1}%'", "CODE", GridViewChgCode.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                    special = special.Where(query);
                }
               
                int count = special.Count();
                if (count > 0)
                {
                    ChgCodeBindingSource.DataSource = special;
                    //lol
                    GridViewChgCode.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewChgCode.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void ChgCodeBindingSource_CurrentChanged(object sender, System.EventArgs e)
        {
            if (ChgCodeBindingSource.Current != null)
                enableNavigator(true);
            else
                enableNavigator(false);
        }

        private void confirmCheckEdit_Click(object sender, System.EventArgs e)
        {
            modified = true;
        }

    


    }
}