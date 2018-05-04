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
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.Win;

namespace TraceForms
{
    
    public partial class CxlFeeForm : DevExpress.XtraEditors.XtraForm
    {
		FlextourEntities _context;
		CXLFEE _selectedRecord;
		Timer _actionConfirmation;
		bool _ignoreLeaveRow = false, _ignorePositionChange = false;
		Dictionary<String, List<CodeName>> _productLookups;
        string _username;

        public CxlFeeForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
            LoadLookups();
			SetReadOnly(true);
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
			Connection.EFConnectionString = sys.Settings.EFConnectionString;
			_context = new FlextourEntities(sys.Settings.EFConnectionString);
            _username = sys.User.Name;
        }

        void SetReadOnly(bool value)
		{
			foreach (Control control in SplitContainerControl.Panel2.Controls)
			{
				control.Enabled = !value;
			}
		}

		private void LoadLookups()
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
			lookup.AddRange(_context.COMP
				.OrderBy(t => t.CODE)
				.Select(t => new CodeName() { Code = t.CODE, Name = t.NAME }));
			_productLookups.Add("OPT", lookup);

			lookup = new List<CodeName>();
			lookup.AddRange(_context.PACK
				.OrderBy(t => t.CODE)
				.Select(t => new CodeName() { Code = t.CODE, Name = t.NAME }));
			_productLookups.Add("PKG", lookup);

			lookup = new List<CodeName>();
			lookup.AddRange(_context.AGY
				.OrderBy(t => t.NO)
				.Select(t => new CodeName() { Code = t.NO, Name = t.NAME }));
			SearchLookupEditAgency.Properties.DataSource = lookup;

			lookup = new List<CodeName>();
			lookup.AddRange(_context.ROOMCOD
				.OrderBy(t => t.CODE)
				.Select(t => new CodeName() { Code = t.CODE, Name = t.DESC }));
			SearchLookupEditCategory.Properties.DataSource = lookup;
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

		private void PopupForm_KeyUp(object sender, KeyEventArgs e)
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

		private void SearchLookupEdit_UpdateDisplayFilter(object sender, Custom_SearchLookupEdit.DisplayFilterEventArgs e)
		{
			//Users did not like have to type quotes in order to get an exact match of entered terms rather than any word being matched
			//https://www.devexpress.com/Support/Center/Example/Details/E3135/how-to-implement-an-event-allowing-you-to-customize-a-filter-string-produced-by-the-find
			//Also requires the custom inherited version of the SearchLookupEdit in the Custom_SearchLookupEdit namespace
			if (!string.IsNullOrEmpty(e.FilterText)) {
				e.FilterText = '"' + e.FilterText + '"';
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
						_context.CXLFEE.AddObject(_selectedRecord);
					}
                    SetUpdateFields(_selectedRecord);
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

        private void SetUpdateFields(CXLFEE record)
        {
            record.LAST_UPD = DateTime.Now;
            record.UPD_INIT = _username;
        }

        private bool IsModified(CXLFEE record)
		{
			//Type-specific routine that takes into account relationships that should also be considered
			//when deciding if there are unsaved changes.  The entity properties also return true if the
			//record is new or deleted.
			return record.IsModified(_context);
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
				_selectedRecord = ((CXLFEE)BindingSource.Current);
				SetReadOnly(false);
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
			SetErrorInfo(_selectedRecord.ValidateCode, SearchLookupEditCode);
			SetErrorInfo(_selectedRecord.ValidateType, ComboBoxEditType);
			SetErrorInfo(_selectedRecord.ValidateAgency, SearchLookupEditAgency);
			SetErrorInfo(_selectedRecord.ValidateCat, SearchLookupEditCategory);
			SetErrorInfo(_selectedRecord.ValidateStart, DateEditStartDate);
			SetErrorInfo(_selectedRecord.ValidateEnd, DateEditEndDate);
			SetErrorInfo(_selectedRecord.ValidateNts, SpinEditNtsPrior);
			SetErrorInfo(_selectedRecord.ValidateCxlDate, DateEditOnAfterDate);
			SetErrorInfo(_selectedRecord.ValidateNbrNts, SpinEditNbrNts);
			SetErrorInfo(_selectedRecord.ValidatePctAmt, SpinEditPctAmt);
			SetErrorInfo(_selectedRecord.ValidateFlatFee, SpinEditFlatFee);
			SetErrorInfo(_selectedRecord.ValidateTimeAfter, SpinEditTimeAfter);
			SetErrorInfo(_selectedRecord.ValidateTimeBasis, ImageComboBoxEditTimeBasis);
			SetErrorInfo(_selectedRecord.ValidateTimeUnits, ImageComboBoxEditTimeUnits);
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

		private void DeleteRecord()
		{
			if (_selectedRecord == null)
				return;

			try {
				if (DisplayHelper.QuestionYesNo(this, "Are you sure you want to delete this record?") == DialogResult.Yes) {
					_ignoreLeaveRow = true;
					_ignorePositionChange = true;
					RemoveRecord();
					if (!_selectedRecord.IsNew()) {
						//Apparently a record which has just been added is not flagged for deletion by BindingSource.RemoveCurrent,
						//(the EntityState remains unchanged).  It seems like it is not tracked by the context even though it is, because
						//the EntityState changes for modification. So if this is a deletion and the entity is not flagged for deletion, 
						//delete it manually.
						if (_selectedRecord != null && (_selectedRecord.EntityState & EntityState.Deleted) != EntityState.Deleted)
							_context.CXLFEE.DeleteObject(_selectedRecord);
						_context.SaveChanges();
					}
					if (GridViewLookup.RowCount == 0) {
						ClearBindings();
					}
					_ignoreLeaveRow = false;
					_ignorePositionChange = false;
					SetBindings();
					ShowActionConfirmation("Record Deleted");
				}
			}
			catch (Exception ex) {
				DisplayHelper.DisplayError(this, ex);
				RefreshRecord();        //pull it back from db because that is it's current state
										//We must also Load and rebind the related entities from the db because context.Refresh doesn't do that
				SetBindings();
			}
		}

		void ClearBindings()
		{
			BindingSource.DataSource = typeof(CXLFEE);
		}


		private void CxlFeeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
			if (IsModified(_selectedRecord)) {
				DialogResult select = DisplayHelper.QuestionYesNo(this, "There are unsaved changes. Are you sure you want to exit?");
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

        private void GridViewLookup_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }

        private void ComboBoxEditType_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateType, sender);
		}

