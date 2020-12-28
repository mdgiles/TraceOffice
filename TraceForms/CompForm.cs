using System.ComponentModel;
using System.Runtime.InteropServices;
using FlexEntities.Entities;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using FlexModel;
using DevExpress.Data.Async.Helpers;
using FlexInterfaces.Core;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Drawing;
using DevExpress.XtraMap;
using DevExpress.Map;
using FlexCommissions;
using System.Data.Entity.Validation;

namespace TraceForms
{
    public partial class CompForm : DevExpress.XtraEditors.XtraForm
    {
        enum WeekDays : byte
        {
            Sunday = 1,
            Monday = 2,
            Tuesday = 4,
            Wednesday = 8,
            Thursday = 16,
            Friday = 32,
            Saturday = 64,
        }
        FlextourEntities _context;
        COMP _selectedRecord, _previousRecord;
        Timer _actionConfirmation;
        bool _ignoreLeaveRow = false, _ignorePositionChange = false;
        string _pupDrp = "";
        ICoreSys _sys;
        bool _isPass = false;
        RepositoryItemImageComboBox _supplierCombo = new RepositoryItemImageComboBox();
        RepositoryItemImageComboBox _operatorCombo = new RepositoryItemImageComboBox();
        List<CodeName> _allCats = new List<CodeName>();
        Dictionary<string, List<CodeName>> _locationLookups = new Dictionary<string, List<CodeName>>();
        Dictionary<string, RepositoryItemSearchLookUpEdit> _repos = new Dictionary<string, RepositoryItemSearchLookUpEdit>();
        Dictionary<string, List<CodeName>> _passLookups = new Dictionary<string, List<CodeName>>();
        List<IdName> _routes = new List<IdName>();
        List<CodeName> _daysOfWeek;
        Dictionary<String, List<CodeName>> _ServPackTypeLookups = new Dictionary<String, List<CodeName>>();
        private readonly DateTime _baseDate = new DateTime(1900, 1, 1);

        public CompForm(FlexInterfaces.Core.ICoreSys sys)
        {
            try {
                InitializeComponent();
                Connect(sys);
                LoadLookups();
                SetReadOnly(true);
                xtraTabPageRoutes.PageEnabled = false;
                SetMapProperties();         //Mapping
                //TimeEditDefaultTime.DataBindings.Add(new Binding("Text", this.BindingSource, "Default_Time", true, DataSourceUpdateMode.OnValidation));
            }
            catch (Exception ex) {
                DisplayHelper.DisplayError(this, ex);
            }
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            COMP.MaxLengths = Connection.GetMaxLengths(typeof(COMP).GetType().Name);
            ProductTax.MaxLengths = Connection.GetMaxLengths(typeof(ProductTax).GetType().Name);

            _context = new FlextourEntities(sys.Settings.EFConnectionString);
            _sys = sys;
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
            SearchLookupEditCity.Properties.DataSource = cities;
            SearchLookupEditDepCity.Properties.DataSource = depCities;
            _locationLookups.Add("CTY", cities);
            RepositoryItemSearchLookUpEditCty.DataSource = _locationLookups["CTY"];
            _repos.Add("CTY", RepositoryItemSearchLookUpEditCty);
            //repositoryItemImageComboboxLocation.DataSource = cities;


            var airports = new List<CodeName> {
                new CodeName(null)
            };
            airports.AddRange(_context.Airport
                .OrderBy(o => o.Code)
                .Select(s => new CodeName() { Code = s.Code, Name = s.Name}).ToList());
            SearchLookupEditAirportCode.Properties.DataSource = airports;

            var languages = new List<CodeName> {
                new CodeName(null)
            };
            languages.AddRange(_context.LANGUAGE
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }).ToList());
            SearchLookupEditLanguage.Properties.DataSource = languages;

            var difficulties = new List<IdName> {
                new IdName(null)
            };
            difficulties.AddRange(_context.CompDifficulty
                .OrderBy(o => o.DifficultyId)
                .Select(s => new IdName() { Id = s.DifficultyId, Name = s.Name }).ToList());
            SearchLookupEditDifficulty.Properties.DataSource = difficulties;

