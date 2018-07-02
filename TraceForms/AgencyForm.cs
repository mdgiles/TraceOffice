using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Dynamic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using DevExpress.XtraEditors.Controls;
using FlexModel;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using FlexEntities.Entities;
using System.Globalization;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;

namespace TraceForms
{


    public partial class AgencyForm : DevExpress.XtraEditors.XtraForm
    {
        public List<IComprod2> myCommRecs;
        public List<IComprod2> myCommRecsAgy;
        public List<ICommLevel> myCommLvl;
        public string currentVal;
        public bool proceed = false;
        public bool modified = false;
        public bool newRec = false;
        public bool newAgyLogRec = false;
        public bool agyLogModified = false;
        public bool authorizeCreditMod = false;
        public bool authorizeBankMod = false;
        public bool newRowRec = false;
        public bool memberNewRowRec = false;
        public bool temp = false;
        public string imagesRoot;
        const string col = "colNO";
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public FlextourEntities context;
        public bool firstLoad = false;
        public string globalRptType = string.Empty;
        public string username;
        public string defAgy = string.Empty;
        public string apiLogin;
        public string transactionKey;
        public AuthorizeNet.CustomerGateway conn;
        public AuthorizeNet.Customer currentCust;
        public List<int> authorizeCurrentRow;
        public List<int> authorizeCurrentBankRow;
        public List<AuthorizeNet.PaymentProfile> creditCards;
        public List<AuthorizeNet.PaymentProfile> bankAccnts;
        public float defaultCreditPct;
        public bool allowElecPayments;
        public bool reqAgyInfoOnFile;
        public bool paymentTestMode;
        public FileSystemWatcher fsw;
        string _accountingURL;
        RepositoryItemImageComboBox agyCurrencyCodeRepository = new RepositoryItemImageComboBox();
        public bool newAgyCurrencyRec = false;
        public bool modifiedAgyCurrencyRec = false;
        public List<int> newAgyCurrencyIndices = new List<int>();
        public List<int> modifiedAgyCurrencyIndices = new List<int>();
        public string fixedDefaultCurrency;
        public int actualDefaultCurrencyIndex;
        public int fixedDefaultCurrencyIndex;

        public AgencyForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
            LoadLookups();
            creditCards = new List<AuthorizeNet.PaymentProfile>();
            bankAccnts = new List<AuthorizeNet.PaymentProfile>();
            authorizeCurrentRow = new List<int>();
            authorizeCurrentBankRow = new List<int>();
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {

            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);
            //FlexBObj.FileWatcher watcher = new FlexBObj.FileWatcher(sys.Settings.DataPath, sys.Settings.EFConnectionString);
            username = sys.User.Name;
            imagesRoot = sys.Settings.ImagesRoot;
            defAgy = sys.Settings.DefaultAgency;
            _accountingURL = sys.Settings.TourAccountingURL;

            var defCredit = context.AGY.First(a => a.NO == defAgy).CreditLimitRemainingWarningPct;
            defaultCreditPct = (defCredit == null ? 0 : (float)defCredit);
            allowElecPayments = sys.Settings.AllowElectronicPayments;
            reqAgyInfoOnFile = sys.Settings.RequireAgyPaymentInfoOnFile;
            paymentTestMode = sys.Settings.PaymentProcessorTestMode;
            if (allowElecPayments) {
                if (string.IsNullOrWhiteSpace(sys.Settings.PaymentProcessorLoginId) || string.IsNullOrWhiteSpace(sys.Settings.PaymentProcessorTxKey)) {
                    MessageBox.Show("You are not currently setup to enter payment info please enter your credentials in the Company File form.");
                    xtraTabPage14.PageVisible = false;
                    return;

                }
                xtraTabPage14.PageVisible = true;
                if (!string.IsNullOrWhiteSpace(sys.Settings.PaymentProcessorLoginId) && !string.IsNullOrWhiteSpace(sys.Settings.PaymentProcessorTxKey)) {
                    apiLogin = sys.Settings.PaymentProcessorLoginId;
                    transactionKey = sys.Settings.PaymentProcessorTxKey;
                    try {
                        conn = new AuthorizeNet.CustomerGateway(apiLogin, transactionKey, paymentTestMode);
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }
                }

                //conn = new AuthorizeNet.CustomerGateway("", "", AuthorizeNet.ServiceMode.Test);
                grdColExpDate.Caption = "Exp. Date \n(YYYY-MM)";
            }
            else
                xtraTabPage14.PageVisible = false;

            var agentLoad = from c in context.AGCYLOG
                            where c.AGENCY == "KJM"
                            select c;
            AgcyLogBindingSource.DataSource = agentLoad;

            fixedDefaultCurrency = sys.Settings.DefaultCurrency;
            //file watcher demo
            //fsw = new FileSystemWatcher();
            ////fsw.Path = sys.Settings.DataPath;
            //fsw.Path = sys.Settings.DataPath;
            //fsw.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite |
            //                   NotifyFilters.DirectoryName | NotifyFilters.FileName;
            //fsw.IncludeSubdirectories = true;
            //fsw.EnableRaisingEvents = true;
            //fsw.Filter = "*.*";
            //fsw.Changed += new FileSystemEventHandler(OnChanged);
            //fsw.Created += new FileSystemEventHandler(OnCreated);
            //fsw.Deleted += new FileSystemEventHandler(OnChanged);
            //fsw.Renamed += new RenamedEventHandler(OnRenamed);



        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            string[] extensions = { ".txt" };
            var ext = (Path.GetExtension(e.FullPath) ?? string.Empty).ToLower();

            if (extensions.Any(ext.Equals)) {
                MessageBox.Show(e.FullPath + "   " + e.Name);
                // Do your magic here
            }
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            //string[] extensions = { ".txt" };
            //var ext = (Path.GetExtension(e.FullPath) ?? string.Empty).ToLower();

            //if (extensions.Any(ext.Equals))
            //{
            //    MessageBox.Show("hey we have something here");
            //    // Do your magic here
            //}
        }

        private void LoadLookups()
        {
            GridControlLookup.DataSource = from lookupRec in context.LOOKUP where lookupRec.RECTYPE == "AGYCLASS" select lookupRec;
            loadDirectory();
            myCommRecsAgy = (from rec in context.COMPROD2
                             where (rec.TYPE == "AGY") && (rec.Inactive == false) && ((rec.START_DATE <= DateTime.Now) && (rec.END_DATE >= DateTime.Now))
                             select rec).ToList<IComprod2>();
            myCommLvl = (from rec in context.CommLevel select rec).ToList<ICommLevel>();

            foreach (COMPROD2 rec in myCommRecsAgy) {
                rec.SetProductRulePosition(myCommLvl);
            }
            GridColumn columnHotelInfo3 = GridViewCustom.Columns.AddField("AgencyValue");
            columnHotelInfo3.VisibleIndex = 1;
            columnHotelInfo3.UnboundType = DevExpress.Data.UnboundColumnType.String;
            columnHotelInfo3.Visible = true;
            gridControl1.DataSource = from rptTypeRec in context.RPTTYPE where rptTypeRec.MEDIA_RPT == false && rptTypeRec.RecipientType == "Agy" select rptTypeRec;
            modified = false;
            newRec = false;
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = string.Empty };
            imageComboBoxEditAgentDelegate.Properties.Items.Add(loadBlank);
            ImageComboBoxEditAgency.Properties.Items.Add(loadBlank);
            ImageComboBoxEditConsrt.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCountry.Properties.Items.Add(loadBlank);
            ImageComboBoxEditLanguage.Properties.Items.Add(loadBlank);

            var lang = from langRec in context.LANGUAGE orderby langRec.CODE ascending select new { langRec.CODE, langRec.NAME };
            var country = from countryRec in context.COUNTRY orderby countryRec.CODE ascending select new { countryRec.CODE, countryRec.NAME };
            var consrt = from consrtRec in context.CONSRT orderby consrtRec.CODE ascending select new { consrtRec.CODE, consrtRec.NAME };
            var agency = from agencyRec in context.AGY orderby agencyRec.NO ascending select new { agencyRec.NO, agencyRec.NAME };
            var dept = from deptRec in context.Dept orderby deptRec.Code ascending select new { deptRec.Code, deptRec.Desc };
            var city = from citRec in context.CITYCOD orderby citRec.CODE ascending select new { citRec.CODE, citRec.NAME };
            var state = from stateRec in context.State orderby stateRec.Code ascending select new { stateRec.Code, stateRec.State1 };
            ///////////////////////////////////////////////////
            // Prevent columns from being automatically created when a data source is assigned.
            //GridLookUpEditCity.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
            //// The data source for the dropdown rows
            //GridLookUpEditCity.Properties.DataSource = city;
            //// The field for the editor's display text.
            //GridLookUpEditCity.Properties.DisplayMember = "CODE" + "(" + "NAME" +")";
            //// The field matching the edit value.
            //GridLookUpEditCity.Properties.ValueMember = "CODE";


            //GridColumn col1 = GridLookUpEditCity.Properties.View.Columns.AddField("CODE");
            //col1.VisibleIndex = 0;
            //col1.Caption = "Code";
            //// A column to display the values of the ProductName field.
            //GridColumn col2 = GridLookUpEditCity.Properties.View.Columns.AddField("NAME");
            //col2.VisibleIndex = 1;
            //col2.Caption = "Name";

            //// Set column widths according to their contents.
            //GridLookUpEditCity.Properties.View.BestFitColumns();
            //// Specify the total dropdown width.
            //GridLookUpEditCity.Properties.PopupFormWidth = 300;    


            ///////////////////////////////////////////////////

            foreach (var result in lang) {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditLanguage.Properties.Items.Add(load);
            }

            foreach (var result in country) {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCountry.Properties.Items.Add(load);
            }

            foreach (var result in consrt) {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditConsrt.Properties.Items.Add(load);
            }

