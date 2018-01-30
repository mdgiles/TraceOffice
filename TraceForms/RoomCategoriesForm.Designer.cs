namespace TraceForms
{
    partial class RoomCategoriesForm
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
			System.Windows.Forms.Label longDescLabel;
			System.Windows.Forms.Label labelName;
			System.Windows.Forms.Label LabelCode;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomCategoriesForm));
			this.inhouseCheckEdit = new DevExpress.XtraEditors.CheckEdit();
			this.RoomCodBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.TextEditName = new DevExpress.XtraEditors.TextEdit();
			this.GridControlCategory = new DevExpress.XtraGrid.GridControl();
			this.GridViewRoomCod = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colCODE = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDESC = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colLongDesc = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInhouse = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCOMPROD = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCOMPROD2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCPRATES = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCXLFEE = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colHOTEL = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colHRATES = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colINVT = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPRATES = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSVCRESTR2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colhrates2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colhrates3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSupplierHotelRoomType = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.TextEditCode = new DevExpress.XtraEditors.TextEdit();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
			this.longDescTextBox = new DevExpress.XtraEditors.MemoEdit();
			this.panelControlStatus = new DevExpress.XtraEditors.PanelControl();
			this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
			this.barManager = new DevExpress.XtraBars.BarManager(this.components);
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			this.barTools = new DevExpress.XtraBars.Bar();
			this.barButtonItemNew = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItemDelete = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItemSave = new DevExpress.XtraBars.BarButtonItem();
			longDescLabel = new System.Windows.Forms.Label();
			labelName = new System.Windows.Forms.Label();
			LabelCode = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.inhouseCheckEdit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RoomCodBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridControlCategory)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridViewRoomCod)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
			this.splitContainerControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.longDescTextBox.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).BeginInit();
			this.panelControlStatus.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
			this.SuspendLayout();
			// 
			// longDescLabel
			// 
			longDescLabel.AutoSize = true;
			longDescLabel.Location = new System.Drawing.Point(58, 186);
			longDescLabel.Name = "longDescLabel";
			longDescLabel.Size = new System.Drawing.Size(86, 13);
			longDescLabel.TabIndex = 31;
			longDescLabel.Text = "Long Description";
			// 
			// labelName
			// 
			labelName.AutoSize = true;
			labelName.Location = new System.Drawing.Point(58, 150);
			labelName.Name = "labelName";
			labelName.Size = new System.Drawing.Size(34, 13);
			labelName.TabIndex = 28;
			labelName.Text = "Name";
			// 
			// LabelCode
			// 
			LabelCode.AutoSize = true;
			LabelCode.Location = new System.Drawing.Point(59, 110);
			LabelCode.Name = "LabelCode";
			LabelCode.Size = new System.Drawing.Size(32, 13);
			LabelCode.TabIndex = 27;
			LabelCode.Text = "Code";
			// 
			// inhouseCheckEdit
			// 
			this.inhouseCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.RoomCodBindingSource, "Inhouse", true));
			this.inhouseCheckEdit.Location = new System.Drawing.Point(59, 221);
			this.inhouseCheckEdit.Name = "inhouseCheckEdit";
			this.inhouseCheckEdit.Properties.Caption = "Inhouse";
			this.inhouseCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.inhouseCheckEdit.Size = new System.Drawing.Size(109, 19);
			this.inhouseCheckEdit.TabIndex = 4;
			this.inhouseCheckEdit.Click += new System.EventHandler(this.inhouseCheckEdit_Click);
			// 
			// RoomCodBindingSource
			// 
			this.RoomCodBindingSource.DataSource = typeof(FlexModel.ROOMCOD);
			this.RoomCodBindingSource.CurrentChanged += new System.EventHandler(this.RoomCodBindingSource_CurrentChanged);
			// 
			// TextEditName
			// 
			this.TextEditName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.RoomCodBindingSource, "DESC", true));
			this.TextEditName.Location = new System.Drawing.Point(154, 147);
			this.TextEditName.Name = "TextEditName";
			this.TextEditName.Properties.MaxLength = 60;
			this.TextEditName.Size = new System.Drawing.Size(466, 20);
			this.TextEditName.TabIndex = 2;
			this.TextEditName.Enter += new System.EventHandler(this.enterControl);
			this.TextEditName.Leave += new System.EventHandler(this.dESCTextBox_Leave);
			// 
			// GridControlCategory
			// 
			this.GridControlCategory.DataSource = this.RoomCodBindingSource;
			this.GridControlCategory.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GridControlCategory.Location = new System.Drawing.Point(0, 0);
			this.GridControlCategory.MainView = this.GridViewRoomCod;
			this.GridControlCategory.Name = "GridControlCategory";
			this.GridControlCategory.Size = new System.Drawing.Size(218, 561);
			this.GridControlCategory.TabIndex = 25;
			this.GridControlCategory.TabStop = false;
			this.GridControlCategory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewRoomCod});
			// 
			// GridViewRoomCod
			// 
			this.GridViewRoomCod.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCODE,
            this.colDESC,
            this.colLongDesc,
            this.colInhouse,
            this.colCOMPROD,
            this.colCOMPROD2,
            this.colCPRATES,
            this.colCXLFEE,
            this.colHOTEL,
            this.colHRATES,
            this.colINVT,
            this.colPRATES,
            this.colSVCRESTR2,
            this.colhrates2,
            this.colhrates3,
            this.colSupplierHotelRoomType,
            this.colDisplayName});
			this.GridViewRoomCod.GridControl = this.GridControlCategory;
			this.GridViewRoomCod.Name = "GridViewRoomCod";
			this.GridViewRoomCod.OptionsView.ShowAutoFilterRow = true;
			this.GridViewRoomCod.OptionsView.ShowGroupPanel = false;
			this.GridViewRoomCod.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
			this.GridViewRoomCod.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
			this.GridViewRoomCod.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView1_BeforeLeaveRow);
			// 
			// colCODE
			// 
			this.colCODE.Caption = "Code";
			this.colCODE.FieldName = "CODE";
			this.colCODE.Name = "colCODE";
			this.colCODE.Visible = true;
			this.colCODE.VisibleIndex = 0;
			// 
			// colDESC
			// 
			this.colDESC.Caption = "Name";
			this.colDESC.FieldName = "DESC";
			this.colDESC.Name = "colDESC";
			this.colDESC.Visible = true;
			this.colDESC.VisibleIndex = 1;
			// 
			// colLongDesc
			// 
			this.colLongDesc.FieldName = "LongDesc";
			this.colLongDesc.Name = "colLongDesc";
			// 
			// colInhouse
			// 
			this.colInhouse.FieldName = "Inhouse";
			this.colInhouse.Name = "colInhouse";
			// 
			// colCOMPROD
			// 
			this.colCOMPROD.FieldName = "COMPROD";
			this.colCOMPROD.Name = "colCOMPROD";
			// 
			// colCOMPROD2
			// 
			this.colCOMPROD2.FieldName = "COMPROD2";
			this.colCOMPROD2.Name = "colCOMPROD2";
			// 
			// colCPRATES
			// 
			this.colCPRATES.FieldName = "CPRATES";
			this.colCPRATES.Name = "colCPRATES";
			// 
			// colCXLFEE
			// 
			this.colCXLFEE.FieldName = "CXLFEE";
			this.colCXLFEE.Name = "colCXLFEE";
			// 
			// colHOTEL
			// 
			this.colHOTEL.FieldName = "HOTEL";
			this.colHOTEL.Name = "colHOTEL";
			// 
			// colHRATES
			// 
			this.colHRATES.FieldName = "HRATES";
			this.colHRATES.Name = "colHRATES";
			// 
			// colINVT
			// 
			this.colINVT.FieldName = "INVT";
			this.colINVT.Name = "colINVT";
			// 
			// colPRATES
			// 
			this.colPRATES.FieldName = "PRATES";
			this.colPRATES.Name = "colPRATES";
			// 
			// colSVCRESTR2
			// 
			this.colSVCRESTR2.FieldName = "SVCRESTR2";
			this.colSVCRESTR2.Name = "colSVCRESTR2";
			// 
			// colhrates2
			// 
			this.colhrates2.FieldName = "hrates2";
			this.colhrates2.Name = "colhrates2";
			// 
			// colhrates3
			// 
			this.colhrates3.FieldName = "hrates3";
			this.colhrates3.Name = "colhrates3";
			// 
			// colSupplierHotelRoomType
			// 
			this.colSupplierHotelRoomType.FieldName = "SupplierHotelRoomType";
			this.colSupplierHotelRoomType.Name = "colSupplierHotelRoomType";
			// 
			// colDisplayName
			// 
			this.colDisplayName.FieldName = "DisplayName";
			this.colDisplayName.Name = "colDisplayName";
			this.colDisplayName.OptionsColumn.ReadOnly = true;
			// 
			// TextEditCode
			// 
			this.TextEditCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.RoomCodBindingSource, "CODE", true));
			this.TextEditCode.Location = new System.Drawing.Point(154, 107);
			this.TextEditCode.Name = "TextEditCode";
			this.TextEditCode.Properties.MaxLength = 16;
			this.TextEditCode.Size = new System.Drawing.Size(149, 20);
			this.TextEditCode.TabIndex = 1;
			this.TextEditCode.Enter += new System.EventHandler(this.enterControl);
			this.TextEditCode.Leave += new System.EventHandler(this.codeTextEdit_Leave);
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			// 
			// splitContainerControl1
			// 
			this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl1.Location = new System.Drawing.Point(0, 31);
			this.splitContainerControl1.Name = "splitContainerControl1";
			this.splitContainerControl1.Panel1.AutoScroll = true;
			this.splitContainerControl1.Panel1.Controls.Add(this.GridControlCategory);
			this.splitContainerControl1.Panel1.Text = "Panel1";
			this.splitContainerControl1.Panel2.AutoScroll = true;
			this.splitContainerControl1.Panel2.Controls.Add(this.longDescTextBox);
			this.splitContainerControl1.Panel2.Controls.Add(this.inhouseCheckEdit);
			this.splitContainerControl1.Panel2.Controls.Add(this.TextEditCode);
			this.splitContainerControl1.Panel2.Controls.Add(longDescLabel);
			this.splitContainerControl1.Panel2.Controls.Add(LabelCode);
			this.splitContainerControl1.Panel2.Controls.Add(labelName);
			this.splitContainerControl1.Panel2.Controls.Add(this.TextEditName);
			this.splitContainerControl1.Panel2.Text = "Panel2";
			this.splitContainerControl1.Size = new System.Drawing.Size(1020, 561);
			this.splitContainerControl1.SplitterPosition = 218;
			this.splitContainerControl1.TabIndex = 27;
			this.splitContainerControl1.Text = "splitContainerControl1";
			// 
			// longDescTextBox
			// 
			this.longDescTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.RoomCodBindingSource, "LongDesc", true));
			this.longDescTextBox.Location = new System.Drawing.Point(154, 183);
			this.longDescTextBox.Name = "longDescTextBox";
			this.longDescTextBox.Properties.MaxLength = 255;
			this.longDescTextBox.Size = new System.Drawing.Size(466, 32);
			this.longDescTextBox.TabIndex = 32;
			this.longDescTextBox.Leave += new System.EventHandler(this.longDescTextBox_Leave);
			// 
			// panelControlStatus
			// 
			this.panelControlStatus.Appearance.Options.UseTextOptions = true;
			this.panelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("panelControlStatus.ContentImage")));
			this.panelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			this.panelControlStatus.Controls.Add(this.LabelStatus);
			this.panelControlStatus.Location = new System.Drawing.Point(339, 2);
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
			// barManager
			// 
			this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barTools});
			this.barManager.DockControls.Add(this.barDockControlTop);
			this.barManager.DockControls.Add(this.barDockControlBottom);
			this.barManager.DockControls.Add(this.barDockControlLeft);
			this.barManager.DockControls.Add(this.barDockControlRight);
			this.barManager.Form = this;
			this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemNew,
            this.barButtonItemDelete,
            this.barButtonItemSave});
			this.barManager.MaxItemId = 3;
			// 
			// barDockControlTop
			// 
			this.barDockControlTop.CausesValidation = false;
			this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
			this.barDockControlTop.Manager = this.barManager;
			this.barDockControlTop.Size = new System.Drawing.Size(1020, 31);
			// 
			// barDockControlBottom
			// 
			this.barDockControlBottom.CausesValidation = false;
			this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.barDockControlBottom.Location = new System.Drawing.Point(0, 592);
			this.barDockControlBottom.Manager = this.barManager;
			this.barDockControlBottom.Size = new System.Drawing.Size(1020, 0);
			// 
			// barDockControlLeft
			// 
			this.barDockControlLeft.CausesValidation = false;
			this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
			this.barDockControlLeft.Manager = this.barManager;
			this.barDockControlLeft.Size = new System.Drawing.Size(0, 561);
			// 
			// barDockControlRight
			// 
			this.barDockControlRight.CausesValidation = false;
			this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.barDockControlRight.Location = new System.Drawing.Point(1020, 31);
			this.barDockControlRight.Manager = this.barManager;
			this.barDockControlRight.Size = new System.Drawing.Size(0, 561);
			// 
			// barTools
			// 
			this.barTools.BarName = "Tools";
			this.barTools.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
			this.barTools.DockCol = 0;
			this.barTools.DockRow = 0;
			this.barTools.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
			this.barTools.FloatLocation = new System.Drawing.Point(61, 94);
			this.barTools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemNew),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemSave)});
			this.barTools.OptionsBar.AllowQuickCustomization = false;
			this.barTools.OptionsBar.DrawDragBorder = false;
			this.barTools.OptionsBar.UseWholeRow = true;
			this.barTools.Text = "Tools";
			// 
			// barButtonItemNew
			// 
			this.barButtonItemNew.Caption = "New";
			this.barButtonItemNew.Id = 0;
			this.barButtonItemNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
			this.barButtonItemNew.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
			this.barButtonItemNew.Name = "barButtonItemNew";
			this.barButtonItemNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemNew_ItemClick);
			// 
			// barButtonItemDelete
			// 
			this.barButtonItemDelete.Caption = "Delete";
			this.barButtonItemDelete.Id = 1;
			this.barButtonItemDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
			this.barButtonItemDelete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.LargeImage")));
			this.barButtonItemDelete.Name = "barButtonItemDelete";
			this.barButtonItemDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemDelete_ItemClick);
			// 
			// barButtonItemSave
			// 
			this.barButtonItemSave.Caption = "Save";
			this.barButtonItemSave.Id = 2;
			this.barButtonItemSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.Image")));
			this.barButtonItemSave.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.LargeImage")));
			this.barButtonItemSave.Name = "barButtonItemSave";
			this.barButtonItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSave_ItemClick);
			// 
			// RoomCategoriesForm
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
			this.Name = "RoomCategoriesForm";
			this.ShowInTaskbar = false;
			this.Text = "Room Categories";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RoomCategoriesForm_FormClosing);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RoomCategoriesForm_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.inhouseCheckEdit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RoomCodBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridControlCategory)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridViewRoomCod)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
			this.splitContainerControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.longDescTextBox.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).EndInit();
			this.panelControlStatus.ResumeLayout(false);
			this.panelControlStatus.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit inhouseCheckEdit;
		private System.Windows.Forms.BindingSource RoomCodBindingSource;
        private DevExpress.XtraEditors.TextEdit TextEditName;
        private DevExpress.XtraGrid.GridControl GridControlCategory;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewRoomCod;
        private DevExpress.XtraEditors.TextEdit TextEditCode;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colCODE;
        private DevExpress.XtraGrid.Columns.GridColumn colDESC;
        private DevExpress.XtraGrid.Columns.GridColumn colLongDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colInhouse;
        private DevExpress.XtraGrid.Columns.GridColumn colCOMPROD;
        private DevExpress.XtraGrid.Columns.GridColumn colCOMPROD2;
        private DevExpress.XtraGrid.Columns.GridColumn colCPRATES;
        private DevExpress.XtraGrid.Columns.GridColumn colCXLFEE;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTEL;
        private DevExpress.XtraGrid.Columns.GridColumn colHRATES;
        private DevExpress.XtraGrid.Columns.GridColumn colINVT;
        private DevExpress.XtraGrid.Columns.GridColumn colPRATES;
        private DevExpress.XtraGrid.Columns.GridColumn colSVCRESTR2;
        private DevExpress.XtraGrid.Columns.GridColumn colhrates2;
        private DevExpress.XtraGrid.Columns.GridColumn colhrates3;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplierHotelRoomType;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplayName;
		private DevExpress.XtraEditors.MemoEdit longDescTextBox;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarManager barManager;
		private DevExpress.XtraBars.Bar barTools;
		private DevExpress.XtraBars.BarButtonItem barButtonItemNew;
		private DevExpress.XtraBars.BarButtonItem barButtonItemDelete;
		private DevExpress.XtraBars.BarButtonItem barButtonItemSave;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
	}
}