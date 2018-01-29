using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraEditors;
using FlexModel;
using DevExpress.XtraEditors.Controls;
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
    
    public partial class RegionForm : DevExpress.XtraEditors.XtraForm
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
        public FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public RegionForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
           
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);
        }

        private void setValues()
        {
            GridViewRegion.SetFocusedRowCellValue("CODE", string.Empty);
            GridViewRegion.SetFocusedRowCellValue("DESC", string.Empty);
           
        }

        private void setReadOnly(bool value)
        {
            textEditCode.Properties.ReadOnly = value;
            GridViewRegion.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = !value;
        }

        private bool checkForms()
        {
            if (!modified && !newRec)
                return true;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider, ((REGION)RegionBindingSource.Current).checkAll, RegionBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, RegionBindingSource, Name, errorProvider, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, RegionBindingSource, Name, errorProvider, Cursor);
                return false;
            }
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool move()
        {
            GridViewRegion.CloseEditor();
            textEditCode.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( REGION)RegionBindingSource.Current);
                setReadOnly(true);
                newRec = false;
                modified = false;
                return true;
            }
            return false;
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (RegionBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (REGION)RegionBindingSource.Current);


                setReadOnly(true);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (REGION)RegionBindingSource.Current);
          
                e.Allow = false;
            }
        }

        private void REGIONForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewRegion.IsFilterRow(e.RowHandle))
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
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( REGION)RegionBindingSource.Current);

            setReadOnly(true);
        }

        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text.ToString();
        }

        private void codeTextBox_Leave(object sender, EventArgs e)
        {
            if (RegionBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider, ((REGION)RegionBindingSource.Current).checkCode, RegionBindingSource);
            }
           
        }

        private void dESCTextBox_Leave(object sender, EventArgs e)
        {
            if (RegionBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider, ((REGION)RegionBindingSource.Current).checkDesc, RegionBindingSource);
            }
        }

        private void RegionForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewRegion.IsFilterRow(GridViewRegion.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewRegion.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewRegion.GetFocusedDisplayText()))
                value = GridViewRegion.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.CODE like '{0}%'", GridViewRegion.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                var special = context.REGION.Where(query);

                if (!string.IsNullOrWhiteSpace(GridViewRegion.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "DESC")))
                {
                    query = String.Format("it.{0} like '{1}%'", "[DESC]", GridViewRegion.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "DESC"));
                    special = special.Where(query);
                }
                int count = special.Count();
                if (count > 0)
                {
                    RegionBindingSource.DataSource = special;
                    GridViewRegion.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                    GridViewRegion.FocusedRowHandle = 0;
                    GridViewRegion.FocusedColumn.FieldName = colName;
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewRegion.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void RegionBindingSource_CurrentChanged(object sender, System.EventArgs e)
        {

        }

        private void barButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridViewRegion.ClearColumnsFilter();
            if (RegionBindingSource.Current == null) {
                //fake query in order to create a link between the database table and the binding source
                RegionBindingSource.DataSource = from opt in context.REGION where opt.CODE == "KJM9" select opt;
                RegionBindingSource.AddNew();
                if (GridViewRegion.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewRegion.FocusedRowHandle = GridViewRegion.RowCount - 1;
                setValues();
                textEditCode.Focus();
                setReadOnly(false);
                newRec = true;
                return;
            }
            textEditCode.Focus();
            //bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewRegion.CloseEditor();
            temp = newRec;
            if (checkForms()) {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (REGION)RegionBindingSource.Current);
                RegionBindingSource.AddNew();
                if (GridViewRegion.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewRegion.FocusedRowHandle = GridViewRegion.RowCount - 1;
                setValues();
                textEditCode.Focus();
                setReadOnly(false);
                newRec = true;
            }
        }

        private void barButtonItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (RegionBindingSource.Current == null)
                return;

            GridViewRegion.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                modified = false;
                newRec = false;
                RegionBindingSource.RemoveCurrent();
                errorProvider.Clear();
                context.SaveChanges();
                setReadOnly(true);
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);
            }
            currentVal = textEditCode.Text;
        }

        private void barButtonItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (RegionBindingSource.Current == null)
                return;

            GridViewRegion.CloseEditor();
            textEditCode.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            bool temp = newRec;
            if (checkForms()) {
                textEditCode.Focus();
                setReadOnly(true);
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
            }

            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (REGION)RegionBindingSource.Current);
        }
    }
}