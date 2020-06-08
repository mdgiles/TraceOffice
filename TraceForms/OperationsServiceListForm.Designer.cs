namespace TraceForms
{
    partial class OperationsServiceListForm
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
            this.buttonSend = new DevExpress.XtraEditors.SimpleButton();
            this.textBoxRecipients = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.labelStatus = new DevExpress.XtraEditors.LabelControl();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.dateEditStart = new DevExpress.XtraEditors.DateEdit();
            this.dateEditEnd = new DevExpress.XtraEditors.DateEdit();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.radioGroupDate = new DevExpress.XtraEditors.RadioGroup();
            this.searchLookUpEditOperator = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.bindingSourceCodeName = new System.Windows.Forms.BindingSource(this.components);
            this.searchLookUpEdit2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.searchLookUpEditHotel = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.searchLookUpEditService = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.checkEditIncludeCancelled = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxRecipients.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEditOperator.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCodeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit2View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEditHotel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEditService.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditIncludeCancelled.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(33, 232);
            this.buttonSend.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(102, 32);
            this.buttonSend.TabIndex = 6;
            this.buttonSend.Text = "&Send Report";
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxRecipients
            // 
            this.textBoxRecipients.Location = new System.Drawing.Point(33, 202);
            this.textBoxRecipients.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxRecipients.Name = "textBoxRecipients";
            this.textBoxRecipients.Size = new System.Drawing.Size(389, 20);
            this.textBoxRecipients.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(30, 187);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Recipient email address. Separate multiple addresses by a comma.";
            // 
            // labelStatus
            // 
            this.labelStatus.Location = new System.Drawing.Point(139, 242);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(2);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 13);
            this.labelStatus.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(33, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Start date";
            // 
            // dateEditStart
            // 
            this.dateEditStart.EditValue = null;
            this.dateEditStart.Location = new System.Drawing.Point(91, 27);
            this.dateEditStart.Margin = new System.Windows.Forms.Padding(2);
            this.dateEditStart.Name = "dateEditStart";
            this.dateEditStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditStart.Properties.DisplayFormat.FormatString = "MM/dd/yyyy";
            this.dateEditStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditStart.Properties.EditFormat.FormatString = "MM/dd/yyyy";
            this.dateEditStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditStart.Properties.Mask.EditMask = "MM/dd/yyyy";
            this.dateEditStart.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateEditStart.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateEditStart.Size = new System.Drawing.Size(131, 20);
            this.dateEditStart.TabIndex = 1;
            // 
            // dateEditEnd
            // 
            this.dateEditEnd.EditValue = null;
            this.dateEditEnd.Location = new System.Drawing.Point(91, 54);
            this.dateEditEnd.Margin = new System.Windows.Forms.Padding(2);
            this.dateEditEnd.Name = "dateEditEnd";
            this.dateEditEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditEnd.Properties.DisplayFormat.FormatString = "MM/dd/yyyy";
            this.dateEditEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditEnd.Properties.EditFormat.FormatString = "MM/dd/yyyy";
            this.dateEditEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditEnd.Properties.Mask.EditMask = "MM/dd/yyyy";
            this.dateEditEnd.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateEditEnd.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateEditEnd.Size = new System.Drawing.Size(131, 20);
            this.dateEditEnd.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(33, 56);
            this.label3.Margin = new System.Windows.Forms.Padding(2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "End date";
            // 
            // radioGroupDate
            // 
            this.radioGroupDate.EditValue = "strt date";
            this.radioGroupDate.Location = new System.Drawing.Point(33, 78);
            this.radioGroupDate.Margin = new System.Windows.Forms.Padding(2);
            this.radioGroupDate.Name = "radioGroupDate";
            this.radioGroupDate.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroupDate.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroupDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroupDate.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("strt date", "By Service Date", true, "service"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("res date", "By Booking Date", true, "booking")});
            this.radioGroupDate.Size = new System.Drawing.Size(223, 23);
            this.radioGroupDate.TabIndex = 9;
            this.radioGroupDate.EditValueChanged += new System.EventHandler(this.radioGroupDate_EditValueChanged);
            // 
            // searchLookUpEditOperator
            // 
            this.searchLookUpEditOperator.Location = new System.Drawing.Point(91, 107);
            this.searchLookUpEditOperator.Name = "searchLookUpEditOperator";
            this.searchLookUpEditOperator.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.searchLookUpEditOperator.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpEditOperator.Properties.DataSource = this.bindingSourceCodeName;
            this.searchLookUpEditOperator.Properties.DisplayMember = "DisplayName";
            this.searchLookUpEditOperator.Properties.NullText = "<all>";
            this.searchLookUpEditOperator.Properties.PopupView = this.searchLookUpEdit2View;
            this.searchLookUpEditOperator.Properties.ValueMember = "Code";
            this.searchLookUpEditOperator.Size = new System.Drawing.Size(392, 20);
            this.searchLookUpEditOperator.TabIndex = 11;
            this.searchLookUpEditOperator.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            this.searchLookUpEditOperator.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.LookupEdit_QueryPopUp);
            this.searchLookUpEditOperator.EditValueChanged += new System.EventHandler(this.searchLookUpEditOperator_EditValueChanged);
            // 
            // bindingSourceCodeName
            // 
            this.bindingSourceCodeName.DataSource = typeof(TraceForms.CodeName);
            // 
            // searchLookUpEdit2View
            // 
            this.searchLookUpEdit2View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colName});
            this.searchLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit2View.Name = "searchLookUpEdit2View";
            this.searchLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit2View.OptionsView.ShowGroupPanel = false;
            this.searchLookUpEdit2View.OptionsView.ShowIndicator = false;
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
            // searchLookUpEditHotel
            // 
            this.searchLookUpEditHotel.Location = new System.Drawing.Point(91, 133);
            this.searchLookUpEditHotel.Name = "searchLookUpEditHotel";
            this.searchLookUpEditHotel.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.searchLookUpEditHotel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpEditHotel.Properties.DataSource = this.bindingSourceCodeName;
            this.searchLookUpEditHotel.Properties.DisplayMember = "DisplayName";
            this.searchLookUpEditHotel.Properties.NullText = "<all>";
            this.searchLookUpEditHotel.Properties.PopupView = this.gridView1;
            this.searchLookUpEditHotel.Properties.ValueMember = "Code";
            this.searchLookUpEditHotel.Size = new System.Drawing.Size(392, 20);
            this.searchLookUpEditHotel.TabIndex = 12;
            this.searchLookUpEditHotel.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            this.searchLookUpEditHotel.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.LookupEdit_QueryPopUp);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "Code";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // searchLookUpEditService
            // 
            this.searchLookUpEditService.Location = new System.Drawing.Point(91, 159);
            this.searchLookUpEditService.Name = "searchLookUpEditService";
            this.searchLookUpEditService.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.searchLookUpEditService.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpEditService.Properties.DataSource = this.bindingSourceCodeName;
            this.searchLookUpEditService.Properties.DisplayMember = "DisplayName";
            this.searchLookUpEditService.Properties.NullText = "<all>";
            this.searchLookUpEditService.Properties.PopupView = this.gridView2;
            this.searchLookUpEditService.Properties.ValueMember = "Code";
            this.searchLookUpEditService.Size = new System.Drawing.Size(392, 20);
            this.searchLookUpEditService.TabIndex = 13;
            this.searchLookUpEditService.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            this.searchLookUpEditService.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.LookupEdit_QueryPopUp);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.FieldName = "Code";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.FieldName = "Name";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(33, 110);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(44, 13);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "Operator";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(33, 136);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(25, 13);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Text = "Hotel";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(33, 162);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(35, 13);
            this.labelControl3.TabIndex = 16;
            this.labelControl3.Text = "Service";
            // 
            // checkEditIncludeCancelled
            // 
            this.checkEditIncludeCancelled.Location = new System.Drawing.Point(261, 80);
            this.checkEditIncludeCancelled.Name = "checkEditIncludeCancelled";
            this.checkEditIncludeCancelled.Properties.Caption = "Include cancelled bookings";
            this.checkEditIncludeCancelled.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.checkEditIncludeCancelled.Size = new System.Drawing.Size(161, 19);
            this.checkEditIncludeCancelled.TabIndex = 17;
            // 
            // OperationsServiceListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 311);
            this.Controls.Add(this.checkEditIncludeCancelled);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.searchLookUpEditService);
            this.Controls.Add(this.searchLookUpEditHotel);
            this.Controls.Add(this.searchLookUpEditOperator);
            this.Controls.Add(this.radioGroupDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateEditEnd);
            this.Controls.Add(this.dateEditStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxRecipients);
            this.Controls.Add(this.buttonSend);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OperationsServiceListForm";
            this.ShowInTaskbar = false;
            this.Text = "Generate Operations Service List";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OperationsServiceListForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.textBoxRecipients.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEditOperator.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCodeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit2View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEditHotel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEditService.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditIncludeCancelled.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		private DevExpress.XtraEditors.SimpleButton buttonSend;
		private DevExpress.XtraEditors.TextEdit textBoxRecipients;
		private DevExpress.XtraEditors.LabelControl label1;
		private DevExpress.XtraEditors.LabelControl labelStatus;
		private DevExpress.XtraEditors.LabelControl label2;
        private DevExpress.XtraEditors.DateEdit dateEditStart;
        private DevExpress.XtraEditors.DateEdit dateEditEnd;
        private DevExpress.XtraEditors.LabelControl label3;
        private DevExpress.XtraEditors.RadioGroup radioGroupDate;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpEditOperator;
        private System.Windows.Forms.BindingSource bindingSourceCodeName;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit2View;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpEditHotel;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpEditService;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.CheckEdit checkEditIncludeCancelled;
    }
}

