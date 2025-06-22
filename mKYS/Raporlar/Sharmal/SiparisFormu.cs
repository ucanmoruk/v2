using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Data.SqlClient;
using mKYS;

namespace mKYS.Raporlar
{
    public partial class SiparisFormu : DevExpress.XtraReports.UI.XtraReport
    {
        public SiparisFormu()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();


        public static string tID;

        private double Euro = 0.0;
        private double Dolar = 0.0;
        private DataSet dsDovizKur;
        private void DovizKur()
        {
            dsDovizKur = new DataSet();
            dsDovizKur.ReadXml(@"https://www.tcmb.gov.tr/kurlar/today.xml");
            DataRow dr = dsDovizKur.Tables[1].Rows[0];
            Dolar = Convert.ToDouble(dr[3].ToString().Replace('.', ','));
            dr = dsDovizKur.Tables[1].Rows[3];
            Euro = Convert.ToDouble(dr[3].ToString().Replace('.', ','));

        }
        int o2;
        public void bilgi()
        {
            DovizKur();

            pTID.Value = tID;
            //pDolar.Value = Dolar;
            //pEuro.Value = Euro;

            //SqlCommand komut2 = new SqlCommand("Select Count(ID) from TeklifDetay where TeklifID = N'" + tID + "' and Birim =N'$' and Durum = N'Aktif' ", bgl.baglanti());
            //SqlDataReader dr2 = komut2.ExecuteReader();
            //while (dr2.Read())
            //{
            //    o2 = Convert.ToInt32(dr2[0]);

            //    if (o2 == 0)
            //    {
            //        xrLabel5.Visible = false;
            //    }
            //    else
            //    {
            //        xrLabel5.Visible = true;
            //    }
            //}
            //bgl.baglanti().Close();

            //SqlCommand komut12 = new SqlCommand("Select Count(ID) from TeklifDetay where TeklifID = N'" + tID + "' and Birim =N'€' and Durum = N'Aktif' ", bgl.baglanti());
            //SqlDataReader dr12 = komut12.ExecuteReader();
            //while (dr12.Read())
            //{
            //    o2 = Convert.ToInt32(dr12[0]);

            //    if (o2 == 0)
            //    {
            //        xrLabel4.Visible = false;
            //    }
            //    else
            //    {
            //        xrLabel4.Visible = true;
            //    }
            //}
            //bgl.baglanti().Close();
        }
    }
}
