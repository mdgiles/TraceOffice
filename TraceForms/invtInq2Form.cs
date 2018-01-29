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
using System.Data.Entity.Core.Objects;
using System.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Runtime.InteropServices;
namespace TraceForms
{
    
    public partial class invtInq2Form : DevExpress.XtraEditors.XtraForm
    {
        public string lastAgy = "";
        public FlextourEntities context;
        public invtInq2Form(FlexCore.CoreSys _sys)
        {
            InitializeComponent();
            Connection.EFConnectionString = _sys.Settings.EFConnectionString;
            context = new FlextourEntities(_sys.Settings.EFConnectionString);
            gsLoad.gridSearchLoad(catSearch, "CODE", "DESC", "Code", "Name", "CODE", "CODE", "CODE");
            gsLoad.gridSearchLoad(agencySearch, "NO", "NAME", "Code", "Name", "NO", "NO", "NO");
            agencySearch.GridControl.DataSource = from c in context.AGY select new { c.NO, c.NAME };
            catSearch.GridControl.DataSource = from c in context.ROOMCOD select new { c.CODE, c.DESC };
            gridControl1.DataSource = from c in context.INVT where c.CODE == codeSearch.Text.TrimEnd() && c.CAT == "KJM" select c;
            //InvtBindingSource.DataSource = context.INVT.Take(100000);
        }

        public void PerformInquiry(FlexInterfaces.BObj.IItem item)
        {
            typeComboBoxEdit.Text = item.ItemType;
            codeSearch.Text = item.Code;
            agencySearch.Text = item.ContractAgency;
            catSearch.Text = item.Category;
            DateTime date1 = item.StartDate;
            DateTime date2 = item.EndDate;
            roomComboBoxEdit.Text = item.DefaultRoom;
            Search(date1, date2, item.Code, item.Category, item.ContractAgency, item.ItemType, item.DefaultRoom);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(startDateEdit.Text) || string.IsNullOrEmpty(endDateEdit.Text))
            {
                MessageBox.Show("Please enter a date range for the desired search.");
                return;
            }
            string queryCode = string.Empty, queryCat = string.Empty, queryAgency = string.Empty, queryType = string.Empty, queryRoom = string.Empty;
            
            DateTime date1 = Convert.ToDateTime(startDateEdit.Text);
            DateTime date2 = Convert.ToDateTime(endDateEdit.Text);
            queryCode = codeSearch.Text;
            queryCat = catSearch.Text;
            queryAgency = agencySearch.Text;
            queryType = typeComboBoxEdit.Text;
            queryRoom = roomComboBoxEdit.Text;
            Search(date1, date2, queryCode, queryCat, queryAgency, queryType, queryRoom);
        }
        
