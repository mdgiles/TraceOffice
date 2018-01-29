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
using FlexModel;
using System.IO;
using OfficeOpenXml;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.ViewInfo;
using System.Runtime.Serialization;
using System.Transactions;
using System.Globalization;

namespace TraceForms
{
    public partial class MGMRatesImportForm : DevExpress.XtraEditors.XtraForm
    {
        FlexInterfaces.Core.ICoreSys _sys;
        FlextourEntities _context;
        RepositoryItemImageComboBox _hotelCombo = new RepositoryItemImageComboBox();
        RepositoryItemImageComboBox _catCombo = new RepositoryItemImageComboBox();
        Timer _actionConfirmation;
        BackgroundWorker _bgWorker = new BackgroundWorker();
        bool _someRates;

        public MGMRatesImportForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
            LoadLookups();

            _sys = sys;
            _bgWorker.DoWork += _bgWorker_DoWork;
            _bgWorker.RunWorkerCompleted += _bgWorker_RunWorkerCompleted;
            _bgWorker.ProgressChanged += _bgWorker_ProgressChanged;
            _bgWorker.WorkerSupportsCancellation = true;
            _bgWorker.WorkerReportsProgress = true;
            openFileDialog.InitialDirectory = sys.Settings.DataPath;
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            _context = new FlextourEntities(sys.Settings.EFConnectionString);
            _context.CommandTimeout = 600;
            _context.ContextOptions.UseCSharpNullComparisonBehavior = true;
            importMappingBindingSource.DataSource = _context.ImportMapping.OrderBy(i => i.Code).ThenBy(i => i.WeekdaySurcharge);
        }

        private void LoadLookups()
        {
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };

            _hotelCombo.Items.Add(loadBlank);
            _hotelCombo.Items.AddRange(_context.HOTEL.Where(a => a.INACTIVE != "Y")
                .OrderBy(o => o.CODE).AsEnumerable()
                .Select(s => new ImageComboBoxItem() { Description = String.Format("{0} ({1})", s.CODE, s.NAME), Value = s.CODE })
                .ToList());
            gridControlMapping.RepositoryItems.Add(_hotelCombo);      //per DX recommendation to avoid memory leaks

