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
    public partial class OTAReferenceListForm : DevExpress.XtraEditors.XtraForm
    {
        ICoreSys _sys;

        public OTAReferenceListForm(ICoreSys sys)
        {
            InitializeComponent();
            _sys = sys;
            textBoxRecipients.Text = Configurator.OperationsServiceList_Recipients;
            //Get the date period of the prior month
            DateTime priorMonth = DateTime.Today.AddMonths(-1);
            DateTime startDate = new DateTime(priorMonth.Year, priorMonth.Month, 1);
            dateEditStart.Text = startDate.ToString();
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);
            dateEditEnd.Text = endDate.ToString();
        }

		private void buttonSend_Click(object sender, EventArgs e)
		{
            if (dateEditStart.DateTime == DateTime.MinValue || dateEditEnd.DateTime == DateTime.MinValue || dateEditStart.DateTime > dateEditEnd.DateTime) {
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
                    Export(startDate, endDate, xl);
                    using (MemoryStream stream = new MemoryStream()) {

                        //var file = new FileInfo("c:\\users\\marqu\\desktop\\test.xlsx");
                        //xl.SaveAs(file);

                        xl.SaveAs(stream);
                        stream.Flush();
                        stream.Position = 0;
                        using (SmtpClient smtp = new SmtpClient(_sys.Settings.MailServer, _sys.Settings.EmailPort)) {
                            smtp.Credentials = new System.Net.NetworkCredential(_sys.Settings.EmailUser, _sys.Settings.EmailPassword);
                            using (MailMessage message = new MailMessage(_sys.Settings.UnmonitoredEmail, recipients)) {
                                message.Subject = $"OTA Reference List {startDate:dd-MMM-yy} to {endDate:dd-MMM-yy}";
                                message.Body = $"The OTA reference list is attached for dates beginning {startDate:dd-MMM-yy} and ending {endDate:dd-MMM-yy}.";
                                message.Attachments.Add(new Attachment(stream, $"OTAReferenceList {startDate:dd-MMM-yy} to {endDate:dd-MMM-yy}.xlsx",
                                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"));
                                smtp.Send(message);
                            }
                        }
                    }
                }
                NLog.LogManager.GetCurrentClassLogger().Debug("Report sent sucessfully");
                return "OTA Reference List sent succesfully";
            }
            catch (Exception ex) {
                NLog.LogManager.GetCurrentClassLogger().Error(ex, "Error sending email");
                return ex.Message;
            }

        }

        private void Export(DateTime startDate, DateTime endDate, ExcelPackage xl)
        {
            Dictionary<string, string> agencies = new Dictionary<string, string> {
                { "8572040812", "LPG" },
                { "7026802096", "Expedia" },
                { "2625068382", "Musement" },
                { "8556648235", "GYG" },
                { "7027495698", "Viator" },
                { "HOTELBEDS", "HotelBeds" },
                { "REZDY", "Rezdy" },
                { "R-VENETIAN", "Venetian" },
            };
            string agencyList = string.Join(",", agencies.Select(x => $"'{x.Key}'"));

            Dictionary<string, ExcelWorksheet> sheets = new Dictionary<string, ExcelWorksheet>();
            foreach (var item in agencies) {
                sheets.Add(item.Key, xl.Workbook.Worksheets.Add(item.Value));
            }

            Dictionary<string, string> columns = new Dictionary<string, string>()
            {
                { "res no", "Trip #" },
                { "item", "Item" },
                { "res agt", "Res Agent" },
                { "tripremarks", "Trip Remarks" },
                { "itemremarks", "Item Remarks" },
                { "reference", "Reference" },
                { "doc nbr", "Doc Nbr" },
                { "last name", "Last Name" },
                { "first name", "First Name" },
                { "code", "Code" },
                { "description", "Description" },
                { "category", "Category" },
                { "catdesc", "Category Description" },
                { "start date", "Service Date" },
                { "res date", "Booking Date" },
                { "cancelled", "Cancelled" },
                { "net", "Amount" },
                { "cost", "Cost" },
            };
            string[] keys = new string[columns.Count];
            columns.Keys.CopyTo(keys, 0);

            //Create another dictionary with the same keys holding the index of the current row in each sheet
            int colCounter = 1;
            Dictionary<string, int> rowCounters = new Dictionary<string, int>();
            foreach (var sheet in sheets) {
                colCounter = 1;
                foreach (var key in columns) {
                    sheet.Value.Cells[1, colCounter].Value = key.Value;
                    sheet.Value.Cells[1, colCounter].Style.Font.Bold = true;
                    colCounter++;
                }
                rowCounters.Add(sheet.Key, 2);      //row 1 is the column header
            }

            string dateField = $"[{radioGroupDate.EditValue}]";
            endDate = endDate.AddDays(1).AddSeconds(-1);
            string sql = $@"SELECT reshdr.[Res No], resitm.Item, resitm.[Res Agt], reshdr.InternalRemarks as TripRemarks, resitm.InternalRemarks as ItemRemarks, 
 reshdr.Reference, psgrlist.[Doc Nbr], psgrlist.[Last Name], psgrlist.[First Name], Code, DESCRIP AS description, CAT AS Category, resroom.catdesc, [Strt Date] AS [Start Date], resitm.[Res Date],
 CASE WHEN resitm.Inactive = 1 THEN 'Yes' ELSE 'No' END AS Cancelled, resitm.agency, resitm.Net FROM resitm, resnight.Cost
 INNER JOIN reshdr ON resitm.[res no] = reshdr.[res no]
 INNER JOIN psgrres ON reshdr.[res no] = psgrres.[res no] and psgrres.[client level] = 1
 INNER JOIN psgrlist ON psgrres.[CLIENT NO] = psgrlist.[CLIENT NO]
 INNER JOIN resroom ON resroom.[res no] = resitm.[res no] and resroom.item = resitm.item and resroom.room = 0 
 INNER JOIN resnight ON resnight.[res no] = resitm.[res no] and resnight.item = resitm.item and resnight.room = 0 and resnight.night = 0
 WHERE AGENCY in ({agencyList}) AND resitm.{dateField} >= '{startDate}' AND resitm.{dateField} <= '{endDate}'
 ORDER BY {dateField}";

            sql = sql.Replace(Environment.NewLine, string.Empty);
            using (IDbConnection conn = _sys.NewDBConnection()) {
                conn.Open();
                using (IDataReader dr = _sys.ExecuteReader(conn, sql)) {
                    if (!string.IsNullOrEmpty(_sys.LastError))
                        throw new Exception(_sys.LastError);

                    while (dr.Read()) {
                        string agency = dr["agency"].ToString();
                        var ws = sheets[agency];
                        rowCounters[agency] = AddRow(dr, ws, keys, rowCounters[agency]);
                    }
                    dr.Close();
                }
                conn.Close();
            }

            foreach (var sheet in sheets) {
                var ws = sheet.Value;
                ws.Cells[sheet.Value.Dimension.Address].AutoFilter = true;
                ws.Column(13).Style.Numberformat.Format = "MM/dd/yyyy";      //TODO: put this in the config file
                ws.Column(14).Style.Numberformat.Format = "MM/dd/yyyy";      //TODO: put this in the config file

                for (colCounter = 1; colCounter < keys.Count(); colCounter++) {
                    sheet.Value.Column(colCounter).AutoFit();
                    sheet.Value.Column(colCounter).Style.WrapText = true;
                }
            }
        }

        internal int AddRow(IDataReader dr, ExcelWorksheet ws, string[] keys, int startRow)
        {
            for (int colIndex = 1; colIndex <= keys.Count(); colIndex++) {
                ws.Cells[startRow, colIndex].Value = dr[keys[colIndex - 1]];
            }
            startRow++;
            return startRow;
        }

        private void OTAReferenceListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _sys.Dispose();
        }
    }
}
