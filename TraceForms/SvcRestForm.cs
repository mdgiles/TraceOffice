using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using FlexModel;
using FlexInterfaces.Core;
using DevExpress.XtraEditors.Controls;
using System.Linq;
using System.Runtime.InteropServices;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraEditors.Repository;
using System.Data;
using System.Drawing;
using System.Text;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System.Data.Entity.Core.Objects;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Data.Async.Helpers;
using DevExpress.XtraEditors.Popup;
using DevExpress.Utils.Win;

namespace TraceForms
{
    public partial class SvcRestForm : DevExpress.XtraEditors.XtraForm
    {
        FlextourEntities _context;
        SVCRESTR _selectedRecord;
        Timer _actionConfirmation;
        bool _ignoreLeaveRow = false, _ignorePositionChange = false;
        ICoreSys _sys;
        List<CodeName> _roomcodCats = new List<CodeName>();
        List<CodeName> _allCats = new List<CodeName>();
        List<CodeName> _assignedCats;
        Dictionary<string, List<CodeName>> _allRatePlans = new Dictionary<string, List<CodeName>>();
        Dictionary<string, List<CodeName>> _lookups = new Dictionary<string, List<CodeName>>();



        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        const string colName = "colCODE";
        public FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public ImageComboBoxItemCollection hotelVals;
        public ImageComboBoxItemCollection compVals;
       
        public ImageComboBoxItemCollection airVals;
        public ImageComboBoxItemCollection cruVals;
        public ImageComboBoxItemCollection carVals;
        public ImageComboBoxItemCollection pkgVals;

        public SvcRestForm(FlexInterfaces.Core.ICoreSys sys)
        {
            try {
                InitializeComponent();
                Connect(sys);
                LoadLookups();
            }
            catch (Exception ex) {
                DisplayHelper.DisplayError(this, ex);
            }
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            _context = new FlextourEntities(sys.Settings.EFConnectionString);
            _sys = sys;
        }

        void SetReadOnly(bool value)
        {
            foreach (Control control in splitContainerControl1.Controls) {
                control.Enabled = !value;
            }
        }

