using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors;
using FlexModel;
using DevExpress.XtraGrid.Columns;
using System.ComponentModel.DataAnnotations;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Linq;
using System.Collections;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Runtime.InteropServices;
using FlexCore;
using FlexInterfaces.Core;
using FlexInterfaces.Media;
using System.Diagnostics;
using System.Data.Entity;

namespace TraceForms
{
    public partial class mediaInfoMaint : XtraForm
    {
        public string currentVal;
        public bool _modified = false;
        public bool newRec = false;
        public bool temp = false;
        public string imagesRoot;
        public bool newRowRec;
        public string username;
        public bool webCheck;
        public FlextourEntities context;
        public ArrayList unboundPosition = new ArrayList();
        public ArrayList unboundSelection = new ArrayList();
        public string keyLogger;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        private FlexInterfaces.Core.ICoreSys _sys;
        List<CodeName> _citycodLookup;
        List<CodeName> _hotelLookup;
        List<CodeName> _packLookup;
        List<CodeName> _compLookup;
        List<CodeName> _waypointLookup;
        private string _originalHtml = string.Empty;

        public bool Modified { 
			get {
				return _modified;
			}
			set {
				_modified = value;
                if (value && MediaInfoBindingSource.Current != null) {
                    //NB: Before updating any property on the entity, any pending edits must be committed 
                    //with bindingSource.EndEdit, other when the properties are set the form bindings are
                    //automatically refreshed, which causes any pending edits to be lost. 
                    MediaInfoBindingSource.EndEdit();
                    MEDIAINFO info = (MEDIAINFO)MediaInfoBindingSource.Current;
                    info.ChgDate = DateTime.Now;
                }
            }
		}

        public mediaInfoMaint(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            _sys = sys;
            Connect(sys);
            LoadLookups();
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);
            imagesRoot = sys.Settings.ImagesRoot;
            username = sys.User.Name;
        }

        private void LoadLookups()
        {
            newRec = false;
            Modified = false;
            newRowRec = false;
            webCheck = false;
            var agy = from agyRec in context.AGY orderby agyRec.NO ascending select new { agyRec.NO, agyRec.NAME };
            var sct = from c in context.LOOKUP where c.LINK_TABLE == "MEDIAINFO" select new { c.CODE, c.DESC };
            var lang = from langRec in context.LANGUAGE orderby langRec.CODE ascending select new { langRec.CODE, langRec.NAME };
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };

            var cats = context.ROOMCOD.Select(r => new CodeName() { Code = r.CODE, Name = r.DESC }).OrderBy(r => r.Code).ToList();
            cats.Insert(0, new CodeName() { Code = string.Empty, Name = string.Empty });
            ImageComboBoxEditCategory.Properties.DataSource = cats;
            ImageComboBoxEditCategory.Properties.DisplayMember = "DisplayName";
            ImageComboBoxEditCategory.Properties.ValueMember = "Code";
            var col = ImageComboBoxEditCategory.Properties.View.Columns.Add();
            col.FieldName = "DisplayName";
            col.Visible = true;

            ImageComboBoxEditAgency.Properties.Items.Add(loadBlank);
            ImageComboBoxEditLang.Properties.Items.Add(loadBlank);
            ImageComboBoxEditSection.Properties.Items.Add(loadBlank);

            //foreach (var result in cat)
            //{
            //    ImageComboBoxItem load = new ImageComboBoxItem() { Description = String.Format("{0}  ({1})", result.CODE.TrimEnd(), result.DESC.TrimEnd()), Value = result.CODE.TrimEnd() };
            //    ImageComboBoxEditCategory.Properties.Items.Add(load);
            //}

