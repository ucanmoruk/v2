using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace mROOT.Raporlar.Ozeco
{
    public partial class Allergens : DevExpress.XtraReports.UI.XtraReport
    {
        public Allergens()
        {
            InitializeComponent();
        }

        public static string tID;
        public void bilgi()
        {
            SubID.Value = tID;
        }

    }
}
