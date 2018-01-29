using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FlexModel;
using System.Linq;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using System.Runtime.InteropServices;
using DevExpress.XtraGrid;
namespace TraceForms
{
    
    public partial class cruitItemForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        const string colName = "colCODE";
        public FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public cruitItemForm(FlexCore.CoreSys _sys)
        {
            InitializeComponent();
            Connection.EFConnectionString = _sys.Settings.EFConnectionString;
            context = new FlextourEntities(_sys.Settings.EFConnectionString);
            CruItItemBindingSource.DataSource = context.CRUITItem;
        }

        private bool checkForms()
        {
            if (!modified && !newRec)
                return true;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((CRUITItem)CruItItemBindingSource.Current).checkAll, CruItItemBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, CruItItemBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, CruItItemBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }

        private bool move()
        {
            ColumnView view = advBandedGridView1;
            GridColumn column1 = view.Columns["CODE"];
            GridColumn column2 = view.Columns["ITIN"];
          

            string val1 = (string)view.GetFocusedRowCellValue(column1);
            string val2 = (string)view.GetFocusedRowCellValue(column2);
      

            if (string.IsNullOrWhiteSpace(val1))
            {
                view.SetColumnError(column1, "Code cannot be blank in a row.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(val2))
            {
                view.SetColumnError(column2, "Itinerary cannot be blank in a row.");
                return false;
            }

            advBandedGridView1.Focus();
            
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;


            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CRUITItem)CruItItemBindingSource.Current);

                newRec = false;
                modified = false;
                return true;
            }
            return false;
        }

        private void advBandedGridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            GridColumn column1 = view.Columns["CODE"];
            GridColumn column2 = view.Columns["ITIN"];

            string val1 = (string)view.GetRowCellValue(e.RowHandle, column1);
            string val2 = (string)view.GetRowCellValue(e.RowHandle, column2);

            if (string.IsNullOrWhiteSpace(val1))
            {
                e.Valid = false;
                view.SetColumnError(column1, "Code cannot be blank in a row.");
            }

            if (string.IsNullOrWhiteSpace(val2))
            {
                e.Valid = false;
                view.SetColumnError(column2, "Itinerary cannot be blank in a row.");
            }

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            advBandedGridView1.ClearColumnsFilter();
            if (CruItItemBindingSource.Current == null)
            {
                //fake query in order to create a link between the database table and the binding source
                CruItItemBindingSource.DataSource = from opt in context.CRUITItem where opt.CODE == "KJM9" select opt;
                CruItItemBindingSource.AddNew();
                //gridSearchControl1.Focus();
                newRec = true;
                return;
            }
            advBandedGridView1.Focus();
            //bindingNavigatorPositionItem.Focus();  //trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CRUITItem)CruItItemBindingSource.Current);
                CruItItemBindingSource.AddNew();
                newRec = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (CruItItemBindingSource.Current == null)
                return;

            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                modified = false;
                newRec = false;
                CruItItemBindingSource.RemoveCurrent();
                errorProvider1.Clear();
                context.SaveChanges();
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);
            }
            //currentVal = gridSearchControl1.Text;
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }

        private void cRUITItemBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            ColumnView view = advBandedGridView1;
            GridColumn column1 = view.Columns["CODE"];
            GridColumn column2 = view.Columns["ITIN"];
            

            string val1 = (string)view.GetFocusedRowCellValue(column1);
            string val2 = (string)view.GetFocusedRowCellValue(column2);
         

            if (string.IsNullOrWhiteSpace(val1))
            {
                view.SetColumnError(column1, "Code cannot be blank in a row.");
                return;
            }

            if (string.IsNullOrWhiteSpace(val2))
            {
                view.SetColumnError(column2, "Itinerary cannot be blank in a row.");
                return;
            }

          

            if (CruItItemBindingSource.Current == null)
                return;

            advBandedGridView1.UpdateCurrentRow();
            advBandedGridView1.Focus();
            bool temp = newRec;
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            if (checkForms())
            {
                //gridSearchControl1.Focus();
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
            }

            if (!temp  && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CRUITItem)CruItItemBindingSource.Current);


        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
             if (move())
                CruItItemBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                CruItItemBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                CruItItemBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                CruItItemBindingSource.MoveLast();
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            temp = newRec;
            ColumnView view = advBandedGridView1;
            GridColumn column1 = view.Columns["CODE"];
            GridColumn column2 = view.Columns["ITIN"];
            

            string val1 = (string)view.GetFocusedRowCellValue(column1);
            string val2 = (string)view.GetFocusedRowCellValue(column2);
           

            if (string.IsNullOrWhiteSpace(val1))
            {
                view.SetColumnError(column1, "Code cannot be blank in a row.");
                return;
            }

            if (string.IsNullOrWhiteSpace(val2))
            {
                view.SetColumnError(column2, "Itinerary cannot be blank in a row.");
                return;
            }

           
            if (!temp && checkForms())
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CRUITItem)CruItItemBindingSource.Current);
        }

        private void cruitItemForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void advBandedGridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            ColumnView view = advBandedGridView1;
            GridColumn column1 = view.Columns["CODE"];
            GridColumn column2 = view.Columns["ITIN"];
           

            string val1 = (string)view.GetFocusedRowCellValue(column1);
            string val2 = (string)view.GetFocusedRowCellValue(column2);
          
            if ((string.IsNullOrWhiteSpace(val1) || string.IsNullOrWhiteSpace(val2) ) && newRec == true) 
            {
                e.Allow = false;
                return;
            }
            
            if (CruItItemBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CRUITItem)CruItItemBindingSource.Current);
            }
            else
                e.Allow = false;
        }

        private void advBandedGridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!advBandedGridView1.IsFilterRow(e.RowHandle))
                modified = true;
        }

        private void advBandedGridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
           // e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void cruitItemForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && advBandedGridView1.IsFilterRow(advBandedGridView1.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = advBandedGridView1.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(advBandedGridView1.GetFocusedDisplayText()))
                value = advBandedGridView1.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.CODE like '{0}%'", advBandedGridView1.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                var special = context.CRUIT.Where(query);

                if (!string.IsNullOrWhiteSpace(advBandedGridView1.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "ITIN")))
                {
                    query = String.Format("it.{0} like '{1}%'", "ITIN", advBandedGridView1.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "ITIN"));
                    special = special.Where(query);
                }

                if (!string.IsNullOrWhiteSpace(advBandedGridView1.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Day")))
                {
                    query = String.Format("it.{0} like '{1}%'", "Day", advBandedGridView1.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Day"));
                    special = special.Where(query);
                }

                if (!string.IsNullOrWhiteSpace(advBandedGridView1.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Line")))
                {
                    query = String.Format("it.{0} like '{1}%'", "Line", advBandedGridView1.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Line"));
                    special = special.Where(query);
                }

                if (!string.IsNullOrWhiteSpace(advBandedGridView1.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "DepPort")))
                {
                    query = String.Format("it.{0} like '{1}%'", "DepPort", advBandedGridView1.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "DepPort"));
                    special = special.Where(query);
                }

                if (!string.IsNullOrWhiteSpace(advBandedGridView1.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "ArvPort")))
                {
                    query = String.Format("it.{0} like '{1}%'", "ArvPort", advBandedGridView1.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "ArvPort"));
                    special = special.Where(query);
                }

                if (!string.IsNullOrWhiteSpace(advBandedGridView1.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "DepTime")))
                {
                    query = String.Format("it.{0} like '{1}%'", "DepTime", advBandedGridView1.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "DepTime"));
                    special = special.Where(query);
                }

                if (!string.IsNullOrWhiteSpace(advBandedGridView1.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "ArvTime")))
                {
                    query = String.Format("it.{0} like '{1}%'", "ArvTime", advBandedGridView1.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "ArvTime"));
                    special = special.Where(query);
                }

                int count = special.Count();
                if (count > 0)
                {
                    CruItItemBindingSource.DataSource = special;
                    advBandedGridView1.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    advBandedGridView1.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }
    }
}