using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using FlexModel;
using DevExpress.XtraEditors.Controls;
using System.Linq;
using System.Globalization;
using System.Runtime.InteropServices;
namespace TraceForms
{
    
    public partial class DigItmForm : DevExpress.XtraEditors.XtraForm
    {
        
        public string coupRes;
        public string coupMonth;
        public string coupYear;
        public string coupCode;
        public string lineNO;
        public string currentVal;
        public bool modified;
        public bool newRec;
        public bool addNew;
        public bool refresh;
        public bool cancelled;
        public FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public string username;
        public DigItmForm(string value, FlextourEntities cont, string line, string user)
        {
            InitializeComponent();
            //Connection.EFConnectionString = _sys.Settings.EFConnectionString;
            //context = new FlextourEntities(Connection.EFConnectionString);
            context = cont;
            modified = false;
            newRec = false;
            refresh = false;
            cancelled = false;
            itemCodeSearch.ButtonEdit.TextChanged += ButtonEdit_TextChanged;
            labelControl12.Text = value;
            int val = Convert.ToInt32(value);
            int line_no = Convert.ToInt16(line);
            coupRes = value;
            lineNO = line;
            DigItmBindingSource.DataSource = from c in context.DIGITM where c.COUP_RES == val && c.LINE_NO == line_no select c;
            //CITYCOD
            gsLoad.gridSearchLoad(officeSearch, "CODE", "NAME", "Code", "Description", "CODE", "CODE", "CODE", DigItmBindingSource, "CAR_OFF");
            officeSearch.GridControl.DataSource = context.CITYCOD;

            //CITYCOD
            gsLoad.gridSearchLoad(pickupSearch, "CODE", "NAME", "Code", "Description", "CODE", "CODE", "CODE", DigItmBindingSource, "PUP_OFF");
            pickupSearch.GridControl.DataSource =  context.CITYCOD;

            //CITYCOD
            gsLoad.gridSearchLoad(dropOffSearch, "CODE", "NAME", "Code", "Description", "CODE", "CODE", "CODE", DigItmBindingSource, "DRP_OFF");
            dropOffSearch.GridControl.DataSource =  context.CITYCOD;
            
            //CODE
            gsLoad.gridSearchLoad(codeSearch, "CODE", "NAME", "Code", "Description", "CODE", "CODE", "NAME", DigItmBindingSource, "CODE");

            //ROOMCOD
            gsLoad.gridSearchLoad(catSearch, "CODE", "DESC", "Code", "Description", "CODE", "CODE", "CODE", DigItmBindingSource, "CAT");
            catSearch.GridControl.DataSource = context.ROOMCOD;

            //MEALCOD 
            gsLoad.gridSearchLoad(mealSearch, "CODE", "DESC", "Code", "Description", "CODE", "CODE", "CODE", DigItmBindingSource, "MEALS");
            mealSearch.GridControl.DataSource = context.MEALCOD;

            //OPER
            gsLoad.gridSearchLoad(operatorSearch, "CODE", "NAME", "Code", "Description", "CODE", "CODE", "CODE", DigItmBindingSource, "OPER");
            operatorSearch.GridControl.DataSource =  context.OPERATOR;
           
            //Origin arv
            gsLoad.gridSearchLoad(arvOriginSearch, "CODE", "NAME", "Code", "Description", "CODE", "CODE", "CODE", DigItmBindingSource, "ARV_FRM");
            arvOriginSearch.GridControl.DataSource = context.CITYCOD;
           
            //Origin dep
            gsLoad.gridSearchLoad(depOriginSearch, "CODE", "NAME", "Code", "Description", "CODE", "CODE", "CODE", DigItmBindingSource, "DEP_FRM");
            depOriginSearch.GridControl.DataSource = context.CITYCOD;
           
            //Dest arv
            gsLoad.gridSearchLoad(arvDestinationSearch, "CODE", "NAME", "Code", "Description", "CODE", "CODE", "CODE", DigItmBindingSource, "ARV_TO");
            arvDestinationSearch.GridControl.DataSource = context.CITYCOD;
           
            //Dest dep
            gsLoad.gridSearchLoad(depDestinationSearch, "CODE", "NAME", "Code", "Description", "CODE", "CODE", "CODE", DigItmBindingSource, "DEP_TO");
            depDestinationSearch.GridControl.DataSource = context.CITYCOD;
           
            //ITEM CODE
            gsLoad.gridSearchLoad(itemCodeSearch, "CODE", "NAME", "Code", "Description", "CODE", "CODE", "CODE", DigItmBindingSource, "ITM_CODE");
            
            username = user;
                                                 
        }

