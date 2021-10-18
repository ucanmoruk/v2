using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;

namespace mKYS.Raporlar
{
    public partial class DokumanMaster : DevExpress.XtraReports.UI.XtraReport
    {
        public DokumanMaster()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public static string aciklama;
        public void bilgi()
        {
            pAciklama.Value = aciklama;
            //pRaporNo.Value = raporno;

            //SqlCommand komut = new SqlCommand("select ID, Revno, Tarih from NKR where RaporNo = N'" + pRaporNo.Value + "'", bgl.baglanti());
            //SqlDataReader dr = komut.ExecuteReader();
            //while (dr.Read())
            //{
            //    revno = dr["Revno"].ToString();
            //    ID = Convert.ToInt32(dr["ID"]);
            //    //     tarih = dr["Tarih"].ToString();
            //}
            //bgl.baglanti().Close();

            //pRaporID.Value = ID;
            //pRaprev.Value = raporno + " / " + revno;


        }
    }
}
