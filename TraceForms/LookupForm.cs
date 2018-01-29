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
    
    public partial class LookupForm : DevExpress.XtraEditors.XtraForm
    {
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        public string currentVal;
        public  FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public LookupForm(FlexCore.CoreSys _sys)
        {
            InitializeComponent();
            Connection.EFConnectionString = _sys.Settings.EFConnectionString;
            context = new FlextourEntities(_sys.Settings.EFConnectionString);
            LookupBindingSource.DataSource = context.LOOKUP;
            advBandedGridView1.ExpandAllGroups();
        }
  
        private bool move()
        {
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (LOOKUP)LookupBindingSource.Current);

                newRec = false;
                modified = false;
                return true;
            }
            return false;
        }

        private void lookup_FormClosing(object sender, FormClosingEventArgs e)
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

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            temp = newRec;
          
           if (!temp && checkForms())
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (LOOKUP)LookupBindingSource.Current);
        }

        private bool checkForms()
        {
            if (!modified && !newRec)
                return true;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel1.Controls, errorProvider1, ((LOOKUP)LookupBindingSource.Current).checkAll, LookupBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, LookupBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, LookupBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            advBandedGridView1.MoveLast();
            if (newRec == true)
            {
                MessageBox.Show("Please save current new record before adding another.");
                return;

            }
            
            if (LookupBindingSource.Current == null)
            {
                LookupBindingSource.AddNew();
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (LOOKUP)LookupBindingSource.Current);
                LookupBindingSource.AddNew();
                newRec = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (LookupBindingSource.Current == null)
                return;
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                modified = false;
                newRec = false;
                LookupBindingSource.RemoveCurrent();
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

        private void lOOKUPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
          
            if (LookupBindingSource.Current == null)
                return;
            advBandedGridView1.UpdateCurrentRow();
            advBandedGridView1.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            bool temp = newRec;
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

            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (LOOKUP)LookupBindingSource.Current);
            
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }
    
        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (move())
                LookupBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                LookupBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                LookupBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                LookupBindingSource.MoveLast();
        }

        private void advBandedGridView1_BeforeLeaveRow(object sender, RowAllowEventArgs e)
        {
            
            if (LookupBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (LOOKUP)LookupBindingSource.Current);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (LOOKUP)LookupBindingSource.Current);
         
                e.Allow = false;
            }
        }

        private void advBandedGridView1_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            if (!advBandedGridView1.IsFilterRow(e.RowHandle))
                modified = true;
        }

        private void advBandedGridView1_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }

        private void advBandedGridView1_ValidateRow(object sender, ValidateRowEventArgs e)
        {
          
        }

       


        //  //var table =  context.GetType().GetProperty(gridSearchControl1.Text.TrimEnd(), ).GetValue(context, null) ;
        //Type t = (from c in context.LOOKUP where c.LINK_TABLE == gridSearchControl1.Text.TrimEnd() select c).GetType();
        //IQueryable L = (IQueryable)(context.GetType().GetProperty(gridSearchControl1.Text.TrimEnd()).GetValue(context, null));
        //gridControl1.DataSource = L;
        //  MessageBox.Show(t.ToString() + " " + s.ToString());
        ////  //PropertyInfo p = t.GetProperty(gridSearchControl1.Text.TrimEnd());
        ////  //var table = p.GetValue(context, null);

        //////gridControl1.DataSource = (context.GetType().GetProperty(gridSearchControl1.Text.TrimEnd()).GetValue(context,null));
        ////  gridControl1.DataSource = table;
        //string query = "Select * From " + gridSearchControl1.Text.TrimEnd();
        //gridControl1.DataSource =(context.ExecuteStoreQuery<FlextourEntities>(query, gridSearchControl1.Text.TrimEnd()));

        //gridControl1.DataSource = (ObjectQuery)context.CreateQuery<FlextourEntities>(query);
           

    }
}