using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TraceForms
{
    public static class AccountingAPI
    {
        public static void InvokeForProduct(string url, string type, string code)
        {
            Invoke(url, $"item?type={type}&code={code}");
        }

        public static void InvokeForOperator(string url, string code)
        {
            Invoke(url, $"vendor?type=OPERATOR&code={code}");
        }

        public static void InvokeForAgency(string url, string agency)
        {
            Invoke(url, $"customer?code={agency}");
        }

        public static void InvokeForAgent(string url, string agent)
        {
            Invoke(url, $"agent?key={agent}");
        }

        public static void Invoke(string url, string action)
        {
            try {
            //Fire and forget API ping so the accounting interface will pick up any new data
                if (!string.IsNullOrEmpty(url)) {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + action);
                    //give it one second, because we don't want any operations held up by failure to invoke the accounting api
                    request.Timeout = 1000;
                    var resp = request.GetResponseAsync();
                }
            }
            catch { }
        }
    }
}
