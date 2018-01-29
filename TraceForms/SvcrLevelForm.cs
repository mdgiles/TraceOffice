using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FlexModel;
using DevExpress.Xpo;
using DevExpress.XtraEditors.Controls;
using System.Linq;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using System.Runtime.InteropServices;
namespace TraceForms
{
    
    public partial class SvcrLevelForm : DevExpress.XtraEditors.XtraForm
    {
        public string table;
        public FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public SvcrLevelForm(FlexCore.CoreSys _sys)
        {
            InitializeComponent();
            Connection.EFConnectionString = _sys.Settings.EFConnectionString;
            context = new FlextourEntities(_sys.Settings.EFConnectionString);
        }

        private void typeComboBoxEdit_TextChanged(object sender, EventArgs e)
        {
            sourceComboBoxEdit.Text = "ALL";
            sourceComboBoxEdit.Text = "ALL";
            if (typeComboBoxEdit.Text == "OPT")
            {
                table = "COMP";
                gridControl1.DataSource = (from c in context.SvcRLevel where c.Type == "OPT"  select c);
            }
            if (typeComboBoxEdit.Text == "PKG")
            {
                table = "PACK";
                gridControl1.DataSource = (from c in context.SvcRLevel where c.Type == "PKG" select c);
            }
            if (typeComboBoxEdit.Text == "HTL")
            {
                table = "HOTEL";
                gridControl1.DataSource = (from c in context.SvcRLevel where c.Type == "HTL"  select c);
            }
            if (typeComboBoxEdit.Text == "CAR")
            {
                table = "CARINFO";
                gridControl1.DataSource = (from c in context.SvcRLevel where c.Type == "CAR" select c);
            }
            if (typeComboBoxEdit.Text == "AIR")
            {
                table = "AIR";
                gridControl1.DataSource = (from c in context.SvcRLevel where c.Type == "AIR" select c);
            }
            if (typeComboBoxEdit.Text == "CRU")
            {
                table = "CRU";
                gridControl1.DataSource = (from c in context.SvcRLevel where c.Type == "CRU" select c);
            }
            if (typeComboBoxEdit.Text == "INS")
            {
                table = "INSURAN";
                gridControl1.DataSource = (from c in context.SvcRLevel where c.Type == "INS" select c);
            }
            if (typeComboBoxEdit.Text == "AGY")
            {
                table = "AGY";
                gridControl1.DataSource = (from c in context.SvcRLevel where c.Type == "AGY"  select c);
            }
        }

        private void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            RepositoryItemComboBox gridOne = new RepositoryItemComboBox();
            //RepositoryItemComboBox gridTwo = new RepositoryItemComboBox();
            //RepositoryItemComboBox gridThree = new RepositoryItemComboBox();

            //if (e.Column.FieldName == "Link_Table")
            //{

            //    gridControl1.RepositoryItems.Add(gridOne);
            //    gridOne.Items.Add(table);
            //    gridOne.Items.Add("DETAIL");
            //    e.RepositoryItem = gridOne;

            //}
            //if (e.Column.FieldName == "Link_Column")
            //{


            //    gridControl1.RepositoryItems.Add(gridTwo);

            //    string table1 = gridView1.GetRowCellValue(e.RowHandle, "Link_Table").ToString();

            //    IQueryable load = (IQueryable)context.GetType().GetProperty(table1.TrimEnd()).GetValue(context, null);
            //    var something = (load.ElementType.GetProperties().Where(p => p.PropertyType.Name == "String" || p.PropertyType.Name.Contains("able")).Select(p => p.Name));
            //    foreach (var please in something)
            //    {
            //        //MessageBox.Show(please);
            //        gridTwo.Items.Add(please);
            //    }
            //    ////MessageBox.Show(something.GetType().UnderlyingSystemType.Name);   .Where(p => p.PropertyType.Name == "String" || p.PropertyType.Name == "Nullable1").Select(p=> p.Name))
            //    //MessageBox.Show(something.ToString());
            //    //gridTwo.Items.AddRange(something);

            //    e.RepositoryItem = gridTwo;



