using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TraceForms
{
    static class gsLoad
    {
        public static void gridSearchLoad(FlexControls.GridSearchControl control, string field1, string field2, string cap1, string cap2, string disp, string value, string look, System.Windows.Forms.BindingSource source, string bind)
        {            
            control.GridView.Columns.Clear();
            control.ButtonEdit.DataBindings.Clear();
            var col = control.GridView.Columns.Add();
            col.FieldName = field1;
            col.Caption = cap1;
            col.Visible = true;
            if (!String.IsNullOrEmpty(field2))
            {
                var col1 = control.GridView.Columns.Add();
                col1.FieldName = field2;
                col1.Caption = cap2;
                col1.Visible = !String.IsNullOrEmpty(cap2);
            }
            control.ValidateOnEnter = true;
            control.ValidateOnSelection = true;
            control.DisplayMember = disp.TrimEnd();
            control.ValueMember = value.TrimEnd();
            control.LookupName = look.TrimEnd();
            control.ShowPopupNumberOfChars = 1;
            control.ButtonEdit.DataBindings.Add("EditValue", source, bind);
            control.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
            control.ButtonEdit.TextChanged += ButtonEdit_TextChanged;
        }

        public static void ButtonEdit_TextChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit lol = sender as DevExpress.XtraEditors.ButtonEdit;
            lol.Text = lol.Text.ToUpper();           
        }

        public static void ButtonEdit_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }

        public static void gridSearchLoad(FlexControls.GridSearchControl control, string field1, string cap1, string disp, string value, string look, System.Windows.Forms.BindingSource source, string bind)
        {
            control.GridView.Columns.Clear();
            var col = control.GridView.Columns.Add();
            col.FieldName = field1;
            col.Caption = cap1;
            col.Visible = true;
            control.ValidateOnEnter = true;
            control.ValidateOnSelection = true;
            control.DisplayMember = disp;
            control.ValueMember = value;
            control.LookupName = look;
            control.ShowPopupNumberOfChars = 1;
            control.ButtonEdit.DataBindings.Add("EditValue", source, bind);
            control.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
            control.ButtonEdit.TextChanged += ButtonEdit_TextChanged;
        }
        public static void gridSearchLoad(FlexControls.GridSearchControl control, string field1, string field2, string cap1, string cap2, string disp, string value, string look)
        {
            control.GridView.Columns.Clear();
            control.ButtonEdit.DataBindings.Clear();
            var col = control.GridView.Columns.Add();
            col.FieldName = field1;
            col.Caption = cap1;
            col.Visible = true;
            var col1 = control.GridView.Columns.Add();
            col1.FieldName = field2;
            col1.Caption = cap2;
            col1.Visible = true;
            control.ValidateOnEnter = true;
            control.ValidateOnSelection = true;
            control.DisplayMember = disp;
            control.ValueMember = value;
            control.LookupName = look;
            control.ShowPopupNumberOfChars = 1;            
            control.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
            control.ButtonEdit.TextChanged += ButtonEdit_TextChanged;
        }
        public static void gridSearchLoad(FlexControls.GridSearchControl control, string field1, string cap1, string disp, string value, string look)
        {
            control.GridView.Columns.Clear();
            var col = control.GridView.Columns.Add();
            col.FieldName = field1;
            col.Caption = cap1;
            col.Visible = true;
            control.ValidateOnEnter = true;
            control.ValidateOnSelection = true;
            control.DisplayMember = disp;
            control.ValueMember = value;
            control.LookupName = look;
            control.ShowPopupNumberOfChars = 1;            
            control.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
           
        }
    }

}
