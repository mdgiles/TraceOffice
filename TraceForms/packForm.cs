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
        public FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        string _accountingURL;

        public packForm(FlexInterfaces.Core.ICoreSys sys)
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
            var agy = from agyRec in context.AGY orderby agyRec.NO ascending select new { agyRec.NO, agyRec.NAME };
            var pkg = from pkgRec in context.PACK orderby pkgRec.CODE ascending select new { pkgRec.CODE, pkgRec.NAME };
            var cty = from ctyRec in context.CITYCOD orderby ctyRec.CODE ascending select new { ctyRec.CODE, ctyRec.NAME };
            var reg = from regRec in context.REGION orderby regRec.CODE ascending select new { regRec.CODE, regRec.DESC };
            var opr = from operRec in context.OPERATOR orderby operRec.CODE ascending select new { operRec.CODE, operRec.NAME };
            var pkt = from pktRec in context.PACKTYPE orderby pktRec.CODE ascending select new { pktRec.CODE, pktRec.DESC };
            var lang = from langRec in context.LANGUAGE orderby langRec.CODE ascending select new { langRec.CODE, langRec.NAME };
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
            if (ok1 && ok2 && ok3 && ok4) {
                var ret = validCheck.saveRec(ref _modified, true, ref newRec, context, PackBindingSource, this.Name, ErrorProvider, Cursor);
                if (ret) {
                    AccountingAPI.InvokeForProduct(_accountingURL, "PKG", ((PACK)PackBindingSource.Current).CODE);
                }
                return ret;
            }
            else
            {
                validCheck.saveRec(ref _modified, false, ref newRec, context, PackBindingSource, this.Name, ErrorProvider, Cursor);
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (PACK)PackBindingSource.Current);

                setReadOnly(true);
            }
            else
            {

                if (!temp && !_modified)
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (PACK)PackBindingSource.Current);
             
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
                myCommRecs = (from rec in context.COMPROD2
                              where (rec.TYPE == "PKG") && (rec.Inactive == false) && ((rec.START_DATE <= TheDate) && (rec.END_DATE >= TheDate))
                              select rec).ToList<IComprod2>();
                myCommRecsAgy = (from rec in context.COMPROD2
                                 where (rec.TYPE == "AGY") && (rec.Inactive == false) && ((rec.START_DATE <= TheDate) && (rec.END_DATE >= TheDate))
                                 select rec).ToList<IComprod2>();
            }
            else
            {
                myCommRecs = (from rec in context.COMPROD2
                              where (rec.TYPE == "PKG") && (rec.Inactive == false)
                              select rec).ToList<IComprod2>();
                myCommRecsAgy = (from rec in context.COMPROD2
                                 where (rec.TYPE == "AGY") && (rec.Inactive == false)
                                 select rec).ToList<IComprod2>();
            }

            myCommLvl = (from rec in context.CommLevel select rec).ToList<ICommLevel>();
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
                  var special = context.PACK.Where(query);
                 
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
                PackBindingSource.DataSource = from packrec in context.PACK where packrec.CODE == "KJM987" select packrec;
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
                    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (PACK)PackBindingSource.Current);
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
                    context.SaveChanges();
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
                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (PACK)PackBindingSource.Current);
        }
    }
}
