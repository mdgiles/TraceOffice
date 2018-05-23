using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using FlexModel;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Popup;
using DevExpress.Utils.Win;
using DevExpress.XtraGrid.Views.Grid;
using Custom_SearchLookupEdit;

namespace TraceForms
{

	public partial class InvtMaint : DevExpress.XtraEditors.XtraForm
    {
		FlextourEntities _context;
		INVT _selectedRecord;
		Timer _actionConfirmation;
		bool _ignoreLeaveRow = false, _ignorePositionChange = false;
		Dictionary<String, List<CodeName>> _productLookups;
		bool _build;

		public InvtMaint(bool val, FlexInterfaces.Core.ICoreSys sys)
        {
			InitializeComponent();
			Connect(sys);
			LoadLookups();
			SetReadOnly(true);
			SetReadOnlyKeyFields(true);
		}

		private void Connect(FlexInterfaces.Core.ICoreSys sys)
		{
			Connection.EFConnectionString = sys.Settings.EFConnectionString;
			_context = new FlextourEntities(sys.Settings.EFConnectionString);
		}

        private void ShowOrHideBuild()
        {
            labelControlDate.Visible = !_build;
            DateEditDate.Visible = !_build;
            SpinEditBuildDays.Visible = _build;
            LabelControlBuild.Visible = _build;
            LabelControlDays.Visible = _build;
            CheckEditOverwrite.Visible = _build;
            LabelControlOver.Visible = _build;
            CheckEditSkip.Visible = _build;
            LabelControlSkips.Visible = _build;
            CheckEditSyn.Visible = _build;
            LabelControlBuildFrom.Visible = _build;
            LabelControlBuildThrough.Visible = _build;
            LabelControlBuildEvery.Visible = _build;
            DateEditBuildFrom.Visible = _build;
            DateEditBuildThrough.Visible = _build;
            ComboBoxEditBuildEvery.Visible = _build;
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
			lookup.AddRange(_context.AGY
				.OrderBy(t => t.NO)
				.Select(t => new CodeName() { Code = t.NO, Name = t.NAME }));
			SearchLookupEditRelAgency.Properties.DataSource = lookup;

			lookup = new List<CodeName>();
			lookup.AddRange(_context.ROOMCOD
				.OrderBy(t => t.CODE)
				.Select(t => new CodeName() { Code = t.CODE, Name = t.DESC }));
			SearchLookupEditCat.Properties.DataSource = lookup;

			lookup = new List<CodeName>();
			lookup.AddRange(_context.ROOMCOD
				.OrderBy(t => t.CODE)
				.Select(t => new CodeName() { Code = t.CODE, Name = t.DESC }));
			SearchLookupEditRelCat.Properties.DataSource = lookup;
		}

		void SetReadOnly(bool value)
		{
			foreach (Control control in splitContainerControl1.Panel2.Controls) {
				control.Enabled = !value;
			}
		}

