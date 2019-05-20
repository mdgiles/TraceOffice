using System.Collections.Generic;
using FlexModel;
using System.Linq;
using System;
using System.ComponentModel;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Drawing;
using System.Collections;
using DevExpress.Xpo;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Runtime.InteropServices;
namespace TraceForms
{
    
    public partial class GroupForm : DevExpress.XtraEditors.XtraForm
    {
        public decimal mealsValue = 0;
        public string defAgy = "TARIFF";
        public FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public GroupForm(FlexCore.CoreSys _sys)
        {
            InitializeComponent();
            Connection.EFConnectionString = _sys.Settings.EFConnectionString;
            context = new FlextourEntities(_sys.Settings.EFConnectionString);
            gsLoad.gridSearchLoad(pkgSearch, "CODE", "NAME", "Code", "Name", "CODE", "CODE", "CODE");
            gsLoad.gridSearchLoad(catSearch, "CODE", "DESC", "Code", "Name", "CODE", "CODE", "CODE");
            gsLoad.gridSearchLoad(agencySearch, "NO", "NAME", "Code", "Name", "NO", "NO", "NO");
            pkgSearch.GridControl.DataSource = from c in context.PACK select new { c.CODE, c.NAME };
            agencySearch.GridControl.DataSource = from c in context.AGY select new { c.NO, c.NAME };
            catSearch.GridControl.DataSource = from c in context.ROOMCOD select new { c.CODE, c.DESC };
            cOMM_PCTTextEdit.Enabled = false;
        }

