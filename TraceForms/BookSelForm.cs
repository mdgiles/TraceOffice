using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using FlexModel;
using System.Data.Entity.Core.Objects;
using DevExpress.XtraEditors.Controls;
using System.Linq;
using DevExpress.Xpo;
using System.Linq.Dynamic;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using System.Runtime.InteropServices;
namespace TraceForms
{
    
    public partial class BookSelForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        const string colName1 = "colCode";
        public string firstLoad;
        public FlextourEntities context;
        public BookSelForm(FlexCore.CoreSys _sys)
        {
            InitializeComponent();
            Connection.EFConnectionString = _sys.Settings.EFConnectionString;
            context = new FlextourEntities(_sys.Settings.EFConnectionString);
            gsLoad.gridSearchLoad(codeSearch, "SelGroup", "SelGroup", "SelGroup", "SelGroup", "SelGroup");
            codeSearch.GridControl.DataSource = (from c in context.BookSel select new { c.SelGroup }).Distinct();
            codeSearch.ButtonEdit.TextChanged += ButtonEdit_TextChanged;           
        }
    
        void ButtonEdit_TextChanged(object sender, EventArgs e)
        {
           BookSelBindingSource.DataSource = from c in context.BookSel where c.SelGroup == codeSearch.Text.TrimEnd() select c;

           BookComboBindingSource.DataSource = from c in context.BookCombo where c.BookSel_Group == codeSearch.Text.TrimEnd() select c;       
        }

        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        void ButtonEdit_QueryPopUp(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            ColumnView view = gridView1;
            GridColumn column1 = view.Columns["Link_Table"];
            GridColumn column2 = view.Columns["Link_Column"];
            GridColumn column3 = view.Columns["Description"];

            string val1 = (string)view.GetFocusedRowCellValue(column1);
            string val2 = (string)view.GetFocusedRowCellValue(column2);
            string val3 = (string)view.GetFocusedRowCellValue(column3);
            if ((string.IsNullOrWhiteSpace(val1) || string.IsNullOrWhiteSpace(val2) || string.IsNullOrWhiteSpace(val3)) && newRec == true)
            {
                e.Allow = false;
                return;
            }
            
            if (BookSelBindingSource.Current == null)
            {
                e.Allow = true;
                return;
            }
            
            temp = newRec;
            bool temp2 = modified;

            if (checkForms())
            {
                e.Allow = true;
                if ((!temp) && temp2)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (BookSel)BookSelBindingSource.Current);
            }
            else
            {
                if ((!temp) && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (BookSel)BookSelBindingSource.Current);
       
                e.Allow = false;

            }
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            modified = true;
        }

        private bool checkForms()
        {
            if (!modified && !newRec)
                return true;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((BookSel)BookComboBindingSource.Current).checkAll, BookComboBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, BookComboBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, BookComboBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }

        private void gridView2_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            ColumnView view = gridView2;
            GridColumn column1 = view.Columns["Link_Table"];
            GridColumn column2 = view.Columns["Link_Column"];
            GridColumn column3 = view.Columns["Description"];
            string val1 = (string)view.GetFocusedRowCellValue(column1);
            string val2 = (string)view.GetFocusedRowCellValue(column2);
            string val3 = (string)view.GetFocusedRowCellValue(column3);
            if ((string.IsNullOrWhiteSpace(val1) || string.IsNullOrWhiteSpace(val2) || string.IsNullOrWhiteSpace(val3)) && newRec == true)
            {
                e.Allow = false;
                return;
            }

            if (BookComboBindingSource.Current == null)
            {
                e.Allow = true;
                return;
            }
            temp = newRec;
            bool temp2 = modified;

            if (checkForms())
            {
                e.Allow = true;
                if ((!temp) && temp2)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (BookSel)BookSelBindingSource.Current);
            }
            else
                e.Allow = false;
        }

        private void gridView2_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }

        private void gridView2_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            modified = true;
        }     

        private void BookSelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (modified || newRec)
            {
                DialogResult select = DevExpress.XtraEditors.XtraMessageBox.Show("There are unsaved changes. Are you sure want to exit?", Name, MessageBoxButtons.YesNo);
                if (select == DialogResult.Yes)
                {
                    e.Cancel = false;
                    this.Dispose();
                }
                else if (select == DialogResult.No)
                    e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                this.Dispose();
            }
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            GridColumn column1 = view.Columns["Type"];
            GridColumn column2 = view.Columns["Code"];
            GridColumn column3 = view.Columns["Cat"];

            string val1 = (string)view.GetRowCellValue(e.RowHandle, column1);
            string val2 = (string)view.GetRowCellValue(e.RowHandle, column2);
            string val3 = (string)view.GetRowCellValue(e.RowHandle, column3);

            if (string.IsNullOrWhiteSpace(val1))
            {
                e.Valid = false;
                view.SetColumnError(column1, "Type cannot be blank in a row.");
            }

            if (string.IsNullOrWhiteSpace(val2) && val1 != "QRY")
            {
                e.Valid = false;
                view.SetColumnError(column2, "Code cannot be blank in a row.");
            }

            if (string.IsNullOrWhiteSpace(val3) && val1 != "QRY")
            {
                e.Valid = false;
                view.SetColumnError(column3, "Category cannot be blank in a row.");
            }
        }

        private void gridView2_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            GridColumn column1 = view.Columns["Type"];
            GridColumn column2 = view.Columns["Code"];
            GridColumn column3 = view.Columns["Cat"];

            string val1 = (string)view.GetRowCellValue(e.RowHandle, column1);
            string val2 = (string)view.GetRowCellValue(e.RowHandle, column2);
            string val3 = (string)view.GetRowCellValue(e.RowHandle, column3);

            if (string.IsNullOrWhiteSpace(val1))
            {
                e.Valid = false;
                view.SetColumnError(column1, "Type cannot be blank in a row.");
            }

            if (string.IsNullOrWhiteSpace(val2) && val1 != "QRY")
            {
                e.Valid = false;
                view.SetColumnError(column2, "Code cannot be blank in a row.");
            }

            if (string.IsNullOrWhiteSpace(val3) && val1 != "QRY")
            {
                e.Valid = false;
                view.SetColumnError(column3, "Category cannot be blank in a row.");
            }
        }

        private void grdSelAdd_Click(object sender, EventArgs e)
        {
            ColumnView view1 = gridView1;
            GridColumn column1 = view1.Columns["Type"];
            GridColumn column2 = view1.Columns["Code"];
            GridColumn column3 = view1.Columns["Cat"];

            string val4 = (string)view1.GetFocusedRowCellValue(column1);
            string val5 = (string)view1.GetFocusedRowCellValue(column2);
            string val6 = (string)view1.GetFocusedRowCellValue(column3);

            if (string.IsNullOrWhiteSpace(val4))
            {

                view1.SetColumnError(column1, "Type cannot be blank in a row.");
                return;
            }

            if (string.IsNullOrWhiteSpace(val5) && val4 != "QRY")
            {

                view1.SetColumnError(column2, "Code cannot be blank in a row.");
                return;
            }

            if (string.IsNullOrWhiteSpace(val6) && val4 != "QRY")
            {

                view1.SetColumnError(column3, "Category cannot be blank in a row.");
                return;
            }
            BookSelBindingSource.AddNew();
            gridView1.SetFocusedRowCellValue("SelGroup", codeSearch.Text);
            gridView1.SetFocusedRowCellValue("Description", descriptionTextEdit.Text);
        }

        private void grdSelDel_Click(object sender, EventArgs e)
        {
            int handle = gridView1.FocusedRowHandle;
            BookSelBindingSource.RemoveAt(handle);
            context.SaveChanges();
            //gridView1.DeleteRow(handle);
        }

        private void grdReqAdd_Click(object sender, EventArgs e)
        {
            ColumnView view1 = gridView2;
            GridColumn column1 = view1.Columns["Type"];
            GridColumn column2 = view1.Columns["Code"];
            GridColumn column3 = view1.Columns["Cat"];

            string val4 = (string)view1.GetFocusedRowCellValue(column1);
            string val5 = (string)view1.GetFocusedRowCellValue(column2);
            string val6 = (string)view1.GetFocusedRowCellValue(column3);

            if (string.IsNullOrWhiteSpace(val4))
            {
               
                view1.SetColumnError(column1, "Type cannot be blank in a row.");
                return;
            }

            if (string.IsNullOrWhiteSpace(val5) && val4 != "QRY")
            {
                
                view1.SetColumnError(column2, "Code cannot be blank in a row.");
                return;
            }

            if (string.IsNullOrWhiteSpace(val6) && val4 != "QRY")
            {
               
                view1.SetColumnError(column3, "Category cannot be blank in a row.");
                return;
            }
            BookComboBindingSource.AddNew();
            gridView2.SetFocusedRowCellValue("BookSel_Group", codeSearch.Text);
            gridView2.SetFocusedRowCellValue("Description", descriptionTextEdit.Text);
        }

        private void grdReqDel_Click(object sender, EventArgs e)
        {
            int handle = gridView2.FocusedRowHandle;
            BookComboBindingSource.RemoveAt(handle);
            context.SaveChanges();
        }

        private void SaveChangesSel_Click(object sender, EventArgs e)
        {

            if (gridView1.UpdateCurrentRow())
            { //add call to validCheck
                BookSelBindingSource.EndEdit();
                context.SaveChanges();
            }
        }

        private void SaveChangesReq_Click(object sender, EventArgs e)
        {

            if (gridView2.UpdateCurrentRow())
            {
                //add call to validCheck
                BookComboBindingSource.EndEdit();
                context.SaveChanges();
            }
        }

        private void codeSearch_Enter(object sender, EventArgs e)
        {
            codeSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }
    }
}