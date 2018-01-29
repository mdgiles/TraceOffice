namespace TraceForms
{
    partial class HtlChainForm
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
            System.Windows.Forms.Label cODELabel;
            System.Windows.Forms.Label dESCLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HtlChainForm));
            this.HtlChainBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.HtlChainBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.hTLCHAINBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.dESCTextBox = new DevExpress.XtraEditors.TextEdit();
            this.cODETextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.GridControlHtlChain = new DevExpress.XtraGrid.GridControl();
            this.GridViewHtlChain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDESC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOTEL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHTLBRAND = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOTELs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHTLBRANDs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControlStatus = new DevExpress.XtraEditors.PanelControl();
            this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
            cODELabel = new System.Windows.Forms.Label();
            dESCLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.HtlChainBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HtlChainBindingNavigator)).BeginInit();
            this.HtlChainBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dESCTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cODETextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlHtlChain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewHtlChain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).BeginInit();
            this.panelControlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // cODELabel
            // 
            cODELabel.AutoSize = true;
            cODELabel.Location = new System.Drawing.Point(59, 76);
            cODELabel.Name = "cODELabel";
            cODELabel.Size = new System.Drawing.Size(32, 13);
            cODELabel.TabIndex = 16;
            cODELabel.Text = "Code";
            // 
            // dESCLabel
            // 
            dESCLabel.AutoSize = true;
            dESCLabel.Location = new System.Drawing.Point(59, 112);
            dESCLabel.Name = "dESCLabel";
            dESCLabel.Size = new System.Drawing.Size(60, 13);
            dESCLabel.TabIndex = 17;
            dESCLabel.Text = "Description";
            // 
            // HtlChainBindingSource
            // 
            this.HtlChainBindingSource.DataSource = typeof(FlexModel.HTLCHAIN);
            this.HtlChainBindingSource.CurrentChanged += new System.EventHandler(this.HtlChainBindingSource_CurrentChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // HtlChainBindingNavigator
            // 
            this.HtlChainBindingNavigator.AddNewItem = null;
            this.HtlChainBindingNavigator.BindingSource = this.HtlChainBindingSource;
            this.HtlChainBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.HtlChainBindingNavigator.DeleteItem = null;
            this.HtlChainBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.hTLCHAINBindingNavigatorSaveItem});
            this.HtlChainBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.HtlChainBindingNavigator.MoveFirstItem = null;
            this.HtlChainBindingNavigator.MoveLastItem = null;
            this.HtlChainBindingNavigator.MoveNextItem = null;
            this.HtlChainBindingNavigator.MovePreviousItem = null;
            this.HtlChainBindingNavigator.Name = "HtlChainBindingNavigator";
            this.HtlChainBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.HtlChainBindingNavigator.Size = new System.Drawing.Size(1020, 25);
            this.HtlChainBindingNavigator.TabIndex = 13;
            this.HtlChainBindingNavigator.Text = "bindingNavigator1";
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
            // hTLCHAINBindingNavigatorSaveItem
            // 
            this.hTLCHAINBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.hTLCHAINBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("hTLCHAINBindingNavigatorSaveItem.Image")));
            this.hTLCHAINBindingNavigatorSaveItem.Name = "hTLCHAINBindingNavigatorSaveItem";
            this.hTLCHAINBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.hTLCHAINBindingNavigatorSaveItem.Text = "Save Data";
            this.hTLCHAINBindingNavigatorSaveItem.Click += new System.EventHandler(this.hTLCHAINBindingNavigatorSaveItem_Click);
            // 
            // dESCTextBox
            // 
            this.dESCTextBox.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.HtlChainBindingSource, "DESC", true));
            this.dESCTextBox.EnterMoveNextControl = true;
            this.dESCTextBox.Location = new System.Drawing.Point(122, 109);
            this.dESCTextBox.Name = "dESCTextBox";
            this.dESCTextBox.Properties.MaxLength = 50;
            this.dESCTextBox.Size = new System.Drawing.Size(270, 20);
            this.dESCTextBox.TabIndex = 2;
            this.dESCTextBox.Enter += new System.EventHandler(this.enterControl);
            this.dESCTextBox.Leave += new System.EventHandler(this.dESCTextBox_Leave);
            // 
            // cODETextEdit
            // 
            this.cODETextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.HtlChainBindingSource, "CODE", true));
            this.cODETextEdit.EnterMoveNextControl = true;
            this.cODETextEdit.Location = new System.Drawing.Point(122, 73);
            this.cODETextEdit.Name = "cODETextEdit";
            this.cODETextEdit.Properties.MaxLength = 12;
            this.cODETextEdit.Size = new System.Drawing.Size(148, 20);
            this.cODETextEdit.TabIndex = 1;
            this.cODETextEdit.Enter += new System.EventHandler(this.enterControl);
            this.cODETextEdit.Leave += new System.EventHandler(this.cODETextEdit_Leave);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(31, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 13);
            this.labelControl1.TabIndex = 19;
            this.labelControl1.Text = "Hotel Chains";
            // 
            // GridControlHtlChain
            // 
            this.GridControlHtlChain.DataSource = this.HtlChainBindingSource;
            this.GridControlHtlChain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControlHtlChain.Location = new System.Drawing.Point(0, 0);
            this.GridControlHtlChain.MainView = this.GridViewHtlChain;
            this.GridControlHtlChain.Name = "GridControlHtlChain";
            this.GridControlHtlChain.Size = new System.Drawing.Size(304, 717);
            this.GridControlHtlChain.TabIndex = 14;
            this.GridControlHtlChain.TabStop = false;
            this.GridControlHtlChain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewHtlChain});
            // 
            // GridViewHtlChain
            // 
            this.GridViewHtlChain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDisplayName,
            this.colCODE,
            this.colDESC,
            this.colHOTEL,
            this.colHTLBRAND});
            this.GridViewHtlChain.GridControl = this.GridControlHtlChain;
            this.GridViewHtlChain.Name = "GridViewHtlChain";
            this.GridViewHtlChain.OptionsView.ShowAutoFilterRow = true;
            this.GridViewHtlChain.OptionsView.ShowGroupPanel = false;
            this.GridViewHtlChain.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            this.GridViewHtlChain.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            this.GridViewHtlChain.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView1_BeforeLeaveRow);
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
            // colHOTEL
            // 
            this.colHOTEL.FieldName = "HOTEL";
            this.colHOTEL.Name = "colHOTEL";
            // 
            // colHTLBRAND
            // 
            this.colHTLBRAND.FieldName = "HTLBRAND";
            this.colHTLBRAND.Name = "colHTLBRAND";
            // 
            // colHOTELs
            // 
            this.colHOTELs.FieldName = "HOTELs";
            this.colHOTELs.Name = "colHOTELs";
            this.colHOTELs.Visible = true;
            this.colHOTELs.VisibleIndex = 2;
            // 
            // colHTLBRANDs
            // 
            this.colHTLBRANDs.FieldName = "HTLBRANDs";
            this.colHTLBRANDs.Name = "colHTLBRANDs";
            this.colHTLBRANDs.Visible = true;
            this.colHTLBRANDs.VisibleIndex = 3;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 25);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.AutoScroll = true;
            this.splitContainerControl1.Panel1.Controls.Add(this.GridControlHtlChain);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.AutoScroll = true;
            this.splitContainerControl1.Panel2.Controls.Add(dESCLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.cODETextEdit);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel2.Controls.Add(cODELabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.dESCTextBox);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1020, 717);
            this.splitContainerControl1.SplitterPosition = 304;
            this.splitContainerControl1.TabIndex = 16;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panelControlStatus
            // 
            this.panelControlStatus.Appearance.Options.UseTextOptions = true;
            this.panelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("panelControlStatus.ContentImage")));
            this.panelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.panelControlStatus.Controls.Add(this.LabelStatus);
            this.panelControlStatus.Location = new System.Drawing.Point(322, 2);
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
            // HtlChainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 742);
            this.Controls.Add(this.panelControlStatus);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.HtlChainBindingNavigator);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "HtlChainForm";
            this.ShowInTaskbar = false;
            this.Text = "Hotel Chain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HtlChainForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HtlChainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.HtlChainBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HtlChainBindingNavigator)).EndInit();
            this.HtlChainBindingNavigator.ResumeLayout(false);
            this.HtlChainBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dESCTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cODETextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlHtlChain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewHtlChain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).EndInit();
            this.panelControlStatus.ResumeLayout(false);
            this.panelControlStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource HtlChainBindingSource;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraGrid.GridControl GridControlHtlChain;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewHtlChain;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit cODETextEdit;
        private DevExpress.XtraEditors.TextEdit dESCTextBox;
        private System.Windows.Forms.BindingNavigator HtlChainBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton hTLCHAINBindingNavigatorSaveItem;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTELs;
        private DevExpress.XtraGrid.Columns.GridColumn colHTLBRANDs;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplayName;
        private DevExpress.XtraGrid.Columns.GridColumn colCODE;
        private DevExpress.XtraGrid.Columns.GridColumn colDESC;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTEL;
        private DevExpress.XtraGrid.Columns.GridColumn colHTLBRAND;


    }
}