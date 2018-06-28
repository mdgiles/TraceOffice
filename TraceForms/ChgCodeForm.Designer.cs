namespace TraceForms
{
    partial class ChgCodeForm
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
			System.Windows.Forms.Label CodeLabel;
			System.Windows.Forms.Label DescLabel;
			System.Windows.Forms.Label ConfirmLabel;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChgCodeForm));
			this.CheckEditConfirm = new DevExpress.XtraEditors.CheckEdit();
			this.BindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.TextEditCode = new DevExpress.XtraEditors.TextEdit();
			this.LabelControlChgCode = new DevExpress.XtraEditors.LabelControl();
			this.GridControlLookup = new DevExpress.XtraGrid.GridControl();
			this.GridViewLookup = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colConfirm = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumnCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumnDesc = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumnConfirm = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDATAFLEX_FILL_01 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDATAFLEX_FILL_02 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.TextEditDesc = new DevExpress.XtraEditors.TextEdit();
			this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.SplitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
			this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
			this.PanelControlStatus = new DevExpress.XtraEditors.PanelControl();
			this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
			this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
			this.bar1 = new DevExpress.XtraBars.Bar();
			this.BarButtonItemNew = new DevExpress.XtraBars.BarButtonItem();
			this.BarButtonItemDelete = new DevExpress.XtraBars.BarButtonItem();
			this.BarButtonItemSave = new DevExpress.XtraBars.BarButtonItem();
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			CodeLabel = new System.Windows.Forms.Label();
			DescLabel = new System.Windows.Forms.Label();
			ConfirmLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.CheckEditConfirm.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridControlLookup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridViewLookup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditDesc.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl)).BeginInit();
			this.SplitContainerControl.SuspendLayout();
			this.xtraScrollableControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PanelControlStatus)).BeginInit();
			this.PanelControlStatus.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
			this.SuspendLayout();
			// 
			// CodeLabel
			// 
			CodeLabel.AutoSize = true;
			CodeLabel.Location = new System.Drawing.Point(106, 143);
			CodeLabel.Name = "CodeLabel";
			CodeLabel.Size = new System.Drawing.Size(32, 13);
			CodeLabel.TabIndex = 11;
			CodeLabel.Text = "Code";
			// 
			// DescLabel
			// 
			DescLabel.AutoSize = true;
			DescLabel.Location = new System.Drawing.Point(106, 189);
			DescLabel.Name = "DescLabel";
			DescLabel.Size = new System.Drawing.Size(60, 13);
			DescLabel.TabIndex = 12;
			DescLabel.Text = "Description";
			// 
			// ConfirmLabel
			// 
			ConfirmLabel.AutoSize = true;
			ConfirmLabel.Location = new System.Drawing.Point(106, 225);
			ConfirmLabel.Name = "ConfirmLabel";
			ConfirmLabel.Size = new System.Drawing.Size(44, 13);
			ConfirmLabel.TabIndex = 18;
			ConfirmLabel.Text = "Confirm";
			// 
			// CheckEditConfirm
			// 
			this.CheckEditConfirm.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CONF", true));
			this.CheckEditConfirm.EnterMoveNextControl = true;
			this.CheckEditConfirm.Location = new System.Drawing.Point(181, 222);
			this.CheckEditConfirm.Name = "CheckEditConfirm";
			this.CheckEditConfirm.Properties.Caption = "";
			this.CheckEditConfirm.Properties.ValueChecked = "Y";
			this.CheckEditConfirm.Properties.ValueUnchecked = "N";
			this.CheckEditConfirm.Size = new System.Drawing.Size(22, 19);
			this.CheckEditConfirm.TabIndex = 3;
			this.CheckEditConfirm.Click += new System.EventHandler(this.CheckEditConfirm_Click);
			// 
			// BindingSource
			// 
			this.BindingSource.DataSource = typeof(FlexModel.CHGCODE);
			this.BindingSource.CurrentChanged += new System.EventHandler(this.BindingSource_CurrentChanged);
			// 
			// TextEditCode
			// 
			this.TextEditCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CODE", true));
			this.TextEditCode.EnterMoveNextControl = true;
			this.TextEditCode.Location = new System.Drawing.Point(177, 140);
			this.TextEditCode.Name = "TextEditCode";
			this.TextEditCode.Properties.MaxLength = 3;
			this.TextEditCode.Size = new System.Drawing.Size(152, 20);
			this.TextEditCode.TabIndex = 1;
			this.TextEditCode.Leave += new System.EventHandler(this.TextEditCode_Leave);
			// 
			// LabelControlChgCode
			// 
			this.LabelControlChgCode.Location = new System.Drawing.Point(84, 82);
			this.LabelControlChgCode.Name = "LabelControlChgCode";
			this.LabelControlChgCode.Size = new System.Drawing.Size(70, 13);
			this.LabelControlChgCode.TabIndex = 17;
			this.LabelControlChgCode.Text = "Change Codes";
			// 
			// GridControlLookup
			// 
			this.GridControlLookup.DataSource = this.BindingSource;
			this.GridControlLookup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GridControlLookup.Location = new System.Drawing.Point(0, 0);
			this.GridControlLookup.MainView = this.GridViewLookup;
			this.GridControlLookup.Name = "GridControlLookup";
			this.GridControlLookup.Size = new System.Drawing.Size(320, 711);
			this.GridControlLookup.TabIndex = 16;
			this.GridControlLookup.TabStop = false;
			this.GridControlLookup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewLookup});
			// 
			// GridViewLookup
			// 
			this.GridViewLookup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colConfirm,
            this.colDisplayName,
            this.GridColumnCode,
            this.GridColumnDesc,
            this.GridColumnConfirm,
            this.colDATAFLEX_FILL_01,
            this.colDATAFLEX_FILL_02});
			this.GridViewLookup.GridControl = this.GridControlLookup;
			this.GridViewLookup.Name = "GridViewLookup";
			this.GridViewLookup.OptionsView.ShowAutoFilterRow = true;
			this.GridViewLookup.OptionsView.ShowGroupPanel = false;
			this.GridViewLookup.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.GridViewLookup_BeforeLeaveRow);
			// 
			// colConfirm
			// 
			this.colConfirm.FieldName = "Confirm";
			this.colConfirm.Name = "colConfirm";
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
			this.GridColumnDesc.FieldName = "DESCRIPTION";
			this.GridColumnDesc.Name = "GridColumnDesc";
			this.GridColumnDesc.Visible = true;
			this.GridColumnDesc.VisibleIndex = 1;
			// 
			// GridColumnConfirm
			// 
			this.GridColumnConfirm.FieldName = "CONF";
			this.GridColumnConfirm.Name = "GridColumnConfirm";
			// 
			// colDATAFLEX_FILL_01
			// 
			this.colDATAFLEX_FILL_01.FieldName = "DATAFLEX_FILL_01";
			this.colDATAFLEX_FILL_01.Name = "colDATAFLEX_FILL_01";
			// 
			// colDATAFLEX_FILL_02
			// 
			this.colDATAFLEX_FILL_02.FieldName = "DATAFLEX_FILL_02";
			this.colDATAFLEX_FILL_02.Name = "colDATAFLEX_FILL_02";
			// 
			// TextEditDesc
			// 
			this.TextEditDesc.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "DESCRIPTION", true));
			this.TextEditDesc.EnterMoveNextControl = true;
			this.TextEditDesc.Location = new System.Drawing.Point(177, 186);
			this.TextEditDesc.Name = "TextEditDesc";
			this.TextEditDesc.Properties.MaxLength = 15;
			this.TextEditDesc.Size = new System.Drawing.Size(152, 20);
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
			this.SplitContainerControl.Location = new System.Drawing.Point(0, 0);
			this.SplitContainerControl.Name = "SplitContainerControl";
			this.SplitContainerControl.Panel1.AutoScroll = true;
			this.SplitContainerControl.Panel1.Controls.Add(this.GridControlLookup);
			this.SplitContainerControl.Panel1.Text = "Panel1";
			this.SplitContainerControl.Panel2.AutoScroll = true;
			this.SplitContainerControl.Panel2.Controls.Add(ConfirmLabel);
			this.SplitContainerControl.Panel2.Controls.Add(this.CheckEditConfirm);
			this.SplitContainerControl.Panel2.Controls.Add(this.TextEditCode);
			this.SplitContainerControl.Panel2.Controls.Add(this.TextEditDesc);
			this.SplitContainerControl.Panel2.Controls.Add(DescLabel);
			this.SplitContainerControl.Panel2.Controls.Add(this.LabelControlChgCode);
			this.SplitContainerControl.Panel2.Controls.Add(CodeLabel);
			this.SplitContainerControl.Panel2.Text = "Panel2";
			this.SplitContainerControl.Size = new System.Drawing.Size(1020, 711);
			this.SplitContainerControl.SplitterPosition = 320;
			this.SplitContainerControl.TabIndex = 1;
			this.SplitContainerControl.Text = "splitContainerControl1";
			// 
			// xtraScrollableControl1
			// 
			this.xtraScrollableControl1.Controls.Add(this.SplitContainerControl);
			this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 31);
			this.xtraScrollableControl1.Name = "xtraScrollableControl1";
			this.xtraScrollableControl1.Size = new System.Drawing.Size(1020, 711);
			this.xtraScrollableControl1.TabIndex = 20;
			// 
			// PanelControlStatus
			// 
			this.PanelControlStatus.Appearance.Options.UseTextOptions = true;
			this.PanelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("PanelControlStatus.ContentImage")));
			this.PanelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			this.PanelControlStatus.Controls.Add(this.LabelStatus);
			this.PanelControlStatus.Location = new System.Drawing.Point(326, 2);
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
            this.BarButtonItemNew,
            this.BarButtonItemDelete,
            this.BarButtonItemSave});
			this.barManager1.MaxItemId = 3;
			// 
			// bar1
			// 
			this.bar1.BarName = "Tools";
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
			// ChgCodeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1020, 742);
			this.Controls.Add(this.PanelControlStatus);
			this.Controls.Add(this.xtraScrollableControl1);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.KeyPreview = true;
			this.MinimizeBox = false;
			this.Name = "ChgCodeForm";
			this.ShowInTaskbar = false;
			this.Text = "Change Code Maintenance";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChgCodeForm_FormClosing);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChgCodeForm_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.CheckEditConfirm.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridControlLookup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridViewLookup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditDesc.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl)).EndInit();
			this.SplitContainerControl.ResumeLayout(false);
			this.xtraScrollableControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.PanelControlStatus)).EndInit();
			this.PanelControlStatus.ResumeLayout(false);
			this.PanelControlStatus.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit TextEditCode;
        private System.Windows.Forms.BindingSource BindingSource;
        private DevExpress.XtraEditors.LabelControl LabelControlChgCode;
        private DevExpress.XtraGrid.GridControl GridControlLookup;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewLookup;
        private DevExpress.XtraEditors.TextEdit TextEditDesc;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private DevExpress.XtraEditors.CheckEdit CheckEditConfirm;
        private DevExpress.XtraEditors.SplitContainerControl SplitContainerControl;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private DevExpress.XtraEditors.PanelControl PanelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colConfirm;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplayName;
        private DevExpress.XtraGrid.Columns.GridColumn GridColumnCode;
        private DevExpress.XtraGrid.Columns.GridColumn GridColumnDesc;
        private DevExpress.XtraGrid.Columns.GridColumn GridColumnConfirm;
        private DevExpress.XtraGrid.Columns.GridColumn colDATAFLEX_FILL_01;
        private DevExpress.XtraGrid.Columns.GridColumn colDATAFLEX_FILL_02;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarManager barManager1;
		private DevExpress.XtraBars.Bar bar1;
		private DevExpress.XtraBars.BarButtonItem BarButtonItemNew;
		private DevExpress.XtraBars.BarButtonItem BarButtonItemDelete;
		private DevExpress.XtraBars.BarButtonItem BarButtonItemSave;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
	}
}