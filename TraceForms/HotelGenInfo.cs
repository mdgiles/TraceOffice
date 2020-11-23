using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Linq.Dynamic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FlexModel;
using System.Data.SqlClient;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using System.Runtime.InteropServices;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views;
using System.Data.OleDb;
using DevExpress.XtraGrid.Views.Card;
using FlexEntities.Entities;
using System.Data.Entity.Core.Objects;
using FlexInterfaces.Core;

namespace TraceForms
{
    public partial class HotelGenInfo : DevExpress.XtraEditors.XtraForm
    {
        public List<IComprod2> myCommRecs;
        public List<IComprod2> myCommRecsAgy;
        public List<ICommLevel> myCommLvl;
        public FlextourEntities context;
        public int i = 0;
        public int pageCount = 1;
        public string currentVal;
        public bool _modified = false;
        public bool newRec = false;
        public bool newRowRec = false;
        public bool roomTypNewRec = false;
        public bool ratePlanNewRec = false;
        public int newRowHandle;
        public int roomTypenewRowHandle;
        public bool contactNewRowRec = false;
        public bool firstLoad = false;
        public bool temp = false;
        public string globalRptType = string.Empty;
        public string internalCode = string.Empty;
        const string col = "colCODE";
        public Timer rowStatusSave;
        public Timer rowStatusDelete;
        public ImageComboBoxItemCollection hbsiGroup;
        public ImageComboBoxItemCollection mgmgroup;
        public string username;
        public string keyLogger = "";
        string _accountingURL;
        RepositoryItemImageComboBox _supplierCombo = new RepositoryItemImageComboBox();
        RepositoryItemImageComboBox _operatorCombo = new RepositoryItemImageComboBox();
        RepositoryItemImageComboBox _catCombo = new RepositoryItemImageComboBox();
        HOTEL _selectedRecord;
        List<CodeName> _hotelLookup;
        ICoreSys _sys;
        FlextourEntities _context;

        public HotelGenInfo(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
            LoadLookups();
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);
            username = sys.User.Name;
            _accountingURL = sys.Settings.TourAccountingURL;
            _context = new FlextourEntities(sys.Settings.EFConnectionString);
            _sys = sys;
        }

