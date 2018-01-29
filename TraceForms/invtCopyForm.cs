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
    
    public partial class invtCopyForm : DevExpress.XtraEditors.XtraForm
    {
        public FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        string username;

        public invtCopyForm(FlexCore.CoreSys _sys)
        {
            InitializeComponent();
            Connection.EFConnectionString = _sys.Settings.EFConnectionString;
            context = new FlextourEntities(_sys.Settings.EFConnectionString);
            username = _sys.User.Name;
            loadCodeSearch.ButtonEdit.TextChanged += ButtonEdit_TextChanged;
            copyCodeSearch.ButtonEdit.TextChanged += ButtonEdit_TextChanged1;
            gsLoad.gridSearchLoad(agencySearch, "NO", "NAME", "Code", "Name", "NO", "NO", "NO");
            gsLoad.gridSearchLoad(gridSearchControl4, "CODE", "DESC", "Code", "Name", "CODE", "CODE", "CODE");
            agencySearch.GridControl.DataSource = from c in context.AGY select new { c.NO, c.NAME };
            gridSearchControl4.GridControl.DataSource = from c in context.ROOMCOD select new { c.CODE, c.DESC };
            agencySearch.ButtonEdit.Properties.ReadOnly = true;
            gridSearchControl4.ButtonEdit.Properties.ReadOnly = true;           
        }

        void ButtonEdit_TextChanged1(object sender, EventArgs e)
        {
            gridControl2.DataSource = from c in context.INVT where c.CODE == loadCodeSearch.Text.TrimEnd() && c.CAT == "KJM" select c;
        }
        void ButtonEdit_TextChanged(object sender, EventArgs e)
        {
            gridControl1.DataSource = from c in context.INVT where c.CODE == loadCodeSearch.Text.TrimEnd() select c;
        }

        private void tYPEComboBoxEdit_TextChanged(object sender, EventArgs e)
        {
            if (this.tYPEComboBoxEdit.Text == "OPT" || this.tYPEComboBoxEdit.Text == "PKG" || this.tYPEComboBoxEdit.Text == "HTL")
            {
                gsLoad.gridSearchLoad(loadCodeSearch, "CODE", "NAME", "Code", "Name", "CODE", "CODE", "CODE");
                gsLoad.gridSearchLoad(copyCodeSearch, "CODE", "NAME", "Code", "Name", "CODE", "CODE", "CODE");

                if (this.tYPEComboBoxEdit.Text == "HTL")
                {
                    // htl codes
                   
                    loadCodeSearch.GridControl.DataSource = from c in context.HOTEL
                                                                select new { c.CODE, c.NAME };
                    copyCodeSearch.GridControl.DataSource = from c in context.HOTEL
                                                                select new { c.CODE, c.NAME };
                }
                if (this.tYPEComboBoxEdit.Text == "OPT")
                {
                   
                    // option codes
                    loadCodeSearch.GridControl.DataSource = from c in context.COMP
                                                                select new { c.CODE, c.NAME };
                    copyCodeSearch.GridControl.DataSource = from c in context.COMP
                                                                select new { c.CODE, c.NAME };
                }

                if (this.tYPEComboBoxEdit.Text == "PKG")
                {
                  
                    // pkg codes
                    loadCodeSearch.GridControl.DataSource = from c in context.PACK
                                                                select new { c.CODE, c.NAME };
                    copyCodeSearch.GridControl.DataSource = from c in context.PACK
                                                                select new { c.CODE, c.NAME };
                }
            }
            if (this.tYPEComboBoxEdit.Text == "CRU" || this.tYPEComboBoxEdit.Text == "AIR")
            {

                gsLoad.gridSearchLoad(loadCodeSearch, "Code", "Name", "Code", "Name", "Code", "Code", "Code");
                gsLoad.gridSearchLoad(copyCodeSearch, "Code", "Name", "Code", "Name", "Code", "Code", "Code");

                if (this.tYPEComboBoxEdit.Text == "CRU")
                {
                    
                    loadCodeSearch.GridControl.DataSource = from c in context.SeaPort
                                                                select new { c.Code, c.Name };
                    copyCodeSearch.GridControl.DataSource = from c in context.SeaPort
                                                                select new { c.Code, c.Name };
                }
                if (this.tYPEComboBoxEdit.Text == "AIR")
                {
                    
                    //airports
                    loadCodeSearch.GridControl.DataSource = from c in context.Airport
                                                                select new { c.Code, c.Name };
                    copyCodeSearch.GridControl.DataSource = from c in context.Airport
                                                                select new { c.Code, c.Name };
                }

            }
        }

        private void gridSearchControl1_Enter(object sender, EventArgs e)
        {
            loadCodeSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        private void gridSearchControl1_ItemSelected()
        {
            loadCodeSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        private void gridSearchControl2_Enter(object sender, EventArgs e)
        {
            copyCodeSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        private void gridSearchControl2_ItemSelected()
        {
            copyCodeSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        private void gridSearchControl3_Enter(object sender, EventArgs e)
        {
            agencySearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        private void gridSearchControl3_ItemSelected()
        {
            agencySearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        private void gridSearchControl4_Enter(object sender, EventArgs e)
        {
            gridSearchControl4.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        private void gridSearchControl4_ItemSelected()
        {
            gridSearchControl4.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
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
                agencySearch.ButtonEdit.Properties.ReadOnly = false;

            if (checkEdit3.Checked)
                agencySearch.ButtonEdit.Properties.ReadOnly = true; 
        }

        private void checkEdit4_Click(object sender, EventArgs e)
        {
            if (!checkEdit4.Checked)
                gridSearchControl4.ButtonEdit.Properties.ReadOnly = false;

            if (checkEdit4.Checked)
                gridSearchControl4.ButtonEdit.Properties.ReadOnly = true; 
        }

        private void checkEdit9_Click(object sender, EventArgs e)
        {
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
                gridView2.SetFocusedRowCellValue("TYPE", tYPEComboBoxEdit.Text);
                gridView2.SetFocusedRowCellValue("CODE", copyCodeSearch.Text);               
                gridView2.SetFocusedRowCellValue("CAT", gridView1.GetRowCellValue(val, "CAT"));
                gridView2.SetFocusedRowCellValue("TP", gridView1.GetRowCellValue(val, "TP"));                
                gridView2.SetFocusedRowCellValue("DATE", gridView1.GetRowCellValue(val, "DATE"));
                gridView2.SetFocusedRowCellValue("UPD_DATE", DateTime.Now);
                gridView2.SetFocusedRowCellValue("UPD_BY", username); 
                gridView2.SetFocusedRowCellValue("ORIG_AMT", gridView1.GetRowCellValue(val, "ORIG_AMT"));
                gridView2.SetFocusedRowCellValue("AV_AMT", gridView1.GetRowCellValue(val, "AV_AMT"));
                gridView2.SetFocusedRowCellValue("AV", gridView1.GetRowCellValue(val, "AV"));
                gridView2.SetFocusedRowCellValue("MIN", gridView1.GetRowCellValue(val, "MIN"));
                gridView2.SetFocusedRowCellValue("CANC", gridView1.GetRowCellValue(val, "CANC"));
                gridView2.SetFocusedRowCellValue("REL", gridView1.GetRowCellValue(val, "REL"));
                gridView2.SetFocusedRowCellValue("AGENCY", gridView1.GetRowCellValue(val, "AGENCY"));
                gridView2.SetFocusedRowCellValue("RELCODE", gridView1.GetRowCellValue(val, "RELCODE"));
                gridView2.SetFocusedRowCellValue("RELCAT", gridView1.GetRowCellValue(val, "RELCAT"));
                gridView2.SetFocusedRowCellValue("RELTYP", gridView1.GetRowCellValue(val, "RELTYP"));
                gridView2.SetFocusedRowCellValue("RELAGY", gridView1.GetRowCellValue(val, "RELAGY"));
                gridView2.SetFocusedRowCellValue("ALLOCTD", gridView1.GetRowCellValue(val, "ALLOCTD"));
                gridView2.SetFocusedRowCellValue("HOLD", gridView1.GetRowCellValue(val, "HOLD"));
                gridView2.SetFocusedRowCellValue("MIN_BK_DAYS", gridView1.GetRowCellValue(val, "MIN_BK_DAYS"));
                gridView2.SetFocusedRowCellValue("MAX", gridView1.GetRowCellValue(val, "MAX"));
                gridView2.SetFocusedRowCellValue("Requestable", gridView1.GetRowCellValue(val, "Requestable"));
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
            if (agencySearch.ButtonEdit.Properties.ReadOnly == false)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                    gridView2.SetRowCellValue(i, gridView2.Columns["AGENCY"], agencySearch.Text);
            }
            if (gridSearchControl4.ButtonEdit.Properties.ReadOnly == false)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                    gridView2.SetRowCellValue(i, gridView2.Columns["CAT"], gridSearchControl4.Text);
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
           


            if (textEdit1.Enabled == true)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                    gridView2.SetRowCellValue(i, gridView2.Columns["TP"], textEdit1.Text);
            }
           
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

                    GridColumn column5 = view.Columns["DATE"];
                  

                    //Get the value of the columns
                    string val1 = (string)view.GetRowCellValue(e.RowHandle, column1);
                    string val2 = (string)view.GetRowCellValue(e.RowHandle, column2);
                    string val3 = (string)view.GetRowCellValue(e.RowHandle, column3);

                    DateTime time1 = (DateTime)view.GetRowCellValue(e.RowHandle, column5);
                   


                    var load = from c in context.INVT where c.CODE == val1 && c.AGENCY == val2 && c.CAT == val3 select new { c.DATE };
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

        private void cARRATEBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save these changes?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                gridView2.MoveFirst();
                gridView2.MoveLast();
                InvtBindingSource.EndEdit();
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
                INVT rec = (from hratRec in context.INVT where hratRec.ID == ID select hratRec).FirstOrDefault();
                context.INVT.DeleteObject(rec);
                context.SaveChanges();
            }
        }
   
    }
}