        private void DateEditStartDate_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateStart, sender);
		}

        private void DateEditEndDate_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateEnd, sender);
		}

        private void SpinEditNtsPrior_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateNts, sender);
		}

        private void DateEditCxlDate_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateCxlDate, sender);
		}

        private void SpinEditNbrNts_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateNbrNts, sender);
		}

        private void TextEditPctAmt_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidatePctAmt, sender);
		}

        private void TextEditFlatFee_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateFlatFee, sender);
		}

        private void ComboBoxEditType_TextChanged(object sender, EventArgs e)
        {
			string type = ComboBoxEditType.Text;
			LoadCodeLookupValues(type, SearchLookupEditCode);
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

		private void CxlFeeForm_KeyDown(object sender, KeyEventArgs e)
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
					query += $" and it.[{col.FieldName}] like '%{value}%'";
				}
			}

			var records = _context.CXLFEE.Where(query);
			if (records.Count() > 0) {
				BindingSource.DataSource = records;
				GridViewLookup.ClearColumnsFilter();
			}
			else {
				ClearBindings();
				DisplayHelper.DisplayInfo(this, "No matching records found.");
			}
			Cursor = Cursors.Default;
		}

		private void SearchLookupEditCode_Leave(object sender, System.EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateCode, sender);
		}

        private void SearchLookupEditAgency_Leave(object sender, System.EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateAgency, sender);
		}

        private void SearchLookupEditCategory_Leave(object sender, System.EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateCat, sender);
		}

		private void ImageComboBoxEditTimeBasis_Leave(object sender, EventArgs e)
		{
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateCat, sender);
		}

		private void ImageComboBoxEditTimeUnits_Leave(object sender, EventArgs e)
		{
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateCat, sender);
		}

		private void SpinEditTimeAfter_Leave(object sender, EventArgs e)
		{
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateCat, sender);
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

		private void BarButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			_ignoreLeaveRow = true;       //so that when the grid row changes it doesn't try to save again
			if (SaveRecord(true)) {
				GridViewLookup.ClearColumnsFilter();    //so that the new record will show even if it doesn't match the filter
				BindingSource.AddNew();
				//if (GridViewRoute.FocusedRowHandle == GridControl.AutoFilterRowHandle)
				GridViewLookup.FocusedRowHandle = GridViewLookup.RowCount - 1;
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

		private void CheckEditNoShow_CheckedChanged(object sender, EventArgs e)
		{
			/*
____ on an add or change - if there is an number in nights prior and the no-show checkbox is checked the number 
* of nights should change to -1 and on/after date is also greyed and blanked. 

Here is the behavior of the Nights Prior field, NoShow checkbox and on/after date. 
If the checkbox is checked then nights prior is  filled with ‘-1’ and on/after date is also greyed and blanked. 
If the checkbox is unchecked, nights prior and on/after date are enabled for entry.  

*/
			//If changes aren't forced back into the context, then when the context PropertyChanged event fires
			//when changing the value of the other checkbox, this checkbox will rebind to its prior value which
			//is not yet in the context. 
			BindingSource.EndEdit();
			if (CheckEditNoShow.Checked) {
				SpinEditNtsPrior.EditValue = -1;
				DateEditOnAfterDate.EditValue = null;
				DateEditOnAfterDate.Enabled = false;
				SpinEditNtsPrior.Enabled = false;
			}
			else {
				SpinEditNtsPrior.Enabled = true;
				DateEditOnAfterDate.Enabled = true;
				if (SpinEditNtsPrior.Value == -1)
					SpinEditNtsPrior.EditValue = 0;
			}
		}

		private void SpinEditNtsPrior_EditValueChanged(object sender, EventArgs e)
		{
			CheckEditNoShow.Checked = (SpinEditNtsPrior.Value == -1);
		}

		private void BarButtonItemExpandContractGrid_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (BarButtonItemExpandContractGrid.Tag.ToString() == "contracted")
			{
				BarButtonItemExpandContractGrid.Tag = "expanded";
				GridViewLookup.Columns["AGENCY"].Visible = true;
				GridViewLookup.Columns["AGENCY"].VisibleIndex = 4;
				GridViewLookup.Columns["NTS_PRIOR"].Visible = true;
				GridViewLookup.Columns["NTS_PRIOR"].VisibleIndex = 5;
				//AdvBandedGridViewHrates.Columns["CAT"].Width = 35;
				GridViewLookup.Columns["CODE"].Width = 65;
			}
			else
			{
				BarButtonItemExpandContractGrid.Tag = "contracted";
				//AdvBandedGridViewHrates.Columns["CAT"].Visible = false;
				GridViewLookup.Columns["AGENCY"].Visible = false;
				GridViewLookup.Columns["NTS_PRIOR"].Visible = false;
				//AdvBandedGridViewHrates.Columns["SvcDate_End"].Visible = false;
			}
		}
	}
}