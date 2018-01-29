using System.Collections.Generic;
using FlexModel;
using System.Linq;
using System;
using System.ComponentModel;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Drawing;
using System.Collections;
using DevExpress.Xpo;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Runtime.InteropServices;
namespace TraceForms
{
    
    public partial class InvtRecForm : DevExpress.XtraEditors.XtraForm
    {
        public string defRoom = "";
        public string defCat = "";
        public string defAgy = "";
        public FlextourEntities context;
        public InvtRecForm(FlexCore.CoreSys _sys)
        {
            InitializeComponent();
            Connection.EFConnectionString = _sys.Settings.EFConnectionString;
            context = new FlextourEntities(_sys.Settings.EFConnectionString);
            gsLoad.gridSearchLoad(codeSearch, "CODE", "NAME", "Code", "Name", "CODE", "CODE", "CODE");
            gsLoad.gridSearchLoad(catSearch, "CODE", "DESC", "Code", "Name", "CODE", "CODE", "CODE");
            gsLoad.gridSearchLoad(agencySearch, "NO", "NAME", "Code", "Name", "NO", "NO", "NO");
            agencySearch.GridControl.DataSource = from c in context.AGY select new { c.NO, c.NAME };
            catSearch.GridControl.DataSource = from c in context.ROOMCOD select new { c.CODE, c.DESC };          
            //iNVT2BindingSource.DataSource = context.INVT2;
            //gridControl1.DataSource = from c in context.INVT2 where c.CODE == codeSearch.Text.TrimEnd() && c.CAT == "KJM" select c;
        
        }