        private void groupSearchButton_Click(object sender, EventArgs e)
        {
            gridView1.SelectAll();
            gridView1.DeleteSelectedRows();
            if (pkgSearch.Text.Length == 0 || agencySearch.Text.Length == 0 || catSearch.Text.Length == 0 || sTART_DATEDateEdit1.Text.Length == 0 || nUM_PAXTextEdit.Text.Length == 0)
            {
                MessageBox.Show("Please fill out all the required fields: Package, Agency, Category, Start Date and Pax.");
                return;
            }
            int l = Convert.ToInt32(nUM_PAXTextEdit.Text);
            var pratGrpMatches = from c in context.PRATGRP
                                 where c.CODE == pkgSearch.Text.TrimEnd() && c.AGENCY == agencySearch.Text.TrimEnd() && c.CAT == catSearch.Text
                                     && c.START_DATE == Convert.ToDateTime(sTART_DATEDateEdit1.Text) && c.NUM_PAX == l
                                 select c;
            foreach (var results in pratGrpMatches)
            {
                var pratLinMatches = from c in context.PRATGLIN
                                     where c.CODE == results.CODE && c.AGENCY == results.AGENCY && c.CAT == results.CAT && c.START_DATE == results.START_DATE && c.NUM_PAX == results.NUM_PAX
                                         
                                     select c;

                foreach (var values in pratLinMatches)
                {
                    labelControl2.Text = values.LAST_UPD.ToString();
                    labelControl4.Text = values.UPD_INIT;
                    h_LTextEdit.Text = values.H_L;
                    yEARTextEdit.Text = values.YEAR;
                    eND_DATEDateEdit.Text = (values.END_DATE.Value).ToString();
                    dESCTextEdit.Text = results.DESC;
                    if (string.IsNullOrEmpty(results.USE_FIT) || results.USE_FIT.Length == 0)
                        uSE_FITCheckEdit.Checked = false;
                    else
                        uSE_FITCheckEdit.Checked = true;
                    mRKUP_PCTTextEdit.Text = results.MRKUP_PCT.ToString();
                    cOMMENT1TextEdit.Text = results.COMMENT1;
                    cOMMENT2TextEdit.Text = results.COMMENT2;
                    if (results.COMM_FLG == "Y")
                        cOMM_FLGCheckEdit.Checked = true;
                    else
                        cOMM_FLGCheckEdit.Checked = false;
                    if (agencySearch.Text.TrimEnd() == defAgy)
                    {
                        cOMM_PCTTextEdit.Enabled = true;
                        cOMM_PCTTextEdit.Text = results.COMM_PCT.ToString();
                    }

                    switch (values.TYPE)
                    {
                        case "HTL":
                            //dosomething
                            gridControl1.DataSource = from c in context.PRATGLIN
                                                      where c.CODE == results.CODE && c.AGENCY == results.AGENCY && c.CAT == results.CAT && c.START_DATE == results.START_DATE && c.NUM_PAX == results.NUM_PAX
                                                      && c.TYPE == "HTL"    
                                                      select c;
                            break;
                        case "OPT":
                            //
                            var serv = (from c in context.COMP where c.CODE == values.CODE1 select new { c.SERV_TYPE }).FirstOrDefault();
                            if (serv != null)
                            {
                                if (serv.SERV_TYPE == "BUSSG")
                                {
                                    gridControl2.DataSource = from c in context.PRATGLIN
                                                              where c.CODE == results.CODE && c.AGENCY == results.AGENCY && c.CAT == results.CAT && c.START_DATE == results.START_DATE && c.NUM_PAX == results.NUM_PAX
                                                              && c.TYPE == "OPT"
                                                              select c;
                                }
                                else
                                {
                                    gridControl3.DataSource = from c in context.PRATGLIN
                                                              where c.CODE == results.CODE && c.AGENCY == results.AGENCY && c.CAT == results.CAT && c.START_DATE == results.START_DATE && c.NUM_PAX == results.NUM_PAX
                                                              && c.TYPE == "OPT"
                                                              select c;
                                }
                            }
                            break;
                        case "AIR":
                            //
                            gridControl4.DataSource = from c in context.PRATGLIN
                                                      where c.CODE == results.CODE && c.AGENCY == results.AGENCY && c.CAT == results.CAT && c.START_DATE == results.START_DATE && c.NUM_PAX == results.NUM_PAX
                                                      && c.TYPE == "AIR"
                                                      select c;
                            break;
                        case "CRU":
                            //
                            gridControl5.DataSource = from c in context.PRATGLIN
                                                      where c.CODE == results.CODE && c.AGENCY == results.AGENCY && c.CAT == results.CAT && c.START_DATE == results.START_DATE && c.NUM_PAX == results.NUM_PAX
                                                      && c.TYPE == "CRU"
                                                      select c;
                            break;



                    }
                }
            }
            //display PMC and meal lines in hotel grid now
            if (gridView1.DataRowCount > 0)
            {
                colPORTERAGE.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                string portVal = colPORTERAGE.SummaryText;
                colMealCost.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                string mealVal = colMealCost.SummaryText;
                int porterage = Convert.ToInt32(portVal);
                int meals = Convert.ToInt32(mealVal);
                colPORTERAGE.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.None;
                colMealCost.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.None;
                gridView1.MoveLast();
                gridView1.AddNewRow();

                gridView1.SetFocusedRowCellValue("CODE1", "Porterage");                
                gridView1.SetFocusedRowCellValue(colSgl, porterage);                
                gridView1.SetFocusedRowCellValue("DBL", porterage);
                gridView1.SetFocusedRowCellValue("TPL", porterage);
                gridView1.SetFocusedRowCellValue("QUA", porterage);
                gridView1.SetFocusedRowCellValue("PORTERAGE", porterage);


                gridView1.MoveLast();
                gridView1.AddNewRow();
                gridView1.SetFocusedRowCellValue("CODE1", "Meals");
                gridView1.SetFocusedRowCellValue("SGL", meals);
                gridView1.SetFocusedRowCellValue("DBL", meals);
                gridView1.SetFocusedRowCellValue("TPL", meals);
                gridView1.SetFocusedRowCellValue("QUA", meals);
                gridView1.SetFocusedRowCellValue("JUN", meals);
                gridView1.SetFocusedRowCellValue("CHD", meals);
                gridView1.SetFocusedRowCellValue("MealCost", meals);


               
            }

            //populate totals grid
            gridView1.Focus();
            gridView1.MoveLast();

            //colSgl.SummaryText;
        }

        private void gridView1_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            
            //[SGL_NRATE]* (1 + ([TAX_PCT] / 100)) * [NBR_NITES]      [Nights] * [Meal Rate]
            if (e.Column.FieldName == "SGL" )
            {
                if (gridView1.GetRowCellValue(e.ListSourceRowIndex, "CODE1") != null)
                {
                    string val = gridView1.GetRowCellValue(e.ListSourceRowIndex, "CODE1").ToString();
                   
                    if (val == "Porterage")
                        e.Value = gridView1.GetRowCellValue(e.ListSourceRowIndex, "PORTERAGE");
                    else if (val == "Meals")
                    {                        
                        e.Value = mealsValue;
                    }
                    //else
                    //{
                    //    decimal sgl_n = Convert.ToDecimal(gridView1.GetRowCellValue(e.ListSourceRowIndex, "SGL_NRATE"));
                    //    decimal tax_p = Convert.ToDecimal(gridView1.GetRowCellValue(e.ListSourceRowIndex, "TAX_PCT"));
                    //    decimal nbr_n = Convert.ToDecimal(gridView1.GetRowCellValue(e.ListSourceRowIndex, "NBR_NITES"));
                    //    e.Value = sgl_n * (1 + (tax_p / 100)) * nbr_n;
                    //}
                }                    
            }
            if (e.Column.FieldName == "DBL")
            {
                if (gridView1.GetRowCellValue(e.ListSourceRowIndex, "CODE1") != null)
                {
                    string val = gridView1.GetRowCellValue(e.ListSourceRowIndex, "CODE1").ToString();

                    if (val == "Porterage")
                        e.Value = gridView1.GetRowCellValue(e.ListSourceRowIndex, "PORTERAGE");
                    else if (val == "Meals")
                    {
                        //decimal nights = Convert.ToDecimal(gridView1.GetRowCellValue(e.ListSourceRowIndex, "NBR_NITES"));
                        //decimal meal_rate = Convert.ToDecimal(gridView1.GetRowCellValue(e.ListSourceRowIndex, "MEAL1_ADN"));
                        e.Value = mealsValue;
                    }
                   
                }
            }

