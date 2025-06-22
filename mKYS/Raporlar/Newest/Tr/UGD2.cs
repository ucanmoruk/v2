using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;

namespace mKYS.Raporlar.Newest.Tr
{
    public partial class UGD2 : DevExpress.XtraReports.UI.XtraReport
    {
        public UGD2()
        {
            InitializeComponent();
        }
        public static string tID;
        public static string detayID, alerjenID;
        sqlbaglanti bgl = new sqlbaglanti();

        public void bilgi()
        {
            pID.Value = tID;
            detayID = null;
            alerjenID = null;
        }

        private void GroupFooter1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
            SqlCommand komut12 = new SqlCommand(@"select ID from rUGDFormül where INCIName in (
            select INCIName from rCosing where Functions like '%PRESER%' )
            and UrunID = '" + tID + "' ", bgl.baglanti());
            SqlDataReader dr12 = komut12.ExecuteReader();
            while (dr12.Read())
            {
                detayID = dr12["ID"].ToString();
            }
            bgl.baglanti().Close();

            if (detayID == "" || detayID == null)
            {
                this.GroupFooter1.Visible = false;
            }
            else
            {

            }
        }

        private void GroupFooter2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            SqlCommand komut2 = new SqlCommand(@"select ID from rUGDFormül where INCIName in (
            select INCIName from rCosing where Kategori = 'Alerjen' )
            and UrunID = '" + tID + "' ", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                alerjenID = dr2["ID"].ToString();
            }
            bgl.baglanti().Close();

            if (alerjenID == "" || alerjenID == null)
            {
                this.GroupFooter2.Visible = false;
            }
            else
            {

            }
        }
    }
}
