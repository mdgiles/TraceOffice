using FlexModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using System.Linq;

using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Data.Entity.Core.Objects;
using DevExpress.Xpo;
using System.Linq.Dynamic;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using System.Runtime.InteropServices;
namespace TraceForms
{
    
    public partial class PCompForm : DevExpress.XtraEditors.XtraForm
    {
        public string username;
       public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public FlextourEntities context;
        public ImageComboBoxItemCollection hotelVals ;
        public ImageComboBoxItemCollection airportVals;
        public ImageComboBoxItemCollection compVals;

        public ImageComboBoxItemCollection airVals;
        public ImageComboBoxItemCollection cruVals;
        public ImageComboBoxItemCollection carVals;
        public ImageComboBoxItemCollection wayVals;
        public ImageComboBoxItemCollection trnVals;
        public ImageComboBoxItemCollection ctyVals;
        public ImageComboBoxItemCollection busVals;
        
        public PCompForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
            
            LoadLookups();
           
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);
            username = sys.User.Name;
        }

        private void LoadLookups()
        {
            hotelVals = new ImageComboBoxItemCollection(ImageComboBoxEditTypeCode.Properties);
            airportVals = new ImageComboBoxItemCollection(ImageComboBoxEditTypeCode.Properties);
            compVals = new ImageComboBoxItemCollection(ImageComboBoxEditTypeCode.Properties);
            cruVals = new ImageComboBoxItemCollection(ImageComboBoxEditTypeCode.Properties);
            airVals = new ImageComboBoxItemCollection(ImageComboBoxEditTypeCode.Properties);
            carVals = new ImageComboBoxItemCollection(ImageComboBoxEditTypeCode.Properties);
            wayVals = new ImageComboBoxItemCollection(ImageComboBoxEditTypeCode.Properties);
            trnVals = new ImageComboBoxItemCollection(ImageComboBoxEditTypeCode.Properties);
            ctyVals = new ImageComboBoxItemCollection(ImageComboBoxEditTypeCode.Properties);
            busVals = new ImageComboBoxItemCollection(ImageComboBoxEditTypeCode.Properties);

            var bus = from busRec in context.BusStation orderby busRec.Code ascending select new { busRec.Code, busRec.Name };
            var way = from wayRec in context.WAYPOINT orderby wayRec.CODE ascending select new { wayRec.CODE, wayRec.DESC };
            var trn = from trnRec in context.TrainStation orderby trnRec.Code ascending select new { trnRec.Code, trnRec.Name };
            var opr = from operRec in context.OPERATOR orderby operRec.CODE ascending select new { operRec.CODE, operRec.NAME };
            var cty = from ctyRec in context.CITYCOD orderby ctyRec.CODE ascending select new { ctyRec.CODE, ctyRec.NAME };
            var pck = from pckRec in context.PACK orderby pckRec.CODE ascending select new { pckRec.CODE, pckRec.NAME };
            var cat = from catRec in context.ROOMCOD orderby catRec.CODE ascending select new { catRec.CODE, catRec.DESC };
            var meal = from mealRec in context.MEALCOD orderby mealRec.CODE ascending select new { mealRec.CODE, mealRec.DESC };
            var carOff = from carOffice in context.CAROFF orderby carOffice.CODE ascending select new { carOffice.OFF, carOffice.NAME };
            var hotel = from hotRec in context.HOTEL orderby hotRec.CODE ascending select new { hotRec.CODE, hotRec.NAME };
            var comp = from compRec in context.COMP orderby compRec.CODE ascending select new { compRec.CODE, compRec.NAME };
            var air = from airRec in context.AIR orderby airRec.CODE ascending select new { airRec.CODE, airRec.NAME };
            var cru = from cruRec in context.CRU orderby cruRec.CODE ascending select new { cruRec.CODE, cruRec.NAME };
            var car = from carRec in context.CARINFO orderby carRec.CODE ascending select new { carRec.CODE, carRec.NAME };
            var airports = from portRec in context.Airport orderby portRec.Code ascending select new { portRec.Code, portRec.Name };
            // 
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = string.Empty };
            ImageComboBoxEditOffice.Properties.Items.Add(loadBlank);
            busVals.Add(loadBlank);
            wayVals.Add(loadBlank);
            trnVals.Add(loadBlank);
            compVals.Add(loadBlank);
            carVals.Add(loadBlank);
            airVals.Add(loadBlank);
            cruVals.Add(loadBlank);
            ImageComboBoxEditOperator.Properties.Items.Add(loadBlank);
            ctyVals.Add(loadBlank);
            ImageComboBoxEditDepartureSearch.Properties.Items.Add(loadBlank);
            ImageComboBoxEditDepartureDestinationSearch.Properties.Items.Add(loadBlank);
            ImageComboBoxEditArrivalSearch.Properties.Items.Add(loadBlank);
            ImageComboBoxEditArrivalDestinationSearch.Properties.Items.Add(loadBlank);
            hotelVals.Add(loadBlank);
            airportVals.Add(loadBlank);
            ImageComboBoxEditMealCode.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCategory.Properties.Items.Add(loadBlank);
            ImageComboBoxEditTypeCategory.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCode.Properties.Items.Add(loadBlank);
            foreach (var result in carOff)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.OFF.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.OFF.TrimEnd() };
               
                ImageComboBoxEditOffice.Properties.Items.Add(load);

                //ImageComboBoxEditOperator.Properties.Items.Add(load);
            }

            foreach (var result in bus)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.Code.TrimEnd() + "  " + "(" + result.Name.TrimEnd() + ")", Value = result.Code.TrimEnd() };
                busVals.Add(load);
                //ImageComboBoxEditOperator.Properties.Items.Add(load);
            }
            foreach (var result in way)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.DESC.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                wayVals.Add(load);
            }
            foreach (var result in trn)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.Code.TrimEnd() + "  " + "(" + result.Name.TrimEnd() + ")", Value = result.Code.TrimEnd() };
                trnVals.Add(load);
            }

            foreach (var result in comp)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                compVals.Add(load);
                //ImageComboBoxEditOperator.Properties.Items.Add(load);
            }

            foreach (var result in car)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                carVals.Add(load);
                //ImageComboBoxEditOperator.Properties.Items.Add(load);
            }

            foreach (var result in air)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                airVals.Add(load);
                //ImageComboBoxEditOperator.Properties.Items.Add(load);
            }

            foreach (var result in cru)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                cruVals.Add(load);
                //ImageComboBoxEditOperator.Properties.Items.Add(load);
            }

            foreach (var result in opr)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditOperator.Properties.Items.Add(load);
            }
            
            foreach (var result in cty)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ctyVals.Add(load);
                ImageComboBoxEditDepartureSearch.Properties.Items.Add(load);
                ImageComboBoxEditDepartureDestinationSearch.Properties.Items.Add(load);
                ImageComboBoxEditArrivalSearch.Properties.Items.Add(load);
                ImageComboBoxEditArrivalDestinationSearch.Properties.Items.Add(load);
            }
            foreach (var result in hotel)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                hotelVals.Add(load);
                //ImageComboBoxEditOperator.Properties.Items.Add(load);
            }

            foreach (var result in airports)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.Code.TrimEnd() + "  " + "(" + result.Name.TrimEnd() + ")", Value = result.Code.TrimEnd() };
                airportVals.Add(load);
                //ImageComboBoxEditOperator.Properties.Items.Add(load);
            }

            foreach (var result in meal)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.DESC.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditMealCode.Properties.Items.Add(load);
            }

            foreach (var result in cat)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.DESC.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCategory.Properties.Items.Add(load);
                ImageComboBoxEditTypeCategory.Properties.Items.Add(load);
            }

            foreach (var result in pck)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCode.Properties.Items.Add(load);
            }
            ImageComboBoxEditPickupSearch.Properties.Items.AddRange(hotelVals);
            ImageComboBoxEditDropoffSearch.Properties.Items.AddRange(hotelVals);
            setReadOnly(true);
            enableNavigator(false);
        }

        private void setReadOnly(bool value)
        {
            ImageComboBoxEditCode.Properties.ReadOnly = value;
            ImageComboBoxEditCategory.Properties.ReadOnly = value;
            dAYSpinEdit.Properties.ReadOnly = value;
            lINESpinEdit.Properties.ReadOnly = value;        
        }

        private void setValues()
        {
            advBandedGridView1.SetFocusedRowCellValue("DAY", 1);
            advBandedGridView1.SetFocusedRowCellValue("LINE", 1);
            advBandedGridView1.SetFocusedRowCellValue("CODE", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("CAT", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("TYPE", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("CODE1", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("CAT1", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("ROOM", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("TOUR_TIME", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("INV_UPD", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("NTS", 0);
            advBandedGridView1.SetFocusedRowCellValue("CHK_OUT", "N");
            advBandedGridView1.SetFocusedRowCellValue("MEALS", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("OPER", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("PRV_CAR", "N");
            advBandedGridView1.SetFocusedRowCellValue("ARV_FRM", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("ARV_TO", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("ARV_FLT", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("ARV_LV_TIME", string.Empty);           
            advBandedGridView1.SetFocusedRowCellValue("ARV_TIME", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("ARV_TRNFR", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("DEP_FRM", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("DEP_TO", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("DEP_FLT", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("DEP_TIME", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("DEP_AV_TIME", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("DEP_TRNFR", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("CAR_OFF", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("PUP_OFF", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("DRP_OFF", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("DATAFLEX_FILL_01", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("Special_Value", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("Bus_Pup_Type", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("Bus_Drp_Type", string.Empty);
         
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            labelControlPackType.Text = string.Empty;
            advBandedGridView1.ClearColumnsFilter();
            if (PCompBindingSource.Current == null)
            {
                PCompBindingSource.DataSource = from pcompRec in context.PCOMP where pcompRec.CODE1 == "KJ9M" select pcompRec;
                PCompBindingSource.AddNew();
                ImageComboBoxEditCode.Focus();
                setReadOnly(false);
                newRec = true;
                setValues();
               
                
                return;
            }
            ImageComboBoxEditCode.Focus();

           //bindingNavigatorPositionItem.Focus();  //trigger field leave event          
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (PCOMP)PCompBindingSource.Current);
                PCompBindingSource.AddNew();
                ImageComboBoxEditCode.Focus();
                setReadOnly(false);
                newRec = true;
                setValues();
                
            }
          
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (PCompBindingSource.Current == null)
                return;
            
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                modified = false;
                newRec = false;
                PCompBindingSource.RemoveCurrent();
                errorProvider1.Clear();
                context.SaveChanges();
                setReadOnly(true);
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);

            }
            currentVal = ImageComboBoxEditCode.Text;
            ImageComboBoxEditCode.Focus();
            modified = false;
            newRec = false;
        }


        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }

        private bool checkForms()
        {
            if (!modified && !newRec)
                return true;

            bool ok1 = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((PCOMP)PCompBindingSource.Current).checkAll, PCompBindingSource);
          
            if (ok1 )
                return validCheck.saveRec(ref modified, true, ref newRec, context, PCompBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, PCompBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }


        private void pCOMPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            ImageComboBoxEditCode.Focus();
            if (PCompBindingSource.Current == null)
                return;
            if (checkOverlappingHotels())
            {
                bool temp = newRec;
                if (checkForms())
                {
                    setReadOnly(true);
                    panelControlStatus.Visible = true;
                    LabelStatus.Text = "Record Saved";
                    rowStatusSave = new Timer();
                    rowStatusSave.Interval = 3000;
                    rowStatusSave.Start();
                    rowStatusSave.Tick += TimedEventSave;
                }

                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (PCOMP)PCompBindingSource.Current);
               
            }
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool move()
        {
            
          
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (PCOMP)PCompBindingSource.Current);
                setReadOnly(true);
                newRec = false;
                modified = false;
                return true;
            }
            return false;
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (move())
                PCompBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                PCompBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                PCompBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                PCompBindingSource.MoveLast();
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            temp = newRec;
            if (!temp && checkForms())
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (PCOMP)PCompBindingSource.Current);
           // setReadOnly(true);
        }

        private void PCompForm_FormClosing(object sender, FormClosingEventArgs e)
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
        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

      
        private void rOOMComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl14.Text = DateTime.Today.ToShortDateString();
                labelControl13.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((PCOMP)PCompBindingSource.Current).checkRmTyp, PCompBindingSource);
        }

        private void tOUR_TIMEImageComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl14.Text = DateTime.Today.ToShortDateString();
                labelControl13.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((PCOMP)PCompBindingSource.Current).checkTourTime, PCompBindingSource);
        }

        private void iNV_UPDImageComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl14.Text = DateTime.Today.ToShortDateString();
                labelControl13.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((PCOMP)PCompBindingSource.Current).checkInvtUpd, PCompBindingSource);
        }

        private void gridSearchControl7_Leave(object sender, EventArgs e)
        {
            
        }

        private void gridSearchControl5_Leave(object sender, EventArgs e)
        {
           
        }

        private void gridSearchControl6_Leave(object sender, EventArgs e)
        {
            
        }

        private void gridSearchControl8_Leave(object sender, EventArgs e)
        {
            
        }

        private void gridSearchControl9_Leave(object sender, EventArgs e)
        {
            
        }

        private void dEP_FLTTextEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl14.Text = DateTime.Today.ToShortDateString();
                labelControl13.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((PCOMP)PCompBindingSource.Current).checkDepFlt, PCompBindingSource);
        }

        private void dEP_TIMETimeEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl14.Text = DateTime.Today.ToShortDateString();
                labelControl13.Text = username;
            }
            //validCheck.check(sender, errorProvider1, ((PCOMP)pCOMPBindingSource.Current).checkCode, pCOMPBindingSource);
        }

        private void dEP_AV_TIMETimeEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl14.Text = DateTime.Today.ToShortDateString();
                labelControl13.Text = username;
            }
            //validCheck.check(sender, errorProvider1, ((PCOMP)pCOMPBindingSource.Current).checkCode, pCOMPBindingSource);
        }

        private void dEP_TRNFRComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl14.Text = DateTime.Today.ToShortDateString();
                labelControl13.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((PCOMP)PCompBindingSource.Current).checkDepTrnfr, PCompBindingSource);
        }

        private void gridSearchControl10_Leave(object sender, EventArgs e)
        {
            
        }

        private void gridSearchControl11_Leave(object sender, EventArgs e)
        {
            
        }

        private void aRV_FLTTextEdit_Leave(object sender, EventArgs e)
        {
            if (PCompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl14.Text = DateTime.Today.ToShortDateString();
                    labelControl13.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((PCOMP)PCompBindingSource.Current).checkArvFlt, PCompBindingSource);
            }
             
        }

        private void aRV_LV_TIMETimeEdit_Leave(object sender, EventArgs e)
        {
            if (PCompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl14.Text = DateTime.Today.ToShortDateString();
                    labelControl13.Text = username;
                }
                //validCheck.check(sender, errorProvider1, ((PCOMP)pCOMPBindingSource.Current).checkCode, pCOMPBindingSource);
        
            }
        }

        private void aRV_TIMETimeEdit_Leave(object sender, EventArgs e)
        {
            if (PCompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl14.Text = DateTime.Today.ToShortDateString();
                    labelControl13.Text = username;
                }
                //validCheck.check(sender, errorProvider1, ((PCOMP)pCOMPBindingSource.Current)., pCOMPBindingSource);
            }
        }

        private void aRV_TRNFRComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (PCompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl14.Text = DateTime.Today.ToShortDateString();
                    labelControl13.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((PCOMP)PCompBindingSource.Current).checkArvTrnfr, PCompBindingSource);
            }
        }

     

        private void advBandedGridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
           
            if (newRec == true)
            {
                e.Allow = false;                
                return;
            }

            temp = newRec;
            bool temp2 = modified;

            if (PCompBindingSource.Current == null)
            {
                e.Allow = true;
                return;
            }

            if (checkForms())
            {
                errorProvider1.Clear();
                e.Allow = true;
                if ((!temp) && temp2)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (PCOMP)PCompBindingSource.Current);
                setReadOnly(true);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (PCOMP)PCompBindingSource.Current);
               
                e.Allow = false;
            }
        

        }

        private void PCompForm_Load(object sender, EventArgs e)
        {
          
        }

        private void checkTypeComboCode()
        {

            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = string.Empty };

            ImageComboBoxEditTypeCode.Properties.Items.Clear();
            ImageComboBoxEditTypeCode.Properties.Items.Add(loadBlank);
            if (tYPEComboBoxEdit.Text.TrimEnd() == "HTL")
            {
                ImageComboBoxEditTypeCode.Properties.Items.AddRange(hotelVals);


                ////
                //others
                tOUR_TIMEImageComboBoxEdit.Enabled = false;
                rOOMComboBoxEdit.Enabled = true;
                ImageComboBoxEditMealCode.Enabled = true;
                pRV_CARCheckEdit.Enabled = false;
                cHK_OUTCheckEdit.Enabled = true;
                iNV_UPDImageComboBoxEdit.Enabled = true;


                ///////////// pickup/dropoff
                ImageComboBoxEditOffice.Enabled = false;
                ImageComboBoxEditPickupSearch.Enabled = false;
                ImageComboBoxEditDropoffSearch.Enabled = false;
                bus_Drp_TypeComboBoxEdit.Enabled = false;
                bus_Pup_TypeComboBoxEdit.Enabled = false;

                ////////////////////////departure                
                ImageComboBoxEditDepartureSearch.Enabled = false;
                ImageComboBoxEditDepartureDestinationSearch.Enabled = false;
                dEP_FLTTextEdit.Enabled = false;
                dEP_TIMETextEdit.Enabled = false;
                dEP_AV_TIMETextEdit.Enabled = false;
                dEP_TRNFRComboBoxEdit.Enabled = false;

                ///////arrival
                ImageComboBoxEditArrivalSearch.Enabled = false;
                ImageComboBoxEditArrivalDestinationSearch.Enabled = false;
                aRV_FLTTextEdit.Enabled = false;
                aRV_LV_TIMETextEdit.Enabled = false;
                aRV_TIMETextEdit.Enabled = false;
                aRV_TRNFRComboBoxEdit.Enabled = false;
                nTSSpinEdit.Enabled = true;



                //If type =  ‘htl’ then tour time and Private car checkbox are greyed.
                //Pickup/DropOff info, Arrival info, Departure info buttons are disabled.
            }

            if (tYPEComboBoxEdit.Text.TrimEnd() == "OPT")
            {
                ImageComboBoxEditTypeCode.Properties.Items.AddRange(compVals);

                //If type = ‘ opt’ then Room/cabin type, check out time are greyed.
                //See above for the which buttons are enabled/disabled.
                //others
                tOUR_TIMEImageComboBoxEdit.Enabled = true;
                rOOMComboBoxEdit.Enabled = false;
                ImageComboBoxEditMealCode.Enabled = true;
                pRV_CARCheckEdit.Enabled = true;
                cHK_OUTCheckEdit.Enabled = false;
                iNV_UPDImageComboBoxEdit.Enabled = true;
                nTSSpinEdit.Enabled = false;


                ///////////// pickup/dropoff
                ImageComboBoxEditOffice.Enabled = false;
                ImageComboBoxEditPickupSearch.Enabled = true;
                ImageComboBoxEditDropoffSearch.Enabled = true;
                bus_Drp_TypeComboBoxEdit.Enabled = true;
                bus_Pup_TypeComboBoxEdit.Enabled = true;

                ///////arrival
                ImageComboBoxEditArrivalSearch.Enabled = false;
                ImageComboBoxEditArrivalDestinationSearch.Enabled = false;
                aRV_FLTTextEdit.Enabled = false;
                aRV_LV_TIMETextEdit.Enabled = false;
                aRV_TIMETextEdit.Enabled = false;
                aRV_TRNFRComboBoxEdit.Enabled = false;


                ////////////////////////departure  

                ImageComboBoxEditDepartureSearch.Enabled = false;
                ImageComboBoxEditDepartureDestinationSearch.Enabled = false;
                dEP_FLTTextEdit.Enabled = false;
                dEP_TIMETextEdit.Enabled = false;
                dEP_AV_TIMETextEdit.Enabled = false;
                dEP_TRNFRComboBoxEdit.Enabled = false;

            }

            if (tYPEComboBoxEdit.Text.TrimEnd() == "AIR")
            {
                ImageComboBoxEditTypeCode.Properties.Items.AddRange(airVals);

                // type = ‘air’ then Room/cabin type, tour time, meal plan,
                //private car checkbox are greyed. 
                //The Pickup/DropOff info button is disabled.  The Arrival info and 
                //Departure Info buttons are enabled.

                //others
                tOUR_TIMEImageComboBoxEdit.Enabled = false;
                rOOMComboBoxEdit.Enabled = false;
                ImageComboBoxEditMealCode.Enabled = false;
                pRV_CARCheckEdit.Enabled = false;
                cHK_OUTCheckEdit.Enabled = true;
                iNV_UPDImageComboBoxEdit.Enabled = true;

                ///////////// pickup/dropoff
                ImageComboBoxEditOffice.Enabled = false;
                ImageComboBoxEditPickupSearch.Enabled = false;
                ImageComboBoxEditDropoffSearch.Enabled = false;
                bus_Drp_TypeComboBoxEdit.Enabled = false;
                bus_Pup_TypeComboBoxEdit.Enabled = false;

                ////////////////////////departure                
                ImageComboBoxEditDepartureSearch.Enabled = true;
                ImageComboBoxEditDepartureDestinationSearch.Enabled = true;
                dEP_FLTTextEdit.Enabled = true;
                dEP_TIMETextEdit.Enabled = true;
                dEP_AV_TIMETextEdit.Enabled = true;
                dEP_TRNFRComboBoxEdit.Enabled = true;

                ///////arrival
                ImageComboBoxEditArrivalSearch.Enabled = true;
                ImageComboBoxEditArrivalDestinationSearch.Enabled = true;
                aRV_FLTTextEdit.Enabled = true;
                aRV_LV_TIMETextEdit.Enabled = true;
                aRV_TIMETextEdit.Enabled = true;
                aRV_TRNFRComboBoxEdit.Enabled = true;
                nTSSpinEdit.Enabled = false;
            }

            if (tYPEComboBoxEdit.Text.TrimEnd() == "CAR")
            {
                ImageComboBoxEditTypeCode.Properties.Items.AddRange(carVals);

                //If type = ‘car’ then Room/cabin type, tour time, check out time checkbox,
                //meal plan, private car checkbox, update inventory are greyed.  
                //Pickup/Dropoff info is enabled and Arrival Info / Departure info is disabled.

                ////////////others
                tOUR_TIMEImageComboBoxEdit.Enabled = false;
                rOOMComboBoxEdit.Enabled = false;
                ImageComboBoxEditMealCode.Enabled = false;
                pRV_CARCheckEdit.Enabled = false;
                cHK_OUTCheckEdit.Enabled = false;
                iNV_UPDImageComboBoxEdit.Enabled = false;

                ///////////// pickup/dropoff
                ImageComboBoxEditOffice.Enabled = true;
                ImageComboBoxEditPickupSearch.Enabled = true;
                ImageComboBoxEditDropoffSearch.Enabled = true;
                bus_Drp_TypeComboBoxEdit.Enabled = true;
                bus_Pup_TypeComboBoxEdit.Enabled = true;

                ////////////////////////departure  

                ImageComboBoxEditDepartureSearch.Enabled = false;
                ImageComboBoxEditDepartureDestinationSearch.Enabled = false;
                dEP_FLTTextEdit.Enabled = false;
                dEP_TIMETextEdit.Enabled = false;
                dEP_AV_TIMETextEdit.Enabled = false;
                dEP_TRNFRComboBoxEdit.Enabled = false;

                ///////arrival
                ImageComboBoxEditArrivalSearch.Enabled = false;
                ImageComboBoxEditArrivalDestinationSearch.Enabled = false;
                aRV_FLTTextEdit.Enabled = false;
                aRV_LV_TIMETextEdit.Enabled = false;
                aRV_TIMETextEdit.Enabled = false;
                aRV_TRNFRComboBoxEdit.Enabled = false;
                nTSSpinEdit.Enabled = false;
            }

            if (tYPEComboBoxEdit.Text.TrimEnd() == "CRU")
            {
                ImageComboBoxEditTypeCode.Properties.Items.AddRange(cruVals);

                //If type = ‘cru’ then Tour time, check out time, meal plan, private car are greyed.
                //Pickup/DropOff info, Arrival info, Departure info buttons are disabled.

                ////////////others
                tOUR_TIMEImageComboBoxEdit.Enabled = false;
                rOOMComboBoxEdit.Enabled = true;
                ImageComboBoxEditMealCode.Enabled = false;
                pRV_CARCheckEdit.Enabled = false;
                cHK_OUTCheckEdit.Enabled = false;
                iNV_UPDImageComboBoxEdit.Enabled = true;
                nTSSpinEdit.Enabled = true;
                ///////////// pickup/dropoff
                ImageComboBoxEditOffice.Enabled = false;
                ImageComboBoxEditPickupSearch.Enabled = false;
                ImageComboBoxEditDropoffSearch.Enabled = false;
                bus_Drp_TypeComboBoxEdit.Enabled = false;
                bus_Pup_TypeComboBoxEdit.Enabled = false;

                ////////////////////////departure         

                ImageComboBoxEditDepartureSearch.Enabled = false;
                ImageComboBoxEditDepartureDestinationSearch.Enabled = false;
                dEP_FLTTextEdit.Enabled = false;
                dEP_TIMETextEdit.Enabled = false;
                dEP_AV_TIMETextEdit.Enabled = false;
                dEP_TRNFRComboBoxEdit.Enabled = false;

                ///////arrival
                ImageComboBoxEditArrivalSearch.Enabled = false;
                ImageComboBoxEditArrivalDestinationSearch.Enabled = false;
                aRV_FLTTextEdit.Enabled = false;
                aRV_LV_TIMETextEdit.Enabled = false;
                aRV_TIMETextEdit.Enabled = false;
                aRV_TRNFRComboBoxEdit.Enabled = false;
            }
        }


        private void tYPEComboBoxEdit_TextChanged(object sender, EventArgs e)
        {
            checkTypeComboCode();
        }

        private void PCompForm_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter && advBandedGridView1.IsFilterRow(advBandedGridView1.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = advBandedGridView1.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(advBandedGridView1.GetFocusedDisplayText()))
                value = advBandedGridView1.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.CAT like '{0}%'", advBandedGridView1.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CAT"));
                var special = context.PCOMP.Where(query);
              
                if (!string.IsNullOrWhiteSpace(advBandedGridView1.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE")))
                {
                    query = String.Format("it.{0} like '{1}%'", "CODE", advBandedGridView1.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                    special = special.Where(query);
                }
                if (!string.IsNullOrWhiteSpace(advBandedGridView1.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE1")))
                {
                    query = String.Format("it.{0} like '{1}%'", "CODE1", advBandedGridView1.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE1"));
                    special = special.Where(query);
                }
                if (!string.IsNullOrWhiteSpace(advBandedGridView1.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CAT1")))
                {
                    query = String.Format("it.{0} like '{1}%'", "CAT1", advBandedGridView1.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CAT1"));
                    special = special.Where(query);
                }
                if (!string.IsNullOrWhiteSpace(advBandedGridView1.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "SpecialValue_Code")))
                {
                    query = String.Format("it.{0} like '{1}%'", "SpecialValue_Code", advBandedGridView1.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "SpecialValue_Code"));
                    special = special.Where(query);
                }
            

                int count = special.Count();
                if (count > 0)
                {
                    PCompBindingSource.DataSource = special;
                    advBandedGridView1.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                    advBandedGridView1.FocusedRowHandle = 0;
                    advBandedGridView1.FocusedColumn.FieldName = colName;
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    advBandedGridView1.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void checkEditPickup_Click(object sender, EventArgs e)
        {
          
        }

        private void checkEditDropoff_Click(object sender, EventArgs e)
        {

        }

        private void ImageComboBoxEditCode_Leave(object sender, EventArgs e)
        {
            if (PCompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text) if (currentVal != ((Control)sender).Text)
                    {
                        modified = true;
                        labelControl14.Text = DateTime.Today.ToShortDateString();
                        labelControl13.Text = username;                       
                    }
                validCheck.check(sender, errorProvider1, ((PCOMP)PCompBindingSource.Current).checkCode, PCompBindingSource);
            }
        }

        private void ImageComboBoxEditCategory_Leave(object sender, EventArgs e)
        {
            if (PCompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl14.Text = DateTime.Today.ToShortDateString();
                    labelControl13.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((PCOMP)PCompBindingSource.Current).checkCat, PCompBindingSource);

            }            
        }

        private void ImageComboBoxEditTypeCode_Leave(object sender, EventArgs e)
        {
            if (PCompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl14.Text = DateTime.Today.ToShortDateString();
                    labelControl13.Text = username;
                }
              validCheck.check(sender, errorProvider1, ((PCOMP)PCompBindingSource.Current).checkRelCode, PCompBindingSource);

            } 
        }

        private void ImageComboBoxEditTypeCategory_Leave(object sender, EventArgs e)
        {
            if (PCompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl14.Text = DateTime.Today.ToShortDateString();
                    labelControl13.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((PCOMP)PCompBindingSource.Current).checkRelCat, PCompBindingSource);

            } 
        }

        private void ImageComboBoxEditMealCode_Leave(object sender, EventArgs e)
        {
            if (PCompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl14.Text = DateTime.Today.ToShortDateString();
                    labelControl13.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((PCOMP)PCompBindingSource.Current).checkMeals, PCompBindingSource);
            }
        }

        private void ImageComboBoxEditOperator_Leave(object sender, EventArgs e)
        {
            if (PCompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl14.Text = DateTime.Today.ToShortDateString();
                    labelControl13.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((PCOMP)PCompBindingSource.Current).checkOper, PCompBindingSource);
            }
        }

        private void ImageComboBoxEditOffice_Leave(object sender, EventArgs e)
        {
            if (PCompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl14.Text = DateTime.Today.ToShortDateString();
                    labelControl13.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((PCOMP)PCompBindingSource.Current).checkCarOff, PCompBindingSource);
            }
        }

        private void ImageComboBoxEditPickupSearch_Leave(object sender, EventArgs e)
        {
            if (PCompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl14.Text = DateTime.Today.ToShortDateString();
                    labelControl13.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((PCOMP)PCompBindingSource.Current).checkPup, PCompBindingSource);
            }

        }

        private void ImageComboBoxEditDropoffSearch_Leave(object sender, EventArgs e)
        {
            if (PCompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl14.Text = DateTime.Today.ToShortDateString();
                    labelControl13.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((PCOMP)PCompBindingSource.Current).checkDrp, PCompBindingSource);

            }
        }

        private void ImageComboBoxEditDepartureSearch_Leave(object sender, EventArgs e)
        {

            if (PCompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl14.Text = DateTime.Today.ToShortDateString();
                    labelControl13.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((PCOMP)PCompBindingSource.Current).checkDepCity, PCompBindingSource);
            }
        }

        private void ImageComboBoxEditDepartureDestinationSearch_Leave(object sender, EventArgs e)
        {
            if (PCompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl14.Text = DateTime.Today.ToShortDateString();
                    labelControl13.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((PCOMP)PCompBindingSource.Current).checkDepFrm, PCompBindingSource);
            }
        }

        private void ImageComboBoxEditArrivalSearch_Leave(object sender, EventArgs e)
        {
            if (PCompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl14.Text = DateTime.Today.ToShortDateString();
                    labelControl13.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((PCOMP)PCompBindingSource.Current).checkArvCity, PCompBindingSource);
            }
        }

        private void ImageComboBoxEditArrivalDestinationSearch_Leave(object sender, EventArgs e)
        {
            if (PCompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl14.Text = DateTime.Today.ToShortDateString();
                    labelControl13.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((PCOMP)PCompBindingSource.Current).checkArvFrm, PCompBindingSource);
            }

        }

        private void checkPupCode()
        {
            ImageComboBoxEditPickupSearch.Properties.Items.Clear();
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = string.Empty };
            ImageComboBoxEditPickupSearch.Properties.Items.Add(loadBlank);
            // ImageComboBoxEditPickupSearch.Text = "";
            if (bus_Pup_TypeComboBoxEdit.Text.TrimEnd() == "HTL")
            {
                ImageComboBoxEditPickupSearch.Properties.Items.AddRange(hotelVals);
            }

            if (bus_Pup_TypeComboBoxEdit.Text.TrimEnd() == "BUS")
            {
                ImageComboBoxEditPickupSearch.Properties.Items.AddRange(busVals);
            }

            if (bus_Pup_TypeComboBoxEdit.Text.TrimEnd() == "CTY")
            {
                ImageComboBoxEditPickupSearch.Properties.Items.AddRange(ctyVals);
            }

            if (bus_Pup_TypeComboBoxEdit.Text.TrimEnd() == "WAY")
            {
                ImageComboBoxEditPickupSearch.Properties.Items.AddRange(wayVals);
            }

            if (bus_Pup_TypeComboBoxEdit.Text.TrimEnd() == "TRN")
            {
                ImageComboBoxEditPickupSearch.Properties.Items.AddRange(trnVals);
            }


            if (bus_Pup_TypeComboBoxEdit.Text.TrimEnd() == "AIR")
            {
                ImageComboBoxEditPickupSearch.Properties.Items.AddRange(airportVals);
            }

            if (bus_Pup_TypeComboBoxEdit.Text.TrimEnd() == "CAR")
            {
                ImageComboBoxEditPickupSearch.Properties.Items.AddRange(carVals);
            }

            if (bus_Pup_TypeComboBoxEdit.Text.TrimEnd() == "CRU")
            {
                ImageComboBoxEditPickupSearch.Properties.Items.AddRange(cruVals);
            }

                if (string.IsNullOrWhiteSpace( bus_Pup_TypeComboBoxEdit.Text))
                {
                    ImageComboBoxEditPickupSearch.Properties.Items.AddRange(hotelVals);
                ImageComboBoxEditPickupSearch.Properties.Items.AddRange(ctyVals);

                }

        }

        private void bus_Pup_TypeComboBoxEdit_TextChanged(object sender, EventArgs e)
        {
            checkPupCode();
            //air, bus, car, cru, cty, htl, trn, way

        }

        private void checkDrpCode()
        {
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = string.Empty };
            ImageComboBoxEditDropoffSearch.Properties.Items.Clear();
            ImageComboBoxEditDropoffSearch.Properties.Items.Add(loadBlank);

            if (bus_Drp_TypeComboBoxEdit.Text.TrimEnd() == "HTL")
            {
                ImageComboBoxEditDropoffSearch.Properties.Items.AddRange(hotelVals);
            }

            if (bus_Drp_TypeComboBoxEdit.Text.TrimEnd() == "BUS")
            {
                ImageComboBoxEditDropoffSearch.Properties.Items.AddRange(busVals);
            }

            if (bus_Drp_TypeComboBoxEdit.Text.TrimEnd() == "CTY")
            {
                ImageComboBoxEditDropoffSearch.Properties.Items.AddRange(ctyVals);
            }

            if (bus_Drp_TypeComboBoxEdit.Text.TrimEnd() == "WAY")
            {
                ImageComboBoxEditDropoffSearch.Properties.Items.AddRange(wayVals);
            }

            if (bus_Drp_TypeComboBoxEdit.Text.TrimEnd() == "TRN")
            {
                ImageComboBoxEditDropoffSearch.Properties.Items.AddRange(trnVals);
            }


            if (bus_Drp_TypeComboBoxEdit.Text.TrimEnd() == "AIR")
            {
                ImageComboBoxEditDropoffSearch.Properties.Items.AddRange(airportVals);
            }

            if (bus_Drp_TypeComboBoxEdit.Text.TrimEnd() == "CAR")
            {
                ImageComboBoxEditDropoffSearch.Properties.Items.AddRange(carVals);
            }

            if (bus_Drp_TypeComboBoxEdit.Text.TrimEnd() == "CRU")
            {
                ImageComboBoxEditDropoffSearch.Properties.Items.AddRange(cruVals);
            }

            if (string.IsNullOrWhiteSpace(bus_Drp_TypeComboBoxEdit.Text))
            {
                ImageComboBoxEditDropoffSearch.Properties.Items.AddRange(hotelVals);
                ImageComboBoxEditDropoffSearch.Properties.Items.AddRange(ctyVals);

            }
        }

        private void bus_Drp_TypeComboBoxEdit_TextChanged(object sender, EventArgs e)
        {
            checkDrpCode();
            
        }

        private void checkTypeCode()
        {
            if (newRec)
            {
                ImageComboBoxEditOffice.Text = string.Empty;
                ImageComboBoxEditPickupSearch.Text = string.Empty;
                ImageComboBoxEditDropoffSearch.Text = string.Empty;
                bus_Drp_TypeComboBoxEdit.Text = string.Empty;
                bus_Pup_TypeComboBoxEdit.Text = string.Empty;


                ImageComboBoxEditArrivalSearch.Text = string.Empty;
                ImageComboBoxEditArrivalDestinationSearch.Text = string.Empty;
                aRV_FLTTextEdit.Text = string.Empty;
                aRV_LV_TIMETextEdit.Text = string.Empty;
                aRV_TIMETextEdit.Text = string.Empty;
                aRV_TRNFRComboBoxEdit.Text = string.Empty;

                ImageComboBoxEditDepartureSearch.Text = string.Empty;
                ImageComboBoxEditDepartureDestinationSearch.Text = string.Empty;
                dEP_FLTTextEdit.Text = string.Empty;
                dEP_TIMETextEdit.Text = string.Empty;
                dEP_AV_TIMETextEdit.Text = string.Empty;
                dEP_TRNFRComboBoxEdit.Text = string.Empty;
            }

            if (tYPEComboBoxEdit.Text == "HTL")
            {
                string code = ImageComboBoxEditTypeCode.EditValue.ToString();
                HOTEL rec = (HOTEL)(from comprec in context.HOTEL where comprec.CODE == code select comprec).FirstOrDefault();
                if(rec != null)
                    ImageComboBoxEditOperator.EditValue = rec.OPER;

            }

            if (tYPEComboBoxEdit.Text == "CRU")
            {
                string code = ImageComboBoxEditTypeCode.EditValue.ToString();
                CRU rec = (CRU)(from comprec in context.CRU where comprec.CODE == code select comprec).FirstOrDefault();
                if (rec != null)
                    ImageComboBoxEditOperator.EditValue = rec.OPER;

            }

            if (tYPEComboBoxEdit.Text == "CAR")
            {
                string code = ImageComboBoxEditTypeCode.EditValue.ToString();
                CARINFO rec = (CARINFO)(from comprec in context.CARINFO where comprec.CODE == code select comprec).FirstOrDefault();
                if (rec != null)
                    ImageComboBoxEditOperator.EditValue = rec.OPERATOR;

            }

            if (tYPEComboBoxEdit.Text == "OPT")
            {
                string code = ImageComboBoxEditTypeCode.EditValue.ToString();
                COMP rec = (COMP)(from comprec in context.COMP where comprec.CODE == code select comprec).FirstOrDefault();
                if (rec != null)
                {

                    ImageComboBoxEditOperator.EditValue = rec.OPER;
                    if (rec.PUDRP_REQ == "B")
                    {
                        //pup/drp
                        ImageComboBoxEditOffice.Enabled = false;
                        ImageComboBoxEditPickupSearch.Enabled = true;
                        ImageComboBoxEditDropoffSearch.Enabled = true;
                        bus_Drp_TypeComboBoxEdit.Enabled = true;
                        bus_Pup_TypeComboBoxEdit.Enabled = true;
                    }
                    else if (rec.PUDRP_REQ == "P")
                    {
                        ImageComboBoxEditOffice.Enabled = false;
                        ImageComboBoxEditPickupSearch.Enabled = true;
                        ImageComboBoxEditDropoffSearch.Enabled = false;
                        bus_Drp_TypeComboBoxEdit.Enabled = false;
                        bus_Pup_TypeComboBoxEdit.Enabled = true;
                    }
                    else if (rec.PUDRP_REQ == "D")
                    {
                        ImageComboBoxEditOffice.Enabled = false;
                        ImageComboBoxEditPickupSearch.Enabled = false;
                        ImageComboBoxEditDropoffSearch.Enabled = true;
                        bus_Drp_TypeComboBoxEdit.Enabled = true;
                        bus_Pup_TypeComboBoxEdit.Enabled = false;
                    }
                    else
                    {
                        ImageComboBoxEditOffice.Enabled = false;
                        ImageComboBoxEditPickupSearch.Enabled = false;
                        ImageComboBoxEditDropoffSearch.Enabled = false;
                        bus_Drp_TypeComboBoxEdit.Enabled = false;
                        bus_Pup_TypeComboBoxEdit.Enabled = false;
                    }

                    if (rec.Require_ArvInfo == "Y")
                    {
                        ImageComboBoxEditArrivalSearch.Enabled = true;
                        ImageComboBoxEditArrivalDestinationSearch.Enabled = true;
                        aRV_FLTTextEdit.Enabled = true;
                        aRV_LV_TIMETextEdit.Enabled = true;
                        aRV_TIMETextEdit.Enabled = true;
                        aRV_TRNFRComboBoxEdit.Enabled = true;
                    }
                    else if (rec.Require_DepInfo == "Y")
                    {

                        ImageComboBoxEditDepartureSearch.Enabled = true;
                        ImageComboBoxEditDepartureDestinationSearch.Enabled = true;
                        dEP_FLTTextEdit.Enabled = true;
                        dEP_TIMETextEdit.Enabled = true;
                        dEP_AV_TIMETextEdit.Enabled = true;
                        dEP_TRNFRComboBoxEdit.Enabled = true;
                    }
                    else
                    {
                        ImageComboBoxEditArrivalSearch.Enabled = false;
                        ImageComboBoxEditArrivalDestinationSearch.Enabled = false;
                        aRV_FLTTextEdit.Enabled = false;
                        aRV_LV_TIMETextEdit.Enabled = false;
                        aRV_TIMETextEdit.Enabled = false;
                        aRV_TRNFRComboBoxEdit.Enabled = false;

                        ImageComboBoxEditDepartureSearch.Enabled = false;
                        ImageComboBoxEditDepartureDestinationSearch.Enabled = false;
                        dEP_FLTTextEdit.Enabled = false;
                        dEP_TIMETextEdit.Enabled = false;
                        dEP_AV_TIMETextEdit.Enabled = false;
                        dEP_TRNFRComboBoxEdit.Enabled = false;

                    }

                    if (rec.TRSFR_TYP == "I" || rec.TRSFR_TYP == "B" || rec.TRSFR_TYP == "M")
                    {
                        //arrival
                        ImageComboBoxEditArrivalSearch.Enabled = true;
                        ImageComboBoxEditArrivalDestinationSearch.Enabled = true;
                        aRV_FLTTextEdit.Enabled = true;
                        aRV_LV_TIMETextEdit.Enabled = true;
                        aRV_TIMETextEdit.Enabled = true;
                        aRV_TRNFRComboBoxEdit.Enabled = true;

                        ImageComboBoxEditDepartureSearch.Enabled = false;
                        ImageComboBoxEditDepartureDestinationSearch.Enabled = false;
                        dEP_FLTTextEdit.Enabled = false;
                        dEP_TIMETextEdit.Enabled = false;
                        dEP_AV_TIMETextEdit.Enabled = false;
                        dEP_TRNFRComboBoxEdit.Enabled = false;
                    }

                    if ( rec.TRSFR_TYP == "N")
                    {
                        //arrival
                        ImageComboBoxEditArrivalSearch.Enabled = false;
                        ImageComboBoxEditArrivalDestinationSearch.Enabled = false;
                        aRV_FLTTextEdit.Enabled = false;
                        aRV_LV_TIMETextEdit.Enabled = false;
                        aRV_TIMETextEdit.Enabled = false;
                        aRV_TRNFRComboBoxEdit.Enabled = false;

                        ImageComboBoxEditDepartureSearch.Enabled = false;
                        ImageComboBoxEditDepartureDestinationSearch.Enabled = false;
                        dEP_FLTTextEdit.Enabled = false;
                        dEP_TIMETextEdit.Enabled = false;
                        dEP_AV_TIMETextEdit.Enabled = false;
                        dEP_TRNFRComboBoxEdit.Enabled = false;
                    }

                    if (rec.TRSFR_TYP == "O" || rec.TRSFR_TYP == "B")
                    {
                        //departure

                        ImageComboBoxEditDepartureSearch.Enabled = true;
                        ImageComboBoxEditDepartureDestinationSearch.Enabled = true;
                        dEP_FLTTextEdit.Enabled = true;
                        dEP_TIMETextEdit.Enabled = true;
                        dEP_AV_TIMETextEdit.Enabled = true;
                        dEP_TRNFRComboBoxEdit.Enabled = true;

                        ImageComboBoxEditArrivalSearch.Enabled = false;
                        ImageComboBoxEditArrivalDestinationSearch.Enabled = false;
                        aRV_FLTTextEdit.Enabled = false;
                        aRV_LV_TIMETextEdit.Enabled = false;
                        aRV_TIMETextEdit.Enabled = false;
                        aRV_TRNFRComboBoxEdit.Enabled = false;
                    }

                    if (rec.TRSFR_TYP == "")
                    {
                        ImageComboBoxEditDepartureSearch.Enabled = false;
                        ImageComboBoxEditDepartureDestinationSearch.Enabled = false;
                        dEP_FLTTextEdit.Enabled = false;
                        dEP_TIMETextEdit.Enabled = false;
                        dEP_AV_TIMETextEdit.Enabled = false;
                        dEP_TRNFRComboBoxEdit.Enabled = false;

                        ImageComboBoxEditArrivalSearch.Enabled = false;
                        ImageComboBoxEditArrivalDestinationSearch.Enabled = false;
                        aRV_FLTTextEdit.Enabled = false;
                        aRV_LV_TIMETextEdit.Enabled = false;
                        aRV_TIMETextEdit.Enabled = false;
                        aRV_TRNFRComboBoxEdit.Enabled = false;
                    }

                }
                //hotel check
                string PreviousHtl = string.Empty;
                decimal currDay = dAYSpinEdit.Value;
                decimal currLine = lINESpinEdit.Value;
                code = ImageComboBoxEditCode.EditValue.ToString();
                string cat = ImageComboBoxEditCategory.EditValue.ToString();
                var pcomps = from prec in context.PCOMP where prec.CODE == code && prec.CAT == cat select prec;

                //previous hotel
                if (pcomps.Count() > 0)
                {
                    //previous hotel diff day


                    PCOMP previousRec = (from comp in context.PCOMP where comp.CODE == code && comp.CAT == cat && comp.DAY <= currDay && comp.LINE < currLine && comp.TYPE == "HTL" orderby comp.DAY descending select comp).FirstOrDefault();
                    //var prevRecsDiffDay = pcomps.Where(item => item.DAY == (currDay - 1));
                    //int? lastLine = prevRecsDiffDay.Max(item => item.LINE);
                    //var previous = (prevRecsDiffDay.Where(item => item.LINE == lastLine)).FirstOrDefault();

                    if (previousRec != null)
                    {
                        if (previousRec.TYPE == "HTL")
                        {
                            if (rec.PUDRP_REQ == "B" || rec.PUDRP_REQ == "P")
                            {
                                ImageComboBoxEditPickupSearch.Properties.Items.Clear();
                                ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = string.Empty };
                                ImageComboBoxEditPickupSearch.Properties.Items.Add(loadBlank);
                                ImageComboBoxEditPickupSearch.Properties.Items.AddRange(hotelVals);
                                ImageComboBoxEditPickupSearch.EditValue = previousRec.CODE1;
                                PreviousHtl = previousRec.CODE1;
                            }
                        }

                    }
                    ///next hotel
                    ///
                    PCOMP nextRec = (from comp in context.PCOMP where comp.CODE == code && comp.CAT == cat && comp.DAY >= currDay && comp.TYPE == "HTL" orderby comp.DAY descending select comp).FirstOrDefault();

                    //same day 

                    if (nextRec != null)
                    {
                        if (nextRec.TYPE == "HTL")
                        {
                            if (rec.PUDRP_REQ == "B" || rec.PUDRP_REQ == "P")
                            {
                                ImageComboBoxEditDropoffSearch.Properties.Items.Clear();
                                ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = string.Empty };
                                ImageComboBoxEditDropoffSearch.Properties.Items.Add(loadBlank);
                                ImageComboBoxEditDropoffSearch.Properties.Items.AddRange(hotelVals);
                                ImageComboBoxEditDropoffSearch.EditValue = nextRec.CODE1;
                            }
                        }
                    }


                }
            }
        }

        private void ImageComboBoxEditTypeCode_TextChanged(object sender, EventArgs e)
        {
            checkTypeCode();          
        }

        private void nTSSpinEdit_Leave(object sender, EventArgs e)
        {
            if (PCompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl14.Text = DateTime.Today.ToShortDateString();
                    labelControl13.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((PCOMP)PCompBindingSource.Current).checkNights, PCompBindingSource);
            }
        }

        private void checkCode()
        {
            string code = ImageComboBoxEditCode.EditValue?.ToString() ?? string.Empty;
            PACK rec = (PACK)(from comprec in context.PACK where comprec.CODE == code select comprec).FirstOrDefault();
            if (rec != null)
            {
                PACKTYPE val = (PACKTYPE)(from comprec in context.PACKTYPE where comprec.CODE == rec.PKG_TYPE select comprec).FirstOrDefault();
                if (val != null)
                {
                    labelControlPackType.Text = val.CODE + " - " + val.DESC;
                    ((PCOMP)PCompBindingSource.Current).PackageType = val.CODE;
                }
            }
        }

        private void ImageComboBoxEditCode_TextChanged(object sender, EventArgs e)
        {
            checkCode();
            

            //next day/line
        }

        void enableNavigator(bool value)
        {
            bindingNavigatorMoveNextItem.Enabled = value;
            bindingNavigatorMoveLastItem.Enabled = value;
            bindingNavigatorMoveFirstItem.Enabled = value;
            bindingNavigatorMovePreviousItem.Enabled = value;
        }

        private void PCompBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (PCompBindingSource.Current != null)
            {
                enableNavigator(true);
                checkTypeComboCode();
                checkCode();
                checkDrpCode();
                checkPupCode();
                checkTypeCode();
                //if (!string.IsNullOrWhiteSpace(dATEDateEdit.Text))
                //    dATEDateEdit.Text = validCheck.convertDate(dATEDateEdit.Text);
              //  context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (PCOMP)PCompBindingSource.Current);

                ImageComboBoxEditPickupSearch.EditValue = ((PCOMP)PCompBindingSource.Current).PUP_OFF;
                ImageComboBoxEditDropoffSearch.EditValue = ((PCOMP)PCompBindingSource.Current).DRP_OFF;
            }
            else
            {
                enableNavigator(false);
                labelControlPackType.Text = string.Empty;
            }
        
        }

        private void labelControl14_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(labelControl14.Text))
                labelControl14.Text = validCheck.convertDate(labelControl14.Text);

        }

        private void dEP_TIMETextEdit_Leave(object sender, EventArgs e)
        {
            if (PCompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl14.Text = DateTime.Today.ToShortDateString();
                    labelControl13.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((PCOMP)PCompBindingSource.Current).checkDepTime, PCompBindingSource);
            }
        }

        private void dEP_AV_TIMETextEdit_Leave(object sender, EventArgs e)
        {
            if (PCompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl14.Text = DateTime.Today.ToShortDateString();
                    labelControl13.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((PCOMP)PCompBindingSource.Current).checkDepAvTime, PCompBindingSource);
            }
        }

        private void aRV_LV_TIMETextEdit_Leave(object sender, EventArgs e)
        {
            if (PCompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl14.Text = DateTime.Today.ToShortDateString();
                    labelControl13.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((PCOMP)PCompBindingSource.Current).checkArvLvTime, PCompBindingSource);
            }
        }

        private void aRV_TIMETextEdit_Leave(object sender, EventArgs e)
        {
            if (PCompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl14.Text = DateTime.Today.ToShortDateString();
                    labelControl13.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((PCOMP)PCompBindingSource.Current).checkArvTime, PCompBindingSource);
            }
        }

        private void ImageComboBoxEditPickupSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bus_Pup_TypeComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (PCompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl14.Text = DateTime.Today.ToShortDateString();
                    labelControl13.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((PCOMP)PCompBindingSource.Current).checkBus_Pup_Type, PCompBindingSource);

                if (string.IsNullOrWhiteSpace(((Control)sender).Text) && !string.IsNullOrWhiteSpace(currentVal))
                    ImageComboBoxEditPickupSearch.EditValue = string.Empty;
            }

        }

        private void bus_Drp_TypeComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (PCompBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl14.Text = DateTime.Today.ToShortDateString();
                    labelControl13.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((PCOMP)PCompBindingSource.Current).checkBus_Drp_Type, PCompBindingSource);
                
                if (string.IsNullOrWhiteSpace(((Control)sender).Text) && !string.IsNullOrWhiteSpace(currentVal))
                    ImageComboBoxEditDropoffSearch.EditValue = string.Empty;
            }

        }

        
        private void cHK_OUTCheckEdit_Click(object sender, EventArgs e)
        {
            modified = true;
        }

        private void pRV_CARCheckEdit_Click(object sender, EventArgs e)
        {
            modified = true;
        }

        private void ImageComboBoxEditCategory_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void ImageComboBoxEditCategory_Modified(object sender, EventArgs e)
        {
          
        }

        bool checkOverlappingHotels()
        {
            string code = ImageComboBoxEditCode.EditValue.ToString();
            string cat = ImageComboBoxEditCategory.EditValue.ToString();
            string relcode = ImageComboBoxEditTypeCode.EditValue.ToString();
            int? nextDay = null;
            int currDay = (int)dAYSpinEdit.Value;
            int currLine = (int)lINESpinEdit.Value;
            bool sameDayLine = false;
            bool hasBlank = false;
            bool overlap = false;
            //check same day first
            var sameDay = (from pcompRec in context.PCOMP where pcompRec.CODE == code && pcompRec.CAT == cat && pcompRec.DAY == currDay orderby pcompRec.DAY descending select pcompRec);
            foreach (PCOMP rec in sameDay)
                if (rec.TYPE == "HTL" && tYPEComboBoxEdit.Text == "HTL")
                    overlap = true;
           
            var Pkgrecs = (from pcompRec in context.PCOMP where pcompRec.CODE == code && pcompRec.CAT == cat  && pcompRec.DAY != currDay && pcompRec.LINE != currLine orderby pcompRec.DAY descending select pcompRec);
            //int lastItem = currPkgrecs.Max(x => x.DAY);
            //var lastdayrecs = currPkgrecs.Where(x => x.DAY == lastItem);
            if (Pkgrecs != null)
            {
                foreach (PCOMP rec in Pkgrecs)
                {
                    //if (rec.DAY == currDay && rec.LINE == currLine)
                    //    sameDayLine = true;
                    if (rec.PackageType == "CTY" && rec.TYPE == "HTL" && rec.CODE1 == string.Empty)
                        hasBlank = true;
                    if (rec.TYPE == "HTL" && tYPEComboBoxEdit.Text == "HTL")
                    {
                        nextDay = rec.DAY + rec.NTS;
                        if ((currDay > rec.DAY && currDay < nextDay) || currDay == rec.DAY)
                            overlap = true;
                    }
                }
                    
                if (sameDayLine)
                {                    
                    MessageBox.Show("There is already an item with these values, please correct the day and line values.");
                    return false;
                }

                if (((PCOMP)PCompBindingSource.Current).PackageType == "CTY")
                {
                    if (string.IsNullOrWhiteSpace(ImageComboBoxEditTypeCode.Text) && hasBlank)
                    {
                        MessageBox.Show("You cannot have two blank hotels in a city package.");
                        return false;
                    }
                }

                if (overlap)
                {
                    MessageBox.Show("This would be an overlapping hotel, please change the day of this item.");
                    return false;
                }

                return true;
            }
            else
            {
                //firstItem
                if (currDay != 1 && currLine != 1)
                {
                    MessageBox.Show("This is the first item of this package it should be on day 1 line 1.");
                    return false;
                }
                else
                    return true;
            }

        }

        private void ImageComboBoxEditTypeCode_Modified(object sender, EventArgs e)
        {

            ImageComboBoxEditOffice.Text = string.Empty;
            ImageComboBoxEditPickupSearch.Text = string.Empty;
            ImageComboBoxEditDropoffSearch.Text = string.Empty;
            bus_Drp_TypeComboBoxEdit.Text = string.Empty;
            bus_Pup_TypeComboBoxEdit.Text = string.Empty;


            ImageComboBoxEditArrivalSearch.Text = string.Empty;
            ImageComboBoxEditArrivalDestinationSearch.Text = string.Empty;
            aRV_FLTTextEdit.Text = string.Empty;
            aRV_LV_TIMETextEdit.Text = string.Empty;
            aRV_TIMETextEdit.Text = string.Empty;
            aRV_TRNFRComboBoxEdit.Text = string.Empty;

            ImageComboBoxEditDepartureSearch.Text = string.Empty;
            ImageComboBoxEditDepartureDestinationSearch.Text = string.Empty;
            dEP_FLTTextEdit.Text = string.Empty;
            dEP_TIMETextEdit.Text = string.Empty;
            dEP_AV_TIMETextEdit.Text = string.Empty;
            dEP_TRNFRComboBoxEdit.Text = string.Empty;
        }

        private void bus_Pup_TypeComboBoxEdit_Modified(object sender, EventArgs e)
        {
           
        }

        private void dAYSpinEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl14.Text = DateTime.Today.ToShortDateString();
                labelControl13.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((PCOMP)PCompBindingSource.Current).checkDay, PCompBindingSource);
       
        }

        private void lINESpinEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl14.Text = DateTime.Today.ToShortDateString();
                labelControl13.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((PCOMP)PCompBindingSource.Current).checkLine, PCompBindingSource);
       
        }
       
    }
}