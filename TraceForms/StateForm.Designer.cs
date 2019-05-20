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
			this.BindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.GridControlLookup = new DevExpress.XtraGrid.GridControl();
			this.GridViewLookup = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.GridColumnCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumnState = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumnCountry = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumnRegion = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumnGroup = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumnAddress = new DevExpress.XtraGrid.Columns.GridColumn();
			this.TextEditName = new DevExpress.XtraEditors.TextEdit();
			this.TextEditGroup = new DevExpress.XtraEditors.TextEdit();
			this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
			this.SearchLookupEditCountry = new Custom_SearchLookupEdit.CustomSearchLookUpEdit();
			this.BindingSourceCodeName = new System.Windows.Forms.BindingSource(this.components);
			this.customSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colCode1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colName1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDisplayName1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.SearchLookupEditRegion = new Custom_SearchLookupEdit.CustomSearchLookUpEdit();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.PanelControlStatus = new DevExpress.XtraEditors.PanelControl();
			this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
			this.BarManager = new DevExpress.XtraBars.BarManager(this.components);
			this.bar1 = new DevExpress.XtraBars.Bar();
			this.barButtonItemNew = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItemDelete = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItemSave = new DevExpress.XtraBars.BarButtonItem();
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridControlLookup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridViewLookup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditGroup.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
			this.splitContainerControl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditCountry.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BindingSourceCodeName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.customSearchLookUpEdit1View)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditRegion.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PanelControlStatus)).BeginInit();
			this.PanelControlStatus.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
			this.SuspendLayout();
			// 
			// TextEditCode
			// 
			this.TextEditCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Code", true));
			this.TextEditCode.EnterMoveNextControl = true;
			this.TextEditCode.Location = new System.Drawing.Point(92, 53);
			this.TextEditCode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.TextEditCode.Name = "TextEditCode";
			this.TextEditCode.Properties.MaxLength = 3;
			this.TextEditCode.Size = new System.Drawing.Size(158, 20);
			this.TextEditCode.TabIndex = 1;
			this.TextEditCode.Leave += new System.EventHandler(this.TextEditCode_Leave);
			// 
			// BindingSource
			// 
			this.BindingSource.DataSource = typeof(FlexModel.State);
			this.BindingSource.CurrentChanged += new System.EventHandler(this.StateBindingSource_CurrentChanged);
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
			// GridControlLookup
			// 
			this.GridControlLookup.DataSource = this.BindingSource;
			this.GridControlLookup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GridControlLookup.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.GridControlLookup.Location = new System.Drawing.Point(0, 0);
			this.GridControlLookup.MainView = this.GridViewLookup;
			this.GridControlLookup.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.GridControlLookup.Name = "GridControlLookup";
			this.GridControlLookup.Size = new System.Drawing.Size(170, 462);
			this.GridControlLookup.TabIndex = 34;
			this.GridControlLookup.TabStop = false;
			this.GridControlLookup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewLookup});
			// 
			// GridViewLookup
			// 
			this.GridViewLookup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GridColumnCode,
            this.GridColumnState,
            this.GridColumnCountry,
            this.GridColumnRegion,
            this.GridColumnGroup,
            this.GridColumnAddress});
			this.GridViewLookup.GridControl = this.GridControlLookup;
			this.GridViewLookup.Name = "GridViewLookup";
			this.GridViewLookup.OptionsCustomization.AllowRowSizing = true;
			this.GridViewLookup.OptionsView.ShowAutoFilterRow = true;
			this.GridViewLookup.OptionsView.ShowGroupPanel = false;
			this.GridViewLookup.OptionsView.ShowIndicator = false;
			this.GridViewLookup.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.GridViewLookup_InvalidRowException);
			this.GridViewLookup.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.GridViewLookup_BeforeLeaveRow);
			// 
			// GridColumnCode
			// 
			this.GridColumnCode.FieldName = "Code";
			this.GridColumnCode.Name = "GridColumnCode";
			this.GridColumnCode.Visible = true;
			this.GridColumnCode.VisibleIndex = 0;
			// 
			// GridColumnState
			// 
			this.GridColumnState.Caption = "State";
			this.GridColumnState.FieldName = "State1";
			this.GridColumnState.Name = "GridColumnState";
			this.GridColumnState.Visible = true;
			this.GridColumnState.VisibleIndex = 1;
			// 
			// GridColumnCountry
			// 
			this.GridColumnCountry.FieldName = "Country";
			this.GridColumnCountry.Name = "GridColumnCountry";
			// 
			// GridColumnRegion
			// 
			this.GridColumnRegion.FieldName = "Region";
			this.GridColumnRegion.Name = "GridColumnRegion";
			// 
			// GridColumnGroup
			// 
			this.GridColumnGroup.FieldName = "Group";
			this.GridColumnGroup.Name = "GridColumnGroup";
			// 
			// GridColumnAddress
			// 
			this.GridColumnAddress.FieldName = "Address";
			this.GridColumnAddress.Name = "GridColumnAddress";
			// 
			// TextEditName
			// 
			this.TextEditName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "State1", true));
			this.TextEditName.EnterMoveNextControl = true;
			this.TextEditName.Location = new System.Drawing.Point(92, 85);
			this.TextEditName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.TextEditName.Name = "TextEditName";
			this.TextEditName.Properties.MaxLength = 40;
			this.TextEditName.Size = new System.Drawing.Size(158, 20);
			this.TextEditName.TabIndex = 2;
			this.TextEditName.Leave += new System.EventHandler(this.TextEditName_Leave);
			// 
			// TextEditGroup
			// 
			this.TextEditGroup.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "Group", true));
			this.TextEditGroup.EnterMoveNextControl = true;
			this.TextEditGroup.Location = new System.Drawing.Point(92, 190);
			this.TextEditGroup.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.TextEditGroup.Name = "TextEditGroup";
			this.TextEditGroup.Properties.MaxLength = 3;
			this.TextEditGroup.Size = new System.Drawing.Size(158, 20);
			this.TextEditGroup.TabIndex = 5;
			this.TextEditGroup.Leave += new System.EventHandler(this.TextEditGroup_Leave);
			// 
			// ErrorProvider
			// 
			this.ErrorProvider.ContainerControl = this;
			// 
			// splitContainerControl
			// 
			this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl.Location = new System.Drawing.Point(0, 31);
			this.splitContainerControl.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.splitContainerControl.Name = "splitContainerControl";
			this.splitContainerControl.Panel1.AutoScroll = true;
			this.splitContainerControl.Panel1.Controls.Add(this.GridControlLookup);
			this.splitContainerControl.Panel1.Text = "Panel1";
			this.splitContainerControl.Panel2.AutoScroll = true;
			this.splitContainerControl.Panel2.Controls.Add(this.TextEditCode);
			this.splitContainerControl.Panel2.Controls.Add(this.TextEditGroup);
			this.splitContainerControl.Panel2.Controls.Add(this.TextEditName);
			this.splitContainerControl.Panel2.Controls.Add(this.labelControl1);
			this.splitContainerControl.Panel2.Controls.Add(this.labelControl5);
			this.splitContainerControl.Panel2.Controls.Add(this.labelControl2);
			this.splitContainerControl.Panel2.Controls.Add(this.labelControl4);
			this.splitContainerControl.Panel2.Controls.Add(this.labelControl3);
			this.splitContainerControl.Panel2.Controls.Add(this.SearchLookupEditCountry);
			this.splitContainerControl.Panel2.Controls.Add(this.SearchLookupEditRegion);
			this.splitContainerControl.Panel2.Text = "Panel2";
			this.splitContainerControl.Size = new System.Drawing.Size(958, 462);
			this.splitContainerControl.SplitterPosition = 170;
			this.splitContainerControl.TabIndex = 44;
			this.splitContainerControl.Text = "splitContainerControl1";
			// 
			// SearchLookupEditCountry
			// 
			this.SearchLookupEditCountry.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Country", true));
			this.SearchLookupEditCountry.Location = new System.Drawing.Point(92, 119);
			this.SearchLookupEditCountry.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.SearchLookupEditCountry.Name = "SearchLookupEditCountry";
			this.SearchLookupEditCountry.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
			this.SearchLookupEditCountry.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
			this.SearchLookupEditCountry.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.SearchLookupEditCountry.Properties.DataSource = this.BindingSourceCodeName;
			this.SearchLookupEditCountry.Properties.DisplayMember = "DisplayName";
			this.SearchLookupEditCountry.Properties.NullText = "";
			this.SearchLookupEditCountry.Properties.PopupSizeable = false;
			this.SearchLookupEditCountry.Properties.ValueMember = "Code";
			this.SearchLookupEditCountry.Properties.View = this.customSearchLookUpEdit1View;
			this.SearchLookupEditCountry.Size = new System.Drawing.Size(304, 20);
			this.SearchLookupEditCountry.TabIndex = 3;
			this.SearchLookupEditCountry.UpdateDisplayFilter += new Custom_SearchLookupEdit.UpdateDisplayFilterHandler(this.SearchLookupEdit_UpdateDisplayFilter);
			this.SearchLookupEditCountry.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
			this.SearchLookupEditCountry.Leave += new System.EventHandler(this.SearchLookupEditCountry_Leave);
			// 
			// BindingSourceCodeName
			// 
			this.BindingSourceCodeName.DataSource = typeof(TraceForms.CodeName);
			// 
			// customSearchLookUpEdit1View
			// 
			this.customSearchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode1,
            this.colName1,
            this.colDisplayName1});
			this.customSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.customSearchLookUpEdit1View.Name = "customSearchLookUpEdit1View";
			this.customSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.customSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
			this.customSearchLookUpEdit1View.OptionsView.ShowIndicator = false;
			// 
			// colCode1
			// 
			this.colCode1.FieldName = "Code";
			this.colCode1.Name = "colCode1";
			this.colCode1.Visible = true;
			this.colCode1.VisibleIndex = 0;
			// 
			// colName1
			// 
			this.colName1.FieldName = "Name";
			this.colName1.Name = "colName1";
			this.colName1.Visible = true;
			this.colName1.VisibleIndex = 1;
			// 
			// colDisplayName1
			// 
			this.colDisplayName1.FieldName = "DisplayName";
			this.colDisplayName1.Name = "colDisplayName1";
			this.colDisplayName1.OptionsColumn.ReadOnly = true;
			// 
			// SearchLookupEditRegion
			// 
			this.SearchLookupEditRegion.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Region", true));
			this.SearchLookupEditRegion.Location = new System.Drawing.Point(92, 152);
			this.SearchLookupEditRegion.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.SearchLookupEditRegion.Name = "SearchLookupEditRegion";
			this.SearchLookupEditRegion.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
			this.SearchLookupEditRegion.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
			this.SearchLookupEditRegion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.SearchLookupEditRegion.Properties.DataSource = this.BindingSourceCodeName;
			this.SearchLookupEditRegion.Properties.DisplayMember = "DisplayName";
			this.SearchLookupEditRegion.Properties.NullText = "";
			this.SearchLookupEditRegion.Properties.PopupSizeable = false;
			this.SearchLookupEditRegion.Properties.ValueMember = "Code";
			this.SearchLookupEditRegion.Properties.View = this.gridView1;
			this.SearchLookupEditRegion.Size = new System.Drawing.Size(304, 20);
			this.SearchLookupEditRegion.TabIndex = 4;
			this.SearchLookupEditRegion.UpdateDisplayFilter += new Custom_SearchLookupEdit.UpdateDisplayFilterHandler(this.SearchLookupEdit_UpdateDisplayFilter);
			this.SearchLookupEditRegion.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
			this.SearchLookupEditRegion.Leave += new System.EventHandler(this.SearchLookupEditRegion_Leave);
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colName,
            this.colDisplayName});
			this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			// 
			// colCode
			// 
			this.colCode.FieldName = "Code";
			this.colCode.Name = "colCode";
			this.colCode.Visible = true;
			this.colCode.VisibleIndex = 0;
			// 
			// colName
			// 
			this.colName.FieldName = "Name";
			this.colName.Name = "colName";
			this.colName.Visible = true;
			this.colName.VisibleIndex = 1;
			// 
			// colDisplayName
			// 
			this.colDisplayName.FieldName = "DisplayName";
			this.colDisplayName.Name = "colDisplayName";
			this.colDisplayName.OptionsColumn.ReadOnly = true;
			// 
			// PanelControlStatus
			// 
			this.PanelControlStatus.Appearance.Options.UseTextOptions = true;
			this.PanelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("PanelControlStatus.ContentImage")));
			this.PanelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			this.PanelControlStatus.Controls.Add(this.LabelStatus);
			this.PanelControlStatus.Location = new System.Drawing.Point(308, 0);
			this.PanelControlStatus.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.PanelControlStatus.Name = "PanelControlStatus";
			this.PanelControlStatus.Size = new System.Drawing.Size(120, 23);
			this.PanelControlStatus.TabIndex = 265;
			this.PanelControlStatus.Visible = false;
			// 
			// LabelStatus
			// 
			this.LabelStatus.Location = new System.Drawing.Point(30, 5);
			this.LabelStatus.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.LabelStatus.Name = "LabelStatus";
			this.LabelStatus.Size = new System.Drawing.Size(0, 13);
			this.LabelStatus.TabIndex = 5;
			// 
			// BarManager
			// 
			this.BarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
			this.BarManager.DockControls.Add(this.barDockControlTop);
			this.BarManager.DockControls.Add(this.barDockControlBottom);
			this.BarManager.DockControls.Add(this.barDockControlLeft);
			this.BarManager.DockControls.Add(this.barDockControlRight);
			this.BarManager.Form = this;
			this.BarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemNew,
            this.barButtonItemDelete,
            this.barButtonItemSave});
			this.BarManager.MaxItemId = 3;
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
			this.barButtonItemNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemNew_ItemClick);
			// 
			// barButtonItemDelete
			// 
			this.barButtonItemDelete.Caption = "Delete";
			this.barButtonItemDelete.Id = 1;
			this.barButtonItemDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemDelete.ImageOptions.Image")));
			this.barButtonItemDelete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemDelete.ImageOptions.LargeImage")));
			this.barButtonItemDelete.Name = "barButtonItemDelete";
			this.barButtonItemDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemDelete_ItemClick);
			// 
			// barButtonItemSave
			// 
			this.barButtonItemSave.Caption = "Save";
			this.barButtonItemSave.Id = 2;
			this.barButtonItemSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemSave.ImageOptions.Image")));
			this.barButtonItemSave.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemSave.ImageOptions.LargeImage")));
			this.barButtonItemSave.Name = "barButtonItemSave";
			this.barButtonItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemSave_ItemClick);
			// 
			// barDockControlTop
			// 
			this.barDockControlTop.CausesValidation = false;
			this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
			this.barDockControlTop.Manager = this.BarManager;
			this.barDockControlTop.Size = new System.Drawing.Size(958, 31);
			// 
			// barDockControlBottom
			// 
			this.barDockControlBottom.CausesValidation = false;
			this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.barDockControlBottom.Location = new System.Drawing.Point(0, 493);
			this.barDockControlBottom.Manager = this.BarManager;
			this.barDockControlBottom.Size = new System.Drawing.Size(958, 0);
			// 
			// barDockControlLeft
			// 
			this.barDockControlLeft.CausesValidation = false;
			this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
			this.barDockControlLeft.Manager = this.BarManager;
			this.barDockControlLeft.Size = new System.Drawing.Size(0, 462);
			// 
			// barDockControlRight
			// 
			this.barDockControlRight.CausesValidation = false;
			this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.barDockControlRight.Location = new System.Drawing.Point(958, 31);
			this.barDockControlRight.Manager = this.BarManager;
			this.barDockControlRight.Size = new System.Drawing.Size(0, 462);
			// 
			// StateForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(958, 493);
			this.Controls.Add(this.PanelControlStatus);
			this.Controls.Add(this.splitContainerControl);
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
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StateForm_FormClosing);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StateForm_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.TextEditCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridControlLookup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridViewLookup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TextEditGroup.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
			this.splitContainerControl.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditCountry.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BindingSourceCodeName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.customSearchLookUpEdit1View)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditRegion.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PanelControlStatus)).EndInit();
			this.PanelControlStatus.ResumeLayout(false);
			this.PanelControlStatus.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl GridControlLookup;
        private System.Windows.Forms.BindingSource BindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewLookup;
        private DevExpress.XtraEditors.TextEdit TextEditName;
        private DevExpress.XtraEditors.TextEdit TextEditGroup;
        private DevExpress.XtraEditors.TextEdit TextEditCode;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraEditors.PanelControl PanelControlStatus;
        private DevExpress.XtraEditors.LabelControl LabelStatus;
        private DevExpress.XtraGrid.Columns.GridColumn GridColumnCode;
        private DevExpress.XtraGrid.Columns.GridColumn GridColumnState;
        private DevExpress.XtraGrid.Columns.GridColumn GridColumnCountry;
        private DevExpress.XtraGrid.Columns.GridColumn GridColumnRegion;
        private DevExpress.XtraGrid.Columns.GridColumn GridColumnGroup;
        private DevExpress.XtraGrid.Columns.GridColumn GridColumnAddress;
        private System.Windows.Forms.BindingSource BindingSourceCodeName;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarManager BarManager;
		private DevExpress.XtraBars.Bar bar1;
		private DevExpress.XtraBars.BarButtonItem barButtonItemNew;
		private DevExpress.XtraBars.BarButtonItem barButtonItemDelete;
		private DevExpress.XtraBars.BarButtonItem barButtonItemSave;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
		private Custom_SearchLookupEdit.CustomSearchLookUpEdit SearchLookupEditCountry;
		private DevExpress.XtraGrid.Views.Grid.GridView customSearchLookUpEdit1View;
		private Custom_SearchLookupEdit.CustomSearchLookUpEdit SearchLookupEditRegion;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn colCode1;
		private DevExpress.XtraGrid.Columns.GridColumn colName1;
		private DevExpress.XtraGrid.Columns.GridColumn colDisplayName1;
		private DevExpress.XtraGrid.Columns.GridColumn colCode;
		private DevExpress.XtraGrid.Columns.GridColumn colName;
		private DevExpress.XtraGrid.Columns.GridColumn colDisplayName;
	}
}