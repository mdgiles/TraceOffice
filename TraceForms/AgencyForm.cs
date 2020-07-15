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
using DevExpress.Data.Filtering;
using AuthorizeNet.APICore;
using System.Diagnostics;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraEditors.Popup;
using DevExpress.Utils.Win;

namespace TraceForms
{
    public partial class AgencyForm : DevExpress.XtraEditors.XtraForm
    {
        List<string> _profilesToDelete;
        List<CodeName> _reportTypes;
        public List<IComprod2> myCommRecs;
        public List<IComprod2> myCommRecsAgy;
        public List<ICommLevel> myCommLvl;
        const string _paymentProfileError = "Customer payment information could not be retrieved from profile manager";
        ICoreSys _sys;
        public AuthorizeNet.CustomerGateway _custGateway;
        bool _detailsModified = false;
        bool _contactsModified = false;
        FlextourEntities _context;
        AGY _selectedRecord, _previousRecord;
        Timer _actionConfirmation;
        bool _ignoreLeaveRow = false, _ignorePositionChange = false;

        private const string _cardRegex = "^(?:(?<Visa>4\\d{3})|(?<JCB>2131|1800|3088|35\\d{3}\\d{11})|(?<MasterCard>5[1-5]\\d{2})|(?<Discover>6011)|(?<DinersClub>(?:3[68]\\d{2})|(?:30[0-5]\\d))|(?<Amex>3[47]\\d{2}))([ -]?)(?(DinersClub)(?:\\d{6}\\1\\d{4})|(?(Amex)(?:\\d{6}\\1\\d{5})|(?:\\d{4}\\1\\d{4}\\1\\d{4})))$";

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

        public AgencyForm(ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
            LoadLookups();
            _sys = sys;
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
            AgencyPaymentProfile.MaxLengths = Connection.GetMaxLengths(typeof(AgencyPaymentProfile).GetType().Name);
            _context = new FlextourEntities(sys.Settings.EFConnectionString);
            _sys = sys;
            bool allowElecPayments = sys.Settings.AllowElectronicPayments && !string.IsNullOrWhiteSpace(sys.Settings.PaymentProcessorLoginId) && 
                !string.IsNullOrWhiteSpace(sys.Settings.PaymentProcessorTxKey);
            if (allowElecPayments) {
                XtraTabPagePayments.PageVisible = true;
                try {
                    _custGateway = new AuthorizeNet.CustomerGateway(sys.Settings.PaymentProcessorLoginId, sys.Settings.PaymentProcessorTxKey, 
                        sys.Settings.PaymentProcessorTestMode);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                XtraTabPagePayments.PageVisible = false;

        }

        private void LoadLookups()
        {
            //loadDirectory();
            myCommRecsAgy = (from rec in _context.COMPROD2
                             where (rec.TYPE == "AGY") && (rec.Inactive == false) && ((rec.START_DATE <= DateTime.Now) && (rec.END_DATE >= DateTime.Now))
                             select rec).ToList<IComprod2>();
            myCommLvl = (from rec in _context.CommLevel select rec).ToList<ICommLevel>();

            repositoryItemImageComboBoxAccountType.AddEnum(typeof(AgencyPaymentProfile.bankAccountTypeEnum));

            foreach (COMPROD2 rec in myCommRecsAgy) {
                rec.SetProductRulePosition(myCommLvl);
            }
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = string.Empty };
            RepositoryItemImageComboBoxEditAgentDelegate.Items.Add(loadBlank);

            var dept = from deptRec in _context.Dept orderby deptRec.Code ascending select new { deptRec.Code, deptRec.Desc };

            foreach (var result in dept) {
                repositoryItemComboBoxDept.Items.Add(result.Code + " " + result.Desc);
            }
            SetReadOnly(true);

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

            _reportTypes = new List<CodeName>();
            _reportTypes.AddRange(_context.RPTTYPE
                .Where(r => r.RecipientType == "Agy")
                .OrderBy(o => o.CODE)
                .Select(s => new CodeName() { Code = s.CODE, Name = s.DESC }).ToList());
            RepositoryItemCheckedComboBoxEditReportType.DataSource = _reportTypes;
            RepositoryItemCheckedComboBoxEditReportType.ValueMember = "Code";
            RepositoryItemCheckedComboBoxEditReportType.DisplayMember = "Name";

            BindingSourceUserFields.DataSource = _context.USERFIELDS
                .Where(u => (u.VISIBLE ?? false) && u.LINK_TABLE == "AGY")
                .OrderBy(u => u.POSITION);
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

        private void LoadDefaultPaymentProfileList()
        {
            ImageComboBoxEditDefaultPmtProfileID.Properties.Items.Clear();
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = string.Empty, Value = string.Empty };
            ImageComboBoxEditDefaultPmtProfileID.Properties.Items.Add(loadBlank);
            foreach (var profile in _selectedRecord.AgencyPaymentProfile) {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = profile.PaymentProfileDesc, Value = profile.PaymentProfileID };
                ImageComboBoxEditDefaultPmtProfileID.Properties.Items.Add(load);
            }
        }

