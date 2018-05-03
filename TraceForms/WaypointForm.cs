using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using FlexModel;
using Custom_SearchLookupEdit;
using System.Collections.Generic;
using DevExpress.XtraEditors.Popup;
using DevExpress.Utils.Win;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Map;
using DevExpress.XtraMap;

namespace TraceForms
{
    
    public partial class WaypointForm : DevExpress.XtraEditors.XtraForm
    {
		FlextourEntities _context;
		WAYPOINT _selectedRecord;
		Timer _actionConfirmation;
		bool _ignoreLeaveRow = false, _ignorePositionChange = false;

		public WaypointForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
            LoadLookups();
			SetReadOnly(true);
			SetMapProperties();         //Mapping
		}

		void SetReadOnly(bool value)
		{
			foreach (Control control in SplitContainerControl.Panel2.Controls)
			{
				control.Enabled = !value;
			}
		}

		void SetReadOnlyKeyFields(bool value)
		{
			TextEditCode.ReadOnly = value;
		}

		private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            _context = new FlextourEntities(sys.Settings.EFConnectionString);
        }

        private void LoadLookups()
        {
			var cities = new List<CodeName> {
				new CodeName(null)
			};
			cities.AddRange(_context.CITYCOD
				.OrderBy(o => o.NAME)
				.Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }).ToList());
			SearchLookupEditCity.Properties.DataSource = cities;

			var states = new List<CodeName> {
				new CodeName(null)
			};
			states.AddRange(_context.State
				.OrderBy(o => o.Code)
				.Select(s => new CodeName() { Code = s.Code, Name = s.State1 }).ToList());
			SearchLookupEditState.Properties.DataSource = states;

			var countries = new List<CodeName> {
				new CodeName(null)
			};
			countries.AddRange(_context.COUNTRY
				.OrderBy(o => o.NAME)
				.Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }).ToList());
			SearchLookupEditCountry.Properties.DataSource = countries;
		}

		private void ShowActionConfirmation(string confirmation)
		{
			PanelControlStatus.Visible = true;
			LabelStatus.Text = confirmation;
			_actionConfirmation = new Timer {
				Interval = 3000
			};
			_actionConfirmation.Start();
			_actionConfirmation.Tick += TimedEvent;
		}

		private void TimedEvent(object sender, EventArgs e)
		{
			PanelControlStatus.Visible = false;
			_actionConfirmation.Stop();
		}

		private void RemoveRecord()
		{
			BindingSource.RemoveCurrent();
		}

		private void RefreshRecord()
		{
			//A Detached record has not yet been added to the context
			//An Added record has been added but not yet saved, most likely because there was
			//an error in SaveRecord, in which case we should not retrieve it from the db
			if (_selectedRecord != null && _selectedRecord.EntityState != EntityState.Detached
				&& _selectedRecord.EntityState != EntityState.Added)
			{
				_context.Refresh(RefreshMode.StoreWins, _selectedRecord);
				SetReadOnlyKeyFields(true);
			}
		}

		private bool SaveRecord(bool prompt)
		{
			try
			{
				if (_selectedRecord == null)
					return true;

				FinalizeBindings();
				bool newRec = _selectedRecord.IsNew();
				bool modified = newRec || IsModified(_selectedRecord);

				if (modified)
				{
					if (prompt)
					{
						DialogResult result = DisplayHelper.QuestionYesNoCancel(this, "Do you want to save these changes?");
						if (result == DialogResult.No)
						{
							if (newRec)
							{
								RemoveRecord();
							}
							else
							{
								RefreshRecord();
							}
							return true;
						}
						else if (result == DialogResult.Cancel)
						{
							return false;
						}
					}
					if (!ValidateAll())
						return false;

					if (_selectedRecord.EntityState == EntityState.Detached)
					{
						_context.WAYPOINT.AddObject(_selectedRecord);
					}
					_context.SaveChanges();
					ShowActionConfirmation("Record Saved");
				}
				return true;
			}
			catch (Exception ex)
			{
				DisplayHelper.DisplayError(this, ex);
				RefreshRecord();        //pull it back from db because that is its current state
										//We must also Load and rebind the related entities from the db because context.Refresh doesn't do that
				SetBindings();
				return false;
			}
		}

		private bool IsModified(WAYPOINT record)
		{
            //Type-specific routine that takes into account relationships that should also be considered
            //when deciding if there are unsaved changes.  The entity properties also return true if the
            //record is new or deleted.
            if (record == null)
                return false;
            return record.IsModified(_context)
					|| record.GeoCode.IsModified(_context);     //Mapping

		}

		private void FinalizeBindings()
		{
			BindingSource.EndEdit();
		}

		void SetBindings()
		{
			//If the route list is filtered, there will be rows in the binding source
			//that are not visible, and they can become selected if the last visible row
			//is deleted, so handle that by checking rowcount.
			if (BindingSource.Current == null)
			{
				_selectedRecord = null;
				SetReadOnly(true);
			}
			else
			{
				_selectedRecord = ((WAYPOINT)BindingSource.Current);
				SetReadOnly(false);
				SetReadOnlyKeyFields(true);
				ShowMapData(_selectedRecord);           //Mapping
			}
			ErrorProvider.Clear();
		}

		private bool ValidateAll()
		{
			if (!_selectedRecord.Validate())
			{
				ShowMainControlErrors();
				DisplayHelper.DisplayWarning(this, "Errors were found. Please resolve them and try again.");
				return false;
			}
			else
			{
				ErrorProvider.Clear();
				return true;
			}
		}

		private void ShowMainControlErrors()
		{
			//The error indicators inside the grids are handled by binding, but errors on the main form must
			//be set manually
			SetErrorInfo(_selectedRecord.ValidateCode, TextEditCode);
			SetErrorInfo(_selectedRecord.ValidateDesc, TextEditDesc);
			SetErrorInfo(_selectedRecord.ValidateAddress1, TextEditAddress1);
			SetErrorInfo(_selectedRecord.ValidateAddress2, TextEditAddress2);
			SetErrorInfo(_selectedRecord.ValidateAddress3, TextEditAddress3);
			SetErrorInfo(_selectedRecord.ValidateTown, TextEditTown);
			SetErrorInfo(_selectedRecord.ValidateZip, TextEditZip);
			SetErrorInfo(_selectedRecord.ValidateCity, SearchLookupEditCity);
			SetErrorInfo(_selectedRecord.ValidateCountry, SearchLookupEditCountry);
			SetErrorInfo(_selectedRecord.ValidateState, SearchLookupEditState);
			SetErrorInfo(_selectedRecord.ValidateDistance, SpinEditDistance);
			SetErrorInfo(_selectedRecord.ValidateDuration, SpinEditDuration);
		}

		private void SetErrorInfo(Func<String> validationMethod, object sender)
		{
			BindingSource.EndEdit();        //force changes back into context for validation
			if (validationMethod != null)
			{
				string error = validationMethod.Invoke();
				ErrorProvider.SetError((Control)sender, error);
			}
		}

		private void GridViewLookup_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
			//If the user selects a row, edits, then selects the auto-filter row, then selects a different row,
			//this event will fire for the auto-filter row, so we cannot ignore it because there is still a record
			//that may need to be saved. 
			if (!_ignoreLeaveRow && IsModified(_selectedRecord))
			{
				e.Allow = SaveRecord(true);
			}
		}

		private void DeleteRecord()
		{
			if (_selectedRecord == null)
				return;

			try
			{
				if (DisplayHelper.QuestionYesNo(this, "Are you sure you want to delete this record?") == DialogResult.Yes)
				{
					_ignoreLeaveRow = true;
					_ignorePositionChange = true;
					RemoveRecord();
					if (!_selectedRecord.IsNew())
					{
						//Apparently a record which has just been added is not flagged for deletion by BindingSource.RemoveCurrent,
						//(the EntityState remains unchanged).  It seems like it is not tracked by the context even though it is, because
						//the EntityState changes for modification. So if this is a deletion and the entity is not flagged for deletion, 
						//delete it manually.
						if (_selectedRecord != null && (_selectedRecord.EntityState & EntityState.Deleted) != EntityState.Deleted)
							_context.WAYPOINT.DeleteObject(_selectedRecord);
						_context.SaveChanges();
					}
					if (GridViewLookup.RowCount == 0)
					{
						ClearBindings();
					}
					_ignoreLeaveRow = false;
					_ignorePositionChange = false;
					SetBindings();
					ShowActionConfirmation("Record Deleted");
				}
			}
			catch (Exception ex)
			{
				DisplayHelper.DisplayError(this, ex);
				RefreshRecord();        //pull it back from db because that is it's current state
										//We must also Load and rebind the related entities from the db because context.Refresh doesn't do that
				SetBindings();
			}
		}

		void ClearBindings()
		{
			BindingSource.DataSource = typeof(WAYPOINT);
			ClearMapData();                 //Mapping
		}

		private void TextEditCode_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateCode, sender);
		}

        private void TextEditDesc_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateDesc, sender);
		}

        private void WAYPOINTForm_FormClosing(object sender, FormClosingEventArgs e)
        {
			if (IsModified(_selectedRecord))
			{
				DialogResult select = DisplayHelper.QuestionYesNo(this, "There are unsaved changes. Are you sure you want to exit?");
				if (select == DialogResult.Yes)
				{
					e.Cancel = false;
					_context.Dispose();
					Dispose();
				}
				else
					e.Cancel = true;
			}
			else
			{
				e.Cancel = false;
				_context.Dispose();
				Dispose();
			}
		}

		private void SearchLookupEditState_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateState, sender);
		}
 
        private void SearchLookupEditCity_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateCity, sender);
		}

		private void SearchLookupEditCountry_Leave(object sender, System.EventArgs e)
		{
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateState, sender);
		}

		private void TextEditAddress1_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateAddress1, sender);
		}

        private void TextEditAddress2_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateAddress2, sender);
		}

        private void TextEditAddress3_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateAddress3, sender);
		}

        private void TextEditTown_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateTown, sender);
		}

        private void TextEditZip_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateZip, sender);
		}   

        private void WaypointForm_KeyDown(object sender, KeyEventArgs e)
        {
			if (e.KeyCode == Keys.Enter && GridViewLookup.IsFilterRow(GridViewLookup.FocusedRowHandle))
			{
				ExecuteQuery();
				e.Handled = true;
			}
		}

		private void ExecuteQuery()
		{
			Cursor = Cursors.WaitCursor;
			string query = "1=1";
			foreach (DevExpress.XtraGrid.Columns.GridColumn col in GridViewLookup.VisibleColumns)
			{
				string value = GridViewLookup.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, col.FieldName);
				if (!string.IsNullOrEmpty(value))
				{
					query += $" and it.{col.FieldName} like '%{value}%'";
				}
			}

			var records = _context.WAYPOINT.Where(query);
			if (records.Count() > 0)
			{
				BindingSource.DataSource = records;
				GridViewLookup.ClearColumnsFilter();
			}
			else
			{
				ClearBindings();
				DisplayHelper.DisplayInfo(this, "No matching records found.");
			}
			Cursor = Cursors.Default;
		}


        private void BindingSource_CurrentChanged(object sender, System.EventArgs e)
        {
			//If the current record is changing as a result of removing a record to delete it, and it is the last
			//record in the table, then SetBindings will clear the bindings, which will cause the delete
			//to fail because the associated entities will become detached when their BindingSources are cleared.
			//Thus we have a flag which is set in that case to ignore this event.
			if (!_ignorePositionChange)
				SetBindings();
		}

		private void SpinEditDistance_Leave(object sender, System.EventArgs e)
		{
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateDistance, sender);
		}

		private void SpinEditDurationEdit_Leave(object sender, EventArgs e)
		{
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateDistance, sender);
		}

		private void BarButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			_ignoreLeaveRow = true;       //so that when the grid row changes it doesn't try to save again
			if (SaveRecord(true))
			{
				GridViewLookup.ClearColumnsFilter();    //so that the new record will show even if it doesn't match the filter
				BindingSource.AddNew();
				//if (GridViewRoute.FocusedRowHandle == GridControl.AutoFilterRowHandle)
				GridViewLookup.FocusedRowHandle = GridViewLookup.RowCount - 1;
				SetReadOnlyKeyFields(false);
				SetReadOnly(false);
			}
			ErrorProvider.Clear();
			_ignoreLeaveRow = false;
		}

		private void BarButtonItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			DeleteRecord();
		}

		private void BarButtonItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (SaveRecord(false))
				RefreshRecord();
		}

		private void PopupForm_KeyUp(object sender, KeyEventArgs e)
		{
			bool gotMatch = false;
			PopupSearchLookUpEditForm popupForm = sender as PopupSearchLookUpEditForm;
			if (e.KeyData == Keys.Enter)
			{
				string searchText = popupForm.Properties.View.FindFilterText;
				if (!string.IsNullOrEmpty(searchText))
				{
					GridView view = popupForm.OwnerEdit.Properties.View;
					//If there is a match is on the ValueMember (Code) column, that should take precedence
					//This needs to be case insensitive, but there is no case insensitive lookup, so we have to iterate the rows
					//int row = view.LocateByValue(popupForm.OwnerEdit.Properties.ValueMember, searchText);
					for (int row = 0; row < view.DataRowCount; row++)
					{
						CodeName codeName = (CodeName)view.GetRow(row);
						if (codeName.Code.Equals(searchText.Trim('"'), StringComparison.OrdinalIgnoreCase))
						{
							view.FocusedRowHandle = row;
							gotMatch = true;
							break;
						}
					}
					if (!gotMatch)
					{
						view.FocusedRowHandle = 0;
					}
					popupForm.OwnerEdit.ClosePopup();
				}
			}
		}

		private void SearchLookupEdit_Popup(object sender, EventArgs e)
		{
			//Hide the Find button because it doesn't do anything when auto - filtering, except it
			//is useful to let the user know the purpose of the filter field, because it has no label
			//LayoutControl lc = ((sender as IPopupControl).PopupWindow.Controls[2].Controls[0] as LayoutControl);
			//((lc.Items[0] as LayoutControlGroup).Items[1] as LayoutControlGroup).Items[1].Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

			PopupSearchLookUpEditForm popupForm = (sender as IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
			popupForm.KeyPreview = true;
			popupForm.KeyUp -= PopupForm_KeyUp;
			popupForm.KeyUp += PopupForm_KeyUp;

			//SearchLookUpEdit currentSearch = (SearchLookUpEdit)sender;
		}

		private void SearchLookupEditCity_Closed(object sender, ClosedEventArgs e)
		{
			//Normal is when a user selects a value
			if (e.CloseMode == PopupCloseMode.Normal)
			{
				//CustomSearchLookUpEdit box = (CustomSearchLookUpEdit)sender;
				if (SearchLookupEditCity.EditValue != null)
				{
					string value = SearchLookupEditCity.EditValue.ToString();
					var city = _context.CITYCOD.FirstOrDefault(s => s.CODE == value);
					if (string.IsNullOrEmpty(TextEditTown.Text))
					{
						TextEditTown.EditValue = city.NAME;
					}
					//If the city is linked to a state and/or country, default the state and/or country for the city
					if (!string.IsNullOrEmpty(city?.State_Code))
					{
						SearchLookupEditState.EditValue = city.State_Code;
					}
					if (!string.IsNullOrEmpty(city?.Country_Code))
					{
						SearchLookupEditCountry.EditValue = city.Country_Code;
					}
				}
			}
		}

		private void SearchLookupEditState_Closed(object sender, ClosedEventArgs e)
		{
			//Normal is when a user selects a value
			if (e.CloseMode == PopupCloseMode.Normal)
			{
				//CustomSearchLookUpEdit box = (CustomSearchLookUpEdit)sender;
				if (SearchLookupEditState.EditValue != null)
				{
					string value = SearchLookupEditState.EditValue.ToString();
					var state = _context.State.FirstOrDefault(s => s.Code == value);
					//If the state is linked to a country, default the country for the city
					if (!string.IsNullOrEmpty(state?.Country))
					{
						SearchLookupEditCountry.EditValue = state.Country;
					}
				}
			}
		}

		private void SearchLookupEdit_UpdateDisplayFilter(object sender, Custom_SearchLookupEdit.DisplayFilterEventArgs e)
		{
			//Users did not like have to type quotes in order to get an exact match of entered terms rather than any word being matched
			//https://www.devexpress.com/Support/Center/Example/Details/E3135/how-to-implement-an-event-allowing-you-to-customize-a-filter-string-produced-by-the-find
			//Also requires the custom inherited version of the SearchLookupEdit in the Custom_SearchLookupEdit namespace
			if (!string.IsNullOrEmpty(e.FilterText))
			{
				e.FilterText = '"' + e.FilterText + '"';
			}
		}

		#region "Mapping"
		MapPushpin _pin;
		delegate void DoSearch();
		IAsyncResult _asyncResult;

		private void SetMapProperties()
		{
			BingSearchDataProvider.SearchCompleted += new BingSearchCompletedEventHandler(SearchDataProvider_SearchCompleted);
			BingMapDataProvider.BingKey = Configurator.BingMapsAPIKey;
			BingSearchDataProvider.BingKey = Configurator.BingMapsAPIKey;
		}

		private void MapControl_MouseDown(object sender, MouseEventArgs e)
		{
			MapHitInfo info = this.MapControl.CalcHitInfo(e.Location);
			if (info.InMapPushpin)
			{
				MapControl.EnableScrolling = false;
				foreach (object obj in info.HitObjects)
				{
					if (obj.GetType() == typeof(MapPushpin))
						_pin = (MapPushpin)obj;
				}
			}
		}

		private void MapControl_MouseMove(object sender, MouseEventArgs e)
		{
			if (_pin != null)
			{
				CoordPoint point = MapControl.ScreenPointToCoordPoint(new MapPoint(e.X, e.Y));
				_pin.Location = point;
			}
		}

		private void MapControl_MouseUp(object sender, MouseEventArgs e)
		{
			if (_pin != null)
			{
				CoordPoint point = MapControl.ScreenPointToCoordPoint(new MapPoint(e.X, e.Y));
				_pin.Location = point;
				MapControl.EnableScrolling = true;
				DisplayPointCoordinates((GeoPoint)point);
				SaveMapData();
				_pin = null;
			}
		}

		private void AddOrMovePushpin(GeoCode geoCode)
		{
			GeoPoint geoPoint = new GeoPoint(geoCode.PushLat, geoCode.PushLong);

			MapPushpin pin = AddOrMovePushpin(geoPoint);

			//Since we only have one pin this isn't really necessary, but just showing how to add an attribute to a pushpin
			//which can later be used to match when retrieving the pin
			MapItemAttribute attrib = pin.Attributes.FirstOrDefault(a => a.Name == "id");
			if (attrib == null)
			{
				pin.Attributes.Add(new MapItemAttribute() {
					Name = "id",
					Type = typeof(int),
					Value = geoCode.GeoCodeId
				});
			}
			else
			{
				attrib.Value = geoCode.GeoCodeId;
			}
		}

		private MapPushpin AddOrMovePushpin(GeoPoint geoPoint)
		{
			MapItem item = MapItemStorage.Items.FirstOrDefault();
			MapPushpin pin;
			if (item == null)
			{
				pin = new MapPushpin();
				MapItemStorage.Items.Add(pin);
			}
			else
			{
				pin = (MapPushpin)item;
			}
			pin.Location = geoPoint;
			MapControl.CenterPoint = geoPoint;
			DisplayPointCoordinates(geoPoint);

			return pin;
		}

		private void DisplayPointCoordinates(GeoPoint point)
		{
			LabelControlLat.Text = point.Latitude == 0 ? string.Empty : point.Latitude.ToString();
			LabelControlLon.Text = point.Longitude == 0 ? string.Empty : point.Longitude.ToString();
		}

		private void SearchDataProvider_SearchCompleted(object sender, BingSearchCompletedEventArgs e)
		{
			SearchRequestResult result = e.RequestResult;
			if (result.ResultCode == RequestResultCode.Success)
			{
				//List<LocationInformation> regions = result.SearchResults;
				//Really we should display all the returned regions for disambiguation, but we're just going with the best match
				//which is the first one
				LocationInformation region = result.SearchResults.FirstOrDefault();
				AddOrMovePushpin(region.Location);
				MapControl.ZoomLevel = 13;
				SaveMapData();
			}

			if (result.ResultCode == RequestResultCode.BadRequest)
				this.DisplayWarning("The Bing Search service does not work for this location.");

		}

		private void SimpleButtonPlot_Click(object sender, EventArgs e)
		{
			_asyncResult = BeginInvoke((DoSearch)SearchAsync);
		}

		private void SearchAsync()
		{
			EndInvoke(_asyncResult);
			string search = $"{TextEditAddress1.Text}, {SearchLookupEditState.EditValue}, {(SearchLookupEditCountry.EditValue as CodeName)?.Name}";
			BingSearchDataProvider.Search(search);
		}

		private void ShowMapData(WAYPOINT record)
		{
			GeoCode geoCode = record?.GeoCode ?? new GeoCode();
			AddOrMovePushpin(geoCode);
			//If a bounding box has been given, then use it
			if (geoCode.NorthLat != 0)
			{
				var topLeft = new GeoPoint(geoCode.NorthLat, geoCode.WestLong);
				var bottomRight = new GeoPoint(geoCode.SouthLat, geoCode.EastLong);
				MapControl.ZoomToRegion(topLeft, bottomRight, 0);
			}
			else
			{
				//If there there is no bounding box, zoom all the way out if this is a new record, otherwise go to the 
				//default zoom level
				MapControl.ZoomLevel = (geoCode.GeoCodeId == 0) ? 1 : 13;
			}
		}

		private void ClearMapData()
		{
			MapItemStorage.Items.Clear();
			MapControl.ZoomLevel = 1;
		}

		private void SaveMapData()
		{
			MapItem item = MapItemStorage.Items.FirstOrDefault();
			if (item != null)
			{
				MapPushpin pin = (MapPushpin)item;
				GeoPoint location = (GeoPoint)pin.Location;
				//If lat and long are zero, then there was no geocode to begin with and the user didn't specify one
				//during the edit, so don't update the values
				if (location.Longitude != 0 || location.Latitude != 0)
				{
					if (_selectedRecord.GeoCode == null)
					{
						_selectedRecord.GeoCode = new GeoCode();
					}
					GeoCode geoCode = _selectedRecord.GeoCode;
					geoCode.PushLat = location.Latitude;
					geoCode.PushLong = location.Longitude;
					geoCode.ManualChecked = true;
					CoordPoint p1 = MapControl.ScreenPointToCoordPoint(new MapPoint());
					CoordPoint p2 = MapControl.ScreenPointToCoordPoint(new MapPoint(MapControl.Width, MapControl.Height));
					GeoPoint gp1 = (GeoPoint)p1;
					GeoPoint gp2 = (GeoPoint)p2;
					geoCode.NorthLat = gp1.Latitude;
					geoCode.WestLong = gp1.Longitude;
					geoCode.SouthLat = gp2.Latitude;
					geoCode.EastLong = gp2.Longitude;
				}
			}
		}
		#endregion
	}
}