		void SetReadOnlyKeyFields(bool value)
		{
			SearchLookupEditCode.ReadOnly = value;
			ComboBoxEditType.ReadOnly = value;
			SearchLookupEditAgency.ReadOnly = value;
			SearchLookupEditCat.ReadOnly = value;
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
				&& _selectedRecord.EntityState != EntityState.Added) {
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
						_context.INVT.AddObject(_selectedRecord);
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

		private bool IsModified(INVT record)
		{
			//Type-specific routine that takes into account relationships that should also be considered
			//when deciding if there are unsaved changes.  The entity properties also return true if the
			//record is new or deleted.
			if (record == null)
				return false;
			return record.IsModified(_context);
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
			//The error indicators inside the grids are handled by binding, but errors on the main form must
			//be set manually
			SetErrorInfo(_selectedRecord.ValidateCode, SearchLookupEditCode);
			SetErrorInfo(_selectedRecord.ValidateType, ComboBoxEditType);
			SetErrorInfo(_selectedRecord.ValidateCat, SearchLookupEditCat);
			SetErrorInfo(_selectedRecord.ValidateAgency, SearchLookupEditAgency);
			SetErrorInfo(_selectedRecord.ValidateRelCode, SearchLookupEditRelCode);
			SetErrorInfo(_selectedRecord.ValidateRelCat, SearchLookupEditRelCat);
			SetErrorInfo(_selectedRecord.ValidateRelAgency, SearchLookupEditRelAgency);
			SetErrorInfo(_selectedRecord.ValidateMin, SpinEditMin);
			SetErrorInfo(_selectedRecord.ValidateMax, SpinEditMax);
			SetErrorInfo(_selectedRecord.ValidateMinBkDays, SpinEditMinBkDays);
			SetErrorInfo(_selectedRecord.ValidateHold, SpinEditHold);
			SetErrorInfo(_selectedRecord.ValidateAv, ComboBoxEditAv);
			SetErrorInfo(_selectedRecord.ValidateCanc, SpinEditCanc);
			SetErrorInfo(_selectedRecord.ValidateOrigAmt, SpinEditOrigAmt);
			SetErrorInfo(_selectedRecord.ValidateAlloctd, SpinEditAlloctd);
			SetErrorInfo(_selectedRecord.ValidateRelDays, SpinEditRel);
		}

		private void SetErrorInfo(Func<String> validationMethod, object sender)
		{
			BindingSource.EndEdit();        //force changes back into context for validation
			if (validationMethod != null) {
				string error = validationMethod.Invoke();
				ErrorProvider.SetError((Control)sender, error);
			}
		}

		private void FinalizeBindings()
		{
			BindingSource.EndEdit();
		}

		void SetBindings()
		{
			if (BindingSource.Current == null) {
				ClearBindings();
			}
			else {
				_selectedRecord = ((INVT)BindingSource.Current);
				SetReadOnly(false);
				SetReadOnlyKeyFields(true);
				BarButtonItemDelete.Enabled = true;
				BarButtonItemSave.Enabled = true;
			}
			ErrorProvider.Clear();
		}

		private void DeleteRecord()
		{
			if (_selectedRecord == null)
				return;

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
							_context.INVT.DeleteObject(_selectedRecord);
						_context.SaveChanges();
					}
					if (GridViewLookup.DataRowCount == 0) {
						ClearBindings();
					}
					_ignoreLeaveRow = false;
					_ignorePositionChange = false;
					SetBindings();
					EntityInstantFeedbackSource.Refresh();
					ShowActionConfirmation("Record Deleted");
				}
			}
			catch (Exception ex) {
				DisplayHelper.DisplayError(this, ex);
				_ignoreLeaveRow = false;
				_ignorePositionChange = false;
				RefreshRecord();        //pull it back from db because that is it's current state
										//We must also Load and rebind the related entities from the db because context.Refresh doesn't do that
				SetBindings();
			}
		}

		void ClearBindings()
		{
			_ignoreLeaveRow = true;
			_ignorePositionChange = true;
			_selectedRecord = null;
			SetReadOnly(true);
			BarButtonItemDelete.Enabled = false;
			BarButtonItemSave.Enabled = false;
			BindingSource.DataSource = typeof(INVT);
			_ignoreLeaveRow = false;
			_ignorePositionChange = false;
		}


		//private void efSrc_GetQueryable(object sender, GetQueryableEventArgs e)
		//{
		//    FlextourEntities context = new FlextourEntities(_sys.Settings.EFConnectionString);
		//    e.QueryableSource = context.INVT;
		//    e.Tag = context;
		//}

		//private void efSrc_DismissQueryable(object sender, GetQueryableEventArgs e)
		//{
		//    ((FlextourEntities)e.Tag).Dispose();
		//}

		private void advBandedGridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            //if ((e.FocusedRowHandle >= 0) && (!GridViewInvt.IsGroupRow(e.FocusedRowHandle)))
            //{
            //    EditItem(e.FocusedRowHandle);
            //}
        }

		private void InvMaint_Load(object sender, EventArgs e)
        {


            /// change the rmcabin to readonly true on selection of type
        }

        private void advBandedGridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }

        private void InvMaint_FormClosing(object sender, FormClosingEventArgs e)
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

        private void ComboBoxEditType_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateType, sender);
		}

        private void ComboBoxEditAv_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateAv, sender);
		}

        private void SpinEditMax_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateMax, sender);
		}

        private void SpinEditMin_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateMin, sender);
		}

        private void SpinEditCanc_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateCanc, sender);
		}

        private void SpinEditMinBkDays_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateMinBkDays, sender);
		}

        private void SpinEditOrigAmt_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateOrigAmt, sender);
		}

        private void SpinEditAlloctd_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateAlloctd, sender);
		}

        private void SpinEditAvAmt_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateAvAmt, sender);
		}

        private void SpinEditHold_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateHold, sender);
		}

        private void SpinEditRel_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateRelDays, sender);
		}

        private void ComboBoxEditRelTyp_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateRelTyp, sender);
		}

        private void ComboBoxEditTp_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateRmCab, sender);
		}

        private void CheckEditSyn_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckEditSyn.Checked == true)
            {
                SpinEditOrigAmt.Properties.ReadOnly = true;
            }
            if (CheckEditSyn.Checked == false)
            {
                SpinEditOrigAmt.Properties.ReadOnly = false;               
            }
        }

        private void dateEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void dateEdit2_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void dATEDateEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void InvMaint_KeyDown(object sender, KeyEventArgs e)
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
			foreach (GridColumn col in GridViewLookup.VisibleColumns) {
				string value = GridViewLookup.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, col.FieldName);
				if (!string.IsNullOrEmpty(value)) {
					query += $" and it.{col.FieldName} like '%{value}%'";
				}
			}

			var records = _context.INVT.Where(query);
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

		//private bool BuildForms()
		//{

		//}

		private void SearchLookupEditCode_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateCode, sender);
		}

        private void SearchLookupEditAgency_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateAgency, sender);
		}

        private void SearchLookupEditCat_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateCat, sender);
		}

        private void SearchLookupEditRelCode_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateRelCode, sender);
		}

        private void SearchLookupEditRelAgency_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateRelAgency, sender);
		}

        private void SearchLookupEditRelCat_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null)
				SetErrorInfo(_selectedRecord.ValidateRelCat, sender);
		}

        private void InvtBindingSource_CurrentChanged(object sender, EventArgs e)
        {
			//If the current record is changing as a result of removing a record to delete it, and it is the last
			//record in the table, then SetBindings will clear the bindings, which will cause the delete
			//to fail because the associated entities will become detached when their BindingSources are cleared.
			//Thus we have a flag which is set in that case to ignore this event.
			if (!_ignorePositionChange)
				SetBindings();
		}

        private void aV_AMTSpinEdit_ValueChanged(object sender, EventArgs e)
        {
            if (CheckEditSyn.Checked == true)
            {
                SpinEditOrigAmt.Value = SpinEditAv_Amt.Value;
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

		private void ComboBoxEditType_SelectedValueChanged(object sender, EventArgs e)
		{
			ComboBoxEditTP.Enabled = (ComboBoxEditType.Text == "HTL");
			if (ComboBoxEditType.Text == "PKG") {
				ComboBoxEditTP.Text = "NON";
			}
			else if (ComboBoxEditType.Text != "HTL") {
				ComboBoxEditTP.Text = string.Empty;
			}
			string type = ComboBoxEditType.Text;
			if (type != null) {			
				LoadCodeLookupValues(type, SearchLookupEditCode);
				LoadCodeLookupValues(type, SearchLookupEditRelCode);
			}
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

		private void BarButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			_ignoreLeaveRow = true;       //so that when the grid row changes it doesn't try to save again
			if (SaveRecord(true)) {
				_selectedRecord = new INVT();
				BindingSource.Add(_selectedRecord);
				GridViewLookup.FocusedRowHandle = GridViewLookup.FindRow(_selectedRecord);
				SetReadOnlyKeyFields(false);
				ComboBoxEditType.Focus();
				SetReadOnly(false);
			}
			ErrorProvider.Clear();
			_ignoreLeaveRow = false;
		}

		private void BarButtonItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			DeleteRecord();
		}

		private void CheckEditSync_CheckedChanged(object sender, EventArgs e)
		{
			SearchLookupEditRelCode.Enabled = CheckEditSync.Checked;
			if (!CheckEditSync.Checked){
				SearchLookupEditRelCode.EditValue = null;
			}
			ComboBoxEditRelTyp.Enabled = CheckEditSync.Checked;
			if (!CheckEditSync.Checked) {
				ComboBoxEditRelTyp.EditValue = null;
			}
			SearchLookupEditRelCat.Enabled = CheckEditSync.Checked;
			if (!CheckEditSync.Checked) {
				SearchLookupEditRelCat.EditValue = null;
			}
			SearchLookupEditRelAgency.Enabled = CheckEditSync.Checked;
			if (!CheckEditSync.Checked) {
				SearchLookupEditRelAgency.EditValue = null;
			}
			SpinEditRel.Enabled = CheckEditSync.Checked;
			if (!CheckEditSync.Checked) {
				SpinEditRel.EditValue = null;
			}
		}

		private void ComboBoxEditAv_SelectedValueChanged(object sender, EventArgs e)
		{
			if (ComboBoxEditAv.Text == "R") {
				foreach (Control control in GroupControlRelease.Controls) {
					control.Enabled = false;
				}

				foreach (Control control in GroupControlQuantities.Controls) {
					control.Enabled = false;
				}
			}

			else if (ComboBoxEditAv.Text == "Q") {
				foreach (Control control in GroupControlRelease.Controls) {
					control.Enabled = false;
				}

				foreach (Control control in GroupControlQuantities.Controls) {
					control.Enabled = false;
				}
			}

			else {
				foreach (Control control in GroupControlRelease.Controls) {
					control.Enabled = true;
				}

				foreach (Control control in GroupControlQuantities.Controls) {
					control.Enabled = true;
				}
			}
		}

		private void BarButtonItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (SaveRecord(false))
				RefreshRecord();
		}
	}
}