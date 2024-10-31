using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using System.Runtime.InteropServices;
using DevExpress.XtraEditors;

namespace mKYS
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
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();


            //  Application.Run(new mROOT._9.UGDR.cosIng());
            //  Application.Run(new Giris());
            // Application.Run(new mKYS.Duyuru.Okuduklarim());


            WindowsFormsSettings.ForceDirectXPaint();
            WindowsFormsSettings.EnableFormSkins();

            if (Environment.OSVersion.Version.Major >= 6) { SetProcessDPIAware(); } // Windows Vista ve üzeri olduğunda çalışır.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Giris());
        }
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

    }
}
