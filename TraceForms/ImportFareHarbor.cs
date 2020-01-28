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
using Custom_SearchLookupEdit;
using DevExpress.Data.Async.Helpers;
using DevExpress.Map;
using DevExpress.XtraMap;
using System.Threading.Tasks;
using TraceForms.Models;
using Newtonsoft.Json;
using System.Text;
using System.Security.Cryptography;

namespace TraceForms
{
    public partial class ImportFareHarbor : XtraForm
    {
        FlextourEntities _context;
        SupplierConnection _supplierConnection;
        Timer _actionConfirmation;
        bool _ignoreLeaveRow = false, _ignorePositionChange = false;

        RepositoryItemImageComboBox _supplierCombo = new RepositoryItemImageComboBox();
        RepositoryItemCustomSearchLookUpEdit _operatorSearch = new RepositoryItemCustomSearchLookUpEdit();

        public ImportFareHarbor(FlexInterfaces.Core.ICoreSys sys)
        {
            try {
                InitializeComponent();
                Connect(sys);
                LoadLookups();
                //GetDataFromAPI();
            }
            catch (Exception ex) {
                DisplayHelper.DisplayError(this, ex);
            }
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            _context = new FlextourEntities(sys.Settings.EFConnectionString);
        }

        private void LoadLookups()
        {
            var supplier = _context.Supplier.SingleOrDefault(s => s.EnumValue == (int)FlexInterfaces.Enumerations.FlexExternalSuppliers.FareHarborDev);
            if(supplier == null) {
                DisplayHelper.DisplayError(this, "The supplier was not found.");
            }
            else {
                var guid = supplier.GUID;
                _supplierConnection = _context.SupplierConnection.FirstOrDefault(s => s.Supplier_GUID == guid);
            }
        }

        private async Task<List<T>> GetDataFromAPI<T>(Type type, SupplierConnection connection, string url,
    CommonRQ request)
        {
            string hash = GetHash(connection);
            Dictionary<string, string> headers = new Dictionary<string, string> {
                { "Api-key", connection.Login },
                { "X-Signature", hash },
            };
            List<T> list = new List<T>();
            //Use whatever valid "from" value is provided or start at 1
            
            //convert strongly typed class to dictionary of request parameters
            Dictionary<string, string> parameters = request.AsDictionary();
            string result = await ApiInvoker.SendRequestGet(string.Empty, connection.URL + url + "?", parameters, headers);
            var rs = JsonConvert.DeserializeObject(result, type);       //Deserialize the data as the provided type
            CommonRS common = (CommonRS)rs;     //We know all returned data can be cast to this basic type
            var data = common.GetData<T>();     //Get the actual list of results as generic type
            list.AddRange(data);
            
            return list;
        }

        private string GetHash(SupplierConnection connection)
        {
            // Compute the signature to be used in the API call (combined key + secret + timestamp in seconds)
            using (var sha = SHA256.Create()) {
                long ts = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds / 1000;
                var computedHash = sha.ComputeHash(Encoding.UTF8.GetBytes(connection.Login + connection.Secret + ts));
                return BitConverter.ToString(computedHash).Replace("-", "");
            }
        }
    }
}
