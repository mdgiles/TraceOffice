namespace TraceForms
{
    partial class ServTypeForm
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
			System.Windows.Forms.Label dESCRIPLabel;
			System.Windows.Forms.Label LabelType;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServTypeForm));
			this.GridControlServType = new DevExpress.XtraGrid.GridControl();
			this.ServTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.GridViewServType = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colTYPE = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colLINKTYPE = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCOMP = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSERVTYPE1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSERVTYPE2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCOMP1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.TextEditType = new DevExpress.XtraEditors.TextEdit();
			this.dESCRIPTextBox = new DevExpress.XtraEditors.TextEdit();
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
			dESCRIPLabel = new System.Windows.Forms.Label();
			LabelType = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.GridControlServType)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ServTypeBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridViewServType)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditType.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dESCRIPTextBox.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
			this.splitContainerControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).BeginInit();
			this.panelControlStatus.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
			this.SuspendLayout();
			// 
			// dESCRIPLabel
			// 
			dESCRIPLabel.AutoSize = true;
			dESCRIPLabel.Location = new System.Drawing.Point(38, 117);
			dESCRIPLabel.Name = "dESCRIPLabel";
			dESCRIPLabel.Size = new System.Drawing.Size(60, 13);
			dESCRIPLabel.TabIndex = 16;
			dESCRIPLabel.Text = "Description";
			// 
			// LabelType
			// 
			LabelType.AutoSize = true;
			LabelType.Location = new System.Drawing.Point(38, 91);
			LabelType.Name = "LabelType";
			LabelType.Size = new System.Drawing.Size(32, 13);
			LabelType.TabIndex = 15;
			LabelType.Text = "Code";
			// 
			// GridControlServType
			// 
			this.GridControlServType.DataSource = this.ServTypeBindingSource;
			this.GridControlServType.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GridControlServType.Location = new System.Drawing.Point(0, 0);
			this.GridControlServType.MainView = this.GridViewServType;
			this.GridControlServType.Name = "GridControlServType";
			this.GridControlServType.Size = new System.Drawing.Size(297, 711);
			this.GridControlServType.TabIndex = 14;
			this.GridControlServType.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewServType});
			// 
			// ServTypeBindingSource
			// 
			this.ServTypeBindingSource.DataSource = typeof(FlexModel.SERVTYPE);
			this.ServTypeBindingSource.CurrentChanged += new System.EventHandler(this.ServTypeBindingSource_CurrentChanged);
			// 
			// GridViewServType
			// 
			this.GridViewServType.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTYPE,
            this.GridColumnName,
            this.colLINKTYPE,
            this.colCOMP,
            this.colSERVTYPE1,
            this.colSERVTYPE2,
            this.colCOMP1,
            this.colDisplayName});
			this.GridViewServType.GridControl = this.GridControlServType;
			this.GridViewServType.Name = "GridViewServType";
			this.GridViewServType.OptionsView.ShowAutoFilterRow = true;
			this.GridViewServType.OptionsView.ShowGroupPanel = false;
			this.GridViewServType.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
			this.GridViewServType.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
			this.GridViewServType.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView1_BeforeLeaveRow);
			// 
			// colTYPE
			// 
			this.colTYPE.Caption = "Code";
			this.colTYPE.FieldName = "TYPE";
			this.colTYPE.Name = "colTYPE";
			this.colTYPE.Visible = true;
			this.colTYPE.VisibleIndex = 0;
			// 
			// GridColumnName
			// 
			this.GridColumnName.Caption = "Name";
			this.GridColumnName.FieldName = "DESCRIP";
			this.GridColumnName.Name = "GridColumnName";
			this.GridColumnName.Visible = true;
			this.GridColumnName.VisibleIndex = 1;
			// 
			// colLINKTYPE
			// 
			this.colLINKTYPE.FieldName = "LINKTYPE";
			this.colLINKTYPE.Name = "colLINKTYPE";
			// 
			// colCOMP
			// 
			this.colCOMP.FieldName = "COMP";
			this.colCOMP.Name = "colCOMP";
			// 
			// colSERVTYPE1
			// 
			this.colSERVTYPE1.FieldName = "SERVTYPE1";
			this.colSERVTYPE1.Name = "colSERVTYPE1";
			// 
			// colSERVTYPE2
			// 
			this.colSERVTYPE2.FieldName = "SERVTYPE2";
			this.colSERVTYPE2.Name = "colSERVTYPE2";
			// 
			// colCOMP1
			// 
			this.colCOMP1.FieldName = "COMP1";
			this.colCOMP1.Name = "colCOMP1";
			// 
			// colDisplayName
			// 
			this.colDisplayName.FieldName = "DisplayName";
			this.colDisplayName.Name = "colDisplayName";
			this.colDisplayName.OptionsColumn.ReadOnly = true;
			// 
			// TextEditType
			// 
			this.TextEditType.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ServTypeBindingSource, "TYPE", true));
			this.TextEditType.Location = new System.Drawing.Point(103, 88);
			this.TextEditType.Name = "TextEditType";
			this.TextEditType.Properties.MaxLength = 5;
			this.TextEditType.Size = new System.Drawing.Size(100, 20);
			this.TextEditType.TabIndex = 19;
			this.TextEditType.Enter += new System.EventHandler(this.enterControl);
			this.TextEditType.Leave += new System.EventHandler(this.type_Leave);
			// 
			// dESCRIPTextBox
			// 
			this.dESCRIPTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ServTypeBindingSource, "DESCRIP", true));
			this.dESCRIPTextBox.Location = new System.Drawing.Point(103, 114);
			this.dESCRIPTextBox.Name = "dESCRIPTextBox";
			this.dESCRIPTextBox.Properties.MaxLength = 60;
			this.dESCRIPTextBox.Size = new System.Drawing.Size(285, 20);
			this.dESCRIPTextBox.TabIndex = 17;
			this.dESCRIPTextBox.Enter += new System.EventHandler(this.enterControl);
			this.dESCRIPTextBox.Leave += new System.EventHandler(this.dESCRIPTextBox_Leave);
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
			this.splitContainerControl1.Panel1.Controls.Add(this.GridControlServType);
			this.splitContainerControl1.Panel1.Text = "Panel1";
			this.splitContainerControl1.Panel2.AutoScroll = true;
			this.splitContainerControl1.Panel2.Controls.Add(dESCRIPLabel);
			this.splitContainerControl1.Panel2.Controls.Add(this.TextEditType);
			this.splitContainerControl1.Panel2.Controls.Add(LabelType);
			this.splitContainerControl1.Panel2.Controls.Add(this.dESCRIPTextBox);
			this.splitContainerControl1.Panel2.Text = "Panel2";
			this.splitContainerControl1.Size = new System.Drawing.Size(1020, 711);
			this.splitContainerControl1.SplitterPosition = 297;
			this.splitContainerControl1.TabIndex = 21;
			this.splitContainerControl1.Text = "splitContainerControl1";
			// 
			// panelControlStatus
			// 
			this.panelControlStatus.Appearance.Options.UseTextOptions = true;
			this.panelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("panelControlStatus.ContentImage")));
			this.panelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			this.panelControlStatus.Controls.Add(this.LabelStatus);
			this.panelControlStatus.Location = new System.Drawing.Point(313, 2);
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
			// ServTypeForm
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
			this.Name = "ServTypeForm";
			this.ShowInTaskbar = false;
			this.Text = "Service Type";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServTypeForm_FormClosing);
			this.Enter += new System.EventHandler(this.enterControl);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ServTypeForm_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.GridControlServType)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ServTypeBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridViewServType)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditType.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dESCRIPTextBox.Properties)).EndInit();
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

        private DevExpress.XtraGrid.GridControl GridControlServType;
        private System.Windows.Forms.BindingSource ServTypeBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewServType;
        private DevExpress.XtraEditors.TextEdit TextEditType;
        private DevExpress.XtraEditors.TextEdit dESCRIPTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colTYPE;
        private DevExpress.XtraGrid.Columns.GridColumn GridColumnName;
        private DevExpress.XtraGrid.Columns.GridColumn colLINKTYPE;
        private DevExpress.XtraGrid.Columns.GridColumn colCOMP;
        private DevExpress.XtraGrid.Columns.GridColumn colSERVTYPE1;
        private DevExpress.XtraGrid.Columns.GridColumn colSERVTYPE2;
        private DevExpress.XtraGrid.Columns.GridColumn colCOMP1;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplayName;
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