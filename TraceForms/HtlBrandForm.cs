using System;
using System.IO;
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
    
    public partial class HtlBrandForm : DevExpress.XtraEditors.XtraForm
    {

        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public string imagesRoot;
        const string colName = "colCODE";
        public  FlextourEntities context;

        public HtlBrandForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
            LoadLookups();
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);
            sys.Connect("");
            imagesRoot = sys.Settings.ImagesRoot;
            sys.Disconnect();
        }

        private void LoadLookups()
        {
            cODETextEdit.Properties.ReadOnly = true;
            GridViewHtlBrand.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = false;
            var chains = from chainRec in context.HTLCHAIN orderby chainRec.CODE select new { chainRec.CODE, chainRec.DESC };

            foreach (var result in chains)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.DESC.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditChain.Properties.Items.Add(load);
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
            GridViewHtlBrand.SetFocusedRowCellValue("CODE", string.Empty);
            GridViewHtlBrand.SetFocusedRowCellValue("DESC", string.Empty);
            GridViewHtlBrand.SetFocusedRowCellValue("CHAIN", string.Empty);
            GridViewHtlBrand.SetFocusedRowCellValue("LOGO_PATH", string.Empty);
        }


        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            GridViewHtlBrand.ClearColumnsFilter();
            if (HtlBrandBindingSource.Current == null)
            {
                //fake query in order to create a link between the database table and the binding source
                HtlBrandBindingSource.DataSource = from opt in context.HTLBRAND where opt.CODE == "KJM9" select opt;
                HtlBrandBindingSource.AddNew();
                if (GridViewHtlBrand.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewHtlBrand.FocusedRowHandle = GridViewHtlBrand.RowCount - 1;
                setValues();
                cODETextEdit.Focus();
                cODETextEdit.Properties.ReadOnly = false;
                GridViewHtlBrand.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = true;
                newRec = true;
                return;
            }
            cODETextEdit.Focus();
            //bindingNavigatorPositionItem.Focus();  
            GridViewHtlBrand.CloseEditor();
            temp = newRec;
            ((HTLBRAND)HtlBrandBindingSource.Current).ImagesRoot = imagesRoot;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (HTLBRAND)HtlBrandBindingSource.Current);
                HtlBrandBindingSource.AddNew();
                if (GridViewHtlBrand.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewHtlBrand.FocusedRowHandle = GridViewHtlBrand.RowCount - 1;
                setValues();
                cODETextEdit.Focus();
                cODETextEdit.Properties.ReadOnly = false;
                GridViewHtlBrand.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = true;
                newRec = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (HtlBrandBindingSource.Current == null)
                return;
            GridViewHtlBrand.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                modified = false;
                newRec = false;
                HtlBrandBindingSource.RemoveCurrent();
                errorProvider1.Clear();              
                context.SaveChanges();
                HtlBrandBindingSource.EndEdit();
                cODETextEdit.Properties.ReadOnly = true;
                GridViewHtlBrand.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = false;
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);
               
            }
            currentVal = cODETextEdit.Text;
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }

        private bool checkForms()
        {
            if (!modified && !newRec)
                return true;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((HTLBRAND)HtlBrandBindingSource.Current).checkAll, HtlBrandBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, HtlBrandBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, HtlBrandBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }


        private void hTLBRANDBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (HtlBrandBindingSource.Current == null)
                return;
            GridViewHtlBrand.CloseEditor();
            cODETextEdit.Focus();
            //bindingNavigatorPositionItem.Focus();
            ((HTLBRAND)HtlBrandBindingSource.Current).ImagesRoot = imagesRoot;
            bool temp = newRec;
            if (checkForms())
            {
                cODETextEdit.Focus();
                cODETextEdit.Properties.ReadOnly = true;
                GridViewHtlBrand.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = false;
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
            }

            if (!temp && !modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (HTLBRAND)HtlBrandBindingSource.Current);
          
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }


        private bool move()
        {
            GridViewHtlBrand.CloseEditor();
            cODETextEdit.Focus();
            //bindingNavigatorPositionItem.Focus();
            temp = newRec;
            ((HTLBRAND)HtlBrandBindingSource.Current).ImagesRoot = imagesRoot;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( HTLBRAND)HtlBrandBindingSource.Current);
                cODETextEdit.Properties.ReadOnly = true;
                GridViewHtlBrand.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = false;
                newRec = false;
                modified = false;
                return true;
            }
            return false;
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (move())
                HtlBrandBindingSource.MoveFirst();            
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                HtlBrandBindingSource.MovePrevious();            
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                HtlBrandBindingSource.MoveNext();            
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                HtlBrandBindingSource.MoveLast();            
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (HtlBrandBindingSource.Current == null)
            {
                e.Allow = true;
                return;
            }
            temp = newRec;
            ((HTLBRAND)HtlBrandBindingSource.Current).ImagesRoot = imagesRoot;
            bool temp2 = modified;
            if (checkForms())
            {
                e.Allow = true;
                if ((!temp) && temp2)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (HTLBRAND)HtlBrandBindingSource.Current);
                cODETextEdit.Properties.ReadOnly = true;
                GridViewHtlBrand.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = false;
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (HTLBRAND)HtlBrandBindingSource.Current);
          
                e.Allow = false;

            }
        }

        private void lOGO_PATHButtonEdit_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
               
                dlg.InitialDirectory = imagesRoot;
                if (dlg.ShowDialog() == DialogResult.OK)
                {                    
                    if (dlg.FileName.ToLower().IndexOf(imagesRoot.ToLower()) != -1)
                        lOGO_PATHButtonEdit.Text = dlg.FileName.Substring(imagesRoot.Length);
                    else
                        lOGO_PATHButtonEdit.Text = dlg.FileName;
                }
            }
        }

        private void lOGO_PATHTextEdit_TextChanged(object sender, EventArgs e)
        {

            logo.Image = null;
            
            try
            {
                using (var stream = new MemoryStream(File.ReadAllBytes(imagesRoot + lOGO_PATHButtonEdit.Text)))
                {
                    logo.Height = Image.FromStream(stream).Height;
                    logo.Width = Image.FromStream(stream).Width;
                    logo.Image = Image.FromStream(stream);
                    errorProvider1.SetError(lOGO_PATHButtonEdit, "");
                }
               
            }
            catch
            {
                try
                {
                    using (var stream = new MemoryStream(File.ReadAllBytes(lOGO_PATHButtonEdit.Text)))
                    {
                        logo.Height = Image.FromStream(stream).Height;
                        logo.Width = Image.FromStream(stream).Width;
                        logo.Image = Image.FromStream(stream);
                        errorProvider1.SetError(lOGO_PATHButtonEdit, "");
                    }
                   
                }
                catch
                {                   
                    return;
                }
            }
            labelControlSizeDisplay.Text = logo.Image.Height + " * " + logo.Image.Width;
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewHtlBrand.IsFilterRow(e.RowHandle))
                modified = true;
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box        
        }

        private void HtlBrandForm_FormClosing(object sender, FormClosingEventArgs e)
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
           ((HTLBRAND)HtlBrandBindingSource.Current).ImagesRoot = imagesRoot;
           if (!temp && checkForms())
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( HTLBRAND)HtlBrandBindingSource.Current);

            cODETextEdit.Properties.ReadOnly = true;
            GridViewHtlBrand.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = false;
        }
        
        private void cODETextEdit_Leave(object sender, EventArgs e)
        {
            if (HtlBrandBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((HTLBRAND)HtlBrandBindingSource.Current).checkCode, HtlBrandBindingSource);
            }
           
        }

     

        private void dESCTextEdit_Leave(object sender, EventArgs e)
        {
            if (HtlBrandBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((HTLBRAND)HtlBrandBindingSource.Current).checkDesc, HtlBrandBindingSource);
            }
        }

        private void path_Leave(object sender, EventArgs e)
        {
            if (HtlBrandBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((HTLBRAND)HtlBrandBindingSource.Current).checkPath, HtlBrandBindingSource);
            }
        }
        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }       

        private void HtlBrandForm_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter && GridViewHtlBrand.IsFilterRow(GridViewHtlBrand.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewHtlBrand.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewHtlBrand.GetFocusedDisplayText()))
                value = GridViewHtlBrand.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.CODE like '{0}%'", GridViewHtlBrand.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                var special = context.HTLBRAND.Where(query);
              
                if (!string.IsNullOrWhiteSpace(GridViewHtlBrand.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "DESC")))
                {
                    query = String.Format("it.{0} like '{1}%'", "[DESC]", GridViewHtlBrand.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "DESC"));
                    special = special.Where(query);
                }
                if (!string.IsNullOrWhiteSpace(GridViewHtlBrand.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CHAIN")))
                {
                    query = String.Format("it.{0} like '{1}%'", "[CHAIN]", GridViewHtlBrand.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CHAIN"));
                    special = special.Where(query);
                }

                int count = special.Count();
                if (count > 0)
                {
                    HtlBrandBindingSource.DataSource = special;
                    GridViewHtlBrand.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                    GridViewHtlBrand.FocusedRowHandle = 0;
                    GridViewHtlBrand.FocusedColumn.FieldName = colName;
                    GridViewHtlBrand.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewHtlBrand.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void ImageComboBoxEditChain_Leave(object sender, System.EventArgs e)
        {
            if (HtlBrandBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((HTLBRAND)HtlBrandBindingSource.Current).checkChain, HtlBrandBindingSource);
            }
        }

        private void HtlBrandBindingSource_CurrentChanged(object sender, System.EventArgs e)
        {
            if (HtlBrandBindingSource.Current != null)
                enableNavigator(true);
            else
                enableNavigator(false);
        }

       
    }
}
