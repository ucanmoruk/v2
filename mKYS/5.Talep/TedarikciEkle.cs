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
using System.Globalization;
using mROOT._8.Spektrotek;

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
            SqlCommand komut2 = new SqlCommand("Select * from RootTedarikci where ID = '" + fID + "' ", bgl.baglanti());
           // SqlCommand komut2 = new SqlCommand("Select * from StokTedarikci where Ad = '" + firma + "' ", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                
                txt_ad.Text = dr2["Ad"].ToString();
                txt_adres.Text = dr2["Adres"].ToString();
                txt_tel.Text = dr2["Telefon"].ToString();
                txt_email.Text = dr2["Email"].ToString();
                txt_yetkili.Text = dr2["Yetkili"].ToString();
                txt_tur.Text = dr2["Tur"].ToString();
                txt_web.Text = dr2["Web"].ToString();
                c_tur.Text = dr2["Tur2"].ToString();
                txt_vd.Text = dr2["VergiDairesi"].ToString();
                txt_vno.Text = dr2["VergiNo"].ToString();
                memoEdit1.Text = dr2["Notlar"].ToString();
            }
            bgl.baglanti().Close();

            
        }

        public static string firma, fID, kimin;
        private void TedarikciEkle_Load(object sender, EventArgs e)
        {

            if (firma == "" || firma == null)
            {
                
            }
            else
            {
                Text = "Firma Güncelle";
                btn_ok.Text = "Güncelle";
                listele();
            }
        }

        TedarikciListesi m = (TedarikciListesi)System.Windows.Forms.Application.OpenForms["TedarikciListesi"];

        SFirmaListesi f = (SFirmaListesi)System.Windows.Forms.Application.OpenForms["SFirmaListesi"];

        string kontrol;
        void ekleme()
        {
            //SqlCommand komut2 = new SqlCommand("Select count(ID) from RootTedarikci where Ad = '" + txt_ad.Text + "' ", bgl.baglanti());
            //SqlDataReader dr2 = komut2.ExecuteReader();
            //while (dr2.Read())
            //{
            //    kontrol = dr2[0].ToString();
            //}
            //bgl.baglanti().Close();

            //if (kontrol == "0" || kontrol == null)
            //{
                SqlCommand add = new SqlCommand("insert into RootTedarikci(Ad,Adres,Tur,Yetkili,Telefon,Email,Durum, Durumu, Web, Tur2,VergiDairesi,VergiNo,Kimin,Notlar) values (@a1,@a2,@a3,@a4,@a5,@a6,@a8,@a9,@a10,@a11,@a12,@a13,@a14,@a15)", bgl.baglanti());
                add.Parameters.AddWithValue("@a1", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txt_ad.Text));
                add.Parameters.AddWithValue("@a2", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txt_adres.Text));
                add.Parameters.AddWithValue("@a3", txt_tur.Text);
                add.Parameters.AddWithValue("@a4", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txt_yetkili.Text));
                add.Parameters.AddWithValue("@a5", txt_tel.Text);
                add.Parameters.AddWithValue("@a6", txt_email.Text);
                add.Parameters.AddWithValue("@a8", "Aktif");
                add.Parameters.AddWithValue("@a9", "Aktif");
                add.Parameters.AddWithValue("@a10", txt_web.Text);
                add.Parameters.AddWithValue("@a11", c_tur.Text);
                add.Parameters.AddWithValue("@a12", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txt_vd.Text));
                add.Parameters.AddWithValue("@a13", txt_vno.Text);
                if(kimin == null || kimin == "")
                    add.Parameters.AddWithValue("@a14", "Root");
                else if(kimin=="Spektrotek")
                    add.Parameters.AddWithValue("@a14", "Spektrotek");
                else
                    add.Parameters.AddWithValue("@a14", "Ozeco");
                add.Parameters.AddWithValue("@a15", memoEdit1.Text);
                add.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Firma kayıt işlemi başarılı.", "Ooppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                if (Application.OpenForms["TedarikciListesi"] == null)
                {

                }
                else
                {
                    m.listele();
                }
                if (Application.OpenForms["SFirmaListesi"] == null)
                {

                }
                else
                {
                    f.listele();
                }
                temizle();
            //}
            //else
            //{
            //    MessageBox.Show("Bir yerde hata var. Bir yöneticiye danışabilir misiniz ? ", "Ooppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            //}




        }

        void guncelle()
        {
            SqlCommand add = new SqlCommand("update RootTedarikci set Ad=@a1 ,Adres=@a2,Tur=@a3,Yetkili=@a4,Telefon=@a5,Email=@a6, Web=@a7, Tur2=@a8, VergiDairesi=@a12, VergiNo = @a13, Notlar=@a14 where ID=N'" + fID+"'", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txt_ad.Text));
            add.Parameters.AddWithValue("@a2", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txt_adres.Text));
            add.Parameters.AddWithValue("@a3", txt_tur.Text);
            add.Parameters.AddWithValue("@a4", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txt_yetkili.Text));
            add.Parameters.AddWithValue("@a5", txt_tel.Text);
            add.Parameters.AddWithValue("@a6", txt_email.Text);
            add.Parameters.AddWithValue("@a7", txt_web.Text);
            add.Parameters.AddWithValue("@a8", c_tur.Text);
            add.Parameters.AddWithValue("@a12", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txt_vd.Text));
            add.Parameters.AddWithValue("@a13", txt_vno.Text);
            add.Parameters.AddWithValue("@a14", memoEdit1.Text);
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
            if (Application.OpenForms["SFirmaListesi"] == null)
            {

            }
            else
            {
                f.listele();
            }
        }

        void temizle()
        {
            txt_tur.Text = "";
            txt_ad.Text = "";
            txt_adres.Text = "";
            txt_tel.Text = "";
            txt_email.Text = "";
            txt_yetkili.Text = "";
            txt_web.Text = "";
            c_tur.Text = "";
            txt_vno.Text = "";
            txt_vd.Text = "";
            memoEdit1.Text = "";
        }


        private void TedarikciEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            firma = null;
            fID = null;
            kimin = null;
 
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
