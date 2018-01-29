using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FlexModel;
using System.ComponentModel.DataAnnotations;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using System.Linq;
using DevExpress.XtraEditors.DXErrorProvider;
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
    
    public partial class InsuranForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        const string colName = "colAGENCY";
        public string username;
        public FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public InsuranForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
            LoadLookups();
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);
            username = sys.User.Name;
        }

        private void LoadLookups()
        {
            setReadOnly(true);

            var agy = from agyRec in context.AGY orderby agyRec.NO ascending select new { agyRec.NO, agyRec.NAME };
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxEditAgency.Properties.Items.Add(loadBlank);
            foreach (var result in agy)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.NO.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.NO.TrimEnd() };
                ImageComboBoxEditAgency.Properties.Items.Add(load);
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
            GridViewInsuran.SetFocusedRowCellValue("YEAR", 0);
            GridViewInsuran.SetFocusedRowCellValue("ITEM_", 0);
            GridViewInsuran.SetFocusedRowCellValue("FROM_AMT", 0);
            GridViewInsuran.SetFocusedRowCellValue("START_DATE", DateTime.Today);
            GridViewInsuran.SetFocusedRowCellValue("TO_AMT", 0);
            GridViewInsuran.SetFocusedRowCellValue("PREMIUM", 0);
            GridViewInsuran.SetFocusedRowCellValue("COMM_PCT", 0);
            GridViewInsuran.SetFocusedRowCellValue("AGENCY", string.Empty);
            GridViewInsuran.SetFocusedRowCellValue("COMM_FLG", "0");
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            GridViewInsuran.ClearColumnsFilter();
            if (InsuranBindingSource.Current == null)
            {
                //fake query in order to create a link between the database table and the binding source
                InsuranBindingSource.DataSource = from opt in context.INSURAN where opt.AGENCY == "KJM9" select opt;
                              
                InsuranBindingSource.AddNew();
                if (GridViewInsuran.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewInsuran.FocusedRowHandle = GridViewInsuran.RowCount - 1;
                setValues();
                setReadOnly(false);
                yEARComboBoxEdit.Focus();
                newRec = true;
                return;
            }
            yEARComboBoxEdit.Focus();
            //bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewInsuran.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( INSURAN)InsuranBindingSource.Current);
                InsuranBindingSource.AddNew();
                if (GridViewInsuran.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewInsuran.FocusedRowHandle = GridViewInsuran.RowCount - 1;
                setValues();
                setReadOnly(false);
                yEARComboBoxEdit.Focus();
              
              
                newRec = true;
            }

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (InsuranBindingSource.Current == null)
                return;
            GridViewInsuran.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                modified = false;
                newRec = false;
                InsuranBindingSource.RemoveCurrent();
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
            currentVal = ImageComboBoxEditAgency.Text;
        }

        private bool checkForms()
        {
            if (!modified && !newRec)
                return true;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((INSURAN)InsuranBindingSource.Current).checkAll, InsuranBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, InsuranBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, InsuranBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }


        private void iNSURANBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (InsuranBindingSource.Current == null)
                return;
            GridViewInsuran.CloseEditor();
            yEARComboBoxEdit.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            bool temp = newRec;
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
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (INSURAN)InsuranBindingSource.Current);
               
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool move()
        {
            GridViewInsuran.CloseEditor();
            yEARComboBoxEdit.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( INSURAN)InsuranBindingSource.Current);
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
                InsuranBindingSource.MoveFirst();
            
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                InsuranBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                InsuranBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                InsuranBindingSource.MoveLast();
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (InsuranBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (INSURAN)InsuranBindingSource.Current);

                setReadOnly(true);

            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (INSURAN)InsuranBindingSource.Current);
           
                e.Allow = false;
            }

        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewInsuran.IsFilterRow(e.RowHandle))
            {
                modified = true;
                labelControl1.Text = DateTime.Today.ToShortDateString();
                labelControl2.Text = username;
            }
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            temp = newRec;
            if (!temp && checkForms())
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( INSURAN)InsuranBindingSource.Current);
            setReadOnly(true);
           
        }

        private void yEARComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (InsuranBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((INSURAN)InsuranBindingSource.Current).checkYear, InsuranBindingSource);
            }
        }

        private void iTEM_TextEdit_Leave(object sender, EventArgs e)
        {
            if (InsuranBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((INSURAN)InsuranBindingSource.Current).checkItem, InsuranBindingSource);
            }
        }

        private void sTART_DATEDateEdit_Leave(object sender, EventArgs e)
        {
            if (InsuranBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((INSURAN)InsuranBindingSource.Current).checkStart, InsuranBindingSource);
            }
        }

        private void eND_DATEDateEdit_Leave(object sender, EventArgs e)
        {
            if (InsuranBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((INSURAN)InsuranBindingSource.Current).checkEnd, InsuranBindingSource);
            }
        }

        private void fROM_AMTTextEdit_Leave(object sender, EventArgs e)
        {
            if (InsuranBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((INSURAN)InsuranBindingSource.Current).checkAmount, InsuranBindingSource);
            }
        }

        private void tO_AMTTextEdit_Leave(object sender, EventArgs e)
        {
            if (InsuranBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((INSURAN)InsuranBindingSource.Current).checkToAmount, InsuranBindingSource);
            }
        }

        private void pREMIUMTextEdit_Leave(object sender, EventArgs e)
        {
            if (InsuranBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((INSURAN)InsuranBindingSource.Current).checkPrem, InsuranBindingSource);
            }
        }

        private void cOMM_PCTTextEdit_Leave(object sender, EventArgs e)
        {
            if (InsuranBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((INSURAN)InsuranBindingSource.Current).checkComm, InsuranBindingSource);
            }
        }

        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text.ToString();
        }

        private void InsuranForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void overlappingRatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string agency = ImageComboBoxEditAgency.EditValue.ToString();
            var load = from c in context.INSURAN where c.YEAR.ToString() == yEARComboBoxEdit.Text && c.AGENCY == agency && c.ITEM_.ToString() == iTEM_TextEdit.Text && c.START_DATE >= Convert.ToDateTime(sTART_DATEDateEdit.Text) && c.END_DATE <= Convert.ToDateTime(eND_DATEDateEdit.Text) && c.START_DATE <= Convert.ToDateTime(eND_DATEDateEdit.Text) && c.END_DATE >= Convert.ToDateTime(sTART_DATEDateEdit.Text) select c;
            if (load.Count() == 1)
                MessageBox.Show("No overlapping rate sheets exist.");
            else
            {
                gridControl2.DataSource = load;
                popupContainerControl1.Show();
            }
        }

      

        public void setReadOnly(bool value)
        {
            iTEM_TextEdit.Properties.ReadOnly = value;
            yEARComboBoxEdit.Properties.ReadOnly = value;
            sTART_DATEDateEdit.Properties.ReadOnly = value;
            ImageComboBoxEditAgency.Properties.ReadOnly = value;
            GridViewInsuran.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = !value;
        }

     

        private void sTART_DATEDateEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void sTART_DATEDateEdit_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(sTART_DATEDateEdit.Text))
                sTART_DATEDateEdit.Text = validCheck.convertDate(sTART_DATEDateEdit.Text);
            else if (string.IsNullOrWhiteSpace(sTART_DATEDateEdit.Text) && !string.IsNullOrWhiteSpace(((INSURAN)InsuranBindingSource.Current).START_DATE.ToString()))
                sTART_DATEDateEdit.Text = validCheck.convertDate(sTART_DATEDateEdit.Text);
            //else if (string.IsNullOrWhiteSpace(sTART_DATEDateEdit.Text) && string.IsNullOrWhiteSpace(((INSURAN)InsuranBindingSource.Current).START_DATE.ToString()))
            //    GridViewInsuran.SetFocusedRowCellValue("START_DATE", "");


           
        }

        private void eND_DATEDateEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void eND_DATEDateEdit_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(eND_DATEDateEdit.Text) && string.IsNullOrWhiteSpace(((INSURAN)InsuranBindingSource.Current).END_DATE.ToString()))
                eND_DATEDateEdit.Text = validCheck.convertDate(eND_DATEDateEdit.Text);
            else if (string.IsNullOrWhiteSpace(eND_DATEDateEdit.Text) && !string.IsNullOrWhiteSpace(((INSURAN)InsuranBindingSource.Current).END_DATE.ToString()))
                eND_DATEDateEdit.Text = validCheck.convertDate(eND_DATEDateEdit.Text);
            else if (string.IsNullOrWhiteSpace(eND_DATEDateEdit.Text) && string.IsNullOrWhiteSpace(((INSURAN)InsuranBindingSource.Current).END_DATE.ToString()))
                ((INSURAN)InsuranBindingSource.Current).END_DATE = null;


        }

        private void GridViewInsuran_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {           

            if (e.Column.FieldName == "START_DATE")
                if (e.Value != null)
                    if (!string.IsNullOrWhiteSpace(e.Value.ToString()))
                        e.DisplayText = validCheck.convertDate(e.Value.ToString());

            if (e.Column.FieldName == "ResDate_Start")
                if (e.Value != null)
                    if (!string.IsNullOrWhiteSpace(e.Value.ToString()))
                        e.DisplayText = validCheck.convertDate(e.Value.ToString());     
            
        }

        private void InsuranForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewInsuran.IsFilterRow(GridViewInsuran.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewInsuran.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewInsuran.GetFocusedDisplayText()))
                value = GridViewInsuran.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.AGENCY like '{0}%'", GridViewInsuran.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "AGENCY"));
                //string query = String.Format("it.{0} like '{1}%'", colName, value);
                var special = context.INSURAN.Where(query);
                if (!string.IsNullOrWhiteSpace(GridViewInsuran.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "START_DATE")))
                {
                    string validDate = GridViewInsuran.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "START_DATE");
                    string values = validCheck.convertDate(validDate);
                    if (!string.IsNullOrWhiteSpace(values))
                    {
                        DateTime startDate = Convert.ToDateTime(values);
                        special = special.Where("it.START_DATE >= @date", new ObjectParameter("date", startDate));
                    }
                }
              

                int count = special.Count();
                if (count > 0)
                {
                    InsuranBindingSource.DataSource = special;
                    GridViewInsuran.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                    GridViewInsuran.FocusedRowHandle = 0;
                    GridViewInsuran.FocusedColumn.FieldName = colName;
                    GridViewInsuran.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewInsuran.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void ImageComboBoxEditAgency_Leave(object sender, System.EventArgs e)
        {
            if (InsuranBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text.ToString())
                {
                    modified = true;
                    labelControl1.Text = DateTime.Today.ToString();
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((INSURAN)InsuranBindingSource.Current).checkAgency, InsuranBindingSource);
            }
        }

        private void InsuranBindingSource_CurrentChanged(object sender, System.EventArgs e)
        {
            if (InsuranBindingSource.Current != null)
            {
                enableNavigator(true);
                
            }
            else
                enableNavigator(false);
        }

        private void ImageComboBoxEditAgency_TextChanged(object sender, System.EventArgs e)
        {
            if (ImageComboBoxEditAgency.EditValue.ToString() == "TARIFF")
            {
                cOMM_FLGCheckEdit.Enabled = true;
                cOMM_PCTTextEdit.Enabled = true;
            }
            else
            {
                cOMM_FLGCheckEdit.Enabled = false;
                cOMM_PCTTextEdit.Enabled = false;

            }
        }
     

    }
}