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
    
    public partial class cruRateCopyForm : DevExpress.XtraEditors.XtraForm
    {        
        public FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public cruRateCopyForm(FlexInterfaces.Core.ICoreSys sys)
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
            var crus = from airRec in context.CRU orderby airRec.CODE ascending select new { airRec.CODE, airRec.NAME };
            var cat = from catRec in context.ROOMCOD orderby catRec.CODE ascending select new { catRec.CODE, catRec.DESC };
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxEditLoadCode.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCopyCode.Properties.Items.Add(loadBlank);
            ImageComboBoxEditAgency.Properties.Items.Add(loadBlank);          
            foreach (var result in crus)
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
            ImageComboBoxEditAgency.Properties.ReadOnly = true;
        }

        void ButtonEdit_QueryPopUp(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
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
                ImageComboBoxEditAgency.Properties.ReadOnly = false;

            if (checkEdit3.Checked)
                ImageComboBoxEditAgency.Properties.ReadOnly = true;  
        }

        private void checkEdit4_Click(object sender, EventArgs e)
        {
            //tx2
            if (!checkEdit4.Checked)
                textEdit2.Enabled = true;

            if (checkEdit4.Checked)
                textEdit2.Enabled = false;
        }

        private void checkEdit9_Click(object sender, EventArgs e)
        {
            //tx1
            if (!checkEdit9.Checked)
                textEdit1.Enabled = true;

            if (checkEdit9.Checked)
                textEdit1.Enabled = false;
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
            //txt9
            if (!checkEdit11.Checked)
                textEdit9.Enabled = true;

            if (checkEdit11.Checked)
                textEdit9.Enabled = false;
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
                gridView2.SetFocusedRowCellValue("CODE", ImageComboBoxEditCopyCode.EditValue);
                gridView2.SetFocusedRowCellValue("AGENCY", gridView1.GetRowCellValue(val, "AGENCY"));
                gridView2.SetFocusedRowCellValue("ITIN", gridView1.GetRowCellValue(val, "ITIN"));
                gridView2.SetFocusedRowCellValue("START_DATE", gridView1.GetRowCellValue(val, "START_DATE"));
                gridView2.SetFocusedRowCellValue("END_DATE", gridView1.GetRowCellValue(val, "END_DATE"));
                gridView2.SetFocusedRowCellValue("YEAR", gridView1.GetRowCellValue(val, "YEAR"));
                gridView2.SetFocusedRowCellValue("H_L", gridView1.GetRowCellValue(val, "H_L"));
                gridView2.SetFocusedRowCellValue("LAST_UPD", gridView1.GetRowCellValue(val, "LAST_UPD"));
                gridView2.SetFocusedRowCellValue("UPD_INIT", gridView1.GetRowCellValue(val, "UPD_INIT"));
                gridView2.SetFocusedRowCellValue("TP1", gridView1.GetRowCellValue(val, "TP1"));
                gridView2.SetFocusedRowCellValue("TP2", gridView1.GetRowCellValue(val, "TP2"));
                gridView2.SetFocusedRowCellValue("TP3", gridView1.GetRowCellValue(val, "TP3"));
                gridView2.SetFocusedRowCellValue("TP4", gridView1.GetRowCellValue(val, "TP4"));
                gridView2.SetFocusedRowCellValue("TP5", gridView1.GetRowCellValue(val, "TP5"));
                gridView2.SetFocusedRowCellValue("TP6", gridView1.GetRowCellValue(val, "TP6"));
                gridView2.SetFocusedRowCellValue("TP7", gridView1.GetRowCellValue(val, "TP7"));
                gridView2.SetFocusedRowCellValue("TP8", gridView1.GetRowCellValue(val, "TP8"));
                gridView2.SetFocusedRowCellValue("TP9", gridView1.GetRowCellValue(val, "TP9"));
                gridView2.SetFocusedRowCellValue("TP10", gridView1.GetRowCellValue(val, "TP10"));
                gridView2.SetFocusedRowCellValue("TP11", gridView1.GetRowCellValue(val, "TP11"));
                gridView2.SetFocusedRowCellValue("TP12", gridView1.GetRowCellValue(val, "TP12"));
                gridView2.SetFocusedRowCellValue("DESC1", gridView1.GetRowCellValue(val, "DESC1"));
                gridView2.SetFocusedRowCellValue("DESC2", gridView1.GetRowCellValue(val, "DESC2"));
                gridView2.SetFocusedRowCellValue("DESC3", gridView1.GetRowCellValue(val, "DESC3"));
                gridView2.SetFocusedRowCellValue("DESC4", gridView1.GetRowCellValue(val, "DESC4"));
                gridView2.SetFocusedRowCellValue("DESC5", gridView1.GetRowCellValue(val, "DESC5"));
                gridView2.SetFocusedRowCellValue("DESC6", gridView1.GetRowCellValue(val, "DESC6"));
                gridView2.SetFocusedRowCellValue("DESC7", gridView1.GetRowCellValue(val, "DESC7"));
                gridView2.SetFocusedRowCellValue("DESC8", gridView1.GetRowCellValue(val, "DESC8"));
                gridView2.SetFocusedRowCellValue("DESC9", gridView1.GetRowCellValue(val, "DESC9"));
                gridView2.SetFocusedRowCellValue("DESC10", gridView1.GetRowCellValue(val, "DESC10"));
                gridView2.SetFocusedRowCellValue("DESC11", gridView1.GetRowCellValue(val, "DESC11"));
                gridView2.SetFocusedRowCellValue("DESC12", gridView1.GetRowCellValue(val, "DESC12"));
                gridView2.SetFocusedRowCellValue("GRATE1", gridView1.GetRowCellValue(val, "GRATE1"));
                gridView2.SetFocusedRowCellValue("GRATE2", gridView1.GetRowCellValue(val, "GRATE2"));
                gridView2.SetFocusedRowCellValue("GRATE3", gridView1.GetRowCellValue(val, "GRATE3"));
                gridView2.SetFocusedRowCellValue("GRATE4", gridView1.GetRowCellValue(val, "GRATE4"));
                gridView2.SetFocusedRowCellValue("GRATE5", gridView1.GetRowCellValue(val, "GRATE5"));
                gridView2.SetFocusedRowCellValue("GRATE6", gridView1.GetRowCellValue(val, "GRATE6"));
                gridView2.SetFocusedRowCellValue("GRATE7", gridView1.GetRowCellValue(val, "GRATE7"));
                gridView2.SetFocusedRowCellValue("GRATE8", gridView1.GetRowCellValue(val, "GRATE8"));
                gridView2.SetFocusedRowCellValue("GRATE9", gridView1.GetRowCellValue(val, "GRATE9"));
                gridView2.SetFocusedRowCellValue("GRATE10", gridView1.GetRowCellValue(val, "GRATE10"));
                gridView2.SetFocusedRowCellValue("GRATE11", gridView1.GetRowCellValue(val, "GRATE11"));
                gridView2.SetFocusedRowCellValue("GRATE12", gridView1.GetRowCellValue(val, "GRATE12"));
                gridView2.SetFocusedRowCellValue("NRATE1", gridView1.GetRowCellValue(val, "NRATE1"));
                gridView2.SetFocusedRowCellValue("NRATE2", gridView1.GetRowCellValue(val, "NRATE2"));
                gridView2.SetFocusedRowCellValue("NRATE3", gridView1.GetRowCellValue(val, "NRATE3"));
                gridView2.SetFocusedRowCellValue("NRATE4", gridView1.GetRowCellValue(val, "NRATE4"));
                gridView2.SetFocusedRowCellValue("NRATE5", gridView1.GetRowCellValue(val, "NRATE5"));
                gridView2.SetFocusedRowCellValue("NRATE6", gridView1.GetRowCellValue(val, "NRATE6"));
                gridView2.SetFocusedRowCellValue("NRATE7", gridView1.GetRowCellValue(val, "NRATE7"));
                gridView2.SetFocusedRowCellValue("NRATE8", gridView1.GetRowCellValue(val, "NRATE8"));
                gridView2.SetFocusedRowCellValue("NRATE9", gridView1.GetRowCellValue(val, "NRATE9"));
                gridView2.SetFocusedRowCellValue("NRATE10", gridView1.GetRowCellValue(val, "NRATE10"));
                gridView2.SetFocusedRowCellValue("NRA TE11", gridView1.GetRowCellValue(val, "NRATE11"));
                gridView2.SetFocusedRowCellValue("NRATE12", gridView1.GetRowCellValue(val, "NRATE12"));
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

            if (textEdit1.Enabled == true)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                    gridView2.SetRowCellValue(i, gridView2.Columns["H_L"], textEdit1.Text);
            }

            if (textEdit2.Enabled == true)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                    gridView2.SetRowCellValue(i, gridView2.Columns["ITIN"], textEdit2.Text);
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

            ColumnView view = sender as ColumnView;
            GridColumn column1 = view.Columns["CODE"];
            GridColumn column2 = view.Columns["AGENCY"];
            GridColumn column3 = view.Columns["ITIN"];
            GridColumn column5 = view.Columns["START_DATE"];
            GridColumn column6 = view.Columns["END_DATE"];

            //Get the value of the columns
            string val1 = (string)view.GetRowCellValue(e.RowHandle, column1);
            string val2 = (string)view.GetRowCellValue(e.RowHandle, column2);
            string val3 = (string)view.GetRowCellValue(e.RowHandle, column3);

            DateTime time1 = (DateTime)view.GetRowCellValue(e.RowHandle, column5);
            DateTime time2 = (DateTime)view.GetRowCellValue(e.RowHandle, column6);


            var load = from c in context.CRATES where c.CODE == val1 && c.AGENCY == val2 && c.ITIN == val3 select new { c.START_DATE, c.END_DATE };
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
                CRatesBindingSource.EndEdit();
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
            string cruCo = ImageComboBoxEditLoadCode.EditValue.ToString();
            gridControl1.DataSource = from c in context.CPRATES where c.CODE == cruCo select c;
        }

        private void ImageComboBoxEditCopyCode_TextChanged(object sender, System.EventArgs e)
        {
            string cruCo = ImageComboBoxEditCopyCode.EditValue.ToString();
            gridControl2.DataSource = from c in context.CRATES where c.CODE == cruCo && c.AGENCY == "KJM" select c;
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
                CRATES rec = (from hratRec in context.CRATES where hratRec.ID == ID select hratRec).FirstOrDefault();
                context.CRATES.DeleteObject(rec);
                context.SaveChanges();
            }
        }
      
    }
}