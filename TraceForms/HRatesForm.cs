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
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views;
using System.Data;
using System.Drawing;
using System.Text;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraGrid;
using System.Data.Linq.SqlClient;
using System.Data.Entity;

namespace TraceForms
{
    
    public partial class HRatesForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool _modified = false;
        public bool newRec = false;
        public bool temp = false;
        public FlextourEntities context;
        public string username;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;        
        public string[]  meals, fgross, fnet, sgross, snet = new string[5];
        public string hcomm;
        List<CodeName> _hotelLookup;
        Timer _actionConfirmation;

        public HRatesForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);                   
            LoadLookups();
        }

        private void LoadLookups()
        {
            GridViewHrates.SetRowCellValue(GridControl.AutoFilterRowHandle, "Inactive", false);
            GridViewHrates.SetRowCellValue(GridControl.AutoFilterRowHandle, "END DATE", DateTime.Today);
            GridViewHrates.SetRowCellValue(GridControl.AutoFilterRowHandle, "ResDate_End", DateTime.Today);

            int val = DateTime.Today.Year;
            for (int index = 0; index < 5; index++)
            {
                yEARComboBoxEdit.Properties.Items.Add(val);
                val++;
            }
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = string.Empty };
            ImageComboBoxEditAgency.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCat.Properties.Items.Add(loadBlank);
            ImageComboBoxEditSpecialValue.Properties.Items.Add(loadBlank);
            ImageComboBoxEditMealCode1.Properties.Items.Add(loadBlank);
            ImageComboBoxEditMealCode2.Properties.Items.Add(loadBlank);
            ImageComboBoxEditMealCode3.Properties.Items.Add(loadBlank);
            ImageComboBoxEditMealCode4.Properties.Items.Add(loadBlank);
            ImageComboBoxEditMealCode5.Properties.Items.Add(loadBlank);
            var agy = from agyRec in context.AGY orderby agyRec.NO ascending select new { agyRec.NO, agyRec.NAME };
            foreach (var result in agy)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.NO.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.NO.TrimEnd() };
                ImageComboBoxEditAgency.Properties.Items.Add(load);
            }
            _hotelLookup = new List<CodeName>();
            _hotelLookup.AddRange(context.HOTEL
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.NAME }));
            bindingSourceCodeNameProduct.DataSource = _hotelLookup;
            var cat = from catRec in context.ROOMCOD orderby catRec.CODE ascending select new { catRec.CODE, catRec.DESC };
            foreach (var result in cat)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.DESC.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCat.Properties.Items.Add(load);
            }
            var spec = from specRec in context.SpecialValue where specRec.Type == "HTL" orderby specRec.Code ascending select new { specRec.Code, specRec.Name };
            foreach (var result in spec)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.Code.TrimEnd() + "  " + "(" + result.Name.TrimEnd() + ")", Value = result.Code.TrimEnd() };
                ImageComboBoxEditSpecialValue.Properties.Items.Add(load);
            }
            var meals = from mealRec in context.MEALCOD orderby mealRec.CODE ascending select new { mealRec.CODE, mealRec.DESC };
            foreach (var result in meals)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.DESC.TrimEnd() + ")", Value = result.CODE.TrimEnd() };                             
                ImageComboBoxEditMealCode1.Properties.Items.Add(load);
                ImageComboBoxEditMealCode2.Properties.Items.Add(load);
                ImageComboBoxEditMealCode3.Properties.Items.Add(load);
                ImageComboBoxEditMealCode4.Properties.Items.Add(load);
                ImageComboBoxEditMealCode5.Properties.Items.Add(load);            
            }
            lockFields();
            expandContractGridButton.Tag = "right";
            enableNavigator(false);
            setReadOnly(true);
        }

        private bool Modified
        {
            get
            {
                return _modified;
            }
            set
            {
                _modified = value;
                if (value && HRateBindingSource.Current != null) {
                    //NB: Before updating any property on the entity, any pending edits must be committed 
                    //with bindingSource.EndEdit, other when the properties are set the form bindings are
                    //automatically refreshed, which causes any pending edits to be lost. 
                    HRateBindingSource.EndEdit();
                    HRATES rate = (HRATES)HRateBindingSource.Current;
                    rate.LAST_UPD = DateTime.Now;
                    rate.UPD_INIT = username;
                }
            }
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
			//force reload from db on every query, rather than using previous cached records
			context.ContextOptions.LazyLoadingEnabled = false;
			context.HRATES.MergeOption = MergeOption.OverwriteChanges;
			username = sys.User.Name;
        }      

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            GridViewHrates.ClearColumnsFilter();
            if (HRateBindingSource.Current == null)
            {
                //fake query in order to create a link between the database table and the binding source
                HRateBindingSource.DataSource = from opt in context.HRATES where opt.CODE == "KJM9" select opt;
                HRateBindingSource.AddNew();
                if (GridViewHrates.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewHrates.FocusedRowHandle = GridViewHrates.RowCount - 1;
                gridLookUpEditHotel.Focus();
                setReadOnly(false);
                newRec = true;               
                setCheckEdits();
                return;
            }
            gridLookUpEditHotel.Focus();
           // bindingNavigatorPositionItem.Focus();         
            temp = newRec;
            if (checkForms())
            {
                errorProvider1.Clear();
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (HRATES)HRateBindingSource.Current);
                HRateBindingSource.AddNew();
                if (GridViewHrates.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewHrates.FocusedRowHandle = GridViewHrates.RowCount - 1;
                gridLookUpEditHotel.Focus();
                setReadOnly(false);
                newRec = true;                
                setCheckEdits();
            }           
        }

        private bool checkForms()
        {
            if (!_modified && !newRec)
                return true;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((HRATES)HRateBindingSource.Current).checkSplitContainer, HRateBindingSource);
            bool validateRates = validCheck.checkAll(PanelControlRatesTab.Controls, errorProvider1, ((HRATES)HRateBindingSource.Current).checkPanel2, HRateBindingSource);
            bool validateMeals = validCheck.checkAll(PanelControlMealsTab.Controls, errorProvider1, ((HRATES)HRateBindingSource.Current).checkPanel3, HRateBindingSource);           
            if (validateMain && validateRates && validateMeals)
                return validCheck.saveRec(ref _modified, true, ref newRec, context, HRateBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref _modified, false, ref newRec, context, HRateBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }

        void setReadOnly(bool value)
        {
            gridLookUpEditHotel.Properties.ReadOnly = value;
            ImageComboBoxEditAgency.Properties.ReadOnly = value;
            ImageComboBoxEditCat.Properties.ReadOnly = value;
            sTART_DATEDateEdit.Properties.ReadOnly = value;
            resDate_StartDateEdit.Properties.ReadOnly = value;

        }

        private void setCheckEdits()
        {
            GridViewHrates.SetFocusedRowCellValue("H_L", string.Empty);
            GridViewHrates.SetFocusedRowCellValue("YEAR", DateTime.Today.Year);
            GridViewHrates.SetFocusedRowCellValue("Allow_Freesell", 0);
            GridViewHrates.SetFocusedRowCellValue("RATE_DESC", string.Empty);
            GridViewHrates.SetFocusedRowCellValue("SGL_GRATE", 0);
            GridViewHrates.SetFocusedRowCellValue("SGL_NRATE", 0);
            GridViewHrates.SetFocusedRowCellValue("DBL_GRATE", 0);
            GridViewHrates.SetFocusedRowCellValue("DBL_NRATE", 0);
            GridViewHrates.SetFocusedRowCellValue("TPL_GRATE", 0);
            GridViewHrates.SetFocusedRowCellValue("TPL_NRATE", 0);
            GridViewHrates.SetFocusedRowCellValue("OTH_GRATE", 0);
            GridViewHrates.SetFocusedRowCellValue("OTH_NRATE", 0);
            GridViewHrates.SetFocusedRowCellValue("QUA_GRATE", 0);
            GridViewHrates.SetFocusedRowCellValue("QUA_NRATE", 0);
            GridViewHrates.SetFocusedRowCellValue("CHD_GRATE", 0);
            GridViewHrates.SetFocusedRowCellValue("CHD_NRATE", 0);
            GridViewHrates.SetFocusedRowCellValue("CHD_LIMIT", 0);
            GridViewHrates.SetFocusedRowCellValue("JR_GRATE", 0);
            GridViewHrates.SetFocusedRowCellValue("JR_NRATE", 0);
            GridViewHrates.SetFocusedRowCellValue("JR_LIMIT", 0);
            GridViewHrates.SetFocusedRowCellValue("MEAL1_CODE", string.Empty);
            GridViewHrates.SetFocusedRowCellValue("MEAL1_ADG", 0);
            GridViewHrates.SetFocusedRowCellValue("MEAL1_ADN", 0);
            GridViewHrates.SetFocusedRowCellValue("MEAL2_CODE", string.Empty);
            GridViewHrates.SetFocusedRowCellValue("MEAL2_ADG", 0);
            GridViewHrates.SetFocusedRowCellValue("MEAL2_ADN", 0);
            GridViewHrates.SetFocusedRowCellValue("MEAL3_CODE", string.Empty);
            GridViewHrates.SetFocusedRowCellValue("MEAL3_ADG", 0);
            GridViewHrates.SetFocusedRowCellValue("MEAL3_ADN", 0);
            GridViewHrates.SetFocusedRowCellValue("MEAL4_CODE", string.Empty);
            GridViewHrates.SetFocusedRowCellValue("MEAL4_ADG", 0);
            GridViewHrates.SetFocusedRowCellValue("MEAL4_ADN", 0);
            GridViewHrates.SetFocusedRowCellValue("MEAL5_CODE", string.Empty);
            GridViewHrates.SetFocusedRowCellValue("MEAL5_ADG", 0);
            GridViewHrates.SetFocusedRowCellValue("MEAL5_ADN", 0);
            GridViewHrates.SetFocusedRowCellValue("COMMENT1", string.Empty);
            GridViewHrates.SetFocusedRowCellValue("COMMENT2", string.Empty);
            GridViewHrates.SetFocusedRowCellValue("AGENCY", string.Empty);
            GridViewHrates.SetFocusedRowCellValue("COMM_FLG", "N");
            GridViewHrates.SetFocusedRowCellValue("COMM_PCT", 0);
            GridViewHrates.SetFocusedRowCellValue("SSGL_GRATE", 0);
            GridViewHrates.SetFocusedRowCellValue("SSGL_NRATE", 0);
            GridViewHrates.SetFocusedRowCellValue("SDBL_GRATE", 0);
            GridViewHrates.SetFocusedRowCellValue("SDBL_NRATE", 0);
            GridViewHrates.SetFocusedRowCellValue("STPL_GRATE", 0);
            GridViewHrates.SetFocusedRowCellValue("STPL_NRATE", 0);
            GridViewHrates.SetFocusedRowCellValue("SOTH_GRATE", 0);
            GridViewHrates.SetFocusedRowCellValue("SOTH_NRATE", 0);
            GridViewHrates.SetFocusedRowCellValue("SQUA_GRATE", 0);
            GridViewHrates.SetFocusedRowCellValue("SQUA_NRATE", 0);
            GridViewHrates.SetFocusedRowCellValue("SCHD_GRATE", 0);
            GridViewHrates.SetFocusedRowCellValue("SCHD_NRATE", 0);
            GridViewHrates.SetFocusedRowCellValue("SCHD_LIMIT", 0);
            GridViewHrates.SetFocusedRowCellValue("SJR_GRATE", 0);
            GridViewHrates.SetFocusedRowCellValue("SJR_NRATE", 0);
            GridViewHrates.SetFocusedRowCellValue("SJR_LIMIT", 0);            
            GridViewHrates.SetFocusedRowCellValue("SMEAL1_ADG", 0);
            GridViewHrates.SetFocusedRowCellValue("SMEAL1_ADN", 0);            
            GridViewHrates.SetFocusedRowCellValue("SMEAL2_ADG", 0);
            GridViewHrates.SetFocusedRowCellValue("SMEAL2_ADN", 0);          
            GridViewHrates.SetFocusedRowCellValue("SMEAL3_ADG", 0);
            GridViewHrates.SetFocusedRowCellValue("SMEAL3_ADN", 0);            
            GridViewHrates.SetFocusedRowCellValue("SMEAL4_ADG", 0);
            GridViewHrates.SetFocusedRowCellValue("SMEAL4_ADN", 0);           
            GridViewHrates.SetFocusedRowCellValue("SMEAL5_ADG", 0);
            GridViewHrates.SetFocusedRowCellValue("SMEAL5_ADN", 0);
            GridViewHrates.SetFocusedRowCellValue("SCOMM_FLG", "N");
            GridViewHrates.SetFocusedRowCellValue("SCOMM_PCT", 0);
            GridViewHrates.SetFocusedRowCellValue("SUN_FLG", 0);
            GridViewHrates.SetFocusedRowCellValue("MON_FLG", 0);
            GridViewHrates.SetFocusedRowCellValue("TUE_FLG", 0);
            GridViewHrates.SetFocusedRowCellValue("WED_FLG", 0);
            GridViewHrates.SetFocusedRowCellValue("THU_FLG", 0);
            GridViewHrates.SetFocusedRowCellValue("FRI_FLG", 0);
            GridViewHrates.SetFocusedRowCellValue("SAT_FLG", 0);
            GridViewHrates.SetFocusedRowCellValue("OVRCOMM_PCT", 0);
            GridViewHrates.SetFocusedRowCellValue("MAX_SGL", 0);
            GridViewHrates.SetFocusedRowCellValue("MAX_DBL", 0);
            GridViewHrates.SetFocusedRowCellValue("MAX_TPL", 0);
            GridViewHrates.SetFocusedRowCellValue("MAX_QUA", 0);
            GridViewHrates.SetFocusedRowCellValue("MAX_OTH", 0);
            GridViewHrates.SetFocusedRowCellValue("NightsStay", 0);
            GridViewHrates.SetFocusedRowCellValue("NightsPay", 0);
            GridViewHrates.SetFocusedRowCellValue("Inactive", false);
            GridViewHrates.SetFocusedRowCellValue("RepeatCount", 0);
            GridViewHrates.SetFocusedRowCellValue("Inhouse", false);
            GridViewHrates.SetFocusedRowCellValue("SpecialValue_Code", string.Empty);
            GridViewHrates.SetFocusedRowCellValue("Currency_CodeSheet", string.Empty);
            GridViewHrates.SetFocusedRowCellValue("Currency_CodePayment", string.Empty);
            GridViewHrates.SetFocusedRowCellValue("Exchangerate", 0);
            GridViewHrates.SetFocusedRowCellValue("MarkupAllowed", false);
            GridViewHrates.SetFocusedRowCellValue("MarkupPct", 0);
        }


        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current == null)
                return;
            GridViewHrates.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Modified = false;
                newRec = false;
                HRateBindingSource.RemoveCurrent();
                errorProvider1.Clear();
                context.SaveChanges();
                setReadOnly(true);
                PanelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);
            }
            gridLookUpEditHotel.Focus();
            //currentVal = ImageComboBoxEditCode.Text;
            
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            PanelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }

        private void hRATEBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            DateTime start = new DateTime();
            DateTime end = new DateTime();
            if(!string.IsNullOrWhiteSpace(sTART_DATEDateEdit.Text))
                start = Convert.ToDateTime(sTART_DATEDateEdit.Text);

            if (!string.IsNullOrWhiteSpace(eND_DATEDateEdit.Text))
                end = Convert.ToDateTime(eND_DATEDateEdit.Text);

            int id = (int)GridViewHrates.GetFocusedRowCellValue("ID");
            string code = gridLookUpEditHotel.EditValue.ToString();
            string agency = ImageComboBoxEditAgency.EditValue.ToString();
            string cat = ImageComboBoxEditCat.EditValue.ToString();
             bool inactive = (bool)inactiveCheckEdit.EditValue;
             if ( !inactive)
             {
                 var load = from c in context.HRATES where c.CODE == code && c.AGENCY == agency && c.ID != id && c.CAT == cat && c.Inactive == false && ((c.START_DATE > start && c.END_DATE >= end && c.START_DATE < end) || (c.START_DATE < start && c.END_DATE >= start) || (c.START_DATE <= start && c.END_DATE >= end)) select c;
                 if (load.Count() > 0)
                 {
                     foreach (var val in load)
                     {
                         DateTime? value1 = (DateTime?)GridViewHrates.GetFocusedRowCellValue("ResDate_Start");
                         DateTime? value2 = (DateTime?)GridViewHrates.GetFocusedRowCellValue("ResDate_End");
                         if ((val.ResDate_Start.HasValue && val.ResDate_End.HasValue && value1.HasValue && value2.HasValue) || (!val.ResDate_Start.HasValue && !val.ResDate_End.HasValue && !value1.HasValue && !value2.HasValue))
                         {
                             MessageBox.Show("This would be an overlapping rate. Please correct the date values.");
                             return;
                         }
                     }

                 }
             }

            if (!checkKids())
            {
                DialogResult select = XtraMessageBox.Show("You have entered a rate without a max age for children/juniors. This item type will not be available, is this correct?", "FlexTour Maintenance", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered.");
                    return;
                }
            }

            if (!checkRatePpl())
            {
                DialogResult select = XtraMessageBox.Show("You have entered a rate without a max number of people. This item type will not be available, is this correct?", "FlexTour Maintenance", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered.");
                    return;
                }

            }

            gridLookUpEditHotel.Focus();

            if (HRateBindingSource.Current == null)
                return;

            //GridViewHrates.CloseEditor();
            //HRateBindingSource.EndEdit();

            bool temp = newRec;
            if (checkForms())
            {
                errorProvider1.Clear();
                setReadOnly(true);
                Modified = false;
                newRec = false;
                PanelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
            }
            
            if(!temp && !_modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (HRATES)HRateBindingSource.Current);
              
        }
            
        private void TimedEventSave(object sender, EventArgs e)
        {
            PanelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool move()
        {
            gridLookUpEditHotel.Focus();
           // bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                errorProvider1.Clear();
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( HRATES)HRateBindingSource.Current);
                setReadOnly(true);
                newRec = false;
                Modified = false;
                return true;
            }
            return false;
        }
        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (move())
                HRateBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                HRateBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                HRateBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                HRateBindingSource.MoveLast();
        }

        private void advBandedGridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (HRateBindingSource.Current == null)
            {
                e.Allow = true;
                return;
            }
            temp = newRec;
            bool temp2 = _modified;
            if (checkForms())
            {
                errorProvider1.Clear();
                e.Allow = true;
                if ((!temp) && temp2)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (HRATES)HRateBindingSource.Current);
                setReadOnly(true);
            }
            else
            {
                if (!temp && !_modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (HRATES)HRateBindingSource.Current);
          
                e.Allow = false;

            }
        }       

        private void advBandedGridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }

        private void HRatesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_modified || newRec)
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
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (HRATES)HRateBindingSource.Current);
            setReadOnly(true);
        }

        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }   

        private void sTART_DATEDateEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkStart, HRateBindingSource);
            }
        }

        private void resDate_StartDateEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkResStart, HRateBindingSource);
            }
        }

        private void eND_DATEDateEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkEnd, HRateBindingSource);
            }
        }

        private void h_LTextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkSeason, HRateBindingSource);
            }
        }

        private void yEARComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkYear, HRateBindingSource);
            }
        }

        private void rATE_DESCTextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkDesc, HRateBindingSource);
            }
        }

        private void sGL_GRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (Convert.ToDouble(sGL_GRATETextEdit.Text) < Convert.ToDouble(sGL_NRATETextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The gross rate is less than the cost. Is this this correct?", "Gross", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        sGL_NRATETextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkGross1, HRateBindingSource);
            }
        }

        private void sGL_NRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet1, HRateBindingSource);
            }
        }

        private void mAX_SGLTextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkMax1, HRateBindingSource);
            }
        }

        private void dBL_GRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (Convert.ToDouble(dBL_GRATETextEdit.Text) < Convert.ToDouble(dBL_NRATETextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The gross rate is less than the cost. Is this this correct?", "Gross", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        dBL_NRATETextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkGross2, HRateBindingSource);
            }
        }

        private void dBL_NRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet2, HRateBindingSource);
            }
        }

        private void mAX_DBLTextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkMax2, HRateBindingSource);
            }
        }

        private void tPL_GRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (Convert.ToDouble(tPL_GRATETextEdit.Text) < Convert.ToDouble(tPL_NRATETextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The gross rate is less than the cost. Is this this correct?", "Gross", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        tPL_NRATETextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkGross3, HRateBindingSource);
            }
        }

        private void tPL_NRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet3, HRateBindingSource);
            }
        }

        private void mAX_TPLTextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkMax3, HRateBindingSource);
            }
        }

        private void qUA_GRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (Convert.ToDouble(qUA_GRATETextEdit.Text) < Convert.ToDouble(qUA_NRATETextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The gross rate is less than the cost. Is this this correct?", "Gross", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        qUA_NRATETextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkGross4, HRateBindingSource);
            }
        }

        private void qUA_NRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet4, HRateBindingSource);
            }
        }

        private void mAX_QUATextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkMax4, HRateBindingSource);
            }
        }

        private void oTH_GRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (Convert.ToDouble(oTH_GRATETextEdit.Text) < Convert.ToDouble(oTH_NRATETextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The gross rate is less than the cost. Is this this correct?", "Gross", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        oTH_NRATETextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkGross5, HRateBindingSource);
            }
        }

        private void oTH_NRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet5, HRateBindingSource);
            }
        }

        private void mAX_OTHTextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkMax5, HRateBindingSource);
            }
        }

        private void cHD_GRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (Convert.ToDouble(cHD_GRATETextEdit.Text) < Convert.ToDouble(cHD_NRATETextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The gross rate is less than the cost. Is this this correct?", "Gross", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        cHD_NRATETextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkGross6, HRateBindingSource);
            }
        }

        private void cHD_NRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet6, HRateBindingSource);
            }
        }

        private void cHD_LIMITTextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkChildAge, HRateBindingSource);
            }
        }

        private void jR_GRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (Convert.ToDouble(jR_GRATETextEdit.Text) < Convert.ToDouble(jR_NRATETextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The gross rate is less than the cost. Is this this correct?", "Gross", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        jR_NRATETextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkGross7, HRateBindingSource);
            }
        }

        private void jR_NRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet7, HRateBindingSource);
            }
        }

        private void jR_LIMITTextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkJunAge, HRateBindingSource);
            }
        }

        private void cOMM_PCTTextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkComm, HRateBindingSource);
            }
        }

        private void sSGL_GRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (Convert.ToDouble(sSGL_GRATETextEdit.Text) < Convert.ToDouble(sSGL_NRATETextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The gross rate is less than the cost. Is this this correct?", "Gross", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        sSGL_NRATETextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkGrossPpl1, HRateBindingSource);
            }
        }

        private void sSGL_NRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNetPpl1, HRateBindingSource);
            }
        }

        private void sDBL_GRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (Convert.ToDouble(sDBL_GRATETextEdit.Text) < Convert.ToDouble(sDBL_NRATETextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The gross rate is less than the cost. Is this this correct?", "Gross", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        sDBL_NRATETextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkGrossPpl2, HRateBindingSource);
            }
        }

        private void sDBL_NRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNetPpl2, HRateBindingSource);
            }
        }

        private void sTPL_GRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (Convert.ToDouble(sTPL_GRATETextEdit.Text) < Convert.ToDouble(sTPL_NRATETextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The gross rate is less than the cost. Is this this correct?", "Gross", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        sTPL_NRATETextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkGrossPpl3, HRateBindingSource);
            }
        }

        private void sTPL_NRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNetPpl3, HRateBindingSource);
            }
        }

        private void sQUA_GRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (Convert.ToDouble(sQUA_GRATETextEdit.Text) < Convert.ToDouble(sQUA_NRATETextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The gross rate is less than the cost. Is this this correct?", "Gross", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        sQUA_NRATETextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkGrossPpl4, HRateBindingSource);
            }
        }

        private void sQUA_NRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNetPpl4, HRateBindingSource);
            }
        }

        private void sOTH_GRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (Convert.ToDouble(sOTH_GRATETextEdit.Text) < Convert.ToDouble(sOTH_NRATETextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The gross rate is less than the cost. Is this this correct?", "Gross", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        sOTH_NRATETextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkGrossPpl5, HRateBindingSource);
            }
        }

        private void sOTH_NRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNetPpl5, HRateBindingSource);
            }
        }

        private void sCHD_GRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (Convert.ToDouble(sCHD_GRATETextEdit.Text) < Convert.ToDouble(sCHD_NRATETextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The gross rate is less than the cost. Is this this correct?", "Gross", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        sCHD_NRATETextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkGrossPpl6, HRateBindingSource);
            }
        }

        private void sCHD_NRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNetPpl6, HRateBindingSource);
            }
        }

        private void sCHD_LIMITTextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkPChildAge, HRateBindingSource);
            }
        }

        private void sJR_GRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (Convert.ToDouble(sJR_GRATETextEdit.Text) < Convert.ToDouble(sJR_NRATETextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The gross rate is less than the cost. Is this this correct?", "Gross", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        sJR_NRATETextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkGrossPpl7, HRateBindingSource);
            }
        }

        private void sJR_NRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNetPpl7, HRateBindingSource);
            }
        }

        private void sJR_LIMITTextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkPJnrAge, HRateBindingSource);
            }
        }

        private void sCOMM_PCTTextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkPComm, HRateBindingSource);
            }
        }

        private void nightsStaySpinEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkStay, HRateBindingSource);
            }
        }

        private void nightsPaySpinEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkPay, HRateBindingSource);
            }
        }

        private void repeatCountSpinEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkRepeat, HRateBindingSource);
            }
        }

        private void cOMMENT1TextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkComment1, HRateBindingSource);
            }
        }

        private void cOMMENT2TextEdit_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkComment2, HRateBindingSource);
            }
        }

        private void overlappingRatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime start = Convert.ToDateTime(sTART_DATEDateEdit.Text);
            DateTime end = Convert.ToDateTime(eND_DATEDateEdit.Text);
            string code = gridLookUpEditHotel.EditValue.ToString();
            string agency = ImageComboBoxEditAgency.EditValue.ToString();
            string cat = ImageComboBoxEditCat.EditValue.ToString();
            var load = from c in context.HRATES where c.CODE == code && c.AGENCY == agency && c.CAT == cat && c.Inactive == false && ((c.START_DATE > start && c.END_DATE >= end && c.START_DATE < end) || (c.START_DATE < start && c.END_DATE >= start) || (c.START_DATE <= start && c.END_DATE >= end)) select c;
            if (load.Count() == 0)
                MessageBox.Show("No overlapping rate sheets exist.");
            else
            {
                gridControl2.DataSource = load;
                popupContainerControl1.Show();
            }
        }

        private void sUN_FLGCheckEdit_CheckStateChanged(object sender, EventArgs e)
        {
            //modified = true;
            lockFields();
        }

        void lockFields()
        {
            if (sUN_FLGCheckEdit.Checked == false && mON_FLGCheckEdit.Checked == false && tUE_FLGCheckEdit.Checked == false && wED_FLGCheckEdit.Checked == false && tHU_FLGCheckEdit.Checked == false && fRI_FLGCheckEdit.Checked == false && sAT_FLGCheckEdit.Checked == false)
            {
                sSGL_GRATETextEdit.Properties.ReadOnly = true;
                sSGL_NRATETextEdit.Properties.ReadOnly = true;
                sDBL_GRATETextEdit.Properties.ReadOnly = true;
                sDBL_NRATETextEdit.Properties.ReadOnly = true;
                sTPL_GRATETextEdit.Properties.ReadOnly = true;
                sTPL_NRATETextEdit.Properties.ReadOnly = true;
                sQUA_GRATETextEdit.Properties.ReadOnly = true;
                sQUA_NRATETextEdit.Properties.ReadOnly = true;
                sOTH_GRATETextEdit.Properties.ReadOnly = true;
                sOTH_NRATETextEdit.Properties.ReadOnly = true;
                sCHD_GRATETextEdit.Properties.ReadOnly = true;
                sCHD_NRATETextEdit.Properties.ReadOnly = true;
                sCHD_LIMITTextEdit.Properties.ReadOnly = true;
                sJR_GRATETextEdit.Properties.ReadOnly = true;
                sJR_LIMITTextEdit.Properties.ReadOnly = true;
                sJR_NRATETextEdit.Properties.ReadOnly = true;
                spinEditSSglCostBeforeTax.Properties.ReadOnly = true;
                spinEditSDblCostBeforeTax.Properties.ReadOnly = true;
                spinEditSTplCostBeforeTax.Properties.ReadOnly = true;
                spinEditSQuaCostBeforeTax.Properties.ReadOnly = true;
                spinEditSOthCostBeforeTax.Properties.ReadOnly = true;
                spinEditSChdCostBeforeTax.Properties.ReadOnly = true;
                spinEditSJrCostBeforeTax.Properties.ReadOnly = true;
                spinEditSSglRetail.Properties.ReadOnly = true;
                spinEditSDblRetail.Properties.ReadOnly = true;
                spinEditSTplRetail.Properties.ReadOnly = true;
                spinEditSQuaRetail.Properties.ReadOnly = true;
                spinEditSOthRetail.Properties.ReadOnly = true;
                spinEditSChdRetail.Properties.ReadOnly = true;
                spinEditSJrRetail.Properties.ReadOnly = true;
            }
            else
            {
                sSGL_GRATETextEdit.Properties.ReadOnly = false;
                sSGL_NRATETextEdit.Properties.ReadOnly = false;
                sDBL_GRATETextEdit.Properties.ReadOnly = false;
                sDBL_NRATETextEdit.Properties.ReadOnly = false;
                sTPL_GRATETextEdit.Properties.ReadOnly = false;
                sTPL_NRATETextEdit.Properties.ReadOnly = false;
                sQUA_GRATETextEdit.Properties.ReadOnly = false;
                sQUA_NRATETextEdit.Properties.ReadOnly = false;
                sOTH_GRATETextEdit.Properties.ReadOnly = false;
                sOTH_NRATETextEdit.Properties.ReadOnly = false;
                sCHD_GRATETextEdit.Properties.ReadOnly = false;
                sCHD_NRATETextEdit.Properties.ReadOnly = false;
                sCHD_LIMITTextEdit.Properties.ReadOnly = false;
                sJR_GRATETextEdit.Properties.ReadOnly = false;
                sJR_LIMITTextEdit.Properties.ReadOnly = false;
                sJR_NRATETextEdit.Properties.ReadOnly = false;
                spinEditSSglCostBeforeTax.Properties.ReadOnly = false;
                spinEditSDblCostBeforeTax.Properties.ReadOnly = false;
                spinEditSTplCostBeforeTax.Properties.ReadOnly = false;
                spinEditSQuaCostBeforeTax.Properties.ReadOnly = false;
                spinEditSOthCostBeforeTax.Properties.ReadOnly = false;
                spinEditSChdCostBeforeTax.Properties.ReadOnly = false;
                spinEditSJrCostBeforeTax.Properties.ReadOnly = false;
                spinEditSSglRetail.Properties.ReadOnly = false;
                spinEditSDblRetail.Properties.ReadOnly = false;
                spinEditSTplRetail.Properties.ReadOnly = false;
                spinEditSQuaRetail.Properties.ReadOnly = false;
                spinEditSOthRetail.Properties.ReadOnly = false;
                spinEditSChdRetail.Properties.ReadOnly = false;
                spinEditSJrRetail.Properties.ReadOnly = false;
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
            if (HRateBindingSource.Current != null) {
                if (!string.IsNullOrWhiteSpace(sTART_DATEDateEdit.Text) && (((HRATES)HRateBindingSource.Current).START_DATE == null))
                    sTART_DATEDateEdit.Text = validCheck.convertDate(sTART_DATEDateEdit.Text);
                else if (string.IsNullOrWhiteSpace(sTART_DATEDateEdit.Text) && (((HRATES)HRateBindingSource.Current).START_DATE != null))
                    sTART_DATEDateEdit.Text = validCheck.convertDate(sTART_DATEDateEdit.Text);
                else if (string.IsNullOrWhiteSpace(sTART_DATEDateEdit.Text) && (((HRATES)HRateBindingSource.Current).START_DATE == null))
                    ((HRATES)HRateBindingSource.Current).START_DATE = null;
            }
        }

        private void resDate_StartDateEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void resDate_StartDateEdit_TextChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrWhiteSpace(resDate_StartDateEdit.Text))
            //    sTART_DATEDateEdit.Text = validCheck.convertDate(resDate_StartDateEdit.Text);
            //else
            //    ((HRATES)HRateBindingSource.Current).ResDate_Start = null;
            if (HRateBindingSource.Current != null) {
                if (!string.IsNullOrWhiteSpace(resDate_StartDateEdit.Text) && (((HRATES)HRateBindingSource.Current).ResDate_Start == null))
                    resDate_StartDateEdit.Text = validCheck.convertDate(resDate_StartDateEdit.Text);
                else if (string.IsNullOrWhiteSpace(resDate_StartDateEdit.Text) && (((HRATES)HRateBindingSource.Current).ResDate_Start != null))
                    resDate_StartDateEdit.Text = validCheck.convertDate(resDate_StartDateEdit.Text);
                else if (string.IsNullOrWhiteSpace(resDate_StartDateEdit.Text) && (((HRATES)HRateBindingSource.Current).ResDate_Start == null))
                    ((HRATES)HRateBindingSource.Current).ResDate_Start = null;
            }
        }

        private void eND_DATEDateEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void eND_DATEDateEdit_TextChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrWhiteSpace(eND_DATEDateEdit.Text))
            //    sTART_DATEDateEdit.Text = validCheck.convertDate(eND_DATEDateEdit.Text);
            //else
            //    ((HRATES)HRateBindingSource.Current).END_DATE = null;
            if (HRateBindingSource.Current != null) {
                if (!string.IsNullOrWhiteSpace(eND_DATEDateEdit.Text) && (((HRATES)HRateBindingSource.Current).END_DATE == null))
                    eND_DATEDateEdit.Text = validCheck.convertDate(eND_DATEDateEdit.Text);
                else if (string.IsNullOrWhiteSpace(eND_DATEDateEdit.Text) && (((HRATES)HRateBindingSource.Current).END_DATE != null))
                    eND_DATEDateEdit.Text = validCheck.convertDate(eND_DATEDateEdit.Text);
                else if (string.IsNullOrWhiteSpace(eND_DATEDateEdit.Text) && (((HRATES)HRateBindingSource.Current).END_DATE == null))
                    ((HRATES)HRateBindingSource.Current).END_DATE = null;
            }
        }

        private void resDate_EndDateEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void resDate_EndDateEdit_TextChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrWhiteSpace(resDate_EndDateEdit.Text))
            //    sTART_DATEDateEdit.Text = validCheck.convertDate(resDate_EndDateEdit.Text);
            //else
            //    ((HRATES)HRateBindingSource.Current).ResDate_End = null;
            if (HRateBindingSource.Current != null) {
                if (!string.IsNullOrWhiteSpace(resDate_EndDateEdit.Text) && (((HRATES)HRateBindingSource.Current).ResDate_End == null))
                    resDate_EndDateEdit.Text = validCheck.convertDate(resDate_EndDateEdit.Text);
                else if (string.IsNullOrWhiteSpace(resDate_EndDateEdit.Text) && (((HRATES)HRateBindingSource.Current).ResDate_End != null)) {
                    resDate_EndDateEdit.Text = validCheck.convertDate(resDate_EndDateEdit.Text);
                    ((HRATES)HRateBindingSource.Current).ResDate_End = null;
                }
                else if (string.IsNullOrWhiteSpace(resDate_EndDateEdit.Text) && (((HRATES)HRateBindingSource.Current).ResDate_End == null))
                    ((HRATES)HRateBindingSource.Current).ResDate_End = null;
            }
        }

        private void HRatesForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewHrates.IsFilterRow(GridViewHrates.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewHrates.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewHrates.GetFocusedDisplayText()))
                value = GridViewHrates.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.CODE like '{0}%'", GridViewHrates.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                var special = context.HRATES.Where(query);

                bool? inactive = GridViewHrates.GetRowCellValue(GridControl.AutoFilterRowHandle, "Inactive") as bool?;
                if (inactive != null) {
                    query = String.Format("it.{0} = {1}", "Inactive", inactive);
                    special = special.Where(query);
                }

                if (!string.IsNullOrWhiteSpace(GridViewHrates.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CAT")))
                {
                    query = String.Format("it.{0} like '{1}%'", "CAT", GridViewHrates.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CAT"));
                    special = special.Where(query);
                }
                //if (!string.IsNullOrWhiteSpace(GridViewHrates.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "AGENCY")))
                //{
                //    query = String.Format("it.{0} like '{1}%'", "AGENCY", GridViewHrates.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "AGENCY"));
                //    special = special.Where(query);
                //}
                DateTime? validDate = GridViewHrates.GetRowCellValue(GridControl.AutoFilterRowHandle, "END_DATE") as DateTime?;
                if(validDate != null) {
                    special = special.Where("it.END_DATE >= @date", new ObjectParameter("date", validDate));                      
                }
                validDate = GridViewHrates.GetRowCellValue(GridControl.AutoFilterRowHandle, "ResDate_End") as DateTime?;
                if (validDate != null) {
                    special = special.Where("it.ResDate_End >= @date", new ObjectParameter("date", validDate));
                }
                int count = special.Count();
                if (count > 0)
                {
                    HRateBindingSource.DataSource = special.OrderBy(item => item.CODE).ThenBy(item => item.CAT).ThenBy(item => item.END_DATE);
                    GridViewHrates.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                    GridViewHrates.FocusedRowHandle = 0;
                    GridViewHrates.FocusedColumn.FieldName = colName;
                    GridViewHrates.CollapseAllGroups();
                    GridViewHrates.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewHrates.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void ImageComboBoxEditCode_Leave(object sender, System.EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkCode, HRateBindingSource);
            }
        }

        private void ImageComboBoxEditAgency_Leave(object sender, System.EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkAgency, HRateBindingSource);
            }
        }

        private void ImageComboBoxEditCat_Leave(object sender, System.EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkCAT, HRateBindingSource);
            }
        }

        private void ImageComboBoxEditSpecialValue_Leave(object sender, System.EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkSpecialCode, HRateBindingSource);
            }
        }
        
        private void mEAL1_CODEImageComboBoxEdit_Leave(object sender, System.EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkMealCode1, HRateBindingSource);
            }
        }

        private void AdvBandedGridViewHrates_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            //if (e.Column.FieldName == "START_DATE")
            //{
            //    e.DisplayText = validCheck.convertDate(e.DisplayText.ToString());                
            //}
        }

        private void mEAL2_CODEImageComboBoxEdit_Leave(object sender, System.EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkMealCode2, HRateBindingSource);
            }
        }

        private void mEAL3_CODEImageComboBoxEdit_Leave(object sender, System.EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkMealCode3, HRateBindingSource);
            }
        }

        private void mEAL4_CODEImageComboBoxEdit_Leave(object sender, System.EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkMealCode4, HRateBindingSource);
            }
        }

        private void mEAL5_CODEImageComboBoxEdit_Leave(object sender, System.EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkMealCode5, HRateBindingSource);
            }
        }

        private void mEAL1_ADGTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkMealsGross1, HRateBindingSource);
            }
        }

        private void mEAL2_ADGTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkMealsGross2, HRateBindingSource);
            }
        }

        private void mEAL3_ADGTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkMealsGross3, HRateBindingSource);
            }
        }

        private void mEAL4_ADGTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkMealsGross4, HRateBindingSource);
            }
        }

        private void mEAL5_ADGTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkMealsGross5, HRateBindingSource);
            }
        }

        private void mEAL1_ADNTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkMealsNet1, HRateBindingSource);
            }
        }

        private void mEAL2_ADNTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkMealsNet2, HRateBindingSource);
            }
        }

        private void mEAL3_ADNTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkMealsNet3, HRateBindingSource);
            }
        }

        private void mEAL4_ADNTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkMealsNet4, HRateBindingSource);
            }
        }

        private void mEAL5_ADNTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkMealsNet5, HRateBindingSource);
            }
        }

        private void sMEAL1_ADGTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkSecMealsGross1, HRateBindingSource);
            }
        }

        private void sMEAL2_ADGTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkSecMealsGross2, HRateBindingSource);
            }
        }

        private void sMEAL3_ADGTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkSecMealsGross3, HRateBindingSource);
            }
        }

        private void sMEAL4_ADGTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkSecMealsGross4, HRateBindingSource);
            }
        }

        private void sMEAL5_ADGTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkSecMealsGross5, HRateBindingSource);
            }
        }

        private void sMEAL1_ADNTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkSecMealsNet1, HRateBindingSource);
            }
        }

        private void sMEAL2_ADNTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkSecMealsNet2, HRateBindingSource);
            }
        }

        private void sMEAL3_ADNTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkSecMealsNet3, HRateBindingSource);
            }
        }

        private void sMEAL4_ADNTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkSecMealsNet4, HRateBindingSource);
            }
        }

        private void sMEAL5_ADNTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkSecMealsNet5, HRateBindingSource);
            }
        }

        private void oVRCOMM_PCTTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkOvrComm, HRateBindingSource);
            }
        }

        private void ImageComboBoxEditCode_SelectedValueChanged(object sender, System.EventArgs e)
        {
            if (newRec && gridLookUpEditHotel.EditValue != null)
            {
                string code = gridLookUpEditHotel.EditValue.ToString();
                var hotValues =( from hotRec in context.HOTEL where hotRec.CODE == code select new { hotRec.NAME, hotRec.MAX_SGL, hotRec.MAX_DBL, hotRec.MAX_TPL, hotRec.MAX_QUA, hotRec.MAX_OTH, hotRec.CHILD_DESC }).SingleOrDefault();
                if (hotValues != null) {
                    rATE_DESCTextEdit.Text = hotValues.NAME;
                    mAX_SGLTextEdit.Text = hotValues.MAX_SGL.ToString();
                    mAX_DBLTextEdit.Text = hotValues.MAX_DBL.ToString();
                    mAX_TPLTextEdit.Text = hotValues.MAX_TPL.ToString();
                    mAX_QUATextEdit.Text = hotValues.MAX_QUA.ToString();
                    mAX_OTHTextEdit.Text = hotValues.MAX_OTH.ToString();
                    cHD_LIMITTextEdit.Text = hotValues.CHILD_DESC;
                    sCHD_LIMITTextEdit.Text = hotValues.CHILD_DESC;
                    jR_LIMITTextEdit.Text = "";
                    sJR_LIMITTextEdit.Text = "";
                }
            }
        }

        private void resDate_EndDateEdit_Leave(object sender, System.EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkResEnd, HRateBindingSource);
            }
        }

        private void AdvBandedGridViewHrates_CustomColumnDisplayText_1(object sender, CustomColumnDisplayTextEventArgs e)
        {
           

            if (e.Column.FieldName == "START_DATE")
                if (e.Value != null)
                    if (!string.IsNullOrWhiteSpace(e.Value.ToString()))
                        e.DisplayText = validCheck.convertDate(e.Value.ToString());

            if (e.Column.FieldName == "ResDate_Start")
                if (e.Value != null)
                    if (!string.IsNullOrWhiteSpace(e.Value.ToString()))
                        e.DisplayText = validCheck.convertDate(e.Value.ToString());
                    
        }

        private void markupPctTextEdit_Leave(object sender, System.EventArgs e)
        {

        }

        private void sCOMM_FLGCheckEdit_Click(object sender, System.EventArgs e)
        {
            Modified = true;
        }   

        private void cOMM_FLGCheckEdit_Click(object sender, System.EventArgs e)
        {
            Modified = true;
        }

        private void sUN_FLGCheckEdit_Click(object sender, System.EventArgs e)
        {
            Modified = true;
        }
        
        private void sTART_DATEDateEdit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null)
                if (!string.IsNullOrWhiteSpace(e.Value.ToString()))
                    e.DisplayText = validCheck.convertDate(e.Value.ToString());
        }

        private void spinEditSglCostBeforeTax_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet1, HRateBindingSource);
            }
        }

        private void spinEditDblCostBeforeTax_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet1, HRateBindingSource);
            }
        }

        private void spinEditTplCostBeforeTax_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet1, HRateBindingSource);
            }
        }

        private void spinEditQuaCostBeforeTax_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet1, HRateBindingSource);
            }
        }

        private void spinEditOthCostBeforeTax_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet1, HRateBindingSource);
            }
        }

        private void spinEditChdCostBeforeTax_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet1, HRateBindingSource);
            }
        }

        private void spinEditJrCostBeforeTax_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet1, HRateBindingSource);
            }
        }

        private void spinEditSglRetail_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet1, HRateBindingSource);
            }
        }

        private void spinEditDblRetail_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet1, HRateBindingSource);
            }
        }

        private void spinEditTplRetail_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet1, HRateBindingSource);
            }
        }

        private void spinEditQuaRetail_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet1, HRateBindingSource);
            }
        }

        private void spinEditOthRetail_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet1, HRateBindingSource);
            }
        }

        private void spinEditChdRetail_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet1, HRateBindingSource);
            }
        }

        private void spinEditJrRetail_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet1, HRateBindingSource);
            }
        }

        private void spinEditSSglCostBeforeTax_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet1, HRateBindingSource);
            }
        }

        private void spinEditSDblCostBeforeTax_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet1, HRateBindingSource);
            }
        }

        private void spinEditSTplCostBeforeTax_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet1, HRateBindingSource);
            }
        }

        private void spinEditSQuaCostBeforeTax_Leave(object sender, EventArgs e)
        {

        }

        private void spinEditSOthCostBeforeTax_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet1, HRateBindingSource);
            }
        }

        private void spinEditSChdCostBeforeTax_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet1, HRateBindingSource);
            }
        }

        private void spinEditsJrCostBeforeTax_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet1, HRateBindingSource);
            }
        }

        private void spinEditSSglRetail_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet1, HRateBindingSource);
            }
        }

        private void spinEditSDblRetail_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet1, HRateBindingSource);
            }
        }

        private void spinEditSTplRetail_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet1, HRateBindingSource);
            }
        }

        private void spinEditSQuaRetail_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet1, HRateBindingSource);
            }
        }

        private void spinEditSOthRetail_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet1, HRateBindingSource);
            }
        }

        private void spinEditSChdRetail_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet1, HRateBindingSource);
            }
        }

        private void spinEditSJrRetail_Leave(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((HRATES)HRateBindingSource.Current).checkNet1, HRateBindingSource);
            }
        }

        private void ShowActionConfirmation(string confirmation)
        {
            PanelControlStatus.Visible = true;
            LabelStatus.Text = confirmation;
            _actionConfirmation = new Timer {
                Interval = 3000
            };
            _actionConfirmation.Start();
            _actionConfirmation.Tick += TimedEvent;
        }

        private void TimedEvent(object sender, EventArgs e)
        {
            PanelControlStatus.Visible = false;
            _actionConfirmation.Stop();
        }

        private void ToolStripButtonClone_Click(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null) {
                if (move()) {
                    var current = (HRATES)HRateBindingSource.Current;
                    var entity = context.HRATES
                        .AsNoTracking()
                        .FirstOrDefault(x => x.ID == current.ID);
                    if (entity != null) {
                        //clear flags so we don't get save warnings displaying the new record
                        Modified = false;
                        newRec = false;
                        entity.EntityKey = null;
                        HRateBindingSource.Add(entity);
                        HRateBindingSource.Position = HRateBindingSource.Count;
                        //set flags so the user will get save warnings when leaving or discarding the new record
                        gridLookUpEditHotel.Focus();
                        Modified = true;
                        newRec = true;
                        setReadOnly(false);
                    }
                }
            }
        }

        private void HRateBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (HRateBindingSource.Current != null)
            {
                enableNavigator(true);
                
            }
            else
                enableNavigator(false);
           // checkForms();
        }


        private bool checkKids()
        {
            if (!string.IsNullOrWhiteSpace(cHD_LIMITTextEdit.Text) && !string.IsNullOrWhiteSpace(cHD_GRATETextEdit.Text) && !string.IsNullOrWhiteSpace(cHD_NRATETextEdit.Text))
            {
                if (validCheck.IsNumeric(cHD_LIMITTextEdit.Text))
                {
                    if (Convert.ToDouble(cHD_LIMITTextEdit.Text) == 0 && (Convert.ToDouble(cHD_GRATETextEdit.Text) > 0 || Convert.ToDouble(cHD_NRATETextEdit.Text) > 0))
                        return false;
                }
            }
            if (!string.IsNullOrWhiteSpace(jR_LIMITTextEdit.Text) && !string.IsNullOrWhiteSpace(jR_GRATETextEdit.Text) && !string.IsNullOrWhiteSpace(jR_NRATETextEdit.Text))
            {
                if (validCheck.IsNumeric(jR_LIMITTextEdit.Text))
                {
                    if (Convert.ToDouble(jR_LIMITTextEdit.Text) == 0 && (Convert.ToDouble(jR_GRATETextEdit.Text) > 0 || Convert.ToDouble(jR_NRATETextEdit.Text) > 0))
                        return false;
                }
            }
            return true;

        }

        private bool checkRatePpl()
        {
            if (!string.IsNullOrWhiteSpace(sGL_GRATETextEdit.Text) && !string.IsNullOrWhiteSpace(sGL_NRATETextEdit.Text) && !string.IsNullOrWhiteSpace(mAX_SGLTextEdit.Text))
            {
                if ((Convert.ToDouble(sGL_GRATETextEdit.Text) > 0 || Convert.ToDouble(sGL_NRATETextEdit.Text) > 0) && Convert.ToDouble(mAX_SGLTextEdit.Text) == 0)
                    return false;
            }
            if (!string.IsNullOrWhiteSpace(dBL_GRATETextEdit.Text) && !string.IsNullOrWhiteSpace(dBL_NRATETextEdit.Text) && !string.IsNullOrWhiteSpace(mAX_DBLTextEdit.Text))
            {
                if ((Convert.ToDouble(dBL_GRATETextEdit.Text) > 0 || Convert.ToDouble(dBL_NRATETextEdit.Text) > 0) && Convert.ToDouble(mAX_DBLTextEdit.Text) == 0)
                    return false;
            }
            if (!string.IsNullOrWhiteSpace(tPL_GRATETextEdit.Text) && !string.IsNullOrWhiteSpace(tPL_NRATETextEdit.Text) && !string.IsNullOrWhiteSpace(mAX_TPLTextEdit.Text))
            {
                if ((Convert.ToDouble(tPL_GRATETextEdit.Text) > 0 || Convert.ToDouble(tPL_NRATETextEdit.Text) > 0) && Convert.ToDouble(mAX_TPLTextEdit.Text) == 0)
                    return false;
            }
            if (!string.IsNullOrWhiteSpace(qUA_GRATETextEdit.Text) && !string.IsNullOrWhiteSpace(qUA_NRATETextEdit.Text) && !string.IsNullOrWhiteSpace(mAX_QUATextEdit.Text))
            {
                if ((Convert.ToDouble(qUA_GRATETextEdit.Text) > 0 || Convert.ToDouble(qUA_NRATETextEdit.Text) > 0) && Convert.ToDouble(mAX_QUATextEdit.Text) == 0)
                    return false;
            }
            if (!string.IsNullOrWhiteSpace(oTH_GRATETextEdit.Text) && !string.IsNullOrWhiteSpace(oTH_NRATETextEdit.Text) && !string.IsNullOrWhiteSpace(mAX_OTHTextEdit.Text))
            {
                if ((Convert.ToDouble(oTH_GRATETextEdit.Text) > 0 || Convert.ToDouble(oTH_NRATETextEdit.Text) > 0) && Convert.ToDouble(mAX_OTHTextEdit.Text) == 0)
                    return false;
            }
          
            return true;

        }

        private void expandContractGridButton_Click(object sender, EventArgs e)
        {
            if (expandContractGridButton.Tag.ToString() == "right")
            {
                expandContractGridButton.Image = TraceForms.Properties.Resources.arrow_left;
                expandContractGridButton.Tag = "left";
                //GridViewHrates.Columns["AGENCY"].Visible = true;
                GridViewHrates.Columns["END DATE"].Visible = true;
                GridViewHrates.Columns["END DATE"].VisibleIndex = 4;
                GridViewHrates.Columns["ResDate_End"].Visible = true;
                GridViewHrates.Columns["ResDate_End"].VisibleIndex = 5;
                GridViewHrates.Columns["CODE"].Width = 65;
            }
            else
            {
                expandContractGridButton.Image = TraceForms.Properties.Resources.arrow_right;
                expandContractGridButton.Tag = "right";
                //GridViewHrates.Columns["AGENCY"].Visible = false;
                GridViewHrates.Columns["END DATE"].Visible = false;
                GridViewHrates.Columns["ResDate_End"].Visible = false;
            }
        }


    }
}