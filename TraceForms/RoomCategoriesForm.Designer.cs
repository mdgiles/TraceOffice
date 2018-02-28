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
			this.BindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.TextEditName = new DevExpress.XtraEditors.TextEdit();
			this.GridControlLookup = new DevExpress.XtraGrid.GridControl();
			this.GridViewLookup = new DevExpress.XtraGrid.Views.Grid.GridView();
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
			this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
			this.TextBoxLongDescription = new DevExpress.XtraEditors.MemoEdit();
			this.PanelControlStatus = new DevExpress.XtraEditors.PanelControl();
			this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
			this.BarManager = new DevExpress.XtraBars.BarManager(this.components);
			this.barTools = new DevExpress.XtraBars.Bar();
			this.barButtonItemNew = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItemDelete = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItemSave = new DevExpress.XtraBars.BarButtonItem();
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			longDescLabel = new System.Windows.Forms.Label();
			labelName = new System.Windows.Forms.Label();
			LabelCode = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.inhouseCheckEdit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridControlLookup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridViewLookup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
			this.splitContainerControl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.TextBoxLongDescription.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PanelControlStatus)).BeginInit();
			this.PanelControlStatus.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
			this.SuspendLayout();
			// 
			// longDescLabel
			// 
			longDescLabel.AutoSize = true;
			longDescLabel.Location = new System.Drawing.Point(58, 157);
			longDescLabel.Name = "longDescLabel";
			longDescLabel.Size = new System.Drawing.Size(86, 13);
			longDescLabel.TabIndex = 31;
			longDescLabel.Text = "Long Description";
			// 
			// labelName
			// 
			labelName.AutoSize = true;
			labelName.Location = new System.Drawing.Point(59, 134);
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
			this.inhouseCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Inhouse", true));
			this.inhouseCheckEdit.Location = new System.Drawing.Point(59, 193);
			this.inhouseCheckEdit.Name = "inhouseCheckEdit";
			this.inhouseCheckEdit.Properties.Caption = "Inhouse";
			this.inhouseCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.inhouseCheckEdit.Size = new System.Drawing.Size(117, 19);
			this.inhouseCheckEdit.TabIndex = 4;
			// 
			// BindingSource
			// 
			this.BindingSource.DataSource = typeof(FlexModel.ROOMCOD);
			this.BindingSource.CurrentChanged += new System.EventHandler(this.BindingSource_CurrentChanged);
			// 
			// TextEditName
			// 
			this.TextEditName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "DESC", true));
			this.TextEditName.Location = new System.Drawing.Point(160, 132);
			this.TextEditName.Name = "TextEditName";
			this.TextEditName.Properties.MaxLength = 60;
			this.TextEditName.Size = new System.Drawing.Size(466, 20);
			this.TextEditName.TabIndex = 2;
			this.TextEditName.Leave += new System.EventHandler(this.TextEditName_Leave);
			// 
			// GridControlLookup
			// 
			this.GridControlLookup.DataSource = this.BindingSource;
			this.GridControlLookup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GridControlLookup.Location = new System.Drawing.Point(0, 0);
			this.GridControlLookup.MainView = this.GridViewLookup;
			this.GridControlLookup.Name = "GridControlLookup";
			this.GridControlLookup.Size = new System.Drawing.Size(218, 467);
			this.GridControlLookup.TabIndex = 25;
			this.GridControlLookup.TabStop = false;
			this.GridControlLookup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewLookup});
			// 
			// GridViewLookup
			// 
			this.GridViewLookup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
			this.GridViewLookup.GridControl = this.GridControlLookup;
			this.GridViewLookup.Name = "GridViewLookup";
			this.GridViewLookup.OptionsView.ShowAutoFilterRow = true;
			this.GridViewLookup.OptionsView.ShowGroupPanel = false;
			this.GridViewLookup.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.GridViewLookup_InvalidRowException);
			this.GridViewLookup.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.GridViewLookup_BeforeLeaveRow);
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
			this.TextEditCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CODE", true));
			this.TextEditCode.Location = new System.Drawing.Point(160, 108);
			this.TextEditCode.Name = "TextEditCode";
			this.TextEditCode.Properties.MaxLength = 16;
			this.TextEditCode.Size = new System.Drawing.Size(149, 20);
			this.TextEditCode.TabIndex = 1;
			this.TextEditCode.Leave += new System.EventHandler(this.TextEditCode_Leave);
			// 
			// ErrorProvider
			// 
			this.ErrorProvider.ContainerControl = this;
			// 
			// splitContainerControl
			// 
			this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl.Location = new System.Drawing.Point(0, 31);
			this.splitContainerControl.Name = "splitContainerControl";
			this.splitContainerControl.Panel1.AutoScroll = true;
			this.splitContainerControl.Panel1.Controls.Add(this.GridControlLookup);
			this.splitContainerControl.Panel1.Text = "Panel1";
			this.splitContainerControl.Panel2.AutoScroll = true;
			this.splitContainerControl.Panel2.Controls.Add(this.TextBoxLongDescription);
			this.splitContainerControl.Panel2.Controls.Add(this.inhouseCheckEdit);
			this.splitContainerControl.Panel2.Controls.Add(this.TextEditCode);
			this.splitContainerControl.Panel2.Controls.Add(longDescLabel);
			this.splitContainerControl.Panel2.Controls.Add(LabelCode);
			this.splitContainerControl.Panel2.Controls.Add(labelName);
			this.splitContainerControl.Panel2.Controls.Add(this.TextEditName);
			this.splitContainerControl.Panel2.Text = "Panel2";
			this.splitContainerControl.Size = new System.Drawing.Size(962, 467);
			this.splitContainerControl.SplitterPosition = 218;
			this.splitContainerControl.TabIndex = 27;
			this.splitContainerControl.Text = "SplitContainerControl";
			// 
			// TextBoxLongDescription
			// 
			this.TextBoxLongDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "LongDesc", true));
			this.TextBoxLongDescription.Location = new System.Drawing.Point(160, 155);
			this.TextBoxLongDescription.Name = "TextBoxLongDescription";
			this.TextBoxLongDescription.Properties.MaxLength = 255;
			this.TextBoxLongDescription.Size = new System.Drawing.Size(466, 32);
			this.TextBoxLongDescription.TabIndex = 32;
			this.TextBoxLongDescription.Leave += new System.EventHandler(this.TextEditLongDescription_Leave);
			// 
			// PanelControlStatus
			// 
			this.PanelControlStatus.Appearance.Options.UseTextOptions = true;
			this.PanelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("PanelControlStatus.ContentImage")));
			this.PanelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			this.PanelControlStatus.Controls.Add(this.LabelStatus);
			this.PanelControlStatus.Location = new System.Drawing.Point(339, 2);
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
            this.barTools});
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
			this.barDockControlTop.Size = new System.Drawing.Size(962, 31);
			// 
			// barDockControlBottom
			// 
			this.barDockControlBottom.CausesValidation = false;
			this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.barDockControlBottom.Location = new System.Drawing.Point(0, 498);
			this.barDockControlBottom.Manager = this.BarManager;
			this.barDockControlBottom.Size = new System.Drawing.Size(962, 0);
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
			this.barDockControlRight.Location = new System.Drawing.Point(962, 31);
			this.barDockControlRight.Manager = this.BarManager;
			this.barDockControlRight.Size = new System.Drawing.Size(0, 467);
			// 
			// RoomCategoriesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(962, 498);
			this.Controls.Add(this.PanelControlStatus);
			this.Controls.Add(this.splitContainerControl);
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
			((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridControlLookup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridViewLookup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
			this.splitContainerControl.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.TextBoxLongDescription.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PanelControlStatus)).EndInit();
			this.PanelControlStatus.ResumeLayout(false);
			this.PanelControlStatus.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit inhouseCheckEdit;
		private System.Windows.Forms.BindingSource BindingSource;
        private DevExpress.XtraEditors.TextEdit TextEditName;
        private DevExpress.XtraGrid.GridControl GridControlLookup;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewLookup;
        private DevExpress.XtraEditors.TextEdit TextEditCode;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraEditors.PanelControl PanelControlStatus;
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
		private DevExpress.XtraEditors.MemoEdit TextBoxLongDescription;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarManager BarManager;
		private DevExpress.XtraBars.Bar barTools;
		private DevExpress.XtraBars.BarButtonItem barButtonItemNew;
		private DevExpress.XtraBars.BarButtonItem barButtonItemDelete;
		private DevExpress.XtraBars.BarButtonItem barButtonItemSave;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
	}
}