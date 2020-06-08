namespace TraceForms.AzureBlobBrowser
{
    partial class AzureBlobBrowser
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
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.fProperties = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
            this.popupContainerControl = new DevExpress.XtraEditors.PopupContainerControl();
            this.treeListBrowser = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumnFullPath = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnDisplayName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnIsFolder = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl)).BeginInit();
            this.popupContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListBrowser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // fProperties
            // 
            this.fProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fProperties.Name = "fProperties";
            this.fProperties.PopupControl = this.popupContainerControl;
            // 
            // popupContainerControl
            // 
            this.popupContainerControl.Controls.Add(this.treeListBrowser);
            this.popupContainerControl.Location = new System.Drawing.Point(2, 25);
            this.popupContainerControl.Margin = new System.Windows.Forms.Padding(2);
            this.popupContainerControl.Name = "popupContainerControl";
            this.popupContainerControl.Size = new System.Drawing.Size(396, 225);
            this.popupContainerControl.TabIndex = 1;
            // 
            // treeListBrowser
            // 
            this.treeListBrowser.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumnFullPath,
            this.treeListColumnDisplayName,
            this.treeListColumnIsFolder});
            this.treeListBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListBrowser.FixedLineWidth = 1;
            this.treeListBrowser.Location = new System.Drawing.Point(0, 0);
            this.treeListBrowser.Margin = new System.Windows.Forms.Padding(2);
            this.treeListBrowser.MinWidth = 16;
            this.treeListBrowser.Name = "treeListBrowser";
            this.treeListBrowser.OptionsBehavior.Editable = false;
            this.treeListBrowser.OptionsBehavior.ReadOnly = true;
            this.treeListBrowser.OptionsView.ShowIndicator = false;
            this.treeListBrowser.Size = new System.Drawing.Size(396, 225);
            this.treeListBrowser.StateImageList = this.svgImageCollection1;
            this.treeListBrowser.TabIndex = 0;
            this.treeListBrowser.TreeLevelWidth = 12;
            this.treeListBrowser.GetStateImage += new DevExpress.XtraTreeList.GetStateImageEventHandler(this.treeListBrowser_GetStateImage);
            this.treeListBrowser.VirtualTreeGetChildNodes += new DevExpress.XtraTreeList.VirtualTreeGetChildNodesEventHandler(this.treeList1_VirtualTreeGetChildNodes);
            this.treeListBrowser.VirtualTreeGetCellValue += new DevExpress.XtraTreeList.VirtualTreeGetCellValueEventHandler(this.treeList1_VirtualTreeGetCellValue);
            this.treeListBrowser.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeListBrowser_MouseDoubleClick);
            this.treeListBrowser.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeListBrowser_MouseUp);
            // 
            // treeListColumnFullPath
            // 
            this.treeListColumnFullPath.Caption = "Full Path";
            this.treeListColumnFullPath.FieldName = "Full Path";
            this.treeListColumnFullPath.MinWidth = 16;
            this.treeListColumnFullPath.Name = "treeListColumnFullPath";
            this.treeListColumnFullPath.OptionsColumn.AllowEdit = false;
            this.treeListColumnFullPath.OptionsColumn.ReadOnly = true;
            this.treeListColumnFullPath.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.String;
            this.treeListColumnFullPath.Width = 50;
            // 
            // treeListColumnDisplayName
            // 
            this.treeListColumnDisplayName.MinWidth = 16;
            this.treeListColumnDisplayName.Name = "treeListColumnDisplayName";
            this.treeListColumnDisplayName.OptionsColumn.AllowEdit = false;
            this.treeListColumnDisplayName.OptionsColumn.ReadOnly = true;
            this.treeListColumnDisplayName.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.String;
            this.treeListColumnDisplayName.Visible = true;
            this.treeListColumnDisplayName.VisibleIndex = 0;
            this.treeListColumnDisplayName.Width = 50;
            // 
            // treeListColumnIsFolder
            // 
            this.treeListColumnIsFolder.Caption = "Is Folder";
            this.treeListColumnIsFolder.FieldName = "Is Folder";
            this.treeListColumnIsFolder.MinWidth = 16;
            this.treeListColumnIsFolder.Name = "treeListColumnIsFolder";
            this.treeListColumnIsFolder.OptionsColumn.AllowEdit = false;
            this.treeListColumnIsFolder.OptionsColumn.ReadOnly = true;
            this.treeListColumnIsFolder.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.Boolean;
            this.treeListColumnIsFolder.Width = 50;
            // 
            // svgImageCollection1
            // 
            this.svgImageCollection1.Add("actions_folderclose", "image://svgimages/icon builder/actions_folderclose.svg");
            this.svgImageCollection1.Add("open", "image://svgimages/actions/open.svg");
            this.svgImageCollection1.Add("insertimage", "image://svgimages/richedit/insertimage.svg");
            // 
            // AzureBlobBrowser
            // 
            this.Controls.Add(this.popupContainerControl);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(399, 20);
            this.QueryResultValue += new DevExpress.XtraEditors.Controls.QueryResultValueEventHandler(this.popupContainerEdit1_Properties_QueryResultValue);
            this.Popup += new System.EventHandler(this.popupContainerEditBrowser_Popup);
            ((System.ComponentModel.ISupportInitialize)(this.fProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl)).EndInit();
            this.popupContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListBrowser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl;
        private DevExpress.XtraTreeList.TreeList treeListBrowser;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnDisplayName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnFullPath;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnIsFolder;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit fProperties;
    }
}
