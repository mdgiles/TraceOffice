using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;
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
    
    public partial class StateForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        const string colName = "colCode";
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public  FlextourEntities context;
        public StateForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
            LoadLookups();


           
            //gsLoad.gridSearchLoad(countrySearch, "CODE", "NAME", "Code", "Name", "NAME", "CODE", "NAME", StateBindingSource, "Country");
            //gsLoad.gridSearchLoad(regionSearch, "CODE", "DESC", "Code", "Description", "DESC", "CODE", "DESC", StateBindingSource, "Region");
            //countrySearch.GridControl.DataSource = context.COUNTRY;
            //regionSearch.GridControl.DataSource = from c in context.REGION select new { c.CODE, c.DESC };
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);
        }

        private void setReadOnly(bool value)
        {
            TextEditCode.Properties.ReadOnly = value;
            GridViewState.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = !value;
        }

        private void LoadLookups()
        {
            setReadOnly(true);
            var region = from stateRec in context.REGION orderby stateRec.CODE ascending select new { stateRec.CODE, stateRec.DESC };
            var count = from countryRec in context.COUNTRY orderby countryRec.CODE ascending select new { countryRec.CODE, countryRec.NAME };
           
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxEditRegion.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCountry.Properties.Items.Add(loadBlank);
          
            foreach (var result in region)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.DESC.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditRegion.Properties.Items.Add(load);
            }
            foreach (var result in count)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCountry.Properties.Items.Add(load);

            }
            
            
        }

        

        private void setValues()
        {
            GridViewState.SetFocusedRowCellValue("Code", string.Empty);
            GridViewState.SetFocusedRowCellValue("State1", string.Empty);
            GridViewState.SetFocusedRowCellValue("Country", string.Empty);
            GridViewState.SetFocusedRowCellValue("Region", string.Empty);
            GridViewState.SetFocusedRowCellValue("Group", string.Empty);           
        }

        private bool checkForms()
        {
            if (!modified && !newRec)
                return true;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((State)StateBindingSource.Current).checkAll, StateBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, StateBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, StateBindingSource, Name, errorProvider1, Cursor);
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

        private void stateBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool move()
        {
            GridViewState.CloseEditor();
            TextEditCode.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( State)StateBindingSource.Current);
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
                StateBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                StateBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                StateBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                StateBindingSource.MoveLast();
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {            
            if (StateBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (State)StateBindingSource.Current);

                setReadOnly(true);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (State)StateBindingSource.Current);
          
                e.Allow = false;
            }
        }

     
        void ButtonEdit_QueryPopUp1(object sender, CancelEventArgs e)
        {
            e.Cancel = false;           
        }

        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewState.IsFilterRow(e.RowHandle))
                modified = true;
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }

        private void stateForm_FormClosing(object sender, FormClosingEventArgs e)
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
            //temp = newRec;
            //if (!temp && checkForms())
            //    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( State)StateBindingSource.Current);

            //setReadOnly(true);
        }

     
        private void codeTextEdit_Leave(object sender, EventArgs e)
        {
            if (StateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((State)StateBindingSource.Current).checkCode, StateBindingSource);
            }
           
        }

        private void state1TextBox_Leave(object sender, EventArgs e)
        {
            if (StateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((State)StateBindingSource.Current).checkState, StateBindingSource);
            }
        }               

        private void groupTextBox_Leave(object sender, EventArgs e)
        {
            if (StateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((State)StateBindingSource.Current).checkGroup, StateBindingSource);
            }
        }

        private void StateForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewState.IsFilterRow(GridViewState.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewState.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewState.GetFocusedDisplayText()))
                value = GridViewState.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.Code like '{0}%'", GridViewState.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Code"));
                var special = context.State.Where(query);


                if (!string.IsNullOrWhiteSpace(GridViewState.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "State1")))
                {
                    query = String.Format("it.{0} like '{1}%'", "State1", GridViewState.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "State1"));
                    special = special.Where(query);
                }
                int count = special.Count();
                if (count > 0)
                {
                    StateBindingSource.DataSource = special;
                    GridViewState.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                    GridViewState.FocusedRowHandle = 0;
                    GridViewState.FocusedColumn.FieldName = colName;
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewState.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void ImageComboBoxEditRegion_Leave(object sender, System.EventArgs e)
        {
            if (StateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((State)StateBindingSource.Current).checkRegion, StateBindingSource);
            }
        }

        private void ImageComboBoxEditCountry_Leave(object sender, System.EventArgs e)
        {
            if (StateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((State)StateBindingSource.Current).checkCountry, StateBindingSource);
            }
        }

        private void StateBindingSource_CurrentChanged(object sender, System.EventArgs e)
        {
            
        }

		private void barButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			GridViewState.ClearColumnsFilter();
			if (StateBindingSource.Current == null)
			{
				//fake query in order to create a link between the database table and the binding source
				StateBindingSource.DataSource = from opt in context.State where opt.Code == "KJM9" select opt;
				StateBindingSource.AddNew();
				if (GridViewState.FocusedRowHandle == GridControl.AutoFilterRowHandle)
					GridViewState.FocusedRowHandle = GridViewState.RowCount - 1;
				TextEditCode.Focus();
				setReadOnly(false);
				newRec = true;
				return;
			}
			TextEditCode.Focus();
			//bindingNavigatorPositionItem.Focus();  //trigger field leave event
			GridViewState.CloseEditor();
			temp = newRec;
			if (checkForms())
			{
				if (!temp)
					context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (State)StateBindingSource.Current);
				StateBindingSource.AddNew();
				if (GridViewState.FocusedRowHandle == GridControl.AutoFilterRowHandle)
					GridViewState.FocusedRowHandle = GridViewState.RowCount - 1;
				TextEditCode.Focus();
				setReadOnly(false);
				newRec = true;
			}

		}

		private void barButtonItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (StateBindingSource.Current == null)
				return;
			GridViewState.CloseEditor();
			if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				modified = false;
				newRec = false;
				StateBindingSource.RemoveCurrent();
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
			if (StateBindingSource.Current == null)
				return;

			GridViewState.CloseEditor();
			TextEditCode.Focus();
			bool temp = newRec;
			//bindingNavigatorPositionItem.Focus();//trigger field leave event
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
				context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (State)StateBindingSource.Current);


		}
	}

}