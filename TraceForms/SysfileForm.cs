using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Security.Permissions;
using Microsoft.Win32;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.Management;
using System.IO;
using FlexModel;
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



namespace TraceForms
{
    
    public partial class SysfileForm : XtraForm
    {
        public string currentVal;
        public bool modified = false;
        public bool newRec = false;
        public Timer rowStatusDelete;
        public Timer rowStatusSave;
        public bool temp = false;
        public string dataPath;
        public  FlextourEntities context;
        public string username;


        public SysfileForm(FlexInterfaces.Core.ICoreSys sys)
        {
            InitializeComponent();
            Connect(sys);
            LoadLookups();

            if (!string.IsNullOrWhiteSpace(sys.Settings.PaymentProcessorLoginId))
            {
                
                string output = string.Empty;
                //FlexCore.CoreSys.AES_Decrypt(sys.Settings.PaymentProcessorLoginId, "0r!0n", ref output);
                //AES_Decrypt(sys.Settings.PaymentProcessorLoginId, "0r!0n", ref output);
                TextEditPaymentLogin.Text = sys.Settings.PaymentProcessorLoginId;
            }

            if (!string.IsNullOrWhiteSpace(sys.Settings.PaymentProcessorTxKey))
            {
                string output = string.Empty;
                //Fl//exCore.CoreSys.AES_Decrypt(sys.Settings.PaymentProcessorTxKey, "0r!0n", ref  output );
                //AES_Decrypt(sys.Settings.PaymentProcessorTxKey, "0r!0n", ref output);
                TextEditTransKey.Text = sys.Settings.PaymentProcessorTxKey;
            }
        }

        private void Connect(FlexInterfaces.Core.ICoreSys sys)
        {
            Connection.EFConnectionString = sys.Settings.EFConnectionString;
            context = new FlextourEntities(sys.Settings.EFConnectionString);
            username = sys.User.Name;
            dataPath = sys.Settings.DataPath;
            string val = sys.Settings.CommandLine;
            SysFileBindingSource.DataSource = context.SYSFILE.Include("CreditCardInfo");           
        }

