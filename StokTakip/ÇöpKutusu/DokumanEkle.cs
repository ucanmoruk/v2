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

namespace StokTakip.Dokuman
{
    public partial class DokumanEkle : Form
    {
        public DokumanEkle()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        void detaybul()
        {
            SqlCommand komutID = new SqlCommand("Select * From DokumanMaster where Kod = '"+ kod +"'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                combo_tur.Text = drI["Tur"].ToString();
                txt_ad.Text = drI["Ad"].ToString();
                txt_kod.Text = drI["Kod"].ToString();
                date_yayin.EditValue = Convert.ToDateTime(drI["YayinTarihi"].ToString());
                txt_rev.Text = drI["RevNo"].ToString(); 
                date_rev.Text = drI["RevTarihi"].ToString();
                combo_durum.Text = drI["Durumu"].ToString(); 
            }
            bgl.baglanti().Close();
        }


        int revsayisi, revsayi2;
        string revk;
        void revkontrol()
        {
         //   revsayisi = Convert.ToInt32(txt_rev.Text);

            SqlCommand komutID = new SqlCommand("Select Max(RevNo) From DokumanRev where Kod = '" + txt_kod.Text + "'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                revk = drI[0].ToString();
                if (revk == null || revk == "")
                    revsayi2 = 0;
                else
                    revsayi2 = Convert.ToInt32(revk);    
            }
            bgl.baglanti().Close();

            if (date_rev.Text == "")
                revdurum = "--.--.--";
            else
                revdurum = date_rev.Text.ToString();


            //if (txt_rev.Text == "" || txt_rev.Text == null)
            //    revno = "0";
            //else
            //    revno = txt_rev.Text;

            if (txt_rev.Text == "" || txt_rev.Text == null)
                revsayisi = 0;
            else
                revsayisi = Convert.ToInt32(txt_rev.Text);

            
            if (revsayisi > revsayi2)
            {
                SqlCommand add = new SqlCommand("insert into DokumanRev(Kod,RevNo,RevTarihi,Aciklama,Durum,Durumu) values (@a1,@a2,@a3,@a4,@a5,@a6)", bgl.baglanti());
                add.Parameters.AddWithValue("@a1", txt_kod.Text);
                add.Parameters.AddWithValue("@a2", revsayisi);
                add.Parameters.AddWithValue("@a3", revdurum);
                add.Parameters.AddWithValue("@a4", txt_aciklama.Text);
                add.Parameters.AddWithValue("@a5", "Aktif");
                add.Parameters.AddWithValue("@a6", combo_durum.Text);
                add.ExecuteNonQuery();
                bgl.baglanti().Close();

                SqlCommand add2 = new SqlCommand("update DokumanMaster set RevNo = @a1, RevTarihi=@a2, Durumu=@a3 where Kod = '" + txt_kod.Text + "'", bgl.baglanti());
                add2.Parameters.AddWithValue("@a1", revsayisi);
                add2.Parameters.AddWithValue("@a2", revdurum);
                add2.Parameters.AddWithValue("@a3", combo_durum.Text);
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();
            }
            else if (revsayisi == revsayi2)
            {
                SqlCommand add = new SqlCommand("insert into DokumanRev(Kod,RevNo,RevTarihi,Aciklama,Durum,Durumu) values (@a1,@a2,@a3,@a4,@a5,@a6)", bgl.baglanti());
                add.Parameters.AddWithValue("@a1", txt_kod.Text);
                add.Parameters.AddWithValue("@a2", revsayisi);
                add.Parameters.AddWithValue("@a3", revdurum);
                add.Parameters.AddWithValue("@a4", txt_aciklama.Text);
                add.Parameters.AddWithValue("@a5", "Aktif");
                add.Parameters.AddWithValue("@a6", combo_durum.Text);
                add.ExecuteNonQuery();
                bgl.baglanti().Close();

                //SqlCommand add2 = new SqlCommand("update DokumanMaster set RevNo = @a1, RevTarihi=@a2, Durumu=@a3 where Kod = '" + txt_kod.Text + "'", bgl.baglanti());
                //add2.Parameters.AddWithValue("@a1", revno);
                //add2.Parameters.AddWithValue("@a2", revdurum);
                //add2.Parameters.AddWithValue("@a3", combo_durum.Text);
                //add.ExecuteNonQuery();
                //bgl.baglanti().Close();
            }
            else
            {
                    SqlCommand add = new SqlCommand("insert into DokumanRev(Kod,RevNo,RevTarihi,Aciklama,Durum) values (@a1,@a2,@a3,@a4,@a5)", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", txt_kod.Text);
                    add.Parameters.AddWithValue("@a2", revsayisi);
                    add.Parameters.AddWithValue("@a3", revdurum);
                    add.Parameters.AddWithValue("@a4", txt_aciklama.Text);
                    add.Parameters.AddWithValue("@a5", "Aktif");
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    //SqlCommand add2 = new SqlCommand("update DokumanMaster set RevNo = @a1, RevTarihi=@a2, Durumu=@a3 where Kod = '"+txt_kod.Text+"'", bgl.baglanti());
                    //add2.Parameters.AddWithValue("@a1", revno);
                    //add2.Parameters.AddWithValue("@a2", revdurum);
                    //add2.Parameters.AddWithValue("@a3", combo_durum.Text);
                    //add.ExecuteNonQuery();
                    //bgl.baglanti().Close();            
            }

        }


        string filekontrol;
        void kontrol()
        {
            SqlCommand detayd = new SqlCommand("Select * from DokumanMaster where Kod = N'" + kod + "'", bgl.baglanti());
            SqlDataReader drde = detayd.ExecuteReader();
            while (drde.Read())
            {
                filekontrol = drde["Path"].ToString();

            }
            bgl.baglanti().Close();
        }

        void dokekle()
        {
            try
            {
                string isim = Path.GetFileName(name);
                if (isim == null)
                {
                    MessageBox.Show("Lütfen geçerli bir doküman seçiniz.");
                }
                else
                {
                    kontrol();
                    if (filekontrol == "")
                    {
                        string path = txt_kod.Text + ".pdf";
                        File.Copy(name, Path.Combine(@Anasayfa.kpath, path), true);
                        SqlCommand add = new SqlCommand("update DokumanMaster set Path = @a1 where Kod = N'" + txt_kod.Text + "'", bgl.baglanti());
                        add.Parameters.AddWithValue("@a1", path);
                        add.ExecuteNonQuery();
                        bgl.baglanti().Close();

                    }
                    else
                    {
                        DialogResult Secim = new DialogResult();
                        Secim = MessageBox.Show("Bu doküman daha önce yüklenmiş. Güncellemek mi istiyorsunuz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (Secim == DialogResult.Yes)
                        {
                            string path = txt_kod.Text + ".pdf";
                            File.Copy(name, Path.Combine(@Anasayfa.kpath, path), true);
                            SqlCommand add = new SqlCommand("update DokumanMaster set Path = @a1 where Kod = N'" + txt_kod.Text + "'", bgl.baglanti());
                            add.Parameters.AddWithValue("@a1", path);
                            add.ExecuteNonQuery();
                            bgl.baglanti().Close();
                        }
                        else
                        {
                            this.Close();
                        }
                    }


                 //   MessageBox.Show("Doküman başarı ile yüklendi!", "Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        DokumanMaster m = (DokumanMaster)System.Windows.Forms.Application.OpenForms["DokumanMaster"];

        string revdurum, revno;
        private void btn_yukle_Click(object sender, EventArgs e)
        {
            try
            {
                if (date_rev.Text == "")
                    revdurum = "--.--.--";
                else
                    revdurum = date_rev.Text.ToString();


                if (txt_rev.Text == "" || txt_rev.Text == null)
                    revno = "0";
                else
                    revno = txt_rev.Text;

                if (btn_yukle.Text == "Yeni Doküman Ekle")
                {
                    SqlCommand add = new SqlCommand("insert into DokumanMaster(Tur,Kod,Ad,YayinTarihi,RevNo,Durumu,Durum,RevTarihi) values (@a1,@a2,@a3,@a4,@a5,@a6,@a8,@a9)", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", combo_tur.Text);
                    add.Parameters.AddWithValue("@a2", txt_kod.Text);
                    add.Parameters.AddWithValue("@a3", txt_ad.Text);
                    add.Parameters.AddWithValue("@a4", date_yayin.EditValue);
                    add.Parameters.AddWithValue("@a5", revno);
                    add.Parameters.AddWithValue("@a6", "Yayında");
                    add.Parameters.AddWithValue("@a8", "Aktif");
                    add.Parameters.AddWithValue("@a9", revdurum);
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    if (btn_sec.Enabled == false)
                    {
                        dokekle();
                    }

                    DialogResult Secim = new DialogResult();
                    Secim = MessageBox.Show("Dokümanınız başarı ile kaydedildi. Yeni bir doküman daha kaydetmek ister misiniz ? ", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (Secim == DialogResult.Yes)
                    {
                        combo_tur.Text = "";
                        txt_ad.Text = "";
                        txt_kod.Text = "";
                        txt_rev.Text = "";
                        date_rev.Text = "";
                        date_yayin.Text = "";
                        btn_sec.Enabled = true;
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else if (btn_yukle.Text == "Revizyon Ekle")
                {
                    revkontrol();

                    if (btn_sec.Enabled == false)
                    {
                        dokekle();
                    }
                    MessageBox.Show("Başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK);
                }
                else
                {
                    dokekle();
                    MessageBox.Show("Doküman yükleme başarılı!", "Başarılı", MessageBoxButtons.OK);
                }

                if (Application.OpenForms["DokumanMaster"] == null)
                { }
                else
                {
                    m.listele();
                }




            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata D1:" + ex);
            }
        }


        public static string gelis, kod;
        private void DokumanEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            gelis = "";
        }

        string name;

        private void txt_rev_KeyPress(object sender, KeyPressEventArgs e)
        {
            // e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)44)
            // text'e sadece sayıların girmesi,geri silme tuşu(ascii kodu:08),virgül(ascii kodu:44) karakterinin girilmesini sağlar.
            //del tuşununda aktif olmasını isterseniz del ascıı kodu:127
            //
            {
                e.Handled = true;
            }

        }

        private void btn_sec_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            open.InitialDirectory = path;
            //Your opendialog box title name.
            open.Title = "Yüklemek istediğiniz dosyayı seçiniz.";
            //which type file format you want to upload in database. just add them.
            open.Filter = "Select Valid Document(*.pdf; *.doc; *.xlsx; *.html)|*.pdf; *.docx; *.xlsx; *.html";
            //FilterIndex property represents the index of the filter currently selected in the file dialog box.
            open.FilterIndex = 1;
            try
            {
                if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (open.CheckFileExists)
                    {
                        name = System.IO.Path.GetFullPath(open.FileName);
                        btn_sec.Enabled = false;
                        lbl_bas.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen dosya seçiniz.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DokumanEkle_Load(object sender, EventArgs e)
        {
            

            if (gelis == "" || gelis == null)
            {
                btn_yukle.Text = "Yeni Doküman Ekle";
                Size = new Size(582, 253);
                combo_durum.Visible = false;

            }
            else if (gelis == "rev")
            {
                detaybul();
                groupControl2.Visible = true;
                btn_yukle.Text = "Revizyon Ekle";
                Size = new Size(582, 285);
                Text = "Revizyon Bilgisi Ekle";
                txt_kod.Enabled = false;
                combo_tur.Enabled = false;
                txt_ad.Enabled = false;
                date_yayin.Enabled = false;
                combo_durum.Visible = true;

            }
            else
            {
                detaybul();
                btn_yukle.Text = "Doküman Yükle";
                Size = new Size(582, 253);
                Text = "Doküman yükle";
                txt_kod.Enabled = false;
                combo_tur.Enabled = false;
                txt_ad.Enabled = false;
                date_yayin.Enabled = false;
                txt_rev.Enabled = false;
                date_rev.Enabled = false;
                combo_durum.Visible = false;
            }
        }
    }
}
