namespace TraceForms
{
    partial class RelatedProductsForm
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
            System.Windows.Forms.Label labelType;
            System.Windows.Forms.Label labelCode;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RelatedProductsForm));
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControlLookup = new DevExpress.XtraGrid.GridControl();
            this.entityInstantFeedbackSource = new DevExpress.Data.Linq.EntityInstantFeedbackSource();
            this.gridViewLookup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProduct_Type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProduct_Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExcluded = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colServiceStart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colServiceEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBookingStart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBookingEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInactive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colError = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErrors = new DevExpress.XtraGrid.Columns.GridColumn();
            this.checkEditExcluded = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.dateEditBookingEnd = new DevExpress.XtraEditors.DateEdit();
            this.dateEditBookingStart = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEditMasterType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEditRelatedType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.checkEditInactive = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateEditServiceEnd = new DevExpress.XtraEditors.DateEdit();
            this.dateEditServiceStart = new DevExpress.XtraEditors.DateEdit();
            this.SearchLookupEditMaster = new Custom_SearchLookupEdit.CustomSearchLookUpEdit();
            this.bindingSourceCodeNameMaster = new System.Windows.Forms.BindingSource(this.components);
            this.searchLookUpEditViewMaster = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMasterCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMasterName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMasterDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SearchLookupEditRelated = new Custom_SearchLookupEdit.CustomSearchLookUpEdit();
            this.bindingSourceCodeNameRelated = new System.Windows.Forms.BindingSource(this.components);
            this.SearchLookupEditGridViewRelated = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRelatedCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRelatedName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRelatedDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.bindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.buttonMoveUp = new System.Windows.Forms.ToolStripButton();
            this.buttonMoveDown = new System.Windows.Forms.ToolStripButton();
            this.panelControlStatus = new DevExpress.XtraEditors.PanelControl();
            this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
            this.xpInstantFeedbackSource = new DevExpress.Xpo.XPInstantFeedbackSource(this.components);
            labelType = new System.Windows.Forms.Label();
            labelCode = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditExcluded.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditBookingEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditBookingEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditBookingStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditBookingStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditMasterType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditRelatedType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditInactive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditServiceEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditServiceEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditServiceStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditServiceStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditMaster.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCodeNameMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEditViewMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditRelated.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCodeNameRelated)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditGridViewRelated)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).BeginInit();
            this.bindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).BeginInit();
            this.panelControlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelType
            // 
            labelType.AutoSize = true;
            labelType.Location = new System.Drawing.Point(28, 394);
            labelType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelType.Name = "labelType";
            labelType.Size = new System.Drawing.Size(128, 24);
            labelType.TabIndex = 4;
            labelType.Text = "Related Type";
            // 
            // labelCode
            // 
            labelCode.AutoSize = true;
            labelCode.Location = new System.Drawing.Point(28, 445);
            labelCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelCode.Name = "labelCode";
            labelCode.Size = new System.Drawing.Size(151, 24);
            labelCode.TabIndex = 6;
            labelCode.Text = "Related Product";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(28, 290);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(120, 24);
            label1.TabIndex = 0;
            label1.Text = "Master Type";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(28, 342);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(143, 24);
            label2.TabIndex = 2;
            label2.Text = "Master Product";
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(FlexModel.RelatedProduct);
            this.bindingSource.CurrentChanged += new System.EventHandler(this.ProductBindingSource_CurrentChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.Location = new System.Drawing.Point(0, 50);
            this.splitContainerControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Panel1.AutoScroll = true;
            this.splitContainerControl.Panel1.Controls.Add(this.gridControlLookup);
            this.splitContainerControl.Panel2.AutoScroll = true;
            this.splitContainerControl.Panel2.Controls.Add(this.checkEditExcluded);
            this.splitContainerControl.Panel2.Controls.Add(this.labelControl5);
            this.splitContainerControl.Panel2.Controls.Add(this.labelControl6);
            this.splitContainerControl.Panel2.Controls.Add(this.labelControl7);
            this.splitContainerControl.Panel2.Controls.Add(this.dateEditBookingEnd);
            this.splitContainerControl.Panel2.Controls.Add(this.dateEditBookingStart);
            this.splitContainerControl.Panel2.Controls.Add(this.labelControl4);
            this.splitContainerControl.Panel2.Controls.Add(this.comboBoxEditMasterType);
            this.splitContainerControl.Panel2.Controls.Add(label1);
            this.splitContainerControl.Panel2.Controls.Add(label2);
            this.splitContainerControl.Panel2.Controls.Add(this.comboBoxEditRelatedType);
            this.splitContainerControl.Panel2.Controls.Add(labelType);
            this.splitContainerControl.Panel2.Controls.Add(labelCode);
            this.splitContainerControl.Panel2.Controls.Add(this.checkEditInactive);
            this.splitContainerControl.Panel2.Controls.Add(this.labelControl3);
            this.splitContainerControl.Panel2.Controls.Add(this.labelControl2);
            this.splitContainerControl.Panel2.Controls.Add(this.dateEditServiceEnd);
            this.splitContainerControl.Panel2.Controls.Add(this.dateEditServiceStart);
            this.splitContainerControl.Panel2.Controls.Add(this.SearchLookupEditMaster);
            this.splitContainerControl.Panel2.Controls.Add(this.SearchLookupEditRelated);
            this.splitContainerControl.Size = new System.Drawing.Size(2107, 1582);
            this.splitContainerControl.SplitterPosition = 621;
            this.splitContainerControl.TabIndex = 39;
            // 
            // gridControlLookup
            // 
            this.gridControlLookup.DataSource = this.bindingSource;
            this.gridControlLookup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlLookup.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridControlLookup.Location = new System.Drawing.Point(0, 0);
            this.gridControlLookup.MainView = this.gridViewLookup;
            this.gridControlLookup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridControlLookup.Name = "gridControlLookup";
            this.gridControlLookup.Size = new System.Drawing.Size(621, 1582);
            this.gridControlLookup.TabIndex = 0;
            this.gridControlLookup.TabStop = false;
            this.gridControlLookup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLookup});
            // 
            // entityInstantFeedbackSource
            // 
            this.entityInstantFeedbackSource.DefaultSorting = null;
            this.entityInstantFeedbackSource.DesignTimeElementType = typeof(FlexModel.RelatedProduct);
            this.entityInstantFeedbackSource.KeyExpression = "ID";
            // 
            // gridViewLookup
            // 
            this.gridViewLookup.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewLookup.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridViewLookup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colProduct_Type,
            this.colProduct_Code,
            this.colType,
            this.colCode,
            this.colExcluded,
            this.colServiceStart,
            this.colServiceEnd,
            this.colBookingStart,
            this.colBookingEnd,
            this.colInactive,
            this.colPosition,
            this.colError,
            this.colErrors});
            this.gridViewLookup.GridControl = this.gridControlLookup;
            this.gridViewLookup.Name = "gridViewLookup";
            this.gridViewLookup.OptionsBehavior.Editable = false;
            this.gridViewLookup.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewLookup.OptionsView.ShowAutoFilterRow = true;
            this.gridViewLookup.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridViewProduct_InvalidRowException);
            this.gridViewLookup.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridViewProduct_BeforeLeaveRow);
            this.gridViewLookup.ColumnFilterChanged += new System.EventHandler(this.GridViewProduct_ColumnFilterChanged);
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colProduct_Type
            // 
            this.colProduct_Type.Caption = "Master Type";
            this.colProduct_Type.FieldName = "Product_Type";
            this.colProduct_Type.Name = "colProduct_Type";
            this.colProduct_Type.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colProduct_Type.Visible = true;
            this.colProduct_Type.VisibleIndex = 0;
            this.colProduct_Type.Width = 189;
            // 
            // colProduct_Code
            // 
            this.colProduct_Code.Caption = "Master Product";
            this.colProduct_Code.FieldName = "Product_Code";
            this.colProduct_Code.Name = "colProduct_Code";
            this.colProduct_Code.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colProduct_Code.Visible = true;
            this.colProduct_Code.VisibleIndex = 1;
            this.colProduct_Code.Width = 331;
            // 
            // colType
            // 
            this.colType.Caption = "Related Type";
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            this.colType.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colType.Visible = true;
            this.colType.VisibleIndex = 2;
            this.colType.Width = 193;
            // 
            // colCode
            // 
            this.colCode.Caption = "Related Product";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 3;
            this.colCode.Width = 459;
            // 
            // colExcluded
            // 
            this.colExcluded.FieldName = "Excluded";
            this.colExcluded.Name = "colExcluded";
            // 
            // colServiceStart
            // 
            this.colServiceStart.FieldName = "ServiceStart";
            this.colServiceStart.Name = "colServiceStart";
            // 
            // colServiceEnd
            // 
            this.colServiceEnd.FieldName = "ServiceEnd";
            this.colServiceEnd.Name = "colServiceEnd";
            // 
            // colBookingStart
            // 
            this.colBookingStart.FieldName = "BookingStart";
            this.colBookingStart.Name = "colBookingStart";
            // 
            // colBookingEnd
            // 
            this.colBookingEnd.FieldName = "BookingEnd";
            this.colBookingEnd.Name = "colBookingEnd";
            // 
            // colInactive
            // 
            this.colInactive.FieldName = "Inactive";
            this.colInactive.Name = "colInactive";
            // 
            // colPosition
            // 
            this.colPosition.Caption = "Position";
            this.colPosition.FieldName = "Position";
            this.colPosition.Name = "colPosition";
            // 
            // colError
            // 
            this.colError.FieldName = "Error";
            this.colError.Name = "colError";
            this.colError.OptionsColumn.ReadOnly = true;
            // 
            // colErrors
            // 
            this.colErrors.FieldName = "Errors";
            this.colErrors.Name = "colErrors";
            this.colErrors.OptionsColumn.ReadOnly = true;
            // 
            // checkEditExcluded
            // 
            this.checkEditExcluded.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "Excluded", true));
            this.checkEditExcluded.Location = new System.Drawing.Point(202, 593);
            this.checkEditExcluded.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkEditExcluded.Name = "checkEditExcluded";
            this.checkEditExcluded.Properties.Caption = "Excluded from proximity search";
            this.checkEditExcluded.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.checkEditExcluded.Size = new System.Drawing.Size(307, 34);
            this.checkEditExcluded.TabIndex = 19;
            this.checkEditExcluded.Enter += new System.EventHandler(this.enterControl);
            this.checkEditExcluded.Leave += new System.EventHandler(this.checkEditExcluded_Leave);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(32, 551);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(118, 23);
            this.labelControl5.TabIndex = 13;
            this.labelControl5.Text = "Booking Date:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(438, 551);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(33, 23);
            this.labelControl6.TabIndex = 16;
            this.labelControl6.Text = "End";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(174, 551);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(40, 23);
            this.labelControl7.TabIndex = 14;
            this.labelControl7.Text = "Start";
            // 
            // dateEditBookingEnd
            // 
            this.dateEditBookingEnd.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "BookingEnd", true));
            this.dateEditBookingEnd.EditValue = null;
            this.dateEditBookingEnd.Location = new System.Drawing.Point(477, 547);
            this.dateEditBookingEnd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateEditBookingEnd.Name = "dateEditBookingEnd";
            this.dateEditBookingEnd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dateEditBookingEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditBookingEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditBookingEnd.Properties.DisplayFormat.FormatString = "dd-MMM-yyyy";
            this.dateEditBookingEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditBookingEnd.Size = new System.Drawing.Size(178, 32);
            this.dateEditBookingEnd.TabIndex = 17;
            this.dateEditBookingEnd.Enter += new System.EventHandler(this.enterControl);
            this.dateEditBookingEnd.Leave += new System.EventHandler(this.dateBooking_Leave);
            // 
            // dateEditBookingStart
            // 
            this.dateEditBookingStart.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "BookingStart", true));
            this.dateEditBookingStart.EditValue = null;
            this.dateEditBookingStart.Location = new System.Drawing.Point(220, 547);
            this.dateEditBookingStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateEditBookingStart.Name = "dateEditBookingStart";
            this.dateEditBookingStart.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dateEditBookingStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditBookingStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditBookingStart.Properties.DisplayFormat.FormatString = "dd-MMM-yyyy";
            this.dateEditBookingStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditBookingStart.Size = new System.Drawing.Size(178, 32);
            this.dateEditBookingStart.TabIndex = 15;
            this.dateEditBookingStart.Enter += new System.EventHandler(this.enterControl);
            this.dateEditBookingStart.Leave += new System.EventHandler(this.dateBooking_Leave);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(32, 499);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(112, 23);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Service Date:";
            // 
            // comboBoxEditMasterType
            // 
            this.comboBoxEditMasterType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Product_Type", true));
            this.comboBoxEditMasterType.EnterMoveNextControl = true;
            this.comboBoxEditMasterType.Location = new System.Drawing.Point(187, 286);
            this.comboBoxEditMasterType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxEditMasterType.Name = "comboBoxEditMasterType";
            this.comboBoxEditMasterType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditMasterType.Properties.Items.AddRange(new object[] {
            "",
            "HTL",
            "OPT",
            "PKG",
            "WAY"});
            this.comboBoxEditMasterType.Properties.MaxLength = 3;
            this.comboBoxEditMasterType.Size = new System.Drawing.Size(138, 32);
            this.comboBoxEditMasterType.TabIndex = 1;
            this.comboBoxEditMasterType.TextChanged += new System.EventHandler(this.comboBoxEditMasterType_TextChanged);
            this.comboBoxEditMasterType.Enter += new System.EventHandler(this.enterControl);
            this.comboBoxEditMasterType.Leave += new System.EventHandler(this.comboBoxEditMasterType_Leave);
            // 
            // comboBoxEditRelatedType
            // 
            this.comboBoxEditRelatedType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Type", true));
            this.comboBoxEditRelatedType.EnterMoveNextControl = true;
            this.comboBoxEditRelatedType.Location = new System.Drawing.Point(187, 390);
            this.comboBoxEditRelatedType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxEditRelatedType.Name = "comboBoxEditRelatedType";
            this.comboBoxEditRelatedType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditRelatedType.Properties.Items.AddRange(new object[] {
            "",
            "HTL",
            "OPT",
            "PKG",
            "WAY"});
            this.comboBoxEditRelatedType.Properties.MaxLength = 3;
            this.comboBoxEditRelatedType.Size = new System.Drawing.Size(138, 32);
            this.comboBoxEditRelatedType.TabIndex = 5;
            this.comboBoxEditRelatedType.TextChanged += new System.EventHandler(this.comboBoxEditRelatedType_TextChanged);
            this.comboBoxEditRelatedType.Enter += new System.EventHandler(this.enterControl);
            this.comboBoxEditRelatedType.Leave += new System.EventHandler(this.comboBoxEditRelatedType_Leave);
            // 
            // checkEditInactive
            // 
            this.checkEditInactive.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "Inactive", true));
            this.checkEditInactive.Location = new System.Drawing.Point(32, 593);
            this.checkEditInactive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkEditInactive.Name = "checkEditInactive";
            this.checkEditInactive.Properties.Caption = "Inactive";
            this.checkEditInactive.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.checkEditInactive.Size = new System.Drawing.Size(139, 34);
            this.checkEditInactive.TabIndex = 18;
            this.checkEditInactive.Enter += new System.EventHandler(this.enterControl);
            this.checkEditInactive.Leave += new System.EventHandler(this.checkEditInactive_Leave);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(438, 499);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(33, 23);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "End";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(174, 499);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 23);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "Start";
            // 
            // dateEditServiceEnd
            // 
            this.dateEditServiceEnd.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "ServiceEnd", true));
            this.dateEditServiceEnd.EditValue = null;
            this.dateEditServiceEnd.Location = new System.Drawing.Point(477, 496);
            this.dateEditServiceEnd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateEditServiceEnd.Name = "dateEditServiceEnd";
            this.dateEditServiceEnd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dateEditServiceEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditServiceEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditServiceEnd.Properties.DisplayFormat.FormatString = "dd-MMM-yyyy";
            this.dateEditServiceEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditServiceEnd.Size = new System.Drawing.Size(178, 32);
            this.dateEditServiceEnd.TabIndex = 12;
            this.dateEditServiceEnd.Enter += new System.EventHandler(this.enterControl);
            this.dateEditServiceEnd.Leave += new System.EventHandler(this.dateServices_Leave);
            // 
            // dateEditServiceStart
            // 
            this.dateEditServiceStart.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "ServiceStart", true));
            this.dateEditServiceStart.EditValue = null;
            this.dateEditServiceStart.Location = new System.Drawing.Point(220, 496);
            this.dateEditServiceStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateEditServiceStart.Name = "dateEditServiceStart";
            this.dateEditServiceStart.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dateEditServiceStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditServiceStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditServiceStart.Properties.DisplayFormat.FormatString = "dd-MMM-yyyy";
            this.dateEditServiceStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditServiceStart.Size = new System.Drawing.Size(178, 32);
            this.dateEditServiceStart.TabIndex = 10;
            this.dateEditServiceStart.Enter += new System.EventHandler(this.enterControl);
            this.dateEditServiceStart.Leave += new System.EventHandler(this.dateServices_Leave);
            // 
            // SearchLookupEditMaster
            // 
            this.SearchLookupEditMaster.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "Product_Code", true));
            this.SearchLookupEditMaster.Location = new System.Drawing.Point(187, 338);
            this.SearchLookupEditMaster.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SearchLookupEditMaster.Name = "SearchLookupEditMaster";
            this.SearchLookupEditMaster.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLookupEditMaster.Properties.DataSource = this.bindingSourceCodeNameMaster;
            this.SearchLookupEditMaster.Properties.DisplayMember = "DisplayName";
            this.SearchLookupEditMaster.Properties.NullText = "";
            this.SearchLookupEditMaster.Properties.PopupSizeable = false;
            this.SearchLookupEditMaster.Properties.ValueMember = "Code";
            this.SearchLookupEditMaster.Properties.View = this.searchLookUpEditViewMaster;
            this.SearchLookupEditMaster.Size = new System.Drawing.Size(627, 32);
            this.SearchLookupEditMaster.TabIndex = 3;
            this.SearchLookupEditMaster.UpdateDisplayFilter += new Custom_SearchLookupEdit.UpdateDisplayFilterHandler(this.SearchLookupEdit_UpdateDisplayFilter);
            this.SearchLookupEditMaster.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            this.SearchLookupEditMaster.Enter += new System.EventHandler(this.enterControl);
            this.SearchLookupEditMaster.Leave += new System.EventHandler(this.SearchLookupEditMasterCode_Leave);
            // 
            // bindingSourceCodeNameMaster
            // 
            this.bindingSourceCodeNameMaster.DataSource = typeof(TraceForms.CodeName);
            // 
            // searchLookUpEditViewMaster
            // 
            this.searchLookUpEditViewMaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMasterCode,
            this.colMasterName,
            this.colMasterDisplayName});
            this.searchLookUpEditViewMaster.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEditViewMaster.Name = "searchLookUpEditViewMaster";
            this.searchLookUpEditViewMaster.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEditViewMaster.OptionsView.ShowGroupPanel = false;
            this.searchLookUpEditViewMaster.OptionsView.ShowIndicator = false;
            // 
            // colMasterCode
            // 
            this.colMasterCode.FieldName = "Code";
            this.colMasterCode.Name = "colMasterCode";
            // 
            // colMasterName
            // 
            this.colMasterName.FieldName = "Name";
            this.colMasterName.Name = "colMasterName";
            // 
            // colMasterDisplayName
            // 
            this.colMasterDisplayName.Caption = "Product";
            this.colMasterDisplayName.FieldName = "DisplayName";
            this.colMasterDisplayName.Name = "colMasterDisplayName";
            this.colMasterDisplayName.OptionsColumn.ReadOnly = true;
            this.colMasterDisplayName.Visible = true;
            this.colMasterDisplayName.VisibleIndex = 0;
            // 
            // SearchLookupEditRelated
            // 
            this.SearchLookupEditRelated.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "Code", true));
            this.SearchLookupEditRelated.Location = new System.Drawing.Point(187, 441);
            this.SearchLookupEditRelated.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SearchLookupEditRelated.Name = "SearchLookupEditRelated";
            this.SearchLookupEditRelated.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLookupEditRelated.Properties.DataSource = this.bindingSourceCodeNameRelated;
            this.SearchLookupEditRelated.Properties.DisplayMember = "DisplayName";
            this.SearchLookupEditRelated.Properties.NullText = "";
            this.SearchLookupEditRelated.Properties.PopupSizeable = false;
            this.SearchLookupEditRelated.Properties.ValueMember = "Code";
            this.SearchLookupEditRelated.Properties.View = this.SearchLookupEditGridViewRelated;
            this.SearchLookupEditRelated.Size = new System.Drawing.Size(627, 32);
            this.SearchLookupEditRelated.TabIndex = 7;
            this.SearchLookupEditRelated.UpdateDisplayFilter += new Custom_SearchLookupEdit.UpdateDisplayFilterHandler(this.SearchLookupEdit_UpdateDisplayFilter);
            this.SearchLookupEditRelated.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            this.SearchLookupEditRelated.Enter += new System.EventHandler(this.enterControl);
            this.SearchLookupEditRelated.Leave += new System.EventHandler(this.SearchLookupEditRelatedCode_Leave);
            // 
            // bindingSourceCodeNameRelated
            // 
            this.bindingSourceCodeNameRelated.DataSource = typeof(TraceForms.CodeName);
            // 
            // SearchLookupEditGridViewRelated
            // 
            this.SearchLookupEditGridViewRelated.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRelatedCode,
            this.colRelatedName,
            this.colRelatedDisplayName});
            this.SearchLookupEditGridViewRelated.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.SearchLookupEditGridViewRelated.Name = "SearchLookupEditGridViewRelated";
            this.SearchLookupEditGridViewRelated.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.SearchLookupEditGridViewRelated.OptionsView.ShowGroupPanel = false;
            this.SearchLookupEditGridViewRelated.OptionsView.ShowIndicator = false;
            // 
            // colRelatedCode
            // 
            this.colRelatedCode.FieldName = "Code";
            this.colRelatedCode.Name = "colRelatedCode";
            // 
            // colRelatedName
            // 
            this.colRelatedName.FieldName = "Name";
            this.colRelatedName.Name = "colRelatedName";
            // 
            // colRelatedDisplayName
            // 
            this.colRelatedDisplayName.Caption = "Product";
            this.colRelatedDisplayName.FieldName = "DisplayName";
            this.colRelatedDisplayName.Name = "colRelatedDisplayName";
            this.colRelatedDisplayName.OptionsColumn.ReadOnly = true;
            this.colRelatedDisplayName.Visible = true;
            this.colRelatedDisplayName.VisibleIndex = 0;
            // 
            // bindingNavigator
            // 
            this.bindingNavigator.AddNewItem = null;
            this.bindingNavigator.BindingSource = this.bindingSource;
            this.bindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator.DeleteItem = null;
            this.bindingNavigator.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.bindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bindingNavigatorSaveItem,
            this.buttonMoveUp,
            this.buttonMoveDown});
            this.bindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator.MoveFirstItem = null;
            this.bindingNavigator.MoveLastItem = null;
            this.bindingNavigator.MoveNextItem = null;
            this.bindingNavigator.MovePreviousItem = null;
            this.bindingNavigator.Name = "bindingNavigator";
            this.bindingNavigator.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.bindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator.Size = new System.Drawing.Size(1700, 35);
            this.bindingNavigator.TabIndex = 23;
            this.bindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(61, 32);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(28, 32);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            this.bindingNavigatorMoveFirstItem.Click += new System.EventHandler(this.bindingNavigatorMoveFirstItem_Click);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(28, 32);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            this.bindingNavigatorMovePreviousItem.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click);
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 35);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(81, 35);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            this.bindingNavigatorPositionItem.Enter += new System.EventHandler(this.bindingNavigatorPositionItem_Enter);
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(28, 32);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            this.bindingNavigatorMoveNextItem.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(28, 32);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            this.bindingNavigatorMoveLastItem.Click += new System.EventHandler(this.bindingNavigatorMoveLastItem_Click);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 35);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(28, 32);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(28, 32);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // bindingNavigatorSaveItem
            // 
            this.bindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorSaveItem.Image")));
            this.bindingNavigatorSaveItem.Name = "bindingNavigatorSaveItem";
            this.bindingNavigatorSaveItem.Size = new System.Drawing.Size(28, 32);
            this.bindingNavigatorSaveItem.Text = "Save Data";
            this.bindingNavigatorSaveItem.Click += new System.EventHandler(this.BindingNavigatorSaveItem_Click);
            // 
            // buttonMoveUp
            // 
            this.buttonMoveUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonMoveUp.Image = global::TraceForms.Properties.Resources.arrow_up;
            this.buttonMoveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonMoveUp.Name = "buttonMoveUp";
            this.buttonMoveUp.Size = new System.Drawing.Size(28, 32);
            this.buttonMoveUp.Text = "Move Up";
            this.buttonMoveUp.Click += new System.EventHandler(this.ButtonMoveUp_Click);
            // 
            // buttonMoveDown
            // 
            this.buttonMoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonMoveDown.Image = global::TraceForms.Properties.Resources.arrow_down;
            this.buttonMoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonMoveDown.Name = "buttonMoveDown";
            this.buttonMoveDown.Size = new System.Drawing.Size(28, 32);
            this.buttonMoveDown.Text = "Move Down";
            this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
            // 
            // panelControlStatus
            // 
            this.panelControlStatus.Appearance.Options.UseTextOptions = true;
            this.panelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("panelControlStatus.ContentImage")));
            this.panelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.panelControlStatus.Controls.Add(this.LabelStatus);
            this.panelControlStatus.Location = new System.Drawing.Point(609, 4);
            this.panelControlStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelControlStatus.Name = "panelControlStatus";
            this.panelControlStatus.Size = new System.Drawing.Size(200, 41);
            this.panelControlStatus.TabIndex = 265;
            this.panelControlStatus.Visible = false;
            // 
            // LabelStatus
            // 
            this.LabelStatus.Location = new System.Drawing.Point(50, 8);
            this.LabelStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(0, 23);
            this.LabelStatus.TabIndex = 5;
            // 
            // xpInstantFeedbackSource
            // 
            this.xpInstantFeedbackSource.ObjectType = typeof(FlexModel.RelatedProduct);
            // 
            // RelatedProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1700, 1312);
            this.Controls.Add(this.panelControlStatus);
            this.Controls.Add(this.bindingNavigator);
            this.Controls.Add(this.splitContainerControl);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimizeBox = false;
            this.Name = "RelatedProductsForm";
            this.ShowInTaskbar = false;
            this.Text = "Related Products Maintenance";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RelatedProductsForm_FormClosing);
            this.Shown += new System.EventHandler(this.RelatedProductsForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RelatedProductsForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditExcluded.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditBookingEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditBookingEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditBookingStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditBookingStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditMasterType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditRelatedType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditInactive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditServiceEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditServiceEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditServiceStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditServiceStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditMaster.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCodeNameMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEditViewMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditRelated.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCodeNameRelated)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditGridViewRelated)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).EndInit();
            this.bindingNavigator.ResumeLayout(false);
            this.bindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).EndInit();
            this.panelControlStatus.ResumeLayout(false);
            this.panelControlStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource;
		private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraGrid.GridControl gridControlLookup;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewLookup;
        private System.Windows.Forms.BindingNavigator bindingNavigator;
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
		private System.Windows.Forms.ToolStripButton bindingNavigatorSaveItem;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraEditors.PanelControl panelControlStatus;
		private DevExpress.XtraEditors.LabelControl LabelStatus;
		private DevExpress.XtraEditors.DateEdit dateEditServiceStart;
		private DevExpress.XtraEditors.CheckEdit checkEditInactive;
		private DevExpress.XtraEditors.LabelControl labelControl3;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.DateEdit dateEditServiceEnd;
		private DevExpress.XtraGrid.Columns.GridColumn colID;
		private DevExpress.XtraGrid.Columns.GridColumn colProduct_Type;
		private DevExpress.XtraGrid.Columns.GridColumn colProduct_Code;
		private DevExpress.XtraGrid.Columns.GridColumn colType;
		private DevExpress.XtraGrid.Columns.GridColumn colCode;
		private DevExpress.XtraGrid.Columns.GridColumn colExcluded;
		private DevExpress.XtraGrid.Columns.GridColumn colServiceStart;
		private DevExpress.XtraGrid.Columns.GridColumn colServiceEnd;
		private DevExpress.XtraGrid.Columns.GridColumn colBookingStart;
		private DevExpress.XtraGrid.Columns.GridColumn colBookingEnd;
		private DevExpress.XtraGrid.Columns.GridColumn colInactive;
		private DevExpress.XtraGrid.Columns.GridColumn colError;
		private DevExpress.XtraGrid.Columns.GridColumn colErrors;
		private DevExpress.XtraEditors.CheckEdit checkEditExcluded;
		private DevExpress.XtraEditors.LabelControl labelControl5;
		private DevExpress.XtraEditors.LabelControl labelControl6;
		private DevExpress.XtraEditors.LabelControl labelControl7;
		private DevExpress.XtraEditors.DateEdit dateEditBookingEnd;
		private DevExpress.XtraEditors.DateEdit dateEditBookingStart;
		private DevExpress.XtraEditors.LabelControl labelControl4;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditMasterType;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditRelatedType;
        private System.Windows.Forms.ToolStripButton buttonMoveUp;
        private System.Windows.Forms.ToolStripButton buttonMoveDown;
        private Custom_SearchLookupEdit.CustomSearchLookUpEdit SearchLookupEditMaster;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEditViewMaster;
        private Custom_SearchLookupEdit.CustomSearchLookUpEdit SearchLookupEditRelated;
        private DevExpress.XtraGrid.Views.Grid.GridView SearchLookupEditGridViewRelated;
        private System.Windows.Forms.BindingSource bindingSourceCodeNameMaster;
        private System.Windows.Forms.BindingSource bindingSourceCodeNameRelated;
        private DevExpress.XtraGrid.Columns.GridColumn colMasterCode;
        private DevExpress.XtraGrid.Columns.GridColumn colMasterName;
        private DevExpress.XtraGrid.Columns.GridColumn colMasterDisplayName;
        private DevExpress.XtraGrid.Columns.GridColumn colRelatedCode;
        private DevExpress.XtraGrid.Columns.GridColumn colRelatedName;
        private DevExpress.XtraGrid.Columns.GridColumn colRelatedDisplayName;
        private DevExpress.XtraGrid.Columns.GridColumn colPosition;
        private DevExpress.Data.Linq.EntityInstantFeedbackSource entityInstantFeedbackSource;
        private DevExpress.Xpo.XPInstantFeedbackSource xpInstantFeedbackSource;
    }
}