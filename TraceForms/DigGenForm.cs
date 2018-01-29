using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Runtime.InteropServices;
namespace TraceForms
{
    
    public partial class DigGenForm : DevExpress.XtraEditors.XtraForm
    {
        public DigGenForm()
        {
            InitializeComponent();
        }

        private void linkColOk_Click(object sender, EventArgs e)
        {
            popupContainerControl1.OwnerEdit.ClosePopup();
        }

        private void DigGenForm_FormClosing(object sender, FormClosingEventArgs e)
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