using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;

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

            //  Application.Run(new mROOT._9.UGDR.ürünfotoları());
             Application.Run(new Giris());
            // Application.Run(new mKYS.Duyuru.Okuduklarim());
        }
    }
}
