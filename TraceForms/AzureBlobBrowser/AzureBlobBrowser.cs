﻿using System;
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

namespace TraceForms.AzureBlobBrowser
{
    public partial class AzureBlobBrowser : DevExpress.XtraEditors.XtraUserControl
    {
        public CloudBlobContainer BlobContainer { get; set; }

        const int FullPathField = 0;
        const int DisplayNameField = 1;
        const int IsFolderField = 2;

        public event EventHandler EditValueChanged;

        private bool MouseDoubleClicked;

        public AzureBlobBrowser()
        {
            InitializeComponent();
            treeListBrowser.DataSource = new object();
        }

        //https://stackoverflow.com/a/24420145/3610417
        public object EditValueData { 
            get {
                return popupContainerEditBrowser.EditValue;
            } 
            set {
                popupContainerEditBrowser.EditValue = value;
                //Events are only initialized at runtime, but at design time the data bound properties are set to null
                // causing a crash in the designer if there is not a null check for the event
                if (this.EditValueChanged != null) {
                    this.EditValueChanged(this, new EventArgs());
                }
            }
        }

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
                e.Children = entries.Select(e => new object[] { e.FullPath, e.DisplayName, e.IsFolder }).ToArray();
            }
        }

        private List<BlobEntry> ListBlobsHierarchicalListing(CloudBlobContainer container, string prefix)
        {
            CloudBlobDirectory dir;
            CloudBlob blob;
            BlobContinuationToken continuationToken;
            BlobEntry entry;
            List<BlobEntry> entries = new List<BlobEntry>();

            try {
                // Call the listing operation and enumerate the result segment.
                // When the continuation token is null, the last segment has been returned and 
                // execution can exit the loop.
                do {
                    BlobResultSegment resultSegment = container.ListBlobsSegmented(prefix, false, BlobListingDetails.Metadata, null, null, null, null);
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

                    // Get the continuation token and loop until it is null.
                    continuationToken = resultSegment.ContinuationToken;

                } while (continuationToken != null);
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

        private void popupContainerEdit1_Properties_QueryResultValue(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
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
                    popupContainerEditBrowser.ClosePopup();
                }
            }
        }

        private void treeListBrowser_MouseUp_1(object sender, MouseEventArgs e)
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

        private void popupContainerEditBrowser_Popup(object sender, EventArgs e)
        {
            if (popupContainerEditBrowser.EditValue != null) {
                ExpandNodeByPath(popupContainerEditBrowser.EditValue.ToString());
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
