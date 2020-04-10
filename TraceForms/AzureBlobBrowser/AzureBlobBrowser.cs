using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Storage;
using DevExpress.XtraEditors.CustomEditor;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using System.Reflection;
using DevExpress.XtraEditors.Drawing;

namespace TraceForms.AzureBlobBrowser
{
    public partial class AzureBlobBrowser : PopupContainerEdit
    {
        public CloudBlobContainer BlobContainer { get; set; }

        const int FullPathField = 0;
        const int DisplayNameField = 1;
        const int IsFolderField = 2;
        private RepositoryItemPopupContainerEdit fProperties;
        private DevExpress.XtraTreeList.TreeList treeListBrowser;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnFullPath;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnDisplayName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnIsFolder;
        private PopupContainerControl popupContainerControl1;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private IContainer components;

        //public new event EventHandler EditValueChanged;

        private bool MouseDoubleClicked;

        public AzureBlobBrowser() {
             InitializeComponent();
            treeListBrowser.DataSource = new object[] { };
        }

        static AzureBlobBrowser() { 
            RepositoryItemAzureBlobBrowser.RegisterCustomEdit();
        }

        const string CustomEditName = "AzureBlobBrowser";       //must be the same as the RepositoryItem name

        public override string EditorTypeName => CustomEditName;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemAzureBlobBrowser Properties => base.Properties as RepositoryItemAzureBlobBrowser;

        ////https://stackoverflow.com/a/24420145/3610417
        //public object EditValueData { 
        //    get {
        //        return this.EditValue;
        //    }
        //    set {
        //        this.EditValue = value;
        //        //Events are only initialized at runtime, but at design time the data bound properties are set to null
        //        // causing a crash in the designer if there is not a null check for the event
        //        if (this.EditValueChanged != null) {
        //            this.EditValueChanged(this, new EventArgs());
        //        }
        //    }
        //}

        private void ExpandNodeByPath(string value)
        {
            //Expanding a node will force it to get data so we should eventually end up with the hierarchy loaded
            //and expanded down to the selected path
            //Handle file and web paths (forward and back slashes can't both exist in a path)
            char splitter = '\\';
            if (value.Contains('/')) {
                splitter = '/';
            }
            string[] path = value.Split(splitter);
            TreeListNodes nodes = treeListBrowser.Nodes;
            foreach (string segment in path) {
                TreeListNode node = FindChildNode(nodes, segment);
                if (node != null) {
                    node.Expanded = true;
                    treeListBrowser.FocusedNode = node;
                    nodes = treeListBrowser.Nodes;
                }
            }
        }

        private TreeListNode FindChildNode(TreeListNodes nodes, string segment)
        {
            foreach (TreeListNode node in nodes) {
                if (node[treeListColumnDisplayName].ToString().ToLower() == segment.ToLower()) {
                    return node;
                }
            }
            return null;
        }

        private void treeList1_VirtualTreeGetChildNodes(object sender, DevExpress.XtraTreeList.VirtualTreeGetChildNodesInfo e)
        {
            string prefix = string.Empty;
            bool isFolder = false;
            //If an existing node is being expanded, it will be an array.  The root node will not be an array because no values
            //have been added to it yet
            if (e.Node.GetType().IsArray) {
                prefix = ((object[])e.Node)[FullPathField].ToString();
                isFolder = (bool)((object[])e.Node)[IsFolderField];
            }
            if (isFolder || string.IsNullOrEmpty(prefix)) {
                var entries = ListBlobsHierarchicalListing(BlobContainer, prefix);
                //Folders show first, then files
                e.Children = entries.OrderBy(a => !a.IsFolder).ThenBy(a => a.DisplayName)
                    .Select(a => new object[] { a.FullPath, a.DisplayName, a.IsFolder }).ToArray();
            }
        }

        private List<BlobEntry> ListBlobsHierarchicalListing(CloudBlobContainer container, string prefix)
        {
            CloudBlobDirectory dir;
            CloudBlob blob;
            BlobContinuationToken continuationToken = null;
            BlobEntry entry;
            List<BlobEntry> entries = new List<BlobEntry>();
            bool hasResults;

            try {
                // Call the listing operation and enumerate the result segment.
                // When the continuation token is null, the last segment has been returned and 
                // execution can exit the loop.
                do {
                    BlobResultSegment resultSegment = container.ListBlobsSegmented(prefix, false, BlobListingDetails.Metadata, null, continuationToken, null, null);
                    hasResults = resultSegment.Results.Any();
                    foreach (var blobItem in resultSegment.Results) {
                        entry = new BlobEntry();
                        // A hierarchical listing may return both virtual directories and blobs.
                        if (blobItem is CloudBlobDirectory) {
                            dir = (CloudBlobDirectory)blobItem;
                            //Get the last portion of the path
                            string[] name = dir.Prefix.TrimEnd('/').Split('/');
                            entry.DisplayName = name[name.Length - 1];
                            entry.FullPath = dir.Prefix;
                            entry.IsFolder = true;
                        }
                        else {
                            blob = (CloudBlob)blobItem;
                            //Get the filename of the blob without the preceding path
                            string[] name = blob.Name.Split('/');
                            entry.DisplayName = name[name.Length - 1];
                            entry.FullPath = blob.Name;
                        }
                        entries.Add(entry);
                    }

                    // Get the continuation token and loop until it is null which is the documented way to tell when the blobs have been enumerated
                    continuationToken = resultSegment.ContinuationToken;

                //In practice I discovered there can be a non-null continuation token and no results in an endless loop so I check both
                } while (continuationToken != null && hasResults);
                return entries;
            }
            catch (StorageException e) {
                throw;
            }
        }

