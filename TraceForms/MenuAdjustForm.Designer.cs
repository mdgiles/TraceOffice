namespace TraceForms
{
    partial class MenuAdjustForm
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
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label captionLabel;
            System.Windows.Forms.Label imagePathLabel;
            System.Windows.Forms.Label positionLabel;
            System.Windows.Forms.Label visibleLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuAdjustForm));
            this.menuConfigParentBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.menuConfigParentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuConfigParentBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.nameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.captionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.imagePathTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.positionSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.visibleCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colAppName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDropDown = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCaption = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colImagePath = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colPosition = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colParentCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colVisible = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.menuItemRestrictionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMenuItem_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAGCYLOG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMenuConfig = new DevExpress.XtraGrid.Columns.GridColumn();
            this.addNewMenuItem = new DevExpress.XtraEditors.SimpleButton();
            this.deleteMenuItem = new DevExpress.XtraEditors.SimpleButton();
            this.saveButton = new DevExpress.XtraEditors.SimpleButton();
            this.panelControlStatus = new DevExpress.XtraEditors.PanelControl();
            this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
            nameLabel = new System.Windows.Forms.Label();
            captionLabel = new System.Windows.Forms.Label();
            imagePathLabel = new System.Windows.Forms.Label();
            positionLabel = new System.Windows.Forms.Label();
            visibleLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.menuConfigParentBindingNavigator)).BeginInit();
            this.menuConfigParentBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuConfigParentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.captionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagePathTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visibleCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemRestrictionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).BeginInit();
            this.panelControlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(873, 98);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(38, 13);
            nameLabel.TabIndex = 3;
            nameLabel.Text = "Name:";
            // 
            // captionLabel
            // 
            captionLabel.AutoSize = true;
            captionLabel.Location = new System.Drawing.Point(863, 137);
            captionLabel.Name = "captionLabel";
            captionLabel.Size = new System.Drawing.Size(48, 13);
            captionLabel.TabIndex = 9;
            captionLabel.Text = "Caption:";
            // 
            // imagePathLabel
            // 
            imagePathLabel.AutoSize = true;
            imagePathLabel.Location = new System.Drawing.Point(845, 181);
            imagePathLabel.Name = "imagePathLabel";
            imagePathLabel.Size = new System.Drawing.Size(66, 13);
            imagePathLabel.TabIndex = 11;
            imagePathLabel.Text = "Image Path:";
            // 
            // positionLabel
            // 
            positionLabel.AutoSize = true;
            positionLabel.Location = new System.Drawing.Point(863, 223);
            positionLabel.Name = "positionLabel";
            positionLabel.Size = new System.Drawing.Size(48, 13);
            positionLabel.TabIndex = 13;
            positionLabel.Text = "Position:";
            // 
            // visibleLabel
            // 
            visibleLabel.AutoSize = true;
            visibleLabel.Location = new System.Drawing.Point(869, 267);
            visibleLabel.Name = "visibleLabel";
            visibleLabel.Size = new System.Drawing.Size(40, 13);
            visibleLabel.TabIndex = 15;
            visibleLabel.Text = "Visible:";
            // 
            // menuConfigParentBindingNavigator
            // 
            this.menuConfigParentBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.menuConfigParentBindingNavigator.BindingSource = this.menuConfigParentBindingSource;
            this.menuConfigParentBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.menuConfigParentBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.menuConfigParentBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.menuConfigParentBindingNavigatorSaveItem});
            this.menuConfigParentBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.menuConfigParentBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.menuConfigParentBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.menuConfigParentBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.menuConfigParentBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.menuConfigParentBindingNavigator.Name = "menuConfigParentBindingNavigator";
            this.menuConfigParentBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.menuConfigParentBindingNavigator.Size = new System.Drawing.Size(1247, 25);
            this.menuConfigParentBindingNavigator.TabIndex = 0;
            this.menuConfigParentBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // menuConfigParentBindingSource
            // 
            this.menuConfigParentBindingSource.DataSource = typeof(FlexModel.MenuItem);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
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
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // menuConfigParentBindingNavigatorSaveItem
            // 
            this.menuConfigParentBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuConfigParentBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("menuConfigParentBindingNavigatorSaveItem.Image")));
            this.menuConfigParentBindingNavigatorSaveItem.Name = "menuConfigParentBindingNavigatorSaveItem";
            this.menuConfigParentBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.menuConfigParentBindingNavigatorSaveItem.Text = "Save Data";
            this.menuConfigParentBindingNavigatorSaveItem.Click += new System.EventHandler(this.menuConfigParentBindingNavigatorSaveItem_Click);
            // 
            // nameTextEdit
            // 
            this.nameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.menuConfigParentBindingSource, "Name", true));
            this.nameTextEdit.Location = new System.Drawing.Point(917, 95);
            this.nameTextEdit.Name = "nameTextEdit";
            this.nameTextEdit.Properties.ReadOnly = true;
            this.nameTextEdit.Size = new System.Drawing.Size(324, 20);
            this.nameTextEdit.TabIndex = 4;
            // 
            // captionTextEdit
            // 
            this.captionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.menuConfigParentBindingSource, "Caption", true));
            this.captionTextEdit.Location = new System.Drawing.Point(917, 134);
            this.captionTextEdit.Name = "captionTextEdit";
            this.captionTextEdit.Size = new System.Drawing.Size(324, 20);
            this.captionTextEdit.TabIndex = 10;
            // 
            // imagePathTextEdit
            // 
            this.imagePathTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.menuConfigParentBindingSource, "ImagePath", true));
            this.imagePathTextEdit.Location = new System.Drawing.Point(917, 178);
            this.imagePathTextEdit.Name = "imagePathTextEdit";
            this.imagePathTextEdit.Size = new System.Drawing.Size(324, 20);
            this.imagePathTextEdit.TabIndex = 12;
            // 
            // positionSpinEdit
            // 
            this.positionSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.menuConfigParentBindingSource, "Position", true));
            this.positionSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.positionSpinEdit.Location = new System.Drawing.Point(917, 220);
            this.positionSpinEdit.Name = "positionSpinEdit";
            this.positionSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.positionSpinEdit.Size = new System.Drawing.Size(100, 20);
            this.positionSpinEdit.TabIndex = 14;
            // 
            // visibleCheckEdit
            // 
            this.visibleCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.menuConfigParentBindingSource, "Visible", true));
            this.visibleCheckEdit.Location = new System.Drawing.Point(915, 264);
            this.visibleCheckEdit.Name = "visibleCheckEdit";
            this.visibleCheckEdit.Properties.Caption = "";
            this.visibleCheckEdit.Size = new System.Drawing.Size(21, 19);
            this.visibleCheckEdit.TabIndex = 16;
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colAppName,
            this.colName,
            this.colType,
            this.colDropDown,
            this.colCaption,
            this.colImagePath,
            this.colPosition,
            this.colParentCode,
            this.colVisible});
            this.treeList1.DataSource = this.menuConfigParentBindingSource;
            this.treeList1.DragNodesMode = DevExpress.XtraTreeList.TreeListDragNodesMode.Standard;
            this.treeList1.Location = new System.Drawing.Point(31, 55);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.DragNodes = true;
            this.treeList1.Size = new System.Drawing.Size(801, 820);
            this.treeList1.TabIndex = 17;
            // 
            // colAppName
            // 
            this.colAppName.FieldName = "AppName";
            this.colAppName.Name = "colAppName";
            this.colAppName.Width = 87;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 87;
            // 
            // colType
            // 
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            this.colType.Width = 87;
            // 
            // colDropDown
            // 
            this.colDropDown.FieldName = "DropDown";
            this.colDropDown.Name = "colDropDown";
            this.colDropDown.Visible = true;
            this.colDropDown.VisibleIndex = 1;
            this.colDropDown.Width = 87;
            // 
            // colCaption
            // 
            this.colCaption.FieldName = "Caption";
            this.colCaption.Name = "colCaption";
            this.colCaption.Visible = true;
            this.colCaption.VisibleIndex = 2;
            this.colCaption.Width = 87;
            // 
            // colImagePath
            // 
            this.colImagePath.FieldName = "ImagePath";
            this.colImagePath.Name = "colImagePath";
            this.colImagePath.Visible = true;
            this.colImagePath.VisibleIndex = 3;
            this.colImagePath.Width = 87;
            // 
            // colPosition
            // 
            this.colPosition.FieldName = "Position";
            this.colPosition.Name = "colPosition";
            this.colPosition.Width = 87;
            // 
            // colParentCode
            // 
            this.colParentCode.FieldName = "ParentCode";
            this.colParentCode.Name = "colParentCode";
            this.colParentCode.Width = 87;
            // 
            // colVisible
            // 
            this.colVisible.FieldName = "Visible";
            this.colVisible.Name = "colVisible";
            this.colVisible.Width = 87;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.menuItemRestrictionBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(848, 350);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(376, 200);
            this.gridControl1.TabIndex = 18;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // menuItemRestrictionBindingSource
            // 
            this.menuItemRestrictionBindingSource.DataSource = typeof(FlexModel.MenuItemSecurity);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colUserID,
            this.colMenuItem_ID,
            this.colAGCYLOG,
            this.colMenuConfig});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colUserID
            // 
            this.colUserID.FieldName = "UserID";
            this.colUserID.Name = "colUserID";
            this.colUserID.Visible = true;
            this.colUserID.VisibleIndex = 0;
            // 
            // colMenuItem_ID
            // 
            this.colMenuItem_ID.FieldName = "MenuItem_ID";
            this.colMenuItem_ID.Name = "colMenuItem_ID";
            this.colMenuItem_ID.Visible = true;
            this.colMenuItem_ID.VisibleIndex = 1;
            // 
            // colAGCYLOG
            // 
            this.colAGCYLOG.FieldName = "AGCYLOG";
            this.colAGCYLOG.Name = "colAGCYLOG";
            // 
            // colMenuConfig
            // 
            this.colMenuConfig.FieldName = "MenuConfig";
            this.colMenuConfig.Name = "colMenuConfig";
            // 
            // addNewMenuItem
            // 
            this.addNewMenuItem.Location = new System.Drawing.Point(866, 569);
            this.addNewMenuItem.Name = "addNewMenuItem";
            this.addNewMenuItem.Size = new System.Drawing.Size(75, 23);
            this.addNewMenuItem.TabIndex = 19;
            this.addNewMenuItem.Text = "Add New";
            this.addNewMenuItem.Click += new System.EventHandler(this.addNewMenuItem_Click);
            // 
            // deleteMenuItem
            // 
            this.deleteMenuItem.Location = new System.Drawing.Point(1054, 569);
            this.deleteMenuItem.Name = "deleteMenuItem";
            this.deleteMenuItem.Size = new System.Drawing.Size(75, 23);
            this.deleteMenuItem.TabIndex = 20;
            this.deleteMenuItem.Text = "Delete";
            this.deleteMenuItem.Click += new System.EventHandler(this.deleteMenuItem_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(960, 569);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 21;
            this.saveButton.Text = "Save";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // panelControlStatus
            // 
            this.panelControlStatus.Appearance.Options.UseTextOptions = true;
            this.panelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("panelControlStatus.ContentImage")));
            this.panelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.panelControlStatus.Controls.Add(this.LabelStatus);
            this.panelControlStatus.Location = new System.Drawing.Point(307, 0);
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
            // MenuAdjustForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1264, 750);
            this.Controls.Add(this.panelControlStatus);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.deleteMenuItem);
            this.Controls.Add(this.addNewMenuItem);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.treeList1);
            this.Controls.Add(visibleLabel);
            this.Controls.Add(this.visibleCheckEdit);
            this.Controls.Add(positionLabel);
            this.Controls.Add(this.positionSpinEdit);
            this.Controls.Add(imagePathLabel);
            this.Controls.Add(this.imagePathTextEdit);
            this.Controls.Add(captionLabel);
            this.Controls.Add(this.captionTextEdit);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameTextEdit);
            this.Controls.Add(this.menuConfigParentBindingNavigator);
            this.MinimizeBox = false;
            this.Name = "MenuAdjustForm";
            this.ShowInTaskbar = false;
            this.Text = "MenuAdjustForm";
            ((System.ComponentModel.ISupportInitialize)(this.menuConfigParentBindingNavigator)).EndInit();
            this.menuConfigParentBindingNavigator.ResumeLayout(false);
            this.menuConfigParentBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuConfigParentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.captionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagePathTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visibleCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemRestrictionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).EndInit();
            this.panelControlStatus.ResumeLayout(false);
            this.panelControlStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource menuConfigParentBindingSource;
        private System.Windows.Forms.BindingNavigator menuConfigParentBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton menuConfigParentBindingNavigatorSaveItem;
        private DevExpress.XtraEditors.TextEdit nameTextEdit;
        private DevExpress.XtraEditors.TextEdit captionTextEdit;
        private DevExpress.XtraEditors.TextEdit imagePathTextEdit;
        private DevExpress.XtraEditors.SpinEdit positionSpinEdit;
        private DevExpress.XtraEditors.CheckEdit visibleCheckEdit;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAppName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colType;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDropDown;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCaption;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colImagePath;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPosition;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colParentCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colVisible;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource menuItemRestrictionBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colMenuItem_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colAGCYLOG;
        private DevExpress.XtraGrid.Columns.GridColumn colMenuConfig;
        private DevExpress.XtraEditors.SimpleButton addNewMenuItem;
        private DevExpress.XtraEditors.SimpleButton deleteMenuItem;
        private DevExpress.XtraEditors.SimpleButton saveButton;
        private DevExpress.XtraEditors.PanelControl panelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
    }
}