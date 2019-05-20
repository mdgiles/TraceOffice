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
using DevExpress.Data.Async.Helpers;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects.DataClasses;

namespace TraceForms
{
	public partial class InvtMaint : DevExpress.XtraEditors.XtraForm
    {
		FlextourEntities _context;
		INVT _selectedRecord;
		Timer _actionConfirmation;
		bool _ignoreLeaveRow = false, _ignorePositionChange = false;
		Dictionary<String, List<CodeName>> _productLookups;
        FlexInterfaces.Core.ICoreSys _sys;

        public InvtMaint(bool val, FlexInterfaces.Core.ICoreSys sys)
        {
            try {
                InitializeComponent();
                Connect(sys);
                LoadLookups();
                _sys = sys;
                SetReadOnly(true);
                SetReadOnlyKeyFields(true);
            }
            catch (Exception ex) {
                DisplayHelper.DisplayError(this, ex);
            }
		}

		private void Connect(FlexInterfaces.Core.ICoreSys sys)
		{
			Connection.EFConnectionString = sys.Settings.EFConnectionString;
			_context = new FlextourEntities(sys.Settings.EFConnectionString);
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
			SearchLookupEditCat.Properties.DataSource = lookup;

			lookup = new List<CodeName>();
			lookup.AddRange(_context.ROOMCOD
				.OrderBy(t => t.CODE)
				.Select(t => new CodeName() { Code = t.CODE, Name = t.DESC }));
			SearchLookupEditRelCat.Properties.DataSource = lookup;

            SearchLookupEditRelCode.Properties.DataSource = null;
            SearchLookupEditCode.Properties.DataSource = null;

            var specialVals = _context.SpecialValue.OrderBy(x => x.Code)
            .Select(x => new CodeName() { Code = x.Code, Name = x.Name }).ToList();
            specialVals.Insert(0, new CodeName());
            SearchLookupEditSpecialValue.Properties.DataSource = specialVals;

            SpinEditStartNumber.EditValue = null;
        }