        public void Search(DateTime date1, DateTime date2, string queryCode, string queryCat, string queryAgency, string queryType, string queryRoom)
        {
            //gridView1.Columns.Clear();
            //GridColumn colAgent = new GridColumn();
            //colAgent.FieldName = "AGENCY";
            //colAgent.Caption = "Agencies:";
            if (gridView1.RowCount > 0)
            {
                while (gridView1.RowCount > 0)
                {
                    int y = 0;
                    gridView1.DeleteRow(y);
                }
            }
            //gridView1.Columns.Add(colAgent);
           //gridControl1.DataSource = from c in context.INVT where c.CODE == codeSearch.Text.TrimEnd() && c.CAT == "KJM" select c;
            DateTime queryStartDate = date1;
            DateTime queryEndDate = date2;
            TimeSpan diff = date2.Subtract(date1);
            int x = diff.Days;           
            for (int y = 0; y < x + 1; y++)
            {
                gridView1.AddNewRow();
                gridView1.SetFocusedRowCellValue("AGENCY", date1.ToLongDateString());
                gridView1.AddNewRow();
                gridView1.SetFocusedRowCellValue("AGENCY", "Base/Avail/Av/Req");
                gridView1.AddNewRow();
                gridView1.SetFocusedRowCellValue("AGENCY", "Release by");
                date1 = date1.AddDays(1);
            }

            if (string.IsNullOrWhiteSpace(queryCode) || string.IsNullOrWhiteSpace(queryCat) || string.IsNullOrWhiteSpace(queryAgency) || string.IsNullOrWhiteSpace(queryRoom) || string.IsNullOrWhiteSpace(queryType))
            {
                string query = String.Format("it.CODE like '{0}%'", queryCode);
                var special = context.INVT.Where(query);

                //query = String.Format("it.CAT like '{0}%'", queryCat);
                //special = special.Where(query);

                //query = String.Format("it.CAT like '{0}%'", queryAgency);
                //special = special.Where(query);

                //query = String.Format("it.TYPE like '{0}%'", queryType);
                //special = special.Where(query);

                //query = String.Format("it.TP like '{0}%'", queryRoom);
                //special = special.Where(query);

                special = special.Where("it.DATE >= @startDate", new ObjectParameter("startDate", queryStartDate));
                special = special.Where("it.DATE >= @endDate", new ObjectParameter("endDate", queryEndDate));
              
                List<FlexModel.INVT> results = new List<FlexModel.INVT>();
                results = special.ToList();
                 //results = (from c in context.INVT
                 //             where c.TYPE == typeComboBoxEdit.Text && c.CODE == codeSearch.Text.TrimEnd() && c.CAT == catSearch.Text.TrimEnd()
                 //             && c.TP == roomComboBoxEdit.Text && c.DATE >= queryStartDate && c.DATE <= queryEndDate
                 //             select c).ToList();        
                foreach (FlexModel.INVT value in results)
                {
                    GridColumn colalm = new GridColumn();                 
                    if(!lastAgy.Contains(value.AGENCY ))
                        gridView1.Columns.Add(colalm);
                    colalm.Visible = true;
                    colalm.Caption = value.AGENCY;
                    colalm.FieldName = value.AGENCY;
                    colalm.UnboundType = DevExpress.Data.UnboundColumnType.String;
                    colalm.Width = 200;
                    lastAgy += value.AGENCY;
                }
            }
            else
            {
                var results = from c in context.INVT 
                              where c.TYPE == queryType && c.CODE == queryCode && c.CAT == queryCat
                              && c.AGENCY == queryAgency && c.TP == queryRoom && c.DATE >= queryStartDate
                              && c.DATE <= queryEndDate
                              select c;
                foreach (var value in results)
                {
                    GridColumn colalm = new GridColumn();
                    if (!lastAgy.Contains(value.AGENCY))
                        gridView1.Columns.Add(colalm);
                    colalm.Visible = true;
                    colalm.Caption = value.AGENCY;
                    colalm.FieldName = value.AGENCY;
                    colalm.UnboundType = DevExpress.Data.UnboundColumnType.String;
                    lastAgy += value.AGENCY;
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
            codeSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }
        private void gridSearchControl1_ItemSelected()
        {
            codeSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }
        private void gridSearchControl2_Enter(object sender, EventArgs e)
        {
            catSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }
        private void gridSearchControl2_ItemSelected()
        {
            catSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }
        private void gridSearchControl3_Enter(object sender, EventArgs e)
        {
            agencySearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }
        private void gridSearchControl3_ItemSelected()
        {
            agencySearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }
        void ButtonEdit_QueryPopUp(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
        }
        private void gridView1_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            DateTime dte = Convert.ToDateTime(startDateEdit.Text);
            string req;
            int days = e.ListSourceRowIndex;
            days++;
            while ((days) % 3 != 0)
                days++;
            days = (days  / 3) - 1;
            dte = dte.AddDays(days);            
                var query = (from c in context.INVT
                              where c.TYPE == typeComboBoxEdit.Text && c.CODE == codeSearch.Text.TrimEnd() && c.CAT == catSearch.Text.TrimEnd() && c.TP == roomComboBoxEdit.Text &&
                                 c.DATE == dte
                              select c);            
            foreach (var results in query)
            {
                if (e.Column.FieldName == results.AGENCY)
                {
                    if (results != null)
                    {
                        if (e.ListSourceRowIndex % 3 == 0)
                        {
                            DateTime dt1 = results.DATE.Value;
                            e.Value = dt1.ToLongDateString();
                        }
                        if (e.ListSourceRowIndex % 3 == 1)
                        {
                            if (results.Requestable == true)
                                req = "Y";
                            else
                                req = "N";
                            e.Value = String.Format("{0}/{1}/{2}/{3}", results.ORIG_AMT, results.AV_AMT, results.AV, req);
                        }
                        if (e.ListSourceRowIndex % 3 == 2)
                        {
                            int j = results.REL.Value;
                            DateTime dt2 = results.DATE.Value;
                            dt2 = dt2.AddDays(-j);
                            e.Value = dt2.ToLongDateString();
                        }
                    }
                }
            }
        }


        private void startDateEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void startDateEdit_TextChanged(object sender, EventArgs e)
        {
            startDateEdit.Text = validCheck.convertDate(startDateEdit.Text);
        }

        private void endDateEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void endDateEdit_TextChanged(object sender, EventArgs e)
        {
            endDateEdit.Text = validCheck.convertDate(endDateEdit.Text);
        }

        private void simpleButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }     
    }
}

