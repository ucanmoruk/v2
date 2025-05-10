using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;

namespace mKYS.Raporlar.Test
{
    public partial class CDermatoloji : DevExpress.XtraReports.UI.XtraReport
    {
        public CDermatoloji()
        {
            InitializeComponent();
        }

        public static string tID;

        sqlbaglanti bgl = new sqlbaglanti();

        public static string raporno;

        public void bilgi()
        {
            pRaporNo.Value = raporno;
            this.Dpi = 300;
            pID.Value = tID;


            SqlCommand komut12 = new SqlCommand(@"SELECT 
        Bileşenler = STUFF(
        (SELECT ', ' + INCIName 
         FROM rUGDFormül where UrunID = '" + tID + "' ORDER BY Miktar DESC FOR XML PATH(''), TYPE ).value('.', 'NVARCHAR(MAX)'),  1, 2, '' )", bgl.baglanti());
            SqlDataReader dr12 = komut12.ExecuteReader();
            while (dr12.Read())
            {
                pING.Value = dr12["Bileşenler"].ToString();
            }
            bgl.baglanti().Close();
        }

        private void xrRichText4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {


        }
    }
}
