using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace mKYS.Raporlar.Newest.Tr
{
    public partial class UGD3 : DevExpress.XtraReports.UI.XtraReport
    {
        public UGD3()
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
