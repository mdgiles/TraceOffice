namespace TraceForms
{
    partial class HtlTypeForm
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
            System.Windows.Forms.Label cODELabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HtlTypeForm));
            this.GridControlLookup = new DevExpress.XtraGrid.GridControl();
            this.BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GridViewLookup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumnCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumnDescrip = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOTEL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TextEditCode = new DevExpress.XtraEditors.TextEdit();
            this.TextEditDescrip = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
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
            dESCRIPLabel = new System.Windows.Forms.Label();
            cODELabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditDescrip.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl)).BeginInit();
            this.SplitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlStatus)).BeginInit();
            this.PanelControlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            this.SuspendLayout();
            // 
            // dESCRIPLabel
            // 
            dESCRIPLabel.AutoSize = true;
            dESCRIPLabel.Location = new System.Drawing.Point(142, 248);
            dESCRIPLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            dESCRIPLabel.Name = "dESCRIPLabel";
            dESCRIPLabel.Size = new System.Drawing.Size(116, 25);
            dESCRIPLabel.TabIndex = 20;
            dESCRIPLabel.Text = "Description";
            // 
            // cODELabel
            // 
            cODELabel.AutoSize = true;
            cODELabel.Location = new System.Drawing.Point(142, 175);
            cODELabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            cODELabel.Name = "cODELabel";
            cODELabel.Size = new System.Drawing.Size(59, 25);
            cODELabel.TabIndex = 19;
            cODELabel.Text = "Code";
            // 
            // GridControlLookup
            // 
            this.GridControlLookup.DataSource = this.BindingSource;
            this.GridControlLookup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControlLookup.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6);
            this.GridControlLookup.Location = new System.Drawing.Point(0, 0);
            this.GridControlLookup.MainView = this.GridViewLookup;
            this.GridControlLookup.Margin = new System.Windows.Forms.Padding(6);
            this.GridControlLookup.Name = "GridControlLookup";
            this.GridControlLookup.Size = new System.Drawing.Size(596, 1367);
            this.GridControlLookup.TabIndex = 16;
            this.GridControlLookup.TabStop = false;
            this.GridControlLookup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewLookup});
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(FlexModel.HTLTYPE);
            this.BindingSource.CurrentChanged += new System.EventHandler(this.HtlTypeBindingSource_CurrentChanged);
            // 
            // GridViewLookup
            // 
            this.GridViewLookup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDisplayName,
            this.GridColumnCode,
            this.GridColumnDescrip,
            this.colHOTEL});
            this.GridViewLookup.GridControl = this.GridControlLookup;
            this.GridViewLookup.Name = "GridViewLookup";
            this.GridViewLookup.OptionsBehavior.Editable = false;
            this.GridViewLookup.OptionsView.ShowAutoFilterRow = true;
            this.GridViewLookup.OptionsView.ShowGroupPanel = false;
            this.GridViewLookup.OptionsView.ShowIndicator = false;
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
            // GridColumnDescrip
            // 
            this.GridColumnDescrip.FieldName = "DESCRIP";
            this.GridColumnDescrip.Name = "GridColumnDescrip";
            this.GridColumnDescrip.Visible = true;
            this.GridColumnDescrip.VisibleIndex = 1;
            // 
            // colHOTEL
            // 
            this.colHOTEL.FieldName = "HOTEL";
            this.colHOTEL.Name = "colHOTEL";
            // 
            // TextEditCode
            // 
            this.TextEditCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CODE", true));
            this.TextEditCode.EnterMoveNextControl = true;
            this.TextEditCode.Location = new System.Drawing.Point(288, 169);
            this.TextEditCode.Margin = new System.Windows.Forms.Padding(6);
            this.TextEditCode.Name = "TextEditCode";
            this.TextEditCode.Properties.MaxLength = 3;
            this.TextEditCode.Size = new System.Drawing.Size(200, 34);
            this.TextEditCode.TabIndex = 1;
            this.TextEditCode.Leave += new System.EventHandler(this.TextEditCode_Leave);
            // 
            // TextEditDescrip
            // 
            this.TextEditDescrip.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "DESCRIP", true));
            this.TextEditDescrip.EnterMoveNextControl = true;
            this.TextEditDescrip.Location = new System.Drawing.Point(288, 242);
            this.TextEditDescrip.Margin = new System.Windows.Forms.Padding(6);
            this.TextEditDescrip.Name = "TextEditDescrip";
            this.TextEditDescrip.Properties.MaxLength = 12;
            this.TextEditDescrip.Size = new System.Drawing.Size(344, 34);
            this.TextEditDescrip.TabIndex = 2;
            this.TextEditDescrip.Leave += new System.EventHandler(this.TextEditDescrip_Leave);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(120, 62);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(100, 25);
            this.labelControl1.TabIndex = 18;
            this.labelControl1.Text = "Hotel Type";
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // SplitContainerControl
            // 
            this.SplitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerControl.Location = new System.Drawing.Point(0, 60);
            this.SplitContainerControl.Margin = new System.Windows.Forms.Padding(6);
            this.SplitContainerControl.Name = "SplitContainerControl";
            this.SplitContainerControl.Panel1.AutoScroll = true;
            this.SplitContainerControl.Panel1.Controls.Add(this.GridControlLookup);
            this.SplitContainerControl.Panel1.Text = "Panel1";
            this.SplitContainerControl.Panel2.AutoScroll = true;
            this.SplitContainerControl.Panel2.Controls.Add(dESCRIPLabel);
            this.SplitContainerControl.Panel2.Controls.Add(this.TextEditCode);
            this.SplitContainerControl.Panel2.Controls.Add(cODELabel);
            this.SplitContainerControl.Panel2.Controls.Add(this.TextEditDescrip);
            this.SplitContainerControl.Panel2.Controls.Add(this.labelControl1);
            this.SplitContainerControl.Panel2.Text = "Panel2";
            this.SplitContainerControl.Size = new System.Drawing.Size(2040, 1367);
            this.SplitContainerControl.SplitterPosition = 596;
            this.SplitContainerControl.TabIndex = 18;
            this.SplitContainerControl.Text = "SplitContainerControl";
            // 
            // PanelControlStatus
            // 
            this.PanelControlStatus.Appearance.Options.UseTextOptions = true;
            this.PanelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("PanelControlStatus.ContentImage")));
            this.PanelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.PanelControlStatus.Controls.Add(this.LabelStatus);
            this.PanelControlStatus.Location = new System.Drawing.Point(656, 4);
            this.PanelControlStatus.Margin = new System.Windows.Forms.Padding(6);
            this.PanelControlStatus.Name = "PanelControlStatus";
            this.PanelControlStatus.Size = new System.Drawing.Size(240, 44);
            this.PanelControlStatus.TabIndex = 265;
            this.PanelControlStatus.Visible = false;
            // 
            // LabelStatus
            // 
            this.LabelStatus.Location = new System.Drawing.Point(60, 10);
            this.LabelStatus.Margin = new System.Windows.Forms.Padding(6);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(0, 25);
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
            this.barDockControlTop.Size = new System.Drawing.Size(2040, 60);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 1427);
            this.barDockControlBottom.Manager = this.BarManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(2040, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 60);
            this.barDockControlLeft.Manager = this.BarManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 1367);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(2040, 60);
            this.barDockControlRight.Manager = this.BarManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 1367);
            // 
            // HtlTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2040, 1427);
            this.Controls.Add(this.PanelControlStatus);
            this.Controls.Add(this.SplitContainerControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimizeBox = false;
            this.Name = "HtlTypeForm";
            this.ShowInTaskbar = false;
            this.Text = "Hotel Type";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HtlTypeForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HtlTypeForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.GridControlLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditDescrip.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit TextEditDescrip;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private DevExpress.XtraEditors.SplitContainerControl SplitContainerControl;
        private DevExpress.XtraEditors.PanelControl PanelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplayName;
        private DevExpress.XtraGrid.Columns.GridColumn GridColumnCode;
        private DevExpress.XtraGrid.Columns.GridColumn GridColumnDescrip;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTEL;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager BarManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem BarButtonItemNew;
        private DevExpress.XtraBars.BarButtonItem BarButtonItemDelete;
        private DevExpress.XtraBars.BarButtonItem BarButtonItemSave;
    }
}