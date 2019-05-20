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
using System.Data.Linq.SqlClient;

namespace TraceForms
{
    
    public partial class VouchGenForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public string table;
        public FlextourEntities context;
        public VouchGenForm(FlexCore.CoreSys _sys)
        {
            InitializeComponent();
            Connection.EFConnectionString = _sys.Settings.EFConnectionString;
            context = new FlextourEntities(_sys.Settings.EFConnectionString);
            VoucherBindingSource.DataSource = context.VOUCHER;
            gsLoad.gridSearchLoad(codeSearch, "CODE", "NAME", "Code", "Name", "CODE", "CODE", "CODE", VoucherBindingSource, "Code");

            gsLoad.gridSearchLoad(catSearch, "CODE", "DESC", "Code", "Name", "CODE", "CODE", "CODE", VoucherBindingSource, "Cat");

            catSearch.GridControl.DataSource = context.ROOMCOD;
            
        }


        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        private bool checkForms()
        {
            if (!modified && !newRec)
                return true;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((VOUCHER)VoucherBindingSource.Current).checkAll, VoucherBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, VoucherBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, VoucherBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (VoucherBindingSource.Current == null)
            {
                VoucherBindingSource.AddNew();
                TextEditAgyNo.Focus();
                //agyNoTextEdit.Properties.ReadOnly = false;
                //gridView1.Columns.ColumnByName(colName1).OptionsColumn.AllowEdit = true;
                newRec = true;
                return;
            }
            TextEditAgyNo.Focus();
            //bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewVouch.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (VOUCHER)VoucherBindingSource.Current);
                VoucherBindingSource.AddNew();
                TextEditAgyNo.Focus();
                //agyNoTextEdit.Properties.ReadOnly = false;
                //gridView1.Columns.ColumnByName(colName1).OptionsColumn.AllowEdit = true;
                newRec = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (VoucherBindingSource.Current == null)
                return;
            GridViewVouch.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                modified = false;
                newRec = false;
                VoucherBindingSource.RemoveCurrent();
                errorProvider1.Clear();
                context.SaveChanges();
                //agyNoTextEdit.Properties.ReadOnly = true;
                //gridView1.Columns.ColumnByName(colName1).OptionsColumn.AllowEdit = false;
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);


            }
            currentVal = TextEditAgyNo.Text;
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }

        private void vOUCHERBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (VoucherBindingSource.Current == null)
                return;

            GridViewVouch.CloseEditor();
            TextEditAgyNo.Focus();
            bool temp = newRec;
           // bindingNavigatorPositionItem.Focus();//trigger field leave event
            if (checkForms())
            {
                TextEditAgyNo.Focus();
                //agyNoTextEdit.Properties.ReadOnly = true;
                //gridView1.Columns.ColumnByName(colName1).OptionsColumn.AllowEdit = false;
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;

            }

            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (VOUCHER)VoucherBindingSource.Current);
               
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool move()
        {
            GridViewVouch.CloseEditor();
            TextEditAgyNo.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (VOUCHER)VoucherBindingSource.Current);
                //agyNoTextEdit.Properties.ReadOnly = true;
                //gridView1.Columns.ColumnByName(colName1).OptionsColumn.AllowEdit = false;
                newRec = false;
                modified = false;
                return true;
            }
            return false;
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (move())
                VoucherBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                VoucherBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                VoucherBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                VoucherBindingSource.MoveLast();
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            temp = newRec;
            if (!temp && checkForms())
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (VOUCHER)VoucherBindingSource.Current);

            //agyNoTextEdit.Properties.ReadOnly = true;
            //gridView1.Columns.ColumnByName(colName1).OptionsColumn.AllowEdit = false;
        }

        private void VouchGenForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void agyNoTextEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
                modified = true;
            validCheck.check(sender, errorProvider1, ((VOUCHER)VoucherBindingSource.Current).checkAgency, VoucherBindingSource); 
        }

        private void issuedByTextEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
                modified = true;
            validCheck.check(sender, errorProvider1, ((VOUCHER)VoucherBindingSource.Current).checkIssue, VoucherBindingSource); 
        }

        private void typeComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
                modified = true;
            validCheck.check(sender, errorProvider1, ((VOUCHER)VoucherBindingSource.Current).checkType, VoucherBindingSource); 
        }

        private void codeSearch_Enter(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;

            codeSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        void ButtonEdit_QueryPopUp(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
        }

        private void catSearch_Enter(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;

            catSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        private void codeSearch_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
                modified = true;
            validCheck.check(sender, errorProvider1, ((VOUCHER)VoucherBindingSource.Current).checkCode, VoucherBindingSource);
        }

        private void catSearch_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
                modified = true;
            validCheck.check(sender, errorProvider1, ((VOUCHER)VoucherBindingSource.Current).checkCat, VoucherBindingSource);
        }

        private void startDateDateEdit_Leave(object sender, EventArgs e)
        {

        }

        private void expDateDateEdit_Leave(object sender, EventArgs e)
        {

        }

        private void pANoTextEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
                modified = true;
            validCheck.check(sender, errorProvider1, ((VOUCHER)VoucherBindingSource.Current).checkPaNo, VoucherBindingSource);
        }

        private void spinEdit1_Leave(object sender, EventArgs e)
        {

        }

        private void typeComboBoxEdit_TextChanged(object sender, EventArgs e)
        {

            if (this.typeComboBoxEdit.Text == "OPT" || this.typeComboBoxEdit.Text == "PKG" || this.typeComboBoxEdit.Text == "HTL" || this.typeComboBoxEdit.Text == "CRU" || this.typeComboBoxEdit.Text == "CAR")
            {
                gsLoad.gridSearchLoad(codeSearch, "CODE", "NAME", "Code", "Name", "CODE", "CODE", "CODE");
                if (this.typeComboBoxEdit.Text == "HTL")
                { // htl codes                   
                    codeSearch.GridControl.DataSource = from c in context.HOTEL select new { c.CODE, c.NAME };
                }
                if (this.typeComboBoxEdit.Text == "OPT")
                {  // option codes
                    codeSearch.GridControl.DataSource = from c in context.COMP select new { c.CODE, c.NAME };
                }
                if (this.typeComboBoxEdit.Text == "PKG")
                {  // pkg codes
                    codeSearch.GridControl.DataSource = from c in context.PACK select new { c.CODE, c.NAME };
                }
                if (this.typeComboBoxEdit.Text == "CRU")
                {      //seaports              
                    codeSearch.GridControl.DataSource = from c in context.CRU select new { c.CODE, c.NAME };
                }
                if (this.typeComboBoxEdit.Text == "CAR")
                {      //seaports              
                    codeSearch.GridControl.DataSource = from c in context.CARINFO select new { c.CODE, c.NAME };
                }
            }
            if ( this.typeComboBoxEdit.Text == "AIR")
            {
                gsLoad.gridSearchLoad(codeSearch, "Code", "Name", "Code", "Name", "Code", "Code", "Name");
                //
                if (this.typeComboBoxEdit.Text == "AIR")
                {  //airports
                    codeSearch.GridControl.DataSource = from c in context.Airport select new { c.Code, c.Name };
                }
            }
        }


        private void startDateDateEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void startDateDateEdit_TextChanged(object sender, EventArgs e)
        {
            startDateDateEdit.Text = validCheck.convertDate(startDateDateEdit.Text);
        }

        private void expDateDateEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void expDateDateEdit_TextChanged(object sender, EventArgs e)
        {
            expDateDateEdit.Text = validCheck.convertDate(expDateDateEdit.Text);
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewVouch.IsFilterRow(e.RowHandle))
                modified = true;
        }

        private void VouchGenForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewVouch.IsFilterRow(GridViewVouch.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewVouch.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewVouch.GetFocusedDisplayText()))
                value = GridViewVouch.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.VoucherNo like '{0}%'", GridViewVouch.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "VoucherNo"));
                var special = context.HRATES.Where(query);

                if (!string.IsNullOrWhiteSpace(GridViewVouch.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "AgyNo")))
                {
                    query = String.Format("it.{0} like '{1}%'", "AgyNo", GridViewVouch.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "AgyNo"));
                    special = special.Where(query);
                }
                if (!string.IsNullOrWhiteSpace(GridViewVouch.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Code")))
                {
                    query = String.Format("it.{0} like '{1}%'", "Code", GridViewVouch.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "Code"));
                    special = special.Where(query);
                }
                if (!string.IsNullOrWhiteSpace(GridViewVouch.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "StartDate")))
                {
                    string validDate = GridViewVouch.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "StartDate");
                    string values = validCheck.convertDate(validDate);
                    if (!string.IsNullOrWhiteSpace(values))
                    {
                        DateTime startDate = Convert.ToDateTime(values);
                        special = special.Where("it.StartDate >= @date", new ObjectParameter("date", startDate));
                    }
                }
                int count = special.Count();
                if (count > 0)
                {
                    VoucherBindingSource.DataSource = special;
                    GridViewVouch.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                    GridViewVouch.FocusedRowHandle = 0;
                    GridViewVouch.FocusedColumn.FieldName = colName;
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewVouch.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void GridViewVouch_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "StartDate")
            {
                if (e.Value != null)
                {
                    e.DisplayText = validCheck.convertDate(e.Value.ToString());
                }
            }
        }
   

     
    }
}