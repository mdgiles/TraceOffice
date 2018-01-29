using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FlexModel;
using System.ComponentModel.DataAnnotations;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using System.Linq;
using FlexCore;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Runtime.InteropServices;
namespace TraceForms
{
    
    public partial class HtlTypeForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        const string colName = "colCODE";
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public  FlextourEntities context;
        public HtlTypeForm(FlexInterfaces.Core.ICoreSys sys)
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

         private void setValues()
         {
             GridViewHtlType.SetFocusedRowCellValue("CODE", string.Empty);
             GridViewHtlType.SetFocusedRowCellValue("DESCRIP", string.Empty);          
         }

        
         private void setReadOnly(bool value)
         {
             TextEditCode.Properties.ReadOnly = value;
             GridViewHtlType.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = !value;
         }

        private bool move()
        {
            GridViewHtlType.CloseEditor();
            TextEditCode.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( HTLTYPE)HtlTypeBindingSource.Current);
                setReadOnly(true);
                newRec = false;
                modified = false;
                return true;
            }
            return false;
        }
  
        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            temp = newRec;
            if (!temp && checkForms())
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( HTLTYPE)HtlTypeBindingSource.Current);

            setReadOnly(true);
        }
     
        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text.ToString();
        }

        private void HtlTypeForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)      
        {
            GridViewHtlType.ClearColumnsFilter();
            if (HtlTypeBindingSource.Current == null)
            {
                //fake query in order to create a link between the database table and the binding source
                HtlTypeBindingSource.DataSource = from opt in context.HTLTYPE where opt.CODE == "KJM9" select opt;
                HtlTypeBindingSource.AddNew();
                if (GridViewHtlType.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewHtlType.FocusedRowHandle = GridViewHtlType.RowCount - 1;
                setValues();
                TextEditCode.Focus();
                setReadOnly(false);
                newRec = true;
                return;
            }
            TextEditCode.Focus();
            //bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewHtlType.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( HTLTYPE)HtlTypeBindingSource.Current);
                HtlTypeBindingSource.AddNew();
                if (GridViewHtlType.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewHtlType.FocusedRowHandle = GridViewHtlType.RowCount - 1;
                setValues();
                TextEditCode.Focus();
                setReadOnly(false);
                newRec = true;
            }
        }
  
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (HtlTypeBindingSource.Current == null)
                return;
            GridViewHtlType.CloseEditor();
            if ((from hotrec in context.HOTEL where hotrec.LOCATION == TextEditCode.Text select hotrec).Count() > 0)
            {
                MessageBox.Show("The record you are trying to delete is being used by a hotel(s).");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                modified = false;
                newRec = false;
                HtlTypeBindingSource.RemoveCurrent();
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
            currentVal = TextEditCode.Text;
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
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((HTLTYPE)HtlTypeBindingSource.Current).checkAll, HtlTypeBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, HtlTypeBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, HtlTypeBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }

        private void hTLTYPEBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {        
            if (HtlTypeBindingSource.Current == null)
                return;
            GridViewHtlType.CloseEditor();
            TextEditCode.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            bool temp = newRec;
            if (checkForms())
            {
                TextEditCode.Focus();
                setReadOnly(true);
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;


            }

            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (HTLTYPE)HtlTypeBindingSource.Current);
              
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (move())
                HtlTypeBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                HtlTypeBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                HtlTypeBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                HtlTypeBindingSource.MoveLast();
        }

        private void cODETextEdit_Leave(object sender, EventArgs e)
        {
            if (HtlTypeBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((HTLTYPE)HtlTypeBindingSource.Current).checkCode, HtlTypeBindingSource);
            }
                 
        }

        private void dESCRIPTextBox_Leave(object sender, EventArgs e)
        {
            if (HtlTypeBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((HTLTYPE)HtlTypeBindingSource.Current).checkDesc, HtlTypeBindingSource);
            }
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (HtlTypeBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (HTLTYPE)HtlTypeBindingSource.Current);
                TextEditCode.Properties.ReadOnly = true;
                GridViewHtlType.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = false;
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (HTLTYPE)HtlTypeBindingSource.Current);
           
                e.Allow = false;

            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewHtlType.IsFilterRow(e.RowHandle))
                modified = true;
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }

        private void HtlTypeForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewHtlType.IsFilterRow(GridViewHtlType.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewHtlType.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewHtlType.GetFocusedDisplayText()))
                value = GridViewHtlType.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.DESCRIP like '{0}%'", GridViewHtlType.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "DESCRIP"));
                var special = context.HTLTYPE.Where(query);
               
                if (!string.IsNullOrWhiteSpace(GridViewHtlType.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE")))
                {
                    query = String.Format("it.{0} like '{1}%'", "CODE", GridViewHtlType.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                    special = special.Where(query);
                }

                int count = special.Count();
                if (count > 0)
                {
                    HtlTypeBindingSource.DataSource = special;
                    GridViewHtlType.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                    GridViewHtlType.FocusedRowHandle = 0;
                    GridViewHtlType.FocusedColumn.FieldName = colName;
                    GridViewHtlType.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewHtlType.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void HtlTypeBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (HtlTypeBindingSource.Current != null)
                enableNavigator(true);
            else
                enableNavigator(false);
        }
     
        
    }
}