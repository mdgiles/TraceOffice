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
    
    public partial class SeaportForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool createNew;
        public bool modified = false;
        public bool newRec = false;
        public bool addNew = false;
        public bool temp = false;
        public bool refresh = false;
        public bool cancelled = false;
        const string colName = "colCode";
        public  FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public SeaportForm(FlexInterfaces.Core.ICoreSys sys)
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
            GridViewSeaport.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = !value;
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
            GridViewSeaport.SetFocusedRowCellValue("Code", string.Empty);
            GridViewSeaport.SetFocusedRowCellValue("Name", string.Empty);
            GridViewSeaport.SetFocusedRowCellValue("Address1", string.Empty);
            GridViewSeaport.SetFocusedRowCellValue("Address2", string.Empty);
            GridViewSeaport.SetFocusedRowCellValue("Address3", string.Empty);
            GridViewSeaport.SetFocusedRowCellValue("City", string.Empty);
            GridViewSeaport.SetFocusedRowCellValue("Town", string.Empty);
            GridViewSeaport.SetFocusedRowCellValue("State", string.Empty);
            GridViewSeaport.SetFocusedRowCellValue("Zip", string.Empty);
            GridViewSeaport.SetFocusedRowCellValue("Country", string.Empty);
            GridViewSeaport.SetFocusedRowCellValue("Latitude", 0);
            GridViewSeaport.SetFocusedRowCellValue("Longitude", 0);
            GridViewSeaport.SetFocusedRowCellValue("GeoCode_ID", 0);
        }
       

   private void Map_Click_1(object sender, EventArgs e)
   {
      
       Uri mapUri = new Uri(new Uri("http://www.bing.com/"), "maps/default.aspx?where1=" + this.latitudeTextEdit.Text + ",%20" + this.longitudeTextEdit.Text + "&v=2");
       Form map = new TraceForms.WebBrowser(mapUri) { MdiParent = this.ParentForm };
       map.Show();
   
   }
       
    private void simpleButton1_Click_1(object sender, EventArgs e)
    {
       
    
    }



   
    private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
    {
        GridViewSeaport.ClearColumnsFilter();
        if (SeaPortBindingSource.Current == null)
        {
            //fake query in order to create a link between the database table and the binding source
            SeaPortBindingSource.DataSource = from opt in context.SeaPort where opt.Code == "KJM9" select opt;
            SeaPortBindingSource.AddNew();
            if (GridViewSeaport.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                GridViewSeaport.FocusedRowHandle = GridViewSeaport.RowCount - 1;
            setValues();
            codeTextEdit.Focus();
            setReadOnly(false);
            newRec = true;
            return;
        }
       // bindingNavigatorPositionItem.Focus();  //trigger field leave event
        codeTextEdit.Focus();
        GridViewSeaport.CloseEditor();
        temp = newRec;
        if (checkForms())
        {
            if (!temp)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( SeaPort)SeaPortBindingSource.Current);
            SeaPortBindingSource.AddNew();
            if (GridViewSeaport.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                GridViewSeaport.FocusedRowHandle = GridViewSeaport.RowCount - 1;
            setValues();
           
            codeTextEdit.Focus();
            setReadOnly(false);
            newRec = true;
        }
    }

    private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
    {

        if (SeaPortBindingSource.Current == null)
            return;

        GridViewSeaport.CloseEditor();
        if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            
            modified = false;
            newRec = false;
            SeaPortBindingSource.RemoveCurrent();
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
        bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((SeaPort)SeaPortBindingSource.Current).checkAll, SeaPortBindingSource);

        if (validateMain)
            return validCheck.saveRec(ref modified, true, ref newRec, context, SeaPortBindingSource, Name, errorProvider1, Cursor);
        else
        {
            validCheck.saveRec(ref modified, false, ref newRec, context, SeaPortBindingSource, Name, errorProvider1, Cursor);
            return false;
        }
    }

    private void BindingNavigatorSaveItem_Click(object sender, EventArgs e)
    {


        if (SeaPortBindingSource.Current == null)
            return;

        GridViewSeaport.CloseEditor();
        codeTextEdit.Focus();
        //bindingNavigatorPositionItem.Focus();//trigger field leave event
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
            context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (SeaPort)SeaPortBindingSource.Current);
         

    }

    private void TimedEventSave(object sender, EventArgs e)
    {
        panelControlStatus.Visible = false;
        rowStatusSave.Stop();
    }

    private bool move()
    {
        GridViewSeaport.CloseEditor();
        codeTextEdit.Focus();
       // bindingNavigatorPositionItem.Focus();//trigger field leave event
        temp = newRec;
        if (checkForms())
        {
            if (!temp)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( SeaPort)SeaPortBindingSource.Current);
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
            SeaPortBindingSource.MoveFirst();

    }

    private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
    {
        if (move())
            SeaPortBindingSource.MovePrevious();

    }

    private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
    {
        if (move())
            SeaPortBindingSource.MoveNext();

    }

    private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
    {
        if (move())
            SeaPortBindingSource.MoveLast();

    }

    private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
    {

        if (SeaPortBindingSource.Current == null)
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
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (SeaPort)SeaPortBindingSource.Current);

            setReadOnly(true);
        }
        else
        {
            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (SeaPort)SeaPortBindingSource.Current);
       
            e.Allow = false;
        }
    }
        
    private void enterControl(object sender, EventArgs e)
    {
        currentVal = ((Control)sender).Text;
    }

    private void codeTextBox_Leave(object sender, EventArgs e)
    {
        if (SeaPortBindingSource.Current != null)
        {
            if (currentVal != ((Control)sender).Text)
                modified = true;
            validCheck.check(sender, errorProvider1, ((SeaPort)SeaPortBindingSource.Current).checkCode, SeaPortBindingSource);
        }
      
    }

    private void nameTextBox_Leave(object sender, EventArgs e)
    {
        if (SeaPortBindingSource.Current != null)
        {
            if (currentVal != ((Control)sender).Text)
                modified = true;
            validCheck.check(sender, errorProvider1, ((SeaPort)SeaPortBindingSource.Current).checkName, SeaPortBindingSource);
        }
    }

    private void address1_Leave(object sender, EventArgs e)
    {
        if (SeaPortBindingSource.Current != null)
        {
            if (currentVal != ((Control)sender).Text)
                modified = true;
            validCheck.check(sender, errorProvider1, ((SeaPort)SeaPortBindingSource.Current).checkAddress1, SeaPortBindingSource);
        }
    }

    private void address2_Leave(object sender, EventArgs e)
    {
        if (SeaPortBindingSource.Current != null)
        {
            if (currentVal != ((Control)sender).Text)
                modified = true;
            validCheck.check(sender, errorProvider1, ((SeaPort)SeaPortBindingSource.Current).checkAddress2, SeaPortBindingSource);
        }
    }

    private void address3_Leave(object sender, EventArgs e)
    {
        if (SeaPortBindingSource.Current != null)
        {
            if (currentVal != ((Control)sender).Text)
                modified = true;
            validCheck.check(sender, errorProvider1, ((SeaPort)SeaPortBindingSource.Current).checkAddress3, SeaPortBindingSource);
        }
    }

    private void city_Leave(object sender, EventArgs e)
    {
        if (SeaPortBindingSource.Current != null)
        {
            if (currentVal != ((Control)sender).Text)
                modified = true;
            validCheck.check(sender, errorProvider1, ((SeaPort)SeaPortBindingSource.Current).checkTown, SeaPortBindingSource);
        }
    }

    private void zip_Leave(object sender, EventArgs e)
    {
        if (SeaPortBindingSource.Current != null)
        {
            if (currentVal != ((Control)sender).Text)
                modified = true;
            validCheck.check(sender, errorProvider1, ((SeaPort)SeaPortBindingSource.Current).checkZip, SeaPortBindingSource);
        }
    }

    private void latitude_Leave(object sender, EventArgs e)
    {
        if (SeaPortBindingSource.Current != null)
        {
            if (currentVal != ((Control)sender).Text)
                modified = true;
            validCheck.check(sender, errorProvider1, ((SeaPort)SeaPortBindingSource.Current).checkLatitude, SeaPortBindingSource);
        }
    }

    private void longitude_Leave(object sender, EventArgs e)
    {
        if (SeaPortBindingSource.Current != null)
        {
            if (currentVal != ((Control)sender).Text)
                modified = true;
            validCheck.check(sender, errorProvider1, ((SeaPort)SeaPortBindingSource.Current).checkTown, SeaPortBindingSource);
        }
    }

    private void SeaPortForm_FormClosing(object sender, FormClosingEventArgs e)
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
        if (!GridViewSeaport.IsFilterRow(e.RowHandle))
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
            context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( SeaPort)SeaPortBindingSource.Current);

        setReadOnly(true);
    }

   

    private void SeaportForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter && GridViewSeaport.IsFilterRow(GridViewSeaport.FocusedRowHandle))
        {
            executeQuery();
        }
    }

    private void executeQuery()
    {
        this.Cursor = Cursors.WaitCursor;
        string colName = GridViewSeaport.FocusedColumn.FieldName;
        string value = String.Empty;
        if (!string.IsNullOrWhiteSpace(GridViewSeaport.GetFocusedDisplayText()))
            value = GridViewSeaport.GetFocusedDisplayText();
        if (!string.IsNullOrWhiteSpace(value))
        {
            string query = String.Format("it.Code like '{0}%'", GridViewSeaport.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Code"));
            var special = context.SeaPort.Where(query);

            if (!string.IsNullOrWhiteSpace(GridViewSeaport.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Name")))
            {
                query = String.Format("it.{0} like '{1}%'", "Name", GridViewSeaport.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Name"));
                special = special.Where(query);
            }

            int count = special.Count();
            if (count > 0)
            {
                SeaPortBindingSource.DataSource = special;
                GridViewSeaport.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                GridViewSeaport.FocusedRowHandle = 0;
                GridViewSeaport.FocusedColumn.FieldName = colName;
            }
            else
            {
                MessageBox.Show("No records in database.");
                GridViewSeaport.ClearColumnsFilter();
            }
        }
        this.Cursor = Cursors.Default;
    }

    private void SeaPortBindingSource_CurrentChanged(object sender, System.EventArgs e)
    {
        if (SeaPortBindingSource.Current != null)
            enableNavigator(true);
        else
            enableNavigator(false);
    }

    private void ImageComboBoxEditState_Leave(object sender, System.EventArgs e)
    {
        if (SeaPortBindingSource.Current != null)
        {
            if (currentVal != ((Control)sender).Text)
                modified = true;
            validCheck.check(sender, errorProvider1, ((SeaPort)SeaPortBindingSource.Current).checkState, SeaPortBindingSource);
        }
    }

    private void ImageComboBoxEditCountry_Leave(object sender, System.EventArgs e)
    {
        if (SeaPortBindingSource.Current != null)
        {
            if (currentVal != ((Control)sender).Text)
                modified = true;
            validCheck.check(sender, errorProvider1, ((SeaPort)SeaPortBindingSource.Current).checkCountry, SeaPortBindingSource);
        }
    }

    private void ImageComboBoxEditCity_Leave(object sender, System.EventArgs e)
    {
        if (SeaPortBindingSource.Current != null)
        {
            if (currentVal != ((Control)sender).Text)
                modified = true;
            validCheck.check(sender, errorProvider1, ((SeaPort)SeaPortBindingSource.Current).checkCity, SeaPortBindingSource);
        }
    }

    private void simpleButton1_Click(object sender, System.EventArgs e)
    {
        string state = ImageComboBoxEditState.EditValue.ToString();
        string country = ImageComboBoxEditCountry.EditValue.ToString();
        Uri mapUri = new Uri(new Uri("http://www.bing.com/"), "maps/default.aspx?where1=" + this.address1TextEdit.Text + "%20" + this.address2TextEdit.Text + "%20" + this.address3TextEdit.Text + ",%20" + this.townTextEdit.Text + ",%20" + state + ",%20" + country + "&v=2");
        Form map = new TraceForms.WebBrowser(mapUri) { MdiParent = this.ParentForm };
        map.Show();
    }
























    }
}