            _catCombo.Items.Add(loadBlank);
            _catCombo.Items.AddRange(_context.ROOMCOD
                .OrderBy(o => o.CODE).AsEnumerable()
                .Select(s => new ImageComboBoxItem() { Description = String.Format("{0} ({1})", s.CODE, s.DESC), Value = s.CODE })
                .ToList());
            gridControlMapping.RepositoryItems.Add(_catCombo);		//per DX recommendation to avoid memory leaks
        }

        private void buttonEditFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var result = openFileDialog.ShowDialog(this);
            if (result == DialogResult.OK) {
                buttonEditFile.Text = openFileDialog.FileName;
            }
        }

        private void MGMRatesImportForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _sys.Dispose();
            _context.Dispose();
        }

        private void SetControlState(bool enabled)
        {
            simpleButtonImport.Enabled = enabled;
            simpleButtonSave.Enabled = enabled;
            gridControlMapping.Enabled = enabled;
            buttonAddFromSelected.Enabled = enabled;
            buttonAddMapping.Enabled = enabled;
            buttonDeleteMapping.Enabled = enabled;
        }

        private void simpleButtonImport_Click(object sender, EventArgs e)
        {
            if (SaveMappings()) {
                if (dateEditEffectiveDate.EditValue != null && dateEditEffectiveDate.DateTime < DateTime.Today) {
                    this.DisplayError("Please specify an effective date of today or later, or leave blank.");
                    return;
                }
                if (dateEditExpirationDate.EditValue != null && dateEditExpirationDate.DateTime <= DateTime.Today) {
                    this.DisplayError("Please specify an expiration date after today, or leave blank.");
                    return;
                }
                if (dateEditExpirationDate.EditValue != null && dateEditEffectiveDate.EditValue != null
                    && dateEditExpirationDate.DateTime < dateEditEffectiveDate.DateTime) {
                    this.DisplayError("The expiration date must not be prior to the effective date.");
                    return;
                }
                if (File.Exists(buttonEditFile.Text)) {
                    this.Cursor = Cursors.WaitCursor;
                    SetControlState(false);
                    marqueeProgressBarControl1.Show();
                    _bgWorker.RunWorkerAsync(buttonEditFile.Text);
                }
                else {
                    this.DisplayError("Please specify a valid file to import.");
                }
            }
        }

        private void _bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            string fileName = e.Argument.ToString();
            FileInfo file = new FileInfo(fileName);
            _someRates = false;

            using (ExcelPackage xl = new ExcelPackage(file)) {
                var ws = xl.Workbook.Worksheets[1];
                string special = ws.Cells[4, 1].GetValue<string>();

                for (int col = 4; col < int.MaxValue; col += 4) {
                    if (worker.CancellationPending)
                        return;

                    string hotelName = ws.Cells[4, col].GetValue<string>();
                    if (string.IsNullOrEmpty(hotelName))
                        break;

                    //We don't know how many hotels there are in the spreadsheet, so we can't report a percentage,
                    // but we can display the hotel name
                    worker.ReportProgress(0, $"Reading {hotelName}...");
                    var mappings = _context.ImportMapping.Where(f => f.NameInSpreadsheet.ToLower() == hotelName.ToLower()
                        && !f.Inactive).ToList();

                    if (mappings?.Count > 0) {
                        string hotelCode = mappings.First().HOTEL.CODE;
                        var markups = _context.COMPROD2.Where(c =>
                            c.ImportRule && c.CODE == hotelCode && c.TYPE == "HTL" && !(bool)c.Inactive
                            && c.RecType == "M").ToList();

                        double dateNum = ws.Cells[6, 1].GetValue<double>();
                        DateTime date = DateTime.FromOADate(dateNum);
                        //Get matching existing rate sheets that will need to be deactivated
                        var rates = _context.HRATES.Where(h => !h.Inactive && h.CODE == hotelCode
                            && h.START_DATE >= date && h.ID > 0).ToList();

                        for (int row = 6; row < int.MaxValue; row++) {
                            dateNum = ws.Cells[row, 1].GetValue<double>();
                            if (dateNum == 0) {
                                string dateText = ws.Cells[row, 1].Text;
                                if (!DateTime.TryParse(dateText, out date))
                                    break;
                            }
                            else {
                                date = DateTime.FromOADate(dateNum);
                            }
                            bool stopSell = false;
                            //Try to handle whether the spreadsheet has rates formatted as number or currency
                            var usCulture = CultureInfo.CreateSpecificCulture("en-US");
                            if (!decimal.TryParse(ws.Cells[row, col].Text, out decimal currentRate)) {
                                decimal.TryParse(ws.Cells[row, col].Text, NumberStyles.Currency, usCulture, out currentRate);
                            }
                            if (!decimal.TryParse(ws.Cells[row, col + 2].Text, out decimal newRate)) {
                                if (!decimal.TryParse(ws.Cells[row, col + 2].Text, NumberStyles.Currency, usCulture, out newRate)) {
                                    //If there is some text in the cell but it is not a number, then treat it as a stopsell
                                    if (!string.IsNullOrEmpty(ws.Cells[row, col + 2].Text)) {
                                        stopSell = true;
                                    }
                                }
                            }

                            if (currentRate > 0 || newRate > 0) {
                                _someRates = true;
                                ImportRate(worker, mappings, rates, markups, special, date, currentRate, newRate, stopSell);
                            }
                        }
                    }
                }
                worker.ReportProgress(0, "Creating rates, please be patient...");

                //Starting with EF6 SaveChanges includes a transaction
                _context.SaveChanges();

                worker.ReportProgress(0, "Done");
                e.Result = true;        //if you don't set e.Result to something, RunWorkerCompleted event is never called
            }
        }

        private void ImportRate(BackgroundWorker worker, List<ImportMapping> mappings, List<HRATES> rates, 
            List<COMPROD2> markups, string special, DateTime date, decimal currentRate, decimal newRate, bool stopSell)
        {
            foreach (ImportMapping mapping in mappings) {
                if (worker.CancellationPending)
                    return;

                DeactivateOldRateSheets(rates, mapping.HOTEL.CODE, mapping.Cat, date);

                //If it is a stopsell, leave the old rate deactivated without adding a new rate
                if (!stopSell) {
                    //Now get the most specific markup for this cat or blank cat
                    var catMarkup = markups.Where(m => (m.CAT == mapping.Cat || string.IsNullOrEmpty(m.CAT))
                        && (m.START_DATE ?? DateTime.MinValue) <= date
                        && (m.END_DATE ?? DateTime.MaxValue) >= date && m.SpecificProduct).
                        OrderByDescending(m => m.CAT).
                        ThenBy(m => (m.END_DATE ?? DateTime.MaxValue).Subtract((m.START_DATE ?? DateTime.MinValue)).Days).
                        ThenBy(m => m.START_DATE).
                        FirstOrDefault();

                    decimal markupPct = (decimal)(catMarkup?.COMM_PCT ?? 0);
                    decimal markupFlat = catMarkup?.FlatAmount ?? 0;

                    var hrate = PopulateHRates(mapping, special, date, newRate, currentRate, markupPct, markupFlat);
                    _context.HRATES.AddObject(hrate);
                }
            }
        }

        private void DeactivateOldRateSheets(List<HRATES> rates, string code, string cat, DateTime date)
        {
            //Now get the matching ratesheets, if any. We are not interested in ones that have a wider date range,
            //because the first data entered is from the spreadsheets, so we don't have to split or deactivate
            //old ratesheets. We just want any active ratesheets that are for this date exactly, and they must
            //be deactivated because even if the new rates are identical, they have a new update code which must
            //be provided to the hotel with any reservation, and it goes in the special value field.
            var matchRates = rates.Where(h => h.CAT == cat && h.START_DATE == date && h.END_DATE == date);
            foreach (var rate in matchRates) {
                //If no effective date is specified, these rates will go live immediately, so deactivate all others
                if (dateEditEffectiveDate.EditValue == null) {
                    rate.Inactive = true;
                }
                else {
                    //If existing rate sheet had no end date, make it end the day before the new effective date,
                    //otherwise deactivate it. Because rates may be imported in advance with the effective date
                    //set in the future, this allows the existing rate sheets to continue to be effective until
                    //the new ones kick in. Then when the imports are run the next time, the ones which had their
                    //end date set on this run will be deactivated, an end date will be set for the ones which are 
                    //currently active, and the new ones will be set for the future.
                    if (rate.ResDate_End == null) {
                        var endDate = dateEditEffectiveDate.DateTime.AddDays(-1);
                        //If the rate is imported for an effective date prior to or the same as a previous effective date,
                        //that will leave the end date prior to the start date. In that case, make the start date equal to 
                        //the end date as well, so that the dates make sense and are both prior to the new effective date.
                        if (rate.ResDate_Start != null && endDate < rate.ResDate_Start) {
                            rate.ResDate_Start = endDate;
                        }
                        rate.ResDate_End = endDate;
                    }
                    else {
                        rate.Inactive = true;
                    }
                }
            }
        }

        private HRATES PopulateHRates(ImportMapping mapping, string special, DateTime date, 
            decimal newRate, decimal currentRate, decimal markupPct, decimal markupFlat)
        {
            string[] rateplan = Array.Empty<string>();
            if (!string.IsNullOrEmpty(special)) {
                rateplan = special.Split('-');
            }

            HRATES hrate = new HRATES();
            hrate.CODE = mapping.HOTEL.CODE;
            hrate.CAT = mapping.Cat;
            hrate.START_DATE = date;
            hrate.END_DATE = date;
            hrate.AGENCY = _sys.Settings.DefaultAgency;
            hrate.LAST_UPD = DateTime.Now;
            hrate.RATE_DESC = mapping.HOTEL.NAME;
            hrate.UPD_INIT = _sys.User.Name;
            if (rateplan.Length > 0) {
                if (rateplan[0].Trim().Length <= 16) {
                    hrate.SpecialValue_Code = rateplan[0].Trim();
                }
                if (rateplan[0].Trim().Length <= 64) {
                    //Use the code as the description by default
                    hrate.COMMENT1 = rateplan[0].Trim();
                    hrate.COMMENT2 = rateplan[0].Trim();
                }
            }
            //Overwrite the description with a description if there is one, and if the comment fields
            //are not required to hold the code (which would be if the code is longer than 16 chars)
            if (rateplan.Length > 1 && rateplan[0].Trim().Length <= 16 && rateplan[1].Trim().Length <= 64) {
                hrate.COMMENT1 = rateplan[1].Trim();
                hrate.COMMENT2 = rateplan[1].Trim();
            }
            hrate.YEAR = date.Year;
            if (dateEditEffectiveDate.EditValue != null) {
                hrate.ResDate_Start = dateEditEffectiveDate.DateTime;
            }
            if (dateEditExpirationDate.EditValue != null) {
                hrate.ResDate_End = dateEditExpirationDate.DateTime;
            }

            string day = date.ToString("ddd").ToLower();
            bool isWeekend = mapping.WeekendDays.ToLower().Contains(day);
            decimal taxRate = (decimal)((mapping.HOTEL.TAXRATE ?? 0) / 100);

            decimal baseCostBeforeTax = newRate > 0 ? newRate : currentRate;
            if (isWeekend) {
                baseCostBeforeTax += mapping.WeekendSurcharge ?? 0;
            }
            else {
                baseCostBeforeTax += mapping.WeekdaySurcharge ?? 0;
            }

            //We don't actually know whether CHD's markups are inclusive of tax, but probably not so add the tax
            //If there is a flat amount it is per room, so it will need to be divided by persons later
            decimal baseMarkupAfterTax = (markupFlat + (baseCostBeforeTax * (markupPct / 100))) * (1 + taxRate);
            decimal baseCostAfterTax = baseCostBeforeTax * (1 + taxRate);
            decimal surchargeBeforeTax = mapping.PerPersonSurcharge ?? 0;
            decimal surchargeAfterTax = surchargeBeforeTax * (1 + taxRate);
            decimal surchargeMarkupWithTax = (surchargeBeforeTax * (markupPct / 100)) * (1 + taxRate);

            decimal perPersonCostBeforeTax = baseCostBeforeTax;
            decimal perPersonCostAfterTax = baseCostAfterTax;
            int occupancy = 1;

            hrate.SglCostBeforeTax = Math.Round(perPersonCostBeforeTax, 2);
            hrate.SGL_NRATE = (float)Math.Round(perPersonCostAfterTax, 2);
            hrate.SGL_GRATE = (float)Math.Round(perPersonCostAfterTax + baseMarkupAfterTax, 2);

            occupancy = 2;
            //costBeforeTax = baseCostBeforeTax / occupancy;
            //costAfterTax = baseCostAfterTax / occupancy;
            //Find out at what occupancy the per person surcharge kicks in and multiply by the difference
            //in number of occupants for this occupancy level
            int perPersonMultiplier = occupancy - (mapping.BaseRateOccupancy ?? 1);
            perPersonCostBeforeTax = (baseCostBeforeTax + (surchargeBeforeTax * perPersonMultiplier)) / occupancy;
            perPersonCostAfterTax = (baseCostAfterTax + (surchargeAfterTax * perPersonMultiplier)) / occupancy;
            hrate.DblCostBeforeTax = Math.Round(perPersonCostBeforeTax, 2);
            hrate.DBL_NRATE = (float)Math.Round(perPersonCostAfterTax, 2);
            hrate.DBL_GRATE = (float)Math.Round(perPersonCostAfterTax + ((baseMarkupAfterTax + (surchargeMarkupWithTax * perPersonMultiplier)) / occupancy), 2);

            occupancy = 3;
            //costBeforeTax = baseCostBeforeTax / occupancy;
            //costAfterTax = baseCostAfterTax / occupancy;
            perPersonMultiplier = occupancy - (mapping.BaseRateOccupancy ?? 1);
            perPersonCostBeforeTax = (baseCostBeforeTax + (surchargeBeforeTax * perPersonMultiplier)) / occupancy;
            perPersonCostAfterTax = (baseCostAfterTax + (surchargeAfterTax * perPersonMultiplier)) / occupancy;
            hrate.TplCostBeforeTax = Math.Round(perPersonCostBeforeTax, 2);
            hrate.TPL_NRATE = (float)Math.Round(perPersonCostAfterTax, 2);
            hrate.TPL_GRATE = (float)Math.Round(perPersonCostAfterTax + ((baseMarkupAfterTax + (surchargeMarkupWithTax * perPersonMultiplier)) / occupancy), 2);

            occupancy = 4;
            //costBeforeTax = baseCostBeforeTax / occupancy;
            //costAfterTax = baseCostAfterTax / occupancy;
            perPersonMultiplier = occupancy - (mapping.BaseRateOccupancy ?? 1);
            perPersonCostBeforeTax = (baseCostBeforeTax + (surchargeBeforeTax * perPersonMultiplier)) / occupancy;
            perPersonCostAfterTax = (baseCostAfterTax + (surchargeAfterTax * perPersonMultiplier)) / occupancy;
            hrate.QuaCostBeforeTax = Math.Round(perPersonCostBeforeTax, 2);
            hrate.QUA_NRATE = (float)Math.Round(perPersonCostAfterTax, 2);
            hrate.QUA_GRATE = (float)Math.Round(perPersonCostAfterTax + ((baseMarkupAfterTax + (surchargeMarkupWithTax * perPersonMultiplier)) / occupancy), 2);

            hrate.CHD_LIMIT = mapping.FreeAgeLimit.ToString();

            //If the rate was marked up by an import rule, don't apply further markups in availability checks
            hrate.MarkupAllowed = !(markupFlat > 0 || markupPct > 0);

            //Pull the max occs from the hotel if nothing is specified on the import
            if ((mapping.MaxOccupancy ?? 0) > 0) {
                hrate.MAX_SGL = mapping.MaxOccupancy;
                hrate.MAX_DBL = mapping.MaxOccupancy;
                hrate.MAX_TPL = mapping.MaxOccupancy;
                hrate.MAX_QUA = mapping.MaxOccupancy;
            }
            else {
                hrate.MAX_SGL = mapping.HOTEL.MAX_SGL;
                hrate.MAX_DBL = mapping.HOTEL.MAX_DBL;
                hrate.MAX_TPL = mapping.HOTEL.MAX_TPL;
                hrate.MAX_QUA = mapping.HOTEL.MAX_QUA;
            }

            DefaultUnusedFields(hrate);
            return hrate;
        }

        private void DefaultUnusedFields(HRATES hrate)
        {
            hrate.H_L = "1";        //doesn't mean anything
            hrate.CHD_GRATE = 0;
            hrate.CHD_NRATE = 0;
            hrate.JR_GRATE = 0;
            hrate.JR_NRATE = 0;
            hrate.JR_LIMIT = string.Empty;
            hrate.OTH_GRATE = 0;
            hrate.OTH_NRATE = 0;
            hrate.MAX_OTH = 0;
            hrate.ChdCostBeforeTax = 0;
            hrate.OthCostBeforeTax = 0;
            hrate.JrCostBeforeTax = 0;
            hrate.SOthCostBeforeTax = 0;
            hrate.SChdCostBeforeTax = 0;
            hrate.SJrCostBeforeTax = 0;
            hrate.MEAL1_CODE = string.Empty;
            hrate.MEAL1_ADG = 0;
            hrate.MEAL1_ADN = 0;
            hrate.MEAL2_CODE = string.Empty;
            hrate.MEAL2_ADG = 0;
            hrate.MEAL2_ADN = 0;
            hrate.MEAL3_CODE = string.Empty;
            hrate.MEAL3_ADG = 0;
            hrate.MEAL3_ADN = 0;
            hrate.MEAL4_CODE = string.Empty;
            hrate.MEAL4_ADG = 0;
            hrate.MEAL4_ADN = 0;
            hrate.MEAL5_CODE = string.Empty;
            hrate.MEAL5_ADG = 0;
            hrate.MEAL5_ADN = 0;
            hrate.COMM_FLG = "Y";
            hrate.COMM_PCT = 0;
            hrate.SSGL_GRATE = 0;
            hrate.SSGL_NRATE = 0;
            hrate.SDBL_NRATE = 0;
            hrate.SDBL_GRATE = 0;
            hrate.STPL_NRATE = 0;
            hrate.STPL_GRATE = 0;
            hrate.SQUA_NRATE = 0;
            hrate.SQUA_GRATE = 0;
            hrate.SOTH_NRATE = 0;
            hrate.SOTH_GRATE = 0;
            hrate.SCHD_NRATE = 0;
            hrate.SCHD_GRATE = 0;
            hrate.SCHD_LIMIT = string.Empty;
            hrate.SJR_NRATE = 0;
            hrate.SJR_GRATE = 0;
            hrate.SJR_LIMIT = string.Empty;
            hrate.SMEAL1_ADG = 0;
            hrate.SMEAL1_ADN = 0;
            hrate.SMEAL2_ADG = 0;
            hrate.SMEAL2_ADN = 0;
            hrate.SMEAL3_ADG = 0;
            hrate.SMEAL3_ADN = 0;
            hrate.SMEAL4_ADG = 0;
            hrate.SMEAL4_ADN = 0;
            hrate.SMEAL5_ADG = 0;
            hrate.SMEAL5_ADN = 0;
            hrate.SCOMM_FLG = string.Empty;
            hrate.SCOMM_PCT = 0;
            hrate.SUN_FLG = "0";
            hrate.MON_FLG = "0";
            hrate.TUE_FLG = "0";
            hrate.WED_FLG = "0";
            hrate.THU_FLG = "0";
            hrate.FRI_FLG = "0";
            hrate.SAT_FLG = "0";
            hrate.OVRCOMM_PCT = 0;
            hrate.NightsPay = 0;
            hrate.NightsStay = 0;
            hrate.Inactive = false;
            hrate.RepeatCount = 0;
            hrate.Inhouse = false;
            hrate.MarkupPct = 0;
        }

        private void buttonDeleteMapping_Click(object sender, EventArgs e)
        {
            try {
                if (gridViewMapping.FocusedRowHandle >= 0) {
                    ImportMapping mapping = (ImportMapping)gridViewMapping.GetFocusedRow();
                    importMappingBindingSource.Remove(mapping);
                    BindMappings();
                }
            }
            catch (Exception ex) {
                this.DisplayError(ex);
            }
        }

        private void buttonAddMapping_Click(object sender, EventArgs e)
        {
            try {
                ImportMapping mapping = new ImportMapping();
                mapping.Type = "HTL";
                importMappingBindingSource.Add(mapping);
                BindMappings();
                gridViewMapping.FocusedRowHandle = importMappingBindingSource.Count - 1;
            }
            catch (Exception ex) {
                this.DisplayError(ex);
            }
        }

        void BindMappings()
        {
            gridControlMapping.DataSource = importMappingBindingSource;
            gridControlMapping.RefreshDataSource();
        }

        private void simpleButtonSave_Click(object sender, EventArgs e)
        {
            if (SaveMappings()) {
                ShowActionConfirmation("Mappings Saved", simpleButtonSave.Left + simpleButtonSave.Width + 10, simpleButtonSave.Top +
                ((simpleButtonSave.Height - panelControlStatus.Height) / 2));
            }
        }

        private bool SaveMappings()
        {
            try {
                importMappingBindingSource.EndEdit();
                gridViewMapping.CloseEditor();
                gridViewMapping.UpdateCurrentRow();

                if (importMappingBindingSource.List.Count > 0) {
                    var mappings = importMappingBindingSource.List.Cast<ImportMapping>();
                    foreach (var mapping in mappings) {
                        if (!mapping.Inactive && !mapping.Validate()) {
                            this.DisplayError(mapping.Error);
                            return false;
                        }
                    }
                    var dups = mappings.GroupBy(x => new { x.Code, x.Cat })
                        .Where(x => x.Skip(1).Any());
                    if (dups.Any()) {
                        this.DisplayError($@"There is a duplicate mapping for {dups.First().Key.Code} {dups.First().Key.Cat}.
Please resolve it and try again.");
                        return false;
                    }
                }

                _context.SaveChanges();
                return true;
            }
            catch (Exception ex) {
                this.DisplayError(ex);
                return false;
            }
        }

        private void gridViewMapping_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column == colCat) {
                e.RepositoryItem = _catCombo;
            }
            else if (e.Column == colCode) {
                e.RepositoryItem = _hotelCombo;
            }
        }

        private void ShowActionConfirmation(string confirmation, int leftPos, int topPos)
        {
            panelControlStatus.Left = leftPos;
            panelControlStatus.Top = topPos;
            panelControlStatus.Visible = true;
            LabelStatus.Text = confirmation;
            _actionConfirmation = new Timer();
            _actionConfirmation.Interval = 3000;
            _actionConfirmation.Start();
            _actionConfirmation.Tick += TimedEvent;
        }

        private void TimedEvent(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            _actionConfirmation.Stop();
        }

        private void buttonAddFromSelected_Click(object sender, EventArgs e)
        {
            if (gridViewMapping.FocusedRowHandle >= 0) {
                var mapping = (ImportMapping)gridViewMapping.GetRow(gridViewMapping.FocusedRowHandle);
                var newMapping = mapping.Clone();
                importMappingBindingSource.Add(newMapping);
                BindMappings();
                gridViewMapping.FocusedRowHandle = importMappingBindingSource.Count - 1;
            }
        }

        private void _bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Default;
            SetControlState(true);
            marqueeProgressBarControl1.Hide();
            if (e.Cancelled || e.Error != null) {
                //Rollback records added or deactivated in HRATES but not committed to the db, 
                //easiest way is just to dispose and recreate the context
                _context.Dispose();
                Connect(_sys);
            }
            if (e.Cancelled) {
                return;
            }
            if (e.Error != null) {
                this.DisplayError(e.Error);
                return;
            }
            if (_someRates) {
                ShowActionConfirmation("Rates imported", (Width - panelControlStatus.Width) / 2, marqueeProgressBarControl1.Top);
            }
            else {
                this.DisplayWarning("No rates were found to import");
            }
        }

        private void _bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            marqueeProgressBarControl1.Text = e.UserState.ToString();
        }

        private void MGMRatesImportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _bgWorker.CancelAsync();
        }

        private void simpleButtonExcludeAll_Click(object sender, EventArgs e)
        {
            foreach (ImportMapping mapping in importMappingBindingSource.List) {
                mapping.Inactive = true;
            }
        }

        private void simpleButtonIncludeAll_Click(object sender, EventArgs e)
        {
            foreach (ImportMapping mapping in importMappingBindingSource.List) {
                mapping.Inactive = false;
            }
        }

        private void simpleButtonToggle_Click(object sender, EventArgs e)
        {
            foreach (ImportMapping mapping in importMappingBindingSource.List) {
                mapping.Inactive = !mapping.Inactive;
            }
        }
    }
}