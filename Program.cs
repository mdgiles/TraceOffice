using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using FlexCore;
using System.Configuration;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Diagnostics;

namespace FlexOffice
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                DevExpress.Skins.SkinManager.EnableFormSkins();
                DevExpress.UserSkins.BonusSkins.Register();
                UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

                string startupForm, configSet;
                getCommandLineArgs(out configSet, out startupForm);

                var sys = new FlexCore.CoreSys(configSet);

                if (!string.IsNullOrWhiteSpace(sys.LastError))
                    throw new Exception(sys.LastError);
                string idFile = Environment.GetEnvironmentVariable("userprofile") + "\\resagent.id";
                string agtName = "";
                if (File.Exists(idFile)) {
                    StreamReader sr = File.OpenText(idFile);
                    agtName = sr.ReadLine();
                    sr.Close();
                }
                else {
                    agtName = System.Environment.GetEnvironmentVariable("username");
                }
                sys.User.Name = agtName;
                sys.User.Password = "$PreAuth$";

                if (!sys.User.Validate(sys)) {
                    throw new Exception("You are an invalid user. Please login with valid user ID.");
                }
                else {
                    if (!sys.User.Agency.Validate(sys))
                        throw new Exception(sys.User.Agency.LastError);

                    if (!sys.User.InHouse) {
                        throw new Exception("You are an invalid user. Please login with valid user ID.");
                    }

                    if (string.IsNullOrEmpty(startupForm)) {
                        Application.Run(new MainMenu(sys));
                    }
                    else {
                        Type t = Type.GetType("TraceForms." + startupForm + ", TraceForms");
                        if (t == null) {
                            throw new Exception(string.Format("Form {0} could not be found.", startupForm));
                        }
                        object[] args = { sys };
                        Form frm = Activator.CreateInstance(t, args) as Form;
                        frm.ShowInTaskbar = true;
                        frm.MinimizeBox = true;
                        frm.MaximizeBox = true;
                        frm.Tag = Environment.GetCommandLineArgs();
                        Application.Run(frm);
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private static void getCommandLineArgs(out string configSet, out string startupForm)
        {
            configSet = string.Empty;
            startupForm = string.Empty;
            var result = Environment.GetCommandLineArgs();
            foreach (string arg in result) {
                if (arg.StartsWith("/data=")) {
                    string[] args = arg.Split('=');
                    configSet = args[1];
                }
                if (arg.StartsWith("/form=")) {
                    string[] args = arg.Split('=');
                    startupForm = args[1];
                }
            }
        }

    }
}

