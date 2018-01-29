namespace TraceForms
{
    partial class StateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StateForm));
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.TextEditCode = new DevExpress.XtraEditors.TextEdit();
            this.StateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.GridControlState = new DevExpress.XtraGrid.GridControl();
            this.GridViewState = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colState1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCountry = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRegion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.state1TextBox = new DevExpress.XtraEditors.TextEdit();
            this.groupTextBox = new DevExpress.XtraEditors.TextEdit();
            this.StateBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.stateBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.ImageComboBoxEditCountry = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.ImageComboBoxEditRegion = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.panelControlStatus = new DevExpress.XtraEditors.PanelControl();
            this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
            this.bindingSourceCodeName = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.state1TextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StateBindingNavigator)).BeginInit();
            this.StateBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditCountry.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditRegion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).BeginInit();
            this.panelControlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCodeName)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(47, 22);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(51, 23);
            this.labelControl6.TabIndex = 46;
            this.labelControl6.Text = "States";
            // 
            // TextEditCode
            // 
            this.TextEditCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.StateBindingSource, "Code", true));
            this.TextEditCode.EnterMoveNextControl = true;
            this.TextEditCode.Location = new System.Drawing.Point(153, 93);
            this.TextEditCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextEditCode.Name = "TextEditCode";
            this.TextEditCode.Properties.MaxLength = 3;
            this.TextEditCode.Size = new System.Drawing.Size(264, 32);
            this.TextEditCode.TabIndex = 1;
            this.TextEditCode.Enter += new System.EventHandler(this.enterControl);
            this.TextEditCode.Leave += new System.EventHandler(this.codeTextEdit_Leave);
            // 
            // StateBindingSource
            // 
            this.StateBindingSource.DataSource = typeof(FlexModel.State);
            this.StateBindingSource.CurrentChanged += new System.EventHandler(this.StateBindingSource_CurrentChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(78, 341);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(52, 23);
            this.labelControl5.TabIndex = 39;
            this.labelControl5.Text = "Group";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(78, 275);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(58, 23);
            this.labelControl4.TabIndex = 38;
            this.labelControl4.Text = "Region";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(78, 215);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(65, 23);
            this.labelControl3.TabIndex = 37;
            this.labelControl3.Text = "Country";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(78, 156);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(49, 23);
            this.labelControl2.TabIndex = 36;
            this.labelControl2.Text = "Name";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(78, 99);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 23);
            this.labelControl1.TabIndex = 35;
            this.labelControl1.Text = "Code";
            // 
            // GridControlState
            // 
            this.GridControlState.DataSource = this.StateBindingSource;
            this.GridControlState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControlState.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GridControlState.Location = new System.Drawing.Point(0, 0);
            this.GridControlState.MainView = this.GridViewState;
            this.GridControlState.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GridControlState.Name = "GridControlState";
            this.GridControlState.Size = new System.Drawing.Size(284, 1277);
            this.GridControlState.TabIndex = 34;
            this.GridControlState.TabStop = false;
            this.GridControlState.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewState});
            // 
            // GridViewState
            // 
            this.GridViewState.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colState1,
            this.colCountry,
            this.colRegion,
            this.colGroup,
            this.colAddress});
            this.GridViewState.GridControl = this.GridControlState;
            this.GridViewState.Name = "GridViewState";
            this.GridViewState.OptionsCustomization.AllowRowSizing = true;
            this.GridViewState.OptionsView.AllowHtmlDrawHeaders = true;
            this.GridViewState.OptionsView.ShowAutoFilterRow = true;
            this.GridViewState.OptionsView.ShowGroupPanel = false;
            this.GridViewState.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            this.GridViewState.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            this.GridViewState.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView1_BeforeLeaveRow);
            // 
            // colCode
            // 
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            // 
            // colState1
            // 
            this.colState1.Caption = "State";
            this.colState1.FieldName = "State1";
            this.colState1.Name = "colState1";
            this.colState1.Visible = true;
            this.colState1.VisibleIndex = 1;
            // 
            // colCountry
            // 
            this.colCountry.FieldName = "Country";
            this.colCountry.Name = "colCountry";
            // 
            // colRegion
            // 
            this.colRegion.FieldName = "Region";
            this.colRegion.Name = "colRegion";
            // 
            // colGroup
            // 
            this.colGroup.FieldName = "Group";
            this.colGroup.Name = "colGroup";
            // 
            // colAddress
            // 
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            // 
            // state1TextBox
            // 
            this.state1TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.StateBindingSource, "State1", true));
            this.state1TextBox.EnterMoveNextControl = true;
            this.state1TextBox.Location = new System.Drawing.Point(153, 150);
            this.state1TextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.state1TextBox.Name = "state1TextBox";
            this.state1TextBox.Properties.MaxLength = 40;
            this.state1TextBox.Size = new System.Drawing.Size(264, 32);
            this.state1TextBox.TabIndex = 2;
            this.state1TextBox.Enter += new System.EventHandler(this.enterControl);
            this.state1TextBox.Leave += new System.EventHandler(this.state1TextBox_Leave);
            // 
            // groupTextBox
            // 
            this.groupTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.StateBindingSource, "Group", true));
            this.groupTextBox.EnterMoveNextControl = true;
            this.groupTextBox.Location = new System.Drawing.Point(153, 337);
            this.groupTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupTextBox.Name = "groupTextBox";
            this.groupTextBox.Properties.MaxLength = 3;
            this.groupTextBox.Size = new System.Drawing.Size(264, 32);
            this.groupTextBox.TabIndex = 5;
            this.groupTextBox.Enter += new System.EventHandler(this.enterControl);
            this.groupTextBox.Leave += new System.EventHandler(this.groupTextBox_Leave);
            // 
            // StateBindingNavigator
            // 
            this.StateBindingNavigator.AddNewItem = null;
            this.StateBindingNavigator.BindingSource = this.StateBindingSource;
            this.StateBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.StateBindingNavigator.DeleteItem = null;
            this.StateBindingNavigator.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.StateBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.stateBindingNavigatorSaveItem});
            this.StateBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.StateBindingNavigator.MoveFirstItem = null;
            this.StateBindingNavigator.MoveLastItem = null;
            this.StateBindingNavigator.MoveNextItem = null;
            this.StateBindingNavigator.MovePreviousItem = null;
            this.StateBindingNavigator.Name = "StateBindingNavigator";
            this.StateBindingNavigator.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.StateBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.StateBindingNavigator.Size = new System.Drawing.Size(1700, 35);
            this.StateBindingNavigator.TabIndex = 31;
            this.StateBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(61, 32);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(28, 32);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            this.bindingNavigatorMoveFirstItem.Click += new System.EventHandler(this.bindingNavigatorMoveFirstItem_Click);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(28, 32);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            this.bindingNavigatorMovePreviousItem.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click);
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 35);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(81, 35);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            this.bindingNavigatorPositionItem.Click += new System.EventHandler(this.bindingNavigatorPositionItem_Enter);
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(28, 32);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            this.bindingNavigatorMoveNextItem.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(28, 32);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            this.bindingNavigatorMoveLastItem.Click += new System.EventHandler(this.bindingNavigatorMoveLastItem_Click);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 35);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(28, 32);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(28, 32);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // stateBindingNavigatorSaveItem
            // 
            this.stateBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stateBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("stateBindingNavigatorSaveItem.Image")));
            this.stateBindingNavigatorSaveItem.Name = "stateBindingNavigatorSaveItem";
            this.stateBindingNavigatorSaveItem.Size = new System.Drawing.Size(28, 32);
            this.stateBindingNavigatorSaveItem.Text = "Save Data";
            this.stateBindingNavigatorSaveItem.Click += new System.EventHandler(this.stateBindingNavigatorSaveItem_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 35);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.AutoScroll = true;
            this.splitContainerControl1.Panel1.Controls.Add(this.GridControlState);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.AutoScroll = true;
            this.splitContainerControl1.Panel2.Controls.Add(this.ImageComboBoxEditCountry);
            this.splitContainerControl1.Panel2.Controls.Add(this.ImageComboBoxEditRegion);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl6);
            this.splitContainerControl1.Panel2.Controls.Add(this.TextEditCode);
            this.splitContainerControl1.Panel2.Controls.Add(this.groupTextBox);
            this.splitContainerControl1.Panel2.Controls.Add(this.state1TextBox);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl5);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl4);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl3);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1700, 1277);
            this.splitContainerControl1.SplitterPosition = 284;
            this.splitContainerControl1.TabIndex = 44;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // ImageComboBoxEditCountry
            // 
            this.ImageComboBoxEditCountry.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.StateBindingSource, "Country", true));
            this.ImageComboBoxEditCountry.EnterMoveNextControl = true;
            this.ImageComboBoxEditCountry.Location = new System.Drawing.Point(153, 211);
            this.ImageComboBoxEditCountry.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ImageComboBoxEditCountry.Name = "ImageComboBoxEditCountry";
            this.ImageComboBoxEditCountry.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ImageComboBoxEditCountry.Size = new System.Drawing.Size(507, 32);
            this.ImageComboBoxEditCountry.TabIndex = 3;
            this.ImageComboBoxEditCountry.Enter += new System.EventHandler(this.enterControl);
            this.ImageComboBoxEditCountry.Leave += new System.EventHandler(this.ImageComboBoxEditCountry_Leave);
            // 
            // ImageComboBoxEditRegion
            // 
            this.ImageComboBoxEditRegion.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.StateBindingSource, "Region", true));
            this.ImageComboBoxEditRegion.EnterMoveNextControl = true;
            this.ImageComboBoxEditRegion.Location = new System.Drawing.Point(153, 269);
            this.ImageComboBoxEditRegion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ImageComboBoxEditRegion.Name = "ImageComboBoxEditRegion";
            this.ImageComboBoxEditRegion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ImageComboBoxEditRegion.Size = new System.Drawing.Size(507, 32);
            this.ImageComboBoxEditRegion.TabIndex = 4;
            this.ImageComboBoxEditRegion.Enter += new System.EventHandler(this.enterControl);
            this.ImageComboBoxEditRegion.Leave += new System.EventHandler(this.ImageComboBoxEditRegion_Leave);
            // 
            // panelControlStatus
            // 
            this.panelControlStatus.Appearance.Options.UseTextOptions = true;
            this.panelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("panelControlStatus.ContentImage")));
            this.panelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.panelControlStatus.Controls.Add(this.LabelStatus);
            this.panelControlStatus.Location = new System.Drawing.Point(513, 0);
            this.panelControlStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelControlStatus.Name = "panelControlStatus";
            this.panelControlStatus.Size = new System.Drawing.Size(200, 41);
            this.panelControlStatus.TabIndex = 265;
            this.panelControlStatus.Visible = false;
            // 
            // LabelStatus
            // 
            this.LabelStatus.Location = new System.Drawing.Point(50, 8);
            this.LabelStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(0, 23);
            this.LabelStatus.TabIndex = 5;
            // 
            // bindingSourceCodeName
            // 
            this.bindingSourceCodeName.DataSource = typeof(TraceForms.CodeName);
            // 
            // StateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1700, 1312);
            this.Controls.Add(this.panelControlStatus);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.StateBindingNavigator);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimizeBox = false;
            this.Name = "StateForm";
            this.ShowInTaskbar = false;
            this.Text = "States";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.stateForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StateForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.state1TextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StateBindingNavigator)).EndInit();
            this.StateBindingNavigator.ResumeLayout(false);
            this.StateBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditCountry.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditRegion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).EndInit();
            this.panelControlStatus.ResumeLayout(false);
            this.panelControlStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCodeName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl GridControlState;
        private System.Windows.Forms.BindingSource StateBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewState;
        private DevExpress.XtraEditors.TextEdit state1TextBox;
        private DevExpress.XtraEditors.TextEdit groupTextBox;
        private System.Windows.Forms.BindingNavigator StateBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton stateBindingNavigatorSaveItem;
        private DevExpress.XtraEditors.TextEdit TextEditCode;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
        private DevExpress.XtraEditors.ImageComboBoxEdit ImageComboBoxEditCountry;
        private DevExpress.XtraEditors.ImageComboBoxEdit ImageComboBoxEditRegion;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colState1;
        private DevExpress.XtraGrid.Columns.GridColumn colCountry;
        private DevExpress.XtraGrid.Columns.GridColumn colRegion;
        private DevExpress.XtraGrid.Columns.GridColumn colGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private System.Windows.Forms.BindingSource bindingSourceCodeName;
    }
}