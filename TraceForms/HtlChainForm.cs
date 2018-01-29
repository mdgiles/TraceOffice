using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    
    public partial class HtlChainForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        const string colName = "colCODE";
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public  FlextourEntities context;
        public HtlChainForm(FlexInterfaces.Core.ICoreSys sys)
        {           
            InitializeComponent();
            Connect(sys);
            LoadLookups();
            //AirportBindingSource.DataSource = context.Airport;
           
         
          
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);
           
        }
        private void LoadLookups()
        {            
            modified = false;
            newRec = false;
            temp = false;
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

        private void setReadOnly(bool value)
        {
            cODETextEdit.Properties.ReadOnly = value;
            GridViewHtlChain.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = !value;      
        }      
      
        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text.ToString();
        }

        private void setValues()
        {
            GridViewHtlChain.SetFocusedRowCellValue("CODE", string.Empty);
            GridViewHtlChain.SetFocusedRowCellValue("DESC", string.Empty);           
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            GridViewHtlChain.ClearColumnsFilter();
            if (HtlChainBindingSource.Current == null)
            {
                //fake query in order to create a link between the database table and the binding source
                HtlChainBindingSource.DataSource = from opt in context.HTLCHAIN where opt.CODE == "KJM9" select opt;
                HtlChainBindingSource.AddNew();
                if (GridViewHtlChain.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewHtlChain.FocusedRowHandle = GridViewHtlChain.RowCount - 1;
                setValues();
                cODETextEdit.Focus();
                setReadOnly(false);    
                newRec = true;
                return;
            }
            cODETextEdit.Focus();
           //bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewHtlChain.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( HTLCHAIN)HtlChainBindingSource.Current);
                HtlChainBindingSource.AddNew();
                if (GridViewHtlChain.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewHtlChain.FocusedRowHandle = GridViewHtlChain.RowCount - 1;
                setValues();
                cODETextEdit.Focus();
                setReadOnly(false);    
                newRec = true;
            }
     
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (HtlChainBindingSource.Current == null)
                return;
            GridViewHtlChain.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                modified = false;
                newRec = false;
                HtlChainBindingSource.RemoveCurrent();
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
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((HTLCHAIN)HtlChainBindingSource.Current).checkAll, HtlChainBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, HtlChainBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, HtlChainBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }


        private void hTLCHAINBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (HtlChainBindingSource.Current == null)
                return;
            GridViewHtlChain.CloseEditor();
            cODETextEdit.Focus();
           //bindingNavigatorPositionItem.Focus();//trigger field leave event
            bool temp = newRec;
           if (checkForms())
           {
                cODETextEdit.Focus();
                setReadOnly(true);    
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
            }

           if (!temp && !modified)
               context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (HTLCHAIN)HtlChainBindingSource.Current);
              
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool move()
        {
            GridViewHtlChain.CloseEditor();
            cODETextEdit.Focus();
          // bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( HTLCHAIN)HtlChainBindingSource.Current);
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
                HtlChainBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                HtlChainBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                HtlChainBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                HtlChainBindingSource.MoveLast();
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (HtlChainBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (HTLCHAIN)HtlChainBindingSource.Current);
                setReadOnly(true);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (HTLCHAIN)HtlChainBindingSource.Current);
          
                e.Allow = false;

            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewHtlChain.IsFilterRow(e.RowHandle))
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
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (HTLCHAIN)HtlChainBindingSource.Current);

            setReadOnly(true);    
        }

        private void HtlChainForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void cODETextEdit_Leave(object sender, EventArgs e)
        {
            if (HtlChainBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((HTLCHAIN)HtlChainBindingSource.Current).checkCode, HtlChainBindingSource);
            }
           
        }

        private void dESCTextBox_Leave(object sender, EventArgs e)
        {
            if (HtlChainBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((HTLCHAIN)HtlChainBindingSource.Current).checkDesc, HtlChainBindingSource);
            }
        }

        private void HtlChainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewHtlChain.IsFilterRow(GridViewHtlChain.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewHtlChain.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewHtlChain.GetFocusedDisplayText()))
                value = GridViewHtlChain.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.CODE like '{0}%'", GridViewHtlChain.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                var special = context.HTLCHAIN.Where(query);
               
                if (!string.IsNullOrWhiteSpace(GridViewHtlChain.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "DESC")))
                {
                    query = String.Format("it.{0} like '{1}%'", "[DESC]", GridViewHtlChain.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "DESC"));
                    special = special.Where(query);
                }

                int count = special.Count();
                if (count > 0)
                {
                    HtlChainBindingSource.DataSource = special;
                    GridViewHtlChain.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                    GridViewHtlChain.FocusedRowHandle = 0;
                    GridViewHtlChain.FocusedColumn.FieldName = colName;
                    GridViewHtlChain.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewHtlChain.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void HtlChainBindingSource_CurrentChanged(object sender, System.EventArgs e)
        {
            if (HtlChainBindingSource.Current != null)
                enableNavigator(true);
            else
                enableNavigator(false);
        }
    }
}