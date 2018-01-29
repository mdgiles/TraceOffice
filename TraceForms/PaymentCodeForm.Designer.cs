namespace TraceForms
{
    partial class PaymentCodeForm
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
            System.Windows.Forms.Label pMT_DESCLabel;
            System.Windows.Forms.Label pMT_CODELabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentCodeForm));
            this.GridControlPayCode = new DevExpress.XtraGrid.GridControl();
            this.PmtCodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GridViewPayCode = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPMT_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPMT_DESC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TextEditCode = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.pMT_DESCTextBox = new DevExpress.XtraEditors.TextEdit();
            this.PmtCodeBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.pMTCODEBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControlStatus = new DevExpress.XtraEditors.PanelControl();
            this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
            pMT_DESCLabel = new System.Windows.Forms.Label();
            pMT_CODELabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlPayCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PmtCodeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewPayCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMT_DESCTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PmtCodeBindingNavigator)).BeginInit();
            this.PmtCodeBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).BeginInit();
            this.panelControlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // pMT_DESCLabel
            // 
            pMT_DESCLabel.AutoSize = true;
            pMT_DESCLabel.Location = new System.Drawing.Point(53, 112);
            pMT_DESCLabel.Name = "pMT_DESCLabel";
            pMT_DESCLabel.Size = new System.Drawing.Size(60, 13);
            pMT_DESCLabel.TabIndex = 17;
            pMT_DESCLabel.Text = "Description";
            // 
            // pMT_CODELabel
            // 
            pMT_CODELabel.AutoSize = true;
            pMT_CODELabel.Location = new System.Drawing.Point(53, 69);
            pMT_CODELabel.Name = "pMT_CODELabel";
            pMT_CODELabel.Size = new System.Drawing.Size(32, 13);
            pMT_CODELabel.TabIndex = 16;
            pMT_CODELabel.Text = "Code";
            // 
            // GridControlPayCode
            // 
            this.GridControlPayCode.DataSource = this.PmtCodeBindingSource;
            this.GridControlPayCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControlPayCode.Location = new System.Drawing.Point(0, 0);
            this.GridControlPayCode.MainView = this.GridViewPayCode;
            this.GridControlPayCode.Name = "GridControlPayCode";
            this.GridControlPayCode.Size = new System.Drawing.Size(294, 717);
            this.GridControlPayCode.TabIndex = 15;
            this.GridControlPayCode.TabStop = false;
            this.GridControlPayCode.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewPayCode});
            // 
            // PmtCodeBindingSource
            // 
            this.PmtCodeBindingSource.DataSource = typeof(FlexModel.PMTCODE);
            this.PmtCodeBindingSource.CurrentChanged += new System.EventHandler(this.PmtCodeBindingSource_CurrentChanged);
            // 
            // GridViewPayCode
            // 
            this.GridViewPayCode.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPMT_CODE,
            this.colPMT_DESC,
            this.colDisplayName});
            this.GridViewPayCode.GridControl = this.GridControlPayCode;
            this.GridViewPayCode.Name = "GridViewPayCode";
            this.GridViewPayCode.OptionsView.ShowAutoFilterRow = true;
            this.GridViewPayCode.OptionsView.ShowGroupPanel = false;
            this.GridViewPayCode.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            this.GridViewPayCode.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            this.GridViewPayCode.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView1_BeforeLeaveRow);
            // 
            // colPMT_CODE
            // 
            this.colPMT_CODE.Caption = "Code";
            this.colPMT_CODE.FieldName = "PMT_CODE";
            this.colPMT_CODE.Name = "colPMT_CODE";
            this.colPMT_CODE.Visible = true;
            this.colPMT_CODE.VisibleIndex = 0;
            // 
            // colPMT_DESC
            // 
            this.colPMT_DESC.Caption = "Description";
            this.colPMT_DESC.FieldName = "PMT_DESC";
            this.colPMT_DESC.Name = "colPMT_DESC";
            this.colPMT_DESC.Visible = true;
            this.colPMT_DESC.VisibleIndex = 1;
            // 
            // colDisplayName
            // 
            this.colDisplayName.FieldName = "DisplayName";
            this.colDisplayName.Name = "colDisplayName";
            this.colDisplayName.OptionsColumn.ReadOnly = true;
            // 
            // TextEditCode
            // 
            this.TextEditCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.PmtCodeBindingSource, "PMT_CODE", true));
            this.TextEditCode.Location = new System.Drawing.Point(118, 66);
            this.TextEditCode.Name = "TextEditCode";
            this.TextEditCode.Properties.MaxLength = 2;
            this.TextEditCode.Size = new System.Drawing.Size(100, 20);
            this.TextEditCode.TabIndex = 1;
            this.TextEditCode.Enter += new System.EventHandler(this.enterControl);
            this.TextEditCode.Leave += new System.EventHandler(this.code_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Payments";
            // 
            // pMT_DESCTextBox
            // 
            this.pMT_DESCTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.PmtCodeBindingSource, "PMT_DESC", true));
            this.pMT_DESCTextBox.Location = new System.Drawing.Point(118, 109);
            this.pMT_DESCTextBox.Name = "pMT_DESCTextBox";
            this.pMT_DESCTextBox.Properties.MaxLength = 10;
            this.pMT_DESCTextBox.Size = new System.Drawing.Size(182, 20);
            this.pMT_DESCTextBox.TabIndex = 2;
            this.pMT_DESCTextBox.Enter += new System.EventHandler(this.enterControl);
            this.pMT_DESCTextBox.Leave += new System.EventHandler(this.pMT_DESCTextBox_Leave);
            // 
            // PmtCodeBindingNavigator
            // 
            this.PmtCodeBindingNavigator.AddNewItem = null;
            this.PmtCodeBindingNavigator.BindingSource = this.PmtCodeBindingSource;
            this.PmtCodeBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.PmtCodeBindingNavigator.DeleteItem = null;
            this.PmtCodeBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.pMTCODEBindingNavigatorSaveItem});
            this.PmtCodeBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.PmtCodeBindingNavigator.MoveFirstItem = null;
            this.PmtCodeBindingNavigator.MoveLastItem = null;
            this.PmtCodeBindingNavigator.MoveNextItem = null;
            this.PmtCodeBindingNavigator.MovePreviousItem = null;
            this.PmtCodeBindingNavigator.Name = "PmtCodeBindingNavigator";
            this.PmtCodeBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.PmtCodeBindingNavigator.Size = new System.Drawing.Size(1020, 25);
            this.PmtCodeBindingNavigator.TabIndex = 14;
            this.PmtCodeBindingNavigator.Text = "bindingNavigator1";
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
            // pMTCODEBindingNavigatorSaveItem
            // 
            this.pMTCODEBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pMTCODEBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("pMTCODEBindingNavigatorSaveItem.Image")));
            this.pMTCODEBindingNavigatorSaveItem.Name = "pMTCODEBindingNavigatorSaveItem";
            this.pMTCODEBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.pMTCODEBindingNavigatorSaveItem.Text = "Save Data";
            this.pMTCODEBindingNavigatorSaveItem.Click += new System.EventHandler(this.pMTCODEBindingNavigatorSaveItem_Click);
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
            this.splitContainerControl1.Panel1.Controls.Add(this.GridControlPayCode);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.AutoScroll = true;
            this.splitContainerControl1.Panel2.Controls.Add(pMT_DESCLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.TextEditCode);
            this.splitContainerControl1.Panel2.Controls.Add(pMT_CODELabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.label1);
            this.splitContainerControl1.Panel2.Controls.Add(this.pMT_DESCTextBox);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1020, 717);
            this.splitContainerControl1.SplitterPosition = 294;
            this.splitContainerControl1.TabIndex = 22;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panelControlStatus
            // 
            this.panelControlStatus.Appearance.Options.UseTextOptions = true;
            this.panelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("panelControlStatus.ContentImage")));
            this.panelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.panelControlStatus.Controls.Add(this.LabelStatus);
            this.panelControlStatus.Location = new System.Drawing.Point(324, 2);
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
            // PaymentCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 742);
            this.Controls.Add(this.panelControlStatus);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.PmtCodeBindingNavigator);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "PaymentCodeForm";
            this.ShowInTaskbar = false;
            this.Text = "Payment Codes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PaymentCodeForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PaymentCodeForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.GridControlPayCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PmtCodeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewPayCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pMT_DESCTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PmtCodeBindingNavigator)).EndInit();
            this.PmtCodeBindingNavigator.ResumeLayout(false);
            this.PmtCodeBindingNavigator.PerformLayout();
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

        private DevExpress.XtraGrid.GridControl GridControlPayCode;
        private System.Windows.Forms.BindingSource PmtCodeBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewPayCode;
        private DevExpress.XtraEditors.TextEdit TextEditCode;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit pMT_DESCTextBox;
        private System.Windows.Forms.BindingNavigator PmtCodeBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton pMTCODEBindingNavigatorSaveItem;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colPMT_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn colPMT_DESC;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplayName;

    }
}