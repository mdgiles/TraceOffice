namespace TraceForms
{
    partial class invtInq2Form
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
            this.typeComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.codeSearch = new FlexControls.GridSearchControl();
            this.catSearch = new FlexControls.GridSearchControl();
            this.roomComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.agencySearch = new FlexControls.GridSearchControl();
            this.startDateEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.endDateEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonSearch = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAGENCY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.InvtBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.simpleButtonClose = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonHelp = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.typeComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvtBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // typeComboBoxEdit
            // 
            this.typeComboBoxEdit.Location = new System.Drawing.Point(127, 12);
            this.typeComboBoxEdit.Name = "typeComboBoxEdit";
            this.typeComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.typeComboBoxEdit.Properties.Items.AddRange(new object[] {
            "AIR",
            "CRU",
            "HTL",
            "OPT",
            "PKG"});
            this.typeComboBoxEdit.Size = new System.Drawing.Size(63, 20);
            this.typeComboBoxEdit.TabIndex = 0;
            this.typeComboBoxEdit.TextChanged += new System.EventHandler(this.typeComboBoxEdit_TextChanged);
            // 
            // codeSearch
            // 
            this.codeSearch.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.codeSearch.Appearance.Options.UseBackColor = true;
            this.codeSearch.AutoAdjustWidth = true;
            this.codeSearch.DisplayMember = null;
            this.codeSearch.EnterMoveNextControl = false;
            this.codeSearch.FilterOn = false;
            this.codeSearch.GridVisible = false;
            this.codeSearch.LastError = "";
            this.codeSearch.Location = new System.Drawing.Point(236, 12);
            this.codeSearch.LookupName = "value";
            this.codeSearch.MaxWidth = 500;
            this.codeSearch.MinWidth = 250;
            this.codeSearch.Name = "codeSearch";
            this.codeSearch.PromptOnChange = false;
            this.codeSearch.PromptText = "";
            this.codeSearch.ShowPopupNumberOfChars = 3;
            this.codeSearch.Size = new System.Drawing.Size(177, 28);
            this.codeSearch.TabIndex = 1;
            this.codeSearch.ValidateOnEnter = false;
            this.codeSearch.ValidateOnSelection = false;
            this.codeSearch.Value = "";
            this.codeSearch.ValueMember = null;
            this.codeSearch.ItemSelected += new FlexControls.GridSearchControl.ItemSelectedEventHandler(this.gridSearchControl1_ItemSelected);
            this.codeSearch.Enter += new System.EventHandler(this.gridSearchControl1_Enter);
            // 
            // catSearch
            // 
            this.catSearch.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.catSearch.Appearance.Options.UseBackColor = true;
            this.catSearch.AutoAdjustWidth = true;
            this.catSearch.DisplayMember = null;
            this.catSearch.EnterMoveNextControl = false;
            this.catSearch.FilterOn = false;
            this.catSearch.GridVisible = false;
            this.catSearch.LastError = "";
            this.catSearch.Location = new System.Drawing.Point(482, 12);
            this.catSearch.LookupName = "value";
            this.catSearch.MaxWidth = 500;
            this.catSearch.MinWidth = 250;
            this.catSearch.Name = "catSearch";
            this.catSearch.PromptOnChange = false;
            this.catSearch.PromptText = "";
            this.catSearch.ShowPopupNumberOfChars = 3;
            this.catSearch.Size = new System.Drawing.Size(177, 28);
            this.catSearch.TabIndex = 2;
            this.catSearch.ValidateOnEnter = false;
            this.catSearch.ValidateOnSelection = false;
            this.catSearch.Value = "";
            this.catSearch.ValueMember = null;
            this.catSearch.ItemSelected += new FlexControls.GridSearchControl.ItemSelectedEventHandler(this.gridSearchControl2_ItemSelected);
            this.catSearch.Enter += new System.EventHandler(this.gridSearchControl2_Enter);
            // 
            // roomComboBoxEdit
            // 
            this.roomComboBoxEdit.Location = new System.Drawing.Point(743, 11);
            this.roomComboBoxEdit.Name = "roomComboBoxEdit";
            this.roomComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.roomComboBoxEdit.Properties.Items.AddRange(new object[] {
            "DBL",
            "SGL",
            "TPL",
            "OTH",
            "QUA"});
            this.roomComboBoxEdit.Size = new System.Drawing.Size(100, 20);
            this.roomComboBoxEdit.TabIndex = 3;
            // 
            // agencySearch
            // 
            this.agencySearch.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.agencySearch.Appearance.Options.UseBackColor = true;
            this.agencySearch.AutoAdjustWidth = true;
            this.agencySearch.DisplayMember = null;
            this.agencySearch.EnterMoveNextControl = false;
            this.agencySearch.FilterOn = false;
            this.agencySearch.GridVisible = false;
            this.agencySearch.LastError = "";
            this.agencySearch.Location = new System.Drawing.Point(127, 55);
            this.agencySearch.LookupName = "value";
            this.agencySearch.MaxWidth = 500;
            this.agencySearch.MinWidth = 250;
            this.agencySearch.Name = "agencySearch";
            this.agencySearch.PromptOnChange = false;
            this.agencySearch.PromptText = "";
            this.agencySearch.ShowPopupNumberOfChars = 3;
            this.agencySearch.Size = new System.Drawing.Size(177, 28);
            this.agencySearch.TabIndex = 4;
            this.agencySearch.ValidateOnEnter = false;
            this.agencySearch.ValidateOnSelection = false;
            this.agencySearch.Value = "";
            this.agencySearch.ValueMember = null;
            this.agencySearch.ItemSelected += new FlexControls.GridSearchControl.ItemSelectedEventHandler(this.gridSearchControl3_ItemSelected);
            this.agencySearch.Enter += new System.EventHandler(this.gridSearchControl3_Enter);
            // 
            // startDateEdit
            // 
            this.startDateEdit.CausesValidation = false;
            this.startDateEdit.Location = new System.Drawing.Point(396, 55);
            this.startDateEdit.Name = "startDateEdit";
            this.startDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.startDateEdit.Size = new System.Drawing.Size(100, 20);
            this.startDateEdit.TabIndex = 5;
            this.startDateEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.startDateEdit_ButtonClick);
            this.startDateEdit.TextChanged += new System.EventHandler(this.startDateEdit_TextChanged);
            // 
            // endDateEdit
            // 
            this.endDateEdit.CausesValidation = false;
            this.endDateEdit.Location = new System.Drawing.Point(611, 55);
            this.endDateEdit.Name = "endDateEdit";
            this.endDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.endDateEdit.Size = new System.Drawing.Size(100, 20);
            this.endDateEdit.TabIndex = 6;
            this.endDateEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.endDateEdit_ButtonClick);
            this.endDateEdit.TextChanged += new System.EventHandler(this.endDateEdit_TextChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(89, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 13);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Type";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(203, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(25, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Code";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(423, 14);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(45, 13);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "Category";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(674, 14);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(58, 13);
            this.labelControl4.TabIndex = 10;
            this.labelControl4.Text = "Room/Cabin";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(84, 58);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 13);
            this.labelControl5.TabIndex = 11;
            this.labelControl5.Text = "Agency";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(322, 58);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(64, 13);
            this.labelControl6.TabIndex = 12;
            this.labelControl6.Text = "Starting Date";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(542, 58);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(58, 13);
            this.labelControl7.TabIndex = 13;
            this.labelControl7.Text = "Ending Date";
            // 
            // simpleButtonSearch
            // 
            this.simpleButtonSearch.Location = new System.Drawing.Point(261, 90);
            this.simpleButtonSearch.Name = "simpleButtonSearch";
            this.simpleButtonSearch.Size = new System.Drawing.Size(99, 30);
            this.simpleButtonSearch.TabIndex = 14;
            this.simpleButtonSearch.Text = "Search";
            this.simpleButtonSearch.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 136);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(950, 512);
            this.gridControl1.TabIndex = 15;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAGENCY});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView1_CustomUnboundColumnData);
            // 
            // colAGENCY
            // 
            this.colAGENCY.AppearanceCell.BackColor = System.Drawing.Color.LightGray;
            this.colAGENCY.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colAGENCY.AppearanceCell.Options.UseBackColor = true;
            this.colAGENCY.AppearanceCell.Options.UseFont = true;
            this.colAGENCY.Caption = "AGENCIES:";
            this.colAGENCY.FieldName = "AGENCY";
            this.colAGENCY.MaxWidth = 200;
            this.colAGENCY.Name = "colAGENCY";
            this.colAGENCY.OptionsColumn.AllowEdit = false;
            this.colAGENCY.OptionsColumn.ReadOnly = true;
            this.colAGENCY.Visible = true;
            this.colAGENCY.VisibleIndex = 0;
            // 
            // InvtBindingSource
            // 
            this.InvtBindingSource.DataSource = typeof(FlexModel.INVT);
            // 
            // simpleButtonClose
            // 
            this.simpleButtonClose.Location = new System.Drawing.Point(384, 90);
            this.simpleButtonClose.Name = "simpleButtonClose";
            this.simpleButtonClose.Size = new System.Drawing.Size(99, 30);
            this.simpleButtonClose.TabIndex = 17;
            this.simpleButtonClose.Text = "Close";
            this.simpleButtonClose.Click += new System.EventHandler(this.simpleButtonClose_Click);
            // 
            // simpleButtonHelp
            // 
            this.simpleButtonHelp.Location = new System.Drawing.Point(501, 90);
            this.simpleButtonHelp.Name = "simpleButtonHelp";
            this.simpleButtonHelp.Size = new System.Drawing.Size(99, 30);
            this.simpleButtonHelp.TabIndex = 18;
            this.simpleButtonHelp.Text = "Help";
            this.simpleButtonHelp.Visible = false;
            // 
            // invtInq2Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(992, 678);
            this.Controls.Add(this.simpleButtonHelp);
            this.Controls.Add(this.simpleButtonClose);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.simpleButtonSearch);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.endDateEdit);
            this.Controls.Add(this.startDateEdit);
            this.Controls.Add(this.agencySearch);
            this.Controls.Add(this.roomComboBoxEdit);
            this.Controls.Add(this.catSearch);
            this.Controls.Add(this.codeSearch);
            this.Controls.Add(this.typeComboBoxEdit);
            this.MinimizeBox = false;
            this.Name = "invtInq2Form";
            this.ShowInTaskbar = false;
            this.Text = "invtInq2Form";
            ((System.ComponentModel.ISupportInitialize)(this.typeComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvtBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit typeComboBoxEdit;
        private FlexControls.GridSearchControl codeSearch;
        private FlexControls.GridSearchControl catSearch;
        private DevExpress.XtraEditors.ComboBoxEdit roomComboBoxEdit;
        private FlexControls.GridSearchControl agencySearch;
        private DevExpress.XtraEditors.ButtonEdit startDateEdit;
        private DevExpress.XtraEditors.ButtonEdit endDateEdit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSearch;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource InvtBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colAGENCY;
        private DevExpress.XtraEditors.SimpleButton simpleButtonClose;
        private DevExpress.XtraEditors.SimpleButton simpleButtonHelp;
    }
}