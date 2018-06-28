using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using FlexModel;
using DevExpress.XtraEditors.Controls;
using System.Runtime.InteropServices;
using System.Data.Entity.Core.Objects;

using DevExpress.Data.Linq;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraGrid;


namespace TraceForms
{
    
    public partial class LanguageForm : DevExpress.XtraEditors.XtraForm
    {
        public string imagesRoot;
        //public FlexCore.CoreSys _sys;
        public string currentVal;
        public bool createNew;
        public bool modified = false;
        public bool newRec = false;
        public bool addNew = false;
        public bool temp = false;
        public bool refresh = false;
        public bool cancelled = false;
        const string colName = "colCODE";
        public FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public LanguageForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
            LoadLookups();
            imagesRoot = sys.Settings.ImagesRoot;           
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);
        }

        private void setReadOnly(bool value)
        {
            codeTextEdit.Properties.ReadOnly = value;
            GridViewLanguage.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = !value;
            ImageComboBoxEditCode.Properties.ReadOnly = value;
        }

        private void LoadLookups()
        {
            setReadOnly(true);
            var lang = from langRec in context.LANGUAGE orderby langRec.CODE ascending select new { langRec.CODE, langRec.NAME };
           
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxEditCode.Properties.Items.Add(loadBlank);
           
            foreach (var result in lang)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCode.Properties.Items.Add(load);
            }
           
        }

        

        private void setValues()
        {
            GridViewLanguage.SetFocusedRowCellValue("CODE", string.Empty);
            GridViewLanguage.SetFocusedRowCellValue("NAME", string.Empty);
            GridViewLanguage.SetFocusedRowCellValue("Language_Code", string.Empty);
            GridViewLanguage.SetFocusedRowCellValue("CultureCode", string.Empty);
            GridViewLanguage.SetFocusedRowCellValue("WebUI", false);
            GridViewLanguage.SetFocusedRowCellValue("ImagePath", string.Empty);
            GridViewLanguage.SetFocusedRowCellValue("LocalName", string.Empty);
            GridViewLanguage.SetFocusedRowCellValue("Searchable", false);           
        }

        private bool checkForms()
        {
            if (!modified && !newRec)
                return true;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((LANGUAGE)LanguageBindingSource.Current).checkAll, LanguageBindingSource);

            if (validateMain)
                return validCheck.saveRec(ref modified, true, ref newRec, context, LanguageBindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, LanguageBindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }

        private void BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private bool move()
        {
            GridViewLanguage.CloseEditor();
            codeTextEdit.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            ((LANGUAGE)LanguageBindingSource.Current).ImagesRoot = imagesRoot;
            if (checkForms())
            {
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, ( LANGUAGE)LanguageBindingSource.Current);
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
                LanguageBindingSource.MoveFirst();

        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                LanguageBindingSource.MovePrevious();

        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                LanguageBindingSource.MoveNext();

        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                LanguageBindingSource.MoveLast();

        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {

            if (LanguageBindingSource.Current == null)
            {
                e.Allow = true;
                return;
            }
            temp = newRec;
            bool temp2 = modified;
            ((LANGUAGE)LanguageBindingSource.Current).ImagesRoot = imagesRoot;
            if (checkForms())
            {
                e.Allow = true;
                if ((!temp) && temp2)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (LANGUAGE)LanguageBindingSource.Current);

                setReadOnly(true);
            }
            else
            {
                if (!temp && !modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (LANGUAGE)LanguageBindingSource.Current);
            
                e.Allow = false;
            }
        }

        private void LANGUAGEForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewLanguage.IsFilterRow(e.RowHandle))
                modified = true;           
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            temp = newRec;
            ((LANGUAGE)LanguageBindingSource.Current).ImagesRoot = imagesRoot;
            if (!temp && checkForms())
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (LANGUAGE)LanguageBindingSource.Current);

            setReadOnly(true);
        }


        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        private void imagePathButtonEdit_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                //6dlg.Filter = "bmp files (*.bmp)|*.bmp";
                dlg.InitialDirectory = imagesRoot;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (dlg.FileName.ToLower().IndexOf(imagesRoot.ToLower()) != -1)
                        imagePathButtonEdit.Text = dlg.FileName.Substring(imagesRoot.Length);
                    else
                        imagePathButtonEdit.Text = dlg.FileName;
                }
            }
        }

        private void imagePathButtonEdit_TextChanged(object sender, EventArgs e)
        {
            pictureEdit1.Image = null;
            Image pic = null;
            try
            {
                pic = new Bitmap(imagesRoot + imagePathButtonEdit.Text);
                errorProvider1.SetError(imagePathButtonEdit, "");
            }
            catch
            {
                try
                {
                    pic = new Bitmap(imagePathButtonEdit.Text);
                    errorProvider1.SetError(imagePathButtonEdit, "");
                }
                catch
                {
                    return;
                }
            }
            pictureEdit1.Image = pic;
        }

        private void codeTextBox_Leave(object sender, EventArgs e)
        {
            if (LanguageBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((LANGUAGE)LanguageBindingSource.Current).checkCode, LanguageBindingSource);
            }           
        }

        private void dESCTextBox_Leave(object sender, EventArgs e)
        {
            if (LanguageBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((LANGUAGE)LanguageBindingSource.Current).checkName, LanguageBindingSource);
            }
        }

        private void localNameTextEdit_Leave(object sender, EventArgs e)
        {
            if (LanguageBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((LANGUAGE)LanguageBindingSource.Current).checkLocalName, LanguageBindingSource);
            }
        }        

        private void cultureCodeTextEdit_Leave(object sender, EventArgs e)
        {
            if (LanguageBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((LANGUAGE)LanguageBindingSource.Current).checkCultureCode, LanguageBindingSource);
            }
        }

        private void imagePathButtonEdit_Leave(object sender, EventArgs e)
        {
            if (LanguageBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((LANGUAGE)LanguageBindingSource.Current).checkImagePath, LanguageBindingSource);
            }
        }       

        private void LanguageForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewLanguage.IsFilterRow(GridViewLanguage.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewLanguage.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(GridViewLanguage.GetFocusedDisplayText()))
                value = GridViewLanguage.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = string.Format("it.CODE like '{0}%'", GridViewLanguage.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));               
                var special = context.LANGUAGE.Where(query);
                if (!string.IsNullOrWhiteSpace(GridViewLanguage.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "NAME")))
                {
                    query = String.Format("it.{0} like '{1}%'", "NAME", GridViewLanguage.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "NAME"));
                    special = special.Where(query);
                }               
  
                int count = special.Count();
                if (count > 0)
                {
                    LanguageBindingSource.DataSource = special;
                    GridViewLanguage.SetRowCellValue(GridControl.AutoFilterRowHandle, colName, value);
                    GridViewLanguage.FocusedRowHandle = 0;
                    GridViewLanguage.FocusedColumn.FieldName = colName;
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewLanguage.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void searchableCheckEdit_Click(object sender, EventArgs e)
        {
            modified = true;
        }

        private void ImageComboBoxEditCode_Leave(object sender, EventArgs e)
        {
            if (LanguageBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    modified = true;
                validCheck.check(sender, errorProvider1, ((LANGUAGE)LanguageBindingSource.Current).checkLanguageCode, LanguageBindingSource);
            }
        }

        private void LanguageBindingSource_CurrentChanged(object sender, EventArgs e)
        {
			
        }

		private void barButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			GridViewLanguage.ClearColumnsFilter();
			if (LanguageBindingSource.Current == null)
			{
				LanguageBindingSource.AddNew();
				codeTextEdit.Focus();
				setValues();
				setReadOnly(false);
				newRec = true;
				return;
			}
			codeTextEdit.Focus();
			// bindingNavigatorPositionItem.Focus();  //trigger field leave event
			GridViewLanguage.CloseEditor();
			temp = newRec;
			((LANGUAGE)LanguageBindingSource.Current).ImagesRoot = imagesRoot;
			if (checkForms())
			{
				if (!temp)
					context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (LANGUAGE)LanguageBindingSource.Current);
				LanguageBindingSource.AddNew();
				codeTextEdit.Focus();
				setValues();
				setReadOnly(false);
				newRec = true;
			}

		}

		private void barButtonItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (LanguageBindingSource.Current == null)
				return;
			GridViewLanguage.CloseEditor();
			if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{

				modified = false;
				newRec = false;
				LanguageBindingSource.RemoveCurrent();
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
			currentVal = codeTextEdit.Text;

		}

		private void barButtonItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (LanguageBindingSource.Current == null)
				return;

			GridViewLanguage.CloseEditor();
			codeTextEdit.Focus();
			//bindingNavigatorPositionItem.Focus();//trigger field leave event
			bool temp = newRec;
			((LANGUAGE)LanguageBindingSource.Current).ImagesRoot = imagesRoot;
			if (checkForms())
			{
				codeTextEdit.Focus();
				setReadOnly(true);
				panelControlStatus.Visible = true;
				LabelStatus.Text = "Record Saved";
				rowStatusSave = new Timer();
				rowStatusSave.Interval = 3000;
				rowStatusSave.Start();
				rowStatusSave.Tick += TimedEventSave;
			}
			if (!temp && !modified)
				context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (LANGUAGE)LanguageBindingSource.Current);


		}
	}
}