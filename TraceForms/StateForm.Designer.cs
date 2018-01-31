namespace TraceForms
{
    partial class StateForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StateForm));
			this.TextEditCode = new DevExpress.XtraEditors.TextEdit();
			this.StateBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.GridControlState = new DevExpress.XtraGrid.GridControl();
			this.GridViewState = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colState1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCountry = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colRegion = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colGroup = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
			this.state1TextBox = new DevExpress.XtraEditors.TextEdit();
			this.groupTextBox = new DevExpress.XtraEditors.TextEdit();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
			this.ImageComboBoxEditCountry = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.ImageComboBoxEditRegion = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.panelControlStatus = new DevExpress.XtraEditors.PanelControl();
			this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
			this.bindingSourceCodeName = new System.Windows.Forms.BindingSource(this.components);
			this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
			this.bar1 = new DevExpress.XtraBars.Bar();
			this.barButtonItemNew = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItemDelete = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItemSave = new DevExpress.XtraBars.BarButtonItem();
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.StateBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridControlState)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridViewState)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.state1TextBox.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupTextBox.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
			this.splitContainerControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditCountry.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditRegion.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).BeginInit();
			this.panelControlStatus.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourceCodeName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
			this.SuspendLayout();
			// 
			// TextEditCode
			// 
			this.TextEditCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.StateBindingSource, "Code", true));
			this.TextEditCode.EnterMoveNextControl = true;
			this.TextEditCode.Location = new System.Drawing.Point(92, 53);
			this.TextEditCode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.TextEditCode.Name = "TextEditCode";
			this.TextEditCode.Properties.MaxLength = 3;
			this.TextEditCode.Size = new System.Drawing.Size(158, 20);
			this.TextEditCode.TabIndex = 1;
			this.TextEditCode.Enter += new System.EventHandler(this.enterControl);
			this.TextEditCode.Leave += new System.EventHandler(this.codeTextEdit_Leave);
			// 
			// StateBindingSource
			// 
			this.StateBindingSource.DataSource = typeof(FlexModel.State);
			this.StateBindingSource.CurrentChanged += new System.EventHandler(this.StateBindingSource_CurrentChanged);
			// 
			// labelControl5
			// 
			this.labelControl5.Location = new System.Drawing.Point(47, 193);
			this.labelControl5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.labelControl5.Name = "labelControl5";
			this.labelControl5.Size = new System.Drawing.Size(29, 13);
			this.labelControl5.TabIndex = 39;
			this.labelControl5.Text = "Group";
			// 
			// labelControl4
			// 
			this.labelControl4.Location = new System.Drawing.Point(47, 155);
			this.labelControl4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.labelControl4.Name = "labelControl4";
			this.labelControl4.Size = new System.Drawing.Size(33, 13);
			this.labelControl4.TabIndex = 38;
			this.labelControl4.Text = "Region";
			// 
			// labelControl3
			// 
			this.labelControl3.Location = new System.Drawing.Point(47, 122);
			this.labelControl3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.labelControl3.Name = "labelControl3";
			this.labelControl3.Size = new System.Drawing.Size(39, 13);
			this.labelControl3.TabIndex = 37;
			this.labelControl3.Text = "Country";
			// 
			// labelControl2
			// 
			this.labelControl2.Location = new System.Drawing.Point(47, 88);
			this.labelControl2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(27, 13);
			this.labelControl2.TabIndex = 36;
			this.labelControl2.Text = "Name";
			// 
			// labelControl1
			// 
			this.labelControl1.Location = new System.Drawing.Point(47, 56);
			this.labelControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(25, 13);
			this.labelControl1.TabIndex = 35;
			this.labelControl1.Text = "Code";
			// 
			// GridControlState
			// 
			this.GridControlState.DataSource = this.StateBindingSource;
			this.GridControlState.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GridControlState.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.GridControlState.Location = new System.Drawing.Point(0, 0);
			this.GridControlState.MainView = this.GridViewState;
			this.GridControlState.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.GridControlState.Name = "GridControlState";
			this.GridControlState.Size = new System.Drawing.Size(170, 462);
			this.GridControlState.TabIndex = 34;
			this.GridControlState.TabStop = false;
			this.GridControlState.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewState});
			// 
			// GridViewState
			// 
			this.GridViewState.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colState1,
            this.colCountry,
            this.colRegion,
            this.colGroup,
            this.colAddress});
			this.GridViewState.GridControl = this.GridControlState;
			this.GridViewState.Name = "GridViewState";
			this.GridViewState.OptionsCustomization.AllowRowSizing = true;
			this.GridViewState.OptionsView.AllowHtmlDrawHeaders = true;
			this.GridViewState.OptionsView.ShowAutoFilterRow = true;
			this.GridViewState.OptionsView.ShowGroupPanel = false;
			this.GridViewState.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
			this.GridViewState.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
			this.GridViewState.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView1_BeforeLeaveRow);
			// 
			// colCode
			// 
			this.colCode.FieldName = "Code";
			this.colCode.Name = "colCode";
			this.colCode.Visible = true;
			this.colCode.VisibleIndex = 0;
			// 
			// colState1
			// 
			this.colState1.Caption = "State";
			this.colState1.FieldName = "State1";
			this.colState1.Name = "colState1";
			this.colState1.Visible = true;
			this.colState1.VisibleIndex = 1;
			// 
			// colCountry
			// 
			this.colCountry.FieldName = "Country";
			this.colCountry.Name = "colCountry";
			// 
			// colRegion
			// 
			this.colRegion.FieldName = "Region";
			this.colRegion.Name = "colRegion";
			// 
			// colGroup
			// 
			this.colGroup.FieldName = "Group";
			this.colGroup.Name = "colGroup";
			// 
			// colAddress
			// 
			this.colAddress.FieldName = "Address";
			this.colAddress.Name = "colAddress";
			// 
			// state1TextBox
			// 
			this.state1TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.StateBindingSource, "State1", true));
			this.state1TextBox.EnterMoveNextControl = true;
			this.state1TextBox.Location = new System.Drawing.Point(92, 85);
			this.state1TextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.state1TextBox.Name = "state1TextBox";
			this.state1TextBox.Properties.MaxLength = 40;
			this.state1TextBox.Size = new System.Drawing.Size(158, 20);
			this.state1TextBox.TabIndex = 2;
			this.state1TextBox.Enter += new System.EventHandler(this.enterControl);
			this.state1TextBox.Leave += new System.EventHandler(this.state1TextBox_Leave);
			// 
			// groupTextBox
			// 
			this.groupTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.StateBindingSource, "Group", true));
			this.groupTextBox.EnterMoveNextControl = true;
			this.groupTextBox.Location = new System.Drawing.Point(92, 190);
			this.groupTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.groupTextBox.Name = "groupTextBox";
			this.groupTextBox.Properties.MaxLength = 3;
			this.groupTextBox.Size = new System.Drawing.Size(158, 20);
			this.groupTextBox.TabIndex = 5;
			this.groupTextBox.Enter += new System.EventHandler(this.enterControl);
			this.groupTextBox.Leave += new System.EventHandler(this.groupTextBox_Leave);
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// splitContainerControl1
			// 
			this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl1.Location = new System.Drawing.Point(0, 31);
			this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.splitContainerControl1.Name = "splitContainerControl1";
			this.splitContainerControl1.Panel1.AutoScroll = true;
			this.splitContainerControl1.Panel1.Controls.Add(this.GridControlState);
			this.splitContainerControl1.Panel1.Text = "Panel1";
			this.splitContainerControl1.Panel2.AutoScroll = true;
			this.splitContainerControl1.Panel2.Controls.Add(this.ImageComboBoxEditCountry);
			this.splitContainerControl1.Panel2.Controls.Add(this.ImageComboBoxEditRegion);
			this.splitContainerControl1.Panel2.Controls.Add(this.TextEditCode);
			this.splitContainerControl1.Panel2.Controls.Add(this.groupTextBox);
			this.splitContainerControl1.Panel2.Controls.Add(this.state1TextBox);
			this.splitContainerControl1.Panel2.Controls.Add(this.labelControl1);
			this.splitContainerControl1.Panel2.Controls.Add(this.labelControl5);
			this.splitContainerControl1.Panel2.Controls.Add(this.labelControl2);
			this.splitContainerControl1.Panel2.Controls.Add(this.labelControl4);
			this.splitContainerControl1.Panel2.Controls.Add(this.labelControl3);
			this.splitContainerControl1.Panel2.Text = "Panel2";
			this.splitContainerControl1.Size = new System.Drawing.Size(958, 462);
			this.splitContainerControl1.SplitterPosition = 170;
			this.splitContainerControl1.TabIndex = 44;
			this.splitContainerControl1.Text = "splitContainerControl1";
			// 
			// ImageComboBoxEditCountry
			// 
			this.ImageComboBoxEditCountry.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.StateBindingSource, "Country", true));
			this.ImageComboBoxEditCountry.EnterMoveNextControl = true;
			this.ImageComboBoxEditCountry.Location = new System.Drawing.Point(92, 119);
			this.ImageComboBoxEditCountry.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.ImageComboBoxEditCountry.Name = "ImageComboBoxEditCountry";
			this.ImageComboBoxEditCountry.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.ImageComboBoxEditCountry.Size = new System.Drawing.Size(304, 20);
			this.ImageComboBoxEditCountry.TabIndex = 3;
			this.ImageComboBoxEditCountry.Enter += new System.EventHandler(this.enterControl);
			this.ImageComboBoxEditCountry.Leave += new System.EventHandler(this.ImageComboBoxEditCountry_Leave);
			// 
			// ImageComboBoxEditRegion
			// 
			this.ImageComboBoxEditRegion.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.StateBindingSource, "Region", true));
			this.ImageComboBoxEditRegion.EnterMoveNextControl = true;
			this.ImageComboBoxEditRegion.Location = new System.Drawing.Point(92, 152);
			this.ImageComboBoxEditRegion.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.ImageComboBoxEditRegion.Name = "ImageComboBoxEditRegion";
			this.ImageComboBoxEditRegion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.ImageComboBoxEditRegion.Size = new System.Drawing.Size(304, 20);
			this.ImageComboBoxEditRegion.TabIndex = 4;
			this.ImageComboBoxEditRegion.Enter += new System.EventHandler(this.enterControl);
			this.ImageComboBoxEditRegion.Leave += new System.EventHandler(this.ImageComboBoxEditRegion_Leave);
			// 
			// panelControlStatus
			// 
			this.panelControlStatus.Appearance.Options.UseTextOptions = true;
			this.panelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("panelControlStatus.ContentImage")));
			this.panelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			this.panelControlStatus.Controls.Add(this.LabelStatus);
			this.panelControlStatus.Location = new System.Drawing.Point(308, 0);
			this.panelControlStatus.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panelControlStatus.Name = "panelControlStatus";
			this.panelControlStatus.Size = new System.Drawing.Size(120, 23);
			this.panelControlStatus.TabIndex = 265;
			this.panelControlStatus.Visible = false;
			// 
			// LabelStatus
			// 
			this.LabelStatus.Location = new System.Drawing.Point(30, 5);
			this.LabelStatus.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.LabelStatus.Name = "LabelStatus";
			this.LabelStatus.Size = new System.Drawing.Size(0, 13);
			this.LabelStatus.TabIndex = 5;
			// 
			// bindingSourceCodeName
			// 
			this.bindingSourceCodeName.DataSource = typeof(TraceForms.CodeName);
			// 
			// barManager1
			// 
			this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
			this.barManager1.DockControls.Add(this.barDockControlTop);
			this.barManager1.DockControls.Add(this.barDockControlBottom);
			this.barManager1.DockControls.Add(this.barDockControlLeft);
			this.barManager1.DockControls.Add(this.barDockControlRight);
			this.barManager1.Form = this;
			this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemNew,
            this.barButtonItemDelete,
            this.barButtonItemSave});
			this.barManager1.MaxItemId = 3;
			// 
			// bar1
			// 
			this.bar1.BarName = "Tools";
			this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
			this.bar1.DockCol = 0;
			this.bar1.DockRow = 0;
			this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
			this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemNew),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemSave)});
			this.bar1.OptionsBar.AllowQuickCustomization = false;
			this.bar1.OptionsBar.DrawDragBorder = false;
			this.bar1.OptionsBar.UseWholeRow = true;
			this.bar1.Text = "Tools";
			// 
			// barButtonItemNew
			// 
			this.barButtonItemNew.Caption = "New";
			this.barButtonItemNew.Id = 0;
			this.barButtonItemNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemNew.ImageOptions.Image")));
			this.barButtonItemNew.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemNew.ImageOptions.LargeImage")));
			this.barButtonItemNew.Name = "barButtonItemNew";
			this.barButtonItemNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemNew_ItemClick);
			// 
			// barButtonItemDelete
			// 
			this.barButtonItemDelete.Caption = "Delete";
			this.barButtonItemDelete.Id = 1;
			this.barButtonItemDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemDelete.ImageOptions.Image")));
			this.barButtonItemDelete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemDelete.ImageOptions.LargeImage")));
			this.barButtonItemDelete.Name = "barButtonItemDelete";
			this.barButtonItemDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemDelete_ItemClick);
			// 
			// barButtonItemSave
			// 
			this.barButtonItemSave.Caption = "Save";
			this.barButtonItemSave.Id = 2;
			this.barButtonItemSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemSave.ImageOptions.Image")));
			this.barButtonItemSave.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemSave.ImageOptions.LargeImage")));
			this.barButtonItemSave.Name = "barButtonItemSave";
			this.barButtonItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSave_ItemClick);
			// 
			// barDockControlTop
			// 
			this.barDockControlTop.CausesValidation = false;
			this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
			this.barDockControlTop.Manager = this.barManager1;
			this.barDockControlTop.Size = new System.Drawing.Size(958, 31);
			// 
			// barDockControlBottom
			// 
			this.barDockControlBottom.CausesValidation = false;
			this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.barDockControlBottom.Location = new System.Drawing.Point(0, 493);
			this.barDockControlBottom.Manager = this.barManager1;
			this.barDockControlBottom.Size = new System.Drawing.Size(958, 0);
			// 
			// barDockControlLeft
			// 
			this.barDockControlLeft.CausesValidation = false;
			this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
			this.barDockControlLeft.Manager = this.barManager1;
			this.barDockControlLeft.Size = new System.Drawing.Size(0, 462);
			// 
			// barDockControlRight
			// 
			this.barDockControlRight.CausesValidation = false;
			this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.barDockControlRight.Location = new System.Drawing.Point(958, 31);
			this.barDockControlRight.Manager = this.barManager1;
			this.barDockControlRight.Size = new System.Drawing.Size(0, 462);
			// 
			// StateForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(958, 493);
			this.Controls.Add(this.panelControlStatus);
			this.Controls.Add(this.splitContainerControl1);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.MinimizeBox = false;
			this.Name = "StateForm";
			this.ShowInTaskbar = false;
			this.Text = "States";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.stateForm_FormClosing);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StateForm_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.StateBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridControlState)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridViewState)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.state1TextBox.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupTextBox.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
			this.splitContainerControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditCountry.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditRegion.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).EndInit();
			this.panelControlStatus.ResumeLayout(false);
			this.panelControlStatus.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourceCodeName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl GridControlState;
        private System.Windows.Forms.BindingSource StateBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewState;
        private DevExpress.XtraEditors.TextEdit state1TextBox;
        private DevExpress.XtraEditors.TextEdit groupTextBox;
        private DevExpress.XtraEditors.TextEdit TextEditCode;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
        private DevExpress.XtraEditors.ImageComboBoxEdit ImageComboBoxEditCountry;
        private DevExpress.XtraEditors.ImageComboBoxEdit ImageComboBoxEditRegion;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colState1;
        private DevExpress.XtraGrid.Columns.GridColumn colCountry;
        private DevExpress.XtraGrid.Columns.GridColumn colRegion;
        private DevExpress.XtraGrid.Columns.GridColumn colGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private System.Windows.Forms.BindingSource bindingSourceCodeName;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarManager barManager1;
		private DevExpress.XtraBars.Bar bar1;
		private DevExpress.XtraBars.BarButtonItem barButtonItemNew;
		private DevExpress.XtraBars.BarButtonItem barButtonItemDelete;
		private DevExpress.XtraBars.BarButtonItem barButtonItemSave;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
	}
}