        private void GridViewCustom_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column == GridColumnCustomValue && _selectedRecord != null) {
                string fieldName = GridViewCustom.GetRowCellValue(e.ListSourceRowIndex, "LINK_COLUMN").ToString();
                if (e.IsGetData) {
                    e.Value = _selectedRecord.GetPropertyValue(fieldName);
                }
                else if (e.IsSetData) {
                    //FinalizeBindings();
                    _selectedRecord.SetPropertyValue(fieldName, e.Value);
                }
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
            using OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open Image";
            dlg.InitialDirectory = _sys.Settings.ImagesRoot;
            if (dlg.ShowDialog() == DialogResult.OK) {
                if (dlg.FileName.ToLower().IndexOf(_sys.Settings.ImagesRoot.ToLower()) != -1)
                    ButtonEditLogoPath.Text = dlg.FileName.Substring(_sys.Settings.ImagesRoot.Length);
                else
                    ButtonEditLogoPath.Text = dlg.FileName;
            }            
        }

        private void ButtonEditLogoPath_TextChanged(object sender, EventArgs e)
        {
            PictureEditPreview.Image = null;
            try {

                using (var stream = new MemoryStream(File.ReadAllBytes(_sys.Settings.ImagesRoot + ButtonEditLogoPath.Text))) {
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

        private void ButtonAddContact_Click(object sender, EventArgs e)
        {
            CONTACT contact = new CONTACT() {
                LINK_TABLE = "AGY",
                RECTYPE = "AGYCONTACT",
                LINK_VALUE = TextEditCode.Text
            };
            BindingSourceContact.Add(contact);
        }

        private void ButtonDeleteContact_Click(object sender, EventArgs e)
        {
            int handle = GridViewContacts.FocusedRowHandle;
            GridViewContacts.DeleteRow(handle);
            BindingSource.EndEdit();
            _context.SaveChanges();
        }

        private void GridViewContacts_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "Reports") {
                CONTACT conRec = (CONTACT)e.Row;
                if (e.IsGetData) {
                    var selected = string.Join(",", _reportTypes.Where(r => conRec.RptContact.Any(rc => rc.RptType == r.Code)).Select(r => r.Code));
                    e.Value = selected;
                }
                if (e.IsSetData) {
                    //The CSV that comes from DevExpress CheckedComboBoxEdit is actually "comma space" delimited
                    //so don't forget to Trim each member
                    var results = e.Value.ToString().Split(',');
                    List<RptContact> toKeep = new List<RptContact>();
                    foreach (var result in results) {
                        var rec = conRec.RptContact.SingleOrDefault(c => c.RptType == result.Trim());
                        if (rec == null) {
                            rec = new RptContact() {
                                Code = TextEditCode.Text,
                                RptType = result.Trim()
                            };
                            conRec.RptContact.Add(rec);
                            _contactsModified = true;
                        }
                        toKeep.Add(rec);
                    }
                    var toRemove = conRec.RptContact.Except(toKeep).ToList();
                    foreach (var remove in toRemove) {
                        conRec.RptContact.Remove(remove);
                        _context.RptContact.DeleteObject(remove);
                        _contactsModified = true;
                    }
                }
            }
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


            using FlextourEntities context2 = new FlextourEntities(Connection.EFConnectionString);
            IList<FlexCommissions.Commission> commQuery1 = new List<FlexCommissions.Commission>();
            IList<FlexCommissions.Commission> commQuery2 = new List<FlexCommissions.Commission>();
            commQuery2 = FlexCommissions.Commissions.GetAgencyCommissions(context2, "C", myCommRecsAgy, myCommLvl, Agency, TheDate, null, null, Source);
            IList<FlexCommissions.Commission> mergedList = (commQuery1.Union(commQuery2)).ToList();
            GridControlCommissions.DataSource = mergedList;
            commQuery2 = FlexCommissions.Commissions.GetAgencyCommissions(context2, "M", myCommRecsAgy, myCommLvl, Agency, TheDate, null, null, Source);
            mergedList = (commQuery1.Union(commQuery2)).ToList();
            GridControlMarkups.DataSource = mergedList;
        }

        private void CheckEditRemoteVouchers_CheckStateChanged(object sender, EventArgs e)
        {
            if (CheckEditRemoteVouchers.Checked) {
                CheckedComboBoxEditVouchTypes.Enabled = true;
            } else {
                CheckedComboBoxEditVouchTypes.Enabled = false;
            }
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

        private void ChangePaymentProfileButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedRecord.PaymentProcessorCustProfileId) || PanelControlCustomerProfileStatus.Visible) {
                CreateCustomerProfile();
            }
            else {
                if (LabelCustomerProfileStatus.Text == _paymentProfileError) {
                    CreateCustomerProfile();
                }
                AuthorizeNet.Customer cust = new AuthorizeNet.Customer() {
                    ProfileID = LabelPaymentProcessorCustProfileId.Text,
                    Email = TextEditCustomerProfileEmail.Text,
                    ID = string.Empty
                };
                _custGateway.UpdateCustomer(cust);
            }
        }

        private void CreateCustomerProfile()
        {
            try {
                var currentCust = _custGateway.CreateCustomer(TextEditCustomerProfileEmail.Text, TextEditName.Text);
                PanelControlCustomerProfileStatus.Visible = string.IsNullOrEmpty(currentCust.ProfileID);
                if (string.IsNullOrEmpty(currentCust.ProfileID)) {
                    LabelCustomerProfileStatus.Text = "Creating customer profile failed";
                }
                LabelPaymentProcessorCustProfileId.Text = currentCust.ProfileID;
                _selectedRecord.PaymentProcessorCustProfileId = currentCust.ProfileID;
                ShowCustomerProfileStatus(false, null);
            }
            catch (Exception ex) {//Authorize.Net does not give us a way to find what the existing ID is if a create fails because of a duplicate ID,
                string error = "E00039 - A duplicate record with ID ";//so in order to obtain it, we must manually extract it from the error message.
                if (ex.Message.StartsWith(error)) {
                    string message = ex.Message.Substring(error.Length, ex.Message.Length - error.Length);
                    string[] parts = message.Split(' ');
                    _selectedRecord.PaymentProcessorCustProfileId = parts[0];
                    LabelPaymentProcessorCustProfileId.Text = parts[0];
                    LoadPaymentProfiles();
                    SetBankAndCreditCardState(true);
                }
                else {
                    ShowCustomerProfileStatus(true, ex.Message);
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            //delete
            DialogResult result = DisplayHelper.QuestionYesNo(this, "Are you sure you want to delete the customer profile? This cannot be undone.");
            if (result == DialogResult.Yes) {
                _custGateway.DeleteCustomer(LabelPaymentProcessorCustProfileId.Text);
                BindingSourceAgencyPaymentProfileCredit.Clear();
                BindingSourceAgencyPaymentProfileBank.Clear();
                LabelPaymentProcessorCustProfileId.Text = string.Empty;
                TextEditCustomerProfileEmail.Text = string.Empty;
            }
        }

        void BindCreditPaymentProfiles()
        {
            GridControlCreditProfiles.DataSource = BindingSourceAgencyPaymentProfileCredit;
            GridControlCreditProfiles.RefreshDataSource();
        }

        private void ButtonAddCredit_Click(object sender, EventArgs e)
        {
            AgencyPaymentProfile pmtProfile = new AgencyPaymentProfile {
                Agy_No = TextEditCode.Text ?? string.Empty,
                IsCreditCard = true
            };
            _selectedRecord.AgencyPaymentProfile.Add(pmtProfile);
            BindCreditPaymentProfiles();
            GridViewCreditProfiles.FocusedRowHandle = BindingSourceAgencyPaymentProfileCredit.Count - 1;
        }

        void BindPaymentProfiles()
        {
            GridControlBankProfiles.DataSource = BindingSourceAgencyPaymentProfileCredit;
            GridControlBankProfiles.RefreshDataSource();
            GridControlCreditProfiles.DataSource = BindingSourceAgencyPaymentProfileCredit;
            GridControlCreditProfiles.RefreshDataSource();
        }

        void BindBankPaymentProfiles()
        {
            GridControlBankProfiles.DataSource = BindingSourceAgencyPaymentProfileCredit;
            GridControlBankProfiles.RefreshDataSource();
        }

        private void ButtonAddBank_Click(object sender, EventArgs e)
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

        private void ButtonDeleteCredit_Click(object sender, EventArgs e)
        {
            if (GridViewCreditProfiles.FocusedRowHandle >= 0) {
                AgencyPaymentProfile rec = (AgencyPaymentProfile)GridViewCreditProfiles.GetFocusedRow();
                if (!string.IsNullOrWhiteSpace(rec.PaymentProfileID)) {
                    _profilesToDelete.Add(rec.PaymentProfileID);
                }
                BindingSourceAgencyPaymentProfileCredit.Remove(rec);
            }
        }

        private void ButtonDeleteBank_Click(object sender, EventArgs e)
        {
            if (GridViewBankProfiles.FocusedRowHandle >= 0) {
                AgencyPaymentProfile rec = (AgencyPaymentProfile)GridViewBankProfiles.GetFocusedRow();
                if (!string.IsNullOrWhiteSpace(rec.PaymentProfileID)) {
                    _profilesToDelete.Add(rec.PaymentProfileID);
                }
                BindingSourceAgencyPaymentProfileBank.Remove(rec);
            }
        }

        private void GridViewPaymentProfiles_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void GridViewBankProfiles_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
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

        private void CheckEditRequireCVV2_Click(object sender, EventArgs e)
        {
            gridColCVV2.Visible = CheckEditRequireCVV2.Checked;
        }

        private void AgcyLogBindingSource_CurrentChanged(object sender, EventArgs e)
        {//move to custom row cell edit event for the agcy log grid
            if (BindingSourceAgcyLog.Current != null && _selectedRecord != null) {
                if (_selectedRecord.NO == _sys.Settings.DefaultAgency) {
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

            GridViewCreditProfiles.CloseEditor();
            GridViewCreditProfiles.UpdateCurrentRow();
            for (int rowCtr = 0; rowCtr < GridViewCreditProfiles.DataRowCount; rowCtr++) {
                AgencyPaymentProfile profile = (AgencyPaymentProfile)GridViewCreditProfiles.GetRow(rowCtr);
                profile.Agy_No = TextEditCode.Text ?? string.Empty;
            }
            BindingSourceAgencyPaymentProfileCredit.EndEdit();

            GridViewBankProfiles.CloseEditor();
            GridViewBankProfiles.UpdateCurrentRow();
            for (int rowCtr = 0; rowCtr < GridViewBankProfiles.DataRowCount; rowCtr++) {
                AgencyPaymentProfile profile = (AgencyPaymentProfile)GridViewBankProfiles.GetRow(rowCtr);
                profile.Agy_No = TextEditCode.Text ?? string.Empty;
            }
            BindingSourceAgencyPaymentProfileBank.EndEdit();
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
                LoadAndBindPaymentTransactions();
                GridViewCustom.LayoutChanged();     //forces the CustomUnboundColumnData event to fire to display the custom fields
                SetReadOnly(false);
                SetReadOnlyKeyFields(true);
                BarButtonItemDelete.Enabled = true;
                BarButtonItemSave.Enabled = true;
            }
            GridViewAgcyLog.Columns["Agcylog_Agent_Delegate"].Visible = (TextEditCode.Text == _sys.Settings.DefaultAgency);
            GridViewAgcyLog.Columns["SUPVR_FLG"].Visible = (TextEditCode.Text == _sys.Settings.DefaultAgency);
            ErrorProvider.Clear();
        }

        private void LoadAndBindContacts()
        {
            if (!string.IsNullOrEmpty(_selectedRecord.NO)) {
                BindingSourceContact.DataSource = _context.CONTACT.Where(c => c.LINK_VALUE == _selectedRecord.NO
                    && c.RECTYPE == "AGYCONTACT" && c.LINK_TABLE == "AGY").Include(c => c.RptContact);
            }
        }

        void LoadAndBindPaymentTransactions()
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

            LoadPaymentProfiles();

            //Don't do any LINQ operations on the entitycollection, just bind directly to it, otherwise
            //it appears to bind as unassociated with the context and you have to manually add/delete
            //rows from the bindingsource to the context (but changes work fine)
            BindingSourceAgencyPaymentProfileCredit.DataSource = _selectedRecord.AgencyPaymentProfile;
            BindPaymentProfiles();

            _profilesToDelete = new List<string>();
        }

        private void LoadPaymentProfiles()
        {
            if (!string.IsNullOrEmpty(_selectedRecord.PaymentProcessorCustProfileId)) {
                try {
                    var cust = _custGateway.GetCustomer(_selectedRecord.PaymentProcessorCustProfileId);
                    foreach (AuthorizeNet.PaymentProfile profile in cust.PaymentProfiles) {
                        var AgyPmtProfile = _selectedRecord.AgencyPaymentProfile.SingleOrDefault(c => c.PaymentProfileID == profile.ProfileID);
                        if (AgyPmtProfile != null) {
                            AgyPmtProfile.BankAccountNumber = profile.BankAccountNumber;
                            AgyPmtProfile.BankName = profile.BankName;
                            AgyPmtProfile.BankNameOnAccount = profile.BankNameOnAccount;
                            AgyPmtProfile.BankRoutingNumber = profile.BankRoutingNumber;
                            AgyPmtProfile.AccountType = (AgencyPaymentProfile.bankAccountTypeEnum)(int)profile.AccountType;
                            AgyPmtProfile.CardNumber = profile.CardNumber;
                            AgyPmtProfile.CardType = profile.CardType;
                            AgyPmtProfile.CardCode = profile.CardCode;
                            if (profile.BillingAddress != null) {
                                AgyPmtProfile.BillingAddressCity = profile.BillingAddress.City;
                                AgyPmtProfile.BillingAddressCompany = profile.BillingAddress.Company;
                                AgyPmtProfile.BillingAddressCountry = profile.BillingAddress.Country;
                                AgyPmtProfile.BillingAddressFirst = profile.BillingAddress.First;
                                AgyPmtProfile.BillingAddressLast = profile.BillingAddress.Last;
                                AgyPmtProfile.BillingAddressPhone = profile.BillingAddress.Phone;
                                AgyPmtProfile.BillingAddressState = profile.BillingAddress.State;
                                AgyPmtProfile.BillingAddressStreet = profile.BillingAddress.Street;
                                AgyPmtProfile.BillingAddressZip = profile.BillingAddress.Zip;
                            }
                        }
                    }
                    _selectedRecord.PaymentProfileFailedToLoad = false;
                    ShowCustomerProfileStatus(false, null);
                    LoadDefaultPaymentProfileList();
                }
                catch {
                    _selectedRecord.PaymentProfileFailedToLoad = true;
                    ShowCustomerProfileStatus(true, _paymentProfileError);
                    SetBankAndCreditCardState(false);
                }
            }
        }

        private void ShowCustomerProfileStatus(bool isError, string error)
        {
            PanelControlCustomerProfileStatus.Visible = isError;
            LabelCustomerProfileStatus.Text = error;
            SimpleButtonRetry.Visible = isError;
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
            if (e.KeyData == Keys.Enter) {
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
                    if (!string.IsNullOrEmpty(_selectedRecord.PaymentProcessorCustProfileId)) {
                        var answer = DisplayHelper.QuestionYesNoCancel(this, "Do you wish to delete the customer payment profile and all associated payment methods? " +
                            " If you are unsure, please check with the accounting department.");
                        if (answer == DialogResult.Cancel)
                            return;
                        if (answer == DialogResult.Yes) {
                            _custGateway.DeleteCustomer(_selectedRecord.PaymentProcessorCustProfileId);
                        }
                    }

                    //ignoreLeaveRow and ignorePositionChange are set because when removing a record, the bindingsource_currentchanged 
                    //and gridview_beforeleaverow events will fire as the current record is removed out from under them.
                    //We do not want these events to perform their usual code of checking whether there are changes in the active
                    //record that should be saved before proceeding, because we know we have just deleted the active record.
                    _ignoreLeaveRow = true;
                    _ignorePositionChange = true;
                    RemoveRecord();
                    BindingSourceContact.Clear();
                    BindingSourceDetail.Clear();
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
                    GridViewLookup.FocusedRowHandle = DevExpress.Data.BaseListSourceDataController.FilterRow;
                    GridControlLookup.Focus();
                    ShowActionConfirmation("Record Deleted");
                }
            }
            catch (Exception ex) {
                DisplayHelper.DisplayError(this, ex);
                _ignoreLeaveRow = false;
                _ignorePositionChange = false;
                RefreshRecord();        //pull it back from db because that is its current state
                //We must also Load and rebind the related entities from the db because context.Refresh doesn't do that
                SetBindings();
            }
        }

        private void GridViewLookup_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            //If the user selects a row, edits, then selects the auto-filter row, then selects a different row,
            //this event will fire for the auto-filter row, so we cannot ignore it because there is still a record
            //that may need to be saved. 
            if (!_ignoreLeaveRow && IsModified(_selectedRecord)) {
                e.Allow = SaveRecord(true);
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
            GridViewCustom.LayoutChanged();     //forces the CustomUnboundColumnData event to fire to display the custom fields
            _ignoreLeaveRow = false;
            _ignorePositionChange = false;
        }

        private void ButtonAddMembership_Click(object sender, EventArgs e)
        {
            DETAIL resource = new DETAIL() {
                LINK_TABLE = "AGY",
                RECTYPE = "AGYCLASS",
                LINK_VALUE = _selectedRecord.NO ?? string.Empty
            };
            BindingSourceDetail.Add(resource);
        }

        private void ButtonDeleteMembership_Click(object sender, EventArgs e)
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
                        //If we prompted then it's because the user is changing the selected record so we don't need
                        //to keep track of the previously selected record
                        _previousRecord = null;
                    }
                    else {
                        //If we didn't prompt then the user has clicked the Save button where the expectation is that
                        //the currently selected row will remain selected.  However EntityInstantFeebackSource does not have
                        //a way to refresh a single record and refreshing the data source causes the focused row to be reset
                        //back to the top row.  Therefore we store the value of the previous selection and set the row focus
                        //back in GridView AsyncCompleted.  This means there will be a flash of the incorrect top row being
                        //displayed before being set back to the previously selected row. DevExpress have no way around this.
                        _previousRecord = _selectedRecord;
                    }
                    if (!ValidateAll())
                        return false;

                    if (!SavePaymentProfiles()) {
                        return false;
                    }

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

        private void DisplayCrash(string message)
        {
            BindingSource.EndEdit();
            ErrorProvider.SetError(TextEditCode, message);
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
            ErrorProvider.Clear();
            return true;
        }

        public bool SavePaymentProfiles()
        {
            if (GridControlBankProfiles.Enabled && GridControlCreditProfiles.Enabled) {
                AuthorizeNet.APICore.customerPaymentProfileMaskedType api = new AuthorizeNet.APICore.customerPaymentProfileMaskedType();
                foreach (AgencyPaymentProfile AgyPmtProfile in _selectedRecord.AgencyPaymentProfile) {
                    if (string.IsNullOrEmpty(AgyPmtProfile.PaymentProfileID)) {
                        if (AgyPmtProfile.IsCreditCard) {
                            int expMonth = (int)AgyPmtProfile.ExpirationMonth;
                            int expYear = (int)AgyPmtProfile.ExpirationYear;
                            AgyPmtProfile.PaymentProfileID = _custGateway.AddCreditCard(_selectedRecord.PaymentProcessorCustProfileId, AgyPmtProfile.CardNumber, expMonth, expYear);
                        }
                        else {
                            var billingAddr = CreateAndPopulateBillingAddress(AgyPmtProfile);
                            var accntType = (AuthorizeNet.APICore.bankAccountTypeEnum)AgyPmtProfile.AccountType;
                            AgyPmtProfile.PaymentProfileID = _custGateway.AddBankAccount(_selectedRecord.PaymentProcessorCustProfileId, AgyPmtProfile.BankNameOnAccount, AgyPmtProfile.BankAccountNumber,
                                AgyPmtProfile.BankRoutingNumber, AgyPmtProfile.BankName, accntType, false, billingAddr);
                        }
                    }
                    else {
                        var profile = new AuthorizeNet.PaymentProfile(api) {
                            ProfileID = AgyPmtProfile.PaymentProfileID,
                        };
                        if (AgyPmtProfile.IsCreditCard) {
                            profile.CardType = AgyPmtProfile.CardType;
                            profile.CardCode = AgyPmtProfile.CardCode;
                            profile.CardExpiration = AgyPmtProfile.CardExpiration;
                        }
                        else {
                            profile.BankAccountNumber = AgyPmtProfile.BankAccountNumber;
                            profile.BankName = AgyPmtProfile.BankName;
                            profile.BankNameOnAccount = AgyPmtProfile.BankNameOnAccount;
                            profile.BankRoutingNumber = AgyPmtProfile.BankRoutingNumber;
                            profile.AccountType = (AuthorizeNet.APICore.bankAccountTypeEnum)AgyPmtProfile.AccountType;
                            profile.BillingAddress = CreateAndPopulateBillingAddress(AgyPmtProfile);
                        }
                        _custGateway.UpdatePaymentProfile(_selectedRecord.PaymentProcessorCustProfileId, profile);
                    }
                    if (AgyPmtProfile.IsCreditCard) {
                        AgyPmtProfile.LastDigits = AgyPmtProfile.CardNumber.GetLast(4);
                        AgyPmtProfile.PaymentProvider = (GetCardTypeFromNumber(AgyPmtProfile.CardNumber)).ToString();
                    }
                    else {
                        AgyPmtProfile.LastDigits = AgyPmtProfile.BankAccountNumber.GetLast(4);
                        AgyPmtProfile.PaymentProvider = AgyPmtProfile.BankName;
                    }
                }
                //Here we delete everything in the list of profiles to delete.  Authorize.Net does not return an indication of whether or not the delete succeeded,
                //so we just do nothing about it either way.
                foreach (string paymentID in _profilesToDelete) {
                    _custGateway.DeletePaymentProfile(_selectedRecord.PaymentProcessorCustProfileId, paymentID);
                }
                _profilesToDelete.Clear();
            }
            return true;
        }

        private AuthorizeNet.Address CreateAndPopulateBillingAddress(AgencyPaymentProfile agyPmtProfile)
        {
            AuthorizeNet.Address addr = new AuthorizeNet.Address() {
                City = agyPmtProfile.BillingAddressCity,
                Company = agyPmtProfile.BillingAddressCompany,
                Country = agyPmtProfile.BillingAddressCountry,
                First = agyPmtProfile.BillingAddressFirst,
                Last = agyPmtProfile.BillingAddressLast,
                Phone = agyPmtProfile.BillingAddressPhone,
                State = agyPmtProfile.BillingAddressState,
                Street = agyPmtProfile.BillingAddressStreet,
                Zip = agyPmtProfile.BillingAddressZip
            };
            return addr;
        }

        private void ShowMainControlErrors()
        {
            //The error indicators inside the grids are handled by binding, but errors on the main form must
            //be set manually
            var errors = _selectedRecord.Errors;
            if (errors != null) {
                if (errors.ContainsKey("CRASH")) {
                    var message = errors["CRASH"];
                    DisplayCrash(message);
                    return;
                }
            }
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
            SetErrorInfo(_selectedRecord.ValidateDetails, GridControlMemberships);
            _selectedRecord.Contacts = BindingSourceContact.List.Cast<CONTACT>().ToList();
            SetErrorInfo(_selectedRecord.ValidateContacts, GridControlMemberships);
            SetErrorInfo(_selectedRecord.ValidateAgcyLog, GridControlAgcyLog);
            SetErrorInfo(_selectedRecord.ValidateAgencyCurrencies, GridControlAgencyCurrency);
            if (GridControlCreditProfiles.Enabled && GridControlBankProfiles.Enabled) {
                SetErrorInfo(_selectedRecord.ValidateAgencyPaymentProfilesCredit, GridControlCreditProfiles);
                SetErrorInfo(_selectedRecord.ValidateAgencyPaymentProfilesBank, GridControlBankProfiles);
            }
            SetErrorInfo(_selectedRecord.ValidatePaymentEmail, TextEditCustomerProfileEmail);
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
                || record.AGCYLOG.IsModified(_context)
                || record.AgencyPaymentProfile.IsModified(_context);
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

        private void ButtonAddAgent_Click(object sender, EventArgs e)
        {
            AGCYLOG agcylog = new AGCYLOG {
                AGENCY = TextEditCode.Text ?? string.Empty
            };
            _selectedRecord.AGCYLOG.Add(agcylog);
            BindAgencyLogs();
            GridViewAgcyLog.FocusedRowHandle = BindingSourceAgcyLog.Count - 1;
        }

        private void ButtonDeleteAgent_Click(object sender, EventArgs e)
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
            if (RadioGroupPaymentDue.SelectedIndex == 1) {
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

        private void CheckEditAllowElectronicPayment_EditValueChanged(object sender, EventArgs e)
        {
            if (CheckEditAllowElectronicPayment.Checked) {
                SetCustomerPaymentProfileState(true);
                if (!string.IsNullOrWhiteSpace(LabelPaymentProcessorCustProfileId.Text) && string.IsNullOrEmpty(LabelCustomerProfileStatus.Text)) {
                    SetElectronicPaymentState(true);
                }
            } else {
                SetElectronicPaymentState(false);
            }
        }

        private void SetCustomerPaymentProfileState(bool enabled)
        {
            CheckEditRequireCVV2.Enabled = enabled;
            TextEditCustomerProfileEmail.Enabled = enabled;
            ChangePaymentProfileButton.Enabled = enabled;
        }

        public void SetElectronicPaymentState(bool enabled)
        {
            SetCustomerPaymentProfileState(enabled);
            SetBankAndCreditCardState(enabled);
            SimpleButtonDelete.Enabled = enabled;
        }

        private void SetBankAndCreditCardState(bool enabled)
        {
            GridControlCreditProfiles.Enabled = enabled;
            GridControlBankProfiles.Enabled = enabled;
            ButtonAddCredit.Enabled = enabled;
            ButtonDeleteCredit.Enabled = enabled;
            ButtonAddBank.Enabled = enabled;
            ButtonDeleteBank.Enabled = enabled;
            ImageComboBoxEditDefaultPmtProfileID.Enabled = enabled;
        }

        private void LabelPaymentProcessorCustProfileId_TextChanged(object sender, EventArgs e)
        {
            bool hasProfile = !string.IsNullOrEmpty(LabelPaymentProcessorCustProfileId.Text) && !PanelControlCustomerProfileStatus.Visible;
            SimpleButtonDelete.Enabled = hasProfile;
            SetBankAndCreditCardState(hasProfile);
        }

        private void CheckEditRequireCVV2_EditValueChanged(object sender, EventArgs e)
        {
            ChangePaymentProfileButton.Enabled = true;
            gridColCVV2.Visible = CheckEditRequireCVV2.Checked;
        }

        private void GridViewContacts_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            _contactsModified = true;
        }

        private void GridViewAgcyLog_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column == colAgcylog_Agent_Delegate) {
                if (_selectedRecord.NO == _sys.Settings.DefaultAgency) {
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
                Agent = _sys.User.Name,
                PmtCode_PmtCode = "D"   //D for deposit - TODO: move this somewhere configurable
            };
            _selectedRecord.PaymentTransaction.Add(paymentTransaction);
            BindPaymentTransactions();
            GridViewDeposits.FocusedRowHandle = GridViewDeposits.RowCount - 1;
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

        private void GridViewCreditProfiles_SubstituteFilter(object sender, DevExpress.Data.SubstituteFilterEventArgs e)
        {
            e.Filter &= CriteriaOperator.Parse("[IsCreditCard] == True");
        }
        
        private void GridViewBankProfiles_SubstituteFilter(object sender, DevExpress.Data.SubstituteFilterEventArgs e)
        {
            e.Filter &= CriteriaOperator.Parse("[IsCreditCard] == False");
        }

        private void SimpleButtonRetry_Click(object sender, EventArgs e)
        {
            LoadAndBindPaymentProfiles();
        }

        private void GridViewCreditProfiles_CustomRowFilter(object sender, RowFilterEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            bool.TryParse(view.GetListSourceRowCellValue(e.ListSourceRow, "IsCreditCard").ToString(), out bool iscredit);
            e.Visible = iscredit;
        }

        private void GridViewBankProfiles_CustomRowFilter(object sender, RowFilterEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            bool.TryParse(view.GetListSourceRowCellValue(e.ListSourceRow, "IsCreditCard").ToString(), out bool iscredit);
            e.Visible = !iscredit;
        }

        private void GridViewLookup_AsyncCompleted(object sender, EventArgs e)
        {
            if (_previousRecord != null && _selectedRecord != null && !_ignoreLeaveRow) {
                GridView view = (GridView)sender;
                int rowHandle = view.LocateByValue("NO", _previousRecord.NO, OnRowSearchComplete);
                if (rowHandle != DevExpress.Data.DataController.OperationInProgress) {
                    SetFocusedRow(GridViewLookup, rowHandle);
                }
            }
        }

        void OnRowSearchComplete(object rh)
        {
            int rowHandle = (int)rh;
            if (GridViewLookup.IsValidRowHandle(rowHandle)) {
                SetFocusedRow(GridViewLookup, rowHandle);
            }
        }

        private void TextEditCustomerProfileEmail_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidatePaymentEmail, sender);
        }

        private void GridViewCreditProfiles_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            for(int i = DateTime.Now.Year; i <= DateTime.Now.Year + 10; i++) {
                RepositoryItemComboBoxExpYear.Items.Add(i);
            }
        }

        private void GridViewDeposits_CustomRowFilter(object sender, RowFilterEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            string pmtCode = view.GetListSourceRowCellValue(e.ListSourceRow, "PmtCode_PmtCode").ToStringEmptyIfNull();
            e.Visible = (pmtCode == "D");     //D for deposit - TODO: move this somewhere configurable
        }

        private void GridViewDeposits_SubstituteFilter(object sender, DevExpress.Data.SubstituteFilterEventArgs e)
        {
            e.Filter &= CriteriaOperator.Parse("[PmtCode_PmtCode] == 'D'");
        }

        private void GridControlCreditProfiles_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateAgencyPaymentProfilesCredit, sender);
        }

        private void GridControlBankProfiles_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateAgencyPaymentProfilesBank, sender);
        }

        void SetFocusedRow(GridView view, int rowHandle)
        {
            //precaution to make sure that any subsequent row changes don't try to force the selected
            //row back to the previously selected one again
            _previousRecord = null;     
            view.FocusedRowHandle = rowHandle;
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
}