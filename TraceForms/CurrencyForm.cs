using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using FlexModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TraceForms
{
    /// <summary>
    /// Enables downloading Currency and CurrencyExchangeRate data from openexchangerates.org API via JSON.
    /// Allows Currency and CurrencyExchangeRate records in DB to be viewed, edited and created.
    /// </summary>
    public partial class CurrencyForm : DevExpress.XtraEditors.XtraForm
    {
        public bool modifiedCurrency = false;
        public bool newCurrencyRec = false;
        public bool modifiedRate = false;
        public bool newRateRec = false;
        public bool temp = false;
        const string colName1 = "colCode";
        const string colName2 = "colName";
        const string colName3 = "colCodeFrom";
        const string APIName = "openexchangerates.org";
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public bool ignoreLeaveRow = false, ignorePositionChange = false, ignoreRateBindingChange = false;
        public Currency _selectedCurrencyRecord;
        public CurrencyExchangeRate _selectedExchangeRateRecord;
        public Timer actionConfirmation;
        public List<int> newRateIndices = new List<int>();
        public List<int> modifiedRateIndices = new List<int>();
        public string imagesRoot;
        RepositoryItemImageComboBox currencyCodeFromRepository = new RepositoryItemImageComboBox();

        FlextourEntities context;
        Dictionary<string, List<CurrencyExchangeRate>> _exchangeRateLookups = new Dictionary<string, List<CurrencyExchangeRate>>();

        public CurrencyForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);

            imagesRoot = sys.Settings.ImagesRoot;

            // only get data from JSON API if Currency table is empty
            if (CurrencyBindingSource.Count == 0)
                GetJsonCurrenciesAsync();

            LoadLookups();
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);
            // this binding source is used for all database access to Currency table
            CurrencyBindingSource.DataSource = context.Currency.OrderBy(o => o.Code);
            // this binding source is only used when getting exchange rate data from API, CurrToExRateBindingSource is updated whenever the user selects a currency
            CurrencyExchangeRateBindingSource.DataSource = context.CurrencyExchangeRate.OrderBy(o => o.Currency_Code_To);   
        }

        private void LoadLookups()
        {
            CurrencyBindingNavigator.BackColor = BackColor;     //match the DevExpress style
            setReadOnly(true);
            enableNavigator(true);

            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = string.Empty };

            // get list of currency codes for codeFrom field in GridViewRates
            List<ImageComboBoxItem> currencyCodesLookup = context.Currency
                .OrderBy(o => o.Code)
                .AsEnumerable()
                .Select(s => new ImageComboBoxItem() { Description = string.Format("{0} - {1}", s.Code, s.Name), Value = s.Code })
                .ToList();
            currencyCodeFromRepository.Items.Clear();
            currencyCodeFromRepository.Items.AddRange(currencyCodesLookup);
            GridControlRates.RepositoryItems.Clear();
            GridControlRates.RepositoryItems.Add(currencyCodeFromRepository);   //per DX recommendation to avoid memory leaks

            List<ImageComboBoxItem> countryCodesLookup = context.COUNTRY
                .OrderBy(o => o.CODE)
                .AsEnumerable()
                .Select(s => new ImageComboBoxItem() { Description = string.Format("{0} - {1}", s.CODE.TrimEnd(), s.NAME.TrimEnd()), Value = s.CODE.TrimEnd() })
                .ToList();
            ImageComboBoxEditCountry.Properties.Items.Clear();
            ImageComboBoxEditCountry.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCountry.Properties.Items.AddRange(countryCodesLookup);
        }

        // Used in order to adjust currency rates coming from JSON API.
        private float calculateAdjustedRate(float originalRate)
        {
            float adjustedRate = 0;

            if (_selectedCurrencyRecord != null) {
                float adjustPercent = (float)(_selectedCurrencyRecord.AdjustPercent ?? 0);  // could be from -999.99 to 999.99
                adjustedRate = originalRate + (originalRate * adjustPercent / 100);
            }

            return adjustedRate;
        }

        private async void GetJsonExchangeRatesAsync()
        {
            try {
                // TODO: make this url configurable
                var url = "https://openexchangerates.org/api/latest.json?app_id=0b6cf8d6abbd41de9fb8a6cb5ef082b1";
                // only enable when rates loaded from JSON API
                GridControlCurrency.Enabled = false;
                // will time out automatically if internet connection down
                var currencyExchangeRates = await DownloadSerializedJsonDataAsync<CurrencyExchangeRateJson>(url);
                var errorCounter = 0;
                var duplicates = 0;

                var ratesFrom = currencyExchangeRates._base;
                var timestamp = currencyExchangeRates.timestamp;
                Dictionary<string, float> rates = currencyExchangeRates.rates;
                DateTime dateTimeZero = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                List<CurrencyExchangeRate> rateItems = new List<CurrencyExchangeRate>();

                if (rates.Count() > 0) {
                    foreach (var r in rates) {
                        CurrencyExchangeRate rateItem = new CurrencyExchangeRate();
                        rateItem.Currency_Code_From = ratesFrom;
                        rateItem.Currency_Code_To = r.Key;
                        rateItem.Rate = (decimal)calculateAdjustedRate(r.Value);
                        rateItem.Timestamp = dateTimeZero.AddSeconds(timestamp);
                        rateItem.Fixed = false;

                        // Don't update if item is fixed, skip duplicates - don't annoy, confuse, intimidate user if he/she tries to update exchange rates too frequently
                        if (!rateItem.CheckFixed() && !rateItem.IsDuplicate()) {
                            // validate each entry
                            if (rateItem.Validate())
                                rateItems.Add(rateItem);
                            else if (errorCounter == 0) {
                                errorCounter++;
                                var errorMessage = "";
                                foreach (var e in rateItem.Errors) {
                                    errorMessage += e.Key + ": " + e.Value + "\n";
                                }
                                DisplayHelper.DisplayError(this, errorMessage);
                            }
                            // don't torture the user by displaying a message for each error in the JSON
                            else
                                break;
                        }
                    }

                    // check for duplicates in JSON data
                    if (errorCounter == 0) {
                        duplicates = rateItems.GroupBy(g => new { g.Currency_Code_From, g.Currency_Code_To }).Where(w => w.Count() > 1).Count();
                        if (duplicates != 0)
                            DisplayHelper.DisplayError(this, "JSON data contains duplicates.");
                    }

                    // only save to DB if every value is validated
                    if (errorCounter == 0 && duplicates == 0) {
                        //CurrencyExchangeRateBindingSource  // in case this method is called more than once
                        rateItems.ForEach(r => CurrencyExchangeRateBindingSource.Add(r));
                        context.SaveChanges();
                        SetBindings(CurrencyBindingSource);
                    }
                }
                else
                    DisplayHelper.DisplayError(this, "Cannot access remote API, url: " + url);  // no currencies retrieved from JSON API
                GridControlCurrency.Enabled = true;
            }
            catch (Exception ex) {
                string message = ex.Message;
                if (message.Contains("inner exception"))
                    message = ex.InnerException.Message;
                XtraMessageBox.Show(message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                GridControlCurrency.Enabled = true;
            }
        }

        // Will get exchange rates as well if CurrencyExchangeRate table is empty
        private async void GetJsonCurrenciesAsync()
        {
            try { 
                // TODO: make this url configurable
                var url = "https://openexchangerates.org/api/currencies.json";
                // only enable when currencies loaded from JSON API
                GridControlCurrency.Enabled = false;
                // will time out automatically if internet connection down
                var currencies = await DownloadSerializedJsonDataAsync<Dictionary<string, string>>(url);
                var errorCounter = 0;
                var duplicates = 0;
                List<Currency> currencyItems = new List<Currency>();

                if (currencies.Count > 0) {
                    foreach (var c in currencies) {
                        Currency currencyItem = new Currency();
                        currencyItem.Code = c.Key;
                        currencyItem.Name = c.Value;
                        currencyItem.Inactive = false;
                        // just skip duplicates - there might be new currencies added to the list, or a record might have been deleted (directly in MSSMS)
                        if (!currencyItem.IsDuplicate()) {
                            // validate each entry
                            if (currencyItem.Validate())
                                currencyItems.Add(currencyItem);
                            else if (errorCounter == 0) {
                                errorCounter++;
                                var errorMessage = "";
                                foreach (var e in currencyItem.Errors) {
                                    errorMessage += e.Key + ": " + e.Value + "\n";
                                }
                                DisplayHelper.DisplayError(this, errorMessage);
                            }
                            // don't torture the user by displaying a message for each error in the JSON
                            else
                                break;
                        }
                    }

                    // check for duplicates in JSON data
                    if (errorCounter == 0) {
                        duplicates = currencyItems.GroupBy(g => new { g.Code }).Where(w => w.Count() > 1).Count();
                        if (duplicates != 0)
                            DisplayHelper.DisplayError(this, "JSON data contains duplicates.");
                    }

                    // only save to DB if every value is validated
                    if (errorCounter == 0 && duplicates == 0) {
                        currencyItems.ForEach(c => CurrencyBindingSource.Add(c));
                        context.SaveChanges();
                        CurrencyBindingSource.DataSource = context.Currency.OrderBy(o => o.Code);
                        BindCurrency();
                        // only get data from JSON API if CurrencyExchangeRate table is empty
                        if (CurrencyExchangeRateBindingSource.Count == 0)
                            GetJsonExchangeRatesAsync();
                        LoadLookups();
                    }
                }
                else
                    DisplayHelper.DisplayError(this, "Cannot access remote API, url: " + url);  // no currencies retrieved from JSON API
                GridControlCurrency.Enabled = true;
            }
            catch (Exception ex) {
                string message = ex.Message;
                if (message.Contains("inner exception"))
                    message = ex.InnerException.Message;
                XtraMessageBox.Show(message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                GridControlCurrency.Enabled = true;
            }
        }

        private void BindCurrency()
        {
            GridControlCurrency.DataSource = CurrencyBindingSource;
            GridControlCurrency.RefreshDataSource();
        }

        private static async Task<T> DownloadSerializedJsonDataAsync<T>(string url) where T : new()
        {
            using (var w = new WebClient()) {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try {
                    json_data = await w.DownloadStringTaskAsync(url);
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }

        // Used to hold data coming from JSON API.
        private class CurrencyExchangeRateJson
        {
            public string disclaimer { get; set; }
            public string license { get; set; }
            public int timestamp { get; set; }
            [JsonProperty("base")]
            public string _base { get; set; }
            public Dictionary<string, float> rates { get; set; }
        }

        void enableNavigator(bool value)
        {
            bindingNavigatorMoveNextItem.Enabled = value;
            bindingNavigatorMoveLastItem.Enabled = value;
            bindingNavigatorMoveFirstItem.Enabled = value;
            bindingNavigatorMovePreviousItem.Enabled = value;
        }

        private void setReadOnly(bool value)
        {
            codeTextEdit.Properties.ReadOnly = value;
            nameTextEdit.Properties.ReadOnly = value;
            GridViewRates.Columns.ColumnByName(colName3).OptionsColumn.AllowEdit = !value;
        }

        // Push changes in controls back to binding source for validation, raising error messages.
        // Called when leaving controls and when clicking on Save.
        private void SetErrorInfo(Func<String> validationMethod, object sender, BindingSource bindingSource)
        {
            bindingSource.EndEdit();        //force changes back into context for validation

            if (bindingSource == CurrencyBindingSource) {
                if ((validationMethod != null) && (modifiedCurrency || newCurrencyRec)) {   // don't validate if no changes made
                    string error = validationMethod.Invoke();
                    errorProvider1.SetError((Control)sender, error);
                }
            }
            else if (bindingSource == CurrToExRateBindingSource) {  // never used - the only control which contains exchange rate data is a GridView, whose error notifications are set automatically
                if ((validationMethod != null) && (modifiedRate || newRateRec)) {   
                    string error = _selectedExchangeRateRecord.Error;   
                    errorProvider1.SetError((Control)sender, error);
                }
            }
        }

        private void RemoveRecords()
        {
            if (newCurrencyRec)
                CurrencyBindingSource.RemoveCurrent();
            if (newRateRec) {   // can be multiple new exchange rates for a given currency
                newRateIndices.ForEach(i => CurrToExRateBindingSource.RemoveAt(i));
            }
        }

        // Used when save fails, restoring modified values back to original values in DB
        private void RefreshRecords()
        {
            try {
                if (_selectedCurrencyRecord != null && !string.IsNullOrEmpty(_selectedCurrencyRecord.Code)) {
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, _selectedCurrencyRecord);
                }
                modifiedRateIndices.ForEach(i => {
                    if (((CurrencyExchangeRate)CurrToExRateBindingSource[i]).ID != 0)
                        context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, CurrToExRateBindingSource[i]);
                    else {  // cannot refresh items that have not been saved to DB yet
                        context.DeleteObject(CurrToExRateBindingSource[i]);
                        CurrToExRateBindingSource.RemoveAt(i);
                    }
                });
            }
            catch { }
        }

        // Necessary in order to ensure that changes in controls are saved.
        private void FinalizeBindings()
        {
            GridViewRates.CloseEditor();
            GridViewRates.UpdateCurrentRow();
            CurrToExRateBindingSource.EndEdit();
            GridViewCurrency.CloseEditor();
            GridViewCurrency.UpdateCurrentRow();  
            CurrencyBindingSource.EndEdit(); 
        }

        private void ShowActionConfirmation(string confirmation)
        {
            panelControlStatus.Visible = true;
            LabelStatus.Text = confirmation;
            actionConfirmation = new Timer();
            actionConfirmation.Interval = 3000;
            actionConfirmation.Start();
            actionConfirmation.Tick += TimedEvent;
        }

        private void TimedEvent(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            actionConfirmation.Stop();
        }

        // Validates all changed Currency and CurrencyExchangeRate records 
        private void ValidateAll()
        {
            List<int> relevantExchangeRateIndices = new List<int>();
            relevantExchangeRateIndices.AddRange(modifiedRateIndices);
            relevantExchangeRateIndices.AddRange(newRateIndices);
            // validate modified and new exchange rates
            relevantExchangeRateIndices.ForEach(i =>
            {
                if (!((CurrencyExchangeRate)CurrToExRateBindingSource[i]).Validate()) {
                    // The error indicators inside the grids are handled by binding - no need to call ValidateControls()
                    setReadOnly(false); // allow editing to correct error
                    throw new Exception("Errors were found. Please resolve them and try again.");
                }
            });

            if (!_selectedCurrencyRecord.Validate()) {
                ValidateControls();
                setReadOnly(false); // allow editing to correct error
                throw new Exception("Errors were found. Please resolve them and try again.");
            }
            else {
                errorProvider1.Clear();
            }
        }

        // Set error info for all non-GridView controls, calling relevant validation method in Currency class
        private void ValidateControls()
        {
            //The error indicators inside the grids are handled by binding, but errors on the main form must
            //be set manually
            SetErrorInfo(_selectedCurrencyRecord.ValidateCode, codeTextEdit, CurrencyBindingSource);
            SetErrorInfo(_selectedCurrencyRecord.ValidateName, nameTextEdit, CurrencyBindingSource);
            SetErrorInfo(_selectedCurrencyRecord.ValidateSymbol, symbolTextEdit, CurrencyBindingSource);
            SetErrorInfo(_selectedCurrencyRecord.ValidateFormatString, formatStringTextEdit, CurrencyBindingSource);
            SetErrorInfo(_selectedCurrencyRecord.ValidateCountryCode, ImageComboBoxEditCountry, CurrencyBindingSource);
            SetErrorInfo(_selectedCurrencyRecord.ValidateLocalName, localNameTextEdit, CurrencyBindingSource);
            SetErrorInfo(_selectedCurrencyRecord.ValidateAdjustPercent, adjustPercentTextEdit, CurrencyBindingSource);
            SetErrorInfo(_selectedCurrencyRecord.ValidateImagePath, buttonEditImagePath, CurrencyBindingSource);
        }

        // Called by save button as well as when navigating within Currency gridview.
        private bool SaveRecord(bool prompt)
        {
            try {
                if (_selectedCurrencyRecord == null)
                    return true;

                bool relevantModification = false;
                bool relevantNewRecord = false;
                if (newCurrencyRec || newRateRec)
                    relevantNewRecord = true;
                if (modifiedCurrency || modifiedRate)
                    relevantModification = true;

                // Call to make sure the modified flag is set, because the Save button doesn't take focus so the Leave event
                // won't fire on the active control
                //SetErrorInfo(null, ActiveControl, CurrencyBindingSource);   

                if (relevantNewRecord)
                    setReadOnly(true);

                if (relevantModification || relevantNewRecord) {
                    if (prompt) {
                        DialogResult result = DevExpress.XtraEditors.XtraMessageBox.Show("Do you want to confirm these changes?",
                            this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (result == System.Windows.Forms.DialogResult.No) {
                            if (relevantNewRecord)
                                RemoveRecords();
                            if (relevantModification)
                                RefreshRecords();

                            modifiedCurrency = false;
                            newCurrencyRec = false;
                            modifiedRate = false;
                            newRateRec = false;
                            modifiedRateIndices.Clear();
                            newRateIndices.Clear();

                            return true;
                        }
                        if (result == System.Windows.Forms.DialogResult.Cancel) {
                            return false;
                        }
                    }   
                }

                FinalizeBindings();

                if (relevantModification || relevantNewRecord) {
                    // cannot really modify a CurrencyExchangeRate row - create a new one with a new timestamp, even though on GridView it appears as a modification
                    List<int> newModifiedRateIndices = new List<int>();
                    modifiedRateIndices.ForEach(i =>
                    {
                        CurrencyExchangeRate rateRecord = new CurrencyExchangeRate();
                        rateRecord = ((CurrencyExchangeRate)CurrToExRateBindingSource[i]).CustomClone(DateTime.Now);
                        context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, CurrToExRateBindingSource[i]);   // undo changes to currently selected record
                        
                        context.CurrencyExchangeRate.AddObject(rateRecord); // add new item to DB instead
                        _selectedExchangeRateRecord = rateRecord;
                        // add to binding source for validation
                        ignoreRateBindingChange = true; // do not handle binding source change 
                        CurrToExRateBindingSource.Add(_selectedExchangeRateRecord);
                        ignoreRateBindingChange = false;
                        newModifiedRateIndices.Add(CurrToExRateBindingSource.Count - 1);
                    });

                    // need to validate newly created modified records
                    modifiedRateIndices.Clear();
                    modifiedRateIndices.AddRange(newModifiedRateIndices);
                    ValidateAll();

                    newRateIndices.ForEach(i =>
                    {
                        context.CurrencyExchangeRate.AddObject((CurrencyExchangeRate)CurrToExRateBindingSource[i]);
                    });

                    context.SaveChanges();
                    ShowActionConfirmation("Record Saved");
                    modifiedCurrency = false;
                    newCurrencyRec = false;
                    modifiedRate = false;
                    newRateRec = false;
                    SetBindings(CurrencyBindingSource); // need to reload exchange rate data from DB - RefreshRecord will not do that for modifications
                    newRateIndices.Clear(); // used to keep track of unsaved, new exchange rates
                    modifiedRateIndices.Clear(); // used to keep track of unsaved, modified exchange rates
                }
                return true;
            }
            catch (Exception ex) {
                string message = ex.Message;
                if (message.Contains("inner exception")) {
                    message = ex.InnerException.Message;
                }
                XtraMessageBox.Show(message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                RefreshRecords();       //pull it back from db because that is its current state
                //newRateIndices.Clear(); // used to keep track of unsaved, new exchange rates
                modifiedRateIndices.Clear();
                modifiedCurrency = false;
                modifiedRate = false;
                //SetBindings(CurrencyBindingSource);         //We must also Load and rebind the related entities from the db because context.Refresh doesn't do that
                return false;
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            ignoreLeaveRow = true;       //so that when the grid row changes it doesn't try to save again
            if (SaveRecord(true)) {
                GridViewCurrency.ClearColumnsFilter();
                GridViewCurrency.ClearSorting();    // otherwise could focus wrong column below
                newCurrencyRec = true;
                CurrencyBindingSource.AddNew();
                GridViewCurrency.FocusedRowHandle = GridViewCurrency.RowCount - 1;
                codeTextEdit.Focus();
                setReadOnly(false);
            }
            ignoreLeaveRow = false;
        }

        private void buttonAddRate_Click(object sender, EventArgs e)
        {
            //ignoreLeaveRow = true;       //so that when the grid row changes it doesn't try to save again
            //if (SaveRecord(true, CurrToExRateBindingSource)) {
            GridViewRates.ClearColumnsFilter();
            GridViewRates.ClearSorting();   // otherwise could focus wrong column below
            newRateRec = true;
            CurrToExRateBindingSource.AddNew();
            var currentIndex = CurrToExRateBindingSource.Count - 1;
            if (!newRateIndices.Contains(currentIndex)) // don't add twice
                newRateIndices.Add(currentIndex);
            GridViewRates.FocusedRowHandle = GridViewRates.RowCount - 1;   
            setReadOnly(false);
            //}
            //ignoreLeaveRow = false;
        }

        // When a new/modified rate is deleted, this method adjusts the lists that keep track of new/modified rates
        private void AdjustRateIndicesForDeletion(int rowHandle) {
            List<int> tmpModifiedRateIndices = new List<int>();
            List<int> tmpNewRateIndices = new List<int>();

            modifiedRateIndices.ForEach(i => {
                if (i < rowHandle)
                    tmpModifiedRateIndices.Add(i);
                else if (i > rowHandle)
                    tmpModifiedRateIndices.Add(i - 1);
            });

            newRateIndices.ForEach(i =>
            {
                if (i < rowHandle)
                    tmpNewRateIndices.Add(i);
                else if (i > rowHandle)
                    tmpNewRateIndices.Add(i - 1);
            });

            modifiedRateIndices.Clear();
            newRateIndices.Clear();
            modifiedRateIndices.AddRange(tmpModifiedRateIndices);
            newRateIndices.AddRange(tmpNewRateIndices);
        }

        private void buttonDeleteRate_Click(object sender, EventArgs e)
        {
            if (GridViewRates.FocusedRowHandle >= 0) {
                CurrencyExchangeRate rateToDelete = (CurrencyExchangeRate)GridViewRates.GetFocusedRow();
                AdjustRateIndicesForDeletion(GridViewRates.FocusedRowHandle);
                CurrToExRateBindingSource.Remove(rateToDelete);
                //Removing from the bindingsource just removes the object from its parent, but does not mark
                //it for deletion, effectively orphaning it.  This will cause foreign key errors when saving.
                //To flag for deletion, delete it from the context as well.
                if (rateToDelete.ID != 0)
                    context.CurrencyExchangeRate.DeleteObject(rateToDelete);
                modifiedRate = true;
            }
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord(false))
                RefreshRecords();
        }

        // When a currency is deleted, all exchange rates that reference it are deleted as well.
        private void DeleteAssociatedExchangeRates(string code)
        {
            // exchange rates to the given code
            var currencyToList = context.CurrencyExchangeRate
                    .AsEnumerable()
                    .Select(s => s)
                    .Where(w => w.Currency_Code_To == code)
                    .ToList();

            // exchange rates from the given code
            var currencyFromList = context.CurrencyExchangeRate
                .AsEnumerable()
                .Select(s => s)
                .Where(w => w.Currency_Code_From == code)
                .ToList();
            // delete all exchange rates from the DB that have the given codeTo
            currencyFromList.ForEach(c => context.DeleteObject(c));
            currencyToList.ForEach(c => context.DeleteObject(c));
        }

        // Only called when deleting a Currency record.
        private void DeleteRecord()
        {
            if (_selectedCurrencyRecord == null) return;

            try {
                if (XtraMessageBox.Show(
                    "This currency and all the exchange rates associated with it will be deleted. Are you sure this is what you want to do?"
                    , this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {

                    ignoreLeaveRow = true;
                    ignorePositionChange = true;    // don't execute binding source changed code

                    DeleteAssociatedExchangeRates(_selectedCurrencyRecord.Code);   
                    context.DeleteObject(_selectedCurrencyRecord);
                    //CurrencyBindingSource.Remove(_selectedCurrencyRecord);
                    errorProvider1.Clear();
                    context.SaveChanges();

                    ignoreLeaveRow = false;
                    ignorePositionChange = false;
                    modifiedCurrency = false;
                    newCurrencyRec = false;
                    modifiedRate = false;
                    newRateRec = false;
                    modifiedRateIndices.Clear();
                    newRateIndices.Clear();
                    
                    ShowActionConfirmation("Record Deleted");

                    ClearBindings();
                    SetBindings(CurrencyBindingSource);
                }
            }
            catch (Exception ex) {
                string message = ex.Message;
                if (message.Contains("inner exception")) {
                    message = ex.InnerException.Message;
                }
                XtraMessageBox.Show(message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                RefreshRecords();        //pull it back from db because that is its current state
                                        //We must also Load and rebind the related entities from the db because context.Refresh doesn't do that
                SetBindings(CurrencyBindingSource);
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DeleteRecord();
            LoadLookups();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord(true))
                CurrencyBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord(true))
                CurrencyBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord(true))
                CurrencyBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord(true))
                CurrencyBindingSource.MoveLast();
        }

        private void gridViewCurrency_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            //If the user selects a row, edits, then selects the auto-filter row, then selects a different row,
            //this event will fire for the auto-filter row, so we cannot ignore it because there is still a record
            //that may need to be saved. 
            //Save changes to exchange rates (which apply to the selected currency) as well.
            if (!ignoreLeaveRow && _selectedCurrencyRecord != null && (modifiedCurrency || newCurrencyRec || modifiedRate || newRateRec)) {
                e.Allow = SaveRecord(true);
            }
        }

        private void gridViewCurrency_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void gridViewCurrency_ColumnFilterChanged(object sender, EventArgs e)
        {
            if (GridViewCurrency.DataRowCount == 0) {
                ClearBindings();
            }   
        }

        private void GridViewCurrency_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // Otherwise when leaving row with errors (and not saving), errors will carry over to new rew
            errorProvider1.Clear();
        }

        private void GridViewRates_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (_selectedExchangeRateRecord.ID != 0) {
                modifiedRate = true;
                var currentIndex = CurrToExRateBindingSource.IndexOf(_selectedExchangeRateRecord);
                if (!modifiedRateIndices.Contains(currentIndex))
                    modifiedRateIndices.Add(currentIndex);
            }
        }

        private void GridViewRates_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            // cannot edit codeFrom for existing exchange rates
            setReadOnly(true);
        }

        private void GridViewRates_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void CurrencyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (modifiedCurrency || newCurrencyRec) {
                DialogResult select = DevExpress.XtraEditors.XtraMessageBox.Show("There are unsaved changes. Are you sure want to exit?", Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (select == DialogResult.Yes) {
                    e.Cancel = false;
                    this.Dispose();
                }
                else if (select == DialogResult.No)
                    e.Cancel = true;
            }
            else {
                e.Cancel = false;
                this.Dispose();
            }
        }

        private void CurrencyForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewCurrency.IsFilterRow(GridViewCurrency.FocusedRowHandle)) {
                executeQuery();
                e.Handled = true;
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewCurrency.FocusedColumn.FieldName;
            //string value = String.Empty;
            //value = GridViewCurrency.GetFocusedDisplayText();

            //if (!string.IsNullOrWhiteSpace(value)) {
            string query = String.Format("it.Name like '{0}%'", GridViewCurrency.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Name"));
            var special = context.Currency.Where(query);

            if (!string.IsNullOrWhiteSpace(GridViewCurrency.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Code"))) {
                query = String.Format("it.{0} like '{1}%'", "Code", GridViewCurrency.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Code"));
                if (special.Count() > 0)
                    special = special.Where(query);
                else 
                    special = context.Currency.Where(query);
            }

            int count = special.Count();
            if (count > 0) {
                CurrencyBindingSource.DataSource = special;
                //GridViewCurrency.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                //GridViewCurrency.FocusedRowHandle = 0;
                //GridViewCurrency.FocusedColumn.FieldName = colName;
                GridViewCurrency.ClearColumnsFilter();
            }
            else {
                ClearBindings();
                XtraMessageBox.Show("No matching records found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //}
            this.Cursor = Cursors.Default;
        }

        //private void executeQuery()
        //{
        //    this.Cursor = Cursors.WaitCursor;
        //    string colName = GridViewCurrency.FocusedColumn.FieldName;
        //    string value = String.Empty;
        //    value = GridViewCurrency.GetFocusedDisplayText();

        //    // search by name first
        //    string query = String.Format("it.Name like '%{0}%'", GridViewCurrency.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Name"));
        //    var special = context.Currency.Where(query);

        //    query = String.Format("it.Code like '{0}%'", GridViewCurrency.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Code"));
        //    special = special.Where(query);

        //    int count = special.Count();

        //    //// search by code if name search returns nothing
        //    //if (count == 0) {
        //    //    query = String.Format("it.Code like '{0}%'", GridViewCurrency.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Code"));
        //    //    special = context.Currency.Where(query);

        //    //    query = String.Format("it.Name like '%{0}%'", GridViewCurrency.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Name"));
        //    //    special = special.Where(query);

        //    //    count = special.Count();
        //    //}

        //    if (count > 0) {
        //        CurrencyBindingSource.DataSource = special;
        //        GridViewCurrency.ClearColumnsFilter();
        //    }
        //    else {
        //        ClearBindings(CurrencyBindingSource);
        //        XtraMessageBox.Show("No matching records found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    this.Cursor = Cursors.Default;
        //}

        private void CurrencyBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            //If the current record is changing as a result of removing a record to delete it, and it is the last
            //record in the table, then SetBindings will clear the bindings, which will cause the delete
            //to fail because the associated entities will become detached when their BindingSources are cleared.
            //Thus we have a flag which is set in that case to ignore this event.
            if (!ignorePositionChange)
                SetBindings(CurrencyBindingSource);
        }

        private void CurrToExRateBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            // When changing currencies, the binding source is changed - this scenario is different from selecting another 
            // exchange rate for a given currency and should be ignored.
            if (!ignoreRateBindingChange)
                SetBindings(CurrToExRateBindingSource);
        }

        void ClearBindings()
        {
            CurrencyBindingSource.DataSource = typeof(Currency);
            CurrToExRateBindingSource.DataSource = typeof(CurrencyExchangeRate);
        }

        void SetBindings(BindingSource bindingSource)
        {
            if (bindingSource == CurrencyBindingSource) {
                if (CurrencyBindingSource.Count == 0) {
                    CurrencyBindingSource.DataSource = context.Currency.OrderBy(o => o.Code);
                    CurrencyBindingSource.MoveFirst();
                }

                if (CurrencyBindingSource.Current == null) {
                    _selectedCurrencyRecord = null;
                    enableNavigator(false);
                    //setReadOnly(true);
                }
                else {
                    _selectedCurrencyRecord = ((Currency)CurrencyBindingSource.Current);
                    ignoreRateBindingChange = true;
                    SetExchangeRateBindings();  // get exchange rates for new currency
                    ignoreRateBindingChange = false;
                    enableNavigator(true);
                    //setReadOnly(false);
                }
            }
            else if (bindingSource == CurrToExRateBindingSource) {
                if (CurrToExRateBindingSource.Current == null) {
                    _selectedExchangeRateRecord = null;
                    enableNavigator(false);
                    //setReadOnly(true);
                }
                else {
                    _selectedExchangeRateRecord = ((CurrencyExchangeRate)CurrToExRateBindingSource.Current);
                    // only do this to newly created exchange rate records
                    if (newRateRec && string.IsNullOrEmpty(_selectedExchangeRateRecord.Currency_Code_To)) {
                            _selectedExchangeRateRecord.Currency_Code_To = _selectedCurrencyRecord.Code;
                            _selectedExchangeRateRecord.Timestamp = DateTime.Now;
                            _selectedExchangeRateRecord.Fixed = true;
                    }
                    enableNavigator(true);
                    //setReadOnly(false);
                }
            }
        }

        void SetExchangeRateBindings()
        {
            try {
                var currencyTo = _selectedCurrencyRecord.Code;
                if (string.IsNullOrEmpty(currencyTo))
                    currencyTo = "";
                var currencyFromGroups = context.CurrencyExchangeRate
                    .AsEnumerable()
                    .Select(s => s)
                    .Where(w => w.Currency_Code_To == currencyTo.ToString())
                    .GroupBy(g => g.Currency_Code_From)
                    .Select(s => new { currencyGroup = s.OrderByDescending(x => x.Timestamp).FirstOrDefault() })
                    .ToList();

                List<CurrencyExchangeRate> latestRatePerCurrency = new List<CurrencyExchangeRate>();
                currencyFromGroups.ForEach(c => latestRatePerCurrency.Add(c.currencyGroup));
                CurrToExRateBindingSource.DataSource = latestRatePerCurrency;
                GridControlRates.DataSource = CurrToExRateBindingSource;
                GridControlRates.RefreshDataSource();
                _selectedExchangeRateRecord = ((CurrencyExchangeRate)CurrToExRateBindingSource.Current);
            }
            catch { }   
        }
         
        private void CurrencyForm_Shown(object sender, EventArgs e)
        {
            GridViewCurrency.FocusedRowHandle = DevExpress.Data.CurrencyDataController.FilterRow;
            GridControlCurrency.Focus();
        }

        // Opens file dialog.
        private void buttonEditImagePath_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog()) {
                dlg.Title = "Open Image";
                dlg.InitialDirectory = imagesRoot;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    if (dlg.FileName.ToLower().IndexOf(imagesRoot.ToLower()) != -1)
                        buttonEditImagePath.Text = dlg.FileName.Substring(imagesRoot.Length);
                    else
                        buttonEditImagePath.Text = dlg.FileName;
                }
            }
        }

        // Validate before leaving control - repeated for other controls below.
        private void codeTextEdit_Leave(object sender, EventArgs e)
        {
            if (_selectedCurrencyRecord != null)
                SetErrorInfo(_selectedCurrencyRecord.ValidateCode, sender, CurrencyBindingSource);
        }

        private void symbolTextEdit_Leave(object sender, EventArgs e)
        {
            if (_selectedCurrencyRecord != null)
                SetErrorInfo(_selectedCurrencyRecord.ValidateSymbol, sender, CurrencyBindingSource);
        }

        private void nameTextEdit_Leave(object sender, EventArgs e)
        {
            if (_selectedCurrencyRecord != null)
                SetErrorInfo(_selectedCurrencyRecord.ValidateName, sender, CurrencyBindingSource);
        }

        private void formatStringTextEdit_Leave(object sender, EventArgs e)
        {
            if (_selectedCurrencyRecord != null)
                SetErrorInfo(_selectedCurrencyRecord.ValidateFormatString, sender, CurrencyBindingSource);
        }

        private void ImageComboBoxEditCountry_Leave(object sender, EventArgs e)
        {
            if (_selectedCurrencyRecord != null)
                SetErrorInfo(_selectedCurrencyRecord.ValidateCountryCode, sender, CurrencyBindingSource);
        }

        private void localNameTextEdit_Leave(object sender, EventArgs e)
        {
            if (_selectedCurrencyRecord != null)
                SetErrorInfo(_selectedCurrencyRecord.ValidateLocalName, sender, CurrencyBindingSource);
        }

        private void adjustPercentTextEdit_Leave(object sender, EventArgs e)
        {
            if (_selectedCurrencyRecord != null)
                SetErrorInfo(_selectedCurrencyRecord.ValidateAdjustPercent, sender, CurrencyBindingSource);
        }

        private void buttonEditImagePath_Leave(object sender, EventArgs e)
        {
            if (_selectedCurrencyRecord != null)
                SetErrorInfo(_selectedCurrencyRecord.ValidateImagePath, sender, CurrencyBindingSource);
        }

        private void codeTextEdit_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (!newCurrencyRec)
                modifiedCurrency = true;
        }

        private void nameTextEdit_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (!newCurrencyRec)
                modifiedCurrency = true;
        }

        private void symbolTextEdit_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (!newCurrencyRec)
                modifiedCurrency = true;
        }  

        private void formatStringTextEdit_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (!newCurrencyRec)
                modifiedCurrency = true;
        }

        private void ImageComboBoxEditCountry_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (!newCurrencyRec)
                modifiedCurrency = true;
        }

        private void localNameTextEdit_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (!newCurrencyRec)
                modifiedCurrency = true;
        }

        private void adjustPercentTextEdit_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (!newCurrencyRec)
                modifiedCurrency = true;
        }

        private void GridViewRates_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "Currency_Code_From") {
                e.RepositoryItem = currencyCodeFromRepository;
            }
        }

        private void buttonEditImagePath_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (!newCurrencyRec)
                modifiedCurrency = true;
        }

        // Load image referenced by image file path for preview
        private void buttonEditImagePath_TextChanged(object sender, EventArgs e)
        {
            PictureEditPreview.Image = null;
            try {

                using (var stream = new MemoryStream(File.ReadAllBytes(imagesRoot + buttonEditImagePath.Text))) {
                    PictureEditPreview.Height = Image.FromStream(stream).Height;
                    PictureEditPreview.Width = Image.FromStream(stream).Width;
                    PictureEditPreview.Image = Image.FromStream(stream);
                    labelControlSize.Text = Image.FromStream(stream).Height + " * " + Image.FromStream(stream).Width;
                    errorProvider1.SetError(buttonEditImagePath, "");
                }
            }
            catch {
                try {
                    using (var stream = new MemoryStream(File.ReadAllBytes(buttonEditImagePath.Text))) {
                        PictureEditPreview.Height = Image.FromStream(stream).Height;
                        PictureEditPreview.Width = Image.FromStream(stream).Width;
                        PictureEditPreview.Image = Image.FromStream(stream);
                        labelControlSize.Text = Image.FromStream(stream).Height + " * " + Image.FromStream(stream).Width;
                        errorProvider1.SetError(buttonEditImagePath, "");
                    }
                }
                catch {
                    return;
                }
            }
        }

        private void getCurrenciesButton_Click(object sender, EventArgs e)
        {
            GetJsonCurrenciesAsync();
        }

        private void getExchangeRatesButton_Click(object sender, EventArgs e)
        {
            GetJsonExchangeRatesAsync();
        }

    }
}