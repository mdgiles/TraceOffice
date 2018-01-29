using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using FlexModel;
using System.Data.Entity.Core.Objects;
using System.Data.Objects;
using DevExpress.XtraEditors.Controls;
using System.Linq;
using DevExpress.Xpo;
using System.Linq.Dynamic;
using System.Reflection;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Reflection;
using DevExpress.XtraGrid.Views.Base;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
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
using System.Data.Entity.Infrastructure;
using DevExpress.XtraEditors.Repository;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraGrid;
using System.Data.Metadata.Edm;
using System.Linq.Expressions;
namespace TraceForms
{
    
    public partial class UserFieldsForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        const string colName1 = "colCode";
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public FlextourEntities context;
        public UserFieldsForm(FlexCore.CoreSys _sys)
        {
            
            InitializeComponent();
            Connection.EFConnectionString = _sys.Settings.EFConnectionString;
            context = new FlextourEntities(_sys.Settings.EFConnectionString);
            UserFieldsBindingSource.DataSource = context.USERFIELDS;
            
          //  int maxlength = context.AGY.Max(x => x.USER_TXT1.Length);
          
        }

        private bool checkForms()
        {
            if (!modified && !newRec)
                return true;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel1.Controls, errorProvider1, ((USERFIELDS)UserFieldsBindingSource.Current).checkAll, UserFieldsBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, UserFieldsBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, UserFieldsBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }


        /// <span class="code-SummaryComment"><summary></span>
        /// Gets the length limit for a given field on a LINQ object ... or zero if not known
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><remarks></span>
        /// You can use the results from this method to dynamically 
        /// set the allowed length of an INPUT on your web page to
        /// exactly the same length as the length of the database column.  
        /// Change the database and the UI changes just by
        /// updating your DBML and recompiling.
        /// <span class="code-SummaryComment"></remarks></span>
        public static int GetLengthLimit(object obj, string field)
        {
            int dblenint = 0;   // default value = we can't determine the length

            Type type = obj.GetType();
            PropertyInfo prop = type.GetProperty(field);
            // Find the Linq 'Column' attribute
            // e.g. [Column(Storage="_FileName", DbType="NChar(256) NOT NULL", CanBeNull=false)]
            object[] info = prop.GetCustomAttributes(typeof(ColumnAttribute), true);
            // Assume there is just one
            if (info.Length == 1)
            {
                ColumnAttribute ca = (ColumnAttribute)info[0];
                string dbtype = ca.DbType;

                if (dbtype.StartsWith("NChar") || dbtype.StartsWith("NVarChar"))
                {
                    int index1 = dbtype.IndexOf("(");
                    int index2 = dbtype.IndexOf(")");
                    string dblen = dbtype.Substring(index1 + 1, index2 - index1 - 1);
                    int.TryParse(dblen, out dblenint);
                }
            }
            return dblenint;
        }

        /// <span class="code-SummaryComment"><summary></span>
        /// If you don't care about truncating data that you are setting on a LINQ object, 
        /// use something like this ...
        /// <span class="code-SummaryComment"></summary></span>
        public static void SetAutoTruncate(object obj, string field, string value)
        {
            int len = GetLengthLimit(obj, field);
            if (len == 0) throw new ApplicationException("Field '" + field +
                    "'does not have length metadata");

            Type type = obj.GetType();
            PropertyInfo prop = type.GetProperty(field);
            if (value.Length > len)
            {
                prop.SetValue(obj, value.Substring(0, len), null);
            }
            else
                prop.SetValue(obj, value, null);
        } 


