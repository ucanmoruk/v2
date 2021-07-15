using StokTakip.Dokuman;
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

namespace StokTakip.Analiz
{
    public partial class AnalizListesi : Form
    {
        public AnalizListesi()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select f.Birim ,l.Kod, l.Ad as 'Analiz Adı', l.Metot, l.Matriks, l.Akreditasyon from StokAnalizListesi l " +
                "inner join StokFirmaBirim f on l.Birim = f.ID where l.Durumu = 'Aktif'", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;

        }

        int yetki;
        void yetkibul()
        {
            SqlCommand komut21 = new SqlCommand("Select * from KaliteYetki where Gorev = N'" + Anasayfa.gorev + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                yetki = Convert.ToInt32(dr21["Analiz"]);
            }
            bgl.baglanti().Close();

            if (yetki == 0 || yetki.ToString() == null)
            {
                barButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
            {
                barButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }

        }


        private void AnalizListesi_Load(object sender, EventArgs e)
        {
            listele();
            yetkibul();


            this.gridView1.Columns[1].Width = 40;
            this.gridView1.Columns[2].Width = 150;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listele();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show( skod + " kodlu analizi silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (Secim == DialogResult.Yes)
                {
                   SqlCommand komutSil = new SqlCommand("update StokAnalizListesi set Durumu=@a1 where Kod = N'" + skod + "'", bgl.baglanti());
                    komutSil.Parameters.AddWithValue("@a1", "Pasif");
                    komutSil.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Silme işlemi gerçekleşmiştir.");
                    listele();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata 11003 : " + ex.Message);
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Analiz.AnalizYeni.kod = skod;
            Analiz.AnalizYeni any = new AnalizYeni();
            any.Show();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SqlCommand komut21 = new SqlCommand("Select * from DokumanMaster where Kod = N'" + skod + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                DokumanGoruntule.yol = dr21["Path"].ToString();
                DokumanGoruntule.ad = dr21["Ad"].ToString();
            }
            bgl.baglanti().Close();

            DokumanGoruntule dg = new DokumanGoruntule();
            dg.Show();
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }

        }

        string skod, sad;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            skod = dr["Kod"].ToString();
            sad = dr["Analiz Adı"].ToString();
        }

        private void AnalizListesi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                listele();
            }
        }

        void reizin()
        {
            if (yetki == 0 || yetki.ToString() == null)
            {
                MessageBox.Show("Bu analiz için henüz reçete oluşturulmamıştır!","Oooppss!!",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                DialogResult Secim = new DialogResult();
                string newLine = Environment.NewLine;
                Secim = MessageBox.Show("Bu analiz için henüz reçete oluşturulmamıştır!" + newLine + "Yeni reçete oluşturmak ister misiniz ? ", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (Secim == DialogResult.Yes)
                {
                    YeniRecete.UrunID = skod;
                    YeniRecete.Ad = sad;

                    var mfrm = (Anasayfa)Application.OpenForms["Anasayfa"];
                    if (mfrm != null)
                        mfrm.YeniRecete();
                }
            }

              
        }


        int redurum;
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SqlCommand komut21 = new SqlCommand("Select Count(ID) from StokRecete where AnalizKod = N'" + skod + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                redurum = Convert.ToInt32(dr21[0]);
            }
            bgl.baglanti().Close();

            if (redurum == 0)
            {
                reizin();               
            }
            else
            {

                Stok.ReceteDetay.skod = skod;
                Stok.ReceteDetay.sad = sad;
                Stok.ReceteDetay rd = new Stok.ReceteDetay();
                rd.Show();
            }



        }
    }
}
