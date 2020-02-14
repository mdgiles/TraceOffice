namespace TraceForms
{
    partial class ImportFareHarbor
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
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportFareHarbor));
            this.gridViewCustomers = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSelected1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEditSelected = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colDisplay_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFromAge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEditAge = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colToAge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaxType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBoxPaxType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridControlItems = new DevExpress.XtraGrid.GridControl();
            this.bindingSourceItems = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEditName = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colInternalCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEditCode = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colPk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.imageComboBoxEditCompanies = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.simpleButtonImport = new DevExpress.XtraEditors.SimpleButton();
            this.searchLookUpEditCity = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.bindingSourceCodeName = new System.Windows.Forms.BindingSource(this.components);
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.searchLookUpEditServiceType = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.spinEditCommPct = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.spinEditCommFlat = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.spinEditMarkupFlat = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.spinEditMarkupPct = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEditAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxPaxType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEditCompanies.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEditCity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCodeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEditServiceType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditCommPct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditCommFlat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditMarkupFlat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditMarkupPct.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridViewCustomers
            // 
            this.gridViewCustomers.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSelected1,
            this.colDisplay_name,
            this.colNote,
            this.colFromAge,
            this.colToAge,
            this.colPaxType});
            this.gridViewCustomers.GridControl = this.gridControlItems;
            this.gridViewCustomers.Name = "gridViewCustomers";
            this.gridViewCustomers.OptionsView.ShowGroupPanel = false;
            this.gridViewCustomers.OptionsView.ShowIndicator = false;
            this.gridViewCustomers.ViewCaption = "Customer Types";
            // 
            // colSelected1
            // 
            this.colSelected1.ColumnEdit = this.repositoryItemCheckEditSelected;
            this.colSelected1.FieldName = "Selected";
            this.colSelected1.Name = "colSelected1";
            this.colSelected1.Visible = true;
            this.colSelected1.VisibleIndex = 0;
            this.colSelected1.Width = 132;
            // 
            // repositoryItemCheckEditSelected
            // 
            this.repositoryItemCheckEditSelected.AutoHeight = false;
            this.repositoryItemCheckEditSelected.Name = "repositoryItemCheckEditSelected";
            // 
            // colDisplay_name
            // 
            this.colDisplay_name.Caption = "Name";
            this.colDisplay_name.FieldName = "Display_name";
            this.colDisplay_name.Name = "colDisplay_name";
            this.colDisplay_name.OptionsColumn.AllowEdit = false;
            this.colDisplay_name.OptionsColumn.ReadOnly = true;
            this.colDisplay_name.Visible = true;
            this.colDisplay_name.VisibleIndex = 1;
            this.colDisplay_name.Width = 290;
            // 
            // colNote
            // 
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            this.colNote.OptionsColumn.AllowEdit = false;
            this.colNote.OptionsColumn.ReadOnly = true;
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 2;
            this.colNote.Width = 476;
            // 
            // colFromAge
            // 
            this.colFromAge.ColumnEdit = this.repositoryItemSpinEditAge;
            this.colFromAge.FieldName = "FromAge";
            this.colFromAge.Name = "colFromAge";
            this.colFromAge.Visible = true;
            this.colFromAge.VisibleIndex = 3;
            this.colFromAge.Width = 119;
            // 
            // repositoryItemSpinEditAge
            // 
            this.repositoryItemSpinEditAge.AutoHeight = false;
            this.repositoryItemSpinEditAge.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEditAge.MaxValue = new decimal(new int[] {
            17,
            0,
            0,
            0});
            this.repositoryItemSpinEditAge.Name = "repositoryItemSpinEditAge";
            // 
            // colToAge
            // 
            this.colToAge.ColumnEdit = this.repositoryItemSpinEditAge;
            this.colToAge.FieldName = "ToAge";
            this.colToAge.Name = "colToAge";
            this.colToAge.Visible = true;
            this.colToAge.VisibleIndex = 4;
            this.colToAge.Width = 90;
            // 
            // colPaxType
            // 
            this.colPaxType.Caption = "Type";
            this.colPaxType.ColumnEdit = this.repositoryItemComboBoxPaxType;
            this.colPaxType.FieldName = "PaxType";
            this.colPaxType.Name = "colPaxType";
            this.colPaxType.Visible = true;
            this.colPaxType.VisibleIndex = 5;
            this.colPaxType.Width = 259;
            // 
            // repositoryItemComboBoxPaxType
            // 
            this.repositoryItemComboBoxPaxType.AutoHeight = false;
            this.repositoryItemComboBoxPaxType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBoxPaxType.ImmediatePopup = true;
            this.repositoryItemComboBoxPaxType.Items.AddRange(new object[] {
            "Infant",
            "Child",
            "Junior",
            "Adult",
            "Senior"});
            this.repositoryItemComboBoxPaxType.Name = "repositoryItemComboBoxPaxType";
            this.repositoryItemComboBoxPaxType.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // gridControlItems
            // 
            this.gridControlItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlItems.DataSource = this.bindingSourceItems;
            gridLevelNode1.LevelTemplate = this.gridViewCustomers;
            gridLevelNode1.RelationName = "Customer_prototypes";
            this.gridControlItems.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControlItems.Location = new System.Drawing.Point(106, 50);
            this.gridControlItems.MainView = this.gridViewItems;
            this.gridControlItems.Name = "gridControlItems";
            this.gridControlItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEditCode,
            this.repositoryItemTextEditName,
            this.repositoryItemCheckEditSelected,
            this.repositoryItemSpinEditAge,
            this.repositoryItemComboBoxPaxType});
            this.gridControlItems.ShowOnlyPredefinedDetails = true;
            this.gridControlItems.Size = new System.Drawing.Size(598, 273);
            this.gridControlItems.TabIndex = 3;
            this.gridControlItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewItems,
            this.gridViewCustomers});
            // 
            // bindingSourceItems
            // 
            this.bindingSourceItems.DataSource = typeof(TraceForms.Models.FareHarbor.Item);
            // 
            // gridViewItems
            // 
            this.gridViewItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSelected,
            this.colName,
            this.colInternalCode,
            this.colPk});
            this.gridViewItems.GridControl = this.gridControlItems;
            this.gridViewItems.Name = "gridViewItems";
            this.gridViewItems.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridViewItems.OptionsView.ShowGroupPanel = false;
            this.gridViewItems.OptionsView.ShowIndicator = false;
            // 
            // colSelected
            // 
            this.colSelected.Caption = "Selected";
            this.colSelected.ColumnEdit = this.repositoryItemCheckEditSelected;
            this.colSelected.FieldName = "Selected";
            this.colSelected.Name = "colSelected";
            this.colSelected.Visible = true;
            this.colSelected.VisibleIndex = 0;
            this.colSelected.Width = 143;
            // 
            // colName
            // 
            this.colName.Caption = "Product";
            this.colName.ColumnEdit = this.repositoryItemTextEditName;
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            this.colName.Width = 977;
            // 
            // repositoryItemTextEditName
            // 
            this.repositoryItemTextEditName.AutoHeight = false;
            this.repositoryItemTextEditName.MaxLength = 60;
            this.repositoryItemTextEditName.Name = "repositoryItemTextEditName";
            // 
            // colInternalCode
            // 
            this.colInternalCode.Caption = "TourTrace Code";
            this.colInternalCode.ColumnEdit = this.repositoryItemTextEditCode;
            this.colInternalCode.FieldName = "InternalCode";
            this.colInternalCode.Name = "colInternalCode";
            this.colInternalCode.Visible = true;
            this.colInternalCode.VisibleIndex = 1;
            this.colInternalCode.Width = 246;
            // 
            // repositoryItemTextEditCode
            // 
            this.repositoryItemTextEditCode.AutoHeight = false;
            this.repositoryItemTextEditCode.MaxLength = 32;
            this.repositoryItemTextEditCode.Name = "repositoryItemTextEditCode";
            // 
            // colPk
            // 
            this.colPk.FieldName = "Pk";
            this.colPk.Name = "colPk";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(31, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Company";
            // 
            // imageComboBoxEditCompanies
            // 
            this.imageComboBoxEditCompanies.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageComboBoxEditCompanies.Location = new System.Drawing.Point(106, 24);
            this.imageComboBoxEditCompanies.Name = "imageComboBoxEditCompanies";
            this.imageComboBoxEditCompanies.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.imageComboBoxEditCompanies.Size = new System.Drawing.Size(410, 20);
            this.imageComboBoxEditCompanies.TabIndex = 2;
            this.imageComboBoxEditCompanies.EditValueChanged += new System.EventHandler(this.imageComboBoxEditCompanies_EditValueChanged);
            // 
            // simpleButtonImport
            // 
            this.simpleButtonImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButtonImport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButtonImport.ImageOptions.SvgImage")));
            this.simpleButtonImport.Location = new System.Drawing.Point(106, 441);
            this.simpleButtonImport.Margin = new System.Windows.Forms.Padding(2);
            this.simpleButtonImport.Name = "simpleButtonImport";
            this.simpleButtonImport.Size = new System.Drawing.Size(112, 40);
            this.simpleButtonImport.TabIndex = 4;
            this.simpleButtonImport.Text = "&Import";
            this.simpleButtonImport.Click += new System.EventHandler(this.simpleButtonImport_Click);
            // 
            // searchLookUpEditCity
            // 
            this.searchLookUpEditCity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchLookUpEditCity.Location = new System.Drawing.Point(106, 329);
            this.searchLookUpEditCity.Name = "searchLookUpEditCity";
            this.searchLookUpEditCity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpEditCity.Properties.DataSource = this.bindingSourceCodeName;
            this.searchLookUpEditCity.Properties.DisplayMember = "DisplayName";
            this.searchLookUpEditCity.Properties.NullText = "";
            this.searchLookUpEditCity.Properties.PopupView = this.searchLookUpEdit1View;
            this.searchLookUpEditCity.Properties.ValueMember = "Code";
            this.searchLookUpEditCity.Size = new System.Drawing.Size(404, 20);
            this.searchLookUpEditCity.TabIndex = 5;
            this.searchLookUpEditCity.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            // 
            // bindingSourceCodeName
            // 
            this.bindingSourceCodeName.DataSource = typeof(TraceForms.CodeName);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colName1});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.searchLookUpEdit1View.OptionsView.ShowIndicator = false;
            // 
            // colCode
            // 
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            // 
            // colName1
            // 
            this.colName1.FieldName = "Name";
            this.colName1.Name = "colName1";
            this.colName1.Visible = true;
            this.colName1.VisibleIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(31, 50);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(42, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Products";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl3.Location = new System.Drawing.Point(31, 332);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(19, 13);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "City";
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl4.Location = new System.Drawing.Point(31, 358);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(62, 13);
            this.labelControl4.TabIndex = 9;
            this.labelControl4.Text = "Service Type";
            // 
            // searchLookUpEditServiceType
            // 
            this.searchLookUpEditServiceType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchLookUpEditServiceType.Location = new System.Drawing.Point(106, 355);
            this.searchLookUpEditServiceType.Name = "searchLookUpEditServiceType";
            this.searchLookUpEditServiceType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpEditServiceType.Properties.DataSource = this.bindingSourceCodeName;
            this.searchLookUpEditServiceType.Properties.DisplayMember = "DisplayName";
            this.searchLookUpEditServiceType.Properties.NullText = "";
            this.searchLookUpEditServiceType.Properties.PopupView = this.gridView2;
            this.searchLookUpEditServiceType.Properties.ValueMember = "Code";
            this.searchLookUpEditServiceType.Size = new System.Drawing.Size(404, 20);
            this.searchLookUpEditServiceType.TabIndex = 8;
            this.searchLookUpEditServiceType.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode1,
            this.colName2});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
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
            // marqueeProgressBarControl1
            // 
            this.marqueeProgressBarControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.marqueeProgressBarControl1.EditValue = "Importing...";
            this.marqueeProgressBarControl1.Location = new System.Drawing.Point(222, 450);
            this.marqueeProgressBarControl1.Margin = new System.Windows.Forms.Padding(2);
            this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
            this.marqueeProgressBarControl1.Properties.ProgressAnimationMode = DevExpress.Utils.Drawing.ProgressAnimationMode.Cycle;
            this.marqueeProgressBarControl1.Properties.ShowTitle = true;
            this.marqueeProgressBarControl1.Size = new System.Drawing.Size(482, 18);
            this.marqueeProgressBarControl1.TabIndex = 15;
            this.marqueeProgressBarControl1.Visible = false;
            // 
            // spinEditCommPct
            // 
            this.spinEditCommPct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.spinEditCommPct.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditCommPct.Location = new System.Drawing.Point(106, 381);
            this.spinEditCommPct.Name = "spinEditCommPct";
            this.spinEditCommPct.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditCommPct.Size = new System.Drawing.Size(96, 20);
            this.spinEditCommPct.TabIndex = 16;
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl5.Location = new System.Drawing.Point(31, 384);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(69, 13);
            this.labelControl5.TabIndex = 17;
            this.labelControl5.Text = "Commission %";
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl6.Location = new System.Drawing.Point(229, 384);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(76, 13);
            this.labelControl6.TabIndex = 19;
            this.labelControl6.Text = "Commission Flat";
            // 
            // spinEditCommFlat
            // 
            this.spinEditCommFlat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.spinEditCommFlat.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditCommFlat.Location = new System.Drawing.Point(311, 381);
            this.spinEditCommFlat.Name = "spinEditCommFlat";
            this.spinEditCommFlat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditCommFlat.Size = new System.Drawing.Size(96, 20);
            this.spinEditCommFlat.TabIndex = 18;
            // 
            // labelControl7
            // 
            this.labelControl7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl7.Location = new System.Drawing.Point(413, 384);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(289, 13);
            this.labelControl7.TabIndex = 20;
            this.labelControl7.Text = "<= These are subtracted from retail to arrive at buying cost";
            // 
            // labelControl8
            // 
            this.labelControl8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl8.Location = new System.Drawing.Point(229, 410);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(56, 13);
            this.labelControl8.TabIndex = 24;
            this.labelControl8.Text = "Markup Flat";
            // 
            // spinEditMarkupFlat
            // 
            this.spinEditMarkupFlat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.spinEditMarkupFlat.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditMarkupFlat.Location = new System.Drawing.Point(311, 407);
            this.spinEditMarkupFlat.Name = "spinEditMarkupFlat";
            this.spinEditMarkupFlat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditMarkupFlat.Size = new System.Drawing.Size(96, 20);
            this.spinEditMarkupFlat.TabIndex = 23;
            // 
            // labelControl9
            // 
            this.labelControl9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl9.Location = new System.Drawing.Point(31, 410);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(49, 13);
            this.labelControl9.TabIndex = 22;
            this.labelControl9.Text = "Markup %";
            // 
            // spinEditMarkupPct
            // 
            this.spinEditMarkupPct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.spinEditMarkupPct.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditMarkupPct.Location = new System.Drawing.Point(106, 407);
            this.spinEditMarkupPct.Name = "spinEditMarkupPct";
            this.spinEditMarkupPct.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditMarkupPct.Size = new System.Drawing.Size(96, 20);
            this.spinEditMarkupPct.TabIndex = 21;
            // 
            // labelControl10
            // 
            this.labelControl10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl10.Location = new System.Drawing.Point(413, 410);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(275, 13);
            this.labelControl10.TabIndex = 25;
            this.labelControl10.Text = "<= These are added to buying cost to arrive at B2B price";
            // 
            // ImportFareHarbor
            // 
            this.ClientSize = new System.Drawing.Size(733, 502);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.spinEditMarkupFlat);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.spinEditMarkupPct);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.spinEditCommFlat);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.spinEditCommPct);
            this.Controls.Add(this.marqueeProgressBarControl1);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.searchLookUpEditServiceType);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.searchLookUpEditCity);
            this.Controls.Add(this.simpleButtonImport);
            this.Controls.Add(this.gridControlItems);
            this.Controls.Add(this.imageComboBoxEditCompanies);
            this.Controls.Add(this.labelControl1);
            this.Name = "ImportFareHarbor";
            this.Text = "Import Products From FareHarbor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImportFareHarbor_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEditAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxPaxType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEditCompanies.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEditCity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCodeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEditServiceType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditCommPct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditCommFlat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditMarkupFlat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditMarkupPct.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ImageComboBoxEdit imageComboBoxEditCompanies;
        private DevExpress.XtraGrid.GridControl gridControlItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewItems;
        private System.Windows.Forms.BindingSource bindingSourceItems;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditName;
        private DevExpress.XtraGrid.Columns.GridColumn colInternalCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPk;
        private DevExpress.XtraGrid.Columns.GridColumn colSelected;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEditSelected;
        private DevExpress.XtraEditors.SimpleButton simpleButtonImport;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpEditCity;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpEditServiceType;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Windows.Forms.BindingSource bindingSourceCodeName;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName1;
        private DevExpress.XtraGrid.Columns.GridColumn colCode1;
        private DevExpress.XtraGrid.Columns.GridColumn colName2;
        private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl1;
        private DevExpress.XtraEditors.SpinEdit spinEditCommPct;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SpinEdit spinEditCommFlat;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCustomers;
        private DevExpress.XtraGrid.Columns.GridColumn colSelected1;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplay_name;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraGrid.Columns.GridColumn colFromAge;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEditAge;
        private DevExpress.XtraGrid.Columns.GridColumn colToAge;
        private DevExpress.XtraGrid.Columns.GridColumn colPaxType;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxPaxType;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.SpinEdit spinEditMarkupFlat;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.SpinEdit spinEditMarkupPct;
        private DevExpress.XtraEditors.LabelControl labelControl10;
    }
}