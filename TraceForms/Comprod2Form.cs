using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FlexModel;
using DevExpress.XtraEditors.Controls;
using System.Linq;
using System.Linq.Dynamic;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;
using System.Data.Entity;

namespace TraceForms
{
    public partial class Comprod2Form : DevExpress.XtraEditors.XtraForm
    {
        public List<ImageComboBoxItem> hotelVals;
        //public ImageComboBoxItemCollection airVals;
        public List<ImageComboBoxItem> compVals;

        public List<ImageComboBoxItem> airVals;
        public List<ImageComboBoxItem> cruVals;
        public List<ImageComboBoxItem> carVals;
        public List<ImageComboBoxItem> pkgVals;
        public List<ImageComboBoxItem> insVals;
        public List<ImageComboBoxItem> servtypeVals;
        public List<ImageComboBoxItem> packTypeVals;
        public List<ImageComboBoxItem> regionVals;
        public List<ImageComboBoxItem> countryVals;

        public List<ImageComboBoxItem> agyTblVals;
        public List<ImageComboBoxItem> lookupVals;
        public List<ImageComboBoxItem> languageVals;
        public List<ImageComboBoxItem> cityVals;

        public List<ImageComboBoxItem> agencyMarkups;
        public List<ImageComboBoxItem> agencyCommissions;
        public Dictionary<int, string> lookupTables;


        public string currentVal;
        public bool _modified = false;
        public bool newRec = false;
        public bool exclusionCheck = false;
        
        public string codeTable;
        public string agencyTable;
        const string colName1 = "colCODE";
        public FlextourEntities savingContext;
        public FlextourEntities loadingContext;
        public string username;
        public object dateSender;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;

        public Comprod2Form(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
            LoadLookups();
      
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            savingContext = new FlextourEntities(sys.Settings.EFConnectionString);
            loadingContext = new FlextourEntities(sys.Settings.EFConnectionString);
            username = sys.User.Name;
        }

        private void LoadLookups()
        {
            hotelVals = new List<ImageComboBoxItem>();
            compVals = new List<ImageComboBoxItem>();
            servtypeVals = new List<ImageComboBoxItem>();
            packTypeVals = new List<ImageComboBoxItem>();
            regionVals = new List<ImageComboBoxItem>();
            countryVals = new List<ImageComboBoxItem>();

            agyTblVals = new List<ImageComboBoxItem>();
            lookupVals = new List<ImageComboBoxItem>();
            languageVals = new List<ImageComboBoxItem>();
            cityVals = new List<ImageComboBoxItem>();

            airVals = new List<ImageComboBoxItem>();
            cruVals = new List<ImageComboBoxItem>();
            carVals = new List<ImageComboBoxItem>();
            pkgVals = new List<ImageComboBoxItem>();
            insVals = new List<ImageComboBoxItem>();
            agencyMarkups = new List<ImageComboBoxItem>();
            agencyCommissions = new List<ImageComboBoxItem>();
            Modified = false;
            newRec = false;
            labelGridSearchPkgHotel.Visible = false;
            labelGridSearchAgency.Visible = false;
            labelCheckEdiExclusion.Visible = false;
            CheckEditExclusion.Visible = false;
            GridSearchControlPkgAgency.Visible = false;
            GridSearchControlPkgHotel.Visible = false;
            GridSearchControlPkgHotel.ButtonEdit.Properties.ReadOnly = true;
            GridSearchControlPkgAgency.ButtonEdit.Properties.ReadOnly = true;

            var cat = from catRec in loadingContext.ROOMCOD orderby catRec.CODE ascending select new { catRec.CODE, catRec.DESC };
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxItem loadNull = new ImageComboBoxItem() { Description = "", Value = null };

            ImageComboBoxEditCategory.Properties.Items.Add(loadBlank);
            ImageBoxCode.Properties.Items.Add(loadBlank);
            //ImageBoxCode.EditValue = "";               
            gsLoad.gridSearchLoad(GridSearchControlPkgHotel, "CODE", "NAME", "Code", "Name", "CODE", "CODE", "CODE", Comprod2BindingSource, "Product_CODE_Exclusion");
            gsLoad.gridSearchLoad(GridSearchControlPkgAgency, "NO", "NAME", "Code", "Name", "NO", "NO", "NO", Comprod2BindingSource, "AGY_NO_Exclusion");
            GridSearchControlPkgAgency.GridControl.DataSource = loadingContext.AGY;

            var srv = from srvRec in loadingContext.SERVTYPE orderby srvRec.TYPE ascending select new { srvRec.TYPE, srvRec.DESCRIP };
            foreach (var result in srv) {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = String.Format("{0}  ({1})", result.TYPE, result.DESCRIP), Value = result.TYPE };
                servtypeVals.Add(load);
            }

            var packtypes = from pktypRec in loadingContext.PACKTYPE orderby pktypRec.CODE ascending select new { pktypRec.CODE, pktypRec.DESC };
            foreach (var result in packtypes) {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = String.Format("{0}  ({1})", result.CODE, result.DESC), Value = result.CODE };
                packTypeVals.Add(load);
            }

