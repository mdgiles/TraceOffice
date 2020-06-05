using DevExpress.Utils.Win;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Views.Grid;
using FlexInterfaces.Core;
using FlexModel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TraceForms
{
    public partial class OperationsServiceListForm : DevExpress.XtraEditors.XtraForm
    {
        ICoreSys _sys;
        FlextourEntities _context;
        List<CodeName> _hotels, _services;

        public OperationsServiceListForm(ICoreSys sys)
        {
            InitializeComponent();
            _sys = sys;
            _context = new FlextourEntities(sys.Settings.EFConnectionString);

            textBoxRecipients.Text = Configurator.OperationsServiceList_Recipients;
            dateEditStart.Text = DateTime.Today.ToString();
            dateEditEnd.Text = DateTime.Today.AddDays(Configurator.OperationsServiceList_FutureDays).ToString();

            var operators = new List<CodeName>() {
                new CodeName(null, "<all>")
            };
            operators.AddRange(_context.OPERATOR
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.NAME }));
            searchLookUpEditOperator.Properties.DataSource = operators;

            _hotels = new List<CodeName>() {
                new CodeName(null, "<all>")
            };
            _hotels.AddRange(_context.HOTEL
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.NAME, Tag = t.OPER }));
            searchLookUpEditHotel.Properties.DataSource = _hotels;

            _services = new List<CodeName>() {
                new CodeName(null, "<all>")
            };
            _services.AddRange(_context.COMP
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.NAME, Tag = t.OPER }));
            searchLookUpEditService.Properties.DataSource = _services;
        }

        private void buttonSend_Click(object sender, EventArgs e)
		{
            if (dateEditStart.DateTime == DateTime.MinValue || dateEditEnd.DateTime == DateTime.MinValue) {
                MessageBox.Show(this, "Please enter a valid start date and end date for the report.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxRecipients.Text)) {
                MessageBox.Show(this, "Please enter a recipient for the report.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Cursor = Cursors.WaitCursor;
            labelStatus.Text = "Generating report...";
            labelStatus.Text = GenerateReport(textBoxRecipients.Text, 0, dateEditStart.DateTime, dateEditEnd.DateTime);
            Cursor = Cursors.Default;
        }

        public string GenerateReport(string recipients, int days, DateTime startDate, DateTime endDate)
        {
            try {
                if (endDate.Equals(DateTime.MinValue)) {
                    endDate = DateTime.Today.AddDays(days);
                }
                //Yes, it really is this hard to get the tag property of the selected radio option. 
                //They should have a radioGroupDate.SelectedItem property
                string dateType = radioGroupDate.Properties.Items[radioGroupDate.SelectedIndex].Tag.ToString();

                using (ExcelPackage xl = new ExcelPackage()) {
                    ExportForOPT(startDate, endDate, xl);
                    ExportForHTL(startDate, endDate, xl);
                    using (MemoryStream stream = new MemoryStream()) {

                        //var file = new FileInfo("c:\\users\\mgile\\desktop\\test.xlsx");
                        //xl.SaveAs(file);

                        xl.SaveAs(stream);
                        stream.Flush();
                        stream.Position = 0;
                        using (SmtpClient smtp = new SmtpClient(_sys.Settings.MailServer, _sys.Settings.EmailPort)) {
                            smtp.Credentials = new System.Net.NetworkCredential(_sys.Settings.EmailUser, _sys.Settings.EmailPassword);
                            using (MailMessage message = new MailMessage(_sys.Settings.UnmonitoredEmail, recipients)) {
                                message.Subject = $"Operations Service List {startDate:dd-MMM-yyyy} to {endDate:dd-MMM-yyyy}";
                                message.Body = $"The operations service list is attached for {dateType} dates beginning {startDate:dd-MMM-yyyy} and ending {endDate:dd-MMM-yyyy}.";
                                message.Attachments.Add(new Attachment(stream, $"OpsServiceList {startDate:dd-MMM-yyyy} to {endDate:dd-MMM-yyyy}.xlsx",
                                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"));
                                smtp.Send(message);
                            }
                        }
                    }
                }
                NLog.LogManager.GetCurrentClassLogger().Debug("Report sent sucessfully");
                return "Operation Service List sent succesfully";
            }
            catch (Exception ex) {
                NLog.LogManager.GetCurrentClassLogger().Error(ex, "Error sending email");
                return ex.Message;
            }

        }

        private void ExportForHTL(DateTime startDate, DateTime endDate, ExcelPackage xl)
        {
            string dateField = $"[{radioGroupDate.EditValue}]";
            string oper = searchLookUpEditOperator.EditValue.ToStringEmptyIfNull();
            int operIsEmpty = string.IsNullOrEmpty(oper) ? 1 : 0;
            string product = searchLookUpEditHotel.EditValue.ToStringEmptyIfNull();
            int prodIsEmpty = string.IsNullOrEmpty(product) ? 1 : 0;

            string cxlClause = string.Empty, cxlDatesClause = string.Empty;
            if (checkEditIncludeCancelled.Checked) {
                cxlClause = "or resitm.inactive = 1";
                cxlDatesClause = $"or resitm.[cxl date] between '{startDate}' and '{endDate}'";
            }

            OrderedDictionary columns = new OrderedDictionary()
            {
                { "strt date", "Service Date" },
                { "res date", "Booking Date" },
                { "res no", "Trip #" },
                { "status", "Status" },
                { "agy name", "Agency Name" },
                { "city", "City" },
                { "reference", "Client\r\nReference" },
                { "nbr adults", "No. of\r\nPax" },
                { "nbr rms", "No. of\r\nRooms" },
                { "nbr nights", "No. of\r\nNights" },
                { "descrip", "Hotel Name" },
                { "category", "Category" },
                { "pkgcode", "Package\r\nCode" },
                { "confirm", "Confirmation No." },
                { "operator", "Vendor/\r\nOperator" },
                { "client1", "1st Guest\r\nLead Name" },
                { "phonenbr", "Phone No." },
                { "note com", "Comments/\r\nRequests" },
                { "internalremarks", "Remarks" },
                { "doc via", "CC" },
            };

            string sql = $@"select resitm.*, pkg.code as pkgcode, pkg.descrip as pkgdescrip, reshdr.[doc via], reshdr.reference, 
reshdr.client1, reshdr.[agy name], reshdr.internalremarks, (select top 1 psgrlist.[phone nbr] from psgrlist 
inner join psgrres on psgrres.[client no] = psgrlist.[client no] AND [client level] = 1 
WHERE psgrres.[res no] = resitm.[res no] and ISNULL([phone nbr], '') <> '') as PhoneNbr,
(select top 1 case when charindex('(' + cat + ')', catdesc) <> 0 then catdesc else catdesc + ' (' + cat + ')' end as catdesc
from resroom where resroom.[res no] = resitm.[res no] and resroom.item = resitm.item order by resroom.room) as category,
hotel.[city code] as city, operator.name as operator, case when resitm.inactive = 1 then 'Inactive' else 'Active' end as status
from resitm 
inner join reshdr on reshdr.[res no] = resitm.[res no]
inner join hotel on resitm.code = hotel.code
left outer join resitm pkg on resitm.parentitem = pkg.item and resitm.[res no] = pkg.[res no] 
left outer join operator on resitm.oper = operator.code
where (resitm.{dateField} between '{startDate}' and '{endDate}' {cxlDatesClause}) and (resitm.inactive = 0 {cxlClause}) 
and resitm.type = 'HTL' 
and (resitm.OPER = '{oper}' OR 1 = {operIsEmpty})
and (resitm.CODE = '{product}' OR 1 = {prodIsEmpty})
order by resitm.{dateField}, resitm.[res no], item";
            ExportCommon(columns, sql, xl, "HTL");
        }

        private void ExportForOPT(DateTime startDate, DateTime endDate, ExcelPackage xl)
        {
            string dateField = $"[{radioGroupDate.EditValue}]";
            string oper = searchLookUpEditOperator.EditValue.ToStringEmptyIfNull();
            int operIsEmpty = string.IsNullOrEmpty(oper) ? 1 : 0;
            string product = searchLookUpEditService.EditValue.ToStringEmptyIfNull();
            int prodIsEmpty = string.IsNullOrEmpty(product) ? 1 : 0;

            string cxlClause = string.Empty, cxlDatesClause = string.Empty;
            if (checkEditIncludeCancelled.Checked) {
                cxlClause = "or resitm.inactive = 1";
                cxlDatesClause = $"or resitm.[cxl date] between '{startDate}' and '{endDate}'";
            }

            OrderedDictionary columns = new OrderedDictionary()
            {
                { "strt date", "Service Date" },
                { "res date", "Booking Date" },
                { "res no", "Trip #" },
                { "status", "Status" },
                { "agy name", "Agency Name" },
                { "city", "City" },
                { "reference", "Client\r\nReference" },
                { "nbr adults", string.Format("No. of{0} Pax", Environment.NewLine) },
                { "pup time", "Pickup\r\nTime" },
                { "location", "Pickup Location" },
                { "tour time", "Service\r\nTime" },
                { "serv type", "Service\r\nType" },
                { "code", "Product\r\nCode" },
                { "descrip", "Product Name" },
                { "pkgcode", "Package\r\nCode" },
                { "pkgdescrip", "Package Name" },
                { "category", "Category" },
                { "confirm", "Confirmation No." },
                { "operator", "Vendor/\r\nOperator" },
                { "client1", "1st Guest\r\nLead Name" },
                { "phonenbr", "Phone No." },
                { "note com", "Comments/\r\nRequests" },
                { "internalremarks", "Remarks" },
                { "doc via", "CC" },
            };

            endDate = endDate.AddDays(1).AddSeconds(-1);
            string sql = $@"select resitm.*, pkg.code as pkgcode, pkg.descrip as pkgdescrip, reshdr.[doc via], reshdr.reference, 
reshdr.client1, reshdr.[agy name], reshdr.internalremarks, (select top 1 psgrlist.[phone nbr] from psgrlist 
inner join psgrres on psgrres.[client no] = psgrlist.[client no] AND [client level] = 1 
WHERE psgrres.[res no] = resitm.[res no] and ISNULL([phone nbr], '') <> '') as PhoneNbr,
(select top 1 case when charindex('(' + cat + ')', catdesc) <> 0 then catdesc else catdesc + ' (' + cat + ')' end as catdesc
from resroom where resroom.[res no] = resitm.[res no] and resroom.item = resitm.item order by resroom.room) as category,
comp.city, comp.[serv type], operator.name as operator, dbo.fn_GetProductDescription(ISNULL(resitm.bus_pup_type, 'WAY'), resitm.[bus pup]) as location,
case when resitm.inactive = 1 then 'Inactive' else 'Active' end as status
from resitm 
inner join reshdr on reshdr.[res no] = resitm.[res no]
inner join comp on resitm.code = comp.code
left outer join resitm pkg on resitm.parentitem = pkg.item and resitm.[res no] = pkg.[res no] 
left outer join operator on resitm.oper = operator.code
where (resitm.{dateField} between '{startDate}' and '{endDate}' {cxlDatesClause}) and (resitm.inactive = 0 {cxlClause}) 
and resitm.type = 'OPT' 
and (resitm.OPER = '{oper}' OR 1 = {operIsEmpty})
and (resitm.CODE = '{product}' OR 1 = {prodIsEmpty})
order by resitm.{dateField}, resitm.[res no], item";

            ExportCommon(columns, sql, xl, "OPT");
        }

        private void ExportCommon(OrderedDictionary columns, string sql, ExcelPackage xl, string sheetName)
        {
            int colIndex;
            var ws = xl.Workbook.Worksheets.Add(sheetName);

            using (IDbConnection conn = _sys.NewDBConnection()) {
                conn.Open();
                using (IDataReader dr = _sys.ExecuteReader(conn, sql)) {
                    if (!string.IsNullOrEmpty(_sys.LastError))
                        throw new Exception(_sys.LastError);

                    string[] keys = new string[columns.Count];
                    columns.Keys.CopyTo(keys, 0);

                    int rowIndex = 2;
                    while (dr.Read()) {
                        for (colIndex = 1; colIndex <= columns.Count; colIndex++) {
                            ws.Cells[rowIndex, colIndex].Value = dr[keys[colIndex - 1]];
                        }
                        rowIndex++;
                    }
                    dr.Close();
                }
                conn.Close();
            }

            ws.Cells["A1:W1"].AutoFilter = true;
            ws.Column(1).Style.Numberformat.Format = "MM/dd/yyyy";      //TODO: put this in the config file
            ws.Column(2).Style.Numberformat.Format = "MM/dd/yyyy";      //TODO: put this in the config file

            for (colIndex = 1; colIndex <= columns.Count; colIndex++) {
                ws.Cells[1, colIndex].Value = columns[colIndex - 1];
                ws.Column(colIndex).AutoFit();
                ws.Column(colIndex).Style.WrapText = true;
            }
        }

        private void OperationsServiceListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _sys.Dispose();
        }

        private void radioGroupDate_EditValueChanged(object sender, EventArgs e)
        {
            if (radioGroupDate.SelectedIndex == 1) {
                dateEditEnd.Properties.MaxValue = DateTime.Today;
                if (dateEditEnd.DateTime > DateTime.Today) {
                    dateEditEnd.DateTime = DateTime.Today;
                }
            }
            else {
                dateEditEnd.Properties.MaxValue = DateTime.MaxValue;
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
            if (e.KeyData == Keys.Enter && popupForm != null) {
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

        private void searchLookUpEditOperator_EditValueChanged(object sender, EventArgs e)
        {
            searchLookUpEditHotel.EditValue = null;
            searchLookUpEditService.EditValue = null;
            if (searchLookUpEditOperator.EditValue is null) {
                searchLookUpEditHotel.Properties.DataSource = _hotels;
                searchLookUpEditService.Properties.DataSource = _services;
            }
            else {
                string oper = searchLookUpEditOperator.EditValue.ToString();
                var products = _hotels.Where(h => h.Tag == oper || h.Code == null).ToList();
                if (products.Any(p => p.Code != null)) {
                    searchLookUpEditHotel.Properties.DataSource = products;
                }
                else {
                    searchLookUpEditHotel.Properties.DataSource = null;
                }
                products = _services.Where(h => h.Tag == oper || h.Code == null).ToList();
                if (products.Any(p => p.Code != null)) {
                    searchLookUpEditService.Properties.DataSource = products;
                }
                else {
                    searchLookUpEditService.Properties.DataSource = null;
                }
            }
            searchLookUpEditService.Enabled = (searchLookUpEditService.Properties.DataSource != null);
            searchLookUpEditHotel.Enabled = (searchLookUpEditHotel.Properties.DataSource != null);
        }

        private void LookupEdit_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ((sender as LookUpEditBase).Properties.DataSource == null)
                e.Cancel = true;
            else
                e.Cancel = false;
        }

    }
}
