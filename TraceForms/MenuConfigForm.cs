using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraEditors;
using FlexModel;
using System.Runtime.InteropServices;
namespace TraceForms
{
    
	public partial class MenuConfigForm: DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        public string username;
        const string colName = "colCODE";
        public FlextourEntities context;
        public FlexCore.CoreSys _FlexSys;
        public DevExpress.XtraBars.Ribbon.RibbonControl ribbon1;
        public DevExpress.XtraBars.Ribbon.RibbonPage page1;
        public DevExpress.XtraBars.Ribbon.RibbonPageGroup group1;
        public DevExpress.XtraBars.BarButtonItem button1;
        public DevExpress.XtraBars.PopupMenu buttonDrop;
        DevExpress.XtraBars.BarButtonItem button;

        public MenuConfigForm(FlexCore.CoreSys _sys)
        {
            InitializeComponent();
            Connection.EFConnectionString = _sys.Settings.EFConnectionString;
            context = new FlextourEntities(_sys.Settings.EFConnectionString);
            username = _sys.User.Name;
            //menuItemBindingSource.DataSource = context.MenuItem;
            _FlexSys = _sys;
            var results = context.MenuItem;
            var result = results.OrderBy(c => c.ParentID);
            foreach (var ed in result)
            {  
                if(ed.Name == "ribbonControl")
                    createRibControl();

                if (ed.Type == "XtraBars.Ribbon.RibbonPage")
                    createRibPage(ed.Caption);

                if(ed.Type == "XtraBars.Ribbon.RibbonPageGroup")
                    createRibPageGroup(ed.Caption, ed.ID);
            }  
         
            ribbon1.Pages.Add(page1);
        }
        void createRibControl()
        {
            ribbon1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            Controls.Add(ribbon1);          

        }

        void createRibPage(string el)
        {
            page1 = new DevExpress.XtraBars.Ribbon.RibbonPage(el);
        }

        void createRibPageGroup(string el, int load)
        {            
            group1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup(el);
            var drop = from c in context.MenuItem
                       where c.ParentID == load && c.Visible == true
                       select new { c.ID, c.Caption, c.DropDown, c.Position };
           
            foreach (var button in drop)
            {
                createDropDownButton(button.Caption, button.ID);
            }

            page1.Groups.Add(group1);
        }

        void createDropDownButton(string el, int load)
        {
            buttonDrop = new DevExpress.XtraBars.PopupMenu();
            button1 = ribbon1.Items.CreateButton(el);
            button1.ActAsDropDown = true;
            button1.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            button1.CausesValidation = true;
            button1.DropDownControl = buttonDrop;
            var buttons = from c in context.MenuItem
                          where c.ParentID == load && c.Visible == true
                          select new { c.ID, c.Caption, c.DropDown, c.Position };
            foreach (var butt in buttons)
            {
                createButton(butt.ID);
            }
            group1.ItemLinks.Add(button1);
        }

        void createButton(int load)
        {
            var values = from c in context.MenuItem
                         where c.ParentID == load && c.Visible == true
                         select new { c.ID, c.Caption, c.DropDown, c.Position };
            foreach (var please in values)
            {
                if (please.Position == 1)
                {
                  
                    if ((from c in context.MenuItemSecurity where c.UserID == username && c.MenuItem_ID == please.ID select c).Count() == 0)
                    {
                        button = ribbon1.Items.CreateButton(please.Caption);
                        itemClickAssign(button);
                        buttonDrop.ItemLinks.Add(button, true);
                    }
                }
                else
                {
                    
                    if ((from c in context.MenuItemSecurity where c.UserID == username && c.MenuItem_ID == please.ID select c).Count() == 0)
                    {
                        button = ribbon1.Items.CreateButton(please.Caption);
                        itemClickAssign(button);
                        buttonDrop.ItemLinks.Add(button);
                    }
                }
            }
        }

