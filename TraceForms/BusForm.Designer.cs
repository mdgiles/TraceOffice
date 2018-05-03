namespace TraceForms
{
    partial class BusForm
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
			System.Windows.Forms.Label labelType;
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label3;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusForm));
			this.BindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.SplitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
			this.GridControlLookup = new DevExpress.XtraGrid.GridControl();
			this.GridViewLookup = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colName1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colFleetMgmtID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colFlexMgmtIPAddress = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInService = new DevExpress.XtraGrid.Columns.GridColumn();
			this.BarManager = new DevExpress.XtraBars.BarManager(this.components);
			this.bar1 = new DevExpress.XtraBars.Bar();
			this.BarButtonItemNew = new DevExpress.XtraBars.BarButtonItem();
			this.BarButtonItemDelete = new DevExpress.XtraBars.BarButtonItem();
			this.BarButtonItemSave = new DevExpress.XtraBars.BarButtonItem();
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			this.SpinEditCapacity = new DevExpress.XtraEditors.SpinEdit();
			this.TextEditFleetMgmtIPAddress = new DevExpress.XtraEditors.TextEdit();
			this.TextEditFleetMgmtID = new DevExpress.XtraEditors.TextEdit();
			this.TextEditName = new DevExpress.XtraEditors.TextEdit();
			this.CheckEditInService = new DevExpress.XtraEditors.CheckEdit();
			this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
			this.PanelControlStatus = new DevExpress.XtraEditors.PanelControl();
			this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
			labelType = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl)).BeginInit();
			this.SplitContainerControl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.GridControlLookup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridViewLookup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SpinEditCapacity.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditFleetMgmtIPAddress.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditFleetMgmtID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CheckEditInService.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PanelControlStatus)).BeginInit();
			this.PanelControlStatus.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelType
			// 
			labelType.AutoSize = true;
			labelType.Location = new System.Drawing.Point(22, 206);
			labelType.Name = "labelType";
			labelType.Size = new System.Drawing.Size(110, 13);
			labelType.TabIndex = 2;
			labelType.Text = "Fleet management ID";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(22, 165);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(34, 13);
			label1.TabIndex = 0;
			label1.Text = "Name";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(22, 244);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(150, 13);
			label2.TabIndex = 4;
			label2.Text = "Fleet management IP address";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(22, 309);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(49, 13);
			label3.TabIndex = 7;
			label3.Text = "Capacity";
			// 
			// BindingSource
			// 
			this.BindingSource.DataSource = typeof(FlexModel.Bus);
			this.BindingSource.CurrentChanged += new System.EventHandler(this.BindingSource_CurrentChanged);
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
			this.SplitContainerControl.Panel2.AutoScroll = true;
			this.SplitContainerControl.Panel2.Controls.Add(label3);
			this.SplitContainerControl.Panel2.Controls.Add(this.SpinEditCapacity);
			this.SplitContainerControl.Panel2.Controls.Add(this.TextEditFleetMgmtIPAddress);
			this.SplitContainerControl.Panel2.Controls.Add(this.TextEditFleetMgmtID);
			this.SplitContainerControl.Panel2.Controls.Add(this.TextEditName);
			this.SplitContainerControl.Panel2.Controls.Add(label1);
			this.SplitContainerControl.Panel2.Controls.Add(label2);
			this.SplitContainerControl.Panel2.Controls.Add(labelType);
			this.SplitContainerControl.Panel2.Controls.Add(this.CheckEditInService);
			this.SplitContainerControl.Size = new System.Drawing.Size(946, 467);
			this.SplitContainerControl.SplitterPosition = 295;
			this.SplitContainerControl.TabIndex = 39;
			// 
			// GridControlLookup
			// 
			this.GridControlLookup.DataSource = this.BindingSource;
			this.GridControlLookup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GridControlLookup.Location = new System.Drawing.Point(0, 0);
			this.GridControlLookup.MainView = this.GridViewLookup;
			this.GridControlLookup.Name = "GridControlLookup";
			this.GridControlLookup.Size = new System.Drawing.Size(295, 467);
			this.GridControlLookup.TabIndex = 0;
			this.GridControlLookup.TabStop = false;
			this.GridControlLookup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewLookup});
			// 
			// GridViewLookup
			// 
			this.GridViewLookup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colName1,
            this.colFleetMgmtID,
            this.colFlexMgmtIPAddress,
            this.colInService});
			this.GridViewLookup.GridControl = this.GridControlLookup;
			this.GridViewLookup.Name = "GridViewLookup";
			this.GridViewLookup.OptionsBehavior.Editable = false;
			this.GridViewLookup.OptionsView.ShowAutoFilterRow = true;
			this.GridViewLookup.OptionsView.ShowGroupPanel = false;
			this.GridViewLookup.ColumnFilterChanged += new System.EventHandler(this.GridViewLookup_ColumnFilterChanged);
			// 
			// colID
			// 
			this.colID.FieldName = "ID";
			this.colID.Name = "colID";
			// 
			// colName1
			// 
			this.colName1.FieldName = "Name";
			this.colName1.Name = "colName1";
			this.colName1.Visible = true;
			this.colName1.VisibleIndex = 0;
			// 
			// colFleetMgmtID
			// 
			this.colFleetMgmtID.FieldName = "FleetMgmtID";
			this.colFleetMgmtID.Name = "colFleetMgmtID";
			// 
			// colFlexMgmtIPAddress
			// 
			this.colFlexMgmtIPAddress.FieldName = "FlexMgmtIPAddress";
			this.colFlexMgmtIPAddress.Name = "colFlexMgmtIPAddress";
			// 
			// colInService
			// 
			this.colInService.FieldName = "InService";
			this.colInService.Name = "colInService";
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
			this.bar1.DockCol = 0;
			this.bar1.DockRow = 0;
			this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
			this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BarButtonItemNew, DevExpress.XtraBars.BarItemPaintStyle.Standard),
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
			this.barDockControlTop.Size = new System.Drawing.Size(946, 31);
			// 
			// barDockControlBottom
			// 
			this.barDockControlBottom.CausesValidation = false;
			this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.barDockControlBottom.Location = new System.Drawing.Point(0, 498);
			this.barDockControlBottom.Manager = this.BarManager;
			this.barDockControlBottom.Size = new System.Drawing.Size(946, 0);
			// 
			// barDockControlLeft
			// 
			this.barDockControlLeft.CausesValidation = false;
			this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
			this.barDockControlLeft.Manager = this.BarManager;
			this.barDockControlLeft.Size = new System.Drawing.Size(0, 467);
			// 
			// barDockControlRight
			// 
			this.barDockControlRight.CausesValidation = false;
			this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.barDockControlRight.Location = new System.Drawing.Point(946, 31);
			this.barDockControlRight.Manager = this.BarManager;
			this.barDockControlRight.Size = new System.Drawing.Size(0, 467);
			// 
			// SpinEditCapacity
			// 
			this.SpinEditCapacity.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Capacity", true));
			this.SpinEditCapacity.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.SpinEditCapacity.Location = new System.Drawing.Point(194, 307);
			this.SpinEditCapacity.Margin = new System.Windows.Forms.Padding(2);
			this.SpinEditCapacity.Name = "SpinEditCapacity";
			this.SpinEditCapacity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.SpinEditCapacity.Properties.Mask.EditMask = "###";
			this.SpinEditCapacity.Properties.Mask.UseMaskAsDisplayFormat = true;
			this.SpinEditCapacity.Properties.MaxValue = new decimal(new int[] {
            999,
            0,
            0,
            0});
			this.SpinEditCapacity.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.SpinEditCapacity.Size = new System.Drawing.Size(67, 20);
			this.SpinEditCapacity.TabIndex = 8;
			this.SpinEditCapacity.Leave += new System.EventHandler(this.SpinEditCapacity_Leave);
			// 
			// TextEditFleetMgmtIPAddress
			// 
			this.TextEditFleetMgmtIPAddress.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "FlexMgmtIPAddress", true));
			this.TextEditFleetMgmtIPAddress.EnterMoveNextControl = true;
			this.TextEditFleetMgmtIPAddress.Location = new System.Drawing.Point(194, 242);
			this.TextEditFleetMgmtIPAddress.Name = "TextEditFleetMgmtIPAddress";
			this.TextEditFleetMgmtIPAddress.Properties.MaxLength = 12;
			this.TextEditFleetMgmtIPAddress.Size = new System.Drawing.Size(168, 20);
			this.TextEditFleetMgmtIPAddress.TabIndex = 5;
			// 
			// TextEditFleetMgmtID
			// 
			this.TextEditFleetMgmtID.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "FleetMgmtID", true));
			this.TextEditFleetMgmtID.EnterMoveNextControl = true;
			this.TextEditFleetMgmtID.Location = new System.Drawing.Point(194, 204);
			this.TextEditFleetMgmtID.Name = "TextEditFleetMgmtID";
			this.TextEditFleetMgmtID.Properties.MaxLength = 50;
			this.TextEditFleetMgmtID.Size = new System.Drawing.Size(295, 20);
			this.TextEditFleetMgmtID.TabIndex = 3;
			// 
			// TextEditName
			// 
			this.TextEditName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Name", true));
			this.TextEditName.EnterMoveNextControl = true;
			this.TextEditName.Location = new System.Drawing.Point(194, 163);
			this.TextEditName.Name = "TextEditName";
			this.TextEditName.Properties.MaxLength = 60;
			this.TextEditName.Size = new System.Drawing.Size(392, 20);
			this.TextEditName.TabIndex = 1;
			this.TextEditName.Leave += new System.EventHandler(this.TextEditName_Leave);
			// 
			// CheckEditInService
			// 
			this.CheckEditInService.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "InService", true));
			this.CheckEditInService.Location = new System.Drawing.Point(23, 275);
			this.CheckEditInService.Margin = new System.Windows.Forms.Padding(2);
			this.CheckEditInService.Name = "CheckEditInService";
			this.CheckEditInService.Properties.Caption = "In Service";
			this.CheckEditInService.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.CheckEditInService.Size = new System.Drawing.Size(190, 19);
			this.CheckEditInService.TabIndex = 6;
			// 
			// LabelStatus
			// 
			this.LabelStatus.Location = new System.Drawing.Point(30, 5);
			this.LabelStatus.Name = "LabelStatus";
			this.LabelStatus.Size = new System.Drawing.Size(0, 13);
			this.LabelStatus.TabIndex = 5;
			// 
			// PanelControlStatus
			// 
			this.PanelControlStatus.Appearance.Options.UseTextOptions = true;
			this.PanelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("PanelControlStatus.ContentImage")));
			this.PanelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			this.PanelControlStatus.Controls.Add(this.LabelStatus);
			this.PanelControlStatus.Location = new System.Drawing.Point(365, 2);
			this.PanelControlStatus.Name = "PanelControlStatus";
			this.PanelControlStatus.Size = new System.Drawing.Size(120, 23);
			this.PanelControlStatus.TabIndex = 265;
			this.PanelControlStatus.Visible = false;
			// 
			// colName
			// 
			this.colName.FieldName = "Name";
			this.colName.Name = "colName";
			this.colName.Visible = true;
			this.colName.VisibleIndex = 0;
			// 
			// BusForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(946, 498);
			this.Controls.Add(this.PanelControlStatus);
			this.Controls.Add(this.SplitContainerControl);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.KeyPreview = true;
			this.MinimizeBox = false;
			this.Name = "BusForm";
			this.ShowInTaskbar = false;
			this.Text = "Bus General Information";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BusForm_FormClosing);
			this.Shown += new System.EventHandler(this.BusForm_Shown);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BusForm_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl)).EndInit();
			this.SplitContainerControl.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.GridControlLookup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridViewLookup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SpinEditCapacity.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditFleetMgmtIPAddress.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditFleetMgmtID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CheckEditInService.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PanelControlStatus)).EndInit();
			this.PanelControlStatus.ResumeLayout(false);
			this.PanelControlStatus.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource BindingSource;
		private System.Windows.Forms.ErrorProvider ErrorProvider;
        private DevExpress.XtraEditors.SplitContainerControl SplitContainerControl;
		private DevExpress.XtraEditors.CheckEdit CheckEditInService;
        private DevExpress.XtraEditors.TextEdit TextEditFleetMgmtIPAddress;
		private DevExpress.XtraEditors.SpinEdit SpinEditCapacity;
		private DevExpress.XtraEditors.PanelControl PanelControlStatus;
		private DevExpress.XtraEditors.LabelControl LabelStatus;
		private DevExpress.XtraGrid.GridControl GridControlLookup;
		private DevExpress.XtraGrid.Views.Grid.GridView GridViewLookup;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarManager BarManager;
		private DevExpress.XtraBars.Bar bar1;
		private DevExpress.XtraBars.BarButtonItem BarButtonItemNew;
		private DevExpress.XtraBars.BarButtonItem BarButtonItemDelete;
		private DevExpress.XtraBars.BarButtonItem BarButtonItemSave;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
		private DevExpress.XtraGrid.Columns.GridColumn colName;
		private DevExpress.XtraEditors.TextEdit TextEditFleetMgmtID;
		private DevExpress.XtraEditors.TextEdit TextEditName;
		private DevExpress.XtraGrid.Columns.GridColumn colID;
		private DevExpress.XtraGrid.Columns.GridColumn colName1;
		private DevExpress.XtraGrid.Columns.GridColumn colFleetMgmtID;
		private DevExpress.XtraGrid.Columns.GridColumn colFlexMgmtIPAddress;
		private DevExpress.XtraGrid.Columns.GridColumn colInService;
	}
}