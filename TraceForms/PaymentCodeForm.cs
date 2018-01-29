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
    
    public partial class PaymentCodeForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        const string colName = "colPMT_CODE";
        public  FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public PaymentCodeForm(FlexInterfaces.Core.ICoreSys sys)
        {           
            InitializeComponent();
            Connect(sys);
        }

        private void setReadOnly(bool value)
        {
            TextEditCode.Properties.ReadOnly = value;
            GridViewPayCode.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = !value;
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);
            enableNavigator(false);
        }

        void enableNavigator(bool value)
        {
            bindingNavigatorMoveNextItem.Enabled = value;
            bindingNavigatorMoveLastItem.Enabled = value;
            bindingNavigatorMoveFirstItem.Enabled = value;
            bindingNavigatorMovePreviousItem.Enabled = value;
        }

        private bool checkForms()
        {
            if (!modified && !newRec)
                return true;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((PMTCODE)PmtCodeBindingSource.Current).checkAll, PmtCodeBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, PmtCodeBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, PmtCodeBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }


        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            GridViewPayCode.ClearColumnsFilter();
            if (PmtCodeBindingSource.Current == null)
            {
                PmtCodeBindingSource.DataSource = from opt in context.PMTCODE where opt.PMT_CODE == "KJM9" select opt;
                PmtCodeBindingSource.AddNew();
                if (GridViewPayCode.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewPayCode.FocusedRowHandle = GridViewPayCode.RowCount - 1;
                TextEditCode.Focus();
                setReadOnly(false);
                newRec = true;
                return;
            }
            TextEditCode.Focus();
            //bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewPayCode.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( PMTCODE)PmtCodeBindingSource.Current);
                PmtCodeBindingSource.AddNew();
                if (GridViewPayCode.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewPayCode.FocusedRowHandle = GridViewPayCode.RowCount - 1;
                TextEditCode.Focus();
                setReadOnly(false);
                newRec = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (PmtCodeBindingSource.Current == null)
                return;

            GridViewPayCode.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                modified = false;
                newRec = false;
                PmtCodeBindingSource.RemoveCurrent();
                errorProvider1.Clear();
                context.SaveChanges();
                setReadOnly(true);
                //bindingNavigatorPositionItem.Focus();
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);
            }
            currentVal = TextEditCode.Text;
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }

        private void pMTCODEBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {   
            if (PmtCodeBindingSource.Current == null)
                return;

            GridViewPayCode.CloseEditor();
            TextEditCode.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            bool temp = newRec;
            if (checkForms())
            {
                TextEditCode.Focus();
                TextEditCode.Properties.ReadOnly = true;
                setReadOnly(true);
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
            }

            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (PMTCODE)PmtCodeBindingSource.Current);
             
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool move()
        {
            GridViewPayCode.CloseEditor();
            TextEditCode.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( PMTCODE)PmtCodeBindingSource.Current);
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
                PmtCodeBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                PmtCodeBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                PmtCodeBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                PmtCodeBindingSource.MoveLast();
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (PmtCodeBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (PMTCODE)PmtCodeBindingSource.Current);

                setReadOnly(true);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (PMTCODE)PmtCodeBindingSource.Current);
           
                e.Allow = false;
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewPayCode.IsFilterRow(e.RowHandle))
                modified = true;
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; 
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            //temp = newRec;
            //if (!temp && checkForms())
            //    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( PMTCODE)PmtCodeBindingSource.Current);

            //setReadOnly(true);
        }

        private void PaymentCodeForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text.ToString();
        }

        private void code_Leave(object sender, EventArgs e)
        {
            if (PmtCodeBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((PMTCODE)PmtCodeBindingSource.Current).checkCode, PmtCodeBindingSource);
            }
        }

        private void pMT_DESCTextBox_Leave(object sender, EventArgs e)
        {
            if (PmtCodeBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((PMTCODE)PmtCodeBindingSource.Current).checkDesc, PmtCodeBindingSource);
            }
        }

        private void PaymentCodeForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewPayCode.IsFilterRow(GridViewPayCode.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewPayCode.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewPayCode.GetFocusedDisplayText()))
                value = GridViewPayCode.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.PMT_CODE like '{0}%'", GridViewPayCode.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "PMT_CODE"));
                var special = context.PMTCODE.Where(query);

                if (!string.IsNullOrWhiteSpace(GridViewPayCode.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "PMT_DESC")))
                {
                    query = String.Format("it.{0} like '{1}%'", "PMT_DESC", GridViewPayCode.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "PMT_DESC"));
                    special = special.Where(query);
                }
                int count = special.Count();
                if (count > 0)
                {
                    PmtCodeBindingSource.DataSource = special;
                    GridViewPayCode.FocusedRowHandle = 0;
                    GridViewPayCode.FocusedColumn.FieldName = colName;
                    GridViewPayCode.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewPayCode.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void PmtCodeBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (PmtCodeBindingSource.Current != null)
                enableNavigator(true);
            else
                enableNavigator(false);
        }


    }
}