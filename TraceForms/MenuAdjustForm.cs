using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FlexModel;
using System.Linq;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;
namespace TraceForms
{
    
    public partial class MenuAdjustForm : DevExpress.XtraEditors.XtraForm
    {
        public FlextourEntities context;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public MenuAdjustForm(FlexCore.CoreSys _sys)
        {
            InitializeComponent();
            Connection.EFConnectionString = _sys.Settings.EFConnectionString;
            context = new FlextourEntities(_sys.Settings.EFConnectionString);

            menuItemRestrictionBindingSource.DataSource = context.MenuItemSecurity;

            treeList1.FilterConditions.Clear();
            menuConfigParentBindingSource.DataSource = context.MenuItem;
            
            treeList1.KeyFieldName = "ID";
            treeList1.ParentFieldName = "ParentID";
            treeList1.OptionsBehavior.EnableFiltering = true;
            treeList1.BeginSort();
            treeList1.Columns["Position"].SortOrder = SortOrder.Ascending;
            treeList1.EndSort();
            treeList1.ExpandAll();
        }

        private void menuConfigParentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to save these changes?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                menuConfigParentBindingSource.EndEdit();
                context.SaveChanges();
                panelControlStatus.Visible = true;
                LabelStatus.Text = "Record Saved";
                rowStatusSave = new Timer();
                rowStatusSave.Interval = 3000;
                rowStatusSave.Start();
                rowStatusSave.Tick += TimedEventSave;

            }
        }

        private void TimedEventSave(object sender, EventArgs e)
        {
            panelControlStatus.Visible = false;
            rowStatusSave.Stop();
        }

        private void addNewMenuItem_Click(object sender, EventArgs e)
        {
            menuItemRestrictionBindingSource.AddNew();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            menuItemRestrictionBindingSource.EndEdit();
            context.SaveChanges();
        }

        private void deleteMenuItem_Click(object sender, EventArgs e)
        {
            menuItemRestrictionBindingSource.RemoveCurrent();
            menuItemRestrictionBindingSource.EndEdit();
            context.SaveChanges();
        }

      
    }
}