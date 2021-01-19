using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TraceForms
{
    internal static class Configurator
    {
        internal static string HotelProductionReport_Recipients
        {
            get {
                return GetValue("HotelProductionReport_Recipients");
            }
        }

        internal static int HotelProductionReport_PastDays
        {
            get
            {
                int days;
                int.TryParse(GetValue("HotelProductionReport_PastDays"), out days);
                return days;
            }
        }

        internal static string OperationsServiceList_Recipients
        {
            get { return GetValue("OperationsServiceList_Recipients"); }
        }

        internal static string BingMapsAPIKey
        {
            get { return GetValue("BingMapsAPIKey"); }
        }

        internal static string ProductList_Recipients
        {
            get { return GetValue("ProductList_Recipients"); }
        }

        internal static int OperationsServiceList_FutureDays
        {
            get
            {
                int days;
                int.TryParse(GetValue("OperationsServiceList_FutureDays"), out days);
                return days;
            }
        }

        internal static string GetValue(string key)
        {
            //This method of opening the exe config file works when running from VB6 if the TraceOffice config file
            //is in the same folder as the TraceForms assembly (which it always should be)
            ExeConfigurationFileMap map = new ExeConfigurationFileMap { ExeConfigFilename = "TraceOffice.exe.config" };
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var setting = config.AppSettings.Settings[key];
            if (setting == null) {
                return string.Empty;
            }
            else {
                return setting.Value;
            }
        }

        internal static string InfoButtonUrl
        {
            get {
                return GetValue("InfoButtonUrl");
            }
        }

        internal static string BaseUrl
        {
            get {
                return GetValue("BaseUrl");
            }
        }

        public static string ConfigSet {
            get { return ConfigurationManager.AppSettings["ConfigSet"] ?? string.Empty; }
        }

        //public static string FeaturedMediaReportSection
        //{
        //    get { return ConfigurationManager.AppSettings["FeaturedMediaReportSection"]; }
        //}

        public static string CityStartsWith {
            get { return ConfigurationManager.AppSettings["CityStartsWith"]; }
        }

        public static string ProductStartsWith {
            get { return ConfigurationManager.AppSettings["ProductStartsWith"]; }
        }

        //      public static string MapsMediaReportSection
        //{
        //	get { return ConfigurationManager.AppSettings["MapsMediaReportSection"]; }
        //}

        //public static string WarningsMediaReportType
        //{
        //    get { return ConfigurationManager.AppSettings["WarningsMediaReportType"]; }
        //}

        public static string VoucherMediaReportType {
            get { return ConfigurationManager.AppSettings["VoucherMediaReportType"]; }
        }

        //public static string MainMediaReportType
        //{
        //    get { return ConfigurationManager.AppSettings["MainMediaReportType"]; }
        //}

        //public static string MainMediaReportSection
        //{
        //    get { return ConfigurationManager.AppSettings["MainMediaReportSection"]; }
        //}

        public static string Suppliers {
            get { return ConfigurationManager.AppSettings["Suppliers"]; }
        }

        public static string Cultures {
            get { return ConfigurationManager.AppSettings["Cultures"]; }
        }

        public static string PhotosPath {
            get { return ConfigurationManager.AppSettings["PhotosPath"]; }
        }

        public static string PromosMediaReportSection {
            get { return ConfigurationManager.AppSettings["PromosMediaReportSection"]; }
        }

        public static string TermsMediaReportSection {
            get { return ConfigurationManager.AppSettings["TermsMediaReportSection"]; }
        }

        public static string HealthMediaReportSection {
            get { return ConfigurationManager.AppSettings["HealthMediaReportSection"]; }
        }

        public static string PresalesMediaReportSection {
            get { return ConfigurationManager.AppSettings["PresalesMediaReportSection"]; }
        }

        public static string FullDescMediaReportSection {
            get { return ConfigurationManager.AppSettings["FullDescMediaReportSection"]; }
        }

        public static string FacilitiesMediaReportSection {
            get { return ConfigurationManager.AppSettings["FacilitiesMediaReportSection"]; }
        }

        public static string RenovationsMediaReportSection {
            get { return ConfigurationManager.AppSettings["RenovationsMediaReportSection"]; }
        }

        public static string FullDescMediaReportTitles {
            get { return ConfigurationManager.AppSettings["FullDescMediaReportTitles"]; }
        }

        public static string TermsMediaReportTitles {
            get { return ConfigurationManager.AppSettings["TermsMediaReportTitles"]; }
        }

        public static string HealthMediaReportTitles {
            get { return ConfigurationManager.AppSettings["HealthMediaReportTitles"]; }
        }

        public static string PromosMediaReportTitles {
            get { return ConfigurationManager.AppSettings["PromosMediaReportTitles"]; }
        }

        public static string FacilitiesMediaReportTitles {
            get { return ConfigurationManager.AppSettings["FacilitiesMediaReportTitles"]; }
        }

        public static string RenovationsMediaReportTitles {
            get { return ConfigurationManager.AppSettings["RenovationsMediaReportTitles"]; }
        }

        public static string PresalesMediaReportTitles {
            get { return ConfigurationManager.AppSettings["PresalesMediaReportTitles"]; }
        }

        public static string InclusionsMediaReportTitles {
            get { return ConfigurationManager.AppSettings["InclusionsMediaReportTitles"]; }
        }

        public static string ExclusionsMediaReportTitles {
            get { return ConfigurationManager.AppSettings["ExclusionsMediaReportTitles"]; }
        }

        public static string DepartReturnMediaReportTitles {
            get { return ConfigurationManager.AppSettings["DepartReturnMediaReportTitles"]; }
        }

        public static string OtherInfoMediaReportTitles {
            get { return ConfigurationManager.AppSettings["OtherInfoMediaReportTitles"]; }
        }

        public static string ItineraryMediaReportTitles {
            get { return ConfigurationManager.AppSettings["ItineraryMediaReportTitles"]; }
        }

        public static string InclusionsMediaReportSection {
            get { return ConfigurationManager.AppSettings["InclusionsMediaReportSection"]; }
        }

        public static string ExclusionsMediaReportSection {
            get { return ConfigurationManager.AppSettings["ExclusionsMediaReportSection"]; }
        }

        public static string DepartReturnMediaReportSection {
            get { return ConfigurationManager.AppSettings["DepartReturnMediaReportSection"]; }
        }

        public static string OtherInfoMediaReportSection {
            get { return ConfigurationManager.AppSettings["OtherInfoMediaReportSection"]; }
        }

        public static string ItineraryMediaReportSection {
            get { return ConfigurationManager.AppSettings["ItineraryMediaReportSection"]; }
        }

        public static string ViatorAPIKeys {
            get { return ConfigurationManager.AppSettings["ViatorAPIKeys"]; }
        }

        public static string SpecificProduct {
            get { return ConfigurationManager.AppSettings["SpecificProduct"]; }
        }

        public static string SpecificDestination {
            get { return ConfigurationManager.AppSettings["SpecificDestination"]; }
        }

        public static string User {
            get { return ConfigurationManager.AppSettings["User"]; }
        }

        public static string UnwantedPhrases {
            get { return ConfigurationManager.AppSettings["UnwantedPhrases"]; }
        }

        public static bool DownloadImages {
            get {
                if (bool.TryParse(ConfigurationManager.AppSettings["DownloadImages"], out bool value)) {
                    return value;
                }
                else {
                    return true;
                }
            }
        }

        public static bool OverwriteImages {
            get {
                if (bool.TryParse(ConfigurationManager.AppSettings["OverwriteImages"], out bool value)) {
                    return value;
                }
                else {
                    return true;
                }
            }
        }

        public static int CancellationPolicyStartDays {
            get {
                int days;
                if (int.TryParse(ConfigurationManager.AppSettings["CancellationPolicyStartDays"], out days)) {
                    return days;
                }
                else {
                    return 1;
                }
            }
        }

        public static int CancellationPolicyEndDays {
            get {
                int days;
                if (int.TryParse(ConfigurationManager.AppSettings["CancellationPolicyEndDays"], out days)) {
                    return days;
                }
                else {
                    return 365;
                }
            }
        }

        public static bool ImportCancellationPolicies {
            get {
                bool val;
                if (bool.TryParse(ConfigurationManager.AppSettings["ImportCancellationPolicies"], out val)) {
                    return val;
                }
                else {
                    return false;
                }
            }
        }

        public static bool ImportCities {
            get {
                bool val;
                if (bool.TryParse(ConfigurationManager.AppSettings["ImportCities"], out val)) {
                    return val;
                }
                else {
                    return false;
                }
            }
        }

        public static bool ImportServiceTypes {
            get {
                bool val;
                if (bool.TryParse(ConfigurationManager.AppSettings["ImportServiceTypes"], out val)) {
                    return val;
                }
                else {
                    return false;
                }
            }
        }

        public static DateTime? ResDateToUse {
            get {
                DateTime value;
                if (DateTime.TryParse(ConfigurationManager.AppSettings["ResDateToUse"], out value)) {
                    return value;
                }
                else {
                    return null;
                }
            }
        }

        public static bool CreateNewInfoAsInHouse {
            get {
                bool value;
                if (bool.TryParse(ConfigurationManager.AppSettings["CreateNewInfoAsInHouse"], out value)) {
                    return value;
                }
                else {
                    return false;
                }
            }
        }

        public static bool MissingProductsOnly {
            get {
                bool value;
                if (bool.TryParse(ConfigurationManager.AppSettings["MissingHotelsOnly"], out value)) {
                    return value;
                }
                else {
                    return false;
                }
            }
        }

        public static bool ImportAmenities {
            get {
                bool value;
                if (bool.TryParse(ConfigurationManager.AppSettings["ImportAmenities"], out value)) {
                    return value;
                }
                else {
                    return false;
                }
            }
        }

        public static bool LogAPICalls {
            get {
                bool value;
                if (bool.TryParse(ConfigurationManager.AppSettings["LogAPICalls"], out value)) {
                    return value;
                }
                else {
                    return false;
                }
            }
        }

        public static bool MainAttributesOnly {
            get {
                bool value;
                if (bool.TryParse(ConfigurationManager.AppSettings["MainAttributesOnly"], out value)) {
                    return value;
                }
                else {
                    return false;
                }
            }
        }

        public static bool ImportCategories {
            get {
                bool value;
                if (bool.TryParse(ConfigurationManager.AppSettings["ImportCategories"], out value)) {
                    return value;
                }
                else {
                    return false;
                }
            }
        }

        public static int CultureIndex {
            get {
                int value;
                if (int.TryParse(ConfigurationManager.AppSettings["CultureIndex"], out value)) {
                    return value;
                }
                else {
                    return 0;
                }
            }
        }

        public static bool RemoveFromSearchAPI {
            get {
                if (bool.TryParse(ConfigurationManager.AppSettings["RemoveFromSearchAPI"], out bool value)) {
                    return value;
                }
                else {
                    return true;
                }
            }
        }
    }
}