        private void LoadLookups()
        {
            
            string currentVal;
            XmlDocument xDoc = new XmlDocument();
            XmlNode g_xmlLic;
            bool g_blnNoLicense = false;
            string path = "";
            var value = Environment.GetCommandLineArgs();
            foreach (string dir in value)
            {
               
                if (dir.StartsWith("/data="))
                {
                    
                    path = dir.Substring("/data=".Length, dir.Length - "/data=".Length);
                    //xDoc.LoadXml(path + "flexlic.dat");
                }

                if (dir.StartsWith("/nolicense"))
                    g_blnNoLicense = true;
            }
            if (string.IsNullOrEmpty(path))
                path = "Files";
            string registry_key = @"SOFTWARE\Flextour\" + path;

            RegistryKey subKey = Registry.LocalMachine.OpenSubKey(registry_key);
            string sDataDir = subKey.GetValue("Data", "").ToString();

            if (!sDataDir.EndsWith(@"\"))
                sDataDir += @"\";
            StreamReader loader;
            loader = File.OpenText(sDataDir + "flexlic_cbc.dat");
            string cypherText = loader.ReadToEnd();
            loader.Close();

            BlowFish decode = new BlowFish("f10r!da");
            string plainText = decode.Decrypt_CBC(cypherText);

            try
            {
                xDoc.LoadXml(plainText);
            }
            catch
            {

            }

          

            if (g_blnNoLicense)
            {
                //not sure if we need this code here but leaving the space for it
                /*
                 *   strVal = g_XMLLic.Attributes("bypass").Value
            Pwd = New Library.Password
            With Pwd
                .Wide = False
                .Title = "Licensing Bypass"
                .Prompt = "Please enter the password to bypass licensing."
                .ShowUser = False
                .PwdMatch = strVal
                .PwdLabel = "Password"
                .Password = ""
                .Show(Library.enumModality.Modal)
                If .Cancelled Then
                    g_blnNoLicense = False
                    sMsg = "Licensing bypass refused."
                    Throw New FlexException(sMsg)
                Else
                    g_XMLLic = XMLDoc.SelectSingleNode("license/logical")
                    Return True
                End If
            End With
                */
            }
            g_xmlLic = xDoc.SelectSingleNode("license/system");
            currentVal = g_xmlLic.Attributes["path"].Value;
            if (currentVal.Length > 0)
            {
                if(currentVal.EndsWith(@"\"))
                    currentVal += @"\";
                if (currentVal.ToLower() != sDataDir.ToLower())
                {
                    MessageBox.Show("You are attempting to run FlexTour in an unlicensed database.");
                    return;
                }
            }

            currentVal = g_xmlLic.Attributes["generated"].Value;
            if (DateTime.Today < Convert.ToDateTime(currentVal))
            {
                MessageBox.Show("License file is invalid.");
                return;
            }

            g_xmlLic = xDoc.SelectSingleNode("license/physical/maintenance");
            currentVal = g_xmlLic.Attributes["enabled"].Value;
            if (!Convert.ToBoolean(currentVal))
            {
                MessageBox.Show("You are not licensed to run the FlexTour Maintenance module.");
                return;
            }


            currentVal = g_xmlLic.Attributes["expires"].Value;
            if (Convert.ToBoolean(currentVal))
            {
                currentVal = g_xmlLic.Attributes["expiredate"].Value;
                if (DateTime.Today >= Convert.ToDateTime(currentVal))
                {
                    MessageBox.Show("Your license for the FlexTour Maintenance module has expired.");
                    return;
                }
               
            }

            g_xmlLic = xDoc.SelectSingleNode("license/system");
            currentVal = g_xmlLic.Attributes["counted"].Value;

            if (Convert.ToBoolean(currentVal))
            {
                currentVal = g_xmlLic.Attributes["usercount"].Value;
                string location = sDataDir + "flexlic.cnt";
                if (File.Exists(location))
                {
                    //return here for user code
                }
            }
            CheckEdit[] flags = {CheckEditGlFlg, CheckEditApFlag, CheckEditArFlag, CheckEditHist, CheckEditICFlag, CheckEditDirectBook, CheckEditFlexPkgs, CheckEditTourfax, CheckEditRemBook};
            string[] xmlKeys = new string[] { "gl", "ap", "ar", "history", "inventory", "directs", "flexpkgs", "tourfax", "remotes" };

            SYSFILE x = (SYSFILE)SysFileBindingSource.Current;
            if (x != null)
            {
                foreach (CheckEdit flag in flags)
                foreach (string xml in xmlKeys)
                {
                    string node = "license/logical/" + xml;
                       checkModuleLicense(xDoc, node, flag);
                }
                setEdits(x);
            }

                CheckEditDirectBook.Checked = (x.DIRECT_AGY.Length > 0);
                TextEditDirectAgy.Enabled = CheckEditDirectBook.Checked;
            
           
            ImageComboBoxItem loadBlank = new ImageComboBoxItem() { Description = "", Value = "" };
            ImageComboBoxEditAgency.Properties.Items.Add(loadBlank);
            ImageComboBoxEditState.Properties.Items.Add(loadBlank);
            ImageComboBoxEditCountry.Properties.Items.Add(loadBlank);           
            ImageComboBoxEditCity.Properties.Items.Add(loadBlank);
            
            var agy = from agyRec in context.AGY orderby agyRec.NO ascending select new { agyRec.NO, agyRec.NAME };
            foreach (var result in agy)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.NO.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.NO.TrimEnd() };
                ImageComboBoxEditAgency.Properties.Items.Add(load);
            }
            var city = from cityrec in context.CITYCOD orderby cityrec.CODE ascending select new { cityrec.CODE, cityrec.NAME };
            foreach (var result in city)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCity.Properties.Items.Add(load);            }

            var state = from stateRec in context.State orderby stateRec.Code ascending select new { stateRec.Code, stateRec.State1 };
            foreach (var result in state)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.Code.TrimEnd() + "  " + "(" + result.State1.TrimEnd() + ")", Value = result.Code.TrimEnd() };
                ImageComboBoxEditState.Properties.Items.Add(load);
            }
            var country = from contRec in context.COUNTRY orderby contRec.CODE ascending select new { contRec.CODE, contRec.NAME };
            foreach (var result in country)
            {
                ImageComboBoxItem load = new ImageComboBoxItem() { Description = result.CODE.TrimEnd() + "  " + "(" + result.NAME.TrimEnd() + ")", Value = result.CODE.TrimEnd() };
                ImageComboBoxEditCountry.Properties.Items.Add(load);
            }

          
        }

