using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using FlexModel;
using DevExpress.XtraEditors.Controls;
using System.Linq;
using DevExpress.XtraGrid.Columns;
using System.Runtime.InteropServices;
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
using FlexEntities.Entities;
using System.Data.Entity.Core.Objects;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;



namespace TraceForms
{
    public partial class CompForm : DevExpress.XtraEditors.XtraForm
    {
        public int newRowHandle;
        public string supplierGuidNewRec = string.Empty;
        public string supplierGuidModifiedRec = string.Empty;
        public List<IComprod2> myCommRecs;
        public List<IComprod2> myCommRecsAgy;
        public List<ICommLevel> myCommLvl;
        public string currentVal;
        public bool _modified = false;
        public bool newRec = false;
        public bool temp = false;
        const string colName = "ColumnCode";
        public FlextourEntities _context;
        public string username;
        public bool newRowRec;
		public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public string keyLogger = "";
		public string hopTourServiceType;
        string _accountingURL;
        RepositoryItemImageComboBox _supplierCombo = new RepositoryItemImageComboBox();
        RepositoryItemImageComboBox _operatorCombo = new RepositoryItemImageComboBox();
        COMP _selectedRecord;
        private string _PupDrpReq;
        RepositoryItemImageComboBox _busStopsCombo = new RepositoryItemImageComboBox();

        public CompForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
            LoadLookups();
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            _context = new FlextourEntities(sys.Settings.EFConnectionString);
            username = sys.User.Name;
            hopTourServiceType = sys.Settings.HopTourServiceType;
            _accountingURL = sys.Settings.TourAccountingURL;
        }

