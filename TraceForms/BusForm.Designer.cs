namespace TraceForms
{
    partial class BusForm
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
            System.Windows.Forms.Label labelType;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusForm));
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControlLookup = new DevExpress.XtraGrid.GridControl();
            this.gridViewLookup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFleetMgmtID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlexMgmtIPAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInService = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spinEditCapacity = new DevExpress.XtraEditors.SpinEdit();
            this.textEditFleetMgmtIPAddress = new DevExpress.XtraEditors.TextEdit();
            this.textEditFleetMgmtID = new DevExpress.XtraEditors.TextEdit();
            this.textEditName = new DevExpress.XtraEditors.TextEdit();
            this.checkEditInService = new DevExpress.XtraEditors.CheckEdit();
            this.bindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.bindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.panelControlStatus = new DevExpress.XtraEditors.PanelControl();
            this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
            labelType = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditCapacity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditFleetMgmtIPAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditFleetMgmtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditInService.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).BeginInit();
            this.bindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).BeginInit();
            this.panelControlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelType
            // 
            labelType.AutoSize = true;
            labelType.Location = new System.Drawing.Point(128, 299);
            labelType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelType.Name = "labelType";
            labelType.Size = new System.Drawing.Size(161, 19);
            labelType.TabIndex = 2;
            labelType.Text = "Fleet management ID";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(128, 239);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(50, 19);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(128, 354);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(218, 19);
            label2.TabIndex = 4;
            label2.Text = "Fleet management IP address";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(128, 450);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(68, 19);
            label3.TabIndex = 7;
            label3.Text = "Capacity";
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(FlexModel.Bus);
            this.bindingSource.CurrentChanged += new System.EventHandler(this.BindingSource_CurrentChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.Location = new System.Drawing.Point(0, 41);
            this.splitContainerControl.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Panel1.AutoScroll = true;
            this.splitContainerControl.Panel1.Controls.Add(this.gridControlLookup);
            this.splitContainerControl.Panel2.AutoScroll = true;
            this.splitContainerControl.Panel2.Controls.Add(label3);
            this.splitContainerControl.Panel2.Controls.Add(this.spinEditCapacity);
            this.splitContainerControl.Panel2.Controls.Add(this.textEditFleetMgmtIPAddress);
            this.splitContainerControl.Panel2.Controls.Add(this.textEditFleetMgmtID);
            this.splitContainerControl.Panel2.Controls.Add(this.textEditName);
            this.splitContainerControl.Panel2.Controls.Add(label1);
            this.splitContainerControl.Panel2.Controls.Add(label2);
            this.splitContainerControl.Panel2.Controls.Add(labelType);
            this.splitContainerControl.Panel2.Controls.Add(this.checkEditInService);
            this.splitContainerControl.Size = new System.Drawing.Size(1896, 1307);
            this.splitContainerControl.SplitterPosition = 442;
            this.splitContainerControl.TabIndex = 39;
            // 
            // gridControlLookup
            // 
            this.gridControlLookup.DataSource = this.bindingSource;
            this.gridControlLookup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlLookup.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlLookup.Location = new System.Drawing.Point(0, 0);
            this.gridControlLookup.MainView = this.gridViewLookup;
            this.gridControlLookup.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlLookup.Name = "gridControlLookup";
            this.gridControlLookup.Size = new System.Drawing.Size(442, 1307);
            this.gridControlLookup.TabIndex = 0;
            this.gridControlLookup.TabStop = false;
            this.gridControlLookup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLookup});
            // 
            // gridViewLookup
            // 
            this.gridViewLookup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colName,
            this.colFleetMgmtID,
            this.colFlexMgmtIPAddress,
            this.colInService});
            this.gridViewLookup.GridControl = this.gridControlLookup;
            this.gridViewLookup.Name = "gridViewLookup";
            this.gridViewLookup.OptionsBehavior.Editable = false;
            this.gridViewLookup.OptionsView.ShowAutoFilterRow = true;
            this.gridViewLookup.OptionsView.ShowGroupPanel = false;
            this.gridViewLookup.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridViewLookup_InvalidRowException);
            this.gridViewLookup.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridViewLookup_BeforeLeaveRow);
            this.gridViewLookup.ColumnFilterChanged += new System.EventHandler(this.gridViewLookup_ColumnFilterChanged);
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // colFleetMgmtID
            // 
            this.colFleetMgmtID.FieldName = "FleetMgmtID";
            this.colFleetMgmtID.Name = "colFleetMgmtID";
            // 
            // colFlexMgmtIPAddress
            // 
            this.colFlexMgmtIPAddress.FieldName = "FlexMgmtIPAddress";
            this.colFlexMgmtIPAddress.Name = "colFlexMgmtIPAddress";
            // 
            // colInService
            // 
            this.colInService.FieldName = "InService";
            this.colInService.Name = "colInService";
            // 
            // spinEditCapacity
            // 
            this.spinEditCapacity.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "Capacity", true));
            this.spinEditCapacity.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditCapacity.Location = new System.Drawing.Point(356, 447);
            this.spinEditCapacity.Name = "spinEditCapacity";
            this.spinEditCapacity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditCapacity.Properties.Mask.EditMask = "###";
            this.spinEditCapacity.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.spinEditCapacity.Properties.MaxValue = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.spinEditCapacity.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditCapacity.Size = new System.Drawing.Size(100, 26);
            this.spinEditCapacity.TabIndex = 8;
            this.spinEditCapacity.Enter += new System.EventHandler(this.enterControl);
            this.spinEditCapacity.Leave += new System.EventHandler(this.spinEditCapacity_Leave);
            // 
            // textEditFleetMgmtIPAddress
            // 
            this.textEditFleetMgmtIPAddress.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "FlexMgmtIPAddress", true));
            this.textEditFleetMgmtIPAddress.EnterMoveNextControl = true;
            this.textEditFleetMgmtIPAddress.Location = new System.Drawing.Point(356, 351);
            this.textEditFleetMgmtIPAddress.Margin = new System.Windows.Forms.Padding(4);
            this.textEditFleetMgmtIPAddress.Name = "textEditFleetMgmtIPAddress";
            this.textEditFleetMgmtIPAddress.Properties.MaxLength = 12;
            this.textEditFleetMgmtIPAddress.Size = new System.Drawing.Size(252, 26);
            this.textEditFleetMgmtIPAddress.TabIndex = 5;
            this.textEditFleetMgmtIPAddress.Enter += new System.EventHandler(this.enterControl);
            this.textEditFleetMgmtIPAddress.Leave += new System.EventHandler(this.textEditFleetMgmtIPAddress_Leave);
            // 
            // textEditFleetMgmtID
            // 
            this.textEditFleetMgmtID.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "FleetMgmtID", true));
            this.textEditFleetMgmtID.EnterMoveNextControl = true;
            this.textEditFleetMgmtID.Location = new System.Drawing.Point(356, 296);
            this.textEditFleetMgmtID.Margin = new System.Windows.Forms.Padding(4);
            this.textEditFleetMgmtID.Name = "textEditFleetMgmtID";
            this.textEditFleetMgmtID.Properties.MaxLength = 60;
            this.textEditFleetMgmtID.Size = new System.Drawing.Size(443, 26);
            this.textEditFleetMgmtID.TabIndex = 3;
            this.textEditFleetMgmtID.Enter += new System.EventHandler(this.enterControl);
            this.textEditFleetMgmtID.Leave += new System.EventHandler(this.textEditFleetMgmtID_Leave);
            // 
            // textEditName
            // 
            this.textEditName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "Name", true));
            this.textEditName.EnterMoveNextControl = true;
            this.textEditName.Location = new System.Drawing.Point(356, 236);
            this.textEditName.Margin = new System.Windows.Forms.Padding(4);
            this.textEditName.Name = "textEditName";
            this.textEditName.Properties.MaxLength = 60;
            this.textEditName.Size = new System.Drawing.Size(671, 26);
            this.textEditName.TabIndex = 1;
            this.textEditName.Enter += new System.EventHandler(this.enterControl);
            this.textEditName.Leave += new System.EventHandler(this.textEditName_Leave);
            // 
            // checkEditInService
            // 
            this.checkEditInService.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "InService", true));
            this.checkEditInService.Location = new System.Drawing.Point(129, 401);
            this.checkEditInService.Name = "checkEditInService";
            this.checkEditInService.Properties.Caption = "In Service";
            this.checkEditInService.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.checkEditInService.Size = new System.Drawing.Size(244, 23);
            this.checkEditInService.TabIndex = 6;
            this.checkEditInService.Enter += new System.EventHandler(this.enterControl);
            this.checkEditInService.Leave += new System.EventHandler(this.checkEditInService_Leave);
            // 
            // bindingNavigator
            // 
            this.bindingNavigator.AddNewItem = null;
            this.bindingNavigator.BindingSource = this.bindingSource;
            this.bindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator.DeleteItem = null;
            this.bindingNavigator.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.bindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bindingNavigatorSaveItem});
            this.bindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator.MoveFirstItem = null;
            this.bindingNavigator.MoveLastItem = null;
            this.bindingNavigator.MoveNextItem = null;
            this.bindingNavigator.MovePreviousItem = null;
            this.bindingNavigator.Name = "bindingNavigator";
            this.bindingNavigator.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.bindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator.Size = new System.Drawing.Size(1530, 31);
            this.bindingNavigator.TabIndex = 23;
            this.bindingNavigator.Text = "bindingNavigator1";
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
            // bindingNavigatorSaveItem
            // 
            this.bindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorSaveItem.Image")));
            this.bindingNavigatorSaveItem.Name = "bindingNavigatorSaveItem";
            this.bindingNavigatorSaveItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorSaveItem.Text = "Save Data";
            this.bindingNavigatorSaveItem.Click += new System.EventHandler(this.BindingNavigatorSaveItem_Click);
            // 
            // panelControlStatus
            // 
            this.panelControlStatus.Appearance.Options.UseTextOptions = true;
            this.panelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("panelControlStatus.ContentImage")));
            this.panelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.panelControlStatus.Controls.Add(this.LabelStatus);
            this.panelControlStatus.Location = new System.Drawing.Point(548, 3);
            this.panelControlStatus.Margin = new System.Windows.Forms.Padding(4);
            this.panelControlStatus.Name = "panelControlStatus";
            this.panelControlStatus.Size = new System.Drawing.Size(180, 34);
            this.panelControlStatus.TabIndex = 265;
            this.panelControlStatus.Visible = false;
            // 
            // LabelStatus
            // 
            this.LabelStatus.Location = new System.Drawing.Point(45, 7);
            this.LabelStatus.Margin = new System.Windows.Forms.Padding(4);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(0, 19);
            this.LabelStatus.TabIndex = 5;
            // 
            // BusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1530, 1084);
            this.Controls.Add(this.panelControlStatus);
            this.Controls.Add(this.bindingNavigator);
            this.Controls.Add(this.splitContainerControl);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeBox = false;
            this.Name = "BusForm";
            this.ShowInTaskbar = false;
            this.Text = "Bus General Information";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BusForm_FormClosing);
            this.Shown += new System.EventHandler(this.BusForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BusForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditCapacity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditFleetMgmtIPAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditFleetMgmtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditInService.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).EndInit();
            this.bindingNavigator.ResumeLayout(false);
            this.bindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).EndInit();
            this.panelControlStatus.ResumeLayout(false);
            this.panelControlStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource;
		private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraGrid.GridControl gridControlLookup;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewLookup;
        private System.Windows.Forms.BindingNavigator bindingNavigator;
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
		private System.Windows.Forms.ToolStripButton bindingNavigatorSaveItem;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraEditors.PanelControl panelControlStatus;
		private DevExpress.XtraEditors.LabelControl LabelStatus;
		private DevExpress.XtraEditors.CheckEdit checkEditInService;
        private DevExpress.XtraEditors.TextEdit textEditFleetMgmtIPAddress;
        private DevExpress.XtraEditors.TextEdit textEditFleetMgmtID;
        private DevExpress.XtraEditors.TextEdit textEditName;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colFleetMgmtID;
        private DevExpress.XtraGrid.Columns.GridColumn colFlexMgmtIPAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colInService;
		private DevExpress.XtraEditors.SpinEdit spinEditCapacity;
    }
}