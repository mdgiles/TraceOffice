using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
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
    
    public partial class PackageTypeForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public bool temp = false;

        const string colName = "colCODE";
        public  FlextourEntities context;
        public PackageTypeForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);
            setReadOnly(true);
        }

       

        private void setReadOnly(bool value)
        {
            TextEditCode.Properties.ReadOnly = value;
            GridViewPackType.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = !value;
        }

        private bool checkForms()
        {
            if (!modified && !newRec)
                return true;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((PACKTYPE)PackTypeBindingSource.Current).checkAll, PackTypeBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, PackTypeBindingSource, base.Name, errorProvider1, base.Cursor);
            else
            {
				validCheck.saveRec(ref modified, false, ref newRec, context, PackTypeBindingSource, base.Name, errorProvider1, base.Cursor);
                return false;
            }
        }

       
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }

        private void pACKTYPEBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
               
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }


        private bool move()
        {
            GridViewPackType.CloseEditor();
            TextEditCode.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( PACKTYPE)PackTypeBindingSource.Current);
                setReadOnly(true);
                newRec = false;
                modified = false;
                return true;
            }
            return false;
        }


        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (PackTypeBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (PACKTYPE)PackTypeBindingSource.Current);

                setReadOnly(true);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (PACKTYPE)PackTypeBindingSource.Current);
           
                e.Allow = false;
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewPackType.IsFilterRow(e.RowHandle))
                modified = true;
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            //temp = newRec;
            //if (!temp && checkForms())
            //    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( PACKTYPE)PackTypeBindingSource.Current);

            //setReadOnly(true);
        }

        private void PackageTypeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (modified || newRec)
            {
				DialogResult select = DevExpress.XtraEditors.XtraMessageBox.Show("There are unsaved changes. Are you sure want to exit?", base.Name, MessageBoxButtons.YesNo);
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


        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text.ToString();
        }

        private void code_Leave(object sender, EventArgs e)
        {
            if (PackTypeBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((PACKTYPE)PackTypeBindingSource.Current).checkCode, PackTypeBindingSource);
            }
           
        }

        private void DescTextBox_Leave(object sender, EventArgs e)
        {
            if (PackTypeBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((PACKTYPE)PackTypeBindingSource.Current).checkDesc, PackTypeBindingSource);
            }
        }

        private void PackageTypeForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewPackType.IsFilterRow(GridViewPackType.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewPackType.FocusedColumn.FieldName;
            string value = String.Empty;

            if (!string.IsNullOrWhiteSpace(GridViewPackType.GetFocusedDisplayText()))
                value = GridViewPackType.GetFocusedDisplayText();

            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.CODE like '{0}%'", GridViewPackType.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                var special = context.PACKTYPE.Where(query);

                if (!string.IsNullOrWhiteSpace(GridViewPackType.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "DESC")))
                {
                    query = String.Format("it.{0} like '{1}%'", "[DESC]", GridViewPackType.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "DESC"));
                    special = special.Where(query);
                }

                int count = special.Count();
                if (count > 0)
                {
                    PackTypeBindingSource.DataSource = special;
                    GridViewPackType.FocusedRowHandle = 0;
                    GridViewPackType.FocusedColumn.FieldName = colName;
                    GridViewPackType.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewPackType.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void PackTypeBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            
        }

		private void barButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			GridViewPackType.ClearColumnsFilter();
			if (PackTypeBindingSource.Current == null)
			{
				PackTypeBindingSource.DataSource = from opt in context.PACKTYPE where opt.CODE == "KJM9" select opt;
				PackTypeBindingSource.AddNew();
				if (GridViewPackType.FocusedRowHandle == GridControl.AutoFilterRowHandle)
					GridViewPackType.FocusedRowHandle = GridViewPackType.RowCount - 1;
				TextEditCode.Focus();
				setReadOnly(false);
				newRec = true;
				return;
			}
			TextEditCode.Focus();
			//bindingNavigatorPositionItem.Focus();  //trigger field leave event
			GridViewPackType.CloseEditor();
			temp = newRec;
			if (checkForms())
			{
				if (!temp)
					context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (PACKTYPE)PackTypeBindingSource.Current);
				PackTypeBindingSource.AddNew();
				if (GridViewPackType.FocusedRowHandle == GridControl.AutoFilterRowHandle)
					GridViewPackType.FocusedRowHandle = GridViewPackType.RowCount - 1;
				TextEditCode.Focus();
				setReadOnly(false);
				newRec = true;
			}

		}

		private void barButtonItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (PackTypeBindingSource.Current == null)
				return;
			GridViewPackType.CloseEditor();
			if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				modified = false;
				newRec = false;
				PackTypeBindingSource.RemoveCurrent();
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
			currentVal = TextEditCode.Text;

		}

		private void barButtonItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (PackTypeBindingSource.Current == null)
				return;

			GridViewPackType.CloseEditor();
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
				context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (PACKTYPE)PackTypeBindingSource.Current);

		}
	}
}