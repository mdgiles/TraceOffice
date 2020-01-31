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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportFareHarbor));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.imageComboBoxEditCompanies = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.gridControlItems = new DevExpress.XtraGrid.GridControl();
            this.bindingSourceItems = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEditSelected = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEditName = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colInternalCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEditCode = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colPk = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEditCompanies.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEditCity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCodeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEditServiceType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditCommPct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditCommFlat.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.imageComboBoxEditCompanies.Size = new System.Drawing.Size(356, 20);
            this.imageComboBoxEditCompanies.TabIndex = 2;
            this.imageComboBoxEditCompanies.EditValueChanged += new System.EventHandler(this.imageComboBoxEditCompanies_EditValueChanged);
            // 
            // gridControlItems
            // 
            this.gridControlItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlItems.DataSource = this.bindingSourceItems;
            this.gridControlItems.Location = new System.Drawing.Point(106, 50);
            this.gridControlItems.MainView = this.gridView1;
            this.gridControlItems.Name = "gridControlItems";
            this.gridControlItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEditCode,
            this.repositoryItemTextEditName,
            this.repositoryItemCheckEditSelected});
            this.gridControlItems.ShowOnlyPredefinedDetails = true;
            this.gridControlItems.Size = new System.Drawing.Size(544, 263);
            this.gridControlItems.TabIndex = 3;
            this.gridControlItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // bindingSourceItems
            // 
            this.bindingSourceItems.DataSource = typeof(TraceForms.Models.FareHarbor.Item);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSelected,
            this.colName,
            this.colInternalCode,
            this.colPk});
            this.gridView1.GridControl = this.gridControlItems;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
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
            // repositoryItemCheckEditSelected
            // 
            this.repositoryItemCheckEditSelected.AutoHeight = false;
            this.repositoryItemCheckEditSelected.Name = "repositoryItemCheckEditSelected";
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
            // simpleButtonImport
            // 
            this.simpleButtonImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButtonImport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButtonImport.ImageOptions.SvgImage")));
            this.simpleButtonImport.Location = new System.Drawing.Point(106, 399);
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
            this.searchLookUpEditCity.Location = new System.Drawing.Point(106, 319);
            this.searchLookUpEditCity.Name = "searchLookUpEditCity";
            this.searchLookUpEditCity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpEditCity.Properties.DataSource = this.bindingSourceCodeName;
            this.searchLookUpEditCity.Properties.DisplayMember = "DisplayName";
            this.searchLookUpEditCity.Properties.NullText = "";
            this.searchLookUpEditCity.Properties.PopupView = this.searchLookUpEdit1View;
            this.searchLookUpEditCity.Properties.ValueMember = "Code";
            this.searchLookUpEditCity.Size = new System.Drawing.Size(350, 20);
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
            this.labelControl3.Location = new System.Drawing.Point(31, 322);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(19, 13);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "City";
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl4.Location = new System.Drawing.Point(31, 348);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(62, 13);
            this.labelControl4.TabIndex = 9;
            this.labelControl4.Text = "Service Type";
            // 
            // searchLookUpEditServiceType
            // 
            this.searchLookUpEditServiceType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchLookUpEditServiceType.Location = new System.Drawing.Point(106, 345);
            this.searchLookUpEditServiceType.Name = "searchLookUpEditServiceType";
            this.searchLookUpEditServiceType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpEditServiceType.Properties.DataSource = this.bindingSourceCodeName;
            this.searchLookUpEditServiceType.Properties.DisplayMember = "DisplayName";
            this.searchLookUpEditServiceType.Properties.NullText = "";
            this.searchLookUpEditServiceType.Properties.PopupView = this.gridView2;
            this.searchLookUpEditServiceType.Properties.ValueMember = "Code";
            this.searchLookUpEditServiceType.Size = new System.Drawing.Size(350, 20);
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
            this.marqueeProgressBarControl1.Location = new System.Drawing.Point(222, 408);
            this.marqueeProgressBarControl1.Margin = new System.Windows.Forms.Padding(2);
            this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
            this.marqueeProgressBarControl1.Properties.ProgressAnimationMode = DevExpress.Utils.Drawing.ProgressAnimationMode.Cycle;
            this.marqueeProgressBarControl1.Properties.ShowTitle = true;
            this.marqueeProgressBarControl1.Size = new System.Drawing.Size(428, 18);
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
            this.spinEditCommPct.Location = new System.Drawing.Point(106, 371);
            this.spinEditCommPct.Name = "spinEditCommPct";
            this.spinEditCommPct.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditCommPct.Size = new System.Drawing.Size(96, 20);
            this.spinEditCommPct.TabIndex = 16;
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl5.Location = new System.Drawing.Point(31, 374);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(69, 13);
            this.labelControl5.TabIndex = 17;
            this.labelControl5.Text = "Commission %";
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl6.Location = new System.Drawing.Point(229, 374);
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
            this.spinEditCommFlat.Location = new System.Drawing.Point(311, 371);
            this.spinEditCommFlat.Name = "spinEditCommFlat";
            this.spinEditCommFlat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditCommFlat.Size = new System.Drawing.Size(96, 20);
            this.spinEditCommFlat.TabIndex = 18;
            // 
            // ImportFareHarbor
            // 
            this.ClientSize = new System.Drawing.Size(679, 450);
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
            ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEditCompanies.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEditCity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCodeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEditServiceType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditCommPct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditCommFlat.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ImageComboBoxEdit imageComboBoxEditCompanies;
        private DevExpress.XtraGrid.GridControl gridControlItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
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
    }
}