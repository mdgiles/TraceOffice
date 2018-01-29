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
namespace TraceForms
{
    
    public partial class insuranCopyForm : DevExpress.XtraEditors.XtraForm
    {
        public FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public insuranCopyForm(FlexCore.CoreSys _sys)
        {
            InitializeComponent();
            Connection.EFConnectionString = _sys.Settings.EFConnectionString;
            context = new FlextourEntities(_sys.Settings.EFConnectionString);
            gsLoad.gridSearchLoad(loadAgencySearch, "CODE", "NAME", "Code", "Name", "CODE", "CODE", "CODE");
            gsLoad.gridSearchLoad(copyAgencySearch, "CODE", "NAME", "Code", "Name", "CODE", "CODE", "CODE");
            gsLoad.gridSearchLoad(gridSearchControl3, "NO", "NAME", "Code", "Name", "NO", "NO", "NO");
            loadAgencySearch.GridControl.DataSource = from c in context.AGY select new { c.NO, c.NAME };
            copyAgencySearch.GridControl.DataSource = from c in context.AGY select new { c.NO, c.NAME };
            gridSearchControl3.GridControl.DataSource = from c in context.AGY select new { c.NO, c.NAME };          
            loadAgencySearch.ButtonEdit.TextChanged += ButtonEdit_TextChanged;
            copyAgencySearch.ButtonEdit.TextChanged += ButtonEdit_TextChanged1;
            gridSearchControl3.ButtonEdit.Properties.ReadOnly = true;
           
        }

        void ButtonEdit_TextChanged1(object sender, EventArgs e)
        {
            gridControl2.DataSource = from c in context.INSURAN where c.AGENCY == loadAgencySearch.Text.TrimEnd() && c.COMM_FLG == "KJM" select c;
        }
        void ButtonEdit_TextChanged(object sender, EventArgs e)
        {
            gridControl1.DataSource = from c in context.INSURAN where c.AGENCY == loadAgencySearch.Text.TrimEnd() select c;
        }

