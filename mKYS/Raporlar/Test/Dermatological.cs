using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace mKYS.Raporlar.Test
{
    public partial class Dermatological : DevExpress.XtraReports.UI.XtraReport
    {
        public Dermatological()
        {
            InitializeComponent();
        }

        public static string raporno;

        public void bilgi()
        {
            pRaporNo.Value = raporno;
        }

        private void xrRichText4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {


        }
    }
}