        private void searchInvRec_Click(object sender, EventArgs e)
        {
            while (iNVT2BindingSource.Count > 0)
                iNVT2BindingSource.RemoveCurrent();
            context.SaveChanges();
            string query = String.Empty;
            DateTime dateOne = Convert.ToDateTime(dateEdit1.Text);
            DateTime dateTwo = Convert.ToDateTime(dateEdit2.Text);
            query = String.Format("it.{0} like '{1}%'", "CODE", codeSearch.Text);
            var LinvtMatches = context.INVT.Where(s => s.CODE == codeSearch.Text);
            var invtMatches = context.INVT.Where(query);
                      //        where c.TYPE == typeComboBoxEdit.Text && c.CODE == codeSearch.Text.TrimEnd() && c.DATE >= dateOne && c.DATE <= dateTwo
                     //         select c;
            if (!string.IsNullOrWhiteSpace(catSearch.Text))
            {
                query = String.Format("it.{0} like '{1}%'", "CAT", catSearch.Text);
                invtMatches = invtMatches.Where(query);
            }
            if (!string.IsNullOrWhiteSpace(agencySearch.Text))
            {
                query = String.Format("it.{0} like '{1}%'", "AGENCY", agencySearch.Text);
                invtMatches = invtMatches.Where(query);
            }
            if (!string.IsNullOrWhiteSpace(tpComboBoxEdit.Text))
            {
                query = String.Format("it.{0} like '{1}%'", "TP", tpComboBoxEdit.Text);
                invtMatches = invtMatches.Where(query);
            }
            if (!string.IsNullOrWhiteSpace(dateEdit1.Text))
            {              
                 LinvtMatches = invtMatches.Where(s => s.DATE >= dateOne);
            }
            if (!string.IsNullOrWhiteSpace(dateEdit2.Text))
            {              
                 LinvtMatches = invtMatches.Where(s => s.DATE <= dateTwo);
            }
           
            //
                          //        && c.CAT == catSearch.Text.TrimEnd() && c.AGENCY == agencySearch.Text.TrimEnd() && c.TP == tpComboBoxEdit.Text

            foreach (var values in LinvtMatches)
            {
                if (Convert.ToString(checkEdit1.OldEditValue) == "badOnly" && ((values.AV_AMT.Value + values.ALLOCTD.Value != values.ORIG_AMT.Value) || (values.ALLOCTD.Value != values.AV_AMT.Value) || (Convert.ToString(checkEdit1.OldEditValue) != "badOnly")))
                {
                    //load grid with invtMatrches
                    var resItmMatches = from c in context.RESITM
                                        where c.TYPE == typeComboBoxEdit.Text && c.Inactive == false && (c.Status == "R" || c.Status == " " || c.Status == "O" || c.Status == null)
                                        && c.CAT == catSearch.Text.TrimEnd() && c.AGENCY == agencySearch.Text.TrimEnd() && c.STRT_DATE <= values.DATE
                                        &&  c.CODE == codeSearch.Text.TrimEnd()
                                        select c;
                    //c.STRT_DATE.Value.AddDays(c.NBR_NIGHTS.Value - 1) >= values.DATE &&
                    if (resItmMatches.Count() == 0)
                    {
                        gridView1.AddNewRow();
                        gridView1.SetFocusedRowCellValue("TYPE", typeComboBoxEdit.Text);
                        gridView1.SetFocusedRowCellValue("CODE", values.CODE);
                        gridView1.SetFocusedRowCellValue("CAT", values.CAT);
                        gridView1.SetFocusedRowCellValue("AGENCY", values.AGENCY);
                        gridView1.SetFocusedRowCellValue("TP", values.TP);
                        gridView1.SetFocusedRowCellValue("DATE", values.DATE);
                        gridView1.SetFocusedRowCellValue("ALLOCTD", values.ALLOCTD);
                        gridView1.SetFocusedRowCellValue("AV_AMT", values.AV_AMT);
                    }
                }
            }

            var resMatches = from c in context.RESITM
                             where c.TYPE == typeComboBoxEdit.Text && c.Inactive == false && (c.Status == "R" || c.Status == " " || c.Status == "O")
                             && c.STRT_DATE >= dateOne && c.STRT_DATE <= dateTwo && c.CAT == catSearch.Text.TrimEnd()
                             && c.AGENCY == agencySearch.Text.TrimEnd() && c.CODE == codeSearch.Text.TrimEnd()
                             select c;
            foreach (var results in resMatches)
            {
                if (results.AGY_INVT.Length != 0)
                {
                    if (string.IsNullOrWhiteSpace(results.Status) || results.Status == "R" || results.Status == "O")
                    {
                        gridView1.AddNewRow();
                        gridView1.SetFocusedRowCellValue("TYPE", typeComboBoxEdit.Text);
                        gridView1.SetFocusedRowCellValue("CODE", results.CODE);
                        gridView1.SetFocusedRowCellValue("CAT", results.CAT);
                        gridView1.SetFocusedRowCellValue("AGENCY", results.AGENCY );
                        if(defRoom.Length > 0)
                            gridView1.SetFocusedRowCellValue("TP", defRoom);
                        else
                            gridView1.SetFocusedRowCellValue("TP", results.RMCABIN);

                        DateTime D = results.STRT_DATE.Value;
                        gridView1.SetFocusedRowCellValue("DATE", D);
                        int avAmt = 0, alloctd = 0;

                        if (results.NBR_NIGHTS.Value > 0)
                        {
                            avAmt += results.NBR_NIGHTS.Value;
                            if (results.Status == "O")
                                alloctd += results.NBR_NIGHTS.Value;
                        }
                        if (results.NBR_NIGHTS2.Value > 0)
                        {
                            avAmt += results.NBR_NIGHTS2.Value;
                            if (results.Status == "O")
                                alloctd += results.NBR_NIGHTS2.Value;
                        }
                        if (results.NBR_NIGHTS3.Value > 0)
                        {
                            avAmt += results.NBR_NIGHTS3.Value;
                            if (results.Status == "O")
                                alloctd += results.NBR_NIGHTS3.Value;
                        }
                        if (results.NBR_NIGHTS4.Value > 0)
                        {
                            avAmt += results.NBR_NIGHTS4.Value;
                            if (results.Status == "O")
                                alloctd += results.NBR_NIGHTS4.Value;
                        }
                        gridView1.SetFocusedRowCellValue("ALLOCTD", alloctd);
                        gridView1.SetFocusedRowCellValue("AV_AMT", avAmt);


                    }
                     

                }

            }
            
        }