            var operators = new List<CodeName> {
                new CodeName(null)
            };
            operators.AddRange(_context.OPERATOR
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }).ToList());
            SearchLookupEditOperator.Properties.DataSource = operators;
            RepositoryItemSearchLookUpEditOperator.DataSource = operators;

            var categories = new List<CodeName> {
                new CodeName(null)
            };
            categories.AddRange(_context.ROOMCOD
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.DESC }).ToList());
            RepositoryItemSearchLookUpEditCat.DataSource = categories;
            RepositoryItemSearchLookUpEditDefaultCat.DataSource = categories;
            _allCats.AddRange(categories);
            RepositoryItemGridLookUpEditRoomcodTime.DataSource = _allCats;
            RepositoryItemGridLookUpEditRoomcodTax.DataSource = _allCats;

            var agencies = new List<CodeName> {
                new CodeName(null)
            };
            agencies.AddRange(_context.AGY
                .OrderBy(o => o.NO)
                .Select(s => new CodeName() { Code = s.NO, Name = s.NAME }).ToList());
            SearchLookupEditAgency.Properties.DataSource = agencies;
            RepositoryItemSearchLookUpEditAgy.DataSource = agencies;

            var states = new List<CodeName> {
                new CodeName(null)
            };
            states.AddRange(_context.State
                .OrderBy(o => o.Code)
                .Select(s => new CodeName() { Code = s.Code, Name = s.State1 }).ToList());  //discuss
            SearchLookupEditState.Properties.DataSource = states;

            var countries = new List<CodeName> {
                new CodeName(null)
            };
            countries.AddRange(_context.COUNTRY
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }).ToList());
            SearchLookupEditCountry.Properties.DataSource = countries;

            var servicetypes = new List<CodeName> {
                new CodeName(null)
            };
            servicetypes.AddRange(_context.SERVTYPE
                .OrderBy(o => o.TYPE)
                .Select(s => new CodeName() { Code = s.TYPE, Name = s.DESCRIP }).ToList());
            SearchLookupEditServiceType.Properties.DataSource = servicetypes;
            _ServPackTypeLookups.Add("OPT", servicetypes);

            var packtypes = new List<CodeName> {
                new CodeName(null)
            };
            packtypes.AddRange(_context.PACKTYPE
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.DESC }).ToList());
            _ServPackTypeLookups.Add("PKG", packtypes);

            var hotels = new List<CodeName>();
            hotels.AddRange(_context.HOTEL
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }).ToList());
            _locationLookups.Add("HTL", hotels);
            RepositoryItemSearchLookUpEditHtl.DataSource = _locationLookups["HTL"];
            _repos.Add("HTL", RepositoryItemSearchLookUpEditHtl);
            _passLookups.Add("HTL", hotels);

            //repositoryItemImageComboboxLocation.DataSource = hotels;

            var waypoints = new List<CodeName>();
            waypoints.AddRange(_context.WAYPOINT
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.DESC }).ToList());
            _locationLookups.Add("WAY", waypoints);
            RepositoryItemSearchLookUpEditWay.DataSource = _locationLookups["WAY"];
            _repos.Add("WAY", RepositoryItemSearchLookUpEditWay);
            //repositoryItemImageComboboxLocation.DataSource = waypoints;

            var supplements = new List<CodeName>();
            supplements.AddRange(_context.COMP
                .Where(c => c.IsSupplement)
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }).ToList());
            RepositoryItemSearchLookUpEditCompCode.DataSource = supplements;

            var products = new List<CodeName>();
            products.AddRange(_context.COMP
                .Where(c => !c.IsSupplement && c.Inactive != "Y")
                .OrderBy(o => o.CODE) 
                .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }).ToList());
            _locationLookups.Add("OPT", products);
            RepositoryItemSearchLookUpEditOpt.DataSource = _locationLookups["OPT"];
            _repos.Add("OPT", RepositoryItemSearchLookUpEditOpt);
            _passLookups.Add("OPT", products);

            products = new List<CodeName>();
            products.AddRange(_context.PACK
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }).ToList());
            _passLookups.Add("PKG", products);

            _supplierCombo.Items.Add(loadBlank);
            _supplierCombo.Items.AddRange(_context.Supplier
                            .OrderBy(o => o.Name).AsEnumerable()
                            .Select(s => new ImageComboBoxItem() { Description = s.Name, Value = s.GUID })
                            .ToList());
            GridControlSupplierProduct.RepositoryItems.Add(_supplierCombo);        //per DX recommendation to avoid memory leaks

            _operatorCombo.Items.Add(loadBlank);
            _operatorCombo.Items.AddRange(_context.OPERATOR
                            .OrderBy(o => o.NAME).AsEnumerable()
                            .Select(s => new ImageComboBoxItem() { Description = $"{s.CODE} ({s.NAME})", Value = s.CODE })
                            .ToList());
            GridControlSupplierProduct.RepositoryItems.Add(_operatorCombo);        //per DX recommendation to avoid memory leaks

            var memberships = new List<CodeName> {
                new CodeName(null)
            };
            memberships.AddRange(_context.LOOKUP.Where(c => c.LINK_TABLE == "DETAIL" && c.LINK_COLUMN == "CODE" && c.RECTYPE == "OPTCLASS")
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.DESC }).ToList());
            repositoryItemSearchLookUpEditClass.DataSource = memberships;

            var Categories = new List<CodeName> {
                new CodeName(null)
            };
            Categories.AddRange(_context.ROOMCOD
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.DESC }).ToList());
            RepositoryItemCustomSearchLookUpEditMappingCat.DataSource = Categories;

            BindingSourceUserFields.DataSource = _context.USERFIELDS
                .Where(u => (u.VISIBLE ?? false) && u.LINK_TABLE == "COMP")
                .OrderBy(u => u.POSITION);

            BindingSourceBusRoutes.DataSource = _context.BusRoute
                .OrderBy(r => r.Name);

            var taxes = new List<IdName>();
            taxes.AddRange(_context.Tax
                .OrderBy(o => o.Name)
                .Select(s => new IdName() { Id = s.Id, Name = s.Name }).ToList());
            repositoryItemSearchLookUpEdit1.DataSource = taxes;

            var regions = new List<CodeName> {
                new CodeName(null)
            };
            regions.AddRange(_context.REGION
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.DESC }).ToList());
            SearchLookUpEditRegion.Properties.DataSource = regions;

            var timeZones = TimeZoneInfo.GetSystemTimeZones();
            SearchLookUpEditTimeZone.Properties.DataSource = timeZones;
            SearchLookUpEditOriginTimeZone.Properties.DataSource = timeZones;
            RepositoryItemCheckedComboBoxEditDaysOfWeek.SetFlags(typeof(WeekDays));
        }

        private void EntityInstantFeedbackSource_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            FlextourEntities context = new FlextourEntities(Connection.EFConnectionString);
            e.QueryableSource = context.COMP;
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
                    COMP record = (COMP)proxy.OriginalRow;
                    BindingSource.DataSource = _context.COMP.Where(c => c.CODE == record.CODE)
                        .Include(c => c.GeoCode);
                    TextEditCode.ReadOnly = false;
                }
                else {
                    ClearBindings();
                }
            }
        }

        void ClearBindings()
        {
            _ignoreLeaveRow = true;
            _ignorePositionChange = true;
            _selectedRecord = null;
            BindingSourceSupplierProduct.Clear();
            SetReadOnly(true);
            BarButtonItemDelete.Enabled = false;
            BarButtonItemUpdateWebsite.Enabled = false;
            BarButtonItemSave.Enabled = false;
            BindingSource.DataSource = typeof(COMP);
            ClearMapData();                 //Mapping
            GridViewUserFields.LayoutChanged();     //forces the CustomUnboundColumnData event to fire to clear the custom fields
            _ignoreLeaveRow = false;
            _ignorePositionChange = false;
        }

        void SetBindings()
        {
            if (BindingSource.Current == null) {
                ClearBindings();
            }
            else {
                _selectedRecord = ((COMP)BindingSource.Current);
                _pupDrp = _selectedRecord.PUDRP_REQ;
                SetPupDrpCheckboxes();
                EnableTransferPointsTab(_selectedRecord.TRSFR_TYP);
                LoadAndBindSupplierProducts();
                LoadAndBindSupplierCategories();
                LoadAndBindMemberships();
                LoadAndBindTransferPoints();
                LoadAndBindBusRoutes();
                LoadAndBindSupplements();
                LoadAndBindRelatedProducts();
                LoadAndBindProductTimes();
                LoadAndBindProductTaxes();
                SetReadOnly(false);
                SetReadOnlyKeyFields(true);
                BarButtonItemDelete.Enabled = true;
                BarButtonItemUpdateWebsite.Enabled = true;
                BarButtonItemSave.Enabled = true;
                ShowMapData(_selectedRecord);           //Mapping
                GridViewUserFields.LayoutChanged();     //forces the CustomUnboundColumnData event to fire to display the custom fields
            }
            ErrorProvider.Clear();
        }

        private void FinalizeBindings()
        {
            BindingSource.EndEdit();
            //if (TextEditDefaultTime.EditValue != null) {
            //    _selectedRecord.Default_Time = ((DateTime)TextEditDefaultTime.EditValue).ToString("HHmm");
            //}
            GridViewSupplierProduct.CloseEditor();
            GridViewSupplierProduct.UpdateCurrentRow();
            GridViewSupplierCategory.CloseEditor();
            GridViewSupplierCategory.UpdateCurrentRow();
            GridViewSupplement.CloseEditor();
            GridViewSupplement.UpdateCurrentRow();
            GridViewDetail.CloseEditor();
            GridViewDetail.UpdateCurrentRow();
            GridViewUserFields.CloseEditor();
            GridViewUserFields.UpdateCurrentRow();
            GridViewRoutes.CloseEditor();
            GridViewRoutes.UpdateCurrentRow();
            GridViewTransferPoints.CloseEditor();
            GridViewTransferPoints.UpdateCurrentRow();
            GridViewRelatedProducts.CloseEditor();
            GridViewRelatedProducts.UpdateCurrentRow();
            GridViewProductTime.CloseEditor();
            GridViewProductTime.UpdateCurrentRow();
            GridViewProductTax.CloseEditor();
            GridViewProductTax.UpdateCurrentRow();
            _selectedRecord.PUDRP_REQ = _pupDrp;
            //Set the  code for each mapping just in case
            for (int rowCtr = 0; rowCtr < GridViewSupplierCategory.DataRowCount; rowCtr++) {
                SupplierCategory suppCat = (SupplierCategory)GridViewSupplierCategory.GetRow(rowCtr);
                suppCat.Product_Type = "OPT";
                suppCat.Product_Code = TextEditCode.Text ?? string.Empty;
                //Empty string represents no category mapping, but it needs to be null for the foreign key
                if (string.IsNullOrWhiteSpace(suppCat.Roomcod_Code)) {
                    suppCat.Roomcod_Code = null;
                }
            }
            BindingSourceSupplierCategory.EndEdit();

            for (int rowCtr = 0; rowCtr < GridViewRelatedProducts.DataRowCount; rowCtr++) {
                RelatedProduct relProduct = (RelatedProduct)GridViewRelatedProducts.GetRow(rowCtr);
                relProduct.Product_Type = "OPT";
                relProduct.Product_Code = TextEditCode.Text ?? string.Empty;
                relProduct.IsPassComponent = _isPass;
                if (!_isPass) {
                    relProduct.Reciprocal = false;
                    relProduct.ForUpSell = false;
                    relProduct.IsRoundTrip = false;
                    relProduct.IsReturn = false;
                    relProduct.ForPackaging = false;
                    relProduct.ServPackType_Code = null;
                    relProduct.Operator_Code = null;
                }
            }
            BindingSourceRelatedProduct.EndEdit();

            for (int rowCtr = 0; rowCtr < GridViewProductTime.DataRowCount; rowCtr++) {
                ProductTime prodTime = (ProductTime)GridViewProductTime.GetRow(rowCtr);
                prodTime.Product_Type = "OPT";
                prodTime.Product_Code = TextEditCode.Text ?? string.Empty;
                SetItemCategoryLookup(prodTime.Roomcod_Code);
            }
            BindingSourceProductTime.EndEdit();

            for (int rowCtr = 0; rowCtr < GridViewProductTax.DataRowCount; rowCtr++) {
                ProductTax prodTax = (ProductTax)GridViewProductTax.GetRow(rowCtr);
                prodTax.Product_Type = "OPT";
                prodTax.Product_Code = TextEditCode.Text ?? string.Empty;
                SetItemCategoryLookup(prodTax.Roomcod_Code);
            }
            BindingSourceProductTax.EndEdit();

            //Set the code for each mapping just in case
            for (int rowCtr = 0; rowCtr < GridViewSupplierProduct.DataRowCount; rowCtr++) {
                SupplierProduct suppProduct = (SupplierProduct)GridViewSupplierProduct.GetRow(rowCtr);
                suppProduct.Product_Type = "OPT";
                suppProduct.Product_Code_Internal = TextEditCode.Text ?? string.Empty;
            }
            BindingSourceSupplierProduct.EndEdit();

            //Set the code for each mapping just in case
            for (int rowCtr = 0; rowCtr < GridViewDetail.DataRowCount; rowCtr++) {
                DETAIL detail = (DETAIL)GridViewDetail.GetRow(rowCtr);
                detail.ProductType = "OPT";
                detail.LINK_VALUE = TextEditCode.Text ?? string.Empty;
                detail.RECTYPE = "OPTCLASS";
            }
            BindingSourceDetail.EndEdit();

            for (int rowCtr = 0; rowCtr < GridViewRoutes.DataRowCount; rowCtr++) {
                CompBusRoute route = (CompBusRoute)GridViewRoutes.GetRow(rowCtr);
                route.Comp_Type = "OPT";
                route.Comp_Code = TextEditCode.Text ?? string.Empty;
            }
            BindingSourceCompBusRoutes.EndEdit();

            for (int rowCtr = 0; rowCtr < GridViewTransferPoints.DataRowCount; rowCtr++) {
                BUSTABLE transfer = (BUSTABLE)GridViewTransferPoints.GetRow(rowCtr);
                transfer.TYPE = "OPT";
                transfer.CODE = TextEditCode.Text ?? string.Empty;
            }
            BindingSourceBusTable.EndEdit();
        }

        void LoadAndBindTransferPoints()
        {
            //Load the related entities. DO NOT do another db query using context.whatever because they
            //will not be associated with the parent entity, and new items will not be added to the relationship
            //so foreign key errors will result. Can't load the related entities on a detached or added (but not saved)
            //entity.
            if (_selectedRecord.EntityState != EntityState.Detached) {
                _selectedRecord.BUSTABLE.Load(MergeOption.OverwriteChanges);
            }
            //Don't do any LINQ operations on the entitycollection, just bind directly to it, otherwise
            //it appears to bind as unassociated with the context and you have to manually add/delete
            //rows from the bindingsource to the context (but changes work fine)
            BindingSourceBusTable.DataSource = _selectedRecord.BUSTABLE;
            BindTransferPoints();
        }

        void LoadAndBindBusRoutes()
        {
            //Load the related entities. DO NOT do another db query using context.whatever because they
            //will not be associated with the parent entity, and new items will not be added to the relationship
            //so foreign key errors will result. Can't load the related entities on a detached or added (but not saved)
            //entity.
            if (_selectedRecord.EntityState != EntityState.Detached) {
                _selectedRecord.CompBusRoute.Load(MergeOption.OverwriteChanges);
            }
            //Don't do any LINQ operations on the entitycollection, just bind directly to it, otherwise
            //it appears to bind as unassociated with the context and you have to manually add/delete
            //rows from the bindingsource to the context (but changes work fine)
            BindingSourceCompBusRoutes.DataSource = _selectedRecord.CompBusRoute;
            BindCompBusRoutes();
        }

        void LoadAndBindSupplierProducts()
        {
            //Load the related entities. DO NOT do another db query using context.whatever because they
            //will not be associated with the parent entity, and new items will not be added to the relationship
            //so foreign key errors will result. Can't load the related entities on a detached or added (but not saved)
            //entity.
            if (_selectedRecord.EntityState != EntityState.Detached) {
                _selectedRecord.SupplierProduct.Load(MergeOption.OverwriteChanges);
            }
            //Don't do any LINQ operations on the entitycollection, just bind directly to it, otherwise
            //it appears to bind as unassociated with the context and you have to manually add/delete
            //rows from the bindingsource to the context (but changes work fine)
            BindingSourceSupplierProduct.DataSource = _selectedRecord.SupplierProduct;
            BindSupplierProducts();
        }

        void BindSupplierProducts()
        {
            GridControlSupplierProduct.DataSource = BindingSourceSupplierProduct;
            GridControlSupplierProduct.RefreshDataSource();
        }

        void LoadAndBindSupplierCategories()
        {
            //Load the related entities. DO NOT do another db query using context.whatever because they
            //will not be associated with the parent entity, and new items will not be added to the relationship
            //so foreign key errors will result. Can't load the related entities on a detached or added (but not saved)
            //entity.
            if (_selectedRecord.EntityState != EntityState.Detached) {
                _selectedRecord.SupplierCategory.Load(MergeOption.OverwriteChanges);
            }
            //Don't do any LINQ operations on the entitycollection, just bind directly to it, otherwise
            //it appears to bind as unassociated with the context and you have to manually add/delete
            //rows from the bindingsource to the context (but changes work fine)
            BindingSourceSupplierCategory.DataSource = _selectedRecord.SupplierCategory;
            BindSupplierCategories();
        }

        void LoadAndBindMemberships()
        {
            //Load the related entities. DO NOT do another db query using context.whatever because they
            //will not be associated with the parent entity, and new items will not be added to the relationship
            //so foreign key errors will result. Can't load the related entities on a detached or added (but not saved)
            //entity.
            if (_selectedRecord.EntityState != EntityState.Detached) {
                _selectedRecord.DETAIL.Load(MergeOption.OverwriteChanges);
            }
            //Don't do any LINQ operations on the entitycollection, just bind directly to it, otherwise
            //it appears to bind as unassociated with the context and you have to manually add/delete
            //rows from the bindingsource to the context (but changes work fine)
            BindingSourceDetail.DataSource = _selectedRecord.DETAIL;
            BindMemberships();
        }

        void BindMemberships()
        {
            GridControlDetail.DataSource = BindingSourceDetail;
            GridControlDetail.RefreshDataSource();
        }

        void BindSupplierCategories()
        {
            GridControlSupplierCategory.DataSource = BindingSourceSupplierCategory;
            GridControlSupplierCategory.RefreshDataSource();
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
                        //If we prompted then it's because the user is changing the selected record so we don't need
                        //to keep track of the previously selected record
                        _previousRecord = null;
                    }
                    else {
                        //If we didn't prompt then the user has clicked the Save button where the expectation is that
                        //the currently selected row will remain selected.  However EntityInstantFeedbackSource does not have
                        //a way to refresh a single record and refreshing the data source causes the focused row to be reset
                        //back to the top row.  Therefore we store the value of the previous selection and set the row focus
                        //back in GridView AsyncCompleted.  This means there will be a flash of the incorrect top row being
                        //displayed before being set back to the previously selected row. DevExpress have no way around this.
                        _previousRecord = _selectedRecord;
                    }
                    if (!ValidateAll())
                        return false;

                    if (_selectedRecord.EntityState == System.Data.Entity.EntityState.Detached) {
                        _context.COMP.AddObject(_selectedRecord);
                    }
                    SetUpdateFields(_selectedRecord);
                    _context.SaveChanges();
                    EntityInstantFeedbackSource.Refresh();
                    ShowActionConfirmation("Record Saved");
                }
                return true;
            }
            catch (DbEntityValidationException ex) {
                string details = string.Join(Environment.NewLine, ex.EntityValidationErrors.Select(e =>
                string.Join(Environment.NewLine, e.ValidationErrors.Select(v =>
                string.Format("{0} - {1}", v.PropertyName, v.ErrorMessage)))));
                return false;
            }
            catch (Exception ex) {
                DisplayHelper.DisplayError(this, ex);
                RefreshRecord();        //pull it back from db because that is its current state
                                        //We must also Load and rebind the related entities from the db because context.Refresh doesn't do that
                SetBindings();
                return false;
            }
        }

        private void GridViewLookup_AsyncCompleted(object sender, EventArgs e)
        {
            if (_previousRecord != null && _selectedRecord != null && !_ignoreLeaveRow) {
                GridView view = (GridView)sender;
                int rowHandle = view.LocateByValue("CODE", _previousRecord.CODE, OnRowSearchComplete);
                if (rowHandle != DevExpress.Data.DataController.OperationInProgress) {
                    SetFocusedRow(GridViewLookup, rowHandle);
                }
            }
        }

        void OnRowSearchComplete(object rh)
        {
            int rowHandle = (int)rh;
            if (GridViewLookup.IsValidRowHandle(rowHandle)) {
                SetFocusedRow(GridViewLookup, rowHandle);
            }
        }

        void SetFocusedRow(GridView view, int rowHandle)
        {
            //precaution to make sure that any subsequent row changes don't try to force the selected
            //row back to the previously selected one again
            _previousRecord = null;
            view.FocusedRowHandle = rowHandle;
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
                            _context.COMP.DeleteObject(_selectedRecord);
                        _context.SaveChanges();
                    }
                    if (GridViewLookup.DataRowCount == 0) {
                        ClearBindings();
                    }
                    _ignoreLeaveRow = false;
                    _ignorePositionChange = false;
                    SetBindings();
                    EntityInstantFeedbackSource.Refresh();
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

        private void GridViewLookup_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            //If the user selects a row, edits, then selects the auto-filter row, then selects a different row,
            //this event will fire for the auto-filter row, so we cannot ignore it because there is still a record
            //that may need to be saved. 
            if (!_ignoreLeaveRow && IsModified(_selectedRecord)) {
                e.Allow = SaveRecord(true);
            }
        }

        private void SetUpdateFields(COMP record)
        {
            record.LAST_UPD = DateTime.Now;
            record.UPD_INIT = _sys.User.Name;
        }

        private bool IsModified(COMP record)
        {
            //Type-specific routine that takes into account relationships that should also be considered
            //when deciding if there are unsaved changes.  The entity properties also return true if the
            //record is new or deleted.
            if (record == null)
                return false;
            return record.IsModified(_context)
                || record.SupplierProduct.IsModified(_context)
                || record.SupplierCategory.IsModified(_context)
                || record.ProductSupplement.IsModified(_context)
                || record.BUSTABLE.IsModified(_context)
                || record.CompBusRoute.IsModified(_context)
                || record.DETAIL.IsModified(_context)
                || record.RelatedProduct1.IsModified(_context)
                || record.ProductTime.IsModified(_context)
                || record.GeoCode.IsModified(_context);     //Mapping
        }

        private void RemoveRecord()
        {
            if (_selectedRecord.IsNew()) {
                //If you clear the bindingsource for child records where the parent entity is tracked by
                //the context, it will lose tracking for the child entities and cascade operations like
                //delete will fail
                BindingSourceSupplierProduct.Clear();
                BindingSourceSupplierCategory.Clear();
                BindingSourceCompBusRoutes.Clear();
                BindingSourceRelatedProduct.Clear();
                BindingSourceProductTime.Clear();
                BindingSourceBusTable.Clear();
                BindingSourceSupplements.Clear();
                BindingSourceDetail.Clear();
            }
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
            if (_selectedRecord != null && _selectedRecord.EntityState != EntityState.Detached
                && _selectedRecord.EntityState != EntityState.Added) {
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
            SetErrorInfo(_selectedRecord.ValidateLanguage, SearchLookupEditLanguage);
            SetErrorInfo(_selectedRecord.ValidateVendorCode, TextEditVendorCode);
            SetErrorInfo(_selectedRecord.ValidateDefaultTime, TextEditDefaultTime);
            SetErrorInfo(_selectedRecord.ValidateDifficulty, SearchLookupEditDifficulty);
            SetErrorInfo(_selectedRecord.ValidateOperator, SearchLookupEditOperator);
            SetErrorInfo(_selectedRecord.ValidateVoucherType, ImageComboBoxEditVoucherTypes);
            SetErrorInfo(_selectedRecord.ValidateRateBasis, ImageComboBoxEditRateBasis);
            SetErrorInfo(_selectedRecord.ValidateRestricCode, ImageComboBoxEditRestrictionsCode);
            SetErrorInfo(_selectedRecord.ValidateTransferType, GridControlTransferPoints);
            SetErrorInfo(_selectedRecord.ValidateTransfers, GridControlTransferPoints);
            SetErrorInfo(_selectedRecord.ValidateServType, SearchLookupEditServiceType);
            SetErrorInfo(_selectedRecord.ValidateVouch, SpinEditDayPrior);
            SetErrorInfo(_selectedRecord.ValidateDistance, SpinEditDistance);
            SetErrorInfo(_selectedRecord.ValidateCity, SearchLookupEditCity);
            SetErrorInfo(_selectedRecord.ValidateState, SearchLookupEditState);
            SetErrorInfo(_selectedRecord.ValidateAddress1, TextEditAddr1);
            SetErrorInfo(_selectedRecord.ValidateAddress2, TextEditAddr2);
            SetErrorInfo(_selectedRecord.ValidateAddress3, TextEditAddr3);
            SetErrorInfo(_selectedRecord.ValidateZip, TextEditZip);
            SetErrorInfo(_selectedRecord.ValidateCountry, SearchLookupEditCountry);
            SetErrorInfo(_selectedRecord.ValidateAirport, SearchLookupEditAirportCode);
            SetErrorInfo(_selectedRecord.ValidateAirMi, TextEditAirportMiles);
            SetErrorInfo(_selectedRecord.ValidateCityMi, TextEditCityMilesTo);
            SetErrorInfo(_selectedRecord.ValidateInclude1, TextEditIncl1);
            SetErrorInfo(_selectedRecord.ValidateInclude2, TextEditIncl2);
            SetErrorInfo(_selectedRecord.ValidateInclude3, TextEditIncl3);
            SetErrorInfo(_selectedRecord.ValidateInclude4, TextEditIncl4);
            SetErrorInfo(_selectedRecord.ValidateInclude5, TextEditIncl5);
            SetErrorInfo(_selectedRecord.ValidateInclude6, TextEditIncl6);
            SetErrorInfo(_selectedRecord.ValidateDuration, SpinEditDuration);
            SetErrorInfo(_selectedRecord.ValidateMaxDuration, SpinEditMaxDuration);
            SetErrorInfo(_selectedRecord.ValidateSupplierProducts, GridControlSupplierProduct);
            SetErrorInfo(_selectedRecord.ValidateSupplierCategories, GridControlSupplierCategory);
            SetErrorInfo(_selectedRecord.ValidateSupplements, GridControlSupplements);
            SetErrorInfo(_selectedRecord.ValidateRelatedProducts, GridControlRelatedProducts);
            SetErrorInfo(_selectedRecord.ValidateDepartureCity, SearchLookupEditDepCity);
        }

        private void SetErrorInfo(Func<String> validationMethod, object sender)
        {
            BindingSource.EndEdit();
            if (validationMethod != null) {
                string error = validationMethod.Invoke();
                ErrorProvider.SetError((Control)sender, error);
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
            if (info.InMapPushpin) {
                MapControl.EnableScrolling = false;
                foreach (object obj in info.HitObjects) {
                    if (obj.GetType() == typeof(MapPushpin))
                        _pin = (MapPushpin)obj;
                }
            }
        }

        private void MapControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (_pin != null) {
                CoordPoint point = MapControl.ScreenPointToCoordPoint(new MapPoint(e.X, e.Y));
                _pin.Location = point;
            }
        }

        private void MapControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (_pin != null) {
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
            if (attrib == null) {
                pin.Attributes.Add(new MapItemAttribute() {
                    Name = "id",
                    Type = typeof(int),
                    Value = geoCode.GeoCodeId
                });
            }
            else {
                attrib.Value = geoCode.GeoCodeId;
            }
        }

        private MapPushpin AddOrMovePushpin(GeoPoint geoPoint)
        {
            MapItem item = MapItemStorage.Items.FirstOrDefault();
            MapPushpin pin;
            if (item == null) {
                pin = new MapPushpin();
                MapItemStorage.Items.Add(pin);
            }
            else {
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
            if (result.ResultCode == RequestResultCode.Success) {
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
            string search = $"{TextEditName.Text}, {SearchLookupEditState.EditValue}, {(SearchLookupEditCountry.EditValue as CodeName)?.Name}";
            BingSearchDataProvider.Search(search);
        }

        private void ShowMapData(COMP record)
        {
            GeoCode geoCode = record?.GeoCode ?? new GeoCode();
            AddOrMovePushpin(geoCode);
            //If a bounding box has been given, then use it
            if (geoCode.NorthLat != 0) {
                var topLeft = new GeoPoint(geoCode.NorthLat, geoCode.WestLong);
                var bottomRight = new GeoPoint(geoCode.SouthLat, geoCode.EastLong);
                MapControl.ZoomToRegion(topLeft, bottomRight, 0);
            }
            else {
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
            if (item != null) {
                MapPushpin pin = (MapPushpin)item;
                GeoPoint location = (GeoPoint)pin.Location;
                //If lat and long are zero, then there was no geocode to begin with and the user didn't specify one
                //during the edit, so don't update the values
                if (location.Longitude != 0 || location.Latitude != 0) {
                    if (_selectedRecord.GeoCode == null) {
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

        private void GridViewComponents_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box       
        }

        private void ImageComboBoxEditTransType_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateTransferType, sender);
        }

        private void SpinEditDayPrior_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateVouch, sender);
        }

        private void TextEditIncl1_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateInclude1, sender);
        }

        private void TextEditIncl2_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateInclude2, sender);
        }

        private void TextEditIncl3_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateInclude3, sender);
        }

        private void TextEditIncl4_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateInclude4, sender);
        }

        private void TextEditIncl5_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateInclude5, sender);
        }

        private void TextEditIncl6_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateInclude6, sender);
        }

        private void TextEditAPNumber_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateAP, sender);
        }

        private void TextEditARNumber_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateAR, sender);
        }

        private void ImageComboBoxEditRestrictionsCode_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateRestricCode, sender);
        }

        private void ImageComboBoxEditRateBasis_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateRateBasis, sender);
        }

        private void ButtonAddRow_Click(object sender, EventArgs e)
        {
            var busTable = new BUSTABLE() {
                LAST_UPD = DateTime.Today,
                UPD_INIT = _sys.User.Name,
                CODE = TextEditCode.Text,
                TYPE = "OPT",
                Exclusion = "0",
            };

            if (ImageComboBoxEditTransType.Text == "Outbound") {
                busTable.In_Out = "O";
            }
            else {
                busTable.In_Out = "I";
            }

            if(CheckEditPickup.Checked == true || CheckEditDropoff.Checked == true) {
                busTable.PUP_DRP = _pupDrp;
            }
            _selectedRecord.BUSTABLE.Add(busTable);
            BindTransferPoints();
            GridViewTransferPoints.FocusedRowHandle = BindingSourceBusTable.Count - 1;
        }

        private void ButtonDelRow_Click(object sender, EventArgs e)
        {
            if (GridViewTransferPoints.FocusedRowHandle >= 0) {
                BUSTABLE transfer = (BUSTABLE)GridViewTransferPoints.GetFocusedRow();
                _selectedRecord.BUSTABLE.Remove(transfer);
                //Removing from the collection just removes the object from its parent, but does not mark
                //it for deletion, effectively orphaning it.  This will cause foreign key errors when saving.
                //To flag for deletion, delete it from the context as well.
                if (!transfer.IsNew()) {
                    _context.BUSTABLE.DeleteObject(transfer);
                }
            }
        }

        void BindTransferPoints()
        {
            GridControlTransferPoints.DataSource = BindingSourceBusTable;
            GridControlTransferPoints.RefreshDataSource();
        }

        private void TextEditVendorCode_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateVendorCode, sender);
        }

        private void GridViewUserFields_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.Column == GridColumnCustomValue) {
                string fieldName = GridViewUserFields.GetRowCellValue(e.ListSourceRowIndex, "LINK_COLUMN").ToString();
                if (e.IsGetData) {
                    e.Value = _selectedRecord.GetPropertyValue(fieldName);
                }
                else if (e.IsSetData && _selectedRecord != null) {
                    //FinalizeBindings();
                    _selectedRecord.SetPropertyValue(fieldName, e.Value);
                }
            }
        }

        private void SetPupDrpCheckboxes()
        {
            if (_pupDrp == "B")
            {
                CheckEditPickup.Checked = true;
                CheckEditDropoff.Checked = true;
            }
            if (_pupDrp == "P")
            {
                CheckEditPickup.Checked = true;
                CheckEditDropoff.Checked = false;
            }
            if (_pupDrp == "D")
            {
                CheckEditPickup.Checked = false;
                CheckEditDropoff.Checked = true;
            }
            if (string.IsNullOrWhiteSpace(_pupDrp))
            {
                CheckEditPickup.Checked = false;
                CheckEditDropoff.Checked = false;                
            }
        }

        private void GridViewTransferPoints_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            GridColumn columnInOut, columnPickupDrop, columnDate, columnEndDate, columnLocationType, columnLocation, columnCarOFfice, columnTime, columnEndTime;
            ColumnView view = sender as ColumnView;
            view.ClearColumnErrors();
            columnInOut = view.Columns["In_Out"];
            columnPickupDrop = view.Columns["PUP_DRP"];
            columnDate = view.Columns["DATE"];
            columnEndDate = view.Columns["EndDate"];
            columnLocationType = view.Columns["LocationType"];
            columnLocation = view.Columns["LOCATION"];
            columnCarOFfice = view.Columns["CarOffice"];
            columnTime = view.Columns["TIME"];
            columnEndTime = view.Columns["EndTime"];
			string strInOut = view.GetRowCellDisplayText(e.RowHandle, columnInOut);
			string strPickupDrop = view.GetRowCellDisplayText(e.RowHandle, columnPickupDrop);
            string strDate = view.GetRowCellDisplayText(e.RowHandle, columnDate);
            string strEndDate = view.GetRowCellDisplayText(e.RowHandle, columnEndDate);
            string strLocationType = view.GetRowCellDisplayText(e.RowHandle, columnLocationType);
            string strLocation = view.GetRowCellDisplayText(e.RowHandle, columnLocation);
            string strCarOFfice = (string)view.GetRowCellValue(e.RowHandle, columnCarOFfice);
            string strTime = view.GetRowCellDisplayText(e.RowHandle, columnTime);
            string strEndTime = view.GetRowCellDisplayText(e.RowHandle, columnEndTime);
            //if (string.IsNullOrWhiteSpace(strInOut))
            //{
            //    e.Valid = false;
            //    view.SetColumnError(columnInOut, "Direction cannot be blank in a row.");
            //}
            if (string.IsNullOrWhiteSpace(strPickupDrop))
            {
                e.Valid = false;
                view.SetColumnError(columnPickupDrop, "Pickup/Dropoff cannot be blank in a row.");
            }
			//if (string.IsNullOrWhiteSpace(strDate))
			//{
			//	e.Valid = false;
			//	view.SetColumnError(columnDate, "Start date cannot be blank in a row.");
			//}
			//if (string.IsNullOrWhiteSpace(strEndDate))
			//{
			//	e.Valid = false;
			//	view.SetColumnError(columnEndDate, "End date cannot be blank in a row.");
			//}
			if (DateTime.TryParse(strDate, out DateTime startDate) && DateTime.TryParse(strEndDate, out DateTime endDate)) {
				if (startDate > endDate)
				{
					e.Valid = false;
					view.SetColumnError(columnEndDate, "End date must be greater or equal to start date.");
				}
			}
            if (string.IsNullOrWhiteSpace(strLocationType))
            {
                e.Valid = false;
                view.SetColumnError(columnLocationType, "Location type cannot be blank in a row.");
            }
            if (string.IsNullOrWhiteSpace(strLocation))
            {
                e.Valid = false;
                view.SetColumnError(columnLocation, "Location cannot be blank in a row.");
            }
            if (!string.IsNullOrWhiteSpace(strCarOFfice))
            {
                if ((from c in _context.CAROFF where c.OFF == strCarOFfice select c).Count() == 0)
                {
                    e.Valid = false;
                    view.SetColumnError(columnCarOFfice, "Car office entered does not exist please select one from the list provided.");
                }
            }
            if (!string.IsNullOrWhiteSpace(strTime))
            {
                if (!validCheck.IsNumeric(strTime) || strTime.Length != 4 || Convert.ToInt32(strTime) > 2359 || Convert.ToInt32(strTime) < 0)
                {
                    e.Valid = false;
                    view.SetColumnError(columnTime, "Departure time must be numeric and between 0000 and 2359.");
                }
            }
            if (!string.IsNullOrWhiteSpace(strEndTime))
            {
                if (!validCheck.IsNumeric(strEndTime) || strEndTime.Length != 4 || Convert.ToInt32(strEndTime) > 2359 || Convert.ToInt32(strEndTime) < 0)
                {
                    e.Valid = false;
                    view.SetColumnError(columnEndTime, "Arrival time must be numeric and between 0000 and 2359.");
                }
            }            
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            DateTime? date;
            if (ButtonEditDate.Text == "")
            {
                date = null;
            }
            else
            {
                date = Convert.ToDateTime(ButtonEditDate.Text);
            }
            
            string agency;
            string source;
            if (string.IsNullOrWhiteSpace(SearchLookupEditAgency.Text))
                agency = "TARIFF";
            else
                agency = SearchLookupEditAgency.Text;

            if (string.IsNullOrWhiteSpace(ComboBoxEditSource.Text))
                source = "ALL";
            else
                source = ComboBoxEditSource.Text;



            UpdateCommMarkupGrid(agency, date, source);
        }

        private void TextEditDefaultTime_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateDefaultTime, sender);
        }

        private void GridViewTransferPoints_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {  
            if (e.Column.FieldName == "LocationType")
            {//If location type changes, clear the columns
                GridViewTransferPoints.SetFocusedRowCellValue("LOCATION", "");
                GridViewTransferPoints.SetFocusedRowCellValue("Exclusion", "0");
            }
        }

        private void GridViewTransferPoints_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void GridViewTransferPoints_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            GridView view = (GridView)sender;
            if (e.Column.FieldName == ColumnLocation.FieldName)
            {
                string type = view.GetRowCellDisplayText(e.RowHandle, "LocationType");
                if (_repos.ContainsKey(type)) {
                    e.RepositoryItem = _repos[type];
                }
            }
			if (e.Column.FieldName == "CompBusRoute_ID") {
                RepositoryItemImageComboBox editor = new RepositoryItemImageComboBox();
				editor.Items.Add(new ImageComboBoxItem() { Description = "", Value = null });
				foreach (var result in BindingSourceCompBusRoutes.List) {
                    CompBusRoute route = (CompBusRoute)result;
					ImageComboBoxItem load = new ImageComboBoxItem() { Description = route.BusRoute.Name, Value = route.ID };
					editor.Items.Add(load);
				}
				e.RepositoryItem = editor;
			}
            //It turns out that CHD were using the exclusion field as an inactive field, so it needs to be allowed on all records.
            //if (e.Column == ColumnExclusion) {
            //    string type = GridViewTransferPoints.GetRowCellDisplayText(e.RowHandle, "LocationType");
            //    if (type != "HTL") {
            //        e.RepositoryItem = repositoryItemCheckEditReadOnly;
            //    }
            //    else {
            //        e.RepositoryItem = RepositoryItemCheckEditLocationExclusion;
            //    }
            //}
        }

        private void TextEditCode_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCode, sender);
        }

        private void ImageComboBoxEditOperator_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateOperator, sender);
        }

        private void ImageComboBoxEditState_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateState, sender);
        }

        private void ImageComboBoxEditCountry_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCountry, sender);
        }

        private void ImageComboBoxEditAirportCode_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateAirport, sender);
        }

        private void ImageComboBoxEditCity_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCity, sender);
        }

        private void SearchLookupEditServiceType_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateServType, sender);
        }

        private void GridViewTransferPoints_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            string name = GridViewTransferPoints.GetRowCellDisplayText(e.FocusedRowHandle, "LocationType");
            GridColumn col = GridViewTransferPoints.Columns["CarOffice"];
            switch (name)
            {
                case "BUS":
                    col.OptionsColumn.AllowFocus = false;
                    break;
                case "CAR":
                    col.OptionsColumn.AllowFocus = true;
                    break;
                case "CRU":
                    col.OptionsColumn.AllowFocus = false;
                    break;
                case "CTY":
                    col.OptionsColumn.AllowFocus = false;
                    break;
                case "HTL":
                    col.OptionsColumn.AllowFocus = false;
                    break;
                case "TRN":
                    col.OptionsColumn.AllowFocus = false;
                    break;
                case "WAY":
                    col.OptionsColumn.AllowFocus = false;
                    break;
                case "AIR":
                    col.OptionsColumn.AllowFocus = false;
                    break;
                default:
                    col.OptionsColumn.AllowFocus = false;
                    break;
            }
        }

        private void GridViewCommissions_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if ((e.Column.FieldName == "ResStartDate" || e.Column.FieldName == "ResEndDate" || e.Column.FieldName == "SvcStartDate" || e.Column.FieldName == "SvcEndDate") && !string.IsNullOrWhiteSpace(e.DisplayText))
                e.DisplayText = validCheck.convertDate(e.DisplayText);                        
        }

        private void GridViewMarkups_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if ((e.Column.FieldName == "ResStartDate" || e.Column.FieldName == "ResEndDate" || e.Column.FieldName == "SvcStartDate" || e.Column.FieldName == "SvcEndDate") && !string.IsNullOrWhiteSpace(e.DisplayText))
                e.DisplayText = validCheck.convertDate(e.DisplayText);                      
        }

        private void UpdateCommMarkupGrid(string agency, DateTime? date, string source)
        {
            List<IComprod2> commRecs;
            List<IComprod2> commRecsAgy;
            List<ICommLevel> commLevel;

            commRecs = (from rec in _context.COMPROD2
                        where (rec.TYPE == "OPT") && (!(rec.Inactive ?? true)) && (((rec.START_DATE ?? DateTime.MinValue) <= (date ?? DateTime.MaxValue))
                        && ((rec.END_DATE ?? DateTime.MaxValue) >= (date ?? DateTime.MinValue)))
                        select rec).ToList<IComprod2>();
            commRecsAgy = (from rec in _context.COMPROD2
                           where (rec.TYPE == "AGY") && (!(rec.Inactive ?? true)) && (((rec.START_DATE ?? DateTime.MinValue) <= (date ?? DateTime.MaxValue))
                       && ((rec.END_DATE ?? DateTime.MaxValue) >= (date ?? DateTime.MinValue)))
                           select rec).ToList<IComprod2>();
            commLevel = (from rec in _context.CommLevel select rec).ToList<ICommLevel>();

            foreach (COMPROD2 rec in commRecs) {
                rec.SetProductRulePosition(commLevel);
            }
            foreach (COMPROD2 rec in commRecsAgy) {
                rec.SetProductRulePosition(commLevel);
            }

            using FlextourEntities context2 = new FlextourEntities(Connection.EFConnectionString);
            IList<Commission> commQuery1 = new List<Commission>();
            IList<Commission> commQuery2 = new List<Commission>();
            commQuery1 = Commissions.GetProductCommissions(context2, "C", TextEditCode.Text.TrimEnd(), "OPT", commRecs, commLevel, null, date, null, null, agency, source);
            commQuery2 = Commissions.GetAgencyCommissions(context2, "C", commRecsAgy, commLevel, agency, date, null, null, source);
            IList<Commission> mergedList = (commQuery1.Union(commQuery2)).ToList();
            GridControlCommissions.DataSource = mergedList;
            commQuery1 = Commissions.GetProductCommissions(context2, "M", TextEditCode.Text.TrimEnd(), "OPT", commRecs, commLevel, null, date, null, null, agency, source);
            commQuery2 = Commissions.GetAgencyCommissions(context2, "M", commRecsAgy, commLevel, agency, date, null, null, source);
            mergedList = (commQuery1.Union(commQuery2)).ToList();
            GridControlMarkups.DataSource = mergedList;
        }

        private void ImageComboBoxEditLanguage_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateLanguage, sender);
        }

        private void ImageComboBoxEditDifficulty_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateDifficulty, sender);
        }

        private void TextEditName_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateName, sender);
        }

        private void DurationTimeEdit_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateDuration, sender);
        }

        private void CompForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void TextEditAddr1_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateAddress1, sender);
        }

        private void TextEditAddr2_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateAddress2, sender);
        }

        private void TextEditAddr3_Leave(object sender, EventArgs e)
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

		private void CheckEditProximitySearch_CheckedChanged(object sender, EventArgs e)
		{
			SpinEditDistance.Enabled = (CheckEditProximitySearch.Checked);
			if (!CheckEditProximitySearch.Checked)
				SpinEditDistance.Value = 0;
		}

		private void SpinEditDistance_Leave(object sender, EventArgs e)
		{
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateDistance, sender);
        }

		private void SimpleButtonAddRoute_Click(object sender, EventArgs e)
		{
            CompBusRoute route = new CompBusRoute {
                Comp_Code = TextEditCode.Text ?? string.Empty,
                Comp_Type = "OPT"
            };
            _selectedRecord.CompBusRoute.Add(route);
            BindCompBusRoutes();
            GridViewRoutes.FocusedRowHandle = BindingSourceCompBusRoutes.Count - 1;	
		}

		private void SimpleButtonRemoveRoute_Click(object sender, EventArgs e)
		{
			if (GridViewRoutes.FocusedRowHandle >= 0) {
				CompBusRoute route = (CompBusRoute)GridViewRoutes.GetFocusedRow();
				BindingSourceCompBusRoutes.Remove(route);
                //Removing from the bindingsource just removes the object from its parent, but does not mark
                //it for deletion, effectively orphaning it.  This will cause foreign key errors when saving.
                //To flag for deletion, delete it from the context as well.
                if (!route.IsNew()) {
                    _context.CompBusRoute.DeleteObject(route);
                }
                BindCompBusRoutes();
			}
		}

		private void BindCompBusRoutes()
		{
			GridControlRoutes.DataSource = BindingSourceCompBusRoutes;
			GridControlRoutes.RefreshDataSource();
		}

		private void GridViewRoutes_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
		{
			e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box       
		}

		private void GridViewRoutes_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
		{
			if (e.IsGetData) {
				var compRoute = (CompBusRoute)BindingSourceCompBusRoutes.List[e.ListSourceRowIndex];
				if (compRoute != null && compRoute.BusRoute != null) {
					if (e.Column == gridColumnStartDate) {
						e.Value = compRoute.BusRoute.StartDate;
					}
					if (e.Column == gridColumnEndDate) {
						e.Value = compRoute.BusRoute.EndDate;
					}
					if (e.Column == gridColumnInactive) {
						e.Value = compRoute.BusRoute.Inactive;
					}
				}
				else {
					if (e.Column == gridColumnStartDate) {
						e.Value = null;
					}
					if (e.Column == gridColumnEndDate) {
						e.Value = null;
					}
					if (e.Column == gridColumnInactive) {
						e.Value = null;
					}
				}
			}
		}

		private void GridViewRoutes_ValidateRow(object sender, ValidateRowEventArgs e)
		{
			ColumnView view = sender as ColumnView;
			view.ClearColumnErrors();
			GridColumn columnRoute = view.Columns["BusRoute_ID"];
			for (int ctr = 0; ctr < view.RowCount; ctr++) {
				if (ctr != e.RowHandle) {
					if (view.GetRowCellValue(ctr, columnRoute) == view.GetRowCellValue(e.RowHandle, columnRoute)) {
						e.Valid = false;
						view.SetColumnError(columnRoute, "This route has already been assigned.");
					}
				}
			}
		}

		private void ButtonAddMembership_Click(object sender, EventArgs e)
		{
            DETAIL detail = new DETAIL {
                LINK_VALUE = TextEditCode.Text ?? string.Empty,
                ProductType = "OPT",
                RECTYPE = "OPTCLASS"
            };
            _selectedRecord.DETAIL.Add(detail);
            BindMemberships();
            GridViewDetail.FocusedRowHandle = BindingSourceDetail.Count - 1;
        }

        private void ButtonDelMembership_Click(object sender, EventArgs e)
		{
            if (GridViewDetail.FocusedRowHandle >= 0) {
                DETAIL detail = (DETAIL)GridViewDetail.GetFocusedRow();
                BindingSourceDetail.Remove(detail);
                //Removing from the bindingsource just removes the object from its parent, but does not mark
                //it for deletion, effectively orphaning it.  This will cause foreign key errors when saving.
                //To flag for deletion, delete it from the context as well.
                if (!detail.IsNew()) {
                    _context.DETAIL.DeleteObject(detail);
                }
                BindMemberships();
            }
        }

        private void SimpleButtonAddSuppMapping_Click(object sender, EventArgs e)
        {
            SupplierProduct suppProduct = new SupplierProduct {
                Product_Code_Internal = TextEditCode.Text ?? string.Empty,
                Product_Type = "OPT"
            };
            _selectedRecord.SupplierProduct.Add(suppProduct);
            BindSupplierProducts();
            GridViewSupplierProduct.FocusedRowHandle = BindingSourceSupplierProduct.Count - 1;
        }

        private void SimpleButtonDelSuppMapping_Click(object sender, EventArgs e)
        {
            if (GridViewSupplierProduct.FocusedRowHandle >= 0) {
                SupplierProduct suppProduct = (SupplierProduct)GridViewSupplierProduct.GetFocusedRow();
                _selectedRecord.SupplierProduct.Remove(suppProduct);
                //Removing from the collection just removes the object from its parent, but does not mark
                //it for deletion, effectively orphaning it.  This will cause foreign key errors when saving.
                //To flag for deletion, delete it from the context as well.
                if (!suppProduct.IsNew()) {
                    _context.SupplierProduct.DeleteObject(suppProduct);
                }
                BindSupplierProducts();
            }
        }

        private void GridViewSupplierProduct_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        void GridViewSupplierProduct_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            GridView view = (GridView)sender;
            if (e.Column.FieldName == gridColumnSupplierGuid.FieldName) {
                e.RepositoryItem = _supplierCombo;
            }
            else if (e.Column.FieldName == gridColumnMappingOperator.FieldName) {
                e.RepositoryItem = _operatorCombo;
            }
            else if (e.Column.FieldName == colPickup_Location_Default.FieldName) {
                string type = view.GetRowCellDisplayText(e.RowHandle, "Pickup_LocationType_Default");
                if (_locationLookups.ContainsKey(type)) {
                    RepositoryItemSearchLookUpEditDefaultPUpLoc.DataSource = _locationLookups[type];
                }
                else {
                    RepositoryItemSearchLookUpEditDefaultPUpLoc.DataSource = null;
                }
            }
            else if (e.Column.FieldName == colDropoff_Location_Default.FieldName) {
                string type = view.GetRowCellDisplayText(e.RowHandle, "Dropoff_LocationType_Default");
                if (_locationLookups.ContainsKey(type)) {
                    RepositoryItemSearchLookUpEditDefaultDropLoc.DataSource = _locationLookups[type];
                }
                else {
                    RepositoryItemSearchLookUpEditDefaultDropLoc.DataSource = null;
                }
            }
        }

        private void GridViewSupplierProduct_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            //Clear the associated time when the pickup or dropoff location changes because we want staff to be conscious
            //that time should probably change if the location changes (downside is that if the time was supposed to be the
            //same and they were not paying attention they may not remember what it was before it was cleared)
            if (e.Column == colPickup_LocationType_Default) {
                GridViewSupplierProduct.SetRowCellValue(e.RowHandle, colPickup_Location_Default, null);
                GridViewSupplierProduct.SetRowCellValue(e.RowHandle, colPickup_Time_Default, null);
            }
            else if (e.Column == colDropoff_LocationType_Default) {
                GridViewSupplierProduct.SetRowCellValue(e.RowHandle, colDropoff_Location_Default, null);
                GridViewSupplierProduct.SetRowCellValue(e.RowHandle, colDropoff_Time_Default, null);
            }
            else if (e.Column == colPickup_Location_Default) {
                GridViewSupplierProduct.SetRowCellValue(e.RowHandle, colPickup_Time_Default, null);
            }
            else if (e.Column == colDropoff_Location_Default) {
                GridViewSupplierProduct.SetRowCellValue(e.RowHandle, colDropoff_Time_Default, null);
            }
        }

        private void GridViewRoutes_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column == colBusRoute_ID) {
                GridViewRoutes.PostEditor();
                GridViewRoutes.SetFocusedRowCellValue(gridColumnFromStop, null);
                GridViewRoutes.SetFocusedRowCellValue(gridColumnToStop, null);
            }
        }

        private void GridViewRoutes_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            GridView view = (GridView)sender;
            if (e.Column.FieldName == gridColumnFromStop.FieldName || e.Column.FieldName == gridColumnToStop.FieldName) {
                var busStopsCombo = new RepositoryItemImageComboBox();
                int? routeId = view.GetRowCellValue(e.RowHandle, colBusRoute_ID) as int?;
                if (routeId != null) {
                    List<ImageComboBoxItem> lookup = new List<ImageComboBoxItem>();
                    lookup.AddRange(_context.BusRouteStop.Where(brs => brs.BusRoute_ID == routeId)
                        .OrderBy(brs => brs.Sequence).AsEnumerable()
                        .Select(brs => new ImageComboBoxItem() { Description = brs.Code, Value = brs.ID })
                        .ToList());
                    lookup.Insert(0, new ImageComboBoxItem() { Description = "", Value = null });
                    busStopsCombo.Items.AddRange(lookup);
                }
                e.RepositoryItem = busStopsCombo;
            }
        }

        private void BarButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _ignoreLeaveRow = true;       //so that when the grid row changes it doesn't try to save again
            if (SaveRecord(true)) {
                //For some reason when there is no existing record in the binding source the Add method does not
                //trigger the CurrentChanged event, but AddNew does so use that instead
                _selectedRecord = (COMP)BindingSource.AddNew();
                //With the instant feedback data source, the new row is not immediately added to the grid, so move
                //the focused row to the filter row just so that no other existing row is visually highlighted
                GridViewLookup.FocusedRowHandle = DevExpress.Data.BaseListSourceDataController.FilterRow;
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

        private void BarButtonItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SaveRecord(false))
                RefreshRecord();
        }

        private void SimpleButtonAddSupplierCategory_Click(object sender, EventArgs e) {
            SupplierCategory cat = new SupplierCategory {
                Product_Code = TextEditCode.Text ?? string.Empty,
                Product_Type = "OPT"
            };
            _selectedRecord.SupplierCategory.Add(cat);
            BindSupplierCategories();
            GridViewSupplierCategory.FocusedRowHandle = BindingSourceSupplierCategory.Count - 1;
        }

        private void SimpleButtonDelSupplierCategory_Click(object sender, EventArgs e) {
            if (GridViewSupplierCategory.FocusedRowHandle >= 0) {
                SupplierCategory cat = (SupplierCategory)GridViewSupplierCategory.GetFocusedRow();
                BindingSourceSupplierCategory.Remove(cat);
                //Removing from the bindingsource just removes the object from its parent, but does not mark
                //it for deletion, effectively orphaning it.  This will cause foreign key errors when saving.
                //To flag for deletion, delete it from the context as well.
                if (!cat.IsDetached()) {
                    _context.SupplierCategory.DeleteObject(cat);
                }
                BindSupplierCategories();
            }
        }

        private void GridViewSupplierCategory_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e) {
            if (e.Column.FieldName == colCatMappingSupplier.FieldName) {
                e.RepositoryItem = _supplierCombo;
            }
        }

        private void PopupForm_KeyUp(object sender, KeyEventArgs e) {
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

        private void ImageComboBoxEditOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SearchLookupEditOperator.Text)) {
                string val = SearchLookupEditOperator.EditValue.ToString();
                var values = (from operRec in _context.OPERATOR where operRec.CODE == val select new { operRec.AP, operRec.Due_Days }).First();
                TextEditAPNumber.Text = values.AP;
                TextEditDueDays.Text = values.Due_Days.ToString();
            }
        }

        private void GridControlTransferPoints_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateTransfers, sender);
        }

        private void GridControlSupplierProduct_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateSupplierProducts, sender);
        }

        private void GridControlSupplierCategory_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateSupplierCategories, sender);
        }

        private void CheckEditPickup_EditValueChanged(object sender, EventArgs e)
        {
            if (CheckEditPickup.Checked == true) {
                checkEditPickupInfoRequired.Enabled = true;
            } else {
                checkEditPickupInfoRequired.Checked = false;
                checkEditPickupInfoRequired.Enabled = false;
            }
            SetPupDrp();
        }

        private void CheckEditDropoff_EditValueChanged(object sender, EventArgs e)
        {
            if (CheckEditDropoff.Checked) {
                checkEditDropoffInfoRequired.Enabled = true;
            }
            else {
                checkEditDropoffInfoRequired.Checked = false;
                checkEditDropoffInfoRequired.Enabled = false;
            }
            SetPupDrp();
        }

        public void SetPupDrp()
        {
            if (CheckEditPickup.Checked && CheckEditDropoff.Checked) {
                _pupDrp = "B";
            } else if (CheckEditDropoff.Checked == true && CheckEditPickup.Checked == false) {
                _pupDrp = "D";
            } else if (CheckEditPickup.Checked == true && CheckEditDropoff.Checked == false) {
                _pupDrp = "P";
            } else {
                _pupDrp = "";
            }
        }

        private void CheckEditMultTimes_Modified(object sender, EventArgs e)
        {
            if (!CheckEditMultTimes.Checked) {
                gridColumnServiceTime.OptionsColumn.AllowEdit = false;
            }
            else {
                gridColumnServiceTime.OptionsColumn.AllowEdit = true;
            }
        }

        private void SearchLookupEditServiceType_EditValueChanged(object sender, EventArgs e)
        {
            string serviceType = SearchLookupEditServiceType.EditValue.ToStringEmptyIfNull();
            bool isHopper = _sys.Settings.HopTourServiceType.Contains(serviceType);
            xtraTabPageRoutes.PageEnabled = isHopper;
            GridViewTransferPoints.Columns["CompBusRoute_ID"].Visible = isHopper;
            _isPass = ("PASS" == serviceType);
            xtraTabPageRelatedProducts.Text = _isPass ? "Pass Products" : "Related Products";
            GridViewRelatedProducts.Columns["IsRoundTrip"].Visible = !_isPass;
            GridViewRelatedProducts.Columns["IsReturn"].Visible = !_isPass;
            GridViewRelatedProducts.Columns["Reciprocal"].Visible = !_isPass;
            GridViewRelatedProducts.Columns["ForUpSell"].Visible = !_isPass;
            GridViewRelatedProducts.Columns["ForPackaging"].Visible = !_isPass;
            GridViewRelatedProducts.Columns["ServPackType_Code"].Visible = _isPass;
            GridViewRelatedProducts.Columns["Operator_Code"].Visible = _isPass;
            if (_isPass) {
                if (RepositoryItemComboBoxType.Items.Contains("HTL")) {
                    RepositoryItemComboBoxType.Items.Remove("HTL");
                }
            }
            else {
                if (!RepositoryItemComboBoxType.Items.Contains("HTL")) {
                    RepositoryItemComboBoxType.Items.Add("HTL");
                }
            }
        }

        private void CompForm_Shown(object sender, EventArgs e)
        {
            GridViewLookup.FocusedRowHandle = DevExpress.Data.BaseListSourceDataController.FilterRow;
            GridControlLookup.Focus();
        }

        private void ImageComboBoxEditConfirmationType_EditValueChanged(object sender, EventArgs e)
        {
            int.TryParse(ImageComboBoxEditConfirmationType.EditValue.ToStringEmptyIfNull(), out int result);
            if (result == 2) {
                SpinEditOnRequestPeriod.Enabled = true;
            } else {
                SpinEditOnRequestPeriod.Enabled = false;
            }
        }

        private void CheckEditIsSupplement_EditValueChanged(object sender, EventArgs e)
        {
            GridControlSupplements.Enabled = !CheckEditIsSupplement.Checked;
            SimpleButtonAddSupplement.Enabled = !CheckEditIsSupplement.Checked;
            SimpleButtonDeleteSupplement.Enabled = !CheckEditIsSupplement.Checked;
            SetCheckBoxState(CheckEditSupplementIsBoard, CheckEditIsSupplement.Checked, false);
            SetCheckBoxState(CheckEditSupplementPaySupplier, CheckEditIsSupplement.Checked, false);
            SetCheckBoxState(CheckEditSupplementQtySelectable, CheckEditIsSupplement.Checked, false);
        }

        private void SetCheckBoxState(CheckEdit checkBox, bool enabled, bool? disabledValue)
        {
            checkBox.Enabled = enabled;
            if (disabledValue != null) {
                checkBox.Checked = (bool)disabledValue;
            }
        }

        void LoadAndBindSupplements()
        {
            //Load the related entities. DO NOT do another db query using context.whatever because they
            //will not be associated with the parent entity, and new items will not be added to the relationship
            //so foreign key errors will result. Can't load the related entities on a detached or added (but not saved)
            //entity.
            if (_selectedRecord.EntityState != EntityState.Detached) {
                _selectedRecord.ProductSupplement.Load(MergeOption.OverwriteChanges);
            }
            //Don't do any LINQ operations on the entitycollection, just bind directly to it, otherwise
            //it appears to bind as unassociated with the context and you have to manually add/delete
            //rows from the bindingsource to the context (but changes work fine)
            BindingSourceSupplements.DataSource = _selectedRecord.ProductSupplement;
            BindSupplements();
        }

        void BindSupplements()
        {
            GridControlSupplements.DataSource = BindingSourceSupplements;
            GridControlSupplements.RefreshDataSource();
        }

        private void SimpleButtonAddSupplement_Click(object sender, EventArgs e)
        {
            ProductSupplement sup = new ProductSupplement {
                Product_Code = TextEditCode.Text ?? string.Empty,
                Product_Type = "OPT"
            };
            _selectedRecord.ProductSupplement.Add(sup);
            BindSupplements();
            GridViewSupplement.FocusedRowHandle = BindingSourceSupplements.Count - 1;
        }

        private void SimpleButtonDeleteSupplement_Click(object sender, EventArgs e)
        {
            if (GridViewSupplement.FocusedRowHandle >= 0) {
                ProductSupplement sup = (ProductSupplement)GridViewSupplement.GetFocusedRow();
                BindingSourceSupplements.Remove(sup);
                //Removing from the bindingsource just removes the object from its parent, but does not mark
                //it for deletion, effectively orphaning it.  This will cause foreign key errors when saving.
                //To flag for deletion, delete it from the context as well.
                if (!sup.IsNew()) {
                    _context.ProductSupplement.DeleteObject(sup);
                }
                BindSupplements();
            }
        }

        private void GridControlSupplements_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateSupplements, sender);
        }

        void LoadAndBindRelatedProducts()
        {
            //Load the related entities. DO NOT do another db query using context.whatever because they
            //will not be associated with the parent entity, and new items will not be added to the relationship
            //so foreign key errors will result. Can't load the related entities on a detached or added (but not saved)
            //entity.
            if (_selectedRecord.EntityState != EntityState.Detached) {
                _selectedRecord.RelatedProduct1.Load(MergeOption.OverwriteChanges);
            }
            //Don't do any LINQ operations on the entitycollection, just bind directly to it, otherwise
            //it appears to bind as unassociated with the context and you have to manually add/delete
            //rows from the bindingsource to the context (but changes work fine)
            BindingSourceRelatedProduct.DataSource = _selectedRecord.RelatedProduct1;
            BindRelatedProducts();
        }

        void BindRelatedProducts()
        {
            GridControlRelatedProducts.DataSource = BindingSourceRelatedProduct;
            GridControlRelatedProducts.RefreshDataSource();
        }

        private void SimpleButtonAddRelatedProduct_Click(object sender, EventArgs e)
        {
            RelatedProduct rel = new RelatedProduct {
                Product_Code = TextEditCode.Text ?? string.Empty,
                Product_Type = "OPT",
                IsPassComponent = _isPass
            };
            _selectedRecord.RelatedProduct1.Add(rel);
            BindRelatedProducts();
            GridViewRelatedProducts.FocusedRowHandle = BindingSourceRelatedProduct.Count - 1;
        }

        private void SimpleButtonDeleteRelatedProduct_Click(object sender, EventArgs e)
        {
            if (GridViewRelatedProducts.FocusedRowHandle >= 0) {
                RelatedProduct rel = (RelatedProduct)GridViewRelatedProducts.GetFocusedRow();
                BindingSourceRelatedProduct.Remove(rel);
                //Removing from the bindingsource just removes the object from its parent, but does not mark
                //it for deletion, effectively orphaning it.  This will cause foreign key errors when saving.
                //To flag for deletion, delete it from the context as well.
                if (!rel.IsNew()) {
                    _context.RelatedProduct.DeleteObject(rel);
                }
                BindRelatedProducts();
            }
        }

        private void GridViewRelatedProducts_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            GridView view = (GridView)sender;
            if (e.RowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle) {
                if (e.Column.FieldName == colRelatedCode.FieldName) {
                    string type = view.GetRowCellDisplayText(e.RowHandle, "Type");
                    if (_passLookups.ContainsKey(type)) {
                        RepositoryItemSearchLookUpEditRelatedProductCode.DataSource = _passLookups[type];
                    }
                    else {
                        RepositoryItemSearchLookUpEditRelatedProductCode.DataSource = null;
                    }
                }
                else if (e.Column == colServPackType) {
                    string type = view.GetRowCellDisplayText(e.RowHandle, "Type");
                    if (_ServPackTypeLookups.ContainsKey(type)) {
                        RepositoryItemSearchLookUpEditServPackType.DataSource = _ServPackTypeLookups[type];
                    }
                    else {
                        RepositoryItemSearchLookUpEditServPackType.DataSource = null;
                    }
                }
            }
        }

        private void SearchLookUpEditDepCity_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateDepartureCity, sender);
        }

        private void BarButtonItemUpdateWebsite_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try {
                string reportType = string.Join(",", _sys.Settings.MainMediaReport, _sys.Settings.WarningMediaReport);
                _context.usp_RefreshSingleProduct("OPT", TextEditCode.Text, reportType, _sys.Settings.FeaturedMediaSection,
                    _sys.Settings.MainMediaReport, _sys.Settings.MainMediaSection);
                ShowActionConfirmation("Website Updated");
            }
            catch {
                ShowActionConfirmation("Update Failed");
            }
        }

        private void ImageComboBoxEditTransType_EditValueChanged(object sender, EventArgs e)
        {
            EnableTransferPointsTab(ImageComboBoxEditTransType.EditValue.ToStringEmptyIfNull());
        }

        private void EnableTransferPointsTab(string transfertype)
        {
            if (!transfertype.IsNullOrEmpty()) {
                if ("IO".Contains(transfertype)) {
                    GridControlTransferPoints.Enabled = true;
                    SimpleButtonAddTransfer.Enabled = true;
                    SimpleButtonPasteTransfers.Enabled = true;
                }
            }
            else {
                GridControlTransferPoints.Enabled = false;
                SimpleButtonAddTransfer.Enabled = false;
                SimpleButtonDeleteTransfer.Enabled = false;
                SimpleButtonCopyTransfers.Enabled = false;
                SimpleButtonPasteTransfers.Enabled = false;
            }
        }

        private void SpinEditMaxDuration_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateMaxDuration, sender);
        }

        private void RepositoryItemTimeEditDefault_EditValueChanged(object sender, EventArgs e)
        {
            TimeEdit edit = sender as TimeEdit;
            DateTime dt = (DateTime)edit.EditValue;
            dt = new DateTime(_baseDate.Year, _baseDate.Month, _baseDate.Day, dt.Hour, dt.Minute, dt.Second);
            edit.EditValue = dt;
        }

        private void SimpleButtonCopyTransfers_Click(object sender, EventArgs e)
        {
            GridControlTransferPoints.FocusedView.CopyToClipboard();
            ShowActionConfirmation("Row(s) copied");
        }

        private void GridViewTransferPoints_ClipboardRowPasting(object sender, ClipboardRowPastingEventArgs e)
        {
            GridView view = sender as GridView;
            GridColumn columnLocation = view.Columns["LOCATION"];
            GridColumn columnLocType = view.Columns["LocationType"];
            var foo = e.OriginalValues;
            if (e.Values[columnLocType].ToString() == "HTL")
                e.Values[columnLocation] = _locationLookups["HTL"].Where(x => x.DisplayName == e.Values[columnLocation].ToString()).FirstOrDefault().Code;
            else if (e.Values[columnLocType].ToString() == "WAY")
                e.Values[columnLocation] = _locationLookups["WAY"].Where(x => x.DisplayName == e.Values[columnLocation].ToString()).FirstOrDefault().Code;
            else if (e.Values[columnLocType].ToString() == "CTY")
                e.Values[columnLocation] = _locationLookups["CTY"].Where(x => x.DisplayName == e.Values[columnLocation].ToString()).FirstOrDefault().Code;
            else if (e.Values[columnLocType].ToString() == "OPT")
                e.Values[columnLocation] = _locationLookups["OPT"].Where(x => x.DisplayName == e.Values[columnLocation].ToString()).FirstOrDefault().Code;
        }

        void LoadAndBindProductTimes()
        {
            //Load the related entities. DO NOT do another db query using context.whatever because they
            //will not be associated with the parent entity, and new items will not be added to the relationship
            //so foreign key errors will result. Can't load the related entities on a detached or added (but not saved)
            //entity.
            if (_selectedRecord.EntityState != EntityState.Detached) {
                _selectedRecord.ProductTime.Load(MergeOption.OverwriteChanges);
            }
            //Don't do any LINQ operations on the entitycollection, just bind directly to it, otherwise
            //it appears to bind as unassociated with the context and you have to manually add/delete
            //rows from the bindingsource to the context (but changes work fine)
            BindingSourceProductTime.DataSource = _selectedRecord.ProductTime;
            BindProductTimes();
        }

        void BindProductTimes()
        {
            GridControlProductTime.DataSource = BindingSourceProductTime;
            GridControlProductTime.RefreshDataSource();
        }

        private void SimpleButtonAddProductTime_Click(object sender, EventArgs e)
        {
            ProductTime time = new ProductTime {
                Product_Code = TextEditCode.Text ?? string.Empty,
                Product_Type = "OPT"
            };
            _selectedRecord.ProductTime.Add(time);
            BindProductTimes();
            GridViewProductTime.FocusedRowHandle = BindingSourceProductTime.Count - 1;
        }

        private void SimpleButtonDeleteProductTime_Click(object sender, EventArgs e)
        {
            if (GridViewProductTime.FocusedRowHandle >= 0) {
                ProductTime time = (ProductTime)GridViewProductTime.GetFocusedRow();
                BindingSourceProductTime.Remove(time);
                //Removing from the bindingsource just removes the object from its parent, but does not mark
                //it for deletion, effectively orphaning it.  This will cause foreign key errors when saving.
                //To flag for deletion, delete it from the context as well.
                if (!time.IsNew()) {
                    _context.ProductTime.DeleteObject(time);
                }
                BindProductTimes();
            }
        }

        private void RepositoryItemGridLookUpEditRoomcodTime_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {
            SetItemCategoryLookup(e.DisplayValue.ToString());
            e.Handled = true;
        }

        private void RepositoryItemGridLookUpEditRoomcodTax_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {
            SetItemCategoryLookup(e.DisplayValue.ToString());
            e.Handled = true;
        }

        private void SetItemCategoryLookup(object itemCat)
        {
            string cat = itemCat.ToStringNullIfNull();

            if (string.IsNullOrEmpty(cat) || _allCats.Any(c => c.Code == cat)) {
                RepositoryItemGridLookUpEditRoomcodTime.DataSource = _allCats;
                RepositoryItemGridLookUpEditRoomcodTax.DataSource = _allCats;
            }
            else {
                //If the value of category isn't in the list, add it to the list
                //We allow non-matching categories so that API products can be booked
                //Do not set DataSource because it's already bound to the list, so just changing the list is sufficient
                //Also settings DataSource from ProcessNewValue is forbidden and throws a NullReferenceException
                var newCat = new CodeName(cat);
                _allCats.Insert(1, newCat);
            }
        }

        private void LookupEdit_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ((sender as LookUpEditBase).Properties.DataSource == null)
                e.Cancel = true;
            else
                e.Cancel = false;
        }

        private void RepositoryItemCheckedComboBoxEditDaysOfWeek_EditValueChanged(object sender, EventArgs e)
        {
            CheckedComboBoxEdit edit = sender as CheckedComboBoxEdit;
            byte value = (byte)edit.EditValue;
            ProductTime row = (ProductTime)GridViewProductTime.GetFocusedRow();
            row.DaysOfWeek = value;
        }

        private void SimpleButtonPasteTransfers_Click(object sender, EventArgs e)
        {
            GridViewTransferPoints.PasteFromClipboard();
        }

        private void GridViewSupplierCategory_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }

        void LoadAndBindProductTaxes()
        {
            //Load the related entities. DO NOT do another db query using context.whatever because they
            //will not be associated with the parent entity, and new items will not be added to the relationship
            //so foreign key errors will result. Can't load the related entities on a detached or added (but not saved)
            //entity.
            if (_selectedRecord.EntityState != EntityState.Detached) {
                _selectedRecord.ProductTax.Load(MergeOption.OverwriteChanges);
            }
            //Don't do any LINQ operations on the entitycollection, just bind directly to it, otherwise
            //it appears to bind as unassociated with the context and you have to manually add/delete
            //rows from the bindingsource to the context (but changes work fine)
            BindingSourceProductTax.DataSource = _selectedRecord.ProductTax;
            BindProductTaxes();
        }

        void BindProductTaxes()
        {
            GridControlProductTax.DataSource = BindingSourceProductTax;
            GridControlProductTax.RefreshDataSource();
        }

        private void GridControlProductTime_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateProductTime, sender);
        }

        private void GridControlProductTax_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateProductTax, sender);
        }

        private void SimpleButtonAddProductTax_Click(object sender, EventArgs e)
        {
            ProductTax tax = new ProductTax {
                Product_Code = TextEditCode.Text ?? string.Empty,
                Product_Type = "OPT"
            };
            _selectedRecord.ProductTax.Add(tax);
            BindProductTaxes();
            GridViewProductTax.FocusedRowHandle = BindingSourceProductTax.Count - 1;
        }

        private void SimpleButtonDeleteProductTax_Click(object sender, EventArgs e)
        {
            if (GridViewProductTax.FocusedRowHandle >= 0) {
                ProductTax tax = (ProductTax)GridViewProductTax.GetFocusedRow();
                BindingSourceProductTax.Remove(tax);
                //Removing from the bindingsource just removes the object from its parent, but does not mark
                //it for deletion, effectively orphaning it.  This will cause foreign key errors when saving.
                //To flag for deletion, delete it from the context as well.
                if (!tax.IsNew()) {
                    _context.ProductTax.DeleteObject(tax);
                }
                BindProductTaxes();
            }
        }
    }
}
