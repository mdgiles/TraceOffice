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
    
    public partial class pcompCopyForm : DevExpress.XtraEditors.XtraForm
    {
        public FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public pcompCopyForm(FlexInterfaces.Core.ICoreSys sys)
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
            var meals = from mealRec in context.MEALCOD orderby mealRec.CODE ascending select new { mealRec.CODE, mealRec.DESC };
            var comp = from airRec in context.COMP orderby airRec.CODE ascending select new { airRec.CODE, airRec.NAME };
            var cat = from catRec in context.ROOMCOD orderby catRec.CODE ascending select new { catRec.CODE, catRec.DESC };

            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxEditLoadCode.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCopyCode.Properties.Items.Add(loadBlank);
            ImageComboBoxEditMealcod.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCategory.Properties.Items.Add(loadBlank);
            foreach (var result in comp)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditLoadCode.Properties.Items.Add(load);
                ImageComboBoxEditCopyCode.Properties.Items.Add(load);
            }
            foreach (var result in meals)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.DESC.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditMealcod.Properties.Items.Add(load);
            }

            foreach (var result in cat)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.DESC.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCategory.Properties.Items.Add(load);
            }
            ImageComboBoxEditCategory.Properties.ReadOnly = true;
            ImageComboBoxEditMealcod.Properties.ReadOnly = true;
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
                string pkgLoad = ImageComboBoxEditLoadCode.EditValue.ToString();
                string cat = (gridView1.GetRowCellValue(val, "CAT")).ToString();
                var values = from c in context.PCOMP where c.CODE == pkgLoad && c.CAT == cat select c;
                foreach (var load in values)
                {
                    gridView2.AddNewRow();
                    gridView2.SetFocusedRowCellValue("CODE", ImageComboBoxEditCopyCode.Text);                    
                    gridView2.SetFocusedRowCellValue("CAT", load.CAT);
                    gridView2.SetFocusedRowCellValue("DAY",load.DAY);
                    gridView2.SetFocusedRowCellValue("LINE", load.LINE);
                    gridView2.SetFocusedRowCellValue("LAST_UPD", load.LAST_UPD);
                    gridView2.SetFocusedRowCellValue("UPD_INIT", load.UPD_INIT);
                    gridView2.SetFocusedRowCellValue("TYPE", load.TYPE);
                    gridView2.SetFocusedRowCellValue("CODE1", load.CODE1);
                    gridView2.SetFocusedRowCellValue("CAT1", load.CAT1);                    
                    gridView2.SetFocusedRowCellValue("ROOM", load.ROOM);
                    gridView2.SetFocusedRowCellValue("TOUR_TIME", load.TOUR_TIME);                    
                    gridView2.SetFocusedRowCellValue("INV_UPD", load.INV_UPD);
                    gridView2.SetFocusedRowCellValue("NTS",load.NTS);
                    gridView2.SetFocusedRowCellValue("CHK_OUT", load.CHK_OUT);
                    gridView2.SetFocusedRowCellValue("MEALS", load.MEALS);
                    gridView2.SetFocusedRowCellValue("OPER", load.OPER);
                    gridView2.SetFocusedRowCellValue("PRV_CAR", load.PRV_CAR);
                    gridView2.SetFocusedRowCellValue("ARV_FRM", load.ARV_FRM);
                    gridView2.SetFocusedRowCellValue("ARV_TO", load.ARV_TO);
                    gridView2.SetFocusedRowCellValue("ARV_FLT", load.ARV_FLT);
                    gridView2.SetFocusedRowCellValue("ARV_LV_TIME", load.ARV_LV_TIME);
                    gridView2.SetFocusedRowCellValue("ARV_TIME", load.ARV_TIME);
                    gridView2.SetFocusedRowCellValue("ARV_TRNFR", load.ARV_TRNFR);
                    gridView2.SetFocusedRowCellValue("DEP_FRM", load.DEP_FRM);
                    gridView2.SetFocusedRowCellValue("DEP_TO", load.DEP_TO);
                    gridView2.SetFocusedRowCellValue("DEP_FLT", load.DEP_FLT);
                    gridView2.SetFocusedRowCellValue("DEP_TIME", load.DEP_TIME);
                    gridView2.SetFocusedRowCellValue("DEP_AV_TIME", load.DEP_AV_TIME);
                    gridView2.SetFocusedRowCellValue("DEP_TRNFR", load.DEP_TRNFR);
                    gridView2.SetFocusedRowCellValue("CAR_OFF", load.CAR_OFF);
                    gridView2.SetFocusedRowCellValue("PUP_OFF", load.PUP_OFF);
                    gridView2.SetFocusedRowCellValue("DRP_OFF)", load.DRP_OFF);                    
                }
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
            if (ImageComboBoxEditMealcod.Properties.ReadOnly == false)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                    gridView2.SetRowCellValue(i, gridView2.Columns["MEALS"], ImageComboBoxEditMealcod.EditValue);
            }
        }

        private void cPRATEBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save these changes?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                gridView2.MoveFirst();
                gridView2.MoveLast();
                PCompBindingSource.EndEdit();
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

                    ColumnView view = sender as ColumnView;
                    GridColumn column1 = view.Columns["CODE"];
                    GridColumn column2 = view.Columns["DAY"];
                    GridColumn column3 = view.Columns["CAT"];
                    GridColumn column4 = view.Columns["LINE"];

                    //Get the value of the columns
                    string val1 = (string)view.GetRowCellValue(e.RowHandle, column1);
                    int val2 = (int)view.GetRowCellValue(e.RowHandle, column2);
                    string val3 = (string)view.GetRowCellValue(e.RowHandle, column3);
                    int val4 = (int)view.GetRowCellValue(e.RowHandle, column4);

                    var load = from c in context.PCOMP where c.CODE == val1 && c.DAY == val2 && c.CAT == val3 && c.LINE == val4 select c;
                    //Validity criterion
                    if (load.Count() > 0)
                    {
                        e.Valid = false;
                        view.SetColumnError(column1, "You are trying to enter a duplicate record.");
                        
                    }

                    session1.CommitTransaction();
                }
                catch { session1.RollbackTransaction(); }
            }
        }

        private void ImageComboBoxEditLoadCode_TextChanged(object sender, EventArgs e)
        {
            string carCo = ImageComboBoxEditLoadCode.EditValue.ToString();
            gridControl1.DataSource = from c in context.CPRATES where c.CODE == carCo select c;
            gridControl1.DataSource = (from c in context.PCOMP
                                       from d in context.PACK
                                       where c.CODE == carCo && d.CODE == carCo
                                       select new { c.CODE, c.CAT, d.NTS, d.NAME }).Distinct();        
        }

        private void ImageComboBoxEditCopyCode_TextChanged(object sender, EventArgs e)
        {
            string carCo = ImageComboBoxEditCopyCode.EditValue.ToString();
            gridControl2.DataSource = from c in context.CPRATES where c.CODE == carCo && c.CAT == "KJM" select c;
    
        }
    }
}