using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using FlexModel;
using DevExpress.XtraEditors.Controls;
using System.Linq;
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
    public partial class SvcRestForm : DevExpress.XtraEditors.XtraForm
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
        public ImageComboBoxItemCollection hotelVals;
        public ImageComboBoxItemCollection compVals;
       
        public ImageComboBoxItemCollection airVals;
        public ImageComboBoxItemCollection cruVals;
        public ImageComboBoxItemCollection carVals;
        public ImageComboBoxItemCollection pkgVals;
        public SvcRestForm(FlexInterfaces.Core.ICoreSys sys)
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
            hotelVals = new ImageComboBoxItemCollection(ImageComboBoxEditCode.Properties);
            compVals = new ImageComboBoxItemCollection(ImageComboBoxEditCode.Properties);
            cruVals = new ImageComboBoxItemCollection(ImageComboBoxEditCode.Properties);
            airVals = new ImageComboBoxItemCollection(ImageComboBoxEditCode.Properties);
            carVals = new ImageComboBoxItemCollection(ImageComboBoxEditCode.Properties);
            pkgVals = new ImageComboBoxItemCollection(ImageComboBoxEditCode.Properties);
          
            setReadOnly(true);
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxEditAgency.Properties.Items.Add(loadBlank);

            var air = from airRec in context.AIR orderby airRec.CODE ascending select new { airRec.CODE, airRec.NAME };
            var pck = from pckRec in context.PACK orderby pckRec.CODE ascending select new { pckRec.CODE, pckRec.NAME };
            var agy = from agyRec in context.AGY orderby agyRec.NO ascending select new { agyRec.NO, agyRec.NAME };
            var hotel = from hotRec in context.HOTEL orderby hotRec.CODE ascending select new { hotRec.CODE, hotRec.NAME };
            var comp = from compRec in context.COMP orderby compRec.CODE ascending select new { compRec.CODE, compRec.NAME };
            var cru = from cruRec in context.CRU orderby cruRec.CODE ascending select new { cruRec.CODE, cruRec.NAME };
            var car = from carRec in context.CARINFO orderby carRec.CODE ascending select new { carRec.CODE, carRec.NAME };
            var airports = from portRec in context.Airport orderby portRec.Code ascending select new { portRec.Code, portRec.Name };

            foreach (var result in pck)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                pkgVals.Add(load);
                //ImageComboBoxEditOperator.Properties.Items.Add(load);
            }

            foreach (var result in hotel)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                hotelVals.Add(load);
                //ImageComboBoxEditOperator.Properties.Items.Add(load);
            }

            foreach (var result in comp)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                compVals.Add(load);
                //ImageComboBoxEditOperator.Properties.Items.Add(load);
            }

            foreach (var result in car)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                carVals.Add(load);
                //ImageComboBoxEditOperator.Properties.Items.Add(load);
            }

            foreach (var result in air)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                airVals.Add(load);
                //ImageComboBoxEditOperator.Properties.Items.Add(load);
            }

            foreach (var result in cru)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                cruVals.Add(load);
                //ImageComboBoxEditOperator.Properties.Items.Add(load);
            }
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

        void setReadOnly(bool value)
        {
            ImageComboBoxEditCode.Properties.ReadOnly = value;
            ImageComboBoxEditAgency.Properties.ReadOnly = value;
            ComboBoxEditType.Properties.ReadOnly = value;
        }

        private void tYPEComboBoxEdit_TextChanged(object sender, System.EventArgs e)
        {
            ImageComboBoxEditCode.Properties.Items.Clear();
            if (ComboBoxEditType.Text == "OPT")
            {
                ImageComboBoxEditCode.Properties.Items.AddRange(compVals);
            }
            if (ComboBoxEditType.Text == "HTL")
            {
                ImageComboBoxEditCode.Properties.Items.AddRange(hotelVals);
            }
            if (ComboBoxEditType.Text == "PKG")
            {
                ImageComboBoxEditCode.Properties.Items.AddRange(pkgVals);
            }
            if (ComboBoxEditType.Text == "CAR")
            {
                ImageComboBoxEditCode.Properties.Items.AddRange(carVals);
            }
            if (ComboBoxEditType.Text == "CRU")
            {
                ImageComboBoxEditCode.Properties.Items.AddRange(cruVals);
            }
            if (ComboBoxEditType.Text == "AIR")
            {
                ImageComboBoxEditCode.Properties.Items.AddRange(airVals);
            }
        }

        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        private void SvcRestForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewSvcRestr.IsFilterRow(GridViewSvcRestr.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewSvcRestr.FocusedColumn.FieldName;
            string value = String.Empty;

            if (!string.IsNullOrWhiteSpace(GridViewSvcRestr.GetFocusedDisplayText()))
                value = GridViewSvcRestr.GetFocusedDisplayText();

            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.CODE like '{0}%'", GridViewSvcRestr.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                var special = context.SVCRESTR.Where(query);

                if (!string.IsNullOrWhiteSpace(GridViewSvcRestr.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "TYPE")))
                {
                    query = String.Format("it.{0} like '{1}%'", "TYPE", GridViewSvcRestr.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "TYPE"));
                    special = special.Where(query);
                }

                if (!string.IsNullOrWhiteSpace(GridViewSvcRestr.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "AGENCY")))
                {
                    query = String.Format("it.{0} like '{1}%'", "AGENCY", GridViewSvcRestr.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "AGENCY"));
                    special = special.Where(query);
                }

                int count = special.Count();
                if (count > 0)
                {
                    SvcRestrBindingSource.DataSource = special;
                    GridViewSvcRestr.FocusedRowHandle = 0;
                    GridViewSvcRestr.FocusedColumn.FieldName = colName;
                    GridViewSvcRestr.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewSvcRestr.ClearColumnsFilter();
                    //this should be final
                }
            }
            this.Cursor = Cursors.Default;
        }

        private bool checkForms()
        {
            if (!modified && !newRec)
                return true;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((SVCRESTR)SvcRestrBindingSource.Current).checkAll, SvcRestrBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, SvcRestrBindingSource, Name, errorProvider1,  Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, SvcRestrBindingSource, Name, errorProvider1,  Cursor);
                return false;
            }
        }

        private void setValues()
        {
            GridViewSvcRestr.SetFocusedRowCellValue("CODE", string.Empty);
            GridViewSvcRestr.SetFocusedRowCellValue("AGENCY", string.Empty);
            GridViewSvcRestr.SetFocusedRowCellValue("TYPE", string.Empty);
             
        }

        private void bindingNavigatorAddNewItem_Click(object sender, System.EventArgs e)
        {
            GridViewSvcRestr.ClearColumnsFilter();
            if (SvcRestrBindingSource.Current == null)
            {
                SvcRestrBindingSource.DataSource = from packrec in context.SVCRESTR where packrec.CODE == "KJM987" select packrec;

                SvcRestrBindingSource.AddNew();
                if (GridViewSvcRestr.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewSvcRestr.FocusedRowHandle = GridViewSvcRestr.RowCount - 1;

                ComboBoxEditType.Focus();
                newRec = true;
                setReadOnly(false);
                setValues();
                return;
            }
            ComboBoxEditType.Focus();
            //bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewSvcRestr.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                errorProvider1.Clear();
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (SVCRESTR)SvcRestrBindingSource.Current);
                SvcRestrBindingSource.AddNew();
                if (GridViewSvcRestr.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewSvcRestr.FocusedRowHandle = GridViewSvcRestr.RowCount - 1;
                ComboBoxEditType.Focus();

                newRec = true;
                setValues();
                setReadOnly(false);
            }         
            
        }

        private void bindingNavigatorDeleteItem_Click(object sender, System.EventArgs e)
        {
            if (SvcRestrBindingSource.Current == null)
                return;
            GridViewSvcRestr.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                modified = false;
                newRec = false;
                SvcRestrBindingSource.RemoveCurrent();
                errorProvider1.Clear();
                context.SaveChanges();
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);
                ImageComboBoxEditCode.Focus();
                currentVal = ImageComboBoxEditCode.Text;
                setReadOnly(true);
                modified = false;
                newRec = false;
            }
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }
        private bool checkRestrCode()
        {
            string code = ImageComboBoxEditCode.EditValue.ToString();
            if (ComboBoxEditType.Text == "HTL")
            {
                if ((from hotRec in context.HOTEL where hotRec.CODE == code && hotRec.RSTR_CDE == "A" select hotRec).Count() == 0)
                    return false;
            }
            if (ComboBoxEditType.Text == "OPT")
            {
                if ((from compRec in context.COMP where compRec.CODE == code && compRec.RSTR_CDE == "A" select compRec).Count() == 0)
                    return false;
            }
            if (ComboBoxEditType.Text == "PKG")
            {
                if ((from packRec in context.PACK where packRec.CODE == code && packRec.RSTR_CDE == "A" select packRec).Count() == 0)
                    return false;
            }
            if (ComboBoxEditType.Text == "CAR")
            {
                if ((from carRec in context.CARINFO where carRec.CODE == code && carRec.RSTR_CDE == "A" select carRec).Count() == 0)
                    return false;
            }
            if (ComboBoxEditType.Text == "CRU")
            {
                if ((from cruRec in context.CRU where cruRec.CODE == code && cruRec.RESTR_CDE == "A" select cruRec).Count() == 0)
                    return false;
            }
            if (ComboBoxEditType.Text == "AIR")
            {
                if ((from airRec in context.AIR where airRec.CODE == code && airRec.RESTR_CDE == "A" select airRec).Count() == 0)
                    return false;
            }
            return true;
        }
        private void sVCRESTR2BindingNavigatorSaveItem_Click(object sender, System.EventArgs e)
        {
            GridViewSvcRestr.ClearColumnsFilter();
            if (SvcRestrBindingSource.Current == null)
                return;

            if (!checkRestrCode())
            {
                MessageBox.Show("The restriction code for this property/service must be set to ‘A’ (agency) in order to save a record in the service restriction file.");
                return;
            }
            GridViewSvcRestr.CloseEditor();
            ComboBoxEditType.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            bool temp = newRec;
            if (checkForms())
            {

                ImageComboBoxEditCode.Focus();
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
                setReadOnly(true);
            }
            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (SVCRESTR)SvcRestrBindingSource.Current);

        }

        private void ComboBoxEditType_Leave(object sender, System.EventArgs e)
        {
            if (SvcRestrBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;

                validCheck.check(sender, errorProvider1, ((SVCRESTR)SvcRestrBindingSource.Current).checkType, SvcRestrBindingSource);
            }
        }

        private void ImageComboBoxEditCode_Leave(object sender, System.EventArgs e)
        {
            if (SvcRestrBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;

                validCheck.check(sender, errorProvider1, ((SVCRESTR)SvcRestrBindingSource.Current).checkCode, SvcRestrBindingSource);
            }
        }

        private void ImageComboBoxEditAgency_Leave(object sender, System.EventArgs e)
        {
            if (SvcRestrBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;

                validCheck.check(sender, errorProvider1, ((SVCRESTR)SvcRestrBindingSource.Current).checkAgency, SvcRestrBindingSource);
            }
        }


        private bool move()
        {

            GridViewSvcRestr.CloseEditor();
            ComboBoxEditType.Focus();
           // bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                errorProvider1.Clear();

                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (SVCRESTR)SvcRestrBindingSource.Current);

                setReadOnly(true);
                newRec = false;
                modified = false;
                return true;
            }
            return false;
        }


        private void bindingNavigatorMoveNextItem_Click(object sender, System.EventArgs e)
        {
            if (move())
                SvcRestrBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, System.EventArgs e)
        {
            if (move())
                SvcRestrBindingSource.MoveLast();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, System.EventArgs e)
        {
            if (move())
                SvcRestrBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, System.EventArgs e)
        {
            if (move())
                SvcRestrBindingSource.MoveFirst();
        }

        private void GridViewSvcRestr_BeforeLeaveRow(object sender, RowAllowEventArgs e)
        {
            if (SvcRestrBindingSource.Current == null)
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (SVCRESTR)SvcRestrBindingSource.Current);

                setReadOnly(true);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (SVCRESTR)SvcRestrBindingSource.Current);

                e.Allow = false;
            }
        }

        private void GridViewSvcRestr_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            if (!GridViewSvcRestr.IsFilterRow(e.RowHandle))
            {
                modified = true;
                
            }
        }

        private void GridViewSvcRestr_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
       
        }

        private void SvcRestrBindingSource_CurrentChanged(object sender, System.EventArgs e)
        {
            if (SvcRestrBindingSource.Current != null)
            {
                enableNavigator(true);

            }
            else
                enableNavigator(false);
        }

        private void SvcRestForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
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

    }
}