namespace TraceForms
{
    partial class HtlChainForm
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
			System.Windows.Forms.Label cODELabel;
			System.Windows.Forms.Label dESCLabel;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HtlChainForm));
			this.BindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.TextEditDesc = new DevExpress.XtraEditors.TextEdit();
			this.TextEditCode = new DevExpress.XtraEditors.TextEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.GridControlLookup = new DevExpress.XtraGrid.GridControl();
			this.GridViewLookup = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumnCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumnDesc = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colHOTEL = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colHTLBRAND = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colHOTELs = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colHTLBRANDs = new DevExpress.XtraGrid.Columns.GridColumn();
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
			cODELabel = new System.Windows.Forms.Label();
			dESCLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditDesc.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridControlLookup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridViewLookup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl)).BeginInit();
			this.SplitContainerControl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PanelControlStatus)).BeginInit();
			this.PanelControlStatus.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
			this.SuspendLayout();
			// 
			// cODELabel
			// 
			cODELabel.AutoSize = true;
			cODELabel.Location = new System.Drawing.Point(59, 76);
			cODELabel.Name = "cODELabel";
			cODELabel.Size = new System.Drawing.Size(32, 13);
			cODELabel.TabIndex = 16;
			cODELabel.Text = "Code";
			// 
			// dESCLabel
			// 
			dESCLabel.AutoSize = true;
			dESCLabel.Location = new System.Drawing.Point(59, 112);
			dESCLabel.Name = "dESCLabel";
			dESCLabel.Size = new System.Drawing.Size(60, 13);
			dESCLabel.TabIndex = 17;
			dESCLabel.Text = "Description";
			// 
			// BindingSource
			// 
			this.BindingSource.DataSource = typeof(FlexModel.HTLCHAIN);
			this.BindingSource.CurrentChanged += new System.EventHandler(this.HtlChainBindingSource_CurrentChanged);
			// 
			// ErrorProvider
			// 
			this.ErrorProvider.ContainerControl = this;
			// 
			// TextEditDesc
			// 
			this.TextEditDesc.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "DESC", true));
			this.TextEditDesc.EnterMoveNextControl = true;
			this.TextEditDesc.Location = new System.Drawing.Point(122, 109);
			this.TextEditDesc.Name = "TextEditDesc";
			this.TextEditDesc.Properties.MaxLength = 50;
			this.TextEditDesc.Size = new System.Drawing.Size(270, 20);
			this.TextEditDesc.TabIndex = 2;
			this.TextEditDesc.Leave += new System.EventHandler(this.TextEditDesc_Leave);
			// 
			// TextEditCode
			// 
			this.TextEditCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CODE", true));
			this.TextEditCode.EnterMoveNextControl = true;
			this.TextEditCode.Location = new System.Drawing.Point(122, 73);
			this.TextEditCode.Name = "TextEditCode";
			this.TextEditCode.Properties.MaxLength = 12;
			this.TextEditCode.Size = new System.Drawing.Size(148, 20);
			this.TextEditCode.TabIndex = 1;
			this.TextEditCode.Leave += new System.EventHandler(this.TextEditCode_Leave);
			// 
			// labelControl1
			// 
			this.labelControl1.Location = new System.Drawing.Point(31, 29);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(60, 13);
			this.labelControl1.TabIndex = 19;
			this.labelControl1.Text = "Hotel Chains";
			// 
			// GridControlLookup
			// 
			this.GridControlLookup.DataSource = this.BindingSource;
			this.GridControlLookup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GridControlLookup.Location = new System.Drawing.Point(0, 0);
			this.GridControlLookup.MainView = this.GridViewLookup;
			this.GridControlLookup.Name = "GridControlLookup";
			this.GridControlLookup.Size = new System.Drawing.Size(304, 711);
			this.GridControlLookup.TabIndex = 14;
			this.GridControlLookup.TabStop = false;
			this.GridControlLookup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewLookup});
			// 
			// GridViewLookup
			// 
			this.GridViewLookup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDisplayName,
            this.GridColumnCode,
            this.GridColumnDesc,
            this.colHOTEL,
            this.colHTLBRAND});
			this.GridViewLookup.GridControl = this.GridControlLookup;
			this.GridViewLookup.Name = "GridViewLookup";
			this.GridViewLookup.OptionsView.ShowAutoFilterRow = true;
			this.GridViewLookup.OptionsView.ShowGroupPanel = false;
			this.GridViewLookup.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.GridViewLookup_BeforeLeaveRow);
			// 
			// colDisplayName
			// 
			this.colDisplayName.FieldName = "DisplayName";
			this.colDisplayName.Name = "colDisplayName";
			this.colDisplayName.OptionsColumn.ReadOnly = true;
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
			// colHOTEL
			// 
			this.colHOTEL.FieldName = "HOTEL";
			this.colHOTEL.Name = "colHOTEL";
			// 
			// colHTLBRAND
			// 
			this.colHTLBRAND.FieldName = "HTLBRAND";
			this.colHTLBRAND.Name = "colHTLBRAND";
			// 
			// colHOTELs
			// 
			this.colHOTELs.FieldName = "HOTELs";
			this.colHOTELs.Name = "colHOTELs";
			this.colHOTELs.Visible = true;
			this.colHOTELs.VisibleIndex = 2;
			// 
			// colHTLBRANDs
			// 
			this.colHTLBRANDs.FieldName = "HTLBRANDs";
			this.colHTLBRANDs.Name = "colHTLBRANDs";
			this.colHTLBRANDs.Visible = true;
			this.colHTLBRANDs.VisibleIndex = 3;
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
			this.SplitContainerControl.Panel2.Controls.Add(dESCLabel);
			this.SplitContainerControl.Panel2.Controls.Add(this.TextEditCode);
			this.SplitContainerControl.Panel2.Controls.Add(this.labelControl1);
			this.SplitContainerControl.Panel2.Controls.Add(cODELabel);
			this.SplitContainerControl.Panel2.Controls.Add(this.TextEditDesc);
			this.SplitContainerControl.Panel2.Text = "Panel2";
			this.SplitContainerControl.Size = new System.Drawing.Size(1020, 711);
			this.SplitContainerControl.SplitterPosition = 304;
			this.SplitContainerControl.TabIndex = 16;
			this.SplitContainerControl.Text = "splitContainerControl1";
			// 
			// PanelControlStatus
			// 
			this.PanelControlStatus.Appearance.Options.UseTextOptions = true;
			this.PanelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("PanelControlStatus.ContentImage")));
			this.PanelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			this.PanelControlStatus.Controls.Add(this.LabelStatus);
			this.PanelControlStatus.Location = new System.Drawing.Point(322, 2);
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
			// HtlChainForm
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
			this.Name = "HtlChainForm";
			this.ShowInTaskbar = false;
			this.Text = "Hotel Chain";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HtlChainForm_FormClosing);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HtlChainForm_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditDesc.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridControlLookup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridViewLookup)).EndInit();
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

        private System.Windows.Forms.BindingSource BindingSource;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private DevExpress.XtraGrid.GridControl GridControlLookup;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewLookup;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit TextEditCode;
        private DevExpress.XtraEditors.TextEdit TextEditDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTELs;
        private DevExpress.XtraGrid.Columns.GridColumn colHTLBRANDs;
        private DevExpress.XtraEditors.SplitContainerControl SplitContainerControl;
        private DevExpress.XtraEditors.PanelControl PanelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplayName;
        private DevExpress.XtraGrid.Columns.GridColumn GridColumnCode;
        private DevExpress.XtraGrid.Columns.GridColumn GridColumnDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTEL;
        private DevExpress.XtraGrid.Columns.GridColumn colHTLBRAND;
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