using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Dynamic;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
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
using DevExpress.Data.Async.Helpers;
using FlexInterfaces.Core;

namespace TraceForms
{
    public partial class AgencyForm : DevExpress.XtraEditors.XtraForm
    {
        public List<IComprod2> myCommRecs;
        public List<IComprod2> myCommRecsAgy;
        public List<ICommLevel> myCommLvl;
        ICoreSys _sys;
        public string imagesRoot;
        const string col = "colNO";
        public bool firstLoad = false;
        public string globalRptType = string.Empty;
        public string username;
        public string _defAgy = string.Empty;
        public string apiLogin;
        public string transactionKey;
        public AuthorizeNet.CustomerGateway _custGateway;
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
        bool _detailsModified = false;
        bool _contactsModified = false;

        FlextourEntities _context;
        AGY _selectedRecord;
        Timer _actionConfirmation;
        bool _ignoreLeaveRow = false, _ignorePositionChange = false;

        public AgencyForm(ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
            LoadLookups();
            creditCards = new List<AuthorizeNet.PaymentProfile>();
            bankAccnts = new List<AuthorizeNet.PaymentProfile>();
            authorizeCurrentRow = new List<int>();
            authorizeCurrentBankRow = new List<int>();
            _sys = sys;
            CheckEditAllowAttachments.Checked = true;
        }

        void SetReadOnly(bool value)
        {
            foreach (Control control in SplitContainerControl.Panel2.Controls) {
                control.Enabled = !value;
            }
        }

        void SetReadOnlyKeyFields(bool value)
        {
            TextEditCode.ReadOnly = value;
        }

        private void ShowActionConfirmation(string confirmation)
        {
            PanelControlStatus.Visible = true;
            LabelStatus.Text = confirmation;
            _actionConfirmation = new Timer {
                Interval = 3000
            };
            _actionConfirmation.Start();
            _actionConfirmation.Tick += TimedEvent;
        }

        private void TimedEvent(object sender, EventArgs e)
        {
            PanelControlStatus.Visible = false;
            _actionConfirmation.Stop();
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            AGY.MaxLengths = Connection.GetMaxLengths(typeof(AGY).GetType().Name);
            AGCYLOG.MaxLengths = Connection.GetMaxLengths(typeof(AGCYLOG).GetType().Name);
            _context = new FlextourEntities(sys.Settings.EFConnectionString);
            _sys = sys;
            //FlexBObj.FileWatcher watcher = new FlexBObj.FileWatcher(sys.Settings.DataPath, sys.Settings.EFConnectionString);
            username = sys.User.Name;
            imagesRoot = sys.Settings.ImagesRoot;
            _defAgy = sys.Settings.DefaultAgency;
            _accountingURL = sys.Settings.TourAccountingURL;

            var defCredit = _context.AGY.First(a => a.NO == _defAgy).CreditLimitRemainingWarningPct;
            defaultCreditPct = (defCredit == null ? 0 : (float)defCredit);
            allowElecPayments = sys.Settings.AllowElectronicPayments;
            reqAgyInfoOnFile = sys.Settings.RequireAgyPaymentInfoOnFile;
            paymentTestMode = sys.Settings.PaymentProcessorTestMode;
            if (allowElecPayments) {
                if (string.IsNullOrWhiteSpace(sys.Settings.PaymentProcessorLoginId) || string.IsNullOrWhiteSpace(sys.Settings.PaymentProcessorTxKey)) {
                    MessageBox.Show("You are not currently setup to enter payment info please enter your credentials in the Company File form.");
                    XtraTabPagePayments.PageVisible = false;
                    return;

                }
                XtraTabPagePayments.PageVisible = true;
                if (!string.IsNullOrWhiteSpace(sys.Settings.PaymentProcessorLoginId) && !string.IsNullOrWhiteSpace(sys.Settings.PaymentProcessorTxKey)) {
                    apiLogin = sys.Settings.PaymentProcessorLoginId;
                    transactionKey = sys.Settings.PaymentProcessorTxKey;
                    try {
                        _custGateway = new AuthorizeNet.CustomerGateway(apiLogin, transactionKey, paymentTestMode);
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }
                }

                //conn = new AuthorizeNet.CustomerGateway("", "", AuthorizeNet.ServiceMode.Test);
                grdColExpDate.Caption = "Exp. Date \n(YYYY-MM)";
            }
            else
                XtraTabPagePayments.PageVisible = false;

            var agentLoad = from c in _context.AGCYLOG
                            where c.AGENCY == "KJM"
                            select c;
            BindingSourceAgcyLog.DataSource = agentLoad;
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

        private void LoadLookups()
        {
            //loadDirectory();
            myCommRecsAgy = (from rec in _context.COMPROD2
                             where (rec.TYPE == "AGY") && (rec.Inactive == false) && ((rec.START_DATE <= DateTime.Now) && (rec.END_DATE >= DateTime.Now))
                             select rec).ToList<IComprod2>();
            myCommLvl = (from rec in _context.CommLevel select rec).ToList<ICommLevel>();

            foreach (COMPROD2 rec in myCommRecsAgy) {
                rec.SetProductRulePosition(myCommLvl);
            }
            GridColumn columnHotelInfo3 = GridViewCustom.Columns.AddField("AgencyValue");
            columnHotelInfo3.VisibleIndex = 1;
            columnHotelInfo3.UnboundType = DevExpress.Data.UnboundColumnType.String;
            columnHotelInfo3.Visible = true;
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = string.Empty };
            RepositoryItemImageComboBoxEditAgentDelegate.Items.Add(loadBlank);

            var lang = from langRec in _context.LANGUAGE orderby langRec.CODE ascending select new { langRec.CODE, langRec.NAME };
            var country = from countryRec in _context.COUNTRY orderby countryRec.CODE ascending select new { countryRec.CODE, countryRec.NAME };
            var consrt = from consrtRec in _context.CONSRT orderby consrtRec.CODE ascending select new { consrtRec.CODE, consrtRec.NAME };
            var agency = from agencyRec in _context.AGY orderby agencyRec.NO ascending select new { agencyRec.NO, agencyRec.NAME };
            var dept = from deptRec in _context.Dept orderby deptRec.Code ascending select new { deptRec.Code, deptRec.Desc };
            var city = from citRec in _context.CITYCOD orderby citRec.CODE ascending select new { citRec.CODE, citRec.NAME };
            var state = from stateRec in _context.State orderby stateRec.Code ascending select new { stateRec.Code, stateRec.State1 };
            var agcylog = from agcylogRec in _context.AGCYLOG orderby agcylogRec.AGT_NAME ascending select new { agcylogRec.AGT_NAME };

            foreach (var result in dept) {
                repositoryItemComboBoxDept.Items.Add(result.Code + " " + result.Desc);
            }
            SetReadOnly(true);
            //DetailBindingSource.DataSource = from c in context.DETAIL where c.CODE == "KJM9" select c;

            var lookup = new List<CodeName> {
                new CodeName(null)
            };
            lookup.AddRange(_context.LANGUAGE
                            .OrderBy(o => o.CODE)
                            .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }));
            SearchLookupEditDefLanguage.Properties.DataSource = lookup;

            var agencies = new List<CodeName> {
                new CodeName(null)
            };
            agencies.AddRange(_context.AGY
                            .OrderBy(o => o.NO)
                            .Select(s => new CodeName() { Code = s.NO, Name = s.NAME }));
            SearchLookupEditAgency.Properties.DataSource = agencies;
            SearchLookupEditParentAgy.Properties.DataSource = agencies;