        void SetReadOnly(bool value)
		{
			foreach (Control control in SplitContainerControl.Panel2.Controls) {
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
                    SetUpdateFields(_selectedRecord);
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

        private void SetUpdateFields(INVT record)
        {
            record.UPD_DATE = DateTime.Now;
            record.UPD_BY = _sys.User.Name;
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
			if (!_selectedRecord.Validate(BarToggleSwitchItemBuild.Checked)) {
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
            if (BarToggleSwitchItemBuild.Checked) {
                SetErrorInfo(ValidateBuildFrom, DateEditBuildFrom);
                SetErrorInfo(ValidateBuildThrough, DateEditBuildThrough);
                SetErrorInfo(ValidateBuildEvery, ComboBoxEditBuildEvery);
                SetErrorInfo(ValidateBuildDays, SpinEditBuildDays);
            }
            else {
                SetErrorInfo(_selectedRecord.ValidateDate, DateEditDate);
            }
            SetErrorInfo(_selectedRecord.ValidateCode, SearchLookupEditCode);
            SetErrorInfo(_selectedRecord.ValidateType, ComboBoxEditType);
            SetErrorInfo(_selectedRecord.ValidateCat, SearchLookupEditCat);
            SetErrorInfo(_selectedRecord.ValidateRmCab, ComboBoxEditTP);
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
            SetErrorInfo(_selectedRecord.ValidateAvAmt, SpinEditAvAmt);
            SetErrorInfo(_selectedRecord.ValidateAlloctd, SpinEditAlloctd);
            SetErrorInfo(_selectedRecord.ValidateRelDays, SpinEditRel);
            SetErrorInfo(_selectedRecord.ValidateRelRmCab, ComboBoxEditRelTyp);
            SetErrorInfo(_selectedRecord.ValidateSpecialValue, SearchLookupEditSpecialValue);
            SetErrorInfo(_selectedRecord.ValidateStartNumber, SpinEditStartNumber);
            SetErrorInfo(_selectedRecord.ValidateEndNumber, SpinEditEndNumber);
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

        private void AdvBandedGridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }

        private void InvMaint_FormClosing(object sender, FormClosingEventArgs e)
        {
			if (!BarToggleSwitchItemBuild.Checked && IsModified(_selectedRecord)) 
			{
                DialogResult select = DisplayHelper.QuestionYesNo(this, "There are unsaved changes. Are you sure want to exit?");
                if (select == DialogResult.Yes) {
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
            if (ComboBoxEditType != null) {
                if (ComboBoxEditType.Text != "HTL") {
                    ComboBoxEditTP.Enabled = false;
                }
                else if (ComboBoxEditType.Text == "HTL") {
                    ComboBoxEditTP.Enabled = true;
                }
            }
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
				SetErrorInfo(_selectedRecord.ValidateRelRmCab, sender);
		}

        private void ComboBoxEditTp_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null) {
                SetErrorInfo(_selectedRecord.ValidateRmCab, sender);
                //The validation for the release field is called here when CheckEditSync is checked because
                //the leave event is never triggered for the release fields when CheckEditSync is checked,
                //since the fields are not enabled, and therefore cannot be entered or left.
                if (CheckEditSync.Checked) {
                    SetErrorInfo(_selectedRecord.ValidateRelRmCab, ComboBoxEditRelTyp);
                }
            }
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

		private void SearchLookupEditCode_Leave(object sender, EventArgs e)
        {
			if (_selectedRecord != null) {
                SetErrorInfo(_selectedRecord.ValidateCode, sender);
                //The validation for the release field is called here when CheckEditSync is checked because
                //the leave event is never triggered for the release fields when CheckEditSync is checked,
                //since the fields are not enabled, and therefore cannot be entered or left.
                if (CheckEditSync.Checked) {
                    SetErrorInfo(_selectedRecord.ValidateRelCode, SearchLookupEditRelCode);
                }
            }
		}

        private void SearchLookupEditAgency_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null) {
                SetErrorInfo(_selectedRecord.ValidateAgency, sender);
                //The validation for the release field is called here when CheckEditSync is checked because
                //the leave event is never triggered for the release fields when CheckEditSync is checked,
                //since the fields are not enabled, and therefore cannot be entered or left.
                if (CheckEditSync.Checked) {
                    SetErrorInfo(_selectedRecord.ValidateRelAgency, SearchLookupEditRelAgency);
                }
            }
        }

        private void SearchLookupEditCat_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null) {
                SetErrorInfo(_selectedRecord.ValidateCat, sender);
                //The validation for the release field is called here when CheckEditSync is checked because
                //the leave event is never triggered for the release fields when CheckEditSync is checked,
                //since the fields are not enabled, and therefore cannot be entered or left.
                if (CheckEditSync.Checked) {
                    SetErrorInfo(_selectedRecord.ValidateRelCat, SearchLookupEditRelCat);
                }
            }
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

        private void DateEditDate_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateDate, sender);
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

        private void Av_AmtSpinEdit_ValueChanged(object sender, EventArgs e)
        {
            if (CheckEditSyn.Checked == true)
            {
                SpinEditOrigAmt.Value = SpinEditAvAmt.Value;
            }
        }

