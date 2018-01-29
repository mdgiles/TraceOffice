using FlexModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Card;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using System.ComponentModel.DataAnnotations;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using System.Linq;
using System.Collections;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Runtime.InteropServices;

namespace TraceForms
{

    public partial class MediaRptForm : DevExpress.XtraEditors.XtraForm
    {
        public string currentVal;
        public bool _modified = false;
        public bool newRec = false;
        public bool temp = false;
        public string reportsRoot;
        const string colName = "ColumnCode";
        public FlextourEntities context;
        public string username;
        public string keyLogger;
        public MEDIAINFO record = null;
        public List<int> handle = new List<int>();
        public List<int?> sections = new List<int?>();
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        List<CodeName> _citycodLookup;
        List<CodeName> _hotelLookup;
        List<CodeName> _packLookup;
        List<CodeName> _compLookup;
        List<CodeName> _waypointLookup;

        public MediaRptForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
            LoadLookups();
        }

        public MediaRptForm(FlextourEntities cont, MEDIAINFO mediaValues)
        {
            InitializeComponent();
            context = cont;
            LoadLookups();
            IEnumerable<MediaRptItem> mediaRecs = from media in context.MediaRptItem where media.REPORT_ID == int.MaxValue select media;
            MediaRptItemBindingSource.DataSource = mediaRecs;
            foreach (MediaRptItem media in mediaRecs)
                context.DeleteObject(media);
            MediaRptBindingSource.DataSource = from mediaRptRec in context.MEDIARPT where mediaRptRec.CODE == mediaValues.CODE && mediaRptRec.LANG == mediaValues.LANG && mediaRptRec.TYPE == mediaValues.TYPE select mediaRptRec;
            record = mediaValues;
        }

