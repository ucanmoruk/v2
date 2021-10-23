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

namespace mKYS
{
    public partial class TalepKabul : Form
    {
        public TalepKabul()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        string kmiktar, talepkod;
        void talepbul()
        {
            SqlCommand komutD = new SqlCommand("select d.TalepNo, l.Kod + ' - ' + l.Ad as Stok, l.Kod, d.Miktar from StokTalepDetay d inner join StokListesi l on d.StokKod = l.Kod where d. ID = '" + tID+"' ", bgl.baglanti());
            SqlDataReader dr = komutD.ExecuteReader();
            while (dr.Read())
            {
                txt_no.Text = dr["TalepNo"].ToString();
                txt_detay.Text = dr["Stok"].ToString();
                kmiktar = dr["Miktar"].ToString();
                talepkod = dr["Kod"].ToString();
            }
            bgl.baglanti().Close();
        }

        string kabuledenID, kabulmiktar, kabulmarka, kabulgelis, kabulsertifika, kabulad, kabulsoyad;
        void talepdetay2()
        {
            SqlCommand komut = new SqlCommand("select * from StokTalepDegerlendirme where TalepNo = '" + txt_no.Text + "' and TalepStokKod = N'" + talepkod + "' and Durumu = 'Aktif'", bgl.baglanti());
            SqlDataReader dra = komut.ExecuteReader();
            while (dra.Read())
            {
                kabuledenID = dra["KabulEdenID"].ToString();
                combo_genel.Text = dra["KabulDurum"].ToString();
                datekabul.EditValue = Convert.ToDateTime(dra["GelisTarihi"].ToString());
                kabulgelis = dra["Tarih"].ToString();
                kabulmiktar = dra["Miktar"].ToString();
                kabulmarka = dra["Marka"].ToString();
                kabulsertifika = dra["Sertifika"].ToString();

            }
            bgl.baglanti().Close();


            SqlCommand komut1 = new SqlCommand("select * from StokKullanici where ID = '" + kabuledenID + "' ", bgl.baglanti());
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                kabulad = dr["Ad"].ToString();
                kabulsoyad = dr["Soyad"].ToString();
                txt_9.Text = kabulad + " " + kabulsoyad;
            }
            bgl.baglanti().Close();


            if (kabulgelis == "True")
                combo_tarih.Text = "Evet";
            else
                combo_tarih.Text = "Hayır";

            if (kabulmiktar == "True")
                combo_miktar.Text = "Evet";
            else
                combo_miktar.Text = "Hayır";

            if (kabulmarka == "True")
                combo_marka.Text = "Evet";
            else
                combo_marka.Text = "Hayır";

            if (kabulsertifika == "True")
                combo_sertifika.Text = "Evet";
            else
                combo_sertifika.Text = "Hayır";
        }



       

        string miktar, ozellik, skt, sertifika;

        private void btn_sertifika_Click(object sender, EventArgs e)
        {
            Sertifika.skod = talepkod;
            Sertifika s = new Sertifika();
            s.ShowDialog();
        }



        void acilis()
        {
            if (combo_miktar.Text == "Evet")
            {
                miktar = "1";
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

        public static string gelentalep, tID;
        private void TalepKabul_Load(object sender, EventArgs e)
        {
            talepbul();

            if (gelentalep == "Kabul" )
            {
                btn_sertifika.Visible = false;
                txt_miktar.Visible = false;
                txt_birim.Visible = false;
                Text = "Siparişi Tamamlanan Talebi Kabul Etme";
            }
            else
            {
                Text = "Talep Kabul Detayları";
                btn_kabul.Visible = false;
                lbl_9.Visible = true;
                txt_9.Visible = true;
                labelControl9.Visible = true;
                datekabul.Visible = true;
                talepdetay2();
            }
        }

        private void combo_miktar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_miktar.Text == "Evet")
            {
                miktar = "1";
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
            //TalepNo = "";
            gelentalep = null;
            tID = null;
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
         //   SqlCommand komutD = new SqlCommand("select COUNT(ID) from StokTalepDetay where ID = '"+tID+"' and  Durum <> N'Tamamlandı' ", bgl.baglanti());
            SqlCommand komutD = new SqlCommand("select COUNT(ID) from StokTalepDetay where TalepNo = '" + txt_no.Text + "' and Durumu = 'Aktif' and Durum <> N'Tamamlandı' ", bgl.baglanti());
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
                SqlCommand add = new SqlCommand(" update StokTalepDegerlendirme " +
              " set KabulEdenID=@a3, GelisTarihi=@a4, Miktar=@a5, Marka=@a6, Tarih=@a7, Sertifika=@a8,KabulDurum=@a9 where TalepNo = '" + txt_no.Text + "' and TalepStokKod ='" + talepkod + "'; " +
              " update StokTalepDetay set Durum = @a10 where ID = '"+tID+"'", bgl.baglanti());
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
                    SqlCommand add1 = new SqlCommand(" update StokTalepListe set Durum = @a10 where TalepNo = '" + txt_no.Text + "' ", bgl.baglanti());
                    add1.Parameters.AddWithValue("@a10", "Tamamlandı");
                    add1.ExecuteNonQuery();
                    bgl.baglanti().Close();

                }
                else
                { }

                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show("Talebiniz başarıyla kabul edildi. Stok miktarını güncellemek ister misiniz?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (Secim == DialogResult.Yes)
                {
                    StokEkle.talepkod = talepkod;
                    StokEkle.talepmiktar = kmiktar;
                    StokEkle se = new StokEkle();
                    se.ShowDialog();
                }
                else
                {

                }

 

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
