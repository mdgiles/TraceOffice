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
    
    public partial class TrainStationForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        const string colName1 = "colCode";
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public  FlextourEntities context;
        public TrainStationForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
            LoadLookups();                       
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);

        }
        private void setReadOnly(bool value)
        {
            TextEditCode.Properties.ReadOnly = value;
            GridViewTrain.Columns.ColumnByName(colName1).OptionsColumn.AllowEdit = !value;
           
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
            GridViewTrain.SetFocusedRowCellValue("Code", string.Empty);
            GridViewTrain.SetFocusedRowCellValue("Name", string.Empty);
            GridViewTrain.SetFocusedRowCellValue("Address1", string.Empty);
            GridViewTrain.SetFocusedRowCellValue("Address2", string.Empty);
            GridViewTrain.SetFocusedRowCellValue("Address3", string.Empty);
            GridViewTrain.SetFocusedRowCellValue("City", string.Empty);
            GridViewTrain.SetFocusedRowCellValue("Town", string.Empty);
            GridViewTrain.SetFocusedRowCellValue("State", string.Empty);
            GridViewTrain.SetFocusedRowCellValue("Zip", string.Empty);
            GridViewTrain.SetFocusedRowCellValue("Country", string.Empty);
            GridViewTrain.SetFocusedRowCellValue("Latitude", 0);
            GridViewTrain.SetFocusedRowCellValue("Longitude", 0);
            GridViewTrain.SetFocusedRowCellValue("GeoCode_ID", 0);
        }
       
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            GridViewTrain.ClearColumnsFilter();
            if (TrainStationBindingSource.Current == null)
            {
                TrainStationBindingSource.DataSource = from opt in context.TrainStation where opt.Code == "KJM9" select opt;
                TrainStationBindingSource.AddNew();
                if (GridViewTrain.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewTrain.FocusedRowHandle = GridViewTrain.RowCount - 1;
                TextEditCode.Focus();
                setReadOnly(false);
                setValues();
                newRec = true;
                return;
            }
            TextEditCode.Focus();
            //bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewTrain.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (TrainStation)TrainStationBindingSource.Current);
                TrainStationBindingSource.AddNew();
                if (GridViewTrain.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewTrain.FocusedRowHandle = GridViewTrain.RowCount - 1;
                TextEditCode.Focus();
                setReadOnly(false);
                setValues();
                newRec = true;
            }
        }
   
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (TrainStationBindingSource.Current == null)
                return;

            GridViewTrain.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {               
                modified = false;
                newRec = false;
                TrainStationBindingSource.RemoveCurrent();
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
            currentVal = TextEditCode.Text;
        }

        private bool checkForms()
        {
            if (!modified && !newRec)
                return true;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((TrainStation)TrainStationBindingSource.Current).checkAll, TrainStationBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, TrainStationBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, TrainStationBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }


        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }

        private void trainStationBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            if (TrainStationBindingSource.Current == null)
                return;

            GridViewTrain.CloseEditor();
            TextEditCode.Focus();
            bool temp = newRec;
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            if (checkForms())
            {
                TextEditCode.Focus();
                setReadOnly(true);
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;


            }

            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (TrainStation)TrainStationBindingSource.Current);
                
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }
       
        private bool move()
        {
            GridViewTrain.CloseEditor();
            TextEditCode.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (TrainStation)TrainStationBindingSource.Current);
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
                TrainStationBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                TrainStationBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                TrainStationBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                TrainStationBindingSource.MoveLast();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string state = ImageComboBoxEditState.EditValue.ToString();
            string country = ImageComboBoxEditCountry.EditValue.ToString();
            Uri mapUri = new Uri(new Uri("http://www.bing.com/"), "maps/default.aspx?where1=" + this.address1TextEdit1.Text + "%20" + this.address2TextEdit1.Text + "%20" + this.address3TextEdit1.Text + ",%20" + this.townTextEdit1.Text + ",%20" + state + ",%20" + country + "&v=2");
            Form map = new TraceForms.WebBrowser(mapUri) { MdiParent = this.ParentForm };
            map.Show();
        }

        private void Map_Click(object sender, EventArgs e)
        {            
            Uri mapUri = new Uri(new Uri("http://www.bing.com/"), "maps/default.aspx?where1=" + this.latitudeTextEdit1.Text + ",%20" + this.longitudeTextEdit1.Text + "&v=2");
            Form map = new TraceForms.WebBrowser(mapUri) { MdiParent = this.ParentForm };
            map.Show();
        }

   

        void ButtonEdit_QueryPopUp1(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
        }

        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (TrainStationBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (TrainStationForm)TrainStationBindingSource.Current);

                setReadOnly(true);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (TrainStation)TrainStationBindingSource.Current);
          
                e.Allow = false;
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewTrain.IsFilterRow(e.RowHandle))
                modified = true;
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }

        private void TrainStationForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            //temp = newRec;
            //if (!temp && checkForms())
            //    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (TrainStation)TrainStationBindingSource.Current);

            //setReadOnly(true);
        }

     

        private void codeTextEdit_Leave(object sender, EventArgs e)
        {
            if (TrainStationBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((TrainStation)TrainStationBindingSource.Current).checkCode, TrainStationBindingSource);
            }
        }

        private void nameTextEdit_Leave(object sender, EventArgs e)
        {
            if (TrainStationBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((TrainStation)TrainStationBindingSource.Current).checkName, TrainStationBindingSource);
            }
        }

        private void address1TextEdit1_Leave(object sender, EventArgs e)
        {
            if (TrainStationBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((TrainStation)TrainStationBindingSource.Current).checkAddress1, TrainStationBindingSource);
            }
        }

        private void address2TextEdit1_Leave(object sender, EventArgs e)
        {
            if (TrainStationBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((TrainStation)TrainStationBindingSource.Current).checkAddress2, TrainStationBindingSource);
            }
        }

        private void address3TextEdit1_Leave(object sender, EventArgs e)
        {
            if (TrainStationBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((TrainStation)TrainStationBindingSource.Current).checkAddress3, TrainStationBindingSource);
            }
        }

        private void townTextEdit1_Leave(object sender, EventArgs e)
        {
            if (TrainStationBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((TrainStation)TrainStationBindingSource.Current).checkTown, TrainStationBindingSource);
            }
        }

        private void zipTextEdit_Leave(object sender, EventArgs e)
        {
            if (TrainStationBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((TrainStation)TrainStationBindingSource.Current).checkZip, TrainStationBindingSource);
            }
        }

        private void latitudeTextEdit1_Leave(object sender, EventArgs e)
        {
            if (TrainStationBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((TrainStation)TrainStationBindingSource.Current).checkLatitude, TrainStationBindingSource);
            }
        }

        private void longitudeTextEdit1_Leave(object sender, EventArgs e)
        {
            if (TrainStationBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((TrainStation)TrainStationBindingSource.Current).checkLongitude, TrainStationBindingSource);
            }
        }

     

        private void TrainStationForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewTrain.IsFilterRow(GridViewTrain.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewTrain.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewTrain.GetFocusedDisplayText()))
                value = GridViewTrain.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.Name like '{0}%'", GridViewTrain.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Name"));
                var special = context.TrainStation.Where(query);

                if (!string.IsNullOrWhiteSpace(GridViewTrain.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Code")))
                {
                    query = String.Format("it.{0} like '{1}%'", "Code", GridViewTrain.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Code"));
                    special = special.Where(query);
                }

                int count = special.Count();
                if (count > 0)
                {
                    TrainStationBindingSource.DataSource = special;
                    GridViewTrain.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                    GridViewTrain.FocusedRowHandle = 0;
                    GridViewTrain.FocusedColumn.FieldName = colName;
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewTrain.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void ImageComboBoxEditCountry_Leave(object sender, System.EventArgs e)
        {
            if (TrainStationBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((TrainStation)TrainStationBindingSource.Current).checkCountry, TrainStationBindingSource);
            }
        }

        private void ImageComboBoxEditCity_Leave(object sender, System.EventArgs e)
        {
            if (TrainStationBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((TrainStation)TrainStationBindingSource.Current).checkCity, TrainStationBindingSource);
            }
        }

        private void ImageComboBoxEditState_Leave(object sender, System.EventArgs e)
        {
            if (TrainStationBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((TrainStation)TrainStationBindingSource.Current).checkState, TrainStationBindingSource);
            }
        }

        private void TrainStationBindingSource_CurrentChanged(object sender, System.EventArgs e)
        {
            if (TrainStationBindingSource.Current != null)
                enableNavigator(true);
            else
                enableNavigator(false);
        }
       
    }
}