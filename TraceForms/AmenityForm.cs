using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Text;
using System.IO;
using FlexModel;
using FlexInterfaces.Core;
using System.Security.Permissions;
using Microsoft.Win32;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.Management;
using System.Xml;
using System.Linq;
using DevExpress.XtraGrid.Columns;
using System.Runtime.InteropServices;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraEditors.Repository;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraGrid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System.Collections;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;

namespace TraceForms
{

    public partial class AmenityForm : DevExpress.XtraEditors.XtraForm
    {
        public string imagesRoot;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        FlextourEntities _context;
        AMENITY _selectedRecord;
        Timer _actionConfirmation;
        IList<AMENITY> _amenities;
        int? _imageIndex;

        public AmenityForm(ICoreSys _sys)
        {
            InitializeComponent();

            Connection.EFConnectionString = _sys.Settings.EFConnectionString;
            _context = new FlextourEntities(_sys.Settings.EFConnectionString);
            _sys.Connect("");
            imagesRoot = _sys.Settings.ImagesRoot;
            _sys.Disconnect();

            SetReadOnly(true);
            ComboBoxEditFilterBySvcType.Focus();
        }

        void SetReadOnly(bool value)
        {
            foreach (Control control in xtraScrollableControl1.Controls) {
                control.Enabled = !value;
            }
            ComboBoxEditFilterBySvcType.Enabled = true;
            TreeListAmenities.Enabled = true;
        }

        void SetReadOnlyKeyFields(bool value)
        {
            TextEditCode.ReadOnly = value;
        }

        private void ShowActionConfirmation(string confirmation)
        {
            PanelControlStatus.Visible = true;
            LabelStatus.Text = confirmation;
            _actionConfirmation = new Timer {
                Interval = 3000
            };
            _actionConfirmation.Start();
            _actionConfirmation.Tick += TimedEvent;
        }

        private void TimedEvent(object sender, EventArgs e)
        {
            PanelControlStatus.Visible = false;
            _actionConfirmation.Stop();
        }

        void SetItems(bool valid)
        {
            SetBindings();
            TextEditItem_Desc1.Properties.ReadOnly = valid;
            TextEditItem_Desc2.Properties.ReadOnly = valid;
            ComboBoxEditItem_Format1.Properties.ReadOnly = valid;
            ComboBoxEditItem_Format2.Properties.ReadOnly = valid;
            CheckEditRequire_Entry.Properties.ReadOnly = valid;
            CheckEditSearchable.Properties.ReadOnly = valid;
            CheckEditSupplier_Entry.Properties.ReadOnly = valid;
        }

        private void AmenityForm_Load(object sender, EventArgs e)
        {
            //sVC_TYPEComboBoxEdit.Focus();
            //treeList1.KeyFieldName = "CODE";
            //treeList1.ParentFieldName = "PARENT_CODE";
            ComboBoxEditFilterBySvcType.Focus();
        }

        private void ComboBoxEditFilterBySvcType_TextChanged(object sender, EventArgs e)
        {
            string type = ComboBoxEditFilterBySvcType.Text;
            _amenities = _context.AMENITY.Where(a => a.SVC_TYPE == type).OrderBy(a => a.SORT_ORDER).ToList();
            TreeListAmenities.DataSource = _amenities;
            BindingSource.DataSource = _amenities;

            if (!string.IsNullOrEmpty(type)) {
                TreeListAmenities.ResetAutoFilterConditions();
                switch (type) {
                    case "HTL":
                        colITEM_DESC1.Caption = "Hotel amenities";
                        break;
                    case "OPT":
                        colITEM_DESC1.Caption = "Service amenities";
                        break;
                    case "PKG":
                        colITEM_DESC1.Caption = "Package amenities";
                        break;
                    default:
                        colITEM_DESC1.Caption = "";
                        break;
                }
                //  treeList1.BeginSort();
                //TreeList.Columns["SORT_ORDER"].SortOrder = SortOrder.Ascending; test
                //    treeList1.EndSort();
                TreeListAmenities.ExpandAll();
                ComboBoxEditFilterBySvcType.Focus();
                TreeListAmenities.MoveFirst();
                ComboBoxEditFilterBySvcType.Focus();
                SetReadOnly(false);
            }
        }

