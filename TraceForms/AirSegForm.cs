using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using FlexModel;
using DevExpress.XtraEditors;
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
    
    public partial class AirSegForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        const string colName = "colCODE";
        const string colName1 = "colAGENCY";
        public string username;
        public FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public AirSegForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();

            Connect(sys);
            LoadLookups();
            lockGrid(true);
           
           
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);
            username = sys.User.Name;
        }

        private void LoadLookups()
        {
            var agy = from agyRec in context.AGY orderby agyRec.NO ascending select new { agyRec.NO, agyRec.NAME };
            var opr = from operRec in context.OPERATOR orderby operRec.CODE ascending select new { operRec.CODE, operRec.NAME };
            var cat = from catRec in context.ROOMCOD orderby catRec.CODE ascending select new { catRec.CODE, catRec.DESC };
            var air = from airRec in context.AIR orderby airRec.CODE ascending select new { airRec.CODE, airRec.NAME };
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxEditOperator.Properties.Items.Add(loadBlank);
            ImageComboBoxEditAgency.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCategory.Properties.Items.Add(loadBlank);
            ImageComboBoxEditAir.Properties.Items.Add(loadBlank);

            foreach (var result in agy)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.NO.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.NO.TrimEnd() };
                ImageComboBoxEditAgency.Properties.Items.Add(load);
            }

            foreach (var result in opr)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditOperator.Properties.Items.Add(load);
            }

            foreach (var result in cat)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.DESC.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCategory.Properties.Items.Add(load);
            }
           
            foreach (var result in air)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditAir.Properties.Items.Add(load);
            }
            enableNavigator(false);
        }

        void enableNavigator(bool value)
        {
            bindingNavigatorMoveNextItem.Enabled = value;
            bindingNavigatorMoveLastItem.Enabled = value;
            bindingNavigatorMoveFirstItem.Enabled = value;
            bindingNavigatorMovePreviousItem.Enabled = value;
           
        }

        private void lockGrid(bool val)
        {           
            sEGTextEdit.Properties.ReadOnly = val;
            sTART_DATEDateEdit.Properties.ReadOnly = val;
            GridViewAirSeg.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = !(val);
            GridViewAirSeg.Columns.ColumnByName(colName1).OptionsColumn.AllowEdit = !(val);
            cOMM_PCTTextEdit.Properties.ReadOnly = val;
            ImageComboBoxEditAir.Properties.ReadOnly = val;
            ImageComboBoxEditAgency.Properties.ReadOnly = val;

        }
      
        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        private void setValues()
        {
            GridViewAirSeg.SetFocusedRowCellValue("CODE", string.Empty);
            GridViewAirSeg.SetFocusedRowCellValue("SEG", string.Empty);
            GridViewAirSeg.SetFocusedRowCellValue("CAT", string.Empty);
            GridViewAirSeg.SetFocusedRowCellValue("H_L", string.Empty);
            GridViewAirSeg.SetFocusedRowCellValue("YEAR", string.Empty);
            GridViewAirSeg.SetFocusedRowCellValue("DESC", string.Empty);
            GridViewAirSeg.SetFocusedRowCellValue("ADG_RATE", 0);
            GridViewAirSeg.SetFocusedRowCellValue("ADN_RATE", 0);
            GridViewAirSeg.SetFocusedRowCellValue("COMMENT1", string.Empty);
            GridViewAirSeg.SetFocusedRowCellValue("COMMENT2", string.Empty);
            GridViewAirSeg.SetFocusedRowCellValue("OPERATOR", string.Empty);
            GridViewAirSeg.SetFocusedRowCellValue("AGENCY", string.Empty);
            GridViewAirSeg.SetFocusedRowCellValue("COMM_FLG", string.Empty);
            GridViewAirSeg.SetFocusedRowCellValue("COMM_PCT", 0);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            GridViewAirSeg.ClearColumnsFilter();
            if (AirSegBindingSource.Current == null)
            {
                //fake query in order to create a link between the database table and the binding source
                AirSegBindingSource.DataSource = from opt in context.AIRSEG where opt.CODE == "KJM9" select opt;
                 AirSegBindingSource.AddNew();
                 if (GridViewAirSeg.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                     GridViewAirSeg.FocusedRowHandle = GridViewAirSeg.RowCount - 1;
                 setValues();
                 ImageComboBoxEditAir.Focus();                 
                 lockGrid(false);                
                 newRec = true;
                 return;
             }
            ImageComboBoxEditAir.Focus();

            // bindingNavigatorPositionItem.Focus();  //trigger field leave event
             GridViewAirSeg.CloseEditor();
             temp = newRec;
             if (checkForms())
             {                 
                 if (!temp)
                     context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (AIRSEG)AirSegBindingSource.Current);
                 AirSegBindingSource.AddNew();
                 if (GridViewAirSeg.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                     GridViewAirSeg.FocusedRowHandle = GridViewAirSeg.RowCount - 1;
                 ImageComboBoxEditAir.Focus();                
                 lockGrid(false);               
                 newRec = true;
             }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (AirSegBindingSource.Current == null)
                return;

            GridViewAirSeg.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                modified = false;
                newRec = false;
                AirSegBindingSource.RemoveCurrent();
                errorProvider1.Clear();
                context.SaveChanges();
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);
            }
            lockGrid(true);
            ImageComboBoxEditAir.Focus();
            currentVal = ImageComboBoxEditAir.Text;
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
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((AIRSEG)AirSegBindingSource.Current).checkAll, AirSegBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, AirSegBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, AirSegBindingSource, Name, errorProvider1, Cursor);
                return false;
            }        
        }

        private void aIRSEGBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (AirSegBindingSource.Current == null)
                return;
            GridViewAirSeg.CloseEditor();
            ImageComboBoxEditAir.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            bool temp = newRec;
            if (checkForms())
            {  
                lockGrid(true);
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
            }

            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (AIRSEG)AirSegBindingSource.Current);
               
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool move()
        {

            GridViewAirSeg.CloseEditor();
            ImageComboBoxEditAir.Focus();
           // bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (AIRSEG)AirSegBindingSource.Current);
              
                lockGrid(true);
                newRec = false;
                modified = false;
                return true;
            }
            return false;
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (move())
                AirSegBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                AirSegBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                AirSegBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                AirSegBindingSource.MoveLast();
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (AirSegBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (AIRSEG)AirSegBindingSource.Current);

                lockGrid(true);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (AIRSEG)AirSegBindingSource.Current);
          
                e.Allow = false;

            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewAirSeg.IsFilterRow(e.RowHandle))
                modified = true;
            labelControl17.Text = DateTime.Today.ToShortDateString();
            labelControl19.Text = username;
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            //temp = newRec;
            //if (!temp && checkForms())
            //     context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (AIRSEG)AirSegBindingSource.Current);
            
            //lockGrid(true);
        }

        private void AirSegForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void sEGTextEdit_Leave(object sender, EventArgs e)
        {
            if (AirSegBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl17.Text = DateTime.Today.ToShortDateString();
                    labelControl19.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIRSEG)AirSegBindingSource.Current).checkSeg, AirSegBindingSource);
            }
        }       

        private void sTART_DATEDateEdit_Leave(object sender, EventArgs e)
        {
            if (AirSegBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl17.Text = DateTime.Today.ToShortDateString();
                    labelControl19.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIRSEG)AirSegBindingSource.Current).checkStart, AirSegBindingSource);
            }
        }

        private void eND_DATEDateEdit_Leave(object sender, EventArgs e)
        {
            if (AirSegBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl17.Text = DateTime.Today.ToShortDateString();
                    labelControl19.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIRSEG)AirSegBindingSource.Current).checkEnd, AirSegBindingSource);
            }
        }

        private void h_LTextEdit_Leave(object sender, EventArgs e)
        {
            if (AirSegBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl17.Text = DateTime.Today.ToShortDateString();
                    labelControl19.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIRSEG)AirSegBindingSource.Current).checkSeason, AirSegBindingSource);
            }
        }

        private void yEARComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (AirSegBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl17.Text = DateTime.Today.ToShortDateString();
                    labelControl19.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIRSEG)AirSegBindingSource.Current).checkYear, AirSegBindingSource);
            }
        }

        private void dESCTextEdit_Leave(object sender, EventArgs e)
        {
            if (AirSegBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl17.Text = DateTime.Today.ToShortDateString();
                    labelControl19.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIRSEG)AirSegBindingSource.Current).checkRate, AirSegBindingSource);
            }
        }

        private void aDG_RATETextEdit_Leave(object sender, EventArgs e)
        {
            if (AirSegBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl17.Text = DateTime.Today.ToShortDateString();
                    labelControl19.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIRSEG)AirSegBindingSource.Current).checkGross, AirSegBindingSource);
            }
        }

        private void aDN_RATETextEdit_Leave(object sender, EventArgs e)
        {
            if (AirSegBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl17.Text = DateTime.Today.ToShortDateString();
                    labelControl19.Text = username;
                }
                if (Convert.ToInt32(aDG_RATETextEdit.Text) < Convert.ToInt32(aDN_RATETextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The net rate is higher than the gross. Is this this correct?", "Net Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be less than the gross rate.");
                        aDN_RATETextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((AIRSEG)AirSegBindingSource.Current).checkNet, AirSegBindingSource);
            }
        }

        private void cOMM_PCTTextEdit_Leave(object sender, EventArgs e)
        {
            if (AirSegBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl17.Text = DateTime.Today.ToShortDateString();
                    labelControl19.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIRSEG)AirSegBindingSource.Current).checkComm, AirSegBindingSource);
            }
        }

        private void cOMMENT1TextEdit_Leave(object sender, EventArgs e)
        {
            if (AirSegBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl17.Text = DateTime.Today.ToShortDateString();
                    labelControl19.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIRSEG)AirSegBindingSource.Current).checkComm1, AirSegBindingSource);
            }
        }

        private void cOMMENT2TextEdit_Leave(object sender, EventArgs e)
        {
            if (AirSegBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl17.Text = DateTime.Today.ToShortDateString();
                    labelControl19.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIRSEG)AirSegBindingSource.Current).checkComm2, AirSegBindingSource);
            }
        }

        private void cOMM_FLGCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (cOMM_FLGCheckEdit.Checked == true)
                cOMM_PCTTextEdit.Properties.ReadOnly = false;

            if (cOMM_FLGCheckEdit.Checked == false)
                cOMM_PCTTextEdit.Properties.ReadOnly = true;            
        }

        private void overlappingRatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string agency = ImageComboBoxEditAgency.EditValue.ToString();
            string air = ImageComboBoxEditAir.EditValue.ToString();
            string cat = ImageComboBoxEditCategory.EditValue.ToString();

            var load = from c in context.AIRSEG where c.CODE == air && c.AGENCY == agency && c.SEG == sEGTextEdit.Text && c.CAT == cat && c.START_DATE >= Convert.ToDateTime(sTART_DATEDateEdit.Text) && c.END_DATE <= Convert.ToDateTime(eND_DATEDateEdit.Text) && c.START_DATE <= Convert.ToDateTime(eND_DATEDateEdit.Text) && c.END_DATE >= Convert.ToDateTime(sTART_DATEDateEdit.Text) select c;
            if (load.Count() == 0)
                MessageBox.Show("No overlapping rate sheets exist.");
            else
            {
                gridControl2.DataSource = load;
                popupContainerControl1.Show();
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

        private void AirSegForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewAirSeg.IsFilterRow(GridViewAirSeg.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewAirSeg.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewAirSeg.GetFocusedDisplayText()))
                value = GridViewAirSeg.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.CAT like '{0}%'", GridViewAirSeg.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CAT"));
                var special = context.AIRSEG.Where(query);
                
                if (!string.IsNullOrWhiteSpace(GridViewAirSeg.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE")))
                {
                    query = String.Format("it.{0} like '{1}%'", "CODE", GridViewAirSeg.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                    special = special.Where(query);
                }
                if (!string.IsNullOrWhiteSpace(GridViewAirSeg.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "SEG")))
                {
                    query = String.Format("it.{0} like '{1}%'", "SEG", GridViewAirSeg.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "SEG"));
                    special = special.Where(query);
                }
                int count = special.Count();
                if (count > 0)
                {
                    AirSegBindingSource.DataSource = special;
                   
                    GridViewAirSeg.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewAirSeg.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void ImageComboBoxEditAir_Leave(object sender, System.EventArgs e)
        {
            if (AirSegBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl17.Text = DateTime.Today.ToShortDateString();
                    labelControl19.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIRSEG)AirSegBindingSource.Current).checkCode, AirSegBindingSource);
            }
           
        }

        private void ImageComboBoxEditAgency_Leave(object sender, System.EventArgs e)
        {
            if (AirSegBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl17.Text = DateTime.Today.ToShortDateString();
                    labelControl19.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIRSEG)AirSegBindingSource.Current).checkAgency, AirSegBindingSource);


            }
            
        }

        private void ImageComboBoxEditOperator_Leave(object sender, System.EventArgs e)
        {
            if (AirSegBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl17.Text = DateTime.Today.ToShortDateString();
                    labelControl19.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIRSEG)AirSegBindingSource.Current).checkOper, AirSegBindingSource);
            }
        }

        private void ImageComboBoxEditCategory_Leave(object sender, System.EventArgs e)
        {
            if (AirSegBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl17.Text = DateTime.Today.ToShortDateString();
                    labelControl19.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIRSEG)AirSegBindingSource.Current).checkCat, AirSegBindingSource);
            }
        }

        private void AirSegBindingSource_CurrentChanged(object sender, System.EventArgs e)
        {
            if (AirSegBindingSource.Current != null)
                enableNavigator(true);
            else
                enableNavigator(false);
        }

     
    }
}