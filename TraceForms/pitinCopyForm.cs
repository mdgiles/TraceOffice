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
    
    public partial class pitinCopyForm : DevExpress.XtraEditors.XtraForm
    {
        public FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public pitinCopyForm(FlexInterfaces.Core.ICoreSys sys)
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
            var pack = from airRec in context.PACK orderby airRec.CODE ascending select new { airRec.CODE, airRec.NAME };
            var cat = from catRec in context.ROOMCOD orderby catRec.CODE ascending select new { catRec.CODE, catRec.DESC };
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxEditLoadCode.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCopyCode.Properties.Items.Add(loadBlank);           
            ImageComboBoxEditCategory.Properties.Items.Add(loadBlank);
            foreach (var result in pack)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditLoadCode.Properties.Items.Add(load);
                ImageComboBoxEditCopyCode.Properties.Items.Add(load);
            }
            
            foreach (var result in cat)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.DESC.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCategory.Properties.Items.Add(load);
            }
            ImageComboBoxEditCategory.Properties.ReadOnly = true;
          
        }

      
        private void checkEdit2_Click(object sender, EventArgs e)
        {
            if (!checkEdit2.Checked)
                gridView1.SelectAll();
            if (checkEdit2.Checked)
                gridView1.ClearSelection();
        }

        private void checkEdit1_Click(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
                simpleButton1.Text = "Preview Copy";

            if (!checkEdit1.Checked)
                simpleButton1.Text = "Preview Overwrite";
        }

        private void checkEdit4_Click(object sender, EventArgs e)
        {
            if (!checkEdit4.Checked)
                ImageComboBoxEditCategory.Properties.ReadOnly = false;

            if (checkEdit4.Checked)
                ImageComboBoxEditCategory.Properties.ReadOnly = true;
        }

        private void checkEdit11_Click(object sender, EventArgs e)
        {
            if (!checkEdit11.Checked)
                textEdit9.Enabled = true;

            if (checkEdit11.Checked)
                textEdit9.Enabled = false;
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
                gridView2.SetFocusedRowCellValue("STATUS", gridView1.GetRowCellValue(val, "STATUS"));
                gridView2.SetFocusedRowCellValue("CAT", gridView1.GetRowCellValue(val, "CAT"));
                gridView2.SetFocusedRowCellValue("DATE", gridView1.GetRowCellValue(val, "DATE"));
                gridView2.SetFocusedRowCellValue("LAST_UPD", gridView1.GetRowCellValue(val, "LAST_UPD"));
                gridView2.SetFocusedRowCellValue("UPD_BY", gridView1.GetRowCellValue(val, "UPD_BY"));
              
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


            if (ImageComboBoxEditCategory.Properties.ReadOnly == false)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                    gridView2.SetRowCellValue(i, gridView2.Columns["CAT"], ImageComboBoxEditCategory.EditValue);
            }

            if (spinEdit1.Enabled == true)
            {
                if (gridView2.RowCount == 1)
                {
                    DateTime time = (DateTime)gridView2.GetFocusedRowCellValue("DATE");
                    int val = (int)spinEdit1.Value;
                    if (comboBoxEdit1.Text == "-      Subtract")
                        val *= -1;

                    if (comboBoxEdit2.Text == "Days")
                        gridView2.SetFocusedRowCellValue("DATE", time.AddDays(val));

                    if (comboBoxEdit2.Text == "Months")
                        gridView2.SetFocusedRowCellValue("DATE", time.AddMonths(val));

                    if (comboBoxEdit2.Text == "Years")
                        gridView2.SetFocusedRowCellValue("DATE", time.AddYears(val));
                }
                else
                {
                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        DateTime time = (DateTime)gridView2.GetRowCellValue(i, "DATE");
                        int val = (int)spinEdit1.Value;
                        if (comboBoxEdit1.Text == "-      Subtract")
                            val *= -1;

                        if (comboBoxEdit2.Text == "Days")
                            gridView2.SetRowCellValue(i, gridView2.Columns["DATE"], time.AddDays(val));

                        if (comboBoxEdit2.Text == "Months")
                            gridView2.SetRowCellValue(i, gridView2.Columns["DATE"], time.AddMonths(val));

                        if (comboBoxEdit2.Text == "Years")
                            gridView2.SetRowCellValue(i, gridView2.Columns["DATE"], time.AddYears(val));
                    }
                }
            }
          

            if (textEdit9.Enabled == true)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                    gridView2.SetRowCellValue(i, gridView2.Columns["STATUS"], textEdit9.Text);
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
                    GridColumn column2 = view.Columns["CAT"];
                    GridColumn column3 = view.Columns["STATUS"];
                    GridColumn column4 = view.Columns["DATE"];                    
                   
                    //Get the value of the columns
                    string val1 = (string)view.GetRowCellValue(e.RowHandle, column1);
                    string val2 = (string)view.GetRowCellValue(e.RowHandle, column2);
                    string val3 = (string)view.GetRowCellValue(e.RowHandle, column3);                   
                    DateTime time1 = (DateTime)view.GetRowCellValue(e.RowHandle, column4);
                    
                    var load = from c in context.PITIN where c.CODE == val1 && c.CAT == val2 && c.STATUS == val3 select new { c.DATE };
                    //Validity criterion

                    if (load.Count() > 0)
                    {
                        foreach (var d in load)
                        {
                            DateTime dateStart2 = (DateTime)d.DATE;
                            if (time1 == dateStart2)
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

        private void cPRATEBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save these changes?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                gridView2.MoveFirst();
                gridView2.MoveLast();
                PitinBindingSource.EndEdit();
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
            gridControl1.DataSource = from c in context.PITIN where c.CODE == carCo select c;
        }

        private void ImageComboBoxEditCopyCode_TextChanged(object sender, System.EventArgs e)
        {
            string carCo = ImageComboBoxEditCopyCode.EditValue.ToString();
            gridControl2.DataSource = from c in context.PITIN where c.CODE == carCo && c.CAT == "KJM" select c;
        }

        private void PurgeButton_Click(object sender, System.EventArgs e)
        {
            //if (gridView1.SelectedRowsCount == 0)
            //{
            //    MessageBox.Show("Please select at least one row before attempting to purge records.");
            //    return;
            //}
            //List<int> values = new List<int>();
            //foreach (int val in gridView1.GetSelectedRows())
            //{
            //    values.Add((int)gridView1.GetRowCellValue(val, "ID"));
            //}
            //foreach (int ID in values)
            //{
            //    PITIN rec = (from hratRec in context.PITIN where hratRec.ID == ID select hratRec).FirstOrDefault();
            //    context.PITIN.DeleteObject(rec);
            //    context.SaveChanges();
            //}
        }
    }
}