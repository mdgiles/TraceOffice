using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using FlexModel;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using System.Runtime.InteropServices;
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
    
    public partial class packItinMaint : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool createNew;
        public bool modified = false;
        public bool newRec = false;
        public bool addNew = false;
        public string username;
        public bool temp = false;
        public bool refresh = false;
        public bool cancelled = false;
        const string colName = "colCODE";
        public  FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public packItinMaint(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
            LoadLookups();
            
          
            //packages
            //gsLoad.gridSearchLoad(codeSearch, "CODE", "NAME", "Code", "Name", "CODE", "CODE", "NAME", PitinBindingSource, "CODE");
            //codeSearch.ButtonEdit.Properties.ReadOnly = true; 
            //catSearch.ButtonEdit.Properties.ReadOnly = true;
          


            // //categories
          
           
            //this.catSearch.GridControl.DataSource = from c in context.ROOMCOD select new { c.CODE, c.DESC };
            //codeSearch.GridControl.DataSource = from c in context.PACK select new { c.CODE, c.NAME };
            //status_stringComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);
            username = sys.User.Name;
        }

        private void setReadOnly(bool value)
        {
            ImageComboBoxEditCode.Properties.ReadOnly = value ;
            ImageComboBoxEditCategory.Properties.ReadOnly = value ;
            dATEDateEdit.Properties.ReadOnly = value;
        }

        private void LoadLookups()
        {
            modified = false;
            newRec = false;
            var agy = from agyRec in context.AGY orderby agyRec.NO ascending select new { agyRec.NO, agyRec.NAME };
            var cty = from ctyRec in context.CITYCOD orderby ctyRec.CODE ascending select new { ctyRec.CODE, ctyRec.NAME };
            var cat = from catRec in context.ROOMCOD orderby catRec.CODE ascending select new { catRec.CODE, catRec.DESC };
            var car = from carRec in context.PACK orderby carRec.CODE ascending select new { carRec.CODE, carRec.NAME };
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxEditCode.Properties.Items.Add(loadBlank);            
            ImageComboBoxEditCategory.Properties.Items.Add(loadBlank);

           
            foreach (var result in car)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCode.Properties.Items.Add(load);
            }
            foreach (var result in cat)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.DESC.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCategory.Properties.Items.Add(load);
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

        void ButtonEdit_QueryPopUp1(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
        }

        private bool checkForms()
        {
            if (!modified && !newRec)
                return true;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((PITIN)PitinBindingSource.Current).checkAll, PitinBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, PitinBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, PitinBindingSource, Name, errorProvider1, Cursor
                    );
                return false;
            }
        }
      
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (PitinBindingSource.Current == null)
            {
                PitinBindingSource.AddNew();
                ImageComboBoxEditCode.Focus();
                setReadOnly(false);
              
                newRec = true;
                return;
            }
            ImageComboBoxEditCode.Focus();
            //bindingNavigatorPositionItem.Focus();  //trigger field leave event            
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( PITIN)PitinBindingSource.Current);
                PitinBindingSource.AddNew();
                ImageComboBoxEditCode.Focus();
                setReadOnly(false);
                             
                
                newRec = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (PitinBindingSource.Current == null)
                return;
           
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                modified = false;
                newRec = false;
                PitinBindingSource.RemoveCurrent();
                errorProvider1.Clear();
                context.SaveChanges();
                setReadOnly(true);
                dATEDateEdit.Properties.ReadOnly = true;
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);

            }
            currentVal = ImageComboBoxEditCode.Text;
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }

        private void BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        { 
            if (PitinBindingSource.Current == null)
                return;

            GridViewPackItin.CloseEditor();
            ImageComboBoxEditCode.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            bool temp = newRec;
            if (checkForms())
            {
                setReadOnly(true);
                dATEDateEdit.Properties.ReadOnly = true;
                GridViewPackItin.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = false;
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
            }

            if (!temp  && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (PITIN)PitinBindingSource.Current);
               
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool move()
        {
            ImageComboBoxEditCode.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( PITIN)PitinBindingSource.Current);
                setReadOnly(true);
                dATEDateEdit.Properties.ReadOnly = true;
                newRec = false;
                modified = false;
                return true;
            }
            return false;
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (move())
                PitinBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                PitinBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                PitinBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                PitinBindingSource.MoveLast();
        }

  
        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        private void codeTextBox_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                LastUpd.Text = DateTime.Today.ToShortDateString(); ;
                UpdBy.Text = username;
            }
            validCheck.check(sender, errorProvider1, (( PITIN)PitinBindingSource.Current).checkCode, PitinBindingSource);
           
        }

        private void cat_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                LastUpd.Text = DateTime.Today.ToShortDateString(); ;
                UpdBy.Text = username;
            }
            validCheck.check(sender, errorProvider1, (( PITIN)PitinBindingSource.Current).checkCat, PitinBindingSource);
           
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            //temp = newRec;
            //if (!temp && checkForms())
            //    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( PITIN)PitinBindingSource.Current);

            //setReadOnly(true);
            //dATEDateEdit.Properties.ReadOnly = true;
           
        }

        private void PITINForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void advBandedGridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            //if (PitinBindingSource.Current == null)
            if (PitinBindingSource.Current == null)
            {
                e.Allow = true;
                return;
            }
            temp = newRec;
            bool temp2 = modified;
            if (checkForms())
            {
                errorProvider1.Clear();
                e.Allow = true;
                if ((!temp) && temp2)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (PITIN)PitinBindingSource.Current);

                setReadOnly(true);
            }
            else
            {

                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (PITIN)PitinBindingSource.Current);

                e.Allow = false;
            }
        }

        private void advBandedGridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void status_stringComboBoxEdit_Leave(object sender, EventArgs e)
        {

        }

        private void dATEDateEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                 LastUpd.Text = DateTime.Today.ToShortDateString(); ;
                UpdBy.Text = username;
            }
            validCheck.check(sender, errorProvider1, (( PITIN)PitinBindingSource.Current).checkDate, PitinBindingSource);
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

        private void packItinMaint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewPackItin.IsFilterRow(GridViewPackItin.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewPackItin.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewPackItin.GetFocusedDisplayText()))
                value = GridViewPackItin.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.CAT like '{0}%'", GridViewPackItin.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CAT"));
                var special = context.PITIN.Where(query);

                if (!string.IsNullOrWhiteSpace(GridViewPackItin.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE")))
                {
                    query = String.Format("it.{0} like '{1}%'", "CODE", GridViewPackItin.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                    special = special.Where(query);
                }
                if (!string.IsNullOrWhiteSpace(GridViewPackItin.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "DATE")))
                {
                    string validDate = GridViewPackItin.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "DATE");
                    string values = validCheck.convertDate(validDate);
                    if (!string.IsNullOrWhiteSpace(values))
                    {
                        DateTime startDate = Convert.ToDateTime(values);
                        special = special.Where("it.DATE >= @dates", new ObjectParameter("dates", startDate));
                    }
                }
                int count = special.Count();
                if (count > 0)
                {
                    PitinBindingSource.DataSource = special;
                    GridViewPackItin.FocusedRowHandle = 0;
                    GridViewPackItin.FocusedColumn.FieldName = colName;
                    GridViewPackItin.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewPackItin.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void GridViewPackItin_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "DATE")
            {
                if (e.Value != null)
                {
                    e.DisplayText = validCheck.convertDate(e.Value.ToString());
                }
            }
        }

        private void PitinBindingSource_CurrentChanged(object sender, System.EventArgs e)
        {
            if (PitinBindingSource.Current != null)
                enableNavigator(true);
            else
                enableNavigator(false);
        }

        private void sTATUSImageComboBoxEdit_Leave(object sender, System.EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                LastUpd.Text = DateTime.Today.ToShortDateString(); ;
                UpdBy.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((PITIN)PitinBindingSource.Current).checkStatus, PitinBindingSource);
           
        }
    }
}