using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using FlexModel;
using System.Data.Entity.Core.Objects;
using DevExpress.XtraEditors.Controls;
using System.Linq;
using System.Linq.Dynamic;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System.Runtime.InteropServices;

using System.Data;
using System.Drawing;
using System.Text;

using DevExpress.XtraEditors;
using System.Data.SqlClient;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;

using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views;
using System.Data.OleDb;
using DevExpress.XtraGrid.Views.Card;


namespace TraceForms
{
    
    public partial class OperatorForm : DevExpress.XtraEditors.XtraForm
    {
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        public string currentVal;
        const string colName = "colCODE";
        public FlextourEntities context;
        public bool contactNewRowRec = false;
        public bool firstLoad = false;
        public string globalRptType = string.Empty;
        public string username;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        string _accountingURL;

        public OperatorForm(FlexInterfaces.Core.ICoreSys sys)
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
            _accountingURL = sys.Settings.TourAccountingURL;

            ////////////////

        }


        private void LoadLookups()
        {
            var dept = from deptRec in context.Dept orderby deptRec.Code ascending select new { deptRec.Code, deptRec.Desc };
            gridControlPopup.DataSource = from RptRec in context.RPTTYPE where RptRec.RecipientType == "Operator" select RptRec;
            var count = from countryRec in context.COUNTRY orderby countryRec.CODE ascending select new { countryRec.CODE, countryRec.NAME };
            var cty = from ctyRec in context.CITYCOD orderby ctyRec.CODE ascending select new { ctyRec.CODE, ctyRec.NAME };
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };

            ImageComboBoxEditCountry.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCity.Properties.Items.Add(loadBlank);

            foreach (var result in dept)
            {
                repositoryItemComboBoxDept.Items.Add(result.Code + " " + result.Desc);
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
            setReadOnly(true);
            enableNavigator(false);
        }
        
        private void OperatorForm_Load(object sender, EventArgs e)
        {
            //GridControlAdditionalContacts.DataSource = context.CONTACT;
           
            tourfaxEmailFormatComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            //sendDocsByComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;            
        }

        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        private bool checkForms()
        {
            if (!modified && !newRec)
                return true;
            bool ok1 = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, (( OPERATOR)OperatorBindingSource.Current).checkAll, OperatorBindingSource);
            bool ok2 = validCheck.checkAll(panelControl5.Controls, errorProvider1, (( OPERATOR)OperatorBindingSource.Current).checkAll, OperatorBindingSource);
            bool ok3 = validCheck.checkAll(panelControl2.Controls, errorProvider1, (( OPERATOR)OperatorBindingSource.Current).checkAll, OperatorBindingSource);
            bool ok4 = validCheck.checkAll(panelControl1.Controls, errorProvider1, (( OPERATOR)OperatorBindingSource.Current).checkAll, OperatorBindingSource);

