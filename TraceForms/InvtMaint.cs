using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using FlexModel;
using System.Data.Entity.Core.Objects;
using DevExpress.XtraEditors.Controls;
using System.Linq;
using System.Linq.Dynamic;
using DevExpress.Data.Linq;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using System.Runtime.InteropServices;


using DevExpress.XtraGrid.Columns;

using System.Data;
using System.Drawing;
using System.Text;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
namespace TraceForms
{
    
    public partial class InvtMaint : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool _modified = false;
        public bool newRec = false;
        public FlextourEntities context;
        //public EntityInstantFeedbackSource _efSrc = new EntityInstantFeedbackSource();
        //public FlexCore.CoreSys _sys = new FlexCore.CoreSys("");
        //public INVT _item;
        //public int pageCount = 1;
        public string username;
       
        public ImageComboBoxItemCollection opts;
        public ImageComboBoxItemCollection htls;
        public ImageComboBoxItemCollection crus;
        public ImageComboBoxItemCollection airs;
        public ImageComboBoxItemCollection pkgs;
        public string defAgy;
        public bool bBuild;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        private char[] TrimChars = new char[2] {'.',' '};
        public InvtMaint(bool val, FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);
			//force reload from db on every query, rather than using previous cached records
			context.ContextOptions.LazyLoadingEnabled = false;
			context.INVT.MergeOption = MergeOption.OverwriteChanges; 
			defAgy = sys.User.Agency.Agency.ToString();
            //_efSrc.KeyExpression = "TYPE,CODE,CAT,TP,DATE,AGENCY";
            //_efSrc.GetQueryable += efSrc_GetQueryable;
            //_efSrc.DismissQueryable += efSrc_DismissQueryable;
            //GridControlInvMaint.DataSource = _efSrc;
            //fake query in order to create a link between the database table and the binding source
            InvtBindingSource.DataSource = from opt in context.INVT where opt.CODE == "KJM9" select opt;
            bBuild = val;
            ShowOrHideBuild();

