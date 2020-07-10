using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Text;
using System.IO;
using FlexModel;
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
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public bool temp = false;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        FlextourEntities _context;
        AMENITY _selectedRecord;
        Timer _actionConfirmation;
        bool _ignoreLeaveRow = false, _ignorePositionChange = false;
        int? _imageIndex;

        public AmenityForm(FlexCore.CoreSys _sys)
        {
            InitializeComponent();

            Connection.EFConnectionString = _sys.Settings.EFConnectionString;
            _context = new FlextourEntities(_sys.Settings.EFConnectionString);
            _sys.Connect("");
            imagesRoot = _sys.Settings.ImagesRoot;
            _sys.Disconnect();
            modified = false;
            newRec = false;
            
            setreadonly(true);
            ComboBoxEditFilterBySvcType.Focus();
        }

        void SetReadOnly(bool value)
        {
            foreach (Control control in xtraScrollableControl1.Controls) {
                control.Enabled = !value;
            }
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

        void setreadonly(bool valid)
        {
            TextEditCode.Properties.ReadOnly = valid;
        }

        void setItems(bool valid)
        {
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

        private void sVC_TYPEComboBoxEdit_TextChanged(object sender, EventArgs e)
        {
            if (newRec == true)
                return;

            if (ComboBoxEditFilterBySvcType.Text == "HTL")
            {
                TreeListAmenities.ResetAutoFilterConditions();
                //treeList1.FilterConditions.Clear();
                BindingSource.DataSource = from c in _context.AMENITY where c.SVC_TYPE == "HTL" orderby c.SORT_ORDER select c;
                colITEM_DESC1.Caption = "HOTEL AMENITIES";
                //  treeList1.BeginSort();
                //TreeList.Columns["SORT_ORDER"].SortOrder = SortOrder.Ascending; test
                //    treeList1.EndSort();
                TreeListAmenities.ExpandAll();
                ComboBoxEditFilterBySvcType.Focus();
                TreeListAmenities.MoveFirst();
            }
            if (ComboBoxEditFilterBySvcType.Text == "PKG")
            {
                TreeListAmenities.ResetAutoFilterConditions();
                //treeList1.FilterConditions.Clear();
                BindingSource.DataSource = from c in _context.AMENITY where c.SVC_TYPE == "PKG" orderby c.SORT_ORDER select c;
                // treeList1.BeginSort();
                TreeListAmenities.Columns["SORT_ORDER"].SortOrder = SortOrder.Ascending;
                //  treeList1.EndSort();
                colITEM_DESC1.Caption = "PACKAGE AMENITIES";
                TreeListAmenities.ExpandAll();
                ComboBoxEditFilterBySvcType.Focus();
                TreeListAmenities.MoveFirst();
            }
            //if (sVCComboBoxEdit.Text == "CAR")
            //{
            //    treeList1.FilterConditions.Clear();
            //    AmenityBindingSource.DataSource = from c in context.AMENITY where c.SVC_TYPE == "CAR" orderby c.SORT_ORDER select c;
            //    //treeList1.BeginSort();
            //    colITEM_DESC1.Caption = "CAR AMENITIES";
            //    treeList1.Columns["SORT_ORDER"].SortOrder = SortOrder.Ascending;
            //    // treeList1.EndSort();
            //    treeList1.ExpandAll();
            //    sVCComboBoxEdit.Focus();
            //    treeList1.MoveFirst();
            //}
            if (ComboBoxEditFilterBySvcType.Text == "OPT")
            {
                TreeListAmenities.ResetAutoFilterConditions();
                //treeList1.FilterConditions.Clear();
                BindingSource.DataSource = from c in _context.AMENITY where c.SVC_TYPE == "OPT" orderby c.SORT_ORDER select c;
                //treeList1.BeginSort();
                TreeListAmenities.Columns["SORT_ORDER"].SortOrder = SortOrder.Ascending;
                //treeList1.EndSort();
                colITEM_DESC1.Caption = "OPTIONAL SERVICE AMENITIES";
                TreeListAmenities.ExpandAll();
                ComboBoxEditFilterBySvcType.Focus();
                TreeListAmenities.MoveFirst();
            }
            //if (sVCComboBoxEdit.Text == "CRU")
            //{
            //    treeList1.FilterConditions.Clear();
            //    AmenityBindingSource.DataSource = from c in context.AMENITY where c.SVC_TYPE == "CRU" orderby c.SORT_ORDER  select c;
            //    //treeList1.BeginSort();
            //    treeList1.Columns["SORT_ORDER"].SortOrder = SortOrder.Ascending;
            //    //treeList1.EndSort();
            //    colITEM_DESC1.Caption = "CRUISE AMENITIES";
            //    treeList1.ExpandAll();
            //    sVCComboBoxEdit.Focus();
            //    treeList1.MoveFirst();
            //}
            //if (sVCComboBoxEdit.Text == "AIR")
            //{
            //    treeList1.FilterConditions.Clear();
            //    AmenityBindingSource.DataSource = from c in context.AMENITY where c.SVC_TYPE == "AIR" orderby c.SORT_ORDER select c;
            //    //treeList1.BeginSort();
            //    treeList1.Columns["SORT_ORDER"].SortOrder = SortOrder.Ascending;
            //    //treeList1.EndSort();
            //    treeList1.ExpandAll();
            //    colITEM_DESC1.Caption = "AIR AMENITIES";
            //    sVCComboBoxEdit.Focus();
            //    treeList1.MoveFirst();
            //}
            ComboBoxEditFilterBySvcType.Focus();
        }

        private void LabelControlUp_Click(object sender, EventArgs e)
        {
            ///ARGHHHHH TREELIST I WILL BE BACK LATER///////////////
            if (BindingSource.Current != null)
            {
                if (TreeListAmenities.FocusedNode.PrevVisibleNode == null || TreeListAmenities.FocusedNode.PrevNode == null)
                    return;

                if (TreeListAmenities.FocusedNode.PrevNode.HasChildren == true)
                {
                    do
                    {
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

                if (TreeListAmenities.FocusedNode.PrevNode.HasChildren == false)
                {
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
            if (BindingSource.Current != null)
            {
                if (TreeListAmenities.FocusedNode.NextVisibleNode == null)
                    return;
                if (TreeListAmenities.FocusedNode.NextNode == null)
                    return;

                if (TreeListAmenities.FocusedNode.NextNode.HasChildren == true)
                {
                    do
                    {
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

                if (TreeListAmenities.FocusedNode.NextNode.HasChildren == false)
                {
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
            try
            {
                pic = new Bitmap(imagesRoot + ButtonEditImage.Text);
                ErrorProvider.SetError(ButtonEditImage, "");
            }
            catch
            {
                try
                {
                    pic = new Bitmap(ButtonEditImage.Text);
                    ErrorProvider.SetError(ButtonEditImage, "");
                }
                catch
                {
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

        private void PropogateOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //update amenassgn set sort_order = (select sort_order from amenity where
            //amenity.code = amenassgn.code and amenity.svc_type = cboType)
            var propogatedRecs = from assignRec in _context.AMENASSGN
                                 from amenityRec in _context.AMENITY
                                 where amenityRec.SVC_TYPE == ComboBoxEditFilterBySvcType.Text && assignRec.SVC_TYPE == ComboBoxEditFilterBySvcType.Text && assignRec.CODE == amenityRec.CODE
                                 select new { amenityRec.CODE, amenityRec.SORT_ORDER };
            Dictionary<string, int> amenitySort = new Dictionary<string, int>();
            foreach (var val in propogatedRecs)
                amenitySort[val.CODE] = (int)val.SORT_ORDER;
            foreach (AMENASSGN rec in _context.AMENASSGN)
            {
                if (amenitySort.ContainsKey(rec.CODE))
                    rec.SORT_ORDER = amenitySort[rec.CODE];
            }
            _context.SaveChanges();

        }

        private void PropogateDeletionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //delete from amenassgn where svc_type = cboType and code not in 
            //(select code from amenity where svc_type = cboType)
            var propogatedRecs = from assignRec in _context.AMENASSGN
                                 from amenityRec in _context.AMENITY
                                 where amenityRec.SVC_TYPE == ComboBoxEditFilterBySvcType.Text && assignRec.SVC_TYPE == ComboBoxEditFilterBySvcType.Text && assignRec.CODE != amenityRec.CODE
                                 select assignRec;
            foreach (AMENASSGN rec in propogatedRecs)
            {
                _context.AMENASSGN.DeleteObject(rec);
            }

            _context.SaveChanges();
        }

        private void AmenityBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (BindingSource.Current != null)
            {
                if (CheckEditHeader.Checked)
                {
                    setItems(true);
                    TextEditItem_Desc1.Properties.ReadOnly = false;
                }
                else
                {
                    setItems(false);

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
                bool newRec = _selectedRecord.IsNew();
                bool modified = newRec || IsModified(_selectedRecord);
                bool nameChanged = _selectedRecord.IsModified(_context, "NAME");

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
                    _context.SaveChanges();
                    //BindingSource
                    ShowActionConfirmation("Record Saved");
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
            _ignoreLeaveRow = true;
            _ignorePositionChange = true;
            _selectedRecord = null;
            SetReadOnly(true);
            BarButtonItemDelete.Enabled = false;
            BarButtonItemSave.Enabled = false;
            BindingSource.DataSource = typeof(AMENITY);
            _ignoreLeaveRow = false;
            _ignorePositionChange = false;
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
            BindingSource.EndEdit();
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
            //TreeList tree = sender as TreeList;
            //Point point = tree.PointToClient(MousePosition);
            //TreeListHitInfo hitInfo = tree.CalcHitInfo(point);
            //AMENITY amenity = (AMENITY)tree.GetRow(e.SourceNode.Id);
            ////if (e.DestinationNode != null) {
            ////    cust.SORT_ORDER = ((Customer)tree.GetRow(e.DestinationNode.Id)).SORT_ORDER;
            ////}
            ////else 
            //amenity.SORT_ORDER = ((AMENITY)tree.GetRow(hitInfo.Node.Id)).SORT_ORDER;
        }

        private void BarButtonItemNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _ignoreLeaveRow = true;       //so that when the grid row changes it doesn't try to save again
            if (SaveRecord(true)) {
                //For some reason when there is no existing record in the binding source the Add method does not
                //trigger the CurrentChanged event, but AddNew does so use that instead
                _selectedRecord = (AMENITY)BindingSource.AddNew();
                //With the instant feedback data source, the new row is not immediately added to the grid, so move
                //the focused row to the filter row just so that no other existing row is visually highlighted
                
                SetReadOnlyKeyFields(false);
                TextEditCode.Focus();
                SetReadOnly(false);
            }
            ErrorProvider.Clear();
            _ignoreLeaveRow = false;
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
                    _ignoreLeaveRow = true;
                    _ignorePositionChange = true;
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
                    _ignoreLeaveRow = false;
                    _ignorePositionChange = false;
                    SetBindings();
                    TreeListAmenities.Focus();
                    ShowActionConfirmation("Record Deleted");
                }
            }
            catch (Exception ex) {
                DisplayHelper.DisplayError(this, ex);
                _ignoreLeaveRow = false;
                _ignorePositionChange = false;
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
    }
}