        private void LoadLookups()
        {

            GridControlLookup.DataSource = from lookupRec in context.LOOKUP where lookupRec.RECTYPE == "HTLCLASS" select lookupRec;
            var htlRating = from htlRate in context.HTLRATNG orderby htlRate.Stars ascending select new { htlRate.CODE, htlRate.DESCRIP };
            var htlType = from htltyp in context.HTLTYPE orderby htltyp.CODE ascending select new { htltyp.CODE, htltyp.DESCRIP };
            var cty = from ctyRec in context.CITYCOD orderby ctyRec.CODE ascending select new { ctyRec.CODE, ctyRec.NAME };
            var hotel = from hotelRec in context.HOTEL orderby hotelRec.CODE ascending select new { hotelRec.CODE, hotelRec.NAME };
            var agy = from agyRec in context.AGY orderby agyRec.NO ascending select new { agyRec.NO, agyRec.NAME };
            var state = from stateRec in context.State orderby stateRec.Code ascending select new { stateRec.Code, stateRec.State1 };
            var count = from countryRec in context.COUNTRY orderby countryRec.CODE ascending select new { countryRec.CODE, countryRec.NAME };
            var air = from airpRec in context.Airport orderby airpRec.Code ascending select new { airpRec.Code, airpRec.Name };
            var region = from regRec in context.REGION orderby regRec.CODE ascending select new { regRec.CODE, regRec.DESC };
            var cat = from catRec in context.ROOMCOD orderby catRec.CODE ascending select new { catRec.CODE, catRec.DESC };
            var chain = from chainRec in context.HTLCHAIN orderby chainRec.CODE ascending select new { chainRec.CODE, chainRec.DESC };
            var brand = from brandRec in context.HTLBRAND orderby brandRec.CODE ascending select new { brandRec.CODE, brandRec.DESC };
            var company = from companyRec in context.COMPANY orderby companyRec.CODE ascending select new { companyRec.CODE, companyRec.NAME };
            var oper = from operRec in context.OPERATOR orderby operRec.CODE ascending select new { operRec.CODE, operRec.NAME };
            var dept = from deptRec in context.Dept orderby deptRec.Code ascending select new { deptRec.Code, deptRec.Desc };
            gridControlPopup.DataSource = from RptRec in context.RPTTYPE where RptRec.RecipientType == "Hotel" select RptRec;
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = null };
            ImageComboBoxEditRating.Properties.Items.Add(loadBlank);
            ImageComboBoxEditType.Properties.Items.Add(loadBlank);
            ImageComboBoxEditArea.Properties.Items.Add(loadBlank);
            ImageComboBoxEditAirport.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCityCode.Properties.Items.Add(loadBlank);
            ImageComboBoxEditAgency.Properties.Items.Add(loadBlank);
            ImageComboBoxEditState.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCountry.Properties.Items.Add(loadBlank);  
            ImageComboBoxEditRegion.Properties.Items.Add(loadBlank);
            ImageComboBoxEditDefCat.Properties.Items.Add(loadBlank);
            ImageComboBoxEditChain.Properties.Items.Add(loadBlank);
            ImageComboBoxEditBrand.Properties.Items.Add(loadBlank);
            ImageComboBoxEditMgmt.Properties.Items.Add(loadBlank);
            ImageComboBoxEditOper.Properties.Items.Add(loadBlank);
            ImageComboBoxEditAgentComm.Properties.Items.Add(loadBlank);
            foreach (var result in dept)
            {
                repositoryItemComboBoxDept.Items.Add(result.Code + " " + result.Desc);
            }
            foreach (var result in htlRating)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.DESCRIP.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditRating.Properties.Items.Add(load);
            }
            foreach (var result in htlType)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.DESCRIP.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditType.Properties.Items.Add(load);
            }
            foreach (var result in cty)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditArea.Properties.Items.Add(load);
                ImageComboBoxEditAirport.Properties.Items.Add(load);
                ImageComboBoxEditCityCode.Properties.Items.Add(load);
            }
            foreach (var result in agy)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.NO.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.NO.TrimEnd() };
                ImageComboBoxEditAgency.Properties.Items.Add(load);
                ImageComboBoxEditAgentComm.Properties.Items.Add(load);
            }
            foreach (var result in state)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.Code.TrimEnd() + "  " + "(" + result.State1.TrimEnd() + ")", Value = result.Code.TrimEnd() };
                ImageComboBoxEditState.Properties.Items.Add(load);
            }
            foreach (var result in count)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCountry.Properties.Items.Add(load);
            }
            foreach (var result in region)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.DESC.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditRegion.Properties.Items.Add(load);
            }
            foreach (var result in air)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.Code.TrimEnd() + "  " + "(" + result.Name.TrimEnd() + ")", Value = result.Code.TrimEnd() };
                ImageComboBoxEditAirport.Properties.Items.Add(load);
            }
            foreach (var result in cat)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.DESC.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditDefCat.Properties.Items.Add(load);
            }
            foreach (var result in oper)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditOper.Properties.Items.Add(load);
            }
            foreach (var result in company)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditMgmt.Properties.Items.Add(load);
            }
            foreach (var result in chain)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.DESC.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditChain.Properties.Items.Add(load);
            }
            foreach (var result in brand)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.DESC.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditBrand.Properties.Items.Add(load);
            }

            _catCombo.Items.Add(loadBlank);
            _catCombo.Items.AddRange(context.ROOMCOD
                .OrderBy(c => c.CODE)
                .AsEnumerable()
                .Select(s => new ImageComboBoxItem() { Description = $"{s.DESC} ({s.CODE})", Value = s.CODE }).ToList());
            GridControlSuppRoomType.RepositoryItems.Add(_catCombo);

            _supplierCombo.Items.Add(loadBlank);
            _supplierCombo.Items.AddRange(context.Supplier
                            .Where(sp => (sp.ProductType ?? "HTL").Contains("HTL"))
                            .OrderBy(o => o.Name).AsEnumerable()
                            .Select(s => new ImageComboBoxItem() { Description = s.Name, Value = s.GUID })
                            .ToList());
            gridControlSupplierProduct.RepositoryItems.Add(_supplierCombo);        //per DX recommendation to avoid memory leaks
            GridControlSuppRoomType.RepositoryItems.Add(_supplierCombo);

            _operatorCombo.Items.Add(loadBlank);
            _operatorCombo.Items.AddRange(context.OPERATOR
                            .OrderBy(o => o.NAME).AsEnumerable()
                            .Select(s => new ImageComboBoxItem() { Description = $"{s.CODE} ({s.NAME})", Value = s.CODE })
                            .ToList());
            gridControlSupplierProduct.RepositoryItems.Add(_operatorCombo);        //per DX recommendation to avoid memory leaks

            _hotelLookup = new List<CodeName> {
                new CodeName()
            };
            _hotelLookup.AddRange(context.HOTEL
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.NAME }));
            bindingSourceCodeNameProduct.DataSource = _hotelLookup;

            GridColumn columnHotelInfo = GridViewCustom.Columns.AddField("HotelValue");
            columnHotelInfo.VisibleIndex = 1;
            columnHotelInfo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            columnHotelInfo.Visible = true;
            Modified = false;
            newRec = false;
            setReadOnly(true);
        }

        private bool Modified
        {
            get
            {
                return _modified;
            }
            set {
                _modified = value;
                if (value && HotelBindingSource.Current != null) {
                    //NB: Before updating any property on the entity, any pending edits must be committed 
                    //with bindingSource.EndEdit, other when the properties are set the form bindings are
                    //automatically refreshed, which causes any pending edits to be lost. 
                    HotelBindingSource.EndEdit();
                    HOTEL hotel = (HOTEL)HotelBindingSource.Current;
                    hotel.LAST_UPD = DateTime.Now;
                    hotel.UPD_INIT = username;
                }
            }
        }

        void setReadOnly(bool value)
        {
            TextEditCode.Properties.ReadOnly = value;
            GridViewHotels.Columns.ColumnByName(col).OptionsColumn.AllowEdit = !(value);
        }

        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        private bool checkForms()
        {
            string val = string.Empty;
            if (!_modified && !newRec)
                return true;
            if (!CheckMappings()) return false;
            bool ok = validCheck.checkAll(splitContainerControl1.Panel2.Controls, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkSplitContainer, HotelBindingSource);
            bool ok1 = validCheck.checkAll(PanelControlAvailabilityTab.Controls, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkPanel1, HotelBindingSource);
            bool ok2 = validCheck.checkAll(PanelControlRestrictionsTab.Controls, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkPanel2, HotelBindingSource);
            bool ok3 = validCheck.checkAll(panelControl3.Controls, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkPanel3, HotelBindingSource);
            bool ok4 = validCheck.checkAll(panelControl4.Controls, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkPanel4, HotelBindingSource);
            bool ok5 = validCheck.checkAll(panelControl5.Controls, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkPanel5, HotelBindingSource);
            bool ok6 = validCheck.checkAll(panelControl6.Controls, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkPanel6, HotelBindingSource);
            bool ok7 = validCheck.checkAll(panelControl7.Controls, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkPanel7, HotelBindingSource);
            bool ok8 = validCheck.checkAll(panelControl7.Controls, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkPanel8, HotelBindingSource);
			if (!CheckRoomTypes()) return false;
			if (!CheckRatePlans()) return false;

            if (ok && ok1 && ok2 && ok3 && ok4 && ok5 && ok6 && ok7 && ok8) {
                var ret = validCheck.saveRec(ref _modified, true, ref newRec, context, HotelBindingSource, this.Name, ErrorProvider, Cursor);
                if (ret) {
                    AccountingAPI.InvokeForProduct(_accountingURL, "HTL", ((HOTEL)HotelBindingSource.Current).CODE);
                }
                return ret;
            }
            else
            {
                validCheck.saveRec(ref _modified, false, ref newRec, context, HotelBindingSource, this.Name, ErrorProvider, Cursor);
                return false;
            }
        }

        private bool CheckMappings()
        {
            for (int row = 0; row < gridViewSupplierProduct.RowCount; row++) {
                SupplierProduct product = (SupplierProduct)gridViewSupplierProduct.GetRow(row);
                product.Product_Code_Internal = TextEditCode.Text;
                product.Product_Type = "HTL";

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

        private bool CheckRatePlans()
		{
			GridViewSuppRatePlan.UpdateCurrentRow();
			for (int row = 0; row < GridViewSuppRatePlan.DataRowCount; row++) {
				var ratePlan = (SupplierRatePlan)GridViewSuppRatePlan.GetRow(row);
				if (string.IsNullOrEmpty(ratePlan.Code)) {
					SetGridError(xtraTabControl1, xtraTabPageSupplierRoomTypes, GridControlSuppRatePlan, GridViewSuppRatePlan,
						row, "Code", "The Supplier Rate Plan is required.");
					return false;
				}
				if (string.IsNullOrEmpty(ratePlan.SpecialValue_Code) & !ratePlan.Inactive) {
					SetGridError(xtraTabControl1, xtraTabPageSupplierRoomTypes, GridControlSuppRatePlan, GridViewSuppRatePlan,
						row, "SpecialValue_Code", "A Special Value is required for active mappings.");
					return false;
				}
			}

			//Id of 0 represents no room type mapping, but it needs to be null for the foreign key
			foreach (SupplierRatePlan ratePlan in supplierHotelRatePlanBindingSource) {
				if (ratePlan.SupplierCategory_Id == 0) {
					ratePlan.SupplierCategory_Id = null;
					ratePlan.SupplierCategory = null;
				}
				ratePlan.Product_Code = TextEditCode.Text;
                ratePlan.Product_Type = "HTL";
			}

			return true;
		}

		private bool CheckRoomTypes()
		{
			GridViewSuppRoomType.UpdateCurrentRow();
			for (int row = 0; row < GridViewSuppRoomType.DataRowCount; row++) {
				var roomType = (SupplierCategory)GridViewSuppRoomType.GetRow(row);
				if (roomType.Supplier_GUID == null) {
					SetGridError(xtraTabControl1, xtraTabPageSupplierRoomTypes, GridControlSuppRoomType, GridViewSuppRoomType,
						row, "Supplier_GUID", "The Supplier is required.");
					return false;
				}
				if (string.IsNullOrEmpty(roomType.Code)) {
					SetGridError(xtraTabControl1, xtraTabPageSupplierRoomTypes, GridControlSuppRoomType, GridViewSuppRoomType,
						row, "Code", "The Supplier Room Type is required.");
					return false;
				}
                //SupplierCategory now also holds lists of categories for API hotels, so not linked to anything in roomcod
				//if (string.IsNullOrEmpty(roomType.Roomcod_Code) & !roomType.Inactive) {
				//	SetGridError(xtraTabControl1, xtraTabPageSupplierRoomTypes, GridControlSuppRoomType, GridViewSuppRoomType,
				//		row, "Roomcod_Code", "A Category is required for active mappings.");
				//	return false;
				//}
			}

			//Empty string represents no category mapping, but it needs to be null for the foreign key
			foreach (SupplierCategory roomType in supplierHotelRoomTypeBindingSource) {
				if (string.IsNullOrWhiteSpace(roomType.Roomcod_Code)) {
					roomType.Roomcod_Code = null;
				}
				roomType.Product_Code = TextEditCode.Text;
                roomType.Product_Type = "HTL";
			}

			return true;
		}

		private void SetGridError(DevExpress.XtraTab.XtraTabControl tabControl, DevExpress.XtraTab.XtraTabPage tabPage, 
			GridControl gridControl, GridView gridView, int row, string field, string errorText)
		{
			tabControl.SelectedTabPage = tabPage;
			gridControl.Focus();
			gridView.FocusedRowHandle = row;
			gridView.FocusedColumn = GridViewSuppRoomType.Columns[field];
			gridView.ShowEditor();
			if (gridView.ActiveEditor != null) {
				gridView.ActiveEditor.ErrorText = errorText;
				gridView.ActiveEditor.IsModified = true;
			}
			MessageBox.Show(errorText, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

        private void setCheckEdits()
        {
            GridViewHotels.SetFocusedRowCellValue("ADMINCLOSED", "N");
            GridViewHotels.SetFocusedRowCellValue("INACTIVE", "N");
            GridViewHotels.SetFocusedRowCellValue("PFRD_FLG", "N");
            GridViewHotels.SetFocusedRowCellValue("ADV_PMT", "N");
            GridViewHotels.SetFocusedRowCellValue("NAMECHG", "N");
            GridViewHotels.SetFocusedRowCellValue("MAILFAX", "E");
            GridViewHotels.SetFocusedRowCellValue("USE_CLIENT_LOGO", "N");
            GridViewHotels.SetFocusedRowCellValue("RSTR_CDE", "O");
            GridViewHotels.SetFocusedRowCellValue("TourfaxEmailFormat", "txt");
            GridViewHotels.SetFocusedRowCellValue("Type", "HTL");
            GridViewHotels.SetFocusedRowCellValue("AP", 0);
            GridViewHotels.SetFocusedRowCellValue("AR", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("ADDR1", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("ADDR2", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("ADDR3", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("PHONE", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("TELEX", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("GEN_MGR", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("AP_MGR", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("LOCAL_NAME", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("LOCAL_PHONE", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("CHECK_IN", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("CRED_CARDS", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("ROOM_DESC", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("CHILD_DESC", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("COMMENT1", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("COMMENT2", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("OPER", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("CONTR_CDE", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("CONTR_AGY", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("ALTERN_1", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("ALTERN_2", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("ALTERN_3", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("ACT_CITY", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("DFLT_CAT", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("RES_EMAIL", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("AP_EMAIL", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("RESTRICTCODE", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("RESTRICTDESC", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("CLOSEUPDBY", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("CITY", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("STATE", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("ZIP", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("BILLACCT", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("GMACCTNO", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("LATITUDE", 0);
            GridViewHotels.SetFocusedRowCellValue("LONGITUDE", 0);
            GridViewHotels.SetFocusedRowCellValue("CHAIN", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("BRAND", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("MGMT_CO", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("USER_DEC1", 0);
            GridViewHotels.SetFocusedRowCellValue("USER_DEC2", 0);
            GridViewHotels.SetFocusedRowCellValue("USER_DTE1", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("USER_DTE2", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("USER_INT1", 0);
            GridViewHotels.SetFocusedRowCellValue("USER_INT2", 0);
            GridViewHotels.SetFocusedRowCellValue("USER_TXT1", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("USER_TXT2", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("USER_TXT3", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("USER_TXT4", string.Empty);
            GridViewHotels.SetFocusedRowCellValue("GeoCode_ID", 0);
            GridViewHotels.SetFocusedRowCellValue("Requestable", 0);
            GridViewHotels.SetFocusedRowCellValue("AccountingServiceItem", 1);
            GridViewHotels.SetFocusedRowCellValue("PreTaxRatesOnAdvice", 0);
            GridViewHotels.SetFocusedRowCellValue("VendorPrepayReqd", 0);
            checkEditAccountingServiceItem.Checked = false;
            checkEditVendorPrepayReqd.Checked = false;
            checkEditPreTaxRatesOnAdvice.Checked = false;
            if (HotelBindingSource.Current != null) {
                var hotel = (HOTEL)HotelBindingSource.Current;
                hotel.AccountingServiceItem = true;
                hotel.VendorPrepayReqd = false;
                hotel.PreTaxRatesOnAdvice = false;
            }
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }

		private void LoadRoomTypeLookup(string code)
		{
			var roomTypes = context.SupplierCategory.Where(h => h.Product_Type == "HTL" && h.Product_Code == code).ToList();
			roomTypes.Insert(0, new SupplierCategory());
			repositoryItemLookUpEditRoomType.DataSource = roomTypes;
		}

		private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        void ButtonEdit_QueryPopUp1(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
        }

        private void gridView3_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "HotelValue" && e.IsGetData)
            {
                string desc = GridViewCustom.GetRowCellValue(e.ListSourceRowIndex, "LINK_COLUMN").ToString();
                desc = desc.Trim();
                e.Value = GridViewHotels.GetRowCellValue(HotelBindingSource.IndexOf(HotelBindingSource.Current), desc);
            }

            if (e.Column.FieldName == "HotelValue" && e.IsSetData)
            {
                string desc = GridViewCustom.GetRowCellValue(e.ListSourceRowIndex, "LINK_COLUMN").ToString();
                desc = desc.Trim();
                GridViewHotels.SetRowCellValue(HotelBindingSource.IndexOf(HotelBindingSource.Current), desc, e.Value);
                Modified = true;
            }
        }

        private void hOTELBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            _selectedRecord = (HOTEL)HotelBindingSource.Current;
            ComboBoxEditSource.Text = string.Empty;
            ImageComboBoxEditAgentComm.Text = string.Empty;
            dateComm.Text = string.Empty;
            gridControl5.DataSource = null;
            gridControl6.DataSource = null;
            if (_selectedRecord != null) {
                GridControlAdditionalContacts.DataSource = (from contRec in context.CONTACT
                                                            where contRec.LINK_VALUE == _selectedRecord.CODE && contRec.RECTYPE == "HTLCONTACT"
                                                                && contRec.LINK_TABLE == "HOTEL"
                                                            select contRec).Distinct();

                //UpdateCommMarkupGrid(rec.CODE, null, "ALL");
                GridControlDetail.DataSource = from c in context.DETAIL where c.LINK_VALUE.TrimEnd() == _selectedRecord.CODE.TrimEnd() select c;
                GridControlCustom.DataSource = from c in context.USERFIELDS
                                               where c.LINK_TABLE.Equals("HOTEL")
                                               select c;

                if (!String.IsNullOrEmpty(_selectedRecord.CODE)) { //new record
                    _selectedRecord.SupplierProduct.Load(MergeOption.OverwriteChanges);
                }
                bindingSourceSupplierProduct.DataSource = _selectedRecord.SupplierProduct;

                LoadRoomTypeLookup(_selectedRecord.CODE);
                supplierHotelRoomTypeBindingSource.DataSource = from supRec in context.SupplierCategory
                                                                where supRec.Product_Code == _selectedRecord.CODE && supRec.Product_Type == "HTL"
                                                                select supRec;
                supplierHotelRatePlanBindingSource.DataSource = from supRec in context.SupplierRatePlan
                                                                where supRec.Product_Code == _selectedRecord.CODE && supRec.Product_Type == "HTL"
                                                                select supRec;
                GridControlSuppRoomType.RefreshDataSource();
                GridControlSuppRatePlan.RefreshDataSource();

                for (int i = 0; i < GridViewCustom.DataRowCount; i++)
                    GridViewCustom.RefreshRow(i);

                if ((_selectedRecord.CONTR_CDE == "C" || _selectedRecord.CONTR_CDE == "P") || (_selectedRecord.RSTR_CDE == "A"))
                    ImageComboBoxEditAgency.Properties.ReadOnly = false;
                else
                    ImageComboBoxEditAgency.Properties.ReadOnly = true;

            }
       }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            Uri mapUri = new Uri(new Uri("http://www.bing.com/"), "maps/default.aspx?where1=" + aDDR1TextBox.Text + "%20" + aDDR2TextBox.Text + "%20" + aDDR3TextBox.Text + ",%20" + cITYTextEdit.Text + ",%20" + ImageComboBoxEditState.EditValue + ",%20" + ImageComboBoxEditState.EditValue + "&v=2");
            Form map = new TraceForms.WebBrowser(mapUri) { MdiParent = this.ParentForm };
            map.Show();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            Uri mapUri = new Uri(new Uri("http://www.bing.com/"), "maps/default.aspx?where1=" + lATITUDETextBox.Text + ",%20" + lONGITUDETextBox.Text + "&v=2");
            Form map = new TraceForms.WebBrowser(mapUri) { MdiParent = this.ParentForm };
            map.Show();
        }

		//public void grid2Load()
		//{
		//   GridControlCustom.DataSource = from c in context.USERFIELDS
		//							  where c.LINK_TABLE.Equals("HOTEL")
		//							  select c;
		//	GridControlHotelMapping.DataSource = from supRec in context.SupplierConnectionRule where supRec.Value == TextEditCode.Text select supRec;

		//	supplierHotelRoomTypeBindingSource.DataSource = from supRec in context.SupplierHotelRoomType.Include("SupplierHotelRatePlan") where supRec.Hotel_Code == TextEditCode.Text select supRec;
		//}

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (newRowRec == true || contactNewRowRec == true)
            {
                if (newRowRec)
                    MessageBox.Show("Please save or delete the new record being added in the grid on the Contacts tab before attempting to navigate to another record.");
                else
                    MessageBox.Show("Please save or delete the new record being added in the grid on the Memberships tab before attempting to navigate to another record.");
                e.Allow = false;
                return;
            }

            if (HotelBindingSource.Current == null)
            {
                e.Allow = true;
                return;
            }

            temp = newRec;
            bool temp2 = _modified;
            if (checkForms())
            {
                ErrorProvider.Clear();
                e.Allow = true;
                if ((!temp) && temp2)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (HOTEL)HotelBindingSource.Current);
                setReadOnly(true);
            }
            else
            {
                if (!temp && !_modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (HOTEL)HotelBindingSource.Current);
            
                e.Allow = false;

            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string value = e.Value.ToString();
            if (!GridViewHotels.IsFilterRow(e.RowHandle))
            {
                Modified = true;
            }
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void HotelGenInfo_FormClosing(object sender, FormClosingEventArgs e)
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

        private void codeSearch_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
                TextEditCode.Text = TextEditCode.Text.ToUpper();
                validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkCode, HotelBindingSource);
            }
        }
        }

        private void nAMETextBox_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
                validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkName, HotelBindingSource);
            }
        }
        }

        private void cONTR_CDEImageComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkAgree, HotelBindingSource);
        }
        }

        private void rSTR_CDEImageComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkRstrCde, HotelBindingSource);
        }
        }

        private void rESTRICTCODETextBox_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkRestrictCode, HotelBindingSource);
        }
        }

        private void rESTRICTDESCTextBox_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkRestrictDesc, HotelBindingSource);
        }
        }

        private void aDDR1TextBox_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkAddress1, HotelBindingSource);
        }
        }

        private void aDDR2TextBox_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkAddress2, HotelBindingSource);
        }
        }

        private void aDDR3TextBox_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkAddress3, HotelBindingSource);
        }
        }

        private void cITYTextEdit_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkTown, HotelBindingSource);
        }
        }

        private void zIPTextBox_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkZip, HotelBindingSource);
        }
        }

        private void lOCAL_PHONETextBox_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkLocalPhone, HotelBindingSource);
        }
        }

        private void lOCAL_NAMETextEdit_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkLocalName, HotelBindingSource);
        }
        }

        private void aIR_MITextEdit_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkAirMiles, HotelBindingSource);
        }
        }


        private void cITY_MITextEdit_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkCityMiles, HotelBindingSource);
        }
        }

        private void lATITUDETextBox_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkLat, HotelBindingSource);
        }
        }

        private void lONGITUDETextBox_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkLong, HotelBindingSource);
        }
        }

        private void gEN_MGRTextBox_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkGenMgr, HotelBindingSource);
        }
        }

        private void pHONETextBox_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkPhone, HotelBindingSource);
        }
        }

        private void mAILFAXImageComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkMailFax, HotelBindingSource);
        }
        }

        private void tourfaxEmailFormatComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkTourFaxEmail, HotelBindingSource);
        }
        }

        private void tELEXTextBox_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkFax, HotelBindingSource);
        }
        }

        private void rES_EMAILTextBox_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkEmail, HotelBindingSource);
        }
        }

        private void dEP_RQSpinEdit_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkDeposit, HotelBindingSource);
        }
        }

        private void rATE_BASISImageComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkRateBasis, HotelBindingSource);
        }
        }

        private void cANC_PERSpinEdit_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkCancel, HotelBindingSource);
        }
        }

        private void cHECK_INTextBox_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkTime, HotelBindingSource);
        }
        }

        private void cHILD_DESCTextBox_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkChildren, HotelBindingSource);
        }
        }

        private void dEF_ROOMComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkDefRoom, HotelBindingSource);
        }
        }

        private void cRED_CARDSTextBox_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkCreditCards, HotelBindingSource);
        }
        }

        private void mAX_SGLSpinEdit_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkMaxSgl, HotelBindingSource);
        }
        }

        private void mAX_DBLSpinEdit_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkMaxDbl, HotelBindingSource);
        }
        }

        private void mAX_TPLSpinEdit_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkMaxTpl, HotelBindingSource);
        }
        }

        private void mAX_QUASpinEdit_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkMaxQua, HotelBindingSource);
        }
        }

        private void mAX_OTHSpinEdit_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkMaxOth, HotelBindingSource);
        }
        }

        private void vOUCH_DAYS_PRIORSpinEdit_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkVouchDays, HotelBindingSource);
        }
        }

        private void nO_RMSSpinEdit_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkNoRooms, HotelBindingSource);
        }
        }

        private void nO_RESTSpinEdit_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkNoRests, HotelBindingSource);
        }
        }

        private void nO_LOUNGESSpinEdit_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkNoLounges, HotelBindingSource);
        }
        }

        private void rOOM_DESCTextBox_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkRoomDesc, HotelBindingSource);
        }
        }

        private void cOMMENT1TextBox_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkComment1, HotelBindingSource);
        }
        }

        private void cOMMENT2TextBox_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkComment2, HotelBindingSource);
        }
        }

        private void aRTextBox_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkAr, HotelBindingSource);
        }
        }

        private void aPTextBox_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkAp, HotelBindingSource);
        }
        }

        private void bILLACCTTextBox_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkBillAct, HotelBindingSource);
        }
        }

        private void tAXRATESpinEdit_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkTaxRate, HotelBindingSource);
        }
        }

        private void rOOMTAXSpinEdit_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkRoomTax, HotelBindingSource);
        }
        }

        private void pERSONTAXSpinEdit_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkPersonTax, HotelBindingSource);
        }
        }

        private void aP_MGRTextBox_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkApManager, HotelBindingSource);
        }
        }

        private void aP_EMAILTextBox_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkApEmail, HotelBindingSource);
        }
        }

        private void due_DaysTextEdit_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkDueDays, HotelBindingSource);
        }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DateTime? date;
            if (dateComm.Text == "")
            {
                date = null;
            }
            else
            {
                date = Convert.ToDateTime(dateComm.Text);
            }
            string agency = string.Empty;
            string source = string.Empty;
            if (string.IsNullOrWhiteSpace(ImageComboBoxEditAgentComm.Text))
                agency = ImageComboBoxEditAgency.Text;
            else
                agency = ImageComboBoxEditAgentComm.Text;
            
            if (string.IsNullOrWhiteSpace(ComboBoxEditSource.Text))
                source = "ALL";
            else
                source = ComboBoxEditSource.Text;

            UpdateCommMarkupGrid(agency, date, source);
        }

        private void dateComm_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void dateComm_TextChanged(object sender, EventArgs e)
        {
            dateComm.Text = validCheck.convertDate(dateComm.Text);
        }

        private void aDMINCLOSEDCheckEdit_Modified(object sender, EventArgs e)
        {
            labelControl4.Text = DateTime.Today.ToShortDateString();
            labelControl5.Text = username;
        }

        private void UpdateCommMarkupGrid(string Agency, DateTime? TheDate, string Source)
        {
            if (TheDate != null)
            {
                myCommRecs = (from rec in context.COMPROD2
                              where (rec.TYPE == "HTL") && (rec.Inactive == false) && ((rec.START_DATE <= TheDate) && (rec.END_DATE >= TheDate))
                              select rec).ToList<IComprod2>();
                myCommRecsAgy = (from rec in context.COMPROD2
                                 where (rec.TYPE == "AGY") && (rec.Inactive == false) && ((rec.START_DATE <= TheDate) && (rec.END_DATE >= TheDate))
                                 select rec).ToList<IComprod2>();
            }
            else
            {
                myCommRecs = (from rec in context.COMPROD2
                              where (rec.TYPE == "HTL") && (rec.Inactive == false)
                              select rec).ToList<IComprod2>();
                myCommRecsAgy = (from rec in context.COMPROD2
                                 where (rec.TYPE == "AGY") && (rec.Inactive == false)
                                 select rec).ToList<IComprod2>();
            }

            myCommLvl = (from rec in context.CommLevel select rec).ToList<ICommLevel>();
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
                IList<FlexCommissions.Commission> commQuery1 = new List<FlexCommissions.Commission>();
                IList<FlexCommissions.Commission> commQuery2 = new List<FlexCommissions.Commission>();
                commQuery1 = FlexCommissions.Commissions.GetProductCommissions(context2, "C", TextEditCode.Text.TrimEnd(), "HTL", myCommRecs, myCommLvl, null, TheDate, null, null, Agency, Source);
                commQuery2 = FlexCommissions.Commissions.GetAgencyCommissions(context2, "C", myCommRecsAgy, myCommLvl, Agency, TheDate, null, null, Source);
                IList<FlexCommissions.Commission> mergedList = (commQuery1.Union(commQuery2)).ToList();
                gridControl6.DataSource = mergedList;
                commQuery1 = FlexCommissions.Commissions.GetProductCommissions(context2, "M", TextEditCode.Text.TrimEnd(), "HTL", myCommRecs, myCommLvl, null, TheDate, null, null, Agency, Source);
                commQuery2 = FlexCommissions.Commissions.GetAgencyCommissions(context2, "M", myCommRecsAgy, myCommLvl, Agency, TheDate, null, null, Source);
                mergedList = (commQuery1.Union(commQuery2)).ToList();
                gridControl5.DataSource = mergedList;
            }
        }

        private void HotelGenInfo_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter && GridViewHotels.IsFilterRow(GridViewHotels.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewHotels.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewHotels.GetFocusedDisplayText()))
                value = GridViewHotels.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.NAME like '{0}%'", GridViewHotels.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "NAME"));
                var special = context.HOTEL.Where(query);

                if (!string.IsNullOrWhiteSpace(GridViewHotels.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE")))
                {
                    query = String.Format("it.{0} like '{1}%'", "CODE", GridViewHotels.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                    special = special.Where(query);
                }
                int count = special.Count();
                if (count > 0)
                {
                    HotelBindingSource.DataSource = special;
                    GridViewHotels.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                    GridViewHotels.FocusedRowHandle = 0;
                    GridViewHotels.FocusedColumn.FieldName = colName;
                    GridViewHotels.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewHotels.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }
        

        private void ImageComboBoxEditRating_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkRating, HotelBindingSource);
        }
        }

        private void ImageComboBoxEditType_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkType, HotelBindingSource);
        }
        }

        private void imageComboBoxEditArea_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkArea, HotelBindingSource);
        }
        }

        private void imageComboBoxEditAlternates1_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkAlternate1, HotelBindingSource);
        }
        }

        private void imageComboBoxEditAlternates2_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkAlternate2, HotelBindingSource);
        }
        }

        private void imageComboBoxEditAlternates3_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkAlternate3, HotelBindingSource);
        }
        }

        private void ImageComboBoxEditAgency_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkAgreeAgy, HotelBindingSource);
        }
        }

        private void ImageComboBoxEditState_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkState, HotelBindingSource);
        }
        }

        private void ImageComboBoxEditRegion_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkRegion, HotelBindingSource);
        }
        }

        private void ImageComboBoxEditCountry_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkCountry, HotelBindingSource);
        }
        }

        private void ImageComboBoxEditAirport_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkAirport, HotelBindingSource);
        }
        }

        private void ImageComboBoxEditCityCode_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkCity, HotelBindingSource);
        }
        }

        private void ImageComboBoxEditDefCat_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkDefCat, HotelBindingSource);
        }
        }

        private void ImageComboBoxEditChain_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkChain, HotelBindingSource);
        }
        }

        private void ImageComboBoxEditBrand_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkBrand, HotelBindingSource);
        }
        }

        private void ImageComboBoxEditOper_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkOperator, HotelBindingSource);
            if (!string.IsNullOrWhiteSpace(ImageComboBoxEditOper.EditValue.ToString()))
            {
                string oper = ImageComboBoxEditOper.EditValue.ToString();
                var values = (from operRec in context.OPERATOR where operRec.CODE == oper select new { operRec.AP, operRec.Due_Days }).First();
                aPTextBox.Text = values.AP;
                due_DaysTextEdit.Text = values.Due_Days.ToString();
            }
        }
        }

        private void ImageComboBoxEditMgmt_Leave(object sender, EventArgs e)
        {
            if (HotelBindingSource.Current != null)
            {
            if (currentVal != ((Control)sender).Text)
            {
                Modified = true;
            }
            validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkMgmtCo, HotelBindingSource);
        }
        }

        private void ButtonAddRow_Click(object sender, EventArgs e)
        {
            if (newRowRec == false)
            {
                if (GridViewDetail.RowCount == 0)
                {
                    DetailBindingSource.DataSource = from c in context.DETAIL where c.CODE == "KJM9" select c;                   
                    newRowRec = true;
                    GridViewDetail.AddNewRow();
                    GridViewDetail.SetFocusedRowCellValue("LINK_TABLE", "HOTEL");
                    GridViewDetail.SetFocusedRowCellValue("RECTYPE", "HTLCLASS");
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
                GridViewDetail.SetFocusedRowCellValue("LINK_TABLE", "HOTEL");
                GridViewDetail.SetFocusedRowCellValue("RECTYPE", "HTLCLASS");
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

        private void DelRow_Click(object sender, EventArgs e)
        {
            int handle = GridViewDetail.FocusedRowHandle;
            GridViewDetail.DeleteRow(handle);
            DetailBindingSource.EndEdit();
            context.SaveChanges();
            newRowRec = false;
            Modified = false;
        }

        private void ButtonSaveChanges_Click(object sender, EventArgs e)
        {
            GridViewDetail.FocusedColumn = GridViewDetail.Columns["RECTYPE"];
            if (GridViewDetail.UpdateCurrentRow())
            {
                DetailBindingSource.EndEdit();
                SaveRecord();
                newRowRec = false;
                Modified = false;
            }
        }

        private void ButtonAddRowContact_Click(object sender, EventArgs e)
        {
            if (contactNewRowRec == false)
            {
                if (GridViewAdditionalContacts.RowCount == 0)
                {
                    contactNewRowRec = true;
                    firstLoad = true;
                    GridViewAdditionalContacts.AddNewRow();
                    GridViewAdditionalContacts.SetFocusedRowCellValue("ID", int.MaxValue);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("LINK_TABLE", "HOTEL");
                    GridViewAdditionalContacts.SetFocusedRowCellValue("LINK_VALUE", TextEditCode.Text);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("ACTIVE", 1);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("ADDRESS1", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("ADDRESS2", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("ADDRESS3", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("CITY", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("STATE", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("ZIP", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("GMACCTNO", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("GMRECID", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("DEPT_HEAD", false);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("COUNTRY", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("USER_DEC1", 0);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("USER_DEC2", 0);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("USER_INT1", 0);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("USER_INT2", 0);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("USER_TXT1", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("USER_TXT2", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("USER_TXT3", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("USER_TXT4", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("LOGIN_NAME", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("PASSWORD", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("LOGIN_ROLE", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("LOGIN_ACTIVE", false);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("RECTYPE", "HTLCONTACT");
                    GridViewAdditionalContacts.SetFocusedRowCellValue("PARENT_ID", 0);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("TITLE", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("DEAR", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("PHONE", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("FAX", string.Empty);
                    Modified = true;
                    return;
                }
                contactNewRowRec = true;
                firstLoad = true;
                GridViewAdditionalContacts.MoveLast();
                GridViewAdditionalContacts.AddNewRow();
                GridViewAdditionalContacts.SetFocusedRowCellValue("ID", int.MaxValue);
                GridViewAdditionalContacts.SetFocusedRowCellValue("LINK_TABLE", "HOTEL");
                GridViewAdditionalContacts.SetFocusedRowCellValue("LINK_VALUE", TextEditCode.Text);
                GridViewAdditionalContacts.SetFocusedRowCellValue("ACTIVE", 1);
                GridViewAdditionalContacts.SetFocusedRowCellValue("ADDRESS1", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("ADDRESS2", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("ADDRESS3", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("CITY", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("STATE", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("ZIP", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("GMACCTNO", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("GMRECID", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("DEPT_HEAD", false);
                GridViewAdditionalContacts.SetFocusedRowCellValue("COUNTRY", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("USER_DEC1", 0);
                GridViewAdditionalContacts.SetFocusedRowCellValue("USER_DEC2", 0);
                GridViewAdditionalContacts.SetFocusedRowCellValue("USER_INT1", 0);
                GridViewAdditionalContacts.SetFocusedRowCellValue("USER_INT2", 0);
                GridViewAdditionalContacts.SetFocusedRowCellValue("USER_TXT1", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("USER_TXT2", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("USER_TXT3", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("USER_TXT4", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("LOGIN_NAME", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("PASSWORD", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("LOGIN_ROLE", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("LOGIN_ACTIVE", false);
                GridViewAdditionalContacts.SetFocusedRowCellValue("RECTYPE", "HTLCONTACT");
                GridViewAdditionalContacts.SetFocusedRowCellValue("PARENT_ID", 0);
                GridViewAdditionalContacts.SetFocusedRowCellValue("TITLE", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("DEAR", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("PHONE", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("FAX", string.Empty);
                Modified = true;
            }
            else
                MessageBox.Show("Please save current record before attempting to add another.");
        }

        private void ButtonDelRowContact_Click(object sender, EventArgs e)
        {
            int handle = GridViewAdditionalContacts.FocusedRowHandle;
            GridViewAdditionalContacts.DeleteRow(handle);
            ContactBindingSource.EndEdit();
            context.SaveChanges();
            contactNewRowRec = false;
            Modified = false;
        }

        private void ButtonContactSave_Click(object sender, EventArgs e)
        {
            GridViewAdditionalContacts.FocusedColumn = GridViewAdditionalContacts.Columns["RECTYPE"];
            if (GridViewAdditionalContacts.UpdateCurrentRow())
            {
                ContactBindingSource.EndEdit();
                SaveRecord();
                contactNewRowRec = false;
                Modified = false;
            }
        }

        private void GridViewAdditionalContacts_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "RptContact" && e.IsGetData)
            {
                CONTACT conRec = (CONTACT)e.Row;
                int id = conRec.ID;
                string load = String.Empty;
                if (id == int.MaxValue)
                {
                    if (firstLoad == true)
                    {
                        var values = from rec in context.RPTTYPE where rec.RecipientType == "Hotel" select new { rec.CODE };
                        foreach (var result in values)
                        {
                            if (!string.IsNullOrWhiteSpace(load))
                                load += "," + result.CODE;
                            else
                                load += result.CODE;
                        }
                        globalRptType = load;
                        firstLoad = false;
                    }
                    else
                    {
                        load = globalRptType;
                    }
                }
                else
                {
                    var val = from rec in context.RptContact where rec.Contact_ID == id && rec.Code == TextEditCode.Text select new { rec.RptType };
                    foreach (var result in val)
                    {
                        if (!string.IsNullOrWhiteSpace(load))
                            load += "," + result.RptType;
                        else
                            load += result.RptType;
                    }
                }
                e.Value = load;
            }
            if (e.Column.FieldName == "RptContact" && e.IsSetData)
            {
                CONTACT conRec = (CONTACT)e.Row;
                int id = conRec.ID;
                if (id == int.MaxValue)
                {
                    globalRptType = e.Value.ToString();
                    Modified = true;
                }
                else
                {
                    string value = e.Value.ToString();
                    var results = from rptRec in context.RptContact where !value.Contains(rptRec.RptType) && rptRec.Code == TextEditCode.Text && rptRec.Contact_ID == id select rptRec;
                    foreach (var result in results)
                    {
                        context.RptContact.DeleteObject(result);
                    }
                    var val1 = (from rptRec in context.RPTTYPE
                                where value.Contains(rptRec.CODE)
                                select new { rptRec.CODE });
                    foreach (var result1 in val1)
                    {
                        if ((from rptCont in context.RptContact where rptCont.Contact_ID == id && rptCont.Code == TextEditCode.Text && rptCont.RptType == result1.CODE select new { rptCont.Code }).Count() == 0)
                        {
                            RptContact lol = new RptContact();
                            lol.Code = TextEditCode.Text;
                            lol.RptType = result1.CODE;
                            lol.Contact_ID = id;
                            context.RptContact.AddObject(lol);
                        }
                    }
                    context.SaveChanges();
                }
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            DoRowDoubleClick(view, pt);
        }

        private void repositoryItemPopupContainerEditRptType_QueryResultValue(object sender, QueryResultValueEventArgs e)
        {
            e.Value += "," + (gridViewPopup.GetRowCellValue(gridViewPopup.FocusedRowHandle, "CODE").ToString());
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            popupContainerControl1.OwnerEdit.ClosePopup();
        }

        private void DoRowDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                popupContainerControl1.OwnerEdit.ClosePopup();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            popupContainerControl1.OwnerEdit.CancelPopup();
        }

        private void MappingAddButton_Click(object sender, EventArgs e)
        {
            if (_selectedRecord != null) {
                SupplierProduct product = new SupplierProduct();
                product.Product_Code_Internal = TextEditCode.Text;
                product.Product_Type = "HTL";
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
                context.SupplierProduct.DeleteObject(suppProd);
                BindSupplierProducts();
                Modified = true;
            }
        }

        void BindSupplierProducts()
        {
            gridControlSupplierProduct.DataSource = bindingSourceSupplierProduct;
            gridControlSupplierProduct.RefreshDataSource();
        }

        private void GridViewAdditionalContacts_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void GridViewAdditionalContacts_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            CONTACT record = (CONTACT)e.Row;
            if (record.COMM_PREF == "E" && string.IsNullOrWhiteSpace(record.EMAIL))
            {
                e.Valid = false;
                view.SetColumnError(view.Columns["EMAIL"], "Email value must be filled out if preferred communication is selected as email.");
            }
            else if (record.COMM_PREF == "F" && string.IsNullOrWhiteSpace(record.FAX))
            {
                e.Valid = false;
                view.SetColumnError(view.Columns["FAX"], "Fax value must be filled out if preferred communication is selected as fax.");
            }
            else
                view.ClearColumnErrors();

        }

        private void cONTR_CDEImageComboBoxEdit_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBoxEdit box = (ComboBoxEdit)sender;
            string value = box.EditValue.ToString();
            if (value == "C" || value == "P")
                ImageComboBoxEditAgency.Properties.ReadOnly = false;
            else
                ImageComboBoxEditAgency.Properties.ReadOnly = true;
            if (string.IsNullOrWhiteSpace(value))
                ImageComboBoxEditAgency.EditValue = string.Empty;
        }

        private void rSTR_CDEImageComboBoxEdit_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBoxEdit box = (ComboBoxEdit)sender;
            string value = box.EditValue.ToString();
            if (value == "A")
                ImageComboBoxEditAgency.Properties.ReadOnly = false;
            else
            {
                 
                ImageComboBoxEditAgency.Properties.ReadOnly = true;
                ImageComboBoxEditAgency.EditValue = string.Empty;
            }
        }

        private void GridViewAdditionalContacts_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            if (!GridViewAdditionalContacts.IsFilterRow(e.RowHandle))
            {
                Modified = true;
            }
        }

        private void HotelGenInfo_Load(object sender, EventArgs e)
        {
            xtraTabPage1.Focus();
            xtraTabPage2.Focus();
            xtraTabPage3.Focus();
            xtraTabPage4.Focus();
            xtraTabPage5.Focus();
            xtraTabPage6.Focus();
            xtraTabPage7.Focus();
            xtraTabPage8.Focus();
            xtraTabPage9.Focus();
            xtraTabPage10.Focus();
            xtraTabPageSupplierHotels.Focus();
            xtraTabPageSupplierRoomTypes.Focus();
         

            // TODO: This line of code loads data into the 'chineseHosts_FlextourDataSet.SupplierHotelRoomType' table. You can move, or remove it, as needed.
            //this.supplierHotelRoomTypeTableAdapter.Fill(this.ChineseHosts_FlextourDataSet.SupplierHotelRoomType);
            // TODO: This line of code loads data into the 'chineseHosts_FlextourDataSet.SupplierHotelRoomType' table. You can move, or remove it, as needed.
            //this.supplierHotelRoomTypeTableAdapter.Fill(this.chineseHosts_FlextourDataSet.SupplierHotelRoomType);
            //// TODO: This line of code loads data into the 'chineseHosts_FlextourDataSet.SupplierHotelRoomType' table. You can move, or remove it, as needed.
            //this.supplierHotelRatePlanTableAdapter1.Fill(this.chineseHosts_FlextourDataSet.SupplierHotelRatePlan);
        }

        private void gridView1_FocusedRowLoaded(object sender, RowEventArgs e)
        {
          
        }

        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
			//SupplierHotelRoomType row = (SupplierHotelRoomType) GridViewSuppRoomType.GetFocusedRow();
			//if (row != null)
			//{

			//	supplierHotelRatePlanBindingSource.DataSource = from supRec in context.SupplierHotelRatePlan where supRec.SupplierHotelRoomType_Id == row.Id select supRec;
			//	//MessageBox.Show("Hello world 2");

			//}
			//else
			//	supplierHotelRatePlanBindingSource.DataSource = null;
        }

        private void simpleButtonRoomTypeAdd_Click(object sender, EventArgs e)
        {
            if (roomTypNewRec == false)
            {
				roomTypNewRec = true;
				roomTypenewRowHandle = GridViewSuppRoomType.RowCount;
                GridViewSuppRoomType.AddNewRow();
				GridViewSuppRoomType.SetRowCellValue(roomTypenewRowHandle, "Inactive", false);
				GridViewSuppRoomType.SetRowCellValue(roomTypenewRowHandle, "Id", int.MaxValue);
				GridViewSuppRoomType.SetRowCellValue(roomTypenewRowHandle, "Product_Code", TextEditCode.Text);
                GridViewSuppRoomType.SetRowCellValue(roomTypenewRowHandle, "Product_Type", "HTL");

                Modified = true;
                return;
            }
            else
                MessageBox.Show("Please save current record before attempting to add another.");
        }

        private void simpleButtonRoomTypeDel_Click(object sender, EventArgs e)
        {
            int handle = GridViewSuppRoomType.FocusedRowHandle;
			var roomType = (SupplierCategory)GridViewSuppRoomType.GetRow(handle);
            //add code to delete from rate plan grid
            if (GridViewSuppRatePlan.RowCount > 0)
            {
                for (i = 0; i < GridViewSuppRatePlan.RowCount; i++)
                {
					var ratePlan = (SupplierRatePlan)GridViewSuppRatePlan.GetRow(i);
					if (ratePlan.SupplierCategory_Id == roomType.Id) {
						GridViewSuppRatePlan.DeleteRow(i);
					}
                }
            }           
            GridViewSuppRoomType.DeleteRow(handle);
            supplierHotelRoomTypeBindingSource.EndEdit();
            context.SaveChanges();
            roomTypNewRec = false;
            Modified = false;
        }

        private void simpleButtonRatePlanAdd_Click(object sender, EventArgs e)
        {
            SupplierCategory rec = (SupplierCategory) GridViewSuppRoomType.GetFocusedRow();

            ratePlanNewRec = true;
            newRowHandle = GridViewSuppRatePlan.RowCount;
            GridViewSuppRatePlan.AddNewRow();
            GridViewSuppRatePlan.SetRowCellValue(newRowHandle, "Inactive", false);
			GridViewSuppRatePlan.SetRowCellValue(newRowHandle, "Product_Code", TextEditCode.Text);
            GridViewSuppRatePlan.SetRowCellValue(newRowHandle, "Product_Type", "HTL");
            if (rec != null)
				GridViewSuppRatePlan.SetFocusedRowCellValue("SupplierCategory_Id", rec.Id);
                       
            Modified = true;
            return;
    }

        private void simpleButtonRatePlanDel_Click(object sender, EventArgs e)
        {
            int handle = GridViewSuppRatePlan.FocusedRowHandle;
            GridViewSuppRatePlan.DeleteRow(handle);
            supplierHotelRatePlanBindingSource.EndEdit();
            context.SaveChanges();
            ratePlanNewRec = false;
            Modified = false;
        }

        private void aDMINCLOSEDCheckEdit_Click(object sender, EventArgs e)
        {
            Modified = true;
        }

        private void repositoryItemPopupContainerEdit1_QueryResultValue(object sender, QueryResultValueEventArgs e)
        {
            GridViewDetail.SetFocusedRowCellValue("NOTE", GridViewLookup.GetRowCellValue(GridViewLookup.FocusedRowHandle, "DESC").ToString());       
            e.Value = GridViewLookup.GetRowCellValue(GridViewLookup.FocusedRowHandle, "CODE").ToString();
          
        }

        private void LookupButtonOk_Click(object sender, EventArgs e)
        {
            popupContainerControlLookup.OwnerEdit.ClosePopup();
        }

        private void LookupButtonCancel_Click(object sender, EventArgs e)
        {
            popupContainerControlLookup.OwnerEdit.CancelPopup();
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
            if (info.InRow || info.InRowCell)
            {
                popupContainerControlLookup.OwnerEdit.ClosePopup();
            }
        }

        private void GridViewDetail_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            Modified = true;
        }

		private void GridViewSuppRoomType_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			Modified = true;
		}

		private void GridViewSuppRatePlan_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			Modified = true;
		}

		private void checkEditProximitySearch_CheckedChanged(object sender, EventArgs e)
		{
			spinEditDistance.Enabled = (checkEditProximitySearch.Checked);
			if (!checkEditProximitySearch.Checked)
				spinEditDistance.Value = 0;
		}

		private void checkEditProximitySearch_Leave(object sender, EventArgs e)
		{
			if (HotelBindingSource.Current != null) {
				if (currentVal != ((Control)sender).Text.ToString())
					Modified = true;
			}
		}

		private void spinEditDistance_Leave(object sender, EventArgs e)
		{
			if (HotelBindingSource.Current != null) {
				if (currentVal != ((Control)sender).Text.ToString())
					Modified = true;
				validCheck.check(sender, ErrorProvider, ((HOTEL)HotelBindingSource.Current).checkDistance, HotelBindingSource);
			}
		}

		private void checkEditProximitySearch_Click(object sender, EventArgs e)
		{
			Modified = true;
		}

        private void checkEditVendorPrepayReqd_Click(object sender, EventArgs e)
        {
            Modified = true;
        }

        private void checkEditPreTaxRatesOnAdvice_Click(object sender, EventArgs e)
        {
            Modified = true;
        }

        private void checkEditAccountingServiceItem_Click(object sender, EventArgs e)
        {
            Modified = true;
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

        private void GridViewSuppRoomType_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column == colRoomTypeMappingSupplier) {
                e.RepositoryItem = _supplierCombo;
            }
            else if (e.Column == colRoomTypeMappingRoomcod) {
                e.RepositoryItem = _catCombo;
            }

        }

        private void BarButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //test comment
            GridViewHotels.ClearColumnsFilter();
            GridControlAdditionalContacts.DataSource = null;
            GridControlCustom.DataSource = null;
            gridControlSupplierProduct.DataSource = null;
            supplierHotelRoomTypeBindingSource.DataSource = null;
            supplierHotelRatePlanBindingSource.DataSource = null;
            if (HotelBindingSource.Current == null) {
                HotelBindingSource.DataSource = from opt in context.HOTEL where opt.CODE == "KJM9" select opt;
                HotelBindingSource.AddNew();
                if (GridViewHotels.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewHotels.FocusedRowHandle = GridViewHotels.RowCount - 1;
                TextEditCode.Focus();
                setReadOnly(false);
                newRec = true;
                setCheckEdits();
                return;
            }
            TextEditCode.Focus();
            //bindingNavigatorPositionItem.Focus();
            GridViewHotels.CloseEditor();
            temp = newRec;
            if (checkForms()) {
                ErrorProvider.Clear();
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (HOTEL)HotelBindingSource.Current);
                HotelBindingSource.AddNew();
                if (GridViewHotels.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewHotels.FocusedRowHandle = GridViewHotels.RowCount - 1;
                TextEditCode.Focus();
                setReadOnly(false);
                newRec = true;
                setCheckEdits();
            }
        }

        private void BarButtonItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (HotelBindingSource.Current == null)
                return;
            GridViewHotels.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes) {

                IEnumerable<CONTACT> contactRecs = from contact in context.CONTACT where contact.LINK_VALUE == TextEditCode.Text select contact;
                foreach (CONTACT rec in contactRecs)
                    context.DeleteObject(rec);

                IEnumerable<RptContact> rptContactRecs = from contact in context.RptContact where contact.Code == TextEditCode.Text select contact;
                foreach (RptContact rec in rptContactRecs)
                    context.DeleteObject(rec);


                Modified = false;
                newRec = false;
                HotelBindingSource.RemoveCurrent();
                ErrorProvider.Clear();
                context.SaveChanges();
                setReadOnly(true);
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);
            }
            currentVal = TextEditCode.Text;
            TextEditCode.Focus();
        }

        private void BarButtonItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveRecord();
        }

        private void SaveRecord()
        {
            //HOTEL current = (HOTEL)HotelBindingSource.Current;
            //if (current.GeoCode_ID == null)
            //    current.GeoCode_ID = 0;
            TextEditCode.Focus();
            int? contactID = 0, roomTypeID = 0;
            if (HotelBindingSource.Current == null)
                return;
            HOTEL hotel = (HOTEL)HotelBindingSource.Current;
            if (string.IsNullOrEmpty(hotel.ACT_CITY)) {
                hotel.ACT_CITY = null;
            }
            GridViewHotels.CloseEditor();
            if (GridViewAdditionalContacts.RowCount > 0)
                contactID = (int?)GridViewAdditionalContacts.GetFocusedRowCellValue("ID");

            if (GridViewSuppRoomType.RowCount > 0)
                roomTypeID = (int?)GridViewSuppRoomType.GetRowCellValue(roomTypenewRowHandle, "Id");

            if (gridViewSupplierProduct.UpdateCurrentRow()) {
                bindingSourceSupplierProduct.EndEdit();
            }

            bool temp = newRec;
            if (checkForms()) {
                ErrorProvider.Clear();
                setReadOnly(true);
                if ((contactID ?? int.MaxValue) == int.MaxValue) {
                    int newID = (int)GridViewAdditionalContacts.GetFocusedRowCellValue("ID");
                    var values1 = from rec in context.RPTTYPE where rec.RecipientType == "Hotel" select new { rec.CODE };
                    foreach (var result in values1) {
                        if (globalRptType.Contains(result.CODE)) {
                            RptContact lol = new RptContact();
                            lol.Code = TextEditCode.Text;
                            lol.RptType = result.CODE;
                            lol.Contact_ID = newID;
                            context.RptContact.AddObject(lol);
                        }
                    }
                    globalRptType = string.Empty;
                    context.SaveChanges();
                    contactNewRowRec = false;
                }

                if ((roomTypeID ?? int.MaxValue) == int.MaxValue) {
                    int newID = (int)GridViewSuppRoomType.GetRowCellValue(roomTypenewRowHandle, "Id");
                    for (int i = 0; i < GridViewSuppRatePlan.RowCount; i++) {
                        int ratePlanID = (int)GridViewSuppRatePlan.GetRowCellValue(i, "SupplierCategory_Id");
                        if (ratePlanID == int.MaxValue)
                            GridViewSuppRatePlan.SetRowCellValue(i, "SupplierCategory_Id", newID);
                    }

                    context.SaveChanges();
                }
                roomTypenewRowHandle = 0;
                contactNewRowRec = false;
                newRowRec = false;
                ratePlanNewRec = false;
                roomTypNewRec = false;
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
                LoadRoomTypeLookup(TextEditCode.Text);
            }

            if (!temp && !_modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (HOTEL)HotelBindingSource.Current);
        }

        private void BarButtonItemUpdateWebsite_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string reportType = string.Join(",", _sys.Settings.MainMediaReport, _sys.Settings.WarningMediaReport);
            _context.usp_RefreshSingleProduct("HTL", TextEditCode.Text, reportType, _sys.Settings.FeaturedMediaSection,
                _sys.Settings.MainMediaReport, _sys.Settings.MainMediaSection);
            panelControlStatus.Visible = true;
            LabelStatus.Text = "Website Updated";
            rowStatusSave = new Timer();
            rowStatusSave.Interval = 3000;
            rowStatusSave.Start();
            rowStatusSave.Tick += TimedEventSave;
        }
    }
}