        private void LabelControlUp_Click(object sender, EventArgs e)
        {
            ///ARGHHHHH TREELIST I WILL BE BACK LATER///////////////
            if (BindingSource.Current != null) {
                if (TreeListAmenities.FocusedNode.PrevVisibleNode == null || TreeListAmenities.FocusedNode.PrevNode == null)
                    return;

                if (TreeListAmenities.FocusedNode.PrevNode.HasChildren == true) {
                    do {
                        string one = TreeListAmenities.FocusedNode.GetValue(colSORT_ORDER).ToString();
                        string two = TreeListAmenities.FocusedNode.PrevNode.GetValue(colSORT_ORDER).ToString();
                        string one2 = TreeListAmenities.FocusedNode.GetValue(colITEM_DESC1).ToString();
                        string two2 = TreeListAmenities.FocusedNode.PrevNode.GetValue(colITEM_DESC1).ToString();
                        int two1 = int.Parse(TreeListAmenities.FocusedNode.PrevNode.GetValue(colSORT_ORDER).ToString());//this used to be the only place two was used
                        int f2 = TreeListAmenities.FocusedNode.Nodes.Count;
                        int f3 = two1 + f2 + 1;
                        TreeListAmenities.FocusedNode.PrevNode.SetValue(colSORT_ORDER, f3);
                        TreeListAmenities.FocusedNode.SetValue(colSORT_ORDER, two1);

                        TreeListAmenities.Refresh();
                        if (TreeListAmenities.FocusedNode.PrevVisibleNode == null)
                            return;
                        if (TreeListAmenities.FocusedNode.PrevNode == null)
                            return;
                    } while (TreeListAmenities.FocusedNode.PrevNode.Visible == false);
                    return;
                }

                if (TreeListAmenities.FocusedNode.PrevNode.HasChildren == false) {
                    string one3 = TreeListAmenities.FocusedNode.GetValue(colSORT_ORDER).ToString();
                    string two3 = TreeListAmenities.FocusedNode.PrevNode.GetValue(colSORT_ORDER).ToString();
                    int one1 = int.Parse(one3);
                    int two4 = int.Parse(two3);
                    int dif = one1 - two4;
                    one1 -= dif;
                    two4 += dif;
                    one3 = one1.ToString();
                    two3 = two4.ToString();
                    TreeListAmenities.FocusedNode.SetValue(colSORT_ORDER, one3);
                    TreeListAmenities.FocusedNode.PrevNode.SetValue(colSORT_ORDER, two3);
                    TreeListAmenities.Refresh();
                }
            }
        }

