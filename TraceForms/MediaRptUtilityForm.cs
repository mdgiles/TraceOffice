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
    
    public partial class MediaRptUtilityForm : DevExpress.XtraEditors.XtraForm
    {
        public FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public MediaRptUtilityForm(FlexCore.CoreSys _sys)
        {
            Connection.EFConnectionString = _sys.Settings.EFConnectionString;
            context = new FlextourEntities(_sys.Settings.EFConnectionString);
            InitializeComponent();
            //gsLoad.gridSearchLoad(codeLoadSearch, "CODE", "NAME", "Code", "Name", "CODE", "CODE", "CODE");
            //gsLoad.gridSearchLoad(codeCopySearch, "CODE", "NAME", "Code", "Name", "CODE", "CODE", "CODE");
            gsLoad.gridSearchLoad(languageLoadSearch, "CODE", "NAME", "Code", "Name", "CODE", "CODE", "CODE");
            gsLoad.gridSearchLoad(languageCopySearch, "CODE", "NAME", "Code", "Name", "CODE", "CODE", "CODE");
            gsLoad.gridSearchLoad(agencyCopySearch, "NO", "NAME", "Code", "Name", "NO", "NO", "NO");
            gsLoad.gridSearchLoad(agencyLoadSearch, "NO", "NAME", "Code", "Name", "NO", "NO", "NO");
            gsLoad.gridSearchLoad(catLoadSearch, "CODE", "DESC", "Code", "Name", "CODE", "CODE", "CODE");
            gsLoad.gridSearchLoad(catCopySearch, "CODE", "DESC", "Code", "Name", "CODE", "CODE", "CODE");
            languageCopySearch.GridControl.DataSource = from c in context.LANGUAGE select new { c.CODE, c.NAME };
            languageLoadSearch.GridControl.DataSource = from c in context.LANGUAGE select new { c.CODE, c.NAME };
            agencyCopySearch.GridControl.DataSource = from c in context.AGY select new { c.NO, c.NAME };
            agencyLoadSearch.GridControl.DataSource = from c in context.AGY select new { c.NO, c.NAME };
            catCopySearch.GridControl.DataSource = from c in context.ROOMCOD select new { c.CODE, c.DESC };
            catLoadSearch.GridControl.DataSource = from c in context.ROOMCOD select new { c.CODE, c.DESC };
            
            //codeLoadSearch.GridControl.DataSource 
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                if (gridView1.IsRowSelected(e.RowHandle))
                {
                    e.Info.Paint.DrawCheckBox(e.Graphics, e.Bounds, ButtonState.Checked);
                    e.Handled = true;
                }
                else
                {
                    e.Info.Paint.DrawCheckBox(e.Graphics, e.Bounds, ButtonState.Normal);
                    e.Handled = true;
                }
            }
        }

        private void catLoadSearch_Enter(object sender, EventArgs e)
        {
            catLoadSearch.ButtonEdit.QueryPopUp += new CancelEventHandler(ButtonEdit_QueryPopUp);
        }

        private void catLoadSearch_ItemSelected()
        {
            catLoadSearch.ButtonEdit.QueryPopUp += new CancelEventHandler(ButtonEdit_QueryPopUp);
        }

        private void languageLoadSearch_Enter(object sender, EventArgs e)
        {
            languageLoadSearch.ButtonEdit.QueryPopUp += new CancelEventHandler(ButtonEdit_QueryPopUp);
        }

        private void languageLoadSearch_ItemSelected()
        {
            languageLoadSearch.ButtonEdit.QueryPopUp += new CancelEventHandler(ButtonEdit_QueryPopUp);
        }

        private void agencyLoadSearch_Enter(object sender, EventArgs e)
        {
            agencyLoadSearch.ButtonEdit.QueryPopUp += new CancelEventHandler(ButtonEdit_QueryPopUp);
        }

        private void agencyLoadSearch_ItemSelected()
        {
            agencyLoadSearch.ButtonEdit.QueryPopUp += new CancelEventHandler(ButtonEdit_QueryPopUp);
        }

        private void codeLoadSearch_Enter(object sender, EventArgs e)
        {
            codeLoadSearch.ButtonEdit.QueryPopUp += new CancelEventHandler(ButtonEdit_QueryPopUp);
        }

        private void codeLoadSearch_ItemSelected()
        {
            codeLoadSearch.ButtonEdit.QueryPopUp += new CancelEventHandler(ButtonEdit_QueryPopUp);
        }

        void ButtonEdit_QueryPopUp(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string code = "%";
            string agency = "%";
            string cat = "%";
            string language = "%";
            DateTime svcStart = DateTime.Today.AddYears(-1000);
            DateTime svcEnd = DateTime.Today.AddYears(1000);
            DateTime resStart = DateTime.Today.AddYears(-1000);
            DateTime resEnd = DateTime.Today.AddYears(1000);
            if (codeLoadSearch.Enabled)
                code = codeLoadSearch.Text;

            if (catLoadSearch.Enabled)
                cat = catLoadSearch.Text;
 
            if (agencyLoadSearch.Enabled)
                agency = agencyLoadSearch.Text;

            if (languageLoadSearch.Enabled)
                language = languageLoadSearch.Text;
            
            if (sVCDATE_STARTDateEdit.Enabled)
                svcStart = Convert.ToDateTime(sVCDATE_STARTDateEdit.Text);

            if (sVCDATE_ENDDateEdit.Enabled)
                svcEnd = Convert.ToDateTime(sVCDATE_ENDDateEdit.Text);

            if (rESDATE_STARTDateEdit.Enabled)
                resStart = Convert.ToDateTime(rESDATE_STARTDateEdit.Text);

            if (rESDATE_ENDDateEdit.Enabled)
                resEnd = Convert.ToDateTime(rESDATE_ENDDateEdit.Text);

            string query = String.Format("it.CODE like '{0}'  && it.CAT like '{1}' && it.Agency like '{2}' && it.LANG like '{3}'", code, cat, agency, language);

            var results = context.MEDIARPT.Where(query);
            
            gridControl1.DataSource = from c in results where c.SVCDATE_START >= svcStart &&  c.RESDATE_START >= resStart  select c;
            gridControl2.DataSource = from c in context.MEDIARPT where  c.AGENCY == "KJM" select c;
            
        }

        private void checkEdit1_Click(object sender, EventArgs e)
        {
            if (!checkEdit1.Checked)
                rPT_TYPEComboBoxEdit.Enabled = true;

            if (checkEdit1.Checked)
                rPT_TYPEComboBoxEdit.Enabled = false;  
        }

        private void checkEdit2_Click(object sender, EventArgs e)
        {
            if (!checkEdit2.Checked)
                tYPEComboBoxEdit.Enabled = true;                 

            if (checkEdit2.Checked)
                tYPEComboBoxEdit.Enabled = false;  
        }

        private void checkEdit3_Click(object sender, EventArgs e)
        {
            if (!checkEdit3.Checked)
                sVCDATE_STARTDateEdit.Enabled = true;

            if (checkEdit3.Checked)
                sVCDATE_STARTDateEdit.Enabled = false;  
        }

        private void checkEdit4_Click(object sender, EventArgs e)
        {
            if (!checkEdit4.Checked)
                rESDATE_STARTDateEdit.Enabled = true;

            if (checkEdit4.Checked)
                rESDATE_STARTDateEdit.Enabled = false;  
        }

        private void checkEdit5_Click(object sender, EventArgs e)
        {
            if (!checkEdit5.Checked)
                catLoadSearch.Enabled = true;

            if (checkEdit5.Checked)
                catLoadSearch.Enabled = false;  
        }

        private void checkEdit6_Click(object sender, EventArgs e)
        {
            if (!checkEdit6.Checked)
                agencyLoadSearch.Enabled = true;

            if (checkEdit6.Checked)
                agencyLoadSearch.Enabled = false;  
        }

        private void checkEdit7_Click(object sender, EventArgs e)
        {
            if (!checkEdit7.Checked)
                sVCDATE_ENDDateEdit.Enabled = true;

            if (checkEdit7.Checked)
                sVCDATE_ENDDateEdit.Enabled = false;  
        }

        private void checkEdit8_Click(object sender, EventArgs e)
        {
            if (!checkEdit8.Checked)
                rESDATE_ENDDateEdit.Enabled = true;

            if (checkEdit8.Checked)
                rESDATE_ENDDateEdit.Enabled = false;  
        }

        private void checkEdit9_Click(object sender, EventArgs e)
        {
            if (!checkEdit9.Checked)
                languageLoadSearch.Enabled = true;

            if (checkEdit9.Checked)
                languageLoadSearch.Enabled = false;  
        }

        private void checkEdit10_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tYPEComboBoxEdit.Text))
            {
                MessageBox.Show("Please select a service type before selecting a code.");
                return;
            }

            if (!checkEdit10.Checked)
                codeLoadSearch.Enabled = true;

            if (checkEdit10.Checked)
                codeLoadSearch.Enabled = false;  
        }

        private void tYPEComboBoxEdit_TextChanged(object sender, EventArgs e)
        {
            codeLoadSearch.GridControl.DataSource = null;
            codeCopySearch.GridControl.DataSource = null;
            if (tYPEComboBoxEdit.Text == "AIR" || tYPEComboBoxEdit.Text == "OPT" || tYPEComboBoxEdit.Text == "CRU" || tYPEComboBoxEdit.Text == "TRN")
            {
                gsLoad.gridSearchLoad(codeLoadSearch, "Code", "Name", "Code", "Name", "Code", "Code", "Code", mEDIARPTBindingSource, "CODE");
                gsLoad.gridSearchLoad(codeCopySearch, "Code", "Name", "Code", "Name", "Code", "Code", "Code", mEDIARPTBindingSource, "CODE");
                if (this.tYPEComboBoxEdit.Text == "AIR")
                {
                    //airport
                    codeLoadSearch.GridControl.DataSource = from c in context.Airport select new { c.Code, c.Name };
                    codeCopySearch.GridControl.DataSource = from c in context.Airport select new { c.Code, c.Name };
                }              
                if (this.tYPEComboBoxEdit.Text == "CRU")
                {
                    //sea ports
                    codeLoadSearch.GridControl.DataSource = from c in context.SeaPort select new { c.Code, c.Name };
                    codeCopySearch.GridControl.DataSource = from c in context.SeaPort select new { c.Code, c.Name };
                }

              
            }
            ////////////////////////////////////////////////////////////////////////////////////////////
            if (tYPEComboBoxEdit.Text == "CAR" || tYPEComboBoxEdit.Text == "CTY" || tYPEComboBoxEdit.Text == "HTL")
            {
                gsLoad.gridSearchLoad(codeLoadSearch, "CODE", "NAME", "Code", "Name", "CODE", "CODE", "CODE", mEDIARPTBindingSource, "CODE");
                gsLoad.gridSearchLoad(codeCopySearch, "CODE", "NAME", "Code", "Name", "CODE", "CODE", "CODE", mEDIARPTBindingSource, "CODE");
                if (this.tYPEComboBoxEdit.Text == "CAR")
                {
                    // cars
                    codeLoadSearch.GridControl.DataSource = from c in context.CARINFO select new { c.CODE, c.NAME };
                    codeCopySearch.GridControl.DataSource = from c in context.CARINFO select new { c.CODE, c.NAME };
                }

                if (this.tYPEComboBoxEdit.Text == "PKG")
                {
                    // pkgs    
                    codeLoadSearch.GridControl.DataSource = from c in context.PACK select new { c.CODE, c.NAME };
                    codeCopySearch.GridControl.DataSource = from c in context.PACK select new { c.CODE, c.NAME };
                }

                if (this.tYPEComboBoxEdit.Text == "OPT")
                {
                    // options
                    codeLoadSearch.GridControl.DataSource = from c in context.COMP select new { c.CODE, c.NAME };
                    codeCopySearch.GridControl.DataSource = from c in context.COMP select new { c.CODE, c.NAME };
                }

                if (this.tYPEComboBoxEdit.Text == "CTY")
                {
                    // city codes
                    codeLoadSearch.GridControl.DataSource = from c in context.CITYCOD select new { c.CODE, c.NAME };
                    codeCopySearch.GridControl.DataSource = from c in context.CITYCOD select new { c.CODE, c.NAME };
                }

                if (this.tYPEComboBoxEdit.Text == "HTL")
                {
                    // htl codes
                    codeLoadSearch.GridControl.DataSource = from c in context.HOTEL select new { c.CODE, c.NAME };
                    codeCopySearch.GridControl.DataSource = from c in context.HOTEL select new { c.CODE, c.NAME };
                }
            }

            if (this.tYPEComboBoxEdit.Text == "WAY")
            {
                gsLoad.gridSearchLoad(codeLoadSearch, "CODE", "DESC", "Code", "Name", "CODE", "CODE", "CODE", mEDIARPTBindingSource, "CODE");
                gsLoad.gridSearchLoad(codeCopySearch, "CODE", "DESC", "Code", "Name", "CODE", "CODE", "CODE", mEDIARPTBindingSource, "CODE");
                // htl codes
                codeLoadSearch.GridControl.DataSource = from c in context.WAYPOINT select new { c.CODE, c.DESC };
                codeCopySearch.GridControl.DataSource = from c in context.WAYPOINT select new { c.CODE, c.DESC };
            }            
        }

        private void assignButton_Click(object sender, EventArgs e)
        {
            int j = gridView2.DataRowCount + 1;

            for (int i = 0; i < j; i++)
            {
                gridView2.MoveFirst();
                gridView2.DeleteRow(gridView2.FocusedRowHandle);
            }

            foreach (int val in gridView1.GetSelectedRows())
            {
                gridView2.AddNewRow();

                gridView2.SetFocusedRowCellValue("CODE", codeCopySearch.Text);
                gridView2.SetFocusedRowCellValue("LANG", gridView1.GetRowCellValue(val, "LANG"));
                gridView2.SetFocusedRowCellValue("TYPE", gridView1.GetRowCellValue(val, "TYPE"));                
                gridView2.SetFocusedRowCellValue("CAT", gridView1.GetRowCellValue(val, "CAT"));
                gridView2.SetFocusedRowCellValue("ROOM", gridView1.GetRowCellValue(val, "ROOM"));
                gridView2.SetFocusedRowCellValue("AGENCY", gridView1.GetRowCellValue(val, "AGENCY"));
                gridView2.SetFocusedRowCellValue("RPT_TYPE", gridView1.GetRowCellValue(val, "RPT_TYPE"));
                gridView2.SetFocusedRowCellValue("SVCDATE_START", gridView1.GetRowCellValue(val, "SVCDATE_START"));
                gridView2.SetFocusedRowCellValue("SVCDATE_END", gridView1.GetRowCellValue(val, "SVCDATE_END"));
                gridView2.SetFocusedRowCellValue("RESDATE_START", gridView1.GetRowCellValue(val, "RESDATE_START"));
                gridView2.SetFocusedRowCellValue("RESDATE_END", gridView1.GetRowCellValue(val, "RESDATE_END"));
                gridView2.SetFocusedRowCellValue("DESC", gridView1.GetRowCellValue(val, "DESC"));
                gridView2.SetFocusedRowCellValue("RPT_FILE", gridView1.GetRowCellValue(val, "RPT_FILE"));
                gridView2.SetFocusedRowCellValue("Inactive", gridView1.GetRowCellValue(val, "Inactive"));
                gridView2.SetFocusedRowCellValue("SECTION", gridView1.GetRowCellValue(val, "SECTION"));
                gridView2.SetFocusedRowCellValue("Inhouse", gridView1.GetRowCellValue(val, "Inhouse"));
                gridView2.SetFocusedRowCellValue("TITLE", gridView1.GetRowCellValue(val, "TITLE"));
                gridView2.SetFocusedRowCellValue("ChgDate", DateTime.Now);
            }
            gridView2.Focus();
            gridView1.Focus();
        }

        private void codeCopySearch_Enter(object sender, EventArgs e)
        {
            codeCopySearch.ButtonEdit.QueryPopUp += new CancelEventHandler(ButtonEdit_QueryPopUp);
        }

        private void codeCopySearch_ItemSelected()
        {
            codeCopySearch.ButtonEdit.QueryPopUp += new CancelEventHandler(ButtonEdit_QueryPopUp);
        }


        private void checkEdit20_Click(object sender, EventArgs e)
        {
            if (!checkEdit20.Checked)
                reportLoad.Enabled = true;

            if (checkEdit20.Checked)
                reportLoad.Enabled = false; 
        }

        private void checkEdit18_Click(object sender, EventArgs e)
        {
            if (!checkEdit18.Checked)
                startServiceDateLoad.Enabled = true;

            if (checkEdit18.Checked)
                startServiceDateLoad.Enabled = false; 
        }

        private void checkEdit17_Click(object sender, EventArgs e)
        {
            if (!checkEdit17.Checked)
                startResDateLoad.Enabled = true;

            if (checkEdit17.Checked)
                startResDateLoad.Enabled = false; 
        }

        private void checkEdit16_Click(object sender, EventArgs e)
        {
            if (!checkEdit16.Checked)
                catCopySearch.Enabled = true;

            if (checkEdit16.Checked)
                catCopySearch.Enabled = false;  
        }

        private void checkEdit12_Click(object sender, EventArgs e)
        {
            if (!checkEdit12.Checked)
                languageCopySearch.Enabled = true;

            if (checkEdit12.Checked)
                languageCopySearch.Enabled = false;  
        }

        private void checkEdit15_Click(object sender, EventArgs e)
        {
            if (!checkEdit15.Checked)
                agencyCopySearch.Enabled = true;

            if (checkEdit15.Checked)
                agencyCopySearch.Enabled = false;  
        }

        private void checkEdit14_Click(object sender, EventArgs e)
        {
            if (!checkEdit14.Checked)
                endServiceDateLoad.Enabled = true;

            if (checkEdit14.Checked)
                endServiceDateLoad.Enabled = false;  
        }

        private void checkEdit13_Click(object sender, EventArgs e)
        {
            if (!checkEdit13.Checked)
                endResDateLoad.Enabled = true;

            if (checkEdit13.Checked)
                endResDateLoad.Enabled = false;  
        }

        private void catCopySearch_Enter(object sender, EventArgs e)
        {
            catCopySearch.ButtonEdit.QueryPopUp += new CancelEventHandler(ButtonEdit_QueryPopUp);
        }

        private void catCopySearch_ItemSelected()
        {
            catCopySearch.ButtonEdit.QueryPopUp += new CancelEventHandler(ButtonEdit_QueryPopUp);
        }

        private void languageCopySearch_Enter(object sender, EventArgs e)
        {
            languageCopySearch.ButtonEdit.QueryPopUp += new CancelEventHandler(ButtonEdit_QueryPopUp);
        }

        private void languageCopySearch_ItemSelected()
        {
            languageCopySearch.ButtonEdit.QueryPopUp += new CancelEventHandler(ButtonEdit_QueryPopUp);
       
        }

        private void agencyCopySearch_Enter(object sender, EventArgs e)
        {
            agencyCopySearch.ButtonEdit.QueryPopUp += new CancelEventHandler(ButtonEdit_QueryPopUp);
        }

        private void agencyCopySearch_ItemSelected()
        {
            agencyCopySearch.ButtonEdit.QueryPopUp += new CancelEventHandler(ButtonEdit_QueryPopUp);
      
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            gridView2.MoveFirst();
            gridView2.Focus();
            if (catCopySearch.Enabled == true)
            {
                for (int i = 0; i < gridView2.RowCount; i++) {
                    gridView2.SetRowCellValue(i, gridView2.Columns["CAT"], catCopySearch.Text);
                    gridView2.SetRowCellValue(i, gridView2.Columns["ChgDate"], DateTime.Now);
                }
            }

            if (languageCopySearch.Enabled == true)
            {
                for (int i = 0; i < gridView2.RowCount; i++) {
                    gridView2.SetRowCellValue(i, gridView2.Columns["LANG"], languageCopySearch.Text);
                    gridView2.SetRowCellValue(i, gridView2.Columns["ChgDate"], DateTime.Now);
                }
            }

            if (agencyCopySearch.Enabled == true)
            {
                for (int i = 0; i < gridView2.RowCount; i++) {
                    gridView2.SetRowCellValue(i, gridView2.Columns["AGENCY"], agencyCopySearch.Text);
                    gridView2.SetRowCellValue(i, gridView2.Columns["ChgDate"], DateTime.Now);
                }
            }

            if (reportLoad.Enabled == true)
            {
                for (int i = 0; i < gridView2.RowCount; i++) {
                    gridView2.SetRowCellValue(i, gridView2.Columns["RPT_TYPE"], reportLoad.Text);
                    gridView2.SetRowCellValue(i, gridView2.Columns["ChgDate"], DateTime.Now);
                }
            }

            if (startServiceDateLoad.Enabled == true)
            {
                for (int i = 0; i < gridView2.RowCount; i++) {
                    gridView2.SetRowCellValue(i, gridView2.Columns["SVCDATE_START"], startServiceDateLoad.Text);
                    gridView2.SetRowCellValue(i, gridView2.Columns["ChgDate"], DateTime.Now);
                }
            }

            if (endServiceDateLoad.Enabled == true)
            {
                for (int i = 0; i < gridView2.RowCount; i++) {
                    gridView2.SetRowCellValue(i, gridView2.Columns["SVCDATE_END"], endServiceDateLoad.Text);
                    gridView2.SetRowCellValue(i, gridView2.Columns["ChgDate"], DateTime.Now);
                }
            }

            if (startResDateLoad.Enabled == true)
            {
                for (int i = 0; i < gridView2.RowCount; i++) {
                    gridView2.SetRowCellValue(i, gridView2.Columns["RESDATE_START"], startResDateLoad.Text);
                    gridView2.SetRowCellValue(i, gridView2.Columns["ChgDate"], DateTime.Now);
                }
            }

            if (endResDateLoad.Enabled == true)
            {
                for (int i = 0; i < gridView2.RowCount; i++) {
                    gridView2.SetRowCellValue(i, gridView2.Columns["RESDATE_END"], endResDateLoad.Text);
                    gridView2.SetRowCellValue(i, gridView2.Columns["ChgDate"], DateTime.Now);
                }
            }

        }

        private bool checkOverlap(DateTime time1, DateTime time2, DateTime dateStart2, DateTime dateEnd2)
        {
            bool val = true;

            if (time1 != null)
            {
                if ((time1 >= dateStart2 && time1 <= dateEnd2) || (time1 >= dateStart2 && dateEnd2 == null) || (time1 <= dateEnd2 && dateStart2 == null))
                {
                    val = false;
                }
            }
            if (time2 != null && time1 != time2)
            {
                if ((time2 >= dateStart2 && time2 <= dateEnd2) || (time2 >= dateStart2 && dateEnd2 == null) || (time2 <= dateEnd2 && dateStart2 == null) || (time1 <= dateStart2 && time2 >= dateEnd2))
                {
                    val = false;
                }
            }

            if (((time1 == null && time2 == null) || (dateStart2 == null && dateEnd2 == null)) && ((time1 == null && dateStart2 == null) || (time1 != null && dateStart2 != null)))
            {
                val = false;
            }
            return val;
        }

        private void mEDIARPTBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save these changes?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                gridView2.MoveFirst();
                gridView2.MoveLast();
                mEDIARPTBindingSource.EndEdit();
                context.SaveChanges();
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;

            }
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private void gridView2_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            using (Session session1 = new Session())
            {

                session1.BeginTransaction();
                try
                {

                    ColumnView view = sender as ColumnView;
                    GridColumn column1 = view.Columns["CODE"];
                    GridColumn column2 = view.Columns["AGENCY"];
                    GridColumn column3 = view.Columns["CAT"];
                  
                    GridColumn column5 = view.Columns["SVCDATE_START"];
                    GridColumn column6 = view.Columns["SVCDATE_END"];
                    GridColumn column7 = view.Columns["RESDATE_START"];
                    GridColumn column8 = view.Columns["RESDATE_END"];
                    //Get the value of the columns
                    string val1 = (string)view.GetRowCellValue(e.RowHandle, column1);
                    string val2 = (string)view.GetRowCellValue(e.RowHandle, column2);
                    string val3 = (string)view.GetRowCellValue(e.RowHandle, column3);
                   
                    DateTime time1 = (DateTime)view.GetRowCellValue(e.RowHandle, column5);
                    DateTime time2 = (DateTime)view.GetRowCellValue(e.RowHandle, column6);
                    DateTime time3 = new DateTime();
                    DateTime time4 = new DateTime();
                    if ((string)view.GetRowCellValue(e.RowHandle, column7) != null)
                        time3 = (DateTime)view.GetRowCellValue(e.RowHandle, column7);
                    if ((string)view.GetRowCellValue(e.RowHandle, column8) != null)
                        time4 = (DateTime)view.GetRowCellValue(e.RowHandle, column8);

                    var load = from c in context.CPRATES where c.CODE == val1 && c.AGENCY == val2 && c.CAT == val3 select new { c.START_DATE, c.END_DATE, c.ResDate_Start, c.ResDate_End };
                    //Validity criterion

                    if (load.Count() > 0)
                    {
                        foreach (var d in load)
                        {
                            DateTime dateStart2 = (DateTime)d.START_DATE;
                            DateTime dateEnd2 = (DateTime)d.END_DATE;
                            if (!checkOverlap(time1, time2, dateStart2, dateEnd2))
                            {
                                DateTime time5 = new DateTime();
                                DateTime time6 = new DateTime();

                                if (d.ResDate_Start != null)
                                    time5 = (DateTime)d.ResDate_Start;
                                if (d.ResDate_Start != null)
                                    time6 = (DateTime)d.ResDate_End;

                                if (!checkOverlap(time3, time4, time5, time6))
                                {
                                    e.Valid = false;
                                    view.SetColumnError(column1, "You are trying to enter an overlapping Media Report.");
                                }
                            }
                        }
                    }
                    session1.CommitTransaction();
                }
                catch { session1.RollbackTransaction(); }
            }
        }

        private void gridView2_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction; 
  
        }

        private void sVCDATE_STARTDateEdit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
           
        }

        private void sVCDATE_ENDDateEdit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            
        }

        private void rESDATE_STARTDateEdit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
           
        }

        private void rESDATE_ENDDateEdit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
          
        }

        private void sVCDATE_STARTDateEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void sVCDATE_ENDDateEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void sVCDATE_STARTDateEdit_TextChanged(object sender, EventArgs e)
        {
            sVCDATE_STARTDateEdit.Text = validCheck.convertDate(sVCDATE_STARTDateEdit.Text);
        }

        private void sVCDATE_ENDDateEdit_TextChanged(object sender, EventArgs e)
        {
            sVCDATE_ENDDateEdit.Text = validCheck.convertDate(sVCDATE_ENDDateEdit.Text);
        }

        private void rESDATE_STARTDateEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void rESDATE_STARTDateEdit_TextChanged(object sender, EventArgs e)
        {
            rESDATE_STARTDateEdit.Text = validCheck.convertDate(rESDATE_STARTDateEdit.Text);
        }

        private void rESDATE_ENDDateEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void rESDATE_ENDDateEdit_TextChanged(object sender, EventArgs e)
        {
            rESDATE_ENDDateEdit.Text = validCheck.convertDate(rESDATE_ENDDateEdit.Text);
        }

        private void startServiceDateLoad_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void startServiceDateLoad_TextChanged(object sender, EventArgs e)
        {
            startServiceDateLoad.Text = validCheck.convertDate(startServiceDateLoad.Text);
        }

        private void endServiceDateLoad_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void endServiceDateLoad_TextChanged(object sender, EventArgs e)
        {
            endServiceDateLoad.Text = validCheck.convertDate(endServiceDateLoad.Text);
        }

        private void startResDateLoad_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void startResDateLoad_TextChanged(object sender, EventArgs e)
        {
            startResDateLoad.Text = validCheck.convertDate(startResDateLoad.Text);
        }

        private void endResDateLoad_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void endResDateLoad_TextChanged(object sender, EventArgs e)
        {
            endResDateLoad.Text = validCheck.convertDate(endResDateLoad.Text);
        }

        private void MediaRptUtilityForm_FormClosing(object sender, FormClosingEventArgs e)
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