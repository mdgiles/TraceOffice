namespace TraceForms
{
    partial class CountryForm
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
            System.Windows.Forms.Label nAMELabel;
            System.Windows.Forms.Label cODELabel;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label LabelMappings;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CountryForm));
            this.GridControlLookup = new DevExpress.XtraGrid.GridControl();
            this.EntityInstantFeedbackSource = new DevExpress.Data.Linq.EntityInstantFeedbackSource();
            this.GridViewLookup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAGY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCOMP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOTEL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TextEditCode = new DevExpress.XtraEditors.TextEdit();
            this.TextEditName = new DevExpress.XtraEditors.TextEdit();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.SplitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.PanelControlMappings = new DevExpress.XtraEditors.PanelControl();
            this.GridControlSupplierCountry = new DevExpress.XtraGrid.GridControl();
            this.BindingSourceSupplierCountry = new System.Windows.Forms.BindingSource(this.components);
            this.GridViewSupplierCountry = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSupplierGuid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSupplierId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryItemTextEdit50 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumnSupplierName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnInternalCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnInactive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ButtonDeleteMapping = new DevExpress.XtraEditors.SimpleButton();
            this.ButtonAddMapping = new DevExpress.XtraEditors.SimpleButton();
            this.SearchLookupEditContinent = new Custom_SearchLookupEdit.CustomSearchLookUpEdit();
            this.BindingSourceIdName = new System.Windows.Forms.BindingSource(this.components);
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
            nAMELabel = new System.Windows.Forms.Label();
            cODELabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            LabelMappings = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl)).BeginInit();
            this.SplitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlMappings)).BeginInit();
            this.PanelControlMappings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlSupplierCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceSupplierCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSupplierCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEdit50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditContinent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceIdName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlStatus)).BeginInit();
            this.PanelControlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            this.SuspendLayout();
            // 
            // nAMELabel
            // 
            nAMELabel.AutoSize = true;
            nAMELabel.Location = new System.Drawing.Point(118, 210);
            nAMELabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            nAMELabel.Name = "nAMELabel";
            nAMELabel.Size = new System.Drawing.Size(66, 25);
            nAMELabel.TabIndex = 14;
            nAMELabel.Text = "Name";
            // 
            // cODELabel
            // 
            cODELabel.AutoSize = true;
            cODELabel.Location = new System.Drawing.Point(118, 138);
            cODELabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            cODELabel.Name = "cODELabel";
            cODELabel.Size = new System.Drawing.Size(59, 25);
            cODELabel.TabIndex = 13;
            cODELabel.Text = "Code";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(118, 283);
            label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(102, 25);
            label2.TabIndex = 26;
            label2.Text = "Continent";
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
            // GridControlLookup
            // 
            this.GridControlLookup.DataSource = this.EntityInstantFeedbackSource;
            this.GridControlLookup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControlLookup.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6);
            this.GridControlLookup.Location = new System.Drawing.Point(0, 0);
            this.GridControlLookup.MainView = this.GridViewLookup;
            this.GridControlLookup.Margin = new System.Windows.Forms.Padding(6);
            this.GridControlLookup.Name = "GridControlLookup";
            this.GridControlLookup.Size = new System.Drawing.Size(376, 1078);
            this.GridControlLookup.TabIndex = 99;
            this.GridControlLookup.TabStop = false;
            this.GridControlLookup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewLookup});
            // 
            // EntityInstantFeedbackSource
            // 
            this.EntityInstantFeedbackSource.DesignTimeElementType = typeof(FlexModel.COUNTRY);
            this.EntityInstantFeedbackSource.KeyExpression = "CODE";
            this.EntityInstantFeedbackSource.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.EntityInstantFeedbackSource_GetQueryable);
            this.EntityInstantFeedbackSource.DismissQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.EntityInstantFeedbackSource_DismissQueryable);
            // 
            // GridViewLookup
            // 
            this.GridViewLookup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDisplayName,
            this.colCODE,
            this.gridColumn1,
            this.colAGY,
            this.colCOMP,
            this.colHOTEL,
            this.colAddress});
            this.GridViewLookup.GridControl = this.GridControlLookup;
            this.GridViewLookup.Name = "GridViewLookup";
            this.GridViewLookup.OptionsBehavior.Editable = false;
            this.GridViewLookup.OptionsView.ShowAutoFilterRow = true;
            this.GridViewLookup.OptionsView.ShowGroupPanel = false;
            this.GridViewLookup.OptionsView.ShowIndicator = false;
            this.GridViewLookup.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewLookup_FocusedRowChanged);
            this.GridViewLookup.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.GridViewLookup_BeforeLeaveRow);
            // 
            // colDisplayName
            // 
            this.colDisplayName.FieldName = "DisplayName";
            this.colDisplayName.Name = "colDisplayName";
            this.colDisplayName.OptionsColumn.ReadOnly = true;
            // 
            // colCODE
            // 
            this.colCODE.Caption = "Code";
            this.colCODE.FieldName = "CODE";
            this.colCODE.Name = "colCODE";
            this.colCODE.Visible = true;
            this.colCODE.VisibleIndex = 0;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Name";
            this.gridColumn1.FieldName = "NAME";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // colAGY
            // 
            this.colAGY.FieldName = "AGY";
            this.colAGY.Name = "colAGY";
            // 
            // colCOMP
            // 
            this.colCOMP.FieldName = "COMP";
            this.colCOMP.Name = "colCOMP";
            // 
            // colHOTEL
            // 
            this.colHOTEL.FieldName = "HOTEL";
            this.colHOTEL.Name = "colHOTEL";
            // 
            // colAddress
            // 
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(FlexModel.COUNTRY);
            this.BindingSource.CurrentChanged += new System.EventHandler(this.BindingSource_CurrentChanged);
            // 
            // TextEditCode
            // 
            this.TextEditCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CODE", true));
            this.TextEditCode.EnterMoveNextControl = true;
            this.TextEditCode.Location = new System.Drawing.Point(256, 135);
            this.TextEditCode.Margin = new System.Windows.Forms.Padding(6);
            this.TextEditCode.Name = "TextEditCode";
            this.TextEditCode.Properties.MaxLength = 3;
            this.TextEditCode.Size = new System.Drawing.Size(134, 34);
            this.TextEditCode.TabIndex = 1;
            this.TextEditCode.Leave += new System.EventHandler(this.TextEditCode_Leave);
            // 
            // TextEditName
            // 
            this.TextEditName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "NAME", true));
            this.TextEditName.EnterMoveNextControl = true;
            this.TextEditName.Location = new System.Drawing.Point(256, 206);
            this.TextEditName.Margin = new System.Windows.Forms.Padding(6);
            this.TextEditName.Name = "TextEditName";
            this.TextEditName.Properties.MaxLength = 50;
            this.TextEditName.Size = new System.Drawing.Size(404, 34);
            this.TextEditName.TabIndex = 2;
            this.TextEditName.Leave += new System.EventHandler(this.TextEditName_Leave);
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
            this.SplitContainerControl.Panel2.Controls.Add(this.SearchLookupEditContinent);
            this.SplitContainerControl.Panel2.Controls.Add(label2);
            this.SplitContainerControl.Panel2.Controls.Add(nAMELabel);
            this.SplitContainerControl.Panel2.Controls.Add(this.TextEditCode);
            this.SplitContainerControl.Panel2.Controls.Add(cODELabel);
            this.SplitContainerControl.Panel2.Controls.Add(this.TextEditName);
            this.SplitContainerControl.Panel2.Text = "Panel2";
            this.SplitContainerControl.Size = new System.Drawing.Size(2040, 1078);
            this.SplitContainerControl.SplitterPosition = 376;
            this.SplitContainerControl.TabIndex = 13;
            this.SplitContainerControl.Text = "splitContainerControl1";
            // 
            // PanelControlMappings
            // 
            this.PanelControlMappings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelControlMappings.Controls.Add(LabelMappings);
            this.PanelControlMappings.Controls.Add(this.GridControlSupplierCountry);
            this.PanelControlMappings.Controls.Add(this.ButtonDeleteMapping);
            this.PanelControlMappings.Controls.Add(this.ButtonAddMapping);
            this.PanelControlMappings.Location = new System.Drawing.Point(123, 544);
            this.PanelControlMappings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PanelControlMappings.Name = "PanelControlMappings";
            this.PanelControlMappings.Size = new System.Drawing.Size(1357, 471);
            this.PanelControlMappings.TabIndex = 272;
            // 
            // GridControlSupplierCountry
            // 
            this.GridControlSupplierCountry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridControlSupplierCountry.DataSource = this.BindingSourceSupplierCountry;
            this.GridControlSupplierCountry.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GridControlSupplierCountry.Location = new System.Drawing.Point(46, 65);
            this.GridControlSupplierCountry.MainView = this.GridViewSupplierCountry;
            this.GridControlSupplierCountry.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GridControlSupplierCountry.Name = "GridControlSupplierCountry";
            this.GridControlSupplierCountry.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RepositoryItemTextEdit50});
            this.GridControlSupplierCountry.Size = new System.Drawing.Size(1184, 373);
            this.GridControlSupplierCountry.TabIndex = 84;
            this.GridControlSupplierCountry.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewSupplierCountry});
            this.GridControlSupplierCountry.Leave += new System.EventHandler(this.GridControlSupplierCountry_Leave);
            // 
            // BindingSourceSupplierCountry
            // 
            this.BindingSourceSupplierCountry.DataSource = typeof(FlexModel.SupplierCountry);
            // 
            // GridViewSupplierCountry
            // 
            this.GridViewSupplierCountry.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnId,
            this.gridColumnSupplierGuid,
            this.gridColumnSupplierId,
            this.gridColumnSupplierName,
            this.gridColumnInternalCode,
            this.gridColumnInactive});
            this.GridViewSupplierCountry.GridControl = this.GridControlSupplierCountry;
            this.GridViewSupplierCountry.Name = "GridViewSupplierCountry";
            this.GridViewSupplierCountry.OptionsView.ShowGroupPanel = false;
            this.GridViewSupplierCountry.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.GridViewSupplierCountry_CustomRowCellEdit);
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
            // SearchLookupEditContinent
            // 
            this.SearchLookupEditContinent.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Continent_ID", true));
            this.SearchLookupEditContinent.EditValue = "";
            this.SearchLookupEditContinent.EnterMoveNextControl = true;
            this.SearchLookupEditContinent.Location = new System.Drawing.Point(256, 277);
            this.SearchLookupEditContinent.Margin = new System.Windows.Forms.Padding(6);
            this.SearchLookupEditContinent.Name = "SearchLookupEditContinent";
            this.SearchLookupEditContinent.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.SearchLookupEditContinent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLookupEditContinent.Properties.DataSource = this.BindingSourceIdName;
            this.SearchLookupEditContinent.Properties.DisplayMember = "Name";
            this.SearchLookupEditContinent.Properties.NullText = "";
            this.SearchLookupEditContinent.Properties.ValueMember = "Id";
            this.SearchLookupEditContinent.Size = new System.Drawing.Size(404, 34);
            this.SearchLookupEditContinent.TabIndex = 25;
            this.SearchLookupEditContinent.UpdateDisplayFilter += new Custom_SearchLookupEdit.UpdateDisplayFilterHandler(this.SearchLookupEdit_UpdateDisplayFilter);
            this.SearchLookupEditContinent.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            this.SearchLookupEditContinent.Leave += new System.EventHandler(this.SearchLookupEditContinent_Leave);
            // 
            // BindingSourceIdName
            // 
            this.BindingSourceIdName.DataSource = typeof(TraceForms.IdName);
            // 
            // PanelControlStatus
            // 
            this.PanelControlStatus.Appearance.Options.UseTextOptions = true;
            this.PanelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("PanelControlStatus.ContentImage")));
            this.PanelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.PanelControlStatus.Controls.Add(this.LabelStatus);
            this.PanelControlStatus.Location = new System.Drawing.Point(606, 4);
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
            this.BarTools.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
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
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(6);
            this.barDockControlTop.Size = new System.Drawing.Size(2040, 60);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 1138);
            this.barDockControlBottom.Manager = this.BarManager;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(6);
            this.barDockControlBottom.Size = new System.Drawing.Size(2040, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 60);
            this.barDockControlLeft.Manager = this.BarManager;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(6);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 1078);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(2040, 60);
            this.barDockControlRight.Manager = this.BarManager;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(6);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 1078);
            // 
            // CountryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2040, 1138);
            this.Controls.Add(this.PanelControlStatus);
            this.Controls.Add(this.SplitContainerControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimizeBox = false;
            this.Name = "CountryForm";
            this.ShowInTaskbar = false;
            this.Text = "CountryForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CountryForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.GridControlLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl)).EndInit();
            this.SplitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlMappings)).EndInit();
            this.PanelControlMappings.ResumeLayout(false);
            this.PanelControlMappings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlSupplierCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceSupplierCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSupplierCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryItemTextEdit50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditContinent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceIdName)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit TextEditCode;
        private DevExpress.XtraEditors.TextEdit TextEditName;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private DevExpress.XtraEditors.SplitContainerControl SplitContainerControl;
        private DevExpress.XtraEditors.PanelControl PanelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplayName;
        private DevExpress.XtraGrid.Columns.GridColumn colCODE;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colAGY;
        private DevExpress.XtraGrid.Columns.GridColumn colCOMP;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTEL;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        public DevExpress.XtraGrid.Views.Grid.GridView GridViewLookup;
        private Custom_SearchLookupEdit.CustomSearchLookUpEdit SearchLookupEditContinent;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarManager BarManager;
		private DevExpress.XtraBars.Bar BarTools;
		private DevExpress.XtraBars.BarButtonItem BarButtonItemNew;
		private DevExpress.XtraBars.BarButtonItem BarButtonItemDelete;
		private DevExpress.XtraBars.BarButtonItem BarButtonItemSave;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
		private System.Windows.Forms.BindingSource BindingSourceIdName;
        private DevExpress.Data.Linq.EntityInstantFeedbackSource EntityInstantFeedbackSource;
        private System.Windows.Forms.BindingSource BindingSourceSupplierCountry;
        private DevExpress.XtraEditors.PanelControl PanelControlMappings;
        private DevExpress.XtraGrid.GridControl GridControlSupplierCountry;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewSupplierCountry;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSupplierGuid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSupplierId;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit RepositoryItemTextEdit50;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSupplierName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnInternalCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnInactive;
        private DevExpress.XtraEditors.SimpleButton ButtonDeleteMapping;
        private DevExpress.XtraEditors.SimpleButton ButtonAddMapping;
    }
}