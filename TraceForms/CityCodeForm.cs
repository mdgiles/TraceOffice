using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FlexModel;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;
using System.Collections.Generic;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Popup;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.Win;

namespace TraceForms
{
    
    public partial class CityCodeForm : DevExpress.XtraEditors.XtraForm
    {
        public string _currentVal;
        public bool _modified = false;
        public bool _newRec = false;
        public FlextourEntities _context;
        public CITYCOD _selectedRecord;
        public Timer _actionConfirmation;
        public bool _ignoreLeaveRow = false, _ignorePositionChange = false;
        RepositoryItemImageComboBox _supplierCombo = new RepositoryItemImageComboBox();
        RepositoryItemImageComboBox _operatorCombo = new RepositoryItemImageComboBox();

        public CityCodeForm(FlexInterfaces.Core.ICoreSys sys)
        {
            try {
                InitializeComponent();
                Connect(sys);
                LoadLookups();
                SetReadOnly(true);
            }
            catch (Exception ex) {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            _context = new FlextourEntities(sys.Settings.EFConnectionString);
           // username = sys.User.Name;
        }


        private void LoadLookups()
        {
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = null };

            //EF will try to execute the entire projection on the sql side, which knows nothing about string.format so it will
            //error. Putting AsEnumerable beforehand will tell EF to execute sql side up to there and return results, then the
            //rest will be EF client side
            var lookup = new List<CodeName> {
                new CodeName(null)
            };
            lookup.AddRange(_context.CITYCOD
                            .OrderBy(o => o.CODE)
                            .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }));
            ImageComboBoxEditLinkCode.Properties.DataSource = lookup;

            imageComboBoxEditState.Properties.Items.Add(loadBlank);
            imageComboBoxEditState.Properties.Items.AddRange(_context.State
                            .OrderBy(o => o.Code).AsEnumerable()
                            .Select(s => new ImageComboBoxItem() { Description = $"{s.Code} ({s.State1})", Value = s.Code })
                            .ToList());

            imageComboBoxEditCountry.Properties.Items.Add(loadBlank);
            imageComboBoxEditCountry.Properties.Items.AddRange(_context.COUNTRY
                            .OrderBy(o => o.CODE).AsEnumerable()
                            .Select(s => new ImageComboBoxItem() { Description = $"{s.CODE} ({s.NAME})", Value = s.CODE })
                            .ToList());

            _supplierCombo.Items.Add(loadBlank);
            _supplierCombo.Items.AddRange(_context.Supplier
                            .OrderBy(o => o.Name).AsEnumerable()
                            .Select(s => new ImageComboBoxItem() { Description = s.Name, Value = s.GUID })
                            .ToList());
            gridControlSupplierCity.RepositoryItems.Add(_supplierCombo);		//per DX recommendation to avoid memory leaks

            _operatorCombo.Items.Add(loadBlank);
            _operatorCombo.Items.AddRange(_context.OPERATOR
                            .OrderBy(o => o.NAME).AsEnumerable()
                            .Select(s => new ImageComboBoxItem() { Description = $"{s.CODE} ({s.NAME})", Value = s.CODE })
                            .ToList());
            gridControlSupplierCity.RepositoryItems.Add(_operatorCombo);		//per DX recommendation to avoid memory leaks
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

