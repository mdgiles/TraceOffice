using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OfficeOpenXml;
using System.IO;
using System.Net.Mail;
using System.Collections.Specialized;
using FlexInterfaces.Core;

namespace TraceForms
{
    public partial class HotelProductionReportForm : DevExpress.XtraEditors.XtraForm
    {
        ICoreSys _sys;

        public HotelProductionReportForm(ICoreSys sys)
        {
            InitializeComponent();
            _sys = sys;
            textBoxRecipients.Text = Configurator.HotelProductionReport_Recipients;
            dateEditStart.Text = DateTime.Today.AddDays(Configurator.HotelProductionReport_PastDays).ToString();
            dateEditEnd.Text = DateTime.Today.ToString();
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
                    ExportReport(startDate, endDate, xl);
                    using (MemoryStream stream = new MemoryStream()) {

                        //var file = new FileInfo("c:\\users\\mgile\\desktop\\test.xlsx");
                        //xl.SaveAs(file);

                        xl.SaveAs(stream);
                        stream.Flush();
                        stream.Position = 0;
                        using (SmtpClient smtp = new SmtpClient(_sys.Settings.MailServer, _sys.Settings.EmailPort)) {
                            smtp.Credentials = new System.Net.NetworkCredential(_sys.Settings.EmailUser, _sys.Settings.EmailPassword);
                            using (MailMessage message = new MailMessage(_sys.Settings.UnmonitoredEmail, recipients)) {
                                message.Subject = string.Format("Hotel Production Report {0:dd-MMM-yy} to {1:dd-MMM-yy}",
                                    DateTime.Today, endDate);
                                message.Body = string.Format("The hotel production report is attached for dates beginning {0:dd-MMM-yy} and ending {1:dd-MMM-yy}.",
                                    DateTime.Today, endDate);
                                message.Attachments.Add(new Attachment(stream, string.Format("HotelProductionReport {0:dd-MMM-yy} to {1:dd-MMM-yy}.xlsx",
                                    DateTime.Today, endDate),
                                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"));
                                smtp.Send(message);
                            }
                        }
                    }
                }
                NLog.LogManager.GetCurrentClassLogger().Debug("HotelProductionReport sent sucessfully");
                return "Hotel Production Report sent succesfully";
            }
            catch (Exception ex) {
                NLog.LogManager.GetCurrentClassLogger().ErrorException("HotelProductionReport - error sending email", ex);
                return ex.Message;
            }

        }

        private void ExportReport(DateTime startDate, DateTime endDate, ExcelPackage xl)
        {
            OrderedDictionary columns = new OrderedDictionary()
            {
                { "Code", "Code" },
                { "Name", "Name" },
                { "Chain", "Agency Name" },
                { "Rooms", "City" },
                { "Start Date", "Start Date" },
                { "Nights", "Nights" },
                { "Room Nights", "Room Nights" },
            };

            string sql = $@"select * from v_HotelRoomNights where [start date] >= '{startDate}' and [start date] <= '{endDate}'
order by [start date], code";
            ExportCommon(columns, sql, xl, "Hotel Production");
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

            ws.Cells["A1:G1"].AutoFilter = true;
            ws.Column(5).Style.Numberformat.Format = "MM/dd/yyyy";      //TODO: put this in the config file

            for (colIndex = 1; colIndex <= columns.Count; colIndex++) {
                ws.Cells[1, colIndex].Value = columns[colIndex - 1];
                ws.Column(colIndex).AutoFit();
                ws.Column(colIndex).Style.WrapText = true;
            }
        }

        private void HotelProductionReportForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _sys.Dispose();
        }
    }
}