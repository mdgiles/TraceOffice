using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FlexModel;
using System.Runtime.InteropServices;
namespace TraceForms
{
    
    public partial class VouchUtilityForm : DevExpress.XtraEditors.XtraForm
    {
        public FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public VouchUtilityForm(FlexCore.CoreSys _sys)
        {
            InitializeComponent();
            Connection.EFConnectionString = _sys.Settings.EFConnectionString;
            context = new FlextourEntities(_sys.Settings.EFConnectionString);
        }

        private void XtraForm1_Load(object sender, EventArgs e)
        {
            VoucherBindingSource.DataSource = context.VOUCHER;
        }

    

        private void startDateDateEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void startDateDateEdit_TextChanged(object sender, EventArgs e)
        {
            startDateDateEdit.Text = validCheck.convertDate(startDateDateEdit.Text);
        }

        private void origExpDateDateEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void origExpDateDateEdit_TextChanged(object sender, EventArgs e)
        {
            origExpDateDateEdit.Text = validCheck.convertDate(origExpDateDateEdit.Text);
        }

        private void expDateDateEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void expDateDateEdit_TextChanged(object sender, EventArgs e)
        {
            expDateDateEdit.Text = validCheck.convertDate(expDateDateEdit.Text);
        }

        private void printDateDateEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void printDateDateEdit_TextChanged(object sender, EventArgs e)
        {
            printDateDateEdit.Text = validCheck.convertDate(printDateDateEdit.Text);
        }

        private void chgDateDateEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void chgDateDateEdit_TextChanged(object sender, EventArgs e)
        {
            chgDateDateEdit.Text = validCheck.convertDate(chgDateDateEdit.Text);
        }

        private void VouchUtilityForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (modified || newRec)
            //{
            //    DialogResult select = DevExpress.XtraEditors.XtraMessageBox.Show("There are unsaved changes. Are you sure want to exit?", Name, MessageBoxButtons.YesNo);
            //    if (select == DialogResult.Yes)
            //    {
            //        e.Cancel = false;
            //        this.Dispose();
            //    }
            //    else if (select == DialogResult.No)
            //        e.Cancel = true;
            //}
            //else
            //{
            //    e.Cancel = false;
            //    this.Dispose();
            //}
        }

        
    }
}