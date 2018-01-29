using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using FlexModel;
using DevExpress.XtraEditors.Controls;
using System.Linq;
using System.Runtime.InteropServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using FlexModel;
using DevExpress.XtraEditors.Controls;
using System.Linq;
using DevExpress.XtraGrid.Columns;
using System.Runtime.InteropServices;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraEditors.Repository;
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
     
    public partial class BusTableForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        public string username;
          public FlextourEntities context;
          public Timer rowStatusDelete;
          public Timer rowStatusSave;
          public ImageComboBoxItemCollection airports;
          public ImageComboBoxItemCollection busstations;
          public ImageComboBoxItemCollection seaports;
          public ImageComboBoxItemCollection trains;
          public ImageComboBoxItemCollection cars;
          public ImageComboBoxItemCollection cities;
          public ImageComboBoxItemCollection cruises;
          public ImageComboBoxItemCollection hotels;
          public ImageComboBoxItemCollection wayports;
          public ImageComboBoxItemCollection opts;
          public ImageComboBoxItemCollection pkgs;
          public BusTableForm(FlexInterfaces.Core.ICoreSys sys)
        {
              //might need to set some fields as read only depending on test results
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
              var airs = from airRec in context.Airport orderby airRec.Code ascending select new { airRec.Code, airRec.Name };
              var buses = from busRec in context.BusStation orderby busRec.Code ascending select new { busRec.Code, busRec.Name };
              var cty = from ctyRec in context.CITYCOD orderby ctyRec.CODE ascending select new { ctyRec.CODE, ctyRec.NAME };
              var seas = from seaRec in context.SeaPort orderby seaRec.Code ascending select new { seaRec.Code, seaRec.Name };
              var trns = from trnRec in context.TrainStation orderby trnRec.Code ascending select new { trnRec.Code, trnRec.Name };
              var crs = from carRec in context.CARINFO orderby carRec.CODE ascending select new { carRec.CODE, carRec.NAME };
              var htls = from htlRec in context.HOTEL orderby htlRec.CODE ascending select new { htlRec.CODE, htlRec.NAME };
              var ways = from wayRec in context.WAYPOINT orderby wayRec.CODE ascending select new { wayRec.CODE, wayRec.DESC };
              var crus = from cruRec in context.CRU orderby cruRec.CODE ascending select new { cruRec.CODE, cruRec.NAME };
              var comps = from compRec in context.COMP orderby compRec.CODE ascending select new { compRec.CODE, compRec.NAME };
              var packs = from packRec in context.PACK orderby packRec.CODE ascending select new { packRec.CODE, packRec.NAME };
              ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
              ImageComboBoxEditCode.Properties.Items.Add(loadBlank);
              ImageComboBoxEditLocation.Properties.Items.Add(loadBlank);

              foreach (var result in airs)
              {
                  ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.Code.TrimEnd() + "  " + "(" + result.Name.TrimEnd() + ")", Value = result.Code.TrimEnd() };
                  airports.Add(load);
              }
              foreach (var result in buses)
              {
                  ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.Code.TrimEnd() + "  " + "(" + result.Name.TrimEnd() + ")", Value = result.Code.TrimEnd() };
                  busstations.Add(load);

              }
              foreach (var result in cty)
              {
                  ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                  cities.Add(load);
              }
              foreach (var result in seas)
              {
                  ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.Code.TrimEnd() + "  " + "(" + result.Name.TrimEnd() + ")", Value = result.Code.TrimEnd() };
                  seaports.Add(load);
              }
              foreach (var result in trns)
              {
                  ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.Code.TrimEnd() + "  " + "(" + result.Name.TrimEnd() + ")", Value = result.Code.TrimEnd() };
                  trains.Add(load);
              }
              foreach (var result in crs)
              {
                  ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                  cars.Add(load);
              }
              foreach (var result in htls)
              {
                  ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                  hotels.Add(load);
              }
              foreach (var result in ways)
              {
                  ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.DESC.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                  wayports.Add(load);
              }
              foreach (var result in comps)
              {
                  ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                  opts.Add(load);
              }
              foreach (var result in packs)
              {
                  ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                  pkgs.Add(load);
              }
              foreach (var result in crus)
              {
                  ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                  cruises.Add(load);
              }
              enableNavigator(false);
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

        private bool move()
        {
            GridViewBusTable.CloseEditor();
            ImageComboBoxEditCode.Focus();
           // bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( BUSTABLE)BusTableBindingSource.Current);              
                newRec = false;
                modified = false;
                return true;
            }
            return false;
        }  

    

        private void BusTableForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void setValues()
        {
            GridViewBusTable.SetFocusedRowCellValue("TYPE", string.Empty);
            GridViewBusTable.SetFocusedRowCellValue("CODE", string.Empty);
            GridViewBusTable.SetFocusedRowCellValue("PUP_DRP", string.Empty);
            GridViewBusTable.SetFocusedRowCellValue("LOCATION", string.Empty);
            GridViewBusTable.SetFocusedRowCellValue("TIME", string.Empty);
            GridViewBusTable.SetFocusedRowCellValue("In_Out", string.Empty);
            GridViewBusTable.SetFocusedRowCellValue("LocationType", string.Empty);
            GridViewBusTable.SetFocusedRowCellValue("CarOffice", string.Empty);
            GridViewBusTable.SetFocusedRowCellValue("EndTime", string.Empty);
            GridViewBusTable.SetFocusedRowCellValue("Exclusion", string.Empty);        
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            GridViewBusTable.ClearColumnsFilter();
            if (BusTableBindingSource.Current == null)
            {
                //fake query in order to create a link between the database table and the binding source
                BusTableBindingSource.DataSource = from opt in context.BUSTABLE where opt.CODE == "KJM9" select opt;
                BusTableBindingSource.AddNew();
                if (GridViewBusTable.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewBusTable.FocusedRowHandle = GridViewBusTable.RowCount - 1;
                setValues();
                newRec = true;
                return;
            }
            ImageComboBoxEditCode.Focus();
           // bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewBusTable.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( BUSTABLE)BusTableBindingSource.Current);
                BusTableBindingSource.AddNew();
                if (GridViewBusTable.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewBusTable.FocusedRowHandle = GridViewBusTable.RowCount - 1;
                setValues();
                newRec = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {        
            if (BusTableBindingSource.Current == null)
                return;
            GridViewBusTable.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                modified = false;
                newRec = false;
                BusTableBindingSource.RemoveCurrent();
                errorProvider1.Clear();
                context.SaveChanges();
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);
            }

            currentVal = ImageComboBoxEditCode.EditValue.ToString();
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
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((BUSTABLE)BusTableBindingSource.Current).checkAll, BusTableBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, BusTableBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, BusTableBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }

        private void bUSTABLEBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (BusTableBindingSource.Current == null)
                return;

            GridViewBusTable.CloseEditor();
            ImageComboBoxEditCode.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            bool temp = newRec;
            if (checkForms())
            {
                tYPEComboBoxEdit.Focus();
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
            }

            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (BUSTABLE)BusTableBindingSource.Current);              
           
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (move())
                BusTableBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                BusTableBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                BusTableBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                BusTableBindingSource.MoveLast();
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {  
            if (BusTableBindingSource.Current == null)
            {
                e.Allow = true;
                return;
            }
            temp = newRec;
            bool temp2 = modified;

            if (checkForms())
            {
                e.Allow = true;
                if ((!temp) && temp2)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (BUSTABLE)BusTableBindingSource.Current);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (BUSTABLE)BusTableBindingSource.Current);  
                e.Allow = false;
              
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewBusTable.IsFilterRow(e.RowHandle))
                modified = true;
            labelControl1.Text = DateTime.Today.ToShortDateString();
            labelControl2.Text = username;
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; 
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {   
            temp = newRec;
            if (!temp && checkForms())
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( BUSTABLE)BusTableBindingSource.Current);           
        }
    
        
        private void tYPEComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (BusTableBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((BUSTABLE)BusTableBindingSource.Current).checkType, BusTableBindingSource);
            }
        }

        private void in_OutComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (BusTableBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((BUSTABLE)BusTableBindingSource.Current).checkInOut, BusTableBindingSource);
            }
        }

        private void pUP_DRPComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (BusTableBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((BUSTABLE)BusTableBindingSource.Current).checkPupDrp, BusTableBindingSource);
            }
        }

        private void dATEDateEdit_Leave(object sender, EventArgs e)
        {
            if (BusTableBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((BUSTABLE)BusTableBindingSource.Current).checkStart, BusTableBindingSource);
            }
        }

        private void endDateDateEdit_Leave(object sender, EventArgs e)
        {
            if (BusTableBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((BUSTABLE)BusTableBindingSource.Current).checkEnd, BusTableBindingSource);
            }
        }

        private void locationTypeComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (BusTableBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((BUSTABLE)BusTableBindingSource.Current).checkLocType, BusTableBindingSource);
            }
        }

        private void tIMETimeEdit_Leave(object sender, EventArgs e)
        {
            if (BusTableBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((BUSTABLE)BusTableBindingSource.Current).checkStTime, BusTableBindingSource);
            }
        }

        private void endTimeTimeEdit_Leave(object sender, EventArgs e)
        {
            if (BusTableBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((BUSTABLE)BusTableBindingSource.Current).checkEndTime, BusTableBindingSource);
            }
        }

        private void tYPEComboBoxEdit_TextChanged(object sender, EventArgs e)
        {
            ImageComboBoxEditCode.Properties.Items.Clear();
           

            if (tYPEComboBoxEdit.Text == "OPT")
            {
                // //options 
                ImageComboBoxEditCode.Properties.Items.AddRange(opts);
            }
            if (tYPEComboBoxEdit.Text == "PKG")
            {
                //// pack codes
                ImageComboBoxEditCode.Properties.Items.AddRange(pkgs);
            }
        }

        private void locationTypeComboBoxEdit_TextChanged(object sender, EventArgs e)
        {
            ImageComboBoxEditLocation.Properties.Items.Clear();
          
                if (locationTypeComboBoxEdit.Text == "AIR")
                {
                    //airport
                    ImageComboBoxEditLocation.Properties.Items.AddRange(airports);
                }
                if (locationTypeComboBoxEdit.Text == "BUS")
                {
                    // bus stations
                    ImageComboBoxEditLocation.Properties.Items.AddRange(busstations);
                }
                if (locationTypeComboBoxEdit.Text == "CRU")
                {
                    //sea ports
                    ImageComboBoxEditLocation.Properties.Items.AddRange(cruises);
                }

                if (locationTypeComboBoxEdit.Text == "TRN")
                {
                    // trn stations    
                    ImageComboBoxEditLocation.Properties.Items.AddRange(trains);
                }
            
        
                if (locationTypeComboBoxEdit.Text == "CAR")
                {
                    // cars
                    ImageComboBoxEditLocation.Properties.Items.AddRange(cars);
                }

                if (locationTypeComboBoxEdit.Text == "CTY")
                {
                    // city codes
                    ImageComboBoxEditLocation.Properties.Items.AddRange(cities);
                }

                if (locationTypeComboBoxEdit.Text == "HTL")
                {
                    // htl codes
                    ImageComboBoxEditLocation.Properties.Items.AddRange(hotels);
                }
            

            if (locationTypeComboBoxEdit.Text == "WAY")
            {               
                // way codes
                ImageComboBoxEditLocation.Properties.Items.AddRange(wayports);
            }            
        }
   

        private void dATEDateEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void dATEDateEdit_TextChanged(object sender, EventArgs e)
        {
            dATEDateEdit.Text = validCheck.convertDate(dATEDateEdit.Text);
        }

        private void endDateDateEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };  
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void endDateDateEdit_TextChanged(object sender, EventArgs e)
        {
            endDateDateEdit.Text = validCheck.convertDate(endDateDateEdit.Text);
        }

        private void BusTableForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewBusTable.IsFilterRow(GridViewBusTable.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewBusTable.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewBusTable.GetFocusedDisplayText()))
                value = GridViewBusTable.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.TYPE like '{0}%'", GridViewBusTable.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "TYPE"));
                var special = context.BUSTABLE.Where(query);
              
                if (!string.IsNullOrWhiteSpace(GridViewBusTable.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE")))
                {
                    query = String.Format("it.{0} like '{1}%'", "CODE", GridViewBusTable.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                    special = special.Where(query);
                }
               
                int count = special.Count();
                if (count > 0)
                {
                    BusTableBindingSource.DataSource = special;
                    GridViewBusTable.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewBusTable.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void ImageComboBoxEditCode_Leave(object sender, System.EventArgs e)
        {
            if (BusTableBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((BUSTABLE)BusTableBindingSource.Current).checkCode, BusTableBindingSource);
            }
        }

        private void ImageComboBoxEditLocation_Leave(object sender, System.EventArgs e)
        {
            if (BusTableBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToShortDateString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((BUSTABLE)BusTableBindingSource.Current).checkLocation, BusTableBindingSource);
            }
        }

        private void BusTableBindingSource_CurrentChanged(object sender, System.EventArgs e)
        {
            if (BusTableBindingSource.Current != null)
                enableNavigator(true);
            else
                enableNavigator(false);
        }
    }
}