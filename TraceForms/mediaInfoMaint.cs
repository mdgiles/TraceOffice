using Custom_SearchLookupEdit;
using DevExpress.Data.Async.Helpers;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using FlexModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TraceForms
{
    public partial class mediaInfoMaint : XtraForm
    {
        FlextourEntities _context;
        MEDIAINFO _selectedRecord;
        Timer _actionConfirmation;
        bool _ignoreLeaveRow = false, _ignorePositionChange = false;
        Dictionary<String, List<CodeName>> _productLookups;
        public string _imagesRoot;
        string _originalHtml = string.Empty;
        public bool _resourcesModified = false;

        public mediaInfoMaint(FlexInterfaces.Core.ICoreSys sys)
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

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            _context = new FlextourEntities(sys.Settings.EFConnectionString);
            _imagesRoot = sys.Settings.ImagesRoot;
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

            lookup = new List<CodeName>();
            lookup.AddRange(_context.LANGUAGE
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.NAME }));
            SearchLookupEditLang.Properties.DataSource = lookup;

            lookup = new List<CodeName>();
            lookup.AddRange(_context.LOOKUP
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.DESC }));
            SearchLookupEditSection.Properties.DataSource = lookup;

            lookup = new List<CodeName>();
            lookup.AddRange(_context.CITYCOD
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.NAME }));
            SearchLookupEditProduct.Properties.DataSource = lookup;

            lookup = new List<CodeName>();
            lookup.AddRange(_context.WAYPOINT
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.DESC }));
            SearchLookupEditProduct.Properties.DataSource = lookup;
        }


        private void ComboBoxEditType_SelectedValueChanged(object sender, EventArgs e)
        {
            string type = ComboBoxEditType.Text;
            SetFieldStates(type);
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

        void SetReadOnly(bool value)
        {
            foreach (Control control in SplitContainerControl.Panel2.Controls) {
                control.Enabled = !value;
            }
        }

        void SetReadOnlyKeyFields(bool value)
        {
            SearchLookupEditProduct.ReadOnly = value;
        }

        private void ButtonEditImage1LowRes_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog() { Title = "Open Image", InitialDirectory = _imagesRoot }) {
                if (dlg.ShowDialog() == DialogResult.OK) {
                    if (dlg.FileName.ToLower().IndexOf(_imagesRoot.ToLower()) != -1)
                        ButtonEditImage1LowRes.Text = dlg.FileName.Substring(_imagesRoot.Length);
                    else
                        ButtonEditImage1LowRes.Text = dlg.FileName;
                }
            }
        }

        private void ButtonEditImage1LowRes_TextChanged(object sender, EventArgs e)
        {

            PictureEditPreviewImage1.Image = null;

            try {
                using (var stream = new MemoryStream(File.ReadAllBytes(_imagesRoot + ButtonEditImage1LowRes.Text))) {
                    PictureEditPreviewImage1.Height = Image.FromStream(stream).Height;
                    PictureEditPreviewImage1.Width = Image.FromStream(stream).Width;
                    PictureEditPreviewImage1.Image = Image.FromStream(stream);
                    ErrorProvider.SetError(ButtonEditImage1LowRes, "");
                }

            }
            catch {
                try {
                    using (var stream = new MemoryStream(File.ReadAllBytes(ButtonEditImage1LowRes.Text))) {
                        PictureEditPreviewImage1.Height = Image.FromStream(stream).Height;
                        PictureEditPreviewImage1.Width = Image.FromStream(stream).Width;
                        PictureEditPreviewImage1.Image = Image.FromStream(stream);
                        ErrorProvider.SetError(ButtonEditImage1LowRes, "");
                    }
                }
                catch {
                    return;
                }

            }


            labelControlSizeDisplay.Text = PictureEditPreviewImage1.Image.Height + " * " + PictureEditPreviewImage1.Image.Width;
        }

        private void ButtonEditImage2MedRes_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog() { Title = "Open Image", InitialDirectory = _imagesRoot }) {
                if (dlg.ShowDialog() == DialogResult.OK) {
                    if (dlg.FileName.ToLower().IndexOf(_imagesRoot.ToLower()) != -1)
                        ButtonEditImage2MedRes.Text = dlg.FileName.Substring(_imagesRoot.Length);
                    else
                        ButtonEditImage2MedRes.Text = dlg.FileName;
                }
            }
        }

        private void ButtonEditImage2MedRes_TextChanged(object sender, EventArgs e)
        {
            PictureEditPreviewImage2.Image = null;

            try {
                using (var stream = new MemoryStream(File.ReadAllBytes(_imagesRoot + ButtonEditImage2MedRes.Text))) {
                    PictureEditPreviewImage2.Height = Image.FromStream(stream).Height;
                    PictureEditPreviewImage2.Width = Image.FromStream(stream).Width;
                    PictureEditPreviewImage2.Image = Image.FromStream(stream);
                    ErrorProvider.SetError(ButtonEditImage2MedRes, "");
                }

            }
            catch {
                try {
                    using (var stream = new MemoryStream(File.ReadAllBytes(ButtonEditImage2MedRes.Text))) {
                        PictureEditPreviewImage2.Height = Image.FromStream(stream).Height;
                        PictureEditPreviewImage2.Width = Image.FromStream(stream).Width;
                        PictureEditPreviewImage2.Image = Image.FromStream(stream);
                        ErrorProvider.SetError(ButtonEditImage2MedRes, "");
                    }
                }
                catch {
                    return;
                }

            }

            labelControlSizeDisplay2.Text = PictureEditPreviewImage2.Image.Height + " * " + PictureEditPreviewImage2.Image.Width;
        }

        private void ButtonEditImage3HighRes_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog() { Title = "Open Image", InitialDirectory = _imagesRoot }) {
                if (dlg.ShowDialog() == DialogResult.OK) {
                    if (dlg.FileName.ToLower().IndexOf(_imagesRoot.ToLower()) != -1)
                        ButtonEditImage3HighRes.Text = dlg.FileName.Substring(_imagesRoot.Length);
                    else
                        ButtonEditImage3HighRes.Text = dlg.FileName;
                }
            }
        }

        private void ButtonEditImage3HighRes_TextChanged(object sender, EventArgs e)
        {

            PictureEditPreviewImage3.Image = null;

            try {
                using (var stream = new MemoryStream(File.ReadAllBytes(_imagesRoot + ButtonEditImage3HighRes.Text))) {
                    PictureEditPreviewImage3.Height = Image.FromStream(stream).Height;
                    PictureEditPreviewImage3.Width = Image.FromStream(stream).Width;
                    PictureEditPreviewImage3.Image = Image.FromStream(stream);
                    ErrorProvider.SetError(ButtonEditImage3HighRes, "");
                }

            }
            catch {
                try {
                    using (var stream = new MemoryStream(File.ReadAllBytes(ButtonEditImage3HighRes.Text))) {
                        PictureEditPreviewImage3.Height = Image.FromStream(stream).Height;
                        PictureEditPreviewImage3.Width = Image.FromStream(stream).Width;
                        PictureEditPreviewImage3.Image = Image.FromStream(stream);
                        ErrorProvider.SetError(ButtonEditImage3HighRes, "");
                    }
                }
                catch {
                    return;
                }

            }

            labelControlSizeDisplay3.Text = PictureEditPreviewImage3.Image.Height + " * " + PictureEditPreviewImage3.Image.Width;
        }

        private void ButtonEditImage4ThmNail_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog() { Title = "Open Image", InitialDirectory = _imagesRoot }) {
                if (dlg.ShowDialog() == DialogResult.OK) {
                    if (dlg.FileName.ToLower().IndexOf(_imagesRoot.ToLower()) != -1)
                        ButtonEditImage4ThmNail.Text = dlg.FileName.Substring(_imagesRoot.Length);
                    else
                        ButtonEditImage4ThmNail.Text = dlg.FileName;
                }
            }
        }

        private void ButtonEditImage4ThmNail_TextChanged(object sender, EventArgs e)
        {
            PictureEditPreviewImage4.Image = null;

            try {
                using (var stream = new MemoryStream(File.ReadAllBytes(_imagesRoot + ButtonEditImage4ThmNail.Text))) {
                    PictureEditPreviewImage4.Height = Image.FromStream(stream).Height;
                    PictureEditPreviewImage4.Width = Image.FromStream(stream).Width;
                    PictureEditPreviewImage4.Image = Image.FromStream(stream);
                    ErrorProvider.SetError(ButtonEditImage4ThmNail, "");
                }
            }
            catch {
                try {
                    using (var stream = new MemoryStream(File.ReadAllBytes(ButtonEditImage4ThmNail.Text))) {
                        PictureEditPreviewImage4.Height = Image.FromStream(stream).Height;
                        PictureEditPreviewImage4.Width = Image.FromStream(stream).Width;
                        PictureEditPreviewImage4.Image = Image.FromStream(stream);
                        ErrorProvider.SetError(ButtonEditImage4ThmNail, "");
                    }
                }
                catch {
                    return;
                }

            }

            labelControlSizeDisplay4.Text = String.Format("{0} * {1}", PictureEditPreviewImage4.Image.Height, PictureEditPreviewImage4.Image.Width);
        }

        private void MediaInfoBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            //If the current record is changing as a result of removing a record to delete it, and it is the last
            //record in the table, then SetBindings will clear the bindings, which will cause the delete
            //to fail because the associated entities will become detached when their BindingSources are cleared.
            //Thus we have a flag which is set in that case to ignore this event.
            if (!_ignorePositionChange)
                SetBindings();
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
                RefreshResources();
                //SetReadOnlyKeyFields(true);
            }
        }

        private void RefreshResources()
        {
            //Refreshing from store can't refresh added but unsaved records, so these have to be manually removed first
            List<RESOURCE> toRemove = new List<RESOURCE>();
            foreach (RESOURCE resource in ResourceBindingSource.List) {
                if (resource.EntityState == EntityState.Added) {
                    toRemove.Add(resource);
                }
            }
            foreach (RESOURCE resource in toRemove) {
                ResourceBindingSource.Remove(resource);
            }
            _context.Refresh(RefreshMode.StoreWins, ResourceBindingSource.List);
            LoadAndBindResources();
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
                        _context.MEDIAINFO.AddObject(_selectedRecord);
                    }
                    SetUpdateFields(_selectedRecord);
                    _context.SaveChanges();
                    if (newRec) {
                        foreach (RESOURCE resource in ResourceBindingSource.List.Cast<RESOURCE>()) {
                            resource.LINK_VALUE = _selectedRecord.ID.ToString();
                        }
                        _context.SaveChanges();
                    }
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

        private void SetUpdateFields(MEDIAINFO record)
        {
            record.ChgDate = DateTime.Now;
        }

        private bool IsModified(MEDIAINFO record)
        {
            //Type-specific routine that takes into account relationships that should also be considered
            //when deciding if there are unsaved changes.  The entity properties also return true if the
            //record is new or deleted.
            if (record == null)
                return false;
            return record.IsModified(_context) || _resourcesModified;
        }

        private bool ValidateAll()
        {
            bool imagesInvalid = false;
            if (ResourceBindingSource.List.Count > 0) {
                imagesInvalid = ResourceBindingSource.List.Cast<RESOURCE>().Any(b => !b.Validate() || b.ValidateTag().IsNotNullOrEmpty());
            }

            if (!_selectedRecord.Validate() || imagesInvalid) {
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
            SetErrorInfo(_selectedRecord.ValidateCode, SearchLookupEditProduct);
            SetErrorInfo(_selectedRecord.ValidateType, ComboBoxEditType);
            SetErrorInfo(_selectedRecord.ValidateCategory, SearchLookupEditCategory);
            SetErrorInfo(_selectedRecord.ValidateLanguage, SearchLookupEditLang);
            SetErrorInfo(_selectedRecord.ValidateAgency, SearchLookupEditAgency);
            SetErrorInfo(_selectedRecord.ValidateSvcStartDate, DateEditSvcStartDate);
            SetErrorInfo(_selectedRecord.ValidateSvcEndDate, DateEditSvcEndDate);
            SetErrorInfo(_selectedRecord.ValidateResStartDate, DateEditResStartDate);
            SetErrorInfo(_selectedRecord.ValidateResEndDate, DateEditResEndDate);
            SetErrorInfo(_selectedRecord.ValidateTitle, TextEditTitle);
            SetErrorInfo(_selectedRecord.ValidateSubtitle, TextEditSubtitle);
            _selectedRecord.Resources = ResourceBindingSource.List.Cast<RESOURCE>().ToList();
            SetErrorInfo(_selectedRecord.ValidateImages, GridControlAdditionalImages);
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
            UpdateHtmlBinding();
        }

        void SetBindings()
        {
            if (BindingSource.Current == null) {
                ClearBindings();
            }
            else {
                _selectedRecord = ((MEDIAINFO)BindingSource.Current);
                LoadAndBindResources();
                SetReadOnly(false);
                //SetReadOnlyKeyFields(true);
                BarButtonItemDelete.Enabled = true;
                BarSubItemReports.Enabled = true;
                BarButtonItemSave.Enabled = true;
                HtmlEditor.BodyHtml = _selectedRecord.TEXT;
            }
            //The original html is required because the html editor reformats html to xhtml. Thus the
            //contents may change, even though the user has not changed them. Retrieving the BodyHtml property
            //right after it has been set will retrieve the reformatted xhtml, which can later be compared to
            //the BodyHtml property to see if the user has made subsequent changes.  Only if the user has made
            //changes should we warn that changes may be lost, otherwise the user will be very confused that each
            //record appears to have been changed when only viewing.
            _originalHtml = HtmlEditor.BodyHtml;
            _resourcesModified = false;
            ErrorProvider.Clear();
        }

        private void LoadAndBindResources()
        {
            string id = _selectedRecord.ID.ToString();
            //var foo = _context.RESOURCE.Where(c => c.LINK_VALUE == id).ToList();
            //GridControlAdditionalImages.DataSource = foo;
            ResourceBindingSource.DataSource = _context.RESOURCE.Where(c => c.LINK_VALUE == id);
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
                            _context.MEDIAINFO.DeleteObject(_selectedRecord);
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

        private void UpdateHtmlBinding()
        {
            //The lost focus event doesn't work on the text editor when clicking a button in the toolbar
            if (HtmlEditor.BodyHtml != _originalHtml) {
                //Modified = true;
                //NB: Before updating any property on the entity, any pending edits must be committed 
                //with bindingSource.EndEdit, other when the properties are set the form bindings are
                //automatically refreshed, which causes any pending edits to be lost. 
                BindingSource.EndEdit();
                _selectedRecord.TEXT = HtmlEditor.BodyHtml;
                _originalHtml = HtmlEditor.BodyHtml;
                //foreach (var bindingObj in htmlEditor.DataBindings) {
                //    Binding binding = (Binding)bindingObj;
                //    if (binding.PropertyName == "BodyHtml") {
                //        binding.WriteValue();
                //        binding.ReadValue();
                //    }
                //}
            }
        }

        void ClearBindings()
        {
            _ignoreLeaveRow = true;
            _ignorePositionChange = true;
            _selectedRecord = null;
            SetReadOnly(true);
            ResourceBindingSource.DataSource = typeof(RESOURCE);
            HtmlEditor.BodyHtml = string.Empty;
            _originalHtml = string.Empty;
            BarButtonItemDelete.Enabled = false;
            BarSubItemReports.Enabled = false;
            BarButtonItemSave.Enabled = false;
            BindingSource.DataSource = typeof(MEDIAINFO);
            _ignoreLeaveRow = false;
            _ignorePositionChange = false;
        }

        private void EntityInstantFeedbackSource_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            FlextourEntities context = new FlextourEntities(Connection.EFConnectionString);
            e.QueryableSource = context.MEDIAINFO;
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
                    MEDIAINFO record = (MEDIAINFO)proxy.OriginalRow;
                    BindingSource.DataSource = _context.MEDIAINFO.Where(c => c.ID == record.ID);
                }
                else {
                    ClearBindings();
                }
            }
        }

        private void SetCheckEdits()
        {
            if (string.IsNullOrWhiteSpace(SearchLookupEditCategory.Text))
                CheckEditAllCategory.Checked = true;
            else
                CheckEditAllCategory.Checked = false;

            if (string.IsNullOrWhiteSpace(SearchLookupEditAgency.Text))
                CheckEditAllAgency.Checked = true;
            else
                CheckEditAllAgency.Checked = false;
        }

        private void GridViewLookup_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            //If the user selects a row, edits, then selects the auto-filter row, then selects a different row,
            //this event will fire for the auto-filter row, so we cannot ignore it because there is still a record
            //that may need to be saved. 
            if (!_ignoreLeaveRow) {
                //We have to push the html editor back into the selected record because it isn't bound, otherwise
                //its state won't be considered in whether the record has changed
                UpdateHtmlBinding();
                if (IsModified(_selectedRecord)) {
                    e.Allow = SaveRecord(true);
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

        private void LookupEdit_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ((sender as LookUpEditBase).Properties.DataSource == null)
                e.Cancel = true;
            else
                e.Cancel = false;
        }

        private void MediaInfoMaint_FormClosing(object sender, FormClosingEventArgs e)
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

        private void ComboBoxEditType_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateType, sender);
        }

        private void DateEditResStartDate_Leave(object sender, EventArgs e)
        {
            DateEditLeaveValidator3000(DateEditResStartDate, _selectedRecord.ValidateResStartDate);
        }

        private void DateEditResEndDate_Leave(object sender, EventArgs e)
        {
            DateEditLeaveValidator3000(DateEditResEndDate, _selectedRecord.ValidateResEndDate);
        }

        private void DateEditSvcStartDate_Leave(object sender, EventArgs e)
        {
            DateEditLeaveValidator3000(DateEditSvcStartDate, _selectedRecord.ValidateSvcStartDate);
        }

        public void DateEditLeaveValidator3000(DateEdit dateedit, Func<string> method)
        {
            if (_selectedRecord != null) {
                if (!string.IsNullOrEmpty(dateedit.Text)) {
                    if (!DateTime.TryParse(dateedit.Text, out DateTime output)) {
                        ErrorProvider.SetError(dateedit, "Please enter a valid value");
                        return;
                    }
                }
                SetErrorInfo(method, dateedit);
            }
        }

        private void DateEditSvcEndDate_Leave(object sender, EventArgs e)
        {
            DateEditLeaveValidator3000(DateEditSvcEndDate, _selectedRecord.ValidateSvcEndDate);
        }

        private void TextEditTitle_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateTitle, sender);
        }

        private void TextEditSubtitle_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateSubtitle, sender);
        }

        private void TextEditCaption_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCaption, sender);
        }

        private void ButtonEditImage1LowRes_Leave(object sender, EventArgs e)
        {
            //Come back to this and add a warning if the file does not exist
        }

        private void ButtonEditImage2MidRes_Leave(object sender, EventArgs e)
        {
            //Ditto
        }

        private void ButtonEditImage3HighRes_Leave(object sender, EventArgs e)
        {
            //Ditto
        }

        private void ButtonEditImage4ThmNail_Leave(object sender, EventArgs e)
        {
            //Ditto
        }

        private void ImageComboBoxEditSeverity_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateSeverity, sender);
        }

        private void ComboBoxEditType_TextChanged(object sender, EventArgs e)
        {
            SetFieldStates(ComboBoxEditType.Text);
        }

        private void SetFieldStates(string type)
        {
            SearchLookupEditProduct.Enabled = true;
            SearchLookupEditCategory.Enabled = true;
            CheckEditAllCategory.Enabled = true;
            DateEditSvcStartDate.Enabled = true;
            DateEditSvcEndDate.Enabled = true;

            LoadCodeLookupValues(type, SearchLookupEditProduct);

            if (type == "AGY") {
                SearchLookupEditProduct.Enabled = false;
                SearchLookupEditCategory.Text = string.Empty;
                SearchLookupEditCategory.Enabled = false;
                CheckEditAllCategory.Checked = false;
                CheckEditAllCategory.Enabled = false;
                DateEditSvcStartDate.Text = string.Empty;
                DateEditSvcStartDate.Enabled = false;
                DateEditSvcEndDate.Text = string.Empty;
                DateEditSvcEndDate.Enabled = false;
            }
        }

        private void RepositoryItemButtonEdit_Item_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog() { Title = "Open Image", InitialDirectory = _imagesRoot }) {
                if (dlg.ShowDialog() == DialogResult.OK) {
                    if (dlg.FileName.ToLower().IndexOf(_imagesRoot.ToLower()) != -1)
                        GridViewAdditionalImages.SetFocusedValue(dlg.FileName.Substring(_imagesRoot.Length));
                    else
                        GridViewAdditionalImages.SetFocusedValue(dlg.FileName);
                }
            }
        }

        private void ButtonAddRow_Click(object sender, EventArgs e)
        {
            RESOURCE resource = new RESOURCE() {
                LINK_TABLE = "MEDIAITEM",
                RECTYPE = "IMAGE",
                LINK_VALUE = _selectedRecord.ID.ToString()
            };
            ResourceBindingSource.Add(resource);
        }

        private void ButtonDelRow_Click(object sender, EventArgs e)
        {
            _resourcesModified = true;
            ResourceBindingSource.RemoveCurrent();
        }

        private void ImageComboBoxEditLang_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateLanguage, sender);
        }

        private void ImageComboBoxEditCode_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCode, sender);
        }

        private void ImageComboBoxEditSection_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateSection, sender);
        }

        private void ImageComboBoxEditAgency_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateAgency, sender);
        }

        private void ImageComboBoxEditCategory_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCategory, sender);
        }

        private void MatchingReports()
        {
            MediaInfoMatchForm xform = new MediaInfoMatchForm(_context, _selectedRecord.ID);
            xform.Show();
        }

        private void RemoveFromReports(int ID)
        {
            DialogResult select = XtraMessageBox.Show("Are you sure you wish to remove this section from all Media Reports?", Name, MessageBoxButtons.YesNo);
            if (select == System.Windows.Forms.DialogResult.Yes) {
                var mediaRptItem = _context.MediaRptItem
                    .Include(mri => mri.MEDIARPT)
                    .Where(mri => mri.SECTION_ID == ID);
                foreach (var result in mediaRptItem) {
                    //Flag as changed all the reports from which this section is removed
                    result.MEDIARPT.ChgDate = DateTime.Now;
                    _context.DeleteObject(result);
                }
                _context.SaveChanges();
            }
        }

        private void CreateNewReports()
        {
            MediaRptForm xform = new MediaRptForm(_context, _selectedRecord) { MdiParent = this.MdiParent }; ;
            xform.Show();
        }

        private void AddToReports()
        {
            MediaInfoMatchForm xform = new MediaInfoMatchForm(_context, _selectedRecord);
            xform.Show();
        }

        private void ButtonCreateThumbnailLowRes_Click(object sender, EventArgs e)
        {
            CreateThumbNail(ButtonEditImage1LowRes.Text);
        }

        private void ButtonCreateThumbnailMedRes_Click(object sender, EventArgs e)
        {
            CreateThumbNail(ButtonEditImage2MedRes.Text);
        }

        private void ButtonCreateThumbNailHighRes_Click(object sender, EventArgs e)
        {
            CreateThumbNail(ButtonEditImage3HighRes.Text);
        }

        private void CreateThumbNail(string path)
        {
            MediaInfo.MediaInfoSys MediaSys = new MediaInfo.MediaInfoSys();
            string newPath = MediaSys.CreateThumbnail(path);
            if (!string.IsNullOrEmpty(newPath)) {
                ButtonEditImage4ThmNail.Text = newPath;
            }
        }

        private void RepositoryItemPopupContainerEditPreview_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            pictureEditPreviewAddImg.Image = null;
            string path = GridViewAdditionalImages.GetFocusedRowCellDisplayText(ColumnItem);
            try {
                if (path.Contains(":") || path.StartsWith("\\")) {
                    using (var stream = new MemoryStream(File.ReadAllBytes(path))) {
                        pictureEditPreviewAddImg.Image = Image.FromStream(stream);
                    }
                }
                else {
                    using (var stream = new MemoryStream(File.ReadAllBytes(_imagesRoot + path))) {
                        pictureEditPreviewAddImg.Image = Image.FromStream(stream);
                    }
                }
            }
            catch { }
        }

        private void ImageComboBoxEditAgency_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchLookupEditAgency.Text))
                CheckEditAllAgency.Checked = true;
            else
                CheckEditAllAgency.Checked = false;
        }

        private void ImageComboBoxEditCategory_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchLookupEditCategory.Text))
                CheckEditAllCategory.Checked = true;
            else
                CheckEditAllCategory.Checked = false;
        }

        private void MediaInfoMaint_Shown(object sender, System.EventArgs e)
        {
            GridViewLookup.FocusedRowHandle = DevExpress.Data.BaseListSourceDataController.FilterRow;
            GridControlLookup.Focus();
        }

        private void BarButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _ignoreLeaveRow = true;       //so that when the grid row changes it doesn't try to save again
            if (SaveRecord(true)) {
                //For some reason when there is no existing record in the binding source the Add method does not
                //trigger the CurrentChanged event, but AddNew does so use that instead
                _selectedRecord = (MEDIAINFO)BindingSource.AddNew();
                //With the instant feedback data source, the new row is not immediately added to the grid, so move
                //the focused row to the filter row just so that no other existing row is visually highlighted
                GridViewLookup.FocusedRowHandle = DevExpress.Data.BaseListSourceDataController.FilterRow;
                SetReadOnly(false);
            }
            ErrorProvider.Clear();
            _ignoreLeaveRow = false;
        }

        private void BarButtonItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteRecord();
        }

        private void BarButtonItemClone_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (BindingSource.Current != null) {
                if (SaveRecord(true)) {
                    //Clone the obejct property by property rather than using MemberwiseClone because MemberwiseClone
                    //will attempt to copy the relationship manager which will then not allow the cloned object to be
                    //added to the binding source because it is no longer the same relationship manager.
                    var current = (MEDIAINFO)BindingSource.Current;
                    var info = new MEDIAINFO {
                        Agency = current.Agency,
                        CAPTION = current.CAPTION,
                        CAT = current.CAT,
                        ChgDate = DateTime.Now,
                        CODE = current.CODE,
                        Consent = current.Consent,
                        IMAGE1 = current.IMAGE1,
                        IMAGE2 = current.IMAGE2,
                        IMAGE3 = current.IMAGE3,
                        IMAGE4 = current.IMAGE4,
                        ImagesRoot = current.ImagesRoot,
                        Inactive = current.Inactive,
                        Inhouse = current.Inhouse,
                        LANG = current.LANG,
                        ROOM = current.ROOM,
                        ResDate_Start = current.ResDate_Start,
                        ResDate_End = current.ResDate_End,
                        SvcDate_Start = current.SvcDate_Start,
                        SvcDate_End = current.SvcDate_End,
                        SECTION = current.SECTION,
                        Severity = current.Severity,
                        SUBTITLE = current.SUBTITLE,
                        TEXT = current.TEXT,
                        TITLE = current.TITLE,
                        TYPE = current.TYPE
                    };
                    //clear flags so we don't get save warnings displaying the new record
                    _ignoreLeaveRow = true;
                    BindingSource.Add(info);
                    BindingSource.Position = BindingSource.Count;
                    //With the instant feedback data source, the new row is not immediately added to the grid, so move
                    //the focused row to the filter row just so that no other existing row is visually highlighted
                    GridViewLookup.FocusedRowHandle = DevExpress.Data.BaseListSourceDataController.FilterRow;
                    //set flags so the user will get save warnings when leaving or discarding the new record
                    _ignoreLeaveRow = false;
                    SetReadOnly(false);
                }
            }
        }

        private void BarButtonItemExpand_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (BarButtonItemExpand.Tag.ToString() == "shrunk") {
                BarButtonItemExpand.Tag = "expanded";
                GridViewLookup.Columns["CAT"].Visible = true;
                GridViewLookup.Columns["CAT"].VisibleIndex = 4;
                GridViewLookup.Columns["Agency"].Visible = true;
                GridViewLookup.Columns["Agency"].VisibleIndex = 5;
                GridViewLookup.Columns["SvcDate_Start"].Visible = true;
                GridViewLookup.Columns["SvcDate_Start"].VisibleIndex = 6;
                GridViewLookup.Columns["SvcDate_End"].Visible = true;
                GridViewLookup.Columns["SvcDate_End"].VisibleIndex = 7;
                GridViewLookup.Columns["TYPE"].Width = 35;
                GridViewLookup.Columns["CODE"].Width = 65;
            }
            else {
                BarButtonItemExpand.Tag = "shrunk";
                GridViewLookup.Columns["CAT"].Visible = false;
                GridViewLookup.Columns["Agency"].Visible = false;
                GridViewLookup.Columns["SvcDate_Start"].Visible = false;
                GridViewLookup.Columns["SvcDate_End"].Visible = false;
            }
        }

        private void BarButtonItemReportsContainingSection_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MatchingReports();
        }

        private void BarButtonItemAddToReports_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddToReports();
        }

        private void BarButtonItemRemoveFromReports_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!GridViewLookup.IsFilterRow(GridViewLookup.FocusedRowHandle)) {
                int ID = (int)GridViewLookup.GetFocusedRowCellValue("ID");
                RemoveFromReports(ID);
            }
        }

        private void BarButtonItemCreateNewReports_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CreateNewReports();
        }

        private void GridViewAdditionalImages_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            _resourcesModified = true;
        }

        private void BarButtonItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SaveRecord(false))
                RefreshRecord();
        }

    }
}

