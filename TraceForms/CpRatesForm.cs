using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using FlexModel;
using System.Data.Entity.Core.Objects;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using System.Linq;
using System.Linq.Dynamic;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System.Runtime.InteropServices;
using System.Data;
using System.Drawing;
using System.Text;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraGrid;
using System.ComponentModel.DataAnnotations;

namespace TraceForms
{
    
    public partial class CpRatesForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool _modified = false;
        public bool newRec = false;
        public bool temp = false;
        public string username;
        const string colName = "colCODE";
        public FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        private FlexInterfaces.Core.ICoreSys _sys;

        public CpRatesForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            _sys = sys;
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
            yEARComboBoxEdit.Properties.Items.Add(DateTime.Today.Year);
            yEARComboBoxEdit.Properties.Items.Add(DateTime.Today.Year + 1);
            yEARComboBoxEdit.Properties.Items.Add(DateTime.Today.Year + 2);
            yEARComboBoxEdit.Properties.Items.Add(DateTime.Today.Year + 3);
            yEARComboBoxEdit.Properties.Items.Add(DateTime.Today.Year + 4);
            yEARComboBoxEdit.Properties.Items.Add(DateTime.Today.Year + 5);
            Modified = false;
            newRec = false;
            var agy = from agyRec in context.AGY orderby agyRec.NO ascending select new { agyRec.NO, agyRec.NAME };
            
            var cat = from catRec in context.ROOMCOD orderby catRec.CODE ascending select new { catRec.CODE, catRec.DESC };
            var car = from carRec in context.COMP orderby carRec.CODE ascending select new { carRec.CODE, carRec.NAME };
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxEditCode.Properties.Items.Add(loadBlank);
            ImageComboBoxEditAgency.Properties.Items.Add(loadBlank);           
            ImageComboBoxEditCategory.Properties.Items.Add(loadBlank);         

