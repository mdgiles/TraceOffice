namespace TraceForms
{
    partial class RegionForm
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
            System.Windows.Forms.Label LabelMappings;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegionForm));
            this.TextEditCode = new DevExpress.XtraEditors.TextEdit();
            this.BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TextEditName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.GridControlLookup = new DevExpress.XtraGrid.GridControl();
            this.EntityInstantFeedbackSource = new DevExpress.Data.Linq.EntityInstantFeedbackSource();
            this.GridViewLookup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDESC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.SplitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.PanelControlMappings = new DevExpress.XtraEditors.PanelControl();
            this.GridControlSupplierRegion = new DevExpress.XtraGrid.GridControl();
            this.BindingSourceSupplierRegion = new System.Windows.Forms.BindingSource(this.components);
            this.GridViewSupplierRegion = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.barTools = new DevExpress.XtraBars.Bar();
            this.BarButtonItemNew = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItemDelete = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            LabelMappings = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl)).BeginInit();
            this.SplitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlMappings)).BeginInit();
            this.PanelControlMappings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlSupplierRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceSupplierRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSupplierRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEdit50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlStatus)).BeginInit();
            this.PanelControlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelMappings
            // 
            LabelMappings.AutoSize = true;
            LabelMappings.Location = new System.Drawing.Point(41, 22);
            LabelMappings.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LabelMappings.Name = "LabelMappings";
            LabelMappings.Size = new System.Drawing.Size(192, 25);
            LabelMappings.TabIndex = 85;
            LabelMappings.Text = "Supplier Mappings:";
            // 
            // TextEditCode
            // 
            this.TextEditCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CODE", true));
            this.TextEditCode.Location = new System.Drawing.Point(170, 190);
            this.TextEditCode.Margin = new System.Windows.Forms.Padding(6);
            this.TextEditCode.Name = "TextEditCode";
            this.TextEditCode.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.TextEditCode.Properties.Appearance.Options.UseBackColor = true;
            this.TextEditCode.Properties.MaxLength = 10;
            this.TextEditCode.Size = new System.Drawing.Size(282, 34);
            this.TextEditCode.TabIndex = 9;
            this.TextEditCode.Leave += new System.EventHandler(this.TextEditCode_Leave);
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(FlexModel.REGION);
            this.BindingSource.CurrentChanged += new System.EventHandler(this.RegionBindingSource_CurrentChanged);
            // 
            // TextEditName
            // 
            this.TextEditName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "DESC", true));
            this.TextEditName.Location = new System.Drawing.Point(170, 240);
            this.TextEditName.Margin = new System.Windows.Forms.Padding(6);
            this.TextEditName.Name = "TextEditName";
            this.TextEditName.Properties.MaxLength = 30;
            this.TextEditName.Size = new System.Drawing.Size(558, 34);
            this.TextEditName.TabIndex = 10;
            this.TextEditName.Leave += new System.EventHandler(this.TextEditName_Leave);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(100, 194);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 25);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "Code";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(100, 244);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 25);
            this.labelControl2.TabIndex = 12;
            this.labelControl2.Text = "Name";
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
            this.GridControlLookup.Size = new System.Drawing.Size(524, 898);
            this.GridControlLookup.TabIndex = 5;
            this.GridControlLookup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewLookup});
            // 
            // EntityInstantFeedbackSource
            // 
            this.EntityInstantFeedbackSource.DesignTimeElementType = typeof(FlexModel.REGION);
            this.EntityInstantFeedbackSource.KeyExpression = "CODE";
            this.EntityInstantFeedbackSource.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.EntityInstantFeedbackSource_GetQueryable);
            this.EntityInstantFeedbackSource.DismissQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.EntityInstantFeedbackSource_DismissQueryable);
            // 
            // GridViewLookup
            // 
            this.GridViewLookup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCODE,
            this.colDESC});
            this.GridViewLookup.GridControl = this.GridControlLookup;
            this.GridViewLookup.Name = "GridViewLookup";
            this.GridViewLookup.OptionsBehavior.Editable = false;
            this.GridViewLookup.OptionsCustomization.AllowQuickHideColumns = false;
            this.GridViewLookup.OptionsView.ShowAutoFilterRow = true;
            this.GridViewLookup.OptionsView.ShowGroupPanel = false;
            this.GridViewLookup.OptionsView.ShowIndicator = false;
            this.GridViewLookup.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel;
            this.GridViewLookup.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewLookup_FocusedRowChanged);
            this.GridViewLookup.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.GridViewLookup_BeforeLeaveRow);
            this.GridViewLookup.ColumnFilterChanged += new System.EventHandler(this.GridViewLookup_ColumnFilterChanged);
            // 
            // colCODE
            // 
            this.colCODE.Caption = "Code";
            this.colCODE.FieldName = "CODE";
            this.colCODE.Name = "colCODE";
            this.colCODE.Visible = true;
            this.colCODE.VisibleIndex = 0;
            // 
            // colDESC
            // 
            this.colDESC.Caption = "Name";
            this.colDESC.FieldName = "DESC";
            this.colDESC.Name = "colDESC";
            this.colDESC.Visible = true;
            this.colDESC.VisibleIndex = 1;
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
            this.SplitContainerControl.Panel2.Controls.Add(this.PanelControlMappings);
            this.SplitContainerControl.Panel2.Controls.Add(this.TextEditCode);
            this.SplitContainerControl.Panel2.Controls.Add(this.labelControl2);
            this.SplitContainerControl.Panel2.Controls.Add(this.TextEditName);
            this.SplitContainerControl.Panel2.Controls.Add(this.labelControl1);
            this.SplitContainerControl.Panel2.Text = "Panel2";
            this.SplitContainerControl.Size = new System.Drawing.Size(1924, 898);
            this.SplitContainerControl.SplitterPosition = 524;
            this.SplitContainerControl.TabIndex = 15;
            this.SplitContainerControl.Text = "splitContainerControl1";
            // 
            // PanelControlMappings
            // 
            this.PanelControlMappings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelControlMappings.Controls.Add(LabelMappings);
            this.PanelControlMappings.Controls.Add(this.GridControlSupplierRegion);
            this.PanelControlMappings.Controls.Add(this.ButtonDeleteMapping);
            this.PanelControlMappings.Controls.Add(this.ButtonAddMapping);
            this.PanelControlMappings.Location = new System.Drawing.Point(20, 346);
            this.PanelControlMappings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PanelControlMappings.Name = "PanelControlMappings";
            this.PanelControlMappings.Size = new System.Drawing.Size(1357, 471);
            this.PanelControlMappings.TabIndex = 271;
            // 
            // GridControlSupplierRegion
            // 
            this.GridControlSupplierRegion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridControlSupplierRegion.DataSource = this.BindingSourceSupplierRegion;
            this.GridControlSupplierRegion.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GridControlSupplierRegion.Location = new System.Drawing.Point(46, 65);
            this.GridControlSupplierRegion.MainView = this.GridViewSupplierRegion;
            this.GridControlSupplierRegion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GridControlSupplierRegion.Name = "GridControlSupplierRegion";
            this.GridControlSupplierRegion.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RepositoryItemTextEdit50});
            this.GridControlSupplierRegion.Size = new System.Drawing.Size(1184, 373);
            this.GridControlSupplierRegion.TabIndex = 84;
            this.GridControlSupplierRegion.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewSupplierRegion});
            this.GridControlSupplierRegion.Leave += new System.EventHandler(this.GridControlSupplierRegion_Leave);
            // 
            // BindingSourceSupplierRegion
            // 
            this.BindingSourceSupplierRegion.DataSource = typeof(FlexModel.SupplierRegion);
            // 
            // GridViewSupplierRegion
            // 
            this.GridViewSupplierRegion.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnId,
            this.gridColumnSupplierGuid,
            this.gridColumnSupplierId,
            this.gridColumnSupplierName,
            this.gridColumnInternalCode,
            this.gridColumnInactive});
            this.GridViewSupplierRegion.GridControl = this.GridControlSupplierRegion;
            this.GridViewSupplierRegion.Name = "GridViewSupplierRegion";
            this.GridViewSupplierRegion.OptionsView.ShowGroupPanel = false;
            this.GridViewSupplierRegion.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.GridViewSupplierRegion_CustomRowCellEdit);
            // 
            // gridColumnId
            // 
            this.gridColumnId.FieldName = "Id";
            this.gridColumnId.Name = "gridColumnId";
            // 
            // gridColumnSupplierGuid
            // 
            this.gridColumnSupplierGuid.Caption = "Supplier";
            this.gridColumnSupplierGuid.FieldName = "Supplier_GUID";
            this.gridColumnSupplierGuid.Name = "gridColumnSupplierGuid";
            this.gridColumnSupplierGuid.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumnSupplierGuid.Visible = true;
            this.gridColumnSupplierGuid.VisibleIndex = 0;
            // 
            // gridColumnSupplierId
            // 
            this.gridColumnSupplierId.Caption = "Supplier Id";
            this.gridColumnSupplierId.ColumnEdit = this.RepositoryItemTextEdit50;
            this.gridColumnSupplierId.FieldName = "SupplierId";
            this.gridColumnSupplierId.Name = "gridColumnSupplierId";
            this.gridColumnSupplierId.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumnSupplierId.Visible = true;
            this.gridColumnSupplierId.VisibleIndex = 1;
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
            this.gridColumnSupplierName.Name = "gridColumnSupplierName";
            this.gridColumnSupplierName.Visible = true;
            this.gridColumnSupplierName.VisibleIndex = 2;
            // 
            // gridColumnInternalCode
            // 
            this.gridColumnInternalCode.Caption = "gridColumn1";
            this.gridColumnInternalCode.FieldName = "Region_Code";
            this.gridColumnInternalCode.Name = "gridColumnInternalCode";
            // 
            // gridColumnInactive
            // 
            this.gridColumnInactive.Caption = "Inactive";
            this.gridColumnInactive.FieldName = "Inactive";
            this.gridColumnInactive.Name = "gridColumnInactive";
            this.gridColumnInactive.Visible = true;
            this.gridColumnInactive.VisibleIndex = 3;
            // 
            // ButtonDeleteMapping
            // 
            this.ButtonDeleteMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonDeleteMapping.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonDeleteMapping.ImageOptions.Image")));
            this.ButtonDeleteMapping.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ButtonDeleteMapping.Location = new System.Drawing.Point(1253, 145);
            this.ButtonDeleteMapping.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ButtonDeleteMapping.Name = "ButtonDeleteMapping";
            this.ButtonDeleteMapping.Size = new System.Drawing.Size(82, 70);
            this.ButtonDeleteMapping.TabIndex = 39;
            this.ButtonDeleteMapping.TabStop = false;
            this.ButtonDeleteMapping.Click += new System.EventHandler(this.ButtonDeleteMapping_Click);
            // 
            // ButtonAddMapping
            // 
            this.ButtonAddMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonAddMapping.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonAddMapping.ImageOptions.Image")));
            this.ButtonAddMapping.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ButtonAddMapping.Location = new System.Drawing.Point(1253, 65);
            this.ButtonAddMapping.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ButtonAddMapping.Name = "ButtonAddMapping";
            this.ButtonAddMapping.Size = new System.Drawing.Size(82, 70);
            this.ButtonAddMapping.TabIndex = 34;
            this.ButtonAddMapping.Click += new System.EventHandler(this.ButtonAddMapping_Click);
            // 
            // PanelControlStatus
            // 
            this.PanelControlStatus.Appearance.Options.UseTextOptions = true;
            this.PanelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("PanelControlStatus.ContentImage")));
            this.PanelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.PanelControlStatus.Controls.Add(this.LabelStatus);
            this.PanelControlStatus.Location = new System.Drawing.Point(594, 4);
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
            this.barTools});
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
            // barTools
            // 
            this.barTools.BarName = "Tools";
            this.barTools.DockCol = 0;
            this.barTools.DockRow = 0;
            this.barTools.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonItemNew),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonItemDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonItemSave)});
            this.barTools.OptionsBar.AllowQuickCustomization = false;
            this.barTools.OptionsBar.DrawDragBorder = false;
            this.barTools.OptionsBar.UseWholeRow = true;
            this.barTools.Text = "Tools";
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
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlTop.Size = new System.Drawing.Size(1924, 60);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 958);
            this.barDockControlBottom.Manager = this.BarManager;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1924, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 60);
            this.barDockControlLeft.Manager = this.BarManager;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 898);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1924, 60);
            this.barDockControlRight.Manager = this.BarManager;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 898);
            // 
            // RegionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 958);
            this.Controls.Add(this.PanelControlStatus);
            this.Controls.Add(this.SplitContainerControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimizeBox = false;
            this.Name = "RegionForm";
            this.ShowInTaskbar = false;
            this.Text = "Regions";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegionForm_FormClosing);
            this.Shown += new System.EventHandler(this.RegionForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl)).EndInit();
            this.SplitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlMappings)).EndInit();
            this.PanelControlMappings.ResumeLayout(false);
            this.PanelControlMappings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlSupplierRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceSupplierRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSupplierRegion)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn colCODE;
        private DevExpress.XtraGrid.Columns.GridColumn colDESC;
        private DevExpress.XtraEditors.TextEdit TextEditCode;
        private DevExpress.XtraEditors.TextEdit TextEditName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private DevExpress.XtraEditors.SplitContainerControl SplitContainerControl;
        private DevExpress.XtraEditors.PanelControl PanelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager BarManager;
        private DevExpress.XtraBars.Bar barTools;
        private DevExpress.XtraBars.BarButtonItem BarButtonItemNew;
        private DevExpress.XtraBars.BarButtonItem BarButtonItemDelete;
        private DevExpress.XtraBars.BarButtonItem BarButtonItemSave;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl PanelControlMappings;
        private DevExpress.XtraGrid.GridControl GridControlSupplierRegion;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewSupplierRegion;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSupplierGuid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSupplierId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSupplierName;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit RepositoryItemTextEdit50;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnInternalCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnInactive;
        private DevExpress.XtraEditors.SimpleButton ButtonDeleteMapping;
        private DevExpress.XtraEditors.SimpleButton ButtonAddMapping;
        private DevExpress.Data.Linq.EntityInstantFeedbackSource EntityInstantFeedbackSource;
        private System.Windows.Forms.BindingSource BindingSourceSupplierRegion;
    }
}