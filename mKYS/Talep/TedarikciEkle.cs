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
using mKYS.Talep;

namespace mKYS.Talep
{
    public partial class TedarikciEkle : Form
    {
        public TedarikciEkle()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        void listele()
        {
            SqlCommand komut2 = new SqlCommand("Select * from StokTedarikci where Ad = '" + firma + "' ", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                
                txt_ad.Text = dr2["Ad"].ToString();
                txt_adres.Text = dr2["Adres"].ToString();
                txt_tel.Text = dr2["Telefon"].ToString();
                txt_fax.Text = dr2["Faks"].ToString();
                txt_email.Text = dr2["Email"].ToString();
                txt_yetkili.Text = dr2["Yetkili"].ToString();
                txt_tur.Text = dr2["Tur"].ToString();              

            }
            bgl.baglanti().Close();

            
        }


        public static string firma;
        private void TedarikciEkle_Load(object sender, EventArgs e)
        {

            if (firma == "" || firma == null)
            {
                
            }
            else
            {
                btn_ok.Text = "Güncelle";
                listele();
            }
        }

        TedarikciListesi m = (TedarikciListesi)System.Windows.Forms.Application.OpenForms["TedarikciListesi"];

        string kontrol;
        void ekleme()
        {
            SqlCommand komut2 = new SqlCommand("Select count(ID) from StokTedarikci where Ad = '" + txt_ad.Text + "' ", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                kontrol = dr2[0].ToString();
            }
            bgl.baglanti().Close();

            if (kontrol == "0" || kontrol == null)
            {
                SqlCommand add = new SqlCommand("insert into StokTedarikci(Ad,Adres,Tur,Yetkili,Telefon,Email,Faks,Durum, Durumu) values (@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9)", bgl.baglanti());
                add.Parameters.AddWithValue("@a1", txt_ad.Text);
                add.Parameters.AddWithValue("@a2", txt_adres.Text);
                add.Parameters.AddWithValue("@a3", txt_tur.Text);
                add.Parameters.AddWithValue("@a4", txt_yetkili.Text);
                add.Parameters.AddWithValue("@a5", txt_tel.Text);
                add.Parameters.AddWithValue("@a6", txt_email.Text);
                add.Parameters.AddWithValue("@a7", txt_fax.Text);
                add.Parameters.AddWithValue("@a8", "Aktif");
                add.Parameters.AddWithValue("@a9", "Aktif");
                add.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Tedarikçi firma ekleme işlemi başarılı.", "Ooppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                if (Application.OpenForms["TedarikciListesi"] == null)
                {

                }
                else
                {
                    m.listele();
                }
                temizle();
            }
            else
            {
                MessageBox.Show("Bu firma daha önce kaydedilmiş olabilir. Bir kontrol edebilir misiniz ? ", "Ooppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }




        }

        void guncelle()
        {
            SqlCommand add = new SqlCommand("update StokTedarikci set Ad=@a1 ,Adres=@a2,Tur=@a3,Yetkili=@a4,Telefon=@a5,Email=@a6,Faks=@a7 where Ad=N'"+firma+"'", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", txt_ad.Text);
            add.Parameters.AddWithValue("@a2", txt_adres.Text);
            add.Parameters.AddWithValue("@a3", txt_tur.Text);
            add.Parameters.AddWithValue("@a4", txt_yetkili.Text);
            add.Parameters.AddWithValue("@a5", txt_tel.Text);
            add.Parameters.AddWithValue("@a6", txt_email.Text);
            add.Parameters.AddWithValue("@a7", txt_fax.Text);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Güncelleme işlemi başarılı.", "Ooppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            if (Application.OpenForms["TedarikciListesi"] == null)
            {

            }
            else
            {
                m.listele();
            }

        }

        void temizle()
        {
            txt_tur.Text = "";
            txt_ad.Text = "";
            txt_adres.Text = "";
            txt_tel.Text = "";
            txt_fax.Text = "";
            txt_email.Text = "";
            txt_yetkili.Text = "";
        }


        private void TedarikciEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            firma = "";
        }

        
        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (btn_ok.Text == "Güncelle")
            {
                guncelle();
            }
            else
            {
                ekleme();
            }
        }
             
    }
}
