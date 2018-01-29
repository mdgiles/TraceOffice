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
            this.GridControlHtlType = new DevExpress.XtraGrid.GridControl();
            this.HtlTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GridViewHtlType = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDESCRIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOTEL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TextEditCode = new DevExpress.XtraEditors.TextEdit();
            this.TextBoxDescrip = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.HtlTypeBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.hTLTYPEBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControlStatus = new DevExpress.XtraEditors.PanelControl();
            this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
            dESCRIPLabel = new System.Windows.Forms.Label();
            cODELabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlHtlType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HtlTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewHtlType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxDescrip.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HtlTypeBindingNavigator)).BeginInit();
            this.HtlTypeBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).BeginInit();
            this.panelControlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // dESCRIPLabel
            // 
            dESCRIPLabel.AutoSize = true;
            dESCRIPLabel.Location = new System.Drawing.Point(71, 129);
            dESCRIPLabel.Name = "dESCRIPLabel";
            dESCRIPLabel.Size = new System.Drawing.Size(60, 13);
            dESCRIPLabel.TabIndex = 20;
            dESCRIPLabel.Text = "Description";
            // 
            // cODELabel
            // 
            cODELabel.AutoSize = true;
            cODELabel.Location = new System.Drawing.Point(71, 91);
            cODELabel.Name = "cODELabel";
            cODELabel.Size = new System.Drawing.Size(32, 13);
            cODELabel.TabIndex = 19;
            cODELabel.Text = "Code";
            // 
            // GridControlHtlType
            // 
            this.GridControlHtlType.DataSource = this.HtlTypeBindingSource;
            this.GridControlHtlType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControlHtlType.Location = new System.Drawing.Point(0, 0);
            this.GridControlHtlType.MainView = this.GridViewHtlType;
            this.GridControlHtlType.Name = "GridControlHtlType";
            this.GridControlHtlType.Size = new System.Drawing.Size(298, 717);
            this.GridControlHtlType.TabIndex = 16;
            this.GridControlHtlType.TabStop = false;
            this.GridControlHtlType.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewHtlType});
            // 
            // HtlTypeBindingSource
            // 
            this.HtlTypeBindingSource.DataSource = typeof(FlexModel.HTLTYPE);
            this.HtlTypeBindingSource.CurrentChanged += new System.EventHandler(this.HtlTypeBindingSource_CurrentChanged);
            // 
            // GridViewHtlType
            // 
            this.GridViewHtlType.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDisplayName,
            this.colCODE,
            this.colDESCRIP,
            this.colHOTEL});
            this.GridViewHtlType.GridControl = this.GridControlHtlType;
            this.GridViewHtlType.Name = "GridViewHtlType";
            this.GridViewHtlType.OptionsView.ShowAutoFilterRow = true;
            this.GridViewHtlType.OptionsView.ShowGroupPanel = false;
            this.GridViewHtlType.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            this.GridViewHtlType.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            this.GridViewHtlType.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView1_BeforeLeaveRow);
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
            // colDESCRIP
            // 
            this.colDESCRIP.FieldName = "DESCRIP";
            this.colDESCRIP.Name = "colDESCRIP";
            this.colDESCRIP.Visible = true;
            this.colDESCRIP.VisibleIndex = 1;
            // 
            // colHOTEL
            // 
            this.colHOTEL.FieldName = "HOTEL";
            this.colHOTEL.Name = "colHOTEL";
            // 
            // TextEditCode
            // 
            this.TextEditCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.HtlTypeBindingSource, "CODE", true));
            this.TextEditCode.EnterMoveNextControl = true;
            this.TextEditCode.Location = new System.Drawing.Point(144, 88);
            this.TextEditCode.Name = "TextEditCode";
            this.TextEditCode.Properties.MaxLength = 3;
            this.TextEditCode.Size = new System.Drawing.Size(100, 20);
            this.TextEditCode.TabIndex = 1;
            this.TextEditCode.Enter += new System.EventHandler(this.enterControl);
            this.TextEditCode.Leave += new System.EventHandler(this.cODETextEdit_Leave);
            // 
            // TextBoxDescrip
            // 
            this.TextBoxDescrip.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.HtlTypeBindingSource, "DESCRIP", true));
            this.TextBoxDescrip.EnterMoveNextControl = true;
            this.TextBoxDescrip.Location = new System.Drawing.Point(144, 126);
            this.TextBoxDescrip.Name = "TextBoxDescrip";
            this.TextBoxDescrip.Properties.MaxLength = 12;
            this.TextBoxDescrip.Size = new System.Drawing.Size(172, 20);
            this.TextBoxDescrip.TabIndex = 2;
            this.TextBoxDescrip.Enter += new System.EventHandler(this.enterControl);
            this.TextBoxDescrip.Leave += new System.EventHandler(this.dESCRIPTextBox_Leave);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(60, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 13);
            this.labelControl1.TabIndex = 18;
            this.labelControl1.Text = "Hotel Type";
            // 
            // HtlTypeBindingNavigator
            // 
            this.HtlTypeBindingNavigator.AddNewItem = null;
            this.HtlTypeBindingNavigator.BindingSource = this.HtlTypeBindingSource;
            this.HtlTypeBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.HtlTypeBindingNavigator.DeleteItem = null;
            this.HtlTypeBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.hTLTYPEBindingNavigatorSaveItem});
            this.HtlTypeBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.HtlTypeBindingNavigator.MoveFirstItem = null;
            this.HtlTypeBindingNavigator.MoveLastItem = null;
            this.HtlTypeBindingNavigator.MoveNextItem = null;
            this.HtlTypeBindingNavigator.MovePreviousItem = null;
            this.HtlTypeBindingNavigator.Name = "HtlTypeBindingNavigator";
            this.HtlTypeBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.HtlTypeBindingNavigator.Size = new System.Drawing.Size(1020, 25);
            this.HtlTypeBindingNavigator.TabIndex = 15;
            this.HtlTypeBindingNavigator.Text = "bindingNavigator1";
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
            // hTLTYPEBindingNavigatorSaveItem
            // 
            this.hTLTYPEBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.hTLTYPEBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("hTLTYPEBindingNavigatorSaveItem.Image")));
            this.hTLTYPEBindingNavigatorSaveItem.Name = "hTLTYPEBindingNavigatorSaveItem";
            this.hTLTYPEBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.hTLTYPEBindingNavigatorSaveItem.Text = "Save Data";
            this.hTLTYPEBindingNavigatorSaveItem.Click += new System.EventHandler(this.hTLTYPEBindingNavigatorSaveItem_Click);
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
            this.splitContainerControl1.Panel1.Controls.Add(this.GridControlHtlType);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.AutoScroll = true;
            this.splitContainerControl1.Panel2.Controls.Add(dESCRIPLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.TextEditCode);
            this.splitContainerControl1.Panel2.Controls.Add(cODELabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.TextBoxDescrip);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1020, 717);
            this.splitContainerControl1.SplitterPosition = 298;
            this.splitContainerControl1.TabIndex = 18;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panelControlStatus
            // 
            this.panelControlStatus.Appearance.Options.UseTextOptions = true;
            this.panelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("panelControlStatus.ContentImage")));
            this.panelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.panelControlStatus.Controls.Add(this.LabelStatus);
            this.panelControlStatus.Location = new System.Drawing.Point(328, 2);
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
            // HtlTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 742);
            this.Controls.Add(this.panelControlStatus);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.HtlTypeBindingNavigator);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "HtlTypeForm";
            this.ShowInTaskbar = false;
            this.Text = "Hotel Type";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HtlTypeForm_FormClosing);
            this.Enter += new System.EventHandler(this.enterControl);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HtlTypeForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.GridControlHtlType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HtlTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewHtlType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxDescrip.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HtlTypeBindingNavigator)).EndInit();
            this.HtlTypeBindingNavigator.ResumeLayout(false);
            this.HtlTypeBindingNavigator.PerformLayout();
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

        private DevExpress.XtraGrid.GridControl GridControlHtlType;
        private System.Windows.Forms.BindingSource HtlTypeBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewHtlType;
        private DevExpress.XtraEditors.TextEdit TextEditCode;
        private DevExpress.XtraEditors.TextEdit TextBoxDescrip;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.BindingNavigator HtlTypeBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton hTLTYPEBindingNavigatorSaveItem;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplayName;
        private DevExpress.XtraGrid.Columns.GridColumn colCODE;
        private DevExpress.XtraGrid.Columns.GridColumn colDESCRIP;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTEL;
    }
}