using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;

namespace mKYS.Raporlar.Newest.Tr
{
    public partial class UGD1 : DevExpress.XtraReports.UI.XtraReport
    {
        public UGD1()
        {
            InitializeComponent();
        }
        public static string tID;

        sqlbaglanti bgl = new sqlbaglanti();

        string m, c, s, k, u;

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

            pMikro.Value = @"http://" + "www.rootarge.com/mRoot/Foto" + "/" + m;
            pChallenge.Value = @"http://" + "www.rootarge.com/mRoot/Foto" + "/" + c;
            pStabilite.Value = @"http://" + "www.rootarge.com/mRoot/Foto" + "/" + s;
            pKutu.Value = @"http://" + "www.rootarge.com/mRoot/Foto" + "/" + k;

            SqlCommand komut2 = new SqlCommand(@"select * from Fotograf where RaporID = '" + tID + "'", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                u = dr2["Path"].ToString();
            }
            bgl.baglanti().Close();

            pUrun.Value = @"http://" + "www.rootarge.com/mRoot/Foto" + "/" + u;

        }

    }
}
