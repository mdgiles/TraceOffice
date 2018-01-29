using System.Collections.Generic;
using FlexModel;
using System.Linq;
using System;
using System.ComponentModel;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Xpo;
using System.Drawing;
using System.Collections;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

using System.Collections.Generic;
using FlexModel;
using System.Linq;
using System;
using System.ComponentModel;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Xpo;
using System.Drawing;
using System.Collections;
using System.Runtime.InteropServices;

using System.Windows.Forms;
using System.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using FlexModel;
using DevExpress.XtraEditors.Controls;
using System.Runtime.InteropServices;
using System.Data.Entity.Core.Objects;

using DevExpress.Data.Linq;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraGrid;


namespace TraceForms
{
     
    public partial class caRateCopyForm : DevExpress.XtraEditors.XtraForm
    {
        public FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public caRateCopyForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
            LoadLookups();          
                
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);            
        }

        private void LoadLookups()
        {
            var agy = from agyRec in context.AGY orderby agyRec.NO ascending select new { agyRec.NO, agyRec.NAME };
            var car = from airRec in context.CARINFO orderby airRec.CODE ascending select new { airRec.CODE, airRec.NAME };
            var cat = from catRec in context.ROOMCOD orderby catRec.CODE ascending select new { catRec.CODE, catRec.DESC };
            var cty = from ctyRec in context.CITYCOD orderby ctyRec.CODE ascending select new { ctyRec.CODE, ctyRec.NAME };
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxEditLoadCode.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCopyCode.Properties.Items.Add(loadBlank);
            ImageComboBoxEditAgency.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCategory.Properties.Items.Add(loadBlank);
            ImageComboBoxEditOffice.Properties.Items.Add(loadBlank);
            foreach (var result in car)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditLoadCode.Properties.Items.Add(load);
                ImageComboBoxEditCopyCode.Properties.Items.Add(load);
            }
            foreach (var result in cty)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditOffice.Properties.Items.Add(load);             
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
            ImageComboBoxEditOffice.Properties.ReadOnly = true;
        }

       

        void ButtonEdit_QueryPopUp(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
        }

        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                if (gridView1.IsRowSelected(e.RowHandle))
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
            gridView1.InvalidateRowIndicator(e.ControllerRow);
        }

        private void checkEdit2_Click(object sender, EventArgs e)
        {
            if (!checkEdit2.Checked)
                gridView1.SelectAll();
            if (checkEdit2.Checked)
                gridView1.ClearSelection();
        }

        private void checkEdit3_Click(object sender, EventArgs e)
        {
            if (!checkEdit3.Checked)
                ImageComboBoxEditAgency.Properties.ReadOnly = false;

            if (checkEdit3.Checked)
                ImageComboBoxEditAgency.Properties.ReadOnly = true;  
        }

        private void checkEdit4_Click(object sender, EventArgs e)
        {
            if (!checkEdit4.Checked)
                ImageComboBoxEditCategory.Properties.ReadOnly = false;

            if (checkEdit4.Checked)
                ImageComboBoxEditCategory.Properties.ReadOnly = true;
        }

        private void checkEdit5_Click(object sender, EventArgs e)
        {
            if (!checkEdit5.Checked)
            {
                spinEdit1.Enabled = true;
                comboBoxEdit1.Enabled = true;
                comboBoxEdit2.Enabled = true;
            }
            if (checkEdit5.Checked)
            {
                spinEdit1.Enabled = false;
                comboBoxEdit1.Enabled = false;
                comboBoxEdit2.Enabled = false;
            }
        }

        private void checkEdit6_Click(object sender, EventArgs e)
        {
            if (!checkEdit6.Checked)
            {
                spinEdit2.Enabled = true;
                comboBoxEdit3.Enabled = true;
                comboBoxEdit4.Enabled = true;
            }

            if (checkEdit6.Checked)
            {
                spinEdit2.Enabled = false;
                comboBoxEdit3.Enabled = false;
                comboBoxEdit4.Enabled = false;
            } 
        }

        private void checkEdit11_Click(object sender, EventArgs e)
        {
            if (!checkEdit11.Checked)
                textEdit9.Enabled = true;

            if (checkEdit11.Checked)
                textEdit9.Enabled = false;
        }

        private void checkEdit7_Click(object sender, EventArgs e)
        {
            if (!checkEdit7.Checked)
                textEdit1.Enabled = true;

            if (checkEdit7.Checked)
                textEdit1.Enabled = false;
        }

        private void checkEdit9_Click(object sender, EventArgs e)
        {
            if (!checkEdit9.Checked)
                ImageComboBoxEditOffice.Properties.ReadOnly = false;

            if (checkEdit9.Checked)
                ImageComboBoxEditOffice.Properties.ReadOnly = true;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int j = gridView2.DataRowCount + 1;

            for (int i = 0; i < j; i++)
            {
                gridView2.MoveFirst();
                gridView2.DeleteRow(gridView2.FocusedRowHandle);
            }


            foreach (int val in gridView1.GetSelectedRows())
            {
                gridView2.AddNewRow();
                gridView2.SetFocusedRowCellValue("CODE", ImageComboBoxEditLoadCode.EditValue);
                gridView2.SetFocusedRowCellValue("AGENCY", gridView1.GetRowCellValue(val, "AGENCY"));
                gridView2.SetFocusedRowCellValue("CAT", gridView1.GetRowCellValue(val, "CAT"));

                gridView2.SetFocusedRowCellValue("ID", gridView1.GetRowCellValue(val, "ID"));

                gridView2.SetFocusedRowCellValue("START_DATE", gridView1.GetRowCellValue(val, "START_DATE"));
                gridView2.SetFocusedRowCellValue("END_DATE", gridView1.GetRowCellValue(val, "END_DATE"));
                gridView2.SetFocusedRowCellValue("YEAR", gridView1.GetRowCellValue(val, "YEAR"));
                gridView2.SetFocusedRowCellValue("H_L", gridView1.GetRowCellValue(val, "H_L"));
                gridView2.SetFocusedRowCellValue("OFF", gridView1.GetRowCellValue(val, "OFF"));
                gridView2.SetFocusedRowCellValue("LAST_UPD", gridView1.GetRowCellValue(val, "LAST_UPD"));
                gridView2.SetFocusedRowCellValue("UPD_INIT", gridView1.GetRowCellValue(val, "UPD_INIT"));
                gridView2.SetFocusedRowCellValue("DESCRIPTION", gridView1.GetRowCellValue(val, "DESCRIPTION"));
                gridView2.SetFocusedRowCellValue("GWKLY_RATE", gridView1.GetRowCellValue(val, "GWKLY_RATE"));
                gridView2.SetFocusedRowCellValue("GDAY_RATE", gridView1.GetRowCellValue(val, "GDAY_RATE"));
                gridView2.SetFocusedRowCellValue("GXTRA_RATE", gridView1.GetRowCellValue(val, "GXTRA_RATE"));
                gridView2.SetFocusedRowCellValue("GADNL_DRVR", gridView1.GetRowCellValue(val, "GADNL_DRVR"));
                gridView2.SetFocusedRowCellValue("GUNDR_AGE", gridView1.GetRowCellValue(val, "GUNDR_AGE"));
                gridView2.SetFocusedRowCellValue("NWKLY_RATE", gridView1.GetRowCellValue(val, "NWKLY_RATE"));
                gridView2.SetFocusedRowCellValue("NDAY_RATE", gridView1.GetRowCellValue(val, "NDAY_RATE"));
                gridView2.SetFocusedRowCellValue("NXTRA_RATE", gridView1.GetRowCellValue(val, "NXTRA_RATE"));
                gridView2.SetFocusedRowCellValue("NADNL_DRVR", gridView1.GetRowCellValue(val, "NADNL_DRVR"));
                gridView2.SetFocusedRowCellValue("NUNDR_AGE", gridView1.GetRowCellValue(val, "NUNDR_AGE"));
                gridView2.SetFocusedRowCellValue("WKMIN_DAYS", gridView1.GetRowCellValue(val, "WKMIN_DAYS"));
                gridView2.SetFocusedRowCellValue("WKMAX_DAYS", gridView1.GetRowCellValue(val, "WKMAX_DAYS"));
                gridView2.SetFocusedRowCellValue("COMM_FLG", gridView1.GetRowCellValue(val, "COMM_FLG"));
                gridView2.SetFocusedRowCellValue("COMM_PCT", gridView1.GetRowCellValue(val, "COMM_PCT"));
            }
            gridView2.Focus();
            gridView1.Focus();
            if (checkEdit1.Checked)
            {
                if (MessageBox.Show("Are you sure you want to delete the original records?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    gridView1.DeleteSelectedRows();
                    context.SaveChanges();
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            gridView2.MoveFirst();
            gridView2.Focus();



            if (ImageComboBoxEditAgency.Properties.ReadOnly == false)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                    gridView2.SetRowCellValue(i, gridView2.Columns["AGENCY"], ImageComboBoxEditAgency.EditValue);
            }

            if (ImageComboBoxEditCategory.Properties.ReadOnly == false)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                    gridView2.SetRowCellValue(i, gridView2.Columns["CAT"], ImageComboBoxEditCategory.EditValue);
            }

            if (ImageComboBoxEditOffice.Properties.ReadOnly == false)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                    gridView2.SetRowCellValue(i, gridView2.Columns["OFF"], ImageComboBoxEditOffice.EditValue);
            }

            if (spinEdit1.Enabled == true)
            {
                if (gridView2.RowCount == 1)
                {
                    if (!string.IsNullOrWhiteSpace(gridView2.GetFocusedRowCellDisplayText("START_DATE")))
                    {
                        DateTime time = (DateTime)gridView2.GetFocusedRowCellValue("START_DATE");
                        int val = (int)spinEdit1.Value;
                        if (comboBoxEdit1.Text == "-      Subtract")
                            val *= -1;

                        if (comboBoxEdit2.Text == "Days")
                            gridView2.SetFocusedRowCellValue("START_DATE", time.AddDays(val));

                        if (comboBoxEdit2.Text == "Months")
                            gridView2.SetFocusedRowCellValue("START_DATE", time.AddMonths(val));

                        if (comboBoxEdit2.Text == "Years")
                            gridView2.SetFocusedRowCellValue("START_DATE", time.AddYears(val));
                    }
                }
                else
                {
                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        if (!string.IsNullOrWhiteSpace(gridView2.GetFocusedRowCellDisplayText("START_DATE")))
                        {
                            DateTime time = (DateTime)gridView2.GetRowCellValue(i, "START_DATE");
                            int val = (int)spinEdit1.Value;
                            if (comboBoxEdit1.Text == "-      Subtract")
                                val *= -1;

                            if (comboBoxEdit2.Text == "Days")
                                gridView2.SetRowCellValue(i, gridView2.Columns["START_DATE"], time.AddDays(val));

                            if (comboBoxEdit2.Text == "Months")
                                gridView2.SetRowCellValue(i, gridView2.Columns["START_DATE"], time.AddMonths(val));

                            if (comboBoxEdit2.Text == "Years")
                                gridView2.SetRowCellValue(i, gridView2.Columns["START_DATE"], time.AddYears(val));
                        }
                    }
                }
            }
            if (spinEdit2.Enabled == true)
            {
                if (gridView2.RowCount == 1)
                {
                    if (!string.IsNullOrWhiteSpace(gridView2.GetFocusedRowCellDisplayText("END_DATE")))
                    {
                        DateTime time = (DateTime)gridView2.GetFocusedRowCellValue("END_DATE");
                        int val = (int)spinEdit2.Value;
                        if (comboBoxEdit3.Text == "-      Subtract")
                            val *= -1;

                        if (comboBoxEdit4.Text == "Days")
                            gridView2.SetFocusedRowCellValue("END_DATE", time.AddDays(val));

                        if (comboBoxEdit4.Text == "Months")
                            gridView2.SetFocusedRowCellValue("END_DATE", time.AddMonths(val));

                        if (comboBoxEdit4.Text == "Years")
                            gridView2.SetFocusedRowCellValue("END_DATE", time.AddYears(val));
                    }
                }
                else
                {
                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        if (!string.IsNullOrWhiteSpace(gridView2.GetFocusedRowCellDisplayText("END_DATE")))
                        {
                            DateTime time = (DateTime)gridView2.GetRowCellValue(i, "END_DATE");
                            int val = (int)spinEdit2.Value;
                            if (comboBoxEdit3.Text == "-      Subtract")
                                val *= -1;

                            if (comboBoxEdit4.Text == "Days")
                                gridView2.SetRowCellValue(i, gridView2.Columns["END_DATE"], time.AddDays(val));

                            if (comboBoxEdit4.Text == "Months")
                                gridView2.SetRowCellValue(i, gridView2.Columns["END_DATE"], time.AddMonths(val));

                            if (comboBoxEdit4.Text == "Years")
                                gridView2.SetRowCellValue(i, gridView2.Columns["END_DATE"], time.AddYears(val));
                        }
                    }
                }
            }

            if (textEdit9.Enabled == true)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                    gridView2.SetRowCellValue(i, gridView2.Columns["YEAR"], textEdit9.Text);
            }
            if (textEdit1.Enabled == true)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                    gridView2.SetRowCellValue(i, gridView2.Columns["H_L"], textEdit1.Text);
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
                    GridColumn column4 = view.Columns["OFF"];
                    GridColumn column5 = view.Columns["START_DATE"];
                    GridColumn column6 = view.Columns["END_DATE"];
                    //Get the value of the columns
                    string val1 = (string)view.GetRowCellValue(e.RowHandle, column1);
                    string val2 = (string)view.GetRowCellValue(e.RowHandle, column2);
                    string val3 = (string)view.GetRowCellValue(e.RowHandle, column3);
                    string val4 = (string)view.GetRowCellValue(e.RowHandle, column4);
                    DateTime time1 = (DateTime)view.GetRowCellValue(e.RowHandle, column5);
                    DateTime time2 = (DateTime)view.GetRowCellValue(e.RowHandle, column6);

                    var load = from c in context.CARRATES where c.CODE == val1 && c.AGENCY == val2 && c.CAT == val3 && c.OFF == val4 select new { c.START_DATE, c.END_DATE };
                    //Validity criterion
                    if (load.Count() > 0)
                    {
                        foreach (var d in load)
                        {
                            DateTime dateStart2 = (DateTime)d.START_DATE;
                            DateTime dateEnd2 = (DateTime)d.END_DATE;
                            if (!checkOverlap(time1, time2, dateStart2, dateEnd2))
                            {
                                gridView2.SetRowCellValue(e.RowHandle, "Over", true);
                                e.Valid = true;
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

        private void cARRATEBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save these changes?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                gridView2.MoveFirst();
                gridView2.MoveLast();
                CarRatesBindingSource.EndEdit();
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
            gridControl1.DataSource = from c in context.CARRATES where c.CODE == carCo select c;
        }

        private void ImageComboBoxEditCopyCode_TextChanged(object sender, System.EventArgs e)
        {
            string carCo = ImageComboBoxEditCopyCode.EditValue.ToString();
            gridControl2.DataSource = from c in context.CARRATES where c.CODE == carCo && c.CAT == "KJM" select c;
        }

        private void PurgeButton_Click(object sender, System.EventArgs e)
        {
            if (gridView1.SelectedRowsCount == 0)
            {
                MessageBox.Show("Please select at least one row before attempting to purge records.");
                return;
            }
            List<int> values = new List<int>();
            foreach (int val in gridView1.GetSelectedRows())
            {
                values.Add((int)gridView1.GetRowCellValue(val, "ID"));
            }
            foreach (int ID in values)
            {
                CARRATES rec = (from hratRec in context.CARRATES where hratRec.ID == ID select hratRec).FirstOrDefault();
                context.CARRATES.DeleteObject(rec);
                context.SaveChanges();
            }
        }

        private void gridView2_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "Over" && e.IsGetData)
            {
                CARRATES val = (CARRATES)e.Row;

                if (!string.IsNullOrWhiteSpace(val.CODE) && !string.IsNullOrWhiteSpace(val.AGENCY) && !string.IsNullOrWhiteSpace(val.CAT) && val.START_DATE != null && val.END_DATE != null && val.ID != 0)
                {
                    var load = from c in context.CARRATES where c.CODE == val.CODE && c.AGENCY == val.AGENCY && c.CAT == val.CAT  select new { c.START_DATE, c.END_DATE };
                    // 
                    foreach (var rec in load)
                    {
                        DateTime start = (DateTime)val.START_DATE;
                        DateTime end = (DateTime)val.END_DATE;
                        DateTime existStart = (DateTime)rec.START_DATE;
                        DateTime existEnd = (DateTime)rec.END_DATE;
                        if (!checkOverlap(start, end, existStart, existEnd))
                        {
                            e.Value = true;
                        }
                        else
                            e.Value = false;
                       
                    }
                    
                }
            }
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

        }

        private void SaveButton_Click(object sender, System.EventArgs e)
        {
            bool overlapFlag = false;

            for (int val = 0; val < gridView2.RowCount; val++)
            {
                ColumnView view = gridView2 as ColumnView;
                string best = gridView2.GetRowCellDisplayText(val, "Over");

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
                gridView2.MoveFirst();
                gridView2.MoveLast();
                CarRatesBindingSource.EndEdit();
                context.SaveChanges();
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
                ImageComboBoxEditLoadCode.Text = string.Empty;
                ImageComboBoxEditCopyCode.Text = string.Empty;
                gridControl2.DataSource = null;
                MessageBox.Show("Operation completed succesfully.");
                ImageComboBoxEditLoadCode.Focus();
            }

        }


    }
      
}