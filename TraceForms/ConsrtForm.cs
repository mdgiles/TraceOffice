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
using DevExpress.XtraEditors.DXErrorProvider;
using System.Runtime.InteropServices;
namespace TraceForms
{
     
    public partial class ConsrtForm : DevExpress.XtraEditors.XtraForm
    {

        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        const string colName = "colCODE";
        public string username;
        public  FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public ConsrtForm(FlexCore.CoreSys _sys)
        {

            InitializeComponent();
            Connection.EFConnectionString = _sys.Settings.EFConnectionString;
            context = new FlextourEntities(_sys.Settings.EFConnectionString);
            username = _sys.User.Name;
            //ConsrtBindingSource.DataSource = context.CONSRT;
            cODETextEdit.Properties.ReadOnly = true;
            GridViewConsrt.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = false;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            GridViewConsrt.ClearColumnsFilter();
            if (ConsrtBindingSource.Current == null)
            {
                //fake query in order to create a link between the database table and the binding source
                ConsrtBindingSource.DataSource = from opt in context.CONSRT where opt.CODE == "KJM9" select opt;
                ConsrtBindingSource.AddNew();
                if (GridViewConsrt.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewConsrt.FocusedRowHandle = GridViewConsrt.RowCount - 1;
                cODETextEdit.Focus();
                cODETextEdit.Properties.ReadOnly = false;
                GridViewConsrt.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = true;
                newRec = true;
                return;
            }
            cODETextEdit.Focus();
           // bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewConsrt.CloseEditor();
            temp = newRec;
            //if (validCheck.saveRoutine(cONSRTBindingSource, cONSRTBindingNavigator, context, errorProvider1, ref newRec, ref modified, (( CONSRT)cONSRTBindingSource.Current).checkAll, splitContainerControl1.Panel2.Controls, validCheck.dummy))
            if (checkForms())
            {
                errorProvider1.Clear();
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( CONSRT)ConsrtBindingSource.Current);
                ConsrtBindingSource.AddNew();
                if (GridViewConsrt.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewConsrt.FocusedRowHandle = GridViewConsrt.RowCount - 1;
                cODETextEdit.Focus();
                cODETextEdit.Properties.ReadOnly = false;
                GridViewConsrt.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = true;
                newRec = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (ConsrtBindingSource.Current == null)
                return;
            GridViewConsrt.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
               
                modified = false;
                newRec = false;
                ConsrtBindingSource.RemoveCurrent();
                errorProvider1.Clear();
                context.SaveChanges();
                cODETextEdit.Properties.ReadOnly = true;
                GridViewConsrt.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = false;
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);
                //bindingNavigatorPositionItem.Focus();
              
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
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, (( CONSRT)ConsrtBindingSource.Current).checkMain, ConsrtBindingSource);
            //bool ok1 = validCheck.checkAll(xtraScrollableControl2.Controls, errorProvider1, (( CONSRT)ConsrtBindingSource.Current).check, ConsrtBindingSource); && ok1 
            bool validateCommissions = validCheck.checkAll(PanelControlCommissionsTab.Controls, errorProvider1, (( CONSRT)ConsrtBindingSource.Current).checkCommissionsTab, ConsrtBindingSource);
            bool validateComments = validCheck.checkAll(PanelControlCommentsTab.Controls, errorProvider1, (( CONSRT)ConsrtBindingSource.Current).checkCommentsTab, ConsrtBindingSource);
            bool validateLocation = validCheck.checkAll(PanelControlLocationTab.Controls, errorProvider1, ((CONSRT)ConsrtBindingSource.Current).checkLocationTab, ConsrtBindingSource);

            if (validateMain && validateCommissions && validateComments && validateLocation)
                return validCheck.saveRec(ref modified, true, ref newRec, context, ConsrtBindingSource, this.Name, errorProvider1, Cursor);
            else
                return validCheck.saveRec(ref modified, false, ref newRec, context, ConsrtBindingSource, this.Name, errorProvider1, Cursor);
        }
        private void cONSRTBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
           
