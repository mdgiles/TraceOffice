namespace TraceForms
{
    partial class packItinMaint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(packItinMaint));
            this.sTATUSImageComboBoxEdit = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.PitinBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PitinBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.pITINBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.GridControlPackItin = new DevExpress.XtraGrid.GridControl();
            this.GridViewPackItin = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLAST_UPD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUPD_BY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTATUS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstatus_string = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UpdBy = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.LastUpd = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cat = new DevExpress.XtraEditors.LabelControl();
            this.cd = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dATEDateEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.ImageComboBoxEditCode = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.ImageComboBoxEditCategory = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.panelControlStatus = new DevExpress.XtraEditors.PanelControl();
            this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.sTATUSImageComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PitinBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PitinBindingNavigator)).BeginInit();
            this.PitinBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlPackItin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewPackItin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dATEDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).BeginInit();
            this.panelControlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // sTATUSImageComboBoxEdit
            // 
            this.sTATUSImageComboBoxEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.PitinBindingSource, "STATUS", true));
            this.sTATUSImageComboBoxEdit.EnterMoveNextControl = true;
            this.sTATUSImageComboBoxEdit.Location = new System.Drawing.Point(92, 184);
            this.sTATUSImageComboBoxEdit.Name = "sTATUSImageComboBoxEdit";
            this.sTATUSImageComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sTATUSImageComboBoxEdit.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Closed", "C", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Available", "A", -1)});
            this.sTATUSImageComboBoxEdit.Size = new System.Drawing.Size(100, 20);
            this.sTATUSImageComboBoxEdit.TabIndex = 4;
            this.sTATUSImageComboBoxEdit.Enter += new System.EventHandler(this.enterControl);
            this.sTATUSImageComboBoxEdit.Leave += new System.EventHandler(this.sTATUSImageComboBoxEdit_Leave);
            // 
            // PitinBindingSource
            // 
            this.PitinBindingSource.DataSource = typeof(FlexModel.PITIN);
            this.PitinBindingSource.CurrentChanged += new System.EventHandler(this.PitinBindingSource_CurrentChanged);
            // 
            // PitinBindingNavigator
            // 
            this.PitinBindingNavigator.AddNewItem = null;
            this.PitinBindingNavigator.BindingSource = this.PitinBindingSource;
            this.PitinBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.PitinBindingNavigator.DeleteItem = null;
            this.PitinBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.pITINBindingNavigatorSaveItem});
            this.PitinBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.PitinBindingNavigator.MoveFirstItem = null;
            this.PitinBindingNavigator.MoveLastItem = null;
            this.PitinBindingNavigator.MoveNextItem = null;
            this.PitinBindingNavigator.MovePreviousItem = null;
            this.PitinBindingNavigator.Name = "PitinBindingNavigator";
            this.PitinBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.PitinBindingNavigator.Size = new System.Drawing.Size(1020, 25);
            this.PitinBindingNavigator.TabIndex = 24;
            this.PitinBindingNavigator.Text = "bindingNavigator1";
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
            // pITINBindingNavigatorSaveItem
            // 
            this.pITINBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pITINBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("pITINBindingNavigatorSaveItem.Image")));
            this.pITINBindingNavigatorSaveItem.Name = "pITINBindingNavigatorSaveItem";
            this.pITINBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.pITINBindingNavigatorSaveItem.Text = "Save Data";
            this.pITINBindingNavigatorSaveItem.Click += new System.EventHandler(this.BindingNavigatorSaveItem_Click);
            // 
            // GridControlPackItin
            // 
            this.GridControlPackItin.DataSource = this.PitinBindingSource;
            this.GridControlPackItin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControlPackItin.Location = new System.Drawing.Point(0, 0);
            this.GridControlPackItin.MainView = this.GridViewPackItin;
            this.GridControlPackItin.Name = "GridControlPackItin";
            this.GridControlPackItin.Size = new System.Drawing.Size(330, 717);
            this.GridControlPackItin.TabIndex = 23;
            this.GridControlPackItin.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewPackItin});
            // 
            // GridViewPackItin
            // 
            this.GridViewPackItin.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCODE,
            this.colCAT,
            this.colDATE,
            this.colLAST_UPD,
            this.colUPD_BY,
            this.colSTATUS,
            this.colstatus_string});
            this.GridViewPackItin.GridControl = this.GridControlPackItin;
            this.GridViewPackItin.Name = "GridViewPackItin";
            this.GridViewPackItin.OptionsBehavior.Editable = false;
            this.GridViewPackItin.OptionsView.ShowAutoFilterRow = true;
            this.GridViewPackItin.OptionsView.ShowGroupPanel = false;
            this.GridViewPackItin.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewPackItin.OptionsView.ShowIndicator = false;
            this.GridViewPackItin.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.GridViewPackItin_CustomColumnDisplayText);
            // 
            // colCODE
            // 
            this.colCODE.FieldName = "CODE";
            this.colCODE.Name = "colCODE";
            this.colCODE.Visible = true;
            this.colCODE.VisibleIndex = 0;
            // 
            // colCAT
            // 
            this.colCAT.FieldName = "CAT";
            this.colCAT.Name = "colCAT";
            this.colCAT.Visible = true;
            this.colCAT.VisibleIndex = 1;
            // 
            // colDATE
            // 
            this.colDATE.FieldName = "DATE";
            this.colDATE.Name = "colDATE";
            this.colDATE.Visible = true;
            this.colDATE.VisibleIndex = 2;
            // 
            // colLAST_UPD
            // 
            this.colLAST_UPD.FieldName = "LAST_UPD";
            this.colLAST_UPD.Name = "colLAST_UPD";
            // 
            // colUPD_BY
            // 
            this.colUPD_BY.FieldName = "UPD_BY";
            this.colUPD_BY.Name = "colUPD_BY";
            // 
            // colSTATUS
            // 
            this.colSTATUS.FieldName = "STATUS";
            this.colSTATUS.Name = "colSTATUS";
            // 
            // colstatus_string
            // 
            this.colstatus_string.FieldName = "status_string";
            this.colstatus_string.Name = "colstatus_string";
            // 
            // UpdBy
            // 
            this.UpdBy.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.PitinBindingSource, "UPD_BY", true));
            this.UpdBy.Location = new System.Drawing.Point(393, 128);
            this.UpdBy.Name = "UpdBy";
            this.UpdBy.Size = new System.Drawing.Size(0, 13);
            this.UpdBy.TabIndex = 22;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(371, 128);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(16, 13);
            this.labelControl7.TabIndex = 21;
            this.labelControl7.Text = "By:";
            // 
            // LastUpd
            // 
            this.LastUpd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.PitinBindingSource, "LAST_UPD", true));
            this.LastUpd.Location = new System.Drawing.Point(273, 128);
            this.LastUpd.Name = "LastUpd";
            this.LastUpd.Size = new System.Drawing.Size(0, 13);
            this.LastUpd.TabIndex = 20;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(38, 186);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(31, 13);
            this.labelControl5.TabIndex = 19;
            this.labelControl5.Text = "Status";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(37, 126);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(23, 13);
            this.labelControl4.TabIndex = 18;
            this.labelControl4.Text = "Date";
            // 
            // cat
            // 
            this.cat.Location = new System.Drawing.Point(37, 94);
            this.cat.Name = "cat";
            this.cat.Size = new System.Drawing.Size(45, 13);
            this.cat.TabIndex = 17;
            this.cat.Text = "Category";
            // 
            // cd
            // 
            this.cd.Location = new System.Drawing.Point(37, 57);
            this.cd.Name = "cd";
            this.cd.Size = new System.Drawing.Size(25, 13);
            this.cd.TabIndex = 16;
            this.cd.Text = "Code";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(200, 128);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(67, 13);
            this.labelControl1.TabIndex = 15;
            this.labelControl1.Text = "Last updated:";
            // 
            // dATEDateEdit
            // 
            this.dATEDateEdit.CausesValidation = false;
            this.dATEDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.PitinBindingSource, "DATE", true));
            this.dATEDateEdit.EnterMoveNextControl = true;
            this.dATEDateEdit.Location = new System.Drawing.Point(92, 123);
            this.dATEDateEdit.Name = "dATEDateEdit";
            this.dATEDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dATEDateEdit.Size = new System.Drawing.Size(100, 20);
            this.dATEDateEdit.TabIndex = 3;
            this.dATEDateEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.dATEDateEdit_ButtonClick);
            this.dATEDateEdit.TextChanged += new System.EventHandler(this.dATEDateEdit_TextChanged);
            this.dATEDateEdit.Enter += new System.EventHandler(this.enterControl);
            this.dATEDateEdit.Leave += new System.EventHandler(this.dATEDateEdit_Leave);
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
            this.splitContainerControl1.Panel1.Controls.Add(this.GridControlPackItin);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.AutoScroll = true;
            this.splitContainerControl1.Panel2.Controls.Add(this.ImageComboBoxEditCode);
            this.splitContainerControl1.Panel2.Controls.Add(this.ImageComboBoxEditCategory);
            this.splitContainerControl1.Panel2.Controls.Add(this.sTATUSImageComboBoxEdit);
            this.splitContainerControl1.Panel2.Controls.Add(this.dATEDateEdit);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel2.Controls.Add(this.UpdBy);
            this.splitContainerControl1.Panel2.Controls.Add(this.cd);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl7);
            this.splitContainerControl1.Panel2.Controls.Add(this.cat);
            this.splitContainerControl1.Panel2.Controls.Add(this.LastUpd);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl4);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl5);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1020, 717);
            this.splitContainerControl1.SplitterPosition = 330;
            this.splitContainerControl1.TabIndex = 30;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // ImageComboBoxEditCode
            // 
            this.ImageComboBoxEditCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.PitinBindingSource, "CODE", true));
            this.ImageComboBoxEditCode.EnterMoveNextControl = true;
            this.ImageComboBoxEditCode.Location = new System.Drawing.Point(92, 54);
            this.ImageComboBoxEditCode.Name = "ImageComboBoxEditCode";
            this.ImageComboBoxEditCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ImageComboBoxEditCode.Size = new System.Drawing.Size(259, 20);
            this.ImageComboBoxEditCode.TabIndex = 1;
            this.ImageComboBoxEditCode.Enter += new System.EventHandler(this.enterControl);
            this.ImageComboBoxEditCode.Leave += new System.EventHandler(this.codeTextBox_Leave);
            // 
            // ImageComboBoxEditCategory
            // 
            this.ImageComboBoxEditCategory.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.PitinBindingSource, "CAT", true));
            this.ImageComboBoxEditCategory.EnterMoveNextControl = true;
            this.ImageComboBoxEditCategory.Location = new System.Drawing.Point(92, 91);
            this.ImageComboBoxEditCategory.Name = "ImageComboBoxEditCategory";
            this.ImageComboBoxEditCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ImageComboBoxEditCategory.Size = new System.Drawing.Size(260, 20);
            this.ImageComboBoxEditCategory.TabIndex = 2;
            this.ImageComboBoxEditCategory.Enter += new System.EventHandler(this.enterControl);
            this.ImageComboBoxEditCategory.Leave += new System.EventHandler(this.cat_Leave);
            // 
            // panelControlStatus
            // 
            this.panelControlStatus.Appearance.Options.UseTextOptions = true;
            this.panelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("panelControlStatus.ContentImage")));
            this.panelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.panelControlStatus.Controls.Add(this.LabelStatus);
            this.panelControlStatus.Location = new System.Drawing.Point(350, 2);
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
            // packItinMaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 742);
            this.Controls.Add(this.panelControlStatus);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.PitinBindingNavigator);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "packItinMaint";
            this.ShowInTaskbar = false;
            this.Text = "Package Itinerary Maintenance";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PITINForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.packItinMaint_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.sTATUSImageComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PitinBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PitinBindingNavigator)).EndInit();
            this.PitinBindingNavigator.ResumeLayout(false);
            this.PitinBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlPackItin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewPackItin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dATEDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).EndInit();
            this.panelControlStatus.ResumeLayout(false);
            this.panelControlStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource PitinBindingSource;
        private DevExpress.XtraEditors.ButtonEdit dATEDateEdit;
        private DevExpress.XtraEditors.LabelControl UpdBy;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl LastUpd;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl cat;
        private DevExpress.XtraEditors.LabelControl cd;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl GridControlPackItin;
        private System.Windows.Forms.BindingNavigator PitinBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton pITINBindingNavigatorSaveItem;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.ImageComboBoxEdit sTATUSImageComboBoxEdit;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewPackItin;
        private DevExpress.XtraGrid.Columns.GridColumn colCODE;
        private DevExpress.XtraGrid.Columns.GridColumn colCAT;
        private DevExpress.XtraGrid.Columns.GridColumn colDATE;
        private DevExpress.XtraGrid.Columns.GridColumn colLAST_UPD;
        private DevExpress.XtraGrid.Columns.GridColumn colUPD_BY;
        private DevExpress.XtraGrid.Columns.GridColumn colSTATUS;
        private DevExpress.XtraGrid.Columns.GridColumn colstatus_string;
        private DevExpress.XtraEditors.PanelControl panelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
        private DevExpress.XtraEditors.ImageComboBoxEdit ImageComboBoxEditCode;
        private DevExpress.XtraEditors.ImageComboBoxEdit ImageComboBoxEditCategory;
    }
}