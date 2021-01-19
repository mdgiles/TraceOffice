
using System;
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

using System.Linq;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Runtime.InteropServices;
using DevExpress.XtraBars;

namespace TraceForms
{
    partial class mediaInfoMaint
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label LabelAgency;
            System.Windows.Forms.Label LabelType;
            System.Windows.Forms.Label LabelsvcStartDate;
            System.Windows.Forms.Label LabelsvcEndDate;
            System.Windows.Forms.Label LabelSection;
            System.Windows.Forms.Label LabelLanguage;
            System.Windows.Forms.Label LabelCode;
            System.Windows.Forms.Label LabelCategory;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label LabelInactive;
            System.Windows.Forms.Label LabelSeverity;
            System.Windows.Forms.Label LabelConsent;
            System.Windows.Forms.Label LabelImage4;
            System.Windows.Forms.Label LabelImage3;
            System.Windows.Forms.Label LabelImage2;
            System.Windows.Forms.Label LabelImage1;
            System.Windows.Forms.Label LabelCaption;
            System.Windows.Forms.Label LabelTitle;
            System.Windows.Forms.Label LabelSubtitle;
            SpiceLogic.HtmlEditorControl.Domain.DesignTime.DictionaryFileInfo dictionaryFileInfo1 = new SpiceLogic.HtmlEditorControl.Domain.DesignTime.DictionaryFileInfo();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mediaInfoMaint));
            this.BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.CheckEditInhouse = new DevExpress.XtraEditors.CheckEdit();
            this.xtraTabControlMediaInfo = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageText = new DevExpress.XtraTab.XtraTabPage();
            this.panelControlText = new DevExpress.XtraEditors.PanelControl();
            this.HtmlEditor = new SpiceLogic.WinHTMLEditor.WinForm.WinFormHtmlEditor();
            this.TextEditTitle = new DevExpress.XtraEditors.TextEdit();
            this.TextEditSubtitle = new DevExpress.XtraEditors.TextEdit();
            this.xtraTabPagePrimaryImages = new DevExpress.XtraTab.XtraTabPage();
            this.panelControlPrimaryImages = new DevExpress.XtraEditors.PanelControl();
            this.TextEditCaption = new DevExpress.XtraEditors.TextEdit();
            this.xtraTabControlPictures = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControlLowRes = new DevExpress.XtraEditors.PanelControl();
            this.azureBlobBrowser1LowRes = new TraceForms.AzureBlobBrowser.AzureBlobBrowser();
            this.BarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTools = new DevExpress.XtraBars.Bar();
            this.BarButtonItemNew = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItemDelete = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItemClone = new DevExpress.XtraBars.BarButtonItem();
            this.BarButtonItemExpand = new DevExpress.XtraBars.BarButtonItem();
            this.BarSubItemReports = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItemReportsContainingSection = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemAddToReports = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemRemoveFromReports = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCreateNewReports = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.PictureEditPreviewImage1LowRes = new DevExpress.XtraEditors.PictureEdit();
            this.labelControlSizeDisplay1LowRes = new DevExpress.XtraEditors.LabelControl();
            this.labelControlSize = new DevExpress.XtraEditors.LabelControl();
            this.ButtonEditImage1LowRes = new DevExpress.XtraEditors.ButtonEdit();
            this.ButtonCreateThumbnailLowRes = new DevExpress.XtraEditors.SimpleButton();
            this.LabelPeview = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPage5 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControlMedRes = new DevExpress.XtraEditors.PanelControl();
            this.azureBlobBrowser2MedRes = new TraceForms.AzureBlobBrowser.AzureBlobBrowser();
            this.labelControlSizeDisplay2MedRes = new DevExpress.XtraEditors.LabelControl();
            this.labelControlSize2 = new DevExpress.XtraEditors.LabelControl();
            this.ButtonEditImage2MedRes = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControlPreview2 = new DevExpress.XtraEditors.LabelControl();
            this.ButtonCreateThumbnailMedRes = new DevExpress.XtraEditors.SimpleButton();
            this.PictureEditPreviewImage2MedRes = new DevExpress.XtraEditors.PictureEdit();
            this.xtraTabPage6 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControlHighRes = new DevExpress.XtraEditors.PanelControl();
            this.azureBlobBrowser3HighRes = new TraceForms.AzureBlobBrowser.AzureBlobBrowser();
            this.labelControlSizeDisplay3HighRes = new DevExpress.XtraEditors.LabelControl();
            this.labelControlSize3 = new DevExpress.XtraEditors.LabelControl();
            this.ButtonEditImage3HighRes = new DevExpress.XtraEditors.ButtonEdit();
            this.ButtonCreateThumbNailHighRes = new DevExpress.XtraEditors.SimpleButton();
            this.LabelPreview3 = new DevExpress.XtraEditors.LabelControl();
            this.PictureEditPreviewImage3HighRes = new DevExpress.XtraEditors.PictureEdit();
            this.xtraTabPage7 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControlThumbNail = new DevExpress.XtraEditors.PanelControl();
            this.azureBlobBrowser4Thumb = new TraceForms.AzureBlobBrowser.AzureBlobBrowser();
            this.labelControlSizeDisplay4Thumb = new DevExpress.XtraEditors.LabelControl();
            this.labelControlSize4 = new DevExpress.XtraEditors.LabelControl();
            this.ButtonEditImage4Thumb = new DevExpress.XtraEditors.ButtonEdit();
            this.LabelPreview4 = new DevExpress.XtraEditors.LabelControl();
            this.PictureEditPreviewImage4Thumb = new DevExpress.XtraEditors.PictureEdit();
            this.xtraTabPageAdditionalImages = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.GridControlAdditionalImages = new DevExpress.XtraGrid.GridControl();
            this.BindingSourceResource = new System.Windows.Forms.BindingSource(this.components);
            this.GridViewAdditionalImages = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColumnID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnLinkTable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnLinkValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnRecType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnTag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBoxTag = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.ColumnItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemAzureBlobBrowser = new TraceForms.AzureBlobBrowser.RepositoryItemAzureBlobBrowser();
            this.ColumnDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnUserDec1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnUserDec2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnUserInt1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnUserInt2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnUserTxt1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBoxImagePurpose = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.ColumnUserTxt2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnUserTxt3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnUserTxt4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnUserDte1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnUserDte2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPreview = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPopupContainerEditPreview = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
            this.popupContainerControlPreview = new DevExpress.XtraEditors.PopupContainerControl();
            this.pictureEditPreviewAddImg = new DevExpress.XtraEditors.PictureEdit();
            this.repositoryItemButtonEdit_Item = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ButtonDelRow = new DevExpress.XtraEditors.SimpleButton();
            this.ButtonAddRow = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPageDisplay = new DevExpress.XtraTab.XtraTabPage();
            this.panelControlDisplay = new DevExpress.XtraEditors.PanelControl();
            this.ImageComboBoxEditSeverity = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.CheckEditConsent = new DevExpress.XtraEditors.CheckEdit();
            this.CheckEditInactive = new DevExpress.XtraEditors.CheckEdit();
            this.GridControlLookup = new DevExpress.XtraGrid.GridControl();
            this.EntityInstantFeedbackSource = new DevExpress.Data.Linq.EntityInstantFeedbackSource();
            this.GridViewLookup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnLang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnRoom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnSection = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnSubtitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnCaption = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnImage1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnImage2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnImage3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnInactive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnSvcDateStart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnSvcDateEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnAgency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnInhouse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnChgDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnImage4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnSeverity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnConsent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnMediaRptItems = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ComboBoxEditType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.SplitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.CheckEditAllCategory = new DevExpress.XtraEditors.CheckEdit();
            this.CheckEditAllAgency = new DevExpress.XtraEditors.CheckEdit();
            this.LabelChgDate = new DevExpress.XtraEditors.LabelControl();
            this.LabelChangeDate = new DevExpress.XtraEditors.LabelControl();
            this.DateEditSvcStartDate = new DevExpress.XtraEditors.DateEdit();
            this.DateEditSvcEndDate = new DevExpress.XtraEditors.DateEdit();
            this.DateEditResStartDate = new DevExpress.XtraEditors.DateEdit();
            this.DateEditResEndDate = new DevExpress.XtraEditors.DateEdit();
            this.SearchLookupEditLang = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.BindingSourceCodeName = new System.Windows.Forms.BindingSource(this.components);
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SearchLookupEditProduct = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.bindingSourceCodeNameProduct = new System.Windows.Forms.BindingSource(this.components);
            this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SearchLookupEditSection = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SearchLookupEditAgency = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SearchLookupEditCategory = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
            this.PanelControlStatus = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            LabelAgency = new System.Windows.Forms.Label();
            LabelType = new System.Windows.Forms.Label();
            LabelsvcStartDate = new System.Windows.Forms.Label();
            LabelsvcEndDate = new System.Windows.Forms.Label();
            LabelSection = new System.Windows.Forms.Label();
            LabelLanguage = new System.Windows.Forms.Label();
            LabelCode = new System.Windows.Forms.Label();
            LabelCategory = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            LabelInactive = new System.Windows.Forms.Label();
            LabelSeverity = new System.Windows.Forms.Label();
            LabelConsent = new System.Windows.Forms.Label();
            LabelImage4 = new System.Windows.Forms.Label();
            LabelImage3 = new System.Windows.Forms.Label();
            LabelImage2 = new System.Windows.Forms.Label();
            LabelImage1 = new System.Windows.Forms.Label();
            LabelCaption = new System.Windows.Forms.Label();
            LabelTitle = new System.Windows.Forms.Label();
            LabelSubtitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditInhouse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlMediaInfo)).BeginInit();
            this.xtraTabControlMediaInfo.SuspendLayout();
            this.xtraTabPageText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlText)).BeginInit();
            this.panelControlText.SuspendLayout();
            this.HtmlEditor.Toolbar1.SuspendLayout();
            this.HtmlEditor.Toolbar2.SuspendLayout();
            this.HtmlEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditSubtitle.Properties)).BeginInit();
            this.xtraTabPagePrimaryImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlPrimaryImages)).BeginInit();
            this.panelControlPrimaryImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCaption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlPictures)).BeginInit();
            this.xtraTabControlPictures.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlLowRes)).BeginInit();
            this.panelControlLowRes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.azureBlobBrowser1LowRes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureEditPreviewImage1LowRes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEditImage1LowRes.Properties)).BeginInit();
            this.xtraTabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlMedRes)).BeginInit();
            this.panelControlMedRes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.azureBlobBrowser2MedRes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEditImage2MedRes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureEditPreviewImage2MedRes.Properties)).BeginInit();
            this.xtraTabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlHighRes)).BeginInit();
            this.panelControlHighRes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.azureBlobBrowser3HighRes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEditImage3HighRes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureEditPreviewImage3HighRes.Properties)).BeginInit();
            this.xtraTabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlThumbNail)).BeginInit();
            this.panelControlThumbNail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.azureBlobBrowser4Thumb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEditImage4Thumb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureEditPreviewImage4Thumb.Properties)).BeginInit();
            this.xtraTabPageAdditionalImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlAdditionalImages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceResource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewAdditionalImages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBoxTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemAzureBlobBrowser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxImagePurpose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEditPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControlPreview)).BeginInit();
            this.popupContainerControlPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditPreviewAddImg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit_Item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.xtraTabPageDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlDisplay)).BeginInit();
            this.panelControlDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditSeverity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditConsent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditInactive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxEditType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl)).BeginInit();
            this.SplitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditAllCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditAllAgency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditSvcStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditSvcStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditSvcEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditSvcEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditResStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditResStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditResEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditResEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditLang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceCodeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCodeNameProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditSection.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditAgency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlStatus)).BeginInit();
            this.PanelControlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelAgency
            // 
            LabelAgency.AutoSize = true;
            LabelAgency.Location = new System.Drawing.Point(9, 104);
            LabelAgency.Name = "LabelAgency";
            LabelAgency.Size = new System.Drawing.Size(43, 13);
            LabelAgency.TabIndex = 0;
            LabelAgency.Text = "Agency";
            // 
            // LabelType
            // 
            LabelType.AutoSize = true;
            LabelType.Location = new System.Drawing.Point(8, 11);
            LabelType.Name = "LabelType";
            LabelType.Size = new System.Drawing.Size(31, 13);
            LabelType.TabIndex = 0;
            LabelType.Text = "Type";
            // 
            // LabelsvcStartDate
            // 
            LabelsvcStartDate.AutoSize = true;
            LabelsvcStartDate.Location = new System.Drawing.Point(8, 153);
            LabelsvcStartDate.Name = "LabelsvcStartDate";
            LabelsvcStartDate.Size = new System.Drawing.Size(120, 13);
            LabelsvcStartDate.TabIndex = 0;
            LabelsvcStartDate.Text = "Service Date:        From";
            // 
            // LabelsvcEndDate
            // 
            LabelsvcEndDate.AutoSize = true;
            LabelsvcEndDate.Location = new System.Drawing.Point(261, 153);
            LabelsvcEndDate.Name = "LabelsvcEndDate";
            LabelsvcEndDate.Size = new System.Drawing.Size(47, 13);
            LabelsvcEndDate.TabIndex = 0;
            LabelsvcEndDate.Text = "Through";
            // 
            // LabelSection
            // 
            LabelSection.AutoSize = true;
            LabelSection.Location = new System.Drawing.Point(8, 81);
            LabelSection.Name = "LabelSection";
            LabelSection.Size = new System.Drawing.Size(42, 13);
            LabelSection.TabIndex = 0;
            LabelSection.Text = "Section";
            // 
            // LabelLanguage
            // 
            LabelLanguage.AutoSize = true;
            LabelLanguage.Location = new System.Drawing.Point(8, 34);
            LabelLanguage.Name = "LabelLanguage";
            LabelLanguage.Size = new System.Drawing.Size(54, 13);
            LabelLanguage.TabIndex = 0;
            LabelLanguage.Text = "Language";
            // 
            // LabelCode
            // 
            LabelCode.AutoSize = true;
            LabelCode.Location = new System.Drawing.Point(8, 57);
            LabelCode.Name = "LabelCode";
            LabelCode.Size = new System.Drawing.Size(32, 13);
            LabelCode.TabIndex = 0;
            LabelCode.Text = "Code";
            // 
            // LabelCategory
            // 
            LabelCategory.AutoSize = true;
            LabelCategory.Location = new System.Drawing.Point(8, 127);
            LabelCategory.Name = "LabelCategory";
            LabelCategory.Size = new System.Drawing.Size(52, 13);
            LabelCategory.TabIndex = 0;
            LabelCategory.Text = "Category";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(8, 177);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(118, 13);
            label1.TabIndex = 37;
            label1.Text = "Res Date:             From";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(261, 176);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(47, 13);
            label2.TabIndex = 38;
            label2.Text = "Through";
            // 
            // LabelInactive
            // 
            LabelInactive.AutoSize = true;
            LabelInactive.Location = new System.Drawing.Point(53, 67);
            LabelInactive.Name = "LabelInactive";
            LabelInactive.Size = new System.Drawing.Size(50, 13);
            LabelInactive.TabIndex = 0;
            LabelInactive.Text = "Inactive:";
            // 
            // LabelSeverity
            // 
            LabelSeverity.AutoSize = true;
            LabelSeverity.Location = new System.Drawing.Point(54, 103);
            LabelSeverity.Name = "LabelSeverity";
            LabelSeverity.Size = new System.Drawing.Size(51, 13);
            LabelSeverity.TabIndex = 0;
            LabelSeverity.Text = "Severity:";
            // 
            // LabelConsent
            // 
            LabelConsent.AutoSize = true;
            LabelConsent.Location = new System.Drawing.Point(52, 147);
            LabelConsent.Name = "LabelConsent";
            LabelConsent.Size = new System.Drawing.Size(51, 13);
            LabelConsent.TabIndex = 0;
            LabelConsent.Text = "Consent:";
            // 
            // LabelImage4
            // 
            LabelImage4.AutoSize = true;
            LabelImage4.Location = new System.Drawing.Point(12, 25);
            LabelImage4.Name = "LabelImage4";
            LabelImage4.Size = new System.Drawing.Size(29, 13);
            LabelImage4.TabIndex = 0;
            LabelImage4.Text = "Path";
            // 
            // LabelImage3
            // 
            LabelImage3.AutoSize = true;
            LabelImage3.Location = new System.Drawing.Point(12, 25);
            LabelImage3.Name = "LabelImage3";
            LabelImage3.Size = new System.Drawing.Size(29, 13);
            LabelImage3.TabIndex = 0;
            LabelImage3.Text = "Path";
            // 
            // LabelImage2
            // 
            LabelImage2.AutoSize = true;
            LabelImage2.Location = new System.Drawing.Point(12, 25);
            LabelImage2.Name = "LabelImage2";
            LabelImage2.Size = new System.Drawing.Size(29, 13);
            LabelImage2.TabIndex = 0;
            LabelImage2.Text = "Path";
            // 
            // LabelImage1
            // 
            LabelImage1.AutoSize = true;
            LabelImage1.Location = new System.Drawing.Point(12, 25);
            LabelImage1.Name = "LabelImage1";
            LabelImage1.Size = new System.Drawing.Size(29, 13);
            LabelImage1.TabIndex = 0;
            LabelImage1.Text = "Path";
            // 
            // LabelCaption
            // 
            LabelCaption.AutoSize = true;
            LabelCaption.Location = new System.Drawing.Point(30, 16);
            LabelCaption.Name = "LabelCaption";
            LabelCaption.Size = new System.Drawing.Size(48, 13);
            LabelCaption.TabIndex = 0;
            LabelCaption.Text = "Caption:";
            // 
            // LabelTitle
            // 
            LabelTitle.AutoSize = true;
            LabelTitle.Location = new System.Drawing.Point(41, 16);
            LabelTitle.Name = "LabelTitle";
            LabelTitle.Size = new System.Drawing.Size(31, 13);
            LabelTitle.TabIndex = 0;
            LabelTitle.Text = "Title:";
            // 
            // LabelSubtitle
            // 
            LabelSubtitle.AutoSize = true;
            LabelSubtitle.Location = new System.Drawing.Point(22, 42);
            LabelSubtitle.Name = "LabelSubtitle";
            LabelSubtitle.Size = new System.Drawing.Size(47, 13);
            LabelSubtitle.TabIndex = 0;
            LabelSubtitle.Text = "Subtitle:";
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(FlexModel.MEDIAINFO);
            this.BindingSource.CurrentChanged += new System.EventHandler(this.MediaInfoBindingSource_CurrentChanged);
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // CheckEditInhouse
            // 
            this.CheckEditInhouse.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Inhouse", true));
            this.CheckEditInhouse.Location = new System.Drawing.Point(424, 151);
            this.CheckEditInhouse.Name = "CheckEditInhouse";
            this.CheckEditInhouse.Properties.Caption = "Display inhouse only";
            this.CheckEditInhouse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CheckEditInhouse.Size = new System.Drawing.Size(137, 19);
            this.CheckEditInhouse.TabIndex = 11;
            // 
            // xtraTabControlMediaInfo
            // 
            this.xtraTabControlMediaInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControlMediaInfo.Location = new System.Drawing.Point(11, 209);
            this.xtraTabControlMediaInfo.Margin = new System.Windows.Forms.Padding(0);
            this.xtraTabControlMediaInfo.Name = "xtraTabControlMediaInfo";
            this.xtraTabControlMediaInfo.SelectedTabPage = this.xtraTabPageText;
            this.xtraTabControlMediaInfo.Size = new System.Drawing.Size(669, 347);
            this.xtraTabControlMediaInfo.TabIndex = 33;
            this.xtraTabControlMediaInfo.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageText,
            this.xtraTabPagePrimaryImages,
            this.xtraTabPageAdditionalImages,
            this.xtraTabPageDisplay});
            this.xtraTabControlMediaInfo.TabStop = false;
            // 
            // xtraTabPageText
            // 
            this.xtraTabPageText.Controls.Add(this.panelControlText);
            this.xtraTabPageText.Margin = new System.Windows.Forms.Padding(4);
            this.xtraTabPageText.Name = "xtraTabPageText";
            this.xtraTabPageText.Size = new System.Drawing.Size(663, 319);
            this.xtraTabPageText.Text = "Text";
            // 
            // panelControlText
            // 
            this.panelControlText.Controls.Add(this.HtmlEditor);
            this.panelControlText.Controls.Add(this.TextEditTitle);
            this.panelControlText.Controls.Add(this.TextEditSubtitle);
            this.panelControlText.Controls.Add(LabelSubtitle);
            this.panelControlText.Controls.Add(LabelTitle);
            this.panelControlText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlText.Location = new System.Drawing.Point(0, 0);
            this.panelControlText.Name = "panelControlText";
            this.panelControlText.Size = new System.Drawing.Size(663, 319);
            this.panelControlText.TabIndex = 0;
            // 
            // HtmlEditor
            // 
            this.HtmlEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HtmlEditor.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.HtmlEditor.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.HtmlEditor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.HtmlEditor.BodyStyle = "FONT-FAMILY: Arial";
            // 
            // HtmlEditor.BtnAlignCenter
            // 
            this.HtmlEditor.BtnAlignCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnAlignCenter.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnAlignCenter.Image")));
            this.HtmlEditor.BtnAlignCenter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnAlignCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnAlignCenter.Name = "_factoryBtnAlignCenter";
            this.HtmlEditor.BtnAlignCenter.Size = new System.Drawing.Size(26, 26);
            this.HtmlEditor.BtnAlignCenter.Text = "Align Centre";
            // 
            // HtmlEditor.BtnAlignLeft
            // 
            this.HtmlEditor.BtnAlignLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnAlignLeft.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnAlignLeft.Image")));
            this.HtmlEditor.BtnAlignLeft.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnAlignLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnAlignLeft.Name = "_factoryBtnAlignLeft";
            this.HtmlEditor.BtnAlignLeft.Size = new System.Drawing.Size(26, 26);
            this.HtmlEditor.BtnAlignLeft.Text = "Align Left";
            // 
            // HtmlEditor.BtnAlignRight
            // 
            this.HtmlEditor.BtnAlignRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnAlignRight.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnAlignRight.Image")));
            this.HtmlEditor.BtnAlignRight.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnAlignRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnAlignRight.Name = "_factoryBtnAlignRight";
            this.HtmlEditor.BtnAlignRight.Size = new System.Drawing.Size(26, 26);
            this.HtmlEditor.BtnAlignRight.Text = "Align Right";
            // 
            // HtmlEditor.BtnBodyStyle
            // 
            this.HtmlEditor.BtnBodyStyle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnBodyStyle.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnBodyStyle.Image")));
            this.HtmlEditor.BtnBodyStyle.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnBodyStyle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnBodyStyle.Name = "_factoryBtnBodyStyle";
            this.HtmlEditor.BtnBodyStyle.Size = new System.Drawing.Size(27, 15);
            this.HtmlEditor.BtnBodyStyle.Text = "Document Style ";
            // 
            // HtmlEditor.BtnBold
            // 
            this.HtmlEditor.BtnBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnBold.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnBold.Image")));
            this.HtmlEditor.BtnBold.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnBold.Name = "_factoryBtnBold";
            this.HtmlEditor.BtnBold.Size = new System.Drawing.Size(23, 32);
            this.HtmlEditor.BtnBold.Text = "Bold";
            // 
            // HtmlEditor.BtnCopy
            // 
            this.HtmlEditor.BtnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnCopy.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnCopy.Image")));
            this.HtmlEditor.BtnCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnCopy.Name = "_factoryBtnCopy";
            this.HtmlEditor.BtnCopy.Size = new System.Drawing.Size(23, 32);
            this.HtmlEditor.BtnCopy.Text = "Copy";
            // 
            // HtmlEditor.BtnCut
            // 
            this.HtmlEditor.BtnCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnCut.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnCut.Image")));
            this.HtmlEditor.BtnCut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnCut.Name = "_factoryBtnCut";
            this.HtmlEditor.BtnCut.Size = new System.Drawing.Size(23, 32);
            this.HtmlEditor.BtnCut.Text = "Cut";
            // 
            // HtmlEditor.BtnFontColor
            // 
            this.HtmlEditor.BtnFontColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnFontColor.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnFontColor.Image")));
            this.HtmlEditor.BtnFontColor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnFontColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnFontColor.Name = "_factoryBtnFontColor";
            this.HtmlEditor.BtnFontColor.Size = new System.Drawing.Size(23, 26);
            this.HtmlEditor.BtnFontColor.Text = "Apply Font Color";
            // 
            // HtmlEditor.BtnFormatRedo
            // 
            this.HtmlEditor.BtnFormatRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnFormatRedo.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnFormatRedo.Image")));
            this.HtmlEditor.BtnFormatRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnFormatRedo.Name = "_factoryBtnRedo";
            this.HtmlEditor.BtnFormatRedo.Size = new System.Drawing.Size(32, 32);
            this.HtmlEditor.BtnFormatRedo.Text = "Redo";
            // 
            // HtmlEditor.BtnFormatReset
            // 
            this.HtmlEditor.BtnFormatReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnFormatReset.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnFormatReset.Image")));
            this.HtmlEditor.BtnFormatReset.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnFormatReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnFormatReset.Name = "_factoryBtnFormatReset";
            this.HtmlEditor.BtnFormatReset.Size = new System.Drawing.Size(34, 32);
            this.HtmlEditor.BtnFormatReset.Text = "Remove Format";
            // 
            // HtmlEditor.BtnFormatUndo
            // 
            this.HtmlEditor.BtnFormatUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnFormatUndo.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnFormatUndo.Image")));
            this.HtmlEditor.BtnFormatUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnFormatUndo.Name = "_factoryBtnUndo";
            this.HtmlEditor.BtnFormatUndo.Size = new System.Drawing.Size(32, 32);
            this.HtmlEditor.BtnFormatUndo.Text = "Undo";
            // 
            // HtmlEditor.BtnHighlightColor
            // 
            this.HtmlEditor.BtnHighlightColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnHighlightColor.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnHighlightColor.Image")));
            this.HtmlEditor.BtnHighlightColor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnHighlightColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnHighlightColor.Name = "_factoryBtnHighlightColor";
            this.HtmlEditor.BtnHighlightColor.Size = new System.Drawing.Size(27, 26);
            this.HtmlEditor.BtnHighlightColor.Text = "Apply Highlight Color";
            // 
            // HtmlEditor.BtnHorizontalRule
            // 
            this.HtmlEditor.BtnHorizontalRule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnHorizontalRule.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnHorizontalRule.Image")));
            this.HtmlEditor.BtnHorizontalRule.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnHorizontalRule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnHorizontalRule.Name = "_factoryBtnHorizontalRule";
            this.HtmlEditor.BtnHorizontalRule.Size = new System.Drawing.Size(24, 26);
            this.HtmlEditor.BtnHorizontalRule.Text = "Insert Horizontal Rule";
            // 
            // HtmlEditor.BtnHyperlink
            // 
            this.HtmlEditor.BtnHyperlink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnHyperlink.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnHyperlink.Image")));
            this.HtmlEditor.BtnHyperlink.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnHyperlink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnHyperlink.Name = "_factoryBtnHyperlink";
            this.HtmlEditor.BtnHyperlink.Size = new System.Drawing.Size(23, 26);
            this.HtmlEditor.BtnHyperlink.Text = "Hyperlink";
            // 
            // HtmlEditor.BtnImage
            // 
            this.HtmlEditor.BtnImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnImage.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnImage.Image")));
            this.HtmlEditor.BtnImage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnImage.Name = "_factoryBtnImage";
            this.HtmlEditor.BtnImage.Size = new System.Drawing.Size(23, 26);
            this.HtmlEditor.BtnImage.Text = "Image";
            // 
            // HtmlEditor.BtnIndent
            // 
            this.HtmlEditor.BtnIndent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnIndent.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnIndent.Image")));
            this.HtmlEditor.BtnIndent.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnIndent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnIndent.Name = "_factoryBtnIndent";
            this.HtmlEditor.BtnIndent.Size = new System.Drawing.Size(27, 26);
            this.HtmlEditor.BtnIndent.Text = "Indent";
            // 
            // HtmlEditor.BtnInsertYouTubeVideo
            // 
            this.HtmlEditor.BtnInsertYouTubeVideo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnInsertYouTubeVideo.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnInsertYouTubeVideo.Image")));
            this.HtmlEditor.BtnInsertYouTubeVideo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnInsertYouTubeVideo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnInsertYouTubeVideo.Name = "_factoryBtnInsertYouTubeVideo";
            this.HtmlEditor.BtnInsertYouTubeVideo.Size = new System.Drawing.Size(23, 26);
            this.HtmlEditor.BtnInsertYouTubeVideo.Text = "Insert YouTube Video";
            // 
            // HtmlEditor.BtnItalic
            // 
            this.HtmlEditor.BtnItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnItalic.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnItalic.Image")));
            this.HtmlEditor.BtnItalic.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnItalic.Name = "_factoryBtnItalic";
            this.HtmlEditor.BtnItalic.Size = new System.Drawing.Size(23, 32);
            this.HtmlEditor.BtnItalic.Text = "Italic";
            // 
            // HtmlEditor.BtnNew
            // 
            this.HtmlEditor.BtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnNew.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnNew.Image")));
            this.HtmlEditor.BtnNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnNew.Name = "_factoryBtnNew";
            this.HtmlEditor.BtnNew.Size = new System.Drawing.Size(23, 32);
            this.HtmlEditor.BtnNew.Text = "New";
            // 
            // HtmlEditor.BtnOpen
            // 
            this.HtmlEditor.BtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnOpen.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnOpen.Image")));
            this.HtmlEditor.BtnOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnOpen.Name = "_factoryBtnOpen";
            this.HtmlEditor.BtnOpen.Size = new System.Drawing.Size(23, 32);
            this.HtmlEditor.BtnOpen.Text = "Open";
            this.HtmlEditor.BtnOpen.Visible = false;
            // 
            // HtmlEditor.BtnOrderedList
            // 
            this.HtmlEditor.BtnOrderedList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnOrderedList.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnOrderedList.Image")));
            this.HtmlEditor.BtnOrderedList.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnOrderedList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnOrderedList.Name = "_factoryBtnOrderedList";
            this.HtmlEditor.BtnOrderedList.Size = new System.Drawing.Size(24, 26);
            this.HtmlEditor.BtnOrderedList.Text = "Numbered List";
            // 
            // HtmlEditor.BtnOutdent
            // 
            this.HtmlEditor.BtnOutdent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnOutdent.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnOutdent.Image")));
            this.HtmlEditor.BtnOutdent.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnOutdent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnOutdent.Name = "_factoryBtnOutdent";
            this.HtmlEditor.BtnOutdent.Size = new System.Drawing.Size(27, 26);
            this.HtmlEditor.BtnOutdent.Text = "Outdent";
            // 
            // HtmlEditor.BtnPaste
            // 
            this.HtmlEditor.BtnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnPaste.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnPaste.Image")));
            this.HtmlEditor.BtnPaste.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnPaste.Name = "_factoryBtnPaste";
            this.HtmlEditor.BtnPaste.Size = new System.Drawing.Size(23, 32);
            this.HtmlEditor.BtnPaste.Text = "Paste";
            // 
            // HtmlEditor.BtnPasteFromMSWord
            // 
            this.HtmlEditor.BtnPasteFromMSWord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnPasteFromMSWord.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnPasteFromMSWord.Image")));
            this.HtmlEditor.BtnPasteFromMSWord.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnPasteFromMSWord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnPasteFromMSWord.Name = "_factoryBtnPasteFromMSWord";
            this.HtmlEditor.BtnPasteFromMSWord.Size = new System.Drawing.Size(23, 32);
            this.HtmlEditor.BtnPasteFromMSWord.Text = "Paste the Content that you Copied from MS Word";
            // 
            // HtmlEditor.BtnPrint
            // 
            this.HtmlEditor.BtnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnPrint.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnPrint.Image")));
            this.HtmlEditor.BtnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnPrint.Name = "_factoryBtnPrint";
            this.HtmlEditor.BtnPrint.Size = new System.Drawing.Size(23, 32);
            this.HtmlEditor.BtnPrint.Text = "Print";
            // 
            // HtmlEditor.BtnSave
            // 
            this.HtmlEditor.BtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnSave.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnSave.Image")));
            this.HtmlEditor.BtnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnSave.Name = "_factoryBtnSave";
            this.HtmlEditor.BtnSave.Size = new System.Drawing.Size(23, 32);
            this.HtmlEditor.BtnSave.Text = "Save";
            this.HtmlEditor.BtnSave.Visible = false;
            // 
            // HtmlEditor.BtnSearch
            // 
            this.HtmlEditor.BtnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnSearch.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnSearch.Image")));
            this.HtmlEditor.BtnSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnSearch.Name = "_factoryBtnSearch";
            this.HtmlEditor.BtnSearch.Size = new System.Drawing.Size(24, 32);
            this.HtmlEditor.BtnSearch.Text = "Search";
            // 
            // HtmlEditor.BtnSpellCheck
            // 
            this.HtmlEditor.BtnSpellCheck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnSpellCheck.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnSpellCheck.Image")));
            this.HtmlEditor.BtnSpellCheck.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnSpellCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnSpellCheck.Name = "_factoryBtnSpellCheck";
            this.HtmlEditor.BtnSpellCheck.Size = new System.Drawing.Size(26, 32);
            this.HtmlEditor.BtnSpellCheck.Text = "Check Spelling";
            // 
            // HtmlEditor.BtnStrikeThrough
            // 
            this.HtmlEditor.BtnStrikeThrough.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnStrikeThrough.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnStrikeThrough.Image")));
            this.HtmlEditor.BtnStrikeThrough.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnStrikeThrough.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnStrikeThrough.Name = "_factoryBtnStrikeThrough";
            this.HtmlEditor.BtnStrikeThrough.Size = new System.Drawing.Size(24, 26);
            this.HtmlEditor.BtnStrikeThrough.Text = "Strike Thru";
            // 
            // HtmlEditor.BtnSubscript
            // 
            this.HtmlEditor.BtnSubscript.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnSubscript.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnSubscript.Image")));
            this.HtmlEditor.BtnSubscript.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnSubscript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnSubscript.Name = "_factoryBtnSubscript";
            this.HtmlEditor.BtnSubscript.Size = new System.Drawing.Size(27, 26);
            this.HtmlEditor.BtnSubscript.Text = "Subscript";
            // 
            // HtmlEditor.BtnSuperScript
            // 
            this.HtmlEditor.BtnSuperScript.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnSuperScript.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnSuperScript.Image")));
            this.HtmlEditor.BtnSuperScript.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnSuperScript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnSuperScript.Name = "_factoryBtnSuperScript";
            this.HtmlEditor.BtnSuperScript.Size = new System.Drawing.Size(27, 26);
            this.HtmlEditor.BtnSuperScript.Text = "Superscript";
            // 
            // HtmlEditor.BtnSymbol
            // 
            this.HtmlEditor.BtnSymbol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnSymbol.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnSymbol.Image")));
            this.HtmlEditor.BtnSymbol.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnSymbol.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnSymbol.Name = "_factoryBtnSymbol";
            this.HtmlEditor.BtnSymbol.Size = new System.Drawing.Size(23, 26);
            this.HtmlEditor.BtnSymbol.Text = "Insert Symbols";
            // 
            // HtmlEditor.BtnTable
            // 
            this.HtmlEditor.BtnTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnTable.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnTable.Image")));
            this.HtmlEditor.BtnTable.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnTable.Name = "_factoryBtnTable";
            this.HtmlEditor.BtnTable.Size = new System.Drawing.Size(24, 26);
            this.HtmlEditor.BtnTable.Text = "Table";
            // 
            // HtmlEditor.BtnUnderline
            // 
            this.HtmlEditor.BtnUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnUnderline.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnUnderline.Image")));
            this.HtmlEditor.BtnUnderline.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnUnderline.Name = "_factoryBtnUnderline";
            this.HtmlEditor.BtnUnderline.Size = new System.Drawing.Size(23, 32);
            this.HtmlEditor.BtnUnderline.Text = "Underline";
            // 
            // HtmlEditor.BtnUnOrderedList
            // 
            this.HtmlEditor.BtnUnOrderedList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HtmlEditor.BtnUnOrderedList.Image = ((System.Drawing.Image)(resources.GetObject("HtmlEditor.BtnUnOrderedList.Image")));
            this.HtmlEditor.BtnUnOrderedList.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HtmlEditor.BtnUnOrderedList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HtmlEditor.BtnUnOrderedList.Name = "_factoryBtnUnOrderedList";
            this.HtmlEditor.BtnUnOrderedList.Size = new System.Drawing.Size(24, 26);
            this.HtmlEditor.BtnUnOrderedList.Text = "Bullet List";
            // 
            // HtmlEditor.CmbFontName
            // 
            this.HtmlEditor.CmbFontName.AddSystemFonts = true;
            this.HtmlEditor.CmbFontName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.HtmlEditor.CmbFontName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.HtmlEditor.CmbFontName.MaxDropDownItems = 17;
            this.HtmlEditor.CmbFontName.Name = "_factoryCmbFontName";
            this.HtmlEditor.CmbFontName.Size = new System.Drawing.Size(114, 35);
            this.HtmlEditor.CmbFontName.Text = "Arial";
            // 
            // HtmlEditor.CmbFontSize
            // 
            this.HtmlEditor.CmbFontSize.Name = "_factoryCmbFontSize";
            this.HtmlEditor.CmbFontSize.Size = new System.Drawing.Size(114, 35);
            this.HtmlEditor.CmbFontSize.Text = "12pt";
            // 
            // HtmlEditor.CmbTitleInsert
            // 
            this.HtmlEditor.CmbTitleInsert.Name = "_factoryCmbTitleInsert";
            this.HtmlEditor.CmbTitleInsert.Size = new System.Drawing.Size(151, 29);
            this.HtmlEditor.DefaultFontFamily = "Arial";
            this.HtmlEditor.DocumentHtml = resources.GetString("HtmlEditor.DocumentHtml");
            this.HtmlEditor.EditorContextMenuStrip = null;
            this.HtmlEditor.HeaderStyleContentElementID = "page_style";
            this.HtmlEditor.HorizontalScroll = null;
            this.HtmlEditor.Location = new System.Drawing.Point(25, 74);
            this.HtmlEditor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.HtmlEditor.Name = "HtmlEditor";
            this.HtmlEditor.Options.ConvertFileUrlsToLocalPaths = true;
            this.HtmlEditor.Options.CustomDOCTYPE = null;
            this.HtmlEditor.Options.FooterTagNavigatorFont = null;
            this.HtmlEditor.Options.FooterTagNavigatorTextColor = System.Drawing.Color.Teal;
            this.HtmlEditor.Options.FTPSettingsForRemoteResources.ConnectionMode = SpiceLogic.HtmlEditorControl.Domain.BOs.UserOptions.FTPSettings.ConnectionModes.Active;
            this.HtmlEditor.Options.FTPSettingsForRemoteResources.Host = null;
            this.HtmlEditor.Options.FTPSettingsForRemoteResources.Password = null;
            this.HtmlEditor.Options.FTPSettingsForRemoteResources.Port = null;
            this.HtmlEditor.Options.FTPSettingsForRemoteResources.RemoteFolderPath = null;
            this.HtmlEditor.Options.FTPSettingsForRemoteResources.Timeout = 4000;
            this.HtmlEditor.Options.FTPSettingsForRemoteResources.UrlOfTheRemoteFolderPath = null;
            this.HtmlEditor.Options.FTPSettingsForRemoteResources.UserName = null;
            this.HtmlEditor.Size = new System.Drawing.Size(618, 232);
            this.HtmlEditor.SpellCheckOptions.CurlyUnderlineImageFilePath = null;
            dictionaryFileInfo1.AffixFilePath = null;
            dictionaryFileInfo1.DictionaryFilePath = null;
            dictionaryFileInfo1.EnableUserDictionary = true;
            dictionaryFileInfo1.UserDictionaryFilePath = null;
            this.HtmlEditor.SpellCheckOptions.DictionaryFile = dictionaryFileInfo1;
            this.HtmlEditor.SpellCheckOptions.FireInlineSpellCheckingOnKeyStroke = true;
            this.HtmlEditor.SpellCheckOptions.NHunspellDllFolderPath = null;
            this.HtmlEditor.SpellCheckOptions.WaitAlertMessage = "Searching next misspelled word..... (please wait)";
            this.HtmlEditor.TabIndex = 15;
            // 
            // HtmlEditor.TlstrpSeparator1
            // 
            this.HtmlEditor.TlstrpSeparator1.Name = "_toolStripSeparator1";
            this.HtmlEditor.TlstrpSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // HtmlEditor.TlstrpSeparator2
            // 
            this.HtmlEditor.TlstrpSeparator2.Name = "_toolStripSeparator2";
            this.HtmlEditor.TlstrpSeparator2.Size = new System.Drawing.Size(6, 35);
            // 
            // HtmlEditor.TlstrpSeparator3
            // 
            this.HtmlEditor.TlstrpSeparator3.Name = "_toolStripSeparator3";
            this.HtmlEditor.TlstrpSeparator3.Size = new System.Drawing.Size(6, 35);
            // 
            // HtmlEditor.TlstrpSeparator4
            // 
            this.HtmlEditor.TlstrpSeparator4.Name = "_toolStripSeparator4";
            this.HtmlEditor.TlstrpSeparator4.Size = new System.Drawing.Size(6, 35);
            // 
            // HtmlEditor.TlstrpSeparator5
            // 
            this.HtmlEditor.TlstrpSeparator5.Name = "_toolStripSeparator5";
            this.HtmlEditor.TlstrpSeparator5.Size = new System.Drawing.Size(6, 29);
            // 
            // HtmlEditor.TlstrpSeparator6
            // 
            this.HtmlEditor.TlstrpSeparator6.Name = "_toolStripSeparator6";
            this.HtmlEditor.TlstrpSeparator6.Size = new System.Drawing.Size(6, 29);
            // 
            // HtmlEditor.TlstrpSeparator7
            // 
            this.HtmlEditor.TlstrpSeparator7.Name = "_toolStripSeparator7";
            this.HtmlEditor.TlstrpSeparator7.Size = new System.Drawing.Size(6, 29);
            // 
            // HtmlEditor.TlstrpSeparator8
            // 
            this.HtmlEditor.TlstrpSeparator8.Name = "_toolStripSeparator8";
            this.HtmlEditor.TlstrpSeparator8.Size = new System.Drawing.Size(6, 29);
            // 
            // HtmlEditor.TlstrpSeparator9
            // 
            this.HtmlEditor.TlstrpSeparator9.Name = "_toolStripSeparator9";
            this.HtmlEditor.TlstrpSeparator9.Size = new System.Drawing.Size(6, 29);
            // 
            // HtmlEditor.WinFormHtmlEditor_Toolbar1
            // 
            this.HtmlEditor.Toolbar1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.HtmlEditor.Toolbar1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.HtmlEditor.Toolbar1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HtmlEditor.BtnNew,
            this.HtmlEditor.BtnOpen,
            this.HtmlEditor.BtnSave,
            this.HtmlEditor.TlstrpSeparator1,
            this.HtmlEditor.CmbFontName,
            this.HtmlEditor.CmbFontSize,
            this.HtmlEditor.TlstrpSeparator2,
            this.HtmlEditor.BtnCut,
            this.HtmlEditor.BtnCopy,
            this.HtmlEditor.BtnPaste,
            this.HtmlEditor.BtnPasteFromMSWord,
            this.HtmlEditor.TlstrpSeparator3,
            this.HtmlEditor.BtnBold,
            this.HtmlEditor.BtnItalic,
            this.HtmlEditor.BtnUnderline,
            this.HtmlEditor.TlstrpSeparator4,
            this.HtmlEditor.BtnFormatReset,
            this.HtmlEditor.BtnFormatUndo,
            this.HtmlEditor.BtnFormatRedo,
            this.HtmlEditor.BtnPrint,
            this.HtmlEditor.BtnSpellCheck,
            this.HtmlEditor.BtnSearch});
            this.HtmlEditor.Toolbar1.Location = new System.Drawing.Point(0, 0);
            this.HtmlEditor.Toolbar1.Name = "WinFormHtmlEditor_Toolbar1";
            this.HtmlEditor.Toolbar1.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.HtmlEditor.Toolbar1.Size = new System.Drawing.Size(618, 35);
            this.HtmlEditor.Toolbar1.TabIndex = 0;
            // 
            // HtmlEditor.WinFormHtmlEditor_Toolbar2
            // 
            this.HtmlEditor.Toolbar2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.HtmlEditor.Toolbar2.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.HtmlEditor.Toolbar2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HtmlEditor.CmbTitleInsert,
            this.HtmlEditor.BtnHighlightColor,
            this.HtmlEditor.BtnFontColor,
            this.HtmlEditor.TlstrpSeparator5,
            this.HtmlEditor.BtnHyperlink,
            this.HtmlEditor.BtnImage,
            this.HtmlEditor.BtnInsertYouTubeVideo,
            this.HtmlEditor.BtnTable,
            this.HtmlEditor.BtnSymbol,
            this.HtmlEditor.BtnHorizontalRule,
            this.HtmlEditor.TlstrpSeparator6,
            this.HtmlEditor.BtnOrderedList,
            this.HtmlEditor.BtnUnOrderedList,
            this.HtmlEditor.TlstrpSeparator7,
            this.HtmlEditor.BtnAlignLeft,
            this.HtmlEditor.BtnAlignCenter,
            this.HtmlEditor.BtnAlignRight,
            this.HtmlEditor.TlstrpSeparator8,
            this.HtmlEditor.BtnOutdent,
            this.HtmlEditor.BtnIndent,
            this.HtmlEditor.TlstrpSeparator9,
            this.HtmlEditor.BtnStrikeThrough,
            this.HtmlEditor.BtnSuperScript,
            this.HtmlEditor.BtnSubscript,
            this.HtmlEditor.BtnBodyStyle});
            this.HtmlEditor.Toolbar2.Location = new System.Drawing.Point(0, 35);
            this.HtmlEditor.Toolbar2.Name = "WinFormHtmlEditor_Toolbar2";
            this.HtmlEditor.Toolbar2.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.HtmlEditor.Toolbar2.Size = new System.Drawing.Size(618, 29);
            this.HtmlEditor.Toolbar2.TabIndex = 0;
            this.HtmlEditor.ToolbarContextMenuStrip = null;
            // 
            // HtmlEditor.WinFormHtmlEditor_ToolbarFooter
            // 
            this.HtmlEditor.ToolbarFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.HtmlEditor.ToolbarFooter.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.HtmlEditor.ToolbarFooter.Location = new System.Drawing.Point(0, 197);
            this.HtmlEditor.ToolbarFooter.Name = "WinFormHtmlEditor_ToolbarFooter";
            this.HtmlEditor.ToolbarFooter.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.HtmlEditor.ToolbarFooter.Size = new System.Drawing.Size(618, 35);
            this.HtmlEditor.ToolbarFooter.TabIndex = 7;
            this.HtmlEditor.VerticalScroll = null;
            this.HtmlEditor.z__ignore = true;
            // 
            // TextEditTitle
            // 
            this.TextEditTitle.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "TITLE", true));
            this.TextEditTitle.Location = new System.Drawing.Point(85, 13);
            this.TextEditTitle.Name = "TextEditTitle";
            this.TextEditTitle.Properties.Tag = "";
            this.TextEditTitle.Size = new System.Drawing.Size(518, 20);
            this.TextEditTitle.TabIndex = 12;
            this.TextEditTitle.Leave += new System.EventHandler(this.TextEditTitle_Leave);
            // 
            // TextEditSubtitle
            // 
            this.TextEditSubtitle.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "SUBTITLE", true));
            this.TextEditSubtitle.Location = new System.Drawing.Point(85, 39);
            this.TextEditSubtitle.Name = "TextEditSubtitle";
            this.TextEditSubtitle.Properties.Tag = "";
            this.TextEditSubtitle.Size = new System.Drawing.Size(518, 20);
            this.TextEditSubtitle.TabIndex = 13;
            this.TextEditSubtitle.Leave += new System.EventHandler(this.TextEditSubtitle_Leave);
            // 
            // xtraTabPagePrimaryImages
            // 
            this.xtraTabPagePrimaryImages.AutoScroll = true;
            this.xtraTabPagePrimaryImages.Controls.Add(this.panelControlPrimaryImages);
            this.xtraTabPagePrimaryImages.Margin = new System.Windows.Forms.Padding(4);
            this.xtraTabPagePrimaryImages.Name = "xtraTabPagePrimaryImages";
            this.xtraTabPagePrimaryImages.Size = new System.Drawing.Size(663, 319);
            this.xtraTabPagePrimaryImages.Text = "Primary Images";
            // 
            // panelControlPrimaryImages
            // 
            this.panelControlPrimaryImages.Controls.Add(LabelCaption);
            this.panelControlPrimaryImages.Controls.Add(this.TextEditCaption);
            this.panelControlPrimaryImages.Controls.Add(this.xtraTabControlPictures);
            this.panelControlPrimaryImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlPrimaryImages.Location = new System.Drawing.Point(0, 0);
            this.panelControlPrimaryImages.Name = "panelControlPrimaryImages";
            this.panelControlPrimaryImages.Size = new System.Drawing.Size(663, 319);
            this.panelControlPrimaryImages.TabIndex = 0;
            // 
            // TextEditCaption
            // 
            this.TextEditCaption.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CAPTION", true));
            this.TextEditCaption.EnterMoveNextControl = true;
            this.TextEditCaption.Location = new System.Drawing.Point(92, 14);
            this.TextEditCaption.Name = "TextEditCaption";
            this.TextEditCaption.Properties.Tag = "";
            this.TextEditCaption.Size = new System.Drawing.Size(533, 20);
            this.TextEditCaption.TabIndex = 15;
            this.TextEditCaption.Leave += new System.EventHandler(this.TextEditCaption_Leave);
            // 
            // xtraTabControlPictures
            // 
            this.xtraTabControlPictures.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.xtraTabControlPictures.Location = new System.Drawing.Point(33, 40);
            this.xtraTabControlPictures.Name = "xtraTabControlPictures";
            this.xtraTabControlPictures.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControlPictures.Size = new System.Drawing.Size(613, 274);
            this.xtraTabControlPictures.TabIndex = 2;
            this.xtraTabControlPictures.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage5,
            this.xtraTabPage6,
            this.xtraTabPage7});
            this.xtraTabControlPictures.TabStop = false;
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.panelControlLowRes);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(607, 246);
            this.xtraTabPage1.Text = "Low Res";
            // 
            // panelControlLowRes
            // 
            this.panelControlLowRes.Controls.Add(this.azureBlobBrowser1LowRes);
            this.panelControlLowRes.Controls.Add(this.PictureEditPreviewImage1LowRes);
            this.panelControlLowRes.Controls.Add(this.labelControlSizeDisplay1LowRes);
            this.panelControlLowRes.Controls.Add(this.labelControlSize);
            this.panelControlLowRes.Controls.Add(LabelImage1);
            this.panelControlLowRes.Controls.Add(this.ButtonEditImage1LowRes);
            this.panelControlLowRes.Controls.Add(this.ButtonCreateThumbnailLowRes);
            this.panelControlLowRes.Controls.Add(this.LabelPeview);
            this.panelControlLowRes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlLowRes.Location = new System.Drawing.Point(0, 0);
            this.panelControlLowRes.Name = "panelControlLowRes";
            this.panelControlLowRes.Size = new System.Drawing.Size(607, 246);
            this.panelControlLowRes.TabIndex = 0;
            // 
            // azureBlobBrowser1LowRes
            // 
            this.azureBlobBrowser1LowRes.BlobContainer = null;
            this.azureBlobBrowser1LowRes.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "IMAGE1", true));
            this.azureBlobBrowser1LowRes.Location = new System.Drawing.Point(67, 50);
            this.azureBlobBrowser1LowRes.Margin = new System.Windows.Forms.Padding(2);
            this.azureBlobBrowser1LowRes.MenuManager = this.BarManager;
            this.azureBlobBrowser1LowRes.Name = "azureBlobBrowser1LowRes";
            this.azureBlobBrowser1LowRes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.azureBlobBrowser1LowRes.Size = new System.Drawing.Size(524, 20);
            this.azureBlobBrowser1LowRes.TabIndex = 17;
            this.azureBlobBrowser1LowRes.Visible = false;
            this.azureBlobBrowser1LowRes.EditValueChanged += new System.EventHandler(this.azureBlobBrowser1LowRes_EditValueChanged);
            // 
            // BarManager
            // 
            this.BarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barTools,
            this.bar3});
            this.BarManager.DockControls.Add(this.barDockControlTop);
            this.BarManager.DockControls.Add(this.barDockControlBottom);
            this.BarManager.DockControls.Add(this.barDockControlLeft);
            this.BarManager.DockControls.Add(this.barDockControlRight);
            this.BarManager.Form = this;
            this.BarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.BarButtonItemNew,
            this.BarButtonItemDelete,
            this.BarButtonItemSave,
            this.BarButtonItemClone,
            this.BarButtonItemExpand,
            this.BarSubItemReports,
            this.barButtonItemReportsContainingSection,
            this.barButtonItemAddToReports,
            this.barButtonItemRemoveFromReports,
            this.barButtonItemCreateNewReports});
            this.BarManager.MaxItemId = 10;
            this.BarManager.StatusBar = this.bar3;
            // 
            // barTools
            // 
            this.barTools.BarName = "Tools";
            this.barTools.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.barTools.DockCol = 0;
            this.barTools.DockRow = 0;
            this.barTools.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BarButtonItemNew, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonItemDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonItemSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonItemClone),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonItemExpand),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarSubItemReports)});
            this.barTools.OptionsBar.AllowQuickCustomization = false;
            this.barTools.OptionsBar.DrawDragBorder = false;
            this.barTools.OptionsBar.UseWholeRow = true;
            this.barTools.Text = "Tools";
            // 
            // BarButtonItemNew
            // 
            this.BarButtonItemNew.Caption = "Add";
            this.BarButtonItemNew.Id = 0;
            this.BarButtonItemNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BarButtonItemNew.ImageOptions.Image")));
            this.BarButtonItemNew.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BarButtonItemNew.ImageOptions.LargeImage")));
            this.BarButtonItemNew.Name = "BarButtonItemNew";
            this.BarButtonItemNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemNew_ItemClick);
            // 
            // BarButtonItemDelete
            // 
            this.BarButtonItemDelete.Caption = "Delete";
            this.BarButtonItemDelete.Id = 1;
            this.BarButtonItemDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BarButtonItemDelete.ImageOptions.Image")));
            this.BarButtonItemDelete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BarButtonItemDelete.ImageOptions.LargeImage")));
            this.BarButtonItemDelete.Name = "BarButtonItemDelete";
            this.BarButtonItemDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemDelete_ItemClick);
            // 
            // BarButtonItemSave
            // 
            this.BarButtonItemSave.Caption = "Save";
            this.BarButtonItemSave.Id = 2;
            this.BarButtonItemSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BarButtonItemSave.ImageOptions.Image")));
            this.BarButtonItemSave.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BarButtonItemSave.ImageOptions.LargeImage")));
            this.BarButtonItemSave.Name = "BarButtonItemSave";
            this.BarButtonItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemSave_ItemClick);
            // 
            // BarButtonItemClone
            // 
            this.BarButtonItemClone.Caption = "Clone";
            this.BarButtonItemClone.Id = 3;
            this.BarButtonItemClone.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BarButtonItemClone.ImageOptions.Image")));
            this.BarButtonItemClone.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BarButtonItemClone.ImageOptions.LargeImage")));
            this.BarButtonItemClone.Name = "BarButtonItemClone";
            this.BarButtonItemClone.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemClone_ItemClick);
            // 
            // BarButtonItemExpand
            // 
            this.BarButtonItemExpand.Caption = "Expand";
            this.BarButtonItemExpand.Id = 4;
            this.BarButtonItemExpand.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BarButtonItemExpand.ImageOptions.Image")));
            this.BarButtonItemExpand.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BarButtonItemExpand.ImageOptions.LargeImage")));
            this.BarButtonItemExpand.Name = "BarButtonItemExpand";
            this.BarButtonItemExpand.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemExpand_ItemClick);
            // 
            // BarSubItemReports
            // 
            this.BarSubItemReports.Caption = "Reports";
            this.BarSubItemReports.Id = 5;
            this.BarSubItemReports.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemReportsContainingSection),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemAddToReports),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemRemoveFromReports),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemCreateNewReports)});
            this.BarSubItemReports.Name = "BarSubItemReports";
            // 
            // barButtonItemReportsContainingSection
            // 
            this.barButtonItemReportsContainingSection.Caption = "Reports containing this section";
            this.barButtonItemReportsContainingSection.Id = 6;
            this.barButtonItemReportsContainingSection.Name = "barButtonItemReportsContainingSection";
            this.barButtonItemReportsContainingSection.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemReportsContainingSection_ItemClick);
            // 
            // barButtonItemAddToReports
            // 
            this.barButtonItemAddToReports.Caption = "Add to reports";
            this.barButtonItemAddToReports.Id = 7;
            this.barButtonItemAddToReports.Name = "barButtonItemAddToReports";
            this.barButtonItemAddToReports.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemAddToReports_ItemClick);
            // 
            // barButtonItemRemoveFromReports
            // 
            this.barButtonItemRemoveFromReports.Caption = "Remove from reports";
            this.barButtonItemRemoveFromReports.Id = 8;
            this.barButtonItemRemoveFromReports.Name = "barButtonItemRemoveFromReports";
            this.barButtonItemRemoveFromReports.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemRemoveFromReports_ItemClick);
            // 
            // barButtonItemCreateNewReports
            // 
            this.barButtonItemCreateNewReports.Caption = "Create new reports";
            this.barButtonItemCreateNewReports.Id = 9;
            this.barButtonItemCreateNewReports.Name = "barButtonItemCreateNewReports";
            this.barButtonItemCreateNewReports.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemCreateNewReports_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.BarManager;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.barDockControlTop.Size = new System.Drawing.Size(953, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 609);
            this.barDockControlBottom.Manager = this.BarManager;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.barDockControlBottom.Size = new System.Drawing.Size(953, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Manager = this.BarManager;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 578);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(953, 31);
            this.barDockControlRight.Manager = this.BarManager;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 578);
            // 
            // PictureEditPreviewImage1LowRes
            // 
            this.PictureEditPreviewImage1LowRes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureEditPreviewImage1LowRes.Cursor = System.Windows.Forms.Cursors.Default;
            this.PictureEditPreviewImage1LowRes.Location = new System.Drawing.Point(67, 85);
            this.PictureEditPreviewImage1LowRes.Name = "PictureEditPreviewImage1LowRes";
            this.PictureEditPreviewImage1LowRes.Size = new System.Drawing.Size(233, 155);
            this.PictureEditPreviewImage1LowRes.TabIndex = 2;
            this.PictureEditPreviewImage1LowRes.LoadCompleted += new System.EventHandler(this.PictureEditPreviewImage1LowRes_LoadCompleted);
            // 
            // labelControlSizeDisplay1LowRes
            // 
            this.labelControlSizeDisplay1LowRes.Location = new System.Drawing.Point(71, 57);
            this.labelControlSizeDisplay1LowRes.Name = "labelControlSizeDisplay1LowRes";
            this.labelControlSizeDisplay1LowRes.Size = new System.Drawing.Size(0, 13);
            this.labelControlSizeDisplay1LowRes.TabIndex = 7;
            // 
            // labelControlSize
            // 
            this.labelControlSize.Location = new System.Drawing.Point(13, 57);
            this.labelControlSize.Name = "labelControlSize";
            this.labelControlSize.Size = new System.Drawing.Size(19, 13);
            this.labelControlSize.TabIndex = 0;
            this.labelControlSize.Text = "Size";
            // 
            // ButtonEditImage1LowRes
            // 
            this.ButtonEditImage1LowRes.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "IMAGE1", true));
            this.ButtonEditImage1LowRes.EnterMoveNextControl = true;
            this.ButtonEditImage1LowRes.Location = new System.Drawing.Point(67, 22);
            this.ButtonEditImage1LowRes.Name = "ButtonEditImage1LowRes";
            this.ButtonEditImage1LowRes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ButtonEditImage1LowRes.Properties.Tag = "";
            this.ButtonEditImage1LowRes.Properties.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonEditImage1LowRes_ButtonPressed);
            this.ButtonEditImage1LowRes.Size = new System.Drawing.Size(524, 20);
            this.ButtonEditImage1LowRes.TabIndex = 16;
            this.ButtonEditImage1LowRes.TextChanged += new System.EventHandler(this.ButtonEditImage1LowRes_TextChanged);
            this.ButtonEditImage1LowRes.Leave += new System.EventHandler(this.ButtonEditImage1LowRes_Leave);
            // 
            // ButtonCreateThumbnailLowRes
            // 
            this.ButtonCreateThumbnailLowRes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCreateThumbnailLowRes.Location = new System.Drawing.Point(306, 85);
            this.ButtonCreateThumbnailLowRes.Name = "ButtonCreateThumbnailLowRes";
            this.ButtonCreateThumbnailLowRes.Size = new System.Drawing.Size(114, 37);
            this.ButtonCreateThumbnailLowRes.TabIndex = 4;
            this.ButtonCreateThumbnailLowRes.TabStop = false;
            this.ButtonCreateThumbnailLowRes.Text = "Create Thumbnail";
            this.ButtonCreateThumbnailLowRes.Click += new System.EventHandler(this.ButtonCreateThumbnailLowRes_Click);
            // 
            // LabelPeview
            // 
            this.LabelPeview.Location = new System.Drawing.Point(13, 85);
            this.LabelPeview.Name = "LabelPeview";
            this.LabelPeview.Size = new System.Drawing.Size(42, 13);
            this.LabelPeview.TabIndex = 0;
            this.LabelPeview.Text = "Preview:";
            // 
            // xtraTabPage5
            // 
            this.xtraTabPage5.Controls.Add(this.panelControlMedRes);
            this.xtraTabPage5.Name = "xtraTabPage5";
            this.xtraTabPage5.Size = new System.Drawing.Size(607, 246);
            this.xtraTabPage5.Text = "Medium Res";
            // 
            // panelControlMedRes
            // 
            this.panelControlMedRes.Controls.Add(this.azureBlobBrowser2MedRes);
            this.panelControlMedRes.Controls.Add(this.labelControlSizeDisplay2MedRes);
            this.panelControlMedRes.Controls.Add(this.labelControlSize2);
            this.panelControlMedRes.Controls.Add(LabelImage2);
            this.panelControlMedRes.Controls.Add(this.ButtonEditImage2MedRes);
            this.panelControlMedRes.Controls.Add(this.labelControlPreview2);
            this.panelControlMedRes.Controls.Add(this.ButtonCreateThumbnailMedRes);
            this.panelControlMedRes.Controls.Add(this.PictureEditPreviewImage2MedRes);
            this.panelControlMedRes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlMedRes.Location = new System.Drawing.Point(0, 0);
            this.panelControlMedRes.Name = "panelControlMedRes";
            this.panelControlMedRes.Size = new System.Drawing.Size(607, 246);
            this.panelControlMedRes.TabIndex = 0;
            // 
            // azureBlobBrowser2MedRes
            // 
            this.azureBlobBrowser2MedRes.BlobContainer = null;
            this.azureBlobBrowser2MedRes.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "IMAGE2", true));
            this.azureBlobBrowser2MedRes.Location = new System.Drawing.Point(67, 50);
            this.azureBlobBrowser2MedRes.Margin = new System.Windows.Forms.Padding(2);
            this.azureBlobBrowser2MedRes.MenuManager = this.BarManager;
            this.azureBlobBrowser2MedRes.Name = "azureBlobBrowser2MedRes";
            this.azureBlobBrowser2MedRes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.azureBlobBrowser2MedRes.Size = new System.Drawing.Size(524, 20);
            this.azureBlobBrowser2MedRes.TabIndex = 18;
            this.azureBlobBrowser2MedRes.Visible = false;
            this.azureBlobBrowser2MedRes.EditValueChanged += new System.EventHandler(this.azureBlobBrowser2MedRes_EditValueChanged);
            // 
            // labelControlSizeDisplay2MedRes
            // 
            this.labelControlSizeDisplay2MedRes.Location = new System.Drawing.Point(73, 55);
            this.labelControlSizeDisplay2MedRes.Name = "labelControlSizeDisplay2MedRes";
            this.labelControlSizeDisplay2MedRes.Size = new System.Drawing.Size(0, 13);
            this.labelControlSizeDisplay2MedRes.TabIndex = 9;
            // 
            // labelControlSize2
            // 
            this.labelControlSize2.Location = new System.Drawing.Point(13, 57);
            this.labelControlSize2.Name = "labelControlSize2";
            this.labelControlSize2.Size = new System.Drawing.Size(19, 13);
            this.labelControlSize2.TabIndex = 0;
            this.labelControlSize2.Text = "Size";
            // 
            // ButtonEditImage2MedRes
            // 
            this.ButtonEditImage2MedRes.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "IMAGE2", true));
            this.ButtonEditImage2MedRes.EnterMoveNextControl = true;
            this.ButtonEditImage2MedRes.Location = new System.Drawing.Point(67, 22);
            this.ButtonEditImage2MedRes.Name = "ButtonEditImage2MedRes";
            this.ButtonEditImage2MedRes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ButtonEditImage2MedRes.Properties.Tag = "";
            this.ButtonEditImage2MedRes.Properties.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonEditImage2MedRes_ButtonPressed);
            this.ButtonEditImage2MedRes.Size = new System.Drawing.Size(524, 20);
            this.ButtonEditImage2MedRes.TabIndex = 17;
            this.ButtonEditImage2MedRes.TextChanged += new System.EventHandler(this.ButtonEditImage2MedRes_TextChanged);
            this.ButtonEditImage2MedRes.Leave += new System.EventHandler(this.ButtonEditImage2MidRes_Leave);
            // 
            // labelControlPreview2
            // 
            this.labelControlPreview2.Location = new System.Drawing.Point(13, 85);
            this.labelControlPreview2.Name = "labelControlPreview2";
            this.labelControlPreview2.Size = new System.Drawing.Size(42, 13);
            this.labelControlPreview2.TabIndex = 0;
            this.labelControlPreview2.Text = "Preview:";
            // 
            // ButtonCreateThumbnailMedRes
            // 
            this.ButtonCreateThumbnailMedRes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCreateThumbnailMedRes.Location = new System.Drawing.Point(306, 85);
            this.ButtonCreateThumbnailMedRes.Name = "ButtonCreateThumbnailMedRes";
            this.ButtonCreateThumbnailMedRes.Size = new System.Drawing.Size(114, 37);
            this.ButtonCreateThumbnailMedRes.TabIndex = 5;
            this.ButtonCreateThumbnailMedRes.TabStop = false;
            this.ButtonCreateThumbnailMedRes.Text = "Create Thumbnail";
            this.ButtonCreateThumbnailMedRes.Click += new System.EventHandler(this.ButtonCreateThumbnailMedRes_Click);
            // 
            // PictureEditPreviewImage2MedRes
            // 
            this.PictureEditPreviewImage2MedRes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureEditPreviewImage2MedRes.Cursor = System.Windows.Forms.Cursors.Default;
            this.PictureEditPreviewImage2MedRes.Location = new System.Drawing.Point(67, 85);
            this.PictureEditPreviewImage2MedRes.Name = "PictureEditPreviewImage2MedRes";
            this.PictureEditPreviewImage2MedRes.Size = new System.Drawing.Size(233, 156);
            this.PictureEditPreviewImage2MedRes.TabIndex = 3;
            this.PictureEditPreviewImage2MedRes.LoadCompleted += new System.EventHandler(this.PictureEditPreviewImage2MedRes_LoadCompleted);
            // 
            // xtraTabPage6
            // 
            this.xtraTabPage6.Controls.Add(this.panelControlHighRes);
            this.xtraTabPage6.Name = "xtraTabPage6";
            this.xtraTabPage6.Size = new System.Drawing.Size(607, 246);
            this.xtraTabPage6.Text = "High Res";
            // 
            // panelControlHighRes
            // 
            this.panelControlHighRes.Controls.Add(this.azureBlobBrowser3HighRes);
            this.panelControlHighRes.Controls.Add(this.labelControlSizeDisplay3HighRes);
            this.panelControlHighRes.Controls.Add(this.labelControlSize3);
            this.panelControlHighRes.Controls.Add(LabelImage3);
            this.panelControlHighRes.Controls.Add(this.ButtonEditImage3HighRes);
            this.panelControlHighRes.Controls.Add(this.ButtonCreateThumbNailHighRes);
            this.panelControlHighRes.Controls.Add(this.LabelPreview3);
            this.panelControlHighRes.Controls.Add(this.PictureEditPreviewImage3HighRes);
            this.panelControlHighRes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlHighRes.Location = new System.Drawing.Point(0, 0);
            this.panelControlHighRes.Name = "panelControlHighRes";
            this.panelControlHighRes.Size = new System.Drawing.Size(607, 246);
            this.panelControlHighRes.TabIndex = 0;
            // 
            // azureBlobBrowser3HighRes
            // 
            this.azureBlobBrowser3HighRes.BlobContainer = null;
            this.azureBlobBrowser3HighRes.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "IMAGE3", true));
            this.azureBlobBrowser3HighRes.Location = new System.Drawing.Point(67, 47);
            this.azureBlobBrowser3HighRes.Margin = new System.Windows.Forms.Padding(2);
            this.azureBlobBrowser3HighRes.MenuManager = this.BarManager;
            this.azureBlobBrowser3HighRes.Name = "azureBlobBrowser3HighRes";
            this.azureBlobBrowser3HighRes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.azureBlobBrowser3HighRes.Size = new System.Drawing.Size(524, 20);
            this.azureBlobBrowser3HighRes.TabIndex = 19;
            this.azureBlobBrowser3HighRes.Visible = false;
            this.azureBlobBrowser3HighRes.EditValueChanged += new System.EventHandler(this.azureBlobBrowser3HighRes_EditValueChanged);
            // 
            // labelControlSizeDisplay3HighRes
            // 
            this.labelControlSizeDisplay3HighRes.Location = new System.Drawing.Point(73, 56);
            this.labelControlSizeDisplay3HighRes.Name = "labelControlSizeDisplay3HighRes";
            this.labelControlSizeDisplay3HighRes.Size = new System.Drawing.Size(0, 13);
            this.labelControlSizeDisplay3HighRes.TabIndex = 9;
            // 
            // labelControlSize3
            // 
            this.labelControlSize3.Location = new System.Drawing.Point(13, 57);
            this.labelControlSize3.Name = "labelControlSize3";
            this.labelControlSize3.Size = new System.Drawing.Size(19, 13);
            this.labelControlSize3.TabIndex = 0;
            this.labelControlSize3.Text = "Size";
            // 
            // ButtonEditImage3HighRes
            // 
            this.ButtonEditImage3HighRes.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "IMAGE3", true));
            this.ButtonEditImage3HighRes.EnterMoveNextControl = true;
            this.ButtonEditImage3HighRes.Location = new System.Drawing.Point(67, 22);
            this.ButtonEditImage3HighRes.Name = "ButtonEditImage3HighRes";
            this.ButtonEditImage3HighRes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ButtonEditImage3HighRes.Properties.Tag = "";
            this.ButtonEditImage3HighRes.Properties.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonEditImage3HighRes_ButtonPressed);
            this.ButtonEditImage3HighRes.Size = new System.Drawing.Size(524, 20);
            this.ButtonEditImage3HighRes.TabIndex = 18;
            this.ButtonEditImage3HighRes.TextChanged += new System.EventHandler(this.ButtonEditImage3HighRes_TextChanged);
            this.ButtonEditImage3HighRes.Leave += new System.EventHandler(this.ButtonEditImage3HighRes_Leave);
            // 
            // ButtonCreateThumbNailHighRes
            // 
            this.ButtonCreateThumbNailHighRes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCreateThumbNailHighRes.Location = new System.Drawing.Point(306, 85);
            this.ButtonCreateThumbNailHighRes.Name = "ButtonCreateThumbNailHighRes";
            this.ButtonCreateThumbNailHighRes.Size = new System.Drawing.Size(114, 37);
            this.ButtonCreateThumbNailHighRes.TabIndex = 6;
            this.ButtonCreateThumbNailHighRes.TabStop = false;
            this.ButtonCreateThumbNailHighRes.Text = "Create Thumbnail";
            this.ButtonCreateThumbNailHighRes.Click += new System.EventHandler(this.ButtonCreateThumbNailHighRes_Click);
            // 
            // LabelPreview3
            // 
            this.LabelPreview3.Location = new System.Drawing.Point(13, 85);
            this.LabelPreview3.Name = "LabelPreview3";
            this.LabelPreview3.Size = new System.Drawing.Size(42, 13);
            this.LabelPreview3.TabIndex = 0;
            this.LabelPreview3.Text = "Preview:";
            // 
            // PictureEditPreviewImage3HighRes
            // 
            this.PictureEditPreviewImage3HighRes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureEditPreviewImage3HighRes.Cursor = System.Windows.Forms.Cursors.Default;
            this.PictureEditPreviewImage3HighRes.Location = new System.Drawing.Point(67, 85);
            this.PictureEditPreviewImage3HighRes.Name = "PictureEditPreviewImage3HighRes";
            this.PictureEditPreviewImage3HighRes.Size = new System.Drawing.Size(233, 156);
            this.PictureEditPreviewImage3HighRes.TabIndex = 3;
            this.PictureEditPreviewImage3HighRes.LoadCompleted += new System.EventHandler(this.PictureEditPreviewImage3HighRes_LoadCompleted);
            // 
            // xtraTabPage7
            // 
            this.xtraTabPage7.Controls.Add(this.panelControlThumbNail);
            this.xtraTabPage7.Name = "xtraTabPage7";
            this.xtraTabPage7.Size = new System.Drawing.Size(607, 246);
            this.xtraTabPage7.Text = "Thumbnail";
            // 
            // panelControlThumbNail
            // 
            this.panelControlThumbNail.Controls.Add(this.azureBlobBrowser4Thumb);
            this.panelControlThumbNail.Controls.Add(this.labelControlSizeDisplay4Thumb);
            this.panelControlThumbNail.Controls.Add(this.labelControlSize4);
            this.panelControlThumbNail.Controls.Add(LabelImage4);
            this.panelControlThumbNail.Controls.Add(this.ButtonEditImage4Thumb);
            this.panelControlThumbNail.Controls.Add(this.LabelPreview4);
            this.panelControlThumbNail.Controls.Add(this.PictureEditPreviewImage4Thumb);
            this.panelControlThumbNail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlThumbNail.Location = new System.Drawing.Point(0, 0);
            this.panelControlThumbNail.Name = "panelControlThumbNail";
            this.panelControlThumbNail.Size = new System.Drawing.Size(607, 246);
            this.panelControlThumbNail.TabIndex = 0;
            // 
            // azureBlobBrowser4Thumb
            // 
            this.azureBlobBrowser4Thumb.BlobContainer = null;
            this.azureBlobBrowser4Thumb.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "IMAGE4", true));
            this.azureBlobBrowser4Thumb.Location = new System.Drawing.Point(67, 50);
            this.azureBlobBrowser4Thumb.Margin = new System.Windows.Forms.Padding(2);
            this.azureBlobBrowser4Thumb.MenuManager = this.BarManager;
            this.azureBlobBrowser4Thumb.Name = "azureBlobBrowser4Thumb";
            this.azureBlobBrowser4Thumb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.azureBlobBrowser4Thumb.Size = new System.Drawing.Size(524, 20);
            this.azureBlobBrowser4Thumb.TabIndex = 20;
            this.azureBlobBrowser4Thumb.Visible = false;
            this.azureBlobBrowser4Thumb.EditValueChanged += new System.EventHandler(this.azureBlobBrowser4Thumb_EditValueChanged);
            // 
            // labelControlSizeDisplay4Thumb
            // 
            this.labelControlSizeDisplay4Thumb.Location = new System.Drawing.Point(67, 57);
            this.labelControlSizeDisplay4Thumb.Name = "labelControlSizeDisplay4Thumb";
            this.labelControlSizeDisplay4Thumb.Size = new System.Drawing.Size(0, 13);
            this.labelControlSizeDisplay4Thumb.TabIndex = 9;
            // 
            // labelControlSize4
            // 
            this.labelControlSize4.Location = new System.Drawing.Point(13, 57);
            this.labelControlSize4.Name = "labelControlSize4";
            this.labelControlSize4.Size = new System.Drawing.Size(19, 13);
            this.labelControlSize4.TabIndex = 0;
            this.labelControlSize4.Text = "Size";
            // 
            // ButtonEditImage4Thumb
            // 
            this.ButtonEditImage4Thumb.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "IMAGE4", true));
            this.ButtonEditImage4Thumb.EnterMoveNextControl = true;
            this.ButtonEditImage4Thumb.Location = new System.Drawing.Point(67, 22);
            this.ButtonEditImage4Thumb.Name = "ButtonEditImage4Thumb";
            this.ButtonEditImage4Thumb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ButtonEditImage4Thumb.Properties.Tag = "";
            this.ButtonEditImage4Thumb.Properties.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonEditImage4ThmNail_ButtonPressed);
            this.ButtonEditImage4Thumb.Size = new System.Drawing.Size(524, 20);
            this.ButtonEditImage4Thumb.TabIndex = 19;
            this.ButtonEditImage4Thumb.TextChanged += new System.EventHandler(this.ButtonEditImage4ThmNail_TextChanged);
            this.ButtonEditImage4Thumb.Leave += new System.EventHandler(this.ButtonEditImage4ThmNail_Leave);
            // 
            // LabelPreview4
            // 
            this.LabelPreview4.Location = new System.Drawing.Point(13, 85);
            this.LabelPreview4.Name = "LabelPreview4";
            this.LabelPreview4.Size = new System.Drawing.Size(42, 13);
            this.LabelPreview4.TabIndex = 0;
            this.LabelPreview4.Text = "Preview:";
            // 
            // PictureEditPreviewImage4Thumb
            // 
            this.PictureEditPreviewImage4Thumb.Cursor = System.Windows.Forms.Cursors.Default;
            this.PictureEditPreviewImage4Thumb.Location = new System.Drawing.Point(67, 85);
            this.PictureEditPreviewImage4Thumb.Name = "PictureEditPreviewImage4Thumb";
            this.PictureEditPreviewImage4Thumb.Size = new System.Drawing.Size(128, 128);
            this.PictureEditPreviewImage4Thumb.TabIndex = 3;
            this.PictureEditPreviewImage4Thumb.LoadCompleted += new System.EventHandler(this.PictureEditPreviewImage4Thumb_LoadCompleted);
            // 
            // xtraTabPageAdditionalImages
            // 
            this.xtraTabPageAdditionalImages.Controls.Add(this.panelControl3);
            this.xtraTabPageAdditionalImages.Margin = new System.Windows.Forms.Padding(4);
            this.xtraTabPageAdditionalImages.Name = "xtraTabPageAdditionalImages";
            this.xtraTabPageAdditionalImages.Size = new System.Drawing.Size(663, 319);
            this.xtraTabPageAdditionalImages.Text = "Additional Images";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.GridControlAdditionalImages);
            this.panelControl3.Controls.Add(this.ButtonDelRow);
            this.panelControl3.Controls.Add(this.ButtonAddRow);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(663, 319);
            this.panelControl3.TabIndex = 0;
            // 
            // GridControlAdditionalImages
            // 
            this.GridControlAdditionalImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridControlAdditionalImages.CausesValidation = false;
            this.GridControlAdditionalImages.DataSource = this.BindingSourceResource;
            this.GridControlAdditionalImages.Location = new System.Drawing.Point(13, 8);
            this.GridControlAdditionalImages.MainView = this.GridViewAdditionalImages;
            this.GridControlAdditionalImages.Name = "GridControlAdditionalImages";
            this.GridControlAdditionalImages.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit_Item,
            this.repositoryItemImageComboBoxTag,
            this.repositoryItemPopupContainerEditPreview,
            this.repositoryItemComboBoxImagePurpose,
            this.repositoryItemAzureBlobBrowser});
            this.GridControlAdditionalImages.Size = new System.Drawing.Size(639, 248);
            this.GridControlAdditionalImages.TabIndex = 19;
            this.GridControlAdditionalImages.TabStop = false;
            this.GridControlAdditionalImages.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewAdditionalImages,
            this.gridView1});
            // 
            // BindingSourceResource
            // 
            this.BindingSourceResource.DataSource = typeof(FlexModel.RESOURCE);
            // 
            // GridViewAdditionalImages
            // 
            this.GridViewAdditionalImages.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColumnID1,
            this.ColumnLinkTable,
            this.ColumnLinkValue,
            this.ColumnRecType,
            this.ColumnTag,
            this.ColumnItem,
            this.ColumnDesc,
            this.ColumnUserDec1,
            this.ColumnUserDec2,
            this.ColumnUserInt1,
            this.ColumnUserInt2,
            this.ColumnUserTxt1,
            this.ColumnUserTxt2,
            this.ColumnUserTxt3,
            this.ColumnUserTxt4,
            this.ColumnUserDte1,
            this.ColumnUserDte2,
            this.gridColumnPreview});
            this.GridViewAdditionalImages.DetailHeight = 182;
            this.GridViewAdditionalImages.FixedLineWidth = 1;
            this.GridViewAdditionalImages.GridControl = this.GridControlAdditionalImages;
            this.GridViewAdditionalImages.Name = "GridViewAdditionalImages";
            this.GridViewAdditionalImages.OptionsView.ShowGroupPanel = false;
            this.GridViewAdditionalImages.OptionsView.ShowIndicator = false;
            this.GridViewAdditionalImages.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.GridViewAdditionalImages_CustomRowCellEdit);
            this.GridViewAdditionalImages.ShownEditor += new System.EventHandler(this.GridViewAdditionalImages_ShownEditor);
            this.GridViewAdditionalImages.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.GridViewAdditionalImages_CellValueChanged);
            // 
            // ColumnID1
            // 
            this.ColumnID1.FieldName = "ID";
            this.ColumnID1.MinWidth = 10;
            this.ColumnID1.Name = "ColumnID1";
            this.ColumnID1.Width = 37;
            // 
            // ColumnLinkTable
            // 
            this.ColumnLinkTable.FieldName = "LINK_TABLE";
            this.ColumnLinkTable.MinWidth = 10;
            this.ColumnLinkTable.Name = "ColumnLinkTable";
            this.ColumnLinkTable.Width = 37;
            // 
            // ColumnLinkValue
            // 
            this.ColumnLinkValue.FieldName = "LINK_VALUE";
            this.ColumnLinkValue.MinWidth = 10;
            this.ColumnLinkValue.Name = "ColumnLinkValue";
            this.ColumnLinkValue.Width = 37;
            // 
            // ColumnRecType
            // 
            this.ColumnRecType.FieldName = "RECTYPE";
            this.ColumnRecType.MinWidth = 10;
            this.ColumnRecType.Name = "ColumnRecType";
            this.ColumnRecType.Width = 37;
            // 
            // ColumnTag
            // 
            this.ColumnTag.Caption = "Resolution";
            this.ColumnTag.ColumnEdit = this.repositoryItemImageComboBoxTag;
            this.ColumnTag.FieldName = "TAG";
            this.ColumnTag.MinWidth = 10;
            this.ColumnTag.Name = "ColumnTag";
            this.ColumnTag.OptionsColumn.FixedWidth = true;
            this.ColumnTag.Visible = true;
            this.ColumnTag.VisibleIndex = 4;
            this.ColumnTag.Width = 50;
            // 
            // repositoryItemImageComboBoxTag
            // 
            this.repositoryItemImageComboBoxTag.AutoHeight = false;
            this.repositoryItemImageComboBoxTag.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBoxTag.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Low", "0", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Medium", "1", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("High", "2", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Thumb", "3", -1)});
            this.repositoryItemImageComboBoxTag.Name = "repositoryItemImageComboBoxTag";
            // 
            // ColumnItem
            // 
            this.ColumnItem.Caption = "File";
            this.ColumnItem.ColumnEdit = this.repositoryItemAzureBlobBrowser;
            this.ColumnItem.FieldName = "ITEM";
            this.ColumnItem.MinWidth = 10;
            this.ColumnItem.Name = "ColumnItem";
            this.ColumnItem.Visible = true;
            this.ColumnItem.VisibleIndex = 1;
            this.ColumnItem.Width = 215;
            // 
            // repositoryItemAzureBlobBrowser
            // 
            this.repositoryItemAzureBlobBrowser.AutoHeight = false;
            this.repositoryItemAzureBlobBrowser.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemAzureBlobBrowser.Name = "repositoryItemAzureBlobBrowser";
            // 
            // ColumnDesc
            // 
            this.ColumnDesc.Caption = "Caption";
            this.ColumnDesc.FieldName = "DESCRIPTION";
            this.ColumnDesc.MinWidth = 10;
            this.ColumnDesc.Name = "ColumnDesc";
            this.ColumnDesc.Visible = true;
            this.ColumnDesc.VisibleIndex = 2;
            this.ColumnDesc.Width = 341;
            // 
            // ColumnUserDec1
            // 
            this.ColumnUserDec1.FieldName = "USER_DEC1";
            this.ColumnUserDec1.MinWidth = 10;
            this.ColumnUserDec1.Name = "ColumnUserDec1";
            this.ColumnUserDec1.Width = 37;
            // 
            // ColumnUserDec2
            // 
            this.ColumnUserDec2.FieldName = "USER_DEC2";
            this.ColumnUserDec2.MinWidth = 10;
            this.ColumnUserDec2.Name = "ColumnUserDec2";
            this.ColumnUserDec2.Width = 37;
            // 
            // ColumnUserInt1
            // 
            this.ColumnUserInt1.FieldName = "USER_INT1";
            this.ColumnUserInt1.MinWidth = 10;
            this.ColumnUserInt1.Name = "ColumnUserInt1";
            this.ColumnUserInt1.Width = 37;
            // 
            // ColumnUserInt2
            // 
            this.ColumnUserInt2.FieldName = "USER_INT2";
            this.ColumnUserInt2.MinWidth = 10;
            this.ColumnUserInt2.Name = "ColumnUserInt2";
            this.ColumnUserInt2.Width = 37;
            // 
            // ColumnUserTxt1
            // 
            this.ColumnUserTxt1.Caption = "Purpose";
            this.ColumnUserTxt1.ColumnEdit = this.repositoryItemComboBoxImagePurpose;
            this.ColumnUserTxt1.FieldName = "USER_TXT1";
            this.ColumnUserTxt1.MinWidth = 10;
            this.ColumnUserTxt1.Name = "ColumnUserTxt1";
            this.ColumnUserTxt1.Visible = true;
            this.ColumnUserTxt1.VisibleIndex = 3;
            this.ColumnUserTxt1.Width = 173;
            // 
            // repositoryItemComboBoxImagePurpose
            // 
            this.repositoryItemComboBoxImagePurpose.AutoHeight = false;
            this.repositoryItemComboBoxImagePurpose.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBoxImagePurpose.Items.AddRange(new object[] {
            "",
            "SEATMAP"});
            this.repositoryItemComboBoxImagePurpose.Name = "repositoryItemComboBoxImagePurpose";
            // 
            // ColumnUserTxt2
            // 
            this.ColumnUserTxt2.FieldName = "USER_TXT2";
            this.ColumnUserTxt2.MinWidth = 10;
            this.ColumnUserTxt2.Name = "ColumnUserTxt2";
            this.ColumnUserTxt2.Width = 37;
            // 
            // ColumnUserTxt3
            // 
            this.ColumnUserTxt3.FieldName = "USER_TXT3";
            this.ColumnUserTxt3.MinWidth = 10;
            this.ColumnUserTxt3.Name = "ColumnUserTxt3";
            this.ColumnUserTxt3.Width = 37;
            // 
            // ColumnUserTxt4
            // 
            this.ColumnUserTxt4.FieldName = "USER_TXT4";
            this.ColumnUserTxt4.MinWidth = 10;
            this.ColumnUserTxt4.Name = "ColumnUserTxt4";
            this.ColumnUserTxt4.Width = 37;
            // 
            // ColumnUserDte1
            // 
            this.ColumnUserDte1.FieldName = "USER_DTE1";
            this.ColumnUserDte1.MinWidth = 10;
            this.ColumnUserDte1.Name = "ColumnUserDte1";
            this.ColumnUserDte1.Width = 37;
            // 
            // ColumnUserDte2
            // 
            this.ColumnUserDte2.FieldName = "USER_DTE2";
            this.ColumnUserDte2.MinWidth = 10;
            this.ColumnUserDte2.Name = "ColumnUserDte2";
            this.ColumnUserDte2.Width = 37;
            // 
            // gridColumnPreview
            // 
            this.gridColumnPreview.Caption = "Preview";
            this.gridColumnPreview.ColumnEdit = this.repositoryItemPopupContainerEditPreview;
            this.gridColumnPreview.MinWidth = 10;
            this.gridColumnPreview.Name = "gridColumnPreview";
            this.gridColumnPreview.OptionsColumn.FixedWidth = true;
            this.gridColumnPreview.Visible = true;
            this.gridColumnPreview.VisibleIndex = 0;
            this.gridColumnPreview.Width = 23;
            // 
            // repositoryItemPopupContainerEditPreview
            // 
            this.repositoryItemPopupContainerEditPreview.AutoHeight = false;
            this.repositoryItemPopupContainerEditPreview.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "Preview", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryItemPopupContainerEditPreview.Name = "repositoryItemPopupContainerEditPreview";
            this.repositoryItemPopupContainerEditPreview.PopupControl = this.popupContainerControlPreview;
            this.repositoryItemPopupContainerEditPreview.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemPopupContainerEditPreview.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.RepositoryItemPopupContainerEditPreview_ButtonClick);
            // 
            // popupContainerControlPreview
            // 
            this.popupContainerControlPreview.Controls.Add(this.pictureEditPreviewAddImg);
            this.popupContainerControlPreview.Location = new System.Drawing.Point(1263, 851);
            this.popupContainerControlPreview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.popupContainerControlPreview.Name = "popupContainerControlPreview";
            this.popupContainerControlPreview.Size = new System.Drawing.Size(497, 386);
            this.popupContainerControlPreview.TabIndex = 0;
            // 
            // pictureEditPreviewAddImg
            // 
            this.pictureEditPreviewAddImg.Location = new System.Drawing.Point(53, 35);
            this.pictureEditPreviewAddImg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureEditPreviewAddImg.Name = "pictureEditPreviewAddImg";
            this.pictureEditPreviewAddImg.Size = new System.Drawing.Size(391, 307);
            this.pictureEditPreviewAddImg.TabIndex = 3;
            // 
            // repositoryItemButtonEdit_Item
            // 
            this.repositoryItemButtonEdit_Item.AutoHeight = false;
            this.repositoryItemButtonEdit_Item.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit_Item.Name = "repositoryItemButtonEdit_Item";
            this.repositoryItemButtonEdit_Item.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.RepositoryItemButtonEdit_Item_ButtonClick);
            // 
            // gridView1
            // 
            this.gridView1.DetailHeight = 182;
            this.gridView1.FixedLineWidth = 1;
            this.gridView1.GridControl = this.GridControlAdditionalImages;
            this.gridView1.Name = "gridView1";
            // 
            // ButtonDelRow
            // 
            this.ButtonDelRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonDelRow.ImageOptions.Image = global::TraceForms.Properties.Resources.document_delete2;
            this.ButtonDelRow.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ButtonDelRow.Location = new System.Drawing.Point(71, 263);
            this.ButtonDelRow.Name = "ButtonDelRow";
            this.ButtonDelRow.Size = new System.Drawing.Size(34, 36);
            this.ButtonDelRow.TabIndex = 2;
            this.ButtonDelRow.TabStop = false;
            this.ButtonDelRow.Text = "simpleButton4";
            this.ButtonDelRow.Click += new System.EventHandler(this.ButtonDelRow_Click);
            // 
            // ButtonAddRow
            // 
            this.ButtonAddRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonAddRow.ImageOptions.Image = global::TraceForms.Properties.Resources.document_new;
            this.ButtonAddRow.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ButtonAddRow.Location = new System.Drawing.Point(29, 263);
            this.ButtonAddRow.Name = "ButtonAddRow";
            this.ButtonAddRow.Size = new System.Drawing.Size(36, 36);
            this.ButtonAddRow.TabIndex = 1;
            this.ButtonAddRow.TabStop = false;
            this.ButtonAddRow.Text = "simpleButton3";
            this.ButtonAddRow.Click += new System.EventHandler(this.ButtonAddRow_Click);
            // 
            // xtraTabPageDisplay
            // 
            this.xtraTabPageDisplay.Controls.Add(this.panelControlDisplay);
            this.xtraTabPageDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.xtraTabPageDisplay.Name = "xtraTabPageDisplay";
            this.xtraTabPageDisplay.Size = new System.Drawing.Size(663, 319);
            this.xtraTabPageDisplay.Text = "Display";
            // 
            // panelControlDisplay
            // 
            this.panelControlDisplay.Controls.Add(this.ImageComboBoxEditSeverity);
            this.panelControlDisplay.Controls.Add(LabelConsent);
            this.panelControlDisplay.Controls.Add(this.CheckEditConsent);
            this.panelControlDisplay.Controls.Add(LabelSeverity);
            this.panelControlDisplay.Controls.Add(this.CheckEditInactive);
            this.panelControlDisplay.Controls.Add(LabelInactive);
            this.panelControlDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlDisplay.Location = new System.Drawing.Point(0, 0);
            this.panelControlDisplay.Name = "panelControlDisplay";
            this.panelControlDisplay.Size = new System.Drawing.Size(663, 319);
            this.panelControlDisplay.TabIndex = 0;
            // 
            // ImageComboBoxEditSeverity
            // 
            this.ImageComboBoxEditSeverity.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Severity", true));
            this.ImageComboBoxEditSeverity.EnterMoveNextControl = true;
            this.ImageComboBoxEditSeverity.Location = new System.Drawing.Point(111, 100);
            this.ImageComboBoxEditSeverity.Name = "ImageComboBoxEditSeverity";
            this.ImageComboBoxEditSeverity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ImageComboBoxEditSeverity.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("0 - Informational", ((short)(0)), -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("1 - Warning", ((short)(1)), -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2 - Additional Fees", ((short)(2)), -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("3 - Critical Service Disruption", ((short)(3)), -1)});
            this.ImageComboBoxEditSeverity.Size = new System.Drawing.Size(182, 20);
            this.ImageComboBoxEditSeverity.TabIndex = 21;
            this.ImageComboBoxEditSeverity.Leave += new System.EventHandler(this.ImageComboBoxEditSeverity_Leave);
            // 
            // CheckEditConsent
            // 
            this.CheckEditConsent.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Consent", true));
            this.CheckEditConsent.EnterMoveNextControl = true;
            this.CheckEditConsent.Location = new System.Drawing.Point(109, 144);
            this.CheckEditConsent.Name = "CheckEditConsent";
            this.CheckEditConsent.Properties.Caption = "";
            this.CheckEditConsent.Size = new System.Drawing.Size(20, 19);
            this.CheckEditConsent.TabIndex = 22;
            // 
            // CheckEditInactive
            // 
            this.CheckEditInactive.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Inactive", true));
            this.CheckEditInactive.EnterMoveNextControl = true;
            this.CheckEditInactive.Location = new System.Drawing.Point(109, 64);
            this.CheckEditInactive.Name = "CheckEditInactive";
            this.CheckEditInactive.Properties.Caption = "";
            this.CheckEditInactive.Size = new System.Drawing.Size(20, 19);
            this.CheckEditInactive.TabIndex = 20;
            // 
            // GridControlLookup
            // 
            this.GridControlLookup.DataSource = this.EntityInstantFeedbackSource;
            this.GridControlLookup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControlLookup.Location = new System.Drawing.Point(0, 0);
            this.GridControlLookup.MainView = this.GridViewLookup;
            this.GridControlLookup.Name = "GridControlLookup";
            this.GridControlLookup.Size = new System.Drawing.Size(251, 578);
            this.GridControlLookup.TabIndex = 32;
            this.GridControlLookup.TabStop = false;
            this.GridControlLookup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewLookup});
            // 
            // EntityInstantFeedbackSource
            // 
            this.EntityInstantFeedbackSource.DesignTimeElementType = typeof(FlexModel.MEDIAINFO);
            this.EntityInstantFeedbackSource.KeyExpression = "ID";
            this.EntityInstantFeedbackSource.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.EntityInstantFeedbackSource_GetQueryable);
            this.EntityInstantFeedbackSource.DismissQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(this.EntityInstantFeedbackSource_DismissQueryable);
            // 
            // GridViewLookup
            // 
            this.GridViewLookup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColumnID,
            this.ColumnLang,
            this.ColumnType,
            this.ColumnCode,
            this.ColumnCategory,
            this.ColumnRoom,
            this.ColumnSection,
            this.ColumnTitle,
            this.ColumnSubtitle,
            this.ColumnText,
            this.ColumnCaption,
            this.ColumnImage1,
            this.ColumnImage2,
            this.ColumnImage3,
            this.ColumnInactive,
            this.ColumnSvcDateStart,
            this.ColumnSvcDateEnd,
            this.ColumnAgency,
            this.ColumnInhouse,
            this.ColumnChgDate,
            this.ColumnImage4,
            this.ColumnSeverity,
            this.ColumnConsent,
            this.ColumnMediaRptItems});
            this.GridViewLookup.DetailHeight = 182;
            this.GridViewLookup.FixedLineWidth = 1;
            this.GridViewLookup.GridControl = this.GridControlLookup;
            this.GridViewLookup.Name = "GridViewLookup";
            this.GridViewLookup.OptionsBehavior.Editable = false;
            this.GridViewLookup.OptionsView.ShowAutoFilterRow = true;
            this.GridViewLookup.OptionsView.ShowGroupPanel = false;
            this.GridViewLookup.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewLookup_FocusedRowChanged);
            this.GridViewLookup.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.GridViewLookup_BeforeLeaveRow);
            // 
            // ColumnID
            // 
            this.ColumnID.FieldName = "ID";
            this.ColumnID.MinWidth = 10;
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.Width = 37;
            // 
            // ColumnLang
            // 
            this.ColumnLang.Caption = "Language";
            this.ColumnLang.FieldName = "LANG";
            this.ColumnLang.MinWidth = 10;
            this.ColumnLang.Name = "ColumnLang";
            this.ColumnLang.Visible = true;
            this.ColumnLang.VisibleIndex = 1;
            this.ColumnLang.Width = 35;
            // 
            // ColumnType
            // 
            this.ColumnType.Caption = "Type";
            this.ColumnType.FieldName = "TYPE";
            this.ColumnType.MinWidth = 10;
            this.ColumnType.Name = "ColumnType";
            this.ColumnType.Visible = true;
            this.ColumnType.VisibleIndex = 0;
            this.ColumnType.Width = 23;
            // 
            // ColumnCode
            // 
            this.ColumnCode.Caption = "Code";
            this.ColumnCode.FieldName = "CODE";
            this.ColumnCode.MinWidth = 10;
            this.ColumnCode.Name = "ColumnCode";
            this.ColumnCode.Visible = true;
            this.ColumnCode.VisibleIndex = 2;
            this.ColumnCode.Width = 37;
            // 
            // ColumnCategory
            // 
            this.ColumnCategory.Caption = "Category";
            this.ColumnCategory.FieldName = "CAT";
            this.ColumnCategory.MinWidth = 10;
            this.ColumnCategory.Name = "ColumnCategory";
            this.ColumnCategory.Width = 37;
            // 
            // ColumnRoom
            // 
            this.ColumnRoom.FieldName = "ROOM";
            this.ColumnRoom.MinWidth = 10;
            this.ColumnRoom.Name = "ColumnRoom";
            this.ColumnRoom.Width = 37;
            // 
            // ColumnSection
            // 
            this.ColumnSection.Caption = "Section";
            this.ColumnSection.FieldName = "SECTION";
            this.ColumnSection.MinWidth = 10;
            this.ColumnSection.Name = "ColumnSection";
            this.ColumnSection.Visible = true;
            this.ColumnSection.VisibleIndex = 3;
            this.ColumnSection.Width = 50;
            // 
            // ColumnTitle
            // 
            this.ColumnTitle.FieldName = "TITLE";
            this.ColumnTitle.MinWidth = 10;
            this.ColumnTitle.Name = "ColumnTitle";
            this.ColumnTitle.Width = 37;
            // 
            // ColumnSubtitle
            // 
            this.ColumnSubtitle.FieldName = "SUBTITLE";
            this.ColumnSubtitle.MinWidth = 10;
            this.ColumnSubtitle.Name = "ColumnSubtitle";
            this.ColumnSubtitle.Width = 37;
            // 
            // ColumnText
            // 
            this.ColumnText.FieldName = "TEXT";
            this.ColumnText.MinWidth = 10;
            this.ColumnText.Name = "ColumnText";
            this.ColumnText.Width = 37;
            // 
            // ColumnCaption
            // 
            this.ColumnCaption.FieldName = "CAPTION";
            this.ColumnCaption.MinWidth = 10;
            this.ColumnCaption.Name = "ColumnCaption";
            this.ColumnCaption.Width = 37;
            // 
            // ColumnImage1
            // 
            this.ColumnImage1.FieldName = "IMAGE1";
            this.ColumnImage1.MinWidth = 10;
            this.ColumnImage1.Name = "ColumnImage1";
            this.ColumnImage1.Width = 37;
            // 
            // ColumnImage2
            // 
            this.ColumnImage2.FieldName = "IMAGE2";
            this.ColumnImage2.MinWidth = 10;
            this.ColumnImage2.Name = "ColumnImage2";
            this.ColumnImage2.Width = 37;
            // 
            // ColumnImage3
            // 
            this.ColumnImage3.FieldName = "IMAGE3";
            this.ColumnImage3.MinWidth = 10;
            this.ColumnImage3.Name = "ColumnImage3";
            this.ColumnImage3.Width = 37;
            // 
            // ColumnInactive
            // 
            this.ColumnInactive.FieldName = "Inactive";
            this.ColumnInactive.MinWidth = 10;
            this.ColumnInactive.Name = "ColumnInactive";
            this.ColumnInactive.Width = 37;
            // 
            // ColumnSvcDateStart
            // 
            this.ColumnSvcDateStart.FieldName = "SvcDate_Start";
            this.ColumnSvcDateStart.MinWidth = 10;
            this.ColumnSvcDateStart.Name = "ColumnSvcDateStart";
            this.ColumnSvcDateStart.Width = 37;
            // 
            // ColumnSvcDateEnd
            // 
            this.ColumnSvcDateEnd.FieldName = "SvcDate_End";
            this.ColumnSvcDateEnd.MinWidth = 10;
            this.ColumnSvcDateEnd.Name = "ColumnSvcDateEnd";
            this.ColumnSvcDateEnd.Width = 37;
            // 
            // ColumnAgency
            // 
            this.ColumnAgency.FieldName = "Agency";
            this.ColumnAgency.MinWidth = 10;
            this.ColumnAgency.Name = "ColumnAgency";
            this.ColumnAgency.Width = 37;
            // 
            // ColumnInhouse
            // 
            this.ColumnInhouse.FieldName = "Inhouse";
            this.ColumnInhouse.MinWidth = 10;
            this.ColumnInhouse.Name = "ColumnInhouse";
            this.ColumnInhouse.Width = 37;
            // 
            // ColumnChgDate
            // 
            this.ColumnChgDate.FieldName = "ChgDate";
            this.ColumnChgDate.MinWidth = 10;
            this.ColumnChgDate.Name = "ColumnChgDate";
            this.ColumnChgDate.Width = 37;
            // 
            // ColumnImage4
            // 
            this.ColumnImage4.FieldName = "IMAGE4";
            this.ColumnImage4.MinWidth = 10;
            this.ColumnImage4.Name = "ColumnImage4";
            this.ColumnImage4.Width = 37;
            // 
            // ColumnSeverity
            // 
            this.ColumnSeverity.FieldName = "Severity";
            this.ColumnSeverity.MinWidth = 10;
            this.ColumnSeverity.Name = "ColumnSeverity";
            this.ColumnSeverity.Width = 37;
            // 
            // ColumnConsent
            // 
            this.ColumnConsent.FieldName = "Consent";
            this.ColumnConsent.MinWidth = 10;
            this.ColumnConsent.Name = "ColumnConsent";
            this.ColumnConsent.Width = 37;
            // 
            // ColumnMediaRptItems
            // 
            this.ColumnMediaRptItems.FieldName = "MediaRptItems";
            this.ColumnMediaRptItems.MinWidth = 10;
            this.ColumnMediaRptItems.Name = "ColumnMediaRptItems";
            this.ColumnMediaRptItems.Width = 37;
            // 
            // ComboBoxEditType
            // 
            this.ComboBoxEditType.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "TYPE", true));
            this.ComboBoxEditType.EditValue = "";
            this.ComboBoxEditType.Location = new System.Drawing.Point(69, 9);
            this.ComboBoxEditType.Name = "ComboBoxEditType";
            this.ComboBoxEditType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ComboBoxEditType.Properties.Items.AddRange(new object[] {
            "HTL",
            "OPT",
            "PKG",
            "CTY",
            "WAY",
            "AGY"});
            this.ComboBoxEditType.Size = new System.Drawing.Size(133, 20);
            this.ComboBoxEditType.TabIndex = 1;
            this.ComboBoxEditType.SelectedValueChanged += new System.EventHandler(this.ComboBoxEditType_SelectedValueChanged);
            this.ComboBoxEditType.TextChanged += new System.EventHandler(this.ComboBoxEditType_TextChanged);
            this.ComboBoxEditType.Leave += new System.EventHandler(this.ComboBoxEditType_Leave);
            // 
            // SplitContainerControl
            // 
            this.SplitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerControl.Location = new System.Drawing.Point(0, 31);
            this.SplitContainerControl.Name = "SplitContainerControl";
            this.SplitContainerControl.Panel1.Controls.Add(this.GridControlLookup);
            this.SplitContainerControl.Panel1.Text = "Panel1";
            this.SplitContainerControl.Panel2.AutoScroll = true;
            this.SplitContainerControl.Panel2.Controls.Add(label1);
            this.SplitContainerControl.Panel2.Controls.Add(label2);
            this.SplitContainerControl.Panel2.Controls.Add(this.CheckEditAllCategory);
            this.SplitContainerControl.Panel2.Controls.Add(this.CheckEditAllAgency);
            this.SplitContainerControl.Panel2.Controls.Add(this.LabelChgDate);
            this.SplitContainerControl.Panel2.Controls.Add(this.LabelChangeDate);
            this.SplitContainerControl.Panel2.Controls.Add(this.xtraTabControlMediaInfo);
            this.SplitContainerControl.Panel2.Controls.Add(LabelAgency);
            this.SplitContainerControl.Panel2.Controls.Add(this.ComboBoxEditType);
            this.SplitContainerControl.Panel2.Controls.Add(LabelCategory);
            this.SplitContainerControl.Panel2.Controls.Add(LabelCode);
            this.SplitContainerControl.Panel2.Controls.Add(this.CheckEditInhouse);
            this.SplitContainerControl.Panel2.Controls.Add(LabelLanguage);
            this.SplitContainerControl.Panel2.Controls.Add(LabelType);
            this.SplitContainerControl.Panel2.Controls.Add(LabelSection);
            this.SplitContainerControl.Panel2.Controls.Add(LabelsvcStartDate);
            this.SplitContainerControl.Panel2.Controls.Add(LabelsvcEndDate);
            this.SplitContainerControl.Panel2.Controls.Add(this.DateEditSvcStartDate);
            this.SplitContainerControl.Panel2.Controls.Add(this.DateEditSvcEndDate);
            this.SplitContainerControl.Panel2.Controls.Add(this.DateEditResStartDate);
            this.SplitContainerControl.Panel2.Controls.Add(this.DateEditResEndDate);
            this.SplitContainerControl.Panel2.Controls.Add(this.SearchLookupEditLang);
            this.SplitContainerControl.Panel2.Controls.Add(this.SearchLookupEditProduct);
            this.SplitContainerControl.Panel2.Controls.Add(this.SearchLookupEditSection);
            this.SplitContainerControl.Panel2.Controls.Add(this.SearchLookupEditAgency);
            this.SplitContainerControl.Panel2.Controls.Add(this.SearchLookupEditCategory);
            this.SplitContainerControl.Panel2.Text = "Panel2";
            this.SplitContainerControl.Size = new System.Drawing.Size(953, 578);
            this.SplitContainerControl.SplitterPosition = 251;
            this.SplitContainerControl.TabIndex = 2;
            this.SplitContainerControl.Text = "splitContainerControl";
            // 
            // CheckEditAllCategory
            // 
            this.CheckEditAllCategory.Location = new System.Drawing.Point(352, 126);
            this.CheckEditAllCategory.Name = "CheckEditAllCategory";
            this.CheckEditAllCategory.Properties.Caption = "All";
            this.CheckEditAllCategory.Size = new System.Drawing.Size(41, 19);
            this.CheckEditAllCategory.TabIndex = 8;
            // 
            // CheckEditAllAgency
            // 
            this.CheckEditAllAgency.Location = new System.Drawing.Point(352, 105);
            this.CheckEditAllAgency.Name = "CheckEditAllAgency";
            this.CheckEditAllAgency.Properties.Caption = "All";
            this.CheckEditAllAgency.Size = new System.Drawing.Size(39, 19);
            this.CheckEditAllAgency.TabIndex = 6;
            // 
            // LabelChgDate
            // 
            this.LabelChgDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSource, "ChgDate", true));
            this.LabelChgDate.Location = new System.Drawing.Point(281, 11);
            this.LabelChgDate.Name = "LabelChgDate";
            this.LabelChgDate.Size = new System.Drawing.Size(3, 13);
            this.LabelChgDate.TabIndex = 36;
            this.LabelChgDate.Text = " ";
            // 
            // LabelChangeDate
            // 
            this.LabelChangeDate.Location = new System.Drawing.Point(211, 11);
            this.LabelChangeDate.Name = "LabelChangeDate";
            this.LabelChangeDate.Size = new System.Drawing.Size(63, 13);
            this.LabelChangeDate.TabIndex = 0;
            this.LabelChangeDate.Text = "Change Date";
            // 
            // DateEditSvcStartDate
            // 
            this.DateEditSvcStartDate.CausesValidation = false;
            this.DateEditSvcStartDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "SvcDate_Start", true));
            this.DateEditSvcStartDate.EditValue = null;
            this.DateEditSvcStartDate.Location = new System.Drawing.Point(144, 151);
            this.DateEditSvcStartDate.Name = "DateEditSvcStartDate";
            this.DateEditSvcStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateEditSvcStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateEditSvcStartDate.Properties.DisplayFormat.FormatString = "dd-MMM-yyyy";
            this.DateEditSvcStartDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DateEditSvcStartDate.Properties.EditFormat.FormatString = "dd-MMM-yyyy";
            this.DateEditSvcStartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DateEditSvcStartDate.Properties.Mask.EditMask = "";
            this.DateEditSvcStartDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.DateEditSvcStartDate.Size = new System.Drawing.Size(100, 20);
            this.DateEditSvcStartDate.TabIndex = 9;
            this.DateEditSvcStartDate.Leave += new System.EventHandler(this.DateEditSvcStartDate_Leave);
            // 
            // DateEditSvcEndDate
            // 
            this.DateEditSvcEndDate.CausesValidation = false;
            this.DateEditSvcEndDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "SvcDate_End", true));
            this.DateEditSvcEndDate.EditValue = null;
            this.DateEditSvcEndDate.Location = new System.Drawing.Point(313, 151);
            this.DateEditSvcEndDate.Name = "DateEditSvcEndDate";
            this.DateEditSvcEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateEditSvcEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateEditSvcEndDate.Properties.DisplayFormat.FormatString = "";
            this.DateEditSvcEndDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DateEditSvcEndDate.Properties.EditFormat.FormatString = "dd-MMM-yyyy";
            this.DateEditSvcEndDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DateEditSvcEndDate.Properties.Mask.EditMask = "";
            this.DateEditSvcEndDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.DateEditSvcEndDate.Size = new System.Drawing.Size(100, 20);
            this.DateEditSvcEndDate.TabIndex = 10;
            this.DateEditSvcEndDate.Leave += new System.EventHandler(this.DateEditSvcEndDate_Leave);
            // 
            // DateEditResStartDate
            // 
            this.DateEditResStartDate.CausesValidation = false;
            this.DateEditResStartDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "ResDate_Start", true));
            this.DateEditResStartDate.EditValue = null;
            this.DateEditResStartDate.Location = new System.Drawing.Point(144, 174);
            this.DateEditResStartDate.Name = "DateEditResStartDate";
            this.DateEditResStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateEditResStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateEditResStartDate.Properties.DisplayFormat.FormatString = "";
            this.DateEditResStartDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DateEditResStartDate.Properties.EditFormat.FormatString = "dd-MMM-yyyy";
            this.DateEditResStartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DateEditResStartDate.Properties.Mask.EditMask = "";
            this.DateEditResStartDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.DateEditResStartDate.Size = new System.Drawing.Size(100, 20);
            this.DateEditResStartDate.TabIndex = 39;
            this.DateEditResStartDate.Leave += new System.EventHandler(this.DateEditResStartDate_Leave);
            // 
            // DateEditResEndDate
            // 
            this.DateEditResEndDate.CausesValidation = false;
            this.DateEditResEndDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "ResDate_End", true));
            this.DateEditResEndDate.EditValue = null;
            this.DateEditResEndDate.Location = new System.Drawing.Point(313, 174);
            this.DateEditResEndDate.Name = "DateEditResEndDate";
            this.DateEditResEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateEditResEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateEditResEndDate.Properties.DisplayFormat.FormatString = "";
            this.DateEditResEndDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DateEditResEndDate.Properties.EditFormat.FormatString = "dd-MMM-yyyy";
            this.DateEditResEndDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DateEditResEndDate.Properties.Mask.EditMask = "";
            this.DateEditResEndDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.DateEditResEndDate.Size = new System.Drawing.Size(100, 20);
            this.DateEditResEndDate.TabIndex = 40;
            this.DateEditResEndDate.Leave += new System.EventHandler(this.DateEditResEndDate_Leave);
            // 
            // SearchLookupEditLang
            // 
            this.SearchLookupEditLang.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "LANG", true));
            this.SearchLookupEditLang.Location = new System.Drawing.Point(69, 32);
            this.SearchLookupEditLang.Name = "SearchLookupEditLang";
            this.SearchLookupEditLang.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.SearchLookupEditLang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLookupEditLang.Properties.DataSource = this.BindingSourceCodeName;
            this.SearchLookupEditLang.Properties.DisplayMember = "DisplayName";
            this.SearchLookupEditLang.Properties.NullText = "";
            this.SearchLookupEditLang.Properties.PopupSizeable = false;
            this.SearchLookupEditLang.Properties.PopupView = this.searchLookUpEdit1View;
            this.SearchLookupEditLang.Properties.ValueMember = "Code";
            this.SearchLookupEditLang.Size = new System.Drawing.Size(277, 20);
            this.SearchLookupEditLang.TabIndex = 2;
            this.SearchLookupEditLang.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            this.SearchLookupEditLang.Leave += new System.EventHandler(this.ImageComboBoxEditLang_Leave);
            // 
            // BindingSourceCodeName
            // 
            this.BindingSourceCodeName.DataSource = typeof(TraceForms.CodeName);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.searchLookUpEdit1View.OptionsView.ShowIndicator = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.FieldName = "Code";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            // 
            // gridColumn5
            // 
            this.gridColumn5.FieldName = "Name";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            // 
            // SearchLookupEditProduct
            // 
            this.SearchLookupEditProduct.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CODE", true));
            this.SearchLookupEditProduct.Location = new System.Drawing.Point(69, 55);
            this.SearchLookupEditProduct.Margin = new System.Windows.Forms.Padding(2);
            this.SearchLookupEditProduct.Name = "SearchLookupEditProduct";
            this.SearchLookupEditProduct.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.SearchLookupEditProduct.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLookupEditProduct.Properties.DataSource = this.bindingSourceCodeNameProduct;
            this.SearchLookupEditProduct.Properties.DisplayMember = "DisplayName";
            this.SearchLookupEditProduct.Properties.NullText = "";
            this.SearchLookupEditProduct.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.SearchLookupEditProduct.Properties.PopupView = this.gridView6;
            this.SearchLookupEditProduct.Properties.ValueMember = "Code";
            this.SearchLookupEditProduct.Size = new System.Drawing.Size(277, 20);
            this.SearchLookupEditProduct.TabIndex = 3;
            this.SearchLookupEditProduct.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            this.SearchLookupEditProduct.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.LookupEdit_QueryPopUp);
            this.SearchLookupEditProduct.Leave += new System.EventHandler(this.ImageComboBoxEditCode_Leave);
            // 
            // bindingSourceCodeNameProduct
            // 
            this.bindingSourceCodeNameProduct.DataSource = typeof(TraceForms.CodeName);
            // 
            // gridView6
            // 
            this.gridView6.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
            this.gridView6.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView6.Name = "gridView6";
            this.gridView6.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView6.OptionsView.ShowGroupPanel = false;
            this.gridView6.OptionsView.ShowIndicator = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.FieldName = "Code";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 404;
            // 
            // gridColumn7
            // 
            this.gridColumn7.FieldName = "Name";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            this.gridColumn7.Width = 1427;
            // 
            // gridColumn8
            // 
            this.gridColumn8.FieldName = "DisplayName";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            // 
            // SearchLookupEditSection
            // 
            this.SearchLookupEditSection.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "SECTION", true));
            this.SearchLookupEditSection.Location = new System.Drawing.Point(69, 78);
            this.SearchLookupEditSection.Name = "SearchLookupEditSection";
            this.SearchLookupEditSection.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.SearchLookupEditSection.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLookupEditSection.Properties.DataSource = this.BindingSourceCodeName;
            this.SearchLookupEditSection.Properties.DisplayMember = "DisplayName";
            this.SearchLookupEditSection.Properties.NullText = "";
            this.SearchLookupEditSection.Properties.PopupSizeable = false;
            this.SearchLookupEditSection.Properties.PopupView = this.gridView2;
            this.SearchLookupEditSection.Properties.ValueMember = "Code";
            this.SearchLookupEditSection.Size = new System.Drawing.Size(277, 20);
            this.SearchLookupEditSection.TabIndex = 4;
            this.SearchLookupEditSection.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            this.SearchLookupEditSection.Leave += new System.EventHandler(this.ImageComboBoxEditSection_Leave);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "Code";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // SearchLookupEditAgency
            // 
            this.SearchLookupEditAgency.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "Agency", true));
            this.SearchLookupEditAgency.Location = new System.Drawing.Point(69, 101);
            this.SearchLookupEditAgency.Name = "SearchLookupEditAgency";
            this.SearchLookupEditAgency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLookupEditAgency.Properties.DataSource = this.BindingSourceCodeName;
            this.SearchLookupEditAgency.Properties.DisplayMember = "DisplayName";
            this.SearchLookupEditAgency.Properties.NullText = "";
            this.SearchLookupEditAgency.Properties.PopupSizeable = false;
            this.SearchLookupEditAgency.Properties.PopupView = this.gridView3;
            this.SearchLookupEditAgency.Properties.ValueMember = "Code";
            this.SearchLookupEditAgency.Size = new System.Drawing.Size(277, 20);
            this.SearchLookupEditAgency.TabIndex = 5;
            this.SearchLookupEditAgency.TextChanged += new System.EventHandler(this.ImageComboBoxEditAgency_TextChanged);
            this.SearchLookupEditAgency.Leave += new System.EventHandler(this.ImageComboBoxEditAgency_Leave);
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn9});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView3.OptionsView.ShowIndicator = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.FieldName = "Code";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn9
            // 
            this.gridColumn9.FieldName = "Name";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            // 
            // SearchLookupEditCategory
            // 
            this.SearchLookupEditCategory.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.BindingSource, "CAT", true));
            this.SearchLookupEditCategory.Location = new System.Drawing.Point(69, 124);
            this.SearchLookupEditCategory.Name = "SearchLookupEditCategory";
            this.SearchLookupEditCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SearchLookupEditCategory.Properties.DataSource = this.BindingSourceCodeName;
            this.SearchLookupEditCategory.Properties.DisplayMember = "DisplayName";
            this.SearchLookupEditCategory.Properties.MaxLength = 16;
            this.SearchLookupEditCategory.Properties.NullText = "";
            this.SearchLookupEditCategory.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.SearchLookupEditCategory.Properties.PopupSizeable = false;
            this.SearchLookupEditCategory.Properties.PopupView = this.gridView4;
            this.SearchLookupEditCategory.Properties.ValueMember = "Code";
            this.SearchLookupEditCategory.Size = new System.Drawing.Size(277, 20);
            this.SearchLookupEditCategory.TabIndex = 7;
            this.SearchLookupEditCategory.Popup += new System.EventHandler(this.SearchLookupEdit_Popup);
            this.SearchLookupEditCategory.TextChanged += new System.EventHandler(this.ImageComboBoxEditCategory_TextChanged);
            this.SearchLookupEditCategory.Leave += new System.EventHandler(this.ImageComboBoxEditCategory_Leave);
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn11});
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsBehavior.AutoPopulateColumns = false;
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowColumnHeaders = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            this.gridView4.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridView4.OptionsView.ShowIndicator = false;
            // 
            // gridColumn10
            // 
            this.gridColumn10.FieldName = "Code";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 0;
            // 
            // gridColumn11
            // 
            this.gridColumn11.FieldName = "Name";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 1;
            // 
            // LabelStatus
            // 
            this.LabelStatus.Location = new System.Drawing.Point(24, 5);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(0, 13);
            this.LabelStatus.TabIndex = 38;
            // 
            // PanelControlStatus
            // 
            this.PanelControlStatus.Appearance.Options.UseTextOptions = true;
            this.PanelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("PanelControlStatus.ContentImage")));
            this.PanelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.PanelControlStatus.Controls.Add(this.labelControl1);
            this.PanelControlStatus.Controls.Add(this.LabelStatus);
            this.PanelControlStatus.Location = new System.Drawing.Point(391, 3);
            this.PanelControlStatus.Name = "PanelControlStatus";
            this.PanelControlStatus.Size = new System.Drawing.Size(120, 25);
            this.PanelControlStatus.TabIndex = 39;
            this.PanelControlStatus.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(30, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(0, 13);
            this.labelControl1.TabIndex = 5;
            // 
            // mediaInfoMaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 632);
            this.Controls.Add(this.PanelControlStatus);
            this.Controls.Add(this.SplitContainerControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "mediaInfoMaint";
            this.ShowInTaskbar = false;
            this.Text = "Media Information Maintenance";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MediaInfoMaint_FormClosing);
            this.Shown += new System.EventHandler(this.MediaInfoMaint_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditInhouse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlMediaInfo)).EndInit();
            this.xtraTabControlMediaInfo.ResumeLayout(false);
            this.xtraTabPageText.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlText)).EndInit();
            this.panelControlText.ResumeLayout(false);
            this.panelControlText.PerformLayout();
            this.HtmlEditor.Toolbar1.ResumeLayout(false);
            this.HtmlEditor.Toolbar1.PerformLayout();
            this.HtmlEditor.Toolbar2.ResumeLayout(false);
            this.HtmlEditor.Toolbar2.PerformLayout();
            this.HtmlEditor.ResumeLayout(false);
            this.HtmlEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditSubtitle.Properties)).EndInit();
            this.xtraTabPagePrimaryImages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlPrimaryImages)).EndInit();
            this.panelControlPrimaryImages.ResumeLayout(false);
            this.panelControlPrimaryImages.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextEditCaption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlPictures)).EndInit();
            this.xtraTabControlPictures.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlLowRes)).EndInit();
            this.panelControlLowRes.ResumeLayout(false);
            this.panelControlLowRes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.azureBlobBrowser1LowRes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureEditPreviewImage1LowRes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEditImage1LowRes.Properties)).EndInit();
            this.xtraTabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlMedRes)).EndInit();
            this.panelControlMedRes.ResumeLayout(false);
            this.panelControlMedRes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.azureBlobBrowser2MedRes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEditImage2MedRes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureEditPreviewImage2MedRes.Properties)).EndInit();
            this.xtraTabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlHighRes)).EndInit();
            this.panelControlHighRes.ResumeLayout(false);
            this.panelControlHighRes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.azureBlobBrowser3HighRes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEditImage3HighRes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureEditPreviewImage3HighRes.Properties)).EndInit();
            this.xtraTabPage7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlThumbNail)).EndInit();
            this.panelControlThumbNail.ResumeLayout(false);
            this.panelControlThumbNail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.azureBlobBrowser4Thumb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEditImage4Thumb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureEditPreviewImage4Thumb.Properties)).EndInit();
            this.xtraTabPageAdditionalImages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridControlAdditionalImages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceResource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewAdditionalImages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBoxTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemAzureBlobBrowser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxImagePurpose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEditPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControlPreview)).EndInit();
            this.popupContainerControlPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditPreviewAddImg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit_Item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.xtraTabPageDisplay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlDisplay)).EndInit();
            this.panelControlDisplay.ResumeLayout(false);
            this.panelControlDisplay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditSeverity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditConsent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditInactive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxEditType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl)).EndInit();
            this.SplitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditAllCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditAllAgency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditSvcStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditSvcStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditSvcEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditSvcEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditResStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditResStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditResEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditResEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditLang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceCodeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCodeNameProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditSection.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditAgency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchLookupEditCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelControlStatus)).EndInit();
            this.PanelControlStatus.ResumeLayout(false);
            this.PanelControlStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource BindingSource;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private DevExpress.XtraEditors.ComboBoxEdit ComboBoxEditType;
        private DevExpress.XtraEditors.CheckEdit CheckEditInhouse;
        private DevExpress.XtraTab.XtraTabControl xtraTabControlMediaInfo;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageText;
        private DevExpress.XtraTab.XtraTabPage xtraTabPagePrimaryImages;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageAdditionalImages;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageDisplay;
        private DevExpress.XtraGrid.GridControl GridControlLookup;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewLookup;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnLang;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnType;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnCode;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnCategory;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnRoom;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnSection;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnTitle;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnSubtitle;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnText;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnCaption;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnImage1;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnImage2;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnImage3;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnInactive;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnSvcDateStart;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnSvcDateEnd;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnAgency;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnInhouse;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnChgDate;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnImage4;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnSeverity;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnConsent;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnMediaRptItems;
        private DevExpress.XtraEditors.SplitContainerControl SplitContainerControl;
        private DevExpress.XtraEditors.LabelControl LabelChgDate;
        private DevExpress.XtraEditors.LabelControl LabelChangeDate;
        private System.Windows.Forms.BindingSource BindingSourceResource;
        private LabelControl LabelStatus;
        private PanelControl PanelControlStatus;
        private LabelControl labelControl1;
        private CheckEdit CheckEditAllAgency;
        private CheckEdit CheckEditAllCategory;
        private BindingSource bindingSourceCodeNameProduct;
        private PanelControl panelControlText;
        private TextEdit TextEditTitle;
        private TextEdit TextEditSubtitle;
        private PanelControl panelControlPrimaryImages;
        private TextEdit TextEditCaption;
        private DevExpress.XtraTab.XtraTabControl xtraTabControlPictures;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private PanelControl panelControlLowRes;
        private LabelControl labelControlSizeDisplay1LowRes;
        private LabelControl labelControlSize;
        private ButtonEdit ButtonEditImage1LowRes;
        private SimpleButton ButtonCreateThumbnailLowRes;
        private LabelControl LabelPeview;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage5;
        private PanelControl panelControlMedRes;
        private LabelControl labelControlSizeDisplay2MedRes;
        private LabelControl labelControlSize2;
        private ButtonEdit ButtonEditImage2MedRes;
        private LabelControl labelControlPreview2;
        private SimpleButton ButtonCreateThumbnailMedRes;
        private PictureEdit PictureEditPreviewImage2MedRes;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage6;
        private PanelControl panelControlHighRes;
        private LabelControl labelControlSizeDisplay3HighRes;
        private LabelControl labelControlSize3;
        private ButtonEdit ButtonEditImage3HighRes;
        private SimpleButton ButtonCreateThumbNailHighRes;
        private LabelControl LabelPreview3;
        private PictureEdit PictureEditPreviewImage3HighRes;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage7;
        private PanelControl panelControlThumbNail;
        private LabelControl labelControlSizeDisplay4Thumb;
        private LabelControl labelControlSize4;
        private ButtonEdit ButtonEditImage4Thumb;
        private LabelControl LabelPreview4;
        private PictureEdit PictureEditPreviewImage4Thumb;
        private PanelControl panelControl3;
        private SimpleButton ButtonDelRow;
        private SimpleButton ButtonAddRow;
        private PanelControl panelControlDisplay;
        private ImageComboBoxEdit ImageComboBoxEditSeverity;
        private CheckEdit CheckEditConsent;
        private CheckEdit CheckEditInactive;
        private PictureEdit pictureEditPreviewAddImg;
        private SpiceLogic.WinHTMLEditor.WinForm.WinFormHtmlEditor HtmlEditor;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager BarManager;
        private DevExpress.XtraBars.Bar barTools;
        private DevExpress.XtraBars.BarButtonItem BarButtonItemNew;
        private DevExpress.XtraBars.BarButtonItem BarButtonItemDelete;
        private DevExpress.XtraBars.BarButtonItem BarButtonItemSave;
        private DevExpress.XtraBars.BarButtonItem BarButtonItemClone;
        private DevExpress.XtraBars.BarButtonItem BarButtonItemExpand;
        private DevExpress.XtraBars.BarSubItem BarSubItemReports;
        private DevExpress.XtraBars.BarButtonItem barButtonItemReportsContainingSection;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAddToReports;
        private DevExpress.XtraBars.BarButtonItem barButtonItemRemoveFromReports;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItemCreateNewReports;
        private GridControl GridControlAdditionalImages;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewAdditionalImages;
        private GridColumn ColumnID1;
        private GridColumn ColumnLinkTable;
        private GridColumn ColumnLinkValue;
        private GridColumn ColumnRecType;
        private GridColumn ColumnTag;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBoxTag;
        private GridColumn ColumnItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit_Item;
        private GridColumn ColumnDesc;
        private GridColumn ColumnUserDec1;
        private GridColumn ColumnUserDec2;
        private GridColumn ColumnUserInt1;
        private GridColumn ColumnUserInt2;
        private GridColumn ColumnUserTxt1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxImagePurpose;
        private GridColumn ColumnUserTxt2;
        private GridColumn ColumnUserTxt3;
        private GridColumn ColumnUserTxt4;
        private GridColumn ColumnUserDte1;
        private GridColumn ColumnUserDte2;
        private GridColumn gridColumnPreview;
        private DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit repositoryItemPopupContainerEditPreview;
        private PopupContainerControl popupContainerControlPreview;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DateEdit DateEditSvcStartDate;
        private DateEdit DateEditSvcEndDate;
        private DateEdit DateEditResStartDate;
        private DateEdit DateEditResEndDate;
        private DevExpress.Data.Linq.EntityInstantFeedbackSource EntityInstantFeedbackSource;
        private BindingSource BindingSourceCodeName;
        private PictureEdit PictureEditPreviewImage1LowRes;
        private AzureBlobBrowser.AzureBlobBrowser azureBlobBrowser1LowRes;
        private AzureBlobBrowser.AzureBlobBrowser azureBlobBrowser2MedRes;
        private AzureBlobBrowser.AzureBlobBrowser azureBlobBrowser3HighRes;
        private AzureBlobBrowser.AzureBlobBrowser azureBlobBrowser4Thumb;
        private AzureBlobBrowser.RepositoryItemAzureBlobBrowser repositoryItemAzureBlobBrowser;
        private SearchLookUpEdit SearchLookupEditLang;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private GridColumn gridColumn4;
        private GridColumn gridColumn5;
        private SearchLookUpEdit SearchLookupEditProduct;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView6;
        private GridColumn gridColumn6;
        private GridColumn gridColumn7;
        private GridColumn gridColumn8;
        private SearchLookUpEdit SearchLookupEditSection;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private GridColumn gridColumn1;
        private GridColumn gridColumn2;
        private SearchLookUpEdit SearchLookupEditAgency;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private GridColumn gridColumn3;
        private GridColumn gridColumn9;
        private SearchLookUpEdit SearchLookupEditCategory;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private GridColumn gridColumn10;
        private GridColumn gridColumn11;
    }
}
