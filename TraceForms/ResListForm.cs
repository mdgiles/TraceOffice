using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FlexModel;
using System.Runtime.InteropServices;
namespace TraceForms
{
    
    public partial class ResListForm : DevExpress.XtraEditors.XtraForm
    {
        public string value;
        public FlextourEntities context;

        public ResListForm(string val, FlexCore.CoreSys _sys)
        {
            value = val;           
            InitializeComponent();
            Connection.EFConnectionString = _sys.Settings.EFConnectionString;
            context = new FlextourEntities(_sys.Settings.EFConnectionString);
            ResHdrBindingSource.DataSource = from c in context.RESHDR where c.AGY_NO.Trim() == value && c.Inactive != true select c;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            

          //  xform.setResNo(gridView1.GetFocusedRowCellValue(colRES_NO).ToString());     


            

            MessageBox.Show(gridView1.GetFocusedRowCellValue(colRES_NO).ToString());
            
        }
    }
}