        void itemClickAssign(DevExpress.XtraBars.BarButtonItem button2)
        {
            switch (button2.Caption)
            {
                case "Hotel General Information":
                    button2.ItemClick += barButtonHotelGenInfo_ItemClick;
                    break;
                case "Hotel Room Categories":
                    button2.ItemClick += barButtonRoomCode_ItemClick;
                    break;        
                case "Hotel Ratings":
                    button2.ItemClick += barButtonHotelRatings_ItemClick;
                    break;
                case "Hotel Type/Location":
                    button2.ItemClick += barButtonHotelType_ItemClick;
                    break;
                case "Hotel Chains":
                    button2.ItemClick += barButtonHotelChain_ItemClick;
                    break;
                case "Hotel Brands":
                    button2.ItemClick += barButtonHotelBrand_ItemClick;
                    break;
                case "Hotel Rate Sheet Information":
                    button2.ItemClick += barButtonHotelRateMaint_ItemClick;
                    break;
                case "Hotel Rate Sheet Utilities":
                    button2.ItemClick += barButtonHotelRateUtil_ItemClick;
                    break;
                case "Package General Information":
                    button2.ItemClick += barButtonPkgGenInfo_ItemClick;
                    break;
                case "Package Component Maintenance":
                    button2.ItemClick += barButtonPkgComp_ItemClick;
                    break;
                case "Package Component Utilities":
                    button2.ItemClick += barButtonPkgCompUtil_ItemClick;
                    break;
                case "Package Itinerary Maintenance":
                    button2.ItemClick += barButtonPkgItinMaint_ItemClick;
                    break;
                case "Package Itinerary Utilities":
                    button2.ItemClick += barButtonPackItinUtil_ItemClick;
                    break;
                case "Package Type":
                    button2.ItemClick += barButtonPackType_ItemClick;
                    break;
                case "Package Rate Maintenance":
                    button2.ItemClick += barButtonPkgRateMaint_ItemClick;
                    break;
                case "Package Rate Utilities":
                    button2.ItemClick += barButtonPackRateUtil_ItemClick;
                    break;
                case "Group Rate Maintenance":
                    button2.ItemClick += barButtonGroup_ItemClick;
                    break;
                case "Group Rate Utilities":
                    button2.ItemClick += barButtonGroupRateUtil_ItemClick;
                    break;
                case "Other Services General Information":
                    button2.ItemClick += barButtonOtherServ_ItemClick;
                    break;
                case "Other Service Rate Maintenance":
                    button2.ItemClick += barButtonOtherServMaint_ItemClick;
                    break;
                case "Pickups/Dropoffs":
                    button2.ItemClick += barButtonBusTable_ItemClick;
                    break;
                case "Booking Combinations":
                    button2.ItemClick += barButtonBookCombo_ItemClick;
                    break;
                case "Service Types":
                    button2.ItemClick += barButtonServType_ItemClick;
                    break;
                case "Car Rental Companies":
                    button2.ItemClick += barButtonCarInfo_ItemClick;
                    break;
                case "Car Rental Rate Maintenance":
                    button2.ItemClick += barButtonCarRateMaint_ItemClick;
                    break;
                case "Car Rental Offices":
                    button2.ItemClick += barButtonCarOff_ItemClick;
                    break;
                case "Airlines":
                    button2.ItemClick += barButtonAirlines_ItemClick;
                    break;
                case "Airline Office":
                    button2.ItemClick += barButtonAirOff_ItemClick;
                    break;
                case "Air Segment Rate Maintenance":
                    button2.ItemClick += barButtonAirSeg_ItemClick;
                    break;
                case "Air Segment Rate Utilities":
                    button2.ItemClick += barButtonAirSegUtil_ItemClick;
                    break;
                case "Cruise Ship":
                    button.ItemClick += barButtonCruise_ItemClick_1;
                    break;
                case "Cruise Rate Maintenance":
                    button2.ItemClick += barButtonCruRate_ItemClick;
                    break;
                case "Cruise Item":
                    button2.ItemClick += barButtonCruItem_ItemClick;
                    break;
                case "Cruise Rate Utilities":
                    button2.ItemClick += barButtonCruRateUtil_ItemClick;
                    break;
                case "Cruise Itinerary Maintenance":
                    button2.ItemClick += barButtonCruItinMaint_ItemClick;
                    break;
                case "Insurance Rate Maintenance":
                    button2.ItemClick += barButtonInsuranRate_ItemClick;
                    break;
                case "Agency General Information":
                    button2.ItemClick += barButtonAgy_ItemClick;
                    break;
                case "Consortium":
                    button2.ItemClick += barButtonConsrt_ItemClick;
                    break;
                case "Service Restriction Levels":
                    button2.ItemClick += barButtonSvcLevels_ItemClick;
                    break;
                case "New Service Restrictions":
                    button2.ItemClick += barButtonSvcRests_ItemClick;
                    break;
                case "New Commissions Maintenance":
                    button2.ItemClick += barButtonComprod_ItemClick;
                    break;
                case "Commission Levels":
                    button2.ItemClick += barButtonCommLevel_ItemClick;
                    break;
                case "Cancellation Fees":
                    button2.ItemClick += barButtonCancFees_ItemClick;
                    break;
                case "Company File":
                    button2.ItemClick += barButtonSysfile_ItemClick;
                    break;
                case "Inventory Maintenance":
                    button2.ItemClick += barButtonInventMaint_ItemClick;
                    break;
                case "Inventory Inquiry by Agency":
                    button2.ItemClick += barButtonInvInq_ItemClick;
                    break;
                case "Inventory Reconciliation":
                    button2.ItemClick += barButtonInvtRec_ItemClick;
                    break;
                case "Inventory Utilities":
                    button2.ItemClick += barButtonInvtUtil_ItemClick;
                    break;
                case "Inventory Change":
                    button2.ItemClick += barButtonInvtChange_ItemClick;
                    break;
                case "City Codes":
                    button2.ItemClick += barButtonCityCode_ItemClick;
                    break;
                case "Region":
                    button2.ItemClick += barButtonRegion_ItemClick;
                    break;
                case "State": 
                    button2.ItemClick += barButtonState_ItemClick;
                    break;
                case "Country Codes":
                    button2.ItemClick += barButtonCountry_ItemClick;
                    break;
                case "Language Codes":
                    button2.ItemClick += barButtonLanguage_ItemClick;
                    break;
                case "Waypoints":
                    button2.ItemClick += barButtonWaypoint_ItemClick;
                    break;
                case "Airport": 
                    button2.ItemClick += barButtonAirport_ItemClick;
                    break;
                case "Seaport":
                    button2.ItemClick += barButtonSeaport_ItemClick;
                    break;
                case "Bus Station":
                    button2.ItemClick += barButtonBusStation_ItemClick;
                    break;
                case "Train Stations":
                    button2.ItemClick += barButtonTStation_ItemClick;
                    break;
                case "Companies":
                    button2.ItemClick += barButtonCompanies_ItemClick;
                    break;
                case "Currency":
                    button2.ItemClick += barButtonCurrency_ItemClick;
                    break;
                case "Meal Codes":
                    button2.ItemClick += barButtonMealCode_ItemClick;
                    break;
                case "Operator codes":
                    button2.ItemClick += barButtonOperator_ItemClick;
                    break;
                case "Payment Codes":
                    button2.ItemClick += barButtonPmtCode_ItemClick;
                    break;
                case "Res History Change Codes":
                    button2.ItemClick += barButtonChgCodes_ItemClick;
                    break;
                case "Digest Header":
                    button2.ItemClick += barButtonDigHdr_ItemClick;
                    break;
                case "Special Value Codes":
                    button2.ItemClick += barButtonSpecValCodes_ItemClick;
                    break;
                case "Custom Fields":
                    button2.ItemClick += barButtonUserfields_ItemClick;
                    break;
                case "Custom Lookup":
                    button2.ItemClick += barButtonLookup_ItemClick;
                    break;
                case "User Roles":
                    button2.ItemClick += barButtonRoles_ItemClick;
                    break;
                case "Report Types":
                    button2.ItemClick += barButtonRptType_ItemClick_1;
                    break;
                case "Amenities":
                    button2.ItemClick += barButtonAmenities_ItemClick;
                    break;
                case "Amenity Service Assignment":
                    button2.ItemClick += barButtonAmenAssign_ItemClick;
                    break;
                case "Media Information":
                    button2.ItemClick += barButtonMediaInfo_ItemClick;
                    break;
                case "Media Report Utilities":
                    button2.ItemClick += barButtonMediaRptUtil_ItemClick;
                    break;
                case "Media Reports":
                    button2.ItemClick += barButtonMediaRpts_ItemClick;
                    break;          
                case "Menu Configuration":
                    button2.ItemClick += barButtonMenuConfig_ItemClick;
                    break;
                case "Menu Adjustments":
                    button2.ItemClick += barButtonMenuAdjust_ItemClick;
                    break;

            }

        }     

