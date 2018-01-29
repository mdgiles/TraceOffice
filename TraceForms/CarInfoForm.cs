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
    
    public partial class CarInfoForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        const string colName = "colCODE";
        public FlextourEntities context;
        public string username;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public CarInfoForm(FlexInterfaces.Core.ICoreSys sys)
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
            var opr = from operRec in context.OPERATOR orderby operRec.CODE ascending select new { operRec.CODE, operRec.NAME };
            var state = from stateRec in context.State orderby stateRec.Code ascending select new { stateRec.Code, stateRec.State1 };
            var count = from countryRec in context.COUNTRY orderby countryRec.CODE ascending select new { countryRec.CODE, countryRec.NAME };
            var air = from airpRec in context.Airport orderby airpRec.Code ascending select new { airpRec.Code, airpRec.Name };
            var cty = from ctyRec in context.CITYCOD orderby ctyRec.CODE ascending select new { ctyRec.CODE, ctyRec.NAME };           
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxEditOperator.Properties.Items.Add(loadBlank);
            ImageComboBoxEditState.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCountry.Properties.Items.Add(loadBlank);
            ImageComboBoxEditAirportCode.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCity.Properties.Items.Add(loadBlank);
                     
            foreach (var result in opr)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditOperator.Properties.Items.Add(load);
            }
            foreach (var result in state)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.Code.TrimEnd() + "  " + "(" + result.State1.TrimEnd() + ")", Value = result.Code.TrimEnd() };
                ImageComboBoxEditState.Properties.Items.Add(load);
            }
            foreach (var result in count)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCountry.Properties.Items.Add(load);
            }
            foreach (var result in air)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.Code.TrimEnd() + "  " + "(" + result.Name.TrimEnd() + ")", Value = result.Code.TrimEnd() };
                ImageComboBoxEditAirportCode.Properties.Items.Add(load);
            }
            foreach (var result in cty)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCity.Properties.Items.Add(load);
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


        void setReadOnly(bool value)
        {
            cODETextEdit.Properties.ReadOnly = value;
            GridViewCarInfo.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = !(value);

        }
             

        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        private bool checkForms()
        {
            if (!modified && !newRec)
                return true;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, (( CARINFO)CarInfoBindingSource.Current).checkMain, CarInfoBindingSource);
            bool validateAccount = validCheck.checkAll(PanelControlAccountTab.Controls, errorProvider1, (( CARINFO)CarInfoBindingSource.Current).checkAccountTab, CarInfoBindingSource);
            bool validateLocation = validCheck.checkAll(PanelControlLocationTab.Controls, errorProvider1, (( CARINFO)CarInfoBindingSource.Current).checkLocationTab, CarInfoBindingSource);
            bool validateComments = validCheck.checkAll(PanelControlCommentsTab.Controls, errorProvider1, (( CARINFO)CarInfoBindingSource.Current).checkCommentsTab, CarInfoBindingSource);
            bool validateContact = validCheck.checkAll(PanelControlContactTab.Controls, errorProvider1, ((CARINFO)CarInfoBindingSource.Current).checkContactTab, CarInfoBindingSource);

            if (validateMain && validateAccount && validateLocation && validateComments && validateContact)
                return validCheck.saveRec(ref modified, true, ref newRec, context, CarInfoBindingSource, Name, errorProvider1, Cursor);
            else
                return validCheck.saveRec(ref modified, false, ref newRec, context, CarInfoBindingSource, Name, errorProvider1, Cursor);
        }   

        private bool move()
        {
            GridViewCarInfo.CloseEditor();
            cODETextEdit.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
             if (checkForms())
           {
                errorProvider1.Clear();            
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( CARINFO)CarInfoBindingSource.Current);
                setReadOnly(true);
                newRec = false;
                modified = false;
                return true;
            }
            return false;
        }

    
        private void CarInfoForm_FormClosing(object sender, FormClosingEventArgs e)
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
            GridViewCarInfo.SetFocusedRowCellValue("Type", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("CODE", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("NAME", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("AP", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("AR", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("OPERATOR", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("OPER_NAME", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("ADDR1", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("ADDR2", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("ADDR3", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("PHONE", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("TELEX", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("CONTACT", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("CONT_PHONE", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("AIRPORT", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("AIR_MI", 0);
            GridViewCarInfo.SetFocusedRowCellValue("COUNTRY", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("CITY", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("CITY_MI", 0);
            GridViewCarInfo.SetFocusedRowCellValue("CREDIT", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("COMMENT1", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("COMMENT2", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("COMMENT3", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("COMMENT4", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("RATE_BASIS", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("RSTR_CDE", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("USE_CLIENT_LOGO", "N");
            GridViewCarInfo.SetFocusedRowCellValue("VOUCH_DAYS_PRIOR", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("STATE", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("ZIP", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("TOWN", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("GMACCTNO", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("USER_DEC1", 0);
            GridViewCarInfo.SetFocusedRowCellValue("USER_DEC2", 0);
            GridViewCarInfo.SetFocusedRowCellValue("USER_INT1", 0);
            GridViewCarInfo.SetFocusedRowCellValue("USER_INT2", 0);
            GridViewCarInfo.SetFocusedRowCellValue("USER_TXT1", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("USER_TXT2", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("USER_TXT3", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("USER_TXT4", string.Empty);
            GridViewCarInfo.SetFocusedRowCellValue("Due_Days", 0);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            GridViewCarInfo.ClearColumnsFilter();
            cODETextEdit.Focus();  //trigger field leave event
            if (CarInfoBindingSource.Current == null)
            {
                //fake query in order to create a link between the database table and the binding source
                CarInfoBindingSource.DataSource = from opt in context.CARINFO where opt.CODE == "KJM9" select opt;
                CarInfoBindingSource.AddNew();
                if (GridViewCarInfo.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewCarInfo.FocusedRowHandle = GridViewCarInfo.RowCount - 1;
                setValues();
                cODETextEdit.Focus();
                setReadOnly(false);
                newRec = true;
                return;
            }
          
            GridViewCarInfo.CloseEditor();
            temp = newRec;
           if (checkForms())
            {
                errorProvider1.Clear();
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( CARINFO)CarInfoBindingSource.Current);
                CarInfoBindingSource.AddNew();
                if (GridViewCarInfo.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewCarInfo.FocusedRowHandle = GridViewCarInfo.RowCount - 1;
                setValues();
                cODETextEdit.Focus();
                setReadOnly(false);
                newRec = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (CarInfoBindingSource.Current == null)
                return;
            GridViewCarInfo.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                modified = false;
                newRec = false;
                CarInfoBindingSource.RemoveCurrent();
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
            cODETextEdit.Focus();
            currentVal = cODETextEdit.Text;
            modified = false;
            newRec = false;
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }

        private void cARINFOBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (CarInfoBindingSource.Current == null)
                return;
            GridViewCarInfo.CloseEditor();
            cODETextEdit.Focus();
           // bindingNavigatorPositionItem.Focus();//trigger field leave event
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
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CARINFO)CarInfoBindingSource.Current);
              
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (move())
                CarInfoBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                CarInfoBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                CarInfoBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                CarInfoBindingSource.MoveLast();
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (CarInfoBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CARINFO)CarInfoBindingSource.Current);
                setReadOnly(true);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CARINFO)CarInfoBindingSource.Current);
         
                e.Allow = false;

            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewCarInfo.IsFilterRow(e.RowHandle))
                modified = true;
            labelControl6.Text = DateTime.Today.ToShortDateString();
            labelControl7.Text = username;
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        { 
            temp = newRec;
            if (!temp && checkForms())
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( CARINFO)CarInfoBindingSource.Current);
            setReadOnly(true);
        }



        private void cODETextEdit_Leave(object sender, EventArgs e)
        {
            if (CarInfoBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl6.Text = DateTime.Today.ToShortDateString();
                    labelControl7.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARINFO)CarInfoBindingSource.Current).checkCode, CarInfoBindingSource);
            }
          
        }

        private void cREDITTextEdit_Leave(object sender, EventArgs e)
        {
            if (CarInfoBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl6.Text = DateTime.Today.ToShortDateString();
                    labelControl7.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARINFO)CarInfoBindingSource.Current).checkCredit, CarInfoBindingSource);
            }
        }

        private void rATE_BASISComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (CarInfoBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl6.Text = DateTime.Today.ToShortDateString();
                    labelControl7.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARINFO)CarInfoBindingSource.Current).checkRate, CarInfoBindingSource);
            }
        }

        private void rSTR_CDEComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (CarInfoBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl6.Text = DateTime.Today.ToShortDateString();
                    labelControl7.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARINFO)CarInfoBindingSource.Current).checkRest, CarInfoBindingSource);
            }
        }

        private void vOUCH_DAYS_PRIORSpinEdit_Leave(object sender, EventArgs e)
        {
            if (CarInfoBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl6.Text = DateTime.Today.ToShortDateString();
                    labelControl7.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARINFO)CarInfoBindingSource.Current).checkVouch, CarInfoBindingSource);
            }
        }

        private void pHONETextEdit_Leave(object sender, EventArgs e)
        {
            if (CarInfoBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl6.Text = DateTime.Today.ToShortDateString();
                    labelControl7.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARINFO)CarInfoBindingSource.Current).checkPhone, CarInfoBindingSource);
            }
        }

        private void cONTACTTextEdit_Leave(object sender, EventArgs e)
        {
            if (CarInfoBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl6.Text = DateTime.Today.ToShortDateString();
                    labelControl7.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARINFO)CarInfoBindingSource.Current).checkContact, CarInfoBindingSource);
            }
        }

        private void tELEXTextEdit_Leave(object sender, EventArgs e)
        {
            if (CarInfoBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl6.Text = DateTime.Today.ToShortDateString();
                    labelControl7.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARINFO)CarInfoBindingSource.Current).checkFax, CarInfoBindingSource);
            }
        }

        private void cONT_PHONETextEdit_Leave(object sender, EventArgs e)
        {
            if (CarInfoBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl6.Text = DateTime.Today.ToShortDateString();
                    labelControl7.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARINFO)CarInfoBindingSource.Current).checkConPho, CarInfoBindingSource);
            }
        }

        private void aDDR1TextEdit_Leave(object sender, EventArgs e)
        {
            if (CarInfoBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl6.Text = DateTime.Today.ToShortDateString();
                    labelControl7.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARINFO)CarInfoBindingSource.Current).checkAddress1, CarInfoBindingSource);
            }
        }

        private void aDDR2TextEdit_Leave(object sender, EventArgs e)
        {
            if (CarInfoBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl6.Text = DateTime.Today.ToShortDateString();
                    labelControl7.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARINFO)CarInfoBindingSource.Current).checkAddress2, CarInfoBindingSource);
            }
        }

        private void aDDR3TextEdit_Leave(object sender, EventArgs e)
        {
            if (CarInfoBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl6.Text = DateTime.Today.ToShortDateString();
                    labelControl7.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARINFO)CarInfoBindingSource.Current).checkAddress3, CarInfoBindingSource);
            }
        }

        private void tOWNTextEdit_Leave(object sender, EventArgs e)
        {
            if (CarInfoBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl6.Text = DateTime.Today.ToShortDateString();
                    labelControl7.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARINFO)CarInfoBindingSource.Current).checkTown, CarInfoBindingSource);
            }
        }

        private void zIPTextEdit_Leave(object sender, EventArgs e)
        {
            if (CarInfoBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl6.Text = DateTime.Today.ToShortDateString();
                    labelControl7.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARINFO)CarInfoBindingSource.Current).checkZip, CarInfoBindingSource);
            }
        }

        private void aIR_MITextEdit_Leave(object sender, EventArgs e)
        {
            if (CarInfoBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl6.Text = DateTime.Today.ToShortDateString();
                    labelControl7.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARINFO)CarInfoBindingSource.Current).checkAirMi, CarInfoBindingSource);
            }
        }

        private void cITY_MITextEdit_Leave(object sender, EventArgs e)
        {
            if (CarInfoBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl6.Text = DateTime.Today.ToShortDateString();
                    labelControl7.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARINFO)CarInfoBindingSource.Current).checkCityMi, CarInfoBindingSource);
            }
        }

        private void cOMMENT1TextEdit_Leave(object sender, EventArgs e)
        {
            if (CarInfoBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl6.Text = DateTime.Today.ToShortDateString();
                    labelControl7.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARINFO)CarInfoBindingSource.Current).checkComm1, CarInfoBindingSource);
            }
        }

        private void cOMMENT2TextEdit_Leave(object sender, EventArgs e)
        {
            if (CarInfoBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl6.Text = DateTime.Today.ToShortDateString();
                    labelControl7.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARINFO)CarInfoBindingSource.Current).checkComm2, CarInfoBindingSource);
            }
        }

        private void cOMMENT3TextEdit_Leave(object sender, EventArgs e)
        {
            if (CarInfoBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl6.Text = DateTime.Today.ToShortDateString();
                    labelControl7.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARINFO)CarInfoBindingSource.Current).checkComm3, CarInfoBindingSource);
            }
        }

        private void cOMMENT4TextEdit_Leave(object sender, EventArgs e)
        {
            if (CarInfoBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl6.Text = DateTime.Today.ToShortDateString();
                    labelControl7.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARINFO)CarInfoBindingSource.Current).checkComm4, CarInfoBindingSource);
            }
        }

        private void aPTextEdit_Leave(object sender, EventArgs e)
        {
            if (CarInfoBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl6.Text = DateTime.Today.ToShortDateString();
                    labelControl7.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARINFO)CarInfoBindingSource.Current).checkAP, CarInfoBindingSource);
            }
        }

        private void aRTextEdit_Leave(object sender, EventArgs e)
        {
            if (CarInfoBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl6.Text = DateTime.Today.ToShortDateString();
                    labelControl7.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARINFO)CarInfoBindingSource.Current).checkAR, CarInfoBindingSource);
            }
        }

        private void due_DaysTextEdit_Leave(object sender, EventArgs e)
        {
            if (CarInfoBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl6.Text = DateTime.Today.ToShortDateString();
                    labelControl7.Text = username;
                }
            }
        }

        private void nAMETextEdit_Leave_1(object sender, EventArgs e)
        {
            if (CarInfoBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl6.Text = DateTime.Today.ToShortDateString();
                    labelControl7.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARINFO)CarInfoBindingSource.Current).checkName, CarInfoBindingSource);
            }
        }

        private void CarInfoForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewCarInfo.IsFilterRow(GridViewCarInfo.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewCarInfo.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewCarInfo.GetFocusedDisplayText()))
                value = GridViewCarInfo.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.NAME like '{0}%'", GridViewCarInfo.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "NAME"));
                var special = context.CARINFO.Where(query);
              
                if (!string.IsNullOrWhiteSpace(GridViewCarInfo.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE")))
                {
                    query = String.Format("it.{0} like '{1}%'", "CODE", GridViewCarInfo.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                    special = special.Where(query);
                }
                int count = special.Count();
                if (count > 0)
                {
                    CarInfoBindingSource.DataSource = special;
                    GridViewCarInfo.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewCarInfo.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void ImageComboBoxEditOperator_Leave(object sender, EventArgs e)
        {
            if (CarInfoBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl6.Text = DateTime.Today.ToShortDateString();
                    labelControl7.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARINFO)CarInfoBindingSource.Current).checkOper, CarInfoBindingSource);

            }
        }

        private void ImageComboBoxEditState_Leave(object sender, EventArgs e)
        {
            if (CarInfoBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl6.Text = DateTime.Today.ToShortDateString();
                    labelControl7.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARINFO)CarInfoBindingSource.Current).checkState, CarInfoBindingSource);
            }
        }

        private void ImageComboBoxEditCountry_Leave(object sender, EventArgs e)
        {
            if (CarInfoBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl6.Text = DateTime.Today.ToShortDateString();
                    labelControl7.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARINFO)CarInfoBindingSource.Current).checkCountry, CarInfoBindingSource);
            }
        }

        private void ImageComboBoxEditAirportCode_Leave(object sender, EventArgs e)
        {
            if (CarInfoBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl6.Text = DateTime.Today.ToShortDateString();
                    labelControl7.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARINFO)CarInfoBindingSource.Current).checkAirport, CarInfoBindingSource);
            }
        }

        private void ImageComboBoxEditCity_Leave(object sender, EventArgs e)
        {
            if (CarInfoBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl6.Text = DateTime.Today.ToShortDateString();
                    labelControl7.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARINFO)CarInfoBindingSource.Current).checkCity, CarInfoBindingSource);
            }
        }

        private void CarInfoBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (CarInfoBindingSource.Current != null)
                enableNavigator(true);
            else
                enableNavigator(false);
        }

        private void ImageComboBoxEditOperator_SelectedValueChanged(object sender, EventArgs e)
        {           
            int index = ImageComboBoxEditOperator.Text.IndexOf(' ');
            TextEditOperName.Text = ImageComboBoxEditOperator.Text.Remove(0, index).Replace("(", "").Replace(")", "").TrimStart().TrimEnd();
        }

        private void uSE_CLIENT_LOGOCheckEdit_Click(object sender, EventArgs e)
        {
            modified = true;
        }
    }
}