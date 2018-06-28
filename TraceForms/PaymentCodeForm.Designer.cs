namespace TraceForms
{
    partial class PaymentCodeForm
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
			System.Windows.Forms.Label pMT_DESCLabel;
			System.Windows.Forms.Label pMT_CODELabel;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentCodeForm));
			this.GridControlLookup = new DevExpress.XtraGrid.GridControl();
			this.BindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.GridViewLookup = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.GridColumnPmt_Code = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumnPmtDesc = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumnDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.TextEditCode = new DevExpress.XtraEditors.TextEdit();
			this.label1 = new System.Windows.Forms.Label();
			this.TextEditDesc = new DevExpress.XtraEditors.TextEdit();
			this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.SplitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
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
			pMT_DESCLabel = new System.Windows.Forms.Label();
			pMT_CODELabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.GridControlLookup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridViewLookup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditDesc.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl)).BeginInit();
			this.SplitContainerControl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PanelControlStatus)).BeginInit();
			this.PanelControlStatus.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
			this.SuspendLayout();
			// 
			// pMT_DESCLabel
			// 
			pMT_DESCLabel.AutoSize = true;
			pMT_DESCLabel.Location = new System.Drawing.Point(53, 112);
			pMT_DESCLabel.Name = "pMT_DESCLabel";
			pMT_DESCLabel.Size = new System.Drawing.Size(60, 13);
			pMT_DESCLabel.TabIndex = 17;
			pMT_DESCLabel.Text = "Description";
			// 
			// pMT_CODELabel
			// 
			pMT_CODELabel.AutoSize = true;
			pMT_CODELabel.Location = new System.Drawing.Point(53, 69);
			pMT_CODELabel.Name = "pMT_CODELabel";
			pMT_CODELabel.Size = new System.Drawing.Size(32, 13);
			pMT_CODELabel.TabIndex = 16;
			pMT_CODELabel.Text = "Code";
			// 
			// GridControlLookup
			// 
			this.GridControlLookup.DataSource = this.BindingSource;
			this.GridControlLookup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GridControlLookup.Location = new System.Drawing.Point(0, 0);
			this.GridControlLookup.MainView = this.GridViewLookup;
			this.GridControlLookup.Name = "GridControlLookup";
			this.GridControlLookup.Size = new System.Drawing.Size(294, 711);
			this.GridControlLookup.TabIndex = 15;
			this.GridControlLookup.TabStop = false;
			this.GridControlLookup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewLookup});
			// 
			// BindingSource
			// 
			this.BindingSource.DataSource = typeof(FlexModel.PMTCODE);
			this.BindingSource.CurrentChanged += new System.EventHandler(this.PmtCodeBindingSource_CurrentChanged);
			// 
			// GridViewLookup
			// 
			this.GridViewLookup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GridColumnPmt_Code,
            this.GridColumnPmtDesc,
            this.GridColumnDisplayName});
			this.GridViewLookup.GridControl = this.GridControlLookup;
			this.GridViewLookup.Name = "GridViewLookup";
			this.GridViewLookup.OptionsView.ShowAutoFilterRow = true;
			this.GridViewLookup.OptionsView.ShowGroupPanel = false;
			this.GridViewLookup.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.GridViewLookup_BeforeLeaveRow);
			// 
			// GridColumnPmt_Code
			// 
			this.GridColumnPmt_Code.Caption = "Code";
			this.GridColumnPmt_Code.FieldName = "PMT_CODE";
			this.GridColumnPmt_Code.Name = "GridColumnPmt_Code";
			this.GridColumnPmt_Code.Visible = true;
			this.GridColumnPmt_Code.VisibleIndex = 0;
			// 
			// GridColumnPmtDesc
			// 
			this.GridColumnPmtDesc.Caption = "Description";
			this.GridColumnPmtDesc.FieldName = "PMT_DESC";
			this.GridColumnPmtDesc.Name = "GridColumnPmtDesc";
			this.GridColumnPmtDesc.Visible = true;
			this.GridColumnPmtDesc.VisibleIndex = 1;
			// 
			// GridColumnDisplayName
			// 
			this.GridColumnDisplayName.FieldName = "DisplayName";
			this.GridColumnDisplayName.Name = "GridColumnDisplayName";
			this.GridColumnDisplayName.OptionsColumn.ReadOnly = true;
			// 
			// TextEditCode
			// 
			this.TextEditCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "PMT_CODE", true));
			this.TextEditCode.Location = new System.Drawing.Point(118, 66);
			this.TextEditCode.Name = "TextEditCode";
			this.TextEditCode.Properties.MaxLength = 2;
			this.TextEditCode.Size = new System.Drawing.Size(100, 20);
			this.TextEditCode.TabIndex = 1;
			this.TextEditCode.Leave += new System.EventHandler(this.TextEditCode_Leave);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(22, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 13);
			this.label1.TabIndex = 19;
			this.label1.Text = "Payments";
			// 
			// TextEditDesc
			// 
			this.TextEditDesc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "PMT_DESC", true));
			this.TextEditDesc.Location = new System.Drawing.Point(118, 109);
			this.TextEditDesc.Name = "TextEditDesc";
			this.TextEditDesc.Properties.MaxLength = 10;
			this.TextEditDesc.Size = new System.Drawing.Size(182, 20);
			this.TextEditDesc.TabIndex = 2;
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
			this.SplitContainerControl.Panel2.Controls.Add(pMT_DESCLabel);
			this.SplitContainerControl.Panel2.Controls.Add(this.TextEditCode);
			this.SplitContainerControl.Panel2.Controls.Add(pMT_CODELabel);
			this.SplitContainerControl.Panel2.Controls.Add(this.label1);
			this.SplitContainerControl.Panel2.Controls.Add(this.TextEditDesc);
			this.SplitContainerControl.Panel2.Text = "Panel2";
			this.SplitContainerControl.Size = new System.Drawing.Size(1020, 711);
			this.SplitContainerControl.SplitterPosition = 294;
			this.SplitContainerControl.TabIndex = 22;
			this.SplitContainerControl.Text = "splitContainerControl1";
			// 
			// PanelControlStatus
			// 
			this.PanelControlStatus.Appearance.Options.UseTextOptions = true;
			this.PanelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("PanelControlStatus.ContentImage")));
			this.PanelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			this.PanelControlStatus.Controls.Add(this.LabelStatus);
			this.PanelControlStatus.Location = new System.Drawing.Point(324, 2);
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
			this.barDockControlTop.Size = new System.Drawing.Size(1020, 31);
			// 
			// barDockControlBottom
			// 
			this.barDockControlBottom.CausesValidation = false;
			this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.barDockControlBottom.Location = new System.Drawing.Point(0, 742);
			this.barDockControlBottom.Manager = this.BarManager;
			this.barDockControlBottom.Size = new System.Drawing.Size(1020, 0);
			// 
			// barDockControlLeft
			// 
			this.barDockControlLeft.CausesValidation = false;
			this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
			this.barDockControlLeft.Manager = this.BarManager;
			this.barDockControlLeft.Size = new System.Drawing.Size(0, 711);
			// 
			// barDockControlRight
			// 
			this.barDockControlRight.CausesValidation = false;
			this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.barDockControlRight.Location = new System.Drawing.Point(1020, 31);
			this.barDockControlRight.Manager = this.BarManager;
			this.barDockControlRight.Size = new System.Drawing.Size(0, 711);
			// 
			// PaymentCodeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1020, 742);
			this.Controls.Add(this.PanelControlStatus);
			this.Controls.Add(this.SplitContainerControl);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.KeyPreview = true;
			this.MinimizeBox = false;
			this.Name = "PaymentCodeForm";
			this.ShowInTaskbar = false;
			this.Text = "Payment Codes";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PaymentCodeForm_FormClosing);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PaymentCodeForm_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.GridControlLookup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridViewLookup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditDesc.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl)).EndInit();
			this.SplitContainerControl.ResumeLayout(false);
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
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit TextEditDesc;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private DevExpress.XtraEditors.SplitContainerControl SplitContainerControl;
        private DevExpress.XtraEditors.PanelControl PanelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
        private DevExpress.XtraGrid.Columns.GridColumn GridColumnPmt_Code;
        private DevExpress.XtraGrid.Columns.GridColumn GridColumnPmtDesc;
        private DevExpress.XtraGrid.Columns.GridColumn GridColumnDisplayName;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarManager BarManager;
		private DevExpress.XtraBars.Bar bar1;
		private DevExpress.XtraBars.BarButtonItem BarButtonItemNew;
		private DevExpress.XtraBars.BarButtonItem BarButtonItemDelete;
		private DevExpress.XtraBars.BarButtonItem BarButtonItemSave;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
	}
}