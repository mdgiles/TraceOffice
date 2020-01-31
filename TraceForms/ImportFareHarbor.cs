using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Views.Grid;
using FlexModel;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using TraceForms.Models.FareHarbor;
using TraceForms.Helpers;
using FlexInterfaces.Core;
using FlexInterfaces;
using System.Data.Entity.Validation;
using System.ComponentModel;

namespace TraceForms
{
    public partial class ImportFareHarbor : XtraForm
    {
        FlextourEntities _context;
        SupplierConnection _supplierConnection;
        ICoreSys _sys;
        string[] _fullDescTitles = Configurator.FullDescMediaReportTitles.Split(';');
        string[] _termsTitles = Configurator.TermsMediaReportTitles.Split(';');
        string[] _promosTitles = Configurator.PromosMediaReportTitles.Split(';');
        string[] _departReturnTitles = Configurator.DepartReturnMediaReportTitles.Split(';');
        string[] _exclusionsTitles = Configurator.ExclusionsMediaReportTitles.Split(';');
        string[] _inclusionsTitles = Configurator.InclusionsMediaReportTitles.Split(';');
        string[] _otherInfoTitles = Configurator.OtherInfoMediaReportTitles.Split(';');
        string[] _presalesTitles = Configurator.PresalesMediaReportTitles.Split(';');
        string[] _itineraryTitles = Configurator.ItineraryMediaReportTitles.Split(';');
        DateTime _update = DateTime.Now;
        const string _prefix = "FH";
        BackgroundWorker _bgWorker = new BackgroundWorker();

        public ImportFareHarbor(FlexInterfaces.Core.ICoreSys sys)
        {
            try {
                InitializeComponent();
                Connect(sys);
                LoadLookups();
                _bgWorker.DoWork += _bgWorker_DoWork;
                _bgWorker.RunWorkerCompleted += _bgWorker_RunWorkerCompleted;
                _bgWorker.ProgressChanged += _bgWorker_ProgressChanged;
                _bgWorker.WorkerSupportsCancellation = true;
                _bgWorker.WorkerReportsProgress = true;
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

        private async void LoadLookups()
        {
            var supplier = _context.Supplier.SingleOrDefault(s => s.EnumValue == (int)FlexInterfaces.Enumerations.FlexExternalSuppliers.FareHarbor);
            if(supplier == null) {
                this.DisplayError("The supplier was not found.");
            }
            else {
                var guid = supplier.GUID;
                _supplierConnection = _context.SupplierConnection.FirstOrDefault(s => s.Supplier_GUID == guid);
                var rq = new CommonRQ();
                var companies = await GetDataFromAPI<Company>(typeof(CompaniesRS), _supplierConnection, "companies/", rq);
                imageComboBoxEditCompanies.Properties.Items.Add(new ImageComboBoxItem());
                imageComboBoxEditCompanies.Properties.Items.AddRange(
                    companies.Select(c => new ImageComboBoxItem() { Description = c.Name, Value = c.Shortname }).ToArray());
            }

            var lookup = new List<CodeName> {
                new CodeName(null)
            };
            lookup.AddRange(_context.CITYCOD
                            .OrderBy(o => o.CODE)
                            .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }));
            searchLookUpEditCity.Properties.DataSource = lookup;

            lookup = new List<CodeName> {
                new CodeName(null)
            };
            lookup.AddRange(_context.SERVTYPE
                            .OrderBy(o => o.TYPE)
                            .Select(s => new CodeName() { Code = s.TYPE, Name = s.DESCRIP }));
            searchLookUpEditServiceType.Properties.DataSource = lookup;
        }