        public DigItmForm(string value, FlextourEntities cont, int line, string user, string coupm, string coupy, string coupc)
        {
            InitializeComponent();
            //Connection.EFConnectionString = _sys.Settings.EFConnectionString;
            //context = new FlextourEntities(Connection.EFConnectionString);
            context = cont;
            modified = false;
            newRec = true; ;
            refresh = false;
            cancelled = false;
            itemCodeSearch.ButtonEdit.TextChanged += ButtonEdit_TextChanged;
            //labelControl12.Text = value;
            int val = Convert.ToInt32(value);
            //int line_no = Convert.ToInt16(line);
            string line1 = Convert.ToString(line);
            DigItmBindingSource.DataSource = context.DIGITM.Take(1000);
            DigItmBindingSource.AddNew();
 
           
           

            //CITYCOD
            gsLoad.gridSearchLoad(officeSearch, "CODE", "NAME", "Code", "Description", "CODE", "CODE", "CODE", DigItmBindingSource, "CAR_OFF");
            officeSearch.GridControl.DataSource = context.CITYCOD;

            //CITYCOD
            gsLoad.gridSearchLoad(pickupSearch, "CODE", "NAME", "Code", "Description", "CODE", "CODE", "CODE", DigItmBindingSource, "PUP_OFF");
            pickupSearch.GridControl.DataSource = context.CITYCOD;

            //CITYCOD
            gsLoad.gridSearchLoad(dropOffSearch, "CODE", "NAME", "Code", "Description", "CODE", "CODE", "CODE", DigItmBindingSource, "DRP_OFF");
            dropOffSearch.GridControl.DataSource = context.CITYCOD;

            //CODE
            gsLoad.gridSearchLoad(codeSearch, "CODE", "NAME", "Code", "Description", "CODE", "CODE", "NAME", DigItmBindingSource, "CODE");

            //ROOMCOD
            gsLoad.gridSearchLoad(catSearch, "CODE", "DESC", "Code", "Description", "CODE", "CODE", "CODE", DigItmBindingSource, "CAT");
            catSearch.GridControl.DataSource = context.ROOMCOD;

            //MEALCOD 
            gsLoad.gridSearchLoad(mealSearch, "CODE", "DESC", "Code", "Description", "CODE", "CODE", "CODE", DigItmBindingSource, "MEALS");
            mealSearch.GridControl.DataSource = context.MEALCOD;

            //OPER
            gsLoad.gridSearchLoad(operatorSearch, "CODE", "NAME", "Code", "Description", "CODE", "CODE", "CODE", DigItmBindingSource, "OPER");
            operatorSearch.GridControl.DataSource = context.OPERATOR;

            //Origin arv
            gsLoad.gridSearchLoad(arvOriginSearch, "CODE", "NAME", "Code", "Description", "CODE", "CODE", "CODE", DigItmBindingSource, "ARV_FRM");
            arvOriginSearch.GridControl.DataSource = context.CITYCOD;

            //Origin dep
            gsLoad.gridSearchLoad(depOriginSearch, "CODE", "NAME", "Code", "Description", "CODE", "CODE", "CODE", DigItmBindingSource, "DEP_FRM");
            depOriginSearch.GridControl.DataSource = context.CITYCOD;

            //Dest arv
            gsLoad.gridSearchLoad(arvDestinationSearch, "CODE", "NAME", "Code", "Description", "CODE", "CODE", "CODE", DigItmBindingSource, "ARV_TO");
            arvDestinationSearch.GridControl.DataSource = context.CITYCOD;

            //Dest dep
            gsLoad.gridSearchLoad(depDestinationSearch, "CODE", "NAME", "Code", "Description", "CODE", "CODE", "CODE", DigItmBindingSource, "DEP_TO");
            depDestinationSearch.GridControl.DataSource = context.CITYCOD;

            //ITEM CODE
            gsLoad.gridSearchLoad(itemCodeSearch, "CODE", "NAME", "Code", "Description", "CODE", "CODE", "CODE", DigItmBindingSource, "ITM_CODE");

            username = user;  
            coupRes = value;
            lineNO = line1;
            coupMonth = coupm;
            coupYear = coupy;
            coupCode = coupc;
        }
        void setRecord()
        {
          
            labelControl12.Text = coupRes;
            labelControl13.Text = lineNO;
            labelControl5.Text = coupMonth;
            labelControl6.Text = coupYear;
            labelControl7.Text = coupCode;
          
        }
        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        void ButtonEdit_TextChanged(object sender, EventArgs e)
        {
            if (iTM_TYPEComboBoxEdit.Text == "CRU" || iTM_TYPEComboBoxEdit.Text == "AIR" || iTM_TYPEComboBoxEdit.Text == "HTL" || iTM_TYPEComboBoxEdit.Text == "OPT" || iTM_TYPEComboBoxEdit.Text == "CAR")
            {
                codeSearch.ButtonEdit.Properties.ReadOnly = false;           
                codeSearch.Text = itemCodeSearch.Text;           
            }
        }

