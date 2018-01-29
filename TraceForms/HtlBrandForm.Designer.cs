namespace TraceForms
{
    partial class HtlBrandForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HtlBrandForm));
            this.lOGO_PATHButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.HtlBrandBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cODETextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.logo = new DevExpress.XtraEditors.PictureEdit();
            this.dESCTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.GridControlHtlBrand = new DevExpress.XtraGrid.GridControl();
            this.GridViewHtlBrand = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colImagesRoot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDESC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCHAIN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLOGO_PATH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOTEL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHTLCHAIN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HtlBrandBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.hTLBRANDBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControlSizeDisplay = new DevExpress.XtraEditors.LabelControl();
            this.ImageComboBoxEditChain = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.panelControlStatus = new DevExpress.XtraEditors.PanelControl();
            this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.lOGO_PATHButtonEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HtlBrandBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cODETextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dESCTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlHtlBrand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewHtlBrand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HtlBrandBindingNavigator)).BeginInit();
            this.HtlBrandBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditChain.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).BeginInit();
            this.panelControlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // lOGO_PATHButtonEdit
            // 
            this.lOGO_PATHButtonEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.HtlBrandBindingSource, "LOGO_PATH", true));
            this.lOGO_PATHButtonEdit.EnterMoveNextControl = true;
            this.lOGO_PATHButtonEdit.Location = new System.Drawing.Point(101, 151);
            this.lOGO_PATHButtonEdit.Name = "lOGO_PATHButtonEdit";
            this.lOGO_PATHButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.lOGO_PATHButtonEdit.Properties.MaxLength = 255;
            this.lOGO_PATHButtonEdit.Size = new System.Drawing.Size(458, 20);
            this.lOGO_PATHButtonEdit.TabIndex = 4;
            this.lOGO_PATHButtonEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lOGO_PATHButtonEdit_ButtonPressed);
            this.lOGO_PATHButtonEdit.TextChanged += new System.EventHandler(this.lOGO_PATHTextEdit_TextChanged);
            this.lOGO_PATHButtonEdit.Enter += new System.EventHandler(this.enterControl);
            this.lOGO_PATHButtonEdit.Leave += new System.EventHandler(this.path_Leave);
            // 
            // HtlBrandBindingSource
            // 
            this.HtlBrandBindingSource.DataSource = typeof(FlexModel.HTLBRAND);
            this.HtlBrandBindingSource.CurrentChanged += new System.EventHandler(this.HtlBrandBindingSource_CurrentChanged);
            // 
            // cODETextEdit
            // 
            this.cODETextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.HtlBrandBindingSource, "CODE", true));
            this.cODETextEdit.EnterMoveNextControl = true;
            this.cODETextEdit.Location = new System.Drawing.Point(101, 57);
            this.cODETextEdit.Name = "cODETextEdit";
            this.cODETextEdit.Properties.MaxLength = 12;
            this.cODETextEdit.Size = new System.Drawing.Size(112, 20);
            this.cODETextEdit.TabIndex = 1;
            this.cODETextEdit.Enter += new System.EventHandler(this.enterControl);
            this.cODETextEdit.Leave += new System.EventHandler(this.cODETextEdit_Leave);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(57, 196);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(38, 13);
            this.labelControl5.TabIndex = 25;
            this.labelControl5.Text = "Preview";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(72, 155);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(23, 13);
            this.labelControl4.TabIndex = 24;
            this.labelControl4.Text = "Logo";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(70, 59);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(25, 13);
            this.labelControl3.TabIndex = 23;
            this.labelControl3.Text = "Code";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(68, 93);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(27, 13);
            this.labelControl2.TabIndex = 22;
            this.labelControl2.Text = "Chain";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(42, 125);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(53, 13);
            this.labelControl1.TabIndex = 21;
            this.labelControl1.Text = "Description";
            // 
            // logo
            // 
            this.logo.Location = new System.Drawing.Point(101, 196);
            this.logo.Name = "logo";
            this.logo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.logo.Properties.Appearance.Options.UseBackColor = true;
            this.logo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.logo.Properties.PictureAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.logo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.logo.Size = new System.Drawing.Size(225, 136);
            this.logo.TabIndex = 18;
            // 
            // dESCTextEdit
            // 
            this.dESCTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.HtlBrandBindingSource, "DESC", true));
            this.dESCTextEdit.EnterMoveNextControl = true;
            this.dESCTextEdit.Location = new System.Drawing.Point(101, 121);
            this.dESCTextEdit.Name = "dESCTextEdit";
            this.dESCTextEdit.Properties.MaxLength = 50;
            this.dESCTextEdit.Size = new System.Drawing.Size(313, 20);
            this.dESCTextEdit.TabIndex = 3;
            this.dESCTextEdit.Enter += new System.EventHandler(this.enterControl);
            this.dESCTextEdit.Leave += new System.EventHandler(this.dESCTextEdit_Leave);
            // 
            // GridControlHtlBrand
            // 
            this.GridControlHtlBrand.DataSource = this.HtlBrandBindingSource;
            this.GridControlHtlBrand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControlHtlBrand.Location = new System.Drawing.Point(0, 0);
            this.GridControlHtlBrand.MainView = this.GridViewHtlBrand;
            this.GridControlHtlBrand.Name = "GridControlHtlBrand";
            this.GridControlHtlBrand.Size = new System.Drawing.Size(409, 717);
            this.GridControlHtlBrand.TabIndex = 15;
            this.GridControlHtlBrand.TabStop = false;
            this.GridControlHtlBrand.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewHtlBrand});
            // 
            // GridViewHtlBrand
            // 
            this.GridViewHtlBrand.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colImagesRoot,
            this.colDisplayName,
            this.colCODE,
            this.colDESC,
            this.colCHAIN,
            this.colLOGO_PATH,
            this.colHOTEL,
            this.colHTLCHAIN});
            this.GridViewHtlBrand.GridControl = this.GridControlHtlBrand;
            this.GridViewHtlBrand.Name = "GridViewHtlBrand";
            this.GridViewHtlBrand.OptionsView.ShowAutoFilterRow = true;
            this.GridViewHtlBrand.OptionsView.ShowGroupPanel = false;
            this.GridViewHtlBrand.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            this.GridViewHtlBrand.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            this.GridViewHtlBrand.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView1_BeforeLeaveRow);
            // 
            // colImagesRoot
            // 
            this.colImagesRoot.FieldName = "ImagesRoot";
            this.colImagesRoot.Name = "colImagesRoot";
            // 
            // colDisplayName
            // 
            this.colDisplayName.FieldName = "DisplayName";
            this.colDisplayName.Name = "colDisplayName";
            this.colDisplayName.OptionsColumn.ReadOnly = true;
            // 
            // colCODE
            // 
            this.colCODE.FieldName = "CODE";
            this.colCODE.Name = "colCODE";
            this.colCODE.Visible = true;
            this.colCODE.VisibleIndex = 0;
            // 
            // colDESC
            // 
            this.colDESC.FieldName = "DESC";
            this.colDESC.Name = "colDESC";
            this.colDESC.Visible = true;
            this.colDESC.VisibleIndex = 1;
            // 
            // colCHAIN
            // 
            this.colCHAIN.FieldName = "CHAIN";
            this.colCHAIN.Name = "colCHAIN";
            this.colCHAIN.Visible = true;
            this.colCHAIN.VisibleIndex = 2;
            // 
            // colLOGO_PATH
            // 
            this.colLOGO_PATH.FieldName = "LOGO_PATH";
            this.colLOGO_PATH.Name = "colLOGO_PATH";
            // 
            // colHOTEL
            // 
            this.colHOTEL.FieldName = "HOTEL";
            this.colHOTEL.Name = "colHOTEL";
            // 
            // colHTLCHAIN
            // 
            this.colHTLCHAIN.FieldName = "HTLCHAIN";
            this.colHTLCHAIN.Name = "colHTLCHAIN";
            // 
            // HtlBrandBindingNavigator
            // 
            this.HtlBrandBindingNavigator.AddNewItem = null;
            this.HtlBrandBindingNavigator.BindingSource = this.HtlBrandBindingSource;
            this.HtlBrandBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.HtlBrandBindingNavigator.DeleteItem = null;
            this.HtlBrandBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.hTLBRANDBindingNavigatorSaveItem});
            this.HtlBrandBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.HtlBrandBindingNavigator.MoveFirstItem = null;
            this.HtlBrandBindingNavigator.MoveLastItem = null;
            this.HtlBrandBindingNavigator.MoveNextItem = null;
            this.HtlBrandBindingNavigator.MovePreviousItem = null;
            this.HtlBrandBindingNavigator.Name = "HtlBrandBindingNavigator";
            this.HtlBrandBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.HtlBrandBindingNavigator.Size = new System.Drawing.Size(1020, 25);
            this.HtlBrandBindingNavigator.TabIndex = 9;
            this.HtlBrandBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            this.bindingNavigatorMoveFirstItem.Click += new System.EventHandler(this.bindingNavigatorMoveFirstItem_Click);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            this.bindingNavigatorMovePreviousItem.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click);
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            this.bindingNavigatorPositionItem.Enter += new System.EventHandler(this.bindingNavigatorPositionItem_Enter);
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            this.bindingNavigatorMoveNextItem.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            this.bindingNavigatorMoveLastItem.Click += new System.EventHandler(this.bindingNavigatorMoveLastItem_Click);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // hTLBRANDBindingNavigatorSaveItem
            // 
            this.hTLBRANDBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.hTLBRANDBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("hTLBRANDBindingNavigatorSaveItem.Image")));
            this.hTLBRANDBindingNavigatorSaveItem.Name = "hTLBRANDBindingNavigatorSaveItem";
            this.hTLBRANDBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.hTLBRANDBindingNavigatorSaveItem.Text = "Save Data";
            this.hTLBRANDBindingNavigatorSaveItem.Click += new System.EventHandler(this.hTLBRANDBindingNavigatorSaveItem_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 25);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.AutoScroll = true;
            this.splitContainerControl1.Panel1.Controls.Add(this.GridControlHtlBrand);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.AutoScroll = true;
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl6);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControlSizeDisplay);
            this.splitContainerControl1.Panel2.Controls.Add(this.ImageComboBoxEditChain);
            this.splitContainerControl1.Panel2.Controls.Add(this.lOGO_PATHButtonEdit);
            this.splitContainerControl1.Panel2.Controls.Add(this.cODETextEdit);
            this.splitContainerControl1.Panel2.Controls.Add(this.dESCTextEdit);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl5);
            this.splitContainerControl1.Panel2.Controls.Add(this.logo);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl4);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl3);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1020, 717);
            this.splitContainerControl1.SplitterPosition = 409;
            this.splitContainerControl1.TabIndex = 28;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(25, 350);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(60, 13);
            this.labelControl6.TabIndex = 27;
            this.labelControl6.Text = "Size in pixels";
            // 
            // labelControlSizeDisplay
            // 
            this.labelControlSizeDisplay.Location = new System.Drawing.Point(101, 351);
            this.labelControlSizeDisplay.Name = "labelControlSizeDisplay";
            this.labelControlSizeDisplay.Size = new System.Drawing.Size(0, 13);
            this.labelControlSizeDisplay.TabIndex = 26;
            // 
            // ImageComboBoxEditChain
            // 
            this.ImageComboBoxEditChain.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.HtlBrandBindingSource, "CHAIN", true));
            this.ImageComboBoxEditChain.EnterMoveNextControl = true;
            this.ImageComboBoxEditChain.Location = new System.Drawing.Point(101, 90);
            this.ImageComboBoxEditChain.Name = "ImageComboBoxEditChain";
            this.ImageComboBoxEditChain.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ImageComboBoxEditChain.Size = new System.Drawing.Size(313, 20);
            this.ImageComboBoxEditChain.TabIndex = 2;
            this.ImageComboBoxEditChain.Enter += new System.EventHandler(this.enterControl);
            this.ImageComboBoxEditChain.Leave += new System.EventHandler(this.ImageComboBoxEditChain_Leave);
            // 
            // panelControlStatus
            // 
            this.panelControlStatus.Appearance.Options.UseTextOptions = true;
            this.panelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("panelControlStatus.ContentImage")));
            this.panelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.panelControlStatus.Controls.Add(this.LabelStatus);
            this.panelControlStatus.Location = new System.Drawing.Point(425, 2);
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
            // HtlBrandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 742);
            this.Controls.Add(this.panelControlStatus);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.HtlBrandBindingNavigator);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "HtlBrandForm";
            this.ShowInTaskbar = false;
            this.Text = "Hotel Brand";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HtlBrandForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HtlBrandForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.lOGO_PATHButtonEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HtlBrandBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cODETextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dESCTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlHtlBrand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewHtlBrand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HtlBrandBindingNavigator)).EndInit();
            this.HtlBrandBindingNavigator.ResumeLayout(false);
            this.HtlBrandBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditChain.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).EndInit();
            this.panelControlStatus.ResumeLayout(false);
            this.panelControlStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GridControlHtlBrand;
        private System.Windows.Forms.BindingSource HtlBrandBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewHtlBrand;
        private System.Windows.Forms.BindingNavigator HtlBrandBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton hTLBRANDBindingNavigatorSaveItem;
        private DevExpress.XtraEditors.PictureEdit logo;
        private DevExpress.XtraEditors.TextEdit dESCTextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit cODETextEdit;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.ButtonEdit lOGO_PATHButtonEdit;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
        private DevExpress.XtraEditors.ImageComboBoxEdit ImageComboBoxEditChain;
        private DevExpress.XtraGrid.Columns.GridColumn colImagesRoot;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplayName;
        private DevExpress.XtraGrid.Columns.GridColumn colCODE;
        private DevExpress.XtraGrid.Columns.GridColumn colDESC;
        private DevExpress.XtraGrid.Columns.GridColumn colCHAIN;
        private DevExpress.XtraGrid.Columns.GridColumn colLOGO_PATH;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTEL;
        private DevExpress.XtraGrid.Columns.GridColumn colHTLCHAIN;
        private DevExpress.XtraEditors.LabelControl labelControlSizeDisplay;
        private DevExpress.XtraEditors.LabelControl labelControl6;

    }
}