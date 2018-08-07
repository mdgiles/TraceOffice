using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using FlexModel;
using DevExpress.XtraEditors.Controls;
using System.Runtime.InteropServices;
using DevExpress.Data.Linq;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraGrid;


namespace TraceForms
{

    public partial class LanguageForm : DevExpress.XtraEditors.XtraForm
    {
        public string _imagesRoot;
        FlextourEntities _context;
        LANGUAGE _selectedRecord;
        Timer _actionConfirmation;
        bool _ignoreLeaveRow = false, _ignorePositionChange = false;

        public LanguageForm(FlexInterfaces.Core.ICoreSys sys)
        {
            try {
                InitializeComponent();
                Connect(sys);
                SetReadOnly(true);
            }
            catch (Exception ex) {
                DisplayHelper.DisplayError(this, ex);
            }
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            _context = new FlextourEntities(sys.Settings.EFConnectionString);
            _imagesRoot = sys.Settings.ImagesRoot;
        }

        void SetReadOnly(bool value)
        {
            foreach (Control control in SplitContainerControl.Panel2.Controls) {
                control.Enabled = !value;
            }
        }

        void SetReadOnlyKeyFields(bool value)
        {
            TextEditCode.ReadOnly = value;
        }

        private void LoadLookups()
        {
            SetReadOnly(true);
            var lang = from langRec in _context.LANGUAGE orderby langRec.CODE ascending select new { langRec.CODE, langRec.NAME };

            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxEditLanguageCode.Properties.Items.Add(loadBlank);

            foreach (var result in lang) {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditLanguageCode.Properties.Items.Add(load);
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

        private void GridViewLookup_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            //If the user selects a row, edits, then selects the auto-filter row, then selects a different row,
            //this event will fire for the auto-filter row, so we cannot ignore it because there is still a record
            //that may need to be saved. 
            if (!_ignoreLeaveRow && IsModified(_selectedRecord)) {
                e.Allow = SaveRecord(true);
            }
        }

        private void LanguageForm_FormClosing(object sender, FormClosingEventArgs e)
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
                        _context.LANGUAGE.AddObject(_selectedRecord);
                    }
                    _context.SaveChanges();
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

        private void FinalizeBindings()
        {
            BindingSource.EndEdit();
        }

        private bool IsModified(LANGUAGE record)
        {
            //Type-specific routine that takes into account relationships that should also be considered
            //when deciding if there are unsaved changes.  The entity properties also return true if the
            //record is new or deleted.
            return record.IsModified(_context);
        }

        void SetBindings()
        {
            //If the route list is filtered, there will be rows in the binding source
            //that are not visible, and they can become selected if the last visible row
            //is deleted, so handle that by checking rowcount.
            if (BindingSource.Current == null) {
                _selectedRecord = null;
                SetReadOnly(true);
            }
            else {
                _selectedRecord = ((LANGUAGE)BindingSource.Current);
                SetReadOnly(false);
                SetReadOnlyKeyFields(true);
            }
            ErrorProvider.Clear();
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
            SetErrorInfo(_selectedRecord.ValidateCode, TextEditCode);
            SetErrorInfo(_selectedRecord.ValidateName, TextEditName);
            SetErrorInfo(_selectedRecord.ValidateLocalName, TextEditName);
            SetErrorInfo(_selectedRecord.ValidateLanguageCode, TextEditName);
            SetErrorInfo(_selectedRecord.ValidateCultureCode, TextEditName);
        }

        private void SetErrorInfo(Func<String> validationMethod, object sender)
        {
            BindingSource.EndEdit();        //force changes back into context for validation
            if (validationMethod != null) {
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
                            _context.LANGUAGE.DeleteObject(_selectedRecord);
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
                RefreshRecord();        //pull it back from db because that is its current state
                                        //We must also Load and rebind the related entities from the db because context.Refresh doesn't do that
                SetBindings();
            }
        }

        void ClearBindings()
        {
            BindingSource.DataSource = typeof(LANGUAGE);
        }

        private void ImagePathButtonEdit_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog()) {
                dlg.Title = "Open Image";
                //6dlg.Filter = "bmp files (*.bmp)|*.bmp";
                dlg.InitialDirectory = _imagesRoot;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    if (dlg.FileName.ToLower().IndexOf(_imagesRoot.ToLower()) != -1)
                        ImagePathButtonEdit.Text = dlg.FileName.Substring(_imagesRoot.Length);
                    else
                        ImagePathButtonEdit.Text = dlg.FileName;
                }
            }
        }

        private void ImagePathButtonEdit_TextChanged(object sender, EventArgs e)
        {
            PictureEdit1.Image = null;
            Image pic = null;
            try {
                pic = new Bitmap(_imagesRoot + ImagePathButtonEdit.Text);
                ErrorProvider.SetError(ImagePathButtonEdit, "");
            }
            catch {
                try {
                    pic = new Bitmap(ImagePathButtonEdit.Text);
                    ErrorProvider.SetError(ImagePathButtonEdit, "");
                }
                catch {
                    return;
                }
            }
            PictureEdit1.Image = pic;
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

        private void TextEditLocalName_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateLocalName, sender);
        }

        private void TextEditCultureCode_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCultureCode, sender);
        }

        private void ButtonEditImagePath_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateImagePath, sender);
        }

        private void ImageComboBoxEditLanguageCode_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateLanguageCode, sender);
        }

        private void LanguageForm_KeyDown(object sender, KeyEventArgs e)
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

            var records = _context.LANGUAGE.Where(query);
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

        private void BarButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _ignoreLeaveRow = true;       //so that when the grid row changes it doesn't try to save again
            if (SaveRecord(true)) {
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
            DeleteRecord();
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

        private void BarButtonItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SaveRecord(false))
                RefreshRecord();
        }
    }
}