            if (ConsrtBindingSource.Current == null)
                return;
            GridViewConsrt.CloseEditor();
            cODETextEdit.Focus();
           // bindingNavigatorPositionItem.Focus();//trigger field leave event
            bool temp = newRec;
            if (checkForms())
            {
                errorProvider1.Clear();
                cODETextEdit.Properties.ReadOnly = true;
                GridViewConsrt.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = false;
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;

            }

            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CONSRT)ConsrtBindingSource.Current);
         
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool move()
        {
            GridViewConsrt.CloseEditor();
            cODETextEdit.Focus();
           // bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            //if (validCheck.saveRoutine(cONSRTBindingSource, cONSRTBindingNavigator, context, errorProvider1, ref newRec, ref modified, (( CONSRT)cONSRTBindingSource.Current).checkAll, splitContainerControl1.Panel2.Controls, validCheck.dummy))
            if (checkForms())
            {
                errorProvider1.Clear();

                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( CONSRT)ConsrtBindingSource.Current);
                cODETextEdit.Properties.ReadOnly = true;
                GridViewConsrt.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = false;
                newRec = false;
                modified = false;
                return true;
            }
            return false;
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (move())
                ConsrtBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                ConsrtBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                ConsrtBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                ConsrtBindingSource.MoveLast();
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (ConsrtBindingSource.Current == null)
            {
                e.Allow = true;
                return;
            }

            temp = newRec;
            bool temp2 = modified;
            if (checkForms())
            {
                errorProvider1.Clear();
                e.Allow = true;
                if ((!temp) && temp2)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CONSRT)ConsrtBindingSource.Current);


                cODETextEdit.Properties.ReadOnly = true;
                GridViewConsrt.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = false;
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CONSRT)ConsrtBindingSource.Current);
         
                e.Allow = false;
               
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewConsrt.IsFilterRow(e.RowHandle))
                modified = true;

            labelControl1.Text = DateTime.Today.ToShortDateString();
            labelControl2.Text = username;       
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }

        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text.ToString();
        }

        private void ConsrtForm_FormClosing(object sender, FormClosingEventArgs e)
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
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( CONSRT)ConsrtBindingSource.Current);
                            
            cODETextEdit.Properties.ReadOnly = true;
            GridViewConsrt.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = false;
        }

        private void nAMETextBox_Leave(object sender, EventArgs e)
        {
            if (ConsrtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((CONSRT)ConsrtBindingSource.Current).checkName, ConsrtBindingSource);
            }
        }

        private void aPTextBox_Leave(object sender, EventArgs e)
        {
            if (ConsrtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((CONSRT)ConsrtBindingSource.Current).checkAp, ConsrtBindingSource);
            }
        }

        private void aDDR1TextEdit_Leave(object sender, EventArgs e)
        {
            if (ConsrtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((CONSRT)ConsrtBindingSource.Current).checkAddress1, ConsrtBindingSource);
            }
        }

        private void aDDR2TextEdit_Leave(object sender, EventArgs e)
        {
            if (ConsrtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((CONSRT)ConsrtBindingSource.Current).checkAddress2, ConsrtBindingSource);
            }
        }

        private void aDDR3TextEdit_Leave(object sender, EventArgs e)
        {
            if (ConsrtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((CONSRT)ConsrtBindingSource.Current).checkAddress3, ConsrtBindingSource);
            }
        }

        private void pHO1TextBox_Leave(object sender, EventArgs e)
        {
            if (ConsrtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((CONSRT)ConsrtBindingSource.Current).checkPho1, ConsrtBindingSource);
            }
        }

        private void pHO2TextBox_Leave(object sender, EventArgs e)
        {
            if (ConsrtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((CONSRT)ConsrtBindingSource.Current).checkPho2, ConsrtBindingSource);
            }
        }

        private void pHO3TextBox_Leave(object sender, EventArgs e)
        {
            if (ConsrtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((CONSRT)ConsrtBindingSource.Current).checkPho3, ConsrtBindingSource);
            }
        }

        private void sTART_DATEDateTimePicker_Leave(object sender, EventArgs e)
        {
            if (ConsrtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((CONSRT)ConsrtBindingSource.Current).checkStart, ConsrtBindingSource);
            }
        }

        private void eND_DATEDateTimePicker_Leave(object sender, EventArgs e)
        {
            if (ConsrtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((CONSRT)ConsrtBindingSource.Current).checkEnd, ConsrtBindingSource);
            }
        }

        private void cOMM1_TYPETextBox_Leave(object sender, EventArgs e)
        {
            if (ConsrtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((CONSRT)ConsrtBindingSource.Current).checkComm_type, ConsrtBindingSource);
            }
        }

        private void cOMM2_TYPETextBox_Leave(object sender, EventArgs e)
        {
            if (ConsrtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((CONSRT)ConsrtBindingSource.Current).checkComm_type2, ConsrtBindingSource);
            }
        }

        private void cOMM3_TYPETextBox_Leave(object sender, EventArgs e)
        {
            if (ConsrtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((CONSRT)ConsrtBindingSource.Current).checkComm_type3, ConsrtBindingSource);
            }
        }

        private void cOMM4_TYPETextBox_Leave(object sender, EventArgs e)
        {
            if (ConsrtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((CONSRT)ConsrtBindingSource.Current).checkComm_type4, ConsrtBindingSource);
            }
        }

        private void cOMM1_DEDTextBox_Leave(object sender, EventArgs e)
        {
            if (ConsrtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((CONSRT)ConsrtBindingSource.Current).checkComm_ded, ConsrtBindingSource);
            }
        }

        private void cOMM2_DEDTextBox_Leave(object sender, EventArgs e)
        {
            if (ConsrtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((CONSRT)ConsrtBindingSource.Current).checkComm_ded2, ConsrtBindingSource);
            }
        }

        private void cOMM3_DEDTextBox_Leave(object sender, EventArgs e)
        {
            if (ConsrtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((CONSRT)ConsrtBindingSource.Current).checkComm_ded3, ConsrtBindingSource);
            }
        }

        private void cOMM4_DEDTextBox_Leave(object sender, EventArgs e)
        {
            if (ConsrtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((CONSRT)ConsrtBindingSource.Current).checkComm_ded4, ConsrtBindingSource);
            }
        }

        private void cOMM1_BALTextBox_Leave(object sender, EventArgs e)
        {
            if (ConsrtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((CONSRT)ConsrtBindingSource.Current).checkComm_bal, ConsrtBindingSource);
            }
        }

        private void cOMM2_BALTextBox_Leave(object sender, EventArgs e)
        {
            if (ConsrtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((CONSRT)ConsrtBindingSource.Current).checkComm_bal2, ConsrtBindingSource);
            }
        }

        private void cOMM3_BALTextBox_Leave(object sender, EventArgs e)
        {
            if (ConsrtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((CONSRT)ConsrtBindingSource.Current).checkComm_bal3, ConsrtBindingSource);
            }
        }

        private void cOMM4_BALTextBox_Leave(object sender, EventArgs e)
        {
            if (ConsrtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((CONSRT)ConsrtBindingSource.Current).checkComm_bal4, ConsrtBindingSource);
            }
        }

        private void cOMMENT1TextBox_Leave(object sender, EventArgs e)
        {
            if (ConsrtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((CONSRT)ConsrtBindingSource.Current).checkComment1, ConsrtBindingSource);
            }
        }

        private void cOMMENT2TextBox_Leave(object sender, EventArgs e)
        {
            if (ConsrtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((CONSRT)ConsrtBindingSource.Current).checkComment2, ConsrtBindingSource);
            }
        }

        private void cODETextEdit_Leave(object sender, EventArgs e)
        {
            if (ConsrtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((CONSRT)ConsrtBindingSource.Current).checkCode, ConsrtBindingSource);
            }
        }

        private void sTART_DATEDateEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void sTART_DATEDateEdit_TextChanged(object sender, EventArgs e)
        {
            sTART_DATEDateEdit.Text = validCheck.convertDate(sTART_DATEDateEdit.Text);
        }

        private void eND_DATEDateEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void eND_DATEDateEdit_TextChanged(object sender, EventArgs e)
        {
            eND_DATEDateEdit.Text = validCheck.convertDate(eND_DATEDateEdit.Text);
        }

        private void ConsrtForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewConsrt.IsFilterRow(GridViewConsrt.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewConsrt.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewConsrt.GetFocusedDisplayText()))
                value = GridViewConsrt.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.NAME like '{0}%'", GridViewConsrt.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "NAME"));
                var special = context.CONSRT.Where(query);
               
                if (!string.IsNullOrWhiteSpace(GridViewConsrt.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE")))
                {
                    query = String.Format("it.{0} like '{1}%'", "CODE", GridViewConsrt.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                    special = special.Where(query);
                }

                int count = special.Count();
                if (count > 0)
                {
                    ConsrtBindingSource.DataSource = special;
                    GridViewConsrt.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewConsrt.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

    

      

      
    }
}