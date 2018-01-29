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

using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
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
    
    public partial class DigHdrForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        const string colName = "colCODE";
        public FlextourEntities context; 
        public string username;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public DigHdrForm(FlexCore.CoreSys _sys)
        {
            InitializeComponent();
            Connection.EFConnectionString = _sys.Settings.EFConnectionString;
            context = new FlextourEntities(_sys.Settings.EFConnectionString);
            modified = false;
            newRec = false;
            agencySearch.ButtonEdit.Properties.ReadOnly = true;
            cOUP_RESTextEdit.Properties.ReadOnly = true;
            gsLoad.gridSearchLoad(agencySearch, "NO", "NAME", "Code", "Description", "NO", "NO", "NAME", DigHdrBindingSource, "AGY_NO");
            agencySearch.GridControl.DataSource = context.AGY;
            DigHdrBindingSource.DataSource = context.DIGHDR.Take(1000);
            username = _sys.User.Name;
            
        }

     

        private bool checkForms()
        {
            
            if (!modified && !newRec)
                return true;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkMain, DigHdrBindingSource);
            bool validateRates = validCheck.checkAll(PanelControlRatesTab.Controls, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkRatesTab, DigHdrBindingSource);
            bool validatePassengers = validCheck.checkAll(PanelControlPassengersTab.Controls, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkPassengersTab, DigHdrBindingSource);
            bool validateGeneral = validCheck.checkAll(PanelControlGeneralTab.Controls, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkGeneralTab, DigHdrBindingSource);

            if (validateMain && validateRates && validatePassengers && validateGeneral)
                return validCheck.saveRec(ref modified, true, ref newRec, context, DigHdrBindingSource, this.Name, errorProvider1, Cursor);
            else
                return validCheck.saveRec(ref modified, false, ref newRec, context, DigHdrBindingSource, this.Name, errorProvider1, Cursor);
        }
     
        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            loadGrid();           
        }

        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

      

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            popupContainerControl1.OwnerEdit.ClosePopup();           
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            popupContainerControl1.OwnerEdit.CancelPopup();
        }

        private void gridSearchControl1_Enter(object sender, EventArgs e)
        {
            agencySearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp1;
        }

        void ButtonEdit_QueryPopUp1(object sender, CancelEventArgs e)
        {
            e.Cancel = false;    
        }

        private void gridSearchControl1_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl2.Text = DateTime.Today.ToShortDateString();
               
            }
            validCheck.check(sender, errorProvider1,((DIGHDR)DigHdrBindingSource.Current).checkAgyNo, DigHdrBindingSource);
            agencySearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp2;
        }

        void ButtonEdit_QueryPopUp2(object sender, CancelEventArgs e)
        {
            e.Cancel = true;

        }

        private void repositoryItemPopupContainerEdit1_QueryResultValue(object sender, QueryResultValueEventArgs e)
        {
            e.Value = gridView2.GetFocusedRowCellValue("RES_NO");    
        }

        private void repositoryItemPopupContainerEdit1_Click(object sender, EventArgs e)
        {
            string val = agencySearch.Text.TrimEnd();
            DateTime t = DateTime.Today.AddMonths(-1);
            gridControl3.DataSource = from c in context.RESHDR where c.AGY_NO == val && c.SERV_DTE >= t && c.Inactive == false select c;
        }

        private void advBandedGridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.FieldName == "COUP_RES" && view.IsFilterRow(e.RowHandle))
                e.RepositoryItem = repositoryItemPopupContainerEdit1;
        }    

        private void DigHdrForm_Load(object sender, EventArgs e)
        {
            loadGrid();
        }        

        private void loadGrid()
        {
            if (!string.IsNullOrWhiteSpace(cOUP_RESTextEdit.Text))
            {
                long val = Convert.ToInt64(cOUP_RESTextEdit.Text.TrimEnd());
                gridControl2.DataSource = from c in context.DIGITM where c.COUP_RES == val select c;
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (DigHdrBindingSource.Current == null)
            {
                DigHdrBindingSource.AddNew();

                agencySearch.Focus();
                agencySearch.ButtonEdit.Properties.ReadOnly = false;
                cOUP_RESTextEdit.Properties.ReadOnly = false;              
                newRec = true;
                return;
            }
            agencySearch.Focus();
            //bindingNavigatorPositionItem.Focus();  //trigger field leave event
            gridView1.CloseEditor();
            temp = newRec;
          
            if (checkForms())
            {
                errorProvider1.Clear();
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (DIGHDR)DigHdrBindingSource.Current);
                DigHdrBindingSource.AddNew();
                agencySearch.Focus();
                agencySearch.ButtonEdit.Properties.ReadOnly = false;
                cOUP_RESTextEdit.Properties.ReadOnly = false;
                newRec = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (DigHdrBindingSource.Current == null)
                return;
            gridView1.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                modified = false;
                newRec = false;
                DigHdrBindingSource.RemoveCurrent();
                errorProvider1.Clear();
                context.SaveChanges();
                agencySearch.ButtonEdit.Properties.ReadOnly = true;
                cOUP_RESTextEdit.Properties.ReadOnly = true;
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);

            }

            agencySearch.Focus();
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }

        private void dIGHDRBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (DigHdrBindingSource.Current == null)
                return;
            gridView1.CloseEditor();
            agencySearch.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            bool temp = newRec;
            if (checkForms())
            {
                errorProvider1.Clear();
                agencySearch.ButtonEdit.Properties.ReadOnly = true;
                cOUP_RESTextEdit.Properties.ReadOnly = true;

                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
            }

            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (DIGHDR)DigHdrBindingSource.Current);
               
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool move()
        {
            gridView1.CloseEditor();
            agencySearch.Focus();
           // bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                errorProvider1.Clear();
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (DIGHDR)DigHdrBindingSource.Current);
                agencySearch.ButtonEdit.Properties.ReadOnly = true;
                cOUP_RESTextEdit.Properties.ReadOnly = true;
                newRec = false;
                modified = false;
                return true;
            }
            return false;
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (move())
                DigHdrBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                DigHdrBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                DigHdrBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                DigHdrBindingSource.MoveLast();
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            temp = newRec;
            if (!temp && checkForms())
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (DIGHDR)DigHdrBindingSource.Current);

            agencySearch.ButtonEdit.Properties.ReadOnly = true;
            cOUP_RESTextEdit.Properties.ReadOnly = true;
        }

        private void DigHdrForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void cOUP_RESTextEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl7.Text = DateTime.Today.ToShortDateString();                
            }
            validCheck.check(sender, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkResNo, DigHdrBindingSource);
        }

        private void cOUP_MMComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl7.Text = DateTime.Today.ToShortDateString();                
            }

            validCheck.check(sender, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkMonth, DigHdrBindingSource);
        }

        private void cOUP_YRSpinEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl7.Text = DateTime.Today.ToShortDateString();               
            }

            validCheck.check(sender, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkYear, DigHdrBindingSource);
        }

        private void cOUP_CODTextEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl7.Text = DateTime.Today.ToShortDateString();                
            }
            validCheck.check(sender, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkCode, DigHdrBindingSource);
        }

        private void nBR_COUPONSSpinEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl7.Text = DateTime.Today.ToShortDateString();
              
            }
            validCheck.check(sender, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkNbrCoups, DigHdrBindingSource);
        }

        private void aGT_NAMETextEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl7.Text = DateTime.Today.ToShortDateString();
               
            }
            validCheck.check(sender, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkAgtName, DigHdrBindingSource);
        }

        private void aGY_NAMETextEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl7.Text = DateTime.Today.ToShortDateString();
                
            }
            validCheck.check(sender, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkAgyName, DigHdrBindingSource);
        }

        private void aGY_ADDRTextEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl7.Text = DateTime.Today.ToShortDateString();
                
            }
            validCheck.check(sender, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkAgyAddress, DigHdrBindingSource);
        }

        private void tYP_ROOMTextEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl7.Text = DateTime.Today.ToShortDateString();
                
            }
            validCheck.check(sender, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkRoomType, DigHdrBindingSource);
        }

        private void tYP_CABINTextEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl7.Text = DateTime.Today.ToShortDateString();
                
            }
            validCheck.check(sender, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkCabinType, DigHdrBindingSource);
        }

        private void pACKAGETextEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl7.Text = DateTime.Today.ToShortDateString();
                
            }
            validCheck.check(sender, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkPackageName, DigHdrBindingSource);
        }

        private void nBR_PAXSpinEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl7.Text = DateTime.Today.ToShortDateString();
                
            }
            validCheck.check(sender, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkPaxNum, DigHdrBindingSource);
        }

        private void pAX1_NAMETextEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl7.Text = DateTime.Today.ToShortDateString();
                
            }
            validCheck.check(sender, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkPaxName1, DigHdrBindingSource);
        }

        private void pAX2_NAMETextEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl7.Text = DateTime.Today.ToShortDateString();
               
            }
            validCheck.check(sender, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkPaxName2, DigHdrBindingSource);
        }

        private void pAX3_NAMETextEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl7.Text = DateTime.Today.ToShortDateString();
                
            }
            validCheck.check(sender, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkPaxName3, DigHdrBindingSource);
        }

        private void gLANDSpinEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl7.Text = DateTime.Today.ToShortDateString();
               
            }
            validCheck.check(sender, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkLandGross, DigHdrBindingSource);
        }

        private void gAIRpinEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl7.Text = DateTime.Today.ToShortDateString();
                
            }
            validCheck.check(sender, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkAirGross, DigHdrBindingSource);
        }

        private void gTELEXSpinEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl7.Text = DateTime.Today.ToShortDateString();
                
            }
            validCheck.check(sender, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkTelexGross, DigHdrBindingSource);
        }

        private void gINSURSpinEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl7.Text = DateTime.Today.ToShortDateString();
                
            }
            validCheck.check(sender, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkInsuranGross, DigHdrBindingSource);
        }

        private void gCRUISESpinEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl7.Text = DateTime.Today.ToShortDateString();
                
            }
            validCheck.check(sender, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkCruiseGross, DigHdrBindingSource);
        }

        private void gTAXESSpinEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl7.Text = DateTime.Today.ToShortDateString();
                
            }
            validCheck.check(sender, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkTaxesGross, DigHdrBindingSource);
        }

        private void gMISCSpinEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl7.Text = DateTime.Today.ToShortDateString();
                
            }
            validCheck.check(sender, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkMiscGross, DigHdrBindingSource);
        }

        private void nETLANDSpinEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl7.Text = DateTime.Today.ToShortDateString();
                
            }
            validCheck.check(sender, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkLandNet, DigHdrBindingSource);
        }

        private void nETAIRpinEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl7.Text = DateTime.Today.ToShortDateString();
                
            }
            validCheck.check(sender, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkAirNet, DigHdrBindingSource);
        }

        private void nTELEXSpinEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl7.Text = DateTime.Today.ToShortDateString();
               
            }
            validCheck.check(sender, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkTelexNet, DigHdrBindingSource);
        }

        private void nETINSURSpinEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl7.Text = DateTime.Today.ToShortDateString();
              
            }
            validCheck.check(sender, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkInsuranNet, DigHdrBindingSource);
        }

        private void nCRUISESpinEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl7.Text = DateTime.Today.ToShortDateString();
              
            }
            validCheck.check(sender, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkCruiseNet, DigHdrBindingSource);
        }

        private void nETTAXESSpinEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl7.Text = DateTime.Today.ToShortDateString();
              
            }
            validCheck.check(sender, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkTaxesNet, DigHdrBindingSource);
        }

        private void nETMISCSpinEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl7.Text = DateTime.Today.ToShortDateString();
               
            }
            validCheck.check(sender, errorProvider1, ((DIGHDR)DigHdrBindingSource.Current).checkMiscNet, DigHdrBindingSource);
        }

        private void advBandedGridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            //if (DigHdrBindingSource.Current == null)
            //{
            //    e.Allow = true;
            //    return;
            //}

            //temp = newRec;
            //bool temp2 = modified;
            //if (checkForms())
            //{
            //    errorProvider1.Clear();
            //    e.Allow = true;  if (!temp && !modified)
           // context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (DIGHDR)DigHdrBindingSource.Current);
           
            //    if ((!temp) && temp2)
            //        context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (DIGHDR)DigHdrBindingSource.Current);


            //    agencySearch.ButtonEdit.Properties.ReadOnly = true;
            //    cOUP_RESTextEdit.Properties.ReadOnly = true;
              
            //}
            //else
            //    e.Allow = false;
            if (DigHdrBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (DIGHDR)DigHdrBindingSource.Current);


              
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (DIGHDR)DigHdrBindingSource.Current);

                e.Allow = false;

            }
        }

        private void advBandedGridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!AdvBandedGridViewDigHdr.IsFilterRow(e.RowHandle))
            {
                modified = true;
                labelControl7.Text = DateTime.Today.ToShortDateString();
            }
            
        }

        private void advBandedGridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; 
        }

        private void DigHdrBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            loadGrid();
        }

        private void DigHdrBindingSource_PositionChanged(object sender, EventArgs e)
        {
            loadGrid();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string coupm = cOUP_MMComboBoxEdit.Text;
            string coupy = cOUP_YRSpinEdit.Text;
            string coupc = cOUP_CODTextEdit.Text;
            int wtf = gridView1.RowCount + 1;
            int line = wtf * 5;
            string val = cOUP_RESTextEdit.Text.TrimEnd();
            DigItmForm xform1 = new DigItmForm(val, context, line, username, coupm, coupy, coupc) { };
            xform1.Show();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("wtf");
            DeleteRow(gridView2);
            //int currentRow;
            //currentRow = gridView2.FocusedRowHandle;
            //if (currentRow < 0)
            //    currentRow = gridView2.GetDataRowHandleByGroupRowHandle(currentRow);
            //gridView2.DeleteRow(currentRow);

            //if (gridView2.SortInfo.GroupCount == 0) return;

            //foreach (DevExpress.XtraGrid.Columns.GridColumn groupColumn in gridView2.GroupedColumns)
            //{
            //    object val = gridView2.GetRowCellValue(currentRow, groupColumn);
            //    gridView2.SetRowCellValue(gridView2.FocusedRowHandle, groupColumn, val);
            //}
            //gridView2.UpdateCurrentRow();
            //gridView2.ShowEditor();

            //gridView2.DeleteRow(gridView2.FocusedRowHandle);


            //int currentRow;
            //currentRow = view.FocusedRowHandle;
            //if (currentRow < 0)
            //    currentRow = view.GetDataRowHandleByGroupRowHandle(currentRow);
            //view.DeleteRow(currentRow);

            //if (view.SortInfo.GroupCount == 0) return;

            //foreach (DevExpress.XtraGrid.Columns.GridColumn groupColumn in view.GroupedColumns)
            //{
            //    object val = view.GetRowCellValue(currentRow, groupColumn);
            //    view.SetRowCellValue(view.FocusedRowHandle, groupColumn, val);
            //}
            //view.UpdateCurrentRow();
            //view.ShowEditor();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            string line = gridView1.GetFocusedRowCellValue("LINE_NO").ToString();
            string val = cOUP_RESTextEdit.Text.TrimEnd();
            DigItmForm xform1 = new DigItmForm(val, context, line, username) { };
            xform1.Show();
        }
        void DeleteRow(GridView view)
        {
            int currentRow;
            currentRow = view.FocusedRowHandle;
            if (currentRow < 0)
                currentRow = view.GetDataRowHandleByGroupRowHandle(currentRow);
            view.DeleteRow(currentRow);

            if (view.SortInfo.GroupCount == 0) return;

            foreach (DevExpress.XtraGrid.Columns.GridColumn groupColumn in view.GroupedColumns)
            {
                object val = view.GetRowCellValue(currentRow, groupColumn);
                view.SetRowCellValue(view.FocusedRowHandle, groupColumn, val);
            }
            view.UpdateCurrentRow();
            view.ShowEditor();
        }

        private void DigHdrForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && AdvBandedGridViewDigHdr.IsFilterRow(AdvBandedGridViewDigHdr.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = AdvBandedGridViewDigHdr.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(AdvBandedGridViewDigHdr.GetFocusedDisplayText()))
                value = AdvBandedGridViewDigHdr.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.AGY_NO like '{0}%'", AdvBandedGridViewDigHdr.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "AGY_NO"));
                var special = context.DIGHDR.Where(query);
               
                if (!string.IsNullOrWhiteSpace(AdvBandedGridViewDigHdr.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "COUP_RES")))
                {
                    query = String.Format("it.{0} like '{1}%'", "COUP_RES", AdvBandedGridViewDigHdr.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "COUP_RES"));
                    special = special.Where(query);
                }

                int count = special.Count();
                if (count > 0)
                {
                    DigHdrBindingSource.DataSource = special;
                    AdvBandedGridViewDigHdr.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                    AdvBandedGridViewDigHdr.FocusedRowHandle = 0;
                    AdvBandedGridViewDigHdr.FocusedColumn.FieldName = colName;
                    AdvBandedGridViewDigHdr.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    AdvBandedGridViewDigHdr.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }
    
    }
}