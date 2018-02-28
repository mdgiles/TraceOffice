using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using FlexModel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.Linq;
using System.Linq.Dynamic;
using DevExpress.XtraGrid.Views.Base;
using System.Data;
using DevExpress.XtraGrid;
using Custom_SearchLookupEdit;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.Win;

namespace TraceForms
{

    public partial class PRatesForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool _modified = false;
        public bool newRec = false;
        public bool temp = false;
        const string colName1 = "colCode";
        public FlextourEntities context;
        public string username;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        private FlexInterfaces.Core.ICoreSys _sys;

        public PRatesForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            _sys = sys;
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
            PRateBindingSource.DataSource = from packrec in context.PRATES where packrec.CODE == "KJM987" select packrec;
               
            yEARComboBoxEdit.Properties.Items.Add(DateTime.Today.Year);
            yEARComboBoxEdit.Properties.Items.Add(DateTime.Today.Year + 1);
            yEARComboBoxEdit.Properties.Items.Add(DateTime.Today.Year + 2);
            yEARComboBoxEdit.Properties.Items.Add(DateTime.Today.Year + 3);
            yEARComboBoxEdit.Properties.Items.Add(DateTime.Today.Year + 4);
            yEARComboBoxEdit.Properties.Items.Add(DateTime.Today.Year + 5);

            var agy = from agyRec in context.AGY orderby agyRec.NO ascending select new { agyRec.NO, agyRec.NAME };
            var pkg = from pkgRec in context.PACK orderby pkgRec.CODE ascending select new { pkgRec.CODE, pkgRec.NAME };
            var cat = from catRec in context.ROOMCOD orderby catRec.CODE ascending select new { catRec.CODE, catRec.DESC };
            var hotel = from hotelRec in context.HOTEL orderby hotelRec.CODE ascending select new { hotelRec.CODE, hotelRec.NAME };
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxEditSpecialValue.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCategory.Properties.Items.Add(loadBlank);
            //ImageComboBoxEditHotelCode.Properties.Items.Add(loadBlank);            
            ImageComboBoxEditAgency.Properties.Items.Add(loadBlank);

