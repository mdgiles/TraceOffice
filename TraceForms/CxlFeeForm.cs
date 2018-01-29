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
    
    public partial class CxlFeeForm : DevExpress.XtraEditors.XtraForm
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
        public ImageComboBoxItemCollection opts;
        public ImageComboBoxItemCollection htls;
        public CxlFeeForm(FlexInterfaces.Core.ICoreSys sys)
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
            opts = new ImageComboBoxItemCollection(ImageComboBoxEditCode.Properties);
            htls = new ImageComboBoxItemCollection(ImageComboBoxEditCode.Properties);
            lockGrid(true);
            var agy = from agyRec in context.AGY orderby agyRec.NO ascending select new { agyRec.NO, agyRec.NAME };
            var cats = from catRec in context.ROOMCOD orderby catRec.CODE ascending select new { catRec.CODE, catRec.DESC };
            var comps = from compRec in context.COMP orderby compRec.CODE ascending select new { compRec.CODE, compRec.NAME };
            var hotels = from hotRec in context.HOTEL orderby hotRec.CODE ascending select new { hotRec.CODE, hotRec.NAME}; 

            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxEditCat.Properties.Items.Add(loadBlank);
            ImageComboBoxEditAgency.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCode.Properties.Items.Add(loadBlank);
            foreach (var result in agy)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.NO.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.NO.TrimEnd() };
                ImageComboBoxEditAgency.Properties.Items.Add(load);
            }
            foreach (var result in cats)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.DESC.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCat.Properties.Items.Add(load);
            }
            foreach (var result in comps)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                //ImageComboBoxEditCode.Properties.Items.Add(load);
                opts.Add(load);
            }
            foreach (var result in hotels)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                //ImageComboBoxEditAgency.Properties.Items.Add(load);
                htls.Add(load);
            }
            enableNavigator(false);
            expandContractGridButton.Tag = "right";
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
			return;
            //Unique key is type, code, agency, cat, start date, end date, nts prior, cxl date
			//tYPEComboBoxEdit.Properties.ReadOnly = val;
			//ImageComboBoxEditAgency.Properties.ReadOnly = val;
			//ImageComboBoxEditCat.Properties.ReadOnly = val;
			//ImageComboBoxEditCode.Properties.ReadOnly = val;
			//sTART_DATEDateEdit.Properties.ReadOnly = val;
			//eND_DATEDateEdit.Properties.ReadOnly = val;
			//nTS_PRIORSpinEdit.Enabled = !val;
			//cXL_DATEDateEdit.Enabled = !val;
			//GridViewCxlFee.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = !(val);
        }   

        void ButtonEdit_QueryPopUp1(object sender, CancelEventArgs e)
        {
            e.Cancel = false;           
        }

        private void CxlFeeForm_FormClosing(object sender, FormClosingEventArgs e)
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
        /*
         * ____ On the add of a new record, all the fields cleared but there was an warning message at the code field that it needed a value. 
         * It did clear once I filled it.

____ Clicked the No Show check box and the on/after date did go grey as it should, but I still could enter a date.  Also, the value in
 Nights prior should go to -1 and go grey. See the screen shots toward the end of this email (dated Thursday, August 15, 2013 1:52 PM).

_____ was able to enter Fee / Number of nights as a negative number.  I am checking to see if this is ok or not…

_____ Should not be able to change stuff in the lookup panel.  when I did and moved off that record it asked to save or not.


         * 
         * 
         * 
         * 
         *  */
        private void setValues()
        {
            checkEdit1.EditValue = false;
            GridViewCxlFee.SetFocusedRowCellValue("CODE", string.Empty);
            GridViewCxlFee.SetFocusedRowCellValue("TYPE", string.Empty);
            GridViewCxlFee.SetFocusedRowCellValue("AGENCY", string.Empty);
            GridViewCxlFee.SetFocusedRowCellValue("CAT", string.Empty);
            GridViewCxlFee.SetFocusedRowCellValue("NTS_PRIOR", 0);
            GridViewCxlFee.SetFocusedRowCellValue("NBR_NTS", 0);
            GridViewCxlFee.SetFocusedRowCellValue("PCT_AMT", 0);
            GridViewCxlFee.SetFocusedRowCellValue("FLAT_FEE", 0);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            
            GridViewCxlFee.ClearColumnsFilter();
            if (CxlFeeBindingSource.Current == null)
            {
                //fake query in order to create a link between the database table and the binding source
                CxlFeeBindingSource.DataSource = from opt in context.CXLFEE where opt.CODE == "KJM9" select opt;
                CxlFeeBindingSource.AddNew();
                if (GridViewCxlFee.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewCxlFee.FocusedRowHandle = GridViewCxlFee.RowCount - 1;
                setValues();
               
                lockGrid(false);
                tYPEComboBoxEdit.Focus();
                nTS_PRIORSpinEdit.Enabled = true;
                newRec = true;
                return;
            }
            tYPEComboBoxEdit.Focus();  //trigger field leave event
            GridViewCxlFee.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CXLFEE)CxlFeeBindingSource.Current);
                CxlFeeBindingSource.AddNew();
                if (GridViewCxlFee.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewCxlFee.FocusedRowHandle = GridViewCxlFee.RowCount - 1;
                setValues();
               
                lockGrid(false);
                tYPEComboBoxEdit.Focus();
                nTS_PRIORSpinEdit.Enabled = true;
                newRec = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (CxlFeeBindingSource.Current == null)
                return;

            GridViewCxlFee.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                modified = false;
                newRec = false;
                CxlFeeBindingSource.RemoveCurrent();
                errorProvider1.Clear();
                context.SaveChanges();
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);
                lockGrid(true);
            }


            tYPEComboBoxEdit.Focus();
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
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((CXLFEE)CxlFeeBindingSource.Current).checkAll, CxlFeeBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, CxlFeeBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, CxlFeeBindingSource, Name, errorProvider1, Cursor);
                //errorProvider1.Clear();
                return false;
            }
        }

        private bool checkDuplicates()
        {
            
            DateTime start = new DateTime();
            DateTime end = new DateTime();
            DateTime cxldate = new DateTime();
            if (!string.IsNullOrWhiteSpace(sTART_DATEDateEdit.Text))
                start = Convert.ToDateTime(sTART_DATEDateEdit.Text);

            if (!string.IsNullOrWhiteSpace(eND_DATEDateEdit.Text))
                end = Convert.ToDateTime(eND_DATEDateEdit.Text);

            if (!string.IsNullOrWhiteSpace(cXL_DATEDateEdit.Text))
                cxldate = Convert.ToDateTime(cXL_DATEDateEdit.Text);

            string code = ImageComboBoxEditCode.EditValue.ToString();
            string agency = ImageComboBoxEditAgency.EditValue.ToString();
            string cat = ImageComboBoxEditCat.EditValue.ToString();

            if ((from cxlRec in context.CXLFEE where cxlRec.CODE == code && cxlRec.AGENCY == agency && cxlRec.CAT == cat && cxlRec.TYPE == tYPEComboBoxEdit.Text && cxlRec.NTS_PRIOR == nTS_PRIORSpinEdit.Value && cxlRec.START_DATE == start && cxlRec.END_DATE == end && cxlRec.CXL_DATE == cxldate select cxlRec).Count() > 0)
                return true;

            return false;
        }

        private void cXLFEEBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (CxlFeeBindingSource.Current == null)
                return;

            if (checkDuplicates())
            {
                MessageBox.Show("You are attempting to enter a duplicate record, please correct the values.");
                return;
            }

            //if (nBR_NTSSpinEdit.Value == 0 && pCT_AMTTextEdit.Text == "0" && fLAT_FEETextEdit.Text == "0")
            //{
            //    MessageBox.Show("One of the fee methods must be entered.");
            //    return;
            //}
            GridViewCxlFee.CloseEditor();
            tYPEComboBoxEdit.Focus();//trigger field leave event
            bool temp = newRec;
            if (checkForms())
            {
                tYPEComboBoxEdit.Focus();
                lockGrid(true);
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
            }

            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CXLFEE)CxlFeeBindingSource.Current);
            
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool move()
        {
            GridViewCxlFee.CloseEditor();
            tYPEComboBoxEdit.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CXLFEE)CxlFeeBindingSource.Current);
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
                CxlFeeBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                CxlFeeBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                CxlFeeBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                CxlFeeBindingSource.MoveLast();
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            temp = newRec;
            bool temp2 = modified;
            if (checkForms())
            {
                e.Allow = true;
                if ((!temp) && temp2)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CXLFEE)CxlFeeBindingSource.Current);
                lockGrid(true);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CXLFEE)CxlFeeBindingSource.Current);
          
                e.Allow = false;
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewCxlFee.IsFilterRow(e.RowHandle))
                modified = true;
            labelControl2.Text = DateTime.Today.ToShortDateString();
            labelControl4.Text = username;            
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }

        private void tYPEComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (CxlFeeBindingSource.Current != null)
            {
                if (CxlFeeBindingSource.Current != null)
                {
                    if (currentVal != ((Control)sender).Text)
                    {
                        modified = true;
                        labelControl2.Text = DateTime.Today.ToShortDateString();
                        labelControl4.Text = username;
                    }
                    validCheck.check(sender, errorProvider1, ((CXLFEE)CxlFeeBindingSource.Current).checkType, CxlFeeBindingSource);
                }
            }
        }

        private void sTART_DATEDateEdit_Leave(object sender, EventArgs e)
        {
           
                if (CxlFeeBindingSource.Current != null)
                {
                    if (currentVal != ((Control)sender).Text)
                    {
                        modified = true;
                        labelControl2.Text = DateTime.Today.ToShortDateString();
                        labelControl4.Text = username;
                    }
                    validCheck.check(sender, errorProvider1, ((CXLFEE)CxlFeeBindingSource.Current).checkStart, CxlFeeBindingSource);
                }
            
        }

        private void eND_DATEDateEdit_Leave(object sender, EventArgs e)
        {
            
                if (CxlFeeBindingSource.Current != null)
                {
                    if (currentVal != ((Control)sender).Text)
                    {
                        modified = true;
                        labelControl2.Text = DateTime.Today.ToShortDateString();
                        labelControl4.Text = username;
                    }
                    validCheck.check(sender, errorProvider1, ((CXLFEE)CxlFeeBindingSource.Current).checkEnd, CxlFeeBindingSource);
                }
            
        }

        private void nTS_PRIORSpinEdit_Leave(object sender, EventArgs e)
        {
            
                if (CxlFeeBindingSource.Current != null)
                {
                    if (currentVal != ((Control)sender).Text)
                    {
                        modified = true;
                        labelControl2.Text = DateTime.Today.ToShortDateString();
                        labelControl4.Text = username;
                    }
                    validCheck.check(sender, errorProvider1, ((CXLFEE)CxlFeeBindingSource.Current).checkNts, CxlFeeBindingSource);
                }

                if (nTS_PRIORSpinEdit.Value == -1)
                {
                    // checkEdit1.Checked = true;
                    cXL_DATEDateEdit.Text = "";
                    //cXL_DATEDateEdit.Enabled = false;
                    cXL_DATEDateEdit.Enabled = false;
                    //  nTS_PRIORSpinEdit.Enabled = false;
                }

                ////////////if (nTS_PRIORSpinEdit.Value == 0 )
                ////////////{
                ////////////    checkEdit1.Checked = false;
                ////////////  // 
                ////////////    nTS_PRIORSpinEdit.Enabled = false;
                ////////////    //cXL_DATEDateEdit.Enabled = true;
                ////////////    cXL_DATEDateEdit.Enabled = true;
                ////////////}

                if (nTS_PRIORSpinEdit.Value > 0)
                {
                    //checkEdit1.Checked = false;
                    cXL_DATEDateEdit.Text = "";
                    nTS_PRIORSpinEdit.Enabled = true;
                    //  cXL_DATEDateEdit.Enabled = false;
                    cXL_DATEDateEdit.Enabled = false;
                }

                if (string.IsNullOrWhiteSpace(nTS_PRIORSpinEdit.Text))
                {
                    //cXL_DATEDateEdit.Enabled = true;    
                    cXL_DATEDateEdit.Enabled = true;
                }


        }

        private void cXL_DATEDateEdit_Leave(object sender, EventArgs e)
        {
                if (CxlFeeBindingSource.Current != null)
                {
                    if (currentVal != ((Control)sender).Text)
                    {
                        modified = true;
                        labelControl2.Text = DateTime.Today.ToShortDateString();
                        labelControl4.Text = username;
                    }
                    validCheck.check(sender, errorProvider1, ((CXLFEE)CxlFeeBindingSource.Current).checkCxlDate, CxlFeeBindingSource);
                }
            
        }

        private void nBR_NTSSpinEdit_Leave(object sender, EventArgs e)
        {
           
                if (CxlFeeBindingSource.Current != null)
                {
                    if (currentVal != ((Control)sender).Text)
                    {
                        modified = true;
                        labelControl2.Text = DateTime.Today.ToShortDateString();
                        labelControl4.Text = username;
                    }
                    validCheck.check(sender, errorProvider1, ((CXLFEE)CxlFeeBindingSource.Current).checkNbrNts, CxlFeeBindingSource);
                }
            
        }

        private void pCT_AMTTextEdit_Leave(object sender, EventArgs e)
        {
            
                if (CxlFeeBindingSource.Current != null)
                {
                    if (currentVal != ((Control)sender).Text)
                    {
                        modified = true;
                        labelControl2.Text = DateTime.Today.ToShortDateString();
                        labelControl4.Text = username;
                    }
                    validCheck.check(sender, errorProvider1, ((CXLFEE)CxlFeeBindingSource.Current).checkPctAmt, CxlFeeBindingSource);
                }
          
        }

        private void fLAT_FEETextEdit_Leave(object sender, EventArgs e)
        {
            
                if (CxlFeeBindingSource.Current != null)
                {
                    if (currentVal != ((Control)sender).Text)
                    {
                        modified = true;
                        labelControl2.Text = DateTime.Today.ToShortDateString();
                        labelControl4.Text = username;
                    }
                    validCheck.check(sender, errorProvider1, ((CXLFEE)CxlFeeBindingSource.Current).checkFltFee, CxlFeeBindingSource);
                }
          
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            temp = newRec;
           if (!temp && checkForms())
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CXLFEE)CxlFeeBindingSource.Current);
          
        }

        private void tYPEComboBoxEdit_TextChanged(object sender, EventArgs e)
        {
            ImageComboBoxEditCode.Properties.Items.Clear();
            if (tYPEComboBoxEdit.Text == "OPT")
            {                       
                ImageComboBoxEditCode.Properties.Items.AddRange(opts);
            }
            if (tYPEComboBoxEdit.Text == "HTL")
            {
                ImageComboBoxEditCode.Properties.Items.AddRange(htls);
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
           // sTART_DATEDateEdit.Text = validCheck.convertDate(sTART_DATEDateEdit.Text);

            if (!string.IsNullOrWhiteSpace(sTART_DATEDateEdit.Text) && string.IsNullOrWhiteSpace(((CXLFEE)CxlFeeBindingSource.Current).START_DATE.ToString()))
                sTART_DATEDateEdit.Text = validCheck.convertDate(sTART_DATEDateEdit.Text);
            else if (string.IsNullOrWhiteSpace(sTART_DATEDateEdit.Text) && !string.IsNullOrWhiteSpace(((CXLFEE)CxlFeeBindingSource.Current).START_DATE.ToString()))
                sTART_DATEDateEdit.Text = validCheck.convertDate(((CXLFEE)CxlFeeBindingSource.Current).START_DATE.ToString());
            else if (string.IsNullOrWhiteSpace(sTART_DATEDateEdit.Text) && string.IsNullOrWhiteSpace(((CXLFEE)CxlFeeBindingSource.Current).START_DATE.ToString()))
                ((CXLFEE)CxlFeeBindingSource.Current).START_DATE = null;
            else if (!string.IsNullOrWhiteSpace(sTART_DATEDateEdit.Text) && !string.IsNullOrWhiteSpace(((CXLFEE)CxlFeeBindingSource.Current).START_DATE.ToString()))
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
            //eND_DATEDateEdit.Text = validCheck.convertDate(eND_DATEDateEdit.Text);

            if (!string.IsNullOrWhiteSpace(eND_DATEDateEdit.Text) && string.IsNullOrWhiteSpace(((CXLFEE)CxlFeeBindingSource.Current).END_DATE.ToString()))
                eND_DATEDateEdit.Text = validCheck.convertDate(eND_DATEDateEdit.Text);
            else if (string.IsNullOrWhiteSpace(eND_DATEDateEdit.Text) && !string.IsNullOrWhiteSpace(((CXLFEE)CxlFeeBindingSource.Current).END_DATE.ToString()))
                eND_DATEDateEdit.Text = validCheck.convertDate(eND_DATEDateEdit.Text);
            else if (string.IsNullOrWhiteSpace(eND_DATEDateEdit.Text) && string.IsNullOrWhiteSpace(((CXLFEE)CxlFeeBindingSource.Current).END_DATE.ToString()))
                ((CXLFEE)CxlFeeBindingSource.Current).END_DATE = null;
            else if (!string.IsNullOrWhiteSpace(eND_DATEDateEdit.Text) && !string.IsNullOrWhiteSpace(((CXLFEE)CxlFeeBindingSource.Current).END_DATE.ToString()))
                eND_DATEDateEdit.Text = validCheck.convertDate(eND_DATEDateEdit.Text);
        }

        private void cXL_DATEDateEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void cXL_DATEDateEdit_TextChanged(object sender, EventArgs e)
        {
            //cXL_DATEDateEdit.Text = validCheck.convertDate(cXL_DATEDateEdit.Text);

            if (!string.IsNullOrWhiteSpace(cXL_DATEDateEdit.Text) && string.IsNullOrWhiteSpace(((CXLFEE)CxlFeeBindingSource.Current).CXL_DATE.ToString()))
                cXL_DATEDateEdit.Text = validCheck.convertDate(cXL_DATEDateEdit.Text);
            else if (string.IsNullOrWhiteSpace(cXL_DATEDateEdit.Text) && !string.IsNullOrWhiteSpace(((CXLFEE)CxlFeeBindingSource.Current).CXL_DATE.ToString()))
                cXL_DATEDateEdit.Text = validCheck.convertDate(cXL_DATEDateEdit.Text);
            else if (string.IsNullOrWhiteSpace(cXL_DATEDateEdit.Text) && string.IsNullOrWhiteSpace(((CXLFEE)CxlFeeBindingSource.Current).CXL_DATE.ToString()))
                ((CXLFEE)CxlFeeBindingSource.Current).CXL_DATE = null;
            else if (!string.IsNullOrWhiteSpace(cXL_DATEDateEdit.Text) && !string.IsNullOrWhiteSpace(((CXLFEE)CxlFeeBindingSource.Current).CXL_DATE.ToString()))
                cXL_DATEDateEdit.Text = validCheck.convertDate(cXL_DATEDateEdit.Text);


            if (!string.IsNullOrWhiteSpace(cXL_DATEDateEdit.Text) && string.IsNullOrWhiteSpace(nTS_PRIORSpinEdit.Text))
                nTS_PRIORSpinEdit.Enabled = false;

            if (string.IsNullOrWhiteSpace(cXL_DATEDateEdit.Text))
                nTS_PRIORSpinEdit.Enabled = true;
        }

        private void CxlFeeForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewCxlFee.IsFilterRow(GridViewCxlFee.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewCxlFee.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewCxlFee.GetFocusedDisplayText()))
                value = GridViewCxlFee.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.CODE like '{0}%'", GridViewCxlFee.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                var special = context.CXLFEE.Where(query);
               
                if (!string.IsNullOrWhiteSpace(GridViewCxlFee.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CAT")))
                {
                    query = String.Format("it.{0} like '{1}%'", "CAT", GridViewCxlFee.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CAT"));
                    special = special.Where(query);
                }

                int count = special.Count();
                if (count > 0)
                {
                    CxlFeeBindingSource.DataSource = special;
                    GridViewCxlFee.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                    GridViewCxlFee.FocusedRowHandle = 0;
                    GridViewCxlFee.FocusedColumn.FieldName = colName;
                    GridViewCxlFee.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewCxlFee.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void ImageComboBoxEditCode_Leave(object sender, System.EventArgs e)
        {
            if (CxlFeeBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl2.Text = DateTime.Today.ToShortDateString();
                    labelControl4.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CXLFEE)CxlFeeBindingSource.Current).checkCode, CxlFeeBindingSource);
            }         

        }

        private void ImageComboBoxEditAgency_Leave(object sender, System.EventArgs e)
        {
            if (CxlFeeBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl2.Text = DateTime.Today.ToShortDateString();
                    labelControl4.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CXLFEE)CxlFeeBindingSource.Current).checkAgency, CxlFeeBindingSource);
            }

        }

        private void ImageComboBoxEditCat_Leave(object sender, System.EventArgs e)
        {
            if (CxlFeeBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl2.Text = DateTime.Today.ToShortDateString();
                    labelControl4.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CXLFEE)CxlFeeBindingSource.Current).checkCat, CxlFeeBindingSource);
            }
        }

        private void CxlFeeBindingSource_CurrentChanged(object sender, System.EventArgs e)
        {
            if (CxlFeeBindingSource.Current != null)
                enableNavigator(true);
            else
                enableNavigator(false);
        }

        private void expandContractGridButton_Click(object sender, System.EventArgs e)
        {
            if (expandContractGridButton.Tag.ToString() == "right")
            {
                expandContractGridButton.Image = TraceForms.Properties.Resources.arrow_left;
                expandContractGridButton.Tag = "left";
                GridViewCxlFee.Columns["AGENCY"].Visible = true;
                GridViewCxlFee.Columns["AGENCY"].VisibleIndex = 4;
                GridViewCxlFee.Columns["NTS_PRIOR"].Visible = true;
                GridViewCxlFee.Columns["NTS_PRIOR"].VisibleIndex = 5;
                //AdvBandedGridViewHrates.Columns["CAT"].Width = 35;
                GridViewCxlFee.Columns["CODE"].Width = 65;
            }
            else
            {
                expandContractGridButton.Image = TraceForms.Properties.Resources.arrow_right;
                expandContractGridButton.Tag = "right";
                //AdvBandedGridViewHrates.Columns["CAT"].Visible = false;
                GridViewCxlFee.Columns["AGENCY"].Visible = false;
                GridViewCxlFee.Columns["NTS_PRIOR"].Visible = false;
                //AdvBandedGridViewHrates.Columns["SvcDate_End"].Visible = false;
            }
        }

        private void nTS_PRIORSpinEdit_TextChanged(object sender, System.EventArgs e)
        {
       
        }

        private void checkEdit1_Click(object sender, System.EventArgs e)
        {
            /*
____ on an add or change - if there is an number in nights prior and the no-show checkbox is checked the number 
            * of nights should change to -1 and on/after date is also greyed and blanked. 

Here is the behavior of the Nights Prior field, NoShow checkbox and on/after date. 
If the checkbox is checked then nights prior is  filled with ‘-1’ and on/after date is also greyed and blanked. 
If the checkbox is unchecked, nights prior and on/after date are enabled for entry.  

           */

            if (checkEdit1.Checked)
            {
                nTS_PRIORSpinEdit.Enabled = true;
                cXL_DATEDateEdit.Enabled = true;
                GridViewCxlFee.SetFocusedRowCellValue("NTS_PRIOR", 0);
            }
            else
            {
                GridViewCxlFee.SetFocusedRowCellValue("NTS_PRIOR",-1);
                //nTS_PRIORSpinEdit.EditValue = -1;
                cXL_DATEDateEdit.Text = "";
                cXL_DATEDateEdit.Enabled = false;
                nTS_PRIORSpinEdit.Enabled = false;
                
            }
        }

        private void GridViewCxlFee_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            //if (e.Column.FieldName == "START_DATE")
            //    if (e.Value != null)
            //        if (!string.IsNullOrWhiteSpace(e.Value.ToString()))
            //            e.DisplayText = validCheck.convertDate(e.Value.ToString());

            if (e.Column.FieldName == "START_DATE")
                if (e.Value != null)
                    if (!string.IsNullOrWhiteSpace(e.Value.ToString()))
                        e.DisplayText = validCheck.convertDate(e.Value.ToString());

            if (e.Column.FieldName == "END_DATE")
                if (e.Value != null)
                    if (!string.IsNullOrWhiteSpace(e.Value.ToString()))
                        e.DisplayText = validCheck.convertDate(e.Value.ToString());

            if (e.Column.FieldName == "CXL_DATE")
                if (e.Value != null)
                    if (!string.IsNullOrWhiteSpace(e.Value.ToString()))
                        e.DisplayText = validCheck.convertDate(e.Value.ToString());
        }

        private void labelControl2_TextChanged(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(labelControl2.Text))
                labelControl2.Text = validCheck.convertDate(labelControl2.Text);
        }

        private void nTS_PRIORSpinEdit_EditValueChanged(object sender, System.EventArgs e)
        {



        }

    }
}