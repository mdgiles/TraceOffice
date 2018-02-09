using FlexInterfaces.Core;
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

        public OperationsServiceListForm(ICoreSys sys)
        {
            InitializeComponent();
            _sys = sys;
            textBoxRecipients.Text = Configurator.OperationsServiceList_Recipients;
            dateEditStart.Text = DateTime.Today.ToString();
            dateEditEnd.Text = DateTime.Today.AddDays(Configurator.OperationsServiceList_FutureDays).ToString();
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
                                message.Subject = string.Format("Operations Service List {0:dd-MMM-yy} to {1:dd-MMM-yy}",
                                    DateTime.Today, endDate);
                                message.Body = string.Format("The operations service list is attached for dates beginning {0:dd-MMM-yy} and ending {1:dd-MMM-yy}.",
                                    DateTime.Today, endDate);
                                message.Attachments.Add(new Attachment(stream, string.Format("OpsServiceList {0:dd-MMM-yy} to {1:dd-MMM-yy}.xlsx",
                                    DateTime.Today, endDate),
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
            OrderedDictionary columns = new OrderedDictionary()
            {
                { "strt date", "Service Date" },
                { "res no", "Trip #" },
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

            string sql = string.Format(@"select resitm.*, pkg.code as pkgcode, pkg.descrip as pkgdescrip, reshdr.[doc via], reshdr.reference, 
reshdr.client1, reshdr.[agy name], reshdr.internalremarks, (select top 1 psgrlist.[phone nbr] from psgrlist 
inner join psgrres on psgrres.[client no] = psgrlist.[client no] AND [client level] = 1 
WHERE psgrres.[res no] = resitm.[res no] and ISNULL([phone nbr], '') <> '') as PhoneNbr,
(select top 1 case when charindex('(' + cat + ')', catdesc) <> 0 then catdesc else catdesc + ' (' + cat + ')' end as catdesc
from resroom where resroom.[res no] = resitm.[res no] and resroom.item = resitm.item order by resroom.room) as category,
hotel.[city code] as city, operator.name as operator
from resitm 
inner join reshdr on reshdr.[res no] = resitm.[res no]
inner join hotel on resitm.code = hotel.code
left outer join resitm pkg on resitm.parentitem = pkg.item and resitm.[res no] = pkg.[res no] 
left outer join operator on resitm.oper = operator.code
where resitm.[strt date] between '{0}' and '{1}' and resitm.inactive = 0 and resitm.type = '{2}' 
order by resitm.[strt date], resitm.[res no], item", startDate, endDate, "HTL");
            ExportCommon(columns, sql, xl, "HTL");
        }

        private void ExportForOPT(DateTime startDate, DateTime endDate, ExcelPackage xl)
        {
            OrderedDictionary columns = new OrderedDictionary()
            {
                { "strt date", "Service Date" },
                { "res no", "Trip #" },
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
            string sql = string.Format(@"select resitm.*, pkg.code as pkgcode, pkg.descrip as pkgdescrip, reshdr.[doc via], reshdr.reference, 
reshdr.client1, reshdr.[agy name], reshdr.internalremarks, (select top 1 psgrlist.[phone nbr] from psgrlist 
inner join psgrres on psgrres.[client no] = psgrlist.[client no] AND [client level] = 1 
WHERE psgrres.[res no] = resitm.[res no] and ISNULL([phone nbr], '') <> '') as PhoneNbr,
(select top 1 case when charindex('(' + cat + ')', catdesc) <> 0 then catdesc else catdesc + ' (' + cat + ')' end as catdesc
from resroom where resroom.[res no] = resitm.[res no] and resroom.item = resitm.item order by resroom.room) as category,
comp.city, comp.[serv type], operator.name as operator, dbo.fn_GetProductDescription(ISNULL(resitm.bus_pup_type, 'WAY'), resitm.[bus pup]) as location
from resitm 
inner join reshdr on reshdr.[res no] = resitm.[res no]
inner join comp on resitm.code = comp.code
left outer join resitm pkg on resitm.parentitem = pkg.item and resitm.[res no] = pkg.[res no] 
left outer join operator on resitm.oper = operator.code
where resitm.[strt date] between '{0}' and '{1}' and resitm.inactive = 0 and resitm.type = '{2}' 
order by resitm.[strt date], resitm.[res no], item", startDate, endDate, "OPT");

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

            ws.Cells["A1:V1"].AutoFilter = true;
            ws.Column(1).Style.Numberformat.Format = "MM/dd/yyyy";      //TODO: put this in the config file

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
    }
}