		private void GridViewLookup_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
		{
			//If the user selects a row, edits, then selects the auto-filter row, then selects a different row,
			//this event will fire for the auto-filter row, so we cannot ignore it because there is still a record
			//that may need to be saved. 
			if (!_ignoreLeaveRow && IsModified(_selectedRecord)) {
				e.Allow = SaveRecord(true);
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
			if (e.KeyData == Keys.Enter && popupForm != null) {
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
				ComboBoxEditTP.EditValue = "NON";
            }
            else if (ComboBoxEditType.Text != "HTL") {
				ComboBoxEditTP.EditValue = string.Empty;
			}
            string type = ComboBoxEditType.Text;
			LoadCodeLookupValues(type, SearchLookupEditCode);
			LoadCodeLookupValues(type, SearchLookupEditRelCode);
		}

        private void GridViewLookup_ColumnFilterChanged(object sender, EventArgs e)
        {
            if (GridViewLookup.DataRowCount == 0) {
                ClearBindings();
            }
        }

        private void LoadCodeLookupValues(string type, CustomSearchLookUpEdit editor)
		{
			if (!string.IsNullOrEmpty(type) && _productLookups.ContainsKey(type)) {
				editor.Properties.DataSource = _productLookups[type];
			}
			else {
				editor.Properties.DataSource = null;
			}
		}

		private void CreateNewRecord()
		{
			_ignoreLeaveRow = true;       //so that when the grid row changes it doesn't try to save again
            if (SaveRecord(true)) {
                //For some reason when there is no existing record in the binding source the Add method does not
                //trigger the CurrentChanged event, but AddNew does so use that instead
                BindingSource.AddNew();
                //With the instant feedback data source, the new row is not immediately added to the grid, so move
                //the focused row to the filter row just so that no other existing row is visually highlighted
                GridViewLookup.FocusedRowHandle = DevExpress.Data.BaseListSourceDataController.FilterRow;
                SetReadOnlyKeyFields(false);
				ComboBoxEditType.Focus();
				SetReadOnly(false);
			}
			ErrorProvider.Clear();
            SetBuildMode(false);
			_ignoreLeaveRow = false;
		}

        private INVT CreateFilledRecord(INVT source, DateTime date)
        {
            INVT invt = new INVT();
            FillRecord(invt, source, date);
            _context.INVT.AddObject(invt);
            return invt;
        }

        private void FillRecord(INVT dest, INVT source, DateTime date)
        {
            dest.DATE = date;
            dest.TYPE = source.TYPE;
            dest.CODE = source.CODE;
            dest.CAT = source.CAT;
            dest.TP = source.TP;
            dest.UPD_DATE = source.UPD_DATE;
            dest.UPD_BY = source.UPD_BY;
            dest.ORIG_AMT = source.ORIG_AMT;
            dest.AV_AMT = source.AV_AMT;
            dest.AV = source.AV;
            dest.MIN = source.MIN;
            dest.CANC = source.CANC;
            dest.REL = source.REL;
            dest.AGENCY = source.AGENCY;
            dest.RELCODE = source.RELCODE;
            dest.RELCAT = source.RELCAT;
            dest.RELTYP = source.RELTYP;
            dest.RELAGY = source.RELAGY;
            dest.ALLOCTD = source.ALLOCTD;
            dest.HOLD = source.HOLD;
            dest.MIN_BK_DAYS = source.MIN_BK_DAYS;
            dest.MAX = source.MAX;
            dest.Requestable = source.Requestable;
            dest.StartNumberRange = source.StartNumberRange;
            dest.EndNumberRange = source.EndNumberRange;
            dest.Time = source.Time;
            dest.SpecialValue_Code = source.SpecialValue_Code;
        }

		private void CheckEditSync_CheckedChanged(object sender, EventArgs e)
		{
			SearchLookupEditRelCode.Enabled = !CheckEditSync.Checked;
			if (!CheckEditSync.Checked){
				SearchLookupEditRelCode.EditValue = null;
			}
			ComboBoxEditRelTyp.Enabled = !CheckEditSync.Checked;
			if (!CheckEditSync.Checked) {
				ComboBoxEditRelTyp.EditValue = null;
			}
			SearchLookupEditRelCat.Enabled = !CheckEditSync.Checked;
			if (!CheckEditSync.Checked) {
				SearchLookupEditRelCat.EditValue = null;
			}
			SearchLookupEditRelAgency.Enabled = !CheckEditSync.Checked;
			if (!CheckEditSync.Checked) {
				SearchLookupEditRelAgency.EditValue = null;
			}
            if (CheckEditSync.Checked) {
                SearchLookupEditRelCode.EditValue = SearchLookupEditCode.EditValue;
                SearchLookupEditRelCat.EditValue = SearchLookupEditCat.EditValue;
                ComboBoxEditRelTyp.EditValue = ComboBoxEditTP.EditValue;
                SearchLookupEditRelAgency.EditValue = SearchLookupEditAgency.EditValue;
            }
        }

		public bool BuildRecords()
		{
			int days = 0;
			DateTime date;

            SetUpdateFields(_selectedRecord);
			do {
                INVT newRec = null;
                date = DateEditBuildFrom.DateTime.AddDays(days);
				if (int.TryParse(ComboBoxEditBuildEvery.Text, out int everyDays)) {
                    if (days == everyDays)
                    {
                        int buildDays = 0;
                        do
                        {  //Build the specified number of days while build days is less than the value of SpinEditBuildDays
                            date = DateEditBuildFrom.DateTime.AddDays(days);
                            newRec = CreateFilledRecord(_selectedRecord, date);
                            if (!SaveContext(newRec, date))
                                return false;
                            buildDays++;
                            days++;
                        } while (buildDays < (int)SpinEditBuildDays.Value);
                    }
                }
                else if (Enum.TryParse(ComboBoxEditBuildEvery.Text, out DayOfWeek dayOfWeek)) {  //If the "build every" field is a day of the week
                    if (date.DayOfWeek == dayOfWeek) {  //If the current date is the same day of the week as the "build every" day of the week
                        int buildDays = 0;
                        do {  //Build the specified number of days while build days is less than the value of SpinEditBuildDays
                            date = DateEditBuildFrom.DateTime.AddDays(days);
                            newRec = CreateFilledRecord(_selectedRecord, date);
                            if (!SaveContext(newRec, date))
                                return false;
                            buildDays++;
                            days++;
                        } while (buildDays < (int)SpinEditBuildDays.Value);
                    }
                    else {
                        days++;
                    }
                }
                else {
					newRec = CreateFilledRecord(_selectedRecord, date);
                    if (!SaveContext(newRec, date))
                        return false;
                    days++;
				}
            } while (date < DateEditBuildThrough.DateTime);
            ShowActionConfirmation("Records built");
            return true;
        }

        private bool SaveContext(INVT rec, DateTime date)
        {
            try {
                _context.SaveChanges();
                return true;
            }
            catch (UpdateException) {
                _context.INVT.DeleteObject(rec);
                if (CheckEditSkip.Checked) {
                    return true;
                }
                if (CheckEditOverwrite.Checked) {
                    INVT existing = _context.INVT.First(i => i.TYPE == _selectedRecord.TYPE && i.CODE == _selectedRecord.CODE &&
                        i.AGENCY == _selectedRecord.AGENCY && i.CAT == _selectedRecord.CAT &&
                        i.TP == _selectedRecord.TP && i.DATE == date);
                    FillRecord(existing, _selectedRecord, date);
                    try {
                        _context.SaveChanges();
                    }
                    catch (Exception ex) {
                        this.DisplayError(ex);
                        return false;
                    }
                    return true;
                }
                this.DisplayError("Records were found with the same values as the values being built. Build has been cancelled.");
                return false;
            }
            catch (Exception ex) {
                this.DisplayError(ex);
                return false;
            }
        }

        public string ValidateBuildDays()
		{
            if (SpinEditBuildDays.Value <= 0) {
                return "Please fill in this field.";
            }

            if (int.TryParse(ComboBoxEditBuildEvery.Text, out int everyDays)) {
                if (everyDays < (int)SpinEditBuildDays.Value) {
                    return $"The number of days to build cannot be greater than {everyDays}.";
                }
            }

            if (Enum.TryParse(ComboBoxEditBuildEvery.Text, out DayOfWeek dayOfWeek)) {
                if (SpinEditBuildDays.Value > 7) {
                    return "The number of days to build cannot be greater than seven.";
                }
            }

			return String.Empty;
		}

        public string ValidateBuildFrom()
        {
            if (DateEditBuildFrom.EditValue == null) {
                return "Please fill in this field.";
            }
            return string.Empty;
        }

        public string ValidateBuildThrough()
        {
            if (DateEditBuildThrough.EditValue == null) {
                return "Please fill in this field.";
            }
            if (DateEditBuildFrom.DateTime > DateEditBuildThrough.DateTime) {
                return "The build through date must be on or after the build from date.";
            }

            return string.Empty;
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
					control.Enabled = !CheckEditSync.Checked;
				}
                SpinEditRel.Enabled = true;
                CheckEditSync.Enabled = true;

				foreach (Control control in GroupControlQuantities.Controls) {
					control.Enabled = true;
				}
			}
		}