        private void iTM_TYPEComboBoxEdit_TextChanged(object sender, EventArgs e)
        {
            itemCodeSearch.GridControl.DataSource = null;
            if (iTM_TYPEComboBoxEdit.Text == "HTL")
            {
                xtraTabPage2.PageEnabled = true;
                xtraTabPage3.PageEnabled = false;
                tYPComboBoxEdit.Text = "HTL";
                tYPComboBoxEdit.Properties.ReadOnly = true;
                codeSearch.ButtonEdit.Properties.ReadOnly = true;
                itemCodeSearch.GridControl.DataSource = context.HOTEL;

            }
            if (iTM_TYPEComboBoxEdit.Text == "PKG")
            {
                xtraTabPage2.PageEnabled = false;
                xtraTabPage3.PageEnabled = false;              
                tYPComboBoxEdit.Properties.ReadOnly = false;
                codeSearch.ButtonEdit.Properties.ReadOnly = false;
                itemCodeSearch.GridControl.DataSource = context.PACK ;

            }
            if (iTM_TYPEComboBoxEdit.Text == "CAR")
            {
                xtraTabPage2.PageEnabled = false;
                xtraTabPage3.PageEnabled = true;
                tYPComboBoxEdit.Text = "CAR";
                tYPComboBoxEdit.Properties.ReadOnly = true;
                codeSearch.ButtonEdit.Properties.ReadOnly = true;
                itemCodeSearch.GridControl.DataSource = context.CARINFO ;

            }
            if (iTM_TYPEComboBoxEdit.Text == "OPT")
            {
                xtraTabPage2.PageEnabled = false;
                xtraTabPage3.PageEnabled = false;
                tYPComboBoxEdit.Text = "OPT";
                tYPComboBoxEdit.Properties.ReadOnly = true;
                codeSearch.ButtonEdit.Properties.ReadOnly = true;
                itemCodeSearch.GridControl.DataSource =context.COMP ;

                
            }
            if (iTM_TYPEComboBoxEdit.Text == "CRU")
            {
                xtraTabPage2.PageEnabled = true;
                xtraTabPage3.PageEnabled = false;
                tYPComboBoxEdit.Text = "CRU";
                tYPComboBoxEdit.Properties.ReadOnly = true;
                codeSearch.ButtonEdit.Properties.ReadOnly = true;
                itemCodeSearch.GridControl.DataSource = context.CRU ;

            }
            if (iTM_TYPEComboBoxEdit.Text == "AIR")
            {
                xtraTabPage2.PageEnabled = false;
                xtraTabPage3.PageEnabled = false;
                tYPComboBoxEdit.Text = "AIR";
                tYPComboBoxEdit.Properties.ReadOnly = true;
                codeSearch.ButtonEdit.Properties.ReadOnly = true;
                itemCodeSearch.GridControl.DataSource =context.AIR ;

            }
        }

