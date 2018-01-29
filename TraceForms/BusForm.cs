using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using FlexModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TraceForms
{
   
    public partial class BusForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
		public bool ignoreLeaveRow = false, ignorePositionChange = false;
        const string keyColName = "colID";
        public FlextourEntities context;
        public string username;
        public Timer actionConfirmation;
		public Bus _selectedRecord;

        public BusForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
			LoadLookups();
        }

		void LoadLookups()
		{
            bindingNavigator.BackColor = BackColor;     //match the DevExpress style
            setReadOnly(true);
			enableNavigator(false);

		}

        void enableNavigator(bool value)
        {
			bindingNavigatorMoveNextItem.Enabled = value;
			bindingNavigatorMoveLastItem.Enabled = value;
			bindingNavigatorMoveFirstItem.Enabled = value;
			bindingNavigatorMovePreviousItem.Enabled = value;
			bindingNavigatorDeleteItem.Enabled = value;
			bindingNavigatorSaveItem.Enabled = value;
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);
            username = sys.User.Name;
        }

		void setReadOnly(bool value)
		{
			foreach (Control control in splitContainerControl.Panel2.Controls) {
				control.Enabled = !value;
			}
		}

		private bool SaveRecord(bool prompt)
		{
			try {
				if (_selectedRecord == null) return true;

                //Call to make sure the modified flag is set, because the Save button doesn't take focus so the Leave event
                //won't fire on the active control
                SetErrorInfo(null, ActiveControl);

                if (modified || newRec) {
                    if (prompt) {
                        DialogResult result = DevExpress.XtraEditors.XtraMessageBox.Show("Do you want to confirm these changes?", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (result == System.Windows.Forms.DialogResult.No) {
                            if (newRec) {
                                RemoveRecord();
                            }
                            else {
                                RefreshRecord();
                            }
                            modified = false;
                            newRec = false;
                            return true;
                        }
                        if (result == System.Windows.Forms.DialogResult.Cancel) {
                            return false;
                        }
                    }
                    FinalizeBindings();
                    ValidateAll();

                    if (_selectedRecord.ID == 0) {
                        context.Bus.AddObject(_selectedRecord);
                    }
                    context.SaveChanges();
                    ShowActionConfirmation("Record Saved");
                    newRec = false;
                    modified = false;
                }

                return true;
			}
			catch (Exception ex) {
				string message = ex.Message;
				if (message.Contains("inner exception")) {
					message = ex.InnerException.Message;
				}
				XtraMessageBox.Show(message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				RefreshRecord();		//pull it back from db because that is its current state
				//We must also Load and rebind the related entities from the db because context.Refresh doesn't do that
				SetBindings();
				return false;
			}
		}

		private void FinalizeBindings()
		{
			bindingSource.EndEdit();
		}

		private void ValidateAll()
		{
			if (!_selectedRecord.Validate()) {
				if (_selectedRecord.Errors.ContainsKey("ID")) {
					//Errors attached to the ID property are non-field specific, eg a duplicate record, so
					//just show an error message without setting an error icon on a field.
					throw new Exception(_selectedRecord.Errors["ID"]);
				}
				else {
					ValidateMainControls();
					throw new Exception("Errors were found. Please resolve them and try again.");
				}
			}
			else {
				errorProvider1.Clear();
			}
		}

		private void ValidateMainControls()
		{
			//Errors on the main form must be set manually
			SetErrorInfo(_selectedRecord.ValidateName, textEditName);
		}

		private void RefreshRecord()
		{
			if (_selectedRecord != null && _selectedRecord.ID != 0) {
				context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, _selectedRecord);
			}
		}

		private void RemoveRecord()
		{
			bindingSource.RemoveCurrent();
		}

		private void ShowActionConfirmation(string confirmation)
		{
			panelControlStatus.Visible = true;
			LabelStatus.Text = confirmation;
			actionConfirmation = new Timer();
			actionConfirmation.Interval = 3000;
			actionConfirmation.Start();
			actionConfirmation.Tick += TimedEvent;
		}

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            ignoreLeaveRow = true;       //so that when the grid row changes it doesn't try to save again
            if (SaveRecord(true)) {
				gridViewLookup.ClearColumnsFilter();
				newRec = true;
				bindingSource.AddNew();
				//if (GridViewRoute.FocusedRowHandle == GridControl.AutoFilterRowHandle)
				gridViewLookup.FocusedRowHandle = gridViewLookup.RowCount - 1;
				textEditName.Focus();
				setReadOnly(false);
			}
            ignoreLeaveRow = false;
        }

        private void DeleteRecord()
		{
			if (_selectedRecord == null) return;

			try {
				if (XtraMessageBox.Show("Are you sure you want to delete this record?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
					ignoreLeaveRow = true;
					ignorePositionChange = true;
					RemoveRecord();
					errorProvider1.Clear();
					if (!newRec) {
						//Apparently a record which has just been added is not flagged for deletion by BindingSource.RemoveCurrent,
						//(the EntityState remains unchanged).  It seems like it is not tracked by the context even though it is, because
						//the EntityState changes for modification. So if this is a deletion and the entity is not flagged for deletion, 
						//delete it manually.
						if (_selectedRecord != null && (_selectedRecord.EntityState & EntityState.Deleted) != EntityState.Deleted)
							context.Bus.DeleteObject(_selectedRecord);
						context.SaveChanges();
					}
					ignoreLeaveRow = false;
					ignorePositionChange = false;
					modified = false;
					newRec = false;
					if (gridViewLookup.RowCount == 0) {
						ClearBindings();
					}
					SetBindings();
					ShowActionConfirmation("Record Deleted");
				}
				currentVal = textEditName.Text;
			}
			catch (Exception ex) {
				string message = ex.Message;
				if (message.Contains("inner exception")) {
					message = ex.InnerException.Message;
				}
				XtraMessageBox.Show(message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				RefreshRecord();		//pull it back from db because that is it's current state
				//We must also Load and rebind the related entities from the db because context.Refresh doesn't do that
				SetBindings();
			}
		}

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
			DeleteRecord();
        }

        private void TimedEvent(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            actionConfirmation.Stop();
        }

        private void BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
			if (SaveRecord(false))
				RefreshRecord();
		}

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord(true))
                bindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord(true))
                bindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord(true))
                bindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord(true))
                bindingSource.MoveLast();
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
			//temp = newRec;
			//if (!temp && checkForms())
			//	context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (Bus)RouteBindingSource.Current);
            //setReadOnly(true);
        }

        private void BusForm_FormClosing(object sender, FormClosingEventArgs e)
        {
			if (modified || newRec) {
				DialogResult select = DevExpress.XtraEditors.XtraMessageBox.Show("There are unsaved changes. Are you sure want to exit?", Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (select == DialogResult.Yes) {
					e.Cancel = false;
					this.Dispose();
				}
				else if (select == DialogResult.No)
					e.Cancel = true;
			}
			else {
				e.Cancel = false;
				this.Dispose();
			}
        }

        private void enterControl(object sender, EventArgs e)
        {
			if (sender.GetType() == typeof(CheckEdit)) {
				currentVal = ((CheckEdit)sender).Checked.ToString();
			}
			else {
				currentVal = ((Control)sender).Text;
			}
        }

        private void BusForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && gridViewLookup.IsFilterRow(gridViewLookup.FocusedRowHandle))
            {
                executeQuery();
				e.Handled = true;
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = gridViewLookup.FocusedColumn.FieldName;
            string value = String.Empty;
			value = gridViewLookup.GetFocusedDisplayText();
			string query = "1=1";
			if (!string.IsNullOrEmpty(gridViewLookup.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Name"))) {
				query = String.Format(" and it.Name like '%{0}%'", gridViewLookup.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Name"));
			}
			var special = context.Bus.Where(query);
               
            int count = special.Count();
            if (count > 0)
            {
                bindingSource.DataSource = special;
                gridViewLookup.ClearColumnsFilter();
            }
            else
            {
				ClearBindings();
				XtraMessageBox.Show("No matching records found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Cursor = Cursors.Default; 
        }

		void ClearBindings()
		{
			bindingSource.DataSource = typeof(Bus);
		}

		void SetBindings()
		{
			//If the route list is filtered, there will be rows in the binding source
			//that are not visible, and they can become selected if the last visible row
			//is deleted, so handle that by checking rowcount.
			if (bindingSource.Current == null) {
				_selectedRecord = null;
				enableNavigator(false);
				setReadOnly(true);
			}
			else {
				_selectedRecord = ((Bus)bindingSource.Current);
				enableNavigator(true);
				setReadOnly(false);
			}
		}

		private void BusForm_Shown(object sender, EventArgs e)
		{
			gridViewLookup.FocusedRowHandle = DevExpress.Data.CurrencyDataController.FilterRow;
			gridControlLookup.Focus();
		}

		private void SetErrorInfo(Func<String> validationMethod, object sender)
		{
            bindingSource.EndEdit();		//force changes back into context for validation
            if (sender != null && sender != gridControlLookup) {
                if (sender.GetType() == typeof(CheckEdit)) {
                    if (currentVal != ((CheckEdit)sender).Checked.ToString()) {
                        modified = true;
                    }
                }
                else {
                    if (currentVal != ((Control)sender).Text) {
                        modified = true;
                    }
                }
                //Put this here to save the current value of the control into currentVal in the cases
                //where this event was fired without a new control gaining focus, ie when the Save
                //button is clicked, otherwise when the focus changes later on, it will prompt to 
                //save again.
                enterControl(sender, new EventArgs());
            }
			if (validationMethod != null) {
				string error = validationMethod.Invoke();
				errorProvider1.SetError((Control)sender, error);
			}
		}

		private void checkEditInService_Leave(object sender, EventArgs e)
		{
			if (_selectedRecord != null)
				SetErrorInfo(null, sender);
		}

		private void gridViewLookup_BeforeLeaveRow(object sender, RowAllowEventArgs e)
		{
			//If the user selects a row, edits, then selects the auto-filter row, then selects a different row,
			//this event will fire for the auto-filter row, so we cannot ignore it because there is still a record
			//that may need to be saved. 
			if (!ignoreLeaveRow && _selectedRecord != null && (modified || newRec)) {
				e.Allow = SaveRecord(true);
			}
		}

		private void gridViewLookup_ColumnFilterChanged(object sender, EventArgs e)
		{
			if (gridViewLookup.DataRowCount == 0) {
				ClearBindings();
			}
		}

		private void gridViewLookup_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
		{
			e.ExceptionMode = ExceptionMode.NoAction;
		}

        private void textEditName_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateName, sender);
        }

        private void textEditFleetMgmtID_Leave(object sender, EventArgs e)
        {

        }

        private void textEditFleetMgmtIPAddress_Leave(object sender, EventArgs e)
        {

        }

        private void BindingSource_CurrentChanged(object sender, EventArgs e)
		{
			//If the current record is changing as a result of removing a record to delete it, and it is the last
			//record in the table, then SetBindings will clear the bindings, which will cause the delete
			//to fail because the associated entities will become detached when their BindingSources are cleared.
			//Thus we have a flag which is set in that case to ignore this event.
			if (!ignorePositionChange)
				SetBindings();
		}

		private void spinEditCapacity_Leave(object sender, EventArgs e)
		{

		}

    }
}