		private void BarToggleSwitchItemBuild_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (BarToggleSwitchItemBuild.Checked) {
                if (_selectedRecord == null)
                    CreateNewRecord();
                SetBuildMode(true);
            }
            else {
                _ignoreLeaveRow = true;
                ClearBuildControls();
                SetBuildMode(false);
                _ignoreLeaveRow = false;
            }
        }

        private void SetBuildMode(bool buildMode)
        {
            GridControlLookup.Visible = !buildMode;
            GroupControlBuild.Enabled = buildMode;
            DateEditDate.Enabled = !buildMode;
            DateEditDate.EditValue = null;
            BarButtonItemDelete.Enabled = !buildMode;
        }

        private void ClearBuildControls()
        {
            foreach (Control control in GroupControlBuild.Controls) {
                if (control is BaseEdit) {
                    if (control is CheckEdit) {
                        ((CheckEdit)control).EditValue = false;
                    }
                    else {
                        ((BaseEdit)control).EditValue = null;
                    }
                }
            }
        }

        public string ValidateBuildEvery()
        {
            if (BarToggleSwitchItemBuild.Checked) {
                if (!string.IsNullOrEmpty(ComboBoxEditBuildEvery.Text)) {
                    if (!Enum.TryParse(ComboBoxEditBuildEvery.Text, out DayOfWeek dayOfWeek)
                      && !int.TryParse(ComboBoxEditBuildEvery.Text, out int everyDays)) {
                        return "Please enter a day of the week or a number of days.";
                    }
                }
            }
            return string.Empty;
        }

        public string ValidateOverwrite()
        {
            if (CheckEditOverwrite.Checked && CheckEditSkip.Checked) {
                return "Records cannot be both skipped and overwritten.  Please choose one or the other.";
            }
            return string.Empty;
        }

        public string ValidateSkip()
        {
            if (CheckEditOverwrite.Checked && CheckEditSkip.Checked) {
                return "Records cannot be both skipped and overwritten.  Please choose one or the other.";
            }
            return string.Empty;
        }

        private void DateEditBuildFrom_Leave(object sender, EventArgs e)
        {
            if (BarToggleSwitchItemBuild.Checked) 
                SetErrorInfo(ValidateBuildFrom, sender);
        }

        private void DateEditBuildThrough_Leave(object sender, EventArgs e)
        {
            if (BarToggleSwitchItemBuild.Checked)
                SetErrorInfo(ValidateBuildThrough, sender);
        }

        private void ComboBoxEditBuildEvery_Leave(object sender, EventArgs e)
        {
            if (BarToggleSwitchItemBuild.Checked)
                SetErrorInfo(ValidateBuildEvery, sender);
        }

        private void SpinEditBuildDays_Leave(object sender, EventArgs e)
        {
            if (BarToggleSwitchItemBuild.Checked)
                SetErrorInfo(ValidateBuildDays, sender);
        }

        private void SearchLookupEditCode_CloseUp(object sender, CloseUpEventArgs e)
        {
            if (e.CloseMode == PopupCloseMode.Normal && CheckEditSync.Checked) {
                SearchLookupEditRelCode.EditValue = e.Value;
            }
        }

        private void LookupEdit_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ((sender as LookUpEditBase).Properties.DataSource == null)
                e.Cancel = true;
            else
                e.Cancel = false;
        }

        private void SearchLookupEditAgency_CloseUp(object sender, CloseUpEventArgs e)
        {
            if (e.CloseMode == PopupCloseMode.Normal && CheckEditSync.Checked) {
                SearchLookupEditRelAgency.EditValue = e.Value;
            }
        }

        private void SearchLookupEditCat_CloseUp(object sender, CloseUpEventArgs e)
        {
            if (e.CloseMode == PopupCloseMode.Normal && CheckEditSync.Checked) {
                SearchLookupEditRelCat.EditValue = e.Value;
            }
        }

        private void ComboBoxEditTP_CloseUp(object sender, CloseUpEventArgs e)
        {
            if (e.CloseMode == PopupCloseMode.Normal && CheckEditSync.Checked) {
                ComboBoxEditRelTyp.EditValue = e.Value;
            }
        }

        private void EntityInstantFeedbackSource_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            FlextourEntities context = new FlextourEntities(Connection.EFConnectionString);
            e.QueryableSource = context.INVT;
            e.Tag = context;
        }

        private void EntityInstantFeedbackSource_DismissQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            ((FlextourEntities)e.Tag).Dispose();
        }

        private void GridViewLookup_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (!_ignoreLeaveRow) {
                GridView view = (GridView)sender;
                object row = view.GetRow(e.FocusedRowHandle);
                if (row != null && row.GetType() != typeof(DevExpress.Data.NotLoadedObject)) {
                    ReadonlyThreadSafeProxyForObjectFromAnotherThread proxy = (ReadonlyThreadSafeProxyForObjectFromAnotherThread)view.GetRow(e.FocusedRowHandle);
                    INVT record = (INVT)proxy.OriginalRow;
                    BindingSource.DataSource = _context.INVT.Where(c => c.CODE == record.CODE);
                }
                else {
                    ClearBindings();
                }
            }
        }

        private void InvtMaint_Shown(object sender, EventArgs e)
        {
            GridViewLookup.FocusedRowHandle = DevExpress.Data.CurrencyDataController.FilterRow;
            GridControlLookup.Focus();
        }

        private void BarHeaderItemBuildMode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BarToggleSwitchItemBuild.Checked = !BarToggleSwitchItemBuild.Checked;
        }

        private void SearchLookupEditAgency_EditValueChanged(object sender, EventArgs e)
        {
            SpinEditHold.Enabled = (SearchLookupEditAgency.EditValue.ToString() == _sys.Settings.DefaultAgency);
            if (!SpinEditHold.Enabled) {
                SpinEditHold.EditValue = 0;
            }
        }

        private void SpinEditStartNumber_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateStartNumber, sender);
                SetErrorInfo(_selectedRecord.ValidateEndNumber, SpinEditEndNumber);
        }

        private void SpinEditEndNumber_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateEndNumber, sender);
                SetErrorInfo(_selectedRecord.ValidateStartNumber, SpinEditStartNumber);
        }

        private void SearchLookupEditSpecialValue_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateSpecialValue, sender);
        }

        private void BarButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (BarToggleSwitchItemBuild.Checked) {
                _ignoreLeaveRow = true;
                _ignorePositionChange = true;
                BindingSource.Remove(_selectedRecord);
                _selectedRecord = (INVT)BindingSource.AddNew();     //set _selectedRecord here because SetBindings will not be called
                _ignorePositionChange = false;
                _ignoreLeaveRow = false;
                ErrorProvider.Clear();
            }
            else {
                CreateNewRecord();
            }
        }

        private void BarButtonItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteRecord();
        }

        private void BarButtonItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (BarToggleSwitchItemBuild.Checked == false) {
				if (SaveRecord(false))
					RefreshRecord();
			}
			else {
                if (ValidateAll())
				    BuildRecords();
            }
		}
	}
}