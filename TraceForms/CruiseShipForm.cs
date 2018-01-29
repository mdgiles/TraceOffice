using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using FlexModel;
using DevExpress.XtraEditors.Controls;
using System.Linq;
using System.Runtime.InteropServices;

using DevExpress.XtraGrid.Columns;

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
   
    public partial class CruiseShipForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        const string colName = "colCODE";
        public string username;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public FlextourEntities context;
        public CruiseShipForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
            LoadLookups();    
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);
            username = sys.User.Name;
        }

        private void LoadLookups()
        {
            modified = false;
            newRec = false;
            var oper = from operRec in context.OPERATOR orderby operRec.CODE ascending select new { operRec.CODE, operRec.NAME };
            var crus = from cruRec in context.CRU orderby cruRec.CODE ascending select new { cruRec.CODE, cruRec.NAME };
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxEditCode.Properties.Items.Add(loadBlank);
            ImageComboBoxEditOperator.Properties.Items.Add(loadBlank);   
            foreach (var result in oper)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditOperator.Properties.Items.Add(load);
            }
            foreach (var result in crus)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCode.Properties.Items.Add(load);
            }
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
            ImageComboBoxEditCode.Properties.ReadOnly = value;
            ImageComboBoxEditOperator.Properties.ReadOnly = value;
            GridViewCruise.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = !value;
        }
 
        private bool checkForms()
        {
            if (!modified && !newRec)
                return true;
            
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((CRU)CruBindingSource.Current).checkMain, CruBindingSource);
            bool validateGenInfo = validCheck.checkAll(PanelControlGenInfoTab.Controls, errorProvider1, ((CRU)CruBindingSource.Current).checkGenInfoTab, CruBindingSource);
            bool validateComments = validCheck.checkAll(PanelControlCommentsTab.Controls, errorProvider1, ((CRU)CruBindingSource.Current).checkCommentsTab, CruBindingSource);
            bool validatePolicy = validCheck.checkAll(PanelControlPolicyTab.Controls, errorProvider1, ((CRU)CruBindingSource.Current).checkPolicyTab, CruBindingSource);
            bool validateAccount = validCheck.checkAll(PanelControlAccountTab.Controls, errorProvider1, ((CRU)CruBindingSource.Current).checkAccountTab, CruBindingSource);

            if (validateMain && validateGenInfo && validateComments && validatePolicy && validateAccount)
                return validCheck.saveRec(ref modified, true, ref newRec, context, CruBindingSource, this.Name, errorProvider1, Cursor);
            else
                return validCheck.saveRec(ref modified, false, ref newRec, context, CruBindingSource, this.Name, errorProvider1, Cursor);
        }
        private bool move()
        {
            
            GridViewCruise.CloseEditor();
            ImageComboBoxEditCode.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            
            if (checkForms())
            {
                errorProvider1.Clear();

                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CRU)CruBindingSource.Current);
                setReadOnly(true);
                newRec = false;
                modified = false;
                return true;
            }
            return false;
        }

        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text.ToString();
        }

        private void CruiseShipForm_Load(object sender, EventArgs e)
        {         

            //cruiseShip
                
        }



        private void nAMETextBox_Leave(object sender, EventArgs e)
        {
            if (CruBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CRU)CruBindingSource.Current).checkName, CruBindingSource);

            }
        }

        private void rESTR_CDEImageComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (CruBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CRU)CruBindingSource.Current).checkRest, CruBindingSource);
            }
        }

        private void bUILTDateEdit_Leave(object sender, EventArgs e)
        {
            //if (currentVal != ((Control)sender).Text.ToString())
            //    modified = true;
            //validCheck.check(sender, errorProvider1, ((CRU)cRUBindingSource.Current).checkDate, cRUBindingSource);
        }

        private void eLECTTextBox_Leave(object sender, EventArgs e)
        {
            if (CruBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CRU)CruBindingSource.Current).checkElect, CruBindingSource);
            }
        }

        private void tONNAGETextBox_Leave(object sender, EventArgs e)
        {
            if (CruBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CRU)CruBindingSource.Current).checkTonn, CruBindingSource);
            }
        }

        private void rEGISTRYTextBox_Leave(object sender, EventArgs e)
        {
            if (CruBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CRU)CruBindingSource.Current).checkReg, CruBindingSource);
            }
        }

        private void cREWTextBox_Leave(object sender, EventArgs e)
        {
            if (CruBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CRU)CruBindingSource.Current).checkCrew, CruBindingSource);
            }
        }

        private void fACILITIESTextBox_Leave(object sender, EventArgs e)
        {
            if (CruBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CRU)CruBindingSource.Current).checkFacilities, CruBindingSource);
            }
        }

        private void dEF_CABINTextBox_Leave(object sender, EventArgs e)
        {
            if (CruBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CRU)CruBindingSource.Current).checkCabin, CruBindingSource);
            }
        }

        private void cOMMENT1TextBox_Leave(object sender, EventArgs e)
        {
            if (CruBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CRU)CruBindingSource.Current).checkComm, CruBindingSource);
            }
        }

        private void cOMMENT2TextBox_Leave(object sender, EventArgs e)
        {
            if (CruBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CRU)CruBindingSource.Current).checkComm2, CruBindingSource);
            }
        }

        private void cOMMENT3TextBox_Leave(object sender, EventArgs e)
        {
            if (CruBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CRU)CruBindingSource.Current).checkComm3, CruBindingSource);
            }
        }

        private void cOMMENT4TextBox_Leave(object sender, EventArgs e)
        {
            if (CruBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CRU)CruBindingSource.Current).checkComm4, CruBindingSource);
            }
        }

        private void aPTextBox_Leave(object sender, EventArgs e)
        {
            if (CruBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CRU)CruBindingSource.Current).checkAp, CruBindingSource);
            }
        }

        private void aRTextBox_Leave(object sender, EventArgs e)
        {
            if (CruBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CRU)CruBindingSource.Current).checkAr, CruBindingSource);
            }
        }

        private void setValues()
        {
            GridViewCruise.SetFocusedRowCellValue("CODE", string.Empty);
            GridViewCruise.SetFocusedRowCellValue("NAME", string.Empty);
            GridViewCruise.SetFocusedRowCellValue("AP", string.Empty);
            GridViewCruise.SetFocusedRowCellValue("AR", string.Empty);
            GridViewCruise.SetFocusedRowCellValue("BUILT", string.Empty);
            GridViewCruise.SetFocusedRowCellValue("ELECT", string.Empty);
            GridViewCruise.SetFocusedRowCellValue("TONNAGE", string.Empty);
            GridViewCruise.SetFocusedRowCellValue("REGISTRY", string.Empty);
            GridViewCruise.SetFocusedRowCellValue("CREW", string.Empty);
            GridViewCruise.SetFocusedRowCellValue("FACILITIES", string.Empty);
            GridViewCruise.SetFocusedRowCellValue("COMMENT1", string.Empty);
            GridViewCruise.SetFocusedRowCellValue("COMMENT2", string.Empty);
            GridViewCruise.SetFocusedRowCellValue("COMMENT3", string.Empty);
            GridViewCruise.SetFocusedRowCellValue("COMMENT4", string.Empty);
            GridViewCruise.SetFocusedRowCellValue("OPER", string.Empty);
            GridViewCruise.SetFocusedRowCellValue("NON", string.Empty);
            GridViewCruise.SetFocusedRowCellValue("RESTR_CDE", string.Empty);
            GridViewCruise.SetFocusedRowCellValue("DEF_CABIN", string.Empty);
            GridViewCruise.SetFocusedRowCellValue("Due_Days", 0);
            GridViewCruise.SetFocusedRowCellValue("Type", string.Empty);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            GridViewCruise.ClearColumnsFilter();
            if (CruBindingSource.Current == null)
            {
                //fake query in order to create a link between the database table and the binding source
                CruBindingSource.DataSource = from opt in context.CRU where opt.CODE == "KJM9" select opt;
                CruBindingSource.AddNew();
                if (GridViewCruise.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewCruise.FocusedRowHandle = GridViewCruise.RowCount - 1;
                setValues();
                ImageComboBoxEditCode.Focus();
                setReadOnly(false);
                newRec = true;
                return;
            }
            ImageComboBoxEditCode.Focus();
            //bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewCruise.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                errorProvider1.Clear();
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CRU)CruBindingSource.Current);
                CruBindingSource.AddNew();
                if (GridViewCruise.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewCruise.FocusedRowHandle = GridViewCruise.RowCount - 1;
                setValues();
                setReadOnly(false);
                
                newRec = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
             if (CruBindingSource.Current == null)
                return;
            GridViewCruise.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                modified = false;
                newRec = false;
                CruBindingSource.RemoveCurrent();
                errorProvider1.Clear();
                context.SaveChanges();               
                GridViewCruise.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = false;
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);
            }

            currentVal = ImageComboBoxEditCode.Text;
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }

        private void cRUBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            typeTextEdit.Text = "CRU";

            if (CruBindingSource.Current == null)
                return;
            GridViewCruise.CloseEditor();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event

            ImageComboBoxEditCode.Focus();
            bool temp = newRec;
            if (checkForms())
            {
                errorProvider1.Clear();
                setReadOnly(true);
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;

            }

            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CRU)CruBindingSource.Current);
               
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (move())
                CruBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                CruBindingSource.MovePrevious();
            
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                CruBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                CruBindingSource.MoveLast();
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (CruBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CRU)CruBindingSource.Current);
                setReadOnly(true);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CRU)CruBindingSource.Current);
         
                e.Allow = false;

            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewCruise.IsFilterRow(e.RowHandle))
                modified = true;

            labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
            labelControlUpdBy.Text = username;
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            //temp = newRec;
            //if (!temp && checkForms())
            //    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CRU)CruBindingSource.Current);

            //setReadOnly(true);
        }

        private void CruiseShipForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void bUILTDateEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }      

        private void CruiseShipForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewCruise.IsFilterRow(GridViewCruise.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewCruise.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewCruise.GetFocusedDisplayText()))
                value = GridViewCruise.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.NAME like '{0}%'", GridViewCruise.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "NAME"));
                var special = context.CRU.Where(query);
              
                if (!string.IsNullOrWhiteSpace(GridViewCruise.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE")))
                {
                    query = String.Format("it.{0} like '{1}%'", "CODE", GridViewCruise.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                    special = special.Where(query);
                }

                int count = special.Count();
                if (count > 0)
                {
                    CruBindingSource.DataSource = special;
                    GridViewCruise.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewCruise.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void ImageComboBoxEditOperator_Leave(object sender, System.EventArgs e)
        {
            if (CruBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRU)CruBindingSource.Current).checkCode, CruBindingSource);
            }
        }

        private void ImageComboBoxEditCode_Leave(object sender, System.EventArgs e)
        {
            if (CruBindingSource.Current != null)
            {

                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRU)CruBindingSource.Current).checkOper, CruBindingSource);
            }
        }

        private void CruBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (CruBindingSource.Current != null)
                enableNavigator(true);
            else
                enableNavigator(false);
        }

        private void TextEditBuilt_Leave(object sender, EventArgs e)
        {

        }

     
    
        
        
    }
}