            var memberships = new List<CodeName> {
                new CodeName(null)
            };
            memberships.AddRange(_context.LOOKUP.Where(c => c.LINK_TABLE == "DETAIL" && c.LINK_COLUMN == "CODE" && c.RECTYPE == "AGYCLASS")
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.DESC }).ToList());
            RepositoryItemSearchLookUpEditClass.DataSource = memberships;

            var countries = new List<CodeName> {
                new CodeName(null)
            };
            countries.AddRange(_context.COUNTRY
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }));
            SearchLookupEditCountry.Properties.DataSource = countries;

            var reporttypes = new List<CodeName> {
                new CodeName(null)
            };
            reporttypes.AddRange(_context.RPTTYPE
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.DESC }));
            RepositoryItemSearchLookUpEditReportType.DataSource = reporttypes;

            //_supplierCombo.Items.Add(loadBlank);
            //_supplierCombo.Items.AddRange(_context.Supplier
            //                .OrderBy(o => o.Name).AsEnumerable()
            //                .Select(s => new ImageComboBoxItem() { Description = s.Name, Value = s.GUID })
            //                .ToList());
            //GridControlSupplierCity.RepositoryItems.Add(_supplierCombo);        //per DX recommendation to avoid memory leaks

            //lookup = new List<CodeName> {
            //    new CodeName(null)
            //};
            //lookup.AddRange(_context.OPERATOR
            //                .OrderBy(o => o.CODE)
            //                .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }));
            //RepositoryItemCustomSearchLookUpEditOperator.DataSource = lookup;
        }

        private void BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            //If the current record is changing as a result of removing a record to delete it, and it is the last
            //record in the table, then SetBindings will clear the bindings, which will cause the delete
            //to fail because the associated entities will become detached when their BindingSources are cleared.
            //Thus we have a flag which is set in that case to ignore this event.
            if (!_ignorePositionChange)
                SetBindings();
        }

        private void LoadAuthorize(AuthorizeNet.Customer cust)
        {
            bankAccnts.Clear();
            creditCards.Clear();
            ImageComboBoxEditDefaultPmtProfileID.Properties.Items.Clear();
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = string.Empty, Value = string.Empty };
            ImageComboBoxEditDefaultPmtProfileID.Properties.Items.Add(loadBlank);
            foreach (AuthorizeNet.PaymentProfile profile in cust.PaymentProfiles) {
                if (!string.IsNullOrWhiteSpace(profile.BankAccountNumber))
                    bankAccnts.Add(profile);

                if (!string.IsNullOrWhiteSpace(profile.CardNumber))
                    creditCards.Add(profile);
            }
            GridControlCreditProfiles.DataSource = creditCards;
            GridControlBankProfiles.DataSource = bankAccnts;
            ///////////////////////

            var loadDefault = from agyRec in _context.AgencyPaymentProfile where agyRec.Agy_No == TextEditCode.Text select agyRec;
            foreach (var result in loadDefault) {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.PaymentProfileDesc, Value = result.PaymentProfileID };
                ImageComboBoxEditDefaultPmtProfileID.Properties.Items.Add(load);
            }
            //setDefeaultProfile to first added if none is set
            if (string.IsNullOrWhiteSpace(ImageComboBoxEditDefaultPmtProfileID.Text) && currentCust.PaymentProfiles.Count > 0) {
                ImageComboBoxEditDefaultPmtProfileID.EditValue = currentCust.PaymentProfiles[0].ProfileID;
                _context.SaveChanges();
            }
            //  ////////////////
        }


        private void GridView3_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "AgencyValue" && e.IsGetData) {
                string desc = GridViewCustom.GetRowCellValue(e.ListSourceRowIndex, "LINK_COLUMN").ToString();
                desc = desc.Trim();
                e.Value = GridViewLookup.GetRowCellValue(BindingSource.IndexOf(BindingSource.Current), desc);
            }

            if (e.Column.FieldName == "AgencyValue" && e.IsSetData) {
                string desc = GridViewCustom.GetRowCellValue(e.ListSourceRowIndex, "LINK_COLUMN").ToString();
                desc = desc.Trim();
                GridViewLookup.SetRowCellValue(BindingSource.IndexOf(BindingSource.Current), desc, e.Value);
                //modified = true;
            }
        }

        private void AgencyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsModified(_selectedRecord)) {
                DialogResult select = DisplayHelper.QuestionYesNo(this, "There are unsaved changes. Are you sure want to exit?");
                if (select == DialogResult.Yes) {
                    e.Cancel = false;
                    _context.Dispose();
                    Dispose();
                }
                else
                    e.Cancel = true;
            }
            else {
                e.Cancel = false;
                _context.Dispose();
                Dispose();
            }
        }

        private void TextEditCode_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateNo, sender);
        }

        private void TextEditName_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateName, sender);
        }

        private void TextEditType_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateType, sender);
        }

        private void TextEditAP_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateAP, sender);
        }

        private void TextEditAR_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateAR, sender);
        }

        private void SearchLookupEditDefaultLanguage_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateDefLang, sender);
        }

        private void TextEditAddress1_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateAddress1, sender);
        }

        private void TextEditAddress2_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateAddress2, sender);
        }

        private void TextEditAddress3_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateAddress3, sender);
        }

        private void TextEditZip_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateZip, sender);
        }

        private void SearchLookupEditCountry_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCountry, sender);
        }

        private void ImageComboBoxEditMailFaxFlg_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateMailFax, sender);
        }

        private void TextEditPhone_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidatePhone, sender);
        }

        private void TextEditFaxNum_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateFax, sender);
        }

        private void TextEditEmail_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateEmail, sender);
        }

        private void ImageComboBoxEditRetReqHtls_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateRetReq, sender);
        }

        private void ImageComboBoxEditRetNotAvailHtls_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateRetNotAvail, sender);
        }

        private void SpinEditRel_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateRel, sender);
        }

        private void SpinEditArvBkDays_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateArvBkDays, sender);
        }

        private void ImageComboBoxEditTourfaxEmailFormat_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateTourfaxEmailFormat, sender);
        }

        private void SpinEditVoucherReprints_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateVouchReprints, sender);
        }

        private void SpinEditVoucherDaysPrior_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateVouchDaysPrior, sender);
        }

        private void SpinEditOptDays_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateOptDays, sender);
        }

        private void SpinEditCxlGrace_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateGrace, sender);
        }

        private void SpinEditComm_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateComm, sender);
        }

        private void ImageComboBoxEditEditHdrs_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateEditHdr, sender);
        }

        private void ImageComboBoxEditEditHtls_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateEditHtl, sender);
        }

        private void SpinEditDueDays_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateDueDays, sender);
        }

        private void SpinEditPmtDays_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidatePmtDays, sender);
        }

        private void SpinEditPriorDays_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidatePriorDays, sender);
        }

        private void SpinEditDaysSpace_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateDaysSpace, sender);
        }

        private void ComboBoxEditInvFormat_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateInvFormat, sender);
        }

        private void SpinEditCxl1NtsPrior_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCxlNights1, sender);
        }

        private void SpinEditCxl2NtsPrior_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCxlNights2, sender);
        }

        private void SpinEditCxl3NtsPrior_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCxlNights3, sender);
        }

        private void SpinEditChg1NtsPrior_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateChgNights1, sender);
        }

        private void SpinEditChg2NtsPrior_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateChgNights2, sender);
        }

        private void SpinEditChg3NtsPrior_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateChgNights3, sender);
        }

        private void TextEditCxl1Pct_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCxlPct1, sender);
        }

        private void TextEditCxl2Pct_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCxlPct2, sender);
        }

        private void TextEditCxl3Pct_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCxlPct3, sender);
        }

        private void TextEditCxl1Flat_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCxlFlatFee1, sender);
        }

        private void TextEditCxl2Flat_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCxlFlatFee2, sender);
        }

        private void TextEditCxl3Flat_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCxlFlatFee3, sender);
        }

        private void TextEditChg1Pct_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateChgPct1, sender);
        }

        private void TextEditChg2Pct_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateChgPct2, sender);
        }

        private void TextEditChg3Pct_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateChgPct3, sender);
        }

        private void TextEditChg1Flat_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateChgFlatFee1, sender);
        }

        private void TextEditChg2Flat_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateChgFlatFee2, sender);
        }

        private void TextEditChg3Flat_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateChgFlatFee3, sender);
        }

        private void SearchLookupEditParentAgy_Leave(object sender, System.EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateParentAgy, sender);
        }

        private void ButtonEditLogoPath_ButtonPressed(object sender, ButtonPressedEventArgs e)
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

        private void ButtonEditLogoPath_TextChanged(object sender, EventArgs e)
        {
            PictureEditPreview.Image = null;
            try {

                using (var stream = new MemoryStream(File.ReadAllBytes(imagesRoot + ButtonEditLogoPath.Text))) {
                    PictureEditPreview.Height = Image.FromStream(stream).Height;
                    PictureEditPreview.Width = Image.FromStream(stream).Width;
                    PictureEditPreview.Image = Image.FromStream(stream);
                    labelControlSize.Text = Image.FromStream(stream).Height + " * " + Image.FromStream(stream).Width;
                    ErrorProvider.SetError(ButtonEditLogoPath, "");
                }
            }
            catch {
                try {
                    using (var stream = new MemoryStream(File.ReadAllBytes(ButtonEditLogoPath.Text))) {
                        PictureEditPreview.Height = Image.FromStream(stream).Height;
                        PictureEditPreview.Width = Image.FromStream(stream).Width;
                        PictureEditPreview.Image = Image.FromStream(stream);
                        labelControlSize.Text = Image.FromStream(stream).Height + " * " + Image.FromStream(stream).Width;
                        ErrorProvider.SetError(ButtonEditLogoPath, "");
                    }
                }
                catch {
                    return;
                }
            }
        }

        private void ButtonAddRow_Click(object sender, EventArgs e)
        {
            CONTACT contact = new CONTACT() {
                LINK_TABLE = "AGY",
                RECTYPE = "IMAGE",
                LINK_VALUE = TextEditCode.Text
            };
            BindingSourceContact.Add(contact);
        }

        private void ButtonSaveChanges_Click(object sender, EventArgs e)
        {/*
            GridViewContacts.FocusedColumn = GridViewContacts.Columns["LINK_TABLE"];
            if (GridViewContacts.UpdateCurrentRow()) {
                BindingSource.EndEdit();
                aGYBindingNavigatorSaveItem_Click(sender, e);
                newRowRec = false;
                modified = false;
            }*/
        }

        private void DelRow_Click(object sender, EventArgs e)
        {
            int handle = GridViewContacts.FocusedRowHandle;
            GridViewContacts.DeleteRow(handle);
            BindingSource.EndEdit();
            _context.SaveChanges();
        }

        private void GridViewContacts_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "RptContact" && e.IsGetData) {
                CONTACT conRec = (CONTACT)e.Row;
                int id = conRec.ID;
                string load = String.Empty;
                if (id == int.MaxValue || id == 0) {
                    if (firstLoad == true) {
                        var values = from rec in _context.RPTTYPE where rec.RecipientType == "Agy" select new { rec.CODE };
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
                    var val = from rec in _context.RptContact where rec.Contact_ID == id && rec.Code == TextEditCode.Text select new { rec.RptType };
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
                    //modified = true;
                }
                else {
                    string value = e.Value.ToString();
                    var results = from rptRec in _context.RptContact where !value.Contains(rptRec.RptType) && rptRec.Code == TextEditCode.Text && rptRec.Contact_ID == id select rptRec;
                    foreach (var result in results) {
                        _context.RptContact.DeleteObject(result);
                    }
                    var val1 = (from rptRec in _context.RPTTYPE
                                where value.Contains(rptRec.CODE)
                                select new { rptRec.CODE });
                    foreach (var result1 in val1) {
                        if ((from rptCont in _context.RptContact where rptCont.Contact_ID == id && rptCont.Code == TextEditCode.Text && rptCont.RptType == result1.CODE select new { rptCont.Code }).Count() == 0) {
                            RptContact lol = new RptContact() {
                                Code = TextEditCode.Text,
                                RptType = result1.CODE,
                                Contact_ID = id
                            };

                            _context.RptContact.AddObject(lol);
                        }
                    }
                    _context.SaveChanges();
                }
            }
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

        private void ButtonEditDate_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(DateEditDate.Text))
                DateEditDate.Text = validCheck.convertDate(DateEditDate.Text);
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            DateTime? date;
            if (DateEditDate.Text == "") {
                date = null;
            }
            else {
                date = Convert.ToDateTime(DateEditDate.Text);
            }
            string agency;
            string source;
            if (string.IsNullOrWhiteSpace(SearchLookupEditAgency.Text))
                agency = TextEditCode.Text;
            else
                agency = SearchLookupEditAgency.Text;

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
                myCommRecsAgy = (from rec in _context.COMPROD2
                                 where (rec.TYPE == "AGY") && (rec.Inactive == false) && ((rec.START_DATE <= TheDate) && (rec.END_DATE >= TheDate))
                                 select rec).ToList<IComprod2>();
            }
            else {
                myCommRecsAgy = (from rec in _context.COMPROD2
                                 where (rec.TYPE == "AGY") && (rec.Inactive == false)
                                 select rec).ToList<IComprod2>();
            }

            myCommLvl = (from rec in _context.CommLevel select rec).ToList<ICommLevel>();
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

        private void PanelControl14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ImageComboBoxEditCity_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCity, sender);
        }

        private void SpinEditDueDays_TextChanged(object sender, EventArgs e)
        {
            if (SpinEditDueDays.Value > 0) {
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
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateState, sender);
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

        private void ChangePaymentProfileButton_Click(object sender, EventArgs e)
        {
            //AuthorizeNet.CustomerGateway conn = new AuthorizeNet.CustomerGateway(apiLogin, transactionKey, AuthorizeNet.ServiceMode.Test);
            if (string.IsNullOrWhiteSpace(TextEditCustomerProfileEmail.Text)) {
                MessageBox.Show("Please enter a value for the Customer Email Address");
                return;
            }
            if (string.IsNullOrEmpty(_selectedRecord.PaymentProcessorCustProfileId)) {
                currentCust = _custGateway.CreateCustomer(TextEditCustomerProfileEmail.Text, TextEditName.Text);
                LabelPaymentProcessorCustProfileId.Text = currentCust.ProfileID;
                _selectedRecord.PaymentProcessorCustProfileId = currentCust.ProfileID;
                // labelControl22.Text = currentCust.ProfileID;
                currentCust.ID = TextEditCode.Text;
                _custGateway.UpdateCustomer(currentCust);
                ChangePaymentProfileButton.Enabled = false;
                DeleteButton.Enabled = true;
                GridControlBankProfiles.Enabled = true;
                AddBankButton.Enabled = true;
                DelBankButton.Enabled = true;
                SimpleButtonValidateBankRow.Enabled = true;
                GridControlCreditProfiles.Enabled = true;
                AddCreditButton.Enabled = true;
                DelCreditButton.Enabled = true;
                SimpleButtonValidateCreditRow.Enabled = true;
                ImageComboBoxEditDefaultPmtProfileID.Enabled = true;
            } else {
                foreach (AuthorizeNet.PaymentProfile rec in creditCards) {
                    //  
                    if (rec.CardNumber.Length > 8 || rec.CardExpiration.Length > 4) {
                        AgencyPaymentProfile updateRec = (from agyRec in _context.AgencyPaymentProfile where agyRec.Agy_No == TextEditCode.Text && agyRec.PaymentProfileID == rec.ProfileID select agyRec).FirstOrDefault();
                        if (rec.CardNumber.Length > 8)
                            updateRec.PaymentProvider = (GetCardTypeFromNumber(rec.CardNumber)).ToString();
                        updateRec.LastDigits = rec.CardNumber.GetLast(4);
                        updateRec.ExpirationMonth = Convert.ToInt32(rec.CardExpiration.GetLast(2));
                        updateRec.ExpirationYear = Convert.ToInt32(rec.CardExpiration.Substring(0, 4));
                        if (string.IsNullOrEmpty(rec.ProfileID)) {
                            updateRec.PaymentProfileID = _custGateway.AddCreditCard(currentCust.ProfileID, rec.CardNumber, (int)updateRec.ExpirationMonth, (int)updateRec.ExpirationYear, rec.CardCode);
                        }
                        else {
                            _custGateway.UpdatePaymentProfile(currentCust.ProfileID, rec);
                        }
                        _context.SaveChanges();
                    }
                }

                foreach (AuthorizeNet.PaymentProfile rec in bankAccnts) {
                    // conn.UpdatePaymentProfile(currentCust.ProfileID, rec);
                    if (rec.BankAccountNumber.Length > 8) {
                        AgencyPaymentProfile updateRec = (from agyRec in _context.AgencyPaymentProfile where agyRec.Agy_No == TextEditCode.Text && agyRec.PaymentProfileID == rec.ProfileID select agyRec).FirstOrDefault();
                        updateRec.PaymentProvider = rec.BankName;
                        updateRec.LastDigits = rec.CardNumber.GetLast(4);
                        if (string.IsNullOrEmpty(rec.ProfileID)) {
                            updateRec.PaymentProfileID = _custGateway.AddBankAccount(currentCust.ProfileID, rec.BankNameOnAccount, rec.BankAccountNumber, rec.BankRoutingNumber, rec.BankName, rec.AccountType, true, rec.BillingAddress);
                        }
                        else {
                            _custGateway.UpdatePaymentProfile(currentCust.ProfileID, rec);
                        }
                        _custGateway.UpdatePaymentProfile(currentCust.ProfileID, rec);
                    }
                }
                currentCust.Email = TextEditCustomerProfileEmail.Text;
                _custGateway.UpdateCustomer(currentCust);
                _context.SaveChanges();
                //currentCust = conn.GetCustomer(labelControl22.Text);
                if (currentCust.PaymentProfiles.Count() > 0)
                    LoadAuthorize(currentCust);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            //delete
            if (MessageBox.Show("Are you sure you want to delete the customer profile?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                _custGateway.DeleteCustomer(currentCust.ProfileID);
                var recs = from payRec in _context.AgencyPaymentProfile where payRec.Agy_No == TextEditCode.Text select payRec;
                foreach (AgencyPaymentProfile record in recs)
                    _context.DeleteObject(record);
                GridViewLookup.SetFocusedRowCellValue("PaymentProcessorCustProfileId", string.Empty);
                GridViewLookup.SetFocusedRowCellValue("PaymentProcessorCustProfileEmail", string.Empty);
                GridViewLookup.SetFocusedRowCellValue("DefaultPaymentProfileId", string.Empty);
                GridViewLookup.SetFocusedRowCellValue("DefaultPaymentProfileId", string.Empty);
                ImageComboBoxEditDefaultPmtProfileID.Properties.Items.Clear();
                ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = string.Empty };
                ImageComboBoxEditDefaultPmtProfileID.Properties.Items.Add(loadBlank);
                ChangePaymentProfileButton.Text = "Create";
            }
        }

        void BindCreditPaymentProfiles()
        {
            GridControlCreditProfiles.DataSource = BindingSourceAgencyPaymentProfileCredit;
            GridControlCreditProfiles.RefreshDataSource();
        }

        private void AddCreditButton_Click(object sender, EventArgs e)
        {
            AgencyPaymentProfile pmtProfile = new AgencyPaymentProfile {
                Agy_No = TextEditCode.Text ?? string.Empty
            };
            _selectedRecord.AgencyPaymentProfile.Add(pmtProfile);
            BindCreditPaymentProfiles();
            GridViewCreditProfiles.FocusedRowHandle = BindingSourceAgencyPaymentProfileCredit.Count - 1;
        }

        void BindBankPaymentProfiles()
        {
            GridControlBankProfiles.DataSource = BindingSourceAgencyPaymentProfileCredit;
            GridControlBankProfiles.RefreshDataSource();
        }

        private void AddBankButton_Click(object sender, EventArgs e)
        {
            AgencyPaymentProfile pmtProfile = new AgencyPaymentProfile {
                Agy_No = TextEditCode.Text ?? string.Empty
            };
            _selectedRecord.AgencyPaymentProfile.Add(pmtProfile);
            BindBankPaymentProfiles();
            GridViewBankProfiles.FocusedRowHandle = BindingSourceAgencyPaymentProfileCredit.Count - 1;
        }

        private void TextEditPaymentProcessorCustProfileEmail_EditValueChanged(object sender, EventArgs e)
        {
            ChangePaymentProfileButton.Enabled = true;
        }

        private void DelCredButton_Click(object sender, EventArgs e)
        {
            if (GridViewCreditProfiles.FocusedRowHandle >= 0) {
                AuthorizeNet.PaymentProfile rec = (AuthorizeNet.PaymentProfile)GridViewCreditProfiles.GetFocusedRow();
                if (rec.ProfileID != null) {
                    AgencyPaymentProfile delRec = (from agyRec in _context.AgencyPaymentProfile where agyRec.PaymentProfileID == rec.ProfileID select agyRec).FirstOrDefault();
                    _custGateway.DeletePaymentProfile(currentCust.ProfileID, rec.ProfileID);
                    if (delRec != null) {
                        if (ImageComboBoxEditDefaultPmtProfileID.Text == delRec.PaymentProfileDesc)
                            GridViewLookup.SetFocusedRowCellValue("DefaultPaymentProfileId", string.Empty);
                        _context.DeleteObject(delRec);
                        _context.SaveChanges();
                    }
                    currentCust = _custGateway.GetCustomer(currentCust.ProfileID);
                    GridControlCreditProfiles.DataSource = null;
                    GridControlBankProfiles.DataSource = null;
                    LoadAuthorize(currentCust);
                    //authorizeCreditMod = false;
                }
                else {
                    //authorizeCreditMod = false;
                    GridControlCreditProfiles.DataSource = null;
                    GridControlBankProfiles.DataSource = null;
                    creditCards.RemoveAt(creditCards.Count - 1);
                    LoadAuthorize(currentCust);

                }
            }
        }

        private void DelBankButton_Click(object sender, EventArgs e)
        {
            if (GridViewBankProfiles.FocusedRowHandle >= 0) {
                AuthorizeNet.PaymentProfile rec = (AuthorizeNet.PaymentProfile)GridViewBankProfiles.GetFocusedRow();
                if (rec.ProfileID != null) {
                    _custGateway.DeletePaymentProfile(currentCust.ProfileID, rec.ProfileID);
                    currentCust = _custGateway.GetCustomer(currentCust.ProfileID);
                    //remove rec in payment table
                    AgencyPaymentProfile delRec = (from agyRec in _context.AgencyPaymentProfile where agyRec.PaymentProfileID == rec.ProfileID select agyRec).FirstOrDefault();
                    if (delRec != null) {
                        if (ImageComboBoxEditDefaultPmtProfileID.Text == delRec.PaymentProfileDesc)
                            ImageComboBoxEditDefaultPmtProfileID.Text = string.Empty;
                        _context.AgencyPaymentProfile.DeleteObject(delRec);
                        _context.SaveChanges();
                    }
                    GridControlCreditProfiles.DataSource = null;
                    GridControlBankProfiles.DataSource = null;
                    LoadAuthorize(currentCust);
                    //authorizeBankMod = false;
                }
                else {
                    //authorizeBankMod = false;
                    GridControlCreditProfiles.DataSource = null;
                    GridControlBankProfiles.DataSource = null;
                    bankAccnts.RemoveAt(bankAccnts.Count - 1);
                    LoadAuthorize(currentCust);

                }
            }
        }

        private void GridViewPaymentProfiles_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void GridViewPaymentProfiles_ValidateRow(object sender, ValidateRowEventArgs e)
        {

            ColumnView view = sender as ColumnView;
            AuthorizeNet.PaymentProfile record = (AuthorizeNet.PaymentProfile)e.Row;
            view.ClearColumnErrors();
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
                if (!string.IsNullOrWhiteSpace(record.CardExpiration) && (!DateTime.TryParseExact(record.CardExpiration, "yyyy-MM", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime Test) || record.CardExpiration.Length > 7)) {
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

        private void GridViewBankProfiles_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void GridViewBankProfiles_ValidateRow(object sender, ValidateRowEventArgs e)
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
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCreditLimit, sender);
        }

        private void TextEditCreditLimitRemPct_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCredLimRemPct, sender);
        }

        private void TextEditPaymentProcessorCustProfileEmail_Leave(object sender, EventArgs e)
        {

        }

        private void ImageComboBoxEditDefaultProfileID_Leave(object sender, EventArgs e)
        {

        }

        private void AgyBindingSource_PositionChanged(object sender, EventArgs e)
        {

        }

        private const string _cardRegex = "^(?:(?<Visa>4\\d{3})|(?<JCB>2131|1800|3088|35\\d{3}\\d{11})|(?<MasterCard>5[1-5]\\d{2})|(?<Discover>6011)|(?<DinersClub>(?:3[68]\\d{2})|(?:30[0-5]\\d))|(?<Amex>3[47]\\d{2}))([ -]?)(?(DinersClub)(?:\\d{6}\\1\\d{4})|(?(Amex)(?:\\d{6}\\1\\d{5})|(?:\\d{4}\\1\\d{4}\\1\\d{4})))$";

        public static CreditCardTypeType? GetCardTypeFromNumber(string cardNum)
        {
            //Create new instance of Regex comparer with our
            //credit card regex patter
            Regex cardTest = new Regex(_cardRegex);

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

        private void AgencyForm_Load(object sender, EventArgs e)
        {

        }

        private void CheckEditRequireCVV2_Click(object sender, EventArgs e)
        {
            grdColCVV2.Visible = CheckEditRequireCVV2.Checked;
        }

        private void CheckEditHtlVouchers_Click(object sender, EventArgs e)
        {
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
            if (!CheckEditSglResConf.Checked && !TextEditVouchTypes.Text.Contains("SGL")) {
                TextEditVouchTypes.Text += "SGL,";
                TextEditVouchTypes.Text = TextEditVouchTypes.Text.Trim();
            }

            if (CheckEditSglResConf.Checked && TextEditVouchTypes.Text.Contains("SGL")) {
                int loc = TextEditVouchTypes.Text.IndexOf("SGL,");
                TextEditVouchTypes.Text = TextEditVouchTypes.Text.Remove(loc, 4);
            }
        }

        private void AgcyLogBindingSource_CurrentChanged(object sender, EventArgs e)
        {//move to custom row cell edit event for the agcy log grid
            if (BindingSourceAgcyLog.Current != null && _selectedRecord != null) {
                if (_selectedRecord.NO == _defAgy) {
                    //RepositoryItemImageComboBoxEditAgentDelegate.
                    RepositoryItemImageComboBoxEditAgentDelegate.Items.Clear();
                    RepositoryItemImageComboBoxEditAgentDelegate.Items.Add(new ImageComboBoxItem() { Description = "", Value = null });

                    var agent = (AGCYLOG)BindingSourceAgcyLog.Current;
                    var agents = (from agentRec in _selectedRecord.AGCYLOG
                                 where agentRec.AGT_NAME != agent.AGT_NAME && agentRec.AgentCompany == agent.AgentCompany
                                 orderby agentRec.AGT_NAME
                                 select new { Description = agentRec.AGT_NAME, Value = agentRec.AGT_NAME }).ToList();
                    foreach (var agtRec in agents) {
                        RepositoryItemImageComboBoxEditAgentDelegate.Items.Add(new ImageComboBoxItem(agtRec.Description, agtRec.Value));
                    }
                }
            }
        }

        private void ButtonAddAgencyCurrency_Click(object sender, EventArgs e)
        {
            AgencyCurrency currency = new AgencyCurrency {
                Agy_No = TextEditCode.Text ?? string.Empty
            };
            _selectedRecord.AgencyCurrency.Add(currency);
            BindAgencyCurrencies();
            GridViewAgencyCurrency.FocusedRowHandle = BindingSourceAgencyCurrency.Count - 1;
        }

        private void BindAgencyCurrencies()
        {
            GridControlAgencyCurrency.DataSource = BindingSourceAgencyCurrency;
            GridControlAgencyCurrency.RefreshDataSource();
        }

        // BAW
        private void SetAgyCurrencyBindings()
        {
            ////if (CurrToExRateBindingSource.Current == null) {
            ////    _selectedExchangeRateRecord = null;
            ////    enableNavigator(false);
            ////    //setReadOnly(true);
            ////}
            ////else {
            //var selectedRecord = (AgencyCurrency)AgencyCurrencyBindingSource.Current;
            //// only do this to newly created agency currency records
            //if (newAgyCurrencyRec && string.IsNullOrEmpty(selectedRecord.Currency_Code)) {
            //    selectedRecord.Agy_No = ((AGY)BindingSource.Current).NO;
            //    selectedRecord.Default = false;  // should be false
            //}
            ////enableNavigator(true);
            ////setReadOnly(false);
        }

        private void AgencyCurrencyBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            SetAgyCurrencyBindings();
        }

        private void ButtonDeleteAgencyCurrency_Click(object sender, EventArgs e)
        {
            if (GridViewAgencyCurrency.FocusedRowHandle >= 0) {
                AgencyCurrency currency = (AgencyCurrency)GridViewAgencyCurrency.GetFocusedRow();
                BindingSourceAgencyCurrency.Remove(currency);
                //Removing from the bindingsource just removes the object from its parent, but does not mark
                //it for deletion, effectively orphaning it.  This will cause foreign key errors when saving.
                //To flag for deletion, delete it from the context as well.
                _context.AgencyCurrency.DeleteObject(currency);
                BindAgencyCurrencies();
            }
        }

        void LoadAndBindAgencyCurrencies()
        {
            //Load the related entities. DO NOT do another db query using context.whatever because they
            //will not be associated with the parent entity, and new items will not be added to the relationship
            //so foreign key errors will result. Can't load the related entities on a detached or added (but not saved)
            //entity.
            if (_selectedRecord.EntityState != System.Data.Entity.EntityState.Detached) {
                _selectedRecord.AgencyCurrency.Load(MergeOption.OverwriteChanges);
            }
            //Don't do any LINQ operations on the entitycollection, just bind directly to it, otherwise
            //it appears to bind as unassociated with the context and you have to manually add/delete
            //rows from the bindingsource to the context (but changes work fine)
            BindingSourceAgencyCurrency.DataSource = _selectedRecord.AgencyCurrency;
            BindAgencyCurrencies();
        }

        // BAW
        // Ensures that the user has to select exactly one default currency

        // BAW
        // When a new/modified currency is deleted, this method adjusts the lists that keep track of new/modified values

        private void GridViewAgencyCurrency_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void FinalizeBindings()
        {
            BindingSource.EndEdit();
            GridViewContacts.CloseEditor();
            GridViewContacts.UpdateCurrentRow();
            //Set the city code for each mapping just in case
            for (int rowCtr = 0; rowCtr < GridViewContacts.DataRowCount; rowCtr++) {
                CONTACT contact = (CONTACT)GridViewContacts.GetRow(rowCtr);
                contact.LINK_VALUE = TextEditCode.Text ?? string.Empty;
            }
            BindingSourceContact.EndEdit();

            GridViewMemberships.CloseEditor();
            GridViewMemberships.UpdateCurrentRow();
            for (int rowCtr = 0; rowCtr < GridViewMemberships.DataRowCount; rowCtr++) {
                DETAIL detail = (DETAIL)GridViewMemberships.GetRow(rowCtr);
                detail.LINK_VALUE = TextEditCode.Text ?? string.Empty;
            }
            BindingSourceDetail.EndEdit();

            GridViewDeposits.CloseEditor();
            GridViewDeposits.UpdateCurrentRow();
            for (int rowCtr = 0; rowCtr < GridViewDeposits.DataRowCount; rowCtr++) {
                PaymentTransaction detail = (PaymentTransaction)GridViewDeposits.GetRow(rowCtr);
                detail.Agency = TextEditCode.Text ?? string.Empty;
                detail.Agent = _sys.User.Name;
                detail.Successful = true;
            }
            BindingSourcePaymentTransaction.EndEdit();

            GridViewAgcyLog.CloseEditor();
            GridViewAgcyLog.UpdateCurrentRow();
            for (int rowCtr = 0; rowCtr < GridViewAgcyLog.DataRowCount; rowCtr++) {
                AGCYLOG profile = (AGCYLOG)GridViewAgcyLog.GetRow(rowCtr);
                profile.AGENCY = TextEditCode.Text ?? string.Empty;
            }
            BindingSourceAgcyLog.EndEdit();
        }

        void SetBindings()
        {
            if (BindingSource.Current == null) {
                ClearBindings();
            }
            else {
                _selectedRecord = ((AGY)BindingSource.Current);
                LoadAndBindPaymentProfiles();
                LoadAndBindDetails();
                LoadAndBindContacts();
                LoadAndBindAgencyCurrencies();
                LoadAndBindAgcyLogs();
                LoadAndBindPaymentTrasactions();
                SetReadOnly(false);
                SetReadOnlyKeyFields(true);
                BarButtonItemDelete.Enabled = true;
                BarButtonItemSave.Enabled = true;
            }
            GridViewAgcyLog.Columns["Agcylog_Agent_Delegate"].Visible = (TextEditCode.Text == _defAgy);
            GridViewAgcyLog.Columns["SUPVR_FLG"].Visible = (TextEditCode.Text == _defAgy);
            ErrorProvider.Clear();
        }

        private void LoadAndBindContacts()
        {
            if (!string.IsNullOrEmpty(_selectedRecord.NO)) {
                string id = _selectedRecord.NO.ToString();
                BindingSourceContact.DataSource = _context.CONTACT.Where(c => c.LINK_VALUE == id);
            }
        }

        void LoadAndBindPaymentTrasactions()
        {
            //Load the related entities. DO NOT do another db query using context.whatever because they
            //will not be associated with the parent entity, and new items will not be added to the relationship
            //so foreign key errors will result. Can't load the related entities on a detached or added (but not saved)
            //entity.
            if (_selectedRecord.EntityState != System.Data.Entity.EntityState.Detached) {
                _selectedRecord.PaymentTransaction.Load(MergeOption.OverwriteChanges);
            }
            //Don't do any LINQ operations on the entitycollection, just bind directly to it, otherwise
            //it appears to bind as unassociated with the context and you have to manually add/delete
            //rows from the bindingsource to the context (but changes work fine)
            BindingSourcePaymentTransaction.DataSource = _selectedRecord.PaymentTransaction;
            BindPaymentTransactions();
        }

        void LoadAndBindAgcyLogs()
        {
            //Load the related entities. DO NOT do another db query using context.whatever because they
            //will not be associated with the parent entity, and new items will not be added to the relationship
            //so foreign key errors will result. Can't load the related entities on a detached or added (but not saved)
            //entity.
            if (_selectedRecord.EntityState != System.Data.Entity.EntityState.Detached) {
                _selectedRecord.AGCYLOG.Load(MergeOption.OverwriteChanges);
            }
            //Don't do any LINQ operations on the entitycollection, just bind directly to it, otherwise
            //it appears to bind as unassociated with the context and you have to manually add/delete
            //rows from the bindingsource to the context (but changes work fine)
            BindingSourceAgcyLog.DataSource = _selectedRecord.AGCYLOG;
            BindAgencyLogs();
        }

        void LoadAndBindPaymentProfiles()
        {
            //Load the related entities. DO NOT do another db query using context.whatever because they
            //will not be associated with the parent entity, and new items will not be added to the relationship
            //so foreign key errors will result. Can't load the related entities on a detached or added (but not saved)
            //entity.
            if (_selectedRecord.EntityState != System.Data.Entity.EntityState.Detached) {
                _selectedRecord.AgencyPaymentProfile.Load(MergeOption.OverwriteChanges);
            }
            //Don't do any LINQ operations on the entitycollection, just bind directly to it, otherwise
            //it appears to bind as unassociated with the context and you have to manually add/delete
            //rows from the bindingsource to the context (but changes work fine)
            if (!string.IsNullOrEmpty(_selectedRecord.PaymentProcessorCustProfileId)) { 
                try {
                    var cust = _custGateway.GetCustomer(_selectedRecord.PaymentProcessorCustProfileId);
                    bankAccnts.Clear();
                    creditCards.Clear();
                    ImageComboBoxEditDefaultPmtProfileID.Properties.Items.Clear();
                    ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = string.Empty, Value = string.Empty };
                    ImageComboBoxEditDefaultPmtProfileID.Properties.Items.Add(loadBlank);
                    foreach (AuthorizeNet.PaymentProfile profile in cust.PaymentProfiles) {
                        if (!string.IsNullOrWhiteSpace(profile.BankAccountNumber))
                            bankAccnts.Add(profile);

                        if (!string.IsNullOrWhiteSpace(profile.CardNumber))
                            creditCards.Add(profile);
                    }
                }
                catch {
                    this.DisplayWarning("Customer payment information could not be retrieved from profile manager");
                }

                //GridControlCreditProfiles.DataSource = creditCards;
                //GridControlBankProfiles.DataSource = bankAccnts;
                ///////////////////////

                var loadDefault = from agyRec in _context.AgencyPaymentProfile where agyRec.Agy_No == TextEditCode.Text select agyRec;
                foreach (var result in loadDefault) {
                    ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.PaymentProfileDesc, Value = result.PaymentProfileID };
                    ImageComboBoxEditDefaultPmtProfileID.Properties.Items.Add(load);
                }
                //setDefeaultProfile to first added if none is set
                //if (string.IsNullOrWhiteSpace(ImageComboBoxEditDefaultPaymentProfileID.Text) && currentCust.PaymentProfiles.Count > 0) {
                //    ImageComboBoxEditDefaultPaymentProfileID.EditValue = currentCust.PaymentProfiles[0].ProfileID;
                //    _context.SaveChanges();
                //}
                BindingSourceAgencyPaymentProfileCredit.DataSource = _selectedRecord.AgencyPaymentProfile;
                BindPaymentProfiles();
            }
        }

        void BindPaymentProfiles()
        {
            GridControlCreditProfiles.DataSource = BindingSourcePaymentProfiles;
            GridControlCreditProfiles.RefreshDataSource();
        }

        private void RemoveRecord()
        {
            //Note that cascade delete must be set on the FK in the db in order for the related
            //entities to be deleted.  This is a db function, not an EF function. However in addition
            //the model must know about the delete, otherwise the relationships in the context will
            //get messed up.  So after adding the cascade rule to the FK, the model must be updated,
            //and in order to refresh a relationship the tables must be deleted and re-added
            //Otherwise, we could do a delete loop
            //If using DbContext instead of ObjectContext, we could do eg
            //_context.SupplierCity.RemoveRange(_selectedRecord.SupplierCity)
            BindingSource.RemoveCurrent();
        }

        private void RefreshRecord()
        {
            //A Detached record has not yet been added to the context
            //An Added record has been added but not yet saved, most likely because there was
            //an error in SaveRecord, in which case we should not retrieve it from the db
            if (_selectedRecord != null && _selectedRecord.EntityState != System.Data.Entity.EntityState.Detached
                && _selectedRecord.EntityState != System.Data.Entity.EntityState.Added) {
                _context.Refresh(RefreshMode.StoreWins, _selectedRecord);
                RefreshContacts();
                RefreshDetails();
                SetReadOnlyKeyFields(true);
            }
        }

        private void RefreshContacts()
        {
            //Refreshing from store can't refresh added but unsaved records, so these have to be manually removed first
            List<CONTACT> toRemove = new List<CONTACT>();
            foreach (CONTACT contact  in BindingSourceContact.List) {
                if (contact.EntityState == System.Data.Entity.EntityState.Added) {
                    toRemove.Add(contact);
                }
            }
            foreach (CONTACT contact in toRemove) {
                BindingSourceContact.Remove(contact);
            }
            _context.Refresh(RefreshMode.StoreWins, BindingSourceContact.List);
            LoadAndBindContacts();
        }

        private void RefreshDetails()
        {
            //Refreshing from store can't refresh added but unsaved records, so these have to be manually removed first
            List<DETAIL> toRemove = new List<DETAIL>();
            foreach (DETAIL detail in BindingSourceDetail.List) {
                if (detail.EntityState == System.Data.Entity.EntityState.Added) {
                    toRemove.Add(detail);
                }
            }
            foreach (DETAIL detail in toRemove) {
                BindingSourceDetail.Remove(detail);
            }
            _context.Refresh(RefreshMode.StoreWins, BindingSourceDetail.List);
            LoadAndBindDetails();
        }
        
        private void LoadAndBindDetails()
        {
            if (!string.IsNullOrEmpty(_selectedRecord.NO)) {
                BindingSourceDetail.DataSource = _context.DETAIL.Where(c => c.LINK_VALUE == _selectedRecord.NO && c.LINK_TABLE == "AGY" && c.RECTYPE == "AGYCLASS");
            }
        }

        private void DeleteRecord()
        {
            if (_selectedRecord == null)
                return;

            try {
                if (DisplayHelper.QuestionYesNo(this, "Are you sure you want to delete this record?") == DialogResult.Yes) {
                    //ignoreLeaveRow and ignorePositionChange are set because when removing a record, the bindingsource_currentchanged 
                    //and gridview_beforeleaverow events will fire as the current record is removed out from under them.
                    //We do not want these events to perform their usual code of checking whether there are changes in the active
                    //record that should be saved before proceeding, because we know we have just deleted the active record.
                    _ignoreLeaveRow = true;
                    _ignorePositionChange = true;
                    RemoveRecord();
                    if (!_selectedRecord.IsNew()) {
                        //Apparently a record which has just been added is not flagged for deletion by BindingSource.RemoveCurrent,
                        //(the EntityState remains unchanged).  It seems like it is not tracked by the context even though it is, because
                        //the EntityState changes for modification. So if this is a deletion and the entity is not flagged for deletion, 
                        //delete it manually.
                        if (_selectedRecord != null && (_selectedRecord.EntityState & System.Data.Entity.EntityState.Deleted) != System.Data.Entity.EntityState.Deleted)
                            _context.AGY.DeleteObject(_selectedRecord);
                        _context.SaveChanges();
                    }
                    if (GridViewLookup.DataRowCount == 0) {
                        ClearBindings();
                    }
                    _ignoreLeaveRow = false;
                    _ignorePositionChange = false;
                    SetBindings();
                    EntityInstantFeedbackSource.Refresh();
                    ShowActionConfirmation("Record Deleted");
                }
            }
            catch (Exception ex) {
                DisplayHelper.DisplayError(this, ex);
                _ignoreLeaveRow = false;
                _ignorePositionChange = false;
                RefreshRecord();        //pull it back from db because that is it's current state
                //We must also Load and rebind the related entities from the db because context.Refresh doesn't do that
                SetBindings();
            }
        }

        void ClearBindings()
        {
            _ignoreLeaveRow = true;
            _ignorePositionChange = true;
            _selectedRecord = null;
            SetReadOnly(true);
            BindingSourceDetail.DataSource = typeof(DETAIL);
            BindingSourceAgcyLog.DataSource = typeof(AGCYLOG);
            BindingSourcePaymentTransaction.DataSource = typeof(PaymentTransaction);
            BindingSourceContact.DataSource = typeof(CONTACT);
            BarButtonItemDelete.Enabled = false;
            BarButtonItemSave.Enabled = false;
            BindingSource.DataSource = typeof(AGY);
            _ignoreLeaveRow = false;
            _ignorePositionChange = false;
        }

        private void ButtonAddRow1_Click(object sender, EventArgs e)
        {
            DETAIL resource = new DETAIL() {
                LINK_TABLE = "AGY",
                RECTYPE = "AGYCLASS",
                LINK_VALUE = _selectedRecord.NO ?? string.Empty
            };
            BindingSourceDetail.Add(resource);
        }

        private void ButtonDelRow_Click(object sender, EventArgs e)
        {
            _detailsModified = true;
            BindingSourceDetail.RemoveCurrent();
        }

        private void SetUpdateFields(AGY record)
        {
            record.LAST_UPD = DateTime.Now;
            record.UPD_INIT = _sys.User.Name;
        }

        private bool SaveRecord(bool prompt)
        {
            try {
                if (_selectedRecord == null)
                    return true;

                FinalizeBindings();
                bool newRec = _selectedRecord.IsNew();
                bool modified = newRec || IsModified(_selectedRecord);
                bool nameChanged = _selectedRecord.IsModified(_context, "NAME");

                if (modified) {
                    if (prompt) {
                        DialogResult result = DisplayHelper.QuestionYesNoCancel(this, "Do you want to save these changes?");
                        if (result == DialogResult.No) {
                            if (newRec) {
                                RemoveRecord();
                            }
                            else {
                                RefreshRecord();
                            }
                            return true;
                        }
                        else if (result == DialogResult.Cancel) {
                            return false;
                        }
                    }
                    if (!ValidateAll())
                        return false;

                    if (_selectedRecord.EntityState == System.Data.Entity.EntityState.Detached) {
                        _context.AGY.AddObject(_selectedRecord);
                    }
                    SetUpdateFields(_selectedRecord);
                    _context.SaveChanges();
                    if (newRec || nameChanged) {
                        AccountingAPI.InvokeForAgency(_sys.Settings.TourAccountingURL, _selectedRecord.NO);
                    }
                    EntityInstantFeedbackSource.Refresh();
                    ShowActionConfirmation("Record Saved");
                }
                return true;
            }
            catch (Exception ex) {
                DisplayHelper.DisplayError(this, ex);
                RefreshRecord();        //pull it back from db because that is its current state
                                        //We must also Load and rebind the related entities from the db because context.Refresh doesn't do that
                SetBindings();
                return false;
            }
        }

        private void SetErrorInfo(Func<String> validationMethod, object sender)
        {
            BindingSource.EndEdit();
            if (validationMethod != null) {
                string error = validationMethod.Invoke();
                ErrorProvider.SetError((Control)sender, error);
            }
        }

        private bool ValidateAll()
        {
            bool detailsInvalid = false;
            if (BindingSourceDetail.List.Count > 0) {
                detailsInvalid = BindingSourceDetail.List.Cast<DETAIL>().Any(b => !b.Validate());
            }

            if (!_selectedRecord.Validate()) {
                ShowMainControlErrors();
                DisplayHelper.DisplayWarning(this, "Errors were found. Please resolve them and try again.");
                return false;
            }
            else {
                ErrorProvider.Clear();
                return true;
            }
        }

        private void ShowMainControlErrors()
        {
            //The error indicators inside the grids are handled by binding, but errors on the main form must
            //be set manually
            SetErrorInfo(_selectedRecord.ValidateNo, TextEditCode);
            SetErrorInfo(_selectedRecord.ValidateName, TextEditName);
            SetErrorInfo(_selectedRecord.ValidateType, TextEditType);
            SetErrorInfo(_selectedRecord.ValidateAP, TextEditAp);
            SetErrorInfo(_selectedRecord.ValidateAR, TextEditAr);
            SetErrorInfo(_selectedRecord.ValidateDefLang, SearchLookupEditDefLanguage);
            SetErrorInfo(_selectedRecord.ValidateAddress1, TextEditAddr1);
            SetErrorInfo(_selectedRecord.ValidateAddress2, TextEditAddr2);
            SetErrorInfo(_selectedRecord.ValidateAddress3, TextEditAddr3);
            SetErrorInfo(_selectedRecord.ValidateCity, TextEditCity);
            SetErrorInfo(_selectedRecord.ValidateState, TextEditState);
            SetErrorInfo(_selectedRecord.ValidateZip, TextEditZip);
            SetErrorInfo(_selectedRecord.ValidateCountry, SearchLookupEditCountry);
            SetErrorInfo(_selectedRecord.ValidateMailFax, ImageComboBoxEditMailFaxFlg);
            SetErrorInfo(_selectedRecord.ValidatePhone, TextEditPhone);
            SetErrorInfo(_selectedRecord.ValidateEmail, TextEditEmail);
            SetErrorInfo(_selectedRecord.ValidateFax, TextEditFaxNum);
            SetErrorInfo(_selectedRecord.ValidateRetNotAvail, ImageComboBoxEditRetNotAvalHtls);
            SetErrorInfo(_selectedRecord.ValidateRetReq, ImageComboBoxEditRetreqHtls);
            SetErrorInfo(_selectedRecord.ValidateRel, SpinEditRel);
            SetErrorInfo(_selectedRecord.ValidateTourfaxEmailFormat, ImageComboBoxEditTourfaxEmailFormat);
            SetErrorInfo(_selectedRecord.ValidateVouchReprints, SpinEditVoucherReprints);
            SetErrorInfo(_selectedRecord.ValidateVouchDaysPrior, SpinEditVoucherDaysPrior);
            SetErrorInfo(_selectedRecord.ValidateOptDays, SpinEditOptDays);
            SetErrorInfo(_selectedRecord.ValidateGrace, SpinEditCxlGrace);
            SetErrorInfo(_selectedRecord.ValidateComm, SpinEditComm);
            SetErrorInfo(_selectedRecord.ValidateEditHdr, ImageComboBoxEditHdrs);
            SetErrorInfo(_selectedRecord.ValidateEditHtl, ImageComboBoxEditHtls);
            SetErrorInfo(_selectedRecord.ValidateDueDays, SpinEditDueDays);
            SetErrorInfo(_selectedRecord.ValidatePmtDays, SpinEditPmtDays);
            SetErrorInfo(_selectedRecord.ValidateCreditLimit, SpinEditCreditLimit);
            SetErrorInfo(_selectedRecord.ValidatePriorDays, SpinEditPriorDays);
            SetErrorInfo(_selectedRecord.ValidateDaysSpace, SpinEditDaysSpace);
            SetErrorInfo(_selectedRecord.ValidateInvFormat, ComboBoxEditInvFmt);
            SetErrorInfo(_selectedRecord.ValidateCxlNights1, SpinEditCxlNtsPrior1);
            SetErrorInfo(_selectedRecord.ValidateCxlNights2, SpinEditCxlNtsPrior2);
            SetErrorInfo(_selectedRecord.ValidateCxlNights3, SpinEditCxlNtsPrior3);
            SetErrorInfo(_selectedRecord.ValidateChgNights1, SpinEditChgNtsPrior1);
            SetErrorInfo(_selectedRecord.ValidateChgNights2, SpinEditChgNtsPrior2);
            SetErrorInfo(_selectedRecord.ValidateChgNights3, SpinEditChgNtsPrior3);
            SetErrorInfo(_selectedRecord.ValidateCxlPct1, TextEditCxlPct1);
            SetErrorInfo(_selectedRecord.ValidateCxlPct2, TextEditCxlPct2);
            SetErrorInfo(_selectedRecord.ValidateCxlPct3, TextEditCxlPct3);
            SetErrorInfo(_selectedRecord.ValidateChgPct1, TextEditChgPct1);
            SetErrorInfo(_selectedRecord.ValidateChgPct2, TextEditChgPct2);
            SetErrorInfo(_selectedRecord.ValidateChgPct3, TextEditChgPct3);
            SetErrorInfo(_selectedRecord.ValidateCxlFlatFee1, TextEditCxlFlat1);
            SetErrorInfo(_selectedRecord.ValidateCxlFlatFee2, TextEditCxlFlat2);
            SetErrorInfo(_selectedRecord.ValidateCxlFlatFee3, TextEditCxlFlat3);
            SetErrorInfo(_selectedRecord.ValidateChgFlatFee1, TextEditChgFlat1);
            SetErrorInfo(_selectedRecord.ValidateChgFlatFee2, TextEditChgFlat2);
            SetErrorInfo(_selectedRecord.ValidateChgFlatFee3, TextEditChgFlat3);
            SetErrorInfo(_selectedRecord.ValidateParentAgy, SearchLookupEditParentAgy);
            SetErrorInfo(_selectedRecord.ValidateSrt2, TextEditSrt2);
            SetErrorInfo(_selectedRecord.ValidateSrt3, TextEditSrt3);
            _selectedRecord.Details = BindingSourceDetail.List.Cast<DETAIL>().ToList();
        }

        private bool IsModified(AGY record)
        {
            //Type-specific routine that takes into account relationships that should also be considered
            //when deciding if there are unsaved changes.  The entity properties also return true if the
            //record is new or deleted.
            if (record == null)
                return false;
            return record.IsModified(_context) 
                || _detailsModified 
                || _contactsModified
                || record.AgencyCurrency.IsModified(_context)
                || record.PaymentTransaction.IsModified(_context)
                || record.AGCYLOG.IsModified(_context);
        }

        private void BarButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _ignoreLeaveRow = true;       //so that when the grid row changes it doesn't try to save again
            if (SaveRecord(true)) {
                //For some reason when there is no existing record in the binding source the Add method does not
                //trigger the CurrentChanged event, but AddNew does so use that instead
                _selectedRecord = (AGY)BindingSource.AddNew();
                //With the instant feedback data source, the new row is not immediately added to the grid, so move
                //the focused row to the filter row just so that no other existing row is visually highlighted
                GridViewLookup.FocusedRowHandle = DevExpress.Data.BaseListSourceDataController.FilterRow;
                SetReadOnlyKeyFields(false);
                TextEditCode.Focus();
                SetReadOnly(false);
            }
            ErrorProvider.Clear();
            _ignoreLeaveRow = false;
        }

        private void EntityInstantFeedbackSource_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            FlextourEntities context = new FlextourEntities(Connection.EFConnectionString);
            e.QueryableSource = context.AGY;
            e.Tag = context;
        }

        private void EntityInstantFeedbackSource_DismissQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            ((FlextourEntities)e.Tag).Dispose();
        }

        private void BarButtonItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteRecord();
        }

        private void BarButtonItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SaveRecord(false))
                RefreshRecord();
        }

        void BindAgencyLogs()
        {
            GridControlAgcyLog.DataSource = BindingSourceAgcyLog;
            GridControlAgcyLog.RefreshDataSource();
        }

        private void ButtonAddMapping_Click(object sender, EventArgs e)
        {
            AGCYLOG agcylog = new AGCYLOG {
                AGENCY = TextEditCode.Text ?? string.Empty
            };
            _selectedRecord.AGCYLOG.Add(agcylog);
            BindAgencyLogs();
            GridViewAgcyLog.FocusedRowHandle = BindingSourceAgcyLog.Count - 1;
        }

        private void ButtonDeleteMapping_Click(object sender, EventArgs e)
        {
            if (GridViewAgcyLog.FocusedRowHandle >= 0) {
                AGCYLOG agcylog = (AGCYLOG)GridViewAgcyLog.GetFocusedRow();
                _selectedRecord.AGCYLOG.Remove(agcylog);
                //Removing from the collection just removes the object from its parent, but does not mark
                //it for deletion, effectively orphaning it.  This will cause foreign key errors when saving.
                //To flag for deletion, delete it from the context as well.
                _context.AGCYLOG.DeleteObject(agcylog);
                BindAgencyLogs();
            }
        }

        private void GridControlAgcyLog_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateAgcyLog, sender);
        }

        private void RadioGroupPaymentDue_EditValueChanged(object sender, EventArgs e)
        {
            if (RadioGroupPaymentDue.SelectedIndex == 0) {
                SpinEditDueDays.Enabled = false;
                SpinEditPmtDays.Enabled = true;
                SpinEditDueDays.Value = 0;
            }
            else {
                SpinEditDueDays.Enabled = true;
                SpinEditPmtDays.Enabled = false;
                SpinEditPmtDays.Value = 0;
            }
        }

        private void SimpleButtonValidateCreditRow_Click(object sender, EventArgs e)
        {
            AuthorizeNet.APICore.customerPaymentProfileMaskedType api = new AuthorizeNet.APICore.customerPaymentProfileMaskedType();
            api.payment = new AuthorizeNet.APICore.paymentMaskedType();
            api.payment.Item = new AuthorizeNet.APICore.creditCardMaskedType();
            api.customerType = AuthorizeNet.APICore.customerTypeEnum.business;
            api.customerTypeSpecified = true;
            AuthorizeNet.Address billing = new AuthorizeNet.Address();

            //apiType.payment.Item is creditCardMaskedType
            AuthorizeNet.PaymentProfile rec = new AuthorizeNet.PaymentProfile(api) {
                BillingAddress = billing
            };
            creditCards.Add(rec);

            if (rec.CardNumber.Length > 8 || rec.CardExpiration.Length > 4) {
                AgencyPaymentProfile updateRec = (from agyRec in _context.AgencyPaymentProfile where agyRec.Agy_No == TextEditCode.Text && agyRec.PaymentProfileID == rec.ProfileID select agyRec).FirstOrDefault();
                if (rec.CardNumber.Length > 8)
                    updateRec.PaymentProvider = (GetCardTypeFromNumber(rec.CardNumber)).ToString();
                updateRec.LastDigits = rec.CardNumber.GetLast(4);
                updateRec.ExpirationMonth = Convert.ToInt32(rec.CardExpiration.GetLast(2));
                updateRec.ExpirationYear = Convert.ToInt32(rec.CardExpiration.Substring(0, 4));
                if (string.IsNullOrEmpty(rec.ProfileID)) {
                    updateRec.PaymentProfileID = _custGateway.AddCreditCard(currentCust.ProfileID, rec.CardNumber, (int)updateRec.ExpirationMonth, (int)updateRec.ExpirationYear, rec.CardCode);
                }
                else {
                    _custGateway.UpdatePaymentProfile(currentCust.ProfileID, rec);
                }
                _context.SaveChanges();
            }
        }

        private void SimpleButtonValidateBankRow_Click(object sender, EventArgs e)
        {
            AuthorizeNet.APICore.customerPaymentProfileMaskedType api = new AuthorizeNet.APICore.customerPaymentProfileMaskedType();
            api.payment = new AuthorizeNet.APICore.paymentMaskedType();
            api.payment.Item = new AuthorizeNet.APICore.bankAccountMaskedType();
            api.customerType = AuthorizeNet.APICore.customerTypeEnum.business;
            api.customerTypeSpecified = true;
            AuthorizeNet.Address billing = new AuthorizeNet.Address();

            //apiType.payment.Item is creditCardMaskedType
            AuthorizeNet.PaymentProfile rec = new AuthorizeNet.PaymentProfile(api) {
                BillingAddress = billing
            };
            bankAccnts.Add(rec);

            if (rec.BankAccountNumber.Length > 8) {
                AgencyPaymentProfile updateRec = (from agyRec in _context.AgencyPaymentProfile where agyRec.Agy_No == TextEditCode.Text && agyRec.PaymentProfileID == rec.ProfileID select agyRec).FirstOrDefault();
                updateRec.PaymentProvider = rec.BankName;
                updateRec.LastDigits = rec.CardNumber.GetLast(4);
                if (string.IsNullOrEmpty(rec.ProfileID)) {
                    updateRec.PaymentProfileID = _custGateway.AddBankAccount(currentCust.ProfileID, rec.BankNameOnAccount, rec.BankAccountNumber, rec.BankRoutingNumber, rec.BankName, rec.AccountType, true, rec.BillingAddress);
                }
                else {
                    _custGateway.UpdatePaymentProfile(currentCust.ProfileID, rec);
                }
                _custGateway.UpdatePaymentProfile(currentCust.ProfileID, rec);
                _context.SaveChanges();
            }
        }

        private void GridViewMemberships_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            _detailsModified = true;
        }

        private void CheckEditCreditUnlimited_EditValueChanged(object sender, EventArgs e)
        {
            if (CheckEditCreditUnlimited.Checked) {
                SpinEditCreditLimit.Enabled = false;
                SpinEditCreditLimit.EditValue = 0;
                SpinEditCreditLimitRemPct.Enabled = false;
                SpinEditCreditLimitRemPct.EditValue = 100;
            }
            else {
                SpinEditCreditLimit.Enabled = true;
                SpinEditCreditLimitRemPct.Enabled = true;
            }
        }

        private void GridViewCreditProfiles_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {

        }

        private void CheckEditAllowElectronicPayment_EditValueChanged(object sender, EventArgs e)
        {
            if (CheckEditAllowElectronicPayment.Checked) {
                TextEditCustomerProfileEmail.Enabled = true;
                CheckEditRequireCVV2.Enabled = true;
                ChangePaymentProfileButton.Enabled = true;
                DeleteButton.Enabled = true;
                ImageComboBoxEditDefaultPmtProfileID.Enabled = true;
            } else {
                TextEditCustomerProfileEmail.Enabled = false;
                CheckEditRequireCVV2.Enabled = false;
                ChangePaymentProfileButton.Enabled = false;
                DeleteButton.Enabled = false;
                GridControlCreditProfiles.Enabled = false;
                GridControlBankProfiles.Enabled = false;
                AddCreditButton.Enabled = false;
                DelCreditButton.Enabled = false;
                SimpleButtonValidateCreditRow.Enabled = false;
                AddBankButton.Enabled = false;
                DelBankButton.Enabled = false;
                SimpleButtonValidateBankRow.Enabled = false;
                ImageComboBoxEditDefaultPmtProfileID.Enabled = false;
            }
        }

        private void LabelPaymentProcessorCustProfileId_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(LabelPaymentProcessorCustProfileId.Text)) {
                ChangePaymentProfileButton.Text = "Create";
                GridControlCreditProfiles.Enabled = false;
                GridControlBankProfiles.Enabled = false;
                AddCreditButton.Enabled = false;
                DelCreditButton.Enabled = false;
                SimpleButtonValidateCreditRow.Enabled = false;
                AddBankButton.Enabled = false;
                DelBankButton.Enabled = false;
                SimpleButtonValidateBankRow.Enabled = false;
            } else {
                ChangePaymentProfileButton.Text = "Update";
                GridControlCreditProfiles.Enabled = true;
                GridControlBankProfiles.Enabled = true;
                AddCreditButton.Enabled = true;
                DelCreditButton.Enabled = true;
                SimpleButtonValidateCreditRow.Enabled = true;
                AddBankButton.Enabled = true;
                DelBankButton.Enabled = true;
                SimpleButtonValidateBankRow.Enabled = true;
            }
        }

        private void CheckEditRequireCVV2_EditValueChanged(object sender, EventArgs e)
        {
            ChangePaymentProfileButton.Enabled = true;
        }

        private void BindingSourceAgencyPaymentProfileBank_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {

        }

        private void GridViewContacts_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            _contactsModified = true;
        }

        private void GridViewAgcyLog_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column == colAgcylog_Agent_Delegate) {
                if (_selectedRecord.NO == _defAgy) {
                    var agentName = GridViewAgcyLog.GetRowCellValue(e.RowHandle, colAGT_NAME).ToStringEmptyIfNull();
                    RepositoryItemImageComboBox editor = new RepositoryItemImageComboBox();
                    editor.Items.Add(new ImageComboBoxItem() { Description = string.Empty, Value = null });
                    editor.Items.AddRange(_selectedRecord.AGCYLOG.Where(a => a.AGT_NAME != agentName)
                        .OrderBy(a => a.AGT_NAME)
                        .Select(a => new ImageComboBoxItem() { Description = a.AGT_NAME, Value = a.AGT_NAME }).ToArray());
                    e.RepositoryItem = editor;
                }
                else {
                    e.RepositoryItem = null;
                }
            }
        }

        void BindPaymentTransactions()
        {
            GridControlDeposits.DataSource = BindingSourcePaymentTransaction;
            GridControlDeposits.RefreshDataSource();
        }

        private void ButtonAddDeposit_Click(object sender, EventArgs e)
        {
            PaymentTransaction paymentTransaction = new PaymentTransaction {
                Agency = TextEditCode.Text ?? string.Empty,
                Agent = _sys.User.Name
            };
            _selectedRecord.PaymentTransaction.Add(paymentTransaction);
            BindPaymentTransactions();
            GridViewDeposits.FocusedRowHandle = BindingSourcePaymentTransaction.Count - 1;
        }

        private void ButtonDeleteDeposit_Click(object sender, EventArgs e)
        {
            if (GridViewDeposits.FocusedRowHandle >= 0) {
                PaymentTransaction paymentTransaction = (PaymentTransaction)GridViewDeposits.GetFocusedRow();
                _selectedRecord.PaymentTransaction.Remove(paymentTransaction);
                //Removing from the collection just removes the object from its parent, but does not mark
                //it for deletion, effectively orphaning it.  This will cause foreign key errors when saving.
                //To flag for deletion, delete it from the context as well.
                _context.PaymentTransaction.DeleteObject(paymentTransaction);
                BindPaymentTransactions();
            }
        }

        private void AgencyForm_Shown(object sender, EventArgs e)
        {
            GridViewLookup.FocusedRowHandle = DevExpress.Data.BaseListSourceDataController.FilterRow;
            GridViewLookup.Focus();
        }

        private void GridViewLookup_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (!_ignoreLeaveRow) {
                GridView view = (GridView)sender;
                object row = view.GetRow(e.FocusedRowHandle);
                if (row != null && row.GetType() != typeof(DevExpress.Data.NotLoadedObject)) {
                    ReadonlyThreadSafeProxyForObjectFromAnotherThread proxy = (ReadonlyThreadSafeProxyForObjectFromAnotherThread)view.GetRow(e.FocusedRowHandle);
                    AGY record = (AGY)proxy.OriginalRow;
                    BindingSource.DataSource = _context.AGY.Where(c => c.NO == record.NO);
                }
                else {
                    ClearBindings();
                }
            }
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