            foreach (var result in agy)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = String.Format("{0}  ({1})", result.NO.TrimEnd(), result.NAME.TrimEnd()), Value = result.NO.TrimEnd() };
                ImageComboBoxEditAgency.Properties.Items.Add(load);
            }
            foreach (var result in lang)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = String.Format("{0}  ({1})", result.CODE.TrimEnd(), result.NAME.TrimEnd()), Value = result.CODE.TrimEnd() };
                ImageComboBoxEditLang.Properties.Items.Add(load);
            }
            foreach (var result in sct)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = String.Format("{0}  ({1})", result.CODE.TrimEnd(), result.DESC.TrimEnd()), Value = result.CODE.TrimEnd() };
                ImageComboBoxEditSection.Properties.Items.Add(load);
            }

            //GridControlMediaInfo.Enabled = false;
            //webBrowserMediaInfoText.Navigating += webBrowser1_Navigating;
            //         //Config setting will override sysfile so that I can use the production db but the local editor
            //         string url = Configurator.InfoButtonUrl;
            //         if (string.IsNullOrEmpty(url)) {
            //             var value = from c in context.SYSFILE select c;
            //             url = value.First().INFO_BUTTON_URL;
            //         }
            //         url += "editor.aspx";
            //         Uri browserUri = new Uri(url);
            //         webBrowserMediaInfoText.Navigate(browserUri);
            htmlEditor.SpellCheckOptions.CurlyUnderlineImageFilePath = _sys.Settings.ImagesRoot + "curly_underline.gif";
            //expandContractGridButton.Tag = "right";
           
            unboundPosition.Capacity = 1000;
            unboundSelection.Capacity = 1000;
            setReadOnly(true);
            barSubItemReports.Enabled = false;

            _hotelLookup = new List<CodeName>();
            _hotelLookup.Add(new CodeName(string.Empty));
            _hotelLookup.AddRange(context.HOTEL
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.NAME }));

            _packLookup = new List<CodeName>();
            _packLookup.Add(new CodeName(string.Empty));
            _packLookup.AddRange(context.PACK
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.NAME }));

            _compLookup = new List<CodeName>();
            _compLookup.Add(new CodeName(string.Empty));
            _compLookup.AddRange(context.COMP
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.NAME }));

            _citycodLookup = new List<CodeName>();
            _citycodLookup.Add(new CodeName(string.Empty));
            _citycodLookup.AddRange(context.CITYCOD
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.NAME }));

            _waypointLookup = new List<CodeName>();
            _waypointLookup.Add(new CodeName(string.Empty));
            _waypointLookup.AddRange(context.WAYPOINT
                .OrderBy(t => t.CODE)
                .Select(t => new CodeName() { Code = t.CODE, Name = t.DESC }));

        }


        private void LoadCodeLookupValues(string type, BindingSource source)
        {
            switch (type) {
                case "HTL":
                    source.DataSource = _hotelLookup;
                    break;
                case "PKG":
                    source.DataSource = _packLookup;
                    break;
                case "OPT":
                    source.DataSource = _compLookup;
                    break;
                case "WAY":
                    source.DataSource = _waypointLookup;
                    break;
                case "CTY":
                    source.DataSource = _citycodLookup;
                    break;
                default:
                    source.DataSource = null;
                    break;
            }
        }

        void setReadOnly(bool value)
        {
            ComboBoxEditType.Properties.ReadOnly = value;
            ImageComboBoxEditLang.Properties.ReadOnly = value;
            gridLookUpEditProduct.Properties.ReadOnly = value;
            ImageComboBoxEditSection.Properties.ReadOnly = value;
            ImageComboBoxEditAgency.Properties.ReadOnly = value;
            ImageComboBoxEditCategory.Properties.ReadOnly = value;
            //removed date fields      
        }

    //    void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
    //    {
    //        try
    //        {
				////don't allow the user to enter filter criteria in the grid until the html editor is ready
				//GridControlMediaInfo.Enabled = true;
				//webBrowserMediaInfoText.Navigating -= webBrowser1_Navigating;
    //            //webBrowserMediaInfoText.Document.Window.Frames[0].Document.Body.InnerHtml = TextEditBrowserText.Text;
    //        }
    //        catch { }
    //    }


        private bool checkForms()
        {
            if (!Modified && !newRec)
                return true;
            bool validatedChanges = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((MEDIAINFO)MediaInfoBindingSource.Current).checkSplitContainer, MediaInfoBindingSource);
            bool validatedChanges1 = validCheck.checkAll(panelControlText.Controls, errorProvider1, ((MEDIAINFO)MediaInfoBindingSource.Current).checkPanelControlText, MediaInfoBindingSource);
            bool validatedChanges2 = validCheck.checkAll(panelControlPrimaryImages.Controls, errorProvider1, ((MEDIAINFO)MediaInfoBindingSource.Current).checkPanelPrimary, MediaInfoBindingSource);
            bool validatedChanges3 = validCheck.checkAll(panelControlLowRes.Controls, errorProvider1, ((MEDIAINFO)MediaInfoBindingSource.Current).checkPanelControlLow, MediaInfoBindingSource);
            bool validatedChanges4 = validCheck.checkAll(panelControlMedRes.Controls, errorProvider1, ((MEDIAINFO)MediaInfoBindingSource.Current).checkPanelControlMid, MediaInfoBindingSource);
            bool validatedChanges5 = validCheck.checkAll(panelControlHighRes.Controls, errorProvider1, ((MEDIAINFO)MediaInfoBindingSource.Current).checkPanelControlHigh, MediaInfoBindingSource);
            bool validatedChanges6 = validCheck.checkAll(panelControlThumbNail.Controls, errorProvider1, ((MEDIAINFO)MediaInfoBindingSource.Current).checkPanelThumb, MediaInfoBindingSource);
            bool validatedChanges7 = validCheck.checkAll(panelControlDisplay.Controls, errorProvider1, ((MEDIAINFO)MediaInfoBindingSource.Current).checkPanelDisplay, MediaInfoBindingSource);

            if (validatedChanges && validatedChanges1 && validatedChanges2 && validatedChanges3 && validatedChanges4 && validatedChanges5 && validatedChanges6 && validatedChanges7)
            {

                return validCheck.saveRec(ref _modified, true, ref newRec, context, MediaInfoBindingSource, Name, errorProvider1, Cursor);
            }
            else
            {
                return validCheck.saveRec(ref _modified, false, ref newRec, context, MediaInfoBindingSource, Name, errorProvider1, Cursor);
                //return false;
            }
        }

        //public void loadBrowser()
        //{
        //    try
        //    {
        //        if (!string.IsNullOrWhiteSpace(((MEDIAINFO)MediaInfoBindingSource.Current).TEXT))
        //            webBrowserMediaInfoText.Document.Window.Frames[0].Document.Body.InnerHtml = ((MEDIAINFO)MediaInfoBindingSource.Current).TEXT;
        //        else
        //            webBrowserMediaInfoText.Document.Window.Frames[0].Document.Body.InnerHtml = String.Empty;
              
        //        //webBrowserMediaInfoText.Parent.Font = Font 
        //        //FontFamily fontFamily = new FontFamily("Arial");
        //        //Font fontchinese = new Font("Arial Unicode MS", 16);
        //        //webBrowserMediaInfoText.Parent.Font = fontchinese;
        //        //Font font = new Font(
        //        //   fontFamily,
        //        //   16,
        //        //   FontStyle.Regular,
        //        //   GraphicsUnit.Pixel);

        //    }
        //    catch { }
        //}

        private void ButtonEditImage1LowRes_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog() { Title = "Open Image", InitialDirectory = imagesRoot })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (dlg.FileName.ToLower().IndexOf(imagesRoot.ToLower()) != -1)
                        ButtonEditImage1LowRes.Text = dlg.FileName.Substring(imagesRoot.Length);
                    else
                        ButtonEditImage1LowRes.Text = dlg.FileName;
                }
            }
        }

        private void ButtonEditImage1LowRes_TextChanged(object sender, EventArgs e)
        {

            pictureEditPreviewImage1.Image = null;
            
            try
            {
                using (var stream = new MemoryStream(File.ReadAllBytes(imagesRoot + ButtonEditImage1LowRes.Text)))
                {
                    pictureEditPreviewImage1.Height = Image.FromStream(stream).Height;
                    pictureEditPreviewImage1.Width = Image.FromStream(stream).Width;
                    pictureEditPreviewImage1.Image = Image.FromStream(stream);
                    errorProvider1.SetError(ButtonEditImage1LowRes, "");
                }
               
            }
            catch
            {
                try
                {
                    using (var stream = new MemoryStream(File.ReadAllBytes(ButtonEditImage1LowRes.Text)))
                    {
                        pictureEditPreviewImage1.Height = Image.FromStream(stream).Height;
                        pictureEditPreviewImage1.Width = Image.FromStream(stream).Width;
                        pictureEditPreviewImage1.Image = Image.FromStream(stream);
                        errorProvider1.SetError(ButtonEditImage1LowRes, "");
                    }
                }
                catch
                {
                    return;
                }

            }


            labelControlSizeDisplay.Text = pictureEditPreviewImage1.Image.Height + " * " + pictureEditPreviewImage1.Image.Width;
        }

        private void ButtonEditImage2MedRes_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog() { Title = "Open Image", InitialDirectory = imagesRoot })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (dlg.FileName.ToLower().IndexOf(imagesRoot.ToLower()) != -1)
                        ButtonEditImage2MedRes.Text = dlg.FileName.Substring(imagesRoot.Length);
                    else
                        ButtonEditImage2MedRes.Text = dlg.FileName;
                } 
            } 
        }

        private void ButtonEditImage2MedRes_TextChanged(object sender, EventArgs e)
        {
            pictureEditPreviewImage2.Image = null;
            
            try
            {
                using(var stream = new MemoryStream(File.ReadAllBytes(imagesRoot + ButtonEditImage2MedRes.Text)))
                {
                    pictureEditPreviewImage2.Height = Image.FromStream(stream).Height;
                    pictureEditPreviewImage2.Width = Image.FromStream(stream).Width;
                    pictureEditPreviewImage2.Image = Image.FromStream(stream);
                    errorProvider1.SetError(ButtonEditImage2MedRes, "");
                }
              
            }
            catch
            {
                try
                {
                    using (var stream = new MemoryStream(File.ReadAllBytes(ButtonEditImage2MedRes.Text)))
                    {
                        pictureEditPreviewImage2.Height = Image.FromStream(stream).Height;
                        pictureEditPreviewImage2.Width = Image.FromStream(stream).Width;
                        pictureEditPreviewImage2.Image = Image.FromStream(stream);
                        errorProvider1.SetError(ButtonEditImage2MedRes, "");
                    }
                }
                catch
                {
                    return;
                }
                
            }

            labelControlSizeDisplay2.Text = pictureEditPreviewImage2.Image.Height + " * " + pictureEditPreviewImage2.Image.Width;
        }

        private void ButtonEditImage3HighRes_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog() { Title = "Open Image", InitialDirectory = imagesRoot })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (dlg.FileName.ToLower().IndexOf(imagesRoot.ToLower()) != -1)
                        ButtonEditImage3HighRes.Text = dlg.FileName.Substring(imagesRoot.Length);
                    else
                        ButtonEditImage3HighRes.Text = dlg.FileName;
                }
            }
        }

        private void ButtonEditImage3HighRes_TextChanged(object sender, EventArgs e)
        {

            pictureEditPreviewImage3.Image = null;
            
            try
            {
                using (var stream = new MemoryStream(File.ReadAllBytes(imagesRoot + ButtonEditImage3HighRes.Text)))
                {
                    pictureEditPreviewImage3.Height = Image.FromStream(stream).Height;
                    pictureEditPreviewImage3.Width = Image.FromStream(stream).Width;
                    pictureEditPreviewImage3.Image = Image.FromStream(stream);
                    errorProvider1.SetError(ButtonEditImage3HighRes, "");
                }
               
            }
            catch
            {
                try
                {
                    using (var stream = new MemoryStream(File.ReadAllBytes(ButtonEditImage3HighRes.Text)))
                    {
                         pictureEditPreviewImage3.Height = Image.FromStream(stream).Height;
                         pictureEditPreviewImage3.Width = Image.FromStream(stream).Width;
                        pictureEditPreviewImage3.Image = Image.FromStream(stream);
                        errorProvider1.SetError(ButtonEditImage3HighRes, "");
                    }
                }
                catch
                {
                    return;
                }

            }

            labelControlSizeDisplay3.Text = pictureEditPreviewImage3.Image.Height + " * " + pictureEditPreviewImage3.Image.Width;
        }

        private void ButtonEditImage4ThmNail_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog() { Title = "Open Image", InitialDirectory = imagesRoot })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (dlg.FileName.ToLower().IndexOf(imagesRoot.ToLower()) != -1)
                        ButtonEditImage4ThmNail.Text = dlg.FileName.Substring(imagesRoot.Length);
                    else
                        ButtonEditImage4ThmNail.Text = dlg.FileName;
                }
            }  
        }

        private void ButtonEditImage4ThmNail_TextChanged(object sender, EventArgs e)
        {
            pictureEditPreviewImage4.Image = null;
            
            try
            {
                using (var stream = new MemoryStream(File.ReadAllBytes(imagesRoot + ButtonEditImage4ThmNail.Text)))
                {
                    pictureEditPreviewImage4.Height = Image.FromStream(stream).Height;
                    pictureEditPreviewImage4.Width = Image.FromStream(stream).Width;
                    pictureEditPreviewImage4.Image = Image.FromStream(stream);                   
                    errorProvider1.SetError(ButtonEditImage4ThmNail, "");
                }               
            }
            catch
            {
                try
                {
                    using (var stream = new MemoryStream(File.ReadAllBytes(ButtonEditImage4ThmNail.Text)))
                    {
                        pictureEditPreviewImage4.Height = Image.FromStream(stream).Height;
                        pictureEditPreviewImage4.Width = Image.FromStream(stream).Width;
                        pictureEditPreviewImage4.Image = Image.FromStream(stream);                      
                        errorProvider1.SetError(ButtonEditImage4ThmNail, "");
                    }
                }
                catch
                {
                    return;
                }

            }

            labelControlSizeDisplay4.Text = String.Format("{0} * {1}", pictureEditPreviewImage4.Image.Height, pictureEditPreviewImage4.Image.Width);
        }
        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        private void MediaInfoBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            //loadBrowser();
            if (((MEDIAINFO)MediaInfoBindingSource.Current) != null)
            {
                barSubItemReports.Enabled = true;
                MEDIAINFO rec = (MEDIAINFO)MediaInfoBindingSource.Current;
                rec.ImagesRoot = imagesRoot;
                string myID = rec.ID.ToString();
                ResourceBindingSource.DataSource = from c in context.RESOURCE where c.LINK_VALUE == myID select c;
                LoadCodeLookupValues(rec.TYPE, bindingSourceCodeNameProduct);
                htmlEditor.BodyHtml = rec.TEXT;
            }
            else
            {
                errorProvider1.Clear();
                ResourceBindingSource.DataSource = null;
                setReadOnly(true);
                htmlEditor.BodyHtml = string.Empty;
            }
            //The original html is required because the html editor reformats html to xhtml. Thus the
            //contents may change, even though the user has not changed them. Retrieving the BodyHtml property
            //right after it has been set will retrieve the reformatted xhtml, which can later be compared to
            //the BodyHtml property to see if the user has made subsequent changes.  Only if the user has made
            //changes should we warn that changes may be lost, otherwise the user will be very confused that each
            //record appears to have been changed when only viewing.
            _originalHtml = htmlEditor.BodyHtml;
            Modified = false;
            setCheckEdits();
        }

        private void setCheckEdits()
        {
            if (string.IsNullOrWhiteSpace(ImageComboBoxEditCategory.Text))
                checkEditAllCategory.Checked = true;
            else
                checkEditAllCategory.Checked = false;

            if (string.IsNullOrWhiteSpace(ImageComboBoxEditAgency.Text))
                checkEditAllAgency.Checked = true;
            else
                checkEditAllAgency.Checked = false;
        }

        private void AddNewRec()
        {
            GridViewMediaInfo.ClearColumnsFilter();
            ResourceBindingSource.DataSource = null;
            setReadOnly(false);
            if (MediaInfoBindingSource.Current == null)
            {
                //fake query in order to create a link between the database table and the binding source
                MediaInfoBindingSource.DataSource = from media in context.MEDIAINFO where media.CODE == "KJM" select media;
                MediaInfoBindingSource.AddNew();
                if (GridViewMediaInfo.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewMediaInfo.FocusedRowHandle = 0;
                newRec = true;
                GridViewMediaInfo.SetFocusedRowCellValue("LANG", String.Empty);
                GridViewMediaInfo.SetFocusedRowCellValue("SECTION", String.Empty);
                GridViewMediaInfo.SetFocusedRowCellValue("CAT", String.Empty);
                GridViewMediaInfo.SetFocusedRowCellValue("CODE", String.Empty);
                GridViewMediaInfo.SetFocusedRowCellValue("Agency", String.Empty);
                GridViewMediaInfo.SetFocusedRowCellValue("Inactive", 0);
                GridViewMediaInfo.SetFocusedRowCellValue("Inhouse", 0);
                GridViewMediaInfo.SetFocusedRowCellValue("ID", int.MaxValue);
                GridViewMediaInfo.SetFocusedRowCellValue("TITLE", String.Empty);
                GridViewMediaInfo.SetFocusedRowCellValue("SUBTITLE", String.Empty);
                GridViewMediaInfo.SetFocusedRowCellValue("CAPTION", String.Empty);
                GridViewMediaInfo.SetFocusedRowCellValue("IMAGE1", String.Empty);
                GridViewMediaInfo.SetFocusedRowCellValue("IMAGE2", String.Empty);
                GridViewMediaInfo.SetFocusedRowCellValue("IMAGE3", String.Empty);
                GridViewMediaInfo.SetFocusedRowCellValue("IMAGE4", String.Empty);
                GridViewMediaInfo.SetFocusedRowCellValue("TEXT", String.Empty);
                GridViewMediaInfo.SetFocusedRowCellValue("Severity", 0);
                barSubItemReports.Enabled = false;
                htmlEditor.BodyHtml = string.Empty;
                _originalHtml = htmlEditor.BodyHtml;
                //TextEditBrowserText.Text = String.Empty;
                return;
            }
            //UpdateHtmlBinding();
            temp = newRec;
            if (checkForms())
            {
                errorProvider1.Clear();
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (MEDIAINFO)MediaInfoBindingSource.Current);
                webCheck = true;
                //webBrowserMediaInfoText.Document.Window.Frames[0].Document.Body.InnerHtml = "";
                htmlEditor.BodyHtml = string.Empty;
                _originalHtml = htmlEditor.BodyHtml;
                GridViewMediaInfo.FocusedRowHandle = 0;
                MediaInfoBindingSource.AddNew();
                if (GridViewMediaInfo.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewMediaInfo.FocusedRowHandle = GridViewMediaInfo.RowCount - 1;
                newRec = true;
            }
            barSubItemReports.Enabled = false;
            GridViewMediaInfo.SetFocusedRowCellValue("LANG", String.Empty);
            GridViewMediaInfo.SetFocusedRowCellValue("SECTION", String.Empty);
            GridViewMediaInfo.SetFocusedRowCellValue("CAT", String.Empty);
            GridViewMediaInfo.SetFocusedRowCellValue("CODE", String.Empty);
            GridViewMediaInfo.SetFocusedRowCellValue("Agency", String.Empty);
            GridViewMediaInfo.SetFocusedRowCellValue("Inactive", 0);
            GridViewMediaInfo.SetFocusedRowCellValue("Inhouse", 0);
            GridViewMediaInfo.SetFocusedRowCellValue("ID", int.MaxValue);
            GridViewMediaInfo.SetFocusedRowCellValue("TITLE", String.Empty);
            GridViewMediaInfo.SetFocusedRowCellValue("SUBTITLE", String.Empty);
            GridViewMediaInfo.SetFocusedRowCellValue("CAPTION", String.Empty);
            GridViewMediaInfo.SetFocusedRowCellValue("IMAGE1", String.Empty);
            GridViewMediaInfo.SetFocusedRowCellValue("IMAGE2", String.Empty);
            GridViewMediaInfo.SetFocusedRowCellValue("IMAGE3", String.Empty);
            GridViewMediaInfo.SetFocusedRowCellValue("IMAGE4", String.Empty);
            GridViewMediaInfo.SetFocusedRowCellValue("TEXT", String.Empty);
            GridViewMediaInfo.SetFocusedRowCellValue("Severity", 0);
            //TextEditBrowserText.Text = String.Empty;
            htmlEditor.BodyHtml = string.Empty;
            _originalHtml = htmlEditor.BodyHtml;
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }

        private bool move()
        {
            GridViewAdditionalImages.CloseEditor();
            //MediaInfoBindingNavigator.Focus();//trigger field leave event
            temp = newRec;
            MEDIAINFO record = (MEDIAINFO)MediaInfoBindingSource.Current;

            UpdateHtmlBinding();

            //if (string.IsNullOrWhiteSpace(((MEDIAINFO)MediaInfoBindingSource.Current).TEXT) && !string.IsNullOrWhiteSpace(webBrowserMediaInfoText.Document.Window.Frames[0].Document.Body.InnerHtml))
            //{
            //    Modified = true;
            //    TextEditBrowserText.Text = webBrowserMediaInfoText.Document.Window.Frames[0].Document.Body.InnerHtml;
            //}


            //if (!string.IsNullOrWhiteSpace(((MEDIAINFO)MediaInfoBindingSource.Current).TEXT) && !string.IsNullOrWhiteSpace(webBrowserMediaInfoText.Document.Window.Frames[0].Document.Body.InnerHtml))
            //{
            //    string savedText = ((MEDIAINFO)MediaInfoBindingSource.Current).TEXT.Replace(" ", "");
            //    string currentText = webBrowserMediaInfoText.Document.Window.Frames[0].Document.Body.InnerHtml.Replace(" ", "");
            //    if (currentText.Contains("&amp;"))
            //        currentText = currentText.Replace("&amp;", "&");

            //    if (savedText.Contains("&amp;"))
            //        savedText = savedText.Replace("&amp;", "&");

            //    if (savedText != currentText && savedText.Count() != currentText.Count())
            //    {
            //        Modified = true;
            //        TextEditBrowserText.Text = webBrowserMediaInfoText.Document.Window.Frames[0].Document.Body.InnerHtml;
            //    }
            //}

            if (checkForms())
            {
                errorProvider1.Clear();
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, record);
                newRec = false;
                Modified = false;
                webCheck = false;
                return true;
            }
            return false;
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (move())
                MediaInfoBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                MediaInfoBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                MediaInfoBindingSource.MoveLast();
        }

        private void GridViewMediaInfo_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {

            if (MediaInfoBindingSource.Current == null)
            {
                e.Allow = true;
                return;
            }

            if (MediaInfoBindingSource.Current != null)
            {
                MEDIAINFO record = (MEDIAINFO)MediaInfoBindingSource.Current;
                UpdateHtmlBinding();

                //if (string.IsNullOrWhiteSpace(((MEDIAINFO)MediaInfoBindingSource.Current).TEXT) && !string.IsNullOrWhiteSpace(webBrowserMediaInfoText.Document.Window.Frames[0].Document.Body.InnerHtml))
                //{
                //    Modified = true;
                //    TextEditBrowserText.Text = webBrowserMediaInfoText.Document.Window.Frames[0].Document.Body.InnerHtml;
                //}


                //if (!string.IsNullOrWhiteSpace(((MEDIAINFO)MediaInfoBindingSource.Current).TEXT) && !string.IsNullOrWhiteSpace(webBrowserMediaInfoText.Document.Window.Frames[0].Document.Body.InnerHtml))
                //{
                //    string savedText = ((MEDIAINFO)MediaInfoBindingSource.Current).TEXT.Replace(" ", "");
                //    string currentText = webBrowserMediaInfoText.Document.Window.Frames[0].Document.Body.InnerHtml.Replace(" ", "");
                //    if (currentText.Contains("&amp;"))
                //        currentText = currentText.Replace("&amp;", "&");

                //    if (savedText.Contains("&amp;"))
                //        savedText = savedText.Replace("&amp;", "&");

                //    if (savedText != currentText && savedText.Count() != currentText.Count())
                //    {
                //        Modified = true;
                //        TextEditBrowserText.Text = webBrowserMediaInfoText.Document.Window.Frames[0].Document.Body.InnerHtml;
                //    }
                //}
            }
            newRec = (newRec || newRowRec);
            temp = newRec;
            bool temp2 = Modified;
            if (checkForms())
            {
                newRowRec = false;
                errorProvider1.Clear();
                e.Allow = true;
                if ((!temp) && temp2)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (MEDIAINFO)MediaInfoBindingSource.Current);
            }
            else
            {
                if (!temp && !Modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (MEDIAINFO)MediaInfoBindingSource.Current);
          
                e.Allow = false;
            }
        }

        private void UpdateHtmlBinding()
        {
            MEDIAINFO record = (MEDIAINFO)MediaInfoBindingSource.Current;

            //The lost focus event doesn't work on the text editor when clicking a button in the toolbar
            if (htmlEditor.BodyHtml != _originalHtml) {
                Modified = true;
                //NB: Before updating any property on the entity, any pending edits must be committed 
                //with bindingSource.EndEdit, other when the properties are set the form bindings are
                //automatically refreshed, which causes any pending edits to be lost. 
                MediaInfoBindingSource.EndEdit();
                record.TEXT = htmlEditor.BodyHtml;
                _originalHtml = htmlEditor.BodyHtml;
                //foreach (var bindingObj in htmlEditor.DataBindings) {
                //    Binding binding = (Binding)bindingObj;
                //    if (binding.PropertyName == "BodyHtml") {
                //        binding.WriteValue();
                //        binding.ReadValue();
                //    }
                //}
            }
        }

        private void GridViewMediaInfo_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewMediaInfo.IsFilterRow(e.RowHandle))
            {
                Modified = true;
            }
        }

        private void GridViewMediaInfo_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            temp = newRec;
            if (!temp && checkForms())
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (MEDIAINFO)MediaInfoBindingSource.Current);
        }

        private void mediaInfoMaint_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Modified || newRec)
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

       

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                MediaInfoBindingSource.MoveNext();
        }

        private void ComboBoxEditType_Leave(object sender, EventArgs e)
        {
            if (((MEDIAINFO)MediaInfoBindingSource.Current) != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((MEDIAINFO)MediaInfoBindingSource.Current).checkSvcType, MediaInfoBindingSource);
            }
        }

        private void DateEditResStartDate_Leave(object sender, EventArgs e)
        {
            if (((MEDIAINFO)MediaInfoBindingSource.Current) != null) {
                if (currentVal != ((Control)sender).Text) {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((MEDIAINFO)MediaInfoBindingSource.Current).checkResStart, MediaInfoBindingSource);
            }
        }

        private void DateEditResEndDate_Leave(object sender, EventArgs e)
        {
            if (((MEDIAINFO)MediaInfoBindingSource.Current) != null) {
                if (currentVal != ((Control)sender).Text) {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((MEDIAINFO)MediaInfoBindingSource.Current).checkResEnd, MediaInfoBindingSource);
            }
        }

        private void DateEditsvcStartDate_Leave(object sender, EventArgs e)
        {
            if (((MEDIAINFO)MediaInfoBindingSource.Current) != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((MEDIAINFO)MediaInfoBindingSource.Current).checkStart, MediaInfoBindingSource);
            }
        }

        private void DateEditsvcEndDate_Leave(object sender, EventArgs e)
        {
            if (((MEDIAINFO)MediaInfoBindingSource.Current) != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((MEDIAINFO)MediaInfoBindingSource.Current).checkEnd, MediaInfoBindingSource);
            }
        }

        private void TextEditTitle_Leave(object sender, EventArgs e)
        {
            if (((MEDIAINFO)MediaInfoBindingSource.Current) != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((MEDIAINFO)MediaInfoBindingSource.Current).checkTitle, MediaInfoBindingSource);
            }
        }

        private void TextEditSubtitle_Leave(object sender, EventArgs e)
        {
            if (((MEDIAINFO)MediaInfoBindingSource.Current) != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((MEDIAINFO)MediaInfoBindingSource.Current).checkSubtitle, MediaInfoBindingSource);
            }
        }

        private void TextEditCaption_Leave(object sender, EventArgs e)
        {
            if (((MEDIAINFO)MediaInfoBindingSource.Current) != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((MEDIAINFO)MediaInfoBindingSource.Current).checkCaption, MediaInfoBindingSource);
            }
        }

        private void ButtonEditImage1LowRes_Leave(object sender, EventArgs e)
        {
            if (((MEDIAINFO)MediaInfoBindingSource.Current) != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((MEDIAINFO)MediaInfoBindingSource.Current).checkImage1, MediaInfoBindingSource);
                TextEditCaption.Focus();
            }
        }

        private void ButtonEditImage2MidRes_Leave(object sender, EventArgs e)
        {
            if (((MEDIAINFO)MediaInfoBindingSource.Current) != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((MEDIAINFO)MediaInfoBindingSource.Current).checkImage2, MediaInfoBindingSource);
                TextEditCaption.Focus();
            }
        }

        private void ButtonEditImage3HighRes_Leave(object sender, EventArgs e)
        {
            if (((MEDIAINFO)MediaInfoBindingSource.Current) != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((MEDIAINFO)MediaInfoBindingSource.Current).checkImage3, MediaInfoBindingSource);
                TextEditCaption.Focus();
            }
        }

        private void ButtonEditImage4ThmNail_Leave(object sender, EventArgs e)
        {
            if (((MEDIAINFO)MediaInfoBindingSource.Current) != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((MEDIAINFO)MediaInfoBindingSource.Current).checkImage4, MediaInfoBindingSource);
                TextEditCaption.Focus();
            }
        }

        private void ImageComboBoxEditSeverity_Leave(object sender, EventArgs e)
        {
            if (((MEDIAINFO)MediaInfoBindingSource.Current) != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((MEDIAINFO)MediaInfoBindingSource.Current).checkSeverity, MediaInfoBindingSource);
            }
        }

        private void ComboBoxEditType_TextChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            gridLookUpEditProduct.Enabled = true;
            ImageComboBoxEditCategory.Enabled = true;
            checkEditAllCategory.Enabled = true;
            ButtonEditsvcStartDate.Enabled = true;
            ButtonEditsvcEndDate.Enabled = true;

            LoadCodeLookupValues(ComboBoxEditType.Text, bindingSourceCodeNameProduct);

            if (ComboBoxEditType.Text == "HDR") {
                gridLookUpEditProduct.Enabled = false;
                ImageComboBoxEditCategory.Text = string.Empty;
                ImageComboBoxEditCategory.Enabled = false;
                checkEditAllCategory.Checked = false;
                checkEditAllCategory.Enabled = false;
                ButtonEditsvcStartDate.Text = string.Empty;
                ButtonEditsvcStartDate.Enabled = false;
                ButtonEditsvcEndDate.Text = string.Empty;
                ButtonEditsvcEndDate.Enabled = false;
            }

            this.Cursor = Cursors.Default;
        }

        private void DateEditsvcStartDate_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { StartPosition = FormStartPosition.CenterScreen };
            xform.Show();
        }

        private void DateEditsvcStartDate_TextChanged(object sender, EventArgs e)
        {
            ButtonEditsvcStartDate.Text = validCheck.convertDate(ButtonEditsvcStartDate.Text);
        }

        private void DateEditsvcEndDate_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { StartPosition = FormStartPosition.CenterScreen };
            xform.Show();
        }

        private void DateEditsvcEndDate_TextChanged(object sender, EventArgs e)
        {
            ButtonEditsvcEndDate.Text = validCheck.convertDate(ButtonEditsvcEndDate.Text);
        }

        private void repositoryItemButtonEdit_Item_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog() { Title = "Open Image", InitialDirectory = imagesRoot })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (dlg.FileName.ToLower().IndexOf(imagesRoot.ToLower()) != -1)
                        GridViewAdditionalImages.SetFocusedValue(dlg.FileName.Substring(imagesRoot.Length));
                    else
                        GridViewAdditionalImages.SetFocusedValue(dlg.FileName);
                }
            }
        }

        private void ButtonAddRow_Click(object sender, EventArgs e)
        {
            if (newRowRec == true)
                MessageBox.Show("Please save the new Media Information record before attempting to add more additional images.");
            else
            {

                Modified = true;
                GridViewAdditionalImages.AddNewRow();
                GridViewAdditionalImages.SetFocusedRowCellValue("LINK_TABLE", "MEDIAITEM");
                if (newRec == true)
                    GridViewAdditionalImages.SetFocusedRowCellValue("LINK_VALUE", int.MaxValue);
                else
                    GridViewAdditionalImages.SetFocusedRowCellValue("LINK_VALUE", GridViewMediaInfo.GetFocusedRowCellValue("ID"));
                GridViewAdditionalImages.SetFocusedRowCellValue("RECTYPE", "IMAGE");
                GridViewAdditionalImages.SetFocusedRowCellValue("USER_DEC1", 0);
                GridViewAdditionalImages.SetFocusedRowCellValue("USER_DEC2", 0);
                GridViewAdditionalImages.SetFocusedRowCellValue("USER_INT1", 0);
                GridViewAdditionalImages.SetFocusedRowCellValue("USER_INT2", 0);
                GridViewAdditionalImages.SetFocusedRowCellValue("USER_TXT1", "");
                GridViewAdditionalImages.SetFocusedRowCellValue("USER_TXT2", "");
                GridViewAdditionalImages.SetFocusedRowCellValue("USER_TXT3", "");
                GridViewAdditionalImages.SetFocusedRowCellValue("USER_TXT4", "");

                newRowRec = true;
            }
        }

        private void ButtonDelRow_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this image?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int hand = GridViewAdditionalImages.FocusedRowHandle;
                GridViewAdditionalImages.DeleteRow(hand);
                MediaInfoBindingSource.EndEdit();
                context.SaveChanges();
                newRowRec = false;
                Modified = true;
            }
        }

        private void ImageComboBoxEditLang_Leave(object sender, EventArgs e)
        {
            if (((MEDIAINFO)MediaInfoBindingSource.Current) != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((MEDIAINFO)MediaInfoBindingSource.Current).checkLang, MediaInfoBindingSource);
            }
        }

        private void ImageComboBoxEditCode_Leave(object sender, EventArgs e)
        {
            if (((MEDIAINFO)MediaInfoBindingSource.Current) != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((MEDIAINFO)MediaInfoBindingSource.Current).checkCode, MediaInfoBindingSource);
            }
        }

        private void ImageComboBoxEditSection_Leave(object sender, EventArgs e)
        {
            if (((MEDIAINFO)MediaInfoBindingSource.Current) != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((MEDIAINFO)MediaInfoBindingSource.Current).checkSection, MediaInfoBindingSource);
            }
        }

        private void ImageComboBoxEditAgency_Leave(object sender, EventArgs e)
        {
            if (((MEDIAINFO)MediaInfoBindingSource.Current) != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((MEDIAINFO)MediaInfoBindingSource.Current).checkAgency, MediaInfoBindingSource);
            }
        }

        private void ImageComboBoxEditCategory_Leave(object sender, EventArgs e)
        {
            if (((MEDIAINFO)MediaInfoBindingSource.Current) != null)
            {
                //We need to allow values for category that are not in ROOMCOD to handle ones from external xml sources
                var row = ImageComboBoxEditCategory.GetSelectedDataRow() as CodeName;
                string val = row?.Code;
                if (row == null || ImageComboBoxEditCategory.Text != row.DisplayName) {
                    val = ImageComboBoxEditCategory.Text;
                }
                if (currentVal != val)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((MEDIAINFO)MediaInfoBindingSource.Current).checkCat, MediaInfoBindingSource);
            }
        }

        private void GridViewAdditionalImages_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridColumn colItem, colDesc, colTag;
            ColumnView view = sender as ColumnView;
            view.ClearColumnErrors();
            colItem = view.Columns["ITEM"];
            colDesc = view.Columns["DESCRIPTION"];
            colTag = view.Columns["TAG"];
            string val1 = view.GetRowCellDisplayText(e.RowHandle, colItem);
            string val2 = view.GetRowCellDisplayText(e.RowHandle, colDesc);
            string val3 = view.GetRowCellDisplayText(e.RowHandle, colTag);

            if (string.IsNullOrWhiteSpace(val1))
            {
                e.Valid = false;
                view.SetColumnError(colItem, "Filename cannot be blank.");
            }
            if (string.IsNullOrWhiteSpace(val2))
            {
                e.Valid = false;
                view.SetColumnError(colDesc, "Caption cannot be blank.");
            }
            if (string.IsNullOrWhiteSpace(val3))
            {
                e.Valid = false;
                view.SetColumnError(colTag, "Resolution cannot be blank.");
            }
        }

        private void GridViewAdditionalImages_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void expandContractGridButton_Click(object sender, EventArgs e)
        {
        }

        private void matchingReports()
        {
            GridViewMediaInfo.RefreshData();
            GridViewMediaInfo.ClearColumnsFilter();
            if (!GridViewMediaInfo.IsFilterRow(GridViewMediaInfo.FocusedRowHandle))
            {
                int ID = (int)GridViewMediaInfo.GetFocusedRowCellValue("ID");
                MediaInfoMatchForm xform = new MediaInfoMatchForm(context, ID);
                xform.Show();
            }
            else
                MessageBox.Show("Please select a row before attempting this action.");
        }

        private void removeFromReports(int ID)
        {
            GridViewMediaInfo.ClearColumnsFilter();
            if (!GridViewMediaInfo.IsFilterRow(GridViewMediaInfo.FocusedRowHandle))
            {
                DialogResult select = XtraMessageBox.Show("Are you sure you wish to remove this section from all Media Reports?", Name, MessageBoxButtons.YesNo);
                if (select == System.Windows.Forms.DialogResult.Yes)
                {
                    var mediaRptItem = context.MediaRptItem
                        .Include(mri => mri.MEDIARPT)
                        .Where(mri => mri.SECTION_ID == ID);
                    foreach (var result in mediaRptItem)
                    {
                        //Flag as changed all the reports from which this section is removed
                        result.MEDIARPT.ChgDate = DateTime.Now;
                        context.DeleteObject(result);
                    }
                    context.SaveChanges();
                }
            }
            else
                MessageBox.Show("Please select a row before attempting this action.");
        }

        private void createNewReports()
        {
            GridViewMediaInfo.ClearColumnsFilter();
            if (!GridViewMediaInfo.IsFilterRow(GridViewMediaInfo.FocusedRowHandle))
            {
                MediaRptForm xform = new MediaRptForm(context, (MEDIAINFO)MediaInfoBindingSource.Current) { MdiParent = this.MdiParent }; ;
                xform.Show();
            }
            else
                MessageBox.Show("Please select a row before attempting this action.");
        }

        private void addToReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void AddToReports()
        {
            GridViewMediaInfo.ClearColumnsFilter();
            if (!GridViewMediaInfo.IsFilterRow(GridViewMediaInfo.FocusedRowHandle))
            {
                MediaInfoMatchForm xform = new MediaInfoMatchForm(context, (MEDIAINFO)MediaInfoBindingSource.Current);
                xform.Show();
            }
            else
                MessageBox.Show("Please select a row before attempting this action.");
        }

        private void createNewReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void removeFromReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void reportsContainingThisSectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ButtonCreateThumbnailLowRes_Click(object sender, EventArgs e)
        {
            CreateThumbNail(ButtonEditImage1LowRes.Text);
        }

        private void ButtonCreateThumbnailMedRes_Click(object sender, EventArgs e)
        {
            CreateThumbNail(ButtonEditImage2MedRes.Text);
        }

        private void ButtonCreateThumbNailHighRes_Click(object sender, EventArgs e)
        {
            CreateThumbNail(ButtonEditImage3HighRes.Text);
        }

        private void CreateThumbNail(string path)
        {
            MediaInfo.MediaInfoSys MediaSys = new MediaInfo.MediaInfoSys();
            string NewImagePath = MediaSys.CreateThumbnail(path);
            if (!(NewImagePath == "") || !(NewImagePath == string.Empty))
            {
                ButtonEditImage4ThmNail.Text = NewImagePath;
                GridViewMediaInfo.SetFocusedRowCellValue("IMAGE4", NewImagePath);
            }
        }

        private void SaveRecord()
        {
            if (MediaInfoBindingSource.Current == null)
                return;
            MEDIAINFO record = (MEDIAINFO)MediaInfoBindingSource.Current;

            //if (TextEditBrowserText.Text != webBrowserMediaInfoText.Document.Window.Frames[0].Document.Body.InnerHtml)
            //{
            //    TextEditBrowserText.Text = webBrowserMediaInfoText.Document.Window.Frames[0].Document.Body.InnerHtml;
            //    Modified = true;
            //}
            UpdateHtmlBinding();

            ResourceBindingSource.EndEdit();
            GridViewMediaInfo.CloseEditor();
            //MediaInfoBindingNavigator.Focus();//trigger field leave event
            bool temp = newRec;
            int ID = (int)GridViewMediaInfo.GetFocusedRowCellValue("ID");

            //We need to allow values for category that are not in ROOMCOD to handle ones from external xml sources
            CodeName row = ImageComboBoxEditCategory.GetSelectedDataRow() as CodeName;
            if (row == null || ImageComboBoxEditCategory.Text != row.DisplayName) {
                record.CAT = ImageComboBoxEditCategory.Text;
            }

            if (checkForms())
            {
                errorProvider1.Clear();
                Modified = false;
                newRec = false;
                webCheck = false;
                newRowRec = false;
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
                if (ID == int.MaxValue)
                {
                    int newID = (int)GridViewMediaInfo.GetFocusedRowCellValue("ID");
                    GridViewAdditionalImages.MoveFirst();
                    for (int x = 0; x < GridViewAdditionalImages.RowCount; x++)
                    {
                        GridViewAdditionalImages.SetFocusedRowCellValue("LINK_VALUE", newID);
                        GridViewAdditionalImages.MoveNext();
                    }
                    ResourceBindingSource.EndEdit();
                    context.SaveChanges();
                }

            }

            if (!temp && !Modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (MEDIAINFO)MediaInfoBindingSource.Current);
          
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private void mediaInfoMaint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewMediaInfo.IsFilterRow(GridViewMediaInfo.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void CheckEditInactive_Modified(object sender, EventArgs e)
        {
            Modified = true;
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewMediaInfo.FocusedColumn.FieldName;
            string value = String.Empty;

            if (!string.IsNullOrWhiteSpace(GridViewMediaInfo.GetFocusedDisplayText()))
                value = GridViewMediaInfo.GetFocusedDisplayText();

            if (!string.IsNullOrWhiteSpace(value))
            {
                //I think the original query cannot have the []
                string query = String.Format("it.SECTION like '{0}%'", GridViewMediaInfo.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "SECTION"));
                var special = context.MEDIAINFO.Where(query);

               
                if (!string.IsNullOrWhiteSpace(GridViewMediaInfo.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "LANG")))
                {
                    query = String.Format("it.{0} like '{1}%'", "[LANG]", GridViewMediaInfo.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "LANG"));
                    special = special.Where(query);
                }
                if (!string.IsNullOrWhiteSpace(GridViewMediaInfo.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "TYPE")))
                {
                    query = String.Format("it.{0} like '{1}%'", "[TYPE]", GridViewMediaInfo.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "TYPE"));
                    special = special.Where(query);
                }
                if (!string.IsNullOrWhiteSpace(GridViewMediaInfo.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE")))
                {
                    query = String.Format("it.{0} like '{1}%'", "[CODE]", GridViewMediaInfo.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                    special = special.Where(query);
                }

                int count = special.Count();
                if (count > 0)
                {
                    
                    MediaInfoBindingSource.DataSource = special;
                    GridViewMediaInfo.FocusedRowHandle = 0;
                    GridViewMediaInfo.FocusedColumn.FieldName = colName;
                    GridViewMediaInfo.ClearColumnsFilter();
                    //if (!string.IsNullOrWhiteSpace(special.First().TEXT))
                    //    webBrowserMediaInfoText.Document.Window.Frames[0].Document.Body.InnerHtml = special.First().TEXT.ToString();

                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewMediaInfo.ClearColumnsFilter();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void repositoryItemPopupContainerEditPreview_ButtonClick(object sender, ButtonPressedEventArgs e)
        {         
            pictureEditPreviewAddImg.Image = null;
            
            try
            {
                using (var stream = new MemoryStream(File.ReadAllBytes(imagesRoot + GridViewAdditionalImages.GetFocusedRowCellDisplayText(ColumnItem))))
                {

                    pictureEditPreviewAddImg.Image = Image.FromStream(stream);                   
                }
               
            }
            catch
            {
                try
                {
                    using (var stream = new MemoryStream(File.ReadAllBytes(GridViewAdditionalImages.GetFocusedRowCellDisplayText(ColumnItem))))
                    {
                        pictureEditPreviewAddImg.Image = Image.FromStream(stream);
                    }
                   
                }
                catch
                {
                    return;
                }
            }
          
        }

        private void ImageComboBoxEditAgency_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ImageComboBoxEditAgency.Text))
                checkEditAllAgency.Checked = true;
            else
                checkEditAllAgency.Checked = false;
        }

        private void ImageComboBoxEditCategory_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ImageComboBoxEditCategory.Text))
                checkEditAllCategory.Checked = true;
            else
                checkEditAllCategory.Checked = false;
        }

        private void ButtonSaveChanges_Click(object sender, System.EventArgs e)
        {
            GridViewAdditionalImages.FocusedColumn = GridViewAdditionalImages.Columns["LINK_VALUE"];
            if (GridViewAdditionalImages.UpdateCurrentRow())
            {
                ResourceBindingSource.EndEdit();
                SaveRecord();
                newRowRec = false;
                Modified = false;
            }
        }

        private void mediaInfoMaint_Shown(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Stopwatch stopwatch = Stopwatch.StartNew();
            while (true)
            {
                //some other processing to do STILL POSSIBLE
                if (stopwatch.ElapsedMilliseconds >= 1000)
                {
                    break;
                }
                //Thread.Sleep(1); //so processor can rest for a while
            }
            this.Cursor = Cursors.Default;
        }

        private void buttonEditResEndDate_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { StartPosition = FormStartPosition.CenterScreen };
            xform.Show();
        }

        private void buttonEditResStartDate_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { StartPosition = FormStartPosition.CenterScreen };
            xform.Show();
        }

        private void barButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddNewRec();
        }

        private void barButtonItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MediaInfoBindingSource.Current == null)
                return;
            xtraTabControlMediaInfo.SelectedTabPageIndex = 0;
            GridViewAdditionalImages.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                Modified = false;
                newRec = false;
                //webBrowserMediaInfoText.Document.Window.Frames[0].Document.Body.InnerHtml = String.Empty;
                htmlEditor.BodyHtml = string.Empty;
                _originalHtml = htmlEditor.BodyHtml;
                MediaInfoBindingSource.RemoveCurrent();
                errorProvider1.Clear();
                context.SaveChanges();
                webCheck = false;
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);
            }
            //loadBrowser();
            currentVal = gridLookUpEditProduct.Text;
            gridLookUpEditProduct.Focus();
            setReadOnly(true);
        }

        private void barButtonItemClone_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MediaInfoBindingSource.Current != null)
                if (move()) {
                    //Clone the obejct property by property rather than using MemberwiseClone because MemberwiseClone
                    //will attempt to copy the relationship manager which will then not allow the cloned object to be
                    //added to the binding source because it is no longer the same relationship manager.
                    var current = (MEDIAINFO)MediaInfoBindingSource.Current;
                    var info = new MEDIAINFO {
                        Agency = current.Agency,
                        CAPTION = current.CAPTION,
                        CAT = current.CAT,
                        ChgDate = DateTime.Now,
                        CODE = current.CODE,
                        Consent = current.Consent,
                        IMAGE1 = current.IMAGE1,
                        IMAGE2 = current.IMAGE2,
                        IMAGE3 = current.IMAGE3,
                        IMAGE4 = current.IMAGE4,
                        ImagesRoot = current.ImagesRoot,
                        Inactive = current.Inactive,
                        Inhouse = current.Inhouse,
                        LANG = current.LANG,
                        ROOM = current.ROOM,
                        ResDate_Start = current.ResDate_Start,
                        ResDate_End = current.ResDate_End,
                        SvcDate_Start = current.SvcDate_Start,
                        SvcDate_End = current.SvcDate_End,
                        SECTION = current.SECTION,
                        Severity = current.Severity,
                        SUBTITLE = current.SUBTITLE,
                        TEXT = current.TEXT,
                        TITLE = current.TITLE,
                        TYPE = current.TYPE
                    };
                    //clear flags so we don't get save warnings displaying the new record
                    Modified = false;
                    newRec = false;
                    MediaInfoBindingSource.Add(info);
                    MediaInfoBindingSource.Position = MediaInfoBindingSource.Count;
                    //set flags so the user will get save warnings when leaving or discarding the new record
                    Modified = true;
                    newRec = true;
                    setReadOnly(false);
                }
        }

        private void barButtonItemExpand_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barButtonItemExpand.Tag.ToString() == "shrunk") {
                barButtonItemExpand.Tag = "expanded";
                GridViewMediaInfo.Columns["CAT"].Visible = true;
                GridViewMediaInfo.Columns["CAT"].VisibleIndex = 4;
                GridViewMediaInfo.Columns["Agency"].Visible = true;
                GridViewMediaInfo.Columns["Agency"].VisibleIndex = 5;
                GridViewMediaInfo.Columns["SvcDate_Start"].Visible = true;
                GridViewMediaInfo.Columns["SvcDate_Start"].VisibleIndex = 6;
                GridViewMediaInfo.Columns["SvcDate_End"].Visible = true;
                GridViewMediaInfo.Columns["SvcDate_End"].VisibleIndex = 7;
                GridViewMediaInfo.Columns["TYPE"].Width = 35;
                GridViewMediaInfo.Columns["CODE"].Width = 65;
            }
            else {
                barButtonItemExpand.Tag = "shrunk";
                GridViewMediaInfo.Columns["CAT"].Visible = false;
                GridViewMediaInfo.Columns["Agency"].Visible = false;
                GridViewMediaInfo.Columns["SvcDate_Start"].Visible = false;
                GridViewMediaInfo.Columns["SvcDate_End"].Visible = false;
            }
        }

        private void barButtonItemReportsContainingSection_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            matchingReports();
        }

        private void barButtonItemAddToReports_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddToReports();
        }

        private void barButtonItemRemoveFromReports_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!GridViewMediaInfo.IsFilterRow(GridViewMediaInfo.FocusedRowHandle)) {
                int ID = (int)GridViewMediaInfo.GetFocusedRowCellValue("ID");
                removeFromReports(ID);
            }
        }

        private void barButtonItemCreateNewReports_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            createNewReports();
        }

        private void htmlEditor_HtmlChanged(object sender, EventArgs e)
        {
            //Modified = true;
        }

        private void barButtonItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //MediaInfoBindingNavigator.Focus();
            SaveRecord();
            barSubItemReports.Enabled = true;
            //Jan 30 KJM - removed the function that separated the saving of resource images to a separate routine as this was the cause for numerous problems       
        }

    }
}