            var agencyComRule = from commRec in loadingContext.CommLevel where commRec.Type == "AGY" && commRec.RecType == "C" select commRec;
            foreach (var result in agencyComRule) {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.Description, Value = result.ID };
                agencyCommissions.Add(load);
            }

            var agencyMarkRule = from commRec in loadingContext.CommLevel where commRec.Type == "AGY" && commRec.RecType == "M" select commRec;
            foreach (var result in agencyMarkRule) {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.Description, Value = result.ID };
                agencyMarkups.Add(load);
            }

            var reg = from regRec in loadingContext.REGION orderby regRec.CODE ascending select new { regRec.CODE, regRec.DESC };
            foreach (var result in reg) {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = String.Format("{0}  ({1})", result.CODE, result.DESC), Value = result.CODE };
                regionVals.Add(load);
            }

            var country = from cntryRec in loadingContext.COUNTRY orderby cntryRec.CODE ascending select new { cntryRec.CODE, cntryRec.NAME };
            foreach (var result in country) {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = String.Format("{0}  ({1})", result.CODE, result.NAME), Value = result.CODE };
                countryVals.Add(load);
            }

            var agy = from agyRec in loadingContext.AGY orderby agyRec.NO ascending select new { agyRec.NO, agyRec.NAME };
            foreach (var result in agy) {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = String.Format("{0}  ({1})", result.NO, result.NAME), Value = result.NO };
                agyTblVals.Add(load);
            }

            var lang = from langRec in loadingContext.LANGUAGE orderby langRec.CODE ascending select new { langRec.CODE, langRec.NAME };
            foreach (var result in lang) {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = String.Format("{0}  ({1})", result.CODE, result.NAME), Value = result.CODE };
                languageVals.Add(load);
            }

            var cty = from ctyRec in loadingContext.CITYCOD orderby ctyRec.CODE ascending select new { ctyRec.CODE, ctyRec.NAME };
            foreach (var result in cty) {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = String.Format("{0}  ({1})", result.CODE, result.NAME), Value = result.CODE };
                cityVals.Add(load);
            }

            var comp = from compRec in loadingContext.COMP orderby compRec.CODE ascending select new { compRec.CODE, compRec.NAME };
            foreach (var result in comp) {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = String.Format("{0}  ({1})", result.CODE, result.NAME), Value = result.CODE };
                compVals.Add(load);
            }

            var hotel = from htlRec in loadingContext.HOTEL orderby htlRec.CODE ascending select new { htlRec.CODE, htlRec.NAME };
            foreach (var result in hotel) {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = String.Format("{0}  ({1})", result.CODE, result.NAME), Value = result.CODE };
                hotelVals.Add(load);
            }

            var pack = from packRec in loadingContext.PACK orderby packRec.CODE ascending select new { packRec.CODE, packRec.NAME };
            foreach (var result in pack) {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = String.Format("{0}  ({1})", result.CODE, result.NAME), Value = result.CODE };
                pkgVals.Add(load);
            }

            foreach (var result in cat) {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = String.Format("{0}  ({1})", result.CODE.TrimEnd(), result.DESC.TrimEnd()), Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCategory.Properties.Items.Add(load);
            }
            ImageComboBoxEditAgency.Properties.Items.AddRange(agyTblVals);
            ImageComboBoxEditAgencyLevelRule.TextChanged += AgencyRuleTextChanged;
            ImageComboBoxEditProductLevelRule.TextChanged += ProductRuleTextChanged;
            ImageComboBoxEditRecType.EditValueChanged += ImageComboBoxEditRecType_EditValueChanged;
                //ImageComboBoxEditAgencyLevelRule.Properties.Items.AddRange(agencyCommissions);
            //ImageComboBoxEditAgencyLevelRule.Properties.Items.AddRange(agencyMarkups);

            if (savingContext.COMPROD2.Count() > 0)
                Comprod2BindingSource.DataSource = savingContext.COMPROD2
                    .Include(c => c.CommLevel)      //for agency
                    .Include(c => c.CommLevel1);    //for product
            savingContext.SaveChanges();
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
                if (value && Comprod2BindingSource.Current != null) {
                    //NB: Before updating any property on the entity, any pending edits must be committed 
                    //with bindingSource.EndEdit, other when the properties are set the form bindings are
                    //automatically refreshed, which causes any pending edits to be lost. 
                    Comprod2BindingSource.EndEdit();
                    COMPROD2 comprod = (COMPROD2)Comprod2BindingSource.Current;
                    comprod.LAST_UPD = DateTime.Now;
                    comprod.UPD_INIT = username;
                }
            }
        }

        void ButtonEdit_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;
        }

        void RecTypeChanged()
        {
			LoadProductRules();
			ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = string.Empty, Value = null };
			ImageComboBoxEditAgencyLevelRule.Properties.Items.Clear();
			ImageComboBoxEditAgencyLevelRule.Properties.Items.Add(loadBlank);

            string recType = ImageComboBoxEditRecType.EditValue.ToString();
            if (recType == "C") {
				ImageComboBoxEditAgencyLevelRule.Properties.Items.AddRange(agencyCommissions);
			}
            else {
                ImageComboBoxEditAgencyLevelRule.Properties.Items.AddRange(agencyMarkups);
			}

			ImageComboBoxEditAgency.EditValue = "";
			ImageComboBoxEditAgency.Properties.Items.Clear();
			ImageComboBoxEditAgency.Properties.Items.Add(loadBlank);
			textEditFreeAgency.EditValue = "";
			textEditFreeAgency.Text = "";

        }

		void setVisible(bool value)
        {
            ImageBoxCode.Visible = value;
			if (!ImageBoxCode.Visible) {
				ImageBoxCode.EditValue = null;
			}

			TextEditFreeCode.Visible = !(value);
			if (!TextEditFreeCode.Visible) {
				TextEditFreeCode.Text = string.Empty;
			}
        }

		void setAgencyVisible(bool value)
		{
			ImageComboBoxEditAgency.Visible = value;
			if (!ImageComboBoxEditAgency.Visible) {
				ImageComboBoxEditAgency.EditValue = null;
			}

			textEditFreeAgency.Visible = !(value);
			if (!textEditFreeAgency.Visible) {
				textEditFreeAgency.Text = string.Empty;
			}

		}

		void AgencyRuleTextChanged(object sender, EventArgs e)
		{
            if (savingContext.COMPROD2.Count() == 0 && newRec == false)
                return;

            ImageComboBoxEditAgency.Properties.Items.Clear();
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = null };
            ImageComboBoxEditAgency.Properties.Items.Add(loadBlank);
            if (!string.IsNullOrWhiteSpace(ImageComboBoxEditAgencyLevelRule.Text))
            {
                int? ID = (int?)ImageComboBoxEditAgencyLevelRule.EditValue;
                commLevel_ID_AgencySpinEdit.Text = ID.ToString();

                var queryResult = (from commRecs in loadingContext.CommLevel where commRecs.ID == ID select commRecs).Distinct();
                foreach (var results in queryResult)
                {
                    if (!string.IsNullOrWhiteSpace(results.Query))
                    {
                        setAgencyVisible(true);
                        ImageComboBoxEditAgency.Text = "";
                        ImageComboBoxEditAgency.Properties.ReadOnly = true;
                        ((COMPROD2)Comprod2BindingSource.Current).AgencyTable = "Query";
                        labelAgencyImageBox.Text = "QUERY";
                        if ((Modified == true || newRec == true))
                            TextEditCommPct.Text = results.Comm_Pct.ToString();

                        if (results.ID > 0)
                            commLevel_ID_AgencySpinEdit.Text = results.ID.ToString();
                        else
                            commLevel_ID_AgencySpinEdit.Text = null;
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(results.Lookup_Table) && string.IsNullOrWhiteSpace(results.Lookup_Column) && string.IsNullOrWhiteSpace(results.Link_Rectype) && (results.Link_Column != "CODE" || results.Link_Column != "Code"))
                    {
                        if (results.Link_Table == "DETAIL")
                        {
                            ((COMPROD2)Comprod2BindingSource.Current).AgencyTable = "FreeForm";
                            labelAgencyImageBox.Text = "Code";
                            setAgencyVisible(false);

                            if (results.ID > 0)
                                commLevel_ID_AgencySpinEdit.Text = results.ID.ToString();
                            else
                                commLevel_ID_AgencySpinEdit.Text = null;
                            if ((Modified == true || newRec == true))
                                TextEditCommPct.Text = results.Comm_Pct.ToString();
                            return;
                        }


                        var load = (from userRec in loadingContext.USERFIELDS where userRec.LINK_TABLE == results.Link_Table && userRec.LINK_COLUMN == results.Link_Column select userRec).FirstOrDefault();
                        if (load != null)
                        {
                            ((COMPROD2)Comprod2BindingSource.Current).AgencyTable = "FreeForm";
                            labelAgencyImageBox.Text = load.LABEL;
                            setAgencyVisible(false);
                        }

                        //((COMPROD2)Comprod2BindingSource.Current).AgencyTable = "FreeForm";
                        //labelAgencyImageBox.Text = "Value";
                        //setAgencyVisible(false);

                        if (results.ID > 0)
                            commLevel_ID_AgencySpinEdit.Text = results.ID.ToString();
                        else
                            commLevel_ID_AgencySpinEdit.Text = null;
                        if ((Modified == true || newRec == true))
                            TextEditCommPct.Text = results.Comm_Pct.ToString();
                        return;
                    }

                    ImageComboBoxEditAgency.Properties.ReadOnly = false;
                    if (!string.IsNullOrWhiteSpace(results.Lookup_Table))
                    {
                        setAgencyVisible(true);
                        switch (results.Lookup_Table.TrimEnd())
                        {
                            case "AGY":
                                ImageComboBoxEditAgency.Properties.Items.AddRange(agyTblVals);
                                break;
                            case "CITY":
                                ImageComboBoxEditAgency.Properties.Items.AddRange(cityVals);
                                break;
                            case "COUNTRY":
                                ImageComboBoxEditAgency.Properties.Items.AddRange(countryVals);
                                break;
                            case "LOOKUP":
                                var look = from lookRec in loadingContext.LOOKUP where lookRec.RECTYPE == results.Link_Rectype orderby lookRec.CODE ascending select new { lookRec.CODE, lookRec.DESC };
                                foreach (var result in look)
                                {
                                    ImageComboBoxItem load = new ImageComboBoxItem() { Description = String.Format("{0}  ({1})", result.CODE, result.DESC), Value = result.CODE };
                                    ImageComboBoxEditAgency.Properties.Items.Add(load);
                                }
                                break;
                            case "LANGUAGE":
                                ImageComboBoxEditAgency.Properties.Items.AddRange(languageVals);
                                break;
                            default:
                                ImageComboBoxEditAgency.Properties.Items.AddRange(agyTblVals);
                                break;
                        }

                        labelAgencyImageBox.Text = results.Lookup_Table.TrimEnd();

                        ((COMPROD2)Comprod2BindingSource.Current).AgencyTable = results.Lookup_Table.TrimEnd();
                        ((COMPROD2)Comprod2BindingSource.Current).AgencyColumn = results.Lookup_Column.TrimEnd();
                        if ((Modified == true || newRec == true))
                            TextEditCommPct.Text = results.Comm_Pct.ToString();
                        //might need a return statement here
                    }
                    else
                    {
                        setAgencyVisible(true);
                        labelAgencyImageBox.Text = "Code";
                        switch (results.Link_Table.TrimEnd())
                        {
                            case "AGY":
                                ImageComboBoxEditAgency.Properties.Items.AddRange(agyTblVals);
                                break;
                            case "LOOKUP":
                                var look = from lookRec in loadingContext.LOOKUP orderby lookRec.CODE ascending select new { lookRec.CODE, lookRec.DESC };
                                foreach (var result in look)
                                {
                                    ImageComboBoxItem load = new ImageComboBoxItem() { Description = String.Format("{0}  ({1})", result.CODE, result.DESC), Value = result.CODE };
                                    ImageComboBoxEditAgency.Properties.Items.Add(load);
                                }
                                break;
                            case "CITY":
                                ImageComboBoxEditAgency.Properties.Items.AddRange(cityVals);
                                break;
                            case "COUNTRY":
                                ImageComboBoxEditAgency.Properties.Items.AddRange(countryVals);
                                break;
                            case "LANGUAGE":
                                ImageComboBoxEditAgency.Properties.Items.AddRange(languageVals);
                                break;
                            case "DETAIL":
                                var dtl = from detailRec in loadingContext.DETAIL orderby detailRec.CODE ascending select new { detailRec.CODE, detailRec.NOTE };
                                foreach (var result in dtl)
                                {
                                    ImageComboBoxItem load = new ImageComboBoxItem() { Description = String.Format("{0}  ({1})", result.CODE, result.NOTE), Value = result.CODE };
                                    ImageComboBoxEditAgency.Properties.Items.Add(load);
                                }
                                break;
                            default:
                                ImageComboBoxEditAgency.Properties.Items.AddRange(agyTblVals);
                                break;
                        }

                        ((COMPROD2)Comprod2BindingSource.Current).AgencyTable = results.Link_Table.TrimEnd();
                        ((COMPROD2)Comprod2BindingSource.Current).AgencyColumn = results.Link_Column.TrimEnd();
                    }
                }
            }
            else
            {
                labelAgencyImageBox.Text = "Agency";
                ImageComboBoxEditAgency.Properties.Items.AddRange(agyTblVals);
                setAgencyVisible(true);

                if (Comprod2BindingSource.Current != null)
                {
                    ((COMPROD2)Comprod2BindingSource.Current).AgencyTable = "";
                    ((COMPROD2)Comprod2BindingSource.Current).AgencyColumn = "";
                }
            }
        }

        void ProductRuleTextChanged(object sender, EventArgs e)
        {
            if (savingContext.COMPROD2.Count() == 0 && newRec == false)
                return;


            ImageBoxCode.Properties.Items.Clear();
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = null };
            //ImageComboBoxItem loadNull = new ImageComboBoxItem() { Description = "NULL", Value = null };
            ImageBoxCode.Properties.Items.Add(loadBlank);
            //ImageBoxCode.Properties.Items.Add(loadNull);
            if (!string.IsNullOrWhiteSpace(ImageComboBoxEditProductLevelRule.Text))
            {
                int? ID = (int?)ImageComboBoxEditProductLevelRule.EditValue;
                commLevel_ID_ProductSpinEdit.Text = ID.ToString();

                var queryResult = (from commRecs in loadingContext.CommLevel where commRecs.ID == ID select commRecs).Distinct();

                foreach (var results in queryResult)
                {
                    if (!string.IsNullOrWhiteSpace(results.Query))
                    {
                        setVisible(true);
                        ImageBoxCode.Text = "";
                        ImageBoxCode.Properties.ReadOnly = true;
                        ((COMPROD2)Comprod2BindingSource.Current).CodeTable = "Query";
                        labelCodeImageBox.Text = "QUERY";
                        if ((Modified == true || newRec == true))
                            TextEditCommPct.Text = results.Comm_Pct.ToString();

                        if (results.ID > 0)
                            commLevel_ID_ProductSpinEdit.Text = results.ID.ToString();
                        else
                            commLevel_ID_ProductSpinEdit.Text = null;
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(results.Lookup_Table) && string.IsNullOrWhiteSpace(results.Lookup_Column) && string.IsNullOrWhiteSpace(results.Link_Rectype) && (results.Link_Column != "CODE" || results.Link_Column != "Code"))
                    {
                        if (results.Link_Table == "DETAIL")
                        {
                            ((COMPROD2)Comprod2BindingSource.Current).CodeTable = "FreeForm";
                            labelCodeImageBox.Text = "Code";
                            setVisible(false);

                            if (results.ID > 0)
                                commLevel_ID_ProductSpinEdit.Text = results.ID.ToString();
                            else
                                commLevel_ID_ProductSpinEdit.Text = null;
                            if ((Modified == true || newRec == true))
                                TextEditCommPct.Text = results.Comm_Pct.ToString();
                            return;
                        }


                        var load = (from userRec in loadingContext.USERFIELDS where userRec.LINK_TABLE == results.Link_Table && userRec.LINK_COLUMN == results.Link_Column select new { userRec.LABEL }).FirstOrDefault();
                        if (load != null)
                        {
                            ((COMPROD2)Comprod2BindingSource.Current).CodeTable = "FreeForm";
                            labelCodeImageBox.Text = load.LABEL;
                            setVisible(false);
                        }

                        ((COMPROD2)Comprod2BindingSource.Current).CodeTable = "FreeForm";
                        labelCodeImageBox.Text = "Value";
                        setVisible(false);

                        if (results.ID > 0)
                            commLevel_ID_ProductSpinEdit.Text = results.ID.ToString();
                        else
                            commLevel_ID_ProductSpinEdit.Text = null;
                        if ((Modified == true || newRec == true))
                            TextEditCommPct.Text = results.Comm_Pct.ToString();
                        return;
                    }

                    ImageBoxCode.Properties.ReadOnly = false;
                    if (!string.IsNullOrWhiteSpace(results.Lookup_Table))
                    {
                        setVisible(true);
                        switch (results.Lookup_Table.TrimEnd())
                        {
                            case "SERVTYPE":
                                ImageBoxCode.Properties.Items.AddRange(servtypeVals);
                                break;
                            case "PACKTYPE":
                                ImageBoxCode.Properties.Items.AddRange(packTypeVals);
                                break;
                            case "REGION":
                                ImageBoxCode.Properties.Items.AddRange(regionVals);
                                break;
                            case "COUNTRY":
                                ImageBoxCode.Properties.Items.AddRange(countryVals);
                                break;
                            case "AGY":
                                ImageBoxCode.Properties.Items.AddRange(agyTblVals);
                                break;
                            case "LOOKUP":
                                var look = from lookRec in loadingContext.LOOKUP where lookRec.RECTYPE == results.Link_Rectype orderby lookRec.CODE ascending select new { lookRec.CODE, lookRec.DESC };
                                foreach (var result in look)
                                {
                                    ImageComboBoxItem load = new ImageComboBoxItem() { Description = String.Format("{0}  ({1})", result.CODE, result.DESC), Value = result.CODE };
                                    ImageBoxCode.Properties.Items.Add(load);
                                }
                                break;
                            case "LANGUAGE":
                                ImageBoxCode.Properties.Items.AddRange(languageVals);
                                break;
                            case "CITYCOD":
                                ImageBoxCode.Properties.Items.AddRange(cityVals);
                                break;
                            default:
                                ImageBoxCode.Properties.Items.AddRange(hotelVals);
                                break;
                        }

                        labelCodeImageBox.Text = results.Lookup_Table.TrimEnd();

                        ((COMPROD2)Comprod2BindingSource.Current).CodeTable = results.Lookup_Table.TrimEnd();
                        ((COMPROD2)Comprod2BindingSource.Current).CodeColumn = results.Lookup_Column.TrimEnd();
                        if ((Modified == true || newRec == true))
                            TextEditCommPct.Text = results.Comm_Pct.ToString();
                        //might need a return statement here
                    }
                    else
                    {
                        setVisible(true);
                        labelCodeImageBox.Text = "Code";
                        switch (results.Link_Table.TrimEnd())
                        {
                            case "SERVTYPE":
                                ImageBoxCode.Properties.Items.AddRange(servtypeVals);
                                break;
                            case "PACKTYPE":
                                ImageBoxCode.Properties.Items.AddRange(packTypeVals);
                                break;
                            case "REGION":
                                ImageBoxCode.Properties.Items.AddRange(regionVals);
                                break;
                            case "COUNTRY":
                                ImageBoxCode.Properties.Items.AddRange(countryVals);
                                break;
                            case "AGY":
                                ImageBoxCode.Properties.Items.AddRange(agyTblVals);
                                break;
                            case "LOOKUP":
                                var look = from lookRec in loadingContext.LOOKUP orderby lookRec.CODE ascending select new { lookRec.CODE, lookRec.DESC };
                                foreach (var result in look)
                                {
                                    ImageComboBoxItem load = new ImageComboBoxItem() { Description = String.Format("{0}  ({1})", result.CODE, result.DESC), Value = result.CODE };
                                    ImageBoxCode.Properties.Items.Add(load);
                                }
                                break;
                            case "LANGUAGE":
                                ImageBoxCode.Properties.Items.AddRange(languageVals);
                                break;
                            case "CITYCOD":
                                ImageBoxCode.Properties.Items.AddRange(cityVals);
                                break;
                            case "DETAIL":
                                var dtl = from detailRec in loadingContext.DETAIL orderby detailRec.CODE ascending select new { detailRec.CODE, detailRec.NOTE };
                                foreach (var result in dtl)
                                {
                                    ImageComboBoxItem load = new ImageComboBoxItem() { Description = String.Format("{0}  ({1})", result.CODE, result.NOTE), Value = result.CODE };
                                    ImageBoxCode.Properties.Items.Add(load);
                                }
                                break;
                            default:
                                ImageBoxCode.Properties.Items.AddRange(hotelVals);
                                break;
                        }

                        ((COMPROD2)Comprod2BindingSource.Current).CodeTable = results.Link_Table.TrimEnd();
                        ((COMPROD2)Comprod2BindingSource.Current).CodeColumn = results.Link_Column.TrimEnd();
                    }
                }
            }
            else
            {
                labelCodeImageBox.Text = "Code";
                setVisible(true);
                switch (ComboBoxEditType.Text)
                {
                    case "PKG":
                        ImageBoxCode.Properties.Items.AddRange(pkgVals);
                        break;
                    case "HTL":
                        ImageBoxCode.Properties.Items.AddRange(hotelVals);
                        break;
                    case "OPT":
                        ImageBoxCode.Properties.Items.AddRange(compVals);
                        break;
                    default:
                        ImageBoxCode.Properties.Items.AddRange(hotelVals);
                        break;
                }

                if (Comprod2BindingSource.Current != null)
                {
                    ((COMPROD2)Comprod2BindingSource.Current).CodeTable = "";
                    ((COMPROD2)Comprod2BindingSource.Current).CodeColumn = "";
                }
            }
        }

        private void ComboBoxEditType_TextChanged(object sender, EventArgs e)
        {
			LoadProductRules();
        }

		private void LoadProductRules()
		{
			string recType = string.Empty;
			if (newRec)
				recType = ImageComboBoxEditRecType.EditValue.ToString();
			else
				recType = ((COMPROD2)Comprod2BindingSource.Current).RecType;

			//((COMPROD2)Comprod2BindingSource.Current).CodeColum
			ImageComboBoxEditProductLevelRule.Properties.Items.Clear();

			//mdg 11Dec14 - blank item should have a null value, not an empty string value, otherwise the editor
			// considers it invalid and will display a built-in error of "invalid value" when selected
			ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = string.Empty, Value = null };
			ImageComboBoxEditProductLevelRule.Properties.Items.Add(loadBlank);
			ImageBoxCode.Properties.Items.Add(loadBlank);

            //ImageBoxCode.EditValue = "";
            //ImageBoxCode.SelectedIndex = 0;
            //TextEditCode.EditValue = "";
            //TextEditCode.Text = "";
            //TextEditFreeCode.EditValue = "";
            //TextEditFreeCode.Text = "";

            if (ComboBoxEditType.Text == "HTL") {

				labelGridSearchPkgHotel.Text = "Hotel";
				ImageComboBoxEditAgencyLevelRule.Properties.ReadOnly = false;
				ImageComboBoxEditAgency.Properties.ReadOnly = false;
				ImageComboBoxEditProductLevelRule.Properties.ReadOnly = false;
				ImageBoxCode.Properties.ReadOnly = false;

				var prodRule = from commRec in loadingContext.CommLevel where commRec.Type == "HTL" && commRec.RecType == recType select new { commRec.Description, commRec.ID };

				foreach (var result in prodRule) {
					//ImageComboBoxEditProductLevelRule.Properties.Items.Add(result.Description);
					ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.Description, Value = result.ID };
					ImageComboBoxEditProductLevelRule.Properties.Items.Add(load);
				}

				if (labelCodeImageBox.Text == "Code") {
					ImageBoxCode.Properties.Items.Clear();
					ImageBoxCode.Properties.Items.AddRange(hotelVals);

				}

			}
			if (ComboBoxEditType.Text == "PKG") {
				labelGridSearchPkgHotel.Text = "Package";
				ImageComboBoxEditAgencyLevelRule.Properties.ReadOnly = false;
				ImageComboBoxEditAgency.Properties.ReadOnly = false;
				ImageComboBoxEditProductLevelRule.Properties.ReadOnly = false;
				ImageBoxCode.Properties.ReadOnly = false;
				var prodRule = from commRec in loadingContext.CommLevel where commRec.Type == "PKG" && commRec.RecType == recType select new { commRec.Description, commRec.ID };
				foreach (var result in prodRule) {
					//ImageComboBoxEditProductLevelRule.Properties.Items.Add(result.Description);
					ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.Description, Value = result.ID };

					ImageComboBoxEditProductLevelRule.Properties.Items.Add(load);

				}

				if (labelCodeImageBox.Text == "Code") {
					ImageBoxCode.Properties.Items.Clear();
					ImageBoxCode.Properties.Items.AddRange(pkgVals);

				}
			}
			if (ComboBoxEditType.Text == "OPT") {
				labelGridSearchPkgHotel.Text = "Component";
				ImageComboBoxEditAgencyLevelRule.Properties.ReadOnly = false;
				ImageComboBoxEditAgency.Properties.ReadOnly = false;
				ImageComboBoxEditProductLevelRule.Properties.ReadOnly = false;
				ImageBoxCode.Properties.ReadOnly = false;
				var prodRule = from commRec in loadingContext.CommLevel where commRec.Type == "OPT" && commRec.RecType == recType select new { commRec.Description, commRec.ID };
				foreach (var result in prodRule) {
					//ImageComboBoxEditProductLevelRule.Properties.Items.Add(result.Description);
					ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.Description, Value = result.ID };
					ImageComboBoxEditProductLevelRule.Properties.Items.Add(load);

				}

				if (labelCodeImageBox.Text == "Code") {
					ImageBoxCode.Properties.Items.Clear();
					ImageBoxCode.Properties.Items.AddRange(compVals);

				}
			}

			if (ComboBoxEditType.Text == "AGY") {

				labelGridSearchPkgHotel.Text = "Agy";
				ImageComboBoxEditProductLevelRule.Enabled = false;
				ImageBoxCode.Enabled = false;
			}
			else {
				ImageComboBoxEditProductLevelRule.Enabled = true;
				ImageBoxCode.Enabled = true;
			}
		}

		private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }

        private void recTypeComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (Comprod2BindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMPROD2)Comprod2BindingSource.Current).checkRecType, Comprod2BindingSource);
            }

            
        }

        private void cOMM_PCTTextEdit_Leave(object sender, EventArgs e)
        {
            if (Comprod2BindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMPROD2)Comprod2BindingSource.Current).checkComm, Comprod2BindingSource);

            }
        }


        private void resDate_EndDateEdit_Leave(object sender, EventArgs e)
        {
            if (Comprod2BindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMPROD2)Comprod2BindingSource.Current).checkResEnd, Comprod2BindingSource);
            }
        }

        private void eND_DATEDateEdit_Leave(object sender, EventArgs e)
        {
            if (Comprod2BindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMPROD2)Comprod2BindingSource.Current).checkEnd, Comprod2BindingSource);
                ///////////////////////////
                if (!string.IsNullOrWhiteSpace(ButtonEditStartDate.Text) && !string.IsNullOrWhiteSpace(ButtonEditEndDate.Text))
                {

                    string code = string.Empty;
                    if (!string.IsNullOrWhiteSpace(ImageBoxCode.Text))
                        code = ImageBoxCode.EditValue.ToString();
                    string cat = string.Empty;
                    if (!string.IsNullOrWhiteSpace(ImageComboBoxEditCategory.Text))
                        cat = ImageComboBoxEditCategory.EditValue.ToString();

                    string agency = string.Empty;
                    if (!string.IsNullOrWhiteSpace(ImageComboBoxEditAgency.Text))
                        agency = ImageComboBoxEditAgency.EditValue.ToString();

                    DateTime start = Convert.ToDateTime(ButtonEditStartDate.Text);
                    DateTime end = Convert.ToDateTime(ButtonEditEndDate.Text);
                    if ((from comprodRec in loadingContext.COMPROD2 where comprodRec.TYPE == ComboBoxEditType.Text && comprodRec.CODE == code && (comprodRec.CommLevel_ID_Product ?? 0) == commLevel_ID_ProductSpinEdit.Value && (comprodRec.CommLevel_ID_Agency ?? 0) == commLevel_ID_AgencySpinEdit.Value && (comprodRec.AGENCY ?? "") == agency && (comprodRec.CAT ?? "") == cat && ((comprodRec.START_DATE >= start && comprodRec.START_DATE <= end) || (comprodRec.END_DATE <= end && comprodRec.END_DATE >= start) || (comprodRec.START_DATE <= start && comprodRec.END_DATE >= end && comprodRec.START_DATE <= end && comprodRec.END_DATE >= start)) select comprodRec).Count() > 0) //
                    {
                        labelGridSearchPkgHotel.Visible = true;
                        labelGridSearchAgency.Visible = true;
                        labelCheckEdiExclusion.Visible = true;
                        CheckEditExclusion.Visible = true;
                        GridSearchControlPkgAgency.Visible = true;
                        GridSearchControlPkgHotel.Visible = true;
                        loadPkgHotel();
                    }
                    else
                    {
                        labelGridSearchPkgHotel.Visible = false;
                        labelGridSearchAgency.Visible = false;
                        labelCheckEdiExclusion.Visible = false;
                        CheckEditExclusion.Visible = false;
                        GridSearchControlPkgAgency.Visible = false;
                        GridSearchControlPkgHotel.Visible = false;
                    }
                }
            }
            ///////////////////////
        }

        private void tYPEComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (Comprod2BindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                    Modified = true;
                validCheck.check(sender, errorProvider1, ((COMPROD2)Comprod2BindingSource.Current).checkType, Comprod2BindingSource);
            }
        }
        private void sTART_DATEDateEdit_Leave(object sender, EventArgs e)
        {
            if (Comprod2BindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMPROD2)Comprod2BindingSource.Current).checkStart, Comprod2BindingSource);
            }
        }
        private void resDate_StartDateEdit_Leave(object sender, EventArgs e)
        {
            if (Comprod2BindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMPROD2)Comprod2BindingSource.Current).checkResStart, Comprod2BindingSource);
            }
        }
        private bool checkForms()
        {
            if (!_modified && !newRec)
                return true;
            bool validateMain = validCheck.checkAll(splitContainerControl1.Panel2.Controls, errorProvider1, ((COMPROD2)Comprod2BindingSource.Current).checkAll, Comprod2BindingSource);

            if (validateMain)
                return validCheck.saveRec(ref _modified, true, ref newRec, savingContext, Comprod2BindingSource, Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref _modified, false, ref newRec, savingContext, Comprod2BindingSource, Name, errorProvider1, Cursor);
                return false;
            }
        }

        private void setValues()
        {
            CommissionsGridView.SetFocusedRowCellValue("TYPE", string.Empty);
            CommissionsGridView.SetFocusedRowCellValue("CODE", string.Empty);
            CommissionsGridView.SetFocusedRowCellValue("CAT", string.Empty);
            CommissionsGridView.SetFocusedRowCellValue("AGENCY", string.Empty);
            CommissionsGridView.SetFocusedRowCellValue("COMM_PCT", 0);
            CommissionsGridView.SetFocusedRowCellValue("PKG_HOTEL", string.Empty);
            CommissionsGridView.SetFocusedRowCellValue("Inactive", false); 
            CommissionsGridView.SetFocusedRowCellValue("RecType", string.Empty);
            CommissionsGridView.SetFocusedRowCellValue("Exclusion", false);          
            ImageBoxCode.Text = "";
            TextEditFreeCode.Text = "";
            ImageBoxCode.Properties.ReadOnly = false;
            ImageComboBoxEditAgency.Properties.ReadOnly = false;           
            //ComboBoxEditProductLevelRule.Text = "";
           // ComboBoxEditAgencyLevelRule.Text = "";
            labelGridSearchPkgHotel.Visible = false;
            labelGridSearchAgency.Visible = false;
            labelCheckEdiExclusion.Visible = false;
            CheckEditExclusion.Visible = false;           
            GridSearchControlPkgAgency.Visible = false;
            GridSearchControlPkgHotel.Visible = false;
            ImageComboBoxEditRecType.Focus();

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {           
            CommissionsGridView.ClearColumnsFilter();
            ImageComboBoxEditRecType.Focus();
            if (Comprod2BindingSource.Current == null)
            {
                Comprod2BindingSource.DataSource = from opt in savingContext.COMPROD2 where opt.CODE == "KJM9" select opt;
               
                Comprod2BindingSource.AddNew();
                if (CommissionsGridView.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                    CommissionsGridView.FocusedRowHandle = CommissionsGridView.RowCount - 1;
                exclusionCheck = false;
                setValues();
                newRec = true;
                return;
            }
            
            CommissionsGridView.CloseEditor();
            bool temp = newRec;
            if (checkForms())
            {
                //Comprod2BindingSource.ResetCurrentItem();
                errorProvider1.Clear();
                if (!temp)
                    savingContext.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (COMPROD2)Comprod2BindingSource.Current);

                Comprod2BindingSource.AddNew();
                if (CommissionsGridView.FocusedRowHandle == GridControl.AutoFilterRowHandle) 
                    CommissionsGridView.FocusedRowHandle = CommissionsGridView.RowCount - 1;
                setValues();
                newRec = true;
                exclusionCheck = false;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (Comprod2BindingSource.Current == null)
                return;
           
            CommissionsGridView.CloseEditor();
            if (MessageBox.Show("Are you sure you want to delete?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ImageBoxCode.Properties.Items.Clear();
                commLevel_ID_ProductSpinEdit.Text = null;
                commLevel_ID_AgencySpinEdit.Text = null;
                errorProvider1.Clear();
                Comprod2BindingSource.RemoveCurrent();
                savingContext.SaveChanges();
                CommissionsGridView.MoveFirst();
                loadUnbound();
                currentVal = ImageComboBoxEditRecType.Text;
                ImageComboBoxEditRecType.Focus();
                labelGridSearchPkgHotel.Visible = false;
                labelGridSearchAgency.Visible = false;
                labelCheckEdiExclusion.Visible = false;
                CheckEditExclusion.Visible = false;
                GridSearchControlPkgAgency.Visible = false;
                GridSearchControlPkgHotel.Visible = false;
                Modified = false;
                newRec = false;
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Deleted";
                rowStatusDelete = new Timer();
                rowStatusDelete.Interval = 3000;
                rowStatusDelete.Start();
                rowStatusDelete.Tick += new EventHandler(TimedEventDelete);
              
               
            }
            
        }

        private void TimedEventDelete(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusDelete.Stop();
        }

        void loadUnbound()
        {
            if (commLevel_ID_AgencySpinEdit.Value > 0)
            {
                int value = (int)commLevel_ID_AgencySpinEdit.Value;
                var load = (from c in loadingContext.CommLevel where c.ID == value select c).FirstOrDefault();
                //ComboBoxEditAgencyLevelRule.Text = load.Description;
                if (!string.IsNullOrWhiteSpace(load.Query))
                {
                    ((COMPROD2)Comprod2BindingSource.Current).AgencyTable = "Query";
                    ((COMPROD2)Comprod2BindingSource.Current).AgencyColumn = "Query";
                }
                else
                {
                    ((COMPROD2)Comprod2BindingSource.Current).AgencyTable = load.Lookup_Table;
                    ((COMPROD2)Comprod2BindingSource.Current).AgencyColumn = load.Lookup_Column;
                }
            }
            else
            {
               // ComboBoxEditAgencyLevelRule.Text = "";
                labelAgencyImageBox.Text = "Agency";
            }

            if (commLevel_ID_ProductSpinEdit.Value > 0)
            {
                int value = (int)commLevel_ID_ProductSpinEdit.Value;
                var load = (from c in loadingContext.CommLevel where c.ID == value select c).FirstOrDefault();
              //  ComboBoxEditProductLevelRule.Text = load.Description;
                if (!string.IsNullOrWhiteSpace(load.Query))
                    ((COMPROD2)Comprod2BindingSource.Current).CodeTable = "Query";

                if (string.IsNullOrWhiteSpace(load.Query) && string.IsNullOrWhiteSpace(load.Lookup_Table) && string.IsNullOrWhiteSpace(load.Lookup_Column) && string.IsNullOrWhiteSpace(load.Link_Rectype) && (load.Link_Column != "CODE" || load.Link_Column != "Code"))
                    ((COMPROD2)Comprod2BindingSource.Current).CodeTable = "FreeForm";

                if (!string.IsNullOrWhiteSpace(load.Lookup_Table))
                    ((COMPROD2)Comprod2BindingSource.Current).CodeTable = load.Lookup_Table;

               
            }
            else
            {
                ImageComboBoxEditProductLevelRule.Text = "";
                //labelCodeImageBox.Text = "Code";
            }

            if (!string.IsNullOrWhiteSpace(TextEditCode.Text))
            {
                TextEditFreeCode.Text = TextEditCode.Text;
                ImageBoxCode.EditValue = TextEditCode.Text;
            }
            else
            {
                TextEditFreeCode.Text = "";
                ImageBoxCode.EditValue = "";
            }

			string agency = ((COMPROD2)Comprod2BindingSource.Current).AGENCY;
			if (!string.IsNullOrWhiteSpace(agency)) {
				textEditFreeAgency.Text = agency;
				ImageComboBoxEditAgency.EditValue = agency;
			}
			else {
				textEditFreeAgency.Text = "";
				ImageComboBoxEditAgency.EditValue = "";
			}

		}

      
        private void cOMPROD2BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            ImageComboBoxEditRecType.Focus();
            if (Comprod2BindingSource.Current == null)
                return;

            this.Cursor = Cursors.WaitCursor;
            panelControlStatus.Visible = true;
            LabelStatus.Text = "SAVE IN PROGRESS......";
            bool temp = newRec;
            if (checkForms())
            {
                Modified = false;
                newRec = false;
                errorProvider1.Clear();
                //setReadOnly(true);
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;               
               
            }
            this.Cursor = Cursors.Arrow;

            if (!temp && !_modified)
                savingContext.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (COMPROD2)Comprod2BindingSource.Current);
            
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }
        private bool move()
        {
            CommissionsGridView.CloseEditor();
            Comprod2BindingNavigator.Focus();//trigger field leave event
            bool temp = newRec;
            if (checkForms())
            {
                Comprod2BindingSource.ResetCurrentItem();
                //if (!temp)
                //    context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (COMPROD2)Comprod2BindingSource.Current);               
                newRec = false;
                Modified = false;
                return true;
            }
            return false;
        }
        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (move())
                Comprod2BindingSource.MoveFirst();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (move())
                Comprod2BindingSource.MovePrevious();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (move())
                Comprod2BindingSource.MoveNext();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (move())
                Comprod2BindingSource.MoveLast();
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
           
            if (Comprod2BindingSource.Current == null)
            {
                ImageBoxCode.EditValue = "";
                ImageComboBoxEditAgency.EditValue = "";
               e.Allow = true;
                return;
            }
            bool temp = newRec;
            bool temp2 = _modified;
            if (checkForms())
            {
                //ImageBoxCode.EditValue = "";
                //ImageComboBoxEditAgency.EditValue = "";
                e.Allow = true;
                if ((!temp) && temp2)
                    savingContext.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (COMPROD2)Comprod2BindingSource.Current);
            }
            else
            {
                if ((!temp) && !_modified)
                    savingContext.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (COMPROD2)Comprod2BindingSource.Current);
           
                e.Allow = false;
            }

            loadUnbound();
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!CommissionsGridView.IsFilterRow(e.RowHandle))
                Modified = true;
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction; //Suppress displaying the error message box
        }

        private void Comprod2Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_modified || newRec)
            {
                DialogResult select = DevExpress.XtraEditors.XtraMessageBox.Show("There are unsaved changes. Are you sure you want to exit?", Name, MessageBoxButtons.YesNo);
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
            //temp = newRec;
            //if (newRec != true)
            //{
            //    if (!temp && checkForms())
            //        context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, (COMPROD2)Comprod2BindingSource.Current);
            //}
        }

        private void overlappingRatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime start = Convert.ToDateTime(ButtonEditStartDate.Text);
            DateTime end = Convert.ToDateTime(ButtonEditEndDate.Text);
            string agency = ImageComboBoxEditAgency.EditValue.ToString();
            string code = ImageBoxCode.EditValue.ToString();
            string cat = ImageComboBoxEditCategory.EditValue.ToString();
            var load = from c in loadingContext.COMPROD2 where c.ID != ((COMPROD2)Comprod2BindingSource.Current).ID && c.Inactive == false && c.TYPE == ComboBoxEditType.Text.TrimEnd() && (c.CommLevel_ID_Product ?? 0) == commLevel_ID_ProductSpinEdit.Value && (c.CommLevel_ID_Agency ?? 0) == commLevel_ID_AgencySpinEdit.Value && (c.AGENCY ?? "") == agency && (c.CODE ?? "") == code && (c.CAT ?? "") == cat && ((c.START_DATE >= start && c.START_DATE <= end) || (c.END_DATE <= end && c.END_DATE >= start) || (c.START_DATE <= start && c.END_DATE >= end && c.START_DATE <= end && c.END_DATE >= start)) select c;
            if (load.Count() == 0)
                MessageBox.Show("No overlapping rate sheets exist.");
            else
            {
                GridControlOverlappingRates.DataSource = load;
                popupContainerEditOverlappingGrid.ShowPopup();
            }
        }

        private void loadPkgHotel()
        {
          if(ComboBoxEditType.Text == "HTL")
              GridSearchControlPkgHotel.GridControl.DataSource = loadingContext.HOTEL;
          if (ComboBoxEditType.Text == "PKG")
              GridSearchControlPkgHotel.GridControl.DataSource = loadingContext.PACK;
          if (ComboBoxEditType.Text == "OPT")
              GridSearchControlPkgHotel.GridControl.DataSource = loadingContext.COMP;
        }

        private void Comprod2BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            ImageComboBoxEditAgency.Properties.ReadOnly = false;
            ImageBoxCode.Properties.ReadOnly = false;
            ImageComboBoxEditAgencyLevelRule.Properties.ReadOnly = false;
            ImageComboBoxEditProductLevelRule.Properties.ReadOnly = false;
            if (((COMPROD2)Comprod2BindingSource.Current) != null) {
                exclusionCheck = false;
                if (((COMPROD2)Comprod2BindingSource.Current).Exclusion == true) {
                    CheckEditExclusion.Visible = true;
                    GridSearchControlPkgAgency.Visible = true;
                    GridSearchControlPkgHotel.Visible = true;
                    loadPkgHotel();
                    labelGridSearchPkgHotel.Visible = true;
                    labelGridSearchAgency.Visible = true;
                    labelCheckEdiExclusion.Visible = true;
                }
                else {
                    labelGridSearchPkgHotel.Visible = false;
                    labelGridSearchAgency.Visible = false;
                    labelCheckEdiExclusion.Visible = false;
                    CheckEditExclusion.Visible = false;
                    GridSearchControlPkgAgency.Visible = false;
                    GridSearchControlPkgHotel.Visible = false;
                }
            }
            loadUnbound();

        }    


        private void eND_DATEDateEdit_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
        
            //}
            //catch { }
        }

        private void resDate_StartDateEdit_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(ButtonEditResDateStart.Text))
                    ButtonEditResDateStart.Text = validCheck.convertDate(ButtonEditResDateStart.Text);
            }
            catch { }
        }

        private void resDate_EndDateEdit_TextChanged(object sender, EventArgs e)
        {
            try
            {
               
                if (!string.IsNullOrWhiteSpace(ButtonEditResDateEnd.Text))
                    ButtonEditResDateEnd.Text = validCheck.convertDate(ButtonEditResDateEnd.Text);
            }
            catch { }
        }

        private void sTART_DATEDateEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { StartPosition = FormStartPosition.CenterScreen };
            xform.Show();
        }

       
        private void resDate_StartDateEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { StartPosition = FormStartPosition.CenterScreen };
            xform.Show();
        }

        private void eND_DATEDateEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { StartPosition = FormStartPosition.CenterScreen };
            xform.Show();
        }

        private void resDate_EndDateEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { StartPosition = FormStartPosition.CenterScreen };
            xform.Show();
        }

        private void resDate_StartButtonEdit_ParseEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if ("".Equals(e.Value))
            {
                e.Value = null;
                e.Handled = true;
            }
        }

        private void resDate_StartButtonEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.None)
            {
                BaseEdit editor = (sender as ButtonEdit);
                if (editor != null)
                    editor.EditValue = null;
                e.Handled = true;
            }
        }

        private void cATImageComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (Comprod2BindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMPROD2)Comprod2BindingSource.Current).checkCat, Comprod2BindingSource);
            }
        }
        private void productLevelSearch_Leave(object sender, EventArgs e)
        {
            if (Comprod2BindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }

                if (string.IsNullOrWhiteSpace(ImageBoxCode.Text) && string.IsNullOrWhiteSpace(ImageComboBoxEditProductLevelRule.Text))
                    ImageComboBoxEditCategory.Properties.ReadOnly = true;
                else
                    ImageComboBoxEditCategory.Properties.ReadOnly = false;
            }
        }
        private void agencyLevelSearch_Leave(object sender, EventArgs e)
        {
            if (Comprod2BindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
            }
        }

        private void cODEImageComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (Comprod2BindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
            }
        }
        private void aGENCYImageComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (Comprod2BindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                validCheck.check(sender, errorProvider1, ((COMPROD2)Comprod2BindingSource.Current).checkAgency, Comprod2BindingSource);
            }
        }
        private void textEdit_Leave(object sender, EventArgs e)
        {
            if (Comprod2BindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
            }
        }
     
        private void GridSearchControlPkgHotel_Enter(object sender, EventArgs e)
        {
            
            currentVal = ((Control)sender).Text;
            GridSearchControlPkgHotel.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        private void GridSearchControlPkgHotel_Leave(object sender, EventArgs e)
        {
            if (Comprod2BindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                GridSearchControlPkgHotel.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp1;
                validCheck.check(sender, errorProvider1, ((COMPROD2)Comprod2BindingSource.Current).checkHotel, Comprod2BindingSource);
            }
        }
        void ButtonEdit_QueryPopUp1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void ImageBoxCode_EditValueChanged(object sender, EventArgs e)
        {

			if (ImageBoxCode.Visible) {
				ImageComboBoxEditProductLevelRule.TextChanged -= ProductRuleTextChanged;
                if (!string.IsNullOrEmpty(ImageComboBoxEditRecType.EditValue.ToString())) {
                    ((COMPROD2)Comprod2BindingSource.Current).RecType = ImageComboBoxEditRecType.EditValue.ToString();
                }
                //if (!string.IsNullOrEmpty(ComboBoxEditType.Text))
                //{
                //    ((COMPROD2)Comprod2BindingSource.Current).TYPE = ComboBoxEditType.Text;
                //}
                //if (!string.IsNullOrEmpty(ImageComboBoxEditAgency.Text))
                //{
                //    ((COMPROD2)Comprod2BindingSource.Current).AGENCY = ImageComboBoxEditAgency.EditValue.ToString();
                //}
                //else
                //{
                //    ((COMPROD2)Comprod2BindingSource.Current).AGENCY = textEditFreeAgency.Text;
                //}
                //if (string.IsNullOrEmpty(ImageBoxCode.Text))
                //{
                //    ((COMPROD2)Comprod2BindingSource.Current).CODE = TextEditFreeCode.Text;
                //}
                //else
                //{
                //    ((COMPROD2)Comprod2BindingSource.Current).CODE = ImageBoxCode.EditValue.ToString();
                //}
                ImageComboBoxEditProductLevelRule.TextChanged += ProductRuleTextChanged;
                if (string.IsNullOrWhiteSpace(ImageBoxCode.Text) && string.IsNullOrWhiteSpace(ImageComboBoxEditProductLevelRule.Text))
					ImageComboBoxEditCategory.Properties.ReadOnly = true;
				else
					ImageComboBoxEditCategory.Properties.ReadOnly = false;
			}

            if (CheckEditExclusion.Checked)
            {
                
                TextEditCommPct.Properties.ReadOnly = true;
                if (!string.IsNullOrWhiteSpace(ImageComboBoxEditProductLevelRule.Text))
                {
                    GridSearchControlPkgHotel.ButtonEdit.Properties.ReadOnly = false;
                    if (!string.IsNullOrWhiteSpace(ImageComboBoxEditAgencyLevelRule.Text))
                        GridSearchControlPkgAgency.ButtonEdit.Properties.ReadOnly = false;
                    int ID = (int)ImageComboBoxEditProductLevelRule.EditValue;
                    IQueryable table;
                    var commRule = (from commRec in loadingContext.CommLevel where commRec.ID == ID select commRec).FirstOrDefault();

                    string linkColumn = commRule.Link_Column.TrimEnd();
                    string linkTable = commRule.Link_Table.TrimEnd();
                    string linkRectype = commRule.Link_Rectype.TrimEnd();
                    //replace blank spaces in column name
                    if (linkColumn.Contains(" "))
                        linkColumn = linkColumn.Replace(" ", "_");
                    //here we get the table to use in evaluating whether the rule's criteria are met or not
                    table = (IQueryable)(loadingContext.GetType()).GetProperty(linkTable).GetValue(loadingContext, null);
                    if ("HOTEL,PACK,COMP".Contains(linkTable))
                    {
                        table = table.Where(String.Format("{0} = @0", linkColumn), ImageBoxCode.EditValue);
                        GridSearchControlPkgHotel.GridControl.DataSource = table;

                    }
                    else if ("AGY".Contains(linkTable))
                    {
                        table = table.Where(String.Format("{0} = @0", linkColumn), ImageBoxCode.EditValue);
                        GridSearchControlPkgHotel.GridControl.DataSource = table;
                        //if it's the product table, then check whether the product passed in as a parameter
                        // meets the requirements based on the field and value specified in the rule 
                    }
                    else
                    {
                        
                        //if the table is an external table (like DETAILS) check the fields to see if it matches
                        //table = table.Where(String.Format("LINK_TABLE = @0 and RECTYPE = @1 and LINK_VALUE = @2 and {0} = @3", linkColumn), commRule.Type, linkRectype, Code, commRec.CODE);
                    }
                }
            }
            else
            {
                TextEditCommPct.Properties.ReadOnly = false;
                GridSearchControlPkgHotel.ButtonEdit.Properties.ReadOnly = true;
                GridSearchControlPkgAgency.ButtonEdit.Properties.ReadOnly = true;
            }
        }

        private void GridSearchControlPkgAgency_Enter(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
            GridSearchControlPkgAgency.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp;
        }

        private void GridSearchControlPkgAgency_Leave(object sender, EventArgs e)
        {
            if (Comprod2BindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    Modified = true;
                }
                GridSearchControlPkgAgency.ButtonEdit.QueryPopUp += ButtonEdit_QueryPopUp1;
            }
        }
        private void ImageComboBoxEditAgency_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (((COMPROD2)Comprod2BindingSource.Current) != null)
                {
					if (ImageComboBoxEditAgency.Visible) {
						ImageComboBoxEditAgency.TextChanged -= AgencyRuleTextChanged;
                        ((COMPROD2)Comprod2BindingSource.Current).AGENCY = ImageComboBoxEditAgency.EditValue.ToString();
						ImageComboBoxEditAgency.TextChanged += AgencyRuleTextChanged;
                    }

                    if (((COMPROD2)Comprod2BindingSource.Current).Exclusion == true)
                    {
                     
                        TextEditCommPct.Properties.ReadOnly = true;
                        if (((COMPROD2)Comprod2BindingSource.Current).CommLevel_ID_Agency > 0)
                        {
                            GridSearchControlPkgAgency.ButtonEdit.Properties.ReadOnly = false;
                            IQueryable table;
                            var commRule = (from commRec in loadingContext.CommLevel where commRec.ID == ((COMPROD2)Comprod2BindingSource.Current).CommLevel_ID_Agency select commRec).FirstOrDefault();
                                
                            string linkColumn = commRule.Link_Column.TrimEnd();
                            string linkTable = commRule.Link_Table.TrimEnd();
                            string linkRectype = commRule.Link_Rectype.TrimEnd();
                            //replace blank spaces in column name
                            if (linkColumn.Contains(" "))
                                linkColumn = linkColumn.Replace(" ", "_");
                            //here we get the table to use in evaluating whether the rule's criteria are met or not
                            table = (IQueryable)(loadingContext.GetType()).GetProperty(linkTable).GetValue(loadingContext, null);
                            if ("HOTEL,PACK,COMP,AIR,CRU,INSURAN,CARINFO".Contains(linkTable))
                            {
                                table = table.Where(String.Format("{0} = @0", linkColumn), ImageComboBoxEditAgency.EditValue);
                                GridSearchControlPkgAgency.GridControl.DataSource = table;
                                //1
                            }
                            else if ("AGY".Contains(linkTable))
                            {
                                //table = table.Where(String.Format("{0} = @0", linkColumn), ImageComboBoxEditAgency.EditValue);
                                GridSearchControlPkgAgency.GridControl.DataSource = table;
                                //if it's the product table, then check whether the product passed in as a parameter
                                // meets the requirements based on the field and value specified in the rule 
                            }
                            else
                            {
                                //if the table is an external table (like DETAILS) check the fields to see if it matches
                                //table = table.Where(String.Format("LINK_TABLE = @0 and RECTYPE = @1 and LINK_VALUE = @2 and {0} = @3", linkColumn), commRule.Type, linkRectype, Code, commRec.CODE);
                            }
                        }
                    }
                    else
                    {
                        TextEditCommPct.Properties.ReadOnly = false;
                        GridSearchControlPkgAgency.ButtonEdit.Properties.ReadOnly = true;
                    }
                }
            }
            catch (Exception)
            {

            }

        }        

        private void CheckEditExclusion_Modified(object sender, EventArgs e)
        {
            gsLoad.gridSearchLoad(GridSearchControlPkgHotel, "CODE", "NAME", "Code", "Name", "CODE", "CODE", "CODE", Comprod2BindingSource, "Product_CODE_Exclusion");
            DateTime start = Convert.ToDateTime(ButtonEditStartDate.Text);
            DateTime end = Convert.ToDateTime(ButtonEditEndDate.Text);
            if (CheckEditExclusion.Checked)
            {
                string code = ImageBoxCode.EditValue.ToString();
                string cat = ImageComboBoxEditCategory.EditValue.ToString();
                string agency = ImageComboBoxEditAgency.EditValue.ToString();
                if ((from comprodRec in loadingContext.COMPROD2 where comprodRec.TYPE == ComboBoxEditType.Text && comprodRec.CODE == code && (comprodRec.CommLevel_ID_Product ?? 0) == commLevel_ID_ProductSpinEdit.Value && (comprodRec.CommLevel_ID_Agency ?? 0) == commLevel_ID_AgencySpinEdit.Value && (comprodRec.AGENCY ?? "") == agency && (comprodRec.CAT ?? "") == cat select comprodRec).Count() == 0) //&& ((comprodRec.START_DATE >= start && comprodRec.START_DATE <= end) || (comprodRec.END_DATE <= end && comprodRec.END_DATE >= start) || (comprodRec.START_DATE <= start && comprodRec.END_DATE >= end && comprodRec.START_DATE <= end && comprodRec.END_DATE >= start))
                {
                    CheckEditExclusion.Checked = false;
                    return;
                }
                
                TextEditCommPct.Properties.ReadOnly = true;
                if (!string.IsNullOrWhiteSpace(ImageComboBoxEditProductLevelRule.Text))
                {
                    GridSearchControlPkgHotel.ButtonEdit.Properties.ReadOnly = false;
                    if (!string.IsNullOrWhiteSpace(ImageComboBoxEditAgencyLevelRule.Text))
                        GridSearchControlPkgAgency.ButtonEdit.Properties.ReadOnly = false;
                    IQueryable table;
                    int ID = (int)ImageComboBoxEditProductLevelRule.EditValue;
                    var commRule = (from commRec in loadingContext.CommLevel where commRec.ID == ID select commRec).FirstOrDefault();

                    string linkColumn = commRule.Link_Column.TrimEnd();
                    string linkTable = commRule.Link_Table.TrimEnd();
                    string linkRectype = commRule.Link_Rectype.TrimEnd();
                    //replace blank spaces in column name
                    if (linkColumn.Contains(" "))
                        linkColumn = linkColumn.Replace(" ", "_");
                    //here we get the table to use in evaluating whether the rule's criteria are met or not
                    table = (IQueryable)(loadingContext.GetType()).GetProperty(linkTable).GetValue(loadingContext, null);
                    if ("HOTEL,PACK,COMP,AIR,CRU,INSURAN,CARINFO".Contains(linkTable))
                    {
                        table = table.Where(String.Format("{0} = @0", linkColumn), ImageBoxCode.EditValue);
                        GridSearchControlPkgHotel.GridControl.DataSource = table;

                    }
                    else if ("AGY".Contains(linkTable))
                    {
                        table = table.Where(String.Format("{0} = @0", linkColumn), ImageBoxCode.EditValue);
                        GridSearchControlPkgHotel.GridControl.DataSource = table;
                        //if it's the product table, then check whether the product passed in as a parameter
                        // meets the requirements based on the field and value specified in the rule 
                    }
                    else
                    {
                        gsLoad.gridSearchLoad(GridSearchControlPkgHotel, "LINK_VALUE", "NAME", "Code", "Name", "LINK_VALUE", "LINK_VALUE", "LINK_VALUE", Comprod2BindingSource, "Product_CODE_Exclusion");
                        string code1 = ImageBoxCode.EditValue.ToString();
                        var query = from detailRec in loadingContext.DETAIL
                                    where detailRec.CODE == code1 && detailRec.LINK_TABLE == ComboBoxEditType.Text
                                    from hotelRec in loadingContext.HOTEL
                                    where hotelRec.CODE == detailRec.LINK_VALUE
                                    select new { detailRec.LINK_VALUE, hotelRec.NAME };
                        GridSearchControlPkgHotel.GridControl.DataSource = query;
                        //if the table is an external table (like DETAILS) check the fields to see if it matches
                        //table = table.Where(String.Format("LINK_TABLE = @0 and RECTYPE = @1 and LINK_VALUE = @2 and {0} = @3", linkColumn), commRule.Type, linkRectype, Code, commRec.CODE);
                    }
                }
                if (!string.IsNullOrWhiteSpace(ImageComboBoxEditAgencyLevelRule.Text))
                {
                    GridSearchControlPkgAgency.ButtonEdit.Properties.ReadOnly = false;
                    IQueryable table;

                    var commRule = (from commRec in loadingContext.CommLevel where commRec.Description == ImageComboBoxEditAgencyLevelRule.Text select commRec).FirstOrDefault();

                    string linkColumn = commRule.Link_Column.TrimEnd();
                    string linkTable = commRule.Link_Table.TrimEnd();
                    string linkRectype = commRule.Link_Rectype.TrimEnd();
                    //replace blank spaces in column name
                    if (linkColumn.Contains(" "))
                        linkColumn = linkColumn.Replace(" ", "_");
                    //here we get the table to use in evaluating whether the rule's criteria are met or not
                    table = (IQueryable)(loadingContext.GetType()).GetProperty(linkTable).GetValue(loadingContext, null);
                    if ("HOTEL,PACK,COMP,AIR,CRU,INSURAN,CARINFO".Contains(linkTable))
                    {
                        table = table.Where(String.Format("{0} = @0", linkColumn), ImageComboBoxEditAgency.EditValue);
                        GridSearchControlPkgHotel.GridControl.DataSource = table;

                    }
                    else if ("AGY".Contains(linkTable))
                    {
                        table = table.Where(String.Format("{0} = @0", linkColumn), ImageComboBoxEditAgency.EditValue);
                        GridSearchControlPkgAgency.GridControl.DataSource = table;
                        //if it's the product table, then check whether the product passed in as a parameter
                        // meets the requirements based on the field and value specified in the rule 
                    }
                    else
                    {
                        gsLoad.gridSearchLoad(GridSearchControlPkgHotel, "LINK_VALUE", "NAME", "Code", "Name", "LINK_VALUE", "LINK_VALUE", "LINK_VALUE", Comprod2BindingSource, "Product_CODE_Exclusion");
                        string code2 = ImageComboBoxEditAgency.EditValue.ToString();
                        var query = from detailRec in loadingContext.DETAIL
                                    where detailRec.CODE == code2 && detailRec.LINK_TABLE == ComboBoxEditType.Text
                                    from hotelRec in loadingContext.HOTEL
                                    where hotelRec.CODE == detailRec.LINK_VALUE
                                    select new { detailRec.LINK_VALUE, hotelRec.NAME };
                        GridSearchControlPkgAgency.GridControl.DataSource = query;                        
                    }
                }
            }
            else
            {
                TextEditCommPct.Properties.ReadOnly = false;
                GridSearchControlPkgHotel.ButtonEdit.Properties.ReadOnly = true;
                GridSearchControlPkgAgency.ButtonEdit.Properties.ReadOnly = true;
            }
        }


        private void Comprod2Form_Load(object sender, EventArgs e)
        {
            loadUnbound();
        }

        private void inactiveCheckEdit_Modified(object sender, EventArgs e)
        {
            Modified = true;
        }

        private void ComboBoxEditType_Enter(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
            if (string.IsNullOrWhiteSpace(ImageComboBoxEditRecType.Text))
            {
                MessageBox.Show("Please select a commission type before proceeding");
                ImageComboBoxEditRecType.Focus();
                return;
            }
        }

        private void CommissionsGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            //try
            //{
            //    Set_labelCodeImageBox((int)CommissionsGridView.GetFocusedRowCellValue("CommLevel_ID_Product"));
            //}
            //catch (Exception)
            //{

            //    Set_labelCodeImageBox(0);
            //}
            

        }

        private void Set_labelCodeImageBox(int x)
        {
            //if (x > 0)
            //{
            //    string querytxt = (from cl in loadingContext.CommLevel where cl.ID == x select cl.Query).FirstOrDefault();
            //    if (querytxt.Length > 0)
            //    {
            //        labelCodeImageBox.Text = "QUERY";
            //    }
            //    else
            //    {
            //        string temp = (from cl in loadingContext.CommLevel where cl.ID == x select cl.Link_Column).FirstOrDefault();
            //        if ("COUNTRYCODEREGIONCODESERV TYPE".Contains(temp))
            //        {
            //            labelCodeImageBox.Text = (from cl in loadingContext.CommLevel where cl.ID == x select cl.Link_Column).FirstOrDefault();
            //        }
            //        else
            //        {
            //            labelCodeImageBox.Text = "Value";
            //        }

            //    }
            //}
            //else
            //{
            //    labelCodeImageBox.Text = "Code";
            //}

        }

        private void Set_ImageBoxCode(int x)
        {

        }

        private void ButtonEditStartDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(ButtonEditStartDate.Text))
                    ButtonEditStartDate.Text = validCheck.convertDate(ButtonEditStartDate.Text);
            }
            catch { }
        }


        private void ButtonEditEndDate_EditValueChanging(object sender, ChangingEventArgs e)
        {
            
        }

        private void ButtonEditEndDate_EditValueChanged(object sender, EventArgs e)
        {
            //this should only fire once when setting the value of a new record
            if (!string.IsNullOrWhiteSpace(ButtonEditEndDate.Text))
                ButtonEditEndDate.Text = validCheck.convertDate(ButtonEditEndDate.Text);
            //if (exclusionCheck)
            //    return;           
        }

		private void TextEditFreeCode_TextChanged(object sender, EventArgs e)
		{
			if (TextEditFreeCode.Visible) {
				ImageComboBoxEditProductLevelRule.TextChanged -= ProductRuleTextChanged;
                ((COMPROD2)Comprod2BindingSource.Current).CODE = TextEditFreeCode.Text;
				ImageComboBoxEditProductLevelRule.TextChanged += ProductRuleTextChanged;
                if (string.IsNullOrWhiteSpace(ImageBoxCode.Text) && string.IsNullOrWhiteSpace(ImageComboBoxEditProductLevelRule.Text))
                    ImageComboBoxEditCategory.Properties.ReadOnly = true;
                else
                    ImageComboBoxEditCategory.Properties.ReadOnly = false;
			}
		}

		private void textEditFreeAgency_TextChanged(object sender, EventArgs e)
		{
			if (textEditFreeAgency.Visible) {
				ImageComboBoxEditAgencyLevelRule.TextChanged -= AgencyRuleTextChanged;
                ((COMPROD2)Comprod2BindingSource.Current).AGENCY = textEditFreeAgency.Text;
				ImageComboBoxEditAgencyLevelRule.TextChanged += AgencyRuleTextChanged;
            }
        }

        private void checkEditFlagsAvailability_Modified(object sender, EventArgs e)
        {
            Modified = true;
        }

        private void checkEditFlagsImports_Modified(object sender, EventArgs e)
        {
            Modified = true;
        }

        private void ImageComboBoxEditRecType_EditValueChanged(object sender, EventArgs e)
        {
            RecTypeChanged();
        }
    }
}
