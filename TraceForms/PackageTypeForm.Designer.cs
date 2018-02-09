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
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.PackTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.GridViewPackType = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPACK = new DevExpress.XtraGrid.Columns.GridColumn();
			this.TextEditCode = new DevExpress.XtraEditors.TextEdit();
			this.TextEditDesc = new DevExpress.XtraEditors.TextEdit();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
			this.panelControlStatus = new DevExpress.XtraEditors.PanelControl();
			this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
			this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			this.bar1 = new DevExpress.XtraBars.Bar();
			this.barButtonItemNew = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItemDelete = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItemSave = new DevExpress.XtraBars.BarButtonItem();
			dESCLabel = new System.Windows.Forms.Label();
			cODELabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PackTypeBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridViewPackType)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditDesc.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
			this.splitContainerControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).BeginInit();
			this.panelControlStatus.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
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
			// gridControl1
			// 
			this.gridControl1.DataSource = this.PackTypeBindingSource;
			this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridControl1.Location = new System.Drawing.Point(0, 0);
			this.gridControl1.MainView = this.GridViewPackType;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.Size = new System.Drawing.Size(319, 711);
			this.gridControl1.TabIndex = 13;
			this.gridControl1.TabStop = false;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewPackType});
			// 
			// PackTypeBindingSource
			// 
			this.PackTypeBindingSource.DataSource = typeof(FlexModel.PACKTYPE);
			this.PackTypeBindingSource.CurrentChanged += new System.EventHandler(this.PackTypeBindingSource_CurrentChanged);
			// 
			// GridViewPackType
			// 
			this.GridViewPackType.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDisplayName,
            this.gridColumnCode,
            this.gridColumnName,
            this.colPACK});
			this.GridViewPackType.GridControl = this.gridControl1;
			this.GridViewPackType.Name = "GridViewPackType";
			this.GridViewPackType.OptionsView.ShowAutoFilterRow = true;
			this.GridViewPackType.OptionsView.ShowGroupPanel = false;
			this.GridViewPackType.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
			this.GridViewPackType.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
			this.GridViewPackType.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView1_BeforeLeaveRow);
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
			this.TextEditCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.PackTypeBindingSource, "CODE", true));
			this.TextEditCode.Location = new System.Drawing.Point(126, 73);
			this.TextEditCode.Name = "TextEditCode";
			this.TextEditCode.Properties.MaxLength = 3;
			this.TextEditCode.Size = new System.Drawing.Size(126, 20);
			this.TextEditCode.TabIndex = 1;
			this.TextEditCode.Enter += new System.EventHandler(this.enterControl);
			this.TextEditCode.Leave += new System.EventHandler(this.code_Leave);
			// 
			// TextEditDesc
			// 
			this.TextEditDesc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.PackTypeBindingSource, "DESC", true));
			this.TextEditDesc.Location = new System.Drawing.Point(126, 109);
			this.TextEditDesc.Name = "TextEditDesc";
			this.TextEditDesc.Properties.MaxLength = 10;
			this.TextEditDesc.Size = new System.Drawing.Size(250, 20);
			this.TextEditDesc.TabIndex = 2;
			this.TextEditDesc.Enter += new System.EventHandler(this.enterControl);
			this.TextEditDesc.Leave += new System.EventHandler(this.DescTextBox_Leave);
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
			this.splitContainerControl1.Panel1.Controls.Add(this.gridControl1);
			this.splitContainerControl1.Panel1.Text = "Panel1";
			this.splitContainerControl1.Panel2.AutoScroll = true;
			this.splitContainerControl1.Panel2.Controls.Add(dESCLabel);
			this.splitContainerControl1.Panel2.Controls.Add(this.TextEditCode);
			this.splitContainerControl1.Panel2.Controls.Add(cODELabel);
			this.splitContainerControl1.Panel2.Controls.Add(this.TextEditDesc);
			this.splitContainerControl1.Panel2.Text = "Panel2";
			this.splitContainerControl1.Size = new System.Drawing.Size(1020, 711);
			this.splitContainerControl1.SplitterPosition = 319;
			this.splitContainerControl1.TabIndex = 15;
			this.splitContainerControl1.Text = "splitContainerControl1";
			// 
			// panelControlStatus
			// 
			this.panelControlStatus.Appearance.Options.UseTextOptions = true;
			this.panelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("panelControlStatus.ContentImage")));
			this.panelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			this.panelControlStatus.Controls.Add(this.LabelStatus);
			this.panelControlStatus.Location = new System.Drawing.Point(338, 2);
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
            this.bar1});
			this.barManager1.DockControls.Add(this.barDockControlTop);
			this.barManager1.DockControls.Add(this.barDockControlBottom);
			this.barManager1.DockControls.Add(this.barDockControlLeft);
			this.barManager1.DockControls.Add(this.barDockControlRight);
			this.barManager1.Form = this;
			this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemNew,
            this.barButtonItemDelete,
            this.barButtonItemSave});
			this.barManager1.MaxItemId = 3;
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
			this.barDockControlBottom.Location = new System.Drawing.Point(0, 742);
			this.barDockControlBottom.Manager = this.barManager1;
			this.barDockControlBottom.Size = new System.Drawing.Size(1020, 0);
			// 
			// barDockControlLeft
			// 
			this.barDockControlLeft.CausesValidation = false;
			this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
			this.barDockControlLeft.Manager = this.barManager1;
			this.barDockControlLeft.Size = new System.Drawing.Size(0, 711);
			// 
			// barDockControlRight
			// 
			this.barDockControlRight.CausesValidation = false;
			this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.barDockControlRight.Location = new System.Drawing.Point(1020, 31);
			this.barDockControlRight.Manager = this.barManager1;
			this.barDockControlRight.Size = new System.Drawing.Size(0, 711);
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
			this.barButtonItemNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemNew_ItemClick);
			// 
			// barButtonItemDelete
			// 
			this.barButtonItemDelete.Caption = "Delete";
			this.barButtonItemDelete.Id = 1;
			this.barButtonItemDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemDelete.ImageOptions.Image")));
			this.barButtonItemDelete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemDelete.ImageOptions.LargeImage")));
			this.barButtonItemDelete.Name = "barButtonItemDelete";
			this.barButtonItemDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemDelete_ItemClick);
			// 
			// barButtonItemSave
			// 
			this.barButtonItemSave.Caption = "Save";
			this.barButtonItemSave.Id = 2;
			this.barButtonItemSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemSave.ImageOptions.Image")));
			this.barButtonItemSave.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemSave.ImageOptions.LargeImage")));
			this.barButtonItemSave.Name = "barButtonItemSave";
			this.barButtonItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSave_ItemClick);
			// 
			// PackageTypeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1020, 742);
			this.Controls.Add(this.panelControlStatus);
			this.Controls.Add(this.splitContainerControl1);
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
			this.Enter += new System.EventHandler(this.enterControl);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PackageTypeForm_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PackTypeBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridViewPackType)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditDesc.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
			this.splitContainerControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).EndInit();
			this.panelControlStatus.ResumeLayout(false);
			this.panelControlStatus.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource PackTypeBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewPackType;
        private DevExpress.XtraEditors.TextEdit TextEditCode;
        private DevExpress.XtraEditors.TextEdit TextEditDesc;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplayName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnName;
        private DevExpress.XtraGrid.Columns.GridColumn colPACK;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarManager barManager1;
		private DevExpress.XtraBars.Bar bar1;
		private DevExpress.XtraBars.BarButtonItem barButtonItemNew;
		private DevExpress.XtraBars.BarButtonItem barButtonItemDelete;
		private DevExpress.XtraBars.BarButtonItem barButtonItemSave;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
	}
}