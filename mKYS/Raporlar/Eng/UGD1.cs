﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;

namespace mKYS.Raporlar.Eng
{
    public partial class UGD1 : DevExpress.XtraReports.UI.XtraReport
    {
        public UGD1()
        {
            InitializeComponent();
        }
        public static string tID;

        sqlbaglanti bgl = new sqlbaglanti();

        string m, c, s, k, fm;

        private void xrPictureBox8_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {

        }

        private void xrLabel67_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            if (e.PageIndex == 0)
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        public void bilgi()
        {
            pID.Value = tID;

            SqlCommand komut12 = new SqlCommand(@"select * from rUGDDetay2 where UrunID = '"+tID+"'", bgl.baglanti());
            SqlDataReader dr12 = komut12.ExecuteReader();
            while (dr12.Read())
            {
                m = dr12["MResim"].ToString();
                c = dr12["CResim"].ToString();
                s = dr12["Sresim"].ToString();
                k = dr12["Kutu"].ToString();
            }
            bgl.baglanti().Close();

            if (m == null || m == "")
                pMikro.Value = null;
            else
                pMikro.Value = @"http://" + "www.rootarge.com/mRoot/Foto" + "/" + m;

            if (c == null || c == "")
                pChallenge.Value = null;
            else
                pChallenge.Value = @"http://" + "www.rootarge.com/mRoot/Foto" + "/" + c;

            if (s == null || s == "")
                pStabilite.Value = null;
            else
                pStabilite.Value = @"http://" + "www.rootarge.com/mRoot/Foto" + "/" + s;

            if (k == null || k == "")
                pKutu.Value = null;
            else
                pKutu.Value = @"http://" + "www.rootarge.com/mRoot/Foto" + "/" + k;

            SqlCommand komut2 = new SqlCommand(@"select * from RootTedarikci where ID in (select FirmaID from rUGDListe where ID = '" + tID + "' )", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                fm = dr2["Logo"].ToString();
            }
            bgl.baglanti().Close();

            if (fm == null || fm == "")
                pFirmaLogo.Value = null;
            else
                pFirmaLogo.Value = @"http://" + "www.rootarge.com/mRoot/Logo" + "/" + fm;


        }

    }
}
