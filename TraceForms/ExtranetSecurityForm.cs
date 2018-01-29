using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;
using FlexModel;
using DevExpress.XtraEditors.Controls;
using System.Runtime.InteropServices;
using DevExpress.XtraGrid.Columns;
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
using System.Data.Objects;
using System.Data.Entity.Core.Objects.DataClasses;

namespace TraceForms
{
    
    public partial class ExtranetSecurityForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        public bool ignoreLeaveRow = false;
        const string colName = "colUserID";
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public  FlextourEntities context;
        public string defaultAgy;
        
        public ExtranetSecurityForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
            LoadLookups();
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);
            defaultAgy = sys.Settings.DefaultAgency;
        }

        private void setReadOnly(bool value)
        {
            CheckEditAgent.Enabled = !value;
            TextEditUser.Properties.ReadOnly = value;
            ImageComboBoxEditUser.Properties.ReadOnly = value;
            GridViewUsers.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = !value;
        }

        private void LoadLookups()
        {
            setReadOnly(true);
            var agents = from agentRec in context.AGCYLOG where agentRec.AGENCY == defaultAgy orderby agentRec.AGT_NAME ascending select new { agentRec.AGT_NAME };
           
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            foreach (var result in agents)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.AGT_NAME.TrimEnd(), Value = result.AGT_NAME.TrimEnd() };
                ImageComboBoxEditUser.Properties.Items.Add(load);
            }

            hTLCHAINBindingSource.DataSource = context.HTLCHAIN;

            enableNavigator(false);
        }

        void LoadAndBindPermissions(string userID)
        {
            PermissionsBindingSource.DataSource = context.ExtranetPermission.Where(p => p.UserID == userID);
            BindPermissions();
        }

        void BindPermissions()
        {
            GridControlPermissions.DataSource = PermissionsBindingSource;
            GridControlPermissions.RefreshDataSource();
        }

        void enableNavigator(bool value)
        {
            bindingNavigatorMoveNextItem.Enabled = value;
            bindingNavigatorMoveLastItem.Enabled = value;
            bindingNavigatorMoveFirstItem.Enabled = value;
            bindingNavigatorMovePreviousItem.Enabled = value;
            bindingNavigatorDeleteItem.Enabled = value;
            bindingNavigatorSaveItem.Enabled = value;
        }

        private void setValues()
        {
            GridViewUsers.SetFocusedRowCellValue("UserID", string.Empty);
            GridViewUsers.SetFocusedRowCellValue("Password", string.Empty);
            GridViewUsers.SetFocusedRowCellValue("ReadOnly", false);
            GridViewUsers.SetFocusedRowCellValue("Inactive", false);
            GridViewUsers.SetFocusedRowCellValue("IsAgent", false);           
        }

        private bool checkForms(bool prompt)
        {
            //if (!modified && !newRec)
              //  return true;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((ExtranetUser)UsersBindingSource.Current).checkAll, UsersBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, UsersBindingSource, Name, errorProvider1, Cursor, prompt);
            else
                return false;
        }


        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (modified || newRec)
            {
                DialogResult select = DevExpress.XtraEditors.XtraMessageBox.Show("Do you want to confirm these changes?", Text, MessageBoxButtons.YesNoCancel);
                if (select == DialogResult.Cancel)
                    return;
                if (select == DialogResult.Yes)
                    if (!SaveRecord())
                        return;
                if (select == DialogResult.No)
                    if (newRec)
                        RemoveRecord();
                    else
                        RefreshRecord();
            }

            GridViewUsers.ClearColumnsFilter();
            if (UsersBindingSource.Current == null)
            {
                //fake query in order to create a link between the database table and the binding source
                UsersBindingSource.DataSource = from opt in context.ExtranetUser where opt.UserID == "KJM9" select opt;
            }
            CheckEditAgent.Focus();
            GridViewUsers.CloseEditor();
            newRec = true;
            ignoreLeaveRow = true;       //so that when the grid row changes it doesn't try to save again
            UsersBindingSource.AddNew();
            if (GridViewUsers.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                GridViewUsers.FocusedRowHandle = GridViewUsers.RowCount - 1;
            CheckEditAgent.Focus();
            setReadOnly(false);
            ignoreLeaveRow = false;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (UsersBindingSource.Current == null)
                return;
            GridViewUsers.CloseEditor();
            if (XtraMessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ignoreLeaveRow = true;
                RemoveRecord();
                errorProvider1.Clear();
                if (!newRec) 
                    context.SaveChanges();
                ignoreLeaveRow = false;
                modified = false;
                newRec = false;
                setReadOnly(true);
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);
            }
            currentVal = TextEditUser.Text;
          
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

            if (UsersBindingSource.Current != null)     //user is not editing a record and has never clicked Add button
            {
                if (SaveRecord())
                    if (!temp && !modified)
                        context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (ExtranetUser)UsersBindingSource.Current);
            }
              
        }

        private void RefreshRecord()
        {
            if (UsersBindingSource.Current != null)     //user is not editing a record and has never clicked Add button
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (ExtranetUser)UsersBindingSource.Current);
        }

        private void RemoveRecord()
        {
            PermissionsBindingSource.Clear();
            UsersBindingSource.RemoveCurrent();
        }

        private bool SaveRecord()
        {
            if (UsersBindingSource.Current == null)     //user is not editing a record and has never clicked Add button
                return true;

            GridViewUsers.CloseEditor();
            GridViewPermissions.CloseEditor();
            if (GridViewPermissions.UpdateCurrentRow())
            {
                PermissionsBindingSource.EndEdit();
                foreach (ExtranetPermission permission in PermissionsBindingSource)
                {
                    permission.UserID = GetUserID();
                    permission.ProductType = "HTL";
                }
            }
            CheckEditAgent.Focus();
            temp = newRec;
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            if (checkForms(false))
            {
                CheckEditAgent.Focus();
                setReadOnly(true);
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
                return true;
            }
            else
                return false;
        }


        private string GetUserID()
        {
            if (CheckEditAgent.Checked)
                return ImageComboBoxEditUser.Text;
            else
                return TextEditUser.Text;
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool move()
        {
            GridViewUsers.CloseEditor();
            CheckEditAgent.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms(true))
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (ExtranetUser)UsersBindingSource.Current);
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
                UsersBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                UsersBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                UsersBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                UsersBindingSource.MoveLast();
        }

        private void gridViewUsers_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (!ignoreLeaveRow)
            {
                if (UsersBindingSource.Current == null)
                {
                    e.Allow = true;
                    return;
                }

                temp = newRec;
                bool temp2 = modified;
                if (checkForms(true))
                {
                    e.Allow = true;
                    if ((!temp) && temp2)
                        context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (ExtranetUser)UsersBindingSource.Current);

                    setReadOnly(true);
                }
                else
                {
                    if (!temp && !modified)
                        context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (ExtranetUser)UsersBindingSource.Current);

                    e.Allow = false;
                }
            }
        }

     
        void ButtonEdit_QueryPopUp1(object sender, CancelEventArgs e)
        {
            e.Cancel = false;           
        }

        private void checkModified(object sender, EventArgs e)
        {
            modified = true;
        }

        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        private void gridViewUsers_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewUsers.IsFilterRow(e.RowHandle))
                modified = true;
        }

        private void gridViewUsers_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }

        private void ExtranetSecurityForm_FormClosing(object sender, FormClosingEventArgs e)
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
            //    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( State)StateBindingSource.Current);

            //setReadOnly(true);
        }

     
        private void TextEditUser_Leave(object sender, EventArgs e)
        {
            if (UsersBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((ExtranetUser)UsersBindingSource.Current).checkUser, UsersBindingSource);
            }
           
        }

        private void TextEditPassword_Leave(object sender, EventArgs e)
        {
            if (UsersBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((ExtranetUser)UsersBindingSource.Current).checkPassword, UsersBindingSource);
            }

        }

        private void ExtranetSecurityForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewUsers.IsFilterRow(GridViewUsers.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewUsers.FocusedColumn.FieldName;
            string value = String.Empty;
            //if (!string.IsNullOrWhiteSpace(GridViewUsers.GetFocusedDisplayText()))
                value = GridViewUsers.GetFocusedDisplayText();
            //if (!string.IsNullOrWhiteSpace(value))
            //{
                string query = String.Format("it.UserID like '{0}%'", GridViewUsers.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "UserID"));
                var results = context.ExtranetUser.Where(query);

                int count = results.Count();
                if (count > 0)
                {
                    UsersBindingSource.DataSource = results;
                    GridViewUsers.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                    GridViewUsers.FocusedRowHandle = 0;
                    GridViewUsers.FocusedColumn.FieldName = colName;
                }
                else
                {
                    XtraMessageBox.Show("No records in database.");
                    GridViewUsers.ClearColumnsFilter();
                }
            //}
            this.Cursor = Cursors.Default;
        }

        private void UsersBindingSource_CurrentChanged(object sender, System.EventArgs e)
        {
            if (UsersBindingSource.Current != null)
            {
                LoadAndBindPermissions(((ExtranetUser)UsersBindingSource.Current).UserID);
                enableNavigator(true);
            }
            else
            {
                enableNavigator(false);
                PermissionsBindingSource.Clear();
                BindPermissions();
            }
        }

        private void ImageComboBoxEditUser_Leave(object sender, System.EventArgs e)
        {
            if (UsersBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((ExtranetUser)UsersBindingSource.Current).checkUser, UsersBindingSource);
            }
        }

        private void CheckEditAgent_CheckedChanged(object sender, EventArgs e)
        {
            TextEditUser.Visible = !CheckEditAgent.Checked;
            ImageComboBoxEditUser.Visible = CheckEditAgent.Checked;
        }

        private void ButtonAddPermission_Click(object sender, EventArgs e)
        {
            PermissionsBindingSource.AddNew();
            BindPermissions();
            GridViewPermissions.FocusedRowHandle = PermissionsBindingSource.Count - 1;
            modified = true;
        }

        private void ButtonDeletePermission_Click(object sender, EventArgs e)
        {
            if (GridViewPermissions.FocusedRowHandle >= 0)
            {
                ExtranetPermission permission = (ExtranetPermission)GridViewPermissions.GetFocusedRow();
                PermissionsBindingSource.Remove(permission);
                BindPermissions();
                modified = true;
            }
        }

        private void repositoryItemLookUpEditChain_EditValueChanged(object sender, EventArgs e)
        {
            modified = true;
        }

    }

}