            foreach (var result in agency) {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.NO.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.NO.TrimEnd() };
                ImageComboBoxEditParentAgy.Properties.Items.Add(load);
                ImageComboBoxEditAgency.Properties.Items.Add(load);
            }

            foreach (var result in dept) {
                repositoryItemComboBoxDept.Items.Add(result.Code + " " + result.Desc);
            }
            setReadOnly(true);
            setAgcyLogReadOnly(true);
            enableAgcyLogNavigator(false);
            enableNavigator(false);
            DetailBindingSource.DataSource = from c in context.DETAIL where c.CODE == "KJM9" select c;

        }

        void enableNavigator(bool value)
        {
            bindingNavigatorMoveNextItem.Enabled = value;
            bindingNavigatorMoveLastItem.Enabled = value;
            bindingNavigatorMoveFirstItem.Enabled = value;
            bindingNavigatorMovePreviousItem.Enabled = value;
        }

        void setReadOnly(bool value)
        {
            TextEditNo.Properties.ReadOnly = value;
            GridViewAgy.Columns.ColumnByName(col).OptionsColumn.AllowEdit = !(value);
        }

        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        private bool checkForms()
        {
            if (!modified && !newRec && !agyLogModified && !newAgyCurrencyRec && !modifiedAgyCurrencyRec)
                return true;

            if (agyLogModified)
                modified = true;

            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((AGY)AgyBindingSource.Current).checkMain, AgyBindingSource);
            bool validateLocation = validCheck.checkAll(PanelControlLocationTab.Controls, errorProvider1, ((AGY)AgyBindingSource.Current).checkLocationTab, AgyBindingSource);
            bool validateContact = validCheck.checkAll(PanelControlContactTab.Controls, errorProvider1, ((AGY)AgyBindingSource.Current).checkContactTab, AgyBindingSource);
            bool validateAvailTab = validCheck.checkAll(PanelControlAvailabilityTab.Controls, errorProvider1, ((AGY)AgyBindingSource.Current).checkAvailabilityTab, AgyBindingSource);
            bool validateReport = validCheck.checkAll(PanelControlReportTab.Controls, errorProvider1, ((AGY)AgyBindingSource.Current).checkReportTab, AgyBindingSource);
            bool validatePolicies = validCheck.checkAll(PanelControlPoliciesTab.Controls, errorProvider1, ((AGY)AgyBindingSource.Current).checkPoliciesTab, AgyBindingSource);
            bool validateCurrencies = ValidateCurrencies();
            bool validateConsrt = validCheck.checkAll(PanelControlConsrtTab.Controls, errorProvider1, ((AGY)AgyBindingSource.Current).checkConsrtTab, AgyBindingSource);
            bool validateAccount = validCheck.checkAll(PanelControlAccountTab.Controls, errorProvider1, ((AGY)AgyBindingSource.Current).checkAccountTab, AgyBindingSource);
            bool validateAdmin = validCheck.checkAll(PanelControlAdminTab.Controls, errorProvider1, ((AGY)AgyBindingSource.Current).checkAdminTab, AgyBindingSource);
            bool validateMember = validCheck.checkAll(PanelControlMemberTab.Controls, errorProvider1, ((AGY)AgyBindingSource.Current).checkMemberTab, AgyBindingSource);
            bool validateResource = validCheck.checkAll(PanelControlResourceTab.Controls, errorProvider1, ((AGY)AgyBindingSource.Current).checkResourceTab, AgyBindingSource);
            bool validateCustom = validCheck.checkAll(PanelControlCustomTab.Controls, errorProvider1, ((AGY)AgyBindingSource.Current).checkCustomTab, AgyBindingSource);
            bool validateAgents = true;

            if (AgcyLogBindingSource.Current != null)
                validateAgents = validCheck.checkAll(PanelControlAgentTab.Controls, errorProvider1, ((AGCYLOG)AgcyLogBindingSource.Current).checkAll, AgcyLogBindingSource);

            if (validateMain && validateLocation && validateContact && validateAvailTab && validateReport && validatePolicies && validateConsrt && validateAccount 
                && validateAdmin && validateMember && validateResource && validateCustom && validateAgents && validateCurrencies) {
                var ret = validCheck.saveRec(ref modified, true, ref newRec, context, AgyBindingSource, this.Name, errorProvider1, Cursor);
                if (ret)
                    ret = SaveAgencyCurrency();
                if (ret) {
                    AccountingAPI.InvokeForAgency(_accountingURL, ((AGY)AgyBindingSource.Current).NO);
                    if (agyLogModified || newAgyLogRec) {
                        AccountingAPI.InvokeForAgent(_accountingURL, ((AGCYLOG)AgcyLogBindingSource.Current).AGT_NAME);
                    }
                }
                return ret;
            }
            else {
                validCheck.saveRec(ref modified, false, ref newRec, context, AgyBindingSource, this.Name, errorProvider1, Cursor);
                return false;
            }
        }

        void setValues()
        {
            GridViewAgy.SetFocusedRowCellValue("DUE_DAY", 0);
            GridViewAgy.SetFocusedRowCellValue("VOUCH_TYPES", string.Empty);
            GridViewAgy.SetFocusedRowCellValue("ALLOW_ATTACHMENTS", "Y");
            GridViewAgy.SetFocusedRowCellValue("ShowAllLanguages", 0);
            GridViewAgy.SetFocusedRowCellValue("TourfaxEmailFormat", "txt");
            GridViewAgy.SetFocusedRowCellValue("INV_FMT", "SGL");
            GridViewAgy.SetFocusedRowCellValue("TYP", string.Empty);
            GridViewAgy.SetFocusedRowCellValue("AR", string.Empty);
            GridViewAgy.SetFocusedRowCellValue("AP", string.Empty);
            GridViewAgy.SetFocusedRowCellValue("ADDR1", string.Empty);
            GridViewAgy.SetFocusedRowCellValue("ADDR2", string.Empty);
            GridViewAgy.SetFocusedRowCellValue("ADDR3", string.Empty);
            GridViewAgy.SetFocusedRowCellValue("PHONE", string.Empty);
            GridViewAgy.SetFocusedRowCellValue("CONSORT", string.Empty);
            GridViewAgy.SetFocusedRowCellValue("STATE", string.Empty);
            GridViewAgy.SetFocusedRowCellValue("SRT2", string.Empty);
            GridViewAgy.SetFocusedRowCellValue("SRT3", string.Empty);
            GridViewAgy.SetFocusedRowCellValue("DEF_LANG", string.Empty);
            GridViewAgy.SetFocusedRowCellValue("FAX_NUM", string.Empty);
            GridViewAgy.SetFocusedRowCellValue("ACTIVE_FLG", "A");
            GridViewAgy.SetFocusedRowCellValue("IMMED_FLG", "N");
            GridViewAgy.SetFocusedRowCellValue("INV_FMT", "SGL");
            GridViewAgy.SetFocusedRowCellValue("SVCDTE_FLG", "N");
            GridViewAgy.SetFocusedRowCellValue("FAX_ID", string.Empty);
            GridViewAgy.SetFocusedRowCellValue("SUB_ALLOC", "N");
            GridViewAgy.SetFocusedRowCellValue("REM_CHG", "N");///
            GridViewAgy.SetFocusedRowCellValue("CONF_PRC", "N");
            GridViewAgy.SetFocusedRowCellValue("EMAIL", string.Empty);
            GridViewAgy.SetFocusedRowCellValue("EDITHTLS", string.Empty);
            GridViewAgy.SetFocusedRowCellValue("EDITHDRS", string.Empty);
            GridViewAgy.SetFocusedRowCellValue("SIMPLEAVAL", "Y");
            GridViewAgy.SetFocusedRowCellValue("GMACCTNO", string.Empty);
            GridViewAgy.SetFocusedRowCellValue("REMOTE_VOUCHERS", "N");
            GridViewAgy.SetFocusedRowCellValue("LOGO_PATH", string.Empty);
            GridViewAgy.SetFocusedRowCellValue("COUNTRY", string.Empty);
            GridViewAgy.SetFocusedRowCellValue("PARENT", string.Empty);
            GridViewAgy.SetFocusedRowCellValue("ZIP", string.Empty);
            GridViewAgy.SetFocusedRowCellValue("CITY", string.Empty);
            GridViewAgy.SetFocusedRowCellValue("WEBSITE", string.Empty);
            GridViewAgy.SetFocusedRowCellValue("Language_Code", string.Empty);
            GridViewAgy.SetFocusedRowCellValue("USER_DEC1", 0);
            GridViewAgy.SetFocusedRowCellValue("USER_DEC2", 0);
            GridViewAgy.SetFocusedRowCellValue("USER_INT1", 0);
            GridViewAgy.SetFocusedRowCellValue("USER_INT2", 0);
            GridViewAgy.SetFocusedRowCellValue("USER_TXT1", string.Empty);
            GridViewAgy.SetFocusedRowCellValue("USER_TXT2", string.Empty);
            GridViewAgy.SetFocusedRowCellValue("USER_TXT3", string.Empty);
            GridViewAgy.SetFocusedRowCellValue("USER_TXT4", string.Empty);
            GridViewAgy.SetFocusedRowCellValue("CreditUnlimited", false);
            GridViewAgy.SetFocusedRowCellValue("RequireCVV2Number", false);
            GridViewAgy.SetFocusedRowCellValue("CreditLimit", 0);
            GridViewAgy.SetFocusedRowCellValue("CreditLimitRemainingWarningPct", defaultCreditPct);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            GridViewAgy.CloseEditor();
            GridViewAgy.ClearColumnsFilter();
            TextEditNo.Focus();
            if (AgyBindingSource.Current == null) {
                AgyBindingSource.DataSource = from opt in context.AGY where opt.NO == "KJM9" select opt;
                AgyBindingSource.AddNew();
                if (GridViewAgy.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewAgy.FocusedRowHandle = GridViewAgy.RowCount - 1;
                setReadOnly(false);
                newRec = true;
                setValues();
                return;
            }
            temp = newRec;
            ((AGY)AgyBindingSource.Current).ImagesRoot = imagesRoot;
            if (checkForms()) {
                newRec = false;
                modified = false;
                newRowRec = false;
                memberNewRowRec = false;
                newAgyLogRec = false;
                agyLogModified = false;
                errorProvider1.Clear();
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (AGY)AgyBindingSource.Current);
                AgyBindingSource.AddNew();
                if (GridViewAgy.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewAgy.FocusedRowHandle = GridViewAgy.RowCount - 1;
                setValues();
                TextEditNo.Focus();
                setReadOnly(false);
                newRec = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (AgyBindingSource.Current == null)
                return;
            GridViewAgy.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes) {

                IEnumerable<CONTACT> contactRecs = from contact in context.CONTACT where contact.LINK_VALUE == TextEditNo.Text select contact;
                foreach (CONTACT rec in contactRecs)
                    context.DeleteObject(rec);

                IEnumerable<RptContact> rptContactRecs = from contact in context.RptContact where contact.Code == TextEditNo.Text select contact;
                foreach (RptContact rec in rptContactRecs)
                    context.DeleteObject(rec);


                modified = false;
                newRec = false;
                AgyBindingSource.RemoveCurrent();
                errorProvider1.Clear();
                context.SaveChanges();
                setReadOnly(true);
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);
            }
            currentVal = TextEditNo.Text;
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }

        private void aGYBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            TextEditNo.Focus();
            if (AgyBindingSource.Current == null)
                return;
            int ID = 0;
            GridViewAgy.CloseEditor();
            if (GridViewContacts.RowCount > 0) {
                ID = (int)GridViewContacts.GetFocusedRowCellValue("ID");
            }
            ((AGY)AgyBindingSource.Current).ImagesRoot = imagesRoot;
            if (((AGY)AgyBindingSource.Current).RequireCVV2Number == null) {
                ((AGY)AgyBindingSource.Current).RequireCVV2Number = false;
            }
            bool require = (bool)((AGY)AgyBindingSource.Current).RequireCVV2Number;
            bool checkNewRecs = false;
            //gridViewPaymentProfiles.UpdateCurrentRow();
            //gridViewPaymentProfiles.MoveFirst();
            foreach (int val in authorizeCurrentRow) {
                AuthorizeNet.PaymentProfile rec = (AuthorizeNet.PaymentProfile)gridViewPaymentProfiles.GetRow(val);
                if (string.IsNullOrWhiteSpace(rec.CardNumber) || string.IsNullOrWhiteSpace(rec.CardExpiration) || (string.IsNullOrWhiteSpace(rec.CardCode) && require))
                    checkNewRecs = true;
            }
            foreach (int val in authorizeCurrentBankRow) {
                AuthorizeNet.PaymentProfile rec = (AuthorizeNet.PaymentProfile)gridViewBankProfiles.GetRow(val);
                if (string.IsNullOrWhiteSpace(rec.BankAccountNumber) || string.IsNullOrWhiteSpace(rec.BankName) || string.IsNullOrWhiteSpace(rec.BankNameOnAccount) || string.IsNullOrWhiteSpace(rec.BankRoutingNumber))
                    checkNewRecs = true;
            }

            if (gridViewPaymentProfiles.HasColumnErrors || checkNewRecs || gridViewBankProfiles.HasColumnErrors) {
                MessageBox.Show("Please correct the errors in the payment grids.");
                gridViewPaymentProfiles.Focus();
                return;
            }

            if ((allowElecPayments && reqAgyInfoOnFile) && (currentCust == null || currentCust.PaymentProfiles.Count == 0)) {
                if (currentCust == null)
                    MessageBox.Show("WARNING!. You are saving an agency without a payment customer profile.");
                else if (currentCust.PaymentProfiles.Count == 0)
                    MessageBox.Show("WARNING!. You are saving an agency without a method of payment for the customer profile.");

            }

            bool temp = newRec;
            if (checkForms()) {
                ////////////////////////
                errorProvider1.Clear();
                newRec = false;
                newRowRec = false;
                memberNewRowRec = false;
                modified = false;
                newAgyLogRec = false;
                agyLogModified = false;
                setReadOnly(true);
                //handle authorizeNet save here after succesfully saving the recordif

                if (authorizeCreditMod) {
                    UpdateButton.Enabled = true;
                    authorizeCreditMod = false;
                    foreach (int val in authorizeCurrentRow) {
                        AuthorizeNet.PaymentProfile rec = (AuthorizeNet.PaymentProfile)gridViewPaymentProfiles.GetRow(val);
                        string cardType = (GetCardTypeFromNumber(rec.CardNumber)).ToString();
                        string creditProfileID = conn.AddCreditCard(currentCust.ProfileID, rec.CardNumber, Convert.ToInt32(rec.CardExpiration.GetLast(2)), Convert.ToInt32(rec.CardExpiration.Substring(0, 4)), rec.CardCode, rec.BillingAddress);
                        string last4 = rec.CardNumber.GetLast(4);
                        AgencyPaymentProfile newCredRecord = new AgencyPaymentProfile();
                        newCredRecord.Agy_No = TextEditNo.Text;
                        newCredRecord.PaymentProfileID = creditProfileID;
                        newCredRecord.ExpirationMonth = Convert.ToInt32(rec.CardExpiration.GetLast(2));
                        newCredRecord.ExpirationYear = Convert.ToInt32(rec.CardExpiration.Substring(0, 4));
                        newCredRecord.LastDigits = last4;
                        newCredRecord.PaymentProvider = cardType;
                        // newCredRecord.PaymentProfileDesc = rec.CardType + " " + last4 + " " + rec.CardExpiration;
                        context.AgencyPaymentProfile.AddObject(newCredRecord);
                        context.SaveChanges();
                    }
                    authorizeCurrentRow.Clear();
                }

                if (authorizeBankMod) {
                    UpdateButton.Enabled = true;
                    authorizeBankMod = false;
                    foreach (int val in authorizeCurrentBankRow) {
                        AuthorizeNet.PaymentProfile rec = (AuthorizeNet.PaymentProfile)gridViewBankProfiles.GetRow(val);
                        string bankprofileID = conn.AddBankAccount(currentCust.ProfileID, rec.BankNameOnAccount, rec.BankAccountNumber, rec.BankRoutingNumber, rec.BankName, rec.AccountType, rec.AccountTypeSpecified, rec.BillingAddress);
                        string last4 = rec.BankAccountNumber.GetLast(4);
                        AgencyPaymentProfile newBankRecord = new AgencyPaymentProfile();
                        newBankRecord.Agy_No = TextEditNo.Text;
                        newBankRecord.PaymentProfileID = bankprofileID;
                        //newBankRecord.PaymentProfileDesc = rec.BankName + " " + last4;
                        newBankRecord.PaymentProvider = rec.BankName;
                        newBankRecord.LastDigits = last4;

                        context.AgencyPaymentProfile.AddObject(newBankRecord);
                        context.SaveChanges();
                    }

                    authorizeCurrentBankRow.Clear();
                }

                if (currentCust != null) {
                    ///llp
                    currentCust.Email = TextEditPaymentProcessorCustProfileEmail.Text;
                    //foreach (AuthorizeNet.PaymentProfile rec in currentCust.PaymentProfiles)
                    //    conn.UpdatePaymentProfile(currentCust.ProfileID, rec);                    
                    conn.UpdateCustomer(currentCust);
                    currentCust = conn.GetCustomer(currentCust.ProfileID);
                    loadAuthorize(currentCust);
                    if (string.IsNullOrWhiteSpace(ImageComboBoxEditDefaultProfileID.Text) && currentCust.PaymentProfiles.Count > 0)
                        ImageComboBoxEditDefaultProfileID.EditValue = currentCust.PaymentProfiles[0].ProfileID;
                }

                //////////////////////////////////end of authoriznet

                if (ID == int.MaxValue) {
                    int newID = (int)GridViewContacts.GetFocusedRowCellValue("ID");
                    var values1 = from rec in context.RPTTYPE where rec.RecipientType == "Agy" select new { rec.CODE };
                    foreach (var result in values1) {
                        if (globalRptType.Contains(result.CODE)) {
                            RptContact contact = new RptContact();
                            contact.Code = TextEditNo.Text;
                            contact.RptType = result.CODE;
                            contact.Contact_ID = newID;
                            context.RptContact.AddObject(contact);

                        }
                    }
                    context.SaveChanges();
                    globalRptType = string.Empty;

                }
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                //ratePlanNewRec = false;
                //roomTypNewRec = false;
                //mappingNewRec = false;
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
            }

            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (AGY)AgyBindingSource.Current);

        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }


        void enableAgcyLogNavigator(bool valid)
        {
            toolStripButton1.Enabled = valid;
            toolStripButton2.Enabled = valid;
            toolStripButton3.Enabled = valid;
            toolStripButton4.Enabled = valid;
            TextEditAgtName.Enabled = valid;
            TextEditPassword.Enabled = valid;
            TextEditAgtEmail.Enabled = valid;
            TextEditAgtFax.Enabled = valid;
            ComboBoxEditResProf.Enabled = valid;
            //ComboBoxEditMntProf.Enabled = valid;
            //ComboBoxEditPrtProf.Enabled = valid;
            //ComboBoxEditAccProf.Enabled = valid;
        }

        private void aGYBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            //       authorizeCurrentRow.Clear();


            ComboBoxEditSource.Text = string.Empty;
            ImageComboBoxEditAgency.Text = string.Empty;
            ButtonEditDate.Text = string.Empty;
            ImageComboBoxEditDefaultProfileID.Properties.Items.Clear();
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = string.Empty, Value = string.Empty };
            ImageComboBoxEditDefaultProfileID.Properties.Items.Add(loadBlank);

            if (AgyBindingSource.Current != null) {
                AGY rec = (AGY)AgyBindingSource.Current;
                // context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (AGY)AgyBindingSource.Current);
                enableNavigator(true);
                proceed = false;
                voucherCheckDina();
                // AgcyLog

                var agentLoad = from c in context.AGCYLOG
                                where c.AGENCY == rec.NO
                                select c;

                AgcyLogBindingSource.DataSource = agentLoad;

                if (agentLoad.Count() > 0) {
                    enableAgcyLogNavigator(true);
                }
                else
                    enableAgcyLogNavigator(false);

                GridControlContacts.DataSource = (from c in context.CONTACT
                                                  where c.LINK_VALUE == rec.NO && c.LINK_TABLE == "AGY" && c.RECTYPE == "AGYCONTACT"
                                                  select c);
                gridControl3.DataSource = from c in context.USERFIELDS
                                          where c.LINK_TABLE.Equals("AGY")
                                          select c;
                GridControlMemberships.DataSource = from c in context.DETAIL where c.LINK_VALUE.TrimEnd() == rec.NO select c;

                // BAW
                AgencyCurrencyBindingSource.DataSource = (from c in context.AgencyCurrency
                                                          where c.Agy_No == rec.NO
                                                          select c);
                gridControlAgencyCurrency.DataSource = AgencyCurrencyBindingSource;
                gridControlAgencyCurrency.RefreshDataSource();

                // used to ensure that at least one record is automatically set to default
                var actualDefaultCurrencyRecord = AgencyCurrencyBindingSource.List.Cast<AgencyCurrency>().Where(a => a.Default == true).FirstOrDefault();
                actualDefaultCurrencyIndex = AgencyCurrencyBindingSource.IndexOf(actualDefaultCurrencyRecord);

                // this currency record may not be the actual default, but it is determined by sys.Settings.DefaultCurrency and is the fallback default, which cannot be edited or deleted
                var fixedDefaultCurrencyRecord = AgencyCurrencyBindingSource.List.Cast<AgencyCurrency>().Where(f => f.Currency_Code == fixedDefaultCurrency).FirstOrDefault();
                fixedDefaultCurrencyIndex = AgencyCurrencyBindingSource.IndexOf(fixedDefaultCurrencyRecord);

                List<ImageComboBoxItem> currencyCodesLookup = (from c in context.Currency
                                                               select new
                                                               {
                                                                   Code = c.Code,
                                                                   Name = c.Name
                                                               })
                                                                .ToList()
                                                                .Select(l => new ImageComboBoxItem()
                                                                {
                                                                    Description = string.Format("{0} - {1}", l.Code, l.Name),
                                                                    Value = l.Code
                                                                }).ToList();


                agyCurrencyCodeRepository.Items.Clear();
                agyCurrencyCodeRepository.Items.AddRange(currencyCodesLookup);
                gridControlAgencyCurrency.RepositoryItems.Clear();
                gridControlAgencyCurrency.RepositoryItems.Add(agyCurrencyCodeRepository);   //per DX recommendation to avoid memory leaks

                if (string.IsNullOrWhiteSpace(TextBoxTyp.Text)) {
                    TextBoxTyp.Text = string.Empty;
                }

                if (rec.DUE_DAY > 0) {
                    SpinEditDueDays.Enabled = true;
                    checkEdit9.Checked = true;
                    SpinEditPmtDays.Enabled = false;
                }
                else {
                    SpinEditDueDays.Enabled = false;
                    checkEdit9.Checked = false;
                    SpinEditPmtDays.Enabled = true;
                }
                //MessageBox.Show("Step 3");
                for (int i = 0; i < GridViewCustom.DataRowCount; i++)
                    GridViewCustom.RefreshRow(i);
                creditCards.Clear();
                bankAccnts.Clear();
                gridCntrlPaymentProfiles.DataSource = null;
                gridControlBankProfiles.DataSource = null;
                if (rec.RequireCVV2Number == true)
                    grdColCVV2.Visible = true;
                else
                    grdColCVV2.Visible = false;

                if (allowElecPayments) {
                    if (!string.IsNullOrWhiteSpace(rec.PaymentProcessorCustProfileId)) {
                        CreateButton.Enabled = false;
                        DeleteButton.Enabled = true;
                        UpdateButton.Enabled = true;
                        AddBankButton.Enabled = true;
                        DelBankButton.Enabled = true;
                        AddCreditButton.Enabled = true;
                        DelCredButton.Enabled = true;
                        try {
                            //following line for testing purposes on apps4 should be able to remove later. Consult MDG
                            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                            conn = new AuthorizeNet.CustomerGateway(apiLogin, transactionKey, paymentTestMode);
                            currentCust = conn.GetCustomer(rec.PaymentProcessorCustProfileId);
                        }
                        catch (Exception ex) {
                            MessageBox.Show(ex.Message);
                        }


                        if (currentCust != null && currentCust.PaymentProfiles.Count() > 0) {
                            loadAuthorize(currentCust);
                        }
                    }
                    else {
                        currentCust = null;
                        //gridControlBankProfiles.DataSource = null;
                        //gridCntrlPaymentProfiles.DataSource = null;
                        CreateButton.Enabled = true;
                        DeleteButton.Enabled = false;
                        UpdateButton.Enabled = false;
                        AddBankButton.Enabled = false;
                        DelBankButton.Enabled = false;
                        AddCreditButton.Enabled = false;
                        DelCredButton.Enabled = false;
                    }
                }

                DateTime? day = DateTime.Today;
                UpdateCommMarkupGrid(TextEditNo.Text, day, "ALL");



            }
            else
                enableNavigator(false);

            if (string.IsNullOrWhiteSpace(TextBoxTyp.Text)) {
                TextBoxTyp.Text = string.Empty;
            }

        }

        private void loadAuthorize(AuthorizeNet.Customer cust)
        {
            bankAccnts.Clear();
            creditCards.Clear();
            ImageComboBoxEditDefaultProfileID.Properties.Items.Clear();
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = string.Empty, Value = string.Empty };
            ImageComboBoxEditDefaultProfileID.Properties.Items.Add(loadBlank);
            foreach (AuthorizeNet.PaymentProfile profile in cust.PaymentProfiles) {
                if (!string.IsNullOrWhiteSpace(profile.BankAccountNumber))
                    bankAccnts.Add(profile);

                if (!string.IsNullOrWhiteSpace(profile.CardNumber))
                    creditCards.Add(profile);
            }
            gridCntrlPaymentProfiles.DataSource = creditCards;
            gridControlBankProfiles.DataSource = bankAccnts;
            ///////////////////////

            var loadDefault = from agyRec in context.AgencyPaymentProfile where agyRec.Agy_No == TextEditNo.Text select agyRec;
            foreach (var result in loadDefault) {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.PaymentProfileDesc, Value = result.PaymentProfileID };
                ImageComboBoxEditDefaultProfileID.Properties.Items.Add(load);
            }
            //setDefeaultProfile to first added if none is set
            if (string.IsNullOrWhiteSpace(ImageComboBoxEditDefaultProfileID.Text) && currentCust.PaymentProfiles.Count > 0) {
                ImageComboBoxEditDefaultProfileID.EditValue = currentCust.PaymentProfiles[0].ProfileID;
                context.SaveChanges();
            }
            //  ////////////////
        }


        private void gridView3_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "AgencyValue" && e.IsGetData) {
                string desc = GridViewCustom.GetRowCellValue(e.ListSourceRowIndex, "LINK_COLUMN").ToString();
                desc = desc.Trim();
                e.Value = GridViewAgy.GetRowCellValue(AgyBindingSource.IndexOf(AgyBindingSource.Current), desc);
            }

            if (e.Column.FieldName == "AgencyValue" && e.IsSetData) {
                string desc = GridViewCustom.GetRowCellValue(e.ListSourceRowIndex, "LINK_COLUMN").ToString();
                desc = desc.Trim();
                GridViewAgy.SetRowCellValue(AgyBindingSource.IndexOf(AgyBindingSource.Current), desc, e.Value);
                modified = true;
            }
        }

        private void voucherCheckDina()
        {
            if (CheckEditRemoteVouchers.Checked) {
                CheckEditHtlVouchers.Enabled = true;
                CheckEditHtlVouchers.Checked = true;
                CheckEditCarVouchers.Enabled = true;
                CheckEditCruVouchers.Enabled = true;
                CheckEditAirVouchers.Enabled = true;
                CheckEditOptVouchers.Enabled = true;
                CheckEditPkgVouchers.Enabled = true;
                CheckEditSglResConf.Enabled = true;
            }

            if (!CheckEditRemoteVouchers.Checked) {
                CheckEditHtlVouchers.Enabled = false;
                CheckEditCarVouchers.Enabled = false;
                CheckEditCruVouchers.Enabled = false;
                CheckEditAirVouchers.Enabled = false;
                CheckEditOptVouchers.Enabled = false;
                CheckEditPkgVouchers.Enabled = false;
                CheckEditSglResConf.Enabled = false;
                //CheckEditHtlVouchers.Checked = CheckEditCarVouchers.Checked = CheckEditCruVouchers.Checked = CheckEditAirVouchers.Checked = CheckEditOptVouchers.Checked = CheckEditPkgVouchers.Checked = CheckEditSglResConf.Checked = false;
            }

            if (TextEditVouchTypes.Text.Contains("OPT"))
                CheckEditOptVouchers.Checked = true;
            else
                CheckEditOptVouchers.Checked = false;

            if (TextEditVouchTypes.Text.Contains("HTL"))
                CheckEditHtlVouchers.Checked = true;
            else
                CheckEditHtlVouchers.Checked = false;

            if (TextEditVouchTypes.Text.Contains("SGL"))
                CheckEditSglResConf.Checked = true;
            else
                CheckEditSglResConf.Checked = false;

            if (TextEditVouchTypes.Text.Contains("CAR"))
                CheckEditCarVouchers.Checked = true;
            else
                CheckEditCarVouchers.Checked = false;

            if (TextEditVouchTypes.Text.Contains("CRU"))
                CheckEditCruVouchers.Checked = true;
            else
                CheckEditCruVouchers.Checked = false;

            if (TextEditVouchTypes.Text.Contains("AIR"))
                CheckEditAirVouchers.Checked = true;
            else
                CheckEditAirVouchers.Checked = false;

            if (TextEditVouchTypes.Text.Contains("PKG"))
                CheckEditPkgVouchers.Checked = true;
            else
                CheckEditPkgVouchers.Checked = false;
        }

        private bool move()
        {
            GridViewAgy.CloseEditor();
            TextEditNo.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms()) {
                errorProvider1.Clear();
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (AGY)AgyBindingSource.Current);
                TextEditNo.Properties.ReadOnly = true;
                GridViewAgy.Columns.ColumnByName(col).OptionsColumn.AllowEdit = false;
                newRec = false;
                modified = false;
                newRowRec = false;
                memberNewRowRec = false;
                newAgyLogRec = false;
                agyLogModified = false;
                return true;
            }
            return false;
        }
        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (newRowRec == true || memberNewRowRec == true) {
                if (newRowRec)
                    MessageBox.Show("Please save or delete the new record being added in the grid on the Contacts tab before attempting to navigate to another record.");
                else
                    MessageBox.Show("Please save or delete the new record being added in the grid on the Memberships tab before attempting to navigate to another record.");
                return;
            }
            if (move())
                AgyBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (newRowRec == true || memberNewRowRec == true) {
                if (newRowRec)
                    MessageBox.Show("Please save or delete the new record being added in the grid on the Contacts tab before attempting to navigate to another record.");
                else
                    MessageBox.Show("Please save or delete the new record being added in the grid on the Memberships tab before attempting to navigate to another record.");
                return;
            }
            if (move())
                AgyBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (newRowRec == true || memberNewRowRec == true) {
                if (newRowRec)
                    MessageBox.Show("Please save or delete the new record being added in the grid on the Contacts tab before attempting to navigate to another record.");
                else
                    MessageBox.Show("Please save or delete the new record being added in the grid on the Memberships tab before attempting to navigate to another record.");
                return;
            }
            if (move())
                AgyBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (newRowRec == true || memberNewRowRec == true) {
                if (newRowRec)
                    MessageBox.Show("Please save or delete the new record being added in the grid on the Contacts tab before attempting to navigate to another record.");
                else
                    MessageBox.Show("Please save or delete the new record being added in the grid on the Memberships tab before attempting to navigate to another record.");
                return;
            }
            if (move())
                AgyBindingSource.MoveLast();
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            //temp = newRec;
            //if (!temp && checkForms())
            //    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( AGY)AgyBindingSource.Current);

            //TextEditNo.Properties.ReadOnly = true;
            //GridViewAgy.Columns.ColumnByName(col).OptionsColumn.AllowEdit = false;
        }

        private void AgencyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (modified || newRec) {
                DialogResult select = DevExpress.XtraEditors.XtraMessageBox.Show("There are unsaved changes. Are you sure you want to exit?", Name, MessageBoxButtons.YesNo);
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

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (newRowRec == true || memberNewRowRec == true) {
                if (newRowRec)
                    MessageBox.Show("Please save or delete the new record being added in the grid on the Contacts tab before attempting to navigate to another record.");
                else
                    MessageBox.Show("Please save or delete the new record being added in the grid on the Memberships tab before attempting to navigate to another record.");

                e.Allow = false;
                return;
            }

            if (AgyBindingSource.Current == null) {
                e.Allow = true;
                return;
            }
            temp = newRec;
            bool temp2 = modified;
            ///////////////

            //if ((allowElecPayments && reqAgyInfoOnFile) && (currentCust == null || currentCust.PaymentProfiles.Count == 0))
            //{
            //    if (currentCust == null)
            //        MessageBox.Show("WARNING!. You are saving an agency without a payment customer profile.");
            //    else if (currentCust.PaymentProfiles.Count == 0)
            //        MessageBox.Show("WARNING!. You are saving an agency without a method of payment for the customer profile.");
            //}

            if (checkForms()) {
                newRec = false;
                modified = false;
                newRowRec = false;
                memberNewRowRec = false;
                newAgyLogRec = false;
                agyLogModified = false;
                errorProvider1.Clear();
                e.Allow = true;
                if ((!temp) && temp2)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (AGY)AgyBindingSource.Current);
                setReadOnly(true);
            }
            else {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (AGY)AgyBindingSource.Current);

                if (modified || newAgyCurrencyRec)  // if new agency currency was added and it had errors, user needs to correct them first
                    e.Allow = false;
                else
                    e.Allow = true;

            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewAgy.IsFilterRow(e.RowHandle))
                modified = true;
            labelControl25.Text = DateTime.Today.ToShortDateString();
            labelControl27.Text = username;
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void nOComboBox_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                    validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkNo, AgyBindingSource);
                    TextEditNo.Text = TextEditNo.Text.ToUpper();
                }
            }
        }

        private void nAMETextBox_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                    validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkName, AgyBindingSource);
                    TextEditName.Text = TextEditName.Text.ToUpper();
                }
            }
        }

        private void tYPTextBox_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkType, AgyBindingSource);
            }
        }

        private void aPTextBox_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkAp, AgyBindingSource);
            }
        }

        private void aRTextBox_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkAr, AgyBindingSource);
            }
        }

        private void defLangSearch_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkDefLang, AgyBindingSource);
            }
        }

        private void aDDR1TextBox_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkAddress1, AgyBindingSource);
            }
        }

        private void aDDR2TextBox_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkAddress2, AgyBindingSource);
            }
        }

        private void aDDR3TextBox_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkAddress3, AgyBindingSource);
            }
        }

        private void cITYTextEdit_Leave(object sender, System.EventArgs e)
        {

        }

        private void stateSearch_Leave(object sender, System.EventArgs e)
        {

        }

        private void zIPTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkZip, AgyBindingSource);
            }
        }

        private void countrySearch_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkCountry, AgyBindingSource);
            }
        }

        private void mAILFAX_FLGImageComboBoxEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkMailFax, AgyBindingSource);
            }
        }

        private void pHONETextBox_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkPhone, AgyBindingSource);
            }
        }

        private void fAX_NUMTextBox_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkFax, AgyBindingSource);
            }
        }

        private void eMAILTextBox_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkEmail, AgyBindingSource);
            }
        }

        private void rETREQHTLSImageComboBoxEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkRetReq, AgyBindingSource);
            }
        }

        private void rETNOTAVALHTLSImageComboBoxEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkRetNotAval, AgyBindingSource);
            }
        }

        private void rELSpinEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkRel, AgyBindingSource);
            }
        }

        private void aRVBKDAYSSpinEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkArkBkDays, AgyBindingSource);
            }
        }

        private void tourfaxEmailFormatImageComboBoxEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkTourEmail, AgyBindingSource);
            }
        }

        private void vOUCHER_REPRINTSSpinEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkVoucherReprints, AgyBindingSource);
            }
        }

        private void vOUCHER_DAYS_PRIORSpinEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkVouchDaysPrior, AgyBindingSource);
            }
        }

        private void oPT_DAYSSpinEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkOptDays, AgyBindingSource);
            }
        }

        private void cXLGRACESpinEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkGrace, AgyBindingSource);
            }
        }

        private void cOMMSpinEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkComm, AgyBindingSource);
            }
        }

        private void eDITHDRSImageComboBoxEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkEditHdr, AgyBindingSource);
            }
        }

        private void eDITHTLSImageComboBoxEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkEditHtl, AgyBindingSource);
            }
        }

        private void consrtSearch_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkConsrt, AgyBindingSource);
            }
        }

        private void dUE_DAYSpinEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkDueDays, AgyBindingSource);
            }
        }

        private void pMT_DAYSSpinEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkPmtDays, AgyBindingSource);
            }
        }

        private void pRIOR_DAYSSpinEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkPriorDays, AgyBindingSource);
            }
        }

        private void dAYS_SPACESpinEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkDaysSpace, AgyBindingSource);
            }
        }

        private void lAST_INVDateEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkLastInv, AgyBindingSource);
            }
        }

        private void iNV_FMTComboBoxEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkInvFormat, AgyBindingSource);
            }
        }

        private void cXL1_NTSPRIORSpinEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkCxlNights1, AgyBindingSource);
            }
        }

        private void cXL2_NTSPRIORSpinEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkCxlNights2, AgyBindingSource);
            }
        }

        private void cXL3_NTSPRIORSpinEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkCxlNights3, AgyBindingSource);
            }
        }

        private void cHG1_NTSPRIORSpinEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkChgNights1, AgyBindingSource);
            }
        }

        private void cHG2_NTSPRIORSpinEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkChgNights2, AgyBindingSource);
            }
        }

        private void cHG3_NTSPRIORSpinEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkChgNights3, AgyBindingSource);
            }
        }

        private void cXL1_PCTTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkCxlPct1, AgyBindingSource);
            }
        }

        private void cXL2_PCTTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkCxlPct2, AgyBindingSource);
            }
        }

        private void cXL3_PCTTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkCxlPct3, AgyBindingSource);
            }
        }

        private void cXL2_FLATTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).CheckCxlFlatFee1, AgyBindingSource);
            }
        }

        private void cXL3_FLATTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).CheckCxlFlatFee2, AgyBindingSource);
            }
        }

        private void cXL3_FLATTextEdit1_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).CheckCxlFlatFee3, AgyBindingSource);
            }
        }

        private void cHG1_PCTTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkChgPct1, AgyBindingSource);
            }
        }

        private void cHG2_PCTTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkChgPct2, AgyBindingSource);
            }
        }

        private void cHG3_PCTTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkChgPct3, AgyBindingSource);
            }
        }

        private void cHG1_FLATTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).CheckChgFlatFee1, AgyBindingSource);
            }
        }

        private void cHG2_FLATTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).CheckChgFlatFee2, AgyBindingSource);
            }
        }

        private void cHG3_FLATTextEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).CheckChgFlatFee3, AgyBindingSource);
            }
        }

        private void parentAgySearch_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkParentAgy, AgyBindingSource);
            }
        }

        private void wEBSITETextEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
            }
        }

        private void sRT2TextEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkSrt2, AgyBindingSource);
            }
        }

        private void sRT3TextEdit_Leave(object sender, System.EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkSrt3, AgyBindingSource);
            }
        }

        private void lOGO_PATHButtonEdit_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog()) {
                dlg.Title = "Open Image";
                dlg.InitialDirectory = imagesRoot;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    if (dlg.FileName.ToLower().IndexOf(imagesRoot.ToLower()) != -1)
                        ButtonEditLogoPath.Text = dlg.FileName.Substring(imagesRoot.Length);
                    else
                        ButtonEditLogoPath.Text = dlg.FileName;
                }
            }
        }

        private void lOGO_PATHButtonEdit_TextChanged(object sender, EventArgs e)
        {
            PictureEditPreview.Image = null;
            try {

                using (var stream = new MemoryStream(File.ReadAllBytes(imagesRoot + ButtonEditLogoPath.Text))) {
                    PictureEditPreview.Height = Image.FromStream(stream).Height;
                    PictureEditPreview.Width = Image.FromStream(stream).Width;
                    PictureEditPreview.Image = Image.FromStream(stream);
                    labelControlSize.Text = Image.FromStream(stream).Height + " * " + Image.FromStream(stream).Width;
                    errorProvider1.SetError(ButtonEditLogoPath, "");
                }
            }
            catch {
                try {
                    using (var stream = new MemoryStream(File.ReadAllBytes(ButtonEditLogoPath.Text))) {
                        PictureEditPreview.Height = Image.FromStream(stream).Height;
                        PictureEditPreview.Width = Image.FromStream(stream).Width;
                        PictureEditPreview.Image = Image.FromStream(stream);
                        labelControlSize.Text = Image.FromStream(stream).Height + " * " + Image.FromStream(stream).Width;
                        errorProvider1.SetError(ButtonEditLogoPath, "");
                    }
                }
                catch {
                    return;
                }
            }
        }

        private void lOGO_PATHButtonEdit_Leave(object sender, EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkLogo, AgyBindingSource);
            }
        }

        private void consrtStartDate_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void consrtEndDate_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void consrtStartDate_TextChanged(object sender, EventArgs e)
        {
            ButtonEditConsrtStartDate.Text = validCheck.convertDate(ButtonEditConsrtStartDate.Text);
        }

        private void consrtEndDate_TextChanged(object sender, EventArgs e)
        {
            ButtonEditConsrtEndDate.Text = validCheck.convertDate(ButtonEditConsrtEndDate.Text);
        }

        private void CheckEditHtlVouchers_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckEditHtlVouchers.Checked && !TextEditVouchTypes.Text.Contains("HTL")) {
                TextEditVouchTypes.Text = TextEditVouchTypes.Text.Trim();
                TextEditVouchTypes.Text += "HTL,";
            }

            if (!CheckEditHtlVouchers.Checked && TextEditVouchTypes.Text.Contains("HTL")) {
                int loc = TextEditVouchTypes.Text.IndexOf("HTL,");
                TextEditVouchTypes.Text = TextEditVouchTypes.Text.Remove(loc, 4);
            }
        }

        private void CheckEditCarVouchers_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckEditCruVouchers_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckEditAirVouchers_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckEditOptVouchers_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckEditPkgVouchers_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ButtonAddRow_Click(object sender, EventArgs e)
        {
            if (newRowRec == false) {
                if (GridViewContacts.RowCount == 0) {
                    newRowRec = true;
                    firstLoad = true;
                    GridViewContacts.AddNewRow();
                    GridViewContacts.SetFocusedRowCellValue("ID", int.MaxValue);
                    GridViewContacts.SetFocusedRowCellValue("LINK_TABLE", "AGY");
                    GridViewContacts.SetFocusedRowCellValue("LINK_VALUE", TextEditNo.Text);
                    GridViewContacts.SetFocusedRowCellValue("ACTIVE", 1);
                    GridViewContacts.SetFocusedRowCellValue("ADDRESS1", string.Empty);
                    GridViewContacts.SetFocusedRowCellValue("ADDRESS2", string.Empty);
                    GridViewContacts.SetFocusedRowCellValue("ADDRESS3", string.Empty);
                    GridViewContacts.SetFocusedRowCellValue("CITY", string.Empty);
                    GridViewContacts.SetFocusedRowCellValue("STATE", string.Empty);
                    GridViewContacts.SetFocusedRowCellValue("ZIP", string.Empty);
                    GridViewContacts.SetFocusedRowCellValue("GMACCTNO", string.Empty);
                    GridViewContacts.SetFocusedRowCellValue("GMRECID", string.Empty);
                    GridViewContacts.SetFocusedRowCellValue("DEPT_HEAD", false);
                    GridViewContacts.SetFocusedRowCellValue("COUNTRY", string.Empty);
                    GridViewContacts.SetFocusedRowCellValue("USER_DEC1", 0);
                    GridViewContacts.SetFocusedRowCellValue("USER_DEC2", 0);
                    GridViewContacts.SetFocusedRowCellValue("USER_INT1", 0);
                    GridViewContacts.SetFocusedRowCellValue("USER_INT2", 0);
                    GridViewContacts.SetFocusedRowCellValue("USER_TXT1", string.Empty);
                    GridViewContacts.SetFocusedRowCellValue("USER_TXT2", string.Empty);
                    GridViewContacts.SetFocusedRowCellValue("USER_TXT3", string.Empty);
                    GridViewContacts.SetFocusedRowCellValue("USER_TXT4", string.Empty);
                    GridViewContacts.SetFocusedRowCellValue("LOGIN_NAME", string.Empty);
                    GridViewContacts.SetFocusedRowCellValue("PASSWORD", string.Empty);
                    GridViewContacts.SetFocusedRowCellValue("LOGIN_ROLE", string.Empty);
                    GridViewContacts.SetFocusedRowCellValue("LOGIN_ACTIVE", false);
                    GridViewContacts.SetFocusedRowCellValue("RECTYPE", "AGYCONTACT");
                    GridViewContacts.SetFocusedRowCellValue("PARENT_ID", 0);
                    GridViewContacts.SetFocusedRowCellValue("TITLE", string.Empty);
                    GridViewContacts.SetFocusedRowCellValue("DEAR", string.Empty);
                    GridViewContacts.SetFocusedRowCellValue("PHONE", string.Empty);
                    GridViewContacts.SetFocusedRowCellValue("FAX", string.Empty);
                    modified = true;
                    return;
                }
                newRowRec = true;
                firstLoad = true;
                GridViewContacts.MoveLast();
                GridViewContacts.AddNewRow();
                GridViewContacts.SetFocusedRowCellValue("ID", int.MaxValue);
                GridViewContacts.SetFocusedRowCellValue("LINK_TABLE", "AGY");
                GridViewContacts.SetFocusedRowCellValue("LINK_VALUE", TextEditNo.Text);
                GridViewContacts.SetFocusedRowCellValue("ACTIVE", 1);
                GridViewContacts.SetFocusedRowCellValue("ADDRESS1", string.Empty);
                GridViewContacts.SetFocusedRowCellValue("ADDRESS2", string.Empty);
                GridViewContacts.SetFocusedRowCellValue("ADDRESS3", string.Empty);
                GridViewContacts.SetFocusedRowCellValue("CITY", string.Empty);
                GridViewContacts.SetFocusedRowCellValue("STATE", string.Empty);
                GridViewContacts.SetFocusedRowCellValue("ZIP", string.Empty);
                GridViewContacts.SetFocusedRowCellValue("GMACCTNO", string.Empty);
                GridViewContacts.SetFocusedRowCellValue("GMRECID", string.Empty);
                GridViewContacts.SetFocusedRowCellValue("DEPT_HEAD", false);
                GridViewContacts.SetFocusedRowCellValue("COUNTRY", string.Empty);
                GridViewContacts.SetFocusedRowCellValue("USER_DEC1", 0);
                GridViewContacts.SetFocusedRowCellValue("USER_DEC2", 0);
                GridViewContacts.SetFocusedRowCellValue("USER_INT1", 0);
                GridViewContacts.SetFocusedRowCellValue("USER_INT2", 0);
                GridViewContacts.SetFocusedRowCellValue("USER_TXT1", string.Empty);
                GridViewContacts.SetFocusedRowCellValue("USER_TXT2", string.Empty);
                GridViewContacts.SetFocusedRowCellValue("USER_TXT3", string.Empty);
                GridViewContacts.SetFocusedRowCellValue("USER_TXT4", string.Empty);
                GridViewContacts.SetFocusedRowCellValue("LOGIN_NAME", string.Empty);
                GridViewContacts.SetFocusedRowCellValue("PASSWORD", string.Empty);
                GridViewContacts.SetFocusedRowCellValue("LOGIN_ROLE", string.Empty);
                GridViewContacts.SetFocusedRowCellValue("LOGIN_ACTIVE", false);
                GridViewContacts.SetFocusedRowCellValue("RECTYPE", "AGYCONTACT");
                GridViewContacts.SetFocusedRowCellValue("PARENT_ID", 0);
                GridViewContacts.SetFocusedRowCellValue("TITLE", string.Empty);
                GridViewContacts.SetFocusedRowCellValue("DEAR", string.Empty);
                GridViewContacts.SetFocusedRowCellValue("PHONE", string.Empty);
                GridViewContacts.SetFocusedRowCellValue("FAX", string.Empty);
                GridViewContacts.SetFocusedRowCellValue("ACTIVE", 1);
                modified = true;
            }
            else
                MessageBox.Show("Please save current record before attempting to add another.");
        }

        private void ButtonSaveChanges_Click(object sender, EventArgs e)
        {
            GridViewContacts.FocusedColumn = GridViewContacts.Columns["LINK_TABLE"];
            if (GridViewContacts.UpdateCurrentRow()) {
                AgyBindingSource.EndEdit();
                aGYBindingNavigatorSaveItem_Click(sender, e);
                newRowRec = false;
                modified = false;
            }
        }

        private void DelRow_Click(object sender, EventArgs e)
        {
            int handle = GridViewContacts.FocusedRowHandle;
            GridViewContacts.DeleteRow(handle);
            AgyBindingSource.EndEdit();
            context.SaveChanges();
            newRowRec = false;
            modified = false;
        }

        private void AddButtonMemberships_Click(object sender, EventArgs e)
        {
            if (memberNewRowRec == false) {
                if (GridViewMemberships.RowCount == 0) {
                    GridViewMemberships.AddNewRow();
                    GridViewMemberships.SetFocusedRowCellValue("LINK_TABLE", "AGY");
                    GridViewMemberships.SetFocusedRowCellValue("RECTYPE", "AGYCLASS");
                    GridViewMemberships.SetFocusedRowCellValue("LINK_VALUE", TextEditNo.Text);
                    GridViewMemberships.SetFocusedRowCellValue("USER_DEC1", 0);
                    GridViewMemberships.SetFocusedRowCellValue("USER_DEC2", 0);
                    GridViewMemberships.SetFocusedRowCellValue("USER_INT1", 0);
                    GridViewMemberships.SetFocusedRowCellValue("USER_INT2", 0);
                    GridViewMemberships.SetFocusedRowCellValue("USER_TXT1", string.Empty);
                    GridViewMemberships.SetFocusedRowCellValue("USER_TXT2", string.Empty);
                    GridViewMemberships.SetFocusedRowCellValue("USER_TXT3", string.Empty);
                    GridViewMemberships.SetFocusedRowCellValue("USER_TXT4", string.Empty);
                    memberNewRowRec = true;
                    modified = true;
                    return;
                }
                GridViewMemberships.AddNewRow();
                GridViewMemberships.SetFocusedRowCellValue("LINK_TABLE", "AGY");
                GridViewMemberships.SetFocusedRowCellValue("RECTYPE", "AGYCLASS");
                GridViewMemberships.SetFocusedRowCellValue("LINK_VALUE", TextEditNo.Text);
                GridViewMemberships.SetFocusedRowCellValue("USER_DEC1", 0);
                GridViewMemberships.SetFocusedRowCellValue("USER_DEC2", 0);
                GridViewMemberships.SetFocusedRowCellValue("USER_INT1", 0);
                GridViewMemberships.SetFocusedRowCellValue("USER_INT2", 0);
                GridViewMemberships.SetFocusedRowCellValue("USER_TXT1", string.Empty);
                GridViewMemberships.SetFocusedRowCellValue("USER_TXT2", string.Empty);
                GridViewMemberships.SetFocusedRowCellValue("USER_TXT3", string.Empty);
                GridViewMemberships.SetFocusedRowCellValue("USER_TXT4", string.Empty);
                memberNewRowRec = true;
                modified = true;
            }
            else
                MessageBox.Show("Please save current record before attempting to add another.");
        }

        private void DelButtonMemberships_Click(object sender, EventArgs e)
        {
            int handle = GridViewMemberships.FocusedRowHandle;
            GridViewMemberships.DeleteRow(handle);
            DetailBindingSource.EndEdit();
            context.SaveChanges();
            memberNewRowRec = false;
            modified = false;
        }

        private void SaveButtonMemberships_Click(object sender, EventArgs e)
        {
            GridViewMemberships.FocusedColumn = GridViewMemberships.Columns["LINK_TABLE"];
            if (GridViewMemberships.UpdateCurrentRow()) {
                AgyBindingSource.EndEdit();
                aGYBindingNavigatorSaveItem_Click(sender, e);
                memberNewRowRec = false;
                modified = false;
            }
        }

        private void GridViewContacts_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "RptContact" && e.IsGetData) {
                CONTACT conRec = (CONTACT)e.Row;
                int id = conRec.ID;
                string load = String.Empty;
                if (id == int.MaxValue || id == 0) {
                    if (firstLoad == true) {
                        var values = from rec in context.RPTTYPE where rec.RecipientType == "Agy" select new { rec.CODE };
                        foreach (var result in values) {
                            if (!string.IsNullOrWhiteSpace(load))
                                load += "," + result.CODE;
                            else
                                load += result.CODE;
                        }
                        globalRptType = load;
                        firstLoad = false;
                    }
                    else {
                        load = globalRptType;
                    }
                }
                else {
                    var val = from rec in context.RptContact where rec.Contact_ID == id && rec.Code == TextEditNo.Text select new { rec.RptType };
                    foreach (var result in val) {
                        if (!string.IsNullOrWhiteSpace(load))
                            load += "," + result.RptType;
                        else
                            load += result.RptType;
                    }
                }
                e.Value = load;
            }
            if (e.Column.FieldName == "RptContact" && e.IsSetData) {
                CONTACT conRec = (CONTACT)e.Row;
                int id = conRec.ID;
                if (id == int.MaxValue || id == 0) {
                    globalRptType = e.Value.ToString();
                    modified = true;
                }
                else {
                    string value = e.Value.ToString();
                    var results = from rptRec in context.RptContact where !value.Contains(rptRec.RptType) && rptRec.Code == TextEditNo.Text && rptRec.Contact_ID == id select rptRec;
                    foreach (var result in results) {
                        context.RptContact.DeleteObject(result);
                    }
                    var val1 = (from rptRec in context.RPTTYPE
                                where value.Contains(rptRec.CODE)
                                select new { rptRec.CODE });
                    foreach (var result1 in val1) {
                        if ((from rptCont in context.RptContact where rptCont.Contact_ID == id && rptCont.Code == TextEditNo.Text && rptCont.RptType == result1.CODE select new { rptCont.Code }).Count() == 0) {
                            RptContact lol = new RptContact();
                            lol.Code = TextEditNo.Text;
                            lol.RptType = result1.CODE;
                            lol.Contact_ID = id;
                            context.RptContact.AddObject(lol);
                        }
                    }
                    context.SaveChanges();
                }
            }
        }

        private void AgencyForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewAgy.IsFilterRow(GridViewAgy.FocusedRowHandle))
                executeQuery();

        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewAgy.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewAgy.GetFocusedDisplayText()))
                value = GridViewAgy.GetFocusedDisplayText();
            //  value = "test";
            if (!string.IsNullOrWhiteSpace(value)) {
                string query = String.Format("it.NAME like '{0}%'", GridViewAgy.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "NAME"));
                var special = context.AGY.Where(query);
                if (!string.IsNullOrWhiteSpace(GridViewAgy.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "NO"))) {
                    query = String.Format("it.{0} like '{1}%'", "NO", GridViewAgy.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "NO"));
                    special = special.Where(query);
                }
                int count = special.Count();
                if (count > 0) {
                    AgyBindingSource.DataSource = special;
                    GridViewAgy.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                    GridViewAgy.FocusedRowHandle = 0;
                    GridViewAgy.FocusedColumn.FieldName = colName;
                    var agentLoad = from c in context.AGCYLOG
                                    where c.AGENCY == TextEditNo.Text
                                    select c;
                    AgcyLogBindingSource.DataSource = agentLoad;
                    GridViewAgy.ClearColumnsFilter();

                }
                else {
                    MessageBox.Show("No records in database.");
                    GridViewAgy.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            DoRowDoubleClick(view, pt);
        }

        private void repositoryItemPopupContainerEditRptType_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {
            e.Value += "," + (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CODE").ToString());
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            popupContainerControl1.OwnerEdit.ClosePopup();
        }

        private void DoRowDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell) {
                popupContainerControl1.OwnerEdit.ClosePopup();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            popupContainerControl1.OwnerEdit.CancelPopup();
        }

        private void CheckEditConfPrc_Modified(object sender, EventArgs e)
        {
            //modified = true;
        }

        private void CheckEditSglResConf_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckEditRemoteVouchers_Modified(object sender, EventArgs e)
        {
            // modified = true;
        }

        private void GridViewContacts_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            CONTACT record = (CONTACT)e.Row;
            if (record.COMM_PREF == "E" && string.IsNullOrWhiteSpace(record.EMAIL)) {
                e.Valid = false;
                view.SetColumnError(view.Columns["EMAIL"], "Email value must be filled out if preferred communication is selected as email.");
            }

            if (record.COMM_PREF == "F" && string.IsNullOrWhiteSpace(record.FAX)) {
                e.Valid = false;
                view.SetColumnError(view.Columns["FAX"], "Fax value must be filled out if preferred communication is selected as fax.");
            }
        }

        private void GridViewContacts_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void checkEdit9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit9.Checked) {
                SpinEditDueDays.Enabled = true;
                SpinEditPmtDays.Enabled = false;
                SpinEditPmtDays.Value = 0;
            }
            else {
                SpinEditDueDays.Enabled = false;
                SpinEditDueDays.Value = 0;
                SpinEditPmtDays.Enabled = true;
            }
        }

        private void ButtonEditLastInvDate_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void ButtonEditLastInvDate_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ButtonEditLastInvDate.Text))
                ButtonEditLastInvDate.Text = validCheck.convertDate(ButtonEditLastInvDate.Text);
        }

        private void ButtonEditDate_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void ButtonEditDate_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ButtonEditDate.Text))
                ButtonEditDate.Text = validCheck.convertDate(ButtonEditDate.Text);
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            DateTime? date;
            if (ButtonEditDate.Text == "") {
                date = null;
            }
            else {
                date = Convert.ToDateTime(ButtonEditDate.Text);
            }
            string agency = string.Empty;
            string source = string.Empty;
            if (string.IsNullOrWhiteSpace(ImageComboBoxEditAgency.Text))
                agency = TextEditNo.Text;
            else
                agency = ImageComboBoxEditAgency.Text;

            if (string.IsNullOrWhiteSpace(ComboBoxEditSource.Text))
                source = "ALL";
            else
                source = ComboBoxEditSource.Text;

            UpdateCommMarkupGrid(agency, date, source);
            //UpdateCommMarkupGrid(ImageComboBoxEditAgency.EditValue.ToString(), date, ComboBoxEditSource.EditValue);       
        }

        private void UpdateCommMarkupGrid(string Agency, DateTime? TheDate, string Source)
        {
            if (TheDate != null) {
                myCommRecsAgy = (from rec in context.COMPROD2
                                 where (rec.TYPE == "AGY") && (rec.Inactive == false) && ((rec.START_DATE <= TheDate) && (rec.END_DATE >= TheDate))
                                 select rec).ToList<IComprod2>();
            }
            else {
                myCommRecsAgy = (from rec in context.COMPROD2
                                 where (rec.TYPE == "AGY") && (rec.Inactive == false)
                                 select rec).ToList<IComprod2>();
            }

            myCommLvl = (from rec in context.CommLevel select rec).ToList<ICommLevel>();
            foreach (COMPROD2 rec in myCommRecsAgy) {
                rec.SetProductRulePosition(myCommLvl);
            }


            using (FlextourEntities context2 = new FlextourEntities(Connection.EFConnectionString)) {
                IList<FlexCommissions.Commission> commQuery1 = new List<FlexCommissions.Commission>();
                IList<FlexCommissions.Commission> commQuery2 = new List<FlexCommissions.Commission>();
                commQuery2 = FlexCommissions.Commissions.GetAgencyCommissions(context2, "C", myCommRecsAgy, myCommLvl, Agency, TheDate, null, null, Source);
                IList<FlexCommissions.Commission> mergedList = (commQuery1.Union(commQuery2)).ToList();
                GridControlCommissions.DataSource = mergedList;
                commQuery2 = FlexCommissions.Commissions.GetAgencyCommissions(context2, "M", myCommRecsAgy, myCommLvl, Agency, TheDate, null, null, Source);
                mergedList = (commQuery1.Union(commQuery2)).ToList();
                GridControlMarkups.DataSource = mergedList;
            }
        }

        private void CheckEditRemoteVouchers_CheckStateChanged(object sender, EventArgs e)
        {
            if (CheckEditRemoteVouchers.Checked) {
                CheckEditHtlVouchers.Enabled = true;
                //CheckEditHtlVouchers.Checked = true;
                CheckEditCarVouchers.Enabled = true;
                CheckEditCruVouchers.Enabled = true;
                CheckEditAirVouchers.Enabled = true;
                CheckEditOptVouchers.Enabled = true;
                CheckEditPkgVouchers.Enabled = true;
                CheckEditSglResConf.Enabled = true;
            }

            if (!CheckEditRemoteVouchers.Checked) {
                CheckEditHtlVouchers.Enabled = false;
                CheckEditHtlVouchers.Checked = false;
                CheckEditCarVouchers.Enabled = false;
                CheckEditCarVouchers.Checked = false;
                CheckEditCruVouchers.Enabled = false;
                CheckEditCruVouchers.Checked = false;
                CheckEditAirVouchers.Enabled = false;
                CheckEditAirVouchers.Checked = false;
                CheckEditOptVouchers.Enabled = false;
                CheckEditOptVouchers.Checked = false;
                CheckEditPkgVouchers.Enabled = false;
                CheckEditPkgVouchers.Checked = false;
                CheckEditSglResConf.Enabled = false;
                CheckEditSglResConf.Checked = false;
            }

        }

        private void GridViewContacts_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {

        }

        private void panelControl14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ImageComboBoxEditCity_Leave(object sender, EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkTown, AgyBindingSource);
            }
        }

        private void SpinEditDueDays_TextChanged(object sender, EventArgs e)
        {
            if (SpinEditDueDays.Value > 0) {
                SpinEditDueDays.Enabled = true;
                SpinEditPmtDays.Enabled = false;
                checkEdit9.Checked = true;
            }
            else {
                SpinEditDueDays.Enabled = false;
                SpinEditPmtDays.Enabled = true;
                checkEdit9.Checked = false;
            }
        }

        private void checkEdit9_Click(object sender, EventArgs e)
        {
            modified = true;
            if (checkEdit9.Checked) {
                SpinEditDueDays.Enabled = true;
                SpinEditPmtDays.Enabled = false;
            }
            else {
                SpinEditDueDays.Enabled = false;
                SpinEditPmtDays.Enabled = true;
            }
        }

        private void ImageComboBoxEditState_Leave(object sender, EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkState, AgyBindingSource);
            }
        }

        private void loadDirectory()
        {
            string path = "";
            var value = Environment.GetCommandLineArgs();
            foreach (string dir in value) {

                if (dir.StartsWith("/data=")) {

                    path = dir.Substring("/data=".Length, dir.Length - "/data=".Length);
                    //xDoc.LoadXml(path + "flexlic.dat");
                }
            }
            if (string.IsNullOrEmpty(path))
                path = "Files";
            string registry_key = @"SOFTWARE\Flextour\" + path;

            RegistryKey subKey = Registry.LocalMachine.OpenSubKey(registry_key);
            string sDataDir = subKey.GetValue("Data", "").ToString();

            if (!sDataDir.EndsWith(@"\"))
                sDataDir += @"\";
            //string[] allAtb = Directory.GetFiles(sDataDir, "*.atb");
            string[] resfiles = Directory.GetFiles(sDataDir, "res_*.atb");
            string[] accfiles = Directory.GetFiles(sDataDir, "acc_*.atb");
            string[] mntfiles = Directory.GetFiles(sDataDir, "mnt_*.atb");
            string[] prtfiles = Directory.GetFiles(sDataDir, "rpt_*.atb");
            foreach (string val in resfiles) {
                ComboBoxEditResProf.Properties.Items.Add((val.Remove(0, sDataDir.Length + 4)).Replace(".atb", "").Replace(".ATB", ""));
            }
            foreach (string val in accfiles) {
                ComboBoxEditAccProf.Properties.Items.Add((val.Remove(0, sDataDir.Length + 4)).Replace(".atb", "").Replace(".ATB", "").Replace(".ATb", ""));
            }
            foreach (string val in mntfiles)
                ComboBoxEditMntProf.Properties.Items.Add((val.Remove(0, sDataDir.Length + 4)).Replace(".atb", "").Replace(".ATB", "").Replace(".ATb", ""));
            foreach (string val in prtfiles)
                ComboBoxEditPrtProf.Properties.Items.Add((val.Remove(0, sDataDir.Length + 4)).Replace(".atb", "").Replace(".ATB", ""));



        }

        private void g(object sender, EventArgs e)
        {

        }
        private void setAgcyLogValues()
        {
            GridViewAgcyLog.SetFocusedRowCellValue("AGT_NAME", string.Empty);
            GridViewAgcyLog.SetFocusedRowCellValue("AGENCY", TextEditNo.Text);
            GridViewAgcyLog.SetFocusedRowCellValue("AGCY_NAME", TextEditName.Text);
            GridViewAgcyLog.SetFocusedRowCellValue("CUR_BOOK", 0);
            GridViewAgcyLog.SetFocusedRowCellValue("SUPVR_FLG", "N");
            GridViewAgcyLog.SetFocusedRowCellValue("RES_PROF", string.Empty);
            GridViewAgcyLog.SetFocusedRowCellValue("MNT_PROF", string.Empty);
            GridViewAgcyLog.SetFocusedRowCellValue("ACC_PROF", string.Empty);
            GridViewAgcyLog.SetFocusedRowCellValue("PRT_PROF", string.Empty);
            GridViewAgcyLog.SetFocusedRowCellValue("AGT_EMAIL", string.Empty);
            GridViewAgcyLog.SetFocusedRowCellValue("AGT_FAX", string.Empty);
            GridViewAgcyLog.SetFocusedRowCellValue("PASSWORD", string.Empty);
            GridViewAgcyLog.SetFocusedRowCellValue("PHONE", string.Empty);

        }

        void setAgcyLogReadOnly(bool value)
        {
            TextEditAgtName.Properties.ReadOnly = value;
        }


        private void agcyLogAddNew_Click(object sender, EventArgs e)
        {
            enableAgcyLogNavigator(true);
            GridViewAgcyLog.CloseEditor();
            if (!CheckEditActiveFlg.Checked) {
                if (MessageBox.Show("This agency is no longer active. Proceed?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }
            TextEditAgtName.Focus();
            // bindingNavigatorPositionItem.Focus();
            if (GridViewAgy.RowCount > 0 && !String.IsNullOrWhiteSpace(TextEditName.Text) && !String.IsNullOrWhiteSpace(TextEditNo.Text) && newAgyLogRec == false) {
                if (AgcyLogBindingSource.Current == null) {
                    AgcyLogBindingSource.DataSource = from opt in context.AGCYLOG where opt.AGENCY == "KJM9" select opt;
                    AgcyLogBindingSource.AddNew();
                    setAgcyLogValues();
                    newAgyLogRec = true;
                    agyLogModified = true;
                    setAgcyLogReadOnly(false);

                    return;
                }
                else {
                    AgcyLogBindingSource.AddNew();
                    setAgcyLogValues();
                    newAgyLogRec = true;
                    agyLogModified = true;
                    setAgcyLogReadOnly(false);
                }
            }


        }

        private void AgcyLogDelete_Click(object sender, EventArgs e)
        {
            if (AgcyLogBindingSource.Current == null)
                return;
            GridViewAgcyLog.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                try {
                    AgcyLogBindingSource.RemoveCurrent();
                    context.SaveChanges();
                    newAgyLogRec = false;
                    agyLogModified = false;
                    setAgcyLogReadOnly(true);
                }
                catch (Exception ex) {
                    DisplayHelper.DisplayError(this, ex);
                }

            }
            currentVal = TextEditNo.Text;
        }

        private void AgcyLogSave_Click(object sender, EventArgs e)
        {
            TextEditNo.Focus();
            if (GridViewAgcyLog.UpdateCurrentRow()) {
                AgcyLogBindingSource.EndEdit();
                aGYBindingNavigatorSaveItem_Click(sender, e);
                newAgyLogRec = false;
                agyLogModified = false;
                setAgcyLogReadOnly(true);
            }
        }

        private void TextEditNo_TextChanged(object sender, EventArgs e)
        {
            if (TextEditNo.Text != defAgy) {
                imageComboBoxEditAgentDelegate.Enabled = false;
                imageComboBoxEditAgentDelegate.Properties.Items.Clear();
                CheckEditSuprvrFlg.Enabled = false;
                ComboBoxEditMntProf.Properties.ReadOnly = true;
                ComboBoxEditAccProf.Properties.ReadOnly = true;
                ComboBoxEditPrtProf.Properties.ReadOnly = true;
            }
            else {
                imageComboBoxEditAgentDelegate.Enabled = true;
                CheckEditSuprvrFlg.Enabled = true;
                TextEditAgtName.Enabled = true;
                TextEditPassword.Enabled = true;
                TextEditAgtEmail.Enabled = true;
                TextEditAgtFax.Enabled = true;
                ComboBoxEditResProf.Enabled = true;
                ComboBoxEditMntProf.Properties.ReadOnly = false;
                ComboBoxEditAccProf.Properties.ReadOnly = false;
                ComboBoxEditPrtProf.Properties.ReadOnly = false;
            }
        }

        private void CheckEditActiveFlg_EditValueChanged(object sender, EventArgs e)
        {
            //string value =  CheckEditActiveFlg.EditValue.ToString();
            //if (value == "I")
            //{
            //    TextEditAgtEmail.Properties.ReadOnly = true;
            //    TextEditAgtFax.Properties.ReadOnly = true;
            //    TextEditAgtName.Properties.ReadOnly = true;
            //    TextEditPassword.Properties.ReadOnly = true;
            //    CheckEditSuprvrFlg.Properties.ReadOnly = true;
            //    ComboBoxEditResProf.Properties.ReadOnly = true;
            //    ComboBoxEditMntProf.Properties.ReadOnly = true;
            //    ComboBoxEditAccProf.Properties.ReadOnly = true;
            //    ComboBoxEditPrtProf.Properties.ReadOnly = true;
            //}
            //else
            //{
            //    TextEditAgtEmail.Properties.ReadOnly = false;
            //    TextEditAgtFax.Properties.ReadOnly = false;
            //    TextEditAgtName.Properties.ReadOnly = false;
            //    TextEditPassword.Properties.ReadOnly = false;
            //    CheckEditSuprvrFlg.Properties.ReadOnly = false;
            //    ComboBoxEditResProf.Properties.ReadOnly = false;
            //    ComboBoxEditMntProf.Properties.ReadOnly = false;
            //    ComboBoxEditAccProf.Properties.ReadOnly = false;
            //    ComboBoxEditPrtProf.Properties.ReadOnly = false;
            //}
        }

        private void TextEditAgtName_Leave(object sender, EventArgs e)
        {
            if (AgcyLogBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    agyLogModified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGCYLOG)AgcyLogBindingSource.Current).checkName, AgcyLogBindingSource);
            }
        }

        private void TextEditPassword_Leave(object sender, EventArgs e)
        {
            if (AgcyLogBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    agyLogModified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGCYLOG)AgcyLogBindingSource.Current).checkPassword, AgcyLogBindingSource);
            }
        }

        private void TextEditAgtEmail_Leave(object sender, EventArgs e)
        {
            if (AgcyLogBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    agyLogModified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGCYLOG)AgcyLogBindingSource.Current).checkEmail, AgcyLogBindingSource);
            }

        }

        private void TextEditAgtFax_Leave(object sender, EventArgs e)
        {
            if (AgcyLogBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    agyLogModified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGCYLOG)AgcyLogBindingSource.Current).checkFax, AgcyLogBindingSource);
            }
        }

        private void ComboBoxEditResProf_Leave(object sender, EventArgs e)
        {
            if (AgcyLogBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    agyLogModified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGCYLOG)AgcyLogBindingSource.Current).checkResProf, AgcyLogBindingSource);
            }
        }

        private void ComboBoxEditMntProf_Leave(object sender, EventArgs e)
        {
            if (AgcyLogBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    agyLogModified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGCYLOG)AgcyLogBindingSource.Current).checkMntProf, AgcyLogBindingSource);
            }
        }

        private void ComboBoxEditPrtProf_Leave(object sender, EventArgs e)
        {
            if (AgcyLogBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    agyLogModified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGCYLOG)AgcyLogBindingSource.Current).checkPrtProf, AgcyLogBindingSource);
            }
        }

        private void ComboBoxEditAccProf_Leave(object sender, EventArgs e)
        {
            if (AgcyLogBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {

                    agyLogModified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((AGCYLOG)AgcyLogBindingSource.Current).checkAccProf, AgcyLogBindingSource);
            }
        }

        private void CheckEditSuprvrFlg_Click(object sender, EventArgs e)
        {
            modified = true;
        }

        private void CheckEditActiveFlg_Click(object sender, EventArgs e)
        {
            modified = true;
        }

        private void CheckEditSubAlloc_Click(object sender, EventArgs e)
        {
            modified = true;
        }

        private void CheckEditPkgVouchers_Click(object sender, EventArgs e)
        {
            modified = true;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (GridViewAgcyLog.RowCount > 0) {
                if (newAgyLogRec || agyLogModified) {
                    MessageBox.Show("Please save or delete the new/modified agent being added on the Agents tab before attempting to navigate to another agent.");
                    return;
                }
                if (move())
                    AgcyLogBindingSource.MoveNext();
            }
        }

        private void GridViewContacts_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (!GridViewContacts.IsFilterRow(e.RowHandle)) {
                modified = true;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (GridViewAgcyLog.RowCount > 0) {
                if (newAgyLogRec || agyLogModified) {
                    MessageBox.Show("Please save or delete the new/modified agent being added on the Agents tab before attempting to navigate to another agent.");
                    return;
                }
                if (move())
                    AgcyLogBindingSource.MoveLast();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //previous
            if (GridViewAgcyLog.RowCount > 0) {
                if (newAgyLogRec || agyLogModified) {
                    MessageBox.Show("Please save or delete the new/modified agent being added on the Agents tab before attempting to navigate to another agent.");
                    return;
                }
                if (move())
                    AgcyLogBindingSource.MovePrevious();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //move first
            if (GridViewAgcyLog.RowCount > 0) {
                if (newAgyLogRec || agyLogModified) {
                    MessageBox.Show("Please save or delete the new/modified agent being added on the Agents tab before attempting to navigate to another agent.");
                    return;
                }
                if (move())
                    AgcyLogBindingSource.MoveFirst();
            }
        }

        private void LookupButtonOk_Click(object sender, EventArgs e)
        {
            popupContainerControlLookup.OwnerEdit.ClosePopup();
        }

        private void LookupButtonCancel_Click(object sender, EventArgs e)
        {
            popupContainerControlLookup.OwnerEdit.CancelPopup();
        }

        private void repositoryItemPopupContainerEdit1_QueryResultValue(object sender, QueryResultValueEventArgs e)
        {
            GridViewMemberships.SetFocusedRowCellValue("NOTE", GridViewLookup.GetRowCellValue(GridViewLookup.FocusedRowHandle, "DESC").ToString());
            e.Value = GridViewLookup.GetRowCellValue(GridViewLookup.FocusedRowHandle, "CODE").ToString();

        }

        private void GridViewLookup_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            RowDoubleClick(view, pt);
        }

        private void RowDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell) {
                popupContainerControlLookup.OwnerEdit.ClosePopup();
            }
        }

        private void CheckEditSuprvrFlg_Click_1(object sender, EventArgs e)
        {
            modified = true;
        }

        private void GridViewMemberships_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            modified = true;

        }

        private void PanelControlAgentTab_Enter(object sender, EventArgs e)
        {
            if (!CheckEditActiveFlg.Checked && !proceed) {
                if (MessageBox.Show("This agency is no longer active. Proceed?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.No) {
                    TextEditNo.Focus();
                }
                else
                    proceed = true;
            }
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            //AuthorizeNet.CustomerGateway conn = new AuthorizeNet.CustomerGateway(apiLogin, transactionKey, AuthorizeNet.ServiceMode.Test);
            if (string.IsNullOrWhiteSpace(TextEditPaymentProcessorCustProfileEmail.Text)) {
                MessageBox.Show("Please enter a value for the Customer Email Address");
                return;
            }
            currentCust = conn.CreateCustomer(TextEditPaymentProcessorCustProfileEmail.Text, TextEditName.Text);
            paymentProcessorCustProfileIdLabel1.Text = currentCust.ProfileID;
            // labelControl22.Text = currentCust.ProfileID;
            currentCust.ID = TextEditNo.Text;
            conn.UpdateCustomer(currentCust);
            CreateButton.Enabled = false;
            DeleteButton.Enabled = true;
            UpdateButton.Enabled = true;
            AddBankButton.Enabled = true;
            DelBankButton.Enabled = true;
            AddCreditButton.Enabled = true;
            DelCredButton.Enabled = true;

            context.SaveChanges();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < currentCust.PaymentProfiles.Count; i++)
            //{
            //    if (!string.IsNullOrWhiteSpace(currentCust.PaymentProfiles[i].CardNumber))
            //    {
            //        AuthorizeNet.APICore.customerPaymentProfileMaskedType api = new AuthorizeNet.APICore.customerPaymentProfileMaskedType();
            //        api.payment = new AuthorizeNet.APICore.paymentMaskedType();
            //        api.payment.Item = new AuthorizeNet.APICore.creditCardMaskedType();
            //        api.customerType = AuthorizeNet.APICore.customerTypeEnum.business;
            //        api.customerTypeSpecified = true;                    
            //        AuthorizeNet.PaymentProfile rec = new AuthorizeNet.PaymentProfile(api);
            //        rec.BillingAddress = currentCust.PaymentProfiles[i].BillingAddress;
            //        if (!string.IsNullOrWhiteSpace(currentCust.PaymentProfiles[i].CardType))
            //            rec.CardType = currentCust.PaymentProfiles[i].CardType;
            //        if (!string.IsNullOrWhiteSpace(currentCust.PaymentProfiles[i].CardCode))
            //            rec.CardCode = currentCust.PaymentProfiles[i].CardCode;

            //        rec.CardNumber = currentCust.PaymentProfiles[i].CardNumber;
            //        rec.CardExpiration = currentCust.PaymentProfiles[i].CardExpiration;
            //        rec.ProfileID = currentCust.PaymentProfiles[i].ProfileID;
            //        conn.UpdatePaymentProfile(currentCust.ProfileID, rec);

            //        if (!string.IsNullOrWhiteSpace(currentCust.PaymentProfiles[i].CardType))
            //        {
            //            string last4 = "XXXX" + "-" + rec.CardNumber.GetLast(4);
            //            AgencyPaymentProfile updateRec = (from agyRec in context.AgencyPaymentProfile where agyRec.Agy_No == TextEditNo.Text && agyRec.PaymentProfileID == rec.ProfileID select agyRec).FirstOrDefault();
            //            //newCredRecord.Agy_No = TextEditNo.Text;
            //            //newCredRecord.PaymentProfileID = rec.ProfileID;
            //            updateRec.PaymentProvider = rec.CardType;
            //            updateRec.LastDigits = last4;
            //            updateRec.ExpirationMonth = Convert.ToInt32(rec.CardExpiration.GetLast(2));
            //            updateRec.ExpirationYear = Convert.ToInt32(rec.CardExpiration.Substring(0, 4));
            //            context.SaveChanges();
            //        }
            //       // context.AgencyPaymentProfile.AddObject(newCredRecord);
            //    }
            //    else if (!string.IsNullOrWhiteSpace(currentCust.PaymentProfiles[i].BankAccountNumber))
            //    {
            //        AuthorizeNet.APICore.customerPaymentProfileMaskedType api = new AuthorizeNet.APICore.customerPaymentProfileMaskedType();
            //        api.payment = new AuthorizeNet.APICore.paymentMaskedType();
            //        api.payment.Item = new AuthorizeNet.APICore.bankAccountMaskedType();
            //        api.customerType = AuthorizeNet.APICore.customerTypeEnum.business;
            //        api.customerTypeSpecified = true;
            //        AuthorizeNet.PaymentProfile rec = new AuthorizeNet.PaymentProfile(api);
            //        rec.BillingAddress = currentCust.PaymentProfiles[i].BillingAddress;
            //        rec.AccountType = currentCust.PaymentProfiles[i].AccountType;
            //        rec.AccountTypeSpecified = currentCust.PaymentProfiles[i].AccountTypeSpecified;
            //        rec.BankAccountNumber = currentCust.PaymentProfiles[i].BankAccountNumber;
            //        rec.BankName = currentCust.PaymentProfiles[i].BankName;
            //        rec.BankNameOnAccount = currentCust.PaymentProfiles[i].BankNameOnAccount;
            //        if (!string.IsNullOrWhiteSpace(currentCust.PaymentProfiles[i].BankRoutingNumber))
            //            rec.BankRoutingNumber = currentCust.PaymentProfiles[i].BankRoutingNumber;
            //        rec.IsBusiness = currentCust.PaymentProfiles[i].IsBusiness;
            //        rec.ProfileID = currentCust.PaymentProfiles[i].ProfileID;
            //        conn.UpdatePaymentProfile(currentCust.ProfileID, rec);
            //        string last4 = "XXXX" + "-" + rec.BankAccountNumber.GetLast(4);
            //        AgencyPaymentProfile updateRec = (from agyRec in context.AgencyPaymentProfile where agyRec.Agy_No == TextEditNo.Text && agyRec.PaymentProfileID == rec.ProfileID select agyRec).FirstOrDefault();
            //        //newCredRecord.Agy_No = TextEditNo.Text;
            //        //newCredRecord.PaymentProfileID = rec.ProfileID;

            //        updateRec.PaymentProvider = rec.BankName;
            //        updateRec.LastDigits = last4;
            //        context.SaveChanges();
            //    }


            //}
            foreach (AuthorizeNet.PaymentProfile rec in creditCards) {
                //  
                if (rec.CardNumber.Length > 8 || rec.CardExpiration.Length > 4) {
                    AgencyPaymentProfile updateRec = (from agyRec in context.AgencyPaymentProfile where agyRec.Agy_No == TextEditNo.Text && agyRec.PaymentProfileID == rec.ProfileID select agyRec).FirstOrDefault();
                    if (rec.CardNumber.Length > 8)
                        updateRec.PaymentProvider = (GetCardTypeFromNumber(rec.CardNumber)).ToString();
                    updateRec.LastDigits = rec.CardNumber.GetLast(4);
                    updateRec.ExpirationMonth = Convert.ToInt32(rec.CardExpiration.GetLast(2));
                    updateRec.ExpirationYear = Convert.ToInt32(rec.CardExpiration.Substring(0, 4));
                    conn.UpdatePaymentProfile(currentCust.ProfileID, rec);
                    context.SaveChanges();
                }
            }

            foreach (AuthorizeNet.PaymentProfile rec in bankAccnts) {
                // conn.UpdatePaymentProfile(currentCust.ProfileID, rec);
                if (rec.BankAccountNumber.Length > 8) {
                    AgencyPaymentProfile updateRec = (from agyRec in context.AgencyPaymentProfile where agyRec.Agy_No == TextEditNo.Text && agyRec.PaymentProfileID == rec.ProfileID select agyRec).FirstOrDefault();
                    updateRec.PaymentProvider = rec.BankName;
                    updateRec.LastDigits = rec.CardNumber.GetLast(4);
                    conn.UpdatePaymentProfile(currentCust.ProfileID, rec);
                    context.SaveChanges();
                }
            }
            currentCust.Email = TextEditPaymentProcessorCustProfileEmail.Text;
            conn.UpdateCustomer(currentCust);
            context.SaveChanges();
            //currentCust = conn.GetCustomer(labelControl22.Text);
            if (currentCust.PaymentProfiles.Count() > 0)
                loadAuthorize(currentCust);

        }

        private void AddCreditButton_Click(object sender, EventArgs e)
        {
            //List<AuthorizePaymentProfile> test = new List<AuthorizePaymentProfile>();
            //AuthorizePaymentProfile rec = new AuthorizePaymentProfile();
            //test.Add(rec);
            //GridControlAuthorizeCredit.DataSource = test;

            if (!authorizeCreditMod) {
                UpdateButton.Enabled = false;
                gridCntrlPaymentProfiles.DataSource = null;
                AuthorizeNet.APICore.customerPaymentProfileMaskedType api = new AuthorizeNet.APICore.customerPaymentProfileMaskedType();
                api.payment = new AuthorizeNet.APICore.paymentMaskedType();
                api.payment.Item = new AuthorizeNet.APICore.creditCardMaskedType();
                api.customerType = AuthorizeNet.APICore.customerTypeEnum.business;
                api.customerTypeSpecified = true;
                AuthorizeNet.Address billing = new AuthorizeNet.Address();

                //apiType.payment.Item is creditCardMaskedType
                AuthorizeNet.PaymentProfile rec = new AuthorizeNet.PaymentProfile(api);

                rec.BillingAddress = billing;
                creditCards.Add(rec);

                gridCntrlPaymentProfiles.DataSource = creditCards;
                gridViewPaymentProfiles.FocusedRowHandle = creditCards.Count - 1;
                //gridViewPaymentProfiles.AddNewRow();
                authorizeCurrentRow.Add(creditCards.Count - 1);
                authorizeCreditMod = true;
            }
            else
                MessageBox.Show("Please save the current profile before attempting to add another.");

            //GridViewAuthorizeCredit.AddNewRow();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //AuthorizePaymentProfile result = (AuthorizePaymentProfile)GridViewAuthorizeCredit.GetRow(0);


        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

            //delete
            if (MessageBox.Show("Are you sure you want to delete the customer profile?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                conn.DeleteCustomer(currentCust.ProfileID);
                var recs = from payRec in context.AgencyPaymentProfile where payRec.Agy_No == TextEditNo.Text select payRec;
                foreach (AgencyPaymentProfile record in recs)
                    context.DeleteObject(record);
                GridViewAgy.SetFocusedRowCellValue("PaymentProcessorCustProfileId", string.Empty);
                GridViewAgy.SetFocusedRowCellValue("PaymentProcessorCustProfileEmail", string.Empty);
                GridViewAgy.SetFocusedRowCellValue("DefaultPaymentProfileId", string.Empty);
                GridViewAgy.SetFocusedRowCellValue("DefaultPaymentProfileId", string.Empty);
                ImageComboBoxEditDefaultProfileID.Properties.Items.Clear();
                ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = string.Empty };
                ImageComboBoxEditDefaultProfileID.Properties.Items.Add(loadBlank);
                context.SaveChanges();

            }


        }

        private void AddBankButton_Click(object sender, EventArgs e)
        {
            if (!authorizeBankMod) {
                UpdateButton.Enabled = false;
                gridControlBankProfiles.DataSource = null;
                AuthorizeNet.APICore.customerPaymentProfileMaskedType api = new AuthorizeNet.APICore.customerPaymentProfileMaskedType();
                api.payment = new AuthorizeNet.APICore.paymentMaskedType();
                api.payment.Item = new AuthorizeNet.APICore.bankAccountMaskedType();
                api.customerType = AuthorizeNet.APICore.customerTypeEnum.business;
                api.customerTypeSpecified = true;
                AuthorizeNet.Address billing = new AuthorizeNet.Address();

                //apiType.payment.Item is creditCardMaskedType
                AuthorizeNet.PaymentProfile rec = new AuthorizeNet.PaymentProfile(api);

                rec.BillingAddress = billing;
                bankAccnts.Add(rec);

                gridControlBankProfiles.DataSource = bankAccnts;
                //gridViewPaymentProfiles.AddNewRow();
                authorizeCurrentBankRow.Add(bankAccnts.Count - 1);
                authorizeBankMod = true;
            }
            else
                MessageBox.Show("Please save the current profile before attempting to add another.");

        }



        private void TextEditPaymentProcessorCustProfileEmail_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void DelCredButton_Click_1(object sender, EventArgs e)
        {
            AuthorizeNet.PaymentProfile rec = (AuthorizeNet.PaymentProfile)gridViewPaymentProfiles.GetFocusedRow();
            if (rec.ProfileID != null) {
                AgencyPaymentProfile delRec = (from agyRec in context.AgencyPaymentProfile where agyRec.PaymentProfileID == rec.ProfileID select agyRec).FirstOrDefault();
                conn.DeletePaymentProfile(currentCust.ProfileID, rec.ProfileID);
                if (delRec != null) {
                    if (ImageComboBoxEditDefaultProfileID.Text == delRec.PaymentProfileDesc)
                        GridViewAgy.SetFocusedRowCellValue("DefaultPaymentProfileId", string.Empty);
                    context.DeleteObject(delRec);
                    context.SaveChanges();
                }
                currentCust = conn.GetCustomer(currentCust.ProfileID);
                gridCntrlPaymentProfiles.DataSource = null;
                gridControlBankProfiles.DataSource = null;
                loadAuthorize(currentCust);
                authorizeCreditMod = false;
            }
            else {
                authorizeCreditMod = false;
                gridCntrlPaymentProfiles.DataSource = null;
                gridControlBankProfiles.DataSource = null;
                creditCards.RemoveAt(creditCards.Count - 1);
                loadAuthorize(currentCust);

            }
        }

        private void DelBankButton_Click(object sender, EventArgs e)
        {
            AuthorizeNet.PaymentProfile rec = (AuthorizeNet.PaymentProfile)gridViewBankProfiles.GetFocusedRow();
            if (rec.ProfileID != null) {
                conn.DeletePaymentProfile(currentCust.ProfileID, rec.ProfileID);
                currentCust = conn.GetCustomer(currentCust.ProfileID);
                //remove rec in payment table
                AgencyPaymentProfile delRec = (from agyRec in context.AgencyPaymentProfile where agyRec.PaymentProfileID == rec.ProfileID select agyRec).FirstOrDefault();
                if (delRec != null) {
                    if (ImageComboBoxEditDefaultProfileID.Text == delRec.PaymentProfileDesc)
                        ImageComboBoxEditDefaultProfileID.Text = string.Empty;
                    context.AgencyPaymentProfile.DeleteObject(delRec);
                    context.SaveChanges();
                }
                gridCntrlPaymentProfiles.DataSource = null;
                gridControlBankProfiles.DataSource = null;
                loadAuthorize(currentCust);
                authorizeBankMod = false;
            }
            else {
                authorizeBankMod = false;
                gridCntrlPaymentProfiles.DataSource = null;
                gridControlBankProfiles.DataSource = null;
                bankAccnts.RemoveAt(bankAccnts.Count - 1);
                loadAuthorize(currentCust);

            }
        }

        private void gridViewPaymentProfiles_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void gridViewPaymentProfiles_ValidateRow(object sender, ValidateRowEventArgs e)
        {

            ColumnView view = sender as ColumnView;
            AuthorizeNet.PaymentProfile record = (AuthorizeNet.PaymentProfile)e.Row;
            view.ClearColumnErrors();
            DateTime Test;
            if (string.IsNullOrWhiteSpace(record.CardExpiration) || string.IsNullOrWhiteSpace(record.CardNumber)) {
                if (string.IsNullOrWhiteSpace(record.CardExpiration)) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["CardExpiration"], "Please enter the expiration date (YYYY-MM).");
                }

                if (string.IsNullOrWhiteSpace(record.CardNumber)) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["CardNumber"], "Please enter the card number.");
                }
            }

            if (!string.IsNullOrWhiteSpace(record.CardCode) && !validCheck.IsNumeric(record.CardCode)) {
                e.Valid = false;
                view.SetColumnError(view.Columns["CardCode"], "The card code must be numeric.");
            }

            if (!string.IsNullOrWhiteSpace(record.BillingAddress.First) && (record.BillingAddress.First.Length > 50 || !record.BillingAddress.First.All(Char.IsLetterOrDigit))) {
                if (record.BillingAddress.First.Length > 50) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BillingAddress.First"], "The max length of this field is 50.");
                }
                //if (!record.BillingAddress.First.All(Char.IsLetterOrDigit))
                //{
                //    e.Valid = false;
                //    view.SetColumnError(view.Columns["BillingAddress.First"], "This field cannot contain symbols.");
                //}
            }

            if (!string.IsNullOrWhiteSpace(record.BillingAddress.Last) && (record.BillingAddress.Last.Length > 50 || !record.BillingAddress.Last.All(Char.IsLetterOrDigit))) {
                if (record.BillingAddress.Last.Length > 50) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BillingAddress.Last"], "The max length of this field is 50.");
                }
                //if (!record.BillingAddress.Last.All(Char.IsLetterOrDigit))
                //{
                //    e.Valid = false;
                //    view.SetColumnError(view.Columns["BillingAddress.Last"], "This field cannot contain symbols.");
                //}
            }

            if (!string.IsNullOrWhiteSpace(record.BillingAddress.Company)) {
                if (record.BillingAddress.Company.Length > 50) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BillingAddress.Company"], "The max length of this field is 50.");
                }
                if (!record.BillingAddress.Company.All(Char.IsLetterOrDigit)) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BillingAddress.Company"], "This field cannot contain symbols.");
                }
            }

            if (!string.IsNullOrWhiteSpace(record.BillingAddress.Street) && (record.BillingAddress.Street.Length > 60 || !record.BillingAddress.Street.All(Char.IsLetterOrDigit))) {
                if (record.BillingAddress.Street.Length > 60) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BillingAddress.Street"], "The max length of this field is 60.");
                }
                if (!record.BillingAddress.Street.All(Char.IsLetterOrDigit)) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BillingAddress.Street"], "This field cannot contain symbols.");
                }
            }

            if (!string.IsNullOrWhiteSpace(record.BillingAddress.City) && (record.BillingAddress.City.Length > 40 || !record.BillingAddress.City.All(Char.IsLetterOrDigit))) {
                if (record.BillingAddress.City.Length > 40) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BillingAddress.City"], "The max length of this field is 40.");
                }
                if (!record.BillingAddress.City.All(Char.IsLetterOrDigit)) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BillingAddress.City"], "This field cannot contain symbols.");
                }
            }

            if (!string.IsNullOrWhiteSpace(record.BillingAddress.State) && (record.BillingAddress.State.Length > 40 || !record.BillingAddress.State.All(Char.IsLetterOrDigit))) {
                if (record.BillingAddress.State.Length > 40) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BillingAddress.State"], "The max length of this field is 40.");
                }
                if (!record.BillingAddress.State.All(Char.IsLetterOrDigit)) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BillingAddress.State"], "This field cannot contain symbols.");
                }
            }

            if (!string.IsNullOrWhiteSpace(record.BillingAddress.Zip) && (record.BillingAddress.Zip.Length > 20 || !record.BillingAddress.Zip.All(Char.IsLetterOrDigit))) {
                if (record.BillingAddress.Zip.Length > 20) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BillingAddress.Zip"], "The max length of this field is 20.");
                }
                if (!record.BillingAddress.Zip.All(Char.IsLetterOrDigit)) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BillingAddress.Zip"], "This field cannot contain symbols.");
                }
            }

            if (!string.IsNullOrWhiteSpace(record.BillingAddress.Country) && (record.BillingAddress.Country.Length > 60 || !record.BillingAddress.Country.All(Char.IsLetterOrDigit))) {
                if (record.BillingAddress.Country.Length > 60) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BillingAddress.Country"], "The max length of this field is 60.");
                }
                if (!record.BillingAddress.Country.All(Char.IsLetterOrDigit)) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BillingAddress.Country"], "This field cannot contain symbols.");
                }
            }

            if (!string.IsNullOrWhiteSpace(record.BillingAddress.Phone) && (record.BillingAddress.Phone.Length > 60 || !record.BillingAddress.Phone.All(Char.IsDigit))) {
                if (record.BillingAddress.Phone.Length > 60) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BillingAddress.Phone"], "The max length of this field is 25.");
                }
                if (!record.BillingAddress.Phone.All(Char.IsDigit)) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BillingAddress.Phone"], "This field cannot contain symbols.");
                }
            }

            if (!string.IsNullOrWhiteSpace(record.CardNumber) && (record.CardNumber.Length > 16 || (record.CardNumber.Length < 16 && validCheck.IsNumeric(record.CardNumber)) || (record.CardNumber.Length > 8 && !record.CardNumber.All(Char.IsDigit)))) {
                if (record.CardNumber.Length > 16) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["CardNumber"], "The max length of this field is 16.");
                }
                if (record.CardNumber.Length < 16) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["CardNumber"], "The length of this field is 16, please add remaining numbers.");
                }
                if (!record.CardNumber.All(Char.IsDigit)) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["CardNumber"], "The Card Number cannot contain letters.");
                }
            }

            if (record.CardExpiration.Length > 4) {
                if (!string.IsNullOrWhiteSpace(record.CardExpiration) && (!DateTime.TryParseExact(record.CardExpiration, "yyyy-MM", CultureInfo.InvariantCulture, DateTimeStyles.None, out Test) || record.CardExpiration.Length > 7)) {
                    if (record.CardExpiration.Length > 7) {
                        e.Valid = false;
                        view.SetColumnError(view.Columns["CardExpiration"], "The max length of this field is 7.");
                    }

                    if (!DateTime.TryParseExact(record.CardExpiration, "yyyy-MM", CultureInfo.InvariantCulture, DateTimeStyles.None, out Test)) {
                        e.Valid = false;
                        view.SetColumnError(view.Columns["CardExpiration"], "Please enter the date in the YYYY-MM format.");
                    }
                }
            }


        }

        private void gridViewBankProfiles_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void gridViewBankProfiles_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            AuthorizeNet.PaymentProfile record = (AuthorizeNet.PaymentProfile)e.Row;
            view.ClearColumnErrors();
            if (string.IsNullOrWhiteSpace(record.BankAccountNumber) || string.IsNullOrWhiteSpace(record.BankNameOnAccount) || string.IsNullOrWhiteSpace(record.BankRoutingNumber)) {
                if (string.IsNullOrWhiteSpace(record.BankAccountNumber)) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BankAccountNumber"], "Please enter the acount number.");
                }

                if (string.IsNullOrWhiteSpace(record.BankNameOnAccount)) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BankNameOnAccount"], "Please enter the name on the account.");
                }
                if (string.IsNullOrWhiteSpace(record.BankRoutingNumber)) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BankRoutingNumber"], "Please enter the routing number.");
                }

            }

            if (!string.IsNullOrWhiteSpace(record.BankAccountNumber) && record.BankAccountNumber.Length > 17) {
                if (record.BankAccountNumber.Length > 17) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BankAccountNumber"], "The max length of this field is 17.");
                }
            }

            if (record.BankRoutingNumber.Length != 9) {
                e.Valid = false;
                view.SetColumnError(view.Columns["BankRoutingNumber"], "The routing number should be nine digits long.");
            }

            if (!string.IsNullOrWhiteSpace(record.BankNameOnAccount) && (record.BankNameOnAccount.Length > 22 || !record.BankNameOnAccount.All(Char.IsLetterOrDigit))) {
                if (record.BankNameOnAccount.Length > 22) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BankNameOnAccount"], "The max length of this field is 22.");
                }
                if (!record.BankNameOnAccount.All(Char.IsLetterOrDigit)) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BankNameOnAccount"], "This field cannot contain symbols.");
                }
            }

            if (!string.IsNullOrWhiteSpace(record.BankName) && (record.BankName.Length > 50 || !record.BankName.All(Char.IsLetterOrDigit))) {
                if (record.BankName.Length > 50) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BankName"], "The max length of this field is 50.");
                }
                if (!record.BankName.All(Char.IsLetterOrDigit)) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BankName"], "This field cannot contain symbols or spaces.");
                }
            }

            if (!string.IsNullOrWhiteSpace(record.BillingAddress.Company) && (record.BillingAddress.Company.Length > 50 || !record.BillingAddress.Company.All(Char.IsLetterOrDigit))) {
                if (record.BillingAddress.Company.Length > 50) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BillingAddress.Company"], "The max length of this field is 50.");
                }
                if (!record.BillingAddress.Company.All(Char.IsLetterOrDigit)) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BillingAddress.Company"], "This field cannot contain symbols.");
                }
            }
            if (!string.IsNullOrWhiteSpace(record.BillingAddress.Street) && (record.BillingAddress.Street.Length > 60 || !record.BillingAddress.Street.All(Char.IsLetterOrDigit))) {
                if (record.BillingAddress.Street.Length > 60) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BillingAddress.Street"], "The max length of this field is 60.");
                }
                if (!record.BillingAddress.Street.All(Char.IsLetterOrDigit)) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BillingAddress.Street"], "This field cannot contain symbols.");
                }
            }

            if (!string.IsNullOrWhiteSpace(record.BillingAddress.City) && (record.BillingAddress.City.Length > 40 || !record.BillingAddress.City.All(Char.IsLetterOrDigit))) {
                if (record.BillingAddress.City.Length > 40) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BillingAddress.City"], "The max length of this field is 40.");
                }
                if (!record.BillingAddress.City.All(Char.IsLetterOrDigit)) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BillingAddress.City"], "This field cannot contain symbols.");
                }
            }

            if (!string.IsNullOrWhiteSpace(record.BillingAddress.State) && (record.BillingAddress.State.Length > 40 || !record.BillingAddress.State.All(Char.IsLetterOrDigit))) {
                if (record.BillingAddress.State.Length > 40) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BillingAddress.State"], "The max length of this field is 40.");
                }
                if (!record.BillingAddress.State.All(Char.IsLetterOrDigit)) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BillingAddress.State"], "This field cannot contain symbols.");
                }
            }

            if (!string.IsNullOrWhiteSpace(record.BillingAddress.Zip)) {
                if (record.BillingAddress.Zip.Length > 20) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BillingAddress.Zip"], "The max length of this field is 20.");
                }
                if (!record.BillingAddress.Zip.All(Char.IsLetterOrDigit)) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BillingAddress.Zip"], "This field cannot contain symbols.");
                }
            }

            if (!string.IsNullOrWhiteSpace(record.BillingAddress.Country) && (record.BillingAddress.Country.Length > 60 || !record.BillingAddress.Country.All(Char.IsLetterOrDigit))) {
                if (record.BillingAddress.Country.Length > 60) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BillingAddress.Country"], "The max length of this field is 60.");
                }
                if (!record.BillingAddress.Country.All(Char.IsLetterOrDigit)) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BillingAddress.Country"], "This field cannot contain symbols.");
                }
            }

            if (!string.IsNullOrWhiteSpace(record.BillingAddress.Phone) && (record.BillingAddress.Phone.Length > 60 || !record.BillingAddress.Phone.All(Char.IsDigit))) {
                if (record.BillingAddress.Phone.Length > 60) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BillingAddress.Phone"], "The max length of this field is 25.");
                }
                if (!record.BillingAddress.Phone.All(Char.IsDigit)) {
                    e.Valid = false;
                    view.SetColumnError(view.Columns["BillingAddress.Phone"], "This field cannot contain symbols.");
                }
            }




        }



        private void TextEditCreditLimit_Leave(object sender, EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                    validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkCredLim, AgyBindingSource);

                }
            }
        }



        private void TextEditCreditLimitRemPct_Leave(object sender, EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                    //validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkNo, AgyBindingSource);
                    //TextEditNo.Text = TextEditNo.Text.ToUpper();
                }
            }
        }

        private void CheckEditActiveFlg_Click_1(object sender, EventArgs e)
        {
            modified = true;
        }

        private void TextEditPaymentProcessorCustProfileEmail_Leave(object sender, EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                    //validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkNo, AgyBindingSource);
                    //TextEditNo.Text = TextEditNo.Text.ToUpper();
                }
            }
        }

        private void ImageComboBoxEditDefaultProfileID_Leave(object sender, EventArgs e)
        {
            if (AgyBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                    //validCheck.check(sender, errorProvider1, ((AGY)AgyBindingSource.Current).checkNo, AgyBindingSource);
                    //TextEditNo.Text = TextEditNo.Text.ToUpper();
                }
            }
        }

        private void AgyBindingSource_PositionChanged(object sender, EventArgs e)
        {


        }
        private const string cardRegex = "^(?:(?<Visa>4\\d{3})|(?<JCB>2131|1800|3088|35\\d{3}\\d{11})|(?<MasterCard>5[1-5]\\d{2})|(?<Discover>6011)|(?<DinersClub>(?:3[68]\\d{2})|(?:30[0-5]\\d))|(?<Amex>3[47]\\d{2}))([ -]?)(?(DinersClub)(?:\\d{6}\\1\\d{4})|(?(Amex)(?:\\d{6}\\1\\d{5})|(?:\\d{4}\\1\\d{4}\\1\\d{4})))$";

        public static CreditCardTypeType? GetCardTypeFromNumber(string cardNum)
        {
            //Create new instance of Regex comparer with our
            //credit card regex patter
            Regex cardTest = new Regex(cardRegex);

            //Compare the supplied card number with the regex
            //pattern and get reference regex named groups
            GroupCollection gc = cardTest.Match(cardNum).Groups;

            //Compare each card type to the named groups to 
            //determine which card type the number matches
            if (gc[CreditCardTypeType.Amex.ToString()].Success) {
                return CreditCardTypeType.Amex;
            }
            else if (gc[CreditCardTypeType.MasterCard.ToString()].Success) {
                return CreditCardTypeType.MasterCard;
            }
            else if (gc[CreditCardTypeType.Visa.ToString()].Success) {
                return CreditCardTypeType.Visa;
            }
            else if (gc[CreditCardTypeType.JCB.ToString()].Success) {
                return CreditCardTypeType.JCB;
            }
            else if (gc[CreditCardTypeType.DinersClub.ToString()].Success) {
                return CreditCardTypeType.DinersClub;
            }
            else if (gc[CreditCardTypeType.Discover.ToString()].Success) {
                return CreditCardTypeType.Discover;
            }
            else {
                //Card type is not supported by our system, return null
                //(You can modify this code to support more (or less)
                // card types as it pertains to your application)
                return CreditCardTypeType.TestCard;
            }
        }

        public enum CreditCardTypeType
        {
            Visa,
            DinersClub,
            MasterCard,
            Discover,
            Amex,
            Switch,
            Solo,
            JCB,
            TestCard
        }

        private void creditUnlimitedCheckEdit_Click(object sender, EventArgs e)
        {
            modified = true;
            if (creditUnlimitedCheckEdit.Checked) {
                TextEditCreditLimit.Enabled = true;
                TextEditCreditLimitRemPct.Enabled = true;
            }
            else {
                TextEditCreditLimit.Enabled = false;
                TextEditCreditLimitRemPct.Enabled = false;
            }


        }

        private void AgencyForm_Load(object sender, EventArgs e)
        {

        }

        private void CheckEditRequireCVV2_Click(object sender, EventArgs e)
        {
            modified = true;
            if (CheckEditRequireCVV2.Checked) {
                grdColCVV2.Visible = false;
            }
            else {
                grdColCVV2.Visible = true;
            }
        }

        private void CheckEditHtlVouchers_Click(object sender, EventArgs e)
        {
            modified = true;
            if (!CheckEditHtlVouchers.Checked && !TextEditVouchTypes.Text.Contains("HTL")) {
                TextEditVouchTypes.Text = TextEditVouchTypes.Text.Trim();
                TextEditVouchTypes.Text += "HTL,";
            }

            if (CheckEditHtlVouchers.Checked && TextEditVouchTypes.Text.Contains("HTL")) {
                int loc = TextEditVouchTypes.Text.IndexOf("HTL,");
                TextEditVouchTypes.Text = TextEditVouchTypes.Text.Remove(loc, 4);
            }
        }

        private void CheckEditCarVouchers_Click(object sender, EventArgs e)
        {
            modified = true;
            if (!CheckEditCarVouchers.Checked && !TextEditVouchTypes.Text.Contains("CAR")) {
                TextEditVouchTypes.Text += "CAR,";
                TextEditVouchTypes.Text = TextEditVouchTypes.Text.Trim();
            }

            if (CheckEditCarVouchers.Checked && TextEditVouchTypes.Text.Contains("CAR")) {
                int loc = TextEditVouchTypes.Text.IndexOf("CAR,");
                TextEditVouchTypes.Text = TextEditVouchTypes.Text.Remove(loc, 4);
            }
        }

        private void CheckEditCruVouchers_Click(object sender, EventArgs e)
        {
            modified = true;
            if (!CheckEditCruVouchers.Checked && !TextEditVouchTypes.Text.Contains("CRU")) {
                TextEditVouchTypes.Text += "CRU,";
                TextEditVouchTypes.Text = TextEditVouchTypes.Text.Trim();
            }

            if (CheckEditCruVouchers.Checked && TextEditVouchTypes.Text.Contains("CRU")) {
                int loc = TextEditVouchTypes.Text.IndexOf("CRU,");
                TextEditVouchTypes.Text = TextEditVouchTypes.Text.Remove(loc, 4);
            }
        }

        private void CheckEditAirVouchers_Click(object sender, EventArgs e)
        {
            modified = true;
            if (!CheckEditAirVouchers.Checked && !TextEditVouchTypes.Text.Contains("AIR")) {
                TextEditVouchTypes.Text += "AIR,";
                TextEditVouchTypes.Text = TextEditVouchTypes.Text.Trim();
            }

            if (CheckEditAirVouchers.Checked && TextEditVouchTypes.Text.Contains("AIR")) {
                int loc = TextEditVouchTypes.Text.IndexOf("AIR,");
                TextEditVouchTypes.Text = TextEditVouchTypes.Text.Remove(loc, 4);
            }
        }

        private void CheckEditOptVouchers_Click(object sender, EventArgs e)
        {
            modified = true;
            if (!CheckEditOptVouchers.Checked && !TextEditVouchTypes.Text.Contains("OPT")) {
                TextEditVouchTypes.Text += "OPT,";
                TextEditVouchTypes.Text = TextEditVouchTypes.Text.Trim();
            }

            if (CheckEditOptVouchers.Checked && TextEditVouchTypes.Text.Contains("OPT")) {
                int loc = TextEditVouchTypes.Text.IndexOf("OPT,");
                TextEditVouchTypes.Text = TextEditVouchTypes.Text.Remove(loc, 4);
            }
        }

        private void CheckEditPkgVouchers_Click_1(object sender, EventArgs e)
        {
            modified = true;
            if (!CheckEditPkgVouchers.Checked && !TextEditVouchTypes.Text.Contains("PKG")) {
                TextEditVouchTypes.Text += "PKG,";
                TextEditVouchTypes.Text = TextEditVouchTypes.Text.Trim();
            }

            if (CheckEditPkgVouchers.Checked && TextEditVouchTypes.Text.Contains("PKG")) {
                int loc = TextEditVouchTypes.Text.IndexOf("PKG,");
                TextEditVouchTypes.Text = TextEditVouchTypes.Text.Remove(loc, 4);
            }
        }

        private void CheckEditSglResConf_Click(object sender, EventArgs e)
        {
            modified = true;
            if (!CheckEditSglResConf.Checked && !TextEditVouchTypes.Text.Contains("SGL")) {
                TextEditVouchTypes.Text += "SGL,";
                TextEditVouchTypes.Text = TextEditVouchTypes.Text.Trim();
            }

            if (CheckEditSglResConf.Checked && TextEditVouchTypes.Text.Contains("SGL")) {
                int loc = TextEditVouchTypes.Text.IndexOf("SGL,");
                TextEditVouchTypes.Text = TextEditVouchTypes.Text.Remove(loc, 4);
            }
        }

        private void textEditAgentCompany_Leave(object sender, EventArgs e)
        {
            if (AgcyLogBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    agyLogModified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
            }

        }

        private void lookUpEditAgentDelegate_Leave(object sender, EventArgs e)
        {
            if (AgcyLogBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    agyLogModified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
            }
        }

        private void imageComboBoxEditAgentDelegate_Leave(object sender, EventArgs e)
        {
            if (AgcyLogBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    agyLogModified = true;
                    labelControl25.Text = DateTime.Today.ToShortDateString();
                    labelControl27.Text = username;
                }
            }
        }

        private void AgcyLogBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (AgcyLogBindingSource.Current != null && AgyBindingSource.Current != null) {
                AGY rec = (AGY)AgyBindingSource.Current;
                if (rec.NO == defAgy) {
                    ImageComboBoxItem load;
                    ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = string.Empty };
                    imageComboBoxEditAgentDelegate.Properties.Items.Clear();
                    imageComboBoxEditAgentDelegate.Properties.Items.Add(loadBlank);

                    var agent = (AGCYLOG)AgcyLogBindingSource.Current;
                    var agents = (from agentRec in rec.AGCYLOG
                                 where agentRec.AGT_NAME != agent.AGT_NAME && agentRec.AgentCompany == agent.AgentCompany
                                 orderby agentRec.AGT_NAME
                                 select new { Description = agentRec.AGT_NAME, Value = agentRec.AGT_NAME }).ToList();
                    foreach (var agtRec in agents) {
                        load = new ImageComboBoxItem(agtRec.Description, agtRec.Value);
                        imageComboBoxEditAgentDelegate.Properties.Items.Add(load);
                    }
                }
            }
        }

        private void gridViewAgencyCurrency_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "Currency_Code") {
                if (e.RowHandle == fixedDefaultCurrencyIndex)
                    gridViewAgencyCurrency.FocusedRowHandle = -1;   // don't allow user to focus and therefore edit the fixed default currency
                else
                    e.RepositoryItem = agyCurrencyCodeRepository;
            }    
        }

        private void buttonAddAgencyCurrency_Click(object sender, EventArgs e)
        {
            gridViewAgencyCurrency.ClearColumnsFilter();
            gridViewAgencyCurrency.ClearSorting();   // otherwise could focus wrong column below
            newAgyCurrencyRec = true;
            AgencyCurrencyBindingSource.AddNew();
            var currentIndex = AgencyCurrencyBindingSource.Count - 1;
            if (!newAgyCurrencyIndices.Contains(currentIndex)) // don't add twice
                newAgyCurrencyIndices.Add(currentIndex);
            gridViewAgencyCurrency.FocusedRowHandle = gridViewAgencyCurrency.RowCount - 1;
            setReadOnly(false);
        }

        // BAW
        private void SetAgyCurrencyBindings()
        {
            //if (CurrToExRateBindingSource.Current == null) {
            //    _selectedExchangeRateRecord = null;
            //    enableNavigator(false);
            //    //setReadOnly(true);
            //}
            //else {
            var selectedRecord = (AgencyCurrency)AgencyCurrencyBindingSource.Current;
            // only do this to newly created agency currency records
            if (newAgyCurrencyRec && string.IsNullOrEmpty(selectedRecord.Currency_Code)) {
                selectedRecord.Agy_No = ((AGY)AgyBindingSource.Current).NO;
                selectedRecord.Default = false;  // should be false
            }
            //enableNavigator(true);
            //setReadOnly(false);
        }

        // BAW
        // Ensure that values in editors are saved and validated.
        private void FinalizeAgyCurrBindings()
        {
            gridViewAgencyCurrency.CloseEditor();
            gridViewAgencyCurrency.UpdateCurrentRow();
            AgencyCurrencyBindingSource.EndEdit();
        }

        // BAW
        // Reload modified records from the database - such as when saving records fails
        private void RefreshRecords()
        {
            try {
                modifiedAgyCurrencyIndices.ForEach(i =>
                {
                    if (((AgencyCurrency)AgencyCurrencyBindingSource[i]).ID != 0)
                        context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, AgencyCurrencyBindingSource[i]);
                    else {
                        context.DeleteObject(AgencyCurrencyBindingSource[i]);
                        AgencyCurrencyBindingSource.RemoveAt(i);
                    }
                });
            }
            catch { }
        }

        private bool ValidateCurrencies()
        {
            try {
                var currentAgency = (AGY)AgyBindingSource.Current;
                if (currentAgency == null)
                    return true;

                FinalizeAgyCurrBindings();

                if (newAgyCurrencyRec || modifiedAgyCurrencyRec) {
                    List<AgencyCurrency> relevantAgencyCurrencies = new List<AgencyCurrency>();
                    modifiedAgyCurrencyIndices.ForEach(i => {
                        relevantAgencyCurrencies.Add((AgencyCurrency)AgencyCurrencyBindingSource[i]);
                    });

                    newAgyCurrencyIndices.ForEach(i => {
                        relevantAgencyCurrencies.Add((AgencyCurrency)AgencyCurrencyBindingSource[i]);
                    });

                    // validate currency entry - will throw on failure
                    currentAgency.checkCurrency(relevantAgencyCurrencies, context);
                }
                return true;
            }
            catch (Exception ex) {
                string message = ex.Message;
                if (message.Contains("inner exception")) {
                    message = ex.InnerException.Message;
                }
                XtraMessageBox.Show(message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        // BAW
        private bool SaveAgencyCurrency()
        {
            try {
                var currentAgency = (AGY)AgyBindingSource.Current;
                if (currentAgency == null)
                    return true;

                if (newAgyCurrencyRec || modifiedAgyCurrencyRec) {
                    newAgyCurrencyIndices.ForEach(i =>
                    {
                        context.AgencyCurrency.AddObject((AgencyCurrency)AgencyCurrencyBindingSource[i]);
                    });

                    context.SaveChanges();
                    newAgyCurrencyRec = false;
                    modifiedAgyCurrencyRec = false;
                    newAgyCurrencyIndices.Clear(); // used to keep track of unsaved, new exchange rates
                    modifiedAgyCurrencyIndices.Clear(); // used to keep track of unsaved, modified exchange rates
                    SetAgyCurrencyBindings(); // need to reload currency data from DB - RefreshRecord will not do that for modifications
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
                modifiedAgyCurrencyIndices.Clear();
                modifiedAgyCurrencyRec = false;
                SetNewDefaultCurrency(null, true);   // in case new currency was set to default and now RefreshRecords() has also set previous default currency back to default
                return false;
            }
        }

        private void AgencyCurrencyBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            SetAgyCurrencyBindings();
        }

        private void gridViewAgencyCurrency_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            if (e.RowHandle == fixedDefaultCurrencyIndex && e.Column.FieldName == "Currency_Code")
                gridViewAgencyCurrency.FocusedRowHandle = -1;   // do not allow user to focus on and thereby edit the fixed default currency.
            else {
                // add index of row to modifed currencies list
                var selectedRecord = (AgencyCurrency)AgencyCurrencyBindingSource.Current;
                if (selectedRecord.ID != 0) {
                    modifiedAgyCurrencyRec = true;
                    var currentIndex = AgencyCurrencyBindingSource.IndexOf(selectedRecord);
                    if (!modifiedAgyCurrencyIndices.Contains(currentIndex))
                        modifiedAgyCurrencyIndices.Add(currentIndex);
                }
                // toggle default currency - this logic ensures that the user has to select exactly one default currency
                if (e.Column.Name == "colDefault" && e.Value.Equals(true))
                    SetNewDefaultCurrency(e.RowHandle);
                else if (e.Column.Name == "colDefault" && e.Value.Equals(false))
                    SetNewDefaultCurrency();
            }    
        }

        private void buttonDeleteAgencyCurrency_Click(object sender, EventArgs e)
        {
            if (gridViewAgencyCurrency.FocusedRowHandle >= 0) {
                AgencyCurrency currencyToDelete = (AgencyCurrency)gridViewAgencyCurrency.GetFocusedRow();

                // do not remove default currency
                if (currencyToDelete.Currency_Code != fixedDefaultCurrency) {
                    if (gridViewAgencyCurrency.FocusedRowHandle == actualDefaultCurrencyIndex)
                        SetNewDefaultCurrency();

                    AdjustCurrencyIndicesForDeletion(gridViewAgencyCurrency.FocusedRowHandle);
                    AgencyCurrencyBindingSource.Remove(currencyToDelete);
                    //Removing from the bindingsource just removes the object from its parent, but does not mark
                    //it for deletion, effectively orphaning it.  This will cause foreign key errors when saving.
                    //To flag for deletion, delete it from the context as well.
                    if (currencyToDelete.ID != 0)
                        context.AgencyCurrency.DeleteObject(currencyToDelete);

                    modifiedAgyCurrencyRec = true;
                }
            }
        }

        // BAW
        // Ensures that the user has to select exactly one default currency
        private void SetNewDefaultCurrency(int? newIndex = null, bool clearNew = false)
        {
            // when SaveRecord fails, need to prevent new record from being default together with the record that is default in DB, restored by RefreshRecords()
            if (clearNew) {
                newAgyCurrencyIndices.ForEach(i =>
                {
                    ((AgencyCurrency)AgencyCurrencyBindingSource[i]).Default = false;
                });
                // used to ensure that at least one record is automatically set to default
                var actualDefaultCurrencyRecord = AgencyCurrencyBindingSource.List.Cast<AgencyCurrency>().Where(a => a.Default == true).FirstOrDefault();
                actualDefaultCurrencyIndex = AgencyCurrencyBindingSource.IndexOf(actualDefaultCurrencyRecord);

                var fixedDefaultCurrencyRecord = AgencyCurrencyBindingSource.List.Cast<AgencyCurrency>().Where(f => f.Currency_Code == fixedDefaultCurrency).FirstOrDefault();
                fixedDefaultCurrencyIndex = AgencyCurrencyBindingSource.IndexOf(fixedDefaultCurrencyRecord);

                if (actualDefaultCurrencyIndex == -1) { // if the actual default record was deleted, reinstate fixed default
                    fixedDefaultCurrencyRecord.Default = true;
                    modifiedAgyCurrencyRec = true;
                    modifiedAgyCurrencyIndices.Add(fixedDefaultCurrencyIndex);
                    actualDefaultCurrencyIndex = fixedDefaultCurrencyIndex;
                }
            }
            // when deleting/modifying existing currency to no longer be default
            else if (newIndex == null) {
                var fixedDefaultCurrencyRecord = (AgencyCurrency)AgencyCurrencyBindingSource.List[fixedDefaultCurrencyIndex];
                if (fixedDefaultCurrencyRecord.Default != true) {   // only if value has changed
                    fixedDefaultCurrencyRecord.Default = true;
                    modifiedAgyCurrencyRec = true;
                    if (!modifiedAgyCurrencyIndices.Contains(fixedDefaultCurrencyIndex))
                        modifiedAgyCurrencyIndices.Add(fixedDefaultCurrencyIndex);
                    actualDefaultCurrencyIndex = fixedDefaultCurrencyIndex;
                }
            }
            // when setting new default explicitly - creating/modifying currency to be new default or when recovering from save error
            else {
                var actualDefaultCurrencyRecord = (AgencyCurrency)AgencyCurrencyBindingSource.List[actualDefaultCurrencyIndex];
                actualDefaultCurrencyRecord.Default = false;
                modifiedAgyCurrencyRec = true;
                if (!modifiedAgyCurrencyIndices.Contains(actualDefaultCurrencyIndex) && !newAgyCurrencyIndices.Contains(actualDefaultCurrencyIndex))
                    modifiedAgyCurrencyIndices.Add(actualDefaultCurrencyIndex);
                actualDefaultCurrencyIndex = (int)newIndex;
            }
        }

        // BAW
        // When a new/modified currency is deleted, this method adjusts the lists that keep track of new/modified values
        private void AdjustCurrencyIndicesForDeletion(int rowHandle)
        {
            List<int> tmpModifiedRateIndices = new List<int>();
            List<int> tmpNewRateIndices = new List<int>();

            modifiedAgyCurrencyIndices.ForEach(i =>
            {
                if (i < rowHandle)
                    tmpModifiedRateIndices.Add(i);
                else if (i > rowHandle)
                    tmpModifiedRateIndices.Add(i - 1);
            });

            newAgyCurrencyIndices.ForEach(i =>
            {
                if (i < rowHandle)
                    tmpNewRateIndices.Add(i);
                else if (i > rowHandle)
                    tmpNewRateIndices.Add(i - 1);
            });

            modifiedAgyCurrencyIndices.Clear();
            newAgyCurrencyIndices.Clear();
            modifiedAgyCurrencyIndices.AddRange(tmpModifiedRateIndices);
            newAgyCurrencyIndices.AddRange(tmpNewRateIndices);
        }

        private void gridViewAgencyCurrency_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void checkEditAllowElectronicPayment_Click(object sender, EventArgs e)
        {
            modified = true;
        }

        private void checkEditAgentInactive_Click(object sender, EventArgs e)
        {
            modified = true;
        }
    }

    public static class StringExtension
    {
        public static string GetLast(this string source, int tail_length)
        {
            if (tail_length >= source.Length)
                return source;
            return source.Substring(source.Length - tail_length);
        }
    }

    public class AuthorizePaymentProfile
    {
        public string ID { get; set; }
        public string CardNo { get; set; }
        public DateTime ExpDate { get; set; }
        public string CVV2 { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
        public string Company { get; set; }
        public string Fax { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Phone { get; set; }

        public AuthorizePaymentProfile()
        {

        }
    }

}