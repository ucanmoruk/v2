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

namespace mKYS
{
    public partial class YeniHammadde : Form
    {
        public YeniHammadde()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        private void temizle()
        {
            hID = null;
            txtad.Text = "";
            txt_inci.Text = "";
            txtcas.Text = "";
            txten.Text = "";
            memofonk.Text = "";
            txtyonetmeli.Text = "";
            txtnoel.Text = "";
            txtkaynak.Text = "";
            memo_fiziko.Text = "";
            memo_toksi.Text = "";

        }

        private void detaybul()
        {
            SqlCommand komut2 = new SqlCommand(@"Select Mix, GenelAd, InciAd, CasNo, EcNo, Fonksiyon, 
            Yonetmelik, Noael, Fizikokimya, Toksikoloji, Kaynak from rHammadde 
            where ID = N'" + hID + "' ", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                combo_tur.Text = dr2["Mix"].ToString();
                txtad.Text = dr2["GenelAd"].ToString();
                txt_inci.Text = dr2["InciAd"].ToString();
                txtcas.Text = dr2["CasNo"].ToString();
                txten.Text = dr2["EcNo"].ToString();
                memofonk.Text = dr2["Fonksiyon"].ToString();
                txtyonetmeli.Text = dr2["Yonetmelik"].ToString();
                txtnoel.Text = dr2["Noael"].ToString();
                memo_fiziko.Text = dr2["Fizikokimya"].ToString();
                memo_toksi.Text = dr2["Toksikoloji"].ToString();
                txtkaynak.Text = dr2["Kaynak"].ToString();

            }
            bgl.baglanti().Close();

        }

        void ekleme()
        {
            try
            {
                SqlCommand add = new SqlCommand(@"insert into rHammadde 
                (Mix, GenelAd, InciAd, CasNo, EcNo, Fonksiyon, Yonetmelik, Noael, Fizikokimya, Toksikoloji, Kaynak, Durum) 
                values (@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9,@a10,@a11,@a12)", bgl.baglanti());
                add.Parameters.AddWithValue("@a1", combo_tur.Text);
                add.Parameters.AddWithValue("@a2", txtad.Text);
                add.Parameters.AddWithValue("@a3", txt_inci.Text);
                add.Parameters.AddWithValue("@a4", txtcas.Text);
                add.Parameters.AddWithValue("@a5", txten.Text);
                add.Parameters.AddWithValue("@a6", memofonk.Text);
                add.Parameters.AddWithValue("@a7", txtyonetmeli.Text);
                add.Parameters.AddWithValue("@a8", txtnoel.Text);
                add.Parameters.AddWithValue("@a9", memo_fiziko.Text);
                add.Parameters.AddWithValue("@a10", memo_toksi.Text);
                add.Parameters.AddWithValue("@a11", txtkaynak.Text);
                add.Parameters.AddWithValue("@a12", "Aktif");
                add.ExecuteNonQuery();
                bgl.baglanti().Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata 1: "+ex);
            }
        }

        void guncelle()
        {
            SqlCommand add = new SqlCommand(@"update rHammadde 
            set Mix=@a1, GenelAd=@a2, InciAd=@a3, CasNo=@a4, EcNo=@a5, Fonksiyon=@a6, 
            Yonetmelik=@a7, Noael=@a8, Fizikokimya=@a9, Toksikoloji=@a10, Kaynak=@a11 
            where ID = '"+hID+"' ", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", combo_tur.Text);
            add.Parameters.AddWithValue("@a2", txtad.Text);
            add.Parameters.AddWithValue("@a3", txt_inci.Text);
            add.Parameters.AddWithValue("@a4", txtcas.Text);
            add.Parameters.AddWithValue("@a5", txten.Text);
            add.Parameters.AddWithValue("@a6", memofonk.Text);
            add.Parameters.AddWithValue("@a7", txtyonetmeli.Text);
            add.Parameters.AddWithValue("@a8", txtnoel.Text);
            add.Parameters.AddWithValue("@a9", memo_fiziko.Text);
            add.Parameters.AddWithValue("@a10", memo_toksi.Text);
            add.Parameters.AddWithValue("@a11", txtkaynak.Text);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        public static string hID;
        private void YeniStok_Load(object sender, EventArgs e)
        {
            if (hID == "" ||hID == null)
            {

            }
            else
            {
                detaybul();
                btnadd.Text = "Güncelle";
            }
        }

        HammaddeListesi m = (HammaddeListesi)System.Windows.Forms.Application.OpenForms["HammaddeListesi"];

        private void btnadd_Click(object sender, EventArgs e)
        {

            if (btnadd.Text == "Güncelle")
            {
                guncelle();
                MessageBox.Show("Güncelleme işlemi başarılı!", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                ekleme();

                DialogResult cikis = new DialogResult();
                cikis = MessageBox.Show("Kaydetme başarılı. Yeni kayıt ?", "Ooppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (cikis == DialogResult.Yes)
                {
                    temizle();
                    xtraTabControl1.SelectedTabPage = xtraTabPage1;
                }
                else
                { this.Close(); }


                
            }

          
            if (Application.OpenForms["HammaddeListesi"] == null)
            {

            }
            else
            {
                m.listele();
            }

        }

        private void YeniHammadde_FormClosed(object sender, FormClosedEventArgs e)
        {
            hID = null;
        }

        private void Next_Click(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
        }
    }
}
