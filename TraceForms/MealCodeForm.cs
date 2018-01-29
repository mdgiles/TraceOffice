using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FlexModel;
using System.ComponentModel.DataAnnotations;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using System.Linq;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Runtime.InteropServices;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraEditors.Repository;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using System.Data.Entity.Core.Objects;
using System.Linq.Dynamic;
using DevExpress.XtraGrid.Views.Grid;

using System.Data.Linq.SqlClient;
namespace TraceForms
{
    
    public partial class MealCodeForm : XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        const string colName = "colCODE";
        public  FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public MealCodeForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);
            setReadOnly(true);
            enableNavigator(false);          
        }

        void enableNavigator(bool value)
        {
            bindingNavigatorMoveNextItem.Enabled = value;
            bindingNavigatorMoveLastItem.Enabled = value;
            bindingNavigatorMoveFirstItem.Enabled = value;
            bindingNavigatorMovePreviousItem.Enabled = value;
        }

        private void setReadOnly(bool valid)
        {
            TextEditCode.Properties.ReadOnly = valid;
            GridViewMeal.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = !valid;        
        }

        private void setValues()
        {
            GridViewMeal.SetFocusedRowCellValue("CODE", string.Empty);
            GridViewMeal.SetFocusedRowCellValue("DESC", string.Empty);
            GridViewMeal.SetFocusedRowCellValue("LONG_DESC", string.Empty);
            GridViewMeal.SetFocusedRowCellValue("DATAFLEX_FILL_01",string.Empty);
       

        }
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            GridViewMeal.ClearColumnsFilter();
            if (MealCodBindingSource.Current == null)
            {
                MealCodBindingSource.DataSource = from opt in context.MEALCOD where opt.CODE == "KJM9" select opt;
                MealCodBindingSource.AddNew();
                if (GridViewMeal.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewMeal.FocusedRowHandle = GridViewMeal.RowCount - 1;
                TextEditCode.Focus();
                setValues();
                setReadOnly(false);
                newRec = true;
                return;
            }
            TextEditCode.Focus();
            //bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewMeal.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( MEALCOD)MealCodBindingSource.Current);
                MealCodBindingSource.AddNew();
                if (GridViewMeal.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewMeal.FocusedRowHandle = GridViewMeal.RowCount - 1;
                TextEditCode.Focus();
                setValues();
                setReadOnly(false);
                newRec = true;
            }

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (MealCodBindingSource.Current == null)
                return;
            GridViewMeal.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                modified = false;
                newRec = false;
                MealCodBindingSource.RemoveCurrent();
                errorProvider1.Clear();
                context.SaveChanges();
                setReadOnly(true);
                //bindingNavigatorPositionItem.Focus();
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);
            }
            currentVal = TextEditCode.Text;

        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }


        private bool checkForms()
        {
            if (!modified && !newRec)
                return true;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((MEALCOD)MealCodBindingSource.Current).checkAll, MealCodBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, MealCodBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, MealCodBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }


        private void mEALCODBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (MealCodBindingSource.Current == null)
                return;
            GridViewMeal.CloseEditor();
            TextEditCode.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            bool temp = newRec;
            if (checkForms())
            {
                TextEditCode.Focus();
                setReadOnly(true);
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;

            }

            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (MEALCOD)MealCodBindingSource.Current);
             
    

        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool move()
        {
            GridViewMeal.CloseEditor();
            TextEditCode.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( MEALCOD)MealCodBindingSource.Current);
                setReadOnly(true);
                newRec = false;
                modified = false;
                return true;
            }
            return false;
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (move())
                MealCodBindingSource.MoveFirst();

        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                MealCodBindingSource.MovePrevious();


        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                MealCodBindingSource.MoveNext();

        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                MealCodBindingSource.MoveLast();

        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (MealCodBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (MEALCOD)MealCodBindingSource.Current);

                setReadOnly(true);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (MEALCOD)MealCodBindingSource.Current);
           
                e.Allow = false;
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewMeal.IsFilterRow(e.RowHandle))
                modified = true;
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }

        private void MealCodeForm_FormClosing(object sender, FormClosingEventArgs e)
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
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( MEALCOD)MealCodBindingSource.Current);

            setReadOnly(true);
        }

        private void code_Leave(object sender, EventArgs e)
        {
            if (MealCodBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((MEALCOD)MealCodBindingSource.Current).checkCode, MealCodBindingSource);
            }
        }

        private void dESCTextBox_Leave(object sender, EventArgs e)
        {
            if (MealCodBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((MEALCOD)MealCodBindingSource.Current).checkDesc, MealCodBindingSource);
            }
        }

        private void lONG_DESCTextBox_Leave(object sender, EventArgs e)
        {
            if (MealCodBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((MEALCOD)MealCodBindingSource.Current).checkLongDesc, MealCodBindingSource);
            }
        }

        private void code_Enter(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        private void MealCodeForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewMeal.IsFilterRow(GridViewMeal.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewMeal.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewMeal.GetFocusedDisplayText()))
                value = GridViewMeal.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.CODE like '{0}%'", GridViewMeal.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                var special = context.MEALCOD.Where(query);

                if (!string.IsNullOrWhiteSpace(GridViewMeal.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "DESC")))
                {
                    query = String.Format("it.{0} like '{1}%'", "[DESC]", GridViewMeal.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "DESC"));
                    special = special.Where(query);
                }
               
                int count = special.Count();
                if (count > 0)
                {
                    MealCodBindingSource.DataSource = special;
                    GridViewMeal.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                    GridViewMeal.FocusedRowHandle = 0;
                    GridViewMeal.FocusedColumn.FieldName = colName;
                    GridViewMeal.CollapseAllGroups();
                    GridViewMeal.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewMeal.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void MealCodBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (MealCodBindingSource.Current != null)
                enableNavigator(true);
            else
                enableNavigator(false);
        }


    }
}