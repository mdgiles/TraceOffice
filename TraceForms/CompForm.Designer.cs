namespace TraceForms
{
    partial class CompForm
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
            System.Windows.Forms.Label LabelCode;
            System.Windows.Forms.Label LabelRateBasis;
            System.Windows.Forms.Label LabelRestrictions;
            System.Windows.Forms.Label LabelVendorCode;
            System.Windows.Forms.Label LabelOperator;
            System.Windows.Forms.Label LabelName;
            System.Windows.Forms.Label language_CodeLabel;
            System.Windows.Forms.Label difficultyLabel;
            System.Windows.Forms.Label LabelAgency;
            System.Windows.Forms.Label LabelDate;
            System.Windows.Forms.Label LabelTransferType;
            System.Windows.Forms.Label LabelDefaultTime;
            System.Windows.Forms.Label LabelVoucheringDaysPrior;
            System.Windows.Forms.Label LabelMinDuration;
            System.Windows.Forms.Label LabelAPNumber;
            System.Windows.Forms.Label LabelARNumber;
            System.Windows.Forms.Label LabelDueDays;
            System.Windows.Forms.Label LabelStreet;
            System.Windows.Forms.Label LabelMilesTo;
            System.Windows.Forms.Label LabelCityMilesTo;
            System.Windows.Forms.Label LabelLong;
            System.Windows.Forms.Label LabelLat;
            System.Windows.Forms.Label LabelMaxDuration;
            System.Windows.Forms.Label LabelRanking;
            System.Windows.Forms.Label LabelRating;
            System.Windows.Forms.Label LabelUserReviews;
            System.Windows.Forms.Label LabelVoucherTypes;
            System.Windows.Forms.Label LabelStartingCost;
            System.Windows.Forms.Label LabelStartingPrice;
            System.Windows.Forms.Label LabelStartingComparison;
            System.Windows.Forms.Label LabelStartingAgentNet;
            System.Windows.Forms.Label LabelMaxPax;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label LabelOnRequestPeriod;
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompForm));
            this.ImageComboBoxEditRestrictionsCode = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ImageComboBoxEditRateBasis = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.labelControlUpdBy = new DevExpress.XtraEditors.LabelControl();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.labelControlLastUpd = new DevExpress.XtraEditors.LabelControl();
            this.LabelLastUpdated = new DevExpress.XtraEditors.LabelControl();
            this.BingMapDataProvider = new DevExpress.XtraMap.BingMapDataProvider();
            this.MapItemStorage = new DevExpress.XtraMap.MapItemStorage();
            this.BingSearchDataProvider = new DevExpress.XtraMap.BingSearchDataProvider();
            this.BindingSourceCompBusRoutes = new System.Windows.Forms.BindingSource(this.components);
            this.BindingSourceBusRoutes = new System.Windows.Forms.BindingSource(this.components);
            this.BindingSourceBusRouteStop = new System.Windows.Forms.BindingSource(this.components);
            this.BindingSourceBusTable = new System.Windows.Forms.BindingSource(this.components);
            this.BindingSourceCodeName = new System.Windows.Forms.BindingSource(this.components);
            this.BindingSourceDetail = new System.Windows.Forms.BindingSource(this.components);
            this.BindingSourceUserFields = new System.Windows.Forms.BindingSource(this.components);
            this.BindingSourceSupplierProduct = new System.Windows.Forms.BindingSource(this.components);
            this.BindingSourceSupplierCategory = new System.Windows.Forms.BindingSource(this.components);
            this.CheckEditInactive = new DevExpress.XtraEditors.CheckEdit();
            this.TextEditVendorCode = new DevExpress.XtraEditors.TextEdit();
            this.TextEditName = new DevExpress.XtraEditors.TextEdit();
            this.GridControlLookup = new DevExpress.XtraGrid.GridControl();
            this.EntityInstantFeedbackSource = new DevExpress.Data.Linq.EntityInstantFeedbackSource();
            this.GridViewLookup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDisplayName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLAST_UPD1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnUpdInit1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnAP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnCity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnOper = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnIncl1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnIncl2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnIncl3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colINCL4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colINCL5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colINCL6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnRateBasis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnRstr_Cde = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnTransferType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnServiceList = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPUDRP_REQ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnService_Type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnUseClientLogo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnVouchDaysPrior = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnLatitude = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnLongitude = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnUserDec1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnUserDec2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnUserInt1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnUserInt2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnUserTxt1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnUserTxt2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnUserTxt3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnUserTxt4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnUserDte1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnUserDte2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnZip = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnTown = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnGMACCTNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnAddr1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnAddr2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnAddr3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnCountry = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColCityMiles = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnAirport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnAirportMiles = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMultiple_Times = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDefault_Time = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransfer_List = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRequire_ArvInfo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnRequiredDepInfo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnAllowFreesell = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInactive1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnVendorCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDue_Days = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLanguage_Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnType1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeoCode_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDifficulty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnMealsIncluded = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDuration = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnAdmin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnUnit_Rate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnAirport1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnCityCod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnCountry1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnLanguage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnOperator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnSERVTYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCPRATES = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnServRestr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BindingSourceBusStation = new System.Windows.Forms.BindingSource(this.components);
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.SplitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.TextEditCode = new DevExpress.XtraEditors.TextEdit();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageLocation = new DevExpress.XtraTab.XtraTabPage();
            this.PanelControlLocationTab = new DevExpress.XtraEditors.PanelControl();
            this.SearchLookUpEditRegion = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView16 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.SearchLookupEditDepCity = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView19 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LabelControlLon = new DevExpress.XtraEditors.LabelControl();
            this.LabelControlLat = new DevExpress.XtraEditors.LabelControl();
            this.SimpleButtonPlot = new DevExpress.XtraEditors.SimpleButton();
            this.MapControl = new DevExpress.XtraMap.MapControl();
            this.ImageLayer = new DevExpress.XtraMap.ImageLayer();
            this.VectorItemsLayer = new DevExpress.XtraMap.VectorItemsLayer();
            this.InformationLayer = new DevExpress.XtraMap.InformationLayer();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.CheckEditProximitySearch = new DevExpress.XtraEditors.CheckEdit();
            this.SpinEditDistance = new DevExpress.XtraEditors.SpinEdit();
            this.TextEditCityMilesTo = new DevExpress.XtraEditors.TextEdit();
            this.LabelCityCode = new DevExpress.XtraEditors.LabelControl();
            this.LabelCity = new DevExpress.XtraEditors.LabelControl();
            this.LabelAirport = new DevExpress.XtraEditors.LabelControl();
            this.TextEditAirportMiles = new DevExpress.XtraEditors.TextEdit();
            this.LabelAirportCode = new DevExpress.XtraEditors.LabelControl();
            this.TextEditAddr1 = new DevExpress.XtraEditors.TextEdit();
            this.TextEditZip = new DevExpress.XtraEditors.TextEdit();
            this.TextEditTown = new DevExpress.XtraEditors.TextEdit();
            this.LabelAddressCity = new DevExpress.XtraEditors.LabelControl();
            this.LabelCountry = new DevExpress.XtraEditors.LabelControl();
            this.TextEditAddr2 = new DevExpress.XtraEditors.TextEdit();
            this.LabelState = new DevExpress.XtraEditors.LabelControl();
            this.LabelZip = new DevExpress.XtraEditors.LabelControl();
            this.TextEditAddr3 = new DevExpress.XtraEditors.TextEdit();
            this.SearchLookupEditState = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SearchLookupEditCountry = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView7 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SearchLookupEditCity = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView10 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SearchLookupEditAirportCode = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView11 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabPagePolicies = new DevExpress.XtraTab.XtraTabPage();
            this.PanelControlPoliciesTab = new DevExpress.XtraEditors.PanelControl();
            this.CheckEditPhone = new DevExpress.XtraEditors.CheckEdit();
            this.CheckEditAdmin = new DevExpress.XtraEditors.CheckEdit();
            this.SpinEditOnRequestPeriod = new DevExpress.XtraEditors.SpinEdit();
            this.ImageComboBoxEditConfirmationType = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.SpinEditMaxPax = new DevExpress.XtraEditors.SpinEdit();
            this.SpinEditStartingAgentNet = new DevExpress.XtraEditors.SpinEdit();
            this.SpinEditStartingComparison = new DevExpress.XtraEditors.SpinEdit();
            this.spinEditStartingPrice = new DevExpress.XtraEditors.SpinEdit();
            this.SpinEditStartingCost = new DevExpress.XtraEditors.SpinEdit();
            this.CheckEditAllNames = new DevExpress.XtraEditors.CheckEdit();
            this.CheckEditAdminClosed = new DevExpress.XtraEditors.CheckEdit();
            this.ImageComboBoxEditVoucherTypes = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.CheckEditDOBRequired = new DevExpress.XtraEditors.CheckEdit();
            this.spinEdit2 = new DevExpress.XtraEditors.SpinEdit();
            this.RatingControlStars = new DevExpress.XtraEditors.RatingControl();
            this.SpinEditRanking = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit1 = new DevExpress.XtraEditors.SpinEdit();
            this.TextEditDueDays = new DevExpress.XtraEditors.TextEdit();
            this.TextEditARNumber = new DevExpress.XtraEditors.TextEdit();
            this.TextEditAPNumber = new DevExpress.XtraEditors.TextEdit();
            this.checkEditDropoffInfoRequired = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditPickupInfoRequired = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditPassengerWeightRequired = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditAccountingServiceItem = new DevExpress.XtraEditors.CheckEdit();
            this.CheckEditVendorPrepayReqd = new DevExpress.XtraEditors.CheckEdit();
            this.unit_RateCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.mealsIncludedCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.CheckEditMultTimes = new DevExpress.XtraEditors.CheckEdit();
            this.CheckEditAllowFree = new DevExpress.XtraEditors.CheckEdit();
            this.CheckEditClientLogo = new DevExpress.XtraEditors.CheckEdit();
            this.SpinEditDayPrior = new DevExpress.XtraEditors.SpinEdit();
            this.CheckEditReqDepInfo = new DevExpress.XtraEditors.CheckEdit();
            this.CheckEditReqArvInfo = new DevExpress.XtraEditors.CheckEdit();
            this.CheckEditDropoff = new DevExpress.XtraEditors.CheckEdit();
            this.CheckEditPickup = new DevExpress.XtraEditors.CheckEdit();
            this.CheckEditTransferList = new DevExpress.XtraEditors.CheckEdit();
            this.CheckEditSvcList = new DevExpress.XtraEditors.CheckEdit();
            this.SpinEditDuration = new DevExpress.XtraEditors.SpinEdit();
            this.ImageComboBoxEditTransType = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.TextEditDefaultTime = new DevExpress.XtraEditors.TimeEdit();
            this.xtraTabPageServices = new DevExpress.XtraTab.XtraTabPage();
            this.PanelControlServicesTab = new DevExpress.XtraEditors.PanelControl();
            this.TextEditIncl6 = new DevExpress.XtraEditors.TextEdit();
            this.TextEditIncl1 = new DevExpress.XtraEditors.TextEdit();
            this.TextEditIncl3 = new DevExpress.XtraEditors.TextEdit();
            this.TextEditIncl5 = new DevExpress.XtraEditors.TextEdit();
            this.TextEditIncl4 = new DevExpress.XtraEditors.TextEdit();
            this.TextEditIncl2 = new DevExpress.XtraEditors.TextEdit();
            this.xtraTabPageRoutes = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonRemoveRoute = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonAddRoute = new DevExpress.XtraEditors.SimpleButton();
            this.GridControlRoutes = new DevExpress.XtraGrid.GridControl();
            this.GridViewRoutes = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComp_Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBusRoute_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditBusRoutes = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCPRates_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCOMP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBusRoute = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCPRATES1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnFromStop = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditStop = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumnToStop = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnInactive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEditInactive = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridView13 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabPageTransferPoints = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.ButtonDelRow = new DevExpress.XtraEditors.SimpleButton();
            this.ButtonAddRow = new DevExpress.XtraEditors.SimpleButton();
            this.GridControlTransferPoints = new DevExpress.XtraGrid.GridControl();
            this.GridViewTransferPoints = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnCode1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnPickDrop = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemImageComboBoxPickDrop = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.ColumnStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEditDate = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.ColumnLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemSearchLookupEditLocation = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemImageComboboxLocationView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnDepartureTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnLastUpd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnUpdInit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnInOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnLocationType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBoxLocType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.ColumnCarOffice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnArrivalTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnExclusion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEditLocationExclusion = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnRoute = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBoxRoutes = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gridColumnCat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemSearchLookUpEditCat = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnServiceTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemTimeEditServiceTime = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.gridView12 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabPageMemberships = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.GridControlDetail = new DevExpress.XtraGrid.GridControl();
            this.GridViewDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLINK_TABLE1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLINK_VALUE1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCODE1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSearchLookUpEditClass = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView14 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNOTE = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.buttonDelMembership = new DevExpress.XtraEditors.SimpleButton();
            this.buttonAddMembership = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPageCustom = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.GridControlUserfields = new DevExpress.XtraGrid.GridControl();
            this.GridViewUserFields = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColumnLinkTable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnLink_Column = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnRecType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnLabel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnVisible = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnLinkupCodeColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnLookupDescColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnLookupTable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnMin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnMax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnRestrictToLookup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnPrecision = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnRequired = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColPosition1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumnCustomValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabPageCommissions = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl7 = new DevExpress.XtraEditors.PanelControl();
            this.LabelSource = new DevExpress.XtraEditors.LabelControl();
            this.ComboBoxEditSource = new DevExpress.XtraEditors.ComboBoxEdit();
            this.LabelMarkups = new DevExpress.XtraEditors.LabelControl();
            this.LabelCommissions = new DevExpress.XtraEditors.LabelControl();
            this.GridControlMarkups = new DevExpress.XtraGrid.GridControl();
            this.gridViewMarkups = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.colRectype1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnSourceComm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExclusion1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.ColumnCategoryComm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ButtonSearch = new DevExpress.XtraEditors.SimpleButton();
            this.SearchLookupEditAgency = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ButtonEditDate = new DevExpress.XtraEditors.DateEdit();
            this.xtraTabPageSupplierMapping = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.GridControlSupplierProduct = new DevExpress.XtraGrid.GridControl();
            this.GridViewSupplierProduct = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnSupplierProductId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnProductType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSupplierGuid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnProductSupplierCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEditMax50 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumnMappingInactive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMappingCustom1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMappingCustom2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMappingSvcStart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMappingSvcEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMappingResStart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMappingResEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMappingDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMappingOperator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRoomcod_Code_Default = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCustomSearchLookUpEditDefaultCat = new Custom_SearchLookupEdit.RepositoryItemCustomSearchLookUpEdit();
            this.repositoryItemCustomSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPickup_LocationType_Default = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBoxDefaultPupLocType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colPickup_Location_Default = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCustomSearchLookUpEditDefaultPUpLoc = new Custom_SearchLookupEdit.RepositoryItemCustomSearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPickup_Time_Default = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTimeEditDefault = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.colDropoff_LocationType_Default = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBoxDefaultDrpLocType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colDropoff_Location_Default = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCustomSearchLookUpEditDefaultDropLoc = new Custom_SearchLookupEdit.RepositoryItemCustomSearchLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDropoff_Time_Default = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMarkupPct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemSpinEditMarkupPct = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colSupplierCommPct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemSpinEditSupplierCommPct = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colRetailMarkupPct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemSpinEditRetailMarkupPct = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colMarkupFlat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemSpinEditMarkupFlat = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colSupplierCommFlat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemSpinEditSupplierCommFlat = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colRetailMarkupFlat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemSpinEditRetailMarkupFlat = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.SimpleButtonDelSuppMapping = new DevExpress.XtraEditors.SimpleButton();
            this.SimpleButtonAddSuppMapping = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPageSupplierCategories = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl8 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonDelSuppCat = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonAddSuppCat = new DevExpress.XtraEditors.SimpleButton();
            this.GridControlSupplierCategory = new DevExpress.XtraGrid.GridControl();
            this.GridViewSupplierCategory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCatMappingSupplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProduct_Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCatMappingRoomcod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemCustomSearchLookUpEditMappingCat = new Custom_SearchLookupEdit.RepositoryItemCustomSearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInactive3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colROOMCOD1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSuppCatName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.SimpleButtonDeleteSupplement = new DevExpress.XtraEditors.SimpleButton();
            this.SimpleButtonAddSupplement = new DevExpress.XtraEditors.SimpleButton();
            this.GridControlSupplements = new DevExpress.XtraGrid.GridControl();
            this.BindingSourceSupplements = new System.Windows.Forms.BindingSource(this.components);
            this.GridViewSupplement = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProduct_Type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProduct_Code1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComp_Type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComp_Code1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemSearchLookUpEditCompCode = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit3View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplementIncluded = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplementMandatory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRateSheet_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplementType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemImageComboBoxSupplementType = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gridView20 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CheckEditSupplementQtySelectable = new DevExpress.XtraEditors.CheckEdit();
            this.CheckEditSupplementIsBoard = new DevExpress.XtraEditors.CheckEdit();
            this.CheckEditSupplementPaySupplier = new DevExpress.XtraEditors.CheckEdit();
            this.CheckEditIsSupplement = new DevExpress.XtraEditors.CheckEdit();
            this.xtraTabPageRelatedProducts = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl9 = new DevExpress.XtraEditors.PanelControl();
            this.SimpleButtonDeletePassProduct = new DevExpress.XtraEditors.SimpleButton();
            this.SimpleButtonAddPass = new DevExpress.XtraEditors.SimpleButton();
            this.GridControlRelatedProducts = new DevExpress.XtraGrid.GridControl();
            this.BindingSourceRelatedProduct = new System.Windows.Forms.BindingSource(this.components);
            this.GridViewRelatedProducts = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRelatedType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemComboBoxType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colRelatedCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemSearchLookUpEditRelatedProductCode = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView17 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExcluded = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colServiceStart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemDateEditSvcStart = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colServiceEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBookingStart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBookingEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInactive2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscountPct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscountFlat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReciprocal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsRoundTrip = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsReturn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colForUpSell = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colForPackaging = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView18 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.default_TimeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.SearchLookupEditOperator = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SearchLookupEditLanguage = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SearchLookupEditDifficulty = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.BindingSourceIdName = new System.Windows.Forms.BindingSource(this.components);
            this.gridView8 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SearchLookupEditServiceType = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView9 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LabelServiceType = new DevExpress.XtraEditors.LabelControl();
            this.ComProd2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PanelControlStatus = new DevExpress.XtraEditors.PanelControl();
            this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
            this.BarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.BarButtonItemNew = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItemDelete = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItemUpdateWebsite = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            LabelCode = new System.Windows.Forms.Label();
            LabelRateBasis = new System.Windows.Forms.Label();
            LabelRestrictions = new System.Windows.Forms.Label();
            LabelVendorCode = new System.Windows.Forms.Label();
            LabelOperator = new System.Windows.Forms.Label();
            LabelName = new System.Windows.Forms.Label();
            language_CodeLabel = new System.Windows.Forms.Label();
            difficultyLabel = new System.Windows.Forms.Label();
            LabelAgency = new System.Windows.Forms.Label();
            LabelDate = new System.Windows.Forms.Label();
            LabelTransferType = new System.Windows.Forms.Label();
            LabelDefaultTime = new System.Windows.Forms.Label();
            LabelVoucheringDaysPrior = new System.Windows.Forms.Label();
            LabelMinDuration = new System.Windows.Forms.Label();
            LabelAPNumber = new System.Windows.Forms.Label();
            LabelARNumber = new System.Windows.Forms.Label();
            LabelDueDays = new System.Windows.Forms.Label();
            LabelStreet = new System.Windows.Forms.Label();
            LabelMilesTo = new System.Windows.Forms.Label();
            LabelCityMilesTo = new System.Windows.Forms.Label();
            LabelLong = new System.Windows.Forms.Label();
            LabelLat = new System.Windows.Forms.Label();
            LabelMaxDuration = new System.Windows.Forms.Label();
            LabelRanking = new System.Windows.Forms.Label();
            LabelRating = new System.Windows.Forms.Label();
            LabelUserReviews = new System.Windows.Forms.Label();
            LabelVoucherTypes = new System.Windows.Forms.Label();
            LabelStartingCost = new System.Windows.Forms.Label();
            LabelStartingPrice = new System.Windows.Forms.Label();
            LabelStartingComparison = new System.Windows.Forms.Label();
            LabelStartingAgentNet = new System.Windows.Forms.Label();
            LabelMaxPax = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            LabelOnRequestPeriod = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditRestrictionsCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditRateBasis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceCompBusRoutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceBusRoutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceBusRouteStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceBusTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceCodeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceUserFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceSupplierProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceSupplierCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditInactive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditVendorCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceBusStation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl)).BeginInit();
            this.SplitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPageLocation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlLocationTab)).BeginInit();
            this.PanelControlLocationTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookUpEditRegion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditDepCity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MapControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditProximitySearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditDistance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCityMilesTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditAirportMiles.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditAddr1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditZip.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditTown.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditAddr2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditAddr3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditCountry.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditCity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditAirportCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView11)).BeginInit();
            this.xtraTabPagePolicies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlPoliciesTab)).BeginInit();
            this.PanelControlPoliciesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditAdmin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditOnRequestPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditConfirmationType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditMaxPax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditStartingAgentNet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditStartingComparison.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditStartingPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditStartingCost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditAllNames.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditAdminClosed.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditVoucherTypes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditDOBRequired.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RatingControlStars.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditRanking.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditDueDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditARNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditAPNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditDropoffInfoRequired.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditPickupInfoRequired.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditPassengerWeightRequired.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditAccountingServiceItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditVendorPrepayReqd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unit_RateCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mealsIncludedCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditMultTimes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditAllowFree.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditClientLogo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditDayPrior.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditReqDepInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditReqArvInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditDropoff.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditPickup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditTransferList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditSvcList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditDuration.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditTransType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditDefaultTime.Properties)).BeginInit();
            this.xtraTabPageServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlServicesTab)).BeginInit();
            this.PanelControlServicesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditIncl6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditIncl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditIncl3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditIncl5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditIncl4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditIncl2.Properties)).BeginInit();
            this.xtraTabPageRoutes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlRoutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewRoutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditBusRoutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditInactive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView13)).BeginInit();
            this.xtraTabPageTransferPoints.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlTransferPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewTransferPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemImageComboBoxPickDrop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemSearchLookupEditLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboboxLocationView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxLocType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditLocationExclusion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBoxRoutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemSearchLookUpEditCat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTimeEditServiceTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView12)).BeginInit();
            this.xtraTabPageMemberships.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEditClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView14)).BeginInit();
            this.xtraTabPageCustom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlUserfields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewUserFields)).BeginInit();
            this.xtraTabPageCommissions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl7)).BeginInit();
            this.panelControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxEditSource.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlMarkups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMarkups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlCommissions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewCommissions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditAgency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEditDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEditDate.Properties)).BeginInit();
            this.xtraTabPageSupplierMapping.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlSupplierProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSupplierProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditMax50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCustomSearchLookUpEditDefaultCat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCustomSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxDefaultPupLocType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCustomSearchLookUpEditDefaultPUpLoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEditDefault)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxDefaultDrpLocType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCustomSearchLookUpEditDefaultDropLoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemSpinEditMarkupPct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemSpinEditSupplierCommPct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemSpinEditRetailMarkupPct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemSpinEditMarkupFlat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemSpinEditSupplierCommFlat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemSpinEditRetailMarkupFlat)).BeginInit();
            this.xtraTabPageSupplierCategories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl8)).BeginInit();
            this.panelControl8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlSupplierCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSupplierCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCustomSearchLookUpEditMappingCat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlSupplements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceSupplements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSupplement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemSearchLookUpEditCompCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit3View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemImageComboBoxSupplementType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditSupplementQtySelectable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditSupplementIsBoard.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditSupplementPaySupplier.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditIsSupplement.Properties)).BeginInit();
            this.xtraTabPageRelatedProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl9)).BeginInit();
            this.panelControl9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlRelatedProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceRelatedProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewRelatedProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemComboBoxType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemSearchLookUpEditRelatedProductCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemDateEditSvcStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemDateEditSvcStart.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.default_TimeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditOperator.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditLanguage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditDifficulty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceIdName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditServiceType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComProd2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlStatus)).BeginInit();
            this.PanelControlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelCode
            // 
            LabelCode.AutoSize = true;
            LabelCode.Location = new System.Drawing.Point(12, 15);
            LabelCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelCode.Name = "LabelCode";
            LabelCode.Size = new System.Drawing.Size(32, 13);
            LabelCode.TabIndex = 0;
            LabelCode.Text = "Code";
            // 
            // LabelRateBasis
            // 
            LabelRateBasis.AutoSize = true;
            LabelRateBasis.Location = new System.Drawing.Point(54, 27);
            LabelRateBasis.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelRateBasis.Name = "LabelRateBasis";
            LabelRateBasis.Size = new System.Drawing.Size(57, 13);
            LabelRateBasis.TabIndex = 0;
            LabelRateBasis.Text = "Rate Basis";
            // 
            // LabelRestrictions
            // 
            LabelRestrictions.AutoSize = true;
            LabelRestrictions.Location = new System.Drawing.Point(410, 94);
            LabelRestrictions.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelRestrictions.Name = "LabelRestrictions";
            LabelRestrictions.Size = new System.Drawing.Size(63, 13);
            LabelRestrictions.TabIndex = 0;
            LabelRestrictions.Text = "Restrictions";
            // 
            // LabelVendorCode
            // 
            LabelVendorCode.AutoSize = true;
            LabelVendorCode.Location = new System.Drawing.Point(54, 204);
            LabelVendorCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelVendorCode.Name = "LabelVendorCode";
            LabelVendorCode.Size = new System.Drawing.Size(69, 13);
            LabelVendorCode.TabIndex = 0;
            LabelVendorCode.Text = "Vendor Code";
            // 
            // LabelOperator
            // 
            LabelOperator.AutoSize = true;
            LabelOperator.Location = new System.Drawing.Point(12, 93);
            LabelOperator.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelOperator.Name = "LabelOperator";
            LabelOperator.Size = new System.Drawing.Size(51, 13);
            LabelOperator.TabIndex = 0;
            LabelOperator.Text = "Operator";
            // 
            // LabelName
            // 
            LabelName.AutoSize = true;
            LabelName.Location = new System.Drawing.Point(12, 42);
            LabelName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelName.Name = "LabelName";
            LabelName.Size = new System.Drawing.Size(34, 13);
            LabelName.TabIndex = 0;
            LabelName.Text = "Name";
            // 
            // language_CodeLabel
            // 
            language_CodeLabel.AutoSize = true;
            language_CodeLabel.Location = new System.Drawing.Point(12, 119);
            language_CodeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            language_CodeLabel.Name = "language_CodeLabel";
            language_CodeLabel.Size = new System.Drawing.Size(54, 13);
            language_CodeLabel.TabIndex = 36;
            language_CodeLabel.Text = "Language";
            // 
            // difficultyLabel
            // 
            difficultyLabel.AutoSize = true;
            difficultyLabel.Location = new System.Drawing.Point(313, 119);
            difficultyLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            difficultyLabel.Name = "difficultyLabel";
            difficultyLabel.Size = new System.Drawing.Size(49, 13);
            difficultyLabel.TabIndex = 37;
            difficultyLabel.Text = "Difficulty";
            // 
            // LabelAgency
            // 
            LabelAgency.AutoSize = true;
            LabelAgency.Location = new System.Drawing.Point(136, 13);
            LabelAgency.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelAgency.Name = "LabelAgency";
            LabelAgency.Size = new System.Drawing.Size(43, 13);
            LabelAgency.TabIndex = 38;
            LabelAgency.Text = "Agency";
            // 
            // LabelDate
            // 
            LabelDate.AutoSize = true;
            LabelDate.Location = new System.Drawing.Point(446, 13);
            LabelDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelDate.Name = "LabelDate";
            LabelDate.Size = new System.Drawing.Size(30, 13);
            LabelDate.TabIndex = 39;
            LabelDate.Text = "Date";
            // 
            // LabelTransferType
            // 
            LabelTransferType.AutoSize = true;
            LabelTransferType.Location = new System.Drawing.Point(54, 53);
            LabelTransferType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelTransferType.Name = "LabelTransferType";
            LabelTransferType.Size = new System.Drawing.Size(75, 13);
            LabelTransferType.TabIndex = 0;
            LabelTransferType.Text = "Transfer Type";
            // 
            // LabelDefaultTime
            // 
            LabelDefaultTime.AutoSize = true;
            LabelDefaultTime.Location = new System.Drawing.Point(168, 100);
            LabelDefaultTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelDefaultTime.Name = "LabelDefaultTime";
            LabelDefaultTime.Size = new System.Drawing.Size(67, 13);
            LabelDefaultTime.TabIndex = 0;
            LabelDefaultTime.Text = "Default Time";
            // 
            // LabelVoucheringDaysPrior
            // 
            LabelVoucheringDaysPrior.AutoSize = true;
            LabelVoucheringDaysPrior.Location = new System.Drawing.Point(54, 128);
            LabelVoucheringDaysPrior.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelVoucheringDaysPrior.Name = "LabelVoucheringDaysPrior";
            LabelVoucheringDaysPrior.Size = new System.Drawing.Size(128, 13);
            LabelVoucheringDaysPrior.TabIndex = 0;
            LabelVoucheringDaysPrior.Text = "Vouchering:     Days Prior";
            // 
            // LabelMinDuration
            // 
            LabelMinDuration.AutoSize = true;
            LabelMinDuration.Location = new System.Drawing.Point(356, 101);
            LabelMinDuration.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelMinDuration.Name = "LabelMinDuration";
            LabelMinDuration.Size = new System.Drawing.Size(119, 13);
            LabelMinDuration.TabIndex = 37;
            LabelMinDuration.Text = "Min Duration (minutes):";
            // 
            // LabelAPNumber
            // 
            LabelAPNumber.AutoSize = true;
            LabelAPNumber.Location = new System.Drawing.Point(54, 178);
            LabelAPNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelAPNumber.Name = "LabelAPNumber";
            LabelAPNumber.Size = new System.Drawing.Size(64, 13);
            LabelAPNumber.TabIndex = 107;
            LabelAPNumber.Text = "A/P Number";
            // 
            // LabelARNumber
            // 
            LabelARNumber.AutoSize = true;
            LabelARNumber.Location = new System.Drawing.Point(230, 178);
            LabelARNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelARNumber.Name = "LabelARNumber";
            LabelARNumber.Size = new System.Drawing.Size(65, 13);
            LabelARNumber.TabIndex = 108;
            LabelARNumber.Text = "A/R Number";
            // 
            // LabelDueDays
            // 
            LabelDueDays.AutoSize = true;
            LabelDueDays.Location = new System.Drawing.Point(426, 178);
            LabelDueDays.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelDueDays.Name = "LabelDueDays";
            LabelDueDays.Size = new System.Drawing.Size(69, 13);
            LabelDueDays.TabIndex = 109;
            LabelDueDays.Text = "AP Due Days";
            // 
            // LabelStreet
            // 
            LabelStreet.AutoSize = true;
            LabelStreet.Location = new System.Drawing.Point(67, 27);
            LabelStreet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelStreet.Name = "LabelStreet";
            LabelStreet.Size = new System.Drawing.Size(37, 13);
            LabelStreet.TabIndex = 0;
            LabelStreet.Text = "Street";
            // 
            // LabelMilesTo
            // 
            LabelMilesTo.AutoSize = true;
            LabelMilesTo.Location = new System.Drawing.Point(730, 37);
            LabelMilesTo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelMilesTo.Name = "LabelMilesTo";
            LabelMilesTo.Size = new System.Drawing.Size(43, 13);
            LabelMilesTo.TabIndex = 0;
            LabelMilesTo.Text = "Miles to";
            // 
            // LabelCityMilesTo
            // 
            LabelCityMilesTo.AutoSize = true;
            LabelCityMilesTo.Location = new System.Drawing.Point(730, 101);
            LabelCityMilesTo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelCityMilesTo.Name = "LabelCityMilesTo";
            LabelCityMilesTo.Size = new System.Drawing.Size(43, 13);
            LabelCityMilesTo.TabIndex = 0;
            LabelCityMilesTo.Text = "Miles to";
            // 
            // LabelLong
            // 
            LabelLong.AutoSize = true;
            LabelLong.Location = new System.Drawing.Point(149, 376);
            LabelLong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelLong.Name = "LabelLong";
            LabelLong.Size = new System.Drawing.Size(58, 13);
            LabelLong.TabIndex = 274;
            LabelLong.Text = "Longitude:";
            // 
            // LabelLat
            // 
            LabelLat.AutoSize = true;
            LabelLat.Location = new System.Drawing.Point(149, 362);
            LabelLat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelLat.Name = "LabelLat";
            LabelLat.Size = new System.Drawing.Size(50, 13);
            LabelLat.TabIndex = 275;
            LabelLat.Text = "Latitude:";
            // 
            // LabelMaxDuration
            // 
            LabelMaxDuration.AutoSize = true;
            LabelMaxDuration.Location = new System.Drawing.Point(598, 101);
            LabelMaxDuration.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelMaxDuration.Name = "LabelMaxDuration";
            LabelMaxDuration.Size = new System.Drawing.Size(123, 13);
            LabelMaxDuration.TabIndex = 113;
            LabelMaxDuration.Text = "Max Duration (minutes):";
            // 
            // LabelRanking
            // 
            LabelRanking.AutoSize = true;
            LabelRanking.Location = new System.Drawing.Point(171, 231);
            LabelRanking.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelRanking.Name = "LabelRanking";
            LabelRanking.Size = new System.Drawing.Size(45, 13);
            LabelRanking.TabIndex = 117;
            LabelRanking.Text = "Ranking";
            // 
            // LabelRating
            // 
            LabelRating.AutoSize = true;
            LabelRating.Location = new System.Drawing.Point(327, 232);
            LabelRating.Name = "LabelRating";
            LabelRating.Size = new System.Drawing.Size(38, 13);
            LabelRating.TabIndex = 123;
            LabelRating.Text = "Rating";
            // 
            // LabelUserReviews
            // 
            LabelUserReviews.AutoSize = true;
            LabelUserReviews.Location = new System.Drawing.Point(482, 231);
            LabelUserReviews.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelUserReviews.Name = "LabelUserReviews";
            LabelUserReviews.Size = new System.Drawing.Size(47, 13);
            LabelUserReviews.TabIndex = 125;
            LabelUserReviews.Text = "Reviews";
            // 
            // LabelVoucherTypes
            // 
            LabelVoucherTypes.AutoSize = true;
            LabelVoucherTypes.Location = new System.Drawing.Point(250, 203);
            LabelVoucherTypes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelVoucherTypes.Name = "LabelVoucherTypes";
            LabelVoucherTypes.Size = new System.Drawing.Size(78, 13);
            LabelVoucherTypes.TabIndex = 128;
            LabelVoucherTypes.Text = "Voucher Types";
            // 
            // LabelStartingCost
            // 
            LabelStartingCost.AutoSize = true;
            LabelStartingCost.Location = new System.Drawing.Point(54, 284);
            LabelStartingCost.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelStartingCost.Name = "LabelStartingCost";
            LabelStartingCost.Size = new System.Drawing.Size(70, 13);
            LabelStartingCost.TabIndex = 132;
            LabelStartingCost.Text = "Starting Cost";
            // 
            // LabelStartingPrice
            // 
            LabelStartingPrice.AutoSize = true;
            LabelStartingPrice.Location = new System.Drawing.Point(236, 285);
            LabelStartingPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelStartingPrice.Name = "LabelStartingPrice";
            LabelStartingPrice.Size = new System.Drawing.Size(71, 13);
            LabelStartingPrice.TabIndex = 134;
            LabelStartingPrice.Text = "Starting Price";
            // 
            // LabelStartingComparison
            // 
            LabelStartingComparison.AutoSize = true;
            LabelStartingComparison.Location = new System.Drawing.Point(419, 284);
            LabelStartingComparison.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelStartingComparison.Name = "LabelStartingComparison";
            LabelStartingComparison.Size = new System.Drawing.Size(104, 13);
            LabelStartingComparison.TabIndex = 136;
            LabelStartingComparison.Text = "Starting Comparison";
            // 
            // LabelStartingAgentNet
            // 
            LabelStartingAgentNet.AutoSize = true;
            LabelStartingAgentNet.Location = new System.Drawing.Point(610, 286);
            LabelStartingAgentNet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelStartingAgentNet.Name = "LabelStartingAgentNet";
            LabelStartingAgentNet.Size = new System.Drawing.Size(97, 13);
            LabelStartingAgentNet.TabIndex = 138;
            LabelStartingAgentNet.Text = "Starting Agent Net";
            // 
            // LabelMaxPax
            // 
            LabelMaxPax.AutoSize = true;
            LabelMaxPax.Location = new System.Drawing.Point(54, 310);
            LabelMaxPax.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelMaxPax.Name = "LabelMaxPax";
            LabelMaxPax.Size = new System.Drawing.Size(85, 13);
            LabelMaxPax.TabIndex = 140;
            LabelMaxPax.Text = "Max Passengers";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(236, 311);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(95, 13);
            label2.TabIndex = 142;
            label2.Text = "Confirmation Type";
            // 
            // LabelOnRequestPeriod
            // 
            LabelOnRequestPeriod.AutoSize = true;
            LabelOnRequestPeriod.Location = new System.Drawing.Point(510, 311);
            LabelOnRequestPeriod.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelOnRequestPeriod.Name = "LabelOnRequestPeriod";
            LabelOnRequestPeriod.Size = new System.Drawing.Size(97, 13);
            LabelOnRequestPeriod.TabIndex = 144;
            LabelOnRequestPeriod.Text = "On Request Period";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(72, 278);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(40, 13);
            label1.TabIndex = 283;
            label1.Text = "Region";
            // 
            // ImageComboBoxEditRestrictionsCode
            // 
            this.ImageComboBoxEditRestrictionsCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "RSTR_CDE", true));
            this.ImageComboBoxEditRestrictionsCode.EnterMoveNextControl = true;
            this.ImageComboBoxEditRestrictionsCode.Location = new System.Drawing.Point(480, 90);
            this.ImageComboBoxEditRestrictionsCode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ImageComboBoxEditRestrictionsCode.Name = "ImageComboBoxEditRestrictionsCode";
            this.ImageComboBoxEditRestrictionsCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ImageComboBoxEditRestrictionsCode.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Open", "O", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("House", "H", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Agency", "A", -1)});
            this.ImageComboBoxEditRestrictionsCode.Size = new System.Drawing.Size(155, 20);
            this.ImageComboBoxEditRestrictionsCode.TabIndex = 6;
            this.ImageComboBoxEditRestrictionsCode.Leave += new System.EventHandler(this.ImageComboBoxEditRestrictionsCode_Leave);
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(FlexModel.COMP);
            this.BindingSource.CurrentChanged += new System.EventHandler(this.BindingSource_CurrentChanged);
            // 
            // ImageComboBoxEditRateBasis
            // 
            this.ImageComboBoxEditRateBasis.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "RATE_BASIS", true));
            this.ImageComboBoxEditRateBasis.EnterMoveNextControl = true;
            this.ImageComboBoxEditRateBasis.Location = new System.Drawing.Point(150, 23);
            this.ImageComboBoxEditRateBasis.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ImageComboBoxEditRateBasis.Name = "ImageComboBoxEditRateBasis";
            this.ImageComboBoxEditRateBasis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ImageComboBoxEditRateBasis.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Daily", "D", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Arrival", "A", -1)});
            this.ImageComboBoxEditRateBasis.Size = new System.Drawing.Size(155, 20);
            this.ImageComboBoxEditRateBasis.TabIndex = 5;
            this.ImageComboBoxEditRateBasis.Leave += new System.EventHandler(this.ImageComboBoxEditRateBasis_Leave);
            // 
            // labelControlUpdBy
            // 
            this.labelControlUpdBy.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "UPD_INIT", true));
            this.labelControlUpdBy.Location = new System.Drawing.Point(497, 15);
            this.labelControlUpdBy.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControlUpdBy.Name = "labelControlUpdBy";
            this.labelControlUpdBy.Size = new System.Drawing.Size(3, 13);
            this.labelControlUpdBy.TabIndex = 0;
            this.labelControlUpdBy.Text = " ";
            // 
            // labelControl17
            // 
            this.labelControl17.Location = new System.Drawing.Point(475, 15);
            this.labelControl17.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(16, 13);
            this.labelControl17.TabIndex = 0;
            this.labelControl17.Text = "By:";
            // 
            // labelControlLastUpd
            // 
            this.labelControlLastUpd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "LAST_UPD", true));
            this.labelControlLastUpd.Location = new System.Drawing.Point(377, 15);
            this.labelControlLastUpd.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControlLastUpd.Name = "labelControlLastUpd";
            this.labelControlLastUpd.Size = new System.Drawing.Size(3, 13);
            this.labelControlLastUpd.TabIndex = 0;
            this.labelControlLastUpd.Text = " ";
            // 
            // LabelLastUpdated
            // 
            this.LabelLastUpdated.Location = new System.Drawing.Point(304, 15);
            this.LabelLastUpdated.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LabelLastUpdated.Name = "LabelLastUpdated";
            this.LabelLastUpdated.Size = new System.Drawing.Size(67, 13);
            this.LabelLastUpdated.TabIndex = 0;
            this.LabelLastUpdated.Text = "Last updated:";
            this.BingMapDataProvider.BingKey = "ArYMvmMLXeYiBI4-c2wJpjLIpm6FIRez7llCbbZPJDoIBXiO9m8pf5H_oiZPEBrR";
            this.BingMapDataProvider.Kind = DevExpress.XtraMap.BingMapKind.Road;
            this.BingSearchDataProvider.BingKey = "ArYMvmMLXeYiBI4-c2wJpjLIpm6FIRez7llCbbZPJDoIBXiO9m8pf5H_oiZPEBrR";
            this.BingSearchDataProvider.GenerateLayerItems = false;
            // 
            // BindingSourceCompBusRoutes
            // 
            this.BindingSourceCompBusRoutes.DataSource = typeof(FlexModel.CompBusRoute);
            // 
            // BindingSourceBusRoutes
            // 
            this.BindingSourceBusRoutes.AllowNew = false;
            this.BindingSourceBusRoutes.DataSource = typeof(FlexModel.BusRoute);
            // 
            // BindingSourceBusRouteStop
            // 
            this.BindingSourceBusRouteStop.DataSource = typeof(FlexModel.BusRouteStop);
            // 
            // BindingSourceBusTable
            // 
            this.BindingSourceBusTable.DataSource = typeof(FlexModel.BUSTABLE);
            // 
            // BindingSourceCodeName
            // 
            this.BindingSourceCodeName.DataSource = typeof(TraceForms.CodeName);
            // 
            // BindingSourceDetail
            // 
            this.BindingSourceDetail.DataSource = typeof(FlexModel.DETAIL);
            // 
            // BindingSourceUserFields
            // 
            this.BindingSourceUserFields.DataSource = typeof(FlexModel.USERFIELDS);
            // 
            // BindingSourceSupplierProduct
            // 
            this.BindingSourceSupplierProduct.AllowNew = false;
            this.BindingSourceSupplierProduct.DataSource = typeof(FlexModel.SupplierProduct);
            // 
            // BindingSourceSupplierCategory
            // 
            this.BindingSourceSupplierCategory.DataSource = typeof(FlexModel.SupplierCategory);
            // 
            // CheckEditInactive
            // 
            this.CheckEditInactive.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Inactive", true));
            this.CheckEditInactive.EnterMoveNextControl = true;
            this.CheckEditInactive.Location = new System.Drawing.Point(394, 64);
            this.CheckEditInactive.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CheckEditInactive.Name = "CheckEditInactive";
            this.CheckEditInactive.Properties.Caption = "Inactive";
            this.CheckEditInactive.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditInactive.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.CheckEditInactive.Properties.Tag = 'N';
            this.CheckEditInactive.Properties.ValueChecked = "Y";
            this.CheckEditInactive.Properties.ValueGrayed = 'N';
            this.CheckEditInactive.Properties.ValueUnchecked = "N";
            this.CheckEditInactive.Size = new System.Drawing.Size(68, 19);
            this.CheckEditInactive.TabIndex = 7;
            // 
            // TextEditVendorCode
            // 
            this.TextEditVendorCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Vendor_Code", true));
            this.TextEditVendorCode.EnterMoveNextControl = true;
            this.TextEditVendorCode.Location = new System.Drawing.Point(135, 201);
            this.TextEditVendorCode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TextEditVendorCode.Name = "TextEditVendorCode";
            this.TextEditVendorCode.Properties.MaxLength = 12;
            this.TextEditVendorCode.Size = new System.Drawing.Size(100, 20);
            this.TextEditVendorCode.TabIndex = 4;
            this.TextEditVendorCode.Leave += new System.EventHandler(this.TextEditVendorCode_Leave);
            // 
            // TextEditName
            // 
            this.TextEditName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "NAME", true));
            this.TextEditName.EnterMoveNextControl = true;
            this.TextEditName.Location = new System.Drawing.Point(86, 38);
            this.TextEditName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TextEditName.Name = "TextEditName";
            this.TextEditName.Properties.MaxLength = 60;
            this.TextEditName.Size = new System.Drawing.Size(404, 20);
            this.TextEditName.TabIndex = 2;
            this.TextEditName.Leave += new System.EventHandler(this.TextEditName_Leave);
            // 
            // GridControlLookup
            // 
            this.GridControlLookup.DataSource = this.EntityInstantFeedbackSource;
            this.GridControlLookup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControlLookup.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GridControlLookup.Location = new System.Drawing.Point(0, 0);
            this.GridControlLookup.MainView = this.GridViewLookup;
            this.GridControlLookup.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GridControlLookup.Name = "GridControlLookup";
            this.GridControlLookup.Size = new System.Drawing.Size(184, 620);
            this.GridControlLookup.TabIndex = 0;
            this.GridControlLookup.TabStop = false;
            this.GridControlLookup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewLookup});
            // 
            // EntityInstantFeedbackSource
            // 
            this.EntityInstantFeedbackSource.DesignTimeElementType = typeof(FlexModel.COMP);
            this.EntityInstantFeedbackSource.KeyExpression = "CODE";
            this.EntityInstantFeedbackSource.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.EntityInstantFeedbackSource_GetQueryable);
            this.EntityInstantFeedbackSource.DismissQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.EntityInstantFeedbackSource_DismissQueryable);
            // 
            // GridViewLookup
            // 
            this.GridViewLookup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDisplayName1,
            this.ColumnCode,
            this.ColumnName,
            this.colLAST_UPD1,
            this.ColumnUpdInit1,
            this.ColumnAP,
            this.ColumnAR,
            this.ColumnCity,
            this.ColumnOper,
            this.ColumnIncl1,
            this.ColumnIncl2,
            this.ColumnIncl3,
            this.colINCL4,
            this.colINCL5,
            this.colINCL6,
            this.ColumnRateBasis,
            this.ColumnRstr_Cde,
            this.ColumnTransferType,
            this.ColumnServiceList,
            this.colPUDRP_REQ,
            this.ColumnService_Type,
            this.ColumnUseClientLogo,
            this.ColumnVouchDaysPrior,
            this.ColumnLatitude,
            this.ColumnLongitude,
            this.ColumnUserDec1,
            this.ColumnUserDec2,
            this.ColumnUserInt1,
            this.ColumnUserInt2,
            this.ColumnUserTxt1,
            this.ColumnUserTxt2,
            this.ColumnUserTxt3,
            this.ColumnUserTxt4,
            this.ColumnUserDte1,
            this.ColumnUserDte2,
            this.ColumnState,
            this.ColumnZip,
            this.ColumnTown,
            this.ColumnGMACCTNO,
            this.ColumnAddr1,
            this.ColumnAddr2,
            this.ColumnAddr3,
            this.ColumnCountry,
            this.ColCityMiles,
            this.ColumnAirport,
            this.ColumnAirportMiles,
            this.colMultiple_Times,
            this.colDefault_Time,
            this.colTransfer_List,
            this.colRequire_ArvInfo,
            this.ColumnRequiredDepInfo,
            this.ColumnAllowFreesell,
            this.colInactive1,
            this.ColumnVendorCode,
            this.colDue_Days,
            this.colLanguage_Code,
            this.ColumnType1,
            this.colGeoCode_ID,
            this.colDifficulty,
            this.ColumnMealsIncluded,
            this.colDuration,
            this.ColumnAdmin,
            this.ColumnUnit_Rate,
            this.ColumnAirport1,
            this.ColumnCityCod,
            this.ColumnCountry1,
            this.ColumnLanguage,
            this.ColumnOperator,
            this.ColumnSERVTYPE,
            this.colCPRATES,
            this.ColumnServRestr});
            this.GridViewLookup.DetailHeight = 182;
            this.GridViewLookup.FixedLineWidth = 1;
            this.GridViewLookup.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.GridViewLookup.GridControl = this.GridControlLookup;
            this.GridViewLookup.LevelIndent = 0;
            this.GridViewLookup.Name = "GridViewLookup";
            this.GridViewLookup.OptionsBehavior.Editable = false;
            this.GridViewLookup.OptionsView.ShowAutoFilterRow = true;
            this.GridViewLookup.OptionsView.ShowGroupPanel = false;
            this.GridViewLookup.OptionsView.ShowIndicator = false;
            this.GridViewLookup.PreviewIndent = 0;
            this.GridViewLookup.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewLookup_FocusedRowChanged);
            this.GridViewLookup.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.GridViewComponentss_InvalidRowException);
            this.GridViewLookup.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.GridViewLookup_BeforeLeaveRow);
            // 
            // colDisplayName1
            // 
            this.colDisplayName1.FieldName = "DisplayName";
            this.colDisplayName1.MinWidth = 10;
            this.colDisplayName1.Name = "colDisplayName1";
            this.colDisplayName1.OptionsColumn.ReadOnly = true;
            this.colDisplayName1.Width = 37;
            // 
            // ColumnCode
            // 
            this.ColumnCode.FieldName = "CODE";
            this.ColumnCode.MinWidth = 10;
            this.ColumnCode.Name = "ColumnCode";
            this.ColumnCode.Visible = true;
            this.ColumnCode.VisibleIndex = 0;
            this.ColumnCode.Width = 37;
            // 
            // ColumnName
            // 
            this.ColumnName.FieldName = "NAME";
            this.ColumnName.MinWidth = 10;
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Visible = true;
            this.ColumnName.VisibleIndex = 1;
            this.ColumnName.Width = 37;
            // 
            // colLAST_UPD1
            // 
            this.colLAST_UPD1.FieldName = "LAST_UPD";
            this.colLAST_UPD1.MinWidth = 10;
            this.colLAST_UPD1.Name = "colLAST_UPD1";
            this.colLAST_UPD1.Width = 37;
            // 
            // ColumnUpdInit1
            // 
            this.ColumnUpdInit1.FieldName = "UPD_INIT";
            this.ColumnUpdInit1.MinWidth = 10;
            this.ColumnUpdInit1.Name = "ColumnUpdInit1";
            this.ColumnUpdInit1.Width = 37;
            // 
            // ColumnAP
            // 
            this.ColumnAP.FieldName = "AP";
            this.ColumnAP.MinWidth = 10;
            this.ColumnAP.Name = "ColumnAP";
            this.ColumnAP.Width = 37;
            // 
            // ColumnAR
            // 
            this.ColumnAR.FieldName = "AR";
            this.ColumnAR.MinWidth = 10;
            this.ColumnAR.Name = "ColumnAR";
            this.ColumnAR.Width = 37;
            // 
            // ColumnCity
            // 
            this.ColumnCity.FieldName = "CITY";
            this.ColumnCity.MinWidth = 10;
            this.ColumnCity.Name = "ColumnCity";
            this.ColumnCity.Width = 37;
            // 
            // ColumnOper
            // 
            this.ColumnOper.FieldName = "OPER";
            this.ColumnOper.MinWidth = 10;
            this.ColumnOper.Name = "ColumnOper";
            this.ColumnOper.Width = 37;
            // 
            // ColumnIncl1
            // 
            this.ColumnIncl1.FieldName = "INCL1";
            this.ColumnIncl1.MinWidth = 10;
            this.ColumnIncl1.Name = "ColumnIncl1";
            this.ColumnIncl1.Width = 37;
            // 
            // ColumnIncl2
            // 
            this.ColumnIncl2.FieldName = "INCL2";
            this.ColumnIncl2.MinWidth = 10;
            this.ColumnIncl2.Name = "ColumnIncl2";
            this.ColumnIncl2.Width = 37;
            // 
            // ColumnIncl3
            // 
            this.ColumnIncl3.FieldName = "INCL3";
            this.ColumnIncl3.MinWidth = 10;
            this.ColumnIncl3.Name = "ColumnIncl3";
            this.ColumnIncl3.Width = 37;
            // 
            // colINCL4
            // 
            this.colINCL4.FieldName = "INCL4";
            this.colINCL4.MinWidth = 10;
            this.colINCL4.Name = "colINCL4";
            this.colINCL4.Width = 37;
            // 
            // colINCL5
            // 
            this.colINCL5.FieldName = "INCL5";
            this.colINCL5.MinWidth = 10;
            this.colINCL5.Name = "colINCL5";
            this.colINCL5.Width = 37;
            // 
            // colINCL6
            // 
            this.colINCL6.FieldName = "INCL6";
            this.colINCL6.MinWidth = 10;
            this.colINCL6.Name = "colINCL6";
            this.colINCL6.Width = 37;
            // 
            // ColumnRateBasis
            // 
            this.ColumnRateBasis.FieldName = "RATE_BASIS";
            this.ColumnRateBasis.MinWidth = 10;
            this.ColumnRateBasis.Name = "ColumnRateBasis";
            this.ColumnRateBasis.Width = 37;
            // 
            // ColumnRstr_Cde
            // 
            this.ColumnRstr_Cde.FieldName = "RSTR_CDE";
            this.ColumnRstr_Cde.MinWidth = 10;
            this.ColumnRstr_Cde.Name = "ColumnRstr_Cde";
            this.ColumnRstr_Cde.Width = 37;
            // 
            // ColumnTransferType
            // 
            this.ColumnTransferType.FieldName = "TRSFR_TYP";
            this.ColumnTransferType.MinWidth = 10;
            this.ColumnTransferType.Name = "ColumnTransferType";
            this.ColumnTransferType.Width = 37;
            // 
            // ColumnServiceList
            // 
            this.ColumnServiceList.FieldName = "SVC_LIST";
            this.ColumnServiceList.MinWidth = 10;
            this.ColumnServiceList.Name = "ColumnServiceList";
            this.ColumnServiceList.Width = 37;
            // 
            // colPUDRP_REQ
            // 
            this.colPUDRP_REQ.FieldName = "PUDRP_REQ";
            this.colPUDRP_REQ.MinWidth = 10;
            this.colPUDRP_REQ.Name = "colPUDRP_REQ";
            this.colPUDRP_REQ.Width = 37;
            // 
            // ColumnService_Type
            // 
            this.ColumnService_Type.FieldName = "SERV_TYPE";
            this.ColumnService_Type.MinWidth = 10;
            this.ColumnService_Type.Name = "ColumnService_Type";
            this.ColumnService_Type.Width = 37;
            // 
            // ColumnUseClientLogo
            // 
            this.ColumnUseClientLogo.FieldName = "USE_CLIENT_LOGO";
            this.ColumnUseClientLogo.MinWidth = 10;
            this.ColumnUseClientLogo.Name = "ColumnUseClientLogo";
            this.ColumnUseClientLogo.Width = 37;
            // 
            // ColumnVouchDaysPrior
            // 
            this.ColumnVouchDaysPrior.FieldName = "VOUCH_DAYS_PRIOR";
            this.ColumnVouchDaysPrior.MinWidth = 10;
            this.ColumnVouchDaysPrior.Name = "ColumnVouchDaysPrior";
            this.ColumnVouchDaysPrior.Width = 37;
            // 
            // ColumnLatitude
            // 
            this.ColumnLatitude.FieldName = "LATITUDE";
            this.ColumnLatitude.MinWidth = 10;
            this.ColumnLatitude.Name = "ColumnLatitude";
            this.ColumnLatitude.Width = 37;
            // 
            // ColumnLongitude
            // 
            this.ColumnLongitude.FieldName = "LONGITUDE";
            this.ColumnLongitude.MinWidth = 10;
            this.ColumnLongitude.Name = "ColumnLongitude";
            this.ColumnLongitude.Width = 37;
            // 
            // ColumnUserDec1
            // 
            this.ColumnUserDec1.FieldName = "USER_DEC1";
            this.ColumnUserDec1.MinWidth = 10;
            this.ColumnUserDec1.Name = "ColumnUserDec1";
            this.ColumnUserDec1.Width = 37;
            // 
            // ColumnUserDec2
            // 
            this.ColumnUserDec2.FieldName = "USER_DEC2";
            this.ColumnUserDec2.MinWidth = 10;
            this.ColumnUserDec2.Name = "ColumnUserDec2";
            this.ColumnUserDec2.Width = 37;
            // 
            // ColumnUserInt1
            // 
            this.ColumnUserInt1.FieldName = "USER_INT1";
            this.ColumnUserInt1.MinWidth = 10;
            this.ColumnUserInt1.Name = "ColumnUserInt1";
            this.ColumnUserInt1.Width = 37;
            // 
            // ColumnUserInt2
            // 
            this.ColumnUserInt2.FieldName = "USER_INT2";
            this.ColumnUserInt2.MinWidth = 10;
            this.ColumnUserInt2.Name = "ColumnUserInt2";
            this.ColumnUserInt2.Width = 37;
            // 
            // ColumnUserTxt1
            // 
            this.ColumnUserTxt1.FieldName = "USER_TXT1";
            this.ColumnUserTxt1.MinWidth = 10;
            this.ColumnUserTxt1.Name = "ColumnUserTxt1";
            this.ColumnUserTxt1.Width = 37;
            // 
            // ColumnUserTxt2
            // 
            this.ColumnUserTxt2.FieldName = "USER_TXT2";
            this.ColumnUserTxt2.MinWidth = 10;
            this.ColumnUserTxt2.Name = "ColumnUserTxt2";
            this.ColumnUserTxt2.Width = 37;
            // 
            // ColumnUserTxt3
            // 
            this.ColumnUserTxt3.FieldName = "USER_TXT3";
            this.ColumnUserTxt3.MinWidth = 10;
            this.ColumnUserTxt3.Name = "ColumnUserTxt3";
            this.ColumnUserTxt3.Width = 37;
            // 
            // ColumnUserTxt4
            // 
            this.ColumnUserTxt4.FieldName = "USER_TXT4";
            this.ColumnUserTxt4.MinWidth = 10;
            this.ColumnUserTxt4.Name = "ColumnUserTxt4";
            this.ColumnUserTxt4.Width = 37;
            // 
            // ColumnUserDte1
            // 
            this.ColumnUserDte1.FieldName = "USER_DTE1";
            this.ColumnUserDte1.MinWidth = 10;
            this.ColumnUserDte1.Name = "ColumnUserDte1";
            this.ColumnUserDte1.Width = 37;
            // 
            // ColumnUserDte2
            // 
            this.ColumnUserDte2.FieldName = "USER_DTE2";
            this.ColumnUserDte2.MinWidth = 10;
            this.ColumnUserDte2.Name = "ColumnUserDte2";
            this.ColumnUserDte2.Width = 37;
            // 
            // ColumnState
            // 
            this.ColumnState.FieldName = "STATE";
            this.ColumnState.MinWidth = 10;
            this.ColumnState.Name = "ColumnState";
            this.ColumnState.Width = 37;
            // 
            // ColumnZip
            // 
            this.ColumnZip.FieldName = "ZIP";
            this.ColumnZip.MinWidth = 10;
            this.ColumnZip.Name = "ColumnZip";
            this.ColumnZip.Width = 37;
            // 
            // ColumnTown
            // 
            this.ColumnTown.FieldName = "TOWN";
            this.ColumnTown.MinWidth = 10;
            this.ColumnTown.Name = "ColumnTown";
            this.ColumnTown.Width = 37;
            // 
            // ColumnGMACCTNO
            // 
            this.ColumnGMACCTNO.FieldName = "GMACCTNO";
            this.ColumnGMACCTNO.MinWidth = 10;
            this.ColumnGMACCTNO.Name = "ColumnGMACCTNO";
            this.ColumnGMACCTNO.Width = 37;
            // 
            // ColumnAddr1
            // 
            this.ColumnAddr1.FieldName = "ADDR1";
            this.ColumnAddr1.MinWidth = 10;
            this.ColumnAddr1.Name = "ColumnAddr1";
            this.ColumnAddr1.Width = 37;
            // 
            // ColumnAddr2
            // 
            this.ColumnAddr2.FieldName = "ADDR2";
            this.ColumnAddr2.MinWidth = 10;
            this.ColumnAddr2.Name = "ColumnAddr2";
            this.ColumnAddr2.Width = 37;
            // 
            // ColumnAddr3
            // 
            this.ColumnAddr3.FieldName = "ADDR3";
            this.ColumnAddr3.MinWidth = 10;
            this.ColumnAddr3.Name = "ColumnAddr3";
            this.ColumnAddr3.Width = 37;
            // 
            // ColumnCountry
            // 
            this.ColumnCountry.FieldName = "COUNTRY";
            this.ColumnCountry.MinWidth = 10;
            this.ColumnCountry.Name = "ColumnCountry";
            this.ColumnCountry.Width = 37;
            // 
            // ColCityMiles
            // 
            this.ColCityMiles.FieldName = "CITY_MI";
            this.ColCityMiles.MinWidth = 10;
            this.ColCityMiles.Name = "ColCityMiles";
            this.ColCityMiles.Width = 37;
            // 
            // ColumnAirport
            // 
            this.ColumnAirport.FieldName = "AIRPORT";
            this.ColumnAirport.MinWidth = 10;
            this.ColumnAirport.Name = "ColumnAirport";
            this.ColumnAirport.Width = 37;
            // 
            // ColumnAirportMiles
            // 
            this.ColumnAirportMiles.FieldName = "AIR_MI";
            this.ColumnAirportMiles.MinWidth = 10;
            this.ColumnAirportMiles.Name = "ColumnAirportMiles";
            this.ColumnAirportMiles.Width = 37;
            // 
            // colMultiple_Times
            // 
            this.colMultiple_Times.FieldName = "Multiple_Times";
            this.colMultiple_Times.MinWidth = 10;
            this.colMultiple_Times.Name = "colMultiple_Times";
            this.colMultiple_Times.Width = 37;
            // 
            // colDefault_Time
            // 
            this.colDefault_Time.FieldName = "Default_Time";
            this.colDefault_Time.MinWidth = 10;
            this.colDefault_Time.Name = "colDefault_Time";
            this.colDefault_Time.Width = 37;
            // 
            // colTransfer_List
            // 
            this.colTransfer_List.FieldName = "Transfer_List";
            this.colTransfer_List.MinWidth = 10;
            this.colTransfer_List.Name = "colTransfer_List";
            this.colTransfer_List.Width = 37;
            // 
            // colRequire_ArvInfo
            // 
            this.colRequire_ArvInfo.FieldName = "Require_ArvInfo";
            this.colRequire_ArvInfo.MinWidth = 10;
            this.colRequire_ArvInfo.Name = "colRequire_ArvInfo";
            this.colRequire_ArvInfo.Width = 37;
            // 
            // ColumnRequiredDepInfo
            // 
            this.ColumnRequiredDepInfo.FieldName = "Require_DepInfo";
            this.ColumnRequiredDepInfo.MinWidth = 10;
            this.ColumnRequiredDepInfo.Name = "ColumnRequiredDepInfo";
            this.ColumnRequiredDepInfo.Width = 37;
            // 
            // ColumnAllowFreesell
            // 
            this.ColumnAllowFreesell.FieldName = "Allow_Freesell";
            this.ColumnAllowFreesell.MinWidth = 10;
            this.ColumnAllowFreesell.Name = "ColumnAllowFreesell";
            this.ColumnAllowFreesell.Width = 37;
            // 
            // colInactive1
            // 
            this.colInactive1.FieldName = "Inactive";
            this.colInactive1.MinWidth = 10;
            this.colInactive1.Name = "colInactive1";
            this.colInactive1.Width = 37;
            // 
            // ColumnVendorCode
            // 
            this.ColumnVendorCode.FieldName = "Vendor_Code";
            this.ColumnVendorCode.MinWidth = 10;
            this.ColumnVendorCode.Name = "ColumnVendorCode";
            this.ColumnVendorCode.Width = 37;
            // 
            // colDue_Days
            // 
            this.colDue_Days.FieldName = "Due_Days";
            this.colDue_Days.MinWidth = 10;
            this.colDue_Days.Name = "colDue_Days";
            this.colDue_Days.Width = 37;
            // 
            // colLanguage_Code
            // 
            this.colLanguage_Code.FieldName = "Language_Code";
            this.colLanguage_Code.MinWidth = 10;
            this.colLanguage_Code.Name = "colLanguage_Code";
            this.colLanguage_Code.Width = 37;
            // 
            // ColumnType1
            // 
            this.ColumnType1.FieldName = "Type";
            this.ColumnType1.MinWidth = 10;
            this.ColumnType1.Name = "ColumnType1";
            this.ColumnType1.Width = 37;
            // 
            // colGeoCode_ID
            // 
            this.colGeoCode_ID.FieldName = "GeoCode_ID";
            this.colGeoCode_ID.MinWidth = 10;
            this.colGeoCode_ID.Name = "colGeoCode_ID";
            this.colGeoCode_ID.Width = 37;
            // 
            // colDifficulty
            // 
            this.colDifficulty.FieldName = "Difficulty";
            this.colDifficulty.MinWidth = 10;
            this.colDifficulty.Name = "colDifficulty";
            this.colDifficulty.Width = 37;
            // 
            // ColumnMealsIncluded
            // 
            this.ColumnMealsIncluded.FieldName = "MealsIncluded";
            this.ColumnMealsIncluded.MinWidth = 10;
            this.ColumnMealsIncluded.Name = "ColumnMealsIncluded";
            this.ColumnMealsIncluded.Width = 37;
            // 
            // colDuration
            // 
            this.colDuration.FieldName = "Duration";
            this.colDuration.MinWidth = 10;
            this.colDuration.Name = "colDuration";
            this.colDuration.Width = 37;
            // 
            // ColumnAdmin
            // 
            this.ColumnAdmin.FieldName = "Admin";
            this.ColumnAdmin.MinWidth = 10;
            this.ColumnAdmin.Name = "ColumnAdmin";
            this.ColumnAdmin.Width = 37;
            // 
            // ColumnUnit_Rate
            // 
            this.ColumnUnit_Rate.FieldName = "Unit_Rate";
            this.ColumnUnit_Rate.MinWidth = 10;
            this.ColumnUnit_Rate.Name = "ColumnUnit_Rate";
            this.ColumnUnit_Rate.Width = 37;
            // 
            // ColumnAirport1
            // 
            this.ColumnAirport1.FieldName = "Airport1";
            this.ColumnAirport1.MinWidth = 10;
            this.ColumnAirport1.Name = "ColumnAirport1";
            this.ColumnAirport1.Width = 37;
            // 
            // ColumnCityCod
            // 
            this.ColumnCityCod.FieldName = "CITYCOD";
            this.ColumnCityCod.MinWidth = 10;
            this.ColumnCityCod.Name = "ColumnCityCod";
            this.ColumnCityCod.Width = 37;
            // 
            // ColumnCountry1
            // 
            this.ColumnCountry1.FieldName = "COUNTRY1";
            this.ColumnCountry1.MinWidth = 10;
            this.ColumnCountry1.Name = "ColumnCountry1";
            this.ColumnCountry1.Width = 37;
            // 
            // ColumnLanguage
            // 
            this.ColumnLanguage.FieldName = "LANGUAGE";
            this.ColumnLanguage.MinWidth = 10;
            this.ColumnLanguage.Name = "ColumnLanguage";
            this.ColumnLanguage.Width = 37;
            // 
            // ColumnOperator
            // 
            this.ColumnOperator.FieldName = "OPERATOR";
            this.ColumnOperator.MinWidth = 10;
            this.ColumnOperator.Name = "ColumnOperator";
            this.ColumnOperator.Width = 37;
            // 
            // ColumnSERVTYPE
            // 
            this.ColumnSERVTYPE.FieldName = "SERVTYPE";
            this.ColumnSERVTYPE.MinWidth = 10;
            this.ColumnSERVTYPE.Name = "ColumnSERVTYPE";
            this.ColumnSERVTYPE.Width = 37;
            // 
            // colCPRATES
            // 
            this.colCPRATES.FieldName = "CPRATES";
            this.colCPRATES.MinWidth = 10;
            this.colCPRATES.Name = "colCPRATES";
            this.colCPRATES.Width = 37;
            // 
            // ColumnServRestr
            // 
            this.ColumnServRestr.FieldName = "SVCRESTR";
            this.ColumnServRestr.MinWidth = 10;
            this.ColumnServRestr.Name = "ColumnServRestr";
            this.ColumnServRestr.Width = 37;
            // 
            // BindingSourceBusStation
            // 
            this.BindingSourceBusStation.DataSource = typeof(FlexModel.BusStation);
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // SplitContainerControl
            // 
            this.SplitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerControl.Location = new System.Drawing.Point(0, 31);
            this.SplitContainerControl.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SplitContainerControl.Name = "SplitContainerControl";
            this.SplitContainerControl.Panel1.AutoScroll = true;
            this.SplitContainerControl.Panel1.Controls.Add(this.GridControlLookup);
            this.SplitContainerControl.Panel1.Text = "Panel1";
            this.SplitContainerControl.Panel2.AutoScroll = true;
            this.SplitContainerControl.Panel2.Controls.Add(difficultyLabel);
            this.SplitContainerControl.Panel2.Controls.Add(language_CodeLabel);
            this.SplitContainerControl.Panel2.Controls.Add(this.TextEditCode);
            this.SplitContainerControl.Panel2.Controls.Add(this.ImageComboBoxEditRestrictionsCode);
            this.SplitContainerControl.Panel2.Controls.Add(LabelCode);
            this.SplitContainerControl.Panel2.Controls.Add(this.TextEditName);
            this.SplitContainerControl.Panel2.Controls.Add(this.labelControlUpdBy);
            this.SplitContainerControl.Panel2.Controls.Add(this.labelControl17);
            this.SplitContainerControl.Panel2.Controls.Add(this.labelControlLastUpd);
            this.SplitContainerControl.Panel2.Controls.Add(this.CheckEditInactive);
            this.SplitContainerControl.Panel2.Controls.Add(this.LabelLastUpdated);
            this.SplitContainerControl.Panel2.Controls.Add(this.xtraTabControl1);
            this.SplitContainerControl.Panel2.Controls.Add(LabelName);
            this.SplitContainerControl.Panel2.Controls.Add(LabelOperator);
            this.SplitContainerControl.Panel2.Controls.Add(LabelRestrictions);
            this.SplitContainerControl.Panel2.Controls.Add(this.default_TimeTextEdit);
            this.SplitContainerControl.Panel2.Controls.Add(this.SearchLookupEditOperator);
            this.SplitContainerControl.Panel2.Controls.Add(this.SearchLookupEditLanguage);
            this.SplitContainerControl.Panel2.Controls.Add(this.SearchLookupEditDifficulty);
            this.SplitContainerControl.Panel2.Controls.Add(this.SearchLookupEditServiceType);
            this.SplitContainerControl.Panel2.Controls.Add(this.LabelServiceType);
            this.SplitContainerControl.Panel2.Text = "Panel2";
            this.SplitContainerControl.Size = new System.Drawing.Size(1164, 620);
            this.SplitContainerControl.SplitterPosition = 184;
            this.SplitContainerControl.TabIndex = 0;
            this.SplitContainerControl.Text = "splitContainerControl1";
            // 
            // TextEditCode
            // 
            this.TextEditCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CODE", true));
            this.TextEditCode.EnterMoveNextControl = true;
            this.TextEditCode.Location = new System.Drawing.Point(86, 12);
            this.TextEditCode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TextEditCode.Name = "TextEditCode";
            this.TextEditCode.Properties.MaxLength = 12;
            this.TextEditCode.Size = new System.Drawing.Size(155, 20);
            this.TextEditCode.TabIndex = 1;
            this.TextEditCode.Leave += new System.EventHandler(this.TextEditCode_Leave);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(15, 154);
            this.xtraTabControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPageLocation;
            this.xtraTabControl1.Size = new System.Drawing.Size(908, 613);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageLocation,
            this.xtraTabPagePolicies,
            this.xtraTabPageServices,
            this.xtraTabPageRoutes,
            this.xtraTabPageTransferPoints,
            this.xtraTabPageMemberships,
            this.xtraTabPageCustom,
            this.xtraTabPageCommissions,
            this.xtraTabPageSupplierMapping,
            this.xtraTabPageSupplierCategories,
            this.xtraTabPage1,
            this.xtraTabPageRelatedProducts});
            this.xtraTabControl1.TabStop = false;
            // 
            // xtraTabPageLocation
            // 
            this.xtraTabPageLocation.Controls.Add(this.PanelControlLocationTab);
            this.xtraTabPageLocation.Margin = new System.Windows.Forms.Padding(4);
            this.xtraTabPageLocation.Name = "xtraTabPageLocation";
            this.xtraTabPageLocation.Size = new System.Drawing.Size(902, 585);
            this.xtraTabPageLocation.Text = "Location";
            // 
            // PanelControlLocationTab
            // 
            this.PanelControlLocationTab.AutoSize = true;
            this.PanelControlLocationTab.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PanelControlLocationTab.Controls.Add(label1);
            this.PanelControlLocationTab.Controls.Add(this.SearchLookUpEditRegion);
            this.PanelControlLocationTab.Controls.Add(this.labelControl3);
            this.PanelControlLocationTab.Controls.Add(this.labelControl2);
            this.PanelControlLocationTab.Controls.Add(this.SearchLookupEditDepCity);
            this.PanelControlLocationTab.Controls.Add(this.LabelControlLon);
            this.PanelControlLocationTab.Controls.Add(this.LabelControlLat);
            this.PanelControlLocationTab.Controls.Add(this.SimpleButtonPlot);
            this.PanelControlLocationTab.Controls.Add(LabelLat);
            this.PanelControlLocationTab.Controls.Add(LabelLong);
            this.PanelControlLocationTab.Controls.Add(this.MapControl);
            this.PanelControlLocationTab.Controls.Add(this.labelControl1);
            this.PanelControlLocationTab.Controls.Add(this.CheckEditProximitySearch);
            this.PanelControlLocationTab.Controls.Add(this.SpinEditDistance);
            this.PanelControlLocationTab.Controls.Add(this.TextEditCityMilesTo);
            this.PanelControlLocationTab.Controls.Add(this.LabelCityCode);
            this.PanelControlLocationTab.Controls.Add(LabelCityMilesTo);
            this.PanelControlLocationTab.Controls.Add(this.LabelCity);
            this.PanelControlLocationTab.Controls.Add(LabelMilesTo);
            this.PanelControlLocationTab.Controls.Add(this.LabelAirport);
            this.PanelControlLocationTab.Controls.Add(this.TextEditAirportMiles);
            this.PanelControlLocationTab.Controls.Add(this.LabelAirportCode);
            this.PanelControlLocationTab.Controls.Add(this.TextEditAddr1);
            this.PanelControlLocationTab.Controls.Add(this.TextEditZip);
            this.PanelControlLocationTab.Controls.Add(this.TextEditTown);
            this.PanelControlLocationTab.Controls.Add(LabelStreet);
            this.PanelControlLocationTab.Controls.Add(this.LabelAddressCity);
            this.PanelControlLocationTab.Controls.Add(this.LabelCountry);
            this.PanelControlLocationTab.Controls.Add(this.TextEditAddr2);
            this.PanelControlLocationTab.Controls.Add(this.LabelState);
            this.PanelControlLocationTab.Controls.Add(this.LabelZip);
            this.PanelControlLocationTab.Controls.Add(this.TextEditAddr3);
            this.PanelControlLocationTab.Controls.Add(this.SearchLookupEditState);
            this.PanelControlLocationTab.Controls.Add(this.SearchLookupEditCountry);
            this.PanelControlLocationTab.Controls.Add(this.SearchLookupEditCity);
            this.PanelControlLocationTab.Controls.Add(this.SearchLookupEditAirportCode);
            this.PanelControlLocationTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelControlLocationTab.Location = new System.Drawing.Point(0, 0);
            this.PanelControlLocationTab.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.PanelControlLocationTab.Name = "PanelControlLocationTab";
            this.PanelControlLocationTab.Size = new System.Drawing.Size(902, 585);
            this.PanelControlLocationTab.TabIndex = 0;
            // 
            // SearchLookUpEditRegion
            // 
            this.SearchLookUpEditRegion.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Region_Code", true));
            this.SearchLookUpEditRegion.EditValue = "";
            this.SearchLookUpEditRegion.Location = new System.Drawing.Point(123, 275);
            this.SearchLookUpEditRegion.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SearchLookUpEditRegion.Name = "SearchLookUpEditRegion";
            this.SearchLookUpEditRegion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLookUpEditRegion.Properties.DataSource = this.BindingSourceCodeName;
            this.SearchLookUpEditRegion.Properties.DisplayMember = "DisplayName";
            this.SearchLookUpEditRegion.Properties.NullText = "";
            this.SearchLookUpEditRegion.Properties.PopupSizeable = false;
            this.SearchLookUpEditRegion.Properties.PopupView = this.gridView16;
            this.SearchLookUpEditRegion.Properties.ValueMember = "Code";
            this.SearchLookUpEditRegion.Size = new System.Drawing.Size(260, 20);
            this.SearchLookUpEditRegion.TabIndex = 282;
            // 
            // gridView16
            // 
            this.gridView16.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn11,
            this.gridColumn12});
            this.gridView16.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView16.Name = "gridView16";
            this.gridView16.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView16.OptionsView.ShowGroupPanel = false;
            this.gridView16.OptionsView.ShowIndicator = false;
            // 
            // gridColumn11
            // 
            this.gridColumn11.FieldName = "Code";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 0;
            // 
            // gridColumn12
            // 
            this.gridColumn12.FieldName = "Name";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(424, 124);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(71, 13);
            this.labelControl3.TabIndex = 281;
            this.labelControl3.Text = "Departure City";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(428, 153);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(25, 13);
            this.labelControl2.TabIndex = 279;
            this.labelControl2.Text = "Code";
            // 
            // SearchLookupEditDepCity
            // 
            this.SearchLookupEditDepCity.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Citycod_Code_Origin", true));
            this.SearchLookupEditDepCity.Location = new System.Drawing.Point(458, 150);
            this.SearchLookupEditDepCity.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SearchLookupEditDepCity.Name = "SearchLookupEditDepCity";
            this.SearchLookupEditDepCity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLookupEditDepCity.Properties.DataSource = this.BindingSourceCodeName;
            this.SearchLookupEditDepCity.Properties.DisplayMember = "DisplayName";
            this.SearchLookupEditDepCity.Properties.NullText = "";
            this.SearchLookupEditDepCity.Properties.PopupSizeable = false;
            this.SearchLookupEditDepCity.Properties.PopupView = this.gridView19;
            this.SearchLookupEditDepCity.Properties.ValueMember = "Code";
            this.SearchLookupEditDepCity.Size = new System.Drawing.Size(234, 20);
            this.SearchLookupEditDepCity.TabIndex = 280;
            this.SearchLookupEditDepCity.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            this.SearchLookupEditDepCity.Leave += new System.EventHandler(this.SearchLookUpEditDepCity_Leave);
            // 
            // gridView19
            // 
            this.gridView19.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn14,
            this.gridColumn15});
            this.gridView19.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView19.Name = "gridView19";
            this.gridView19.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView19.OptionsView.ShowGroupPanel = false;
            this.gridView19.OptionsView.ShowIndicator = false;
            // 
            // gridColumn14
            // 
            this.gridColumn14.FieldName = "Code";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 0;
            // 
            // gridColumn15
            // 
            this.gridColumn15.FieldName = "Name";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 1;
            // 
            // LabelControlLon
            // 
            this.LabelControlLon.Location = new System.Drawing.Point(216, 377);
            this.LabelControlLon.Margin = new System.Windows.Forms.Padding(2);
            this.LabelControlLon.Name = "LabelControlLon";
            this.LabelControlLon.Size = new System.Drawing.Size(0, 13);
            this.LabelControlLon.TabIndex = 278;
            // 
            // LabelControlLat
            // 
            this.LabelControlLat.Location = new System.Drawing.Point(216, 362);
            this.LabelControlLat.Margin = new System.Windows.Forms.Padding(2);
            this.LabelControlLat.Name = "LabelControlLat";
            this.LabelControlLat.Size = new System.Drawing.Size(0, 13);
            this.LabelControlLat.TabIndex = 277;
            // 
            // SimpleButtonPlot
            // 
            this.SimpleButtonPlot.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("SimpleButtonPlot.ImageOptions.Image")));
            this.SimpleButtonPlot.Location = new System.Drawing.Point(74, 349);
            this.SimpleButtonPlot.Margin = new System.Windows.Forms.Padding(2);
            this.SimpleButtonPlot.Name = "SimpleButtonPlot";
            this.SimpleButtonPlot.Size = new System.Drawing.Size(66, 41);
            this.SimpleButtonPlot.TabIndex = 276;
            this.SimpleButtonPlot.Text = "Plot";
            // 
            // MapControl
            // 
            this.MapControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MapControl.EnableAnimation = false;
            this.MapControl.Layers.Add(this.ImageLayer);
            this.MapControl.Layers.Add(this.VectorItemsLayer);
            this.MapControl.Layers.Add(this.InformationLayer);
            this.MapControl.Location = new System.Drawing.Point(414, 196);
            this.MapControl.Margin = new System.Windows.Forms.Padding(2);
            this.MapControl.MaximumSize = new System.Drawing.Size(400, 312);
            this.MapControl.Name = "MapControl";
            this.MapControl.NavigationPanelOptions.Height = 200;
            this.MapControl.ShowSearchPanel = false;
            this.MapControl.Size = new System.Drawing.Size(355, 312);
            this.MapControl.TabIndex = 272;
            this.MapControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MapControl_MouseDown);
            this.MapControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapControl_MouseMove);
            this.MapControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MapControl_MouseUp);
            this.ImageLayer.DataProvider = this.BingMapDataProvider;
            this.ImageLayer.Name = "ImageLayer";
            this.VectorItemsLayer.Data = this.MapItemStorage;
            this.VectorItemsLayer.Name = "VectorItemsLayer";
            this.InformationLayer.DataProvider = this.BingSearchDataProvider;
            this.InformationLayer.Name = "InformationLayer";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(74, 328);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(181, 13);
            this.labelControl1.TabIndex = 102;
            this.labelControl1.Text = "Distance to search from this item (km)";
            // 
            // CheckEditProximitySearch
            // 
            this.CheckEditProximitySearch.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "ProximitySearch", true));
            this.CheckEditProximitySearch.Location = new System.Drawing.Point(72, 301);
            this.CheckEditProximitySearch.Margin = new System.Windows.Forms.Padding(2);
            this.CheckEditProximitySearch.Name = "CheckEditProximitySearch";
            this.CheckEditProximitySearch.Properties.Caption = "Enable proximity search for this item on a map";
            this.CheckEditProximitySearch.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditProximitySearch.Size = new System.Drawing.Size(270, 19);
            this.CheckEditProximitySearch.TabIndex = 101;
            this.CheckEditProximitySearch.CheckedChanged += new System.EventHandler(this.CheckEditProximitySearch_CheckedChanged);
            // 
            // SpinEditDistance
            // 
            this.SpinEditDistance.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "ProximitySearchDistance", true));
            this.SpinEditDistance.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SpinEditDistance.Enabled = false;
            this.SpinEditDistance.Location = new System.Drawing.Point(306, 324);
            this.SpinEditDistance.Margin = new System.Windows.Forms.Padding(2);
            this.SpinEditDistance.Name = "SpinEditDistance";
            this.SpinEditDistance.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SpinEditDistance.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.SpinEditDistance.Size = new System.Drawing.Size(66, 20);
            this.SpinEditDistance.TabIndex = 103;
            this.SpinEditDistance.Leave += new System.EventHandler(this.SpinEditDistance_Leave);
            // 
            // TextEditCityMilesTo
            // 
            this.TextEditCityMilesTo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CITY_MI", true));
            this.TextEditCityMilesTo.EnterMoveNextControl = true;
            this.TextEditCityMilesTo.Location = new System.Drawing.Point(778, 97);
            this.TextEditCityMilesTo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TextEditCityMilesTo.Name = "TextEditCityMilesTo";
            this.TextEditCityMilesTo.Size = new System.Drawing.Size(44, 20);
            this.TextEditCityMilesTo.TabIndex = 18;
            // 
            // LabelCityCode
            // 
            this.LabelCityCode.Location = new System.Drawing.Point(428, 100);
            this.LabelCityCode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LabelCityCode.Name = "LabelCityCode";
            this.LabelCityCode.Size = new System.Drawing.Size(25, 13);
            this.LabelCityCode.TabIndex = 0;
            this.LabelCityCode.Text = "Code";
            // 
            // LabelCity
            // 
            this.LabelCity.Location = new System.Drawing.Point(434, 76);
            this.LabelCity.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LabelCity.Name = "LabelCity";
            this.LabelCity.Size = new System.Drawing.Size(19, 13);
            this.LabelCity.TabIndex = 0;
            this.LabelCity.Text = "City";
            // 
            // LabelAirport
            // 
            this.LabelAirport.Location = new System.Drawing.Point(434, 10);
            this.LabelAirport.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LabelAirport.Name = "LabelAirport";
            this.LabelAirport.Size = new System.Drawing.Size(33, 13);
            this.LabelAirport.TabIndex = 0;
            this.LabelAirport.Text = "Airport";
            // 
            // TextEditAirportMiles
            // 
            this.TextEditAirportMiles.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "AIR_MI", true));
            this.TextEditAirportMiles.EnterMoveNextControl = true;
            this.TextEditAirportMiles.Location = new System.Drawing.Point(778, 33);
            this.TextEditAirportMiles.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TextEditAirportMiles.Name = "TextEditAirportMiles";
            this.TextEditAirportMiles.Size = new System.Drawing.Size(44, 20);
            this.TextEditAirportMiles.TabIndex = 16;
            // 
            // LabelAirportCode
            // 
            this.LabelAirportCode.Location = new System.Drawing.Point(428, 36);
            this.LabelAirportCode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LabelAirportCode.Name = "LabelAirportCode";
            this.LabelAirportCode.Size = new System.Drawing.Size(25, 13);
            this.LabelAirportCode.TabIndex = 0;
            this.LabelAirportCode.Text = "Code";
            // 
            // TextEditAddr1
            // 
            this.TextEditAddr1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "ADDR1", true));
            this.TextEditAddr1.EnterMoveNextControl = true;
            this.TextEditAddr1.Location = new System.Drawing.Point(123, 23);
            this.TextEditAddr1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TextEditAddr1.Name = "TextEditAddr1";
            this.TextEditAddr1.Properties.MaxLength = 30;
            this.TextEditAddr1.Size = new System.Drawing.Size(260, 20);
            this.TextEditAddr1.TabIndex = 8;
            this.TextEditAddr1.Leave += new System.EventHandler(this.TextEditAddr1_Leave);
            // 
            // TextEditZip
            // 
            this.TextEditZip.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "ZIP", true));
            this.TextEditZip.EnterMoveNextControl = true;
            this.TextEditZip.Location = new System.Drawing.Point(123, 201);
            this.TextEditZip.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TextEditZip.Name = "TextEditZip";
            this.TextEditZip.Properties.MaxLength = 10;
            this.TextEditZip.Size = new System.Drawing.Size(260, 20);
            this.TextEditZip.TabIndex = 13;
            this.TextEditZip.Leave += new System.EventHandler(this.TextEditZip_Leave);
            // 
            // TextEditTown
            // 
            this.TextEditTown.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "TOWN", true));
            this.TextEditTown.EnterMoveNextControl = true;
            this.TextEditTown.Location = new System.Drawing.Point(123, 127);
            this.TextEditTown.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TextEditTown.Name = "TextEditTown";
            this.TextEditTown.Properties.MaxLength = 30;
            this.TextEditTown.Size = new System.Drawing.Size(260, 20);
            this.TextEditTown.TabIndex = 11;
            this.TextEditTown.Leave += new System.EventHandler(this.TextEditTown_Leave);
            // 
            // LabelAddressCity
            // 
            this.LabelAddressCity.Location = new System.Drawing.Point(70, 131);
            this.LabelAddressCity.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LabelAddressCity.Name = "LabelAddressCity";
            this.LabelAddressCity.Size = new System.Drawing.Size(19, 13);
            this.LabelAddressCity.TabIndex = 0;
            this.LabelAddressCity.Text = "City";
            // 
            // LabelCountry
            // 
            this.LabelCountry.Location = new System.Drawing.Point(72, 241);
            this.LabelCountry.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LabelCountry.Name = "LabelCountry";
            this.LabelCountry.Size = new System.Drawing.Size(39, 13);
            this.LabelCountry.TabIndex = 0;
            this.LabelCountry.Text = "Country";
            // 
            // TextEditAddr2
            // 
            this.TextEditAddr2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "ADDR2", true));
            this.TextEditAddr2.EnterMoveNextControl = true;
            this.TextEditAddr2.Location = new System.Drawing.Point(123, 57);
            this.TextEditAddr2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TextEditAddr2.Name = "TextEditAddr2";
            this.TextEditAddr2.Properties.MaxLength = 30;
            this.TextEditAddr2.Size = new System.Drawing.Size(260, 20);
            this.TextEditAddr2.TabIndex = 9;
            this.TextEditAddr2.Leave += new System.EventHandler(this.TextEditAddr2_Leave);
            // 
            // LabelState
            // 
            this.LabelState.Location = new System.Drawing.Point(70, 168);
            this.LabelState.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LabelState.Name = "LabelState";
            this.LabelState.Size = new System.Drawing.Size(26, 13);
            this.LabelState.TabIndex = 0;
            this.LabelState.Text = "State";
            // 
            // LabelZip
            // 
            this.LabelZip.Location = new System.Drawing.Point(72, 204);
            this.LabelZip.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LabelZip.Name = "LabelZip";
            this.LabelZip.Size = new System.Drawing.Size(14, 13);
            this.LabelZip.TabIndex = 0;
            this.LabelZip.Text = "Zip";
            // 
            // TextEditAddr3
            // 
            this.TextEditAddr3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "ADDR3", true));
            this.TextEditAddr3.EnterMoveNextControl = true;
            this.TextEditAddr3.Location = new System.Drawing.Point(123, 93);
            this.TextEditAddr3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TextEditAddr3.Name = "TextEditAddr3";
            this.TextEditAddr3.Properties.MaxLength = 30;
            this.TextEditAddr3.Size = new System.Drawing.Size(260, 20);
            this.TextEditAddr3.TabIndex = 10;
            this.TextEditAddr3.Leave += new System.EventHandler(this.TextEditAddr3_Leave);
            // 
            // SearchLookupEditState
            // 
            this.SearchLookupEditState.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "STATE", true));
            this.SearchLookupEditState.Location = new System.Drawing.Point(123, 164);
            this.SearchLookupEditState.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SearchLookupEditState.Name = "SearchLookupEditState";
            this.SearchLookupEditState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLookupEditState.Properties.DataSource = this.BindingSourceCodeName;
            this.SearchLookupEditState.Properties.DisplayMember = "DisplayName";
            this.SearchLookupEditState.Properties.NullText = "";
            this.SearchLookupEditState.Properties.PopupSizeable = false;
            this.SearchLookupEditState.Properties.PopupView = this.gridView6;
            this.SearchLookupEditState.Properties.ValueMember = "Code";
            this.SearchLookupEditState.Size = new System.Drawing.Size(260, 20);
            this.SearchLookupEditState.TabIndex = 12;
            this.SearchLookupEditState.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            this.SearchLookupEditState.Leave += new System.EventHandler(this.ImageComboBoxEditState_Leave);
            // 
            // gridView6
            // 
            this.gridView6.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode10,
            this.colName4});
            this.gridView6.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView6.Name = "gridView6";
            this.gridView6.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView6.OptionsView.ShowGroupPanel = false;
            this.gridView6.OptionsView.ShowIndicator = false;
            // 
            // colCode10
            // 
            this.colCode10.FieldName = "Code";
            this.colCode10.Name = "colCode10";
            this.colCode10.Visible = true;
            this.colCode10.VisibleIndex = 0;
            // 
            // colName4
            // 
            this.colName4.FieldName = "Name";
            this.colName4.Name = "colName4";
            this.colName4.Visible = true;
            this.colName4.VisibleIndex = 1;
            // 
            // SearchLookupEditCountry
            // 
            this.SearchLookupEditCountry.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "COUNTRY", true));
            this.SearchLookupEditCountry.Location = new System.Drawing.Point(123, 237);
            this.SearchLookupEditCountry.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SearchLookupEditCountry.Name = "SearchLookupEditCountry";
            this.SearchLookupEditCountry.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLookupEditCountry.Properties.DataSource = this.BindingSourceCodeName;
            this.SearchLookupEditCountry.Properties.DisplayMember = "DisplayName";
            this.SearchLookupEditCountry.Properties.NullText = "";
            this.SearchLookupEditCountry.Properties.PopupSizeable = false;
            this.SearchLookupEditCountry.Properties.PopupView = this.gridView7;
            this.SearchLookupEditCountry.Properties.ValueMember = "Code";
            this.SearchLookupEditCountry.Size = new System.Drawing.Size(260, 20);
            this.SearchLookupEditCountry.TabIndex = 14;
            this.SearchLookupEditCountry.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            this.SearchLookupEditCountry.Leave += new System.EventHandler(this.ImageComboBoxEditCountry_Leave);
            // 
            // gridView7
            // 
            this.gridView7.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode11,
            this.colName5});
            this.gridView7.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView7.Name = "gridView7";
            this.gridView7.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView7.OptionsView.ShowGroupPanel = false;
            this.gridView7.OptionsView.ShowIndicator = false;
            // 
            // colCode11
            // 
            this.colCode11.FieldName = "Code";
            this.colCode11.Name = "colCode11";
            this.colCode11.Visible = true;
            this.colCode11.VisibleIndex = 0;
            // 
            // colName5
            // 
            this.colName5.FieldName = "Name";
            this.colName5.Name = "colName5";
            this.colName5.Visible = true;
            this.colName5.VisibleIndex = 1;
            // 
            // SearchLookupEditCity
            // 
            this.SearchLookupEditCity.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CITY", true));
            this.SearchLookupEditCity.Location = new System.Drawing.Point(458, 97);
            this.SearchLookupEditCity.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SearchLookupEditCity.Name = "SearchLookupEditCity";
            this.SearchLookupEditCity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLookupEditCity.Properties.DataSource = this.BindingSourceCodeName;
            this.SearchLookupEditCity.Properties.DisplayMember = "DisplayName";
            this.SearchLookupEditCity.Properties.NullText = "";
            this.SearchLookupEditCity.Properties.PopupSizeable = false;
            this.SearchLookupEditCity.Properties.PopupView = this.gridView10;
            this.SearchLookupEditCity.Properties.ValueMember = "Code";
            this.SearchLookupEditCity.Size = new System.Drawing.Size(234, 20);
            this.SearchLookupEditCity.TabIndex = 17;
            this.SearchLookupEditCity.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            this.SearchLookupEditCity.Leave += new System.EventHandler(this.ImageComboBoxEditCity_Leave);
            // 
            // gridView10
            // 
            this.gridView10.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode9,
            this.colName7});
            this.gridView10.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView10.Name = "gridView10";
            this.gridView10.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView10.OptionsView.ShowGroupPanel = false;
            this.gridView10.OptionsView.ShowIndicator = false;
            // 
            // colCode9
            // 
            this.colCode9.FieldName = "Code";
            this.colCode9.Name = "colCode9";
            this.colCode9.Visible = true;
            this.colCode9.VisibleIndex = 0;
            // 
            // colName7
            // 
            this.colName7.FieldName = "Name";
            this.colName7.Name = "colName7";
            this.colName7.Visible = true;
            this.colName7.VisibleIndex = 1;
            // 
            // SearchLookupEditAirportCode
            // 
            this.SearchLookupEditAirportCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "AIRPORT", true));
            this.SearchLookupEditAirportCode.Location = new System.Drawing.Point(458, 34);
            this.SearchLookupEditAirportCode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SearchLookupEditAirportCode.Name = "SearchLookupEditAirportCode";
            this.SearchLookupEditAirportCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLookupEditAirportCode.Properties.NullText = "";
            this.SearchLookupEditAirportCode.Properties.PopupSizeable = false;
            this.SearchLookupEditAirportCode.Properties.PopupView = this.gridView11;
            this.SearchLookupEditAirportCode.Size = new System.Drawing.Size(234, 20);
            this.SearchLookupEditAirportCode.TabIndex = 15;
            this.SearchLookupEditAirportCode.Leave += new System.EventHandler(this.ImageComboBoxEditAirportCode_Leave);
            // 
            // gridView11
            // 
            this.gridView11.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView11.Name = "gridView11";
            this.gridView11.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView11.OptionsView.ShowGroupPanel = false;
            // 
            // xtraTabPagePolicies
            // 
            this.xtraTabPagePolicies.Controls.Add(this.PanelControlPoliciesTab);
            this.xtraTabPagePolicies.Margin = new System.Windows.Forms.Padding(4);
            this.xtraTabPagePolicies.Name = "xtraTabPagePolicies";
            this.xtraTabPagePolicies.Size = new System.Drawing.Size(902, 585);
            this.xtraTabPagePolicies.Text = "Policies";
            // 
            // PanelControlPoliciesTab
            // 
            this.PanelControlPoliciesTab.AutoSize = true;
            this.PanelControlPoliciesTab.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PanelControlPoliciesTab.Controls.Add(this.CheckEditPhone);
            this.PanelControlPoliciesTab.Controls.Add(this.CheckEditAdmin);
            this.PanelControlPoliciesTab.Controls.Add(LabelOnRequestPeriod);
            this.PanelControlPoliciesTab.Controls.Add(this.SpinEditOnRequestPeriod);
            this.PanelControlPoliciesTab.Controls.Add(this.ImageComboBoxEditConfirmationType);
            this.PanelControlPoliciesTab.Controls.Add(label2);
            this.PanelControlPoliciesTab.Controls.Add(LabelMaxPax);
            this.PanelControlPoliciesTab.Controls.Add(this.SpinEditMaxPax);
            this.PanelControlPoliciesTab.Controls.Add(LabelStartingAgentNet);
            this.PanelControlPoliciesTab.Controls.Add(this.SpinEditStartingAgentNet);
            this.PanelControlPoliciesTab.Controls.Add(LabelStartingComparison);
            this.PanelControlPoliciesTab.Controls.Add(this.SpinEditStartingComparison);
            this.PanelControlPoliciesTab.Controls.Add(LabelStartingPrice);
            this.PanelControlPoliciesTab.Controls.Add(this.spinEditStartingPrice);
            this.PanelControlPoliciesTab.Controls.Add(LabelStartingCost);
            this.PanelControlPoliciesTab.Controls.Add(this.SpinEditStartingCost);
            this.PanelControlPoliciesTab.Controls.Add(this.CheckEditAllNames);
            this.PanelControlPoliciesTab.Controls.Add(this.CheckEditAdminClosed);
            this.PanelControlPoliciesTab.Controls.Add(this.ImageComboBoxEditVoucherTypes);
            this.PanelControlPoliciesTab.Controls.Add(LabelVoucherTypes);
            this.PanelControlPoliciesTab.Controls.Add(this.CheckEditDOBRequired);
            this.PanelControlPoliciesTab.Controls.Add(LabelUserReviews);
            this.PanelControlPoliciesTab.Controls.Add(this.spinEdit2);
            this.PanelControlPoliciesTab.Controls.Add(LabelRating);
            this.PanelControlPoliciesTab.Controls.Add(this.RatingControlStars);
            this.PanelControlPoliciesTab.Controls.Add(LabelRanking);
            this.PanelControlPoliciesTab.Controls.Add(this.SpinEditRanking);
            this.PanelControlPoliciesTab.Controls.Add(LabelMaxDuration);
            this.PanelControlPoliciesTab.Controls.Add(this.spinEdit1);
            this.PanelControlPoliciesTab.Controls.Add(LabelDueDays);
            this.PanelControlPoliciesTab.Controls.Add(this.TextEditDueDays);
            this.PanelControlPoliciesTab.Controls.Add(LabelARNumber);
            this.PanelControlPoliciesTab.Controls.Add(this.TextEditARNumber);
            this.PanelControlPoliciesTab.Controls.Add(LabelAPNumber);
            this.PanelControlPoliciesTab.Controls.Add(this.ImageComboBoxEditRateBasis);
            this.PanelControlPoliciesTab.Controls.Add(this.TextEditAPNumber);
            this.PanelControlPoliciesTab.Controls.Add(this.checkEditDropoffInfoRequired);
            this.PanelControlPoliciesTab.Controls.Add(this.checkEditPickupInfoRequired);
            this.PanelControlPoliciesTab.Controls.Add(this.checkEditPassengerWeightRequired);
            this.PanelControlPoliciesTab.Controls.Add(this.TextEditVendorCode);
            this.PanelControlPoliciesTab.Controls.Add(this.checkEditAccountingServiceItem);
            this.PanelControlPoliciesTab.Controls.Add(this.CheckEditVendorPrepayReqd);
            this.PanelControlPoliciesTab.Controls.Add(LabelMinDuration);
            this.PanelControlPoliciesTab.Controls.Add(this.unit_RateCheckEdit);
            this.PanelControlPoliciesTab.Controls.Add(LabelRateBasis);
            this.PanelControlPoliciesTab.Controls.Add(this.mealsIncludedCheckEdit);
            this.PanelControlPoliciesTab.Controls.Add(this.CheckEditMultTimes);
            this.PanelControlPoliciesTab.Controls.Add(LabelVendorCode);
            this.PanelControlPoliciesTab.Controls.Add(this.CheckEditAllowFree);
            this.PanelControlPoliciesTab.Controls.Add(this.CheckEditClientLogo);
            this.PanelControlPoliciesTab.Controls.Add(LabelVoucheringDaysPrior);
            this.PanelControlPoliciesTab.Controls.Add(this.SpinEditDayPrior);
            this.PanelControlPoliciesTab.Controls.Add(LabelDefaultTime);
            this.PanelControlPoliciesTab.Controls.Add(this.CheckEditReqDepInfo);
            this.PanelControlPoliciesTab.Controls.Add(this.CheckEditReqArvInfo);
            this.PanelControlPoliciesTab.Controls.Add(this.CheckEditDropoff);
            this.PanelControlPoliciesTab.Controls.Add(this.CheckEditPickup);
            this.PanelControlPoliciesTab.Controls.Add(this.CheckEditTransferList);
            this.PanelControlPoliciesTab.Controls.Add(this.CheckEditSvcList);
            this.PanelControlPoliciesTab.Controls.Add(LabelTransferType);
            this.PanelControlPoliciesTab.Controls.Add(this.SpinEditDuration);
            this.PanelControlPoliciesTab.Controls.Add(this.ImageComboBoxEditTransType);
            this.PanelControlPoliciesTab.Controls.Add(this.TextEditDefaultTime);
            this.PanelControlPoliciesTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelControlPoliciesTab.Location = new System.Drawing.Point(0, 0);
            this.PanelControlPoliciesTab.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.PanelControlPoliciesTab.Name = "PanelControlPoliciesTab";
            this.PanelControlPoliciesTab.Size = new System.Drawing.Size(902, 585);
            this.PanelControlPoliciesTab.TabIndex = 0;
            // 
            // CheckEditPhone
            // 
            this.CheckEditPhone.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "PhoneRequired", true));
            this.CheckEditPhone.Enabled = false;
            this.CheckEditPhone.Location = new System.Drawing.Point(161, 254);
            this.CheckEditPhone.Margin = new System.Windows.Forms.Padding(2);
            this.CheckEditPhone.Name = "CheckEditPhone";
            this.CheckEditPhone.Properties.Caption = "Phone Required";
            this.CheckEditPhone.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditPhone.Properties.ValueGrayed = false;
            this.CheckEditPhone.Size = new System.Drawing.Size(100, 19);
            this.CheckEditPhone.TabIndex = 146;
            // 
            // CheckEditAdmin
            // 
            this.CheckEditAdmin.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Admin", true));
            this.CheckEditAdmin.EnterMoveNextControl = true;
            this.CheckEditAdmin.Location = new System.Drawing.Point(593, 174);
            this.CheckEditAdmin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CheckEditAdmin.Name = "CheckEditAdmin";
            this.CheckEditAdmin.Properties.Caption = "Administrative product";
            this.CheckEditAdmin.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditAdmin.Size = new System.Drawing.Size(135, 19);
            this.CheckEditAdmin.TabIndex = 30;
            // 
            // SpinEditOnRequestPeriod
            // 
            this.SpinEditOnRequestPeriod.CausesValidation = false;
            this.SpinEditOnRequestPeriod.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "OnRequestPeriod", true));
            this.SpinEditOnRequestPeriod.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SpinEditOnRequestPeriod.Location = new System.Drawing.Point(612, 307);
            this.SpinEditOnRequestPeriod.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SpinEditOnRequestPeriod.Name = "SpinEditOnRequestPeriod";
            this.SpinEditOnRequestPeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SpinEditOnRequestPeriod.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            131072});
            this.SpinEditOnRequestPeriod.Size = new System.Drawing.Size(83, 20);
            this.SpinEditOnRequestPeriod.TabIndex = 145;
            // 
            // ImageComboBoxEditConfirmationType
            // 
            this.ImageComboBoxEditConfirmationType.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "ConfirmationType", true));
            this.ImageComboBoxEditConfirmationType.EnterMoveNextControl = true;
            this.ImageComboBoxEditConfirmationType.Location = new System.Drawing.Point(336, 307);
            this.ImageComboBoxEditConfirmationType.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ImageComboBoxEditConfirmationType.Name = "ImageComboBoxEditConfirmationType";
            this.ImageComboBoxEditConfirmationType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ImageComboBoxEditConfirmationType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Instant", ((short)(0)), -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Requestable", ((short)(1)), -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Instant with cutoff", ((short)(2)), -1)});
            this.ImageComboBoxEditConfirmationType.Size = new System.Drawing.Size(155, 20);
            this.ImageComboBoxEditConfirmationType.TabIndex = 143;
            this.ImageComboBoxEditConfirmationType.EditValueChanged += new System.EventHandler(this.ImageComboBoxEditConfirmationType_EditValueChanged);
            // 
            // SpinEditMaxPax
            // 
            this.SpinEditMaxPax.CausesValidation = false;
            this.SpinEditMaxPax.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "MaxPaxPerBooking", true));
            this.SpinEditMaxPax.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SpinEditMaxPax.Location = new System.Drawing.Point(135, 306);
            this.SpinEditMaxPax.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SpinEditMaxPax.Name = "SpinEditMaxPax";
            this.SpinEditMaxPax.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SpinEditMaxPax.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            131072});
            this.SpinEditMaxPax.Size = new System.Drawing.Size(83, 20);
            this.SpinEditMaxPax.TabIndex = 141;
            // 
            // SpinEditStartingAgentNet
            // 
            this.SpinEditStartingAgentNet.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "StartingAgentNet", true));
            this.SpinEditStartingAgentNet.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SpinEditStartingAgentNet.EnterMoveNextControl = true;
            this.SpinEditStartingAgentNet.Location = new System.Drawing.Point(708, 283);
            this.SpinEditStartingAgentNet.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SpinEditStartingAgentNet.Name = "SpinEditStartingAgentNet";
            this.SpinEditStartingAgentNet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SpinEditStartingAgentNet.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.SpinEditStartingAgentNet.Properties.Mask.EditMask = "f";
            this.SpinEditStartingAgentNet.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.SpinEditStartingAgentNet.Properties.NullText = "0";
            this.SpinEditStartingAgentNet.Size = new System.Drawing.Size(68, 20);
            this.SpinEditStartingAgentNet.TabIndex = 139;
            // 
            // SpinEditStartingComparison
            // 
            this.SpinEditStartingComparison.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "StartingComparison", true));
            this.SpinEditStartingComparison.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SpinEditStartingComparison.EnterMoveNextControl = true;
            this.SpinEditStartingComparison.Location = new System.Drawing.Point(526, 281);
            this.SpinEditStartingComparison.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SpinEditStartingComparison.Name = "SpinEditStartingComparison";
            this.SpinEditStartingComparison.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SpinEditStartingComparison.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.SpinEditStartingComparison.Properties.Mask.EditMask = "f";
            this.SpinEditStartingComparison.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.SpinEditStartingComparison.Properties.NullText = "0";
            this.SpinEditStartingComparison.Size = new System.Drawing.Size(68, 20);
            this.SpinEditStartingComparison.TabIndex = 137;
            // 
            // spinEditStartingPrice
            // 
            this.spinEditStartingPrice.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "StartingPrice", true));
            this.spinEditStartingPrice.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditStartingPrice.EnterMoveNextControl = true;
            this.spinEditStartingPrice.Location = new System.Drawing.Point(316, 281);
            this.spinEditStartingPrice.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.spinEditStartingPrice.Name = "spinEditStartingPrice";
            this.spinEditStartingPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditStartingPrice.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.spinEditStartingPrice.Properties.Mask.EditMask = "f";
            this.spinEditStartingPrice.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.spinEditStartingPrice.Properties.NullText = "0";
            this.spinEditStartingPrice.Size = new System.Drawing.Size(68, 20);
            this.spinEditStartingPrice.TabIndex = 135;
            // 
            // SpinEditStartingCost
            // 
            this.SpinEditStartingCost.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "StartingCost", true));
            this.SpinEditStartingCost.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SpinEditStartingCost.EnterMoveNextControl = true;
            this.SpinEditStartingCost.Location = new System.Drawing.Point(135, 280);
            this.SpinEditStartingCost.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SpinEditStartingCost.Name = "SpinEditStartingCost";
            this.SpinEditStartingCost.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SpinEditStartingCost.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.SpinEditStartingCost.Properties.Mask.EditMask = "f";
            this.SpinEditStartingCost.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.SpinEditStartingCost.Properties.NullText = "0";
            this.SpinEditStartingCost.Size = new System.Drawing.Size(68, 20);
            this.SpinEditStartingCost.TabIndex = 133;
            // 
            // CheckEditAllNames
            // 
            this.CheckEditAllNames.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "AllNamesRequired", true));
            this.CheckEditAllNames.Enabled = false;
            this.CheckEditAllNames.Location = new System.Drawing.Point(277, 254);
            this.CheckEditAllNames.Margin = new System.Windows.Forms.Padding(2);
            this.CheckEditAllNames.Name = "CheckEditAllNames";
            this.CheckEditAllNames.Properties.Caption = "All Names Required";
            this.CheckEditAllNames.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditAllNames.Properties.ValueGrayed = false;
            this.CheckEditAllNames.Size = new System.Drawing.Size(117, 19);
            this.CheckEditAllNames.TabIndex = 131;
            // 
            // CheckEditAdminClosed
            // 
            this.CheckEditAdminClosed.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "AdminClosed", true));
            this.CheckEditAdminClosed.Enabled = false;
            this.CheckEditAdminClosed.Location = new System.Drawing.Point(54, 229);
            this.CheckEditAdminClosed.Margin = new System.Windows.Forms.Padding(2);
            this.CheckEditAdminClosed.Name = "CheckEditAdminClosed";
            this.CheckEditAdminClosed.Properties.Caption = "Admin Closed";
            this.CheckEditAdminClosed.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditAdminClosed.Properties.ValueGrayed = false;
            this.CheckEditAdminClosed.Size = new System.Drawing.Size(96, 19);
            this.CheckEditAdminClosed.TabIndex = 130;
            // 
            // ImageComboBoxEditVoucherTypes
            // 
            this.ImageComboBoxEditVoucherTypes.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "VoucherTypesAccepted", true));
            this.ImageComboBoxEditVoucherTypes.EnterMoveNextControl = true;
            this.ImageComboBoxEditVoucherTypes.Location = new System.Drawing.Point(330, 200);
            this.ImageComboBoxEditVoucherTypes.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ImageComboBoxEditVoucherTypes.Name = "ImageComboBoxEditVoucherTypes";
            this.ImageComboBoxEditVoucherTypes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ImageComboBoxEditVoucherTypes.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Paper", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Electronic", 2, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Identification", 4, -1)});
            this.ImageComboBoxEditVoucherTypes.Size = new System.Drawing.Size(155, 20);
            this.ImageComboBoxEditVoucherTypes.TabIndex = 129;
            // 
            // CheckEditDOBRequired
            // 
            this.CheckEditDOBRequired.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "DOBRequired", true));
            this.CheckEditDOBRequired.EnterMoveNextControl = true;
            this.CheckEditDOBRequired.Location = new System.Drawing.Point(54, 254);
            this.CheckEditDOBRequired.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CheckEditDOBRequired.Name = "CheckEditDOBRequired";
            this.CheckEditDOBRequired.Properties.Caption = "DOB Required";
            this.CheckEditDOBRequired.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditDOBRequired.Size = new System.Drawing.Size(96, 19);
            this.CheckEditDOBRequired.TabIndex = 127;
            // 
            // spinEdit2
            // 
            this.spinEdit2.CausesValidation = false;
            this.spinEdit2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "MaxDuration", true));
            this.spinEdit2.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit2.Location = new System.Drawing.Point(530, 228);
            this.spinEdit2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.spinEdit2.Name = "spinEdit2";
            this.spinEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit2.Properties.Mask.EditMask = "f";
            this.spinEdit2.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            131072});
            this.spinEdit2.Size = new System.Drawing.Size(100, 20);
            this.spinEdit2.TabIndex = 126;
            // 
            // RatingControlStars
            // 
            this.RatingControlStars.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "UserRating", true));
            this.RatingControlStars.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.RatingControlStars.Location = new System.Drawing.Point(376, 230);
            this.RatingControlStars.Name = "RatingControlStars";
            this.RatingControlStars.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.RatingControlStars.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.RatingControlStars.Rating = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.RatingControlStars.Size = new System.Drawing.Size(89, 18);
            this.RatingControlStars.TabIndex = 124;
            this.RatingControlStars.Text = "0";
            // 
            // SpinEditRanking
            // 
            this.SpinEditRanking.CausesValidation = false;
            this.SpinEditRanking.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Ranking", true));
            this.SpinEditRanking.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SpinEditRanking.Location = new System.Drawing.Point(220, 228);
            this.SpinEditRanking.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SpinEditRanking.Name = "SpinEditRanking";
            this.SpinEditRanking.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SpinEditRanking.Properties.Mask.EditMask = "0.0000";
            this.SpinEditRanking.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.SpinEditRanking.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            131072});
            this.SpinEditRanking.Size = new System.Drawing.Size(83, 20);
            this.SpinEditRanking.TabIndex = 118;
            // 
            // spinEdit1
            // 
            this.spinEdit1.CausesValidation = false;
            this.spinEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "MaxDuration", true));
            this.spinEdit1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit1.Location = new System.Drawing.Point(723, 97);
            this.spinEdit1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.spinEdit1.Name = "spinEdit1";
            this.spinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit1.Properties.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.spinEdit1.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            131072});
            this.spinEdit1.Size = new System.Drawing.Size(100, 20);
            this.spinEdit1.TabIndex = 114;
            // 
            // TextEditDueDays
            // 
            this.TextEditDueDays.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Due_Days", true));
            this.TextEditDueDays.EnterMoveNextControl = true;
            this.TextEditDueDays.Location = new System.Drawing.Point(497, 175);
            this.TextEditDueDays.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TextEditDueDays.Name = "TextEditDueDays";
            this.TextEditDueDays.Size = new System.Drawing.Size(78, 20);
            this.TextEditDueDays.TabIndex = 112;
            // 
            // TextEditARNumber
            // 
            this.TextEditARNumber.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "AR", true));
            this.TextEditARNumber.EnterMoveNextControl = true;
            this.TextEditARNumber.Location = new System.Drawing.Point(297, 175);
            this.TextEditARNumber.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TextEditARNumber.Name = "TextEditARNumber";
            this.TextEditARNumber.Properties.MaxLength = 12;
            this.TextEditARNumber.Size = new System.Drawing.Size(100, 20);
            this.TextEditARNumber.TabIndex = 111;
            // 
            // TextEditAPNumber
            // 
            this.TextEditAPNumber.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "AP", true));
            this.TextEditAPNumber.EnterMoveNextControl = true;
            this.TextEditAPNumber.Location = new System.Drawing.Point(135, 175);
            this.TextEditAPNumber.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TextEditAPNumber.Name = "TextEditAPNumber";
            this.TextEditAPNumber.Properties.MaxLength = 6;
            this.TextEditAPNumber.Size = new System.Drawing.Size(78, 20);
            this.TextEditAPNumber.TabIndex = 110;
            // 
            // checkEditDropoffInfoRequired
            // 
            this.checkEditDropoffInfoRequired.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "DropoffInfoRequired", true));
            this.checkEditDropoffInfoRequired.Enabled = false;
            this.checkEditDropoffInfoRequired.Location = new System.Drawing.Point(639, 49);
            this.checkEditDropoffInfoRequired.Margin = new System.Windows.Forms.Padding(2);
            this.checkEditDropoffInfoRequired.Name = "checkEditDropoffInfoRequired";
            this.checkEditDropoffInfoRequired.Properties.Caption = "Dropoff info required";
            this.checkEditDropoffInfoRequired.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.checkEditDropoffInfoRequired.Properties.ValueGrayed = false;
            this.checkEditDropoffInfoRequired.Size = new System.Drawing.Size(126, 19);
            this.checkEditDropoffInfoRequired.TabIndex = 106;
            // 
            // checkEditPickupInfoRequired
            // 
            this.checkEditPickupInfoRequired.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "PickupInfoRequired", true));
            this.checkEditPickupInfoRequired.Enabled = false;
            this.checkEditPickupInfoRequired.Location = new System.Drawing.Point(500, 49);
            this.checkEditPickupInfoRequired.Margin = new System.Windows.Forms.Padding(2);
            this.checkEditPickupInfoRequired.Name = "checkEditPickupInfoRequired";
            this.checkEditPickupInfoRequired.Properties.Caption = "Pickup info required";
            this.checkEditPickupInfoRequired.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.checkEditPickupInfoRequired.Properties.ValueGrayed = false;
            this.checkEditPickupInfoRequired.Size = new System.Drawing.Size(119, 19);
            this.checkEditPickupInfoRequired.TabIndex = 105;
            // 
            // checkEditPassengerWeightRequired
            // 
            this.checkEditPassengerWeightRequired.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "WeightRequired", true));
            this.checkEditPassengerWeightRequired.Location = new System.Drawing.Point(404, 254);
            this.checkEditPassengerWeightRequired.Margin = new System.Windows.Forms.Padding(2);
            this.checkEditPassengerWeightRequired.Name = "checkEditPassengerWeightRequired";
            this.checkEditPassengerWeightRequired.Properties.Caption = "Passenger weight required";
            this.checkEditPassengerWeightRequired.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.checkEditPassengerWeightRequired.Properties.ValueGrayed = false;
            this.checkEditPassengerWeightRequired.Size = new System.Drawing.Size(152, 19);
            this.checkEditPassengerWeightRequired.TabIndex = 104;
            // 
            // checkEditAccountingServiceItem
            // 
            this.checkEditAccountingServiceItem.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "AccountingServiceItem", true));
            this.checkEditAccountingServiceItem.Location = new System.Drawing.Point(171, 150);
            this.checkEditAccountingServiceItem.Margin = new System.Windows.Forms.Padding(2);
            this.checkEditAccountingServiceItem.Name = "checkEditAccountingServiceItem";
            this.checkEditAccountingServiceItem.Properties.Caption = "Accounting service item";
            this.checkEditAccountingServiceItem.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.checkEditAccountingServiceItem.Properties.ValueGrayed = false;
            this.checkEditAccountingServiceItem.Size = new System.Drawing.Size(143, 19);
            this.checkEditAccountingServiceItem.TabIndex = 103;
            // 
            // CheckEditVendorPrepayReqd
            // 
            this.CheckEditVendorPrepayReqd.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "VendorPrepayReqd", true));
            this.CheckEditVendorPrepayReqd.Location = new System.Drawing.Point(409, 126);
            this.CheckEditVendorPrepayReqd.Margin = new System.Windows.Forms.Padding(2);
            this.CheckEditVendorPrepayReqd.Name = "CheckEditVendorPrepayReqd";
            this.CheckEditVendorPrepayReqd.Properties.Caption = "Vendor prepayment required";
            this.CheckEditVendorPrepayReqd.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditVendorPrepayReqd.Properties.ValueGrayed = false;
            this.CheckEditVendorPrepayReqd.Size = new System.Drawing.Size(160, 19);
            this.CheckEditVendorPrepayReqd.TabIndex = 102;
            // 
            // unit_RateCheckEdit
            // 
            this.unit_RateCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Unit_Rate", true));
            this.unit_RateCheckEdit.EnterMoveNextControl = true;
            this.unit_RateCheckEdit.Location = new System.Drawing.Point(312, 24);
            this.unit_RateCheckEdit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.unit_RateCheckEdit.Name = "unit_RateCheckEdit";
            this.unit_RateCheckEdit.Properties.Caption = "Unit Rate";
            this.unit_RateCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.unit_RateCheckEdit.Size = new System.Drawing.Size(72, 19);
            this.unit_RateCheckEdit.TabIndex = 37;
            // 
            // mealsIncludedCheckEdit
            // 
            this.mealsIncludedCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "MealsIncluded", true));
            this.mealsIncludedCheckEdit.EnterMoveNextControl = true;
            this.mealsIncludedCheckEdit.Location = new System.Drawing.Point(324, 149);
            this.mealsIncludedCheckEdit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.mealsIncludedCheckEdit.Name = "mealsIncludedCheckEdit";
            this.mealsIncludedCheckEdit.Properties.Caption = "Meals Included";
            this.mealsIncludedCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.mealsIncludedCheckEdit.Size = new System.Drawing.Size(104, 19);
            this.mealsIncludedCheckEdit.TabIndex = 29;
            // 
            // CheckEditMultTimes
            // 
            this.CheckEditMultTimes.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Multiple_Times", true));
            this.CheckEditMultTimes.EnterMoveNextControl = true;
            this.CheckEditMultTimes.Location = new System.Drawing.Point(54, 98);
            this.CheckEditMultTimes.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CheckEditMultTimes.Name = "CheckEditMultTimes";
            this.CheckEditMultTimes.Properties.Caption = "Multiple Times";
            this.CheckEditMultTimes.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditMultTimes.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.CheckEditMultTimes.Properties.ValueChecked = "1";
            this.CheckEditMultTimes.Properties.ValueGrayed = "0";
            this.CheckEditMultTimes.Properties.ValueUnchecked = "0";
            this.CheckEditMultTimes.Size = new System.Drawing.Size(104, 19);
            this.CheckEditMultTimes.TabIndex = 31;
            this.CheckEditMultTimes.Modified += new System.EventHandler(this.CheckEditMultTimes_Modified);
            // 
            // CheckEditAllowFree
            // 
            this.CheckEditAllowFree.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Allow_Freesell", true));
            this.CheckEditAllowFree.EnterMoveNextControl = true;
            this.CheckEditAllowFree.Location = new System.Drawing.Point(54, 150);
            this.CheckEditAllowFree.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CheckEditAllowFree.Name = "CheckEditAllowFree";
            this.CheckEditAllowFree.Properties.Caption = "Allow Freesell";
            this.CheckEditAllowFree.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditAllowFree.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.CheckEditAllowFree.Size = new System.Drawing.Size(104, 19);
            this.CheckEditAllowFree.TabIndex = 38;
            // 
            // CheckEditClientLogo
            // 
            this.CheckEditClientLogo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "USE_CLIENT_LOGO", true));
            this.CheckEditClientLogo.EditValue = "N";
            this.CheckEditClientLogo.EnterMoveNextControl = true;
            this.CheckEditClientLogo.Location = new System.Drawing.Point(285, 126);
            this.CheckEditClientLogo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CheckEditClientLogo.Name = "CheckEditClientLogo";
            this.CheckEditClientLogo.Properties.Caption = "Allow Client Logo";
            this.CheckEditClientLogo.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditClientLogo.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.CheckEditClientLogo.Properties.ValueChecked = "Y";
            this.CheckEditClientLogo.Properties.ValueGrayed = "N";
            this.CheckEditClientLogo.Properties.ValueUnchecked = "N";
            this.CheckEditClientLogo.Size = new System.Drawing.Size(110, 19);
            this.CheckEditClientLogo.TabIndex = 36;
            // 
            // SpinEditDayPrior
            // 
            this.SpinEditDayPrior.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "VOUCH_DAYS_PRIOR", true));
            this.SpinEditDayPrior.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SpinEditDayPrior.EnterMoveNextControl = true;
            this.SpinEditDayPrior.Location = new System.Drawing.Point(188, 125);
            this.SpinEditDayPrior.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SpinEditDayPrior.Name = "SpinEditDayPrior";
            this.SpinEditDayPrior.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SpinEditDayPrior.Size = new System.Drawing.Size(85, 20);
            this.SpinEditDayPrior.TabIndex = 35;
            this.SpinEditDayPrior.Leave += new System.EventHandler(this.SpinEditDayPrior_Leave);
            // 
            // CheckEditReqDepInfo
            // 
            this.CheckEditReqDepInfo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Require_DepInfo", true));
            this.CheckEditReqDepInfo.EditValue = "N";
            this.CheckEditReqDepInfo.EnterMoveNextControl = true;
            this.CheckEditReqDepInfo.Location = new System.Drawing.Point(502, 74);
            this.CheckEditReqDepInfo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CheckEditReqDepInfo.Name = "CheckEditReqDepInfo";
            this.CheckEditReqDepInfo.Properties.Caption = "Require Departure Info";
            this.CheckEditReqDepInfo.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditReqDepInfo.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.CheckEditReqDepInfo.Properties.ValueChecked = "Y";
            this.CheckEditReqDepInfo.Properties.ValueGrayed = "N";
            this.CheckEditReqDepInfo.Properties.ValueUnchecked = "N";
            this.CheckEditReqDepInfo.Size = new System.Drawing.Size(136, 19);
            this.CheckEditReqDepInfo.TabIndex = 28;
            // 
            // CheckEditReqArvInfo
            // 
            this.CheckEditReqArvInfo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Require_ArvInfo", true));
            this.CheckEditReqArvInfo.EditValue = "N";
            this.CheckEditReqArvInfo.EnterMoveNextControl = true;
            this.CheckEditReqArvInfo.Location = new System.Drawing.Point(359, 74);
            this.CheckEditReqArvInfo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CheckEditReqArvInfo.Name = "CheckEditReqArvInfo";
            this.CheckEditReqArvInfo.Properties.Caption = "Require Arrival Info";
            this.CheckEditReqArvInfo.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditReqArvInfo.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.CheckEditReqArvInfo.Properties.ValueChecked = "Y";
            this.CheckEditReqArvInfo.Properties.ValueGrayed = "N";
            this.CheckEditReqArvInfo.Properties.ValueUnchecked = "N";
            this.CheckEditReqArvInfo.Size = new System.Drawing.Size(123, 19);
            this.CheckEditReqArvInfo.TabIndex = 27;
            // 
            // CheckEditDropoff
            // 
            this.CheckEditDropoff.EnterMoveNextControl = true;
            this.CheckEditDropoff.Location = new System.Drawing.Point(378, 49);
            this.CheckEditDropoff.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CheckEditDropoff.Name = "CheckEditDropoff";
            this.CheckEditDropoff.Properties.Caption = "Includes Dropoff";
            this.CheckEditDropoff.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditDropoff.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.CheckEditDropoff.Size = new System.Drawing.Size(104, 19);
            this.CheckEditDropoff.TabIndex = 26;
            this.CheckEditDropoff.EditValueChanged += new System.EventHandler(this.CheckEditDropoff_EditValueChanged);
            // 
            // CheckEditPickup
            // 
            this.CheckEditPickup.EnterMoveNextControl = true;
            this.CheckEditPickup.Location = new System.Drawing.Point(261, 49);
            this.CheckEditPickup.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CheckEditPickup.Name = "CheckEditPickup";
            this.CheckEditPickup.Properties.Caption = "Includes Pickup";
            this.CheckEditPickup.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditPickup.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.CheckEditPickup.Size = new System.Drawing.Size(104, 19);
            this.CheckEditPickup.TabIndex = 25;
            this.CheckEditPickup.EditValueChanged += new System.EventHandler(this.CheckEditPickup_EditValueChanged);
            // 
            // CheckEditTransferList
            // 
            this.CheckEditTransferList.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Transfer_List", true));
            this.CheckEditTransferList.EditValue = "N";
            this.CheckEditTransferList.EnterMoveNextControl = true;
            this.CheckEditTransferList.Location = new System.Drawing.Point(54, 74);
            this.CheckEditTransferList.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CheckEditTransferList.Name = "CheckEditTransferList";
            this.CheckEditTransferList.Properties.Caption = "Show on Transfer List";
            this.CheckEditTransferList.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditTransferList.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.CheckEditTransferList.Properties.ValueChecked = "Y";
            this.CheckEditTransferList.Properties.ValueGrayed = "N";
            this.CheckEditTransferList.Properties.ValueUnchecked = "N";
            this.CheckEditTransferList.Size = new System.Drawing.Size(135, 19);
            this.CheckEditTransferList.TabIndex = 24;
            // 
            // CheckEditSvcList
            // 
            this.CheckEditSvcList.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "SVC_LIST", true));
            this.CheckEditSvcList.EditValue = "N";
            this.CheckEditSvcList.EnterMoveNextControl = true;
            this.CheckEditSvcList.Location = new System.Drawing.Point(212, 74);
            this.CheckEditSvcList.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CheckEditSvcList.Name = "CheckEditSvcList";
            this.CheckEditSvcList.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.CheckEditSvcList.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.CheckEditSvcList.Properties.Appearance.Options.UseBackColor = true;
            this.CheckEditSvcList.Properties.Appearance.Options.UseForeColor = true;
            this.CheckEditSvcList.Properties.Caption = "Show on Service List";
            this.CheckEditSvcList.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditSvcList.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.CheckEditSvcList.Properties.ValueChecked = "Y";
            this.CheckEditSvcList.Properties.ValueGrayed = "N";
            this.CheckEditSvcList.Properties.ValueUnchecked = "N";
            this.CheckEditSvcList.Size = new System.Drawing.Size(133, 19);
            this.CheckEditSvcList.TabIndex = 23;
            // 
            // SpinEditDuration
            // 
            this.SpinEditDuration.CausesValidation = false;
            this.SpinEditDuration.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Duration", true));
            this.SpinEditDuration.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SpinEditDuration.Location = new System.Drawing.Point(480, 97);
            this.SpinEditDuration.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SpinEditDuration.Name = "SpinEditDuration";
            this.SpinEditDuration.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SpinEditDuration.Properties.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.SpinEditDuration.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            131072});
            this.SpinEditDuration.Size = new System.Drawing.Size(100, 20);
            this.SpinEditDuration.TabIndex = 39;
            this.SpinEditDuration.Leave += new System.EventHandler(this.DurationTimeEdit_Leave);
            // 
            // ImageComboBoxEditTransType
            // 
            this.ImageComboBoxEditTransType.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "TRSFR_TYP", true));
            this.ImageComboBoxEditTransType.Location = new System.Drawing.Point(150, 49);
            this.ImageComboBoxEditTransType.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ImageComboBoxEditTransType.Name = "ImageComboBoxEditTransType";
            this.ImageComboBoxEditTransType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ImageComboBoxEditTransType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("None", "N", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Inbound", "I", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Outbound", "O", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Meet & Greet", "M", -1)});
            this.ImageComboBoxEditTransType.Size = new System.Drawing.Size(100, 20);
            this.ImageComboBoxEditTransType.TabIndex = 21;
            this.ImageComboBoxEditTransType.EditValueChanged += new System.EventHandler(this.ImageComboBoxEditTransType_EditValueChanged);
            this.ImageComboBoxEditTransType.Leave += new System.EventHandler(this.ImageComboBoxEditTransType_Leave);
            // 
            // TextEditDefaultTime
            // 
            this.TextEditDefaultTime.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Default_Time", true));
            this.TextEditDefaultTime.EditValue = null;
            this.TextEditDefaultTime.Location = new System.Drawing.Point(239, 97);
            this.TextEditDefaultTime.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TextEditDefaultTime.Name = "TextEditDefaultTime";
            this.TextEditDefaultTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TextEditDefaultTime.Properties.DisplayFormat.FormatString = "hh:mm tt";
            this.TextEditDefaultTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.TextEditDefaultTime.Properties.EditFormat.FormatString = "hh:mm tt";
            this.TextEditDefaultTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.TextEditDefaultTime.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.TextEditDefaultTime.Properties.Mask.EditMask = "hh:mm tt";
            this.TextEditDefaultTime.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.TextEditDefaultTime.Properties.TimeEditStyle = DevExpress.XtraEditors.Repository.TimeEditStyle.TouchUI;
            this.TextEditDefaultTime.Size = new System.Drawing.Size(100, 20);
            this.TextEditDefaultTime.TabIndex = 32;
            this.TextEditDefaultTime.Leave += new System.EventHandler(this.TextEditDefaultTime_Leave);
            // 
            // xtraTabPageServices
            // 
            this.xtraTabPageServices.Controls.Add(this.PanelControlServicesTab);
            this.xtraTabPageServices.Margin = new System.Windows.Forms.Padding(4);
            this.xtraTabPageServices.Name = "xtraTabPageServices";
            this.xtraTabPageServices.PageVisible = false;
            this.xtraTabPageServices.Size = new System.Drawing.Size(902, 585);
            this.xtraTabPageServices.Text = "Services";
            // 
            // PanelControlServicesTab
            // 
            this.PanelControlServicesTab.AutoSize = true;
            this.PanelControlServicesTab.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PanelControlServicesTab.Controls.Add(this.TextEditIncl6);
            this.PanelControlServicesTab.Controls.Add(this.TextEditIncl1);
            this.PanelControlServicesTab.Controls.Add(this.TextEditIncl3);
            this.PanelControlServicesTab.Controls.Add(this.TextEditIncl5);
            this.PanelControlServicesTab.Controls.Add(this.TextEditIncl4);
            this.PanelControlServicesTab.Controls.Add(this.TextEditIncl2);
            this.PanelControlServicesTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelControlServicesTab.Location = new System.Drawing.Point(0, 0);
            this.PanelControlServicesTab.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.PanelControlServicesTab.Name = "PanelControlServicesTab";
            this.PanelControlServicesTab.Size = new System.Drawing.Size(902, 585);
            this.PanelControlServicesTab.TabIndex = 0;
            // 
            // TextEditIncl6
            // 
            this.TextEditIncl6.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "INCL6", true));
            this.TextEditIncl6.EnterMoveNextControl = true;
            this.TextEditIncl6.Location = new System.Drawing.Point(58, 267);
            this.TextEditIncl6.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TextEditIncl6.Name = "TextEditIncl6";
            this.TextEditIncl6.Properties.MaxLength = 50;
            this.TextEditIncl6.Size = new System.Drawing.Size(546, 20);
            this.TextEditIncl6.TabIndex = 40;
            this.TextEditIncl6.Leave += new System.EventHandler(this.TextEditIncl6_Leave);
            // 
            // TextEditIncl1
            // 
            this.TextEditIncl1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "INCL1", true));
            this.TextEditIncl1.EnterMoveNextControl = true;
            this.TextEditIncl1.Location = new System.Drawing.Point(58, 67);
            this.TextEditIncl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TextEditIncl1.Name = "TextEditIncl1";
            this.TextEditIncl1.Properties.MaxLength = 50;
            this.TextEditIncl1.Size = new System.Drawing.Size(546, 20);
            this.TextEditIncl1.TabIndex = 35;
            this.TextEditIncl1.Leave += new System.EventHandler(this.TextEditIncl1_Leave);
            // 
            // TextEditIncl3
            // 
            this.TextEditIncl3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "INCL3", true));
            this.TextEditIncl3.EnterMoveNextControl = true;
            this.TextEditIncl3.Location = new System.Drawing.Point(58, 148);
            this.TextEditIncl3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TextEditIncl3.Name = "TextEditIncl3";
            this.TextEditIncl3.Properties.MaxLength = 50;
            this.TextEditIncl3.Size = new System.Drawing.Size(546, 20);
            this.TextEditIncl3.TabIndex = 37;
            this.TextEditIncl3.Leave += new System.EventHandler(this.TextEditIncl3_Leave);
            // 
            // TextEditIncl5
            // 
            this.TextEditIncl5.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "INCL5", true));
            this.TextEditIncl5.EnterMoveNextControl = true;
            this.TextEditIncl5.Location = new System.Drawing.Point(58, 223);
            this.TextEditIncl5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TextEditIncl5.Name = "TextEditIncl5";
            this.TextEditIncl5.Properties.MaxLength = 50;
            this.TextEditIncl5.Size = new System.Drawing.Size(546, 20);
            this.TextEditIncl5.TabIndex = 39;
            this.TextEditIncl5.Leave += new System.EventHandler(this.TextEditIncl5_Leave);
            // 
            // TextEditIncl4
            // 
            this.TextEditIncl4.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "INCL4", true));
            this.TextEditIncl4.EnterMoveNextControl = true;
            this.TextEditIncl4.Location = new System.Drawing.Point(58, 186);
            this.TextEditIncl4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TextEditIncl4.Name = "TextEditIncl4";
            this.TextEditIncl4.Properties.MaxLength = 50;
            this.TextEditIncl4.Size = new System.Drawing.Size(546, 20);
            this.TextEditIncl4.TabIndex = 38;
            this.TextEditIncl4.Leave += new System.EventHandler(this.TextEditIncl4_Leave);
            // 
            // TextEditIncl2
            // 
            this.TextEditIncl2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "INCL2", true));
            this.TextEditIncl2.EnterMoveNextControl = true;
            this.TextEditIncl2.Location = new System.Drawing.Point(58, 110);
            this.TextEditIncl2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TextEditIncl2.Name = "TextEditIncl2";
            this.TextEditIncl2.Properties.MaxLength = 50;
            this.TextEditIncl2.Size = new System.Drawing.Size(546, 20);
            this.TextEditIncl2.TabIndex = 36;
            this.TextEditIncl2.Leave += new System.EventHandler(this.TextEditIncl2_Leave);
            // 
            // xtraTabPageRoutes
            // 
            this.xtraTabPageRoutes.Controls.Add(this.panelControl1);
            this.xtraTabPageRoutes.Margin = new System.Windows.Forms.Padding(2);
            this.xtraTabPageRoutes.Name = "xtraTabPageRoutes";
            this.xtraTabPageRoutes.PageEnabled = false;
            this.xtraTabPageRoutes.Size = new System.Drawing.Size(902, 585);
            this.xtraTabPageRoutes.Text = "Routes";
            // 
            // panelControl1
            // 
            this.panelControl1.AutoSize = true;
            this.panelControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelControl1.Controls.Add(this.simpleButtonRemoveRoute);
            this.panelControl1.Controls.Add(this.simpleButtonAddRoute);
            this.panelControl1.Controls.Add(this.GridControlRoutes);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(902, 585);
            this.panelControl1.TabIndex = 0;
            // 
            // simpleButtonRemoveRoute
            // 
            this.simpleButtonRemoveRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButtonRemoveRoute.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonRemoveRoute.ImageOptions.Image")));
            this.simpleButtonRemoveRoute.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonRemoveRoute.Location = new System.Drawing.Point(867, 228);
            this.simpleButtonRemoveRoute.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.simpleButtonRemoveRoute.Name = "simpleButtonRemoveRoute";
            this.simpleButtonRemoveRoute.Size = new System.Drawing.Size(38, 43);
            this.simpleButtonRemoveRoute.TabIndex = 34;
            this.simpleButtonRemoveRoute.TabStop = false;
            this.simpleButtonRemoveRoute.Text = "simpleButton4";
            this.simpleButtonRemoveRoute.Click += new System.EventHandler(this.SimpleButtonRemoveRoute_Click);
            // 
            // simpleButtonAddRoute
            // 
            this.simpleButtonAddRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButtonAddRoute.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonAddRoute.ImageOptions.Image")));
            this.simpleButtonAddRoute.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonAddRoute.Location = new System.Drawing.Point(867, 179);
            this.simpleButtonAddRoute.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.simpleButtonAddRoute.Name = "simpleButtonAddRoute";
            this.simpleButtonAddRoute.Size = new System.Drawing.Size(38, 43);
            this.simpleButtonAddRoute.TabIndex = 35;
            this.simpleButtonAddRoute.TabStop = false;
            this.simpleButtonAddRoute.Text = "simpleButton3";
            this.simpleButtonAddRoute.Click += new System.EventHandler(this.SimpleButtonAddRoute_Click);
            // 
            // GridControlRoutes
            // 
            this.GridControlRoutes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridControlRoutes.CausesValidation = false;
            this.GridControlRoutes.DataSource = this.BindingSourceCompBusRoutes;
            this.GridControlRoutes.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GridControlRoutes.Location = new System.Drawing.Point(23, 23);
            this.GridControlRoutes.MainView = this.GridViewRoutes;
            this.GridControlRoutes.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GridControlRoutes.Name = "GridControlRoutes";
            this.GridControlRoutes.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEditBusRoutes,
            this.repositoryItemCheckEditInactive,
            this.repositoryItemLookUpEditStop});
            this.GridControlRoutes.Size = new System.Drawing.Size(821, 482);
            this.GridControlRoutes.TabIndex = 32;
            this.GridControlRoutes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewRoutes,
            this.gridView13});
            // 
            // GridViewRoutes
            // 
            this.GridViewRoutes.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID1,
            this.colComp_Code,
            this.colBusRoute_ID,
            this.colCPRates_ID,
            this.colCOMP,
            this.colBusRoute,
            this.colCPRATES1,
            this.gridColumnStartDate,
            this.gridColumnEndDate,
            this.gridColumnFromStop,
            this.gridColumnToStop,
            this.gridColumnInactive});
            this.GridViewRoutes.DetailHeight = 182;
            this.GridViewRoutes.FixedLineWidth = 1;
            this.GridViewRoutes.GridControl = this.GridControlRoutes;
            this.GridViewRoutes.LevelIndent = 0;
            this.GridViewRoutes.Name = "GridViewRoutes";
            this.GridViewRoutes.OptionsView.ShowGroupPanel = false;
            this.GridViewRoutes.PreviewIndent = 0;
            this.GridViewRoutes.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.GridViewRoutes_CustomRowCellEdit);
            this.GridViewRoutes.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.GridViewRoutes_CellValueChanged);
            this.GridViewRoutes.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.GridViewRoutes_InvalidRowException);
            this.GridViewRoutes.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.GridViewRoutes_ValidateRow);
            this.GridViewRoutes.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.GridViewRoutes_CustomUnboundColumnData);
            // 
            // colID1
            // 
            this.colID1.FieldName = "ID";
            this.colID1.MinWidth = 10;
            this.colID1.Name = "colID1";
            this.colID1.Width = 37;
            // 
            // colComp_Code
            // 
            this.colComp_Code.FieldName = "Comp_Code";
            this.colComp_Code.MinWidth = 10;
            this.colComp_Code.Name = "colComp_Code";
            this.colComp_Code.Width = 37;
            // 
            // colBusRoute_ID
            // 
            this.colBusRoute_ID.Caption = "Bus Route";
            this.colBusRoute_ID.ColumnEdit = this.repositoryItemLookUpEditBusRoutes;
            this.colBusRoute_ID.FieldName = "BusRoute_ID";
            this.colBusRoute_ID.MinWidth = 10;
            this.colBusRoute_ID.Name = "colBusRoute_ID";
            this.colBusRoute_ID.Visible = true;
            this.colBusRoute_ID.VisibleIndex = 0;
            this.colBusRoute_ID.Width = 205;
            // 
            // repositoryItemLookUpEditBusRoutes
            // 
            this.repositoryItemLookUpEditBusRoutes.AutoHeight = false;
            this.repositoryItemLookUpEditBusRoutes.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditBusRoutes.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 40, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 95, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StartDate", "Start Date", 40, DevExpress.Utils.FormatType.DateTime, "dd-MMM-yyyy", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EndDate", "End Date", 40, DevExpress.Utils.FormatType.DateTime, "dd-MMM-yyyy", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Inactive", "Inactive", 25, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.repositoryItemLookUpEditBusRoutes.DataSource = this.BindingSourceBusRoutes;
            this.repositoryItemLookUpEditBusRoutes.DisplayMember = "Name";
            this.repositoryItemLookUpEditBusRoutes.Name = "repositoryItemLookUpEditBusRoutes";
            this.repositoryItemLookUpEditBusRoutes.NullText = "";
            this.repositoryItemLookUpEditBusRoutes.ValueMember = "ID";
            // 
            // colCPRates_ID
            // 
            this.colCPRates_ID.FieldName = "CPRates_ID";
            this.colCPRates_ID.MinWidth = 10;
            this.colCPRates_ID.Name = "colCPRates_ID";
            this.colCPRates_ID.Width = 37;
            // 
            // colCOMP
            // 
            this.colCOMP.FieldName = "COMP";
            this.colCOMP.MinWidth = 10;
            this.colCOMP.Name = "colCOMP";
            this.colCOMP.Width = 37;
            // 
            // colBusRoute
            // 
            this.colBusRoute.FieldName = "BusRoute";
            this.colBusRoute.MinWidth = 10;
            this.colBusRoute.Name = "colBusRoute";
            this.colBusRoute.Width = 37;
            // 
            // colCPRATES1
            // 
            this.colCPRATES1.FieldName = "CPRATES";
            this.colCPRATES1.MinWidth = 10;
            this.colCPRATES1.Name = "colCPRATES1";
            this.colCPRATES1.Width = 37;
            // 
            // gridColumnStartDate
            // 
            this.gridColumnStartDate.Caption = "Start Date";
            this.gridColumnStartDate.DisplayFormat.FormatString = "dd-MMM-yyyy";
            this.gridColumnStartDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnStartDate.FieldName = "gridColumnStartDate";
            this.gridColumnStartDate.MinWidth = 10;
            this.gridColumnStartDate.Name = "gridColumnStartDate";
            this.gridColumnStartDate.OptionsColumn.AllowEdit = false;
            this.gridColumnStartDate.OptionsColumn.ReadOnly = true;
            this.gridColumnStartDate.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.gridColumnStartDate.Visible = true;
            this.gridColumnStartDate.VisibleIndex = 1;
            this.gridColumnStartDate.Width = 65;
            // 
            // gridColumnEndDate
            // 
            this.gridColumnEndDate.Caption = "End Date";
            this.gridColumnEndDate.DisplayFormat.FormatString = "dd-MMM-yyyy";
            this.gridColumnEndDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnEndDate.FieldName = "gridColumnEndDate";
            this.gridColumnEndDate.MinWidth = 10;
            this.gridColumnEndDate.Name = "gridColumnEndDate";
            this.gridColumnEndDate.OptionsColumn.AllowEdit = false;
            this.gridColumnEndDate.OptionsColumn.ReadOnly = true;
            this.gridColumnEndDate.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.gridColumnEndDate.Visible = true;
            this.gridColumnEndDate.VisibleIndex = 2;
            this.gridColumnEndDate.Width = 59;
            // 
            // gridColumnFromStop
            // 
            this.gridColumnFromStop.Caption = "From Stop";
            this.gridColumnFromStop.ColumnEdit = this.repositoryItemLookUpEditStop;
            this.gridColumnFromStop.FieldName = "BusRouteStop_ID_First";
            this.gridColumnFromStop.MinWidth = 10;
            this.gridColumnFromStop.Name = "gridColumnFromStop";
            this.gridColumnFromStop.Visible = true;
            this.gridColumnFromStop.VisibleIndex = 3;
            this.gridColumnFromStop.Width = 107;
            // 
            // repositoryItemLookUpEditStop
            // 
            this.repositoryItemLookUpEditStop.AutoHeight = false;
            this.repositoryItemLookUpEditStop.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditStop.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Type", "Type", 51, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Code", 52, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.repositoryItemLookUpEditStop.DataSource = this.BindingSourceBusRouteStop;
            this.repositoryItemLookUpEditStop.DisplayMember = "Code";
            this.repositoryItemLookUpEditStop.KeyMember = "ID";
            this.repositoryItemLookUpEditStop.Name = "repositoryItemLookUpEditStop";
            this.repositoryItemLookUpEditStop.NullText = "";
            // 
            // gridColumnToStop
            // 
            this.gridColumnToStop.Caption = "To Stop";
            this.gridColumnToStop.ColumnEdit = this.repositoryItemLookUpEditStop;
            this.gridColumnToStop.FieldName = "BusRouteStop_ID_Last";
            this.gridColumnToStop.MinWidth = 10;
            this.gridColumnToStop.Name = "gridColumnToStop";
            this.gridColumnToStop.Visible = true;
            this.gridColumnToStop.VisibleIndex = 4;
            this.gridColumnToStop.Width = 93;
            // 
            // gridColumnInactive
            // 
            this.gridColumnInactive.Caption = "Inactive";
            this.gridColumnInactive.ColumnEdit = this.repositoryItemCheckEditInactive;
            this.gridColumnInactive.FieldName = "gridColumnInactive";
            this.gridColumnInactive.MinWidth = 10;
            this.gridColumnInactive.Name = "gridColumnInactive";
            this.gridColumnInactive.OptionsColumn.AllowEdit = false;
            this.gridColumnInactive.OptionsColumn.ReadOnly = true;
            this.gridColumnInactive.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.gridColumnInactive.Visible = true;
            this.gridColumnInactive.VisibleIndex = 5;
            this.gridColumnInactive.Width = 55;
            // 
            // repositoryItemCheckEditInactive
            // 
            this.repositoryItemCheckEditInactive.AutoHeight = false;
            this.repositoryItemCheckEditInactive.Caption = "Check";
            this.repositoryItemCheckEditInactive.Name = "repositoryItemCheckEditInactive";
            // 
            // gridView13
            // 
            this.gridView13.DetailHeight = 182;
            this.gridView13.FixedLineWidth = 1;
            this.gridView13.GridControl = this.GridControlRoutes;
            this.gridView13.LevelIndent = 0;
            this.gridView13.Name = "gridView13";
            this.gridView13.PreviewIndent = 0;
            // 
            // xtraTabPageTransferPoints
            // 
            this.xtraTabPageTransferPoints.Controls.Add(this.panelControl4);
            this.xtraTabPageTransferPoints.Margin = new System.Windows.Forms.Padding(4);
            this.xtraTabPageTransferPoints.Name = "xtraTabPageTransferPoints";
            this.xtraTabPageTransferPoints.PageEnabled = false;
            this.xtraTabPageTransferPoints.Size = new System.Drawing.Size(902, 585);
            this.xtraTabPageTransferPoints.Text = "Transfer Points";
            // 
            // panelControl4
            // 
            this.panelControl4.AutoSize = true;
            this.panelControl4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelControl4.Controls.Add(this.ButtonDelRow);
            this.panelControl4.Controls.Add(this.ButtonAddRow);
            this.panelControl4.Controls.Add(this.GridControlTransferPoints);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(0, 0);
            this.panelControl4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(902, 585);
            this.panelControl4.TabIndex = 0;
            // 
            // ButtonDelRow
            // 
            this.ButtonDelRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonDelRow.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonDelRow.ImageOptions.Image")));
            this.ButtonDelRow.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ButtonDelRow.Location = new System.Drawing.Point(851, 238);
            this.ButtonDelRow.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ButtonDelRow.Name = "ButtonDelRow";
            this.ButtonDelRow.Size = new System.Drawing.Size(36, 46);
            this.ButtonDelRow.TabIndex = 106;
            this.ButtonDelRow.TabStop = false;
            this.ButtonDelRow.Text = "simpleButton4";
            this.ButtonDelRow.Click += new System.EventHandler(this.ButtonDelRow_Click);
            // 
            // ButtonAddRow
            // 
            this.ButtonAddRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonAddRow.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonAddRow.ImageOptions.Image")));
            this.ButtonAddRow.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ButtonAddRow.Location = new System.Drawing.Point(851, 188);
            this.ButtonAddRow.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ButtonAddRow.Name = "ButtonAddRow";
            this.ButtonAddRow.Size = new System.Drawing.Size(36, 46);
            this.ButtonAddRow.TabIndex = 0;
            this.ButtonAddRow.TabStop = false;
            this.ButtonAddRow.Text = "simpleButton3";
            this.ButtonAddRow.Click += new System.EventHandler(this.ButtonAddRow_Click);
            // 
            // GridControlTransferPoints
            // 
            this.GridControlTransferPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridControlTransferPoints.CausesValidation = false;
            this.GridControlTransferPoints.DataSource = this.BindingSourceBusTable;
            this.GridControlTransferPoints.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GridControlTransferPoints.Location = new System.Drawing.Point(28, 32);
            this.GridControlTransferPoints.MainView = this.GridViewTransferPoints;
            this.GridControlTransferPoints.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GridControlTransferPoints.Name = "GridControlTransferPoints";
            this.GridControlTransferPoints.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RepositoryItemImageComboBoxPickDrop,
            this.repositoryItemButtonEditDate,
            this.RepositoryItemSearchLookupEditLocation,
            this.repositoryItemImageComboBoxRoutes,
            this.RepositoryItemTimeEditServiceTime,
            this.RepositoryItemSearchLookUpEditCat,
            this.repositoryItemComboBoxLocType,
            this.repositoryItemCheckEditLocationExclusion});
            this.GridControlTransferPoints.Size = new System.Drawing.Size(811, 500);
            this.GridControlTransferPoints.TabIndex = 31;
            this.GridControlTransferPoints.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewTransferPoints,
            this.gridView12});
            this.GridControlTransferPoints.Leave += new System.EventHandler(this.GridControlTransferPoints_Leave);
            // 
            // GridViewTransferPoints
            // 
            this.GridViewTransferPoints.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDisplayName,
            this.ColumnType,
            this.ColumnCode1,
            this.ColumnPickDrop,
            this.ColumnStartDate,
            this.ColumnLocation,
            this.ColumnDepartureTime,
            this.ColumnLastUpd,
            this.ColumnUpdInit,
            this.ColumnInOut,
            this.ColumnEndDate,
            this.ColumnLocationType,
            this.ColumnCarOffice,
            this.ColumnArrivalTime,
            this.ColumnExclusion,
            this.colID,
            this.ColumnRoute,
            this.gridColumnCat,
            this.gridColumnServiceTime});
            this.GridViewTransferPoints.DetailHeight = 182;
            this.GridViewTransferPoints.FixedLineWidth = 1;
            this.GridViewTransferPoints.GridControl = this.GridControlTransferPoints;
            this.GridViewTransferPoints.LevelIndent = 0;
            this.GridViewTransferPoints.Name = "GridViewTransferPoints";
            this.GridViewTransferPoints.OptionsView.ShowGroupPanel = false;
            this.GridViewTransferPoints.OptionsView.ShowIndicator = false;
            this.GridViewTransferPoints.PreviewIndent = 0;
            this.GridViewTransferPoints.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.GridViewTransferPoints_CustomRowCellEdit);
            this.GridViewTransferPoints.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewTransferPoints_FocusedRowChanged);
            this.GridViewTransferPoints.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.GridViewTransferPoints_CellValueChanged);
            this.GridViewTransferPoints.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.GridViewTransferPoints_InvalidRowException);
            this.GridViewTransferPoints.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.GridViewTransferPoints_ValidateRow);
            this.GridViewTransferPoints.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.GridViewTransferPoints_CustomColumnDisplayText);
            // 
            // colDisplayName
            // 
            this.colDisplayName.FieldName = "DisplayName";
            this.colDisplayName.MinWidth = 10;
            this.colDisplayName.Name = "colDisplayName";
            this.colDisplayName.OptionsColumn.ReadOnly = true;
            this.colDisplayName.Width = 37;
            // 
            // ColumnType
            // 
            this.ColumnType.FieldName = "TYPE";
            this.ColumnType.MinWidth = 10;
            this.ColumnType.Name = "ColumnType";
            this.ColumnType.Width = 37;
            // 
            // ColumnCode1
            // 
            this.ColumnCode1.FieldName = "CODE";
            this.ColumnCode1.MinWidth = 10;
            this.ColumnCode1.Name = "ColumnCode1";
            this.ColumnCode1.Width = 37;
            // 
            // ColumnPickDrop
            // 
            this.ColumnPickDrop.Caption = "Pick/Drop";
            this.ColumnPickDrop.ColumnEdit = this.RepositoryItemImageComboBoxPickDrop;
            this.ColumnPickDrop.FieldName = "PUP_DRP";
            this.ColumnPickDrop.MinWidth = 10;
            this.ColumnPickDrop.Name = "ColumnPickDrop";
            this.ColumnPickDrop.Visible = true;
            this.ColumnPickDrop.VisibleIndex = 0;
            this.ColumnPickDrop.Width = 55;
            // 
            // RepositoryItemImageComboBoxPickDrop
            // 
            this.RepositoryItemImageComboBoxPickDrop.AutoHeight = false;
            this.RepositoryItemImageComboBoxPickDrop.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemImageComboBoxPickDrop.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Pickup", "P", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Dropoff", "D", -1)});
            this.RepositoryItemImageComboBoxPickDrop.Name = "RepositoryItemImageComboBoxPickDrop";
            // 
            // ColumnStartDate
            // 
            this.ColumnStartDate.Caption = "Start Date";
            this.ColumnStartDate.ColumnEdit = this.repositoryItemButtonEditDate;
            this.ColumnStartDate.FieldName = "DATE";
            this.ColumnStartDate.MinWidth = 10;
            this.ColumnStartDate.Name = "ColumnStartDate";
            this.ColumnStartDate.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.ColumnStartDate.Visible = true;
            this.ColumnStartDate.VisibleIndex = 1;
            this.ColumnStartDate.Width = 77;
            // 
            // repositoryItemButtonEditDate
            // 
            this.repositoryItemButtonEditDate.AutoHeight = false;
            this.repositoryItemButtonEditDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEditDate.Name = "repositoryItemButtonEditDate";
            this.repositoryItemButtonEditDate.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.RepositoryItemButtonEditDate_ButtonClick);
            // 
            // ColumnLocation
            // 
            this.ColumnLocation.Caption = "Location";
            this.ColumnLocation.ColumnEdit = this.RepositoryItemSearchLookupEditLocation;
            this.ColumnLocation.FieldName = "LOCATION";
            this.ColumnLocation.MinWidth = 10;
            this.ColumnLocation.Name = "ColumnLocation";
            this.ColumnLocation.Visible = true;
            this.ColumnLocation.VisibleIndex = 4;
            this.ColumnLocation.Width = 141;
            // 
            // RepositoryItemSearchLookupEditLocation
            // 
            this.RepositoryItemSearchLookupEditLocation.AutoHeight = false;
            this.RepositoryItemSearchLookupEditLocation.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.RepositoryItemSearchLookupEditLocation.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemSearchLookupEditLocation.DataSource = this.BindingSourceCodeName;
            this.RepositoryItemSearchLookupEditLocation.DisplayMember = "DisplayName";
            this.RepositoryItemSearchLookupEditLocation.HideSelection = false;
            this.RepositoryItemSearchLookupEditLocation.Name = "RepositoryItemSearchLookupEditLocation";
            this.RepositoryItemSearchLookupEditLocation.NullText = "";
            this.RepositoryItemSearchLookupEditLocation.PopupView = this.repositoryItemImageComboboxLocationView;
            this.RepositoryItemSearchLookupEditLocation.ValueMember = "Code";
            this.RepositoryItemSearchLookupEditLocation.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            this.RepositoryItemSearchLookupEditLocation.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PopupForm_KeyUp);
            // 
            // repositoryItemImageComboboxLocationView
            // 
            this.repositoryItemImageComboboxLocationView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode17,
            this.colName12});
            this.repositoryItemImageComboboxLocationView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemImageComboboxLocationView.Name = "repositoryItemImageComboboxLocationView";
            this.repositoryItemImageComboboxLocationView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemImageComboboxLocationView.OptionsView.ShowGroupPanel = false;
            this.repositoryItemImageComboboxLocationView.OptionsView.ShowIndicator = false;
            // 
            // colCode17
            // 
            this.colCode17.FieldName = "Code";
            this.colCode17.Name = "colCode17";
            this.colCode17.Visible = true;
            this.colCode17.VisibleIndex = 0;
            // 
            // colName12
            // 
            this.colName12.FieldName = "Name";
            this.colName12.Name = "colName12";
            this.colName12.Visible = true;
            this.colName12.VisibleIndex = 1;
            // 
            // ColumnDepartureTime
            // 
            this.ColumnDepartureTime.Caption = "Dep Time";
            this.ColumnDepartureTime.FieldName = "TIME";
            this.ColumnDepartureTime.MinWidth = 10;
            this.ColumnDepartureTime.Name = "ColumnDepartureTime";
            this.ColumnDepartureTime.Visible = true;
            this.ColumnDepartureTime.VisibleIndex = 6;
            this.ColumnDepartureTime.Width = 58;
            // 
            // ColumnLastUpd
            // 
            this.ColumnLastUpd.FieldName = "LAST_UPD";
            this.ColumnLastUpd.MinWidth = 10;
            this.ColumnLastUpd.Name = "ColumnLastUpd";
            this.ColumnLastUpd.Width = 37;
            // 
            // ColumnUpdInit
            // 
            this.ColumnUpdInit.FieldName = "UPD_INIT";
            this.ColumnUpdInit.MinWidth = 10;
            this.ColumnUpdInit.Name = "ColumnUpdInit";
            this.ColumnUpdInit.Width = 37;
            // 
            // ColumnInOut
            // 
            this.ColumnInOut.Caption = "Direction";
            this.ColumnInOut.FieldName = "In_Out";
            this.ColumnInOut.MinWidth = 10;
            this.ColumnInOut.Name = "ColumnInOut";
            this.ColumnInOut.Width = 27;
            // 
            // ColumnEndDate
            // 
            this.ColumnEndDate.Caption = "End Date";
            this.ColumnEndDate.ColumnEdit = this.repositoryItemButtonEditDate;
            this.ColumnEndDate.FieldName = "EndDate";
            this.ColumnEndDate.MinWidth = 10;
            this.ColumnEndDate.Name = "ColumnEndDate";
            this.ColumnEndDate.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.ColumnEndDate.Visible = true;
            this.ColumnEndDate.VisibleIndex = 2;
            this.ColumnEndDate.Width = 77;
            // 
            // ColumnLocationType
            // 
            this.ColumnLocationType.Caption = "Type";
            this.ColumnLocationType.ColumnEdit = this.repositoryItemComboBoxLocType;
            this.ColumnLocationType.FieldName = "LocationType";
            this.ColumnLocationType.MinWidth = 10;
            this.ColumnLocationType.Name = "ColumnLocationType";
            this.ColumnLocationType.Visible = true;
            this.ColumnLocationType.VisibleIndex = 3;
            this.ColumnLocationType.Width = 47;
            // 
            // repositoryItemComboBoxLocType
            // 
            this.repositoryItemComboBoxLocType.AutoHeight = false;
            this.repositoryItemComboBoxLocType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBoxLocType.Items.AddRange(new object[] {
            "HTL",
            "WAY",
            "CTY"});
            this.repositoryItemComboBoxLocType.Name = "repositoryItemComboBoxLocType";
            // 
            // ColumnCarOffice
            // 
            this.ColumnCarOffice.Caption = "Car Office";
            this.ColumnCarOffice.FieldName = "CarOffice";
            this.ColumnCarOffice.MinWidth = 10;
            this.ColumnCarOffice.Name = "ColumnCarOffice";
            this.ColumnCarOffice.Width = 102;
            // 
            // ColumnArrivalTime
            // 
            this.ColumnArrivalTime.Caption = "Arv Time";
            this.ColumnArrivalTime.FieldName = "EndTime";
            this.ColumnArrivalTime.MinWidth = 10;
            this.ColumnArrivalTime.Name = "ColumnArrivalTime";
            this.ColumnArrivalTime.Visible = true;
            this.ColumnArrivalTime.VisibleIndex = 7;
            this.ColumnArrivalTime.Width = 57;
            // 
            // ColumnExclusion
            // 
            this.ColumnExclusion.ColumnEdit = this.repositoryItemCheckEditLocationExclusion;
            this.ColumnExclusion.FieldName = "Exclusion";
            this.ColumnExclusion.MinWidth = 10;
            this.ColumnExclusion.Name = "ColumnExclusion";
            this.ColumnExclusion.Visible = true;
            this.ColumnExclusion.VisibleIndex = 5;
            this.ColumnExclusion.Width = 51;
            // 
            // repositoryItemCheckEditLocationExclusion
            // 
            this.repositoryItemCheckEditLocationExclusion.AutoHeight = false;
            this.repositoryItemCheckEditLocationExclusion.Name = "repositoryItemCheckEditLocationExclusion";
            this.repositoryItemCheckEditLocationExclusion.ReadOnly = true;
            this.repositoryItemCheckEditLocationExclusion.ValueChecked = "1";
            this.repositoryItemCheckEditLocationExclusion.ValueUnchecked = "0";
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.MinWidth = 10;
            this.colID.Name = "colID";
            this.colID.Width = 37;
            // 
            // ColumnRoute
            // 
            this.ColumnRoute.Caption = "Route";
            this.ColumnRoute.ColumnEdit = this.repositoryItemImageComboBoxRoutes;
            this.ColumnRoute.FieldName = "CompBusRoute_ID";
            this.ColumnRoute.MinWidth = 10;
            this.ColumnRoute.Name = "ColumnRoute";
            this.ColumnRoute.Visible = true;
            this.ColumnRoute.VisibleIndex = 8;
            this.ColumnRoute.Width = 111;
            // 
            // repositoryItemImageComboBoxRoutes
            // 
            this.repositoryItemImageComboBoxRoutes.AutoHeight = false;
            this.repositoryItemImageComboBoxRoutes.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBoxRoutes.HideSelection = false;
            this.repositoryItemImageComboBoxRoutes.Name = "repositoryItemImageComboBoxRoutes";
            // 
            // gridColumnCat
            // 
            this.gridColumnCat.Caption = "Category";
            this.gridColumnCat.ColumnEdit = this.RepositoryItemSearchLookUpEditCat;
            this.gridColumnCat.FieldName = "CAT";
            this.gridColumnCat.MinWidth = 10;
            this.gridColumnCat.Name = "gridColumnCat";
            this.gridColumnCat.Visible = true;
            this.gridColumnCat.VisibleIndex = 9;
            this.gridColumnCat.Width = 52;
            // 
            // RepositoryItemSearchLookUpEditCat
            // 
            this.RepositoryItemSearchLookUpEditCat.AutoHeight = false;
            this.RepositoryItemSearchLookUpEditCat.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.RepositoryItemSearchLookUpEditCat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemSearchLookUpEditCat.DataSource = this.BindingSourceCodeName;
            this.RepositoryItemSearchLookUpEditCat.DisplayMember = "DisplayName";
            this.RepositoryItemSearchLookUpEditCat.Name = "RepositoryItemSearchLookUpEditCat";
            this.RepositoryItemSearchLookUpEditCat.NullText = "";
            this.RepositoryItemSearchLookUpEditCat.PopupView = this.repositoryItemSearchLookUpEdit1View;
            this.RepositoryItemSearchLookUpEditCat.ValueMember = "Code";
            this.RepositoryItemSearchLookUpEditCat.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            this.RepositoryItemSearchLookUpEditCat.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PopupForm_KeyUp);
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode16,
            this.colName11});
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowIndicator = false;
            // 
            // colCode16
            // 
            this.colCode16.FieldName = "Code";
            this.colCode16.Name = "colCode16";
            this.colCode16.Visible = true;
            this.colCode16.VisibleIndex = 0;
            // 
            // colName11
            // 
            this.colName11.FieldName = "Name";
            this.colName11.Name = "colName11";
            this.colName11.Visible = true;
            this.colName11.VisibleIndex = 1;
            // 
            // gridColumnServiceTime
            // 
            this.gridColumnServiceTime.Caption = "Service time";
            this.gridColumnServiceTime.ColumnEdit = this.RepositoryItemTimeEditServiceTime;
            this.gridColumnServiceTime.FieldName = "ServiceTime";
            this.gridColumnServiceTime.MinWidth = 10;
            this.gridColumnServiceTime.Name = "gridColumnServiceTime";
            this.gridColumnServiceTime.Visible = true;
            this.gridColumnServiceTime.VisibleIndex = 10;
            this.gridColumnServiceTime.Width = 60;
            // 
            // RepositoryItemTimeEditServiceTime
            // 
            this.RepositoryItemTimeEditServiceTime.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.RepositoryItemTimeEditServiceTime.AutoHeight = false;
            this.RepositoryItemTimeEditServiceTime.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemTimeEditServiceTime.DisplayFormat.FormatString = "h:mm tt";
            this.RepositoryItemTimeEditServiceTime.Mask.EditMask = "hh:mm tt";
            this.RepositoryItemTimeEditServiceTime.Mask.UseMaskAsDisplayFormat = true;
            this.RepositoryItemTimeEditServiceTime.Name = "RepositoryItemTimeEditServiceTime";
            // 
            // gridView12
            // 
            this.gridView12.DetailHeight = 182;
            this.gridView12.FixedLineWidth = 1;
            this.gridView12.GridControl = this.GridControlTransferPoints;
            this.gridView12.LevelIndent = 0;
            this.gridView12.Name = "gridView12";
            this.gridView12.PreviewIndent = 0;
            // 
            // xtraTabPageMemberships
            // 
            this.xtraTabPageMemberships.Controls.Add(this.panelControl2);
            this.xtraTabPageMemberships.Margin = new System.Windows.Forms.Padding(2);
            this.xtraTabPageMemberships.Name = "xtraTabPageMemberships";
            this.xtraTabPageMemberships.Size = new System.Drawing.Size(902, 585);
            this.xtraTabPageMemberships.Text = "Memberships";
            // 
            // panelControl2
            // 
            this.panelControl2.AutoSize = true;
            this.panelControl2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelControl2.Controls.Add(this.GridControlDetail);
            this.panelControl2.Controls.Add(this.buttonDelMembership);
            this.panelControl2.Controls.Add(this.buttonAddMembership);
            this.panelControl2.Controls.Add(this.labelControl7);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(902, 585);
            this.panelControl2.TabIndex = 10;
            // 
            // GridControlDetail
            // 
            this.GridControlDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridControlDetail.DataSource = this.BindingSourceDetail;
            this.GridControlDetail.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GridControlDetail.Location = new System.Drawing.Point(19, 46);
            this.GridControlDetail.MainView = this.GridViewDetail;
            this.GridControlDetail.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GridControlDetail.Name = "GridControlDetail";
            this.GridControlDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSearchLookUpEditClass});
            this.GridControlDetail.Size = new System.Drawing.Size(785, 464);
            this.GridControlDetail.TabIndex = 25;
            this.GridControlDetail.TabStop = false;
            this.GridControlDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewDetail});
            // 
            // GridViewDetail
            // 
            this.GridViewDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.colLINK_TABLE1,
            this.gridColumn2,
            this.colLINK_VALUE1,
            this.colCODE1,
            this.colNOTE,
            this.colUSER_DEC11,
            this.colUSER_DEC21,
            this.colUSER_INT11,
            this.colUSER_INT21,
            this.colUSER_TXT11,
            this.colUSER_TXT21,
            this.colUSER_TXT31,
            this.colUSER_TXT41,
            this.colUSER_DTE11,
            this.colUSER_DTE21});
            this.GridViewDetail.DetailHeight = 182;
            this.GridViewDetail.FixedLineWidth = 1;
            this.GridViewDetail.GridControl = this.GridControlDetail;
            this.GridViewDetail.LevelIndent = 0;
            this.GridViewDetail.Name = "GridViewDetail";
            this.GridViewDetail.OptionsView.ShowGroupPanel = false;
            this.GridViewDetail.PreviewIndent = 0;
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "ID";
            this.gridColumn1.MinWidth = 10;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 37;
            // 
            // colLINK_TABLE1
            // 
            this.colLINK_TABLE1.FieldName = "LINK_TABLE";
            this.colLINK_TABLE1.MinWidth = 10;
            this.colLINK_TABLE1.Name = "colLINK_TABLE1";
            this.colLINK_TABLE1.Width = 37;
            // 
            // gridColumn2
            // 
            this.gridColumn2.FieldName = "RECTYPE";
            this.gridColumn2.MinWidth = 10;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Width = 37;
            // 
            // colLINK_VALUE1
            // 
            this.colLINK_VALUE1.FieldName = "LINK_VALUE";
            this.colLINK_VALUE1.MinWidth = 10;
            this.colLINK_VALUE1.Name = "colLINK_VALUE1";
            this.colLINK_VALUE1.Width = 37;
            // 
            // colCODE1
            // 
            this.colCODE1.Caption = "Classification";
            this.colCODE1.ColumnEdit = this.repositoryItemSearchLookUpEditClass;
            this.colCODE1.FieldName = "CODE";
            this.colCODE1.MinWidth = 10;
            this.colCODE1.Name = "colCODE1";
            this.colCODE1.Visible = true;
            this.colCODE1.VisibleIndex = 0;
            this.colCODE1.Width = 37;
            // 
            // repositoryItemSearchLookUpEditClass
            // 
            this.repositoryItemSearchLookUpEditClass.AutoHeight = false;
            this.repositoryItemSearchLookUpEditClass.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.repositoryItemSearchLookUpEditClass.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSearchLookUpEditClass.DataSource = this.BindingSourceCodeName;
            this.repositoryItemSearchLookUpEditClass.DisplayMember = "DisplayName";
            this.repositoryItemSearchLookUpEditClass.Name = "repositoryItemSearchLookUpEditClass";
            this.repositoryItemSearchLookUpEditClass.PopupView = this.gridView14;
            this.repositoryItemSearchLookUpEditClass.ValueMember = "Code";
            // 
            // gridView14
            // 
            this.gridView14.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode5,
            this.colName});
            this.gridView14.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView14.Name = "gridView14";
            this.gridView14.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView14.OptionsView.ShowGroupPanel = false;
            this.gridView14.OptionsView.ShowIndicator = false;
            // 
            // colCode5
            // 
            this.colCode5.FieldName = "Code";
            this.colCode5.Name = "colCode5";
            this.colCode5.Visible = true;
            this.colCode5.VisibleIndex = 0;
            this.colCode5.Width = 424;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 1448;
            // 
            // colNOTE
            // 
            this.colNOTE.Caption = "Note";
            this.colNOTE.FieldName = "NOTE";
            this.colNOTE.MinWidth = 10;
            this.colNOTE.Name = "colNOTE";
            this.colNOTE.Visible = true;
            this.colNOTE.VisibleIndex = 1;
            this.colNOTE.Width = 37;
            // 
            // colUSER_DEC11
            // 
            this.colUSER_DEC11.FieldName = "USER_DEC1";
            this.colUSER_DEC11.MinWidth = 10;
            this.colUSER_DEC11.Name = "colUSER_DEC11";
            this.colUSER_DEC11.Width = 37;
            // 
            // colUSER_DEC21
            // 
            this.colUSER_DEC21.FieldName = "USER_DEC2";
            this.colUSER_DEC21.MinWidth = 10;
            this.colUSER_DEC21.Name = "colUSER_DEC21";
            this.colUSER_DEC21.Width = 37;
            // 
            // colUSER_INT11
            // 
            this.colUSER_INT11.FieldName = "USER_INT1";
            this.colUSER_INT11.MinWidth = 10;
            this.colUSER_INT11.Name = "colUSER_INT11";
            this.colUSER_INT11.Width = 37;
            // 
            // colUSER_INT21
            // 
            this.colUSER_INT21.FieldName = "USER_INT2";
            this.colUSER_INT21.MinWidth = 10;
            this.colUSER_INT21.Name = "colUSER_INT21";
            this.colUSER_INT21.Width = 37;
            // 
            // colUSER_TXT11
            // 
            this.colUSER_TXT11.FieldName = "USER_TXT1";
            this.colUSER_TXT11.MinWidth = 10;
            this.colUSER_TXT11.Name = "colUSER_TXT11";
            this.colUSER_TXT11.Width = 37;
            // 
            // colUSER_TXT21
            // 
            this.colUSER_TXT21.FieldName = "USER_TXT2";
            this.colUSER_TXT21.MinWidth = 10;
            this.colUSER_TXT21.Name = "colUSER_TXT21";
            this.colUSER_TXT21.Width = 37;
            // 
            // colUSER_TXT31
            // 
            this.colUSER_TXT31.FieldName = "USER_TXT3";
            this.colUSER_TXT31.MinWidth = 10;
            this.colUSER_TXT31.Name = "colUSER_TXT31";
            this.colUSER_TXT31.Width = 37;
            // 
            // colUSER_TXT41
            // 
            this.colUSER_TXT41.FieldName = "USER_TXT4";
            this.colUSER_TXT41.MinWidth = 10;
            this.colUSER_TXT41.Name = "colUSER_TXT41";
            this.colUSER_TXT41.Width = 37;
            // 
            // colUSER_DTE11
            // 
            this.colUSER_DTE11.FieldName = "USER_DTE1";
            this.colUSER_DTE11.MinWidth = 10;
            this.colUSER_DTE11.Name = "colUSER_DTE11";
            this.colUSER_DTE11.Width = 37;
            // 
            // colUSER_DTE21
            // 
            this.colUSER_DTE21.FieldName = "USER_DTE2";
            this.colUSER_DTE21.MinWidth = 10;
            this.colUSER_DTE21.Name = "colUSER_DTE21";
            this.colUSER_DTE21.Width = 37;
            // 
            // buttonDelMembership
            // 
            this.buttonDelMembership.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonDelMembership.ImageOptions.Image")));
            this.buttonDelMembership.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonDelMembership.Location = new System.Drawing.Point(72, 303);
            this.buttonDelMembership.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonDelMembership.Name = "buttonDelMembership";
            this.buttonDelMembership.Size = new System.Drawing.Size(34, 36);
            this.buttonDelMembership.TabIndex = 22;
            this.buttonDelMembership.TabStop = false;
            this.buttonDelMembership.Text = "simpleButton4";
            this.buttonDelMembership.Click += new System.EventHandler(this.ButtonDelMembership_Click);
            // 
            // buttonAddMembership
            // 
            this.buttonAddMembership.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddMembership.ImageOptions.Image")));
            this.buttonAddMembership.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonAddMembership.Location = new System.Drawing.Point(19, 303);
            this.buttonAddMembership.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonAddMembership.Name = "buttonAddMembership";
            this.buttonAddMembership.Size = new System.Drawing.Size(36, 36);
            this.buttonAddMembership.TabIndex = 23;
            this.buttonAddMembership.TabStop = false;
            this.buttonAddMembership.Text = "simpleButton3";
            this.buttonAddMembership.Click += new System.EventHandler(this.ButtonAddMembership_Click);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(16, 15);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(71, 13);
            this.labelControl7.TabIndex = 24;
            this.labelControl7.Text = "Classifications:";
            // 
            // xtraTabPageCustom
            // 
            this.xtraTabPageCustom.Controls.Add(this.panelControl6);
            this.xtraTabPageCustom.Margin = new System.Windows.Forms.Padding(4);
            this.xtraTabPageCustom.Name = "xtraTabPageCustom";
            this.xtraTabPageCustom.Size = new System.Drawing.Size(902, 585);
            this.xtraTabPageCustom.Text = "Custom";
            // 
            // panelControl6
            // 
            this.panelControl6.AutoSize = true;
            this.panelControl6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelControl6.Controls.Add(this.GridControlUserfields);
            this.panelControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl6.Location = new System.Drawing.Point(0, 0);
            this.panelControl6.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(902, 585);
            this.panelControl6.TabIndex = 0;
            // 
            // GridControlUserfields
            // 
            this.GridControlUserfields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridControlUserfields.DataSource = this.BindingSourceUserFields;
            this.GridControlUserfields.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GridControlUserfields.Location = new System.Drawing.Point(18, 44);
            this.GridControlUserfields.MainView = this.GridViewUserFields;
            this.GridControlUserfields.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GridControlUserfields.Name = "GridControlUserfields";
            this.GridControlUserfields.Size = new System.Drawing.Size(785, 464);
            this.GridControlUserfields.TabIndex = 1;
            this.GridControlUserfields.TabStop = false;
            this.GridControlUserfields.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewUserFields});
            // 
            // GridViewUserFields
            // 
            this.GridViewUserFields.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColumnLinkTable,
            this.ColumnLink_Column,
            this.ColumnRecType,
            this.ColumnLabel,
            this.ColumnDescription,
            this.ColumnVisible,
            this.ColumnLinkupCodeColumn,
            this.ColumnLookupDescColumn,
            this.ColumnLookupTable,
            this.ColumnSize,
            this.ColumnMin,
            this.ColumnMax,
            this.ColumnRestrictToLookup,
            this.ColumnPrecision,
            this.ColumnRequired,
            this.ColPosition1,
            this.GridColumnCustomValue});
            this.GridViewUserFields.DetailHeight = 182;
            this.GridViewUserFields.FixedLineWidth = 1;
            this.GridViewUserFields.GridControl = this.GridControlUserfields;
            this.GridViewUserFields.LevelIndent = 0;
            this.GridViewUserFields.Name = "GridViewUserFields";
            this.GridViewUserFields.OptionsView.ShowGroupPanel = false;
            this.GridViewUserFields.PreviewIndent = 0;
            this.GridViewUserFields.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.GridViewUserFields_CustomUnboundColumnData);
            // 
            // ColumnLinkTable
            // 
            this.ColumnLinkTable.FieldName = "LINK_TABLE";
            this.ColumnLinkTable.MinWidth = 10;
            this.ColumnLinkTable.Name = "ColumnLinkTable";
            this.ColumnLinkTable.Width = 37;
            // 
            // ColumnLink_Column
            // 
            this.ColumnLink_Column.FieldName = "LINK_COLUMN";
            this.ColumnLink_Column.MinWidth = 10;
            this.ColumnLink_Column.Name = "ColumnLink_Column";
            this.ColumnLink_Column.Width = 37;
            // 
            // ColumnRecType
            // 
            this.ColumnRecType.FieldName = "RECTYPE";
            this.ColumnRecType.MinWidth = 10;
            this.ColumnRecType.Name = "ColumnRecType";
            this.ColumnRecType.Width = 37;
            // 
            // ColumnLabel
            // 
            this.ColumnLabel.Caption = "Label";
            this.ColumnLabel.FieldName = "LABEL";
            this.ColumnLabel.MinWidth = 10;
            this.ColumnLabel.Name = "ColumnLabel";
            this.ColumnLabel.OptionsColumn.AllowEdit = false;
            this.ColumnLabel.OptionsColumn.TabStop = false;
            this.ColumnLabel.Visible = true;
            this.ColumnLabel.VisibleIndex = 0;
            this.ColumnLabel.Width = 37;
            // 
            // ColumnDescription
            // 
            this.ColumnDescription.FieldName = "DESC";
            this.ColumnDescription.MinWidth = 10;
            this.ColumnDescription.Name = "ColumnDescription";
            this.ColumnDescription.Width = 37;
            // 
            // ColumnVisible
            // 
            this.ColumnVisible.FieldName = "VISIBLE";
            this.ColumnVisible.MinWidth = 10;
            this.ColumnVisible.Name = "ColumnVisible";
            this.ColumnVisible.Width = 37;
            // 
            // ColumnLinkupCodeColumn
            // 
            this.ColumnLinkupCodeColumn.FieldName = "LKUP_CODE_COLUMN";
            this.ColumnLinkupCodeColumn.MinWidth = 10;
            this.ColumnLinkupCodeColumn.Name = "ColumnLinkupCodeColumn";
            this.ColumnLinkupCodeColumn.Width = 37;
            // 
            // ColumnLookupDescColumn
            // 
            this.ColumnLookupDescColumn.FieldName = "LKUP_DESC_COLUMN";
            this.ColumnLookupDescColumn.MinWidth = 10;
            this.ColumnLookupDescColumn.Name = "ColumnLookupDescColumn";
            this.ColumnLookupDescColumn.Width = 37;
            // 
            // ColumnLookupTable
            // 
            this.ColumnLookupTable.FieldName = "LKUP_TABLE";
            this.ColumnLookupTable.MinWidth = 10;
            this.ColumnLookupTable.Name = "ColumnLookupTable";
            this.ColumnLookupTable.Width = 37;
            // 
            // ColumnSize
            // 
            this.ColumnSize.FieldName = "SIZE";
            this.ColumnSize.MinWidth = 10;
            this.ColumnSize.Name = "ColumnSize";
            this.ColumnSize.Width = 37;
            // 
            // ColumnMin
            // 
            this.ColumnMin.FieldName = "MIN";
            this.ColumnMin.MinWidth = 10;
            this.ColumnMin.Name = "ColumnMin";
            this.ColumnMin.Width = 37;
            // 
            // ColumnMax
            // 
            this.ColumnMax.FieldName = "MAX";
            this.ColumnMax.MinWidth = 10;
            this.ColumnMax.Name = "ColumnMax";
            this.ColumnMax.Width = 37;
            // 
            // ColumnRestrictToLookup
            // 
            this.ColumnRestrictToLookup.FieldName = "RESTRICT_TO_LKUP";
            this.ColumnRestrictToLookup.MinWidth = 10;
            this.ColumnRestrictToLookup.Name = "ColumnRestrictToLookup";
            this.ColumnRestrictToLookup.Width = 37;
            // 
            // ColumnPrecision
            // 
            this.ColumnPrecision.FieldName = "PRECISION";
            this.ColumnPrecision.MinWidth = 10;
            this.ColumnPrecision.Name = "ColumnPrecision";
            this.ColumnPrecision.Width = 37;
            // 
            // ColumnRequired
            // 
            this.ColumnRequired.FieldName = "REQUIRED";
            this.ColumnRequired.MinWidth = 10;
            this.ColumnRequired.Name = "ColumnRequired";
            this.ColumnRequired.Width = 37;
            // 
            // ColPosition1
            // 
            this.ColPosition1.FieldName = "POSITION";
            this.ColPosition1.MinWidth = 10;
            this.ColPosition1.Name = "ColPosition1";
            this.ColPosition1.Width = 37;
            // 
            // GridColumnCustomValue
            // 
            this.GridColumnCustomValue.Caption = "Value";
            this.GridColumnCustomValue.Name = "GridColumnCustomValue";
            this.GridColumnCustomValue.Visible = true;
            this.GridColumnCustomValue.VisibleIndex = 1;
            // 
            // xtraTabPageCommissions
            // 
            this.xtraTabPageCommissions.Controls.Add(this.panelControl7);
            this.xtraTabPageCommissions.Margin = new System.Windows.Forms.Padding(4);
            this.xtraTabPageCommissions.Name = "xtraTabPageCommissions";
            this.xtraTabPageCommissions.Size = new System.Drawing.Size(902, 585);
            this.xtraTabPageCommissions.Text = "Commissions";
            // 
            // panelControl7
            // 
            this.panelControl7.AutoSize = true;
            this.panelControl7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelControl7.Controls.Add(this.LabelSource);
            this.panelControl7.Controls.Add(this.ComboBoxEditSource);
            this.panelControl7.Controls.Add(this.LabelMarkups);
            this.panelControl7.Controls.Add(this.LabelCommissions);
            this.panelControl7.Controls.Add(this.GridControlMarkups);
            this.panelControl7.Controls.Add(this.GridControlCommissions);
            this.panelControl7.Controls.Add(this.ButtonSearch);
            this.panelControl7.Controls.Add(LabelDate);
            this.panelControl7.Controls.Add(LabelAgency);
            this.panelControl7.Controls.Add(this.SearchLookupEditAgency);
            this.panelControl7.Controls.Add(this.ButtonEditDate);
            this.panelControl7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl7.Location = new System.Drawing.Point(0, 0);
            this.panelControl7.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelControl7.Name = "panelControl7";
            this.panelControl7.Size = new System.Drawing.Size(902, 585);
            this.panelControl7.TabIndex = 0;
            // 
            // LabelSource
            // 
            this.LabelSource.Location = new System.Drawing.Point(18, 13);
            this.LabelSource.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LabelSource.Name = "LabelSource";
            this.LabelSource.Size = new System.Drawing.Size(33, 13);
            this.LabelSource.TabIndex = 57;
            this.LabelSource.Text = "Source";
            // 
            // ComboBoxEditSource
            // 
            this.ComboBoxEditSource.Location = new System.Drawing.Point(58, 10);
            this.ComboBoxEditSource.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ComboBoxEditSource.Name = "ComboBoxEditSource";
            this.ComboBoxEditSource.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ComboBoxEditSource.Properties.Items.AddRange(new object[] {
            "INHOUSE",
            "REMOTE",
            "H2H",
            "WEB"});
            this.ComboBoxEditSource.Size = new System.Drawing.Size(70, 20);
            this.ComboBoxEditSource.TabIndex = 59;
            // 
            // LabelMarkups
            // 
            this.LabelMarkups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelMarkups.Location = new System.Drawing.Point(14, 386);
            this.LabelMarkups.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LabelMarkups.Name = "LabelMarkups";
            this.LabelMarkups.Size = new System.Drawing.Size(40, 13);
            this.LabelMarkups.TabIndex = 52;
            this.LabelMarkups.Text = "Markups";
            // 
            // LabelCommissions
            // 
            this.LabelCommissions.Location = new System.Drawing.Point(14, 35);
            this.LabelCommissions.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LabelCommissions.Name = "LabelCommissions";
            this.LabelCommissions.Size = new System.Drawing.Size(60, 13);
            this.LabelCommissions.TabIndex = 51;
            this.LabelCommissions.Text = "Commissions";
            // 
            // GridControlMarkups
            // 
            this.GridControlMarkups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridControlMarkups.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GridControlMarkups.Location = new System.Drawing.Point(14, 403);
            this.GridControlMarkups.MainView = this.gridViewMarkups;
            this.GridControlMarkups.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GridControlMarkups.Name = "GridControlMarkups";
            this.GridControlMarkups.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit5,
            this.repositoryItemCheckEdit4});
            this.GridControlMarkups.Size = new System.Drawing.Size(785, 157);
            this.GridControlMarkups.TabIndex = 43;
            this.GridControlMarkups.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMarkups});
            // 
            // gridViewMarkups
            // 
            this.gridViewMarkups.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.gridViewMarkups.DetailHeight = 182;
            this.gridViewMarkups.FixedLineWidth = 1;
            this.gridViewMarkups.GridControl = this.GridControlMarkups;
            this.gridViewMarkups.LevelIndent = 0;
            this.gridViewMarkups.Name = "gridViewMarkups";
            this.gridViewMarkups.OptionsBehavior.Editable = false;
            this.gridViewMarkups.OptionsView.ShowGroupPanel = false;
            this.gridViewMarkups.OptionsView.ShowIndicator = false;
            this.gridViewMarkups.PreviewIndent = 0;
            this.gridViewMarkups.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.GridViewMarkups_CustomColumnDisplayText);
            // 
            // ColumnServiceEndMU
            // 
            this.ColumnServiceEndMU.Caption = "Service End";
            this.ColumnServiceEndMU.FieldName = "SvcEndDate";
            this.ColumnServiceEndMU.MinWidth = 10;
            this.ColumnServiceEndMU.Name = "ColumnServiceEndMU";
            this.ColumnServiceEndMU.Visible = true;
            this.ColumnServiceEndMU.VisibleIndex = 2;
            this.ColumnServiceEndMU.Width = 40;
            // 
            // ColumnBookStartDateMU
            // 
            this.ColumnBookStartDateMU.Caption = "Book Start";
            this.ColumnBookStartDateMU.FieldName = "ResStartDate";
            this.ColumnBookStartDateMU.MinWidth = 10;
            this.ColumnBookStartDateMU.Name = "ColumnBookStartDateMU";
            this.ColumnBookStartDateMU.Visible = true;
            this.ColumnBookStartDateMU.VisibleIndex = 3;
            this.ColumnBookStartDateMU.Width = 40;
            // 
            // ColumnBookEndDateMU
            // 
            this.ColumnBookEndDateMU.Caption = "Book End";
            this.ColumnBookEndDateMU.FieldName = "ResEndDate";
            this.ColumnBookEndDateMU.MinWidth = 10;
            this.ColumnBookEndDateMU.Name = "ColumnBookEndDateMU";
            this.ColumnBookEndDateMU.Visible = true;
            this.ColumnBookEndDateMU.VisibleIndex = 4;
            this.ColumnBookEndDateMU.Width = 44;
            // 
            // ColumnCommPctMU
            // 
            this.ColumnCommPctMU.Caption = "Comm Pct";
            this.ColumnCommPctMU.FieldName = "Percentage";
            this.ColumnCommPctMU.MinWidth = 10;
            this.ColumnCommPctMU.Name = "ColumnCommPctMU";
            this.ColumnCommPctMU.Visible = true;
            this.ColumnCommPctMU.VisibleIndex = 8;
            this.ColumnCommPctMU.Width = 30;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Inactive";
            this.gridColumn6.ColumnEdit = this.repositoryItemCheckEdit4;
            this.gridColumn6.FieldName = "Inactive";
            this.gridColumn6.MinWidth = 10;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Width = 24;
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
            this.ColumnStartDateMU.MinWidth = 10;
            this.ColumnStartDateMU.Name = "ColumnStartDateMU";
            this.ColumnStartDateMU.Visible = true;
            this.ColumnStartDateMU.VisibleIndex = 1;
            this.ColumnStartDateMU.Width = 40;
            // 
            // ColumnAgencyRuleMU
            // 
            this.ColumnAgencyRuleMU.Caption = "Agency Rule";
            this.ColumnAgencyRuleMU.FieldName = "AgencyRuleDescription";
            this.ColumnAgencyRuleMU.MinWidth = 10;
            this.ColumnAgencyRuleMU.Name = "ColumnAgencyRuleMU";
            this.ColumnAgencyRuleMU.Visible = true;
            this.ColumnAgencyRuleMU.VisibleIndex = 6;
            this.ColumnAgencyRuleMU.Width = 67;
            // 
            // ColumnPositionMU
            // 
            this.ColumnPositionMU.Caption = "Position";
            this.ColumnPositionMU.FieldName = "Position";
            this.ColumnPositionMU.MinWidth = 10;
            this.ColumnPositionMU.Name = "ColumnPositionMU";
            this.ColumnPositionMU.Visible = true;
            this.ColumnPositionMU.VisibleIndex = 9;
            this.ColumnPositionMU.Width = 32;
            // 
            // ColumnProductRuleMU
            // 
            this.ColumnProductRuleMU.Caption = "Product Rule";
            this.ColumnProductRuleMU.FieldName = "ProductRuleDescription";
            this.ColumnProductRuleMU.MinWidth = 10;
            this.ColumnProductRuleMU.Name = "ColumnProductRuleMU";
            this.ColumnProductRuleMU.Visible = true;
            this.ColumnProductRuleMU.VisibleIndex = 5;
            this.ColumnProductRuleMU.Width = 71;
            // 
            // gridColumnRecType
            // 
            this.gridColumnRecType.Caption = "Comm/Markup";
            this.gridColumnRecType.FieldName = "RecType";
            this.gridColumnRecType.MinWidth = 10;
            this.gridColumnRecType.Name = "gridColumnRecType";
            this.gridColumnRecType.Width = 38;
            // 
            // ColumnSourceMU
            // 
            this.ColumnSourceMU.Caption = "Source";
            this.ColumnSourceMU.FieldName = "Source";
            this.ColumnSourceMU.MinWidth = 10;
            this.ColumnSourceMU.Name = "ColumnSourceMU";
            this.ColumnSourceMU.Visible = true;
            this.ColumnSourceMU.VisibleIndex = 0;
            this.ColumnSourceMU.Width = 30;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Exclusion";
            this.gridColumn13.ColumnEdit = this.repositoryItemCheckEdit5;
            this.gridColumn13.FieldName = "Exclusion";
            this.gridColumn13.MinWidth = 10;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Width = 26;
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
            this.ColumnCategoryMU.MinWidth = 10;
            this.ColumnCategoryMU.Name = "ColumnCategoryMU";
            this.ColumnCategoryMU.Visible = true;
            this.ColumnCategoryMU.VisibleIndex = 7;
            this.ColumnCategoryMU.Width = 37;
            // 
            // GridControlCommissions
            // 
            this.GridControlCommissions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridControlCommissions.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GridControlCommissions.Location = new System.Drawing.Point(14, 54);
            this.GridControlCommissions.MainView = this.GridViewCommissions;
            this.GridControlCommissions.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GridControlCommissions.Name = "GridControlCommissions";
            this.GridControlCommissions.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit2,
            this.repositoryItemCheckEdit3});
            this.GridControlCommissions.Size = new System.Drawing.Size(785, 158);
            this.GridControlCommissions.TabIndex = 42;
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
            this.colRectype1,
            this.ColumnSourceComm,
            this.colExclusion1,
            this.ColumnCategoryComm});
            this.GridViewCommissions.DetailHeight = 182;
            this.GridViewCommissions.FixedLineWidth = 1;
            this.GridViewCommissions.GridControl = this.GridControlCommissions;
            this.GridViewCommissions.LevelIndent = 0;
            this.GridViewCommissions.Name = "GridViewCommissions";
            this.GridViewCommissions.OptionsBehavior.Editable = false;
            this.GridViewCommissions.OptionsView.ShowGroupPanel = false;
            this.GridViewCommissions.OptionsView.ShowIndicator = false;
            this.GridViewCommissions.PreviewIndent = 0;
            this.GridViewCommissions.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.GridViewCommissions_CustomColumnDisplayText);
            // 
            // ColumnEndDateComm
            // 
            this.ColumnEndDateComm.Caption = "Service End";
            this.ColumnEndDateComm.FieldName = "SvcEndDate";
            this.ColumnEndDateComm.MinWidth = 10;
            this.ColumnEndDateComm.Name = "ColumnEndDateComm";
            this.ColumnEndDateComm.Visible = true;
            this.ColumnEndDateComm.VisibleIndex = 2;
            this.ColumnEndDateComm.Width = 42;
            // 
            // ColumnBookStartDateComm
            // 
            this.ColumnBookStartDateComm.Caption = "Book Start";
            this.ColumnBookStartDateComm.FieldName = "ResStartDate";
            this.ColumnBookStartDateComm.MinWidth = 10;
            this.ColumnBookStartDateComm.Name = "ColumnBookStartDateComm";
            this.ColumnBookStartDateComm.Visible = true;
            this.ColumnBookStartDateComm.VisibleIndex = 3;
            this.ColumnBookStartDateComm.Width = 42;
            // 
            // ColumnBookEndDateComm
            // 
            this.ColumnBookEndDateComm.Caption = "Book End";
            this.ColumnBookEndDateComm.FieldName = "ResEndDate";
            this.ColumnBookEndDateComm.MinWidth = 10;
            this.ColumnBookEndDateComm.Name = "ColumnBookEndDateComm";
            this.ColumnBookEndDateComm.Visible = true;
            this.ColumnBookEndDateComm.VisibleIndex = 4;
            this.ColumnBookEndDateComm.Width = 47;
            // 
            // ColumnCommPctComm
            // 
            this.ColumnCommPctComm.Caption = "Comm Pct";
            this.ColumnCommPctComm.FieldName = "Percentage";
            this.ColumnCommPctComm.MinWidth = 10;
            this.ColumnCommPctComm.Name = "ColumnCommPctComm";
            this.ColumnCommPctComm.Visible = true;
            this.ColumnCommPctComm.VisibleIndex = 8;
            this.ColumnCommPctComm.Width = 30;
            // 
            // colInactive
            // 
            this.colInactive.Caption = "Inactive";
            this.colInactive.ColumnEdit = this.repositoryItemCheckEdit3;
            this.colInactive.FieldName = "Inactive";
            this.colInactive.MinWidth = 10;
            this.colInactive.Name = "colInactive";
            this.colInactive.Width = 23;
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
            this.ColumnStartDateComm.MinWidth = 10;
            this.ColumnStartDateComm.Name = "ColumnStartDateComm";
            this.ColumnStartDateComm.Visible = true;
            this.ColumnStartDateComm.VisibleIndex = 1;
            this.ColumnStartDateComm.Width = 42;
            // 
            // ColumnAgencyRuleComm
            // 
            this.ColumnAgencyRuleComm.Caption = "Agency Rule";
            this.ColumnAgencyRuleComm.FieldName = "AgencyRuleDescription";
            this.ColumnAgencyRuleComm.MinWidth = 10;
            this.ColumnAgencyRuleComm.Name = "ColumnAgencyRuleComm";
            this.ColumnAgencyRuleComm.Visible = true;
            this.ColumnAgencyRuleComm.VisibleIndex = 6;
            this.ColumnAgencyRuleComm.Width = 67;
            // 
            // ColumnPositionComm
            // 
            this.ColumnPositionComm.Caption = "Position";
            this.ColumnPositionComm.FieldName = "Position";
            this.ColumnPositionComm.MinWidth = 10;
            this.ColumnPositionComm.Name = "ColumnPositionComm";
            this.ColumnPositionComm.Visible = true;
            this.ColumnPositionComm.VisibleIndex = 9;
            this.ColumnPositionComm.Width = 22;
            // 
            // ColumnProductRuleComm
            // 
            this.ColumnProductRuleComm.Caption = "Product Rule";
            this.ColumnProductRuleComm.FieldName = "ProductRuleDescription";
            this.ColumnProductRuleComm.MinWidth = 10;
            this.ColumnProductRuleComm.Name = "ColumnProductRuleComm";
            this.ColumnProductRuleComm.Visible = true;
            this.ColumnProductRuleComm.VisibleIndex = 5;
            this.ColumnProductRuleComm.Width = 71;
            // 
            // colRectype1
            // 
            this.colRectype1.Caption = "Comm/Markup";
            this.colRectype1.FieldName = "RecType";
            this.colRectype1.MinWidth = 10;
            this.colRectype1.Name = "colRectype1";
            this.colRectype1.Width = 38;
            // 
            // ColumnSourceComm
            // 
            this.ColumnSourceComm.Caption = "Source";
            this.ColumnSourceComm.FieldName = "Source";
            this.ColumnSourceComm.MinWidth = 10;
            this.ColumnSourceComm.Name = "ColumnSourceComm";
            this.ColumnSourceComm.Visible = true;
            this.ColumnSourceComm.VisibleIndex = 0;
            this.ColumnSourceComm.Width = 31;
            // 
            // colExclusion1
            // 
            this.colExclusion1.Caption = "Exclusion";
            this.colExclusion1.ColumnEdit = this.repositoryItemCheckEdit2;
            this.colExclusion1.FieldName = "Exclusion";
            this.colExclusion1.MinWidth = 10;
            this.colExclusion1.Name = "colExclusion1";
            this.colExclusion1.Width = 26;
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
            this.ColumnCategoryComm.MinWidth = 10;
            this.ColumnCategoryComm.Name = "ColumnCategoryComm";
            this.ColumnCategoryComm.Visible = true;
            this.ColumnCategoryComm.VisibleIndex = 7;
            this.ColumnCategoryComm.Width = 37;
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Location = new System.Drawing.Point(646, 9);
            this.ButtonSearch.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(80, 25);
            this.ButtonSearch.TabIndex = 41;
            this.ButtonSearch.Text = "Search";
            this.ButtonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // SearchLookupEditAgency
            // 
            this.SearchLookupEditAgency.Location = new System.Drawing.Point(186, 10);
            this.SearchLookupEditAgency.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SearchLookupEditAgency.Name = "SearchLookupEditAgency";
            this.SearchLookupEditAgency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLookupEditAgency.Properties.DataSource = this.BindingSourceCodeName;
            this.SearchLookupEditAgency.Properties.DisplayMember = "DisplayName";
            this.SearchLookupEditAgency.Properties.NullText = "";
            this.SearchLookupEditAgency.Properties.PopupSizeable = false;
            this.SearchLookupEditAgency.Properties.PopupView = this.gridView5;
            this.SearchLookupEditAgency.Properties.ValueMember = "Code";
            this.SearchLookupEditAgency.Size = new System.Drawing.Size(251, 20);
            this.SearchLookupEditAgency.TabIndex = 45;
            this.SearchLookupEditAgency.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            // 
            // gridView5
            // 
            this.gridView5.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode12,
            this.colName6});
            this.gridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView5.OptionsView.ShowGroupPanel = false;
            this.gridView5.OptionsView.ShowIndicator = false;
            // 
            // colCode12
            // 
            this.colCode12.FieldName = "Code";
            this.colCode12.Name = "colCode12";
            this.colCode12.Visible = true;
            this.colCode12.VisibleIndex = 0;
            // 
            // colName6
            // 
            this.colName6.FieldName = "Name";
            this.colName6.Name = "colName6";
            this.colName6.Visible = true;
            this.colName6.VisibleIndex = 1;
            // 
            // ButtonEditDate
            // 
            this.ButtonEditDate.CausesValidation = false;
            this.ButtonEditDate.EditValue = null;
            this.ButtonEditDate.Location = new System.Drawing.Point(484, 10);
            this.ButtonEditDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ButtonEditDate.Name = "ButtonEditDate";
            this.ButtonEditDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ButtonEditDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ButtonEditDate.Properties.DisplayFormat.FormatString = "dd-MMM-yyyy";
            this.ButtonEditDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ButtonEditDate.Properties.EditFormat.FormatString = "dd-MMM-yyyy";
            this.ButtonEditDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ButtonEditDate.Properties.Mask.EditMask = "";
            this.ButtonEditDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.ButtonEditDate.Size = new System.Drawing.Size(154, 20);
            this.ButtonEditDate.TabIndex = 46;
            // 
            // xtraTabPageSupplierMapping
            // 
            this.xtraTabPageSupplierMapping.Controls.Add(this.panelControl3);
            this.xtraTabPageSupplierMapping.Margin = new System.Windows.Forms.Padding(2);
            this.xtraTabPageSupplierMapping.Name = "xtraTabPageSupplierMapping";
            this.xtraTabPageSupplierMapping.Size = new System.Drawing.Size(902, 585);
            this.xtraTabPageSupplierMapping.Text = "Supplier Mappings";
            // 
            // panelControl3
            // 
            this.panelControl3.AutoSize = true;
            this.panelControl3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelControl3.Controls.Add(this.GridControlSupplierProduct);
            this.panelControl3.Controls.Add(this.SimpleButtonDelSuppMapping);
            this.panelControl3.Controls.Add(this.SimpleButtonAddSuppMapping);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Margin = new System.Windows.Forms.Padding(2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(902, 585);
            this.panelControl3.TabIndex = 103;
            // 
            // GridControlSupplierProduct
            // 
            this.GridControlSupplierProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridControlSupplierProduct.DataSource = this.BindingSourceSupplierProduct;
            this.GridControlSupplierProduct.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GridControlSupplierProduct.Location = new System.Drawing.Point(22, 24);
            this.GridControlSupplierProduct.MainView = this.GridViewSupplierProduct;
            this.GridControlSupplierProduct.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GridControlSupplierProduct.Name = "GridControlSupplierProduct";
            this.GridControlSupplierProduct.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEditMax50,
            this.repositoryItemComboBoxDefaultPupLocType,
            this.repositoryItemCustomSearchLookUpEditDefaultCat,
            this.repositoryItemCustomSearchLookUpEditDefaultPUpLoc,
            this.repositoryItemComboBoxDefaultDrpLocType,
            this.repositoryItemCustomSearchLookUpEditDefaultDropLoc,
            this.repositoryItemTimeEditDefault,
            this.RepositoryItemSpinEditMarkupPct,
            this.RepositoryItemSpinEditSupplierCommPct,
            this.RepositoryItemSpinEditRetailMarkupPct,
            this.RepositoryItemSpinEditMarkupFlat,
            this.RepositoryItemSpinEditSupplierCommFlat,
            this.RepositoryItemSpinEditRetailMarkupFlat});
            this.GridControlSupplierProduct.Size = new System.Drawing.Size(819, 534);
            this.GridControlSupplierProduct.TabIndex = 100;
            this.GridControlSupplierProduct.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewSupplierProduct});
            this.GridControlSupplierProduct.Leave += new System.EventHandler(this.GridControlSupplierProduct_Leave);
            // 
            // GridViewSupplierProduct
            // 
            this.GridViewSupplierProduct.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnSupplierProductId,
            this.gridColumnProductCode,
            this.gridColumnProductType,
            this.gridColumnSupplierGuid,
            this.gridColumnProductSupplierCode,
            this.gridColumnMappingInactive,
            this.gridColumnMappingCustom1,
            this.gridColumnMappingCustom2,
            this.gridColumnMappingSvcStart,
            this.gridColumnMappingSvcEnd,
            this.gridColumnMappingResStart,
            this.gridColumnMappingResEnd,
            this.gridColumnMappingDesc,
            this.gridColumnMappingOperator,
            this.colRoomcod_Code_Default,
            this.colPickup_LocationType_Default,
            this.colPickup_Location_Default,
            this.colPickup_Time_Default,
            this.colDropoff_LocationType_Default,
            this.colDropoff_Location_Default,
            this.colDropoff_Time_Default,
            this.colMarkupPct,
            this.colSupplierCommPct,
            this.colRetailMarkupPct,
            this.colMarkupFlat,
            this.colSupplierCommFlat,
            this.colRetailMarkupFlat});
            this.GridViewSupplierProduct.DetailHeight = 182;
            this.GridViewSupplierProduct.FixedLineWidth = 1;
            this.GridViewSupplierProduct.GridControl = this.GridControlSupplierProduct;
            this.GridViewSupplierProduct.LevelIndent = 0;
            this.GridViewSupplierProduct.Name = "GridViewSupplierProduct";
            this.GridViewSupplierProduct.OptionsView.ColumnAutoWidth = false;
            this.GridViewSupplierProduct.OptionsView.ShowGroupPanel = false;
            this.GridViewSupplierProduct.OptionsView.ShowIndicator = false;
            this.GridViewSupplierProduct.PreviewIndent = 0;
            this.GridViewSupplierProduct.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.GridViewSupplierProduct_CustomRowCellEdit);
            this.GridViewSupplierProduct.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.GridViewSupplierProduct_CellValueChanged);
            this.GridViewSupplierProduct.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.GridViewSupplierProduct_InvalidRowException);
            // 
            // gridColumnSupplierProductId
            // 
            this.gridColumnSupplierProductId.FieldName = "ID";
            this.gridColumnSupplierProductId.MinWidth = 10;
            this.gridColumnSupplierProductId.Name = "gridColumnSupplierProductId";
            this.gridColumnSupplierProductId.Width = 37;
            // 
            // gridColumnProductCode
            // 
            this.gridColumnProductCode.FieldName = "Product_Code_Internal";
            this.gridColumnProductCode.MinWidth = 10;
            this.gridColumnProductCode.Name = "gridColumnProductCode";
            this.gridColumnProductCode.Width = 37;
            // 
            // gridColumnProductType
            // 
            this.gridColumnProductType.FieldName = "Product_Type";
            this.gridColumnProductType.MinWidth = 10;
            this.gridColumnProductType.Name = "gridColumnProductType";
            this.gridColumnProductType.Width = 37;
            // 
            // gridColumnSupplierGuid
            // 
            this.gridColumnSupplierGuid.Caption = "Supplier";
            this.gridColumnSupplierGuid.FieldName = "Supplier_GUID";
            this.gridColumnSupplierGuid.MinWidth = 10;
            this.gridColumnSupplierGuid.Name = "gridColumnSupplierGuid";
            this.gridColumnSupplierGuid.Visible = true;
            this.gridColumnSupplierGuid.VisibleIndex = 0;
            this.gridColumnSupplierGuid.Width = 122;
            // 
            // gridColumnProductSupplierCode
            // 
            this.gridColumnProductSupplierCode.Caption = "Supplier Code";
            this.gridColumnProductSupplierCode.ColumnEdit = this.repositoryItemTextEditMax50;
            this.gridColumnProductSupplierCode.FieldName = "ProductCodeSupplier";
            this.gridColumnProductSupplierCode.MinWidth = 10;
            this.gridColumnProductSupplierCode.Name = "gridColumnProductSupplierCode";
            this.gridColumnProductSupplierCode.Visible = true;
            this.gridColumnProductSupplierCode.VisibleIndex = 1;
            this.gridColumnProductSupplierCode.Width = 93;
            // 
            // repositoryItemTextEditMax50
            // 
            this.repositoryItemTextEditMax50.AutoHeight = false;
            this.repositoryItemTextEditMax50.MaxLength = 50;
            this.repositoryItemTextEditMax50.Name = "repositoryItemTextEditMax50";
            // 
            // gridColumnMappingInactive
            // 
            this.gridColumnMappingInactive.Caption = "Inactive";
            this.gridColumnMappingInactive.FieldName = "Inactive";
            this.gridColumnMappingInactive.MinWidth = 10;
            this.gridColumnMappingInactive.Name = "gridColumnMappingInactive";
            this.gridColumnMappingInactive.Visible = true;
            this.gridColumnMappingInactive.VisibleIndex = 2;
            this.gridColumnMappingInactive.Width = 69;
            // 
            // gridColumnMappingCustom1
            // 
            this.gridColumnMappingCustom1.Caption = "Custom 1";
            this.gridColumnMappingCustom1.ColumnEdit = this.repositoryItemTextEditMax50;
            this.gridColumnMappingCustom1.FieldName = "Custom1";
            this.gridColumnMappingCustom1.MinWidth = 10;
            this.gridColumnMappingCustom1.Name = "gridColumnMappingCustom1";
            this.gridColumnMappingCustom1.Visible = true;
            this.gridColumnMappingCustom1.VisibleIndex = 3;
            this.gridColumnMappingCustom1.Width = 85;
            // 
            // gridColumnMappingCustom2
            // 
            this.gridColumnMappingCustom2.Caption = "Custom 2";
            this.gridColumnMappingCustom2.ColumnEdit = this.repositoryItemTextEditMax50;
            this.gridColumnMappingCustom2.FieldName = "Custom2";
            this.gridColumnMappingCustom2.MinWidth = 10;
            this.gridColumnMappingCustom2.Name = "gridColumnMappingCustom2";
            this.gridColumnMappingCustom2.Visible = true;
            this.gridColumnMappingCustom2.VisibleIndex = 4;
            this.gridColumnMappingCustom2.Width = 74;
            // 
            // gridColumnMappingSvcStart
            // 
            this.gridColumnMappingSvcStart.Caption = "Svc Start";
            this.gridColumnMappingSvcStart.DisplayFormat.FormatString = "dd-MMM-yy";
            this.gridColumnMappingSvcStart.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnMappingSvcStart.FieldName = "SvcDate_Start";
            this.gridColumnMappingSvcStart.MinWidth = 10;
            this.gridColumnMappingSvcStart.Name = "gridColumnMappingSvcStart";
            this.gridColumnMappingSvcStart.Visible = true;
            this.gridColumnMappingSvcStart.VisibleIndex = 5;
            this.gridColumnMappingSvcStart.Width = 90;
            // 
            // gridColumnMappingSvcEnd
            // 
            this.gridColumnMappingSvcEnd.Caption = "Svc End";
            this.gridColumnMappingSvcEnd.DisplayFormat.FormatString = "dd-MMM-yy";
            this.gridColumnMappingSvcEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnMappingSvcEnd.FieldName = "SvcDate_End";
            this.gridColumnMappingSvcEnd.MinWidth = 10;
            this.gridColumnMappingSvcEnd.Name = "gridColumnMappingSvcEnd";
            this.gridColumnMappingSvcEnd.Visible = true;
            this.gridColumnMappingSvcEnd.VisibleIndex = 6;
            this.gridColumnMappingSvcEnd.Width = 90;
            // 
            // gridColumnMappingResStart
            // 
            this.gridColumnMappingResStart.Caption = "Res Start";
            this.gridColumnMappingResStart.DisplayFormat.FormatString = "dd-MMM-yy";
            this.gridColumnMappingResStart.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnMappingResStart.FieldName = "ResDate_Start";
            this.gridColumnMappingResStart.MinWidth = 10;
            this.gridColumnMappingResStart.Name = "gridColumnMappingResStart";
            this.gridColumnMappingResStart.Visible = true;
            this.gridColumnMappingResStart.VisibleIndex = 7;
            this.gridColumnMappingResStart.Width = 90;
            // 
            // gridColumnMappingResEnd
            // 
            this.gridColumnMappingResEnd.Caption = "Res End";
            this.gridColumnMappingResEnd.DisplayFormat.FormatString = "dd-MMM-yy";
            this.gridColumnMappingResEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnMappingResEnd.FieldName = "ResDate_End";
            this.gridColumnMappingResEnd.MinWidth = 10;
            this.gridColumnMappingResEnd.Name = "gridColumnMappingResEnd";
            this.gridColumnMappingResEnd.Visible = true;
            this.gridColumnMappingResEnd.VisibleIndex = 8;
            this.gridColumnMappingResEnd.Width = 90;
            // 
            // gridColumnMappingDesc
            // 
            this.gridColumnMappingDesc.Caption = "Description";
            this.gridColumnMappingDesc.FieldName = "Description";
            this.gridColumnMappingDesc.MinWidth = 10;
            this.gridColumnMappingDesc.Name = "gridColumnMappingDesc";
            this.gridColumnMappingDesc.Visible = true;
            this.gridColumnMappingDesc.VisibleIndex = 9;
            this.gridColumnMappingDesc.Width = 111;
            // 
            // gridColumnMappingOperator
            // 
            this.gridColumnMappingOperator.Caption = "Operator";
            this.gridColumnMappingOperator.FieldName = "Operator_Code";
            this.gridColumnMappingOperator.MinWidth = 10;
            this.gridColumnMappingOperator.Name = "gridColumnMappingOperator";
            this.gridColumnMappingOperator.Visible = true;
            this.gridColumnMappingOperator.VisibleIndex = 10;
            this.gridColumnMappingOperator.Width = 98;
            // 
            // colRoomcod_Code_Default
            // 
            this.colRoomcod_Code_Default.Caption = "Default Cat";
            this.colRoomcod_Code_Default.ColumnEdit = this.repositoryItemCustomSearchLookUpEditDefaultCat;
            this.colRoomcod_Code_Default.FieldName = "Roomcod_Code_Default";
            this.colRoomcod_Code_Default.MinWidth = 21;
            this.colRoomcod_Code_Default.Name = "colRoomcod_Code_Default";
            this.colRoomcod_Code_Default.Visible = true;
            this.colRoomcod_Code_Default.VisibleIndex = 11;
            this.colRoomcod_Code_Default.Width = 78;
            // 
            // repositoryItemCustomSearchLookUpEditDefaultCat
            // 
            this.repositoryItemCustomSearchLookUpEditDefaultCat.AutoHeight = false;
            this.repositoryItemCustomSearchLookUpEditDefaultCat.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.repositoryItemCustomSearchLookUpEditDefaultCat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCustomSearchLookUpEditDefaultCat.DataSource = this.BindingSourceCodeName;
            this.repositoryItemCustomSearchLookUpEditDefaultCat.DisplayMember = "DisplayName";
            this.repositoryItemCustomSearchLookUpEditDefaultCat.Name = "repositoryItemCustomSearchLookUpEditDefaultCat";
            this.repositoryItemCustomSearchLookUpEditDefaultCat.NullText = "";
            this.repositoryItemCustomSearchLookUpEditDefaultCat.PopupView = this.repositoryItemCustomSearchLookUpEdit1View;
            this.repositoryItemCustomSearchLookUpEditDefaultCat.ValueMember = "Code";
            this.repositoryItemCustomSearchLookUpEditDefaultCat.UpdateDisplayFilter += new Custom_SearchLookupEdit.UpdateDisplayFilterHandler(this.SearchLookupEdit_UpdateDisplayFilter);
            this.repositoryItemCustomSearchLookUpEditDefaultCat.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            // 
            // repositoryItemCustomSearchLookUpEdit1View
            // 
            this.repositoryItemCustomSearchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode4,
            this.gridColumn7});
            this.repositoryItemCustomSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemCustomSearchLookUpEdit1View.Name = "repositoryItemCustomSearchLookUpEdit1View";
            this.repositoryItemCustomSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemCustomSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.repositoryItemCustomSearchLookUpEdit1View.OptionsView.ShowIndicator = false;
            // 
            // colCode4
            // 
            this.colCode4.FieldName = "Code";
            this.colCode4.Name = "colCode4";
            this.colCode4.Visible = true;
            this.colCode4.VisibleIndex = 0;
            // 
            // gridColumn7
            // 
            this.gridColumn7.FieldName = "Name";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            // 
            // colPickup_LocationType_Default
            // 
            this.colPickup_LocationType_Default.Caption = "Pickup Type";
            this.colPickup_LocationType_Default.ColumnEdit = this.repositoryItemComboBoxDefaultPupLocType;
            this.colPickup_LocationType_Default.FieldName = "Pickup_LocationType_Default";
            this.colPickup_LocationType_Default.MinWidth = 21;
            this.colPickup_LocationType_Default.Name = "colPickup_LocationType_Default";
            this.colPickup_LocationType_Default.Visible = true;
            this.colPickup_LocationType_Default.VisibleIndex = 12;
            this.colPickup_LocationType_Default.Width = 84;
            // 
            // repositoryItemComboBoxDefaultPupLocType
            // 
            this.repositoryItemComboBoxDefaultPupLocType.AutoHeight = false;
            this.repositoryItemComboBoxDefaultPupLocType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBoxDefaultPupLocType.Items.AddRange(new object[] {
            "",
            "WAY",
            "HTL",
            "OPT"});
            this.repositoryItemComboBoxDefaultPupLocType.Name = "repositoryItemComboBoxDefaultPupLocType";
            this.repositoryItemComboBoxDefaultPupLocType.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // colPickup_Location_Default
            // 
            this.colPickup_Location_Default.Caption = "Pickup Location";
            this.colPickup_Location_Default.ColumnEdit = this.repositoryItemCustomSearchLookUpEditDefaultPUpLoc;
            this.colPickup_Location_Default.FieldName = "Pickup_Location_Default";
            this.colPickup_Location_Default.MinWidth = 21;
            this.colPickup_Location_Default.Name = "colPickup_Location_Default";
            this.colPickup_Location_Default.Visible = true;
            this.colPickup_Location_Default.VisibleIndex = 13;
            this.colPickup_Location_Default.Width = 137;
            // 
            // repositoryItemCustomSearchLookUpEditDefaultPUpLoc
            // 
            this.repositoryItemCustomSearchLookUpEditDefaultPUpLoc.AutoHeight = false;
            this.repositoryItemCustomSearchLookUpEditDefaultPUpLoc.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.repositoryItemCustomSearchLookUpEditDefaultPUpLoc.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCustomSearchLookUpEditDefaultPUpLoc.DataSource = this.BindingSourceCodeName;
            this.repositoryItemCustomSearchLookUpEditDefaultPUpLoc.DisplayMember = "DisplayName";
            this.repositoryItemCustomSearchLookUpEditDefaultPUpLoc.Name = "repositoryItemCustomSearchLookUpEditDefaultPUpLoc";
            this.repositoryItemCustomSearchLookUpEditDefaultPUpLoc.NullText = "";
            this.repositoryItemCustomSearchLookUpEditDefaultPUpLoc.PopupView = this.gridView1;
            this.repositoryItemCustomSearchLookUpEditDefaultPUpLoc.ValueMember = "Code";
            this.repositoryItemCustomSearchLookUpEditDefaultPUpLoc.UpdateDisplayFilter += new Custom_SearchLookupEdit.UpdateDisplayFilterHandler(this.SearchLookupEdit_UpdateDisplayFilter);
            this.repositoryItemCustomSearchLookUpEditDefaultPUpLoc.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode2,
            this.gridColumn5});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // colCode2
            // 
            this.colCode2.FieldName = "Code";
            this.colCode2.Name = "colCode2";
            this.colCode2.Visible = true;
            this.colCode2.VisibleIndex = 0;
            // 
            // gridColumn5
            // 
            this.gridColumn5.FieldName = "Name";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            // 
            // colPickup_Time_Default
            // 
            this.colPickup_Time_Default.Caption = "Pickup Time";
            this.colPickup_Time_Default.ColumnEdit = this.repositoryItemTimeEditDefault;
            this.colPickup_Time_Default.FieldName = "Pickup_Time_Default";
            this.colPickup_Time_Default.MinWidth = 21;
            this.colPickup_Time_Default.Name = "colPickup_Time_Default";
            this.colPickup_Time_Default.Visible = true;
            this.colPickup_Time_Default.VisibleIndex = 14;
            this.colPickup_Time_Default.Width = 78;
            // 
            // repositoryItemTimeEditDefault
            // 
            this.repositoryItemTimeEditDefault.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.repositoryItemTimeEditDefault.AutoHeight = false;
            this.repositoryItemTimeEditDefault.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemTimeEditDefault.Mask.EditMask = "h:mm tt";
            this.repositoryItemTimeEditDefault.Name = "repositoryItemTimeEditDefault";
            this.repositoryItemTimeEditDefault.TimeEditStyle = DevExpress.XtraEditors.Repository.TimeEditStyle.TouchUI;
            // 
            // colDropoff_LocationType_Default
            // 
            this.colDropoff_LocationType_Default.Caption = "Dropoff Type";
            this.colDropoff_LocationType_Default.ColumnEdit = this.repositoryItemComboBoxDefaultDrpLocType;
            this.colDropoff_LocationType_Default.FieldName = "Dropoff_LocationType_Default";
            this.colDropoff_LocationType_Default.MinWidth = 21;
            this.colDropoff_LocationType_Default.Name = "colDropoff_LocationType_Default";
            this.colDropoff_LocationType_Default.Visible = true;
            this.colDropoff_LocationType_Default.VisibleIndex = 15;
            this.colDropoff_LocationType_Default.Width = 91;
            // 
            // repositoryItemComboBoxDefaultDrpLocType
            // 
            this.repositoryItemComboBoxDefaultDrpLocType.AutoHeight = false;
            this.repositoryItemComboBoxDefaultDrpLocType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBoxDefaultDrpLocType.Items.AddRange(new object[] {
            "",
            "WAY",
            "HTL",
            "OPT"});
            this.repositoryItemComboBoxDefaultDrpLocType.Name = "repositoryItemComboBoxDefaultDrpLocType";
            this.repositoryItemComboBoxDefaultDrpLocType.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // colDropoff_Location_Default
            // 
            this.colDropoff_Location_Default.Caption = "Dropoff Location";
            this.colDropoff_Location_Default.ColumnEdit = this.repositoryItemCustomSearchLookUpEditDefaultDropLoc;
            this.colDropoff_Location_Default.FieldName = "Dropoff_Location_Default";
            this.colDropoff_Location_Default.MinWidth = 21;
            this.colDropoff_Location_Default.Name = "colDropoff_Location_Default";
            this.colDropoff_Location_Default.Visible = true;
            this.colDropoff_Location_Default.VisibleIndex = 16;
            this.colDropoff_Location_Default.Width = 158;
            // 
            // repositoryItemCustomSearchLookUpEditDefaultDropLoc
            // 
            this.repositoryItemCustomSearchLookUpEditDefaultDropLoc.AutoHeight = false;
            this.repositoryItemCustomSearchLookUpEditDefaultDropLoc.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.repositoryItemCustomSearchLookUpEditDefaultDropLoc.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCustomSearchLookUpEditDefaultDropLoc.DataSource = this.BindingSourceCodeName;
            this.repositoryItemCustomSearchLookUpEditDefaultDropLoc.DisplayMember = "DisplayName";
            this.repositoryItemCustomSearchLookUpEditDefaultDropLoc.Name = "repositoryItemCustomSearchLookUpEditDefaultDropLoc";
            this.repositoryItemCustomSearchLookUpEditDefaultDropLoc.NullText = "";
            this.repositoryItemCustomSearchLookUpEditDefaultDropLoc.PopupView = this.gridView3;
            this.repositoryItemCustomSearchLookUpEditDefaultDropLoc.ValueMember = "Code";
            this.repositoryItemCustomSearchLookUpEditDefaultDropLoc.UpdateDisplayFilter += new Custom_SearchLookupEdit.UpdateDisplayFilterHandler(this.SearchLookupEdit_UpdateDisplayFilter);
            this.repositoryItemCustomSearchLookUpEditDefaultDropLoc.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode6,
            this.gridColumn8});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView3.OptionsView.ShowIndicator = false;
            // 
            // colCode6
            // 
            this.colCode6.FieldName = "Code";
            this.colCode6.Name = "colCode6";
            this.colCode6.Visible = true;
            this.colCode6.VisibleIndex = 0;
            // 
            // gridColumn8
            // 
            this.gridColumn8.FieldName = "Name";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            // 
            // colDropoff_Time_Default
            // 
            this.colDropoff_Time_Default.Caption = "Dropoff Time";
            this.colDropoff_Time_Default.ColumnEdit = this.repositoryItemTimeEditDefault;
            this.colDropoff_Time_Default.FieldName = "Dropoff_Time_Default";
            this.colDropoff_Time_Default.MinWidth = 21;
            this.colDropoff_Time_Default.Name = "colDropoff_Time_Default";
            this.colDropoff_Time_Default.Visible = true;
            this.colDropoff_Time_Default.VisibleIndex = 17;
            this.colDropoff_Time_Default.Width = 78;
            // 
            // colMarkupPct
            // 
            this.colMarkupPct.Caption = "Markup Pct";
            this.colMarkupPct.ColumnEdit = this.RepositoryItemSpinEditMarkupPct;
            this.colMarkupPct.FieldName = "MarkupPct";
            this.colMarkupPct.Name = "colMarkupPct";
            this.colMarkupPct.Visible = true;
            this.colMarkupPct.VisibleIndex = 18;
            // 
            // RepositoryItemSpinEditMarkupPct
            // 
            this.RepositoryItemSpinEditMarkupPct.AutoHeight = false;
            this.RepositoryItemSpinEditMarkupPct.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemSpinEditMarkupPct.Name = "RepositoryItemSpinEditMarkupPct";
            // 
            // colSupplierCommPct
            // 
            this.colSupplierCommPct.Caption = "Commission Pct";
            this.colSupplierCommPct.ColumnEdit = this.RepositoryItemSpinEditSupplierCommPct;
            this.colSupplierCommPct.FieldName = "SupplierCommPct";
            this.colSupplierCommPct.Name = "colSupplierCommPct";
            this.colSupplierCommPct.Visible = true;
            this.colSupplierCommPct.VisibleIndex = 19;
            // 
            // RepositoryItemSpinEditSupplierCommPct
            // 
            this.RepositoryItemSpinEditSupplierCommPct.AutoHeight = false;
            this.RepositoryItemSpinEditSupplierCommPct.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemSpinEditSupplierCommPct.Name = "RepositoryItemSpinEditSupplierCommPct";
            // 
            // colRetailMarkupPct
            // 
            this.colRetailMarkupPct.Caption = "Retail Markup Pct";
            this.colRetailMarkupPct.ColumnEdit = this.RepositoryItemSpinEditRetailMarkupPct;
            this.colRetailMarkupPct.FieldName = "RetailMarkupPct";
            this.colRetailMarkupPct.Name = "colRetailMarkupPct";
            this.colRetailMarkupPct.Visible = true;
            this.colRetailMarkupPct.VisibleIndex = 20;
            // 
            // RepositoryItemSpinEditRetailMarkupPct
            // 
            this.RepositoryItemSpinEditRetailMarkupPct.AutoHeight = false;
            this.RepositoryItemSpinEditRetailMarkupPct.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemSpinEditRetailMarkupPct.Name = "RepositoryItemSpinEditRetailMarkupPct";
            // 
            // colMarkupFlat
            // 
            this.colMarkupFlat.Caption = "Supplier Commission Flat";
            this.colMarkupFlat.ColumnEdit = this.RepositoryItemSpinEditMarkupFlat;
            this.colMarkupFlat.FieldName = "MarkupFlat";
            this.colMarkupFlat.Name = "colMarkupFlat";
            this.colMarkupFlat.Visible = true;
            this.colMarkupFlat.VisibleIndex = 21;
            // 
            // RepositoryItemSpinEditMarkupFlat
            // 
            this.RepositoryItemSpinEditMarkupFlat.AutoHeight = false;
            this.RepositoryItemSpinEditMarkupFlat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemSpinEditMarkupFlat.Name = "RepositoryItemSpinEditMarkupFlat";
            // 
            // colSupplierCommFlat
            // 
            this.colSupplierCommFlat.Caption = "Supplier Commission Flat";
            this.colSupplierCommFlat.ColumnEdit = this.RepositoryItemSpinEditSupplierCommFlat;
            this.colSupplierCommFlat.FieldName = "SupplierCommFlat";
            this.colSupplierCommFlat.Name = "colSupplierCommFlat";
            this.colSupplierCommFlat.Visible = true;
            this.colSupplierCommFlat.VisibleIndex = 22;
            // 
            // RepositoryItemSpinEditSupplierCommFlat
            // 
            this.RepositoryItemSpinEditSupplierCommFlat.AutoHeight = false;
            this.RepositoryItemSpinEditSupplierCommFlat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemSpinEditSupplierCommFlat.Name = "RepositoryItemSpinEditSupplierCommFlat";
            // 
            // colRetailMarkupFlat
            // 
            this.colRetailMarkupFlat.Caption = "colRetailMarkupFlat";
            this.colRetailMarkupFlat.ColumnEdit = this.RepositoryItemSpinEditRetailMarkupFlat;
            this.colRetailMarkupFlat.FieldName = "RetailMarkupFlat";
            this.colRetailMarkupFlat.Name = "colRetailMarkupFlat";
            this.colRetailMarkupFlat.Visible = true;
            this.colRetailMarkupFlat.VisibleIndex = 23;
            // 
            // RepositoryItemSpinEditRetailMarkupFlat
            // 
            this.RepositoryItemSpinEditRetailMarkupFlat.AutoHeight = false;
            this.RepositoryItemSpinEditRetailMarkupFlat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemSpinEditRetailMarkupFlat.Name = "RepositoryItemSpinEditRetailMarkupFlat";
            // 
            // SimpleButtonDelSuppMapping
            // 
            this.SimpleButtonDelSuppMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SimpleButtonDelSuppMapping.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("SimpleButtonDelSuppMapping.ImageOptions.Image")));
            this.SimpleButtonDelSuppMapping.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.SimpleButtonDelSuppMapping.Location = new System.Drawing.Point(845, 73);
            this.SimpleButtonDelSuppMapping.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SimpleButtonDelSuppMapping.Name = "SimpleButtonDelSuppMapping";
            this.SimpleButtonDelSuppMapping.Size = new System.Drawing.Size(36, 44);
            this.SimpleButtonDelSuppMapping.TabIndex = 102;
            this.SimpleButtonDelSuppMapping.TabStop = false;
            this.SimpleButtonDelSuppMapping.Text = "simpleButton4";
            this.SimpleButtonDelSuppMapping.Click += new System.EventHandler(this.SimpleButtonDelSuppMapping_Click);
            // 
            // SimpleButtonAddSuppMapping
            // 
            this.SimpleButtonAddSuppMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SimpleButtonAddSuppMapping.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("SimpleButtonAddSuppMapping.ImageOptions.Image")));
            this.SimpleButtonAddSuppMapping.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.SimpleButtonAddSuppMapping.Location = new System.Drawing.Point(845, 24);
            this.SimpleButtonAddSuppMapping.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SimpleButtonAddSuppMapping.Name = "SimpleButtonAddSuppMapping";
            this.SimpleButtonAddSuppMapping.Size = new System.Drawing.Size(36, 43);
            this.SimpleButtonAddSuppMapping.TabIndex = 101;
            this.SimpleButtonAddSuppMapping.TabStop = false;
            this.SimpleButtonAddSuppMapping.Text = "simpleButton3";
            this.SimpleButtonAddSuppMapping.Click += new System.EventHandler(this.SimpleButtonAddSuppMapping_Click);
            // 
            // xtraTabPageSupplierCategories
            // 
            this.xtraTabPageSupplierCategories.Controls.Add(this.panelControl8);
            this.xtraTabPageSupplierCategories.Margin = new System.Windows.Forms.Padding(2);
            this.xtraTabPageSupplierCategories.Name = "xtraTabPageSupplierCategories";
            this.xtraTabPageSupplierCategories.Size = new System.Drawing.Size(902, 585);
            this.xtraTabPageSupplierCategories.Text = "Supplier Categories";
            // 
            // panelControl8
            // 
            this.panelControl8.Controls.Add(this.simpleButtonDelSuppCat);
            this.panelControl8.Controls.Add(this.simpleButtonAddSuppCat);
            this.panelControl8.Controls.Add(this.GridControlSupplierCategory);
            this.panelControl8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl8.Location = new System.Drawing.Point(0, 0);
            this.panelControl8.Margin = new System.Windows.Forms.Padding(2);
            this.panelControl8.Name = "panelControl8";
            this.panelControl8.Size = new System.Drawing.Size(902, 585);
            this.panelControl8.TabIndex = 0;
            // 
            // simpleButtonDelSuppCat
            // 
            this.simpleButtonDelSuppCat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonDelSuppCat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonDelSuppCat.ImageOptions.Image")));
            this.simpleButtonDelSuppCat.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonDelSuppCat.Location = new System.Drawing.Point(845, 75);
            this.simpleButtonDelSuppCat.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.simpleButtonDelSuppCat.Name = "simpleButtonDelSuppCat";
            this.simpleButtonDelSuppCat.Size = new System.Drawing.Size(36, 44);
            this.simpleButtonDelSuppCat.TabIndex = 108;
            this.simpleButtonDelSuppCat.TabStop = false;
            this.simpleButtonDelSuppCat.Text = "simpleButton4";
            this.simpleButtonDelSuppCat.Click += new System.EventHandler(this.SimpleButtonDelSupplierCategory_Click);
            // 
            // simpleButtonAddSuppCat
            // 
            this.simpleButtonAddSuppCat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonAddSuppCat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonAddSuppCat.ImageOptions.Image")));
            this.simpleButtonAddSuppCat.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonAddSuppCat.Location = new System.Drawing.Point(845, 25);
            this.simpleButtonAddSuppCat.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.simpleButtonAddSuppCat.Name = "simpleButtonAddSuppCat";
            this.simpleButtonAddSuppCat.Size = new System.Drawing.Size(36, 44);
            this.simpleButtonAddSuppCat.TabIndex = 107;
            this.simpleButtonAddSuppCat.TabStop = false;
            this.simpleButtonAddSuppCat.Text = "simpleButton3";
            this.simpleButtonAddSuppCat.Click += new System.EventHandler(this.SimpleButtonAddSupplierCategory_Click);
            // 
            // GridControlSupplierCategory
            // 
            this.GridControlSupplierCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridControlSupplierCategory.DataSource = this.BindingSourceSupplierCategory;
            this.GridControlSupplierCategory.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GridControlSupplierCategory.Location = new System.Drawing.Point(25, 25);
            this.GridControlSupplierCategory.MainView = this.GridViewSupplierCategory;
            this.GridControlSupplierCategory.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GridControlSupplierCategory.Name = "GridControlSupplierCategory";
            this.GridControlSupplierCategory.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RepositoryItemCustomSearchLookUpEditMappingCat});
            this.GridControlSupplierCategory.Size = new System.Drawing.Size(816, 532);
            this.GridControlSupplierCategory.TabIndex = 106;
            this.GridControlSupplierCategory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewSupplierCategory});
            this.GridControlSupplierCategory.Leave += new System.EventHandler(this.GridControlSupplierCategory_Leave);
            // 
            // GridViewSupplierCategory
            // 
            this.GridViewSupplierCategory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId3,
            this.colCode3,
            this.colCatMappingSupplier,
            this.colProduct_Code,
            this.colCatMappingRoomcod,
            this.colInactive3,
            this.colROOMCOD1,
            this.colSupplier,
            this.gridColumn35,
            this.gridColumnSuppCatName});
            this.GridViewSupplierCategory.DetailHeight = 182;
            this.GridViewSupplierCategory.FixedLineWidth = 1;
            this.GridViewSupplierCategory.GridControl = this.GridControlSupplierCategory;
            this.GridViewSupplierCategory.LevelIndent = 0;
            this.GridViewSupplierCategory.Name = "GridViewSupplierCategory";
            this.GridViewSupplierCategory.OptionsNavigation.AutoFocusNewRow = true;
            this.GridViewSupplierCategory.OptionsView.ShowGroupPanel = false;
            this.GridViewSupplierCategory.OptionsView.ShowIndicator = false;
            this.GridViewSupplierCategory.PreviewIndent = 0;
            this.GridViewSupplierCategory.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.GridViewSupplierCategory_CustomRowCellEdit);
            this.GridViewSupplierCategory.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.GridViewSupplierCategory_InvalidRowException);
            // 
            // colId3
            // 
            this.colId3.FieldName = "Id";
            this.colId3.MinWidth = 10;
            this.colId3.Name = "colId3";
            this.colId3.Width = 37;
            // 
            // colCode3
            // 
            this.colCode3.Caption = "Supplier Code";
            this.colCode3.FieldName = "Code";
            this.colCode3.MinWidth = 10;
            this.colCode3.Name = "colCode3";
            this.colCode3.Visible = true;
            this.colCode3.VisibleIndex = 1;
            this.colCode3.Width = 98;
            // 
            // colCatMappingSupplier
            // 
            this.colCatMappingSupplier.Caption = "Supplier";
            this.colCatMappingSupplier.FieldName = "Supplier_GUID";
            this.colCatMappingSupplier.MinWidth = 10;
            this.colCatMappingSupplier.Name = "colCatMappingSupplier";
            this.colCatMappingSupplier.Visible = true;
            this.colCatMappingSupplier.VisibleIndex = 0;
            this.colCatMappingSupplier.Width = 105;
            // 
            // colProduct_Code
            // 
            this.colProduct_Code.FieldName = "Product_Code";
            this.colProduct_Code.MinWidth = 10;
            this.colProduct_Code.Name = "colProduct_Code";
            this.colProduct_Code.Width = 97;
            // 
            // colCatMappingRoomcod
            // 
            this.colCatMappingRoomcod.Caption = "Category";
            this.colCatMappingRoomcod.ColumnEdit = this.RepositoryItemCustomSearchLookUpEditMappingCat;
            this.colCatMappingRoomcod.FieldName = "Roomcod_Code";
            this.colCatMappingRoomcod.MinWidth = 10;
            this.colCatMappingRoomcod.Name = "colCatMappingRoomcod";
            this.colCatMappingRoomcod.Visible = true;
            this.colCatMappingRoomcod.VisibleIndex = 3;
            this.colCatMappingRoomcod.Width = 132;
            // 
            // RepositoryItemCustomSearchLookUpEditMappingCat
            // 
            this.RepositoryItemCustomSearchLookUpEditMappingCat.AutoHeight = false;
            this.RepositoryItemCustomSearchLookUpEditMappingCat.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.RepositoryItemCustomSearchLookUpEditMappingCat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemCustomSearchLookUpEditMappingCat.DataSource = this.BindingSourceCodeName;
            this.RepositoryItemCustomSearchLookUpEditMappingCat.DisplayMember = "DisplayName";
            this.RepositoryItemCustomSearchLookUpEditMappingCat.Name = "RepositoryItemCustomSearchLookUpEditMappingCat";
            this.RepositoryItemCustomSearchLookUpEditMappingCat.NullText = "";
            this.RepositoryItemCustomSearchLookUpEditMappingCat.PopupView = this.gridView2;
            this.RepositoryItemCustomSearchLookUpEditMappingCat.ValueMember = "Code";
            this.RepositoryItemCustomSearchLookUpEditMappingCat.UpdateDisplayFilter += new Custom_SearchLookupEdit.UpdateDisplayFilterHandler(this.SearchLookupEdit_UpdateDisplayFilter);
            this.RepositoryItemCustomSearchLookUpEditMappingCat.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.gridColumn4});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            // 
            // colCode
            // 
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.FieldName = "Name";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // colInactive3
            // 
            this.colInactive3.FieldName = "Inactive";
            this.colInactive3.MinWidth = 10;
            this.colInactive3.Name = "colInactive3";
            this.colInactive3.Visible = true;
            this.colInactive3.VisibleIndex = 4;
            this.colInactive3.Width = 62;
            // 
            // colROOMCOD1
            // 
            this.colROOMCOD1.FieldName = "ROOMCOD";
            this.colROOMCOD1.MinWidth = 10;
            this.colROOMCOD1.Name = "colROOMCOD1";
            this.colROOMCOD1.Width = 37;
            // 
            // colSupplier
            // 
            this.colSupplier.FieldName = "Supplier";
            this.colSupplier.MinWidth = 10;
            this.colSupplier.Name = "colSupplier";
            this.colSupplier.Width = 37;
            // 
            // gridColumn35
            // 
            this.gridColumn35.Caption = "gridColumn35";
            this.gridColumn35.FieldName = "Product_Type";
            this.gridColumn35.MinWidth = 10;
            this.gridColumn35.Name = "gridColumn35";
            this.gridColumn35.Width = 37;
            // 
            // gridColumnSuppCatName
            // 
            this.gridColumnSuppCatName.Caption = "Supplier Name";
            this.gridColumnSuppCatName.FieldName = "Name";
            this.gridColumnSuppCatName.MinWidth = 21;
            this.gridColumnSuppCatName.Name = "gridColumnSuppCatName";
            this.gridColumnSuppCatName.Visible = true;
            this.gridColumnSuppCatName.VisibleIndex = 2;
            this.gridColumnSuppCatName.Width = 311;
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.panelControl5);
            this.xtraTabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(902, 585);
            this.xtraTabPage1.Text = "Supplements";
            // 
            // panelControl5
            // 
            this.panelControl5.AutoSize = true;
            this.panelControl5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelControl5.Controls.Add(this.SimpleButtonDeleteSupplement);
            this.panelControl5.Controls.Add(this.SimpleButtonAddSupplement);
            this.panelControl5.Controls.Add(this.GridControlSupplements);
            this.panelControl5.Controls.Add(this.CheckEditSupplementQtySelectable);
            this.panelControl5.Controls.Add(this.CheckEditSupplementIsBoard);
            this.panelControl5.Controls.Add(this.CheckEditSupplementPaySupplier);
            this.panelControl5.Controls.Add(this.CheckEditIsSupplement);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl5.Location = new System.Drawing.Point(0, 0);
            this.panelControl5.Margin = new System.Windows.Forms.Padding(2);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(902, 585);
            this.panelControl5.TabIndex = 0;
            // 
            // SimpleButtonDeleteSupplement
            // 
            this.SimpleButtonDeleteSupplement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SimpleButtonDeleteSupplement.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("SimpleButtonDeleteSupplement.ImageOptions.Image")));
            this.SimpleButtonDeleteSupplement.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.SimpleButtonDeleteSupplement.Location = new System.Drawing.Point(848, 106);
            this.SimpleButtonDeleteSupplement.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SimpleButtonDeleteSupplement.Name = "SimpleButtonDeleteSupplement";
            this.SimpleButtonDeleteSupplement.Size = new System.Drawing.Size(36, 44);
            this.SimpleButtonDeleteSupplement.TabIndex = 109;
            this.SimpleButtonDeleteSupplement.TabStop = false;
            this.SimpleButtonDeleteSupplement.Text = "simpleButton4";
            this.SimpleButtonDeleteSupplement.Click += new System.EventHandler(this.SimpleButtonDeleteSupplement_Click);
            // 
            // SimpleButtonAddSupplement
            // 
            this.SimpleButtonAddSupplement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SimpleButtonAddSupplement.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("SimpleButtonAddSupplement.ImageOptions.Image")));
            this.SimpleButtonAddSupplement.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.SimpleButtonAddSupplement.Location = new System.Drawing.Point(848, 58);
            this.SimpleButtonAddSupplement.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SimpleButtonAddSupplement.Name = "SimpleButtonAddSupplement";
            this.SimpleButtonAddSupplement.Size = new System.Drawing.Size(36, 44);
            this.SimpleButtonAddSupplement.TabIndex = 108;
            this.SimpleButtonAddSupplement.TabStop = false;
            this.SimpleButtonAddSupplement.Text = "simpleButton3";
            this.SimpleButtonAddSupplement.Click += new System.EventHandler(this.SimpleButtonAddSupplement_Click);
            // 
            // GridControlSupplements
            // 
            this.GridControlSupplements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridControlSupplements.CausesValidation = false;
            this.GridControlSupplements.DataSource = this.BindingSourceSupplements;
            this.GridControlSupplements.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GridControlSupplements.Location = new System.Drawing.Point(28, 59);
            this.GridControlSupplements.MainView = this.GridViewSupplement;
            this.GridControlSupplements.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GridControlSupplements.Name = "GridControlSupplements";
            this.GridControlSupplements.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RepositoryItemSearchLookUpEditCompCode,
            this.RepositoryItemImageComboBoxSupplementType});
            this.GridControlSupplements.Size = new System.Drawing.Size(816, 464);
            this.GridControlSupplements.TabIndex = 42;
            this.GridControlSupplements.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewSupplement,
            this.gridView20});
            this.GridControlSupplements.Leave += new System.EventHandler(this.GridControlSupplements_Leave);
            // 
            // BindingSourceSupplements
            // 
            this.BindingSourceSupplements.DataSource = typeof(FlexModel.ProductSupplement);
            // 
            // GridViewSupplement
            // 
            this.GridViewSupplement.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId4,
            this.colProduct_Type,
            this.colProduct_Code1,
            this.colComp_Type,
            this.colComp_Code1,
            this.colSupplementIncluded,
            this.colSupplementMandatory,
            this.colRateSheet_Id,
            this.colSupplementType});
            this.GridViewSupplement.DetailHeight = 182;
            this.GridViewSupplement.FixedLineWidth = 1;
            this.GridViewSupplement.GridControl = this.GridControlSupplements;
            this.GridViewSupplement.LevelIndent = 0;
            this.GridViewSupplement.Name = "GridViewSupplement";
            this.GridViewSupplement.OptionsView.ShowGroupPanel = false;
            this.GridViewSupplement.OptionsView.ShowIndicator = false;
            this.GridViewSupplement.PreviewIndent = 0;
            // 
            // colId4
            // 
            this.colId4.FieldName = "Id";
            this.colId4.Name = "colId4";
            // 
            // colProduct_Type
            // 
            this.colProduct_Type.FieldName = "Product_Type";
            this.colProduct_Type.Name = "colProduct_Type";
            // 
            // colProduct_Code1
            // 
            this.colProduct_Code1.FieldName = "Product_Code";
            this.colProduct_Code1.Name = "colProduct_Code1";
            // 
            // colComp_Type
            // 
            this.colComp_Type.FieldName = "Comp_Type";
            this.colComp_Type.Name = "colComp_Type";
            // 
            // colComp_Code1
            // 
            this.colComp_Code1.Caption = "Supplement";
            this.colComp_Code1.ColumnEdit = this.RepositoryItemSearchLookUpEditCompCode;
            this.colComp_Code1.FieldName = "Comp_Code";
            this.colComp_Code1.Name = "colComp_Code1";
            this.colComp_Code1.Visible = true;
            this.colComp_Code1.VisibleIndex = 0;
            // 
            // RepositoryItemSearchLookUpEditCompCode
            // 
            this.RepositoryItemSearchLookUpEditCompCode.AutoHeight = false;
            this.RepositoryItemSearchLookUpEditCompCode.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.RepositoryItemSearchLookUpEditCompCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemSearchLookUpEditCompCode.DataSource = this.BindingSourceCodeName;
            this.RepositoryItemSearchLookUpEditCompCode.DisplayMember = "DisplayName";
            this.RepositoryItemSearchLookUpEditCompCode.Name = "RepositoryItemSearchLookUpEditCompCode";
            this.RepositoryItemSearchLookUpEditCompCode.NullText = "";
            this.RepositoryItemSearchLookUpEditCompCode.PopupFormMinSize = new System.Drawing.Size(300, 312);
            this.RepositoryItemSearchLookUpEditCompCode.PopupFormSize = new System.Drawing.Size(300, 312);
            this.RepositoryItemSearchLookUpEditCompCode.PopupView = this.repositoryItemSearchLookUpEdit3View;
            this.RepositoryItemSearchLookUpEditCompCode.ValueMember = "Code";
            this.RepositoryItemSearchLookUpEditCompCode.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            this.RepositoryItemSearchLookUpEditCompCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PopupForm_KeyUp);
            // 
            // repositoryItemSearchLookUpEdit3View
            // 
            this.repositoryItemSearchLookUpEdit3View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode14,
            this.colName9});
            this.repositoryItemSearchLookUpEdit3View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit3View.Name = "repositoryItemSearchLookUpEdit3View";
            this.repositoryItemSearchLookUpEdit3View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit3View.OptionsView.ShowGroupPanel = false;
            this.repositoryItemSearchLookUpEdit3View.OptionsView.ShowIndicator = false;
            // 
            // colCode14
            // 
            this.colCode14.FieldName = "Code";
            this.colCode14.Name = "colCode14";
            this.colCode14.Visible = true;
            this.colCode14.VisibleIndex = 0;
            // 
            // colName9
            // 
            this.colName9.FieldName = "Name";
            this.colName9.Name = "colName9";
            this.colName9.Visible = true;
            this.colName9.VisibleIndex = 1;
            // 
            // colSupplementIncluded
            // 
            this.colSupplementIncluded.FieldName = "SupplementIncluded";
            this.colSupplementIncluded.Name = "colSupplementIncluded";
            this.colSupplementIncluded.Visible = true;
            this.colSupplementIncluded.VisibleIndex = 1;
            // 
            // colSupplementMandatory
            // 
            this.colSupplementMandatory.FieldName = "SupplementMandatory";
            this.colSupplementMandatory.Name = "colSupplementMandatory";
            this.colSupplementMandatory.Visible = true;
            this.colSupplementMandatory.VisibleIndex = 2;
            // 
            // colRateSheet_Id
            // 
            this.colRateSheet_Id.FieldName = "RateSheet_Id";
            this.colRateSheet_Id.Name = "colRateSheet_Id";
            // 
            // colSupplementType
            // 
            this.colSupplementType.ColumnEdit = this.RepositoryItemImageComboBoxSupplementType;
            this.colSupplementType.FieldName = "SupplementType";
            this.colSupplementType.Name = "colSupplementType";
            this.colSupplementType.Visible = true;
            this.colSupplementType.VisibleIndex = 3;
            // 
            // RepositoryItemImageComboBoxSupplementType
            // 
            this.RepositoryItemImageComboBoxSupplementType.AutoHeight = false;
            this.RepositoryItemImageComboBoxSupplementType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemImageComboBoxSupplementType.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Per Room", "PerRoom", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Per Night", "PerNight", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Per Person", "PerPerson", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Per Person Per Night", "PerPersonNight", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Per Booking", "PerBooking", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Per Room Per Night", "PerRoomNight", -1)});
            this.RepositoryItemImageComboBoxSupplementType.Name = "RepositoryItemImageComboBoxSupplementType";
            // 
            // gridView20
            // 
            this.gridView20.DetailHeight = 182;
            this.gridView20.FixedLineWidth = 1;
            this.gridView20.GridControl = this.GridControlSupplements;
            this.gridView20.LevelIndent = 0;
            this.gridView20.Name = "gridView20";
            this.gridView20.PreviewIndent = 0;
            // 
            // CheckEditSupplementQtySelectable
            // 
            this.CheckEditSupplementQtySelectable.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "SupplementQtySelectable", true));
            this.CheckEditSupplementQtySelectable.Enabled = false;
            this.CheckEditSupplementQtySelectable.EnterMoveNextControl = true;
            this.CheckEditSupplementQtySelectable.Location = new System.Drawing.Point(467, 17);
            this.CheckEditSupplementQtySelectable.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CheckEditSupplementQtySelectable.Name = "CheckEditSupplementQtySelectable";
            this.CheckEditSupplementQtySelectable.Properties.Caption = "Supplement Qty Selectable";
            this.CheckEditSupplementQtySelectable.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditSupplementQtySelectable.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.CheckEditSupplementQtySelectable.Size = new System.Drawing.Size(156, 19);
            this.CheckEditSupplementQtySelectable.TabIndex = 41;
            // 
            // CheckEditSupplementIsBoard
            // 
            this.CheckEditSupplementIsBoard.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "SupplementIsBoard", true));
            this.CheckEditSupplementIsBoard.Enabled = false;
            this.CheckEditSupplementIsBoard.EnterMoveNextControl = true;
            this.CheckEditSupplementIsBoard.Location = new System.Drawing.Point(324, 17);
            this.CheckEditSupplementIsBoard.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CheckEditSupplementIsBoard.Name = "CheckEditSupplementIsBoard";
            this.CheckEditSupplementIsBoard.Properties.Caption = "Supplement Is Board";
            this.CheckEditSupplementIsBoard.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditSupplementIsBoard.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.CheckEditSupplementIsBoard.Size = new System.Drawing.Size(128, 19);
            this.CheckEditSupplementIsBoard.TabIndex = 40;
            // 
            // CheckEditSupplementPaySupplier
            // 
            this.CheckEditSupplementPaySupplier.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "SupplementPaySupplier", true));
            this.CheckEditSupplementPaySupplier.Enabled = false;
            this.CheckEditSupplementPaySupplier.EnterMoveNextControl = true;
            this.CheckEditSupplementPaySupplier.Location = new System.Drawing.Point(164, 17);
            this.CheckEditSupplementPaySupplier.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CheckEditSupplementPaySupplier.Name = "CheckEditSupplementPaySupplier";
            this.CheckEditSupplementPaySupplier.Properties.Caption = "Supplement Pay Supplier";
            this.CheckEditSupplementPaySupplier.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditSupplementPaySupplier.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.CheckEditSupplementPaySupplier.Size = new System.Drawing.Size(148, 19);
            this.CheckEditSupplementPaySupplier.TabIndex = 39;
            // 
            // CheckEditIsSupplement
            // 
            this.CheckEditIsSupplement.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "IsSupplement", true));
            this.CheckEditIsSupplement.EnterMoveNextControl = true;
            this.CheckEditIsSupplement.Location = new System.Drawing.Point(42, 17);
            this.CheckEditIsSupplement.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CheckEditIsSupplement.Name = "CheckEditIsSupplement";
            this.CheckEditIsSupplement.Properties.Caption = "Is Supplement";
            this.CheckEditIsSupplement.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditIsSupplement.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.CheckEditIsSupplement.Size = new System.Drawing.Size(110, 19);
            this.CheckEditIsSupplement.TabIndex = 38;
            this.CheckEditIsSupplement.EditValueChanged += new System.EventHandler(this.CheckEditIsSupplement_EditValueChanged);
            // 
            // xtraTabPageRelatedProducts
            // 
            this.xtraTabPageRelatedProducts.Controls.Add(this.panelControl9);
            this.xtraTabPageRelatedProducts.Margin = new System.Windows.Forms.Padding(2);
            this.xtraTabPageRelatedProducts.Name = "xtraTabPageRelatedProducts";
            this.xtraTabPageRelatedProducts.Size = new System.Drawing.Size(902, 585);
            this.xtraTabPageRelatedProducts.Text = "Related Products";
            // 
            // panelControl9
            // 
            this.panelControl9.AutoSize = true;
            this.panelControl9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelControl9.Controls.Add(this.SimpleButtonDeletePassProduct);
            this.panelControl9.Controls.Add(this.SimpleButtonAddPass);
            this.panelControl9.Controls.Add(this.GridControlRelatedProducts);
            this.panelControl9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl9.Location = new System.Drawing.Point(0, 0);
            this.panelControl9.Margin = new System.Windows.Forms.Padding(2);
            this.panelControl9.Name = "panelControl9";
            this.panelControl9.Size = new System.Drawing.Size(902, 585);
            this.panelControl9.TabIndex = 1;
            // 
            // SimpleButtonDeletePassProduct
            // 
            this.SimpleButtonDeletePassProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SimpleButtonDeletePassProduct.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("SimpleButtonDeletePassProduct.ImageOptions.Image")));
            this.SimpleButtonDeletePassProduct.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.SimpleButtonDeletePassProduct.Location = new System.Drawing.Point(845, 81);
            this.SimpleButtonDeletePassProduct.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SimpleButtonDeletePassProduct.Name = "SimpleButtonDeletePassProduct";
            this.SimpleButtonDeletePassProduct.Size = new System.Drawing.Size(36, 44);
            this.SimpleButtonDeletePassProduct.TabIndex = 109;
            this.SimpleButtonDeletePassProduct.TabStop = false;
            this.SimpleButtonDeletePassProduct.Text = "Delete Pass Product";
            this.SimpleButtonDeletePassProduct.Click += new System.EventHandler(this.SimpleButtonDeleteRelatedProduct_Click);
            // 
            // SimpleButtonAddPass
            // 
            this.SimpleButtonAddPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SimpleButtonAddPass.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("SimpleButtonAddPass.ImageOptions.Image")));
            this.SimpleButtonAddPass.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.SimpleButtonAddPass.Location = new System.Drawing.Point(845, 30);
            this.SimpleButtonAddPass.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SimpleButtonAddPass.Name = "SimpleButtonAddPass";
            this.SimpleButtonAddPass.Size = new System.Drawing.Size(36, 44);
            this.SimpleButtonAddPass.TabIndex = 108;
            this.SimpleButtonAddPass.TabStop = false;
            this.SimpleButtonAddPass.Text = "Add Pass Product";
            this.SimpleButtonAddPass.Click += new System.EventHandler(this.SimpleButtonAddRelatedProduct_Click);
            // 
            // GridControlRelatedProducts
            // 
            this.GridControlRelatedProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridControlRelatedProducts.CausesValidation = false;
            this.GridControlRelatedProducts.DataSource = this.BindingSourceRelatedProduct;
            this.GridControlRelatedProducts.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GridControlRelatedProducts.Location = new System.Drawing.Point(27, 31);
            this.GridControlRelatedProducts.MainView = this.GridViewRelatedProducts;
            this.GridControlRelatedProducts.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GridControlRelatedProducts.Name = "GridControlRelatedProducts";
            this.GridControlRelatedProducts.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RepositoryItemDateEditSvcStart,
            this.RepositoryItemComboBoxType,
            this.RepositoryItemSearchLookUpEditRelatedProductCode});
            this.GridControlRelatedProducts.Size = new System.Drawing.Size(807, 518);
            this.GridControlRelatedProducts.TabIndex = 42;
            this.GridControlRelatedProducts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewRelatedProducts,
            this.gridView18});
            // 
            // BindingSourceRelatedProduct
            // 
            this.BindingSourceRelatedProduct.AllowNew = false;
            this.BindingSourceRelatedProduct.DataSource = typeof(FlexModel.RelatedProduct);
            // 
            // GridViewRelatedProducts
            // 
            this.GridViewRelatedProducts.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID5,
            this.colRelatedType,
            this.colRelatedCode,
            this.colExcluded,
            this.colServiceStart,
            this.colServiceEnd,
            this.colBookingStart,
            this.colBookingEnd,
            this.colInactive2,
            this.colPosition,
            this.colDiscountPct,
            this.colDiscountFlat,
            this.colReciprocal,
            this.colIsRoundTrip,
            this.colIsReturn,
            this.colForUpSell,
            this.colForPackaging});
            this.GridViewRelatedProducts.DetailHeight = 182;
            this.GridViewRelatedProducts.FixedLineWidth = 1;
            this.GridViewRelatedProducts.GridControl = this.GridControlRelatedProducts;
            this.GridViewRelatedProducts.LevelIndent = 0;
            this.GridViewRelatedProducts.Name = "GridViewRelatedProducts";
            this.GridViewRelatedProducts.OptionsView.ShowGroupPanel = false;
            this.GridViewRelatedProducts.OptionsView.ShowIndicator = false;
            this.GridViewRelatedProducts.PreviewIndent = 0;
            this.GridViewRelatedProducts.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.GridViewRelatedProducts_CustomRowCellEdit);
            // 
            // colID5
            // 
            this.colID5.FieldName = "ID";
            this.colID5.Name = "colID5";
            // 
            // colRelatedType
            // 
            this.colRelatedType.ColumnEdit = this.RepositoryItemComboBoxType;
            this.colRelatedType.FieldName = "Type";
            this.colRelatedType.Name = "colRelatedType";
            this.colRelatedType.Visible = true;
            this.colRelatedType.VisibleIndex = 0;
            // 
            // RepositoryItemComboBoxType
            // 
            this.RepositoryItemComboBoxType.AutoHeight = false;
            this.RepositoryItemComboBoxType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemComboBoxType.Items.AddRange(new object[] {
            "OPT",
            "PKG"});
            this.RepositoryItemComboBoxType.Name = "RepositoryItemComboBoxType";
            // 
            // colRelatedCode
            // 
            this.colRelatedCode.ColumnEdit = this.RepositoryItemSearchLookUpEditRelatedProductCode;
            this.colRelatedCode.FieldName = "Code";
            this.colRelatedCode.Name = "colRelatedCode";
            this.colRelatedCode.Visible = true;
            this.colRelatedCode.VisibleIndex = 1;
            // 
            // RepositoryItemSearchLookUpEditRelatedProductCode
            // 
            this.RepositoryItemSearchLookUpEditRelatedProductCode.AutoHeight = false;
            this.RepositoryItemSearchLookUpEditRelatedProductCode.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.RepositoryItemSearchLookUpEditRelatedProductCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemSearchLookUpEditRelatedProductCode.DataSource = this.BindingSourceCodeName;
            this.RepositoryItemSearchLookUpEditRelatedProductCode.DisplayMember = "DisplayName";
            this.RepositoryItemSearchLookUpEditRelatedProductCode.Name = "RepositoryItemSearchLookUpEditRelatedProductCode";
            this.RepositoryItemSearchLookUpEditRelatedProductCode.NullText = "";
            this.RepositoryItemSearchLookUpEditRelatedProductCode.PopupView = this.gridView17;
            this.RepositoryItemSearchLookUpEditRelatedProductCode.ValueMember = "Code";
            // 
            // gridView17
            // 
            this.gridView17.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode15,
            this.colName10});
            this.gridView17.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView17.Name = "gridView17";
            this.gridView17.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView17.OptionsView.ShowGroupPanel = false;
            this.gridView17.OptionsView.ShowIndicator = false;
            // 
            // colCode15
            // 
            this.colCode15.FieldName = "Code";
            this.colCode15.Name = "colCode15";
            this.colCode15.Visible = true;
            this.colCode15.VisibleIndex = 0;
            // 
            // colName10
            // 
            this.colName10.FieldName = "Name";
            this.colName10.Name = "colName10";
            this.colName10.Visible = true;
            this.colName10.VisibleIndex = 1;
            // 
            // colExcluded
            // 
            this.colExcluded.FieldName = "Excluded";
            this.colExcluded.Name = "colExcluded";
            this.colExcluded.Visible = true;
            this.colExcluded.VisibleIndex = 11;
            // 
            // colServiceStart
            // 
            this.colServiceStart.ColumnEdit = this.RepositoryItemDateEditSvcStart;
            this.colServiceStart.FieldName = "ServiceStart";
            this.colServiceStart.Name = "colServiceStart";
            this.colServiceStart.Visible = true;
            this.colServiceStart.VisibleIndex = 2;
            // 
            // RepositoryItemDateEditSvcStart
            // 
            this.RepositoryItemDateEditSvcStart.AutoHeight = false;
            this.RepositoryItemDateEditSvcStart.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemDateEditSvcStart.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemDateEditSvcStart.Name = "RepositoryItemDateEditSvcStart";
            // 
            // colServiceEnd
            // 
            this.colServiceEnd.FieldName = "ServiceEnd";
            this.colServiceEnd.Name = "colServiceEnd";
            this.colServiceEnd.Visible = true;
            this.colServiceEnd.VisibleIndex = 3;
            // 
            // colBookingStart
            // 
            this.colBookingStart.FieldName = "BookingStart";
            this.colBookingStart.Name = "colBookingStart";
            this.colBookingStart.Visible = true;
            this.colBookingStart.VisibleIndex = 4;
            // 
            // colBookingEnd
            // 
            this.colBookingEnd.FieldName = "BookingEnd";
            this.colBookingEnd.Name = "colBookingEnd";
            this.colBookingEnd.Visible = true;
            this.colBookingEnd.VisibleIndex = 5;
            // 
            // colInactive2
            // 
            this.colInactive2.FieldName = "Inactive";
            this.colInactive2.Name = "colInactive2";
            this.colInactive2.Visible = true;
            this.colInactive2.VisibleIndex = 6;
            // 
            // colPosition
            // 
            this.colPosition.FieldName = "Position";
            this.colPosition.Name = "colPosition";
            // 
            // colDiscountPct
            // 
            this.colDiscountPct.FieldName = "DiscountPct";
            this.colDiscountPct.Name = "colDiscountPct";
            // 
            // colDiscountFlat
            // 
            this.colDiscountFlat.FieldName = "DiscountFlat";
            this.colDiscountFlat.Name = "colDiscountFlat";
            // 
            // colReciprocal
            // 
            this.colReciprocal.FieldName = "Reciprocal";
            this.colReciprocal.Name = "colReciprocal";
            // 
            // colIsRoundTrip
            // 
            this.colIsRoundTrip.Caption = "Round Trip";
            this.colIsRoundTrip.FieldName = "IsRoundTrip";
            this.colIsRoundTrip.Name = "colIsRoundTrip";
            this.colIsRoundTrip.Visible = true;
            this.colIsRoundTrip.VisibleIndex = 7;
            // 
            // colIsReturn
            // 
            this.colIsReturn.Caption = "Return";
            this.colIsReturn.FieldName = "IsReturn";
            this.colIsReturn.Name = "colIsReturn";
            this.colIsReturn.Visible = true;
            this.colIsReturn.VisibleIndex = 8;
            // 
            // colForUpSell
            // 
            this.colForUpSell.Caption = "Upsell";
            this.colForUpSell.FieldName = "ForUpSell";
            this.colForUpSell.Name = "colForUpSell";
            this.colForUpSell.Visible = true;
            this.colForUpSell.VisibleIndex = 9;
            // 
            // colForPackaging
            // 
            this.colForPackaging.Caption = "For Packaging";
            this.colForPackaging.FieldName = "ForPackaging";
            this.colForPackaging.Name = "colForPackaging";
            this.colForPackaging.Visible = true;
            this.colForPackaging.VisibleIndex = 10;
            // 
            // gridView18
            // 
            this.gridView18.DetailHeight = 182;
            this.gridView18.FixedLineWidth = 1;
            this.gridView18.GridControl = this.GridControlRelatedProducts;
            this.gridView18.LevelIndent = 0;
            this.gridView18.Name = "gridView18";
            this.gridView18.PreviewIndent = 0;
            // 
            // default_TimeTextEdit
            // 
            this.default_TimeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Default_Time", true));
            this.default_TimeTextEdit.Location = new System.Drawing.Point(-126, 760);
            this.default_TimeTextEdit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.default_TimeTextEdit.Name = "default_TimeTextEdit";
            this.default_TimeTextEdit.Size = new System.Drawing.Size(100, 20);
            this.default_TimeTextEdit.TabIndex = 36;
            this.default_TimeTextEdit.TabStop = false;
            // 
            // SearchLookupEditOperator
            // 
            this.SearchLookupEditOperator.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "OPER", true));
            this.SearchLookupEditOperator.Location = new System.Drawing.Point(86, 90);
            this.SearchLookupEditOperator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SearchLookupEditOperator.Name = "SearchLookupEditOperator";
            this.SearchLookupEditOperator.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLookupEditOperator.Properties.DataSource = this.BindingSourceCodeName;
            this.SearchLookupEditOperator.Properties.DisplayMember = "DisplayName";
            this.SearchLookupEditOperator.Properties.NullText = "";
            this.SearchLookupEditOperator.Properties.PopupSizeable = false;
            this.SearchLookupEditOperator.Properties.PopupView = this.searchLookUpEdit1View;
            this.SearchLookupEditOperator.Properties.ValueMember = "Code";
            this.SearchLookupEditOperator.Size = new System.Drawing.Size(295, 20);
            this.SearchLookupEditOperator.TabIndex = 3;
            this.SearchLookupEditOperator.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            this.SearchLookupEditOperator.Leave += new System.EventHandler(this.ImageComboBoxEditOperator_Leave);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode8,
            this.colName2});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.searchLookUpEdit1View.OptionsView.ShowIndicator = false;
            // 
            // colCode8
            // 
            this.colCode8.FieldName = "Code";
            this.colCode8.Name = "colCode8";
            this.colCode8.Visible = true;
            this.colCode8.VisibleIndex = 0;
            // 
            // colName2
            // 
            this.colName2.FieldName = "Name";
            this.colName2.Name = "colName2";
            this.colName2.Visible = true;
            this.colName2.VisibleIndex = 1;
            // 
            // SearchLookupEditLanguage
            // 
            this.SearchLookupEditLanguage.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Language_Code", true));
            this.SearchLookupEditLanguage.EditValue = "4";
            this.SearchLookupEditLanguage.Location = new System.Drawing.Point(86, 116);
            this.SearchLookupEditLanguage.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SearchLookupEditLanguage.Name = "SearchLookupEditLanguage";
            this.SearchLookupEditLanguage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLookupEditLanguage.Properties.DataSource = this.BindingSourceCodeName;
            this.SearchLookupEditLanguage.Properties.DisplayMember = "DisplayName";
            this.SearchLookupEditLanguage.Properties.NullText = "";
            this.SearchLookupEditLanguage.Properties.PopupSizeable = false;
            this.SearchLookupEditLanguage.Properties.PopupView = this.gridView4;
            this.SearchLookupEditLanguage.Properties.ValueMember = "Code";
            this.SearchLookupEditLanguage.Size = new System.Drawing.Size(155, 20);
            this.SearchLookupEditLanguage.TabIndex = 8;
            this.SearchLookupEditLanguage.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            this.SearchLookupEditLanguage.Leave += new System.EventHandler(this.ImageComboBoxEditLanguage_Leave);
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode13,
            this.colName8});
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            this.gridView4.OptionsView.ShowIndicator = false;
            // 
            // colCode13
            // 
            this.colCode13.FieldName = "Code";
            this.colCode13.Name = "colCode13";
            this.colCode13.Visible = true;
            this.colCode13.VisibleIndex = 0;
            // 
            // colName8
            // 
            this.colName8.FieldName = "Name";
            this.colName8.Name = "colName8";
            this.colName8.Visible = true;
            this.colName8.VisibleIndex = 1;
            // 
            // SearchLookupEditDifficulty
            // 
            this.SearchLookupEditDifficulty.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Difficulty", true));
            this.SearchLookupEditDifficulty.Location = new System.Drawing.Point(382, 116);
            this.SearchLookupEditDifficulty.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SearchLookupEditDifficulty.Name = "SearchLookupEditDifficulty";
            this.SearchLookupEditDifficulty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLookupEditDifficulty.Properties.DataSource = this.BindingSourceIdName;
            this.SearchLookupEditDifficulty.Properties.DisplayMember = "Name";
            this.SearchLookupEditDifficulty.Properties.NullText = "";
            this.SearchLookupEditDifficulty.Properties.PopupSizeable = false;
            this.SearchLookupEditDifficulty.Properties.PopupView = this.gridView8;
            this.SearchLookupEditDifficulty.Properties.ValueMember = "Id";
            this.SearchLookupEditDifficulty.Size = new System.Drawing.Size(252, 20);
            this.SearchLookupEditDifficulty.TabIndex = 9;
            this.SearchLookupEditDifficulty.Leave += new System.EventHandler(this.ImageComboBoxEditDifficulty_Leave);
            // 
            // BindingSourceIdName
            // 
            this.BindingSourceIdName.DataSource = typeof(TraceForms.IdName);
            // 
            // gridView8
            // 
            this.gridView8.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId2,
            this.colName3});
            this.gridView8.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView8.Name = "gridView8";
            this.gridView8.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView8.OptionsView.ShowGroupPanel = false;
            this.gridView8.OptionsView.ShowIndicator = false;
            // 
            // colId2
            // 
            this.colId2.FieldName = "Id";
            this.colId2.Name = "colId2";
            // 
            // colName3
            // 
            this.colName3.FieldName = "Name";
            this.colName3.Name = "colName3";
            this.colName3.Visible = true;
            this.colName3.VisibleIndex = 0;
            // 
            // SearchLookupEditServiceType
            // 
            this.SearchLookupEditServiceType.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "SERV_TYPE", true));
            this.SearchLookupEditServiceType.Location = new System.Drawing.Point(86, 64);
            this.SearchLookupEditServiceType.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SearchLookupEditServiceType.Name = "SearchLookupEditServiceType";
            this.SearchLookupEditServiceType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLookupEditServiceType.Properties.DataSource = this.BindingSourceCodeName;
            this.SearchLookupEditServiceType.Properties.DisplayMember = "DisplayName";
            this.SearchLookupEditServiceType.Properties.NullText = "";
            this.SearchLookupEditServiceType.Properties.PopupSizeable = false;
            this.SearchLookupEditServiceType.Properties.PopupView = this.gridView9;
            this.SearchLookupEditServiceType.Properties.ValueMember = "Code";
            this.SearchLookupEditServiceType.Size = new System.Drawing.Size(295, 20);
            this.SearchLookupEditServiceType.TabIndex = 22;
            this.SearchLookupEditServiceType.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            this.SearchLookupEditServiceType.EditValueChanged += new System.EventHandler(this.SearchLookupEditServiceType_EditValueChanged);
            this.SearchLookupEditServiceType.Leave += new System.EventHandler(this.SearchLookupEditServiceType_Leave);
            // 
            // gridView9
            // 
            this.gridView9.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode7,
            this.colName1});
            this.gridView9.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView9.Name = "gridView9";
            this.gridView9.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView9.OptionsView.ShowGroupPanel = false;
            this.gridView9.OptionsView.ShowIndicator = false;
            // 
            // colCode7
            // 
            this.colCode7.FieldName = "Code";
            this.colCode7.Name = "colCode7";
            this.colCode7.Visible = true;
            this.colCode7.VisibleIndex = 0;
            // 
            // colName1
            // 
            this.colName1.FieldName = "Name";
            this.colName1.Name = "colName1";
            this.colName1.Visible = true;
            this.colName1.VisibleIndex = 1;
            // 
            // LabelServiceType
            // 
            this.LabelServiceType.Location = new System.Drawing.Point(15, 68);
            this.LabelServiceType.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LabelServiceType.Name = "LabelServiceType";
            this.LabelServiceType.Size = new System.Drawing.Size(62, 13);
            this.LabelServiceType.TabIndex = 0;
            this.LabelServiceType.Text = "Service Type";
            // 
            // ComProd2BindingSource
            // 
            this.ComProd2BindingSource.DataSource = typeof(FlexModel.COMPROD2);
            // 
            // PanelControlStatus
            // 
            this.PanelControlStatus.Appearance.Options.UseTextOptions = true;
            this.PanelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("PanelControlStatus.ContentImage")));
            this.PanelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.PanelControlStatus.Controls.Add(this.LabelStatus);
            this.PanelControlStatus.Location = new System.Drawing.Point(299, 2);
            this.PanelControlStatus.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.PanelControlStatus.Name = "PanelControlStatus";
            this.PanelControlStatus.Size = new System.Drawing.Size(120, 23);
            this.PanelControlStatus.TabIndex = 265;
            this.PanelControlStatus.Visible = false;
            // 
            // LabelStatus
            // 
            this.LabelStatus.Location = new System.Drawing.Point(30, 5);
            this.LabelStatus.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(0, 13);
            this.LabelStatus.TabIndex = 5;
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
            this.BarButtonItemSave,
            this.BarButtonItemUpdateWebsite});
            this.BarManager.MaxItemId = 4;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonItemNew),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonItemDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonItemSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonItemUpdateWebsite)});
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
            // BarButtonItemUpdateWebsite
            // 
            this.BarButtonItemUpdateWebsite.Caption = "Update Website";
            this.BarButtonItemUpdateWebsite.Id = 3;
            this.BarButtonItemUpdateWebsite.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BarButtonItemUpdateWebsite.ImageOptions.Image")));
            this.BarButtonItemUpdateWebsite.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BarButtonItemUpdateWebsite.ImageOptions.LargeImage")));
            this.BarButtonItemUpdateWebsite.Name = "BarButtonItemUpdateWebsite";
            this.BarButtonItemUpdateWebsite.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemUpdateWebsite_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.BarManager;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.barDockControlTop.Size = new System.Drawing.Size(1164, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 651);
            this.barDockControlBottom.Manager = this.BarManager;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.barDockControlBottom.Size = new System.Drawing.Size(1164, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Manager = this.BarManager;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 620);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1164, 31);
            this.barDockControlRight.Manager = this.BarManager;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 620);
            // 
            // CompForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1164, 651);
            this.Controls.Add(this.PanelControlStatus);
            this.Controls.Add(this.SplitContainerControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MinimizeBox = false;
            this.Name = "CompForm";
            this.ShowInTaskbar = false;
            this.Text = "Other Services General Information";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CompForm_FormClosing);
            this.Shown += new System.EventHandler(this.CompForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditRestrictionsCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditRateBasis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceCompBusRoutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceBusRoutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceBusRouteStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceBusTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceCodeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceUserFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceSupplierProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceSupplierCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditInactive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditVendorCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceBusStation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl)).EndInit();
            this.SplitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPageLocation.ResumeLayout(false);
            this.xtraTabPageLocation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlLocationTab)).EndInit();
            this.PanelControlLocationTab.ResumeLayout(false);
            this.PanelControlLocationTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookUpEditRegion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditDepCity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MapControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditProximitySearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditDistance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCityMilesTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditAirportMiles.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditAddr1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditZip.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditTown.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditAddr2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditAddr3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditCountry.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditCity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditAirportCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView11)).EndInit();
            this.xtraTabPagePolicies.ResumeLayout(false);
            this.xtraTabPagePolicies.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlPoliciesTab)).EndInit();
            this.PanelControlPoliciesTab.ResumeLayout(false);
            this.PanelControlPoliciesTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditAdmin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditOnRequestPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditConfirmationType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditMaxPax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditStartingAgentNet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditStartingComparison.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditStartingPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditStartingCost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditAllNames.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditAdminClosed.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditVoucherTypes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditDOBRequired.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RatingControlStars.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditRanking.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditDueDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditARNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditAPNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditDropoffInfoRequired.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditPickupInfoRequired.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditPassengerWeightRequired.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditAccountingServiceItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditVendorPrepayReqd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unit_RateCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mealsIncludedCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditMultTimes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditAllowFree.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditClientLogo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditDayPrior.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditReqDepInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditReqArvInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditDropoff.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditPickup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditTransferList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditSvcList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditDuration.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditTransType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditDefaultTime.Properties)).EndInit();
            this.xtraTabPageServices.ResumeLayout(false);
            this.xtraTabPageServices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlServicesTab)).EndInit();
            this.PanelControlServicesTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TextEditIncl6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditIncl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditIncl3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditIncl5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditIncl4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditIncl2.Properties)).EndInit();
            this.xtraTabPageRoutes.ResumeLayout(false);
            this.xtraTabPageRoutes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridControlRoutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewRoutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditBusRoutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditInactive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView13)).EndInit();
            this.xtraTabPageTransferPoints.ResumeLayout(false);
            this.xtraTabPageTransferPoints.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridControlTransferPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewTransferPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemImageComboBoxPickDrop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemSearchLookupEditLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboboxLocationView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxLocType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditLocationExclusion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBoxRoutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemSearchLookUpEditCat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTimeEditServiceTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView12)).EndInit();
            this.xtraTabPageMemberships.ResumeLayout(false);
            this.xtraTabPageMemberships.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEditClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView14)).EndInit();
            this.xtraTabPageCustom.ResumeLayout(false);
            this.xtraTabPageCustom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridControlUserfields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewUserFields)).EndInit();
            this.xtraTabPageCommissions.ResumeLayout(false);
            this.xtraTabPageCommissions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl7)).EndInit();
            this.panelControl7.ResumeLayout(false);
            this.panelControl7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxEditSource.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlMarkups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMarkups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlCommissions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewCommissions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditAgency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEditDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEditDate.Properties)).EndInit();
            this.xtraTabPageSupplierMapping.ResumeLayout(false);
            this.xtraTabPageSupplierMapping.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridControlSupplierProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSupplierProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditMax50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCustomSearchLookUpEditDefaultCat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCustomSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxDefaultPupLocType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCustomSearchLookUpEditDefaultPUpLoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEditDefault)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxDefaultDrpLocType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCustomSearchLookUpEditDefaultDropLoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemSpinEditMarkupPct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemSpinEditSupplierCommPct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemSpinEditRetailMarkupPct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemSpinEditMarkupFlat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemSpinEditSupplierCommFlat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemSpinEditRetailMarkupFlat)).EndInit();
            this.xtraTabPageSupplierCategories.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl8)).EndInit();
            this.panelControl8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridControlSupplierCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSupplierCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCustomSearchLookUpEditMappingCat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridControlSupplements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceSupplements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSupplement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemSearchLookUpEditCompCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit3View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemImageComboBoxSupplementType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditSupplementQtySelectable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditSupplementIsBoard.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditSupplementPaySupplier.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditIsSupplement.Properties)).EndInit();
            this.xtraTabPageRelatedProducts.ResumeLayout(false);
            this.xtraTabPageRelatedProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl9)).EndInit();
            this.panelControl9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridControlRelatedProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceRelatedProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewRelatedProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemComboBoxType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemSearchLookUpEditRelatedProductCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemDateEditSvcStart.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemDateEditSvcStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.default_TimeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditOperator.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditLanguage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditDifficulty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceIdName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditServiceType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComProd2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlStatus)).EndInit();
            this.PanelControlStatus.ResumeLayout(false);
            this.PanelControlStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControlUpdBy;
        private System.Windows.Forms.BindingSource BindingSource;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.LabelControl labelControlLastUpd;
        private DevExpress.XtraEditors.LabelControl LabelLastUpdated;
        private System.Windows.Forms.BindingSource BindingSourceBusTable;
        private DevExpress.XtraEditors.CheckEdit CheckEditInactive;
        private DevExpress.XtraEditors.TextEdit TextEditVendorCode;
        private DevExpress.XtraEditors.TextEdit TextEditName;
        private DevExpress.XtraGrid.GridControl GridControlLookup;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewLookup;
        private System.Windows.Forms.BindingSource BindingSourceBusStation;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemimageComboboxInOut;
        private DevExpress.XtraEditors.ImageComboBoxEdit ImageComboBoxEditRestrictionsCode;
        private DevExpress.XtraEditors.ImageComboBoxEdit ImageComboBoxEditRateBasis;
        private DevExpress.XtraEditors.SplitContainerControl SplitContainerControl;
        private System.Windows.Forms.BindingSource BindingSourceDetail;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEditExclusion;
        private System.Windows.Forms.BindingSource BindingSourceUserFields;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplayName1;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnCode;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnName;
        private DevExpress.XtraGrid.Columns.GridColumn colLAST_UPD1;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnUpdInit1;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnAP;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnAR;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnCity;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnOper;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnIncl1;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnIncl2;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnIncl3;
        private DevExpress.XtraGrid.Columns.GridColumn colINCL4;
        private DevExpress.XtraGrid.Columns.GridColumn colINCL5;
        private DevExpress.XtraGrid.Columns.GridColumn colINCL6;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnRateBasis;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnRstr_Cde;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnTransferType;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnServiceList;
        private DevExpress.XtraGrid.Columns.GridColumn colPUDRP_REQ;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnService_Type;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnUseClientLogo;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnVouchDaysPrior;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnLatitude;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnLongitude;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnUserDec1;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnUserDec2;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnUserInt1;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnUserInt2;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnUserTxt1;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnUserTxt2;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnUserTxt3;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnUserTxt4;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnUserDte1;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnUserDte2;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnState;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnZip;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnTown;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnGMACCTNO;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnAddr1;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnAddr2;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnAddr3;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnCountry;
        private DevExpress.XtraGrid.Columns.GridColumn ColCityMiles;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnAirport;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnAirportMiles;
        private DevExpress.XtraGrid.Columns.GridColumn colMultiple_Times;
        private DevExpress.XtraGrid.Columns.GridColumn colDefault_Time;
        private DevExpress.XtraGrid.Columns.GridColumn colTransfer_List;
        private DevExpress.XtraGrid.Columns.GridColumn colRequire_ArvInfo;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnRequiredDepInfo;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnAllowFreesell;
        private DevExpress.XtraGrid.Columns.GridColumn colInactive1;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnVendorCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDue_Days;
        private DevExpress.XtraGrid.Columns.GridColumn colLanguage_Code;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnType1;
        private DevExpress.XtraGrid.Columns.GridColumn colGeoCode_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colDifficulty;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnMealsIncluded;
        private DevExpress.XtraGrid.Columns.GridColumn colDuration;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnAdmin;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnUnit_Rate;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnAirport1;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnCityCod;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnCountry1;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnLanguage;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnOperator;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnSERVTYPE;
        private DevExpress.XtraGrid.Columns.GridColumn colCPRATES;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnServRestr;
        private DevExpress.XtraEditors.TextEdit default_TimeTextEdit;
        private System.Windows.Forms.BindingSource ComProd2BindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox RepositoryItemImageComboBoxCarOffice;
        private DevExpress.XtraEditors.TextEdit TextEditCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboboxLocationType;
        private DevExpress.XtraEditors.PanelControl PanelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
		private System.Windows.Forms.BindingSource BindingSourceCompBusRoutes;
		private System.Windows.Forms.BindingSource BindingSourceBusRoutes;
        private System.Windows.Forms.BindingSource BindingSourceSupplierProduct;
        private System.Windows.Forms.BindingSource BindingSourceBusRouteStop;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager BarManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem BarButtonItemNew;
        private DevExpress.XtraBars.BarButtonItem BarButtonItemDelete;
        private DevExpress.XtraBars.BarButtonItem BarButtonItemSave;
        private System.Windows.Forms.BindingSource BindingSourceSupplierCategory;
        private System.Windows.Forms.BindingSource BindingSourceCodeName;
        private DevExpress.Data.Linq.EntityInstantFeedbackSource EntityInstantFeedbackSource;
        private DevExpress.XtraEditors.SearchLookUpEdit SearchLookupEditOperator;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.SearchLookUpEdit SearchLookupEditLanguage;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraEditors.SearchLookUpEdit SearchLookupEditDifficulty;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView8;
        private DevExpress.XtraMap.BingMapDataProvider BingMapDataProvider;
        private DevExpress.XtraMap.MapItemStorage MapItemStorage;
        private DevExpress.XtraMap.BingSearchDataProvider BingSearchDataProvider;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageLocation;
        private DevExpress.XtraEditors.PanelControl PanelControlLocationTab;
        private DevExpress.XtraEditors.LabelControl LabelControlLon;
        private DevExpress.XtraEditors.LabelControl LabelControlLat;
        private DevExpress.XtraEditors.SimpleButton SimpleButtonPlot;
        private DevExpress.XtraMap.MapControl MapControl;
        private DevExpress.XtraMap.ImageLayer ImageLayer;
        private DevExpress.XtraMap.VectorItemsLayer VectorItemsLayer;
        private DevExpress.XtraMap.InformationLayer InformationLayer;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit CheckEditProximitySearch;
        private DevExpress.XtraEditors.SpinEdit SpinEditDistance;
        private DevExpress.XtraEditors.TextEdit TextEditCityMilesTo;
        private DevExpress.XtraEditors.LabelControl LabelCityCode;
        private DevExpress.XtraEditors.LabelControl LabelCity;
        private DevExpress.XtraEditors.LabelControl LabelAirport;
        private DevExpress.XtraEditors.TextEdit TextEditAirportMiles;
        private DevExpress.XtraEditors.LabelControl LabelAirportCode;
        private DevExpress.XtraEditors.TextEdit TextEditAddr1;
        private DevExpress.XtraEditors.TextEdit TextEditZip;
        private DevExpress.XtraEditors.TextEdit TextEditTown;
        private DevExpress.XtraEditors.LabelControl LabelAddressCity;
        private DevExpress.XtraEditors.LabelControl LabelCountry;
        private DevExpress.XtraEditors.TextEdit TextEditAddr2;
        private DevExpress.XtraEditors.LabelControl LabelState;
        private DevExpress.XtraEditors.LabelControl LabelZip;
        private DevExpress.XtraEditors.TextEdit TextEditAddr3;
        private DevExpress.XtraEditors.SearchLookUpEdit SearchLookupEditState;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView6;
        private DevExpress.XtraEditors.SearchLookUpEdit SearchLookupEditCountry;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView7;
        private DevExpress.XtraEditors.SearchLookUpEdit SearchLookupEditCity;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView10;
        private DevExpress.XtraEditors.SearchLookUpEdit SearchLookupEditAirportCode;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView11;
        private DevExpress.XtraTab.XtraTabPage xtraTabPagePolicies;
        private DevExpress.XtraEditors.PanelControl PanelControlPoliciesTab;
        private DevExpress.XtraEditors.TextEdit TextEditDueDays;
        private DevExpress.XtraEditors.TextEdit TextEditARNumber;
        private DevExpress.XtraEditors.TextEdit TextEditAPNumber;
        private DevExpress.XtraEditors.CheckEdit checkEditDropoffInfoRequired;
        private DevExpress.XtraEditors.CheckEdit checkEditPickupInfoRequired;
        private DevExpress.XtraEditors.CheckEdit checkEditPassengerWeightRequired;
        private DevExpress.XtraEditors.CheckEdit checkEditAccountingServiceItem;
        private DevExpress.XtraEditors.CheckEdit CheckEditVendorPrepayReqd;
        private DevExpress.XtraEditors.CheckEdit unit_RateCheckEdit;
        private DevExpress.XtraEditors.CheckEdit CheckEditAdmin;
        private DevExpress.XtraEditors.CheckEdit mealsIncludedCheckEdit;
        private DevExpress.XtraEditors.CheckEdit CheckEditMultTimes;
        private DevExpress.XtraEditors.CheckEdit CheckEditAllowFree;
        private DevExpress.XtraEditors.CheckEdit CheckEditClientLogo;
        private DevExpress.XtraEditors.SpinEdit SpinEditDayPrior;
        private DevExpress.XtraEditors.CheckEdit CheckEditReqDepInfo;
        private DevExpress.XtraEditors.CheckEdit CheckEditReqArvInfo;
        private DevExpress.XtraEditors.CheckEdit CheckEditDropoff;
        private DevExpress.XtraEditors.CheckEdit CheckEditPickup;
        private DevExpress.XtraEditors.CheckEdit CheckEditTransferList;
        private DevExpress.XtraEditors.CheckEdit CheckEditSvcList;
        private DevExpress.XtraEditors.LabelControl LabelServiceType;
        private DevExpress.XtraEditors.SpinEdit SpinEditDuration;
        private DevExpress.XtraEditors.SearchLookUpEdit SearchLookupEditServiceType;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView9;
        private DevExpress.XtraEditors.ImageComboBoxEdit ImageComboBoxEditTransType;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageServices;
        private DevExpress.XtraEditors.PanelControl PanelControlServicesTab;
        private DevExpress.XtraEditors.TextEdit TextEditIncl6;
        private DevExpress.XtraEditors.TextEdit TextEditIncl1;
        private DevExpress.XtraEditors.TextEdit TextEditIncl3;
        private DevExpress.XtraEditors.TextEdit TextEditIncl5;
        private DevExpress.XtraEditors.TextEdit TextEditIncl4;
        private DevExpress.XtraEditors.TextEdit TextEditIncl2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageRoutes;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonRemoveRoute;
        private DevExpress.XtraEditors.SimpleButton simpleButtonAddRoute;
        private DevExpress.XtraGrid.GridControl GridControlRoutes;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewRoutes;
        private DevExpress.XtraGrid.Columns.GridColumn colID1;
        private DevExpress.XtraGrid.Columns.GridColumn colComp_Code;
        private DevExpress.XtraGrid.Columns.GridColumn colBusRoute_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditBusRoutes;
        private DevExpress.XtraGrid.Columns.GridColumn colCPRates_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colCOMP;
        private DevExpress.XtraGrid.Columns.GridColumn colBusRoute;
        private DevExpress.XtraGrid.Columns.GridColumn colCPRATES1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnEndDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnFromStop;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditStop;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnToStop;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnInactive;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEditInactive;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageTransferPoints;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.SimpleButton ButtonAddRow;
        private DevExpress.XtraGrid.GridControl GridControlTransferPoints;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewTransferPoints;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplayName;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnType;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnCode1;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnPickDrop;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox RepositoryItemImageComboBoxPickDrop;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnStartDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEditDate;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnLocation;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit RepositoryItemSearchLookupEditLocation;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemImageComboboxLocationView;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnDepartureTime;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnLastUpd;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnUpdInit;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnInOut;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnEndDate;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnLocationType;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnCarOffice;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnArrivalTime;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnExclusion;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnRoute;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBoxRoutes;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCat;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit RepositoryItemSearchLookUpEditCat;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnServiceTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit RepositoryItemTimeEditServiceTime;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageMemberships;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl GridControlDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewDetail;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colLINK_TABLE1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn colLINK_VALUE1;
        private DevExpress.XtraGrid.Columns.GridColumn colCODE1;
        private DevExpress.XtraGrid.Columns.GridColumn colNOTE;
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
        private DevExpress.XtraEditors.SimpleButton buttonDelMembership;
        private DevExpress.XtraEditors.SimpleButton buttonAddMembership;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageCustom;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        private DevExpress.XtraGrid.GridControl GridControlUserfields;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewUserFields;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnLinkTable;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnLink_Column;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnRecType;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnLabel;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnDescription;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnVisible;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnLinkupCodeColumn;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnLookupDescColumn;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnLookupTable;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnSize;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnMin;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnMax;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnRestrictToLookup;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnPrecision;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnRequired;
        private DevExpress.XtraGrid.Columns.GridColumn ColPosition1;
        private DevExpress.XtraGrid.Columns.GridColumn GridColumnCustomValue;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageCommissions;
        private DevExpress.XtraEditors.PanelControl panelControl7;
        private DevExpress.XtraEditors.LabelControl LabelSource;
        private DevExpress.XtraEditors.ComboBoxEdit ComboBoxEditSource;
        private DevExpress.XtraEditors.LabelControl LabelMarkups;
        private DevExpress.XtraEditors.LabelControl LabelCommissions;
        private DevExpress.XtraGrid.GridControl GridControlMarkups;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMarkups;
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
        private DevExpress.XtraGrid.Columns.GridColumn colRectype1;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnSourceComm;
        private DevExpress.XtraGrid.Columns.GridColumn colExclusion1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnCategoryComm;
        private DevExpress.XtraEditors.SimpleButton ButtonSearch;
        private DevExpress.XtraEditors.SearchLookUpEdit SearchLookupEditAgency;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageSupplierMapping;
        private DevExpress.XtraGrid.GridControl GridControlSupplierProduct;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewSupplierProduct;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSupplierProductId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnProductType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSupplierGuid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnProductSupplierCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditMax50;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMappingInactive;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMappingCustom1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMappingCustom2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMappingSvcStart;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMappingSvcEnd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMappingResStart;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMappingResEnd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMappingDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMappingOperator;
        private DevExpress.XtraGrid.Columns.GridColumn colRoomcod_Code_Default;
        private Custom_SearchLookupEdit.RepositoryItemCustomSearchLookUpEdit repositoryItemCustomSearchLookUpEditDefaultCat;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemCustomSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colCode4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn colPickup_LocationType_Default;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxDefaultPupLocType;
        private DevExpress.XtraGrid.Columns.GridColumn colPickup_Location_Default;
        private Custom_SearchLookupEdit.RepositoryItemCustomSearchLookUpEdit repositoryItemCustomSearchLookUpEditDefaultPUpLoc;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colCode2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn colPickup_Time_Default;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repositoryItemTimeEditDefault;
        private DevExpress.XtraGrid.Columns.GridColumn colDropoff_LocationType_Default;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxDefaultDrpLocType;
        private DevExpress.XtraGrid.Columns.GridColumn colDropoff_Location_Default;
        private Custom_SearchLookupEdit.RepositoryItemCustomSearchLookUpEdit repositoryItemCustomSearchLookUpEditDefaultDropLoc;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn colCode6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn colDropoff_Time_Default;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton SimpleButtonDelSuppMapping;
        private DevExpress.XtraEditors.SimpleButton SimpleButtonAddSuppMapping;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageSupplierCategories;
        private DevExpress.XtraEditors.PanelControl panelControl8;
        private DevExpress.XtraEditors.SimpleButton simpleButtonDelSuppCat;
        private DevExpress.XtraEditors.SimpleButton simpleButtonAddSuppCat;
        private DevExpress.XtraGrid.GridControl GridControlSupplierCategory;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewSupplierCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colId3;
        private DevExpress.XtraGrid.Columns.GridColumn colCode3;
        private DevExpress.XtraGrid.Columns.GridColumn colCatMappingSupplier;
        private DevExpress.XtraGrid.Columns.GridColumn colProduct_Code;
        private DevExpress.XtraGrid.Columns.GridColumn colCatMappingRoomcod;
        private Custom_SearchLookupEdit.RepositoryItemCustomSearchLookUpEdit RepositoryItemCustomSearchLookUpEditMappingCat;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn colInactive3;
        private DevExpress.XtraGrid.Columns.GridColumn colROOMCOD1;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplier;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSuppCatName;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView12;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView13;
        private DevExpress.XtraEditors.SimpleButton ButtonDelRow;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repositoryItemSearchLookUpEditClass;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView14;
        private DevExpress.XtraGrid.Columns.GridColumn colCode5;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxLocType;
        private DevExpress.XtraEditors.TimeEdit TextEditDefaultTime;
        private DevExpress.XtraEditors.DateEdit ButtonEditDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCode10;
        private DevExpress.XtraGrid.Columns.GridColumn colName4;
        private DevExpress.XtraGrid.Columns.GridColumn colCode11;
        private DevExpress.XtraGrid.Columns.GridColumn colName5;
        private DevExpress.XtraGrid.Columns.GridColumn colCode12;
        private DevExpress.XtraGrid.Columns.GridColumn colName6;
        private DevExpress.XtraGrid.Columns.GridColumn colCode8;
        private DevExpress.XtraGrid.Columns.GridColumn colName2;
        private DevExpress.XtraGrid.Columns.GridColumn colCode7;
        private DevExpress.XtraGrid.Columns.GridColumn colName1;
        private System.Windows.Forms.BindingSource BindingSourceIdName;
        private DevExpress.XtraGrid.Columns.GridColumn colId2;
        private DevExpress.XtraGrid.Columns.GridColumn colName3;
        private DevExpress.XtraGrid.Columns.GridColumn colCode9;
        private DevExpress.XtraGrid.Columns.GridColumn colName7;
        private DevExpress.XtraGrid.Columns.GridColumn colCode13;
        private DevExpress.XtraGrid.Columns.GridColumn colName8;
        private DevExpress.XtraEditors.SpinEdit spinEdit1;
        private DevExpress.XtraEditors.SpinEdit SpinEditRanking;
        private DevExpress.XtraEditors.CheckEdit CheckEditDOBRequired;
        private DevExpress.XtraEditors.SpinEdit spinEdit2;
        private DevExpress.XtraEditors.RatingControl RatingControlStars;
        private DevExpress.XtraEditors.ImageComboBoxEdit ImageComboBoxEditVoucherTypes;
        private DevExpress.XtraEditors.CheckEdit CheckEditAllNames;
        private DevExpress.XtraEditors.CheckEdit CheckEditAdminClosed;
        private DevExpress.XtraEditors.SpinEdit SpinEditMaxPax;
        private DevExpress.XtraEditors.SpinEdit SpinEditStartingAgentNet;
        private DevExpress.XtraEditors.SpinEdit SpinEditStartingComparison;
        private DevExpress.XtraEditors.SpinEdit spinEditStartingPrice;
        private DevExpress.XtraEditors.SpinEdit SpinEditStartingCost;
        private DevExpress.XtraEditors.SpinEdit SpinEditOnRequestPeriod;
        private DevExpress.XtraEditors.ImageComboBoxEdit ImageComboBoxEditConfirmationType;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraEditors.CheckEdit CheckEditIsSupplement;
        private DevExpress.XtraEditors.CheckEdit CheckEditSupplementPaySupplier;
        private DevExpress.XtraEditors.CheckEdit CheckEditSupplementIsBoard;
        private DevExpress.XtraGrid.GridControl GridControlSupplements;
        private System.Windows.Forms.BindingSource BindingSourceSupplements;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewSupplement;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView20;
        private DevExpress.XtraEditors.CheckEdit CheckEditSupplementQtySelectable;
        private DevExpress.XtraGrid.Columns.GridColumn colId4;
        private DevExpress.XtraGrid.Columns.GridColumn colProduct_Type;
        private DevExpress.XtraGrid.Columns.GridColumn colProduct_Code1;
        private DevExpress.XtraGrid.Columns.GridColumn colComp_Type;
        private DevExpress.XtraGrid.Columns.GridColumn colComp_Code1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit RepositoryItemSearchLookUpEditCompCode;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit3View;
        private DevExpress.XtraGrid.Columns.GridColumn colCode14;
        private DevExpress.XtraGrid.Columns.GridColumn colName9;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplementIncluded;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplementMandatory;
        private DevExpress.XtraGrid.Columns.GridColumn colRateSheet_Id;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplementType;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox RepositoryItemImageComboBoxSupplementType;
        private DevExpress.XtraEditors.SimpleButton SimpleButtonDeleteSupplement;
        private DevExpress.XtraEditors.SimpleButton SimpleButtonAddSupplement;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageRelatedProducts;
        private DevExpress.XtraEditors.PanelControl panelControl9;
        private DevExpress.XtraEditors.SimpleButton SimpleButtonDeletePassProduct;
        private DevExpress.XtraEditors.SimpleButton SimpleButtonAddPass;
        private DevExpress.XtraGrid.GridControl GridControlRelatedProducts;
        private System.Windows.Forms.BindingSource BindingSourceRelatedProduct;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewRelatedProducts;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView18;
        private DevExpress.XtraGrid.Columns.GridColumn colID5;
        private DevExpress.XtraGrid.Columns.GridColumn colRelatedType;
        private DevExpress.XtraGrid.Columns.GridColumn colRelatedCode;
        private DevExpress.XtraGrid.Columns.GridColumn colExcluded;
        private DevExpress.XtraGrid.Columns.GridColumn colServiceStart;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit RepositoryItemDateEditSvcStart;
        private DevExpress.XtraGrid.Columns.GridColumn colServiceEnd;
        private DevExpress.XtraGrid.Columns.GridColumn colBookingStart;
        private DevExpress.XtraGrid.Columns.GridColumn colBookingEnd;
        private DevExpress.XtraGrid.Columns.GridColumn colInactive2;
        private DevExpress.XtraGrid.Columns.GridColumn colPosition;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscountPct;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscountFlat;
        private DevExpress.XtraGrid.Columns.GridColumn colReciprocal;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox RepositoryItemComboBoxType;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView17;
        private DevExpress.XtraGrid.Columns.GridColumn colIsRoundTrip;
        private DevExpress.XtraGrid.Columns.GridColumn colIsReturn;
        private DevExpress.XtraGrid.Columns.GridColumn colForUpSell;
        private DevExpress.XtraGrid.Columns.GridColumn colForPackaging;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit RepositoryItemSearchLookUpEditRelatedProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCode15;
        private DevExpress.XtraGrid.Columns.GridColumn colName10;
        private DevExpress.XtraEditors.CheckEdit CheckEditPhone;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SearchLookUpEdit SearchLookupEditDepCity;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraEditors.SearchLookUpEdit SearchLookUpEditRegion;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn colMarkupPct;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit RepositoryItemSpinEditMarkupPct;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplierCommPct;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit RepositoryItemSpinEditSupplierCommPct;
        private DevExpress.XtraGrid.Columns.GridColumn colRetailMarkupPct;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit RepositoryItemSpinEditRetailMarkupPct;
        private DevExpress.XtraGrid.Columns.GridColumn colMarkupFlat;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit RepositoryItemSpinEditMarkupFlat;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplierCommFlat;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit RepositoryItemSpinEditSupplierCommFlat;
        private DevExpress.XtraGrid.Columns.GridColumn colRetailMarkupFlat;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit RepositoryItemSpinEditRetailMarkupFlat;
        private DevExpress.XtraGrid.Columns.GridColumn colCode17;
        private DevExpress.XtraGrid.Columns.GridColumn colName12;
        private DevExpress.XtraGrid.Columns.GridColumn colCode16;
        private DevExpress.XtraGrid.Columns.GridColumn colName11;
        private DevExpress.XtraBars.BarButtonItem BarButtonItemUpdateWebsite;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEditLocationExclusion;
    }
}
