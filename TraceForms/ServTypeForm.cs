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
    
    public partial class ServTypeForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
      
        public bool temp = false;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        const string colName = "colTYPE";
        public  FlextourEntities context;
        public ServTypeForm(FlexInterfaces.Core.ICoreSys sys)
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
            TextEditType.Properties.ReadOnly = value;
            GridViewServType.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = !value;           
        }

        private void LoadLookups()
        {
            setReadOnly(true);           
        }

        private void setValues()
        {
            GridViewServType.SetFocusedRowCellValue("TYPE", string.Empty);
            GridViewServType.SetFocusedRowCellValue("DESCRIP", string.Empty);
            GridViewServType.SetFocusedRowCellValue("LINKTYPE", string.Empty);
          
        }

      
        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text.ToString();
        }

        private bool checkForms()
        {
            if (!modified && !newRec)
                return true;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((SERVTYPE)ServTypeBindingSource.Current).checkAll, ServTypeBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, ServTypeBindingSource, base.Name, errorProvider1, base.Cursor);
            else
            {
				validCheck.saveRec(ref modified, false, ref newRec, context, ServTypeBindingSource, base.Name, errorProvider1, base.Cursor);
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

        private void sERVTYPEBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
              
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }


        private bool move()
        {
            GridViewServType.CloseEditor();
            TextEditType.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( SERVTYPE)ServTypeBindingSource.Current);
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
                ServTypeBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                ServTypeBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                ServTypeBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                ServTypeBindingSource.MoveLast();
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (ServTypeBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (SERVTYPE)ServTypeBindingSource.Current);

                setReadOnly(true);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (SERVTYPE)ServTypeBindingSource.Current);
            
                e.Allow = false;
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewServType.IsFilterRow(e.RowHandle))
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
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( SERVTYPE)ServTypeBindingSource.Current);

            setReadOnly(true);
        }

        private void ServTypeForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void type_Leave(object sender, EventArgs e)
        {
            if (ServTypeBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((SERVTYPE)ServTypeBindingSource.Current).checkType, ServTypeBindingSource);
            }
           
        }

        private void dESCRIPTextBox_Leave(object sender, EventArgs e)
        {
            if (ServTypeBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((SERVTYPE)ServTypeBindingSource.Current).checkDesc, ServTypeBindingSource);
            }
        }

        private void ServTypeForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewServType.IsFilterRow(GridViewServType.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewServType.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewServType.GetFocusedDisplayText()))
                value = GridViewServType.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.TYPE like '{0}%'", GridViewServType.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "TYPE"));
                var special = context.SERVTYPE.Where(query);

               
                if (!string.IsNullOrWhiteSpace(GridViewServType.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "DESCRIP")))
                {
                    query = String.Format("it.{0} like '{1}%'", "DESCRIP", GridViewServType.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "DESCRIP"));
                    special = special.Where(query);
                }
                int count = special.Count();
                if (count > 0)
                {
                    ServTypeBindingSource.DataSource = special;
                    GridViewServType.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                    GridViewServType.FocusedRowHandle = 0;
                    GridViewServType.FocusedColumn.FieldName = colName;
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewServType.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void ServTypeBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            
        }

		private void barButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			GridViewServType.ClearColumnsFilter();
			if (ServTypeBindingSource.Current == null)
			{
				//fake query in order to create a link between the database table and the binding source
				ServTypeBindingSource.DataSource = from opt in context.SERVTYPE where opt.TYPE == "KJM9" select opt;
				ServTypeBindingSource.AddNew();
				if (GridViewServType.FocusedRowHandle == GridControl.AutoFilterRowHandle)
					GridViewServType.FocusedRowHandle = GridViewServType.RowCount - 1;
				setValues();
				TextEditType.Focus();
				setReadOnly(false);
				newRec = true;
				return;
			}
			TextEditType.Focus();
			//bindingNavigatorPositionItem.Focus();  //trigger field leave event
			GridViewServType.CloseEditor();
			temp = newRec;
			if (checkForms())
			{
				if (!temp)
					context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (SERVTYPE)ServTypeBindingSource.Current);
				ServTypeBindingSource.AddNew();
				if (GridViewServType.FocusedRowHandle == GridControl.AutoFilterRowHandle)
					GridViewServType.FocusedRowHandle = GridViewServType.RowCount - 1;
				setValues();
				TextEditType.Focus();
				setReadOnly(false);
				newRec = true;
			}

		}

		private void barButtonItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (ServTypeBindingSource.Current == null)
				return;
			GridViewServType.CloseEditor();
			if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{

				modified = false;
				newRec = false;
				ServTypeBindingSource.RemoveCurrent();
				errorProvider1.Clear();
				context.SaveChanges();
				setReadOnly(true);
				panelControlStatus.Visible = true;
				LabelStatus.Text = "Record Deleted";
				rowStatusDelete = new Timer();
				rowStatusDelete.Interval = 3000;
				rowStatusDelete.Start();
				rowStatusDelete.Tick += new EventHandler(TimedEventDelete);
				//bindingNavigatorPositionItem.Focus();

			}
			currentVal = TextEditType.Text;

		}

		private void barButtonItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (ServTypeBindingSource.Current == null)
				return;

			GridViewServType.CloseEditor();
			TextEditType.Focus();
			bool temp = newRec;
			// bindingNavigatorPositionItem.Focus();//trigger field leave event
			if (checkForms())
			{
				TextEditType.Focus();
				setReadOnly(true);
				panelControlStatus.Visible = true;
				LabelStatus.Text = "Record Saved";
				rowStatusSave = new Timer();
				rowStatusSave.Interval = 3000;
				rowStatusSave.Start();
				rowStatusSave.Tick += TimedEventSave;
			}

			if (!temp && !modified)
				context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (SERVTYPE)ServTypeBindingSource.Current);

		}
	}
}