            if (ok1 && ok2 && ok3 && ok4) {
                var ret = validCheck.saveRec(ref modified, true, ref newRec, context, OperatorBindingSource, this.Name, errorProvider1, Cursor);
                if (ret) {
                    AccountingAPI.InvokeForOperator(_accountingURL, ((OPERATOR)OperatorBindingSource.Current).CODE);
                }
                return ret;
            }
            else
                return validCheck.saveRec(ref modified, false, ref newRec, context, OperatorBindingSource, this.Name, errorProvider1, Cursor);
        }
        private void setValues()
        {
            GridViewOper.SetFocusedRowCellValue("CODE", string.Empty);
            GridViewOper.SetFocusedRowCellValue("NAME", string.Empty);
            GridViewOper.SetFocusedRowCellValue("ADDR1", string.Empty);
            GridViewOper.SetFocusedRowCellValue("ADDR2", string.Empty);
            GridViewOper.SetFocusedRowCellValue("ADDR3", string.Empty);
            GridViewOper.SetFocusedRowCellValue("CITY_CODE", string.Empty);
            GridViewOper.SetFocusedRowCellValue("CNTRY_CODE", string.Empty);
            GridViewOper.SetFocusedRowCellValue("PHONE", string.Empty);
            GridViewOper.SetFocusedRowCellValue("MAIL_FAX", "E");
            GridViewOper.SetFocusedRowCellValue("PHONE", string.Empty);
            GridViewOper.SetFocusedRowCellValue("TELEX", string.Empty);
            GridViewOper.SetFocusedRowCellValue("AP", 0);
            GridViewOper.SetFocusedRowCellValue("AR", string.Empty);
            GridViewOper.SetFocusedRowCellValue("RES_EMAIL", string.Empty);
            GridViewOper.SetFocusedRowCellValue("AP_EMAIL", string.Empty);
            GridViewOper.SetFocusedRowCellValue("Due_Days", 0);
            
            GridViewOper.SetFocusedRowCellValue("TourfaxEmailFormat", "txt");
    
        }
    

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (OperatorBindingSource.Current == null)
            {
                OperatorBindingSource.DataSource = from opt in context.OPERATOR where opt.CODE == "KJM9" select opt;               
                OperatorBindingSource.AddNew();
                TextEditCode.Focus();
                setReadOnly(false);
                setValues();
                newRec = true;
                return;
            }
            TextEditCode.Focus();
           //bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewOper.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                errorProvider1.Clear();
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( OPERATOR)OperatorBindingSource.Current);
                OperatorBindingSource.AddNew();
                TextEditCode.Focus();
                setReadOnly(false);
                setValues();
                newRec = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (OperatorBindingSource.Current == null)
                return;
            GridViewOper.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                modified = false;
                newRec = false;

                IEnumerable<CONTACT> contactRecs = from contact in context.CONTACT where contact.LINK_VALUE == TextEditCode.Text select contact;
                foreach (CONTACT rec in contactRecs)
                    context.DeleteObject(rec);

                IEnumerable<RptContact> rptContactRecs = from contact in context.RptContact where contact.Code == TextEditCode.Text select contact;
                foreach (RptContact rec in rptContactRecs)
                    context.DeleteObject(rec);


                OperatorBindingSource.RemoveCurrent();
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
            TextEditCode.Focus();
            currentVal = TextEditCode.Text;
            modified = false;
            newRec = false;
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }
        void setReadOnly(bool value)
        {
            TextEditCode.Properties.ReadOnly = value;
            GridViewOper.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = !(value);
        }

        private void oPERATORBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            TextEditCode.Focus();
            int contactID = 0;
            if (OperatorBindingSource.Current == null)
                return;
            GridViewOper.CloseEditor();
            if (GridViewAdditionalContacts.RowCount > 0)
                contactID = (int)GridViewAdditionalContacts.GetFocusedRowCellValue("ID");


            bool temp = newRec;
            if (checkForms())
            {
                contactNewRowRec = false;
                errorProvider1.Clear();
                setReadOnly(true);
                if (contactID == int.MaxValue)
                {
                    int newID = (int)GridViewAdditionalContacts.GetFocusedRowCellValue("ID");
                    var values1 = from rec in context.RPTTYPE where rec.RecipientType == "Operator" select new { rec.CODE };
                    foreach (var result in values1)
                    {
                        if (globalRptType.Contains(result.CODE))
                        {
                            RptContact lol = new RptContact();
                            lol.Code = TextEditCode.Text;
                            lol.RptType = result.CODE;
                            lol.Contact_ID = newID;
                            context.RptContact.AddObject(lol);
                        }
                    }
                    globalRptType = string.Empty;
                    context.SaveChanges();
                    
                   
                }
                contactNewRowRec = false;
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
            }

            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (OPERATOR)OperatorBindingSource.Current);


        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }



        private bool move()
        {
            if (contactNewRowRec == true)
            {
                MessageBox.Show("Please save or delete the new record being added in the grid on the Contacts tab before attempting to navigate to another record.");

                return false;
            }

            GridViewOper.CloseEditor();
            TextEditCode.Focus();
           //bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                errorProvider1.Clear();

                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( OPERATOR)OperatorBindingSource.Current);

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
                OperatorBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                OperatorBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                OperatorBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                OperatorBindingSource.MoveLast();
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {

            if (contactNewRowRec == true)
            {
                
                MessageBox.Show("Please save or delete the new record being added in the grid on the Contacts tab before attempting to navigate to another record.");
                e.Allow = false;
                return;
            }

            if (OperatorBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (OPERATOR)OperatorBindingSource.Current);

                setReadOnly(true);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (OPERATOR)OperatorBindingSource.Current);

                e.Allow = false;
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewOper.IsFilterRow(e.RowHandle))
            {
                modified = true;
                labelControl1.Text = validCheck.convertDate(DateTime.Today.ToShortDateString());
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
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( OPERATOR)OperatorBindingSource.Current);

            setReadOnly(true);
        }

        private void pHONETextEdit_Leave(object sender, EventArgs e)
        {
            if (OperatorBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = validCheck.convertDate(DateTime.Today.ToShortDateString());
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((OPERATOR)OperatorBindingSource.Current).checkPhone, OperatorBindingSource);
            }
        }

        private void sendDocsByComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (OperatorBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = validCheck.convertDate(DateTime.Today.ToShortDateString());
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((OPERATOR)OperatorBindingSource.Current).checkMailFax, OperatorBindingSource);
            }
        }

        private void tourfaxEmailFormatComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (OperatorBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = validCheck.convertDate(DateTime.Today.ToShortDateString());
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((OPERATOR)OperatorBindingSource.Current).checkTourfaxEmailFormat, OperatorBindingSource);
            }
        }

        private void tELEXTextEdit_Leave(object sender, EventArgs e)
        {
            if (OperatorBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = validCheck.convertDate(DateTime.Today.ToShortDateString());
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((OPERATOR)OperatorBindingSource.Current).checkTelex, OperatorBindingSource);
            }
        }

        private void rES_EMAILTextEdit_Leave(object sender, EventArgs e)
        {
            if (OperatorBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = validCheck.convertDate(DateTime.Today.ToShortDateString());
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((OPERATOR)OperatorBindingSource.Current).checkRES_EMAIL, OperatorBindingSource);
            }
        }

        private void aPTextEdit_Leave(object sender, EventArgs e)
        {
            if (OperatorBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = validCheck.convertDate(DateTime.Today.ToShortDateString());
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((OPERATOR)OperatorBindingSource.Current).checkAP, OperatorBindingSource);
            }
        }

        private void aRTextEdit_Leave(object sender, EventArgs e)
        {
            if (OperatorBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = validCheck.convertDate(DateTime.Today.ToShortDateString());
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((OPERATOR)OperatorBindingSource.Current).checkAR, OperatorBindingSource);
            }
        }

        private void aP_EMAILTextEdit_Leave(object sender, EventArgs e)
        {
            if (OperatorBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = validCheck.convertDate(DateTime.Today.ToShortDateString());
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((OPERATOR)OperatorBindingSource.Current).checkAP_EMAIL, OperatorBindingSource);
            }
        }

        private void due_DaysTextEdit_Leave(object sender, EventArgs e)
        {
            if (OperatorBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = validCheck.convertDate(DateTime.Today.ToShortDateString());
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((OPERATOR)OperatorBindingSource.Current).checkDue_Days, OperatorBindingSource);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string city = ImageComboBoxEditCity.EditValue.ToString();
            string country = ImageComboBoxEditCountry.EditValue.ToString();
            Uri mapUri = new Uri(new Uri("http://www.bing.com/"), "maps/default.aspx?where1=" + aDDR1TextEdit.Text + "%20" + aDDR2TextEdit.Text + "%20" + aDDR3TextEdit.Text + ",%20" + city + ",%20" + country + "&v=2");
            Form map = new TraceForms.WebBrowser(mapUri) { MdiParent = this.ParentForm };
            map.Show();
        }

        private void OperatorForm_FormClosing(object sender, FormClosingEventArgs e)
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

        void enableNavigator(bool value)
        {
            bindingNavigatorMoveNextItem.Enabled = value;
            bindingNavigatorMoveLastItem.Enabled = value;
            bindingNavigatorMoveFirstItem.Enabled = value;
            bindingNavigatorMovePreviousItem.Enabled = value;
        }

        private void oPERATORBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            OPERATOR rec = (OPERATOR)OperatorBindingSource.Current;
           
            if (OperatorBindingSource.Current != null)
            {
                GridControlAdditionalContacts.DataSource = (from contRec in context.CONTACT
                                                            where contRec.LINK_TABLE == "OPERATOR" && contRec.LINK_VALUE == rec.CODE && contRec.RECTYPE == "OPRCONTACT"
                                                            select contRec).Distinct();
                enableNavigator(true);
            }
            else
                enableNavigator(false);

           
        }
       

        private void nAMETextEdit_Leave(object sender, EventArgs e)
        {
            if (OperatorBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = validCheck.convertDate(DateTime.Today.ToShortDateString());
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((OPERATOR)OperatorBindingSource.Current).checkName, OperatorBindingSource);
            }
        }

        private void aDDR1TextEdit_Leave(object sender, EventArgs e)
        {
            if (OperatorBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = validCheck.convertDate(DateTime.Today.ToShortDateString());
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((OPERATOR)OperatorBindingSource.Current).checkADDR1, OperatorBindingSource);
            }
        }

        private void aDDR2TextEdit_Leave(object sender, EventArgs e)
        {
            if (OperatorBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = validCheck.convertDate(DateTime.Today.ToShortDateString());
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((OPERATOR)OperatorBindingSource.Current).checkADDR2, OperatorBindingSource);
            }
        }

        private void aDDR3TextEdit_Leave(object sender, EventArgs e)
        {
            if (OperatorBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = validCheck.convertDate(DateTime.Today.ToShortDateString());
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((OPERATOR)OperatorBindingSource.Current).checkADDR3, OperatorBindingSource);
            }
        }

        private void OperatorForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewOper.IsFilterRow(GridViewOper.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewOper.FocusedColumn.FieldName;
            string value = String.Empty;

            if (!string.IsNullOrWhiteSpace(GridViewOper.GetFocusedDisplayText()))
                value = GridViewOper.GetFocusedDisplayText();

            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.NAME like '{0}%'", GridViewOper.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "NAME"));
                var special = context.OPERATOR.Where(query);
                              
                if (!string.IsNullOrWhiteSpace(GridViewOper.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE")))
                {
                    query = String.Format("it.{0} like '{1}%'", "CODE", GridViewOper.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                    special = special.Where(query);
                }
              
                int count = special.Count();
                if (count > 0)
                {
                    OperatorBindingSource.DataSource = special;
                    GridViewOper.FocusedRowHandle = 0;
                    GridViewOper.FocusedColumn.FieldName = colName;
                    GridViewOper.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewOper.ClearColumnsFilter();
                    //this should be final
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void repositoryItemPopupContainerEditRptType_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {


            e.Value += "," + (gridViewPopup.GetRowCellValue(gridViewPopup.FocusedRowHandle, "CODE").ToString());


            

        }

        private void OkButton_Click(object sender, System.EventArgs e)
        {
            popupContainerControl1.OwnerEdit.ClosePopup();
        }

        private void CancelButton_Click(object sender, System.EventArgs e)
        {
            popupContainerControl1.OwnerEdit.CancelPopup();
        }

        private void gridViewPopup_DoubleClick(object sender, System.EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            DoRowDoubleClick(view, pt);
        }

        private void DoRowDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                popupContainerControl1.OwnerEdit.ClosePopup();
            }
        }

        private void ButtonAddRowContact_Click(object sender, System.EventArgs e)
        {
            if (contactNewRowRec == false)
            {
                if (GridViewAdditionalContacts.RowCount == 0)
                {
                    contactNewRowRec = true;
                    firstLoad = true;
                    GridViewAdditionalContacts.AddNewRow();
                    GridViewAdditionalContacts.SetFocusedRowCellValue("ID", int.MaxValue);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("LINK_TABLE", "OPERATOR");
                    GridViewAdditionalContacts.SetFocusedRowCellValue("LINK_VALUE", TextEditCode.Text);


                    GridViewAdditionalContacts.SetFocusedRowCellValue("NAME", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("DEPT", string.Empty);

                    GridViewAdditionalContacts.SetFocusedRowCellValue("COMM_PREF", string.Empty);

                    GridViewAdditionalContacts.SetFocusedRowCellValue("EMAIL", string.Empty);

                    GridViewAdditionalContacts.SetFocusedRowCellValue("ACTIVE", 1);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("ADDRESS1", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("ADDRESS2", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("ADDRESS3", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("CITY", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("STATE", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("ZIP", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("GMACCTNO", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("GMRECID", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("DEPT_HEAD", false);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("COUNTRY", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("USER_DEC1", 0);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("USER_DEC2", 0);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("USER_INT1", 0);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("USER_INT2", 0);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("USER_TXT1", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("USER_TXT2", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("USER_TXT3", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("USER_TXT4", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("LOGIN_NAME", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("PASSWORD", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("LOGIN_ROLE", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("LOGIN_ACTIVE", false);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("RECTYPE", "OPRCONTACT");
                    GridViewAdditionalContacts.SetFocusedRowCellValue("PARENT_ID", 0);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("TITLE", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("DEAR", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("PHONE", string.Empty);
                    GridViewAdditionalContacts.SetFocusedRowCellValue("FAX", string.Empty);
                    modified = true;
                    return;
                }
                contactNewRowRec = true;
                firstLoad = true;
                GridViewAdditionalContacts.MoveLast();
                GridViewAdditionalContacts.AddNewRow();
                GridViewAdditionalContacts.SetFocusedRowCellValue("ID", int.MaxValue);
                GridViewAdditionalContacts.SetFocusedRowCellValue("LINK_TABLE", "OPERATOR");
                GridViewAdditionalContacts.SetFocusedRowCellValue("LINK_VALUE", TextEditCode.Text);
                GridViewAdditionalContacts.SetFocusedRowCellValue("ACTIVE", 1);
                GridViewAdditionalContacts.SetFocusedRowCellValue("ADDRESS1", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("ADDRESS2", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("ADDRESS3", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("CITY", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("STATE", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("ZIP", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("GMACCTNO", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("GMRECID", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("DEPT_HEAD", false);
                GridViewAdditionalContacts.SetFocusedRowCellValue("COUNTRY", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("USER_DEC1", 0);
                GridViewAdditionalContacts.SetFocusedRowCellValue("USER_DEC2", 0);
                GridViewAdditionalContacts.SetFocusedRowCellValue("USER_INT1", 0);
                GridViewAdditionalContacts.SetFocusedRowCellValue("USER_INT2", 0);
                GridViewAdditionalContacts.SetFocusedRowCellValue("USER_TXT1", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("USER_TXT2", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("USER_TXT3", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("USER_TXT4", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("LOGIN_NAME", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("PASSWORD", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("LOGIN_ROLE", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("LOGIN_ACTIVE", false);
                GridViewAdditionalContacts.SetFocusedRowCellValue("RECTYPE", "OPRCONTACT");
                GridViewAdditionalContacts.SetFocusedRowCellValue("PARENT_ID", 0);
                GridViewAdditionalContacts.SetFocusedRowCellValue("TITLE", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("DEAR", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("PHONE", string.Empty);
                GridViewAdditionalContacts.SetFocusedRowCellValue("FAX", string.Empty);
                modified = true;
            }
            else
                MessageBox.Show("Please save current record before attempting to add another.");
        }

        private void ButtonDelRowContact_Click(object sender, System.EventArgs e)
        {
            int handle = GridViewAdditionalContacts.FocusedRowHandle;
            GridViewAdditionalContacts.DeleteRow(handle);
            OperatorBindingSource.EndEdit();
            context.SaveChanges();
            contactNewRowRec = false;
            modified = false;
        }

        private void ButtonContactSave_Click(object sender, System.EventArgs e)
        {
            GridViewAdditionalContacts.FocusedColumn = GridViewAdditionalContacts.Columns["RECTYPE"];
            if (GridViewAdditionalContacts.UpdateCurrentRow())
            {
                OperatorBindingSource.EndEdit();
                oPERATORBindingNavigatorSaveItem_Click(sender, e);
                contactNewRowRec = false;
                modified = false;
            }
        }

        private void ImageComboBoxEditCity_Leave(object sender, System.EventArgs e)
        {
            if (OperatorBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = validCheck.convertDate(DateTime.Today.ToShortDateString());
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((OPERATOR)OperatorBindingSource.Current).checkCity, OperatorBindingSource);
            }
        }

        private void ImageComboBoxEditCountry_Leave(object sender, System.EventArgs e)
        {
            if (OperatorBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = validCheck.convertDate(DateTime.Today.ToShortDateString());
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((OPERATOR)OperatorBindingSource.Current).checkCountry, OperatorBindingSource);
            }
        }

        private void TextEditCode_Leave(object sender, System.EventArgs e)
        {
            if (OperatorBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl1.Text = validCheck.convertDate(DateTime.Today.ToShortDateString());
                    labelControl2.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((OPERATOR)OperatorBindingSource.Current).checkCode, OperatorBindingSource);
            }
        }

        private void GridViewAdditionalContacts_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "RptType" && e.IsGetData)
            {
                CONTACT conRec = (CONTACT)e.Row;
                int id = conRec.ID;
                string load = String.Empty;
                if (id == int.MaxValue)
                {
                    if (firstLoad == true)
                    {
                        var values = from rec in context.RPTTYPE where rec.RecipientType == "Operator" select new { rec.CODE };
                        foreach (var result in values)
                        {
                            if (!string.IsNullOrWhiteSpace(load))
                                load += "," + result.CODE;
                            else
                                load += result.CODE;
                        }
                        globalRptType = load;
                        firstLoad = false;
                    }
                    else
                    {
                        load = globalRptType;
                    }
                }
                else
                {
                    var val = from rec in context.RptContact where rec.Contact_ID == id && rec.Code == TextEditCode.Text select new { rec.RptType };
                    foreach (var result in val)
                    {
                        if (!string.IsNullOrWhiteSpace(load))
                            load += "," + result.RptType;
                        else
                            load += result.RptType;
                    }
                }
                e.Value = load;
            }
            if (e.Column.FieldName == "RptType" && e.IsSetData)
            {
                CONTACT conRec = (CONTACT)e.Row;
                int id = conRec.ID;
                if (id == int.MaxValue)
                {
                    globalRptType = e.Value.ToString();
                    modified = true;
                }
                else
                {
                    string value = e.Value.ToString();
                    var results = from rptRec in context.RptContact where !value.Contains(rptRec.RptType) && rptRec.Code == TextEditCode.Text && rptRec.Contact_ID == id select rptRec;
                    foreach (var result in results)
                    {
                        context.RptContact.DeleteObject(result);
                    }
                    var val1 = (from rptRec in context.RPTTYPE
                                where value.Contains(rptRec.CODE)
                                select new { rptRec.CODE });
                    foreach (var result1 in val1)
                    {
                        if ((from rptCont in context.RptContact where rptCont.Contact_ID == id && rptCont.Code == TextEditCode.Text && rptCont.RptType == result1.CODE select new { rptCont.Code }).Count() == 0)
                        {
                            RptContact lol = new RptContact();
                            lol.Code = TextEditCode.Text;
                            lol.RptType = result1.CODE;
                            lol.Contact_ID = id;
                            context.RptContact.AddObject(lol);
                        }
                    }
                    context.SaveChanges();
                }
            }
        }

        private void labelControl1_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(labelControl1.Text))
                labelControl1.Text = validCheck.convertDate(labelControl1.Text);
        }

        private void GridViewAdditionalContacts_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            modified = true;
        }

        private void checkEditNoVendorBill_Click(object sender, EventArgs e)
        {
            modified = true;
        }

        private void TextEditTown_Leave(object sender, EventArgs e)
        {
            if (OperatorBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl1.Text = validCheck.convertDate(DateTime.Today.ToShortDateString());
                    labelControl2.Text = username;
                }
            }
        }

        private void TextEditState_Leave(object sender, EventArgs e)
        {
            if (OperatorBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl1.Text = validCheck.convertDate(DateTime.Today.ToShortDateString());
                    labelControl2.Text = username;
                }
            }
        }

        private void TextEditZip_Leave(object sender, EventArgs e)
        {
            if (OperatorBindingSource.Current != null) {
                if (currentVal != ((Control)sender).Text) {
                    modified = true;
                    labelControl1.Text = validCheck.convertDate(DateTime.Today.ToShortDateString());
                    labelControl2.Text = username;
                }
            }
        }

    }
}