using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using System.Threading;
using System.Globalization;
using MMXReport.Properties;

namespace MMXReport
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            if (!string.IsNullOrWhiteSpace(Settings.Default.LastUICulture))
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.LastUICulture);

            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            Application.Run(new MainForm());
        }
    }
}