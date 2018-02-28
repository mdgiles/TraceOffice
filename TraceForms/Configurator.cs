using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraceForms
{
    internal static class Configurator
    {

        internal static string HotelProductionReport_Recipients
        {
            get { return GetValue("HotelProductionReport_Recipients"); }
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
            return ConfigurationManager.AppSettings[key];
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

        internal static string MainMediaReport
        {
            get { return GetValue("MainMediaReport"); }
        }

        internal static string MainMediaSection
        {
            get { return GetValue("MainMediaSection"); }
        }
    }
}
