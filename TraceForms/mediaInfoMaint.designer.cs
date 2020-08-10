
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
            this.MediaInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ButtonEditsvcStartDate = new DevExpress.XtraEditors.ButtonEdit();
            this.ButtonEditsvcEndDate = new DevExpress.XtraEditors.ButtonEdit();
            this.CheckEditInhouse = new DevExpress.XtraEditors.CheckEdit();
            this.xtraTabControlMediaInfo = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageText = new DevExpress.XtraTab.XtraTabPage();
            this.panelControlText = new DevExpress.XtraEditors.PanelControl();
            this.htmlEditor = new SpiceLogic.WinHTMLEditor.WinForm.WinFormHtmlEditor();
            this.TextEditTitle = new DevExpress.XtraEditors.TextEdit();
            this.TextEditSubtitle = new DevExpress.XtraEditors.TextEdit();
            this.xtraTabPagePrimaryImages = new DevExpress.XtraTab.XtraTabPage();
            this.panelControlPrimaryImages = new DevExpress.XtraEditors.PanelControl();
            this.TextEditCaption = new DevExpress.XtraEditors.TextEdit();
            this.xtraTabControlPictures = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControlLowRes = new DevExpress.XtraEditors.PanelControl();
            this.labelControlSizeDisplay = new DevExpress.XtraEditors.LabelControl();
            this.labelControlSize = new DevExpress.XtraEditors.LabelControl();
            this.ButtonCreateThumbnailLowRes = new DevExpress.XtraEditors.SimpleButton();
            this.LabelPeview = new DevExpress.XtraEditors.LabelControl();
            this.pictureEditPreviewImage1 = new DevExpress.XtraEditors.PictureEdit();
            this.ButtonEditImage1LowRes = new DevExpress.XtraEditors.TextEdit();
            this.xtraTabPage5 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControlMedRes = new DevExpress.XtraEditors.PanelControl();
            this.labelControlSizeDisplay2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControlSize2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControlPreview2 = new DevExpress.XtraEditors.LabelControl();
            this.ButtonCreateThumbnailMedRes = new DevExpress.XtraEditors.SimpleButton();
            this.pictureEditPreviewImage2 = new DevExpress.XtraEditors.PictureEdit();
            this.ButtonEditImage2MedRes = new DevExpress.XtraEditors.TextEdit();
            this.xtraTabPage6 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControlHighRes = new DevExpress.XtraEditors.PanelControl();
            this.labelControlSizeDisplay3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControlSize3 = new DevExpress.XtraEditors.LabelControl();
            this.ButtonCreateThumbNailHighRes = new DevExpress.XtraEditors.SimpleButton();
            this.LabelPreview3 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEditPreviewImage3 = new DevExpress.XtraEditors.PictureEdit();
            this.ButtonEditImage3HighRes = new DevExpress.XtraEditors.TextEdit();
            this.xtraTabPage7 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControlThumbNail = new DevExpress.XtraEditors.PanelControl();
            this.labelControlSizeDisplay4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControlSize4 = new DevExpress.XtraEditors.LabelControl();
            this.LabelPreview4 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEditPreviewImage4 = new DevExpress.XtraEditors.PictureEdit();
            this.ButtonEditImage4ThmNail = new DevExpress.XtraEditors.TextEdit();
            this.xtraTabPageAdditionalImages = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.GridControlAdditionalImages = new DevExpress.XtraGrid.GridControl();
            this.ResourceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GridViewAdditionalImages = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColumnID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnLinkTable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnLinkValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnRecType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnTag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBoxTag = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.ColumnItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit_Item = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
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
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ButtonSaveChanges = new DevExpress.XtraEditors.SimpleButton();
            this.ButtonDelRow = new DevExpress.XtraEditors.SimpleButton();
            this.ButtonAddRow = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPageDisplay = new DevExpress.XtraTab.XtraTabPage();
            this.panelControlDisplay = new DevExpress.XtraEditors.PanelControl();
            this.ImageComboBoxEditSeverity = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.CheckEditConsent = new DevExpress.XtraEditors.CheckEdit();
            this.CheckEditInactive = new DevExpress.XtraEditors.CheckEdit();
            this.GridControlMediaInfo = new DevExpress.XtraGrid.GridControl();
            this.GridViewMediaInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridLookUpEditProduct = new DevExpress.XtraEditors.GridLookUpEdit();
            this.bindingSourceCodeNameProduct = new System.Windows.Forms.BindingSource(this.components);
            this.gridLookUpEditProductView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCodeProduct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameProduct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDisplayNameProduct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.buttonEditResEndDate = new DevExpress.XtraEditors.ButtonEdit();
            this.buttonEditResStartDate = new DevExpress.XtraEditors.ButtonEdit();
            this.checkEditAllCategory = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditAllAgency = new DevExpress.XtraEditors.CheckEdit();
            this.ImageComboBoxEditAgency = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.ImageComboBoxEditSection = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.ImageComboBoxEditLang = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.LabelChgDate = new DevExpress.XtraEditors.LabelControl();
            this.LabelChangeDate = new DevExpress.XtraEditors.LabelControl();
            this.ImageComboBoxEditCategory = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.LabelStatus = new DevExpress.XtraEditors.LabelControl();
            this.panelControlStatus = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEditPreviewAddImg = new DevExpress.XtraEditors.PictureEdit();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTools = new DevExpress.XtraBars.Bar();
            this.barButtonItemNew = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemClone = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemExpand = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItemReports = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItemReportsContainingSection = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemAddToReports = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemRemoveFromReports = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCreateNewReports = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
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
            ((System.ComponentModel.ISupportInitialize)(this.MediaInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEditsvcStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEditsvcEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditInhouse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlMediaInfo)).BeginInit();
            this.xtraTabControlMediaInfo.SuspendLayout();
            this.xtraTabPageText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlText)).BeginInit();
            this.panelControlText.SuspendLayout();
            this.htmlEditor.Toolbar1.SuspendLayout();
            this.htmlEditor.Toolbar2.SuspendLayout();
            this.htmlEditor.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditPreviewImage1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEditImage1LowRes.Properties)).BeginInit();
            this.xtraTabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlMedRes)).BeginInit();
            this.panelControlMedRes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditPreviewImage2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEditImage2MedRes.Properties)).BeginInit();
            this.xtraTabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlHighRes)).BeginInit();
            this.panelControlHighRes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditPreviewImage3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEditImage3HighRes.Properties)).BeginInit();
            this.xtraTabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlThumbNail)).BeginInit();
            this.panelControlThumbNail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditPreviewImage4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEditImage4ThmNail.Properties)).BeginInit();
            this.xtraTabPageAdditionalImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlAdditionalImages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResourceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewAdditionalImages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBoxTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit_Item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxImagePurpose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEditPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControlPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.xtraTabPageDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlDisplay)).BeginInit();
            this.panelControlDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditSeverity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditConsent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditInactive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlMediaInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewMediaInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxEditType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCodeNameProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditProductView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditResEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditResStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditAllCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditAllAgency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditAgency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditSection.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditLang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).BeginInit();
            this.panelControlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditPreviewAddImg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelAgency
            // 
            LabelAgency.AutoSize = true;
            LabelAgency.Location = new System.Drawing.Point(8, 104);
            LabelAgency.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelAgency.Name = "LabelAgency";
            LabelAgency.Size = new System.Drawing.Size(43, 13);
            LabelAgency.TabIndex = 0;
            LabelAgency.Text = "Agency";
            // 
            // LabelType
            // 
            LabelType.AutoSize = true;
            LabelType.Location = new System.Drawing.Point(8, 11);
            LabelType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelType.Name = "LabelType";
            LabelType.Size = new System.Drawing.Size(31, 13);
            LabelType.TabIndex = 0;
            LabelType.Text = "Type";
            // 
            // LabelsvcStartDate
            // 
            LabelsvcStartDate.AutoSize = true;
            LabelsvcStartDate.Location = new System.Drawing.Point(8, 153);
            LabelsvcStartDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelsvcStartDate.Name = "LabelsvcStartDate";
            LabelsvcStartDate.Size = new System.Drawing.Size(120, 13);
            LabelsvcStartDate.TabIndex = 0;
            LabelsvcStartDate.Text = "Service Date:        From";
            // 
            // LabelsvcEndDate
            // 
            LabelsvcEndDate.AutoSize = true;
            LabelsvcEndDate.Location = new System.Drawing.Point(261, 153);
            LabelsvcEndDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelsvcEndDate.Name = "LabelsvcEndDate";
            LabelsvcEndDate.Size = new System.Drawing.Size(47, 13);
            LabelsvcEndDate.TabIndex = 0;
            LabelsvcEndDate.Text = "Through";
            // 
            // LabelSection
            // 
            LabelSection.AutoSize = true;
            LabelSection.Location = new System.Drawing.Point(8, 81);
            LabelSection.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelSection.Name = "LabelSection";
            LabelSection.Size = new System.Drawing.Size(42, 13);
            LabelSection.TabIndex = 0;
            LabelSection.Text = "Section";
            // 
            // LabelLanguage
            // 
            LabelLanguage.AutoSize = true;
            LabelLanguage.Location = new System.Drawing.Point(8, 34);
            LabelLanguage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelLanguage.Name = "LabelLanguage";
            LabelLanguage.Size = new System.Drawing.Size(54, 13);
            LabelLanguage.TabIndex = 0;
            LabelLanguage.Text = "Language";
            // 
            // LabelCode
            // 
            LabelCode.AutoSize = true;
            LabelCode.Location = new System.Drawing.Point(8, 58);
            LabelCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelCode.Name = "LabelCode";
            LabelCode.Size = new System.Drawing.Size(32, 13);
            LabelCode.TabIndex = 0;
            LabelCode.Text = "Code";
            // 
            // LabelCategory
            // 
            LabelCategory.AutoSize = true;
            LabelCategory.Location = new System.Drawing.Point(8, 127);
            LabelCategory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelCategory.Name = "LabelCategory";
            LabelCategory.Size = new System.Drawing.Size(52, 13);
            LabelCategory.TabIndex = 0;
            LabelCategory.Text = "Category";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(8, 176);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(118, 13);
            label1.TabIndex = 37;
            label1.Text = "Res Date:             From";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(261, 176);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(47, 13);
            label2.TabIndex = 38;
            label2.Text = "Through";
            // 
            // LabelInactive
            // 
            LabelInactive.AutoSize = true;
            LabelInactive.Location = new System.Drawing.Point(53, 67);
            LabelInactive.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelInactive.Name = "LabelInactive";
            LabelInactive.Size = new System.Drawing.Size(50, 13);
            LabelInactive.TabIndex = 0;
            LabelInactive.Text = "Inactive:";
            // 
            // LabelSeverity
            // 
            LabelSeverity.AutoSize = true;
            LabelSeverity.Location = new System.Drawing.Point(54, 103);
            LabelSeverity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelSeverity.Name = "LabelSeverity";
            LabelSeverity.Size = new System.Drawing.Size(51, 13);
            LabelSeverity.TabIndex = 0;
            LabelSeverity.Text = "Severity:";
            // 
            // LabelConsent
            // 
            LabelConsent.AutoSize = true;
            LabelConsent.Location = new System.Drawing.Point(52, 147);
            LabelConsent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelConsent.Name = "LabelConsent";
            LabelConsent.Size = new System.Drawing.Size(51, 13);
            LabelConsent.TabIndex = 0;
            LabelConsent.Text = "Consent:";
            // 
            // LabelImage4
            // 
            LabelImage4.AutoSize = true;
            LabelImage4.Location = new System.Drawing.Point(12, 25);
            LabelImage4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelImage4.Name = "LabelImage4";
            LabelImage4.Size = new System.Drawing.Size(29, 13);
            LabelImage4.TabIndex = 0;
            LabelImage4.Text = "Path";
            // 
            // LabelImage3
            // 
            LabelImage3.AutoSize = true;
            LabelImage3.Location = new System.Drawing.Point(12, 25);
            LabelImage3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelImage3.Name = "LabelImage3";
            LabelImage3.Size = new System.Drawing.Size(29, 13);
            LabelImage3.TabIndex = 0;
            LabelImage3.Text = "Path";
            // 
            // LabelImage2
            // 
            LabelImage2.AutoSize = true;
            LabelImage2.Location = new System.Drawing.Point(12, 25);
            LabelImage2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelImage2.Name = "LabelImage2";
            LabelImage2.Size = new System.Drawing.Size(29, 13);
            LabelImage2.TabIndex = 0;
            LabelImage2.Text = "Path";
            // 
            // LabelImage1
            // 
            LabelImage1.AutoSize = true;
            LabelImage1.Location = new System.Drawing.Point(12, 25);
            LabelImage1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelImage1.Name = "LabelImage1";
            LabelImage1.Size = new System.Drawing.Size(29, 13);
            LabelImage1.TabIndex = 0;
            LabelImage1.Text = "Path";
            // 
            // LabelCaption
            // 
            LabelCaption.AutoSize = true;
            LabelCaption.Location = new System.Drawing.Point(30, 26);
            LabelCaption.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelCaption.Name = "LabelCaption";
            LabelCaption.Size = new System.Drawing.Size(48, 13);
            LabelCaption.TabIndex = 0;
            LabelCaption.Text = "Caption:";
            // 
            // LabelTitle
            // 
            LabelTitle.AutoSize = true;
            LabelTitle.Location = new System.Drawing.Point(41, 16);
            LabelTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelTitle.Name = "LabelTitle";
            LabelTitle.Size = new System.Drawing.Size(31, 13);
            LabelTitle.TabIndex = 0;
            LabelTitle.Text = "Title:";
            // 
            // LabelSubtitle
            // 
            LabelSubtitle.AutoSize = true;
            LabelSubtitle.Location = new System.Drawing.Point(22, 42);
            LabelSubtitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LabelSubtitle.Name = "LabelSubtitle";
            LabelSubtitle.Size = new System.Drawing.Size(47, 13);
            LabelSubtitle.TabIndex = 0;
            LabelSubtitle.Text = "Subtitle:";
            // 
            // MediaInfoBindingSource
            // 
            this.MediaInfoBindingSource.DataSource = typeof(FlexModel.MEDIAINFO);
            this.MediaInfoBindingSource.CurrentChanged += new System.EventHandler(this.MediaInfoBindingSource_CurrentChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ButtonEditsvcStartDate
            // 
            this.ButtonEditsvcStartDate.CausesValidation = false;
            this.ButtonEditsvcStartDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.MediaInfoBindingSource, "SvcDate_Start", true));
            this.ButtonEditsvcStartDate.Location = new System.Drawing.Point(144, 151);
            this.ButtonEditsvcStartDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ButtonEditsvcStartDate.Name = "ButtonEditsvcStartDate";
            this.ButtonEditsvcStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ButtonEditsvcStartDate.Size = new System.Drawing.Size(100, 20);
            this.ButtonEditsvcStartDate.TabIndex = 9;
            this.ButtonEditsvcStartDate.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.DateEditsvcStartDate_ButtonClick);
            this.ButtonEditsvcStartDate.TextChanged += new System.EventHandler(this.DateEditsvcStartDate_TextChanged);
            this.ButtonEditsvcStartDate.Enter += new System.EventHandler(this.enterControl);
            this.ButtonEditsvcStartDate.Leave += new System.EventHandler(this.DateEditsvcStartDate_Leave);
            // 
            // ButtonEditsvcEndDate
            // 
            this.ButtonEditsvcEndDate.CausesValidation = false;
            this.ButtonEditsvcEndDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.MediaInfoBindingSource, "SvcDate_End", true));
            this.ButtonEditsvcEndDate.Location = new System.Drawing.Point(313, 151);
            this.ButtonEditsvcEndDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ButtonEditsvcEndDate.Name = "ButtonEditsvcEndDate";
            this.ButtonEditsvcEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ButtonEditsvcEndDate.Size = new System.Drawing.Size(100, 20);
            this.ButtonEditsvcEndDate.TabIndex = 10;
            this.ButtonEditsvcEndDate.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.DateEditsvcEndDate_ButtonClick);
            this.ButtonEditsvcEndDate.TextChanged += new System.EventHandler(this.DateEditsvcEndDate_TextChanged);
            this.ButtonEditsvcEndDate.Enter += new System.EventHandler(this.enterControl);
            this.ButtonEditsvcEndDate.Leave += new System.EventHandler(this.DateEditsvcEndDate_Leave);
            // 
            // CheckEditInhouse
            // 
            this.CheckEditInhouse.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.MediaInfoBindingSource, "Inhouse", true));
            this.CheckEditInhouse.Location = new System.Drawing.Point(424, 150);
            this.CheckEditInhouse.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CheckEditInhouse.Name = "CheckEditInhouse";
            this.CheckEditInhouse.Properties.Caption = "Display inhouse only";
            this.CheckEditInhouse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CheckEditInhouse.Size = new System.Drawing.Size(137, 19);
            this.CheckEditInhouse.TabIndex = 11;
            this.CheckEditInhouse.Modified += new System.EventHandler(this.CheckEditInactive_Modified);
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
            this.xtraTabControlMediaInfo.Size = new System.Drawing.Size(649, 356);
            this.xtraTabControlMediaInfo.TabIndex = 33;
            this.xtraTabControlMediaInfo.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageText,
            this.xtraTabPagePrimaryImages,
            this.xtraTabPageAdditionalImages,
            this.xtraTabPageDisplay});
            this.xtraTabControlMediaInfo.TabStop = false;
            this.xtraTabControlMediaInfo.Enter += new System.EventHandler(this.enterControl);
            // 
            // xtraTabPageText
            // 
            this.xtraTabPageText.Controls.Add(this.panelControlText);
            this.xtraTabPageText.Margin = new System.Windows.Forms.Padding(4);
            this.xtraTabPageText.Name = "xtraTabPageText";
            this.xtraTabPageText.Size = new System.Drawing.Size(643, 328);
            this.xtraTabPageText.Text = "Text";
            // 
            // panelControlText
            // 
            this.panelControlText.Controls.Add(this.htmlEditor);
            this.panelControlText.Controls.Add(this.TextEditTitle);
            this.panelControlText.Controls.Add(this.TextEditSubtitle);
            this.panelControlText.Controls.Add(LabelSubtitle);
            this.panelControlText.Controls.Add(LabelTitle);
            this.panelControlText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlText.Location = new System.Drawing.Point(0, 0);
            this.panelControlText.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelControlText.Name = "panelControlText";
            this.panelControlText.Size = new System.Drawing.Size(643, 328);
            this.panelControlText.TabIndex = 0;
            // 
            // htmlEditor
            // 
            this.htmlEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.htmlEditor.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.htmlEditor.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.htmlEditor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.htmlEditor.BodyStyle = "FONT-FAMILY: Arial";
            // 
            // htmlEditor.BtnAlignCenter
            // 
            this.htmlEditor.BtnAlignCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnAlignCenter.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnAlignCenter.Image")));
            this.htmlEditor.BtnAlignCenter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnAlignCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnAlignCenter.Name = "_factoryBtnAlignCenter";
            this.htmlEditor.BtnAlignCenter.Size = new System.Drawing.Size(26, 26);
            this.htmlEditor.BtnAlignCenter.Text = "Align Centre";
            // 
            // htmlEditor.BtnAlignLeft
            // 
            this.htmlEditor.BtnAlignLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnAlignLeft.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnAlignLeft.Image")));
            this.htmlEditor.BtnAlignLeft.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnAlignLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnAlignLeft.Name = "_factoryBtnAlignLeft";
            this.htmlEditor.BtnAlignLeft.Size = new System.Drawing.Size(26, 26);
            this.htmlEditor.BtnAlignLeft.Text = "Align Left";
            // 
            // htmlEditor.BtnAlignRight
            // 
            this.htmlEditor.BtnAlignRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnAlignRight.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnAlignRight.Image")));
            this.htmlEditor.BtnAlignRight.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnAlignRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnAlignRight.Name = "_factoryBtnAlignRight";
            this.htmlEditor.BtnAlignRight.Size = new System.Drawing.Size(26, 26);
            this.htmlEditor.BtnAlignRight.Text = "Align Right";
            // 
            // htmlEditor.BtnBodyStyle
            // 
            this.htmlEditor.BtnBodyStyle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnBodyStyle.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnBodyStyle.Image")));
            this.htmlEditor.BtnBodyStyle.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnBodyStyle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnBodyStyle.Name = "_factoryBtnBodyStyle";
            this.htmlEditor.BtnBodyStyle.Size = new System.Drawing.Size(27, 15);
            this.htmlEditor.BtnBodyStyle.Text = "Document Style ";
            // 
            // htmlEditor.BtnBold
            // 
            this.htmlEditor.BtnBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnBold.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnBold.Image")));
            this.htmlEditor.BtnBold.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnBold.Name = "_factoryBtnBold";
            this.htmlEditor.BtnBold.Size = new System.Drawing.Size(23, 32);
            this.htmlEditor.BtnBold.Text = "Bold";
            // 
            // htmlEditor.BtnCopy
            // 
            this.htmlEditor.BtnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnCopy.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnCopy.Image")));
            this.htmlEditor.BtnCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnCopy.Name = "_factoryBtnCopy";
            this.htmlEditor.BtnCopy.Size = new System.Drawing.Size(23, 32);
            this.htmlEditor.BtnCopy.Text = "Copy";
            // 
            // htmlEditor.BtnCut
            // 
            this.htmlEditor.BtnCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnCut.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnCut.Image")));
            this.htmlEditor.BtnCut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnCut.Name = "_factoryBtnCut";
            this.htmlEditor.BtnCut.Size = new System.Drawing.Size(23, 32);
            this.htmlEditor.BtnCut.Text = "Cut";
            // 
            // htmlEditor.BtnFontColor
            // 
            this.htmlEditor.BtnFontColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnFontColor.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnFontColor.Image")));
            this.htmlEditor.BtnFontColor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnFontColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnFontColor.Name = "_factoryBtnFontColor";
            this.htmlEditor.BtnFontColor.Size = new System.Drawing.Size(23, 26);
            this.htmlEditor.BtnFontColor.Text = "Apply Font Color";
            // 
            // htmlEditor.BtnFormatRedo
            // 
            this.htmlEditor.BtnFormatRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnFormatRedo.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnFormatRedo.Image")));
            this.htmlEditor.BtnFormatRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnFormatRedo.Name = "_factoryBtnRedo";
            this.htmlEditor.BtnFormatRedo.Size = new System.Drawing.Size(32, 32);
            this.htmlEditor.BtnFormatRedo.Text = "Redo";
            // 
            // htmlEditor.BtnFormatReset
            // 
            this.htmlEditor.BtnFormatReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnFormatReset.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnFormatReset.Image")));
            this.htmlEditor.BtnFormatReset.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnFormatReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnFormatReset.Name = "_factoryBtnFormatReset";
            this.htmlEditor.BtnFormatReset.Size = new System.Drawing.Size(34, 32);
            this.htmlEditor.BtnFormatReset.Text = "Remove Format";
            // 
            // htmlEditor.BtnFormatUndo
            // 
            this.htmlEditor.BtnFormatUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnFormatUndo.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnFormatUndo.Image")));
            this.htmlEditor.BtnFormatUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnFormatUndo.Name = "_factoryBtnUndo";
            this.htmlEditor.BtnFormatUndo.Size = new System.Drawing.Size(32, 32);
            this.htmlEditor.BtnFormatUndo.Text = "Undo";
            // 
            // htmlEditor.BtnHighlightColor
            // 
            this.htmlEditor.BtnHighlightColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnHighlightColor.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnHighlightColor.Image")));
            this.htmlEditor.BtnHighlightColor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnHighlightColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnHighlightColor.Name = "_factoryBtnHighlightColor";
            this.htmlEditor.BtnHighlightColor.Size = new System.Drawing.Size(27, 26);
            this.htmlEditor.BtnHighlightColor.Text = "Apply Highlight Color";
            // 
            // htmlEditor.BtnHorizontalRule
            // 
            this.htmlEditor.BtnHorizontalRule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnHorizontalRule.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnHorizontalRule.Image")));
            this.htmlEditor.BtnHorizontalRule.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnHorizontalRule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnHorizontalRule.Name = "_factoryBtnHorizontalRule";
            this.htmlEditor.BtnHorizontalRule.Size = new System.Drawing.Size(24, 26);
            this.htmlEditor.BtnHorizontalRule.Text = "Insert Horizontal Rule";
            // 
            // htmlEditor.BtnHyperlink
            // 
            this.htmlEditor.BtnHyperlink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnHyperlink.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnHyperlink.Image")));
            this.htmlEditor.BtnHyperlink.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnHyperlink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnHyperlink.Name = "_factoryBtnHyperlink";
            this.htmlEditor.BtnHyperlink.Size = new System.Drawing.Size(23, 26);
            this.htmlEditor.BtnHyperlink.Text = "Hyperlink";
            // 
            // htmlEditor.BtnImage
            // 
            this.htmlEditor.BtnImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnImage.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnImage.Image")));
            this.htmlEditor.BtnImage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnImage.Name = "_factoryBtnImage";
            this.htmlEditor.BtnImage.Size = new System.Drawing.Size(23, 26);
            this.htmlEditor.BtnImage.Text = "Image";
            // 
            // htmlEditor.BtnIndent
            // 
            this.htmlEditor.BtnIndent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnIndent.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnIndent.Image")));
            this.htmlEditor.BtnIndent.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnIndent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnIndent.Name = "_factoryBtnIndent";
            this.htmlEditor.BtnIndent.Size = new System.Drawing.Size(27, 26);
            this.htmlEditor.BtnIndent.Text = "Indent";
            // 
            // htmlEditor.BtnInsertYouTubeVideo
            // 
            this.htmlEditor.BtnInsertYouTubeVideo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnInsertYouTubeVideo.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnInsertYouTubeVideo.Image")));
            this.htmlEditor.BtnInsertYouTubeVideo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnInsertYouTubeVideo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnInsertYouTubeVideo.Name = "_factoryBtnInsertYouTubeVideo";
            this.htmlEditor.BtnInsertYouTubeVideo.Size = new System.Drawing.Size(23, 26);
            this.htmlEditor.BtnInsertYouTubeVideo.Text = "Insert YouTube Video";
            // 
            // htmlEditor.BtnItalic
            // 
            this.htmlEditor.BtnItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnItalic.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnItalic.Image")));
            this.htmlEditor.BtnItalic.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnItalic.Name = "_factoryBtnItalic";
            this.htmlEditor.BtnItalic.Size = new System.Drawing.Size(23, 32);
            this.htmlEditor.BtnItalic.Text = "Italic";
            // 
            // htmlEditor.BtnNew
            // 
            this.htmlEditor.BtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnNew.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnNew.Image")));
            this.htmlEditor.BtnNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnNew.Name = "_factoryBtnNew";
            this.htmlEditor.BtnNew.Size = new System.Drawing.Size(23, 32);
            this.htmlEditor.BtnNew.Text = "New";
            // 
            // htmlEditor.BtnOpen
            // 
            this.htmlEditor.BtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnOpen.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnOpen.Image")));
            this.htmlEditor.BtnOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnOpen.Name = "_factoryBtnOpen";
            this.htmlEditor.BtnOpen.Size = new System.Drawing.Size(23, 32);
            this.htmlEditor.BtnOpen.Text = "Open";
            this.htmlEditor.BtnOpen.Visible = false;
            // 
            // htmlEditor.BtnOrderedList
            // 
            this.htmlEditor.BtnOrderedList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnOrderedList.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnOrderedList.Image")));
            this.htmlEditor.BtnOrderedList.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnOrderedList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnOrderedList.Name = "_factoryBtnOrderedList";
            this.htmlEditor.BtnOrderedList.Size = new System.Drawing.Size(24, 26);
            this.htmlEditor.BtnOrderedList.Text = "Numbered List";
            // 
            // htmlEditor.BtnOutdent
            // 
            this.htmlEditor.BtnOutdent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnOutdent.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnOutdent.Image")));
            this.htmlEditor.BtnOutdent.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnOutdent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnOutdent.Name = "_factoryBtnOutdent";
            this.htmlEditor.BtnOutdent.Size = new System.Drawing.Size(27, 26);
            this.htmlEditor.BtnOutdent.Text = "Outdent";
            // 
            // htmlEditor.BtnPaste
            // 
            this.htmlEditor.BtnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnPaste.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnPaste.Image")));
            this.htmlEditor.BtnPaste.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnPaste.Name = "_factoryBtnPaste";
            this.htmlEditor.BtnPaste.Size = new System.Drawing.Size(23, 32);
            this.htmlEditor.BtnPaste.Text = "Paste";
            // 
            // htmlEditor.BtnPasteFromMSWord
            // 
            this.htmlEditor.BtnPasteFromMSWord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnPasteFromMSWord.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnPasteFromMSWord.Image")));
            this.htmlEditor.BtnPasteFromMSWord.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnPasteFromMSWord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnPasteFromMSWord.Name = "_factoryBtnPasteFromMSWord";
            this.htmlEditor.BtnPasteFromMSWord.Size = new System.Drawing.Size(23, 32);
            this.htmlEditor.BtnPasteFromMSWord.Text = "Paste the Content that you Copied from MS Word";
            // 
            // htmlEditor.BtnPrint
            // 
            this.htmlEditor.BtnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnPrint.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnPrint.Image")));
            this.htmlEditor.BtnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnPrint.Name = "_factoryBtnPrint";
            this.htmlEditor.BtnPrint.Size = new System.Drawing.Size(23, 32);
            this.htmlEditor.BtnPrint.Text = "Print";
            // 
            // htmlEditor.BtnSave
            // 
            this.htmlEditor.BtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnSave.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnSave.Image")));
            this.htmlEditor.BtnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnSave.Name = "_factoryBtnSave";
            this.htmlEditor.BtnSave.Size = new System.Drawing.Size(23, 32);
            this.htmlEditor.BtnSave.Text = "Save";
            this.htmlEditor.BtnSave.Visible = false;
            // 
            // htmlEditor.BtnSearch
            // 
            this.htmlEditor.BtnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnSearch.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnSearch.Image")));
            this.htmlEditor.BtnSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnSearch.Name = "_factoryBtnSearch";
            this.htmlEditor.BtnSearch.Size = new System.Drawing.Size(24, 32);
            this.htmlEditor.BtnSearch.Text = "Search";
            // 
            // htmlEditor.BtnSpellCheck
            // 
            this.htmlEditor.BtnSpellCheck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnSpellCheck.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnSpellCheck.Image")));
            this.htmlEditor.BtnSpellCheck.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnSpellCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnSpellCheck.Name = "_factoryBtnSpellCheck";
            this.htmlEditor.BtnSpellCheck.Size = new System.Drawing.Size(26, 32);
            this.htmlEditor.BtnSpellCheck.Text = "Check Spelling";
            // 
            // htmlEditor.BtnStrikeThrough
            // 
            this.htmlEditor.BtnStrikeThrough.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnStrikeThrough.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnStrikeThrough.Image")));
            this.htmlEditor.BtnStrikeThrough.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnStrikeThrough.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnStrikeThrough.Name = "_factoryBtnStrikeThrough";
            this.htmlEditor.BtnStrikeThrough.Size = new System.Drawing.Size(24, 26);
            this.htmlEditor.BtnStrikeThrough.Text = "Strike Thru";
            // 
            // htmlEditor.BtnSubscript
            // 
            this.htmlEditor.BtnSubscript.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnSubscript.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnSubscript.Image")));
            this.htmlEditor.BtnSubscript.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnSubscript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnSubscript.Name = "_factoryBtnSubscript";
            this.htmlEditor.BtnSubscript.Size = new System.Drawing.Size(27, 26);
            this.htmlEditor.BtnSubscript.Text = "Subscript";
            // 
            // htmlEditor.BtnSuperScript
            // 
            this.htmlEditor.BtnSuperScript.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnSuperScript.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnSuperScript.Image")));
            this.htmlEditor.BtnSuperScript.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnSuperScript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnSuperScript.Name = "_factoryBtnSuperScript";
            this.htmlEditor.BtnSuperScript.Size = new System.Drawing.Size(27, 26);
            this.htmlEditor.BtnSuperScript.Text = "Superscript";
            // 
            // htmlEditor.BtnSymbol
            // 
            this.htmlEditor.BtnSymbol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnSymbol.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnSymbol.Image")));
            this.htmlEditor.BtnSymbol.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnSymbol.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnSymbol.Name = "_factoryBtnSymbol";
            this.htmlEditor.BtnSymbol.Size = new System.Drawing.Size(23, 26);
            this.htmlEditor.BtnSymbol.Text = "Insert Symbols";
            // 
            // htmlEditor.BtnTable
            // 
            this.htmlEditor.BtnTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnTable.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnTable.Image")));
            this.htmlEditor.BtnTable.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnTable.Name = "_factoryBtnTable";
            this.htmlEditor.BtnTable.Size = new System.Drawing.Size(24, 26);
            this.htmlEditor.BtnTable.Text = "Table";
            // 
            // htmlEditor.BtnUnderline
            // 
            this.htmlEditor.BtnUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnUnderline.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnUnderline.Image")));
            this.htmlEditor.BtnUnderline.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnUnderline.Name = "_factoryBtnUnderline";
            this.htmlEditor.BtnUnderline.Size = new System.Drawing.Size(23, 32);
            this.htmlEditor.BtnUnderline.Text = "Underline";
            // 
            // htmlEditor.BtnUnOrderedList
            // 
            this.htmlEditor.BtnUnOrderedList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.htmlEditor.BtnUnOrderedList.Image = ((System.Drawing.Image)(resources.GetObject("htmlEditor.BtnUnOrderedList.Image")));
            this.htmlEditor.BtnUnOrderedList.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.htmlEditor.BtnUnOrderedList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.htmlEditor.BtnUnOrderedList.Name = "_factoryBtnUnOrderedList";
            this.htmlEditor.BtnUnOrderedList.Size = new System.Drawing.Size(24, 26);
            this.htmlEditor.BtnUnOrderedList.Text = "Bullet List";
            // 
            // htmlEditor.CmbFontName
            // 
            this.htmlEditor.CmbFontName.AddSystemFonts = true;
            this.htmlEditor.CmbFontName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.htmlEditor.CmbFontName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.htmlEditor.CmbFontName.MaxDropDownItems = 17;
            this.htmlEditor.CmbFontName.Name = "_factoryCmbFontName";
            this.htmlEditor.CmbFontName.Size = new System.Drawing.Size(114, 35);
            this.htmlEditor.CmbFontName.Text = "Arial";
            // 
            // htmlEditor.CmbFontSize
            // 
            this.htmlEditor.CmbFontSize.Name = "_factoryCmbFontSize";
            this.htmlEditor.CmbFontSize.Size = new System.Drawing.Size(114, 35);
            this.htmlEditor.CmbFontSize.Text = "12pt";
            // 
            // htmlEditor.CmbTitleInsert
            // 
            this.htmlEditor.CmbTitleInsert.Name = "_factoryCmbTitleInsert";
            this.htmlEditor.CmbTitleInsert.Size = new System.Drawing.Size(151, 29);
            this.htmlEditor.DefaultFontFamily = "Arial";
            this.htmlEditor.DocumentHtml = resources.GetString("htmlEditor.DocumentHtml");
            this.htmlEditor.EditorContextMenuStrip = null;
            this.htmlEditor.HeaderStyleContentElementID = "page_style";
            this.htmlEditor.HorizontalScroll = null;
            this.htmlEditor.Location = new System.Drawing.Point(25, 74);
            this.htmlEditor.Name = "htmlEditor";
            this.htmlEditor.Options.ConvertFileUrlsToLocalPaths = true;
            this.htmlEditor.Options.CustomDOCTYPE = null;
            this.htmlEditor.Options.FooterTagNavigatorFont = null;
            this.htmlEditor.Options.FooterTagNavigatorTextColor = System.Drawing.Color.Teal;
            this.htmlEditor.Options.FTPSettingsForRemoteResources.ConnectionMode = SpiceLogic.HtmlEditorControl.Domain.BOs.UserOptions.FTPSettings.ConnectionModes.Active;
            this.htmlEditor.Options.FTPSettingsForRemoteResources.Host = null;
            this.htmlEditor.Options.FTPSettingsForRemoteResources.Password = null;
            this.htmlEditor.Options.FTPSettingsForRemoteResources.Port = null;
            this.htmlEditor.Options.FTPSettingsForRemoteResources.RemoteFolderPath = null;
            this.htmlEditor.Options.FTPSettingsForRemoteResources.Timeout = 4000;
            this.htmlEditor.Options.FTPSettingsForRemoteResources.UrlOfTheRemoteFolderPath = null;
            this.htmlEditor.Options.FTPSettingsForRemoteResources.UserName = null;
            this.htmlEditor.Size = new System.Drawing.Size(598, 240);
            this.htmlEditor.SpellCheckOptions.CurlyUnderlineImageFilePath = null;
            dictionaryFileInfo1.AffixFilePath = null;
            dictionaryFileInfo1.DictionaryFilePath = null;
            dictionaryFileInfo1.EnableUserDictionary = true;
            dictionaryFileInfo1.UserDictionaryFilePath = null;
            this.htmlEditor.SpellCheckOptions.DictionaryFile = dictionaryFileInfo1;
            this.htmlEditor.SpellCheckOptions.FireInlineSpellCheckingOnKeyStroke = true;
            this.htmlEditor.SpellCheckOptions.NHunspellDllFolderPath = null;
            this.htmlEditor.SpellCheckOptions.WaitAlertMessage = "Searching next misspelled word..... (please wait)";
            this.htmlEditor.TabIndex = 15;
            // 
            // htmlEditor.TlstrpSeparator1
            // 
            this.htmlEditor.TlstrpSeparator1.Name = "_toolStripSeparator1";
            this.htmlEditor.TlstrpSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // htmlEditor.TlstrpSeparator2
            // 
            this.htmlEditor.TlstrpSeparator2.Name = "_toolStripSeparator2";
            this.htmlEditor.TlstrpSeparator2.Size = new System.Drawing.Size(6, 35);
            // 
            // htmlEditor.TlstrpSeparator3
            // 
            this.htmlEditor.TlstrpSeparator3.Name = "_toolStripSeparator3";
            this.htmlEditor.TlstrpSeparator3.Size = new System.Drawing.Size(6, 35);
            // 
            // htmlEditor.TlstrpSeparator4
            // 
            this.htmlEditor.TlstrpSeparator4.Name = "_toolStripSeparator4";
            this.htmlEditor.TlstrpSeparator4.Size = new System.Drawing.Size(6, 35);
            // 
            // htmlEditor.TlstrpSeparator5
            // 
            this.htmlEditor.TlstrpSeparator5.Name = "_toolStripSeparator5";
            this.htmlEditor.TlstrpSeparator5.Size = new System.Drawing.Size(6, 29);
            // 
            // htmlEditor.TlstrpSeparator6
            // 
            this.htmlEditor.TlstrpSeparator6.Name = "_toolStripSeparator6";
            this.htmlEditor.TlstrpSeparator6.Size = new System.Drawing.Size(6, 29);
            // 
            // htmlEditor.TlstrpSeparator7
            // 
            this.htmlEditor.TlstrpSeparator7.Name = "_toolStripSeparator7";
            this.htmlEditor.TlstrpSeparator7.Size = new System.Drawing.Size(6, 29);
            // 
            // htmlEditor.TlstrpSeparator8
            // 
            this.htmlEditor.TlstrpSeparator8.Name = "_toolStripSeparator8";
            this.htmlEditor.TlstrpSeparator8.Size = new System.Drawing.Size(6, 29);
            // 
            // htmlEditor.TlstrpSeparator9
            // 
            this.htmlEditor.TlstrpSeparator9.Name = "_toolStripSeparator9";
            this.htmlEditor.TlstrpSeparator9.Size = new System.Drawing.Size(6, 29);
            // 
            // htmlEditor.WinFormHtmlEditor_Toolbar1
            // 
            this.htmlEditor.Toolbar1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.htmlEditor.Toolbar1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.htmlEditor.Toolbar1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.htmlEditor.BtnNew,
            this.htmlEditor.BtnOpen,
            this.htmlEditor.BtnSave,
            this.htmlEditor.TlstrpSeparator1,
            this.htmlEditor.CmbFontName,
            this.htmlEditor.CmbFontSize,
            this.htmlEditor.TlstrpSeparator2,
            this.htmlEditor.BtnCut,
            this.htmlEditor.BtnCopy,
            this.htmlEditor.BtnPaste,
            this.htmlEditor.BtnPasteFromMSWord,
            this.htmlEditor.TlstrpSeparator3,
            this.htmlEditor.BtnBold,
            this.htmlEditor.BtnItalic,
            this.htmlEditor.BtnUnderline,
            this.htmlEditor.TlstrpSeparator4,
            this.htmlEditor.BtnFormatReset,
            this.htmlEditor.BtnFormatUndo,
            this.htmlEditor.BtnFormatRedo,
            this.htmlEditor.BtnPrint,
            this.htmlEditor.BtnSpellCheck,
            this.htmlEditor.BtnSearch});
            this.htmlEditor.Toolbar1.Location = new System.Drawing.Point(0, 0);
            this.htmlEditor.Toolbar1.Name = "WinFormHtmlEditor_Toolbar1";
            this.htmlEditor.Toolbar1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.htmlEditor.Toolbar1.Size = new System.Drawing.Size(598, 35);
            this.htmlEditor.Toolbar1.TabIndex = 0;
            // 
            // htmlEditor.WinFormHtmlEditor_Toolbar2
            // 
            this.htmlEditor.Toolbar2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.htmlEditor.Toolbar2.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.htmlEditor.Toolbar2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.htmlEditor.CmbTitleInsert,
            this.htmlEditor.BtnHighlightColor,
            this.htmlEditor.BtnFontColor,
            this.htmlEditor.TlstrpSeparator5,
            this.htmlEditor.BtnHyperlink,
            this.htmlEditor.BtnImage,
            this.htmlEditor.BtnInsertYouTubeVideo,
            this.htmlEditor.BtnTable,
            this.htmlEditor.BtnSymbol,
            this.htmlEditor.BtnHorizontalRule,
            this.htmlEditor.TlstrpSeparator6,
            this.htmlEditor.BtnOrderedList,
            this.htmlEditor.BtnUnOrderedList,
            this.htmlEditor.TlstrpSeparator7,
            this.htmlEditor.BtnAlignLeft,
            this.htmlEditor.BtnAlignCenter,
            this.htmlEditor.BtnAlignRight,
            this.htmlEditor.TlstrpSeparator8,
            this.htmlEditor.BtnOutdent,
            this.htmlEditor.BtnIndent,
            this.htmlEditor.TlstrpSeparator9,
            this.htmlEditor.BtnStrikeThrough,
            this.htmlEditor.BtnSuperScript,
            this.htmlEditor.BtnSubscript,
            this.htmlEditor.BtnBodyStyle});
            this.htmlEditor.Toolbar2.Location = new System.Drawing.Point(0, 35);
            this.htmlEditor.Toolbar2.Name = "WinFormHtmlEditor_Toolbar2";
            this.htmlEditor.Toolbar2.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.htmlEditor.Toolbar2.Size = new System.Drawing.Size(598, 29);
            this.htmlEditor.Toolbar2.TabIndex = 0;
            this.htmlEditor.ToolbarContextMenuStrip = null;
            // 
            // htmlEditor.WinFormHtmlEditor_ToolbarFooter
            // 
            this.htmlEditor.ToolbarFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.htmlEditor.ToolbarFooter.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.htmlEditor.ToolbarFooter.Location = new System.Drawing.Point(0, 205);
            this.htmlEditor.ToolbarFooter.Name = "WinFormHtmlEditor_ToolbarFooter";
            this.htmlEditor.ToolbarFooter.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.htmlEditor.ToolbarFooter.Size = new System.Drawing.Size(598, 35);
            this.htmlEditor.ToolbarFooter.TabIndex = 7;
            this.htmlEditor.VerticalScroll = null;
            this.htmlEditor.z__ignore = true;
            // 
            // TextEditTitle
            // 
            this.TextEditTitle.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.MediaInfoBindingSource, "TITLE", true));
            this.TextEditTitle.Location = new System.Drawing.Point(85, 13);
            this.TextEditTitle.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TextEditTitle.Name = "TextEditTitle";
            this.TextEditTitle.Properties.Tag = "";
            this.TextEditTitle.Size = new System.Drawing.Size(518, 20);
            this.TextEditTitle.TabIndex = 12;
            this.TextEditTitle.Enter += new System.EventHandler(this.enterControl);
            this.TextEditTitle.Leave += new System.EventHandler(this.TextEditTitle_Leave);
            // 
            // TextEditSubtitle
            // 
            this.TextEditSubtitle.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.MediaInfoBindingSource, "SUBTITLE", true));
            this.TextEditSubtitle.Location = new System.Drawing.Point(85, 39);
            this.TextEditSubtitle.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TextEditSubtitle.Name = "TextEditSubtitle";
            this.TextEditSubtitle.Properties.Tag = "";
            this.TextEditSubtitle.Size = new System.Drawing.Size(518, 20);
            this.TextEditSubtitle.TabIndex = 13;
            this.TextEditSubtitle.Enter += new System.EventHandler(this.enterControl);
            this.TextEditSubtitle.Leave += new System.EventHandler(this.TextEditSubtitle_Leave);
            // 
            // xtraTabPagePrimaryImages
            // 
            this.xtraTabPagePrimaryImages.AutoScroll = true;
            this.xtraTabPagePrimaryImages.Controls.Add(this.panelControlPrimaryImages);
            this.xtraTabPagePrimaryImages.Margin = new System.Windows.Forms.Padding(4);
            this.xtraTabPagePrimaryImages.Name = "xtraTabPagePrimaryImages";
            this.xtraTabPagePrimaryImages.Size = new System.Drawing.Size(643, 328);
            this.xtraTabPagePrimaryImages.Text = "Primary Images";
            // 
            // panelControlPrimaryImages
            // 
            this.panelControlPrimaryImages.Controls.Add(LabelCaption);
            this.panelControlPrimaryImages.Controls.Add(this.TextEditCaption);
            this.panelControlPrimaryImages.Controls.Add(this.xtraTabControlPictures);
            this.panelControlPrimaryImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlPrimaryImages.Location = new System.Drawing.Point(0, 0);
            this.panelControlPrimaryImages.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelControlPrimaryImages.Name = "panelControlPrimaryImages";
            this.panelControlPrimaryImages.Size = new System.Drawing.Size(643, 328);
            this.panelControlPrimaryImages.TabIndex = 0;
            // 
            // TextEditCaption
            // 
            this.TextEditCaption.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.MediaInfoBindingSource, "CAPTION", true));
            this.TextEditCaption.EnterMoveNextControl = true;
            this.TextEditCaption.Location = new System.Drawing.Point(92, 23);
            this.TextEditCaption.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TextEditCaption.Name = "TextEditCaption";
            this.TextEditCaption.Properties.Tag = "";
            this.TextEditCaption.Size = new System.Drawing.Size(575, 20);
            this.TextEditCaption.TabIndex = 15;
            this.TextEditCaption.Enter += new System.EventHandler(this.enterControl);
            this.TextEditCaption.Leave += new System.EventHandler(this.TextEditCaption_Leave);
            // 
            // xtraTabControlPictures
            // 
            this.xtraTabControlPictures.Location = new System.Drawing.Point(24, 58);
            this.xtraTabControlPictures.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.xtraTabControlPictures.Name = "xtraTabControlPictures";
            this.xtraTabControlPictures.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControlPictures.Size = new System.Drawing.Size(643, 325);
            this.xtraTabControlPictures.TabIndex = 2;
            this.xtraTabControlPictures.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage5,
            this.xtraTabPage6,
            this.xtraTabPage7});
            this.xtraTabControlPictures.TabStop = false;
            this.xtraTabControlPictures.Enter += new System.EventHandler(this.enterControl);
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.panelControlLowRes);
            this.xtraTabPage1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(637, 297);
            this.xtraTabPage1.Text = "Low Res";
            // 
            // panelControlLowRes
            // 
            this.panelControlLowRes.Controls.Add(this.labelControlSizeDisplay);
            this.panelControlLowRes.Controls.Add(this.labelControlSize);
            this.panelControlLowRes.Controls.Add(LabelImage1);
            this.panelControlLowRes.Controls.Add(this.ButtonCreateThumbnailLowRes);
            this.panelControlLowRes.Controls.Add(this.LabelPeview);
            this.panelControlLowRes.Controls.Add(this.pictureEditPreviewImage1);
            this.panelControlLowRes.Controls.Add(this.ButtonEditImage1LowRes);
            this.panelControlLowRes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlLowRes.Location = new System.Drawing.Point(0, 0);
            this.panelControlLowRes.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelControlLowRes.Name = "panelControlLowRes";
            this.panelControlLowRes.Size = new System.Drawing.Size(637, 297);
            this.panelControlLowRes.TabIndex = 0;
            // 
            // labelControlSizeDisplay
            // 
            this.labelControlSizeDisplay.Location = new System.Drawing.Point(71, 57);
            this.labelControlSizeDisplay.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControlSizeDisplay.Name = "labelControlSizeDisplay";
            this.labelControlSizeDisplay.Size = new System.Drawing.Size(0, 13);
            this.labelControlSizeDisplay.TabIndex = 7;
            // 
            // labelControlSize
            // 
            this.labelControlSize.Location = new System.Drawing.Point(13, 57);
            this.labelControlSize.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControlSize.Name = "labelControlSize";
            this.labelControlSize.Size = new System.Drawing.Size(19, 13);
            this.labelControlSize.TabIndex = 0;
            this.labelControlSize.Text = "Size";
            // 
            // ButtonCreateThumbnailLowRes
            // 
            this.ButtonCreateThumbnailLowRes.Location = new System.Drawing.Point(317, 85);
            this.ButtonCreateThumbnailLowRes.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
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
            this.LabelPeview.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LabelPeview.Name = "LabelPeview";
            this.LabelPeview.Size = new System.Drawing.Size(42, 13);
            this.LabelPeview.TabIndex = 0;
            this.LabelPeview.Text = "Preview:";
            // 
            // pictureEditPreviewImage1
            // 
            this.pictureEditPreviewImage1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEditPreviewImage1.Location = new System.Drawing.Point(67, 85);
            this.pictureEditPreviewImage1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureEditPreviewImage1.Name = "pictureEditPreviewImage1";
            this.pictureEditPreviewImage1.Size = new System.Drawing.Size(235, 174);
            this.pictureEditPreviewImage1.TabIndex = 2;
            // 
            // ButtonEditImage1LowRes
            // 
            this.ButtonEditImage1LowRes.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.MediaInfoBindingSource, "IMAGE1", true));
            this.ButtonEditImage1LowRes.Location = new System.Drawing.Point(67, 22);
            this.ButtonEditImage1LowRes.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ButtonEditImage1LowRes.Name = "ButtonEditImage1LowRes";
            this.ButtonEditImage1LowRes.Properties.Tag = "";
            this.ButtonEditImage1LowRes.Size = new System.Drawing.Size(551, 20);
            this.ButtonEditImage1LowRes.TabIndex = 16;
            this.ButtonEditImage1LowRes.TextChanged += new System.EventHandler(this.ButtonEditImage1LowRes_TextChanged);
            this.ButtonEditImage1LowRes.Enter += new System.EventHandler(this.enterControl);
            this.ButtonEditImage1LowRes.Leave += new System.EventHandler(this.ButtonEditImage1LowRes_Leave);
            // 
            // xtraTabPage5
            // 
            this.xtraTabPage5.Controls.Add(this.panelControlMedRes);
            this.xtraTabPage5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.xtraTabPage5.Name = "xtraTabPage5";
            this.xtraTabPage5.Size = new System.Drawing.Size(637, 297);
            this.xtraTabPage5.Text = "Medium Res";
            // 
            // panelControlMedRes
            // 
            this.panelControlMedRes.Controls.Add(this.labelControlSizeDisplay2);
            this.panelControlMedRes.Controls.Add(this.labelControlSize2);
            this.panelControlMedRes.Controls.Add(LabelImage2);
            this.panelControlMedRes.Controls.Add(this.labelControlPreview2);
            this.panelControlMedRes.Controls.Add(this.ButtonCreateThumbnailMedRes);
            this.panelControlMedRes.Controls.Add(this.pictureEditPreviewImage2);
            this.panelControlMedRes.Controls.Add(this.ButtonEditImage2MedRes);
            this.panelControlMedRes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlMedRes.Location = new System.Drawing.Point(0, 0);
            this.panelControlMedRes.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelControlMedRes.Name = "panelControlMedRes";
            this.panelControlMedRes.Size = new System.Drawing.Size(637, 297);
            this.panelControlMedRes.TabIndex = 0;
            // 
            // labelControlSizeDisplay2
            // 
            this.labelControlSizeDisplay2.Location = new System.Drawing.Point(73, 55);
            this.labelControlSizeDisplay2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControlSizeDisplay2.Name = "labelControlSizeDisplay2";
            this.labelControlSizeDisplay2.Size = new System.Drawing.Size(0, 13);
            this.labelControlSizeDisplay2.TabIndex = 9;
            // 
            // labelControlSize2
            // 
            this.labelControlSize2.Location = new System.Drawing.Point(13, 57);
            this.labelControlSize2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControlSize2.Name = "labelControlSize2";
            this.labelControlSize2.Size = new System.Drawing.Size(19, 13);
            this.labelControlSize2.TabIndex = 0;
            this.labelControlSize2.Text = "Size";
            // 
            // labelControlPreview2
            // 
            this.labelControlPreview2.Location = new System.Drawing.Point(13, 85);
            this.labelControlPreview2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControlPreview2.Name = "labelControlPreview2";
            this.labelControlPreview2.Size = new System.Drawing.Size(42, 13);
            this.labelControlPreview2.TabIndex = 0;
            this.labelControlPreview2.Text = "Preview:";
            // 
            // ButtonCreateThumbnailMedRes
            // 
            this.ButtonCreateThumbnailMedRes.Location = new System.Drawing.Point(317, 85);
            this.ButtonCreateThumbnailMedRes.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ButtonCreateThumbnailMedRes.Name = "ButtonCreateThumbnailMedRes";
            this.ButtonCreateThumbnailMedRes.Size = new System.Drawing.Size(114, 37);
            this.ButtonCreateThumbnailMedRes.TabIndex = 5;
            this.ButtonCreateThumbnailMedRes.TabStop = false;
            this.ButtonCreateThumbnailMedRes.Text = "Create Thumbnail";
            this.ButtonCreateThumbnailMedRes.Click += new System.EventHandler(this.ButtonCreateThumbnailMedRes_Click);
            // 
            // pictureEditPreviewImage2
            // 
            this.pictureEditPreviewImage2.Location = new System.Drawing.Point(67, 85);
            this.pictureEditPreviewImage2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureEditPreviewImage2.Name = "pictureEditPreviewImage2";
            this.pictureEditPreviewImage2.Size = new System.Drawing.Size(235, 174);
            this.pictureEditPreviewImage2.TabIndex = 3;
            // 
            // ButtonEditImage2MedRes
            // 
            this.ButtonEditImage2MedRes.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.MediaInfoBindingSource, "IMAGE2", true));
            this.ButtonEditImage2MedRes.Location = new System.Drawing.Point(67, 22);
            this.ButtonEditImage2MedRes.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ButtonEditImage2MedRes.Name = "ButtonEditImage2MedRes";
            this.ButtonEditImage2MedRes.Properties.Tag = "";
            this.ButtonEditImage2MedRes.Size = new System.Drawing.Size(551, 20);
            this.ButtonEditImage2MedRes.TabIndex = 17;
            this.ButtonEditImage2MedRes.TextChanged += new System.EventHandler(this.ButtonEditImage2MedRes_TextChanged);
            this.ButtonEditImage2MedRes.Enter += new System.EventHandler(this.enterControl);
            this.ButtonEditImage2MedRes.Leave += new System.EventHandler(this.ButtonEditImage2MidRes_Leave);
            // 
            // xtraTabPage6
            // 
            this.xtraTabPage6.Controls.Add(this.panelControlHighRes);
            this.xtraTabPage6.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.xtraTabPage6.Name = "xtraTabPage6";
            this.xtraTabPage6.Size = new System.Drawing.Size(637, 297);
            this.xtraTabPage6.Text = "High Res";
            // 
            // panelControlHighRes
            // 
            this.panelControlHighRes.Controls.Add(this.labelControlSizeDisplay3);
            this.panelControlHighRes.Controls.Add(this.labelControlSize3);
            this.panelControlHighRes.Controls.Add(LabelImage3);
            this.panelControlHighRes.Controls.Add(this.ButtonCreateThumbNailHighRes);
            this.panelControlHighRes.Controls.Add(this.LabelPreview3);
            this.panelControlHighRes.Controls.Add(this.pictureEditPreviewImage3);
            this.panelControlHighRes.Controls.Add(this.ButtonEditImage3HighRes);
            this.panelControlHighRes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlHighRes.Location = new System.Drawing.Point(0, 0);
            this.panelControlHighRes.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelControlHighRes.Name = "panelControlHighRes";
            this.panelControlHighRes.Size = new System.Drawing.Size(637, 297);
            this.panelControlHighRes.TabIndex = 0;
            // 
            // labelControlSizeDisplay3
            // 
            this.labelControlSizeDisplay3.Location = new System.Drawing.Point(73, 56);
            this.labelControlSizeDisplay3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControlSizeDisplay3.Name = "labelControlSizeDisplay3";
            this.labelControlSizeDisplay3.Size = new System.Drawing.Size(0, 13);
            this.labelControlSizeDisplay3.TabIndex = 9;
            // 
            // labelControlSize3
            // 
            this.labelControlSize3.Location = new System.Drawing.Point(13, 57);
            this.labelControlSize3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControlSize3.Name = "labelControlSize3";
            this.labelControlSize3.Size = new System.Drawing.Size(19, 13);
            this.labelControlSize3.TabIndex = 0;
            this.labelControlSize3.Text = "Size";
            // 
            // ButtonCreateThumbNailHighRes
            // 
            this.ButtonCreateThumbNailHighRes.Location = new System.Drawing.Point(317, 85);
            this.ButtonCreateThumbNailHighRes.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
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
            this.LabelPreview3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LabelPreview3.Name = "LabelPreview3";
            this.LabelPreview3.Size = new System.Drawing.Size(42, 13);
            this.LabelPreview3.TabIndex = 0;
            this.LabelPreview3.Text = "Preview:";
            // 
            // pictureEditPreviewImage3
            // 
            this.pictureEditPreviewImage3.Location = new System.Drawing.Point(67, 85);
            this.pictureEditPreviewImage3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureEditPreviewImage3.Name = "pictureEditPreviewImage3";
            this.pictureEditPreviewImage3.Size = new System.Drawing.Size(235, 174);
            this.pictureEditPreviewImage3.TabIndex = 3;
            // 
            // ButtonEditImage3HighRes
            // 
            this.ButtonEditImage3HighRes.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.MediaInfoBindingSource, "IMAGE3", true));
            this.ButtonEditImage3HighRes.Location = new System.Drawing.Point(67, 22);
            this.ButtonEditImage3HighRes.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ButtonEditImage3HighRes.Name = "ButtonEditImage3HighRes";
            this.ButtonEditImage3HighRes.Properties.Tag = "";
            this.ButtonEditImage3HighRes.Size = new System.Drawing.Size(552, 20);
            this.ButtonEditImage3HighRes.TabIndex = 18;
            this.ButtonEditImage3HighRes.TextChanged += new System.EventHandler(this.ButtonEditImage3HighRes_TextChanged);
            this.ButtonEditImage3HighRes.Enter += new System.EventHandler(this.enterControl);
            this.ButtonEditImage3HighRes.Leave += new System.EventHandler(this.ButtonEditImage3HighRes_Leave);
            // 
            // xtraTabPage7
            // 
            this.xtraTabPage7.Controls.Add(this.panelControlThumbNail);
            this.xtraTabPage7.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.xtraTabPage7.Name = "xtraTabPage7";
            this.xtraTabPage7.Size = new System.Drawing.Size(637, 297);
            this.xtraTabPage7.Text = "Thumbnail";
            // 
            // panelControlThumbNail
            // 
            this.panelControlThumbNail.Controls.Add(this.labelControlSizeDisplay4);
            this.panelControlThumbNail.Controls.Add(this.labelControlSize4);
            this.panelControlThumbNail.Controls.Add(LabelImage4);
            this.panelControlThumbNail.Controls.Add(this.LabelPreview4);
            this.panelControlThumbNail.Controls.Add(this.pictureEditPreviewImage4);
            this.panelControlThumbNail.Controls.Add(this.ButtonEditImage4ThmNail);
            this.panelControlThumbNail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlThumbNail.Location = new System.Drawing.Point(0, 0);
            this.panelControlThumbNail.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelControlThumbNail.Name = "panelControlThumbNail";
            this.panelControlThumbNail.Size = new System.Drawing.Size(637, 297);
            this.panelControlThumbNail.TabIndex = 0;
            // 
            // labelControlSizeDisplay4
            // 
            this.labelControlSizeDisplay4.Location = new System.Drawing.Point(77, 57);
            this.labelControlSizeDisplay4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControlSizeDisplay4.Name = "labelControlSizeDisplay4";
            this.labelControlSizeDisplay4.Size = new System.Drawing.Size(0, 13);
            this.labelControlSizeDisplay4.TabIndex = 9;
            // 
            // labelControlSize4
            // 
            this.labelControlSize4.Location = new System.Drawing.Point(13, 57);
            this.labelControlSize4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControlSize4.Name = "labelControlSize4";
            this.labelControlSize4.Size = new System.Drawing.Size(19, 13);
            this.labelControlSize4.TabIndex = 0;
            this.labelControlSize4.Text = "Size";
            // 
            // LabelPreview4
            // 
            this.LabelPreview4.Location = new System.Drawing.Point(13, 85);
            this.LabelPreview4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LabelPreview4.Name = "LabelPreview4";
            this.LabelPreview4.Size = new System.Drawing.Size(42, 13);
            this.LabelPreview4.TabIndex = 0;
            this.LabelPreview4.Text = "Preview:";
            // 
            // pictureEditPreviewImage4
            // 
            this.pictureEditPreviewImage4.Location = new System.Drawing.Point(67, 85);
            this.pictureEditPreviewImage4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureEditPreviewImage4.Name = "pictureEditPreviewImage4";
            this.pictureEditPreviewImage4.Size = new System.Drawing.Size(235, 174);
            this.pictureEditPreviewImage4.TabIndex = 3;
            // 
            // ButtonEditImage4ThmNail
            // 
            this.ButtonEditImage4ThmNail.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.MediaInfoBindingSource, "IMAGE4", true));
            this.ButtonEditImage4ThmNail.Location = new System.Drawing.Point(67, 22);
            this.ButtonEditImage4ThmNail.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ButtonEditImage4ThmNail.Name = "ButtonEditImage4ThmNail";
            this.ButtonEditImage4ThmNail.Properties.Tag = "";
            this.ButtonEditImage4ThmNail.Size = new System.Drawing.Size(547, 20);
            this.ButtonEditImage4ThmNail.TabIndex = 19;
            this.ButtonEditImage4ThmNail.TextChanged += new System.EventHandler(this.ButtonEditImage4ThmNail_TextChanged);
            this.ButtonEditImage4ThmNail.Enter += new System.EventHandler(this.enterControl);
            this.ButtonEditImage4ThmNail.Leave += new System.EventHandler(this.ButtonEditImage4ThmNail_Leave);
            // 
            // xtraTabPageAdditionalImages
            // 
            this.xtraTabPageAdditionalImages.Controls.Add(this.panelControl3);
            this.xtraTabPageAdditionalImages.Margin = new System.Windows.Forms.Padding(4);
            this.xtraTabPageAdditionalImages.Name = "xtraTabPageAdditionalImages";
            this.xtraTabPageAdditionalImages.Size = new System.Drawing.Size(643, 328);
            this.xtraTabPageAdditionalImages.Text = "Additional Images";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.GridControlAdditionalImages);
            this.panelControl3.Controls.Add(this.ButtonSaveChanges);
            this.panelControl3.Controls.Add(this.ButtonDelRow);
            this.panelControl3.Controls.Add(this.ButtonAddRow);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(643, 328);
            this.panelControl3.TabIndex = 0;
            // 
            // GridControlAdditionalImages
            // 
            this.GridControlAdditionalImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridControlAdditionalImages.CausesValidation = false;
            this.GridControlAdditionalImages.DataSource = this.ResourceBindingSource;
            this.GridControlAdditionalImages.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GridControlAdditionalImages.Location = new System.Drawing.Point(13, 8);
            this.GridControlAdditionalImages.MainView = this.GridViewAdditionalImages;
            this.GridControlAdditionalImages.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GridControlAdditionalImages.Name = "GridControlAdditionalImages";
            this.GridControlAdditionalImages.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit_Item,
            this.repositoryItemImageComboBoxTag,
            this.repositoryItemPopupContainerEditPreview,
            this.repositoryItemComboBoxImagePurpose});
            this.GridControlAdditionalImages.Size = new System.Drawing.Size(619, 257);
            this.GridControlAdditionalImages.TabIndex = 19;
            this.GridControlAdditionalImages.TabStop = false;
            this.GridControlAdditionalImages.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewAdditionalImages,
            this.gridView1});
            // 
            // ResourceBindingSource
            // 
            this.ResourceBindingSource.DataSource = typeof(FlexModel.RESOURCE);
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
            this.GridViewAdditionalImages.DetailHeight = 198;
            this.GridViewAdditionalImages.FixedLineWidth = 1;
            this.GridViewAdditionalImages.GridControl = this.GridControlAdditionalImages;
            this.GridViewAdditionalImages.Name = "GridViewAdditionalImages";
            this.GridViewAdditionalImages.OptionsView.ShowGroupPanel = false;
            this.GridViewAdditionalImages.OptionsView.ShowIndicator = false;
            // 
            // ColumnID1
            // 
            this.ColumnID1.FieldName = "ID";
            this.ColumnID1.MinWidth = 12;
            this.ColumnID1.Name = "ColumnID1";
            this.ColumnID1.Width = 45;
            // 
            // ColumnLinkTable
            // 
            this.ColumnLinkTable.FieldName = "LINK_TABLE";
            this.ColumnLinkTable.MinWidth = 12;
            this.ColumnLinkTable.Name = "ColumnLinkTable";
            this.ColumnLinkTable.Width = 45;
            // 
            // ColumnLinkValue
            // 
            this.ColumnLinkValue.FieldName = "LINK_VALUE";
            this.ColumnLinkValue.MinWidth = 12;
            this.ColumnLinkValue.Name = "ColumnLinkValue";
            this.ColumnLinkValue.Width = 45;
            // 
            // ColumnRecType
            // 
            this.ColumnRecType.FieldName = "RECTYPE";
            this.ColumnRecType.MinWidth = 12;
            this.ColumnRecType.Name = "ColumnRecType";
            this.ColumnRecType.Width = 45;
            // 
            // ColumnTag
            // 
            this.ColumnTag.Caption = "Resolution";
            this.ColumnTag.ColumnEdit = this.repositoryItemImageComboBoxTag;
            this.ColumnTag.FieldName = "TAG";
            this.ColumnTag.MinWidth = 12;
            this.ColumnTag.Name = "ColumnTag";
            this.ColumnTag.OptionsColumn.FixedWidth = true;
            this.ColumnTag.Visible = true;
            this.ColumnTag.VisibleIndex = 4;
            this.ColumnTag.Width = 60;
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
            this.ColumnItem.ColumnEdit = this.repositoryItemButtonEdit_Item;
            this.ColumnItem.FieldName = "ITEM";
            this.ColumnItem.MinWidth = 12;
            this.ColumnItem.Name = "ColumnItem";
            this.ColumnItem.Visible = true;
            this.ColumnItem.VisibleIndex = 1;
            this.ColumnItem.Width = 258;
            // 
            // repositoryItemButtonEdit_Item
            // 
            this.repositoryItemButtonEdit_Item.AutoHeight = false;
            this.repositoryItemButtonEdit_Item.Name = "repositoryItemButtonEdit_Item";
            // 
            // ColumnDesc
            // 
            this.ColumnDesc.Caption = "Caption";
            this.ColumnDesc.FieldName = "DESCRIPTION";
            this.ColumnDesc.MinWidth = 12;
            this.ColumnDesc.Name = "ColumnDesc";
            this.ColumnDesc.Visible = true;
            this.ColumnDesc.VisibleIndex = 2;
            this.ColumnDesc.Width = 410;
            // 
            // ColumnUserDec1
            // 
            this.ColumnUserDec1.FieldName = "USER_DEC1";
            this.ColumnUserDec1.MinWidth = 12;
            this.ColumnUserDec1.Name = "ColumnUserDec1";
            this.ColumnUserDec1.Width = 45;
            // 
            // ColumnUserDec2
            // 
            this.ColumnUserDec2.FieldName = "USER_DEC2";
            this.ColumnUserDec2.MinWidth = 12;
            this.ColumnUserDec2.Name = "ColumnUserDec2";
            this.ColumnUserDec2.Width = 45;
            // 
            // ColumnUserInt1
            // 
            this.ColumnUserInt1.FieldName = "USER_INT1";
            this.ColumnUserInt1.MinWidth = 12;
            this.ColumnUserInt1.Name = "ColumnUserInt1";
            this.ColumnUserInt1.Width = 45;
            // 
            // ColumnUserInt2
            // 
            this.ColumnUserInt2.FieldName = "USER_INT2";
            this.ColumnUserInt2.MinWidth = 12;
            this.ColumnUserInt2.Name = "ColumnUserInt2";
            this.ColumnUserInt2.Width = 45;
            // 
            // ColumnUserTxt1
            // 
            this.ColumnUserTxt1.Caption = "Purpose";
            this.ColumnUserTxt1.ColumnEdit = this.repositoryItemComboBoxImagePurpose;
            this.ColumnUserTxt1.FieldName = "USER_TXT1";
            this.ColumnUserTxt1.MinWidth = 12;
            this.ColumnUserTxt1.Name = "ColumnUserTxt1";
            this.ColumnUserTxt1.Visible = true;
            this.ColumnUserTxt1.VisibleIndex = 3;
            this.ColumnUserTxt1.Width = 208;
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
            this.ColumnUserTxt2.MinWidth = 12;
            this.ColumnUserTxt2.Name = "ColumnUserTxt2";
            this.ColumnUserTxt2.Width = 45;
            // 
            // ColumnUserTxt3
            // 
            this.ColumnUserTxt3.FieldName = "USER_TXT3";
            this.ColumnUserTxt3.MinWidth = 12;
            this.ColumnUserTxt3.Name = "ColumnUserTxt3";
            this.ColumnUserTxt3.Width = 45;
            // 
            // ColumnUserTxt4
            // 
            this.ColumnUserTxt4.FieldName = "USER_TXT4";
            this.ColumnUserTxt4.MinWidth = 12;
            this.ColumnUserTxt4.Name = "ColumnUserTxt4";
            this.ColumnUserTxt4.Width = 45;
            // 
            // ColumnUserDte1
            // 
            this.ColumnUserDte1.FieldName = "USER_DTE1";
            this.ColumnUserDte1.MinWidth = 12;
            this.ColumnUserDte1.Name = "ColumnUserDte1";
            this.ColumnUserDte1.Width = 45;
            // 
            // ColumnUserDte2
            // 
            this.ColumnUserDte2.FieldName = "USER_DTE2";
            this.ColumnUserDte2.MinWidth = 12;
            this.ColumnUserDte2.Name = "ColumnUserDte2";
            this.ColumnUserDte2.Width = 45;
            // 
            // gridColumnPreview
            // 
            this.gridColumnPreview.Caption = "Preview";
            this.gridColumnPreview.ColumnEdit = this.repositoryItemPopupContainerEditPreview;
            this.gridColumnPreview.MinWidth = 12;
            this.gridColumnPreview.Name = "gridColumnPreview";
            this.gridColumnPreview.OptionsColumn.FixedWidth = true;
            this.gridColumnPreview.Visible = true;
            this.gridColumnPreview.VisibleIndex = 0;
            this.gridColumnPreview.Width = 27;
            // 
            // repositoryItemPopupContainerEditPreview
            // 
            this.repositoryItemPopupContainerEditPreview.AutoHeight = false;
            this.repositoryItemPopupContainerEditPreview.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "Preview", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryItemPopupContainerEditPreview.Name = "repositoryItemPopupContainerEditPreview";
            this.repositoryItemPopupContainerEditPreview.PopupControl = this.popupContainerControlPreview;
            this.repositoryItemPopupContainerEditPreview.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemPopupContainerEditPreview.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemPopupContainerEditPreview_ButtonClick);
            // 
            // popupContainerControlPreview
            // 
            this.popupContainerControlPreview.Location = new System.Drawing.Point(1263, 851);
            this.popupContainerControlPreview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.popupContainerControlPreview.Name = "popupContainerControlPreview";
            this.popupContainerControlPreview.Size = new System.Drawing.Size(497, 386);
            this.popupContainerControlPreview.TabIndex = 0;
            // 
            // gridView1
            // 
            this.gridView1.DetailHeight = 198;
            this.gridView1.FixedLineWidth = 1;
            this.gridView1.GridControl = this.GridControlAdditionalImages;
            this.gridView1.Name = "gridView1";
            // 
            // ButtonSaveChanges
            // 
            this.ButtonSaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonSaveChanges.ImageOptions.Image = global::TraceForms.Properties.Resources.save;
            this.ButtonSaveChanges.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ButtonSaveChanges.Location = new System.Drawing.Point(110, 270);
            this.ButtonSaveChanges.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ButtonSaveChanges.Name = "ButtonSaveChanges";
            this.ButtonSaveChanges.Size = new System.Drawing.Size(38, 36);
            this.ButtonSaveChanges.TabIndex = 3;
            this.ButtonSaveChanges.TabStop = false;
            this.ButtonSaveChanges.Text = "simpleButton3";
            this.ButtonSaveChanges.Click += new System.EventHandler(this.ButtonSaveChanges_Click);
            // 
            // ButtonDelRow
            // 
            this.ButtonDelRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonDelRow.ImageOptions.Image = global::TraceForms.Properties.Resources.document_delete2;
            this.ButtonDelRow.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ButtonDelRow.Location = new System.Drawing.Point(71, 270);
            this.ButtonDelRow.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
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
            this.ButtonAddRow.Location = new System.Drawing.Point(29, 270);
            this.ButtonAddRow.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
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
            this.xtraTabPageDisplay.Size = new System.Drawing.Size(643, 328);
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
            this.panelControlDisplay.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelControlDisplay.Name = "panelControlDisplay";
            this.panelControlDisplay.Size = new System.Drawing.Size(643, 328);
            this.panelControlDisplay.TabIndex = 0;
            // 
            // ImageComboBoxEditSeverity
            // 
            this.ImageComboBoxEditSeverity.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.MediaInfoBindingSource, "Severity", true));
            this.ImageComboBoxEditSeverity.EnterMoveNextControl = true;
            this.ImageComboBoxEditSeverity.Location = new System.Drawing.Point(110, 100);
            this.ImageComboBoxEditSeverity.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
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
            this.ImageComboBoxEditSeverity.Enter += new System.EventHandler(this.enterControl);
            this.ImageComboBoxEditSeverity.Leave += new System.EventHandler(this.ImageComboBoxEditSeverity_Leave);
            // 
            // CheckEditConsent
            // 
            this.CheckEditConsent.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.MediaInfoBindingSource, "Consent", true));
            this.CheckEditConsent.EnterMoveNextControl = true;
            this.CheckEditConsent.Location = new System.Drawing.Point(109, 144);
            this.CheckEditConsent.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CheckEditConsent.Name = "CheckEditConsent";
            this.CheckEditConsent.Properties.Caption = "";
            this.CheckEditConsent.Size = new System.Drawing.Size(20, 19);
            this.CheckEditConsent.TabIndex = 22;
            this.CheckEditConsent.Modified += new System.EventHandler(this.CheckEditInactive_Modified);
            // 
            // CheckEditInactive
            // 
            this.CheckEditInactive.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.MediaInfoBindingSource, "Inactive", true));
            this.CheckEditInactive.EnterMoveNextControl = true;
            this.CheckEditInactive.Location = new System.Drawing.Point(109, 64);
            this.CheckEditInactive.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CheckEditInactive.Name = "CheckEditInactive";
            this.CheckEditInactive.Properties.Caption = "";
            this.CheckEditInactive.Size = new System.Drawing.Size(20, 19);
            this.CheckEditInactive.TabIndex = 20;
            this.CheckEditInactive.Modified += new System.EventHandler(this.CheckEditInactive_Modified);
            // 
            // GridControlMediaInfo
            // 
            this.GridControlMediaInfo.DataSource = this.MediaInfoBindingSource;
            this.GridControlMediaInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControlMediaInfo.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GridControlMediaInfo.Location = new System.Drawing.Point(0, 0);
            this.GridControlMediaInfo.MainView = this.GridViewMediaInfo;
            this.GridControlMediaInfo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GridControlMediaInfo.Name = "GridControlMediaInfo";
            this.GridControlMediaInfo.Size = new System.Drawing.Size(251, 586);
            this.GridControlMediaInfo.TabIndex = 32;
            this.GridControlMediaInfo.TabStop = false;
            this.GridControlMediaInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewMediaInfo});
            // 
            // GridViewMediaInfo
            // 
            this.GridViewMediaInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.GridViewMediaInfo.DetailHeight = 198;
            this.GridViewMediaInfo.FixedLineWidth = 1;
            this.GridViewMediaInfo.GridControl = this.GridControlMediaInfo;
            this.GridViewMediaInfo.Name = "GridViewMediaInfo";
            this.GridViewMediaInfo.OptionsBehavior.Editable = false;
            this.GridViewMediaInfo.OptionsView.ShowAutoFilterRow = true;
            this.GridViewMediaInfo.OptionsView.ShowGroupPanel = false;
            this.GridViewMediaInfo.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.GridViewMediaInfo_CellValueChanging);
            this.GridViewMediaInfo.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.GridViewMediaInfo_InvalidRowException);
            this.GridViewMediaInfo.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.GridViewMediaInfo_BeforeLeaveRow);
            // 
            // ColumnID
            // 
            this.ColumnID.FieldName = "ID";
            this.ColumnID.MinWidth = 12;
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.Width = 45;
            // 
            // ColumnLang
            // 
            this.ColumnLang.Caption = "Language";
            this.ColumnLang.FieldName = "LANG";
            this.ColumnLang.MinWidth = 12;
            this.ColumnLang.Name = "ColumnLang";
            this.ColumnLang.Visible = true;
            this.ColumnLang.VisibleIndex = 1;
            this.ColumnLang.Width = 42;
            // 
            // ColumnType
            // 
            this.ColumnType.Caption = "Type";
            this.ColumnType.FieldName = "TYPE";
            this.ColumnType.MinWidth = 12;
            this.ColumnType.Name = "ColumnType";
            this.ColumnType.Visible = true;
            this.ColumnType.VisibleIndex = 0;
            this.ColumnType.Width = 27;
            // 
            // ColumnCode
            // 
            this.ColumnCode.Caption = "Code";
            this.ColumnCode.FieldName = "CODE";
            this.ColumnCode.MinWidth = 12;
            this.ColumnCode.Name = "ColumnCode";
            this.ColumnCode.Visible = true;
            this.ColumnCode.VisibleIndex = 2;
            this.ColumnCode.Width = 45;
            // 
            // ColumnCategory
            // 
            this.ColumnCategory.Caption = "Category";
            this.ColumnCategory.FieldName = "CAT";
            this.ColumnCategory.MinWidth = 12;
            this.ColumnCategory.Name = "ColumnCategory";
            this.ColumnCategory.Width = 45;
            // 
            // ColumnRoom
            // 
            this.ColumnRoom.FieldName = "ROOM";
            this.ColumnRoom.MinWidth = 12;
            this.ColumnRoom.Name = "ColumnRoom";
            this.ColumnRoom.Width = 45;
            // 
            // ColumnSection
            // 
            this.ColumnSection.Caption = "Section";
            this.ColumnSection.FieldName = "SECTION";
            this.ColumnSection.MinWidth = 12;
            this.ColumnSection.Name = "ColumnSection";
            this.ColumnSection.Visible = true;
            this.ColumnSection.VisibleIndex = 3;
            this.ColumnSection.Width = 60;
            // 
            // ColumnTitle
            // 
            this.ColumnTitle.FieldName = "TITLE";
            this.ColumnTitle.MinWidth = 12;
            this.ColumnTitle.Name = "ColumnTitle";
            this.ColumnTitle.Width = 45;
            // 
            // ColumnSubtitle
            // 
            this.ColumnSubtitle.FieldName = "SUBTITLE";
            this.ColumnSubtitle.MinWidth = 12;
            this.ColumnSubtitle.Name = "ColumnSubtitle";
            this.ColumnSubtitle.Width = 45;
            // 
            // ColumnText
            // 
            this.ColumnText.FieldName = "TEXT";
            this.ColumnText.MinWidth = 12;
            this.ColumnText.Name = "ColumnText";
            this.ColumnText.Width = 45;
            // 
            // ColumnCaption
            // 
            this.ColumnCaption.FieldName = "CAPTION";
            this.ColumnCaption.MinWidth = 12;
            this.ColumnCaption.Name = "ColumnCaption";
            this.ColumnCaption.Width = 45;
            // 
            // ColumnImage1
            // 
            this.ColumnImage1.FieldName = "IMAGE1";
            this.ColumnImage1.MinWidth = 12;
            this.ColumnImage1.Name = "ColumnImage1";
            this.ColumnImage1.Width = 45;
            // 
            // ColumnImage2
            // 
            this.ColumnImage2.FieldName = "IMAGE2";
            this.ColumnImage2.MinWidth = 12;
            this.ColumnImage2.Name = "ColumnImage2";
            this.ColumnImage2.Width = 45;
            // 
            // ColumnImage3
            // 
            this.ColumnImage3.FieldName = "IMAGE3";
            this.ColumnImage3.MinWidth = 12;
            this.ColumnImage3.Name = "ColumnImage3";
            this.ColumnImage3.Width = 45;
            // 
            // ColumnInactive
            // 
            this.ColumnInactive.FieldName = "Inactive";
            this.ColumnInactive.MinWidth = 12;
            this.ColumnInactive.Name = "ColumnInactive";
            this.ColumnInactive.Width = 45;
            // 
            // ColumnSvcDateStart
            // 
            this.ColumnSvcDateStart.FieldName = "SvcDate_Start";
            this.ColumnSvcDateStart.MinWidth = 12;
            this.ColumnSvcDateStart.Name = "ColumnSvcDateStart";
            this.ColumnSvcDateStart.Width = 45;
            // 
            // ColumnSvcDateEnd
            // 
            this.ColumnSvcDateEnd.FieldName = "SvcDate_End";
            this.ColumnSvcDateEnd.MinWidth = 12;
            this.ColumnSvcDateEnd.Name = "ColumnSvcDateEnd";
            this.ColumnSvcDateEnd.Width = 45;
            // 
            // ColumnAgency
            // 
            this.ColumnAgency.FieldName = "Agency";
            this.ColumnAgency.MinWidth = 12;
            this.ColumnAgency.Name = "ColumnAgency";
            this.ColumnAgency.Width = 45;
            // 
            // ColumnInhouse
            // 
            this.ColumnInhouse.FieldName = "Inhouse";
            this.ColumnInhouse.MinWidth = 12;
            this.ColumnInhouse.Name = "ColumnInhouse";
            this.ColumnInhouse.Width = 45;
            // 
            // ColumnChgDate
            // 
            this.ColumnChgDate.FieldName = "ChgDate";
            this.ColumnChgDate.MinWidth = 12;
            this.ColumnChgDate.Name = "ColumnChgDate";
            this.ColumnChgDate.Width = 45;
            // 
            // ColumnImage4
            // 
            this.ColumnImage4.FieldName = "IMAGE4";
            this.ColumnImage4.MinWidth = 12;
            this.ColumnImage4.Name = "ColumnImage4";
            this.ColumnImage4.Width = 45;
            // 
            // ColumnSeverity
            // 
            this.ColumnSeverity.FieldName = "Severity";
            this.ColumnSeverity.MinWidth = 12;
            this.ColumnSeverity.Name = "ColumnSeverity";
            this.ColumnSeverity.Width = 45;
            // 
            // ColumnConsent
            // 
            this.ColumnConsent.FieldName = "Consent";
            this.ColumnConsent.MinWidth = 12;
            this.ColumnConsent.Name = "ColumnConsent";
            this.ColumnConsent.Width = 45;
            // 
            // ColumnMediaRptItems
            // 
            this.ColumnMediaRptItems.FieldName = "MediaRptItems";
            this.ColumnMediaRptItems.MinWidth = 12;
            this.ColumnMediaRptItems.Name = "ColumnMediaRptItems";
            this.ColumnMediaRptItems.Width = 45;
            // 
            // ComboBoxEditType
            // 
            this.ComboBoxEditType.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.MediaInfoBindingSource, "TYPE", true));
            this.ComboBoxEditType.Location = new System.Drawing.Point(68, 9);
            this.ComboBoxEditType.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ComboBoxEditType.Name = "ComboBoxEditType";
            this.ComboBoxEditType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ComboBoxEditType.Properties.Items.AddRange(new object[] {
            "",
            "HTL",
            "OPT",
            "PKG",
            "CAR",
            "CRU",
            "AIR",
            "CTY",
            "WAY",
            "HDR"});
            this.ComboBoxEditType.Size = new System.Drawing.Size(133, 20);
            this.ComboBoxEditType.TabIndex = 1;
            this.ComboBoxEditType.TextChanged += new System.EventHandler(this.ComboBoxEditType_TextChanged);
            this.ComboBoxEditType.Enter += new System.EventHandler(this.enterControl);
            this.ComboBoxEditType.Leave += new System.EventHandler(this.ComboBoxEditType_Leave);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 31);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.GridControlMediaInfo);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.AutoScroll = true;
            this.splitContainerControl1.Panel2.Controls.Add(this.gridLookUpEditProduct);
            this.splitContainerControl1.Panel2.Controls.Add(this.buttonEditResEndDate);
            this.splitContainerControl1.Panel2.Controls.Add(label1);
            this.splitContainerControl1.Panel2.Controls.Add(label2);
            this.splitContainerControl1.Panel2.Controls.Add(this.buttonEditResStartDate);
            this.splitContainerControl1.Panel2.Controls.Add(this.checkEditAllCategory);
            this.splitContainerControl1.Panel2.Controls.Add(this.checkEditAllAgency);
            this.splitContainerControl1.Panel2.Controls.Add(this.ImageComboBoxEditAgency);
            this.splitContainerControl1.Panel2.Controls.Add(this.ImageComboBoxEditSection);
            this.splitContainerControl1.Panel2.Controls.Add(this.ImageComboBoxEditLang);
            this.splitContainerControl1.Panel2.Controls.Add(this.LabelChgDate);
            this.splitContainerControl1.Panel2.Controls.Add(this.LabelChangeDate);
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraTabControlMediaInfo);
            this.splitContainerControl1.Panel2.Controls.Add(LabelAgency);
            this.splitContainerControl1.Panel2.Controls.Add(this.ComboBoxEditType);
            this.splitContainerControl1.Panel2.Controls.Add(LabelCategory);
            this.splitContainerControl1.Panel2.Controls.Add(LabelCode);
            this.splitContainerControl1.Panel2.Controls.Add(this.CheckEditInhouse);
            this.splitContainerControl1.Panel2.Controls.Add(LabelLanguage);
            this.splitContainerControl1.Panel2.Controls.Add(LabelType);
            this.splitContainerControl1.Panel2.Controls.Add(LabelSection);
            this.splitContainerControl1.Panel2.Controls.Add(this.ButtonEditsvcEndDate);
            this.splitContainerControl1.Panel2.Controls.Add(LabelsvcStartDate);
            this.splitContainerControl1.Panel2.Controls.Add(LabelsvcEndDate);
            this.splitContainerControl1.Panel2.Controls.Add(this.ButtonEditsvcStartDate);
            this.splitContainerControl1.Panel2.Controls.Add(this.ImageComboBoxEditCategory);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(934, 586);
            this.splitContainerControl1.SplitterPosition = 251;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridLookUpEditProduct
            // 
            this.gridLookUpEditProduct.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.MediaInfoBindingSource, "CODE", true));
            this.gridLookUpEditProduct.Location = new System.Drawing.Point(68, 55);
            this.gridLookUpEditProduct.Margin = new System.Windows.Forms.Padding(2);
            this.gridLookUpEditProduct.Name = "gridLookUpEditProduct";
            this.gridLookUpEditProduct.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEditProduct.Properties.DataSource = this.bindingSourceCodeNameProduct;
            this.gridLookUpEditProduct.Properties.DisplayMember = "DisplayName";
            this.gridLookUpEditProduct.Properties.ImmediatePopup = true;
            this.gridLookUpEditProduct.Properties.NullText = "";
            this.gridLookUpEditProduct.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.gridLookUpEditProduct.Properties.PopupView = this.gridLookUpEditProductView;
            this.gridLookUpEditProduct.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.gridLookUpEditProduct.Properties.ValueMember = "Code";
            this.gridLookUpEditProduct.Size = new System.Drawing.Size(277, 20);
            this.gridLookUpEditProduct.TabIndex = 3;
            this.gridLookUpEditProduct.Enter += new System.EventHandler(this.enterControl);
            this.gridLookUpEditProduct.Leave += new System.EventHandler(this.ImageComboBoxEditCode_Leave);
            // 
            // bindingSourceCodeNameProduct
            // 
            this.bindingSourceCodeNameProduct.DataSource = typeof(TraceForms.CodeName);
            // 
            // gridLookUpEditProductView
            // 
            this.gridLookUpEditProductView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCodeProduct,
            this.colNameProduct,
            this.colDisplayNameProduct});
            this.gridLookUpEditProductView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEditProductView.Name = "gridLookUpEditProductView";
            this.gridLookUpEditProductView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEditProductView.OptionsView.ShowGroupPanel = false;
            this.gridLookUpEditProductView.OptionsView.ShowIndicator = false;
            // 
            // colCodeProduct
            // 
            this.colCodeProduct.FieldName = "Code";
            this.colCodeProduct.Name = "colCodeProduct";
            this.colCodeProduct.Visible = true;
            this.colCodeProduct.VisibleIndex = 0;
            this.colCodeProduct.Width = 404;
            // 
            // colNameProduct
            // 
            this.colNameProduct.FieldName = "Name";
            this.colNameProduct.Name = "colNameProduct";
            this.colNameProduct.Visible = true;
            this.colNameProduct.VisibleIndex = 1;
            this.colNameProduct.Width = 1427;
            // 
            // colDisplayNameProduct
            // 
            this.colDisplayNameProduct.FieldName = "DisplayName";
            this.colDisplayNameProduct.Name = "colDisplayNameProduct";
            this.colDisplayNameProduct.OptionsColumn.ReadOnly = true;
            // 
            // buttonEditResEndDate
            // 
            this.buttonEditResEndDate.CausesValidation = false;
            this.buttonEditResEndDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.MediaInfoBindingSource, "ResDate_End", true));
            this.buttonEditResEndDate.Location = new System.Drawing.Point(313, 174);
            this.buttonEditResEndDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonEditResEndDate.Name = "buttonEditResEndDate";
            this.buttonEditResEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.buttonEditResEndDate.Size = new System.Drawing.Size(100, 20);
            this.buttonEditResEndDate.TabIndex = 40;
            this.buttonEditResEndDate.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEditResEndDate_ButtonClick);
            this.buttonEditResEndDate.Enter += new System.EventHandler(this.enterControl);
            this.buttonEditResEndDate.Leave += new System.EventHandler(this.DateEditResEndDate_Leave);
            // 
            // buttonEditResStartDate
            // 
            this.buttonEditResStartDate.CausesValidation = false;
            this.buttonEditResStartDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.MediaInfoBindingSource, "ResDate_Start", true));
            this.buttonEditResStartDate.Location = new System.Drawing.Point(144, 174);
            this.buttonEditResStartDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonEditResStartDate.Name = "buttonEditResStartDate";
            this.buttonEditResStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.buttonEditResStartDate.Size = new System.Drawing.Size(100, 20);
            this.buttonEditResStartDate.TabIndex = 39;
            this.buttonEditResStartDate.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEditResStartDate_ButtonClick);
            this.buttonEditResStartDate.Enter += new System.EventHandler(this.enterControl);
            this.buttonEditResStartDate.Leave += new System.EventHandler(this.DateEditResStartDate_Leave);
            // 
            // checkEditAllCategory
            // 
            this.checkEditAllCategory.Location = new System.Drawing.Point(352, 126);
            this.checkEditAllCategory.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkEditAllCategory.Name = "checkEditAllCategory";
            this.checkEditAllCategory.Properties.Caption = "All";
            this.checkEditAllCategory.Size = new System.Drawing.Size(41, 19);
            this.checkEditAllCategory.TabIndex = 8;
            // 
            // checkEditAllAgency
            // 
            this.checkEditAllAgency.Location = new System.Drawing.Point(352, 105);
            this.checkEditAllAgency.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkEditAllAgency.Name = "checkEditAllAgency";
            this.checkEditAllAgency.Properties.Caption = "All";
            this.checkEditAllAgency.Size = new System.Drawing.Size(38, 19);
            this.checkEditAllAgency.TabIndex = 6;
            // 
            // ImageComboBoxEditAgency
            // 
            this.ImageComboBoxEditAgency.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.MediaInfoBindingSource, "Agency", true));
            this.ImageComboBoxEditAgency.Location = new System.Drawing.Point(68, 102);
            this.ImageComboBoxEditAgency.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ImageComboBoxEditAgency.Name = "ImageComboBoxEditAgency";
            this.ImageComboBoxEditAgency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ImageComboBoxEditAgency.Size = new System.Drawing.Size(277, 20);
            this.ImageComboBoxEditAgency.TabIndex = 5;
            this.ImageComboBoxEditAgency.TextChanged += new System.EventHandler(this.ImageComboBoxEditAgency_TextChanged);
            this.ImageComboBoxEditAgency.Enter += new System.EventHandler(this.enterControl);
            this.ImageComboBoxEditAgency.Leave += new System.EventHandler(this.ImageComboBoxEditAgency_Leave);
            // 
            // ImageComboBoxEditSection
            // 
            this.ImageComboBoxEditSection.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.MediaInfoBindingSource, "SECTION", true));
            this.ImageComboBoxEditSection.Location = new System.Drawing.Point(68, 79);
            this.ImageComboBoxEditSection.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ImageComboBoxEditSection.Name = "ImageComboBoxEditSection";
            this.ImageComboBoxEditSection.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ImageComboBoxEditSection.Size = new System.Drawing.Size(277, 20);
            this.ImageComboBoxEditSection.TabIndex = 4;
            this.ImageComboBoxEditSection.Enter += new System.EventHandler(this.enterControl);
            this.ImageComboBoxEditSection.Leave += new System.EventHandler(this.ImageComboBoxEditSection_Leave);
            // 
            // ImageComboBoxEditLang
            // 
            this.ImageComboBoxEditLang.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.MediaInfoBindingSource, "LANG", true));
            this.ImageComboBoxEditLang.Location = new System.Drawing.Point(68, 32);
            this.ImageComboBoxEditLang.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ImageComboBoxEditLang.Name = "ImageComboBoxEditLang";
            this.ImageComboBoxEditLang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ImageComboBoxEditLang.Size = new System.Drawing.Size(277, 20);
            this.ImageComboBoxEditLang.TabIndex = 2;
            this.ImageComboBoxEditLang.Enter += new System.EventHandler(this.enterControl);
            this.ImageComboBoxEditLang.Leave += new System.EventHandler(this.ImageComboBoxEditLang_Leave);
            // 
            // LabelChgDate
            // 
            this.LabelChgDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.MediaInfoBindingSource, "ChgDate", true));
            this.LabelChgDate.Location = new System.Drawing.Point(281, 11);
            this.LabelChgDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LabelChgDate.Name = "LabelChgDate";
            this.LabelChgDate.Size = new System.Drawing.Size(3, 13);
            this.LabelChgDate.TabIndex = 36;
            this.LabelChgDate.Text = " ";
            // 
            // LabelChangeDate
            // 
            this.LabelChangeDate.Location = new System.Drawing.Point(211, 11);
            this.LabelChangeDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LabelChangeDate.Name = "LabelChangeDate";
            this.LabelChangeDate.Size = new System.Drawing.Size(63, 13);
            this.LabelChangeDate.TabIndex = 0;
            this.LabelChangeDate.Text = "Change Date";
            // 
            // ImageComboBoxEditCategory
            // 
            this.ImageComboBoxEditCategory.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.MediaInfoBindingSource, "CAT", true));
            this.ImageComboBoxEditCategory.Location = new System.Drawing.Point(68, 125);
            this.ImageComboBoxEditCategory.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ImageComboBoxEditCategory.Name = "ImageComboBoxEditCategory";
            this.ImageComboBoxEditCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ImageComboBoxEditCategory.Properties.ImmediatePopup = true;
            this.ImageComboBoxEditCategory.Properties.MaxLength = 16;
            this.ImageComboBoxEditCategory.Properties.NullText = "";
            this.ImageComboBoxEditCategory.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.ImageComboBoxEditCategory.Properties.PopupSizeable = false;
            this.ImageComboBoxEditCategory.Properties.PopupView = this.gridLookUpEdit1View;
            this.ImageComboBoxEditCategory.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ImageComboBoxEditCategory.Size = new System.Drawing.Size(277, 20);
            this.ImageComboBoxEditCategory.TabIndex = 7;
            this.ImageComboBoxEditCategory.TextChanged += new System.EventHandler(this.ImageComboBoxEditCategory_TextChanged);
            this.ImageComboBoxEditCategory.Enter += new System.EventHandler(this.enterControl);
            this.ImageComboBoxEditCategory.Leave += new System.EventHandler(this.ImageComboBoxEditCategory_Leave);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsBehavior.AutoPopulateColumns = false;
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowColumnHeaders = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.gridLookUpEdit1View.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridLookUpEdit1View.OptionsView.ShowIndicator = false;
            // 
            // LabelStatus
            // 
            this.LabelStatus.Location = new System.Drawing.Point(24, 5);
            this.LabelStatus.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(0, 13);
            this.LabelStatus.TabIndex = 38;
            // 
            // panelControlStatus
            // 
            this.panelControlStatus.Appearance.Options.UseTextOptions = true;
            this.panelControlStatus.ContentImage = ((System.Drawing.Image)(resources.GetObject("panelControlStatus.ContentImage")));
            this.panelControlStatus.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.panelControlStatus.Controls.Add(this.labelControl1);
            this.panelControlStatus.Controls.Add(this.LabelStatus);
            this.panelControlStatus.Location = new System.Drawing.Point(391, 3);
            this.panelControlStatus.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelControlStatus.Name = "panelControlStatus";
            this.panelControlStatus.Size = new System.Drawing.Size(120, 25);
            this.panelControlStatus.TabIndex = 39;
            this.panelControlStatus.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(30, 5);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(0, 13);
            this.labelControl1.TabIndex = 5;
            // 
            // pictureEditPreviewAddImg
            // 
            this.pictureEditPreviewAddImg.Location = new System.Drawing.Point(53, 35);
            this.pictureEditPreviewAddImg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureEditPreviewAddImg.Name = "pictureEditPreviewAddImg";
            this.pictureEditPreviewAddImg.Size = new System.Drawing.Size(391, 307);
            this.pictureEditPreviewAddImg.TabIndex = 3;
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barTools,
            this.bar3});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemNew,
            this.barButtonItemDelete,
            this.barButtonItemSave,
            this.barButtonItemClone,
            this.barButtonItemExpand,
            this.barSubItemReports,
            this.barButtonItemReportsContainingSection,
            this.barButtonItemAddToReports,
            this.barButtonItemRemoveFromReports,
            this.barButtonItemCreateNewReports});
            this.barManager.MaxItemId = 10;
            this.barManager.StatusBar = this.bar3;
            // 
            // barTools
            // 
            this.barTools.BarName = "Tools";
            this.barTools.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.barTools.DockCol = 0;
            this.barTools.DockRow = 0;
            this.barTools.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItemNew, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemClone),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemExpand),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItemReports)});
            this.barTools.OptionsBar.AllowQuickCustomization = false;
            this.barTools.OptionsBar.DrawDragBorder = false;
            this.barTools.OptionsBar.UseWholeRow = true;
            this.barTools.Text = "Tools";
            // 
            // barButtonItemNew
            // 
            this.barButtonItemNew.Caption = "Add";
            this.barButtonItemNew.Id = 0;
            this.barButtonItemNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemNew.ImageOptions.Image")));
            this.barButtonItemNew.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemNew.ImageOptions.LargeImage")));
            this.barButtonItemNew.Name = "barButtonItemNew";
            this.barButtonItemNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemNew_ItemClick);
            // 
            // barButtonItemDelete
            // 
            this.barButtonItemDelete.Caption = "Delete";
            this.barButtonItemDelete.Id = 1;
            this.barButtonItemDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemDelete.ImageOptions.Image")));
            this.barButtonItemDelete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemDelete.ImageOptions.LargeImage")));
            this.barButtonItemDelete.Name = "barButtonItemDelete";
            this.barButtonItemDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemDelete_ItemClick);
            // 
            // barButtonItemSave
            // 
            this.barButtonItemSave.Caption = "Save";
            this.barButtonItemSave.Id = 2;
            this.barButtonItemSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemSave.ImageOptions.Image")));
            this.barButtonItemSave.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemSave.ImageOptions.LargeImage")));
            this.barButtonItemSave.Name = "barButtonItemSave";
            this.barButtonItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSave_ItemClick);
            // 
            // barButtonItemClone
            // 
            this.barButtonItemClone.Caption = "Clone";
            this.barButtonItemClone.Id = 3;
            this.barButtonItemClone.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemClone.ImageOptions.Image")));
            this.barButtonItemClone.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemClone.ImageOptions.LargeImage")));
            this.barButtonItemClone.Name = "barButtonItemClone";
            this.barButtonItemClone.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemClone_ItemClick);
            // 
            // barButtonItemExpand
            // 
            this.barButtonItemExpand.Caption = "Expand";
            this.barButtonItemExpand.Id = 4;
            this.barButtonItemExpand.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemExpand.ImageOptions.Image")));
            this.barButtonItemExpand.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemExpand.ImageOptions.LargeImage")));
            this.barButtonItemExpand.Name = "barButtonItemExpand";
            this.barButtonItemExpand.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemExpand_ItemClick);
            // 
            // barSubItemReports
            // 
            this.barSubItemReports.Caption = "Reports";
            this.barSubItemReports.Id = 5;
            this.barSubItemReports.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemReportsContainingSection),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemAddToReports),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemRemoveFromReports),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemCreateNewReports)});
            this.barSubItemReports.Name = "barSubItemReports";
            // 
            // barButtonItemReportsContainingSection
            // 
            this.barButtonItemReportsContainingSection.Caption = "Reports containing this section";
            this.barButtonItemReportsContainingSection.Id = 6;
            this.barButtonItemReportsContainingSection.Name = "barButtonItemReportsContainingSection";
            this.barButtonItemReportsContainingSection.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemReportsContainingSection_ItemClick);
            // 
            // barButtonItemAddToReports
            // 
            this.barButtonItemAddToReports.Caption = "Add to reports";
            this.barButtonItemAddToReports.Id = 7;
            this.barButtonItemAddToReports.Name = "barButtonItemAddToReports";
            this.barButtonItemAddToReports.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemAddToReports_ItemClick);
            // 
            // barButtonItemRemoveFromReports
            // 
            this.barButtonItemRemoveFromReports.Caption = "Remove from reports";
            this.barButtonItemRemoveFromReports.Id = 8;
            this.barButtonItemRemoveFromReports.Name = "barButtonItemRemoveFromReports";
            this.barButtonItemRemoveFromReports.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemRemoveFromReports_ItemClick);
            // 
            // barButtonItemCreateNewReports
            // 
            this.barButtonItemCreateNewReports.Caption = "Create new reports";
            this.barButtonItemCreateNewReports.Id = 9;
            this.barButtonItemCreateNewReports.Name = "barButtonItemCreateNewReports";
            this.barButtonItemCreateNewReports.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemCreateNewReports_ItemClick);
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
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlTop.Size = new System.Drawing.Size(934, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 617);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlBottom.Size = new System.Drawing.Size(934, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 586);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(934, 31);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 586);
            // 
            // mediaInfoMaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 640);
            this.Controls.Add(this.panelControlStatus);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MinimizeBox = false;
            this.Name = "mediaInfoMaint";
            this.ShowInTaskbar = false;
            this.Text = "Media Information Maintenance";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mediaInfoMaint_FormClosing);
            this.Shown += new System.EventHandler(this.mediaInfoMaint_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mediaInfoMaint_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.MediaInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEditsvcStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEditsvcEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditInhouse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlMediaInfo)).EndInit();
            this.xtraTabControlMediaInfo.ResumeLayout(false);
            this.xtraTabPageText.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlText)).EndInit();
            this.panelControlText.ResumeLayout(false);
            this.panelControlText.PerformLayout();
            this.htmlEditor.Toolbar1.ResumeLayout(false);
            this.htmlEditor.Toolbar1.PerformLayout();
            this.htmlEditor.Toolbar2.ResumeLayout(false);
            this.htmlEditor.Toolbar2.PerformLayout();
            this.htmlEditor.ResumeLayout(false);
            this.htmlEditor.PerformLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditPreviewImage1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEditImage1LowRes.Properties)).EndInit();
            this.xtraTabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlMedRes)).EndInit();
            this.panelControlMedRes.ResumeLayout(false);
            this.panelControlMedRes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditPreviewImage2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEditImage2MedRes.Properties)).EndInit();
            this.xtraTabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlHighRes)).EndInit();
            this.panelControlHighRes.ResumeLayout(false);
            this.panelControlHighRes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditPreviewImage3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEditImage3HighRes.Properties)).EndInit();
            this.xtraTabPage7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlThumbNail)).EndInit();
            this.panelControlThumbNail.ResumeLayout(false);
            this.panelControlThumbNail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditPreviewImage4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEditImage4ThmNail.Properties)).EndInit();
            this.xtraTabPageAdditionalImages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridControlAdditionalImages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResourceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewAdditionalImages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBoxTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit_Item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxImagePurpose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEditPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControlPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.xtraTabPageDisplay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlDisplay)).EndInit();
            this.panelControlDisplay.ResumeLayout(false);
            this.panelControlDisplay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditSeverity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditConsent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEditInactive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlMediaInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewMediaInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxEditType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCodeNameProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditProductView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditResEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditResStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditAllCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditAllAgency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditAgency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditSection.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditLang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageComboBoxEditCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlStatus)).EndInit();
            this.panelControlStatus.ResumeLayout(false);
            this.panelControlStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditPreviewAddImg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource MediaInfoBindingSource;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.ComboBoxEdit ComboBoxEditType;
        private DevExpress.XtraEditors.ButtonEdit ButtonEditsvcStartDate;
        private DevExpress.XtraEditors.ButtonEdit ButtonEditsvcEndDate;
        private DevExpress.XtraEditors.CheckEdit CheckEditInhouse;
        private DevExpress.XtraTab.XtraTabControl xtraTabControlMediaInfo;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageText;
        private DevExpress.XtraTab.XtraTabPage xtraTabPagePrimaryImages;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageAdditionalImages;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageDisplay;
        private DevExpress.XtraGrid.GridControl GridControlMediaInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewMediaInfo;
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
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.LabelControl LabelChgDate;
        private DevExpress.XtraEditors.LabelControl LabelChangeDate;
        private System.Windows.Forms.BindingSource ResourceBindingSource;
        private DevExpress.XtraEditors.ImageComboBoxEdit ImageComboBoxEditAgency;
        private DevExpress.XtraEditors.ImageComboBoxEdit ImageComboBoxEditSection;
        private DevExpress.XtraEditors.ImageComboBoxEdit ImageComboBoxEditLang;
        private LabelControl LabelStatus;
        private PanelControl panelControlStatus;
        private LabelControl labelControl1;
        private CheckEdit checkEditAllAgency;
        private CheckEdit checkEditAllCategory;
        private ButtonEdit buttonEditResEndDate;
        private ButtonEdit buttonEditResStartDate;
        private GridLookUpEdit ImageComboBoxEditCategory;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private GridLookUpEdit gridLookUpEditProduct;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEditProductView;
        private GridColumn colCodeProduct;
        private GridColumn colNameProduct;
        private GridColumn colDisplayNameProduct;
        private BindingSource bindingSourceCodeNameProduct;
        private PanelControl panelControlText;
        private TextEdit TextEditTitle;
        private TextEdit TextEditSubtitle;
        private PanelControl panelControlPrimaryImages;
        private TextEdit TextEditCaption;
        private DevExpress.XtraTab.XtraTabControl xtraTabControlPictures;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private PanelControl panelControlLowRes;
        private LabelControl labelControlSizeDisplay;
        private LabelControl labelControlSize;
        private SimpleButton ButtonCreateThumbnailLowRes;
        private LabelControl LabelPeview;
        private PictureEdit pictureEditPreviewImage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage5;
        private PanelControl panelControlMedRes;
        private LabelControl labelControlSizeDisplay2;
        private LabelControl labelControlSize2;
        private LabelControl labelControlPreview2;
        private SimpleButton ButtonCreateThumbnailMedRes;
        private PictureEdit pictureEditPreviewImage2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage6;
        private PanelControl panelControlHighRes;
        private LabelControl labelControlSizeDisplay3;
        private LabelControl labelControlSize3;
        private SimpleButton ButtonCreateThumbNailHighRes;
        private LabelControl LabelPreview3;
        private PictureEdit pictureEditPreviewImage3;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage7;
        private PanelControl panelControlThumbNail;
        private LabelControl labelControlSizeDisplay4;
        private LabelControl labelControlSize4;
        private LabelControl LabelPreview4;
        private PictureEdit pictureEditPreviewImage4;
        private PanelControl panelControl3;
        private SimpleButton ButtonSaveChanges;
        private SimpleButton ButtonDelRow;
        private SimpleButton ButtonAddRow;
        private PanelControl panelControlDisplay;
        private ImageComboBoxEdit ImageComboBoxEditSeverity;
        private CheckEdit CheckEditConsent;
        private CheckEdit CheckEditInactive;
        private PictureEdit pictureEditPreviewAddImg;
        private SpiceLogic.WinHTMLEditor.WinForm.WinFormHtmlEditor htmlEditor;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barTools;
        private DevExpress.XtraBars.BarButtonItem barButtonItemNew;
        private DevExpress.XtraBars.BarButtonItem barButtonItemDelete;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSave;
        private DevExpress.XtraBars.BarButtonItem barButtonItemClone;
        private DevExpress.XtraBars.BarButtonItem barButtonItemExpand;
        private DevExpress.XtraBars.BarSubItem barSubItemReports;
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
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemButtonEdit_Item;
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
        private TextEdit ButtonEditImage1LowRes;
        private TextEdit ButtonEditImage2MedRes;
        private TextEdit ButtonEditImage3HighRes;
        private TextEdit ButtonEditImage4ThmNail;
    }
}
