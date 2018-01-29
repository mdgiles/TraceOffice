namespace TraceForms
{
    partial class ExtranetSecurityForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtranetSecurityForm));
            this.TextEditUser = new DevExpress.XtraEditors.TextEdit();
            this.UsersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.GridControlUsers = new DevExpress.XtraGrid.GridControl();
            this.GridViewUsers = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPassword = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsAgent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInactive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReadOnly = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TextEditPassword = new DevExpress.XtraEditors.TextEdit();
            this.UsersBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.ButtonDeletePermission = new DevExpress.XtraEditors.SimpleButton();
            this.GridControlPermissions = new DevExpress.XtraGrid.GridControl();
            this.PermissionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GridViewPermissions = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHtlChain_Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditChain = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.hTLCHAINBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colHtlBrand_Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProduct_Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ButtonAddPermission = new DevExpress.XtraEditors.SimpleButton();
            this.ImageComboBoxEditUser = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.CheckEditAgent = new DevExpress.XtraEditors.CheckEdit();
            this.CheckEditReadOnly = new DevExpress.XtraEditors.CheckEdit();
            this.CheckEditInactive = new DevExpress.XtraEditors.CheckEdit();
            this.panelControlStatus = new DevExpress.XtraEditors.PanelControl();
            this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsersBindingNavigator)).BeginInit();
            this.UsersBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlPermissions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PermissionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewPermissions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditChain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hTLCHAINBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditAgent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditReadOnly.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditInactive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).BeginInit();
            this.panelControlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextEditUser
            // 
            this.TextEditUser.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.UsersBindingSource, "UserID", true));
            this.TextEditUser.EnterMoveNextControl = true;
            this.TextEditUser.Location = new System.Drawing.Point(156, 143);
            this.TextEditUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TextEditUser.Name = "TextEditUser";
            this.TextEditUser.Properties.MaxLength = 256;
            this.TextEditUser.Size = new System.Drawing.Size(238, 26);
            this.TextEditUser.TabIndex = 2;
            this.TextEditUser.Enter += new System.EventHandler(this.enterControl);
            this.TextEditUser.Leave += new System.EventHandler(this.TextEditUser_Leave);
            // 
            // UsersBindingSource
            // 
            this.UsersBindingSource.DataSource = typeof(FlexModel.ExtranetUser);
            this.UsersBindingSource.CurrentChanged += new System.EventHandler(this.UsersBindingSource_CurrentChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(69, 189);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(67, 19);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Password";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(69, 148);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(32, 19);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "User";
            // 
            // GridControlUsers
            // 
            this.GridControlUsers.DataSource = this.UsersBindingSource;
            this.GridControlUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControlUsers.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GridControlUsers.Location = new System.Drawing.Point(0, 0);
            this.GridControlUsers.MainView = this.GridViewUsers;
            this.GridControlUsers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GridControlUsers.Name = "GridControlUsers";
            this.GridControlUsers.Size = new System.Drawing.Size(384, 1053);
            this.GridControlUsers.TabIndex = 0;
            this.GridControlUsers.TabStop = false;
            this.GridControlUsers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewUsers});
            // 
            // GridViewUsers
            // 
            this.GridViewUsers.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserID,
            this.colPassword,
            this.colIsAgent,
            this.colInactive,
            this.colReadOnly});
            this.GridViewUsers.GridControl = this.GridControlUsers;
            this.GridViewUsers.Name = "GridViewUsers";
            this.GridViewUsers.OptionsCustomization.AllowRowSizing = true;
            this.GridViewUsers.OptionsView.AllowHtmlDrawHeaders = true;
            this.GridViewUsers.OptionsView.ShowAutoFilterRow = true;
            this.GridViewUsers.OptionsView.ShowGroupPanel = false;
            this.GridViewUsers.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewUsers_CellValueChanging);
            this.GridViewUsers.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridViewUsers_InvalidRowException);
            this.GridViewUsers.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridViewUsers_BeforeLeaveRow);
            // 
            // colUserID
            // 
            this.colUserID.FieldName = "UserID";
            this.colUserID.Name = "colUserID";
            this.colUserID.Visible = true;
            this.colUserID.VisibleIndex = 0;
            // 
            // colPassword
            // 
            this.colPassword.FieldName = "Password";
            this.colPassword.Name = "colPassword";
            // 
            // colIsAgent
            // 
            this.colIsAgent.FieldName = "IsAgent";
            this.colIsAgent.Name = "colIsAgent";
            // 
            // colInactive
            // 
            this.colInactive.FieldName = "Inactive";
            this.colInactive.Name = "colInactive";
            // 
            // colReadOnly
            // 
            this.colReadOnly.FieldName = "ReadOnly";
            this.colReadOnly.Name = "colReadOnly";
            // 
            // TextEditPassword
            // 
            this.TextEditPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.UsersBindingSource, "Password", true));
            this.TextEditPassword.EnterMoveNextControl = true;
            this.TextEditPassword.Location = new System.Drawing.Point(156, 184);
            this.TextEditPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TextEditPassword.Name = "TextEditPassword";
            this.TextEditPassword.Properties.MaxLength = 40;
            this.TextEditPassword.Size = new System.Drawing.Size(238, 26);
            this.TextEditPassword.TabIndex = 5;
            this.TextEditPassword.Enter += new System.EventHandler(this.enterControl);
            this.TextEditPassword.Leave += new System.EventHandler(this.TextEditPassword_Leave);
            // 
            // UsersBindingNavigator
            // 
            this.UsersBindingNavigator.AddNewItem = null;
            this.UsersBindingNavigator.BindingSource = this.UsersBindingSource;
            this.UsersBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.UsersBindingNavigator.DeleteItem = null;
            this.UsersBindingNavigator.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.UsersBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.UsersBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.UsersBindingNavigator.MoveFirstItem = null;
            this.UsersBindingNavigator.MoveLastItem = null;
            this.UsersBindingNavigator.MoveNextItem = null;
            this.UsersBindingNavigator.MovePreviousItem = null;
            this.UsersBindingNavigator.Name = "UsersBindingNavigator";
            this.UsersBindingNavigator.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.UsersBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.UsersBindingNavigator.Size = new System.Drawing.Size(1530, 31);
            this.UsersBindingNavigator.TabIndex = 31;
            this.UsersBindingNavigator.Text = "bindingNavigator1";
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
            this.bindingNavigatorPositionItem.Click += new System.EventHandler(this.bindingNavigatorPositionItem_Enter);
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
            this.bindingNavigatorSaveItem.Click += new System.EventHandler(this.bindingNavigatorSaveItem_Click);
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
            this.splitContainerControl1.Panel1.Controls.Add(this.GridControlUsers);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.AutoScroll = true;
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl4);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl3);
            this.splitContainerControl1.Panel2.Controls.Add(this.ButtonDeletePermission);
            this.splitContainerControl1.Panel2.Controls.Add(this.GridControlPermissions);
            this.splitContainerControl1.Panel2.Controls.Add(this.ButtonAddPermission);
            this.splitContainerControl1.Panel2.Controls.Add(this.TextEditUser);
            this.splitContainerControl1.Panel2.Controls.Add(this.ImageComboBoxEditUser);
            this.splitContainerControl1.Panel2.Controls.Add(this.CheckEditAgent);
            this.splitContainerControl1.Panel2.Controls.Add(this.CheckEditReadOnly);
            this.splitContainerControl1.Panel2.Controls.Add(this.CheckEditInactive);
            this.splitContainerControl1.Panel2.Controls.Add(this.TextEditPassword);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1530, 1053);
            this.splitContainerControl1.SplitterPosition = 256;
            this.splitContainerControl1.TabIndex = 44;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Location = new System.Drawing.Point(46, 314);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(493, 22);
            this.labelControl4.TabIndex = 74;
            this.labelControl4.Text = "Permissions (Leave empty to allow access to all hotels)";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Location = new System.Drawing.Point(46, 58);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(41, 22);
            this.labelControl3.TabIndex = 73;
            this.labelControl3.Text = "User";
            // 
            // ButtonDeletePermission
            // 
            this.ButtonDeletePermission.Image = ((System.Drawing.Image)(resources.GetObject("ButtonDeletePermission.Image")));
            this.ButtonDeletePermission.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ButtonDeletePermission.Location = new System.Drawing.Point(777, 424);
            this.ButtonDeletePermission.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonDeletePermission.Name = "ButtonDeletePermission";
            this.ButtonDeletePermission.Size = new System.Drawing.Size(62, 53);
            this.ButtonDeletePermission.TabIndex = 72;
            this.ButtonDeletePermission.TabStop = false;
            this.ButtonDeletePermission.Text = "simpleButton4";
            this.ButtonDeletePermission.Click += new System.EventHandler(this.ButtonDeletePermission_Click);
            // 
            // GridControlPermissions
            // 
            this.GridControlPermissions.DataSource = this.PermissionsBindingSource;
            this.GridControlPermissions.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GridControlPermissions.Location = new System.Drawing.Point(69, 361);
            this.GridControlPermissions.MainView = this.GridViewPermissions;
            this.GridControlPermissions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GridControlPermissions.Name = "GridControlPermissions";
            this.GridControlPermissions.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEditChain});
            this.GridControlPermissions.Size = new System.Drawing.Size(699, 187);
            this.GridControlPermissions.TabIndex = 71;
            this.GridControlPermissions.TabStop = false;
            this.GridControlPermissions.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewPermissions});
            // 
            // PermissionsBindingSource
            // 
            this.PermissionsBindingSource.DataSource = typeof(FlexModel.ExtranetPermission);
            // 
            // GridViewPermissions
            // 
            this.GridViewPermissions.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.GridViewPermissions.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GridViewPermissions.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.GridViewPermissions.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colUserID1,
            this.colHtlChain_Code,
            this.colHtlBrand_Code,
            this.colProduct_Code});
            this.GridViewPermissions.GridControl = this.GridControlPermissions;
            this.GridViewPermissions.Name = "GridViewPermissions";
            this.GridViewPermissions.OptionsView.AllowHtmlDrawHeaders = true;
            this.GridViewPermissions.OptionsView.ShowGroupPanel = false;
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colUserID1
            // 
            this.colUserID1.FieldName = "UserID";
            this.colUserID1.Name = "colUserID1";
            // 
            // colHtlChain_Code
            // 
            this.colHtlChain_Code.Caption = "Hotel Chain";
            this.colHtlChain_Code.ColumnEdit = this.repositoryItemLookUpEditChain;
            this.colHtlChain_Code.FieldName = "HtlChain_Code";
            this.colHtlChain_Code.Name = "colHtlChain_Code";
            this.colHtlChain_Code.Visible = true;
            this.colHtlChain_Code.VisibleIndex = 0;
            // 
            // repositoryItemLookUpEditChain
            // 
            this.repositoryItemLookUpEditChain.AutoHeight = false;
            this.repositoryItemLookUpEditChain.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditChain.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CODE", "CODE", 51, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DisplayName", "Display Name", 74, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEditChain.DataSource = this.hTLCHAINBindingSource;
            this.repositoryItemLookUpEditChain.DisplayMember = "DisplayName";
            this.repositoryItemLookUpEditChain.Name = "repositoryItemLookUpEditChain";
            this.repositoryItemLookUpEditChain.NullText = "<Select Hotel Chain>";
            this.repositoryItemLookUpEditChain.NullValuePromptShowForEmptyValue = true;
            this.repositoryItemLookUpEditChain.ValueMember = "CODE";
            this.repositoryItemLookUpEditChain.EditValueChanged += new System.EventHandler(this.repositoryItemLookUpEditChain_EditValueChanged);
            // 
            // hTLCHAINBindingSource
            // 
            this.hTLCHAINBindingSource.DataSource = typeof(FlexModel.HTLCHAIN);
            // 
            // colHtlBrand_Code
            // 
            this.colHtlBrand_Code.Caption = "Brand";
            this.colHtlBrand_Code.FieldName = "HtlBrand_Code";
            this.colHtlBrand_Code.Name = "colHtlBrand_Code";
            // 
            // colProduct_Code
            // 
            this.colProduct_Code.Caption = "Hotel";
            this.colProduct_Code.FieldName = "Product_Code";
            this.colProduct_Code.Name = "colProduct_Code";
            // 
            // ButtonAddPermission
            // 
            this.ButtonAddPermission.Image = global::TraceForms.Properties.Resources.document_new;
            this.ButtonAddPermission.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ButtonAddPermission.Location = new System.Drawing.Point(777, 361);
            this.ButtonAddPermission.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonAddPermission.Name = "ButtonAddPermission";
            this.ButtonAddPermission.Size = new System.Drawing.Size(62, 54);
            this.ButtonAddPermission.TabIndex = 70;
            this.ButtonAddPermission.Click += new System.EventHandler(this.ButtonAddPermission_Click);
            // 
            // ImageComboBoxEditUser
            // 
            this.ImageComboBoxEditUser.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.UsersBindingSource, "UserID", true));
            this.ImageComboBoxEditUser.EnterMoveNextControl = true;
            this.ImageComboBoxEditUser.Location = new System.Drawing.Point(156, 143);
            this.ImageComboBoxEditUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ImageComboBoxEditUser.Name = "ImageComboBoxEditUser";
            this.ImageComboBoxEditUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ImageComboBoxEditUser.Size = new System.Drawing.Size(279, 26);
            this.ImageComboBoxEditUser.TabIndex = 3;
            this.ImageComboBoxEditUser.Visible = false;
            this.ImageComboBoxEditUser.Enter += new System.EventHandler(this.enterControl);
            this.ImageComboBoxEditUser.Leave += new System.EventHandler(this.ImageComboBoxEditUser_Leave);
            // 
            // CheckEditAgent
            // 
            this.CheckEditAgent.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.UsersBindingSource, "IsAgent", true));
            this.CheckEditAgent.EnterMoveNextControl = true;
            this.CheckEditAgent.Location = new System.Drawing.Point(66, 101);
            this.CheckEditAgent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CheckEditAgent.Name = "CheckEditAgent";
            this.CheckEditAgent.Properties.Caption = "Res agent";
            this.CheckEditAgent.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditAgent.Size = new System.Drawing.Size(116, 23);
            this.CheckEditAgent.TabIndex = 0;
            this.CheckEditAgent.CheckedChanged += new System.EventHandler(this.CheckEditAgent_CheckedChanged);
            this.CheckEditAgent.Modified += new System.EventHandler(this.checkModified);
            // 
            // CheckEditReadOnly
            // 
            this.CheckEditReadOnly.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.UsersBindingSource, "ReadOnly", true));
            this.CheckEditReadOnly.EnterMoveNextControl = true;
            this.CheckEditReadOnly.Location = new System.Drawing.Point(66, 259);
            this.CheckEditReadOnly.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CheckEditReadOnly.Name = "CheckEditReadOnly";
            this.CheckEditReadOnly.Properties.Caption = "Read only";
            this.CheckEditReadOnly.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditReadOnly.Properties.Modified += new System.EventHandler(this.checkModified);
            this.CheckEditReadOnly.Size = new System.Drawing.Size(116, 23);
            this.CheckEditReadOnly.TabIndex = 7;
            // 
            // CheckEditInactive
            // 
            this.CheckEditInactive.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.UsersBindingSource, "Inactive", true));
            this.CheckEditInactive.EnterMoveNextControl = true;
            this.CheckEditInactive.Location = new System.Drawing.Point(66, 222);
            this.CheckEditInactive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CheckEditInactive.Name = "CheckEditInactive";
            this.CheckEditInactive.Properties.Caption = "Inactive";
            this.CheckEditInactive.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CheckEditInactive.Properties.Modified += new System.EventHandler(this.checkModified);
            this.CheckEditInactive.Size = new System.Drawing.Size(116, 23);
            this.CheckEditInactive.TabIndex = 6;
            // 
            // panelControlStatus
            // 
            this.panelControlStatus.Appearance.Options.UseTextOptions = true;
            this.panelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("panelControlStatus.ContentImage")));
            this.panelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.panelControlStatus.Controls.Add(this.LabelStatus);
            this.panelControlStatus.Location = new System.Drawing.Point(462, 0);
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
            // ExtranetSecurityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1530, 1084);
            this.Controls.Add(this.panelControlStatus);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.UsersBindingNavigator);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimizeBox = false;
            this.Name = "ExtranetSecurityForm";
            this.ShowInTaskbar = false;
            this.Text = "Extranet Security";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExtranetSecurityForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExtranetSecurityForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.TextEditUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsersBindingNavigator)).EndInit();
            this.UsersBindingNavigator.ResumeLayout(false);
            this.UsersBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridControlPermissions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PermissionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewPermissions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditChain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hTLCHAINBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditAgent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditReadOnly.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditInactive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).EndInit();
            this.panelControlStatus.ResumeLayout(false);
            this.panelControlStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl GridControlUsers;
        private System.Windows.Forms.BindingSource UsersBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewUsers;
        private DevExpress.XtraEditors.TextEdit TextEditPassword;
        private System.Windows.Forms.BindingNavigator UsersBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton bindingNavigatorSaveItem;
        private DevExpress.XtraEditors.TextEdit TextEditUser;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
        private DevExpress.XtraEditors.CheckEdit CheckEditAgent;
        private DevExpress.XtraEditors.CheckEdit CheckEditReadOnly;
        private DevExpress.XtraEditors.CheckEdit CheckEditInactive;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colPassword;
        private DevExpress.XtraGrid.Columns.GridColumn colIsAgent;
        private DevExpress.XtraGrid.Columns.GridColumn colInactive;
        private DevExpress.XtraGrid.Columns.GridColumn colReadOnly;
        private DevExpress.XtraEditors.ImageComboBoxEdit ImageComboBoxEditUser;
        private DevExpress.XtraEditors.SimpleButton ButtonDeletePermission;
        private DevExpress.XtraGrid.GridControl GridControlPermissions;
        private System.Windows.Forms.BindingSource PermissionsBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewPermissions;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID1;
        private DevExpress.XtraGrid.Columns.GridColumn colHtlChain_Code;
        private DevExpress.XtraGrid.Columns.GridColumn colHtlBrand_Code;
        private DevExpress.XtraGrid.Columns.GridColumn colProduct_Code;
        private DevExpress.XtraEditors.SimpleButton ButtonAddPermission;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditChain;
        private System.Windows.Forms.BindingSource hTLCHAINBindingSource;

    }
}