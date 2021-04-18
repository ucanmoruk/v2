using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakip
{
    public partial class TalepKabul : Form
    {
        public TalepKabul()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        void talepbul()
        {
            SqlCommand komutD = new SqlCommand("select * from StokTalepListe where Aktif = N'Aktif' and Durum = N'İşleme Alındı' ", bgl.baglanti());
            SqlDataReader dr = komutD.ExecuteReader();
            while (dr.Read())
            {
                combo_no.Properties.Items.Add(dr["TalepNo"]);
            }
            bgl.baglanti().Close();
        }

        void temizle()
        {
            combo_detay.Text = "";
            combo_detay.Properties.Items.Clear();
            talepdetay();
            txt_miktar.Text = "";
            txt_birim.Text = "";
            TalepNo = "";
        }

        string stokkod, stokad, stokmiktar, stokbirim;
        void talepdetay()
        {
            SqlCommand komutD = new SqlCommand("select * from StokTalepDetay where TalepNo = N'"+combo_no.Text+"' and Durum <> N'Tamamlandı' ", bgl.baglanti());
            SqlDataReader dr = komutD.ExecuteReader();
            while (dr.Read())
            {
                stokkod = dr["StokKod"].ToString();
              //  combo_detay.Properties.Items.Add(dr["StokKod"]);
                stokmiktar = dr["Miktar"].ToString();
             //   txt_tmiktar.Text = stokmiktar;
                stokbirim = dr["Birim"].ToString();
              //  txt_tbirim.Text = stokbirim;
                txt_birim.Text = stokbirim;
                SqlCommand komut = new SqlCommand("select * from StokListesi where Kod = N'" + stokkod + "' ", bgl.baglanti());
                SqlDataReader dra = komut.ExecuteReader();
                while (dra.Read())
                {
                    stokad = dra["Ad"].ToString();
                    //  txt_ad.Text = stokad;
                    combo_detay.Properties.Items.Add(stokkod + " - " + stokad + " - " + stokmiktar + " - " + stokbirim);
                }
                bgl.baglanti().Close();
            }
            bgl.baglanti().Close();

         

            
    
        }

        string smiktar;
        string miktar, ozellik, skt, sertifika;

        private void combo_no_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_detay.Text = "";
            combo_detay.Properties.Items.Clear();
            talepdetay();
        }

        string detaykod;
        private void combo_detay_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (combo_detay.Text =="" || combo_detay.Text == null)
                {

                }
                else
                {
                    string[] result = combo_detay.Text.Split('-');
                    detaykod = result[0].Trim(' ');
                    smiktar = result[2].Trim(' ');
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata A144:"+ ex);
            }

        }

        private void btn_sertifika_Click(object sender, EventArgs e)
        {
            Sertifika.skod = detaykod;
            Sertifika s = new Sertifika();
            s.ShowDialog();
        }
     

        public static string TalepNo;

        void acilis()
        {
            if (combo_miktar.Text == "Evet")
            {
                miktar = "1";
                kmiktar = smiktar;
            }
            else
            {
                miktar = "0";
                kmiktar = txt_miktar.Text;
            }

            if (combo_marka.Text == "Evet")
            {
                ozellik = "1";
            }
            else
            {
                ozellik = "0";
            }
            if (combo_tarih.Text == "Evet")
            {
                skt = "1";
            }
            else
            {
                skt = "0";
            }
            if (combo_sertifika.Text == "Evet")
            {
                sertifika = "1";
            }
            else
            {
                sertifika = "0";

            }

        }

        private void TalepKabul_Load(object sender, EventArgs e)
        {           
            talepbul();
            btn_sertifika.Visible = false;
            txt_miktar.Visible = false;
            txt_birim.Visible = false;
            if (TalepNo == "")
            {
                combo_no.Text = "";
            }
            else
            {
                combo_no.Text = TalepNo;
                talepdetay();
            }
        }

        string kmiktar;
        private void combo_miktar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_miktar.Text == "Evet")
            {
                miktar = "1";
                kmiktar = smiktar;
                txt_birim.Visible = false;
                txt_miktar.Visible = false;
            }
            else
            {
                miktar = "0";
                kmiktar = txt_miktar.Text;
                txt_birim.Visible = true;
                txt_miktar.Visible = true;
            }
        }

        private void combo_marka_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_marka.Text == "Evet")
            {
                ozellik = "1";
            }
            else
            {
                ozellik = "0";
            }
        }

        private void TalepKabul_FormClosing(object sender, FormClosingEventArgs e)
        {
            TalepNo = "";
        }

        private void combo_tarih_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_tarih.Text == "Evet")
            {
                skt = "1";
            }
            else
            {
                skt = "0";
            }
        }

        private void combo_sertifika_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_sertifika.Text == "Evet")
            {
                sertifika = "1";
                btn_sertifika.Visible = true;
            }
            else
            {
                sertifika = "0";
                btn_sertifika.Visible = false;
            }
        }

        TalepListesi m = (TalepListesi)System.Windows.Forms.Application.OpenForms["TalepListesi"];

        int talepsay;
        void talepkontrol()
        {
            SqlCommand komutD = new SqlCommand("select COUNT(ID) from StokTalepDetay where TalepNo = '"+combo_no.Text+"' and Durum <> N'Tamamlandı' ", bgl.baglanti());
            SqlDataReader dr = komutD.ExecuteReader();
            while (dr.Read())
            {
                talepsay = Convert.ToInt32(dr[0]);
            }
            bgl.baglanti().Close();

        }

        private void btn_kabul_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime tarih = DateTime.Now;
                acilis();
                SqlCommand add = new SqlCommand("insert into StokTalepDegerlendirme " +
                " (TalepNo, TalepStokKod, KabulEdenID, GelisTarihi, Miktar, Marka, Tarih, Sertifika,KabulDurum) values (@a1,@a2,@a3,@a4, @a5, @a6, @a7, @a8, @a9); " +
                " update StokTalepDetay set Durum = @a10 where TalepNo = '"+combo_no.Text+"' and StokKod ='"+detaykod+"'", bgl.baglanti());
                add.Parameters.AddWithValue("@a1", combo_no.Text);
                add.Parameters.AddWithValue("@a2", detaykod);
                add.Parameters.AddWithValue("@a3", Anasayfa.kullanici);
                add.Parameters.AddWithValue("@a4", tarih);
                add.Parameters.AddWithValue("@a5", miktar);
                add.Parameters.AddWithValue("@a6", ozellik);
                add.Parameters.AddWithValue("@a7", skt);
                add.Parameters.AddWithValue("@a8", sertifika);
                add.Parameters.AddWithValue("@a9", combo_genel.Text);
                add.Parameters.AddWithValue("@a10", "Tamamlandı");
                add.ExecuteNonQuery();
                bgl.baglanti().Close();

                talepkontrol();
                if (talepsay == 0)
                {
                    SqlCommand add1 = new SqlCommand(" update StokTalepListe set Durum = @a10 where TalepNo = '" + combo_no.Text + "' ", bgl.baglanti());
                    add1.Parameters.AddWithValue("@a10", "Tamamlandı");
                    add1.ExecuteNonQuery();
                    bgl.baglanti().Close();
                  
                }
                else
                {

                }




                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show("Talebiniz başarıyla kabul edildi. Stok miktarını güncellemek ister misiniz?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (Secim == DialogResult.Yes)
                {
                    StokEkle.talepkod = detaykod;
                    StokEkle.talepmiktar = kmiktar;
                    StokEkle se = new StokEkle();
                    se.ShowDialog();
                }
                else
                {
                    
                }

                temizle();

                if (Application.OpenForms["TalepListesi"] == null)
                {

                }
                else
                {
                    m.listele();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

     

    }
}