        private void setValues()
        {
            advBandedGridView1.SetFocusedRowCellValue("LINK_TABLE", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("LINK_COLUMN", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("RECTYPE", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("LABEL", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("DESC", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("VISIBLE", false);
            advBandedGridView1.SetFocusedRowCellValue("LKUP_CODE_COLUMN", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("LKUP_DESC_COLUMN", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("LKUP_TABLE", string.Empty);
            advBandedGridView1.SetFocusedRowCellValue("SIZE", 0);
            advBandedGridView1.SetFocusedRowCellValue("MIN", 0);
            advBandedGridView1.SetFocusedRowCellValue("MAX", 0);
            advBandedGridView1.SetFocusedRowCellValue("RESTRICT_TO_LKUP", false);
            advBandedGridView1.SetFocusedRowCellValue("PRECISION", 0);
            advBandedGridView1.SetFocusedRowCellValue("REQUIRED", false);
            advBandedGridView1.SetFocusedRowCellValue("POSITION", 0);
        }
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
          // advBandedGridView1.FocusedRowHandle = GridControl.AutoFilterRowHandle;
            advBandedGridView1.ExpandAllGroups();
          
            if (UserFieldsBindingSource.Current == null)
            {                
                UserFieldsBindingSource.AddNew();
                if (advBandedGridView1.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    advBandedGridView1.FocusedRowHandle = advBandedGridView1.RowCount - 1;
                setValues();
                newRec = true;
           
                return;   
            }
            temp = newRec;
         //dingNavigatorPositionItem.Focus();  //trigger field leave event
           if (checkForms())
           {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (USERFIELDS)UserFieldsBindingSource.Current);
                UserFieldsBindingSource.AddNew();
                if (advBandedGridView1.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    advBandedGridView1.FocusedRowHandle = advBandedGridView1.RowCount - 1;
                setValues();
                newRec = true;
            }
           advBandedGridView1.ExpandAllGroups();
          
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (UserFieldsBindingSource.Current == null)
                return;
            advBandedGridView1.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                modified = false;
                newRec = false;
                UserFieldsBindingSource.RemoveCurrent();
                errorProvider1.Clear();
                context.SaveChanges();
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);
            }
            //currentVal = gridSearchControl1.Text;
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }

        private void setSize()
        {
            //if necessary all this can be done dynamically using a similar technique to that employed in commissions
           string val = advBandedGridView1.GetFocusedRowCellDisplayText("LINK_COLUMN");
            if(val.Contains("TXT"))
                advBandedGridView1.SetFocusedRowCellValue("SIZE", 50);
            else if(val.Contains("DTE"))
                advBandedGridView1.SetFocusedRowCellValue("SIZE", 16);
            else if(val.Contains("INT") || val.Contains("DEC"))
                advBandedGridView1.SetFocusedRowCellValue("SIZE", 4);

        }

        private void uSERFIELDSBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            setSize();

            if (UserFieldsBindingSource.Current == null)
                return;

            advBandedGridView1.CloseEditor();
            advBandedGridView1.Focus();
            bool temp = newRec;
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            if (checkForms())
            {
                advBandedGridView1.Focus();
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
            }

            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (USERFIELDS)UserFieldsBindingSource.Current);
              
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool move()
        {
            ColumnView view = advBandedGridView1;
            GridColumn column1 = view.Columns["LINK_TABLE"];
            GridColumn column2 = view.Columns["LINK_COLUMN"];
            GridColumn column3 = view.Columns["DESC"];

            string val1 = (string)view.GetFocusedRowCellValue(column1);
            string val2 = (string)view.GetFocusedRowCellValue(column2);
            string val3 = (string)view.GetFocusedRowCellValue(column3);

            //if (string.IsNullOrWhiteSpace(val1))
            //{
            //    view.SetColumnError(column1, "Link Table cannot be blank in a row.");
            //    return false;
            //}

            //if (string.IsNullOrWhiteSpace(val2))
            //{
            //    view.SetColumnError(column2, "Link Column cannot be blank in a row.");
            //    return false;
            //}

            //if (string.IsNullOrWhiteSpace(val3))
            //{
            //    view.SetColumnError(column3, "Description cannot be blank in a row.");
            //    return false;
            //}
            advBandedGridView1.CloseEditor();
            advBandedGridView1.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (USERFIELDS)UserFieldsBindingSource.Current);
                
                newRec = false;
                modified = false;
                return true;
            }
            return false;
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (move())
                UserFieldsBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                UserFieldsBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                UserFieldsBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                UserFieldsBindingSource.MoveLast();
        }

   

        private void UserFieldsForm_FormClosing(object sender, FormClosingEventArgs e)
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
            temp = newRec;
            ColumnView view = advBandedGridView1;
            GridColumn column1 = view.Columns["LINK_TABLE"];
            GridColumn column2 = view.Columns["LINK_COLUMN"];
            GridColumn column3 = view.Columns["DESC"];

            string val1 = (string)view.GetFocusedRowCellValue(column1);
            string val2 = (string)view.GetFocusedRowCellValue(column2);
            string val3 = (string)view.GetFocusedRowCellValue(column3);

            //if (string.IsNullOrWhiteSpace(val1)) 
            //{
            //    view.SetColumnError(column1, "Link Table cannot be blank in a row.");
            //    return;
            //}

            //if (string.IsNullOrWhiteSpace(val2))
            //{
            //    view.SetColumnError(column2, "Link Column cannot be blank in a row.");
            //    return;
            //}

            //if (string.IsNullOrWhiteSpace(val3))
            //{
            //    view.SetColumnError(column3, "Description cannot be blank in a row.");
            //    return;
            //}
       
        }

        private void advBandedGridView1_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            GridColumn column1 = view.Columns["LINK_TABLE"];
            GridColumn column2 = view.Columns["LINK_COLUMN"];
            GridColumn column3 = view.Columns["DESC"];

            string val1 = (string)view.GetRowCellValue(e.RowHandle, column1);
            string val2 = (string)view.GetRowCellValue(e.RowHandle, column2);
            string val3 = (string)view.GetRowCellValue(e.RowHandle, column3);

            //if (string.IsNullOrWhiteSpace(val1))
            //{
            //    e.Valid = false;
            //    view.SetColumnError(column1, "Link Table cannot be blank in a row.");
            //}

            //if (string.IsNullOrWhiteSpace(val2))
            //{
            //    e.Valid = false;
            //    view.SetColumnError(column2, "Link Column cannot be blank in a row.");
            //}

            //if (string.IsNullOrWhiteSpace(val3))
            //{
            //    e.Valid = false;
            //    view.SetColumnError(column3, "Description cannot be blank in a row.");
            //}
        }

        private void advBandedGridView1_BeforeLeaveRow(object sender, RowAllowEventArgs e)
        {
            ColumnView view = advBandedGridView1;
            GridColumn column1 = view.Columns["LINK_TABLE"];
            GridColumn column2 = view.Columns["LINK_COLUMN"];
            GridColumn column3 = view.Columns["DESC"];

            string val1 = (string)view.GetFocusedRowCellValue(column1);
            string val2 = (string)view.GetFocusedRowCellValue(column2);
            string val3 = (string)view.GetFocusedRowCellValue(column3);
            if ((string.IsNullOrWhiteSpace(val1) || string.IsNullOrWhiteSpace(val2) || string.IsNullOrWhiteSpace(val3)) && newRec == true)
            {
                e.Allow = false;
                return;

            }

            if (UserFieldsBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (USERFIELDS)UserFieldsBindingSource.Current);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (USERFIELDS)UserFieldsBindingSource.Current);
         
                e.Allow = false;
            }
        }

        private void advBandedGridView1_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            if (!advBandedGridView1.IsFilterRow(e.RowHandle))
                modified = true;
        }

        private void advBandedGridView1_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }
    }
}