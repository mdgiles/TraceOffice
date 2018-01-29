namespace TraceForms
{
    partial class HtlRatingForm
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
            System.Windows.Forms.Label cODELabel;
            System.Windows.Forms.Label dESCRIPLabel;
            System.Windows.Forms.Label starsLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HtlRatingForm));
            this.starRating1 = new TraceForms.starRating();
            this.GridControlHtlRating = new DevExpress.XtraGrid.GridControl();
            this.HtlRatingBindingSource = new System.Windows.Forms.BindingSource();
            this.GridViewHtlRating = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDESCRIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImage_Path = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStars = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOTEL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dESCRIPTextBox = new DevExpress.XtraEditors.TextEdit();
            this.cODETextBox = new DevExpress.XtraEditors.TextEdit();
            this.HtlRatingBindingNavigator = new System.Windows.Forms.BindingNavigator();
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
            this.hTLRATNGBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.starsSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.panelControlStatus = new DevExpress.XtraEditors.PanelControl();
            this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
            cODELabel = new System.Windows.Forms.Label();
            dESCRIPLabel = new System.Windows.Forms.Label();
            starsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlHtlRating)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HtlRatingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewHtlRating)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dESCRIPTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cODETextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HtlRatingBindingNavigator)).BeginInit();
            this.HtlRatingBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.starsSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).BeginInit();
            this.panelControlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // cODELabel
            // 
            cODELabel.AutoSize = true;
            cODELabel.Location = new System.Drawing.Point(64, 62);
            cODELabel.Name = "cODELabel";
            cODELabel.Size = new System.Drawing.Size(32, 13);
            cODELabel.TabIndex = 8;
            cODELabel.Text = "Code";
            // 
            // dESCRIPLabel
            // 
            dESCRIPLabel.AutoSize = true;
            dESCRIPLabel.Location = new System.Drawing.Point(64, 116);
            dESCRIPLabel.Name = "dESCRIPLabel";
            dESCRIPLabel.Size = new System.Drawing.Size(60, 13);
            dESCRIPLabel.TabIndex = 10;
            dESCRIPLabel.Text = "Description";
            // 
            // starsLabel
            // 
            starsLabel.AutoSize = true;
            starsLabel.Location = new System.Drawing.Point(82, 168);
            starsLabel.Name = "starsLabel";
            starsLabel.Size = new System.Drawing.Size(36, 13);
            starsLabel.TabIndex = 13;
            starsLabel.Text = "Stars:";
            // 
            // starRating1
            // 
            this.starRating1.Location = new System.Drawing.Point(124, 217);
            this.starRating1.Name = "starRating1";
            this.starRating1.rating = 0D;
            this.starRating1.Size = new System.Drawing.Size(163, 55);
            this.starRating1.stars = 5;
            this.starRating1.TabIndex = 13;
            this.starRating1.Leave += new System.EventHandler(this.starRating1_Leave);
            this.starRating1.MouseLeave += new System.EventHandler(this.starRating1_MouseLeave);
            // 
            // GridControlHtlRating
            // 
            this.GridControlHtlRating.DataSource = this.HtlRatingBindingSource;
            this.GridControlHtlRating.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControlHtlRating.Location = new System.Drawing.Point(0, 0);
            this.GridControlHtlRating.MainView = this.GridViewHtlRating;
            this.GridControlHtlRating.Name = "GridControlHtlRating";
            this.GridControlHtlRating.Size = new System.Drawing.Size(253, 717);
            this.GridControlHtlRating.TabIndex = 12;
            this.GridControlHtlRating.TabStop = false;
            this.GridControlHtlRating.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewHtlRating});
            // 
            // HtlRatingBindingSource
            // 
            this.HtlRatingBindingSource.DataSource = typeof(FlexModel.HTLRATNG);
            this.HtlRatingBindingSource.CurrentChanged += new System.EventHandler(this.HtlRatingBindingSource_CurrentChanged);
            // 
            // GridViewHtlRating
            // 
            this.GridViewHtlRating.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDisplayName,
            this.colCODE,
            this.colDESCRIP,
            this.colImage_Path,
            this.colStars,
            this.colHOTEL});
            this.GridViewHtlRating.GridControl = this.GridControlHtlRating;
            this.GridViewHtlRating.Name = "GridViewHtlRating";
            this.GridViewHtlRating.OptionsView.ShowAutoFilterRow = true;
            this.GridViewHtlRating.OptionsView.ShowGroupPanel = false;
            this.GridViewHtlRating.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            this.GridViewHtlRating.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            this.GridViewHtlRating.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView1_BeforeLeaveRow);
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
            this.colCODE.OptionsColumn.AllowEdit = false;
            this.colCODE.Visible = true;
            this.colCODE.VisibleIndex = 0;
            // 
            // colDESCRIP
            // 
            this.colDESCRIP.FieldName = "DESCRIP";
            this.colDESCRIP.Name = "colDESCRIP";
            this.colDESCRIP.OptionsColumn.AllowEdit = false;
            this.colDESCRIP.Visible = true;
            this.colDESCRIP.VisibleIndex = 1;
            // 
            // colImage_Path
            // 
            this.colImage_Path.FieldName = "Image_Path";
            this.colImage_Path.Name = "colImage_Path";
            // 
            // colStars
            // 
            this.colStars.FieldName = "Stars";
            this.colStars.Name = "colStars";
            // 
            // colHOTEL
            // 
            this.colHOTEL.FieldName = "HOTEL";
            this.colHOTEL.Name = "colHOTEL";
            // 
            // dESCRIPTextBox
            // 
            this.dESCRIPTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.HtlRatingBindingSource, "DESCRIP", true));
            this.dESCRIPTextBox.EnterMoveNextControl = true;
            this.dESCRIPTextBox.Location = new System.Drawing.Point(124, 113);
            this.dESCRIPTextBox.Name = "dESCRIPTextBox";
            this.dESCRIPTextBox.Properties.MaxLength = 12;
            this.dESCRIPTextBox.Size = new System.Drawing.Size(129, 20);
            this.dESCRIPTextBox.TabIndex = 2;
            this.dESCRIPTextBox.Enter += new System.EventHandler(this.cODETextBox_Enter);
            this.dESCRIPTextBox.Leave += new System.EventHandler(this.dESCRIPTextBox_Leave);
            // 
            // cODETextBox
            // 
            this.cODETextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.HtlRatingBindingSource, "CODE", true));
            this.cODETextBox.EnterMoveNextControl = true;
            this.cODETextBox.Location = new System.Drawing.Point(124, 59);
            this.cODETextBox.Name = "cODETextBox";
            this.cODETextBox.Properties.MaxLength = 2;
            this.cODETextBox.Size = new System.Drawing.Size(132, 20);
            this.cODETextBox.TabIndex = 1;
            this.cODETextBox.TextChanged += new System.EventHandler(this.cODETextBox_TextChanged);
            this.cODETextBox.Enter += new System.EventHandler(this.cODETextBox_Enter);
            this.cODETextBox.Leave += new System.EventHandler(this.cODETextBox_Leave);
            // 
            // HtlRatingBindingNavigator
            // 
            this.HtlRatingBindingNavigator.AddNewItem = null;
            this.HtlRatingBindingNavigator.BindingSource = this.HtlRatingBindingSource;
            this.HtlRatingBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.HtlRatingBindingNavigator.DeleteItem = null;
            this.HtlRatingBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.hTLRATNGBindingNavigatorSaveItem});
            this.HtlRatingBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.HtlRatingBindingNavigator.MoveFirstItem = null;
            this.HtlRatingBindingNavigator.MoveLastItem = null;
            this.HtlRatingBindingNavigator.MoveNextItem = null;
            this.HtlRatingBindingNavigator.MovePreviousItem = null;
            this.HtlRatingBindingNavigator.Name = "HtlRatingBindingNavigator";
            this.HtlRatingBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.HtlRatingBindingNavigator.Size = new System.Drawing.Size(1020, 25);
            this.HtlRatingBindingNavigator.TabIndex = 7;
            this.HtlRatingBindingNavigator.Text = "bindingNavigator1";
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
            // hTLRATNGBindingNavigatorSaveItem
            // 
            this.hTLRATNGBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.hTLRATNGBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("hTLRATNGBindingNavigatorSaveItem.Image")));
            this.hTLRATNGBindingNavigatorSaveItem.Name = "hTLRATNGBindingNavigatorSaveItem";
            this.hTLRATNGBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.hTLRATNGBindingNavigatorSaveItem.Text = "Save Data";
            this.hTLRATNGBindingNavigatorSaveItem.Click += new System.EventHandler(this.hTLRATNGBindingNavigatorSaveItem_Click);
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
            this.splitContainerControl1.Panel1.Controls.Add(this.GridControlHtlRating);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.AutoScroll = true;
            this.splitContainerControl1.Panel2.Controls.Add(starsLabel);
            this.splitContainerControl1.Panel2.Controls.Add(this.starsSpinEdit);
            this.splitContainerControl1.Panel2.Controls.Add(this.starRating1);
            this.splitContainerControl1.Panel2.Controls.Add(this.cODETextBox);
            this.splitContainerControl1.Panel2.Controls.Add(this.dESCRIPTextBox);
            this.splitContainerControl1.Panel2.Controls.Add(dESCRIPLabel);
            this.splitContainerControl1.Panel2.Controls.Add(cODELabel);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1020, 717);
            this.splitContainerControl1.SplitterPosition = 253;
            this.splitContainerControl1.TabIndex = 8;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // starsSpinEdit
            // 
            this.starsSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.HtlRatingBindingSource, "Stars", true));
            this.starsSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.starsSpinEdit.Location = new System.Drawing.Point(124, 165);
            this.starsSpinEdit.Name = "starsSpinEdit";
            this.starsSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.starsSpinEdit.Properties.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.starsSpinEdit.Properties.Mask.EditMask = "0.0";
            this.starsSpinEdit.Properties.MaxValue = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.starsSpinEdit.Size = new System.Drawing.Size(61, 20);
            this.starsSpinEdit.TabIndex = 14;
            this.starsSpinEdit.EditValueChanged += new System.EventHandler(this.starsSpinEdit_EditValueChanged);
            this.starsSpinEdit.Enter += new System.EventHandler(this.cODETextBox_Enter);
            this.starsSpinEdit.Leave += new System.EventHandler(this.starsSpinEdit_Leave);
            // 
            // panelControlStatus
            // 
            this.panelControlStatus.Appearance.Options.UseTextOptions = true;
            this.panelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("panelControlStatus.ContentImage")));
            this.panelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.panelControlStatus.Controls.Add(this.LabelStatus);
            this.panelControlStatus.Location = new System.Drawing.Point(310, 2);
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
            // HtlRatingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 742);
            this.Controls.Add(this.panelControlStatus);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.HtlRatingBindingNavigator);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "HtlRatingForm";
            this.ShowInTaskbar = false;
            this.Text = "Hotel Rating";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HtlRatingForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HtlRatingForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.GridControlHtlRating)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HtlRatingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewHtlRating)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dESCRIPTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cODETextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HtlRatingBindingNavigator)).EndInit();
            this.HtlRatingBindingNavigator.ResumeLayout(false);
            this.HtlRatingBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.starsSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).EndInit();
            this.panelControlStatus.ResumeLayout(false);
            this.panelControlStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private starRating starRating1;
        private DevExpress.XtraGrid.GridControl GridControlHtlRating;
        private System.Windows.Forms.BindingSource HtlRatingBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewHtlRating;
        private DevExpress.XtraEditors.TextEdit dESCRIPTextBox;
        private DevExpress.XtraEditors.TextEdit cODETextBox;
        private System.Windows.Forms.BindingNavigator HtlRatingBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton hTLRATNGBindingNavigatorSaveItem;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplayName;
        private DevExpress.XtraGrid.Columns.GridColumn colCODE;
        private DevExpress.XtraGrid.Columns.GridColumn colDESCRIP;
        private DevExpress.XtraGrid.Columns.GridColumn colImage_Path;
        private DevExpress.XtraGrid.Columns.GridColumn colStars;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTEL;
        private DevExpress.XtraEditors.SpinEdit starsSpinEdit;

    }
}