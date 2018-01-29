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

using System.Runtime.InteropServices;
namespace TraceForms
{
    
    public partial class CxlFeeCopyForm : DevExpress.XtraEditors.XtraForm
    {
        public FlextourEntities context;
        public string username;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public ImageComboBoxItemCollection opts;
        public ImageComboBoxItemCollection htls;
        public CxlFeeCopyForm(FlexInterfaces.Core.ICoreSys sys)
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
            opts = new ImageComboBoxItemCollection(ImageComboBoxEditLoadCode.Properties);
            htls = new ImageComboBoxItemCollection(ImageComboBoxEditLoadCode.Properties);
            var agy = from agyRec in context.AGY orderby agyRec.NO ascending select new { agyRec.NO, agyRec.NAME };
            var crus = from airRec in context.CRU orderby airRec.CODE ascending select new { airRec.CODE, airRec.NAME };
            var cat = from catRec in context.ROOMCOD orderby catRec.CODE ascending select new { catRec.CODE, catRec.DESC };
            var comps = from compRec in context.COMP orderby compRec.CODE ascending select new { compRec.CODE, compRec.NAME };
            var hotels = from hotRec in context.HOTEL orderby hotRec.CODE ascending select new { hotRec.CODE, hotRec.NAME }; 

            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxEditLoadCode.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCopyCode.Properties.Items.Add(loadBlank);
            ImageComboBoxEditAgency.Properties.Items.Add(loadBlank);
			ImageComboBoxEditCategory.Properties.Items.Add(loadBlank);
          
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
            ImageComboBoxEditCategory.Properties.ReadOnly = true;           
            ImageComboBoxEditAgency.Properties.ReadOnly = true;
        }

      

