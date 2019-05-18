using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using FlexModel;
using DevExpress.XtraEditors.Controls;
using System.Linq;
using System.Runtime.InteropServices;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;
using FlexEntities.Entities;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Popup;
using DevExpress.Utils.Win;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.Entity.Core.Objects;

namespace TraceForms
{
    public partial class packForm : DevExpress.XtraEditors.XtraForm
    {
        public List<IComprod2> myCommRecs;
        public List<IComprod2> myCommRecsAgy;
        public List<ICommLevel> myCommLvl;
        public string currentVal;
        public bool _modified;
        public bool newRec;
        public bool temp;
        const string colName = "ColumnCodePkg";
        public string username;
        public FlextourEntities _context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        string _accountingURL;
        RepositoryItemImageComboBox _supplierCombo = new RepositoryItemImageComboBox();
        RepositoryItemImageComboBox _operatorCombo = new RepositoryItemImageComboBox();
        Dictionary<String, List<CodeName>> _locationLookups = new Dictionary<String, List<CodeName>>();
        PACK _selectedRecord;

        public packForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
            LoadLookups();
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            _context = new FlextourEntities(sys.Settings.EFConnectionString);
            username = sys.User.Name;
            _accountingURL = sys.Settings.TourAccountingURL;
        }

        private void LoadLookups()
        {          
            //PackBindingSource.DataSource = context.PACK;
            GridColumn columnHotelInfo = gridViewUserFields.Columns.AddField("PackValue");
            columnHotelInfo.VisibleIndex = 1;
            columnHotelInfo.UnboundType = DevExpress.Data.UnboundColumnType.String;
            columnHotelInfo.Visible = true;
            columnHotelInfo.Caption = "Pack Value";
            ColumnLabelUserFields.Visible = true;        
            var agy = from agyRec in _context.AGY orderby agyRec.NO ascending select new { agyRec.NO, agyRec.NAME };
            var pkg = from pkgRec in _context.PACK orderby pkgRec.CODE ascending select new { pkgRec.CODE, pkgRec.NAME };
            var cty = from ctyRec in _context.CITYCOD orderby ctyRec.CODE ascending select new { ctyRec.CODE, ctyRec.NAME };
            var reg = from regRec in _context.REGION orderby regRec.CODE ascending select new { regRec.CODE, regRec.DESC };
            var opr = from operRec in _context.OPERATOR orderby operRec.CODE ascending select new { operRec.CODE, operRec.NAME };
            var pkt = from pktRec in _context.PACKTYPE orderby pktRec.CODE ascending select new { pktRec.CODE, pktRec.DESC };
            var lang = from langRec in _context.LANGUAGE orderby langRec.CODE ascending select new { langRec.CODE, langRec.NAME };
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxEditAltern1.Properties.Items.Add(loadBlank);
            ImageComboBoxEditAltern2.Properties.Items.Add(loadBlank);
            ImageComboBoxEditAltern3.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCity.Properties.Items.Add(loadBlank);
            ImageComboBoxEditRegion.Properties.Items.Add(loadBlank);
            ImageComboBoxEditOperator.Properties.Items.Add(loadBlank);
            ImageComboBoxEditPkgType.Properties.Items.Add(loadBlank);
            ImageComboBoxEditAgency.Properties.Items.Add(loadBlank);
            ImageComboBoxEditLanguage.Properties.Items.Add(loadBlank);
            
            foreach (var result in lang)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditLanguage.Properties.Items.Add(load);        
            }
            foreach (var result in agy)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.NO.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.NO.TrimEnd() };                
                ImageComboBoxEditAgency.Properties.Items.Add(load);               
            }
            foreach (var result in pkg)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditAltern1.Properties.Items.Add(load);
                ImageComboBoxEditAltern2.Properties.Items.Add(load);
                ImageComboBoxEditAltern3.Properties.Items.Add(load);
            }
            foreach (var result in cty)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCity.Properties.Items.Add(load);
            }
            foreach (var result in reg)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.DESC.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditRegion.Properties.Items.Add(load);
            }
            foreach (var result in opr)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditOperator.Properties.Items.Add(load);
            }
            foreach (var result in pkt)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.DESC.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditPkgType.Properties.Items.Add(load);
            }

            _supplierCombo.Items.Add(loadBlank);
            _supplierCombo.Items.AddRange(_context.Supplier
                            .Where(sp => sp.ProductType == "PKG")
                            .OrderBy(o => o.Name).AsEnumerable()
                            .Select(s => new ImageComboBoxItem() { Description = s.Name, Value = s.GUID })
                            .ToList());
            gridControlSupplierProduct.RepositoryItems.Add(_supplierCombo);        //per DX recommendation to avoid memory leaks

            _operatorCombo.Items.Add(loadBlank);
            _operatorCombo.Items.AddRange(_context.OPERATOR
                            .OrderBy(o => o.NAME).AsEnumerable()
                            .Select(s => new ImageComboBoxItem() { Description = $"{s.CODE} ({s.NAME})", Value = s.CODE })
                            .ToList());
            gridControlSupplierProduct.RepositoryItems.Add(_operatorCombo);        //per DX recommendation to avoid memory leaks

            //For the CustomSearchLookupEdit, there are lots of properties to set so we create a repository item
            //in the designer and just assign a data source
            var lookup = new List<CodeName> {
                new CodeName(null)
            };
            lookup.AddRange(_context.ROOMCOD
                            .OrderBy(o => o.CODE)
                            .Select(s => new CodeName() { Code = s.CODE, Name = s.DESC }));
            repositoryItemCustomSearchLookUpEditDefaultCat.DataSource = lookup;
            repositoryItemCustomSearchLookUpEditMappingCat.DataSource = lookup;

            lookup = new List<CodeName> {
                new CodeName(null)
            };
            lookup.AddRange(_context.COMP
                            .OrderBy(o => o.CODE)
                            .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }));
            _locationLookups.Add("OPT", lookup);

            lookup = new List<CodeName> {
                new CodeName(null)
            };
            lookup.AddRange(_context.HOTEL
                            .OrderBy(o => o.CODE)
                            .Select(s => new CodeName() { Code = s.CODE, Name = s.NAME }));
            _locationLookups.Add("HTL", lookup);

            lookup = new List<CodeName> {
                new CodeName(null)
            };
            lookup.AddRange(_context.WAYPOINT
                            .OrderBy(o => o.CODE)
                            .Select(s => new CodeName() { Code = s.CODE, Name = s.DESC }));
            _locationLookups.Add("WAY", lookup);

            Modified = false;
            newRec = false;
            temp = newRec;
            setReadOnly(true);
        }

        private bool Modified
        {
            get
            {
                return _modified;
            }
            set
            {
                _modified = value;
                if (value && PackBindingSource.Current != null) {
                    //NB: Before updating any property on the entity, any pending edits must be committed 
                    //with bindingSource.EndEdit, other when the properties are set the form bindings are
                    //automatically refreshed, which causes any pending edits to be lost. 
                    PackBindingSource.EndEdit();
                    PACK pack = (PACK)PackBindingSource.Current;
                    pack.LAST_UPD = DateTime.Now;
                    pack.UPD_INIT = username;
                }
            }
        }

        void setReadOnly(bool value)
        {
            TextEditCode.Properties.ReadOnly = value;
            gridViewPackages.Columns.ColumnByName(colName).OptionsColumn.AllowEdit = !(value);
        }

        private bool checkForms()
        {
            if (!_modified && !newRec)
                return true;
            bool ok1 = validCheck.checkAll(splitContainerControl1.Panel2.Controls, ErrorProvider, ((PACK)PackBindingSource.Current).checkSplitContainer, PackBindingSource);
            bool ok2 = validCheck.checkAll(panelControlPolicies.Controls, ErrorProvider, ((PACK)PackBindingSource.Current).checkPanelPolicies, PackBindingSource);
            bool ok3 = validCheck.checkAll(panelControlAlternatePkgs.Controls, ErrorProvider, ((PACK)PackBindingSource.Current).checkPanelAlternates, PackBindingSource);
            bool ok4 = validCheck.checkAll(panelControlSvcsIncluded.Controls, ErrorProvider, ((PACK)PackBindingSource.Current).checkPanelSvcs, PackBindingSource);
            if (!CheckMappings()) return false;
            if (!CheckSupplierCategories()) return false;

            if (ok1 && ok2 && ok3 && ok4) {
                var ret = validCheck.saveRec(ref _modified, true, ref newRec, _context, PackBindingSource, this.Name, ErrorProvider, Cursor);
                if (ret) {
                    AccountingAPI.InvokeForProduct(_accountingURL, "PKG", ((PACK)PackBindingSource.Current).CODE);
                }
                return ret;
            }
            else
            {
                validCheck.saveRec(ref _modified, false, ref newRec, _context, PackBindingSource, this.Name, ErrorProvider, Cursor);
                return false;
            }
        }
     
        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        private void TextEditCode_Leave(object sender, EventArgs e)
        {

            if (PackBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, ErrorProvider, ((PACK)PackBindingSource.Current).checkCode, PackBindingSource);
                TextEditCode.Text = TextEditCode.Text.ToUpper();
            }
        }

        private void TextEditName_Leave(object sender, EventArgs e)
        {
            if (PackBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, ErrorProvider, ((PACK)PackBindingSource.Current).checkName, PackBindingSource);
            }
        }

        private void SpinEditNights_Leave(object sender, EventArgs e)
        {
            if (PackBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, ErrorProvider, ((PACK)PackBindingSource.Current).checkNts, PackBindingSource);
            }
        }

        private void ImageComboBoxEditRateBasis_Leave(object sender, EventArgs e)
        {
            if (PackBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, ErrorProvider, ((PACK)PackBindingSource.Current).checkRateBasis, PackBindingSource);
            }
        }

        private void ImageComboBoxEditRstrCde_Leave(object sender, EventArgs e)
        {
            if (PackBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, ErrorProvider, ((PACK)PackBindingSource.Current).checkRstrCode, PackBindingSource);
            }
        }

        private void ImageComboBoxEditAltern1_Leave(object sender, EventArgs e)
        {
            if (PackBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, ErrorProvider, ((PACK)PackBindingSource.Current).checkAltern1, PackBindingSource);
            }
        }

        private void ImageComboBoxEditAltern2_Leave(object sender, EventArgs e)
        {
            if (PackBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, ErrorProvider, ((PACK)PackBindingSource.Current).checkAltern2, PackBindingSource);
            }
        }

        private void ImageComboBoxEditAltern3_Leave(object sender, EventArgs e)
        {
            if (PackBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, ErrorProvider, ((PACK)PackBindingSource.Current).checkAltern3, PackBindingSource);
            }
        }

        private void ImageComboBoxEditOperatorSearch_Leave(object sender, EventArgs e)
        {
            if (PackBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, ErrorProvider, ((PACK)PackBindingSource.Current).checkOper, PackBindingSource);
            }
        }

        private void ImageComboBoxEditPkgTypeSearch_Leave(object sender, EventArgs e)
        {
            if (PackBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, ErrorProvider, ((PACK)PackBindingSource.Current).checkPkgType, PackBindingSource);
            }
        }

        private void ImageComboBoxEditRegionSearch_Leave(object sender, EventArgs e)
        {
            if (PackBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, ErrorProvider, ((PACK)PackBindingSource.Current).checkRegion, PackBindingSource);
            }
        }

        private void SpinEditMaxSgl_Leave(object sender, EventArgs e)
        {
            if (PackBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, ErrorProvider, ((PACK)PackBindingSource.Current).checkMaxSgl, PackBindingSource);
            }
        }

        private void SpinEditMaxDbl_Leave(object sender, EventArgs e)
        {
            if (PackBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, ErrorProvider, ((PACK)PackBindingSource.Current).checkMaxDbl, PackBindingSource);
            }
        }

        private void SpinEditMaxTpl_Leave(object sender, EventArgs e)
        {
            if (PackBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, ErrorProvider, ((PACK)PackBindingSource.Current).checkMaxTpl, PackBindingSource);
            }
        }

        private void SpinEditMaxQua_Leave(object sender, EventArgs e)
        {
            if (PackBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, ErrorProvider, ((PACK)PackBindingSource.Current).checkMaxQua, PackBindingSource);
            }
        }

        private void SpinEditMaxOth_Leave(object sender, EventArgs e)
        {
            if (PackBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, ErrorProvider, ((PACK)PackBindingSource.Current).checkMaxOth, PackBindingSource);
            }
        }

        private void TextEditInclude1_Leave(object sender, EventArgs e)
        {
            if (PackBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, ErrorProvider, ((PACK)PackBindingSource.Current).checkInclude1, PackBindingSource);
            }
        }

        private void TextEditInclude2_Leave(object sender, EventArgs e)
        {
            if (PackBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, ErrorProvider, ((PACK)PackBindingSource.Current).checkInclude2, PackBindingSource);
            }
        }

        private void TextEditInclude3_Leave(object sender, EventArgs e)
        {
            if (PackBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, ErrorProvider, ((PACK)PackBindingSource.Current).checkInclude4, PackBindingSource);
            }
        }

        private void TextEditInclude4_Leave(object sender, EventArgs e)
        {
            if (PackBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, ErrorProvider, ((PACK)PackBindingSource.Current).checkInclude4, PackBindingSource);
            }
        }

        private void TextEditInclude5_Leave(object sender, EventArgs e)
        {
            if (PackBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, ErrorProvider, ((PACK)PackBindingSource.Current).checkInclude5, PackBindingSource);
            }
        }

        private void TextEditInclude6_Leave(object sender, EventArgs e)
        {
            if (PackBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, ErrorProvider, ((PACK)PackBindingSource.Current).checkInclude6, PackBindingSource);
            }
        }

        private void setCheckEdits()
        {
            gridViewPackages.SetFocusedRowCellValue("BUS", "N");
            gridViewPackages.SetFocusedRowCellValue("NON", "N");
            gridViewPackages.SetFocusedRowCellValue("NON_RulesOnly", 0);
            gridViewPackages.SetFocusedRowCellValue("Allow_Freesell", 0);
            gridViewPackages.SetFocusedRowCellValue("Inactive", "N");          
            gridViewPackages.SetFocusedRowCellValue("Use_Pitin", 0);
            gridViewPackages.SetFocusedRowCellValue("FLEX_PKG", "N");
            gridViewPackages.SetFocusedRowCellValue("INCLUDE1", string.Empty);
            gridViewPackages.SetFocusedRowCellValue("INCLUDE2", string.Empty);
            gridViewPackages.SetFocusedRowCellValue("INCLUDE3", string.Empty);
            gridViewPackages.SetFocusedRowCellValue("INCLUDE4", string.Empty);
            gridViewPackages.SetFocusedRowCellValue("INCLUDE5", string.Empty);
            gridViewPackages.SetFocusedRowCellValue("INCLUDE6", string.Empty);
            gridViewPackages.SetFocusedRowCellValue("Language_Code", string.Empty);
            gridViewPackages.SetFocusedRowCellValue("OPER", string.Empty);
            gridViewPackages.SetFocusedRowCellValue("ALTERN_1", string.Empty);
            gridViewPackages.SetFocusedRowCellValue("ALTERN_2", string.Empty);
            gridViewPackages.SetFocusedRowCellValue("ALTERN_3", string.Empty);
            gridViewPackages.SetFocusedRowCellValue("USER_DEC1", 0);
            gridViewPackages.SetFocusedRowCellValue("USER_DEC2", 0);
            gridViewPackages.SetFocusedRowCellValue("USER_INT1", 0);
            gridViewPackages.SetFocusedRowCellValue("USER_INT2", 0);
            gridViewPackages.SetFocusedRowCellValue("USER_TXT1", string.Empty);
            gridViewPackages.SetFocusedRowCellValue("USER_TXT2", string.Empty);
            gridViewPackages.SetFocusedRowCellValue("USER_TXT3", string.Empty);
            gridViewPackages.SetFocusedRowCellValue("USER_TXT4", string.Empty);
            gridViewPackages.SetFocusedRowCellValue("AccountingServiceItem", 1);
            gridViewPackages.SetFocusedRowCellValue("VendorPrepayReqd", 0);
            checkEditAccountingServiceItem.Checked = false;
            checkEditVendorPrepayReqd.Checked = false;
            if (PackBindingSource.Current != null) {
                var pack = (PACK)PackBindingSource.Current;
                pack.AccountingServiceItem = true;
                pack.VendorPrepayReqd = false;
            }
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private void packForm_FormClosing(object sender, FormClosingEventArgs e)
        {
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

        private void gridViewPackages_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (PackBindingSource.Current == null)
            {
                e.Allow = true;
                return;
            }
            temp = newRec;
            bool temp2 = _modified;
            if (checkForms())
            {
                ErrorProvider.Clear();
                e.Allow = true;
                if ((!temp) && temp2)
                    _context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (PACK)PackBindingSource.Current);

                setReadOnly(true);
            }
            else
            {

                if (!temp && !_modified)
                    _context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (PACK)PackBindingSource.Current);
             
                e.Allow = false;
            }
        }

        private void gridViewPackages_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {          
            if (!gridViewPackages.IsFilterRow(e.RowHandle))
            {
                Modified = true;
            }
        }

        private void gridViewPackages_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; 
        }

        private void PackBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            _selectedRecord = (PACK)PackBindingSource.Current;
            if (_selectedRecord != null) {
                ImageComboBoxEditAgency.Text = "";
                ButtonEditDate.Text = "";
                ComboBoxEditSource.Text = "";
                if (!String.IsNullOrEmpty(_selectedRecord.CODE)) { //new record
                    _selectedRecord.SupplierProduct.Load(MergeOption.OverwriteChanges);
                    _selectedRecord.SupplierCategory.Load(MergeOption.OverwriteChanges);
                }
                bindingSourceSupplierProduct.DataSource = _selectedRecord.SupplierProduct;
                supplierCategoryBindingSource.DataSource = _selectedRecord.SupplierCategory;
                GridControlUserfields.DataSource = from userRec in _context.USERFIELDS
                                                   where userRec.LINK_TABLE.Equals("PACK")
                                                   select userRec;
                UpdateCommMarkupGrid("TARIFF", null, "ALL");//refactor to method
            }
        }

        private void gridViewUserFields_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "PackValue" && e.IsGetData)
            {
                string desc = gridViewUserFields.GetRowCellValue(e.ListSourceRowIndex, "LINK_COLUMN").ToString();
                desc = desc.Trim();
                e.Value = gridViewPackages.GetRowCellValue(PackBindingSource.IndexOf(PackBindingSource.Current), desc);
            }
            if (e.Column.FieldName == "PackValue" && e.IsSetData)
            {
                string desc = gridViewUserFields.GetRowCellValue(e.ListSourceRowIndex, "LINK_COLUMN").ToString();
                desc = desc.Trim();
                gridViewPackages.SetRowCellValue(PackBindingSource.IndexOf(PackBindingSource.Current), desc, e.Value);
                Modified = true;
            }
        }

        private void CheckEdit_Modified(object sender, EventArgs e)
        {
            Modified = true;
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            DateTime? date;
            if (ButtonEditDate.Text == "")
            {
                date = null;
            }
            else
            {
                date = Convert.ToDateTime(ButtonEditDate.Text);
            }

            string agency = string.Empty;
            string source = string.Empty;
            if (string.IsNullOrWhiteSpace(ImageComboBoxEditAgency.Text))
                agency = "TARIFF";
            else
                agency = ImageComboBoxEditAgency.Text;

            if (string.IsNullOrWhiteSpace(ComboBoxEditSource.Text))
                source = "ALL";
            else
                source = ComboBoxEditSource.Text;

            UpdateCommMarkupGrid(agency, date, source);//refactor to method
        }

        private void ButtonEditDate_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ButtonEditDate.Text))
                ButtonEditDate.Text = validCheck.convertDate(ButtonEditDate.Text);
        }

        private void ButtonEditDate_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void ImageComboBoxEditCity_Leave(object sender, EventArgs e)
        {
            if (PackBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, ErrorProvider, ((PACK)PackBindingSource.Current).checkCity, PackBindingSource);
            }
        }

        private void gridViewCommissions_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if ((e.Column.FieldName == "ResStartDate" || e.Column.FieldName == "ResEndDate" || e.Column.FieldName == "SvcStartDate" || e.Column.FieldName == "SvcEndDate") && !string.IsNullOrWhiteSpace(e.DisplayText))
                e.DisplayText = validCheck.convertDate(e.DisplayText);                    
        }

        private void gridViewMarkups_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if ((e.Column.FieldName == "ResStartDate" || e.Column.FieldName == "ResEndDate" || e.Column.FieldName == "SvcStartDate" || e.Column.FieldName == "SvcEndDate") && !string.IsNullOrWhiteSpace(e.DisplayText))
                e.DisplayText = validCheck.convertDate(e.DisplayText);                      
        }

        private void UpdateCommMarkupGrid(string Agency, DateTime? TheDate, string Source)
        {
            if (TheDate != null)
            {
                myCommRecs = (from rec in _context.COMPROD2
                              where (rec.TYPE == "PKG") && (rec.Inactive == false) && ((rec.START_DATE <= TheDate) && (rec.END_DATE >= TheDate))
                              select rec).ToList<IComprod2>();
                myCommRecsAgy = (from rec in _context.COMPROD2
                                 where (rec.TYPE == "AGY") && (rec.Inactive == false) && ((rec.START_DATE <= TheDate) && (rec.END_DATE >= TheDate))
                                 select rec).ToList<IComprod2>();
            }
            else
            {
                myCommRecs = (from rec in _context.COMPROD2
                              where (rec.TYPE == "PKG") && (rec.Inactive == false)
                              select rec).ToList<IComprod2>();
                myCommRecsAgy = (from rec in _context.COMPROD2
                                 where (rec.TYPE == "AGY") && (rec.Inactive == false)
                                 select rec).ToList<IComprod2>();
            }

            myCommLvl = (from rec in _context.CommLevel select rec).ToList<ICommLevel>();
            foreach (COMPROD2 rec in myCommRecs)
            {

                rec.SetProductRulePosition(myCommLvl);
            }
            foreach (COMPROD2 rec in myCommRecsAgy)
            {
                rec.SetProductRulePosition(myCommLvl);
            }
          
            using (FlextourEntities context2 = new FlextourEntities(Connection.EFConnectionString))
            {
                IList<FlexCommissions.Commission> commQuery1 = new List<FlexCommissions.Commission>();
                IList<FlexCommissions.Commission> commQuery2 = new List<FlexCommissions.Commission>();
                commQuery1 = FlexCommissions.Commissions.GetProductCommissions(context2, "C", TextEditCode.Text.TrimEnd(), "PKG", myCommRecs, myCommLvl, null, TheDate, null, null, Agency, Source);
                commQuery2 = FlexCommissions.Commissions.GetAgencyCommissions(context2, "C", myCommRecsAgy, myCommLvl, Agency, TheDate, null, null, Source);
                IList<FlexCommissions.Commission> mergedList = (commQuery1.Union(commQuery2)).ToList();
                GridControlCommissions.DataSource = mergedList;
                commQuery1 = FlexCommissions.Commissions.GetProductCommissions(context2, "M", TextEditCode.Text.TrimEnd(), "PKG", myCommRecs, myCommLvl, null, TheDate, null, null, Agency, Source);
                commQuery2 = FlexCommissions.Commissions.GetAgencyCommissions(context2, "M", myCommRecsAgy, myCommLvl, Agency, TheDate, null, null, Source);
                mergedList = (commQuery1.Union(commQuery2)).ToList();
                GridControlMarkups.DataSource = mergedList;
            }
        }

        private void packForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && gridViewPackages.IsFilterRow(gridViewPackages.FocusedRowHandle))
            {
                executeQuery();
            }
        }

        private void executeQuery()
        {
            this.Cursor = Cursors.WaitCursor;
            string colName = gridViewPackages.FocusedColumn.FieldName;
            string value = String.Empty;
            if (!string.IsNullOrWhiteSpace(gridViewPackages.GetFocusedDisplayText()))
                value = gridViewPackages.GetFocusedDisplayText();
            if (!string.IsNullOrWhiteSpace(value))
              {
                  string query = String.Format("it.NAME like '{0}%'", gridViewPackages.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "NAME"));
                  var special = _context.PACK.Where(query);
                 
                  if (!string.IsNullOrWhiteSpace(gridViewPackages.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE")))
                  {
                      query = String.Format("it.{0} like '{1}%'", "CODE", gridViewPackages.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, "CODE"));
                      special = special.Where(query);
                  }             
                  int count = special.Count();
                  if (count > 0)
                  {
                      PackBindingSource.DataSource = special;
                      gridViewPackages.FocusedRowHandle = 0;
                      gridViewPackages.FocusedColumn.FieldName = colName;
                      gridViewPackages.ClearColumnsFilter();
                  }
                  else
                  {                      
                      MessageBox.Show("No records in database.");
                      gridViewPackages.ClearColumnsFilter();                     
                  }
              }
            this.Cursor = Cursors.Default; 
        }

        private void ImageComboBoxEditLanguage_Leave(object sender, EventArgs e)
        {
            if (PackBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, ErrorProvider, ((PACK)PackBindingSource.Current).checkLang, PackBindingSource);
            }
        }

        private void checkEditVendorPrepayReqd_Click(object sender, EventArgs e)
        {
            Modified = true;
        }

        private void checkEditAccountingServiceItem_Click(object sender, EventArgs e)
        {
            Modified = true;
        }

        private void CheckEditServicesOnly_Modified(object sender, EventArgs e)
        {
            Modified = true;
            validCheck.check(sender, ErrorProvider, ((PACK)PackBindingSource.Current).checkServicesOnly, PackBindingSource);
        }

        private void CheckEditMultipleTimes_Modified(object sender, EventArgs e)
        {
            Modified = true;
        }

        private void BarButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridViewPackages.ClearColumnsFilter();
            if (PackBindingSource.Current == null) {
                PackBindingSource.DataSource = from packrec in _context.PACK where packrec.CODE == "KJM987" select packrec;
                PackBindingSource.AddNew();
                if (gridViewPackages.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    gridViewPackages.FocusedRowHandle = gridViewPackages.RowCount - 1;
                TextEditCode.Focus();
                TextEditCode.Properties.ReadOnly = false;
                newRec = true;
                setReadOnly(false);
                setCheckEdits();
                return;
            }
            TextEditCode.Focus();
            //bindingNavigatorPositionItem.Focus()//;  //trigger field leave event
            gridViewPackages.CloseEditor();
            temp = newRec;
            if (checkForms()) {
                ErrorProvider.Clear();
                if (!temp)
                    _context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (PACK)PackBindingSource.Current);
                PackBindingSource.AddNew();
                if (gridViewPackages.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    gridViewPackages.FocusedRowHandle = gridViewPackages.RowCount - 1;
                TextEditCode.Focus();
                TextEditCode.Properties.ReadOnly = false;
                newRec = true;
                setCheckEdits();
                setReadOnly(false);
            }
        }

        private void BarButtonItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try {
                gridViewPackages.ClearColumnsFilter();
                if (PackBindingSource.Current == null)
                    return;
                gridViewPackages.CloseEditor();
                if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    Modified = false;
                    newRec = false;
                    PackBindingSource.RemoveCurrent();
                    ErrorProvider.Clear();
                    _context.SaveChanges();
                    panelControlStatus.Visible = true;
                    LabelStatus.Text = "Record Deleted";
                    rowStatusDelete = new Timer();
                    rowStatusDelete.Interval = 3000;
                    rowStatusDelete.Start();
                    rowStatusDelete.Tick += new EventHandler(TimedEventDelete);

                }
                currentVal = TextEditCode.Text;
                setReadOnly(true);
            }
            catch (Exception ex) {
                DisplayHelper.DisplayError(this, ex);
            }
        }

        private void BarButtonItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridViewPackages.ClearColumnsFilter();
            if (PackBindingSource.Current == null)
                return;

            gridViewSupplierCategory.CloseEditor();
            if (gridViewSupplierCategory.UpdateCurrentRow()) {
                supplierCategoryBindingSource.EndEdit();
            }

            gridViewSupplierProduct.CloseEditor();
            if (gridViewSupplierProduct.UpdateCurrentRow()) {
                bindingSourceSupplierProduct.EndEdit();
            }

            gridViewPackages.CloseEditor();
            TextEditCode.Focus();
            //bindingNavigatorPositionItem.Focus();//trigger field leave event
            bool temp = newRec;
            if (checkForms()) {
                ErrorProvider.Clear();
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;
                setReadOnly(true);
            }

            if (!temp && !_modified)
                _context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (PACK)PackBindingSource.Current);
        }

        private void MappingAddButton_Click(object sender, EventArgs e) {
            if (_selectedRecord != null) {
                SupplierProduct product = new SupplierProduct();
                product.Product_Code_Internal = TextEditCode.Text;
                product.Product_Type = "PKG";
                _selectedRecord.SupplierProduct.Add(product);
                BindSupplierProducts();
                gridViewSupplierProduct.FocusedRowHandle = bindingSourceSupplierProduct.Count - 1;
                Modified = true;
            }
        }

        private void MappingDelButton_Click(object sender, EventArgs e) {
            if (gridViewSupplierProduct.FocusedRowHandle >= 0) {
                SupplierProduct suppProd = (SupplierProduct)gridViewSupplierProduct.GetFocusedRow();
                bindingSourceSupplierProduct.Remove(suppProd);
                //Removing from the bindingsource just removes the object from its parent, but does not mark
                //it for deletion, effectively orphaning it.  This will cause foreign key errors when saving.
                //To flag for deletion, delete it from the context as well.
                _context.SupplierProduct.DeleteObject(suppProd);
                BindSupplierProducts();
                Modified = true;
            }
        }

        void BindSupplierProducts() {
            gridControlSupplierProduct.DataSource = bindingSourceSupplierProduct;
            gridControlSupplierProduct.RefreshDataSource();
        }

        private void gridViewSupplierProduct_InvalidRowException(object sender, InvalidRowExceptionEventArgs e) {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        void gridViewSupplierProduct_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e) {
            if (e.Column == gridColumnSupplierGuid) {
                e.RepositoryItem = _supplierCombo;
            }
            else if (e.Column == gridColumnMappingOperator) {
                e.RepositoryItem = _operatorCombo;
            }
            else if (e.Column == colPickup_Location_Default) {
                string type = gridViewSupplierProduct.GetRowCellDisplayText(e.RowHandle, "Pickup_LocationType_Default");
                if (_locationLookups.ContainsKey(type)) {
                    repositoryItemCustomSearchLookUpEditDefaultPUpLoc.DataSource = _locationLookups[type];
                }
                else {
                    repositoryItemCustomSearchLookUpEditDefaultPUpLoc.DataSource = null;
                }
            }
            else if (e.Column == colDropoff_Location_Default) {
                string type = gridViewSupplierProduct.GetRowCellDisplayText(e.RowHandle, "Dropoff_LocationType_Default");
                if (_locationLookups.ContainsKey(type)) {
                    repositoryItemCustomSearchLookUpEditDefaultDropLoc.DataSource = _locationLookups[type];
                }
                else {
                    repositoryItemCustomSearchLookUpEditDefaultDropLoc.DataSource = null;
                }
            }
        }

        private void gridViewSupplierProduct_CellValueChanged(object sender, CellValueChangedEventArgs e) {
            Modified = true;
            //Clear the associated time when the pickup or dropoff location changes because we want staff to be conscious
            //that time should probably change if the location changes (downside is that if the time was supposed to be the
            //same and they were not paying attention they may not remember what it was before it was cleared)
            if (e.Column == colPickup_LocationType_Default) {
                gridViewSupplierProduct.SetRowCellValue(e.RowHandle, colPickup_Location_Default, null);
                gridViewSupplierProduct.SetRowCellValue(e.RowHandle, colPickup_Time_Default, null);
            }
            else if (e.Column == colDropoff_LocationType_Default) {
                gridViewSupplierProduct.SetRowCellValue(e.RowHandle, colDropoff_Location_Default, null);
                gridViewSupplierProduct.SetRowCellValue(e.RowHandle, colDropoff_Time_Default, null);
            }
            else if (e.Column == colPickup_Location_Default) {
                gridViewSupplierProduct.SetRowCellValue(e.RowHandle, colPickup_Time_Default, null);
            }
            else if (e.Column == colDropoff_Location_Default) {
                gridViewSupplierProduct.SetRowCellValue(e.RowHandle, colDropoff_Time_Default, null);
            }
        }

        private void gridViewSupplierProduct_ValidateRow(object sender, ValidateRowEventArgs e) {
            ColumnView view = sender as ColumnView;
            view.ClearColumnErrors();
            if (view.GetRowCellValue(e.RowHandle, gridColumnSupplierGuid) == null) {
                e.Valid = false;
                view.SetColumnError(gridColumnSupplierGuid, "Please enter a Supplier for the Supplier Mapping record.");
            }
            if (string.IsNullOrEmpty(view.GetRowCellValue(e.RowHandle, gridColumnProductSupplierCode).ToString())) {
                e.Valid = false;
                view.SetColumnError(gridColumnProductSupplierCode, "Please enter a Supplier Product Code for the Supplier Mapping record.");
            }
            if (!view.GetRowCellValue(e.RowHandle, colPickup_LocationType_Default).IsNullOrEmpty()) {
                if (view.GetRowCellValue(e.RowHandle, colPickup_Location_Default).IsNullOrEmpty()) {
                    e.Valid = false;
                    view.SetColumnError(colPickup_LocationType_Default, "Please enter a default pickup location for the Supplier Mapping record.");
                }
                if (view.GetRowCellValue(e.RowHandle, colPickup_Time_Default).IsNullOrEmpty()) {
                    e.Valid = false;
                    view.SetColumnError(colPickup_Time_Default, "Please enter a default pickup time for the Supplier Mapping record.");
                }
            }
            if (!view.GetRowCellValue(e.RowHandle, colDropoff_LocationType_Default).IsNullOrEmpty()) {
                if (view.GetRowCellValue(e.RowHandle, colDropoff_Location_Default).IsNullOrEmpty()) {
                    e.Valid = false;
                    view.SetColumnError(colDropoff_Location_Default, "Please enter a default dropoff location for the Supplier Mapping record.");
                }
                if (view.GetRowCellValue(e.RowHandle, colDropoff_Time_Default).IsNullOrEmpty()) {
                    e.Valid = false;
                    view.SetColumnError(colDropoff_Time_Default, "Please enter a default dropoff time for the Supplier Mapping record.");
                }
            }
        }

        private bool CheckMappings() {
            for (int row = 0; row < gridViewSupplierProduct.RowCount; row++) {
                SupplierProduct product = (SupplierProduct)gridViewSupplierProduct.GetRow(row);
                product.Product_Code_Internal = TextEditCode.Text;
                product.Product_Type = "PKG";

                if (!string.IsNullOrEmpty(product.Pickup_LocationType_Default) && string.IsNullOrEmpty(product.Pickup_Location_Default)) {
                    MessageBox.Show("Please enter a default pickup location for the Supplier Mapping record.");
                    return false;
                }
                if (!string.IsNullOrEmpty(product.Pickup_LocationType_Default) && product.Pickup_Time_Default == null) {
                    MessageBox.Show("Please enter a default pickup time for the Supplier Mapping record.");
                    return false;
                }
                if (!string.IsNullOrEmpty(product.Dropoff_LocationType_Default) && string.IsNullOrEmpty(product.Dropoff_Location_Default)) {
                    MessageBox.Show("Please enter a default dropoff location for the Supplier Mapping record.");
                    return false;
                }
                if (!string.IsNullOrEmpty(product.Dropoff_LocationType_Default) && product.Dropoff_Time_Default == null) {
                    MessageBox.Show("Please enter a default dropoff time for the Supplier Mapping record.");
                    return false;
                }
            }
            return true;
        }

        void BindSupplierCategories() {
            gridControlSupplierCategory.DataSource = supplierCategoryBindingSource;
            gridControlSupplierCategory.RefreshDataSource();
        }

        private void simpleButtonAddSupplierCategory_Click(object sender, EventArgs e) {
            if (_selectedRecord != null) {
                SupplierCategory cat = new SupplierCategory();
                cat.Product_Code = TextEditCode.Text;
                cat.Product_Type = "PKG";
                _selectedRecord.SupplierCategory.Add(cat);
                BindSupplierCategories();
                gridViewSupplierCategory.FocusedRowHandle = supplierCategoryBindingSource.Count - 1;
                Modified = true;
            }
        }

        private void simpleButtonDelSupplierCategory_Click(object sender, EventArgs e) {
            if (gridViewSupplierCategory.FocusedRowHandle >= 0) {
                SupplierCategory cat = (SupplierCategory)gridViewSupplierCategory.GetFocusedRow();
                supplierCategoryBindingSource.Remove(cat);
                //Removing from the bindingsource just removes the object from its parent, but does not mark
                //it for deletion, effectively orphaning it.  This will cause foreign key errors when saving.
                //To flag for deletion, delete it from the context as well.
                _context.SupplierCategory.DeleteObject(cat);
                BindSupplierCategories();
                Modified = true;
            }
        }

        private bool CheckSupplierCategories() {
            gridViewSupplierCategory.UpdateCurrentRow();
            for (int row = 0; row < gridViewSupplierCategory.DataRowCount; row++) {
                var roomType = (SupplierCategory)gridViewSupplierCategory.GetRow(row);
                if (roomType.Supplier_GUID == null) {
                    SetGridError(xtraTabControl1, xtraTabPageSupplierCategories, gridControlSupplierCategory, gridViewSupplierCategory,
                        row, "Supplier_GUID", "The Supplier is required.");
                    return false;
                }
                if (string.IsNullOrEmpty(roomType.Code)) {
                    SetGridError(xtraTabControl1, xtraTabPageSupplierCategories, gridControlSupplierCategory, gridViewSupplierCategory,
                        row, "Code", "The Supplier category is required.");
                    return false;
                }
            }

            //Empty string represents no category mapping, but it needs to be null for the foreign key
            foreach (SupplierCategory roomType in supplierCategoryBindingSource) {
                if (string.IsNullOrWhiteSpace(roomType.Roomcod_Code)) {
                    roomType.Roomcod_Code = null;
                }
                roomType.Product_Code = TextEditCode.Text;
                roomType.Product_Type = "PKG";
            }

            return true;
        }

        private void SetGridError(DevExpress.XtraTab.XtraTabControl tabControl, DevExpress.XtraTab.XtraTabPage tabPage,
            GridControl gridControl, GridView gridView, int row, string field, string errorText) {
            tabControl.SelectedTabPage = tabPage;
            gridControl.Focus();
            gridView.FocusedRowHandle = row;
            gridView.FocusedColumn = gridViewSupplierCategory.Columns[field];
            gridView.ShowEditor();
            if (gridView.ActiveEditor != null) {
                gridView.ActiveEditor.ErrorText = errorText;
                gridView.ActiveEditor.IsModified = true;
            }
            MessageBox.Show(errorText, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void GridViewSupplierCategory_CellValueChanged(object sender, CellValueChangedEventArgs e) {
            Modified = true;
        }

        private void GridViewSupplierCategory_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e) {
            if (e.Column == colSupplierCategory_Supplier_GUID) {
                e.RepositoryItem = _supplierCombo;
            }
        }

        private void PopupForm_KeyUp(object sender, KeyEventArgs e) {
            bool gotMatch = false;
            PopupSearchLookUpEditForm popupForm = sender as PopupSearchLookUpEditForm;
            if (e.KeyData == Keys.Enter) {
                string searchText = popupForm.Properties.View.FindFilterText;
                if (!string.IsNullOrEmpty(searchText)) {
                    GridView view = popupForm.OwnerEdit.Properties.View;
                    //If there is a match is on the ValueMember (Code) column, that should take precedence
                    //This needs to be case insensitive, but there is no case insensitive lookup, so we have to iterate the rows
                    //int row = view.LocateByValue(popupForm.OwnerEdit.Properties.ValueMember, searchText);
                    for (int row = 0; row < view.DataRowCount; row++) {
                        CodeName codeName = (CodeName)view.GetRow(row);
                        if (codeName.Code.Equals(searchText.Trim('"'), StringComparison.OrdinalIgnoreCase)) {
                            view.FocusedRowHandle = row;
                            gotMatch = true;
                            break;
                        }
                    }
                    if (!gotMatch) {
                        view.FocusedRowHandle = 0;
                    }
                    popupForm.OwnerEdit.ClosePopup();
                }
            }
        }

        private void SearchLookupEdit_Popup(object sender, EventArgs e) {
            //Hide the Find button because it doesn't do anything when auto - filtering, except it
            //is useful to let the user know the purpose of the filter field, because it has no label
            //LayoutControl lc = ((sender as IPopupControl).PopupWindow.Controls[2].Controls[0] as LayoutControl);
            //((lc.Items[0] as LayoutControlGroup).Items[1] as LayoutControlGroup).Items[1].Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            PopupSearchLookUpEditForm popupForm = (sender as IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            popupForm.KeyPreview = true;
            popupForm.KeyUp -= PopupForm_KeyUp;
            popupForm.KeyUp += PopupForm_KeyUp;

            //SearchLookUpEdit currentSearch = (SearchLookUpEdit)sender;
        }

        private void SearchLookupEdit_UpdateDisplayFilter(object sender, Custom_SearchLookupEdit.DisplayFilterEventArgs e) {
            //Users did not like have to type quotes in order to get an exact match of entered terms rather than any word being matched
            //https://www.devexpress.com/Support/Center/Example/Details/E3135/how-to-implement-an-event-allowing-you-to-customize-a-filter-string-produced-by-the-find
            //Also requires the custom inherited version of the SearchLookupEdit in the Custom_SearchLookupEdit namespace
            if (!string.IsNullOrEmpty(e.FilterText)) {
                e.FilterText = '"' + e.FilterText + '"';
            }
        }

        private void GridViewSupplierCategory_InvalidRowException(object sender, InvalidRowExceptionEventArgs e) {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box       
        }

        private void GridViewSupplierCategory_ValidateRow(object sender, ValidateRowEventArgs e) {
            ColumnView view = sender as ColumnView;
            view.ClearColumnErrors();
            if (view.GetRowCellValue(e.RowHandle, colSupplierCategory_Supplier_GUID) == null) {
                e.Valid = false;
                view.SetColumnError(colSupplierCategory_Supplier_GUID, "Please select a Supplier from the dropdown for the Supplier Category record.");
            }
            if (string.IsNullOrEmpty(view.GetRowCellValue(e.RowHandle, colSupplierCategory_Code).ToString())) {
                e.Valid = false;
                view.SetColumnError(colSupplierCategory_Code, "Please enter a Code for the Supplier Category record.");
            }
        }
    }
}
