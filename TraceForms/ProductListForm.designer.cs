namespace TraceForms
{
    partial class ProductListForm
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
            System.Windows.Forms.Label LabelLanguage;
            this.buttonSend = new DevExpress.XtraEditors.SimpleButton();
            this.textBoxRecipients = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.labelStatus = new DevExpress.XtraEditors.LabelControl();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.dateEditStart = new DevExpress.XtraEditors.DateEdit();
            this.dateEditEnd = new DevExpress.XtraEditors.DateEdit();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.ImageComboBoxEditLang = new DevExpress.XtraEditors.ImageComboBoxEdit();
            LabelLanguage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxRecipients.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditLang.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(63, 305);
            this.buttonSend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(170, 57);
            this.buttonSend.TabIndex = 6;
            this.buttonSend.Text = "&Send Report";
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxRecipients
            // 
            this.textBoxRecipients.Location = new System.Drawing.Point(63, 251);
            this.textBoxRecipients.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxRecipients.Name = "textBoxRecipients";
            this.textBoxRecipients.Size = new System.Drawing.Size(649, 32);
            this.textBoxRecipients.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(63, 220);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(561, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Recipient email address. Separate multiple addresses by a comma.";
            // 
            // labelStatus
            // 
            this.labelStatus.Location = new System.Drawing.Point(240, 322);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 23);
            this.labelStatus.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(64, 140);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Start date";
            // 
            // dateEditStart
            // 
            this.dateEditStart.EditValue = null;
            this.dateEditStart.Location = new System.Drawing.Point(159, 136);
            this.dateEditStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateEditStart.Name = "dateEditStart";
            this.dateEditStart.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
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
            this.dateEditStart.Size = new System.Drawing.Size(219, 32);
            this.dateEditStart.TabIndex = 1;
            // 
            // dateEditEnd
            // 
            this.dateEditEnd.EditValue = null;
            this.dateEditEnd.Location = new System.Drawing.Point(159, 176);
            this.dateEditEnd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateEditEnd.Name = "dateEditEnd";
            this.dateEditEnd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
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
            this.dateEditEnd.Size = new System.Drawing.Size(219, 32);
            this.dateEditEnd.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(64, 179);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "End date";
            // 
            // ImageComboBoxEditLang
            // 
            this.ImageComboBoxEditLang.Location = new System.Drawing.Point(159, 95);
            this.ImageComboBoxEditLang.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ImageComboBoxEditLang.Name = "ImageComboBoxEditLang";
            this.ImageComboBoxEditLang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ImageComboBoxEditLang.Size = new System.Drawing.Size(462, 32);
            this.ImageComboBoxEditLang.TabIndex = 9;
            // 
            // LabelLanguage
            // 
            LabelLanguage.AutoSize = true;
            LabelLanguage.Location = new System.Drawing.Point(60, 99);
            LabelLanguage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LabelLanguage.Name = "LabelLanguage";
            LabelLanguage.Size = new System.Drawing.Size(97, 24);
            LabelLanguage.TabIndex = 8;
            LabelLanguage.Text = "Language";
            // 
            // ProductListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 550);
            this.Controls.Add(this.ImageComboBoxEditLang);
            this.Controls.Add(LabelLanguage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateEditEnd);
            this.Controls.Add(this.dateEditStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxRecipients);
            this.Controls.Add(this.buttonSend);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductListForm";
            this.ShowInTaskbar = false;
            this.Text = "Generate Product List";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProductListForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.textBoxRecipients.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditLang.Properties)).EndInit();
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
        private DevExpress.XtraEditors.ImageComboBoxEdit ImageComboBoxEditLang;
    }
}

