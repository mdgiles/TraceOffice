namespace TraceForms
{
    partial class WaypointForm
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
            System.Windows.Forms.Label durationLabel;
            System.Windows.Forms.Label LabelLat;
            System.Windows.Forms.Label LabelLong;
            System.Windows.Forms.Label LabelMappings;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaypointForm));
            this.BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.TextEditTown = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.TextEditAddress1 = new DevExpress.XtraEditors.TextEdit();
            this.TextEditAddress2 = new DevExpress.XtraEditors.TextEdit();
            this.TextEditAddress3 = new DevExpress.XtraEditors.TextEdit();
            this.TextEditZip = new DevExpress.XtraEditors.TextEdit();
            this.TextEditCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.TextEditDesc = new DevExpress.XtraEditors.TextEdit();
            this.GridControlLookup = new DevExpress.XtraGrid.GridControl();
            this.EntityInstantFeedbackSource = new DevExpress.Data.Linq.EntityInstantFeedbackSource();
            this.GridViewLookup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GridColumnCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumnDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.SplitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.ButtonAddMapping = new DevExpress.XtraEditors.SimpleButton();
            this.ButtonDeleteMapping = new DevExpress.XtraEditors.SimpleButton();
            this.GridControlSupplierProduct = new DevExpress.XtraGrid.GridControl();
            this.BindingSourceSupplierProduct = new System.Windows.Forms.BindingSource(this.components);
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
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPickup_Time_Default = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTimeEditDefault = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.colDropoff_LocationType_Default = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBoxDefaultDrpLocType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colDropoff_Location_Default = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCustomSearchLookUpEditDefaultDropLoc = new Custom_SearchLookupEdit.RepositoryItemCustomSearchLookUpEdit();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDropoff_Time_Default = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplierProduct_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LabelControlLon = new DevExpress.XtraEditors.LabelControl();
            this.LabelControlLat = new DevExpress.XtraEditors.LabelControl();
            this.SimpleButtonPlot = new DevExpress.XtraEditors.SimpleButton();
            this.MapControl = new DevExpress.XtraMap.MapControl();
            this.ImageLayer = new DevExpress.XtraMap.ImageLayer();
            this.BingMapDataProvider = new DevExpress.XtraMap.BingMapDataProvider();
            this.VectorItemsLayer = new DevExpress.XtraMap.VectorItemsLayer();
            this.MapItemStorage = new DevExpress.XtraMap.MapItemStorage();
            this.InformationLayer = new DevExpress.XtraMap.InformationLayer();
            this.BingSearchDataProvider = new DevExpress.XtraMap.BingSearchDataProvider();
            this.checkEditSearchable = new DevExpress.XtraEditors.CheckEdit();
            this.SpinEditDuration = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.CheckEditProximitySearch = new DevExpress.XtraEditors.CheckEdit();
            this.SpinEditDistance = new DevExpress.XtraEditors.SpinEdit();
            this.SearchLookupEditState = new Custom_SearchLookupEdit.CustomSearchLookUpEdit();
            this.BindingSourceCodeName = new System.Windows.Forms.BindingSource(this.components);
            this.customSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDisplayName2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SearchLookupEditCountry = new Custom_SearchLookupEdit.CustomSearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDisplayName3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SearchLookupEditCity = new Custom_SearchLookupEdit.CustomSearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDisplayName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PanelControlStatus = new DevExpress.XtraEditors.PanelControl();
            this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
            this.BarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.BarButtonItemNew = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItemDelete = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.GridColumnAddress1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumnAddress2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumnAddress3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumnCity = new DevExpress.XtraGrid.Columns.GridColumn();
            durationLabel = new System.Windows.Forms.Label();
            LabelLat = new System.Windows.Forms.Label();
            LabelLong = new System.Windows.Forms.Label();
            LabelMappings = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditTown.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditAddress1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditAddress2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditAddress3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditZip.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl)).BeginInit();
            this.SplitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlSupplierProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceSupplierProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSupplierProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditMax50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCustomSearchLookUpEditDefaultCat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCustomSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxDefaultPupLocType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCustomSearchLookUpEditDefaultPUpLoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEditDefault)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxDefaultDrpLocType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCustomSearchLookUpEditDefaultDropLoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MapControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditSearchable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditDuration.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditProximitySearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditDistance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceCodeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditCountry.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditCity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlStatus)).BeginInit();
            this.PanelControlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            this.SuspendLayout();
            // 
            // durationLabel
            // 
            durationLabel.AutoSize = true;
            durationLabel.Location = new System.Drawing.Point(29, 761);
            durationLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            durationLabel.Name = "durationLabel";
            durationLabel.Size = new System.Drawing.Size(92, 25);
            durationLabel.TabIndex = 24;
            durationLabel.Text = "Duration";
            // 
            // LabelLat
            // 
            LabelLat.AutoSize = true;
            LabelLat.Location = new System.Drawing.Point(172, 541);
            LabelLat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LabelLat.Name = "LabelLat";
            LabelLat.Size = new System.Drawing.Size(94, 25);
            LabelLat.TabIndex = 275;
            LabelLat.Text = "Latitude:";
            // 
            // LabelLong
            // 
            LabelLong.AutoSize = true;
            LabelLong.Location = new System.Drawing.Point(172, 568);
            LabelLong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LabelLong.Name = "LabelLong";
            LabelLong.Size = new System.Drawing.Size(111, 25);
            LabelLong.TabIndex = 274;
            LabelLong.Text = "Longitude:";
            // 
            // LabelMappings
            // 
            LabelMappings.AutoSize = true;
            LabelMappings.Location = new System.Drawing.Point(29, 827);
            LabelMappings.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LabelMappings.Name = "LabelMappings";
            LabelMappings.Size = new System.Drawing.Size(192, 25);
            LabelMappings.TabIndex = 284;
            LabelMappings.Text = "Supplier Mappings:";
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(FlexModel.WAYPOINT);
            this.BindingSource.CurrentChanged += new System.EventHandler(this.BindingSource_CurrentChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(34, 279);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(35, 25);
            this.labelControl3.TabIndex = 22;
            this.labelControl3.Text = "City";
            // 
            // TextEditTown
            // 
            this.TextEditTown.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Town", true));
            this.TextEditTown.EnterMoveNextControl = true;
            this.TextEditTown.Location = new System.Drawing.Point(160, 323);
            this.TextEditTown.Margin = new System.Windows.Forms.Padding(6);
            this.TextEditTown.Name = "TextEditTown";
            this.TextEditTown.Properties.MaxLength = 30;
            this.TextEditTown.Size = new System.Drawing.Size(482, 40);
            this.TextEditTown.TabIndex = 10;
            this.TextEditTown.Leave += new System.EventHandler(this.TextEditTown_Leave);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(34, 129);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(56, 25);
            this.labelControl8.TabIndex = 5;
            this.labelControl8.Text = "Street";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(34, 329);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(51, 25);
            this.labelControl7.TabIndex = 9;
            this.labelControl7.Text = "Town";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(34, 385);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(48, 25);
            this.labelControl6.TabIndex = 11;
            this.labelControl6.Text = "State";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(34, 431);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(29, 25);
            this.labelControl5.TabIndex = 13;
            this.labelControl5.Text = "Zip";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(34, 481);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(73, 25);
            this.labelControl4.TabIndex = 15;
            this.labelControl4.Text = "Country";
            // 
            // TextEditAddress1
            // 
            this.TextEditAddress1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "ADDRESS1", true));
            this.TextEditAddress1.EnterMoveNextControl = true;
            this.TextEditAddress1.Location = new System.Drawing.Point(160, 123);
            this.TextEditAddress1.Margin = new System.Windows.Forms.Padding(6);
            this.TextEditAddress1.Name = "TextEditAddress1";
            this.TextEditAddress1.Properties.MaxLength = 40;
            this.TextEditAddress1.Size = new System.Drawing.Size(482, 40);
            this.TextEditAddress1.TabIndex = 6;
            this.TextEditAddress1.Leave += new System.EventHandler(this.TextEditAddress1_Leave);
            // 
            // TextEditAddress2
            // 
            this.TextEditAddress2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "ADDRESS2", true));
            this.TextEditAddress2.EnterMoveNextControl = true;
            this.TextEditAddress2.Location = new System.Drawing.Point(160, 173);
            this.TextEditAddress2.Margin = new System.Windows.Forms.Padding(6);
            this.TextEditAddress2.Name = "TextEditAddress2";
            this.TextEditAddress2.Properties.MaxLength = 40;
            this.TextEditAddress2.Size = new System.Drawing.Size(482, 40);
            this.TextEditAddress2.TabIndex = 7;
            this.TextEditAddress2.Leave += new System.EventHandler(this.TextEditAddress2_Leave);
            // 
            // TextEditAddress3
            // 
            this.TextEditAddress3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "ADDRESS3", true));
            this.TextEditAddress3.EnterMoveNextControl = true;
            this.TextEditAddress3.Location = new System.Drawing.Point(160, 223);
            this.TextEditAddress3.Margin = new System.Windows.Forms.Padding(6);
            this.TextEditAddress3.Name = "TextEditAddress3";
            this.TextEditAddress3.Properties.MaxLength = 40;
            this.TextEditAddress3.Size = new System.Drawing.Size(482, 40);
            this.TextEditAddress3.TabIndex = 8;
            this.TextEditAddress3.Leave += new System.EventHandler(this.TextEditAddress3_Leave);
            // 
            // TextEditZip
            // 
            this.TextEditZip.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "ZIP", true));
            this.TextEditZip.EnterMoveNextControl = true;
            this.TextEditZip.Location = new System.Drawing.Point(160, 425);
            this.TextEditZip.Margin = new System.Windows.Forms.Padding(6);
            this.TextEditZip.Name = "TextEditZip";
            this.TextEditZip.Properties.MaxLength = 10;
            this.TextEditZip.Size = new System.Drawing.Size(200, 40);
            this.TextEditZip.TabIndex = 14;
            this.TextEditZip.Leave += new System.EventHandler(this.TextEditZip_Leave);
            // 
            // TextEditCode
            // 
            this.TextEditCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CODE", true));
            this.TextEditCode.EnterMoveNextControl = true;
            this.TextEditCode.Location = new System.Drawing.Point(160, 23);
            this.TextEditCode.Margin = new System.Windows.Forms.Padding(6);
            this.TextEditCode.Name = "TextEditCode";
            this.TextEditCode.Properties.MaxLength = 12;
            this.TextEditCode.Size = new System.Drawing.Size(200, 40);
            this.TextEditCode.TabIndex = 1;
            this.TextEditCode.Leave += new System.EventHandler(this.TextEditCode_Leave);
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(34, 79);
            this.labelControl13.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(54, 25);
            this.labelControl13.TabIndex = 2;
            this.labelControl13.Text = "Name";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(34, 29);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(47, 25);
            this.labelControl9.TabIndex = 0;
            this.labelControl9.Text = "Code";
            // 
            // TextEditDesc
            // 
            this.TextEditDesc.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "DESC", true));
            this.TextEditDesc.EnterMoveNextControl = true;
            this.TextEditDesc.Location = new System.Drawing.Point(160, 73);
            this.TextEditDesc.Margin = new System.Windows.Forms.Padding(6);
            this.TextEditDesc.Name = "TextEditDesc";
            this.TextEditDesc.Properties.MaxLength = 60;
            this.TextEditDesc.Size = new System.Drawing.Size(712, 40);
            this.TextEditDesc.TabIndex = 3;
            this.TextEditDesc.Leave += new System.EventHandler(this.TextEditDesc_Leave);
            // 
            // GridControlLookup
            // 
            this.GridControlLookup.DataSource = this.EntityInstantFeedbackSource;
            this.GridControlLookup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControlLookup.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6);
            this.GridControlLookup.Location = new System.Drawing.Point(0, 0);
            this.GridControlLookup.MainView = this.GridViewLookup;
            this.GridControlLookup.Margin = new System.Windows.Forms.Padding(6);
            this.GridControlLookup.Name = "GridControlLookup";
            this.GridControlLookup.Size = new System.Drawing.Size(380, 1256);
            this.GridControlLookup.TabIndex = 0;
            this.GridControlLookup.TabStop = false;
            this.GridControlLookup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewLookup});
            // 
            // EntityInstantFeedbackSource
            // 
            this.EntityInstantFeedbackSource.DesignTimeElementType = typeof(FlexModel.WAYPOINT);
            this.EntityInstantFeedbackSource.KeyExpression = "CODE";
            this.EntityInstantFeedbackSource.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.EntityInstantFeedbackSource_GetQueryable);
            this.EntityInstantFeedbackSource.DismissQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.EntityInstantFeedbackSource_DismissQueryable);
            // 
            // GridViewLookup
            // 
            this.GridViewLookup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GridColumnCode,
            this.GridColumnDesc});
            this.GridViewLookup.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.GridViewLookup.GridControl = this.GridControlLookup;
            this.GridViewLookup.Name = "GridViewLookup";
            this.GridViewLookup.OptionsBehavior.Editable = false;
            this.GridViewLookup.OptionsView.ShowAutoFilterRow = true;
            this.GridViewLookup.OptionsView.ShowGroupPanel = false;
            this.GridViewLookup.OptionsView.ShowIndicator = false;
            this.GridViewLookup.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewLookup_FocusedRowChanged);
            this.GridViewLookup.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.GridViewLookup_BeforeLeaveRow);
            this.GridViewLookup.ColumnFilterChanged += new System.EventHandler(this.GridViewLookup_ColumnFilterChanged);
            // 
            // GridColumnCode
            // 
            this.GridColumnCode.Caption = "Code";
            this.GridColumnCode.FieldName = "CODE";
            this.GridColumnCode.Name = "GridColumnCode";
            this.GridColumnCode.Visible = true;
            this.GridColumnCode.VisibleIndex = 0;
            // 
            // GridColumnDesc
            // 
            this.GridColumnDesc.Caption = "Name";
            this.GridColumnDesc.FieldName = "DESC";
            this.GridColumnDesc.Name = "GridColumnDesc";
            this.GridColumnDesc.Visible = true;
            this.GridColumnDesc.VisibleIndex = 1;
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // SplitContainerControl
            // 
            this.SplitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerControl.Location = new System.Drawing.Point(0, 60);
            this.SplitContainerControl.Margin = new System.Windows.Forms.Padding(6);
            this.SplitContainerControl.Name = "SplitContainerControl";
            this.SplitContainerControl.Panel1.AutoScroll = true;
            this.SplitContainerControl.Panel1.Controls.Add(this.GridControlLookup);
            this.SplitContainerControl.Panel1.Text = "Panel1";
            this.SplitContainerControl.Panel2.AutoScroll = true;
            this.SplitContainerControl.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.SplitContainerControl.Panel2.Controls.Add(LabelMappings);
            this.SplitContainerControl.Panel2.Controls.Add(this.ButtonAddMapping);
            this.SplitContainerControl.Panel2.Controls.Add(this.ButtonDeleteMapping);
            this.SplitContainerControl.Panel2.Controls.Add(this.GridControlSupplierProduct);
            this.SplitContainerControl.Panel2.Controls.Add(this.LabelControlLon);
            this.SplitContainerControl.Panel2.Controls.Add(this.LabelControlLat);
            this.SplitContainerControl.Panel2.Controls.Add(this.SimpleButtonPlot);
            this.SplitContainerControl.Panel2.Controls.Add(LabelLat);
            this.SplitContainerControl.Panel2.Controls.Add(LabelLong);
            this.SplitContainerControl.Panel2.Controls.Add(this.MapControl);
            this.SplitContainerControl.Panel2.Controls.Add(this.checkEditSearchable);
            this.SplitContainerControl.Panel2.Controls.Add(durationLabel);
            this.SplitContainerControl.Panel2.Controls.Add(this.SpinEditDuration);
            this.SplitContainerControl.Panel2.Controls.Add(this.labelControl14);
            this.SplitContainerControl.Panel2.Controls.Add(this.CheckEditProximitySearch);
            this.SplitContainerControl.Panel2.Controls.Add(this.SpinEditDistance);
            this.SplitContainerControl.Panel2.Controls.Add(this.TextEditCode);
            this.SplitContainerControl.Panel2.Controls.Add(this.TextEditDesc);
            this.SplitContainerControl.Panel2.Controls.Add(this.labelControl9);
            this.SplitContainerControl.Panel2.Controls.Add(this.labelControl13);
            this.SplitContainerControl.Panel2.Controls.Add(this.TextEditZip);
            this.SplitContainerControl.Panel2.Controls.Add(this.TextEditAddress3);
            this.SplitContainerControl.Panel2.Controls.Add(this.TextEditAddress2);
            this.SplitContainerControl.Panel2.Controls.Add(this.labelControl3);
            this.SplitContainerControl.Panel2.Controls.Add(this.TextEditAddress1);
            this.SplitContainerControl.Panel2.Controls.Add(this.TextEditTown);
            this.SplitContainerControl.Panel2.Controls.Add(this.labelControl4);
            this.SplitContainerControl.Panel2.Controls.Add(this.labelControl5);
            this.SplitContainerControl.Panel2.Controls.Add(this.labelControl8);
            this.SplitContainerControl.Panel2.Controls.Add(this.labelControl6);
            this.SplitContainerControl.Panel2.Controls.Add(this.labelControl7);
            this.SplitContainerControl.Panel2.Controls.Add(this.SearchLookupEditState);
            this.SplitContainerControl.Panel2.Controls.Add(this.SearchLookupEditCountry);
            this.SplitContainerControl.Panel2.Controls.Add(this.SearchLookupEditCity);
            this.SplitContainerControl.Panel2.Text = "Panel2";
            this.SplitContainerControl.Size = new System.Drawing.Size(1980, 1256);
            this.SplitContainerControl.SplitterPosition = 380;
            this.SplitContainerControl.TabIndex = 0;
            this.SplitContainerControl.Text = "splitContainerControl1";
            // 
            // ButtonAddMapping
            // 
            this.ButtonAddMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonAddMapping.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonAddMapping.ImageOptions.Image")));
            this.ButtonAddMapping.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ButtonAddMapping.Location = new System.Drawing.Point(1033, 863);
            this.ButtonAddMapping.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ButtonAddMapping.Name = "ButtonAddMapping";
            this.ButtonAddMapping.Size = new System.Drawing.Size(82, 70);
            this.ButtonAddMapping.TabIndex = 283;
            this.ButtonAddMapping.Click += new System.EventHandler(this.ButtonAddMapping_Click);
            // 
            // ButtonDeleteMapping
            // 
            this.ButtonDeleteMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonDeleteMapping.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonDeleteMapping.ImageOptions.Image")));
            this.ButtonDeleteMapping.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ButtonDeleteMapping.Location = new System.Drawing.Point(1033, 953);
            this.ButtonDeleteMapping.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ButtonDeleteMapping.Name = "ButtonDeleteMapping";
            this.ButtonDeleteMapping.Size = new System.Drawing.Size(82, 70);
            this.ButtonDeleteMapping.TabIndex = 282;
            this.ButtonDeleteMapping.TabStop = false;
            this.ButtonDeleteMapping.Click += new System.EventHandler(this.ButtonDeleteMapping_Click);
            // 
            // GridControlSupplierProduct
            // 
            this.GridControlSupplierProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridControlSupplierProduct.DataSource = this.BindingSourceSupplierProduct;
            this.GridControlSupplierProduct.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(5);
            this.GridControlSupplierProduct.Location = new System.Drawing.Point(34, 863);
            this.GridControlSupplierProduct.MainView = this.GridViewSupplierProduct;
            this.GridControlSupplierProduct.Margin = new System.Windows.Forms.Padding(5);
            this.GridControlSupplierProduct.Name = "GridControlSupplierProduct";
            this.GridControlSupplierProduct.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEditMax50,
            this.repositoryItemComboBoxDefaultPupLocType,
            this.repositoryItemCustomSearchLookUpEditDefaultCat,
            this.repositoryItemCustomSearchLookUpEditDefaultPUpLoc,
            this.repositoryItemComboBoxDefaultDrpLocType,
            this.repositoryItemCustomSearchLookUpEditDefaultDropLoc,
            this.repositoryItemTimeEditDefault});
            this.GridControlSupplierProduct.Size = new System.Drawing.Size(978, 310);
            this.GridControlSupplierProduct.TabIndex = 279;
            this.GridControlSupplierProduct.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewSupplierProduct});
            this.GridControlSupplierProduct.Leave += new System.EventHandler(this.GridControlSupplierProduct_Leave);
            // 
            // BindingSourceSupplierProduct
            // 
            this.BindingSourceSupplierProduct.DataSource = typeof(FlexModel.SupplierProduct);
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
            this.colSupplierProduct_Name});
            this.GridViewSupplierProduct.GridControl = this.GridControlSupplierProduct;
            this.GridViewSupplierProduct.Name = "GridViewSupplierProduct";
            this.GridViewSupplierProduct.OptionsView.ColumnAutoWidth = false;
            this.GridViewSupplierProduct.OptionsView.ShowGroupPanel = false;
            this.GridViewSupplierProduct.OptionsView.ShowIndicator = false;
            this.GridViewSupplierProduct.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.GridViewSupplierProduct_CustomRowCellEdit);
            // 
            // gridColumnSupplierProductId
            // 
            this.gridColumnSupplierProductId.FieldName = "ID";
            this.gridColumnSupplierProductId.Name = "gridColumnSupplierProductId";
            this.gridColumnSupplierProductId.Width = 74;
            // 
            // gridColumnProductCode
            // 
            this.gridColumnProductCode.FieldName = "Product_Code_Internal";
            this.gridColumnProductCode.Name = "gridColumnProductCode";
            this.gridColumnProductCode.Width = 74;
            // 
            // gridColumnProductType
            // 
            this.gridColumnProductType.FieldName = "Product_Type";
            this.gridColumnProductType.Name = "gridColumnProductType";
            this.gridColumnProductType.Width = 74;
            // 
            // gridColumnSupplierGuid
            // 
            this.gridColumnSupplierGuid.Caption = "Supplier";
            this.gridColumnSupplierGuid.FieldName = "Supplier_GUID";
            this.gridColumnSupplierGuid.Name = "gridColumnSupplierGuid";
            this.gridColumnSupplierGuid.Visible = true;
            this.gridColumnSupplierGuid.VisibleIndex = 0;
            this.gridColumnSupplierGuid.Width = 244;
            // 
            // gridColumnProductSupplierCode
            // 
            this.gridColumnProductSupplierCode.Caption = "Supplier Code";
            this.gridColumnProductSupplierCode.ColumnEdit = this.repositoryItemTextEditMax50;
            this.gridColumnProductSupplierCode.FieldName = "ProductCodeSupplier";
            this.gridColumnProductSupplierCode.Name = "gridColumnProductSupplierCode";
            this.gridColumnProductSupplierCode.Visible = true;
            this.gridColumnProductSupplierCode.VisibleIndex = 1;
            this.gridColumnProductSupplierCode.Width = 187;
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
            this.gridColumnMappingInactive.Name = "gridColumnMappingInactive";
            this.gridColumnMappingInactive.Visible = true;
            this.gridColumnMappingInactive.VisibleIndex = 2;
            this.gridColumnMappingInactive.Width = 138;
            // 
            // gridColumnMappingCustom1
            // 
            this.gridColumnMappingCustom1.Caption = "Custom 1";
            this.gridColumnMappingCustom1.ColumnEdit = this.repositoryItemTextEditMax50;
            this.gridColumnMappingCustom1.FieldName = "Custom1";
            this.gridColumnMappingCustom1.Name = "gridColumnMappingCustom1";
            this.gridColumnMappingCustom1.Width = 170;
            // 
            // gridColumnMappingCustom2
            // 
            this.gridColumnMappingCustom2.Caption = "Custom 2";
            this.gridColumnMappingCustom2.ColumnEdit = this.repositoryItemTextEditMax50;
            this.gridColumnMappingCustom2.FieldName = "Custom2";
            this.gridColumnMappingCustom2.Name = "gridColumnMappingCustom2";
            this.gridColumnMappingCustom2.Width = 148;
            // 
            // gridColumnMappingSvcStart
            // 
            this.gridColumnMappingSvcStart.Caption = "Svc Start";
            this.gridColumnMappingSvcStart.DisplayFormat.FormatString = "dd-MMM-yy";
            this.gridColumnMappingSvcStart.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnMappingSvcStart.FieldName = "SvcDate_Start";
            this.gridColumnMappingSvcStart.Name = "gridColumnMappingSvcStart";
            this.gridColumnMappingSvcStart.Width = 180;
            // 
            // gridColumnMappingSvcEnd
            // 
            this.gridColumnMappingSvcEnd.Caption = "Svc End";
            this.gridColumnMappingSvcEnd.DisplayFormat.FormatString = "dd-MMM-yy";
            this.gridColumnMappingSvcEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnMappingSvcEnd.FieldName = "SvcDate_End";
            this.gridColumnMappingSvcEnd.Name = "gridColumnMappingSvcEnd";
            this.gridColumnMappingSvcEnd.Width = 180;
            // 
            // gridColumnMappingResStart
            // 
            this.gridColumnMappingResStart.Caption = "Res Start";
            this.gridColumnMappingResStart.DisplayFormat.FormatString = "dd-MMM-yy";
            this.gridColumnMappingResStart.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnMappingResStart.FieldName = "ResDate_Start";
            this.gridColumnMappingResStart.Name = "gridColumnMappingResStart";
            this.gridColumnMappingResStart.Width = 180;
            // 
            // gridColumnMappingResEnd
            // 
            this.gridColumnMappingResEnd.Caption = "Res End";
            this.gridColumnMappingResEnd.DisplayFormat.FormatString = "dd-MMM-yy";
            this.gridColumnMappingResEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnMappingResEnd.FieldName = "ResDate_End";
            this.gridColumnMappingResEnd.Name = "gridColumnMappingResEnd";
            this.gridColumnMappingResEnd.Width = 180;
            // 
            // gridColumnMappingDesc
            // 
            this.gridColumnMappingDesc.Caption = "Description";
            this.gridColumnMappingDesc.FieldName = "Description";
            this.gridColumnMappingDesc.Name = "gridColumnMappingDesc";
            this.gridColumnMappingDesc.Width = 223;
            // 
            // gridColumnMappingOperator
            // 
            this.gridColumnMappingOperator.Caption = "Operator";
            this.gridColumnMappingOperator.FieldName = "Operator_Code";
            this.gridColumnMappingOperator.Name = "gridColumnMappingOperator";
            this.gridColumnMappingOperator.Width = 197;
            // 
            // colRoomcod_Code_Default
            // 
            this.colRoomcod_Code_Default.Caption = "Default Cat";
            this.colRoomcod_Code_Default.ColumnEdit = this.repositoryItemCustomSearchLookUpEditDefaultCat;
            this.colRoomcod_Code_Default.FieldName = "Roomcod_Code_Default";
            this.colRoomcod_Code_Default.MinWidth = 42;
            this.colRoomcod_Code_Default.Name = "colRoomcod_Code_Default";
            this.colRoomcod_Code_Default.Width = 157;
            // 
            // repositoryItemCustomSearchLookUpEditDefaultCat
            // 
            this.repositoryItemCustomSearchLookUpEditDefaultCat.AutoHeight = false;
            this.repositoryItemCustomSearchLookUpEditDefaultCat.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.repositoryItemCustomSearchLookUpEditDefaultCat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCustomSearchLookUpEditDefaultCat.DisplayMember = "DisplayName";
            this.repositoryItemCustomSearchLookUpEditDefaultCat.Name = "repositoryItemCustomSearchLookUpEditDefaultCat";
            this.repositoryItemCustomSearchLookUpEditDefaultCat.NullText = "";
            this.repositoryItemCustomSearchLookUpEditDefaultCat.PopupView = this.repositoryItemCustomSearchLookUpEdit1View;
            this.repositoryItemCustomSearchLookUpEditDefaultCat.ValueMember = "Code";
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
            this.colPickup_LocationType_Default.MinWidth = 42;
            this.colPickup_LocationType_Default.Name = "colPickup_LocationType_Default";
            this.colPickup_LocationType_Default.Width = 168;
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
            this.colPickup_Location_Default.MinWidth = 42;
            this.colPickup_Location_Default.Name = "colPickup_Location_Default";
            this.colPickup_Location_Default.Width = 275;
            // 
            // repositoryItemCustomSearchLookUpEditDefaultPUpLoc
            // 
            this.repositoryItemCustomSearchLookUpEditDefaultPUpLoc.AutoHeight = false;
            this.repositoryItemCustomSearchLookUpEditDefaultPUpLoc.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.repositoryItemCustomSearchLookUpEditDefaultPUpLoc.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCustomSearchLookUpEditDefaultPUpLoc.DisplayMember = "DisplayName";
            this.repositoryItemCustomSearchLookUpEditDefaultPUpLoc.Name = "repositoryItemCustomSearchLookUpEditDefaultPUpLoc";
            this.repositoryItemCustomSearchLookUpEditDefaultPUpLoc.NullText = "";
            this.repositoryItemCustomSearchLookUpEditDefaultPUpLoc.PopupView = this.gridView3;
            this.repositoryItemCustomSearchLookUpEditDefaultPUpLoc.ValueMember = "Code";
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn5});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView3.OptionsView.ShowIndicator = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "Code";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
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
            this.colPickup_Time_Default.MinWidth = 42;
            this.colPickup_Time_Default.Name = "colPickup_Time_Default";
            this.colPickup_Time_Default.Width = 157;
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
            this.colDropoff_LocationType_Default.MinWidth = 42;
            this.colDropoff_LocationType_Default.Name = "colDropoff_LocationType_Default";
            this.colDropoff_LocationType_Default.Width = 182;
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
            this.colDropoff_Location_Default.MinWidth = 42;
            this.colDropoff_Location_Default.Name = "colDropoff_Location_Default";
            this.colDropoff_Location_Default.Width = 317;
            // 
            // repositoryItemCustomSearchLookUpEditDefaultDropLoc
            // 
            this.repositoryItemCustomSearchLookUpEditDefaultDropLoc.AutoHeight = false;
            this.repositoryItemCustomSearchLookUpEditDefaultDropLoc.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.repositoryItemCustomSearchLookUpEditDefaultDropLoc.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCustomSearchLookUpEditDefaultDropLoc.DisplayMember = "DisplayName";
            this.repositoryItemCustomSearchLookUpEditDefaultDropLoc.Name = "repositoryItemCustomSearchLookUpEditDefaultDropLoc";
            this.repositoryItemCustomSearchLookUpEditDefaultDropLoc.PopupView = this.gridView4;
            this.repositoryItemCustomSearchLookUpEditDefaultDropLoc.ValueMember = "Code";
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode6,
            this.gridColumn8});
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            this.gridView4.OptionsView.ShowIndicator = false;
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
            this.colDropoff_Time_Default.MinWidth = 42;
            this.colDropoff_Time_Default.Name = "colDropoff_Time_Default";
            this.colDropoff_Time_Default.Width = 157;
            // 
            // colSupplierProduct_Name
            // 
            this.colSupplierProduct_Name.Caption = "Supplier Name";
            this.colSupplierProduct_Name.FieldName = "Name";
            this.colSupplierProduct_Name.MinWidth = 40;
            this.colSupplierProduct_Name.Name = "colSupplierProduct_Name";
            this.colSupplierProduct_Name.Visible = true;
            this.colSupplierProduct_Name.VisibleIndex = 3;
            this.colSupplierProduct_Name.Width = 927;
            // 
            // LabelControlLon
            // 
            this.LabelControlLon.Location = new System.Drawing.Point(314, 568);
            this.LabelControlLon.Margin = new System.Windows.Forms.Padding(4);
            this.LabelControlLon.Name = "LabelControlLon";
            this.LabelControlLon.Size = new System.Drawing.Size(0, 25);
            this.LabelControlLon.TabIndex = 278;
            // 
            // LabelControlLat
            // 
            this.LabelControlLat.Location = new System.Drawing.Point(314, 539);
            this.LabelControlLat.Margin = new System.Windows.Forms.Padding(4);
            this.LabelControlLat.Name = "LabelControlLat";
            this.LabelControlLat.Size = new System.Drawing.Size(0, 25);
            this.LabelControlLat.TabIndex = 277;
            // 
            // SimpleButtonPlot
            // 
            this.SimpleButtonPlot.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("SimpleButtonPlot.ImageOptions.Image")));
            this.SimpleButtonPlot.Location = new System.Drawing.Point(34, 531);
            this.SimpleButtonPlot.Margin = new System.Windows.Forms.Padding(4);
            this.SimpleButtonPlot.Name = "SimpleButtonPlot";
            this.SimpleButtonPlot.Size = new System.Drawing.Size(132, 73);
            this.SimpleButtonPlot.TabIndex = 276;
            this.SimpleButtonPlot.Text = "Plot";
            this.SimpleButtonPlot.Click += new System.EventHandler(this.SimpleButtonPlot_Click);
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
            this.MapControl.Location = new System.Drawing.Point(716, 129);
            this.MapControl.Margin = new System.Windows.Forms.Padding(4);
            this.MapControl.MaximumSize = new System.Drawing.Size(800, 600);
            this.MapControl.Name = "MapControl";
            this.MapControl.ShowSearchPanel = false;
            this.MapControl.Size = new System.Drawing.Size(790, 600);
            this.MapControl.TabIndex = 271;
            this.MapControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MapControl_MouseDown);
            this.MapControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapControl_MouseMove);
            this.MapControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MapControl_MouseUp);
            this.ImageLayer.DataProvider = this.BingMapDataProvider;
            this.ImageLayer.Name = "ImageLayer";
            this.BingMapDataProvider.BingKey = "ArYMvmMLXeYiBI4-c2wJpjLIpm6FIRez7llCbbZPJDoIBXiO9m8pf5H_oiZPEBrR";
            this.BingMapDataProvider.Kind = DevExpress.XtraMap.BingMapKind.Road;
            this.VectorItemsLayer.Data = this.MapItemStorage;
            this.VectorItemsLayer.Name = "VectorItemsLayer";
            this.InformationLayer.DataProvider = this.BingSearchDataProvider;
            this.InformationLayer.Name = "InformationLayer";
            this.BingSearchDataProvider.BingKey = "ArYMvmMLXeYiBI4-c2wJpjLIpm6FIRez7llCbbZPJDoIBXiO9m8pf5H_oiZPEBrR";
            this.BingSearchDataProvider.GenerateLayerItems = false;
            // 
            // checkEditSearchable
            // 
            this.checkEditSearchable.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Searchable", true));
            this.checkEditSearchable.Location = new System.Drawing.Point(38, 706);
            this.checkEditSearchable.Margin = new System.Windows.Forms.Padding(4);
            this.checkEditSearchable.Name = "checkEditSearchable";
            this.checkEditSearchable.Properties.Caption = "Searchable";
            this.checkEditSearchable.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.checkEditSearchable.Size = new System.Drawing.Size(168, 38);
            this.checkEditSearchable.TabIndex = 32;
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
            this.SpinEditDuration.Location = new System.Drawing.Point(133, 754);
            this.SpinEditDuration.Margin = new System.Windows.Forms.Padding(6);
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
            this.SpinEditDuration.Size = new System.Drawing.Size(200, 40);
            this.SpinEditDuration.TabIndex = 25;
            this.SpinEditDuration.Leave += new System.EventHandler(this.SpinEditDurationEdit_Leave);
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(34, 673);
            this.labelControl14.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(362, 25);
            this.labelControl14.TabIndex = 19;
            this.labelControl14.Text = "Distance to search from this item (km)";
            // 
            // CheckEditProximitySearch
            // 
            this.CheckEditProximitySearch.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "ProximitySearch", true));
            this.CheckEditProximitySearch.Location = new System.Drawing.Point(34, 621);
            this.CheckEditProximitySearch.Margin = new System.Windows.Forms.Padding(4);
            this.CheckEditProximitySearch.Name = "CheckEditProximitySearch";
            this.CheckEditProximitySearch.Properties.Caption = "Enable proximity search for this item on a map";
            this.CheckEditProximitySearch.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditProximitySearch.Size = new System.Drawing.Size(518, 38);
            this.CheckEditProximitySearch.TabIndex = 18;
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
            this.SpinEditDistance.Location = new System.Drawing.Point(418, 670);
            this.SpinEditDistance.Margin = new System.Windows.Forms.Padding(4);
            this.SpinEditDistance.Name = "SpinEditDistance";
            this.SpinEditDistance.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SpinEditDistance.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.SpinEditDistance.Size = new System.Drawing.Size(134, 40);
            this.SpinEditDistance.TabIndex = 20;
            this.SpinEditDistance.Leave += new System.EventHandler(this.SpinEditDistance_Leave);
            // 
            // SearchLookupEditState
            // 
            this.SearchLookupEditState.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "STATE", true));
            this.SearchLookupEditState.Location = new System.Drawing.Point(160, 371);
            this.SearchLookupEditState.Margin = new System.Windows.Forms.Padding(6);
            this.SearchLookupEditState.Name = "SearchLookupEditState";
            this.SearchLookupEditState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLookupEditState.Properties.DataSource = this.BindingSourceCodeName;
            this.SearchLookupEditState.Properties.DisplayMember = "DisplayName";
            this.SearchLookupEditState.Properties.NullText = "";
            this.SearchLookupEditState.Properties.PopupSizeable = false;
            this.SearchLookupEditState.Properties.PopupView = this.customSearchLookUpEdit1View;
            this.SearchLookupEditState.Properties.ValueMember = "Code";
            this.SearchLookupEditState.Size = new System.Drawing.Size(482, 40);
            this.SearchLookupEditState.TabIndex = 12;
            this.SearchLookupEditState.UpdateDisplayFilter += new Custom_SearchLookupEdit.UpdateDisplayFilterHandler(this.SearchLookupEdit_UpdateDisplayFilter);
            this.SearchLookupEditState.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            this.SearchLookupEditState.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.SearchLookupEditState_Closed);
            this.SearchLookupEditState.Leave += new System.EventHandler(this.SearchLookupEditState_Leave);
            // 
            // BindingSourceCodeName
            // 
            this.BindingSourceCodeName.DataSource = typeof(TraceForms.CodeName);
            // 
            // customSearchLookUpEdit1View
            // 
            this.customSearchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode1,
            this.colName1,
            this.colDisplayName2});
            this.customSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.customSearchLookUpEdit1View.Name = "customSearchLookUpEdit1View";
            this.customSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.customSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colCode1
            // 
            this.colCode1.FieldName = "Code";
            this.colCode1.Name = "colCode1";
            this.colCode1.Visible = true;
            this.colCode1.VisibleIndex = 0;
            // 
            // colName1
            // 
            this.colName1.FieldName = "Name";
            this.colName1.Name = "colName1";
            this.colName1.Visible = true;
            this.colName1.VisibleIndex = 1;
            // 
            // colDisplayName2
            // 
            this.colDisplayName2.FieldName = "DisplayName";
            this.colDisplayName2.Name = "colDisplayName2";
            this.colDisplayName2.OptionsColumn.ReadOnly = true;
            // 
            // SearchLookupEditCountry
            // 
            this.SearchLookupEditCountry.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "COUNTRY", true));
            this.SearchLookupEditCountry.Location = new System.Drawing.Point(160, 475);
            this.SearchLookupEditCountry.Margin = new System.Windows.Forms.Padding(6);
            this.SearchLookupEditCountry.Name = "SearchLookupEditCountry";
            this.SearchLookupEditCountry.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLookupEditCountry.Properties.DataSource = this.BindingSourceCodeName;
            this.SearchLookupEditCountry.Properties.DisplayMember = "DisplayName";
            this.SearchLookupEditCountry.Properties.NullText = "";
            this.SearchLookupEditCountry.Properties.PopupSizeable = false;
            this.SearchLookupEditCountry.Properties.PopupView = this.gridView1;
            this.SearchLookupEditCountry.Properties.ValueMember = "Code";
            this.SearchLookupEditCountry.Size = new System.Drawing.Size(482, 40);
            this.SearchLookupEditCountry.TabIndex = 16;
            this.SearchLookupEditCountry.UpdateDisplayFilter += new Custom_SearchLookupEdit.UpdateDisplayFilterHandler(this.SearchLookupEdit_UpdateDisplayFilter);
            this.SearchLookupEditCountry.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            this.SearchLookupEditCountry.Leave += new System.EventHandler(this.SearchLookupEditCountry_Leave);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode2,
            this.colName2,
            this.colDisplayName3});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colCode2
            // 
            this.colCode2.FieldName = "Code";
            this.colCode2.Name = "colCode2";
            this.colCode2.Visible = true;
            this.colCode2.VisibleIndex = 0;
            // 
            // colName2
            // 
            this.colName2.FieldName = "Name";
            this.colName2.Name = "colName2";
            this.colName2.Visible = true;
            this.colName2.VisibleIndex = 1;
            // 
            // colDisplayName3
            // 
            this.colDisplayName3.FieldName = "DisplayName";
            this.colDisplayName3.Name = "colDisplayName3";
            this.colDisplayName3.OptionsColumn.ReadOnly = true;
            // 
            // SearchLookupEditCity
            // 
            this.SearchLookupEditCity.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CITY", true));
            this.SearchLookupEditCity.Location = new System.Drawing.Point(160, 273);
            this.SearchLookupEditCity.Margin = new System.Windows.Forms.Padding(6);
            this.SearchLookupEditCity.Name = "SearchLookupEditCity";
            this.SearchLookupEditCity.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.SearchLookupEditCity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLookupEditCity.Properties.DataSource = this.BindingSourceCodeName;
            this.SearchLookupEditCity.Properties.DisplayMember = "DisplayName";
            this.SearchLookupEditCity.Properties.NullText = "";
            this.SearchLookupEditCity.Properties.PopupSizeable = false;
            this.SearchLookupEditCity.Properties.PopupView = this.gridView2;
            this.SearchLookupEditCity.Properties.ValueMember = "Code";
            this.SearchLookupEditCity.Size = new System.Drawing.Size(482, 40);
            this.SearchLookupEditCity.TabIndex = 23;
            this.SearchLookupEditCity.UpdateDisplayFilter += new Custom_SearchLookupEdit.UpdateDisplayFilterHandler(this.SearchLookupEdit_UpdateDisplayFilter);
            this.SearchLookupEditCity.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            this.SearchLookupEditCity.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.SearchLookupEditCity_Closed);
            this.SearchLookupEditCity.Leave += new System.EventHandler(this.SearchLookupEditCity_Leave);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colName,
            this.colDisplayName1});
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
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // colDisplayName1
            // 
            this.colDisplayName1.FieldName = "DisplayName";
            this.colDisplayName1.Name = "colDisplayName1";
            this.colDisplayName1.OptionsColumn.ReadOnly = true;
            // 
            // PanelControlStatus
            // 
            this.PanelControlStatus.Appearance.Options.UseTextOptions = true;
            this.PanelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("PanelControlStatus.ContentImage")));
            this.PanelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.PanelControlStatus.Controls.Add(this.LabelStatus);
            this.PanelControlStatus.Location = new System.Drawing.Point(616, 4);
            this.PanelControlStatus.Margin = new System.Windows.Forms.Padding(6);
            this.PanelControlStatus.Name = "PanelControlStatus";
            this.PanelControlStatus.Size = new System.Drawing.Size(240, 44);
            this.PanelControlStatus.TabIndex = 265;
            this.PanelControlStatus.Visible = false;
            // 
            // LabelStatus
            // 
            this.LabelStatus.Location = new System.Drawing.Point(60, 10);
            this.LabelStatus.Margin = new System.Windows.Forms.Padding(6);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(0, 25);
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
            this.BarButtonItemSave});
            this.BarManager.MaxItemId = 6;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.FloatLocation = new System.Drawing.Point(688, 138);
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
            this.BarButtonItemNew.Id = 3;
            this.BarButtonItemNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BarButtonItemNew.ImageOptions.Image")));
            this.BarButtonItemNew.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BarButtonItemNew.ImageOptions.LargeImage")));
            this.BarButtonItemNew.Name = "BarButtonItemNew";
            this.BarButtonItemNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemNew_ItemClick);
            // 
            // BarButtonItemDelete
            // 
            this.BarButtonItemDelete.Caption = "Delete";
            this.BarButtonItemDelete.Id = 4;
            this.BarButtonItemDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BarButtonItemDelete.ImageOptions.Image")));
            this.BarButtonItemDelete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BarButtonItemDelete.ImageOptions.LargeImage")));
            this.BarButtonItemDelete.Name = "BarButtonItemDelete";
            this.BarButtonItemDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemDelete_ItemClick);
            // 
            // BarButtonItemSave
            // 
            this.BarButtonItemSave.Caption = "Save";
            this.BarButtonItemSave.Id = 5;
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
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(6);
            this.barDockControlTop.Size = new System.Drawing.Size(1980, 60);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 1316);
            this.barDockControlBottom.Manager = this.BarManager;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(6);
            this.barDockControlBottom.Size = new System.Drawing.Size(1980, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 60);
            this.barDockControlLeft.Manager = this.BarManager;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(6);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 1256);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1980, 60);
            this.barDockControlRight.Manager = this.BarManager;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(6);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 1256);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // GridColumnAddress1
            // 
            this.GridColumnAddress1.FieldName = "ADDRESS1";
            this.GridColumnAddress1.Name = "GridColumnAddress1";
            // 
            // GridColumnAddress2
            // 
            this.GridColumnAddress2.FieldName = "ADDRESS2";
            this.GridColumnAddress2.Name = "GridColumnAddress2";
            // 
            // GridColumnAddress3
            // 
            this.GridColumnAddress3.FieldName = "ADDRESS3";
            this.GridColumnAddress3.Name = "GridColumnAddress3";
            // 
            // GridColumnCity
            // 
            this.GridColumnCity.FieldName = "CITY";
            this.GridColumnCity.Name = "GridColumnCity";
            // 
            // WaypointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1980, 1316);
            this.Controls.Add(this.PanelControlStatus);
            this.Controls.Add(this.SplitContainerControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimizeBox = false;
            this.Name = "WaypointForm";
            this.ShowInTaskbar = false;
            this.Text = "Waypoints";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WAYPOINTForm_FormClosing);
            this.Shown += new System.EventHandler(this.WaypointForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditTown.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditAddress1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditAddress2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditAddress3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditZip.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl)).EndInit();
            this.SplitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridControlSupplierProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceSupplierProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSupplierProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditMax50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCustomSearchLookUpEditDefaultCat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCustomSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxDefaultPupLocType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCustomSearchLookUpEditDefaultPUpLoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEditDefault)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxDefaultDrpLocType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCustomSearchLookUpEditDefaultDropLoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MapControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditSearchable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditDuration.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditProximitySearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinEditDistance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceCodeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditCountry.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditCity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlStatus)).EndInit();
            this.PanelControlStatus.ResumeLayout(false);
            this.PanelControlStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GridControlLookup;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewLookup;
        private System.Windows.Forms.BindingSource BindingSource;
        private DevExpress.XtraEditors.TextEdit TextEditDesc;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit TextEditCode;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit TextEditTown;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit TextEditAddress1;
        private DevExpress.XtraEditors.TextEdit TextEditAddress2;
        private DevExpress.XtraEditors.TextEdit TextEditAddress3;
        private DevExpress.XtraEditors.TextEdit TextEditZip;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private DevExpress.XtraEditors.SplitContainerControl SplitContainerControl;
        private DevExpress.XtraEditors.PanelControl PanelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
		private DevExpress.XtraEditors.LabelControl labelControl14;
		private DevExpress.XtraEditors.CheckEdit CheckEditProximitySearch;
		private DevExpress.XtraEditors.SpinEdit SpinEditDistance;
		private DevExpress.XtraEditors.SpinEdit SpinEditDuration;
        private DevExpress.XtraEditors.CheckEdit checkEditSearchable;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarManager BarManager;
		private DevExpress.XtraBars.Bar bar1;
		private DevExpress.XtraBars.BarButtonItem BarButtonItemNew;
		private DevExpress.XtraBars.BarButtonItem BarButtonItemDelete;
		private DevExpress.XtraBars.BarButtonItem BarButtonItemSave;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
		private DevExpress.XtraBars.Bar bar3;
		private DevExpress.XtraBars.Bar bar2;
		private Custom_SearchLookupEdit.CustomSearchLookUpEdit SearchLookupEditState;
		private DevExpress.XtraGrid.Views.Grid.GridView customSearchLookUpEdit1View;
		private Custom_SearchLookupEdit.CustomSearchLookUpEdit SearchLookupEditCountry;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private Custom_SearchLookupEdit.CustomSearchLookUpEdit SearchLookupEditCity;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraGrid.Columns.GridColumn GridColumnCode;
		private DevExpress.XtraGrid.Columns.GridColumn GridColumnDesc;
		private DevExpress.XtraGrid.Columns.GridColumn GridColumnAddress1;
		private DevExpress.XtraGrid.Columns.GridColumn GridColumnAddress2;
		private DevExpress.XtraGrid.Columns.GridColumn GridColumnAddress3;
		private DevExpress.XtraGrid.Columns.GridColumn GridColumnCity;
		private DevExpress.XtraMap.MapControl MapControl;
		private DevExpress.XtraMap.ImageLayer ImageLayer;
		private DevExpress.XtraMap.BingMapDataProvider BingMapDataProvider;
		private DevExpress.XtraMap.VectorItemsLayer VectorItemsLayer;
		private DevExpress.XtraMap.MapItemStorage MapItemStorage;
		private DevExpress.XtraMap.InformationLayer InformationLayer;
		private DevExpress.XtraMap.BingSearchDataProvider BingSearchDataProvider;
		private DevExpress.XtraEditors.LabelControl LabelControlLon;
		private DevExpress.XtraEditors.LabelControl LabelControlLat;
		private DevExpress.XtraEditors.SimpleButton SimpleButtonPlot;
		private System.Windows.Forms.BindingSource BindingSourceCodeName;
		private DevExpress.XtraGrid.Columns.GridColumn colCode1;
		private DevExpress.XtraGrid.Columns.GridColumn colName1;
		private DevExpress.XtraGrid.Columns.GridColumn colDisplayName2;
		private DevExpress.XtraGrid.Columns.GridColumn colCode2;
		private DevExpress.XtraGrid.Columns.GridColumn colName2;
		private DevExpress.XtraGrid.Columns.GridColumn colDisplayName3;
		private DevExpress.XtraGrid.Columns.GridColumn colCode;
		private DevExpress.XtraGrid.Columns.GridColumn colName;
		private DevExpress.XtraGrid.Columns.GridColumn colDisplayName1;
        private DevExpress.Data.Linq.EntityInstantFeedbackSource EntityInstantFeedbackSource;
        private System.Windows.Forms.BindingSource BindingSourceSupplierProduct;
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
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn colPickup_Time_Default;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repositoryItemTimeEditDefault;
        private DevExpress.XtraGrid.Columns.GridColumn colDropoff_LocationType_Default;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxDefaultDrpLocType;
        private DevExpress.XtraGrid.Columns.GridColumn colDropoff_Location_Default;
        private Custom_SearchLookupEdit.RepositoryItemCustomSearchLookUpEdit repositoryItemCustomSearchLookUpEditDefaultDropLoc;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn colCode6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn colDropoff_Time_Default;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplierProduct_Name;
        private DevExpress.XtraEditors.SimpleButton ButtonDeleteMapping;
        private DevExpress.XtraEditors.SimpleButton ButtonAddMapping;
    }
}