        private void typeComboBoxEdit_TextChanged(object sender, EventArgs e)
        {
            if (this.typeComboBoxEdit.Text == "OPT" || this.typeComboBoxEdit.Text == "PKG" || this.typeComboBoxEdit.Text == "HTL")
            {
                gsLoad.gridSearchLoad(codeSearch, "CODE", "NAME", "Code", "Name", "CODE", "CODE", "CODE");
                if (this.typeComboBoxEdit.Text == "HTL")
                { // htl codes                   
                    codeSearch.GridControl.DataSource = from c in context.HOTEL select new { c.CODE, c.NAME };
                }
                if (this.typeComboBoxEdit.Text == "OPT")
                {  // option codes
                    codeSearch.GridControl.DataSource = from c in context.COMP select new { c.CODE, c.NAME };
                }
                if (this.typeComboBoxEdit.Text == "PKG")
                {  // pkg codes
                    codeSearch.GridControl.DataSource = from c in context.PACK select new { c.CODE, c.NAME };
                }
            }
            if (this.typeComboBoxEdit.Text == "CRU" || this.typeComboBoxEdit.Text == "AIR")
            {
                gsLoad.gridSearchLoad(codeSearch, "Code", "Name", "Code", "Name", "Code", "Code", "Name");
                if (this.typeComboBoxEdit.Text == "CRU")
                {      //seaports              
                    codeSearch.GridControl.DataSource = from c in context.SeaPort select new { c.Code, c.Name };
                }
                if (this.typeComboBoxEdit.Text == "AIR")
                {  //airports
                    codeSearch.GridControl.DataSource = from c in context.Airport select new { c.Code, c.Name };
                }
            }
        }

        private void gridSearchControl1_Enter(object sender, EventArgs e)
        {
            if (typeComboBoxEdit.Text != "HTL" && typeComboBoxEdit.Text != "CRU" && typeComboBoxEdit.Text != "PKG" && typeComboBoxEdit.Text != "AIR" && typeComboBoxEdit.Text != "OPT")
            {
                MessageBox.Show("Please select a type from the selection provided.");
                typeComboBoxEdit.Focus();
                return;
            }
            codeSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp1;
        }

        private void gridSearchControl1_ItemSelected()
        {
            codeSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp1;
        }

        private void gridSearchControl2_Enter(object sender, EventArgs e)
        {
            agencySearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp1;
        }

        private void gridSearchControl2_ItemSelected()
        {
            agencySearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp1;
        }

        private void gridSearchControl3_Enter(object sender, EventArgs e)
        {
            catSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp1;
        }

        private void gridSearchControl3_ItemSelected()
        {
            catSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp1;
        }

        void ButtonEdit_QueryPopUp1(object sender, CancelEventArgs e)
        {
            e.Cancel = false;            
        }

        private void gridSearchControl1_Leave(object sender, EventArgs e)
        {
           
            if (this.typeComboBoxEdit.Text == "HTL")
            {
                var results = (from c in context.HOTEL where c.CODE == codeSearch.Text.TrimEnd() select c).FirstOrDefault();
                if (results != null)
                {
                    defRoom = results.DEF_ROOM;
                    defCat = results.DFLT_CAT;
                    defAgy = results.CONTR_AGY;
                }
            }
            if (this.typeComboBoxEdit.Text == "CRU")
            {
                var results = (from c in context.CRU where c.CODE == codeSearch.Text.TrimEnd() select c).FirstOrDefault();
                if (results != null)
                {
                    defRoom = results.DEF_CABIN;                   
                }
            }
            
        }

    

        private void dateEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void dateEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void dateEdit1_TextChanged(object sender, EventArgs e)
        {
            dateEdit1.Text = validCheck.convertDate(dateEdit1.Text);
        }

        private void dateEdit2_TextChanged(object sender, EventArgs e)
        {
            dateEdit2.Text = validCheck.convertDate(dateEdit2.Text);
        }

    
    }
}