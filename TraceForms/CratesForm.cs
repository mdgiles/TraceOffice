using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using FlexModel;
using System.Data.Entity.Core.Objects;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using System.Linq;
using System.Linq.Dynamic;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
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
   
    public partial class CratesForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        const string colName1 = "colCode";
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public FlextourEntities context;
        public string username;
        public CratesForm(FlexInterfaces.Core.ICoreSys sys)
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
            var crates = from carRec in context.CRU orderby carRec.CODE ascending select new { carRec.CODE, carRec.NAME };
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxEditCode.Properties.Items.Add(loadBlank);
            ImageComboBoxEditAgency.Properties.Items.Add(loadBlank);           
             

            foreach (var result in agy)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.NO.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.NO.TrimEnd() };
                ImageComboBoxEditAgency.Properties.Items.Add(load);
            }
            foreach (var result in crates)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCode.Properties.Items.Add(load);
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


        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        private void setValues()
        {
            GridViewCrates.SetFocusedRowCellValue("CODE", string.Empty);
            GridViewCrates.SetFocusedRowCellValue("ITIN", string.Empty);
            GridViewCrates.SetFocusedRowCellValue("H_L", string.Empty);
            GridViewCrates.SetFocusedRowCellValue("YEAR", string.Empty);
            GridViewCrates.SetFocusedRowCellValue("TP1", 0);
            GridViewCrates.SetFocusedRowCellValue("DESC1", string.Empty);            
            GridViewCrates.SetFocusedRowCellValue("GRATE1", 0);
            GridViewCrates.SetFocusedRowCellValue("NRATE1", 0);
            GridViewCrates.SetFocusedRowCellValue("TP1", 0);
            GridViewCrates.SetFocusedRowCellValue("DESC1", string.Empty);
            GridViewCrates.SetFocusedRowCellValue("GRATE1", 0);
            GridViewCrates.SetFocusedRowCellValue("NRATE1", 0);   
            GridViewCrates.SetFocusedRowCellValue("TP2", 0);
            GridViewCrates.SetFocusedRowCellValue("DESC2", string.Empty);
            GridViewCrates.SetFocusedRowCellValue("GRATE2", 0);
            GridViewCrates.SetFocusedRowCellValue("NRATE2", 0);
            GridViewCrates.SetFocusedRowCellValue("TP3", 0);
            GridViewCrates.SetFocusedRowCellValue("DESC3", string.Empty);
            GridViewCrates.SetFocusedRowCellValue("GRATE3", 0);
            GridViewCrates.SetFocusedRowCellValue("NRATE3", 0);
            GridViewCrates.SetFocusedRowCellValue("TP4", 0);
            GridViewCrates.SetFocusedRowCellValue("DESC4", string.Empty);
            GridViewCrates.SetFocusedRowCellValue("GRATE4", 0);
            GridViewCrates.SetFocusedRowCellValue("NRATE4", 0);
            GridViewCrates.SetFocusedRowCellValue("TP5", 0);
            GridViewCrates.SetFocusedRowCellValue("DESC5", string.Empty);
            GridViewCrates.SetFocusedRowCellValue("GRATE5", 0);
            GridViewCrates.SetFocusedRowCellValue("NRATE5", 0);
            GridViewCrates.SetFocusedRowCellValue("TP6", 0);
            GridViewCrates.SetFocusedRowCellValue("DESC6", string.Empty);
            GridViewCrates.SetFocusedRowCellValue("GRATE6", 0);
            GridViewCrates.SetFocusedRowCellValue("NRATE6", 0);
            GridViewCrates.SetFocusedRowCellValue("TP7", 0);
            GridViewCrates.SetFocusedRowCellValue("DESC7", string.Empty);
            GridViewCrates.SetFocusedRowCellValue("GRATE7", 0);
            GridViewCrates.SetFocusedRowCellValue("NRATE7", 0);
            GridViewCrates.SetFocusedRowCellValue("TP8", 0);
            GridViewCrates.SetFocusedRowCellValue("DESC8", string.Empty);
            GridViewCrates.SetFocusedRowCellValue("GRATE8", 0);
            GridViewCrates.SetFocusedRowCellValue("NRATE8", 0);
            GridViewCrates.SetFocusedRowCellValue("TP9", 0);
            GridViewCrates.SetFocusedRowCellValue("DESC9", string.Empty);
            GridViewCrates.SetFocusedRowCellValue("GRATE9", 0);
            GridViewCrates.SetFocusedRowCellValue("NRATE9", 0);
            GridViewCrates.SetFocusedRowCellValue("TP10", 0);
            GridViewCrates.SetFocusedRowCellValue("DESC10", string.Empty);
            GridViewCrates.SetFocusedRowCellValue("GRATE10", 0);
            GridViewCrates.SetFocusedRowCellValue("NRATE10", 0);
            GridViewCrates.SetFocusedRowCellValue("TP11", 0);
            GridViewCrates.SetFocusedRowCellValue("DESC11", string.Empty);
            GridViewCrates.SetFocusedRowCellValue("GRATE11", 0);
            GridViewCrates.SetFocusedRowCellValue("NRATE11", 0);
            GridViewCrates.SetFocusedRowCellValue("TP12", 0);
            GridViewCrates.SetFocusedRowCellValue("DESC12", string.Empty);
            GridViewCrates.SetFocusedRowCellValue("GRATE12", 0);
            GridViewCrates.SetFocusedRowCellValue("NRATE12", 0);
            GridViewCrates.SetFocusedRowCellValue("AGENCY", string.Empty);           
            GridViewCrates.SetFocusedRowCellValue("COMM_FLG", string.Empty);
            GridViewCrates.SetFocusedRowCellValue("COMM_PCT", 0);
        }

       

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            GridViewCrates.ClearColumnsFilter();
            if (CRatesBindingSource.Current == null)
            {
                //fake query in order to create a link between the database table and the binding source
                CRatesBindingSource.DataSource = from opt in context.CRATES where opt.CODE == "KJM9" select opt;
                CRatesBindingSource.AddNew();
                if (GridViewCrates.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewCrates.FocusedRowHandle = GridViewCrates.RowCount - 1;
                setValues();
                ImageComboBoxEditCode.Focus();                
                newRec = true;
                return;
            }
            ImageComboBoxEditCode.Focus();
            //bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewCrates.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CRATES)CRatesBindingSource.Current);
                CRatesBindingSource.AddNew();
                if (GridViewCrates.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewCrates.FocusedRowHandle = GridViewCrates.RowCount - 1;
                setValues();
                ImageComboBoxEditCode.Focus();
                newRec = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
             if (CRatesBindingSource.Current == null)
                return;
            
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                modified = false;
                newRec = false;
                CRatesBindingSource.RemoveCurrent();
                errorProvider1.Clear();
                context.SaveChanges();
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

        private bool checkForms()
        {
            if (!modified && !newRec)
                return true;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkAll, CRatesBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, CRatesBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, CRatesBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }

        private void cRATESBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current == null)
                return;

            DateTime start = new DateTime();
            DateTime end = new DateTime();
            if (!string.IsNullOrWhiteSpace(sTART_DATEDateEdit.Text))
                start = Convert.ToDateTime(sTART_DATEDateEdit.Text);

            if (!string.IsNullOrWhiteSpace(eND_DATEDateEdit.Text))
                end = Convert.ToDateTime(eND_DATEDateEdit.Text);
            string code = ImageComboBoxEditCode.EditValue.ToString();
            string agency = ImageComboBoxEditAgency.EditValue.ToString();
            
            int id = (int)GridViewCrates.GetFocusedRowCellValue("ID");
            var load = from c in context.CRATES where c.CODE == code && c.ID != id && c.AGENCY == agency &&  ((c.START_DATE > start && c.END_DATE >= end && c.START_DATE < end) || (c.START_DATE < start && c.END_DATE >= start) || (c.START_DATE <= start && c.END_DATE >= end)) select c;
            if (load.Count() > 0)
            {
                MessageBox.Show("This would be an overlapping rate. Please correct the date values.");
                return;
            }
            ImageComboBoxEditCode.Focus();
            bool temp = newRec;
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            if (checkForms())
            {
                ImageComboBoxEditCode.Focus();
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
            }

            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CRATES)CRatesBindingSource.Current);
              
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool move()
        {
            ImageComboBoxEditCode.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( CRATES)CRatesBindingSource.Current);
              
                newRec = false;
                modified = false;
                return true;
            }
            return false;
        }
        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
             if (move())
                CRatesBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
              if (move())
                CRatesBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                CRatesBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
             if (move())
                CRatesBindingSource.MoveLast();
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
             temp = newRec;
            if (!temp && checkForms())
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( CRATES)CRatesBindingSource.Current);
        }

        private void CratesForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (CRatesBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CRATES)CRatesBindingSource.Current);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CRATES)CRatesBindingSource.Current);
          
                e.Allow = false;
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewCrates.IsFilterRow(e.RowHandle))
                modified = true;
            labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
            labelControlUpdBy.Text = username;
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
             e.ExceptionMode = ExceptionMode.NoAction;
        } 

        private void iTINTextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkItin, CRatesBindingSource);
            }
        }

        private void sTART_DATEDateEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkStart, CRatesBindingSource);
            }
        }

        private void eND_DATEDateEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkEnd, CRatesBindingSource);
            }
        }

        private void h_LTextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkSeason, CRatesBindingSource);
            }
        }

        private void yEARTextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkYear, CRatesBindingSource);
            }
        }

        private void tP1TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkTp1, CRatesBindingSource);
            }
        }

        private void tP2TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkTp2, CRatesBindingSource);
            }
        }

        private void tP3TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkTp3, CRatesBindingSource);
            }
        }

        private void tP4TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkTp4, CRatesBindingSource);
            }
        }

        private void tP5TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkTp5, CRatesBindingSource);
            }
        }

        private void tP6TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkTp6, CRatesBindingSource);
            }
        }

        private void tP7TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkTp7, CRatesBindingSource);
            }
        }

        private void tP8TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkTp8, CRatesBindingSource);
            }
        }

        private void tP9TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkTp9, CRatesBindingSource);
            }
        }

        private void tP10TextEdit_Leave(object sender, EventArgs e)
        {
           if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkTp10, CRatesBindingSource);
            }
        }

        private void tP11TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkTp11, CRatesBindingSource);
            }
        }

        private void tP12TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkTp12, CRatesBindingSource);
            }
        }

        private void dESC1TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkDesc1, CRatesBindingSource);
            }
        }

        private void dESC2TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkDesc2, CRatesBindingSource);
            }
        }

        private void dESC3TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkDesc3, CRatesBindingSource);
            }
        }

        private void dESC4TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkDesc4, CRatesBindingSource);
            }
        }

        private void dESC5TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkDesc5, CRatesBindingSource);
            }
        }

        private void dESC6TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkDesc6, CRatesBindingSource);
            }
        }

        private void dESC7TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkDesc7, CRatesBindingSource);
            }
        }

        private void dESC8TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkDesc8, CRatesBindingSource);
            }
        }

        private void dESC9TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkDesc9, CRatesBindingSource);
            }
        }

        private void dESC10TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkDesc10, CRatesBindingSource);
            }
        }

        private void dESC11TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkDesc11, CRatesBindingSource);
            }
        }

        private void dESC12TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkDesc12, CRatesBindingSource);
            }
        }

        private void gRATE1TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkGrate1, CRatesBindingSource);
            }
        }

        private void gRATE2TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkGrate2, CRatesBindingSource);
            }
        }

        private void gRATE3TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkGrate3, CRatesBindingSource);
            }
        }

        private void gRATE4TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkGrate4, CRatesBindingSource);
            }
        }

        private void gRATE5TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkGrate5, CRatesBindingSource);
            }
        }

        private void gRATE6TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkGrate6, CRatesBindingSource);
            }
        }

        private void gRATE7TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkGrate7, CRatesBindingSource);
            }
        }

        private void gRATE8TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkGrate8, CRatesBindingSource);
            }
        }

        private void gRATE9TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkGrate9, CRatesBindingSource);
            }
        }

        private void gRATE10TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkGrate10, CRatesBindingSource);
            }
        }

        private void gRATE11TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkGrate11, CRatesBindingSource);
            }
        }

        private void gRATE12TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkGrate12, CRatesBindingSource);
            }
        }

        private void nRATE1TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                if (Convert.ToInt32(gRATE1TextEdit.Text) < Convert.ToInt32(nRATE1TextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The net rate is higher than the gross. Is this this correct?", "Net Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be less than the gross rate.");
                        nRATE1TextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkNrate1, CRatesBindingSource);
            }
        }

        private void nRATE2TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                if (Convert.ToInt32(gRATE2TextEdit.Text) < Convert.ToInt32(nRATE2TextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The net rate is higher than the gross. Is this this correct?", "Net Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be less than the gross rate.");
                        nRATE2TextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkNrate2, CRatesBindingSource);
            }
        }

        private void nRATE3TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                if (Convert.ToInt32(gRATE3TextEdit.Text) < Convert.ToInt32(nRATE3TextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The net rate is higher than the gross. Is this this correct?", "Net Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be less than the gross rate.");
                        nRATE3TextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkNrate3, CRatesBindingSource);
            }
        }

        private void nRATE4TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                if (Convert.ToInt32(gRATE4TextEdit.Text) < Convert.ToInt32(nRATE4TextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The net rate is higher than the gross. Is this this correct?", "Net Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be less than the gross rate.");
                        nRATE4TextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkNrate4, CRatesBindingSource);
            }
        }

        private void nRATE5TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                if (Convert.ToInt32(gRATE5TextEdit.Text) < Convert.ToInt32(nRATE5TextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The net rate is higher than the gross. Is this this correct?", "Net Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be less than the gross rate.");
                        nRATE5TextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkNrate5, CRatesBindingSource);
            }
        }

        private void nRATE6TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                if (Convert.ToInt32(gRATE6TextEdit.Text) < Convert.ToInt32(nRATE6TextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The net rate is higher than the gross. Is this this correct?", "Net Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be less than the gross rate.");
                        nRATE6TextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkNrate6, CRatesBindingSource);
            }
        }

        private void nRATE7TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                if (Convert.ToInt32(gRATE7TextEdit.Text) < Convert.ToInt32(nRATE7TextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The net rate is higher than the gross. Is this this correct?", "Net Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be less than the gross rate.");
                        nRATE7TextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkNrate7, CRatesBindingSource);
            }
        }

        private void nRATE8TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                if (Convert.ToInt32(gRATE8TextEdit.Text) < Convert.ToInt32(nRATE8TextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The net rate is higher than the gross. Is this this correct?", "Net Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be less than the gross rate.");
                        nRATE8TextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkNrate8, CRatesBindingSource);
            }
        }

        private void nRATE9TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                if (Convert.ToInt32(gRATE9TextEdit.Text) < Convert.ToInt32(nRATE9TextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The net rate is higher than the gross. Is this this correct?", "Net Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be less than the gross rate.");
                        nRATE9TextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkNrate9, CRatesBindingSource);
            }
        }

        private void nRATE10TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                if (Convert.ToInt32(gRATE10TextEdit.Text) < Convert.ToInt32(nRATE10TextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The net rate is higher than the gross. Is this this correct?", "Net Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be less than the gross rate.");
                        nRATE10TextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkNrate10, CRatesBindingSource);
            }
        }

        private void nRATE11TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                if (Convert.ToInt32(gRATE11TextEdit.Text) < Convert.ToInt32(nRATE11TextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The net rate is higher than the gross. Is this this correct?", "Net Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be less than the gross rate.");
                        nRATE11TextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkNrate11, CRatesBindingSource);
            }
        }

        private void nRATE12TextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                if (Convert.ToInt32(gRATE12TextEdit.Text) < Convert.ToInt32(nRATE12TextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The net rate is higher than the gross. Is this this correct?", "Net Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be less than the gross rate.");
                        nRATE12TextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkNrate12, CRatesBindingSource);
            }
        }

        private void cOMM_PCTTextEdit_Leave(object sender, EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkComm, CRatesBindingSource);
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

        private void GridViewCrates_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "START_DATE")
            {
                if (e.Value != null)
                {
                    e.DisplayText = validCheck.convertDate(e.Value.ToString());
                }
            }
        }

        private void CratesForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewCrates.IsFilterRow(GridViewCrates.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewCrates.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewCrates.GetFocusedDisplayText()))
                value = GridViewCrates.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.CODE like '{0}%'", GridViewCrates.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                //string query = String.Format("it.{0} like '{1}%'", colName, value);
                var special = context.CRATES.Where(query);
                if (!string.IsNullOrWhiteSpace(GridViewCrates.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "START_DATE")))
                {
                    string validDate = GridViewCrates.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "START_DATE");
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
                    CRatesBindingSource.DataSource = special;
                    GridViewCrates.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewCrates.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void ImageComboBoxEditAgency_Leave(object sender, System.EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkAgency, CRatesBindingSource);
            }
        }

        private void ImageComboBoxEditCode_Leave(object sender, System.EventArgs e)
        {
             if (CRatesBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControlLastUpd.Text = DateTime.Today.ToShortDateString();
                    labelControlUpdBy.Text = username;
                }

                validCheck.check(sender, errorProvider1, ((CRATES)CRatesBindingSource.Current).checkCode, CRatesBindingSource);
            }
        }

        private void CRatesBindingSource_CurrentChanged(object sender, System.EventArgs e)
        {
            if (CRatesBindingSource.Current != null)
                enableNavigator(true);
            else
                enableNavigator(false);
        }


    }
}