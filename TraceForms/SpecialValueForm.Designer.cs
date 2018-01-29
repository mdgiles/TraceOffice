namespace TraceForms
{
    partial class SpecialValueForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpecialValueForm));
            this.SpecialValueBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SpecialValueBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.specialValueBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.rateCalcDescMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.codeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.requiresRateCalcCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.GridControlSpecVal = new DevExpress.XtraGrid.GridControl();
            this.GridViewSpecVal = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRequiresRateCalc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRateCalcDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ComboBoxEditType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.nameTextBox = new DevExpress.XtraEditors.TextEdit();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControlStatus = new DevExpress.XtraEditors.PanelControl();
            this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.SpecialValueBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpecialValueBindingNavigator)).BeginInit();
            this.SpecialValueBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rateCalcDescMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requiresRateCalcCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlSpecVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSpecVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxEditType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).BeginInit();
            this.panelControlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // SpecialValueBindingSource
            // 
            this.SpecialValueBindingSource.DataSource = typeof(FlexModel.SpecialValue);
            this.SpecialValueBindingSource.CurrentChanged += new System.EventHandler(this.SpecialValueBindingSource_CurrentChanged);
            // 
            // SpecialValueBindingNavigator
            // 
            this.SpecialValueBindingNavigator.AddNewItem = null;
            this.SpecialValueBindingNavigator.BindingSource = this.SpecialValueBindingSource;
            this.SpecialValueBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.SpecialValueBindingNavigator.DeleteItem = null;
            this.SpecialValueBindingNavigator.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.SpecialValueBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.specialValueBindingNavigatorSaveItem});
            this.SpecialValueBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.SpecialValueBindingNavigator.MoveFirstItem = null;
            this.SpecialValueBindingNavigator.MoveLastItem = null;
            this.SpecialValueBindingNavigator.MoveNextItem = null;
            this.SpecialValueBindingNavigator.MovePreviousItem = null;
            this.SpecialValueBindingNavigator.Name = "SpecialValueBindingNavigator";
            this.SpecialValueBindingNavigator.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.SpecialValueBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.SpecialValueBindingNavigator.Size = new System.Drawing.Size(1530, 31);
            this.SpecialValueBindingNavigator.TabIndex = 19;
            this.SpecialValueBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(54, 28);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            this.bindingNavigatorMoveFirstItem.Click += new System.EventHandler(this.bindingNavigatorMoveFirstItem_Click);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            this.bindingNavigatorMovePreviousItem.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click);
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(73, 31);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            this.bindingNavigatorPositionItem.Enter += new System.EventHandler(this.bindingNavigatorPositionItem_Enter);
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            this.bindingNavigatorMoveNextItem.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            this.bindingNavigatorMoveLastItem.Click += new System.EventHandler(this.bindingNavigatorMoveLastItem_Click);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // specialValueBindingNavigatorSaveItem
            // 
            this.specialValueBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.specialValueBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("specialValueBindingNavigatorSaveItem.Image")));
            this.specialValueBindingNavigatorSaveItem.Name = "specialValueBindingNavigatorSaveItem";
            this.specialValueBindingNavigatorSaveItem.Size = new System.Drawing.Size(28, 28);
            this.specialValueBindingNavigatorSaveItem.Text = "Save Data";
            this.specialValueBindingNavigatorSaveItem.Click += new System.EventHandler(this.specialValueBindingNavigatorSaveItem_Click);
            // 
            // rateCalcDescMemoEdit
            // 
            this.rateCalcDescMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SpecialValueBindingSource, "RateCalcDesc", true));
            this.rateCalcDescMemoEdit.Enabled = false;
            this.rateCalcDescMemoEdit.Location = new System.Drawing.Point(70, 311);
            this.rateCalcDescMemoEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rateCalcDescMemoEdit.Name = "rateCalcDescMemoEdit";
            this.rateCalcDescMemoEdit.Size = new System.Drawing.Size(519, 170);
            this.rateCalcDescMemoEdit.TabIndex = 5;
            this.rateCalcDescMemoEdit.Enter += new System.EventHandler(this.enterControl);
            this.rateCalcDescMemoEdit.Leave += new System.EventHandler(this.rateCalcDescTextBox_Leave);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(42, 31);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(100, 19);
            this.labelControl5.TabIndex = 41;
            this.labelControl5.Text = "Special Values";
            // 
            // codeTextEdit
            // 
            this.codeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SpecialValueBindingSource, "Code", true));
            this.codeTextEdit.Location = new System.Drawing.Point(114, 114);
            this.codeTextEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.codeTextEdit.Name = "codeTextEdit";
            this.codeTextEdit.Properties.MaxLength = 16;
            this.codeTextEdit.Size = new System.Drawing.Size(316, 26);
            this.codeTextEdit.TabIndex = 2;
            this.codeTextEdit.Enter += new System.EventHandler(this.enterControl);
            this.codeTextEdit.Leave += new System.EventHandler(this.codeTextEdit_Leave);
            // 
            // requiresRateCalcCheckEdit
            // 
            this.requiresRateCalcCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SpecialValueBindingSource, "RequiresRateCalc", true));
            this.requiresRateCalcCheckEdit.Location = new System.Drawing.Point(111, 206);
            this.requiresRateCalcCheckEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.requiresRateCalcCheckEdit.Name = "requiresRateCalcCheckEdit";
            this.requiresRateCalcCheckEdit.Properties.Caption = "Requires Rate Calculations";
            this.requiresRateCalcCheckEdit.Size = new System.Drawing.Size(232, 23);
            this.requiresRateCalcCheckEdit.TabIndex = 4;
            this.requiresRateCalcCheckEdit.Click += new System.EventHandler(this.requiresRateCalcCheckEdit_Click);
            // 
            // GridControlSpecVal
            // 
            this.GridControlSpecVal.DataSource = this.SpecialValueBindingSource;
            this.GridControlSpecVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControlSpecVal.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GridControlSpecVal.Location = new System.Drawing.Point(0, 0);
            this.GridControlSpecVal.MainView = this.GridViewSpecVal;
            this.GridControlSpecVal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GridControlSpecVal.Name = "GridControlSpecVal";
            this.GridControlSpecVal.Size = new System.Drawing.Size(416, 1053);
            this.GridControlSpecVal.TabIndex = 32;
            this.GridControlSpecVal.TabStop = false;
            this.GridControlSpecVal.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewSpecVal});
            // 
            // GridViewSpecVal
            // 
            this.GridViewSpecVal.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colType,
            this.colCode,
            this.colName,
            this.colRequiresRateCalc,
            this.colRateCalcDesc,
            this.colDisplayName});
            this.GridViewSpecVal.GridControl = this.GridControlSpecVal;
            this.GridViewSpecVal.Name = "GridViewSpecVal";
            this.GridViewSpecVal.OptionsView.ShowAutoFilterRow = true;
            this.GridViewSpecVal.OptionsView.ShowGroupPanel = false;
            this.GridViewSpecVal.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            this.GridViewSpecVal.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            this.GridViewSpecVal.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView1_BeforeLeaveRow);
            // 
            // colType
            // 
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            this.colType.Visible = true;
            this.colType.VisibleIndex = 0;
            // 
            // colCode
            // 
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 1;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            // 
            // colRequiresRateCalc
            // 
            this.colRequiresRateCalc.FieldName = "RequiresRateCalc";
            this.colRequiresRateCalc.Name = "colRequiresRateCalc";
            // 
            // colRateCalcDesc
            // 
            this.colRateCalcDesc.FieldName = "RateCalcDesc";
            this.colRateCalcDesc.Name = "colRateCalcDesc";
            // 
            // colDisplayName
            // 
            this.colDisplayName.FieldName = "DisplayName";
            this.colDisplayName.Name = "colDisplayName";
            this.colDisplayName.OptionsColumn.ReadOnly = true;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(69, 259);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(197, 19);
            this.labelControl4.TabIndex = 38;
            this.labelControl4.Text = "Rate Calculation Description";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(64, 156);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(41, 19);
            this.labelControl3.TabIndex = 37;
            this.labelControl3.Text = "Name";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(68, 118);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 19);
            this.labelControl2.TabIndex = 36;
            this.labelControl2.Text = "Code";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(69, 80);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(35, 19);
            this.labelControl1.TabIndex = 35;
            this.labelControl1.Text = "Type";
            // 
            // ComboBoxEditType
            // 
            this.ComboBoxEditType.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SpecialValueBindingSource, "Type", true));
            this.ComboBoxEditType.Location = new System.Drawing.Point(114, 76);
            this.ComboBoxEditType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ComboBoxEditType.Name = "ComboBoxEditType";
            this.ComboBoxEditType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ComboBoxEditType.Properties.Items.AddRange(new object[] {
            "HTL",
            "OPT",
            "PKG",
            "CAR",
            "CRU",
            "AIR"});
            this.ComboBoxEditType.Properties.MaxLength = 3;
            this.ComboBoxEditType.Size = new System.Drawing.Size(150, 26);
            this.ComboBoxEditType.TabIndex = 1;
            this.ComboBoxEditType.Enter += new System.EventHandler(this.enterControl);
            this.ComboBoxEditType.Leave += new System.EventHandler(this.typeComboBoxEdit_Leave);
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.SpecialValueBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(114, 152);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Properties.MaxLength = 64;
            this.nameTextBox.Size = new System.Drawing.Size(554, 26);
            this.nameTextBox.TabIndex = 3;
            this.nameTextBox.Enter += new System.EventHandler(this.enterControl);
            this.nameTextBox.Leave += new System.EventHandler(this.nameTextBox_Leave);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 31);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.AutoScroll = true;
            this.splitContainerControl1.Panel1.Controls.Add(this.GridControlSpecVal);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.AutoScroll = true;
            this.splitContainerControl1.Panel2.Controls.Add(this.rateCalcDescMemoEdit);
            this.splitContainerControl1.Panel2.Controls.Add(this.ComboBoxEditType);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl5);
            this.splitContainerControl1.Panel2.Controls.Add(this.nameTextBox);
            this.splitContainerControl1.Panel2.Controls.Add(this.codeTextEdit);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel2.Controls.Add(this.requiresRateCalcCheckEdit);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl4);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl3);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1530, 1053);
            this.splitContainerControl1.SplitterPosition = 277;
            this.splitContainerControl1.TabIndex = 43;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panelControlStatus
            // 
            this.panelControlStatus.Appearance.Options.UseTextOptions = true;
            this.panelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("panelControlStatus.ContentImage")));
            this.panelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.panelControlStatus.Controls.Add(this.LabelStatus);
            this.panelControlStatus.Location = new System.Drawing.Point(440, 3);
            this.panelControlStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelControlStatus.Name = "panelControlStatus";
            this.panelControlStatus.Size = new System.Drawing.Size(180, 34);
            this.panelControlStatus.TabIndex = 265;
            this.panelControlStatus.Visible = false;
            // 
            // LabelStatus
            // 
            this.LabelStatus.Location = new System.Drawing.Point(45, 7);
            this.LabelStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(0, 19);
            this.LabelStatus.TabIndex = 5;
            // 
            // SpecialValueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1530, 1084);
            this.Controls.Add(this.panelControlStatus);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.SpecialValueBindingNavigator);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimizeBox = false;
            this.Name = "SpecialValueForm";
            this.ShowInTaskbar = false;
            this.Text = "Special Value";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SpecialValue_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SpecialValueForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.SpecialValueBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpecialValueBindingNavigator)).EndInit();
            this.SpecialValueBindingNavigator.ResumeLayout(false);
            this.SpecialValueBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rateCalcDescMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requiresRateCalcCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlSpecVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSpecVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxEditType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).EndInit();
            this.panelControlStatus.ResumeLayout(false);
            this.panelControlStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource SpecialValueBindingSource;
        private DevExpress.XtraEditors.TextEdit codeTextEdit;
        private DevExpress.XtraEditors.CheckEdit requiresRateCalcCheckEdit;
        private DevExpress.XtraGrid.GridControl GridControlSpecVal;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewSpecVal;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit ComboBoxEditType;
        private DevExpress.XtraEditors.TextEdit nameTextBox;
        private System.Windows.Forms.BindingNavigator SpecialValueBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton specialValueBindingNavigatorSaveItem;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.MemoEdit rateCalcDescMemoEdit;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colRequiresRateCalc;
        private DevExpress.XtraGrid.Columns.GridColumn colRateCalcDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplayName;
       

    }
}