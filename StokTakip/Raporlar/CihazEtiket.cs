using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace StokTakip.Raporlar
{
    public partial class CihazEtiket : DevExpress.XtraReports.UI.XtraReport
    {
        public CihazEtiket()
        {
            InitializeComponent();
        }
        public void bilgi()
        {
            pDurum.Value = "Aktif";
        }
    }
}