        private void LabelControlDown_Click(object sender, EventArgs e)
        {
            if (BindingSource.Current != null) {
                if (TreeListAmenities.FocusedNode.NextVisibleNode == null)
                    return;
                if (TreeListAmenities.FocusedNode.NextNode == null)
                    return;

                if (TreeListAmenities.FocusedNode.NextNode.HasChildren == true) {
                    do {
                        string one = TreeListAmenities.FocusedNode.GetValue(colSORT_ORDER).ToString();
                        string two = TreeListAmenities.FocusedNode.NextNode.GetValue(colSORT_ORDER).ToString();
                        int one1 = int.Parse(one);
                        int f2 = TreeListAmenities.FocusedNode.NextNode.Nodes.Count;
                        int f3 = one1 + f2 + 1;
                        TreeListAmenities.FocusedNode.NextNode.SetValue(colSORT_ORDER, one);
                        TreeListAmenities.FocusedNode.SetValue(colSORT_ORDER, f3);
                        TreeListAmenities.Refresh();
                        if (TreeListAmenities.FocusedNode.NextVisibleNode == null)
                            return;
                        if (TreeListAmenities.FocusedNode.NextNode == null)
                            return;
                    } while (TreeListAmenities.FocusedNode.NextNode.Visible == false);
                    return;
                }

                if (TreeListAmenities.FocusedNode.NextNode.HasChildren == false) {
                    string one3 = TreeListAmenities.FocusedNode.GetValue(colSORT_ORDER).ToString();
                    string two3 = TreeListAmenities.FocusedNode.NextNode.GetValue(colSORT_ORDER).ToString();
                    int one1 = int.Parse(one3);
                    int two4 = int.Parse(two3);
                    int dif = two4 - one1;
                    one1 += dif;
                    two4 -= dif;
                    one3 = one1.ToString();
                    two3 = two4.ToString();
                    TreeListAmenities.FocusedNode.NextNode.SetValue(colSORT_ORDER, two3);
                    TreeListAmenities.FocusedNode.SetValue(colSORT_ORDER, one3);
                    TreeListAmenities.Refresh();
                }
            }
        }

        private void ButtonEditImage_TextChanged(object sender, EventArgs e)
        {
            PictureEdit1.Image = null;
            Image pic;
            try {
                pic = new Bitmap(imagesRoot + ButtonEditImage.Text);
                ErrorProvider.SetError(ButtonEditImage, "");
            }
            catch {
                try {
                    pic = new Bitmap(ButtonEditImage.Text);
                    ErrorProvider.SetError(ButtonEditImage, "");
                }
                catch {
                    //if (string.IsNullOrWhiteSpace(path.Text))
                    //    errorProvider1.SetError(path, "");
                    //else
                    //    errorProvider1.SetError(path, "Invalid image file");
                    return;
                }
            }
            PictureEdit1.Image = pic;
        }

