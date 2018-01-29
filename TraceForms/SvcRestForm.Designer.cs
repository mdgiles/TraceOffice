namespace TraceForms
{
    partial class SvcRestForm
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
            System.Windows.Forms.Label cODELabel;
            System.Windows.Forms.Label aGENCYLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SvcRestForm));
            this.SvcRestrBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.SvcRestrBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.sVCRESTR2BindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.ComboBoxEditType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.ImageComboBoxEditCode = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.ImageComboBoxEditAgency = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.GridViewSvcRestr = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAGENCY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAGY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCARINFO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCOMP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCRU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOTEL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPACK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControlStatus = new DevExpress.XtraEditors.PanelControl();
            this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            tYPELabel = new System.Windows.Forms.Label();
            cODELabel = new System.Windows.Forms.Label();
            aGENCYLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SvcRestrBindingNavigator)).BeginInit();
            this.SvcRestrBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SvcRestrBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxEditType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditAgency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSvcRestr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).BeginInit();
            this.panelControlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tYPELabel
            // 
            tYPELabel.AutoSize = true;
            tYPELabel.Location = new System.Drawing.Point(88, 55);
            tYPELabel.Name = "tYPELabel";
            tYPELabel.Size = new System.Drawing.Size(35, 13);
            tYPELabel.TabIndex = 8;
            tYPELabel.Text = "TYPE:";
            // 
            // cODELabel
            // 
            cODELabel.AutoSize = true;
            cODELabel.Location = new System.Drawing.Point(84, 95);
            cODELabel.Name = "cODELabel";
            cODELabel.Size = new System.Drawing.Size(39, 13);
            cODELabel.TabIndex = 9;
            cODELabel.Text = "CODE:";
            // 
            // aGENCYLabel
            // 
            aGENCYLabel.AutoSize = true;
            aGENCYLabel.Location = new System.Drawing.Point(72, 141);
            aGENCYLabel.Name = "aGENCYLabel";
            aGENCYLabel.Size = new System.Drawing.Size(51, 13);
            aGENCYLabel.TabIndex = 10;
            aGENCYLabel.Text = "AGENCY:";
            // 
            // SvcRestrBindingNavigator
            // 
            this.SvcRestrBindingNavigator.AddNewItem = null;
            this.SvcRestrBindingNavigator.BindingSource = this.SvcRestrBindingSource;
            this.SvcRestrBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.SvcRestrBindingNavigator.DeleteItem = null;
            this.SvcRestrBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.sVCRESTR2BindingNavigatorSaveItem});
            this.SvcRestrBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.SvcRestrBindingNavigator.MoveFirstItem = null;
            this.SvcRestrBindingNavigator.MoveLastItem = null;
            this.SvcRestrBindingNavigator.MoveNextItem = null;
            this.SvcRestrBindingNavigator.MovePreviousItem = null;
            this.SvcRestrBindingNavigator.Name = "SvcRestrBindingNavigator";
            this.SvcRestrBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.SvcRestrBindingNavigator.Size = new System.Drawing.Size(1020, 25);
            this.SvcRestrBindingNavigator.TabIndex = 8;
            this.SvcRestrBindingNavigator.Text = "bindingNavigator1";
            // 
            // SvcRestrBindingSource
            // 
            this.SvcRestrBindingSource.DataSource = typeof(FlexModel.SVCRESTR);
            this.SvcRestrBindingSource.CurrentChanged += new System.EventHandler(this.SvcRestrBindingSource_CurrentChanged);
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
            // sVCRESTR2BindingNavigatorSaveItem
            // 
            this.sVCRESTR2BindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sVCRESTR2BindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("sVCRESTR2BindingNavigatorSaveItem.Image")));
            this.sVCRESTR2BindingNavigatorSaveItem.Name = "sVCRESTR2BindingNavigatorSaveItem";
            this.sVCRESTR2BindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.sVCRESTR2BindingNavigatorSaveItem.Text = "Save Data";
            this.sVCRESTR2BindingNavigatorSaveItem.Click += new System.EventHandler(this.sVCRESTR2BindingNavigatorSaveItem_Click);
            // 
            // ComboBoxEditType
            // 
            this.ComboBoxEditType.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SvcRestrBindingSource, "TYPE", true));
            this.ComboBoxEditType.Location = new System.Drawing.Point(129, 52);
            this.ComboBoxEditType.Name = "ComboBoxEditType";
            this.ComboBoxEditType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ComboBoxEditType.Properties.Items.AddRange(new object[] {
            "",
            "HTL",
            "OPT",
            "PKG",
            "AIR",
            "CAR",
            "CRU"});
            this.ComboBoxEditType.Size = new System.Drawing.Size(100, 20);
            this.ComboBoxEditType.TabIndex = 9;
            this.ComboBoxEditType.TextChanged += new System.EventHandler(this.tYPEComboBoxEdit_TextChanged);
            this.ComboBoxEditType.Enter += new System.EventHandler(this.enterControl);
            this.ComboBoxEditType.Leave += new System.EventHandler(this.ComboBoxEditType_Leave);
            // 
            // ImageComboBoxEditCode
            // 
            this.ImageComboBoxEditCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SvcRestrBindingSource, "CODE", true));
            this.ImageComboBoxEditCode.Location = new System.Drawing.Point(129, 92);
            this.ImageComboBoxEditCode.Name = "ImageComboBoxEditCode";
            this.ImageComboBoxEditCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ImageComboBoxEditCode.Size = new System.Drawing.Size(281, 20);
            this.ImageComboBoxEditCode.TabIndex = 10;
            this.ImageComboBoxEditCode.Enter += new System.EventHandler(this.enterControl);
            this.ImageComboBoxEditCode.Leave += new System.EventHandler(this.ImageComboBoxEditCode_Leave);
            // 
            // ImageComboBoxEditAgency
            // 
            this.ImageComboBoxEditAgency.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.SvcRestrBindingSource, "AGENCY", true));
            this.ImageComboBoxEditAgency.Location = new System.Drawing.Point(129, 138);
            this.ImageComboBoxEditAgency.Name = "ImageComboBoxEditAgency";
            this.ImageComboBoxEditAgency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ImageComboBoxEditAgency.Size = new System.Drawing.Size(281, 20);
            this.ImageComboBoxEditAgency.TabIndex = 11;
            this.ImageComboBoxEditAgency.Enter += new System.EventHandler(this.enterControl);
            this.ImageComboBoxEditAgency.Leave += new System.EventHandler(this.ImageComboBoxEditAgency_Leave);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 25);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.ImageComboBoxEditAgency);
            this.splitContainerControl1.Panel2.Controls.Add(aGENCYLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.ComboBoxEditType);
            this.splitContainerControl1.Panel2.Controls.Add(tYPELabel);
            this.splitContainerControl1.Panel2.Controls.Add(cODELabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.ImageComboBoxEditCode);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1020, 717);
            this.splitContainerControl1.SplitterPosition = 296;
            this.splitContainerControl1.TabIndex = 12;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.SvcRestrBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.GridViewSvcRestr;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(296, 717);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewSvcRestr});
            // 
            // GridViewSvcRestr
            // 
            this.GridViewSvcRestr.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTYPE,
            this.colCODE,
            this.colAGENCY,
            this.colAGY,
            this.colCARINFO,
            this.colCOMP,
            this.colCRU,
            this.colHOTEL,
            this.colPACK});
            this.GridViewSvcRestr.GridControl = this.gridControl1;
            this.GridViewSvcRestr.Name = "GridViewSvcRestr";
            this.GridViewSvcRestr.OptionsView.ShowAutoFilterRow = true;
            this.GridViewSvcRestr.OptionsView.ShowGroupPanel = false;
            this.GridViewSvcRestr.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.GridViewSvcRestr_CellValueChanging);
            this.GridViewSvcRestr.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.GridViewSvcRestr_InvalidRowException);
            this.GridViewSvcRestr.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.GridViewSvcRestr_BeforeLeaveRow);
            // 
            // colTYPE
            // 
            this.colTYPE.Caption = "Type";
            this.colTYPE.FieldName = "TYPE";
            this.colTYPE.Name = "colTYPE";
            this.colTYPE.Visible = true;
            this.colTYPE.VisibleIndex = 0;
            // 
            // colCODE
            // 
            this.colCODE.Caption = "Code";
            this.colCODE.FieldName = "CODE";
            this.colCODE.Name = "colCODE";
            this.colCODE.Visible = true;
            this.colCODE.VisibleIndex = 1;
            // 
            // colAGENCY
            // 
            this.colAGENCY.Caption = "Agency";
            this.colAGENCY.FieldName = "AGENCY";
            this.colAGENCY.Name = "colAGENCY";
            this.colAGENCY.Visible = true;
            this.colAGENCY.VisibleIndex = 2;
            // 
            // colAGY
            // 
            this.colAGY.FieldName = "AGY";
            this.colAGY.Name = "colAGY";
            // 
            // colCARINFO
            // 
            this.colCARINFO.FieldName = "CARINFO";
            this.colCARINFO.Name = "colCARINFO";
            // 
            // colCOMP
            // 
            this.colCOMP.FieldName = "COMP";
            this.colCOMP.Name = "colCOMP";
            // 
            // colCRU
            // 
            this.colCRU.FieldName = "CRU";
            this.colCRU.Name = "colCRU";
            // 
            // colHOTEL
            // 
            this.colHOTEL.FieldName = "HOTEL";
            this.colHOTEL.Name = "colHOTEL";
            // 
            // colPACK
            // 
            this.colPACK.FieldName = "PACK";
            this.colPACK.Name = "colPACK";
            // 
            // panelControlStatus
            // 
            this.panelControlStatus.Appearance.Options.UseTextOptions = true;
            this.panelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("panelControlStatus.ContentImage")));
            this.panelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.panelControlStatus.Controls.Add(this.LabelStatus);
            this.panelControlStatus.Location = new System.Drawing.Point(304, 1);
            this.panelControlStatus.Name = "panelControlStatus";
            this.panelControlStatus.Size = new System.Drawing.Size(120, 23);
            this.panelControlStatus.TabIndex = 266;
            this.panelControlStatus.Visible = false;
            // 
            // LabelStatus
            // 
            this.LabelStatus.Location = new System.Drawing.Point(30, 5);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(0, 13);
            this.LabelStatus.TabIndex = 5;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // SvcRestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1020, 742);
            this.Controls.Add(this.panelControlStatus);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.SvcRestrBindingNavigator);
            this.KeyPreview = true;
            this.Name = "SvcRestForm";
            this.Text = "SvcRestForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SvcRestForm_FormClosing);
            this.Enter += new System.EventHandler(this.enterControl);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SvcRestForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.SvcRestrBindingNavigator)).EndInit();
            this.SvcRestrBindingNavigator.ResumeLayout(false);
            this.SvcRestrBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SvcRestrBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxEditType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditAgency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewSvcRestr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).EndInit();
            this.panelControlStatus.ResumeLayout(false);
            this.panelControlStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator SvcRestrBindingNavigator;
        private System.Windows.Forms.BindingSource SvcRestrBindingSource;
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
        private System.Windows.Forms.ToolStripButton sVCRESTR2BindingNavigatorSaveItem;
        private DevExpress.XtraEditors.ComboBoxEdit ComboBoxEditType;
        private DevExpress.XtraEditors.ImageComboBoxEdit ImageComboBoxEditCode;
        private DevExpress.XtraEditors.ImageComboBoxEdit ImageComboBoxEditAgency;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewSvcRestr;
        private DevExpress.XtraGrid.Columns.GridColumn colTYPE;
        private DevExpress.XtraGrid.Columns.GridColumn colCODE;
        private DevExpress.XtraGrid.Columns.GridColumn colAGENCY;
        private DevExpress.XtraGrid.Columns.GridColumn colAGY;
        private DevExpress.XtraGrid.Columns.GridColumn colCARINFO;
        private DevExpress.XtraGrid.Columns.GridColumn colCOMP;
        private DevExpress.XtraGrid.Columns.GridColumn colCRU;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTEL;
        private DevExpress.XtraGrid.Columns.GridColumn colPACK;
        private DevExpress.XtraEditors.PanelControl panelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}