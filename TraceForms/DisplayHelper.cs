using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TraceForms
{
    public static class DisplayHelper
    {
        public static void DisplayError(this Form form, Exception ex)
        {
            string msg = ex.Message;
            if (ex.InnerException != null) {
                msg = msg.Replace("See the inner exception for details.", string.Empty);
                msg += Environment.NewLine + ex.InnerException.Message;
            }
            DisplayError(form, msg);
        }

        public static void DisplayError(this Form form, string error)
        {
            DisplayMessage(form, error, MessageBoxIcon.Error);
        }

        public static void DisplayInfo(this Form form, string message)
        {
            DisplayMessage(form, message, MessageBoxIcon.Information);
        }

        public static void DisplayWarning(this Form form, string message)
        {
            DisplayMessage(form, message, MessageBoxIcon.Warning);
        }

        public static void DisplayMessage(this Form form, string message, MessageBoxIcon icon)
        {
            form.Cursor = Cursors.Default;
            XtraMessageBox.Show(form, message, form.Text, MessageBoxButtons.OK, icon);
        }

        public static DialogResult QuestionYesNoCancel(this Form form, string message)
        {
            return Question(form, message, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }

        public static DialogResult QuestionYesNo(this Form form, string message)
        {
            return Question(form, message, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult Question(this Form form, string message, MessageBoxButtons buttons)
        {
            return Question(form, message, buttons, MessageBoxIcon.Question);
        }

        public static DialogResult Question(this Form form, string message, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            form.Cursor = Cursors.Default;
            return XtraMessageBox.Show(form, message, form.Text, buttons, icon);
        }
    }
}
