using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;
using FlexModel;
using DevExpress.XtraEditors.Controls;
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
    
    public partial class WaypointForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        const string colName = "colCODE";
        public FlextourEntities context;
        public WaypointForm(FlexInterfaces.Core.ICoreSys sys)
        {
        
            InitializeComponent();
            Connect(sys);
            LoadLookups();
        }
        private void setReadOnly(bool value)
        {
            codeTextBox.Properties.ReadOnly = value;
            GridViewWay.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = !value;
        }
        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);

        }

        private void LoadLookups()
        {
            setReadOnly(true);
            var state = from stateRec in context.State orderby stateRec.Code ascending select new { stateRec.Code, stateRec.State1 };
            var count = from countryRec in context.COUNTRY orderby countryRec.CODE ascending select new { countryRec.CODE, countryRec.NAME };
            var cty = from ctyRec in context.CITYCOD orderby ctyRec.CODE ascending select new { ctyRec.CODE, ctyRec.NAME };
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxEditState.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCountry.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCity.Properties.Items.Add(loadBlank);
            foreach (var result in state)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.Code.TrimEnd() + "  " + "(" + result.State1.TrimEnd() + ")", Value = result.Code.TrimEnd() };
                ImageComboBoxEditState.Properties.Items.Add(load);
            }
            foreach (var result in count)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCountry.Properties.Items.Add(load);

            }
            foreach (var result in cty)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCity.Properties.Items.Add(load);
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

        private void setValues()
        {
			GridViewWay.SetFocusedRowCellValue("Type", "WAY");
			GridViewWay.SetFocusedRowCellValue("CODE", string.Empty);
            GridViewWay.SetFocusedRowCellValue("NAME", string.Empty);
            GridViewWay.SetFocusedRowCellValue("ADDRESS1", string.Empty);
            GridViewWay.SetFocusedRowCellValue("ADDRESS2", string.Empty);
            GridViewWay.SetFocusedRowCellValue("ADDRESS3", string.Empty);
            GridViewWay.SetFocusedRowCellValue("CITY", string.Empty);
            GridViewWay.SetFocusedRowCellValue("Town", string.Empty);
            GridViewWay.SetFocusedRowCellValue("STATE", string.Empty);
            GridViewWay.SetFocusedRowCellValue("ZIP", string.Empty);
            GridViewWay.SetFocusedRowCellValue("COUNTRY", string.Empty);
            GridViewWay.SetFocusedRowCellValue("LATITUDE", 0);
            GridViewWay.SetFocusedRowCellValue("LONGITUDE", 0);
            GridViewWay.SetFocusedRowCellValue("GeoCode_ID", 0);
		}
       

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            GridViewWay.ClearColumnsFilter();
            if (WayPointBindingSource.Current == null)
            {
                WayPointBindingSource.DataSource = from opt in context.WAYPOINT where opt.CODE == "KJM9" select opt;
                WayPointBindingSource.AddNew();
                if (GridViewWay.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewWay.FocusedRowHandle = GridViewWay.RowCount - 1;
                codeTextBox.Focus();
                setValues();
                setReadOnly(false);
                newRec = true;
                return;
            }
            codeTextBox.Focus();
           // bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewWay.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (WAYPOINT)WayPointBindingSource.Current);
                WayPointBindingSource.AddNew();
                if (GridViewWay.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewWay.FocusedRowHandle = GridViewWay.RowCount - 1;
                codeTextBox.Focus();
                setValues();
                setReadOnly(false);
                newRec = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (WayPointBindingSource.Current == null)
                return;
            GridViewWay.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                
                modified = false;
                newRec = false;
                WayPointBindingSource.RemoveCurrent();
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
            currentVal = codeTextBox.Text;
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
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((WAYPOINT)WayPointBindingSource.Current).checkAll, WayPointBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, WayPointBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, WayPointBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }

        private void wAYPOINTBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {    

            if (WayPointBindingSource.Current == null)
                return;
            codeTextBox.Focus();
            GridViewWay.CloseEditor();
            bool temp = newRec;
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            if (checkForms())
            {
                codeTextBox.Focus();
                setReadOnly(true);
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
            }

            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (WAYPOINT)WayPointBindingSource.Current);
               

        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool move()
        {
            GridViewWay.CloseEditor();
            codeTextBox.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (WAYPOINT)WayPointBindingSource.Current);
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
                WayPointBindingSource.MoveFirst();
            
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                WayPointBindingSource.MovePrevious();
            
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                WayPointBindingSource.MoveNext();
            
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                WayPointBindingSource.MoveLast();
            
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (WayPointBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (WAYPOINT)WayPointBindingSource.Current);

                setReadOnly(true);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (WAYPOINT)WayPointBindingSource.Current);
               

                e.Allow = false;
            }
        }
   
        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text.ToString();
        }

        private void codeTextBox_Leave(object sender, EventArgs e)
        {
            if (WayPointBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((WAYPOINT)WayPointBindingSource.Current).checkCode, WayPointBindingSource);
            }
          
        }

        private void descTextBox_Leave(object sender, EventArgs e)
        {
            if (WayPointBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((WAYPOINT)WayPointBindingSource.Current).checkDesc, WayPointBindingSource);
            }
        }

    

        private void WAYPOINTForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewWay.IsFilterRow(e.RowHandle))
                modified = true;
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            temp = newRec;
            if (!temp && checkForms())
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (WAYPOINT)WayPointBindingSource.Current);

            setReadOnly(true);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string state = ImageComboBoxEditState.EditValue.ToString();
            string country = ImageComboBoxEditCountry.EditValue.ToString();
            Uri mapUri = new Uri(new Uri("http://www.bing.com/"), "maps/default.aspx?where1=" + this.address1.Text + "%20" + this.address2.Text + "%20" + this.address3.Text + ",%20" + this.city.Text + ",%20" + state + ",%20" + country + "&v=2");
            Form map = new TraceForms.WebBrowser(mapUri) { MdiParent = this.ParentForm };
            map.Show();
        }

        private void Map_Click(object sender, EventArgs e)
        {
            Uri mapUri = new Uri(new Uri("http://www.bing.com/"), "maps/default.aspx?where1=" + this.latitude.Text + ",%20" + this.longitude.Text + "&v=2");
            Form map = new TraceForms.WebBrowser(mapUri) { MdiParent = this.ParentForm };
            map.Show();
        }

        private void state_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text.ToString())
                modified = true;
            validCheck.check(sender, errorProvider1, ((WAYPOINT)WayPointBindingSource.Current).checkState, WayPointBindingSource);
        }
 
        private void cityCode_Leave(object sender, EventArgs e)
        {
            if (WayPointBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((WAYPOINT)WayPointBindingSource.Current).checkCity, WayPointBindingSource);
            }
        }

        private void address1_Leave(object sender, EventArgs e)
        {
            if (WayPointBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((WAYPOINT)WayPointBindingSource.Current).checkAddress1, WayPointBindingSource);
            }
        }

        private void address2_Leave(object sender, EventArgs e)
        {
            if (WayPointBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((WAYPOINT)WayPointBindingSource.Current).checkAddress2, WayPointBindingSource);
            }
        }

        private void address3_Leave(object sender, EventArgs e)
        {
            if (WayPointBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((WAYPOINT)WayPointBindingSource.Current).checkAddress3, WayPointBindingSource);
            }
        }

        private void city_Leave(object sender, EventArgs e)
        {
            if (WayPointBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((WAYPOINT)WayPointBindingSource.Current).checkTown, WayPointBindingSource);
            }
        }

        private void zip_Leave(object sender, EventArgs e)
        {
            if (WayPointBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((WAYPOINT)WayPointBindingSource.Current).checkZip, WayPointBindingSource);
            }
        }

        private void latitude_Leave(object sender, EventArgs e)
        {
            if (WayPointBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((WAYPOINT)WayPointBindingSource.Current).checkLatitude, WayPointBindingSource);
            }
        }

        private void longitude_Leave(object sender, EventArgs e)
        {
            if (WayPointBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
                validCheck.check(sender, errorProvider1, ((WAYPOINT)WayPointBindingSource.Current).checkLongitude, WayPointBindingSource);
            }
        }      

        private void WaypointForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewWay.IsFilterRow(GridViewWay.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewWay.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewWay.GetFocusedDisplayText()))
                value = GridViewWay.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.CODE like '{0}%'", GridViewWay.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                var special = context.WAYPOINT.Where(query);

                if (!string.IsNullOrWhiteSpace(GridViewWay.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "DESC")))
                {
                    query = String.Format("it.{0} like '{1}%'", "[DESC]", GridViewWay.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "DESC"));
                    special = special.Where(query);
                }

                int count = special.Count();
                if (count > 0)
                {
                    WayPointBindingSource.DataSource = special;
                    GridViewWay.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                    GridViewWay.FocusedRowHandle = 0;
                    GridViewWay.FocusedColumn.FieldName = colName;
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewWay.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void ImageComboBoxEditState_Leave(object sender, System.EventArgs e)
        {
            if (WayPointBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;

                validCheck.check(sender, errorProvider1, ((WAYPOINT)WayPointBindingSource.Current).checkState, WayPointBindingSource);
            }
        }

        private void ImageComboBoxEditCountry_Leave(object sender, System.EventArgs e)
        {
            if (WayPointBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;

                validCheck.check(sender, errorProvider1, ((WAYPOINT)WayPointBindingSource.Current).checkCountry, WayPointBindingSource);
            }
        }

        private void ImageComboBoxEditCity_Leave(object sender, System.EventArgs e)
        {
            if (WayPointBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;

                validCheck.check(sender, errorProvider1, ((WAYPOINT)WayPointBindingSource.Current).checkCity, WayPointBindingSource);
            }
        }

        private void WayPointBindingSource_CurrentChanged(object sender, System.EventArgs e)
        {

            if (WayPointBindingSource.Current != null)
                enableNavigator(true);
            else
                enableNavigator(false);
        }

		private void checkEditProximitySearch_Leave(object sender, System.EventArgs e)
		{
			if (WayPointBindingSource.Current != null) {
				if (currentVal != ((Control)sender).Text.ToString())
					modified = true;
			}
		}

		private void spinEditDistance_Leave(object sender, System.EventArgs e)
		{
			if (WayPointBindingSource.Current != null) {
				if (currentVal != ((Control)sender).Text.ToString())
					modified = true;
				validCheck.check(sender, errorProvider1, ((WAYPOINT)WayPointBindingSource.Current).checkDistance, WayPointBindingSource);
			}
		}

		private void checkEditProximitySearch_CheckedChanged(object sender, System.EventArgs e)
		{
			spinEditDistance.Enabled = (checkEditProximitySearch.Checked);
			if (!checkEditProximitySearch.Checked)
				spinEditDistance.Value = 0;
		}

		private void checkEditProximitySearch_Click(object sender, System.EventArgs e)
		{
			modified = true;
		}

		private void durationTimeEdit_Leave(object sender, EventArgs e)
		{
			if (WayPointBindingSource.Current != null) {
				if (currentVal != ((Control)sender).Text) {
					modified = true;
				}
			}
		}

        private void checkEditSearchable_Click(object sender, EventArgs e)
        {
            modified = true;
        }

        private void checkEditSearchable_Leave(object sender, EventArgs e)
        {
            if (WayPointBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                }
            }
        }
    }
}