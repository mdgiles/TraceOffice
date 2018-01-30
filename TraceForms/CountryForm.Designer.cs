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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CountryForm));
			this.GridControlCountry = new DevExpress.XtraGrid.GridControl();
			this.CountryBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.GridViewCountry = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCODE = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAGY = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCOMP = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colHOTEL = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
			this.TextEditCode = new DevExpress.XtraEditors.TextEdit();
			this.TextEditName = new DevExpress.XtraEditors.TextEdit();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
			this.imageComboBoxEditContinent = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.panelControlStatus = new DevExpress.XtraEditors.PanelControl();
			this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
			this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
			this.BarTools = new DevExpress.XtraBars.Bar();
			this.barButtonItemNew = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			nAMELabel = new System.Windows.Forms.Label();
			cODELabel = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.GridControlCountry)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CountryBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridViewCountry)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
			this.splitContainerControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEditContinent.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).BeginInit();
			this.panelControlStatus.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
			this.SuspendLayout();
			// 
			// nAMELabel
			// 
			nAMELabel.AutoSize = true;
			nAMELabel.Location = new System.Drawing.Point(59, 109);
			nAMELabel.Name = "nAMELabel";
			nAMELabel.Size = new System.Drawing.Size(34, 13);
			nAMELabel.TabIndex = 14;
			nAMELabel.Text = "Name";
			// 
			// cODELabel
			// 
			cODELabel.AutoSize = true;
			cODELabel.Location = new System.Drawing.Point(59, 72);
			cODELabel.Name = "cODELabel";
			cODELabel.Size = new System.Drawing.Size(32, 13);
			cODELabel.TabIndex = 13;
			cODELabel.Text = "Code";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(59, 147);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(54, 13);
			label2.TabIndex = 26;
			label2.Text = "Continent";
			// 
			// GridControlCountry
			// 
			this.GridControlCountry.DataSource = this.CountryBindingSource;
			this.GridControlCountry.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GridControlCountry.Location = new System.Drawing.Point(0, 0);
			this.GridControlCountry.MainView = this.GridViewCountry;
			this.GridControlCountry.Name = "GridControlCountry";
			this.GridControlCountry.Size = new System.Drawing.Size(188, 561);
			this.GridControlCountry.TabIndex = 99;
			this.GridControlCountry.TabStop = false;
			this.GridControlCountry.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewCountry});
			// 
			// CountryBindingSource
			// 
			this.CountryBindingSource.DataSource = typeof(FlexModel.COUNTRY);
			this.CountryBindingSource.CurrentChanged += new System.EventHandler(this.CountryBindingSource_CurrentChanged);
			// 
			// GridViewCountry
			// 
			this.GridViewCountry.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDisplayName,
            this.colCODE,
            this.gridColumn1,
            this.colAGY,
            this.colCOMP,
            this.colHOTEL,
            this.colAddress});
			this.GridViewCountry.GridControl = this.GridControlCountry;
			this.GridViewCountry.Name = "GridViewCountry";
			this.GridViewCountry.OptionsView.ShowAutoFilterRow = true;
			this.GridViewCountry.OptionsView.ShowGroupPanel = false;
			this.GridViewCountry.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
			this.GridViewCountry.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
			this.GridViewCountry.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView1_BeforeLeaveRow);
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
			// TextEditCode
			// 
			this.TextEditCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.CountryBindingSource, "CODE", true));
			this.TextEditCode.EnterMoveNextControl = true;
			this.TextEditCode.Location = new System.Drawing.Point(128, 70);
			this.TextEditCode.Name = "TextEditCode";
			this.TextEditCode.Properties.MaxLength = 3;
			this.TextEditCode.Size = new System.Drawing.Size(67, 20);
			this.TextEditCode.TabIndex = 1;
			this.TextEditCode.Enter += new System.EventHandler(this.enterControl);
			this.TextEditCode.Leave += new System.EventHandler(this.cODETextEdit_Leave);
			// 
			// TextEditName
			// 
			this.TextEditName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.CountryBindingSource, "NAME", true));
			this.TextEditName.EnterMoveNextControl = true;
			this.TextEditName.Location = new System.Drawing.Point(128, 107);
			this.TextEditName.Name = "TextEditName";
			this.TextEditName.Properties.MaxLength = 50;
			this.TextEditName.Size = new System.Drawing.Size(202, 20);
			this.TextEditName.TabIndex = 2;
			this.TextEditName.Enter += new System.EventHandler(this.enterControl);
			this.TextEditName.Leave += new System.EventHandler(this.nAMETextEdit_Leave);
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// splitContainerControl1
			// 
			this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl1.Location = new System.Drawing.Point(0, 31);
			this.splitContainerControl1.Name = "splitContainerControl1";
			this.splitContainerControl1.Panel1.AutoScroll = true;
			this.splitContainerControl1.Panel1.Controls.Add(this.GridControlCountry);
			this.splitContainerControl1.Panel1.Text = "Panel1";
			this.splitContainerControl1.Panel2.AutoScroll = true;
			this.splitContainerControl1.Panel2.Controls.Add(this.imageComboBoxEditContinent);
			this.splitContainerControl1.Panel2.Controls.Add(label2);
			this.splitContainerControl1.Panel2.Controls.Add(nAMELabel);
			this.splitContainerControl1.Panel2.Controls.Add(this.TextEditCode);
			this.splitContainerControl1.Panel2.Controls.Add(cODELabel);
			this.splitContainerControl1.Panel2.Controls.Add(this.TextEditName);
			this.splitContainerControl1.Panel2.Text = "Panel2";
			this.splitContainerControl1.Size = new System.Drawing.Size(1020, 561);
			this.splitContainerControl1.SplitterPosition = 188;
			this.splitContainerControl1.TabIndex = 13;
			this.splitContainerControl1.Text = "splitContainerControl1";
			// 
			// imageComboBoxEditContinent
			// 
			this.imageComboBoxEditContinent.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.CountryBindingSource, "Continent_ID", true));
			this.imageComboBoxEditContinent.EnterMoveNextControl = true;
			this.imageComboBoxEditContinent.Location = new System.Drawing.Point(128, 144);
			this.imageComboBoxEditContinent.Name = "imageComboBoxEditContinent";
			this.imageComboBoxEditContinent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.imageComboBoxEditContinent.Size = new System.Drawing.Size(202, 20);
			this.imageComboBoxEditContinent.TabIndex = 25;
			this.imageComboBoxEditContinent.Enter += new System.EventHandler(this.enterControl);
			this.imageComboBoxEditContinent.Leave += new System.EventHandler(this.imageComboBoxEditCountry_Leave);
			// 
			// panelControlStatus
			// 
			this.panelControlStatus.Appearance.Options.UseTextOptions = true;
			this.panelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("panelControlStatus.ContentImage")));
			this.panelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			this.panelControlStatus.Controls.Add(this.LabelStatus);
			this.panelControlStatus.Location = new System.Drawing.Point(303, 2);
			this.panelControlStatus.Name = "panelControlStatus";
			this.panelControlStatus.Size = new System.Drawing.Size(120, 23);
			this.panelControlStatus.TabIndex = 265;
			this.panelControlStatus.Visible = false;
			// 
			// LabelStatus
			// 
			this.LabelStatus.Location = new System.Drawing.Point(30, 5);
			this.LabelStatus.Name = "LabelStatus";
			this.LabelStatus.Size = new System.Drawing.Size(0, 13);
			this.LabelStatus.TabIndex = 5;
			// 
			// barManager1
			// 
			this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.BarTools});
			this.barManager1.DockControls.Add(this.barDockControlTop);
			this.barManager1.DockControls.Add(this.barDockControlBottom);
			this.barManager1.DockControls.Add(this.barDockControlLeft);
			this.barManager1.DockControls.Add(this.barDockControlRight);
			this.barManager1.Form = this;
			this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemNew,
            this.barButtonItem2,
            this.barButtonItem3});
			this.barManager1.MaxItemId = 3;
			// 
			// BarTools
			// 
			this.BarTools.BarName = "Tools";
			this.BarTools.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
			this.BarTools.DockCol = 0;
			this.BarTools.DockRow = 0;
			this.BarTools.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
			this.BarTools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemNew),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3)});
			this.BarTools.OptionsBar.AllowQuickCustomization = false;
			this.BarTools.OptionsBar.DrawDragBorder = false;
			this.BarTools.OptionsBar.UseWholeRow = true;
			this.BarTools.Text = "Tools";
			// 
			// barButtonItemNew
			// 
			this.barButtonItemNew.Caption = "New";
			this.barButtonItemNew.Id = 0;
			this.barButtonItemNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemNew.ImageOptions.Image")));
			this.barButtonItemNew.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemNew.ImageOptions.LargeImage")));
			this.barButtonItemNew.Name = "barButtonItemNew";
			this.barButtonItemNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemNew_ItemClick);
			// 
			// barButtonItem2
			// 
			this.barButtonItem2.Caption = "Delete";
			this.barButtonItem2.Id = 1;
			this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
			this.barButtonItem2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.LargeImage")));
			this.barButtonItem2.Name = "barButtonItem2";
			this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
			// 
			// barButtonItem3
			// 
			this.barButtonItem3.Caption = "Save";
			this.barButtonItem3.Id = 2;
			this.barButtonItem3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.Image")));
			this.barButtonItem3.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.LargeImage")));
			this.barButtonItem3.Name = "barButtonItem3";
			this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
			// 
			// barDockControlTop
			// 
			this.barDockControlTop.CausesValidation = false;
			this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
			this.barDockControlTop.Manager = this.barManager1;
			this.barDockControlTop.Size = new System.Drawing.Size(1020, 31);
			// 
			// barDockControlBottom
			// 
			this.barDockControlBottom.CausesValidation = false;
			this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.barDockControlBottom.Location = new System.Drawing.Point(0, 592);
			this.barDockControlBottom.Manager = this.barManager1;
			this.barDockControlBottom.Size = new System.Drawing.Size(1020, 0);
			// 
			// barDockControlLeft
			// 
			this.barDockControlLeft.CausesValidation = false;
			this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
			this.barDockControlLeft.Manager = this.barManager1;
			this.barDockControlLeft.Size = new System.Drawing.Size(0, 561);
			// 
			// barDockControlRight
			// 
			this.barDockControlRight.CausesValidation = false;
			this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.barDockControlRight.Location = new System.Drawing.Point(1020, 31);
			this.barDockControlRight.Manager = this.barManager1;
			this.barDockControlRight.Size = new System.Drawing.Size(0, 561);
			// 
			// CountryForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1020, 592);
			this.Controls.Add(this.panelControlStatus);
			this.Controls.Add(this.splitContainerControl1);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.KeyPreview = true;
			this.MinimizeBox = false;
			this.Name = "CountryForm";
			this.ShowInTaskbar = false;
			this.Text = "CountryForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CountryForm_FormClosing);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CountryForm_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.GridControlCountry)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CountryBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridViewCountry)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
			this.splitContainerControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEditContinent.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).EndInit();
			this.panelControlStatus.ResumeLayout(false);
			this.panelControlStatus.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GridControlCountry;
        private System.Windows.Forms.BindingSource CountryBindingSource;
        private DevExpress.XtraEditors.TextEdit TextEditCode;
        private DevExpress.XtraEditors.TextEdit TextEditName;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplayName;
        private DevExpress.XtraGrid.Columns.GridColumn colCODE;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colAGY;
        private DevExpress.XtraGrid.Columns.GridColumn colCOMP;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTEL;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        public DevExpress.XtraGrid.Views.Grid.GridView GridViewCountry;
        private DevExpress.XtraEditors.ImageComboBoxEdit imageComboBoxEditContinent;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarManager barManager1;
		private DevExpress.XtraBars.Bar BarTools;
		private DevExpress.XtraBars.BarButtonItem barButtonItemNew;
		private DevExpress.XtraBars.BarButtonItem barButtonItem2;
		private DevExpress.XtraBars.BarButtonItem barButtonItem3;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
	}
}