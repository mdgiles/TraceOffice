using Custom_SearchLookupEdit;
using DevExpress.Data;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using FlexModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TraceForms
{

    public partial class RelatedProductsForm : DevExpress.XtraEditors.XtraForm
    {
        bool _ignoreLeaveRow = false, _ignorePositionChange = false;
        FlextourEntities _context;
        Timer _actionConfirmation;
        RelatedProduct _selectedRecord;
		RepositoryItemImageComboBox _productCombo = new RepositoryItemImageComboBox();
		Dictionary<String, List<CodeName>> _productLookups;

        public RelatedProductsForm(FlexInterfaces.Core.ICoreSys sys)
        {
            try {
                InitializeComponent();
                Connect(sys);
                LoadLookups();
                SetReadOnly(true);
            }
            catch (Exception ex) {
                DisplayHelper.DisplayError(this, ex);
            }
        }

        void LoadLookups()
		{
			CodeName loadBlank = new CodeName(string.Empty);

			_productLookups = new Dictionary<String, List<CodeName>>();

            List<CodeName> lookup;
            //EF will try to execute the entire projection on the sql side, which knows nothing about string.format so it will
            //error. Putting AsEnumerable beforehand will tell EF to execute sql side up to there and return results, then the
            //rest will be EF client side

            lookup = new List<CodeName>();
            lookup.AddRange(_context.HOTEL
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.NAME }));
			_productLookups.Add("HTL", lookup);

            lookup = new List<CodeName>();
            lookup.AddRange(_context.WAYPOINT
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.DESC }));
            _productLookups.Add("WAY", lookup);

            lookup = new List<CodeName>();
            lookup.AddRange(_context.COMP
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.NAME }));
            _productLookups.Add("OPT", lookup);

            lookup = new List<CodeName>();
            lookup.AddRange(_context.PACK
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.NAME }));
            _productLookups.Add("PKG", lookup);

            //Set up a merged grouping for the master type and code and sort by position
            //Set up a merged grouping for the key fields and sort by day and line
            GridViewLookup.SortInfo.ClearAndAddRange(
                new[] { new GridMergedColumnSortInfo(new[] { colProduct_Type, colProduct_Code },
                    new[] { ColumnSortOrder.Ascending, ColumnSortOrder.Ascending }),
                new GridColumnSortInfo(colPosition, ColumnSortOrder.Ascending) }, 1);

            BindingSource.DataSource = _context.RelatedProduct;
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            _context = new FlextourEntities(sys.Settings.EFConnectionString);
        }

		void SetReadOnly(bool value)
		{
			foreach (Control control in SplitContainerControl.Panel2.Controls) {
				control.Enabled = !value;
			}
		}

		private bool SaveRecord(bool prompt)
		{
			try {
				if (_selectedRecord == null) return true;

                FinalizeBindings();
                bool newRec = _selectedRecord.IsNew();
                bool modified = newRec || IsModified(_selectedRecord);

                if (modified) {
                    if (prompt) {
                        DialogResult result = DisplayHelper.QuestionYesNoCancel(this, "Do you want to confirm these changes?");
                        if (result == DialogResult.No) {
                            if (newRec) {
                                RemoveRecord();
                            }
                            else {
                                RefreshRecord();
                            }
                        }
                        else if (result == DialogResult.Cancel) {
                            return false;
                        }
                    }
                    if (!ValidateAll())
                        return false;

                    if (_selectedRecord.ID == 0) {
                        _context.RelatedProduct.AddObject(_selectedRecord);
                    }
                    _context.SaveChanges();
                    ShowActionConfirmation("Record Saved");
                }
                return true;
			}
			catch (Exception ex) {
				DisplayHelper.DisplayError(this, ex);
				RefreshRecord();		//pull it back from db because that is its current state
				//We must also Load and rebind the related entities from the db because context.Refresh doesn't do that
				SetBindings();
				return false;
			}
		}

		private void FinalizeBindings()
		{
			BindingSource.EndEdit();
		}

		private bool ValidateAll()
		{
			if (!_selectedRecord.Validate()) {
				ShowMainControlErrors();
                DisplayHelper.DisplayWarning(this, "Errors were found. Please resolve them and try again.");
                return false;
            }
			else {
				ErrorProvider.Clear();
                return true;
			}
		}

		private void ShowMainControlErrors()
		{
			//Errors on the main form must be set manually
			SetErrorInfo(_selectedRecord.ValidateMasterType, comboBoxEditMasterType);
			SetErrorInfo(_selectedRecord.ValidateMasterCode, SearchLookupEditMaster);
			SetErrorInfo(_selectedRecord.ValidateMasterType, comboBoxEditMasterType);
			SetErrorInfo(_selectedRecord.ValidateMasterCode, SearchLookupEditMaster);
			//The reason for validating start and end dates with the same routine is just to get the error icon
			//on both fields
			SetErrorInfo(_selectedRecord.ValidateServiceDates, dateEditServiceStart);
			SetErrorInfo(_selectedRecord.ValidateServiceDates, dateEditServiceEnd);
			SetErrorInfo(_selectedRecord.ValidateBookingDates, dateEditBookingStart);
			SetErrorInfo(_selectedRecord.ValidateBookingDates, dateEditBookingEnd);
		}

		private void RefreshRecord()
		{
			if (_selectedRecord != null && _selectedRecord.ID != 0) {
				_context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, _selectedRecord);
			}
		}

		private void RemoveRecord()
		{
			BindingSource.RemoveCurrent();
		}

		private void ShowActionConfirmation(string confirmation)
		{
			panelControlStatus.Visible = true;
			LabelStatus.Text = confirmation;
            _actionConfirmation = new Timer {
                Interval = 3000
            };
            _actionConfirmation.Start();
			_actionConfirmation.Tick += TimedEvent;
		}

        private void DeleteRecord()
		{
			if (_selectedRecord == null) return;

			try {
				if (DisplayHelper.QuestionYesNo(this, "Are you sure you want to delete this record?") == DialogResult.Yes) {
                    //ignoreLeaveRow and ignorePositionChange are set because when removing a record, the bindingsource_currentchanged 
                    //and gridview_beforeleaverow events will fire as the current record is removed out from under them.
                    //We do not want these events to perform their usual code of checking whether there are changes in the active
                    //record that should be saved before proceeding, because we know we have just deleted the active record.
                    _ignoreLeaveRow = true;
					_ignorePositionChange = true;
					RemoveRecord();
					ErrorProvider.Clear();
					if (!_selectedRecord.IsNew()) {
						//Apparently a record which has just been added is not flagged for deletion by BindingSource.RemoveCurrent,
						//(the EntityState remains unchanged).  It seems like it is not tracked by the context even though it is, because
						//the EntityState changes for modification. So if this is a deletion and the entity is not flagged for deletion, 
						//delete it manually.
						if (_selectedRecord != null && (_selectedRecord.EntityState & EntityState.Deleted) != EntityState.Deleted)
							_context.RelatedProduct.DeleteObject(_selectedRecord);
						_context.SaveChanges();
					}
                    _ignoreLeaveRow = false;
                    _ignorePositionChange = false;
                    SetBindings();
					ShowActionConfirmation("Record Deleted");
				}
			}
			catch (Exception ex) {
                DisplayHelper.DisplayError(this, ex);
                _ignoreLeaveRow = false;
                _ignorePositionChange = false;
                RefreshRecord();		//pull it back from db because that is its current state
				//We must also Load and rebind the related entities from the db because context.Refresh doesn't do that
				SetBindings();
			}
		}

        private void TimedEvent(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            _actionConfirmation.Stop();
        }

        private void RelatedProductsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsModified(_selectedRecord)) {
                DialogResult select = DisplayHelper.QuestionYesNo(this, "There are unsaved changes. Are you sure want to exit?");
                if (select == DialogResult.Yes) {
                    e.Cancel = false;
                    _context.Dispose();
                    Dispose();
                }
                else
                    e.Cancel = true;
            }
            else {
                e.Cancel = false;
                _context.Dispose();
                Dispose();
            }
        }

        private bool IsModified(RelatedProduct record)
        {
            //Type-specific routine that takes into account relationships that should also be considered
            //when deciding if there are unsaved changes.  The entity properties also return true if the
            //record is new or deleted.
            if (record == null)
                return false;
            return record.IsModified(_context);
        }

        private void RelatedProductsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewLookup.IsFilterRow(GridViewLookup.FocusedRowHandle)) {
                ExecuteQuery();
                e.Handled = true;
            }
        }

        private void ExecuteQuery()
        {
            Cursor = Cursors.WaitCursor;
            string query = "1=1";
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in GridViewLookup.VisibleColumns) {
                string value = GridViewLookup.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, col.FieldName);
                if (!string.IsNullOrEmpty(value)) {
                    query += $" and it.{col.FieldName} like '%{value}%'";
                }
            }
            query += " order by it.Product_Type, it.Product_Code, it.Position";

            var records = _context.RelatedProduct.Where(query);
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
            this.Cursor = Cursors.Default; 
        }

		void ClearBindings()
		{
            _ignoreLeaveRow = true;
            _ignorePositionChange = true;
            _selectedRecord = null;
            SetReadOnly(true);
            SetButtonEnabledState(false);
            BindingSource.DataSource = typeof(RelatedProduct);
            _ignoreLeaveRow = false;
            _ignorePositionChange = false;
        }

        void SetBindings()
		{
            if (BindingSource.Current == null || GridViewLookup.DataRowCount == 0) {
                ClearBindings();
            }
            else {
                _selectedRecord = ((RelatedProduct)BindingSource.Current);
                SetReadOnly(false);
                SetButtonEnabledState(true);
            }
            ErrorProvider.Clear();
        }

        private void SetButtonEnabledState(bool state)
        {
            BarButtonItemDelete.Enabled = state;
            BarButtonItemSave.Enabled = state;
            BarButtonItemUp.Enabled = state;
            BarButtonItemDown.Enabled = state;
        }

        private void RelatedProductsForm_Shown(object sender, EventArgs e)
		{
			GridViewLookup.FocusedRowHandle = DevExpress.Data.CurrencyDataController.FilterRow;
			GridControlLookup.Focus();
		}

		private void SetErrorInfo(Func<String> validationMethod, object sender)
		{
            BindingSource.EndEdit();        //force changes back into context for validation
            if (validationMethod != null) {
                string error = validationMethod.Invoke();
                ErrorProvider.SetError((Control)sender, error);
            }
        }

        private void dateEdits_Leave(object sender, EventArgs e)
		{
		}

		private void checkEditInactive_Leave(object sender, EventArgs e)
		{
			if (_selectedRecord != null)
				SetErrorInfo(null, sender);
		}

		private void gridViewProduct_BeforeLeaveRow(object sender, RowAllowEventArgs e)
		{
            //If the user selects a row, edits, then selects the auto-filter row, then selects a different row,
            //this event will fire for the auto-filter row, so we cannot ignore it because there is still a record
            //that may need to be saved. 
            if (!_ignoreLeaveRow && IsModified(_selectedRecord)) {
                e.Allow = SaveRecord(true);
            }
        }

        private void GridViewProduct_ColumnFilterChanged(object sender, EventArgs e)
		{
			if (GridViewLookup.DataRowCount == 0) {
				ClearBindings();
			}
		}

		private void gridViewProduct_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
		{
			e.ExceptionMode = ExceptionMode.NoAction;
		}

		private void checkEditExcluded_Leave(object sender, EventArgs e)
		{
			if (_selectedRecord != null)
				SetErrorInfo(null, sender);
		}

		private void dateServices_Leave(object sender, EventArgs e)
		{
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateServiceDates, sender);
		}

		private void dateBooking_Leave(object sender, EventArgs e)
		{
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateBookingDates, sender);
		}

		private void comboBoxEditMasterType_Leave(object sender, EventArgs e)
		{
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateMasterType, sender);
		}

		private void SearchLookupEditMasterCode_Leave(object sender, EventArgs e)
		{
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateMasterCode, sender);
		}

		private void comboBoxEditRelatedType_Leave(object sender, EventArgs e)
		{
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateRelatedType, sender);
		}

		private void SearchLookupEditRelatedCode_Leave(object sender, EventArgs e)
		{
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateRelatedCode, sender);
		}

		private void comboBoxEditMasterType_TextChanged(object sender, EventArgs e)
		{
			string type = comboBoxEditMasterType.Text;
            LoadCodeLookupValues(type, SearchLookupEditMaster);
        }

        private void comboBoxEditRelatedType_TextChanged(object sender, EventArgs e)
		{
			string type = comboBoxEditRelatedType.Text;
            LoadCodeLookupValues(type, SearchLookupEditRelated);
		}

        private void LoadCodeLookupValues(string type, CustomSearchLookUpEdit editor)
        {
            if (_productLookups.ContainsKey(type)) {
                editor.Properties.DataSource = _productLookups[type];
            }
            else {
                editor.Properties.DataSource = null;
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

        private void SearchLookupEdit_UpdateDisplayFilter(object sender, Custom_SearchLookupEdit.DisplayFilterEventArgs e)
        {
            //Users did not like have to type quotes in order to get an exact match of entered terms rather than any word being matched
            //https://www.devexpress.com/Support/Center/Example/Details/E3135/how-to-implement-an-event-allowing-you-to-customize-a-filter-string-produced-by-the-find
            //Also requires the custom inherited version of the SearchLookupEdit in the Custom_SearchLookupEdit namespace
            if (!string.IsNullOrEmpty(e.FilterText)) {
                e.FilterText = '"' + e.FilterText + '"';
            }
        }

        void PopupForm_KeyUp(object sender, KeyEventArgs e)
        {
            bool gotMatch = false;
            PopupSearchLookUpEditForm popupForm = sender as PopupSearchLookUpEditForm;
            if (e.KeyData == Keys.Enter) {
                string searchText = popupForm.Properties.View.FindFilterText;
                if (!string.IsNullOrEmpty(searchText)) {
                    GridView view = popupForm.OwnerEdit.Properties.View;
                    //If there is a match is on the ValueMember (Code) column, that should take precedence
                    //This needs to be case insensitive, but there is no case insensitive lookup, so we have to iterate the rows
                    //int row = view.LocateByValue(popupForm.OwnerEdit.Properties.ValueMember, searchText);
                    for (int row = 0; row < view.DataRowCount; row++) {
                        CodeName codeName = (CodeName)view.GetRow(row);
                        if (codeName.Code.Equals(searchText.Trim('"'), StringComparison.OrdinalIgnoreCase)) {
                            view.FocusedRowHandle = row;
                            gotMatch = true;
                            break;
                        }
                    }
                    if (!gotMatch) {
                        view.FocusedRowHandle = 0;
                    }
                    popupForm.OwnerEdit.ClosePopup();
                }
            }
        }

        private void BarButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _ignoreLeaveRow = true;       //so that when the grid row changes it doesn't try to save again
            if (SaveRecord(true)) {
                GridViewLookup.ClearColumnsFilter();
                BindingSource.AddNew();
                GridViewLookup.FocusedRowHandle = GridViewLookup.RowCount - 1;
                comboBoxEditMasterType.Focus();
                SetReadOnly(false);
            }
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

        private void BarButtonItemUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_selectedRecord.Position == null || _selectedRecord.Position > 0) {
                var prior = GridViewLookup.GetRow(GridViewLookup.FocusedRowHandle - 1);
                if (prior != null) {
                    RelatedProduct priorProduct = (RelatedProduct)prior;
                    if (priorProduct.Product_Code == _selectedRecord.Product_Code && priorProduct.Product_Type == _selectedRecord.Product_Type
                        && priorProduct.Position != null) {
                        priorProduct.Position += 1;
                    }
                    if (_selectedRecord.Position != null) {
                        _selectedRecord.Position -= 1;
                    }
                }
            }
        }

        private void BarButtonItemDown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_selectedRecord.ID != 0) {
                RelatedProduct nextProduct = (RelatedProduct)GridViewLookup.GetRow(GridViewLookup.FocusedRowHandle + 1);
                nextProduct.Position -= 1;
                _selectedRecord.Position += 1;
            }
        }

        private void ProductBindingSource_CurrentChanged(object sender, EventArgs e)
		{
			//If the current record is changing as a result of removing a record to delete it, and it is the last
			//record in the table, then SetBindings will clear the bindings, which will cause the delete
			//to fail because the associated entities will become detached when their BindingSources are cleared.
			//Thus we have a flag which is set in that case to ignore this event.
			if (!_ignorePositionChange)
				SetBindings();
		}

    }
}