        private void LoadLookups()
        {
			GridControlLookup.DataSource = from lookupRec in _context.LOOKUP where lookupRec.RECTYPE == "OPTCLASS" select lookupRec;
			GridColumn columnHotelInfo = gridViewUserFields.Columns.AddField("HotelValue");
            columnHotelInfo.VisibleIndex = 1;
            columnHotelInfo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            columnHotelInfo.Visible = true;
            columnHotelInfo.Caption = "Comp Value";
            ColumnLabel.Visible = true;
            Modified = false;
            newRec = false;
            newRowRec = false;
            var agy = from agyRec in _context.AGY orderby agyRec.NO ascending select new { agyRec.NO, agyRec.NAME };
            var opr = from operRec in _context.OPERATOR orderby operRec.CODE ascending select new { operRec.CODE, operRec.NAME };
            var state = from stateRec in _context.State orderby stateRec.Code ascending select new { stateRec.Code, stateRec.State1 };
            var count = from countryRec in _context.COUNTRY orderby countryRec.CODE ascending select new { countryRec.CODE, countryRec.NAME };
            var air = from airpRec in _context.Airport orderby airpRec.Code ascending select new { airpRec.Code, airpRec.Name };
            var cty = from ctyRec in _context.CITYCOD orderby ctyRec.CODE ascending select new { ctyRec.CODE, ctyRec.NAME };
            var svc = from svcRec in _context.SERVTYPE orderby svcRec.TYPE ascending select new { svcRec.TYPE, svcRec.DESCRIP };
            var lang = from langRec in _context.LANGUAGE orderby langRec.CODE ascending select new { langRec.CODE, langRec.NAME };
            var diff = from diffRec in _context.CompDifficulty orderby diffRec.Name ascending select new { diffRec.Name, diffRec.Description, diffRec.DifficultyId };
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxEditOperator.Properties.Items.Add(loadBlank);
            ImageComboBoxEditState.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCountry.Properties.Items.Add(loadBlank);
            ImageComboBoxEditAirportCode.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCity.Properties.Items.Add(loadBlank);
            ImageComboBoxEditServiceType.Properties.Items.Add(loadBlank);
            ImageComboBoxEditAgency.Properties.Items.Add(loadBlank);
            ImageComboBoxEditLanguage.Properties.Items.Add(loadBlank);
            ImageComboBoxEditDifficulty.Properties.Items.Add(loadBlank);

            foreach (var result in lang)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE + "  " + "(" + result.NAME + ")", Value = result.CODE };
                ImageComboBoxEditLanguage.Properties.Items.Add(load);
            }
            foreach (var result in diff)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.Name + "  " + "(" + result.Description + ")", Value = result.DifficultyId };
                ImageComboBoxEditDifficulty.Properties.Items.Add(load);
            }
            foreach (var result in agy)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.NO + "  " + "(" + result.NAME + ")", Value = result.NO };
                ImageComboBoxEditAgency.Properties.Items.Add(load);
            }
            foreach (var result in opr)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE + "  " + "(" + result.NAME + ")", Value = result.CODE };
                ImageComboBoxEditOperator.Properties.Items.Add(load);
            }
            foreach (var result in state)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.Code + "  " + "(" + result.State1 + ")", Value = result.Code };
                ImageComboBoxEditState.Properties.Items.Add(load);
            }
            foreach (var result in count)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE + "  " + "(" + result.NAME + ")", Value = result.CODE };
                ImageComboBoxEditCountry.Properties.Items.Add(load);
            }
            foreach (var result in air)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.Code + "  " + "(" + result.Name + ")", Value = result.Code };
                ImageComboBoxEditAirportCode.Properties.Items.Add(load);
            }
            foreach (var result in cty)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE + "  " + "(" + result.NAME + ")", Value = result.CODE };
                ImageComboBoxEditCity.Properties.Items.Add(load);
            }
            foreach (var result in svc)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.TYPE + "  " + "(" + result.DESCRIP + ")", Value = result.TYPE };
                ImageComboBoxEditServiceType.Properties.Items.Add(load);
            }

            _supplierCombo.Items.Add(loadBlank);
            _supplierCombo.Items.AddRange(_context.Supplier
                            .Where(sp => sp.ProductType == "OPT")
                            .OrderBy(o => o.Name).AsEnumerable()
                            .Select(s => new ImageComboBoxItem() { Description = s.Name, Value = s.GUID })
                            .ToList());
            gridControlSupplierProduct.RepositoryItems.Add(_supplierCombo);        //per DX recommendation to avoid memory leaks


            _operatorCombo.Items.Add(loadBlank);
            _operatorCombo.Items.AddRange(_context.OPERATOR
                            .OrderBy(o => o.NAME).AsEnumerable()
                            .Select(s => new ImageComboBoxItem() { Description = $"{s.CODE} ({s.NAME})", Value = s.CODE })
                            .ToList());
            gridControlSupplierProduct.RepositoryItems.Add(_operatorCombo);        //per DX recommendation to avoid memory leaks

            bindingSourceBusRoutes.DataSource = _context.BusRoute;
            setReadOnly(true);
            enableNavigator(false);
        }

        private bool Modified
        {
            get
            {
                return _modified;
            }
            set
            {
                _modified = value;
                if (value && CompBindingSource.Current != null) {
                    //NB: Before updating any property on the entity, any pending edits must be committed 
                    //with bindingSource.EndEdit, other when the properties are set the form bindings are
                    //automatically refreshed, which causes any pending edits to be lost. 
                    CompBindingSource.EndEdit();
                    COMP comp = (COMP)CompBindingSource.Current;
                    comp.LAST_UPD = DateTime.Now;
                    comp.UPD_INIT = username;
                }
            }
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
            TextEditCode.Properties.ReadOnly = value;
            GridViewComponents.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = !(value);
        }

        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        private void CompBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            _selectedRecord = (COMP)CompBindingSource.Current; 
            if (_selectedRecord != null)
            {
                ImageComboBoxEditAgency.Text = "";
                ButtonEditDate.Text = "";
                ImageComboBoxEditTourTime.Text = "";
                TextEditDefaultTime.Text = "";
                ComboBoxEditSource.Text = "";
                GridControlTransferPoints.DataSource = from busTabRec in _context.BUSTABLE where busTabRec.CODE == _selectedRecord.CODE select busTabRec;
                if (!String.IsNullOrEmpty(_selectedRecord.CODE)) { //new record
                    _selectedRecord.CompBusRoute.Load(MergeOption.OverwriteChanges);
                    _selectedRecord.SupplierProduct.Load(MergeOption.OverwriteChanges);
                }
                bindingSourceCompBusRoutes.DataSource = _selectedRecord.CompBusRoute;
                bindingSourceSupplierProduct.DataSource = _selectedRecord.SupplierProduct;
				GridControlDetail.DataSource = from c in _context.DETAIL where c.LINK_VALUE.TrimEnd() == _selectedRecord.CODE.TrimEnd() select c;

				GridControlUserfields.DataSource = from userRec in _context.USERFIELDS
                                                   where userRec.LINK_TABLE.Equals("COMP")
                                                   select userRec;

                UpdateCommMarkupGrid("TARIFF", null, "ALL");

                if (_selectedRecord.Multiple_Times == "1")
                {
                    TextEditDefaultTime.Enabled = true;
                    ImageComboBoxEditTourTime.Enabled = false;
                    TextEditDefaultTime.Text = _selectedRecord.Default_Time;
                }
                else
                {
                    TextEditDefaultTime.Enabled = false;
                    ImageComboBoxEditTourTime.Enabled = true;
                    ImageComboBoxEditTourTime.EditValue = _selectedRecord.Default_Time;
                }
				xtraTabPageRoutes.PageEnabled = (_selectedRecord.SERV_TYPE == hopTourServiceType);
				gridViewTransferPoints.Columns["CompBusRoute_ID"].Visible = (_selectedRecord.SERV_TYPE == hopTourServiceType);
                _PupDrpReq = _selectedRecord.PUDRP_REQ;
                SetPupDrpCheckboxes();
                Modified = false;
            }
            if (CompBindingSource.Current != null)
                    enableNavigator(true);
                else
                    enableNavigator(false);
        }

        private bool checkForms()
        {           
            if (!_modified && !newRec)
                return true;
            if (!CheckMappings()) return false;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((COMP)CompBindingSource.Current).checkMain, CompBindingSource);
            bool validateLocation = validCheck.checkAll(PanelControlLocationTab.Controls, errorProvider1, ((COMP)CompBindingSource.Current).checkLocationTab, CompBindingSource);
            bool validateAccount = validCheck.checkAll(PanelControlAccountTab.Controls, errorProvider1, ((COMP)CompBindingSource.Current).checkAccountTab, CompBindingSource);
            bool validatePolicies = validCheck.checkAll(PanelControlPoliciesTab.Controls, errorProvider1, ((COMP)CompBindingSource.Current).checkPoliciesTab, CompBindingSource);
            bool validateServices = validCheck.checkAll(PanelControlServicesTab.Controls, errorProvider1, ((COMP)CompBindingSource.Current).checkServicesTab, CompBindingSource);
            if (validateMain && validateLocation && validateAccount && validatePolicies && validateServices) {
                var ret = validCheck.saveRec(ref _modified, true, ref newRec, _context, CompBindingSource, Name, errorProvider1, Cursor);
                if (ret) {
                    AccountingAPI.InvokeForProduct(_accountingURL, "OPT", ((COMP)CompBindingSource.Current).CODE);
                }
                return ret;
            }
            else
            {
                validCheck.saveRec(ref _modified, false, ref newRec, _context, CompBindingSource, Name, errorProvider1, Cursor);
                return false; 
            }
        }

        private bool CheckMappings()
        {
            for (int row = 0; row < gridViewSupplierProduct.RowCount; row++) {
                SupplierProduct product = (SupplierProduct)gridViewSupplierProduct.GetRow(row);
                product.Product_Code_Internal = TextEditCode.Text;
                product.Product_Type = "OPT";

                if (product.Supplier_GUID == null) {
                    MessageBox.Show("Please select a Supplier from the dropdown for the new Supplier Mapping record.");
                    return false;
                }
                if (string.IsNullOrEmpty(product.ProductCodeSupplier)) {
                    MessageBox.Show("Please enter a Supplier Product Code for the new Supplier Mapping record.");
                    return false;
                }
            }
            return true;
        }

        private void setCheckEdits()
        {
            GridViewComponents.SetFocusedRowCellValue("Transfer_List", "N");
            GridViewComponents.SetFocusedRowCellValue("Require_ArvInfo", "N");
            GridViewComponents.SetFocusedRowCellValue("Allow_Freesell", 0);
            GridViewComponents.SetFocusedRowCellValue("Require_DepInfo", "N");
            GridViewComponents.SetFocusedRowCellValue("Inactive", "N");
            GridViewComponents.SetFocusedRowCellValue("USE_CLIENT_LOGO", "N");
            GridViewComponents.SetFocusedRowCellValue("SVC_LIST", "N");
            GridViewComponents.SetFocusedRowCellValue("Multiple_Times", 0);
            GridViewComponents.SetFocusedRowCellValue("LATITUDE", 0);
            GridViewComponents.SetFocusedRowCellValue("LONGITUDE", 0);
            GridViewComponents.SetFocusedRowCellValue("AP", string.Empty);
            GridViewComponents.SetFocusedRowCellValue("AR", string.Empty);
            GridViewComponents.SetFocusedRowCellValue("CITY", string.Empty);
            GridViewComponents.SetFocusedRowCellValue("OPER", string.Empty);
            GridViewComponents.SetFocusedRowCellValue("INCL1", string.Empty);
            GridViewComponents.SetFocusedRowCellValue("INCL2", string.Empty);
            GridViewComponents.SetFocusedRowCellValue("INCL3", string.Empty);
            GridViewComponents.SetFocusedRowCellValue("INCL4", string.Empty);
            GridViewComponents.SetFocusedRowCellValue("INCL5", string.Empty);
            GridViewComponents.SetFocusedRowCellValue("INCL6", string.Empty);
            GridViewComponents.SetFocusedRowCellValue("TRSFR_TYP", string.Empty);
            GridViewComponents.SetFocusedRowCellValue("PUDRP_REQ", string.Empty);
            GridViewComponents.SetFocusedRowCellValue("SERV_TYPE", string.Empty);
            GridViewComponents.SetFocusedRowCellValue("VOUCH_DAYS_PRIOR", 0);
            GridViewComponents.SetFocusedRowCellValue("USER_DEC1", 0);
            GridViewComponents.SetFocusedRowCellValue("USER_DEC2", 0);
            GridViewComponents.SetFocusedRowCellValue("USER_INT1", 0);
            GridViewComponents.SetFocusedRowCellValue("USER_INT2", 0);
            GridViewComponents.SetFocusedRowCellValue("USER_TXT1", string.Empty);
            GridViewComponents.SetFocusedRowCellValue("USER_TXT2", string.Empty);
            GridViewComponents.SetFocusedRowCellValue("USER_TXT3", string.Empty);
            GridViewComponents.SetFocusedRowCellValue("USER_TXT4", string.Empty);
            GridViewComponents.SetFocusedRowCellValue("STATE", string.Empty);
            GridViewComponents.SetFocusedRowCellValue("ZIP", string.Empty);
            GridViewComponents.SetFocusedRowCellValue("TOWN", string.Empty);
            GridViewComponents.SetFocusedRowCellValue("GMACCTNO", string.Empty);
            GridViewComponents.SetFocusedRowCellValue("ADDR1", string.Empty);
            GridViewComponents.SetFocusedRowCellValue("ADDR2", string.Empty);
            GridViewComponents.SetFocusedRowCellValue("ADDR3", string.Empty);
            GridViewComponents.SetFocusedRowCellValue("COUNTRY", string.Empty);
            GridViewComponents.SetFocusedRowCellValue("AIRPORT", string.Empty);
            GridViewComponents.SetFocusedRowCellValue("Default_Time", string.Empty);
            GridViewComponents.SetFocusedRowCellValue("Vendor_Code", string.Empty);
            GridViewComponents.SetFocusedRowCellValue("Language_Code", string.Empty);
            GridViewComponents.SetFocusedRowCellValue("Difficulty", 0);
            GridViewComponents.SetFocusedRowCellValue("MealsIncluded", 0);
            GridViewComponents.SetFocusedRowCellValue("Duration", string.Empty);
            GridViewComponents.SetFocusedRowCellValue("PickupInfoRequired", 0);
            GridViewComponents.SetFocusedRowCellValue("DropoffInfoRequired", 0);
            GridViewComponents.SetFocusedRowCellValue("WeightRequired", 0);
            GridViewComponents.SetFocusedRowCellValue("AccountingServiceItem", 1);
            GridViewComponents.SetFocusedRowCellValue("VendorPrepayReqd", 0);
            checkEditPickupInfoRequired.Enabled = false;
            checkEditDropoffInfoRequired.Enabled = false;
            checkEditPickupInfoRequired.Checked = false;
            checkEditDropoffInfoRequired.Checked = false;
            CheckEditPickup.Checked = false;
            CheckEditDropoff.Checked = false;
            checkEditAccountingServiceItem.Checked = true;
            checkEditPassengerWeightRequired.Checked = false;
            checkEditVendorPrepayReqd.Checked = false;
            if (CompBindingSource.Current != null) {
                var comp = (COMP)CompBindingSource.Current;
                comp.AccountingServiceItem = true;
                comp.VendorPrepayReqd = false;
                comp.PickupInfoRequired = false;
                comp.DropoffInfoRequired = false;
                comp.WeightRequired = false;
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            GridViewComponents.ClearColumnsFilter();
            if (CompBindingSource.Current == null)
            {
                //fake query in order to create a link between the database table and the binding source
                CompBindingSource.DataSource = from opt in _context.COMP where opt.CODE == "KJM9" select opt;
                CompBindingSource.AddNew();
                if (GridViewComponents.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewComponents.FocusedRowHandle = GridViewComponents.RowCount - 1;
                TextEditCode.Focus();
                setReadOnly(false);
                newRec = true;
                _PupDrpReq = "";
                setCheckEdits();
                return;
            }
            TextEditCode.Focus();
            //bindingNavigatorPositionItem.Focus(); 
            GridViewComponents.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                errorProvider1.Clear();
                if (!temp)
                    _context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (COMP)CompBindingSource.Current);
                CompBindingSource.AddNew();
                if (GridViewComponents.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewComponents.FocusedRowHandle = GridViewComponents.RowCount - 1;
                TextEditCode.Focus();
                setReadOnly(false);
                newRec = true;
                _PupDrpReq = "";
                setCheckEdits();
            }           
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (CompBindingSource.Current == null)
                return;
            GridViewComponents.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Modified = false;
                newRec = false;
                CompBindingSource.RemoveCurrent();
                errorProvider1.Clear();
                _context.SaveChanges();
                setReadOnly(true);
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);
            }
            TextEditCode.Focus();
            currentVal = TextEditCode.Text;
            Modified = false;
            newRec = false;
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }

        private void CompBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {           
            if (CompBindingSource.Current == null)
                return;

            CompBindingSource.EndEdit();

            GridViewComponents.CloseEditor();
            gridViewTransferPoints.FocusedColumn = gridViewTransferPoints.Columns["TYPE"];
            if (gridViewTransferPoints.UpdateCurrentRow())
            {
                BusTableBindingSource.EndEdit();
                foreach (BUSTABLE busRec in BusTableBindingSource.List) {
                    if (ImageComboBoxEditTransType.Text == "Outbound") {
                        busRec.In_Out = "O";
                    }
                    else {
                        busRec.In_Out = "I";
                    }
                }
            }

            gridViewSupplierProduct.CloseEditor();
            if (gridViewSupplierProduct.UpdateCurrentRow()) {
                bindingSourceSupplierProduct.EndEdit();
            }

            gridViewRoutes.CloseEditor();
			gridViewRoutes.FocusedColumn = gridViewRoutes.Columns["BusRoute_ID"];
			if (gridViewRoutes.UpdateCurrentRow()) {
				bindingSourceCompBusRoutes.EndEdit();
			}

            ((COMP)CompBindingSource.Current).PUDRP_REQ = _PupDrpReq;

             TextEditCode.Focus();
             bool temp = newRec;
           // bindingNavigatorPositionItem.Focus();//trigger field leave event
            if (checkForms())
            {
                errorProvider1.Clear();
                setReadOnly(true);
                Modified = false;
                newRec = false;
                newRowRec = false;
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
            }
            if(!temp && !_modified)
                _context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (COMP)CompBindingSource.Current);
             
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool move()
        {
            GridViewComponents.CloseEditor();
            TextEditCode.Focus();
            temp = newRec;
            if (checkForms())
            {
                errorProvider1.Clear();
                if (!temp)
                    _context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (COMP)CompBindingSource.Current);
                setReadOnly(true);
                newRec = false;
                Modified = false;
                return true;
            }
            return false;
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (newRowRec == true)
            {
                MessageBox.Show("Please save or delete the new record being added in the Transfer Points grid before attempting to navigate to another record.");
                return;
            }
            if (move())
                CompBindingSource.MoveFirst();
            currentVal = TextEditCode.Text;
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (newRowRec == true)
            {
                MessageBox.Show("Please save or delete the new record being added in the Transfer Points grid before attempting to navigate to another record.");
                return;
            }
            if (move())
                CompBindingSource.MovePrevious();
            currentVal = TextEditCode.Text;
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (newRowRec == true)
            {
                MessageBox.Show("Please save or delete the new record being added in the Transfer Points grid before attempting to navigate to another record.");
                return;
            }
            if (move())
                CompBindingSource.MoveNext();
            currentVal = TextEditCode.Text;
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (newRowRec == true)
            {
                MessageBox.Show("Please save or delete the new record being added in the Transfer Points grid before attempting to navigate to another record.");
                return;
            }
            if (move())
                CompBindingSource.MoveLast();
            currentVal = TextEditCode.Text;
        }

        private void gridViewComponents_BeforeLeaveRow(object sender, RowAllowEventArgs e)
        {
            if (newRowRec == true)
            {
                e.Allow = false;
                MessageBox.Show("Please save or delete the new record being added in the Transfer Points grid before attempting to navigate to another record.");
                return;
            }
            if (CompBindingSource.Current == null)
            {
                e.Allow = true;
                return;
            }
            temp = newRec;
            bool temp2 = _modified;
            if (checkForms())
            {
                errorProvider1.Clear();
                e.Allow = true;
                if ((!temp) && temp2)
                    _context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (COMP)CompBindingSource.Current);
                setReadOnly(true);
            }
            else
            {
                if ((!temp) && !_modified)
                    _context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (COMP)CompBindingSource.Current);
              
                e.Allow = false;

            }
        }

        private void gridViewComponents_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            if (!GridViewComponents.IsFilterRow(e.RowHandle))
            {
                Modified = true;
            }          
        }

        private void gridViewComponentss_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box       
        }

        private void ButtonAddressMap_Click(object sender, EventArgs e)
        {
            Uri mapUri = new Uri(new Uri("http://www.bing.com/"), "maps/default.aspx?where1=" + TextEditAddr1.Text + "%20" + TextEditAddr2.Text + "%20" + TextEditAddr3.Text + ",%20" + TextEditTown.Text + ",%20" + ImageComboBoxEditState.EditValue + ",%20" + ImageComboBoxEditCountry.EditValue + "&v=2");
            Form map = new TraceForms.WebBrowser(mapUri) { MdiParent = this.ParentForm };
            map.Show();
        }

        private void ButtonGeocodeMap_Click(object sender, EventArgs e)
        {
            Uri mapUri = new Uri(new Uri("http://www.bing.com/"), "maps/default.aspx?where1=" + TextEditLattitude.Text + ",%20" + TextEditLongitude.Text + "&v=2");
            Form map = new TraceForms.WebBrowser(mapUri) { MdiParent = this.ParentForm };
            map.Show();
        }

        private void ImageComboBoxEditTransType_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMP)CompBindingSource.Current).checkTransfer, CompBindingSource);
            }
        }

        private void SpinEditDayPrior_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMP)CompBindingSource.Current).checkVouch, CompBindingSource);
            }
        }

        private void TextEditIncl1_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMP)CompBindingSource.Current).checkIncl1, CompBindingSource);
            }
        }

        private void TextEditIncl2_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMP)CompBindingSource.Current).checkIncl2, CompBindingSource);
            }
        }

        private void TextEditIncl3_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMP)CompBindingSource.Current).checkIncl3, CompBindingSource);
            }
        }

        private void TextEditIncl4_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMP)CompBindingSource.Current).checkIncl4, CompBindingSource);
            }
        }

        private void TextEditIncl5_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMP)CompBindingSource.Current).checkIncl5, CompBindingSource);
            }
        }

        private void TextEditIncl6_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMP)CompBindingSource.Current).checkIncl6, CompBindingSource);
            }
        }

        private void TextEditAPNumber_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMP)CompBindingSource.Current).checkAp, CompBindingSource);
            }
        }

        private void TextEditARNumber_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMP)CompBindingSource.Current).checkAr, CompBindingSource);
            }
        }

        private void TextEditDueDays_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
            }
        }

        private void TextEditLatitude_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMP)CompBindingSource.Current).checkLatitude, CompBindingSource);
            }
        }

        private void TextEditLongitude_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMP)CompBindingSource.Current).checkLongitude, CompBindingSource);
            }
        }

        private void ImageComboBoxEditRestrictionsCode_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMP)CompBindingSource.Current).checkRest, CompBindingSource);
            }
        }

        private void ImageComboBoxEditRateBasis_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMP)CompBindingSource.Current).checkRate, CompBindingSource);
            }
        }

        private void ButtonAddRow_Click(object sender, EventArgs e)
        {
            if (newRowRec == false)
            {
                if (gridViewTransferPoints.RowCount != 0)
                {
                    gridViewTransferPoints.MoveLast();
                }
                gridViewTransferPoints.AddNewRow();
                gridViewTransferPoints.SetFocusedRowCellValue("CODE", TextEditCode.Text);
                gridViewTransferPoints.SetFocusedRowCellValue("TYPE", "OPT");
                gridViewTransferPoints.SetFocusedRowCellValue("LAST_UPD", DateTime.Today);
                gridViewTransferPoints.SetFocusedRowCellValue("UPD_INIT", username);
                gridViewTransferPoints.SetFocusedRowCellValue("Exclusion", 0);
                gridViewTransferPoints.SetFocusedRowCellValue("TIME", "");
                gridViewTransferPoints.SetFocusedRowCellValue("EndTime", "");
                if (_PupDrpReq != "B")
                    gridViewTransferPoints.SetFocusedRowCellValue("PUP_DRP", _PupDrpReq);
                //We currently don't do roundtrip transfers, so the direction can be set 
                //based on the transfer type (Meet & Greet = Inbound)
                //Be careful because the fieldnames are case sensitive but they won't give you any error
                //if the fieldname isn't found, they just silently fail
                if (ImageComboBoxEditTransType.Text == "Outbound") {
                    gridViewTransferPoints.SetFocusedRowCellValue("In_Out", "O");
                }
                else {
                    gridViewTransferPoints.SetFocusedRowCellValue("In_Out", "I");
                }
                newRowRec = true;
                gridViewTransferPoints.AddNewRow();
            }
            else
                MessageBox.Show("Please save current record before attempting to add another.");            
        }

        private void repositoryItemButtonEditDate_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void gridViewTransferPoints_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "DATE" || e.Column.FieldName == "EndDate" && !string.IsNullOrWhiteSpace(e.DisplayText))
                e.DisplayText = validCheck.convertDate(e.DisplayText); 
        }

        private void delRow_Click(object sender, EventArgs e)
        {
            int handle = gridViewTransferPoints.FocusedRowHandle;
            gridViewTransferPoints.DeleteRow(handle);
            CompBindingSource.EndEdit();
            _context.SaveChanges();
            newRowRec = false;
            Modified = false;
        }

        private void TextEditVenderCode_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMP)CompBindingSource.Current).checkVendorCode, CompBindingSource);
            }
        }

        private void ButtonSaveChanges_Click(object sender, EventArgs e)
        {
                gridViewTransferPoints.FocusedColumn = gridViewTransferPoints.Columns["TYPE"];
                if (gridViewTransferPoints.UpdateCurrentRow())
                {
                    BusTableBindingSource.EndEdit();
                    CompBindingNavigatorSaveItem_Click(sender, e);                 
                    newRowRec = false;
                    Modified = false;
                }         
        }

        private void gridViewUserFields_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "HotelValue" && e.IsGetData)
            {
                string desc = gridViewUserFields.GetRowCellValue(e.ListSourceRowIndex, "LINK_COLUMN").ToString();
                desc = desc.Trim();
                e.Value = GridViewComponents.GetRowCellValue(CompBindingSource.IndexOf(CompBindingSource.Current), desc);
             }

            if (e.Column.FieldName == "HotelValue" && e.IsSetData)
            {
                string desc = gridViewUserFields.GetRowCellValue(e.ListSourceRowIndex, "LINK_COLUMN").ToString();
                desc = desc.Trim();
                GridViewComponents.SetRowCellValue(CompBindingSource.IndexOf(CompBindingSource.Current), desc, e.Value);
                Modified = true;
            }
        }

        private void SetPupDrpCheckboxes()
        {
            if (_PupDrpReq == "B")
            {
                CheckEditPickup.Checked = true;
                CheckEditDropoff.Checked = true;
            }
            if (_PupDrpReq == "P")
            {
                CheckEditPickup.Checked = true;
                CheckEditDropoff.Checked = false;
            }
            if (_PupDrpReq == "D")
            {
                CheckEditPickup.Checked = false;
                CheckEditDropoff.Checked = true;
            }
            if (string.IsNullOrWhiteSpace(_PupDrpReq))
            {
                CheckEditPickup.Checked = false;
                CheckEditDropoff.Checked = false;                
            }
        }    

        private void CheckEdit_Modified(object sender, EventArgs e)
        {
            Modified = true;
        }

        private void CheckEditPup_CheckStateChanged(object sender, EventArgs e)
        {
            Modified = true;
            if (CheckEditPickup.Checked && CheckEditDropoff.Checked)
                _PupDrpReq = "B";
            if (!CheckEditPickup.Checked && CheckEditDropoff.Checked)
                _PupDrpReq = "D";
            if (CheckEditPickup.Checked && !CheckEditDropoff.Checked)
                _PupDrpReq = "P";
            if (!CheckEditPickup.Checked && !CheckEditDropoff.Checked)
                _PupDrpReq = "";
            if (!CheckEditPickup.Checked) {
                checkEditPickupInfoRequired.Checked = false;
            }
            checkEditPickupInfoRequired.Enabled = CheckEditPickup.Checked;
            if (!CheckEditDropoff.Checked) {
                checkEditDropoffInfoRequired.Checked = false;
            }
            checkEditDropoffInfoRequired.Enabled = CheckEditDropoff.Checked;
        }

        private void gridViewTransferPoints_ValidateRow(object sender, ValidateRowEventArgs e)
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

			DateTime startDate, endDate ;
			if (DateTime.TryParse(strDate, out startDate) && DateTime.TryParse(strEndDate, out endDate)) {
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
            
            string agency = string.Empty;
            string source = string.Empty;
            if (string.IsNullOrWhiteSpace(ImageComboBoxEditAgency.Text))
                agency = "TARIFF";
            else
                agency = ImageComboBoxEditAgency.Text;

            if (string.IsNullOrWhiteSpace(ComboBoxEditSource.Text))
                source = "ALL";
            else
                source = ComboBoxEditSource.Text;



            UpdateCommMarkupGrid(agency, date, source);
        }

        private void ButtonEditDate_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ButtonEditDate.Text))
                ButtonEditDate.Text = validCheck.convertDate(ButtonEditDate.Text);
        }

        private void ImageComboBoxEditTourTime_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (!string.IsNullOrWhiteSpace(ImageComboBoxEditTourTime.Text))
                {
                    if (default_TimeTextEdit.Text != ImageComboBoxEditTourTime.EditValue.ToString())
                    {
                        default_TimeTextEdit.Text = ImageComboBoxEditTourTime.EditValue.ToString();
                        Modified = true;
                    }
                }
                else
                {
                    default_TimeTextEdit.Text = ImageComboBoxEditTourTime.Text;
                    if (currentVal != ((Control)sender).Text)
                    {
                        Modified = true;
                    }
                }
            }
        }

        private void TextEditDefaultTime_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (!string.IsNullOrWhiteSpace(TextEditDefaultTime.Text))
                {
                    if (!validCheck.IsNumeric(TextEditDefaultTime.Text) || TextEditDefaultTime.Text.Length != 4 || Convert.ToInt32(TextEditDefaultTime.Text) > 2359 || Convert.ToInt32(TextEditDefaultTime.Text) < 0)
                    {
                        MessageBox.Show("Departure time must be numeric and between 0000 and 2359, please correct value.");
                        TextEditDefaultTime.Focus();
                        return;
                    }
                    else
                    {
                        if (default_TimeTextEdit.Text != TextEditDefaultTime.Text)
                        {
                            default_TimeTextEdit.Text = TextEditDefaultTime.Text;
                            Modified = true;
                        }
                    }
                }
                else
                {
                    default_TimeTextEdit.Text = TextEditDefaultTime.Text;
                    if (currentVal != ((Control)sender).Text)
                    {
                        Modified = true;
                    }
                }
            }
        }

        private void gridViewTransferPoints_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {  
            if (e.Column.FieldName == "LocationType")
            {               
                gridViewTransferPoints.SetFocusedRowCellValue("LOCATION", "");
                gridViewTransferPoints.SetFocusedRowCellValue("CarOffice", "");
            }
            Modified = true;
        }

        private void gridViewTransferPoints_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void gridViewTransferPoints_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            ColumnView view = sender as ColumnView;        
            e.ExceptionMode = ExceptionMode.NoAction;   
            if ("DATE,EndDate".Contains(view.FocusedColumn.FieldName) && !string.IsNullOrWhiteSpace(e.Value.ToString()))
                gridViewTransferPoints.SetFocusedValue(validCheck.convertDate(e.Value.ToString()));            
        }

        private void ButtonEditDate_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void gridViewTransferPoints_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {           
            string name = "";
            RepositoryItemImageComboBox editor = new RepositoryItemImageComboBox();
            GridColumn col = gridViewTransferPoints.Columns["CarOffice"];
            if (e.Column.FieldName == "LOCATION")
            {
                name = gridViewTransferPoints.GetRowCellDisplayText(e.RowHandle, "LocationType");
                ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
                editor.Items.Add(loadBlank);
                switch (name)
                {
                    case "BUS":
                        var bus = from busRec in _context.BusStation orderby busRec.Code ascending select new { busRec.Code, busRec.Name };
                        col.OptionsColumn.AllowFocus = false;    
                        foreach (var result in bus)
                        {
                            ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.Code + "  " + "(" + result.Name + ")", Value = result.Code };                            
                            editor.Items.Add(load);
                        }
                        break;
                    case "CAR":
                        var car = from carRec in _context.CARINFO orderby carRec.CODE ascending select new { carRec.CODE, carRec.NAME };
                        col.OptionsColumn.AllowFocus = true;    
                        foreach (var result in car)
                        {
                            ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE + "  " + "(" + result.NAME + ")", Value = result.CODE };
                            editor.Items.Add(load);
                        }
                        break;
                    case "CRU":
                        var cru = from cruRec in _context.SeaPort orderby cruRec.Code ascending select new { cruRec.Code, cruRec.Name };
                        col.OptionsColumn.AllowFocus = false;    
                        foreach (var result in cru)
                        {
                            ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.Code + "  " + "(" + result.Name + ")", Value = result.Code };
                            editor.Items.Add(load);
                        }
                        break;
                    case "CTY":
                        var cty = from ctyRec in _context.CITYCOD orderby ctyRec.CODE ascending select new { ctyRec.CODE, ctyRec.NAME };
                        col.OptionsColumn.AllowFocus = false;    
                        foreach (var result in cty)
                        {
                            ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE + "  " + "(" + result.NAME + ")", Value = result.CODE };
                            editor.Items.Add(load);
                        }
                        break;
                    case "HTL":
                        var htl = from htlRec in _context.HOTEL orderby htlRec.CODE ascending select new { htlRec.CODE, htlRec.NAME };
                        col.OptionsColumn.AllowFocus = false;    
                        foreach (var result in htl)
                        {
                            ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE + "  " + "(" + result.NAME + ")", Value = result.CODE };
                            editor.Items.Add(load);
                        }
                        break;
                    case "TRN":
                        var trn = from trnRec in _context.TrainStation orderby trnRec.Code ascending select new { trnRec.Code, trnRec.Name };
                        col.OptionsColumn.AllowFocus = false;    
                        foreach (var result in trn)
                        {
                            ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.Code + "  " + "(" + result.Name + ")", Value = result.Code };
                            editor.Items.Add(load);
                        }
                        break;
                    case "WAY":
                        var way = from wayRec in _context.WAYPOINT orderby wayRec.CODE ascending select new { wayRec.CODE, wayRec.DESC };
                        col.OptionsColumn.AllowFocus = false;    
                        foreach (var result in way)
                        {
                            ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE + "  " + "(" + result.DESC + ")", Value = result.CODE };
                            editor.Items.Add(load);
                        }
                        break;
                    case "AIR":
                        var air = from airRec in _context.Airport orderby airRec.Code ascending select new { airRec.Code, airRec.Name };
                        col.OptionsColumn.AllowFocus = false;    
                        foreach (var result in air)
                        {
                            ImageComboBoxItem load = new ImageComboBoxItem() { Description = String.Format("{0}  ({1})", result.Code, result.Name), Value = result.Code };
                            editor.Items.Add(load);
                        }
                        break;
                    default:
                        col.OptionsColumn.AllowFocus = false; 
                        break;
                }
                e.RepositoryItem = editor;
            }
            if (e.Column.FieldName == "CarOffice")
            {
                col.OptionsColumn.AllowFocus = true;    
                ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
                editor.Items.Add(loadBlank);
                string location = (string)gridViewTransferPoints.GetRowCellValue(e.RowHandle, "LOCATION");
                var values = from carOffRec in _context.CAROFF where carOffRec.CODE == location orderby carOffRec.OFF ascending select new { carOffRec.OFF, carOffRec.NAME };
                foreach (var result in values)
                {
                    ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.OFF + "  " + "(" + result.NAME + ")", Value = result.OFF };
                    editor.Items.Add(load);
                }
                e.RepositoryItem = editor;
            }
			if (e.Column.FieldName == "CompBusRoute_ID") {
				ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
				editor.Items.Add(loadBlank);
				var values = from routeRec in _context.CompBusRoute where routeRec.Comp_Code == TextEditCode.Text 
							 select new { routeRec.ID, routeRec.BusRoute.Name };
				foreach (var result in values) {
					ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.Name, Value = result.ID };
					editor.Items.Add(load);
				}
				e.RepositoryItem = editor;
			}
        }

        private void TextEditCode_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMP)CompBindingSource.Current).checkCode, CompBindingSource);
                TextEditCode.Text = TextEditCode.Text.ToUpper();
            }
        }

        private void ImageComboBoxEditOperator_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMP)CompBindingSource.Current).checkOperator, CompBindingSource);
            }
            if (!string.IsNullOrWhiteSpace(ImageComboBoxEditOperator.Text))
            {
                string val = ImageComboBoxEditOperator.EditValue.ToString();
                var values = (from operRec in _context.OPERATOR where operRec.CODE == val select new { operRec.AP, operRec.Due_Days }).First();
                TextEditAPNumber.Text = values.AP;
                TextEditDueDays.Text = values.Due_Days.ToString();
            }
        }

        private void ImageComboBoxEditState_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMP)CompBindingSource.Current).checkState, CompBindingSource);
            }
        }

        private void ImageComboBoxEditCountry_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMP)CompBindingSource.Current).checkCountry, CompBindingSource);
            }
        }

        private void ImageComboBoxEditAirportCode_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMP)CompBindingSource.Current).checkAirport, CompBindingSource);
            }
        }

        private void ImageComboBoxEditCity_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMP)CompBindingSource.Current).checkCity, CompBindingSource);
            }
        }

        private void ImageComboBoxEditServiceType_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMP)CompBindingSource.Current).checkServType, CompBindingSource);
            }
        }

        private void gridViewTransferPoints_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            string name = gridViewTransferPoints.GetRowCellDisplayText(e.FocusedRowHandle, "LocationType");
            GridColumn col = gridViewTransferPoints.Columns["CarOffice"];
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

        private void gridViewCommissions_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if ((e.Column.FieldName == "ResStartDate" || e.Column.FieldName == "ResEndDate" || e.Column.FieldName == "SvcStartDate" || e.Column.FieldName == "SvcEndDate") && !string.IsNullOrWhiteSpace(e.DisplayText))
                e.DisplayText = validCheck.convertDate(e.DisplayText);                        
        }

        private void gridViewMarkups_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if ((e.Column.FieldName == "ResStartDate" || e.Column.FieldName == "ResEndDate" || e.Column.FieldName == "SvcStartDate" || e.Column.FieldName == "SvcEndDate") && !string.IsNullOrWhiteSpace(e.DisplayText))
                e.DisplayText = validCheck.convertDate(e.DisplayText);                      
        }

        private void UpdateCommMarkupGrid(string Agency, DateTime? TheDate, string Source)
        {
            if (TheDate != null)
            {
                myCommRecs = (from rec in _context.COMPROD2
                              where (rec.TYPE == "OPT") && (rec.Inactive == false) && ((rec.START_DATE <= TheDate) && (rec.END_DATE >= TheDate))
                              select rec).ToList<IComprod2>();
                myCommRecsAgy = (from rec in _context.COMPROD2
                                 where (rec.TYPE == "AGY") && (rec.Inactive == false) && ((rec.START_DATE <= TheDate) && (rec.END_DATE >= TheDate))
                                 select rec).ToList<IComprod2>();

               
            }
            else
            {
                myCommRecs = (from rec in _context.COMPROD2
                              where (rec.TYPE == "OPT") && (rec.Inactive == false)
                              select rec).ToList<IComprod2>();
                myCommRecsAgy = (from rec in _context.COMPROD2
                                 where (rec.TYPE == "AGY") && (rec.Inactive == false)
                                 select rec).ToList<IComprod2>();
            }
            myCommLvl = (from rec in _context.CommLevel select rec).ToList<ICommLevel>();

            foreach (COMPROD2 rec in myCommRecs)
            {

                rec.SetProductRulePosition(myCommLvl);
            }
            foreach (COMPROD2 rec in myCommRecsAgy)
            {
                rec.SetProductRulePosition(myCommLvl);
            }

           
            using (FlextourEntities context2 = new FlextourEntities(Connection.EFConnectionString))
            {
                IList<FlexCommissions.Commission> commQueryGetProduct = new List<FlexCommissions.Commission>();
                IList<FlexCommissions.Commission> commQueryyGetAgency = new List<FlexCommissions.Commission>();
                commQueryGetProduct = FlexCommissions.Commissions.GetProductCommissions(context2, "C", TextEditCode.Text.TrimEnd(), "OPT", myCommRecs, myCommLvl, null, TheDate, null, null, Agency, Source);
                commQueryyGetAgency = FlexCommissions.Commissions.GetAgencyCommissions(context2, "C", myCommRecsAgy, myCommLvl, Agency, TheDate, null, null, Source);
                IList<FlexCommissions.Commission> mergedList = (commQueryGetProduct.Union(commQueryyGetAgency)).ToList();
                GridControlCommissions.DataSource = mergedList;
                commQueryGetProduct = FlexCommissions.Commissions.GetProductCommissions(context2, "M", TextEditCode.Text.TrimEnd(), "OPT", myCommRecs, myCommLvl, null, TheDate, null, null, Agency, Source);
                commQueryyGetAgency = FlexCommissions.Commissions.GetAgencyCommissions(context2, "M", myCommRecsAgy, myCommLvl, Agency, TheDate, null, null, Source);
                mergedList = (commQueryGetProduct.Union(commQueryyGetAgency)).ToList();
                GridControlMarkups.DataSource = mergedList;
            }
        }

        private void CompForm_KeyDown(object sender, KeyEventArgs e)
        { 
            if (e.KeyCode == Keys.Enter && GridViewComponents.IsFilterRow(GridViewComponents.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewComponents.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewComponents.GetFocusedDisplayText()))
                value = GridViewComponents.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.NAME like '{0}%'", GridViewComponents.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "NAME"));
                var special = _context.COMP.Where(query);
               
                if (!string.IsNullOrWhiteSpace(GridViewComponents.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE")))
                {
                    query = String.Format("it.{0} like '{1}%'", "CODE", GridViewComponents.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                    special = special.Where(query);
                }     
                int count = special.Count();
                if (count > 0)
                {
                    CompBindingSource.DataSource = special;
                    GridViewComponents.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewComponents.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default; 
        }

        private void ImageComboBoxEditLanguage_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMP)CompBindingSource.Current).checkOperator, CompBindingSource);
            }
        }

        private void ImageComboBoxEditDifficulty_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMP)CompBindingSource.Current).checkOperator, CompBindingSource);
            }
        }

        private void TextEditName_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMP)CompBindingSource.Current).checkName, CompBindingSource);
            }
        }

        private void durationTimeEdit_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
            }
        }

        private void CheckEditMultTimes_Modified(object sender, EventArgs e)
        {
            Modified = true;
            ImageComboBoxEditTourTime.Text = "";
            TextEditDefaultTime.Text = "";
            if (CheckEditMultTimes.Checked == true)
            {
                TextEditDefaultTime.Enabled = true;
                ImageComboBoxEditTourTime.Enabled = false;
            }
            else
            {
                TextEditDefaultTime.Enabled = false;
                ImageComboBoxEditTourTime.Enabled = true;
            }
        }

        private void CompForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_modified || newRec)
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

        private void TextEditAddr1_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMP)CompBindingSource.Current).checkAddress1, CompBindingSource);
            }
        }

        private void TextEditAddr2_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMP)CompBindingSource.Current).checkAddress2, CompBindingSource);
            }
        }

        private void TextEditAddr3_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMP)CompBindingSource.Current).checkAddress3, CompBindingSource);
            }
        }

        private void TextEditTown_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMP)CompBindingSource.Current).checkTown, CompBindingSource);
            }
        }

        private void TextEditZip_Leave(object sender, EventArgs e)
        {
            if (CompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMP)CompBindingSource.Current).checkZip, CompBindingSource);
            }
        }

		private void checkEditProximitySearch_CheckedChanged(object sender, EventArgs e)
		{
			spinEditDistance.Enabled = (checkEditProximitySearch.Checked);
			if (!checkEditProximitySearch.Checked)
				spinEditDistance.Value = 0;
		}

		private void checkEditProximitySearch_Leave(object sender, EventArgs e)
		{
			if (CompBindingSource.Current != null) {
				if (currentVal != ((Control)sender).Text.ToString())
					Modified = true;
			}
		}

		private void spinEditDistance_Leave(object sender, EventArgs e)
		{
			if (CompBindingSource.Current != null) {
				if (currentVal != ((Control)sender).Text.ToString())
					Modified = true;
				validCheck.check(sender, errorProvider1, ((COMP)CompBindingSource.Current).checkDistance, CompBindingSource);
			}
		}

		private void simpleButtonAddRoute_Click(object sender, EventArgs e)
		{
			CompBusRoute route = new CompBusRoute();
			if (_selectedRecord != null) {
				_selectedRecord.CompBusRoute.Add(route);
				BindCompBusRoute();
				gridViewRoutes.FocusedRowHandle = bindingSourceCompBusRoutes.Count - 1;
				Modified = true;
			}
		}

		private void simpleButtonRemoveRoute_Click(object sender, EventArgs e)
		{
			if (gridViewRoutes.FocusedRowHandle >= 0) {
				CompBusRoute route = (CompBusRoute)gridViewRoutes.GetFocusedRow();
				bindingSourceCompBusRoutes.Remove(route);
				//Removing from the bindingsource just removes the object from its parent, but does not mark
				//it for deletion, effectively orphaning it.  This will cause foreign key errors when saving.
				//To flag for deletion, delete it from the context as well.
				_context.CompBusRoute.DeleteObject(route);
				BindCompBusRoute();
				Modified = true;
			}
		}

		private void BindCompBusRoute()
		{
			gridControlRoutes.DataSource = bindingSourceCompBusRoutes;
			gridControlRoutes.RefreshDataSource();
		}

		private void simpleButtonSaveRoutes_Click(object sender, EventArgs e)
		{
			gridViewRoutes.FocusedColumn = gridViewRoutes.Columns["BusRoute_ID"];
			if (gridViewRoutes.UpdateCurrentRow()) {
				bindingSourceCompBusRoutes.EndEdit();
				CompBindingNavigatorSaveItem_Click(sender, e);
				Modified = false;
			}         
		}

		private void gridViewRoutes_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
		{
			e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box       
		}

		private void gridViewRoutes_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
		{
			if (e.IsGetData) {
				var compRoute = (CompBusRoute)bindingSourceCompBusRoutes.List[e.ListSourceRowIndex];
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

		private void gridViewRoutes_ValidateRow(object sender, ValidateRowEventArgs e)
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

		private void checkEditProximitySearch_Click(object sender, EventArgs e)
		{
			Modified = true;
		}

		private void ImageComboBoxEditServiceType_SelectedIndexChanged(object sender, EventArgs e)
		{
			string serviceType = string.Empty;
			if (ImageComboBoxEditServiceType.SelectedIndex > 0) {
				ImageComboBoxItem item = (ImageComboBoxItem)ImageComboBoxEditServiceType.SelectedItem;
				serviceType = item.Value.ToString();
			}
			xtraTabPageRoutes.PageEnabled = (serviceType == hopTourServiceType);
			gridViewTransferPoints.Columns["CompBusRoute_ID"].Visible = (serviceType == hopTourServiceType);
		}

		private void buttonAddMembership_Click(object sender, EventArgs e)
		{
			if (newRowRec == false) {
				if (GridViewDetail.RowCount == 0) {
					DetailBindingSource.DataSource = from c in _context.DETAIL where c.CODE == "KJM9" select c;
					newRowRec = true;
					GridViewDetail.AddNewRow();
					GridViewDetail.SetFocusedRowCellValue("LINK_TABLE", "COMP");
					GridViewDetail.SetFocusedRowCellValue("RECTYPE", "OPTCLASS");
					GridViewDetail.SetFocusedRowCellValue("LINK_VALUE", TextEditCode.Text);
					GridViewDetail.SetFocusedRowCellValue("USER_DEC1", 0);
					GridViewDetail.SetFocusedRowCellValue("USER_DEC2", 0);
					GridViewDetail.SetFocusedRowCellValue("USER_INT1", 0);
					GridViewDetail.SetFocusedRowCellValue("USER_INT2", 0);
					GridViewDetail.SetFocusedRowCellValue("USER_TXT1", string.Empty);
					GridViewDetail.SetFocusedRowCellValue("USER_TXT2", string.Empty);
					GridViewDetail.SetFocusedRowCellValue("USER_TXT3", string.Empty);
					GridViewDetail.SetFocusedRowCellValue("USER_TXT4", string.Empty);
					Modified = true;
					return;
				}
				newRowRec = true;
				GridViewDetail.AddNewRow();
				GridViewDetail.SetFocusedRowCellValue("LINK_TABLE", "COMP");
				GridViewDetail.SetFocusedRowCellValue("RECTYPE", "OPTCLASS");
				GridViewDetail.SetFocusedRowCellValue("LINK_VALUE", TextEditCode.Text);
				GridViewDetail.SetFocusedRowCellValue("USER_DEC1", 0);
				GridViewDetail.SetFocusedRowCellValue("USER_DEC2", 0);
				GridViewDetail.SetFocusedRowCellValue("USER_INT1", 0);
				GridViewDetail.SetFocusedRowCellValue("USER_INT2", 0);
				GridViewDetail.SetFocusedRowCellValue("USER_TXT1", string.Empty);
				GridViewDetail.SetFocusedRowCellValue("USER_TXT2", string.Empty);
				GridViewDetail.SetFocusedRowCellValue("USER_TXT3", string.Empty);
				GridViewDetail.SetFocusedRowCellValue("USER_TXT4", string.Empty);
				Modified = true;
			}
			else
				MessageBox.Show("Please save current record before attempting to add another.");
		}

		private void buttonDelMembership_Click(object sender, EventArgs e)
		{
			int handle = GridViewDetail.FocusedRowHandle;
			GridViewDetail.DeleteRow(handle);
			DetailBindingSource.EndEdit();
			_context.SaveChanges();
			newRowRec = false;
			Modified = false;
		}

		private void buttonSaveMemberships_Click(object sender, EventArgs e)
		{
			GridViewDetail.FocusedColumn = GridViewDetail.Columns["RECTYPE"];
			if (GridViewDetail.UpdateCurrentRow()) {
				DetailBindingSource.EndEdit();
				CompBindingNavigatorSaveItem_Click(sender, e);
				newRowRec = false;
				Modified = false;
			}
		}

		private void GridViewDetail_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			Modified = true;
		}

		private void GridViewLookup_DoubleClick(object sender, EventArgs e)
		{
			GridView view = (GridView)sender;
			Point pt = view.GridControl.PointToClient(Control.MousePosition);
			RowDoubleClick(view, pt);
		}

		private void RowDoubleClick(GridView view, Point pt)
		{
			GridHitInfo info = view.CalcHitInfo(pt);
			if (info.InRow || info.InRowCell) {
				popupContainerControlLookup.OwnerEdit.ClosePopup();
			}
		}

		private void LookupButtonOk_Click(object sender, EventArgs e)
		{
			popupContainerControlLookup.OwnerEdit.ClosePopup();

		}

		private void LookupButtonCancel_Click(object sender, EventArgs e)
		{
			popupContainerControlLookup.OwnerEdit.CancelPopup();
		}

		private void repositoryItemPopupContainerEdit1_QueryResultValue(object sender, QueryResultValueEventArgs e)
		{
			GridViewDetail.SetFocusedRowCellValue("NOTE", GridViewLookup.GetRowCellValue(GridViewLookup.FocusedRowHandle, "DESC").ToString());
			e.Value = GridViewLookup.GetRowCellValue(GridViewLookup.FocusedRowHandle, "CODE").ToString();
		}

        private void checkEditVendorPrepayReqd_Click(object sender, EventArgs e)
        {
            Modified = true;
        }

        private void checkEditAccountingServiceItem_Click(object sender, EventArgs e)
        {
            Modified = true;
        }

        private void checkEditPassengerWeightRequired_Click(object sender, EventArgs e)
        {
            Modified = true;
        }

        private void MappingAddButton_Click(object sender, EventArgs e)
        {
            if (_selectedRecord != null) {
                SupplierProduct product = new SupplierProduct();
                product.Product_Code_Internal = TextEditCode.Text;
                product.Product_Type = "OPT";
                _selectedRecord.SupplierProduct.Add(product);
                BindSupplierProducts();
                gridViewSupplierProduct.FocusedRowHandle = bindingSourceSupplierProduct.Count - 1;
                Modified = true;
            }
        }

        private void MappingDelButton_Click(object sender, EventArgs e)
        {
            if (gridViewSupplierProduct.FocusedRowHandle >= 0) {
                SupplierProduct suppProd = (SupplierProduct)gridViewSupplierProduct.GetFocusedRow();
                bindingSourceSupplierProduct.Remove(suppProd);
                //Removing from the bindingsource just removes the object from its parent, but does not mark
                //it for deletion, effectively orphaning it.  This will cause foreign key errors when saving.
                //To flag for deletion, delete it from the context as well.
                _context.SupplierProduct.DeleteObject(suppProd);
                BindSupplierProducts();
                Modified = true;
            }
        }

        void BindSupplierProducts()
        {
            gridControlSupplierProduct.DataSource = bindingSourceSupplierProduct;
            gridControlSupplierProduct.RefreshDataSource();
        }

        private void gridViewSupplierProduct_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        void gridViewSupplierProduct_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column == gridColumnSupplierGuid) {
                e.RepositoryItem = _supplierCombo;
            }
            else if (e.Column == gridColumnMappingOperator) {
                e.RepositoryItem = _operatorCombo;
            }
        }

        private void gridViewSupplierProduct_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            Modified = true;
        }

        private void gridViewSupplierProduct_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            view.ClearColumnErrors();
            GridColumn colSupplier = view.Columns["Supplier_GUID"];
            GridColumn colSupplierCode = view.Columns["ProductCodeSupplier"];
            if (view.GetRowCellValue(e.RowHandle, colSupplier) == null) {
                e.Valid = false;
                view.SetColumnError(colSupplier, "Please select a Supplier from the dropdown for the new Supplier Mapping record.");
            }
            if (string.IsNullOrEmpty(view.GetRowCellValue(e.RowHandle, colSupplierCode).ToString())) {
                e.Valid = false;
                view.SetColumnError(colSupplierCode, "Please enter a Supplier Product Code for the new Supplier Mapping record.");
            }
        }

        private void gridViewRoutes_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "BusRoute_ID") {
                gridViewRoutes.PostEditor();
                gridViewRoutes.SetFocusedRowCellValue("BusRouteStop_ID_First", null);
                gridViewRoutes.SetFocusedRowCellValue("BusRouteStop_ID_Last", null);
            }
            _modified = true;
        }

        private void gridViewRoutes_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "BusRouteStop_ID_First" || e.Column.FieldName == "BusRouteStop_ID_Last") {
                _busStopsCombo.Items.Clear();
                int? routeId = gridViewRoutes.GetRowCellValue(e.RowHandle, "BusRoute_ID") as int?;
                if (routeId != null) {
                    List<ImageComboBoxItem> lookup = new List<ImageComboBoxItem>();
                    lookup.AddRange(_context.BusRouteStop.Where(brs => brs.BusRoute_ID == routeId)
                        .OrderBy(brs => brs.Sequence).AsEnumerable()
                        .Select(brs => new ImageComboBoxItem() { Description = brs.Code, Value = brs.ID })
                        .ToList());
                    lookup.Insert(0, new ImageComboBoxItem() { Description = "", Value = null });
                    _busStopsCombo.Items.AddRange(lookup);
                }
                e.RepositoryItem = _busStopsCombo;
            }
        }
    }
}
