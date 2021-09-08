using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;

namespace StokTakip.Raporlar
{
    public partial class KimyasalEtiket : DevExpress.XtraReports.UI.XtraReport
    {
        public KimyasalEtiket()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public static string sTur, sGelis, sID;
        public void bilgi()
        {
           

            if (sGelis == "Özel")
            {
                pID.Value = sID;
                //SqlCommand komut = new SqlCommand("select ID, Revno, Tarih from NKR where RaporNo = N'" + pRaporNo.Value + "'", bgl.baglanti());
                //SqlDataReader dr = komut.ExecuteReader();
                //while (dr.Read())
                //{
                //    revno = dr["Revno"].ToString();

                //}
                //bgl.baglanti().Close();

                //pRaporID.Value = ID;
                //pRaprev.Value = raporno + " / " + revno;
            }
            else
            {
                pTur.Value = sTur;
            }
           


        }

    }
}
