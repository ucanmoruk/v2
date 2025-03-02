using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using mKYS;
using System.Data.SqlClient;

namespace mROOT.Raporlar.Newest
{
    public partial class UTSEtiket : DevExpress.XtraReports.UI.XtraReport
    {
        public UTSEtiket()
        {
            InitializeComponent();
        }
        public static string tID;

        sqlbaglanti bgl = new sqlbaglanti();

        string m;

        public void bilgi()
        {
            pID.Value = tID;

            SqlCommand komut12 = new SqlCommand(@"SELECT 
        Bileşenler = STUFF(
        (SELECT ', ' + INCIName 
         FROM rUGDFormül where UrunID = '"+tID+"' ORDER BY Miktar DESC FOR XML PATH(''), TYPE ).value('.', 'NVARCHAR(MAX)'),  1, 2, '' )", bgl.baglanti());
            SqlDataReader dr12 = komut12.ExecuteReader();
            while (dr12.Read())
            {
                pIng.Value = dr12["Bileşenler"].ToString();
            }
            bgl.baglanti().Close();

            SqlCommand komut1 = new SqlCommand(@"select * from Fotograf where RaporID = '" + tID + "'", bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                m = dr1["Path"].ToString();
            }
            bgl.baglanti().Close();

            if (m == null || m == "")
                pGorsel.Value = null;
            else
                pGorsel.Value = @"http://" + "www.massgrup.com/mRoot/Foto" + "/" + m;
        }
    }
}
