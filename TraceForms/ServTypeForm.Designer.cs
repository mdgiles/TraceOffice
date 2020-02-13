namespace TraceForms
{
    partial class ServTypeForm
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
            System.Windows.Forms.Label dESCRIPLabel;
            System.Windows.Forms.Label LabelType;
            System.Windows.Forms.Label LabelMappings;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServTypeForm));
            this.GridControlLookup = new DevExpress.XtraGrid.GridControl();
            this.EntityInstantFeedbackSource = new DevExpress.Data.Linq.EntityInstantFeedbackSource();
            this.GridViewLookup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GridColumnCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLINKTYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCOMP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSERVTYPE1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSERVTYPE2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCOMP1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TextEditCode = new DevExpress.XtraEditors.TextEdit();
            this.TextEditDesc = new DevExpress.XtraEditors.TextEdit();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.SplitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.PanelControlMappings = new DevExpress.XtraEditors.PanelControl();
            this.GridControlSupplierServType = new DevExpress.XtraGrid.GridControl();
            this.BindingSourceSupplierServType = new System.Windows.Forms.BindingSource(this.components);
            this.GridViewSupplierServType = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSupplierGuid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSupplierId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemTextEdit50 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumnSupplierName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnInternalCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnInactive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ButtonDeleteMapping = new DevExpress.XtraEditors.SimpleButton();
            this.ButtonAddMapping = new DevExpress.XtraEditors.SimpleButton();
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
            dESCRIPLabel = new System.Windows.Forms.Label();
            LabelType = new System.Windows.Forms.Label();
            LabelMappings = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl)).BeginInit();
            this.SplitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlMappings)).BeginInit();
            this.PanelControlMappings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlSupplierServType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceSupplierServType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSupplierServType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEdit50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlStatus)).BeginInit();
            this.PanelControlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            this.SuspendLayout();
            // 
            // dESCRIPLabel
            // 
            dESCRIPLabel.AutoSize = true;
            dESCRIPLabel.Location = new System.Drawing.Point(38, 117);
            dESCRIPLabel.Name = "dESCRIPLabel";
            dESCRIPLabel.Size = new System.Drawing.Size(60, 13);
            dESCRIPLabel.TabIndex = 16;
            dESCRIPLabel.Text = "Description";
            // 
            // LabelType
            // 
            LabelType.AutoSize = true;
            LabelType.Location = new System.Drawing.Point(38, 91);
            LabelType.Name = "LabelType";
            LabelType.Size = new System.Drawing.Size(32, 13);
            LabelType.TabIndex = 15;
            LabelType.Text = "Code";
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
            // GridControlLookup
            // 
            this.GridControlLookup.DataSource = this.EntityInstantFeedbackSource;
            this.GridControlLookup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControlLookup.Location = new System.Drawing.Point(0, 0);
            this.GridControlLookup.MainView = this.GridViewLookup;
            this.GridControlLookup.Name = "GridControlLookup";
            this.GridControlLookup.Size = new System.Drawing.Size(297, 652);
            this.GridControlLookup.TabIndex = 14;
            this.GridControlLookup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewLookup});
            // 
            // EntityInstantFeedbackSource
            // 
            this.EntityInstantFeedbackSource.DesignTimeElementType = typeof(FlexModel.SERVTYPE);
            this.EntityInstantFeedbackSource.KeyExpression = "TYPE";
            this.EntityInstantFeedbackSource.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.EntityInstantFeedbackSource_GetQueryable);
            this.EntityInstantFeedbackSource.DismissQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.EntityInstantFeedbackSource_DismissQueryable);
            // 
            // GridViewLookup
            // 
            this.GridViewLookup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GridColumnCode,
            this.GridColumnName,
            this.colLINKTYPE,
            this.colCOMP,
            this.colSERVTYPE1,
            this.colSERVTYPE2,
            this.colCOMP1,
            this.colDisplayName});
            this.GridViewLookup.DetailHeight = 182;
            this.GridViewLookup.FixedLineWidth = 1;
            this.GridViewLookup.GridControl = this.GridControlLookup;
            this.GridViewLookup.LevelIndent = 0;
            this.GridViewLookup.Name = "GridViewLookup";
            this.GridViewLookup.OptionsBehavior.Editable = false;
            this.GridViewLookup.OptionsView.ShowAutoFilterRow = true;
            this.GridViewLookup.OptionsView.ShowGroupPanel = false;
            this.GridViewLookup.OptionsView.ShowIndicator = false;
            this.GridViewLookup.PreviewIndent = 0;
            this.GridViewLookup.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewLookup_FocusedRowChanged);
            this.GridViewLookup.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.GridViewLookup_BeforeLeaveRow);
            this.GridViewLookup.ColumnFilterChanged += new System.EventHandler(this.GridViewLookup_ColumnFilterChanged);
            // 
            // GridColumnCode
            // 
            this.GridColumnCode.Caption = "Code";
            this.GridColumnCode.FieldName = "TYPE";
            this.GridColumnCode.MinWidth = 10;
            this.GridColumnCode.Name = "GridColumnCode";
            this.GridColumnCode.Visible = true;
            this.GridColumnCode.VisibleIndex = 0;
            this.GridColumnCode.Width = 37;
            // 
            // GridColumnName
            // 
            this.GridColumnName.Caption = "Name";
            this.GridColumnName.FieldName = "DESCRIP";
            this.GridColumnName.MinWidth = 10;
            this.GridColumnName.Name = "GridColumnName";
            this.GridColumnName.Visible = true;
            this.GridColumnName.VisibleIndex = 1;
            this.GridColumnName.Width = 37;
            // 
            // colLINKTYPE
            // 
            this.colLINKTYPE.FieldName = "LINKTYPE";
            this.colLINKTYPE.MinWidth = 10;
            this.colLINKTYPE.Name = "colLINKTYPE";
            this.colLINKTYPE.Width = 37;
            // 
            // colCOMP
            // 
            this.colCOMP.FieldName = "COMP";
            this.colCOMP.MinWidth = 10;
            this.colCOMP.Name = "colCOMP";
            this.colCOMP.Width = 37;
            // 
            // colSERVTYPE1
            // 
            this.colSERVTYPE1.FieldName = "SERVTYPE1";
            this.colSERVTYPE1.MinWidth = 10;
            this.colSERVTYPE1.Name = "colSERVTYPE1";
            this.colSERVTYPE1.Width = 37;
            // 
            // colSERVTYPE2
            // 
            this.colSERVTYPE2.FieldName = "SERVTYPE2";
            this.colSERVTYPE2.MinWidth = 10;
            this.colSERVTYPE2.Name = "colSERVTYPE2";
            this.colSERVTYPE2.Width = 37;
            // 
            // colCOMP1
            // 
            this.colCOMP1.FieldName = "COMP1";
            this.colCOMP1.MinWidth = 10;
            this.colCOMP1.Name = "colCOMP1";
            this.colCOMP1.Width = 37;
            // 
            // colDisplayName
            // 
            this.colDisplayName.FieldName = "DisplayName";
            this.colDisplayName.MinWidth = 10;
            this.colDisplayName.Name = "colDisplayName";
            this.colDisplayName.OptionsColumn.ReadOnly = true;
            this.colDisplayName.Width = 37;
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(FlexModel.SERVTYPE);
            this.BindingSource.CurrentChanged += new System.EventHandler(this.ServTypeBindingSource_CurrentChanged);
            // 
            // TextEditCode
            // 
            this.TextEditCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "TYPE", true));
            this.TextEditCode.Location = new System.Drawing.Point(103, 88);
            this.TextEditCode.Name = "TextEditCode";
            this.TextEditCode.Properties.MaxLength = 12;
            this.TextEditCode.Size = new System.Drawing.Size(100, 20);
            this.TextEditCode.TabIndex = 19;
            this.TextEditCode.Leave += new System.EventHandler(this.TextEditType_Leave);
            // 
            // TextEditDesc
            // 
            this.TextEditDesc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "DESCRIP", true));
            this.TextEditDesc.Location = new System.Drawing.Point(103, 114);
            this.TextEditDesc.Name = "TextEditDesc";
            this.TextEditDesc.Properties.MaxLength = 60;
            this.TextEditDesc.Size = new System.Drawing.Size(285, 20);
            this.TextEditDesc.TabIndex = 17;
            this.TextEditDesc.Leave += new System.EventHandler(this.TextEditDesc_Leave);
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
            this.SplitContainerControl.Panel2.Controls.Add(this.PanelControlMappings);
            this.SplitContainerControl.Panel2.Controls.Add(dESCRIPLabel);
            this.SplitContainerControl.Panel2.Controls.Add(this.TextEditCode);
            this.SplitContainerControl.Panel2.Controls.Add(LabelType);
            this.SplitContainerControl.Panel2.Controls.Add(this.TextEditDesc);
            this.SplitContainerControl.Panel2.Text = "Panel2";
            this.SplitContainerControl.Size = new System.Drawing.Size(782, 652);
            this.SplitContainerControl.SplitterPosition = 297;
            this.SplitContainerControl.TabIndex = 21;
            this.SplitContainerControl.Text = "splitContainerControl1";
            // 
            // PanelControlMappings
            // 
            this.PanelControlMappings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelControlMappings.Controls.Add(LabelMappings);
            this.PanelControlMappings.Controls.Add(this.GridControlSupplierServType);
            this.PanelControlMappings.Controls.Add(this.ButtonDeleteMapping);
            this.PanelControlMappings.Controls.Add(this.ButtonAddMapping);
            this.PanelControlMappings.Location = new System.Drawing.Point(41, 156);
            this.PanelControlMappings.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.PanelControlMappings.Name = "PanelControlMappings";
            this.PanelControlMappings.Size = new System.Drawing.Size(424, 269);
            this.PanelControlMappings.TabIndex = 273;
            // 
            // GridControlSupplierServType
            // 
            this.GridControlSupplierServType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridControlSupplierServType.DataSource = this.BindingSourceSupplierServType;
            this.GridControlSupplierServType.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GridControlSupplierServType.Location = new System.Drawing.Point(23, 34);
            this.GridControlSupplierServType.MainView = this.GridViewSupplierServType;
            this.GridControlSupplierServType.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GridControlSupplierServType.Name = "GridControlSupplierServType";
            this.GridControlSupplierServType.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RepositoryItemTextEdit50});
            this.GridControlSupplierServType.Size = new System.Drawing.Size(337, 194);
            this.GridControlSupplierServType.TabIndex = 84;
            this.GridControlSupplierServType.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewSupplierServType});
            this.GridControlSupplierServType.Leave += new System.EventHandler(this.GridControlSupplierServType_Leave);
            // 
            // BindingSourceSupplierServType
            // 
            this.BindingSourceSupplierServType.DataSource = typeof(FlexModel.SupplierServiceType);
            // 
            // GridViewSupplierServType
            // 
            this.GridViewSupplierServType.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnId,
            this.gridColumnSupplierGuid,
            this.gridColumnSupplierId,
            this.gridColumnSupplierName,
            this.gridColumnInternalCode,
            this.gridColumnInactive});
            this.GridViewSupplierServType.DetailHeight = 182;
            this.GridViewSupplierServType.FixedLineWidth = 1;
            this.GridViewSupplierServType.GridControl = this.GridControlSupplierServType;
            this.GridViewSupplierServType.LevelIndent = 0;
            this.GridViewSupplierServType.Name = "GridViewSupplierServType";
            this.GridViewSupplierServType.OptionsView.ShowGroupPanel = false;
            this.GridViewSupplierServType.PreviewIndent = 0;
            this.GridViewSupplierServType.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.GridViewSupplierServType_CustomRowCellEdit);
            // 
            // gridColumnId
            // 
            this.gridColumnId.FieldName = "Id";
            this.gridColumnId.MinWidth = 10;
            this.gridColumnId.Name = "gridColumnId";
            this.gridColumnId.Width = 37;
            // 
            // gridColumnSupplierGuid
            // 
            this.gridColumnSupplierGuid.Caption = "Supplier";
            this.gridColumnSupplierGuid.FieldName = "Supplier_GUID";
            this.gridColumnSupplierGuid.MinWidth = 10;
            this.gridColumnSupplierGuid.Name = "gridColumnSupplierGuid";
            this.gridColumnSupplierGuid.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumnSupplierGuid.Visible = true;
            this.gridColumnSupplierGuid.VisibleIndex = 0;
            this.gridColumnSupplierGuid.Width = 37;
            // 
            // gridColumnSupplierId
            // 
            this.gridColumnSupplierId.Caption = "Supplier Id";
            this.gridColumnSupplierId.ColumnEdit = this.RepositoryItemTextEdit50;
            this.gridColumnSupplierId.FieldName = "SupplierId";
            this.gridColumnSupplierId.MinWidth = 10;
            this.gridColumnSupplierId.Name = "gridColumnSupplierId";
            this.gridColumnSupplierId.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumnSupplierId.Visible = true;
            this.gridColumnSupplierId.VisibleIndex = 1;
            this.gridColumnSupplierId.Width = 37;
            // 
            // RepositoryItemTextEdit50
            // 
            this.RepositoryItemTextEdit50.AutoHeight = false;
            this.RepositoryItemTextEdit50.MaxLength = 50;
            this.RepositoryItemTextEdit50.Name = "RepositoryItemTextEdit50";
            // 
            // gridColumnSupplierName
            // 
            this.gridColumnSupplierName.Caption = "Supplier Name";
            this.gridColumnSupplierName.ColumnEdit = this.RepositoryItemTextEdit50;
            this.gridColumnSupplierName.FieldName = "SupplierName";
            this.gridColumnSupplierName.MinWidth = 10;
            this.gridColumnSupplierName.Name = "gridColumnSupplierName";
            this.gridColumnSupplierName.Visible = true;
            this.gridColumnSupplierName.VisibleIndex = 2;
            this.gridColumnSupplierName.Width = 37;
            // 
            // gridColumnInternalCode
            // 
            this.gridColumnInternalCode.Caption = "gridColumn1";
            this.gridColumnInternalCode.FieldName = "Region_Code";
            this.gridColumnInternalCode.MinWidth = 10;
            this.gridColumnInternalCode.Name = "gridColumnInternalCode";
            this.gridColumnInternalCode.Width = 37;
            // 
            // gridColumnInactive
            // 
            this.gridColumnInactive.Caption = "Inactive";
            this.gridColumnInactive.FieldName = "Inactive";
            this.gridColumnInactive.MinWidth = 10;
            this.gridColumnInactive.Name = "gridColumnInactive";
            this.gridColumnInactive.Visible = true;
            this.gridColumnInactive.VisibleIndex = 3;
            this.gridColumnInactive.Width = 37;
            // 
            // ButtonDeleteMapping
            // 
            this.ButtonDeleteMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonDeleteMapping.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonDeleteMapping.ImageOptions.Image")));
            this.ButtonDeleteMapping.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ButtonDeleteMapping.Location = new System.Drawing.Point(372, 75);
            this.ButtonDeleteMapping.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ButtonDeleteMapping.Name = "ButtonDeleteMapping";
            this.ButtonDeleteMapping.Size = new System.Drawing.Size(41, 36);
            this.ButtonDeleteMapping.TabIndex = 39;
            this.ButtonDeleteMapping.TabStop = false;
            this.ButtonDeleteMapping.Click += new System.EventHandler(this.ButtonDeleteMapping_Click);
            // 
            // ButtonAddMapping
            // 
            this.ButtonAddMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonAddMapping.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonAddMapping.ImageOptions.Image")));
            this.ButtonAddMapping.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ButtonAddMapping.Location = new System.Drawing.Point(372, 34);
            this.ButtonAddMapping.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ButtonAddMapping.Name = "ButtonAddMapping";
            this.ButtonAddMapping.Size = new System.Drawing.Size(41, 36);
            this.ButtonAddMapping.TabIndex = 34;
            this.ButtonAddMapping.Click += new System.EventHandler(this.ButtonAddMapping_Click);
            // 
            // PanelControlStatus
            // 
            this.PanelControlStatus.Appearance.Options.UseTextOptions = true;
            this.PanelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("PanelControlStatus.ContentImage")));
            this.PanelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.PanelControlStatus.Controls.Add(this.LabelStatus);
            this.PanelControlStatus.Location = new System.Drawing.Point(313, 2);
            this.PanelControlStatus.Name = "PanelControlStatus";
            this.PanelControlStatus.Size = new System.Drawing.Size(120, 23);
            this.PanelControlStatus.TabIndex = 265;
            this.PanelControlStatus.Visible = false;
            // 
            // LabelStatus
            // 
            this.LabelStatus.Location = new System.Drawing.Point(30, 5);
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
            this.BarButtonItemSave});
            this.BarManager.MaxItemId = 3;
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
            this.barDockControlTop.Size = new System.Drawing.Size(782, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 683);
            this.barDockControlBottom.Manager = this.BarManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(782, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Manager = this.BarManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 652);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(782, 31);
            this.barDockControlRight.Manager = this.BarManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 652);
            // 
            // ServTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 683);
            this.Controls.Add(this.PanelControlStatus);
            this.Controls.Add(this.SplitContainerControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "ServTypeForm";
            this.ShowInTaskbar = false;
            this.Text = "Service Type";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServTypeForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.GridControlLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl)).EndInit();
            this.SplitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlMappings)).EndInit();
            this.PanelControlMappings.ResumeLayout(false);
            this.PanelControlMappings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlSupplierServType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceSupplierServType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSupplierServType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEdit50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlStatus)).EndInit();
            this.PanelControlStatus.ResumeLayout(false);
            this.PanelControlStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GridControlLookup;
        private System.Windows.Forms.BindingSource BindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewLookup;
        private DevExpress.XtraEditors.TextEdit TextEditCode;
        private DevExpress.XtraEditors.TextEdit TextEditDesc;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private DevExpress.XtraEditors.SplitContainerControl SplitContainerControl;
        private DevExpress.XtraEditors.PanelControl PanelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
        private DevExpress.XtraGrid.Columns.GridColumn GridColumnCode;
        private DevExpress.XtraGrid.Columns.GridColumn GridColumnName;
        private DevExpress.XtraGrid.Columns.GridColumn colLINKTYPE;
        private DevExpress.XtraGrid.Columns.GridColumn colCOMP;
        private DevExpress.XtraGrid.Columns.GridColumn colSERVTYPE1;
        private DevExpress.XtraGrid.Columns.GridColumn colSERVTYPE2;
        private DevExpress.XtraGrid.Columns.GridColumn colCOMP1;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplayName;
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
        private DevExpress.XtraEditors.PanelControl PanelControlMappings;
        private DevExpress.XtraGrid.GridControl GridControlSupplierServType;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewSupplierServType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSupplierGuid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSupplierId;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit RepositoryItemTextEdit50;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSupplierName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnInternalCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnInactive;
        private DevExpress.XtraEditors.SimpleButton ButtonDeleteMapping;
        private DevExpress.XtraEditors.SimpleButton ButtonAddMapping;
        private System.Windows.Forms.BindingSource BindingSourceSupplierServType;
    }
}