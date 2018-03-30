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
			this.GridViewLookup = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.GridColumnCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumnDesc = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colADDRESS1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colADDRESS2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colADDRESS3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCITY = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSTATE = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colZIP = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCOUNTRY = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colLATITUDE = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colLONGITUDE = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTown = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colGeoCode_ID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colProximitySearch = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colProximitySearchDistance = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDuration = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSearchable = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colGeoCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colRESITM = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colRESITM1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colRelatedProduct = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colRelatedProduct1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.SplitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
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
			this.customSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.SearchLookupEditCountry = new Custom_SearchLookupEdit.CustomSearchLookUpEdit();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.SearchLookupEditCity = new Custom_SearchLookupEdit.CustomSearchLookUpEdit();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
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
			this.BindingSourceCodeName = new System.Windows.Forms.BindingSource(this.components);
			this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDisplayName1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCode1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colName1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDisplayName2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCode2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colName2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDisplayName3 = new DevExpress.XtraGrid.Columns.GridColumn();
			durationLabel = new System.Windows.Forms.Label();
			LabelLat = new System.Windows.Forms.Label();
			LabelLong = new System.Windows.Forms.Label();
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
			((System.ComponentModel.ISupportInitialize)(this.MapControl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEditSearchable.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SpinEditDuration.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CheckEditProximitySearch.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SpinEditDistance.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditState.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.customSearchLookUpEdit1View)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditCountry.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditCity.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PanelControlStatus)).BeginInit();
			this.PanelControlStatus.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BindingSourceCodeName)).BeginInit();
			this.SuspendLayout();
			// 
			// durationLabel
			// 
			durationLabel.AutoSize = true;
			durationLabel.Location = new System.Drawing.Point(18, 457);
			durationLabel.Name = "durationLabel";
			durationLabel.Size = new System.Drawing.Size(48, 13);
			durationLabel.TabIndex = 24;
			durationLabel.Text = "Duration";
			// 
			// LabelLat
			// 
			LabelLat.AutoSize = true;
			LabelLat.Location = new System.Drawing.Point(87, 329);
			LabelLat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			LabelLat.Name = "LabelLat";
			LabelLat.Size = new System.Drawing.Size(50, 13);
			LabelLat.TabIndex = 275;
			LabelLat.Text = "Latitude:";
			// 
			// LabelLong
			// 
			LabelLong.AutoSize = true;
			LabelLong.Location = new System.Drawing.Point(87, 343);
			LabelLong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			LabelLong.Name = "LabelLong";
			LabelLong.Size = new System.Drawing.Size(58, 13);
			LabelLong.TabIndex = 274;
			LabelLong.Text = "Longitude:";
			// 
			// BindingSource
			// 
			this.BindingSource.DataSource = typeof(FlexModel.WAYPOINT);
			this.BindingSource.CurrentChanged += new System.EventHandler(this.BindingSource_CurrentChanged);
			// 
			// labelControl3
			// 
			this.labelControl3.Location = new System.Drawing.Point(18, 193);
			this.labelControl3.Name = "labelControl3";
			this.labelControl3.Size = new System.Drawing.Size(19, 13);
			this.labelControl3.TabIndex = 22;
			this.labelControl3.Text = "City";
			// 
			// TextEditTown
			// 
			this.TextEditTown.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Town", true));
			this.TextEditTown.EnterMoveNextControl = true;
			this.TextEditTown.Location = new System.Drawing.Point(81, 216);
			this.TextEditTown.Name = "TextEditTown";
			this.TextEditTown.Properties.MaxLength = 30;
			this.TextEditTown.Size = new System.Drawing.Size(241, 20);
			this.TextEditTown.TabIndex = 10;
			this.TextEditTown.Leave += new System.EventHandler(this.TextEditTown_Leave);
			// 
			// labelControl8
			// 
			this.labelControl8.Location = new System.Drawing.Point(18, 115);
			this.labelControl8.Name = "labelControl8";
			this.labelControl8.Size = new System.Drawing.Size(30, 13);
			this.labelControl8.TabIndex = 5;
			this.labelControl8.Text = "Street";
			// 
			// labelControl7
			// 
			this.labelControl7.Location = new System.Drawing.Point(18, 219);
			this.labelControl7.Name = "labelControl7";
			this.labelControl7.Size = new System.Drawing.Size(26, 13);
			this.labelControl7.TabIndex = 9;
			this.labelControl7.Text = "Town";
			// 
			// labelControl6
			// 
			this.labelControl6.Location = new System.Drawing.Point(18, 248);
			this.labelControl6.Name = "labelControl6";
			this.labelControl6.Size = new System.Drawing.Size(26, 13);
			this.labelControl6.TabIndex = 11;
			this.labelControl6.Text = "State";
			// 
			// labelControl5
			// 
			this.labelControl5.Location = new System.Drawing.Point(18, 272);
			this.labelControl5.Name = "labelControl5";
			this.labelControl5.Size = new System.Drawing.Size(14, 13);
			this.labelControl5.TabIndex = 13;
			this.labelControl5.Text = "Zip";
			// 
			// labelControl4
			// 
			this.labelControl4.Location = new System.Drawing.Point(18, 298);
			this.labelControl4.Name = "labelControl4";
			this.labelControl4.Size = new System.Drawing.Size(39, 13);
			this.labelControl4.TabIndex = 15;
			this.labelControl4.Text = "Country";
			// 
			// TextEditAddress1
			// 
			this.TextEditAddress1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "ADDRESS1", true));
			this.TextEditAddress1.EnterMoveNextControl = true;
			this.TextEditAddress1.Location = new System.Drawing.Point(81, 112);
			this.TextEditAddress1.Name = "TextEditAddress1";
			this.TextEditAddress1.Properties.MaxLength = 40;
			this.TextEditAddress1.Size = new System.Drawing.Size(241, 20);
			this.TextEditAddress1.TabIndex = 6;
			this.TextEditAddress1.Leave += new System.EventHandler(this.TextEditAddress1_Leave);
			// 
			// TextEditAddress2
			// 
			this.TextEditAddress2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "ADDRESS2", true));
			this.TextEditAddress2.EnterMoveNextControl = true;
			this.TextEditAddress2.Location = new System.Drawing.Point(81, 138);
			this.TextEditAddress2.Name = "TextEditAddress2";
			this.TextEditAddress2.Properties.MaxLength = 40;
			this.TextEditAddress2.Size = new System.Drawing.Size(241, 20);
			this.TextEditAddress2.TabIndex = 7;
			this.TextEditAddress2.Leave += new System.EventHandler(this.TextEditAddress2_Leave);
			// 
			// TextEditAddress3
			// 
			this.TextEditAddress3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "ADDRESS3", true));
			this.TextEditAddress3.EnterMoveNextControl = true;
			this.TextEditAddress3.Location = new System.Drawing.Point(81, 164);
			this.TextEditAddress3.Name = "TextEditAddress3";
			this.TextEditAddress3.Properties.MaxLength = 40;
			this.TextEditAddress3.Size = new System.Drawing.Size(241, 20);
			this.TextEditAddress3.TabIndex = 8;
			this.TextEditAddress3.Leave += new System.EventHandler(this.TextEditAddress3_Leave);
			// 
			// TextEditZip
			// 
			this.TextEditZip.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "ZIP", true));
			this.TextEditZip.EnterMoveNextControl = true;
			this.TextEditZip.Location = new System.Drawing.Point(81, 269);
			this.TextEditZip.Name = "TextEditZip";
			this.TextEditZip.Properties.MaxLength = 10;
			this.TextEditZip.Size = new System.Drawing.Size(100, 20);
			this.TextEditZip.TabIndex = 14;
			this.TextEditZip.Leave += new System.EventHandler(this.TextEditZip_Leave);
			// 
			// TextEditCode
			// 
			this.TextEditCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CODE", true));
			this.TextEditCode.EnterMoveNextControl = true;
			this.TextEditCode.Location = new System.Drawing.Point(81, 60);
			this.TextEditCode.Name = "TextEditCode";
			this.TextEditCode.Properties.MaxLength = 12;
			this.TextEditCode.Size = new System.Drawing.Size(100, 20);
			this.TextEditCode.TabIndex = 1;
			this.TextEditCode.Leave += new System.EventHandler(this.TextEditCode_Leave);
			// 
			// labelControl13
			// 
			this.labelControl13.Location = new System.Drawing.Point(18, 89);
			this.labelControl13.Name = "labelControl13";
			this.labelControl13.Size = new System.Drawing.Size(27, 13);
			this.labelControl13.TabIndex = 2;
			this.labelControl13.Text = "Name";
			// 
			// labelControl9
			// 
			this.labelControl9.Location = new System.Drawing.Point(18, 63);
			this.labelControl9.Name = "labelControl9";
			this.labelControl9.Size = new System.Drawing.Size(25, 13);
			this.labelControl9.TabIndex = 0;
			this.labelControl9.Text = "Code";
			// 
			// TextEditDesc
			// 
			this.TextEditDesc.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "DESC", true));
			this.TextEditDesc.EnterMoveNextControl = true;
			this.TextEditDesc.Location = new System.Drawing.Point(81, 86);
			this.TextEditDesc.Name = "TextEditDesc";
			this.TextEditDesc.Properties.MaxLength = 60;
			this.TextEditDesc.Size = new System.Drawing.Size(356, 20);
			this.TextEditDesc.TabIndex = 3;
			this.TextEditDesc.Leave += new System.EventHandler(this.TextEditDesc_Leave);
			// 
			// GridControlLookup
			// 
			this.GridControlLookup.DataSource = this.BindingSource;
			this.GridControlLookup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GridControlLookup.Location = new System.Drawing.Point(0, 0);
			this.GridControlLookup.MainView = this.GridViewLookup;
			this.GridControlLookup.Name = "GridControlLookup";
			this.GridControlLookup.Size = new System.Drawing.Size(190, 572);
			this.GridControlLookup.TabIndex = 0;
			this.GridControlLookup.TabStop = false;
			this.GridControlLookup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewLookup});
			// 
			// GridViewLookup
			// 
			this.GridViewLookup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GridColumnCode,
            this.GridColumnDesc,
            this.colADDRESS1,
            this.colADDRESS2,
            this.colADDRESS3,
            this.colCITY,
            this.colSTATE,
            this.colZIP,
            this.colCOUNTRY,
            this.colLATITUDE,
            this.colLONGITUDE,
            this.colTown,
            this.colGeoCode_ID,
            this.colProximitySearch,
            this.colProximitySearchDistance,
            this.colType,
            this.colDuration,
            this.colSearchable,
            this.colGeoCode,
            this.colRESITM,
            this.colRESITM1,
            this.colRelatedProduct,
            this.colRelatedProduct1,
            this.colDisplayName});
			this.GridViewLookup.GridControl = this.GridControlLookup;
			this.GridViewLookup.Name = "GridViewLookup";
			this.GridViewLookup.OptionsView.ShowAutoFilterRow = true;
			this.GridViewLookup.OptionsView.ShowGroupPanel = false;
			this.GridViewLookup.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.GridViewLookup_BeforeLeaveRow);
			// 
			// GridColumnCode
			// 
			this.GridColumnCode.FieldName = "CODE";
			this.GridColumnCode.Name = "GridColumnCode";
			this.GridColumnCode.Visible = true;
			this.GridColumnCode.VisibleIndex = 0;
			// 
			// GridColumnDesc
			// 
			this.GridColumnDesc.FieldName = "DESC";
			this.GridColumnDesc.Name = "GridColumnDesc";
			this.GridColumnDesc.Visible = true;
			this.GridColumnDesc.VisibleIndex = 1;
			// 
			// colADDRESS1
			// 
			this.colADDRESS1.FieldName = "ADDRESS1";
			this.colADDRESS1.Name = "colADDRESS1";
			// 
			// colADDRESS2
			// 
			this.colADDRESS2.FieldName = "ADDRESS2";
			this.colADDRESS2.Name = "colADDRESS2";
			// 
			// colADDRESS3
			// 
			this.colADDRESS3.FieldName = "ADDRESS3";
			this.colADDRESS3.Name = "colADDRESS3";
			// 
			// colCITY
			// 
			this.colCITY.FieldName = "CITY";
			this.colCITY.Name = "colCITY";
			// 
			// colSTATE
			// 
			this.colSTATE.FieldName = "STATE";
			this.colSTATE.Name = "colSTATE";
			// 
			// colZIP
			// 
			this.colZIP.FieldName = "ZIP";
			this.colZIP.Name = "colZIP";
			// 
			// colCOUNTRY
			// 
			this.colCOUNTRY.FieldName = "COUNTRY";
			this.colCOUNTRY.Name = "colCOUNTRY";
			// 
			// colLATITUDE
			// 
			this.colLATITUDE.FieldName = "LATITUDE";
			this.colLATITUDE.Name = "colLATITUDE";
			// 
			// colLONGITUDE
			// 
			this.colLONGITUDE.FieldName = "LONGITUDE";
			this.colLONGITUDE.Name = "colLONGITUDE";
			// 
			// colTown
			// 
			this.colTown.FieldName = "Town";
			this.colTown.Name = "colTown";
			// 
			// colGeoCode_ID
			// 
			this.colGeoCode_ID.FieldName = "GeoCode_ID";
			this.colGeoCode_ID.Name = "colGeoCode_ID";
			// 
			// colProximitySearch
			// 
			this.colProximitySearch.FieldName = "ProximitySearch";
			this.colProximitySearch.Name = "colProximitySearch";
			// 
			// colProximitySearchDistance
			// 
			this.colProximitySearchDistance.FieldName = "ProximitySearchDistance";
			this.colProximitySearchDistance.Name = "colProximitySearchDistance";
			// 
			// colType
			// 
			this.colType.FieldName = "Type";
			this.colType.Name = "colType";
			// 
			// colDuration
			// 
			this.colDuration.FieldName = "Duration";
			this.colDuration.Name = "colDuration";
			// 
			// colSearchable
			// 
			this.colSearchable.FieldName = "Searchable";
			this.colSearchable.Name = "colSearchable";
			// 
			// colGeoCode
			// 
			this.colGeoCode.FieldName = "GeoCode";
			this.colGeoCode.Name = "colGeoCode";
			// 
			// colRESITM
			// 
			this.colRESITM.FieldName = "RESITM";
			this.colRESITM.Name = "colRESITM";
			// 
			// colRESITM1
			// 
			this.colRESITM1.FieldName = "RESITM1";
			this.colRESITM1.Name = "colRESITM1";
			// 
			// colRelatedProduct
			// 
			this.colRelatedProduct.FieldName = "RelatedProduct";
			this.colRelatedProduct.Name = "colRelatedProduct";
			// 
			// colRelatedProduct1
			// 
			this.colRelatedProduct1.FieldName = "RelatedProduct1";
			this.colRelatedProduct1.Name = "colRelatedProduct1";
			// 
			// colDisplayName
			// 
			this.colDisplayName.FieldName = "DisplayName";
			this.colDisplayName.Name = "colDisplayName";
			this.colDisplayName.OptionsColumn.ReadOnly = true;
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
			this.SplitContainerControl.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
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
			this.SplitContainerControl.Size = new System.Drawing.Size(1020, 572);
			this.SplitContainerControl.SplitterPosition = 190;
			this.SplitContainerControl.TabIndex = 0;
			this.SplitContainerControl.Text = "splitContainerControl1";
			// 
			// LabelControlLon
			// 
			this.LabelControlLon.Location = new System.Drawing.Point(158, 343);
			this.LabelControlLon.Margin = new System.Windows.Forms.Padding(2);
			this.LabelControlLon.Name = "LabelControlLon";
			this.LabelControlLon.Size = new System.Drawing.Size(0, 13);
			this.LabelControlLon.TabIndex = 278;
			// 
			// LabelControlLat
			// 
			this.LabelControlLat.Location = new System.Drawing.Point(158, 328);
			this.LabelControlLat.Margin = new System.Windows.Forms.Padding(2);
			this.LabelControlLat.Name = "LabelControlLat";
			this.LabelControlLat.Size = new System.Drawing.Size(0, 13);
			this.LabelControlLat.TabIndex = 277;
			// 
			// SimpleButtonPlot
			// 
			this.SimpleButtonPlot.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("SimpleButtonPlot.ImageOptions.Image")));
			this.SimpleButtonPlot.Location = new System.Drawing.Point(18, 324);
			this.SimpleButtonPlot.Margin = new System.Windows.Forms.Padding(2);
			this.SimpleButtonPlot.Name = "SimpleButtonPlot";
			this.SimpleButtonPlot.Size = new System.Drawing.Size(66, 38);
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
			this.MapControl.Location = new System.Drawing.Point(359, 115);
			this.MapControl.Margin = new System.Windows.Forms.Padding(2);
			this.MapControl.Name = "MapControl";
			this.MapControl.ShowSearchPanel = false;
			this.MapControl.Size = new System.Drawing.Size(397, 252);
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
			this.checkEditSearchable.Location = new System.Drawing.Point(18, 430);
			this.checkEditSearchable.Margin = new System.Windows.Forms.Padding(2);
			this.checkEditSearchable.Name = "checkEditSearchable";
			this.checkEditSearchable.Properties.Caption = "Searchable";
			this.checkEditSearchable.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.checkEditSearchable.Size = new System.Drawing.Size(84, 19);
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
			this.SpinEditDuration.Location = new System.Drawing.Point(82, 454);
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
			this.SpinEditDuration.TabIndex = 25;
			this.SpinEditDuration.Leave += new System.EventHandler(this.SpinEditDurationEdit_Leave);
			// 
			// labelControl14
			// 
			this.labelControl14.Location = new System.Drawing.Point(18, 398);
			this.labelControl14.Margin = new System.Windows.Forms.Padding(2);
			this.labelControl14.Name = "labelControl14";
			this.labelControl14.Size = new System.Drawing.Size(181, 13);
			this.labelControl14.TabIndex = 19;
			this.labelControl14.Text = "Distance to search from this item (km)";
			// 
			// CheckEditProximitySearch
			// 
			this.CheckEditProximitySearch.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "ProximitySearch", true));
			this.CheckEditProximitySearch.Location = new System.Drawing.Point(18, 371);
			this.CheckEditProximitySearch.Margin = new System.Windows.Forms.Padding(2);
			this.CheckEditProximitySearch.Name = "CheckEditProximitySearch";
			this.CheckEditProximitySearch.Properties.Caption = "Enable proximity search for this item on a map";
			this.CheckEditProximitySearch.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.CheckEditProximitySearch.Size = new System.Drawing.Size(259, 19);
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
			this.SpinEditDistance.Location = new System.Drawing.Point(210, 396);
			this.SpinEditDistance.Margin = new System.Windows.Forms.Padding(2);
			this.SpinEditDistance.Name = "SpinEditDistance";
			this.SpinEditDistance.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.SpinEditDistance.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.SpinEditDistance.Size = new System.Drawing.Size(67, 20);
			this.SpinEditDistance.TabIndex = 20;
			this.SpinEditDistance.Leave += new System.EventHandler(this.SpinEditDistance_Leave);
			// 
			// SearchLookupEditState
			// 
			this.SearchLookupEditState.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "STATE", true));
			this.SearchLookupEditState.Location = new System.Drawing.Point(81, 241);
			this.SearchLookupEditState.Name = "SearchLookupEditState";
			this.SearchLookupEditState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.SearchLookupEditState.Properties.DataSource = this.BindingSourceCodeName;
			this.SearchLookupEditState.Properties.DisplayMember = "DisplayName";
			this.SearchLookupEditState.Properties.NullText = "";
			this.SearchLookupEditState.Properties.PopupSizeable = false;
			this.SearchLookupEditState.Properties.ValueMember = "Code";
			this.SearchLookupEditState.Properties.View = this.customSearchLookUpEdit1View;
			this.SearchLookupEditState.Size = new System.Drawing.Size(241, 20);
			this.SearchLookupEditState.TabIndex = 12;
			this.SearchLookupEditState.UpdateDisplayFilter += new Custom_SearchLookupEdit.UpdateDisplayFilterHandler(this.SearchLookupEdit_UpdateDisplayFilter);
			this.SearchLookupEditState.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
			this.SearchLookupEditState.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.SearchLookupEditState_Closed);
			this.SearchLookupEditState.Leave += new System.EventHandler(this.SearchLookupEditState_Leave);
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
			// SearchLookupEditCountry
			// 
			this.SearchLookupEditCountry.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "COUNTRY", true));
			this.SearchLookupEditCountry.Location = new System.Drawing.Point(81, 295);
			this.SearchLookupEditCountry.Name = "SearchLookupEditCountry";
			this.SearchLookupEditCountry.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.SearchLookupEditCountry.Properties.DataSource = this.BindingSourceCodeName;
			this.SearchLookupEditCountry.Properties.DisplayMember = "DisplayName";
			this.SearchLookupEditCountry.Properties.NullText = "";
			this.SearchLookupEditCountry.Properties.PopupSizeable = false;
			this.SearchLookupEditCountry.Properties.ValueMember = "Code";
			this.SearchLookupEditCountry.Properties.View = this.gridView1;
			this.SearchLookupEditCountry.Size = new System.Drawing.Size(241, 20);
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
			// SearchLookupEditCity
			// 
			this.SearchLookupEditCity.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CITY", true));
			this.SearchLookupEditCity.Location = new System.Drawing.Point(81, 190);
			this.SearchLookupEditCity.Name = "SearchLookupEditCity";
			this.SearchLookupEditCity.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
			this.SearchLookupEditCity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.SearchLookupEditCity.Properties.DataSource = this.BindingSourceCodeName;
			this.SearchLookupEditCity.Properties.DisplayMember = "DisplayName";
			this.SearchLookupEditCity.Properties.NullText = "";
			this.SearchLookupEditCity.Properties.PopupSizeable = false;
			this.SearchLookupEditCity.Properties.ValueMember = "Code";
			this.SearchLookupEditCity.Properties.View = this.gridView2;
			this.SearchLookupEditCity.Size = new System.Drawing.Size(241, 20);
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
			// PanelControlStatus
			// 
			this.PanelControlStatus.Appearance.Options.UseTextOptions = true;
			this.PanelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("PanelControlStatus.ContentImage")));
			this.PanelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			this.PanelControlStatus.Controls.Add(this.LabelStatus);
			this.PanelControlStatus.Location = new System.Drawing.Point(308, 2);
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
			this.barDockControlTop.Size = new System.Drawing.Size(1020, 31);
			// 
			// barDockControlBottom
			// 
			this.barDockControlBottom.CausesValidation = false;
			this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.barDockControlBottom.Location = new System.Drawing.Point(0, 603);
			this.barDockControlBottom.Manager = this.BarManager;
			this.barDockControlBottom.Size = new System.Drawing.Size(1020, 0);
			// 
			// barDockControlLeft
			// 
			this.barDockControlLeft.CausesValidation = false;
			this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
			this.barDockControlLeft.Manager = this.BarManager;
			this.barDockControlLeft.Size = new System.Drawing.Size(0, 572);
			// 
			// barDockControlRight
			// 
			this.barDockControlRight.CausesValidation = false;
			this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.barDockControlRight.Location = new System.Drawing.Point(1020, 31);
			this.barDockControlRight.Manager = this.BarManager;
			this.barDockControlRight.Size = new System.Drawing.Size(0, 572);
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
			// BindingSourceCodeName
			// 
			this.BindingSourceCodeName.DataSource = typeof(TraceForms.CodeName);
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
			// WaypointForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1020, 603);
			this.Controls.Add(this.PanelControlStatus);
			this.Controls.Add(this.SplitContainerControl);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.KeyPreview = true;
			this.MinimizeBox = false;
			this.Name = "WaypointForm";
			this.ShowInTaskbar = false;
			this.Text = "Waypoints";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WAYPOINTForm_FormClosing);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WaypointForm_KeyDown);
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
			((System.ComponentModel.ISupportInitialize)(this.MapControl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEditSearchable.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SpinEditDuration.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CheckEditProximitySearch.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SpinEditDistance.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditState.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.customSearchLookUpEdit1View)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditCountry.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditCity.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PanelControlStatus)).EndInit();
			this.PanelControlStatus.ResumeLayout(false);
			this.PanelControlStatus.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BindingSourceCodeName)).EndInit();
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
		private DevExpress.XtraGrid.Columns.GridColumn colADDRESS1;
		private DevExpress.XtraGrid.Columns.GridColumn colADDRESS2;
		private DevExpress.XtraGrid.Columns.GridColumn colADDRESS3;
		private DevExpress.XtraGrid.Columns.GridColumn colCITY;
		private DevExpress.XtraGrid.Columns.GridColumn colSTATE;
		private DevExpress.XtraGrid.Columns.GridColumn colZIP;
		private DevExpress.XtraGrid.Columns.GridColumn colCOUNTRY;
		private DevExpress.XtraGrid.Columns.GridColumn colLATITUDE;
		private DevExpress.XtraGrid.Columns.GridColumn colLONGITUDE;
		private DevExpress.XtraGrid.Columns.GridColumn colTown;
		private DevExpress.XtraGrid.Columns.GridColumn colGeoCode_ID;
		private DevExpress.XtraGrid.Columns.GridColumn colProximitySearch;
		private DevExpress.XtraGrid.Columns.GridColumn colProximitySearchDistance;
		private DevExpress.XtraGrid.Columns.GridColumn colType;
		private DevExpress.XtraGrid.Columns.GridColumn colDuration;
		private DevExpress.XtraGrid.Columns.GridColumn colSearchable;
		private DevExpress.XtraGrid.Columns.GridColumn colGeoCode;
		private DevExpress.XtraGrid.Columns.GridColumn colRESITM;
		private DevExpress.XtraGrid.Columns.GridColumn colRESITM1;
		private DevExpress.XtraGrid.Columns.GridColumn colRelatedProduct;
		private DevExpress.XtraGrid.Columns.GridColumn colRelatedProduct1;
		private DevExpress.XtraGrid.Columns.GridColumn colDisplayName;
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
	}
}