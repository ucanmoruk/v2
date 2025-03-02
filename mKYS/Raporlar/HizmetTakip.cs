using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;

namespace mROOT.Raporlar
{
    public partial class HizmetTakip : DevExpress.XtraReports.UI.XtraReport
    {
        public HizmetTakip()
        {
            InitializeComponent();
        }

        public static List<object> seciliyazdir = new List<object>();

        string gemini;
        public void bilgi()
        {

            string degerler = "";

            for (int i = 0; i < seciliyazdir.Count; i++)
            {

                // Numaralandırılmış formatta değer ekliyoruz
                degerler += $"{seciliyazdir[i]};";

                if (i == seciliyazdir.Count - 1)
                {
                    degerler = degerler.TrimEnd(' ', ';');
                }

            }
            gemini = degerler.ToString();
            pID.Value = gemini;
        }



    }
}
