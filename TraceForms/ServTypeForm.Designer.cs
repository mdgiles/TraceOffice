namespace TraceForms
{
    partial class ServTypeForm
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
            System.Windows.Forms.Label tYPELabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServTypeForm));
            this.GridControlServType = new DevExpress.XtraGrid.GridControl();
            this.ServTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GridViewServType = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDESCRIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLINKTYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCOMP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSERVTYPE1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSERVTYPE2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCOMP1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TextEditType = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.dESCRIPTextBox = new DevExpress.XtraEditors.TextEdit();
            this.ServTypeBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.sERVTYPEBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControlStatus = new DevExpress.XtraEditors.PanelControl();
            this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
            dESCRIPLabel = new System.Windows.Forms.Label();
            tYPELabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlServType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewServType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dESCRIPTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServTypeBindingNavigator)).BeginInit();
            this.ServTypeBindingNavigator.SuspendLayout();
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
            dESCRIPLabel.Location = new System.Drawing.Point(37, 117);
            dESCRIPLabel.Name = "dESCRIPLabel";
            dESCRIPLabel.Size = new System.Drawing.Size(60, 13);
            dESCRIPLabel.TabIndex = 16;
            dESCRIPLabel.Text = "Description";
            // 
            // tYPELabel
            // 
            tYPELabel.AutoSize = true;
            tYPELabel.Location = new System.Drawing.Point(66, 91);
            tYPELabel.Name = "tYPELabel";
            tYPELabel.Size = new System.Drawing.Size(31, 13);
            tYPELabel.TabIndex = 15;
            tYPELabel.Text = "Type";
            // 
            // GridControlServType
            // 
            this.GridControlServType.DataSource = this.ServTypeBindingSource;
            this.GridControlServType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControlServType.Location = new System.Drawing.Point(0, 0);
            this.GridControlServType.MainView = this.GridViewServType;
            this.GridControlServType.Name = "GridControlServType";
            this.GridControlServType.Size = new System.Drawing.Size(297, 717);
            this.GridControlServType.TabIndex = 14;
            this.GridControlServType.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewServType});
            // 
            // ServTypeBindingSource
            // 
            this.ServTypeBindingSource.DataSource = typeof(FlexModel.SERVTYPE);
            this.ServTypeBindingSource.CurrentChanged += new System.EventHandler(this.ServTypeBindingSource_CurrentChanged);
            // 
            // GridViewServType
            // 
            this.GridViewServType.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTYPE,
            this.colDESCRIP,
            this.colLINKTYPE,
            this.colCOMP,
            this.colSERVTYPE1,
            this.colSERVTYPE2,
            this.colCOMP1,
            this.colDisplayName});
            this.GridViewServType.GridControl = this.GridControlServType;
            this.GridViewServType.Name = "GridViewServType";
            this.GridViewServType.OptionsView.ShowAutoFilterRow = true;
            this.GridViewServType.OptionsView.ShowGroupPanel = false;
            this.GridViewServType.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            this.GridViewServType.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            this.GridViewServType.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView1_BeforeLeaveRow);
            // 
            // colTYPE
            // 
            this.colTYPE.FieldName = "TYPE";
            this.colTYPE.Name = "colTYPE";
            this.colTYPE.Visible = true;
            this.colTYPE.VisibleIndex = 0;
            // 
            // colDESCRIP
            // 
            this.colDESCRIP.FieldName = "DESCRIP";
            this.colDESCRIP.Name = "colDESCRIP";
            this.colDESCRIP.Visible = true;
            this.colDESCRIP.VisibleIndex = 1;
            // 
            // colLINKTYPE
            // 
            this.colLINKTYPE.FieldName = "LINKTYPE";
            this.colLINKTYPE.Name = "colLINKTYPE";
            // 
            // colCOMP
            // 
            this.colCOMP.FieldName = "COMP";
            this.colCOMP.Name = "colCOMP";
            // 
            // colSERVTYPE1
            // 
            this.colSERVTYPE1.FieldName = "SERVTYPE1";
            this.colSERVTYPE1.Name = "colSERVTYPE1";
            // 
            // colSERVTYPE2
            // 
            this.colSERVTYPE2.FieldName = "SERVTYPE2";
            this.colSERVTYPE2.Name = "colSERVTYPE2";
            // 
            // colCOMP1
            // 
            this.colCOMP1.FieldName = "COMP1";
            this.colCOMP1.Name = "colCOMP1";
            // 
            // colDisplayName
            // 
            this.colDisplayName.FieldName = "DisplayName";
            this.colDisplayName.Name = "colDisplayName";
            this.colDisplayName.OptionsColumn.ReadOnly = true;
            // 
            // TextEditType
            // 
            this.TextEditType.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.ServTypeBindingSource, "TYPE", true));
            this.TextEditType.Location = new System.Drawing.Point(103, 88);
            this.TextEditType.Name = "TextEditType";
            this.TextEditType.Properties.MaxLength = 5;
            this.TextEditType.Size = new System.Drawing.Size(100, 20);
            this.TextEditType.TabIndex = 19;
            this.TextEditType.Enter += new System.EventHandler(this.enterControl);
            this.TextEditType.Leave += new System.EventHandler(this.type_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Service Types";
            // 
            // dESCRIPTextBox
            // 
            this.dESCRIPTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ServTypeBindingSource, "DESCRIP", true));
            this.dESCRIPTextBox.Location = new System.Drawing.Point(103, 114);
            this.dESCRIPTextBox.Name = "dESCRIPTextBox";
            this.dESCRIPTextBox.Properties.MaxLength = 60;
            this.dESCRIPTextBox.Size = new System.Drawing.Size(285, 20);
            this.dESCRIPTextBox.TabIndex = 17;
            this.dESCRIPTextBox.Enter += new System.EventHandler(this.enterControl);
            this.dESCRIPTextBox.Leave += new System.EventHandler(this.dESCRIPTextBox_Leave);
            // 
            // ServTypeBindingNavigator
            // 
            this.ServTypeBindingNavigator.AddNewItem = null;
            this.ServTypeBindingNavigator.BindingSource = this.ServTypeBindingSource;
            this.ServTypeBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.ServTypeBindingNavigator.DeleteItem = null;
            this.ServTypeBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.sERVTYPEBindingNavigatorSaveItem});
            this.ServTypeBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.ServTypeBindingNavigator.MoveFirstItem = null;
            this.ServTypeBindingNavigator.MoveLastItem = null;
            this.ServTypeBindingNavigator.MoveNextItem = null;
            this.ServTypeBindingNavigator.MovePreviousItem = null;
            this.ServTypeBindingNavigator.Name = "ServTypeBindingNavigator";
            this.ServTypeBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.ServTypeBindingNavigator.Size = new System.Drawing.Size(1020, 25);
            this.ServTypeBindingNavigator.TabIndex = 13;
            this.ServTypeBindingNavigator.Text = "bindingNavigator1";
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
            // sERVTYPEBindingNavigatorSaveItem
            // 
            this.sERVTYPEBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sERVTYPEBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("sERVTYPEBindingNavigatorSaveItem.Image")));
            this.sERVTYPEBindingNavigatorSaveItem.Name = "sERVTYPEBindingNavigatorSaveItem";
            this.sERVTYPEBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.sERVTYPEBindingNavigatorSaveItem.Text = "Save Data";
            this.sERVTYPEBindingNavigatorSaveItem.Click += new System.EventHandler(this.sERVTYPEBindingNavigatorSaveItem_Click);
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
            this.splitContainerControl1.Panel1.Controls.Add(this.GridControlServType);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.AutoScroll = true;
            this.splitContainerControl1.Panel2.Controls.Add(dESCRIPLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.label1);
            this.splitContainerControl1.Panel2.Controls.Add(this.TextEditType);
            this.splitContainerControl1.Panel2.Controls.Add(tYPELabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.dESCRIPTextBox);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1020, 717);
            this.splitContainerControl1.SplitterPosition = 297;
            this.splitContainerControl1.TabIndex = 21;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panelControlStatus
            // 
            this.panelControlStatus.Appearance.Options.UseTextOptions = true;
            this.panelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("panelControlStatus.ContentImage")));
            this.panelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.panelControlStatus.Controls.Add(this.LabelStatus);
            this.panelControlStatus.Location = new System.Drawing.Point(313, 2);
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
            // ServTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 742);
            this.Controls.Add(this.panelControlStatus);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.ServTypeBindingNavigator);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "ServTypeForm";
            this.ShowInTaskbar = false;
            this.Text = "Service Type";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServTypeForm_FormClosing);
            this.Enter += new System.EventHandler(this.enterControl);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ServTypeForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.GridControlServType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewServType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dESCRIPTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServTypeBindingNavigator)).EndInit();
            this.ServTypeBindingNavigator.ResumeLayout(false);
            this.ServTypeBindingNavigator.PerformLayout();
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

        private DevExpress.XtraGrid.GridControl GridControlServType;
        private System.Windows.Forms.BindingSource ServTypeBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewServType;
        private DevExpress.XtraEditors.TextEdit TextEditType;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit dESCRIPTextBox;
        private System.Windows.Forms.BindingNavigator ServTypeBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton sERVTYPEBindingNavigatorSaveItem;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colTYPE;
        private DevExpress.XtraGrid.Columns.GridColumn colDESCRIP;
        private DevExpress.XtraGrid.Columns.GridColumn colLINKTYPE;
        private DevExpress.XtraGrid.Columns.GridColumn colCOMP;
        private DevExpress.XtraGrid.Columns.GridColumn colSERVTYPE1;
        private DevExpress.XtraGrid.Columns.GridColumn colSERVTYPE2;
        private DevExpress.XtraGrid.Columns.GridColumn colCOMP1;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplayName;

    }
}