        private void AmenityForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsModified(_selectedRecord)) {
                DialogResult select = DisplayHelper.QuestionYesNo(this, "There are unsaved changes. Are you sure want to exit?");
                if (select == DialogResult.Yes) {
                    e.Cancel = false;
                    _context.Dispose();
                    Dispose();
                }
                else
                    e.Cancel = true;
            }
            else {
                e.Cancel = false;
                _context.Dispose();
                Dispose();
            }
        }

        private void ComboBoxEditSvcType_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateSvcType, sender);
        }

        private void TextEditCode_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateCode, sender);
        }

        private void TextEditItem_Desc1_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateDesc1, sender);
        }

        private void ComboBoxEditItem_Format1_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateFormat1, sender);
        }

        private void TextEditItem_Desc2_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateDesc2, sender);
        }

        private void ComboBoxEditItem_Format2_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateFormat2, sender);
        }

        private void ButtonEditImage_Leave(object sender, EventArgs e)
        {
            if (_selectedRecord != null)
                SetErrorInfo(_selectedRecord.ValidateImagePath, sender);
        }

        private void TreeList1_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            //if (e.Column.FieldName == "ITEM_DESC1")
            //{
            //    if (e.Node.Level == 0 || e.Node.HasChildren)
            //    {
            //        e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            //    }
            //}
        }

        private void PropogateDeletionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //delete from amenassgn where svc_type = cboType and code not in 
            //(select code from amenity where svc_type = cboType)
            var propogatedRecs = from assignRec in _context.AMENASSGN
                                 from amenityRec in _context.AMENITY
                                 where amenityRec.SVC_TYPE == ComboBoxEditFilterBySvcType.Text && assignRec.SVC_TYPE == ComboBoxEditFilterBySvcType.Text && assignRec.CODE != amenityRec.CODE
                                 select assignRec;
            foreach (AMENASSGN rec in propogatedRecs) {
                _context.AMENASSGN.DeleteObject(rec);
            }

            _context.SaveChanges();
        }

        private void AmenityBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (BindingSource.Current != null) {
                if (CheckEditHeader.Checked) {
                    SetItems(true);
                    TextEditItem_Desc1.Properties.ReadOnly = false;
                }
                else {
                    SetItems(false);
                }
            }
        }

        private void ButtonEditImage_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dlg = new OpenFileDialog() { Title = "Open Image", InitialDirectory = imagesRoot };
            if (dlg.ShowDialog() == DialogResult.OK) {
                if (dlg.FileName.ToLower().IndexOf(imagesRoot.ToLower()) != -1)
                    ButtonEditImage.Text = dlg.FileName.Substring(imagesRoot.Length);
                else
                    ButtonEditImage.Text = dlg.FileName;
            }
        }

        private void AmenityForm_Shown(object sender, System.EventArgs e)
        {
            ComboBoxEditFilterBySvcType.Focus();
        }

        private void TreeList1_BeforeFocusNode(object sender, BeforeFocusNodeEventArgs e)
        {
            //if (modified || newRec)
            //{
            //    if (checkForms())
            //    {
            //        e.CanFocus = true;
            //    }
            //    else
            //        e.CanFocus = false;
            //}
        }

        private bool SaveRecord(bool prompt)
        {
            try {
                if (_selectedRecord == null)
                    return true;

                FinalizeBindings();
                if (_selectedRecord.IsNew()) {
                    if (_amenities.Contains(_selectedRecord)) {

                    }
                }
                TreeListAmenities.RefreshDataSource();
                CalculateSortOrder(TreeListAmenities.Nodes, 1M, 0);
                CalculateParentCode(TreeListAmenities.Nodes);
                bool newRec = _selectedRecord.IsNew();
                bool modified = newRec || _amenities.IsModified(_context);//amenities needs to be refreshed or something after calculating the sort order, so that this will be accurate
                if (modified) {
                    if (prompt) {
                        DialogResult result = DisplayHelper.QuestionYesNoCancel(this, "Do you want to save these changes?");
                        if (result == DialogResult.No) {
                            if (newRec) {
                                RemoveRecord();
                            }
                            else {
                                RefreshRecord();
                            }
                            return true;
                        }
                        else if (result == DialogResult.Cancel) {
                            return false;
                        }
                    }
                    if (!ValidateAll())
                        return false;


                    if (_selectedRecord.EntityState == System.Data.Entity.EntityState.Detached) {
                        _context.AMENITY.AddObject(_selectedRecord);
                    }
                    if (!_amenities.Contains(_selectedRecord)) {
                        _amenities.Add(_selectedRecord);
                    }

                    _context.SaveChanges();
                    ShowActionConfirmation("Changes Saved");
                }
                return true;
            }
            catch (Exception ex) {
                DisplayHelper.DisplayError(this, ex);
                RefreshRecord();        //pull it back from db because that is its current state
                                        //We must also Load and rebind the related entities from the db because context.Refresh doesn't do that
                SetBindings();
                return false;
            }
        }

        public void CalculateSortOrder(TreeListNodes nodes, decimal? increase, decimal? start)
        {
            int nodePosition = 0;
            foreach (TreeListNode node in nodes) {
                var amenityRow = (AMENITY)TreeListAmenities.GetRow(node.Id);//Get the node as an Amenity so we can modify sort order
                nodePosition++;//Node position goes up by one as we go down the tree list, so that increase gets "added" an additional time to the start depending on the node's position
                amenityRow.SORT_ORDER = start + (increase * nodePosition);//Start value is zero for base-level nodes, and the parent's sort order for children
                if (node.HasChildren) {//If the node has children we need to update their sort orders to reflect the changes made to the parent
                    CalculateSortOrder(node.Nodes, 0.001M, amenityRow.SORT_ORDER);//Child nodes start at parent sort order plus 0.001
                }
            }
        }

        public void CalculateParentCode(TreeListNodes nodes)
        {
            foreach (TreeListNode node in nodes) {
                var amenityRow = (AMENITY)TreeListAmenities.GetRow(node.Id);
                if (node.ParentNode == null) {
                    amenityRow.PARENT_CODE = null;
                }
                else {
                    var parentRow = (AMENITY)TreeListAmenities.GetRow(node.ParentNode.Id);
                    amenityRow.PARENT_CODE = parentRow.CODE;
                }
            }
        }

        void SetBindings()
        {
            if (BindingSource.Current == null) {
                ClearBindings();
            }
            else {
                _selectedRecord = ((AMENITY)BindingSource.Current);
                SetReadOnly(false);
                SetReadOnlyKeyFields(true);
                BarButtonItemDelete.Enabled = true;
                BarButtonItemSave.Enabled = true;
            }
            ErrorProvider.Clear();
        }

        void ClearBindings()
        {
            _selectedRecord = null;
            SetReadOnly(true);
            BarButtonItemDelete.Enabled = false;
            BarButtonItemSave.Enabled = false;
            BindingSource.DataSource = typeof(AMENITY);
        }

        private bool ValidateAll()
        {
            if (!_selectedRecord.Validate()) {
                ShowMainControlErrors();
                DisplayHelper.DisplayWarning(this, "Errors were found. Please resolve them and try again.");
                return false;
            }
            ErrorProvider.Clear();
            return true;
        }

        private void SetErrorInfo(Func<String> validationMethod, object sender)
        {
            BindingSource.EndEdit();//This is where the program crashes from a null reference exception when clicking off of Service Type in a new amenity
            if (validationMethod != null) {
                string error = validationMethod.Invoke();
                ErrorProvider.SetError((Control)sender, error);
            }
        }

        private void DisplayCrash(string message)
        {
            BindingSource.EndEdit();
            ErrorProvider.SetError(TextEditCode, message);
        }

        private void ShowMainControlErrors()
        {
            //The error indicators inside the grids are handled by binding, but errors on the main form must
            //be set manually
            var errors = _selectedRecord.Errors;
            if (errors != null) {
                if (errors.ContainsKey("CRASH")) {
                    var message = errors["CRASH"];
                    DisplayCrash(message);
                    return;
                }
            }
            SetErrorInfo(_selectedRecord.ValidateCode, TextEditCode);
            SetErrorInfo(_selectedRecord.ValidateSvcType, ComboBoxEditSvcType);
            SetErrorInfo(_selectedRecord.ValidateDesc1, TextEditItem_Desc1);
            SetErrorInfo(_selectedRecord.ValidateDesc2, TextEditItem_Desc2);
            SetErrorInfo(_selectedRecord.ValidateFormat1, ComboBoxEditItem_Format1);
            SetErrorInfo(_selectedRecord.ValidateFormat2, ComboBoxEditItem_Format2);
            SetErrorInfo(_selectedRecord.ValidateImagePath, ButtonEditImage);
        }


        private void TreeList_BeforeDropNode(object sender, BeforeDropNodeEventArgs e)
        {
            TreeList tree = sender as TreeList;
            Point point = tree.PointToClient(MousePosition);
            TreeListHitInfo hitInfo = tree.CalcHitInfo(point);
            AMENITY amenity = (AMENITY)tree.GetRow(e.SourceNode.Id);
            //if (e.DestinationNode != null) {
            //    cust.SORT_ORDER = ((Customer)tree.GetRow(e.DestinationNode.Id)).SORT_ORDER;
            //}
            //else
            if (_imageIndex == 0) {//If the index is 0, then the node is being attached to a parent node as a child node.  Add it below all of the parent's
                                   //child nodes, as this way we don't have to cascade changes to SORT_ORDER on two levels, just on the upper level.
                AMENITY hitInfoNodeAmenity = (AMENITY)tree.GetRow(hitInfo.Node.Id);
                if (hitInfo.Node.HasAsParent(hitInfo.Node)) {//Don't allow child nodes to have children.
                    

                    //decimal parentSortOrder = hitInfoNodeAmenity.SORT_ORDER ?? 0;//If this is 0 then either hitInfoNode or SORT_ORDER is null, bc SORT_ORDER starts at 1.
                    //if (parentSortOrder != 0) {
                    //    if (hitInfo.Node.HasChildren) {
                    //        var firstChild = (AMENITY)tree.GetRow(hitInfo.Node.Nodes.FirstNode.Id);//The first child node, used so that we can loop through all the child nodes
                    //        var sort = ((AMENITY)tree.GetRow(hitInfo.Node.Nodes.LastNode.Id)).SORT_ORDER + 0.001M;//This will be the new sort order of the node being dropped
                    //        var children = _amenities.Where(a => a.SORT_ORDER > parentSortOrder && a.SORT_ORDER < (parentSortOrder + 1));
                    //        //Here we make sure that we don't have a skipped sort order.  This could happen if a child node is removed from its parent and then added again
                    //        firstChild.SORT_ORDER = parentSortOrder + 0.001M;
                    //        foreach (var child in children) {
                    //            if (child.SORT_ORDER == firstChild.SORT_ORDER) {
                    //                continue;
                    //            }
                    //            else {

                    //            }
                    //        }
                    //        amenity.SORT_ORDER = sort;
                    //    }
                    //    else {
                    //        amenity.SORT_ORDER = parentSortOrder + 0.001M;
                    //    }
                    //}
                }
            }
            else if (_imageIndex == 1) {//If the index is 1, the node is being inserted below.
                var sort = ((AMENITY)tree.GetRow(hitInfo.Node.PrevNode.Id)).SORT_ORDER + 1M;//This will be the new sort order of the node being dropped
                foreach (var amen in _amenities) {//Cascade the sort order first or set the dropped node sort order first?
                    if (amen.SORT_ORDER >= sort) {
                        amen.SORT_ORDER += 1M;
                    }
                }
                amenity.SORT_ORDER = sort;
            }
            else if (_imageIndex == 2) {//If the index is 2, the node is being inserted above.
                var sort = ((AMENITY)tree.GetRow(hitInfo.Node.PrevNode.Id)).SORT_ORDER - 1M;//This will be the new sort order of the node being dropped
                foreach (var amen in _amenities) {
                    if (amen.SORT_ORDER >= sort) {
                        amen.SORT_ORDER += 1M;
                    }
                }
                amenity.SORT_ORDER = ((AMENITY)tree.GetRow(hitInfo.Node.PrevNode.Id)).SORT_ORDER - 1M;
            }
        }

        private void BarButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SaveRecord(true)) {
                //For some reason when there is no existing record in the binding source the Add method does not
                //trigger the CurrentChanged event, but AddNew does so use that instead
                _selectedRecord = (AMENITY)BindingSource.AddNew();
                //Because AMENITY has a compound primary key, when the value of one of the key fields posts back from the bound
                //editor, if the other one is null EF will throw an exception about null keys not being allowed (before our own
                //validation can fire).  Work around this by setting the key fields to empty string so that their values can
                //post back and then be handled by our own validation to require the user to enter data
                _selectedRecord.CODE = string.Empty;
                if(TreeListAmenities.FocusedNode != null) {
                    if (TreeListAmenities.FocusedNode.Level == 0) {//Not sure if base level nodes have a level of 0 or 1
                        _selectedRecord.SORT_ORDER = ((AMENITY)TreeListAmenities.GetRow(TreeListAmenities.FocusedNode.Id)).SORT_ORDER + 1;
                    }
                }
                SetReadOnlyKeyFields(false);
                ComboBoxEditSvcType.Focus();
                SetReadOnly(false);
            }
            ErrorProvider.Clear();
        }

        private void FinalizeBindings()
        {
            BindingSource.EndEdit();
        }

        private bool IsModified(AMENITY record)
        {
            //Type-specific routine that takes into account relationships that should also be considered
            //when deciding if there are unsaved changes.  The entity properties also return true if the
            //record is new or deleted.
            if (record == null)
                return false;
            return record.IsModified(_context);
        }

        private void RemoveRecord()
        {
            //Note that cascade delete must be set on the FK in the db in order for the related
            //entities to be deleted.  This is a db function, not an EF function. However in addition
            //the model must know about the delete, otherwise the relationships in the context will
            //get messed up.  So after adding the cascade rule to the FK, the model must be updated,
            //and in order to refresh a relationship the tables must be deleted and re-added
            //Otherwise, we could do a delete loop
            //If using DbContext instead of ObjectContext, we could do eg
            //_context.SupplierCity.RemoveRange(_selectedRecord.SupplierCity)
            BindingSource.RemoveCurrent();
            if (_amenities.Contains(_selectedRecord)) {
                _amenities.Remove(_selectedRecord);
            }
        }

        private void CheckEditHeader_Click(object sender, EventArgs e)
        {
            if (CheckEditHeader.Checked) {
                LabelItemDesc1.Text = "Header Name";
            }
            else {
                LabelItemDesc1.Text = "Item 1 Description";
            }
        }

        private void TreeList_CalcNodeDragImageIndex(object sender, CalcNodeDragImageIndexEventArgs e)
        {
            _imageIndex = TreeListAmenities.FocusedNode.ImageIndex;
            Console.WriteLine("Index = " + e.ImageIndex);
        }

        private void BarButtonItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SaveRecord(false))
                RefreshRecord();
        }

        private void BarButtonItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteRecord();
        }

        private void DeleteRecord()
        {
            if (_selectedRecord == null)
                return;

            try {
                if (DisplayHelper.QuestionYesNo(this, "Are you sure you want to delete this record?") == DialogResult.Yes) {
                    //ignoreLeaveRow and ignorePositionChange are set because when removing a record, the bindingsource_currentchanged 
                    //and gridview_beforeleaverow events will fire as the current record is removed out from under them.
                    //We do not want these events to perform their usual code of checking whether there are changes in the active
                    //record that should be saved before proceeding, because we know we have just deleted the active record.
                    RemoveRecord();
                    if (!_selectedRecord.IsNew()) {
                        //Apparently a record which has just been added is not flagged for deletion by BindingSource.RemoveCurrent,
                        //(the EntityState remains unchanged).  It seems like it is not tracked by the context even though it is, because
                        //the EntityState changes for modification. So if this is a deletion and the entity is not flagged for deletion, 
                        //delete it manually.
                        if (_selectedRecord != null && (_selectedRecord.EntityState & System.Data.Entity.EntityState.Deleted) != System.Data.Entity.EntityState.Deleted)
                            _context.AMENITY.DeleteObject(_selectedRecord);
                        _context.SaveChanges();
                    }
                    if (TreeListAmenities.Nodes.Count == 0) {
                        ClearBindings();
                    }
                    SetBindings();
                    TreeListAmenities.Focus();
                    ShowActionConfirmation("Record Deleted");
                }
            }
            catch (Exception ex) {
                DisplayHelper.DisplayError(this, ex);
                RefreshRecord();        //pull it back from db because that is its current state
                //We must also Load and rebind the related entities from the db because context.Refresh doesn't do that
                SetBindings();
            }
        }

        private void RefreshRecord()
        {
            //A Detached record has not yet been added to the context
            //An Added record has been added but not yet saved, most likely because there was
            //an error in SaveRecord, in which case we should not retrieve it from the db
            if (_selectedRecord != null && _selectedRecord.EntityState != System.Data.Entity.EntityState.Detached
                && _selectedRecord.EntityState != System.Data.Entity.EntityState.Added) {
                _context.Refresh(RefreshMode.StoreWins, _selectedRecord);
                SetReadOnlyKeyFields(true);
            }
        }

        private void TreeListAmenities_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            _selectedRecord = ((AMENITY)BindingSource.Current);
        }
    }
}