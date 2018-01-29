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
    
    public partial class AirportForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        const string colName1 = "colCode";
        public FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public AirportForm(FlexInterfaces.Core.ICoreSys sys)
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
            codeTextEdit.Properties.ReadOnly = value;
            GridViewAirport.Columns.ColumnByName(colName1).OptionsColumn.AllowEdit = !value;
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
            GridViewAirport.SetFocusedRowCellValue("Code", string.Empty);
            GridViewAirport.SetFocusedRowCellValue("Name", string.Empty);
            GridViewAirport.SetFocusedRowCellValue("Address1", string.Empty);
            GridViewAirport.SetFocusedRowCellValue("Address2", string.Empty);
            GridViewAirport.SetFocusedRowCellValue("Address3", string.Empty);
            GridViewAirport.SetFocusedRowCellValue("City", string.Empty);
            GridViewAirport.SetFocusedRowCellValue("Town", string.Empty);
            GridViewAirport.SetFocusedRowCellValue("State", string.Empty);
            GridViewAirport.SetFocusedRowCellValue("Zip", string.Empty);
            GridViewAirport.SetFocusedRowCellValue("Country", string.Empty);
            GridViewAirport.SetFocusedRowCellValue("Latitude", 0);
            GridViewAirport.SetFocusedRowCellValue("Longitude", 0);
            GridViewAirport.SetFocusedRowCellValue("GeoCode_ID", 0);
        }
       

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            GridViewAirport.ClearColumnsFilter();
            codeTextEdit.Focus();
            if (AirportBindingSource.Current == null)
            {
                //fake query in order to create a link between the database table and the binding source
                AirportBindingSource.DataSource = from opt in context.Airport where opt.Code == "KJM9" select opt;
                AirportBindingSource.AddNew();
                if (GridViewAirport.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewAirport.FocusedRowHandle = GridViewAirport.RowCount - 1;
                
                codeTextEdit.Focus();
                setReadOnly(false);
                newRec = true;
                setValues();
                return;
            }
          
            GridViewAirport.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                       context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( Airport)AirportBindingSource.Current);

                AirportBindingSource.AddNew();
                if (GridViewAirport.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewAirport.FocusedRowHandle = GridViewAirport.RowCount - 1;
                setValues();
                codeTextEdit.Focus();
                setReadOnly(false);
                newRec = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (AirportBindingSource.Current == null)
                return;
            GridViewAirport.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                modified = false;
                newRec = false;
                AirportBindingSource.RemoveCurrent();
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
            currentVal = codeTextEdit.Text;
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
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((Airport)AirportBindingSource.Current).checkMain, AirportBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, AirportBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, AirportBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }


        private void airportBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
           
            if (AirportBindingSource.Current == null)
                return;
            codeTextEdit.Focus();
            GridViewAirport.CloseEditor();
          //  bindingNavigatorPositionItem.Focus();//trigger field leave event
            bool temp = newRec;
            if (checkForms())
            {
                codeTextEdit.Focus();
                setReadOnly(true);
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
            }

            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (Airport)AirportBindingSource.Current);

        }


        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool move()
        {
            
            GridViewAirport.CloseEditor();
            codeTextEdit.Focus();
           // bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( Airport)AirportBindingSource.Current);
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
                AirportBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                AirportBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                AirportBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                AirportBindingSource.MoveLast();
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {          

            if (AirportBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (Airport)AirportBindingSource.Current);

                setReadOnly(true);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (Airport)AirportBindingSource.Current);

                e.Allow = false;

            }
        }

   

        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewAirport.IsFilterRow(e.RowHandle))
                modified = true;
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            temp = newRec;
            if (checkForms())
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( Airport)AirportBindingSource.Current);

            setReadOnly(true);
        }

        private void AirportForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void codeTextEdit_Leave(object sender, EventArgs e)
        {
            if (AirportBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((Airport)AirportBindingSource.Current).checkCode, AirportBindingSource);
            }
        }         

        private void nameTextEdit_Leave(object sender, EventArgs e)
        {
            if (AirportBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((Airport)AirportBindingSource.Current).checkName, AirportBindingSource);
            }
        }

        private void address1TextEdit_Leave(object sender, EventArgs e)
        {
            if (AirportBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;

                validCheck.check(sender, errorProvider1, ((Airport)AirportBindingSource.Current).checkAddress1, AirportBindingSource);
            }
        }

        private void address2TextEdit_Leave(object sender, EventArgs e)
        {
            if (AirportBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;

                validCheck.check(sender, errorProvider1, ((Airport)AirportBindingSource.Current).checkAddress2, AirportBindingSource);
            }
        }

        private void address3TextEdit_Leave(object sender, EventArgs e)
        {
            if (AirportBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;

                validCheck.check(sender, errorProvider1, ((Airport)AirportBindingSource.Current).checkAddress3, AirportBindingSource);
            }
        }

        private void townTextEdit_Leave(object sender, EventArgs e)
        {
            if (AirportBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;

                validCheck.check(sender, errorProvider1, ((Airport)AirportBindingSource.Current).checkTown, AirportBindingSource);
            }
        }

        private void zipTextEdit_Leave(object sender, EventArgs e)
        {
            if (AirportBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;

                validCheck.check(sender, errorProvider1, ((Airport)AirportBindingSource.Current).checkZip, AirportBindingSource);
            }
        }

        private void latitudeTextEdit_Leave(object sender, EventArgs e)
        {
            if (AirportBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((Airport)AirportBindingSource.Current).checkLatitude, AirportBindingSource);
            }
        }

        private void longitudeTextEdit_Leave(object sender, EventArgs e)
        {
            if (AirportBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((Airport)AirportBindingSource.Current).checkLongitude, AirportBindingSource);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string state = ImageComboBoxEditState.EditValue.ToString();
            string country = ImageComboBoxEditCountry.EditValue.ToString();
            Uri mapUri = new Uri(new Uri("http://www.bing.com/"), "maps/default.aspx?where1=" + address1TextEdit.Text + "%20" + address2TextEdit.Text + "%20" + address3TextEdit.Text + ",%20" + townTextEdit.Text + ",%20" + state + ",%20" + country + "&v=2");
            Form map = new TraceForms.WebBrowser(mapUri) { MdiParent = this.ParentForm };
            map.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Uri mapUri = new Uri(new Uri("http://www.bing.com/"), "maps/default.aspx?where1=" + latitudeTextEdit.Text + ",%20" + longitudeTextEdit.Text + "&v=2");
            Form map = new TraceForms.WebBrowser(mapUri) { MdiParent = this.ParentForm };
            map.Show();
        }

     
     

        private void AirportForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewAirport.IsFilterRow(GridViewAirport.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewAirport.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewAirport.GetFocusedDisplayText()))
                value = GridViewAirport.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.Code like '{0}%'", GridViewAirport.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Code"));
                var special = context.Airport.Where(query);
              
                if (!string.IsNullOrWhiteSpace(GridViewAirport.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Name")))
                {
                    query = String.Format("it.{0} like '{1}%'", "Name", GridViewAirport.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Name"));
                    special = special.Where(query);
                }
                int count = special.Count();
                if (count > 0)
                {
                    AirportBindingSource.DataSource = special;
                    
                    GridViewAirport.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewAirport.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void ImageComboBoxEditState_Leave(object sender, System.EventArgs e)
        {
            if (AirportBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;

                validCheck.check(sender, errorProvider1, ((Airport)AirportBindingSource.Current).checkState, AirportBindingSource);
            }
        }

        private void ImageComboBoxEditCity_Leave(object sender, System.EventArgs e)
        {
            if (AirportBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;

                validCheck.check(sender, errorProvider1, ((Airport)AirportBindingSource.Current).checkCity, AirportBindingSource);
            }
        }

        private void ImageComboBoxEditCountry_Leave(object sender, System.EventArgs e)
        {
            if (AirportBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;

                validCheck.check(sender, errorProvider1, ((Airport)AirportBindingSource.Current).checkCountry, AirportBindingSource);
            }
        }

        private void AirportBindingSource_CurrentChanged(object sender, System.EventArgs e)
        {
            if (AirportBindingSource.Current != null)
                enableNavigator(true);
            else
                enableNavigator(false);
        }

    


    

      
 
    }
}