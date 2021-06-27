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
    public partial class AnalizYeni : Form
    {
        public AnalizYeni()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        int akod;
        void kontrol()
        {
            if (combo_akre.Text == "" || combo_akre.Text == null)
            {
                MessageBox.Show("Lütfen akreditasyon durumunu belirtiniz!", "Ooppsss!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SqlCommand komutID = new SqlCommand("Select count(ID) From StokAnalizListesi where Kod = N'" + txt_kod.Text + "'", bgl.baglanti());
                SqlDataReader drI = komutID.ExecuteReader();
                while (drI.Read())
                {
                    akod = Convert.ToInt32(drI[0].ToString());
                }
                bgl.baglanti().Close();

                if (akod != 0)
                {
                    MessageBox.Show("Bu kod numaralı analiz daha önce kaydedilmiştir. Lütfen kontrol ediniz!", "Ooppsss!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                }
            }
        }

        void ekleme()
        {
            SqlCommand add = new SqlCommand(" insert into StokAnalizListesi (Kod, Ad, Metot, Matriks, Akreditasyon,Durumu) values (@a1, @a2, @a3, @a4, @a5, @a6) ", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", txt_kod.Text);
            add.Parameters.AddWithValue("@a2", txt_ad.Text);
            add.Parameters.AddWithValue("@a3", txt_metot.Text);
            add.Parameters.AddWithValue("@a4", txt_matriks.Text);
            add.Parameters.AddWithValue("@a5", combo_akre.Text);
            add.Parameters.AddWithValue("@a6", "Aktif");
            add.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Yeni analiz başarıyla eklenmiştir!", "Ooppsss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        void listele()
        {

            SqlCommand komutID = new SqlCommand("Select * From StokAnalizListesi where Kod = N'" + kod + "'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                txt_ad.Text = drI["Ad"].ToString();
                txt_kod.Text = drI["Kod"].ToString();
                txt_matriks.Text = drI["Matriks"].ToString();
                txt_metot.Text = drI["Metot"].ToString();
                combo_akre.Text = drI["Akreditasyon"].ToString();
            }
            bgl.baglanti().Close();
        }

        void guncelle()
        {
            SqlCommand add = new SqlCommand(" update StokAnalizListesi set Kod=@a1, Ad=@a2, Metot=@a3, Matriks=@a4, Akreditasyon=@a5 where Kod = '"+kod+"' ", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", txt_kod.Text);
            add.Parameters.AddWithValue("@a2", txt_ad.Text);
            add.Parameters.AddWithValue("@a3", txt_metot.Text);
            add.Parameters.AddWithValue("@a4", txt_matriks.Text);
            add.Parameters.AddWithValue("@a5", combo_akre.Text);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Analiz bilgileri başarıyla güncellenmiştir!", "Ooppsss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public static string kod;
        private void AnalizYeni_Load(object sender, EventArgs e)
        {
            if (kod == "" || kod == null)
            {

            }
            else
            {
                listele();
                btn_add.Text = "Güncelle";
                Text = "Analiz Bilgi Güncelle";
            }
        }

        AnalizListesi m = (AnalizListesi)System.Windows.Forms.Application.OpenForms["AnalizListesi"];

        private void btn_add_Click(object sender, EventArgs e)
        {

            if (btn_add.Text == "Güncelle")
            {
                guncelle();
            }
            else
            {
                kontrol();
                ekleme();

                txt_ad.Text = "";
                txt_kod.Text = "";
                txt_matriks.Text = "";
                txt_metot.Text = "";
                combo_akre.Text = "";

            }

            if (Application.OpenForms["AnalizListesi"] == null)
            {

            }
            else
            {
                m.listele();
            }
            


        }

        private void AnalizYeni_FormClosing(object sender, FormClosingEventArgs e)
        {
            kod = "";
        }
    }
}
