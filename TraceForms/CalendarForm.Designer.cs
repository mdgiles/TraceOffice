namespace TraceForms
{
    partial class CalendarForm
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
            this.cmdOk = new DevExpress.XtraEditors.SimpleButton();
            this.cmdCxl = new DevExpress.XtraEditors.SimpleButton();
            this.cmdToday = new DevExpress.XtraEditors.SimpleButton();
            this.dateNavigator1 = new DevExpress.XtraScheduler.DateNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(146, 289);
            this.cmdOk.Margin = new System.Windows.Forms.Padding(4);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(112, 32);
            this.cmdOk.TabIndex = 1;
            this.cmdOk.Text = "OK";
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // cmdCxl
            // 
            this.cmdCxl.Location = new System.Drawing.Point(268, 289);
            this.cmdCxl.Margin = new System.Windows.Forms.Padding(4);
            this.cmdCxl.Name = "cmdCxl";
            this.cmdCxl.Size = new System.Drawing.Size(112, 32);
            this.cmdCxl.TabIndex = 2;
            this.cmdCxl.Text = "Cancel";
            this.cmdCxl.Click += new System.EventHandler(this.cmdCxl_Click);
            // 
            // cmdToday
            // 
            this.cmdToday.Location = new System.Drawing.Point(389, 287);
            this.cmdToday.Margin = new System.Windows.Forms.Padding(4);
            this.cmdToday.Name = "cmdToday";
            this.cmdToday.Size = new System.Drawing.Size(112, 32);
            this.cmdToday.TabIndex = 3;
            this.cmdToday.Text = "Today";
            this.cmdToday.Click += new System.EventHandler(this.cmdToday_Click);
            // 
            // dateNavigator1
            // 
            this.dateNavigator1.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.False;
            this.dateNavigator1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNavigator1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dateNavigator1.DateTime = new System.DateTime(((long)(0)));
            this.dateNavigator1.EditValue = new System.DateTime(((long)(0)));
            this.dateNavigator1.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.dateNavigator1.InactiveDaysVisibility = DevExpress.XtraEditors.Controls.CalendarInactiveDaysVisibility.Hidden;
            this.dateNavigator1.Location = new System.Drawing.Point(-1, 1);
            this.dateNavigator1.Margin = new System.Windows.Forms.Padding(4);
            this.dateNavigator1.Name = "dateNavigator1";
            this.dateNavigator1.Padding = new System.Windows.Forms.Padding(0);
            this.dateNavigator1.ShowTodayButton = false;
            this.dateNavigator1.ShowWeekNumbers = false;
            this.dateNavigator1.Size = new System.Drawing.Size(648, 278);
            this.dateNavigator1.TabIndex = 0;
            this.dateNavigator1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dateNavigator1_MouseDoubleClick);
            // 
            // CalendarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 334);
            this.Controls.Add(this.cmdToday);
            this.Controls.Add(this.cmdCxl);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.dateNavigator1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeBox = false;
            this.Name = "CalendarForm";
            this.ShowInTaskbar = false;
            this.Text = "CalendarForm";
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraScheduler.DateNavigator dateNavigator1;
        private DevExpress.XtraEditors.SimpleButton cmdOk;
        private DevExpress.XtraEditors.SimpleButton cmdCxl;
        private DevExpress.XtraEditors.SimpleButton cmdToday;
    }
}