        private void loadmedia(MEDIAINFO record)
        {
            if (record != null)
            {
                AddNewRec();
                GridViewMediaRpt.SetFocusedRowCellValue("ID", int.MaxValue);
                GridViewMediaRpt.SetFocusedRowCellValue("TYPE", record.TYPE);
                GridViewMediaRpt.SetFocusedRowCellValue("LANG", record.LANG);
                GridViewMediaRpt.SetFocusedRowCellValue("CODE", record.CODE);
                GridViewMediaRpt.SetFocusedRowCellValue("CAT", record.CAT);
                GridViewMediaRpt.SetFocusedRowCellValue("AGENCY", record.Agency);
                GridViewMediaRpt.SetFocusedRowCellValue("SVCDATE_START", record.SvcDate_Start);
                GridViewMediaRpt.SetFocusedRowCellValue("SVCDATE_END", record.SvcDate_End);
                ComboBoxEditSvcType.Text = record.TYPE;
                ImageComboBoxEditLanguage.EditValue = record.LANG;
                gridLookUpEditProductValue.EditValue = record.CODE;
                ImageComboBoxEditCat.EditValue = record.CAT;
                ImageComboBoxEditAgency.EditValue = record.Agency;
                ButtonEditSvcStartDate.Text = record.SvcDate_Start.ToString();
                ButtonEditSvcEndDate.Text = record.SvcDate_End.ToString();
                searchLookup(record.CODE, record.LANG, record.TYPE, record.CAT, record.SECTION);

            }
        }
        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);
            username = sys.User.Name;
            reportsRoot = sys.Settings.ReportsRoot;
        }

        private void LoadLookups()
        {
            //MediaRptItemBindingSource.DataSource = context.MediaRptItem;
            ImageComboBoxEditLanguage.TextChanged += LanguageTextChanged;
            ImageComboBoxEditCat.TextChanged += CategoryTextChanged;
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxItem loadNull = new ImageComboBoxItem() { Description = "NULL", Value = DBNull.Value };
            ImageComboBoxEditLanguage.Properties.Items.Add(loadBlank);
            ImageComboBoxEditAgency.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCat.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCatLookup.Properties.Items.Add(loadBlank);
            ImageComboBoxEditSectionLookup.Properties.Items.Add(loadBlank);
            ImageComboBoxEditLangLookup.Properties.Items.Add(loadBlank);

            var lang = from langRec in context.LANGUAGE orderby langRec.CODE ascending select new { langRec.CODE, langRec.NAME };
            var agy = from agyRec in context.AGY orderby agyRec.NO ascending select new { agyRec.NO, agyRec.NAME };
            var cat = from catRec in context.ROOMCOD orderby catRec.CODE ascending select new { catRec.CODE, catRec.DESC };
            var sec = from lookRec in context.LOOKUP where lookRec.LINK_TABLE == "MEDIAINFO" select new { lookRec.CODE, lookRec.DESC };
            foreach (var result in lang)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = String.Format("{0}  ({1})", result.CODE.TrimEnd(), result.NAME.TrimEnd()), Value = result.CODE.TrimEnd() };
                ImageComboBoxEditLanguage.Properties.Items.Add(load);
                ImageComboBoxEditLangLookup.Properties.Items.Add(load);
            }

          
            foreach (var result in agy)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = String.Format("{0}  ({1})", result.NO.TrimEnd(), result.NAME.TrimEnd()), Value = result.NO.TrimEnd() };
                ImageComboBoxEditAgency.Properties.Items.Add(load);
            }

            
            foreach (var result in cat)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = String.Format("{0}  ({1})", result.CODE.TrimEnd(), result.DESC.TrimEnd()), Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCat.Properties.Items.Add(load);
                ImageComboBoxEditCatLookup.Properties.Items.Add(load);
            }

            
            foreach (var result in sec)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = String.Format("{0}  ({1})", result.CODE.TrimEnd(), result.DESC.TrimEnd()), Value = result.CODE.TrimEnd() };
                ImageComboBoxEditSectionLookup.Properties.Items.Add(load);
            }

            var report = from rptType in context.RPTTYPE where rptType.MEDIA_RPT == true select new { rptType.CODE };
            foreach (var result in report)
                ComboBoxEditRptType.Properties.Items.Add(result.CODE);

           
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

            setReadOnly(true);
            enableNavigator(false);
        }

        public bool Modified
        {
            get {
                return _modified;
            }
            set {
                _modified = value;
                if (value && MediaRptBindingSource.Current != null) {
                    //NB: Before updating any property on the entity, any pending edits must be committed 
                    //with bindingSource.EndEdit, other when the properties are set the form bindings are
                    //automatically refreshed, which causes any pending edits to be lost. 
                    MediaRptBindingSource.EndEdit();
                    MEDIARPT rpt = (MEDIARPT)MediaRptBindingSource.Current;
                    rpt.ChgDate = DateTime.Now;
                }
            }
        }

        void setReadOnly(bool value)
        {
            ComboBoxEditRptType.Properties.ReadOnly = value;
            ImageComboBoxEditLanguage.Properties.ReadOnly = value;
            ImageComboBoxEditLangLookup.Properties.ReadOnly = value;
            gridLookUpEditProductValue.Properties.ReadOnly = value;
            gridLookUpEditProductInfo.Properties.ReadOnly = value;
            ImageComboBoxEditSectionLookup.Properties.ReadOnly = value;
            ComboBoxEditSvcType.Properties.ReadOnly = value;
            ComboBoxEditSvcTypeLookup.Properties.ReadOnly = value;
            ImageComboBoxEditAgency.Properties.ReadOnly = value;
            ImageComboBoxEditCat.Properties.ReadOnly = value;
            ImageComboBoxEditCatLookup.Properties.ReadOnly = value;
            //removed date fields    
        }

        void enableNavigator(bool value)
        {
            bindingNavigatorMoveNextItem.Enabled = value;
            bindingNavigatorMoveLastItem.Enabled = value;
            bindingNavigatorMoveFirstItem.Enabled = value;
            bindingNavigatorMovePreviousItem.Enabled = value;
        }

        void CategoryTextChanged(object sender, EventArgs e)
        {
            ImageComboBoxEditCatLookup.EditValue = ImageComboBoxEditCat.EditValue;
        }

        void LanguageTextChanged(object sender, EventArgs e)
        {
            ImageComboBoxEditLangLookup.EditValue = ImageComboBoxEditLanguage.EditValue;
        }

        void CodeTextChanged(object sender, EventArgs e)
        {
            gridLookUpEditProductInfo.EditValue = gridLookUpEditProductValue.EditValue;
        }

        private void MediaRptBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            GridControlLookupGrid.DataSource = null;
            if (((MEDIARPT)MediaRptBindingSource.Current) != null)
            {
                MEDIARPT rec = (MEDIARPT)MediaRptBindingSource.Current;
                LoadCodeLookupValues(rec.TYPE, bindingSourceCodeNameProduct);
                loadGrids();
                setReadOnly(false);
                enableNavigator(true);
                setCheckEdits();
                if (rec.CODE != null)
                {
                    rec.MediaRptItem.Load();
                    MediaRptItemBindingSource.DataSource = context.MediaRptItem.Where(mri => mri.REPORT_ID == rec.ID);
                    if (rec.MediaRptItem.Count > 0)
                    {
                        sections = (from item in rec.MediaRptItem select item.SECTION_ID).ToList();
                    }
                    else {
                        sections.Clear();
                    }
                }
                else
                    sections.Clear();
            }
            else
            {
                setReadOnly(true);
                enableNavigator(false);
            }
        }

        private void setCheckEdits()
        {
            if (string.IsNullOrWhiteSpace(ImageComboBoxEditCat.Text))
                checkEditAllCategory.Checked = true;
            else
                checkEditAllCategory.Checked = false;

            if (string.IsNullOrWhiteSpace(ImageComboBoxEditAgency.Text))
                checkEditAllAgency.Checked = true;
            else
                checkEditAllAgency.Checked = false;

            if (string.IsNullOrWhiteSpace(gridLookUpEditProductInfo.Text))
                checkEditCodeLookup.Checked = true;
            else
                checkEditCodeLookup.Checked = false;

            if (string.IsNullOrWhiteSpace(ImageComboBoxEditCatLookup.Text))
                checkEditCatLookup.Checked = true;
            else
                checkEditCatLookup.Checked = false;

            if (string.IsNullOrWhiteSpace(ImageComboBoxEditSectionLookup.Text))
                checkEditSectionLookup.Checked = true;
            else
                checkEditSectionLookup.Checked = false;
        }

        private void loadGrids()
        {
            string code = "";
            string lang = "";
            int ID = 0;
            if (((MEDIARPT)MediaRptBindingSource.Current) != null)
                ID = ((MEDIARPT)MediaRptBindingSource.Current).ID;
            if (!string.IsNullOrWhiteSpace(gridLookUpEditProductValue.Text))
                code = gridLookUpEditProductValue.EditValue.ToString();
            if (!string.IsNullOrWhiteSpace(ImageComboBoxEditLanguage.Text))
                lang = ImageComboBoxEditLanguage.EditValue.ToString();
            GridControlAssignGrid.DataSource = from cd in context.MEDIAINFO
                                               from c in context.MediaRptItem
                                               from e in context.MEDIARPT
                                               where e.CODE == code && e.LANG == lang && e.RPT_TYPE == ComboBoxEditRptType.Text && e.ID == ID && c.REPORT_ID == e.ID && cd.ID == c.SECTION_ID
                                               orderby c.POSITION ascending
                                               select new { cd.TYPE, cd.CODE, cd.CAT, cd.Agency, cd.SvcDate_Start, cd.SvcDate_End, cd.SECTION, cd.Inhouse, cd.TITLE, c.ID, c.POSITION };
        }

        private bool checkForms()
        {
            if (!_modified && !newRec)
                return true;
            bool ok1 = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((MEDIARPT)MediaRptBindingSource.Current).checkSplitContainer, MediaRptBindingSource);
            bool ok2 = validCheck.checkAll(panelControlReport.Controls, errorProvider1, ((MEDIARPT)MediaRptBindingSource.Current).checkPanelReport, MediaRptBindingSource);
             if (ok1 && ok2 )
                 return validCheck.saveRec(ref _modified, true, ref newRec, context, MediaRptBindingSource, this.Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref _modified, false, ref newRec, context, MediaRptBindingSource, this.Name, errorProvider1, Cursor);
                return false;
            }
        }

        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }
        private void AddNewRec()
        {
            ButtonUpArrow.Enabled = false;
            ButtonDownArrow.Enabled = false;
            GridViewMediaRpt.ClearColumnsFilter();
            setReadOnly(false);
            xtraTabControl1RptInfoSvcs.SelectedTabPageIndex = 0;
            if (MediaRptBindingSource.Current == null)
            {
                //fake queries in order to create a link between the database table and the binding source
                MediaRptBindingSource.DataSource = from media in context.MEDIARPT where media.CODE == "KJM" select media;
                MediaRptItemBindingSource.DataSource = context.MediaRptItem.Where(mri => mri.REPORT_ID == int.MaxValue);
                MediaRptBindingSource.AddNew();
                if (GridViewMediaRpt.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewMediaRpt.FocusedRowHandle = GridViewMediaRpt.RowCount - 1;
                GridViewMediaRpt.SetFocusedRowCellValue("ROOM", String.Empty);
                GridViewMediaRpt.SetFocusedRowCellValue("CAT", String.Empty);
                GridViewMediaRpt.SetFocusedRowCellValue("DESC", String.Empty);
                GridViewMediaRpt.SetFocusedRowCellValue("AGENCY", String.Empty);
                GridViewMediaRpt.SetFocusedRowCellValue("RPT_FILE", String.Empty);
                GridViewMediaRpt.SetFocusedRowCellValue("Inactive", 0);
                GridViewMediaRpt.SetFocusedRowCellValue("ID", int.MaxValue);
                ComboBoxEditRptType.Focus();
                newRec = true;
                return;
            }
            ComboBoxEditRptType.Focus();
            //bindingNavigatorPositionItem.Focus();  //trigger field leave event
            GridViewAssignGrid.CloseEditor();
            temp = newRec;
            if (checkForms())
            {
                errorProvider1.Clear();
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (MEDIARPT)MediaRptBindingSource.Current);
                MediaRptBindingSource.AddNew();
                if (GridViewMediaRpt.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    GridViewMediaRpt.FocusedRowHandle = GridViewMediaRpt.RowCount - 1;
                GridViewMediaRpt.SetFocusedRowCellValue("ROOM", String.Empty);
                GridViewMediaRpt.SetFocusedRowCellValue("CAT", String.Empty);
                GridViewMediaRpt.SetFocusedRowCellValue("AGENCY", String.Empty);
                GridViewMediaRpt.SetFocusedRowCellValue("DESC", String.Empty);
                GridViewMediaRpt.SetFocusedRowCellValue("RPT_FILE", String.Empty);
                GridViewMediaRpt.SetFocusedRowCellValue("Inactive", 0);
                GridViewMediaRpt.SetFocusedRowCellValue("ID", int.MaxValue);
                ComboBoxEditRptType.Focus();
                newRec = true;
            }
        }
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            AddNewRec();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (newRec)
            {
                ButtonUpArrow.Enabled = true;
                ButtonDownArrow.Enabled = true;
            }
            if (MediaRptBindingSource.Current == null)
                return;
            if (!GridViewMediaRpt.IsFilterRow(GridViewMediaRpt.FocusedRowHandle))
            {
                int ID = (int)GridViewMediaRpt.GetFocusedRowCellValue("ID");
                GridViewAssignGrid.CloseEditor();
                if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Modified = false;
                    newRec = false;
                    MediaRptBindingSource.RemoveCurrent();
                    IEnumerable<MediaRptItem> mediaRecs = from media in context.MediaRptItem where media.REPORT_ID == int.MaxValue || media.REPORT_ID == ID select media;
                    foreach (MediaRptItem media in mediaRecs)
                        context.DeleteObject(media);
                    errorProvider1.Clear();
                    context.SaveChanges();
                    panelControlStatus.Visible = true;
                    LabelStatus.Text = "Record Deleted";
                    rowStatusDelete = new Timer();
                    rowStatusDelete.Interval = 3000;
                    rowStatusDelete.Start();
                    rowStatusDelete.Tick += TimedEvent;
                    
                }
                loadGrids();
                currentVal = ComboBoxEditRptType.Text;
                ComboBoxEditRptType.Focus();
                setReadOnly(true);
            }
        }

        private void TimedEvent(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            //LabelStatus.Text = "";
            rowStatusDelete.Stop();
        }

        private void MediaRptBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (MediaRptBindingSource.Current == null)
                return;

            GridViewAssignGrid.CloseEditor();
            ComboBoxEditRptType.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            int ID = (int)GridViewMediaRpt.GetFocusedRowCellValue("ID");
            bool temp = newRec;
            if (checkForms())
            {
                ButtonUpArrow.Enabled = true;
                ButtonDownArrow.Enabled = true;
                errorProvider1.Clear();
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
                setReadOnly(true);

                if (ID == int.MaxValue)
                {
                    int newID = (int)GridViewMediaRpt.GetFocusedRowCellValue("ID");
                    for (int x = 0; x < handle.Count(); x++)
                    {
                        GridViewMediaRptItem.SetRowCellValue(handle[x], "REPORT_ID", newID);
                    }
                    MediaRptItemBindingSource.EndEdit();
                    context.SaveChanges();
                    loadGrids();
                }
                handle.Clear();
            }

            if (!temp && !_modified)
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (MEDIARPT)MediaRptBindingSource.Current);
            
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            if (sender == rowStatusSave)
                panelControlStatus.Visible = false;
            //LabelStatus.Text = "";
            rowStatusSave.Stop();
        }

        private bool move()
        {
            GridViewAssignGrid.CloseEditor();
            ComboBoxEditRptType.Focus();
           // bindingNavigatorPositionItem.Focus();//trigger field leave event
            temp = newRec;
            if (checkForms())
            {
                errorProvider1.Clear();
                if (!temp)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (MEDIARPT)MediaRptBindingSource.Current);
                newRec = false;
                Modified = false;
                return true;
            }
            return false;
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (move())
                MediaRptBindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                MediaRptBindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                MediaRptBindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                MediaRptBindingSource.MoveLast();
        }

        private void GridViewMediaRpt_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (MediaRptBindingSource.Current == null)
            {
                e.Allow = true;
                return;
            }
            if (string.IsNullOrWhiteSpace(ComboBoxEditRptType.Text))
                e.Allow = false;

            temp = newRec;
            bool temp2 = _modified;
            if (checkForms())
            {
                errorProvider1.Clear();
                e.Allow = true;
                if ((!temp) && temp2)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (MEDIARPT)MediaRptBindingSource.Current);
            }
            else
            {
                if (!temp && !_modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (MEDIARPT)MediaRptBindingSource.Current);
          
                e.Allow = false;
            }
        }

        private void GridViewMediaRpt_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!GridViewMediaRpt.IsFilterRow(e.RowHandle))
                Modified = true;
        }

        private void GridViewMediaRpt_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            temp = newRec;
            if (!temp && checkForms())
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (MEDIARPT)MediaRptBindingSource.Current);
        }

        private void MediaRptForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            IEnumerable<MediaRptItem> mediaRecs = from media in context.MediaRptItem where media.REPORT_ID == int.MaxValue select media;
            foreach (MediaRptItem media in mediaRecs)
                context.DeleteObject(media);
            if (_modified || newRec)
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

        public int LocateRowByMultipleValues(ColumnView view, GridColumn[] columns, object[] values, int startRowHandle)
        {
            // checking whether the arrays have the same length 
            if (columns.Length != values.Length)
                return DevExpress.XtraGrid.GridControl.InvalidRowHandle;
            // obtaining the number of data rows within the view 
            int dataRowCount;
            if (view is CardView)
                dataRowCount = (view as CardView).RowCount;
            else
                dataRowCount = (view as GridView).RowCount;
            // traversing the data rows to find a match 
            bool match;
            object currValue;
            for (int currentRowHandle = startRowHandle; currentRowHandle < dataRowCount;
            currentRowHandle++)
            {
                match = true;
                for (int i = 0; i < columns.Length; i++)
                {
                    currValue = view.GetRowCellValue(currentRowHandle, columns[i]);
                    if (!currValue.Equals(values[i]))
                        match = false;
                }
                if (match)
                    return currentRowHandle;
            }
            // returning the invalid row handle if no matches found 
            return DevExpress.XtraGrid.GridControl.InvalidRowHandle;
        }

        private void AssignToGrid(int section_ID)
        {
            if (sections.Contains(section_ID))
            {
                MessageBox.Show("You are attempting to add an item that is already assigned.");
                return;
            }
            int ID = (int)GridViewMediaRpt.GetFocusedRowCellValue("ID");

            int position = sections.Count() + 1;

            //var recs = ((from mediaRec in context.MediaRptItem where mediaRec.REPORT_ID == ID select mediaRec));
            //position = recs.Count() + 1;   
            GridViewMediaRptItem.AddNewRow();
            GridViewMediaRptItem.SetFocusedRowCellValue("REPORT_ID", ID);
            GridViewMediaRptItem.SetFocusedRowCellValue("SECTION_ID", section_ID);
            GridViewMediaRptItem.SetFocusedRowCellValue("POSITION", position);
            sections.Add(section_ID);
            handle.Add(GridViewMediaRptItem.FocusedRowHandle);
            MediaRptItemBindingSource.EndEdit();

            if (newRec == true)
            {               
        
                GridControlAssignGrid.DataSource = from cd in context.MEDIAINFO                                                  
                                                   where sections.Contains(cd.ID)
                                                   select new { cd.TYPE, cd.CODE, cd.CAT, cd.Agency, cd.SvcDate_Start, cd.SvcDate_End,
                                                       cd.SECTION, cd.Inhouse, cd.TITLE, cd.ID };
             //   GridViewAssignGrid.SetFocusedRowCellValue("Position", position);
            }
            else
            {
                context.SaveChanges();
                loadGrids();
            }
        }
        private void ButtonAssignSect_Click(object sender, EventArgs e)
        {
            int section_ID = (int)GridViewLookup.GetFocusedRowCellValue("ID");
            AssignToGrid(section_ID);
        }

        private void GridControlLookupGrid_DoubleClick(object sender, EventArgs e)
        {
            int section_ID = (int)GridViewLookup.GetFocusedRowCellValue("ID");
            AssignToGrid(section_ID);
        }

        private void ImageComboBoxLang_Leave(object sender, EventArgs e)
        {
            if (((MEDIARPT)MediaRptBindingSource.Current) != null)
            {
                if (currentVal != ((Control)sender).Text)
                    Modified = true;
                validCheck.check(sender, errorProvider1, ((MEDIARPT)MediaRptBindingSource.Current).checkLang, MediaRptBindingSource);
            }
        }

        private void ImageComboBoxCode_Leave(object sender, EventArgs e)
        {
            if (((MEDIARPT)MediaRptBindingSource.Current) != null)
            {
                if (currentVal != ((Control)sender).Text)
                    Modified = true;
                validCheck.check(sender, errorProvider1, ((MEDIARPT)MediaRptBindingSource.Current).checkCode, MediaRptBindingSource);
            }
        }

        private void ImageComboBoxCat_Leave(object sender, EventArgs e)
        {
            if (((MEDIARPT)MediaRptBindingSource.Current) != null)
            {
                if (currentVal != ((Control)sender).Text)
                    Modified = true;
                validCheck.check(sender, errorProvider1, ((MEDIARPT)MediaRptBindingSource.Current).checkCat, MediaRptBindingSource);
            }
        }

        private void ImageComboBoxAgency_Leave(object sender, EventArgs e)
        {
            if (((MEDIARPT)MediaRptBindingSource.Current) != null)
            {
                if (currentVal != ((Control)sender).Text)
                    Modified = true;
                validCheck.check(sender, errorProvider1, ((MEDIARPT)MediaRptBindingSource.Current).checkAgency, MediaRptBindingSource);
            }
        }

        private void ComboBoxEditRptType_Leave(object sender, EventArgs e)
        {
            if (((MEDIARPT)MediaRptBindingSource.Current) != null)
            {
                if (currentVal != ((Control)sender).Text)
                    Modified = true;
                validCheck.check(sender, errorProvider1, ((MEDIARPT)MediaRptBindingSource.Current).checkRptType, MediaRptBindingSource);
            }
        }

        private void ComboBoxEditSvcType_Leave(object sender, EventArgs e)
        {
            if (((MEDIARPT)MediaRptBindingSource.Current) != null)
            {
                if (currentVal != ((Control)sender).Text)
                    Modified = true;
                validCheck.check(sender, errorProvider1, ((MEDIARPT)MediaRptBindingSource.Current).checkSvcType, MediaRptBindingSource);
            }
        }

        private void ButtonEditSvcStartDate_Leave(object sender, EventArgs e)
        {
            if (((MEDIARPT)MediaRptBindingSource.Current) != null)
            {
                if (currentVal != ((Control)sender).Text)
                    Modified = true;
                validCheck.check(sender, errorProvider1, ((MEDIARPT)MediaRptBindingSource.Current).checkStart, MediaRptBindingSource);
            }
        }

        private void ButtonEditSvcEndDate_Leave(object sender, EventArgs e)
        {
            if (((MEDIARPT)MediaRptBindingSource.Current) != null)
            {
                if (currentVal != ((Control)sender).Text)
                    Modified = true;
                validCheck.check(sender, errorProvider1, ((MEDIARPT)MediaRptBindingSource.Current).checkEnd, MediaRptBindingSource);
            }
        }

        private void ButtonEditResStartDate_Leave(object sender, EventArgs e)
        {
            if (((MEDIARPT)MediaRptBindingSource.Current) != null)
            {
                if (currentVal != ((Control)sender).Text)
                    Modified = true;
                validCheck.check(sender, errorProvider1, ((MEDIARPT)MediaRptBindingSource.Current).checkResStart, MediaRptBindingSource);
            }
        }

        private void ButtonEditResEndDate_Leave(object sender, EventArgs e)
        {
            if (((MEDIARPT)MediaRptBindingSource.Current) != null)
            {
                if (currentVal != ((Control)sender).Text)
                    Modified = true;
                validCheck.check(sender, errorProvider1, ((MEDIARPT)MediaRptBindingSource.Current).checkResEnd, MediaRptBindingSource);
            }
        }

        private void TextEditDesc_Leave(object sender, EventArgs e)
        {
            if (((MEDIARPT)MediaRptBindingSource.Current) != null)
            {
                if (currentVal != ((Control)sender).Text)
                    Modified = true;
                validCheck.check(sender, errorProvider1, ((MEDIARPT)MediaRptBindingSource.Current).checkDesc, MediaRptBindingSource);
            }
        }

        private void ButtonEditRptFile_Leave(object sender, EventArgs e)
        {
            if (((MEDIARPT)MediaRptBindingSource.Current) != null)
            {
                if (currentVal != ((Control)sender).Text)
                    Modified = true;
                validCheck.check(sender, errorProvider1, ((MEDIARPT)MediaRptBindingSource.Current).checkRptFile, MediaRptBindingSource);
            }
        }

        private void CheckEditInactive_CheckStateChanged(object sender, EventArgs e)
        {
            Modified = true;
        }

        private void ComboBoxEditSvcType_TextChanged(object sender, EventArgs e)
        {
            ComboBoxEditSvcTypeLookup.Text = ComboBoxEditSvcType.Text;
            LoadCodeLookupValues(ComboBoxEditSvcType.Text, bindingSourceCodeNameProduct);
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

        private void ButtonEditSvcStartDate_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { StartPosition = FormStartPosition.CenterScreen };
            xform.Show();
        }

        private void ButtonEditSvcStartDate_TextChanged(object sender, EventArgs e)
        {
            ButtonEditSvcStartDate.Text = validCheck.convertDate(ButtonEditSvcStartDate.Text);
        }

        private void ButtonEditSvcEndDate_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { StartPosition = FormStartPosition.CenterScreen };
            xform.Show();
        }

        private void ButtonEditSvcEndDate_TextChanged(object sender, EventArgs e)
        {
            ButtonEditSvcEndDate.Text = validCheck.convertDate(ButtonEditSvcEndDate.Text);
        }

        private void ButtonEditResStartDate_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { StartPosition = FormStartPosition.CenterScreen };
            xform.Show();
        }

        private void ButtonEditResStartDate_TextChanged(object sender, EventArgs e)
        {
            ButtonEditResStartDate.Text = validCheck.convertDate(ButtonEditResStartDate.Text);
        }

        private void ButtonEditResEndDate_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { StartPosition = FormStartPosition.CenterScreen };
            xform.Show();
        }

        private void ButtonEditResEndDate_TextChanged(object sender, EventArgs e)
        {
            ButtonEditResEndDate.Text = validCheck.convertDate(ButtonEditResEndDate.Text);
        }

        private void MediaRptForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GridViewMediaRpt.IsFilterRow(GridViewMediaRpt.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = GridViewMediaRpt.FocusedColumn.FieldName;
            string value = String.Empty;

            if (!string.IsNullOrWhiteSpace(GridViewMediaRpt.GetFocusedDisplayText()))
                value = GridViewMediaRpt.GetFocusedDisplayText();

            if (!string.IsNullOrWhiteSpace(value))
            {
                string query = String.Format("it.RPT_TYPE like '{0}%'", GridViewMediaRpt.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "RPT_TYPE"));
                var special = context.MEDIARPT.Where(query);

              
                if (!string.IsNullOrWhiteSpace(GridViewMediaRpt.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "LANG")))
                {
                    query = String.Format("it.{0} like '{1}%'", "[LANG]", GridViewMediaRpt.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "LANG"));
                    special = special.Where(query);
                }
                if (!string.IsNullOrWhiteSpace(GridViewMediaRpt.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "TYPE")))
                {
                    query = String.Format("it.{0} like '{1}%'", "[TYPE]", GridViewMediaRpt.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "TYPE"));
                    special = special.Where(query);
                }
                if (!string.IsNullOrWhiteSpace(GridViewMediaRpt.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE")))
                {
                    query = String.Format("it.{0} like '{1}%'", "[CODE]", GridViewMediaRpt.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                    special = special.Where(query);
                }
               
               
                int count = special.Count();
                if (count > 0)
                {
                    MediaRptBindingSource.DataSource = special;
                    GridViewMediaRpt.FocusedRowHandle = 0;
                    GridViewMediaRpt.FocusedColumn.FieldName = colName;
                    GridViewMediaRpt.ClearColumnsFilter();
                }
                else
                {
                    MessageBox.Show("No records in database.");
                    GridViewMediaRpt.ClearColumnsFilter();
                    MediaRptBindingSource.Clear();
                    //GridControlAssignGrid.DataSource = null;
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void searchLookup(string code, string lang, string type, string cat, string section)
        {
            //dynamic query
            var mediaRecs = from media in context.MEDIAINFO select media;

            if (!string.IsNullOrWhiteSpace(code))
                mediaRecs = mediaRecs.Where(p => p.CODE == code);

            if (!string.IsNullOrWhiteSpace(lang))
                mediaRecs = mediaRecs.Where(p => p.LANG == lang);

            if (!string.IsNullOrWhiteSpace(type))
                mediaRecs = mediaRecs.Where(p => p.TYPE == type);

            if (!string.IsNullOrWhiteSpace(cat))
                mediaRecs = mediaRecs.Where(p => p.CAT == cat);

            if (!string.IsNullOrWhiteSpace(section))
                mediaRecs = mediaRecs.Where(p => p.SECTION == section);

            GridControlLookupGrid.DataSource = mediaRecs;
        }

        private void ButtonSearchLookup_Click(object sender, EventArgs e)
        {
            string code = string.Empty;
            string lang = string.Empty;
            string type = string.Empty;
            string cat = string.Empty;
            string section = string.Empty;

            if (!string.IsNullOrWhiteSpace(gridLookUpEditProductInfo.Text))
                code = gridLookUpEditProductInfo.EditValue.ToString();

            if (!string.IsNullOrWhiteSpace(ImageComboBoxEditLangLookup.Text))
                lang = ImageComboBoxEditLangLookup.EditValue.ToString();

            if (!string.IsNullOrWhiteSpace(ComboBoxEditSvcTypeLookup.Text))
                type = ComboBoxEditSvcTypeLookup.EditValue.ToString();

            if (!string.IsNullOrWhiteSpace(ImageComboBoxEditCatLookup.Text))
                cat = ImageComboBoxEditCatLookup.EditValue.ToString();

            if (!string.IsNullOrWhiteSpace(ImageComboBoxEditSectionLookup.Text))
                section = ImageComboBoxEditSectionLookup.EditValue.ToString();

            searchLookup(code, lang, type, cat, section);
        }

        private void MediaRptForm_Shown(object sender, EventArgs e)
        {
            if (record != null)
            {
                loadmedia(record);
            }
        }

        private void LabelMoveUp_Click(object sender, EventArgs e)
        {
           
        }

        private void LabelMoveDown_Click(object sender, EventArgs e)
        {
           
        }

        private void ImageComboBoxEditLangLookup_Click(object sender, EventArgs e)
        {
            ImageComboBoxEditLangLookup.EditValue = ImageComboBoxEditLangLookup.Text;
        }

        private void ImageComboBoxEditCodeLookup_Click(object sender, EventArgs e)
        {
            gridLookUpEditProductInfo.EditValue = gridLookUpEditProductValue.Text;
        }

        private void ImageComboBoxEditCatLookup_Click(object sender, EventArgs e)
        {
            ImageComboBoxEditCatLookup.EditValue = ImageComboBoxEditCatLookup.Text;
        }

        private void ImageComboBoxEditSectionLookup_Click(object sender, EventArgs e)
        {
            ImageComboBoxEditSectionLookup.EditValue = ImageComboBoxEditSectionLookup.Text;
        }

        private void ComboBoxEditSvcTypeLookup_Click(object sender, EventArgs e)
        {
            ComboBoxEditSvcTypeLookup.EditValue = ComboBoxEditSvcTypeLookup.Text;
        }

        private void ComboBoxEditSvcTypeLookup_TextChanged(object sender, EventArgs e)
        {
            LoadCodeLookupValues(ComboBoxEditSvcTypeLookup.Text, bindingSourceCodeNameInfo);
        }

        private void ButtonEditRptFile_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog() { Title = "Open Image", InitialDirectory = reportsRoot })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (dlg.FileName.ToLower().IndexOf(reportsRoot.ToLower()) != -1)
                        ButtonEditRptFile.Text = dlg.FileName.Substring(reportsRoot.Length);
                    else
                        ButtonEditRptFile.Text = dlg.FileName;
                }
            }
        }

        private void ImageComboBoxEditCat_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ImageComboBoxEditCat.Text))
                checkEditAllCategory.Checked = true;
            else
                checkEditAllCategory.Checked = false;
        }

        private void ImageComboBoxEditAgency_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ImageComboBoxEditAgency.Text))
                checkEditAllAgency.Checked = true;
            else
                checkEditAllAgency.Checked = false;
        }

        private void ImageComboBoxEditCatLookup_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ImageComboBoxEditCatLookup.Text))
                checkEditCatLookup.Checked = true;
            else
                checkEditCatLookup.Checked = false;
        }

        private void ImageComboBoxEditSectionLookup_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ImageComboBoxEditSectionLookup.Text))
                checkEditSectionLookup.Checked = true;
            else
                checkEditSectionLookup.Checked = false;
        }

        private void ButtonDelRow_Click(object sender, EventArgs e)
        {
            if (GridViewAssignGrid.FocusedRowHandle != int.MinValue)
            {
                DialogResult select = XtraMessageBox.Show("Are you sure you wish to remove this section from the Media Report?", Name, MessageBoxButtons.YesNo);
                int ID = 0;
                ID = (int)GridViewAssignGrid.GetFocusedRowCellValue(ColumnIDAsn);
                //int updatePosition = 0;
                int updateReportID = 0;
                if (select == System.Windows.Forms.DialogResult.Yes)
                {
                    MediaRptItem mediaRptItemRec = (from mediaRec in context.MediaRptItem where mediaRec.ID == ID select mediaRec).FirstOrDefault();

                    ID = (int)mediaRptItemRec.SECTION_ID;
                    var NextmediaRptItemRecs = from mediaRec in context.MediaRptItem where mediaRec.REPORT_ID == mediaRptItemRec.REPORT_ID && mediaRec.POSITION > mediaRptItemRec.POSITION select mediaRec;
                    foreach (MediaRptItem rec in NextmediaRptItemRecs)
                    {
                        rec.POSITION -= 1;
                    }
                    context.DeleteObject(mediaRptItemRec);                    
                    sections.Remove(ID);
                    context.SaveChanges();
                    loadGrids();
                }
            }
        }

        private void GridViewMediaRpt_ColumnFilterChanged(object sender, EventArgs e)
        {
            loadGrids();
        }

        private void ButtonDownArrow_Click(object sender, EventArgs e)
        {
            if (GridViewAssignGrid.RowCount == 0 || GridViewAssignGrid.RowCount == 1)
                return;
            //if (!GridControlAssignGrid.IsFocused)
            //{
            //    MessageBox.Show("Please select the row you would like to move.");
            //    return;
            //}

            if (newRec)
            {
                MessageBox.Show("Please save the new record before trying to modify the position.");
                return;
            }

            if (GridViewAssignGrid.UpdateCurrentRow())
            {
                MediaRptBindingSource.EndEdit();
                context.SaveChanges();
                newRec = false;
            }
            else
            {
                MessageBox.Show("Please correct errors in the grid.");
                return;
            }

            if (GridViewAssignGrid.IsLastRow)
            {
                MessageBox.Show("This row is already at highest priority.");
                return;
            }
            else
            {
                
                int currentIDAsn = (int)GridViewAssignGrid.GetFocusedRowCellValue("ID");
                MediaRptItem currRec = (from media in context.MediaRptItem where media.ID == currentIDAsn select media).FirstOrDefault();
                int nextRowHandleAsn = GridViewAssignGrid.FocusedRowHandle + 1;
                int preIDAsn = (int)GridViewAssignGrid.GetRowCellValue(nextRowHandleAsn, ColumnIDAsn);
                MediaRptItem nextRec = (from media in context.MediaRptItem where media.ID == preIDAsn select media).FirstOrDefault();
                // int rowHandleMRptItem = (int)GridViewMediaRptItem.LocateByDisplayText(0, ColumnIDMRptItem, currentIDAsn.ToString());
                short? position = currRec.POSITION;
                currRec.POSITION = nextRec.POSITION;
                nextRec.POSITION = position;
                //int rowHandleMRptItem = (int)GridViewMediaRptItem.LocateByDisplayText(0, ColumnIDMRptItem, currentIDAsn.ToString());
                //int position = (int)Convert.ToInt32(GridViewAssignGrid.GetFocusedRowCellDisplayText(ColumnRptPosition));
                //int nextRowHandleAsn = GridViewAssignGrid.FocusedRowHandle + 1;
                //int nextIDAsn = (int)GridViewAssignGrid.GetRowCellValue(nextRowHandleAsn, ColumnIDAsn);
                //int nextrowHandleMRptItem = (int)GridViewMediaRptItem.LocateByDisplayText(0, ColumnIDMRptItem, nextIDAsn.ToString());
                //int nextPosition = position + 1;
                //GridViewMediaRptItem.SetRowCellValue(rowHandleMRptItem, ColumnPosition, nextPosition);
                //GridViewMediaRptItem.SetRowCellValue(nextrowHandleMRptItem, ColumnPosition, position);
                context.SaveChanges();
                loadGrids();
                GridViewAssignGrid.FocusedRowHandle = nextRowHandleAsn;
            }
        }

        private void ButtonUpArrow_Click(object sender, EventArgs e)
        { 
            if (GridViewAssignGrid.RowCount == 0)
                return;

            if (newRec)
            {
                MessageBox.Show("Please save the new record before trying to modify the position.");
                return;
            }
            //if (!GridControlAssignGrid.IsFocused)
            //{
            //MessageBox.Show("Please select the row you would like to move.");
            //return;
            //}

            if (GridViewAssignGrid.UpdateCurrentRow())
            {
                MediaRptBindingSource.EndEdit();
                context.SaveChanges();
                newRec = false;
            }
            else
            {
                MessageBox.Show("Please correct errors in the grid.");
                return;
            }

            if (GridViewAssignGrid.IsFirstRow)
            {
                MessageBox.Show("This row is already at highest priority.");
                return;
            }
            else
            {
                int currentIDAsn = (int)GridViewAssignGrid.GetFocusedRowCellValue(ColumnIDAsn);
                MediaRptItem currRec = (from media in context.MediaRptItem where media.ID == currentIDAsn select media).FirstOrDefault();
                int preRowHandleAsn = GridViewAssignGrid.FocusedRowHandle - 1;
                int preIDAsn = (int)GridViewAssignGrid.GetRowCellValue(preRowHandleAsn, ColumnIDAsn);
                MediaRptItem prevRec = (from media in context.MediaRptItem where media.ID == preIDAsn select media).FirstOrDefault();
               // int rowHandleMRptItem = (int)GridViewMediaRptItem.LocateByDisplayText(0, ColumnIDMRptItem, currentIDAsn.ToString());
                short? position = currRec.POSITION;
                currRec.POSITION = prevRec.POSITION;
                prevRec.POSITION = position;
                //int prerowHandleMRptItem = (int)GridViewMediaRptItem.LocateByDisplayText(0, ColumnIDMRptItem, preIDAsn.ToString());
                ////int prePosition = position - 1;
                //GridViewMediaRptItem.SetRowCellValue(rowHandleMRptItem, ColumnPosition, prePosition);
                //GridViewMediaRptItem.SetRowCellValue(prerowHandleMRptItem, ColumnPosition, position);
                context.SaveChanges();
                loadGrids();
                GridViewAssignGrid.FocusedRowHandle = preRowHandleAsn;
            }
        }

        private void checkEditInhouse_CheckStateChanged(object sender, EventArgs e)
        {
            Modified = true;
        }
    }
}