            if (e.Column.FieldName == "TPL")
            {
                if (gridView1.GetRowCellValue(e.ListSourceRowIndex, "CODE1") != null)
                {
                    string val = gridView1.GetRowCellValue(e.ListSourceRowIndex, "CODE1").ToString();

                    if (val == "Porterage")
                        e.Value = gridView1.GetRowCellValue(e.ListSourceRowIndex, "PORTERAGE");
                    else if (val == "Meals")
                    {
                       e.Value = mealsValue;
                    }

                }
            }

            if (e.Column.FieldName == "QUA")
            {
                if (gridView1.GetRowCellValue(e.ListSourceRowIndex, "CODE1") != null)
                {
                    string val = gridView1.GetRowCellValue(e.ListSourceRowIndex, "CODE1").ToString();

                    if (val == "Porterage")
                        e.Value = gridView1.GetRowCellValue(e.ListSourceRowIndex, "PORTERAGE");
                    else if (val == "Meals")
                    {
                        e.Value = mealsValue;
                    }

                }
            }
            if (e.Column.FieldName == "JUN")
            {
                if (gridView1.GetRowCellValue(e.ListSourceRowIndex, "CODE1") != null)
                {
                    string val = gridView1.GetRowCellValue(e.ListSourceRowIndex, "CODE1").ToString();

                   if (val == "Meals")
                    {
                        e.Value = mealsValue;
                    }

                }
            }

            if (e.Column.FieldName == "CHD")
            {
                if (gridView1.GetRowCellValue(e.ListSourceRowIndex, "CODE1") != null)
                {
                    string val = gridView1.GetRowCellValue(e.ListSourceRowIndex, "CODE1").ToString();

                    if (val == "Meals")
                    {
                         e.Value = mealsValue;
                    }

                }
            }
            if (e.Column.FieldName == "MealCost")
            {
                if (gridView1.GetRowCellValue(e.ListSourceRowIndex, "CODE1") != null)
                {
                    string val = gridView1.GetRowCellValue(e.ListSourceRowIndex, "CODE1").ToString();
                    if (val == "Meals")
                    {
                        e.Value = mealsValue;
                    }
                    if (val != "Porterage" && val != "Meals")
                    {

                        decimal nights = Convert.ToDecimal(gridView1.GetRowCellValue(e.ListSourceRowIndex, "NBR_NITES"));
                        decimal meal_rate = Convert.ToDecimal(gridView1.GetRowCellValue(e.ListSourceRowIndex, "MEAL1_ADN"));
                        mealsValue = nights * meal_rate;
                        e.Value = mealsValue;

                    }
                }
            }
            
        }

     

        private void sTART_DATEDateEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void sTART_DATEDateEdit1_TextChanged(object sender, EventArgs e)
        {
            sTART_DATEDateEdit1.Text = validCheck.convertDate(sTART_DATEDateEdit1.Text);
        }

        private void eND_DATEDateEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void eND_DATEDateEdit_TextChanged(object sender, EventArgs e)
        {
            eND_DATEDateEdit.Text = validCheck.convertDate(eND_DATEDateEdit.Text);
        }

        private void GroupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (modified || newRec)
            //{
            //    DialogResult select = DevExpress.XtraEditors.XtraMessageBox.Show("There are unsaved changes. Are you sure want to exit?", Name, MessageBoxButtons.YesNo);
            //    if (select == DialogResult.Yes)
            //    {
            //        e.Cancel = false;
            //        this.Dispose();
            //    }
            //    else if (select == DialogResult.No)
            //        e.Cancel = true;
            //}
            //else
            //{
            //    e.Cancel = false;
            //    this.Dispose();
            //}
        }

  
    }
}