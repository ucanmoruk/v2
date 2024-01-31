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
            memoek.Text = "";
        }
        public static string ID;
        private void detaybul()
        {

            if (Anasayfa.birimID == 1005)
            {
                SqlCommand komut2 = new SqlCommand(@"Select Mix, GenelAd, Noael2, Fizikokimya, Toksikoloji, Kaynak , EkBilgi from rHammadde 
                where cID = N'" + ID + "' ", bgl.baglanti());
                SqlDataReader dr2 = komut2.ExecuteReader();
                while (dr2.Read())
                {
                    combo_tur.Text = dr2["Mix"].ToString();
                    txtad.Text = dr2["GenelAd"].ToString();
                    txtnoel.Text = dr2["Noael2"].ToString();
                    memo_fiziko.Text = dr2["Fizikokimya"].ToString();
                    memo_toksi.Text = dr2["Toksikoloji"].ToString();
                    memoek.Text = dr2["EkBilgi"].ToString();
                    txtkaynak.Text = dr2["Kaynak"].ToString();

                }
                bgl.baglanti().Close();
            }
            else
            {
                SqlCommand komut2 = new SqlCommand(@"Select Mix, GenelAd, Noael2, Fizikokimya, Toksikoloji, Kaynak , EkBilgi from rkHammadde 
                where cID = N'" + ID + "' ", bgl.baglanti());
                SqlDataReader dr2 = komut2.ExecuteReader();
                while (dr2.Read())
                {
                    combo_tur.Text = dr2["Mix"].ToString();
                    txtad.Text = dr2["GenelAd"].ToString();
                    txtnoel.Text = dr2["Noael2"].ToString();
                    memo_fiziko.Text = dr2["Fizikokimya"].ToString();
                    memo_toksi.Text = dr2["Toksikoloji"].ToString();
                    memoek.Text = dr2["EkBilgi"].ToString();
                    txtkaynak.Text = dr2["Kaynak"].ToString();

                }
                bgl.baglanti().Close();
            }

            
            SqlCommand komut12 = new SqlCommand(@"Select INCIName, Cas, EC, Functions, Regulation 
            from rCosing 
            where ID = N'" + ID + "' ", bgl.baglanti());
            SqlDataReader dr12 = komut12.ExecuteReader();
            while (dr12.Read())
            {
                txt_inci.Text = dr12["INCIName"].ToString();
                txtcas.Text = dr12["Cas"].ToString();
                txten.Text = dr12["EC"].ToString();
                memofonk.Text = dr12["Functions"].ToString();
                txtyonetmeli.Text = dr12["Regulation"].ToString();

            }
            bgl.baglanti().Close();
        }

        void ekleme()
        {
            try
            {
                if (Anasayfa.birimID == 1005)
                {
                    SqlCommand add = new SqlCommand(@"insert into rHammadde 
                     (Mix, GenelAd, Noael2, Fizikokimya, Toksikoloji, Kaynak, EkBilgi, Durum, cID) 
                     values (@a1,@a2,@a8,@a9,@a10,@a11,@a12,@a13,@a14)", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", combo_tur.Text);
                    add.Parameters.AddWithValue("@a2", txtad.Text);
                    //add.Parameters.AddWithValue("@a3", txt_inci.Text);
                    //add.Parameters.AddWithValue("@a4", txtcas.Text);
                    //add.Parameters.AddWithValue("@a5", txten.Text);
                    //add.Parameters.AddWithValue("@a6", memofonk.Text);
                    //add.Parameters.AddWithValue("@a7", txtyonetmeli.Text);
                    if (txtnoel.Text == "" || txtnoel.Text == null)
                        add.Parameters.AddWithValue("@a8", DBNull.Value);
                    else
                        add.Parameters.AddWithValue("@a8", txtnoel.Text);
                    add.Parameters.AddWithValue("@a9", memo_fiziko.Text);
                    add.Parameters.AddWithValue("@a10", memo_toksi.Text);
                    add.Parameters.AddWithValue("@a11", txtkaynak.Text);
                    add.Parameters.AddWithValue("@a12", memoek.Text);
                    add.Parameters.AddWithValue("@a13", "Aktif");
                    add.Parameters.AddWithValue("@a14", ID);
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }
                else
                {
                    SqlCommand add = new SqlCommand(@"insert into rkHammadde 
                      (Mix, GenelAd, Noael2, Fizikokimya, Toksikoloji, Kaynak, EkBilgi, Durum, cID) 
                      values (@a1,@a2,@a8,@a9,@a10,@a11,@a12,@a13,@a14)", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", combo_tur.Text);
                    add.Parameters.AddWithValue("@a2", txtad.Text);
                    //add.Parameters.AddWithValue("@a3", txt_inci.Text);
                    //add.Parameters.AddWithValue("@a4", txtcas.Text);
                    //add.Parameters.AddWithValue("@a5", txten.Text);
                    //add.Parameters.AddWithValue("@a6", memofonk.Text);
                    //add.Parameters.AddWithValue("@a7", txtyonetmeli.Text);
                    if (txtnoel.Text == "" || txtnoel.Text == null)
                        add.Parameters.AddWithValue("@a8", DBNull.Value);
                    else
                        add.Parameters.AddWithValue("@a8", txtnoel.Text);
                    add.Parameters.AddWithValue("@a9", memo_fiziko.Text);
                    add.Parameters.AddWithValue("@a10", memo_toksi.Text);
                    add.Parameters.AddWithValue("@a11", txtkaynak.Text);
                    add.Parameters.AddWithValue("@a12", memoek.Text);
                    add.Parameters.AddWithValue("@a13", "Aktif");
                    add.Parameters.AddWithValue("@a14", ID);
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata 1: "+ex);
            }
        }

        void guncelle()
        {
            try
            {
                if (Anasayfa.birimID == 1005)
                {
                    SqlCommand add = new SqlCommand(@"update rHammadde 
                    set Mix=@a1, GenelAd=@a2,
                    Noael2=@a8, Fizikokimya=@a9, Toksikoloji=@a10, Kaynak=@a11 , EkBilgi = @a12
                    where cID = '" + ID + "' ", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", combo_tur.Text);
                    add.Parameters.AddWithValue("@a2", txtad.Text);
                    //add.Parameters.AddWithValue("@a3", txt_inci.Text);
                    //add.Parameters.AddWithValue("@a4", txtcas.Text);
                    //add.Parameters.AddWithValue("@a5", txten.Text);
                    //add.Parameters.AddWithValue("@a6", memofonk.Text);
                    //add.Parameters.AddWithValue("@a7", txtyonetmeli.Text);
                    if (txtnoel.Text == "" || txtnoel.Text == null)
                        add.Parameters.AddWithValue("@a8", DBNull.Value);
                    else
                        add.Parameters.AddWithValue("@a8", txtnoel.Text);
                    add.Parameters.AddWithValue("@a9", memo_fiziko.Text);
                    add.Parameters.AddWithValue("@a10", memo_toksi.Text);
                    add.Parameters.AddWithValue("@a11", txtkaynak.Text);
                    add.Parameters.AddWithValue("@a12", memoek.Text);
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }
                else
                {
                    SqlCommand add = new SqlCommand(@"update rkHammadde 
                    set Mix=@a1, GenelAd=@a2,
                    Noael2=@a8, Fizikokimya=@a9, Toksikoloji=@a10, Kaynak=@a11 , EkBilgi = @a12
                    where cID = '" + ID + "' ", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", combo_tur.Text);
                    add.Parameters.AddWithValue("@a2", txtad.Text);
                    //add.Parameters.AddWithValue("@a3", txt_inci.Text);
                    //add.Parameters.AddWithValue("@a4", txtcas.Text);
                    //add.Parameters.AddWithValue("@a5", txten.Text);
                    //add.Parameters.AddWithValue("@a6", memofonk.Text);
                    //add.Parameters.AddWithValue("@a7", txtyonetmeli.Text);
                    if (txtnoel.Text == "" || txtnoel.Text == null)
                        add.Parameters.AddWithValue("@a8", DBNull.Value);
                    else
                        add.Parameters.AddWithValue("@a8", txtnoel.Text);
                    add.Parameters.AddWithValue("@a9", memo_fiziko.Text);
                    add.Parameters.AddWithValue("@a10", memo_toksi.Text);
                    add.Parameters.AddWithValue("@a11", txtkaynak.Text);
                    add.Parameters.AddWithValue("@a12", memoek.Text);
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata güncelle!: "+ ex);
            }
        }

        public static string gelis;
        private void YeniStok_Load(object sender, EventArgs e)
        {
            detaybul();
            if (gelis == "cosing")
            {

            }
            else
            {
                
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
                MessageBox.Show("Kaydetme işlemi başarılı!", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //DialogResult cikis = new DialogResult();
                //cikis = MessageBox.Show("Kaydetme başarılı. Yeni kayıt ?", "Ooppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                //if (cikis == DialogResult.Yes)
                //{
                //    temizle();
                //    xtraTabControl1.SelectedTabPage = xtraTabPage1;
                //}
                //else
                //{ this.Close(); }
       


            }

          
            if (Application.OpenForms["HammaddeListesi"] == null)
            {

            }
            else
            {
                m.listele();
            }
            this.Close();
        }

        private void YeniHammadde_FormClosed(object sender, FormClosedEventArgs e)
        {
            gelis = null; ID = null; 
        }

        private void Next_Click(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPage = xtraTabPage3;
        }
    }
}