        private void treeList1_VirtualTreeGetCellValue(object sender, DevExpress.XtraTreeList.VirtualTreeGetCellValueInfo e)
        {
            if (e.Column == treeListColumnDisplayName) {
                e.CellData = ((object[])e.Node)[DisplayNameField].ToString();
            }
            if (e.Column == treeListColumnFullPath) {
                e.CellData = ((object[])e.Node)[FullPathField].ToString();
            }
            if (e.Column == treeListColumnIsFolder) {
                e.CellData = (bool)((object[])e.Node)[IsFolderField];
            }
        }

        private void popupContainerEdit_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
        {
            //Only allow selecting a new value by double-clicking a node.  Default functionality is to 
            //select a new value whenever the popup closes but this is not intuitive because the popup can
            //be closed by clicking outside it, which should not select a value.
            if (treeListBrowser.FocusedNode != null && MouseDoubleClicked) {
                MouseDoubleClicked = false;
                string selectedVal = treeListBrowser.FocusedNode[treeListColumnFullPath].ToString();
                //string originalVal = e.Value.ToStringEmptyIfNull();
                e.Value = selectedVal;
            }
        }

        private void treeListBrowser_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            var hitInfo = treeListBrowser.CalcHitInfo(new Point(e.X, e.Y));
            if (hitInfo.Node != null) {
                var node = hitInfo.Node;
                if (!(bool)node[treeListColumnIsFolder]) {
                    MouseDoubleClicked = true;
                    this.ClosePopup();
                }
            }
        }

        private void treeListBrowser_MouseUp(object sender, MouseEventArgs e)
        {
            base.OnMouseUp(e);
            var hitInfo = treeListBrowser.CalcHitInfo(new Point(e.X, e.Y));
            if (hitInfo.Node != null) {
                var node = hitInfo.Node;
                if ((bool)node[treeListColumnIsFolder]) {
                    node.Expanded = !node.Expanded;
                }
            }

        }

        private void treeListBrowser_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            if ((bool)e.Node[treeListColumnIsFolder]) {
                e.NodeImageIndex = (e.Node.Expanded) ? 1 : 0;
            }
            else {
                e.NodeImageIndex = 2;
            }
        }

        private void popupContainerEdit_Popup(object sender, EventArgs e)
        {
            if (this.EditValue != null) {
                ExpandNodeByPath(this.EditValue.ToString());
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.fProperties = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
            this.treeListBrowser = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumnFullPath = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnDisplayName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnIsFolder = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListBrowser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // fProperties
            // 
            this.fProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fProperties.Name = "fProperties";
            this.fProperties.PopupControl = this.popupContainerControl1;
            this.fProperties.Popup += new System.EventHandler(this.popupContainerEdit_Popup);
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
            // popupContainerControl1
            // 
            this.popupContainerControl1.Controls.Add(this.treeListBrowser);
            this.popupContainerControl1.Location = new System.Drawing.Point(2, 25);
            this.popupContainerControl1.Margin = new System.Windows.Forms.Padding(2);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(396, 225);
            this.popupContainerControl1.TabIndex = 1;
            // 
            // svgImageCollection1
            // 
            this.svgImageCollection1.Add("actions_folderclose", "image://svgimages/icon builder/actions_folderclose.svg");
            this.svgImageCollection1.Add("open", "image://svgimages/actions/open.svg");
            this.svgImageCollection1.Add("insertimage", "image://svgimages/richedit/insertimage.svg");
            // 
            // AzureBlobBrowser
            // 
            this.QueryResultValue += new DevExpress.XtraEditors.Controls.QueryResultValueEventHandler(this.popupContainerEdit_QueryResultValue);
            ((System.ComponentModel.ISupportInitialize)(this.fProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListBrowser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).EndInit();
            this.ResumeLayout(false);

        }
    }

    [UserRepositoryItem("RegisterCustomEdit")]
    public class RepositoryItemAzureBlobBrowser : RepositoryItemPopupContainerEdit
    {
        static RepositoryItemAzureBlobBrowser() { RegisterCustomEdit(); }

        public RepositoryItemAzureBlobBrowser() { }

        const string CustomEditName = "AzureBlobBrowser";       //must be the same as the editor name

        public override string EditorTypeName => CustomEditName;

        public static void RegisterCustomEdit()
        {
            Image img = null;
            try {
                img = (Bitmap)Bitmap.FromStream(Assembly.GetExecutingAssembly().
                  GetManifestResourceStream("DevExpress.CustomEditors.CustomEdit.bmp"));
            }
            catch {
            }
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName,
              typeof(AzureBlobBrowser), typeof(RepositoryItemAzureBlobBrowser),
              typeof(PopupContainerEditViewInfo), new ButtonEditPainter(), true, img));
        }

        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try {
                base.Assign(item);
                RepositoryItemAzureBlobBrowser source = item as RepositoryItemAzureBlobBrowser;
                if (source == null)
                    return;
            }
            finally {
                EndUpdate();
            }
        }
    }

    internal class BlobEntry
    {
        public List<BlobEntry> Entries { get; set; }
        public string DisplayName { get; set; }
        public string FullPath { get; set; }
        public bool IsFolder { get; set; }
    }

}