            username = sys.User.Name;
            LoadLookups();
        }

        private bool Modified
        {
            get
            {
                return _modified;
            }
            set
            {
                _modified = value;
                if (value && InvtBindingSource.Current != null) {
                    //NB: Before updating any property on the entity, any pending edits must be committed 
                    //with bindingSource.EndEdit, other when the properties are set the form bindings are
                    //automatically refreshed, which causes any pending edits to be lost. 
                    InvtBindingSource.EndEdit();
                    INVT invt = (INVT)InvtBindingSource.Current;
                    invt.UPD_DATE = DateTime.Now;
                    invt.UPD_BY = username;
                }
            }
        }

        private void ShowOrHideBuild()
        {
            ////////////////////////////////////////////
            labelControlDate.Visible = !bBuild;
            DateEditDate.Visible = !bBuild;
            SpinEditBuildDays.Visible = bBuild;
            LabelControlBuild.Visible = bBuild;
            LabelControlDays.Visible = bBuild;
            CheckEditOverwrite.Visible = bBuild;
            LabelControlOver.Visible = bBuild;
            CheckEditSkip.Visible = bBuild;
            LabelControlSkips.Visible = bBuild;
            checkEditSyn.Visible = bBuild;
            LabelControlBuildFrom.Visible = bBuild;
            LabelControlBuildThrough.Visible = bBuild;
            LabelControlBuildEvery.Visible = bBuild;
            DateEditBuildFrom.Visible = bBuild;
            DateEditBuildThrough.Visible = bBuild;
            ComboBoxEditBuildEvery.Visible = bBuild;
            /////////////////////////

        }



        private void LoadLookups()
        {
       
              if(bBuild)
                  InvtBindingSource.DataSource = from opt in context.INVT where opt.CODE == "K9JM" select opt;             
              

            opts = new ImageComboBoxItemCollection(ImageComboBoxEditCode.Properties);
            htls = new ImageComboBoxItemCollection(ImageComboBoxEditCode.Properties);
            crus = new ImageComboBoxItemCollection(ImageComboBoxEditCode.Properties);
            airs = new ImageComboBoxItemCollection(ImageComboBoxEditCode.Properties);
            pkgs = new ImageComboBoxItemCollection(ImageComboBoxEditCode.Properties);
            var agy = from agyRec in context.AGY orderby agyRec.NO ascending select new { agyRec.NO, agyRec.NAME };
            var cats = from catRec in context.ROOMCOD orderby catRec.CODE ascending select new { catRec.CODE, catRec.DESC };
            var comps = from compRec in context.COMP orderby compRec.CODE ascending select new { compRec.CODE, compRec.NAME };
            var hotels = from hotRec in context.HOTEL orderby hotRec.CODE ascending select new { hotRec.CODE, hotRec.NAME };
            var cruises = from cruRec in context.CRU orderby cruRec.CODE ascending select new { cruRec.CODE, cruRec.NAME };
            var air = from airRec in context.AIR orderby airRec.CODE ascending select new { airRec.CODE, airRec.NAME };
            var packs = from pckRec in context.PACK orderby pckRec.CODE ascending select new { pckRec.CODE, pckRec.NAME };
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxEditCat.Properties.Items.Add(loadBlank);
            ImageComboBoxEditAgency.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCode.Properties.Items.Add(loadBlank);
            ImageComboBoxEditRelCat.Properties.Items.Add(loadBlank);
            ImageComboBoxEditRelAgency.Properties.Items.Add(loadBlank);
            ImageComboBoxEditRelCode.Properties.Items.Add(loadBlank);
            foreach (var result in agy)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.NO.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.NO.TrimEnd() };
                ImageComboBoxEditAgency.Properties.Items.Add(load);
                ImageComboBoxEditRelAgency.Properties.Items.Add(load);
            }
            foreach (var result in cats)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.DESC.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCat.Properties.Items.Add(load);
                ImageComboBoxEditRelCat.Properties.Items.Add(load);

            }
            foreach (var result in comps)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                
                opts.Add(load);
            }
            foreach (var result in hotels)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                
                htls.Add(load);
            }
            foreach (var result in air)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };

                airs.Add(load);
            }
            foreach (var result in cruises)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };

                crus.Add(load);
            }
            foreach (var result in packs)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };

                pkgs.Add(load);
            }
            enableNavigator(false);
            //expandContractGridButton.Tag = "right";
            setReadOnly(true);
        }

        void enableNavigator(bool value)
        {
            bindingNavigatorMoveNextItem.Enabled = value;
            bindingNavigatorMoveLastItem.Enabled = value;
            bindingNavigatorMoveFirstItem.Enabled = value;
            bindingNavigatorMovePreviousItem.Enabled = value;
        }


        void setReadOnly(bool value)
        {
            ImageComboBoxEditCode.Properties.ReadOnly = value;
            ImageComboBoxEditAgency.Properties.ReadOnly = value;
            ImageComboBoxEditCat.Properties.ReadOnly = value;
            ComboBoxEditType.Properties.ReadOnly = value;
            DateEditDate.Properties.ReadOnly = value;
            ComboBoxEditTP.Properties.ReadOnly = value;
            //ImageComboBoxEditCategory.Properties.ReadOnly = value;
            //sTART_DATEDateEdit.Properties.ReadOnly = value;
            //resDate_StartDateEdit.Properties.ReadOnly = value;
        }

        //private void efSrc_GetQueryable(object sender, GetQueryableEventArgs e)
        //{
        //    FlextourEntities context = new FlextourEntities(_sys.Settings.EFConnectionString);
        //    e.QueryableSource = context.INVT;
        //    e.Tag = context;
        //}

        //private void efSrc_DismissQueryable(object sender, GetQueryableEventArgs e)
        //{
        //    ((FlextourEntities)e.Tag).Dispose();
        //}

        private void advBandedGridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            //if ((e.FocusedRowHandle >= 0) && (!GridViewInvt.IsGroupRow(e.FocusedRowHandle)))
            //{
            //    EditItem(e.FocusedRowHandle);
            //}
        }

        //private void EditItem(int rowHandle)
        //{
        //    try
        //    {
        //        //Single value key
        //        int key = Convert.ToInt32(GridViewInvt.GetRowCellValue(rowHandle, "ID"));
        //        _item = context.INVT.Single<INVT>(i => i.ID == key);
        //        EditItem(_item);

        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        //private void EditItem(INVT item)
        //{
        //    InvtBindingSource.DataSource = item;
        //    InvtBindingSource.MoveFirst();
        //}

        private void InvMaint_Load(object sender, EventArgs e)
        {


            /// change the rmcabin to readonly true on selection of type
        }

        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

       

        private bool move()
        {
            GridViewInvt.CloseEditor();
            ComboBoxEditType.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            bool temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (INVT)InvtBindingSource.Current);
                setReadOnly(true);
                newRec = false;
                Modified = false;
                return true;
            }
            return false;
        }

        private void advBandedGridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            //if (InvtBindingSource.Current == null)
            //{
            //    e.Allow = true;
            //    return;
            //}
            //temp = newRec;
            //bool temp2 = modified;

            //if (validCheck.saveRoutine(InvtBindingSource, context, errorProvider1, ref newRec, ref modified, ((INVT)InvtBindingSource.Current).checkAll, splitContainerControl1.Panel2.Controls, validCheck.dummy))
            //{
            //    e.Allow = true;
            //    if ((!temp) && temp2)
            //        context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (INVT)InvtBindingSource.Current);
            //}
            //else
            //    e.Allow = false;



            if (InvtBindingSource.Current == null)
            {
                e.Allow = true;
                return;
            }
            bool temp = newRec;
            bool temp2 = _modified;
            if (checkForms())
            {
                e.Allow = true;
                if ((!temp) && temp2)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (INVT)InvtBindingSource.Current);

                setReadOnly(true);

            }
            else
                e.Allow = false;
            /////////////////////////////////////////////////////////////




            //if (InvtBindingSource.Current == null)
            //{
            //    e.Allow = true;
            //    return;
            //}
            //else if (newRec == true || modified == true)
            //{
            //    Boolean isValid = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((INVT)InvtBindingSource.Current).checkAll, InvtBindingSource);
            //    if (isValid)
            //    {
            //        SaveItem();
            //        e.Allow = true;
            //    }
            //    else
            //    {
            //        e.Allow = false;
            //    }

            //}
            
        }

        private void advBandedGridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if (!advBandedGridView1.IsFilterRow(e.RowHandle))
            //{
            //    Modified = true;
            //}
        }

        private void advBandedGridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }

        private void InvMaint_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_modified || newRec)
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

        private void tYPEComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (InvtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }

                validCheck.check(sender, errorProvider1, ((INVT)InvtBindingSource.Current).checkType, InvtBindingSource);
            }
        }      

        private void dATEDateEdit_Leave(object sender, EventArgs e)
        {
            if (InvtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }

                if (Convert.ToDateTime(validCheck.convertDate(DateEditDate.Text)) < DateTime.Today)
                {
                    DialogResult select = MessageBox.Show("The date entered is prior to today's date is this correct?", "Date", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        MessageBox.Show("Please correct the value.");
                        DateEditDate.Focus();
                        return;
                    }
                }

                validCheck.check(sender, errorProvider1, ((INVT)InvtBindingSource.Current).checkDate, InvtBindingSource);
            }
        }

        private void aVComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (InvtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }

                validCheck.check(sender, errorProvider1, ((INVT)InvtBindingSource.Current).checkAv, InvtBindingSource);
            }
        }

        private void mAXSpinEdit_Leave(object sender, EventArgs e)
        {
            if (InvtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.Trim(TrimChars))
                {
                    Modified = true;
                }

                validCheck.check(sender, errorProvider1, ((INVT)InvtBindingSource.Current).checkMax, InvtBindingSource);
            }
        }

        private void mINSpinEdit_Leave(object sender, EventArgs e)
        {
            if (InvtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.Trim(TrimChars))
                {
                    Modified = true;
                }

                validCheck.check(sender, errorProvider1, ((INVT)InvtBindingSource.Current).checkMin, InvtBindingSource);
            }
        }

        private void cANCSpinEdit_Leave(object sender, EventArgs e)
        {
            if (InvtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.Trim(TrimChars))
                {
                    Modified = true;
                }

                validCheck.check(sender, errorProvider1, ((INVT)InvtBindingSource.Current).checkCanc, InvtBindingSource);
            }
        }

        private void mIN_BK_DAYSSpinEdit_Leave(object sender, EventArgs e)
        {
            if (InvtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.Trim(TrimChars))
                {
                    Modified = true;
                }

                validCheck.check(sender, errorProvider1, ((INVT)InvtBindingSource.Current).checkMinBook, InvtBindingSource);
            }
        }

        private void oRIG_AMTSpinEdit_Leave(object sender, EventArgs e)
        {
            if (InvtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.Trim(TrimChars))
                {
                    Modified = true;
                }

                validCheck.check(sender, errorProvider1, ((INVT)InvtBindingSource.Current).checkOrigAmt, InvtBindingSource);
            }
        }

        private void aLLOCTDSpinEdit_Leave(object sender, EventArgs e)
        {
            if (InvtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.Trim(TrimChars))
                {
                    Modified = true;
                }

                validCheck.check(sender, errorProvider1, ((INVT)InvtBindingSource.Current).checkAllocated, InvtBindingSource);
            }
        }

        private void aV_AMTSpinEdit_Leave(object sender, EventArgs e)
        {
            if (InvtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.Trim(TrimChars))
                {
                    Modified = true;
                }

                validCheck.check(sender, errorProvider1, ((INVT)InvtBindingSource.Current).checkAvAmt, InvtBindingSource);
            }
        }

        private void hOLDSpinEdit_Leave(object sender, EventArgs e)
        {
            if (InvtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.Trim(TrimChars))
                {
                    Modified = true;
                }

                validCheck.check(sender, errorProvider1, ((INVT)InvtBindingSource.Current).checkHold, InvtBindingSource);
            }
        }

        private void rELSpinEdit_Leave(object sender, EventArgs e)
        {
            if (InvtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.Trim(TrimChars))
                {
                    Modified = true;
                }

                validCheck.check(sender, errorProvider1, ((INVT)InvtBindingSource.Current).checkRelDays, InvtBindingSource);
            }
        }

        private void rELTYPComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (InvtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }

                validCheck.check(sender, errorProvider1, ((INVT)InvtBindingSource.Current).checkRelType, InvtBindingSource);
            }
        }

        private void tPComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (InvtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }

                validCheck.check(sender, errorProvider1, ((INVT)InvtBindingSource.Current).checkRmCab, InvtBindingSource);
            }
        }

        private void tYPEComboBoxEdit_TextChanged(object sender, EventArgs e)
        {
            ImageComboBoxEditCode.Properties.Items.Clear();
            ImageComboBoxEditRelCode.Properties.Items.Clear();
          

    
                if (ComboBoxEditType.Text == "HTL")
                {
                   
                    ComboBoxEditTP.Properties.ReadOnly = false;
                    ComboBoxEditRelTyp.Properties.ReadOnly = false;
                    SpinEditMinBkDays.Properties.ReadOnly = true;
                    SpinEditMax.Properties.ReadOnly = false;
                    SpinEditMin.Properties.ReadOnly = false;
                    checkEditSyn.Checked = true;
                    //oRIG_AMTSpinEdit.Properties.ReadOnly = true;
                    SpinEditHold.Properties.ReadOnly = true;
                    ImageComboBoxEditCode.Properties.Items.AddRange(htls);
                    ImageComboBoxEditRelCode.Properties.Items.AddRange(htls);
                    SpinEditCanc.Properties.ReadOnly = false;
                    
                }
                if (ComboBoxEditType.Text == "OPT")
                {
                    ImageComboBoxEditRelAgency.Properties.ReadOnly = true;
                    SpinEditCanc.Properties.ReadOnly = false;
                    ComboBoxEditTP.Properties.ReadOnly = true;
                    
                    ComboBoxEditRelTyp.Properties.ReadOnly = true;
                    SpinEditMinBkDays.Properties.ReadOnly = true;
                    SpinEditMax.Properties.ReadOnly = true;
                    SpinEditMin.Properties.ReadOnly = true;
                    checkEditSyn.Checked = true;
                    SpinEditOrig_Amt.Properties.ReadOnly = true;
                    SpinEditHold.Properties.ReadOnly = true;
                    // option codes
                    ImageComboBoxEditCode.Properties.Items.AddRange(opts);
                    ImageComboBoxEditRelCode.Properties.Items.AddRange(opts);
                    
                }

                if (ComboBoxEditType.Text == "PKG")
                {
                    ComboBoxEditRelTyp.Text = "NON";
                    ComboBoxEditTP.Properties.ReadOnly = true;
                    SpinEditCanc.Properties.ReadOnly = false;
                    ComboBoxEditRelTyp.Properties.ReadOnly = true;
                    SpinEditMinBkDays.Properties.ReadOnly = true;
                    SpinEditMax.Properties.ReadOnly = true;
                    SpinEditMin.Properties.ReadOnly = true;
                    checkEditSyn.Checked = true;
                    SpinEditOrig_Amt.Properties.ReadOnly = true;
                    SpinEditHold.Properties.ReadOnly = true;
     
                    //ImageComboBoxEditRelAgency.Properties.ReadOnly = true;
                    // pkg codes
                    ImageComboBoxEditCode.Properties.Items.AddRange(pkgs);
                    ImageComboBoxEditRelCode.Properties.Items.AddRange(pkgs);
                    
                }
            
        
                if (ComboBoxEditType.Text == "CRU")
                {
                    ImageComboBoxEditRelAgency.Properties.ReadOnly = true;
                    
                    ComboBoxEditTP.Properties.ReadOnly = false;
                    ComboBoxEditRelTyp.Properties.ReadOnly = false;
                    SpinEditMinBkDays.Properties.ReadOnly = true;
                    SpinEditMax.Properties.ReadOnly = true;
                    SpinEditCanc.Properties.ReadOnly = false;
                    SpinEditMin.Properties.ReadOnly = true;
                    checkEditSyn.Checked = true;
                    SpinEditOrig_Amt.Properties.ReadOnly = true;
                    SpinEditHold.Properties.ReadOnly = true;
                    ImageComboBoxEditCode.Properties.Items.AddRange(crus);
                    ImageComboBoxEditRelCode.Properties.Items.AddRange(crus);
                    
                }
                if (ComboBoxEditType.Text == "AIR")
                {
                    ComboBoxEditTP.Properties.ReadOnly = true;
                    ComboBoxEditRelTyp.Properties.ReadOnly = true;
                    SpinEditMinBkDays.Properties.ReadOnly = true;
                    SpinEditMax.Properties.ReadOnly = true;
                    SpinEditMin.Properties.ReadOnly = true;
                    checkEditSyn.Checked = true;
                    SpinEditCanc.Properties.ReadOnly = false;
                    SpinEditOrig_Amt.Properties.ReadOnly = true;
                    SpinEditHold.Properties.ReadOnly = true;
                    
                   // ImageComboBoxEditRelAgency.Properties.ReadOnly = true;
                    //airports
                    ImageComboBoxEditCode.Properties.Items.AddRange(airs);
                    ImageComboBoxEditRelCode.Properties.Items.AddRange(airs);
                    
                }

            
        }

        
        private void aVComboBoxEdit_TextChanged(object sender, EventArgs e)
        {
            if (ComboBoxEditAV.Text == "A")
            {
                lockControls("Available", false);

            }
            if (ComboBoxEditAV.Text == "C")
            {
                lockControls("Closed", false);

            }
            if (ComboBoxEditAV.Text == "S")
            {
                lockControls("Sell through only on this date", false);

            }
            if (ComboBoxEditAV.Text == "R")
            {
                lockControls("Request inventory only", true);
                CheckEditReq.Checked = true;
                if (ComboBoxEditType.Text == "HTL" && ImageComboBoxEditAgency.EditValue == defAgy)
                {
                    SpinEditHold.Properties.ReadOnly = false;
                }
               
            }
            if (ComboBoxEditAV.Text == "Q")
            {                
                lockControls("Request and sell through only", true);
                CheckEditReq.Checked = true;
                if (ComboBoxEditType.Text == "HTL" && ImageComboBoxEditAgency.EditValue == defAgy)
                {
                    SpinEditHold.Properties.ReadOnly = false;
                }
            }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEditSyn.Checked == true)
            {
                SpinEditOrig_Amt.Properties.ReadOnly = true;
            }
            if (checkEditSyn.Checked == false)
            {
                SpinEditOrig_Amt.Properties.ReadOnly = false;
                
            }
        }

        private void lockControls(string val, bool value)
        {            
            labelControl3.Text = val;
           // checkEditSyn.Properties.ReadOnly = !value;
           // requestableCheckEdit.Properties.ReadOnly = !value;
            SpinEditOrig_Amt.Properties.ReadOnly = value;
            SpinEditAv_Amt.Properties.ReadOnly = value;
            SpinEditAlloctd.Properties.ReadOnly = value;
            SpinEditHold.Properties.ReadOnly = value;
            SpinEditRel.Properties.ReadOnly = value;
            ComboBoxEditRelTyp.Properties.ReadOnly = value;
            ImageComboBoxEditRelAgency.Properties.ReadOnly = value;
            ImageComboBoxEditRelCat.Properties.ReadOnly = value;
            ImageComboBoxEditRelCode.Properties.ReadOnly = value;

        }

        private void dateEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void dateEdit2_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void dATEDateEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void dATEDateEdit_TextChanged(object sender, EventArgs e)
        {
            //dATEDateEdit.Text = validCheck.convertDate(dATEDateEdit.Text);
          
                if (!string.IsNullOrWhiteSpace(DateEditDate.Text) && string.IsNullOrWhiteSpace(((INVT)InvtBindingSource.Current).DATE.ToString()))
                    DateEditDate.Text = validCheck.convertDate(DateEditDate.Text);
                else if (string.IsNullOrWhiteSpace(DateEditDate.Text) && !string.IsNullOrWhiteSpace(((INVT)InvtBindingSource.Current).DATE.ToString()))
                    DateEditDate.Text = validCheck.convertDate(DateEditDate.Text);
                else if (string.IsNullOrWhiteSpace(DateEditDate.Text) && string.IsNullOrWhiteSpace(((INVT)InvtBindingSource.Current).DATE.ToString()))
                    ((INVT)InvtBindingSource.Current).DATE = null;
                else if (!string.IsNullOrWhiteSpace(DateEditDate.Text) && !string.IsNullOrWhiteSpace(((INVT)InvtBindingSource.Current).DATE.ToString()))
                    DateEditDate.Text = validCheck.convertDate(DateEditDate.Text);
            
        }

        private void dateEdit1_TextChanged(object sender, EventArgs e)
        {
            DateEditBuildFrom.Text = validCheck.convertDate(DateEditBuildFrom.Text);
        }

        private void dateEdit2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(DateEditBuildFrom.Text) && !string.IsNullOrWhiteSpace(DateEditBuildThrough.Text))
            {
                DateEditBuildThrough.Text = validCheck.convertDate(DateEditBuildThrough.Text);
                DateTime date = Convert.ToDateTime(DateEditBuildFrom.Text);
                ComboBoxEditBuildEvery.Text = date.DayOfWeek.ToString();
                SpinEditBuildDays.Value = 7;
                GridViewInvt.SetFocusedRowCellValue("DATE", date);
                DateEditDate.EditValue = date;
            }
        }

        private void barButtonItemAddRec_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (modified == false)
            //{
            //    if (validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((INVT)InvtBindingSource.Current).checkAll, InvtBindingSource))
            //    {
            //        newRec = true;
            //        modified = false;
            //        _item = context.INVT.CreateObject();
            //        EditItem(_item);
            //    }
            //}
            //else
            //{
            //    validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((INVT)InvtBindingSource.Current).checkAll, InvtBindingSource);
            //}
        }

        private void barButtonItemSaveRec_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveItem(); 
        }

        private void barButtonItemDelRec_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //context.DeleteObject(_item);
            //context.SaveChanges();
            //GridControlInvMaint.DataSource = null;
            //GridControlInvMaint.DataSource = _efSrc;
            //panelControlStatus.Visible = true;
            //LabelStatus.Text = "Record Deleted";
            //rowStatusDelete = new Timer();
            //rowStatusDelete.Interval = 3000;
            //rowStatusDelete.Start();
            //rowStatusDelete.Tick += new EventHandler(TimedEventDelete);
        }

        //private void TimedEventDelete(object sender, EventArgs e)
        //{
        //    panelControlStatus.Visible = false;
        //    rowStatusDelete.Stop();
        //}

        private void SaveItem()
        {
        //    if (modified || newRec)
        //    {
        //        if (validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((INVT)InvtBindingSource.Current).checkAll, InvtBindingSource))
        //        {
        //            InvtBindingSource.EndEdit();

        //            try
        //            {
        //                context.INVT.AddObject(_item);
        //            }
        //            catch (Exception)
        //            {

        //                context.INVT.ApplyCurrentValues(_item);
        //            }

        //            context.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
        //            context.DetectChanges();
        //            //advBandedGridView1.MoveFirst();
        //            //context = new FlextourEntities(sys.Settings.EFConnectionString);
        //            //InvtBindingSource.DataSource = context.INVT.Take(500);
        //            panelControlStatus.Visible = true;
        //            LabelStatus.Text = "Record Saved";
        //            rowStatusSave = new Timer();
        //            rowStatusSave.Interval = 3000;
        //            rowStatusSave.Start();
        //            rowStatusSave.Tick += TimedEventSave;
        //            GridControlInvMaint.DataSource = null;
        //            GridControlInvMaint.DataSource = _efSrc;

        //            newRec = false;
        //            modified = false;
        //        }
        //    }
        }

       

        private void InvMaint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewInvt.IsFilterRow(GridViewInvt.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewInvt.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewInvt.GetFocusedDisplayText()))
                value = GridViewInvt.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = string.Format("it.CODE like '{0}%'", GridViewInvt.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE")); 
                //string query = String.Format("it.{0} like '{1}%'", colName, value);
                var special = context.INVT.Where(query);
                if (!string.IsNullOrWhiteSpace(GridViewInvt.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "TYPE")))
                {
                    query = String.Format("it.{0} like '{1}%'", "TYPE", GridViewInvt.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "TYPE"));
                    special = special.Where(query);
                }
                if (!string.IsNullOrWhiteSpace(GridViewInvt.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "AGENCY")))
                {
                    query = String.Format("it.{0} like '{1}%'", "AGENCY", GridViewInvt.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "AGENCY"));
                    special = special.Where(query);
                }
                if (!string.IsNullOrWhiteSpace(GridViewInvt.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CAT")))
                {
                    query = String.Format("it.{0} like '{1}%'", "CAT", GridViewInvt.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CAT"));
                    special = special.Where(query);
                }
                if (!string.IsNullOrWhiteSpace(GridViewInvt.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "DATE")))
                {
                    string validDate = GridViewInvt.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "DATE");
                    string values = validCheck.convertDate(validDate);
                    if (!string.IsNullOrWhiteSpace(values))
                    {
                        DateTime startDate = Convert.ToDateTime(values);
                        special = special.Where("it.DATE >= @date", new ObjectParameter("date", startDate));
                    }
                }
                int count = special.Count();
                if (count > 0)
                {
                    InvtBindingSource.DataSource = special;
                    GridViewInvt.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                    GridViewInvt.FocusedRowHandle = 0;
                    GridViewInvt.FocusedColumn.FieldName = colName;
                    GridViewInvt.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewInvt.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {

            if (e.Column.FieldName == "DATE")
                if (e.Value != null)
                    if (!string.IsNullOrWhiteSpace(e.Value.ToString()))
                        e.DisplayText = validCheck.convertDate(e.Value.ToString());

           
        }
         
        private void setValues()
        {            
            GridViewInvt.SetFocusedRowCellValue("TYPE", string.Empty);
            GridViewInvt.SetFocusedRowCellValue("CODE", string.Empty);
            GridViewInvt.SetFocusedRowCellValue("CAT", string.Empty);
            GridViewInvt.SetFocusedRowCellValue("TP", string.Empty);
            GridViewInvt.SetFocusedRowCellValue("ORIG_AMT", 0);
            GridViewInvt.SetFocusedRowCellValue("AV_AMT", 0);
            GridViewInvt.SetFocusedRowCellValue("AV", string.Empty);
            GridViewInvt.SetFocusedRowCellValue("MIN", 0);
            GridViewInvt.SetFocusedRowCellValue("CANC", 0);
            GridViewInvt.SetFocusedRowCellValue("REL", 0);
            GridViewInvt.SetFocusedRowCellValue("AGENCY", string.Empty);
            GridViewInvt.SetFocusedRowCellValue("RELCODE", string.Empty);
            GridViewInvt.SetFocusedRowCellValue("RELCAT", string.Empty);
             GridViewInvt.SetFocusedRowCellValue("RELTYP", string.Empty);
            GridViewInvt.SetFocusedRowCellValue("RELAGY", string.Empty);
            GridViewInvt.SetFocusedRowCellValue("ALLOCTD", 0);
            GridViewInvt.SetFocusedRowCellValue("HOLD", 0);
              GridViewInvt.SetFocusedRowCellValue("MIN_BK_DAYS", 0);
             GridViewInvt.SetFocusedRowCellValue("MAX", 0);
            GridViewInvt.SetFocusedRowCellValue("Requestable", false);
            SpinEditMinBkDays.Properties.ReadOnly = true;
            SpinEditMax.Properties.ReadOnly = true;
            SpinEditMin.Properties.ReadOnly = true;
            SpinEditCanc.Properties.ReadOnly = true;
            SpinEditOrig_Amt.Properties.ReadOnly = true;
            SpinEditHold.Properties.ReadOnly = true;
            ComboBoxEditRelTyp.Properties.ReadOnly = true;
            ComboBoxEditTP.Properties.ReadOnly = true;
            checkEditSyn.Checked = true;
        }

     

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            GridViewInvt.ClearColumnsFilter();
            //if (bBuild)
            //{
            //    ComboBoxEditType.Focus();
            //    setReadOnly(false);
            //    newRec = true;
            //    setValues();
            //    return;
            //}
            if (bBuild)
            {
                CheckEditOverwrite.Checked = true;
                CheckEditSkip.Checked = false;
                DateEditBuildFrom.Text = string.Empty;
                DateEditBuildThrough.Text = string.Empty;
                ComboBoxEditBuildEvery.Text = string.Empty;
                SpinEditBuildDays.Value = 7;              
            }

            if (InvtBindingSource.Current == null)
            {
                InvtBindingSource.DataSource = from opt in context.INVT where opt.CODE == "K9JM" select opt;             
               InvtBindingSource.AddNew();
                if (GridViewInvt.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewInvt.FocusedRowHandle = GridViewInvt.RowCount - 1;

                ComboBoxEditType.Focus();
                setReadOnly(false);
                newRec = true;
                setValues();
                return;
            }
            ComboBoxEditType.Focus();
            //bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewInvt.CloseEditor();
            bool temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (INVT)InvtBindingSource.Current);

                InvtBindingSource.AddNew();
                if (GridViewInvt.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewInvt.FocusedRowHandle = GridViewInvt.RowCount - 1;
                setValues();
                ComboBoxEditType.Focus();
                setReadOnly(false);
                newRec = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (InvtBindingSource.Current == null)
                return;

            GridViewInvt.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Modified = false;
                newRec = false;
                InvtBindingSource.RemoveCurrent();
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
            currentVal = ComboBoxEditType.Text;
        }

        private bool buildForms()
        {
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((INVT)InvtBindingSource.Current).checkAll, InvtBindingSource);
            if (validateMain)
                return true;
            else
            {
                MessageBox.Show("Please correct error(s) before attempting to build the records.");
                return false;
            }
        }

        private bool checkForms()
        {
            if (!_modified && !newRec)
                return true;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((INVT)InvtBindingSource.Current).checkAll, InvtBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref _modified, true, ref newRec, context, InvtBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref _modified, false, ref newRec, context, InvtBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }
        private void BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            
            if (InvtBindingSource.Current == null)
                return;          

            if (CheckRelease())
            {
                GridViewInvt.CloseEditor();
                ComboBoxEditType.Focus();
               // bindingNavigatorPositionItem.Focus();//trigger field leave event
                if (bBuild)
                {
                    if (buildForms())
                    {
                        //add overwrite code here
                        string code = ImageComboBoxEditCode.EditValue.ToString();
                        string agency = ImageComboBoxEditAgency.EditValue.ToString();
                        string cat = ImageComboBoxEditCat.EditValue.ToString();
                         string startDay = ComboBoxEditBuildEvery.Text;
                        int interval = (int)SpinEditBuildDays.Value;
                        DateTime startDate = Convert.ToDateTime(DateEditBuildFrom.Text);
                        DateTime endDate = Convert.ToDateTime(DateEditBuildThrough.Text);
                        bool overWritten = false;
                        bool skip = false;
                        Modified = false;
                        newRec = false;
                        bool firstRecSkipped = false;
                        for (var day = startDate.Date; day.Date <= endDate.Date; day = day.AddDays(1))
                            if (day.DayOfWeek.ToString() == startDay)
                                for (int x = 0; x < interval; x++)
                                {
                                    DateTime saveDate = day.AddDays(x);
                           
                                    if (saveDate.Date <= endDate.Date )
                                    {                           
                                        
                                        INVT rec = new FlexModel.INVT();
                                        rec.TYPE = ComboBoxEditType.Text;
                                        rec.CODE = ImageComboBoxEditCode.EditValue.ToString();
                                        rec.CAT = ImageComboBoxEditCat.EditValue.ToString();
                                        rec.TP = ComboBoxEditTP.Text;
                                        rec.DATE = saveDate.Date;
                                        rec.UPD_DATE = DateTime.Now;
                                        rec.UPD_BY = username;
                                        rec.ORIG_AMT = (short)SpinEditOrig_Amt.Value;
                                        rec.AV_AMT = (short)SpinEditAv_Amt.Value;
                                        rec.AV = ComboBoxEditAV.Text;
                                        rec.MIN = (short)SpinEditMin.Value;
                                        rec.CANC = (short)SpinEditCanc.Value;
                                        rec.REL = (short)SpinEditRel.Value;
                                        rec.AGENCY = ImageComboBoxEditAgency.EditValue.ToString();
                                        rec.RELCODE = ImageComboBoxEditRelCode.EditValue.ToString();
                                        rec.RELCAT = ImageComboBoxEditRelCat.EditValue.ToString();
                                        rec.RELTYP = ComboBoxEditRelTyp.Text;
                                        rec.RELAGY = ImageComboBoxEditRelAgency.EditValue.ToString();
                                        rec.ALLOCTD = (short)SpinEditAlloctd.Value;
                                        rec.HOLD = (short)SpinEditHold.Value;
                                        rec.MIN_BK_DAYS = (short)SpinEditMinBkDays.Value;
                                        rec.MAX = (short)SpinEditMax.Value;
                                        rec.Requestable = CheckEditReq.Checked;
                                        rec.ID = int.MaxValue;
                                        if (CheckEditOverwrite.Checked)
                                        {
                                            var existingRecs = from invtRec in context.INVT where invtRec.TYPE == ComboBoxEditType.Text && invtRec.CODE == code && invtRec.AGENCY == agency && invtRec.CAT == cat && invtRec.TP == ComboBoxEditTP.Text && invtRec.DATE == saveDate  select invtRec;
                                            foreach (INVT exists in existingRecs)
                                            {
                                                context.INVT.DeleteObject(exists);
                                                overWritten = true;
                                            }
                                            context.SaveChanges();
                                            if(saveDate != startDate)
                                                context.INVT.AddObject(rec);
                                            context.SaveChanges();
                                            
                                        }

                                        if (CheckEditSkip.Checked)
                                        {
                                            if ((from invtRec in context.INVT where invtRec.TYPE == ComboBoxEditType.Text && invtRec.CODE == code && invtRec.AGENCY == agency && invtRec.CAT == cat && invtRec.TP == ComboBoxEditTP.Text && invtRec.DATE == saveDate select invtRec).Count() == 0)
                                            {
                                                if (firstRecSkipped || saveDate == startDate)
                                                {
                                                    firstRecSkipped = false;
                                                    GridViewInvt.SetFocusedRowCellValue("DATE", saveDate);
                                                    context.SaveChanges();
                                                }
                                                else
                                                {
                                                    context.INVT.AddObject(rec);
                                                    context.SaveChanges();
                                                }
                                            }
                                            else
                                            {
                                                skip = true;
                                                if (saveDate == startDate)
                                                    firstRecSkipped = true;
                                            }
                                        }                                       
                                    }
                                }

                        if (overWritten)
                            MessageBox.Show("Inventory build completed succesfully. \n There were existing records that were overwritten.");
                        else if(skip)
                            MessageBox.Show("Inventory build completed succesfully. \n There were existing records that were skipped.");
                        else
                            MessageBox.Show("Inventory build completed succesfully.");
                    }
                    return;
                }


                bool temp = newRec;
                if (checkForms())
                {
                    ComboBoxEditType.Focus();
                    setReadOnly(true);
                    panelControlStatus.Visible = true;
                    LabelStatus.Text = "Record Saved";
                    rowStatusSave = new Timer();
                    rowStatusSave.Interval = 3000;
                    rowStatusSave.Start();
                    rowStatusSave.Tick += TimedEventSave;
                }
                if (!temp && !_modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (INVT)InvtBindingSource.Current);

            }
            else
                MessageBox.Show("There is no release record.");

        }

        private bool CheckRelease()
        {

            if(ImageComboBoxEditCode.Text == ImageComboBoxEditRelCode.Text && ImageComboBoxEditAgency.Text == ImageComboBoxEditRelAgency.Text && ImageComboBoxEditCat.Text == ImageComboBoxEditRelCat.Text && ComboBoxEditTP.Text == ComboBoxEditRelTyp.Text)
                return true;

            string code = ImageComboBoxEditRelCode.EditValue.ToString();
            string cat = ImageComboBoxEditRelCat.EditValue.ToString();
            string agency = ImageComboBoxEditRelAgency.EditValue.ToString();
            string room = ComboBoxEditRelTyp.Text;

            var recs = from invtRec in context.INVT where invtRec.CODE == code && invtRec.CAT == cat && invtRec.AGENCY == agency && invtRec.TP == room select invtRec;
            if (recs.Count() > 0)
                return true;

            return false;
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private void ImageComboBoxEditCode_Leave(object sender, EventArgs e)
        {
            if (InvtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }

                validCheck.check(sender, errorProvider1, ((INVT)InvtBindingSource.Current).checkCODE, InvtBindingSource);
            }
        }

        private void ImageComboBoxEditAgency_Leave(object sender, EventArgs e)
        {
            if (InvtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }

                validCheck.check(sender, errorProvider1, ((INVT)InvtBindingSource.Current).checkAgency, InvtBindingSource);
            }
        }

        private void ImageComboBoxEditCat_Leave(object sender, EventArgs e)
        {
            if (InvtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }

                validCheck.check(sender, errorProvider1, ((INVT)InvtBindingSource.Current).checkCAT, InvtBindingSource);
            }
        }

        private void ImageComboBoxEditRelCode_Leave(object sender, EventArgs e)
        {
            if (InvtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((INVT)InvtBindingSource.Current).checkRelCode, InvtBindingSource);
            }
        }

        private void ImageComboBoxEditRelAgency_Leave(object sender, EventArgs e)
        {
            if (InvtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((INVT)InvtBindingSource.Current).checkRelAgy, InvtBindingSource);
            }
        }

        private void ImageComboBoxEditRelCat_Leave(object sender, EventArgs e)
        {
            if (InvtBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((INVT)InvtBindingSource.Current).checkRelCat, InvtBindingSource);
            }
        }

        private void InvtBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (InvtBindingSource.Current != null)
            {
                enableNavigator(true);
                if (!string.IsNullOrWhiteSpace(DateEditDate.Text))
                    DateEditDate.Text = validCheck.convertDate(DateEditDate.Text);
                checkEditSyn.Checked = true;
                SpinEditOrig_Amt.Properties.ReadOnly = true;
            }
            else
                enableNavigator(false);
        }

        private void aV_AMTSpinEdit_ValueChanged(object sender, EventArgs e)
        {
            if (SpinEditOrig_Amt.Properties.ReadOnly == true)
            {
                SpinEditOrig_Amt.Value = SpinEditAv_Amt.Value;
            }
        }

        private void ImageComboBoxEditAgency_TextChanged(object sender, EventArgs e)
        {
            if (ImageComboBoxEditAgency.EditValue.ToString() == "TARIFF")
            {
                ImageComboBoxEditRelAgency.EditValue = "TARIFF";
                ImageComboBoxEditRelAgency.Properties.ReadOnly = true;

            }
            ComboBoxEditAV.Properties.Items.Clear();
            string agency = ImageComboBoxEditAgency.EditValue.ToString();
            if (ComboBoxEditType.Text == "HTL")
            {
                if (agency == defAgy)
                {
                    string[] vals = { "A", "C", "R", "S", "Q" };
                    ComboBoxEditAV.Properties.Items.AddRange(vals);
                }
                else
                {
                    string[] vals = { "A", "C",  "S", };
                    ComboBoxEditAV.Properties.Items.AddRange(vals);
                }
            }

            if (ComboBoxEditType.Text != "HTL")
            {
                if (agency == defAgy)
                {
                    string[] vals = { "A", "C", "R" };
                    ComboBoxEditAV.Properties.Items.AddRange(vals);
                }
                else
                {
                    string[] vals = { "A", "C", };
                    ComboBoxEditAV.Properties.Items.AddRange(vals);
                }
            }          
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                InvtBindingSource.MoveNext();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                InvtBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                InvtBindingSource.MoveLast();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (move())
                InvtBindingSource.MoveFirst();
        }

        private void ImageComboBoxEditCode_TextChanged(object sender, EventArgs e)
        {
            if (ComboBoxEditType.Text == "HTL")
            {
                string code = ImageComboBoxEditCode.EditValue.ToString();
                HOTEL rec = (HOTEL)(from hotrec in context.HOTEL where hotrec.CODE == code select hotrec).FirstOrDefault();
                if (!string.IsNullOrWhiteSpace(rec.CONTR_CDE) && (rec.CONTR_CDE == "P" || rec.CONTR_CDE == "C"))
                {
                    ImageComboBoxEditAgency.EditValue = rec.CONTR_AGY;
                    ImageComboBoxEditAgency.Properties.ReadOnly = true;

                    ImageComboBoxEditRelCode.EditValue = ImageComboBoxEditCode.EditValue;
                    ImageComboBoxEditRelAgency.EditValue = rec.CONTR_AGY;
                    ImageComboBoxEditRelCode.Properties.ReadOnly = true;
                    ImageComboBoxEditRelAgency.Properties.ReadOnly = true;
                }
                else
                    ImageComboBoxEditAgency.Properties.ReadOnly = false;

            }
        }

        private void ImageComboBoxEditCode_EditValueChanged(object sender, EventArgs e)
        {
            ImageComboBoxEditRelCode.EditValue = ImageComboBoxEditCode.EditValue;
        }

        private void ImageComboBoxEditAgency_EditValueChanged(object sender, EventArgs e)
        {
            ImageComboBoxEditRelAgency.EditValue = ImageComboBoxEditAgency.EditValue;

            string agency = ImageComboBoxEditAgency.EditValue.ToString();
            AGY rec = (AGY)(from agyRec in context.AGY where agyRec.NO == agency select agyRec).FirstOrDefault();
            if(rec != null)
                SpinEditRel.Value = (decimal)rec.REL;
        }

        private void ImageComboBoxEditCat_EditValueChanged(object sender, EventArgs e)
        {
            ImageComboBoxEditRelCat.EditValue = ImageComboBoxEditCat.EditValue;
 
        }

        private void tPComboBoxEdit_EditValueChanged(object sender, EventArgs e)
        {
            ComboBoxEditRelTyp.EditValue = ComboBoxEditTP.EditValue;
        }

        private void GridViewInvt_BeforeLeaveRow(object sender, RowAllowEventArgs e)
        {
            if (InvtBindingSource.Current == null)
            {
                e.Allow = true;
                return;
            }
            
            
            bool temp = newRec;
            bool temp2 = _modified;
            if (checkForms())
            {
                errorProvider1.Clear();
                e.Allow = true;
                if ((!temp) && temp2)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (INVT)InvtBindingSource.Current);
            }
            else
            {
                if (!temp && !_modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (INVT)InvtBindingSource.Current);

                e.Allow = false;
            }
        }

        private void CheckEditSync_Click(object sender, EventArgs e)
        {

        }

        private void CheckEditSkip_Click(object sender, EventArgs e)
        {

        }

        private void CheckEditOverwrite_Click(object sender, EventArgs e)
        {

        }

    }

}