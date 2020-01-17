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

        /*private async Task<List<T>> GetDataFromAPI<T>(Type type, SupplierConnection connection, LANGUAGE lang, string url,
    CommonRQ request, bool getAllPages)
        {
            List<T> list = new List<T>();
            //Use whatever valid "from" value is provided or start at 1
            do {
                //convert strongly typed class to dictionary of request parameters
                Dictionary<string, string> parameters = request.AsDictionary();
                string result = await ApiInvoker.SendRequestGet(string.Empty, connection.URL + url + "?", parameters, headers);
                var rs = JsonConvert.DeserializeObject(result, type);       //Deserialize the data as the provided type
                if (rs == null) {
                    break;
                }
                CommonRS common = (CommonRS)rs;     //We know all returned data can be cast to this basic type
                var data = common.GetData<T>();     //Get the actual list of results as generic type
                if (data.Count == 0) {
                    break;
                }
                list.AddRange(data);
                to += 1000;
                from += 1000;
            } while (getAllPages);
            return list;
        }*/
    }
}
