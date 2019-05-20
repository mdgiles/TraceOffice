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
using DevExpress.XtraEditors.Repository;
using DevExpress.Data.Async.Helpers;

namespace TraceForms
{
    public partial class CountryForm : DevExpress.XtraEditors.XtraForm
    {
		FlextourEntities _context;
		COUNTRY _selectedRecord;
		Timer _actionConfirmation;
		bool _ignoreLeaveRow = false, _ignorePositionChange = false;

        RepositoryItemImageComboBox _supplierCombo = new RepositoryItemImageComboBox();

        public CountryForm(FlexInterfaces.Core.ICoreSys sys)
        {
			try
			{
				InitializeComponent();
				Connect(sys);
				SetReadOnly(true);
				LoadLookups();
			}
			catch (Exception ex)
			{
				DisplayHelper.DisplayError(this, ex);
			}
		}

        private void LoadLookups()
        {
			var lookup = new List<IdName> {
				new IdName(null)
			};
			lookup.AddRange(_context.Continent
				.OrderBy(o => o.Name)
				.Select(s => new IdName() { Id = s.ID, Name = s.Name }));
			SearchLookupEditContinent.Properties.DataSource = lookup;

            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = null };

            _supplierCombo.Items.Add(loadBlank);
            _supplierCombo.Items.AddRange(_context.Supplier
                            .OrderBy(o => o.Name).AsEnumerable()
                            .Select(s => new ImageComboBoxItem() { Description = s.Name, Value = s.GUID })
                            .ToList());
            GridControlSupplierCountry.RepositoryItems.Add(_supplierCombo);        //per DX recommendation to avoid memory leaks
        }

