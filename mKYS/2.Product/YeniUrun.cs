﻿using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mKYS.Analiz
{
    public partial class YeniUrun : Form
    {
        public YeniUrun()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();


        int akod;
        void kontrol()
        {
            SqlCommand komutID = new SqlCommand("Select count(ID) From RootUrunListesi where Kod = N'" + txt_kod.Text + "'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                akod = Convert.ToInt32(drI[0].ToString());
            }
            bgl.baglanti().Close();

            if (akod != 0)
            {
                MessageBox.Show("Bu kod numaralı ürün daha önce kaydedilmiştir. Lütfen kontrol ediniz!", "Ooppsss!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
            }
        }

        string yenisim, ftpfullpath, yeniyol;
        void ekleme()
        {
            if (btn_logo.Enabled == true)
            {

            }
            else
            {
                string isim = Path.GetFileName(name);
                yenisim = txt_kod.Text + " - " + isim;
                using (var client = new WebClient())
                {
                    string ftpUsername = "massgrup";
                    string ftpPassword = "FfU_Gw48@aseltk5";
                    ftpfullpath = "ftp://" + "www.massgrup.com/httpdocs/mRoot/Logo" + "/" + yenisim;
                    yeniyol = "http://" + "www.massgrup.com/mRoot/Logo" + "/" + yenisim;
                    client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                    client.UploadFile(ftpfullpath, name);
                }
            }
                       
            SqlCommand add = new SqlCommand(@"insert into RootUrunListesi (Kod, Ad, Ozellik, Fotograf, Durum, Marka, Kategori, Fiyat, Barkod, Seri, Hacim, TESF) values (@a1, @a2, @a3, @a4, @a5, @a6, @a7,@a8, @a9, @a10, @a11, @a12) ", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", txt_kod.Text);
            add.Parameters.AddWithValue("@a2", txt_ad.Text);
            add.Parameters.AddWithValue("@a3", txt_ozelik.Text);
            if (String.IsNullOrEmpty(yenisim))
            {
                add.Parameters.AddWithValue("@a4", DBNull.Value);
            }
            else
            {
                add.Parameters.AddWithValue("@a4", yenisim);
            }
            add.Parameters.AddWithValue("@a5", "Aktif");          
            add.Parameters.AddWithValue("@a6", txt_marka.Text);          
            add.Parameters.AddWithValue("@a7", c_kategori.Text);          
            add.Parameters.AddWithValue("@a8", Convert.ToDecimal(txt_fiyat.Text)); 
            add.Parameters.AddWithValue("@a9", t_barkod.Text); 
            add.Parameters.AddWithValue("@a10", t_seri.Text); 
            add.Parameters.AddWithValue("@a11", t_hacim.Text); 
            if(t_tesf.Text=="" || t_tesf.Text == null)
                add.Parameters.AddWithValue("@a12", DBNull.Value);
            else
                add.Parameters.AddWithValue("@a12", Convert.ToDecimal(t_tesf.Text));
            add.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Yeni ürün başarıyla eklenmiştir!", "Ooppsss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        string fotoname;
        void listele()
        {

            SqlCommand komutID = new SqlCommand("Select * From RootUrunListesi where ID = N'" + kod + "'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                txt_ad.Text = drI["Ad"].ToString();
                txt_kod.Text = drI["Kod"].ToString();
                txt_ozelik.Text = drI["Ozellik"].ToString();
                txt_marka.Text = drI["Marka"].ToString();
                c_kategori.Text = drI["Kategori"].ToString();
                fotoname = drI["Fotograf"].ToString();
                txt_fiyat.Text = drI["Fiyat"].ToString();
                t_barkod.Text = drI["Barkod"].ToString();
                t_seri.Text = drI["Seri"].ToString();
                t_hacim.Text = drI["Hacim"].ToString(); 
                t_tesf.Text = drI["TESF"].ToString();

            }
            bgl.baglanti().Close();
            string yol = @"http://www.massgrup.com/mRoot/Logo/" + fotoname;
            pictureEdit1.LoadAsync(yol);

        }

        void guncelle()
        {
            if (btn_logo.Enabled == false)
            {
                string isim = Path.GetFileName(name);
                yenisim = txt_kod.Text + " - " + isim;
                using (var client = new WebClient())
                {
                    string ftpUsername = "massgrup";
                    string ftpPassword = "FfU_Gw48@aseltk5";
                    ftpfullpath = "ftp://" + "www.massgrup.com/httpdocs/mRoot/Logo" + "/" + yenisim;
                    yeniyol = "http://" + "www.massgrup.com/mRoot/Logo" + "/" + yenisim;
                    client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                    client.UploadFile(ftpfullpath, name);
                }
                SqlCommand add = new SqlCommand(@"update RootUrunListesi set Kod=@a1, Ad=@a2, Ozellik=@a3, Fotograf=@a4, Marka=@a5, Kategori = @a6, Fiyat=@a7, Barkod=@a8, Seri=@a9, Hacim=@a10, TESF =@a11 where ID = '" + kod + "' ", bgl.baglanti());
                add.Parameters.AddWithValue("@a1", txt_kod.Text);
                add.Parameters.AddWithValue("@a2", txt_ad.Text);
                add.Parameters.AddWithValue("@a3", txt_ozelik.Text);
                add.Parameters.AddWithValue("@a4", yenisim);
                add.Parameters.AddWithValue("@a5", txt_marka.Text);
                add.Parameters.AddWithValue("@a6", c_kategori.Text);
                add.Parameters.AddWithValue("@a7", Convert.ToDecimal(txt_fiyat.Text));
                add.Parameters.AddWithValue("@a8", t_barkod.Text);
                add.Parameters.AddWithValue("@a9", t_seri.Text);
                add.Parameters.AddWithValue("@a10", t_hacim.Text);
                if (t_tesf.Text == "" || t_tesf.Text == null)
                    add.Parameters.AddWithValue("@a11", DBNull.Value);
                else
                    add.Parameters.AddWithValue("@a11", Convert.ToDecimal(t_tesf.Text));
                add.ExecuteNonQuery();
                bgl.baglanti().Close();

            }
            else
            {
                SqlCommand add = new SqlCommand(" update RootUrunListesi set Kod=@a1, Ad=@a2, Ozellik=@a3, Marka=@a5, Kategori = @a6, Fiyat=@a7, Barkod=@a8, Seri=@a9, Hacim=@a10, TESF =@a11 where ID = '" + kod + "' ", bgl.baglanti());
                add.Parameters.AddWithValue("@a1", txt_kod.Text);
                add.Parameters.AddWithValue("@a2", txt_ad.Text);
                add.Parameters.AddWithValue("@a3", txt_ozelik.Text);
                add.Parameters.AddWithValue("@a5", txt_marka.Text);
                add.Parameters.AddWithValue("@a6", c_kategori.Text);
                add.Parameters.AddWithValue("@a7", Convert.ToDecimal(txt_fiyat.Text));
                add.Parameters.AddWithValue("@a8", t_barkod.Text);
                add.Parameters.AddWithValue("@a9", t_seri.Text);
                add.Parameters.AddWithValue("@a10", t_hacim.Text);
                if (t_tesf.Text == "" || t_tesf.Text == null)
                    add.Parameters.AddWithValue("@a11", DBNull.Value);
                else
                    add.Parameters.AddWithValue("@a11", Convert.ToDecimal(t_tesf.Text));
                add.ExecuteNonQuery();
                bgl.baglanti().Close();
            }
         

            MessageBox.Show("Ürün bilgileri başarıyla güncellenmiştir!", "Ooppsss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                Text = "Ürün Bilgi Güncelle";
            }
        }

        AnalizListesi m = (AnalizListesi)System.Windows.Forms.Application.OpenForms["AnalizListesi"];

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (btn_add.Text == "Güncelle")
            {                
                guncelle();
                btn_logo.Enabled = true;
            }
            else
            {

                if (txt_kod.Text == "")
                {
                    MessageBox.Show("Lütfen ürün kodu bölümünü doldurunuz!", "Oooppss!");
                }
                else
                {
                    kontrol();
                    ekleme();

                    txt_ad.Text = null;
                    txt_kod.Text = null;
                    txt_ozelik.Text = null;
                    t_barkod.Text = null;
                    txt_marka.Text = null;
                    t_hacim.Text = null;
                    t_tesf.Text = null;
                    txt_fiyat.Text = null;
                    t_seri.Text = null;
                    c_kategori.Text = null;
                    btn_logo.Enabled = true;
                    t_tesf.Text = null;
                }
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
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // open.InitialDirectory = "C:\\";
            open.InitialDirectory = path;
            open.Filter = "Pdf Files|*.pdf|Tüm Dosyalar(*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                name = open.FileName;
               // pictureEdit1.Image = new Bitmap(open.FileName);
               // btn_logo.Enabled = false;
            }

            string isim = Path.GetFileName(name);
            yenisim = txt_kod.Text;
            using (var client = new WebClient())
            {
                string ftpUsername = "massgrup";
                string ftpPassword = "FfU_Gw48@aseltk5";
                ftpfullpath = "ftp://" + "www.massgrup.com/httpdocs/mRoot/Logo" + "/" + yenisim;
                yeniyol = "https://" + "www.massgrup.com/mRoot/Logo" + "/" + yenisim;
                client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                client.UploadFile(ftpfullpath, name);
            }

            MessageBox.Show(yeniyol);
            mKYS.Dokuman.DokumanGoruntule.path = yeniyol;
            mKYS.Dokuman.DokumanGoruntule dg = new mKYS.Dokuman.DokumanGoruntule();
            dg.Show();
        }

        private void txt_kod_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void YeniUrun_FormClosed(object sender, FormClosedEventArgs e)
        {
            kod = null;
        }

        string name;
        private void btn_logo_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // open.InitialDirectory = "C:\\";
            open.InitialDirectory = path;
            open.Filter = "Fotoğraf (*.jpg)|*.jpg|Tüm Dosyalar(*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                name = open.FileName;
                pictureEdit1.Image = new Bitmap(open.FileName);
                btn_logo.Enabled = false;
            }
        }
    }
}
