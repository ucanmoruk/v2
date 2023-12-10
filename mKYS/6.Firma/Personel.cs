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
    public partial class Personel : Form
    {
        public Personel()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();

        void temizle()
        {
            txt_ad.Text = "";
            txt_soyad.Text = "";
            txt_gorev.Text = "";
            txt_parola.Text = "";
            txt_telefon.Text = "";
            txt_email.Text = "";
            combo_birim.Text = "";

        }
        int yetki;
        void yetkibul()
        {
            SqlCommand komut21 = new SqlCommand("Select * from KaliteYetki where Gorev = N'" + Anasayfa.gorev + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                yetki = Convert.ToInt32(dr21["Firma"]);
            }
            bgl.baglanti().Close();

            if (yetki == 0 || yetki.ToString() == null)
                btn_ekle.Visible = false;
            else
                btn_ekle.Visible = true;
        }

        public static string update;
        private void Personel_Load(object sender, EventArgs e)
        {
            combobul();
          //  yetkibul();
            if (update == null || update == "")
            {
                temizle();
            }
            else
            {
                personeldetay();
                btn_ekle.Text = "Güncelle";
            }
            update = "";
        }

        void combobul()
        {
          
            SqlCommand komut2 = new SqlCommand("Select Birim from RootFirmaBirim where FirmaID = N'" + Anasayfa.firmaID + "' and Durum = N'Aktif' ", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                combo_birim.Properties.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }
        int birimID;
        void personeldetay()
        {
            SqlCommand komut21 = new SqlCommand("Select * from RootKullanici where ID = N'" + update + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                txt_ad.Text = dr21["Ad"].ToString();
                txt_soyad.Text = dr21["Soyad"].ToString();
                txt_gorev.Text = dr21["Gorev"].ToString();
                txt_telefon.Text = dr21["Telefon"].ToString(); ;
                txt_email.Text = dr21["Email"].ToString(); ;
                txt_parola.Text = dr21["Parola"].ToString();
                birimID = Convert.ToInt32(dr21["BirimID"]);
            }
            bgl.baglanti().Close();

            SqlCommand komut2 = new SqlCommand("Select * from RootFirmaBirim where ID = N'" + birimID + "' ", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                combo_birim.Text = dr2["Birim"].ToString();
            }
            bgl.baglanti().Close();
        }

        PersonelListesi m = (PersonelListesi)System.Windows.Forms.Application.OpenForms["PersonelListesi"];

        string kad;
        private void btn_ekle_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_ekle.Text == "Güncelle")
                {                    
                        kad = txt_ad.Text + "." + txt_soyad.Text;
                        SqlCommand add = new SqlCommand("update RootKullanici set BirimID=@o2,  Ad=@o4, Soyad=@o5, Gorev=@o6, Email=@o7,Telefon=@o8,Parola=@o9,Durum=@o10 where ID = N'" + PersonelListesi.kkod + "' ", bgl.baglanti());
                        add.Parameters.AddWithValue("@o2", yenibirim);
                        add.Parameters.AddWithValue("@o4", txt_ad.Text);
                        add.Parameters.AddWithValue("@o5", txt_soyad.Text);
                        add.Parameters.AddWithValue("@o6", txt_gorev.Text);
                        add.Parameters.AddWithValue("@o7", txt_email.Text);
                        add.Parameters.AddWithValue("@o8", txt_telefon.Text);
                        add.Parameters.AddWithValue("@o9", txt_parola.Text);
                        add.Parameters.AddWithValue("@o10", "Aktif");
                        add.ExecuteNonQuery();
                        bgl.baglanti().Close();
                        MessageBox.Show("Güncelleme işlemi başarılı!", "Oppss!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (Application.OpenForms["PersonelListesi"] == null)
                    {

                    }
                    else
                    {
                        m.listele();
                    }
                }
                else
                {
                    if (combo_birim.Text == "")
                    {
                        MessageBox.Show("Lütfen Birim Seçiniz!", "Oppss!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    else
                    {
                        kad = txt_ad.Text + "." + txt_soyad.Text;
                        SqlCommand add = new SqlCommand("insert into RootKullanici(FirmaID, BirimID, Kadi, Ad, Soyad, Gorev, Email,Telefon,Parola,Durum) values (@o1,@o2, @o3, @o4, @o5, @o6, @o7, @o8, @o9, @o10)", bgl.baglanti());
                        add.Parameters.AddWithValue("@o1", Anasayfa.firmaID);
                        add.Parameters.AddWithValue("@o2", yenibirim);
                        add.Parameters.AddWithValue("@o3", kad);
                        add.Parameters.AddWithValue("@o4", txt_ad.Text);
                        add.Parameters.AddWithValue("@o5", txt_soyad.Text);
                        add.Parameters.AddWithValue("@o6", txt_gorev.Text);
                        add.Parameters.AddWithValue("@o7", txt_email.Text);
                        add.Parameters.AddWithValue("@o8", txt_telefon.Text);
                        add.Parameters.AddWithValue("@o9", txt_parola.Text);
                        add.Parameters.AddWithValue("@o10", "Aktif");
                        add.ExecuteNonQuery();
                        bgl.baglanti().Close();
                        MessageBox.Show("Ekleme işlemi başarılı!", "Oppss!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }

                    if (Application.OpenForms["PersonelListesi"] == null)
                    {
                        
                    }
                    else
                    {
                        m.listele();
                    }
                    temizle();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Prs1: " + ex, "Oppss!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        int yenibirim;
        private void combo_birim_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("Select ID from RootFirmaBirim where Birim = N'" + combo_birim.Text + "' and FirmaID = N'"+Anasayfa.firmaID+"'", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                yenibirim = Convert.ToInt32(dr2["ID"]); 
            }
            bgl.baglanti().Close();
        }
    }
}
