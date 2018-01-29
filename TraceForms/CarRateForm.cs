using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FlexModel;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Data.Entity.Core.Objects;
using DevExpress.Xpo;
using System.Linq.Dynamic;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using System.Runtime.InteropServices;


namespace TraceForms
{
     
    public partial class CarRateForm : Form
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;       
        public FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public string username;
        public CarRateForm(FlexInterfaces.Core.ICoreSys sys)
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
            var agy = from agyRec in context.AGY orderby agyRec.NO ascending select new { agyRec.NO, agyRec.NAME };            
            var cty = from ctyRec in context.CITYCOD orderby ctyRec.CODE ascending select new { ctyRec.CODE, ctyRec.NAME };
            var cat = from catRec in context.ROOMCOD orderby catRec.CODE ascending select new { catRec.CODE, catRec.DESC };
            var car = from carRec in context.CARINFO orderby carRec.CODE ascending select new { carRec.CODE, carRec.NAME };            
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxEditCode.Properties.Items.Add(loadBlank);
            ImageComboBoxEditAgency.Properties.Items.Add(loadBlank);
            ImageComboBoxEditOffice.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCategory.Properties.Items.Add(loadBlank);
           
            foreach (var result in cty)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditOffice.Properties.Items.Add(load);
            }
            
            foreach (var result in agy)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.NO.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.NO.TrimEnd() };
                ImageComboBoxEditAgency.Properties.Items.Add(load);
            }
            foreach (var result in car)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCode.Properties.Items.Add(load);
            }
            foreach (var result in cat)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.DESC.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCategory.Properties.Items.Add(load);
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

      
        private bool move()
        {
            ImageComboBoxEditCode.Focus();
          // bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( CARRATES)CarRateBindingSource.Current);
                sTART_DATEDateEdit.Properties.ReadOnly = true;
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

        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text.ToString();
        }

        private void CarRateForm_FormClosing(object sender, FormClosingEventArgs e)
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
  
        private void setReadOnly(bool value)
        {

            ImageComboBoxEditAgency.Properties.ReadOnly = value;
            ImageComboBoxEditCode.Properties.ReadOnly = value;
            ImageComboBoxEditCategory.Properties.ReadOnly = value;
            ImageComboBoxEditOffice.Properties.ReadOnly = value;
            cOMM_PCTTextEdit.Properties.ReadOnly = value;
            sTART_DATEDateEdit.Properties.ReadOnly = value;   
        }

        private void setValues()
        {
            AdvBandedGridViewCarRate.SetFocusedRowCellValue("OFF", string.Empty);
            AdvBandedGridViewCarRate.SetFocusedRowCellValue("CODE", string.Empty);
            AdvBandedGridViewCarRate.SetFocusedRowCellValue("CAT", string.Empty);
            AdvBandedGridViewCarRate.SetFocusedRowCellValue("H_L", string.Empty);
            AdvBandedGridViewCarRate.SetFocusedRowCellValue("YEAR", string.Empty);
            AdvBandedGridViewCarRate.SetFocusedRowCellValue("DESCRIPTION", string.Empty);
            AdvBandedGridViewCarRate.SetFocusedRowCellValue("GWKLY_RATE", 0);
            AdvBandedGridViewCarRate.SetFocusedRowCellValue("GDAY_RATE", 0);
            AdvBandedGridViewCarRate.SetFocusedRowCellValue("GXTRA_RATE", 0);
            AdvBandedGridViewCarRate.SetFocusedRowCellValue("GADNL_DRVR", 0);
            AdvBandedGridViewCarRate.SetFocusedRowCellValue("GUNDR_AGE", 0);
            AdvBandedGridViewCarRate.SetFocusedRowCellValue("NWKLY_RATE", 0);
            AdvBandedGridViewCarRate.SetFocusedRowCellValue("NDAY_RATE", 0);
            AdvBandedGridViewCarRate.SetFocusedRowCellValue("NXTRA_RATE", 0);
            AdvBandedGridViewCarRate.SetFocusedRowCellValue("NADNL_DRVR", 0);
            AdvBandedGridViewCarRate.SetFocusedRowCellValue("NUNDR_AGE", 0);
            AdvBandedGridViewCarRate.SetFocusedRowCellValue("AGENCY", string.Empty);
            AdvBandedGridViewCarRate.SetFocusedRowCellValue("WKMIN_DAYS", 0);
            AdvBandedGridViewCarRate.SetFocusedRowCellValue("WKMAX_DAYS", 0);
            AdvBandedGridViewCarRate.SetFocusedRowCellValue("COMM_FLG", "N");
            AdvBandedGridViewCarRate.SetFocusedRowCellValue("COMM_PCT", 0);
           
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            AdvBandedGridViewCarRate.ClearColumnsFilter();
            if (CarRateBindingSource.Current == null)
            {
                //fake query in order to create a link between the database table and the binding source
                CarRateBindingSource.DataSource = from opt in context.CARRATES where opt.CODE == "KJM9" select opt;
                CarRateBindingSource.AddNew();
                if (AdvBandedGridViewCarRate.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    AdvBandedGridViewCarRate.FocusedRowHandle = AdvBandedGridViewCarRate.RowCount - 1;
                setValues();
                ImageComboBoxEditCode.Focus();
                setReadOnly(false);
                sTART_DATEDateEdit.Properties.ReadOnly = false;
                newRec = true;
                return;
            }
            ImageComboBoxEditCode.Focus();
          // bindingNavigatorPositionItem.Focus();  //trigger field leave event
           
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( CARRATES)CarRateBindingSource.Current);
                CarRateBindingSource.AddNew();
                if (AdvBandedGridViewCarRate.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    AdvBandedGridViewCarRate.FocusedRowHandle = AdvBandedGridViewCarRate.RowCount - 1;
                setValues();
                ImageComboBoxEditCode.Focus();

                setReadOnly(false);
                sTART_DATEDateEdit.Properties.ReadOnly = false;
                newRec = true;
            }
        }
        
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (CarRateBindingSource.Current == null)
                return;
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
               
                modified = false;
                newRec = false;
                CarRateBindingSource.RemoveCurrent();
                errorProvider1.Clear();
                context.SaveChanges();
                sTART_DATEDateEdit.Properties.ReadOnly = true;
                setReadOnly(true);
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);
            }
            ImageComboBoxEditCode.Focus();//currentVal
            currentVal = ImageComboBoxEditCode.Text;
            modified = false;
            newRec = false;
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
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((CARRATES)CarRateBindingSource.Current).checkAll, CarRateBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, CarRateBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, CarRateBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }



        private void cARRATEBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (CarRateBindingSource.Current == null)
                return;
            ImageComboBoxEditCode.Focus();
          // bindingNavigatorPositionItem.Focus();//trigger field leave event
            bool temp = newRec;
           if (checkForms())
           {
               ImageComboBoxEditCode.Focus();
                sTART_DATEDateEdit.Properties.ReadOnly = true;
                setReadOnly(true);
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
            }

           if (!temp && !modified)
               context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CARRATES)CarRateBindingSource.Current);
             
        }


        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            temp = newRec;
            if (!temp && checkForms())
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( CARRATES)CarRateBindingSource.Current);

            sTART_DATEDateEdit.Properties.ReadOnly = true;
            setReadOnly(true);
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (move())
                CarRateBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                CarRateBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                CarRateBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                CarRateBindingSource.MoveLast();
        }


        private void advBandedGridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }      

       

        private void sTART_DATEDateEdit_Leave(object sender, EventArgs e)
        {
            if (CarRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARRATES)CarRateBindingSource.Current).checkStart, CarRateBindingSource);
            }
        }

        private void eND_DATEDateEdit_Leave(object sender, EventArgs e)
        {
            if (CarRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARRATES)CarRateBindingSource.Current).checkEnd, CarRateBindingSource);
            }
        }

        private void h_LTextEdit_Leave(object sender, EventArgs e)
        {
            if (CarRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARRATES)CarRateBindingSource.Current).checkSeason, CarRateBindingSource);
            }
        }

        private void yEARComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (CarRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARRATES)CarRateBindingSource.Current).checkYear, CarRateBindingSource);
            }
        }

        private void dESCRIPTIONTextEdit_Leave(object sender, EventArgs e)
        {
            if (CarRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARRATES)CarRateBindingSource.Current).checkDesc, CarRateBindingSource);
            }
        }

        private void gWKLY_RATETextEdit_Leave(object sender, EventArgs e)
        {
            if (CarRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARRATES)CarRateBindingSource.Current).checkGrate, CarRateBindingSource);
            }
        }

        private void gDAY_RATETextEdit_Leave(object sender, EventArgs e)
        {
            if (CarRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARRATES)CarRateBindingSource.Current).checkGDrate, CarRateBindingSource);
            }
        }

        private void gXTRA_RATETextEdit_Leave(object sender, EventArgs e)
        {
            if (CarRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARRATES)CarRateBindingSource.Current).checkGXrate, CarRateBindingSource);
            }
        }

        private void gADNL_DRVRTextEdit_Leave(object sender, EventArgs e)
        {
            if (CarRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARRATES)CarRateBindingSource.Current).checkGAdriver, CarRateBindingSource);
            }
        }

        private void gUNDR_AGETextEdit_Leave(object sender, EventArgs e)
        {
            if (CarRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CARRATES)CarRateBindingSource.Current).checkGUnderAge, CarRateBindingSource);
            }
        }

        private void nWKLY_RATETextEdit_Leave(object sender, EventArgs e)
        {
            if (CarRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                if (Convert.ToDouble(gWKLY_RATETextEdit.Text) < Convert.ToDouble(nWKLY_RATETextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The net rate is higher than the gross. Is this this correct?", "Net Weekly Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be less than the gross rate.");
                        nWKLY_RATETextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CARRATES)CarRateBindingSource.Current).checkNrate, CarRateBindingSource);
            }

        }

        private void nDAY_RATETextEdit_Leave(object sender, EventArgs e)
        {
            if (CarRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                if (Convert.ToDouble(gDAY_RATETextEdit.Text) < Convert.ToDouble(nDAY_RATETextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The net rate is higher than the gross. Is this this correct?", "Net Daily Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be less than the gross rate.");
                        nDAY_RATETextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CARRATES)CarRateBindingSource.Current).checkNDrate, CarRateBindingSource);
            }

        }

        private void nXTRA_RATETextEdit_Leave(object sender, EventArgs e)
        {
            if (CarRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                if (Convert.ToDouble(gXTRA_RATETextEdit.Text) < Convert.ToDouble(nXTRA_RATETextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The net rate is higher than the gross. Is this this correct?", "Net Additional Day Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be less than the gross rate.");
                        nXTRA_RATETextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CARRATES)CarRateBindingSource.Current).checkNXrate, CarRateBindingSource);
            }

        }

        private void nADNL_DRVRTextEdit_Leave(object sender, EventArgs e)
        {
            if (CarRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                if (Convert.ToDouble(gADNL_DRVRTextEdit.Text) < Convert.ToDouble(nADNL_DRVRTextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The net rate is higher than the gross. Is this this correct?", "Net Additional Driver Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be less than the gross rate.");
                        nADNL_DRVRTextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CARRATES)CarRateBindingSource.Current).checkNAdriver, CarRateBindingSource);
            }

        }

        private void nUNDR_AGETextEdit_Leave(object sender, EventArgs e)
        {
            if (CarRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                if (Convert.ToDouble(gUNDR_AGETextEdit.Text) < Convert.ToDouble(nUNDR_AGETextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The net rate is higher than the gross. Is this this correct?", "Net Under Age Driver Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be less than the gross rate.");
                        nUNDR_AGETextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CARRATES)CarRateBindingSource.Current).checkNUnderAge, CarRateBindingSource);
            }

        }

        private void wKMIN_DAYSSpinEdit_Leave(object sender, EventArgs e)
        {
            if (CarRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARRATES)CarRateBindingSource.Current).checkComm, CarRateBindingSource);
            }
        }

        private void wKMAX_DAYSSpinEdit_Leave(object sender, EventArgs e)
        {
            if (CarRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARRATES)CarRateBindingSource.Current).checkComm, CarRateBindingSource);
            }
        }

        private void cOMM_PCTTextEdit_Leave(object sender, EventArgs e)
        {
            if (CarRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARRATES)CarRateBindingSource.Current).checkComm, CarRateBindingSource);
            }
        }

        private void overlappingRatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string code = ImageComboBoxEditCode.EditValue.ToString();
            string agency = ImageComboBoxEditAgency.EditValue.ToString();
            string cat = ImageComboBoxEditCategory.EditValue.ToString();
            string office = ImageComboBoxEditOffice.EditValue.ToString();

            var load = from c in context.CARRATES where c.CODE == code && c.AGENCY == agency && c.OFF == office && c.CAT == cat && c.START_DATE >= Convert.ToDateTime(sTART_DATEDateEdit.Text) && c.END_DATE <= Convert.ToDateTime(eND_DATEDateEdit.Text) && c.START_DATE <= Convert.ToDateTime(eND_DATEDateEdit.Text) && c.END_DATE >= Convert.ToDateTime(sTART_DATEDateEdit.Text) select c;
            if (load.Count() == 1)
                MessageBox.Show("No overlapping rate sheets exist.");
            else
            {
                gridControl2.DataSource = load;
                popupContainerControl1.Show();
            }
        }

        private void cOMM_FLGCheckEdit_CheckStateChanged(object sender, EventArgs e)
        {
            if (cOMM_FLGCheckEdit.Checked == true)
                cOMM_PCTTextEdit.Properties.ReadOnly = false;

            if (cOMM_FLGCheckEdit.Checked == false)
                cOMM_PCTTextEdit.Properties.ReadOnly = true;
        }      

        private void advBandedGridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (CarRateBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CARRATES)CarRateBindingSource.Current);
                setReadOnly(true);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CARRATES)CarRateBindingSource.Current);

                e.Allow = false;
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

        private void CarRateForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && AdvBandedGridViewCarRate.IsFilterRow(AdvBandedGridViewCarRate.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = AdvBandedGridViewCarRate.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(AdvBandedGridViewCarRate.GetFocusedDisplayText()))
                value = AdvBandedGridViewCarRate.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                //string query = String.Format("it.{0} = {1}", "Inactive", false);
                string query = String.Format("it.CAT like '{0}%'", AdvBandedGridViewCarRate.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CAT"));
                var special = context.CARRATES.Where(query);
               
                if (!string.IsNullOrWhiteSpace(AdvBandedGridViewCarRate.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE")))
                {
                    query = String.Format("it.{0} like '{1}%'", "CODE", AdvBandedGridViewCarRate.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                    special = special.Where(query);
                }
                if (!string.IsNullOrWhiteSpace(AdvBandedGridViewCarRate.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "OFF")))
                {
                    query = String.Format("it.{0} like '{1}%'", "OFF", AdvBandedGridViewCarRate.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "OFF"));
                    special = special.Where(query);
                }
                if (!string.IsNullOrWhiteSpace(AdvBandedGridViewCarRate.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "START_DATE")))
                {
                    string validDate = AdvBandedGridViewCarRate.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "START_DATE");
                    string values = validCheck.convertDate(validDate);
                    if (!string.IsNullOrWhiteSpace(values))
                    {
                        DateTime startDate = Convert.ToDateTime(values);
                        special = special.Where("it.START_DATE >= @date", new ObjectParameter("date", startDate));
                    }
                }
                int count = special.Count();
                if (count > 0)
                {
                    CarRateBindingSource.DataSource = special;
                    //AdvBandedGridViewCarRate.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                    AdvBandedGridViewCarRate.FocusedRowHandle = 0;
                    AdvBandedGridViewCarRate.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    AdvBandedGridViewCarRate.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void AdvBandedGridViewCarRate_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "START_DATE")
            {
                if (e.Value != null)
                {
                    e.DisplayText = validCheck.convertDate(e.Value.ToString());
                }
            }
        }

        private void ImageComboBoxEditCode_Leave(object sender, System.EventArgs e)
        {
            if (CarRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                
                validCheck.check(sender, errorProvider1, ((CARRATES)CarRateBindingSource.Current).checkCODE, CarRateBindingSource);
                int index = ImageComboBoxEditCode.Text.IndexOf(' ');
                dESCRIPTIONTextEdit.Text = ImageComboBoxEditCode.Text.Remove(0, index).Replace("(", "").Replace(")", "").TrimStart().TrimEnd();
            }
        }

        private void ImageComboBoxEditAgency_Leave(object sender, System.EventArgs e)
        {
            if (CarRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARRATES)CarRateBindingSource.Current).checkAgency, CarRateBindingSource);
            }
        }

        private void ImageComboBoxEditOffice_Leave(object sender, System.EventArgs e)
        {
            if (CarRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARRATES)CarRateBindingSource.Current).checkOff, CarRateBindingSource);
            }
        }

        private void ImageComboBoxEditCategory_Leave(object sender, System.EventArgs e)
        {
            if (CarRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CARRATES)CarRateBindingSource.Current).checkCAT, CarRateBindingSource);
            }
        }

        private void CarRateBindingSource_CurrentChanged(object sender, EventArgs e)
        {

            if (CarRateBindingSource.Current != null)
                enableNavigator(true);
            else
                enableNavigator(false);
        }

        private void cOMM_FLGCheckEdit_Click(object sender, EventArgs e)
        {
            modified = true;

            if (cOMM_FLGCheckEdit.Checked == true)
                cOMM_PCTTextEdit.Properties.ReadOnly = false;

            if (cOMM_FLGCheckEdit.Checked == false)
                cOMM_PCTTextEdit.Properties.ReadOnly = true;
        }

    }
}
