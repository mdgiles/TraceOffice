namespace TraceForms
{
    partial class CountryForm
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
            System.Windows.Forms.Label nAMELabel;
            System.Windows.Forms.Label cODELabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CountryForm));
            System.Windows.Forms.Label label2;
            this.GridControlCountry = new DevExpress.XtraGrid.GridControl();
            this.CountryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GridViewCountry = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAGY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCOMP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOTEL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cODETextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.nAMETextEdit = new DevExpress.XtraEditors.TextEdit();
            this.CountryBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.cOUNTRYBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControlStatus = new DevExpress.XtraEditors.PanelControl();
            this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
            this.imageComboBoxEditContinent = new DevExpress.XtraEditors.ImageComboBoxEdit();
            nAMELabel = new System.Windows.Forms.Label();
            cODELabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cODETextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nAMETextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountryBindingNavigator)).BeginInit();
            this.CountryBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).BeginInit();
            this.panelControlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEditContinent.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // nAMELabel
            // 
            nAMELabel.AutoSize = true;
            nAMELabel.Location = new System.Drawing.Point(89, 160);
            nAMELabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            nAMELabel.Name = "nAMELabel";
            nAMELabel.Size = new System.Drawing.Size(65, 19);
            nAMELabel.TabIndex = 14;
            nAMELabel.Text = "Country";
            // 
            // cODELabel
            // 
            cODELabel.AutoSize = true;
            cODELabel.Location = new System.Drawing.Point(89, 105);
            cODELabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            cODELabel.Name = "cODELabel";
            cODELabel.Size = new System.Drawing.Size(45, 19);
            cODELabel.TabIndex = 13;
            cODELabel.Text = "Code";
            // 
            // GridControlCountry
            // 
            this.GridControlCountry.DataSource = this.CountryBindingSource;
            this.GridControlCountry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControlCountry.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GridControlCountry.Location = new System.Drawing.Point(0, 0);
            this.GridControlCountry.MainView = this.GridViewCountry;
            this.GridControlCountry.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GridControlCountry.Name = "GridControlCountry";
            this.GridControlCountry.Size = new System.Drawing.Size(423, 1053);
            this.GridControlCountry.TabIndex = 99;
            this.GridControlCountry.TabStop = false;
            this.GridControlCountry.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewCountry});
            // 
            // CountryBindingSource
            // 
            this.CountryBindingSource.DataSource = typeof(FlexModel.COUNTRY);
            this.CountryBindingSource.CurrentChanged += new System.EventHandler(this.CountryBindingSource_CurrentChanged);
            // 
            // GridViewCountry
            // 
            this.GridViewCountry.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDisplayName,
            this.colCODE,
            this.gridColumn1,
            this.colAGY,
            this.colCOMP,
            this.colHOTEL,
            this.colAddress});
            this.GridViewCountry.GridControl = this.GridControlCountry;
            this.GridViewCountry.Name = "GridViewCountry";
            this.GridViewCountry.OptionsView.ShowAutoFilterRow = true;
            this.GridViewCountry.OptionsView.ShowGroupPanel = false;
            this.GridViewCountry.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            this.GridViewCountry.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            this.GridViewCountry.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView1_BeforeLeaveRow);
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
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "NAME";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // colAGY
            // 
            this.colAGY.FieldName = "AGY";
            this.colAGY.Name = "colAGY";
            // 
            // colCOMP
            // 
            this.colCOMP.FieldName = "COMP";
            this.colCOMP.Name = "colCOMP";
            // 
            // colHOTEL
            // 
            this.colHOTEL.FieldName = "HOTEL";
            this.colHOTEL.Name = "colHOTEL";
            // 
            // colAddress
            // 
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            // 
            // cODETextEdit
            // 
            this.cODETextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.CountryBindingSource, "CODE", true));
            this.cODETextEdit.EnterMoveNextControl = true;
            this.cODETextEdit.Location = new System.Drawing.Point(192, 102);
            this.cODETextEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cODETextEdit.Name = "cODETextEdit";
            this.cODETextEdit.Properties.MaxLength = 3;
            this.cODETextEdit.Size = new System.Drawing.Size(101, 26);
            this.cODETextEdit.TabIndex = 1;
            this.cODETextEdit.Enter += new System.EventHandler(this.enterControl);
            this.cODETextEdit.Leave += new System.EventHandler(this.cODETextEdit_Leave);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(51, 26);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(67, 19);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "Countries";
            // 
            // nAMETextEdit
            // 
            this.nAMETextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.CountryBindingSource, "NAME", true));
            this.nAMETextEdit.EnterMoveNextControl = true;
            this.nAMETextEdit.Location = new System.Drawing.Point(192, 156);
            this.nAMETextEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nAMETextEdit.Name = "nAMETextEdit";
            this.nAMETextEdit.Properties.MaxLength = 20;
            this.nAMETextEdit.Size = new System.Drawing.Size(208, 26);
            this.nAMETextEdit.TabIndex = 2;
            this.nAMETextEdit.Enter += new System.EventHandler(this.enterControl);
            this.nAMETextEdit.Leave += new System.EventHandler(this.nAMETextEdit_Leave);
            // 
            // CountryBindingNavigator
            // 
            this.CountryBindingNavigator.AddNewItem = null;
            this.CountryBindingNavigator.BindingSource = this.CountryBindingSource;
            this.CountryBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.CountryBindingNavigator.DeleteItem = null;
            this.CountryBindingNavigator.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.CountryBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.cOUNTRYBindingNavigatorSaveItem});
            this.CountryBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.CountryBindingNavigator.MoveFirstItem = null;
            this.CountryBindingNavigator.MoveLastItem = null;
            this.CountryBindingNavigator.MoveNextItem = null;
            this.CountryBindingNavigator.MovePreviousItem = null;
            this.CountryBindingNavigator.Name = "CountryBindingNavigator";
            this.CountryBindingNavigator.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.CountryBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.CountryBindingNavigator.Size = new System.Drawing.Size(1530, 31);
            this.CountryBindingNavigator.TabIndex = 9;
            this.CountryBindingNavigator.Text = "bindingNavigator1";
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
            // cOUNTRYBindingNavigatorSaveItem
            // 
            this.cOUNTRYBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cOUNTRYBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("cOUNTRYBindingNavigatorSaveItem.Image")));
            this.cOUNTRYBindingNavigatorSaveItem.Name = "cOUNTRYBindingNavigatorSaveItem";
            this.cOUNTRYBindingNavigatorSaveItem.Size = new System.Drawing.Size(28, 28);
            this.cOUNTRYBindingNavigatorSaveItem.Text = "Save Data";
            this.cOUNTRYBindingNavigatorSaveItem.Click += new System.EventHandler(this.cOUNTRYBindingNavigatorSaveItem_Click);
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
            this.splitContainerControl1.Panel1.Controls.Add(this.GridControlCountry);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.AutoScroll = true;
            this.splitContainerControl1.Panel2.Controls.Add(this.imageComboBoxEditContinent);
            this.splitContainerControl1.Panel2.Controls.Add(label2);
            this.splitContainerControl1.Panel2.Controls.Add(nAMELabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.cODETextEdit);
            this.splitContainerControl1.Panel2.Controls.Add(cODELabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel2.Controls.Add(this.nAMETextEdit);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1530, 1053);
            this.splitContainerControl1.SplitterPosition = 282;
            this.splitContainerControl1.TabIndex = 13;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panelControlStatus
            // 
            this.panelControlStatus.Appearance.Options.UseTextOptions = true;
            this.panelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("panelControlStatus.ContentImage")));
            this.panelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.panelControlStatus.Controls.Add(this.LabelStatus);
            this.panelControlStatus.Location = new System.Drawing.Point(454, 3);
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
            // imageComboBoxEditContinent
            // 
            this.imageComboBoxEditContinent.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.CountryBindingSource, "Continent_ID", true));
            this.imageComboBoxEditContinent.EnterMoveNextControl = true;
            this.imageComboBoxEditContinent.Location = new System.Drawing.Point(192, 210);
            this.imageComboBoxEditContinent.Margin = new System.Windows.Forms.Padding(4);
            this.imageComboBoxEditContinent.Name = "imageComboBoxEditContinent";
            this.imageComboBoxEditContinent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.imageComboBoxEditContinent.Size = new System.Drawing.Size(303, 26);
            this.imageComboBoxEditContinent.TabIndex = 25;
            this.imageComboBoxEditContinent.Enter += new System.EventHandler(this.enterControl);
            this.imageComboBoxEditContinent.Leave += new System.EventHandler(this.imageComboBoxEditCountry_Leave);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(89, 215);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(77, 19);
            label2.TabIndex = 26;
            label2.Text = "Continent";
            // 
            // CountryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1530, 1084);
            this.Controls.Add(this.panelControlStatus);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.CountryBindingNavigator);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimizeBox = false;
            this.Name = "CountryForm";
            this.ShowInTaskbar = false;
            this.Text = "CountryForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CountryForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CountryForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.GridControlCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cODETextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nAMETextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountryBindingNavigator)).EndInit();
            this.CountryBindingNavigator.ResumeLayout(false);
            this.CountryBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).EndInit();
            this.panelControlStatus.ResumeLayout(false);
            this.panelControlStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEditContinent.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GridControlCountry;
        private System.Windows.Forms.BindingSource CountryBindingSource;
        private DevExpress.XtraEditors.TextEdit cODETextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit nAMETextEdit;
        private System.Windows.Forms.BindingNavigator CountryBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton cOUNTRYBindingNavigatorSaveItem;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplayName;
        private DevExpress.XtraGrid.Columns.GridColumn colCODE;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colAGY;
        private DevExpress.XtraGrid.Columns.GridColumn colCOMP;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTEL;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        public DevExpress.XtraGrid.Views.Grid.GridView GridViewCountry;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private DevExpress.XtraEditors.ImageComboBoxEdit imageComboBoxEditContinent;
    }
}