            //}
            //if (e.Column.FieldName == "Lookup_Column")
            //{
            //    gridControl1.RepositoryItems.Add(gridThree);
            //    string table1 = gridView1.GetRowCellValue(e.RowHandle, "Lookup_Table").ToString();
            //    if (!string.IsNullOrWhiteSpace(table1))
            //    {
            //        IQueryable load = (IQueryable)context.GetType().GetProperty(table1.TrimEnd()).GetValue(context, null);
            //        var something = load.ElementType.GetProperties();
            //        foreach (var please in something)
            //        {
            //            gridThree.Items.Add(please.Name);
            //        }

            //        e.RepositoryItem = gridThree;
            //    }
            //}

        }

        private void repositoryItemPopupContainerEdit1_QueryResultValue(object sender, QueryResultValueEventArgs e)
        {
            e.Value = gridView2.GetFocusedRowCellDisplayText("Name");
        }

        private void repositoryItemPopupContainerEdit1_Click(object sender, EventArgs e)
        {
            string table1 = gridView1.GetFocusedRowCellDisplayText("Link_Table");

            IQueryable load = (IQueryable)context.GetType().GetProperty(table1.TrimEnd()).GetValue(context, null);
            gridControl2.DataSource = load.ElementType.GetProperties();
             
        }

        private void repositoryItemPopupContainerEdit1_Leave(object sender, EventArgs e)
        {
            gridControl2.DataSource = null;
        }

        private void linkColOk_Click(object sender, EventArgs e)
        {
            popupContainerControl1.OwnerEdit.ClosePopup();
        }

        private void linkColCancel_Click(object sender, EventArgs e)
        {
            popupContainerControl1.OwnerEdit.CancelPopup();
        }

        private void linkColHelp_Click(object sender, EventArgs e)
        {
            // will return later
        }

        private void repositoryItemPopupContainerEdit2_Click(object sender, EventArgs e)
        {
            string table1 = gridView1.GetFocusedRowCellDisplayText("Lookup_Table");

            IQueryable load = (IQueryable)context.GetType().GetProperty(table1.TrimEnd()).GetValue(context, null);
            gridControl3.DataSource = load.ElementType.GetProperties();
        }

        private void repositoryItemPopupContainerEdit2_QueryResultValue(object sender, QueryResultValueEventArgs e)
        {
            e.Value = gridView3.GetFocusedRowCellDisplayText("Name");
        }

        private void repositoryItemPopupContainerEdit2_Leave(object sender, EventArgs e)
        {
            gridControl3.DataSource = null;
        }

        private void lookColOk_Click(object sender, EventArgs e)
        {
            popupContainerControl2.OwnerEdit.ClosePopup();
        }

        private void lookColCancel_Click(object sender, EventArgs e)
        {
            popupContainerControl2.OwnerEdit.CancelPopup();
        }

        private void lookColHelp_Click(object sender, EventArgs e)
        {
            //I'll BE BACK    (in BEST Gov. Arnold voice)
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            using (Session session1 = new Session())
            {

                session1.BeginTransaction();
                try
                {                    
                    ColumnView view = sender as ColumnView;
                    GridColumn column1 = view.Columns["Link_Table"];
                    GridColumn column2 = view.Columns["Link_Column"];
                    GridColumn column3 = view.Columns["Description"];      

                    string val1 = (string)view.GetRowCellValue(e.RowHandle, column1);
                    string val2 = (string)view.GetRowCellValue(e.RowHandle, column2);
                    string val3 = (string)view.GetRowCellValue(e.RowHandle, column3);

                    if (string.IsNullOrWhiteSpace(val1))
                    {
                        e.Valid = false;
                        view.SetColumnError(column1, "Link Table cannot be blank in a row.");
                    }

                    if (string.IsNullOrWhiteSpace(val2))
                    {
                        e.Valid = false;
                        view.SetColumnError(column2, "Link Column cannot be blank in a row.");
                    }

                    if (string.IsNullOrWhiteSpace(val3))
                    {
                        e.Valid = false;
                        view.SetColumnError(column3, "Description cannot be blank in a row.");
                    }

                    session1.CommitTransaction();
                }
                catch { session1.RollbackTransaction(); }
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {            

        }

        private void svcRLevelBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

        }

        private void SvcrLevelForm_FormClosing(object sender, FormClosingEventArgs e)
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