        private void tYPComboBoxEdit_TextChanged(object sender, EventArgs e)
        {
            codeSearch.GridControl.DataSource = null;

            if (tYPComboBoxEdit.Text == "HTL" && iTM_TYPEComboBoxEdit.Text == "PKG")
            {               
                codeSearch.GridControl.DataSource = context.HOTEL;
            }
            if (tYPComboBoxEdit.Text == "CAR" && iTM_TYPEComboBoxEdit.Text == "PKG")
            {               
                codeSearch.GridControl.DataSource = context.CARINFO;
            }
            if (tYPComboBoxEdit.Text == "OPT" && iTM_TYPEComboBoxEdit.Text == "PKG")
            {                
                codeSearch.GridControl.DataSource = context.COMP;
            }
            if (tYPComboBoxEdit.Text == "CRU" && iTM_TYPEComboBoxEdit.Text == "PKG")
            {               
                codeSearch.GridControl.DataSource = context.CRU;
            }
            if (tYPComboBoxEdit.Text == "AIR" && iTM_TYPEComboBoxEdit.Text == "PKG")
            {
                codeSearch.GridControl.DataSource =  context.AIR;
            }
        }

        private void gridSearchControl1_Enter(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
            officeSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        void ButtonEdit_QueryPopUp(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
        }

        private void gridSearchControl2_Enter(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
            pickupSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        private void gridSearchControl3_Enter(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
            dropOffSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        private void gridSearchControl4_Enter(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
            codeSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        private void gridSearchControl5_Enter(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
            catSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        private void gridSearchControl6_Enter(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
            mealSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        private void gridSearchControl7_Enter(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
            operatorSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        private void gridSearchControl8_Enter(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
            arvOriginSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        private void gridSearchControl9_Enter(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
            depOriginSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        private void gridSearchControl10_Enter(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
            arvDestinationSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        private void gridSearchControl11_Enter(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
            depDestinationSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        private void gridSearchControl12_Enter(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
            itemCodeSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        private void gridSearchControl1_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkCarOff, DigItmBindingSource);
        }

        private void gridSearchControl2_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkCarPup, DigItmBindingSource);
        }

        private void gridSearchControl3_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkCarDrp, DigItmBindingSource);
        }

        private void gridSearchControl4_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkCODE, DigItmBindingSource);
        }

        private void gridSearchControl5_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkCat, DigItmBindingSource);
        }

        private void gridSearchControl6_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkMeals, DigItmBindingSource);
        }

