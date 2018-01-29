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
     
    public partial class busTblCopyForm : DevExpress.XtraEditors.XtraForm
    {
        public FlextourEntities context;
        public string username;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public busTblCopyForm(FlexInterfaces.Core.ICoreSys sys)
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
            var air = from airRec in context.AIR orderby airRec.CODE ascending select new { airRec.CODE, airRec.NAME };
            var cat = from catRec in context.ROOMCOD orderby catRec.CODE ascending select new { catRec.CODE, catRec.DESC };
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxEditLoadCode.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCopyCode.Properties.Items.Add(loadBlank);
            ImageComboBoxEditLocation.Properties.Items.Add(loadBlank);
       
            foreach (var result in air)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditLoadCode.Properties.Items.Add(load);
                ImageComboBoxEditCopyCode.Properties.Items.Add(load);
            }
          

            foreach (var result in cat)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.DESC.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditLocation.Properties.Items.Add(load);
            }
            ImageComboBoxEditCopyCode.Properties.ReadOnly = true;
            ImageComboBoxEditLocation.Properties.ReadOnly = true;

            //locationSearch.GridControl.DataSource = from c in context.CITYCOD select new { c.CODE, c.NAME };
            //loadCodeSearch.ButtonEdit.TextChanged += ButtonEdit_TextChanged;
            //copyCodeSearch.ButtonEdit.TextChanged += ButtonEdit_TextChanged1;
            //locationSearch.ButtonEdit.Properties.ReadOnly = true;
        }


        void ButtonEdit_TextChanged1(object sender, EventArgs e)
        {

        }
        void ButtonEdit_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit5_TextChanged(object sender, EventArgs e)
        {
            //if (comboBoxEdit5.Text == "OPT")           
            //{
            //    //options 
            //    loadCodeSearch.GridControl.DataSource = from c in context.COMP select new { c.CODE, c.NAME };
            //    copyCodeSearch.GridControl.DataSource = from c in context.COMP select new { c.CODE, c.NAME };
            //}
            //if (comboBoxEdit5.Text == "PKG")
            //{
            //    //Pkg codes
            //    loadCodeSearch.GridControl.DataSource = from c in context.PACK select new { c.CODE, c.NAME };
            //    copyCodeSearch.GridControl.DataSource = from c in context.PACK select new { c.CODE, c.NAME };
            //}
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
                simpleButton1.Text = "Copy";

            if (!checkEdit1.Checked)
                simpleButton1.Text = "Overwrite";
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
                //gridView2.AddNewRow();
                //gridView2.SetFocusedRowCellValue("CODE", copyCodeSearch.Text);
                //gridView2.SetFocusedRowCellValue("TYPE", gridView1.GetRowCellValue(val, "TYPE"));
                gridView2.SetFocusedRowCellValue("PUP_DRP", gridView1.GetRowCellValue(val, "PUP_DRP"));
                gridView2.SetFocusedRowCellValue("DATE", gridView1.GetRowCellValue(val, "DATE"));
                gridView2.SetFocusedRowCellValue("LOCATION", gridView1.GetRowCellValue(val, "LOCATION"));
                gridView2.SetFocusedRowCellValue("TIME", gridView1.GetRowCellValue(val, "TIME"));
                gridView2.SetFocusedRowCellValue("IN_OUT", gridView1.GetRowCellValue(val, "IN_OUT"));
                gridView2.SetFocusedRowCellValue("EndDate", gridView1.GetRowCellValue(val, "EndDate"));
                gridView2.SetFocusedRowCellValue("LocationType", gridView1.GetRowCellValue(val, "LocationType"));

                gridView2.SetFocusedRowCellValue("CarOffice", gridView1.GetRowCellValue(val, "CarOffice"));
                gridView2.SetFocusedRowCellValue("EndTime", gridView1.GetRowCellValue(val, "EndTime"));
                gridView2.SetFocusedRowCellValue("Exclusion", gridView1.GetRowCellValue(val, "Exclusion"));

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
                comboBoxEdit6.Properties.ReadOnly = false;

            if (checkEdit3.Checked)
                comboBoxEdit6.Properties.ReadOnly = true;  
        }

        private void checkEdit4_Click(object sender, EventArgs e)
        {
            //if (!checkEdit4.Checked)
            //    locationSearch.ButtonEdit.Properties.ReadOnly = false;

            //if (checkEdit4.Checked)
            //    locationSearch.ButtonEdit.Properties.ReadOnly = true;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //gridView2.MoveFirst();
            //gridView2.Focus();
            //if (locationSearch.ButtonEdit.Properties.ReadOnly == false)
            //{
            //    for (int i = 0; i < gridView2.RowCount; i++)
            //        gridView2.SetRowCellValue(i, gridView2.Columns["LOCATION"], locationSearch.Text);
            //}

           

            if (comboBoxEdit6.Enabled == true)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                    gridView2.SetRowCellValue(i, gridView2.Columns["LocationType"], comboBoxEdit6.Text);
            }
           
        }

        private void comboBoxEdit6_TextChanged(object sender, EventArgs e)
        {
            //if (comboBoxEdit6.Text == "HTL")
            //    locationSearch.GridControl.DataSource = from c in context.HOTEL select new { c.CODE, c.NAME };
        }

        private void aIRSEGBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save these changes?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                gridView2.MoveFirst();
                gridView2.MoveLast();
                BusTableBindingSource.EndEdit();
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

        private void gridView2_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            using (Session session1 = new Session())
            {

                session1.BeginTransaction();
                try
                {

                    //ColumnView view = sender as ColumnView;
                    //GridColumn column1 = view.Columns["CODE"];
                    //GridColumn column2 = view.Columns["AGENCY"];
                    //GridColumn column3 = view.Columns["CAT"];
                    //GridColumn column4 = view.Columns["SEG"];
                    //GridColumn column5 = view.Columns["START_DATE"];
                    //GridColumn column6 = view.Columns["END_DATE"];
                    ////Get the value of the columns
                    //string val1 = (string)view.GetRowCellValue(e.RowHandle, column1);
                    //string val2 = (string)view.GetRowCellValue(e.RowHandle, column2);
                    //string val3 = (string)view.GetRowCellValue(e.RowHandle, column3);
                    //string val4 = (string)view.GetRowCellValue(e.RowHandle, column4);
                    //DateTime time1 = (DateTime)view.GetRowCellValue(e.RowHandle, column5);
                    //DateTime time2 = (DateTime)view.GetRowCellValue(e.RowHandle, column6);

                    //var load = from c in context.AIRSEG where c.CODE == val1 && c.AGENCY == val2 && c.CAT == val3 && c.SEG == val4 select new { c.START_DATE, c.END_DATE };
                    ////Validity criterion
                    //if (load.Count() > 0)
                    //{
                    //    foreach (var d in load)
                    //    {
                    //        DateTime dateStart2 = (DateTime)d.START_DATE;
                    //        DateTime dateEnd2 = (DateTime)d.END_DATE;
                    //        if (!checkOverlap(time1, time2, dateStart2, dateEnd2))
                    //        {
                    //            e.Valid = false;
                    //            view.SetColumnError(column1, "You are trying to enter an overlapping Hotel Rate.");
                    //        }
                    //    }
                    //}
                    //session1.CommitTransaction();
                }
                catch { session1.RollbackTransaction(); }
            }
        }

        private void gridView2_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
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
                BUSTABLE rec = (from hratRec in context.BUSTABLE where hratRec.ID == ID select hratRec).FirstOrDefault();
                context.BUSTABLE.DeleteObject(rec);
                context.SaveChanges();
            }
        }




    

    }
}