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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.fProperties = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
            this.treeListBrowser = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumnDisplayName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnFullPath = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnIsFolder = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bindingSourceBlobEntry = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListBrowser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBlobEntry)).BeginInit();
            this.SuspendLayout();
            // 
            // fProperties
            // 
            this.fProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fProperties.Name = "fProperties";
            // 
            // treeListBrowser
            // 
            this.treeListBrowser.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumnDisplayName,
            this.treeListColumnFullPath,
            this.treeListColumnIsFolder});
            this.treeListBrowser.Location = new System.Drawing.Point(24, 31);
            this.treeListBrowser.Name = "treeListBrowser";
            this.treeListBrowser.Size = new System.Drawing.Size(400, 200);
            this.treeListBrowser.TabIndex = 0;
            // 
            // treeListColumnDisplayName
            // 
            this.treeListColumnDisplayName.Caption = "treeListColumn1";
            this.treeListColumnDisplayName.FieldName = "treeListColumn1";
            this.treeListColumnDisplayName.Name = "treeListColumnDisplayName";
            this.treeListColumnDisplayName.Visible = true;
            this.treeListColumnDisplayName.VisibleIndex = 0;
            // 
            // treeListColumnFullPath
            // 
            this.treeListColumnFullPath.Caption = "treeListColumn1";
            this.treeListColumnFullPath.FieldName = "treeListColumn1";
            this.treeListColumnFullPath.Name = "treeListColumnFullPath";
            this.treeListColumnFullPath.Visible = true;
            this.treeListColumnFullPath.VisibleIndex = 1;
            // 
            // treeListColumnIsFolder
            // 
            this.treeListColumnIsFolder.Caption = "treeListColumn1";
            this.treeListColumnIsFolder.FieldName = "treeListColumn1";
            this.treeListColumnIsFolder.Name = "treeListColumnIsFolder";
            this.treeListColumnIsFolder.Visible = true;
            this.treeListColumnIsFolder.VisibleIndex = 2;
            // 
            // AzureBlobBrowser
            // 
            this.Controls.Add(this.treeListBrowser);
            this.Name = "XtraForm1";
            this.Size = new System.Drawing.Size(639, 20);
            ((System.ComponentModel.ISupportInitialize)(this.fProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListBrowser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBlobEntry)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeListBrowser;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnDisplayName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnFullPath;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnIsFolder;
        private DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit fProperties;
        private System.Windows.Forms.BindingSource bindingSourceBlobEntry;
    }
}