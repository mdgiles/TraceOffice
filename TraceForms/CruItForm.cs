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
    
    public partial class CruItForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        public string username;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public string col = "colCODE";
        public FlextourEntities context;
        public CruItForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
            LoadLookups();
            CruItBindingSource.DataSource = context.CRUIT;
           
            //gsLoad.gridSearchLoad(codeSearch, "CODE", "NAME", "Code", "Name", "CODE", "CODE", "CODE", CruItBindingSource, "CODE");
            //codeSearch.GridControl.DataSource = from c in context.CRU select new { c.CODE, c.NAME };
            //codeSearch.ButtonEdit.Properties.ReadOnly = true;
            //GridViewCruIt.Columns.ColumnByName(col).OptionsColumn.AllowEdit = false;
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);

        }

        private void LoadLookups()
        {

            var cty = from ctyRec in context.CRU orderby ctyRec.CODE ascending select new { ctyRec.CODE, ctyRec.NAME };
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxEditCode.Properties.Items.Add(loadBlank);
        
            foreach (var result in cty)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.NAME.TrimEnd() };
                ImageComboBoxEditCode.Properties.Items.Add(load);
            }
            setReadOnly(true);
            enableNavigator(false);
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
            ImageComboBoxEditCode.Properties.ReadOnly = value;
            GridViewCruIt.Columns.ColumnByName(col).OptionsColumn.AllowEdit = !value;

        }


        private void setValues()
        {
            GridViewCruIt.SetFocusedRowCellValue("CODE", string.Empty);
            GridViewCruIt.SetFocusedRowCellValue("NAME", string.Empty);
            GridViewCruIt.SetFocusedRowCellValue("ITIN", string.Empty);
            GridViewCruIt.SetFocusedRowCellValue("YEAR", string.Empty);
            GridViewCruIt.SetFocusedRowCellValue("DATES", string.Empty);
            GridViewCruIt.SetFocusedRowCellValue("DESC", string.Empty);
            GridViewCruIt.SetFocusedRowCellValue("DA_NT", string.Empty);
            GridViewCruIt.SetFocusedRowCellValue("F_S", string.Empty);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            GridViewCruIt.ClearColumnsFilter();
            if (CruItBindingSource.Current == null)
            {
                //fake query in order to create a link between the database table and the binding source
                CruItBindingSource.DataSource = from opt in context.CRUIT where opt.CODE == "KJM9" select opt;
                CruItBindingSource.AddNew();
                if (GridViewCruIt.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewCruIt.FocusedRowHandle = GridViewCruIt.RowCount - 1;
                setValues();
                //codeSearch.Focus();
                setReadOnly(false);
                newRec = true;
                return;
            }
            ImageComboBoxEditCode.Focus();
            //bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewCruIt.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CRUIT)CruItBindingSource.Current);
                CruItBindingSource.AddNew();
                if (GridViewCruIt.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewCruIt.FocusedRowHandle = GridViewCruIt.RowCount - 1;
                setValues();
                //codeSearch.Focus();
                setReadOnly(false);
                newRec = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (CruItBindingSource.Current == null)
                return;
            GridViewCruIt.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                modified = false;
                newRec = false;
                CruItBindingSource.RemoveCurrent();
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
            //codeSearch.Focus();
           
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
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((CRUIT)CruItBindingSource.Current).checkAll, CruItBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, CruItBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, CruItBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }

        private void cRUITBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (CruItBindingSource.Current == null)
                return;

            GridViewCruIt.CloseEditor();
            ImageComboBoxEditCode.Focus();
            bool temp = newRec;
           // bindingNavigatorPositionItem.Focus();//trigger field leave event
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
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CRUIT)CruItBindingSource.Current);
            
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool move()
        {

            GridViewCruIt.CloseEditor();
            ImageComboBoxEditCode.Focus(); 
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CRUIT)CruItBindingSource.Current);
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
                CruItBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                CruItBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                CruItBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                CruItBindingSource.MoveLast();
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (CruItBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CRUIT)CruItBindingSource.Current);


                setReadOnly(true);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CRUIT)CruItBindingSource.Current);
           
                e.Allow = false;

            }
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewCruIt.IsFilterRow(e.RowHandle))
                modified = true;
            labelControl12.Text = DateTime.Today.ToShortDateString();
            labelControl14.Text = username;
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
           // temp = newRec;
           //if (!temp && checkForms())
           //     context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (CRUIT)CruItBindingSource.Current);

           // setReadOnly(true);
        }

        private void CruItForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void nAMETextEdit_Leave(object sender, EventArgs e)
        {
            if (CruItBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl12.Text = DateTime.Today.ToShortDateString();
                    labelControl14.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CRUIT)CruItBindingSource.Current).checkName, CruItBindingSource);
            }
        }

        private void iTINTextEdit_Leave(object sender, EventArgs e)
        {
            if (CruItBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl12.Text = DateTime.Today.ToShortDateString();
                    labelControl14.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CRUIT)CruItBindingSource.Current).checkItin, CruItBindingSource);
            }
        }

        private void yEARComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (CruItBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl12.Text = DateTime.Today.ToShortDateString();
                    labelControl14.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CRUIT)CruItBindingSource.Current).checkYear, CruItBindingSource);
            }
        }

        private void dESCTextEdit_Leave(object sender, EventArgs e)
        {
            if (CruItBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl12.Text = DateTime.Today.ToShortDateString();
                    labelControl14.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CRUIT)CruItBindingSource.Current).checkDesc, CruItBindingSource);
            }
        }

        private void arvDateDateEdit_Leave(object sender, EventArgs e)
        {
            if (CruItBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl12.Text = DateTime.Today.ToShortDateString();
                    labelControl14.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CRUIT)CruItBindingSource.Current).checkStart, CruItBindingSource);
            }
        }

        private void depDateDateEdit_Leave(object sender, EventArgs e)
        {
            if (CruItBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl12.Text = DateTime.Today.ToShortDateString();
                    labelControl14.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CRUIT)CruItBindingSource.Current).checkEnd, CruItBindingSource);
            }
        }

        private void dA_NTTextEdit_Leave(object sender, EventArgs e)
        {
            if (CruItBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl12.Text = DateTime.Today.ToShortDateString();
                    labelControl14.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CRUIT)CruItBindingSource.Current).checkDays, CruItBindingSource);
            }
        }

        private void f_SComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (CruItBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl12.Text = DateTime.Today.ToShortDateString();
                    labelControl14.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CRUIT)CruItBindingSource.Current).checkFly, CruItBindingSource);
            }
        }

        private void dATESTextEdit_Leave(object sender, EventArgs e)
        {
            if (CruItBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl12.Text = DateTime.Today.ToShortDateString();
                    labelControl14.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CRUIT)CruItBindingSource.Current).checkDates, CruItBindingSource);
            }
        }

        private void arvDateDateEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void arvDateDateEdit_TextChanged(object sender, EventArgs e)
        {
            arvDateDateEdit.Text = validCheck.convertDate(arvDateDateEdit.Text);
        }

        private void depDateDateEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void depDateDateEdit_TextChanged(object sender, EventArgs e)
        {
            depDateDateEdit.Text = validCheck.convertDate(depDateDateEdit.Text);
        }

        private void CruItForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewCruIt.IsFilterRow(GridViewCruIt.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewCruIt.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewCruIt.GetFocusedDisplayText()))
                value = GridViewCruIt.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.NAME like '{0}%'", GridViewCruIt.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "NAME"));
                var special = context.CRUIT.Where(query);
               
                if (!string.IsNullOrWhiteSpace(GridViewCruIt.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE")))
                {
                    query = String.Format("it.{0} like '{1}%'", "CODE", GridViewCruIt.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                    special = special.Where(query);
                }

                int count = special.Count();
                if (count > 0)
                {
                    CruItBindingSource.DataSource = special;
                    GridViewCruIt.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewCruIt.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void ImageComboBoxEditCode_Leave(object sender, System.EventArgs e)
        {
            if (CruItBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl12.Text = DateTime.Today.ToShortDateString();
                    labelControl14.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CRUIT)CruItBindingSource.Current).checkCode, CruItBindingSource);

            }
        }

        private void CruItBindingSource_CurrentChanged(object sender, System.EventArgs e)
        {
            if (CruItBindingSource.Current != null)
                enableNavigator(true);
            else
                enableNavigator(false);
        }
    }
}