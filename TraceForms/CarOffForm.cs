using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using FlexModel;
using DevExpress.XtraEditors.Controls;
using System.Linq;
using FlexCore;
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
    
    public partial class CarOffForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        const string colName = "colCODE";
        public  FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public string username;
        public CarOffForm(FlexInterfaces.Core.ICoreSys sys)
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
            var car = from carRec in context.CARINFO orderby carRec.CODE ascending select new { carRec.CODE, carRec.NAME };
            var state = from stateRec in context.State orderby stateRec.Code ascending select new { stateRec.Code, stateRec.State1 };
            var count = from countryRec in context.COUNTRY orderby countryRec.CODE ascending select new { countryRec.CODE, countryRec.NAME };
            var air = from airpRec in context.Airport orderby airpRec.Code ascending select new { airpRec.Code, airpRec.Name };
            var cty = from ctyRec in context.CITYCOD orderby ctyRec.CODE ascending select new { ctyRec.CODE, ctyRec.NAME };
            var reg = from regRec in context.REGION orderby regRec.CODE ascending select new { regRec.CODE, regRec.DESC };
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxEditOffice.Properties.Items.Add(loadBlank);
            ImageComboBoxEditState.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCountry.Properties.Items.Add(loadBlank);
            ImageComboBoxEditAirportCode.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCity.Properties.Items.Add(loadBlank);
            ImageComboBoxEditRegion.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCode.Properties.Items.Add(loadBlank);

            foreach (var result in car)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCode.Properties.Items.Add(load);
            }


            foreach (var result in reg)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.DESC.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditRegion.Properties.Items.Add(load);
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
                ImageComboBoxEditOffice.Properties.Items.Add(load);
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
            ImageComboBoxEditCode.Properties.ReadOnly = value;
            ImageComboBoxEditOffice.Properties.ReadOnly = value;
            GridViewCarOff.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = !(value);
        }

      
        private bool checkForms()
        {
            if (!modified && !newRec)
                return true;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, (( CAROFF)CarOffBindingSource.Current).checkMain, CarOffBindingSource);
            bool validateContact = validCheck.checkAll(PanelControlContactTab.Controls, errorProvider1, (( CAROFF)CarOffBindingSource.Current).checkContactTab, CarOffBindingSource);
            bool validateLocation = validCheck.checkAll(PanelControlLocationTab.Controls, errorProvider1, (( CAROFF)CarOffBindingSource.Current).checkLocationTab, CarOffBindingSource);
            bool validateComments = validCheck.checkAll(PanelControlCommentsTab.Controls, errorProvider1, (( CAROFF)CarOffBindingSource.Current).checkCommentsTab, CarOffBindingSource);           

            if (validateMain && validateContact && validateLocation && validateComments )
                return validCheck.saveRec(ref modified, true, ref newRec, context, CarOffBindingSource, Name, errorProvider1, Cursor);
            else
                return validCheck.saveRec(ref modified, false, ref newRec, context, CarOffBindingSource, Name, errorProvider1, Cursor);
        }
   
    
        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        private bool move()
        {
            GridViewCarOff.CloseEditor();
            ImageComboBoxEditCode.Focus();
           // bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                errorProvider1.Clear();
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( CAROFF)CarOffBindingSource.Current);
                setReadOnly(true);
                newRec = false;
                modified = false;
                return true;
            }
            return false;
        }
     
        void ButtonEdit_QueryPopUp1(object sender, CancelEventArgs e)
        {
            e.Cancel = false;          
        }

        private void setValues()
        {
            GridViewCarOff.SetFocusedRowCellValue("OFF", string.Empty);
            GridViewCarOff.SetFocusedRowCellValue("CODE", string.Empty);
            GridViewCarOff.SetFocusedRowCellValue("NAME", string.Empty);
            GridViewCarOff.SetFocusedRowCellValue("AP", string.Empty);
            GridViewCarOff.SetFocusedRowCellValue("AR", string.Empty);
            GridViewCarOff.SetFocusedRowCellValue("CONTACT", string.Empty);
            GridViewCarOff.SetFocusedRowCellValue("PHONE1", string.Empty);
            GridViewCarOff.SetFocusedRowCellValue("PHONE1_NO", string.Empty);
            GridViewCarOff.SetFocusedRowCellValue("PHONE2", string.Empty);
            GridViewCarOff.SetFocusedRowCellValue("PHONE2_NO", string.Empty);
            GridViewCarOff.SetFocusedRowCellValue("ADDR1", string.Empty);
            GridViewCarOff.SetFocusedRowCellValue("ADDR2", string.Empty);
            GridViewCarOff.SetFocusedRowCellValue("ADDR3", string.Empty);            
            GridViewCarOff.SetFocusedRowCellValue("AIRPORT", string.Empty);
            GridViewCarOff.SetFocusedRowCellValue("AIR_MI", 0);
            GridViewCarOff.SetFocusedRowCellValue("COUNTRY", string.Empty);
            GridViewCarOff.SetFocusedRowCellValue("CITY", string.Empty);
            GridViewCarOff.SetFocusedRowCellValue("CITY_MI", 0);
            GridViewCarOff.SetFocusedRowCellValue("MISC1", string.Empty);
            GridViewCarOff.SetFocusedRowCellValue("MISC2", string.Empty);
            GridViewCarOff.SetFocusedRowCellValue("MISC3", string.Empty);
            GridViewCarOff.SetFocusedRowCellValue("MISC4", string.Empty);   
            GridViewCarOff.SetFocusedRowCellValue("REGION", string.Empty);
            GridViewCarOff.SetFocusedRowCellValue("LATITUDE", string.Empty);            
            GridViewCarOff.SetFocusedRowCellValue("LONGITUDE", string.Empty);
            GridViewCarOff.SetFocusedRowCellValue("STATE", string.Empty);
            GridViewCarOff.SetFocusedRowCellValue("ZIP", string.Empty);
            GridViewCarOff.SetFocusedRowCellValue("TOWN", string.Empty);
            GridViewCarOff.SetFocusedRowCellValue("GMACCTNO", string.Empty);
            GridViewCarOff.SetFocusedRowCellValue("USER_DEC1", 0);
            GridViewCarOff.SetFocusedRowCellValue("USER_DEC2", 0);
            GridViewCarOff.SetFocusedRowCellValue("USER_INT1", 0);
            GridViewCarOff.SetFocusedRowCellValue("USER_INT2", 0);
            GridViewCarOff.SetFocusedRowCellValue("USER_TXT1", string.Empty);
            GridViewCarOff.SetFocusedRowCellValue("USER_TXT2", string.Empty);
            GridViewCarOff.SetFocusedRowCellValue("USER_TXT3", string.Empty);
            GridViewCarOff.SetFocusedRowCellValue("USER_TXT4", string.Empty);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            GridViewCarOff.ClearColumnsFilter();
            if (CarOffBindingSource.Current == null)
            {
                //fake query in order to create a link between the database table and the binding source
                CarOffBindingSource.DataSource = from opt in context.CAROFF where opt.CODE == "KJM9" select opt;
                CarOffBindingSource.AddNew();
                if (GridViewCarOff.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewCarOff.FocusedRowHandle = GridViewCarOff.RowCount - 1;
                setValues();
                ImageComboBoxEditCode.Focus();
                setReadOnly(false);
                newRec = true;
                return;
            }
            ImageComboBoxEditCode.Focus();
            //bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewCarOff.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                errorProvider1.Clear();
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( CAROFF)CarOffBindingSource.Current);
                CarOffBindingSource.AddNew();
                if (GridViewCarOff.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewCarOff.FocusedRowHandle = GridViewCarOff.RowCount - 1;
                setValues();
                ImageComboBoxEditCode.Focus();
                setReadOnly(false);
                newRec = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (CarOffBindingSource.Current == null)
                return;
            GridViewCarOff.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                modified = false;
                newRec = false;
                CarOffBindingSource.RemoveCurrent();
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
            ImageComboBoxEditCode.Focus();
            currentVal = ImageComboBoxEditCode.Text;
            modified = false;
            newRec = false;
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }


        private void cAROFFBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (CarOffBindingSource.Current == null)
                return;
            GridViewCarOff.CloseEditor();
            ImageComboBoxEditCode.Focus();
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
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CAROFF)CarOffBindingSource.Current);
           
        }


        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (move())
                CarOffBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                CarOffBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                CarOffBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                CarOffBindingSource.MoveLast();
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (CarOffBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CAROFF)CarOffBindingSource.Current);
                setReadOnly(true);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CAROFF)CarOffBindingSource.Current);
         
                e.Allow = false;
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewCarOff.IsFilterRow(e.RowHandle))
                modified = true;
            labelControl4.Text = DateTime.Today.ToShortDateString();
            labelControl5.Text = username;
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }

        private void CarOffForm_FormClosing(object sender, FormClosingEventArgs e)
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
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( CAROFF)CarOffBindingSource.Current);
            setReadOnly(true);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string state = ImageComboBoxEditState.EditValue.ToString();
            string country = ImageComboBoxEditCountry.EditValue.ToString();
            Uri mapUri = new Uri(new Uri("http://www.bing.com/"), "maps/default.aspx?where1=" + aDDR1TextEdit.Text + "%20" + aDDR2TextEdit.Text + "%20" + aDDR3TextEdit.Text + ",%20" + tOWNTextEdit.Text + ",%20" + state + ",%20" + country + "&v=2");
            Form map = new TraceForms.WebBrowser(mapUri) { MdiParent = this.ParentForm };
            map.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Uri mapUri = new Uri(new Uri("http://www.bing.com/"), "maps/default.aspx?where1=" + lATITUDETextEdit.Text + ",%20" + lONGITUDETextEdit.Text + "&v=2");
            Form map = new TraceForms.WebBrowser(mapUri) { MdiParent = this.ParentForm };
            map.Show();
        }

        private void mISC1TextEdit_Leave(object sender, EventArgs e)
        {
            if (CarOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl4.Text = DateTime.Today.ToShortDateString();
                    labelControl5.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CAROFF)CarOffBindingSource.Current).checkComm1, CarOffBindingSource);
            }
        }

        private void mISC2TextEdit_Leave(object sender, EventArgs e)
        {
            if (CarOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl4.Text = DateTime.Today.ToShortDateString();
                    labelControl5.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CAROFF)CarOffBindingSource.Current).checkComm2, CarOffBindingSource);
            }
        }

        private void mISC3TextEdit_Leave(object sender, EventArgs e)
        {
            if (CarOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl4.Text = DateTime.Today.ToShortDateString();
                    labelControl5.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CAROFF)CarOffBindingSource.Current).checkComm3, CarOffBindingSource);
            }
        }

        private void mISC4TextEdit_Leave(object sender, EventArgs e)
        {
            if (CarOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl4.Text = DateTime.Today.ToShortDateString();
                    labelControl5.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CAROFF)CarOffBindingSource.Current).checkComm4, CarOffBindingSource);
            }
        }

        private void aDDR1TextEdit_Leave(object sender, EventArgs e)
        {
            if (CarOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl4.Text = DateTime.Today.ToShortDateString();
                    labelControl5.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CAROFF)CarOffBindingSource.Current).checkAddress1, CarOffBindingSource);
            }
        }

        private void aDDR2TextEdit_Leave(object sender, EventArgs e)
        {
            if (CarOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl4.Text = DateTime.Today.ToShortDateString();
                    labelControl5.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CAROFF)CarOffBindingSource.Current).checkAddress2, CarOffBindingSource);
            }
        }

        private void aDDR3TextEdit_Leave(object sender, EventArgs e)
        {
            if (CarOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl4.Text = DateTime.Today.ToShortDateString();
                    labelControl5.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CAROFF)CarOffBindingSource.Current).checkAddress3, CarOffBindingSource);
            }
        }

        private void tOWNTextEdit_Leave(object sender, EventArgs e)
        {
            if (CarOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl4.Text = DateTime.Today.ToShortDateString();
                    labelControl5.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CAROFF)CarOffBindingSource.Current).checkTown, CarOffBindingSource);
            }
        }

        private void zIPTextEdit_Leave(object sender, EventArgs e)
        {
            if (CarOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl4.Text = DateTime.Today.ToShortDateString();
                    labelControl5.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CAROFF)CarOffBindingSource.Current).checkZip, CarOffBindingSource);
            }
        }

        private void aIR_MITextEdit_Leave(object sender, EventArgs e)
        {
            if (CarOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl4.Text = DateTime.Today.ToShortDateString();
                    labelControl5.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CAROFF)CarOffBindingSource.Current).checkAirMi, CarOffBindingSource);
            }
        }

        private void cITY_MITextEdit_Leave(object sender, EventArgs e)
        {
            if (CarOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl4.Text = DateTime.Today.ToShortDateString();
                    labelControl5.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CAROFF)CarOffBindingSource.Current).checkCityMi, CarOffBindingSource);
            }
        }

        private void lATITUDETextEdit_Leave(object sender, EventArgs e)
        {
            if (CarOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl4.Text = DateTime.Today.ToShortDateString();
                    labelControl5.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CAROFF)CarOffBindingSource.Current).checkLatitude, CarOffBindingSource);
            }
        }

        private void lONGITUDETextEdit_Leave(object sender, EventArgs e)
        {
            if (CarOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl4.Text = DateTime.Today.ToShortDateString();
                    labelControl5.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CAROFF)CarOffBindingSource.Current).checkLongitude, CarOffBindingSource);
            }
        }

        private void cONTACTTextEdit_Leave(object sender, EventArgs e)
        {
            if (CarOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl4.Text = DateTime.Today.ToShortDateString();
                    labelControl5.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CAROFF)CarOffBindingSource.Current).checkContact, CarOffBindingSource);
            }
        }

        private void pHONE1TextEdit_Leave(object sender, EventArgs e)
        {
            if (CarOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl4.Text = DateTime.Today.ToShortDateString();
                    labelControl5.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CAROFF)CarOffBindingSource.Current).checkPhone1, CarOffBindingSource);
            }
        }

        private void pHONE1_NOTextEdit_Leave(object sender, EventArgs e)
        {
            if (CarOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl4.Text = DateTime.Today.ToShortDateString();
                    labelControl5.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CAROFF)CarOffBindingSource.Current).checkPhoneNo1, CarOffBindingSource);
            }
        }

        private void pHONE2TextEdit_Leave(object sender, EventArgs e)
        {
            if (CarOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl4.Text = DateTime.Today.ToShortDateString();
                    labelControl5.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CAROFF)CarOffBindingSource.Current).checkPhone2, CarOffBindingSource);
            }
        }

        private void pHONE2_NOTextEdit_Leave(object sender, EventArgs e)
        {
            if (CarOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl4.Text = DateTime.Today.ToShortDateString();
                    labelControl5.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CAROFF)CarOffBindingSource.Current).checkPhoneNo2, CarOffBindingSource);
            }
        }

        private void aPTextEdit_Leave(object sender, EventArgs e)
        {
            if (CarOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl4.Text = DateTime.Today.ToShortDateString();
                    labelControl5.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CAROFF)CarOffBindingSource.Current).checkAP, CarOffBindingSource);
            }
        }

        private void aRTextEdit_Leave(object sender, EventArgs e)
        {
            if (CarOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl4.Text = DateTime.Today.ToShortDateString();
                    labelControl5.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CAROFF)CarOffBindingSource.Current).checkAR, CarOffBindingSource);
            }
        }

        private void nAMETextEdit_Leave(object sender, EventArgs e)
        {
            if (CarOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl4.Text = DateTime.Today.ToShortDateString();
                    labelControl5.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CAROFF)CarOffBindingSource.Current).checkName, CarOffBindingSource);
            }
        }

        private void CarOffForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewCarOff.IsFilterRow(GridViewCarOff.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewCarOff.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewCarOff.GetFocusedDisplayText()))
                value = GridViewCarOff.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.NAME like '{0}%'", GridViewCarOff.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "NAME"));
                var special = context.CAROFF.Where(query);
              
                if (!string.IsNullOrWhiteSpace(GridViewCarOff.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE")))
                {
                    query = String.Format("it.{0} like '{1}%'", "CODE", GridViewCarOff.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                    special = special.Where(query);
                }
                int count = special.Count();
                if (count > 0)
                {
                    CarOffBindingSource.DataSource = special;
                    GridViewCarOff.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewCarOff.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void ImageComboBoxEditCode_Leave(object sender, System.EventArgs e)
        {
            if (CarOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl4.Text = DateTime.Today.ToShortDateString();
                    labelControl5.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CAROFF)CarOffBindingSource.Current).checkCode, CarOffBindingSource);

            }
        }

        private void ImageComboBoxEditOffice_Leave(object sender, System.EventArgs e)
        {
            if (CarOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl4.Text = DateTime.Today.ToShortDateString();
                    labelControl5.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CAROFF)CarOffBindingSource.Current).checkOff, CarOffBindingSource);

            }
        }

        private void ImageComboBoxEditState_Leave(object sender, System.EventArgs e)
        {
            if (CarOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl4.Text = DateTime.Today.ToShortDateString();
                    labelControl5.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CAROFF)CarOffBindingSource.Current).checkState, CarOffBindingSource);

            }
        }

        private void ImageComboBoxEditRegion_Leave(object sender, System.EventArgs e)
        {
            if (CarOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl4.Text = DateTime.Today.ToShortDateString();
                    labelControl5.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CAROFF)CarOffBindingSource.Current).checkRegion, CarOffBindingSource);

            }
        }

        private void ImageComboBoxEditCountry_Leave(object sender, System.EventArgs e)
        {
            if (CarOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl4.Text = DateTime.Today.ToShortDateString();
                    labelControl5.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CAROFF)CarOffBindingSource.Current).checkCountry, CarOffBindingSource);

            }
        }

        private void ImageComboBoxEditAirportCode_Leave(object sender, System.EventArgs e)
        {
            if (CarOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl4.Text = DateTime.Today.ToShortDateString();
                    labelControl5.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CAROFF)CarOffBindingSource.Current).checkAirport, CarOffBindingSource);

            }
        }

        private void ImageComboBoxEditCity_Leave(object sender, System.EventArgs e)
        {
            if (CarOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl4.Text = DateTime.Today.ToShortDateString();
                    labelControl5.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CAROFF)CarOffBindingSource.Current).checkCity, CarOffBindingSource);

            }
        }

        private void CarOffBindingSource_CurrentChanged(object sender, System.EventArgs e)
        {
            if (CarOffBindingSource.Current != null)
                enableNavigator(true);
            else
                enableNavigator(false);
        }
    }
}