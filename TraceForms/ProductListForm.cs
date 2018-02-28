using DevExpress.XtraEditors.Controls;
using FlexInterfaces.Core;
using FlexModel;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TraceForms
{
    public partial class ProductListForm : DevExpress.XtraEditors.XtraForm
    {
        ICoreSys _sys;

        public ProductListForm(ICoreSys sys)
        {
            InitializeComponent();
            _sys = sys;

            ImageComboBoxEditLang.Properties.Items.Add(new ImageComboBoxItem() { Description = "", Value = null });
            using (var context = new FlextourEntities(sys.Settings.EFConnectionString)) {
                foreach (var lang in context.LANGUAGE.OrderBy(l => l.CODE)) {
                    ImageComboBoxEditLang.Properties.Items.Add(new ImageComboBoxItem { Description = $"{lang.NAME} ({lang.CODE})", Value = lang.CODE });
                }
            }
            ImageComboBoxEditLang.EditValue = _sys.Settings.DefaultLanguage;
            textBoxRecipients.Text = Configurator.ProductList_Recipients;
            dateEditStart.Text = DateTime.Today.ToString();
            dateEditEnd.Text = DateTime.Today.AddYears(1).ToString();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            //Unspecified start date is today
            DateTime startDate = (dateEditStart.DateTime == DateTime.MinValue ? DateTime.Today : dateEditStart.DateTime);
            //Unspecified end date is a lot of years in the future
            DateTime endDate = (dateEditEnd.DateTime == DateTime.MinValue ? DateTime.Today.AddYears(100) : dateEditEnd.DateTime);
            if (startDate < DateTime.Today || endDate < DateTime.Today) {
                DisplayHelper.DisplayError(this, "Start and end date must not be in the past.");
                return;
            }
            if (startDate >= endDate) {
                DisplayHelper.DisplayError(this, "Start date must be prior to end date.");
                return;
            }
            if (string.IsNullOrEmpty(textBoxRecipients.Text)) {
                DisplayHelper.DisplayError(this, "Please enter a recipient for the report.");
                return;
            }
            Cursor = Cursors.WaitCursor;
            labelStatus.Text = "Generating report...";
            labelStatus.Text = GenerateReport(textBoxRecipients.Text, startDate, endDate);
            Cursor = Cursors.Default;
        }

        public string GenerateReport(string recipients, DateTime startDate, DateTime endDate)
        {
            try {
                string lang = _sys.Settings.DefaultLanguage;
                if (ImageComboBoxEditLang.EditValue != null) {
                    lang = ImageComboBoxEditLang.EditValue.ToString();
                }

                using (ExcelPackage xl = new ExcelPackage()) {
                    if (ExportForOPT(startDate, endDate, xl, lang)) {
                        using (MemoryStream stream = new MemoryStream()) {

                            //var file = new FileInfo("c:\\users\\marqu\\desktop\\ProductList.xlsx");
                            //xl.SaveAs(file);

                            xl.SaveAs(stream);
                            stream.Flush();
                            stream.Position = 0;
                            using (SmtpClient smtp = new SmtpClient(_sys.Settings.MailServer, _sys.Settings.EmailPort)) {
                                smtp.Credentials = new System.Net.NetworkCredential(_sys.Settings.EmailUser, _sys.Settings.EmailPassword);
                                using (MailMessage message = new MailMessage()) {
                                    message.From = new MailAddress(_sys.Settings.UnmonitoredEmail, "Ops");
                                    message.To.Add(recipients);
                                    message.Subject = $"Product List {lang}";
                                    message.Body = $"The product list is attached.";
                                    message.Attachments.Add(new Attachment(stream, $"ProductList_{lang}.xlsx",
                                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"));
                                    smtp.Send(message);
                                }
                            }
                        }
                    }
                    else {
                        return "No matching records found";
                    }
                }
                NLog.LogManager.GetCurrentClassLogger().Debug("Report sent sucessfully");
                return "Product List sent succesfully";
            }
            catch (Exception ex) {
                NLog.LogManager.GetCurrentClassLogger().Error(ex, "Error");
                return ex.Message;
            }

        }

        private bool ExportForOPT(DateTime startDate, DateTime endDate, ExcelPackage xl, string lang)
        {
            OrderedDictionary columns = new OrderedDictionary()
            {
                { "cityname", "Destination" },
                { "productsubtypename", "Type" },
                { "operatorname", "Supplier" },
                { "title", "Product Name" },
                { "code", "Product Code" },
                { "catdesc", "Category" },
                { "cat", "Category Code" },
                { "validity", "Validity" },
                { "net", "Agent Net" },
                { "retail", "Retail Price" },
                { "chd limit", "Child Age" },
                { "chd grate", "Child Net" },
                { "childretail", "Child Retail" },
                { "jr limit", "Junior Age" },
                { "jr grate", "Junior Net" },
                { "juniorretail", "Junior Retail" },
                { "duration", "Duration" },
            };

            endDate = endDate.AddDays(1).AddSeconds(-1);
            using (IDbConnection conn = _sys.NewDBConnection()) {
                conn.Open();
                using (IDbCommand cmd = _sys.NewDBCommand(conn)) {
                    cmd.CommandText = "usp_ProductList";
                    cmd.CommandType = CommandType.StoredProcedure;
                    AddParameter(cmd, DbType.DateTime, "@startDate", startDate);
                    AddParameter(cmd, DbType.DateTime, "@endDate", endDate);
                    AddParameter(cmd, DbType.String, "@lang", lang);
                    return ExportCommon(columns, cmd, xl, lang);
                }
            }
        }

        private IDbDataParameter AddParameter(IDbCommand cmd, DbType type, string name, object value)
        {
            IDbDataParameter param = cmd.CreateParameter();
            param.DbType = type;
            param.ParameterName = name;
            param.Value = value;
            cmd.Parameters.Add(param);
            return param;
        }

        private bool ExportCommon(OrderedDictionary columns, IDbCommand cmd, ExcelPackage xl, string lang)
        {
            int colIndex;
            string sheetName = string.Empty;
            int rowIndex = 0;
            ExcelWorksheet ws = null;
            bool gotRecords = false;
            bool hasRates, hasChdRates, hasJrRates;
            string key;

            //Copy the dictionary to an array so we can access it by index number
            string[] keys = new string[columns.Count];
            columns.Keys.CopyTo(keys, 0);

            using (IDataReader dr = cmd.ExecuteReader()) {
                if (!string.IsNullOrEmpty(_sys.LastError))
                    throw new Exception(_sys.LastError);

                while (dr.Read()) {
                    gotRecords = true;
                    if (dr["maintype"].ToString() != sheetName) {
                        sheetName = dr["maintype"].ToString();
                        ws = xl.Workbook.Worksheets.Add(sheetName);
                        rowIndex = 2;
                    }
                    hasChdRates = (dr["chd limit"].ToIntZeroIfNull() != 0);
                    hasJrRates = (dr["jr limit"].ToIntZeroIfNull() != 0);
                    hasRates = (dr["net"] != null);
                    for (colIndex = 1; colIndex <= columns.Count; colIndex++) {
                        key = keys[colIndex - 1];
                        if (key == "code") {
                            //The text on the website says "Things To Do" so the name of the sheet matches that, but the route
                            //is /activities
                            string mainType = (sheetName == "Things To Do" ? "activities" : sheetName.ToLower());
                            if (mainType.Equals("packages", StringComparison.OrdinalIgnoreCase)) {
                                ws.Cells[rowIndex, colIndex].Hyperlink = new Uri($"{_sys.Settings.WebsiteURL}packages.html#/{dr["code"]}/{lang}");
                            }
                            else {
                                ws.Cells[rowIndex, colIndex].Hyperlink = new Uri($"{_sys.Settings.WebsiteURL}services.html#/{mainType}/{dr["code"]}/{lang}");
                            }
                            ws.Cells[rowIndex, colIndex].Value = dr[key];
                            ws.Cells[rowIndex, colIndex].Style.Font.UnderLine = true;
                            ws.Cells[rowIndex, colIndex].Style.Font.Color.SetColor(Color.Blue);
                        }
                        else if (key == "net" || key.Contains("retail") || key.Contains("grate")) {
                            //null rates means this must be an API product, so don't attempt to put them in and format
                            if (hasRates) {
                                if (key.Contains("chd ") || key.Contains("child")) {
                                    //only put in and format child rates if there is a child age limit
                                    if (hasChdRates) {
                                        ws.Cells[rowIndex, colIndex].Value = dr[key];
                                        ws.Cells[rowIndex, colIndex].Style.Numberformat.Format = "$0.00";
                                    }
                                }
                                else if (key.Contains("jr ") || key.Contains("junior")) {
                                    //only put in and format jr rates if there is a junior age limit
                                    if (hasJrRates) {
                                        ws.Cells[rowIndex, colIndex].Value = dr[key];
                                        ws.Cells[rowIndex, colIndex].Style.Numberformat.Format = "$0.00";
                                    }
                                }
                                else {
                                    ws.Cells[rowIndex, colIndex].Value = dr[key];
                                    ws.Cells[rowIndex, colIndex].Style.Numberformat.Format = "$0.00";
                                }
                            }
                        }
                        else if (key == "chd limit" || key == "jr limit") {
                            if ((key == "chd limit" && hasChdRates) || (key == "jr limit" && hasJrRates)) {
                                ws.Cells[rowIndex, colIndex].Value = dr[key];
                                ws.Cells[rowIndex, colIndex].Style.Numberformat.Format = "@";   //format as text
                            }
                        }
                        else if (key == "catdesc") {
                            //If there is a category title specified in media repo and it's not the same as the product title,
                            //use it rather than roomcod desc
                            if (string.CompareOrdinal(dr["cattitle"].ToStringEmptyIfNull(), dr["title"].ToStringEmptyIfNull()) != 0) {
                                ws.Cells[rowIndex, colIndex].Value = dr["cattitle"];
                            }
                            else {
                                ws.Cells[rowIndex, colIndex].Value = dr[key];
                            }
                        }
                        else {
                            ws.Cells[rowIndex, colIndex].Value = dr[key];
                        }
                    }
                    rowIndex++;
                }
                dr.Close();
            }

            if (gotRecords) {
                foreach (var sheet in xl.Workbook.Worksheets) {
                    FinishSheet(sheet, columns, keys);
                }
            }
            return gotRecords;
        }

        private void FinishSheet(ExcelWorksheet ws, OrderedDictionary columns, string[] keys)
        {
            for (int colIndex = 1; colIndex <= columns.Count; colIndex++) {
                //Column header
                ws.Cells[1, colIndex].Value = columns[colIndex - 1];
                ws.Cells[1, colIndex].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[1, colIndex].Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                ws.Cells[1, colIndex].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[1, colIndex].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                //We have to set AutoFit and then do the cell merging, because EPPlus AutoFit ignores merged cells
                //Otherwise it would be easier to do the merging while populating the sheet above
                ws.Column(colIndex).AutoFit();
                ws.Column(colIndex).Style.WrapText = true;
            }
            MergeValues(ws, keys);
        }

        private void MergeValues(ExcelWorksheet ws, string[] keys)
        {
            string[] mergeKeys = new string[] { "cityname", "productsubtypename", "operatorname", "title", "code" };
            int[] mergeCols = new int[mergeKeys.Length];
            int[] startRows = new int[mergeKeys.Length];
            string[] mergeVals = new string[mergeKeys.Length];
            int rowIndex = 2;
            string value;

            for (int ctr = 0; ctr < mergeKeys.Length; ctr++) {
                string key = mergeKeys[ctr];
                mergeCols[ctr] = keys.FindIndex(k => k == key) + 1;
                mergeVals[ctr] = ws.Cells[rowIndex, mergeCols[ctr]].Value.ToStringEmptyIfNull();
                startRows[ctr] = rowIndex;
            }

            do {
                for (int index = 0; index < mergeCols.Length; index++) {
                    int colIndex = mergeCols[index];
                    value = ws.Cells[rowIndex, colIndex].Value.ToStringEmptyIfNull();
                    if (value != mergeVals[index]) {
                        //If a value has changed, the merge needs to be for the column which has changed and all the columns to the right
                        for (int nextIndex = index; nextIndex < mergeCols.Length; nextIndex++) {
                            colIndex = mergeCols[nextIndex];
                            ws.Cells[startRows[nextIndex], colIndex, rowIndex - 1, colIndex].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            if (!ws.Cells[startRows[nextIndex], colIndex, rowIndex - 1, colIndex].Merge) {
                                ws.Cells[startRows[nextIndex], colIndex, rowIndex - 1, colIndex].Merge = true;
                            }
                            startRows[nextIndex] = rowIndex;
                            mergeVals[nextIndex] = ws.Cells[rowIndex, colIndex].Value.ToStringEmptyIfNull();
                        }
                    }
                    if (string.IsNullOrEmpty(value)) {
                        return;
                    }
                }
                rowIndex++;
            } while (true);
        }

        private void ProductListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _sys.Dispose();
        }
    }
}
