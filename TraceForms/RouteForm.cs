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
   
    public partial class RouteForm : DevExpress.XtraEditors.XtraForm
    {
        public string _currentVal;
        public bool _modified = false, _newRec = false;
		public bool _ignoreLeaveRow = false, _ignorePositionChange = false;
        public FlextourEntities _context;
        public string _username;
        public Timer _actionConfirmation;
		public BusRoute _selectedRecord;
		RepositoryItemImageComboBox _productCombo = new RepositoryItemImageComboBox();
		RepositoryItemImageComboBox _daysCombo = new RepositoryItemImageComboBox();
		Dictionary<String, List<ImageComboBoxItem>> _productLookups;

        public RouteForm(FlexInterfaces.Core.ICoreSys sys)
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

			List<ImageComboBoxItem> daysLookup;
			ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };

			daysLookup = new List<ImageComboBoxItem>();
			daysLookup.Add(new ImageComboBoxItem() { Description = "", Value = (Int16)(-1) });
			daysLookup.Add(new ImageComboBoxItem() { Description = "Sunday", Value = (Int16)0 });
			daysLookup.Add(new ImageComboBoxItem() { Description = "Monday", Value = (Int16)1 });
			daysLookup.Add(new ImageComboBoxItem() { Description = "Tuesday", Value = (Int16)2 });
			daysLookup.Add(new ImageComboBoxItem() { Description = "Wednesday", Value = (Int16)3 });
			daysLookup.Add(new ImageComboBoxItem() { Description = "Thursday", Value = (Int16)4 });
			daysLookup.Add(new ImageComboBoxItem() { Description = "Friday", Value = (Int16)5 });
			daysLookup.Add(new ImageComboBoxItem() { Description = "Saturday", Value = (Int16)6 });
			_daysCombo.Items.AddRange(daysLookup);
			gridControlTimes.RepositoryItems.Add(_daysCombo);		//per DX recommendation to avoid memory leaks

			_productLookups = new Dictionary<String, List<ImageComboBoxItem>>();

			List<ImageComboBoxItem> lookup = new List<ImageComboBoxItem>();
			lookup.Add(loadBlank);
			//EF will try to execute the entire projection on the sql side, which knows nothing about string.format so it will
			//error. Putting AsEnumerable beforehand will tell EF to execute sql side up to there and return results, then the
			//rest will be EF client side
			lookup.AddRange(_context.BusStation.Where(a => (a.GeoCode_ID ?? 0) != 0)
							.OrderBy(o => o.Name).AsEnumerable()
							.Select(s => new ImageComboBoxItem() { Description = $"{s.Code} ({s.Name})", Value = s.Code })
							.ToList());
			_productLookups.Add("BUS", lookup);

			lookup = new List<ImageComboBoxItem>();
			lookup.Add(loadBlank);
			lookup.AddRange(_context.SeaPort.Where(a => (a.GeoCode_ID ?? 0) != 0)
							.OrderBy(o => o.Name).AsEnumerable()
							.Select(s => new ImageComboBoxItem() { Description = $"{s.Code} ({s.Name})", Value = s.Code })
							.ToList());
			_productLookups.Add("CRU", lookup);

			lookup = new List<ImageComboBoxItem>();
			lookup.Add(loadBlank);
			lookup.AddRange(_context.CITYCOD.Where(a => (a.GeoCode_ID ?? 0) != 0)
							.OrderBy(o => o.NAME).AsEnumerable()
							.Select(s => new ImageComboBoxItem() { Description = $"{s.CODE} ({s.NAME})", Value = s.CODE })
							.ToList());
			_productLookups.Add("CTY", lookup);

			lookup = new List<ImageComboBoxItem>();
			lookup.Add(loadBlank);
			lookup.AddRange(_context.HOTEL.Where(a => (a.GeoCode_ID ?? 0) != 0)
							.OrderBy(o => o.NAME).AsEnumerable()
							.Select(s => new ImageComboBoxItem() { Description = $"{s.CODE} ({s.NAME})", Value = s.CODE })
							.ToList());
			_productLookups.Add("HTL", lookup);

			lookup = new List<ImageComboBoxItem>();
			lookup.Add(loadBlank);
			lookup.AddRange(_context.TrainStation.Where(a => (a.GeoCode_ID ?? 0) != 0)
							.OrderBy(o => o.Name).AsEnumerable()
							.Select(s => new ImageComboBoxItem() { Description = $"{s.Code} ({s.Name})", Value = s.Code })
							.ToList());
			_productLookups.Add("TRN", lookup);

			lookup = new List<ImageComboBoxItem>();
			lookup.Add(loadBlank);
			lookup.AddRange(_context.WAYPOINT.Where(a => (a.GeoCode_ID ?? 0) != 0)
							.OrderBy(o => o.DESC).AsEnumerable()
							.Select(s => new ImageComboBoxItem() { Description = $"{s.CODE} ({s.DESC})", Value = s.CODE })
							.ToList());
			_productLookups.Add("WAY", lookup);

			lookup = new List<ImageComboBoxItem>();
			lookup.Add(loadBlank);
			lookup.AddRange(_context.Airport.Where(a => (a.GeoCode_ID ?? 0) != 0)
							.OrderBy(o => o.Name).AsEnumerable()
							.Select(s => new ImageComboBoxItem() { Description = $"{s.Code} ({s.Name})", Value = s.Code })
							.ToList());
			_productLookups.Add("AIR", lookup);

			lookup = new List<ImageComboBoxItem>();
			lookup.Add(loadBlank);
			lookup.AddRange(_context.COMP.Where(a => (a.GeoCode_ID ?? 0) != 0)
							.OrderBy(o => o.NAME).AsEnumerable()
							.Select(s => new ImageComboBoxItem() { Description = $"{s.CODE} ({s.NAME})", Value = s.CODE })
							.ToList());
			_productLookups.Add("OPT", lookup);
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
            _context = new FlextourEntities(sys.Settings.EFConnectionString);
            _username = sys.User.Name;
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

                if (_modified || _newRec) {
                    if (prompt) {
                        DialogResult result = XtraMessageBox.Show("Do you want to confirm these changes?", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.No) {
                            if (_newRec) {
                                RemoveRecord();
                            }
                            else {
                                RefreshRecord();
                            }
                            _modified = false;
                            _newRec = false;
                            return true;
                        }
                        if (result == DialogResult.Cancel) {
                            return false;
                        }
                    }
                    FinalizeBindings();
                    if (!ShowMainControlErrors())
                        return false;

                    if (_selectedRecord.ID == 0) {
                        _context.BusRoute.AddObject(_selectedRecord);
                    }
                    _context.SaveChanges();
                    ShowActionConfirmation("Record Saved");
                    _newRec = false;
                    _modified = false;
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
			//Must end edit before setting MapColour below, because otherwise a NotificationChanged will fire
			//and all editors will refresh, losing the changes in the active editor (others will have posted
			//their changes in their Leave event)
			bindingSource.EndEdit();
			//colour picker is unbound
			_selectedRecord.MapColour = ColorTranslator.ToHtml(colorPickEditMap.Color);
			gridViewStops.CloseEditor();
			gridViewTimes.CloseEditor();
			gridViewStops.UpdateCurrentRow();
			//Set the sequence numbers for the stops to eliminate any gaps caused by deletion
			for (int rowCtr = 0; rowCtr < gridViewStops.DataRowCount; rowCtr++) {
				BusRouteStop busStop = (BusRouteStop)gridViewStops.GetRow(rowCtr);
				busStop.Sequence = rowCtr + 1;
			}
			bindingSourceStops.EndEdit();
			gridViewTimes.UpdateCurrentRow();
			bindingSourceTimes.EndEdit();
		}

		private bool ShowMainControlErrors()
		{
			bool busStopsInvalid = false, busTimesInvalid = false;
			if (bindingSourceStops.List.Count > 0) {
				busStopsInvalid = bindingSourceStops.List.Cast<BusRouteStop>().Any(b => !b.Validate());
			}
			if (bindingSourceTimes.List.Count > 0) {
				busTimesInvalid = bindingSourceTimes.List.Cast<BusDeparture>().Any(b => !b.Validate());
			}

			if (!_selectedRecord.Validate() || busStopsInvalid || busTimesInvalid) {
				ValidateMainControls();
                XtraMessageBox.Show("Errors were found. Please resolve them and try again.", 
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
			}
			else {
				errorProvider1.Clear();
                return true;
			}
		}

		private void ValidateMainControls()
		{
			//The error indicators inside the grids are handled by binding, but errors on the main form must
			//be set manually
			SetErrorInfo(_selectedRecord.ValidateName, textEditName);
			SetErrorInfo(_selectedRecord.ValidateColour, colorPickEditMap);
			SetErrorInfo(_selectedRecord.ValidateDates, dateEditStart);
			SetErrorInfo(_selectedRecord.ValidateDates, dateEditEnd);
			SetErrorInfo(_selectedRecord.ValidateStops, gridControlStops);
			SetErrorInfo(_selectedRecord.ValidateDepartures, gridControlTimes);
		}

		private void RefreshRecord()
		{
			if (_selectedRecord != null && _selectedRecord.ID != 0) {
				_context.Refresh(RefreshMode.StoreWins, _selectedRecord);
			}
		}

		private void RemoveRecord()
		{
			if (_newRec) {
				//If you clear the bindingsource for child records where the parent entity is tracked by
				//the context, it will lose tracking for the child entities and cascade operations like
				//delete will fail
				bindingSourceStops.Clear();
				bindingSourceTimes.Clear();
			}
            //Note that cascade delete must be set on the FK in the db in order for the related
            //entities to be deleted.  This is a db function, not an EF function. However in addition
            //the model must know about the delete, otherwise the relationships in the context will
            //get messed up.  So after adding the cascade rule to the FK, the model must be updated,
            //and in order to refresh a relationship the tables must be deleted and re-added
            //Otherwise, we could do a delete loop
            //If using DbContext instead of ObjectContext, we could do eg
            //_context.BusRouteStop.RemoveRange(_selectedRecord.BusRouteStop)
            bindingSource.RemoveCurrent();
		}

		private void ShowActionConfirmation(string confirmation)
		{
			panelControlStatus.Visible = true;
			LabelStatus.Text = confirmation;
			_actionConfirmation = new Timer();
			_actionConfirmation.Interval = 3000;
			_actionConfirmation.Start();
			_actionConfirmation.Tick += TimedEvent;
		}

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _ignoreLeaveRow = true;       //so that when the grid row changes it doesn't try to save again
            if (SaveRecord(true)) {
				gridViewLookup.ClearColumnsFilter();
				_newRec = true;
				bindingSource.AddNew();
				//if (GridViewRoute.FocusedRowHandle == GridControl.AutoFilterRowHandle)
				gridViewLookup.FocusedRowHandle = gridViewLookup.RowCount - 1;
				textEditName.Focus();
				setReadOnly(false);
			}
            _ignoreLeaveRow = false;
        }

        private void DeleteRecord()
		{
			if (_selectedRecord == null) return;

			try {
				if (XtraMessageBox.Show("Are you sure you want to delete this record?", 
                    Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
					_ignoreLeaveRow = true;
					_ignorePositionChange = true;
					RemoveRecord();
					errorProvider1.Clear();
					if (!_newRec) {
						//Apparently a record which has just been added is not flagged for deletion by BindingSource.RemoveCurrent,
						//(the EntityState remains unchanged).  It seems like it is not tracked by the context even though it is, because
						//the EntityState changes for modification. So if this is a deletion and the entity is not flagged for deletion, 
						//delete it manually.
						if (_selectedRecord != null && (_selectedRecord.EntityState & EntityState.Deleted) != EntityState.Deleted)
							_context.BusRoute.DeleteObject(_selectedRecord);
						_context.SaveChanges();
					}
					_modified = false;
					_newRec = false;
					if (gridViewLookup.DataRowCount == 0) {
						ClearBindings();
					}
                    _ignoreLeaveRow = false;
                    _ignorePositionChange = false;
                    SetBindings();
					ShowActionConfirmation("Record Deleted");
				}
				_currentVal = textEditName.Text;
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
            _actionConfirmation.Stop();
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

        private void gridViewLookup_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
			//If the user selects a row, edits, then selects the auto-filter row, then selects a different row,
			//this event will fire for the auto-filter row, so we cannot ignore it because there is still a record
			//that may need to be saved. 
			if (!_ignoreLeaveRow && _selectedRecord != null && (_modified || _newRec)) {
				e.Allow = SaveRecord(true);
			}
		}

        private void gridViewLookup_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            //We never want users to be able to type in a record position number but the binding navigator
            //has built in behaviour that keeps enabling the position so the only way to prevent editing
            //is to disable it in the Enter event
            bindingNavigatorPositionItem.Enabled = false;
        }

        private void RouteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
			if (_modified || _newRec) {
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
				_currentVal = ((CheckEdit)sender).Checked.ToString();
			}
			else {
				_currentVal = ((Control)sender).Text;
			}
        }

        private void RouteForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && gridViewLookup.IsFilterRow(gridViewLookup.FocusedRowHandle))
            {
                ExecuteQuery();
				e.Handled = true;
            }
        }

        private void ExecuteQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = gridViewLookup.FocusedColumn.FieldName;
            string value = String.Empty;
			value = gridViewLookup.GetFocusedDisplayText();
            string query = String.Format("it.Name like '%{0}%'", gridViewLookup.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Name"));
            var records = _context.BusRoute.Where(query);
               
            if (records.Count() > 0)
            {
                bindingSource.DataSource = records;
                gridViewLookup.ClearColumnsFilter();
            }
            else
            {
				ClearBindings();
				XtraMessageBox.Show("No matching records found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Cursor = Cursors.Default; 
        }

        private void bindingSource_CurrentChanged(object sender, EventArgs e)
        {
			//If the current record is changing as a result of removing a record to delete it, and it is the last
			//record in the table, then SetBindings will clear the bindings, which will cause the delete
			//to fail because the associated entities will become detached when their BindingSources are cleared.
			//Thus we have a flag which is set in that case to ignore this event.
			if (!_ignorePositionChange)
				SetBindings();
        }

		void ClearBindings()
		{
			bindingSource.DataSource = typeof(BusRoute);
		}

		void SetBindings()
		{
			//If the route list is filtered, there will be rows in the binding source
			//that are not visible, and they can become selected if the last visible row
			//is deleted, so handle that by checking rowcount.
			if (bindingSource.Current == null) {
				colorPickEditMap.EditValue = null;
				_selectedRecord = null;
				bindingSourceStops.Clear();
				bindingSourceTimes.Clear();
				enableNavigator(false);
				setReadOnly(true);
			}
			else {
				_selectedRecord = ((BusRoute)bindingSource.Current);
				colorPickEditMap.Color = ColorTranslator.FromHtml(_selectedRecord.MapColour);
				LoadAndBindStops(_selectedRecord.ID);
				LoadAndBindTimes(_selectedRecord.ID);
				enableNavigator(true);
				setReadOnly(false);
			}
		}

		void LoadAndBindStops(int id)
		{
			//Load the related entities. DO NOT do another db query using context.whatever because they
			//will not be associated with the parent entity, and new items will not be added to the relationship
			//so foreign key errors will result. Can't load the related entities on a detached or added (but not saved)
			//entity.
			if (id != 0) {
				_selectedRecord.BusRouteStop.Load(MergeOption.OverwriteChanges);
			}
			//Don't do any LINQ operations on the entitycollection, just bind directly to it, otherwise
			//it appears to bind as unassociated with the context and you have to manually add/delete
			//rows from the bindingsource to the context (but changes work fine)
			bindingSourceStops.DataSource = _selectedRecord.BusRouteStop;
			BindStops();
		}

		void BindStops()
		{
			gridControlStops.DataSource = bindingSourceStops;
			gridControlStops.RefreshDataSource();
		}

		void LoadAndBindTimes(int id)
		{
			if (id != 0) {
				_selectedRecord.BusDeparture.Load(MergeOption.OverwriteChanges);
			}
			bindingSourceTimes.DataSource = _selectedRecord.BusDeparture;
			BindTimes();
		}

		void BindTimes()
		{
			gridControlTimes.DataSource = bindingSourceTimes;
			gridControlTimes.RefreshDataSource();
		}

		private void buttonAddStop_Click(object sender, EventArgs e)
		{
			BusRouteStop busStop = new BusRouteStop();
			if (_selectedRecord.BusRouteStop.Count == 0) {
				busStop.Sequence = 1;
			}
			else {
				busStop.Sequence = _selectedRecord.BusRouteStop.Max(b => b.Sequence) + 1;
			}
			_selectedRecord.BusRouteStop.Add(busStop);
			BindStops();
			gridViewStops.FocusedRowHandle = bindingSourceStops.Count - 1;
			_modified = true;
		}

		private void buttonDeleteStop_Click(object sender, EventArgs e)
		{
			if (gridViewStops.FocusedRowHandle >= 0) {
				BusRouteStop busStop = (BusRouteStop)gridViewStops.GetFocusedRow();
				bindingSourceStops.Remove(busStop);
				//Removing from the bindingsource just removes the object from its parent, but does not mark
				//it for deletion, effectively orphaning it.  This will cause foreign key errors when saving.
				//To flag for deletion, delete it from the context as well.
				_context.BusRouteStop.DeleteObject(busStop);		
				BindStops();
				_modified = true;
			}
		}

		private void buttonAddTime_Click(object sender, EventArgs e)
		{
			_selectedRecord.BusDeparture.Add(new BusDeparture());
			BindTimes();
			gridViewTimes.FocusedRowHandle = 0;		//new rows will appear at the top because grid is sorted by date and time
		}

		private void buttonDeleteTime_Click(object sender, EventArgs e)
		{
			if (gridViewTimes.FocusedRowHandle >= 0) {
				BusDeparture busTime = (BusDeparture)gridViewTimes.GetFocusedRow();
				bindingSourceTimes.Remove(busTime);
				_context.BusDeparture.DeleteObject(busTime);
				BindTimes();
				_modified = true;
			}
		}

		private void gridViewStops_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
		{
			if (e.Column.FieldName == "Code") {
				_productCombo.Items.Clear();
				string type = gridViewStops.GetRowCellDisplayText(e.RowHandle, "Type");
				if (_productLookups.ContainsKey(type)) {
					List<ImageComboBoxItem> lookup = _productLookups[type];
					_productCombo.Items.AddRange(lookup);
				}
				e.RepositoryItem = _productCombo;
			}
		}

		private void gridViewTimes_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
		{
			if (e.Column.FieldName == "Day") {
				e.RepositoryItem = _daysCombo;
			}
		}

		private void gridViewStops_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			if (e.Column.FieldName == "Type") {
				gridViewStops.SetFocusedRowCellValue("Code", "");
			}
			_modified = true;
		}

		private void gridViewTimes_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			_modified = true;
		}

		private void buttonUpArrow_Click(object sender, EventArgs e)
		{
			if (gridViewStops.FocusedRowHandle > 0) {
				BusRouteStop busStop = (BusRouteStop)gridViewStops.GetFocusedRow();
				BusRouteStop priorStop = (BusRouteStop)gridViewStops.GetRow(gridViewStops.FocusedRowHandle - 1);
				priorStop.Sequence += 1;
				busStop.Sequence -= 1;
				BindStops();
				_modified = true;
			}
		}

		private void buttonDownArrow_Click(object sender, EventArgs e)
		{
			if (gridViewStops.FocusedRowHandle < gridViewStops.DataRowCount - 1) {
				BusRouteStop busStop = (BusRouteStop)gridViewStops.GetFocusedRow();
				BusRouteStop nextStop = (BusRouteStop)gridViewStops.GetRow(gridViewStops.FocusedRowHandle + 1);
				nextStop.Sequence -= 1;
				busStop.Sequence += 1;
				BindStops();
				_modified = true;
			}
		}

		private void RouteForm_Shown(object sender, EventArgs e)
		{
			gridViewLookup.FocusedRowHandle = DevExpress.Data.CurrencyDataController.FilterRow;
			gridControlLookup.Focus();
		}

		private void colorPickEditMap_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
		{
			ColorPickEdit colorEdit = (sender as ColorPickEdit);
			if (colorEdit.Color.IsEmpty) {
				e.DisplayText = string.Empty;
			}
			else if (!colorEdit.Color.IsKnownColor) {
				Color color = colorEdit.Color;
				//X2 means 2 digit hex, so that F will be 0F
				e.DisplayText = String.Format("#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B);
			}
		}

		private void SetErrorInfo(Func<String> validationMethod, object sender)
		{
            bindingSource.EndEdit();		//force changes back into context for validation
            if (sender != null) {
                if (sender.GetType() == typeof(CheckEdit)) {
                    if (_currentVal != ((CheckEdit)sender).Checked.ToString()) {
                        _modified = true;
                    }
                }
                else {
                    if (_currentVal != ((Control)sender).Text) {
                        _modified = true;
                    }
                }
                //Put this here to save the current value of the control into currentVal in the cases
                //where this event was fired without a new control gaining focus, ie when the Save
                //button is clicked. 
                enterControl(sender, new EventArgs());
            }
			if (validationMethod != null) {
				string error = validationMethod.Invoke();
				errorProvider1.SetError((Control)sender, error);
			}
		}

		private void TextEditName_Leave(object sender, EventArgs e)
		{
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateName, sender);
		}

		private void colorPickEditMap_Leave(object sender, EventArgs e)
		{
			if (_selectedRecord != null) {
				//colour picker is unbound so we have to push the value into the backing object before validating
				_selectedRecord.MapColour = ColorTranslator.ToHtml(colorPickEditMap.Color);
				SetErrorInfo(_selectedRecord.ValidateColour, sender);
			}
		}

		private void dateEdits_Leave(object sender, EventArgs e)
		{
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateDates, sender);
		}

		private void gridControlTimes_Leave(object sender, EventArgs e)
		{
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateDepartures, sender);
		}

		private void gridControlStops_Leave(object sender, EventArgs e)
		{
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateStops, sender);
		}

		private void checkEditInactive_Leave(object sender, EventArgs e)
		{
			if (_selectedRecord != null)
				SetErrorInfo(null, sender);
		}

		private void gridViewStops_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
		{
			if (e.RowHandle == GridControl.NewItemRowHandle) {
				BaseEditViewInfo info = ((GridCellInfo)e.Cell).ViewInfo;
				info.ShowErrorIcon = false;
				info.CalcViewInfo(e.Graphics);
			}
		}

		private void GridViewRoute_ColumnFilterChanged(object sender, EventArgs e)
		{
			if (gridViewLookup.DataRowCount == 0) {
				ClearBindings();
			}
		}

		private void checkEditShowTransferPointsOnMap_Leave(object sender, EventArgs e)
		{
			if (_selectedRecord != null)
				SetErrorInfo(null, sender);
		}

    }
}
