namespace TraceForms
{
    partial class CompanyForm
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
            System.Windows.Forms.Label tYPELabel;
            System.Windows.Forms.Label nAMELabel;
            System.Windows.Forms.Label cODELabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyForm));
            this.tYPETextEdit = new DevExpress.XtraEditors.TextEdit();
            this.CompanyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cODETextEdit = new DevExpress.XtraEditors.TextEdit();
            this.GridControlCompany = new DevExpress.XtraGrid.GridControl();
            this.GridViewCompany = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOTEL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCommunicationValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.nAMETextBox = new DevExpress.XtraEditors.TextEdit();
            this.CompanyBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.cOMPANYBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControlStatus = new DevExpress.XtraEditors.PanelControl();
            this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
            tYPELabel = new System.Windows.Forms.Label();
            nAMELabel = new System.Windows.Forms.Label();
            cODELabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tYPETextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cODETextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nAMETextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyBindingNavigator)).BeginInit();
            this.CompanyBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).BeginInit();
            this.panelControlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // tYPELabel
            // 
            tYPELabel.AutoSize = true;
            tYPELabel.Location = new System.Drawing.Point(70, 134);
            tYPELabel.Name = "tYPELabel";
            tYPELabel.Size = new System.Drawing.Size(31, 13);
            tYPELabel.TabIndex = 24;
            tYPELabel.Text = "Type";
            // 
            // nAMELabel
            // 
            nAMELabel.AutoSize = true;
            nAMELabel.Location = new System.Drawing.Point(70, 171);
            nAMELabel.Name = "nAMELabel";
            nAMELabel.Size = new System.Drawing.Size(34, 13);
            nAMELabel.TabIndex = 22;
            nAMELabel.Text = "Name";
            // 
            // cODELabel
            // 
            cODELabel.AutoSize = true;
            cODELabel.Location = new System.Drawing.Point(70, 106);
            cODELabel.Name = "cODELabel";
            cODELabel.Size = new System.Drawing.Size(32, 13);
            cODELabel.TabIndex = 21;
            cODELabel.Text = "Code";
            // 
            // tYPETextEdit
            // 
            this.tYPETextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.CompanyBindingSource, "TYPE", true));
            this.tYPETextEdit.EnterMoveNextControl = true;
            this.tYPETextEdit.Location = new System.Drawing.Point(115, 136);
            this.tYPETextEdit.Name = "tYPETextEdit";
            this.tYPETextEdit.Properties.MaxLength = 12;
            this.tYPETextEdit.Size = new System.Drawing.Size(173, 20);
            this.tYPETextEdit.TabIndex = 2;
            this.tYPETextEdit.Enter += new System.EventHandler(this.enterControl);
            this.tYPETextEdit.Leave += new System.EventHandler(this.tYPETextEdit_Leave);
            // 
            // CompanyBindingSource
            // 
            this.CompanyBindingSource.DataSource = typeof(FlexModel.COMPANY);
            this.CompanyBindingSource.CurrentChanged += new System.EventHandler(this.CompanyBindingSource_CurrentChanged);
            // 
            // cODETextEdit
            // 
            this.cODETextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.CompanyBindingSource, "CODE", true));
            this.cODETextEdit.EnterMoveNextControl = true;
            this.cODETextEdit.Location = new System.Drawing.Point(115, 103);
            this.cODETextEdit.Name = "cODETextEdit";
            this.cODETextEdit.Properties.MaxLength = 12;
            this.cODETextEdit.Size = new System.Drawing.Size(173, 20);
            this.cODETextEdit.TabIndex = 1;
            this.cODETextEdit.Enter += new System.EventHandler(this.enterControl);
            this.cODETextEdit.Leave += new System.EventHandler(this.cODETextEdit_Leave);
            // 
            // GridControlCompany
            // 
            this.GridControlCompany.DataSource = this.CompanyBindingSource;
            this.GridControlCompany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControlCompany.Location = new System.Drawing.Point(0, 0);
            this.GridControlCompany.MainView = this.GridViewCompany;
            this.GridControlCompany.Name = "GridControlCompany";
            this.GridControlCompany.Size = new System.Drawing.Size(276, 717);
            this.GridControlCompany.TabIndex = 19;
            this.GridControlCompany.TabStop = false;
            this.GridControlCompany.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewCompany});
            // 
            // GridViewCompany
            // 
            this.GridViewCompany.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDisplayName,
            this.colCODE,
            this.colTYPE,
            this.gridColumn1,
            this.colHOTEL,
            this.colCommunicationValue});
            this.GridViewCompany.GridControl = this.GridControlCompany;
            this.GridViewCompany.Name = "GridViewCompany";
            this.GridViewCompany.OptionsView.ShowAutoFilterRow = true;
            this.GridViewCompany.OptionsView.ShowGroupPanel = false;
            this.GridViewCompany.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            this.GridViewCompany.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            this.GridViewCompany.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView1_BeforeLeaveRow);
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
            this.colCODE.Width = 99;
            // 
            // colTYPE
            // 
            this.colTYPE.FieldName = "TYPE";
            this.colTYPE.Name = "colTYPE";
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "NAME";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 159;
            // 
            // colHOTEL
            // 
            this.colHOTEL.FieldName = "HOTEL";
            this.colHOTEL.Name = "colHOTEL";
            // 
            // colCommunicationValue
            // 
            this.colCommunicationValue.FieldName = "CommunicationValue";
            this.colCommunicationValue.Name = "colCommunicationValue";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Companies";
            // 
            // nAMETextBox
            // 
            this.nAMETextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CompanyBindingSource, "NAME", true));
            this.nAMETextBox.EnterMoveNextControl = true;
            this.nAMETextBox.Location = new System.Drawing.Point(115, 168);
            this.nAMETextBox.Name = "nAMETextBox";
            this.nAMETextBox.Properties.MaxLength = 60;
            this.nAMETextBox.Size = new System.Drawing.Size(366, 20);
            this.nAMETextBox.TabIndex = 3;
            this.nAMETextBox.Enter += new System.EventHandler(this.enterControl);
            this.nAMETextBox.Leave += new System.EventHandler(this.nAMETextBox_Leave);
            // 
            // CompanyBindingNavigator
            // 
            this.CompanyBindingNavigator.AddNewItem = null;
            this.CompanyBindingNavigator.BindingSource = this.CompanyBindingSource;
            this.CompanyBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.CompanyBindingNavigator.DeleteItem = null;
            this.CompanyBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.cOMPANYBindingNavigatorSaveItem});
            this.CompanyBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.CompanyBindingNavigator.MoveFirstItem = null;
            this.CompanyBindingNavigator.MoveLastItem = null;
            this.CompanyBindingNavigator.MoveNextItem = null;
            this.CompanyBindingNavigator.MovePreviousItem = null;
            this.CompanyBindingNavigator.Name = "CompanyBindingNavigator";
            this.CompanyBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.CompanyBindingNavigator.Size = new System.Drawing.Size(1020, 25);
            this.CompanyBindingNavigator.TabIndex = 18;
            this.CompanyBindingNavigator.Text = "bindingNavigator1";
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
            // cOMPANYBindingNavigatorSaveItem
            // 
            this.cOMPANYBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cOMPANYBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("cOMPANYBindingNavigatorSaveItem.Image")));
            this.cOMPANYBindingNavigatorSaveItem.Name = "cOMPANYBindingNavigatorSaveItem";
            this.cOMPANYBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.cOMPANYBindingNavigatorSaveItem.Text = "Save Data";
            this.cOMPANYBindingNavigatorSaveItem.Click += new System.EventHandler(this.cOMPANYBindingNavigatorSaveItem_Click);
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
            this.splitContainerControl1.Panel1.Controls.Add(this.GridControlCompany);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.AutoScroll = true;
            this.splitContainerControl1.Panel2.Controls.Add(this.tYPETextEdit);
            this.splitContainerControl1.Panel2.Controls.Add(this.cODETextEdit);
            this.splitContainerControl1.Panel2.Controls.Add(cODELabel);
            this.splitContainerControl1.Panel2.Controls.Add(tYPELabel);
            this.splitContainerControl1.Panel2.Controls.Add(nAMELabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.label1);
            this.splitContainerControl1.Panel2.Controls.Add(this.nAMETextBox);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1020, 717);
            this.splitContainerControl1.SplitterPosition = 276;
            this.splitContainerControl1.TabIndex = 21;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panelControlStatus
            // 
            this.panelControlStatus.Appearance.Options.UseTextOptions = true;
            this.panelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("panelControlStatus.ContentImage")));
            this.panelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.panelControlStatus.Controls.Add(this.LabelStatus);
            this.panelControlStatus.Location = new System.Drawing.Point(300, 2);
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
            // CompanyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 742);
            this.Controls.Add(this.panelControlStatus);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.CompanyBindingNavigator);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "CompanyForm";
            this.ShowInTaskbar = false;
            this.Text = "Companies Maintenance";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CompanyForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CompanyForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.tYPETextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cODETextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nAMETextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyBindingNavigator)).EndInit();
            this.CompanyBindingNavigator.ResumeLayout(false);
            this.CompanyBindingNavigator.PerformLayout();
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

        private DevExpress.XtraGrid.GridControl GridControlCompany;
        private System.Windows.Forms.BindingSource CompanyBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewCompany;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit nAMETextBox;
        private System.Windows.Forms.BindingNavigator CompanyBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton cOMPANYBindingNavigatorSaveItem;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.TextEdit tYPETextEdit;
        private DevExpress.XtraEditors.TextEdit cODETextEdit;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplayName;
        private DevExpress.XtraGrid.Columns.GridColumn colCODE;
        private DevExpress.XtraGrid.Columns.GridColumn colTYPE;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTEL;
        private DevExpress.XtraGrid.Columns.GridColumn colCommunicationValue;
        private DevExpress.XtraEditors.PanelControl panelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;

    }
}