        private void gridSearchControl1_Enter(object sender, EventArgs e)
        {
            loadAgencySearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        void ButtonEdit_QueryPopUp(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
        }

        private void gridSearchControl1_ItemSelected()
        {
            loadAgencySearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        private void gridSearchControl2_Enter(object sender, EventArgs e)
        {
            copyAgencySearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        private void gridSearchControl2_ItemSelected()
        {
            copyAgencySearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        private void gridSearchControl3_Enter(object sender, EventArgs e)
        {
            gridSearchControl3.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        private void gridSearchControl3_ItemSelected()
        {
            gridSearchControl3.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        private void checkEdit1_Click(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
                simpleButton1.Text = "Preview Copy";

            if (!checkEdit1.Checked)
                simpleButton1.Text = "Preview Overwrite";
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
                gridSearchControl3.ButtonEdit.Properties.ReadOnly = false;

            if (checkEdit3.Checked)
                gridSearchControl3.ButtonEdit.Properties.ReadOnly = true; 
        }

        private void checkEdit11_Click(object sender, EventArgs e)
        {
            if (!checkEdit11.Checked)
                textEdit9.Enabled = true;

            if (checkEdit11.Checked)
                textEdit9.Enabled = false;
        }

        private void checkEdit4_Click(object sender, EventArgs e)
        {
            if (!checkEdit4.Checked)
                textEdit2.Enabled = true;

            if (checkEdit4.Checked)
                textEdit2.Enabled = false;
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

        private void checkEdit8_Click(object sender, EventArgs e)
        {
            if (!checkEdit8.Checked)
                textEdit1.Enabled = true;

            if (checkEdit8.Checked)
                textEdit1.Enabled = false;
        }

        private void checkEdit10_Click(object sender, EventArgs e)
        {
            if (!checkEdit10.Checked)
                textEdit8.Enabled = true;

            if (checkEdit10.Checked)
                textEdit8.Enabled = false;
        }

        private void checkEdit7_Click(object sender, EventArgs e)
        {
            if (!checkEdit7.Checked)
                textEdit7.Enabled = true;

            if (checkEdit7.Checked)
                textEdit7.Enabled = false;
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
                gridView2.SetFocusedRowCellValue("AGENCY", copyAgencySearch.Text);
                gridView2.SetFocusedRowCellValue("YEAR", gridView1.GetRowCellValue(val, "YEAR"));
                gridView2.SetFocusedRowCellValue("ITEM#", gridView1.GetRowCellValue(val, "ITEM#"));
                gridView2.SetFocusedRowCellValue("START_DATE", gridView1.GetRowCellValue(val, "START_DATE"));
                gridView2.SetFocusedRowCellValue("END_DATE", gridView1.GetRowCellValue(val, "END_DATE"));
                gridView2.SetFocusedRowCellValue("FROM_AMT", gridView1.GetRowCellValue(val, "FROM_AMT"));
                gridView2.SetFocusedRowCellValue("TO_AMT", gridView1.GetRowCellValue(val, "TO_AMT"));
                gridView2.SetFocusedRowCellValue("PREMIUM", gridView1.GetRowCellValue(val, "PREMIUM"));
                gridView2.SetFocusedRowCellValue("COMM_FLG", gridView1.GetRowCellValue(val, "COMM_FLG"));
                gridView2.SetFocusedRowCellValue("COMM_PCT", gridView1.GetRowCellValue(val, "COMM_PCT"));
               
                gridView2.SetFocusedRowCellValue("LAST_UPD", gridView1.GetRowCellValue(val, "LAST_UPD"));
                gridView2.SetFocusedRowCellValue("UPD_INIT", gridView1.GetRowCellValue(val, "UPD_INIT"));               

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
            if (gridSearchControl3.ButtonEdit.Properties.ReadOnly == false)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                    gridView2.SetRowCellValue(i, gridView2.Columns["AGENCY"], gridSearchControl3.Text);
            }           

            if (spinEdit1.Enabled == true)
            {
                if (gridView2.RowCount == 1)
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
                else
                {
                    for (int i = 0; i < gridView2.RowCount; i++)
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
            if (spinEdit2.Enabled == true)
            {
                if (gridView2.RowCount == 1)
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
                else
                {
                    for (int i = 0; i < gridView2.RowCount; i++)
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
           

            if (textEdit9.Enabled == true)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                    gridView2.SetRowCellValue(i, gridView2.Columns["YEAR"], textEdit9.Text);
            }
            if (textEdit2.Enabled == true)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                    gridView2.SetRowCellValue(i, gridView2.Columns["ITEM#"], textEdit8.Text);
            }
            if (textEdit7.Enabled == true)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                    gridView2.SetRowCellValue(i, gridView2.Columns["PREMIUM"], textEdit7.Text);
            }
            if (textEdit1.Enabled == true)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                    gridView2.SetRowCellValue(i, gridView2.Columns["FROM_AMT"], textEdit1.Text);
            }
            if (textEdit8.Enabled == true)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                    gridView2.SetRowCellValue(i, gridView2.Columns["TO_AMT"], textEdit1.Text);
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
                    GridColumn column1 = view.Columns["YEAR"];
                    GridColumn column2 = view.Columns["AGENCY"];
                    GridColumn column3 = view.Columns["ITEM#"];
                   
                    GridColumn column5 = view.Columns["START_DATE"];
                    GridColumn column6 = view.Columns["END_DATE"];
                  
                    //Get the value of the columns
                    short val1 = (short)view.GetRowCellValue(e.RowHandle, column1);
                    string val2 = (string)view.GetRowCellValue(e.RowHandle, column2);
                    short val3 = (short)view.GetRowCellValue(e.RowHandle, column3);
                   
                    DateTime time1 = (DateTime)view.GetRowCellValue(e.RowHandle, column5);
                    DateTime time2 = (DateTime)view.GetRowCellValue(e.RowHandle, column6);
                   

                    var load = from c in context.INSURAN where c.YEAR == val1 && c.AGENCY == val2 && c.ITEM_ == val3 select new { c.START_DATE, c.END_DATE };
                    //Validity criterion

                    if (load.Count() > 0)
                    {
                        foreach (var d in load)
                        {
                            DateTime dateStart2 = (DateTime)d.START_DATE;
                            DateTime dateEnd2 = (DateTime)d.END_DATE;
                            if (!checkOverlap(time1, time2, dateStart2, dateEnd2))
                            {
                               
                                    e.Valid = false;
                                    view.SetColumnError(column1, "You are trying to enter an overlapping Hotel Rate.");
                               
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
                InsuranBindingSource.EndEdit();
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

        private void PurgeButton_Click(object sender, EventArgs e)
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
                INSURAN rec = (from hratRec in context.INSURAN where hratRec.ID == ID select hratRec).FirstOrDefault();
                context.INSURAN.DeleteObject(rec);
                context.SaveChanges();
            }
        }
        
    }
}