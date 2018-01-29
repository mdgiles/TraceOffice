using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using FlexModel;
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
   
    public partial class AirOffForm : DevExpress.XtraEditors.XtraForm
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
        public AirOffForm(FlexInterfaces.Core.ICoreSys sys)
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
            setReadOnly(true);
            var cty = from ctyRec in context.CITYCOD orderby ctyRec.CODE ascending select new { ctyRec.CODE, ctyRec.NAME };
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxEditCity.Properties.Items.Add(loadBlank);
            ImageComboBoxEditAir.Properties.Items.Add(loadBlank);
            var air = from airRec in context.AIR orderby airRec.CODE ascending select new { airRec.CODE, airRec.NAME };
            foreach (var result in air)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditAir.Properties.Items.Add(load);
            }
            foreach (var result in cty)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCity.Properties.Items.Add(load);
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

        void setReadOnly(bool value)
        {
            ImageComboBoxEditAir.Properties.ReadOnly = value;
            ImageComboBoxEditCity.Properties.ReadOnly = value;
            GridViewAirOff.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = !(value);
        }

   
     
        private bool checkForms()
        {
            if (!modified && !newRec)
                return true;

            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((AIROFF)AirOffBindingSource.Current).checkMain, AirOffBindingSource);
            bool validateMisc = validCheck.checkAll(PanelControlMiscTab.Controls, errorProvider1, (( AIROFF)AirOffBindingSource.Current).checkMiscTab, AirOffBindingSource);
            bool validateLocation = validCheck.checkAll(PanelControlLocationTab.Controls, errorProvider1, (( AIROFF)AirOffBindingSource.Current).checkLoactionTab, AirOffBindingSource);
            bool validateContact = validCheck.checkAll(PanelControlContact.Controls, errorProvider1, (( AIROFF)AirOffBindingSource.Current).checkContactTab, AirOffBindingSource);

            if ( validateMain && validateMisc && validateLocation && validateContact)
                return validCheck.saveRec(ref modified, true, ref newRec, context, AirOffBindingSource, this.Name, errorProvider1, Cursor);
            else
                return validCheck.saveRec(ref modified, false, ref newRec, context, AirOffBindingSource, this.Name, errorProvider1, Cursor);
        }

        private void setValues()
        {
            GridViewAirOff.SetFocusedRowCellValue("CODE", string.Empty);
            GridViewAirOff.SetFocusedRowCellValue("OFF", string.Empty);
            GridViewAirOff.SetFocusedRowCellValue("NAME", string.Empty);
            GridViewAirOff.SetFocusedRowCellValue("AP", string.Empty);
            GridViewAirOff.SetFocusedRowCellValue("AR", string.Empty);
            GridViewAirOff.SetFocusedRowCellValue("CONTACT", string.Empty);
            GridViewAirOff.SetFocusedRowCellValue("PHONE1", string.Empty);
            GridViewAirOff.SetFocusedRowCellValue("PHONE1_NO", string.Empty);
            GridViewAirOff.SetFocusedRowCellValue("PHONE2", string.Empty);
            GridViewAirOff.SetFocusedRowCellValue("PHONE2_NO", string.Empty);
            GridViewAirOff.SetFocusedRowCellValue("AD1", string.Empty);
            GridViewAirOff.SetFocusedRowCellValue("AD2", string.Empty);
            GridViewAirOff.SetFocusedRowCellValue("AD3", string.Empty);
            GridViewAirOff.SetFocusedRowCellValue("MISC1", string.Empty);
            GridViewAirOff.SetFocusedRowCellValue("MISC2", string.Empty);
            GridViewAirOff.SetFocusedRowCellValue("MISC3", string.Empty);
            GridViewAirOff.SetFocusedRowCellValue("MISC4", string.Empty);
            GridViewAirOff.SetFocusedRowCellValue("DATAFLEX_FILL_01", string.Empty);  
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

            GridViewAirOff.ClearColumnsFilter();
            if (AirOffBindingSource.Current == null)
            {
                //fake query in order to create a link between the database table and the binding source
                AirOffBindingSource.DataSource = from opt in context.AIROFF where opt.CODE == "KJM9" select opt;
                AirOffBindingSource.AddNew();
                if (GridViewAirOff.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewAirOff.FocusedRowHandle = GridViewAirOff.RowCount - 1;
                setValues();
                ImageComboBoxEditAir.Focus();
                setReadOnly(false);
                newRec = true;
                return;
            }
            ImageComboBoxEditAir.Focus();
           // bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewAirOff.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                errorProvider1.Clear();
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( AIROFF)AirOffBindingSource.Current);
                AirOffBindingSource.AddNew();
                if (GridViewAirOff.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewAirOff.FocusedRowHandle = GridViewAirOff.RowCount - 1;
                setValues();
                ImageComboBoxEditAir.Focus();
                setReadOnly(false);
                newRec = true;
            }
            
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (AirOffBindingSource.Current == null)
                return;
            GridViewAirOff.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                modified = false;
                newRec = false;
                AirOffBindingSource.RemoveCurrent();
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

            ImageComboBoxEditAir.Focus();
            modified = false;
            newRec = false;
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }


        private void aIROFFBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (AirOffBindingSource.Current == null)
                return;
            GridViewAirOff.CloseEditor();
            ImageComboBoxEditAir.Focus();
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
            ImageComboBoxEditAir.Focus();
            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (AIROFF)AirOffBindingSource.Current);
              
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool move()
        {
            GridViewAirOff.CloseEditor();
            ImageComboBoxEditAir.Focus();
           // bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                errorProvider1.Clear();

                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( AIROFF)AirOffBindingSource.Current);
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
                AirOffBindingSource.MoveFirst();
            
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                AirOffBindingSource.MovePrevious();
            
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                AirOffBindingSource.MoveNext();
            
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                AirOffBindingSource.MoveLast();
            
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (AirOffBindingSource.Current == null)
            {
                e.Allow = true;
                return;
            }

            temp = newRec;
            bool temp2 = modified;
            if (checkForms())
            {
                errorProvider1.Clear();
                setReadOnly(true);
                e.Allow = true;
                if ((!temp) && temp2)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (AIROFF)AirOffBindingSource.Current);


                
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (AIROFF)AirOffBindingSource.Current);

                if (modified)
                    e.Allow = false;
                else
                    e.Allow = true;

            }
        }       

       

      
   
        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            temp = newRec;
            if (!temp && checkForms())
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( AIROFF)AirOffBindingSource.Current);

            setReadOnly(true);
        }

        private void AirOffForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
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
            if (!GridViewAirOff.IsFilterRow(e.RowHandle))
                modified = true;
            labelControl2.Text = DateTime.Today.ToShortDateString();
            labelControl3.Text = username;            
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box       
        }
        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        private void cODETextEdit_Leave(object sender, EventArgs e)
        {
            if (AirOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl2.Text = DateTime.Today.ToShortDateString();
                    labelControl3.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIROFF)AirOffBindingSource.Current).checkCode, AirOffBindingSource);
            }
        }

        private void nAMETextEdit_Leave(object sender, EventArgs e)
        {
            if (AirOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl2.Text = DateTime.Today.ToShortDateString();
                    labelControl3.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIROFF)AirOffBindingSource.Current).checkName, AirOffBindingSource);
            }
        }

      

        private void aPTextEdit_Leave(object sender, EventArgs e)
        {
            if (AirOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl2.Text = DateTime.Today.ToShortDateString();
                    labelControl3.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIROFF)AirOffBindingSource.Current).checkAp, AirOffBindingSource);
            }
        }

        private void aRTextEdit_Leave(object sender, EventArgs e)
        {
            if (AirOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl2.Text = DateTime.Today.ToShortDateString();
                    labelControl3.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIROFF)AirOffBindingSource.Current).checkAr, AirOffBindingSource);
            }
        }

        private void cONTACTTextEdit_Leave(object sender, EventArgs e)
        {
            if (AirOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl2.Text = DateTime.Today.ToShortDateString();
                    labelControl3.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIROFF)AirOffBindingSource.Current).checkContact, AirOffBindingSource);
            }
        }

        private void pHONE1TextEdit_Leave(object sender, EventArgs e)
        {
            if (AirOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl2.Text = DateTime.Today.ToShortDateString();
                    labelControl3.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIROFF)AirOffBindingSource.Current).checkPho1, AirOffBindingSource);
            }
        }

        private void pHONE1_NOTextEdit_Leave(object sender, EventArgs e)
        {
            if (AirOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl2.Text = DateTime.Today.ToShortDateString();
                    labelControl3.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIROFF)AirOffBindingSource.Current).checkPhoNo1, AirOffBindingSource);
            }
        }

        private void pHONE2TextEdit_Leave(object sender, EventArgs e)
        {
            if (AirOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl2.Text = DateTime.Today.ToShortDateString();
                    labelControl3.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIROFF)AirOffBindingSource.Current).checkPho2, AirOffBindingSource);
            }
        }

        private void pHONE2_NOTextEdit_Leave(object sender, EventArgs e)
        {
            if (AirOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl2.Text = DateTime.Today.ToShortDateString();
                    labelControl3.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIROFF)AirOffBindingSource.Current).checkPhoNo2, AirOffBindingSource);
            }
        }

        private void aD1TextEdit_Leave(object sender, EventArgs e)
        {
            if (AirOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl2.Text = DateTime.Today.ToShortDateString();
                    labelControl3.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIROFF)AirOffBindingSource.Current).checkAd1, AirOffBindingSource);
            }
        }

        private void aD2TextEdit_Leave(object sender, EventArgs e)
        {
            if (AirOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl2.Text = DateTime.Today.ToShortDateString();
                    labelControl3.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIROFF)AirOffBindingSource.Current).checkAd2, AirOffBindingSource);
            }
        }

        private void aD3TextEdit_Leave(object sender, EventArgs e)
        {
            if (AirOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl2.Text = DateTime.Today.ToShortDateString();
                    labelControl3.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIROFF)AirOffBindingSource.Current).checkAd3, AirOffBindingSource);
            }
        }

        private void mISC1TextEdit_Leave(object sender, EventArgs e)
        {
            if (AirOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl2.Text = DateTime.Today.ToShortDateString();
                    labelControl3.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIROFF)AirOffBindingSource.Current).checkMisc1, AirOffBindingSource);
            }
        }

        private void mISC2TextEdit_Leave(object sender, EventArgs e)
        {
            if (AirOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl2.Text = DateTime.Today.ToShortDateString();
                    labelControl3.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIROFF)AirOffBindingSource.Current).checkMisc2, AirOffBindingSource);
            }
        }

        private void mISC3TextEdit_Leave(object sender, EventArgs e)
        {
            if (AirOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl2.Text = DateTime.Today.ToShortDateString();
                    labelControl3.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIROFF)AirOffBindingSource.Current).checkMisc3, AirOffBindingSource);
            }
        }

        private void mISC4TextEdit_Leave(object sender, EventArgs e)
        {
            if (AirOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl2.Text = DateTime.Today.ToShortDateString();
                    labelControl3.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIROFF)AirOffBindingSource.Current).checkMisc4, AirOffBindingSource);
            }
        }

        private void AirOffForm_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter && GridViewAirOff.IsFilterRow(GridViewAirOff.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewAirOff.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewAirOff.GetFocusedDisplayText()))
                value = GridViewAirOff.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.NAME like '{0}%'", GridViewAirOff.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "NAME"));
                var special = context.AIROFF.Where(query);                
                if (!string.IsNullOrWhiteSpace(GridViewAirOff.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE")))
                {
                    query = String.Format("it.{0} like '{1}%'", "CODE", GridViewAirOff.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                    special = special.Where(query);
                }     
                int count = special.Count();
                if (count > 0)
                {
                    AirOffBindingSource.DataSource = special;
                   
                    GridViewAirOff.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewAirOff.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void ImageComboBoxEditCity_Leave(object sender, System.EventArgs e)
        {
            if (AirOffBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl2.Text = DateTime.Today.ToShortDateString();
                    labelControl3.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIROFF)AirOffBindingSource.Current).checkOff, AirOffBindingSource);
            }
        }

        private void AirOffBindingSource_CurrentChanged(object sender, System.EventArgs e)
        {
            if (AirOffBindingSource.Current != null)
                enableNavigator(true);
            else
                enableNavigator(false);
        }

        
    }
}