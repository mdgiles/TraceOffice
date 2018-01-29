using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FlexModel;
using DevExpress.XtraEditors.Controls;
using System.Runtime.InteropServices;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraEditors.Repository;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraGrid;

namespace TraceForms
{
    
    public partial class RoomCategoriesForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool createNew;
        public bool modified = false;
        public bool newRec = false;
        public bool addNew = false;
        public bool temp = false;
        public bool refresh = false;
        public bool cancelled = false;
        const string colName = "colCODE";
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public  FlextourEntities context;
        public RoomCategoriesForm(FlexInterfaces.Core.ICoreSys sys)
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

        private void setReadOnly(bool value)
        {
            codeTextEdit.Properties.ReadOnly = value;
            GridViewRoomCod.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = !value;
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

        private void setValues()
        {
            GridViewRoomCod.SetFocusedRowCellValue("CODE", string.Empty);
            GridViewRoomCod.SetFocusedRowCellValue("DESC", string.Empty);
            GridViewRoomCod.SetFocusedRowCellValue("Inhouse", false);
            GridViewRoomCod.SetFocusedRowCellValue("LongDesc", string.Empty);
        }

        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        private bool checkForms()
        {
            if (!modified && !newRec)
                return true;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((ROOMCOD)RoomCodBindingSource.Current).checkAll, RoomCodBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, RoomCodBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, RoomCodBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            GridViewRoomCod.ClearColumnsFilter();
            if (RoomCodBindingSource.Current == null)
            {
                //fake query in order to create a link between the database table and the binding source
                RoomCodBindingSource.DataSource = from opt in context.ROOMCOD where opt.CODE == "KJM9" select opt;
                RoomCodBindingSource.AddNew();
                if (GridViewRoomCod.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewRoomCod.FocusedRowHandle = GridViewRoomCod.RowCount - 1;
                codeTextEdit.Focus();
                setReadOnly(false);
                setValues();
                newRec = true;
                return;
            }
            codeTextEdit.Focus();
            //bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewRoomCod.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( ROOMCOD)RoomCodBindingSource.Current);
                RoomCodBindingSource.AddNew();
                if (GridViewRoomCod.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewRoomCod.FocusedRowHandle = GridViewRoomCod.RowCount - 1;
                codeTextEdit.Focus();
                setReadOnly(false);
                setValues();
                newRec = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (RoomCodBindingSource.Current == null)
                return;
            GridViewRoomCod.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                modified = false;
                newRec = false;
                RoomCodBindingSource.RemoveCurrent();
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
            currentVal = codeTextEdit.Text;
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }

        private void rOOMCODBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (RoomCodBindingSource.Current == null)
                return;

            GridViewRoomCod.CloseEditor();
            codeTextEdit.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            bool temp = newRec;
            if (checkForms())
            {
                codeTextEdit.Focus();
                setReadOnly(true);
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
            }

            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (ROOMCOD)RoomCodBindingSource.Current);

        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }


        private bool move()
        {
            GridViewRoomCod.CloseEditor();
            codeTextEdit.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( ROOMCOD)RoomCodBindingSource.Current);
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
                RoomCodBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                RoomCodBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                RoomCodBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                RoomCodBindingSource.MoveLast();
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {

            if (RoomCodBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (ROOMCOD)RoomCodBindingSource.Current);

                setReadOnly(true);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (ROOMCOD)RoomCodBindingSource.Current);

                e.Allow = false;
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewRoomCod.IsFilterRow(e.RowHandle))
                modified = true;
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; 
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            temp = newRec;
            if (!temp && checkForms())
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( ROOMCOD)RoomCodBindingSource.Current);

            setReadOnly(true);
        }

        private void RoomCategoriesForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void codeTextEdit_Leave(object sender, EventArgs e)
        {
            if (RoomCodBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((ROOMCOD)RoomCodBindingSource.Current).checkCode, RoomCodBindingSource);
            }
        }

        private void dESCTextBox_Leave(object sender, EventArgs e)
        {
            if (RoomCodBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((ROOMCOD)RoomCodBindingSource.Current).checkDesc, RoomCodBindingSource);
            }
        }

        private void longDescTextBox_Leave(object sender, EventArgs e)
        {
            if (RoomCodBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((ROOMCOD)RoomCodBindingSource.Current).checkLongDesc, RoomCodBindingSource);
            }
        }

        private void RoomCategoriesForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewRoomCod.IsFilterRow(GridViewRoomCod.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewRoomCod.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewRoomCod.GetFocusedDisplayText()))
                value = GridViewRoomCod.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.CODE like '{0}%'", GridViewRoomCod.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                var special = context.ROOMCOD.Where(query);

                if (!string.IsNullOrWhiteSpace(GridViewRoomCod.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "DESC")))
                {
                    query = String.Format("it.{0} like '{1}%'", "[DESC]", GridViewRoomCod.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "DESC"));
                    special = special.Where(query);
                }
               
                int count = special.Count();
                if (count > 0)
                {
                    RoomCodBindingSource.DataSource = special;
                    GridViewRoomCod.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                    GridViewRoomCod.FocusedRowHandle = 0;
                    GridViewRoomCod.FocusedColumn.FieldName = colName;
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewRoomCod.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void RoomCodBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (RoomCodBindingSource.Current != null)
                enableNavigator(true);
            else
                enableNavigator(false);
        }

        private void inhouseCheckEdit_Click(object sender, EventArgs e)
        {
            modified = true;
        }

     






    }
}