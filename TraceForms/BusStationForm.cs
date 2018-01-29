using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraEditors;
using FlexModel;
using DevExpress.XtraEditors.Controls;
using System.Runtime.InteropServices;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraEditors.Repository;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraGrid;


namespace TraceForms
{
     
    public partial class BusStationForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        const string colName1 = "colCode";
        public  FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public BusStationForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
            LoadLookups();
            //BusStationBindingSource.DataSource = context.BusStation;
           
           
           
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);

        }

        private void  setReadOnly(bool value)
        {
            codeTextBox.Properties.ReadOnly = value;
            GridViewBusStation.Columns.ColumnByName(colName1).OptionsColumn.AllowEdit = !value;

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
            GridViewBusStation.SetFocusedRowCellValue("Code", string.Empty);
            GridViewBusStation.SetFocusedRowCellValue("Name", string.Empty);
            GridViewBusStation.SetFocusedRowCellValue("Address1", string.Empty);
            GridViewBusStation.SetFocusedRowCellValue("Address2", string.Empty);
            GridViewBusStation.SetFocusedRowCellValue("Address3", string.Empty);
            GridViewBusStation.SetFocusedRowCellValue("City", string.Empty);
            GridViewBusStation.SetFocusedRowCellValue("Town", string.Empty);
            GridViewBusStation.SetFocusedRowCellValue("State", string.Empty);
            GridViewBusStation.SetFocusedRowCellValue("Zip", string.Empty);
            GridViewBusStation.SetFocusedRowCellValue("Country", string.Empty);
            GridViewBusStation.SetFocusedRowCellValue("Latitude", 0);
            GridViewBusStation.SetFocusedRowCellValue("Longitude", 0);
            GridViewBusStation.SetFocusedRowCellValue("GeoCode_ID", 0);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            GridViewBusStation.ClearColumnsFilter();
            if (BusStationBindingSource.Current == null)
            {
                //fake query in order to create a link between the database table and the binding source
                BusStationBindingSource.DataSource = from opt in context.BusStation where opt.Code == "KJM9" select opt;
                BusStationBindingSource.AddNew();
                if (GridViewBusStation.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewBusStation.FocusedRowHandle = GridViewBusStation.RowCount - 1;
                setValues();
                codeTextBox.Focus();
                setReadOnly(false);
                newRec = true;
                return;
            }
            codeTextBox.Focus();
           // bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewBusStation.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( BusStation)BusStationBindingSource.Current);
                BusStationBindingSource.AddNew();
                if (GridViewBusStation.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewBusStation.FocusedRowHandle = GridViewBusStation.RowCount - 1;
                setValues();
                codeTextBox.Focus();
                setReadOnly(false);
                newRec = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (BusStationBindingSource.Current == null)
                return;
            GridViewBusStation.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {               
                modified = false;
                newRec = false;
                BusStationBindingSource.RemoveCurrent();
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
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((BusStation)BusStationBindingSource.Current).checkAll, BusStationBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, BusStationBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, BusStationBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }

        private void busStationBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (BusStationBindingSource.Current == null)
                return;
            GridViewBusStation.CloseEditor();
            codeTextBox.Focus();
           // bindingNavigatorPositionItem.Focus();//trigger field leave event
            bool temp = newRec;
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
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (BusStation)BusStationBindingSource.Current);
            
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool move()
        {
            GridViewBusStation.CloseEditor();
            codeTextBox.Focus();
            ///bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( BusStation)BusStationBindingSource.Current);
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
                BusStationBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                BusStationBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                BusStationBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            
            if (move())
                BusStationBindingSource.MoveLast();
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if(BusStationBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (BusStation)BusStationBindingSource.Current);


                setReadOnly(true);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (BusStation)BusStationBindingSource.Current);
         
                e.Allow = false;

            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewBusStation.IsFilterRow(e.RowHandle))
                modified = true;
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }

       
        private void BusStationForm_FormClosing(object sender, FormClosingEventArgs e)
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
            currentVal = ((Control)sender).Text.ToString();
        }

        private void codeTextBox_Leave(object sender, EventArgs e)
        {
            if (BusStationBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;

                validCheck.check(sender, errorProvider1, ((BusStation)BusStationBindingSource.Current).checkCode, BusStationBindingSource);
            }
        }

        private void nameTextBox_Leave(object sender, EventArgs e)
        {
            if (BusStationBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;

                validCheck.check(sender, errorProvider1, ((BusStation)BusStationBindingSource.Current).checkName, BusStationBindingSource);
            }
        }

        private void address1TextBox_Leave(object sender, EventArgs e)
        {
            if (BusStationBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;

                validCheck.check(sender, errorProvider1, ((BusStation)BusStationBindingSource.Current).checkAddress1, BusStationBindingSource);
            }
        }

        private void address2TextBox_Leave(object sender, EventArgs e)
        {
            if (BusStationBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;

                validCheck.check(sender, errorProvider1, ((BusStation)BusStationBindingSource.Current).checkAddress2, BusStationBindingSource);
            }
        }

        private void address3TextBox_Leave(object sender, EventArgs e)
        {
            if (BusStationBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;

                validCheck.check(sender, errorProvider1, ((BusStation)BusStationBindingSource.Current).checkAddress3, BusStationBindingSource);
            }
        }

        private void townTextEdit_Leave(object sender, EventArgs e)
        {
            if (BusStationBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;

                validCheck.check(sender, errorProvider1, ((BusStation)BusStationBindingSource.Current).checkTown, BusStationBindingSource);
            }
        }

        private void zipTextEdit_Leave(object sender, EventArgs e)
        {
            if (BusStationBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;

                validCheck.check(sender, errorProvider1, ((BusStation)BusStationBindingSource.Current).checkZip, BusStationBindingSource);
            }
        }

        private void latitudeTextBox_Leave(object sender, EventArgs e)
        {
            if (BusStationBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;

                validCheck.check(sender, errorProvider1, ((BusStation)BusStationBindingSource.Current).checkLatitude, BusStationBindingSource);
            }
        }

        private void longitudeTextBox_Leave(object sender, EventArgs e)
        {
            if (BusStationBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;

                validCheck.check(sender, errorProvider1, ((BusStation)BusStationBindingSource.Current).checkLongitude, BusStationBindingSource);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string state = ImageComboBoxEditState.EditValue.ToString();
            string count = ImageComboBoxEditCountry.EditValue.ToString();
            Uri mapUri = new Uri(new Uri("http://www.bing.com/"), "maps/default.aspx?where1=" + address1TextBox.Text + "%20" + address2TextBox.Text + "%20" + address3TextBox.Text + ",%20" + townTextEdit.Text + ",%20" + state + ",%20" + count + "&v=2");
            Form map = new TraceForms.WebBrowser(mapUri) { MdiParent = this.ParentForm };
            map.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Uri mapUri = new Uri(new Uri("http://www.bing.com/"), "maps/default.aspx?where1=" + latitudeTextBox.Text + ",%20" + longitudeTextBox.Text + "&v=2");
            Form map = new TraceForms.WebBrowser(mapUri) { MdiParent = this.ParentForm };
            map.Show();
        }

        private void BusStationForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewBusStation.IsFilterRow(GridViewBusStation.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewBusStation.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewBusStation.GetFocusedDisplayText()))
                value = GridViewBusStation.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.Name like '{0}%'", GridViewBusStation.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Name"));
                var special = context.BusStation.Where(query);
               
                if (!string.IsNullOrWhiteSpace(GridViewBusStation.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Code")))
                {
                    query = String.Format("it.{0} like '{1}%'", "Code", GridViewBusStation.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Code"));
                    special = special.Where(query);
                }
            
                int count = special.Count();
                if (count > 0)
                {
                    BusStationBindingSource.DataSource = special;
                    GridViewBusStation.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewBusStation.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void ImageComboBoxEditCity_Leave(object sender, System.EventArgs e)
        {
            if (BusStationBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
          
                validCheck.check(sender, errorProvider1, ((BusStation)BusStationBindingSource.Current).checkCity, BusStationBindingSource);

            }
        }

        private void ImageComboBoxEditState_Leave(object sender, System.EventArgs e)
        {
            if (BusStationBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
              
                validCheck.check(sender, errorProvider1, ((BusStation)BusStationBindingSource.Current).checkState, BusStationBindingSource);

            }
        }

        private void ImageComboBoxEditCountry_Leave(object sender, System.EventArgs e)
        {
            if (BusStationBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                    modified = true;
        
                validCheck.check(sender, errorProvider1, ((BusStation)BusStationBindingSource.Current).checkCountry, BusStationBindingSource);
            }
        }

        private void BusStationBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (BusStationBindingSource.Current != null)
                enableNavigator(true);
            else
                enableNavigator(false);
        }


      
      

    }
}