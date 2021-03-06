﻿namespace TraceForms
{
    partial class CityCodeForm
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
            System.Windows.Forms.Label LabelName;
            System.Windows.Forms.Label LabelLinkCode;
            System.Windows.Forms.Label LabelLong;
            System.Windows.Forms.Label LabelLat;
            System.Windows.Forms.Label LabelState;
            System.Windows.Forms.Label LabelCountry;
            System.Windows.Forms.Label LabelMappings;
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CityCodeForm));
            this.BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TextEditName = new DevExpress.XtraEditors.TextEdit();
            this.TextEditCode = new DevExpress.XtraEditors.TextEdit();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.SplitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.GridControlLookup = new DevExpress.XtraGrid.GridControl();
            this.EntityInstantFeedbackSource = new DevExpress.Data.Linq.EntityInstantFeedbackSource();
            this.GridViewLookup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnLookupCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLookupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLookupLinkCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLookupState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLookupRegion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLookupCountry = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.PanelControlMappings = new DevExpress.XtraEditors.PanelControl();
            this.GridControlSupplierCity = new DevExpress.XtraGrid.GridControl();
            this.BindingSourceSupplierCity = new System.Windows.Forms.BindingSource(this.components);
            this.GridViewSupplierCity = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnSupplierCityId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSupplierGuid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCityCodeSupplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemTextEdit12 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumnCityNameSupplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemTextEdit50 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumnCitycodCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnInactive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnOperator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemSearchLookUpEditOperator = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.BindingSourceCodeName = new System.Windows.Forms.BindingSource(this.components);
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemCustomSearchLookUpEditOperator = new Custom_SearchLookupEdit.RepositoryItemCustomSearchLookUpEdit();
            this.repositoryItemCustomSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ButtonDeleteMapping = new DevExpress.XtraEditors.SimpleButton();
            this.ButtonAddMapping = new DevExpress.XtraEditors.SimpleButton();
            this.SearchLookupEditLinkCode = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SearchLookupEditState = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SearchLookupEditRegion = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SearchLookupEditCountry = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PanelControlStatus = new DevExpress.XtraEditors.PanelControl();
            this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
            this.BarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.BarTools = new DevExpress.XtraBars.Bar();
            this.BarButtonItemNew = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItemDelete = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bingMapDataProvider2 = new DevExpress.XtraMap.BingMapDataProvider();
            this.bingMapDataProvider3 = new DevExpress.XtraMap.BingMapDataProvider();
            LabelCode = new System.Windows.Forms.Label();
            LabelName = new System.Windows.Forms.Label();
            LabelLinkCode = new System.Windows.Forms.Label();
            LabelLong = new System.Windows.Forms.Label();
            LabelLat = new System.Windows.Forms.Label();
            LabelState = new System.Windows.Forms.Label();
            LabelCountry = new System.Windows.Forms.Label();
            LabelMappings = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl)).BeginInit();
            this.SplitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MapControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlMappings)).BeginInit();
            this.PanelControlMappings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlSupplierCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceSupplierCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSupplierCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEdit12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEdit50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemSearchLookUpEditOperator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceCodeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCustomSearchLookUpEditOperator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCustomSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditLinkCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditRegion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditCountry.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlStatus)).BeginInit();
            this.PanelControlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelCode
            // 
            LabelCode.AutoSize = true;
            LabelCode.Location = new System.Drawing.Point(32, 33);
            LabelCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelCode.Name = "LabelCode";
            LabelCode.Size = new System.Drawing.Size(54, 13);
            LabelCode.TabIndex = 12;
            LabelCode.Text = "City Code";
            // 
            // LabelName
            // 
            LabelName.AutoSize = true;
            LabelName.Location = new System.Drawing.Point(32, 60);
            LabelName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelName.Name = "LabelName";
            LabelName.Size = new System.Drawing.Size(34, 13);
            LabelName.TabIndex = 16;
            LabelName.Text = "Name";
            // 
            // LabelLinkCode
            // 
            LabelLinkCode.AutoSize = true;
            LabelLinkCode.Location = new System.Drawing.Point(32, 83);
            LabelLinkCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelLinkCode.Name = "LabelLinkCode";
            LabelLinkCode.Size = new System.Drawing.Size(62, 13);
            LabelLinkCode.TabIndex = 14;
            LabelLinkCode.Text = "Search City";
            // 
            // LabelLong
            // 
            LabelLong.AutoSize = true;
            LabelLong.Location = new System.Drawing.Point(104, 197);
            LabelLong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelLong.Name = "LabelLong";
            LabelLong.Size = new System.Drawing.Size(58, 13);
            LabelLong.TabIndex = 18;
            LabelLong.Text = "Longitude:";
            // 
            // LabelLat
            // 
            LabelLat.AutoSize = true;
            LabelLat.Location = new System.Drawing.Point(104, 184);
            LabelLat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelLat.Name = "LabelLat";
            LabelLat.Size = new System.Drawing.Size(50, 13);
            LabelLat.TabIndex = 19;
            LabelLat.Text = "Latitude:";
            // 
            // LabelState
            // 
            LabelState.AutoSize = true;
            LabelState.Location = new System.Drawing.Point(32, 107);
            LabelState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelState.Name = "LabelState";
            LabelState.Size = new System.Drawing.Size(33, 13);
            LabelState.TabIndex = 22;
            LabelState.Text = "State";
            // 
            // LabelCountry
            // 
            LabelCountry.AutoSize = true;
            LabelCountry.Location = new System.Drawing.Point(32, 154);
            LabelCountry.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelCountry.Name = "LabelCountry";
            LabelCountry.Size = new System.Drawing.Size(46, 13);
            LabelCountry.TabIndex = 24;
            LabelCountry.Text = "Country";
            // 
            // LabelMappings
            // 
            LabelMappings.AutoSize = true;
            LabelMappings.Location = new System.Drawing.Point(20, 11);
            LabelMappings.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelMappings.Name = "LabelMappings";
            LabelMappings.Size = new System.Drawing.Size(97, 13);
            LabelMappings.TabIndex = 85;
            LabelMappings.Text = "Supplier Mappings:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(32, 131);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(40, 13);
            label1.TabIndex = 275;
            label1.Text = "Region";
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(FlexModel.CITYCOD);
            this.BindingSource.CurrentChanged += new System.EventHandler(this.BindingSource_CurrentChanged);
            // 
            // TextEditName
            // 
            this.TextEditName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "NAME", true));
            this.TextEditName.EnterMoveNextControl = true;
            this.TextEditName.Location = new System.Drawing.Point(100, 57);
            this.TextEditName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TextEditName.Name = "TextEditName";
            this.TextEditName.Properties.MaxLength = 20;
            this.TextEditName.Size = new System.Drawing.Size(202, 20);
            this.TextEditName.TabIndex = 2;
            this.TextEditName.Leave += new System.EventHandler(this.TextEditName_Leave);
            // 
            // TextEditCode
            // 
            this.TextEditCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CODE", true));
            this.TextEditCode.EnterMoveNextControl = true;
            this.TextEditCode.Location = new System.Drawing.Point(100, 31);
            this.TextEditCode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TextEditCode.Name = "TextEditCode";
            this.TextEditCode.Properties.MaxLength = 12;
            this.TextEditCode.Size = new System.Drawing.Size(100, 20);
            this.TextEditCode.TabIndex = 1;
            this.TextEditCode.Leave += new System.EventHandler(this.TextEditCode_Leave);
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
            this.SplitContainerControl.Panel2.Controls.Add(label1);
            this.SplitContainerControl.Panel2.Controls.Add(this.LabelControlLon);
            this.SplitContainerControl.Panel2.Controls.Add(this.LabelControlLat);
            this.SplitContainerControl.Panel2.Controls.Add(this.SimpleButtonPlot);
            this.SplitContainerControl.Panel2.Controls.Add(this.MapControl);
            this.SplitContainerControl.Panel2.Controls.Add(this.PanelControlMappings);
            this.SplitContainerControl.Panel2.Controls.Add(LabelCountry);
            this.SplitContainerControl.Panel2.Controls.Add(LabelState);
            this.SplitContainerControl.Panel2.Controls.Add(LabelLat);
            this.SplitContainerControl.Panel2.Controls.Add(LabelLong);
            this.SplitContainerControl.Panel2.Controls.Add(this.TextEditName);
            this.SplitContainerControl.Panel2.Controls.Add(LabelCode);
            this.SplitContainerControl.Panel2.Controls.Add(LabelLinkCode);
            this.SplitContainerControl.Panel2.Controls.Add(this.TextEditCode);
            this.SplitContainerControl.Panel2.Controls.Add(LabelName);
            this.SplitContainerControl.Panel2.Controls.Add(this.SearchLookupEditLinkCode);
            this.SplitContainerControl.Panel2.Controls.Add(this.SearchLookupEditState);
            this.SplitContainerControl.Panel2.Controls.Add(this.SearchLookupEditRegion);
            this.SplitContainerControl.Panel2.Controls.Add(this.SearchLookupEditCountry);
            this.SplitContainerControl.Panel2.Text = "Panel2";
            this.SplitContainerControl.Size = new System.Drawing.Size(1224, 547);
            this.SplitContainerControl.SplitterPosition = 268;
            this.SplitContainerControl.TabIndex = 21;
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
            this.GridControlLookup.Size = new System.Drawing.Size(268, 547);
            this.GridControlLookup.TabIndex = 0;
            this.GridControlLookup.TabStop = false;
            this.GridControlLookup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewLookup});
            // 
            // EntityInstantFeedbackSource
            // 
            this.EntityInstantFeedbackSource.DesignTimeElementType = typeof(FlexModel.CITYCOD);
            this.EntityInstantFeedbackSource.KeyExpression = "CODE";
            this.EntityInstantFeedbackSource.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.EntityInstantFeedbackSource_GetQueryable);
            this.EntityInstantFeedbackSource.DismissQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.EntityInstantFeedbackSource_DismissQueryable);
            // 
            // GridViewLookup
            // 
            this.GridViewLookup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnLookupCode,
            this.gridColumnLookupName,
            this.gridColumnLookupLinkCode,
            this.gridColumnLookupState,
            this.gridColumnLookupRegion,
            this.gridColumnLookupCountry});
            this.GridViewLookup.DetailHeight = 198;
            this.GridViewLookup.GridControl = this.GridControlLookup;
            this.GridViewLookup.LevelIndent = 0;
            this.GridViewLookup.Name = "GridViewLookup";
            this.GridViewLookup.OptionsBehavior.Editable = false;
            this.GridViewLookup.OptionsCustomization.AllowQuickHideColumns = false;
            this.GridViewLookup.OptionsView.ShowAutoFilterRow = true;
            this.GridViewLookup.OptionsView.ShowGroupPanel = false;
            this.GridViewLookup.OptionsView.ShowIndicator = false;
            this.GridViewLookup.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel;
            this.GridViewLookup.PreviewIndent = 0;
            this.GridViewLookup.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewLookup_FocusedRowChanged);
            this.GridViewLookup.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.GridViewLookup_InvalidRowException);
            this.GridViewLookup.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.GridViewLookup_BeforeLeaveRow);
            this.GridViewLookup.ColumnFilterChanged += new System.EventHandler(this.GridViewLookup_ColumnFilterChanged);
            // 
            // gridColumnLookupCode
            // 
            this.gridColumnLookupCode.Caption = "Code";
            this.gridColumnLookupCode.FieldName = "CODE";
            this.gridColumnLookupCode.MinWidth = 12;
            this.gridColumnLookupCode.Name = "gridColumnLookupCode";
            this.gridColumnLookupCode.Visible = true;
            this.gridColumnLookupCode.VisibleIndex = 0;
            this.gridColumnLookupCode.Width = 44;
            // 
            // gridColumnLookupName
            // 
            this.gridColumnLookupName.Caption = "Name";
            this.gridColumnLookupName.FieldName = "NAME";
            this.gridColumnLookupName.MinWidth = 12;
            this.gridColumnLookupName.Name = "gridColumnLookupName";
            this.gridColumnLookupName.Visible = true;
            this.gridColumnLookupName.VisibleIndex = 1;
            this.gridColumnLookupName.Width = 44;
            // 
            // gridColumnLookupLinkCode
            // 
            this.gridColumnLookupLinkCode.Caption = "Search City";
            this.gridColumnLookupLinkCode.FieldName = "LINKCODE";
            this.gridColumnLookupLinkCode.MinWidth = 12;
            this.gridColumnLookupLinkCode.Name = "gridColumnLookupLinkCode";
            this.gridColumnLookupLinkCode.Visible = true;
            this.gridColumnLookupLinkCode.VisibleIndex = 2;
            this.gridColumnLookupLinkCode.Width = 44;
            // 
            // gridColumnLookupState
            // 
            this.gridColumnLookupState.Caption = "State";
            this.gridColumnLookupState.FieldName = "State.State_Code";
            this.gridColumnLookupState.MinWidth = 12;
            this.gridColumnLookupState.Name = "gridColumnLookupState";
            this.gridColumnLookupState.Width = 44;
            // 
            // gridColumnLookupRegion
            // 
            this.gridColumnLookupRegion.Caption = "Region";
            this.gridColumnLookupRegion.FieldName = "Region_Code";
            this.gridColumnLookupRegion.MinWidth = 12;
            this.gridColumnLookupRegion.Name = "gridColumnLookupRegion";
            this.gridColumnLookupRegion.Width = 44;
            // 
            // gridColumnLookupCountry
            // 
            this.gridColumnLookupCountry.Caption = "Country";
            this.gridColumnLookupCountry.FieldName = "Country_Code";
            this.gridColumnLookupCountry.MinWidth = 12;
            this.gridColumnLookupCountry.Name = "gridColumnLookupCountry";
            this.gridColumnLookupCountry.Width = 44;
            // 
            // LabelControlLon
            // 
            this.LabelControlLon.Location = new System.Drawing.Point(170, 198);
            this.LabelControlLon.Margin = new System.Windows.Forms.Padding(2);
            this.LabelControlLon.Name = "LabelControlLon";
            this.LabelControlLon.Size = new System.Drawing.Size(0, 13);
            this.LabelControlLon.TabIndex = 273;
            // 
            // LabelControlLat
            // 
            this.LabelControlLat.Location = new System.Drawing.Point(170, 184);
            this.LabelControlLat.Margin = new System.Windows.Forms.Padding(2);
            this.LabelControlLat.Name = "LabelControlLat";
            this.LabelControlLat.Size = new System.Drawing.Size(0, 13);
            this.LabelControlLat.TabIndex = 272;
            // 
            // SimpleButtonPlot
            // 
            this.SimpleButtonPlot.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("SimpleButtonPlot.ImageOptions.Image")));
            this.SimpleButtonPlot.Location = new System.Drawing.Point(34, 184);
            this.SimpleButtonPlot.Margin = new System.Windows.Forms.Padding(2);
            this.SimpleButtonPlot.Name = "SimpleButtonPlot";
            this.SimpleButtonPlot.Size = new System.Drawing.Size(66, 24);
            this.SimpleButtonPlot.TabIndex = 271;
            this.SimpleButtonPlot.Text = "Plot";
            this.SimpleButtonPlot.Click += new System.EventHandler(this.SimpleButtonPlot_Click);
            // 
            // MapControl
            // 
            this.MapControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MapControl.EnableAnimation = false;
            this.MapControl.Layers.Add(this.ImageLayer);
            this.MapControl.Layers.Add(this.VectorItemsLayer);
            this.MapControl.Layers.Add(this.InformationLayer);
            this.MapControl.Location = new System.Drawing.Point(348, 22);
            this.MapControl.Margin = new System.Windows.Forms.Padding(2);
            this.MapControl.Name = "MapControl";
            this.MapControl.ShowSearchPanel = false;
            this.MapControl.Size = new System.Drawing.Size(570, 192);
            this.MapControl.TabIndex = 270;
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
            // PanelControlMappings
            // 
            this.PanelControlMappings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelControlMappings.Controls.Add(LabelMappings);
            this.PanelControlMappings.Controls.Add(this.GridControlSupplierCity);
            this.PanelControlMappings.Controls.Add(this.ButtonDeleteMapping);
            this.PanelControlMappings.Controls.Add(this.ButtonAddMapping);
            this.PanelControlMappings.Location = new System.Drawing.Point(34, 232);
            this.PanelControlMappings.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.PanelControlMappings.Name = "PanelControlMappings";
            this.PanelControlMappings.Size = new System.Drawing.Size(885, 266);
            this.PanelControlMappings.TabIndex = 35;
            // 
            // GridControlSupplierCity
            // 
            this.GridControlSupplierCity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridControlSupplierCity.DataSource = this.BindingSourceSupplierCity;
            this.GridControlSupplierCity.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GridControlSupplierCity.Location = new System.Drawing.Point(22, 35);
            this.GridControlSupplierCity.MainView = this.GridViewSupplierCity;
            this.GridControlSupplierCity.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GridControlSupplierCity.Name = "GridControlSupplierCity";
            this.GridControlSupplierCity.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RepositoryItemTextEdit12,
            this.RepositoryItemTextEdit50,
            this.RepositoryItemCustomSearchLookUpEditOperator,
            this.RepositoryItemSearchLookUpEditOperator});
            this.GridControlSupplierCity.Size = new System.Drawing.Size(798, 213);
            this.GridControlSupplierCity.TabIndex = 84;
            this.GridControlSupplierCity.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewSupplierCity});
            this.GridControlSupplierCity.Leave += new System.EventHandler(this.GridControlSupplierCity_Leave);
            // 
            // BindingSourceSupplierCity
            // 
            this.BindingSourceSupplierCity.DataSource = typeof(FlexModel.SupplierCity);
            // 
            // GridViewSupplierCity
            // 
            this.GridViewSupplierCity.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnSupplierCityId,
            this.gridColumnSupplierGuid,
            this.gridColumnCityCodeSupplier,
            this.gridColumnCityNameSupplier,
            this.gridColumnCitycodCode,
            this.gridColumnInactive,
            this.gridColumnOperator});
            this.GridViewSupplierCity.DetailHeight = 198;
            this.GridViewSupplierCity.GridControl = this.GridControlSupplierCity;
            this.GridViewSupplierCity.LevelIndent = 0;
            this.GridViewSupplierCity.Name = "GridViewSupplierCity";
            this.GridViewSupplierCity.OptionsView.ShowGroupPanel = false;
            this.GridViewSupplierCity.PreviewIndent = 0;
            this.GridViewSupplierCity.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.GridViewSupplierCity_CustomRowCellEdit);
            // 
            // gridColumnSupplierCityId
            // 
            this.gridColumnSupplierCityId.FieldName = "ID";
            this.gridColumnSupplierCityId.MinWidth = 12;
            this.gridColumnSupplierCityId.Name = "gridColumnSupplierCityId";
            this.gridColumnSupplierCityId.Width = 44;
            // 
            // gridColumnSupplierGuid
            // 
            this.gridColumnSupplierGuid.Caption = "Supplier";
            this.gridColumnSupplierGuid.FieldName = "Supplier_GUID";
            this.gridColumnSupplierGuid.MinWidth = 12;
            this.gridColumnSupplierGuid.Name = "gridColumnSupplierGuid";
            this.gridColumnSupplierGuid.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumnSupplierGuid.Visible = true;
            this.gridColumnSupplierGuid.VisibleIndex = 0;
            this.gridColumnSupplierGuid.Width = 44;
            // 
            // gridColumnCityCodeSupplier
            // 
            this.gridColumnCityCodeSupplier.Caption = "Supplier City Id";
            this.gridColumnCityCodeSupplier.ColumnEdit = this.RepositoryItemTextEdit12;
            this.gridColumnCityCodeSupplier.FieldName = "CityCodeSupplier";
            this.gridColumnCityCodeSupplier.MinWidth = 12;
            this.gridColumnCityCodeSupplier.Name = "gridColumnCityCodeSupplier";
            this.gridColumnCityCodeSupplier.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumnCityCodeSupplier.Visible = true;
            this.gridColumnCityCodeSupplier.VisibleIndex = 1;
            this.gridColumnCityCodeSupplier.Width = 44;
            // 
            // RepositoryItemTextEdit12
            // 
            this.RepositoryItemTextEdit12.AutoHeight = false;
            this.RepositoryItemTextEdit12.MaxLength = 12;
            this.RepositoryItemTextEdit12.Name = "RepositoryItemTextEdit12";
            // 
            // gridColumnCityNameSupplier
            // 
            this.gridColumnCityNameSupplier.Caption = "Supplier City Name";
            this.gridColumnCityNameSupplier.ColumnEdit = this.RepositoryItemTextEdit50;
            this.gridColumnCityNameSupplier.FieldName = "CityNameSupplier";
            this.gridColumnCityNameSupplier.MinWidth = 12;
            this.gridColumnCityNameSupplier.Name = "gridColumnCityNameSupplier";
            this.gridColumnCityNameSupplier.Visible = true;
            this.gridColumnCityNameSupplier.VisibleIndex = 2;
            this.gridColumnCityNameSupplier.Width = 44;
            // 
            // RepositoryItemTextEdit50
            // 
            this.RepositoryItemTextEdit50.AutoHeight = false;
            this.RepositoryItemTextEdit50.MaxLength = 50;
            this.RepositoryItemTextEdit50.Name = "RepositoryItemTextEdit50";
            // 
            // gridColumnCitycodCode
            // 
            this.gridColumnCitycodCode.Caption = "gridColumn1";
            this.gridColumnCitycodCode.FieldName = "Citycod_Code";
            this.gridColumnCitycodCode.MinWidth = 12;
            this.gridColumnCitycodCode.Name = "gridColumnCitycodCode";
            this.gridColumnCitycodCode.Width = 44;
            // 
            // gridColumnInactive
            // 
            this.gridColumnInactive.Caption = "Inactive";
            this.gridColumnInactive.FieldName = "Inactive";
            this.gridColumnInactive.MinWidth = 12;
            this.gridColumnInactive.Name = "gridColumnInactive";
            this.gridColumnInactive.Visible = true;
            this.gridColumnInactive.VisibleIndex = 3;
            this.gridColumnInactive.Width = 44;
            // 
            // gridColumnOperator
            // 
            this.gridColumnOperator.Caption = "Operator";
            this.gridColumnOperator.ColumnEdit = this.RepositoryItemSearchLookUpEditOperator;
            this.gridColumnOperator.FieldName = "Operator_Code";
            this.gridColumnOperator.MinWidth = 12;
            this.gridColumnOperator.Name = "gridColumnOperator";
            this.gridColumnOperator.Visible = true;
            this.gridColumnOperator.VisibleIndex = 4;
            this.gridColumnOperator.Width = 44;
            // 
            // RepositoryItemSearchLookUpEditOperator
            // 
            this.RepositoryItemSearchLookUpEditOperator.AutoHeight = false;
            this.RepositoryItemSearchLookUpEditOperator.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemSearchLookUpEditOperator.DataSource = this.BindingSourceCodeName;
            this.RepositoryItemSearchLookUpEditOperator.DisplayMember = "DisplayName";
            this.RepositoryItemSearchLookUpEditOperator.Name = "RepositoryItemSearchLookUpEditOperator";
            this.RepositoryItemSearchLookUpEditOperator.PopupView = this.repositoryItemSearchLookUpEdit1View;
            this.RepositoryItemSearchLookUpEditOperator.ValueMember = "Code";
            // 
            // BindingSourceCodeName
            // 
            this.BindingSourceCodeName.DataSource = typeof(TraceForms.CodeName);
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colName});
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowIndicator = false;
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
            // RepositoryItemCustomSearchLookUpEditOperator
            // 
            this.RepositoryItemCustomSearchLookUpEditOperator.AutoHeight = false;
            this.RepositoryItemCustomSearchLookUpEditOperator.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.RepositoryItemCustomSearchLookUpEditOperator.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryItemCustomSearchLookUpEditOperator.DataSource = this.BindingSourceCodeName;
            this.RepositoryItemCustomSearchLookUpEditOperator.DisplayMember = "DisplayName";
            this.RepositoryItemCustomSearchLookUpEditOperator.Name = "RepositoryItemCustomSearchLookUpEditOperator";
            this.RepositoryItemCustomSearchLookUpEditOperator.NullText = "";
            this.RepositoryItemCustomSearchLookUpEditOperator.PopupView = this.repositoryItemCustomSearchLookUpEdit1View;
            this.RepositoryItemCustomSearchLookUpEditOperator.ValueMember = "Code";
            this.RepositoryItemCustomSearchLookUpEditOperator.UpdateDisplayFilter += new Custom_SearchLookupEdit.UpdateDisplayFilterHandler(this.SearchLookupEdit_UpdateDisplayFilter);
            this.RepositoryItemCustomSearchLookUpEditOperator.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            // 
            // repositoryItemCustomSearchLookUpEdit1View
            // 
            this.repositoryItemCustomSearchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode1,
            this.colName1});
            this.repositoryItemCustomSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemCustomSearchLookUpEdit1View.Name = "repositoryItemCustomSearchLookUpEdit1View";
            this.repositoryItemCustomSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemCustomSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.repositoryItemCustomSearchLookUpEdit1View.OptionsView.ShowIndicator = false;
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
            // ButtonDeleteMapping
            // 
            this.ButtonDeleteMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonDeleteMapping.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonDeleteMapping.ImageOptions.Image")));
            this.ButtonDeleteMapping.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ButtonDeleteMapping.Location = new System.Drawing.Point(833, 84);
            this.ButtonDeleteMapping.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ButtonDeleteMapping.Name = "ButtonDeleteMapping";
            this.ButtonDeleteMapping.Size = new System.Drawing.Size(40, 36);
            this.ButtonDeleteMapping.TabIndex = 39;
            this.ButtonDeleteMapping.TabStop = false;
            this.ButtonDeleteMapping.Click += new System.EventHandler(this.ButtonDeleteMapping_Click);
            // 
            // ButtonAddMapping
            // 
            this.ButtonAddMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonAddMapping.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonAddMapping.ImageOptions.Image")));
            this.ButtonAddMapping.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ButtonAddMapping.Location = new System.Drawing.Point(833, 43);
            this.ButtonAddMapping.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ButtonAddMapping.Name = "ButtonAddMapping";
            this.ButtonAddMapping.Size = new System.Drawing.Size(40, 36);
            this.ButtonAddMapping.TabIndex = 34;
            this.ButtonAddMapping.Click += new System.EventHandler(this.ButtonAddMapping_Click);
            // 
            // SearchLookupEditLinkCode
            // 
            this.SearchLookupEditLinkCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "LINKCODE", true));
            this.SearchLookupEditLinkCode.Location = new System.Drawing.Point(100, 81);
            this.SearchLookupEditLinkCode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SearchLookupEditLinkCode.Name = "SearchLookupEditLinkCode";
            this.SearchLookupEditLinkCode.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.SearchLookupEditLinkCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLookupEditLinkCode.Properties.DataSource = this.BindingSourceCodeName;
            this.SearchLookupEditLinkCode.Properties.DisplayMember = "DisplayName";
            this.SearchLookupEditLinkCode.Properties.NullText = "";
            this.SearchLookupEditLinkCode.Properties.PopupView = this.searchLookUpEdit1View;
            this.SearchLookupEditLinkCode.Properties.ValueMember = "Code";
            this.SearchLookupEditLinkCode.Size = new System.Drawing.Size(202, 20);
            this.SearchLookupEditLinkCode.TabIndex = 3;
            this.SearchLookupEditLinkCode.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            this.SearchLookupEditLinkCode.Leave += new System.EventHandler(this.TextEditLinkCode_Leave);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.searchLookUpEdit1View.OptionsView.ShowIndicator = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.FieldName = "Code";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 227;
            // 
            // gridColumn4
            // 
            this.gridColumn4.FieldName = "Name";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 945;
            // 
            // gridColumn5
            // 
            this.gridColumn5.FieldName = "DisplayName";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            // 
            // SearchLookupEditState
            // 
            this.SearchLookupEditState.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "State_Code", true));
            this.SearchLookupEditState.Location = new System.Drawing.Point(100, 105);
            this.SearchLookupEditState.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SearchLookupEditState.Name = "SearchLookupEditState";
            this.SearchLookupEditState.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.SearchLookupEditState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLookupEditState.Properties.DataSource = this.BindingSourceCodeName;
            this.SearchLookupEditState.Properties.DisplayMember = "DisplayName";
            this.SearchLookupEditState.Properties.NullText = "";
            this.SearchLookupEditState.Properties.PopupView = this.gridView3;
            this.SearchLookupEditState.Properties.ValueMember = "Code";
            this.SearchLookupEditState.Size = new System.Drawing.Size(202, 20);
            this.SearchLookupEditState.TabIndex = 21;
            this.SearchLookupEditState.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            this.SearchLookupEditState.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.SearchLookupEditState_Closed);
            this.SearchLookupEditState.Leave += new System.EventHandler(this.SearchLookupEditState_Leave);
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn7});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView3.OptionsView.ShowIndicator = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.FieldName = "Code";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            // 
            // gridColumn7
            // 
            this.gridColumn7.FieldName = "Name";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            // 
            // SearchLookupEditRegion
            // 
            this.SearchLookupEditRegion.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Region_Code", true));
            this.SearchLookupEditRegion.Location = new System.Drawing.Point(100, 128);
            this.SearchLookupEditRegion.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SearchLookupEditRegion.Name = "SearchLookupEditRegion";
            this.SearchLookupEditRegion.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.SearchLookupEditRegion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLookupEditRegion.Properties.DataSource = this.BindingSourceCodeName;
            this.SearchLookupEditRegion.Properties.DisplayMember = "DisplayName";
            this.SearchLookupEditRegion.Properties.NullText = "";
            this.SearchLookupEditRegion.Properties.PopupView = this.gridView4;
            this.SearchLookupEditRegion.Properties.ValueMember = "Code";
            this.SearchLookupEditRegion.Size = new System.Drawing.Size(202, 20);
            this.SearchLookupEditRegion.TabIndex = 274;
            this.SearchLookupEditRegion.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            this.SearchLookupEditRegion.Leave += new System.EventHandler(this.SearchLookUpEditRegion_Leave);
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8,
            this.gridColumn9});
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            this.gridView4.OptionsView.ShowIndicator = false;
            // 
            // gridColumn8
            // 
            this.gridColumn8.FieldName = "Code";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            // 
            // gridColumn9
            // 
            this.gridColumn9.FieldName = "Name";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            // 
            // SearchLookupEditCountry
            // 
            this.SearchLookupEditCountry.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Country_Code", true));
            this.SearchLookupEditCountry.Location = new System.Drawing.Point(100, 152);
            this.SearchLookupEditCountry.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SearchLookupEditCountry.Name = "SearchLookupEditCountry";
            this.SearchLookupEditCountry.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.SearchLookupEditCountry.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLookupEditCountry.Properties.DataSource = this.BindingSourceCodeName;
            this.SearchLookupEditCountry.Properties.DisplayMember = "DisplayName";
            this.SearchLookupEditCountry.Properties.NullText = "";
            this.SearchLookupEditCountry.Properties.PopupView = this.gridView2;
            this.SearchLookupEditCountry.Properties.ValueMember = "Code";
            this.SearchLookupEditCountry.Size = new System.Drawing.Size(202, 20);
            this.SearchLookupEditCountry.TabIndex = 23;
            this.SearchLookupEditCountry.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            this.SearchLookupEditCountry.Leave += new System.EventHandler(this.SearchLookupEditCountry_Leave);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "Code";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // PanelControlStatus
            // 
            this.PanelControlStatus.Appearance.Options.UseTextOptions = true;
            this.PanelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("PanelControlStatus.ContentImage")));
            this.PanelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.PanelControlStatus.Controls.Add(this.LabelStatus);
            this.PanelControlStatus.Location = new System.Drawing.Point(452, 2);
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
            this.BarTools});
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
            // BarTools
            // 
            this.BarTools.BarName = "Tools";
            this.BarTools.DockCol = 0;
            this.BarTools.DockRow = 0;
            this.BarTools.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.BarTools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonItemNew),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonItemDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonItemSave)});
            this.BarTools.OptionsBar.AllowQuickCustomization = false;
            this.BarTools.OptionsBar.DrawDragBorder = false;
            this.BarTools.OptionsBar.UseWholeRow = true;
            this.BarTools.Text = "Tools";
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
            this.BarButtonItemDelete.Enabled = false;
            this.BarButtonItemDelete.Id = 1;
            this.BarButtonItemDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BarButtonItemDelete.ImageOptions.Image")));
            this.BarButtonItemDelete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BarButtonItemDelete.ImageOptions.LargeImage")));
            this.BarButtonItemDelete.Name = "BarButtonItemDelete";
            this.BarButtonItemDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemDelete_ItemClick);
            // 
            // BarButtonItemSave
            // 
            this.BarButtonItemSave.Caption = "Save";
            this.BarButtonItemSave.Enabled = false;
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
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlTop.Size = new System.Drawing.Size(1224, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 578);
            this.barDockControlBottom.Manager = this.BarManager;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlBottom.Size = new System.Drawing.Size(1224, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Manager = this.BarManager;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 547);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1224, 31);
            this.barDockControlRight.Manager = this.BarManager;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 547);
            this.bingMapDataProvider2.BingKey = "ArYMvmMLXeYiBI4-c2wJpjLIpm6FIRez7llCbbZPJDoIBXiO9m8pf5H_oiZPEBrR";
            this.bingMapDataProvider3.BingKey = "ArYMvmMLXeYiBI4-c2wJpjLIpm6FIRez7llCbbZPJDoIBXiO9m8pf5H_oiZPEBrR";
            // 
            // CityCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 578);
            this.Controls.Add(this.PanelControlStatus);
            this.Controls.Add(this.SplitContainerControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MinimizeBox = false;
            this.Name = "CityCodeForm";
            this.ShowInTaskbar = false;
            this.Text = "City Codes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CityCodeForm_FormClosing);
            this.Shown += new System.EventHandler(this.CityCodeForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl)).EndInit();
            this.SplitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridControlLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MapControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlMappings)).EndInit();
            this.PanelControlMappings.ResumeLayout(false);
            this.PanelControlMappings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlSupplierCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceSupplierCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSupplierCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEdit12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEdit50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemSearchLookUpEditOperator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceCodeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemCustomSearchLookUpEditOperator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCustomSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditLinkCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditRegion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditCountry.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlStatus)).EndInit();
            this.PanelControlStatus.ResumeLayout(false);
            this.PanelControlStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource BindingSource;
        private DevExpress.XtraEditors.TextEdit TextEditName;
        private DevExpress.XtraEditors.TextEdit TextEditCode;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private DevExpress.XtraEditors.SplitContainerControl SplitContainerControl;
        private DevExpress.XtraEditors.PanelControl PanelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
        private DevExpress.XtraEditors.PanelControl PanelControlMappings;
        private DevExpress.XtraEditors.SimpleButton ButtonDeleteMapping;
        private DevExpress.XtraEditors.SimpleButton ButtonAddMapping;
        private DevExpress.XtraGrid.GridControl GridControlSupplierCity;
        private System.Windows.Forms.BindingSource BindingSourceSupplierCity;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewSupplierCity;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSupplierCityId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSupplierGuid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCityCodeSupplier;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCityNameSupplier;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit RepositoryItemTextEdit12;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit RepositoryItemTextEdit50;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCitycodCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnInactive;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnOperator;
        private System.Windows.Forms.BindingSource BindingSourceCodeName;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager BarManager;
        private DevExpress.XtraBars.Bar BarTools;
        private DevExpress.XtraBars.BarButtonItem BarButtonItemNew;
        private DevExpress.XtraBars.BarButtonItem BarButtonItemDelete;
        private DevExpress.XtraBars.BarButtonItem BarButtonItemSave;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private Custom_SearchLookupEdit.RepositoryItemCustomSearchLookUpEdit RepositoryItemCustomSearchLookUpEditOperator;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemCustomSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colCode1;
        private DevExpress.XtraGrid.Columns.GridColumn colName1;
        private DevExpress.Data.Linq.EntityInstantFeedbackSource EntityInstantFeedbackSource;
        private DevExpress.XtraMap.MapControl MapControl;
        private DevExpress.XtraMap.ImageLayer ImageLayer;
        private DevExpress.XtraMap.BingMapDataProvider BingMapDataProvider;
        private DevExpress.XtraMap.VectorItemsLayer VectorItemsLayer;
        private DevExpress.XtraMap.MapItemStorage MapItemStorage;
        private DevExpress.XtraMap.InformationLayer InformationLayer;
        private DevExpress.XtraMap.BingSearchDataProvider BingSearchDataProvider;
        private DevExpress.XtraMap.BingMapDataProvider bingMapDataProvider2;
        private DevExpress.XtraMap.BingMapDataProvider bingMapDataProvider3;
        private DevExpress.XtraEditors.SimpleButton SimpleButtonPlot;
        private DevExpress.XtraEditors.LabelControl LabelControlLon;
        private DevExpress.XtraEditors.LabelControl LabelControlLat;
        private DevExpress.XtraGrid.GridControl GridControlLookup;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewLookup;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLookupCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLookupName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLookupLinkCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLookupState;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLookupRegion;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLookupCountry;
        private DevExpress.XtraEditors.SearchLookUpEdit SearchLookupEditLinkCode;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.SearchLookUpEdit SearchLookupEditState;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.SearchLookUpEdit SearchLookupEditRegion;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.SearchLookUpEdit SearchLookupEditCountry;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit RepositoryItemSearchLookUpEditOperator;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
    }
}