        private void checkModuleLicense(XmlDocument xmlDoc, string node, CheckEdit flag)
        {
            XmlNode g_xmlLicense;
            g_xmlLicense = xmlDoc.SelectSingleNode(node);
            string value = g_xmlLicense.Attributes["enabled"].Value;
            if (flag == CheckEditFlexPkgs || flag == CheckEditTourfax || flag == CheckEditRemBook)
                flag.Checked = Convert.ToBoolean(value);
            else
                flag.Enabled = Convert.ToBoolean(value);

           
        }

        private void setEdits(SYSFILE currRec)
        {
           
            //CheckEditGlFlg.Checked = (CheckEditGlFlg.Enabled && currRec.GL_FLG_BOOL);
            //CheckEditApFlag.Checked = (CheckEditGlFlg.Enabled && currRec.GL_FLG_BOOL);
            //CheckEditArFlag.Checked = (CheckEditGlFlg.Enabled && currRec.GL_FLG_BOOL);
            //CheckEditHist.Checked = (CheckEditGlFlg.Enabled && currRec.GL_FLG_BOOL);
            //CheckEditICFlag.Checked = (CheckEditGlFlg.Enabled && currRec.GL_FLG_BOOL);
            //CheckEditDirectBook.Checked = (CheckEditGlFlg.Enabled && currRec.GL_FLG_BOOL);
        }


        private void SysfileForm_Load(object sender, EventArgs e)
        {
            //ComboBoxItemCollection coll = ComboBoxEditDriveSearch.Properties.Items;
            //coll.BeginUpdate();
            //try
            //{
            //    var searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_LogicalDisk");//Find all drives
            //    foreach (ManagementObject queryObj in searcher.Get())
            //    {
            //        try
            //        {
            //            coll.Add(queryObj["Name"].ToString() + " [" + queryObj["ProviderName"].ToString()+"]");//network drive
            //        }
            //        catch
            //        {
            //            try
            //            {
            //                if (string.IsNullOrWhiteSpace(queryObj["VolumeName"].ToString()))//Blank name
            //                    throw new Exception();
            //                coll.Add(queryObj["Name"].ToString() + " [" + queryObj["VolumeName"].ToString() + "]");//Named local drive
            //            }
            //            catch
            //            {
            //                coll.Add(queryObj["Name"].ToString() + " [" + queryObj["Description"].ToString() + "]");//Unnamed local drive
            //            }
            //        }
            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("An error occured while checking system drives");
            //}
            //coll.EndUpdate();

            if (string.IsNullOrWhiteSpace(TextEditCompanyName.Text))
                TextEditCompanyName.Properties.ReadOnly = false;

           
        }


        private void enterControl(object sender, EventArgs e)
        {
            currentVal = ((Control)sender).Text;
        }



