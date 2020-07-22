namespace TraceForms
{
    partial class HotelProductionReportForm
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
            if (disposing && (components != null)) {
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
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.dateEditEnd = new DevExpress.XtraEditors.DateEdit();
            this.dateEditStart = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.labelStatus = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.textBoxRecipients = new DevExpress.XtraEditors.TextEdit();
            this.buttonSend = new DevExpress.XtraEditors.SimpleButton();
            this.radioGroupDate = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxRecipients.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(51, 101);
            this.label3.Margin = new System.Windows.Forms.Padding(2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "End date";
            // 
            // dateEditEnd
            // 
            this.dateEditEnd.EditValue = null;
            this.dateEditEnd.Location = new System.Drawing.Point(108, 99);
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
            this.dateEditEnd.TabIndex = 11;
            // 
            // dateEditStart
            // 
            this.dateEditStart.EditValue = null;
            this.dateEditStart.Location = new System.Drawing.Point(108, 71);
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
            this.dateEditStart.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(51, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Start date";
            // 
            // labelStatus
            // 
            this.labelStatus.Location = new System.Drawing.Point(159, 207);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(2);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 13);
            this.labelStatus.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(51, 152);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Recipient email address. Separate multiple addresses by a comma.";
            // 
            // textBoxRecipients
            // 
            this.textBoxRecipients.Location = new System.Drawing.Point(51, 169);
            this.textBoxRecipients.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxRecipients.Name = "textBoxRecipients";
            this.textBoxRecipients.Size = new System.Drawing.Size(389, 20);
            this.textBoxRecipients.TabIndex = 13;
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(53, 198);
            this.buttonSend.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(102, 32);
            this.buttonSend.TabIndex = 14;
            this.buttonSend.Text = "&Send Report";
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // radioGroupDate
            // 
            this.radioGroupDate.EditValue = "strt date";
            this.radioGroupDate.Location = new System.Drawing.Point(51, 125);
            this.radioGroupDate.Margin = new System.Windows.Forms.Padding(2);
            this.radioGroupDate.Name = "radioGroupDate";
            this.radioGroupDate.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroupDate.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroupDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroupDate.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("strt date", "By Service Date", true, "service"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("res date", "By Booking Date", true, "booking")});
            this.radioGroupDate.Size = new System.Drawing.Size(223, 23);
            this.radioGroupDate.TabIndex = 16;
            this.radioGroupDate.EditValueChanged += new System.EventHandler(this.radioGroupDate_EditValueChanged);
            // 
            // HotelProductionReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 286);
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
            this.Name = "HotelProductionReportForm";
            this.ShowInTaskbar = false;
            this.Text = "Hotel Production Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HotelProductionReportForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxRecipients.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupDate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl label3;
        private DevExpress.XtraEditors.DateEdit dateEditEnd;
        private DevExpress.XtraEditors.DateEdit dateEditStart;
        private DevExpress.XtraEditors.LabelControl label2;
        private DevExpress.XtraEditors.LabelControl labelStatus;
        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.TextEdit textBoxRecipients;
        private DevExpress.XtraEditors.SimpleButton buttonSend;
        private DevExpress.XtraEditors.RadioGroup radioGroupDate;
    }
}