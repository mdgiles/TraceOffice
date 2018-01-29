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
    
    public partial class ReportTypeForm : XtraForm
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
        public  FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public string dataPath;
        public ReportTypeForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
            //LoadLookups();
            setReadOnly(true);
            dataPath = sys.Settings.DataPath;          
        }

        private void setReadOnly(bool value)
        {
            TextEditCode.Properties.ReadOnly = value;
            GridViewReport.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = !value;
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

        private void setValues()
        {
            GridViewReport.SetFocusedRowCellValue("RPT_FILE", string.Empty);
            GridViewReport.SetFocusedRowCellValue("RecipientType", string.Empty);
            GridViewReport.SetFocusedRowCellValue("ReplyToEmail", string.Empty);
            GridViewReport.SetFocusedRowCellValue("ReplyToMessage", string.Empty);
            GridViewReport.SetFocusedRowCellValue("IMG_RES", -1);

            GridViewReport.SetFocusedRowCellValue("CODE", string.Empty);
            GridViewReport.SetFocusedRowCellValue("DESC", string.Empty);
            GridViewReport.SetFocusedRowCellValue("TOURFAX", false);
            GridViewReport.SetFocusedRowCellValue("EDITABLE", false);
            GridViewReport.SetFocusedRowCellValue("MEDIA_RPT", false);   
        }


        private bool checkForms()
        {
            if (!modified && !newRec)
                return true;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((RPTTYPE)RptTypeBindingSource.Current).checkAll, RptTypeBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, RptTypeBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, RptTypeBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }

       
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            GridViewReport.ClearColumnsFilter();
            if (RptTypeBindingSource.Current == null)
            {
                //fake query in order to create a link between the database table and the binding source
                RptTypeBindingSource.DataSource = from opt in context.RPTTYPE where opt.CODE == "KJM9" select opt;
                RptTypeBindingSource.AddNew();
                if (GridViewReport.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewReport.FocusedRowHandle = GridViewReport.RowCount - 1;
                setValues();
                TextEditCode.Focus();
                setReadOnly(false);
                newRec = true;
                return;
            }
            TextEditCode.Focus();
            //bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewReport.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( RPTTYPE)RptTypeBindingSource.Current);
                RptTypeBindingSource.AddNew();
                if (GridViewReport.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewReport.FocusedRowHandle = GridViewReport.RowCount - 1;
                TextEditCode.Focus();
                setValues();
                setReadOnly(false);
                newRec = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (RptTypeBindingSource.Current == null)
                return;
            GridViewReport.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                
                modified = false;
                newRec = false;
                RptTypeBindingSource.RemoveCurrent();
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

        private void BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (RptTypeBindingSource.Current == null)
                return;

            GridViewReport.CloseEditor();
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
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (RPTTYPE)RptTypeBindingSource.Current);
               
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool move()
        {
            GridViewReport.CloseEditor();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            TextEditCode.Focus();
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( RPTTYPE)RptTypeBindingSource.Current);
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
                RptTypeBindingSource.MoveFirst();

        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                RptTypeBindingSource.MovePrevious();

        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                RptTypeBindingSource.MoveNext();

        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                RptTypeBindingSource.MoveLast();

        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (RptTypeBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (RPTTYPE)RptTypeBindingSource.Current);

                setReadOnly(true);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (RPTTYPE)RptTypeBindingSource.Current);
            
                e.Allow = false;
            }
        }

        private void RPTTYPEForm_FormClosing(object sender, FormClosingEventArgs e)
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
            if (!GridViewReport.IsFilterRow(e.RowHandle))
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
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( RPTTYPE)RptTypeBindingSource.Current);
           setReadOnly(true);
        }

        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        private void codeTextBox_Leave(object sender, EventArgs e)
        {
            if (RptTypeBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((RPTTYPE)RptTypeBindingSource.Current).checkCode, RptTypeBindingSource);
            }
       
        }

        private void dESCTextBox_Leave(object sender, EventArgs e)
        {
            if (RptTypeBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((RPTTYPE)RptTypeBindingSource.Current).checkDesc, RptTypeBindingSource);
            }
        }

        private void rPT_FILETextBox_Leave(object sender, EventArgs e)
        {
            if (RptTypeBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((RPTTYPE)RptTypeBindingSource.Current).checkRPT_FILE, RptTypeBindingSource);
            }
        }

        private void mEDIA_RPTCheckEdit_Leave(object sender, EventArgs e)
        {
            if (RptTypeBindingSource.Current != null)
            {
                validCheck.check(iMG_RESRadioGroup, errorProvider1, ((RPTTYPE)RptTypeBindingSource.Current).checkIMG_RES, RptTypeBindingSource);
            }
        }
        private void iMG_RESRadioGroup_Leave(object sender, EventArgs e)
        {
            if (RptTypeBindingSource.Current != null)
            {
                validCheck.check(sender, errorProvider1, ((RPTTYPE)RptTypeBindingSource.Current).checkIMG_RES, RptTypeBindingSource);
            }
        }
        private void replyToEmailTextEdit_Leave(object sender, EventArgs e)
        {
            if (RptTypeBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((RPTTYPE)RptTypeBindingSource.Current).checkReplyToEmail, RptTypeBindingSource);
            }
        }

        private void replyToMessageTextEdit_Leave(object sender, EventArgs e)
        {

        }

        private void ReportTypeForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewReport.IsFilterRow(GridViewReport.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewReport.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewReport.GetFocusedDisplayText()))
                value = GridViewReport.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.CODE like '{0}%'", GridViewReport.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                var special = context.RPTTYPE.Where(query);

                if (!string.IsNullOrWhiteSpace(GridViewReport.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "DESC")))
                {
                    query = String.Format("it.{0} like '{1}%'", "[DESC]", GridViewReport.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "DESC"));
                    special = special.Where(query);
                }
                int count = special.Count();
                if (count > 0)
                {
                    RptTypeBindingSource.DataSource = special;
                    GridViewReport.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                    GridViewReport.FocusedRowHandle = 0;
                    GridViewReport.FocusedColumn.FieldName = colName;
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewReport.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void tOURFAXCheckEdit_Click(object sender, System.EventArgs e)
        {
            modified = true;
        }

        private void rPT_FILEButtonEdit_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog() { Title = "Open Image", InitialDirectory = dataPath })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (dlg.FileName.ToLower().IndexOf(dataPath.ToLower()) != -1)
                        rPT_FILEButtonEdit.Text = dlg.FileName.Substring(dataPath.Length);
                    else
                        rPT_FILEButtonEdit.Text = dlg.FileName;
                }
            }  
        }

        private void RptTypeBindingSource_CurrentChanged(object sender, System.EventArgs e)
        {
            if (RptTypeBindingSource.Current != null)
            {
                RPTTYPE x = (RPTTYPE)RptTypeBindingSource.Current;
                enableNavigator(true);
                if (x.MEDIA_RPT == null)
                    iMG_RESRadioGroup.Enabled = false;
                else
                    iMG_RESRadioGroup.Enabled = (bool)x.MEDIA_RPT;
            }
            else
                enableNavigator(false);
        }

        private void mEDIA_RPTCheckEdit_Click(object sender, System.EventArgs e)
        {
            modified = true;
            if (!mEDIA_RPTCheckEdit.Checked)
            {
                iMG_RESRadioGroup.Enabled = true;
                iMG_RESRadioGroup.SelectedIndex = 0;
            }
            else
                iMG_RESRadioGroup.Enabled = false;
        }

        private void rPT_FILEButtonEdit_Leave(object sender, System.EventArgs e)
        {
            if (RptTypeBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((RPTTYPE)RptTypeBindingSource.Current).checkRPT_FILE, RptTypeBindingSource);
            }
        }

        private void recipientTypeComboBoxEdit_Leave(object sender, System.EventArgs e)
        {
            if (RptTypeBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((RPTTYPE)RptTypeBindingSource.Current).checkRecipientType, RptTypeBindingSource);
            }
        }

      

    }
}