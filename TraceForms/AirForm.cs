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
   
    public partial class AirForm : DevExpress.XtraEditors.XtraForm
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
        public AirForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
            //AirBindingSource.DataSource = context.AIR;
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

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);
            username = sys.User.Name;

        }

        void setReadOnly(bool value)
        {

            TextEditCode.Properties.ReadOnly = value;
            GridViewAir.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = !(value);

            // setReadOnly(true);
        }

        private void setValues()
        {
            GridViewAir.SetFocusedRowCellValue("CODE", string.Empty);
            GridViewAir.SetFocusedRowCellValue("MAIN_OFF", string.Empty);
            GridViewAir.SetFocusedRowCellValue("NAME", string.Empty);
            GridViewAir.SetFocusedRowCellValue("AP", string.Empty);
            GridViewAir.SetFocusedRowCellValue("AR", string.Empty);
            GridViewAir.SetFocusedRowCellValue("CONTACT", string.Empty);
            GridViewAir.SetFocusedRowCellValue("PHONE1", string.Empty);
            GridViewAir.SetFocusedRowCellValue("PHONE1_NO", string.Empty);
            GridViewAir.SetFocusedRowCellValue("PHONE2", string.Empty);
            GridViewAir.SetFocusedRowCellValue("PHONE2_NO", string.Empty);
            GridViewAir.SetFocusedRowCellValue("MAIN_AD1", string.Empty);
            GridViewAir.SetFocusedRowCellValue("MAIN_AD2", string.Empty);
            GridViewAir.SetFocusedRowCellValue("MAIN_AD3", string.Empty);
            GridViewAir.SetFocusedRowCellValue("MISC1", string.Empty);
            GridViewAir.SetFocusedRowCellValue("MISC2", string.Empty);
            GridViewAir.SetFocusedRowCellValue("MISC3", string.Empty);
            GridViewAir.SetFocusedRowCellValue("MISC4", string.Empty);
            GridViewAir.SetFocusedRowCellValue("OTHER_OFF1", string.Empty);
            GridViewAir.SetFocusedRowCellValue("OTHER_OFF2", string.Empty);
            GridViewAir.SetFocusedRowCellValue("OTHER_OFF3", string.Empty);
            GridViewAir.SetFocusedRowCellValue("RATE_BASIS", string.Empty);
            GridViewAir.SetFocusedRowCellValue("RESTR_CDE", string.Empty);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            GridViewAir.ClearColumnsFilter();
            if (AirBindingSource.Current == null)
            {
                //fake query in order to create a link between the database table and the binding source
                AirBindingSource.DataSource = from opt in context.AIR where opt.CODE == "KJM9" select opt;
                AirBindingSource.AddNew();
                if (GridViewAir.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewAir.FocusedRowHandle = GridViewAir.RowCount - 1;
                setValues();
                TextEditCode.Focus();
                setReadOnly(false);
                newRec = true;
                return;
            }
            TextEditCode.Focus();
           // bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewAir.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                errorProvider1.Clear();
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( AIR)AirBindingSource.Current);
                AirBindingSource.AddNew();
                if (GridViewAir.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewAir.FocusedRowHandle = GridViewAir.RowCount - 1;
                setValues();
                TextEditCode.Focus();
                setReadOnly(false);
                newRec = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (AirBindingSource.Current == null)
                return;
            GridViewAir.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                modified = false;
                newRec = false;
                AirBindingSource.RemoveCurrent();
                errorProvider1.Clear();
                context.SaveChanges();
                setReadOnly(true);
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);
                //bindingNavigatorPositionItem.Focus();
            }
            TextEditCode.Focus();
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
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((AIR)AirBindingSource.Current).checkMain, AirBindingSource);
            bool validateContact = validCheck.checkAll(PanelControlContactTab.Controls, errorProvider1, (( AIR)AirBindingSource.Current).checkContactTab, AirBindingSource);
            bool validateLocation = validCheck.checkAll(PanelControlLocationTab.Controls, errorProvider1, (( AIR)AirBindingSource.Current).checkLocationTab, AirBindingSource);
            bool validateMiscTab = validCheck.checkAll(PanelControlMiscTab.Controls, errorProvider1, (( AIR)AirBindingSource.Current).checkMiscTab, AirBindingSource);
            bool validateAccount = validCheck.checkAll(PanelControlAccountingTab.Controls, errorProvider1, (( AIR)AirBindingSource.Current).checkAccountTab, AirBindingSource);

            if (validateMain && validateContact && validateLocation && validateMiscTab && validateAccount)
                return validCheck.saveRec(ref modified, true, ref newRec, context, AirBindingSource, this.Name, errorProvider1, Cursor);
            else
                return validCheck.saveRec(ref modified, false, ref newRec, context, AirBindingSource, this.Name, errorProvider1, Cursor);
        }
        private void aIRBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
             if (AirBindingSource.Current == null)
                 return;
             GridViewAir.CloseEditor();
             TextEditCode.Focus();
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
            if(!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (AIR)AirBindingSource.Current);
       
        }


        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool move()
        {
            GridViewAir.CloseEditor();
            TextEditCode.Focus();
          //  bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;            
            if (checkForms())
            {
                errorProvider1.Clear();
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( AIR)AirBindingSource.Current);
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
                AirBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                AirBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                AirBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                AirBindingSource.MoveLast();
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (AirBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (AIR)AirBindingSource.Current);


                setReadOnly(true);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (AIR)AirBindingSource.Current);
       
                e.Allow = false;

            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewAir.IsFilterRow(e.RowHandle))
                modified = true;
            labelControl1.Text = DateTime.Today.ToShortDateString();
            labelControl2.Text = username;
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; 
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            temp = newRec;
            if (!temp && checkForms())
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( AIR)AirBindingSource.Current);
            setReadOnly(true);
        }

        private void AirForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        private void cODETextEdit_Leave(object sender, EventArgs e)
        {
            if (AirBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIR)AirBindingSource.Current).checkCode, AirBindingSource);
            }
        }

        private void nAMETextEdit_Leave(object sender, EventArgs e)
        {
            if (AirBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIR)AirBindingSource.Current).checkName, AirBindingSource);
            }
        }

        private void rATE_BASISComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (AirBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIR)AirBindingSource.Current).checkRate, AirBindingSource);
            }
        }

        private void rESTR_CDEComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (AirBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIR)AirBindingSource.Current).checkRest, AirBindingSource);
            }
        }

        private void pHONE1TextEdit_Leave(object sender, EventArgs e)
        {
            if (AirBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIR)AirBindingSource.Current).checkPho1, AirBindingSource);
            }
        }

        private void pHONE1_NOTextEdit_Leave(object sender, EventArgs e)
        {
            if (AirBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIR)AirBindingSource.Current).checkPhoNo1, AirBindingSource);
            }
        }

        private void pHONE2TextEdit_Leave(object sender, EventArgs e)
        {
            if (AirBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIR)AirBindingSource.Current).checkPho2, AirBindingSource);
            }
        }

        private void pHONE2_NOTextEdit_Leave(object sender, EventArgs e)
        {
            if (AirBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIR)AirBindingSource.Current).checkPhoNo2, AirBindingSource);
            }
        }

        private void mAIN_OFFTextEdit_Leave(object sender, EventArgs e)
        {
            if (AirBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIR)AirBindingSource.Current).checkMainOff, AirBindingSource);
            }
        }

        private void cONTACTTextEdit_Leave(object sender, EventArgs e)
        {
            if (AirBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIR)AirBindingSource.Current).checkContact, AirBindingSource);
            }
        }

        private void mAIN_AD1TextEdit_Leave(object sender, EventArgs e)
        {
            if (AirBindingSource.Current != null)
            {

                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIR)AirBindingSource.Current).checkMainAd1, AirBindingSource);
            }
        }

        private void mAIN_AD2TextEdit_Leave(object sender, EventArgs e)
        {
            if (AirBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIR)AirBindingSource.Current).checkMainAd2, AirBindingSource);
            }
        }

        private void mAIN_AD3TextEdit_Leave(object sender, EventArgs e)
        {
            if (AirBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIR)AirBindingSource.Current).checkMainAd3, AirBindingSource);
            }
        }

        private void oTHER_OFF1TextEdit_Leave(object sender, EventArgs e)
        {
            if (AirBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIR)AirBindingSource.Current).checkOtherOff1, AirBindingSource);
            }
        }

        private void oTHER_OFF2TextEdit_Leave(object sender, EventArgs e)
        {
            if (AirBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIR)AirBindingSource.Current).checkOtherOff2, AirBindingSource);
            }
        }

        private void oTHER_OFF3TextEdit_Leave(object sender, EventArgs e)
        {
            if (AirBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIR)AirBindingSource.Current).checkOtherOff3, AirBindingSource);
            }
        }

        private void mISC1TextEdit_Leave(object sender, EventArgs e)
        {
            if (AirBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIR)AirBindingSource.Current).checkMisc1, AirBindingSource);
            }
        }

        private void mISC2TextEdit_Leave(object sender, EventArgs e)
        {
            if (AirBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIR)AirBindingSource.Current).checkMisc2, AirBindingSource);
            }
        }

        private void mISC3TextEdit_Leave(object sender, EventArgs e)
        {
            if (AirBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIR)AirBindingSource.Current).checkMisc3, AirBindingSource);
            }
        }

        private void mISC4TextEdit_Leave(object sender, EventArgs e)
        {
            if (AirBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIR)AirBindingSource.Current).checkMisc4, AirBindingSource);
            }
        }

        private void aPTextEdit_Leave(object sender, EventArgs e)
        {
            if (AirBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIR)AirBindingSource.Current).checkAp, AirBindingSource);
            }
        }

        private void aRTextEdit_Leave(object sender, EventArgs e)
        {
            if (AirBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AIR)AirBindingSource.Current).checkAr, AirBindingSource);
            }
        }

        private void due_DaysTextEdit_Leave(object sender, EventArgs e)
        {
            if (AirBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
            }
        }

        private void AirForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewAir.IsFilterRow(GridViewAir.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewAir.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewAir.GetFocusedDisplayText()))
                value = GridViewAir.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.NAME like '{0}%'", GridViewAir.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "NAME"));
                var special = context.AIR.Where(query);
               
                if (!string.IsNullOrWhiteSpace(GridViewAir.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE")))
                {
                    query = String.Format("it.{0} like '{1}%'", "CODE", GridViewAir.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                    special = special.Where(query);
                }     
                int count = special.Count();
                if (count > 0)
                {
                    AirBindingSource.DataSource = special;
                    //GridViewAir.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                    //GridViewAir.FocusedRowHandle = 0;
                    //GridViewAir.FocusedColumn.FieldName = colName;
                    GridViewAir.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewAir.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default; 
        }

        private void AirBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (AirBindingSource.Current != null)
                enableNavigator(true);
            else
                enableNavigator(false);
        }
    }
}
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
    