        private void comboBoxEdit7_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxEdit7.Text == "OPT")
            {               
                //options 
                ImageComboBoxEditLoadCode.Properties.Items.AddRange(opts);
                ImageComboBoxEditCopyCode.Properties.Items.AddRange(opts);
            }
            if (comboBoxEdit7.Text == "HTL")
            {
                //Pkg codes
                ImageComboBoxEditLoadCode.Properties.Items.AddRange(htls);
                ImageComboBoxEditCopyCode.Properties.Items.AddRange(htls);
            }
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

        private void checkEdit1_Click(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
                copyButton.Text = "Copy";

            if (!checkEdit1.Checked)
                copyButton.Text = "Overwrite";
        }

        private void copyButton_Click(object sender, EventArgs e)
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
                gridView2.SetFocusedRowCellValue("TYPE", gridView1.GetRowCellValue(val, "TYPE"));
                gridView2.SetFocusedRowCellValue("AGENCY", gridView1.GetRowCellValue(val, "AGENCY"));
                gridView2.SetFocusedRowCellValue("START_DATE", gridView1.GetRowCellValue(val, "START_DATE"));
                gridView2.SetFocusedRowCellValue("END_DATE", gridView1.GetRowCellValue(val, "END_DATE"));
                gridView2.SetFocusedRowCellValue("CXL_DATE", gridView1.GetRowCellValue(val, "CXL_DATE"));
                gridView2.SetFocusedRowCellValue("NTS_PRIOR", gridView1.GetRowCellValue(val, "NTS_PRIOR"));
                gridView2.SetFocusedRowCellValue("CAT", gridView1.GetRowCellValue(val, "CAT"));
                gridView2.SetFocusedRowCellValue("NBR_NTS", gridView1.GetRowCellValue(val, "NBR_NTS"));

                gridView2.SetFocusedRowCellValue("PCT_AMT", gridView1.GetRowCellValue(val, "PCT_AMT"));
                gridView2.SetFocusedRowCellValue("FLAT_FEE", gridView1.GetRowCellValue(val, "FLAT_FEE"));              

                gridView2.SetFocusedRowCellValue("LAST_UPD", DateTime.Today);
                gridView2.SetFocusedRowCellValue("UPD_INIT", username);

            }
            if (checkEdit1.Checked)
            {
                if (MessageBox.Show("Are you sure you want to delete the original records?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    gridView1.DeleteSelectedRows();
                    context.SaveChanges();
                }
            }
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

        private void checkEdit12_Click(object sender, EventArgs e)
        {
            if (!checkEdit12.Checked)
                textEdit1.Enabled = true;

            if (checkEdit12.Checked)
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

        private void checkEdit7_Click(object sender, EventArgs e)
        {
            if (!checkEdit7.Checked)
            {
                spinEdit3.Enabled = true;
                comboBoxEdit5.Enabled = true;
                comboBoxEdit6.Enabled = true;
            }

            if (checkEdit7.Checked)
            {
                spinEdit3.Enabled = false;
                comboBoxEdit5.Enabled = false;
                comboBoxEdit6.Enabled = false;
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
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
            if (spinEdit3.Enabled == true)
            {
                if (gridView2.RowCount == 1)
                {
                    DateTime time = (DateTime)gridView2.GetFocusedRowCellValue("CXL_DATE");
                    int val = (int)spinEdit3.Value;
                    if (comboBoxEdit6.Text == "-      Subtract")
                        val *= -1;

                    if (comboBoxEdit5.Text == "Days")
                        gridView2.SetFocusedRowCellValue("CXL_DATE", time.AddDays(val));

                    if (comboBoxEdit5.Text == "Months")
                        gridView2.SetFocusedRowCellValue("CXL_DATE", time.AddMonths(val));

                    if (comboBoxEdit5.Text == "Years")
                        gridView2.SetFocusedRowCellValue("CXL_DATE", time.AddYears(val));
                }
                else
                {
                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        DateTime time = (DateTime)gridView2.GetRowCellValue(i, "CXL_DATE");
                        int val = (int)spinEdit3.Value;
                        if (comboBoxEdit6.Text == "-      Subtract")
                            val *= -1;

                        if (comboBoxEdit5.Text == "Days")
                            gridView2.SetRowCellValue(i, gridView2.Columns["CXL_DATE"], time.AddDays(val));

                        if (comboBoxEdit5.Text == "Months")
                            gridView2.SetRowCellValue(i, gridView2.Columns["CXL_DATE"], time.AddMonths(val));

                        if (comboBoxEdit5.Text == "Years")
                            gridView2.SetRowCellValue(i, gridView2.Columns["CXL_DATE"], time.AddYears(val));
                    }
                }


            }
            if (textEdit1.Enabled == true)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                    gridView2.SetRowCellValue(i, gridView2.Columns["NTS_PRIOR"], textEdit1.Text);
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
            //using (Session session1 = new Session())
            //{

            //    session1.BeginTransaction();
            //    try
            //    {

            //        ColumnView view = sender as ColumnView;
            //        GridColumn column1 = view.Columns["CODE"];
            //        GridColumn column2 = view.Columns["AGENCY"];
            //        GridColumn column3 = view.Columns["CAT"];
            //        GridColumn column4 = view.Columns["Time"];
            //        GridColumn column5 = view.Columns["START_DATE"];
            //        GridColumn column6 = view.Columns["END_DATE"];
            //        GridColumn column7 = view.Columns["ResDate_Start"];
            //        GridColumn column8 = view.Columns["ResDate_End"];
            //        //Get the value of the columns
            //        string val1 = (string)view.GetRowCellValue(e.RowHandle, column1);
            //        string val2 = (string)view.GetRowCellValue(e.RowHandle, column2);
            //        string val3 = (string)view.GetRowCellValue(e.RowHandle, column3);
            //        string val4 = (string)view.GetRowCellValue(e.RowHandle, column4);
            //        DateTime time1 = (DateTime)view.GetRowCellValue(e.RowHandle, column5);
            //        DateTime time2 = (DateTime)view.GetRowCellValue(e.RowHandle, column6);
            //        DateTime time3 = new DateTime();
            //        DateTime time4 = new DateTime();
            //        if ((string)view.GetRowCellValue(e.RowHandle, column7) != null)
            //            time3 = (DateTime)view.GetRowCellValue(e.RowHandle, column7);
            //        if ((string)view.GetRowCellValue(e.RowHandle, column8) != null)
            //            time4 = (DateTime)view.GetRowCellValue(e.RowHandle, column8);

            //        var load = from c in context.CPRATES where c.CODE == val1 && c.AGENCY == val2 && c.CAT == val3 select new { c.START_DATE, c.END_DATE, c.ResDate_Start, c.ResDate_End };
            //        //Validity criterion

            //        if (load.Count() > 0)
            //        {
            //            foreach (var d in load)
            //            {
            //                DateTime dateStart2 = (DateTime)d.START_DATE;
            //                DateTime dateEnd2 = (DateTime)d.END_DATE;
            //                if (!checkOverlap(time1, time2, dateStart2, dateEnd2))
            //                {
            //                    DateTime time5 = new DateTime();
            //                    DateTime time6 = new DateTime();

            //                    if (d.ResDate_Start != null)
            //                        time5 = (DateTime)d.ResDate_Start;
            //                    if (d.ResDate_Start != null)
            //                        time6 = (DateTime)d.ResDate_End;

            //                    if (!checkOverlap(time3, time4, time5, time6))
            //                    {
            //                        e.Valid = false;
            //                        view.SetColumnError(column1, "You are trying to enter an overlapping Hotel Rate.");
            //                    }
            //                }
            //            }
            //        }
            //        session1.CommitTransaction();
            //    }
            //    catch { session1.RollbackTransaction(); }
            //}
        }

        private void gridView2_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction; 
        }

        private void cPRATEBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save these changes?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                gridView2.MoveFirst();
                gridView2.MoveLast();
                CxlFeeBindingSource.EndEdit();
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
            gridControl1.DataSource = from c in context.CXLFEE where c.CODE == carCo select c;
        }

        private void ImageComboBoxEditCopyCode_TextChanged(object sender, System.EventArgs e)
        {
            string carCo = ImageComboBoxEditCopyCode.EditValue.ToString();
            gridControl2.DataSource = from c in context.CXLFEE where c.CODE == carCo && c.CAT == "KJM" select c;
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
                CXLFEE rec = (from hratRec in context.CXLFEE where hratRec.ID == ID select hratRec).FirstOrDefault();
                context.CXLFEE.DeleteObject(rec);
                context.SaveChanges();
            }
        }
    }
}