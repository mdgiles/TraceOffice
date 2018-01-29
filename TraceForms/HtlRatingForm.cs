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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using FlexModel;
using DevExpress.XtraEditors.Controls;
using System.Linq;
using DevExpress.XtraGrid.Columns;
using System.Runtime.InteropServices;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraEditors.Repository;
using System.Data;
using System.Drawing;
using System.Text;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;

namespace TraceForms
{
    
    public partial class HtlRatingForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        const string colName = "colCODE";
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public  FlextourEntities context;
        public HtlRatingForm(FlexInterfaces.Core.ICoreSys sys)
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
            cODETextBox.Properties.ReadOnly = valid;
            GridViewHtlRating.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = !valid;

        }

        private void setValues()
        {
            GridViewHtlRating.SetFocusedRowCellValue("CODE", string.Empty);
            GridViewHtlRating.SetFocusedRowCellValue("DESCRIP", string.Empty);
            GridViewHtlRating.SetFocusedRowCellValue("Image_Path", string.Empty);
         
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            GridViewHtlRating.ClearColumnsFilter();
            if (HtlRatingBindingSource.Current == null)
            {
                //fake query in order to create a link between the database table and the binding source
                HtlRatingBindingSource.DataSource = from opt in context.HTLRATNG where opt.CODE == "KJM9" select opt;
                HtlRatingBindingSource.AddNew();
                if (GridViewHtlRating.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewHtlRating.FocusedRowHandle = GridViewHtlRating.RowCount - 1;
                setValues();
                cODETextBox.Focus();
                setReadOnly(false);
                newRec = true;
                return;
            }
            cODETextBox.Focus();
            //bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewHtlRating.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( HTLRATNG)HtlRatingBindingSource.Current);
                HtlRatingBindingSource.AddNew();
                if (GridViewHtlRating.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewHtlRating.FocusedRowHandle = GridViewHtlRating.RowCount - 1;
                setValues();
                cODETextBox.Focus();
                setReadOnly(false);
                newRec = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (HtlRatingBindingSource.Current == null)
                return;
            GridViewHtlRating.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                
                modified = false;
                newRec = false;
                HtlRatingBindingSource.RemoveCurrent();
                errorProvider1.Clear();
                context.SaveChanges();
                setReadOnly(true);
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);
               
            }
            currentVal = cODETextBox.Text;
                
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
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((HTLRATNG)HtlRatingBindingSource.Current).checkAll, HtlRatingBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, HtlRatingBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, HtlRatingBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }

        private void hTLRATNGBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

            if (HtlRatingBindingSource.Current == null)
                return;
            GridViewHtlRating.CloseEditor();
            cODETextBox.Focus();
           // bindingNavigatorPositionItem.Focus();//trigger field leave event
            bool temp = newRec;
            if (checkForms())
            {
                cODETextBox.Focus();
                setReadOnly(true);
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
            }

            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (HTLRATNG)HtlRatingBindingSource.Current);
             
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool move()
        {
            GridViewHtlRating.CloseEditor();
            cODETextBox.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( HTLRATNG)HtlRatingBindingSource.Current);
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
                HtlRatingBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                HtlRatingBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                HtlRatingBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                HtlRatingBindingSource.MoveLast();
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {

            if (HtlRatingBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (HTLRATNG)HtlRatingBindingSource.Current);


                setReadOnly(true);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (HTLRATNG)HtlRatingBindingSource.Current);
      
                e.Allow = false;
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewHtlRating.IsFilterRow(e.RowHandle))
                modified = true;
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            temp = newRec;
           if (!temp && checkForms())
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( HTLRATNG)HtlRatingBindingSource.Current);

           setReadOnly(true);
        }

        private void HtlRatingForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void cODETextBox_Enter(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text.ToString();
        }

        private void dESCRIPTextBox_Leave(object sender, EventArgs e)
        {
            if (HtlRatingBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((HTLRATNG)HtlRatingBindingSource.Current).checkDesc, HtlRatingBindingSource);
            }
        }

        private void cODETextBox_Leave(object sender, EventArgs e)
        {
            if (HtlRatingBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((HTLRATNG)HtlRatingBindingSource.Current).checkCode, HtlRatingBindingSource);
            }
           
        }

        private void cODETextBox_TextChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrWhiteSpace(cODETextBox.Text))
            //{
            //    starRating1.changeRating(double.Parse(cODETextBox.Text[0].ToString()));
            //    if (cODETextBox.Text.Contains('+'))
            //        starRating1.changeRating(starRating1.rating + 0.5);
            //}
        }

        private void HtlRatingForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewHtlRating.IsFilterRow(GridViewHtlRating.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewHtlRating.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewHtlRating.GetFocusedDisplayText()))
                value = GridViewHtlRating.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.DESCRIP like '{0}%'", GridViewHtlRating.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "DESCRIP"));
                var special = context.HTLRATNG.Where(query);
                
                if (!string.IsNullOrWhiteSpace(GridViewHtlRating.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE")))
                {
                    query = String.Format("it.{0} like '{1}%'", "CODE", GridViewHtlRating.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                    special = special.Where(query);
                }

                int count = special.Count();
                if (count > 0)
                {
                    HtlRatingBindingSource.DataSource = special;
                    GridViewHtlRating.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                    GridViewHtlRating.FocusedRowHandle = 0;
                    GridViewHtlRating.FocusedColumn.FieldName = colName;
                    GridViewHtlRating.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewHtlRating.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void HtlRatingBindingSource_CurrentChanged(object sender, System.EventArgs e)
        {
            if (HtlRatingBindingSource.Current != null)
                enableNavigator(true);
            else
                enableNavigator(false);
        }

        private void starsSpinEdit_EditValueChanged(object sender, System.EventArgs e)
        {
            starRating1.changeRating(Convert.ToDouble(starsSpinEdit.Value));
        }

        private void starRating1_MouseLeave(object sender, System.EventArgs e)
        {
            starsSpinEdit.Value = Convert.ToDecimal(starRating1.rating);
        }

        private void starRating1_Leave(object sender, System.EventArgs e)
        {
            starsSpinEdit.Value = Convert.ToDecimal(starRating1.rating);
        }

        private void starsSpinEdit_Leave(object sender, System.EventArgs e)
        {
            if (HtlRatingBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
             
            }
            validCheck.check(sender, errorProvider1, ((HTLRATNG)HtlRatingBindingSource.Current).checkStars, HtlRatingBindingSource);
           
        }

     
    }
}