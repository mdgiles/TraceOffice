namespace TraceForms
{
    partial class RoleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoleForm));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.GridControlRole = new DevExpress.XtraGrid.GridControl();
            this.RoleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GridViewRole = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDESC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tYPEComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dESCTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.RoleBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.rOLEBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.TextEditCode = new DevExpress.XtraEditors.TextEdit();
            this.panelControlStatus = new DevExpress.XtraEditors.PanelControl();
            this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tYPEComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dESCTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoleBindingNavigator)).BeginInit();
            this.RoleBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).BeginInit();
            this.panelControlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(34, 52);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(51, 13);
            this.labelControl1.TabIndex = 15;
            this.labelControl1.Text = "User Roles";
            // 
            // GridControlRole
            // 
            this.GridControlRole.DataSource = this.RoleBindingSource;
            this.GridControlRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControlRole.Location = new System.Drawing.Point(0, 0);
            this.GridControlRole.MainView = this.GridViewRole;
            this.GridControlRole.Name = "GridControlRole";
            this.GridControlRole.Size = new System.Drawing.Size(276, 717);
            this.GridControlRole.TabIndex = 12;
            this.GridControlRole.TabStop = false;
            this.GridControlRole.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewRole});
            // 
            // RoleBindingSource
            // 
            this.RoleBindingSource.DataSource = typeof(FlexModel.ROLE);
            this.RoleBindingSource.CurrentChanged += new System.EventHandler(this.RoleBindingSource_CurrentChanged);
            // 
            // GridViewRole
            // 
            this.GridViewRole.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTYPE,
            this.colCODE,
            this.colDESC});
            this.GridViewRole.GridControl = this.GridControlRole;
            this.GridViewRole.Name = "GridViewRole";
            this.GridViewRole.OptionsView.ShowAutoFilterRow = true;
            this.GridViewRole.OptionsView.ShowGroupPanel = false;
            this.GridViewRole.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            this.GridViewRole.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            this.GridViewRole.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView1_BeforeLeaveRow);
            // 
            // colTYPE
            // 
            this.colTYPE.FieldName = "TYPE";
            this.colTYPE.Name = "colTYPE";
            this.colTYPE.Visible = true;
            this.colTYPE.VisibleIndex = 0;
            // 
            // colCODE
            // 
            this.colCODE.FieldName = "CODE";
            this.colCODE.Name = "colCODE";
            this.colCODE.Visible = true;
            this.colCODE.VisibleIndex = 1;
            // 
            // colDESC
            // 
            this.colDESC.FieldName = "DESC";
            this.colDESC.Name = "colDESC";
            this.colDESC.Visible = true;
            this.colDESC.VisibleIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Type";
            // 
            // tYPEComboBoxEdit
            // 
            this.tYPEComboBoxEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.RoleBindingSource, "TYPE", true));
            this.tYPEComboBoxEdit.Location = new System.Drawing.Point(105, 97);
            this.tYPEComboBoxEdit.Name = "tYPEComboBoxEdit";
            this.tYPEComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tYPEComboBoxEdit.Properties.Items.AddRange(new object[] {
            "Hotel",
            "Operator",
            "Agency"});
            this.tYPEComboBoxEdit.Properties.MaxLength = 12;
            this.tYPEComboBoxEdit.Size = new System.Drawing.Size(100, 20);
            this.tYPEComboBoxEdit.TabIndex = 1;
            this.tYPEComboBoxEdit.TextChanged += new System.EventHandler(this.tYPEComboBoxEdit_TextChanged_1);
            this.tYPEComboBoxEdit.Enter += new System.EventHandler(this.enterControl);
            this.tYPEComboBoxEdit.Leave += new System.EventHandler(this.type_Leave);
            // 
            // dESCTextEdit
            // 
            this.dESCTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.RoleBindingSource, "DESC", true));
            this.dESCTextEdit.Location = new System.Drawing.Point(105, 149);
            this.dESCTextEdit.Name = "dESCTextEdit";
            this.dESCTextEdit.Properties.MaxLength = 50;
            this.dESCTextEdit.Size = new System.Drawing.Size(296, 20);
            this.dESCTextEdit.TabIndex = 3;
            this.dESCTextEdit.Enter += new System.EventHandler(this.enterControl);
            this.dESCTextEdit.Leave += new System.EventHandler(this.descTextBox_Leave);
            // 
            // RoleBindingNavigator
            // 
            this.RoleBindingNavigator.AddNewItem = null;
            this.RoleBindingNavigator.BindingSource = this.RoleBindingSource;
            this.RoleBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.RoleBindingNavigator.DeleteItem = null;
            this.RoleBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.rOLEBindingNavigatorSaveItem});
            this.RoleBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.RoleBindingNavigator.MoveFirstItem = null;
            this.RoleBindingNavigator.MoveLastItem = null;
            this.RoleBindingNavigator.MoveNextItem = null;
            this.RoleBindingNavigator.MovePreviousItem = null;
            this.RoleBindingNavigator.Name = "RoleBindingNavigator";
            this.RoleBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.RoleBindingNavigator.Size = new System.Drawing.Size(1020, 25);
            this.RoleBindingNavigator.TabIndex = 1;
            this.RoleBindingNavigator.Text = "bindingNavigator1";
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
            this.bindingNavigatorMovePreviousItem.Text = "of {0}";
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
            this.bindingNavigatorAddNewItem.Text = "of {0}";
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
            // rOLEBindingNavigatorSaveItem
            // 
            this.rOLEBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rOLEBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("rOLEBindingNavigatorSaveItem.Image")));
            this.rOLEBindingNavigatorSaveItem.Name = "rOLEBindingNavigatorSaveItem";
            this.rOLEBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.rOLEBindingNavigatorSaveItem.Text = "of {0}";
            this.rOLEBindingNavigatorSaveItem.Click += new System.EventHandler(this.BindingNavigatorSaveItem_Click);
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
            this.splitContainerControl1.Panel1.Controls.Add(this.GridControlRole);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.AutoScroll = true;
            this.splitContainerControl1.Panel2.Controls.Add(this.TextEditCode);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel2.Controls.Add(this.tYPEComboBoxEdit);
            this.splitContainerControl1.Panel2.Controls.Add(this.label3);
            this.splitContainerControl1.Panel2.Controls.Add(this.dESCTextEdit);
            this.splitContainerControl1.Panel2.Controls.Add(this.label2);
            this.splitContainerControl1.Panel2.Controls.Add(this.label1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1020, 717);
            this.splitContainerControl1.SplitterPosition = 276;
            this.splitContainerControl1.TabIndex = 14;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // TextEditCode
            // 
            this.TextEditCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.RoleBindingSource, "CODE", true));
            this.TextEditCode.Location = new System.Drawing.Point(105, 123);
            this.TextEditCode.Name = "TextEditCode";
            this.TextEditCode.Properties.MaxLength = 50;
            this.TextEditCode.Size = new System.Drawing.Size(296, 20);
            this.TextEditCode.TabIndex = 2;
            this.TextEditCode.Enter += new System.EventHandler(this.enterControl);
            this.TextEditCode.Leave += new System.EventHandler(this.ImageComboBoxEditCode_Leave);
            // 
            // panelControlStatus
            // 
            this.panelControlStatus.Appearance.Options.UseTextOptions = true;
            this.panelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("panelControlStatus.ContentImage")));
            this.panelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.panelControlStatus.Controls.Add(this.LabelStatus);
            this.panelControlStatus.Location = new System.Drawing.Point(295, 2);
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
            // RoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 742);
            this.Controls.Add(this.panelControlStatus);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.RoleBindingNavigator);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "RoleForm";
            this.ShowInTaskbar = false;
            this.Text = "User Roles";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RoleForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RoleForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.GridControlRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tYPEComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dESCTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoleBindingNavigator)).EndInit();
            this.RoleBindingNavigator.ResumeLayout(false);
            this.RoleBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).EndInit();
            this.panelControlStatus.ResumeLayout(false);
            this.panelControlStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource RoleBindingSource;
        private System.Windows.Forms.BindingNavigator RoleBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton rOLEBindingNavigatorSaveItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.ComboBoxEdit tYPEComboBoxEdit;
        private DevExpress.XtraEditors.TextEdit dESCTextEdit;
        private DevExpress.XtraGrid.GridControl GridControlRole;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewRole;
        private DevExpress.XtraGrid.Columns.GridColumn colCODE;
        private DevExpress.XtraGrid.Columns.GridColumn colTYPE;
        private DevExpress.XtraGrid.Columns.GridColumn colDESC;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
        private DevExpress.XtraEditors.TextEdit TextEditCode;
    }
}