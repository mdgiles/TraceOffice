using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using FlexModel;
using System.Data.Entity.Core.Objects;
using DevExpress.XtraEditors.Controls;
using System.Linq;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Xpo;
using System.Linq.Dynamic;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using System.Runtime.InteropServices;
namespace TraceForms
{
    public partial class CommLevelForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        public string table;
        public FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public CommLevelForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
            cbEdit_Type.Focus();
            modified = false;           
        }

        public void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);
        }

        private void gvCommissions_BeforeLeaveRow(object sender, RowAllowEventArgs e)
        {
            try
            {
                ColumnView view = sender as ColumnView;
                GridColumn col_CommPct = view.Columns["Comm_Pct"];
                var CommPct = view.GetRowCellValue(e.RowHandle, col_CommPct);
                double dblCommPct = Convert.ToDouble(CommPct);

                if ((dblCommPct <= 0 || dblCommPct >= 100) && newRec == true)
                {                    
                    view.SetColumnError(col_CommPct, "Please fix errors");                    
                    return;
                }
                GridColumn colDescription = view.Columns["Description"];
                string strDesc = view.GetFocusedRowCellDisplayText(colDescription);
                if (string.IsNullOrWhiteSpace(strDesc))
                {
                    view.SetColumnError(colDescription, "Description cannot be blank in a row.");                   
                    return;
                }
                if (context.CommLevel.Count() == 0)
                {
                    e.Allow = true;
                    return;
                }
                if (modified == true)
                {
                    DialogResult select = DevExpress.XtraEditors.XtraMessageBox.Show("Do you wish to save the changes you have made?", "Records changed!", MessageBoxButtons.YesNo);
                    if (select == System.Windows.Forms.DialogResult.Yes)
                    {
                        saveChanges(view);
                        modified = false;
                    }
                    else
                    {
                        int rowHandle = view.FocusedRowHandle;
                        object DataRow = view.GetRow(rowHandle);
                        context.Refresh(RefreshMode.StoreWins, DataRow);
                        modified = false;
                    }
                }
                e.Allow = true;                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gvCommissions_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            modified = true;
        }

        private void gvCommissions_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }

        private void gvMarkups_BeforeLeaveRow(object sender, RowAllowEventArgs e)
        {
            try
            {                
                ColumnView view = sender as ColumnView;
                GridColumn col_CommPct = view.Columns["Comm_Pct"];
                var CommPct = view.GetRowCellValue(e.RowHandle, col_CommPct);            
                double dblCommPct = Convert.ToDouble(CommPct);
                                
                if ((dblCommPct <= 0 || dblCommPct >=100) && newRec == true)
                {
                    view.SetColumnError(col_CommPct, "Please fix errors");
                   
                    return;
                }
                GridColumn colDescription = view.Columns["Description"];
                string strDesc = view.GetFocusedRowCellDisplayText(colDescription);
                if (string.IsNullOrWhiteSpace(strDesc))
                {
                    view.SetColumnError(colDescription, "Description cannot be blank in a row.");
                   
                    return;
                }
                if (context.CommLevel.Count() == 0)
                {
                    e.Allow = true;
                    return;
                }
                if (modified == true)
                {
                    DialogResult select = DevExpress.XtraEditors.XtraMessageBox.Show("Do you wish to save the changes you have made?", "Records changed!", MessageBoxButtons.YesNo);
                    if (select == System.Windows.Forms.DialogResult.Yes)
                    {
                        saveChanges(view);
                        modified = false;
                    }
                    else
                    {
                        int row = view.FocusedRowHandle;
                        object DataRow = view.GetRow(row);
                        context.Refresh(RefreshMode.StoreWins, DataRow);
                        modified = false;
                    }

                }
                e.Allow = true;                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gvMarkups_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            modified = true;
        }

        private void gvMarkups_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }

        private void CommLevelForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void cbEdit_Type_enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        private void cbEdit_Type_Leave(object sender, EventArgs e)
        {
            try
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;               
            }
            catch{}
            if (!"PKG,HTL,AIR,CAR,OPT,AGY,CRU,INS".Contains(cbEdit_Type.Text))
            {
                MessageBox.Show("Please enter a valid record type. \n (PKG, HTL, AIR, CAR, OPT, INS, AGY, CRU)");
                cbEdit_Type.Focus();
            }
        }

        private void repositoryItemPopupContEdit_Query_Comm_QueryResultValue(object sender, QueryResultValueEventArgs e)
        {
            e.Value = memoEdit_Comm.Text;
            string query = memoEdit_Comm.Text;
            
            if (isValidQuery(query) == false)
            {
                MessageBox.Show("Please enter a valid query!");
                return;
            }
            memoEdit_Comm.Text = "";   
        }

        private bool isValidQuery(string sqlstring)
        {
                                  
            if (string.IsNullOrEmpty(sqlstring) == true)
                return true;
            try
            {
                List<string> result = context.ExecuteStoreQuery<string>(sqlstring).ToList();
                return true;
            }

            catch (Exception ex)
            {
               return false ;
            }
        }

        private void repositoryItemPopupContEdit_Query_MU_QueryResultValue(object sender, QueryResultValueEventArgs e)
        {
            e.Value = memoEdit_MU.Text;
            string query = memoEdit_MU.Text;

            if (isValidQuery(query) == false)
            {
                MessageBox.Show("Please enter a valid query!");
                return;
            }
            memoEdit_MU.Text = "";
        }    

        private void grdQueryPopOk_Comm_Click(object sender, EventArgs e)
        {
            popupContainer_Comm.OwnerEdit.ClosePopup();
            
        }

        private void grdQueryPopCancel_Comm_Click(object sender, EventArgs e)
        {
            popupContainer_Comm.OwnerEdit.CancelPopup();

        }

        private void grdQueryPopHelp_Comm_Click(object sender, EventArgs e)
        {

        }

        private void grdQueryPopOk_MU_Click(object sender, EventArgs e)
        {

            popupContainer_MU.OwnerEdit.ClosePopup();
        }

        private void grdQueryPopCancel_MU_Click(object sender, EventArgs e)
        {
            popupContainer_MU.OwnerEdit.CancelPopup();
        }

        private void grdQueryPopHelp_MU_Click(object sender, EventArgs e)
        {

        }

        private void repositoryItemPopupContEdit_Query_Comm_Click(object sender, EventArgs e)
        {
            memoEdit_Comm.Text = gvCommissions.GetFocusedRowCellDisplayText("Query");
        }

        private void repositoryItemPopupContEdit_Query_MU_Click(object sender, EventArgs e)
        {
            memoEdit_MU.Text = gvMarkups.GetFocusedRowCellDisplayText("Query");
        }

        private void grdCommSelAdd_Click(object sender, EventArgs e)
        {
            if (newRec == false)
            {
                if (gvCommissions.RowCount == 0)
                {
                    gvCommissions.AddNewRow();                    
                    gvCommissions.SetFocusedRowCellValue("Type", cbEdit_Type.Text);
                    gvCommissions.SetFocusedRowCellValue("RecType", "C");
                    gvCommissions.SetFocusedRowCellValue("Position", 1);
                    gvCommissions.SetFocusedRowCellValue("Link_Table", "");
                    gvCommissions.SetFocusedRowCellValue("Link_Column", "");
                    gvCommissions.SetFocusedRowCellValue("Link_Rectype", "");
                    gvCommissions.SetFocusedRowCellValue("Lookup_Table", "");
                    gvCommissions.SetFocusedRowCellValue("Lookup_Column", "");
                    gvCommissions.SetFocusedRowCellValue("Query", "");
                    gvCommissions.SetFocusedRowCellValue("Description", "");
                    newRec = true;
                    return;
                }

                ColumnView commView = gvCommissions;
                GridColumn colCommPct_Comm = commView.Columns["Comm_Pct"];
                var commPct_Comm = commView.GetFocusedRowCellValue(colCommPct_Comm);
                double dblCommPct_Comm = Convert.ToDouble(commPct_Comm);

                if (dblCommPct_Comm <= -100 || dblCommPct_Comm >= 100)
                {
                    MessageBox.Show("Default pct cannot be blank in a row or greater than 100.");                    
                    return;
                }


                GridColumn colDesc_Comm = commView.Columns["Description"];
                string strDesc_Comm = commView.GetFocusedRowCellDisplayText(colDesc_Comm);
                if (string.IsNullOrWhiteSpace(strDesc_Comm))
                {
                    MessageBox.Show("Description cannot be blank in a row.");
                    return;
                }
                gvCommissions.MoveLast();
                int position_Comm = (int)gvCommissions.GetFocusedRowCellValue("Position");
                gvCommissions.AddNewRow();                
                gvCommissions.SetFocusedRowCellValue("Type", cbEdit_Type.Text);
                gvCommissions.SetFocusedRowCellValue("RecType", "C");
                gvCommissions.SetFocusedRowCellValue("Position", position_Comm + 1);
                gvCommissions.SetFocusedRowCellValue("Link_Table", "");
                gvCommissions.SetFocusedRowCellValue("Link_Column", "");
                gvCommissions.SetFocusedRowCellValue("Link_Rectype", "");
                gvCommissions.SetFocusedRowCellValue("Lookup_Table", "");
                gvCommissions.SetFocusedRowCellValue("Lookup_Column", "");
                gvCommissions.SetFocusedRowCellValue("Query", "");
                gvCommissions.SetFocusedRowCellValue("Description", "");
                newRec = true;
            }
            else
                MessageBox.Show("Please save current record before attempting to enter another.");            
        }

        private void grdCommSelDel_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = (int)gvCommissions.GetFocusedRowCellValue("ID");
                var comprod2 = from commRec in context.COMPROD2 where commRec.CommLevel_ID_Product == ID || commRec.CommLevel_ID_Agency == ID select commRec;               
                if (comprod2.Count() > 0)
                {
                    string message = String.Format("This rule is presently being used by {0} commission record(s) in Comprod2. \n Do you wish to remove all references to this rule?", comprod2.Count());
                    DialogResult select = DevExpress.XtraEditors.XtraMessageBox.Show(message,"Warning!",  MessageBoxButtons.YesNo);
                    if (select == System.Windows.Forms.DialogResult.Yes)
                    {
                        //delete from comprod2
                        foreach (var result in comprod2)
                        {
                            context.DeleteObject(result);
                        }
                    }
                    else
                        return;                    
                }

                gvCommissions.ClearColumnErrors();
                int rowHandle = gvCommissions.FocusedRowHandle;
                gvCommissions.DeleteRow(rowHandle);
                CommLevelBindingSource.EndEdit();
                validCheck.reorderPositions(this.gvCommissions, "Deletion");

                context.SaveChanges();
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);
                newRec = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }

        private void SaveChangesComm_Click(object sender, EventArgs e)
        {
            saveChanges(gvCommissions);
        }
       
        private void grdMUReqAdd_Click(object sender, EventArgs e)
        {
            if (newRec == false)
            {
                if (gvMarkups.RowCount == 0)
                {
                    gvMarkups.AddNewRow();                   
                    gvMarkups.SetFocusedRowCellValue("Type", cbEdit_Type.Text);
                    gvMarkups.SetFocusedRowCellValue("RecType", "M");
                    gvMarkups.SetFocusedRowCellValue("Position", 1);
                    gvMarkups.SetFocusedRowCellValue("Link_Table", "");
                    gvMarkups.SetFocusedRowCellValue("Link_Column", "");
                    gvMarkups.SetFocusedRowCellValue("Link_Rectype", "");
                    gvMarkups.SetFocusedRowCellValue("Lookup_Table", "");
                    gvMarkups.SetFocusedRowCellValue("Lookup_Column", "");
                    gvMarkups.SetFocusedRowCellValue("Query", "");
                    gvMarkups.SetFocusedRowCellValue("Description", "");
                    newRec = true;
                    return;
                }

                ColumnView markupsView = gvMarkups;
                GridColumn colCommPct_MU = markupsView.Columns["Comm_Pct"];
                var commPct_MU = markupsView.GetFocusedRowCellValue(colCommPct_MU);
                double dblCommPct_MU = Convert.ToDouble(commPct_MU);

                if (dblCommPct_MU <= -100 || dblCommPct_MU >= 100)
                {
                    MessageBox.Show("Default pct cannot be blank in a row or greater than 100.");
                    return;
                }

                GridColumn colDesc_MU = markupsView.Columns["Description"];
                string desc_MU = markupsView.GetFocusedRowCellDisplayText(colDesc_MU);
                if (string.IsNullOrWhiteSpace(desc_MU))
                {
                    MessageBox.Show("Description cannot be blank in a row.");
                    return;
                }

                gvMarkups.MoveLast();
                int positionMU = (int)gvMarkups.GetFocusedRowCellValue("Position");
                gvMarkups.AddNewRow();               
                gvMarkups.SetFocusedRowCellValue("Type", cbEdit_Type.Text);
                gvMarkups.SetFocusedRowCellValue("RecType", "M");
                gvMarkups.SetFocusedRowCellValue("Position", positionMU + 1);
                gvMarkups.SetFocusedRowCellValue("Link_Table", "");
                gvMarkups.SetFocusedRowCellValue("Link_Column", "");
                gvMarkups.SetFocusedRowCellValue("Link_Rectype", "");
                gvMarkups.SetFocusedRowCellValue("Lookup_Table", "");
                gvMarkups.SetFocusedRowCellValue("Lookup_Column", "");
                gvMarkups.SetFocusedRowCellValue("Query", "");
                gvMarkups.SetFocusedRowCellValue("Description", "");
                newRec = true;
            }
            else
                MessageBox.Show("Please save current record before attempting to add another.");
        }

        private void grdMUReqDel_Click(object sender, EventArgs e)
        {
            try
            {
                int ID_MU = (int)gvMarkups.GetFocusedRowCellValue("ID");
                var comprod2 = from commRec in context.COMPROD2 where commRec.CommLevel_ID_Product == ID_MU || commRec.CommLevel_ID_Agency == ID_MU select commRec;
                if (comprod2.Count() > 0)
                {
                    string message = String.Format("This rule is presently being used by {0} commission record(s) in Comprod2. \n Do you wish to remove all references to this rule?", comprod2.Count());
                    DialogResult select = DevExpress.XtraEditors.XtraMessageBox.Show(message, "Warning!", MessageBoxButtons.YesNo);
                    if (select == System.Windows.Forms.DialogResult.Yes)
                    {
                        //delete from comprod2
                        foreach (var result in comprod2)
                        {
                            context.DeleteObject(result);
                        }
                    }
                    else
                        return;
                }
                int rowHandle = gvMarkups.FocusedRowHandle;
                gvMarkups.DeleteRow(rowHandle);
                CommLevelBindingSource.EndEdit();
                validCheck.reorderPositions(this.gvMarkups, "Deletion");
                context.SaveChanges();
                newRec = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gvCommissions_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            try
            {
                ColumnView view = sender as ColumnView;
                GridColumn colComm_Pct = view.Columns["Comm_Pct"];
                GridColumn colDescription = view.Columns["Description"];
                GridColumn colLink_Table = view.Columns["Link_Table"];
                GridColumn colLink_Column = view.Columns["Link_Column"];              
                var CommPct_Comm = view.GetRowCellValue(e.RowHandle, colComm_Pct);
                double dblCommPct_Comm = Convert.ToDouble(CommPct_Comm);
                string strDesc_Comm = view.GetRowCellDisplayText(e.RowHandle, colDescription);
                string strLinkTable_Comm = view.GetRowCellDisplayText(e.RowHandle, colLink_Table);
                string strLinkCol_Comm = view.GetRowCellDisplayText(e.RowHandle, colLink_Column);                

                if (string.IsNullOrWhiteSpace(strDesc_Comm))
                {
                    DialogResult result = MessageBox.Show("Description cannot be blank in a row.  If you are attempting to delete, select Yes.  Otherwise, select No to correct the problem.", "Warning", MessageBoxButtons.YesNo);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        e.Valid = true;
                        int handle = gvCommissions.FocusedRowHandle;
                        gvCommissions.DeleteRow(handle);
                        CommLevelBindingSource.EndEdit();
                        context.SaveChanges();
                        newRec = false;
                        return;
                    }
                    else
                    {
                        e.Valid = false;
                        return;
                    }
                }

                if (dblCommPct_Comm <= -100 || dblCommPct_Comm >= 100)
                {
                    DialogResult result = MessageBox.Show("Default pct cannot be blank in a row or greater than 100.  If you are attempting to delete, select Yes.  Otherwise, select No to correct the problem.", "Warning", MessageBoxButtons.YesNo);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {                      
                        e.Valid = true;
                        int handle = gvCommissions.FocusedRowHandle;
                        gvCommissions.DeleteRow(handle);
                        CommLevelBindingSource.EndEdit();
                        context.SaveChanges();
                        newRec = false;
                        return;
                    }
                    else
                    {
                        e.Valid = false;
                        return;
                    }                                      
                }

                if (string.IsNullOrWhiteSpace(strLinkTable_Comm))
                {
                    DialogResult result = MessageBox.Show("Link table cannot be blank in a row.  If you are attempting to delete, select Yes.  Otherwise, select No to correct the problem.", "Warning", MessageBoxButtons.YesNo);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        e.Valid = true;
                        int handle = gvCommissions.FocusedRowHandle;
                        gvCommissions.DeleteRow(handle);
                        CommLevelBindingSource.EndEdit();
                        context.SaveChanges();
                        newRec = false;
                        return;
                    }
                    else
                    {
                        e.Valid = false;
                        return;
                    }
                }

                if (string.IsNullOrWhiteSpace(strLinkCol_Comm))
                {
                    DialogResult result = MessageBox.Show("Link column cannot be blank in a row.  If you are attempting to delete, select Yes.  Otherwise, select No to correct the problem.", "Warning", MessageBoxButtons.YesNo);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        e.Valid = true;
                        int handle = gvCommissions.FocusedRowHandle;
                        gvCommissions.DeleteRow(handle);
                        CommLevelBindingSource.EndEdit();
                        context.SaveChanges();
                        newRec = false;
                        return;
                    }
                    else
                    {
                        e.Valid = false;
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          
        }

        private void gvMarkups_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            try
            {
                ColumnView view = sender as ColumnView;
                GridColumn colComm_Pct = view.Columns["Comm_Pct"];
                GridColumn colDescription = view.Columns["Description"];
                GridColumn colLink_Table = view.Columns["Link_Table"];
                GridColumn colLink_Column = view.Columns["Link_Column"];
                var Comm_Pct = view.GetRowCellValue(e.RowHandle, colComm_Pct);
                double dblComm_Pct = Convert.ToDouble(Comm_Pct);
                string Description = view.GetRowCellDisplayText(e.RowHandle, colDescription);
                string Link_Table = view.GetRowCellDisplayText(e.RowHandle, colLink_Table);
                string Link_Column = view.GetRowCellDisplayText(e.RowHandle, colLink_Column);

                if (string.IsNullOrWhiteSpace(Description))
                {
                    DialogResult result = MessageBox.Show("Description cannot be blank in a row.  If you are attempting to delete, select Yes.  Otherwise, select No to correct the problem.", "Warning", MessageBoxButtons.YesNo);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        e.Valid = true;
                        int handle = gvCommissions.FocusedRowHandle;
                        gvMarkups.DeleteRow(handle);
                        CommLevelBindingSource.EndEdit();
                        context.SaveChanges();
                        newRec = false;
                        return;
                    }
                    else
                    {
                        e.Valid = false;
                        return;
                    }
                }

                if (dblComm_Pct <= -100 || dblComm_Pct >= 100)
                {
                    DialogResult result = MessageBox.Show("Default pct cannot be blank in a row or greater than 100.  If you are attempting to delete, select Yes.  Otherwise, select No to correct the problem.", "Warning", MessageBoxButtons.YesNo);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        e.Valid = true;
                        int handle = gvMarkups.FocusedRowHandle;
                        gvMarkups.DeleteRow(handle);
                        CommLevelBindingSource.EndEdit();
                        context.SaveChanges();
                        newRec = false;
                        return;
                    }
                    else
                    {
                        e.Valid = false;
                        return;
                    }
                }

                if (string.IsNullOrWhiteSpace(Link_Table))
                {
                    DialogResult result = MessageBox.Show("Link table cannot be blank in a row.  If you are attempting to delete, select Yes.  Otherwise, select No to correct the problem.", "Warning", MessageBoxButtons.YesNo);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        e.Valid = true;
                        int handle = gvCommissions.FocusedRowHandle;
                        gvMarkups.DeleteRow(handle);
                        CommLevelBindingSource.EndEdit();
                        context.SaveChanges();
                        newRec = false;
                        return;
                    }
                    else
                    {
                        e.Valid = false;
                        return;
                    }
                }

                if (string.IsNullOrWhiteSpace(Link_Column))
                {
                    DialogResult result = MessageBox.Show("Link column cannot be blank in a row.  If you are attempting to delete, select Yes.  Otherwise, select No to correct the problem.", "Warning", MessageBoxButtons.YesNo);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        e.Valid = true;
                        int handle = gvCommissions.FocusedRowHandle;
                        gvMarkups.DeleteRow(handle);
                        CommLevelBindingSource.EndEdit();
                        context.SaveChanges();
                        newRec = false;
                        return;
                    }
                    else
                    {
                        e.Valid = false;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblMoveRec_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblMoveRec_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

         
           
        private void cbEdit_Type_TextChanged(object sender, EventArgs e)
        {
            try
            {               
                if (cbEdit_Type.Text == "OPT")
                {
                    table = "COMP";                  
                    gridControlCommissions.DataSource = (from commRecCommiss in context.CommLevel where commRecCommiss.Type == "OPT" && commRecCommiss.RecType == "C" orderby commRecCommiss.Position ascending select commRecCommiss);

                    gridControlMarkups.DataSource = (from commRecMarkup in context.CommLevel where commRecMarkup.Type == "OPT" && commRecMarkup.RecType == "M" orderby commRecMarkup.Position ascending select commRecMarkup);
                    repositoryItemCB_LookUpTable_Comm.Items.Clear();
                    repositoryItemCB_LookUpTable_MU.Items.Clear();
                    repositoryItemCB_LinkTable_Comm.Items.Clear();
                    repositoryItemCB_LinkTable_MU.Items.Clear();
                    repositoryItemCB_LookUpTable_Comm.Items.Add("CITYCOD");
                    repositoryItemCB_LookUpTable_Comm.Items.Add("COUNTRY");
                    repositoryItemCB_LookUpTable_Comm.Items.Add("REGION");
                    repositoryItemCB_LookUpTable_Comm.Items.Add("OPERATOR");
                    repositoryItemCB_LookUpTable_Comm.Items.Add("LOOKUP");
                    repositoryItemCB_LookUpTable_Comm.Items.Add("SERVTYPE");
                    repositoryItemCB_LookUpTable_MU.Items.Add("CITYCOD");
                    repositoryItemCB_LookUpTable_MU.Items.Add("COUNTRY");
                    repositoryItemCB_LookUpTable_MU.Items.Add("REGION");
                    repositoryItemCB_LookUpTable_MU.Items.Add("OPERATOR");
                    repositoryItemCB_LookUpTable_MU.Items.Add("LOOKUP");
                    repositoryItemCB_LookUpTable_MU.Items.Add("SERVTYPE");
                    repositoryItemCB_LinkTable_Comm.Items.Add("COMP");
                    repositoryItemCB_LinkTable_Comm.Items.Add("DETAIL");
                    repositoryItemCB_LinkTable_MU.Items.Add("COMP");
                    repositoryItemCB_LinkTable_MU.Items.Add("DETAIL");
                }
                if (cbEdit_Type.Text == "PKG")
                {
                    table = "PACK";                     
                    gridControlCommissions.DataSource = (from commRecCommiss in context.CommLevel where commRecCommiss.Type == "PKG" && commRecCommiss.RecType == "C" orderby commRecCommiss.Position ascending select commRecCommiss);

                    gridControlMarkups.DataSource = (from commRecMarkups in context.CommLevel where commRecMarkups.Type == "PKG" && commRecMarkups.RecType == "M" orderby commRecMarkups.Position ascending select commRecMarkups);
                    repositoryItemCB_LinkTable_Comm.Items.Clear();
                    repositoryItemCB_LookUpTable_Comm.Items.Clear();
                    repositoryItemCB_LookUpTable_MU.Items.Clear();
                    repositoryItemCB_LinkTable_MU.Items.Clear();
                    repositoryItemCB_LookUpTable_Comm.Items.Add("CITYCOD");
                    repositoryItemCB_LookUpTable_Comm.Items.Add("COUNTRY");
                    repositoryItemCB_LookUpTable_Comm.Items.Add("REGION");
                    repositoryItemCB_LookUpTable_Comm.Items.Add("OPERATOR");
                    repositoryItemCB_LookUpTable_Comm.Items.Add("LOOKUP");
                    repositoryItemCB_LookUpTable_Comm.Items.Add("PACKTYPE");
                    repositoryItemCB_LookUpTable_MU.Items.Add("CITYCOD");
                    repositoryItemCB_LookUpTable_MU.Items.Add("COUNTRY");
                    repositoryItemCB_LookUpTable_MU.Items.Add("REGION");
                    repositoryItemCB_LookUpTable_MU.Items.Add("OPERATOR");
                    repositoryItemCB_LookUpTable_MU.Items.Add("LOOKUP");
                    repositoryItemCB_LookUpTable_MU.Items.Add("PACKTYPE");
                    repositoryItemCB_LinkTable_Comm.Items.Add("PACK");
                    repositoryItemCB_LinkTable_Comm.Items.Add("DETAIL");
                    repositoryItemCB_LinkTable_MU.Items.Add("PACK");
                    repositoryItemCB_LinkTable_MU.Items.Add("DETAIL");
                }
                if (cbEdit_Type.Text == "HTL")
                {
                    table = "HOTEL";                   
                    gridControlCommissions.DataSource = (from commRecCommiss in context.CommLevel where commRecCommiss.Type == "HTL" && commRecCommiss.RecType == "C" orderby commRecCommiss.Position ascending select commRecCommiss);

                    gridControlMarkups.DataSource = (from commRecMarkups in context.CommLevel where commRecMarkups.Type == "HTL" && commRecMarkups.RecType == "M" orderby commRecMarkups.Position ascending select commRecMarkups);
                    repositoryItemCB_LinkTable_Comm.Items.Clear();
                    repositoryItemCB_LookUpTable_Comm.Items.Clear();
                    repositoryItemCB_LookUpTable_MU.Items.Clear();
                    repositoryItemCB_LinkTable_MU.Items.Clear();
                    repositoryItemCB_LookUpTable_Comm.Items.Add("CITYCOD");
                    repositoryItemCB_LookUpTable_Comm.Items.Add("COUNTRY");
                    repositoryItemCB_LookUpTable_Comm.Items.Add("REGION");
                    repositoryItemCB_LookUpTable_Comm.Items.Add("OPERATOR");
                    repositoryItemCB_LookUpTable_Comm.Items.Add("LOOKUP");
                    repositoryItemCB_LookUpTable_MU.Items.Add("CITYCOD");
                    repositoryItemCB_LookUpTable_MU.Items.Add("COUNTRY");
                    repositoryItemCB_LookUpTable_MU.Items.Add("REGION");
                    repositoryItemCB_LookUpTable_MU.Items.Add("OPERATOR");
                    repositoryItemCB_LookUpTable_MU.Items.Add("LOOKUP");
                    repositoryItemCB_LinkTable_Comm.Items.Add("HOTEL");
                    repositoryItemCB_LinkTable_Comm.Items.Add("DETAIL");
                    repositoryItemCB_LinkTable_MU.Items.Add("HOTEL");
                    repositoryItemCB_LinkTable_MU.Items.Add("DETAIL");
                }
                if (cbEdit_Type.Text == "CAR")
                {
                    table = "CARINFO";
                   
                    gridControlCommissions.DataSource = (from commRecCommiss in context.CommLevel where commRecCommiss.Type == "CAR" && commRecCommiss.RecType == "C" orderby commRecCommiss.Position ascending select commRecCommiss);

                    gridControlMarkups.DataSource = (from commRecMarkups in context.CommLevel where commRecMarkups.Type == "CAR" && commRecMarkups.RecType == "M" orderby commRecMarkups.Position ascending select commRecMarkups);
                    repositoryItemCB_LinkTable_Comm.Items.Clear();
                    repositoryItemCB_LookUpTable_Comm.Items.Clear();
                    repositoryItemCB_LookUpTable_MU.Items.Clear();
                    repositoryItemCB_LinkTable_MU.Items.Clear();
                    repositoryItemCB_LookUpTable_Comm.Items.Add("CITYCOD");
                    repositoryItemCB_LookUpTable_Comm.Items.Add("COUNTRY");
                    repositoryItemCB_LookUpTable_Comm.Items.Add("REGION");
                    repositoryItemCB_LookUpTable_Comm.Items.Add("LOOKUP");
                    repositoryItemCB_LookUpTable_MU.Items.Add("CITYCOD");
                    repositoryItemCB_LookUpTable_MU.Items.Add("COUNTRY");
                    repositoryItemCB_LookUpTable_MU.Items.Add("REGION");
                    repositoryItemCB_LookUpTable_MU.Items.Add("LOOKUP");
                    repositoryItemCB_LinkTable_Comm.Items.Add("CARINFO");
                    repositoryItemCB_LinkTable_Comm.Items.Add("DETAIL");
                    repositoryItemCB_LinkTable_MU.Items.Add("CARINFO");
                    repositoryItemCB_LinkTable_MU.Items.Add("DETAIL");

                }
                if (cbEdit_Type.Text == "AIR")
                {
                    table = "AIR";                   
                    gridControlCommissions.DataSource = (from commRecCommiss in context.CommLevel where commRecCommiss.Type == "AIR" && commRecCommiss.RecType == "C" orderby commRecCommiss.Position ascending select commRecCommiss);

                    gridControlMarkups.DataSource = (from commRecMarkups in context.CommLevel where commRecMarkups.Type == "AIR" && commRecMarkups.RecType == "M" orderby commRecMarkups.Position ascending select commRecMarkups);
                    repositoryItemCB_LinkTable_Comm.Items.Clear();
                    repositoryItemCB_LookUpTable_Comm.Items.Clear();
                    repositoryItemCB_LookUpTable_MU.Items.Clear();
                    repositoryItemCB_LinkTable_MU.Items.Clear();
                    repositoryItemCB_LookUpTable_Comm.Items.Add("CITYCOD");
                    repositoryItemCB_LookUpTable_Comm.Items.Add("COUNTRY");
                    repositoryItemCB_LookUpTable_Comm.Items.Add("REGION");
                    repositoryItemCB_LookUpTable_Comm.Items.Add("LOOKUP");
                    repositoryItemCB_LookUpTable_MU.Items.Add("CITYCOD");
                    repositoryItemCB_LookUpTable_MU.Items.Add("COUNTRY");
                    repositoryItemCB_LookUpTable_MU.Items.Add("REGION");
                    repositoryItemCB_LookUpTable_MU.Items.Add("LOOKUP");
                    repositoryItemCB_LinkTable_Comm.Items.Add("AIR");
                    repositoryItemCB_LinkTable_Comm.Items.Add("DETAIL");
                    repositoryItemCB_LinkTable_MU.Items.Add("AIR");
                    repositoryItemCB_LinkTable_MU.Items.Add("DETAIL");
                }
                if (cbEdit_Type.Text == "CRU")
                {
                    table = "CRU";                  
                    gridControlCommissions.DataSource = (from commRecCommiss in context.CommLevel where commRecCommiss.Type == "CRU" && commRecCommiss.RecType == "C" orderby commRecCommiss.Position ascending select commRecCommiss);

                    gridControlMarkups.DataSource = (from commRecMarkups in context.CommLevel where commRecMarkups.Type == "CRU" && commRecMarkups.RecType == "M" orderby commRecMarkups.Position ascending select commRecMarkups);
                    repositoryItemCB_LinkTable_Comm.Items.Clear();
                    repositoryItemCB_LookUpTable_Comm.Items.Clear();
                    repositoryItemCB_LookUpTable_MU.Items.Clear();
                    repositoryItemCB_LinkTable_MU.Items.Clear();
                    repositoryItemCB_LookUpTable_Comm.Items.Add("CITYCOD");
                    repositoryItemCB_LookUpTable_Comm.Items.Add("COUNTRY");
                    repositoryItemCB_LookUpTable_Comm.Items.Add("REGION");
                    repositoryItemCB_LookUpTable_Comm.Items.Add("LOOKUP");
                    repositoryItemCB_LookUpTable_MU.Items.Add("CITYCOD");
                    repositoryItemCB_LookUpTable_MU.Items.Add("COUNTRY");
                    repositoryItemCB_LookUpTable_MU.Items.Add("REGION");
                    repositoryItemCB_LookUpTable_MU.Items.Add("LOOKUP");
                    repositoryItemCB_LinkTable_Comm.Items.Add("CRU");
                    repositoryItemCB_LinkTable_Comm.Items.Add("DETAIL");
                    repositoryItemCB_LinkTable_MU.Items.Add("CRU");
                    repositoryItemCB_LinkTable_MU.Items.Add("DETAIL");
                }
                if (cbEdit_Type.Text == "INS")
                {
                    table = "INSURAN";
                    
                    gridControlCommissions.DataSource = (from commRecCommiss in context.CommLevel where commRecCommiss.Type == "INS" && commRecCommiss.RecType == "C" orderby commRecCommiss.Position ascending select commRecCommiss);

                    gridControlMarkups.DataSource = (from commRecMarkups in context.CommLevel where commRecMarkups.Type == "INS" && commRecMarkups.RecType == "M" orderby commRecMarkups.Position ascending select commRecMarkups);
                    repositoryItemCB_LinkTable_Comm.Items.Clear();
                    repositoryItemCB_LookUpTable_Comm.Items.Clear();
                    repositoryItemCB_LookUpTable_MU.Items.Clear();
                    repositoryItemCB_LinkTable_MU.Items.Clear();
                    repositoryItemCB_LookUpTable_Comm.Items.Add("CITYCOD");
                    repositoryItemCB_LookUpTable_Comm.Items.Add("COUNTRY");
                    repositoryItemCB_LookUpTable_Comm.Items.Add("REGION");
                    repositoryItemCB_LookUpTable_Comm.Items.Add("LOOKUP");
                    repositoryItemCB_LookUpTable_MU.Items.Add("CITYCOD");
                    repositoryItemCB_LookUpTable_MU.Items.Add("COUNTRY");
                    repositoryItemCB_LookUpTable_MU.Items.Add("REGION");
                    repositoryItemCB_LookUpTable_MU.Items.Add("LOOKUP");
                    repositoryItemCB_LinkTable_Comm.Items.Add("INSURAN");
                    repositoryItemCB_LinkTable_Comm.Items.Add("DETAIL");
                    repositoryItemCB_LinkTable_MU.Items.Add("INSURAN");
                    repositoryItemCB_LinkTable_MU.Items.Add("DETAIL");
                }
                if (cbEdit_Type.Text == "AGY")
                {
                    table = "AGY";                                       
                    gridControlCommissions.DataSource = (from commRecCommiss in context.CommLevel where commRecCommiss.Type == "AGY" && commRecCommiss.RecType == "C" orderby commRecCommiss.Position ascending select commRecCommiss);

                    gridControlMarkups.DataSource = (from commRecMarkups in context.CommLevel where commRecMarkups.Type == "AGY" && commRecMarkups.RecType == "M" orderby commRecMarkups.Position ascending select commRecMarkups);                   
                    repositoryItemCB_LinkTable_Comm.Items.Clear();
                    repositoryItemCB_LookUpTable_Comm.Items.Clear();
                    repositoryItemCB_LookUpTable_MU.Items.Clear();
                    repositoryItemCB_LinkTable_MU.Items.Clear();
                    repositoryItemCB_LookUpTable_Comm.Items.Add("CITYCOD");
                    repositoryItemCB_LookUpTable_Comm.Items.Add("COUNTRY");
                    repositoryItemCB_LookUpTable_Comm.Items.Add("REGION");
                    repositoryItemCB_LookUpTable_Comm.Items.Add("LOOKUP");
                    repositoryItemCB_LookUpTable_Comm.Items.Add("AGY");
                    repositoryItemCB_LookUpTable_Comm.Items.Add("LANGUAGE");
                    repositoryItemCB_LookUpTable_MU.Items.Add("CITYCOD");
                    repositoryItemCB_LookUpTable_MU.Items.Add("COUNTRY");
                    repositoryItemCB_LookUpTable_MU.Items.Add("REGION");
                    repositoryItemCB_LookUpTable_MU.Items.Add("LOOKUP");
                    repositoryItemCB_LookUpTable_MU.Items.Add("AGY");
                    repositoryItemCB_LookUpTable_MU.Items.Add("LANGUAGE");
                    repositoryItemCB_LinkTable_Comm.Items.Add("AGY");
                    repositoryItemCB_LinkTable_Comm.Items.Add("DETAIL");
                    repositoryItemCB_LinkTable_MU.Items.Add("AGY");
                    repositoryItemCB_LinkTable_MU.Items.Add("DETAIL");
                }
                if (cbEdit_Type.Text == "")
                {
                    gridControlCommissions.DataSource = null;
                    gridControlMarkups.DataSource = null;
                }
                currentVal = cbEdit_Type.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gvCommissions_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            repositoryItemCB_LinkColumn_Comm.Items.Clear();
            repositoryItemCB_LookupColumn_Comm.Items.Clear();
            string LinkTable = gvCommissions.GetFocusedRowCellDisplayText("Link_Table");
            if (!string.IsNullOrWhiteSpace(LinkTable))
            {
                IQueryable LoadTable = (IQueryable)context.GetType().GetProperty(LinkTable.TrimEnd()).GetValue(context, null);
                List<System.Reflection.PropertyInfo> valid = LoadTable.ElementType.GetProperties().ToList();

                foreach (System.Reflection.PropertyInfo value in valid)
                {
                    if (value.PropertyType.FullName.Contains("System.Data") || value.PropertyType.FullName.Contains("FlexModel") || value.Name.Contains("DisplayName") || value.Name.Contains("ImagesRoot"))
                    {  }
                    else
                    {
                        string columnName = value.Name;
                        if (LinkTable == "HOTEL")
                            if ("LAST_UPD,UPD_INIT,GEN_MGR,AP_MGR,LOCAL_NAME,LOCAL_PHONE,AIR_MI,COUNTRY_CODE,CITY_CODE,CITY_MI,DEP_RQ,CANC_PER,CHECK_IN,CRED_CARDS,NO_RMS,NO_REST,NO_LOUNGES,ROOM_DESC,CHILD_DESC,RATE_BASIS,DEF_ROOM,CONTR_CDE,CONTR_AGY,RSTR_CDE,ALTERN_1,ALTERN_2,ALTERN_3,ACT_CITY,ADV_PMT,PFRD_FLG,DFLT_CAT,RES_EMAIL,AP_EMAIL,MAX_SGL,MAX_DBL,MAX_TPL,MAX_QUA,MAX_OTH ".Contains(columnName))
                                columnName = columnName.Replace("_", " ");

                        if (LinkTable == "AGY")
                            if ("LAST_UPD,UPD_INIT,DEF_LANG,FAX_NUM,PMT_DAYS,ACTIVE_FLG,IMMED_FLG,INV_FMT,PRIOR_DAYS,LAST_INV,DAYS_SPACE,SVCDTE_FLG,FAX_ID,OPT_DAYS,SUB_ALLOC,MAILFAX_FLG,REM_CHG,CONF_PRC,CXL1_NTSPRIOR,CXL1_PCT,CXL1_FLAT,CHG1_NTSPRIOR,CHG1_PCT,CHG1_FLAT,CXL2_NTSPRIOR,CXL2_PCT,CXL2_FLAT,CHG2_NTSPRIOR,CHG2_PCT,CHG2_FLAT,CXL3_NTSPRIOR,CXL3_PCT,CXL3_FLAT,CHG3_NTSPRIOR,CHG3_PCT,CHG3_FLAT".Contains(columnName))
                                columnName = columnName.Replace("_", " ");

                        if (LinkTable == "PACK")
                            if ("LAST_UPD,UPD_INIT,RATE_BASIS,ALTERN_1,ALTERN_2,ALTERN_3,RSTR_CDE,PKG_TYPE,FLEX_PKG,MAX_SGL,MAX_DBL,MAX_TPL,MAX_QUA,MAX_OTH".Contains(columnName))
                                columnName = columnName.Replace("_", " ");

                        if (LinkTable == "AIR")
                            if ("LAST_UPD,UPD_INIT,PHONE1_NO,PHONE2_NO,MAIN_OFF,MAIN_AD1,MAIN_AD2,MAIN_AD3,OTHER_OFF1,OTHER_OFF2,OTHER_OFF3,RATE_BASIS,RESTR_CDE".Contains(columnName))
                                columnName = columnName.Replace("_", " ");

                        if (LinkTable == "CARINFO")
                            if ("LAST_UPD,UPD_INIT,OPER_NAME,CONT_PHONE,AIR_MI,CITY_MI,RATE_BASIS,RSTR_CDE,".Contains(columnName))
                                columnName = columnName.Replace("_", " ");

                        if (LinkTable == "COMP")
                            if ("LAST_UPD,UPD_INIT,RATE_BASIS,RSTR_CDE,TRSFR_TYP,SVC_LIST,PUDRP_REQ,SERV_TYPE,CITY_MI,AIR_MI".Contains(columnName))
                                columnName = columnName.Replace("_", " ");

                        if (LinkTable == "CRU")
                            if ("LAST_UPD,UPD_INIT,RESTR_CDE,DEF_CABIN".Contains(columnName))
                                columnName = columnName.Replace("_", " ");

                        if (LinkTable == "INSURAN")
                            if ("START_DATE,END_DATE,LAST_UPD,UPD_INIT,FROM_AMT,TO_AMT,COMM_FLG,COMM_PCT".Contains(columnName))
                                columnName = columnName.Replace("_", " ");
                        repositoryItemCB_LinkColumn_Comm.Items.Add(columnName);
                    }
                }
            }
            
            string LookupTable = gvCommissions.GetFocusedRowCellDisplayText("Lookup_Table");
            if (!string.IsNullOrWhiteSpace(LookupTable))
            {
                IQueryable LoadTable = (IQueryable)context.GetType().GetProperty(LookupTable.TrimEnd()).GetValue(context, null);
                List<System.Reflection.PropertyInfo> valid = LoadTable.ElementType.GetProperties().ToList();

                foreach (System.Reflection.PropertyInfo value in valid)
                {
                    if (value.PropertyType.FullName.Contains("System.Data") || value.PropertyType.FullName.Contains("FlexModel") || value.Name.Contains("DisplayName") || value.Name.Contains("ImagesRoot"))
                    {  }
                    else
                    {
                        string columnName = value.Name;
                        if (LookupTable == "AGY")
                            if ("LAST_UPD,UPD_INIT,DEF_LANG,FAX_NUM,PMT_DAYS,ACTIVE_FLG,IMMED_FLG,INV_FMT,PRIOR_DAYS,LAST_INV,DAYS_SPACE,SVCDTE_FLG,FAX_ID,OPT_DAYS,SUB_ALLOC,MAILFAX_FLG,REM_CHG,CONF_PRC,CXL1_NTSPRIOR,CXL1_PCT,CXL1_FLAT,CHG1_NTSPRIOR,CHG1_PCT,CHG1_FLAT,CXL2_NTSPRIOR,CXL2_PCT,CXL2_FLAT,CHG2_NTSPRIOR,CHG2_PCT,CHG2_FLAT,CXL3_NTSPRIOR,CXL3_PCT,CXL3_FLAT,CHG3_NTSPRIOR,CHG3_PCT,CHG3_FLAT".Contains(columnName))
                                columnName = columnName.Replace("_", " ");
                        repositoryItemCB_LookupColumn_Comm.Items.Add(value.Name);

                    }

                }
            }
        }

        private void gvCommissions_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            
            if (e.Column.FieldName == "Link_Table")
            {
                gvCommissions.SetFocusedRowCellValue("Link_Column", "");  
                if (!string.IsNullOrWhiteSpace(e.Value.ToString()))
                {
                    repositoryItemCB_LinkColumn_Comm.Items.Clear();
                    string LinkTable = gvCommissions.GetFocusedRowCellDisplayText("Link_Table");
                    if (!string.IsNullOrWhiteSpace(LinkTable))
                    {
                        IQueryable LoadTable = (IQueryable)context.GetType().GetProperty(LinkTable.TrimEnd()).GetValue(context, null);
                        List<System.Reflection.PropertyInfo> valid = LoadTable.ElementType.GetProperties().ToList();

                        foreach (System.Reflection.PropertyInfo value in valid)
                        {
                            if (value.PropertyType.FullName.Contains("System.Data") || value.PropertyType.FullName.Contains("FlexModel") || value.Name.Contains("DisplayName") || value.Name.Contains("ImagesRoot"))
                            { }
                            else
                            {
                                string columnName = value.Name;
                                if (LinkTable == "HOTEL")
                                    if ("LAST_UPD,UPD_INIT,GEN_MGR,AP_MGR,LOCAL_NAME,LOCAL_PHONE,AIR_MI,COUNTRY_CODE,CITY_CODE,CITY_MI,DEP_RQ,CANC_PER,CHECK_IN,CRED_CARDS,NO_RMS,NO_REST,NO_LOUNGES,ROOM_DESC,CHILD_DESC,RATE_BASIS,DEF_ROOM,CONTR_CDE,CONTR_AGY,RSTR_CDE,ALTERN_1,ALTERN_2,ALTERN_3,ACT_CITY,ADV_PMT,PFRD_FLG,DFLT_CAT,RES_EMAIL,AP_EMAIL,MAX_SGL,MAX_DBL,MAX_TPL,MAX_QUA,MAX_OTH ".Contains(columnName))
                                        columnName = columnName.Replace("_", " ");

                                if (LinkTable == "AGY")
                                    if ("LAST_UPD,UPD_INIT,DEF_LANG,FAX_NUM,PMT_DAYS,ACTIVE_FLG,IMMED_FLG,INV_FMT,PRIOR_DAYS,LAST_INV,DAYS_SPACE,SVCDTE_FLG,FAX_ID,OPT_DAYS,SUB_ALLOC,MAILFAX_FLG,REM_CHG,CONF_PRC,CXL1_NTSPRIOR,CXL1_PCT,CXL1_FLAT,CHG1_NTSPRIOR,CHG1_PCT,CHG1_FLAT,CXL2_NTSPRIOR,CXL2_PCT,CXL2_FLAT,CHG2_NTSPRIOR,CHG2_PCT,CHG2_FLAT,CXL3_NTSPRIOR,CXL3_PCT,CXL3_FLAT,CHG3_NTSPRIOR,CHG3_PCT,CHG3_FLAT".Contains(columnName))
                                        columnName = columnName.Replace("_", " ");

                                if (LinkTable == "PACK")
                                    if ("LAST_UPD,UPD_INIT,RATE_BASIS,ALTERN_1,ALTERN_2,ALTERN_3,RSTR_CDE,PKG_TYPE,FLEX_PKG,MAX_SGL,MAX_DBL,MAX_TPL,MAX_QUA,MAX_OTH".Contains(columnName))
                                        columnName = columnName.Replace("_", " ");

                                if (LinkTable == "AIR")
                                    if ("LAST_UPD,UPD_INIT,PHONE1_NO,PHONE2_NO,MAIN_OFF,MAIN_AD1,MAIN_AD2,MAIN_AD3,OTHER_OFF1,OTHER_OFF2,OTHER_OFF3,RATE_BASIS,RESTR_CDE".Contains(columnName))
                                        columnName = columnName.Replace("_", " ");

                                if (LinkTable == "CARINFO")
                                    if ("LAST_UPD,UPD_INIT,OPER_NAME,CONT_PHONE,AIR_MI,CITY_MI,RATE_BASIS,RSTR_CDE,".Contains(columnName))
                                        columnName = columnName.Replace("_", " ");

                                if (LinkTable == "COMP")
                                    if ("LAST_UPD,UPD_INIT,RATE_BASIS,RSTR_CDE,TRSFR_TYP,SVC_LIST,PUDRP_REQ,SERV_TYPE,CITY_MI,AIR_MI".Contains(columnName))
                                        columnName = columnName.Replace("_", " ");

                                if (LinkTable == "CRU")
                                    if ("LAST_UPD,UPD_INIT,RESTR_CDE,DEF_CABIN".Contains(columnName))
                                        columnName = columnName.Replace("_", " ");

                                if (LinkTable == "INSURAN")
                                    if ("START_DATE,END_DATE,LAST_UPD,UPD_INIT,FROM_AMT,TO_AMT,COMM_FLG,COMM_PCT".Contains(columnName))
                                        columnName = columnName.Replace("_", " ");
                                repositoryItemCB_LinkColumn_Comm.Items.Add(columnName);

                            }
                        }
                    }
                }
            }

            if (e.Column.FieldName == "Lookup_Table")
            {                
                gvCommissions.SetFocusedRowCellValue("Lookup_Column", "");
                if (!string.IsNullOrWhiteSpace(e.Value.ToString()))
                {
                    repositoryItemCB_LookupColumn_Comm.Items.Clear();
                    string LookupTable = gvCommissions.GetFocusedRowCellDisplayText("Lookup_Table");
                    if (!string.IsNullOrWhiteSpace(LookupTable))
                    {
                        IQueryable LoadTable = (IQueryable)context.GetType().GetProperty(LookupTable.TrimEnd()).GetValue(context, null);
                        List<System.Reflection.PropertyInfo> valid = LoadTable.ElementType.GetProperties().ToList();

                        foreach (System.Reflection.PropertyInfo value in valid)
                        {
                            if (value.PropertyType.FullName.Contains("System.Data") || value.PropertyType.FullName.Contains("FlexModel") || value.Name.Contains("DisplayName") || value.Name.Contains("ImagesRoot"))
                            { }
                            else
                            {
                                string columnName = value.Name;
                                if (LookupTable == "AGY")
                                    if ("LAST_UPD,UPD_INIT,DEF_LANG,FAX_NUM,PMT_DAYS,ACTIVE_FLG,IMMED_FLG,INV_FMT,PRIOR_DAYS,LAST_INV,DAYS_SPACE,SVCDTE_FLG,FAX_ID,OPT_DAYS,SUB_ALLOC,MAILFAX_FLG,REM_CHG,CONF_PRC,CXL1_NTSPRIOR,CXL1_PCT,CXL1_FLAT,CHG1_NTSPRIOR,CHG1_PCT,CHG1_FLAT,CXL2_NTSPRIOR,CXL2_PCT,CXL2_FLAT,CHG2_NTSPRIOR,CHG2_PCT,CHG2_FLAT,CXL3_NTSPRIOR,CXL3_PCT,CXL3_FLAT,CHG3_NTSPRIOR,CHG3_PCT,CHG3_FLAT".Contains(columnName))
                                        columnName = columnName.Replace("_", " ");
                                repositoryItemCB_LookupColumn_Comm.Items.Add(value.Name);
                            }
                        }
                    }
                }
            }
        }

        private void gvMarkups_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            repositoryItemCB_LinkColumn_MU.Items.Clear();
            repositoryItemCB_LookupColumn_MU.Items.Clear();
            string LinkTable = gvMarkups.GetFocusedRowCellDisplayText("Link_Table");
            if (!string.IsNullOrWhiteSpace(LinkTable))
            {
                IQueryable LoadTable = (IQueryable)context.GetType().GetProperty(LinkTable.TrimEnd()).GetValue(context, null);
                List<System.Reflection.PropertyInfo> valid = LoadTable.ElementType.GetProperties().ToList();

                foreach (System.Reflection.PropertyInfo value in valid)
                {
                    if (value.PropertyType.FullName.Contains("System.Data") || value.PropertyType.FullName.Contains("FlexModel") || value.Name.Contains("DisplayName") || value.Name.Contains("ImagesRoot"))
                    { }
                    else
                    {
                        string columnName = value.Name;
                        if (LinkTable == "HOTEL")
                            if ("LAST_UPD,UPD_INIT,GEN_MGR,AP_MGR,LOCAL_NAME,LOCAL_PHONE,AIR_MI,COUNTRY_CODE,CITY_CODE,CITY_MI,DEP_RQ,CANC_PER,CHECK_IN,CRED_CARDS,NO_RMS,NO_REST,NO_LOUNGES,ROOM_DESC,CHILD_DESC,RATE_BASIS,DEF_ROOM,CONTR_CDE,CONTR_AGY,RSTR_CDE,ALTERN_1,ALTERN_2,ALTERN_3,ACT_CITY,ADV_PMT,PFRD_FLG,DFLT_CAT,RES_EMAIL,AP_EMAIL,MAX_SGL,MAX_DBL,MAX_TPL,MAX_QUA,MAX_OTH ".Contains(columnName))
                                columnName = columnName.Replace("_", " ");
                        if (LinkTable == "AGY")
                            if ("LAST_UPD,UPD_INIT,DEF_LANG,FAX_NUM,PMT_DAYS,ACTIVE_FLG,IMMED_FLG,INV_FMT,PRIOR_DAYS,LAST_INV,DAYS_SPACE,SVCDTE_FLG,FAX_ID,OPT_DAYS,SUB_ALLOC,MAILFAX_FLG,REM_CHG,CONF_PRC,CXL1_NTSPRIOR,CXL1_PCT,CXL1_FLAT,CHG1_NTSPRIOR,CHG1_PCT,CHG1_FLAT,CXL2_NTSPRIOR,CXL2_PCT,CXL2_FLAT,CHG2_NTSPRIOR,CHG2_PCT,CHG2_FLAT,CXL3_NTSPRIOR,CXL3_PCT,CXL3_FLAT,CHG3_NTSPRIOR,CHG3_PCT,CHG3_FLAT".Contains(columnName))
                                columnName = columnName.Replace("_", " ");
                        if (LinkTable == "PACK")
                            if ("LAST_UPD,UPD_INIT,RATE_BASIS,ALTERN_1,ALTERN_2,ALTERN_3,RSTR_CDE,PKG_TYPE,FLEX_PKG,MAX_SGL,MAX_DBL,MAX_TPL,MAX_QUA,MAX_OTH".Contains(columnName))
                                columnName = columnName.Replace("_", " ");
                        if (LinkTable == "AIR")
                            if ("LAST_UPD,UPD_INIT,PHONE1_NO,PHONE2_NO,MAIN_OFF,MAIN_AD1,MAIN_AD2,MAIN_AD3,OTHER_OFF1,OTHER_OFF2,OTHER_OFF3,RATE_BASIS,RESTR_CDE".Contains(columnName))
                                columnName = columnName.Replace("_", " ");
                        if (LinkTable == "CARINFO")
                            if ("LAST_UPD,UPD_INIT,OPER_NAME,CONT_PHONE,AIR_MI,CITY_MI,RATE_BASIS,RSTR_CDE,".Contains(columnName))
                                columnName = columnName.Replace("_", " ");
                        if (LinkTable == "COMP")
                            if ("LAST_UPD,UPD_INIT,RATE_BASIS,RSTR_CDE,TRSFR_TYP,SVC_LIST,PUDRP_REQ,SERV_TYPE,CITY_MI,AIR_MI".Contains(columnName))
                                columnName = columnName.Replace("_", " ");
                        if (LinkTable == "CRU")
                            if ("LAST_UPD,UPD_INIT,RESTR_CDE,DEF_CABIN".Contains(columnName))
                                columnName = columnName.Replace("_", " ");
                        if (LinkTable == "INSURAN")
                            if ("START_DATE,END_DATE,LAST_UPD,UPD_INIT,FROM_AMT,TO_AMT,COMM_FLG,COMM_PCT".Contains(columnName))
                                columnName = columnName.Replace("_", " ");
                        repositoryItemCB_LinkColumn_MU.Items.Add(columnName);
                    }
                }
            }

            string LookupTable = gvMarkups.GetFocusedRowCellDisplayText("Lookup_Table");
            if (!string.IsNullOrWhiteSpace(LookupTable))
            {
                IQueryable LoadTable = (IQueryable)context.GetType().GetProperty(LookupTable.TrimEnd()).GetValue(context, null);
                List<System.Reflection.PropertyInfo> valid = LoadTable.ElementType.GetProperties().ToList();

                foreach (System.Reflection.PropertyInfo value in valid)
                {
                    if (value.PropertyType.FullName.Contains("System.Data") || value.PropertyType.FullName.Contains("FlexModel") || value.Name.Contains("DisplayName") || value.Name.Contains("ImagesRoot"))
                    { }
                    else
                    {
                        string columnName = value.Name;
                        if (LookupTable == "AGY")
                            if ("LAST_UPD,UPD_INIT,DEF_LANG,FAX_NUM,PMT_DAYS,ACTIVE_FLG,IMMED_FLG,INV_FMT,PRIOR_DAYS,LAST_INV,DAYS_SPACE,SVCDTE_FLG,FAX_ID,OPT_DAYS,SUB_ALLOC,MAILFAX_FLG,REM_CHG,CONF_PRC,CXL1_NTSPRIOR,CXL1_PCT,CXL1_FLAT,CHG1_NTSPRIOR,CHG1_PCT,CHG1_FLAT,CXL2_NTSPRIOR,CXL2_PCT,CXL2_FLAT,CHG2_NTSPRIOR,CHG2_PCT,CHG2_FLAT,CXL3_NTSPRIOR,CXL3_PCT,CXL3_FLAT,CHG3_NTSPRIOR,CHG3_PCT,CHG3_FLAT".Contains(columnName))
                                columnName = columnName.Replace("_", " ");
                        repositoryItemCB_LookupColumn_MU.Items.Add(value.Name);
                    }
                }
            }
        }

        private void gvMarkups_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Link_Table")
            {
                gvMarkups.SetFocusedRowCellValue("Link_Column", "");
                if (!string.IsNullOrWhiteSpace(e.Value.ToString()))
                {
                    repositoryItemCB_LinkColumn_MU.Items.Clear();
                    string LinkTable = gvMarkups.GetFocusedRowCellDisplayText("Link_Table");
                    if (!string.IsNullOrWhiteSpace(LinkTable))
                    {
                        IQueryable LoadTable = (IQueryable)context.GetType().GetProperty(LinkTable.TrimEnd()).GetValue(context, null);
                        List<System.Reflection.PropertyInfo> valid = LoadTable.ElementType.GetProperties().ToList();

                        foreach (System.Reflection.PropertyInfo value in valid)
                        {
                            if (value.PropertyType.FullName.Contains("System.Data") || value.PropertyType.FullName.Contains("FlexModel") || value.Name.Contains("DisplayName") || value.Name.Contains("ImagesRoot"))
                            { }
                            else
                            {
                                string columnName = value.Name;
                                if (LinkTable == "HOTEL")
                                    if ("LAST_UPD,UPD_INIT,GEN_MGR,AP_MGR,LOCAL_NAME,LOCAL_PHONE,AIR_MI,COUNTRY_CODE,CITY_CODE,CITY_MI,DEP_RQ,CANC_PER,CHECK_IN,CRED_CARDS,NO_RMS,NO_REST,NO_LOUNGES,ROOM_DESC,CHILD_DESC,RATE_BASIS,DEF_ROOM,CONTR_CDE,CONTR_AGY,RSTR_CDE,ALTERN_1,ALTERN_2,ALTERN_3,ACT_CITY,ADV_PMT,PFRD_FLG,DFLT_CAT,RES_EMAIL,AP_EMAIL,MAX_SGL,MAX_DBL,MAX_TPL,MAX_QUA,MAX_OTH ".Contains(columnName))
                                        columnName = columnName.Replace("_", " ");
                                if (LinkTable == "AGY")
                                    if ("LAST_UPD,UPD_INIT,DEF_LANG,FAX_NUM,PMT_DAYS,ACTIVE_FLG,IMMED_FLG,INV_FMT,PRIOR_DAYS,LAST_INV,DAYS_SPACE,SVCDTE_FLG,FAX_ID,OPT_DAYS,SUB_ALLOC,MAILFAX_FLG,REM_CHG,CONF_PRC,CXL1_NTSPRIOR,CXL1_PCT,CXL1_FLAT,CHG1_NTSPRIOR,CHG1_PCT,CHG1_FLAT,CXL2_NTSPRIOR,CXL2_PCT,CXL2_FLAT,CHG2_NTSPRIOR,CHG2_PCT,CHG2_FLAT,CXL3_NTSPRIOR,CXL3_PCT,CXL3_FLAT,CHG3_NTSPRIOR,CHG3_PCT,CHG3_FLAT".Contains(columnName))
                                        columnName = columnName.Replace("_", " ");
                                if (LinkTable == "PACK")
                                    if ("LAST_UPD,UPD_INIT,RATE_BASIS,ALTERN_1,ALTERN_2,ALTERN_3,RSTR_CDE,PKG_TYPE,FLEX_PKG,MAX_SGL,MAX_DBL,MAX_TPL,MAX_QUA,MAX_OTH".Contains(columnName))
                                        columnName = columnName.Replace("_", " ");
                                if (LinkTable == "AIR")
                                    if ("LAST_UPD,UPD_INIT,PHONE1_NO,PHONE2_NO,MAIN_OFF,MAIN_AD1,MAIN_AD2,MAIN_AD3,OTHER_OFF1,OTHER_OFF2,OTHER_OFF3,RATE_BASIS,RESTR_CDE".Contains(columnName))
                                        columnName = columnName.Replace("_", " ");
                                if (LinkTable == "CARINFO")
                                    if ("LAST_UPD,UPD_INIT,OPER_NAME,CONT_PHONE,AIR_MI,CITY_MI,RATE_BASIS,RSTR_CDE,".Contains(columnName))
                                        columnName = columnName.Replace("_", " ");
                                if (LinkTable == "COMP")
                                    if ("LAST_UPD,UPD_INIT,RATE_BASIS,RSTR_CDE,TRSFR_TYP,SVC_LIST,PUDRP_REQ,SERV_TYPE,CITY_MI,AIR_MI".Contains(columnName))
                                        columnName = columnName.Replace("_", " ");
                                if (LinkTable == "CRU")
                                    if ("LAST_UPD,UPD_INIT,RESTR_CDE,DEF_CABIN".Contains(columnName))
                                        columnName = columnName.Replace("_", " ");
                                if (LinkTable == "INSURAN")
                                    if ("START_DATE,END_DATE,LAST_UPD,UPD_INIT,FROM_AMT,TO_AMT,COMM_FLG,COMM_PCT".Contains(columnName))
                                        columnName = columnName.Replace("_", " ");
                                repositoryItemCB_LinkColumn_MU.Items.Add(columnName);
                            }
                        }
                    }
                }
            }

            if (e.Column.FieldName == "Lookup_Table")
            {              
                gvMarkups.SetFocusedRowCellValue("Lookup_Column", "");
                if (!string.IsNullOrWhiteSpace(e.Value.ToString()))
                {
                    repositoryItemCB_LookupColumn_MU.Items.Clear();
                    string LookupTable = gvMarkups.GetFocusedRowCellDisplayText("Lookup_Table");
                    if (!string.IsNullOrWhiteSpace(LookupTable))
                    {
                        IQueryable LoadTable = (IQueryable)context.GetType().GetProperty(LookupTable.TrimEnd()).GetValue(context, null);
                        List<System.Reflection.PropertyInfo> valid = LoadTable.ElementType.GetProperties().ToList();
                        foreach (System.Reflection.PropertyInfo value in valid)
                        {
                            if (value.PropertyType.FullName.Contains("System.Data") || value.PropertyType.FullName.Contains("FlexModel") || value.Name.Contains("DisplayName") || value.Name.Contains("ImagesRoot"))
                            { }
                            else
                            {
                                string columnName = value.Name;
                                if (LookupTable == "AGY")
                                    if ("LAST_UPD,UPD_INIT,DEF_LANG,FAX_NUM,PMT_DAYS,ACTIVE_FLG,IMMED_FLG,INV_FMT,PRIOR_DAYS,LAST_INV,DAYS_SPACE,SVCDTE_FLG,FAX_ID,OPT_DAYS,SUB_ALLOC,MAILFAX_FLG,REM_CHG,CONF_PRC,CXL1_NTSPRIOR,CXL1_PCT,CXL1_FLAT,CHG1_NTSPRIOR,CHG1_PCT,CHG1_FLAT,CXL2_NTSPRIOR,CXL2_PCT,CXL2_FLAT,CHG2_NTSPRIOR,CHG2_PCT,CHG2_FLAT,CXL3_NTSPRIOR,CXL3_PCT,CXL3_FLAT,CHG3_NTSPRIOR,CHG3_PCT,CHG3_FLAT".Contains(columnName))
                                        columnName = columnName.Replace("_", " ");
                                repositoryItemCB_LookupColumn_MU.Items.Add(columnName);
                            }
                        }
                    }
                }
            }
        }

     

        private void saveChanges(ColumnView view)
        {
            view.FocusedColumn = view.Columns["Type"];
            string linkTable = view.GetFocusedRowCellDisplayText("Link_Table");
            string linkColumn = view.GetFocusedRowCellDisplayText("Link_Column");
            string lookupTable = view.GetFocusedRowCellDisplayText("Lookup_Table");
            string lookupColumn = view.GetFocusedRowCellDisplayText("Lookup_Column");
            string linkRec = view.GetFocusedRowCellDisplayText("Link_Rectype");
            int ID = (int)view.GetFocusedRowCellValue("ID");
            string recType = view.GetFocusedRowCellDisplayText("RecType");
            string query = view.GetFocusedRowCellDisplayText("Query");
            var load = from commLevelRec in context.CommLevel
                       where commLevelRec.ID != ID && commLevelRec.Type == cbEdit_Type.Text && commLevelRec.Link_Table == linkTable && commLevelRec.Link_Column == linkColumn
                           && commLevelRec.Lookup_Table == lookupTable && commLevelRec.Lookup_Column == lookupColumn && commLevelRec.Link_Rectype == linkRec && commLevelRec.RecType == recType && commLevelRec.Query == query
                       select commLevelRec;
            if (load.Count() > 0)
            {
                MessageBox.Show("You are attempting to enter a duplicate record. Please make this entry unique..");
                return;
            }

            if (isValidQuery((string)query) == false)
            {
                MessageBox.Show("Please enter a valid SQL query to save the changes.");
              return;
            }
            if (view.UpdateCurrentRow())
            {
                CommLevelBindingSource.EndEdit();
                context.SaveChanges();
                newRec = false;
                modified = false;
                newRec = false;
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
            }
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private void SaveChangesMarkups_Click(object sender, EventArgs e)
        {
            saveChanges(gvMarkups);
        }

        private void CommButtonUpArrow_Click(object sender, EventArgs e)
        {
            if (gvCommissions.RowCount == 0 || gvCommissions.RowCount == 1)
                return;
            //if (!gridControlCommissions.IsFocused)
            //{
            //    MessageBox.Show("Please select the row you would like to move.");
            //    return;
            //}
            gvCommissions.FocusedColumn = gvCommissions.Columns["Type"];
            if (gvCommissions.UpdateCurrentRow())
            {
                CommLevelBindingSource.EndEdit();
                context.SaveChanges();
                newRec = false;
            }
            else
            {
                MessageBox.Show("Please correct errors in the grid.");
                return;
            }

            if (gvCommissions.IsFirstRow)
            {
                MessageBox.Show("This row is already at highest priority.");
                return;
            }
            else
            {
                int currentRow = gvCommissions.FocusedRowHandle;
                int previousRow = currentRow - 1;
                object value = gvCommissions.GetFocusedRowCellValue("Position");
                gvCommissions.SetFocusedRowCellValue("Position", gvCommissions.GetRowCellValue(previousRow, "Position"));
                gvCommissions.SetRowCellValue(previousRow, "Position", value);
                context.SaveChanges();
                string val = cbEdit_Type.Text;
                cbEdit_Type.Text = "";
                cbEdit_Type.Text = val;
                gvCommissions.FocusedRowHandle = previousRow;
            }
        }

        private void CommButtonDownArrow_Click(object sender, EventArgs e)
        {
            if (gvCommissions.RowCount == 0 || gvCommissions.RowCount == 1)
                return;
            //if (!gridControlCommissions.IsFocused)
            //{
            //    MessageBox.Show("Please select the row you would like to move.");
            //    return;
            //}
            
            gvCommissions.FocusedColumn = gvCommissions.Columns["Type"];
            if (gvCommissions.UpdateCurrentRow())
            {
                CommLevelBindingSource.EndEdit();
                context.SaveChanges();
                newRec = false;
            }
            else
            {
                MessageBox.Show("Please correct errors in the grid.");
                return;
            }
            if (gvCommissions.IsLastRow)
            {
                MessageBox.Show("This row is already at lowest priority.");
                return;
            }
            else
            {
                int current = gvCommissions.FocusedRowHandle;
                int next = current + 1;
                object value = gvCommissions.GetFocusedRowCellValue("Position");
                gvCommissions.SetFocusedRowCellValue("Position", gvCommissions.GetRowCellValue(next, "Position"));
                gvCommissions.SetRowCellValue(next, "Position", value);
                context.SaveChanges();
                string val = cbEdit_Type.Text;
                cbEdit_Type.Text = "";
                cbEdit_Type.Text = val;
                gvCommissions.FocusedRowHandle = next;
            }
        }

        private void MarkupButtonUpArrow_Click(object sender, EventArgs e)
        {
             if (gvMarkups.RowCount == 0 || gvMarkups.RowCount ==1)
                return;
            //if (!gridControlMarkups.IsFocused)
            //{
            //    MessageBox.Show("Please select the row you would like to move.");
            //    return;
            //}
            gvMarkups.FocusedColumn = gvMarkups.Columns["Type"];
            if (gvMarkups.UpdateCurrentRow())
            {
                CommLevelBindingSource.EndEdit();
                context.SaveChanges();
                newRec = false;
            }
            else
            {
                MessageBox.Show("Please correct errors in the grid.");
                return;
            }
            if (gvMarkups.IsFirstRow)
            {
                MessageBox.Show("This row is already at highest priority.");
                return;
            }
            else
            {
                int current = gvMarkups.FocusedRowHandle;
                int previous = current - 1;
                object value = gvMarkups.GetFocusedRowCellValue("Position");
                gvMarkups.SetFocusedRowCellValue("Position", gvMarkups.GetRowCellValue(previous, "Position"));
                gvMarkups.SetRowCellValue(previous, "Position", value);
                context.SaveChanges();
                string val = cbEdit_Type.Text;
                cbEdit_Type.Text = "";
                cbEdit_Type.Text = val;
                gvMarkups.FocusedRowHandle = previous;
            }
        }

       


        private void MarkupButtonDownAwwor_Click(object sender, EventArgs e)
        {
            if (gvMarkups.RowCount == 0 || gvMarkups.RowCount == 1)
                return;
            //if (!gridControlMarkups.IsFocused)
            //{
            //    MessageBox.Show("Please select the row you would like to move.");
            //    return;
            //}
            gvMarkups.FocusedColumn = gvMarkups.Columns["Type"];
            if (gvMarkups.UpdateCurrentRow())
            {
                CommLevelBindingSource.EndEdit();
                context.SaveChanges();
                newRec = false;
            }
            else
            {
                MessageBox.Show("Please correct errors in the grid.");
                return;
            }

            if (gvMarkups.IsLastRow)
            {
                MessageBox.Show("This row is already at lowest priority.");
                return;
            }
            else
            {
                int current = gvMarkups.FocusedRowHandle;
                int next = current + 1;
                object value = gvMarkups.GetFocusedRowCellValue("Position");
                gvMarkups.SetFocusedRowCellValue("Position", gvMarkups.GetRowCellValue(next, "Position"));
                gvMarkups.SetRowCellValue(next, "Position", value);
                context.SaveChanges();
                string val = cbEdit_Type.Text;
                cbEdit_Type.Text = "";
                cbEdit_Type.Text = val;
                gvMarkups.FocusedRowHandle = next;
            }
        }
    }
}



