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
    
    public partial class InvtChgForm : DevExpress.XtraEditors.XtraForm
    {
        public FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public InvtChgForm(FlexCore.CoreSys _sys)
        {
            InitializeComponent();
            Connection.EFConnectionString = _sys.Settings.EFConnectionString;
            context = new FlextourEntities(_sys.Settings.EFConnectionString);
            gsLoad.gridSearchLoad(agencySearch, "NO", "NAME", "Code", "Name", "NO", "NO", "NO");
            gsLoad.gridSearchLoad(relAgencySearch, "NO", "NAME", "Code", "Name", "NO", "NO", "NO");
            agencySearch.GridControl.DataSource = from c in context.AGY select new { c.NO, c.NAME };
            relAgencySearch.GridControl.DataSource = from c in context.AGY select new { c.NO, c.NAME };
            gsLoad.gridSearchLoad(catSearch, "CODE", "DESC", "Code", "Name", "CODE", "CODE", "CODE");
            gsLoad.gridSearchLoad(relCatSearch, "CODE", "DESC", "Code", "Name", "CODE", "CODE", "CODE");
            catSearch.GridControl.DataSource = from c in context.ROOMCOD select new { c.CODE, c.DESC };
            relCatSearch.GridControl.DataSource = from c in context.ROOMCOD select new { c.CODE, c.DESC };
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page == xtraTabPage1)
            {
                colDATE.Visible = true;
                colAV.Visible = true;
                colMIN_BK_DAYS.Visible = true;
                colMAX.Visible = true;
                colMIN.Visible = true;               
                colCANC.Visible = true;

                colORIG_AMT.Visible = false;
                colAV_AMT.Visible = false;
                colALLOCTD.Visible = false;
                colHOLD.Visible = false;

                colREL.Visible = false;
                colRELAGY.Visible = false;
                colRELCAT.Visible = false;
                colRELCODE.Visible = false;
                colRELTYP.Visible = false; 

                colDATE.VisibleIndex = 0;
                colAV.VisibleIndex = 1;
                colMIN_BK_DAYS.VisibleIndex = 2;
                colMAX.VisibleIndex = 3;
                colMIN.VisibleIndex = 4;
                colCANC.VisibleIndex = 5;
            }
            if (e.Page == xtraTabPage2)
            {
                colDATE.Visible = true;
                colORIG_AMT.Visible = true;
                colAV_AMT.Visible = true;
                colALLOCTD.Visible = true;                
                colHOLD.Visible = true;

                
                colAV.Visible = false;
                colMIN_BK_DAYS.Visible = false;
                colMAX.Visible = false;
                colMIN.Visible = false;
                colCANC.Visible = false;

                colREL.Visible = false;
                colRELAGY.Visible = false;
                colRELCAT.Visible = false;
                colRELCODE.Visible = false;
                colRELTYP.Visible = false; 

                colDATE.VisibleIndex = 0;
                colORIG_AMT.VisibleIndex = 1;
                colAV_AMT.VisibleIndex = 2;
                colALLOCTD.VisibleIndex = 3;
                colHOLD.VisibleIndex = 4;

            }
            if (e.Page == xtraTabPage3)
            {
                colDATE.Visible = true;
                colREL.Visible = true;
                colRELAGY.Visible = true;
                colRELCAT.Visible = true;
                colRELCODE.Visible = true;
                colRELTYP.Visible = true; ;

                colORIG_AMT.Visible = false;
                colAV_AMT.Visible = false;
                colALLOCTD.Visible = false;
                colHOLD.Visible = false;

                colAV.Visible = false;
                colMIN_BK_DAYS.Visible = false;
                colMAX.Visible = false;
                colMIN.Visible = false;
                colCANC.Visible = false;

                colDATE.VisibleIndex = 0;
                colREL.VisibleIndex = 1;
                colRELCODE.VisibleIndex = 2;
                colRELAGY.VisibleIndex = 3;
                colRELCAT.VisibleIndex = 4;
                colRELTYP.VisibleIndex = 5;

            }
        }

        private void comboBoxEdit1_TextChanged(object sender, EventArgs e)
        {
            if (this.comboBoxEdit1.Text == "OPT" || this.comboBoxEdit1.Text == "PKG" || this.comboBoxEdit1.Text == "HTL")
            {
                gsLoad.gridSearchLoad(codeSearch, "CODE", "NAME", "Code", "Name", "CODE", "CODE", "CODE");
                gsLoad.gridSearchLoad(relCodeSearch, "CODE", "NAME", "Code", "Name", "CODE", "CODE", "CODE");

                if (this.comboBoxEdit1.Text == "HTL")
                { // htl codes                   
                    codeSearch.GridControl.DataSource = from c in context.HOTEL select new { c.CODE, c.NAME };
                    relCodeSearch.GridControl.DataSource = from c in context.HOTEL select new { c.CODE, c.NAME };
                }
                if (this.comboBoxEdit1.Text == "OPT")
                {
                    // option codes
                    codeSearch.GridControl.DataSource = from c in context.COMP select new { c.CODE, c.NAME };
                    relCodeSearch.GridControl.DataSource = from c in context.COMP select new { c.CODE, c.NAME };
                }

                if (this.comboBoxEdit1.Text == "PKG")
                {
                    // pkg codes
                    codeSearch.GridControl.DataSource = from c in context.PACK select new { c.CODE, c.NAME };
                    relCodeSearch.GridControl.DataSource = from c in context.PACK select new { c.CODE, c.NAME };
                }
            }
            if (this.comboBoxEdit1.Text == "CRU" || this.comboBoxEdit1.Text == "AIR")
            {
                gsLoad.gridSearchLoad(codeSearch, "Code", "Name", "Code", "Name", "Code", "Code", "Name");
                gsLoad.gridSearchLoad(relCodeSearch, "Code", "Name", "Code", "Name", "Code", "Code", "Name");
                if (this.comboBoxEdit1.Text == "CRU")
                {
                    codeSearch.GridControl.DataSource = from c in context.SeaPort select new { c.Code, c.Name };
                    relCodeSearch.GridControl.DataSource = from c in context.SeaPort select new { c.Code, c.Name };
                }
                if (this.comboBoxEdit1.Text == "AIR")
                {
                    //airports
                    codeSearch.GridControl.DataSource = from c in context.Airport select new { c.Code, c.Name };
                    relCodeSearch.GridControl.DataSource = from c in context.Airport select new { c.Code, c.Name };
                }

            }
        }

        private void gridSearchControl1_Enter(object sender, EventArgs e)
        {
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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = from c in context.INVT where c.TYPE == comboBoxEdit1.Text && c.CODE == codeSearch.Text.TrimEnd() && c.AGENCY == agencySearch.Text.TrimEnd()  && c.DATE >= Convert.ToDateTime(dateEdit1.Text) && c.DATE <= Convert.ToDateTime(dateEdit2.Text) select c;
            //&& c.CAT == gridSearchControl3.Text.TrimEnd() && c.TP == comboBoxEdit2.Text
        }

        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
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

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            foreach (int val in gridView1.GetSelectedRows())
            {
                if (comboBoxEdit4.Enabled)
                {
                    gridView1.SetRowCellValue(val, gridView1.Columns["AV"], comboBoxEdit4.Text);
                    gridView1.SetRowCellValue(val, gridView1.Columns["UPD_DATE"], DateTime.Now);
                }

                if (spinEdit3.Enabled)
                {
                    gridView1.SetRowCellValue(val, gridView1.Columns["MAX"], spinEdit3.Text);
                    gridView1.SetRowCellValue(val, gridView1.Columns["UPD_DATE"], DateTime.Now);
                }

                if (spinEdit4.Enabled)
                {
                    gridView1.SetRowCellValue(val, gridView1.Columns["MIN"], spinEdit4.Text);
                    gridView1.SetRowCellValue(val, gridView1.Columns["UPD_DATE"], DateTime.Now);
                }

                if (spinEdit2.Enabled)
                {
                    gridView1.SetRowCellValue(val, gridView1.Columns["MIN_BK_DAYS"], spinEdit2.Text);
                    gridView1.SetRowCellValue(val, gridView1.Columns["UPD_DATE"], DateTime.Now);
                }

                if (spinEdit5.Enabled)
                {
                    gridView1.SetRowCellValue(val, gridView1.Columns["CANC"], spinEdit5.Text);
                    gridView1.SetRowCellValue(val, gridView1.Columns["UPD_DATE"], DateTime.Now);
                }
                if (radioGroup1.SelectedIndex == 0)
                {
                    gridView1.SetRowCellValue(val, gridView1.Columns["Requestable"], 1);
                    gridView1.SetRowCellValue(val, gridView1.Columns["UPD_DATE"], DateTime.Now);
                }
                if (radioGroup1.SelectedIndex == 1)
                {
                    gridView1.SetRowCellValue(val, gridView1.Columns["Requestable"], 0);
                    gridView1.SetRowCellValue(val, gridView1.Columns["UPD_DATE"], DateTime.Now);
                }
            }          
           
        }

        private void checkEdit4_Click(object sender, EventArgs e)
        {
            if (!checkEdit4.Checked)
                comboBoxEdit4.Enabled = true;

            if (checkEdit4.Checked)
                comboBoxEdit4.Enabled = false; 
        }

        private void checkEdit5_Click(object sender, EventArgs e)
        {
            if (!checkEdit5.Checked)
                spinEdit3.Enabled = true;

            if (checkEdit5.Checked)
                spinEdit3.Enabled = false; 
        }

        private void checkEdit6_Click(object sender, EventArgs e)
        {
            if (!checkEdit6.Checked)
                spinEdit4.Enabled = true;

            if (checkEdit6.Checked)
                spinEdit4.Enabled = false; 
        }

        private void checkEdit7_Click(object sender, EventArgs e)
        {
            if (!checkEdit7.Checked)
                spinEdit2.Enabled = true;

            if (checkEdit7.Checked)
                spinEdit2.Enabled = false; 
        }

        private void checkEdit8_Click(object sender, EventArgs e)
        {
            if (!checkEdit8.Checked)
                spinEdit5.Enabled = true;

            if (checkEdit8.Checked)
                spinEdit5.Enabled = false; 
        }

        private void InvtCopyBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save these changes?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                gridView1.MoveFirst();
                gridView1.MoveLast();
                InvtBindingSource.EndEdit();
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

        private void checkEdit9_Click(object sender, EventArgs e)
        {
            if (!checkEdit9.Checked)
                spinEdit6.Enabled = true;

            if (checkEdit9.Checked)
                spinEdit6.Enabled = false; 
        }

        private void checkEdit10_Click(object sender, EventArgs e)
        {
            if (!checkEdit10.Checked)
                spinEdit9.Enabled = true;

            if (checkEdit10.Checked)
                spinEdit9.Enabled = false; 
        }

        private void checkEdit11_Click(object sender, EventArgs e)
        {
            if (!checkEdit11.Checked)
                spinEdit7.Enabled = true;

            if (checkEdit11.Checked)
                spinEdit7.Enabled = false; 
        }

        private void checkEdit12_Click(object sender, EventArgs e)
        {
            if (!checkEdit12.Checked)
                spinEdit8.Enabled = true;

            if (checkEdit12.Checked)
                spinEdit8.Enabled = false; 
        }     

        private void updateButton2_Click(object sender, EventArgs e)
        {
            foreach (int val in gridView1.GetSelectedRows())
            {  
                if (spinEdit6.Enabled)
                {
                    gridView1.SetRowCellValue(val, gridView1.Columns["ORIG_AMT"], spinEdit6.Text);
                    gridView1.SetRowCellValue(val, gridView1.Columns["UPD_DATE"], DateTime.Now);
                }
                if (spinEdit7.Enabled)
                {
                    gridView1.SetRowCellValue(val, gridView1.Columns["AV_AMT"], spinEdit7.Text);
                    gridView1.SetRowCellValue(val, gridView1.Columns["UPD_DATE"], DateTime.Now);
                }
                if (spinEdit8.Enabled)
                {
                    gridView1.SetRowCellValue(val, gridView1.Columns["HOLD"], spinEdit8.Text);
                    gridView1.SetRowCellValue(val, gridView1.Columns["UPD_DATE"], DateTime.Now);
                }
                if (spinEdit9.Enabled)
                {
                    gridView1.SetRowCellValue(val, gridView1.Columns["ALLOCTD"], spinEdit9.Text);
                    gridView1.SetRowCellValue(val, gridView1.Columns["UPD_DATE"], DateTime.Now);
                }
            }          
        }

        private void updateButton3_Click(object sender, EventArgs e)
        {
            colDATE.Visible = true;
            colREL.Visible = true;
            colRELAGY.Visible = true;
            colRELCAT.Visible = true;
            colRELCODE.Visible = true;
            colRELTYP.Visible = true;


            foreach (int val in gridView1.GetSelectedRows())
            {
                if (spinEdit10.Enabled)
                {
                    gridView1.SetRowCellValue(val, gridView1.Columns["REL"], spinEdit10.Text);
                    gridView1.SetRowCellValue(val, gridView1.Columns["UPD_DATE"], DateTime.Now);
                }
                if (relCodeSearch.Enabled)
                {
                    gridView1.SetRowCellValue(val, gridView1.Columns["RELCODE"], relCodeSearch.Text);
                    gridView1.SetRowCellValue(val, gridView1.Columns["UPD_DATE"], DateTime.Now);
                }
                if (relAgencySearch.Enabled)
                {
                    gridView1.SetRowCellValue(val, gridView1.Columns["RELAGY"], relAgencySearch.Text);
                    gridView1.SetRowCellValue(val, gridView1.Columns["UPD_DATE"], DateTime.Now);
                }
                if (relCatSearch.Enabled)
                {
                    gridView1.SetRowCellValue(val, gridView1.Columns["RELCAT"], relCatSearch.Text);
                    gridView1.SetRowCellValue(val, gridView1.Columns["UPD_DATE"], DateTime.Now);
                }
                if (comboBoxEdit5.Enabled)
                {
                    gridView1.SetRowCellValue(val, gridView1.Columns["RELTYP"], comboBoxEdit5.Text);
                    gridView1.SetRowCellValue(val, gridView1.Columns["UPD_DATE"], DateTime.Now);
                }
            }          

        }

        private void checkEdit13_Click(object sender, EventArgs e)
        {
            if (!checkEdit13.Checked)
                spinEdit10.Enabled = true;

            if (checkEdit13.Checked)
                spinEdit10.Enabled = false; 
        }

        private void checkEdit14_Click(object sender, EventArgs e)
        {
            if (!checkEdit14.Checked)
                relCodeSearch.Enabled = true;

            if (checkEdit14.Checked)
                relCodeSearch.Enabled = false; 
        }

        private void checkEdit15_Click(object sender, EventArgs e)
        {
            if (!checkEdit15.Checked)
                relAgencySearch.Enabled = true;

            if (checkEdit15.Checked)
                relAgencySearch.Enabled = false; 
        }

        private void checkEdit16_Click(object sender, EventArgs e)
        {
            if (!checkEdit16.Checked)
                relCatSearch.Enabled = true;

            if (checkEdit16.Checked)
                relCatSearch.Enabled = false; 
        }

        private void checkEdit17_Click(object sender, EventArgs e)
        {
            if (!checkEdit17.Checked)
                comboBoxEdit5.Enabled = true;

            if (checkEdit17.Checked)
                comboBoxEdit5.Enabled = false; 
        }

        private void relCatSearch_Enter(object sender, EventArgs e)
        {
            relCatSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        private void relCatSearch_ItemSelected()
        {
            relCatSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        private void relCodeSearch_Enter(object sender, EventArgs e)
        {
            relCodeSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        private void relCodeSearch_ItemSelected()
        {
            relCodeSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        private void relAgencySearch_Enter(object sender, EventArgs e)
        {
            relAgencySearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        private void relAgencySearch_ItemSelected()
        {
            relAgencySearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        void ButtonEdit_QueryPopUp(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
        }


        private void dateEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void dateEdit1_TextChanged(object sender, EventArgs e)
        {
            dateEdit1.Text = validCheck.convertDate(dateEdit1.Text);
        }

        private void dateEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void dateEdit2_TextChanged(object sender, EventArgs e)
        {
            dateEdit2.Text = validCheck.convertDate(dateEdit2.Text);
        }

    }
}