        private void gridSearchControl7_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkOperator, DigItmBindingSource);
        }

        private void gridSearchControl8_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkArvFrm, DigItmBindingSource);
        }

        private void gridSearchControl9_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkDepFrm, DigItmBindingSource);
        }

        private void gridSearchControl10_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkArvTo, DigItmBindingSource);
        }

        private void gridSearchControl11_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkDepTo, DigItmBindingSource);
        }

        private void gridSearchControl12_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkItmCODE, DigItmBindingSource);           
        }    

        private void gridSearchControl8_ItemSelected()
        {
            arvOriginSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        private void gridSearchControl12_ItemSelected()
        {
            itemCodeSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;           
        }

        private void digItmSav_Click(object sender, EventArgs e)
        {
            DigItmBindingSource.EndEdit();
            context.SaveChanges();
            this.Close();
            //regular save button routine
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iTM_TYPEComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkItmType, DigItmBindingSource);
        }

        private void dATE_MDYDateEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            //validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current)., DigItmBindingSource);
            
        }

        private void tYPComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkType, DigItmBindingSource);
        }

        private void nBR_PAXSpinEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkNbrPax, DigItmBindingSource);
        }

        private void tOUR_TIMEImageComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkTourTime, DigItmBindingSource);
        }

        private void cONFIRMTextEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            //validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkOff, DigItmBindingSource);
        }

        private void rM_TYPComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkRmTyp, DigItmBindingSource);
        }

        private void rM_TYP2ComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkRmTyp2, DigItmBindingSource);
        }

        private void rM_TYP3ComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkRmTyp3, DigItmBindingSource);
        }

        private void rM_TYP4ComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkRmTyp4, DigItmBindingSource);
        }

        private void nBR_RMSSpinEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkNbrRms, DigItmBindingSource);
        }

        private void nBR_RMS2SpinEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkNbrRms2, DigItmBindingSource);
        }

        private void nBR_RMS3SpinEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkNbrRms3, DigItmBindingSource);
        }

        private void nBR_RMS4SpinEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkNbrRms4, DigItmBindingSource);
        }

        private void nTSSpinEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            //validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current), DigItmBindingSource);
        }

        private void oTH_DESCTextEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            //validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current)., DigItmBindingSource);
        }

        private void cAR_DAYSSpinEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            //validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkOff, DigItmBindingSource);
        }

        private void cAR_DRVR1TextEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            //validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkOff, DigItmBindingSource);
        }

        private void cAR_DRVR2TextEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            //validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkOff, DigItmBindingSource);
        }

        private void cAR_DRVR3TextEdit_Leave(object sender, EventArgs e)
        {

            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            //validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkOff, DigItmBindingSource);
        }

        private void aRV_DATEDateEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            //validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkOff, DigItmBindingSource);
        }

        private void dEP_DATEDateEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            //validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkOff, DigItmBindingSource);
        }

        private void aRV_FLTTextEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            //validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkOff, DigItmBindingSource);
        }

        private void dEP_FLTTextEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            //validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkOff, DigItmBindingSource);
        }

        private void aRV_LV_TIMETimeEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            //validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkOff, DigItmBindingSource);
        }

        private void dEP_TIMETimeEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            //validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkOff, DigItmBindingSource);
        }

        private void aRV_TIMETimeEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            //validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkOff, DigItmBindingSource);
        }

        private void dEP_AV_TIMETimeEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            //validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkOff, DigItmBindingSource);
        }

        private void aRV_TXFRComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkArvTfr, DigItmBindingSource);
        }

        private void dEP_TXFRComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl9.Text = DateTime.Today.ToShortDateString();
                labelControl59.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((DIGITM)DigItmBindingSource.Current).checkDepTfr, DigItmBindingSource);
        }


        private void DigItmForm_Load(object sender, EventArgs e)
        {
            if(newRec == true)
                setRecord();
        }

     
        private static string GetMonthName(int month)
        {
            DateTime date = new DateTime(1900, month, 1);
            return date.ToString("MMM");
            
        }

     

        private void dATE_MDYDateEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void dATE_MDYDateEdit_TextChanged(object sender, EventArgs e)
        {
            dATE_MDYDateEdit.Text = validCheck.convertDate(dATE_MDYDateEdit.Text);
        }

        private void aRV_DATEDateEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void aRV_DATEDateEdit_TextChanged(object sender, EventArgs e)
        {
            aRV_DATEDateEdit.Text = validCheck.convertDate(aRV_DATEDateEdit.Text);
        }

        private void dEP_DATEDateEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void dEP_DATEDateEdit_TextChanged(object sender, EventArgs e)
        {
            dEP_DATEDateEdit.Text = validCheck.convertDate(dEP_DATEDateEdit.Text);
        }

        private void DigItmForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (modified || newRec)
            {
                DialogResult select = DevExpress.XtraEditors.XtraMessageBox.Show("There are unsaved changes. Are you sure want to exit?", Name, MessageBoxButtons.YesNo);
                if (select == DialogResult.Yes)
                {
                    e.Cancel = false;
                    this.Dispose();
                }
                else if (select == DialogResult.No)
                    e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                this.Dispose();
            }
        }

     

    }
}