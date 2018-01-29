using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace TraceForms
{
    public partial class CalendarForm : DevExpress.XtraEditors.XtraForm
    {
        public DevExpress.XtraEditors.ButtonEdit textBox1;
        public CalendarForm(object textbox)
        {
            InitializeComponent();
            textBox1 = (DevExpress.XtraEditors.ButtonEdit)textbox;
            DateTime val;

            if (!string.IsNullOrWhiteSpace(textBox1.Text) && DateTime.TryParse(textBox1.Text, out val))
            {
                DateTime startDate = Convert.ToDateTime(validCheck.convertDate(textBox1.Text));
                dateNavigator1.DateTime = startDate;
            }
            else
                dateNavigator1.DateTime = DateTime.Today;

        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            //ok
            textBox1.Text = dateNavigator1.DateTime.ToString();
            this.Close();
            
        }

        private void cmdCxl_Click(object sender, EventArgs e)
        {
            //cancel
            this.Close();
        }

        private void cmdToday_Click(object sender, EventArgs e)
        {
            //today
            textBox1.Text = DateTime.Today.ToString();
            this.Close();

        }

        private void dateNavigator1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Y > 40)
            {
                textBox1.Text = dateNavigator1.DateTime.ToString();
                this.Close();
            }
        }

     
    }
//    public class MyDateNavigator : DevExpress.XtraScheduler.DateNavigator
//    {
//        protected override DevExpress.XtraEditors.Drawing.DateEditPainter CreatePainter()
//        {
//            return new MyPainter(this);
//            //return base.CreatePainter();
//        }

//    }
//    class MyPainter : DevExpress.XtraEditors.Drawing.DateEditPainter
//    {
//        public MyPainter(DevExpress.XtraScheduler.DateNavigator nav) : base(nav) { }
//        protected override void DrawHeader(DevExpress.XtraEditors.Calendar.CalendarObjectInfoArgs info)
//        {
//            DevExpress.XtraEditors.ViewInfo.DateEditInfoArgs args = (DevExpress.XtraEditors.ViewInfo.DateEditInfoArgs)info;
//            args.ShowDecYear = false;
//            args.ShowIncYear = false;
//            args.ShowIncMonth = true;
//            args.ShowDecMonth = true;
//            args.IncYearButton.Enabled = false;
//            args.DecYearButton.Enabled = false;
//            base.DrawHeader(args);
//        }
//    }
//    //public class NewCalendar : DevExpress.XtraScheduler.DateNavigator
//    //{
//    //    protected override DevExpress.XtraEditors.Drawing.DateEditPainter CreatePainter()
//    //    {
//    //        return base.CreatePainter();
//    //    }

//    //    protected override DevExpress.XtraEditors.ViewInfo.DateEditInfoArgs CreateInfoArgs()
//    //    {
//    //        return base.CreateInfoArgs();
//    //    }
        
//    //}
}