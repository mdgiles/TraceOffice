namespace TraceForms
{
    partial class BookSelForm
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
            System.Windows.Forms.Label activeLabel;
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Label selGroupLabel;
            this.BookSelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codeSearch = new FlexControls.GridSearchControl();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.BookComboBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBookCombo_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBookSel_Group = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMustInclude = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMustExclude = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colActive1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCat1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSvcDate_Start1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSvcDate_End1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuery1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDaysPriorToStart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDaysAfterStart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDaysPriorToEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDaysAfterEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnyOverlap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRequiredNts = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHotel_User_Txt2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCity1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBookSel_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSelGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroup_Active = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResDate_Start = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResDate_End = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSvcDate_Start = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSvcDate_End = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuery = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComp_Serv_Type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBookSel1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBookSel2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.descriptionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.group_ActiveCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.SaveChangesReq = new DevExpress.XtraEditors.SimpleButton();
            this.SaveChangesSel = new DevExpress.XtraEditors.SimpleButton();
            this.grdReqDel = new DevExpress.XtraEditors.SimpleButton();
            this.grdReqAdd = new DevExpress.XtraEditors.SimpleButton();
            this.grdSelDel = new DevExpress.XtraEditors.SimpleButton();
            this.grdSelAdd = new DevExpress.XtraEditors.SimpleButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            activeLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            selGroupLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BookSelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BookComboBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.group_ActiveCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // activeLabel
            // 
            activeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            activeLabel.AutoSize = true;
            activeLabel.Location = new System.Drawing.Point(819, 43);
            activeLabel.Name = "activeLabel";
            activeLabel.Size = new System.Drawing.Size(37, 13);
            activeLabel.TabIndex = 11;
            activeLabel.Text = "Active";
            // 
            // descriptionLabel
            // 
            descriptionLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(453, 42);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(60, 13);
            descriptionLabel.TabIndex = 9;
            descriptionLabel.Text = "Description";
            // 
            // selGroupLabel
            // 
            selGroupLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            selGroupLabel.AutoSize = true;
            selGroupLabel.Location = new System.Drawing.Point(109, 42);
            selGroupLabel.Name = "selGroupLabel";
            selGroupLabel.Size = new System.Drawing.Size(82, 13);
            selGroupLabel.TabIndex = 7;
            selGroupLabel.Text = "Selection Group";
            // 
            // BookSelBindingSource
            // 
            this.BookSelBindingSource.DataSource = typeof(FlexModel.BookSel);
            // 
            // codeSearch
            // 
            this.codeSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.codeSearch.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.codeSearch.Appearance.Options.UseBackColor = true;
            this.codeSearch.AutoAdjustWidth = true;
            this.codeSearch.DisplayMember = null;
            this.codeSearch.EnterMoveNextControl = false;
            this.codeSearch.FilterOn = false;
            this.codeSearch.GridVisible = false;
            this.codeSearch.LastError = "";
            this.codeSearch.Location = new System.Drawing.Point(197, 40);
            this.codeSearch.LookupName = "value";
            this.codeSearch.MaxWidth = 500;
            this.codeSearch.MinWidth = 250;
            this.codeSearch.Name = "codeSearch";
            this.codeSearch.PromptOnChange = false;
            this.codeSearch.PromptText = "";
            this.codeSearch.ShowPopupNumberOfChars = 3;
            this.codeSearch.Size = new System.Drawing.Size(118, 27);
            this.codeSearch.TabIndex = 15;
            this.codeSearch.ValidateOnEnter = false;
            this.codeSearch.ValidateOnSelection = false;
            this.codeSearch.Value = "";
            this.codeSearch.ValueMember = null;
            this.codeSearch.Enter += new System.EventHandler(this.codeSearch_Enter);
            // 
            // gridControl2
            // 
            this.gridControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl2.DataSource = this.BookComboBindingSource;
            this.gridControl2.Location = new System.Drawing.Point(0, 732);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControl2.Size = new System.Drawing.Size(1139, 294);
            this.gridControl2.TabIndex = 14;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // BookComboBindingSource
            // 
            this.BookComboBindingSource.DataSource = typeof(FlexModel.BookCombo);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBookCombo_ID,
            this.colDescription1,
            this.colBookSel_Group,
            this.colMustInclude,
            this.colMustExclude,
            this.colActive1,
            this.colType1,
            this.colCode1,
            this.colCat1,
            this.colSvcDate_Start1,
            this.colSvcDate_End1,
            this.colQuery1,
            this.colDaysPriorToStart,
            this.colDaysAfterStart,
            this.colDaysPriorToEnd,
            this.colDaysAfterEnd,
            this.colAnyOverlap,
            this.colRequiredNts,
            this.colHotel_User_Txt2,
            this.colCity1});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView2_CellValueChanging);
            this.gridView2.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView2_InvalidRowException);
            this.gridView2.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView2_BeforeLeaveRow);
            this.gridView2.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView2_ValidateRow);
            // 
            // colBookCombo_ID
            // 
            this.colBookCombo_ID.FieldName = "BookCombo_ID";
            this.colBookCombo_ID.Name = "colBookCombo_ID";
            // 
            // colDescription1
            // 
            this.colDescription1.FieldName = "Description";
            this.colDescription1.Name = "colDescription1";
            // 
            // colBookSel_Group
            // 
            this.colBookSel_Group.FieldName = "BookSel_Group";
            this.colBookSel_Group.Name = "colBookSel_Group";
            // 
            // colMustInclude
            // 
            this.colMustInclude.Caption = "Incl";
            this.colMustInclude.FieldName = "MustInclude";
            this.colMustInclude.Name = "colMustInclude";
            this.colMustInclude.Visible = true;
            this.colMustInclude.VisibleIndex = 1;
            // 
            // colMustExclude
            // 
            this.colMustExclude.Caption = "Excl";
            this.colMustExclude.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colMustExclude.FieldName = "MustExclude";
            this.colMustExclude.Name = "colMustExclude";
            this.colMustExclude.Visible = true;
            this.colMustExclude.VisibleIndex = 2;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colActive1
            // 
            this.colActive1.FieldName = "Active";
            this.colActive1.Name = "colActive1";
            this.colActive1.Visible = true;
            this.colActive1.VisibleIndex = 0;
            // 
            // colType1
            // 
            this.colType1.FieldName = "Type";
            this.colType1.Name = "colType1";
            this.colType1.Visible = true;
            this.colType1.VisibleIndex = 3;
            // 
            // colCode1
            // 
            this.colCode1.FieldName = "Code";
            this.colCode1.Name = "colCode1";
            this.colCode1.Visible = true;
            this.colCode1.VisibleIndex = 4;
            // 
            // colCat1
            // 
            this.colCat1.FieldName = "Cat";
            this.colCat1.Name = "colCat1";
            this.colCat1.Visible = true;
            this.colCat1.VisibleIndex = 5;
            // 
            // colSvcDate_Start1
            // 
            this.colSvcDate_Start1.Caption = "SvcDateStart";
            this.colSvcDate_Start1.FieldName = "SvcDate_Start";
            this.colSvcDate_Start1.Name = "colSvcDate_Start1";
            this.colSvcDate_Start1.Visible = true;
            this.colSvcDate_Start1.VisibleIndex = 6;
            // 
            // colSvcDate_End1
            // 
            this.colSvcDate_End1.Caption = "SvcDateEnd";
            this.colSvcDate_End1.FieldName = "SvcDate_End";
            this.colSvcDate_End1.Name = "colSvcDate_End1";
            this.colSvcDate_End1.Visible = true;
            this.colSvcDate_End1.VisibleIndex = 7;
            // 
            // colQuery1
            // 
            this.colQuery1.FieldName = "Query";
            this.colQuery1.Name = "colQuery1";
            this.colQuery1.Visible = true;
            this.colQuery1.VisibleIndex = 16;
            // 
            // colDaysPriorToStart
            // 
            this.colDaysPriorToStart.Caption = "DaysPrior";
            this.colDaysPriorToStart.FieldName = "DaysPriorToStart";
            this.colDaysPriorToStart.Name = "colDaysPriorToStart";
            this.colDaysPriorToStart.Visible = true;
            this.colDaysPriorToStart.VisibleIndex = 10;
            // 
            // colDaysAfterStart
            // 
            this.colDaysAfterStart.Caption = "DaysAfter";
            this.colDaysAfterStart.FieldName = "DaysAfterStart";
            this.colDaysAfterStart.Name = "colDaysAfterStart";
            this.colDaysAfterStart.Visible = true;
            this.colDaysAfterStart.VisibleIndex = 11;
            // 
            // colDaysPriorToEnd
            // 
            this.colDaysPriorToEnd.Caption = "PriorEnd";
            this.colDaysPriorToEnd.FieldName = "DaysPriorToEnd";
            this.colDaysPriorToEnd.Name = "colDaysPriorToEnd";
            this.colDaysPriorToEnd.Visible = true;
            this.colDaysPriorToEnd.VisibleIndex = 12;
            // 
            // colDaysAfterEnd
            // 
            this.colDaysAfterEnd.Caption = "AfterEnd";
            this.colDaysAfterEnd.FieldName = "DaysAfterEnd";
            this.colDaysAfterEnd.Name = "colDaysAfterEnd";
            this.colDaysAfterEnd.Visible = true;
            this.colDaysAfterEnd.VisibleIndex = 13;
            // 
            // colAnyOverlap
            // 
            this.colAnyOverlap.Caption = "Overlap";
            this.colAnyOverlap.FieldName = "AnyOverlap";
            this.colAnyOverlap.Name = "colAnyOverlap";
            this.colAnyOverlap.Visible = true;
            this.colAnyOverlap.VisibleIndex = 15;
            // 
            // colRequiredNts
            // 
            this.colRequiredNts.Caption = "ReqNts";
            this.colRequiredNts.FieldName = "RequiredNts";
            this.colRequiredNts.Name = "colRequiredNts";
            this.colRequiredNts.Visible = true;
            this.colRequiredNts.VisibleIndex = 14;
            // 
            // colHotel_User_Txt2
            // 
            this.colHotel_User_Txt2.Caption = "Ticket Location";
            this.colHotel_User_Txt2.FieldName = "Hotel_User_Txt2";
            this.colHotel_User_Txt2.Name = "colHotel_User_Txt2";
            this.colHotel_User_Txt2.OptionsColumn.ReadOnly = true;
            this.colHotel_User_Txt2.Visible = true;
            this.colHotel_User_Txt2.VisibleIndex = 8;
            // 
            // colCity1
            // 
            this.colCity1.FieldName = "City";
            this.colCity1.Name = "colCity1";
            this.colCity1.Visible = true;
            this.colCity1.VisibleIndex = 9;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.DataSource = this.BookSelBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(0, 350);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1139, 294);
            this.gridControl1.TabIndex = 13;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBookSel_ID,
            this.colSelGroup,
            this.colGroup_Active,
            this.colDescription,
            this.colActive,
            this.colResDate_Start,
            this.colResDate_End,
            this.colSvcDate_Start,
            this.colSvcDate_End,
            this.colType,
            this.colCode,
            this.colCat,
            this.colQuery,
            this.colComp_Serv_Type,
            this.colCity,
            this.colBookSel1,
            this.colBookSel2});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            this.gridView1.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            this.gridView1.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView1_BeforeLeaveRow);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            // 
            // colBookSel_ID
            // 
            this.colBookSel_ID.FieldName = "BookSel_ID";
            this.colBookSel_ID.Name = "colBookSel_ID";
            // 
            // colSelGroup
            // 
            this.colSelGroup.FieldName = "SelGroup";
            this.colSelGroup.Name = "colSelGroup";
            // 
            // colGroup_Active
            // 
            this.colGroup_Active.FieldName = "Group_Active";
            this.colGroup_Active.Name = "colGroup_Active";
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            // 
            // colActive
            // 
            this.colActive.FieldName = "Active";
            this.colActive.Name = "colActive";
            this.colActive.Visible = true;
            this.colActive.VisibleIndex = 0;
            // 
            // colResDate_Start
            // 
            this.colResDate_Start.Caption = "ResDateStart";
            this.colResDate_Start.FieldName = "ResDate_Start";
            this.colResDate_Start.Name = "colResDate_Start";
            this.colResDate_Start.Visible = true;
            this.colResDate_Start.VisibleIndex = 1;
            // 
            // colResDate_End
            // 
            this.colResDate_End.Caption = "ResDateEnd";
            this.colResDate_End.FieldName = "ResDate_End";
            this.colResDate_End.Name = "colResDate_End";
            this.colResDate_End.Visible = true;
            this.colResDate_End.VisibleIndex = 2;
            // 
            // colSvcDate_Start
            // 
            this.colSvcDate_Start.Caption = "SvcDateStart";
            this.colSvcDate_Start.FieldName = "SvcDate_Start";
            this.colSvcDate_Start.Name = "colSvcDate_Start";
            this.colSvcDate_Start.Visible = true;
            this.colSvcDate_Start.VisibleIndex = 3;
            // 
            // colSvcDate_End
            // 
            this.colSvcDate_End.Caption = "SvcDateEnd";
            this.colSvcDate_End.FieldName = "SvcDate_End";
            this.colSvcDate_End.Name = "colSvcDate_End";
            this.colSvcDate_End.Visible = true;
            this.colSvcDate_End.VisibleIndex = 4;
            // 
            // colType
            // 
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            this.colType.Visible = true;
            this.colType.VisibleIndex = 5;
            // 
            // colCode
            // 
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 6;
            // 
            // colCat
            // 
            this.colCat.FieldName = "Cat";
            this.colCat.Name = "colCat";
            this.colCat.Visible = true;
            this.colCat.VisibleIndex = 7;
            // 
            // colQuery
            // 
            this.colQuery.FieldName = "Query";
            this.colQuery.Name = "colQuery";
            this.colQuery.Visible = true;
            this.colQuery.VisibleIndex = 10;
            // 
            // colComp_Serv_Type
            // 
            this.colComp_Serv_Type.Caption = "Svc";
            this.colComp_Serv_Type.FieldName = "Comp_Serv_Type";
            this.colComp_Serv_Type.Name = "colComp_Serv_Type";
            this.colComp_Serv_Type.Visible = true;
            this.colComp_Serv_Type.VisibleIndex = 8;
            // 
            // colCity
            // 
            this.colCity.FieldName = "City";
            this.colCity.Name = "colCity";
            this.colCity.Visible = true;
            this.colCity.VisibleIndex = 9;
            // 
            // colBookSel1
            // 
            this.colBookSel1.FieldName = "BookSel1";
            this.colBookSel1.Name = "colBookSel1";
            // 
            // colBookSel2
            // 
            this.colBookSel2.FieldName = "BookSel2";
            this.colBookSel2.Name = "colBookSel2";
            // 
            // descriptionTextEdit
            // 
            this.descriptionTextEdit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.descriptionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BookSelBindingSource, "Description", true));
            this.descriptionTextEdit.Location = new System.Drawing.Point(518, 39);
            this.descriptionTextEdit.Name = "descriptionTextEdit";
            this.descriptionTextEdit.Size = new System.Drawing.Size(238, 20);
            this.descriptionTextEdit.TabIndex = 10;
            this.descriptionTextEdit.Enter += new System.EventHandler(this.enterControl);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.AutoScroll = true;
            this.splitContainerControl1.Panel1.Controls.Add(this.group_ActiveCheckEdit);
            this.splitContainerControl1.Panel1.Controls.Add(this.SaveChangesReq);
            this.splitContainerControl1.Panel1.Controls.Add(this.SaveChangesSel);
            this.splitContainerControl1.Panel1.Controls.Add(this.grdReqDel);
            this.splitContainerControl1.Panel1.Controls.Add(this.grdReqAdd);
            this.splitContainerControl1.Panel1.Controls.Add(this.grdSelDel);
            this.splitContainerControl1.Panel1.Controls.Add(this.grdSelAdd);
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.codeSearch);
            this.splitContainerControl1.Panel1.Controls.Add(activeLabel);
            this.splitContainerControl1.Panel1.Controls.Add(selGroupLabel);
            this.splitContainerControl1.Panel1.Controls.Add(this.descriptionTextEdit);
            this.splitContainerControl1.Panel1.Controls.Add(descriptionLabel);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.AutoScroll = true;
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1264, 742);
            this.splitContainerControl1.SplitterPosition = 1259;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // group_ActiveCheckEdit
            // 
            this.group_ActiveCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BookSelBindingSource, "Group_Active", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.group_ActiveCheckEdit.Location = new System.Drawing.Point(918, 41);
            this.group_ActiveCheckEdit.Name = "group_ActiveCheckEdit";
            this.group_ActiveCheckEdit.Properties.Caption = "";
            this.group_ActiveCheckEdit.Properties.ValueChecked = ((short)(1));
            this.group_ActiveCheckEdit.Properties.ValueUnchecked = ((short)(0));
            this.group_ActiveCheckEdit.Size = new System.Drawing.Size(21, 19);
            this.group_ActiveCheckEdit.TabIndex = 22;
            // 
            // SaveChangesReq
            // 
            this.SaveChangesReq.Location = new System.Drawing.Point(361, 812);
            this.SaveChangesReq.Name = "SaveChangesReq";
            this.SaveChangesReq.Size = new System.Drawing.Size(93, 23);
            this.SaveChangesReq.TabIndex = 21;
            this.SaveChangesReq.Text = "Save Changes";
            this.SaveChangesReq.Click += new System.EventHandler(this.SaveChangesReq_Click);
            // 
            // SaveChangesSel
            // 
            this.SaveChangesSel.Location = new System.Drawing.Point(361, 429);
            this.SaveChangesSel.Name = "SaveChangesSel";
            this.SaveChangesSel.Size = new System.Drawing.Size(93, 23);
            this.SaveChangesSel.TabIndex = 20;
            this.SaveChangesSel.Text = "Save Changes";
            this.SaveChangesSel.Click += new System.EventHandler(this.SaveChangesSel_Click);
            // 
            // grdReqDel
            // 
            this.grdReqDel.Location = new System.Drawing.Point(253, 812);
            this.grdReqDel.Name = "grdReqDel";
            this.grdReqDel.Size = new System.Drawing.Size(75, 23);
            this.grdReqDel.TabIndex = 19;
            this.grdReqDel.Text = "Delete Row";
            this.grdReqDel.Click += new System.EventHandler(this.grdReqDel_Click);
            // 
            // grdReqAdd
            // 
            this.grdReqAdd.Location = new System.Drawing.Point(139, 812);
            this.grdReqAdd.Name = "grdReqAdd";
            this.grdReqAdd.Size = new System.Drawing.Size(75, 23);
            this.grdReqAdd.TabIndex = 18;
            this.grdReqAdd.Text = "Add Row";
            this.grdReqAdd.Click += new System.EventHandler(this.grdReqAdd_Click);
            // 
            // grdSelDel
            // 
            this.grdSelDel.Location = new System.Drawing.Point(253, 429);
            this.grdSelDel.Name = "grdSelDel";
            this.grdSelDel.Size = new System.Drawing.Size(75, 23);
            this.grdSelDel.TabIndex = 17;
            this.grdSelDel.Text = "Delete Row";
            this.grdSelDel.Click += new System.EventHandler(this.grdSelDel_Click);
            // 
            // grdSelAdd
            // 
            this.grdSelAdd.Location = new System.Drawing.Point(139, 429);
            this.grdSelAdd.Name = "grdSelAdd";
            this.grdSelAdd.Size = new System.Drawing.Size(75, 23);
            this.grdSelAdd.TabIndex = 16;
            this.grdSelAdd.Text = "Add Row";
            this.grdSelAdd.Click += new System.EventHandler(this.grdSelAdd_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // BookSelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 742);
            this.Controls.Add(this.splitContainerControl1);
            this.MinimizeBox = false;
            this.Name = "BookSelForm";
            this.ShowInTaskbar = false;
            this.Text = "BookSelForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BookSelForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.BookSelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BookComboBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.group_ActiveCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource BookSelBindingSource;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colBookSel_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colSelGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colGroup_Active;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colActive;
        private DevExpress.XtraGrid.Columns.GridColumn colResDate_Start;
        private DevExpress.XtraGrid.Columns.GridColumn colResDate_End;
        private DevExpress.XtraGrid.Columns.GridColumn colSvcDate_Start;
        private DevExpress.XtraGrid.Columns.GridColumn colSvcDate_End;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCat;
        private DevExpress.XtraGrid.Columns.GridColumn colQuery;
        private DevExpress.XtraGrid.Columns.GridColumn colComp_Serv_Type;
        private DevExpress.XtraGrid.Columns.GridColumn colCity;
        private DevExpress.XtraGrid.Columns.GridColumn colBookSel1;
        private DevExpress.XtraGrid.Columns.GridColumn colBookSel2;
        private DevExpress.XtraEditors.TextEdit descriptionTextEdit;
        private System.Windows.Forms.BindingSource BookComboBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colBookCombo_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription1;
        private DevExpress.XtraGrid.Columns.GridColumn colBookSel_Group;
        private DevExpress.XtraGrid.Columns.GridColumn colMustInclude;
        private DevExpress.XtraGrid.Columns.GridColumn colMustExclude;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colActive1;
        private DevExpress.XtraGrid.Columns.GridColumn colType1;
        private DevExpress.XtraGrid.Columns.GridColumn colCode1;
        private DevExpress.XtraGrid.Columns.GridColumn colCat1;
        private DevExpress.XtraGrid.Columns.GridColumn colSvcDate_Start1;
        private DevExpress.XtraGrid.Columns.GridColumn colSvcDate_End1;
        private DevExpress.XtraGrid.Columns.GridColumn colQuery1;
        private DevExpress.XtraGrid.Columns.GridColumn colDaysPriorToStart;
        private DevExpress.XtraGrid.Columns.GridColumn colDaysAfterStart;
        private DevExpress.XtraGrid.Columns.GridColumn colDaysPriorToEnd;
        private DevExpress.XtraGrid.Columns.GridColumn colDaysAfterEnd;
        private DevExpress.XtraGrid.Columns.GridColumn colAnyOverlap;
        private DevExpress.XtraGrid.Columns.GridColumn colRequiredNts;
        private DevExpress.XtraGrid.Columns.GridColumn colHotel_User_Txt2;
        private DevExpress.XtraGrid.Columns.GridColumn colCity1;
        private FlexControls.GridSearchControl codeSearch;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SimpleButton grdReqDel;
        private DevExpress.XtraEditors.SimpleButton grdReqAdd;
        private DevExpress.XtraEditors.SimpleButton grdSelDel;
        private DevExpress.XtraEditors.SimpleButton grdSelAdd;
        private DevExpress.XtraEditors.SimpleButton SaveChangesReq;
        private DevExpress.XtraEditors.SimpleButton SaveChangesSel;
        private DevExpress.XtraEditors.CheckEdit group_ActiveCheckEdit;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}