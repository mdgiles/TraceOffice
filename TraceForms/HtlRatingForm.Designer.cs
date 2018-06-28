namespace TraceForms
{
    partial class HtlRatingForm
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
			System.Windows.Forms.Label dESCRIPLabel;
			System.Windows.Forms.Label starsLabel;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HtlRatingForm));
			this.GridControlLookup = new DevExpress.XtraGrid.GridControl();
			this.BindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.GridViewLookup = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumnCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumnDescrip = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colImage_Path = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colStars = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colHOTEL = new DevExpress.XtraGrid.Columns.GridColumn();
			this.TextEditDescrip = new DevExpress.XtraEditors.TextEdit();
			this.TextEditCode = new DevExpress.XtraEditors.TextEdit();
			this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.SplitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
			this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
			this.ButtonEditImagePath = new DevExpress.XtraEditors.ButtonEdit();
			this.PictureEdit = new DevExpress.XtraEditors.PictureEdit();
			this.RatingControlStars = new DevExpress.XtraEditors.RatingControl();
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
			this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
			cODELabel = new System.Windows.Forms.Label();
			dESCRIPLabel = new System.Windows.Forms.Label();
			starsLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.GridControlLookup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridViewLookup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditDescrip.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl)).BeginInit();
			this.SplitContainerControl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ButtonEditImagePath.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PictureEdit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RatingControlStars.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PanelControlStatus)).BeginInit();
			this.PanelControlStatus.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
			this.SuspendLayout();
			// 
			// cODELabel
			// 
			cODELabel.AutoSize = true;
			cODELabel.Location = new System.Drawing.Point(64, 62);
			cODELabel.Name = "cODELabel";
			cODELabel.Size = new System.Drawing.Size(32, 13);
			cODELabel.TabIndex = 8;
			cODELabel.Text = "Code";
			// 
			// dESCRIPLabel
			// 
			dESCRIPLabel.AutoSize = true;
			dESCRIPLabel.Location = new System.Drawing.Point(64, 116);
			dESCRIPLabel.Name = "dESCRIPLabel";
			dESCRIPLabel.Size = new System.Drawing.Size(60, 13);
			dESCRIPLabel.TabIndex = 10;
			dESCRIPLabel.Text = "Description";
			// 
			// starsLabel
			// 
			starsLabel.AutoSize = true;
			starsLabel.Location = new System.Drawing.Point(64, 157);
			starsLabel.Name = "starsLabel";
			starsLabel.Size = new System.Drawing.Size(36, 13);
			starsLabel.TabIndex = 13;
			starsLabel.Text = "Stars:";
			// 
			// GridControlLookup
			// 
			this.GridControlLookup.DataSource = this.BindingSource;
			this.GridControlLookup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GridControlLookup.Location = new System.Drawing.Point(0, 0);
			this.GridControlLookup.MainView = this.GridViewLookup;
			this.GridControlLookup.Name = "GridControlLookup";
			this.GridControlLookup.Size = new System.Drawing.Size(253, 711);
			this.GridControlLookup.TabIndex = 12;
			this.GridControlLookup.TabStop = false;
			this.GridControlLookup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewLookup});
			// 
			// BindingSource
			// 
			this.BindingSource.DataSource = typeof(FlexModel.HTLRATNG);
			this.BindingSource.CurrentChanged += new System.EventHandler(this.HtlRatingBindingSource_CurrentChanged);
			// 
			// GridViewLookup
			// 
			this.GridViewLookup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDisplayName,
            this.GridColumnCode,
            this.GridColumnDescrip,
            this.colImage_Path,
            this.colStars,
            this.colHOTEL});
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
			this.GridColumnCode.OptionsColumn.AllowEdit = false;
			this.GridColumnCode.Visible = true;
			this.GridColumnCode.VisibleIndex = 0;
			// 
			// GridColumnDescrip
			// 
			this.GridColumnDescrip.FieldName = "DESCRIP";
			this.GridColumnDescrip.Name = "GridColumnDescrip";
			this.GridColumnDescrip.OptionsColumn.AllowEdit = false;
			this.GridColumnDescrip.Visible = true;
			this.GridColumnDescrip.VisibleIndex = 1;
			// 
			// colImage_Path
			// 
			this.colImage_Path.FieldName = "Image_Path";
			this.colImage_Path.Name = "colImage_Path";
			// 
			// colStars
			// 
			this.colStars.FieldName = "Stars";
			this.colStars.Name = "colStars";
			// 
			// colHOTEL
			// 
			this.colHOTEL.FieldName = "HOTEL";
			this.colHOTEL.Name = "colHOTEL";
			// 
			// TextEditDescrip
			// 
			this.TextEditDescrip.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "DESCRIP", true));
			this.TextEditDescrip.EnterMoveNextControl = true;
			this.TextEditDescrip.Location = new System.Drawing.Point(149, 109);
			this.TextEditDescrip.Name = "TextEditDescrip";
			this.TextEditDescrip.Properties.MaxLength = 12;
			this.TextEditDescrip.Size = new System.Drawing.Size(129, 20);
			this.TextEditDescrip.TabIndex = 2;
			this.TextEditDescrip.Leave += new System.EventHandler(this.TextEditDescrip_Leave);
			// 
			// TextEditCode
			// 
			this.TextEditCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "CODE", true));
			this.TextEditCode.EnterMoveNextControl = true;
			this.TextEditCode.Location = new System.Drawing.Point(149, 59);
			this.TextEditCode.Name = "TextEditCode";
			this.TextEditCode.Properties.MaxLength = 2;
			this.TextEditCode.Size = new System.Drawing.Size(132, 20);
			this.TextEditCode.TabIndex = 1;
			this.TextEditCode.Leave += new System.EventHandler(this.TextEditCode_Leave);
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
			this.SplitContainerControl.Panel2.Controls.Add(this.labelControl7);
			this.SplitContainerControl.Panel2.Controls.Add(this.labelControl8);
			this.SplitContainerControl.Panel2.Controls.Add(this.ButtonEditImagePath);
			this.SplitContainerControl.Panel2.Controls.Add(this.PictureEdit);
			this.SplitContainerControl.Panel2.Controls.Add(starsLabel);
			this.SplitContainerControl.Panel2.Controls.Add(this.TextEditCode);
			this.SplitContainerControl.Panel2.Controls.Add(this.TextEditDescrip);
			this.SplitContainerControl.Panel2.Controls.Add(dESCRIPLabel);
			this.SplitContainerControl.Panel2.Controls.Add(cODELabel);
			this.SplitContainerControl.Panel2.Controls.Add(this.RatingControlStars);
			this.SplitContainerControl.Panel2.Text = "Panel2";
			this.SplitContainerControl.Size = new System.Drawing.Size(1020, 711);
			this.SplitContainerControl.SplitterPosition = 253;
			this.SplitContainerControl.TabIndex = 8;
			this.SplitContainerControl.Text = "splitContainerControl1";
			// 
			// labelControl7
			// 
			this.labelControl7.Location = new System.Drawing.Point(67, 198);
			this.labelControl7.Name = "labelControl7";
			this.labelControl7.Size = new System.Drawing.Size(55, 13);
			this.labelControl7.TabIndex = 49;
			this.labelControl7.Text = "Image Path";
			// 
			// labelControl8
			// 
			this.labelControl8.Location = new System.Drawing.Point(67, 230);
			this.labelControl8.Name = "labelControl8";
			this.labelControl8.Size = new System.Drawing.Size(38, 13);
			this.labelControl8.TabIndex = 50;
			this.labelControl8.Text = "Preview";
			// 
			// ButtonEditImagePath
			// 
			this.ButtonEditImagePath.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Stars", true));
			this.ButtonEditImagePath.EnterMoveNextControl = true;
			this.ButtonEditImagePath.Location = new System.Drawing.Point(149, 195);
			this.ButtonEditImagePath.Name = "ButtonEditImagePath";
			this.ButtonEditImagePath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.ButtonEditImagePath.Properties.MaxLength = 255;
			this.ButtonEditImagePath.Size = new System.Drawing.Size(152, 20);
			this.ButtonEditImagePath.TabIndex = 47;
			this.ButtonEditImagePath.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonEditImagePath_ButtonPressed);
			this.ButtonEditImagePath.TextChanged += new System.EventHandler(this.ButtonEditImagePath_TextChanged);
			// 
			// PictureEdit
			// 
			this.PictureEdit.Cursor = System.Windows.Forms.Cursors.Default;
			this.PictureEdit.Location = new System.Drawing.Point(149, 230);
			this.PictureEdit.Name = "PictureEdit";
			this.PictureEdit.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.PictureEdit.Properties.Appearance.Options.UseBackColor = true;
			this.PictureEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.PictureEdit.Properties.PictureAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.PictureEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
			this.PictureEdit.Size = new System.Drawing.Size(152, 141);
			this.PictureEdit.TabIndex = 48;
			// 
			// RatingControlStars
			// 
			this.RatingControlStars.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Stars", true));
			this.RatingControlStars.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.RatingControlStars.Location = new System.Drawing.Point(149, 157);
			this.RatingControlStars.Name = "RatingControlStars";
			this.RatingControlStars.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
			this.RatingControlStars.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
			this.RatingControlStars.Rating = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.RatingControlStars.Size = new System.Drawing.Size(89, 18);
			this.RatingControlStars.TabIndex = 14;
			this.RatingControlStars.Text = "0";
			this.RatingControlStars.Leave += new System.EventHandler(this.RatingControlStars_Leave);
			// 
			// PanelControlStatus
			// 
			this.PanelControlStatus.Appearance.Options.UseTextOptions = true;
			this.PanelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("PanelControlStatus.ContentImage")));
			this.PanelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			this.PanelControlStatus.Controls.Add(this.LabelStatus);
			this.PanelControlStatus.Location = new System.Drawing.Point(310, 2);
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
			// HtlRatingForm
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
			this.Name = "HtlRatingForm";
			this.ShowInTaskbar = false;
			this.Text = "Hotel Rating";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HtlRatingForm_FormClosing);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HtlRatingForm_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.GridControlLookup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridViewLookup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditDescrip.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl)).EndInit();
			this.SplitContainerControl.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ButtonEditImagePath.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PictureEdit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RatingControlStars.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PanelControlStatus)).EndInit();
			this.PanelControlStatus.ResumeLayout(false);
			this.PanelControlStatus.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl GridControlLookup;
        private System.Windows.Forms.BindingSource BindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewLookup;
        private DevExpress.XtraEditors.TextEdit TextEditDescrip;
        private DevExpress.XtraEditors.TextEdit TextEditCode;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private DevExpress.XtraEditors.SplitContainerControl SplitContainerControl;
        private DevExpress.XtraEditors.PanelControl PanelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplayName;
        private DevExpress.XtraGrid.Columns.GridColumn GridColumnCode;
        private DevExpress.XtraGrid.Columns.GridColumn GridColumnDescrip;
        private DevExpress.XtraGrid.Columns.GridColumn colImage_Path;
        private DevExpress.XtraGrid.Columns.GridColumn colStars;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTEL;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarManager BarManager;
		private DevExpress.XtraBars.Bar bar1;
		private DevExpress.XtraBars.BarButtonItem BarButtonItemNew;
		private DevExpress.XtraBars.BarButtonItem BarButtonItemDelete;
		private DevExpress.XtraBars.BarButtonItem BarButtonItemSave;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
		private DevExpress.XtraEditors.RatingControl RatingControlStars;
		private DevExpress.XtraEditors.LabelControl labelControl7;
		private DevExpress.XtraEditors.LabelControl labelControl8;
		private DevExpress.XtraEditors.ButtonEdit ButtonEditImagePath;
		private DevExpress.XtraEditors.PictureEdit PictureEdit;
		private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
	}
}