        private void iMAGES_ROOTButtonEdit_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            folderBrowserDialog1.SelectedPath = dataPath;
            DirectoryInfo subdir = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
            if (subdir.GetDirectories().Length > 0)
                folderBrowserDialog1.SelectedPath = subdir.GetDirectories()[0].FullName; //Move into first subdirectory
            DialogResult pressed = DialogResult.OK;
            while (pressed == DialogResult.OK)
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (folderBrowserDialog1.SelectedPath.ToLower().IndexOf(dataPath.ToLower()) == -1)
                    {
                        pressed = MessageBox.Show("Folder must be a subdirectory of " + dataPath, "Error", MessageBoxButtons.OKCancel);
                        if (subdir.GetDirectories().Length > 0)
                            folderBrowserDialog1.SelectedPath = subdir.GetDirectories()[0].FullName; //Move into first subdirectory
                    }
                    else
                    {
                        ButtonEditImagesFullPath.Text = folderBrowserDialog1.SelectedPath;
                        validCheck.check(sender, errorProvider1, (( SYSFILE)SysFileBindingSource.Current).checkImages_Full_Path, SysFileBindingSource);
                        pressed = DialogResult.Cancel;
                    }
                }
                else
                    pressed = DialogResult.Cancel;
            }
        }



        private void images_Full_PathButtonEdit_Leave(object sender, EventArgs e)
        {           
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkImages_Full_Path, SysFileBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void rEPORTS_ROOTButtonEdit_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                ((SYSFILE)SysFileBindingSource.Current).DataPath = dataPath;
                validCheck.check(sender, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkReports_Full_Path, SysFileBindingSource);        
                //TextEditName.Text = TextEditName.Text.ToUpper();
            } 
        }

        private void reports_Full_PathButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            //folderBrowserDialog1.SelectedPath = dataPath;
            //DirectoryInfo subdir = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
            //if (subdir.GetDirectories().Length > 0)
            //    folderBrowserDialog1.SelectedPath = subdir.GetDirectories()[0].FullName; //Move into first subdirectory
            //DialogResult pressed = DialogResult.OK;
            //while (pressed == DialogResult.OK)
            //{
            //    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            //    {
            //        if (folderBrowserDialog1.SelectedPath.ToLower().IndexOf(dataPath.ToLower()) == -1)
            //        {
            //            pressed = MessageBox.Show("Folder must be a subdirectory of " + dataPath, "Error", MessageBoxButtons.OKCancel);
            //            if (subdir.GetDirectories().Length > 0)
            //                folderBrowserDialog1.SelectedPath = subdir.GetDirectories()[0].FullName; //Move into first subdirectory
            //        }
            //        else
            //        {
            //            ButtonEditReportsFullPath.Text = folderBrowserDialog1.SelectedPath;
            //            ((SYSFILE)SysFileBindingSource.Current).DataPath = dataPath;
            //            validCheck.check(sender, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkReports_Full_Path, SysFileBindingSource);
            //            pressed = DialogResult.Cancel;
            //        }
            //    }
            //    else
            //        pressed = DialogResult.Cancel;
            //}
        }

     

        private void resNightCutOverDateEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CalendarForm xform = new CalendarForm(sender) { };
            xform.StartPosition = FormStartPosition.CenterScreen;
            xform.Show();
        }

        private void resNightCutOverDateEdit_TextChanged(object sender, EventArgs e)
        {
            DateEditResNightCutOver.Text = validCheck.convertDate(DateEditResNightCutOver.Text);
        }

        private void BindingNavigatorSaveItemSysfile_Click(object sender, EventArgs e)
        {
            TextEditCompanyName.Focus();
            if (SysFileBindingSource.Current == null)
                return;
            
            if (checkForms())
            {
                errorProvider1.Clear();
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

        private bool checkForms()
        {
            if (!modified && !newRec)
                return true;
            bool ok6 = true;
            bool ok7 = true;
            bool ok1 = validCheck.checkAll(xtraScrollableControl1.Controls, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkXtraScroll, SysFileBindingSource);
            bool ok2 = validCheck.checkAll(panelControl3.Controls, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkPanelControl3, SysFileBindingSource);
            bool ok3 = validCheck.checkAll(panelControl4.Controls, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkPanelControl4, SysFileBindingSource);
            bool ok4 = validCheck.checkAll(panelControl5.Controls, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkPanelControl5, SysFileBindingSource);
            bool ok5 = validCheck.checkAll(panelControl6.Controls, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkPanelControl6, SysFileBindingSource);
            if(CreditCardInfoBindingSource.Current != null)
                ok6 = validCheck.checkAll(panelControl7.Controls, errorProvider1, ((CreditCardInfo)CreditCardInfoBindingSource.Current).checkPanelControl7, CreditCardInfoBindingSource);
            if(AddressBindingSource.Current != null)
                ok7 = validCheck.checkAll(panelControl7.Controls, errorProvider1, ((Address)AddressBindingSource.Current).checkPanelControl7, AddressBindingSource);

            if (ok1 && ok2 && ok3 && ok4 && ok5 && ok6 && ok7)
                return validCheck.saveRec(ref modified, true, ref newRec, context, SysFileBindingSource, this.Name, errorProvider1, Cursor);
            else
            {
                validCheck.saveRec(ref modified, false, ref newRec, context, SysFileBindingSource, this.Name, errorProvider1, Cursor);
                return false;
            }
        }


        private void TextEditResEmail_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkRES_EMAIL, SysFileBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void ImageComboBoxEditRateOvr_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                //validCheck.check(sender, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkRES_EMAIL, SysFileBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void ImageComboBoxEditAllowZero_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                //validCheck.check(sender, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkRES_EMAIL, SysFileBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void SpinEditCxlGrace_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkCXLGRACE, SysFileBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void ComboBoxEditDriveSearch_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                 //validCheck.check(sender, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkRES_EMAIL, SysFileBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void SpinEditCxlDays_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkCXL_DAYS, SysFileBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void TextEditEmailServer_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkEMAIL_SERVER, SysFileBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void TextEditSmtpPort_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkSMTP_PORT, SysFileBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void TextEditFaxServer_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkFAX_SERVER, SysFileBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void ComboBoxEditFaxSystem_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                //validCheck.check(sender, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkRES_EMAIL, SysFileBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }

        }

        private void SpinEditSchedHr_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkSCHED_HR, SysFileBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void SpinEditSchedMin_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkSCHED_MIN, SysFileBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void TextEditAttn1_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkATTN1, SysFileBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void TextEditAttn2_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkATTN2, SysFileBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void TextEditAttn3_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkATTN3, SysFileBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void TextEditUnmonitoredEmail_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkUnmonitoredEmail, SysFileBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void TextEditDirectAgy_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkDIRECT_AGY, SysFileBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void TextEditInfoButtonUrl_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkINFO_BUTTON_URL, SysFileBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void SpinEditLockRetry_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkLOCK_RETRY, SysFileBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void TextEditInvNo_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkINV_NO, SysFileBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void TextEditApVoucherNo_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkAPVoucher_No, SysFileBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void DateEditResNightCutOver_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                //validCheck.check(sender, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkRES_EMAIL, SysFileBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void TextEditMcoInvNo_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkMCO_INV_NO, SysFileBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void rMCountSpinEdit_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkRMCount, SysFileBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void typeNameComboBox_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CreditCardInfo)CreditCardInfoBindingSource.Current).checkCardTypeId, CreditCardInfoBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void accountNumberTextEdit_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CreditCardInfo)CreditCardInfoBindingSource.Current).checkAccountNo, CreditCardInfoBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void expirationMonthSpinEdit_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CreditCardInfo)CreditCardInfoBindingSource.Current).checkExpMon, CreditCardInfoBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void expirationYearSpinEdit_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CreditCardInfo)CreditCardInfoBindingSource.Current).checkExpYear, CreditCardInfoBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void cardHolderNameTextEdit_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((CreditCardInfo)CreditCardInfoBindingSource.Current).checkCardHoldName, CreditCardInfoBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void line1TextEdit_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((Address)AddressBindingSource.Current).checkLine1, AddressBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void line2TextEdit_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((Address)AddressBindingSource.Current).checkLine2, AddressBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void line3TextEdit_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((Address)AddressBindingSource.Current).checkLine3, AddressBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void citycod_CodeImageComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((Address)AddressBindingSource.Current).checkCity, AddressBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void state_CodeImageComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((Address)AddressBindingSource.Current).checkState, AddressBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void country_CodeImageComboBoxEdit_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((Address)AddressBindingSource.Current).checkCountry, AddressBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void zipOrPostcodeTextEdit_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((Address)AddressBindingSource.Current).checkZip, AddressBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void TextEditCompanyName_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkCOMPANY_NAME, SysFileBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

    

        private void SysFileBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            SYSFILE x = (SYSFILE)SysFileBindingSource.Current;
            if (x != null)
            {
                int val = (int)x.CreditCardInfo_ID_Default;               
                CreditCardInfoBindingSource.DataSource = from cred in context.CreditCardInfo where cred.ID == val select cred;
                CreditCardInfo value = (CreditCardInfo)CreditCardInfoBindingSource.Current;
                if (value != null)
                {
                    AddressBindingSource.DataSource = from address in context.Address where address.ID == value.Address_ID_BillingAddress select address;
                }

                requireAgyPaymentInfoOnFileCheckEdit.Enabled = (bool)x.AllowElectronicPayments;
                TextEditPaymentLogin.Enabled = (bool)x.AllowElectronicPayments;
                TextEditTransKey.Enabled = (bool)x.AllowElectronicPayments;
            
            }
        }

        private void ImageComboBoxEditAgency_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                validCheck.check(sender, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkDEF_AGY, SysFileBindingSource);
                //TextEditName.Text = TextEditName.Text.ToUpper();
            }
        }

        private void CheckEditSetupFlag_Click(object sender, EventArgs e)
        {
            modified = true;
            TextEditInvNo.Enabled = !(TextEditInvNo.Enabled);
            CheckEditUseRwVoucherNo.Enabled = !(CheckEditUseRwVoucherNo.Enabled);
            TextEditApVoucherNo.Enabled = !(TextEditApVoucherNo.Enabled);
            DateEditResNightCutOver.Enabled = !(DateEditResNightCutOver.Enabled);
            TextEditMcoInvNo.Enabled = !(TextEditMcoInvNo.Enabled);
            
        }

        private void pRT_NET_BOOLCheckEdit_Click(object sender, EventArgs e)
        {
            modified = true;
        }

        private void ButtonEditReportsRoot_Leave(object sender, EventArgs e)
        {
            
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    modified = true;
                    labelControl31.Text = DateTime.Today.ToShortDateString();
                    labelControl32.Text = username;
                }
                ((SYSFILE)SysFileBindingSource.Current).DataPath = dataPath;
                ((SYSFILE)SysFileBindingSource.Current).REPORTS_ROOT = ((Control)sender).Text;
                validCheck.check(sender, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkReports_Full_Path, SysFileBindingSource);                
            } 
        }

        private void CheckEditDirectBook_Click(object sender, EventArgs e)
        {
            modified = true;
            if (CheckEditDirectBook.Checked == true)
            {
                TextEditDirectAgy.Enabled = false;
                TextEditDirectAgy.Text = string.Empty;
            }
            else
            {
                TextEditDirectAgy.Enabled = true;
            }
        }

        private void SysfileForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (modified || newRec)
            {
                DialogResult select = DevExpress.XtraEditors.XtraMessageBox.Show("There are unsaved changes. Are you sure want to exit?", Name, MessageBoxButtons.YesNo);
                if (select == DialogResult.Yes)
                {
                    e.Cancel = false;
                    this.Dispose();
                }
                else if (select == DialogResult.No)
                    e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                this.Dispose();
            }
        }

        private bool AES_Encrypt(string input, string pass, ref string output)
        {
            try
            {
                System.Security.Cryptography.RijndaelManaged AES = new System.Security.Cryptography.RijndaelManaged();
                System.Security.Cryptography.MD5CryptoServiceProvider Hash_AES = new System.Security.Cryptography.MD5CryptoServiceProvider();
                Byte[] hash = new byte[31];
                Byte[] temp = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass));
                Array.Copy(temp, 0, hash, 0, 16);
                Array.Copy(temp, 0, hash, 15, 16);
                AES.Key = hash;
                AES.Mode = System.Security.Cryptography.CipherMode.ECB;
                System.Security.Cryptography.ICryptoTransform DESEncryptor = AES.CreateEncryptor();
                Byte[] Buffer = System.Text.ASCIIEncoding.ASCII.GetBytes(input);
                output = Convert.ToBase64String(DESEncryptor.TransformFinalBlock(Buffer, 0, Buffer.Length));
                return true;
            }
            catch(Exception ex)
            {
                output = ex.Message;
                return false;
            }
        }


        private bool AES_Decrypt(string input, string pass, ref string output)
        {
            try
            {
                System.Security.Cryptography.RijndaelManaged AES = new System.Security.Cryptography.RijndaelManaged();
                System.Security.Cryptography.MD5CryptoServiceProvider Hash_AES = new System.Security.Cryptography.MD5CryptoServiceProvider();
                Byte[] hash = new byte[31];
                Byte[] temp = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass));
                Array.Copy(temp, 0, hash, 0, 16);
                Array.Copy(temp, 0, hash, 15, 16);
                AES.Key = hash;
                AES.Mode = System.Security.Cryptography.CipherMode.ECB;
                System.Security.Cryptography.ICryptoTransform DESDecryptor = AES.CreateDecryptor();
                Byte[] Buffer = System.Text.ASCIIEncoding.ASCII.GetBytes(input);
                output = Convert.ToBase64String(DESDecryptor.TransformFinalBlock(Buffer, 0, Buffer.Length));
                return true;
            }
            catch (Exception ex)
            {
                output = ex.Message;
                return false;
            }
        }

        private void TextEditPaymentLogin_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    if (!string.IsNullOrWhiteSpace(TextEditPaymentLogin.Text))
                    {
                        string password = "0r!0n";
                        string value = TextEditPaymentLogin.Text;
                        string output = string.Empty;
                        FlexCore.CoreSys.AES_Encrypt(value, password, ref output);
                        paymentProcessorLoginIdTextEdit.Text = output;
                    }
                    else
                    {
                       // (SysFileBindingSource.Current)
                        paymentProcessorLoginIdTextEdit.EditValue = string.Empty;
                        paymentProcessorLoginIdTextEdit.Text = string.Empty;
                    }
                      

                    modified = true;

                }
                validCheck.check(sender, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkLodinID, SysFileBindingSource);
              
            }
        }

        private void TextEditTransKey_Leave(object sender, EventArgs e)
        {
            if (SysFileBindingSource.Current != null)
            {
                if (currentVal != ((Control)sender).Text)
                {
                    if (!string.IsNullOrWhiteSpace(TextEditTransKey.Text))
                    {
                        string password = "0r!0n";
                        string value = TextEditTransKey.Text;
                        string output = string.Empty;
                        FlexCore.CoreSys.AES_Encrypt(value, password, ref output);
                        paymentProcessorTxKeyTextEdit.Text = output;
                        
                    }
                    else
                    {
                        // (SysFileBindingSource.Current)
                        paymentProcessorTxKeyTextEdit.EditValue = string.Empty;
                        paymentProcessorTxKeyTextEdit.Text = string.Empty;
                    }
                    modified = true;
                }
                
                validCheck.check(sender, errorProvider1, ((SYSFILE)SysFileBindingSource.Current).checkTransactionKey, SysFileBindingSource);
              
            }
        }

        private void allowElectronicPaymentsCheckEdit_Click(object sender, EventArgs e)
        {
            modified = true;
            if (allowElectronicPaymentsCheckEdit.Checked)
            {
                requireAgyPaymentInfoOnFileCheckEdit.Enabled = false;
                TextEditPaymentLogin.Enabled = false;
                TextEditTransKey.Enabled = false;

            }
            else
            {
                requireAgyPaymentInfoOnFileCheckEdit.Enabled = true;
                TextEditPaymentLogin.Enabled = true;
                TextEditTransKey.Enabled = true;
            }
        }
        /*
    Public Shared Function AES_Decrypt(ByVal input As String, ByVal pass As String, ByVal output As String) As Boolean

        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider

        Try

            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = Convert.FromBase64String(input)
            output = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return True

        Catch ex As Exception

            output = ex.Message
            Return False

        End Try

    End Function

         * 
         * 
         * 
         * 
         *  */


    }
}