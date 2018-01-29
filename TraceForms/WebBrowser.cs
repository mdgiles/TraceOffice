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
    
    public partial class WebBrowser : DevExpress.XtraEditors.XtraForm
    {
        public WebBrowser(System.Uri url)
        {
            
            InitializeComponent();
            this.webBrowser1.Url = url;
        }

        private void WebBrowser_Load(object sender, EventArgs e)
        {
            
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}