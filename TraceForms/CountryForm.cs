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
    
    public partial class CountryForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        const string colName = "colCODE";
        public FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public CountryForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
            LoadLookups();
           
        }

        private void LoadLookups()
        {
            modified = false;
            newRec = false;
            setReadOnly(true);
            enableNavigator(false);

            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = null };
            imageComboBoxEditContinent.Properties.Items.Add(loadBlank);
            var continents = from cont in context.Continent orderby cont.Name ascending select new { cont.ID, cont.Name };
            foreach (var result in continents) {
                ImageComboBoxItem load = new ImageComboBoxItem() {
                    Description = result.Name,
                    Value = result.ID
                };
                imageComboBoxEditContinent.Properties.Items.Add(load);
            }

        }

        void enableNavigator(bool value)
        {
            bindingNavigatorMoveNextItem.Enabled = value;
            bindingNavigatorMoveLastItem.Enabled = value;
            bindingNavigatorMoveFirstItem.Enabled = value;
            bindingNavigatorMovePreviousItem.Enabled = value;
        }


        private void setReadOnly(bool value)
        {
            cODETextEdit.Properties.ReadOnly = value;
            GridViewCountry.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = !value;
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);

        }
       
        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        private void setValues()
        {
            GridViewCountry.SetFocusedRowCellValue("CODE", string.Empty);
            GridViewCountry.SetFocusedRowCellValue("NAME", string.Empty);
        }
     

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            
            GridViewCountry.ClearColumnsFilter();
          
            if (CountryBindingSource.Count == 0)
            {
                //fake query in order to create a link between the database table and the binding source
                CountryBindingSource.DataSource = from opt in context.COUNTRY where opt.CODE == "KJM9" select opt;
                CountryBindingSource.AddNew();
                if (GridViewCountry.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewCountry.FocusedRowHandle = GridViewCountry.RowCount - 1;
               
                setValues();
                cODETextEdit.Focus();                
                setReadOnly(false);
                newRec = true;
           
                return;
            }
            
           
            temp = newRec;
            if (checkForms())
            {
                errorProvider1.Clear();
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (COUNTRY)CountryBindingSource.Current);
                CountryBindingSource.AddNew();
                if (GridViewCountry.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewCountry.FocusedRowHandle = GridViewCountry.RowCount - 1;
                cODETextEdit.Focus();
                setReadOnly(false);
                newRec = true;
                setValues();
            }           

            
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (CountryBindingSource.Current == null)
                return;
            GridViewCountry.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                modified = false;
                newRec = false;
                CountryBindingSource.RemoveCurrent();
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
            currentVal = cODETextEdit.Text;
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
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((COUNTRY)CountryBindingSource.Current).checkAll, CountryBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, CountryBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, CountryBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }

        private void cOUNTRYBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (CountryBindingSource.Current == null)
                return;

            GridViewCountry.CloseEditor();
            cODETextEdit.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            bool temp = newRec;
            if (checkForms())
            {
                cODETextEdit.Focus();
                setReadOnly(true);
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;

            }

            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (COUNTRY)CountryBindingSource.Current);
           
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool move()
        {
            GridViewCountry.CloseEditor();
            cODETextEdit.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( COUNTRY)CountryBindingSource.Current);
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
                CountryBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                CountryBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {

            if (move())
                CountryBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                CountryBindingSource.MoveLast();
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (CountryBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (COUNTRY)CountryBindingSource.Current);
                setReadOnly(true);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (COUNTRY)CountryBindingSource.Current);
           
                e.Allow = false;

            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewCountry.IsFilterRow(e.RowHandle))
                modified = true;
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            temp = newRec;
            if (!temp && checkForms())
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( COUNTRY)CountryBindingSource.Current);
            setReadOnly(true);
        }

        private void CountryForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void cODETextEdit_Leave(object sender, EventArgs e)
        {
            if (CountryBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((COUNTRY)CountryBindingSource.Current).checkCode, CountryBindingSource);
            }
                 
        }

        private void nAMETextEdit_Leave(object sender, EventArgs e)
        {
            if (CountryBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((COUNTRY)CountryBindingSource.Current).checkName, CountryBindingSource);
            }
        }

        private void CountryForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewCountry.IsFilterRow(GridViewCountry.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewCountry.FocusedColumn.FieldName;
            string value = String.Empty;

            //value = GridViewCountry.GetFocusedDisplayText();
            //if (!string.IsNullOrWhiteSpace(value))
            //{
                string query = String.Format("it.CODE like '{0}%'", GridViewCountry.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                var special = context.COUNTRY.Where(query);
               
                if (!string.IsNullOrWhiteSpace(GridViewCountry.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "NAME")))
                {
                    query = String.Format("it.{0} like '{1}%'", "NAME", GridViewCountry.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "NAME"));
                    special = special.Where(query);
                }

                int count = special.Count();
                if (count > 0)
                {
                    CountryBindingSource.DataSource = special;
                    GridViewCountry.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewCountry.ClearColumnsFilter();
                }
            //}
            this.Cursor = Cursors.Default;
        }

        private void CountryBindingSource_CurrentChanged(object sender, System.EventArgs e)
        {
            if (CountryBindingSource.Current != null)
                enableNavigator(true);
            else
                enableNavigator(false);
        }

        private void imageComboBoxEditCountry_Leave(object sender, EventArgs e)
        {
            if (CountryBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((COUNTRY)CountryBindingSource.Current).checkContinent, CountryBindingSource);
            }
        }
    }
}