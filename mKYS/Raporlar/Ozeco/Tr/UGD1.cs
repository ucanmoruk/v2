using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace mKYS.Raporlar.Ozeco.Tr
{
    public partial class UGD1 : DevExpress.XtraReports.UI.XtraReport
    {
        public UGD1()
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
