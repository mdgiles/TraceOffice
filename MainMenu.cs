using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using System.Linq;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using TraceForms;
using FlexModel;
using System.Reflection;
namespace FlexOffice
{
    public partial class MainMenu : RibbonForm
    {
        public string username;
        public FlextourEntities context;
        public FlexCore.CoreSys _FlexSys;
        public DevExpress.XtraBars.Ribbon.RibbonControl ribbon1 = new RibbonControl();
        public DevExpress.XtraBars.Ribbon.RibbonPage page1 = new RibbonPage();
        public DevExpress.XtraBars.Ribbon.RibbonPageGroup group1;
        public DevExpress.XtraBars.PopupMenu popup;
        private IEnumerable<FlexModel.MenuItem> _menus;
        private IEnumerable<FlexModel.MenuItemSecurity> _security;
        
        public MainMenu(FlexCore.CoreSys sys)
        {
            InitializeComponent();
            InitSkinGallery();
            _FlexSys = sys;

            Connection.EFConnectionString = _FlexSys.Settings.EFConnectionString;
            context = new FlextourEntities(_FlexSys.Settings.EFConnectionString);
            username = _FlexSys.User.Name;
            _menus = context.MenuItem.Where(c => (c.Visible ?? false) && c.AppName == "FlexOffice").
                OrderBy(c => c.ParentID).ThenBy(c => c.Position).ToList();
            _security = context.MenuItemSecurity.Where(c => c.UserID == username).ToList();
            var root = _menus.First(m => m.ParentID == null);

            createRibControl();
            foreach (var item in _menus.Where(m => m.ParentID == root.ID)) {
                if (!_security.Any(s => s.MenuItem_ID == item.ID)) {
                    createRibPage(item);
                }
            }

            ribbon1.Pages.Add(ribbonPageGallery);
        }

        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }

        private void iExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Exit?", "CONFIRM ACTION", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                this.Close();
            }
        }
        void createRibControl()
        {
            ribbon1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            ribbon1.RibbonStyle = RibbonControlStyle.Office2010;
            //ribbon1.ApplicationButtonAccessibleDescription = "HELP";
            //ribbon1.ApplicationButtonDropDownControl = HotelDrop;
            Ribbon = ribbon1;
            Controls.Add(ribbon1);

        }

        void createRibPage(FlexModel.MenuItem el)
        {
            page1 = new DevExpress.XtraBars.Ribbon.RibbonPage(el.Caption);
            ribbon1.Pages.Add(page1);
            foreach (var item in _menus.Where(m => m.ParentID == el.ID)) {
                if (!_security.Any(s => s.MenuItem_ID == item.ID)) {
                    createRibPageGroup(item);
                }
            }
        }

        void createRibPageGroup(FlexModel.MenuItem el)
        {
            group1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup(el.Caption);
            group1.ShowCaptionButton = false;
            foreach (var item in _menus.Where(m => m.ParentID == el.ID)) {
                if (!_security.Any(s => s.MenuItem_ID == item.ID)) {
                    createDropDownButton(item);
                }
            }
            page1.Groups.Add(group1);
        }

        void createDropDownButton(FlexModel.MenuItem el)
        {
            popup = new DevExpress.XtraBars.PopupMenu();
            var menu = ribbon1.Items.CreateButton(el.Caption);
            menu.ActAsDropDown = true;
            menu.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            menu.CausesValidation = true;
            foreach (var item in _menus.Where(m => m.ParentID == el.ID)) {
                if (!_security.Any(s => s.MenuItem_ID == item.ID)) {
                    createButton(item);
                }
            }
            menu.DropDownControl = popup;
            group1.ItemLinks.Add(menu);
        }

        void createButton(FlexModel.MenuItem el)
        {
            foreach (var item in _menus.Where(m => m.ParentID == el.ID)) {
                if (!_security.Any(s => s.MenuItem_ID == item.ID)) {
                    var button = ribbon1.Items.CreateButton(item.Caption);
                    itemClickAssign(button, item.FormName);
                    popup.ItemLinks.Add(button);
                }
            }
        }

        private void DisplayError(Exception ex)
        {
            string error = ex.Message;
            if (ex.InnerException != null) {
                error = error.Replace("See the inner exception for details.", string.Empty);
                error += Environment.NewLine + ex.InnerException.Message;
            }
            MessageBox.Show(this, error, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void itemClickAssign(DevExpress.XtraBars.BarButtonItem button2, string formName)
        {
            //TODO - switch this to use formName not Caption
            switch (button2.Caption) {
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
                case "Hotel Rate Sheet Maintenance":
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
                    button2.ItemClick += barButtonCruise_ItemClick_1;
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
                case "Currencies":
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
                case "Voucher Generation":
                    button2.ItemClick += barButtonVouchGen_ItemClick;
                    break;
                case "Voucher Utilities":
                    button2.ItemClick += barButtonVouchUtil_ItemClick;
                    break;
                case "Car Rate Utilities":
                    button2.ItemClick += barButtonItemCarRateCopy_ItemClick;
                    break;
                case "Car Rate Copy by Region":
                    button2.ItemClick += barButtonItemCarRateRegCopy_ItemClick;
                    break;
                case "Other Service Rate Utilities":
                    button2.ItemClick += barButtonOtherServRateUtil_ItemClick;
                    break;
                case "Pickup / Dropoff Times Utilities":
                    button2.ItemClick += barButtonBusTableCopy_ItemClick;
                    break;
                case "Insurance Rate Utilities":
                    button2.ItemClick += barButtonInsuranRateCopy_ItemClick;
                    break;
                case "Cancellation Fee Utilities":
                    button2.ItemClick += barButtonCancFeesCopy_ItemClick;
                    break;
                case "Departments":
                    button2.ItemClick += barButtonDept_ItemClick;
                    break;
                case "Svc Restrictions by Agency":
                    button2.ItemClick += barButtonItemSvcRestr_ItemClick;
                    break;
                case "Inventory Build":
                    button2.ItemClick += BarButtonItemInvBuild_ItemClick;
                    break;
                case "Extranet Security":
                    button2.ItemClick += BarButtonExtranetSecurity_ItemClick;
                    break;
                case "Bus Routes":
                    button2.ItemClick += BarButtonRouteForm_ItemClick;
                    break;
                case "Related Products":
                    button2.ItemClick += BarButtonRelatedProductsForm_ItemClick;
                    break;
                case "Bus General Information":
                    button2.ItemClick += BarButtonBusForm_ItemClick;
                    break;
				case "Bus Manifest":
					button2.ItemClick += BarButtonBusAssignmentForm_ItemClick;
					break;
                case "Import MGM Rates":
                    button2.ItemClick += BarButtonMGMRatesImportForm_ItemClick;
                    break;
                case "Hotel Production Report":
                    button2.ItemClick += HotelProductionReportForm_ItemClick;
                    break;
                case "Operations Service List":
                    button2.ItemClick += OperationsServiceListForm_ItemClick;
                    break;
                case "Product List":
                    button2.ItemClick += ProductListForm_ItemClick;
                    break;

            }
            //
        }
        private void barButtonVouchUtil_ItemClick(object sender, ItemClickEventArgs e)
        {
            VouchUtilityForm xform1 = new VouchUtilityForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonVouchGen_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void barButtonBusStation_ItemClick(object sender, ItemClickEventArgs e)
        {
            BusStationForm xform1 = new BusStationForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonCompanies_ItemClick(object sender, ItemClickEventArgs e)
        {
            CompanyForm xform1 = new CompanyForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonServType_ItemClick(object sender, ItemClickEventArgs e)
        {
            ServTypeForm xform1 = new ServTypeForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonHotelChain_ItemClick(object sender, ItemClickEventArgs e)
        {
            HtlChainForm xform1 = new HtlChainForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonCruItinMaint_ItemClick(object sender, ItemClickEventArgs e)
        {
            CruItForm xform1 = new CruItForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonMenuConfig_ItemClick(object sender, ItemClickEventArgs e)
        {
            MenuConfigForm xform1 = new MenuConfigForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonMediaRptUtil_ItemClick(object sender, ItemClickEventArgs e)
        {
            MediaRptUtilityForm xform1 = new MediaRptUtilityForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonAirSegUtil_ItemClick(object sender, ItemClickEventArgs e)
        {
            airCopyForm xform1 = new airCopyForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonCruRateUtil_ItemClick(object sender, ItemClickEventArgs e)
        {
            cruRateCopyForm xform1 = new cruRateCopyForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonCruRate_ItemClick(object sender, ItemClickEventArgs e)
        {
            CratesForm xform1 = new CratesForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonGroupRateUtil_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void barButtonPackRateUtil_ItemClick(object sender, ItemClickEventArgs e)
        {
            pratesCopyForm xform1 = new pratesCopyForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonPackItinUtil_ItemClick(object sender, ItemClickEventArgs e)
        {
            pitinCopyForm xform1 = new pitinCopyForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonPkgComp_ItemClick(object sender, ItemClickEventArgs e)
        {
            PCompForm xform1 = new PCompForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonPkgCompUtil_ItemClick(object sender, ItemClickEventArgs e)
        {
            pcompCopyForm xform1 = new pcompCopyForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonInvtChange_ItemClick(object sender, ItemClickEventArgs e)
        {
            InvtChgForm xform1 = new InvtChgForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonInvtUtil_ItemClick(object sender, ItemClickEventArgs e)
        {
            invtCopyForm xform1 = new invtCopyForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonInvtRec_ItemClick(object sender, ItemClickEventArgs e)
        {
            InvtRecForm xform1 = new InvtRecForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonInvInq_ItemClick(object sender, ItemClickEventArgs e)
        {
            invtInq2Form xform1 = new invtInq2Form(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonHotelRateUtil_ItemClick(object sender, ItemClickEventArgs e)
        {
            hRateCopyForm xform1 = new hRateCopyForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void barButtonBookCombo_ItemClick(object sender, ItemClickEventArgs e)
        {
            BookSelForm xform1 = new BookSelForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonCruItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            cruitItemForm xform1 = new cruitItemForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonDigHdr_ItemClick(object sender, ItemClickEventArgs e)
        {
            DigHdrForm xform1 = new DigHdrForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonSysfile_ItemClick(object sender, ItemClickEventArgs e)
        {
            SysfileForm xform1 = new SysfileForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonOtherServ_ItemClick(object sender, ItemClickEventArgs e)
        {
            CompForm xform1 = new CompForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonComprod_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Tried to use a function which took the type of the form as a parameter and
            //created it using Activator.CreateInstance, but wrapping that in a try/catch
            //does not catch any exception in the form constructor. If you handle it in the 
            //constructor, Activator.CreateInstance just says "Exception was thrown by the target 
            //of an invocation" and doesn't give the actual exception. Thus the forms have to 
            //be created as strongly typed in order to get any exception from
            //the constructor and show it to the user.
            try {
                CommissionsForm xform1 = new CommissionsForm(_FlexSys) { MdiParent = this };
                xform1.Show();
            }
            catch (Exception ex) {
                DisplayError(ex);
            }
        }

        private void barButtonCommLevel_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommLevelForm xform1 = new CommLevelForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonSvcRests_ItemClick(object sender, ItemClickEventArgs e)
        {
            SvcRestr2Form xform1 = new SvcRestr2Form(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonSvcLevels_ItemClick(object sender, ItemClickEventArgs e)
        {
            SvcrLevelForm xform1 = new SvcrLevelForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonMediaRpts_ItemClick(object sender, ItemClickEventArgs e)
        {
            MediaRptForm xform1 = new MediaRptForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonMediaInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
            mediaInfoMaint xform1 = new mediaInfoMaint(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonPkgRateMaint_ItemClick(object sender, ItemClickEventArgs e)
        {
            PRatesForm xform1 = new PRatesForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonLookup_ItemClick(object sender, ItemClickEventArgs e)
        {
            LookupForm xform1 = new LookupForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonUserfields_ItemClick(object sender, ItemClickEventArgs e)
        {
            UserFieldsForm xform1 = new UserFieldsForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonAmenAssign_ItemClick(object sender, ItemClickEventArgs e)
        {
            AmenAssignForm xform1 = new AmenAssignForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonAmenities_ItemClick(object sender, ItemClickEventArgs e)
        {
            AmenityForm xform1 = new AmenityForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonRegion_ItemClick(object sender, ItemClickEventArgs e)
        {
            RegionForm xform1 = new RegionForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonSeaport_ItemClick(object sender, ItemClickEventArgs e)
        {
            SeaportForm xform1 = new SeaportForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonRoles_ItemClick(object sender, ItemClickEventArgs e)
        {
            RoleForm xform1 = new RoleForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonPkgItinMaint_ItemClick(object sender, ItemClickEventArgs e)
        {
            packItinMaint xform1 = new packItinMaint(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonCurrency_ItemClick(object sender, ItemClickEventArgs e)
        {
            CurrencyForm xform1 = new CurrencyForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonWaypoint_ItemClick(object sender, ItemClickEventArgs e)
        {
            WaypointForm xform1 = new WaypointForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonState_ItemClick(object sender, ItemClickEventArgs e)
        {
            StateForm xform1 = new StateForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonPkgGenInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
            packForm xform1 = new packForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonInventMaint_ItemClick(object sender, ItemClickEventArgs e)
        {
            //XtraForm1 xform1 = new XtraForm1(_FlexSys.Settings.EFConnectionString) { MdiParent = this };
            InvtMaint xform1 = new InvtMaint(false, _FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonBusTable_ItemClick(object sender, ItemClickEventArgs e)
        {
            BusTableForm xform1 = new BusTableForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonCancFees_ItemClick(object sender, ItemClickEventArgs e)
        {
            CxlFeeForm xform1 = new CxlFeeForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonHotelRateMaint_ItemClick(object sender, ItemClickEventArgs e)
        {
            HRatesForm xform1 = new HRatesForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonCarRateMaint_ItemClick(object sender, ItemClickEventArgs e)
        {
            CarRateForm xform1 = new CarRateForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonOtherServMaint_ItemClick(object sender, ItemClickEventArgs e)
        {
            CpRatesForm xform1 = new CpRatesForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonAirport_ItemClick(object sender, ItemClickEventArgs e)
        {
            AirportForm xform1 = new AirportForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonAirOff_ItemClick(object sender, ItemClickEventArgs e)
        {
            AirOffForm xform1 = new AirOffForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonAirlines_ItemClick(object sender, ItemClickEventArgs e)
        {
            AirForm xform1 = new AirForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonAgy_ItemClick(object sender, ItemClickEventArgs e)
        {
            AgencyForm xform1 = new AgencyForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonAirSeg_ItemClick(object sender, ItemClickEventArgs e)
        {
            AirSegForm xform1 = new AirSegForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonCarInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
            CarInfoForm xform1 = new CarInfoForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonCarOff_ItemClick(object sender, ItemClickEventArgs e)
        {
            CarOffForm xform1 = new CarOffForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonChgCodes_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChgCodeForm xform1 = new ChgCodeForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonConsrt_ItemClick(object sender, ItemClickEventArgs e)
        {
            ConsrtForm xform1 = new ConsrtForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonCountry_ItemClick(object sender, ItemClickEventArgs e)
        {
            CountryForm xform1 = new CountryForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonInsuranRate_ItemClick(object sender, ItemClickEventArgs e)
        {
            InsuranForm xform1 = new InsuranForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonLanguage_ItemClick(object sender, ItemClickEventArgs e)
        {
            LanguageForm xform1 = new LanguageForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonSpecValCodes_ItemClick(object sender, ItemClickEventArgs e)
        {
            SpecialValueForm xform1 = new SpecialValueForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonOperator_ItemClick(object sender, ItemClickEventArgs e)
        {
            OperatorForm xform1 = new OperatorForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonPackType_ItemClick(object sender, ItemClickEventArgs e)
        {
            PackageTypeForm xform1 = new PackageTypeForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonHotelGenInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
            try {
                HotelGenInfo xform1 = new HotelGenInfo(_FlexSys) { MdiParent = this };
                xform1.Show();
            }
            catch(Exception ex) {
                DisplayError(ex);
            }
        }

        private void barButtonCruise_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            CruiseShipForm xform1 = new CruiseShipForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonRptType_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            ReportTypeForm xform1 = new ReportTypeForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonRoomCode_ItemClick(object sender, ItemClickEventArgs e)
        {
            RoomCategoriesForm xform1 = new RoomCategoriesForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonPmtCode_ItemClick(object sender, ItemClickEventArgs e)
        {
            PaymentCodeForm xform1 = new PaymentCodeForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonTStation_ItemClick(object sender, ItemClickEventArgs e)
        {
            TrainStationForm xform1 = new TrainStationForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonMealCode_ItemClick(object sender, ItemClickEventArgs e)
        {
            MealCodeForm xform1 = new MealCodeForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonHotelType_ItemClick(object sender, ItemClickEventArgs e)
        {
            HtlTypeForm xform1 = new HtlTypeForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonCityCode_ItemClick(object sender, ItemClickEventArgs e)
        {
            CityCodeForm xform1 = new CityCodeForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonHotelRatings_ItemClick(object sender, ItemClickEventArgs e)
        {
            HtlRatingForm xform1 = new HtlRatingForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonHotelBrand_ItemClick(object sender, ItemClickEventArgs e)
        {
            HtlBrandForm xform1 = new HtlBrandForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonMenuAdjust_ItemClick(object sender, ItemClickEventArgs e)
        {
            MenuAdjustForm xform1 = new MenuAdjustForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonItemCarRateCopy_ItemClick(object sender, ItemClickEventArgs e)
        {
            caRateCopyForm xform1 = new caRateCopyForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonItemCarRateRegCopy_ItemClick(object sender, ItemClickEventArgs e)
        {
            caRegCopyForm xform1 = new caRegCopyForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonOtherServRateUtil_ItemClick(object sender, ItemClickEventArgs e)
        {
            cpratesCopyForm xform1 = new cpratesCopyForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonBusTableCopy_ItemClick(object sender, ItemClickEventArgs e)
        {
            busTblCopyForm xform1 = new busTblCopyForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonInsuranRateCopy_ItemClick(object sender, ItemClickEventArgs e)
        {
            insuranCopyForm xform1 = new insuranCopyForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonCancFeesCopy_ItemClick(object sender, ItemClickEventArgs e)
        {
            CxlFeeCopyForm xform1 = new CxlFeeCopyForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonDept_ItemClick(object sender, ItemClickEventArgs e)
        {
            DeptForm xform1 = new DeptForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void barButtonItemSvcRestr_ItemClick(object sender, ItemClickEventArgs e)
        {
            SvcRestForm xform1 = new SvcRestForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {

            e.Cancel = false;
            this.Dispose();

        }

        private void BarButtonItemInvBuild_ItemClick(object sender, ItemClickEventArgs e)
        {
            InvtMaint xform1 = new InvtMaint(true, _FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void MainMenu_Shown(object sender, EventArgs e)
        {

        }

        private void BarButtonExtranetSecurity_ItemClick(object sender, ItemClickEventArgs e)
        {
            ExtranetSecurityForm xform1 = new ExtranetSecurityForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void BarButtonRouteForm_ItemClick(object sender, ItemClickEventArgs e)
        {
            RouteForm xform1 = new RouteForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void BarButtonRelatedProductsForm_ItemClick(object sender, ItemClickEventArgs e)
        {
            RelatedProductsForm xform1 = new RelatedProductsForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

        private void BarButtonBusForm_ItemClick(object sender, ItemClickEventArgs e)
        {
            BusForm xform1 = new BusForm(_FlexSys) { MdiParent = this };
            xform1.Show();
        }

		private void BarButtonBusAssignmentForm_ItemClick(object sender, ItemClickEventArgs e)
		{
			BusAssignmentForm xform1 = new BusAssignmentForm(_FlexSys) { MdiParent = this };
			xform1.Show();
		}

        private void BarButtonMGMRatesImportForm_ItemClick(object sender, ItemClickEventArgs e)
        {
            try {
                MGMRatesImportForm xform1 = new MGMRatesImportForm(_FlexSys) { MdiParent = this };
                xform1.Show();
            }
            catch (Exception ex) {
                DisplayError(ex);
            }
        }

        private void OperationsServiceListForm_ItemClick(object sender, ItemClickEventArgs e)
        {
            try {
                OperationsServiceListForm xform1 = new OperationsServiceListForm(_FlexSys) { MdiParent = this };
                xform1.Show();
            }
            catch (Exception ex) {
                DisplayError(ex);
            }
        }

        private void HotelProductionReportForm_ItemClick(object sender, ItemClickEventArgs e)
        {
            try {
                HotelProductionReportForm xform1 = new HotelProductionReportForm(_FlexSys) { MdiParent = this };
                xform1.Show();
            }
            catch (Exception ex) {
                DisplayError(ex);
            }
        }

        private void ProductListForm_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                ProductListForm xform1 = new ProductListForm(_FlexSys) { MdiParent = this };
                xform1.Show();
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }

    }
}