            var spec = from specRec in context.SpecialValue where specRec.Type == "PKG" orderby specRec.Code ascending select new { specRec.Code, specRec.Name };
            foreach (var result in spec) {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.Code.TrimEnd() + "  " + "(" + result.Name.TrimEnd() + ")", Value = result.Code.TrimEnd() };
                ImageComboBoxEditSpecialValue.Properties.Items.Add(load);
            }

            //foreach (var result in hotel)
            //{
            //    ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
            //    ImageComboBoxEditHotelCode.Properties.Items.Add(load);
            //}
            foreach (var result in agy)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.NO.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.NO.TrimEnd() };
                ImageComboBoxEditAgency.Properties.Items.Add(load);
            }

            //Bind directly to PACK so that the selected PACK record can be retrieved in EditValueChanged without another
            //database lookup.  In this case since package is required we don't need a null entry.
            SearchLookupEditCode.Properties.DataSource = context.PACK.OrderBy(o => o.CODE);

            foreach (var result in cat)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.DESC.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCategory.Properties.Items.Add(load);
            }
            Modified = false;
            newRec = false;
            temp = newRec;
            setReadOnly(true);
            enableNavigator(false);
            expandContractGridButton.Tag = "right";
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
                if (value && PRateBindingSource.Current != null) {
                    //NB: Before updating any property on the entity, any pending edits must be committed 
                    //with bindingSource.EndEdit, other when the properties are set the form bindings are
                    //automatically refreshed, which causes any pending edits to be lost. 
                    PRateBindingSource.EndEdit();
                    PRATES rates = (PRATES)PRateBindingSource.Current;
                    rates.LAST_UPD = DateTime.Now;
                    rates.UPD_INIT = username;
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

        void setReadOnly(bool value)
        {
            SearchLookupEditCode.Properties.ReadOnly = value;
            ImageComboBoxEditAgency.Properties.ReadOnly = value;
            ImageComboBoxEditHotelCode.Properties.ReadOnly = value;
            ImageComboBoxEditCategory.Properties.ReadOnly = value;
            //sTART_DATEDateEdit.Properties.ReadOnly = value;
            //resDate_StartDateEdit.Properties.ReadOnly = value;
        }

        private bool checkForms()
        {
            if (!_modified && !newRec)
                return true;

            bool ok1 = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((PRATES)PRateBindingSource.Current).checkAll, PRateBindingSource);
           if (ok1)
               return validCheck.saveRec(ref _modified, true, ref newRec, context, PRateBindingSource, this.Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref _modified, false, ref newRec, context, PRateBindingSource, this.Name, errorProvider1, Cursor);
                return false;
            }
        }
     

     

        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }      

        void ButtonEdit_QueryPopUp1(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
           
        }


        private void setValues()
        {
            GridViewPrates.SetFocusedRowCellValue("CODE", string.Empty);
            GridViewPrates.SetFocusedRowCellValue("CAT", string.Empty);
            GridViewPrates.SetFocusedRowCellValue("H_L", string.Empty);
            GridViewPrates.SetFocusedRowCellValue("YEAR", DateTime.Today.Year);
            GridViewPrates.SetFocusedRowCellValue("HCODE", string.Empty);
            GridViewPrates.SetFocusedRowCellValue("DESC", string.Empty);
            GridViewPrates.SetFocusedRowCellValue("SGL_GRATE", 0);
            GridViewPrates.SetFocusedRowCellValue("SGL_NRATE", 0);
            GridViewPrates.SetFocusedRowCellValue("EXG_SGL", 0);
            GridViewPrates.SetFocusedRowCellValue("EXN_SGL", 0);
            GridViewPrates.SetFocusedRowCellValue("DBL_GRATE", 0);
            GridViewPrates.SetFocusedRowCellValue("DBL_NRATE", 0);
            GridViewPrates.SetFocusedRowCellValue("EXG_DBL", 0);
            GridViewPrates.SetFocusedRowCellValue("EXN_DBL", 0);
            GridViewPrates.SetFocusedRowCellValue("TPL_GRATE", 0);
            GridViewPrates.SetFocusedRowCellValue("TPL_NRATE", 0);
            GridViewPrates.SetFocusedRowCellValue("EXG_TPL", 0);
            GridViewPrates.SetFocusedRowCellValue("EXN_TPL", 0);
            GridViewPrates.SetFocusedRowCellValue("QUA_GRATE", 0);
            GridViewPrates.SetFocusedRowCellValue("QUA_NRATE", 0);
            GridViewPrates.SetFocusedRowCellValue("EXG_QUA", 0);
            GridViewPrates.SetFocusedRowCellValue("EXN_QUA", 0);
            GridViewPrates.SetFocusedRowCellValue("OTH_GRATE", 0);
            GridViewPrates.SetFocusedRowCellValue("OTH_NRATE", 0);
            GridViewPrates.SetFocusedRowCellValue("EXG_OTH", 0);
            GridViewPrates.SetFocusedRowCellValue("EXN_OTH", 0);
             GridViewPrates.SetFocusedRowCellValue("CHD_GRATE", 0);
            GridViewPrates.SetFocusedRowCellValue("CHD_NRATE", 0);
            GridViewPrates.SetFocusedRowCellValue("EXG_CHD", 0);
            GridViewPrates.SetFocusedRowCellValue("EXN_CHD", 0);
            GridViewPrates.SetFocusedRowCellValue("CHD_LIMIT", 0);
            GridViewPrates.SetFocusedRowCellValue("JR_GRATE", 0);
            GridViewPrates.SetFocusedRowCellValue("JR_NRATE", 0);
            GridViewPrates.SetFocusedRowCellValue("EXG_JR", 0);
            GridViewPrates.SetFocusedRowCellValue("EXN_JR", 0);
            GridViewPrates.SetFocusedRowCellValue("JR_LIMIT", 0);      
            GridViewPrates.SetFocusedRowCellValue("MEAL1_CODE", string.Empty);
            GridViewPrates.SetFocusedRowCellValue("MEAL1_ADG", 0);
            GridViewPrates.SetFocusedRowCellValue("MEAL1_ADN", 0);
            GridViewPrates.SetFocusedRowCellValue("MEAL2_CODE", string.Empty);
            GridViewPrates.SetFocusedRowCellValue("MEAL2_ADG", 0);
            GridViewPrates.SetFocusedRowCellValue("MEAL2_ADN", 0);
            GridViewPrates.SetFocusedRowCellValue("MEAL3_CODE", string.Empty);
            GridViewPrates.SetFocusedRowCellValue("MEAL3_ADG", 0);
            GridViewPrates.SetFocusedRowCellValue("MEAL3_ADN", 0);
            GridViewPrates.SetFocusedRowCellValue("MEAL4_CODE", string.Empty);
            GridViewPrates.SetFocusedRowCellValue("MEAL4_ADG", 0);
            GridViewPrates.SetFocusedRowCellValue("MEAL4_ADN", 0);
            GridViewPrates.SetFocusedRowCellValue("MEAL5_CODE", string.Empty);
            GridViewPrates.SetFocusedRowCellValue("MEAL5_ADG", 0);
            GridViewPrates.SetFocusedRowCellValue("MEAL5_ADN", 0);
            GridViewPrates.SetFocusedRowCellValue("COMMENT1", string.Empty);
            GridViewPrates.SetFocusedRowCellValue("COMMENT2", string.Empty);
            GridViewPrates.SetFocusedRowCellValue("AGENCY", string.Empty);
            GridViewPrates.SetFocusedRowCellValue("COMM_FLG", "N");
            GridViewPrates.SetFocusedRowCellValue("COMM_PCT", 0);
            GridViewPrates.SetFocusedRowCellValue("MAX_SGL", 0);
            GridViewPrates.SetFocusedRowCellValue("MAX_DBL", 0);
            GridViewPrates.SetFocusedRowCellValue("MAX_TPL", 0);
            GridViewPrates.SetFocusedRowCellValue("MAX_QUA", 0);
            GridViewPrates.SetFocusedRowCellValue("MAX_OTH", 0);
            GridViewPrates.SetFocusedRowCellValue("Inhouse", false);
            GridViewPrates.SetFocusedRowCellValue("Inactive", false);
            GridViewPrates.SetFocusedRowCellValue("SpecialValue_Code", string.Empty);
            GridViewPrates.SetFocusedRowCellValue("Currency_CodeSheet", string.Empty);
            GridViewPrates.SetFocusedRowCellValue("Currency_CodePayment", string.Empty);
            GridViewPrates.SetFocusedRowCellValue("ExchangeRate", 0);
            GridViewPrates.SetFocusedRowCellValue("PRatesPlan_Day1", 0);
            GridViewPrates.SetFocusedRowCellValue("PRatesPlan_Day2", 0);
            GridViewPrates.SetFocusedRowCellValue("PRatesPlan_Day3", 0);
            GridViewPrates.SetFocusedRowCellValue("PRatesPlan_Day4", 0);
            GridViewPrates.SetFocusedRowCellValue("PRatesPlan_Day5", 0);
            GridViewPrates.SetFocusedRowCellValue("PRatesPlan_Day6", 0);
            GridViewPrates.SetFocusedRowCellValue("PRatesPlan_Day7", 0);
        }


        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            GridViewPrates.ClearColumnsFilter();
            if (PRateBindingSource.Current == null)
            {
                PRateBindingSource.DataSource = from packrec in context.PRATES where packrec.CODE == "KJM987" select packrec;
             
                PRateBindingSource.AddNew();
                if (GridViewPrates.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewPrates.FocusedRowHandle = GridViewPrates.RowCount - 1;
                SearchLookupEditCode.Focus();             
                newRec = true;
                setReadOnly(false);
                setValues();
                return;
            }
            SearchLookupEditCode.Focus();
           // bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewPrates.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                errorProvider1.Clear();
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (PRATES)PRateBindingSource.Current);
                PRateBindingSource.AddNew();
                if (GridViewPrates.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewPrates.FocusedRowHandle = GridViewPrates.RowCount - 1;
                SearchLookupEditCode.Focus();
                
                newRec = true;
                setValues();
                setReadOnly(false);
            }         
            
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current == null)
                return;
            GridViewPrates.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Modified = false;
                newRec = false;
                PRateBindingSource.RemoveCurrent();
                errorProvider1.Clear();
                context.SaveChanges();
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);
                SearchLookupEditCode.Focus();
                currentVal = SearchLookupEditCode.Text;
                setReadOnly(true);
                Modified = false;
                newRec = false;
            }
            
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }


        private void pRATEBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current == null)
                return;
            SearchLookupEditCode.Focus();
            //Overlapping ratesheets are no longer an error, because the business logic takes care of which
            //one should be used.  User can see which ones are overlapping using the menu option but should
            //not be prevented from saving.

            //DateTime start = new DateTime();
            //DateTime end = new DateTime();
            //if (!string.IsNullOrWhiteSpace(sTART_DATEDateEdit.Text))
            //    start = Convert.ToDateTime(sTART_DATEDateEdit.Text);

            //if (!string.IsNullOrWhiteSpace(eND_DATEDateEdit.Text))
            //    end = Convert.ToDateTime(eND_DATEDateEdit.Text);         
   
            //string code = ImageComboBoxEditCode.EditValue.ToString();
            //string agency = ImageComboBoxEditAgency.EditValue.ToString();
            //string cat = ImageComboBoxEditCategory.EditValue.ToString();
            //int curID = (int)GridViewPrates.GetFocusedRowCellValue("ID");
            // bool inactive = (bool)inactiveCheckEdit.EditValue;
            // if ( !inactive)
            // {
            //     var load = from c in context.PRATES where c.CODE == code && c.AGENCY == agency && c.CAT == cat && c.ID != curID && c.Inactive == false && ((c.START_DATE > start && c.END_DATE >= end && c.START_DATE < end) || (c.START_DATE < start && c.END_DATE >= start) || (c.START_DATE <= start && c.END_DATE >= end)) select c;
            //     if (load.Count() > 0)
            //     {
            //         foreach (var val in load)
            //         {
            //             DateTime? value1 = (DateTime?)GridViewPrates.GetFocusedRowCellValue("ResDate_Start");
            //             DateTime? value2 = (DateTime?)GridViewPrates.GetFocusedRowCellValue("ResDate_End");
            //             if ((val.ResDate_Start.HasValue && val.ResDate_End.HasValue && value1.HasValue && value2.HasValue) || (!val.ResDate_Start.HasValue && !val.ResDate_End.HasValue && !value1.HasValue && !value2.HasValue))
            //             {
            //                 MessageBox.Show("This would be an overlapping rate. Please correct the date values.");
            //                 return;
            //             }
            //         }
            //     }
            // }
            
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

            GridViewPrates.ClearColumnsFilter();
            if (PRateBindingSource.Current == null)
                return;
            SearchLookupEditCode.Focus();
            GridViewPrates.CloseEditor();
            bool temp = newRec;
         //   bindingNavigatorPositionItem.Focus();//trigger field leave event
            if (checkForms())
            {

                SearchLookupEditCode.Focus();
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
                setReadOnly(true);
            }

            if(!temp && !_modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (PRATES)PRateBindingSource.Current);
        
           
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool move()
        {

            GridViewPrates.CloseEditor();
            SearchLookupEditCode.Focus();
           // bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( PRATES)PRateBindingSource.Current);
               
                newRec = false;
                Modified = false;
                return true;
            }
            return false;
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (move())
                PRateBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                PRateBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                PRateBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                PRateBindingSource.MoveLast();
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (PRateBindingSource.Current == null)
            {
                e.Allow = true;
                return;
            }
            temp = newRec;
            bool temp2 = _modified;

            if (checkForms())
            {
                e.Allow = true;
                if ((!temp) && temp2)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (PRATES)PRateBindingSource.Current);
            }
            else
            {
                if (!temp && !_modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (PRATES)PRateBindingSource.Current);
        
                e.Allow = false;
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewPrates.IsFilterRow(e.RowHandle))
            {
                Modified = true;
            }
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }

        private void PRatesForm_FormClosing(object sender, FormClosingEventArgs e)
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
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( PRATES)PRateBindingSource.Current);         
        }

        private void sTART_DATEDateEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkStart, PRateBindingSource);
            }
        }

        private void resDate_StartDateEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkResStart, PRateBindingSource);
            }
        }

        private void eND_DATEDateEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkEnd, PRateBindingSource);
            }
        }

        private void h_LTextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkSeason, PRateBindingSource);
            }
        }

        private void yEARComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkYear, PRateBindingSource);
            }
        }

        private void dESCTextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkDesc, PRateBindingSource);
            }
        }

        private void resDate_EndDateEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkResEnd, PRateBindingSource);
            }
        }

        private void cOMM_PCTTextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkComm, PRateBindingSource);
            }
        }

        private void sGL_GRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (Convert.ToDouble(sGL_GRATETextEdit.Text) < Convert.ToDouble(sGL_NRATETextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The gross rate is less than the cost. Is this this correct?", "Gross Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        sGL_NRATETextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkGross1, PRateBindingSource);
            }
        }

        private void sGL_NRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkNet1, PRateBindingSource);
            }
        }

        private void eXG_SGLTextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (Convert.ToDouble(eXG_SGLTextEdit.Text) < Convert.ToDouble(eXN_SGLTextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The gross rate is less than the cost. Is this this correct?", "Gross Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        eXN_SGLTextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkExtraG1, PRateBindingSource);
            }
        }

        private void eXN_SGLTextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkExtraN1, PRateBindingSource);
            }
        }

        private void mAX_SGLTextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }

                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkMaxOcc1, PRateBindingSource);
            }
           
        }

        private void dBL_GRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (Convert.ToDouble(dBL_GRATETextEdit.Text) < Convert.ToDouble(dBL_NRATETextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The gross rate is less than the cost. Is this this correct?", "Gross Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        dBL_NRATETextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkGross2, PRateBindingSource);
            }
        }

        private void dBL_NRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkNet2, PRateBindingSource);
            }
        }

        private void eXG_DBLTextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (Convert.ToDouble(eXG_DBLTextEdit.Text) < Convert.ToDouble(eXN_DBLTextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The gross rate is less than the cost. Is this this correct?", "Gross Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        eXN_DBLTextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkExtraG2, PRateBindingSource);
            }
        }

        private void eXN_DBLTextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkExtraN2, PRateBindingSource);
            }
        }

        private void mAX_DBLTextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkMaxOcc2, PRateBindingSource);
            }

            
        }

        private void tPL_GRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (Convert.ToDouble(tPL_GRATETextEdit.Text) < Convert.ToDouble(tPL_NRATETextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The gross rate is less than the cost. Is this this correct?", "Gross Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        tPL_NRATETextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkGross3, PRateBindingSource);
            }            
        }

        private void tPL_NRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkNet3, PRateBindingSource);
            }
        }

        private void eXG_TPLTextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (Convert.ToDouble(eXG_TPLTextEdit.Text) < Convert.ToDouble(eXN_TPLTextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The gross rate is less than the cost. Is this this correct?", "Gross Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        tPL_NRATETextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkExtraG3, PRateBindingSource);
            }
        }

        private void eXN_TPLTextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkExtraN3, PRateBindingSource);
            }
        }

        private void mAX_TPLTextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkMaxOcc3, PRateBindingSource);
            }

            
        }

        private void qUA_GRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (Convert.ToDouble(qUA_GRATETextEdit.Text) < Convert.ToDouble(qUA_NRATETextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The gross rate is less than the cost. Is this this correct?", "Gross Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        qUA_NRATETextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkGross4, PRateBindingSource);
            }
        }

        private void qUA_NRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkNet4, PRateBindingSource);
            }
        }

        private void eXG_QUATextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (Convert.ToDouble(eXG_QUATextEdit.Text) < Convert.ToDouble(eXN_QUATextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The gross rate is less than the cost. Is this this correct?", "Gross Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        eXN_QUATextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkExtraG4, PRateBindingSource);
            }
        }

        private void eXN_QUATextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkExtraN4, PRateBindingSource);
            }
        }

        private void mAX_QUATextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkMaxOcc4, PRateBindingSource);
            }

           
        }

        private void oTH_GRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (Convert.ToDouble(oTH_GRATETextEdit.Text) < Convert.ToDouble(oTH_NRATETextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The gross rate is less than the cost. Is this this correct?", "Gross Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        oTH_NRATETextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkGross5, PRateBindingSource);
            }
        }

        private void oTH_NRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkNet5, PRateBindingSource);
            }
        }

        private void eXG_OTHTextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (Convert.ToDouble(eXG_OTHTextEdit.Text) < Convert.ToDouble(eXN_OTHTextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The gross rate is less than the cost. Is this this correct?", "Gross Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        eXN_OTHTextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkExtraG5, PRateBindingSource);
            }
        }

        private void eXN_OTHTextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkExtraN5, PRateBindingSource);
            }
        }

        private void mAX_OTHTextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkMaxOcc5, PRateBindingSource);
            }

            
        }

        private void cHD_GRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (Convert.ToDouble(cHD_GRATETextEdit.Text) < Convert.ToDouble(cHD_NRATETextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The gross rate is less than the cost. Is this this correct?", "Gross Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        cHD_NRATETextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkGross6, PRateBindingSource);
            }
        }

        private void cHD_NRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkNet6, PRateBindingSource);
            }
        }

        private void eXG_CHDTextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (Convert.ToDouble(eXG_CHDTextEdit.Text) < Convert.ToDouble(eXN_CHDTextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The gross rate is less than the cost. Is this this correct?", "Gross Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        eXN_CHDTextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkExtraG6, PRateBindingSource);
            }
        }

        private void eXN_CHDTextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkExtraN6, PRateBindingSource);
            }
        }

        private void cHD_LIMITTextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkChdLimit, PRateBindingSource);
            }

            
        }

        private void jR_GRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (Convert.ToDouble(jR_GRATETextEdit.Text) < Convert.ToDouble(jR_NRATETextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The gross rate is less than the cost. Is this this correct?", "Gross Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        jR_NRATETextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkGross7, PRateBindingSource);
            }
        }

        private void jR_NRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkNet7, PRateBindingSource);
            }
        }

        private void eXG_JRTextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (Convert.ToDouble(eXG_JRTextEdit.Text) < Convert.ToDouble(eXN_JRTextEdit.Text))
                {
                    DialogResult select = XtraMessageBox.Show("The gross rate is less than the cost. Is this this correct?", "Gross Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        eXN_JRTextEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkExtraG7, PRateBindingSource);
            }
        }

        private void eXN_JRTextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkExtraN7, PRateBindingSource);
            }
        }

        private void jR_LIMITTextEdit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkJnrLimit, PRateBindingSource);
            }

            
        }

        private void overlappingRatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime start = new DateTime();
            DateTime end = new DateTime();
            if (!string.IsNullOrWhiteSpace(sTART_DATEDateEdit.Text))
                start = Convert.ToDateTime(sTART_DATEDateEdit.Text);

            if (!string.IsNullOrWhiteSpace(eND_DATEDateEdit.Text))
                end = Convert.ToDateTime(eND_DATEDateEdit.Text);
            string code = SearchLookupEditCode.EditValue.ToString();
            string agency = ImageComboBoxEditAgency.EditValue.ToString();
            string cat = ImageComboBoxEditCategory.EditValue.ToString();
            int id = (int)GridViewPrates.GetFocusedRowCellValue("ID");
            bool inactive = (bool)inactiveCheckEdit.EditValue;
            if (!inactive)
            {
                //The sql I want to determine date overlaps:
                //start between c.START_DATE and c.END_DATE OR end between c.START_DATE and c.END_DATE OR
                //c.START_DATE between start and end OR c.END_DATE between start and end
                var load = from c in context.PRATES
                           where c.CODE == code && c.ID != id && c.AGENCY == agency && c.CAT == cat && c.Inactive == false
                               && ((start >= c.START_DATE && start <= c.END_DATE) || (end >= c.START_DATE && end <= c.END_DATE)
                               || (c.START_DATE >= start && c.START_DATE <= end) || (c.END_DATE >= start && c.END_DATE <= end))
                           select c;
                if (load.Count() == 0)
                    MessageBox.Show("No overlapping rate sheets exist.");
                else
                {
                    var overlaps = new List<PRATES>();
                    foreach (var val in load)
                    {
                        DateTime? value1 = (DateTime?)GridViewPrates.GetFocusedRowCellValue("ResDate_Start");
                        DateTime? value2 = (DateTime?)GridViewPrates.GetFocusedRowCellValue("ResDate_End");
                        if ((val.ResDate_Start.HasValue && val.ResDate_End.HasValue && value1.HasValue && value2.HasValue)
                            || (!val.ResDate_Start.HasValue && !val.ResDate_End.HasValue && !value1.HasValue && !value2.HasValue))
                        {
                            overlaps.Add(val);
                        }
                    }
                    if (overlaps.Count() > 0)
                    {
                        gridControl2.DataSource = overlaps;
                        popupContainerControl1.Top = cODELabel.Top;
                        popupContainerControl1.Left = cODELabel.Left;
                        popupContainerControl1.BringToFront();
                        popupContainerControl1.Show();
                    }
                    else
                    {
                        MessageBox.Show("No overlapping rate sheets exist.");
                    }
                }
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

        private void resDate_StartDateEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void resDate_StartDateEdit_TextChanged(object sender, EventArgs e)
        {
            resDate_StartDateEdit.Text = validCheck.convertDate(resDate_StartDateEdit.Text);
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

        private void resDate_EndDateEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void resDate_EndDateEdit_TextChanged(object sender, EventArgs e)
        {
            resDate_EndDateEdit.Text = validCheck.convertDate(resDate_EndDateEdit.Text);
        }

        private void PRatesForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewPrates.IsFilterRow(GridViewPrates.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            if (!newRec)
            {
                this.Cursor = Cursors.WaitCursor;
                string colName = GridViewPrates.FocusedColumn.FieldName;
                string value = String.Empty;
                if (!string.IsNullOrWhiteSpace(GridViewPrates.GetFocusedDisplayText()))
                    value = GridViewPrates.GetFocusedDisplayText();
                if (!string.IsNullOrWhiteSpace(value))
                {
                    string query = String.Format("it.AGENCY like '{0}%'", GridViewPrates.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "AGENCY"));
                    var special = context.PRATES.Where(query);

                    if (!string.IsNullOrWhiteSpace(GridViewPrates.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE")))
                    {
                        query = String.Format("it.{0} like '{1}%'", "CODE", GridViewPrates.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                        special = special.Where(query);
                    }
                    int count = special.Count();
                    if (count > 0)
                    {
                        PRateBindingSource.DataSource = special;
                        GridViewPrates.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                        GridViewPrates.FocusedRowHandle = 0;
                        GridViewPrates.FocusedColumn.FieldName = colName;
                    }
                    else
                    {
                        MessageBox.Show("No records in database.");
                        GridViewPrates.ClearColumnsFilter();
                    }
                }
                this.Cursor = Cursors.Default;
            }
        }     


        private void SearchLookupEditCode_Leave(object sender, System.EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }

                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkCode, PRateBindingSource);
          
            }
        }

        private void ImageComboBoxEditAgency_Leave(object sender, System.EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }

                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkAgency, PRateBindingSource);

            }
        }

        private void ImageComboBoxEditHotelCode_Leave(object sender, System.EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }

                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkHotel, PRateBindingSource);
            }
        }

        private void ImageComboBoxEditCategory_Leave(object sender, System.EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }

                validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkCat, PRateBindingSource);
                //Don't default the description to the category description, because a blank description will automatically
                //use the category description in availability
                //int index = ImageComboBoxEditCategory.Text.IndexOf(' ');
                //dESCTextEdit.Text = ImageComboBoxEditCategory.Text.Remove(0, index).Replace("(", "").Replace(")", "").TrimStart().TrimEnd();

            }
        }

        private void PRateBindingSource_CurrentChanged(object sender, System.EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                enableNavigator(true);
                string agency = ((PRATES)PRateBindingSource.Current).AGENCY; 
                if (agency == _sys.Settings.DefaultAgency)
                {
                    cOMM_PCTTextEdit.Enabled = true;
                    cOMM_FLGCheckEdit.Enabled = true;
                }
                else
                {
                    cOMM_PCTTextEdit.Enabled = false;
                    cOMM_PCTTextEdit.Text = string.Empty;
                    cOMM_FLGCheckEdit.Enabled = false;
                    cOMM_FLGCheckEdit.EditValue = false;
                }

            }
            else
                enableNavigator(false);
        }

        private void GridViewPrates_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "START_DATE")
                if (e.Value != null)
                    if (!string.IsNullOrWhiteSpace(e.Value.ToString()))
                        e.DisplayText = validCheck.convertDate(e.Value.ToString());

        }

        private void expandContractGridButton_Click(object sender, System.EventArgs e)
        {
            if (expandContractGridButton.Tag.ToString() == "right")
            {
                expandContractGridButton.Image = TraceForms.Properties.Resources.arrow_left;
                expandContractGridButton.Tag = "left";
                GridViewPrates.Columns["AGENCY"].Visible = true;
                GridViewPrates.Columns["AGENCY"].VisibleIndex = 4;
                GridViewPrates.Columns["ResDate_Start"].Visible = true;
                GridViewPrates.Columns["ResDate_Start"].VisibleIndex = 5;
                //AdvBandedGridViewHrates.Columns["CAT"].Width = 35;
                GridViewPrates.Columns["CODE"].Width = 65;
            }
            else
            {
                expandContractGridButton.Image = TraceForms.Properties.Resources.arrow_right;
                expandContractGridButton.Tag = "right";
                //AdvBandedGridViewHrates.Columns["CAT"].Visible = false;
                GridViewPrates.Columns["AGENCY"].Visible = false;
                GridViewPrates.Columns["ResDate_Start"].Visible = false;
                //AdvBandedGridViewHrates.Columns["SvcDate_End"].Visible = false;
            }
        }

        private void dBL_GRATETextEdit_Enter(object sender, System.EventArgs e)
        {
            currentVal = ((Control)sender).Text;
            if (Convert.ToDouble(mAX_SGLTextEdit.Text) == 0 && Convert.ToDouble(sGL_GRATETextEdit.Text) > 0)
            {
                DialogResult select = XtraMessageBox.Show("You have entered a rate but a max occupancy of zero. This room type will not be available.", "FlexTour Maintenance", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered.");
                    mAX_SGLTextEdit.Focus();
                    return;
                }
            }
        }

        private void tPL_GRATETextEdit_Enter(object sender, System.EventArgs e)
        {
            currentVal = ((Control)sender).Text;
            if (Convert.ToDouble(mAX_DBLTextEdit.Text) == 0 && Convert.ToDouble(dBL_GRATETextEdit.Text) > 0)
            {
                DialogResult select = XtraMessageBox.Show("You have entered a rate but a max occupancy of zero. This room type will not be available.", "FlexTour Maintenance", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered.");
                    mAX_DBLTextEdit.Focus();
                    return;
                }
            }
        }

        private void qUA_GRATETextEdit_Enter(object sender, System.EventArgs e)
        {
            currentVal = ((Control)sender).Text;
            if (Convert.ToDouble(mAX_TPLTextEdit.Text) == 0 && Convert.ToDouble(tPL_GRATETextEdit.Text) > 0)
            {
                DialogResult select = XtraMessageBox.Show("You have entered a rate but a max occupancy of zero. This room type will not be available.", "FlexTour Maintenance", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered.");
                    mAX_TPLTextEdit.Focus();
                    return;
                }
            }
        }

        private void oTH_GRATETextEdit_Enter(object sender, System.EventArgs e)
        {
            currentVal = ((Control)sender).Text;
            if (Convert.ToDouble(mAX_QUATextEdit.Text) == 0 && Convert.ToDouble(qUA_GRATETextEdit.Text) > 0)
            {
                DialogResult select = XtraMessageBox.Show("You have entered a rate but a max occupancy of zero. This room type will not be available.", "FlexTour Maintenance", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered.");
                    mAX_QUATextEdit.Focus();
                    return;
                }
            }
        }

        private void cHD_GRATETextEdit_Enter(object sender, System.EventArgs e)
        {
            currentVal = ((Control)sender).Text;
            if (Convert.ToDouble(mAX_OTHTextEdit.Text) == 0 && Convert.ToDouble(oTH_GRATETextEdit.Text) > 0)
            {
                DialogResult select = XtraMessageBox.Show("You have entered a rate but a max occupancy of zero. This room type will not be available.", "FlexTour Maintenance", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered.");
                    mAX_OTHTextEdit.Focus();
                    return;
                }
            }
        }

        private void jR_GRATETextEdit_Enter(object sender, System.EventArgs e)
        {
            currentVal = ((Control)sender).Text;
            if (Convert.ToDouble(cHD_LIMITTextEdit.Text) == 0 && Convert.ToDouble(cHD_GRATETextEdit.Text) > 0)
            {
                DialogResult select = XtraMessageBox.Show("You have entered a rate but a max occupancy of zero. This room type will not be available.", "FlexTour Maintenance", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered.");
                    cHD_LIMITTextEdit.Focus();
                    return;
                }
            }
        }

        private void inactiveCheckEdit_Click(object sender, System.EventArgs e)
        {
            Modified = true;
        }

        private bool checkKids()
        {
            if (!string.IsNullOrWhiteSpace(cHD_LIMITTextEdit.Text) && !string.IsNullOrWhiteSpace(cHD_GRATETextEdit.Text) && !string.IsNullOrWhiteSpace(cHD_NRATETextEdit.Text))
            {
                if (Convert.ToDouble(cHD_LIMITTextEdit.Text) == 0 && (Convert.ToDouble(cHD_GRATETextEdit.Text) > 0 || Convert.ToDouble(cHD_NRATETextEdit.Text) > 0))
                    return false;
            }
            if (!string.IsNullOrWhiteSpace(jR_LIMITTextEdit.Text) && !string.IsNullOrWhiteSpace(jR_GRATETextEdit.Text) && !string.IsNullOrWhiteSpace(jR_NRATETextEdit.Text))
            {
                if (Convert.ToDouble(jR_LIMITTextEdit.Text) == 0 && (Convert.ToDouble(jR_GRATETextEdit.Text) > 0 || Convert.ToDouble(jR_NRATETextEdit.Text) > 0))
                    return false;
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

        private void ImageComboBoxEditAgency_TextChanged(object sender, System.EventArgs e)
        {

            string agency = ImageComboBoxEditAgency.EditValue.ToString();
            if (agency == "TARIFF")
            {
                cOMM_PCTTextEdit.Enabled = true;
                cOMM_FLGCheckEdit.Enabled = true;
            }
            else
            {
                cOMM_PCTTextEdit.Enabled = false;
                cOMM_FLGCheckEdit.Enabled = false;
            }

        }

        private void spinEditSglRetail_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkExtraG6, PRateBindingSource);
            }
        }

        private void spinEditDblRetail_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkExtraG6, PRateBindingSource);
            }
        }

        private void spinEditTplRetail_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkExtraG6, PRateBindingSource);
            }
        }

        private void spinEditQuaRetail_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkExtraG6, PRateBindingSource);
            }
        }

        private void spinEditOthRetail_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkExtraG6, PRateBindingSource);
            }
        }

        private void spinEditChdRetail_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkExtraG6, PRateBindingSource);
            }
        }

        private void spinEditJrRetail_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkExtraG6, PRateBindingSource);
            }
        }

        private void spinEditSeniorRetail_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkExtraG6, PRateBindingSource);
            }
        }

        private void spinEditSeniorAgeLimit_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkExtraG6, PRateBindingSource);
            }
        }

        private void spinEditSeniorGross_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (spinEditSeniorGross.Value < spinEditSeniorCost.Value)
                {
                    DialogResult select = XtraMessageBox.Show("The gross rate is less than the cost. Is this this correct?", "Gross Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        jR_NRATETextEdit.Focus();
                        return;
                    }
                }
                //validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkExtraG6, PRateBindingSource);
            }
        }

        private void spinEditSeniorCost_Leave(object sender, EventArgs e)
        {
            if (PRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                //validCheck.check(sender, errorProvider1, ((PRATES)PRateBindingSource.Current).checkExtraG6, PRateBindingSource);
            }
        }

        private void SearchLookupEdit_Popup(object sender, EventArgs e)
        {
            //Hide the Find button because it doesn't do anything when auto - filtering, except it
            //is useful to let the user know the purpose of the filter field, because it has no label
            //LayoutControl lc = ((sender as IPopupControl).PopupWindow.Controls[2].Controls[0] as LayoutControl);
            //((lc.Items[0] as LayoutControlGroup).Items[1] as LayoutControlGroup).Items[1].Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            PopupSearchLookUpEditForm popupForm = (sender as IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            popupForm.KeyPreview = true;
            popupForm.KeyUp -= PopupForm_KeyUp;
            popupForm.KeyUp += PopupForm_KeyUp;

            //SearchLookUpEdit currentSearch = (SearchLookUpEdit)sender;
        }

        private void SearchLookupEdit_UpdateDisplayFilter(object sender, Custom_SearchLookupEdit.DisplayFilterEventArgs e)
        {
            //Users did not like have to type quotes in order to get an exact match of entered terms rather than any word being matched
            //https://www.devexpress.com/Support/Center/Example/Details/E3135/how-to-implement-an-event-allowing-you-to-customize-a-filter-string-produced-by-the-find
            //Also requires the custom inherited version of the SearchLookupEdit in the Custom_SearchLookupEdit namespace
            if (!string.IsNullOrEmpty(e.FilterText)) {
                e.FilterText = '"' + e.FilterText + '"';
            }
        }

        private void PopupForm_KeyUp(object sender, KeyEventArgs e)
        {
            bool gotMatch = false;
            string keyValue;
            PopupSearchLookUpEditForm popupForm = sender as PopupSearchLookUpEditForm;
            if (e.KeyData == Keys.Enter) {
                string searchText = popupForm.Properties.View.FindFilterText;
                if (!string.IsNullOrEmpty(searchText)) {
                    GridView view = popupForm.OwnerEdit.Properties.View;
                    //If there is a match is on the ValueMember (Code) column, that should take precedence
                    //This needs to be case insensitive, but there is no case insensitive lookup, so we have to iterate the rows
                    //int row = view.LocateByValue(popupForm.OwnerEdit.Properties.ValueMember, searchText);
                    for (int rowHandle = 0; rowHandle < view.DataRowCount; rowHandle++) {
                        //Handle where the control may be bound to different data types
                        object row = view.GetRow(rowHandle);
                        if (row.GetType() == typeof(PACK)) {
                            keyValue = ((PACK)row).CODE;
                        }
                        else {
                            keyValue = ((CodeName)row).Code;
                        }
                        if (searchText.Equals(keyValue, StringComparison.OrdinalIgnoreCase)) {
                            view.FocusedRowHandle = rowHandle;
                            gotMatch = true;
                            break;
                        }
                    }
                    if (!gotMatch) {
                        view.FocusedRowHandle = 0;
                    }
                    popupForm.OwnerEdit.ClosePopup();
                }
            }
        }

        private void SearchLookupEditCode_EditValueChanged(object sender, EventArgs e)
        {
            if (SearchLookupEditCode.GetSelectedDataRow() != null) {
                PACK package = (PACK)SearchLookupEditCode.GetSelectedDataRow();
                TimeEditTime.Enabled = package.MultipleTimes;
                if (!package.MultipleTimes)
                    TimeEditTime.EditValue = null;
            }
        }
    }
}