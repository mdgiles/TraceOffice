namespace TraceForms
{
    partial class ChgCodeForm
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
            System.Windows.Forms.Label dESCRIPTIONLabel;
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChgCodeForm));
            this.confirmCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.ChgCodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cODETextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.GridControlChgCode = new DevExpress.XtraGrid.GridControl();
            this.GridViewChgCode = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colConfirm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDESCRIPTION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCONF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDATAFLEX_FILL_01 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDATAFLEX_FILL_02 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ChgCodeBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.cHGCODEBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.dESCRIPTIONTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.panelControlStatus = new DevExpress.XtraEditors.PanelControl();
            this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
            cODELabel = new System.Windows.Forms.Label();
            dESCRIPTIONLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.confirmCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChgCodeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cODETextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlChgCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewChgCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChgCodeBindingNavigator)).BeginInit();
            this.ChgCodeBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dESCRIPTIONTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.xtraScrollableControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).BeginInit();
            this.panelControlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // cODELabel
            // 
            cODELabel.AutoSize = true;
            cODELabel.Location = new System.Drawing.Point(106, 143);
            cODELabel.Name = "cODELabel";
            cODELabel.Size = new System.Drawing.Size(32, 13);
            cODELabel.TabIndex = 11;
            cODELabel.Text = "Code";
            // 
            // dESCRIPTIONLabel
            // 
            dESCRIPTIONLabel.AutoSize = true;
            dESCRIPTIONLabel.Location = new System.Drawing.Point(106, 189);
            dESCRIPTIONLabel.Name = "dESCRIPTIONLabel";
            dESCRIPTIONLabel.Size = new System.Drawing.Size(60, 13);
            dESCRIPTIONLabel.TabIndex = 12;
            dESCRIPTIONLabel.Text = "Description";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(106, 225);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(44, 13);
            label1.TabIndex = 18;
            label1.Text = "Confirm";
            // 
            // confirmCheckEdit
            // 
            this.confirmCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ChgCodeBindingSource, "CONF", true));
            this.confirmCheckEdit.EnterMoveNextControl = true;
            this.confirmCheckEdit.Location = new System.Drawing.Point(181, 222);
            this.confirmCheckEdit.Name = "confirmCheckEdit";
            this.confirmCheckEdit.Properties.Caption = "";
            this.confirmCheckEdit.Properties.ValueChecked = "Y";
            this.confirmCheckEdit.Properties.ValueUnchecked = "N";
            this.confirmCheckEdit.Size = new System.Drawing.Size(22, 19);
            this.confirmCheckEdit.TabIndex = 3;
            this.confirmCheckEdit.Click += new System.EventHandler(this.confirmCheckEdit_Click);
            // 
            // ChgCodeBindingSource
            // 
            this.ChgCodeBindingSource.DataSource = typeof(FlexModel.CHGCODE);
            this.ChgCodeBindingSource.CurrentChanged += new System.EventHandler(this.ChgCodeBindingSource_CurrentChanged);
            // 
            // cODETextEdit
            // 
            this.cODETextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ChgCodeBindingSource, "CODE", true));
            this.cODETextEdit.EnterMoveNextControl = true;
            this.cODETextEdit.Location = new System.Drawing.Point(177, 140);
            this.cODETextEdit.Name = "cODETextEdit";
            this.cODETextEdit.Properties.MaxLength = 3;
            this.cODETextEdit.Size = new System.Drawing.Size(152, 20);
            this.cODETextEdit.TabIndex = 1;
            this.cODETextEdit.Enter += new System.EventHandler(this.enterControl);
            this.cODETextEdit.Leave += new System.EventHandler(this.cODETextEdit_Leave);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(84, 82);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 13);
            this.labelControl1.TabIndex = 17;
            this.labelControl1.Text = "Change Codes";
            // 
            // GridControlChgCode
            // 
            this.GridControlChgCode.DataSource = this.ChgCodeBindingSource;
            this.GridControlChgCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControlChgCode.Location = new System.Drawing.Point(0, 0);
            this.GridControlChgCode.MainView = this.GridViewChgCode;
            this.GridControlChgCode.Name = "GridControlChgCode";
            this.GridControlChgCode.Size = new System.Drawing.Size(320, 717);
            this.GridControlChgCode.TabIndex = 16;
            this.GridControlChgCode.TabStop = false;
            this.GridControlChgCode.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewChgCode});
            // 
            // GridViewChgCode
            // 
            this.GridViewChgCode.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colConfirm,
            this.colDisplayName,
            this.colCODE,
            this.colDESCRIPTION,
            this.colCONF,
            this.colDATAFLEX_FILL_01,
            this.colDATAFLEX_FILL_02});
            this.GridViewChgCode.GridControl = this.GridControlChgCode;
            this.GridViewChgCode.Name = "GridViewChgCode";
            this.GridViewChgCode.OptionsView.ShowAutoFilterRow = true;
            this.GridViewChgCode.OptionsView.ShowGroupPanel = false;
            this.GridViewChgCode.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            this.GridViewChgCode.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            this.GridViewChgCode.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView1_BeforeLeaveRow);
            // 
            // colConfirm
            // 
            this.colConfirm.FieldName = "Confirm";
            this.colConfirm.Name = "colConfirm";
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
            // colDESCRIPTION
            // 
            this.colDESCRIPTION.FieldName = "DESCRIPTION";
            this.colDESCRIPTION.Name = "colDESCRIPTION";
            this.colDESCRIPTION.Visible = true;
            this.colDESCRIPTION.VisibleIndex = 1;
            // 
            // colCONF
            // 
            this.colCONF.FieldName = "CONF";
            this.colCONF.Name = "colCONF";
            // 
            // colDATAFLEX_FILL_01
            // 
            this.colDATAFLEX_FILL_01.FieldName = "DATAFLEX_FILL_01";
            this.colDATAFLEX_FILL_01.Name = "colDATAFLEX_FILL_01";
            // 
            // colDATAFLEX_FILL_02
            // 
            this.colDATAFLEX_FILL_02.FieldName = "DATAFLEX_FILL_02";
            this.colDATAFLEX_FILL_02.Name = "colDATAFLEX_FILL_02";
            // 
            // ChgCodeBindingNavigator
            // 
            this.ChgCodeBindingNavigator.AddNewItem = null;
            this.ChgCodeBindingNavigator.BindingSource = this.ChgCodeBindingSource;
            this.ChgCodeBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.ChgCodeBindingNavigator.DeleteItem = null;
            this.ChgCodeBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.cHGCODEBindingNavigatorSaveItem});
            this.ChgCodeBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.ChgCodeBindingNavigator.MoveFirstItem = null;
            this.ChgCodeBindingNavigator.MoveLastItem = null;
            this.ChgCodeBindingNavigator.MoveNextItem = null;
            this.ChgCodeBindingNavigator.MovePreviousItem = null;
            this.ChgCodeBindingNavigator.Name = "ChgCodeBindingNavigator";
            this.ChgCodeBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.ChgCodeBindingNavigator.Size = new System.Drawing.Size(1020, 25);
            this.ChgCodeBindingNavigator.TabIndex = 10;
            this.ChgCodeBindingNavigator.Text = "bindingNavigator1";
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
            // cHGCODEBindingNavigatorSaveItem
            // 
            this.cHGCODEBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cHGCODEBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("cHGCODEBindingNavigatorSaveItem.Image")));
            this.cHGCODEBindingNavigatorSaveItem.Name = "cHGCODEBindingNavigatorSaveItem";
            this.cHGCODEBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.cHGCODEBindingNavigatorSaveItem.Text = "Save Data";
            this.cHGCODEBindingNavigatorSaveItem.Click += new System.EventHandler(this.cHGCODEBindingNavigatorSaveItem_Click);
            // 
            // dESCRIPTIONTextEdit
            // 
            this.dESCRIPTIONTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ChgCodeBindingSource, "DESCRIPTION", true));
            this.dESCRIPTIONTextEdit.EnterMoveNextControl = true;
            this.dESCRIPTIONTextEdit.Location = new System.Drawing.Point(177, 186);
            this.dESCRIPTIONTextEdit.Name = "dESCRIPTIONTextEdit";
            this.dESCRIPTIONTextEdit.Properties.MaxLength = 15;
            this.dESCRIPTIONTextEdit.Size = new System.Drawing.Size(152, 20);
            this.dESCRIPTIONTextEdit.TabIndex = 2;
            this.dESCRIPTIONTextEdit.Enter += new System.EventHandler(this.enterControl);
            this.dESCRIPTIONTextEdit.Leave += new System.EventHandler(this.dESCRIPTIONTextEdit_Leave);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.AutoScroll = true;
            this.splitContainerControl1.Panel1.Controls.Add(this.GridControlChgCode);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.AutoScroll = true;
            this.splitContainerControl1.Panel2.Controls.Add(label1);
            this.splitContainerControl1.Panel2.Controls.Add(this.confirmCheckEdit);
            this.splitContainerControl1.Panel2.Controls.Add(this.cODETextEdit);
            this.splitContainerControl1.Panel2.Controls.Add(this.dESCRIPTIONTextEdit);
            this.splitContainerControl1.Panel2.Controls.Add(dESCRIPTIONLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel2.Controls.Add(cODELabel);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1020, 717);
            this.splitContainerControl1.SplitterPosition = 320;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Controls.Add(this.splitContainerControl1);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 25);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(1020, 717);
            this.xtraScrollableControl1.TabIndex = 20;
            // 
            // panelControlStatus
            // 
            this.panelControlStatus.Appearance.Options.UseTextOptions = true;
            this.panelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("panelControlStatus.ContentImage")));
            this.panelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.panelControlStatus.Controls.Add(this.LabelStatus);
            this.panelControlStatus.Location = new System.Drawing.Point(326, 2);
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
            // ChgCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 742);
            this.Controls.Add(this.panelControlStatus);
            this.Controls.Add(this.xtraScrollableControl1);
            this.Controls.Add(this.ChgCodeBindingNavigator);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "ChgCodeForm";
            this.ShowInTaskbar = false;
            this.Text = "Change Code Maintenance";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChgCodeForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChgCodeForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.confirmCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChgCodeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cODETextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlChgCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewChgCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChgCodeBindingNavigator)).EndInit();
            this.ChgCodeBindingNavigator.ResumeLayout(false);
            this.ChgCodeBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dESCRIPTIONTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.xtraScrollableControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).EndInit();
            this.panelControlStatus.ResumeLayout(false);
            this.panelControlStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit cODETextEdit;
        private System.Windows.Forms.BindingSource ChgCodeBindingSource;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl GridControlChgCode;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewChgCode;
        private System.Windows.Forms.BindingNavigator ChgCodeBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton cHGCODEBindingNavigatorSaveItem;
        private DevExpress.XtraEditors.TextEdit dESCRIPTIONTextEdit;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.CheckEdit confirmCheckEdit;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private DevExpress.XtraEditors.PanelControl panelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colConfirm;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplayName;
        private DevExpress.XtraGrid.Columns.GridColumn colCODE;
        private DevExpress.XtraGrid.Columns.GridColumn colDESCRIPTION;
        private DevExpress.XtraGrid.Columns.GridColumn colCONF;
        private DevExpress.XtraGrid.Columns.GridColumn colDATAFLEX_FILL_01;
        private DevExpress.XtraGrid.Columns.GridColumn colDATAFLEX_FILL_02;

    }
}