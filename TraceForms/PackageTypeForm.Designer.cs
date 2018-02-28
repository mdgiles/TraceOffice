namespace TraceForms
{
    partial class PackageTypeForm
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
			System.Windows.Forms.Label dESCLabel;
			System.Windows.Forms.Label cODELabel;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PackageTypeForm));
			this.GridControlLookup = new DevExpress.XtraGrid.GridControl();
			this.BindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.GridViewLookup = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPACK = new DevExpress.XtraGrid.Columns.GridColumn();
			this.TextEditCode = new DevExpress.XtraEditors.TextEdit();
			this.TextEditDesc = new DevExpress.XtraEditors.TextEdit();
			this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.SplitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
			this.PanelControlStatus = new DevExpress.XtraEditors.PanelControl();
			this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
			this.BarManager = new DevExpress.XtraBars.BarManager(this.components);
			this.bar1 = new DevExpress.XtraBars.Bar();
			this.barButtonItemNew = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItemDelete = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItemSave = new DevExpress.XtraBars.BarButtonItem();
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			dESCLabel = new System.Windows.Forms.Label();
			cODELabel = new System.Windows.Forms.Label();
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
			// dESCLabel
			// 
			dESCLabel.AutoSize = true;
			dESCLabel.Location = new System.Drawing.Point(49, 112);
			dESCLabel.Name = "dESCLabel";
			dESCLabel.Size = new System.Drawing.Size(60, 13);
			dESCLabel.TabIndex = 15;
			dESCLabel.Text = "Description";
			// 
			// cODELabel
			// 
			cODELabel.AutoSize = true;
			cODELabel.Location = new System.Drawing.Point(49, 76);
			cODELabel.Name = "cODELabel";
			cODELabel.Size = new System.Drawing.Size(32, 13);
			cODELabel.TabIndex = 12;
			cODELabel.Text = "Code";
			// 
			// GridControlLookup
			// 
			this.GridControlLookup.DataSource = this.BindingSource;
			this.GridControlLookup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GridControlLookup.Location = new System.Drawing.Point(0, 0);
			this.GridControlLookup.MainView = this.GridViewLookup;
			this.GridControlLookup.Name = "GridControlLookup";
			this.GridControlLookup.Size = new System.Drawing.Size(319, 711);
			this.GridControlLookup.TabIndex = 13;
			this.GridControlLookup.TabStop = false;
			this.GridControlLookup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewLookup});
			// 
			// BindingSource
			// 
			this.BindingSource.DataSource = typeof(FlexModel.PACKTYPE);
			this.BindingSource.CurrentChanged += new System.EventHandler(this.BindingSource_CurrentChanged);
			// 
			// GridViewLookup
			// 
			this.GridViewLookup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDisplayName,
            this.gridColumnCode,
            this.gridColumnName,
            this.colPACK});
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
			// gridColumnCode
			// 
			this.gridColumnCode.FieldName = "CODE";
			this.gridColumnCode.Name = "gridColumnCode";
			this.gridColumnCode.OptionsColumn.AllowEdit = false;
			this.gridColumnCode.Visible = true;
			this.gridColumnCode.VisibleIndex = 0;
			// 
			// gridColumnName
			// 
			this.gridColumnName.FieldName = "Name";
			this.gridColumnName.Name = "gridColumnName";
			this.gridColumnName.OptionsColumn.AllowEdit = false;
			this.gridColumnName.Visible = true;
			this.gridColumnName.VisibleIndex = 1;
			// 
			// colPACK
			// 
			this.colPACK.FieldName = "PACK";
			this.colPACK.Name = "colPACK";
			// 
			// TextEditCode
			// 
			this.TextEditCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CODE", true));
			this.TextEditCode.Location = new System.Drawing.Point(126, 73);
			this.TextEditCode.Name = "TextEditCode";
			this.TextEditCode.Properties.MaxLength = 3;
			this.TextEditCode.Size = new System.Drawing.Size(126, 20);
			this.TextEditCode.TabIndex = 1;
			this.TextEditCode.Leave += new System.EventHandler(this.TextEditCode_Leave);
			// 
			// TextEditDesc
			// 
			this.TextEditDesc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "DESC", true));
			this.TextEditDesc.Location = new System.Drawing.Point(126, 109);
			this.TextEditDesc.Name = "TextEditDesc";
			this.TextEditDesc.Properties.MaxLength = 60;
			this.TextEditDesc.Size = new System.Drawing.Size(250, 20);
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
			this.SplitContainerControl.Panel2.Controls.Add(dESCLabel);
			this.SplitContainerControl.Panel2.Controls.Add(this.TextEditCode);
			this.SplitContainerControl.Panel2.Controls.Add(cODELabel);
			this.SplitContainerControl.Panel2.Controls.Add(this.TextEditDesc);
			this.SplitContainerControl.Panel2.Text = "Panel2";
			this.SplitContainerControl.Size = new System.Drawing.Size(1020, 711);
			this.SplitContainerControl.SplitterPosition = 319;
			this.SplitContainerControl.TabIndex = 15;
			this.SplitContainerControl.Text = "splitContainerControl1";
			// 
			// PanelControlStatus
			// 
			this.PanelControlStatus.Appearance.Options.UseTextOptions = true;
			this.PanelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("PanelControlStatus.ContentImage")));
			this.PanelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			this.PanelControlStatus.Controls.Add(this.LabelStatus);
			this.PanelControlStatus.Location = new System.Drawing.Point(338, 2);
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
            this.barButtonItemNew,
            this.barButtonItemDelete,
            this.barButtonItemSave});
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
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemNew),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemSave)});
			this.bar1.OptionsBar.AllowQuickCustomization = false;
			this.bar1.OptionsBar.DrawDragBorder = false;
			this.bar1.OptionsBar.UseWholeRow = true;
			this.bar1.Text = "Tools";
			// 
			// barButtonItemNew
			// 
			this.barButtonItemNew.Caption = "New";
			this.barButtonItemNew.Id = 0;
			this.barButtonItemNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemNew.ImageOptions.Image")));
			this.barButtonItemNew.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemNew.ImageOptions.LargeImage")));
			this.barButtonItemNew.Name = "barButtonItemNew";
			this.barButtonItemNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemNew_ItemClick);
			// 
			// barButtonItemDelete
			// 
			this.barButtonItemDelete.Caption = "Delete";
			this.barButtonItemDelete.Id = 1;
			this.barButtonItemDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemDelete.ImageOptions.Image")));
			this.barButtonItemDelete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemDelete.ImageOptions.LargeImage")));
			this.barButtonItemDelete.Name = "barButtonItemDelete";
			this.barButtonItemDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemDelete_ItemClick);
			// 
			// barButtonItemSave
			// 
			this.barButtonItemSave.Caption = "Save";
			this.barButtonItemSave.Id = 2;
			this.barButtonItemSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemSave.ImageOptions.Image")));
			this.barButtonItemSave.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemSave.ImageOptions.LargeImage")));
			this.barButtonItemSave.Name = "barButtonItemSave";
			this.barButtonItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemSave_ItemClick);
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
			// PackageTypeForm
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
			this.Name = "PackageTypeForm";
			this.ShowInTaskbar = false;
			this.Text = "Package Types";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PackageTypeForm_FormClosing);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PackageTypeForm_KeyDown);
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
        private DevExpress.XtraEditors.TextEdit TextEditDesc;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private DevExpress.XtraEditors.SplitContainerControl SplitContainerControl;
        private DevExpress.XtraEditors.PanelControl PanelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplayName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnName;
        private DevExpress.XtraGrid.Columns.GridColumn colPACK;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarManager BarManager;
		private DevExpress.XtraBars.Bar bar1;
		private DevExpress.XtraBars.BarButtonItem barButtonItemNew;
		private DevExpress.XtraBars.BarButtonItem barButtonItemDelete;
		private DevExpress.XtraBars.BarButtonItem barButtonItemSave;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
	}
}