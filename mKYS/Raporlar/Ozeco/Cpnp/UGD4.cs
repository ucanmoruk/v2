using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace mKYS.Raporlar.Ozeco.Cpnp
{
    public partial class UGD4 : DevExpress.XtraReports.UI.XtraReport
    {
        public UGD4()
        {
            InitializeComponent();
        }
        public static string tID;


        public void bilgi()
        {
            pID.Value = tID;
        }

    }
}