        private void barButtonBusStation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BusStationForm xform1 = new BusStationForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonCompanies_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CompanyForm xform1 = new CompanyForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonServType_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ServTypeForm xform1 = new ServTypeForm(_FlexSys) { };
            xform1.Show();
        }


        private void barButtonHotelChain_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HtlChainForm xform1 = new HtlChainForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonCruItinMaint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CruItForm xform1 = new CruItForm(_FlexSys) { };
            xform1.Show();
        }
        private void barButtonMenuAdjust_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MenuAdjustForm xform1 = new MenuAdjustForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }
        private void barButtonMenuConfig_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MenuConfigForm xform1 = new MenuConfigForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonMediaRptUtil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MediaRptUtilityForm xform1 = new MediaRptUtilityForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonAirSegUtil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            airCopyForm xform1 = new airCopyForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonCruRateUtil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cruRateCopyForm xform1 = new cruRateCopyForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonCruRate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CratesForm xform1 = new CratesForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonGroupRateUtil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //GroupCopyForm xform1 = new GroupCopyForm(_FlexSys) { };
            //xform1.Show();
        }

        private void barButtonPackRateUtil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pratesCopyForm xform1 = new pratesCopyForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonPackItinUtil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pitinCopyForm xform1 = new pitinCopyForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonPkgComp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PCompForm xform1 = new PCompForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonPkgCompUtil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pcompCopyForm xform1 = new pcompCopyForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonInvtChange_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InvtChgForm xform1 = new InvtChgForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonInvtUtil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            invtCopyForm xform1 = new invtCopyForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonInvtRec_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InvtRecForm xform1 = new InvtRecForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonInvInq_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            invtInq2Form xform1 = new invtInq2Form(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonHotelRateUtil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            hRateCopyForm xform1 = new hRateCopyForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //GroupForm xform1 = new GroupForm(_FlexSys) { };
            //xform1.Show();
        }

        private void barButtonBookCombo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BookSelForm xform1 = new BookSelForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonCruItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cruitItemForm xform1 = new cruitItemForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonDigHdr_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DigHdrForm xform1 = new DigHdrForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonSysfile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SysfileForm xform1 = new SysfileForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonOtherServ_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CompForm xform1 = new CompForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonComprod_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommissionsForm xform1 = new CommissionsForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonCommLevel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommLevelForm xform1 = new CommLevelForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonSvcRests_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SvcRestr2Form xform1 = new SvcRestr2Form(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonSvcLevels_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SvcrLevelForm xform1 = new SvcrLevelForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonMediaRpts_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MediaRptForm xform1 = new MediaRptForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonMediaInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            mediaInfoMaint xform1 = new mediaInfoMaint(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonPkgRateMaint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PRatesForm xform1 = new PRatesForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonLookup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LookupForm xform1 = new LookupForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonUserfields_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UserFieldsForm xform1 = new UserFieldsForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonAmenAssign_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AmenAssignForm xform1 = new AmenAssignForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonAmenities_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AmenityForm xform1 = new AmenityForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonRegion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RegionForm xform1 = new RegionForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonSeaport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SeaportForm xform1 = new SeaportForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonRoles_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RoleForm xform1 = new RoleForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonPkgItinMaint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            packItinMaint xform1 = new packItinMaint(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonCurrency_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CurrencyForm xform1 = new CurrencyForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonWaypoint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            WaypointForm xform1 = new WaypointForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonState_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StateForm xform1 = new StateForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonPkgGenInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PackForm xform1 = new PackForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonInventMaint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InvtMaint xform1 = new InvtMaint(false, _FlexSys) { };
            xform1.Show();
        }

        private void barButtonBusTable_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BusTableForm xform1 = new BusTableForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonCancFees_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CxlFeeForm xform1 = new CxlFeeForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonHotelRateMaint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HRatesForm xform1 = new HRatesForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonCarRateMaint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CarRateForm xform1 = new CarRateForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonOtherServMaint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CpRatesForm xform1 = new CpRatesForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonAirport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AirportForm xform1 = new AirportForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonAirOff_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AirOffForm xform1 = new AirOffForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonAirlines_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AirForm xform1 = new AirForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonAgy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AgencyForm xform1 = new AgencyForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonAirSeg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AirSegForm xform1 = new AirSegForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonCarInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CarInfoForm xform1 = new CarInfoForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonCarOff_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CarOffForm xform1 = new CarOffForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonChgCodes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChgCodeForm xform1 = new ChgCodeForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonConsrt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ConsrtForm xform1 = new ConsrtForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonCountry_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CountryForm xform1 = new CountryForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonInsuranRate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InsuranForm xform1 = new InsuranForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonLanguage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LanguageForm xform1 = new LanguageForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonSpecValCodes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SpecialValueForm xform1 = new SpecialValueForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonOperator_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OperatorForm xform1 = new OperatorForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonPackType_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PackageTypeForm xform1 = new PackageTypeForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonHotelGenInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HotelGenInfo xform1 = new HotelGenInfo(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonCruise_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CruiseShipForm xform1 = new CruiseShipForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonRptType_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportTypeForm xform1 = new ReportTypeForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonRoomCode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RoomCategoriesForm xform1 = new RoomCategoriesForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonPmtCode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PaymentCodeForm xform1 = new PaymentCodeForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonTStation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TrainStationForm xform1 = new TrainStationForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonMealCode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MealCodeForm xform1 = new MealCodeForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonHotelType_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HtlTypeForm xform1 = new HtlTypeForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonCityCode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CityCodeForm xform1 = new CityCodeForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonHotelRatings_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HtlRatingForm xform1 = new HtlRatingForm(_FlexSys) { };
            xform1.Show();
        }

        private void barButtonHotelBrand_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HtlBrandForm xform1 = new HtlBrandForm(_FlexSys) { };
            xform1.Show();
        }
        
	}
}