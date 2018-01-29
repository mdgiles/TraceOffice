using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Reflection;
using System.Data.Linq;
using System.Data.Entity.Core.Objects;
using System.Windows.Forms;
using FlexModel;
using System.ComponentModel;
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
    
    public partial class SvcRestr2Form : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        const string colName1 = "colCODE";
        public string username;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public FlextourEntities context;
        public SvcRestr2Form(FlexCore.CoreSys _sys)
        {
            InitializeComponent();
            Connection.EFConnectionString = _sys.Settings.EFConnectionString;
            context = new FlextourEntities( _sys.Settings.EFConnectionString);
            modified = false;
            newRec = false;
            hotelSearch.ButtonEdit.Properties.ReadOnly = true;
            gsLoad.gridSearchLoad(codeSearch, "CODE", "NAME", "Code", "Name", "CODE", "CODE", "CODE", SvcRestr2BindingSource, "CODE");
            gsLoad.gridSearchLoad(agyLevelSearch, "SvcRLevel_ID_Agency", "Description", "SvcRLevel_ID_Agency", "SvcRLevel_ID_Agency", "SvcRLevel_ID_Agency", SvcRestr2BindingSource, "SvcRLevel_ID_Agency");
            gsLoad.gridSearchLoad(prodLevelSearch, "SvcRLevel_ID_Product", "Description", "SvcRLevel_ID_Product", "SvcRLevel_ID_Product", "SvcRLevel_ID_Product", SvcRestr2BindingSource, "SvcRLevel_ID_Product");
            gsLoad.gridSearchLoad(agencySearch, "NO", "NAME", "Code", "Name", "NO", "NO", "NO", SvcRestr2BindingSource, "AGENCY");
            agencySearch.GridControl.DataSource = context.AGY;
            //agyLevelSearch.GridControl.DataSource = from c in context.CommLevel where c.Type == "AGY" select c;
            prodLevelSearch.ButtonEdit.TextChanged += ButtonEdit_TextChanged1;
            agyLevelSearch.ButtonEdit.TextChanged += ButtonEdit_TextChanged3;
            gsLoad.gridSearchLoad(catSearch, "CODE", "DESC", "Code", "Name", "CODE", "CODE", "CODE", SvcRestr2BindingSource, "CAT");
            catSearch.GridControl.DataSource = context.ROOMCOD;           
              
            username = _sys.User.Name;            
            SvcRestr2BindingSource.DataSource = context.SVCRESTR2;
            ((SVCRESTR2)SvcRestr2BindingSource.Current).lookupTable = labelControl2.Text;
        }

     
        void ButtonEdit_TextChanged3(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(agencySearch.Text))
            {
                int value = Convert.ToInt32(agyLevelSearch.Text);
                var result = (from c in context.SvcRLevel where c.ID == value select c).Distinct();
                foreach (var val in result)
                {
                    gsLoad.gridSearchLoad(agencySearch, "Description", "Description", "Description", "Description", "Description");
                    labelControl4.Text = val.Lookup_Table.TrimEnd();
                    IQueryable load = (IQueryable)(context.GetType().GetProperty(val.Lookup_Table.TrimEnd()).GetValue(context, null));
                    agencySearch.GridControl.DataSource = load;
                }
            }
        }



        void ButtonEdit_TextChanged1(object sender, EventArgs e)
        {
            int value;

            if (!string.IsNullOrWhiteSpace(prodLevelSearch.Text))
            {
                value = Convert.ToInt32(prodLevelSearch.Text);
                var result = (from c in context.SvcRLevel where c.ID == value select c).Distinct();

                foreach (var f in result)
                {
                    if (!string.IsNullOrWhiteSpace(f.Lookup_Table))
                    {

                        if (f.Lookup_Table.TrimEnd() == "AGY")
                        {
                            gsLoad.gridSearchLoad(codeSearch, "NO", "NAME", "Code", "Name", "NO", "NO", "NAME", SvcRestr2BindingSource, "CODE");
                            labelControl2.Text = f.Lookup_Table.TrimEnd();
                            ((SVCRESTR2)SvcRestr2BindingSource.Current).lookupTable = labelControl2.Text;
                            IQueryable load = (IQueryable)(context.GetType().GetProperty(f.Lookup_Table.TrimEnd()).GetValue(context, null));
                            codeSearch.GridControl.DataSource = load;
                        }
                        else
                        {
                            if (f.Lookup_Table.TrimEnd() == "REGION")
                                gsLoad.gridSearchLoad(codeSearch, "CODE", "DESC", "Code", "Name", "CODE", "CODE", "CODE", SvcRestr2BindingSource, "CODE");
                            else
                                gsLoad.gridSearchLoad(codeSearch, "CODE", "NAME", "Code", "Name", "CODE", "CODE", "CODE", SvcRestr2BindingSource, "CODE");

                            labelControl2.Text = f.Lookup_Table.TrimEnd();
                            ((SVCRESTR2)SvcRestr2BindingSource.Current).lookupTable = labelControl2.Text;
                            IQueryable load1 = (IQueryable)(context.GetType().GetProperty(f.Lookup_Table.TrimEnd()).GetValue(context, null));
                            if (!string.IsNullOrWhiteSpace(f.Link_Rectype))
                                codeSearch.GridControl.DataSource = load1.Where("RECTYPE = @0", f.Link_Rectype.TrimEnd());
                            else
                                codeSearch.GridControl.DataSource = load1;
                        }
                    }
                    else
                    {
                        labelControl2.Text = "CODE";
                        ((SVCRESTR2)SvcRestr2BindingSource.Current).lookupTable = labelControl2.Text;

                    }
                }
            }
        }

        private void tYPEComboBoxEdit_TextChanged(object sender, EventArgs e)
        {
            codeSearch.GridControl.DataSource = null;
            gsLoad.gridSearchLoad(codeSearch, "CODE", "NAME", "Code", "Name", "CODE", "CODE", "CODE", SvcRestr2BindingSource, "CODE");
           
            if (ComboBoxEditType.Text == "HTL")
            {
                fieldClear();

                prodLevelSearch.ButtonEdit.Properties.ReadOnly = false;
                codeSearch.ButtonEdit.Properties.ReadOnly = false;
                prodLevelSearch.GridControl.DataSource = from c in context.SvcRLevel where c.Type == "HTL" select c;
                codeSearch.GridControl.DataSource =  context.HOTEL;
                
            }
            if (ComboBoxEditType.Text == "PKG")
            {
                //pack
                fieldClear();

                prodLevelSearch.ButtonEdit.Properties.ReadOnly = false;
                codeSearch.ButtonEdit.Properties.ReadOnly = false;
                prodLevelSearch.GridControl.DataSource = from c in context.SvcRLevel where c.Type == "PKG" select c;
                codeSearch.GridControl.DataSource =  context.PACK ;
                
            }
            if (ComboBoxEditType.Text == "AIR")
            {//air
                fieldClear();

                prodLevelSearch.ButtonEdit.Properties.ReadOnly = false;
                codeSearch.ButtonEdit.Properties.ReadOnly = false;
                prodLevelSearch.GridControl.DataSource = from c in context.SvcRLevel where c.Type == "AIR" select c;
                codeSearch.GridControl.DataSource = context.AIR;
               
            }
            if (ComboBoxEditType.Text == "CAR")
            {//carinfo

                fieldClear();
                prodLevelSearch.ButtonEdit.Properties.ReadOnly = false;
                codeSearch.ButtonEdit.Properties.ReadOnly = false;
                prodLevelSearch.GridControl.DataSource = from c in context.SvcRLevel where c.Type == "CAR" select c;
                codeSearch.GridControl.DataSource = context.CARINFO;
               
            }
            if (ComboBoxEditType.Text == "OPT")
            {//comp
                fieldClear();

                prodLevelSearch.ButtonEdit.Properties.ReadOnly = false;
                codeSearch.ButtonEdit.Properties.ReadOnly = false;
                prodLevelSearch.GridControl.DataSource = from c in context.SvcRLevel where c.Type == "OPT" select c;
                codeSearch.GridControl.DataSource = context.COMP;
              
            }
            if (ComboBoxEditType.Text == "CRU")
            {//cru
                fieldClear();

                prodLevelSearch.ButtonEdit.Properties.ReadOnly = false;
                codeSearch.ButtonEdit.Properties.ReadOnly = false;
                prodLevelSearch.GridControl.DataSource = from c in context.SvcRLevel where c.Type == "CRU" select c;
                codeSearch.GridControl.DataSource = context.CRU;
                
            }
            if (ComboBoxEditType.Text == "AGY")
            {
                fieldClear();

                prodLevelSearch.ButtonEdit.Properties.ReadOnly = true;
                codeSearch.ButtonEdit.Properties.ReadOnly = true;
                


            }
        }
        private void fieldClear()
        {
            if (newRec == true)
            {
                labelControl2.Text = "CODE";
                labelControl4.Text = "Agency";
                ((SVCRESTR2)SvcRestr2BindingSource.Current).lookupTable = labelControl2.Text;
                agencySearch.ButtonEdit.Text = "";
                agyLevelSearch.ButtonEdit.Text = "";
                codeSearch.ButtonEdit.Text = "";
                prodLevelSearch.ButtonEdit.Text = "";
                hotelSearch.ButtonEdit.Text = "";
                catSearch.ButtonEdit.Text = "";
                sTART_DATEDateEdit.Text = "";
                resDate_StartDateEdit.Text = "";
                eND_DATEDateEdit.Text = "";
                resDate_EndDateEdit.Text = "";
            }


        }

        private void gridSearchControl1_Enter(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
            prodLevelSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp1;
        }

        void ButtonEdit_QueryPopUp1(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
        }

        private void gridSearchControl2_Enter(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
            codeSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp1;
        }

        private void gridSearchControl3_Enter(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
            agyLevelSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp1;
        }

        private void gridSearchControl4_Enter(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
            agencySearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp1;
        }

        private void gridSearchControl5_Load(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
            hotelSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp1;
        }

        private void gridSearchControl6_Enter(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
            catSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp1;
        }

        private void overlappingRatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var load = from c in context.SVCRESTR2 where   c.START_DATE >= Convert.ToDateTime(sTART_DATEDateEdit.Text) && c.END_DATE <= Convert.ToDateTime(eND_DATEDateEdit.Text) && c.START_DATE <= Convert.ToDateTime(eND_DATEDateEdit.Text) && c.END_DATE >= Convert.ToDateTime(sTART_DATEDateEdit.Text) select c;
            if (load.Count() < 2)
                MessageBox.Show("No overlapping rate sheets exist.");
            else
            {
                gridControl2.DataSource = load;
                popupContainerControl1.Show();
            }
        }

        private bool checkForms()
        {
            if (!modified && !newRec)
                return true;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((SVCRESTR2)SvcRestr2BindingSource.Current).checkAll, SvcRestr2BindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, SvcRestr2BindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, SvcRestr2BindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (SvcRestr2BindingSource.Current == null)
            {
                SvcRestr2BindingSource.AddNew();
                //codeTextEdit.Focus();
                //codeTextEdit.Properties.ReadOnly = false;
                //gridView1.Columns.ColumnByName(colName1).OptionsColumn.AllowEdit = true;
                newRec = true;
                return;
            }
            ComboBoxEditType.Focus();
            //bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewSvcRest.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (SVCRESTR2)SvcRestr2BindingSource.Current);
                SvcRestr2BindingSource.AddNew();
                //codeTextEdit.Focus();
                //codeTextEdit.Properties.ReadOnly = false;
                //gridView1.Columns.ColumnByName(colName1).OptionsColumn.AllowEdit = true;
                newRec = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (SvcRestr2BindingSource.Current == null)
                return;
            GridViewSvcRest.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                modified = false;
                newRec = false;
                SvcRestr2BindingSource.RemoveCurrent();
                errorProvider1.Clear();
                context.SaveChanges();
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);

            }
            //currentVal = codeTextEdit.Text;
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }

        private void sVCRESTR2BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (SvcRestr2BindingSource.Current == null)
                return;

            GridViewSvcRest.CloseEditor();
            ComboBoxEditType.Focus();
            bool temp = newRec;
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            if (checkForms())
            {
                //codeTextEdit.Focus();
                //codeTextEdit.Properties.ReadOnly = true;
                //gridView1.Columns.ColumnByName(colName1).OptionsColumn.AllowEdit = false;
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;

            }

            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (SVCRESTR2)SvcRestr2BindingSource.Current);
            
        }


        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool move()
        {

            GridViewSvcRest.CloseEditor();
            ComboBoxEditType.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (SVCRESTR2)SvcRestr2BindingSource.Current);
                //codeTextEdit.Properties.ReadOnly = true;
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
                SvcRestr2BindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                SvcRestr2BindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                SvcRestr2BindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                SvcRestr2BindingSource.MoveLast();
        }

        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (SvcRestr2BindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (SVCRESTR2)SvcRestr2BindingSource.Current);
                //codeTextEdit.Properties.ReadOnly = true;
                //gridView1.Columns.ColumnByName(colName1).OptionsColumn.AllowEdit = false;
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (SVCRESTR2)SvcRestr2BindingSource.Current);
         
                e.Allow = false;
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            if (!GridViewSvcRest.IsFilterRow(e.RowHandle))
                modified = true;
            labelControl8.Text = DateTime.Today.ToShortDateString(); ;
            labelControl10.Text = username;
            
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; 
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            temp = newRec;
            ((SVCRESTR2)SvcRestr2BindingSource.Current).lookupTable = labelControl2.Text;
            if (!temp && checkForms())
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (SVCRESTR2)SvcRestr2BindingSource.Current);
            //codeTextEdit.Properties.ReadOnly = true;
            //gridView1.Columns.ColumnByName(colName1).OptionsColumn.AllowEdit = false;
        }

        private void SvcRestr2Form_FormClosing(object sender, FormClosingEventArgs e)
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

        private void gridSearchControl1_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl8.Text = DateTime.Today.ToShortDateString(); ;
                labelControl10.Text = username;
            }
            //validCheck.check(sender, errorProvider1, ((SVCRESTR2)sVCRESTR2BindingSource.Current).checkName, sVCRESTR2BindingSource); 
        }

        private void gridSearchControl1_ItemSelected()
        {
            prodLevelSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp1;
        }

        private void gridSearchControl2_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl8.Text = DateTime.Today.ToShortDateString(); ;
                labelControl10.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((SVCRESTR2)SvcRestr2BindingSource.Current).checkCode, SvcRestr2BindingSource); 
        }

        private void gridSearchControl2_ItemSelected()
        {
            codeSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp1;
        }

        private void gridSearchControl3_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl8.Text = DateTime.Today.ToShortDateString(); ;
                labelControl10.Text = username;
            }
            //validCheck.check(sender, errorProvider1, ((SVCRESTR2)sVCRESTR2BindingSource.Current).checkName, sVCRESTR2BindingSource); 
        }

        private void gridSearchControl3_ItemSelected()
        {
            agyLevelSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp1;
        }

        private void gridSearchControl4_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl8.Text = DateTime.Today.ToShortDateString(); ;
                labelControl10.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((SVCRESTR2)SvcRestr2BindingSource.Current).checkAgency, SvcRestr2BindingSource); 
        }

        private void gridSearchControl4_ItemSelected()
        {
            agencySearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp1;
        }

        private void gridSearchControl5_Enter(object sender, EventArgs e)
        {
            hotelSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp1;
        }

        private void gridSearchControl5_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl8.Text = DateTime.Today.ToShortDateString(); ;
                labelControl10.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((SVCRESTR2)SvcRestr2BindingSource.Current).checkHotel, SvcRestr2BindingSource); 
        }

        private void gridSearchControl5_ItemSelected()
        {
            hotelSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp1;
        }

        private void gridSearchControl6_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl8.Text = DateTime.Today.ToShortDateString(); ;
                labelControl10.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((SVCRESTR2)SvcRestr2BindingSource.Current).checkCat, SvcRestr2BindingSource); 
        }

        private void gridSearchControl6_ItemSelected()
        {
            catSearch.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp1;
        }

        private void tYPEComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl8.Text = DateTime.Today.ToShortDateString(); ;
                labelControl10.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((SVCRESTR2)SvcRestr2BindingSource.Current).checkType, SvcRestr2BindingSource); 
        }

        private void sTART_DATEDateEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl8.Text = DateTime.Today.ToShortDateString(); ;
                labelControl10.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((SVCRESTR2)SvcRestr2BindingSource.Current).checkStart, SvcRestr2BindingSource); 
        }

        private void resDate_StartDateEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl8.Text = DateTime.Today.ToShortDateString(); ;
                labelControl10.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((SVCRESTR2)SvcRestr2BindingSource.Current).checkResStart, SvcRestr2BindingSource); 
        }

        private void eND_DATEDateEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl8.Text = DateTime.Today.ToShortDateString(); ;
                labelControl10.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((SVCRESTR2)SvcRestr2BindingSource.Current).checkEnd, SvcRestr2BindingSource); 
        }

        private void resDate_EndDateEdit_Leave(object sender, EventArgs e)
        {
            if (currentVal != ((Control)sender).Text)
            {
                modified = true;
                labelControl8.Text = DateTime.Today.ToShortDateString(); ;
                labelControl10.Text = username;
            }
            validCheck.check(sender, errorProvider1, ((SVCRESTR2)SvcRestr2BindingSource.Current).checkResEnd, SvcRestr2BindingSource); 
        }

        private void inactiveCheckEdit_CheckStateChanged(object sender, EventArgs e)
        {
            modified = true;
            labelControl8.Text = DateTime.Today.ToShortDateString(); ;
            labelControl10.Text = username;            
        }

    

        private void sTART_DATEDateEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void sTART_DATEDateEdit_TextChanged(object sender, EventArgs e)
        {
            sTART_DATEDateEdit.Text = validCheck.convertDate(sTART_DATEDateEdit.Text);
        }

        private void resDate_StartDateEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void resDate_StartDateEdit_TextChanged(object sender, EventArgs e)
        {
            resDate_StartDateEdit.Text = validCheck.convertDate(resDate_StartDateEdit.Text);
        }

        private void eND_DATEDateEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void eND_DATEDateEdit_TextChanged(object sender, EventArgs e)
        {
            eND_DATEDateEdit.Text = validCheck.convertDate(eND_DATEDateEdit.Text);
        }

        private void resDate_EndDateEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void resDate_EndDateEdit_TextChanged(object sender, EventArgs e)
        {
            resDate_EndDateEdit.Text = validCheck.convertDate(resDate_EndDateEdit.Text);
        }

        private void SvcRestr2Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewSvcRest.IsFilterRow(GridViewSvcRest.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewSvcRest.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewSvcRest.GetFocusedDisplayText()))
                value = GridViewSvcRest.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.TYPE like '{0}%'", GridViewSvcRest.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "TYPE"));
                var special = context.SVCRESTR.Where(query);


                if (!string.IsNullOrWhiteSpace(GridViewSvcRest.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE")))
                {
                    query = String.Format("it.{0} like '{1}%'", "CODE", GridViewSvcRest.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                    special = special.Where(query);
                }
                int count = special.Count();
                if (count > 0)
                {
                    SvcRestr2BindingSource.DataSource = special;
                    GridViewSvcRest.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                    GridViewSvcRest.FocusedRowHandle = 0;
                    GridViewSvcRest.FocusedColumn.FieldName = colName;
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewSvcRest.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }
      
      
    }
}