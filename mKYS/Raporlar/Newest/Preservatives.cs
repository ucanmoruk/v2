using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace mROOT.Raporlar.Newest
{
    public partial class Preservatives : DevExpress.XtraReports.UI.XtraReport
    {
        public Preservatives()
        {
            InitializeComponent();
        }

        public static string tID;
        public void bilgi()
        {
            Sub2ID.Value = tID;
        }

    }
}
