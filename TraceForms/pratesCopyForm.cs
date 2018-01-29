using System.Collections.Generic;
using FlexModel;
using System.Linq;
using System;
using System.ComponentModel;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Xpo;
using System.Drawing;
using System.Collections;

using System.Windows.Forms;
using System.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Runtime.InteropServices;

using System.Collections.Generic;
using FlexModel;
using System.Linq;
using System;
using System.ComponentModel;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Xpo;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Runtime.InteropServices;
using System.Text;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using DevExpress.XtraEditors.Controls;
using System.Data.Entity.Core.Objects;
using DevExpress.Data.Linq;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;

namespace TraceForms
{
    
    public partial class pratesCopyForm : DevExpress.XtraEditors.XtraForm
    {
        public FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        string username;

        public pratesCopyForm(FlexInterfaces.Core.ICoreSys sys)
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
            var agy = from agyRec in context.AGY orderby agyRec.NO ascending select new { agyRec.NO, agyRec.NAME };
            var pack = from airRec in context.PACK orderby airRec.CODE ascending select new { airRec.CODE, airRec.NAME };
            var cat = from catRec in context.ROOMCOD orderby catRec.CODE ascending select new { catRec.CODE, catRec.DESC };
            var hot = from hotRec in context.HOTEL orderby hotRec.CODE ascending select new { hotRec.CODE, hotRec.NAME };
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxEditLoadCode.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCopyCode.Properties.Items.Add(loadBlank);
            ImageComboBoxEditAgency.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCategory.Properties.Items.Add(loadBlank);
            foreach (var result in pack)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditLoadCode.Properties.Items.Add(load);
                ImageComboBoxEditCopyCode.Properties.Items.Add(load);
            }
            foreach (var result in agy)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.NO.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.NO.TrimEnd() };
                ImageComboBoxEditAgency.Properties.Items.Add(load);
            }

            foreach (var result in cat)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.DESC.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCategory.Properties.Items.Add(load);
            }        
            foreach (var result in hot)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditHotel.Properties.Items.Add(load);                
            }
            ImageComboBoxEditCategory.Properties.ReadOnly = true;
            ImageComboBoxEditAgency.Properties.ReadOnly = true;
            ImageComboBoxEditHotel.Properties.ReadOnly = true;          
        }



      
       

       

        private void checkEdit1_Click(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
                PreviewButton.Text = "Preview Copy";

            if (!checkEdit1.Checked)
                PreviewButton.Text = "Preview Overwrite";
        }

        private void checkEdit2_Click(object sender, EventArgs e)
        {
            if (!checkEdit2.Checked)
                GridViewLoad.SelectAll();
            if (checkEdit2.Checked)
                GridViewLoad.ClearSelection();
        }

        private void checkEdit3_Click(object sender, EventArgs e)
        {
            if (!CheckEditAgency.Checked)
                ImageComboBoxEditAgency.Properties.ReadOnly = false;

            if (CheckEditAgency.Checked)
                ImageComboBoxEditAgency.Properties.ReadOnly = true;    
        }

        private void checkEdit4_Click(object sender, EventArgs e)
        {
            if (!CheckEditCategory.Checked)
                ImageComboBoxEditCategory.Properties.ReadOnly = false;

            if (CheckEditCategory.Checked)
                ImageComboBoxEditCategory.Properties.ReadOnly = true;
        }

        private void checkEdit9_Click(object sender, EventArgs e)
        {
            if (!CheckEditHotel.Checked)
                ImageComboBoxEditHotel.Properties.ReadOnly = false;

            if (CheckEditHotel.Checked)
                ImageComboBoxEditHotel.Properties.ReadOnly = true;
        }

        private void checkEdit5_Click(object sender, EventArgs e)
        {
            if (!CheckEditStart.Checked)
            {
                SpinEditStart.Enabled = true;
                ComboBoxEditStartAdd.Enabled = true;
                ComboBoxEditStartTerm.Enabled = true;
            }
            if (CheckEditStart.Checked)
            {
                SpinEditStart.Enabled = false;
                ComboBoxEditStartAdd.Enabled = false;
                ComboBoxEditStartTerm.Enabled = false;
            }
        }

        private void checkEdit6_Click(object sender, EventArgs e)
        {
            if (!CheckEditEnd.Checked)
            {
                SpinEditEnd.Enabled = true;
                ComboBoxEditEndAdd.Enabled = true;
                ComboBoxEditEndTerm.Enabled = true;
            }

            if (CheckEditEnd.Checked)
            {
                SpinEditEnd.Enabled = false;
                ComboBoxEditEndAdd.Enabled = false;
                ComboBoxEditEndTerm.Enabled = false;
            }
        }

        private void checkEdit11_Click(object sender, EventArgs e)
        {
            if (!CheckEditYear.Checked)
                TextEditYear.Enabled = true;

            if (CheckEditYear.Checked)
                TextEditYear.Enabled = false;
        }

        private void checkEdit7_Click(object sender, EventArgs e)
        {
            if (!CheckEditResStart.Checked)
            {
                SpinEditResStart.Enabled = true;
                ComboBoxEditResStartTerm.Enabled = true;
                ComboBoxEditResStartAdd.Enabled = true;
            }

            if (CheckEditResStart.Checked)
            {
                SpinEditResStart.Enabled = false;
                ComboBoxEditResStartTerm.Enabled = false;
                ComboBoxEditResStartAdd.Enabled = false;
            }
        }

        private void checkEdit10_Click(object sender, EventArgs e)
        {
            if (!CheckEditSeason.Checked)
                TextEditSeason.Enabled = true;

            if (CheckEditSeason.Checked)
                TextEditSeason.Enabled = false;
        }

        private void checkEdit8_Click(object sender, EventArgs e)
        {
            if (!CheckEditInactive.Checked)
                ImageComboBoxEditInactive.Enabled = true;

            if (CheckEditInactive.Checked)
                ImageComboBoxEditInactive.Enabled = false;
        }

        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                if (GridViewLoad.IsRowSelected(e.RowHandle))
                {
                    e.Info.Paint.DrawCheckBox(e.Graphics, e.Bounds, ButtonState.Checked);
                    e.Handled = true;
                }
                else
                {

                    e.Info.Paint.DrawCheckBox(e.Graphics, e.Bounds, ButtonState.Normal);
                    e.Handled = true;

                }

            }
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            GridViewLoad.InvalidateRowIndicator(e.ControllerRow);
        }

        
        private void gridView2_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;  
        }

        private void cPRATEBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save these changes?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GridViewCopy.MoveFirst();
                GridViewCopy.MoveLast();
                PRatesBindingSource.EndEdit();
                context.SaveChanges();
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
            }
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private void ImageComboBoxEditLoadCode_TextChanged(object sender, EventArgs e)
        {
            string carCo = ImageComboBoxEditLoadCode.EditValue.ToString();
            GridControlLoad.DataSource = from c in context.PRATES where c.CODE == carCo select c;
        }

        private void ImageComboBoxEditCopyCode_TextChanged(object sender, EventArgs e)
        {
            string carCo = ImageComboBoxEditCopyCode.EditValue.ToString();
            GridControlCopy.DataSource = from c in context.PRATES where c.CODE == carCo && c.CAT == "KJM" select c;
        }

       
        private void simpleButton1_Click_1(object sender, System.EventArgs e)
        {

            int j = GridViewCopy.DataRowCount + 1;

            for (int i = 0; i < j; i++)
            {
                GridViewCopy.MoveFirst();
                GridViewCopy.DeleteRow(GridViewCopy.FocusedRowHandle);
            }

            foreach (int val in GridViewLoad.GetSelectedRows())
            {
                GridViewCopy.AddNewRow();
                GridViewCopy.SetFocusedRowCellValue("CODE", ImageComboBoxEditCopyCode.EditValue);
                GridViewCopy.SetFocusedRowCellValue("ID", GridViewLoad.GetRowCellValue(val, "ID"));
                GridViewCopy.SetFocusedRowCellValue("CAT", GridViewLoad.GetRowCellValue(val, "CAT"));
                GridViewCopy.SetFocusedRowCellValue("H_L", GridViewLoad.GetRowCellValue(val, "H_L"));
                GridViewCopy.SetFocusedRowCellValue("YEAR", GridViewLoad.GetRowCellValue(val, "YEAR"));
                GridViewCopy.SetFocusedRowCellValue("HCODE", GridViewLoad.GetRowCellValue(val, "HCODE"));
                GridViewCopy.SetFocusedRowCellValue("LAST_UPD", DateTime.Now);
                GridViewCopy.SetFocusedRowCellValue("UPD_INIT", username);
                GridViewCopy.SetFocusedRowCellValue("START_DATE", GridViewLoad.GetRowCellValue(val, "START_DATE"));
                GridViewCopy.SetFocusedRowCellValue("END_DATE", GridViewLoad.GetRowCellValue(val, "END_DATE"));
                GridViewCopy.SetFocusedRowCellValue("DESC", GridViewLoad.GetRowCellValue(val, "DESC"));

                GridViewCopy.SetFocusedRowCellValue("SGL_GRATE", GridViewLoad.GetRowCellValue(val, "SGL_GRATE"));
                GridViewCopy.SetFocusedRowCellValue("SGL_NRATE", GridViewLoad.GetRowCellValue(val, "SGL_NRATE"));
                GridViewCopy.SetFocusedRowCellValue("EXG_SGL", GridViewLoad.GetRowCellValue(val, "EXG_SGL"));
                GridViewCopy.SetFocusedRowCellValue("EXN_SGL", GridViewLoad.GetRowCellValue(val, "EXN_SGL"));

                GridViewCopy.SetFocusedRowCellValue("DBL_GRATE", GridViewLoad.GetRowCellValue(val, "DBL_GRATE"));
                GridViewCopy.SetFocusedRowCellValue("DBL_NRATE", GridViewLoad.GetRowCellValue(val, "DBL_NRATE"));
                GridViewCopy.SetFocusedRowCellValue("EXG_DBL", GridViewLoad.GetRowCellValue(val, "EXG_DBL"));
                GridViewCopy.SetFocusedRowCellValue("EXN_DBL", GridViewLoad.GetRowCellValue(val, "EXN_DBL"));

                GridViewCopy.SetFocusedRowCellValue("TPL_GRATE", GridViewLoad.GetRowCellValue(val, "TPL_GRATE"));
                GridViewCopy.SetFocusedRowCellValue("TPL_NRATE", GridViewLoad.GetRowCellValue(val, "TPL_NRATE"));
                GridViewCopy.SetFocusedRowCellValue("EXG_TPL", GridViewLoad.GetRowCellValue(val, "EXG_TPL"));
                GridViewCopy.SetFocusedRowCellValue("EXN_TPL", GridViewLoad.GetRowCellValue(val, "EXN_TPL"));

                GridViewCopy.SetFocusedRowCellValue("QUA_GRATE", GridViewLoad.GetRowCellValue(val, "QUA_GRATE"));
                GridViewCopy.SetFocusedRowCellValue("QUA_NRATE", GridViewLoad.GetRowCellValue(val, "QUA_NRATE"));
                GridViewCopy.SetFocusedRowCellValue("EXG_QUA", GridViewLoad.GetRowCellValue(val, "EXG_QUA"));
                GridViewCopy.SetFocusedRowCellValue("EXN_QUA", GridViewLoad.GetRowCellValue(val, "EXN_QUA"));

                GridViewCopy.SetFocusedRowCellValue("OTH_GRATE", GridViewLoad.GetRowCellValue(val, "OTH_GRATE"));
                GridViewCopy.SetFocusedRowCellValue("OTH_NRATE", GridViewLoad.GetRowCellValue(val, "OTH_NRATE"));
                GridViewCopy.SetFocusedRowCellValue("EXG_OTH", GridViewLoad.GetRowCellValue(val, "EXG_OTH"));
                GridViewCopy.SetFocusedRowCellValue("EXN_OTH", GridViewLoad.GetRowCellValue(val, "EXN_OTH"));

                GridViewCopy.SetFocusedRowCellValue("CHD_GRATE", GridViewLoad.GetRowCellValue(val, "CHD_GRATE"));
                GridViewCopy.SetFocusedRowCellValue("CHD_NRATE", GridViewLoad.GetRowCellValue(val, "CHD_NRATE"));
                GridViewCopy.SetFocusedRowCellValue("EXG_CHD", GridViewLoad.GetRowCellValue(val, "EXG_CHD"));
                GridViewCopy.SetFocusedRowCellValue("EXN_CHD", GridViewLoad.GetRowCellValue(val, "EXN_CHD"));
                GridViewCopy.SetFocusedRowCellValue("CHD_LIMIT", GridViewLoad.GetRowCellValue(val, "CHD_LIMIT"));

                GridViewCopy.SetFocusedRowCellValue("JR_LIMIT", GridViewLoad.GetRowCellValue(val, "JR_LIMIT"));
                GridViewCopy.SetFocusedRowCellValue("JR_GRATE", GridViewLoad.GetRowCellValue(val, "JR_GRATE"));
                GridViewCopy.SetFocusedRowCellValue("JR_NRATE", GridViewLoad.GetRowCellValue(val, "JR_NRATE"));
                GridViewCopy.SetFocusedRowCellValue("EXG_JR", GridViewLoad.GetRowCellValue(val, "EXG_JR"));
                GridViewCopy.SetFocusedRowCellValue("EXN_JR", GridViewLoad.GetRowCellValue(val, "EXN_JR"));

                GridViewCopy.SetFocusedRowCellValue("MEAL1_CODE", GridViewLoad.GetRowCellValue(val, "MEAL1_CODE"));
                GridViewCopy.SetFocusedRowCellValue("MEAL2_CODE", GridViewLoad.GetRowCellValue(val, "MEAL2_CODE"));
                GridViewCopy.SetFocusedRowCellValue("MEAL3_CODE", GridViewLoad.GetRowCellValue(val, "MEAL3_CODE"));
                GridViewCopy.SetFocusedRowCellValue("MEAL4_CODE", GridViewLoad.GetRowCellValue(val, "MEAL4_CODE"));
                GridViewCopy.SetFocusedRowCellValue("MEAL5_CODE", GridViewLoad.GetRowCellValue(val, "MEAL5_CODE"));
                GridViewCopy.SetFocusedRowCellValue("MEAL1_ADG", GridViewLoad.GetRowCellValue(val, "MEAL1_ADG"));
                GridViewCopy.SetFocusedRowCellValue("MEAL2_ADG", GridViewLoad.GetRowCellValue(val, "MEAL2_ADG"));
                GridViewCopy.SetFocusedRowCellValue("MEAL3_ADG", GridViewLoad.GetRowCellValue(val, "MEAL3_ADG"));
                GridViewCopy.SetFocusedRowCellValue("MEAL4_ADG", GridViewLoad.GetRowCellValue(val, "MEAL4_ADG"));
                GridViewCopy.SetFocusedRowCellValue("MEAL5_ADG", GridViewLoad.GetRowCellValue(val, "MEAL5_ADG"));
                GridViewCopy.SetFocusedRowCellValue("MEAL1_ADN", GridViewLoad.GetRowCellValue(val, "MEAL1_ADN"));
                GridViewCopy.SetFocusedRowCellValue("MEAL2_ADN", GridViewLoad.GetRowCellValue(val, "MEAL2_ADN"));
                GridViewCopy.SetFocusedRowCellValue("MEAL3_ADN", GridViewLoad.GetRowCellValue(val, "MEAL3_ADN"));
                GridViewCopy.SetFocusedRowCellValue("MEAL4_ADN", GridViewLoad.GetRowCellValue(val, "MEAL4_ADN"));
                GridViewCopy.SetFocusedRowCellValue("MEAL5_ADN", GridViewLoad.GetRowCellValue(val, "MEAL5_ADN"));

                GridViewCopy.SetFocusedRowCellValue("COMMENT1", GridViewLoad.GetRowCellValue(val, "COMMENT1"));
                GridViewCopy.SetFocusedRowCellValue("COMMENT2", GridViewLoad.GetRowCellValue(val, "COMMENT2"));
                GridViewCopy.SetFocusedRowCellValue("AGENCY", GridViewLoad.GetRowCellValue(val, "AGENCY"));

                GridViewCopy.SetFocusedRowCellValue("COMM_FLG", GridViewLoad.GetRowCellValue(val, "COMM_FLG"));
                GridViewCopy.SetFocusedRowCellValue("COMM_PCT", GridViewLoad.GetRowCellValue(val, "COMM_PCT"));

                GridViewCopy.SetFocusedRowCellValue("MAX_SGL", GridViewLoad.GetRowCellValue(val, "MAX_SGL"));
                GridViewCopy.SetFocusedRowCellValue("MAX_DBL", GridViewLoad.GetRowCellValue(val, "MAX_DBL"));
                GridViewCopy.SetFocusedRowCellValue("MAX_TPL", GridViewLoad.GetRowCellValue(val, "MAX_TPL"));
                GridViewCopy.SetFocusedRowCellValue("MAX_QUA", GridViewLoad.GetRowCellValue(val, "MAX_QUA"));
                GridViewCopy.SetFocusedRowCellValue("MAX_OTH", GridViewLoad.GetRowCellValue(val, "MAX_OTH"));
                GridViewCopy.SetFocusedRowCellValue("Inhouse", GridViewLoad.GetRowCellValue(val, "Inhouse"));
                GridViewCopy.SetFocusedRowCellValue("Inactive", GridViewLoad.GetRowCellValue(val, "Inactive"));
                GridViewCopy.SetFocusedRowCellValue("ResDate_Start", GridViewLoad.GetRowCellValue(val, "ResDate_Start"));
                GridViewCopy.SetFocusedRowCellValue("ResDate_End", GridViewLoad.GetRowCellValue(val, "ResDate_End"));

                GridViewCopy.SetFocusedRowCellValue("SpecialValue_Code", GridViewLoad.GetRowCellValue(val, "SpecialValue_Code"));
                GridViewCopy.SetFocusedRowCellValue("Currency_CodeSheet", GridViewLoad.GetRowCellValue(val, "Currency_CodeSheet"));
                GridViewCopy.SetFocusedRowCellValue("Currency_CodePayment", GridViewLoad.GetRowCellValue(val, "Currency_CodePayment"));
                GridViewCopy.SetFocusedRowCellValue("ExchangeRate", GridViewLoad.GetRowCellValue(val, "ExchangeRate"));

                GridViewCopy.SetFocusedRowCellValue("PRatesPlan_Day1", GridViewLoad.GetRowCellValue(val, "PRatesPlan_Day1"));
                GridViewCopy.SetFocusedRowCellValue("PRatesPlan_Day2", GridViewLoad.GetRowCellValue(val, "PRatesPlan_Day2"));
                GridViewCopy.SetFocusedRowCellValue("PRatesPlan_Day3", GridViewLoad.GetRowCellValue(val, "PRatesPlan_Day3"));
                GridViewCopy.SetFocusedRowCellValue("PRatesPlan_Day4", GridViewLoad.GetRowCellValue(val, "PRatesPlan_Day4"));
                GridViewCopy.SetFocusedRowCellValue("PRatesPlan_Day5", GridViewLoad.GetRowCellValue(val, "PRatesPlan_Day5"));
                GridViewCopy.SetFocusedRowCellValue("PRatesPlan_Day6", GridViewLoad.GetRowCellValue(val, "PRatesPlan_Day6"));
                GridViewCopy.SetFocusedRowCellValue("PRatesPlan_Day7", GridViewLoad.GetRowCellValue(val, "PRatesPlan_Day7"));
            }
            GridViewCopy.Focus();
            GridViewLoad.Focus();
            if (checkEdit1.Checked)
            {
                if (MessageBox.Show("Are you sure you want to delete the original records?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    GridViewLoad.DeleteSelectedRows();
                    context.SaveChanges();
                }
            }
        }

        private void simpleButton2_Click_1(object sender, System.EventArgs e)
        {
            GridViewCopy.MoveFirst();
            GridViewCopy.Focus();
            if (ImageComboBoxEditAgency.Properties.ReadOnly == false)
            {
                for (int i = 0; i < GridViewCopy.RowCount; i++)
                    GridViewCopy.SetRowCellValue(i, GridViewCopy.Columns["AGENCY"], ImageComboBoxEditAgency.EditValue);
            }

            if (ImageComboBoxEditCategory.Properties.ReadOnly == false)
            {
                for (int i = 0; i < GridViewCopy.RowCount; i++)
                    GridViewCopy.SetRowCellValue(i, GridViewCopy.Columns["CAT"], ImageComboBoxEditCategory.EditValue);
            }

            if (ImageComboBoxEditHotel.Properties.ReadOnly == false)
            {
                for (int i = 0; i < GridViewCopy.RowCount; i++)
                    GridViewCopy.SetRowCellValue(i, GridViewCopy.Columns["HCODE"], ImageComboBoxEditHotel.EditValue);
            }

            if (SpinEditStart.Enabled == true)
            {
                if (GridViewCopy.RowCount == 1)
                {
                    if (!string.IsNullOrWhiteSpace(GridViewCopy.GetFocusedRowCellDisplayText("START_DATE")))
                    {
                        DateTime time = (DateTime)GridViewCopy.GetFocusedRowCellValue("START_DATE");
                        int val = (int)SpinEditStart.Value;
                        if (ComboBoxEditStartAdd.Text == "-      Subtract")
                            val *= -1;

                        if (ComboBoxEditStartTerm.Text == "Days")
                            GridViewCopy.SetFocusedRowCellValue("START_DATE", time.AddDays(val));

                        if (ComboBoxEditStartTerm.Text == "Months")
                            GridViewCopy.SetFocusedRowCellValue("START_DATE", time.AddMonths(val));

                        if (ComboBoxEditStartTerm.Text == "Years")
                            GridViewCopy.SetFocusedRowCellValue("START_DATE", time.AddYears(val));
                    }
                }
                else
                {
                    for (int i = 0; i < GridViewCopy.RowCount; i++)
                    {
                        if (!string.IsNullOrWhiteSpace(GridViewCopy.GetFocusedRowCellDisplayText("START_DATE")))
                        {
                            DateTime time = (DateTime)GridViewCopy.GetRowCellValue(i, "START_DATE");
                            int val = (int)SpinEditStart.Value;
                            if (ComboBoxEditStartAdd.Text == "-      Subtract")
                                val *= -1;

                            if (ComboBoxEditStartTerm.Text == "Days")
                                GridViewCopy.SetRowCellValue(i, GridViewCopy.Columns["START_DATE"], time.AddDays(val));

                            if (ComboBoxEditStartTerm.Text == "Months")
                                GridViewCopy.SetRowCellValue(i, GridViewCopy.Columns["START_DATE"], time.AddMonths(val));

                            if (ComboBoxEditStartTerm.Text == "Years")
                                GridViewCopy.SetRowCellValue(i, GridViewCopy.Columns["START_DATE"], time.AddYears(val));
                        }
                    }
                }
            }
            if (SpinEditEnd.Enabled == true)
            {
                if (GridViewCopy.RowCount == 1)
                {
                    if (!string.IsNullOrWhiteSpace(GridViewCopy.GetFocusedRowCellDisplayText("END_DATE")))
                    {
                        DateTime time = (DateTime)GridViewCopy.GetFocusedRowCellValue("END_DATE");
                        int val = (int)SpinEditEnd.Value;
                        if (ComboBoxEditEndAdd.Text == "-      Subtract")
                            val *= -1;

                        if (ComboBoxEditEndTerm.Text == "Days")
                            GridViewCopy.SetFocusedRowCellValue("END_DATE", time.AddDays(val));

                        if (ComboBoxEditEndTerm.Text == "Months")
                            GridViewCopy.SetFocusedRowCellValue("END_DATE", time.AddMonths(val));

                        if (ComboBoxEditEndTerm.Text == "Years")
                            GridViewCopy.SetFocusedRowCellValue("END_DATE", time.AddYears(val));
                    }
                }
                else
                {
                    for (int i = 0; i < GridViewCopy.RowCount; i++)
                    {
                        if (!string.IsNullOrWhiteSpace(GridViewCopy.GetFocusedRowCellDisplayText("END_DATE")))
                        {
                            DateTime time = (DateTime)GridViewCopy.GetRowCellValue(i, "END_DATE");
                            int val = (int)SpinEditEnd.Value;
                            if (ComboBoxEditEndAdd.Text == "-      Subtract")
                                val *= -1;

                            if (ComboBoxEditEndTerm.Text == "Days")
                                GridViewCopy.SetRowCellValue(i, GridViewCopy.Columns["END_DATE"], time.AddDays(val));

                            if (ComboBoxEditEndTerm.Text == "Months")
                                GridViewCopy.SetRowCellValue(i, GridViewCopy.Columns["END_DATE"], time.AddMonths(val));

                            if (ComboBoxEditEndTerm.Text == "Years")
                                GridViewCopy.SetRowCellValue(i, GridViewCopy.Columns["END_DATE"], time.AddYears(val));
                        }
                    }
                }
            }
            if (SpinEditResStart.Enabled == true)
            {
                if (GridViewCopy.RowCount == 1)
                {
                    if (!string.IsNullOrWhiteSpace(GridViewCopy.GetFocusedRowCellDisplayText("ResDate_Start")))
                    {
                        DateTime time = (DateTime)GridViewCopy.GetFocusedRowCellValue("ResDate_Start");
                        int val = (int)SpinEditResStart.Value;
                        if (ComboBoxEditResStartAdd.Text == "-      Subtract")
                             val *= -1;

                        if (ComboBoxEditResStartTerm.Text == "Days")
                            GridViewCopy.SetFocusedRowCellValue("ResDate_Start", time.AddDays(val));

                        if (ComboBoxEditResStartTerm.Text == "Months")
                            GridViewCopy.SetFocusedRowCellValue("ResDate_Start", time.AddMonths(val));

                        if (ComboBoxEditResStartTerm.Text == "Years")
                            GridViewCopy.SetFocusedRowCellValue("ResDate_Start", time.AddYears(val));
                    }
                }
                else
                {
                    for (int i = 0; i < GridViewCopy.RowCount; i++)
                    {
                        if (!string.IsNullOrWhiteSpace(GridViewCopy.GetFocusedRowCellDisplayText("ResDate_Start")))
                        {
                            DateTime time = (DateTime)GridViewCopy.GetRowCellValue(i, "ResDate_Start");
                            int val = (int)SpinEditResStart.Value;
                            if (ComboBoxEditResStartAdd.Text == "-      Subtract")
                                val *= -1;

                            if (ComboBoxEditResStartTerm.Text == "Days")
                                GridViewCopy.SetRowCellValue(i, GridViewCopy.Columns["ResDate_Start"], time.AddDays(val));

                            if (ComboBoxEditResStartTerm.Text == "Months")
                                GridViewCopy.SetRowCellValue(i, GridViewCopy.Columns["ResDate_Start"], time.AddMonths(val));

                            if (ComboBoxEditResStartTerm.Text == "Years")
                                GridViewCopy.SetRowCellValue(i, GridViewCopy.Columns["ResDate_Start"], time.AddYears(val));
                        }
                    }
                }

            }

            if (SpinEditResEnd.Enabled == true)
            {
                if (GridViewCopy.RowCount == 1)
                {
                    if (!string.IsNullOrWhiteSpace(GridViewCopy.GetFocusedRowCellDisplayText("ResDate_End")))
                    {
                        DateTime time = (DateTime)GridViewCopy.GetFocusedRowCellValue("ResDate_End");
                        int val = (int)SpinEditResStart.Value;
                        if (ComboBoxEditResStartAdd.Text == "-      Subtract")
                            val *= -1;

                        if (ComboBoxEditResStartTerm.Text == "Days")
                            GridViewCopy.SetFocusedRowCellValue("ResDate_End", time.AddDays(val));

                        if (ComboBoxEditResStartTerm.Text == "Months")
                            GridViewCopy.SetFocusedRowCellValue("ResDate_End", time.AddMonths(val));

                        if (ComboBoxEditResStartTerm.Text == "Years")
                            GridViewCopy.SetFocusedRowCellValue("ResDate_End", time.AddYears(val));
                    }
                }
                else
                {
                    for (int i = 0; i < GridViewCopy.RowCount; i++)
                    {
                        if (!string.IsNullOrWhiteSpace(GridViewCopy.GetFocusedRowCellDisplayText("ResDate_End")))
                        {
                            DateTime time = (DateTime)GridViewCopy.GetRowCellValue(i, "ResDate_End");
                            int val = (int)SpinEditResStart.Value;
                            if (ComboBoxEditResStartAdd.Text == "-      Subtract")
                                val *= -1;

                            if (ComboBoxEditResStartTerm.Text == "Days")
                                GridViewCopy.SetRowCellValue(i, GridViewCopy.Columns["ResDate_End"], time.AddDays(val));

                            if (ComboBoxEditResStartTerm.Text == "Months")
                                GridViewCopy.SetRowCellValue(i, GridViewCopy.Columns["ResDate_End"], time.AddMonths(val));

                            if (ComboBoxEditResStartTerm.Text == "Years")
                                GridViewCopy.SetRowCellValue(i, GridViewCopy.Columns["ResDate_End"], time.AddYears(val));
                        }
                    }
                }


            }

            if (TextEditYear.Enabled == true)
            {
                for (int i = 0; i < GridViewCopy.RowCount; i++)
                    GridViewCopy.SetRowCellValue(i, GridViewCopy.Columns["YEAR"], TextEditYear.Text);
            }
            if (TextEditSeason.Enabled == true)
            {
                for (int i = 0; i < GridViewCopy.RowCount; i++)
                    GridViewCopy.SetRowCellValue(i, GridViewCopy.Columns["H_L"], TextEditSeason.Text);
            }
            if (ImageComboBoxEditInactive.Enabled == true)
            {
                for (int i = 0; i < GridViewCopy.RowCount; i++)
                    GridViewCopy.SetRowCellValue(i, GridViewCopy.Columns["Inactive"], ImageComboBoxEditInactive.EditValue);
            }
            if (ImageComboBoxEditInhouse.Enabled == true)
            {
                for (int i = 0; i < GridViewCopy.RowCount; i++)
                    GridViewCopy.SetRowCellValue(i, GridViewCopy.Columns["Inhouse"], ImageComboBoxEditInhouse.EditValue);
            }

            if (TextEditSpecialValueCode.Enabled == true)
            {
                for (int i = 0; i < GridViewCopy.RowCount; i++)
                    GridViewCopy.SetRowCellValue(i, GridViewCopy.Columns["SpecialValue_Code"], TextEditSpecialValueCode.Text);
            }  
        }

        private void simpleButton3_Click_1(object sender, System.EventArgs e)
        {
            bool overlapFlag = false;

            for (int val = 0; val < GridViewCopy.RowCount; val++)
            {
                ColumnView view = GridViewCopy as ColumnView;
                string best = GridViewCopy.GetRowCellDisplayText(val, "Over");

                if (best == "Checked")
                    overlapFlag = true;
            }
            //                 

            if (overlapFlag)
            {
                MessageBox.Show("There is a potential overlap. Please correct the values before attempting to save.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to save these changes?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GridViewCopy.MoveFirst();
                GridViewCopy.MoveLast();
                PRatesBindingSource.EndEdit();
                context.SaveChanges();
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
                ImageComboBoxEditLoadCode.Text = string.Empty;
                ImageComboBoxEditCopyCode.Text = string.Empty;
                GridControlCopy.DataSource = null;
                MessageBox.Show("Operation completed succesfully.");
                ImageComboBoxEditLoadCode.Focus();
            }

        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "START_DATE")
                if (e.Value != null)
                    if (!string.IsNullOrWhiteSpace(e.Value.ToString()))
                        e.DisplayText = validCheck.convertDate(e.Value.ToString());

            if (e.Column.FieldName == "END_DATE")
                if (e.Value != null)
                    if (!string.IsNullOrWhiteSpace(e.Value.ToString()))
                        e.DisplayText = validCheck.convertDate(e.Value.ToString());

            if (e.Column.FieldName == "ResDate_Start")
                if (e.Value != null)
                    if (!string.IsNullOrWhiteSpace(e.Value.ToString()))
                        e.DisplayText = validCheck.convertDate(e.Value.ToString());

            if (e.Column.FieldName == "ResDate_End")
                if (e.Value != null)
                    if (!string.IsNullOrWhiteSpace(e.Value.ToString()))
                        e.DisplayText = validCheck.convertDate(e.Value.ToString());

        }

        private void gridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "START_DATE")
                if (e.Value != null)
                    if (!string.IsNullOrWhiteSpace(e.Value.ToString()))
                        e.DisplayText = validCheck.convertDate(e.Value.ToString());

            if (e.Column.FieldName == "END_DATE")
                if (e.Value != null)
                    if (!string.IsNullOrWhiteSpace(e.Value.ToString()))
                        e.DisplayText = validCheck.convertDate(e.Value.ToString());

            if (e.Column.FieldName == "ResDate_Start")
                if (e.Value != null)
                    if (!string.IsNullOrWhiteSpace(e.Value.ToString()))
                        e.DisplayText = validCheck.convertDate(e.Value.ToString());

            if (e.Column.FieldName == "ResDate_End")
                if (e.Value != null)
                    if (!string.IsNullOrWhiteSpace(e.Value.ToString()))
                        e.DisplayText = validCheck.convertDate(e.Value.ToString());
        }

        private bool checkOverlap(DateTime time1, DateTime time2, DateTime dateStart2, DateTime dateEnd2)
        {
            bool val = true;

            if (time1 != null)
            {
                if ((time1 >= dateStart2 && time1 <= dateEnd2) || (time1 >= dateStart2 && dateEnd2 == null) || (time1 <= dateEnd2 && dateStart2 == null))
                {
                    val = false;
                }
            }
            if (time2 != null && time1 != time2)
            {
                if ((time2 >= dateStart2 && time2 <= dateEnd2) || (time2 >= dateStart2 && dateEnd2 == null) || (time2 <= dateEnd2 && dateStart2 == null) || (time1 <= dateStart2 && time2 >= dateEnd2))
                {
                    val = false;
                }
            }

            if (((time1 == null && time2 == null) || (dateStart2 == null && dateEnd2 == null)) && ((time1 == null && dateStart2 == null) || (time1 != null && dateStart2 != null)))
            {
                val = false;
            }
            return val;
        }


        private void gridView2_ValidateRow_1(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            using (Session session1 = new Session())
            {

                session1.BeginTransaction();
                try
                {

                    ColumnView view = sender as ColumnView;
                    GridColumn column1 = view.Columns["CODE"];
                    GridColumn column2 = view.Columns["AGENCY"];
                    GridColumn column3 = view.Columns["CAT"];
                    GridColumn column4 = view.Columns["Inactive"];
                    GridColumn column5 = view.Columns["START_DATE"];
                    GridColumn column6 = view.Columns["END_DATE"];
                    GridColumn column7 = view.Columns["ResDate_Start"];
                    GridColumn column8 = view.Columns["ResDate_End"];
                    //Get the value of the columns
                    string val1 = (string)view.GetRowCellValue(e.RowHandle, column1);
                    string val2 = (string)view.GetRowCellValue(e.RowHandle, column2);
                    string val3 = (string)view.GetRowCellValue(e.RowHandle, column3);
                    bool val4 = (bool)view.GetRowCellValue(e.RowHandle, column4);
                    DateTime time1 = (DateTime)view.GetRowCellValue(e.RowHandle, column5);
                    DateTime time2 = (DateTime)view.GetRowCellValue(e.RowHandle, column6);
                    DateTime time3 = new DateTime();
                    DateTime time4 = new DateTime();

                    if ((string)view.GetRowCellValue(e.RowHandle, column7) != null)
                        time3 = (DateTime)view.GetRowCellValue(e.RowHandle, column7);

                    if ((string)view.GetRowCellValue(e.RowHandle, column8) != null)
                        time4 = (DateTime)view.GetRowCellValue(e.RowHandle, column8);

                    var load = from c in context.PRATES where c.CODE == val1 && c.AGENCY == val2 && c.CAT == val3 && c.Inactive == val4 select new { c.START_DATE, c.END_DATE, c.ResDate_Start, c.ResDate_End };
                    //Validity criterion
                    if (load.Count() > 0)
                    {
                        foreach (var d in load)
                        {
                            DateTime dateStart2 = (DateTime)d.START_DATE;
                            DateTime dateEnd2 = (DateTime)d.END_DATE;
                            if (!checkOverlap(time1, time2, dateStart2, dateEnd2))
                            {
                                DateTime time5 = new DateTime();
                                DateTime time6 = new DateTime();

                                if (d.ResDate_Start != null)
                                    time5 = (DateTime)d.ResDate_Start;
                                if (d.ResDate_Start != null)
                                    time6 = (DateTime)d.ResDate_End;

                                if (!checkOverlap(time3, time4, time5, time6))
                                {
                                    GridViewCopy.SetRowCellValue(e.RowHandle, "Over", true);
                                    e.Valid = true;
                                }
                                
                                   
                            }
                        }
                    }

                    session1.CommitTransaction();
                }
                catch { session1.RollbackTransaction(); }
            }
        }

        private void PurgeButton_Click(object sender, System.EventArgs e)
        {
            if (GridViewLoad.SelectedRowsCount == 0)
            {
                MessageBox.Show("Please select at least one row before attempting to purge records.");
                return;
            }
            if (MessageBox.Show("Are you sure you want to purge the selected ratesheets ?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<int> values = new List<int>();
                foreach (int val in GridViewLoad.GetSelectedRows())
                {
                    values.Add((int)GridViewLoad.GetRowCellValue(val, "ID"));
                }
                foreach (int ID in values)
                {
                    PRATES rec = (from hratRec in context.PRATES where hratRec.ID == ID select hratRec).FirstOrDefault();
                    context.PRATES.DeleteObject(rec);
                    context.SaveChanges();
                }
            }
        }

        private void checkEdit12_Click(object sender, System.EventArgs e)
        {
            if (!CheckEditResEnd.Checked)
            {
                SpinEditResEnd.Enabled = true;
                ComboBoxEditResEndAdd.Enabled = true;
                ComboBoxEditResEndTerm.Enabled = true;
            }

            if (CheckEditResEnd.Checked)
            {
                SpinEditResEnd.Enabled = false;
                ComboBoxEditResEndAdd.Enabled = false;
                ComboBoxEditResEndTerm.Enabled = false;
            }
        }

        private void gridView2_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "Over" && e.IsGetData)
            {
                PRATES val = (PRATES)e.Row;

                if (!string.IsNullOrWhiteSpace(val.CODE) && !string.IsNullOrWhiteSpace(val.AGENCY) && !string.IsNullOrWhiteSpace(val.CAT) && val.START_DATE != null && val.END_DATE != null && val.ID != 0)
                {
                    var load = from c in context.PRATES where c.CODE == val.CODE && c.AGENCY == val.AGENCY && c.CAT == val.CAT && c.Inactive == val.Inactive select new { c.START_DATE, c.END_DATE, c.ResDate_Start, c.ResDate_End };
                    // 
                    foreach (var rec in load)
                    {
                        DateTime start = (DateTime)val.START_DATE;
                        DateTime end = (DateTime)val.END_DATE;
                        DateTime existStart = (DateTime)rec.START_DATE;
                        DateTime existEnd = (DateTime)rec.END_DATE;
                        if (!checkOverlap(start, end, existStart, existEnd))
                        {
                            DateTime resStart = new DateTime();
                            DateTime resEnd = new DateTime();
                            DateTime resStartExist = new DateTime();
                            DateTime resEndExist = new DateTime();
                            if (val.ResDate_Start != null)
                                resStart = (DateTime)val.ResDate_Start;
                            if (val.ResDate_End != null)
                                resEnd = (DateTime)val.ResDate_End;
                            if (rec.ResDate_Start != null)
                                resStartExist = (DateTime)rec.ResDate_Start;
                            if (rec.ResDate_End != null)
                                resEndExist = (DateTime)rec.ResDate_End;
                            if (!checkOverlap(resStart, resEnd, resStartExist, resEndExist))
                                e.Value = true;
                            else
                                e.Value = false;
                        }
                    }
                }
            }
        }

        private void checkEdit15_Click(object sender, System.EventArgs e)
        {
            if (!CheckEditInactive.Checked)
                ImageComboBoxEditInhouse.Enabled = true;

            if (CheckEditInactive.Checked)
                ImageComboBoxEditInhouse.Enabled = false;
        }

        private void checkEdit13_Click(object sender, System.EventArgs e)
        {
            if (!CheckEditSpecialCode.Checked)
                TextEditSpecialValueCode.Enabled = true;

            if (CheckEditSpecialCode.Checked)
                TextEditSpecialValueCode.Enabled = false;
        }

        
    }
}