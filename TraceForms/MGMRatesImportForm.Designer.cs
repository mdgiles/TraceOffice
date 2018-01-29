namespace TraceForms
{
    partial class MGMRatesImportForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MGMRatesImportForm));
            this.buttonEditFile = new DevExpress.XtraEditors.ButtonEdit();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.simpleButtonImport = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.buttonDeleteMapping = new DevExpress.XtraEditors.SimpleButton();
            this.buttonAddMapping = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlMapping = new DevExpress.XtraGrid.GridControl();
            this.importMappingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewMapping = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameInSpreadsheet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeekdaySurcharge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEditMoney = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colWeekendSurcharge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerPersonSurcharge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaseRateOccupancy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEditInteger = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colWeekendDays = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckedComboBoxEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            this.colFreeAgeLimit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInactive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaxOccupancy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButtonSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.panelControlStatus = new DevExpress.XtraEditors.PanelControl();
            this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
            this.buttonAddFromSelected = new DevExpress.XtraEditors.SimpleButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dateEditEffectiveDate = new DevExpress.XtraEditors.DateEdit();
            this.simpleButtonAllActive = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonAllInactive = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonToggle = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dateEditExpirationDate = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMapping)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.importMappingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMapping)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEditMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEditInteger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).BeginInit();
            this.panelControlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEffectiveDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEffectiveDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditExpirationDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditExpirationDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonEditFile
            // 
            this.buttonEditFile.Location = new System.Drawing.Point(148, 46);
            this.buttonEditFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonEditFile.Name = "buttonEditFile";
            this.buttonEditFile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEditFile.Size = new System.Drawing.Size(629, 32);
            this.buttonEditFile.TabIndex = 0;
            this.buttonEditFile.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEditFile_ButtonClick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Excel Spreadsheets|*.xlsx;*.xlsm;*.xls";
            // 
            // simpleButtonImport
            // 
            this.simpleButtonImport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonImport.ImageOptions.Image")));
            this.simpleButtonImport.Location = new System.Drawing.Point(783, 46);
            this.simpleButtonImport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButtonImport.Name = "simpleButtonImport";
            this.simpleButtonImport.Size = new System.Drawing.Size(186, 70);
            this.simpleButtonImport.TabIndex = 1;
            this.simpleButtonImport.Text = "&Import";
            this.simpleButtonImport.Click += new System.EventHandler(this.simpleButtonImport_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(22, 50);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(28, 23);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "File";
            // 
            // buttonDeleteMapping
            // 
            this.buttonDeleteMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteMapping.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonDeleteMapping.ImageOptions.Image")));
            this.buttonDeleteMapping.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonDeleteMapping.Location = new System.Drawing.Point(1145, 550);
            this.buttonDeleteMapping.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonDeleteMapping.Name = "buttonDeleteMapping";
            this.buttonDeleteMapping.Size = new System.Drawing.Size(69, 64);
            this.buttonDeleteMapping.TabIndex = 5;
            this.buttonDeleteMapping.TabStop = false;
            this.buttonDeleteMapping.Text = "simpleButton4";
            this.buttonDeleteMapping.ToolTip = "Remove selected mapping";
            this.buttonDeleteMapping.Click += new System.EventHandler(this.buttonDeleteMapping_Click);
            // 
            // buttonAddMapping
            // 
            this.buttonAddMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddMapping.ImageOptions.Image = global::TraceForms.Properties.Resources.document_new;
            this.buttonAddMapping.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonAddMapping.Location = new System.Drawing.Point(1145, 399);
            this.buttonAddMapping.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAddMapping.Name = "buttonAddMapping";
            this.buttonAddMapping.Size = new System.Drawing.Size(69, 65);
            this.buttonAddMapping.TabIndex = 4;
            this.buttonAddMapping.ToolTip = "Add new mapping";
            this.buttonAddMapping.Click += new System.EventHandler(this.buttonAddMapping_Click);
            // 
            // gridControlMapping
            // 
            this.gridControlMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlMapping.DataSource = this.importMappingBindingSource;
            this.gridControlMapping.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControlMapping.EmbeddedNavigator.Buttons.First.Visible = false;
            this.gridControlMapping.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.gridControlMapping.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.gridControlMapping.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.gridControlMapping.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.gridControlMapping.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.gridControlMapping.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControlMapping.Location = new System.Drawing.Point(22, 235);
            this.gridControlMapping.MainView = this.gridViewMapping;
            this.gridControlMapping.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControlMapping.Name = "gridControlMapping";
            this.gridControlMapping.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSpinEditMoney,
            this.repositoryItemSpinEditInteger,
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckedComboBoxEdit1});
            this.gridControlMapping.Size = new System.Drawing.Size(1100, 546);
            this.gridControlMapping.TabIndex = 3;
            this.gridControlMapping.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMapping});
            // 
            // importMappingBindingSource
            // 
            this.importMappingBindingSource.DataSource = typeof(FlexModel.ImportMapping);
            // 
            // gridViewMapping
            // 
            this.gridViewMapping.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colCode,
            this.colCat,
            this.colNameInSpreadsheet,
            this.colWeekdaySurcharge,
            this.colWeekendSurcharge,
            this.colPerPersonSurcharge,
            this.colBaseRateOccupancy,
            this.colWeekendDays,
            this.colFreeAgeLimit,
            this.colInactive,
            this.colType,
            this.colMaxOccupancy});
            this.gridViewMapping.GridControl = this.gridControlMapping;
            this.gridViewMapping.Name = "gridViewMapping";
            this.gridViewMapping.OptionsCustomization.AllowColumnMoving = false;
            this.gridViewMapping.OptionsCustomization.AllowGroup = false;
            this.gridViewMapping.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridViewMapping.OptionsFind.AllowFindPanel = false;
            this.gridViewMapping.OptionsMenu.EnableColumnMenu = false;
            this.gridViewMapping.OptionsView.ShowGroupPanel = false;
            this.gridViewMapping.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridViewMapping_CustomRowCellEdit);
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colCode
            // 
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 1;
            this.colCode.Width = 143;
            // 
            // colCat
            // 
            this.colCat.Caption = "Category";
            this.colCat.FieldName = "Cat";
            this.colCat.Name = "colCat";
            this.colCat.Visible = true;
            this.colCat.VisibleIndex = 2;
            this.colCat.Width = 117;
            // 
            // colNameInSpreadsheet
            // 
            this.colNameInSpreadsheet.FieldName = "NameInSpreadsheet";
            this.colNameInSpreadsheet.Name = "colNameInSpreadsheet";
            this.colNameInSpreadsheet.Visible = true;
            this.colNameInSpreadsheet.VisibleIndex = 3;
            this.colNameInSpreadsheet.Width = 217;
            // 
            // colWeekdaySurcharge
            // 
            this.colWeekdaySurcharge.ColumnEdit = this.repositoryItemSpinEditMoney;
            this.colWeekdaySurcharge.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colWeekdaySurcharge.FieldName = "WeekdaySurcharge";
            this.colWeekdaySurcharge.Name = "colWeekdaySurcharge";
            this.colWeekdaySurcharge.Visible = true;
            this.colWeekdaySurcharge.VisibleIndex = 4;
            this.colWeekdaySurcharge.Width = 104;
            // 
            // repositoryItemSpinEditMoney
            // 
            this.repositoryItemSpinEditMoney.AutoHeight = false;
            this.repositoryItemSpinEditMoney.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEditMoney.Mask.EditMask = "#####0.00";
            this.repositoryItemSpinEditMoney.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemSpinEditMoney.MaxValue = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.repositoryItemSpinEditMoney.Name = "repositoryItemSpinEditMoney";
            // 
            // colWeekendSurcharge
            // 
            this.colWeekendSurcharge.ColumnEdit = this.repositoryItemSpinEditMoney;
            this.colWeekendSurcharge.FieldName = "WeekendSurcharge";
            this.colWeekendSurcharge.Name = "colWeekendSurcharge";
            this.colWeekendSurcharge.Visible = true;
            this.colWeekendSurcharge.VisibleIndex = 5;
            this.colWeekendSurcharge.Width = 100;
            // 
            // colPerPersonSurcharge
            // 
            this.colPerPersonSurcharge.ColumnEdit = this.repositoryItemSpinEditMoney;
            this.colPerPersonSurcharge.FieldName = "PerPersonSurcharge";
            this.colPerPersonSurcharge.Name = "colPerPersonSurcharge";
            this.colPerPersonSurcharge.Visible = true;
            this.colPerPersonSurcharge.VisibleIndex = 6;
            this.colPerPersonSurcharge.Width = 105;
            // 
            // colBaseRateOccupancy
            // 
            this.colBaseRateOccupancy.ColumnEdit = this.repositoryItemSpinEditInteger;
            this.colBaseRateOccupancy.FieldName = "BaseRateOccupancy";
            this.colBaseRateOccupancy.Name = "colBaseRateOccupancy";
            this.colBaseRateOccupancy.Visible = true;
            this.colBaseRateOccupancy.VisibleIndex = 7;
            this.colBaseRateOccupancy.Width = 110;
            // 
            // repositoryItemSpinEditInteger
            // 
            this.repositoryItemSpinEditInteger.AutoHeight = false;
            this.repositoryItemSpinEditInteger.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEditInteger.IsFloatValue = false;
            this.repositoryItemSpinEditInteger.Mask.EditMask = "N00";
            this.repositoryItemSpinEditInteger.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemSpinEditInteger.MaxValue = new decimal(new int[] {
            17,
            0,
            0,
            0});
            this.repositoryItemSpinEditInteger.Name = "repositoryItemSpinEditInteger";
            // 
            // colWeekendDays
            // 
            this.colWeekendDays.ColumnEdit = this.repositoryItemCheckedComboBoxEdit1;
            this.colWeekendDays.FieldName = "WeekendDays";
            this.colWeekendDays.Name = "colWeekendDays";
            this.colWeekendDays.Visible = true;
            this.colWeekendDays.VisibleIndex = 8;
            this.colWeekendDays.Width = 74;
            // 
            // repositoryItemCheckedComboBoxEdit1
            // 
            this.repositoryItemCheckedComboBoxEdit1.AutoHeight = false;
            this.repositoryItemCheckedComboBoxEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCheckedComboBoxEdit1.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Sun", "Sun"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Mon", "Mon"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Tue", "Tue"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Wed", "Wed"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Thu", "Thu"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Fri", "Fri"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("Sat", "Sat")});
            this.repositoryItemCheckedComboBoxEdit1.Name = "repositoryItemCheckedComboBoxEdit1";
            this.repositoryItemCheckedComboBoxEdit1.SelectAllItemVisible = false;
            // 
            // colFreeAgeLimit
            // 
            this.colFreeAgeLimit.ColumnEdit = this.repositoryItemSpinEditInteger;
            this.colFreeAgeLimit.FieldName = "FreeAgeLimit";
            this.colFreeAgeLimit.Name = "colFreeAgeLimit";
            this.colFreeAgeLimit.Visible = true;
            this.colFreeAgeLimit.VisibleIndex = 9;
            this.colFreeAgeLimit.Width = 101;
            // 
            // colInactive
            // 
            this.colInactive.Caption = "Exclude";
            this.colInactive.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colInactive.FieldName = "Inactive";
            this.colInactive.Name = "colInactive";
            this.colInactive.Visible = true;
            this.colInactive.VisibleIndex = 0;
            this.colInactive.Width = 43;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colType
            // 
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            // 
            // colMaxOccupancy
            // 
            this.colMaxOccupancy.Caption = "Max Occ";
            this.colMaxOccupancy.ColumnEdit = this.repositoryItemSpinEditInteger;
            this.colMaxOccupancy.FieldName = "MaxOccupancy";
            this.colMaxOccupancy.Name = "colMaxOccupancy";
            this.colMaxOccupancy.Visible = true;
            this.colMaxOccupancy.VisibleIndex = 10;
            this.colMaxOccupancy.Width = 58;
            // 
            // simpleButtonSave
            // 
            this.simpleButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButtonSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonSave.ImageOptions.Image")));
            this.simpleButtonSave.Location = new System.Drawing.Point(22, 788);
            this.simpleButtonSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButtonSave.Name = "simpleButtonSave";
            this.simpleButtonSave.Size = new System.Drawing.Size(218, 82);
            this.simpleButtonSave.TabIndex = 6;
            this.simpleButtonSave.Text = "&Save Mappings";
            this.simpleButtonSave.Click += new System.EventHandler(this.simpleButtonSave_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(24, 182);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(88, 23);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Mappings:";
            // 
            // panelControlStatus
            // 
            this.panelControlStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panelControlStatus.Appearance.Options.UseTextOptions = true;
            this.panelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("panelControlStatus.ContentImage")));
            this.panelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.panelControlStatus.Controls.Add(this.LabelStatus);
            this.panelControlStatus.Location = new System.Drawing.Point(325, 811);
            this.panelControlStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelControlStatus.Name = "panelControlStatus";
            this.panelControlStatus.Size = new System.Drawing.Size(243, 41);
            this.panelControlStatus.TabIndex = 12;
            this.panelControlStatus.Visible = false;
            // 
            // LabelStatus
            // 
            this.LabelStatus.Location = new System.Drawing.Point(50, 8);
            this.LabelStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(0, 23);
            this.LabelStatus.TabIndex = 0;
            // 
            // buttonAddFromSelected
            // 
            this.buttonAddFromSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddFromSelected.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddFromSelected.ImageOptions.Image")));
            this.buttonAddFromSelected.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonAddFromSelected.Location = new System.Drawing.Point(1145, 475);
            this.buttonAddFromSelected.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAddFromSelected.Name = "buttonAddFromSelected";
            this.buttonAddFromSelected.Size = new System.Drawing.Size(69, 65);
            this.buttonAddFromSelected.TabIndex = 13;
            this.buttonAddFromSelected.ToolTip = "Add new mapping from currently selected mapping";
            this.buttonAddFromSelected.Click += new System.EventHandler(this.buttonAddFromSelected_Click);
            // 
            // marqueeProgressBarControl1
            // 
            this.marqueeProgressBarControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.marqueeProgressBarControl1.EditValue = "Importing...";
            this.marqueeProgressBarControl1.Location = new System.Drawing.Point(369, 126);
            this.marqueeProgressBarControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
            this.marqueeProgressBarControl1.Properties.ProgressAnimationMode = DevExpress.Utils.Drawing.ProgressAnimationMode.Cycle;
            this.marqueeProgressBarControl1.Properties.ShowTitle = true;
            this.marqueeProgressBarControl1.Size = new System.Drawing.Size(434, 31);
            this.marqueeProgressBarControl1.TabIndex = 14;
            this.marqueeProgressBarControl1.Visible = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(22, 88);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(116, 23);
            this.labelControl3.TabIndex = 15;
            this.labelControl3.Text = "Effective Date";
            // 
            // dateEditEffectiveDate
            // 
            this.dateEditEffectiveDate.EditValue = null;
            this.dateEditEffectiveDate.Location = new System.Drawing.Point(148, 85);
            this.dateEditEffectiveDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateEditEffectiveDate.Name = "dateEditEffectiveDate";
            this.dateEditEffectiveDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dateEditEffectiveDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditEffectiveDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditEffectiveDate.Properties.DisplayFormat.FormatString = "dd-MMM-yyyy";
            this.dateEditEffectiveDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditEffectiveDate.Size = new System.Drawing.Size(178, 32);
            this.dateEditEffectiveDate.TabIndex = 16;
            // 
            // simpleButtonAllActive
            // 
            this.simpleButtonAllActive.Location = new System.Drawing.Point(148, 171);
            this.simpleButtonAllActive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButtonAllActive.Name = "simpleButtonAllActive";
            this.simpleButtonAllActive.Size = new System.Drawing.Size(214, 44);
            this.simpleButtonAllActive.TabIndex = 17;
            this.simpleButtonAllActive.Text = "Exclude All";
            this.simpleButtonAllActive.Click += new System.EventHandler(this.simpleButtonExcludeAll_Click);
            // 
            // simpleButtonAllInactive
            // 
            this.simpleButtonAllInactive.Location = new System.Drawing.Point(369, 171);
            this.simpleButtonAllInactive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButtonAllInactive.Name = "simpleButtonAllInactive";
            this.simpleButtonAllInactive.Size = new System.Drawing.Size(214, 44);
            this.simpleButtonAllInactive.TabIndex = 18;
            this.simpleButtonAllInactive.Text = "Include All";
            this.simpleButtonAllInactive.Click += new System.EventHandler(this.simpleButtonIncludeAll_Click);
            // 
            // simpleButtonToggle
            // 
            this.simpleButtonToggle.Location = new System.Drawing.Point(590, 171);
            this.simpleButtonToggle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButtonToggle.Name = "simpleButtonToggle";
            this.simpleButtonToggle.Size = new System.Drawing.Size(214, 44);
            this.simpleButtonToggle.TabIndex = 19;
            this.simpleButtonToggle.Text = "Toggle Include/Exclude";
            this.simpleButtonToggle.Click += new System.EventHandler(this.simpleButtonToggle_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(351, 89);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(128, 23);
            this.labelControl4.TabIndex = 20;
            this.labelControl4.Text = "Expiration Date";
            // 
            // dateEditExpirationDate
            // 
            this.dateEditExpirationDate.EditValue = null;
            this.dateEditExpirationDate.Location = new System.Drawing.Point(485, 86);
            this.dateEditExpirationDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateEditExpirationDate.Name = "dateEditExpirationDate";
            this.dateEditExpirationDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dateEditExpirationDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditExpirationDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditExpirationDate.Properties.DisplayFormat.FormatString = "dd-MMM-yyyy";
            this.dateEditExpirationDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditExpirationDate.Size = new System.Drawing.Size(178, 32);
            this.dateEditExpirationDate.TabIndex = 21;
            // 
            // MGMRatesImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 897);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.dateEditExpirationDate);
            this.Controls.Add(this.simpleButtonToggle);
            this.Controls.Add(this.simpleButtonAllInactive);
            this.Controls.Add(this.simpleButtonAllActive);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.dateEditEffectiveDate);
            this.Controls.Add(this.marqueeProgressBarControl1);
            this.Controls.Add(this.buttonAddFromSelected);
            this.Controls.Add(this.panelControlStatus);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.simpleButtonSave);
            this.Controls.Add(this.buttonDeleteMapping);
            this.Controls.Add(this.buttonAddMapping);
            this.Controls.Add(this.gridControlMapping);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.simpleButtonImport);
            this.Controls.Add(this.buttonEditFile);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "MGMRatesImportForm";
            this.ShowInTaskbar = false;
            this.Text = "Rates Import";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MGMRatesImportForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MGMRatesImportForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMapping)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.importMappingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMapping)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEditMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEditInteger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).EndInit();
            this.panelControlStatus.ResumeLayout(false);
            this.panelControlStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEffectiveDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEffectiveDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditExpirationDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditExpirationDate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ButtonEdit buttonEditFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private DevExpress.XtraEditors.SimpleButton simpleButtonImport;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton buttonDeleteMapping;
        private DevExpress.XtraEditors.SimpleButton buttonAddMapping;
        private DevExpress.XtraGrid.GridControl gridControlMapping;
        private System.Windows.Forms.BindingSource importMappingBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMapping;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSave;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCat;
        private DevExpress.XtraGrid.Columns.GridColumn colNameInSpreadsheet;
        private DevExpress.XtraGrid.Columns.GridColumn colWeekdaySurcharge;
        private DevExpress.XtraGrid.Columns.GridColumn colWeekendSurcharge;
        private DevExpress.XtraGrid.Columns.GridColumn colPerPersonSurcharge;
        private DevExpress.XtraGrid.Columns.GridColumn colBaseRateOccupancy;
        private DevExpress.XtraGrid.Columns.GridColumn colWeekendDays;
        private DevExpress.XtraGrid.Columns.GridColumn colFreeAgeLimit;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEditMoney;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEditInteger;
        private DevExpress.XtraEditors.PanelControl panelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
        private DevExpress.XtraEditors.SimpleButton buttonAddFromSelected;
        private System.Windows.Forms.ToolTip toolTip1;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit dateEditEffectiveDate;
        private DevExpress.XtraGrid.Columns.GridColumn colInactive;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit repositoryItemCheckedComboBoxEdit1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonAllActive;
        private DevExpress.XtraEditors.SimpleButton simpleButtonAllInactive;
        private DevExpress.XtraEditors.SimpleButton simpleButtonToggle;
        private DevExpress.XtraGrid.Columns.GridColumn colMaxOccupancy;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.DateEdit dateEditExpirationDate;
    }
}