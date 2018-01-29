using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using DevExpress.XtraEditors;
using System.Text;
using System.Windows.Forms;
using FlexModel;
using System.Data.Entity.Core.Objects;
using System.Runtime.InteropServices;
namespace TraceForms
{
    
    public partial class IndexTab : XtraUserControl
    {

        public delegate void TabEventHandler(object sender,selectTab e);
        public event TabEventHandler tabHandler;
        public String letter;
        public IndexTab()
        {
            InitializeComponent();
        }
        public class selectTab
        {

        }
        private void labelClick(object sender, EventArgs e)
        {
            LabelControl label1 = (LabelControl)sender;
            letter = label1.Text;
            if (tabHandler != null)
                tabHandler(null,null);

        }
        private void labelhover(object sender, EventArgs e)
        {
            LabelControl label1 = (LabelControl)sender;

            label1.Font = new Font(label1.Font, FontStyle.Underline);
            label1.Cursor = Cursors.Hand;
        }

        private void labelLeave(object sender, EventArgs e)
        {
            LabelControl label1 = (LabelControl)sender;

            FontStyle fontStyle = label1.Font.Style;
            fontStyle &= FontStyle.Bold;
            fontStyle &= FontStyle.Italic;
            fontStyle &= FontStyle.Strikeout;
            fontStyle &= FontStyle.Underline;


            label1.Font = new Font(label1.Font, fontStyle);
            label1.Cursor = Cursors.Arrow;
        }

        private void labelControl44_Click(object sender, EventArgs e)
        {
            panelControl1.Visible = false;
            panelControl2.Visible = true;
        }

        private void labelControl10_Click(object sender, EventArgs e)
        {
            panelControl2.Visible = false;
            panelControl1.Visible = true;
           
        }
        



    }


}
