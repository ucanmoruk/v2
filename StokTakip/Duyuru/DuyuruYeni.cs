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

namespace StokTakip.Duyuru
{
    public partial class DuyuruYeni : Form
    {
        public DuyuruYeni()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from DokumanMaster where Durum = N'Aktif'", bgl.baglanti());
            da.Fill(dt);
            combo_personel.Properties.Items.Add(dt);
            //   gridControl1.DataSource = dt;
        }


        string ad, soyad;
        private void personelbul()
        {
            //SqlCommand komutID = new SqlCommand("select Ad, Soyad From StokKullanici where Durum=N'Aktif' ", bgl.baglanti());
            //SqlDataReader drI = komutID.ExecuteReader();
            //while (drI.Read())
            //{
            //    ad = drI["Ad"].ToString();
            //    soyad = drI["Soyad"].ToString();
            ////    combo_personel.Properties.Items.Add(ad+" "+soyad);
            //}
            //bgl.baglanti().Close();
        }

        void ekleme()
        {
            //SqlCommand add = new SqlCommand(" insert into StokAnalizListesi (Kod, Ad, Metot, Matriks, Akreditasyon,Durumu) values (@a1, @a2, @a3, @a4, @a5, @a6) ", bgl.baglanti());
            //add.Parameters.AddWithValue("@a1", txt_kod.Text);
            //add.Parameters.AddWithValue("@a2", txt_ad.Text);
            //add.Parameters.AddWithValue("@a3", txt_metot.Text);
            //add.Parameters.AddWithValue("@a4", txt_matriks.Text);
            //add.Parameters.AddWithValue("@a5", combo_akre.Text);
            //add.Parameters.AddWithValue("@a6", "Aktif");
            //add.ExecuteNonQuery();
            //bgl.baglanti().Close();

            //MessageBox.Show("Yeni analiz başarıyla eklenmiştir!", "Ooppsss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        private void Combo_alici_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Combo_alici.Text == "Herkese ulaşsın")
            {
                combo_personel.Enabled = false;
            }
            else
            {
                combo_personel.Enabled = true;
            }
        }

     //   DuyuruListe m = (DuyuruListe)System.Windows.Forms.Application.OpenForms["DuyuruListe"];

        private void btn_yayin_Click(object sender, EventArgs e)
        {


            //if (Application.OpenForms["DuyuruListe"] == null)
            //{ }
            //else
            //{
            //    m.listele();
            //}
        }

        private void DuyuruYeni_Load(object sender, EventArgs e)
        {
            personelbul();

         //   listele();
        }
    }
}
