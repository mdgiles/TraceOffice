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
   
    public partial class cpratesCopyForm : DevExpress.XtraEditors.XtraForm
    {
        public FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public string username;
        public cpratesCopyForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
            LoadLookups();
            username = sys.User.Name;
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);          
        }

        private void LoadLookups()
        {
            var agy = from agyRec in context.AGY orderby agyRec.NO ascending select new { agyRec.NO, agyRec.NAME };
            var comp = from airRec in context.COMP orderby airRec.CODE ascending select new { airRec.CODE, airRec.NAME };
            var cat = from catRec in context.ROOMCOD orderby catRec.CODE ascending select new { catRec.CODE, catRec.DESC };
           
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxEditLoadCode.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCopyCode.Properties.Items.Add(loadBlank);
            ImageComboBoxEditAgency.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCategory.Properties.Items.Add(loadBlank);
            foreach (var result in comp)
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
            ImageComboBoxEditCategory.Properties.ReadOnly = true;
            ImageComboBoxEditAgency.Properties.ReadOnly = true;
        }


      

        void ButtonEdit_QueryPopUp(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
        }

        private void checkEdit1_Click(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
                simpleButton1.Text = "Copy";

            if (!checkEdit1.Checked)
                simpleButton1.Text = "Overwrite";
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

        private void checkEdit12_Click(object sender, EventArgs e)
        {
            if (!CheckEditTime.Checked)
                TextEditTime.Enabled = true;

            if (CheckEditTime.Checked)
                TextEditTime.Enabled = false;
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

        private void checkEdit11_Click(object sender, EventArgs e)
        {
            if (!CheckEditYear.Checked)
                TextEditYear.Enabled = true;

            if (CheckEditYear.Checked)
                TextEditYear.Enabled = false;
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //preview
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
                GridViewCopy.SetFocusedRowCellValue("AGENCY", GridViewLoad.GetRowCellValue(val, "AGENCY"));
                GridViewCopy.SetFocusedRowCellValue("CAT", GridViewLoad.GetRowCellValue(val, "CAT"));
                GridViewCopy.SetFocusedRowCellValue("START_DATE", GridViewLoad.GetRowCellValue(val, "START_DATE"));
                GridViewCopy.SetFocusedRowCellValue("END_DATE", GridViewLoad.GetRowCellValue(val, "END_DATE"));
                GridViewCopy.SetFocusedRowCellValue("YEAR", GridViewLoad.GetRowCellValue(val, "YEAR"));
                GridViewCopy.SetFocusedRowCellValue("H_L", GridViewLoad.GetRowCellValue(val, "H_L"));
                GridViewCopy.SetFocusedRowCellValue("ID", GridViewLoad.GetRowCellValue(val, "ID"));
                GridViewCopy.SetFocusedRowCellValue("ResDate_Start", GridViewLoad.GetRowCellValue(val, "ResDate_Start"));
                GridViewCopy.SetFocusedRowCellValue("ResDate_End", GridViewLoad.GetRowCellValue(val, "ResDate_End"));
                GridViewCopy.SetFocusedRowCellValue("Inactive", GridViewLoad.GetRowCellValue(val, "Inactive"));
                GridViewCopy.SetFocusedRowCellValue("Time", GridViewLoad.GetRowCellValue(val, "Time"));
                GridViewCopy.SetFocusedRowCellValue("DESC", GridViewLoad.GetRowCellValue(val, "DESC"));
                GridViewCopy.SetFocusedRowCellValue("LAST_UPD", DateTime.Now);
                GridViewCopy.SetFocusedRowCellValue("UPD_INIT", username);                
                GridViewCopy.SetFocusedRowCellValue("PP1", GridViewLoad.GetRowCellValue(val, "PP1"));
                GridViewCopy.SetFocusedRowCellValue("PP2", GridViewLoad.GetRowCellValue(val, "PP2"));
                GridViewCopy.SetFocusedRowCellValue("PP3", GridViewLoad.GetRowCellValue(val, "PP3"));
                GridViewCopy.SetFocusedRowCellValue("PP4", GridViewLoad.GetRowCellValue(val, "PP4"));
                GridViewCopy.SetFocusedRowCellValue("PP5", GridViewLoad.GetRowCellValue(val, "PP5"));
                GridViewCopy.SetFocusedRowCellValue("PP6", GridViewLoad.GetRowCellValue(val, "PP6"));
                GridViewCopy.SetFocusedRowCellValue("PP7", GridViewLoad.GetRowCellValue(val, "PP7"));
                GridViewCopy.SetFocusedRowCellValue("PP8", GridViewLoad.GetRowCellValue(val, "PP8"));
                GridViewCopy.SetFocusedRowCellValue("PP9", GridViewLoad.GetRowCellValue(val, "PP9"));
                GridViewCopy.SetFocusedRowCellValue("PP10", GridViewLoad.GetRowCellValue(val, "PP10"));
                GridViewCopy.SetFocusedRowCellValue("GPP1", GridViewLoad.GetRowCellValue(val, "GPP1"));
                GridViewCopy.SetFocusedRowCellValue("GPP2", GridViewLoad.GetRowCellValue(val, "GPP2"));
                GridViewCopy.SetFocusedRowCellValue("GPP3", GridViewLoad.GetRowCellValue(val, "GPP3"));
                GridViewCopy.SetFocusedRowCellValue("GPP4", GridViewLoad.GetRowCellValue(val, "GPP4"));
                GridViewCopy.SetFocusedRowCellValue("GPP5", GridViewLoad.GetRowCellValue(val, "GPP5"));
                GridViewCopy.SetFocusedRowCellValue("GPP6", GridViewLoad.GetRowCellValue(val, "GPP6"));
                GridViewCopy.SetFocusedRowCellValue("GPP7", GridViewLoad.GetRowCellValue(val, "GPP7"));
                GridViewCopy.SetFocusedRowCellValue("GPP8", GridViewLoad.GetRowCellValue(val, "GPP8"));
                GridViewCopy.SetFocusedRowCellValue("GPP9", GridViewLoad.GetRowCellValue(val, "GPP9"));
                GridViewCopy.SetFocusedRowCellValue("GPP10", GridViewLoad.GetRowCellValue(val, "GPP10"));
                GridViewCopy.SetFocusedRowCellValue("NPP1", GridViewLoad.GetRowCellValue(val, "NPP1"));
                GridViewCopy.SetFocusedRowCellValue("NPP2", GridViewLoad.GetRowCellValue(val, "NPP2"));
                GridViewCopy.SetFocusedRowCellValue("NPP3", GridViewLoad.GetRowCellValue(val, "NPP3"));
                GridViewCopy.SetFocusedRowCellValue("NPP4", GridViewLoad.GetRowCellValue(val, "NPP4"));
                GridViewCopy.SetFocusedRowCellValue("NPP5", GridViewLoad.GetRowCellValue(val, "NPP5"));
                GridViewCopy.SetFocusedRowCellValue("NPP6", GridViewLoad.GetRowCellValue(val, "NPP6"));
                GridViewCopy.SetFocusedRowCellValue("NPP7", GridViewLoad.GetRowCellValue(val, "NPP7"));
                GridViewCopy.SetFocusedRowCellValue("NPP8", GridViewLoad.GetRowCellValue(val, "NPP8"));
                GridViewCopy.SetFocusedRowCellValue("NPP9", GridViewLoad.GetRowCellValue(val, "NPP9"));
                GridViewCopy.SetFocusedRowCellValue("NPP10", GridViewLoad.GetRowCellValue(val, "NPP10"));               
                GridViewCopy.SetFocusedRowCellValue("CHD_GRATE", GridViewLoad.GetRowCellValue(val, "CHD_GRATE"));
                GridViewCopy.SetFocusedRowCellValue("CHD_NRATE", GridViewLoad.GetRowCellValue(val, "CHD_NRATE"));
                GridViewCopy.SetFocusedRowCellValue("CHD_LIMIT", GridViewLoad.GetRowCellValue(val, "CHD_LIMIT"));
                GridViewCopy.SetFocusedRowCellValue("JR_LIMIT", GridViewLoad.GetRowCellValue(val, "JR_LIMIT"));
                GridViewCopy.SetFocusedRowCellValue("JR_GRATE", GridViewLoad.GetRowCellValue(val, "JR_GRATE"));
                GridViewCopy.SetFocusedRowCellValue("JR_NRATE", GridViewLoad.GetRowCellValue(val, "JR_NRATE"));
                GridViewCopy.SetFocusedRowCellValue("COMM_FLG", GridViewLoad.GetRowCellValue(val, "COMM_FLG"));
                GridViewCopy.SetFocusedRowCellValue("COMM_PCT", GridViewLoad.GetRowCellValue(val, "COMM_PCT"));
                GridViewCopy.SetFocusedRowCellValue("Transport_Type", GridViewLoad.GetRowCellValue(val, "Transport_Type"));
                GridViewCopy.SetFocusedRowCellValue("Vendor_Code", GridViewLoad.GetRowCellValue(val, "Vendor_Code"));
                GridViewCopy.SetFocusedRowCellValue("Unit_Rate", GridViewLoad.GetRowCellValue(val, "Unit_Rate"));
                GridViewCopy.SetFocusedRowCellValue("Inhouse", GridViewLoad.GetRowCellValue(val, "Inhouse"));               
                GridViewCopy.SetFocusedRowCellValue("Vendor_Code_Jr", GridViewLoad.GetRowCellValue(val, "Vendor_Code_Jr"));
                GridViewCopy.SetFocusedRowCellValue("Vendor_Code_Chd", GridViewLoad.GetRowCellValue(val, "Vendor_Code_Chd"));
                GridViewCopy.SetFocusedRowCellValue("SpecialValue_Code", GridViewLoad.GetRowCellValue(val, "SpecialValue_Code"));
                GridViewCopy.SetFocusedRowCellValue("Currency_CodeSheet", GridViewLoad.GetRowCellValue(val, "Currency_CodeSheet"));
                GridViewCopy.SetFocusedRowCellValue("Currency_CodePayment", GridViewLoad.GetRowCellValue(val, "Currency_CodePayment"));
                GridViewCopy.SetFocusedRowCellValue("ExchangeRate", GridViewLoad.GetRowCellValue(val, "ExchangeRate"));
                GridViewCopy.SetFocusedRowCellValue("BusTourDays", GridViewLoad.GetRowCellValue(val, "BusTourDays"));
                GridViewCopy.SetFocusedRowCellValue("BusTourStops", GridViewLoad.GetRowCellValue(val, "BusTourStops"));
                GridViewCopy.SetFocusedRowCellValue("Comp_Type", GridViewLoad.GetRowCellValue(val, "Comp_Type"));
                GridViewCopy.SetFocusedRowCellValue("SeniorAgeLimit", GridViewLoad.GetRowCellValue(val, "SeniorAgeLimit"));
                GridViewCopy.SetFocusedRowCellValue("SeniorCost", GridViewLoad.GetRowCellValue(val, "SeniorCost"));
                GridViewCopy.SetFocusedRowCellValue("SeniorGross", GridViewLoad.GetRowCellValue(val, "SeniorGross"));
                GridViewCopy.SetFocusedRowCellValue("SeniorRetail", GridViewLoad.GetRowCellValue(val, "SeniorRetail"));
                GridViewCopy.SetFocusedRowCellValue("Retail1", GridViewLoad.GetRowCellValue(val, "Retail1"));
                GridViewCopy.SetFocusedRowCellValue("Retail2", GridViewLoad.GetRowCellValue(val, "Retail2"));
                GridViewCopy.SetFocusedRowCellValue("Retail3", GridViewLoad.GetRowCellValue(val, "Retail3"));
                GridViewCopy.SetFocusedRowCellValue("Retail4", GridViewLoad.GetRowCellValue(val, "Retail4"));
                GridViewCopy.SetFocusedRowCellValue("Retail5", GridViewLoad.GetRowCellValue(val, "Retail5"));
                GridViewCopy.SetFocusedRowCellValue("Retail6", GridViewLoad.GetRowCellValue(val, "Retail6"));
                GridViewCopy.SetFocusedRowCellValue("Retail7", GridViewLoad.GetRowCellValue(val, "Retail7"));
                GridViewCopy.SetFocusedRowCellValue("Retail8", GridViewLoad.GetRowCellValue(val, "Retail8"));
                GridViewCopy.SetFocusedRowCellValue("Retail9", GridViewLoad.GetRowCellValue(val, "Retail9"));
                GridViewCopy.SetFocusedRowCellValue("Retail10", GridViewLoad.GetRowCellValue(val, "Retail10"));
                GridViewCopy.SetFocusedRowCellValue("Retail10", GridViewLoad.GetRowCellValue(val, "Retail10"));
                GridViewCopy.SetFocusedRowCellValue("ChildRetail", GridViewLoad.GetRowCellValue(val, "ChildRetail"));
                GridViewCopy.SetFocusedRowCellValue("JuniorRetail", GridViewLoad.GetRowCellValue(val, "JuniorRetail"));
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

        private void simpleButton2_Click(object sender, EventArgs e)
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

            if (TextEditSpecialCode.Enabled == true)
            {
                for (int i = 0; i < GridViewCopy.RowCount; i++)
                    GridViewCopy.SetRowCellValue(i, GridViewCopy.Columns["SpecialValue_Code"], TextEditSpecialCode.Text);
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
            if (TextEditTime.Enabled == true)
            {
                for (int i = 0; i < GridViewCopy.RowCount; i++)
                    GridViewCopy.SetRowCellValue(i, GridViewCopy.Columns["Time"], TextEditTime.Text);
            }
           
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

        private void gridView2_ValidateRow(object sender, ValidateRowEventArgs e)
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
                    GridColumn column4 = view.Columns["Time"];
                    GridColumn column5 = view.Columns["START_DATE"];
                    GridColumn column6 = view.Columns["END_DATE"];
                    GridColumn column7 = view.Columns["ResDate_Start"];
                    GridColumn column8 = view.Columns["ResDate_End"];
                    //Get the value of the columns
                    string val1 = (string)view.GetRowCellValue(e.RowHandle, column1);
                    string val2 = (string)view.GetRowCellValue(e.RowHandle, column2);
                    string val3 = (string)view.GetRowCellValue(e.RowHandle, column3);
                    string val4 = (string)view.GetRowCellValue(e.RowHandle, column4);
                    DateTime time1 = (DateTime)view.GetRowCellValue(e.RowHandle, column5);
                    DateTime time2 = (DateTime)view.GetRowCellValue(e.RowHandle, column6);
                    DateTime time3 = new DateTime();
                    DateTime time4 = new DateTime();
                    if((string)view.GetRowCellValue(e.RowHandle, column7) != null)   
                        time3 = (DateTime)view.GetRowCellValue(e.RowHandle, column7);
                    if ((string)view.GetRowCellValue(e.RowHandle, column8) != null)
                        time4 = (DateTime)view.GetRowCellValue(e.RowHandle, column8);

                    var load = from c in context.CPRATES where c.CODE == val1 && c.AGENCY == val2 && c.CAT == val3  select new { c.START_DATE, c.END_DATE, c.ResDate_Start, c.ResDate_End };
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

                                if(d.ResDate_Start != null)
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
                CpRatesBindingSource.EndEdit();
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

        private void ImageComboBoxEditLoadCode_TextChanged(object sender, System.EventArgs e)
        {
            string carCo = ImageComboBoxEditLoadCode.EditValue.ToString();
            GridControlLoad.DataSource = from c in context.CPRATES where c.CODE == carCo select c;
        }

        private void ImageComboBoxEditCopyCode_TextChanged(object sender, System.EventArgs e)
        {
            string carCo = ImageComboBoxEditCopyCode.EditValue.ToString();
            GridControlCopy.DataSource = from c in context.CPRATES where c.CODE == carCo && c.CAT == "KJM" select c;
        }

        private void PurgeButton_Click(object sender, EventArgs e)
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
                    CPRATES rec = (from hratRec in context.CPRATES where hratRec.ID == ID select hratRec).FirstOrDefault();
                    context.CPRATES.DeleteObject(rec);
                    context.SaveChanges();
                }
            }
        }

        private void gridView2_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "Over" && e.IsGetData)
            {
                CPRATES val = (CPRATES)e.Row;

                if (!string.IsNullOrWhiteSpace(val.CODE) && !string.IsNullOrWhiteSpace(val.AGENCY) && !string.IsNullOrWhiteSpace(val.CAT) && val.START_DATE != null && val.END_DATE != null && val.ID != 0)
                {
                    var load = from c in context.CPRATES where c.CODE == val.CODE && c.AGENCY == val.AGENCY && c.CAT == val.CAT && c.Inactive == val.Inactive select new { c.START_DATE, c.END_DATE, c.ResDate_Start, c.ResDate_End };
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

        private void gridView2_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
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

        private void SaveButton_Click(object sender, EventArgs e)
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
                CpRatesBindingSource.EndEdit();
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

        private void checkEdit9_Click(object sender, EventArgs e)
        {
            if (!CheckEditResEnd.Checked)
            {
                SpinEditResEnd.Enabled = true;
                ComboBoxEditResEndTerm.Enabled = true;
                ComboBoxEditResEndAdd.Enabled = true;
            }

            if (CheckEditResEnd.Checked)
            {
                SpinEditResEnd.Enabled = false;
                ComboBoxEditResEndTerm.Enabled = false;
                ComboBoxEditResEndAdd.Enabled = false;
            }
        }

        private void checkEdit13_Click(object sender, EventArgs e)
        {
            if (!CheckEditInactive.Checked)
                ImageComboBoxEditInhouse.Enabled = true;

            if (CheckEditInactive.Checked)
                ImageComboBoxEditInhouse.Enabled = false;
        }

        private void checkEdit14_Click(object sender, EventArgs e)
        {
            if (!CheckEditSpecialCode.Checked)
                TextEditSpecialCode.Enabled = true;

            if (CheckEditSpecialCode.Checked)
                TextEditSpecialCode.Enabled = false;
        }
     
    }
}