        private async Task<List<T>> GetDataFromAPI<T>(Type type, SupplierConnection connection, string url, CommonRQ request)
        {
            Dictionary<string, string> headers = new Dictionary<string, string> {
                { "X-FareHarbor-API-App", connection.Login },
                { "X-FareHarbor-API-User", connection.Secret },
            };
            List<T> list = new List<T>();
           
            //convert strongly typed class to dictionary of request parameters
            Dictionary<string, string> parameters = request.AsDictionary();
            string result = await ApiInvoker.SendRequestGet(connection.URL + url, parameters, headers);
            var rs = JsonConvert.DeserializeObject(result, type);       //Deserialize the data as the provided type
            CommonRS common = (CommonRS)rs;     //We know all returned data can be cast to this basic type
            var data = common.GetData<T>();     //Get the actual list of results as generic type
            list.AddRange(data);
            return list;
        }

        private async void imageComboBoxEditCompanies_EditValueChanged(object sender, EventArgs e)
        {
            bindingSourceItems.DataSource = null;
            if (imageComboBoxEditCompanies.EditValue != null) {
                this.Cursor = Cursors.WaitCursor;
                string company = imageComboBoxEditCompanies.EditValue.ToString();
                var rq = new ItemsRQ() { detailed = "yes" };
                var items = await GetDataFromAPI<Item>(typeof(ItemsRS), _supplierConnection, $"companies/{company}/items/", rq);
                //Check if items are already imported
                foreach (var item in items) {
                    string pk = item.Pk.ToString();
                    var mapping = _context.SupplierProduct.FirstOrDefault(sp => sp.ProductCodeSupplier == pk 
                      && sp.Supplier_GUID == _supplierConnection.Supplier_GUID);
                    if (mapping != null) {
                        item.InternalCode = mapping.Product_Code_Internal;
                    }
                }
                bindingSourceItems.DataSource = items;
                this.Cursor = Cursors.Default;
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

        private void SetControlState(bool enabled)
        {
            imageComboBoxEditCompanies.Enabled = enabled;
            gridControlItems.Enabled = enabled;
            searchLookUpEditCity.Enabled = enabled;
            searchLookUpEditServiceType.Enabled = enabled;
            simpleButtonImport.Enabled = enabled;
        }

        private void simpleButtonImport_Click(object sender, EventArgs e)
        {
            if (bindingSourceItems.DataSource != null && bindingSourceItems.List.Count > 0) {
                var items = (List<Item>)bindingSourceItems.List;
                if (items.Any(i => i.Selected && string.IsNullOrEmpty(i.InternalCode))) {
                    if (searchLookUpEditCity.EditValue == null) {
                        this.DisplayError("Please select a valid city for the new products to be imported");
                        return;
                    }
                    if (searchLookUpEditServiceType.EditValue == null) {
                        this.DisplayError("Please select a valid service type for the new products to be imported");
                        return;
                    }
                }

                this.Cursor = Cursors.WaitCursor;
                SetControlState(false);
                marqueeProgressBarControl1.Show();
                _bgWorker.RunWorkerAsync();
            }
        }

        private void _bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //NOTE: There cannot be async/await in the worker methods, because "await" releases the thread 
            //which makes the worker think it has finished
            BackgroundWorker worker = sender as BackgroundWorker;
            foreach (var row in bindingSourceItems.List) {
                if (worker.CancellationPending)
                    return;

                var item = (Item)row;
                if (item.Selected) {
                    worker.ReportProgress(0, $"Importing {item.Name}...");
                    ImportProduct(item, worker);
                }
            }
            worker.ReportProgress(0, "Done");
            e.Result = true;        //if you don't set e.Result to something, RunWorkerCompleted event is never called
        }

        private void ImportProduct(Item item, BackgroundWorker worker)
        {
            try {
                //Set up the main COMP record
                bool productAddedOrNameChanged = false;
                var comp = _context.COMP.FirstOrDefault(c => c.CODE == item.InternalCode);
                if (comp == null) {
                    productAddedOrNameChanged = true;
                    comp = new COMP() {
                        CODE = item.InternalCode,
                        RSTR_CDE = "O",
                        Inactive = "N",
                        AdminClosed = false,
                        PickupInfoRequired = false,
                        DropoffInfoRequired = false,
                        VendorPrepayReqd = false,
                        AccountingServiceItem = true,
                        MealsIncluded = false,
                        RATE_BASIS = "D",
                        ProximitySearch = false,
                        WeightRequired = false,
                        DOBRequired = false,
                        Allow_Freesell = true,
                        Multiple_Times = "0",
                        SERV_TYPE = searchLookUpEditServiceType.EditValue.ToString(),
                        CITY = searchLookUpEditCity.EditValue.ToString()
                    };
                    _context.COMP.AddObject(comp);
                    SupplierProduct suppProd = new SupplierProduct() {
                        Product_Type = "OPT",
                        Product_Code_Internal = item.InternalCode,
                        ProductCodeSupplier = item.Pk.ToString(),
                        Supplier_GUID = _supplierConnection.Supplier_GUID,
                        Inactive = false,
                        SupplierCommPct = spinEditCommPct.Value,
                        SupplierCommFlat = spinEditCommFlat.Value
                    };
                    suppProd.COMP = comp;
                    _context.SupplierProduct.AddObject(suppProd);
                }
                else {
                    if (comp.AdminClosed || comp.Inactive == "Y")
                        return;
                }
                if (comp.NAME != item.Name) {
                    productAddedOrNameChanged = true;
                }
                comp.NAME = item.Name;
                if (item.Is_pickup_ever_available) {
                    comp.PUDRP_REQ = "P";
                    comp.TRSFR_TYP = "O";
                }
                else {
                    comp.TRSFR_TYP = "N";
                }
                //Other location types seem to be "pre", "start", "end"
                //TODO: Each location can also have notes, which are rarely provided and often duplicate other information
                //Should the location notes be stored somewhere?
                //There is also an item.Location property which holds the whole address as a single string
                var mainLocation = item.Locations.FirstOrDefault(l => l.Type == "primary");
                if (mainLocation == null) {
                    mainLocation = item.Locations.FirstOrDefault();
                }
                if (mainLocation != null) {
                    var address = mainLocation.Address;
                    comp.ADDR1 = address.Street;
                    comp.COUNTRY = address.Country;
                    comp.ZIP = address.Postal_code;
                    comp.STATE = address.Province;
                    comp.TOWN = address.City;
                    var geo = comp.GeoCode;
                    if (geo == null) {
                        geo = new GeoCode();
                        _context.GeoCode.AddObject(geo);
                        comp.GeoCode = geo;
                    }
                    geo.AgentInitials = _sys.User.Name;
                    geo.PushLat = mainLocation.Latitude;
                    geo.PushLong = mainLocation.Longitude;
                }

                if (Configurator.ImportCancellationPolicies) {
                    //Cancellation policy has a type field which so far is only ever "hours-before-start"
                    int daysPrior = (int)Math.Ceiling(item.Effective_cancellation_policy.Cutoff_hours_before / 24) + (_supplierConnection.ExtraNightsPriorForCxlPolicy ?? 0);
                    FindOrAddCxlfee(_sys, _context, comp.CODE, daysPrior, 100);
                }

                //Set up the media information
                MEDIAINFO mainInfo = MediaHelper.CheckAndCreateNewMediaInfo(_context, _sys.Settings.MainMediaSection, item.Name,
                    "OPT", comp.CODE, string.Empty, "ENG", Configurator.CreateNewInfoAsInHouse, null);

                List<string> texts = new List<string>();
                if (!string.IsNullOrEmpty(item.Headline)) {
                    texts.Add(item.Headline);
                }
                if (!string.IsNullOrEmpty(item.Description_text)) {
                    texts.Add(item.Description_text);
                }
                if (!string.IsNullOrEmpty(item.Description_safe_html)) {
                    texts.Add(item.Description_safe_html);
                }
                string.Join("<br/><br/>", texts);
                mainInfo.TEXT = item.Headline + item.Description_text + item.Description_safe_html;
                string imagePath = MediaHelper.GetOrPutImage(_sys, "OPT", comp.CODE, _prefix, comp.CITY, item.Image_cdn_url, string.Empty, false);
                mainInfo.IMAGE1 = imagePath;
                imagePath = MediaHelper.GetOrPutImage(_sys, "OPT", comp.CODE, _prefix, comp.CITY, item.Image_cdn_url, "thumb_", true);
                mainInfo.IMAGE4 = imagePath;

                //Some companies have booking notes that are clearly intended for after making a booking because they say
                //"Thank you for your booking". Others have useful info about what to bring and what to expect. We can't tell the difference
                //so just always use the booking notes
                MEDIAINFO fullInfo = MediaHelper.CheckAndCreateNewMediaInfo(_context, Configurator.FullDescMediaReportSection, _fullDescTitles[0],
                    "OPT", comp.CODE, string.Empty, "ENG", Configurator.CreateNewInfoAsInHouse, null);
                fullInfo.TEXT = CreateBulletList(item.Description_bullets) + item.Booking_notes_safe_html;

                MEDIAINFO termsInfo = new MEDIAINFO();
                if (!string.IsNullOrEmpty(item.Cancellation_policy_safe_html)) {
                    termsInfo = MediaHelper.CheckAndCreateNewMediaInfo(_context, Configurator.TermsMediaReportSection, _termsTitles[0],
                        "OPT", comp.CODE, string.Empty, "ENG", Configurator.CreateNewInfoAsInHouse, null);
                    termsInfo.TEXT = item.Cancellation_policy_safe_html;
                }

                //Download the images and attach to the main media section
                List<RESOURCE> resources = new List<RESOURCE>();
                if (Configurator.DownloadImages) {
                    foreach (var image in item.Images) {
                        imagePath = MediaHelper.GetOrPutImage(_sys, "OPT", comp.CODE, _prefix, comp.CITY, image.Image_cdn_url, string.Empty, false);
                        MediaHelper.CheckAndAddResource(_context, resources, mainInfo, imagePath, string.Empty, "1");       //1=medium res
                    }
                }

                var rptGeninfo = MediaHelper.CheckAndCreateNewMediaRpt(_context, _sys.Settings.MainMediaReport, "OPT", comp.CODE,
                    "ENG", null);
                var rptVoucher = MediaHelper.CheckAndCreateNewMediaRpt(_context, Configurator.VoucherMediaReportType, "OPT", comp.CODE,
                    "ENG", null);

                if ((!string.IsNullOrEmpty(mainInfo.TEXT) || resources.Count > 0)) {
                    MediaHelper.CheckAndAddInfoToReports(_context, new MEDIARPT[] { rptGeninfo, rptVoucher }, mainInfo, 0);
                    if (mainInfo.ID == 0) {
                        _context.MEDIAINFO.AddObject(mainInfo);
                    }
                }
                if (!string.IsNullOrEmpty(fullInfo.TEXT)) {
                    MediaHelper.CheckAndAddInfoToReports(_context, new MEDIARPT[] { rptGeninfo }, fullInfo, 1);
                    if (fullInfo.ID == 0) {
                        _context.MEDIAINFO.AddObject(fullInfo);
                    }
                }
                if (!string.IsNullOrEmpty(termsInfo.TEXT)) {
                    MediaHelper.CheckAndAddInfoToReports(_context, new MEDIARPT[] { rptGeninfo, rptVoucher }, termsInfo, 2);
                    if (termsInfo.ID == 0) {
                        _context.MEDIAINFO.AddObject(termsInfo);
                    }
                }
                if (rptGeninfo.ID == 0 && rptGeninfo.MediaRptItem.Count > 0) {
                    _context.MEDIARPT.AddObject(rptGeninfo);
                }
                if (rptVoucher.ID == 0 && rptVoucher.MediaRptItem.Count > 0) {
                    _context.MEDIARPT.AddObject(rptVoucher);
                }

                List<MEDIAINFO> infos = new List<MEDIAINFO>() { mainInfo, fullInfo, termsInfo };
                MediaHelper.SetMediaInfosChgDate(_context, infos, _update);
                MediaHelper.SetServiceChgDate(_context, comp, _update, _sys.User.Name);

                _context.SaveChanges();
                if (productAddedOrNameChanged) {
                    AccountingAPI.InvokeForProduct(_sys.Settings.TourAccountingURL, "OPT", comp.CODE);
                }

                //Update the image resources with the id of the linked media section
                if (resources.Count > 0) {
                    foreach (var resource in resources) {
                        resource.LINK_VALUE = mainInfo.ID.ToString();
                        _context.RESOURCE.AddObject(resource);
                    }
                    _context.SaveChanges();
                }

                try {
                    worker.ReportProgress(0, $"Updating website for {item.Name}");
                    _context.usp_RefreshSingleProduct("OPT", comp.CODE, _sys.Settings.MainMediaReport, _sys.Settings.FeaturedMediaSection,
                        _sys.Settings.MainMediaReport, _sys.Settings.MainMediaSection);
                }
                catch {
                    NLog.LogManager.GetCurrentClassLogger().Trace(" Refresh Product Failed");
                }
            }
            catch (DbEntityValidationException ex) {
                string details = string.Join(Environment.NewLine, ex.EntityValidationErrors.Select(e =>
                    string.Join(Environment.NewLine, e.ValidationErrors.Select(v =>
                    string.Format("{0} - {1}", v.PropertyName, v.ErrorMessage)))));
                details += Environment.NewLine;
                NLog.LogManager.GetCurrentClassLogger().Error(ex, details);
                System.Diagnostics.Debugger.Break();
            }
            catch (Exception ex) {
                NLog.LogManager.GetCurrentClassLogger().Error(ex);
                System.Diagnostics.Debugger.Break();
            }
        }

        string CreateBulletList(List<string> lines)
        {
            if (lines.Any()) {
                StringBuilder list = new StringBuilder("<ul>");
                foreach (string line in lines) {
                    list.Append($"<li>{line}</li>");
                }
                list.Append("</ul>");
                list.Append("<br/>");
                return list.ToString();
            }
            else {
                return string.Empty;
            }
        }

        void FindOrAddCxlfee(ICoreSys sys, FlextourEntities context, string code, int ntsPrior, decimal pctPenalty)
        {
            CXLFEE cxlFee = context.CXLFEE.FirstOrDefault(c => c.TYPE == "OPT" && c.CODE == code && c.CAT == null && c.START_DATE == null
                && c.END_DATE == null && c.AGENCY == sys.Settings.DefaultAgency);
            if (cxlFee == null) {
                cxlFee = new CXLFEE() {
                    TYPE = "OPT",
                    CODE = code,
                    CAT = null,
                    START_DATE = null,
                    END_DATE = null,
                    AGENCY = sys.Settings.DefaultAgency,
                };
                context.CXLFEE.AddObject(cxlFee);
            }
            cxlFee.NTS_PRIOR = (short)ntsPrior;
            cxlFee.Description = null;
            cxlFee.NonRefundable = (ntsPrior == 999) || pctPenalty == 100;
            cxlFee.PCT_AMT = (float)pctPenalty;
            cxlFee.FLAT_FEE = null;
            cxlFee.NBR_NTS = null;
            cxlFee.TimeBasis = (short)Enumerations.FlexCancelFeeTimeBasis.flxCancelFeeTimeBasisBeforeArrival;
            cxlFee.TimeUnits = (short)Enumerations.FlexTimeUnits.flxTimeUnitsDays;
            MediaHelper.SetCxlfeeChgDate(context, cxlFee, _update, _sys.User.Name);
        }

        private void _bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Default;
            SetControlState(true);
            marqueeProgressBarControl1.Hide();
            if (e.Cancelled) {
                return;
            }
            else if (e.Error != null) {
                this.DisplayError(e.Error);
            }
            else {
                this.DisplayInfo("Import completed");
            }
        }

        private void _bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            marqueeProgressBarControl1.Text = e.UserState.ToString();
        }

        private void ImportFareHarbor_FormClosing(object sender, FormClosingEventArgs e)
        {
            _bgWorker.CancelAsync();
        }
    }
}