        private void EntityInstantFeedbackSource_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            FlextourEntities context = new FlextourEntities(Connection.EFConnectionString);
            e.QueryableSource = context.COUNTRY;
            e.Tag = context;
        }

        private void EntityInstantFeedbackSource_DismissQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            ((FlextourEntities)e.Tag).Dispose();
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

        private void GridViewLookup_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (!_ignoreLeaveRow) {
                GridView view = (GridView)sender;
                BindFocusedRow(view, e.FocusedRowHandle);
            }
        }

        private void BindFocusedRow(GridView view, int focusedRowHandle)
        {
            object row = view.GetRow(focusedRowHandle);
            if (row != null && row.GetType() != typeof(DevExpress.Data.NotLoadedObject)) {
                ReadonlyThreadSafeProxyForObjectFromAnotherThread proxy = (ReadonlyThreadSafeProxyForObjectFromAnotherThread)view.GetRow(focusedRowHandle);
                COUNTRY record = (COUNTRY)proxy.OriginalRow;
                BindingSource.DataSource = _context.COUNTRY.Where(c => c.CODE == record.CODE);
            }
            else {
                ClearBindings();
            }
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
            if (_selectedRecord.IsNew()) {
                //If you clear the bindingsource for child records where the parent entity is tracked by
                //the context, it will lose tracking for the child entities and cascade operations like
                //delete will fail
                BindingSourceSupplierCountry.Clear();
            }
            //Note that cascade delete must be set on the FK in the db in order for the related
            //entities to be deleted.  This is a db function, not an EF function. However in addition
            //the model must know about the delete, otherwise the relationships in the context will
            //get messed up.  So after adding the cascade rule to the FK, the model must be updated,
            //and in order to refresh a relationship the tables must be deleted and re-added
            //Otherwise, we could do a delete loop
            //If using DbContext instead of ObjectContext, we could do eg
            //_context.SupplierRegion.RemoveRange(_selectedRecord.SupplierRegion)
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
            try {
                if (_selectedRecord == null)
                    return true;

                FinalizeBindings();
                bool newRec = _selectedRecord.IsNew();
                bool modified = newRec || IsModified(_selectedRecord);

                if (modified) {
                    if (prompt) {
                        DialogResult result = DisplayHelper.QuestionYesNoCancel(this, "Do you want to save these changes?");
                        if (result == DialogResult.No) {
                            if (newRec) {
                                RemoveRecord();
                            }
                            else {
                                RefreshRecord();
                            }
                            return true;
                        }
                        else if (result == DialogResult.Cancel) {
                            return false;
                        }
                    }
                    if (!ValidateAll())
                        return false;

                    if (_selectedRecord.EntityState == EntityState.Detached) {
                        _context.COUNTRY.AddObject(_selectedRecord);
                    }
                    _context.SaveChanges();
                    EntityInstantFeedbackSource.Refresh();
                    ShowActionConfirmation("Record Saved");
                }
                return true;
            }
            catch (Exception ex) {
                DisplayHelper.DisplayError(this, ex);
                RefreshRecord();        //pull it back from db because that is its current state
                                        //We must also Load and rebind the related entities from the db because context.Refresh doesn't do that
                SetBindings();
                return false;
            }
        }

		private bool IsModified(COUNTRY record)
		{
            //Type-specific routine that takes into account relationships that should also be considered
            //when deciding if there are unsaved changes.  The entity properties also return true if the
            //record is new or deleted.
            if (record == null)
                return false;
            return record.IsModified(_context)
                || record.SupplierCountry.IsModified(_context);
        }

		private void FinalizeBindings()
		{
            BindingSource.EndEdit();
            GridViewSupplierCountry.CloseEditor();
            GridViewSupplierCountry.UpdateCurrentRow();
            //Set the city code for each mapping just in case
            for (int rowCtr = 0; rowCtr < GridViewSupplierCountry.DataRowCount; rowCtr++) {
                SupplierCountry suppCountry = (SupplierCountry)GridViewSupplierCountry.GetRow(rowCtr);
                suppCountry.Country_Code = TextEditCode.Text;
            }
            BindingSourceSupplierCountry.EndEdit();
        }

		void SetBindings()
		{
            //If the route list is filtered, there will be rows in the binding source
            if (BindingSource.Current == null) {
                ClearBindings();
            }
            else {
                _selectedRecord = ((COUNTRY)BindingSource.Current);
                LoadAndBindSupplierCountry();
                SetReadOnly(false);
                SetReadOnlyKeyFields(true);
                BarButtonItemDelete.Enabled = true;
                BarButtonItemSave.Enabled = true;
            }
            ErrorProvider.Clear();
        }

        void LoadAndBindSupplierCountry()
        {
            //Load the related entities. DO NOT do another db query using context.whatever because they
            //will not be associated with the parent entity, and new items will not be added to the relationship
            //so foreign key errors will result. Can't load the related entities on a detached or added (but not saved)
            //entity.
            if (_selectedRecord.EntityState != EntityState.Detached) {
                _selectedRecord.SupplierCountry.Load(MergeOption.OverwriteChanges);
            }
            //Don't do any LINQ operations on the entitycollection, just bind directly to it, otherwise
            //it appears to bind as unassociated with the context and you have to manually add/delete
            //rows from the bindingsource to the context (but changes work fine)
            BindingSourceSupplierCountry.DataSource = _selectedRecord.SupplierCountry;
            BindSupplierCountry();
        }

        void BindSupplierCountry()
        {
            GridControlSupplierCountry.DataSource = BindingSourceSupplierCountry;
            GridControlSupplierCountry.RefreshDataSource();
        }

        private void GridControlSupplierCountry_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateSupplierCountries, sender);
        }

        private void GridViewSupplierCountry_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column == gridColumnSupplierGuid) {
                e.RepositoryItem = _supplierCombo;
            }
            //else if (e.Column == gridColumnOperator) {
            //    e.RepositoryItem = _operatorSearch;
            //}
        }

        private bool ValidateAll()
        {
            bool supplierInvalid = false;
            if (BindingSourceSupplierCountry.List.Count > 0) {
                supplierInvalid = BindingSourceSupplierCountry.List.Cast<SupplierCountry>().Any(b => !b.Validate());
            }

            if (!_selectedRecord.Validate() || supplierInvalid) {
                ShowMainControlErrors();
                DisplayHelper.DisplayWarning(this, "Errors were found. Please resolve them and try again.");
                return false;
            }
            else {
                ErrorProvider.Clear();
                return true;
            }
        }

        private void ButtonAddMapping_Click(object sender, EventArgs e)
        {
            SupplierCountry suppCountry = new SupplierCountry();
            suppCountry.Country_Code = TextEditCode.Text;
            _selectedRecord.SupplierCountry.Add(suppCountry);
            BindSupplierCountry();
            GridViewSupplierCountry.FocusedRowHandle = BindingSourceSupplierCountry.Count - 1;
        }

        private void ButtonDeleteMapping_Click(object sender, EventArgs e)
        {
            if (GridViewSupplierCountry.FocusedRowHandle >= 0) {
                SupplierCountry suppCountry = (SupplierCountry)GridViewSupplierCountry.GetFocusedRow();
                _selectedRecord.SupplierCountry.Remove(suppCountry);
                //Removing from the collection just removes the object from its parent, but does not mark
                //it for deletion, effectively orphaning it.  This will cause foreign key errors when saving.
                //To flag for deletion, delete it from the context as well.
                _context.SupplierCountry.DeleteObject(suppCountry);
                BindSupplierCountry();
            }
        }

        private void ShowMainControlErrors()
		{
			//The error indicators inside the grids are handled by binding, but errors on the main form must
			//be set manually
			SetErrorInfo(_selectedRecord.ValidateCode, TextEditCode);
			SetErrorInfo(_selectedRecord.ValidateName, TextEditName);
			SetErrorInfo(_selectedRecord.ValidateContinent, SearchLookupEditContinent);
            SetErrorInfo(_selectedRecord.ValidateSupplierCountries, GridControlSupplierCountry);
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

		private void CountryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
			if (IsModified(_selectedRecord))
			{
				DialogResult select = DisplayHelper.QuestionYesNo(this, "There are unsaved changes. Are you sure want to exit?");
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

		private bool DeleteRecord()
		{
            if (_selectedRecord == null)
                return false;

            try {
                if (DisplayHelper.QuestionYesNo(this, "Are you sure you want to delete this record?") == DialogResult.Yes) {
                    //ignoreLeaveRow and ignorePositionChange are set because when removing a record, the bindingsource_currentchanged 
                    //and gridview_beforeleaverow events will fire as the current record is removed out from under them.
                    //We do not want these events to perform their usual code of checking whether there are changes in the active
                    //record that should be saved before proceeding, because we know we have just deleted the active record.
                    _ignoreLeaveRow = true;
                    _ignorePositionChange = true;
                    RemoveRecord();
                    if (!_selectedRecord.IsNew()) {
                        //Apparently a record which has just been added is not flagged for deletion by BindingSource.RemoveCurrent,
                        //(the EntityState remains unchanged).  It seems like it is not tracked by the context even though it is, because
                        //the EntityState changes for modification. So if this is a deletion and the entity is not flagged for deletion, 
                        //delete it manually.
                        if (_selectedRecord != null && (_selectedRecord.EntityState & EntityState.Deleted) != EntityState.Deleted)
                            _context.COUNTRY.DeleteObject(_selectedRecord);
                        _context.SaveChanges();
                    }
                    if (GridViewLookup.DataRowCount == 0) {
                        ClearBindings();
                    }
                    _ignoreLeaveRow = false;
                    _ignorePositionChange = false;
                    EntityInstantFeedbackSource.Refresh();
                    SetBindings();
                    ShowActionConfirmation("Record Deleted");
                    return true;
                }
                else {
                    return false;
                }
            }
            catch (Exception ex) {
                DisplayHelper.DisplayError(this, ex);
                _ignoreLeaveRow = false;
                _ignorePositionChange = false;
                RefreshRecord();        //pull it back from db because that is it's current state
                //We must also Load and rebind the related entities from the db because context.Refresh doesn't do that
                SetBindings();
                return false;
            }
        }

		private void BindingSource_CurrentChanged(object sender, EventArgs e)
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
            _ignoreLeaveRow = true;
            _ignorePositionChange = true;
            _selectedRecord = null;
            BindingSourceSupplierCountry.Clear();
            SetReadOnly(true);
            BarButtonItemDelete.Enabled = false;
            BarButtonItemSave.Enabled = false;
            BindingSource.DataSource = typeof(COUNTRY);
            _ignoreLeaveRow = false;
            _ignorePositionChange = false;
        }

		private void TextEditCode_Leave(object sender, EventArgs e)
		{
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateCode, sender);
		}

		private void TextEditName_Leave(object sender, EventArgs e)
		{
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateName, sender);
		}

		private void SearchLookupEditContinent_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateContinent, sender);
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
				TextEditCode.Focus();
				SetReadOnly(false);
			}
			ErrorProvider.Clear();
			_ignoreLeaveRow = false;
		}


		private void BarButtonItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
            if (DeleteRecord()) {
                GridViewLookup.FocusedRowHandle = DevExpress.Data.BaseListSourceDataController.FilterRow;
            }
        }

		private void BarButtonItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (SaveRecord(false))
				RefreshRecord();
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

		void PopupForm_KeyUp(object sender, KeyEventArgs e)
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
						IdName idName = (IdName)view.GetRow(row);
						if (idName.Name.Equals(searchText, StringComparison.OrdinalIgnoreCase))
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
	}
}