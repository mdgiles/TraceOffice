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
    
    public partial class SpecialValueForm : XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        const string colName1 = "colCode";
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public FlextourEntities context;
        public SpecialValueForm(FlexInterfaces.Core.ICoreSys sys)
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

        private void setReadOnly(bool value)
        {
            codeTextEdit.Properties.ReadOnly = value;
            ComboBoxEditType.Properties.ReadOnly = value;
            GridViewSpecVal.Columns.ColumnByName(colName1).OptionsColumn.AllowEdit = !value;
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
            GridViewSpecVal.SetFocusedRowCellValue("Type", string.Empty);
            GridViewSpecVal.SetFocusedRowCellValue("Code", string.Empty);
            GridViewSpecVal.SetFocusedRowCellValue("Name", string.Empty);
            GridViewSpecVal.SetFocusedRowCellValue("RequiresRateCalc", false);
            GridViewSpecVal.SetFocusedRowCellValue("RateCalcDesc", string.Empty);           
        }


        private bool checkForms()
        {
            if (!modified && !newRec)
                return true;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((SpecialValue)SpecialValueBindingSource.Current).checkAll, SpecialValueBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, SpecialValueBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, SpecialValueBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }
       
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            GridViewSpecVal.ClearColumnsFilter();
            if (SpecialValueBindingSource.Current == null)
            {
                //fake query in order to create a link between the database table and the binding source
                SpecialValueBindingSource.DataSource = from opt in context.SpecialValue where opt.Code == "KJM9" select opt;
                SpecialValueBindingSource.AddNew();
                if (GridViewSpecVal.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewSpecVal.FocusedRowHandle = GridViewSpecVal.RowCount - 1;
                ComboBoxEditType.Focus();
                setReadOnly(false);
                newRec = true;
                return;
            }
            ComboBoxEditType.Focus();
            //bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewSpecVal.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (SpecialValue)SpecialValueBindingSource.Current);
                SpecialValueBindingSource.AddNew();
                if (GridViewSpecVal.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewSpecVal.FocusedRowHandle = GridViewSpecVal.RowCount - 1;
                ComboBoxEditType.Focus();
                setReadOnly(false);
                newRec = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

            if (SpecialValueBindingSource.Current == null)
                return;
            GridViewSpecVal.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {                
                modified = false;
                newRec = false;
                SpecialValueBindingSource.RemoveCurrent();
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
            currentVal = codeTextEdit.Text;
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }

        private void specialValueBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (SpecialValueBindingSource.Current == null)
                return;

            GridViewSpecVal.CloseEditor();
            ComboBoxEditType.Focus();
            bool temp = newRec;
            //bindingNavigatorPositionItem.Focus();
            if (checkForms())
            {
                codeTextEdit.Focus();
                setReadOnly(true);
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
            }

            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (SpecialValue)SpecialValueBindingSource.Current);
               

        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool move()
        {
            GridViewSpecVal.CloseEditor();
            ComboBoxEditType.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (SpecialValue)SpecialValueBindingSource.Current);
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
                SpecialValueBindingSource.MoveFirst();
            
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                SpecialValueBindingSource.MovePrevious();
            
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                SpecialValueBindingSource.MoveNext();
            

        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                SpecialValueBindingSource.MoveLast();
            
        }

        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            temp = newRec;
            if (!temp && checkForms())
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (SpecialValue)SpecialValueBindingSource.Current);

            setReadOnly(true);
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (SpecialValueBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (SpecialValue)SpecialValueBindingSource.Current);

                setReadOnly(true);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (SpecialValue)SpecialValueBindingSource.Current);
           
                e.Allow = false;
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewSpecVal.IsFilterRow(e.RowHandle))
                modified = true;
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; 
        }

        private void typeComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (SpecialValueBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((SpecialValue)SpecialValueBindingSource.Current).checkType, SpecialValueBindingSource);
            }
          
        }

        private void codeTextEdit_Leave(object sender, EventArgs e)
        {
            if (SpecialValueBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((SpecialValue)SpecialValueBindingSource.Current).checkCode, SpecialValueBindingSource);
            }
           
        }

        private void nameTextBox_Leave(object sender, EventArgs e)
        {
            if (SpecialValueBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((SpecialValue)SpecialValueBindingSource.Current).checkName, SpecialValueBindingSource);
            }
        }

        private void rateCalcDescTextBox_Leave(object sender, EventArgs e)
        {
            if (SpecialValueBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                if (requiresRateCalcCheckEdit.Checked == true)
                    validCheck.check(rateCalcDescMemoEdit, errorProvider1, ((SpecialValue)SpecialValueBindingSource.Current).checkDesc, SpecialValueBindingSource);
                else
                    errorProvider1.SetError(rateCalcDescMemoEdit, "");
            }
        }

        private void SpecialValue_FormClosing(object sender, FormClosingEventArgs e)
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

        private void SpecialValueForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewSpecVal.IsFilterRow(GridViewSpecVal.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewSpecVal.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewSpecVal.GetFocusedDisplayText()))
                value = GridViewSpecVal.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.Code like '{0}%'", GridViewSpecVal.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Code"));
                var special = context.SpecialValue.Where(query);


                if (!string.IsNullOrWhiteSpace(GridViewSpecVal.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Name")))
                {
                    query = String.Format("it.{0} like '{1}%'", "Name", GridViewSpecVal.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Name"));
                    special = special.Where(query);
                }
                int count = special.Count();
                if (count > 0)
                {
                    SpecialValueBindingSource.DataSource = special;
                    GridViewSpecVal.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                    GridViewSpecVal.FocusedRowHandle = 0;
                    GridViewSpecVal.FocusedColumn.FieldName = colName;
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewSpecVal.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void SpecialValueBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (SpecialValueBindingSource.Current != null)
                enableNavigator(true);
            else
                enableNavigator(false);
        }

        private void requiresRateCalcCheckEdit_Click(object sender, EventArgs e)
        {
            modified = true;

            if(requiresRateCalcCheckEdit.Checked == true)
            {
                GridViewSpecVal.SetFocusedRowCellValue("RateCalcDesc", string.Empty);
                rateCalcDescMemoEdit.EditValue = string.Empty;
                rateCalcDescMemoEdit.Text = string.Empty;
                rateCalcDescMemoEdit.Enabled = false;

            }
            else
            {
                rateCalcDescMemoEdit.Enabled = true;
                
            }
        }

       
    }
}