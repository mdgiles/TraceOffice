using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using System.Drawing;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors;
using System.ComponentModel;
using DevExpress.XtraEditors.Popup;
using System.Reflection;

namespace TraceForms.AzureBlobBrowser
{
    [UserRepositoryItem("RegisterCustomEdit")]
    public class RepositoryItemAzureBlobBrowser : RepositoryItemPopupContainerEdit
    {
        static readonly object _updateDisplayFilter = new object();

        static RepositoryItemAzureBlobBrowser() { RegisterCustomEdit(); }

        public RepositoryItemAzureBlobBrowser() { }

        public const string CustomEditName = "AzureBlobBrowser";

        public override string EditorTypeName { get { return CustomEditName; } }

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
              typeof(SearchLookUpEditBaseViewInfo), new ButtonEditPainter(), true, img));
        }

        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try {
                base.Assign(item);
                RepositoryItemAzureBlobBrowser source = item as RepositoryItemAzureBlobBrowser;
                if (source == null)
                    return;
                //Events.AddHandler(_updateDisplayFilter, source.Events[_updateDisplayFilter]);
            }
            finally {
                EndUpdate();
            }
        }
    }
}