        void SetReadOnlyKeyFields(bool value)
        {
            SearchLookUpEditCode.ReadOnly = value;
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

        private void LoadLookups()
        {
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            var cities = new List<CodeName>();
            var depCities = new List<CodeName> {
                new CodeName(null)
            };
            cities.AddRange(_context.CITYCOD
                .OrderBy(o => o.NAME)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }).ToList());
            depCities.AddRange(_context.CITYCOD
                .OrderBy(o => o.NAME)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }).ToList());
            //repositoryItemImageComboboxLocation.DataSource = cities;

            //var servicetypes = new List<CodeName> {
            //    new CodeName(null)
            //};
            //servicetypes.AddRange(_context.SERVTYPE
            //    .OrderBy(o => o.TYPE)
            //    .Select(s => new CodeName() { Code = s.TYPE, Name = s.DESCRIP }).ToList());
            //SearchLookupEditServiceType.Properties.DataSource = servicetypes;
            //_ServPackTypeLookups.Add("OPT", servicetypes);

            //var packtypes = new List<CodeName> {
            //    new CodeName(null)
            //};
            //packtypes.AddRange(_context.PACKTYPE
            //    .OrderBy(o => o.CODE)
            //    .Select(s => new CodeName() { Code = s.CODE, Name = s.DESC }).ToList());
            //_ServPackTypeLookups.Add("PKG", packtypes);

            //var hotels = new List<CodeName>();
            //hotels.AddRange(_context.HOTEL
            //    .OrderBy(o => o.CODE)
            //    .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }).ToList());
            //_locationLookups.Add("HTL", hotels);
            //RepositoryItemSearchLookUpEditHtl.DataSource = _locationLookups["HTL"];
            //_repos.Add("HTL", RepositoryItemSearchLookUpEditHtl);
            //_passLookups.Add("HTL", hotels);

            ////repositoryItemImageComboboxLocation.DataSource = hotels;

            //var waypoints = new List<CodeName>();
            //waypoints.AddRange(_context.WAYPOINT
            //    .OrderBy(o => o.CODE)
            //    .Select(s => new CodeName() { Code = s.CODE, Name = s.DESC }).ToList());
            //_locationLookups.Add("WAY", waypoints);
            //RepositoryItemSearchLookUpEditWay.DataSource = _locationLookups["WAY"];
            //_repos.Add("WAY", RepositoryItemSearchLookUpEditWay);
            ////repositoryItemImageComboboxLocation.DataSource = waypoints;

            //var memberships = new List<CodeName> {
            //    new CodeName(null)
            //};
            //memberships.AddRange(_context.LOOKUP.Where(c => c.LINK_TABLE == "DETAIL" && c.LINK_COLUMN == "CODE" && c.RECTYPE == "OPTCLASS")
            //    .OrderBy(o => o.CODE)
            //    .Select(s => new CodeName() { Code = s.CODE, Name = s.DESC }).ToList());
            //repositoryItemSearchLookUpEditClass.DataSource = memberships;

            //_roomcodCats = new List<CodeName> {
            //    new CodeName(null)
            //};
            //_roomcodCats.AddRange(_context.ROOMCOD
            //    .OrderBy(o => o.CODE)
            //    .Select(s => new CodeName() { Code = s.CODE, Name = s.DESC }).ToList());
            //_allCats.AddRange(_roomcodCats);

            //BindingSourceUserFields.DataSource = _context.USERFIELDS
            //    .Where(u => (u.VISIBLE ?? false) && u.LINK_TABLE == "COMP")
            //    .OrderBy(u => u.POSITION);

            //BindingSourceBusRoutes.DataSource = _context.BusRoute
            //    .OrderBy(r => r.Name);


            //uncomment above

            //Divider between old and new code


            var rpHotels = new List<CodeName> {
                new CodeName(null)
            };
            rpHotels.AddRange(_context.SpecialValue
                .OrderBy(o => o.Code)
                .Where(r => r.Type == "HTL")
                .Select(s => new CodeName() { Code = s.Code, Name = s.Name }).ToList());
            _allRatePlans.Add("HTL", rpHotels);

            var rpPkgs = new List<CodeName> {
                new CodeName(null)
            };
            rpPkgs.AddRange(_context.SpecialValue
                .OrderBy(o => o.Code)
                .Where(r => r.Type == "PKG")
                .Select(s => new CodeName() { Code = s.Code, Name = s.Name }).ToList());
            _allRatePlans.Add("PKG", rpPkgs);

            var rpComps = new List<CodeName> {
                new CodeName(null)
            };
            rpComps.AddRange(_context.SpecialValue
                .OrderBy(o => o.Code)
                .Where(r => r.Type == "OPT")
                .Select(s => new CodeName() { Code = s.Code, Name = s.Name }).ToList());
            _allRatePlans.Add("OPT", rpComps);
        }

        void enableNavigator(bool value)
        {
            bindingNavigatorMoveNextItem.Enabled = value;
            bindingNavigatorMoveLastItem.Enabled = value;
            bindingNavigatorMoveFirstItem.Enabled = value;
            bindingNavigatorMovePreviousItem.Enabled = value;
        }

        void setReadOnly(bool value)
        {
            SearchLookUpEditCode.Properties.ReadOnly = value;
            SearchLookUpEditAgency.Properties.ReadOnly = value;
            ComboBoxEditType.Properties.ReadOnly = value;
        }

        private void tYPEComboBoxEdit_TextChanged(object sender, System.EventArgs e)
        {
            //SearchLookUpEditCode.Properties.Items.Clear();
            //if (ComboBoxEditType.Text == "OPT")
            //{
            //    SearchLookUpEditCode.Properties.Items.AddRange(compVals);
            //}
            //if (ComboBoxEditType.Text == "HTL")
            //{
            //    SearchLookUpEditCode.Properties.Items.AddRange(hotelVals);
            //}
            //if (ComboBoxEditType.Text == "PKG")
            //{
            //    SearchLookUpEditCode.Properties.Items.AddRange(pkgVals);
            //}
            //if (ComboBoxEditType.Text == "CAR")
            //{
            //    SearchLookUpEditCode.Properties.Items.AddRange(carVals);
            //}
            //if (ComboBoxEditType.Text == "CRU")
            //{
            //    SearchLookUpEditCode.Properties.Items.AddRange(cruVals);
            //}
            //if (ComboBoxEditType.Text == "AIR")
            //{
            //    SearchLookUpEditCode.Properties.Items.AddRange(airVals);
            //}
        }

        private bool checkForms()
        {
            //if (!modified && !newRec)
            //    return true;
            //bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, ErrorProvider, ((SVCRESTR)BindingSource.Current).checkAll, BindingSource);

            //if (validateMain)
            //    return validCheck.saveRec(ref modified, true, ref newRec, context, BindingSource, Name, ErrorProvider,  Cursor);
            //else
            //{
            //    validCheck.saveRec(ref modified, false, ref newRec, context, BindingSource, Name, ErrorProvider,  Cursor);
            //    return false;
            //}
            return true;
        }

        private void setValues()
        {
            GridViewLookup.SetFocusedRowCellValue("CODE", string.Empty);
            GridViewLookup.SetFocusedRowCellValue("AGENCY", string.Empty);
            GridViewLookup.SetFocusedRowCellValue("TYPE", string.Empty);
             
        }

        private void GridViewLookup_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (!_ignoreLeaveRow) {
                GridView view = (GridView)sender;
                object row = view.GetRow(e.FocusedRowHandle);
                if (row != null && row.GetType() != typeof(DevExpress.Data.NotLoadedObject)) {
                    ReadonlyThreadSafeProxyForObjectFromAnotherThread proxy = (ReadonlyThreadSafeProxyForObjectFromAnotherThread)view.GetRow(e.FocusedRowHandle);
                    SVCRESTR record = (SVCRESTR)proxy.OriginalRow;
                    BindingSource.DataSource = _context.COMP.Where(c => c.CODE == record.CODE);
                    SearchLookUpEditCode.ReadOnly = false;
                }
                else {
                    ClearBindings();
                }
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, System.EventArgs e)
        {
            GridViewLookup.ClearColumnsFilter();
            if (BindingSource.Current == null)
            {
                BindingSource.DataSource = from packrec in context.SVCRESTR where packrec.CODE == "KJM987" select packrec;

                BindingSource.AddNew();
                if (GridViewLookup.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewLookup.FocusedRowHandle = GridViewLookup.RowCount - 1;

                ComboBoxEditType.Focus();
                newRec = true;
                setReadOnly(false);
                setValues();
                return;
            }
            ComboBoxEditType.Focus();
            //bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewLookup.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                ErrorProvider.Clear();
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (SVCRESTR)BindingSource.Current);
                BindingSource.AddNew();
                if (GridViewLookup.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewLookup.FocusedRowHandle = GridViewLookup.RowCount - 1;
                ComboBoxEditType.Focus();

                newRec = true;
                setValues();
                setReadOnly(false);
            }         
            
        }

        private void bindingNavigatorDeleteItem_Click(object sender, System.EventArgs e)
        {
            if (BindingSource.Current == null)
                return;
            GridViewLookup.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                modified = false;
                newRec = false;
                BindingSource.RemoveCurrent();
                ErrorProvider.Clear();
                context.SaveChanges();
                PanelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);
                SearchLookUpEditCode.Focus();
                currentVal = SearchLookUpEditCode.Text;
                setReadOnly(true);
                modified = false;
                newRec = false;
            }
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            PanelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            PanelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }
        private bool checkRestrCode()
        {
            string code = SearchLookUpEditCode.EditValue.ToString();
            if (ComboBoxEditType.Text == "HTL")
            {
                if ((from hotRec in context.HOTEL where hotRec.CODE == code && hotRec.RSTR_CDE == "A" select hotRec).Count() == 0)
                    return false;
            }
            if (ComboBoxEditType.Text == "OPT")
            {
                if ((from compRec in context.COMP where compRec.CODE == code && compRec.RSTR_CDE == "A" select compRec).Count() == 0)
                    return false;
            }
            if (ComboBoxEditType.Text == "PKG")
            {
                if ((from packRec in context.PACK where packRec.CODE == code && packRec.RSTR_CDE == "A" select packRec).Count() == 0)
                    return false;
            }
            if (ComboBoxEditType.Text == "CAR")
            {
                if ((from carRec in context.CARINFO where carRec.CODE == code && carRec.RSTR_CDE == "A" select carRec).Count() == 0)
                    return false;
            }
            if (ComboBoxEditType.Text == "CRU")
            {
                if ((from cruRec in context.CRU where cruRec.CODE == code && cruRec.RESTR_CDE == "A" select cruRec).Count() == 0)
                    return false;
            }
            if (ComboBoxEditType.Text == "AIR")
            {
                if ((from airRec in context.AIR where airRec.CODE == code && airRec.RESTR_CDE == "A" select airRec).Count() == 0)
                    return false;
            }
            return true;
        }
        private void sVCRESTR2BindingNavigatorSaveItem_Click(object sender, System.EventArgs e)
        {
            GridViewLookup.ClearColumnsFilter();
            if (BindingSource.Current == null)
                return;

            if (!checkRestrCode())
            {
                MessageBox.Show("The restriction code for this property/service must be set to ‘A’ (agency) in order to save a record in the service restriction file.");
                return;
            }
            GridViewLookup.CloseEditor();
            ComboBoxEditType.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            bool temp = newRec;
            if (checkForms())
            {

                SearchLookUpEditCode.Focus();
                PanelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
                setReadOnly(true);
            }
            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (SVCRESTR)BindingSource.Current);

        }

        private void ComboBoxEditType_Leave(object sender, System.EventArgs e)
        {
            if (BindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;

                //validCheck.check(sender, ErrorProvider, ((SVCRESTR)BindingSource.Current).checkType, BindingSource);
            }
        }

        private void ImageComboBoxEditCode_Leave(object sender, System.EventArgs e)
        {
            if (BindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;

                //validCheck.check(sender, ErrorProvider, ((SVCRESTR)BindingSource.Current).checkCode, BindingSource);
            }
        }

        private void ImageComboBoxEditAgency_Leave(object sender, System.EventArgs e)
        {
            if (BindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;

                //validCheck.check(sender, ErrorProvider, ((SVCRESTR)BindingSource.Current).checkAgency, BindingSource);
            }
        }


        private bool move()
        {

            GridViewLookup.CloseEditor();
            ComboBoxEditType.Focus();
           // bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                ErrorProvider.Clear();

                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (SVCRESTR)BindingSource.Current);

                setReadOnly(true);
                newRec = false;
                modified = false;
                return true;
            }
            return false;
        }


        private void bindingNavigatorMoveNextItem_Click(object sender, System.EventArgs e)
        {
            if (move())
                BindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, System.EventArgs e)
        {
            if (move())
                BindingSource.MoveLast();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, System.EventArgs e)
        {
            if (move())
                BindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, System.EventArgs e)
        {
            if (move())
                BindingSource.MoveFirst();
        }

        private void GridViewSvcRestr_BeforeLeaveRow(object sender, RowAllowEventArgs e)
        {
            if (BindingSource.Current == null)
            {
                e.Allow = true;
                return;
            }

            temp = newRec;
            bool temp2 = modified;
            if (checkForms())
            {
                ErrorProvider.Clear();
                e.Allow = true;
                if ((!temp) && temp2)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (SVCRESTR)BindingSource.Current);

                setReadOnly(true);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (SVCRESTR)BindingSource.Current);

                e.Allow = false;
            }
        }

        private void GridViewSvcRestr_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            if (!GridViewLookup.IsFilterRow(e.RowHandle))
            {
                modified = true;
                
            }
        }

        private void GridViewSvcRestr_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
       
        }

        private void SvcRestrBindingSource_CurrentChanged(object sender, System.EventArgs e)
        {
            if (BindingSource.Current != null)
            {
                enableNavigator(true);

            }
            else
                enableNavigator(false);
        }

        private void SvcRestForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (modified || newRec)
            {
                DialogResult select = DevExpress.XtraEditors.XtraMessageBox.Show("There are unsaved changes. Are you sure want to exit?", Name, MessageBoxButtons.YesNo);
                if (select == DialogResult.Yes)
                {
                    e.Cancel = false;
                    this.Dispose();
                }
                else if (select == DialogResult.No)
                    e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                this.Dispose();
            }
        }

        private void FinalizeBindings()
        {
            BindingSource.EndEdit();
        }

        private bool IsModified(SVCRESTR record)
        {
            //Type-specific routine that takes into account relationships that should also be considered
            //when deciding if there are unsaved changes.  The entity properties also return true if the
            //record is new or deleted.
            if (record == null)
                return false;
            return record.IsModified(_context);
        }

        private void RemoveRecord()
        {
            //Note that cascade delete must be set on the FK in the db in order for the related
            //entities to be deleted.  This is a db function, not an EF function. However in addition
            //the model must know about the delete, otherwise the relationships in the context will
            //get messed up.  So after adding the cascade rule to the FK, the model must be updated,
            //and in order to refresh a relationship the tables must be deleted and re-added
            //Otherwise, we could do a delete loop
            //If using DbContext instead of ObjectContext, we could do eg
            //_context.SupplierCity.RemoveRange(_selectedRecord.SupplierCity)
            BindingSource.RemoveCurrent();
        }

        private void RefreshRecord()
        {
            //A Detached record has not yet been added to the context
            //An Added record has been added but not yet saved, most likely because there was
            //an error in SaveRecord, in which case we should not retrieve it from the db
            if (_selectedRecord != null && _selectedRecord.EntityState != System.Data.Entity.EntityState.Detached
                && _selectedRecord.EntityState != System.Data.Entity.EntityState.Added) {
                _context.Refresh(RefreshMode.StoreWins, _selectedRecord);
                SetReadOnlyKeyFields(true);
            }
        }

        private bool ValidateAll()
        {
            if (!_selectedRecord.Validate()) {
                ShowMainControlErrors();
                DisplayHelper.DisplayWarning(this, "Errors were found. Please resolve them and try again.");
                return false;
            }
            ErrorProvider.Clear();
            return true;
        }

        private void SetErrorInfo(Func<String> validationMethod, object sender)
        {
            BindingSource.EndEdit();//This is where the program crashes from a null reference exception when clicking off of Service Type in a new amenity
            if (validationMethod != null) {
                string error = validationMethod.Invoke();
                ErrorProvider.SetError((Control)sender, error);
            }
        }

        private void DisplayCrash(string message)
        {
            BindingSource.EndEdit();
            ErrorProvider.SetError(SearchLookUpEditCode, message);
        }
        
        private void ShowMainControlErrors()
        {
            //The error indicators inside the grids are handled by binding, but errors on the main form must
            //be set manually

            var errors = _selectedRecord.Errors;
            if (errors != null) {
                if (errors.ContainsKey("CRASH")) {
                    var message = errors["CRASH"];
                    DisplayCrash(message);
                    return;
                }
            }
            SetErrorInfo(_selectedRecord.ValidateCode, SearchLookUpEditCode);
            SetErrorInfo(_selectedRecord.ValidateType, ComboBoxEditType);
            SetErrorInfo(_selectedRecord.ValidateAgency, SearchLookUpEditAgency);
            SetErrorInfo(_selectedRecord.ValidateRoomcodCode, GridLookUpEditCategory);
            SetErrorInfo(_selectedRecord.ValidateSpecialValueCode, GridLookUpEditRatePlan);
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

        private void GridLookupEditRatePlan_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {
            SetRatePlanLookup(e.DisplayValue.ToString());
            e.Handled = true;
        }

        private void SetRatePlanLookup(object ratePlan)
        {
            string plan = ratePlan.ToStringEmptyIfNull();
            string type = ComboBoxEditType.EditValue.ToStringEmptyIfNull();

            if (string.IsNullOrEmpty(plan) || _allRatePlans[type].Any(c => c.Code == plan)) {
                GridLookUpEditRatePlan.Properties.DataSource = _allRatePlans["type"];
            }
            else {
                //If the value of category isn't in the list, add it to the list
                //We allow non-matching categories so that API products can be booked
                //Do not set DataSource because it's already bound to the list, so just changing the list is sufficient
                //Also settings DataSource from ProcessNewValue is forbidden and throws a NullReferenceException
                var listNewPlan = new List<CodeName> {
                    new CodeName(null)
                };
                _allRatePlans.Add(string.Empty, listNewPlan);
            }
        }

        private void LookupEdit_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ((sender as LookUpEditBase).Properties.DataSource == null)
                e.Cancel = true;
            else
                e.Cancel = false;
        }

        private void EntityInstantFeedbackSource_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            FlextourEntities context = new FlextourEntities(Connection.EFConnectionString);
            e.QueryableSource = context.SVCRESTR;
            e.Tag = context;
        }

        private void EntityInstantFeedbackSource_DismissQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            ((FlextourEntities)e.Tag).Dispose();
        }

        void SetBindings()
        {
            if (BindingSource.Current == null) {
                ClearBindings();
            }
            else {
                _selectedRecord = ((SVCRESTR)BindingSource.Current);
                SetReadOnly(false);
                SetReadOnlyKeyFields(true);
                BarButtonItemDelete.Enabled = true;
                BarButtonItemSave.Enabled = true;
            }
            ErrorProvider.Clear();
        }

        void ClearBindings()
        {
            _ignoreLeaveRow = true;
            _ignorePositionChange = true;
            _selectedRecord = null;
            SetReadOnly(true);
            BarButtonItemDelete.Enabled = false;
            BarButtonItemSave.Enabled = false;
            BindingSource.DataSource = typeof(SVCRESTR);
            _ignoreLeaveRow = false;
            _ignorePositionChange = false;
        }

        private bool SaveRecord(bool prompt)
        {
            try {
                if (_selectedRecord == null)
                    return true;

                FinalizeBindings();
                bool newRec = _selectedRecord.IsNew();
                bool modified = newRec || IsModified(_selectedRecord);
                bool nameChanged = _selectedRecord.IsModified(_context, "NAME");

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

                    if (_selectedRecord.EntityState == System.Data.Entity.EntityState.Detached) {
                        _context.SVCRESTR.AddObject(_selectedRecord);
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
                        if (_selectedRecord != null && (_selectedRecord.EntityState & System.Data.Entity.EntityState.Deleted) != System.Data.Entity.EntityState.Deleted)
                            _context.SVCRESTR.DeleteObject(_selectedRecord);
                        _context.SaveChanges();
                    }
                    if (GridViewLookup.DataRowCount == 0) {
                        ClearBindings();
                    }
                    _ignoreLeaveRow = false;
                    _ignorePositionChange = false;
                    SetBindings();
                    //EntityInstantFeedbackSource.Refresh();
                    GridViewLookup.FocusedRowHandle = DevExpress.Data.BaseListSourceDataController.FilterRow;
                    GridControlLookup.Focus();
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

        private void BarButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _ignoreLeaveRow = true;       //so that when the grid row changes it doesn't try to save again
            if (SaveRecord(true)) {
                //For some reason when there is no existing record in the binding source the Add method does not
                //trigger the CurrentChanged event, but AddNew does so use that instead
                _selectedRecord = (SVCRESTR)BindingSource.AddNew();
                //With the instant feedback data source, the new row is not immediately added to the grid, so move
                //the focused row to the filter row just so that no other existing row is visually highlighted
                GridViewLookup.FocusedRowHandle = DevExpress.Data.BaseListSourceDataController.FilterRow;
                SetReadOnlyKeyFields(false);
                SearchLookUpEditCode.Focus();
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
    }
}