            foreach (var result in agy)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.NO.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.NO.TrimEnd() };
                ImageComboBoxEditAgency.Properties.Items.Add(load);
            }
            foreach (var result in car)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCode.Properties.Items.Add(load);
            }
            foreach (var result in cat)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.DESC.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCategory.Properties.Items.Add(load);
            }
            setReadOnly(true);
            enableNavigator(false);
            expandContractGridButton.Tag = "right";
            cOMM_PCTSpinEdit.Enabled = false;
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
                if (value && CpRateBindingSource.Current != null) {
                    //NB: Before updating any property on the entity, any pending edits must be committed 
                    //with bindingSource.EndEdit, other when the properties are set the form bindings are
                    //automatically refreshed, which causes any pending edits to be lost. 
                    CpRateBindingSource.EndEdit();
                    CPRATES rate = (CPRATES)CpRateBindingSource.Current;
                    rate.LAST_UPD = DateTime.Now;
                    rate.UPD_INIT = username;
                }
            }
        }

        void enableNavigator(bool value)
        {
            bindingNavigatorMoveNextItem.Enabled = value;
            bindingNavigatorMoveLastItem.Enabled = value;
            bindingNavigatorMoveFirstItem.Enabled = value;
            bindingNavigatorMovePreviousItem.Enabled = value;
        }


     
        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        private void setReadOnly(bool value)
        {
            ImageComboBoxEditCode.Properties.ReadOnly = value;
            ImageComboBoxEditAgency.Properties.ReadOnly = value;
            ImageComboBoxEditCategory.Properties.ReadOnly = value;
            sTART_DATEDateEdit.Properties.ReadOnly = value;
            GridViewCprates.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = !value;
        }
        void ButtonEdit_QueryPopUp1(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
        }

        private bool move()
        {
            ImageComboBoxEditCode.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( CPRATES)CpRateBindingSource.Current);               
                GridViewCprates.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = false;
                setReadOnly(true);
                newRec = false;
                Modified = false;
                return true;
            }
            return false;
        }

        private void setValues()
        {
            GridViewCprates.SetFocusedRowCellValue("CODE", string.Empty);
            GridViewCprates.SetFocusedRowCellValue("CAT", string.Empty);
            GridViewCprates.SetFocusedRowCellValue("H_L", string.Empty);
            GridViewCprates.SetFocusedRowCellValue("YEAR", 0);
            GridViewCprates.SetFocusedRowCellValue("DESC", string.Empty);
            GridViewCprates.SetFocusedRowCellValue("PP1", 0);
            GridViewCprates.SetFocusedRowCellValue("GPP1", 0);
            GridViewCprates.SetFocusedRowCellValue("NPP1", 0);
            GridViewCprates.SetFocusedRowCellValue("PP2", 0);
            GridViewCprates.SetFocusedRowCellValue("GPP2", 0);
            GridViewCprates.SetFocusedRowCellValue("NPP2", 0);
            GridViewCprates.SetFocusedRowCellValue("PP3", 0);
            GridViewCprates.SetFocusedRowCellValue("GPP3", 0);
            GridViewCprates.SetFocusedRowCellValue("NPP3", 0);
            GridViewCprates.SetFocusedRowCellValue("PP4", 0);
            GridViewCprates.SetFocusedRowCellValue("GPP4", 0);
            GridViewCprates.SetFocusedRowCellValue("NPP4", 0);
            GridViewCprates.SetFocusedRowCellValue("PP5", 0);
            GridViewCprates.SetFocusedRowCellValue("GPP5", 0);
            GridViewCprates.SetFocusedRowCellValue("NPP5", 0);
            GridViewCprates.SetFocusedRowCellValue("PP6", 0);
            GridViewCprates.SetFocusedRowCellValue("GPP6", 0);
            GridViewCprates.SetFocusedRowCellValue("NPP6", 0);
            GridViewCprates.SetFocusedRowCellValue("PP7", 0);
            GridViewCprates.SetFocusedRowCellValue("GPP7", 0);
            GridViewCprates.SetFocusedRowCellValue("NPP7", 0);
            GridViewCprates.SetFocusedRowCellValue("PP8", 0);
            GridViewCprates.SetFocusedRowCellValue("GPP8", 0);
            GridViewCprates.SetFocusedRowCellValue("NPP8", 0);
            GridViewCprates.SetFocusedRowCellValue("PP9", 0);
            GridViewCprates.SetFocusedRowCellValue("GPP9", 0);
            GridViewCprates.SetFocusedRowCellValue("NPP9", 0);
            GridViewCprates.SetFocusedRowCellValue("PP10", 0);
            GridViewCprates.SetFocusedRowCellValue("GPP10", 0);
            GridViewCprates.SetFocusedRowCellValue("NPP10", 0);
            GridViewCprates.SetFocusedRowCellValue("AGENCY", string.Empty);
            GridViewCprates.SetFocusedRowCellValue("JR_GRATE", 0);
            GridViewCprates.SetFocusedRowCellValue("JR_NRATE", 0);
            GridViewCprates.SetFocusedRowCellValue("JR_LIMIT", 0);
            GridViewCprates.SetFocusedRowCellValue("CHD_GRATE", 0);
            GridViewCprates.SetFocusedRowCellValue("CHD_NRATE", 0);
            GridViewCprates.SetFocusedRowCellValue("CHD_LIMIT", 0);
            GridViewCprates.SetFocusedRowCellValue("COMM_FLG", "N");
            GridViewCprates.SetFocusedRowCellValue("COMM_PCT", 0);
            GridViewCprates.SetFocusedRowCellValue("Unit_Rate", "0");
            GridViewCprates.SetFocusedRowCellValue("Time", string.Empty);
            GridViewCprates.SetFocusedRowCellValue("Transport_Type", string.Empty);
            GridViewCprates.SetFocusedRowCellValue("Vendor_Code", string.Empty);
            GridViewCprates.SetFocusedRowCellValue("Vendor_Code_Chd", string.Empty);
            GridViewCprates.SetFocusedRowCellValue("Vendor_Code_Jr", string.Empty);
            GridViewCprates.SetFocusedRowCellValue("Inactive", false);
            GridViewCprates.SetFocusedRowCellValue("Inhouse", false);
            GridViewCprates.SetFocusedRowCellValue("SpecialValue_Code", string.Empty);
            GridViewCprates.SetFocusedRowCellValue("Currency_CodeSheet", string.Empty);
            GridViewCprates.SetFocusedRowCellValue("Currency_CodePayment", string.Empty);
            GridViewCprates.SetFocusedRowCellValue("ExchangeRate", 0);
			GridViewCprates.SetFocusedRowCellValue("START_DATE", string.Empty);
		}

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

            GridViewCprates.ClearColumnsFilter();
            if (CpRateBindingSource.Current == null)
            {
                //fake query in order to create a link between the database table and the binding source
                CpRateBindingSource.DataSource = from opt in context.CPRATES where opt.CODE == "KJM9" select opt;
                CpRateBindingSource.AddNew();
                if (GridViewCprates.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewCprates.FocusedRowHandle = GridViewCprates.RowCount - 1;
                setValues();
                setReadOnly(false);
                ImageComboBoxEditCode.Focus();                             
                GridViewCprates.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = true;
                
                newRec = true;
                return;
            }
            ImageComboBoxEditCode.Focus();
            //bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewCprates.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( CPRATES)CpRateBindingSource.Current);
               
                CpRateBindingSource.AddNew();
                if (GridViewCprates.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewCprates.FocusedRowHandle = GridViewCprates.RowCount - 1;
                setValues();
                setReadOnly(false);
                ImageComboBoxEditCode.Focus();                               
                GridViewCprates.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = true;
                newRec = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current == null)
                return;
            
            GridViewCprates.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                
                Modified = false;
                newRec = false;
                CpRateBindingSource.RemoveCurrent();
                errorProvider1.Clear();
                context.SaveChanges();                
                GridViewCprates.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = false;
                setReadOnly(true);
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);

            }
            ImageComboBoxEditCode.Focus();           
            Modified = false;
            newRec = false;
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }

        private bool checkForms()
        {
            if (!_modified && !newRec)
                return true;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkAll, CpRateBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref _modified, true, ref newRec, context, CpRateBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref _modified, false, ref newRec, context, CpRateBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }

        private void cPRATEBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current == null)
                return;
            ImageComboBoxEditCode.Focus();
			//Overlapping ratesheets are no longer an error, because the business logic takes care of which
			//one should be used.  User can see which ones are overlapping using the menu option but should
			//not be prevented from saving.

			//DateTime start = new DateTime();
			//DateTime end = new DateTime();
			//if (!string.IsNullOrWhiteSpace(sTART_DATEDateEdit.Text))
			//	start = Convert.ToDateTime(sTART_DATEDateEdit.Text);

			//if (!string.IsNullOrWhiteSpace(eND_DATEDateEdit.Text))
			//	end = Convert.ToDateTime(eND_DATEDateEdit.Text);
			//string code = ImageComboBoxEditCode.EditValue.ToString();
			//string agency = ImageComboBoxEditAgency.EditValue.ToString();
			//string cat = ImageComboBoxEditCategory.EditValue.ToString();
			//string time = timeTextEdit.Text;
			//decimal busTourStops = spinEditRouteStops.Value;
			//decimal busTourDays = spinEditRouteDays.Value;
			//int id = (int)GridViewCprates.GetFocusedRowCellValue("ID");
			//bool inactive = (bool)inactiveCheckEdit.EditValue;
			//if (!inactive)
			//{
			//	//The sql I want to determine date overlaps:
			//	//start between c.START_DATE and c.END_DATE OR end between c.START_DATE and c.END_DATE OR
			//	//c.START_DATE between start and end OR c.END_DATE between start and end
			//	var load = from c in context.CPRATES
			//			   where c.CODE == code && c.ID != id && c.AGENCY == agency && c.CAT == cat && c.Inactive == false 
			//				&& c.Time == time && (c.BusTourDays ?? 0) == busTourDays && (c.BusTourStops ?? 0) == busTourStops
			//				   && ((start >= c.START_DATE && start <= c.END_DATE) || (end >= c.START_DATE && end <= c.END_DATE)
			//				   || (c.START_DATE >= start && c.START_DATE <= end) || (c.END_DATE >= start && c.END_DATE <= end))
			//					select c;
			//	if (load.Count() > 0)
			//	{
			//		foreach (var val in load)
			//		{
			//			DateTime? value1 = (DateTime?)GridViewCprates.GetFocusedRowCellValue("ResDate_Start");
			//			DateTime? value2 = (DateTime?)GridViewCprates.GetFocusedRowCellValue("ResDate_End");
			//			if ((val.ResDate_Start.HasValue && val.ResDate_End.HasValue && value1.HasValue && value2.HasValue) || (!val.ResDate_Start.HasValue && !val.ResDate_End.HasValue && !value1.HasValue && !value2.HasValue))
			//			{
			//				MessageBox.Show("This would be an overlapping rate. Please correct the date values.");
			//				return;
			//			}
			//		}
			//	}
			//}
            if (!checkKids())
            {
                DialogResult select = XtraMessageBox.Show("You have entered a rate without a max age. This item type will not be available, is this correct?", "FlexTour Maintenance", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered.");
                    return;
                }
            }

            if (!checkRatePpl())
            {
                DialogResult select = XtraMessageBox.Show("You have entered a rate without a max number of people. This item type will not be available, is this correct?", "FlexTour Maintenance", MessageBoxButtons.YesNo);
                if (select == DialogResult.No)
                {
                    XtraMessageBox.Show("Please correct the value entered.");                    
                    return;
                }

            }

            
            GridViewCprates.CloseEditor();
            
            bool temp = newRec;
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            if (checkForms())
            {
                ImageComboBoxEditCode.Focus();              
                GridViewCprates.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = false;
                setReadOnly(true);
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
            }

            if(!temp && !_modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CPRATES)CpRateBindingSource.Current);               
           
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (move())
                CpRateBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                CpRateBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                CpRateBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                CpRateBindingSource.MoveLast();
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (CpRateBindingSource.Current == null)
            {
                e.Allow = true;
                return;
            }
            temp = newRec;
            bool temp2 = _modified;

            if (checkForms())
            {
                e.Allow = true;
                if ((!temp) && temp2)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CPRATES)CpRateBindingSource.Current);


                GridViewCprates.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = false;
                setReadOnly(true);

            }
            else
            {
                if (!temp && !_modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CPRATES)CpRateBindingSource.Current);               
        
                e.Allow = false;

            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewCprates.IsFilterRow(e.RowHandle))
                Modified = true;
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            temp = newRec;
           if (!temp && checkForms())
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( CPRATES)CpRateBindingSource.Current);
           
            GridViewCprates.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = false;
            setReadOnly(true);
        }

        private void CpRatesForm_FormClosing(object sender, FormClosingEventArgs e)
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
     
        private void sTART_DATEDateEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkStart, CpRateBindingSource);
            }
        }

        private void timeTimeEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkTime, CpRateBindingSource);
            }
        }

        private void resDate_StartDateEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkResStart, CpRateBindingSource);
            }

        }

        private void eND_DATEDateEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkEnd, CpRateBindingSource);
            }
        }

        private void resDate_EndDateEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkResEnd, CpRateBindingSource);
            }

        }

        private void h_LTextEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkSeason, CpRateBindingSource);
            }
        }

        private void yEARComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkYear, CpRateBindingSource);
            }
        }

        private void dESCTextEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkDesc, CpRateBindingSource);
            }

        }

        private void transport_TypeComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkTransfer, CpRateBindingSource);
            }

        }

        private void vendor_CodeTextEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkVendor, CpRateBindingSource);
            }

        }

        private void pP1TextEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkNbrPpl1, CpRateBindingSource);
            }

        }

        private void pP2TextEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkNbrPpl2, CpRateBindingSource);
            }

        }

        private void pP3TextEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkNbrPpl3, CpRateBindingSource);
            }

        }

        private void pP4TextEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkNbrPpl4, CpRateBindingSource);
            }

        }

        private void pP5TextEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkNbrPpl5, CpRateBindingSource);
            }

        }

        private void pP6TextEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkNbrPpl6, CpRateBindingSource);
            }

        }

        private void pP7TextEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkNbrPpl7, CpRateBindingSource);
            }

        }

        private void pP8TextEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkNbrPpl8, CpRateBindingSource);
            }

        }

        private void pP9TextEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkNbrPpl9, CpRateBindingSource);
            }

        }

        private void pP10TextEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkNbrPpl10, CpRateBindingSource);
            }

        }

        private void gPP1TextBox_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (gPP1SpinEdit.Value < nPP1SpinEdit.Value)
                {
                    DialogResult select = XtraMessageBox.Show("The gross is less than the cost. Is this correct?", "Gross", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be higher than the cost.");
                        gPP1SpinEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkGrossPpl1, CpRateBindingSource);
            }

        }

        private void gPP2TextBox_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (gPP2SpinEdit.Value < nPP2SpinEdit.Value)
                {
                    DialogResult select = XtraMessageBox.Show("The gross is less than the cost. Is this correct?", "Gross", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be higher than the cost.");
                        gPP2SpinEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkGrossPpl2, CpRateBindingSource);
            }

        }

        private void gPP3TextBox_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (gPP3SpinEdit.Value < nPP3SpinEdit.Value)
                {
                    DialogResult select = XtraMessageBox.Show("The gross is less than the cost. Is this correct?", "Gross", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be higher than the cost.");
                        gPP3SpinEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkGrossPpl3, CpRateBindingSource);
            }

        }

        private void gPP4TextBox_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (gPP4SpinEdit.Value < nPP4SpinEdit.Value)
                {
                    DialogResult select = XtraMessageBox.Show("The gross is less than the cost. Is this correct?", "Gross", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be higher than the cost.");
                        gPP4SpinEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkGrossPpl4, CpRateBindingSource);
            }

        }

        private void gPP5TextBox_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (gPP5SpinEdit.Value < nPP5SpinEdit.Value)
                {
                    DialogResult select = XtraMessageBox.Show("The gross is less than the cost. Is this correct?", "Gross", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be higher than the cost.");
                        gPP5SpinEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkGrossPpl5, CpRateBindingSource);
            }

        }

        private void gPP6TextBox_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (gPP6SpinEdit.Value < nPP6SpinEdit.Value)
                {
                    DialogResult select = XtraMessageBox.Show("The gross is less than the cost. Is this correct?", "Gross", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be higher than the cost.");
                        gPP6SpinEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkGrossPpl6, CpRateBindingSource);
            }

        }

        private void gPP7TextBox_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (gPP7SpinEdit.Value < nPP7SpinEdit.Value)
                {
                    DialogResult select = XtraMessageBox.Show("The gross is less than the cost. Is this correct?", "Gross", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be higher than the cost.");
                        gPP7SpinEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkGrossPpl7, CpRateBindingSource);
            }

        }

        private void gPP8TextBox_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (gPP8SpinEdit.Value < nPP8SpinEdit.Value)
                {
                    DialogResult select = XtraMessageBox.Show("The gross is less than the cost. Is this correct?", "Gross", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be higher than the cost.");
                        gPP8SpinEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkGrossPpl8, CpRateBindingSource);
            }

        }

        private void gPP9TextBox_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (gPP9SpinEdit.Value < nPP9SpinEdit.Value)
                {
                    DialogResult select = XtraMessageBox.Show("The gross is less than the cost. Is this correct?", "Gross", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be higher than the cost.");
                        gPP9SpinEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkGrossPpl9, CpRateBindingSource);
            }

        }

        private void gPP10TextBox_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (gPP10SpinEdit.Value < nPP10SpinEdit.Value)
                {
                    DialogResult select = XtraMessageBox.Show("The gross is less than the cost. Is this correct?", "Gross", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be higher than the cost.");
                        gPP10SpinEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkGrossPpl10, CpRateBindingSource);
            }

        }

        private void nPP1TextEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkNetPpl1, CpRateBindingSource);
            }

        }

        private void nPP2TextEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkNetPpl2, CpRateBindingSource);
            }

        }

       

        private void nPP3TextEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
               
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkNetPpl3, CpRateBindingSource);
            }
        }

        private void nPP4TextEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkNetPpl4, CpRateBindingSource);
            }

        }

        private void nPP5TextEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkNetPpl5, CpRateBindingSource);
            }

        }

        private void nPP6TextEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkNetPpl6, CpRateBindingSource);
            }

        }

        private void nPP7TextEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkNetPpl7, CpRateBindingSource);
            }

        }

        private void nPP8TextEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkNetPpl8, CpRateBindingSource);
            }

        }

        private void nPP9TextEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkNetPpl9, CpRateBindingSource);
            }

        }

        private void nPP10SpinEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkNetPpl10, CpRateBindingSource);
            }

        }

        private void cHD_GRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (cHD_GRATESpinEdit.Value < cHD_NRATESpinEdit.Value)
                {
                    DialogResult select = XtraMessageBox.Show("The gross is less than the cost. Is this correct?", "Child Junior Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be higher than the cost.");
                        cHD_NRATESpinEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkChildGross, CpRateBindingSource);
            }

        }

        /*
        *   //supposed to be a message box
                if ((JR_GRATE == 0 || JR_GRATE == null))
                    throw new ValidationException("JR_LIMIT" + ":" + "You have entered a junior age limit with no corresponding rate.");

               //supposed to be a message box
               if((CHD_GRATE == 0 || CHD_GRATE == null))
                   throw new ValidationException("CHD_LIMIT" + ":" + "You have entered a child age limit with no corresponding rate."); */



        private void cHD_NRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkChildNet, CpRateBindingSource);
            }

        }

        private void cHD_LIMITTextEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if ((cHD_GRATESpinEdit.Value == 0 && cHD_NRATESpinEdit.Value == 0) || (string.IsNullOrWhiteSpace(cHD_GRATESpinEdit.Text) && string.IsNullOrWhiteSpace(cHD_NRATESpinEdit.Text)))
                {
                    if (!string.IsNullOrWhiteSpace(cHD_LIMITTextEdit.Text) && validCheck.IsNumeric(cHD_LIMITTextEdit.Text))
                    {
                        DialogResult select = XtraMessageBox.Show("You have entered a child age limit with no corresponding rate. Is this correct?", "Child Limit", MessageBoxButtons.YesNo);
                        if (select == DialogResult.No)
                        {
                            XtraMessageBox.Show("Please correct the values entered.");
                            cHD_GRATESpinEdit.Focus();
                            return;
                        }
                    }
                    
                }

                
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkChildAge, CpRateBindingSource);
            }

        }

        private void jR_GRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (jR_GRATESpinEdit.Value < jR_NRATESpinEdit.Value)
                {
                    DialogResult select = XtraMessageBox.Show("The gross is less than the cost. Is this correct?", "Junior Gross Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        jR_GRATESpinEdit.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkJunGross, CpRateBindingSource);
            }

        }

        private void jR_NRATETextEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkJunNet, CpRateBindingSource);
            }

        }

        private void jR_LIMITTextEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if ((jR_GRATESpinEdit.Value == 0 && jR_NRATESpinEdit.Value == 0) || (string.IsNullOrWhiteSpace(jR_GRATESpinEdit.Text) && string.IsNullOrWhiteSpace(jR_NRATESpinEdit.Text)))
                {
                    if (!string.IsNullOrWhiteSpace(jR_LIMITTextEdit.Text) && validCheck.IsNumeric(jR_LIMITTextEdit.Text))
                    {
                        DialogResult select = XtraMessageBox.Show("You have entered a junior age limit with no corresponding rate. Is this correct?", "Junior Limit", MessageBoxButtons.YesNo);
                        if (select == DialogResult.No)
                        {
                            XtraMessageBox.Show("Please correct the values entered.");
                            jR_GRATESpinEdit.Focus();
                            return;
                        }
                    }
                }

                
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkJunAge, CpRateBindingSource);
            }

        }

        private void vendor_Code_JrTextEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkJunVendor, CpRateBindingSource);
            }

        }

        private void cOMM_PCTTextEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkComm, CpRateBindingSource);
            }

        }

        private void vendor_Code_ChdTextEdit_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkChildVendor, CpRateBindingSource);
            }

        }

        private void overlappiingRatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
			DateTime start = new DateTime();
			DateTime end = new DateTime();
			if (!string.IsNullOrWhiteSpace(sTART_DATEDateEdit.Text))
				start = Convert.ToDateTime(sTART_DATEDateEdit.Text);

			if (!string.IsNullOrWhiteSpace(eND_DATEDateEdit.Text))
				end = Convert.ToDateTime(eND_DATEDateEdit.Text);
			string code = ImageComboBoxEditCode.EditValue.ToString();
            string agency = ImageComboBoxEditAgency.EditValue.ToString();
            string cat = ImageComboBoxEditCategory.EditValue.ToString();
			string time = timeTextEdit.Text;
			decimal busTourStops = spinEditRouteStops.Value;
			decimal busTourDays = spinEditRouteDays.Value;
			int id = (int)GridViewCprates.GetFocusedRowCellValue("ID");
            bool inactive = (bool)inactiveCheckEdit.EditValue;
			if (!inactive) {
				//The sql I want to determine date overlaps:
				//start between c.START_DATE and c.END_DATE OR end between c.START_DATE and c.END_DATE OR
				//c.START_DATE between start and end OR c.END_DATE between start and end
				var load = from c in context.CPRATES
						   where c.CODE == code && c.ID != id && c.AGENCY == agency && c.CAT == cat && c.Inactive == false
							&& c.Time == time && (c.BusTourDays ?? 0) == busTourDays && (c.BusTourStops ?? 0) == busTourStops
							   && ((start >= c.START_DATE && start <= c.END_DATE) || (end >= c.START_DATE && end <= c.END_DATE)
							   || (c.START_DATE >= start && c.START_DATE <= end) || (c.END_DATE >= start && c.END_DATE <= end))
						   select c;
				if (load.Count() == 0)
					MessageBox.Show("No overlapping rate sheets exist.");
				else {
					var overlaps = new List<CPRATES>();
					foreach (var val in load) {
						DateTime? value1 = (DateTime?)GridViewCprates.GetFocusedRowCellValue("ResDate_Start");
						DateTime? value2 = (DateTime?)GridViewCprates.GetFocusedRowCellValue("ResDate_End");
						if ((val.ResDate_Start.HasValue && val.ResDate_End.HasValue && value1.HasValue && value2.HasValue) 
                            || (!val.ResDate_Start.HasValue && !val.ResDate_End.HasValue && !value1.HasValue && !value2.HasValue)) {
							overlaps.Add(val);
						}
					}
					if (overlaps.Count() > 0) {
						gridControl2.DataSource = overlaps;
						popupContainerControl1.Top = cODELabel.Top;
						popupContainerControl1.Left = cODELabel.Left;
						popupContainerControl1.BringToFront();
						popupContainerControl1.Show();
					}
					else {
						MessageBox.Show("No overlapping rate sheets exist.");
					}
				}
			}
        }

        private void CpRatesForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewCprates.IsFilterRow(GridViewCprates.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewCprates.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewCprates.GetFocusedDisplayText()))
                value = GridViewCprates.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {

                string query = String.Format("it.CODE like '{0}%'", GridViewCprates.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                var special = context.CPRATES.Where(query);

                if (!string.IsNullOrWhiteSpace(GridViewCprates.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CAT")))
                {
                    query = String.Format("it.{0} like '{1}%'", "CAT", GridViewCprates.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CAT"));
                    special = special.Where(query);
                }
                if (!string.IsNullOrWhiteSpace(GridViewCprates.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "AGENCY")))
                {
                    query = String.Format("it.{0} like '{1}%'", "AGENCY", GridViewCprates.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "AGENCY"));
                    special = special.Where(query);
                }
                if (!string.IsNullOrWhiteSpace(GridViewCprates.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "START_DATE")))
                {
                    string validDate = GridViewCprates.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "START_DATE");
                    string values = validCheck.convertDate(validDate);
                    if (!string.IsNullOrWhiteSpace(values))
                    {
                        DateTime startDate = Convert.ToDateTime(values);
                        special = special.Where("it.START_DATE >= @date", new ObjectParameter("date", startDate));
                    }
                }
                if (!string.IsNullOrWhiteSpace(GridViewCprates.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "ResDate_Start")))
                {
                    string validDate = GridViewCprates.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "ResDate_Start");
                    string values = validCheck.convertDate(validDate);
                    if (!string.IsNullOrWhiteSpace(values))
                    {
                        DateTime startDate = Convert.ToDateTime(values);
                        special = special.Where("it.ResDate_Start >= @date", new ObjectParameter("date", startDate));
                    }
                }
                int count = special.Count();
                if (count > 0)
                {
                    CpRateBindingSource.DataSource = special.OrderBy(item => item.CAT).ThenBy(item => item.START_DATE);
                    GridViewCprates.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                    GridViewCprates.FocusedRowHandle = 0;
                    GridViewCprates.FocusedColumn.FieldName = colName;
                    GridViewCprates.ClearColumnsFilter();

                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewCprates.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void ImageComboBoxEditCode_Leave(object sender, System.EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkCODE, CpRateBindingSource);
				ValidateCode(true);
            }
        }

		private void ValidateCode(bool updateDescription)
		{
			if (ImageComboBoxEditCode.SelectedIndex > 0) {		//0 is the blank item, < 0 is no item
				ImageComboBoxItem item = (ImageComboBoxItem)ImageComboBoxEditCode.SelectedItem;
				string code = item.Value.ToString();
				var comp = context.COMP.Include("CompBusRoute").FirstOrDefault(c => c.CODE == code);
				bool isHop = (comp == null ? false : comp.CompBusRoute.Count() > 0);
				spinEditRouteDays.Enabled = isHop;
				spinEditRouteStops.Enabled = isHop;
				if (!isHop) {
					spinEditRouteDays.Value = 0;
					spinEditRouteStops.Value = 0;
				}
				//if (string.IsNullOrEmpty(dESCTextEdit.Text))
				//	dESCTextEdit.Text = item.Description;
			}
		}

        private void ImageComboBoxEditAgency_Leave(object sender, System.EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkAgency, CpRateBindingSource);
            }
        }

        private void ImageComboBoxEditCategory_Leave(object sender, System.EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkCAT, CpRateBindingSource);
            }
        }

        private void CpRateBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                enableNavigator(true);
                //context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CPRATES)CpRateBindingSource.Current);               
           
            }
            else
                enableNavigator(false);
        }

        private void expandContractGridButton_Click(object sender, EventArgs e)
        {
            if (expandContractGridButton.Tag.ToString() == "right")
            {
                expandContractGridButton.Image = TraceForms.Properties.Resources.arrow_left;
                expandContractGridButton.Tag = "left";
                GridViewCprates.Columns["END_DATE"].Visible = true;
                GridViewCprates.Columns["END_DATE"].VisibleIndex = 4;
                GridViewCprates.Columns["ResDate_Start"].Visible = true;
                GridViewCprates.Columns["ResDate_Start"].VisibleIndex = 5;
                GridViewCprates.Columns["ResDate_End"].Visible = true;
                GridViewCprates.Columns["ResDate_End"].VisibleIndex = 6;
                GridViewCprates.Columns["Inactive"].Visible = true;
                GridViewCprates.Columns["Inactive"].VisibleIndex = 7;
                GridViewCprates.Columns["AGENCY"].Visible = true;
                GridViewCprates.Columns["AGENCY"].VisibleIndex = 8;
                GridViewCprates.Columns["CODE"].Width = 65;
            }
            else
            {
                expandContractGridButton.Image = TraceForms.Properties.Resources.arrow_right;
                expandContractGridButton.Tag = "right";
                GridViewCprates.Columns["AGENCY"].Visible = false;
                GridViewCprates.Columns["ResDate_Start"].Visible = false;
                GridViewCprates.Columns["ResDate_End"].Visible = false;
                GridViewCprates.Columns["END_DATE"].Visible = false;
                GridViewCprates.Columns["Inactive"].Visible = false;
            }
        }

        private void GridViewCprates_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
        }


        private void unit_Rate_BoolCheckEdit_Click(object sender, EventArgs e)
        {
            Modified = true;
        }

       

        private bool checkKids()
        {
            if (!string.IsNullOrWhiteSpace(cHD_LIMITTextEdit.Text))
            {
                if (Convert.ToDouble(cHD_LIMITTextEdit.Text) == 0 && (cHD_GRATESpinEdit.Value > 0 || cHD_NRATESpinEdit.Value > 0))
                    return false;
            }

            if (!string.IsNullOrWhiteSpace(jR_LIMITTextEdit.Text))
            {

                if (Convert.ToDouble(jR_LIMITTextEdit.Text) == 0 && (jR_GRATESpinEdit.Value > 0 || jR_NRATESpinEdit.Value > 0))
                    return false;
            }
            return true;

        }

        private bool checkRatePpl()
        {
            if (pP1SpinEdit.Value == 0 && (nPP1SpinEdit.Value > 0 || gPP1SpinEdit.Value > 0))
                return false;
            if (pP2SpinEdit.Value == 0 && (nPP2SpinEdit.Value > 0 || gPP2SpinEdit.Value > 0))
                return false;
            if (pP3SpinEdit.Value == 0 && (nPP3SpinEdit.Value > 0 || gPP3SpinEdit.Value > 0))
                return false;
            if (pP4SpinEdit.Value == 0 && (nPP4SpinEdit.Value > 0 || gPP4SpinEdit.Value > 0))
                return false;
            if (pP5SpinEdit.Value == 0 && (nPP5SpinEdit.Value > 0 || gPP5SpinEdit.Value > 0))
                return false;
            if (pP6SpinEdit.Value == 0 && (nPP6SpinEdit.Value > 0 || gPP6SpinEdit.Value > 0))
                return false;
            if (pP7SpinEdit.Value == 0 && (nPP7SpinEdit.Value > 0 || gPP7SpinEdit.Value > 0))
                return false;
            if (pP8SpinEdit.Value == 0 && (nPP8SpinEdit.Value > 0 || gPP8SpinEdit.Value > 0))
                return false;
            if (pP9SpinEdit.Value == 0 && (nPP9SpinEdit.Value > 0 || gPP9SpinEdit.Value > 0))
                return false;
            if (pP10SpinEdit.Value == 0 && (nPP10SpinEdit.Value > 0 || gPP10SpinEdit.Value > 0))
                return false;

            return true;

        }

        private void cOMM_FLGCheckEdit_Click(object sender, EventArgs e)
        {
            Modified = true;
        }

		private void spinEditRouteStops_Leave(object sender, EventArgs e)
		{
			if (CpRateBindingSource.Current != null) {
				if (currentVal != ((Control)sender).Text) {
					Modified = true;
				}
			}
		}

		private void spinEditRouteDays_Leave(object sender, EventArgs e)
		{
			if (CpRateBindingSource.Current != null) {
				if (currentVal != ((Control)sender).Text) {
					Modified = true;
				}
				validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkDays, CpRateBindingSource);
			}
		}

		private void ImageComboBoxEditCode_SelectedIndexChanged(object sender, EventArgs e)
		{
			ValidateCode(false);
		}

		private void CpRatesForm_Load(object sender, EventArgs e)
		{

		}

		private void simpleButtonClosePopup_Click(object sender, EventArgs e)
		{
			popupContainerControl1.Hide();
		}

        private void spinEditRetailChild_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (spinEditRetailChild.Value < cHD_NRATESpinEdit.Value)
                {
                    DialogResult select = XtraMessageBox.Show("The retail rate is less than the cost. Is this correct?", "Child Retail Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        spinEditRetailChild.Focus();
                        return;
                    }
                }
            }
        }

        private void spinEditRetailJunior_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (spinEditRetailJunior.Value < jR_NRATESpinEdit.Value)
                {
                    DialogResult select = XtraMessageBox.Show("The retail rate is less than the cost. Is this correct?", "Junior Retail Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        spinEditRetailJunior.Focus();
                        return;
                    }
                }
            }
        }

        private void spinEditRetailSenior_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (spinEditRetailSenior.Value < spinEditCostSenior.Value)
                {
                    DialogResult select = XtraMessageBox.Show("The retail rate is less than the cost. Is this correct?", "Senior Retail Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        spinEditRetailSenior.Focus();
                        return;
                    }
                }
            }
        }

        private void spinEditGrossSenior_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (spinEditGrossSenior.Value < spinEditCostSenior.Value)
                {
                    DialogResult select = XtraMessageBox.Show("The gross is less than the cost. Is this correct?", "Senior Gross Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        spinEditGrossSenior.Focus();
                        return;
                    }
                }
            }
        }

        private void spinEditCostSenior_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
            }
        }

        private void spinEditSeniorAge_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (spinEditSeniorAge.Value > 0 && spinEditCostSenior.Value == 0 && spinEditGrossSenior.Value == 0)
                {
                    DialogResult select = XtraMessageBox.Show("You have entered a senior age limit with no corresponding rate. Is this correct?", "Senior Limit", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the values entered.");
                        spinEditSeniorAge.Focus();
                        return;
                    }
                }

                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkSeniorAge, CpRateBindingSource);
            }

        }

        private void spinEditRetail1_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (spinEditRetail1.Value < nPP1SpinEdit.Value)
                {
                    DialogResult select = XtraMessageBox.Show("The retail rate is less than the cost. Is this correct?", "Retail Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        spinEditRetail1.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkRetail1, CpRateBindingSource);
            }
        }

        private void spinEditRetail2_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (spinEditRetail2.Value < nPP2SpinEdit.Value)
                {
                    DialogResult select = XtraMessageBox.Show("The retail rate is less than the cost. Is this correct?", "Retail Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        spinEditRetail2.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkRetail2, CpRateBindingSource);
            }
        }

        private void spinEditRetail3_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (spinEditRetail3.Value < nPP3SpinEdit.Value)
                {
                    DialogResult select = XtraMessageBox.Show("The retail rate is less than the cost. Is this correct?", "Retail Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        spinEditRetail3.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkRetail3, CpRateBindingSource);
            }
        }

        private void spinEditRetail4_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (spinEditRetail4.Value < nPP4SpinEdit.Value)
                {
                    DialogResult select = XtraMessageBox.Show("The retail rate is less than the cost. Is this correct?", "Retail Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        spinEditRetail4.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkRetail4, CpRateBindingSource);
            }
        }

        private void spinEditRetail5_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (spinEditRetail5.Value < nPP5SpinEdit.Value)
                {
                    DialogResult select = XtraMessageBox.Show("The retail rate is less than the cost. Is this correct?", "Retail Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        spinEditRetail5.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkRetail5, CpRateBindingSource);
            }
        }

        private void spinEditRetail6_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (spinEditRetail6.Value < nPP6SpinEdit.Value)
                {
                    DialogResult select = XtraMessageBox.Show("The retail rate is less than the cost. Is this correct?", "Retail Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        spinEditRetail6.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkRetail6, CpRateBindingSource);
            }
        }

        private void spinEditRetail7_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (spinEditRetail7.Value < nPP7SpinEdit.Value)
                {
                    DialogResult select = XtraMessageBox.Show("The retail rate is less than the cost. Is this correct?", "Retail Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        spinEditRetail7.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkRetail7, CpRateBindingSource);
            }
        }

        private void spinEditRetail8_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (spinEditRetail8.Value < nPP8SpinEdit.Value)
                {
                    DialogResult select = XtraMessageBox.Show("The retail rate is less than the cost. Is this correct?", "Retail Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        spinEditRetail8.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkRetail8, CpRateBindingSource);
            }
        }

        private void spinEditRetail9_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (spinEditRetail9.Value < nPP9SpinEdit.Value)
                {
                    DialogResult select = XtraMessageBox.Show("The retail rate is less than the cost. Is this correct?", "Retail Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        spinEditRetail9.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkRetail9, CpRateBindingSource);
            }
        }

        private void spinEditRetail10_Leave(object sender, EventArgs e)
        {
            if (CpRateBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                if (spinEditRetail10.Value < nPP10SpinEdit.Value)
                {
                    DialogResult select = XtraMessageBox.Show("The retail rate is less than the cost. Is this correct?", "Retail Rate", MessageBoxButtons.YesNo);
                    if (select == DialogResult.No)
                    {
                        XtraMessageBox.Show("Please correct the value entered to be greater than the cost.");
                        spinEditRetail10.Focus();
                        return;
                    }
                }
                validCheck.check(sender, errorProvider1, ((CPRATES)CpRateBindingSource.Current).checkRetail10, CpRateBindingSource);
            }
        }

        private void cOMM_FLGCheckEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (cOMM_FLGCheckEdit.Checked)
                cOMM_PCTSpinEdit.Enabled = true;
            else
                cOMM_PCTSpinEdit.Enabled = false;
        }

        private void ImageComboBoxEditAgency_EditValueChanged(object sender, EventArgs e)
        {
            string agency = ImageComboBoxEditAgency.EditValue.ToString();
            if (agency == _sys.Settings.DefaultAgency)
            {
                cOMM_FLGCheckEdit.Enabled = true;
            }
            else
            {
                cOMM_PCTSpinEdit.Enabled = false;
                cOMM_PCTSpinEdit.Value = 0;
                cOMM_FLGCheckEdit.Enabled = false;
                cOMM_FLGCheckEdit.EditValue = "N";      //the db field is char(1) Y/N
            }
        }
    }
}