        private void CityCodeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_modified || _newRec) {
                DialogResult select = DevExpress.XtraEditors.XtraMessageBox.Show("There are unsaved changes. Are you sure want to exit?", 
                    Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (select == DialogResult.Yes) {
                    e.Cancel = false;
                    Dispose();
                }
                else 
                    e.Cancel = true;
            }
            else {
                e.Cancel = false;
                Dispose();
            }
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
                    if (!_newRec) {
                        //Apparently a record which has just been added is not flagged for deletion by BindingSource.RemoveCurrent,
                        //(the EntityState remains unchanged).  It seems like it is not tracked by the context even though it is, because
                        //the EntityState changes for modification. So if this is a deletion and the entity is not flagged for deletion, 
                        //delete it manually.
                        if (_selectedRecord != null && (_selectedRecord.EntityState & EntityState.Deleted) != EntityState.Deleted)
                            _context.CITYCOD.DeleteObject(_selectedRecord);
                        _context.SaveChanges();
                    }
                    _ignoreLeaveRow = false;
                    _ignorePositionChange = false;
                    _modified = false;
                    _newRec = false;
                    if (gridViewLookup.RowCount == 0) {
                        ClearBindings();
                    }
                    SetBindings();
                    ShowActionConfirmation("Record Deleted");
                }
                _currentVal = textEditCode.Text;
            }
            catch (Exception ex) {
                string message = ex.Message;
                if (message.Contains("inner exception")) {
                    message = ex.InnerException.Message;
                }
                XtraMessageBox.Show(message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                RefreshRecord();        //pull it back from db because that is it's current state
                //We must also Load and rebind the related entities from the db because context.Refresh doesn't do that
                SetBindings();
            }
        }

        void ClearBindings()
        {
            bindingSource.DataSource = typeof(CITYCOD);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
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
                        DialogResult result = XtraMessageBox.Show("Do you want to confirm these changes?", Text, 
                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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
                    if (!ValidateAll())
                        return false;

                    if (_selectedRecord.EntityState == EntityState.Detached) {
                        _context.CITYCOD.AddObject(_selectedRecord);
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
                RefreshRecord();        //pull it back from db because that is its current state
                                        //We must also Load and rebind the related entities from the db because context.Refresh doesn't do that
                SetBindings();
                return false;
            }
        }

        private bool ValidateAll()
        {
            bool suppCitiesInvalid = false;
            if (bindingSourceSupplierCity.List.Count > 0) {
                suppCitiesInvalid = bindingSourceSupplierCity.List.Cast<SupplierCity>().Any(b => !b.Validate());
            }

            if (!_selectedRecord.Validate() || suppCitiesInvalid) {
                ShowMainControlErrors();
                XtraMessageBox.Show("Errors were found. Please resolve them and try again.",
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else {
                errorProvider.Clear();
                return true;
            }
        }

        private void ShowMainControlErrors()
        {
            //The error indicators inside the grids are handled by binding, but errors on the main form must
            //be set manually
            SetErrorInfo(_selectedRecord.ValidateCode, textEditCode);
            SetErrorInfo(_selectedRecord.ValidateName, textEditName);
            SetErrorInfo(_selectedRecord.ValidateLinkCode, ImageComboBoxEditLinkCode);
            SetErrorInfo(_selectedRecord.ValidateState, imageComboBoxEditState);
            SetErrorInfo(_selectedRecord.ValidateCountry, imageComboBoxEditCountry);
            SetErrorInfo(_selectedRecord.ValidateLatitude, spinEditLat);
            SetErrorInfo(_selectedRecord.ValidateLongitude, spinEditLong);
            SetErrorInfo(_selectedRecord.ValidateSupplierCities, gridControlSupplierCity);
        }

        private void SetErrorInfo(Func<String> validationMethod, object sender)
        {
            bindingSource.EndEdit();        //force changes back into context for validation
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
                errorProvider.SetError((Control)sender, error);
            }
        }

        private void FinalizeBindings()
        {
            bindingSource.EndEdit();
            gridViewSupplierCity.CloseEditor();
            gridViewSupplierCity.UpdateCurrentRow();
            //Set the city code for each mapping just in case
            for (int rowCtr = 0; rowCtr < gridViewSupplierCity.DataRowCount; rowCtr++) {
                SupplierCity suppCity = (SupplierCity)gridViewSupplierCity.GetRow(rowCtr);
                suppCity.Citycod_Code = textEditCode.Text;
            }
            bindingSourceSupplierCity.EndEdit();
        }

        void SetBindings()
        {
            //If the route list is filtered, there will be rows in the binding source
            //that are not visible, and they can become selected if the last visible row
            //is deleted, so handle that by checking rowcount.
            if (bindingSource.Current == null) {
                _selectedRecord = null;
                bindingSourceSupplierCity.Clear();
                SetReadOnly(true);
            }
            else {
                _selectedRecord = ((CITYCOD)bindingSource.Current);
                LoadAndBindSupplierCities();
                SetReadOnly(false);
                SetReadOnlyKeyFields(true);
            }
            errorProvider.Clear();
        }

        void LoadAndBindSupplierCities()
        {
            //Load the related entities. DO NOT do another db query using context.whatever because they
            //will not be associated with the parent entity, and new items will not be added to the relationship
            //so foreign key errors will result. Can't load the related entities on a detached or added (but not saved)
            //entity.
            if (_selectedRecord.EntityState != EntityState.Detached) {
                _selectedRecord.SupplierCity.Load(MergeOption.OverwriteChanges);
            }
            //Don't do any LINQ operations on the entitycollection, just bind directly to it, otherwise
            //it appears to bind as unassociated with the context and you have to manually add/delete
            //rows from the bindingsource to the context (but changes work fine)
            bindingSourceSupplierCity.DataSource = _selectedRecord.SupplierCity;
            BindSupplierCities();
        }

        void SetReadOnly(bool value)
        {
            foreach (Control control in splitContainerControl.Panel2.Controls) {
                control.Enabled = !value;
            }
        }

        void SetReadOnlyKeyFields(bool value)
        {
            textEditCode.ReadOnly = value;
        }

        private void ShowActionConfirmation(string confirmation)
        {
            panelControlStatus.Visible = true;
            labelStatus.Text = confirmation;
            _actionConfirmation = new Timer();
            _actionConfirmation.Interval = 3000;
            _actionConfirmation.Start();
            _actionConfirmation.Tick += TimedEvent;
        }

        private void TimedEvent(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            _actionConfirmation.Stop();
        }

        private void RemoveRecord()
        {
            if (_newRec) {
                //If you clear the bindingsource for child records where the parent entity is tracked by
                //the context, it will lose tracking for the child entities and cascade operations like
                //delete will fail
                bindingSourceSupplierCity.Clear();
            }
            //Note that cascade delete must be set on the FK in the db in order for the related
            //entities to be deleted.  This is a db function, not an EF function. However in addition
            //the model must know about the delete, otherwise the relationships in the context will
            //get messed up.  So after adding the cascade rule to the FK, the model must be updated,
            //and in order to refresh a relationship the tables must be deleted and re-added
            //Otherwise, we could do a delete loop
            //If using DbContext instead of ObjectContext, we could do eg
            //_context.SupplierCity.RemoveRange(_selectedRecord.SupplierCity)
            bindingSource.RemoveCurrent();
        }

        private void RefreshRecord()
        {
            //A Detached record has not yet been added to the context
            //An Added record has been added but not yet saved, most likely because there was
            //an error in SaveRecord, in which case we should not retrieve it from the db
            if (_selectedRecord != null && _selectedRecord.EntityState != EntityState.Detached
                && _selectedRecord.EntityState != EntityState.Added) {
                _context.Refresh(RefreshMode.StoreWins, _selectedRecord);
                SetReadOnlyKeyFields(true);
            }
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
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

        private void TextEditLinkCode_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateLinkCode, sender);
        }

        private void CityCodeForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && gridViewLookup.IsFilterRow(gridViewLookup.FocusedRowHandle)) {
                ExecuteQuery();
                e.Handled = true;
            }
        }

        private void ExecuteQuery()
        {
            Cursor = Cursors.WaitCursor;
            string colName = gridViewLookup.FocusedColumn.FieldName;
            string value = String.Empty;
            value = gridViewLookup.GetFocusedDisplayText();
            string query = "1=1";
            if (!string.IsNullOrEmpty(gridViewLookup.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"))) {
                query += String.Format(" and it.CODE like '%{0}%'", gridViewLookup.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
            }
            if (!string.IsNullOrEmpty(gridViewLookup.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "NAME"))) {
                query += String.Format(" and it.NAME like '%{0}%'", gridViewLookup.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "NAME"));
            }
            if (!string.IsNullOrEmpty(gridViewLookup.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "LINKCODE"))) {
                query += String.Format(" and it.LINKCODE like '%{0}%'", gridViewLookup.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "LINKCODE"));
            }

            var records = _context.CITYCOD.Where(query);
            if (records.Count() > 0) {
                bindingSource.DataSource = records;
                gridViewLookup.ClearColumnsFilter();
            }
            else {
                ClearBindings();
                XtraMessageBox.Show("No matching records found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Cursor = Cursors.Default;
        }

        private void longTextEdit_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateLongitude, sender);
        }

        private void latTextEdit_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateLatitude, sender);
        }

        private void zoomLevelSpinEdit_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                if (_currentVal != ((Control)sender).Text)
                    _modified = true;
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

        private void bindingSource_CurrentChanged(object sender, EventArgs e)
        {
            //If the current record is changing as a result of removing a record to delete it, and it is the last
            //record in the table, then SetBindings will clear the bindings, which will cause the delete
            //to fail because the associated entities will become detached when their BindingSources are cleared.
            //Thus we have a flag which is set in that case to ignore this event.
            if (!_ignorePositionChange)
                SetBindings();
        }

        private void imageComboBoxEditState_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateState, sender);
        }

        private void imageComboBoxEditCountry_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCountry, sender);
        }

        void BindSupplierCities()
        {
            gridControlSupplierCity.DataSource = bindingSourceSupplierCity;
            gridControlSupplierCity.RefreshDataSource();
        }

        private void buttonAddMapping_Click(object sender, EventArgs e)
        {
            SupplierCity suppCity = new SupplierCity();
            suppCity.Citycod_Code = textEditCode.Text;
            _selectedRecord.SupplierCity.Add(suppCity);
            BindSupplierCities();
            gridViewSupplierCity.FocusedRowHandle = bindingSourceSupplierCity.Count - 1;
            _modified = true;
        }

        private void buttonDeleteMapping_Click(object sender, EventArgs e)
        {
            if (gridViewSupplierCity.FocusedRowHandle >= 0) {
                SupplierCity suppCity = (SupplierCity)gridViewSupplierCity.GetFocusedRow();
                bindingSourceSupplierCity.Remove(suppCity);
                //Removing from the bindingsource just removes the object from its parent, but does not mark
                //it for deletion, effectively orphaning it.  This will cause foreign key errors when saving.
                //To flag for deletion, delete it from the context as well.
                _context.SupplierCity.DeleteObject(suppCity);
                BindSupplierCities();
                _modified = true;
            }
        }

        private void CityCodeForm_Shown(object sender, EventArgs e)
        {
            gridViewLookup.FocusedRowHandle = DevExpress.Data.CurrencyDataController.FilterRow;
            gridControlLookup.Focus();
        }

        private void gridViewLookup_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void gridViewLookup_ColumnFilterChanged(object sender, EventArgs e)
        {
            if (gridViewLookup.DataRowCount == 0) {
                ClearBindings();
            }
        }

        private void GridControlSupplierCity_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateSupplierCities, sender);
        }

        private void GridViewSupplierCity_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            _modified = true;
        }

        private void GridViewSupplierCity_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column == gridColumnSupplierGuid) { 
                e.RepositoryItem = _supplierCombo;
            }
            else if (e.Column == gridColumnOperator) {
                e.RepositoryItem = _operatorCombo;
            }
        }

        private void imageComboBoxEditState_SelectedValueChanged(object sender, EventArgs e)
        {
            ImageComboBoxEdit box = (ImageComboBoxEdit)sender;
            if (box.EditValue != null) {
                string value = box.EditValue.ToString();
                var state = _context.State.FirstOrDefault(s => s.Code == value);
                //If the state is linked to a country, default the country for the city
                if (!string.IsNullOrEmpty(state?.Country)) {
                    imageComboBoxEditCountry.EditValue = state.Country;
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

            SearchLookUpEdit currentSearch = (SearchLookUpEdit)sender;
            popupForm.Size = new Size(currentSearch.Width, 800);
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

        private void barButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _ignoreLeaveRow = true;       //so that when the grid row changes it doesn't try to save again
            if (SaveRecord(true)) {
                gridViewLookup.ClearColumnsFilter();
                _newRec = true;
                bindingSource.AddNew();
                //if (GridViewRoute.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                gridViewLookup.FocusedRowHandle = gridViewLookup.RowCount - 1;
                SetReadOnlyKeyFields(false);
                textEditCode.Focus();
                SetReadOnly(false);
            }
            errorProvider.Clear();
            _ignoreLeaveRow = false;
        }

        private void barButtonItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteRecord();
        }

        private void barButtonItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SaveRecord(false))
                RefreshRecord();
        }

        void PopupForm_KeyUp(object sender, KeyEventArgs e)
        {
            PopupSearchLookUpEditForm popupForm = sender as PopupSearchLookUpEditForm;
            if (e.KeyData == Keys.Enter) {
                if (!string.IsNullOrEmpty(popupForm.Properties.View.FindFilterText)) {
                    GridView view = popupForm.OwnerEdit.Properties.View;
                    //If there is a match is on the ValueMember (Code) column, that should take precedence
                    int row = view.LocateByValue(popupForm.OwnerEdit.Properties.ValueMember, popupForm.Properties.View.FindFilterText);
                    if (view.IsValidRowHandle(row)) {
                        view.FocusedRowHandle = row;
                    }
                    else {
                        view.FocusedRowHandle = 0;
                    }
                    popupForm.OwnerEdit.ClosePopup();
                }
            }
        }

    }
}
