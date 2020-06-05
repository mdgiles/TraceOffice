using FlexModel;
namespace TraceForms
{
    partial class AgencyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label eMAILLabel;
            System.Windows.Forms.Label fAX_NUMLabel;
            System.Windows.Forms.Label pHONELabel;
            System.Windows.Forms.Label mAILFAX_FLGLabel;
            System.Windows.Forms.Label aRVBKDAYSLabel;
            System.Windows.Forms.Label rELLabel;
            System.Windows.Forms.Label rETNOTAVALHTLSLabel;
            System.Windows.Forms.Label rETREQHTLSLabel;
            System.Windows.Forms.Label sUB_ALLOCLabel;
            System.Windows.Forms.Label vOUCHER_DAYS_PRIORLabel;
            System.Windows.Forms.Label vOUCHER_REPRINTSLabel;
            System.Windows.Forms.Label rEMOTE_VOUCHERSLabel;
            System.Windows.Forms.Label aLLOW_ATTACHMENTSLabel;
            System.Windows.Forms.Label cONF_PRCLabel;
            System.Windows.Forms.Label eDITHTLSLabel;
            System.Windows.Forms.Label eDITHDRSLabel;
            System.Windows.Forms.Label cOMMLabel;
            System.Windows.Forms.Label cXLGRACELabel;
            System.Windows.Forms.Label oPT_DAYSLabel;
            System.Windows.Forms.Label aPLabel;
            System.Windows.Forms.Label dEF_LANGLabel;
            System.Windows.Forms.Label tYPLabel;
            System.Windows.Forms.Label nAMELabel;
            System.Windows.Forms.Label nOLabel;
            System.Windows.Forms.Label aRLabel;
            System.Windows.Forms.Label wEBSITELabel;
            System.Windows.Forms.Label cXL1_NTSPRIORLabel;
            System.Windows.Forms.Label cXL1_PCTLabel;
            System.Windows.Forms.Label cXL2_FLATLabel;
            System.Windows.Forms.Label label21;
            System.Windows.Forms.Label label22;
            System.Windows.Forms.Label label23;
            System.Windows.Forms.Label cHG1_NTSPRIORLabel;
            System.Windows.Forms.Label cHG1_PCTLabel;
            System.Windows.Forms.Label cHG1_FLATLabel;
            System.Windows.Forms.Label label27;
            System.Windows.Forms.Label label28;
            System.Windows.Forms.Label label29;
            System.Windows.Forms.Label pARENTLabel;
            System.Windows.Forms.Label cOUNTRYLabel;
            System.Windows.Forms.Label zIPLabel;
            System.Windows.Forms.Label sTATELabel;
            System.Windows.Forms.Label cITYLabel;
            System.Windows.Forms.Label aDDR1Label;
            System.Windows.Forms.Label tourfaxEmailFormatLabel;
            System.Windows.Forms.Label lOGO_PATHLabel;
            System.Windows.Forms.Label vOUCH_TYPESLabel;
            System.Windows.Forms.Label label18;
            System.Windows.Forms.Label label19;
            System.Windows.Forms.Label label20;
            System.Windows.Forms.Label label24;
            System.Windows.Forms.Label label25;
            System.Windows.Forms.Label label26;
            System.Windows.Forms.Label LabelSize;
            System.Windows.Forms.Label LabelCreditLimit;
            System.Windows.Forms.Label LabelCreditLimitRemainingWarningPct;
            System.Windows.Forms.Label LabelCreditUnlimited;
            System.Windows.Forms.Label paymentProcessorCustProfileEmailLabel;
            System.Windows.Forms.Label paymentProcessorCustProfileIdLabel;
            System.Windows.Forms.Label label30;
            System.Windows.Forms.Label LabelFundBalance;
            System.Windows.Forms.Label LabelAmountPaid;
            System.Windows.Forms.Label LabelCreditBalance;
            System.Windows.Forms.Label label35;
            System.Windows.Forms.Label sRT3Label;
            System.Windows.Forms.Label sRT2Label;
            System.Windows.Forms.Label LabelPaymentDue;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgencyForm));
            this.LabelPaymentProfileStatus = new System.Windows.Forms.Label();
            this.LabelDate = new System.Windows.Forms.Label();
            this.LabelAgency = new System.Windows.Forms.Label();
            this.GridControlLookup = new DevExpress.XtraGrid.GridControl();
            this.EntityInstantFeedbackSource = new DevExpress.Data.Linq.EntityInstantFeedbackSource();
            this.GridViewLookup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLAST_UPD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUPD_INIT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTYP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colADDR1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colADDR2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colADDR3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPHONE1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCONSORT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCOMM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTATE1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSRT2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSRT3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDEF_LANG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colREL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAX_NUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPMT_DAYS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colACTIVE_FLG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIMMED_FLG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colINV_FMT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPRIOR_DAYS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLAST_INV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDAYS_SPACE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSVCDTE_FLG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAX_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOPT_DAYS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSUB_ALLOC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAILFAX_FLG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colREM_CHG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCONF_PRC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEMAIL1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCXL1_NTSPRIOR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCXL1_PCT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCXL1_FLAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCHG1_NTSPRIOR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCHG1_PCT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCHG1_FLAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCXL2_NTSPRIOR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCXL2_PCT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCXL2_FLAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCHG2_NTSPRIOR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCHG2_PCT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCHG2_FLAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCXL3_NTSPRIOR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCXL3_PCT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCXL3_FLAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCHG3_NTSPRIOR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCHG3_PCT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCHG3_FLAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCXLGRACE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colARVBKDAYS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRETREQHTLS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRETNOTAVALHTLS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEDITHTLS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEDITHDRS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSIMPLEAVAL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGMACCTNO1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colREMOTE_VOUCHERS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVOUCHER_DAYS_PRIOR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVOUCHER_REPRINTS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLOGO_PATH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCOUNTRY1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPARENT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCITY1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZIP1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWEBSITE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUSER_DEC11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUSER_DEC21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUSER_INT11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUSER_INT21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUSER_TXT11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUSER_TXT21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUSER_TXT31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUSER_TXT41 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUSER_DTE11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUSER_DTE21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVOUCH_TYPES = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colALLOW_ATTACHMENTS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDUE_DAY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLanguage_Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShowAllLanguages = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTourfaxEmailFormat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentProcessorCustProfileId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentProcessorCustProfileEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDefaultPaymentProfileId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreditLimit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreditLimitRemainingWarningPct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreditUnlimited = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRequireCVV2Number = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAGCYLOG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCOUNTRY11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLANGUAGE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLANGUAGE1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCOMPROD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCOMPROD2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCPRATES = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCXLFEE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOTEL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colINVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPRATES = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSVCRESTR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSYSFILE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSYSFILE1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCOMPROD21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colhrates2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colhrates3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHRATES = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentTransaction = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAgencyPaymentProfile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImagesRoot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDisplayName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CheckEditActiveFlg = new DevExpress.XtraEditors.CheckEdit();
            this.XtraTabControlAgency = new DevExpress.XtraTab.XtraTabControl();
            this.XtraTabPageLocation = new DevExpress.XtraTab.XtraTabPage();
            this.PanelControlLocationTab = new DevExpress.XtraEditors.PanelControl();
            this.TextEditCity = new DevExpress.XtraEditors.TextEdit();
            this.TextEditState = new DevExpress.XtraEditors.TextEdit();
            this.TextEditZip = new DevExpress.XtraEditors.TextEdit();
            this.TextEditAddr3 = new DevExpress.XtraEditors.TextEdit();
            this.TextEditAddr2 = new DevExpress.XtraEditors.TextEdit();
            this.TextEditAddr1 = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchLookupEditCountry = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.BindingSourceCodeName = new System.Windows.Forms.BindingSource(this.components);
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.XtraTabPageContacts = new DevExpress.XtraTab.XtraTabPage();
            this.PanelControlContactTab = new DevExpress.XtraEditors.PanelControl();
            this.ButtonDeleteContact = new DevExpress.XtraEditors.SimpleButton();
            this.ButtonAddContact = new DevExpress.XtraEditors.SimpleButton();
            this.ImageComboBoxEditMailFaxFlg = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.GridControlContacts = new DevExpress.XtraGrid.GridControl();
            this.BindingSourceContact = new System.Windows.Forms.BindingSource(this.components);
            this.GridViewContacts = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLINK_TABLE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLINK_VALUE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNAME1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDEPT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBoxDept = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colADDRESS1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colADDRESS2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colADDRESS3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCITY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGMACCTNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGMRECID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDEPT_HEAD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colACTIVE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCOMM_PREF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBoxSendDocs = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colCOUNTRY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUSER_DEC1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUSER_DEC2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUSER_INT1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUSER_INT2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUSER_TXT1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUSER_TXT2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUSER_TXT3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUSER_TXT4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUSER_DTE1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUSER_DTE2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLOGIN_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPASSWORD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLOGIN_ROLE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLOGIN_ACTIVE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRECTYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPARENT_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTITLE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDEAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPHONE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEMAIL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRptType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemCheckedComboBoxEditReportType = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            this.RepositoryItemSearchLookUpEditReportType = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TextEditEmail = new DevExpress.XtraEditors.TextEdit();
            this.TextEditFaxNum = new DevExpress.XtraEditors.TextEdit();
            this.TextEditPhone = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.XtraTabPageAvailability = new DevExpress.XtraTab.XtraTabPage();
            this.PanelControlAvailabilityTab = new DevExpress.XtraEditors.PanelControl();
            this.ImageComboBoxEditRetNotAvalHtls = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.ImageComboBoxEditRetreqHtls = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.CheckEditSubAlloc = new DevExpress.XtraEditors.CheckEdit();
            this.SpinEditArvBkDays = new DevExpress.XtraEditors.SpinEdit();
            this.SpinEditRel = new DevExpress.XtraEditors.SpinEdit();
            this.XtraTabPageReporting = new DevExpress.XtraTab.XtraTabPage();
            this.PanelControlReportTab = new DevExpress.XtraEditors.PanelControl();
            this.CheckEditPkgVouchers = new DevExpress.XtraEditors.CheckEdit();
            this.CheckEditOptVouchers = new DevExpress.XtraEditors.CheckEdit();
            this.CheckEditAirVouchers = new DevExpress.XtraEditors.CheckEdit();
            this.CheckEditCruVouchers = new DevExpress.XtraEditors.CheckEdit();
            this.CheckEditCarVouchers = new DevExpress.XtraEditors.CheckEdit();
            this.CheckEditHtlVouchers = new DevExpress.XtraEditors.CheckEdit();
            this.ImageComboBoxEditTourfaxEmailFormat = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.CheckEditSglResConf = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit8 = new DevExpress.XtraEditors.CheckEdit();
            this.CheckEditRemoteVouchers = new DevExpress.XtraEditors.CheckEdit();
            this.CheckEditAllowAttachments = new DevExpress.XtraEditors.CheckEdit();
            this.CheckEditConfPrc = new DevExpress.XtraEditors.CheckEdit();
            this.SpinEditVoucherDaysPrior = new DevExpress.XtraEditors.SpinEdit();
            this.SpinEditVoucherReprints = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.XtraTabPagePolicies = new DevExpress.XtraTab.XtraTabPage();
            this.PanelControlPoliciesTab = new DevExpress.XtraEditors.PanelControl();
            this.ButtonDeleteAgencyCurrency = new DevExpress.XtraEditors.SimpleButton();
            this.ButtonAddAgencyCurrency = new DevExpress.XtraEditors.SimpleButton();
            this.GridControlAgencyCurrency = new DevExpress.XtraGrid.GridControl();
            this.BindingSourceAgencyCurrency = new System.Windows.Forms.BindingSource(this.components);
            this.GridViewAgencyCurrency = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCurrency_Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDefault = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ImageComboBoxEditHtls = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.ImageComboBoxEditHdrs = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.CheckEditRemChg = new DevExpress.XtraEditors.CheckEdit();
            this.SpinEditComm = new DevExpress.XtraEditors.SpinEdit();
            this.SpinEditCxlGrace = new DevExpress.XtraEditors.SpinEdit();
            this.SpinEditOptDays = new DevExpress.XtraEditors.SpinEdit();
            this.XtraTabPageAccounting = new DevExpress.XtraTab.XtraTabPage();
            this.PanelControlAccountTab = new DevExpress.XtraEditors.PanelControl();
            this.RadioGroupPaymentDue = new DevExpress.XtraEditors.RadioGroup();
            this.BarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.BarButtonItemNew = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItemDelete = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.ButtonDeleteDeposit = new DevExpress.XtraEditors.SimpleButton();
            this.ButtonAddDeposit = new DevExpress.XtraEditors.SimpleButton();
            this.GridControlDeposits = new DevExpress.XtraGrid.GridControl();
            this.BindingSourcePaymentTransaction = new System.Windows.Forms.BindingSource(this.components);
            this.GridViewDeposits = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAgency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CheckEditCreditUnlimited = new DevExpress.XtraEditors.CheckEdit();
            this.SpinEditDaysSpace = new DevExpress.XtraEditors.SpinEdit();
            this.SpinEditPriorDays = new DevExpress.XtraEditors.SpinEdit();
            this.SpinEditPmtDays = new DevExpress.XtraEditors.SpinEdit();
            this.SpinEditDueDays = new DevExpress.XtraEditors.SpinEdit();
            this.LabelControlDaysSpace = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.LabelControlLastInvDate = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.LabelControlPriorDays = new DevExpress.XtraEditors.LabelControl();
            this.LabelControlPmtDays = new DevExpress.XtraEditors.LabelControl();
            this.LabelControlDueDays = new DevExpress.XtraEditors.LabelControl();
            this.CheckEditSvcDateFlg = new DevExpress.XtraEditors.CheckEdit();
            this.ComboBoxEditInvFmt = new DevExpress.XtraEditors.ComboBoxEdit();
            this.CheckEditImmedFlg = new DevExpress.XtraEditors.CheckEdit();
            this.TextEditFundBalance = new DevExpress.XtraEditors.SpinEdit();
            this.SpinEditCreditLimit = new DevExpress.XtraEditors.SpinEdit();
            this.SpinEditCreditLimitRemPct = new DevExpress.XtraEditors.SpinEdit();
            this.SpinEditCreditBalance = new DevExpress.XtraEditors.SpinEdit();
            this.TextEditAmountPaid = new DevExpress.XtraEditors.SpinEdit();
            this.DateEditLastInvDate = new DevExpress.XtraEditors.DateEdit();
            this.XtraTabPagePayments = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.SimpleButtonRetry = new DevExpress.XtraEditors.SimpleButton();
            this.PanelControlPaymentProfileStatus = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.SimpleButtonValidateBankRow = new DevExpress.XtraEditors.SimpleButton();
            this.SimpleButtonValidateCreditRow = new DevExpress.XtraEditors.SimpleButton();
            this.CheckEditAllowElectronicPayment = new DevExpress.XtraEditors.CheckEdit();
            this.CheckEditRequireCVV2 = new DevExpress.XtraEditors.CheckEdit();
            this.LabelDefaultPaymentProfileID = new System.Windows.Forms.Label();
            this.ButtonDeleteCredit = new DevExpress.XtraEditors.SimpleButton();
            this.ButtonDeleteBank = new DevExpress.XtraEditors.SimpleButton();
            this.LabelPaymentProcessorCustProfileId = new System.Windows.Forms.Label();
            this.ButtonAddBank = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.GridControlBankProfiles = new DevExpress.XtraGrid.GridControl();
            this.BindingSourceAgencyPaymentProfile = new System.Windows.Forms.BindingSource(this.components);
            this.GridViewBankProfiles = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnBankName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAccountType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBoxAccountType = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gridColumnAccountNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnStreet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnZipCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCountry = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRoutingNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnNameOnAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridControlCreditProfiles = new DevExpress.XtraGrid.GridControl();
            this.GridViewCreditProfiles = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdColID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.grdColCardNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdColExpirationYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemSpinEditExpYear = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.grdColCVV2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdColCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdColFirst = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdColLast = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColStreet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColZip = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCountry = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColAccountType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColExpirationMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemImageComboBoxExpMonth = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.AddCreditButton = new DevExpress.XtraEditors.SimpleButton();
            this.LblCreditCardProf = new System.Windows.Forms.Label();
            this.DeleteButton = new DevExpress.XtraEditors.SimpleButton();
            this.ChangePaymentProfileButton = new DevExpress.XtraEditors.SimpleButton();
            this.TextEditCustomerProfileEmail = new DevExpress.XtraEditors.TextEdit();
            this.ImageComboBoxEditDefaultPmtProfileID = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.XtraTabPageAdministrativeFees = new DevExpress.XtraTab.XtraTabPage();
            this.PanelControlAdminTab = new DevExpress.XtraEditors.PanelControl();
            this.TextEditChgFlat2 = new DevExpress.XtraEditors.TextEdit();
            this.TextEditChgFlat3 = new DevExpress.XtraEditors.TextEdit();
            this.TextEditChgFlat1 = new DevExpress.XtraEditors.TextEdit();
            this.TextEditChgPct2 = new DevExpress.XtraEditors.TextEdit();
            this.TextEditChgPct1 = new DevExpress.XtraEditors.TextEdit();
            this.SpinEditChgNtsPrior2 = new DevExpress.XtraEditors.SpinEdit();
            this.SpinEditCxlNtsPrior1 = new DevExpress.XtraEditors.SpinEdit();
            this.SpinEditChgNtsPrior1 = new DevExpress.XtraEditors.SpinEdit();
            this.TextEditCxlFlat1 = new DevExpress.XtraEditors.TextEdit();
            this.TextEditCxlFlat3 = new DevExpress.XtraEditors.TextEdit();
            this.TextEditCxlPct1 = new DevExpress.XtraEditors.TextEdit();
            this.TextEditChgPct3 = new DevExpress.XtraEditors.TextEdit();
            this.SpinEditCxlNtsPrior2 = new DevExpress.XtraEditors.SpinEdit();
            this.TextEditCxlPct3 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.TextEditCxlFlat2 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.TextEditCxlPct2 = new DevExpress.XtraEditors.TextEdit();
            this.SpinEditChgNtsPrior3 = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.SpinEditCxlNtsPrior3 = new DevExpress.XtraEditors.SpinEdit();
            this.XtraTabPageMemberships = new DevExpress.XtraTab.XtraTabPage();
            this.PanelControlMemberTab = new DevExpress.XtraEditors.PanelControl();
            this.TextEditSrt3 = new DevExpress.XtraEditors.TextEdit();
            this.TextEditSrt2 = new DevExpress.XtraEditors.TextEdit();
            this.ButtonDeleteMembership = new DevExpress.XtraEditors.SimpleButton();
            this.ButtonAddMembership = new DevExpress.XtraEditors.SimpleButton();
            this.GridControlMemberships = new DevExpress.XtraGrid.GridControl();
            this.BindingSourceDetail = new System.Windows.Forms.BindingSource(this.components);
            this.GridViewMemberships = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLINK_TABLE2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRECTYPE2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLINK_VALUE1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemSearchLookUpEditClass = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNOTE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUSER_DEC12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUSER_DEC22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUSER_INT12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUSER_INT22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUSER_TXT12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUSER_TXT22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUSER_TXT32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUSER_TXT42 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUSER_DTE12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUSER_DTE22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SearchLookupEditParentAgy = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.XtraTabPageResources = new DevExpress.XtraTab.XtraTabPage();
            this.PanelControlResourceTab = new DevExpress.XtraEditors.PanelControl();
            this.labelControlSize = new DevExpress.XtraEditors.LabelControl();
            this.ButtonEditLogoPath = new DevExpress.XtraEditors.ButtonEdit();
            this.TextEditWebsite = new DevExpress.XtraEditors.TextEdit();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.PictureEditPreview = new DevExpress.XtraEditors.PictureEdit();
            this.XtraTabPageCustom = new DevExpress.XtraTab.XtraTabPage();
            this.PanelControlCustomTab = new DevExpress.XtraEditors.PanelControl();
            this.GridControlCustom = new DevExpress.XtraGrid.GridControl();
            this.BindingSourceUserfield = new System.Windows.Forms.BindingSource(this.components);
            this.GridViewCustom = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLINK_TABLE1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLINK_COLUMN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRECTYPE1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLABEL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDESC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVISIBLE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLKUP_CODE_COLUMN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLKUP_DESC_COLUMN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLKUP_TABLE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSIZE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMIN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRESTRICT_TO_LKUP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPRECISION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colREQUIRED = new DevExpress.XtraGrid.Columns.GridColumn();
            this.XtraTabPageCommissions = new DevExpress.XtraTab.XtraTabPage();
            this.PanelControlCommTab = new DevExpress.XtraEditors.PanelControl();
            this.LabelMarkups = new System.Windows.Forms.Label();
            this.LabelCommissions = new System.Windows.Forms.Label();
            this.LabelSource = new DevExpress.XtraEditors.LabelControl();
            this.ComboBoxEditSource = new DevExpress.XtraEditors.ComboBoxEdit();
            this.ButtonSearch = new DevExpress.XtraEditors.SimpleButton();
            this.GridControlMarkups = new DevExpress.XtraGrid.GridControl();
            this.GridViewMarkups = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColumnServiceEndMU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnBookStartDateMU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnBookEndDateMU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnCommPctMU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.ColumnStartDateMU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnAgencyRuleMU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnPositionMU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnProductRuleMU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRecType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnSourceMU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.ColumnCategoryMU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridControlCommissions = new DevExpress.XtraGrid.GridControl();
            this.GridViewCommissions = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColumnEndDateComm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnBookStartDateComm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnBookEndDateComm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnCommPctComm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInactive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.ColumnStartDateComm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnAgencyRuleComm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnPositionComm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnProductRuleComm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnSourceComm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExclusion1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.ColumnCategoryComm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SearchLookupEditAgency = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DateEditDate = new DevExpress.XtraEditors.DateEdit();
            this.XtraTabPageAgents = new DevExpress.XtraTab.XtraTabPage();
            this.PanelControlAgentTab = new DevExpress.XtraEditors.PanelControl();
            this.ButtonDeleteAgent = new DevExpress.XtraEditors.SimpleButton();
            this.ButtonAddAgent = new DevExpress.XtraEditors.SimpleButton();
            this.GridControlAgcyLog = new DevExpress.XtraGrid.GridControl();
            this.BindingSourceAgcyLog = new System.Windows.Forms.BindingSource(this.components);
            this.GridViewAgcyLog = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAgentInactive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemCheckEditAgcylogBool = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colAGT_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemTextEditAgentName = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colAGENCY1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAGCY_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCUR_BOOK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSUPVR_FLG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemCheckEditSupvrFlg = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colRES_PROF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMNT_PROF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colACC_PROF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPRT_PROF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAGT_EMAIL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemTextEditAgtEmail = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colAGT_FAX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemTextEditAgtFax = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colPASSWORD1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemTextEditPassword = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colDATAFLEX_FILL_01 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAGY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAgentCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemTextEditAgentCompany = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colAgcylog_Agent_Delegate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemImageComboBoxEditAgentDelegate = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colAgcylogReadOnly = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BindingSourcePaymentProfiles = new System.Windows.Forms.BindingSource(this.components);
            this.BindingSourceCreditCardInfo = new System.Windows.Forms.BindingSource(this.components);
            this.TextEditAr = new DevExpress.XtraEditors.TextEdit();
            this.TextEditAp = new DevExpress.XtraEditors.TextEdit();
            this.TextEditType = new DevExpress.XtraEditors.TextEdit();
            this.TextEditName = new DevExpress.XtraEditors.TextEdit();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.BindingSourceComprod2 = new System.Windows.Forms.BindingSource(this.components);
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.SplitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.labelControl27 = new DevExpress.XtraEditors.LabelControl();
            this.LabelControlLastUpdatedBy = new DevExpress.XtraEditors.LabelControl();
            this.labelControl25 = new DevExpress.XtraEditors.LabelControl();
            this.LabelControlLastUpdated = new DevExpress.XtraEditors.LabelControl();
            this.SearchLookupEditDefLanguage = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TextEditCode = new DevExpress.XtraEditors.TextEdit();
            this.PanelControlStatus = new DevExpress.XtraEditors.PanelControl();
            this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
            this.chineseHosts_FlextourDataSet = new TraceForms.ChineseHosts_FlextourDataSet();
            this.BindingSourceAgencyPaymentProfileBank = new System.Windows.Forms.BindingSource(this.components);
            this.TextEditVouchTypes = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            eMAILLabel = new System.Windows.Forms.Label();
            fAX_NUMLabel = new System.Windows.Forms.Label();
            pHONELabel = new System.Windows.Forms.Label();
            mAILFAX_FLGLabel = new System.Windows.Forms.Label();
            aRVBKDAYSLabel = new System.Windows.Forms.Label();
            rELLabel = new System.Windows.Forms.Label();
            rETNOTAVALHTLSLabel = new System.Windows.Forms.Label();
            rETREQHTLSLabel = new System.Windows.Forms.Label();
            sUB_ALLOCLabel = new System.Windows.Forms.Label();
            vOUCHER_DAYS_PRIORLabel = new System.Windows.Forms.Label();
            vOUCHER_REPRINTSLabel = new System.Windows.Forms.Label();
            rEMOTE_VOUCHERSLabel = new System.Windows.Forms.Label();
            aLLOW_ATTACHMENTSLabel = new System.Windows.Forms.Label();
            cONF_PRCLabel = new System.Windows.Forms.Label();
            eDITHTLSLabel = new System.Windows.Forms.Label();
            eDITHDRSLabel = new System.Windows.Forms.Label();
            cOMMLabel = new System.Windows.Forms.Label();
            cXLGRACELabel = new System.Windows.Forms.Label();
            oPT_DAYSLabel = new System.Windows.Forms.Label();
            aPLabel = new System.Windows.Forms.Label();
            dEF_LANGLabel = new System.Windows.Forms.Label();
            tYPLabel = new System.Windows.Forms.Label();
            nAMELabel = new System.Windows.Forms.Label();
            nOLabel = new System.Windows.Forms.Label();
            aRLabel = new System.Windows.Forms.Label();
            wEBSITELabel = new System.Windows.Forms.Label();
            cXL1_NTSPRIORLabel = new System.Windows.Forms.Label();
            cXL1_PCTLabel = new System.Windows.Forms.Label();
            cXL2_FLATLabel = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            label22 = new System.Windows.Forms.Label();
            label23 = new System.Windows.Forms.Label();
            cHG1_NTSPRIORLabel = new System.Windows.Forms.Label();
            cHG1_PCTLabel = new System.Windows.Forms.Label();
            cHG1_FLATLabel = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            label28 = new System.Windows.Forms.Label();
            label29 = new System.Windows.Forms.Label();
            pARENTLabel = new System.Windows.Forms.Label();
            cOUNTRYLabel = new System.Windows.Forms.Label();
            zIPLabel = new System.Windows.Forms.Label();
            sTATELabel = new System.Windows.Forms.Label();
            cITYLabel = new System.Windows.Forms.Label();
            aDDR1Label = new System.Windows.Forms.Label();
            tourfaxEmailFormatLabel = new System.Windows.Forms.Label();
            lOGO_PATHLabel = new System.Windows.Forms.Label();
            vOUCH_TYPESLabel = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            label20 = new System.Windows.Forms.Label();
            label24 = new System.Windows.Forms.Label();
            label25 = new System.Windows.Forms.Label();
            label26 = new System.Windows.Forms.Label();
            LabelSize = new System.Windows.Forms.Label();
            LabelCreditLimit = new System.Windows.Forms.Label();
            LabelCreditLimitRemainingWarningPct = new System.Windows.Forms.Label();
            LabelCreditUnlimited = new System.Windows.Forms.Label();
            paymentProcessorCustProfileEmailLabel = new System.Windows.Forms.Label();
            paymentProcessorCustProfileIdLabel = new System.Windows.Forms.Label();
            label30 = new System.Windows.Forms.Label();
            LabelFundBalance = new System.Windows.Forms.Label();
            LabelAmountPaid = new System.Windows.Forms.Label();
            LabelCreditBalance = new System.Windows.Forms.Label();
            label35 = new System.Windows.Forms.Label();
            sRT3Label = new System.Windows.Forms.Label();
            sRT2Label = new System.Windows.Forms.Label();
            LabelPaymentDue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditActiveFlg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XtraTabControlAgency)).BeginInit();
            this.XtraTabControlAgency.SuspendLayout();
            this.XtraTabPageLocation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlLocationTab)).BeginInit();
            this.PanelControlLocationTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditZip.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditAddr3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditAddr2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditAddr1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditCountry.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceCodeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.XtraTabPageContacts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlContactTab)).BeginInit();
            this.PanelControlContactTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditMailFaxFlg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlContacts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewContacts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBoxSendDocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckedComboBoxEditReportType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemSearchLookUpEditReportType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditFaxNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditPhone.Properties)).BeginInit();
            this.XtraTabPageAvailability.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlAvailabilityTab)).BeginInit();
            this.PanelControlAvailabilityTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditRetNotAvalHtls.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditRetreqHtls.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditSubAlloc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditArvBkDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditRel.Properties)).BeginInit();
            this.XtraTabPageReporting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlReportTab)).BeginInit();
            this.PanelControlReportTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditPkgVouchers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditOptVouchers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditAirVouchers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditCruVouchers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditCarVouchers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditHtlVouchers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditTourfaxEmailFormat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditSglResConf.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit8.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditRemoteVouchers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditAllowAttachments.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditConfPrc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditVoucherDaysPrior.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditVoucherReprints.Properties)).BeginInit();
            this.XtraTabPagePolicies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlPoliciesTab)).BeginInit();
            this.PanelControlPoliciesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlAgencyCurrency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceAgencyCurrency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewAgencyCurrency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditHtls.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditHdrs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditRemChg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditComm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditCxlGrace.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditOptDays.Properties)).BeginInit();
            this.XtraTabPageAccounting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlAccountTab)).BeginInit();
            this.PanelControlAccountTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RadioGroupPaymentDue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlDeposits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourcePaymentTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewDeposits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditCreditUnlimited.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditDaysSpace.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditPriorDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditPmtDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditDueDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditSvcDateFlg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxEditInvFmt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditImmedFlg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditFundBalance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditCreditLimit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditCreditLimitRemPct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditCreditBalance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditAmountPaid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditLastInvDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditLastInvDate.Properties)).BeginInit();
            this.XtraTabPagePayments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlPaymentProfileStatus)).BeginInit();
            this.PanelControlPaymentProfileStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditAllowElectronicPayment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditRequireCVV2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlBankProfiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceAgencyPaymentProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewBankProfiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBoxAccountType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlCreditProfiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewCreditProfiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemSpinEditExpYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemImageComboBoxExpMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCustomerProfileEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditDefaultPmtProfileID.Properties)).BeginInit();
            this.XtraTabPageAdministrativeFees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlAdminTab)).BeginInit();
            this.PanelControlAdminTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditChgFlat2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditChgFlat3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditChgFlat1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditChgPct2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditChgPct1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditChgNtsPrior2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditCxlNtsPrior1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditChgNtsPrior1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCxlFlat1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCxlFlat3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCxlPct1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditChgPct3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditCxlNtsPrior2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCxlPct3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCxlFlat2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCxlPct2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditChgNtsPrior3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditCxlNtsPrior3.Properties)).BeginInit();
            this.XtraTabPageMemberships.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlMemberTab)).BeginInit();
            this.PanelControlMemberTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditSrt3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditSrt2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlMemberships)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewMemberships)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemSearchLookUpEditClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditParentAgy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            this.XtraTabPageResources.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlResourceTab)).BeginInit();
            this.PanelControlResourceTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEditLogoPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditWebsite.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureEditPreview.Properties)).BeginInit();
            this.XtraTabPageCustom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlCustomTab)).BeginInit();
            this.PanelControlCustomTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlCustom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceUserfield)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewCustom)).BeginInit();
            this.XtraTabPageCommissions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlCommTab)).BeginInit();
            this.PanelControlCommTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxEditSource.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlMarkups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewMarkups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlCommissions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewCommissions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditAgency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditDate.Properties)).BeginInit();
            this.XtraTabPageAgents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlAgentTab)).BeginInit();
            this.PanelControlAgentTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlAgcyLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceAgcyLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewAgcyLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEditAgcylogBool)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEditAgentName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEditSupvrFlg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEditAgtEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEditAgtFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEditPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEditAgentCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemImageComboBoxEditAgentDelegate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourcePaymentProfiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceCreditCardInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditAr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditAp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceComprod2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl)).BeginInit();
            this.SplitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditDefLanguage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlStatus)).BeginInit();
            this.PanelControlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chineseHosts_FlextourDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceAgencyPaymentProfileBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditVouchTypes.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // eMAILLabel
            // 
            eMAILLabel.AutoSize = true;
            eMAILLabel.BackColor = System.Drawing.Color.Transparent;
            eMAILLabel.Location = new System.Drawing.Point(64, 134);
            eMAILLabel.Name = "eMAILLabel";
            eMAILLabel.Size = new System.Drawing.Size(35, 13);
            eMAILLabel.TabIndex = 0;
            eMAILLabel.Text = "Email:";
            // 
            // fAX_NUMLabel
            // 
            fAX_NUMLabel.AutoSize = true;
            fAX_NUMLabel.BackColor = System.Drawing.Color.Transparent;
            fAX_NUMLabel.Location = new System.Drawing.Point(430, 88);
            fAX_NUMLabel.Name = "fAX_NUMLabel";
            fAX_NUMLabel.Size = new System.Drawing.Size(29, 13);
            fAX_NUMLabel.TabIndex = 0;
            fAX_NUMLabel.Text = "Fax:";
            // 
            // pHONELabel
            // 
            pHONELabel.AutoSize = true;
            pHONELabel.BackColor = System.Drawing.Color.Transparent;
            pHONELabel.Location = new System.Drawing.Point(262, 88);
            pHONELabel.Name = "pHONELabel";
            pHONELabel.Size = new System.Drawing.Size(41, 13);
            pHONELabel.TabIndex = 0;
            pHONELabel.Text = "Phone:";
            // 
            // mAILFAX_FLGLabel
            // 
            mAILFAX_FLGLabel.AutoSize = true;
            mAILFAX_FLGLabel.BackColor = System.Drawing.Color.Transparent;
            mAILFAX_FLGLabel.Location = new System.Drawing.Point(30, 88);
            mAILFAX_FLGLabel.Name = "mAILFAX_FLGLabel";
            mAILFAX_FLGLabel.Size = new System.Drawing.Size(75, 13);
            mAILFAX_FLGLabel.TabIndex = 0;
            mAILFAX_FLGLabel.Text = "Send docs by:";
            // 
            // aRVBKDAYSLabel
            // 
            aRVBKDAYSLabel.AutoSize = true;
            aRVBKDAYSLabel.BackColor = System.Drawing.Color.Transparent;
            aRVBKDAYSLabel.Location = new System.Drawing.Point(43, 239);
            aRVBKDAYSLabel.Name = "aRVBKDAYSLabel";
            aRVBKDAYSLabel.Size = new System.Drawing.Size(113, 13);
            aRVBKDAYSLabel.TabIndex = 0;
            aRVBKDAYSLabel.Text = "Minimum Booking days";
            // 
            // rELLabel
            // 
            rELLabel.AutoSize = true;
            rELLabel.BackColor = System.Drawing.Color.Transparent;
            rELLabel.Location = new System.Drawing.Point(43, 197);
            rELLabel.Name = "rELLabel";
            rELLabel.Size = new System.Drawing.Size(119, 13);
            rELLabel.TabIndex = 0;
            rELLabel.Text = "Inventory release days";
            // 
            // rETNOTAVALHTLSLabel
            // 
            rETNOTAVALHTLSLabel.AutoSize = true;
            rETNOTAVALHTLSLabel.BackColor = System.Drawing.Color.Transparent;
            rETNOTAVALHTLSLabel.Location = new System.Drawing.Point(43, 150);
            rETNOTAVALHTLSLabel.Name = "rETNOTAVALHTLSLabel";
            rETNOTAVALHTLSLabel.Size = new System.Drawing.Size(190, 13);
            rETNOTAVALHTLSLabel.TabIndex = 0;
            rETNOTAVALHTLSLabel.Text = "Availability check returns n/a products";
            // 
            // rETREQHTLSLabel
            // 
            rETREQHTLSLabel.AutoSize = true;
            rETREQHTLSLabel.BackColor = System.Drawing.Color.Transparent;
            rETREQHTLSLabel.Location = new System.Drawing.Point(43, 100);
            rETREQHTLSLabel.Name = "rETREQHTLSLabel";
            rETREQHTLSLabel.Size = new System.Drawing.Size(211, 13);
            rETREQHTLSLabel.TabIndex = 0;
            rETREQHTLSLabel.Text = "Availability check returns request products";
            // 
            // sUB_ALLOCLabel
            // 
            sUB_ALLOCLabel.AutoSize = true;
            sUB_ALLOCLabel.BackColor = System.Drawing.Color.Transparent;
            sUB_ALLOCLabel.Location = new System.Drawing.Point(43, 51);
            sUB_ALLOCLabel.Name = "sUB_ALLOCLabel";
            sUB_ALLOCLabel.Size = new System.Drawing.Size(180, 13);
            sUB_ALLOCLabel.TabIndex = 0;
            sUB_ALLOCLabel.Text = "Agency has inventory sub-allotment";
            // 
            // vOUCHER_DAYS_PRIORLabel
            // 
            vOUCHER_DAYS_PRIORLabel.AutoSize = true;
            vOUCHER_DAYS_PRIORLabel.BackColor = System.Drawing.Color.Transparent;
            vOUCHER_DAYS_PRIORLabel.Location = new System.Drawing.Point(38, 307);
            vOUCHER_DAYS_PRIORLabel.Name = "vOUCHER_DAYS_PRIORLabel";
            vOUCHER_DAYS_PRIORLabel.Size = new System.Drawing.Size(213, 13);
            vOUCHER_DAYS_PRIORLabel.TabIndex = 0;
            vOUCHER_DAYS_PRIORLabel.Text = "Days prior to services begin for vouchering";
            // 
            // vOUCHER_REPRINTSLabel
            // 
            vOUCHER_REPRINTSLabel.AutoSize = true;
            vOUCHER_REPRINTSLabel.BackColor = System.Drawing.Color.Transparent;
            vOUCHER_REPRINTSLabel.Location = new System.Drawing.Point(38, 255);
            vOUCHER_REPRINTSLabel.Name = "vOUCHER_REPRINTSLabel";
            vOUCHER_REPRINTSLabel.Size = new System.Drawing.Size(207, 13);
            vOUCHER_REPRINTSLabel.TabIndex = 0;
            vOUCHER_REPRINTSLabel.Text = "Nbr voucher reprints without services chg";
            // 
            // rEMOTE_VOUCHERSLabel
            // 
            rEMOTE_VOUCHERSLabel.AutoSize = true;
            rEMOTE_VOUCHERSLabel.BackColor = System.Drawing.Color.Transparent;
            rEMOTE_VOUCHERSLabel.Location = new System.Drawing.Point(38, 152);
            rEMOTE_VOUCHERSLabel.Name = "rEMOTE_VOUCHERSLabel";
            rEMOTE_VOUCHERSLabel.Size = new System.Drawing.Size(157, 13);
            rEMOTE_VOUCHERSLabel.TabIndex = 0;
            rEMOTE_VOUCHERSLabel.Text = "Agency can generate vouchers";
            // 
            // aLLOW_ATTACHMENTSLabel
            // 
            aLLOW_ATTACHMENTSLabel.AutoSize = true;
            aLLOW_ATTACHMENTSLabel.BackColor = System.Drawing.Color.Transparent;
            aLLOW_ATTACHMENTSLabel.Location = new System.Drawing.Point(38, 104);
            aLLOW_ATTACHMENTSLabel.Name = "aLLOW_ATTACHMENTSLabel";
            aLLOW_ATTACHMENTSLabel.Size = new System.Drawing.Size(191, 13);
            aLLOW_ATTACHMENTSLabel.TabIndex = 0;
            aLLOW_ATTACHMENTSLabel.Text = "Agency can receive email attachments";
            // 
            // cONF_PRCLabel
            // 
            cONF_PRCLabel.AutoSize = true;
            cONF_PRCLabel.BackColor = System.Drawing.Color.Transparent;
            cONF_PRCLabel.Location = new System.Drawing.Point(38, 52);
            cONF_PRCLabel.Name = "cONF_PRCLabel";
            cONF_PRCLabel.Size = new System.Drawing.Size(156, 13);
            cONF_PRCLabel.TabIndex = 0;
            cONF_PRCLabel.Text = "Print net price on confirmations";
            // 
            // eDITHTLSLabel
            // 
            eDITHTLSLabel.AutoSize = true;
            eDITHTLSLabel.BackColor = System.Drawing.Color.Transparent;
            eDITHTLSLabel.Location = new System.Drawing.Point(39, 299);
            eDITHTLSLabel.Name = "eDITHTLSLabel";
            eDITHTLSLabel.Size = new System.Drawing.Size(114, 13);
            eDITHTLSLabel.TabIndex = 0;
            eDITHTLSLabel.Text = "Allow editing line items";
            // 
            // eDITHDRSLabel
            // 
            eDITHDRSLabel.AutoSize = true;
            eDITHDRSLabel.BackColor = System.Drawing.Color.Transparent;
            eDITHDRSLabel.Location = new System.Drawing.Point(38, 253);
            eDITHDRSLabel.Name = "eDITHDRSLabel";
            eDITHDRSLabel.Size = new System.Drawing.Size(167, 13);
            eDITHDRSLabel.TabIndex = 0;
            eDITHDRSLabel.Text = "Allow editing reservation headers";
            // 
            // cOMMLabel
            // 
            cOMMLabel.AutoSize = true;
            cOMMLabel.BackColor = System.Drawing.Color.Transparent;
            cOMMLabel.Location = new System.Drawing.Point(38, 207);
            cOMMLabel.Name = "cOMMLabel";
            cOMMLabel.Size = new System.Drawing.Size(120, 13);
            cOMMLabel.TabIndex = 0;
            cOMMLabel.Text = "Commission percentage";
            // 
            // cXLGRACELabel
            // 
            cXLGRACELabel.AutoSize = true;
            cXLGRACELabel.BackColor = System.Drawing.Color.Transparent;
            cXLGRACELabel.Location = new System.Drawing.Point(38, 156);
            cXLGRACELabel.Name = "cXLGRACELabel";
            cXLGRACELabel.Size = new System.Drawing.Size(94, 13);
            cXLGRACELabel.TabIndex = 0;
            cXLGRACELabel.Text = "Grace period days";
            // 
            // oPT_DAYSLabel
            // 
            oPT_DAYSLabel.AutoSize = true;
            oPT_DAYSLabel.BackColor = System.Drawing.Color.Transparent;
            oPT_DAYSLabel.Location = new System.Drawing.Point(38, 107);
            oPT_DAYSLabel.Name = "oPT_DAYSLabel";
            oPT_DAYSLabel.Size = new System.Drawing.Size(185, 13);
            oPT_DAYSLabel.TabIndex = 0;
            oPT_DAYSLabel.Text = "Days Allowed for an inventory option";
            // 
            // aPLabel
            // 
            aPLabel.AutoSize = true;
            aPLabel.BackColor = System.Drawing.Color.Transparent;
            aPLabel.Location = new System.Drawing.Point(236, 72);
            aPLabel.Name = "aPLabel";
            aPLabel.Size = new System.Drawing.Size(63, 13);
            aPLabel.TabIndex = 0;
            aPLabel.Text = "A/P number";
            // 
            // dEF_LANGLabel
            // 
            dEF_LANGLabel.AutoSize = true;
            dEF_LANGLabel.BackColor = System.Drawing.Color.Transparent;
            dEF_LANGLabel.Location = new System.Drawing.Point(19, 95);
            dEF_LANGLabel.Name = "dEF_LANGLabel";
            dEF_LANGLabel.Size = new System.Drawing.Size(92, 13);
            dEF_LANGLabel.TabIndex = 0;
            dEF_LANGLabel.Text = "Default Language";
            // 
            // tYPLabel
            // 
            tYPLabel.AutoSize = true;
            tYPLabel.BackColor = System.Drawing.Color.Transparent;
            tYPLabel.Location = new System.Drawing.Point(19, 72);
            tYPLabel.Name = "tYPLabel";
            tYPLabel.Size = new System.Drawing.Size(70, 13);
            tYPLabel.TabIndex = 0;
            tYPLabel.Text = "Agency Type";
            // 
            // nAMELabel
            // 
            nAMELabel.AutoSize = true;
            nAMELabel.BackColor = System.Drawing.Color.Transparent;
            nAMELabel.Location = new System.Drawing.Point(18, 49);
            nAMELabel.Name = "nAMELabel";
            nAMELabel.Size = new System.Drawing.Size(73, 13);
            nAMELabel.TabIndex = 0;
            nAMELabel.Text = "Agency Name";
            // 
            // nOLabel
            // 
            nOLabel.AutoSize = true;
            nOLabel.BackColor = System.Drawing.Color.Transparent;
            nOLabel.Location = new System.Drawing.Point(18, 25);
            nOLabel.Name = "nOLabel";
            nOLabel.Size = new System.Drawing.Size(71, 13);
            nOLabel.TabIndex = 0;
            nOLabel.Text = "Agency Code";
            // 
            // aRLabel
            // 
            aRLabel.AutoSize = true;
            aRLabel.BackColor = System.Drawing.Color.Transparent;
            aRLabel.Location = new System.Drawing.Point(417, 72);
            aRLabel.Name = "aRLabel";
            aRLabel.Size = new System.Drawing.Size(64, 13);
            aRLabel.TabIndex = 0;
            aRLabel.Text = "A/R number";
            // 
            // wEBSITELabel
            // 
            wEBSITELabel.AutoSize = true;
            wEBSITELabel.BackColor = System.Drawing.Color.Transparent;
            wEBSITELabel.Location = new System.Drawing.Point(28, 408);
            wEBSITELabel.Name = "wEBSITELabel";
            wEBSITELabel.Size = new System.Drawing.Size(46, 13);
            wEBSITELabel.TabIndex = 0;
            wEBSITELabel.Text = "Website";
            // 
            // cXL1_NTSPRIORLabel
            // 
            cXL1_NTSPRIORLabel.AutoSize = true;
            cXL1_NTSPRIORLabel.BackColor = System.Drawing.Color.Transparent;
            cXL1_NTSPRIORLabel.Location = new System.Drawing.Point(48, 75);
            cXL1_NTSPRIORLabel.Name = "cXL1_NTSPRIORLabel";
            cXL1_NTSPRIORLabel.Size = new System.Drawing.Size(80, 13);
            cXL1_NTSPRIORLabel.TabIndex = 0;
            cXL1_NTSPRIORLabel.Text = "Cxl Nights Prior";
            // 
            // cXL1_PCTLabel
            // 
            cXL1_PCTLabel.AutoSize = true;
            cXL1_PCTLabel.BackColor = System.Drawing.Color.Transparent;
            cXL1_PCTLabel.Location = new System.Drawing.Point(48, 116);
            cXL1_PCTLabel.Name = "cXL1_PCTLabel";
            cXL1_PCTLabel.Size = new System.Drawing.Size(62, 13);
            cXL1_PCTLabel.TabIndex = 0;
            cXL1_PCTLabel.Text = "Cxl Percent";
            // 
            // cXL2_FLATLabel
            // 
            cXL2_FLATLabel.AutoSize = true;
            cXL2_FLATLabel.BackColor = System.Drawing.Color.Transparent;
            cXL2_FLATLabel.Location = new System.Drawing.Point(48, 155);
            cXL2_FLATLabel.Name = "cXL2_FLATLabel";
            cXL2_FLATLabel.Size = new System.Drawing.Size(64, 13);
            cXL2_FLATLabel.TabIndex = 0;
            cXL2_FLATLabel.Text = "Cxl Flat Fee";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.BackColor = System.Drawing.Color.Transparent;
            label21.Location = new System.Drawing.Point(509, 75);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(80, 13);
            label21.TabIndex = 0;
            label21.Text = "Cxl Nights Prior";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.BackColor = System.Drawing.Color.Transparent;
            label22.Location = new System.Drawing.Point(509, 116);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(62, 13);
            label22.TabIndex = 0;
            label22.Text = "Cxl Percent";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.BackColor = System.Drawing.Color.Transparent;
            label23.Location = new System.Drawing.Point(509, 159);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(64, 13);
            label23.TabIndex = 0;
            label23.Text = "Cxl Flat Fee";
            // 
            // cHG1_NTSPRIORLabel
            // 
            cHG1_NTSPRIORLabel.AutoSize = true;
            cHG1_NTSPRIORLabel.BackColor = System.Drawing.Color.Transparent;
            cHG1_NTSPRIORLabel.Location = new System.Drawing.Point(48, 221);
            cHG1_NTSPRIORLabel.Name = "cHG1_NTSPRIORLabel";
            cHG1_NTSPRIORLabel.Size = new System.Drawing.Size(84, 13);
            cHG1_NTSPRIORLabel.TabIndex = 0;
            cHG1_NTSPRIORLabel.Text = "Chg Nights Prior";
            // 
            // cHG1_PCTLabel
            // 
            cHG1_PCTLabel.AutoSize = true;
            cHG1_PCTLabel.BackColor = System.Drawing.Color.Transparent;
            cHG1_PCTLabel.Location = new System.Drawing.Point(48, 263);
            cHG1_PCTLabel.Name = "cHG1_PCTLabel";
            cHG1_PCTLabel.Size = new System.Drawing.Size(66, 13);
            cHG1_PCTLabel.TabIndex = 0;
            cHG1_PCTLabel.Text = "Chg Percent";
            // 
            // cHG1_FLATLabel
            // 
            cHG1_FLATLabel.AutoSize = true;
            cHG1_FLATLabel.BackColor = System.Drawing.Color.Transparent;
            cHG1_FLATLabel.Location = new System.Drawing.Point(48, 300);
            cHG1_FLATLabel.Name = "cHG1_FLATLabel";
            cHG1_FLATLabel.Size = new System.Drawing.Size(68, 13);
            cHG1_FLATLabel.TabIndex = 0;
            cHG1_FLATLabel.Text = "Chg Flat Fee";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.BackColor = System.Drawing.Color.Transparent;
            label27.Location = new System.Drawing.Point(509, 300);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(68, 13);
            label27.TabIndex = 0;
            label27.Text = "Chg Flat Fee";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.BackColor = System.Drawing.Color.Transparent;
            label28.Location = new System.Drawing.Point(509, 263);
            label28.Name = "label28";
            label28.Size = new System.Drawing.Size(66, 13);
            label28.TabIndex = 0;
            label28.Text = "Chg Percent";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.BackColor = System.Drawing.Color.Transparent;
            label29.Location = new System.Drawing.Point(509, 221);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(84, 13);
            label29.TabIndex = 0;
            label29.Text = "Chg Nights Prior";
            // 
            // pARENTLabel
            // 
            pARENTLabel.AutoSize = true;
            pARENTLabel.BackColor = System.Drawing.Color.Transparent;
            pARENTLabel.Location = new System.Drawing.Point(36, 21);
            pARENTLabel.Name = "pARENTLabel";
            pARENTLabel.Size = new System.Drawing.Size(78, 13);
            pARENTLabel.TabIndex = 0;
            pARENTLabel.Text = "Parent Agency";
            // 
            // cOUNTRYLabel
            // 
            cOUNTRYLabel.AutoSize = true;
            cOUNTRYLabel.BackColor = System.Drawing.Color.Transparent;
            cOUNTRYLabel.Location = new System.Drawing.Point(230, 273);
            cOUNTRYLabel.Name = "cOUNTRYLabel";
            cOUNTRYLabel.Size = new System.Drawing.Size(46, 13);
            cOUNTRYLabel.TabIndex = 0;
            cOUNTRYLabel.Text = "Country";
            // 
            // zIPLabel
            // 
            zIPLabel.AutoSize = true;
            zIPLabel.BackColor = System.Drawing.Color.Transparent;
            zIPLabel.Location = new System.Drawing.Point(38, 272);
            zIPLabel.Name = "zIPLabel";
            zIPLabel.Size = new System.Drawing.Size(21, 13);
            zIPLabel.TabIndex = 0;
            zIPLabel.Text = "Zip";
            // 
            // sTATELabel
            // 
            sTATELabel.AutoSize = true;
            sTATELabel.BackColor = System.Drawing.Color.Transparent;
            sTATELabel.Location = new System.Drawing.Point(38, 231);
            sTATELabel.Name = "sTATELabel";
            sTATELabel.Size = new System.Drawing.Size(33, 13);
            sTATELabel.TabIndex = 0;
            sTATELabel.Text = "State";
            // 
            // cITYLabel
            // 
            cITYLabel.AutoSize = true;
            cITYLabel.BackColor = System.Drawing.Color.Transparent;
            cITYLabel.Location = new System.Drawing.Point(38, 191);
            cITYLabel.Name = "cITYLabel";
            cITYLabel.Size = new System.Drawing.Size(26, 13);
            cITYLabel.TabIndex = 0;
            cITYLabel.Text = "City";
            // 
            // aDDR1Label
            // 
            aDDR1Label.AutoSize = true;
            aDDR1Label.BackColor = System.Drawing.Color.Transparent;
            aDDR1Label.Location = new System.Drawing.Point(38, 64);
            aDDR1Label.Name = "aDDR1Label";
            aDDR1Label.Size = new System.Drawing.Size(37, 13);
            aDDR1Label.TabIndex = 0;
            aDDR1Label.Text = "Street";
            // 
            // tourfaxEmailFormatLabel
            // 
            tourfaxEmailFormatLabel.AutoSize = true;
            tourfaxEmailFormatLabel.BackColor = System.Drawing.Color.Transparent;
            tourfaxEmailFormatLabel.Location = new System.Drawing.Point(399, 104);
            tourfaxEmailFormatLabel.Name = "tourfaxEmailFormatLabel";
            tourfaxEmailFormatLabel.Size = new System.Drawing.Size(109, 13);
            tourfaxEmailFormatLabel.TabIndex = 0;
            tourfaxEmailFormatLabel.Text = "Tourfax Email Format";
            // 
            // lOGO_PATHLabel
            // 
            lOGO_PATHLabel.AutoSize = true;
            lOGO_PATHLabel.BackColor = System.Drawing.Color.Transparent;
            lOGO_PATHLabel.Location = new System.Drawing.Point(28, 34);
            lOGO_PATHLabel.Name = "lOGO_PATHLabel";
            lOGO_PATHLabel.Size = new System.Drawing.Size(30, 13);
            lOGO_PATHLabel.TabIndex = 0;
            lOGO_PATHLabel.Text = "Logo";
            // 
            // vOUCH_TYPESLabel
            // 
            vOUCH_TYPESLabel.AutoSize = true;
            vOUCH_TYPESLabel.Location = new System.Drawing.Point(417, 98);
            vOUCH_TYPESLabel.Name = "vOUCH_TYPESLabel";
            vOUCH_TYPESLabel.Size = new System.Drawing.Size(79, 13);
            vOUCH_TYPESLabel.TabIndex = 0;
            vOUCH_TYPESLabel.Text = "VOUCH TYPES:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.BackColor = System.Drawing.Color.Transparent;
            label18.Location = new System.Drawing.Point(270, 75);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(80, 13);
            label18.TabIndex = 0;
            label18.Text = "Cxl Nights Prior";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.BackColor = System.Drawing.Color.Transparent;
            label19.Location = new System.Drawing.Point(270, 116);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(62, 13);
            label19.TabIndex = 0;
            label19.Text = "Cxl Percent";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.BackColor = System.Drawing.Color.Transparent;
            label20.Location = new System.Drawing.Point(270, 155);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(64, 13);
            label20.TabIndex = 0;
            label20.Text = "Cxl Flat Fee";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.BackColor = System.Drawing.Color.Transparent;
            label24.Location = new System.Drawing.Point(270, 221);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(84, 13);
            label24.TabIndex = 0;
            label24.Text = "Chg Nights Prior";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.BackColor = System.Drawing.Color.Transparent;
            label25.Location = new System.Drawing.Point(270, 263);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(66, 13);
            label25.TabIndex = 0;
            label25.Text = "Chg Percent";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.BackColor = System.Drawing.Color.Transparent;
            label26.Location = new System.Drawing.Point(270, 300);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(68, 13);
            label26.TabIndex = 0;
            label26.Text = "Chg Flat Fee";
            // 
            // LabelSize
            // 
            LabelSize.AutoSize = true;
            LabelSize.BackColor = System.Drawing.Color.Transparent;
            LabelSize.Location = new System.Drawing.Point(28, 357);
            LabelSize.Name = "LabelSize";
            LabelSize.Size = new System.Drawing.Size(33, 13);
            LabelSize.TabIndex = 85;
            LabelSize.Text = "Size: ";
            // 
            // LabelCreditLimit
            // 
            LabelCreditLimit.AutoSize = true;
            LabelCreditLimit.BackColor = System.Drawing.Color.Transparent;
            LabelCreditLimit.Location = new System.Drawing.Point(27, 42);
            LabelCreditLimit.Name = "LabelCreditLimit";
            LabelCreditLimit.Size = new System.Drawing.Size(57, 13);
            LabelCreditLimit.TabIndex = 63;
            LabelCreditLimit.Text = "Credit limit";
            // 
            // LabelCreditLimitRemainingWarningPct
            // 
            LabelCreditLimitRemainingWarningPct.AutoSize = true;
            LabelCreditLimitRemainingWarningPct.BackColor = System.Drawing.Color.Transparent;
            LabelCreditLimitRemainingWarningPct.Location = new System.Drawing.Point(27, 67);
            LabelCreditLimitRemainingWarningPct.Name = "LabelCreditLimitRemainingWarningPct";
            LabelCreditLimitRemainingWarningPct.Size = new System.Drawing.Size(161, 13);
            LabelCreditLimitRemainingWarningPct.TabIndex = 64;
            LabelCreditLimitRemainingWarningPct.Text = "Credit limit remaining warning %";
            // 
            // LabelCreditUnlimited
            // 
            LabelCreditUnlimited.AutoSize = true;
            LabelCreditUnlimited.BackColor = System.Drawing.Color.Transparent;
            LabelCreditUnlimited.Location = new System.Drawing.Point(27, 16);
            LabelCreditUnlimited.Name = "LabelCreditUnlimited";
            LabelCreditUnlimited.Size = new System.Drawing.Size(80, 13);
            LabelCreditUnlimited.TabIndex = 65;
            LabelCreditUnlimited.Text = "Unlimited credit";
            // 
            // paymentProcessorCustProfileEmailLabel
            // 
            paymentProcessorCustProfileEmailLabel.AutoSize = true;
            paymentProcessorCustProfileEmailLabel.BackColor = System.Drawing.Color.Transparent;
            paymentProcessorCustProfileEmailLabel.Location = new System.Drawing.Point(26, 47);
            paymentProcessorCustProfileEmailLabel.Name = "paymentProcessorCustProfileEmailLabel";
            paymentProcessorCustProfileEmailLabel.Size = new System.Drawing.Size(122, 13);
            paymentProcessorCustProfileEmailLabel.TabIndex = 0;
            paymentProcessorCustProfileEmailLabel.Text = "Customer Email Address";
            // 
            // paymentProcessorCustProfileIdLabel
            // 
            paymentProcessorCustProfileIdLabel.AutoSize = true;
            paymentProcessorCustProfileIdLabel.BackColor = System.Drawing.Color.Transparent;
            paymentProcessorCustProfileIdLabel.Location = new System.Drawing.Point(26, 75);
            paymentProcessorCustProfileIdLabel.Name = "paymentProcessorCustProfileIdLabel";
            paymentProcessorCustProfileIdLabel.Size = new System.Drawing.Size(100, 13);
            paymentProcessorCustProfileIdLabel.TabIndex = 64;
            paymentProcessorCustProfileIdLabel.Text = "Customer Profile ID";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.BackColor = System.Drawing.Color.Transparent;
            label30.Location = new System.Drawing.Point(450, 35);
            label30.Name = "label30";
            label30.Size = new System.Drawing.Size(62, 13);
            label30.TabIndex = 48;
            label30.Text = "Currencies:";
            // 
            // LabelFundBalance
            // 
            LabelFundBalance.AutoSize = true;
            LabelFundBalance.BackColor = System.Drawing.Color.Transparent;
            LabelFundBalance.Location = new System.Drawing.Point(27, 118);
            LabelFundBalance.Name = "LabelFundBalance";
            LabelFundBalance.Size = new System.Drawing.Size(169, 13);
            LabelFundBalance.TabIndex = 68;
            LabelFundBalance.Text = "Fund balance on last deposit date";
            // 
            // LabelAmountPaid
            // 
            LabelAmountPaid.AutoSize = true;
            LabelAmountPaid.BackColor = System.Drawing.Color.Transparent;
            LabelAmountPaid.Location = new System.Drawing.Point(27, 144);
            LabelAmountPaid.Name = "LabelAmountPaid";
            LabelAmountPaid.Size = new System.Drawing.Size(207, 13);
            LabelAmountPaid.TabIndex = 69;
            LabelAmountPaid.Text = "Amount paid from funds since last deposit";
            // 
            // LabelCreditBalance
            // 
            LabelCreditBalance.AutoSize = true;
            LabelCreditBalance.BackColor = System.Drawing.Color.Transparent;
            LabelCreditBalance.Location = new System.Drawing.Point(27, 93);
            LabelCreditBalance.Name = "LabelCreditBalance";
            LabelCreditBalance.Size = new System.Drawing.Size(114, 13);
            LabelCreditBalance.TabIndex = 71;
            LabelCreditBalance.Text = "Current credit balance";
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.BackColor = System.Drawing.Color.Transparent;
            label35.Location = new System.Drawing.Point(397, 16);
            label35.Name = "label35";
            label35.Size = new System.Drawing.Size(105, 13);
            label35.TabIndex = 76;
            label35.Text = "Deposit transactions";
            // 
            // sRT3Label
            // 
            sRT3Label.AutoSize = true;
            sRT3Label.BackColor = System.Drawing.Color.Transparent;
            sRT3Label.Location = new System.Drawing.Point(321, 53);
            sRT3Label.Name = "sRT3Label";
            sRT3Label.Size = new System.Drawing.Size(57, 13);
            sRT3Label.TabIndex = 87;
            sRT3Label.Text = "Sub-group";
            // 
            // sRT2Label
            // 
            sRT2Label.AutoSize = true;
            sRT2Label.BackColor = System.Drawing.Color.Transparent;
            sRT2Label.Location = new System.Drawing.Point(36, 53);
            sRT2Label.Name = "sRT2Label";
            sRT2Label.Size = new System.Drawing.Size(36, 13);
            sRT2Label.TabIndex = 88;
            sRT2Label.Text = "Group";
            // 
            // LabelPaymentDue
            // 
            LabelPaymentDue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            LabelPaymentDue.AutoSize = true;
            LabelPaymentDue.BackColor = System.Drawing.Color.Transparent;
            LabelPaymentDue.Location = new System.Drawing.Point(395, 252);
            LabelPaymentDue.Name = "LabelPaymentDue";
            LabelPaymentDue.Size = new System.Drawing.Size(146, 13);
            LabelPaymentDue.TabIndex = 80;
            LabelPaymentDue.Text = "Payment due date based on:";
            // 
            // LabelPaymentProfileStatus
            // 
            this.LabelPaymentProfileStatus.AutoSize = true;
            this.LabelPaymentProfileStatus.Location = new System.Drawing.Point(21, 5);
            this.LabelPaymentProfileStatus.Name = "LabelPaymentProfileStatus";
            this.LabelPaymentProfileStatus.Size = new System.Drawing.Size(0, 13);
            this.LabelPaymentProfileStatus.TabIndex = 6;
            // 
            // LabelDate
            // 
            this.LabelDate.AutoSize = true;
            this.LabelDate.BackColor = System.Drawing.Color.Transparent;
            this.LabelDate.Location = new System.Drawing.Point(464, 17);
            this.LabelDate.Name = "LabelDate";
            this.LabelDate.Size = new System.Drawing.Size(30, 13);
            this.LabelDate.TabIndex = 0;
            this.LabelDate.Text = "Date";
            // 
            // LabelAgency
            // 
            this.LabelAgency.AutoSize = true;
            this.LabelAgency.BackColor = System.Drawing.Color.Transparent;
            this.LabelAgency.Location = new System.Drawing.Point(154, 17);
            this.LabelAgency.Name = "LabelAgency";
            this.LabelAgency.Size = new System.Drawing.Size(43, 13);
            this.LabelAgency.TabIndex = 0;
            this.LabelAgency.Text = "Agency";
            // 
            // GridControlLookup
            // 
            this.GridControlLookup.DataSource = this.EntityInstantFeedbackSource;
            this.GridControlLookup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControlLookup.Location = new System.Drawing.Point(0, 0);
            this.GridControlLookup.MainView = this.GridViewLookup;
            this.GridControlLookup.Name = "GridControlLookup";
            this.GridControlLookup.Size = new System.Drawing.Size(190, 642);
            this.GridControlLookup.TabIndex = 16;
            this.GridControlLookup.TabStop = false;
            this.GridControlLookup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewLookup});
            // 
            // EntityInstantFeedbackSource
            // 
            this.EntityInstantFeedbackSource.DesignTimeElementType = typeof(FlexModel.AGY);
            this.EntityInstantFeedbackSource.KeyExpression = "NO";
            this.EntityInstantFeedbackSource.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.EntityInstantFeedbackSource_GetQueryable);
            this.EntityInstantFeedbackSource.DismissQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.EntityInstantFeedbackSource_DismissQueryable);
            // 
            // GridViewLookup
            // 
            this.GridViewLookup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNO,
            this.colNAME,
            this.colLAST_UPD,
            this.colUPD_INIT,
            this.colTYP,
            this.colAP,
            this.colAR,
            this.colADDR1,
            this.colADDR2,
            this.colADDR3,
            this.colPHONE1,
            this.colCONSORT,
            this.colCOMM,
            this.colSTATE1,
            this.colSRT2,
            this.colSRT3,
            this.colDEF_LANG,
            this.colREL,
            this.colFAX_NUM,
            this.colPMT_DAYS,
            this.colACTIVE_FLG,
            this.colIMMED_FLG,
            this.colINV_FMT,
            this.colPRIOR_DAYS,
            this.colLAST_INV,
            this.colDAYS_SPACE,
            this.colSVCDTE_FLG,
            this.colFAX_ID,
            this.colOPT_DAYS,
            this.colSUB_ALLOC,
            this.colMAILFAX_FLG,
            this.colREM_CHG,
            this.colCONF_PRC,
            this.colEMAIL1,
            this.colCXL1_NTSPRIOR,
            this.colCXL1_PCT,
            this.colCXL1_FLAT,
            this.colCHG1_NTSPRIOR,
            this.colCHG1_PCT,
            this.colCHG1_FLAT,
            this.colCXL2_NTSPRIOR,
            this.colCXL2_PCT,
            this.colCXL2_FLAT,
            this.colCHG2_NTSPRIOR,
            this.colCHG2_PCT,
            this.colCHG2_FLAT,
            this.colCXL3_NTSPRIOR,
            this.colCXL3_PCT,
            this.colCXL3_FLAT,
            this.colCHG3_NTSPRIOR,
            this.colCHG3_PCT,
            this.colCHG3_FLAT,
            this.colCXLGRACE,
            this.colARVBKDAYS,
            this.colRETREQHTLS,
            this.colRETNOTAVALHTLS,
            this.colEDITHTLS,
            this.colEDITHDRS,
            this.colSIMPLEAVAL,
            this.colGMACCTNO1,
            this.colREMOTE_VOUCHERS,
            this.colVOUCHER_DAYS_PRIOR,
            this.colVOUCHER_REPRINTS,
            this.colLOGO_PATH,
            this.colCOUNTRY1,
            this.colPARENT,
            this.colCITY1,
            this.colZIP1,
            this.colWEBSITE,
            this.colUSER_DEC11,
            this.colUSER_DEC21,
            this.colUSER_INT11,
            this.colUSER_INT21,
            this.colUSER_TXT11,
            this.colUSER_TXT21,
            this.colUSER_TXT31,
            this.colUSER_TXT41,
            this.colUSER_DTE11,
            this.colUSER_DTE21,
            this.colVOUCH_TYPES,
            this.colALLOW_ATTACHMENTS,
            this.colDUE_DAY,
            this.colLanguage_Code,
            this.colShowAllLanguages,
            this.colTourfaxEmailFormat,
            this.colPaymentProcessorCustProfileId,
            this.colPaymentProcessorCustProfileEmail,
            this.colDefaultPaymentProfileId,
            this.colCreditLimit,
            this.colCreditLimitRemainingWarningPct,
            this.colCreditUnlimited,
            this.colRequireCVV2Number,
            this.colAGCYLOG,
            this.colCOUNTRY11,
            this.colLANGUAGE,
            this.colLANGUAGE1,
            this.colCOMPROD,
            this.colCOMPROD2,
            this.colCPRATES,
            this.colCXLFEE,
            this.colHOTEL,
            this.colINVT,
            this.colPRATES,
            this.colSVCRESTR,
            this.colSYSFILE,
            this.colSYSFILE1,
            this.colCOMPROD21,
            this.colhrates2,
            this.colhrates3,
            this.colHRATES,
            this.colPaymentTransaction,
            this.colAgencyPaymentProfile,
            this.colImagesRoot,
            this.colDisplayName1});
            this.GridViewLookup.DetailHeight = 198;
            this.GridViewLookup.FixedLineWidth = 1;
            this.GridViewLookup.GridControl = this.GridControlLookup;
            this.GridViewLookup.Name = "GridViewLookup";
            this.GridViewLookup.OptionsMenu.EnableFooterMenu = false;
            this.GridViewLookup.OptionsView.ShowAutoFilterRow = true;
            this.GridViewLookup.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.GridViewLookup.OptionsView.ShowGroupPanel = false;
            this.GridViewLookup.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewLookup_FocusedRowChanged);
            this.GridViewLookup.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.GridViewLookup_BeforeLeaveRow);
            this.GridViewLookup.AsyncCompleted += new System.EventHandler(this.GridViewLookup_AsyncCompleted);
            // 
            // colNO
            // 
            this.colNO.Caption = "Code";
            this.colNO.FieldName = "NO";
            this.colNO.MinWidth = 12;
            this.colNO.Name = "colNO";
            this.colNO.OptionsColumn.AllowEdit = false;
            this.colNO.Visible = true;
            this.colNO.VisibleIndex = 0;
            this.colNO.Width = 45;
            // 
            // colNAME
            // 
            this.colNAME.Caption = "Name";
            this.colNAME.FieldName = "NAME";
            this.colNAME.MinWidth = 12;
            this.colNAME.Name = "colNAME";
            this.colNAME.OptionsColumn.AllowEdit = false;
            this.colNAME.Visible = true;
            this.colNAME.VisibleIndex = 1;
            this.colNAME.Width = 45;
            // 
            // colLAST_UPD
            // 
            this.colLAST_UPD.FieldName = "LAST_UPD";
            this.colLAST_UPD.MinWidth = 12;
            this.colLAST_UPD.Name = "colLAST_UPD";
            this.colLAST_UPD.Width = 45;
            // 
            // colUPD_INIT
            // 
            this.colUPD_INIT.FieldName = "UPD_INIT";
            this.colUPD_INIT.MinWidth = 12;
            this.colUPD_INIT.Name = "colUPD_INIT";
            this.colUPD_INIT.Width = 45;
            // 
            // colTYP
            // 
            this.colTYP.FieldName = "TYP";
            this.colTYP.MinWidth = 12;
            this.colTYP.Name = "colTYP";
            this.colTYP.Width = 45;
            // 
            // colAP
            // 
            this.colAP.FieldName = "AP";
            this.colAP.MinWidth = 12;
            this.colAP.Name = "colAP";
            this.colAP.Width = 45;
            // 
            // colAR
            // 
            this.colAR.FieldName = "AR";
            this.colAR.MinWidth = 12;
            this.colAR.Name = "colAR";
            this.colAR.Width = 45;
            // 
            // colADDR1
            // 
            this.colADDR1.FieldName = "ADDR1";
            this.colADDR1.MinWidth = 12;
            this.colADDR1.Name = "colADDR1";
            this.colADDR1.Width = 45;
            // 
            // colADDR2
            // 
            this.colADDR2.FieldName = "ADDR2";
            this.colADDR2.MinWidth = 12;
            this.colADDR2.Name = "colADDR2";
            this.colADDR2.Width = 45;
            // 
            // colADDR3
            // 
            this.colADDR3.FieldName = "ADDR3";
            this.colADDR3.MinWidth = 12;
            this.colADDR3.Name = "colADDR3";
            this.colADDR3.Width = 45;
            // 
            // colPHONE1
            // 
            this.colPHONE1.FieldName = "PHONE";
            this.colPHONE1.MinWidth = 12;
            this.colPHONE1.Name = "colPHONE1";
            this.colPHONE1.Width = 45;
            // 
            // colCONSORT
            // 
            this.colCONSORT.FieldName = "CONSORT";
            this.colCONSORT.MinWidth = 12;
            this.colCONSORT.Name = "colCONSORT";
            this.colCONSORT.Width = 45;
            // 
            // colCOMM
            // 
            this.colCOMM.FieldName = "COMM";
            this.colCOMM.MinWidth = 12;
            this.colCOMM.Name = "colCOMM";
            this.colCOMM.Width = 45;
            // 
            // colSTATE1
            // 
            this.colSTATE1.FieldName = "STATE";
            this.colSTATE1.MinWidth = 12;
            this.colSTATE1.Name = "colSTATE1";
            this.colSTATE1.Width = 45;
            // 
            // colSRT2
            // 
            this.colSRT2.FieldName = "SRT2";
            this.colSRT2.MinWidth = 12;
            this.colSRT2.Name = "colSRT2";
            this.colSRT2.Width = 45;
            // 
            // colSRT3
            // 
            this.colSRT3.FieldName = "SRT3";
            this.colSRT3.MinWidth = 12;
            this.colSRT3.Name = "colSRT3";
            this.colSRT3.Width = 45;
            // 
            // colDEF_LANG
            // 
            this.colDEF_LANG.FieldName = "DEF_LANG";
            this.colDEF_LANG.MinWidth = 12;
            this.colDEF_LANG.Name = "colDEF_LANG";
            this.colDEF_LANG.Width = 45;
            // 
            // colREL
            // 
            this.colREL.FieldName = "REL";
            this.colREL.MinWidth = 12;
            this.colREL.Name = "colREL";
            this.colREL.Width = 45;
            // 
            // colFAX_NUM
            // 
            this.colFAX_NUM.FieldName = "FAX_NUM";
            this.colFAX_NUM.MinWidth = 12;
            this.colFAX_NUM.Name = "colFAX_NUM";
            this.colFAX_NUM.Width = 45;
            // 
            // colPMT_DAYS
            // 
            this.colPMT_DAYS.FieldName = "PMT_DAYS";
            this.colPMT_DAYS.MinWidth = 12;
            this.colPMT_DAYS.Name = "colPMT_DAYS";
            this.colPMT_DAYS.Width = 45;
            // 
            // colACTIVE_FLG
            // 
            this.colACTIVE_FLG.FieldName = "ACTIVE_FLG";
            this.colACTIVE_FLG.MinWidth = 12;
            this.colACTIVE_FLG.Name = "colACTIVE_FLG";
            this.colACTIVE_FLG.Width = 45;
            // 
            // colIMMED_FLG
            // 
            this.colIMMED_FLG.FieldName = "IMMED_FLG";
            this.colIMMED_FLG.MinWidth = 12;
            this.colIMMED_FLG.Name = "colIMMED_FLG";
            this.colIMMED_FLG.Width = 45;
            // 
            // colINV_FMT
            // 
            this.colINV_FMT.FieldName = "INV_FMT";
            this.colINV_FMT.MinWidth = 12;
            this.colINV_FMT.Name = "colINV_FMT";
            this.colINV_FMT.Width = 45;
            // 
            // colPRIOR_DAYS
            // 
            this.colPRIOR_DAYS.FieldName = "PRIOR_DAYS";
            this.colPRIOR_DAYS.MinWidth = 12;
            this.colPRIOR_DAYS.Name = "colPRIOR_DAYS";
            this.colPRIOR_DAYS.Width = 45;
            // 
            // colLAST_INV
            // 
            this.colLAST_INV.FieldName = "LAST_INV";
            this.colLAST_INV.MinWidth = 12;
            this.colLAST_INV.Name = "colLAST_INV";
            this.colLAST_INV.Width = 45;
            // 
            // colDAYS_SPACE
            // 
            this.colDAYS_SPACE.FieldName = "DAYS_SPACE";
            this.colDAYS_SPACE.MinWidth = 12;
            this.colDAYS_SPACE.Name = "colDAYS_SPACE";
            this.colDAYS_SPACE.Width = 45;
            // 
            // colSVCDTE_FLG
            // 
            this.colSVCDTE_FLG.FieldName = "SVCDTE_FLG";
            this.colSVCDTE_FLG.MinWidth = 12;
            this.colSVCDTE_FLG.Name = "colSVCDTE_FLG";
            this.colSVCDTE_FLG.Width = 45;
            // 
            // colFAX_ID
            // 
            this.colFAX_ID.FieldName = "FAX_ID";
            this.colFAX_ID.MinWidth = 12;
            this.colFAX_ID.Name = "colFAX_ID";
            this.colFAX_ID.Width = 45;
            // 
            // colOPT_DAYS
            // 
            this.colOPT_DAYS.FieldName = "OPT_DAYS";
            this.colOPT_DAYS.MinWidth = 12;
            this.colOPT_DAYS.Name = "colOPT_DAYS";
            this.colOPT_DAYS.Width = 45;
            // 
            // colSUB_ALLOC
            // 
            this.colSUB_ALLOC.FieldName = "SUB_ALLOC";
            this.colSUB_ALLOC.MinWidth = 12;
            this.colSUB_ALLOC.Name = "colSUB_ALLOC";
            this.colSUB_ALLOC.Width = 45;
            // 
            // colMAILFAX_FLG
            // 
            this.colMAILFAX_FLG.FieldName = "MAILFAX_FLG";
            this.colMAILFAX_FLG.MinWidth = 12;
            this.colMAILFAX_FLG.Name = "colMAILFAX_FLG";
            this.colMAILFAX_FLG.Width = 45;
            // 
            // colREM_CHG
            // 
            this.colREM_CHG.FieldName = "REM_CHG";
            this.colREM_CHG.MinWidth = 12;
            this.colREM_CHG.Name = "colREM_CHG";
            this.colREM_CHG.Width = 45;
            // 
            // colCONF_PRC
            // 
            this.colCONF_PRC.FieldName = "CONF_PRC";
            this.colCONF_PRC.MinWidth = 12;
            this.colCONF_PRC.Name = "colCONF_PRC";
            this.colCONF_PRC.Width = 45;
            // 
            // colEMAIL1
            // 
            this.colEMAIL1.FieldName = "EMAIL";
            this.colEMAIL1.MinWidth = 12;
            this.colEMAIL1.Name = "colEMAIL1";
            this.colEMAIL1.Width = 45;
            // 
            // colCXL1_NTSPRIOR
            // 
            this.colCXL1_NTSPRIOR.FieldName = "CXL1_NTSPRIOR";
            this.colCXL1_NTSPRIOR.MinWidth = 12;
            this.colCXL1_NTSPRIOR.Name = "colCXL1_NTSPRIOR";
            this.colCXL1_NTSPRIOR.Width = 45;
            // 
            // colCXL1_PCT
            // 
            this.colCXL1_PCT.FieldName = "CXL1_PCT";
            this.colCXL1_PCT.MinWidth = 12;
            this.colCXL1_PCT.Name = "colCXL1_PCT";
            this.colCXL1_PCT.Width = 45;
            // 
            // colCXL1_FLAT
            // 
            this.colCXL1_FLAT.FieldName = "CXL1_FLAT";
            this.colCXL1_FLAT.MinWidth = 12;
            this.colCXL1_FLAT.Name = "colCXL1_FLAT";
            this.colCXL1_FLAT.Width = 45;
            // 
            // colCHG1_NTSPRIOR
            // 
            this.colCHG1_NTSPRIOR.FieldName = "CHG1_NTSPRIOR";
            this.colCHG1_NTSPRIOR.MinWidth = 12;
            this.colCHG1_NTSPRIOR.Name = "colCHG1_NTSPRIOR";
            this.colCHG1_NTSPRIOR.Width = 45;
            // 
            // colCHG1_PCT
            // 
            this.colCHG1_PCT.FieldName = "CHG1_PCT";
            this.colCHG1_PCT.MinWidth = 12;
            this.colCHG1_PCT.Name = "colCHG1_PCT";
            this.colCHG1_PCT.Width = 45;
            // 
            // colCHG1_FLAT
            // 
            this.colCHG1_FLAT.FieldName = "CHG1_FLAT";
            this.colCHG1_FLAT.MinWidth = 12;
            this.colCHG1_FLAT.Name = "colCHG1_FLAT";
            this.colCHG1_FLAT.Width = 45;
            // 
            // colCXL2_NTSPRIOR
            // 
            this.colCXL2_NTSPRIOR.FieldName = "CXL2_NTSPRIOR";
            this.colCXL2_NTSPRIOR.MinWidth = 12;
            this.colCXL2_NTSPRIOR.Name = "colCXL2_NTSPRIOR";
            this.colCXL2_NTSPRIOR.Width = 45;
            // 
            // colCXL2_PCT
            // 
            this.colCXL2_PCT.FieldName = "CXL2_PCT";
            this.colCXL2_PCT.MinWidth = 12;
            this.colCXL2_PCT.Name = "colCXL2_PCT";
            this.colCXL2_PCT.Width = 45;
            // 
            // colCXL2_FLAT
            // 
            this.colCXL2_FLAT.FieldName = "CXL2_FLAT";
            this.colCXL2_FLAT.MinWidth = 12;
            this.colCXL2_FLAT.Name = "colCXL2_FLAT";
            this.colCXL2_FLAT.Width = 45;
            // 
            // colCHG2_NTSPRIOR
            // 
            this.colCHG2_NTSPRIOR.FieldName = "CHG2_NTSPRIOR";
            this.colCHG2_NTSPRIOR.MinWidth = 12;
            this.colCHG2_NTSPRIOR.Name = "colCHG2_NTSPRIOR";
            this.colCHG2_NTSPRIOR.Width = 45;
            // 
            // colCHG2_PCT
            // 
            this.colCHG2_PCT.FieldName = "CHG2_PCT";
            this.colCHG2_PCT.MinWidth = 12;
            this.colCHG2_PCT.Name = "colCHG2_PCT";
            this.colCHG2_PCT.Width = 45;
            // 
            // colCHG2_FLAT
            // 
            this.colCHG2_FLAT.FieldName = "CHG2_FLAT";
            this.colCHG2_FLAT.MinWidth = 12;
            this.colCHG2_FLAT.Name = "colCHG2_FLAT";
            this.colCHG2_FLAT.Width = 45;
            // 
            // colCXL3_NTSPRIOR
            // 
            this.colCXL3_NTSPRIOR.FieldName = "CXL3_NTSPRIOR";
            this.colCXL3_NTSPRIOR.MinWidth = 12;
            this.colCXL3_NTSPRIOR.Name = "colCXL3_NTSPRIOR";
            this.colCXL3_NTSPRIOR.Width = 45;
            // 
            // colCXL3_PCT
            // 
            this.colCXL3_PCT.FieldName = "CXL3_PCT";
            this.colCXL3_PCT.MinWidth = 12;
            this.colCXL3_PCT.Name = "colCXL3_PCT";
            this.colCXL3_PCT.Width = 45;
            // 
            // colCXL3_FLAT
            // 
            this.colCXL3_FLAT.FieldName = "CXL3_FLAT";
            this.colCXL3_FLAT.MinWidth = 12;
            this.colCXL3_FLAT.Name = "colCXL3_FLAT";
            this.colCXL3_FLAT.Width = 45;
            // 
            // colCHG3_NTSPRIOR
            // 
            this.colCHG3_NTSPRIOR.FieldName = "CHG3_NTSPRIOR";
            this.colCHG3_NTSPRIOR.MinWidth = 12;
            this.colCHG3_NTSPRIOR.Name = "colCHG3_NTSPRIOR";
            this.colCHG3_NTSPRIOR.Width = 45;
            // 
            // colCHG3_PCT
            // 
            this.colCHG3_PCT.FieldName = "CHG3_PCT";
            this.colCHG3_PCT.MinWidth = 12;
            this.colCHG3_PCT.Name = "colCHG3_PCT";
            this.colCHG3_PCT.Width = 45;
            // 
            // colCHG3_FLAT
            // 
            this.colCHG3_FLAT.FieldName = "CHG3_FLAT";
            this.colCHG3_FLAT.MinWidth = 12;
            this.colCHG3_FLAT.Name = "colCHG3_FLAT";
            this.colCHG3_FLAT.Width = 45;
            // 
            // colCXLGRACE
            // 
            this.colCXLGRACE.FieldName = "CXLGRACE";
            this.colCXLGRACE.MinWidth = 12;
            this.colCXLGRACE.Name = "colCXLGRACE";
            this.colCXLGRACE.Width = 45;
            // 
            // colARVBKDAYS
            // 
            this.colARVBKDAYS.FieldName = "ARVBKDAYS";
            this.colARVBKDAYS.MinWidth = 12;
            this.colARVBKDAYS.Name = "colARVBKDAYS";
            this.colARVBKDAYS.Width = 45;
            // 
            // colRETREQHTLS
            // 
            this.colRETREQHTLS.FieldName = "RETREQHTLS";
            this.colRETREQHTLS.MinWidth = 12;
            this.colRETREQHTLS.Name = "colRETREQHTLS";
            this.colRETREQHTLS.Width = 45;
            // 
            // colRETNOTAVALHTLS
            // 
            this.colRETNOTAVALHTLS.FieldName = "RETNOTAVALHTLS";
            this.colRETNOTAVALHTLS.MinWidth = 12;
            this.colRETNOTAVALHTLS.Name = "colRETNOTAVALHTLS";
            this.colRETNOTAVALHTLS.Width = 45;
            // 
            // colEDITHTLS
            // 
            this.colEDITHTLS.FieldName = "EDITHTLS";
            this.colEDITHTLS.MinWidth = 12;
            this.colEDITHTLS.Name = "colEDITHTLS";
            this.colEDITHTLS.Width = 45;
            // 
            // colEDITHDRS
            // 
            this.colEDITHDRS.FieldName = "EDITHDRS";
            this.colEDITHDRS.MinWidth = 12;
            this.colEDITHDRS.Name = "colEDITHDRS";
            this.colEDITHDRS.Width = 45;
            // 
            // colSIMPLEAVAL
            // 
            this.colSIMPLEAVAL.FieldName = "SIMPLEAVAL";
            this.colSIMPLEAVAL.MinWidth = 12;
            this.colSIMPLEAVAL.Name = "colSIMPLEAVAL";
            this.colSIMPLEAVAL.Width = 45;
            // 
            // colGMACCTNO1
            // 
            this.colGMACCTNO1.FieldName = "GMACCTNO";
            this.colGMACCTNO1.MinWidth = 12;
            this.colGMACCTNO1.Name = "colGMACCTNO1";
            this.colGMACCTNO1.Width = 45;
            // 
            // colREMOTE_VOUCHERS
            // 
            this.colREMOTE_VOUCHERS.FieldName = "REMOTE_VOUCHERS";
            this.colREMOTE_VOUCHERS.MinWidth = 12;
            this.colREMOTE_VOUCHERS.Name = "colREMOTE_VOUCHERS";
            this.colREMOTE_VOUCHERS.Width = 45;
            // 
            // colVOUCHER_DAYS_PRIOR
            // 
            this.colVOUCHER_DAYS_PRIOR.FieldName = "VOUCHER_DAYS_PRIOR";
            this.colVOUCHER_DAYS_PRIOR.MinWidth = 12;
            this.colVOUCHER_DAYS_PRIOR.Name = "colVOUCHER_DAYS_PRIOR";
            this.colVOUCHER_DAYS_PRIOR.Width = 45;
            // 
            // colVOUCHER_REPRINTS
            // 
            this.colVOUCHER_REPRINTS.FieldName = "VOUCHER_REPRINTS";
            this.colVOUCHER_REPRINTS.MinWidth = 12;
            this.colVOUCHER_REPRINTS.Name = "colVOUCHER_REPRINTS";
            this.colVOUCHER_REPRINTS.Width = 45;
            // 
            // colLOGO_PATH
            // 
            this.colLOGO_PATH.FieldName = "LOGO_PATH";
            this.colLOGO_PATH.MinWidth = 12;
            this.colLOGO_PATH.Name = "colLOGO_PATH";
            this.colLOGO_PATH.Width = 45;
            // 
            // colCOUNTRY1
            // 
            this.colCOUNTRY1.FieldName = "COUNTRY";
            this.colCOUNTRY1.MinWidth = 12;
            this.colCOUNTRY1.Name = "colCOUNTRY1";
            this.colCOUNTRY1.Width = 45;
            // 
            // colPARENT
            // 
            this.colPARENT.FieldName = "PARENT";
            this.colPARENT.MinWidth = 12;
            this.colPARENT.Name = "colPARENT";
            this.colPARENT.Width = 45;
            // 
            // colCITY1
            // 
            this.colCITY1.FieldName = "CITY";
            this.colCITY1.MinWidth = 12;
            this.colCITY1.Name = "colCITY1";
            this.colCITY1.Width = 45;
            // 
            // colZIP1
            // 
            this.colZIP1.FieldName = "ZIP";
            this.colZIP1.MinWidth = 12;
            this.colZIP1.Name = "colZIP1";
            this.colZIP1.Width = 45;
            // 
            // colWEBSITE
            // 
            this.colWEBSITE.FieldName = "WEBSITE";
            this.colWEBSITE.MinWidth = 12;
            this.colWEBSITE.Name = "colWEBSITE";
            this.colWEBSITE.Width = 45;
            // 
            // colUSER_DEC11
            // 
            this.colUSER_DEC11.FieldName = "USER_DEC1";
            this.colUSER_DEC11.MinWidth = 12;
            this.colUSER_DEC11.Name = "colUSER_DEC11";
            this.colUSER_DEC11.Width = 45;
            // 
            // colUSER_DEC21
            // 
            this.colUSER_DEC21.FieldName = "USER_DEC2";
            this.colUSER_DEC21.MinWidth = 12;
            this.colUSER_DEC21.Name = "colUSER_DEC21";
            this.colUSER_DEC21.Width = 45;
            // 
            // colUSER_INT11
            // 
            this.colUSER_INT11.FieldName = "USER_INT1";
            this.colUSER_INT11.MinWidth = 12;
            this.colUSER_INT11.Name = "colUSER_INT11";
            this.colUSER_INT11.Width = 45;
            // 
            // colUSER_INT21
            // 
            this.colUSER_INT21.FieldName = "USER_INT2";
            this.colUSER_INT21.MinWidth = 12;
            this.colUSER_INT21.Name = "colUSER_INT21";
            this.colUSER_INT21.Width = 45;
            // 
            // colUSER_TXT11
            // 
            this.colUSER_TXT11.FieldName = "USER_TXT1";
            this.colUSER_TXT11.MinWidth = 12;
            this.colUSER_TXT11.Name = "colUSER_TXT11";
            this.colUSER_TXT11.Width = 45;
            // 
            // colUSER_TXT21
            // 
            this.colUSER_TXT21.FieldName = "USER_TXT2";
            this.colUSER_TXT21.MinWidth = 12;
            this.colUSER_TXT21.Name = "colUSER_TXT21";
            this.colUSER_TXT21.Width = 45;
            // 
            // colUSER_TXT31
            // 
            this.colUSER_TXT31.FieldName = "USER_TXT3";
            this.colUSER_TXT31.MinWidth = 12;
            this.colUSER_TXT31.Name = "colUSER_TXT31";
            this.colUSER_TXT31.Width = 45;
            // 
            // colUSER_TXT41
            // 
            this.colUSER_TXT41.FieldName = "USER_TXT4";
            this.colUSER_TXT41.MinWidth = 12;
            this.colUSER_TXT41.Name = "colUSER_TXT41";
            this.colUSER_TXT41.Width = 45;
            // 
            // colUSER_DTE11
            // 
            this.colUSER_DTE11.FieldName = "USER_DTE1";
            this.colUSER_DTE11.MinWidth = 12;
            this.colUSER_DTE11.Name = "colUSER_DTE11";
            this.colUSER_DTE11.Width = 45;
            // 
            // colUSER_DTE21
            // 
            this.colUSER_DTE21.FieldName = "USER_DTE2";
            this.colUSER_DTE21.MinWidth = 12;
            this.colUSER_DTE21.Name = "colUSER_DTE21";
            this.colUSER_DTE21.Width = 45;
            // 
            // colVOUCH_TYPES
            // 
            this.colVOUCH_TYPES.FieldName = "VOUCH_TYPES";
            this.colVOUCH_TYPES.MinWidth = 12;
            this.colVOUCH_TYPES.Name = "colVOUCH_TYPES";
            this.colVOUCH_TYPES.Width = 45;
            // 
            // colALLOW_ATTACHMENTS
            // 
            this.colALLOW_ATTACHMENTS.FieldName = "ALLOW_ATTACHMENTS";
            this.colALLOW_ATTACHMENTS.MinWidth = 12;
            this.colALLOW_ATTACHMENTS.Name = "colALLOW_ATTACHMENTS";
            this.colALLOW_ATTACHMENTS.Width = 45;
            // 
            // colDUE_DAY
            // 
            this.colDUE_DAY.FieldName = "DUE_DAY";
            this.colDUE_DAY.MinWidth = 12;
            this.colDUE_DAY.Name = "colDUE_DAY";
            this.colDUE_DAY.Width = 45;
            // 
            // colLanguage_Code
            // 
            this.colLanguage_Code.FieldName = "Language_Code";
            this.colLanguage_Code.MinWidth = 12;
            this.colLanguage_Code.Name = "colLanguage_Code";
            this.colLanguage_Code.Width = 45;
            // 
            // colShowAllLanguages
            // 
            this.colShowAllLanguages.FieldName = "ShowAllLanguages";
            this.colShowAllLanguages.MinWidth = 12;
            this.colShowAllLanguages.Name = "colShowAllLanguages";
            this.colShowAllLanguages.Width = 45;
            // 
            // colTourfaxEmailFormat
            // 
            this.colTourfaxEmailFormat.FieldName = "TourfaxEmailFormat";
            this.colTourfaxEmailFormat.MinWidth = 12;
            this.colTourfaxEmailFormat.Name = "colTourfaxEmailFormat";
            this.colTourfaxEmailFormat.Width = 45;
            // 
            // colPaymentProcessorCustProfileId
            // 
            this.colPaymentProcessorCustProfileId.FieldName = "PaymentProcessorCustProfileId";
            this.colPaymentProcessorCustProfileId.MinWidth = 12;
            this.colPaymentProcessorCustProfileId.Name = "colPaymentProcessorCustProfileId";
            this.colPaymentProcessorCustProfileId.Width = 45;
            // 
            // colPaymentProcessorCustProfileEmail
            // 
            this.colPaymentProcessorCustProfileEmail.FieldName = "PaymentProcessorCustProfileEmail";
            this.colPaymentProcessorCustProfileEmail.MinWidth = 12;
            this.colPaymentProcessorCustProfileEmail.Name = "colPaymentProcessorCustProfileEmail";
            this.colPaymentProcessorCustProfileEmail.Width = 45;
            // 
            // colDefaultPaymentProfileId
            // 
            this.colDefaultPaymentProfileId.FieldName = "DefaultPaymentProfileId";
            this.colDefaultPaymentProfileId.MinWidth = 12;
            this.colDefaultPaymentProfileId.Name = "colDefaultPaymentProfileId";
            this.colDefaultPaymentProfileId.Width = 45;
            // 
            // colCreditLimit
            // 
            this.colCreditLimit.FieldName = "CreditLimit";
            this.colCreditLimit.MinWidth = 12;
            this.colCreditLimit.Name = "colCreditLimit";
            this.colCreditLimit.Width = 45;
            // 
            // colCreditLimitRemainingWarningPct
            // 
            this.colCreditLimitRemainingWarningPct.FieldName = "CreditLimitRemainingWarningPct";
            this.colCreditLimitRemainingWarningPct.MinWidth = 12;
            this.colCreditLimitRemainingWarningPct.Name = "colCreditLimitRemainingWarningPct";
            this.colCreditLimitRemainingWarningPct.Width = 45;
            // 
            // colCreditUnlimited
            // 
            this.colCreditUnlimited.FieldName = "CreditUnlimited";
            this.colCreditUnlimited.MinWidth = 12;
            this.colCreditUnlimited.Name = "colCreditUnlimited";
            this.colCreditUnlimited.Width = 45;
            // 
            // colRequireCVV2Number
            // 
            this.colRequireCVV2Number.FieldName = "RequireCVV2Number";
            this.colRequireCVV2Number.MinWidth = 12;
            this.colRequireCVV2Number.Name = "colRequireCVV2Number";
            this.colRequireCVV2Number.Width = 45;
            // 
            // colAGCYLOG
            // 
            this.colAGCYLOG.FieldName = "AGCYLOG";
            this.colAGCYLOG.MinWidth = 12;
            this.colAGCYLOG.Name = "colAGCYLOG";
            this.colAGCYLOG.Width = 45;
            // 
            // colCOUNTRY11
            // 
            this.colCOUNTRY11.FieldName = "COUNTRY1";
            this.colCOUNTRY11.MinWidth = 12;
            this.colCOUNTRY11.Name = "colCOUNTRY11";
            this.colCOUNTRY11.Width = 45;
            // 
            // colLANGUAGE
            // 
            this.colLANGUAGE.FieldName = "LANGUAGE";
            this.colLANGUAGE.MinWidth = 12;
            this.colLANGUAGE.Name = "colLANGUAGE";
            this.colLANGUAGE.Width = 45;
            // 
            // colLANGUAGE1
            // 
            this.colLANGUAGE1.FieldName = "LANGUAGE1";
            this.colLANGUAGE1.MinWidth = 12;
            this.colLANGUAGE1.Name = "colLANGUAGE1";
            this.colLANGUAGE1.Width = 45;
            // 
            // colCOMPROD
            // 
            this.colCOMPROD.FieldName = "COMPROD";
            this.colCOMPROD.MinWidth = 12;
            this.colCOMPROD.Name = "colCOMPROD";
            this.colCOMPROD.Width = 45;
            // 
            // colCOMPROD2
            // 
            this.colCOMPROD2.FieldName = "COMPROD2";
            this.colCOMPROD2.MinWidth = 12;
            this.colCOMPROD2.Name = "colCOMPROD2";
            this.colCOMPROD2.Width = 45;
            // 
            // colCPRATES
            // 
            this.colCPRATES.FieldName = "CPRATES";
            this.colCPRATES.MinWidth = 12;
            this.colCPRATES.Name = "colCPRATES";
            this.colCPRATES.Width = 45;
            // 
            // colCXLFEE
            // 
            this.colCXLFEE.FieldName = "CXLFEE";
            this.colCXLFEE.MinWidth = 12;
            this.colCXLFEE.Name = "colCXLFEE";
            this.colCXLFEE.Width = 45;
            // 
            // colHOTEL
            // 
            this.colHOTEL.FieldName = "HOTEL";
            this.colHOTEL.MinWidth = 12;
            this.colHOTEL.Name = "colHOTEL";
            this.colHOTEL.Width = 45;
            // 
            // colINVT
            // 
            this.colINVT.FieldName = "INVT";
            this.colINVT.MinWidth = 12;
            this.colINVT.Name = "colINVT";
            this.colINVT.Width = 45;
            // 
            // colPRATES
            // 
            this.colPRATES.FieldName = "PRATES";
            this.colPRATES.MinWidth = 12;
            this.colPRATES.Name = "colPRATES";
            this.colPRATES.Width = 45;
            // 
            // colSVCRESTR
            // 
            this.colSVCRESTR.FieldName = "SVCRESTR";
            this.colSVCRESTR.MinWidth = 12;
            this.colSVCRESTR.Name = "colSVCRESTR";
            this.colSVCRESTR.Width = 45;
            // 
            // colSYSFILE
            // 
            this.colSYSFILE.FieldName = "SYSFILE";
            this.colSYSFILE.MinWidth = 12;
            this.colSYSFILE.Name = "colSYSFILE";
            this.colSYSFILE.Width = 45;
            // 
            // colSYSFILE1
            // 
            this.colSYSFILE1.FieldName = "SYSFILE1";
            this.colSYSFILE1.MinWidth = 12;
            this.colSYSFILE1.Name = "colSYSFILE1";
            this.colSYSFILE1.Width = 45;
            // 
            // colCOMPROD21
            // 
            this.colCOMPROD21.FieldName = "COMPROD21";
            this.colCOMPROD21.MinWidth = 12;
            this.colCOMPROD21.Name = "colCOMPROD21";
            this.colCOMPROD21.Width = 45;
            // 
            // colhrates2
            // 
            this.colhrates2.FieldName = "hrates2";
            this.colhrates2.MinWidth = 12;
            this.colhrates2.Name = "colhrates2";
            this.colhrates2.Width = 45;
            // 
            // colhrates3
            // 
            this.colhrates3.FieldName = "hrates3";
            this.colhrates3.MinWidth = 12;
            this.colhrates3.Name = "colhrates3";
            this.colhrates3.Width = 45;
            // 
            // colHRATES
            // 
            this.colHRATES.FieldName = "HRATES";
            this.colHRATES.MinWidth = 12;
            this.colHRATES.Name = "colHRATES";
            this.colHRATES.Width = 45;
            // 
            // colPaymentTransaction
            // 
            this.colPaymentTransaction.FieldName = "PaymentTransaction";
            this.colPaymentTransaction.MinWidth = 12;
            this.colPaymentTransaction.Name = "colPaymentTransaction";
            this.colPaymentTransaction.Width = 45;
            // 
            // colAgencyPaymentProfile
            // 
            this.colAgencyPaymentProfile.FieldName = "AgencyPaymentProfile";
            this.colAgencyPaymentProfile.MinWidth = 12;
            this.colAgencyPaymentProfile.Name = "colAgencyPaymentProfile";
            this.colAgencyPaymentProfile.Width = 45;
            // 
            // colImagesRoot
            // 
            this.colImagesRoot.FieldName = "ImagesRoot";
            this.colImagesRoot.MinWidth = 12;
            this.colImagesRoot.Name = "colImagesRoot";
            this.colImagesRoot.Width = 45;
            // 
            // colDisplayName1
            // 
            this.colDisplayName1.FieldName = "DisplayName";
            this.colDisplayName1.MinWidth = 12;
            this.colDisplayName1.Name = "colDisplayName1";
            this.colDisplayName1.OptionsColumn.ReadOnly = true;
            this.colDisplayName1.Width = 45;
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(FlexModel.AGY);
            this.BindingSource.CurrentChanged += new System.EventHandler(this.BindingSource_CurrentChanged);
            this.BindingSource.PositionChanged += new System.EventHandler(this.AgyBindingSource_PositionChanged);
            // 
            // CheckEditActiveFlg
            // 
            this.CheckEditActiveFlg.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "ACTIVE_FLG", true));
            this.CheckEditActiveFlg.EnterMoveNextControl = true;
            this.CheckEditActiveFlg.Location = new System.Drawing.Point(350, 92);
            this.CheckEditActiveFlg.Name = "CheckEditActiveFlg";
            this.CheckEditActiveFlg.Properties.Caption = "Active";
            this.CheckEditActiveFlg.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditActiveFlg.Properties.ValueChecked = "A";
            this.CheckEditActiveFlg.Properties.ValueGrayed = "";
            this.CheckEditActiveFlg.Properties.ValueUnchecked = "I";
            this.CheckEditActiveFlg.Size = new System.Drawing.Size(56, 19);
            this.CheckEditActiveFlg.TabIndex = 7;
            this.CheckEditActiveFlg.EditValueChanged += new System.EventHandler(this.CheckEditActiveFlg_EditValueChanged);
            // 
            // XtraTabControlAgency
            // 
            this.XtraTabControlAgency.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.XtraTabControlAgency.Location = new System.Drawing.Point(21, 120);
            this.XtraTabControlAgency.Name = "XtraTabControlAgency";
            this.XtraTabControlAgency.SelectedTabPage = this.XtraTabPageLocation;
            this.XtraTabControlAgency.Size = new System.Drawing.Size(883, 527);
            this.XtraTabControlAgency.TabIndex = 31;
            this.XtraTabControlAgency.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.XtraTabPageLocation,
            this.XtraTabPageContacts,
            this.XtraTabPageAvailability,
            this.XtraTabPageReporting,
            this.XtraTabPagePolicies,
            this.XtraTabPageAccounting,
            this.XtraTabPagePayments,
            this.XtraTabPageAdministrativeFees,
            this.XtraTabPageMemberships,
            this.XtraTabPageResources,
            this.XtraTabPageCustom,
            this.XtraTabPageCommissions,
            this.XtraTabPageAgents});
            this.XtraTabControlAgency.TabStop = false;
            // 
            // XtraTabPageLocation
            // 
            this.XtraTabPageLocation.Controls.Add(this.PanelControlLocationTab);
            this.XtraTabPageLocation.Name = "XtraTabPageLocation";
            this.XtraTabPageLocation.Size = new System.Drawing.Size(877, 499);
            this.XtraTabPageLocation.Text = "Location";
            // 
            // PanelControlLocationTab
            // 
            this.PanelControlLocationTab.Controls.Add(this.TextEditCity);
            this.PanelControlLocationTab.Controls.Add(this.TextEditState);
            this.PanelControlLocationTab.Controls.Add(this.TextEditZip);
            this.PanelControlLocationTab.Controls.Add(cOUNTRYLabel);
            this.PanelControlLocationTab.Controls.Add(zIPLabel);
            this.PanelControlLocationTab.Controls.Add(sTATELabel);
            this.PanelControlLocationTab.Controls.Add(cITYLabel);
            this.PanelControlLocationTab.Controls.Add(this.TextEditAddr3);
            this.PanelControlLocationTab.Controls.Add(this.TextEditAddr2);
            this.PanelControlLocationTab.Controls.Add(aDDR1Label);
            this.PanelControlLocationTab.Controls.Add(this.TextEditAddr1);
            this.PanelControlLocationTab.Controls.Add(this.label1);
            this.PanelControlLocationTab.Controls.Add(this.SearchLookupEditCountry);
            this.PanelControlLocationTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelControlLocationTab.Location = new System.Drawing.Point(0, 0);
            this.PanelControlLocationTab.Name = "PanelControlLocationTab";
            this.PanelControlLocationTab.Size = new System.Drawing.Size(877, 499);
            this.PanelControlLocationTab.TabIndex = 0;
            // 
            // TextEditCity
            // 
            this.TextEditCity.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CITY", true));
            this.TextEditCity.EditValue = " ";
            this.TextEditCity.EnterMoveNextControl = true;
            this.TextEditCity.Location = new System.Drawing.Point(90, 187);
            this.TextEditCity.Name = "TextEditCity";
            this.TextEditCity.Properties.MaxLength = 30;
            this.TextEditCity.Size = new System.Drawing.Size(430, 20);
            this.TextEditCity.TabIndex = 11;
            this.TextEditCity.Leave += new System.EventHandler(this.ImageComboBoxEditCity_Leave);
            // 
            // TextEditState
            // 
            this.TextEditState.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "STATE", true));
            this.TextEditState.EnterMoveNextControl = true;
            this.TextEditState.Location = new System.Drawing.Point(90, 227);
            this.TextEditState.Name = "TextEditState";
            this.TextEditState.Properties.MaxLength = 20;
            this.TextEditState.Size = new System.Drawing.Size(257, 20);
            this.TextEditState.TabIndex = 12;
            this.TextEditState.Leave += new System.EventHandler(this.ImageComboBoxEditState_Leave);
            // 
            // TextEditZip
            // 
            this.TextEditZip.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "ZIP", true));
            this.TextEditZip.EnterMoveNextControl = true;
            this.TextEditZip.Location = new System.Drawing.Point(89, 270);
            this.TextEditZip.Name = "TextEditZip";
            this.TextEditZip.Properties.MaxLength = 10;
            this.TextEditZip.Size = new System.Drawing.Size(122, 20);
            this.TextEditZip.TabIndex = 13;
            this.TextEditZip.Leave += new System.EventHandler(this.TextEditZip_Leave);
            // 
            // TextEditAddr3
            // 
            this.TextEditAddr3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "ADDR3", true));
            this.TextEditAddr3.EnterMoveNextControl = true;
            this.TextEditAddr3.Location = new System.Drawing.Point(90, 142);
            this.TextEditAddr3.Name = "TextEditAddr3";
            this.TextEditAddr3.Properties.MaxLength = 30;
            this.TextEditAddr3.Size = new System.Drawing.Size(430, 20);
            this.TextEditAddr3.TabIndex = 10;
            this.TextEditAddr3.Leave += new System.EventHandler(this.TextEditAddress3_Leave);
            // 
            // TextEditAddr2
            // 
            this.TextEditAddr2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "ADDR2", true));
            this.TextEditAddr2.EnterMoveNextControl = true;
            this.TextEditAddr2.Location = new System.Drawing.Point(89, 101);
            this.TextEditAddr2.Name = "TextEditAddr2";
            this.TextEditAddr2.Properties.MaxLength = 30;
            this.TextEditAddr2.Size = new System.Drawing.Size(431, 20);
            this.TextEditAddr2.TabIndex = 9;
            this.TextEditAddr2.Leave += new System.EventHandler(this.TextEditAddress2_Leave);
            // 
            // TextEditAddr1
            // 
            this.TextEditAddr1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "ADDR1", true));
            this.TextEditAddr1.EnterMoveNextControl = true;
            this.TextEditAddr1.Location = new System.Drawing.Point(89, 61);
            this.TextEditAddr1.Name = "TextEditAddr1";
            this.TextEditAddr1.Properties.MaxLength = 30;
            this.TextEditAddr1.Size = new System.Drawing.Size(431, 20);
            this.TextEditAddr1.TabIndex = 8;
            this.TextEditAddr1.Leave += new System.EventHandler(this.TextEditAddress1_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Address";
            // 
            // SearchLookupEditCountry
            // 
            this.SearchLookupEditCountry.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "COUNTRY", true));
            this.SearchLookupEditCountry.Location = new System.Drawing.Point(294, 269);
            this.SearchLookupEditCountry.Name = "SearchLookupEditCountry";
            this.SearchLookupEditCountry.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLookupEditCountry.Properties.DataSource = this.BindingSourceCodeName;
            this.SearchLookupEditCountry.Properties.DisplayMember = "DisplayName";
            this.SearchLookupEditCountry.Properties.NullText = "";
            this.SearchLookupEditCountry.Properties.PopupSizeable = false;
            this.SearchLookupEditCountry.Properties.PopupView = this.gridView3;
            this.SearchLookupEditCountry.Properties.ValueMember = "Code";
            this.SearchLookupEditCountry.Size = new System.Drawing.Size(226, 20);
            this.SearchLookupEditCountry.TabIndex = 14;
            this.SearchLookupEditCountry.Leave += new System.EventHandler(this.SearchLookupEditCountry_Leave);
            // 
            // BindingSourceCodeName
            // 
            this.BindingSourceCodeName.DataSource = typeof(TraceForms.CodeName);
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode2,
            this.colName3});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView3.OptionsView.ShowIndicator = false;
            // 
            // colCode2
            // 
            this.colCode2.FieldName = "Code";
            this.colCode2.Name = "colCode2";
            this.colCode2.Visible = true;
            this.colCode2.VisibleIndex = 0;
            // 
            // colName3
            // 
            this.colName3.FieldName = "Name";
            this.colName3.Name = "colName3";
            this.colName3.Visible = true;
            this.colName3.VisibleIndex = 1;
            // 
            // XtraTabPageContacts
            // 
            this.XtraTabPageContacts.Controls.Add(this.PanelControlContactTab);
            this.XtraTabPageContacts.Name = "XtraTabPageContacts";
            this.XtraTabPageContacts.Size = new System.Drawing.Size(877, 499);
            this.XtraTabPageContacts.Text = "Contacts";
            // 
            // PanelControlContactTab
            // 
            this.PanelControlContactTab.Controls.Add(this.ButtonDeleteContact);
            this.PanelControlContactTab.Controls.Add(this.ButtonAddContact);
            this.PanelControlContactTab.Controls.Add(this.ImageComboBoxEditMailFaxFlg);
            this.PanelControlContactTab.Controls.Add(this.GridControlContacts);
            this.PanelControlContactTab.Controls.Add(eMAILLabel);
            this.PanelControlContactTab.Controls.Add(this.TextEditEmail);
            this.PanelControlContactTab.Controls.Add(fAX_NUMLabel);
            this.PanelControlContactTab.Controls.Add(this.TextEditFaxNum);
            this.PanelControlContactTab.Controls.Add(pHONELabel);
            this.PanelControlContactTab.Controls.Add(this.TextEditPhone);
            this.PanelControlContactTab.Controls.Add(mAILFAX_FLGLabel);
            this.PanelControlContactTab.Controls.Add(this.label2);
            this.PanelControlContactTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelControlContactTab.Location = new System.Drawing.Point(0, 0);
            this.PanelControlContactTab.Name = "PanelControlContactTab";
            this.PanelControlContactTab.Size = new System.Drawing.Size(877, 499);
            this.PanelControlContactTab.TabIndex = 0;
            // 
            // ButtonDeleteContact
            // 
            this.ButtonDeleteContact.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonDeleteContact.ImageOptions.Image")));
            this.ButtonDeleteContact.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ButtonDeleteContact.Location = new System.Drawing.Point(797, 219);
            this.ButtonDeleteContact.Name = "ButtonDeleteContact";
            this.ButtonDeleteContact.Size = new System.Drawing.Size(34, 38);
            this.ButtonDeleteContact.TabIndex = 38;
            this.ButtonDeleteContact.TabStop = false;
            this.ButtonDeleteContact.Text = "Delete Contact";
            this.ButtonDeleteContact.Click += new System.EventHandler(this.ButtonDeleteContact_Click);
            // 
            // ButtonAddContact
            // 
            this.ButtonAddContact.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonAddContact.ImageOptions.Image")));
            this.ButtonAddContact.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ButtonAddContact.Location = new System.Drawing.Point(797, 174);
            this.ButtonAddContact.Name = "ButtonAddContact";
            this.ButtonAddContact.Size = new System.Drawing.Size(34, 38);
            this.ButtonAddContact.TabIndex = 36;
            this.ButtonAddContact.TabStop = false;
            this.ButtonAddContact.Text = "Add Contact";
            this.ButtonAddContact.Click += new System.EventHandler(this.ButtonAddContact_Click);
            // 
            // ImageComboBoxEditMailFaxFlg
            // 
            this.ImageComboBoxEditMailFaxFlg.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "MAILFAX_FLG", true));
            this.ImageComboBoxEditMailFaxFlg.EnterMoveNextControl = true;
            this.ImageComboBoxEditMailFaxFlg.Location = new System.Drawing.Point(111, 85);
            this.ImageComboBoxEditMailFaxFlg.Name = "ImageComboBoxEditMailFaxFlg";
            this.ImageComboBoxEditMailFaxFlg.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ImageComboBoxEditMailFaxFlg.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Email", "E", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Fax", "F", -1)});
            this.ImageComboBoxEditMailFaxFlg.Size = new System.Drawing.Size(100, 20);
            this.ImageComboBoxEditMailFaxFlg.TabIndex = 15;
            this.ImageComboBoxEditMailFaxFlg.Leave += new System.EventHandler(this.ImageComboBoxEditMailFaxFlg_Leave);
            // 
            // GridControlContacts
            // 
            this.GridControlContacts.DataSource = this.BindingSourceContact;
            this.GridControlContacts.Location = new System.Drawing.Point(33, 174);
            this.GridControlContacts.MainView = this.GridViewContacts;
            this.GridControlContacts.Name = "GridControlContacts";
            this.GridControlContacts.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBoxSendDocs,
            this.repositoryItemComboBoxDept,
            this.RepositoryItemSearchLookUpEditReportType,
            this.RepositoryItemCheckedComboBoxEditReportType});
            this.GridControlContacts.Size = new System.Drawing.Size(758, 195);
            this.GridControlContacts.TabIndex = 10;
            this.GridControlContacts.TabStop = false;
            this.GridControlContacts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewContacts});
            // 
            // BindingSourceContact
            // 
            this.BindingSourceContact.DataSource = typeof(FlexModel.CONTACT);
            // 
            // GridViewContacts
            // 
            this.GridViewContacts.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLINK_TABLE,
            this.colLINK_VALUE,
            this.colNAME1,
            this.colDEPT,
            this.colADDRESS1,
            this.colADDRESS2,
            this.colADDRESS3,
            this.colCITY,
            this.colSTATE,
            this.colZIP,
            this.colGMACCTNO,
            this.colGMRECID,
            this.colDEPT_HEAD,
            this.colID,
            this.colACTIVE,
            this.colCOMM_PREF,
            this.colCOUNTRY,
            this.colUSER_DEC1,
            this.colUSER_DEC2,
            this.colUSER_INT1,
            this.colUSER_INT2,
            this.colUSER_TXT1,
            this.colUSER_TXT2,
            this.colUSER_TXT3,
            this.colUSER_TXT4,
            this.colUSER_DTE1,
            this.colUSER_DTE2,
            this.colLOGIN_NAME,
            this.colPASSWORD,
            this.colLOGIN_ROLE,
            this.colLOGIN_ACTIVE,
            this.colRECTYPE,
            this.colPARENT_ID,
            this.colTITLE,
            this.colDEAR,
            this.colPHONE,
            this.colFAX,
            this.colEMAIL,
            this.gridColumnRptType});
            this.GridViewContacts.DetailHeight = 198;
            this.GridViewContacts.FixedLineWidth = 1;
            this.GridViewContacts.GridControl = this.GridControlContacts;
            this.GridViewContacts.Name = "GridViewContacts";
            this.GridViewContacts.OptionsView.ShowGroupPanel = false;
            this.GridViewContacts.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.GridViewContacts_CellValueChanged);
            this.GridViewContacts.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.GridViewContacts_CustomUnboundColumnData);
            // 
            // colLINK_TABLE
            // 
            this.colLINK_TABLE.FieldName = "LINK_TABLE";
            this.colLINK_TABLE.MinWidth = 12;
            this.colLINK_TABLE.Name = "colLINK_TABLE";
            this.colLINK_TABLE.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colLINK_TABLE.Width = 45;
            // 
            // colLINK_VALUE
            // 
            this.colLINK_VALUE.FieldName = "LINK_VALUE";
            this.colLINK_VALUE.MinWidth = 12;
            this.colLINK_VALUE.Name = "colLINK_VALUE";
            this.colLINK_VALUE.Width = 45;
            // 
            // colNAME1
            // 
            this.colNAME1.Caption = "Name";
            this.colNAME1.FieldName = "NAME";
            this.colNAME1.MinWidth = 12;
            this.colNAME1.Name = "colNAME1";
            this.colNAME1.Visible = true;
            this.colNAME1.VisibleIndex = 1;
            this.colNAME1.Width = 53;
            // 
            // colDEPT
            // 
            this.colDEPT.Caption = "Department";
            this.colDEPT.ColumnEdit = this.repositoryItemComboBoxDept;
            this.colDEPT.FieldName = "DEPT";
            this.colDEPT.MinWidth = 12;
            this.colDEPT.Name = "colDEPT";
            this.colDEPT.Visible = true;
            this.colDEPT.VisibleIndex = 2;
            this.colDEPT.Width = 59;
            // 
            // repositoryItemComboBoxDept
            // 
            this.repositoryItemComboBoxDept.AutoHeight = false;
            this.repositoryItemComboBoxDept.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBoxDept.Name = "repositoryItemComboBoxDept";
            // 
            // colADDRESS1
            // 
            this.colADDRESS1.FieldName = "ADDRESS1";
            this.colADDRESS1.MinWidth = 12;
            this.colADDRESS1.Name = "colADDRESS1";
            this.colADDRESS1.Width = 45;
            // 
            // colADDRESS2
            // 
            this.colADDRESS2.FieldName = "ADDRESS2";
            this.colADDRESS2.MinWidth = 12;
            this.colADDRESS2.Name = "colADDRESS2";
            this.colADDRESS2.Width = 45;
            // 
            // colADDRESS3
            // 
            this.colADDRESS3.FieldName = "ADDRESS3";
            this.colADDRESS3.MinWidth = 12;
            this.colADDRESS3.Name = "colADDRESS3";
            this.colADDRESS3.Width = 45;
            // 
            // colCITY
            // 
            this.colCITY.FieldName = "CITY";
            this.colCITY.MinWidth = 12;
            this.colCITY.Name = "colCITY";
            this.colCITY.Width = 45;
            // 
            // colSTATE
            // 
            this.colSTATE.FieldName = "STATE";
            this.colSTATE.MinWidth = 12;
            this.colSTATE.Name = "colSTATE";
            this.colSTATE.Width = 45;
            // 
            // colZIP
            // 
            this.colZIP.FieldName = "ZIP";
            this.colZIP.MinWidth = 12;
            this.colZIP.Name = "colZIP";
            this.colZIP.Width = 45;
            // 
            // colGMACCTNO
            // 
            this.colGMACCTNO.FieldName = "GMACCTNO";
            this.colGMACCTNO.MinWidth = 12;
            this.colGMACCTNO.Name = "colGMACCTNO";
            this.colGMACCTNO.Width = 45;
            // 
            // colGMRECID
            // 
            this.colGMRECID.FieldName = "GMRECID";
            this.colGMRECID.MinWidth = 12;
            this.colGMRECID.Name = "colGMRECID";
            this.colGMRECID.Width = 45;
            // 
            // colDEPT_HEAD
            // 
            this.colDEPT_HEAD.FieldName = "DEPT_HEAD";
            this.colDEPT_HEAD.MinWidth = 12;
            this.colDEPT_HEAD.Name = "colDEPT_HEAD";
            this.colDEPT_HEAD.Width = 45;
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.MinWidth = 12;
            this.colID.Name = "colID";
            this.colID.Width = 45;
            // 
            // colACTIVE
            // 
            this.colACTIVE.Caption = "Active";
            this.colACTIVE.FieldName = "ACTIVE";
            this.colACTIVE.MinWidth = 12;
            this.colACTIVE.Name = "colACTIVE";
            this.colACTIVE.Visible = true;
            this.colACTIVE.VisibleIndex = 0;
            this.colACTIVE.Width = 30;
            // 
            // colCOMM_PREF
            // 
            this.colCOMM_PREF.Caption = "Send Docs By";
            this.colCOMM_PREF.ColumnEdit = this.repositoryItemImageComboBoxSendDocs;
            this.colCOMM_PREF.FieldName = "COMM_PREF";
            this.colCOMM_PREF.MinWidth = 12;
            this.colCOMM_PREF.Name = "colCOMM_PREF";
            this.colCOMM_PREF.Visible = true;
            this.colCOMM_PREF.VisibleIndex = 4;
            this.colCOMM_PREF.Width = 45;
            // 
            // repositoryItemImageComboBoxSendDocs
            // 
            this.repositoryItemImageComboBoxSendDocs.AutoHeight = false;
            this.repositoryItemImageComboBoxSendDocs.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBoxSendDocs.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Mail", "M", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Fax", "F", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("None", "N", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Email", "E", -1)});
            this.repositoryItemImageComboBoxSendDocs.Name = "repositoryItemImageComboBoxSendDocs";
            // 
            // colCOUNTRY
            // 
            this.colCOUNTRY.FieldName = "COUNTRY";
            this.colCOUNTRY.MinWidth = 12;
            this.colCOUNTRY.Name = "colCOUNTRY";
            this.colCOUNTRY.Width = 45;
            // 
            // colUSER_DEC1
            // 
            this.colUSER_DEC1.FieldName = "USER_DEC1";
            this.colUSER_DEC1.MinWidth = 12;
            this.colUSER_DEC1.Name = "colUSER_DEC1";
            this.colUSER_DEC1.Width = 45;
            // 
            // colUSER_DEC2
            // 
            this.colUSER_DEC2.FieldName = "USER_DEC2";
            this.colUSER_DEC2.MinWidth = 12;
            this.colUSER_DEC2.Name = "colUSER_DEC2";
            this.colUSER_DEC2.Width = 45;
            // 
            // colUSER_INT1
            // 
            this.colUSER_INT1.FieldName = "USER_INT1";
            this.colUSER_INT1.MinWidth = 12;
            this.colUSER_INT1.Name = "colUSER_INT1";
            this.colUSER_INT1.Width = 45;
            // 
            // colUSER_INT2
            // 
            this.colUSER_INT2.FieldName = "USER_INT2";
            this.colUSER_INT2.MinWidth = 12;
            this.colUSER_INT2.Name = "colUSER_INT2";
            this.colUSER_INT2.Width = 45;
            // 
            // colUSER_TXT1
            // 
            this.colUSER_TXT1.FieldName = "USER_TXT1";
            this.colUSER_TXT1.MinWidth = 12;
            this.colUSER_TXT1.Name = "colUSER_TXT1";
            this.colUSER_TXT1.Width = 45;
            // 
            // colUSER_TXT2
            // 
            this.colUSER_TXT2.FieldName = "USER_TXT2";
            this.colUSER_TXT2.MinWidth = 12;
            this.colUSER_TXT2.Name = "colUSER_TXT2";
            this.colUSER_TXT2.Width = 45;
            // 
            // colUSER_TXT3
            // 
            this.colUSER_TXT3.FieldName = "USER_TXT3";
            this.colUSER_TXT3.MinWidth = 12;
            this.colUSER_TXT3.Name = "colUSER_TXT3";
            this.colUSER_TXT3.Width = 45;
            // 
            // colUSER_TXT4
            // 
            this.colUSER_TXT4.FieldName = "USER_TXT4";
            this.colUSER_TXT4.MinWidth = 12;
            this.colUSER_TXT4.Name = "colUSER_TXT4";
            this.colUSER_TXT4.Width = 45;
            // 
            // colUSER_DTE1
            // 
            this.colUSER_DTE1.FieldName = "USER_DTE1";
            this.colUSER_DTE1.MinWidth = 12;
            this.colUSER_DTE1.Name = "colUSER_DTE1";
            this.colUSER_DTE1.Width = 45;
            // 
            // colUSER_DTE2
            // 
            this.colUSER_DTE2.FieldName = "USER_DTE2";
            this.colUSER_DTE2.MinWidth = 12;
            this.colUSER_DTE2.Name = "colUSER_DTE2";
            this.colUSER_DTE2.Width = 45;
            // 
            // colLOGIN_NAME
            // 
            this.colLOGIN_NAME.FieldName = "LOGIN_NAME";
            this.colLOGIN_NAME.MinWidth = 12;
            this.colLOGIN_NAME.Name = "colLOGIN_NAME";
            this.colLOGIN_NAME.Width = 45;
            // 
            // colPASSWORD
            // 
            this.colPASSWORD.FieldName = "PASSWORD";
            this.colPASSWORD.MinWidth = 12;
            this.colPASSWORD.Name = "colPASSWORD";
            this.colPASSWORD.Width = 45;
            // 
            // colLOGIN_ROLE
            // 
            this.colLOGIN_ROLE.FieldName = "LOGIN_ROLE";
            this.colLOGIN_ROLE.MinWidth = 12;
            this.colLOGIN_ROLE.Name = "colLOGIN_ROLE";
            this.colLOGIN_ROLE.Width = 45;
            // 
            // colLOGIN_ACTIVE
            // 
            this.colLOGIN_ACTIVE.FieldName = "LOGIN_ACTIVE";
            this.colLOGIN_ACTIVE.MinWidth = 12;
            this.colLOGIN_ACTIVE.Name = "colLOGIN_ACTIVE";
            this.colLOGIN_ACTIVE.Width = 45;
            // 
            // colRECTYPE
            // 
            this.colRECTYPE.FieldName = "RECTYPE";
            this.colRECTYPE.MinWidth = 12;
            this.colRECTYPE.Name = "colRECTYPE";
            this.colRECTYPE.Width = 45;
            // 
            // colPARENT_ID
            // 
            this.colPARENT_ID.FieldName = "PARENT_ID";
            this.colPARENT_ID.MinWidth = 12;
            this.colPARENT_ID.Name = "colPARENT_ID";
            this.colPARENT_ID.Width = 45;
            // 
            // colTITLE
            // 
            this.colTITLE.FieldName = "TITLE";
            this.colTITLE.MinWidth = 12;
            this.colTITLE.Name = "colTITLE";
            this.colTITLE.Width = 45;
            // 
            // colDEAR
            // 
            this.colDEAR.FieldName = "DEAR";
            this.colDEAR.MinWidth = 12;
            this.colDEAR.Name = "colDEAR";
            this.colDEAR.Width = 45;
            // 
            // colPHONE
            // 
            this.colPHONE.Caption = "Phone";
            this.colPHONE.FieldName = "PHONE";
            this.colPHONE.MinWidth = 12;
            this.colPHONE.Name = "colPHONE";
            this.colPHONE.Visible = true;
            this.colPHONE.VisibleIndex = 7;
            this.colPHONE.Width = 55;
            // 
            // colFAX
            // 
            this.colFAX.Caption = "Fax";
            this.colFAX.FieldName = "FAX";
            this.colFAX.MinWidth = 12;
            this.colFAX.Name = "colFAX";
            this.colFAX.Visible = true;
            this.colFAX.VisibleIndex = 6;
            this.colFAX.Width = 42;
            // 
            // colEMAIL
            // 
            this.colEMAIL.Caption = "Email";
            this.colEMAIL.FieldName = "EMAIL";
            this.colEMAIL.MinWidth = 12;
            this.colEMAIL.Name = "colEMAIL";
            this.colEMAIL.Visible = true;
            this.colEMAIL.VisibleIndex = 5;
            this.colEMAIL.Width = 108;
            // 
            // gridColumnRptType
            // 
            this.gridColumnRptType.Caption = "Rpt Types";
            this.gridColumnRptType.ColumnEdit = this.RepositoryItemCheckedComboBoxEditReportType;
            this.gridColumnRptType.FieldName = "Reports";
            this.gridColumnRptType.MinWidth = 12;
            this.gridColumnRptType.Name = "gridColumnRptType";
            this.gridColumnRptType.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumnRptType.Visible = true;
            this.gridColumnRptType.VisibleIndex = 3;
            this.gridColumnRptType.Width = 90;
            // 
            // RepositoryItemCheckedComboBoxEditReportType
            // 
            this.RepositoryItemCheckedComboBoxEditReportType.AutoHeight = false;
            this.RepositoryItemCheckedComboBoxEditReportType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemCheckedComboBoxEditReportType.DisplayMember = "DisplayName";
            this.RepositoryItemCheckedComboBoxEditReportType.Name = "RepositoryItemCheckedComboBoxEditReportType";
            this.RepositoryItemCheckedComboBoxEditReportType.ValueMember = "Code";
            // 
            // RepositoryItemSearchLookUpEditReportType
            // 
            this.RepositoryItemSearchLookUpEditReportType.AutoHeight = false;
            this.RepositoryItemSearchLookUpEditReportType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemSearchLookUpEditReportType.DataSource = this.BindingSourceCodeName;
            this.RepositoryItemSearchLookUpEditReportType.DisplayMember = "DisplayName";
            this.RepositoryItemSearchLookUpEditReportType.Name = "RepositoryItemSearchLookUpEditReportType";
            this.RepositoryItemSearchLookUpEditReportType.PopupView = this.repositoryItemSearchLookUpEdit1View;
            this.RepositoryItemSearchLookUpEditReportType.ValueMember = "Code";
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode1,
            this.colName2});
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowIndicator = false;
            // 
            // colCode1
            // 
            this.colCode1.FieldName = "Code";
            this.colCode1.Name = "colCode1";
            this.colCode1.Visible = true;
            this.colCode1.VisibleIndex = 0;
            // 
            // colName2
            // 
            this.colName2.FieldName = "Name";
            this.colName2.Name = "colName2";
            this.colName2.Visible = true;
            this.colName2.VisibleIndex = 1;
            // 
            // TextEditEmail
            // 
            this.TextEditEmail.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "EMAIL", true));
            this.TextEditEmail.EnterMoveNextControl = true;
            this.TextEditEmail.Location = new System.Drawing.Point(111, 131);
            this.TextEditEmail.Name = "TextEditEmail";
            this.TextEditEmail.Properties.MaxLength = 50;
            this.TextEditEmail.Size = new System.Drawing.Size(454, 20);
            this.TextEditEmail.TabIndex = 18;
            this.TextEditEmail.Leave += new System.EventHandler(this.TextEditEmail_Leave);
            // 
            // TextEditFaxNum
            // 
            this.TextEditFaxNum.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "FAX_NUM", true));
            this.TextEditFaxNum.EnterMoveNextControl = true;
            this.TextEditFaxNum.Location = new System.Drawing.Point(465, 85);
            this.TextEditFaxNum.Name = "TextEditFaxNum";
            this.TextEditFaxNum.Properties.MaxLength = 20;
            this.TextEditFaxNum.Size = new System.Drawing.Size(100, 20);
            this.TextEditFaxNum.TabIndex = 17;
            this.TextEditFaxNum.Leave += new System.EventHandler(this.TextEditFaxNum_Leave);
            // 
            // TextEditPhone
            // 
            this.TextEditPhone.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "PHONE", true));
            this.TextEditPhone.EnterMoveNextControl = true;
            this.TextEditPhone.Location = new System.Drawing.Point(309, 85);
            this.TextEditPhone.Name = "TextEditPhone";
            this.TextEditPhone.Properties.MaxLength = 20;
            this.TextEditPhone.Size = new System.Drawing.Size(100, 20);
            this.TextEditPhone.TabIndex = 16;
            this.TextEditPhone.Leave += new System.EventHandler(this.TextEditPhone_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Primary Contact";
            // 
            // XtraTabPageAvailability
            // 
            this.XtraTabPageAvailability.Controls.Add(this.PanelControlAvailabilityTab);
            this.XtraTabPageAvailability.Name = "XtraTabPageAvailability";
            this.XtraTabPageAvailability.Size = new System.Drawing.Size(877, 499);
            this.XtraTabPageAvailability.Text = "Availability";
            // 
            // PanelControlAvailabilityTab
            // 
            this.PanelControlAvailabilityTab.Controls.Add(this.ImageComboBoxEditRetNotAvalHtls);
            this.PanelControlAvailabilityTab.Controls.Add(this.ImageComboBoxEditRetreqHtls);
            this.PanelControlAvailabilityTab.Controls.Add(this.CheckEditSubAlloc);
            this.PanelControlAvailabilityTab.Controls.Add(this.SpinEditArvBkDays);
            this.PanelControlAvailabilityTab.Controls.Add(this.SpinEditRel);
            this.PanelControlAvailabilityTab.Controls.Add(aRVBKDAYSLabel);
            this.PanelControlAvailabilityTab.Controls.Add(rELLabel);
            this.PanelControlAvailabilityTab.Controls.Add(rETNOTAVALHTLSLabel);
            this.PanelControlAvailabilityTab.Controls.Add(rETREQHTLSLabel);
            this.PanelControlAvailabilityTab.Controls.Add(sUB_ALLOCLabel);
            this.PanelControlAvailabilityTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelControlAvailabilityTab.Location = new System.Drawing.Point(0, 0);
            this.PanelControlAvailabilityTab.Name = "PanelControlAvailabilityTab";
            this.PanelControlAvailabilityTab.Size = new System.Drawing.Size(877, 499);
            this.PanelControlAvailabilityTab.TabIndex = 0;
            // 
            // ImageComboBoxEditRetNotAvalHtls
            // 
            this.ImageComboBoxEditRetNotAvalHtls.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "RETNOTAVALHTLS", true));
            this.ImageComboBoxEditRetNotAvalHtls.EnterMoveNextControl = true;
            this.ImageComboBoxEditRetNotAvalHtls.Location = new System.Drawing.Point(279, 147);
            this.ImageComboBoxEditRetNotAvalHtls.Name = "ImageComboBoxEditRetNotAvalHtls";
            this.ImageComboBoxEditRetNotAvalHtls.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ImageComboBoxEditRetNotAvalHtls.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("No", "N", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Website", "R", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("API", "H", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Both", "B", -1)});
            this.ImageComboBoxEditRetNotAvalHtls.Size = new System.Drawing.Size(100, 20);
            this.ImageComboBoxEditRetNotAvalHtls.TabIndex = 22;
            this.ImageComboBoxEditRetNotAvalHtls.Leave += new System.EventHandler(this.ImageComboBoxEditRetNotAvailHtls_Leave);
            // 
            // ImageComboBoxEditRetreqHtls
            // 
            this.ImageComboBoxEditRetreqHtls.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "RETREQHTLS", true));
            this.ImageComboBoxEditRetreqHtls.EnterMoveNextControl = true;
            this.ImageComboBoxEditRetreqHtls.Location = new System.Drawing.Point(279, 97);
            this.ImageComboBoxEditRetreqHtls.Name = "ImageComboBoxEditRetreqHtls";
            this.ImageComboBoxEditRetreqHtls.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ImageComboBoxEditRetreqHtls.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("No", "N", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Website", "R", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("API", "H", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Both", "B", -1)});
            this.ImageComboBoxEditRetreqHtls.Size = new System.Drawing.Size(100, 20);
            this.ImageComboBoxEditRetreqHtls.TabIndex = 21;
            this.ImageComboBoxEditRetreqHtls.Leave += new System.EventHandler(this.ImageComboBoxEditRetReqHtls_Leave);
            // 
            // CheckEditSubAlloc
            // 
            this.CheckEditSubAlloc.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "SUB_ALLOC", true));
            this.CheckEditSubAlloc.EnterMoveNextControl = true;
            this.CheckEditSubAlloc.Location = new System.Drawing.Point(279, 49);
            this.CheckEditSubAlloc.Name = "CheckEditSubAlloc";
            this.CheckEditSubAlloc.Properties.Caption = "";
            this.CheckEditSubAlloc.Properties.ValueChecked = "Y";
            this.CheckEditSubAlloc.Properties.ValueUnchecked = "N";
            this.CheckEditSubAlloc.Size = new System.Drawing.Size(18, 19);
            this.CheckEditSubAlloc.TabIndex = 19;
            // 
            // SpinEditArvBkDays
            // 
            this.SpinEditArvBkDays.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "ARVBKDAYS", true));
            this.SpinEditArvBkDays.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SpinEditArvBkDays.EnterMoveNextControl = true;
            this.SpinEditArvBkDays.Location = new System.Drawing.Point(279, 236);
            this.SpinEditArvBkDays.Name = "SpinEditArvBkDays";
            this.SpinEditArvBkDays.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.SpinEditArvBkDays.Properties.Appearance.Options.UseBackColor = true;
            this.SpinEditArvBkDays.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SpinEditArvBkDays.Properties.IsFloatValue = false;
            this.SpinEditArvBkDays.Properties.Mask.EditMask = "N00";
            this.SpinEditArvBkDays.Size = new System.Drawing.Size(56, 20);
            this.SpinEditArvBkDays.TabIndex = 24;
            this.SpinEditArvBkDays.Leave += new System.EventHandler(this.SpinEditArvBkDays_Leave);
            // 
            // SpinEditRel
            // 
            this.SpinEditRel.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "REL", true));
            this.SpinEditRel.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SpinEditRel.EnterMoveNextControl = true;
            this.SpinEditRel.Location = new System.Drawing.Point(279, 194);
            this.SpinEditRel.Name = "SpinEditRel";
            this.SpinEditRel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SpinEditRel.Properties.IsFloatValue = false;
            this.SpinEditRel.Properties.Mask.EditMask = "N00";
            this.SpinEditRel.Size = new System.Drawing.Size(56, 20);
            this.SpinEditRel.TabIndex = 23;
            this.SpinEditRel.Leave += new System.EventHandler(this.SpinEditRel_Leave);
            // 
            // XtraTabPageReporting
            // 
            this.XtraTabPageReporting.AutoScroll = true;
            this.XtraTabPageReporting.Controls.Add(this.PanelControlReportTab);
            this.XtraTabPageReporting.Name = "XtraTabPageReporting";
            this.XtraTabPageReporting.Size = new System.Drawing.Size(877, 499);
            this.XtraTabPageReporting.Text = "Reporting";
            // 
            // PanelControlReportTab
            // 
            this.PanelControlReportTab.Controls.Add(this.CheckEditPkgVouchers);
            this.PanelControlReportTab.Controls.Add(this.CheckEditOptVouchers);
            this.PanelControlReportTab.Controls.Add(this.CheckEditAirVouchers);
            this.PanelControlReportTab.Controls.Add(this.CheckEditCruVouchers);
            this.PanelControlReportTab.Controls.Add(this.CheckEditCarVouchers);
            this.PanelControlReportTab.Controls.Add(this.CheckEditHtlVouchers);
            this.PanelControlReportTab.Controls.Add(this.ImageComboBoxEditTourfaxEmailFormat);
            this.PanelControlReportTab.Controls.Add(this.CheckEditSglResConf);
            this.PanelControlReportTab.Controls.Add(this.checkEdit8);
            this.PanelControlReportTab.Controls.Add(this.CheckEditRemoteVouchers);
            this.PanelControlReportTab.Controls.Add(this.CheckEditAllowAttachments);
            this.PanelControlReportTab.Controls.Add(this.CheckEditConfPrc);
            this.PanelControlReportTab.Controls.Add(tourfaxEmailFormatLabel);
            this.PanelControlReportTab.Controls.Add(this.SpinEditVoucherDaysPrior);
            this.PanelControlReportTab.Controls.Add(this.SpinEditVoucherReprints);
            this.PanelControlReportTab.Controls.Add(vOUCHER_DAYS_PRIORLabel);
            this.PanelControlReportTab.Controls.Add(vOUCHER_REPRINTSLabel);
            this.PanelControlReportTab.Controls.Add(this.labelControl1);
            this.PanelControlReportTab.Controls.Add(rEMOTE_VOUCHERSLabel);
            this.PanelControlReportTab.Controls.Add(aLLOW_ATTACHMENTSLabel);
            this.PanelControlReportTab.Controls.Add(cONF_PRCLabel);
            this.PanelControlReportTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelControlReportTab.Location = new System.Drawing.Point(0, 0);
            this.PanelControlReportTab.Name = "PanelControlReportTab";
            this.PanelControlReportTab.Size = new System.Drawing.Size(877, 499);
            this.PanelControlReportTab.TabIndex = 0;
            // 
            // CheckEditPkgVouchers
            // 
            this.CheckEditPkgVouchers.EnterMoveNextControl = true;
            this.CheckEditPkgVouchers.Location = new System.Drawing.Point(375, 198);
            this.CheckEditPkgVouchers.Name = "CheckEditPkgVouchers";
            this.CheckEditPkgVouchers.Properties.Caption = "Pkg";
            this.CheckEditPkgVouchers.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditPkgVouchers.Properties.ValueChecked = " PKG,";
            this.CheckEditPkgVouchers.Properties.ValueGrayed = "";
            this.CheckEditPkgVouchers.Properties.ValueUnchecked = "";
            this.CheckEditPkgVouchers.Size = new System.Drawing.Size(40, 19);
            this.CheckEditPkgVouchers.TabIndex = 34;
            this.CheckEditPkgVouchers.Click += new System.EventHandler(this.CheckEditPkgVouchers_Click_1);
            // 
            // CheckEditOptVouchers
            // 
            this.CheckEditOptVouchers.EnterMoveNextControl = true;
            this.CheckEditOptVouchers.Location = new System.Drawing.Point(289, 198);
            this.CheckEditOptVouchers.Name = "CheckEditOptVouchers";
            this.CheckEditOptVouchers.Properties.Caption = "Services";
            this.CheckEditOptVouchers.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditOptVouchers.Properties.ValueChecked = " OPT,";
            this.CheckEditOptVouchers.Properties.ValueGrayed = "";
            this.CheckEditOptVouchers.Properties.ValueUnchecked = "";
            this.CheckEditOptVouchers.Size = new System.Drawing.Size(63, 19);
            this.CheckEditOptVouchers.TabIndex = 33;
            this.CheckEditOptVouchers.Click += new System.EventHandler(this.CheckEditOptVouchers_Click);
            // 
            // CheckEditAirVouchers
            // 
            this.CheckEditAirVouchers.EnterMoveNextControl = true;
            this.CheckEditAirVouchers.Location = new System.Drawing.Point(595, 198);
            this.CheckEditAirVouchers.Name = "CheckEditAirVouchers";
            this.CheckEditAirVouchers.Properties.Caption = "Air";
            this.CheckEditAirVouchers.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditAirVouchers.Properties.ValueChecked = " AIR,";
            this.CheckEditAirVouchers.Properties.ValueGrayed = "";
            this.CheckEditAirVouchers.Properties.ValueUnchecked = "";
            this.CheckEditAirVouchers.Size = new System.Drawing.Size(35, 19);
            this.CheckEditAirVouchers.TabIndex = 32;
            this.CheckEditAirVouchers.Click += new System.EventHandler(this.CheckEditAirVouchers_Click);
            // 
            // CheckEditCruVouchers
            // 
            this.CheckEditCruVouchers.EnterMoveNextControl = true;
            this.CheckEditCruVouchers.Location = new System.Drawing.Point(512, 198);
            this.CheckEditCruVouchers.Name = "CheckEditCruVouchers";
            this.CheckEditCruVouchers.Properties.Caption = "Cruises";
            this.CheckEditCruVouchers.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditCruVouchers.Properties.ValueChecked = " CRU,";
            this.CheckEditCruVouchers.Properties.ValueGrayed = "";
            this.CheckEditCruVouchers.Properties.ValueUnchecked = "";
            this.CheckEditCruVouchers.Size = new System.Drawing.Size(61, 19);
            this.CheckEditCruVouchers.TabIndex = 31;
            this.CheckEditCruVouchers.Click += new System.EventHandler(this.CheckEditCruVouchers_Click);
            // 
            // CheckEditCarVouchers
            // 
            this.CheckEditCarVouchers.EnterMoveNextControl = true;
            this.CheckEditCarVouchers.Location = new System.Drawing.Point(441, 198);
            this.CheckEditCarVouchers.Name = "CheckEditCarVouchers";
            this.CheckEditCarVouchers.Properties.Caption = "Cars";
            this.CheckEditCarVouchers.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditCarVouchers.Properties.ValueChecked = " CAR,";
            this.CheckEditCarVouchers.Properties.ValueGrayed = "";
            this.CheckEditCarVouchers.Properties.ValueUnchecked = "";
            this.CheckEditCarVouchers.Size = new System.Drawing.Size(49, 19);
            this.CheckEditCarVouchers.TabIndex = 30;
            this.CheckEditCarVouchers.Click += new System.EventHandler(this.CheckEditCarVouchers_Click);
            // 
            // CheckEditHtlVouchers
            // 
            this.CheckEditHtlVouchers.EnterMoveNextControl = true;
            this.CheckEditHtlVouchers.Location = new System.Drawing.Point(211, 198);
            this.CheckEditHtlVouchers.Name = "CheckEditHtlVouchers";
            this.CheckEditHtlVouchers.Properties.Caption = "Hotels";
            this.CheckEditHtlVouchers.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditHtlVouchers.Properties.ValueChecked = "HTL,";
            this.CheckEditHtlVouchers.Properties.ValueGrayed = "";
            this.CheckEditHtlVouchers.Properties.ValueUnchecked = "";
            this.CheckEditHtlVouchers.Size = new System.Drawing.Size(56, 19);
            this.CheckEditHtlVouchers.TabIndex = 29;
            this.CheckEditHtlVouchers.Click += new System.EventHandler(this.CheckEditHtlVouchers_Click);
            // 
            // ImageComboBoxEditTourfaxEmailFormat
            // 
            this.ImageComboBoxEditTourfaxEmailFormat.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "TourfaxEmailFormat", true));
            this.ImageComboBoxEditTourfaxEmailFormat.EnterMoveNextControl = true;
            this.ImageComboBoxEditTourfaxEmailFormat.Location = new System.Drawing.Point(514, 101);
            this.ImageComboBoxEditTourfaxEmailFormat.Name = "ImageComboBoxEditTourfaxEmailFormat";
            this.ImageComboBoxEditTourfaxEmailFormat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ImageComboBoxEditTourfaxEmailFormat.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("pdf", "pdf", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("htm", "htm", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("txt", "txt", -1)});
            this.ImageComboBoxEditTourfaxEmailFormat.Size = new System.Drawing.Size(100, 20);
            this.ImageComboBoxEditTourfaxEmailFormat.TabIndex = 27;
            this.ImageComboBoxEditTourfaxEmailFormat.Leave += new System.EventHandler(this.ImageComboBoxEditTourfaxEmailFormat_Leave);
            // 
            // CheckEditSglResConf
            // 
            this.CheckEditSglResConf.EnterMoveNextControl = true;
            this.CheckEditSglResConf.Location = new System.Drawing.Point(474, 252);
            this.CheckEditSglResConf.Name = "CheckEditSglResConf";
            this.CheckEditSglResConf.Properties.Caption = "Single Res Confirmations";
            this.CheckEditSglResConf.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditSglResConf.Properties.ValueChecked = " SGL,";
            this.CheckEditSglResConf.Properties.ValueUnchecked = "";
            this.CheckEditSglResConf.Size = new System.Drawing.Size(141, 19);
            this.CheckEditSglResConf.TabIndex = 36;
            this.CheckEditSglResConf.Click += new System.EventHandler(this.CheckEditSglResConf_Click);
            // 
            // checkEdit8
            // 
            this.checkEdit8.Location = new System.Drawing.Point(500, -71);
            this.checkEdit8.Name = "checkEdit8";
            this.checkEdit8.Properties.Caption = "";
            this.checkEdit8.Properties.ValueChecked = "A";
            this.checkEdit8.Properties.ValueUnchecked = "I";
            this.checkEdit8.Size = new System.Drawing.Size(22, 19);
            this.checkEdit8.TabIndex = 34;
            // 
            // CheckEditRemoteVouchers
            // 
            this.CheckEditRemoteVouchers.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "REMOTE_VOUCHERS", true));
            this.CheckEditRemoteVouchers.EnterMoveNextControl = true;
            this.CheckEditRemoteVouchers.Location = new System.Drawing.Point(250, 149);
            this.CheckEditRemoteVouchers.Name = "CheckEditRemoteVouchers";
            this.CheckEditRemoteVouchers.Properties.Caption = "";
            this.CheckEditRemoteVouchers.Properties.ValueChecked = "Y";
            this.CheckEditRemoteVouchers.Properties.ValueGrayed = "  ";
            this.CheckEditRemoteVouchers.Properties.ValueUnchecked = "N";
            this.CheckEditRemoteVouchers.Size = new System.Drawing.Size(27, 19);
            this.CheckEditRemoteVouchers.TabIndex = 28;
            this.CheckEditRemoteVouchers.CheckStateChanged += new System.EventHandler(this.CheckEditRemoteVouchers_CheckStateChanged);
            // 
            // CheckEditAllowAttachments
            // 
            this.CheckEditAllowAttachments.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "ALLOW_ATTACHMENTS", true));
            this.CheckEditAllowAttachments.EnterMoveNextControl = true;
            this.CheckEditAllowAttachments.Location = new System.Drawing.Point(250, 101);
            this.CheckEditAllowAttachments.Name = "CheckEditAllowAttachments";
            this.CheckEditAllowAttachments.Properties.Caption = "";
            this.CheckEditAllowAttachments.Properties.ValueChecked = "Y";
            this.CheckEditAllowAttachments.Properties.ValueGrayed = " ";
            this.CheckEditAllowAttachments.Properties.ValueUnchecked = "N";
            this.CheckEditAllowAttachments.Size = new System.Drawing.Size(24, 19);
            this.CheckEditAllowAttachments.TabIndex = 26;
            // 
            // CheckEditConfPrc
            // 
            this.CheckEditConfPrc.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CONF_PRC", true));
            this.CheckEditConfPrc.EnterMoveNextControl = true;
            this.CheckEditConfPrc.Location = new System.Drawing.Point(250, 49);
            this.CheckEditConfPrc.Name = "CheckEditConfPrc";
            this.CheckEditConfPrc.Properties.Caption = "";
            this.CheckEditConfPrc.Properties.ValueChecked = "Y";
            this.CheckEditConfPrc.Properties.ValueUnchecked = "N";
            this.CheckEditConfPrc.Size = new System.Drawing.Size(73, 19);
            this.CheckEditConfPrc.TabIndex = 25;
            // 
            // SpinEditVoucherDaysPrior
            // 
            this.SpinEditVoucherDaysPrior.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "VOUCHER_DAYS_PRIOR", true));
            this.SpinEditVoucherDaysPrior.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SpinEditVoucherDaysPrior.EnterMoveNextControl = true;
            this.SpinEditVoucherDaysPrior.Location = new System.Drawing.Point(250, 304);
            this.SpinEditVoucherDaysPrior.Name = "SpinEditVoucherDaysPrior";
            this.SpinEditVoucherDaysPrior.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SpinEditVoucherDaysPrior.Properties.IsFloatValue = false;
            this.SpinEditVoucherDaysPrior.Properties.Mask.EditMask = "N00";
            this.SpinEditVoucherDaysPrior.Size = new System.Drawing.Size(55, 20);
            this.SpinEditVoucherDaysPrior.TabIndex = 37;
            this.SpinEditVoucherDaysPrior.Leave += new System.EventHandler(this.SpinEditVoucherDaysPrior_Leave);
            // 
            // SpinEditVoucherReprints
            // 
            this.SpinEditVoucherReprints.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "VOUCHER_REPRINTS", true));
            this.SpinEditVoucherReprints.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SpinEditVoucherReprints.EnterMoveNextControl = true;
            this.SpinEditVoucherReprints.Location = new System.Drawing.Point(250, 252);
            this.SpinEditVoucherReprints.Name = "SpinEditVoucherReprints";
            this.SpinEditVoucherReprints.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SpinEditVoucherReprints.Properties.IsFloatValue = false;
            this.SpinEditVoucherReprints.Properties.Mask.EditMask = "N00";
            this.SpinEditVoucherReprints.Size = new System.Drawing.Size(55, 20);
            this.SpinEditVoucherReprints.TabIndex = 35;
            this.SpinEditVoucherReprints.Leave += new System.EventHandler(this.SpinEditVoucherReprints_Leave);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(41, 201);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(124, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Service types to voucher:";
            // 
            // XtraTabPagePolicies
            // 
            this.XtraTabPagePolicies.Controls.Add(this.PanelControlPoliciesTab);
            this.XtraTabPagePolicies.Name = "XtraTabPagePolicies";
            this.XtraTabPagePolicies.Size = new System.Drawing.Size(877, 499);
            this.XtraTabPagePolicies.Text = "Policies";
            // 
            // PanelControlPoliciesTab
            // 
            this.PanelControlPoliciesTab.Controls.Add(label30);
            this.PanelControlPoliciesTab.Controls.Add(this.ButtonDeleteAgencyCurrency);
            this.PanelControlPoliciesTab.Controls.Add(this.ButtonAddAgencyCurrency);
            this.PanelControlPoliciesTab.Controls.Add(this.GridControlAgencyCurrency);
            this.PanelControlPoliciesTab.Controls.Add(this.ImageComboBoxEditHtls);
            this.PanelControlPoliciesTab.Controls.Add(this.ImageComboBoxEditHdrs);
            this.PanelControlPoliciesTab.Controls.Add(this.CheckEditRemChg);
            this.PanelControlPoliciesTab.Controls.Add(this.SpinEditComm);
            this.PanelControlPoliciesTab.Controls.Add(this.SpinEditCxlGrace);
            this.PanelControlPoliciesTab.Controls.Add(this.SpinEditOptDays);
            this.PanelControlPoliciesTab.Controls.Add(eDITHTLSLabel);
            this.PanelControlPoliciesTab.Controls.Add(eDITHDRSLabel);
            this.PanelControlPoliciesTab.Controls.Add(cOMMLabel);
            this.PanelControlPoliciesTab.Controls.Add(cXLGRACELabel);
            this.PanelControlPoliciesTab.Controls.Add(oPT_DAYSLabel);
            this.PanelControlPoliciesTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelControlPoliciesTab.Location = new System.Drawing.Point(0, 0);
            this.PanelControlPoliciesTab.Name = "PanelControlPoliciesTab";
            this.PanelControlPoliciesTab.Size = new System.Drawing.Size(877, 499);
            this.PanelControlPoliciesTab.TabIndex = 0;
            // 
            // ButtonDeleteAgencyCurrency
            // 
            this.ButtonDeleteAgencyCurrency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonDeleteAgencyCurrency.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonDeleteAgencyCurrency.ImageOptions.Image")));
            this.ButtonDeleteAgencyCurrency.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ButtonDeleteAgencyCurrency.Location = new System.Drawing.Point(802, 94);
            this.ButtonDeleteAgencyCurrency.Name = "ButtonDeleteAgencyCurrency";
            this.ButtonDeleteAgencyCurrency.Size = new System.Drawing.Size(34, 38);
            this.ButtonDeleteAgencyCurrency.TabIndex = 47;
            this.ButtonDeleteAgencyCurrency.TabStop = false;
            this.ButtonDeleteAgencyCurrency.Text = "Delete Currency";
            this.ButtonDeleteAgencyCurrency.Click += new System.EventHandler(this.ButtonDeleteAgencyCurrency_Click);
            // 
            // ButtonAddAgencyCurrency
            // 
            this.ButtonAddAgencyCurrency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonAddAgencyCurrency.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonAddAgencyCurrency.ImageOptions.Image")));
            this.ButtonAddAgencyCurrency.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ButtonAddAgencyCurrency.Location = new System.Drawing.Point(802, 51);
            this.ButtonAddAgencyCurrency.Name = "ButtonAddAgencyCurrency";
            this.ButtonAddAgencyCurrency.Size = new System.Drawing.Size(34, 38);
            this.ButtonAddAgencyCurrency.TabIndex = 46;
            this.ButtonAddAgencyCurrency.Text = "Add Currency";
            this.ButtonAddAgencyCurrency.Click += new System.EventHandler(this.ButtonAddAgencyCurrency_Click);
            // 
            // GridControlAgencyCurrency
            // 
            this.GridControlAgencyCurrency.DataSource = this.BindingSourceAgencyCurrency;
            this.GridControlAgencyCurrency.Location = new System.Drawing.Point(453, 51);
            this.GridControlAgencyCurrency.MainView = this.GridViewAgencyCurrency;
            this.GridControlAgencyCurrency.Name = "GridControlAgencyCurrency";
            this.GridControlAgencyCurrency.Size = new System.Drawing.Size(343, 255);
            this.GridControlAgencyCurrency.TabIndex = 45;
            this.GridControlAgencyCurrency.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewAgencyCurrency});
            // 
            // BindingSourceAgencyCurrency
            // 
            this.BindingSourceAgencyCurrency.DataSource = typeof(FlexModel.AgencyCurrency);
            this.BindingSourceAgencyCurrency.CurrentChanged += new System.EventHandler(this.AgencyCurrencyBindingSource_CurrentChanged);
            // 
            // GridViewAgencyCurrency
            // 
            this.GridViewAgencyCurrency.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCurrency_Code,
            this.colDefault});
            this.GridViewAgencyCurrency.DetailHeight = 198;
            this.GridViewAgencyCurrency.FixedLineWidth = 1;
            this.GridViewAgencyCurrency.GridControl = this.GridControlAgencyCurrency;
            this.GridViewAgencyCurrency.Name = "GridViewAgencyCurrency";
            this.GridViewAgencyCurrency.OptionsView.ShowGroupPanel = false;
            this.GridViewAgencyCurrency.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.GridViewAgencyCurrency_InvalidRowException);
            // 
            // colCurrency_Code
            // 
            this.colCurrency_Code.Caption = "Currency";
            this.colCurrency_Code.FieldName = "Currency_Code";
            this.colCurrency_Code.MinWidth = 12;
            this.colCurrency_Code.Name = "colCurrency_Code";
            this.colCurrency_Code.Visible = true;
            this.colCurrency_Code.VisibleIndex = 0;
            this.colCurrency_Code.Width = 181;
            // 
            // colDefault
            // 
            this.colDefault.Caption = "Default";
            this.colDefault.FieldName = "Default";
            this.colDefault.MinWidth = 12;
            this.colDefault.Name = "colDefault";
            this.colDefault.Visible = true;
            this.colDefault.VisibleIndex = 1;
            this.colDefault.Width = 57;
            // 
            // ImageComboBoxEditHtls
            // 
            this.ImageComboBoxEditHtls.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "EDITHTLS", true));
            this.ImageComboBoxEditHtls.EnterMoveNextControl = true;
            this.ImageComboBoxEditHtls.Location = new System.Drawing.Point(259, 296);
            this.ImageComboBoxEditHtls.Name = "ImageComboBoxEditHtls";
            this.ImageComboBoxEditHtls.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ImageComboBoxEditHtls.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("No", "N", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Remotes", "R", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Host2Host", "H", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Both", "B", -1)});
            this.ImageComboBoxEditHtls.Size = new System.Drawing.Size(100, 20);
            this.ImageComboBoxEditHtls.TabIndex = 43;
            this.ImageComboBoxEditHtls.Leave += new System.EventHandler(this.ImageComboBoxEditEditHtls_Leave);
            // 
            // ImageComboBoxEditHdrs
            // 
            this.ImageComboBoxEditHdrs.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "EDITHDRS", true));
            this.ImageComboBoxEditHdrs.EnterMoveNextControl = true;
            this.ImageComboBoxEditHdrs.Location = new System.Drawing.Point(259, 251);
            this.ImageComboBoxEditHdrs.Name = "ImageComboBoxEditHdrs";
            this.ImageComboBoxEditHdrs.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ImageComboBoxEditHdrs.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("No", "N", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Remotes", "R", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Host2Host", "H", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Both", "B", -1)});
            this.ImageComboBoxEditHdrs.Size = new System.Drawing.Size(100, 20);
            this.ImageComboBoxEditHdrs.TabIndex = 42;
            this.ImageComboBoxEditHdrs.Leave += new System.EventHandler(this.ImageComboBoxEditEditHdrs_Leave);
            // 
            // CheckEditRemChg
            // 
            this.CheckEditRemChg.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "REM_CHG", true));
            this.CheckEditRemChg.EnterMoveNextControl = true;
            this.CheckEditRemChg.Location = new System.Drawing.Point(41, 50);
            this.CheckEditRemChg.Name = "CheckEditRemChg";
            this.CheckEditRemChg.Properties.Caption = "Allow remotes to modify in-house bookings";
            this.CheckEditRemChg.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditRemChg.Properties.ValueChecked = "Y";
            this.CheckEditRemChg.Properties.ValueUnchecked = "N";
            this.CheckEditRemChg.Size = new System.Drawing.Size(236, 19);
            this.CheckEditRemChg.TabIndex = 38;
            // 
            // SpinEditComm
            // 
            this.SpinEditComm.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "COMM", true));
            this.SpinEditComm.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SpinEditComm.EnterMoveNextControl = true;
            this.SpinEditComm.Location = new System.Drawing.Point(259, 204);
            this.SpinEditComm.Name = "SpinEditComm";
            this.SpinEditComm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SpinEditComm.Properties.Mask.EditMask = "n2";
            this.SpinEditComm.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            131072});
            this.SpinEditComm.Properties.MinValue = new decimal(new int[] {
            9999,
            0,
            0,
            -2147352576});
            this.SpinEditComm.Size = new System.Drawing.Size(53, 20);
            this.SpinEditComm.TabIndex = 41;
            this.SpinEditComm.Leave += new System.EventHandler(this.SpinEditComm_Leave);
            // 
            // SpinEditCxlGrace
            // 
            this.SpinEditCxlGrace.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CXLGRACE", true));
            this.SpinEditCxlGrace.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SpinEditCxlGrace.EnterMoveNextControl = true;
            this.SpinEditCxlGrace.Location = new System.Drawing.Point(259, 153);
            this.SpinEditCxlGrace.Name = "SpinEditCxlGrace";
            this.SpinEditCxlGrace.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SpinEditCxlGrace.Properties.IsFloatValue = false;
            this.SpinEditCxlGrace.Properties.Mask.EditMask = "N00";
            this.SpinEditCxlGrace.Size = new System.Drawing.Size(53, 20);
            this.SpinEditCxlGrace.TabIndex = 40;
            this.SpinEditCxlGrace.Leave += new System.EventHandler(this.SpinEditCxlGrace_Leave);
            // 
            // SpinEditOptDays
            // 
            this.SpinEditOptDays.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "OPT_DAYS", true));
            this.SpinEditOptDays.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SpinEditOptDays.EnterMoveNextControl = true;
            this.SpinEditOptDays.Location = new System.Drawing.Point(259, 103);
            this.SpinEditOptDays.Name = "SpinEditOptDays";
            this.SpinEditOptDays.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SpinEditOptDays.Properties.IsFloatValue = false;
            this.SpinEditOptDays.Properties.Mask.EditMask = "N00";
            this.SpinEditOptDays.Size = new System.Drawing.Size(53, 20);
            this.SpinEditOptDays.TabIndex = 39;
            this.SpinEditOptDays.Leave += new System.EventHandler(this.SpinEditOptDays_Leave);
            // 
            // XtraTabPageAccounting
            // 
            this.XtraTabPageAccounting.Controls.Add(this.PanelControlAccountTab);
            this.XtraTabPageAccounting.Name = "XtraTabPageAccounting";
            this.XtraTabPageAccounting.Size = new System.Drawing.Size(877, 499);
            this.XtraTabPageAccounting.Text = "Accounting";
            // 
            // PanelControlAccountTab
            // 
            this.PanelControlAccountTab.Controls.Add(LabelPaymentDue);
            this.PanelControlAccountTab.Controls.Add(this.RadioGroupPaymentDue);
            this.PanelControlAccountTab.Controls.Add(this.ButtonDeleteDeposit);
            this.PanelControlAccountTab.Controls.Add(this.ButtonAddDeposit);
            this.PanelControlAccountTab.Controls.Add(label35);
            this.PanelControlAccountTab.Controls.Add(this.GridControlDeposits);
            this.PanelControlAccountTab.Controls.Add(LabelCreditBalance);
            this.PanelControlAccountTab.Controls.Add(LabelAmountPaid);
            this.PanelControlAccountTab.Controls.Add(LabelFundBalance);
            this.PanelControlAccountTab.Controls.Add(LabelCreditUnlimited);
            this.PanelControlAccountTab.Controls.Add(this.CheckEditCreditUnlimited);
            this.PanelControlAccountTab.Controls.Add(LabelCreditLimitRemainingWarningPct);
            this.PanelControlAccountTab.Controls.Add(LabelCreditLimit);
            this.PanelControlAccountTab.Controls.Add(this.SpinEditDaysSpace);
            this.PanelControlAccountTab.Controls.Add(this.SpinEditPriorDays);
            this.PanelControlAccountTab.Controls.Add(this.SpinEditPmtDays);
            this.PanelControlAccountTab.Controls.Add(this.SpinEditDueDays);
            this.PanelControlAccountTab.Controls.Add(this.LabelControlDaysSpace);
            this.PanelControlAccountTab.Controls.Add(this.labelControl9);
            this.PanelControlAccountTab.Controls.Add(this.labelControl8);
            this.PanelControlAccountTab.Controls.Add(this.labelControl7);
            this.PanelControlAccountTab.Controls.Add(this.LabelControlLastInvDate);
            this.PanelControlAccountTab.Controls.Add(this.labelControl5);
            this.PanelControlAccountTab.Controls.Add(this.LabelControlPriorDays);
            this.PanelControlAccountTab.Controls.Add(this.LabelControlPmtDays);
            this.PanelControlAccountTab.Controls.Add(this.LabelControlDueDays);
            this.PanelControlAccountTab.Controls.Add(this.CheckEditSvcDateFlg);
            this.PanelControlAccountTab.Controls.Add(this.ComboBoxEditInvFmt);
            this.PanelControlAccountTab.Controls.Add(this.CheckEditImmedFlg);
            this.PanelControlAccountTab.Controls.Add(this.TextEditFundBalance);
            this.PanelControlAccountTab.Controls.Add(this.SpinEditCreditLimit);
            this.PanelControlAccountTab.Controls.Add(this.SpinEditCreditLimitRemPct);
            this.PanelControlAccountTab.Controls.Add(this.SpinEditCreditBalance);
            this.PanelControlAccountTab.Controls.Add(this.TextEditAmountPaid);
            this.PanelControlAccountTab.Controls.Add(this.DateEditLastInvDate);
            this.PanelControlAccountTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelControlAccountTab.Location = new System.Drawing.Point(0, 0);
            this.PanelControlAccountTab.Name = "PanelControlAccountTab";
            this.PanelControlAccountTab.Size = new System.Drawing.Size(877, 499);
            this.PanelControlAccountTab.TabIndex = 0;
            // 
            // RadioGroupPaymentDue
            // 
            this.RadioGroupPaymentDue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RadioGroupPaymentDue.EditValue = true;
            this.RadioGroupPaymentDue.Location = new System.Drawing.Point(398, 268);
            this.RadioGroupPaymentDue.MenuManager = this.BarManager;
            this.RadioGroupPaymentDue.Name = "RadioGroupPaymentDue";
            this.RadioGroupPaymentDue.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.RadioGroupPaymentDue.Properties.Appearance.Options.UseBackColor = true;
            this.RadioGroupPaymentDue.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.RadioGroupPaymentDue.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "Specific day of month"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Number of days after booking")});
            this.RadioGroupPaymentDue.Size = new System.Drawing.Size(173, 45);
            this.RadioGroupPaymentDue.TabIndex = 79;
            this.RadioGroupPaymentDue.EditValueChanged += new System.EventHandler(this.RadioGroupPaymentDue_EditValueChanged);
            // 
            // BarManager
            // 
            this.BarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.BarManager.DockControls.Add(this.barDockControlTop);
            this.BarManager.DockControls.Add(this.barDockControlBottom);
            this.BarManager.DockControls.Add(this.barDockControlLeft);
            this.BarManager.DockControls.Add(this.barDockControlRight);
            this.BarManager.Form = this;
            this.BarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.BarButtonItemNew,
            this.BarButtonItemDelete,
            this.BarButtonItemSave});
            this.BarManager.MaxItemId = 3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonItemNew),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonItemDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonItemSave)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // BarButtonItemNew
            // 
            this.BarButtonItemNew.Caption = "New";
            this.BarButtonItemNew.Id = 0;
            this.BarButtonItemNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BarButtonItemNew.ImageOptions.Image")));
            this.BarButtonItemNew.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BarButtonItemNew.ImageOptions.LargeImage")));
            this.BarButtonItemNew.Name = "BarButtonItemNew";
            this.BarButtonItemNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemNew_ItemClick);
            // 
            // BarButtonItemDelete
            // 
            this.BarButtonItemDelete.Caption = "Delete";
            this.BarButtonItemDelete.Id = 1;
            this.BarButtonItemDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BarButtonItemDelete.ImageOptions.Image")));
            this.BarButtonItemDelete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BarButtonItemDelete.ImageOptions.LargeImage")));
            this.BarButtonItemDelete.Name = "BarButtonItemDelete";
            this.BarButtonItemDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemDelete_ItemClick);
            // 
            // BarButtonItemSave
            // 
            this.BarButtonItemSave.Caption = "Save";
            this.BarButtonItemSave.Id = 2;
            this.BarButtonItemSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BarButtonItemSave.ImageOptions.Image")));
            this.BarButtonItemSave.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BarButtonItemSave.ImageOptions.LargeImage")));
            this.BarButtonItemSave.Name = "BarButtonItemSave";
            this.BarButtonItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemSave_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.BarManager;
            this.barDockControlTop.Size = new System.Drawing.Size(1183, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 673);
            this.barDockControlBottom.Manager = this.BarManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(1183, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Manager = this.BarManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 642);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1183, 31);
            this.barDockControlRight.Manager = this.BarManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 642);
            // 
            // ButtonDeleteDeposit
            // 
            this.ButtonDeleteDeposit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonDeleteDeposit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonDeleteDeposit.ImageOptions.Image")));
            this.ButtonDeleteDeposit.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ButtonDeleteDeposit.Location = new System.Drawing.Point(819, 109);
            this.ButtonDeleteDeposit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ButtonDeleteDeposit.Name = "ButtonDeleteDeposit";
            this.ButtonDeleteDeposit.Size = new System.Drawing.Size(34, 38);
            this.ButtonDeleteDeposit.TabIndex = 78;
            this.ButtonDeleteDeposit.TabStop = false;
            this.ButtonDeleteDeposit.Text = "Delete Transaction";
            this.ButtonDeleteDeposit.Click += new System.EventHandler(this.ButtonDeleteDeposit_Click);
            // 
            // ButtonAddDeposit
            // 
            this.ButtonAddDeposit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonAddDeposit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonAddDeposit.ImageOptions.Image")));
            this.ButtonAddDeposit.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ButtonAddDeposit.Location = new System.Drawing.Point(819, 65);
            this.ButtonAddDeposit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ButtonAddDeposit.Name = "ButtonAddDeposit";
            this.ButtonAddDeposit.Size = new System.Drawing.Size(34, 38);
            this.ButtonAddDeposit.TabIndex = 77;
            this.ButtonAddDeposit.Text = "Add Transaction";
            this.ButtonAddDeposit.Click += new System.EventHandler(this.ButtonAddDeposit_Click);
            // 
            // GridControlDeposits
            // 
            this.GridControlDeposits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridControlDeposits.DataSource = this.BindingSourcePaymentTransaction;
            this.GridControlDeposits.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.GridControlDeposits.Location = new System.Drawing.Point(398, 34);
            this.GridControlDeposits.MainView = this.GridViewDeposits;
            this.GridControlDeposits.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.GridControlDeposits.Name = "GridControlDeposits";
            this.GridControlDeposits.Size = new System.Drawing.Size(415, 204);
            this.GridControlDeposits.TabIndex = 74;
            this.GridControlDeposits.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewDeposits});
            // 
            // BindingSourcePaymentTransaction
            // 
            this.BindingSourcePaymentTransaction.DataSource = typeof(FlexModel.PaymentTransaction);
            // 
            // GridViewDeposits
            // 
            this.GridViewDeposits.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID2,
            this.colAgency,
            this.colType,
            this.colDate,
            this.colAmount,
            this.colDescription});
            this.GridViewDeposits.DetailHeight = 198;
            this.GridViewDeposits.FixedLineWidth = 1;
            this.GridViewDeposits.GridControl = this.GridControlDeposits;
            this.GridViewDeposits.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", this.colAmount, "")});
            this.GridViewDeposits.Name = "GridViewDeposits";
            this.GridViewDeposits.OptionsView.ShowGroupPanel = false;
            this.GridViewDeposits.OptionsView.ShowIndicator = false;
            // 
            // colID2
            // 
            this.colID2.FieldName = "ID";
            this.colID2.MinWidth = 21;
            this.colID2.Name = "colID2";
            this.colID2.Width = 79;
            // 
            // colAgency
            // 
            this.colAgency.FieldName = "Agency";
            this.colAgency.MinWidth = 21;
            this.colAgency.Name = "colAgency";
            this.colAgency.Width = 79;
            // 
            // colType
            // 
            this.colType.FieldName = "Type";
            this.colType.MinWidth = 21;
            this.colType.Name = "colType";
            this.colType.Width = 79;
            // 
            // colDate
            // 
            this.colDate.FieldName = "Date";
            this.colDate.MinWidth = 21;
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 0;
            this.colDate.Width = 79;
            // 
            // colAmount
            // 
            this.colAmount.FieldName = "Amount";
            this.colAmount.MinWidth = 21;
            this.colAmount.Name = "colAmount";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 1;
            this.colAmount.Width = 79;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.MinWidth = 21;
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 2;
            this.colDescription.Width = 79;
            // 
            // CheckEditCreditUnlimited
            // 
            this.CheckEditCreditUnlimited.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CreditUnlimited", true));
            this.CheckEditCreditUnlimited.Location = new System.Drawing.Point(279, 14);
            this.CheckEditCreditUnlimited.Name = "CheckEditCreditUnlimited";
            this.CheckEditCreditUnlimited.Properties.Caption = "";
            this.CheckEditCreditUnlimited.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditCreditUnlimited.Size = new System.Drawing.Size(22, 19);
            this.CheckEditCreditUnlimited.TabIndex = 54;
            this.CheckEditCreditUnlimited.EditValueChanged += new System.EventHandler(this.CheckEditCreditUnlimited_EditValueChanged);
            // 
            // SpinEditDaysSpace
            // 
            this.SpinEditDaysSpace.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "DAYS_SPACE", true));
            this.SpinEditDaysSpace.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SpinEditDaysSpace.EnterMoveNextControl = true;
            this.SpinEditDaysSpace.Location = new System.Drawing.Point(284, 194);
            this.SpinEditDaysSpace.Name = "SpinEditDaysSpace";
            this.SpinEditDaysSpace.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SpinEditDaysSpace.Properties.IsFloatValue = false;
            this.SpinEditDaysSpace.Properties.Mask.EditMask = "N00";
            this.SpinEditDaysSpace.Size = new System.Drawing.Size(100, 20);
            this.SpinEditDaysSpace.TabIndex = 59;
            this.SpinEditDaysSpace.Leave += new System.EventHandler(this.SpinEditDaysSpace_Leave);
            // 
            // SpinEditPriorDays
            // 
            this.SpinEditPriorDays.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "PRIOR_DAYS", true));
            this.SpinEditPriorDays.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SpinEditPriorDays.EnterMoveNextControl = true;
            this.SpinEditPriorDays.Location = new System.Drawing.Point(284, 168);
            this.SpinEditPriorDays.Name = "SpinEditPriorDays";
            this.SpinEditPriorDays.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SpinEditPriorDays.Properties.IsFloatValue = false;
            this.SpinEditPriorDays.Properties.Mask.EditMask = "N00";
            this.SpinEditPriorDays.Size = new System.Drawing.Size(100, 20);
            this.SpinEditPriorDays.TabIndex = 58;
            this.SpinEditPriorDays.Leave += new System.EventHandler(this.SpinEditPriorDays_Leave);
            // 
            // SpinEditPmtDays
            // 
            this.SpinEditPmtDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SpinEditPmtDays.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "PMT_DAYS", true));
            this.SpinEditPmtDays.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SpinEditPmtDays.EnterMoveNextControl = true;
            this.SpinEditPmtDays.Location = new System.Drawing.Point(688, 342);
            this.SpinEditPmtDays.Name = "SpinEditPmtDays";
            this.SpinEditPmtDays.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SpinEditPmtDays.Properties.IsFloatValue = false;
            this.SpinEditPmtDays.Properties.Mask.EditMask = "N00";
            this.SpinEditPmtDays.Properties.MaxValue = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.SpinEditPmtDays.Properties.MinValue = new decimal(new int[] {
            99,
            0,
            0,
            -2147483648});
            this.SpinEditPmtDays.Size = new System.Drawing.Size(54, 20);
            this.SpinEditPmtDays.TabIndex = 57;
            this.SpinEditPmtDays.Leave += new System.EventHandler(this.SpinEditPmtDays_Leave);
            // 
            // SpinEditDueDays
            // 
            this.SpinEditDueDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SpinEditDueDays.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "DUE_DAY", true));
            this.SpinEditDueDays.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SpinEditDueDays.Enabled = false;
            this.SpinEditDueDays.EnterMoveNextControl = true;
            this.SpinEditDueDays.Location = new System.Drawing.Point(688, 316);
            this.SpinEditDueDays.Name = "SpinEditDueDays";
            this.SpinEditDueDays.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SpinEditDueDays.Properties.IsFloatValue = false;
            this.SpinEditDueDays.Properties.Mask.EditMask = "N00";
            this.SpinEditDueDays.Properties.MaxValue = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.SpinEditDueDays.Size = new System.Drawing.Size(54, 20);
            this.SpinEditDueDays.TabIndex = 55;
            this.SpinEditDueDays.TextChanged += new System.EventHandler(this.SpinEditDueDays_TextChanged);
            this.SpinEditDueDays.Leave += new System.EventHandler(this.SpinEditDueDays_Leave);
            // 
            // LabelControlDaysSpace
            // 
            this.LabelControlDaysSpace.Location = new System.Drawing.Point(30, 197);
            this.LabelControlDaysSpace.Name = "LabelControlDaysSpace";
            this.LabelControlDaysSpace.Size = new System.Drawing.Size(181, 13);
            this.LabelControlDaysSpace.TabIndex = 0;
            this.LabelControlDaysSpace.Text = "Number of days between invoice runs";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(30, 303);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(117, 13);
            this.labelControl9.TabIndex = 0;
            this.labelControl9.Text = "Invoice by services date";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(30, 275);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(70, 13);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "Invoice format";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(30, 249);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(86, 13);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "Immediate invoice";
            // 
            // LabelControlLastInvDate
            // 
            this.LabelControlLastInvDate.Location = new System.Drawing.Point(30, 223);
            this.LabelControlLastInvDate.Name = "LabelControlLastInvDate";
            this.LabelControlLastInvDate.Size = new System.Drawing.Size(81, 13);
            this.LabelControlLastInvDate.TabIndex = 0;
            this.LabelControlLastInvDate.Text = "Last invoice date";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(39, 237);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(0, 13);
            this.labelControl5.TabIndex = 12;
            // 
            // LabelControlPriorDays
            // 
            this.LabelControlPriorDays.Location = new System.Drawing.Point(30, 171);
            this.LabelControlPriorDays.Name = "LabelControlPriorDays";
            this.LabelControlPriorDays.Size = new System.Drawing.Size(242, 13);
            this.LabelControlPriorDays.TabIndex = 0;
            this.LabelControlPriorDays.Text = "Number of days prior to services date for invoicing";
            // 
            // LabelControlPmtDays
            // 
            this.LabelControlPmtDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelControlPmtDays.Location = new System.Drawing.Point(398, 346);
            this.LabelControlPmtDays.Name = "LabelControlPmtDays";
            this.LabelControlPmtDays.Size = new System.Drawing.Size(233, 13);
            this.LabelControlPmtDays.TabIndex = 0;
            this.LabelControlPmtDays.Text = "Number of allowable days for final payment date";
            // 
            // LabelControlDueDays
            // 
            this.LabelControlDueDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelControlDueDays.Location = new System.Drawing.Point(398, 320);
            this.LabelControlDueDays.Name = "LabelControlDueDays";
            this.LabelControlDueDays.Size = new System.Drawing.Size(265, 13);
            this.LabelControlDueDays.TabIndex = 0;
            this.LabelControlDueDays.Text = "Payment due on specific day of month following service";
            // 
            // CheckEditSvcDateFlg
            // 
            this.CheckEditSvcDateFlg.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "SVCDTE_FLG", true));
            this.CheckEditSvcDateFlg.Enabled = false;
            this.CheckEditSvcDateFlg.EnterMoveNextControl = true;
            this.CheckEditSvcDateFlg.Location = new System.Drawing.Point(284, 300);
            this.CheckEditSvcDateFlg.Name = "CheckEditSvcDateFlg";
            this.CheckEditSvcDateFlg.Properties.Caption = "";
            this.CheckEditSvcDateFlg.Properties.ReadOnly = true;
            this.CheckEditSvcDateFlg.Properties.ValueChecked = "Y";
            this.CheckEditSvcDateFlg.Properties.ValueUnchecked = "N";
            this.CheckEditSvcDateFlg.Size = new System.Drawing.Size(23, 19);
            this.CheckEditSvcDateFlg.TabIndex = 63;
            // 
            // ComboBoxEditInvFmt
            // 
            this.ComboBoxEditInvFmt.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "INV_FMT", true));
            this.ComboBoxEditInvFmt.EnterMoveNextControl = true;
            this.ComboBoxEditInvFmt.Location = new System.Drawing.Point(284, 272);
            this.ComboBoxEditInvFmt.Name = "ComboBoxEditInvFmt";
            this.ComboBoxEditInvFmt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ComboBoxEditInvFmt.Properties.Items.AddRange(new object[] {
            "AGY",
            "SGL"});
            this.ComboBoxEditInvFmt.Size = new System.Drawing.Size(100, 20);
            this.ComboBoxEditInvFmt.TabIndex = 62;
            this.ComboBoxEditInvFmt.Leave += new System.EventHandler(this.ComboBoxEditInvFormat_Leave);
            // 
            // CheckEditImmedFlg
            // 
            this.CheckEditImmedFlg.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "IMMED_FLG", true));
            this.CheckEditImmedFlg.EnterMoveNextControl = true;
            this.CheckEditImmedFlg.Location = new System.Drawing.Point(284, 246);
            this.CheckEditImmedFlg.Name = "CheckEditImmedFlg";
            this.CheckEditImmedFlg.Properties.Caption = "";
            this.CheckEditImmedFlg.Properties.ValueChecked = "Y";
            this.CheckEditImmedFlg.Properties.ValueUnchecked = "N";
            this.CheckEditImmedFlg.Size = new System.Drawing.Size(23, 19);
            this.CheckEditImmedFlg.TabIndex = 61;
            // 
            // TextEditFundBalance
            // 
            this.TextEditFundBalance.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CreditLimit", true));
            this.TextEditFundBalance.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TextEditFundBalance.Location = new System.Drawing.Point(284, 115);
            this.TextEditFundBalance.Name = "TextEditFundBalance";
            this.TextEditFundBalance.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TextEditFundBalance.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.TextEditFundBalance.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.TextEditFundBalance.Size = new System.Drawing.Size(100, 20);
            this.TextEditFundBalance.TabIndex = 67;
            // 
            // SpinEditCreditLimit
            // 
            this.SpinEditCreditLimit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CreditLimit", true));
            this.SpinEditCreditLimit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SpinEditCreditLimit.Location = new System.Drawing.Point(284, 39);
            this.SpinEditCreditLimit.Name = "SpinEditCreditLimit";
            this.SpinEditCreditLimit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SpinEditCreditLimit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.SpinEditCreditLimit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.SpinEditCreditLimit.Size = new System.Drawing.Size(100, 20);
            this.SpinEditCreditLimit.TabIndex = 52;
            this.SpinEditCreditLimit.Leave += new System.EventHandler(this.TextEditCreditLimit_Leave);
            // 
            // SpinEditCreditLimitRemPct
            // 
            this.SpinEditCreditLimitRemPct.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CreditLimitRemainingWarningPct", true));
            this.SpinEditCreditLimitRemPct.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SpinEditCreditLimitRemPct.Location = new System.Drawing.Point(284, 65);
            this.SpinEditCreditLimitRemPct.Name = "SpinEditCreditLimitRemPct";
            this.SpinEditCreditLimitRemPct.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SpinEditCreditLimitRemPct.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.SpinEditCreditLimitRemPct.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.SpinEditCreditLimitRemPct.Size = new System.Drawing.Size(100, 20);
            this.SpinEditCreditLimitRemPct.TabIndex = 66;
            this.SpinEditCreditLimitRemPct.Leave += new System.EventHandler(this.TextEditCreditLimitRemPct_Leave);
            // 
            // SpinEditCreditBalance
            // 
            this.SpinEditCreditBalance.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "FundsOnAccount", true));
            this.SpinEditCreditBalance.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SpinEditCreditBalance.Location = new System.Drawing.Point(284, 91);
            this.SpinEditCreditBalance.Name = "SpinEditCreditBalance";
            this.SpinEditCreditBalance.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SpinEditCreditBalance.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.SpinEditCreditBalance.Size = new System.Drawing.Size(100, 20);
            this.SpinEditCreditBalance.TabIndex = 72;
            // 
            // TextEditAmountPaid
            // 
            this.TextEditAmountPaid.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CreditLimit", true));
            this.TextEditAmountPaid.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TextEditAmountPaid.Location = new System.Drawing.Point(284, 141);
            this.TextEditAmountPaid.Name = "TextEditAmountPaid";
            this.TextEditAmountPaid.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TextEditAmountPaid.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.TextEditAmountPaid.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.TextEditAmountPaid.Size = new System.Drawing.Size(100, 20);
            this.TextEditAmountPaid.TabIndex = 70;
            // 
            // DateEditLastInvDate
            // 
            this.DateEditLastInvDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "LAST_INV", true));
            this.DateEditLastInvDate.EditValue = null;
            this.DateEditLastInvDate.Location = new System.Drawing.Point(284, 220);
            this.DateEditLastInvDate.Name = "DateEditLastInvDate";
            this.DateEditLastInvDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateEditLastInvDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateEditLastInvDate.Properties.DisplayFormat.FormatString = "";
            this.DateEditLastInvDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DateEditLastInvDate.Properties.EditFormat.FormatString = "";
            this.DateEditLastInvDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DateEditLastInvDate.Properties.Mask.EditMask = "";
            this.DateEditLastInvDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.DateEditLastInvDate.Size = new System.Drawing.Size(100, 20);
            this.DateEditLastInvDate.TabIndex = 60;
            // 
            // XtraTabPagePayments
            // 
            this.XtraTabPagePayments.Controls.Add(this.panelControl1);
            this.XtraTabPagePayments.Name = "XtraTabPagePayments";
            this.XtraTabPagePayments.Size = new System.Drawing.Size(877, 499);
            this.XtraTabPagePayments.Text = "Payments";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.SimpleButtonRetry);
            this.panelControl1.Controls.Add(this.PanelControlPaymentProfileStatus);
            this.panelControl1.Controls.Add(this.SimpleButtonValidateBankRow);
            this.panelControl1.Controls.Add(this.SimpleButtonValidateCreditRow);
            this.panelControl1.Controls.Add(this.CheckEditAllowElectronicPayment);
            this.panelControl1.Controls.Add(this.CheckEditRequireCVV2);
            this.panelControl1.Controls.Add(this.LabelDefaultPaymentProfileID);
            this.panelControl1.Controls.Add(this.ButtonDeleteCredit);
            this.panelControl1.Controls.Add(this.ButtonDeleteBank);
            this.panelControl1.Controls.Add(paymentProcessorCustProfileIdLabel);
            this.panelControl1.Controls.Add(this.LabelPaymentProcessorCustProfileId);
            this.panelControl1.Controls.Add(this.ButtonAddBank);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.GridControlBankProfiles);
            this.panelControl1.Controls.Add(this.GridControlCreditProfiles);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.AddCreditButton);
            this.panelControl1.Controls.Add(this.LblCreditCardProf);
            this.panelControl1.Controls.Add(this.DeleteButton);
            this.panelControl1.Controls.Add(this.ChangePaymentProfileButton);
            this.panelControl1.Controls.Add(paymentProcessorCustProfileEmailLabel);
            this.panelControl1.Controls.Add(this.TextEditCustomerProfileEmail);
            this.panelControl1.Controls.Add(this.ImageComboBoxEditDefaultPmtProfileID);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(877, 499);
            this.panelControl1.TabIndex = 0;
            // 
            // SimpleButtonRetry
            // 
            this.SimpleButtonRetry.Location = new System.Drawing.Point(670, 14);
            this.SimpleButtonRetry.Name = "SimpleButtonRetry";
            this.SimpleButtonRetry.Size = new System.Drawing.Size(75, 23);
            this.SimpleButtonRetry.TabIndex = 10002;
            this.SimpleButtonRetry.Text = "Retry";
            this.SimpleButtonRetry.Click += new System.EventHandler(this.SimpleButtonRetry_Click);
            // 
            // PanelControlPaymentProfileStatus
            // 
            this.PanelControlPaymentProfileStatus.Appearance.Options.UseTextOptions = true;
            this.PanelControlPaymentProfileStatus.AutoSize = true;
            this.PanelControlPaymentProfileStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("PanelControlPaymentProfileStatus.ContentImage")));
            this.PanelControlPaymentProfileStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.PanelControlPaymentProfileStatus.Controls.Add(this.LabelPaymentProfileStatus);
            this.PanelControlPaymentProfileStatus.Controls.Add(this.labelControl2);
            this.PanelControlPaymentProfileStatus.Location = new System.Drawing.Point(217, 12);
            this.PanelControlPaymentProfileStatus.Name = "PanelControlPaymentProfileStatus";
            this.PanelControlPaymentProfileStatus.Size = new System.Drawing.Size(145, 25);
            this.PanelControlPaymentProfileStatus.TabIndex = 10001;
            this.PanelControlPaymentProfileStatus.Visible = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(30, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(0, 13);
            this.labelControl2.TabIndex = 5;
            // 
            // SimpleButtonValidateBankRow
            // 
            this.SimpleButtonValidateBankRow.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("SimpleButtonValidateBankRow.ImageOptions.Image")));
            this.SimpleButtonValidateBankRow.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.SimpleButtonValidateBankRow.Location = new System.Drawing.Point(803, 373);
            this.SimpleButtonValidateBankRow.Name = "SimpleButtonValidateBankRow";
            this.SimpleButtonValidateBankRow.Size = new System.Drawing.Size(34, 38);
            this.SimpleButtonValidateBankRow.TabIndex = 74;
            this.SimpleButtonValidateBankRow.Text = "Validate Current Row";
            this.SimpleButtonValidateBankRow.Click += new System.EventHandler(this.SimpleButtonValidateBankRow_Click);
            // 
            // SimpleButtonValidateCreditRow
            // 
            this.SimpleButtonValidateCreditRow.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("SimpleButtonValidateCreditRow.ImageOptions.Image")));
            this.SimpleButtonValidateCreditRow.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.SimpleButtonValidateCreditRow.Location = new System.Drawing.Point(803, 212);
            this.SimpleButtonValidateCreditRow.Name = "SimpleButtonValidateCreditRow";
            this.SimpleButtonValidateCreditRow.Size = new System.Drawing.Size(34, 38);
            this.SimpleButtonValidateCreditRow.TabIndex = 73;
            this.SimpleButtonValidateCreditRow.Text = "Validate Current Row";
            this.SimpleButtonValidateCreditRow.Click += new System.EventHandler(this.SimpleButtonValidateCreditRow_Click);
            // 
            // CheckEditAllowElectronicPayment
            // 
            this.CheckEditAllowElectronicPayment.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "AllowElectronicPayment", true));
            this.CheckEditAllowElectronicPayment.Location = new System.Drawing.Point(27, 18);
            this.CheckEditAllowElectronicPayment.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.CheckEditAllowElectronicPayment.Name = "CheckEditAllowElectronicPayment";
            this.CheckEditAllowElectronicPayment.Properties.Caption = "Allow Electronic Payment";
            this.CheckEditAllowElectronicPayment.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditAllowElectronicPayment.Size = new System.Drawing.Size(156, 19);
            this.CheckEditAllowElectronicPayment.TabIndex = 72;
            this.CheckEditAllowElectronicPayment.EditValueChanged += new System.EventHandler(this.CheckEditAllowElectronicPayment_EditValueChanged);
            // 
            // CheckEditRequireCVV2
            // 
            this.CheckEditRequireCVV2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "RequireCVV2Number", true));
            this.CheckEditRequireCVV2.EnterMoveNextControl = true;
            this.CheckEditRequireCVV2.Location = new System.Drawing.Point(285, 72);
            this.CheckEditRequireCVV2.Name = "CheckEditRequireCVV2";
            this.CheckEditRequireCVV2.Properties.Caption = "Require CVV2 Number";
            this.CheckEditRequireCVV2.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditRequireCVV2.Properties.ValueGrayed = "";
            this.CheckEditRequireCVV2.Size = new System.Drawing.Size(130, 19);
            this.CheckEditRequireCVV2.TabIndex = 51;
            this.CheckEditRequireCVV2.EditValueChanged += new System.EventHandler(this.CheckEditRequireCVV2_EditValueChanged);
            this.CheckEditRequireCVV2.Click += new System.EventHandler(this.CheckEditRequireCVV2_Click);
            // 
            // LabelDefaultPaymentProfileID
            // 
            this.LabelDefaultPaymentProfileID.AutoSize = true;
            this.LabelDefaultPaymentProfileID.BackColor = System.Drawing.Color.Transparent;
            this.LabelDefaultPaymentProfileID.Location = new System.Drawing.Point(14, 423);
            this.LabelDefaultPaymentProfileID.Name = "LabelDefaultPaymentProfileID";
            this.LabelDefaultPaymentProfileID.Size = new System.Drawing.Size(134, 13);
            this.LabelDefaultPaymentProfileID.TabIndex = 70;
            this.LabelDefaultPaymentProfileID.Text = "Default Payment Profile ID";
            // 
            // ButtonDeleteCredit
            // 
            this.ButtonDeleteCredit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonDeleteCredit.ImageOptions.Image")));
            this.ButtonDeleteCredit.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ButtonDeleteCredit.Location = new System.Drawing.Point(803, 167);
            this.ButtonDeleteCredit.Name = "ButtonDeleteCredit";
            this.ButtonDeleteCredit.Size = new System.Drawing.Size(34, 38);
            this.ButtonDeleteCredit.TabIndex = 69;
            this.ButtonDeleteCredit.TabStop = false;
            this.ButtonDeleteCredit.Text = "Delete Credit Card Profile";
            this.ButtonDeleteCredit.Click += new System.EventHandler(this.ButtonDeleteCredit_Click);
            // 
            // ButtonDeleteBank
            // 
            this.ButtonDeleteBank.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonDeleteBank.ImageOptions.Image")));
            this.ButtonDeleteBank.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ButtonDeleteBank.Location = new System.Drawing.Point(803, 329);
            this.ButtonDeleteBank.Name = "ButtonDeleteBank";
            this.ButtonDeleteBank.Size = new System.Drawing.Size(34, 38);
            this.ButtonDeleteBank.TabIndex = 68;
            this.ButtonDeleteBank.TabStop = false;
            this.ButtonDeleteBank.Text = "Delete Bank Account Profile";
            this.ButtonDeleteBank.Click += new System.EventHandler(this.ButtonDeleteBank_Click);
            // 
            // LabelPaymentProcessorCustProfileId
            // 
            this.LabelPaymentProcessorCustProfileId.BackColor = System.Drawing.Color.Transparent;
            this.LabelPaymentProcessorCustProfileId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "PaymentProcessorCustProfileId", true));
            this.LabelPaymentProcessorCustProfileId.Location = new System.Drawing.Point(163, 73);
            this.LabelPaymentProcessorCustProfileId.Name = "LabelPaymentProcessorCustProfileId";
            this.LabelPaymentProcessorCustProfileId.Size = new System.Drawing.Size(100, 23);
            this.LabelPaymentProcessorCustProfileId.TabIndex = 65;
            this.LabelPaymentProcessorCustProfileId.TextChanged += new System.EventHandler(this.LabelPaymentProcessorCustProfileId_TextChanged);
            // 
            // ButtonAddBank
            // 
            this.ButtonAddBank.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonAddBank.ImageOptions.Image")));
            this.ButtonAddBank.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ButtonAddBank.Location = new System.Drawing.Point(803, 285);
            this.ButtonAddBank.Name = "ButtonAddBank";
            this.ButtonAddBank.Size = new System.Drawing.Size(34, 38);
            this.ButtonAddBank.TabIndex = 67;
            this.ButtonAddBank.Text = "Add Bank Account Profile";
            this.ButtonAddBank.Click += new System.EventHandler(this.ButtonAddBank_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(27, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Bank Account Profiles";
            // 
            // GridControlBankProfiles
            // 
            this.GridControlBankProfiles.DataSource = this.BindingSourceAgencyPaymentProfile;
            this.GridControlBankProfiles.Location = new System.Drawing.Point(12, 285);
            this.GridControlBankProfiles.MainView = this.GridViewBankProfiles;
            this.GridControlBankProfiles.Name = "GridControlBankProfiles";
            this.GridControlBankProfiles.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBoxAccountType});
            this.GridControlBankProfiles.Size = new System.Drawing.Size(785, 127);
            this.GridControlBankProfiles.TabIndex = 53;
            this.GridControlBankProfiles.TabStop = false;
            this.GridControlBankProfiles.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewBankProfiles});
            // 
            // BindingSourceAgencyPaymentProfile
            // 
            this.BindingSourceAgencyPaymentProfile.DataSource = typeof(FlexModel.AgencyPaymentProfile);
            // 
            // GridViewBankProfiles
            // 
            this.GridViewBankProfiles.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.GridViewBankProfiles.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GridViewBankProfiles.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnID,
            this.gridColumnBankName,
            this.gridColumnAccountType,
            this.gridColumnAccountNo,
            this.gridColumnStreet,
            this.gridColumnCity,
            this.gridColumnState,
            this.gridColumnZipCode,
            this.gridColumnCountry,
            this.gridColumnPhone,
            this.gridColumnRoutingNo,
            this.gridColumnNameOnAccount});
            this.GridViewBankProfiles.DetailHeight = 198;
            this.GridViewBankProfiles.FixedLineWidth = 1;
            this.GridViewBankProfiles.GridControl = this.GridControlBankProfiles;
            this.GridViewBankProfiles.Name = "GridViewBankProfiles";
            this.GridViewBankProfiles.OptionsView.ShowGroupPanel = false;
            this.GridViewBankProfiles.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.GridViewBankProfiles_InvalidRowException);
            this.GridViewBankProfiles.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.GridViewBankProfiles_ValidateRow);
            this.GridViewBankProfiles.CustomRowFilter += new DevExpress.XtraGrid.Views.Base.RowFilterEventHandler(this.GridViewBankProfiles_CustomRowFilter);
            this.GridViewBankProfiles.SubstituteFilter += new System.EventHandler<DevExpress.Data.SubstituteFilterEventArgs>(this.GridViewBankProfiles_SubstituteFilter);
            // 
            // gridColumnID
            // 
            this.gridColumnID.Caption = "ID";
            this.gridColumnID.FieldName = "ProfileID";
            this.gridColumnID.MinWidth = 12;
            this.gridColumnID.Name = "gridColumnID";
            this.gridColumnID.Visible = true;
            this.gridColumnID.VisibleIndex = 0;
            this.gridColumnID.Width = 41;
            // 
            // gridColumnBankName
            // 
            this.gridColumnBankName.Caption = "Bank Name";
            this.gridColumnBankName.FieldName = "BankName";
            this.gridColumnBankName.MinWidth = 12;
            this.gridColumnBankName.Name = "gridColumnBankName";
            this.gridColumnBankName.Visible = true;
            this.gridColumnBankName.VisibleIndex = 1;
            this.gridColumnBankName.Width = 53;
            // 
            // gridColumnAccountType
            // 
            this.gridColumnAccountType.Caption = "Account Type";
            this.gridColumnAccountType.ColumnEdit = this.repositoryItemImageComboBoxAccountType;
            this.gridColumnAccountType.FieldName = "AccountType";
            this.gridColumnAccountType.MinWidth = 12;
            this.gridColumnAccountType.Name = "gridColumnAccountType";
            this.gridColumnAccountType.Visible = true;
            this.gridColumnAccountType.VisibleIndex = 2;
            this.gridColumnAccountType.Width = 53;
            // 
            // repositoryItemImageComboBoxAccountType
            // 
            this.repositoryItemImageComboBoxAccountType.AutoHeight = false;
            this.repositoryItemImageComboBoxAccountType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBoxAccountType.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Checking", ((short)(0)), -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Saving", ((short)(1)), -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Business checking", ((short)(2)), -1)});
            this.repositoryItemImageComboBoxAccountType.Name = "repositoryItemImageComboBoxAccountType";
            // 
            // gridColumnAccountNo
            // 
            this.gridColumnAccountNo.Caption = "Account Nbr";
            this.gridColumnAccountNo.FieldName = "BankAccountNumber";
            this.gridColumnAccountNo.MinWidth = 12;
            this.gridColumnAccountNo.Name = "gridColumnAccountNo";
            this.gridColumnAccountNo.Visible = true;
            this.gridColumnAccountNo.VisibleIndex = 3;
            this.gridColumnAccountNo.Width = 48;
            // 
            // gridColumnStreet
            // 
            this.gridColumnStreet.Caption = "Street";
            this.gridColumnStreet.FieldName = "BillingAddress.Street";
            this.gridColumnStreet.MinWidth = 12;
            this.gridColumnStreet.Name = "gridColumnStreet";
            this.gridColumnStreet.Visible = true;
            this.gridColumnStreet.VisibleIndex = 6;
            this.gridColumnStreet.Width = 53;
            // 
            // gridColumnCity
            // 
            this.gridColumnCity.Caption = "City";
            this.gridColumnCity.FieldName = "BillingAddress.City";
            this.gridColumnCity.MinWidth = 12;
            this.gridColumnCity.Name = "gridColumnCity";
            this.gridColumnCity.Visible = true;
            this.gridColumnCity.VisibleIndex = 7;
            this.gridColumnCity.Width = 43;
            // 
            // gridColumnState
            // 
            this.gridColumnState.Caption = "State";
            this.gridColumnState.FieldName = "BillingAddress.State";
            this.gridColumnState.MinWidth = 12;
            this.gridColumnState.Name = "gridColumnState";
            this.gridColumnState.Visible = true;
            this.gridColumnState.VisibleIndex = 8;
            this.gridColumnState.Width = 26;
            // 
            // gridColumnZipCode
            // 
            this.gridColumnZipCode.Caption = "Zip Code";
            this.gridColumnZipCode.FieldName = "BillingAddress.Zip";
            this.gridColumnZipCode.MinWidth = 12;
            this.gridColumnZipCode.Name = "gridColumnZipCode";
            this.gridColumnZipCode.Visible = true;
            this.gridColumnZipCode.VisibleIndex = 9;
            this.gridColumnZipCode.Width = 38;
            // 
            // gridColumnCountry
            // 
            this.gridColumnCountry.Caption = "Country";
            this.gridColumnCountry.FieldName = "BillingAddress.Country";
            this.gridColumnCountry.MinWidth = 12;
            this.gridColumnCountry.Name = "gridColumnCountry";
            this.gridColumnCountry.Visible = true;
            this.gridColumnCountry.VisibleIndex = 10;
            this.gridColumnCountry.Width = 28;
            // 
            // gridColumnPhone
            // 
            this.gridColumnPhone.Caption = "Phone No.";
            this.gridColumnPhone.FieldName = "BillingAddress.Phone";
            this.gridColumnPhone.MinWidth = 12;
            this.gridColumnPhone.Name = "gridColumnPhone";
            this.gridColumnPhone.Visible = true;
            this.gridColumnPhone.VisibleIndex = 11;
            this.gridColumnPhone.Width = 69;
            // 
            // gridColumnRoutingNo
            // 
            this.gridColumnRoutingNo.Caption = "Routing Nbr";
            this.gridColumnRoutingNo.FieldName = "BankRoutingNumber";
            this.gridColumnRoutingNo.MinWidth = 12;
            this.gridColumnRoutingNo.Name = "gridColumnRoutingNo";
            this.gridColumnRoutingNo.Visible = true;
            this.gridColumnRoutingNo.VisibleIndex = 4;
            this.gridColumnRoutingNo.Width = 45;
            // 
            // gridColumnNameOnAccount
            // 
            this.gridColumnNameOnAccount.Caption = "Name on Acct";
            this.gridColumnNameOnAccount.FieldName = "BankNameOnAccount";
            this.gridColumnNameOnAccount.MinWidth = 12;
            this.gridColumnNameOnAccount.Name = "gridColumnNameOnAccount";
            this.gridColumnNameOnAccount.Visible = true;
            this.gridColumnNameOnAccount.VisibleIndex = 5;
            this.gridColumnNameOnAccount.Width = 54;
            // 
            // GridControlCreditProfiles
            // 
            this.GridControlCreditProfiles.DataSource = this.BindingSourceAgencyPaymentProfile;
            this.GridControlCreditProfiles.Location = new System.Drawing.Point(12, 123);
            this.GridControlCreditProfiles.MainView = this.GridViewCreditProfiles;
            this.GridControlCreditProfiles.Name = "GridControlCreditProfiles";
            this.GridControlCreditProfiles.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemComboBox1,
            this.RepositoryItemImageComboBoxExpMonth,
            this.RepositoryItemSpinEditExpYear});
            this.GridControlCreditProfiles.Size = new System.Drawing.Size(785, 127);
            this.GridControlCreditProfiles.TabIndex = 52;
            this.GridControlCreditProfiles.TabStop = false;
            this.GridControlCreditProfiles.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewCreditProfiles});
            // 
            // GridViewCreditProfiles
            // 
            this.GridViewCreditProfiles.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.GridViewCreditProfiles.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GridViewCreditProfiles.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.GridViewCreditProfiles.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdColID,
            this.grdColCardNo,
            this.grdColExpirationYear,
            this.grdColCVV2,
            this.grdColCompany,
            this.grdColFirst,
            this.grdColLast,
            this.gridColStreet,
            this.gridColCity,
            this.gridColState,
            this.gridColZip,
            this.gridColCountry,
            this.gridColAccountType,
            this.gridColPhone,
            this.gridColExpirationMonth});
            this.GridViewCreditProfiles.DetailHeight = 198;
            this.GridViewCreditProfiles.FixedLineWidth = 1;
            this.GridViewCreditProfiles.GridControl = this.GridControlCreditProfiles;
            this.GridViewCreditProfiles.Name = "GridViewCreditProfiles";
            this.GridViewCreditProfiles.OptionsView.AllowHtmlDrawHeaders = true;
            this.GridViewCreditProfiles.OptionsView.ShowGroupPanel = false;
            this.GridViewCreditProfiles.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.GridViewCreditProfiles_CustomRowCellEdit);
            this.GridViewCreditProfiles.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.GridViewPaymentProfiles_InvalidRowException);
            this.GridViewCreditProfiles.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.GridViewPaymentProfiles_ValidateRow);
            this.GridViewCreditProfiles.CustomRowFilter += new DevExpress.XtraGrid.Views.Base.RowFilterEventHandler(this.GridViewCreditProfiles_CustomRowFilter);
            this.GridViewCreditProfiles.SubstituteFilter += new System.EventHandler<DevExpress.Data.SubstituteFilterEventArgs>(this.GridViewCreditProfiles_SubstituteFilter);
            // 
            // grdColID
            // 
            this.grdColID.Caption = "ID";
            this.grdColID.ColumnEdit = this.repositoryItemComboBox1;
            this.grdColID.FieldName = "ProfileID";
            this.grdColID.MinWidth = 12;
            this.grdColID.Name = "grdColID";
            this.grdColID.Width = 84;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // grdColCardNo
            // 
            this.grdColCardNo.Caption = "Card No";
            this.grdColCardNo.FieldName = "CardNumber";
            this.grdColCardNo.MinWidth = 12;
            this.grdColCardNo.Name = "grdColCardNo";
            this.grdColCardNo.Visible = true;
            this.grdColCardNo.VisibleIndex = 0;
            this.grdColCardNo.Width = 135;
            // 
            // grdColExpirationYear
            // 
            this.grdColExpirationYear.Caption = "Year";
            this.grdColExpirationYear.ColumnEdit = this.RepositoryItemSpinEditExpYear;
            this.grdColExpirationYear.FieldName = "CardExpiration";
            this.grdColExpirationYear.MinWidth = 12;
            this.grdColExpirationYear.Name = "grdColExpirationYear";
            this.grdColExpirationYear.Visible = true;
            this.grdColExpirationYear.VisibleIndex = 1;
            this.grdColExpirationYear.Width = 66;
            // 
            // RepositoryItemSpinEditExpYear
            // 
            this.RepositoryItemSpinEditExpYear.AutoHeight = false;
            this.RepositoryItemSpinEditExpYear.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemSpinEditExpYear.Name = "RepositoryItemSpinEditExpYear";
            // 
            // grdColCVV2
            // 
            this.grdColCVV2.Caption = "CVV2";
            this.grdColCVV2.FieldName = "CardCode";
            this.grdColCVV2.MinWidth = 12;
            this.grdColCVV2.Name = "grdColCVV2";
            this.grdColCVV2.Visible = true;
            this.grdColCVV2.VisibleIndex = 3;
            this.grdColCVV2.Width = 49;
            // 
            // grdColCompany
            // 
            this.grdColCompany.Caption = "Company";
            this.grdColCompany.FieldName = "BillingAddress.Company";
            this.grdColCompany.MinWidth = 12;
            this.grdColCompany.Name = "grdColCompany";
            this.grdColCompany.Width = 62;
            // 
            // grdColFirst
            // 
            this.grdColFirst.Caption = "First";
            this.grdColFirst.FieldName = "BillingAddress.First";
            this.grdColFirst.MinWidth = 12;
            this.grdColFirst.Name = "grdColFirst";
            this.grdColFirst.Visible = true;
            this.grdColFirst.VisibleIndex = 4;
            this.grdColFirst.Width = 58;
            // 
            // grdColLast
            // 
            this.grdColLast.Caption = "Last";
            this.grdColLast.FieldName = "BillingAddress.Last";
            this.grdColLast.MinWidth = 12;
            this.grdColLast.Name = "grdColLast";
            this.grdColLast.Visible = true;
            this.grdColLast.VisibleIndex = 5;
            this.grdColLast.Width = 58;
            // 
            // gridColStreet
            // 
            this.gridColStreet.Caption = "Street";
            this.gridColStreet.FieldName = "BillingAddress.Street";
            this.gridColStreet.MinWidth = 12;
            this.gridColStreet.Name = "gridColStreet";
            this.gridColStreet.Visible = true;
            this.gridColStreet.VisibleIndex = 6;
            this.gridColStreet.Width = 80;
            // 
            // gridColCity
            // 
            this.gridColCity.Caption = "City";
            this.gridColCity.FieldName = "BillingAddress.City";
            this.gridColCity.MinWidth = 12;
            this.gridColCity.Name = "gridColCity";
            this.gridColCity.Visible = true;
            this.gridColCity.VisibleIndex = 7;
            this.gridColCity.Width = 58;
            // 
            // gridColState
            // 
            this.gridColState.Caption = "State";
            this.gridColState.FieldName = "BillingAddress.State";
            this.gridColState.MinWidth = 12;
            this.gridColState.Name = "gridColState";
            this.gridColState.Visible = true;
            this.gridColState.VisibleIndex = 8;
            this.gridColState.Width = 45;
            // 
            // gridColZip
            // 
            this.gridColZip.Caption = "Zip Code";
            this.gridColZip.FieldName = "BillingAddress.Zip";
            this.gridColZip.MinWidth = 12;
            this.gridColZip.Name = "gridColZip";
            this.gridColZip.Visible = true;
            this.gridColZip.VisibleIndex = 9;
            this.gridColZip.Width = 52;
            // 
            // gridColCountry
            // 
            this.gridColCountry.Caption = "Country";
            this.gridColCountry.FieldName = "BillingAddress.Country";
            this.gridColCountry.MinWidth = 12;
            this.gridColCountry.Name = "gridColCountry";
            this.gridColCountry.Visible = true;
            this.gridColCountry.VisibleIndex = 10;
            this.gridColCountry.Width = 98;
            // 
            // gridColAccountType
            // 
            this.gridColAccountType.FieldName = "AccountType";
            this.gridColAccountType.Name = "gridColAccountType";
            // 
            // gridColPhone
            // 
            this.gridColPhone.Caption = "Phone No.";
            this.gridColPhone.FieldName = "BillingAddress.Phone";
            this.gridColPhone.MinWidth = 12;
            this.gridColPhone.Name = "gridColPhone";
            this.gridColPhone.Visible = true;
            this.gridColPhone.VisibleIndex = 11;
            this.gridColPhone.Width = 196;
            // 
            // gridColExpirationMonth
            // 
            this.gridColExpirationMonth.Caption = "Month";
            this.gridColExpirationMonth.ColumnEdit = this.RepositoryItemImageComboBoxExpMonth;
            this.gridColExpirationMonth.FieldName = "ExpirationMonth";
            this.gridColExpirationMonth.Name = "gridColExpirationMonth";
            this.gridColExpirationMonth.Visible = true;
            this.gridColExpirationMonth.VisibleIndex = 2;
            this.gridColExpirationMonth.Width = 86;
            // 
            // RepositoryItemImageComboBoxExpMonth
            // 
            this.RepositoryItemImageComboBoxExpMonth.AutoHeight = false;
            this.RepositoryItemImageComboBoxExpMonth.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemImageComboBoxExpMonth.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("January", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("February", 2, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("March", 3, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("April", 4, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("May", 5, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("June", 6, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("July", 7, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("August", 8, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Semptember", 9, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("October", 10, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("November", 11, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("December", 12, -1)});
            this.RepositoryItemImageComboBoxExpMonth.Name = "RepositoryItemImageComboBoxExpMonth";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(792, 542);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 11;
            this.simpleButton1.Text = "Delete";
            // 
            // AddCreditButton
            // 
            this.AddCreditButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("AddCreditButton.ImageOptions.Image")));
            this.AddCreditButton.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.AddCreditButton.Location = new System.Drawing.Point(803, 123);
            this.AddCreditButton.Name = "AddCreditButton";
            this.AddCreditButton.Size = new System.Drawing.Size(34, 38);
            this.AddCreditButton.TabIndex = 10;
            this.AddCreditButton.Text = "Add Credit Card Profile";
            this.AddCreditButton.Click += new System.EventHandler(this.ButtonAddCredit_Click);
            // 
            // LblCreditCardProf
            // 
            this.LblCreditCardProf.AutoSize = true;
            this.LblCreditCardProf.BackColor = System.Drawing.Color.Transparent;
            this.LblCreditCardProf.Location = new System.Drawing.Point(27, 107);
            this.LblCreditCardProf.Name = "LblCreditCardProf";
            this.LblCreditCardProf.Size = new System.Drawing.Size(100, 13);
            this.LblCreditCardProf.TabIndex = 4;
            this.LblCreditCardProf.Text = "Credit Card Profiles";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(670, 70);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 5;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ChangePaymentProfileButton
            // 
            this.ChangePaymentProfileButton.Location = new System.Drawing.Point(570, 70);
            this.ChangePaymentProfileButton.Name = "ChangePaymentProfileButton";
            this.ChangePaymentProfileButton.Size = new System.Drawing.Size(75, 23);
            this.ChangePaymentProfileButton.TabIndex = 4;
            this.ChangePaymentProfileButton.Text = "Create";
            this.ChangePaymentProfileButton.Click += new System.EventHandler(this.ChangePaymentProfileButton_Click);
            // 
            // TextEditCustomerProfileEmail
            // 
            this.TextEditCustomerProfileEmail.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "PaymentProcessorCustProfileEmail", true));
            this.TextEditCustomerProfileEmail.Location = new System.Drawing.Point(166, 44);
            this.TextEditCustomerProfileEmail.Name = "TextEditCustomerProfileEmail";
            this.TextEditCustomerProfileEmail.Size = new System.Drawing.Size(579, 20);
            this.TextEditCustomerProfileEmail.TabIndex = 50;
            this.TextEditCustomerProfileEmail.EditValueChanged += new System.EventHandler(this.TextEditPaymentProcessorCustProfileEmail_EditValueChanged);
            this.TextEditCustomerProfileEmail.Leave += new System.EventHandler(this.TextEditPaymentProcessorCustProfileEmail_Leave);
            // 
            // ImageComboBoxEditDefaultPmtProfileID
            // 
            this.ImageComboBoxEditDefaultPmtProfileID.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "DefaultPaymentProfileId", true));
            this.ImageComboBoxEditDefaultPmtProfileID.Location = new System.Drawing.Point(151, 420);
            this.ImageComboBoxEditDefaultPmtProfileID.Name = "ImageComboBoxEditDefaultPmtProfileID";
            this.ImageComboBoxEditDefaultPmtProfileID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ImageComboBoxEditDefaultPmtProfileID.Size = new System.Drawing.Size(218, 20);
            this.ImageComboBoxEditDefaultPmtProfileID.TabIndex = 54;
            this.ImageComboBoxEditDefaultPmtProfileID.Leave += new System.EventHandler(this.ImageComboBoxEditDefaultProfileID_Leave);
            // 
            // XtraTabPageAdministrativeFees
            // 
            this.XtraTabPageAdministrativeFees.Controls.Add(this.PanelControlAdminTab);
            this.XtraTabPageAdministrativeFees.Name = "XtraTabPageAdministrativeFees";
            this.XtraTabPageAdministrativeFees.Size = new System.Drawing.Size(877, 499);
            this.XtraTabPageAdministrativeFees.Text = "Administrative Fees";
            // 
            // PanelControlAdminTab
            // 
            this.PanelControlAdminTab.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.PanelControlAdminTab.Appearance.Options.UseBackColor = true;
            this.PanelControlAdminTab.Controls.Add(cHG1_FLATLabel);
            this.PanelControlAdminTab.Controls.Add(this.TextEditChgFlat2);
            this.PanelControlAdminTab.Controls.Add(cHG1_PCTLabel);
            this.PanelControlAdminTab.Controls.Add(this.TextEditChgFlat3);
            this.PanelControlAdminTab.Controls.Add(this.TextEditChgFlat1);
            this.PanelControlAdminTab.Controls.Add(this.TextEditChgPct2);
            this.PanelControlAdminTab.Controls.Add(cHG1_NTSPRIORLabel);
            this.PanelControlAdminTab.Controls.Add(label21);
            this.PanelControlAdminTab.Controls.Add(this.TextEditChgPct1);
            this.PanelControlAdminTab.Controls.Add(this.SpinEditChgNtsPrior2);
            this.PanelControlAdminTab.Controls.Add(this.SpinEditCxlNtsPrior1);
            this.PanelControlAdminTab.Controls.Add(label26);
            this.PanelControlAdminTab.Controls.Add(this.SpinEditChgNtsPrior1);
            this.PanelControlAdminTab.Controls.Add(cXL2_FLATLabel);
            this.PanelControlAdminTab.Controls.Add(cXL1_PCTLabel);
            this.PanelControlAdminTab.Controls.Add(label25);
            this.PanelControlAdminTab.Controls.Add(this.TextEditCxlFlat1);
            this.PanelControlAdminTab.Controls.Add(this.TextEditCxlFlat3);
            this.PanelControlAdminTab.Controls.Add(cXL1_NTSPRIORLabel);
            this.PanelControlAdminTab.Controls.Add(label24);
            this.PanelControlAdminTab.Controls.Add(this.TextEditCxlPct1);
            this.PanelControlAdminTab.Controls.Add(this.TextEditChgPct3);
            this.PanelControlAdminTab.Controls.Add(this.SpinEditCxlNtsPrior2);
            this.PanelControlAdminTab.Controls.Add(label20);
            this.PanelControlAdminTab.Controls.Add(this.TextEditCxlPct3);
            this.PanelControlAdminTab.Controls.Add(label19);
            this.PanelControlAdminTab.Controls.Add(this.labelControl13);
            this.PanelControlAdminTab.Controls.Add(label18);
            this.PanelControlAdminTab.Controls.Add(label22);
            this.PanelControlAdminTab.Controls.Add(this.TextEditCxlFlat2);
            this.PanelControlAdminTab.Controls.Add(this.labelControl12);
            this.PanelControlAdminTab.Controls.Add(this.TextEditCxlPct2);
            this.PanelControlAdminTab.Controls.Add(this.SpinEditChgNtsPrior3);
            this.PanelControlAdminTab.Controls.Add(this.labelControl11);
            this.PanelControlAdminTab.Controls.Add(label23);
            this.PanelControlAdminTab.Controls.Add(this.SpinEditCxlNtsPrior3);
            this.PanelControlAdminTab.Controls.Add(label28);
            this.PanelControlAdminTab.Controls.Add(label29);
            this.PanelControlAdminTab.Controls.Add(label27);
            this.PanelControlAdminTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelControlAdminTab.Location = new System.Drawing.Point(0, 0);
            this.PanelControlAdminTab.Name = "PanelControlAdminTab";
            this.PanelControlAdminTab.Size = new System.Drawing.Size(877, 499);
            this.PanelControlAdminTab.TabIndex = 0;
            // 
            // TextEditChgFlat2
            // 
            this.TextEditChgFlat2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CHG2_FLAT", true));
            this.TextEditChgFlat2.EnterMoveNextControl = true;
            this.TextEditChgFlat2.Location = new System.Drawing.Point(373, 296);
            this.TextEditChgFlat2.Name = "TextEditChgFlat2";
            this.TextEditChgFlat2.Size = new System.Drawing.Size(46, 20);
            this.TextEditChgFlat2.TabIndex = 78;
            this.TextEditChgFlat2.Leave += new System.EventHandler(this.TextEditChg2Flat_Leave);
            // 
            // TextEditChgFlat3
            // 
            this.TextEditChgFlat3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CHG3_FLAT", true));
            this.TextEditChgFlat3.EnterMoveNextControl = true;
            this.TextEditChgFlat3.Location = new System.Drawing.Point(603, 296);
            this.TextEditChgFlat3.Name = "TextEditChgFlat3";
            this.TextEditChgFlat3.Size = new System.Drawing.Size(46, 20);
            this.TextEditChgFlat3.TabIndex = 81;
            this.TextEditChgFlat3.Leave += new System.EventHandler(this.TextEditChg3Flat_Leave);
            // 
            // TextEditChgFlat1
            // 
            this.TextEditChgFlat1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CHG1_FLAT", true));
            this.TextEditChgFlat1.EnterMoveNextControl = true;
            this.TextEditChgFlat1.Location = new System.Drawing.Point(142, 296);
            this.TextEditChgFlat1.Name = "TextEditChgFlat1";
            this.TextEditChgFlat1.Size = new System.Drawing.Size(46, 20);
            this.TextEditChgFlat1.TabIndex = 75;
            this.TextEditChgFlat1.Leave += new System.EventHandler(this.TextEditChg1Flat_Leave);
            // 
            // TextEditChgPct2
            // 
            this.TextEditChgPct2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CHG2_PCT", true));
            this.TextEditChgPct2.EnterMoveNextControl = true;
            this.TextEditChgPct2.Location = new System.Drawing.Point(373, 259);
            this.TextEditChgPct2.Name = "TextEditChgPct2";
            this.TextEditChgPct2.Properties.Mask.EditMask = "P";
            this.TextEditChgPct2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.TextEditChgPct2.Size = new System.Drawing.Size(46, 20);
            this.TextEditChgPct2.TabIndex = 77;
            this.TextEditChgPct2.Leave += new System.EventHandler(this.TextEditChg2Pct_Leave);
            // 
            // TextEditChgPct1
            // 
            this.TextEditChgPct1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CHG1_PCT", true));
            this.TextEditChgPct1.EnterMoveNextControl = true;
            this.TextEditChgPct1.Location = new System.Drawing.Point(142, 259);
            this.TextEditChgPct1.Name = "TextEditChgPct1";
            this.TextEditChgPct1.Properties.Mask.EditMask = "P";
            this.TextEditChgPct1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.TextEditChgPct1.Size = new System.Drawing.Size(46, 20);
            this.TextEditChgPct1.TabIndex = 74;
            this.TextEditChgPct1.Leave += new System.EventHandler(this.TextEditChg1Pct_Leave);
            // 
            // SpinEditChgNtsPrior2
            // 
            this.SpinEditChgNtsPrior2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CHG2_NTSPRIOR", true));
            this.SpinEditChgNtsPrior2.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SpinEditChgNtsPrior2.EnterMoveNextControl = true;
            this.SpinEditChgNtsPrior2.Location = new System.Drawing.Point(373, 218);
            this.SpinEditChgNtsPrior2.Name = "SpinEditChgNtsPrior2";
            this.SpinEditChgNtsPrior2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SpinEditChgNtsPrior2.Properties.IsFloatValue = false;
            this.SpinEditChgNtsPrior2.Properties.Mask.EditMask = "N00";
            this.SpinEditChgNtsPrior2.Size = new System.Drawing.Size(46, 20);
            this.SpinEditChgNtsPrior2.TabIndex = 76;
            this.SpinEditChgNtsPrior2.Leave += new System.EventHandler(this.SpinEditChg2NtsPrior_Leave);
            // 
            // SpinEditCxlNtsPrior1
            // 
            this.SpinEditCxlNtsPrior1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CXL1_NTSPRIOR", true));
            this.SpinEditCxlNtsPrior1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SpinEditCxlNtsPrior1.EnterMoveNextControl = true;
            this.SpinEditCxlNtsPrior1.Location = new System.Drawing.Point(142, 73);
            this.SpinEditCxlNtsPrior1.Name = "SpinEditCxlNtsPrior1";
            this.SpinEditCxlNtsPrior1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SpinEditCxlNtsPrior1.Properties.IsFloatValue = false;
            this.SpinEditCxlNtsPrior1.Properties.Mask.EditMask = "N00";
            this.SpinEditCxlNtsPrior1.Size = new System.Drawing.Size(46, 20);
            this.SpinEditCxlNtsPrior1.TabIndex = 64;
            this.SpinEditCxlNtsPrior1.Leave += new System.EventHandler(this.SpinEditCxl1NtsPrior_Leave);
            // 
            // SpinEditChgNtsPrior1
            // 
            this.SpinEditChgNtsPrior1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CHG1_NTSPRIOR", true));
            this.SpinEditChgNtsPrior1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SpinEditChgNtsPrior1.EnterMoveNextControl = true;
            this.SpinEditChgNtsPrior1.Location = new System.Drawing.Point(142, 218);
            this.SpinEditChgNtsPrior1.Name = "SpinEditChgNtsPrior1";
            this.SpinEditChgNtsPrior1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SpinEditChgNtsPrior1.Properties.IsFloatValue = false;
            this.SpinEditChgNtsPrior1.Properties.Mask.EditMask = "N00";
            this.SpinEditChgNtsPrior1.Size = new System.Drawing.Size(46, 20);
            this.SpinEditChgNtsPrior1.TabIndex = 73;
            this.SpinEditChgNtsPrior1.Leave += new System.EventHandler(this.SpinEditChg1NtsPrior_Leave);
            // 
            // TextEditCxlFlat1
            // 
            this.TextEditCxlFlat1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CXL1_FLAT", true));
            this.TextEditCxlFlat1.EnterMoveNextControl = true;
            this.TextEditCxlFlat1.Location = new System.Drawing.Point(142, 152);
            this.TextEditCxlFlat1.Name = "TextEditCxlFlat1";
            this.TextEditCxlFlat1.Size = new System.Drawing.Size(46, 20);
            this.TextEditCxlFlat1.TabIndex = 66;
            this.TextEditCxlFlat1.Leave += new System.EventHandler(this.TextEditCxl1Flat_Leave);
            // 
            // TextEditCxlFlat3
            // 
            this.TextEditCxlFlat3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CXL3_FLAT", true));
            this.TextEditCxlFlat3.EnterMoveNextControl = true;
            this.TextEditCxlFlat3.Location = new System.Drawing.Point(603, 152);
            this.TextEditCxlFlat3.Name = "TextEditCxlFlat3";
            this.TextEditCxlFlat3.Size = new System.Drawing.Size(46, 20);
            this.TextEditCxlFlat3.TabIndex = 72;
            this.TextEditCxlFlat3.Leave += new System.EventHandler(this.TextEditCxl3Flat_Leave);
            // 
            // TextEditCxlPct1
            // 
            this.TextEditCxlPct1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CXL1_PCT", true));
            this.TextEditCxlPct1.EnterMoveNextControl = true;
            this.TextEditCxlPct1.Location = new System.Drawing.Point(142, 113);
            this.TextEditCxlPct1.Name = "TextEditCxlPct1";
            this.TextEditCxlPct1.Properties.Mask.EditMask = "P";
            this.TextEditCxlPct1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.TextEditCxlPct1.Size = new System.Drawing.Size(46, 20);
            this.TextEditCxlPct1.TabIndex = 65;
            this.TextEditCxlPct1.Leave += new System.EventHandler(this.TextEditCxl1Pct_Leave);
            // 
            // TextEditChgPct3
            // 
            this.TextEditChgPct3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CHG3_PCT", true));
            this.TextEditChgPct3.EnterMoveNextControl = true;
            this.TextEditChgPct3.Location = new System.Drawing.Point(603, 259);
            this.TextEditChgPct3.Name = "TextEditChgPct3";
            this.TextEditChgPct3.Properties.Mask.EditMask = "P";
            this.TextEditChgPct3.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.TextEditChgPct3.Size = new System.Drawing.Size(46, 20);
            this.TextEditChgPct3.TabIndex = 80;
            this.TextEditChgPct3.Leave += new System.EventHandler(this.TextEditChg3Pct_Leave);
            // 
            // SpinEditCxlNtsPrior2
            // 
            this.SpinEditCxlNtsPrior2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CXL2_NTSPRIOR", true));
            this.SpinEditCxlNtsPrior2.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SpinEditCxlNtsPrior2.EnterMoveNextControl = true;
            this.SpinEditCxlNtsPrior2.Location = new System.Drawing.Point(373, 73);
            this.SpinEditCxlNtsPrior2.Name = "SpinEditCxlNtsPrior2";
            this.SpinEditCxlNtsPrior2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SpinEditCxlNtsPrior2.Properties.IsFloatValue = false;
            this.SpinEditCxlNtsPrior2.Properties.Mask.EditMask = "N00";
            this.SpinEditCxlNtsPrior2.Size = new System.Drawing.Size(46, 20);
            this.SpinEditCxlNtsPrior2.TabIndex = 67;
            this.SpinEditCxlNtsPrior2.Leave += new System.EventHandler(this.SpinEditCxl2NtsPrior_Leave);
            // 
            // TextEditCxlPct3
            // 
            this.TextEditCxlPct3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CXL3_PCT", true));
            this.TextEditCxlPct3.EnterMoveNextControl = true;
            this.TextEditCxlPct3.Location = new System.Drawing.Point(603, 113);
            this.TextEditCxlPct3.Name = "TextEditCxlPct3";
            this.TextEditCxlPct3.Properties.Mask.EditMask = "P";
            this.TextEditCxlPct3.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.TextEditCxlPct3.Size = new System.Drawing.Size(46, 20);
            this.TextEditCxlPct3.TabIndex = 71;
            this.TextEditCxlPct3.Leave += new System.EventHandler(this.TextEditCxl3Pct_Leave);
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Location = new System.Drawing.Point(545, 23);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(71, 16);
            this.labelControl13.TabIndex = 0;
            this.labelControl13.Text = "Level 3 Fees";
            // 
            // TextEditCxlFlat2
            // 
            this.TextEditCxlFlat2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CXL2_FLAT", true));
            this.TextEditCxlFlat2.EnterMoveNextControl = true;
            this.TextEditCxlFlat2.Location = new System.Drawing.Point(373, 152);
            this.TextEditCxlFlat2.Name = "TextEditCxlFlat2";
            this.TextEditCxlFlat2.Size = new System.Drawing.Size(46, 20);
            this.TextEditCxlFlat2.TabIndex = 69;
            this.TextEditCxlFlat2.Leave += new System.EventHandler(this.TextEditCxl2Flat_Leave);
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Location = new System.Drawing.Point(293, 23);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(71, 16);
            this.labelControl12.TabIndex = 0;
            this.labelControl12.Text = "Level 2 Fees";
            // 
            // TextEditCxlPct2
            // 
            this.TextEditCxlPct2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CXL2_PCT", true));
            this.TextEditCxlPct2.EnterMoveNextControl = true;
            this.TextEditCxlPct2.Location = new System.Drawing.Point(373, 113);
            this.TextEditCxlPct2.Name = "TextEditCxlPct2";
            this.TextEditCxlPct2.Properties.Mask.EditMask = "P";
            this.TextEditCxlPct2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.TextEditCxlPct2.Size = new System.Drawing.Size(46, 20);
            this.TextEditCxlPct2.TabIndex = 68;
            this.TextEditCxlPct2.Leave += new System.EventHandler(this.TextEditCxl2Pct_Leave);
            // 
            // SpinEditChgNtsPrior3
            // 
            this.SpinEditChgNtsPrior3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CHG3_NTSPRIOR", true));
            this.SpinEditChgNtsPrior3.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SpinEditChgNtsPrior3.EnterMoveNextControl = true;
            this.SpinEditChgNtsPrior3.Location = new System.Drawing.Point(603, 218);
            this.SpinEditChgNtsPrior3.Name = "SpinEditChgNtsPrior3";
            this.SpinEditChgNtsPrior3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SpinEditChgNtsPrior3.Properties.IsFloatValue = false;
            this.SpinEditChgNtsPrior3.Properties.Mask.EditMask = "N00";
            this.SpinEditChgNtsPrior3.Size = new System.Drawing.Size(46, 20);
            this.SpinEditChgNtsPrior3.TabIndex = 79;
            this.SpinEditChgNtsPrior3.Leave += new System.EventHandler(this.SpinEditChg3NtsPrior_Leave);
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(78, 23);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(71, 16);
            this.labelControl11.TabIndex = 0;
            this.labelControl11.Text = "Level 1 Fees";
            // 
            // SpinEditCxlNtsPrior3
            // 
            this.SpinEditCxlNtsPrior3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CXL3_NTSPRIOR", true));
            this.SpinEditCxlNtsPrior3.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SpinEditCxlNtsPrior3.EnterMoveNextControl = true;
            this.SpinEditCxlNtsPrior3.Location = new System.Drawing.Point(603, 73);
            this.SpinEditCxlNtsPrior3.Name = "SpinEditCxlNtsPrior3";
            this.SpinEditCxlNtsPrior3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SpinEditCxlNtsPrior3.Properties.IsFloatValue = false;
            this.SpinEditCxlNtsPrior3.Properties.Mask.EditMask = "N00";
            this.SpinEditCxlNtsPrior3.Size = new System.Drawing.Size(46, 20);
            this.SpinEditCxlNtsPrior3.TabIndex = 70;
            this.SpinEditCxlNtsPrior3.Leave += new System.EventHandler(this.SpinEditCxl3NtsPrior_Leave);
            // 
            // XtraTabPageMemberships
            // 
            this.XtraTabPageMemberships.Controls.Add(this.PanelControlMemberTab);
            this.XtraTabPageMemberships.Name = "XtraTabPageMemberships";
            this.XtraTabPageMemberships.Size = new System.Drawing.Size(877, 499);
            this.XtraTabPageMemberships.Text = "Memberships";
            // 
            // PanelControlMemberTab
            // 
            this.PanelControlMemberTab.Controls.Add(sRT3Label);
            this.PanelControlMemberTab.Controls.Add(this.TextEditSrt3);
            this.PanelControlMemberTab.Controls.Add(sRT2Label);
            this.PanelControlMemberTab.Controls.Add(this.TextEditSrt2);
            this.PanelControlMemberTab.Controls.Add(this.ButtonDeleteMembership);
            this.PanelControlMemberTab.Controls.Add(this.ButtonAddMembership);
            this.PanelControlMemberTab.Controls.Add(this.GridControlMemberships);
            this.PanelControlMemberTab.Controls.Add(pARENTLabel);
            this.PanelControlMemberTab.Controls.Add(this.SearchLookupEditParentAgy);
            this.PanelControlMemberTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelControlMemberTab.Location = new System.Drawing.Point(0, 0);
            this.PanelControlMemberTab.Name = "PanelControlMemberTab";
            this.PanelControlMemberTab.Size = new System.Drawing.Size(877, 499);
            this.PanelControlMemberTab.TabIndex = 0;
            // 
            // TextEditSrt3
            // 
            this.TextEditSrt3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "SRT3", true));
            this.TextEditSrt3.EnterMoveNextControl = true;
            this.TextEditSrt3.Location = new System.Drawing.Point(387, 49);
            this.TextEditSrt3.Name = "TextEditSrt3";
            this.TextEditSrt3.Properties.MaxLength = 10;
            this.TextEditSrt3.Size = new System.Drawing.Size(177, 20);
            this.TextEditSrt3.TabIndex = 90;
            // 
            // TextEditSrt2
            // 
            this.TextEditSrt2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "SRT2", true));
            this.TextEditSrt2.EnterMoveNextControl = true;
            this.TextEditSrt2.Location = new System.Drawing.Point(120, 50);
            this.TextEditSrt2.Name = "TextEditSrt2";
            this.TextEditSrt2.Properties.MaxLength = 10;
            this.TextEditSrt2.Size = new System.Drawing.Size(177, 20);
            this.TextEditSrt2.TabIndex = 89;
            // 
            // ButtonDeleteMembership
            // 
            this.ButtonDeleteMembership.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonDeleteMembership.ImageOptions.Image")));
            this.ButtonDeleteMembership.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ButtonDeleteMembership.Location = new System.Drawing.Point(746, 130);
            this.ButtonDeleteMembership.Name = "ButtonDeleteMembership";
            this.ButtonDeleteMembership.Size = new System.Drawing.Size(34, 38);
            this.ButtonDeleteMembership.TabIndex = 43;
            this.ButtonDeleteMembership.TabStop = false;
            this.ButtonDeleteMembership.Text = "Delete Membership";
            this.ButtonDeleteMembership.Click += new System.EventHandler(this.ButtonDeleteMembership_Click);
            // 
            // ButtonAddMembership
            // 
            this.ButtonAddMembership.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonAddMembership.ImageOptions.Image")));
            this.ButtonAddMembership.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ButtonAddMembership.Location = new System.Drawing.Point(746, 85);
            this.ButtonAddMembership.Name = "ButtonAddMembership";
            this.ButtonAddMembership.Size = new System.Drawing.Size(34, 38);
            this.ButtonAddMembership.TabIndex = 41;
            this.ButtonAddMembership.TabStop = false;
            this.ButtonAddMembership.Text = "Add Membership";
            this.ButtonAddMembership.Click += new System.EventHandler(this.ButtonAddMembership_Click);
            // 
            // GridControlMemberships
            // 
            this.GridControlMemberships.DataSource = this.BindingSourceDetail;
            this.GridControlMemberships.Location = new System.Drawing.Point(34, 85);
            this.GridControlMemberships.MainView = this.GridViewMemberships;
            this.GridControlMemberships.Name = "GridControlMemberships";
            this.GridControlMemberships.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RepositoryItemSearchLookUpEditClass});
            this.GridControlMemberships.Size = new System.Drawing.Size(706, 319);
            this.GridControlMemberships.TabIndex = 2;
            this.GridControlMemberships.TabStop = false;
            this.GridControlMemberships.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewMemberships});
            // 
            // GridViewMemberships
            // 
            this.GridViewMemberships.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID1,
            this.colLINK_TABLE2,
            this.colRECTYPE2,
            this.colLINK_VALUE1,
            this.colCODE,
            this.colNOTE,
            this.colUSER_DEC12,
            this.colUSER_DEC22,
            this.colUSER_INT12,
            this.colUSER_INT22,
            this.colUSER_TXT12,
            this.colUSER_TXT22,
            this.colUSER_TXT32,
            this.colUSER_TXT42,
            this.colUSER_DTE12,
            this.colUSER_DTE22});
            this.GridViewMemberships.DetailHeight = 198;
            this.GridViewMemberships.FixedLineWidth = 1;
            this.GridViewMemberships.GridControl = this.GridControlMemberships;
            this.GridViewMemberships.Name = "GridViewMemberships";
            this.GridViewMemberships.OptionsView.ShowGroupPanel = false;
            this.GridViewMemberships.OptionsView.ShowIndicator = false;
            this.GridViewMemberships.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.GridViewMemberships_CellValueChanged);
            // 
            // colID1
            // 
            this.colID1.FieldName = "ID";
            this.colID1.MinWidth = 12;
            this.colID1.Name = "colID1";
            this.colID1.Width = 45;
            // 
            // colLINK_TABLE2
            // 
            this.colLINK_TABLE2.FieldName = "LINK_TABLE";
            this.colLINK_TABLE2.MinWidth = 12;
            this.colLINK_TABLE2.Name = "colLINK_TABLE2";
            this.colLINK_TABLE2.Width = 45;
            // 
            // colRECTYPE2
            // 
            this.colRECTYPE2.FieldName = "RECTYPE";
            this.colRECTYPE2.MinWidth = 12;
            this.colRECTYPE2.Name = "colRECTYPE2";
            this.colRECTYPE2.Width = 45;
            // 
            // colLINK_VALUE1
            // 
            this.colLINK_VALUE1.FieldName = "LINK_VALUE";
            this.colLINK_VALUE1.MinWidth = 12;
            this.colLINK_VALUE1.Name = "colLINK_VALUE1";
            this.colLINK_VALUE1.Width = 45;
            // 
            // colCODE
            // 
            this.colCODE.Caption = "Classification";
            this.colCODE.ColumnEdit = this.RepositoryItemSearchLookUpEditClass;
            this.colCODE.FieldName = "CODE";
            this.colCODE.MinWidth = 12;
            this.colCODE.Name = "colCODE";
            this.colCODE.Visible = true;
            this.colCODE.VisibleIndex = 0;
            this.colCODE.Width = 45;
            // 
            // RepositoryItemSearchLookUpEditClass
            // 
            this.RepositoryItemSearchLookUpEditClass.AutoHeight = false;
            this.RepositoryItemSearchLookUpEditClass.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemSearchLookUpEditClass.DataSource = this.BindingSourceCodeName;
            this.RepositoryItemSearchLookUpEditClass.DisplayMember = "DisplayName";
            this.RepositoryItemSearchLookUpEditClass.Name = "RepositoryItemSearchLookUpEditClass";
            this.RepositoryItemSearchLookUpEditClass.NullText = "";
            this.RepositoryItemSearchLookUpEditClass.PopupView = this.gridView1;
            this.RepositoryItemSearchLookUpEditClass.ValueMember = "Code";
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode5,
            this.colName7});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // colCode5
            // 
            this.colCode5.FieldName = "Code";
            this.colCode5.Name = "colCode5";
            this.colCode5.Visible = true;
            this.colCode5.VisibleIndex = 0;
            // 
            // colName7
            // 
            this.colName7.FieldName = "Name";
            this.colName7.Name = "colName7";
            this.colName7.Visible = true;
            this.colName7.VisibleIndex = 1;
            // 
            // colNOTE
            // 
            this.colNOTE.Caption = "Note";
            this.colNOTE.FieldName = "NOTE";
            this.colNOTE.MinWidth = 12;
            this.colNOTE.Name = "colNOTE";
            this.colNOTE.Visible = true;
            this.colNOTE.VisibleIndex = 1;
            this.colNOTE.Width = 45;
            // 
            // colUSER_DEC12
            // 
            this.colUSER_DEC12.FieldName = "USER_DEC1";
            this.colUSER_DEC12.MinWidth = 12;
            this.colUSER_DEC12.Name = "colUSER_DEC12";
            this.colUSER_DEC12.Width = 45;
            // 
            // colUSER_DEC22
            // 
            this.colUSER_DEC22.FieldName = "USER_DEC2";
            this.colUSER_DEC22.MinWidth = 12;
            this.colUSER_DEC22.Name = "colUSER_DEC22";
            this.colUSER_DEC22.Width = 45;
            // 
            // colUSER_INT12
            // 
            this.colUSER_INT12.FieldName = "USER_INT1";
            this.colUSER_INT12.MinWidth = 12;
            this.colUSER_INT12.Name = "colUSER_INT12";
            this.colUSER_INT12.Width = 45;
            // 
            // colUSER_INT22
            // 
            this.colUSER_INT22.FieldName = "USER_INT2";
            this.colUSER_INT22.MinWidth = 12;
            this.colUSER_INT22.Name = "colUSER_INT22";
            this.colUSER_INT22.Width = 45;
            // 
            // colUSER_TXT12
            // 
            this.colUSER_TXT12.FieldName = "USER_TXT1";
            this.colUSER_TXT12.MinWidth = 12;
            this.colUSER_TXT12.Name = "colUSER_TXT12";
            this.colUSER_TXT12.Width = 45;
            // 
            // colUSER_TXT22
            // 
            this.colUSER_TXT22.FieldName = "USER_TXT2";
            this.colUSER_TXT22.MinWidth = 12;
            this.colUSER_TXT22.Name = "colUSER_TXT22";
            this.colUSER_TXT22.Width = 45;
            // 
            // colUSER_TXT32
            // 
            this.colUSER_TXT32.FieldName = "USER_TXT3";
            this.colUSER_TXT32.MinWidth = 12;
            this.colUSER_TXT32.Name = "colUSER_TXT32";
            this.colUSER_TXT32.Width = 45;
            // 
            // colUSER_TXT42
            // 
            this.colUSER_TXT42.FieldName = "USER_TXT4";
            this.colUSER_TXT42.MinWidth = 12;
            this.colUSER_TXT42.Name = "colUSER_TXT42";
            this.colUSER_TXT42.Width = 45;
            // 
            // colUSER_DTE12
            // 
            this.colUSER_DTE12.FieldName = "USER_DTE1";
            this.colUSER_DTE12.MinWidth = 12;
            this.colUSER_DTE12.Name = "colUSER_DTE12";
            this.colUSER_DTE12.Width = 45;
            // 
            // colUSER_DTE22
            // 
            this.colUSER_DTE22.FieldName = "USER_DTE2";
            this.colUSER_DTE22.MinWidth = 12;
            this.colUSER_DTE22.Name = "colUSER_DTE22";
            this.colUSER_DTE22.Width = 45;
            // 
            // SearchLookupEditParentAgy
            // 
            this.SearchLookupEditParentAgy.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "PARENT", true));
            this.SearchLookupEditParentAgy.Location = new System.Drawing.Point(120, 18);
            this.SearchLookupEditParentAgy.Name = "SearchLookupEditParentAgy";
            this.SearchLookupEditParentAgy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLookupEditParentAgy.Properties.DataSource = this.BindingSourceCodeName;
            this.SearchLookupEditParentAgy.Properties.DisplayMember = "DisplayName";
            this.SearchLookupEditParentAgy.Properties.NullText = "";
            this.SearchLookupEditParentAgy.Properties.PopupSizeable = false;
            this.SearchLookupEditParentAgy.Properties.PopupView = this.gridView4;
            this.SearchLookupEditParentAgy.Properties.ValueMember = "Code";
            this.SearchLookupEditParentAgy.Size = new System.Drawing.Size(237, 20);
            this.SearchLookupEditParentAgy.TabIndex = 82;
            this.SearchLookupEditParentAgy.Leave += new System.EventHandler(this.SearchLookupEditParentAgy_Leave);
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode4,
            this.colName5});
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            this.gridView4.OptionsView.ShowIndicator = false;
            // 
            // colCode4
            // 
            this.colCode4.FieldName = "Code";
            this.colCode4.Name = "colCode4";
            this.colCode4.Visible = true;
            this.colCode4.VisibleIndex = 0;
            // 
            // colName5
            // 
            this.colName5.FieldName = "Name";
            this.colName5.Name = "colName5";
            this.colName5.Visible = true;
            this.colName5.VisibleIndex = 1;
            // 
            // XtraTabPageResources
            // 
            this.XtraTabPageResources.AutoScroll = true;
            this.XtraTabPageResources.Controls.Add(this.PanelControlResourceTab);
            this.XtraTabPageResources.Name = "XtraTabPageResources";
            this.XtraTabPageResources.Size = new System.Drawing.Size(877, 499);
            this.XtraTabPageResources.Text = "Resources";
            // 
            // PanelControlResourceTab
            // 
            this.PanelControlResourceTab.Controls.Add(this.labelControlSize);
            this.PanelControlResourceTab.Controls.Add(LabelSize);
            this.PanelControlResourceTab.Controls.Add(lOGO_PATHLabel);
            this.PanelControlResourceTab.Controls.Add(this.ButtonEditLogoPath);
            this.PanelControlResourceTab.Controls.Add(wEBSITELabel);
            this.PanelControlResourceTab.Controls.Add(this.TextEditWebsite);
            this.PanelControlResourceTab.Controls.Add(this.labelControl15);
            this.PanelControlResourceTab.Controls.Add(this.PictureEditPreview);
            this.PanelControlResourceTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelControlResourceTab.Location = new System.Drawing.Point(0, 0);
            this.PanelControlResourceTab.Name = "PanelControlResourceTab";
            this.PanelControlResourceTab.Size = new System.Drawing.Size(877, 499);
            this.PanelControlResourceTab.TabIndex = 0;
            this.PanelControlResourceTab.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelControl14_Paint);
            // 
            // labelControlSize
            // 
            this.labelControlSize.Location = new System.Drawing.Point(67, 357);
            this.labelControlSize.Name = "labelControlSize";
            this.labelControlSize.Size = new System.Drawing.Size(0, 13);
            this.labelControlSize.TabIndex = 10000;
            // 
            // ButtonEditLogoPath
            // 
            this.ButtonEditLogoPath.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "LOGO_PATH", true));
            this.ButtonEditLogoPath.EnterMoveNextControl = true;
            this.ButtonEditLogoPath.Location = new System.Drawing.Point(80, 31);
            this.ButtonEditLogoPath.Name = "ButtonEditLogoPath";
            this.ButtonEditLogoPath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ButtonEditLogoPath.Properties.MaxLength = 255;
            this.ButtonEditLogoPath.Size = new System.Drawing.Size(644, 20);
            this.ButtonEditLogoPath.TabIndex = 83;
            this.ButtonEditLogoPath.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonEditLogoPath_ButtonPressed);
            this.ButtonEditLogoPath.TextChanged += new System.EventHandler(this.ButtonEditLogoPath_TextChanged);
            // 
            // TextEditWebsite
            // 
            this.TextEditWebsite.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "WEBSITE", true));
            this.TextEditWebsite.EnterMoveNextControl = true;
            this.TextEditWebsite.Location = new System.Drawing.Point(80, 406);
            this.TextEditWebsite.Name = "TextEditWebsite";
            this.TextEditWebsite.Properties.MaxLength = 255;
            this.TextEditWebsite.Size = new System.Drawing.Size(644, 20);
            this.TextEditWebsite.TabIndex = 84;
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl15.Appearance.Options.UseFont = true;
            this.labelControl15.Location = new System.Drawing.Point(31, 74);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(45, 16);
            this.labelControl15.TabIndex = 0;
            this.labelControl15.Text = "Preview";
            // 
            // PictureEditPreview
            // 
            this.PictureEditPreview.Location = new System.Drawing.Point(31, 104);
            this.PictureEditPreview.Name = "PictureEditPreview";
            this.PictureEditPreview.Size = new System.Drawing.Size(238, 247);
            this.PictureEditPreview.TabIndex = 0;
            // 
            // XtraTabPageCustom
            // 
            this.XtraTabPageCustom.Controls.Add(this.PanelControlCustomTab);
            this.XtraTabPageCustom.Name = "XtraTabPageCustom";
            this.XtraTabPageCustom.Size = new System.Drawing.Size(877, 499);
            this.XtraTabPageCustom.Text = "Custom";
            // 
            // PanelControlCustomTab
            // 
            this.PanelControlCustomTab.Controls.Add(this.GridControlCustom);
            this.PanelControlCustomTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelControlCustomTab.Location = new System.Drawing.Point(0, 0);
            this.PanelControlCustomTab.Name = "PanelControlCustomTab";
            this.PanelControlCustomTab.Size = new System.Drawing.Size(877, 499);
            this.PanelControlCustomTab.TabIndex = 0;
            // 
            // GridControlCustom
            // 
            this.GridControlCustom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridControlCustom.DataSource = this.BindingSourceUserfield;
            this.GridControlCustom.Location = new System.Drawing.Point(23, 83);
            this.GridControlCustom.MainView = this.GridViewCustom;
            this.GridControlCustom.Name = "GridControlCustom";
            this.GridControlCustom.Size = new System.Drawing.Size(771, 301);
            this.GridControlCustom.TabIndex = 4;
            this.GridControlCustom.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewCustom});
            // 
            // GridViewCustom
            // 
            this.GridViewCustom.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLINK_TABLE1,
            this.colLINK_COLUMN,
            this.colRECTYPE1,
            this.colLABEL,
            this.colDESC,
            this.colVISIBLE,
            this.colLKUP_CODE_COLUMN,
            this.colLKUP_DESC_COLUMN,
            this.colLKUP_TABLE,
            this.colSIZE,
            this.colMIN,
            this.colMAX,
            this.colRESTRICT_TO_LKUP,
            this.colPRECISION,
            this.colREQUIRED});
            this.GridViewCustom.DetailHeight = 198;
            this.GridViewCustom.FixedLineWidth = 1;
            this.GridViewCustom.GridControl = this.GridControlCustom;
            this.GridViewCustom.Name = "GridViewCustom";
            this.GridViewCustom.OptionsView.ShowGroupPanel = false;
            this.GridViewCustom.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.GridViewCustom_CustomUnboundColumnData);
            // 
            // colLINK_TABLE1
            // 
            this.colLINK_TABLE1.FieldName = "LINK_TABLE";
            this.colLINK_TABLE1.MinWidth = 12;
            this.colLINK_TABLE1.Name = "colLINK_TABLE1";
            this.colLINK_TABLE1.Width = 45;
            // 
            // colLINK_COLUMN
            // 
            this.colLINK_COLUMN.FieldName = "LINK_COLUMN";
            this.colLINK_COLUMN.MinWidth = 12;
            this.colLINK_COLUMN.Name = "colLINK_COLUMN";
            this.colLINK_COLUMN.Width = 45;
            // 
            // colRECTYPE1
            // 
            this.colRECTYPE1.FieldName = "RECTYPE";
            this.colRECTYPE1.MinWidth = 12;
            this.colRECTYPE1.Name = "colRECTYPE1";
            this.colRECTYPE1.Width = 45;
            // 
            // colLABEL
            // 
            this.colLABEL.FieldName = "LABEL";
            this.colLABEL.MinWidth = 12;
            this.colLABEL.Name = "colLABEL";
            this.colLABEL.OptionsColumn.AllowEdit = false;
            this.colLABEL.OptionsColumn.TabStop = false;
            this.colLABEL.Visible = true;
            this.colLABEL.VisibleIndex = 0;
            this.colLABEL.Width = 45;
            // 
            // colDESC
            // 
            this.colDESC.FieldName = "DESC";
            this.colDESC.MinWidth = 12;
            this.colDESC.Name = "colDESC";
            this.colDESC.Width = 45;
            // 
            // colVISIBLE
            // 
            this.colVISIBLE.FieldName = "VISIBLE";
            this.colVISIBLE.MinWidth = 12;
            this.colVISIBLE.Name = "colVISIBLE";
            this.colVISIBLE.Width = 45;
            // 
            // colLKUP_CODE_COLUMN
            // 
            this.colLKUP_CODE_COLUMN.FieldName = "LKUP_CODE_COLUMN";
            this.colLKUP_CODE_COLUMN.MinWidth = 12;
            this.colLKUP_CODE_COLUMN.Name = "colLKUP_CODE_COLUMN";
            this.colLKUP_CODE_COLUMN.Width = 45;
            // 
            // colLKUP_DESC_COLUMN
            // 
            this.colLKUP_DESC_COLUMN.FieldName = "LKUP_DESC_COLUMN";
            this.colLKUP_DESC_COLUMN.MinWidth = 12;
            this.colLKUP_DESC_COLUMN.Name = "colLKUP_DESC_COLUMN";
            this.colLKUP_DESC_COLUMN.Width = 45;
            // 
            // colLKUP_TABLE
            // 
            this.colLKUP_TABLE.FieldName = "LKUP_TABLE";
            this.colLKUP_TABLE.MinWidth = 12;
            this.colLKUP_TABLE.Name = "colLKUP_TABLE";
            this.colLKUP_TABLE.Width = 45;
            // 
            // colSIZE
            // 
            this.colSIZE.FieldName = "SIZE";
            this.colSIZE.MinWidth = 12;
            this.colSIZE.Name = "colSIZE";
            this.colSIZE.Width = 45;
            // 
            // colMIN
            // 
            this.colMIN.FieldName = "MIN";
            this.colMIN.MinWidth = 12;
            this.colMIN.Name = "colMIN";
            this.colMIN.Width = 45;
            // 
            // colMAX
            // 
            this.colMAX.FieldName = "MAX";
            this.colMAX.MinWidth = 12;
            this.colMAX.Name = "colMAX";
            this.colMAX.Width = 45;
            // 
            // colRESTRICT_TO_LKUP
            // 
            this.colRESTRICT_TO_LKUP.FieldName = "RESTRICT_TO_LKUP";
            this.colRESTRICT_TO_LKUP.MinWidth = 12;
            this.colRESTRICT_TO_LKUP.Name = "colRESTRICT_TO_LKUP";
            this.colRESTRICT_TO_LKUP.Width = 45;
            // 
            // colPRECISION
            // 
            this.colPRECISION.FieldName = "PRECISION";
            this.colPRECISION.MinWidth = 12;
            this.colPRECISION.Name = "colPRECISION";
            this.colPRECISION.Width = 45;
            // 
            // colREQUIRED
            // 
            this.colREQUIRED.FieldName = "REQUIRED";
            this.colREQUIRED.MinWidth = 12;
            this.colREQUIRED.Name = "colREQUIRED";
            this.colREQUIRED.Width = 45;
            // 
            // XtraTabPageCommissions
            // 
            this.XtraTabPageCommissions.Controls.Add(this.PanelControlCommTab);
            this.XtraTabPageCommissions.Name = "XtraTabPageCommissions";
            this.XtraTabPageCommissions.Size = new System.Drawing.Size(877, 499);
            this.XtraTabPageCommissions.Text = "Commissions";
            // 
            // PanelControlCommTab
            // 
            this.PanelControlCommTab.Controls.Add(this.LabelMarkups);
            this.PanelControlCommTab.Controls.Add(this.LabelCommissions);
            this.PanelControlCommTab.Controls.Add(this.LabelSource);
            this.PanelControlCommTab.Controls.Add(this.ComboBoxEditSource);
            this.PanelControlCommTab.Controls.Add(this.ButtonSearch);
            this.PanelControlCommTab.Controls.Add(this.LabelDate);
            this.PanelControlCommTab.Controls.Add(this.LabelAgency);
            this.PanelControlCommTab.Controls.Add(this.GridControlMarkups);
            this.PanelControlCommTab.Controls.Add(this.GridControlCommissions);
            this.PanelControlCommTab.Controls.Add(this.SearchLookupEditAgency);
            this.PanelControlCommTab.Controls.Add(this.DateEditDate);
            this.PanelControlCommTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelControlCommTab.Location = new System.Drawing.Point(0, 0);
            this.PanelControlCommTab.Name = "PanelControlCommTab";
            this.PanelControlCommTab.Size = new System.Drawing.Size(877, 499);
            this.PanelControlCommTab.TabIndex = 0;
            // 
            // LabelMarkups
            // 
            this.LabelMarkups.AutoSize = true;
            this.LabelMarkups.BackColor = System.Drawing.Color.Transparent;
            this.LabelMarkups.Location = new System.Drawing.Point(31, 244);
            this.LabelMarkups.Name = "LabelMarkups";
            this.LabelMarkups.Size = new System.Drawing.Size(47, 13);
            this.LabelMarkups.TabIndex = 91;
            this.LabelMarkups.Text = "Markups";
            // 
            // LabelCommissions
            // 
            this.LabelCommissions.AutoSize = true;
            this.LabelCommissions.BackColor = System.Drawing.Color.Transparent;
            this.LabelCommissions.Location = new System.Drawing.Point(31, 45);
            this.LabelCommissions.Name = "LabelCommissions";
            this.LabelCommissions.Size = new System.Drawing.Size(67, 13);
            this.LabelCommissions.TabIndex = 90;
            this.LabelCommissions.Text = "Commissions";
            // 
            // LabelSource
            // 
            this.LabelSource.Location = new System.Drawing.Point(34, 17);
            this.LabelSource.Name = "LabelSource";
            this.LabelSource.Size = new System.Drawing.Size(33, 13);
            this.LabelSource.TabIndex = 0;
            this.LabelSource.Text = "Source";
            // 
            // ComboBoxEditSource
            // 
            this.ComboBoxEditSource.EnterMoveNextControl = true;
            this.ComboBoxEditSource.Location = new System.Drawing.Point(76, 14);
            this.ComboBoxEditSource.Name = "ComboBoxEditSource";
            this.ComboBoxEditSource.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ComboBoxEditSource.Properties.Items.AddRange(new object[] {
            "INHOUSE",
            "REMOTE",
            "H2H",
            "WEB",
            "ALL"});
            this.ComboBoxEditSource.Size = new System.Drawing.Size(70, 20);
            this.ComboBoxEditSource.TabIndex = 87;
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Location = new System.Drawing.Point(664, 13);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(80, 25);
            this.ButtonSearch.TabIndex = 62;
            this.ButtonSearch.TabStop = false;
            this.ButtonSearch.Text = "Search";
            this.ButtonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // GridControlMarkups
            // 
            this.GridControlMarkups.Location = new System.Drawing.Point(34, 260);
            this.GridControlMarkups.MainView = this.GridViewMarkups;
            this.GridControlMarkups.Name = "GridControlMarkups";
            this.GridControlMarkups.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit5,
            this.repositoryItemCheckEdit4});
            this.GridControlMarkups.Size = new System.Drawing.Size(808, 175);
            this.GridControlMarkups.TabIndex = 45;
            this.GridControlMarkups.TabStop = false;
            this.GridControlMarkups.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewMarkups});
            // 
            // GridViewMarkups
            // 
            this.GridViewMarkups.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColumnServiceEndMU,
            this.ColumnBookStartDateMU,
            this.ColumnBookEndDateMU,
            this.ColumnCommPctMU,
            this.gridColumn6,
            this.ColumnStartDateMU,
            this.ColumnAgencyRuleMU,
            this.ColumnPositionMU,
            this.ColumnProductRuleMU,
            this.gridColumnRecType,
            this.ColumnSourceMU,
            this.gridColumn13,
            this.ColumnCategoryMU});
            this.GridViewMarkups.DetailHeight = 198;
            this.GridViewMarkups.FixedLineWidth = 1;
            this.GridViewMarkups.GridControl = this.GridControlMarkups;
            this.GridViewMarkups.Name = "GridViewMarkups";
            this.GridViewMarkups.OptionsBehavior.Editable = false;
            this.GridViewMarkups.OptionsView.ShowGroupPanel = false;
            // 
            // ColumnServiceEndMU
            // 
            this.ColumnServiceEndMU.Caption = "Service End";
            this.ColumnServiceEndMU.FieldName = "SvcEndDate";
            this.ColumnServiceEndMU.MinWidth = 12;
            this.ColumnServiceEndMU.Name = "ColumnServiceEndMU";
            this.ColumnServiceEndMU.Visible = true;
            this.ColumnServiceEndMU.VisibleIndex = 2;
            this.ColumnServiceEndMU.Width = 48;
            // 
            // ColumnBookStartDateMU
            // 
            this.ColumnBookStartDateMU.Caption = "Book Start";
            this.ColumnBookStartDateMU.FieldName = "ResStartDate";
            this.ColumnBookStartDateMU.MinWidth = 12;
            this.ColumnBookStartDateMU.Name = "ColumnBookStartDateMU";
            this.ColumnBookStartDateMU.Visible = true;
            this.ColumnBookStartDateMU.VisibleIndex = 3;
            this.ColumnBookStartDateMU.Width = 48;
            // 
            // ColumnBookEndDateMU
            // 
            this.ColumnBookEndDateMU.Caption = "Book End";
            this.ColumnBookEndDateMU.FieldName = "ResEndDate";
            this.ColumnBookEndDateMU.MinWidth = 12;
            this.ColumnBookEndDateMU.Name = "ColumnBookEndDateMU";
            this.ColumnBookEndDateMU.Visible = true;
            this.ColumnBookEndDateMU.VisibleIndex = 4;
            this.ColumnBookEndDateMU.Width = 53;
            // 
            // ColumnCommPctMU
            // 
            this.ColumnCommPctMU.Caption = "Comm Pct";
            this.ColumnCommPctMU.FieldName = "Percentage";
            this.ColumnCommPctMU.MinWidth = 12;
            this.ColumnCommPctMU.Name = "ColumnCommPctMU";
            this.ColumnCommPctMU.Visible = true;
            this.ColumnCommPctMU.VisibleIndex = 8;
            this.ColumnCommPctMU.Width = 36;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Inactive";
            this.gridColumn6.ColumnEdit = this.repositoryItemCheckEdit4;
            this.gridColumn6.FieldName = "Inactive";
            this.gridColumn6.MinWidth = 12;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Width = 29;
            // 
            // repositoryItemCheckEdit4
            // 
            this.repositoryItemCheckEdit4.AutoHeight = false;
            this.repositoryItemCheckEdit4.Caption = "Check";
            this.repositoryItemCheckEdit4.Name = "repositoryItemCheckEdit4";
            // 
            // ColumnStartDateMU
            // 
            this.ColumnStartDateMU.Caption = "Start Date";
            this.ColumnStartDateMU.FieldName = "SvcStartDate";
            this.ColumnStartDateMU.MinWidth = 12;
            this.ColumnStartDateMU.Name = "ColumnStartDateMU";
            this.ColumnStartDateMU.Visible = true;
            this.ColumnStartDateMU.VisibleIndex = 1;
            this.ColumnStartDateMU.Width = 48;
            // 
            // ColumnAgencyRuleMU
            // 
            this.ColumnAgencyRuleMU.Caption = "Agency Rule";
            this.ColumnAgencyRuleMU.FieldName = "AgencyRuleDescription";
            this.ColumnAgencyRuleMU.MinWidth = 12;
            this.ColumnAgencyRuleMU.Name = "ColumnAgencyRuleMU";
            this.ColumnAgencyRuleMU.Visible = true;
            this.ColumnAgencyRuleMU.VisibleIndex = 6;
            this.ColumnAgencyRuleMU.Width = 81;
            // 
            // ColumnPositionMU
            // 
            this.ColumnPositionMU.Caption = "Position";
            this.ColumnPositionMU.FieldName = "Position";
            this.ColumnPositionMU.MinWidth = 12;
            this.ColumnPositionMU.Name = "ColumnPositionMU";
            this.ColumnPositionMU.Visible = true;
            this.ColumnPositionMU.VisibleIndex = 9;
            this.ColumnPositionMU.Width = 39;
            // 
            // ColumnProductRuleMU
            // 
            this.ColumnProductRuleMU.Caption = "Product Rule";
            this.ColumnProductRuleMU.FieldName = "ProductRuleDescription";
            this.ColumnProductRuleMU.MinWidth = 12;
            this.ColumnProductRuleMU.Name = "ColumnProductRuleMU";
            this.ColumnProductRuleMU.Visible = true;
            this.ColumnProductRuleMU.VisibleIndex = 5;
            this.ColumnProductRuleMU.Width = 86;
            // 
            // gridColumnRecType
            // 
            this.gridColumnRecType.Caption = "Comm/Markup";
            this.gridColumnRecType.FieldName = "RecType";
            this.gridColumnRecType.MinWidth = 12;
            this.gridColumnRecType.Name = "gridColumnRecType";
            this.gridColumnRecType.Width = 46;
            // 
            // ColumnSourceMU
            // 
            this.ColumnSourceMU.Caption = "Source";
            this.ColumnSourceMU.FieldName = "Source";
            this.ColumnSourceMU.MinWidth = 12;
            this.ColumnSourceMU.Name = "ColumnSourceMU";
            this.ColumnSourceMU.Visible = true;
            this.ColumnSourceMU.VisibleIndex = 0;
            this.ColumnSourceMU.Width = 36;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Exclusion";
            this.gridColumn13.ColumnEdit = this.repositoryItemCheckEdit5;
            this.gridColumn13.FieldName = "Exclusion";
            this.gridColumn13.MinWidth = 12;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Width = 32;
            // 
            // repositoryItemCheckEdit5
            // 
            this.repositoryItemCheckEdit5.AutoHeight = false;
            this.repositoryItemCheckEdit5.Caption = "Check";
            this.repositoryItemCheckEdit5.Name = "repositoryItemCheckEdit5";
            // 
            // ColumnCategoryMU
            // 
            this.ColumnCategoryMU.Caption = "Category";
            this.ColumnCategoryMU.FieldName = "Category";
            this.ColumnCategoryMU.MinWidth = 12;
            this.ColumnCategoryMU.Name = "ColumnCategoryMU";
            this.ColumnCategoryMU.Visible = true;
            this.ColumnCategoryMU.VisibleIndex = 7;
            this.ColumnCategoryMU.Width = 45;
            // 
            // GridControlCommissions
            // 
            this.GridControlCommissions.Location = new System.Drawing.Point(34, 61);
            this.GridControlCommissions.MainView = this.GridViewCommissions;
            this.GridControlCommissions.Name = "GridControlCommissions";
            this.GridControlCommissions.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit2,
            this.repositoryItemCheckEdit3});
            this.GridControlCommissions.Size = new System.Drawing.Size(808, 161);
            this.GridControlCommissions.TabIndex = 44;
            this.GridControlCommissions.TabStop = false;
            this.GridControlCommissions.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewCommissions});
            // 
            // GridViewCommissions
            // 
            this.GridViewCommissions.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColumnEndDateComm,
            this.ColumnBookStartDateComm,
            this.ColumnBookEndDateComm,
            this.ColumnCommPctComm,
            this.colInactive,
            this.ColumnStartDateComm,
            this.ColumnAgencyRuleComm,
            this.ColumnPositionComm,
            this.ColumnProductRuleComm,
            this.gridColumn1,
            this.ColumnSourceComm,
            this.colExclusion1,
            this.ColumnCategoryComm});
            this.GridViewCommissions.DetailHeight = 198;
            this.GridViewCommissions.FixedLineWidth = 1;
            this.GridViewCommissions.GridControl = this.GridControlCommissions;
            this.GridViewCommissions.Name = "GridViewCommissions";
            this.GridViewCommissions.OptionsBehavior.Editable = false;
            this.GridViewCommissions.OptionsView.ShowGroupPanel = false;
            // 
            // ColumnEndDateComm
            // 
            this.ColumnEndDateComm.Caption = "Service End";
            this.ColumnEndDateComm.FieldName = "SvcEndDate";
            this.ColumnEndDateComm.MinWidth = 12;
            this.ColumnEndDateComm.Name = "ColumnEndDateComm";
            this.ColumnEndDateComm.Visible = true;
            this.ColumnEndDateComm.VisibleIndex = 2;
            this.ColumnEndDateComm.Width = 51;
            // 
            // ColumnBookStartDateComm
            // 
            this.ColumnBookStartDateComm.Caption = "Book Start";
            this.ColumnBookStartDateComm.FieldName = "ResStartDate";
            this.ColumnBookStartDateComm.MinWidth = 12;
            this.ColumnBookStartDateComm.Name = "ColumnBookStartDateComm";
            this.ColumnBookStartDateComm.Visible = true;
            this.ColumnBookStartDateComm.VisibleIndex = 3;
            this.ColumnBookStartDateComm.Width = 51;
            // 
            // ColumnBookEndDateComm
            // 
            this.ColumnBookEndDateComm.Caption = "Book End";
            this.ColumnBookEndDateComm.FieldName = "ResEndDate";
            this.ColumnBookEndDateComm.MinWidth = 12;
            this.ColumnBookEndDateComm.Name = "ColumnBookEndDateComm";
            this.ColumnBookEndDateComm.Visible = true;
            this.ColumnBookEndDateComm.VisibleIndex = 4;
            this.ColumnBookEndDateComm.Width = 57;
            // 
            // ColumnCommPctComm
            // 
            this.ColumnCommPctComm.Caption = "Comm Pct";
            this.ColumnCommPctComm.FieldName = "Percentage";
            this.ColumnCommPctComm.MinWidth = 12;
            this.ColumnCommPctComm.Name = "ColumnCommPctComm";
            this.ColumnCommPctComm.Visible = true;
            this.ColumnCommPctComm.VisibleIndex = 8;
            this.ColumnCommPctComm.Width = 36;
            // 
            // colInactive
            // 
            this.colInactive.Caption = "Inactive";
            this.colInactive.ColumnEdit = this.repositoryItemCheckEdit3;
            this.colInactive.FieldName = "Inactive";
            this.colInactive.MinWidth = 12;
            this.colInactive.Name = "colInactive";
            this.colInactive.Width = 27;
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.Caption = "Check";
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            // 
            // ColumnStartDateComm
            // 
            this.ColumnStartDateComm.Caption = "Start Date";
            this.ColumnStartDateComm.FieldName = "SvcStartDate";
            this.ColumnStartDateComm.MinWidth = 12;
            this.ColumnStartDateComm.Name = "ColumnStartDateComm";
            this.ColumnStartDateComm.Visible = true;
            this.ColumnStartDateComm.VisibleIndex = 1;
            this.ColumnStartDateComm.Width = 51;
            // 
            // ColumnAgencyRuleComm
            // 
            this.ColumnAgencyRuleComm.Caption = "Agency Rule";
            this.ColumnAgencyRuleComm.FieldName = "AgencyRuleDescription";
            this.ColumnAgencyRuleComm.MinWidth = 12;
            this.ColumnAgencyRuleComm.Name = "ColumnAgencyRuleComm";
            this.ColumnAgencyRuleComm.Visible = true;
            this.ColumnAgencyRuleComm.VisibleIndex = 6;
            this.ColumnAgencyRuleComm.Width = 81;
            // 
            // ColumnPositionComm
            // 
            this.ColumnPositionComm.Caption = "Position";
            this.ColumnPositionComm.FieldName = "Position";
            this.ColumnPositionComm.MinWidth = 12;
            this.ColumnPositionComm.Name = "ColumnPositionComm";
            this.ColumnPositionComm.Visible = true;
            this.ColumnPositionComm.VisibleIndex = 9;
            this.ColumnPositionComm.Width = 27;
            // 
            // ColumnProductRuleComm
            // 
            this.ColumnProductRuleComm.Caption = "Product Rule";
            this.ColumnProductRuleComm.FieldName = "ProductRuleDescription";
            this.ColumnProductRuleComm.MinWidth = 12;
            this.ColumnProductRuleComm.Name = "ColumnProductRuleComm";
            this.ColumnProductRuleComm.Visible = true;
            this.ColumnProductRuleComm.VisibleIndex = 5;
            this.ColumnProductRuleComm.Width = 86;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Comm/Markup";
            this.gridColumn1.FieldName = "RecType";
            this.gridColumn1.MinWidth = 12;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 46;
            // 
            // ColumnSourceComm
            // 
            this.ColumnSourceComm.Caption = "Source";
            this.ColumnSourceComm.FieldName = "Source";
            this.ColumnSourceComm.MinWidth = 12;
            this.ColumnSourceComm.Name = "ColumnSourceComm";
            this.ColumnSourceComm.Visible = true;
            this.ColumnSourceComm.VisibleIndex = 0;
            this.ColumnSourceComm.Width = 38;
            // 
            // colExclusion1
            // 
            this.colExclusion1.Caption = "Exclusion";
            this.colExclusion1.ColumnEdit = this.repositoryItemCheckEdit2;
            this.colExclusion1.FieldName = "Exclusion";
            this.colExclusion1.MinWidth = 12;
            this.colExclusion1.Name = "colExclusion1";
            this.colExclusion1.Width = 32;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Caption = "Check";
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // ColumnCategoryComm
            // 
            this.ColumnCategoryComm.Caption = "Category";
            this.ColumnCategoryComm.FieldName = "Category";
            this.ColumnCategoryComm.MinWidth = 12;
            this.ColumnCategoryComm.Name = "ColumnCategoryComm";
            this.ColumnCategoryComm.Visible = true;
            this.ColumnCategoryComm.VisibleIndex = 7;
            this.ColumnCategoryComm.Width = 45;
            // 
            // SearchLookupEditAgency
            // 
            this.SearchLookupEditAgency.Location = new System.Drawing.Point(206, 14);
            this.SearchLookupEditAgency.Name = "SearchLookupEditAgency";
            this.SearchLookupEditAgency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLookupEditAgency.Properties.DataSource = this.BindingSourceCodeName;
            this.SearchLookupEditAgency.Properties.DisplayMember = "DisplayName";
            this.SearchLookupEditAgency.Properties.NullText = "";
            this.SearchLookupEditAgency.Properties.PopupSizeable = false;
            this.SearchLookupEditAgency.Properties.PopupView = this.gridView5;
            this.SearchLookupEditAgency.Properties.ValueMember = "Code";
            this.SearchLookupEditAgency.Size = new System.Drawing.Size(250, 20);
            this.SearchLookupEditAgency.TabIndex = 88;
            // 
            // gridView5
            // 
            this.gridView5.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode6,
            this.colName6});
            this.gridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView5.OptionsView.ShowGroupPanel = false;
            this.gridView5.OptionsView.ShowIndicator = false;
            // 
            // colCode6
            // 
            this.colCode6.FieldName = "Code";
            this.colCode6.Name = "colCode6";
            this.colCode6.Visible = true;
            this.colCode6.VisibleIndex = 0;
            // 
            // colName6
            // 
            this.colName6.FieldName = "Name";
            this.colName6.Name = "colName6";
            this.colName6.Visible = true;
            this.colName6.VisibleIndex = 1;
            // 
            // DateEditDate
            // 
            this.DateEditDate.CausesValidation = false;
            this.DateEditDate.EditValue = null;
            this.DateEditDate.Location = new System.Drawing.Point(502, 14);
            this.DateEditDate.Name = "DateEditDate";
            this.DateEditDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateEditDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateEditDate.Properties.DisplayFormat.FormatString = "";
            this.DateEditDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DateEditDate.Properties.EditFormat.FormatString = "";
            this.DateEditDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DateEditDate.Properties.Mask.EditMask = "";
            this.DateEditDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.DateEditDate.Size = new System.Drawing.Size(154, 20);
            this.DateEditDate.TabIndex = 89;
            this.DateEditDate.TextChanged += new System.EventHandler(this.ButtonEditDate_TextChanged);
            // 
            // XtraTabPageAgents
            // 
            this.XtraTabPageAgents.Controls.Add(this.PanelControlAgentTab);
            this.XtraTabPageAgents.Name = "XtraTabPageAgents";
            this.XtraTabPageAgents.Size = new System.Drawing.Size(877, 499);
            this.XtraTabPageAgents.Text = "Agents";
            // 
            // PanelControlAgentTab
            // 
            this.PanelControlAgentTab.Controls.Add(this.ButtonDeleteAgent);
            this.PanelControlAgentTab.Controls.Add(this.ButtonAddAgent);
            this.PanelControlAgentTab.Controls.Add(this.GridControlAgcyLog);
            this.PanelControlAgentTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelControlAgentTab.Location = new System.Drawing.Point(0, 0);
            this.PanelControlAgentTab.Name = "PanelControlAgentTab";
            this.PanelControlAgentTab.Size = new System.Drawing.Size(877, 499);
            this.PanelControlAgentTab.TabIndex = 0;
            // 
            // ButtonDeleteAgent
            // 
            this.ButtonDeleteAgent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonDeleteAgent.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonDeleteAgent.ImageOptions.Image")));
            this.ButtonDeleteAgent.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ButtonDeleteAgent.Location = new System.Drawing.Point(808, 92);
            this.ButtonDeleteAgent.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ButtonDeleteAgent.Name = "ButtonDeleteAgent";
            this.ButtonDeleteAgent.Size = new System.Drawing.Size(34, 38);
            this.ButtonDeleteAgent.TabIndex = 41;
            this.ButtonDeleteAgent.TabStop = false;
            this.ButtonDeleteAgent.Text = "Delete Agent";
            this.ButtonDeleteAgent.Click += new System.EventHandler(this.ButtonDeleteAgent_Click);
            // 
            // ButtonAddAgent
            // 
            this.ButtonAddAgent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonAddAgent.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonAddAgent.ImageOptions.Image")));
            this.ButtonAddAgent.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ButtonAddAgent.Location = new System.Drawing.Point(808, 48);
            this.ButtonAddAgent.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ButtonAddAgent.Name = "ButtonAddAgent";
            this.ButtonAddAgent.Size = new System.Drawing.Size(34, 38);
            this.ButtonAddAgent.TabIndex = 40;
            this.ButtonAddAgent.Text = "Add Agent";
            this.ButtonAddAgent.Click += new System.EventHandler(this.ButtonAddAgent_Click);
            // 
            // GridControlAgcyLog
            // 
            this.GridControlAgcyLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GridControlAgcyLog.DataSource = this.BindingSourceAgcyLog;
            this.GridControlAgcyLog.Location = new System.Drawing.Point(21, 17);
            this.GridControlAgcyLog.MainView = this.GridViewAgcyLog;
            this.GridControlAgcyLog.Name = "GridControlAgcyLog";
            this.GridControlAgcyLog.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RepositoryItemCheckEditAgcylogBool,
            this.RepositoryItemTextEditPassword,
            this.RepositoryItemCheckEditSupvrFlg,
            this.RepositoryItemTextEditAgtEmail,
            this.RepositoryItemTextEditAgtFax,
            this.RepositoryItemTextEditAgentCompany,
            this.RepositoryItemTextEditAgentName,
            this.RepositoryItemImageComboBoxEditAgentDelegate});
            this.GridControlAgcyLog.Size = new System.Drawing.Size(782, 467);
            this.GridControlAgcyLog.TabIndex = 34;
            this.GridControlAgcyLog.TabStop = false;
            this.GridControlAgcyLog.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewAgcyLog});
            this.GridControlAgcyLog.Leave += new System.EventHandler(this.GridControlAgcyLog_Leave);
            // 
            // BindingSourceAgcyLog
            // 
            this.BindingSourceAgcyLog.DataSource = typeof(FlexModel.AGCYLOG);
            this.BindingSourceAgcyLog.CurrentChanged += new System.EventHandler(this.AgcyLogBindingSource_CurrentChanged);
            // 
            // GridViewAgcyLog
            // 
            this.GridViewAgcyLog.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAgentInactive,
            this.colAGT_NAME,
            this.colAGENCY1,
            this.colAGCY_NAME,
            this.colCUR_BOOK,
            this.colSUPVR_FLG,
            this.colRES_PROF,
            this.colMNT_PROF,
            this.colACC_PROF,
            this.colPRT_PROF,
            this.colAGT_EMAIL,
            this.colAGT_FAX,
            this.colPASSWORD1,
            this.colDATAFLEX_FILL_01,
            this.colAGY,
            this.colAgentCompany,
            this.colAgcylog_Agent_Delegate,
            this.colAgcylogReadOnly});
            this.GridViewAgcyLog.DetailHeight = 198;
            this.GridViewAgcyLog.FixedLineWidth = 1;
            this.GridViewAgcyLog.GridControl = this.GridControlAgcyLog;
            this.GridViewAgcyLog.Name = "GridViewAgcyLog";
            this.GridViewAgcyLog.OptionsView.ShowGroupPanel = false;
            this.GridViewAgcyLog.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colAgentInactive, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.GridViewAgcyLog.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.GridViewAgcyLog_CustomRowCellEdit);
            // 
            // colAgentInactive
            // 
            this.colAgentInactive.Caption = "Inactive";
            this.colAgentInactive.ColumnEdit = this.RepositoryItemCheckEditAgcylogBool;
            this.colAgentInactive.FieldName = "Inactive";
            this.colAgentInactive.MinWidth = 12;
            this.colAgentInactive.Name = "colAgentInactive";
            this.colAgentInactive.Visible = true;
            this.colAgentInactive.VisibleIndex = 1;
            this.colAgentInactive.Width = 78;
            // 
            // RepositoryItemCheckEditAgcylogBool
            // 
            this.RepositoryItemCheckEditAgcylogBool.AutoHeight = false;
            this.RepositoryItemCheckEditAgcylogBool.Name = "RepositoryItemCheckEditAgcylogBool";
            // 
            // colAGT_NAME
            // 
            this.colAGT_NAME.Caption = "Agent Name";
            this.colAGT_NAME.ColumnEdit = this.RepositoryItemTextEditAgentName;
            this.colAGT_NAME.FieldName = "AGT_NAME";
            this.colAGT_NAME.MinWidth = 12;
            this.colAGT_NAME.Name = "colAGT_NAME";
            this.colAGT_NAME.Visible = true;
            this.colAGT_NAME.VisibleIndex = 0;
            this.colAGT_NAME.Width = 205;
            // 
            // RepositoryItemTextEditAgentName
            // 
            this.RepositoryItemTextEditAgentName.AutoHeight = false;
            this.RepositoryItemTextEditAgentName.MaxLength = 256;
            this.RepositoryItemTextEditAgentName.Name = "RepositoryItemTextEditAgentName";
            // 
            // colAGENCY1
            // 
            this.colAGENCY1.Caption = "Agency";
            this.colAGENCY1.FieldName = "AGENCY";
            this.colAGENCY1.MinWidth = 12;
            this.colAGENCY1.Name = "colAGENCY1";
            this.colAGENCY1.Width = 29;
            // 
            // colAGCY_NAME
            // 
            this.colAGCY_NAME.Caption = "Agency name";
            this.colAGCY_NAME.FieldName = "AGCY_NAME";
            this.colAGCY_NAME.MinWidth = 12;
            this.colAGCY_NAME.Name = "colAGCY_NAME";
            this.colAGCY_NAME.Width = 29;
            // 
            // colCUR_BOOK
            // 
            this.colCUR_BOOK.Caption = "Booking Number";
            this.colCUR_BOOK.FieldName = "CUR_BOOK";
            this.colCUR_BOOK.MinWidth = 12;
            this.colCUR_BOOK.Name = "colCUR_BOOK";
            this.colCUR_BOOK.Width = 29;
            // 
            // colSUPVR_FLG
            // 
            this.colSUPVR_FLG.Caption = "Supervisor";
            this.colSUPVR_FLG.ColumnEdit = this.RepositoryItemCheckEditSupvrFlg;
            this.colSUPVR_FLG.FieldName = "SUPVR_FLG";
            this.colSUPVR_FLG.MinWidth = 12;
            this.colSUPVR_FLG.Name = "colSUPVR_FLG";
            this.colSUPVR_FLG.Visible = true;
            this.colSUPVR_FLG.VisibleIndex = 4;
            this.colSUPVR_FLG.Width = 79;
            // 
            // RepositoryItemCheckEditSupvrFlg
            // 
            this.RepositoryItemCheckEditSupvrFlg.AutoHeight = false;
            this.RepositoryItemCheckEditSupvrFlg.Name = "RepositoryItemCheckEditSupvrFlg";
            this.RepositoryItemCheckEditSupvrFlg.ValueChecked = "Y";
            this.RepositoryItemCheckEditSupvrFlg.ValueUnchecked = "N";
            // 
            // colRES_PROF
            // 
            this.colRES_PROF.Caption = "Reservations";
            this.colRES_PROF.FieldName = "RES_PROF";
            this.colRES_PROF.MinWidth = 12;
            this.colRES_PROF.Name = "colRES_PROF";
            this.colRES_PROF.Width = 29;
            // 
            // colMNT_PROF
            // 
            this.colMNT_PROF.Caption = "Maintenance";
            this.colMNT_PROF.FieldName = "MNT_PROF";
            this.colMNT_PROF.MinWidth = 12;
            this.colMNT_PROF.Name = "colMNT_PROF";
            this.colMNT_PROF.Width = 29;
            // 
            // colACC_PROF
            // 
            this.colACC_PROF.Caption = "Accounting";
            this.colACC_PROF.FieldName = "ACC_PROF";
            this.colACC_PROF.MinWidth = 12;
            this.colACC_PROF.Name = "colACC_PROF";
            this.colACC_PROF.Width = 29;
            // 
            // colPRT_PROF
            // 
            this.colPRT_PROF.Caption = "Printing";
            this.colPRT_PROF.FieldName = "PRT_PROF";
            this.colPRT_PROF.MinWidth = 12;
            this.colPRT_PROF.Name = "colPRT_PROF";
            this.colPRT_PROF.Width = 29;
            // 
            // colAGT_EMAIL
            // 
            this.colAGT_EMAIL.Caption = "Email";
            this.colAGT_EMAIL.ColumnEdit = this.RepositoryItemTextEditAgtEmail;
            this.colAGT_EMAIL.FieldName = "AGT_EMAIL";
            this.colAGT_EMAIL.MinWidth = 12;
            this.colAGT_EMAIL.Name = "colAGT_EMAIL";
            this.colAGT_EMAIL.Visible = true;
            this.colAGT_EMAIL.VisibleIndex = 5;
            this.colAGT_EMAIL.Width = 53;
            // 
            // RepositoryItemTextEditAgtEmail
            // 
            this.RepositoryItemTextEditAgtEmail.AutoHeight = false;
            this.RepositoryItemTextEditAgtEmail.MaxLength = 256;
            this.RepositoryItemTextEditAgtEmail.Name = "RepositoryItemTextEditAgtEmail";
            // 
            // colAGT_FAX
            // 
            this.colAGT_FAX.Caption = "Fax";
            this.colAGT_FAX.ColumnEdit = this.RepositoryItemTextEditAgtFax;
            this.colAGT_FAX.FieldName = "AGT_FAX";
            this.colAGT_FAX.MinWidth = 12;
            this.colAGT_FAX.Name = "colAGT_FAX";
            this.colAGT_FAX.Visible = true;
            this.colAGT_FAX.VisibleIndex = 6;
            this.colAGT_FAX.Width = 41;
            // 
            // RepositoryItemTextEditAgtFax
            // 
            this.RepositoryItemTextEditAgtFax.AutoHeight = false;
            this.RepositoryItemTextEditAgtFax.MaxLength = 20;
            this.RepositoryItemTextEditAgtFax.Name = "RepositoryItemTextEditAgtFax";
            // 
            // colPASSWORD1
            // 
            this.colPASSWORD1.Caption = "Password";
            this.colPASSWORD1.ColumnEdit = this.RepositoryItemTextEditPassword;
            this.colPASSWORD1.FieldName = "PASSWORD";
            this.colPASSWORD1.MinWidth = 12;
            this.colPASSWORD1.Name = "colPASSWORD1";
            this.colPASSWORD1.Visible = true;
            this.colPASSWORD1.VisibleIndex = 3;
            this.colPASSWORD1.Width = 94;
            // 
            // RepositoryItemTextEditPassword
            // 
            this.RepositoryItemTextEditPassword.AutoHeight = false;
            this.RepositoryItemTextEditPassword.MaxLength = 10;
            this.RepositoryItemTextEditPassword.Name = "RepositoryItemTextEditPassword";
            // 
            // colDATAFLEX_FILL_01
            // 
            this.colDATAFLEX_FILL_01.FieldName = "DATAFLEX_FILL_01";
            this.colDATAFLEX_FILL_01.MinWidth = 12;
            this.colDATAFLEX_FILL_01.Name = "colDATAFLEX_FILL_01";
            this.colDATAFLEX_FILL_01.Width = 45;
            // 
            // colAGY
            // 
            this.colAGY.Caption = "Agency No";
            this.colAGY.FieldName = "AGY";
            this.colAGY.MinWidth = 12;
            this.colAGY.Name = "colAGY";
            this.colAGY.Width = 42;
            // 
            // colAgentCompany
            // 
            this.colAgentCompany.Caption = "Company Code";
            this.colAgentCompany.ColumnEdit = this.RepositoryItemTextEditAgentCompany;
            this.colAgentCompany.FieldName = "AgentCompany";
            this.colAgentCompany.Name = "colAgentCompany";
            this.colAgentCompany.Visible = true;
            this.colAgentCompany.VisibleIndex = 7;
            this.colAgentCompany.Width = 85;
            // 
            // RepositoryItemTextEditAgentCompany
            // 
            this.RepositoryItemTextEditAgentCompany.AutoHeight = false;
            this.RepositoryItemTextEditAgentCompany.MaxLength = 12;
            this.RepositoryItemTextEditAgentCompany.Name = "RepositoryItemTextEditAgentCompany";
            // 
            // colAgcylog_Agent_Delegate
            // 
            this.colAgcylog_Agent_Delegate.Caption = "Agent Delegate";
            this.colAgcylog_Agent_Delegate.ColumnEdit = this.RepositoryItemImageComboBoxEditAgentDelegate;
            this.colAgcylog_Agent_Delegate.FieldName = "Agcylog_Agent_Delegate";
            this.colAgcylog_Agent_Delegate.Name = "colAgcylog_Agent_Delegate";
            this.colAgcylog_Agent_Delegate.Visible = true;
            this.colAgcylog_Agent_Delegate.VisibleIndex = 8;
            this.colAgcylog_Agent_Delegate.Width = 129;
            // 
            // RepositoryItemImageComboBoxEditAgentDelegate
            // 
            this.RepositoryItemImageComboBoxEditAgentDelegate.AutoHeight = false;
            this.RepositoryItemImageComboBoxEditAgentDelegate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemImageComboBoxEditAgentDelegate.Name = "RepositoryItemImageComboBoxEditAgentDelegate";
            // 
            // colAgcylogReadOnly
            // 
            this.colAgcylogReadOnly.Caption = "Read Only";
            this.colAgcylogReadOnly.ColumnEdit = this.RepositoryItemCheckEditAgcylogBool;
            this.colAgcylogReadOnly.FieldName = "ReadOnly";
            this.colAgcylogReadOnly.Name = "colAgcylogReadOnly";
            this.colAgcylogReadOnly.Visible = true;
            this.colAgcylogReadOnly.VisibleIndex = 2;
            // 
            // TextEditAr
            // 
            this.TextEditAr.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "AR", true));
            this.TextEditAr.EnterMoveNextControl = true;
            this.TextEditAr.Location = new System.Drawing.Point(502, 70);
            this.TextEditAr.Name = "TextEditAr";
            this.TextEditAr.Properties.MaxLength = 12;
            this.TextEditAr.Size = new System.Drawing.Size(100, 20);
            this.TextEditAr.TabIndex = 5;
            this.TextEditAr.Leave += new System.EventHandler(this.TextEditAR_Leave);
            // 
            // TextEditAp
            // 
            this.TextEditAp.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "AP", true));
            this.TextEditAp.EnterMoveNextControl = true;
            this.TextEditAp.Location = new System.Drawing.Point(306, 69);
            this.TextEditAp.Name = "TextEditAp";
            this.TextEditAp.Properties.MaxLength = 6;
            this.TextEditAp.Size = new System.Drawing.Size(100, 20);
            this.TextEditAp.TabIndex = 4;
            this.TextEditAp.Leave += new System.EventHandler(this.TextEditAP_Leave);
            // 
            // TextEditType
            // 
            this.TextEditType.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "TYP", true));
            this.TextEditType.EnterMoveNextControl = true;
            this.TextEditType.Location = new System.Drawing.Point(125, 70);
            this.TextEditType.Name = "TextEditType";
            this.TextEditType.Properties.MaxLength = 1;
            this.TextEditType.Size = new System.Drawing.Size(72, 20);
            this.TextEditType.TabIndex = 3;
            this.TextEditType.Leave += new System.EventHandler(this.TextEditType_Leave);
            // 
            // TextEditName
            // 
            this.TextEditName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "NAME", true));
            this.TextEditName.EnterMoveNextControl = true;
            this.TextEditName.Location = new System.Drawing.Point(125, 47);
            this.TextEditName.Name = "TextEditName";
            this.TextEditName.Properties.MaxLength = 60;
            this.TextEditName.Size = new System.Drawing.Size(281, 20);
            this.TextEditName.TabIndex = 2;
            this.TextEditName.Leave += new System.EventHandler(this.TextEditName_Leave);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // SplitContainerControl
            // 
            this.SplitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerControl.Location = new System.Drawing.Point(0, 31);
            this.SplitContainerControl.Name = "SplitContainerControl";
            this.SplitContainerControl.Panel1.AutoScroll = true;
            this.SplitContainerControl.Panel1.Controls.Add(this.GridControlLookup);
            this.SplitContainerControl.Panel1.Text = "Panel1";
            this.SplitContainerControl.Panel2.AutoScroll = true;
            this.SplitContainerControl.Panel2.Controls.Add(this.labelControl27);
            this.SplitContainerControl.Panel2.Controls.Add(this.LabelControlLastUpdatedBy);
            this.SplitContainerControl.Panel2.Controls.Add(this.labelControl25);
            this.SplitContainerControl.Panel2.Controls.Add(this.LabelControlLastUpdated);
            this.SplitContainerControl.Panel2.Controls.Add(this.CheckEditActiveFlg);
            this.SplitContainerControl.Panel2.Controls.Add(nOLabel);
            this.SplitContainerControl.Panel2.Controls.Add(aRLabel);
            this.SplitContainerControl.Panel2.Controls.Add(this.XtraTabControlAgency);
            this.SplitContainerControl.Panel2.Controls.Add(this.TextEditName);
            this.SplitContainerControl.Panel2.Controls.Add(vOUCH_TYPESLabel);
            this.SplitContainerControl.Panel2.Controls.Add(this.TextEditAr);
            this.SplitContainerControl.Panel2.Controls.Add(nAMELabel);
            this.SplitContainerControl.Panel2.Controls.Add(aPLabel);
            this.SplitContainerControl.Panel2.Controls.Add(this.TextEditType);
            this.SplitContainerControl.Panel2.Controls.Add(this.TextEditAp);
            this.SplitContainerControl.Panel2.Controls.Add(tYPLabel);
            this.SplitContainerControl.Panel2.Controls.Add(dEF_LANGLabel);
            this.SplitContainerControl.Panel2.Controls.Add(this.SearchLookupEditDefLanguage);
            this.SplitContainerControl.Panel2.Controls.Add(this.TextEditCode);
            this.SplitContainerControl.Panel2.Controls.Add(this.TextEditVouchTypes);
            this.SplitContainerControl.Panel2.Text = "Panel2";
            this.SplitContainerControl.Size = new System.Drawing.Size(1183, 642);
            this.SplitContainerControl.SplitterPosition = 190;
            this.SplitContainerControl.TabIndex = 20;
            this.SplitContainerControl.Text = "SplitContainerControl";
            // 
            // labelControl27
            // 
            this.labelControl27.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "UPD_INIT", true));
            this.labelControl27.Location = new System.Drawing.Point(461, 25);
            this.labelControl27.Name = "labelControl27";
            this.labelControl27.Size = new System.Drawing.Size(0, 13);
            this.labelControl27.TabIndex = 0;
            // 
            // LabelControlLastUpdatedBy
            // 
            this.LabelControlLastUpdatedBy.Location = new System.Drawing.Point(439, 25);
            this.LabelControlLastUpdatedBy.Name = "LabelControlLastUpdatedBy";
            this.LabelControlLastUpdatedBy.Size = new System.Drawing.Size(16, 13);
            this.LabelControlLastUpdatedBy.TabIndex = 0;
            this.LabelControlLastUpdatedBy.Text = "By:";
            // 
            // labelControl25
            // 
            this.labelControl25.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "LAST_UPD", true));
            this.labelControl25.Location = new System.Drawing.Point(345, 25);
            this.labelControl25.Name = "labelControl25";
            this.labelControl25.Size = new System.Drawing.Size(0, 13);
            this.labelControl25.TabIndex = 0;
            // 
            // LabelControlLastUpdated
            // 
            this.LabelControlLastUpdated.Location = new System.Drawing.Point(271, 25);
            this.LabelControlLastUpdated.Name = "LabelControlLastUpdated";
            this.LabelControlLastUpdated.Size = new System.Drawing.Size(68, 13);
            this.LabelControlLastUpdated.TabIndex = 0;
            this.LabelControlLastUpdated.Text = "Last Updated:";
            // 
            // SearchLookupEditDefLanguage
            // 
            this.SearchLookupEditDefLanguage.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "DEF_LANG", true));
            this.SearchLookupEditDefLanguage.Location = new System.Drawing.Point(125, 93);
            this.SearchLookupEditDefLanguage.Name = "SearchLookupEditDefLanguage";
            this.SearchLookupEditDefLanguage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLookupEditDefLanguage.Properties.DataSource = this.BindingSourceCodeName;
            this.SearchLookupEditDefLanguage.Properties.DisplayMember = "DisplayName";
            this.SearchLookupEditDefLanguage.Properties.NullText = "";
            this.SearchLookupEditDefLanguage.Properties.PopupSizeable = false;
            this.SearchLookupEditDefLanguage.Properties.PopupView = this.searchLookUpEdit1View;
            this.SearchLookupEditDefLanguage.Properties.ValueMember = "Code";
            this.SearchLookupEditDefLanguage.Size = new System.Drawing.Size(218, 20);
            this.SearchLookupEditDefLanguage.TabIndex = 6;
            this.SearchLookupEditDefLanguage.Leave += new System.EventHandler(this.SearchLookupEditDefaultLanguage_Leave);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode3,
            this.colName4});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.searchLookUpEdit1View.OptionsView.ShowIndicator = false;
            // 
            // colCode3
            // 
            this.colCode3.FieldName = "Code";
            this.colCode3.Name = "colCode3";
            this.colCode3.Visible = true;
            this.colCode3.VisibleIndex = 0;
            // 
            // colName4
            // 
            this.colName4.FieldName = "Name";
            this.colName4.Name = "colName4";
            this.colName4.Visible = true;
            this.colName4.VisibleIndex = 1;
            // 
            // TextEditCode
            // 
            this.TextEditCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "NO", true));
            this.TextEditCode.Location = new System.Drawing.Point(125, 23);
            this.TextEditCode.Name = "TextEditCode";
            this.TextEditCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TextEditCode.Properties.MaxLength = 10;
            this.TextEditCode.Size = new System.Drawing.Size(122, 20);
            this.TextEditCode.TabIndex = 1;
            this.TextEditCode.Leave += new System.EventHandler(this.TextEditCode_Leave);
            // 
            // PanelControlStatus
            // 
            this.PanelControlStatus.Appearance.Options.UseTextOptions = true;
            this.PanelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("PanelControlStatus.ContentImage")));
            this.PanelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.PanelControlStatus.Controls.Add(this.LabelStatus);
            this.PanelControlStatus.Location = new System.Drawing.Point(322, 2);
            this.PanelControlStatus.Name = "PanelControlStatus";
            this.PanelControlStatus.Size = new System.Drawing.Size(120, 23);
            this.PanelControlStatus.TabIndex = 10000;
            this.PanelControlStatus.Visible = false;
            // 
            // LabelStatus
            // 
            this.LabelStatus.Location = new System.Drawing.Point(30, 5);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(0, 13);
            this.LabelStatus.TabIndex = 5;
            // 
            // chineseHosts_FlextourDataSet
            // 
            this.chineseHosts_FlextourDataSet.DataSetName = "ChineseHosts_FlextourDataSet";
            this.chineseHosts_FlextourDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BindingSourceAgencyPaymentProfileBank
            // 
            this.BindingSourceAgencyPaymentProfileBank.DataSource = typeof(FlexModel.AgencyPaymentProfile);
            this.BindingSourceAgencyPaymentProfileBank.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.BindingSourceAgencyPaymentProfileBank_ListChanged);
            // 
            // TextEditVouchTypes
            // 
            this.TextEditVouchTypes.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "VOUCH_TYPES", true));
            this.TextEditVouchTypes.Location = new System.Drawing.Point(502, 93);
            this.TextEditVouchTypes.Name = "TextEditVouchTypes";
            this.TextEditVouchTypes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TextEditVouchTypes.Size = new System.Drawing.Size(100, 20);
            this.TextEditVouchTypes.TabIndex = 64;
            this.TextEditVouchTypes.TabStop = false;
            // 
            // AgencyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1183, 673);
            this.Controls.Add(this.PanelControlStatus);
            this.Controls.Add(this.SplitContainerControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.KeyPreview = true;
            this.Name = "AgencyForm";
            this.Text = "Agency Information";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AgencyForm_FormClosing);
            this.Load += new System.EventHandler(this.AgencyForm_Load);
            this.Shown += new System.EventHandler(this.AgencyForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.GridControlLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditActiveFlg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XtraTabControlAgency)).EndInit();
            this.XtraTabControlAgency.ResumeLayout(false);
            this.XtraTabPageLocation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlLocationTab)).EndInit();
            this.PanelControlLocationTab.ResumeLayout(false);
            this.PanelControlLocationTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditZip.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditAddr3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditAddr2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditAddr1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditCountry.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceCodeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.XtraTabPageContacts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlContactTab)).EndInit();
            this.PanelControlContactTab.ResumeLayout(false);
            this.PanelControlContactTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditMailFaxFlg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlContacts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewContacts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxDept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBoxSendDocs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckedComboBoxEditReportType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemSearchLookUpEditReportType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditFaxNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditPhone.Properties)).EndInit();
            this.XtraTabPageAvailability.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlAvailabilityTab)).EndInit();
            this.PanelControlAvailabilityTab.ResumeLayout(false);
            this.PanelControlAvailabilityTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditRetNotAvalHtls.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditRetreqHtls.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditSubAlloc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditArvBkDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditRel.Properties)).EndInit();
            this.XtraTabPageReporting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlReportTab)).EndInit();
            this.PanelControlReportTab.ResumeLayout(false);
            this.PanelControlReportTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditPkgVouchers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditOptVouchers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditAirVouchers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditCruVouchers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditCarVouchers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditHtlVouchers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditTourfaxEmailFormat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditSglResConf.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit8.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditRemoteVouchers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditAllowAttachments.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditConfPrc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditVoucherDaysPrior.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditVoucherReprints.Properties)).EndInit();
            this.XtraTabPagePolicies.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlPoliciesTab)).EndInit();
            this.PanelControlPoliciesTab.ResumeLayout(false);
            this.PanelControlPoliciesTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlAgencyCurrency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceAgencyCurrency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewAgencyCurrency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditHtls.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditHdrs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditRemChg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditComm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditCxlGrace.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditOptDays.Properties)).EndInit();
            this.XtraTabPageAccounting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlAccountTab)).EndInit();
            this.PanelControlAccountTab.ResumeLayout(false);
            this.PanelControlAccountTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RadioGroupPaymentDue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlDeposits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourcePaymentTransaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewDeposits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditCreditUnlimited.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditDaysSpace.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditPriorDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditPmtDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditDueDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditSvcDateFlg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxEditInvFmt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditImmedFlg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditFundBalance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditCreditLimit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditCreditLimitRemPct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditCreditBalance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditAmountPaid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditLastInvDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditLastInvDate.Properties)).EndInit();
            this.XtraTabPagePayments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlPaymentProfileStatus)).EndInit();
            this.PanelControlPaymentProfileStatus.ResumeLayout(false);
            this.PanelControlPaymentProfileStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditAllowElectronicPayment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditRequireCVV2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlBankProfiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceAgencyPaymentProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewBankProfiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBoxAccountType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlCreditProfiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewCreditProfiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemSpinEditExpYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemImageComboBoxExpMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCustomerProfileEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditDefaultPmtProfileID.Properties)).EndInit();
            this.XtraTabPageAdministrativeFees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlAdminTab)).EndInit();
            this.PanelControlAdminTab.ResumeLayout(false);
            this.PanelControlAdminTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditChgFlat2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditChgFlat3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditChgFlat1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditChgPct2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditChgPct1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditChgNtsPrior2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditCxlNtsPrior1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditChgNtsPrior1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCxlFlat1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCxlFlat3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCxlPct1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditChgPct3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditCxlNtsPrior2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCxlPct3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCxlFlat2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCxlPct2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditChgNtsPrior3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditCxlNtsPrior3.Properties)).EndInit();
            this.XtraTabPageMemberships.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlMemberTab)).EndInit();
            this.PanelControlMemberTab.ResumeLayout(false);
            this.PanelControlMemberTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditSrt3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditSrt2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlMemberships)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewMemberships)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemSearchLookUpEditClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditParentAgy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            this.XtraTabPageResources.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlResourceTab)).EndInit();
            this.PanelControlResourceTab.ResumeLayout(false);
            this.PanelControlResourceTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEditLogoPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditWebsite.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureEditPreview.Properties)).EndInit();
            this.XtraTabPageCustom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlCustomTab)).EndInit();
            this.PanelControlCustomTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridControlCustom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceUserfield)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewCustom)).EndInit();
            this.XtraTabPageCommissions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlCommTab)).EndInit();
            this.PanelControlCommTab.ResumeLayout(false);
            this.PanelControlCommTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxEditSource.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlMarkups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewMarkups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlCommissions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewCommissions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditAgency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditDate.Properties)).EndInit();
            this.XtraTabPageAgents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlAgentTab)).EndInit();
            this.PanelControlAgentTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridControlAgcyLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceAgcyLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewAgcyLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEditAgcylogBool)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEditAgentName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCheckEditSupvrFlg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEditAgtEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEditAgtFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEditPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEditAgentCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemImageComboBoxEditAgentDelegate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourcePaymentProfiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceCreditCardInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditAr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditAp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceComprod2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl)).EndInit();
            this.SplitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditDefLanguage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlStatus)).EndInit();
            this.PanelControlStatus.ResumeLayout(false);
            this.PanelControlStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chineseHosts_FlextourDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceAgencyPaymentProfileBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditVouchTypes.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl GridControlLookup;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewLookup;
        private DevExpress.XtraTab.XtraTabControl XtraTabControlAgency;
        private DevExpress.XtraTab.XtraTabPage XtraTabPageLocation;
        private DevExpress.XtraTab.XtraTabPage XtraTabPageContacts;
        private DevExpress.XtraEditors.PanelControl PanelControlContactTab;
        private DevExpress.XtraEditors.TextEdit TextEditEmail;
        private DevExpress.XtraEditors.TextEdit TextEditFaxNum;
        private DevExpress.XtraEditors.TextEdit TextEditPhone;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraTab.XtraTabPage XtraTabPageAvailability;
        private DevExpress.XtraEditors.PanelControl PanelControlAvailabilityTab;
        private DevExpress.XtraTab.XtraTabPage XtraTabPageReporting;
        private DevExpress.XtraEditors.PanelControl PanelControlReportTab;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraTab.XtraTabPage XtraTabPagePolicies;
        private DevExpress.XtraEditors.PanelControl PanelControlPoliciesTab;
        private DevExpress.XtraTab.XtraTabPage XtraTabPageAccounting;
        private DevExpress.XtraEditors.PanelControl PanelControlAccountTab;
        private DevExpress.XtraEditors.LabelControl LabelControlDaysSpace;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl LabelControlLastInvDate;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl LabelControlPriorDays;
        private DevExpress.XtraEditors.LabelControl LabelControlPmtDays;
        private DevExpress.XtraEditors.LabelControl LabelControlDueDays;
        private DevExpress.XtraEditors.CheckEdit CheckEditSvcDateFlg;
        private DevExpress.XtraEditors.ComboBoxEdit ComboBoxEditInvFmt;
        private DevExpress.XtraEditors.CheckEdit CheckEditImmedFlg;
        private DevExpress.XtraTab.XtraTabPage XtraTabPageAdministrativeFees;
        private DevExpress.XtraEditors.PanelControl PanelControlAdminTab;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraTab.XtraTabPage XtraTabPageMemberships;
        private DevExpress.XtraEditors.PanelControl PanelControlMemberTab;
        private DevExpress.XtraTab.XtraTabPage XtraTabPageResources;
        private DevExpress.XtraEditors.PanelControl PanelControlResourceTab;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.PictureEdit PictureEditPreview;
        private DevExpress.XtraTab.XtraTabPage XtraTabPageCustom;
        private DevExpress.XtraTab.XtraTabPage XtraTabPageCommissions;
        private DevExpress.XtraEditors.TextEdit TextEditAr;
        private DevExpress.XtraEditors.TextEdit TextEditAp;
        private DevExpress.XtraEditors.TextEdit TextEditType;
        private DevExpress.XtraEditors.TextEdit TextEditName;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraEditors.TextEdit TextEditWebsite;
        private DevExpress.XtraEditors.PanelControl PanelControlCustomTab;
        private DevExpress.XtraGrid.GridControl GridControlCustom;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewCustom;
        private System.Windows.Forms.BindingSource BindingSourceAgcyLog;
        private DevExpress.XtraEditors.TextEdit TextEditChgFlat1;
        private DevExpress.XtraEditors.TextEdit TextEditChgPct1;
        private DevExpress.XtraEditors.SpinEdit SpinEditCxlNtsPrior1;
        private DevExpress.XtraEditors.SpinEdit SpinEditChgNtsPrior1;
        private DevExpress.XtraEditors.TextEdit TextEditCxlFlat1;
        private DevExpress.XtraEditors.TextEdit TextEditCxlPct1;
        private DevExpress.XtraEditors.TextEdit TextEditChgFlat3;
        private DevExpress.XtraEditors.TextEdit TextEditChgPct3;
        private DevExpress.XtraEditors.SpinEdit SpinEditChgNtsPrior3;
        private DevExpress.XtraEditors.SpinEdit SpinEditCxlNtsPrior3;
        private DevExpress.XtraEditors.TextEdit TextEditCxlFlat3;
        private DevExpress.XtraEditors.TextEdit TextEditCxlPct3;
        private DevExpress.XtraEditors.SpinEdit SpinEditArvBkDays;
        private DevExpress.XtraEditors.SpinEdit SpinEditRel;
        private DevExpress.XtraEditors.SpinEdit SpinEditVoucherDaysPrior;
        private DevExpress.XtraEditors.SpinEdit SpinEditVoucherReprints;
        private DevExpress.XtraEditors.SpinEdit SpinEditComm;
        private DevExpress.XtraEditors.SpinEdit SpinEditCxlGrace;
        private DevExpress.XtraEditors.SpinEdit SpinEditOptDays;
        private DevExpress.XtraEditors.SpinEdit SpinEditDaysSpace;
        private DevExpress.XtraEditors.SpinEdit SpinEditPriorDays;
        private DevExpress.XtraEditors.SpinEdit SpinEditPmtDays;
        private DevExpress.XtraEditors.SpinEdit SpinEditDueDays;
        private DevExpress.XtraTab.XtraTabPage XtraTabPageAgents;
        private DevExpress.XtraEditors.PanelControl PanelControlAgentTab;
        private DevExpress.XtraEditors.PanelControl PanelControlLocationTab;
        private DevExpress.XtraEditors.TextEdit TextEditZip;
        private DevExpress.XtraEditors.TextEdit TextEditAddr3;
        private DevExpress.XtraEditors.TextEdit TextEditAddr2;
        private DevExpress.XtraEditors.TextEdit TextEditAddr1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl GridControlContacts;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewContacts;
        private DevExpress.XtraGrid.GridControl GridControlMemberships;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewMemberships;
        private DevExpress.XtraEditors.PanelControl PanelControlCommTab;
        private DevExpress.XtraGrid.GridControl GridControlAgcyLog;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewAgcyLog;
        private System.Windows.Forms.BindingSource BindingSourceComprod2;
        private DevExpress.XtraGrid.Columns.GridColumn colLINK_TABLE;
        private DevExpress.XtraGrid.Columns.GridColumn colLINK_VALUE;
        private DevExpress.XtraGrid.Columns.GridColumn colNAME1;
        private DevExpress.XtraGrid.Columns.GridColumn colDEPT;
        private DevExpress.XtraGrid.Columns.GridColumn colADDRESS1;
        private DevExpress.XtraGrid.Columns.GridColumn colADDRESS2;
        private DevExpress.XtraGrid.Columns.GridColumn colADDRESS3;
        private DevExpress.XtraGrid.Columns.GridColumn colCITY;
        private DevExpress.XtraGrid.Columns.GridColumn colSTATE;
        private DevExpress.XtraGrid.Columns.GridColumn colZIP;
        private DevExpress.XtraGrid.Columns.GridColumn colGMACCTNO;
        private DevExpress.XtraGrid.Columns.GridColumn colGMRECID;
        private DevExpress.XtraGrid.Columns.GridColumn colDEPT_HEAD;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colACTIVE;
        private DevExpress.XtraGrid.Columns.GridColumn colCOMM_PREF;
        private DevExpress.XtraGrid.Columns.GridColumn colCOUNTRY;
        private DevExpress.XtraGrid.Columns.GridColumn colUSER_DEC1;
        private DevExpress.XtraGrid.Columns.GridColumn colUSER_DEC2;
        private DevExpress.XtraGrid.Columns.GridColumn colUSER_INT1;
        private DevExpress.XtraGrid.Columns.GridColumn colUSER_INT2;
        private DevExpress.XtraGrid.Columns.GridColumn colUSER_TXT1;
        private DevExpress.XtraGrid.Columns.GridColumn colUSER_TXT2;
        private DevExpress.XtraGrid.Columns.GridColumn colUSER_TXT3;
        private DevExpress.XtraGrid.Columns.GridColumn colUSER_TXT4;
        private DevExpress.XtraGrid.Columns.GridColumn colUSER_DTE1;
        private DevExpress.XtraGrid.Columns.GridColumn colUSER_DTE2;
        private DevExpress.XtraGrid.Columns.GridColumn colLOGIN_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colPASSWORD;
        private DevExpress.XtraGrid.Columns.GridColumn colLOGIN_ROLE;
        private DevExpress.XtraGrid.Columns.GridColumn colLOGIN_ACTIVE;
        private DevExpress.XtraGrid.Columns.GridColumn colRECTYPE;
        private DevExpress.XtraGrid.Columns.GridColumn colPARENT_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colTITLE;
        private DevExpress.XtraGrid.Columns.GridColumn colDEAR;
        private DevExpress.XtraGrid.Columns.GridColumn colPHONE;
        private DevExpress.XtraGrid.Columns.GridColumn colFAX;
        private DevExpress.XtraGrid.Columns.GridColumn colEMAIL;
        private System.Windows.Forms.BindingSource BindingSourceUserfield;
        private DevExpress.XtraGrid.Columns.GridColumn colLINK_TABLE1;
        private DevExpress.XtraGrid.Columns.GridColumn colLINK_COLUMN;
        private DevExpress.XtraGrid.Columns.GridColumn colRECTYPE1;
        private DevExpress.XtraGrid.Columns.GridColumn colLABEL;
        private DevExpress.XtraGrid.Columns.GridColumn colDESC;
        private DevExpress.XtraGrid.Columns.GridColumn colVISIBLE;
        private DevExpress.XtraGrid.Columns.GridColumn colLKUP_CODE_COLUMN;
        private DevExpress.XtraGrid.Columns.GridColumn colLKUP_DESC_COLUMN;
        private DevExpress.XtraGrid.Columns.GridColumn colLKUP_TABLE;
        private DevExpress.XtraGrid.Columns.GridColumn colSIZE;
        private DevExpress.XtraGrid.Columns.GridColumn colMIN;
        private DevExpress.XtraGrid.Columns.GridColumn colMAX;
        private DevExpress.XtraGrid.Columns.GridColumn colRESTRICT_TO_LKUP;
        private DevExpress.XtraGrid.Columns.GridColumn colPRECISION;
        private DevExpress.XtraGrid.Columns.GridColumn colREQUIRED;
        private DevExpress.XtraGrid.Columns.GridColumn colAGT_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colAGENCY1;
        private DevExpress.XtraGrid.Columns.GridColumn colAGCY_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colCUR_BOOK;
        private DevExpress.XtraGrid.Columns.GridColumn colSUPVR_FLG;
        private DevExpress.XtraGrid.Columns.GridColumn colRES_PROF;
        private DevExpress.XtraGrid.Columns.GridColumn colMNT_PROF;
        private DevExpress.XtraGrid.Columns.GridColumn colACC_PROF;
        private DevExpress.XtraGrid.Columns.GridColumn colPRT_PROF;
        private DevExpress.XtraGrid.Columns.GridColumn colAGT_EMAIL;
        private DevExpress.XtraGrid.Columns.GridColumn colAGT_FAX;
        private DevExpress.XtraGrid.Columns.GridColumn colPASSWORD1;
        private DevExpress.XtraGrid.Columns.GridColumn colAGY;
        public DevExpress.XtraGrid.Columns.GridColumn colDATAFLEX_FILL_01;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private System.Windows.Forms.BindingSource BindingSourceDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colID1;
        private DevExpress.XtraGrid.Columns.GridColumn colLINK_TABLE2;
        private DevExpress.XtraGrid.Columns.GridColumn colRECTYPE2;
        private DevExpress.XtraGrid.Columns.GridColumn colLINK_VALUE1;
        private DevExpress.XtraGrid.Columns.GridColumn colCODE;
        private DevExpress.XtraGrid.Columns.GridColumn colNOTE;
        private DevExpress.XtraGrid.Columns.GridColumn colUSER_DEC12;
        private DevExpress.XtraGrid.Columns.GridColumn colUSER_DEC22;
        private DevExpress.XtraGrid.Columns.GridColumn colUSER_INT12;
        private DevExpress.XtraGrid.Columns.GridColumn colUSER_INT22;
        private DevExpress.XtraGrid.Columns.GridColumn colUSER_TXT12;
        private DevExpress.XtraGrid.Columns.GridColumn colUSER_TXT22;
        private DevExpress.XtraGrid.Columns.GridColumn colUSER_TXT32;
        private DevExpress.XtraGrid.Columns.GridColumn colUSER_TXT42;
        private DevExpress.XtraGrid.Columns.GridColumn colUSER_DTE12;
        private DevExpress.XtraGrid.Columns.GridColumn colUSER_DTE22;
        private DevExpress.XtraEditors.CheckEdit CheckEditActiveFlg;
        private DevExpress.XtraEditors.CheckEdit CheckEditSubAlloc;
        private DevExpress.XtraEditors.CheckEdit CheckEditSglResConf;
        private DevExpress.XtraEditors.CheckEdit CheckEditRemoteVouchers;
        private DevExpress.XtraEditors.CheckEdit CheckEditAllowAttachments;
        private DevExpress.XtraEditors.CheckEdit CheckEditConfPrc;
        private DevExpress.XtraEditors.CheckEdit CheckEditRemChg;
        private DevExpress.XtraEditors.ImageComboBoxEdit ImageComboBoxEditMailFaxFlg;
        private DevExpress.XtraEditors.ImageComboBoxEdit ImageComboBoxEditRetNotAvalHtls;
        private DevExpress.XtraEditors.ImageComboBoxEdit ImageComboBoxEditRetreqHtls;
        private DevExpress.XtraEditors.ImageComboBoxEdit ImageComboBoxEditHtls;
        private DevExpress.XtraEditors.ImageComboBoxEdit ImageComboBoxEditHdrs;
        private DevExpress.XtraEditors.CheckEdit checkEdit8;
        private DevExpress.XtraEditors.ImageComboBoxEdit ImageComboBoxEditTourfaxEmailFormat;
        private DevExpress.XtraEditors.SplitContainerControl SplitContainerControl;
        private DevExpress.XtraEditors.LabelControl labelControl27;
        private DevExpress.XtraEditors.LabelControl LabelControlLastUpdatedBy;
        private DevExpress.XtraEditors.LabelControl labelControl25;
        private DevExpress.XtraEditors.ButtonEdit ButtonEditLogoPath;
        private DevExpress.XtraEditors.CheckEdit CheckEditPkgVouchers;
        private DevExpress.XtraEditors.CheckEdit CheckEditOptVouchers;
        private DevExpress.XtraEditors.CheckEdit CheckEditAirVouchers;
        private DevExpress.XtraEditors.CheckEdit CheckEditCruVouchers;
        private DevExpress.XtraEditors.CheckEdit CheckEditCarVouchers;
        private DevExpress.XtraEditors.CheckEdit CheckEditHtlVouchers;
        private DevExpress.XtraEditors.SimpleButton ButtonAddContact;
        private DevExpress.XtraEditors.SimpleButton ButtonDeleteContact;
        private DevExpress.XtraEditors.SimpleButton ButtonDeleteMembership;
        private DevExpress.XtraEditors.SimpleButton ButtonAddMembership;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnRptType;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxDept;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBoxSendDocs;
        private DevExpress.XtraGrid.GridControl GridControlMarkups;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewMarkups;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnServiceEndMU;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnBookStartDateMU;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnBookEndDateMU;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnCommPctMU;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit4;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnStartDateMU;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnAgencyRuleMU;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnPositionMU;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnProductRuleMU;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnRecType;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnSourceMU;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit5;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnCategoryMU;
        private DevExpress.XtraGrid.GridControl GridControlCommissions;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewCommissions;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnEndDateComm;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnBookStartDateComm;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnBookEndDateComm;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnCommPctComm;
        private DevExpress.XtraGrid.Columns.GridColumn colInactive;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnStartDateComm;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnAgencyRuleComm;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnPositionComm;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnProductRuleComm;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnSourceComm;
        private DevExpress.XtraGrid.Columns.GridColumn colExclusion1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnCategoryComm;
        private DevExpress.XtraEditors.LabelControl LabelSource;
        private DevExpress.XtraEditors.ComboBoxEdit ComboBoxEditSource;
        private DevExpress.XtraEditors.SimpleButton ButtonSearch;
        private DevExpress.XtraEditors.LabelControl LabelControlLastUpdated;
        private System.Windows.Forms.Label LabelDate;
        private System.Windows.Forms.Label LabelAgency;
        private DevExpress.XtraEditors.TextEdit TextEditChgFlat2;
        private DevExpress.XtraEditors.TextEdit TextEditChgPct2;
        private DevExpress.XtraEditors.SpinEdit SpinEditChgNtsPrior2;
        private DevExpress.XtraEditors.SpinEdit SpinEditCxlNtsPrior2;
        private DevExpress.XtraEditors.TextEdit TextEditCxlFlat2;
        private DevExpress.XtraEditors.TextEdit TextEditCxlPct2;
        private DevExpress.XtraEditors.LabelControl labelControlSize;
        private DevExpress.XtraEditors.PanelControl PanelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
        private DevExpress.XtraEditors.TextEdit TextEditCity;
        private DevExpress.XtraEditors.TextEdit TextEditState;
        private DevExpress.XtraGrid.GridControl GridControlCreditProfiles;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewCreditProfiles;
        private System.Windows.Forms.Label LblCreditCardProf;
        private System.Windows.Forms.BindingSource BindingSourcePaymentProfiles;
        private DevExpress.XtraGrid.Columns.GridColumn grdColID;
        private DevExpress.XtraGrid.Columns.GridColumn grdColCardNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdColExpirationYear;
        private DevExpress.XtraGrid.Columns.GridColumn grdColCVV2;
        private DevExpress.XtraGrid.Columns.GridColumn grdColCompany;
        private DevExpress.XtraGrid.Columns.GridColumn grdColFirst;
        private DevExpress.XtraGrid.Columns.GridColumn grdColLast;
        private DevExpress.XtraGrid.Columns.GridColumn gridColStreet;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCity;
        private DevExpress.XtraGrid.Columns.GridColumn gridColState;
        private DevExpress.XtraGrid.Columns.GridColumn gridColZip;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCountry;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPhone;
        private DevExpress.XtraEditors.CheckEdit CheckEditCreditUnlimited;
        private DevExpress.XtraTab.XtraTabPage XtraTabPagePayments;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit TextEditCustomerProfileEmail;
        private System.Windows.Forms.BindingSource BindingSourceCreditCardInfo;
        private DevExpress.XtraEditors.SimpleButton DeleteButton;
        private DevExpress.XtraEditors.SimpleButton ChangePaymentProfileButton;
        private DevExpress.XtraEditors.SimpleButton AddCreditButton;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.GridControl GridControlBankProfiles;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewBankProfiles;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnBankName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAccountType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAccountNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnStreet;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCity;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnState;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnZipCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCountry;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPhone;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnRoutingNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnNameOnAccount;
        private DevExpress.XtraEditors.SimpleButton ButtonAddBank;
        private System.Windows.Forms.Label LabelPaymentProcessorCustProfileId;
        private System.Windows.Forms.BindingSource BindingSource;
        private DevExpress.XtraEditors.SimpleButton ButtonDeleteCredit;
        private DevExpress.XtraEditors.SimpleButton ButtonDeleteBank;
        private System.Windows.Forms.Label LabelDefaultPaymentProfileID;
        private DevExpress.XtraEditors.CheckEdit CheckEditRequireCVV2;
        private DevExpress.XtraGrid.Columns.GridColumn colNO;
        private DevExpress.XtraGrid.Columns.GridColumn colNAME;
        private DevExpress.XtraGrid.Columns.GridColumn colLAST_UPD;
        private DevExpress.XtraGrid.Columns.GridColumn colUPD_INIT;
        private DevExpress.XtraGrid.Columns.GridColumn colTYP;
        private DevExpress.XtraGrid.Columns.GridColumn colAP;
        private DevExpress.XtraGrid.Columns.GridColumn colAR;
        private DevExpress.XtraGrid.Columns.GridColumn colADDR1;
        private DevExpress.XtraGrid.Columns.GridColumn colADDR2;
        private DevExpress.XtraGrid.Columns.GridColumn colADDR3;
        private DevExpress.XtraGrid.Columns.GridColumn colPHONE1;
        private DevExpress.XtraGrid.Columns.GridColumn colCONSORT;
        private DevExpress.XtraGrid.Columns.GridColumn colCOMM;
        private DevExpress.XtraGrid.Columns.GridColumn colSTATE1;
        private DevExpress.XtraGrid.Columns.GridColumn colSRT2;
        private DevExpress.XtraGrid.Columns.GridColumn colSRT3;
        private DevExpress.XtraGrid.Columns.GridColumn colDEF_LANG;
        private DevExpress.XtraGrid.Columns.GridColumn colREL;
        private DevExpress.XtraGrid.Columns.GridColumn colFAX_NUM;
        private DevExpress.XtraGrid.Columns.GridColumn colPMT_DAYS;
        private DevExpress.XtraGrid.Columns.GridColumn colACTIVE_FLG;
        private DevExpress.XtraGrid.Columns.GridColumn colIMMED_FLG;
        private DevExpress.XtraGrid.Columns.GridColumn colINV_FMT;
        private DevExpress.XtraGrid.Columns.GridColumn colPRIOR_DAYS;
        private DevExpress.XtraGrid.Columns.GridColumn colLAST_INV;
        private DevExpress.XtraGrid.Columns.GridColumn colDAYS_SPACE;
        private DevExpress.XtraGrid.Columns.GridColumn colSVCDTE_FLG;
        private DevExpress.XtraGrid.Columns.GridColumn colFAX_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colOPT_DAYS;
        private DevExpress.XtraGrid.Columns.GridColumn colSUB_ALLOC;
        private DevExpress.XtraGrid.Columns.GridColumn colMAILFAX_FLG;
        private DevExpress.XtraGrid.Columns.GridColumn colREM_CHG;
        private DevExpress.XtraGrid.Columns.GridColumn colCONF_PRC;
        private DevExpress.XtraGrid.Columns.GridColumn colEMAIL1;
        private DevExpress.XtraGrid.Columns.GridColumn colCXL1_NTSPRIOR;
        private DevExpress.XtraGrid.Columns.GridColumn colCXL1_PCT;
        private DevExpress.XtraGrid.Columns.GridColumn colCXL1_FLAT;
        private DevExpress.XtraGrid.Columns.GridColumn colCHG1_NTSPRIOR;
        private DevExpress.XtraGrid.Columns.GridColumn colCHG1_PCT;
        private DevExpress.XtraGrid.Columns.GridColumn colCHG1_FLAT;
        private DevExpress.XtraGrid.Columns.GridColumn colCXL2_NTSPRIOR;
        private DevExpress.XtraGrid.Columns.GridColumn colCXL2_PCT;
        private DevExpress.XtraGrid.Columns.GridColumn colCXL2_FLAT;
        private DevExpress.XtraGrid.Columns.GridColumn colCHG2_NTSPRIOR;
        private DevExpress.XtraGrid.Columns.GridColumn colCHG2_PCT;
        private DevExpress.XtraGrid.Columns.GridColumn colCHG2_FLAT;
        private DevExpress.XtraGrid.Columns.GridColumn colCXL3_NTSPRIOR;
        private DevExpress.XtraGrid.Columns.GridColumn colCXL3_PCT;
        private DevExpress.XtraGrid.Columns.GridColumn colCXL3_FLAT;
        private DevExpress.XtraGrid.Columns.GridColumn colCHG3_NTSPRIOR;
        private DevExpress.XtraGrid.Columns.GridColumn colCHG3_PCT;
        private DevExpress.XtraGrid.Columns.GridColumn colCHG3_FLAT;
        private DevExpress.XtraGrid.Columns.GridColumn colCXLGRACE;
        private DevExpress.XtraGrid.Columns.GridColumn colARVBKDAYS;
        private DevExpress.XtraGrid.Columns.GridColumn colRETREQHTLS;
        private DevExpress.XtraGrid.Columns.GridColumn colRETNOTAVALHTLS;
        private DevExpress.XtraGrid.Columns.GridColumn colEDITHTLS;
        private DevExpress.XtraGrid.Columns.GridColumn colEDITHDRS;
        private DevExpress.XtraGrid.Columns.GridColumn colSIMPLEAVAL;
        private DevExpress.XtraGrid.Columns.GridColumn colGMACCTNO1;
        private DevExpress.XtraGrid.Columns.GridColumn colREMOTE_VOUCHERS;
        private DevExpress.XtraGrid.Columns.GridColumn colVOUCHER_DAYS_PRIOR;
        private DevExpress.XtraGrid.Columns.GridColumn colVOUCHER_REPRINTS;
        private DevExpress.XtraGrid.Columns.GridColumn colLOGO_PATH;
        private DevExpress.XtraGrid.Columns.GridColumn colCOUNTRY1;
        private DevExpress.XtraGrid.Columns.GridColumn colPARENT;
        private DevExpress.XtraGrid.Columns.GridColumn colCITY1;
        private DevExpress.XtraGrid.Columns.GridColumn colZIP1;
        private DevExpress.XtraGrid.Columns.GridColumn colWEBSITE;
        private DevExpress.XtraGrid.Columns.GridColumn colUSER_DEC11;
        private DevExpress.XtraGrid.Columns.GridColumn colUSER_DEC21;
        private DevExpress.XtraGrid.Columns.GridColumn colUSER_INT11;
        private DevExpress.XtraGrid.Columns.GridColumn colUSER_INT21;
        private DevExpress.XtraGrid.Columns.GridColumn colUSER_TXT11;
        private DevExpress.XtraGrid.Columns.GridColumn colUSER_TXT21;
        private DevExpress.XtraGrid.Columns.GridColumn colUSER_TXT31;
        private DevExpress.XtraGrid.Columns.GridColumn colUSER_TXT41;
        private DevExpress.XtraGrid.Columns.GridColumn colUSER_DTE11;
        private DevExpress.XtraGrid.Columns.GridColumn colUSER_DTE21;
        private DevExpress.XtraGrid.Columns.GridColumn colVOUCH_TYPES;
        private DevExpress.XtraGrid.Columns.GridColumn colALLOW_ATTACHMENTS;
        private DevExpress.XtraGrid.Columns.GridColumn colDUE_DAY;
        private DevExpress.XtraGrid.Columns.GridColumn colLanguage_Code;
        private DevExpress.XtraGrid.Columns.GridColumn colShowAllLanguages;
        private DevExpress.XtraGrid.Columns.GridColumn colTourfaxEmailFormat;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentProcessorCustProfileId;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentProcessorCustProfileEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colDefaultPaymentProfileId;
        private DevExpress.XtraGrid.Columns.GridColumn colCreditLimit;
        private DevExpress.XtraGrid.Columns.GridColumn colCreditLimitRemainingWarningPct;
        private DevExpress.XtraGrid.Columns.GridColumn colCreditUnlimited;
        private DevExpress.XtraGrid.Columns.GridColumn colRequireCVV2Number;
        private DevExpress.XtraGrid.Columns.GridColumn colAGCYLOG;
        private DevExpress.XtraGrid.Columns.GridColumn colCOUNTRY11;
        private DevExpress.XtraGrid.Columns.GridColumn colLANGUAGE;
        private DevExpress.XtraGrid.Columns.GridColumn colLANGUAGE1;
        private DevExpress.XtraGrid.Columns.GridColumn colCOMPROD;
        private DevExpress.XtraGrid.Columns.GridColumn colCOMPROD2;
        private DevExpress.XtraGrid.Columns.GridColumn colCPRATES;
        private DevExpress.XtraGrid.Columns.GridColumn colCXLFEE;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTEL;
        private DevExpress.XtraGrid.Columns.GridColumn colINVT;
        private DevExpress.XtraGrid.Columns.GridColumn colPRATES;
        private DevExpress.XtraGrid.Columns.GridColumn colSVCRESTR;
        private DevExpress.XtraGrid.Columns.GridColumn colSYSFILE;
        private DevExpress.XtraGrid.Columns.GridColumn colSYSFILE1;
        private DevExpress.XtraGrid.Columns.GridColumn colCOMPROD21;
        private DevExpress.XtraGrid.Columns.GridColumn colhrates2;
        private DevExpress.XtraGrid.Columns.GridColumn colhrates3;
        private DevExpress.XtraGrid.Columns.GridColumn colHRATES;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentTransaction;
        private DevExpress.XtraGrid.Columns.GridColumn colAgencyPaymentProfile;
        private DevExpress.XtraGrid.Columns.GridColumn colImagesRoot;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplayName1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private System.Windows.Forms.BindingSource BindingSourceAgencyCurrency;
        private ChineseHosts_FlextourDataSet chineseHosts_FlextourDataSet;
        private DevExpress.XtraEditors.SimpleButton ButtonDeleteAgencyCurrency;
        private DevExpress.XtraEditors.SimpleButton ButtonAddAgencyCurrency;
        private DevExpress.XtraGrid.GridControl GridControlAgencyCurrency;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewAgencyCurrency;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrency_Code;
        private DevExpress.XtraGrid.Columns.GridColumn colDefault;
        private DevExpress.XtraGrid.Columns.GridColumn colAgentInactive;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit RepositoryItemCheckEditAgcylogBool;
        private DevExpress.XtraEditors.CheckEdit CheckEditAllowElectronicPayment;
        private DevExpress.XtraGrid.GridControl GridControlDeposits;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewDeposits;
        private DevExpress.XtraEditors.SimpleButton ButtonAddDeposit;
        private System.Windows.Forms.BindingSource BindingSourcePaymentTransaction;
        private DevExpress.XtraGrid.Columns.GridColumn colID2;
        private DevExpress.XtraGrid.Columns.GridColumn colAgency;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraEditors.SimpleButton ButtonDeleteDeposit;
        private DevExpress.XtraEditors.TextEdit TextEditSrt3;
        private DevExpress.XtraEditors.TextEdit TextEditSrt2;
        private DevExpress.XtraEditors.SpinEdit TextEditFundBalance;
        private DevExpress.XtraEditors.SpinEdit SpinEditCreditLimit;
        private DevExpress.XtraEditors.SpinEdit SpinEditCreditLimitRemPct;
        private DevExpress.XtraEditors.SpinEdit SpinEditCreditBalance;
        private DevExpress.XtraEditors.SpinEdit TextEditAmountPaid;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager BarManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem BarButtonItemNew;
        private DevExpress.XtraBars.BarButtonItem BarButtonItemDelete;
        private DevExpress.XtraBars.BarButtonItem BarButtonItemSave;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Data.Linq.EntityInstantFeedbackSource EntityInstantFeedbackSource;
        private DevExpress.XtraEditors.SearchLookUpEdit SearchLookupEditDefLanguage;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.SearchLookUpEdit SearchLookupEditCountry;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraEditors.SearchLookUpEdit SearchLookupEditParentAgy;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraEditors.SearchLookUpEdit SearchLookupEditAgency;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraEditors.ImageComboBoxEdit ImageComboBoxEditDefaultPmtProfileID;
        private System.Windows.Forms.BindingSource BindingSourceAgencyPaymentProfile;
        private System.Windows.Forms.BindingSource BindingSourceContact;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit RepositoryItemSearchLookUpEditReportType;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private System.Windows.Forms.BindingSource BindingSourceCodeName;
        private DevExpress.XtraGrid.Columns.GridColumn colCode1;
        private DevExpress.XtraGrid.Columns.GridColumn colName2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit RepositoryItemCheckEditSupvrFlg;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit RepositoryItemTextEditPassword;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit RepositoryItemTextEditAgtEmail;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit RepositoryItemTextEditAgtFax;
        private DevExpress.XtraGrid.Columns.GridColumn colAgentCompany;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit RepositoryItemTextEditAgentCompany;
        private DevExpress.XtraGrid.Columns.GridColumn colAgcylog_Agent_Delegate;
        private DevExpress.XtraEditors.SimpleButton ButtonDeleteAgent;
        private DevExpress.XtraEditors.SimpleButton ButtonAddAgent;
        private DevExpress.XtraEditors.TextEdit TextEditCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit RepositoryItemTextEditAgentName;
        private DevExpress.XtraEditors.RadioGroup RadioGroupPaymentDue;
        private DevExpress.XtraGrid.Columns.GridColumn colCode2;
        private DevExpress.XtraGrid.Columns.GridColumn colName3;
        private DevExpress.XtraGrid.Columns.GridColumn colCode3;
        private DevExpress.XtraGrid.Columns.GridColumn colName4;
        private DevExpress.XtraEditors.DateEdit DateEditLastInvDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCode4;
        private DevExpress.XtraGrid.Columns.GridColumn colName5;
        private DevExpress.XtraGrid.Columns.GridColumn colCode6;
        private DevExpress.XtraGrid.Columns.GridColumn colName6;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit RepositoryItemSearchLookUpEditClass;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton SimpleButtonValidateCreditRow;
        private DevExpress.XtraEditors.SimpleButton SimpleButtonValidateBankRow;
        private DevExpress.XtraEditors.DateEdit DateEditDate;
        private System.Windows.Forms.Label LabelMarkups;
        private System.Windows.Forms.Label LabelCommissions;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox RepositoryItemImageComboBoxEditAgentDelegate;
        private System.Windows.Forms.BindingSource BindingSourceAgencyPaymentProfileBank;
        private DevExpress.XtraGrid.Columns.GridColumn colCode5;
        private DevExpress.XtraGrid.Columns.GridColumn colName7;
        private DevExpress.XtraGrid.Columns.GridColumn colAgcylogReadOnly;
        private DevExpress.XtraGrid.Columns.GridColumn gridColAccountType;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBoxAccountType;
        private DevExpress.XtraEditors.PanelControl PanelControlPaymentProfileStatus;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.Label LabelPaymentProfileStatus;
        private DevExpress.XtraEditors.SimpleButton SimpleButtonRetry;
        private DevExpress.XtraGrid.Columns.GridColumn gridColExpirationMonth;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox RepositoryItemImageComboBoxExpMonth;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit RepositoryItemSpinEditExpYear;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit RepositoryItemCheckedComboBoxEditReportType;
        private DevExpress.XtraEditors.CheckedComboBoxEdit TextEditVouchTypes;
    }
}