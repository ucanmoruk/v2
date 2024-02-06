using mKYS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mROOT._2.Product
{
    public partial class SatisListesi : Form
    {
        public SatisListesi()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        void listele()
        {
            DataTable dt2 = new DataTable();
            //SqlDataAdapter da2 = new SqlDataAdapter("select l.ID, f.Birim ,l.Kod, l.Ad as 'Analiz Adı', d.Kod + ' ' + d.Ad as 'Metot Kaynağı', l.Matriks, l.Akreditasyon from StokAnalizListesi l " +
            //    "left join StokFirmaBirim f on l.Birim = f.ID left join StokDKDListe d on l.Metot = d.ID where l.Durumu = 'Aktif' order by l.Kod ", bgl.baglanti());
            SqlDataAdapter da2 = new SqlDataAdapter(@"select r.Tarih, l.Kod, l.Kategori, l.Marka, l.Ad, l.Ozellik, r.Hareket, r.Miktar, r.Fiyat from RootUrunHareket r 
            left join RootUrunListesi l on r.UrunID = l.ID
            where r.Durum = 'Aktif'
            order by r.ID desc ", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;
          //  gridView1.Columns["ID"].Visible = false;
        }


        private void SatisListesi_Load(object sender, EventArgs e)
        {
            listele();
        }
    }
}
