using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mKYS;
using DevExpress.DataAccess.Excel;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors;
using System.IO;
using System.Net;

namespace mROOT._9.UGDR
{
    public partial class OzuYeni : Form
    {
        public OzuYeni()
        {
            InitializeComponent();
        }

        public static string detay;

        sqlbaglanti bgl = new sqlbaglanti();
        uListe n = (uListe)System.Windows.Forms.Application.OpenForms["uListe"];
        private void simpleButton2_Click(object sender, EventArgs e)
        {
          

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
        }

        private void uYeni_Load(object sender, EventArgs e)
        {
            hosgeldin();
            listele();


            if (Giris.birimID != "1005")
            {
                mmikrotr.Text = "Son ürün için yapılan mikrobiyolojik analiz sonuçları ürün güvenlik dosyasında sunulmuştur. Sonuçlar mikrobiyolojik kalite kontrol limitlerine uygundur. Mikrobiyolojik kontaminasyon riski taşımamaktadır.";
                mchaltr.Text = "Son ürün için yapılan koruyucu etkinlik test sonuçları ürün güvenlik dosyasında sunulmuştur. Sonuçlar uygun olarak değerlendirilmiştir.";
                mstatr.Text = "Ürünün üretici tarafından öngörülen raf ömrü 24 aydır. Ürünün açıldıktan sonraki dayanıklılık süresi etikette 12 ay olarak belirtilmiştir.";
            }
        }

        void listele()
        {

            if (Giris.birimID == "1005")
            {
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter("select ID, Ad from RootTedarikci where Durum = 'Aktif' and Kimin = 'Ozeco' order by Ad", bgl.baglanti());
                da2.Fill(dt2);
                gridLookUpEdit1.Properties.DataSource = dt2;
                gridLookUpEdit1.Properties.DisplayMember = "Ad";
                gridLookUpEdit1.Properties.ValueMember = "ID";
            }
            else
            {
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter("select ID, Ad from RootTedarikci where Durum = 'Aktif' order by Ad", bgl.baglanti());
                da2.Fill(dt2);
                gridLookUpEdit1.Properties.DataSource = dt2;
                gridLookUpEdit1.Properties.DisplayMember = "Ad";
                gridLookUpEdit1.Properties.ValueMember = "ID";
            }
            DataTable dt12 = new DataTable();
            SqlDataAdapter da12 = new SqlDataAdapter("select ID, Kategori, UrunTipi from rUGDTip order by Kategori", bgl.baglanti());
            da12.Fill(dt12);
            gridLookUpEdit2.Properties.DataSource = dt12;
            gridLookUpEdit2.Properties.DisplayMember = "UrunTipi";
            gridLookUpEdit2.Properties.ValueMember = "ID";

        }

        void hosgeldin()
        {
            dateEdit1.EditValue = DateTime.Now;

            SqlCommand komut = new SqlCommand("select MAX(RaporNo) from rUGDListe where BirimID = '" + Giris.birimID + "' and Durum = N'Aktif'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                int rno = Convert.ToInt32(dr[0].ToString()) + 1;
                traporno.Text = Convert.ToString(rno);
            }
            bgl.baglanti().Close();

            SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
            "insert into rUGDListe (RaporNo, BirimID, Durum, RaporDurum) " +
            "values (@o2,@o3,@o4, @o5) SET @ID = SCOPE_IDENTITY() ;" +
            "COMMIT TRANSACTION", bgl.baglanti());
            add2.Parameters.AddWithValue("@o2", traporno.Text);
            add2.Parameters.AddWithValue("@o3", Giris.birimID);
            add2.Parameters.AddWithValue("@o4", "Pasif");
            add2.Parameters.AddWithValue("@o5", "Yeni");
            add2.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
            add2.ExecuteNonQuery();
            yeniID = add2.Parameters["@ID"].Value.ToString();
            bgl.baglanti().Close();

            


        }

        private void Next_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand add2 = new SqlCommand(@"BEGIN TRANSACTION
                 update rUGDListe set Versiyon=@a1, Tarih=@a2, FirmaID=@a3, Urun=@a4, Barkod=@a5, Miktar=@a6, 
                 Tip1=@a7, Tip2=@a8, Uygulama=@a9, Hedef=@a10, A=@a11, UrunEn=@a12 where ID = '" + yeniID + "' COMMIT TRANSACTION", bgl.baglanti());
                add2.Parameters.AddWithValue("@a1", tverno.Text);
                add2.Parameters.AddWithValue("@a2", dateEdit1.EditValue);
                add2.Parameters.AddWithValue("@a3", gridLookUpEdit1.EditValue);
                add2.Parameters.AddWithValue("@a4", turun.Text);
                add2.Parameters.AddWithValue("@a5", tbarkod.Text);
                add2.Parameters.AddWithValue("@a6", tmiktar.Text);
                add2.Parameters.AddWithValue("@a7", ctip.Text);
                add2.Parameters.AddWithValue("@a8", (object)gridLookUpEdit2.EditValue ?? DBNull.Value);
                add2.Parameters.AddWithValue("@a9", tUygulama.Text);
                add2.Parameters.AddWithValue("@a10", thedef.Text);
                if (tAdegeri.Text == "" || tAdegeri.Text == null)
                    add2.Parameters.AddWithValue("@a11", DBNull.Value);
                else
                    add2.Parameters.AddWithValue("@a11", Convert.ToDecimal(tAdegeri.Text));
                add2.Parameters.AddWithValue("@a12", turunen.Text);
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();
                xtraTabControl1.SelectedTabPage = xtraTabPage2;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata1: " + ex);
            }

        }

        private void next2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand add2 = new SqlCommand(@"BEGIN TRANSACTION
                insert into rUGDDetay (UrunID, Gorunum, Renk, Koku, pH, Kaynama, Erime, Yogunluk, Viskozite, Suda, Diger, Durum, KokuEn, GorunumEn, RenkEn, SudaEn, DigerEn )
                values (@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9,@a10,@a11,@a12,@a13,@a14,@a15,@a16,@a17) COMMIT TRANSACTION", bgl.baglanti());
                add2.Parameters.AddWithValue("@a1", yeniID);
                add2.Parameters.AddWithValue("@a2", tgorunum.Text);
                add2.Parameters.AddWithValue("@a3", trenk.Text);
                add2.Parameters.AddWithValue("@a4", tkoku.Text);
                add2.Parameters.AddWithValue("@a5", tph.Text);
                add2.Parameters.AddWithValue("@a6", tkaynama.Text);
                add2.Parameters.AddWithValue("@a7", terime.Text);
                add2.Parameters.AddWithValue("@a8", tyogunluk.Text);
                add2.Parameters.AddWithValue("@a9", tviskozite.Text);
                add2.Parameters.AddWithValue("@a10", tsuda.Text);
                add2.Parameters.AddWithValue("@a11", tdiger.Text);
                add2.Parameters.AddWithValue("@a12", "Pasif");
                add2.Parameters.AddWithValue("@a13", tkokuen.Text);
                add2.Parameters.AddWithValue("@a14", tgorunumen.Text);
                add2.Parameters.AddWithValue("@a15", trenken.Text);
                add2.Parameters.AddWithValue("@a16", tsudaen.Text);
                add2.Parameters.AddWithValue("@a17", tdigeren.Text);
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();
                xtraTabControl1.SelectedTabPage = xtraTabPage3;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata2: " + ex);
            }
        }

        byte mikro, challenge, stabilite;
        private void simpleButton7_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkEdit1.Checked == true)
                    mikro = 1;
                else
                    mikro = 0;
                if (checkEdit2.Checked == true)
                    challenge = 1;
                else
                    challenge = 0;
                if (checkEdit3.Checked == true)
                    stabilite = 1;
                else
                    stabilite = 0;

                SqlCommand add2 = new SqlCommand(@"BEGIN TRANSACTION
            insert into rUGDDetay2 (UrunID, Mikro, Challenge, Stabilite, MResim, CResim, SResim, StabiliteNot, Durum, MikroNot, MikroNotEn, ChallengeNot, ChallengeNotEn, StabiliteNotEn)
            values (@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9,@o1,@o2,@o3,@o4,@o5) COMMIT TRANSACTION", bgl.baglanti());
                add2.Parameters.AddWithValue("@a1", yeniID);
                add2.Parameters.AddWithValue("@a2", mikro);
                add2.Parameters.AddWithValue("@a3", challenge);
                add2.Parameters.AddWithValue("@a4", stabilite);
                add2.Parameters.AddWithValue("@a5", string.IsNullOrEmpty(rmik) ? (object)DBNull.Value : rmik);
                add2.Parameters.AddWithValue("@a6", string.IsNullOrEmpty(rchal) ? (object)DBNull.Value : rchal);
                add2.Parameters.AddWithValue("@a7", string.IsNullOrEmpty(rsta) ? (object)DBNull.Value : rsta);
                add2.Parameters.AddWithValue("@a8", mstatr.Text);
                add2.Parameters.AddWithValue("@a9", "Pasif");
                add2.Parameters.AddWithValue("@o1", mmikrotr.Text);
                add2.Parameters.AddWithValue("@o2", mmikroen.Text);
                add2.Parameters.AddWithValue("@o3", mchaltr.Text);
                add2.Parameters.AddWithValue("@o4", mchalen.Text);
                add2.Parameters.AddWithValue("@o5", mstaen.Text);
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();
                xtraTabControl1.SelectedTabPage = xtraTabPage4;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata3: " + ex);
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            kaydet();
        }

        string kayit;
        void kaydet()
        {
            //rUGDListe durum aktif güncelle

            SqlCommand add2 = new SqlCommand(@"BEGIN TRANSACTION
            update rUGDDetay2 set Kullanim=@a1, Ozellikler=@a2, Uyarilar=@a3, Kutu=@a4, Durum=@a5, 
            UyarilarEn=@o6, KullanimEn=@o7, OzelliklerEn=@o8, Kutu2=@o10 where UrunID = '" + yeniID + "' ;" +
            "update rUGDListe set Durum=@a6 where ID = '"+yeniID+"' ;" +
            "update rUGDDetay set Durum=@a7 where UrunID = '" + yeniID + "' COMMIT TRANSACTION", bgl.baglanti());
            add2.Parameters.AddWithValue("@a1", memoEdit2.Text);
            add2.Parameters.AddWithValue("@a2", memoEdit3.Text);
            add2.Parameters.AddWithValue("@a3", memoEdit4.Text);
            add2.Parameters.AddWithValue("@a4", string.IsNullOrEmpty(rkut) ? (object)DBNull.Value : rkut);
            add2.Parameters.AddWithValue("@a5", "Aktif");
            add2.Parameters.AddWithValue("@a6", "Aktif");
            add2.Parameters.AddWithValue("@a7", "Aktif");
            add2.Parameters.AddWithValue("@o6", memoEdit7.Text);
            add2.Parameters.AddWithValue("@o7", memoEdit9.Text);
            add2.Parameters.AddWithValue("@o8", memoEdit8.Text);
            add2.Parameters.AddWithValue("@o10", string.IsNullOrEmpty(ruyar) ? (object)DBNull.Value : ruyar);
            add2.ExecuteNonQuery();
            bgl.baglanti().Close();
            kayit = "evet";
            if (Application.OpenForms["uListe"] == null)
            {

            }
            else
            {
                n.listele();
            }

            DialogResult Secim = new DialogResult();
            Secim = MessageBox.Show("Kayıt başarılı! Formül eklemek ister misin ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Secim == DialogResult.Yes)
            {
                uFormul.rNo = traporno.Text;
                uFormul.uID = yeniID;
                uFormul nf = new uFormul();
                nf.Show();

            }
            else
            {
                DialogResult Secimx = new DialogResult();
                Secimx = MessageBox.Show("Yeni kayıt açmak ister misin?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Secimx == DialogResult.Yes)
                {
                    hosgeldin();
                    xtraTabControl1.SelectedTabPage = xtraTabPage1;

                }
                else
                {
                    this.Close();
                }

            }




        }
        string mresim, cresim, sresim, kresim;

        private void gridLookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("select * from rUGDTip where ID = '" + gridLookUpEdit2.EditValue + "'", bgl.baglanti());
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["ADegeri"].ToString() == null || dr["ADegeri"].ToString() == "")
                    {
                        tAdegeri.Text = "";
                        tUygulama.Text = "";
                    }
                    else
                    {

                        tAdegeri.Text = dr["ADegeri"].ToString();
                        tUygulama.Text = dr["UygulamaBolgesi"].ToString(); 
                   
                    }
                }
                bgl.baglanti().Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("A değeri bulunamadı!" + ex);
            }
        }

        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }
        string rmikro, rchallenge, rstabilite, rkutu;

        private void butonchal_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();

                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                // open.InitialDirectory = "C:\\";
                open.InitialDirectory = path;
                open.Filter = "Fotoğraf (*.jpg)|*.jpg|Tüm Dosyalar(*.*)|*.*";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    rchallenge = open.FileName;
                    // pictureEdit1.Image = new Bitmap(open.FileName);
                    butonchal.Text = "Seçildi";
                }
                parolaolustur();
                string isim = Path.GetFileName(rchallenge);
                rchal = yeniID + "rc-" + parola + ".jpg";
                using (var client = new WebClient())
                {
                    string ftpUsername = "massgrup";
                    string ftpPassword = "!88n2ee5Q";
                    ftpfullpath = "ftp://" + "www.massgrup.com/httpdocs/mRoot/Foto" + "/" + rchal;
                    rcyol = "https://" + "www.massgrup.com/mRoot/Foto" + "/" + rchal;
                    client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                    client.UploadFile(ftpfullpath, rchallenge);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oppss4: " + ex);
            }
        }

        private void butonstab_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();

                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                // open.InitialDirectory = "C:\\";
                open.InitialDirectory = path;
                open.Filter = "Fotoğraf (*.jpg)|*.jpg|Tüm Dosyalar(*.*)|*.*";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    rstabilite = open.FileName;
                    // pictureEdit1.Image = new Bitmap(open.FileName);
                    butonstab.Text = "Seçildi";
                }
                parolaolustur();
                string isim = Path.GetFileName(rstabilite);
                rsta = yeniID + "rs-"+parola + ".jpg";
                using (var client = new WebClient())
                {
                    string ftpUsername = "massgrup";
                    string ftpPassword = "!88n2ee5Q";
                    ftpfullpath = "ftp://" + "www.massgrup.com/httpdocs/mRoot/Foto" + "/" + rsta;
                    rsyol = "https://" + "www.massgrup.com/mRoot/Foto" + "/" + rsta;
                    client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                    client.UploadFile(ftpfullpath, rstabilite);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oppss3: " + ex);
            }
        }

        private void butonetiket_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();

                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                // open.InitialDirectory = "C:\\";
                open.InitialDirectory = path;
                open.Filter = "Fotoğraf (*.jpg)|*.jpg|Tüm Dosyalar(*.*)|*.*";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    rkutu = open.FileName;
                    // pictureEdit1.Image = new Bitmap(open.FileName);
                    butonetiket.Text = "Seçildi";
                }
                parolaolustur();
                string isim = Path.GetFileName(rkutu);
                rkut = yeniID + "rk-"+parola + ".jpg";
                using (var client = new WebClient())
                {
                    string ftpUsername = "massgrup";
                    string ftpPassword = "!88n2ee5Q";
                    ftpfullpath = "ftp://" + "www.massgrup.com/httpdocs/mRoot/Foto" + "/" + rkut;
                    rkyol = "https://" + "www.massgrup.com/mRoot/Foto" + "/" + rkut;
                    client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                    client.UploadFile(ftpfullpath, rkutu);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oppss2: " + ex);
            }
        }

        string rmik, rchal, rsta, rkut, ftpfullpath;

        private void comboBoxEdit3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEdit3.Text == "Devam ediyor")
            {
                mchaltr.Text = "Koruyucu etkinlik testi devam etmektedir.";
                mchalen.Text = "Screening challenge test are ongoing.";
            }
            else if (comboBoxEdit3.Text == "Tamamlandı")
            {
                mchaltr.Text = "Koruyucu etkinlik testi ekte sunulmuştur.";
                mchalen.Text = "Screening challenge test (challange test): The product contains a protective agent, the result of the test is attached.";
            }
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEdit1.Text == "Devam ediyor")
            {
                mstatr.Text = "Ürünün üretici tarafından öngörülen raf ömrü 24 aydır. Ürünün açıldıktan sonraki dayanıklılık süresi etikette 12 ay olarak belirtilmiştir." + "\r\n" + "Ürünle ilgili stabilite çalışmaları devam etmektedir.";
                mstaen.Text = "The shelf life of the product stipulated by the manufacturer is 24 months. The shelf life of the product after opening is stated as 12 months on the label." + "\r\n" + "Stability studies on the product are ongoing.";
            }
            else if (comboBoxEdit1.Text == "Tamamlandı")
            {
                mstatr.Text = "Ürünün üretici tarafından öngörülen raf ömrü 24 aydır. Ürünün açıldıktan sonraki dayanıklılık süresi etikette 12 ay olarak belirtilmiştir." + "\r\n" + "Stabilite test raporu dosya ekinde yer almaktadır.";
                mstaen.Text = "The shelf life of the product stipulated by the manufacturer is 24 months. The shelf life of the product after opening is stated as 12 months on the label." + "\r\n" + "Stability test report is in the file attachment.";
            }
        }
        string ruyari, ruyar;
        private void btn_uyari_Click(object sender, EventArgs e)
        {
            //etiket uyarıları 
            try
            {
                OpenFileDialog open = new OpenFileDialog();

                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                // open.InitialDirectory = "C:\\";
                open.InitialDirectory = path;
                open.Filter = "Fotoğraf (*.jpg)|*.jpg|Tüm Dosyalar(*.*)|*.*";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    ruyari = open.FileName;
                    // pictureEdit1.Image = new Bitmap(open.FileName);
                    btn_uyari.Text = "Seçildi";
                }
                parolaolustur();
                string isim = Path.GetFileName(ruyari);
                ruyar = yeniID + "rk-" + parola + ".jpg";
                using (var client = new WebClient())
                {
                    string ftpUsername = "massgrup";
                    string ftpPassword = "!88n2ee5Q";
                    ftpfullpath = "ftp://" + "www.massgrup.com/httpdocs/mRoot/Foto" + "/" + ruyar;
                    rkyol = "https://" + "www.massgrup.com/mRoot/Foto" + "/" + ruyar;
                    client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                    client.UploadFile(ftpfullpath, ruyari);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oppss2: " + ex);
            }
        }

        private void comboBoxEdit2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEdit2.Text == "Devam ediyor")
            {
                mmikrotr.Text = "Mikrobiyolojik çalışmalar devam etmektedir.";
                mmikroen.Text = "Microbiological studies are ongoing.";
            }
            else if (comboBoxEdit2.Text == "Tamamlandı")
            {
                mmikrotr.Text = "Mikrobiyolojik test sonuçları ekte sunulmuştur.";
                mmikroen.Text = "Microbiological study test results are available in the appendix.";
            }
        }

        private void comboBoxEdit6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEdit6.Text == "Türkçe")
            {
                mstatr.Visible = true;
                mstaen.Visible = false;
            }
            else
            {
                mstatr.Visible = false;
                mstaen.Visible = true;
            }
        }

        private void comboBoxEdit5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEdit5.Text == "Türkçe")
            {
                mchaltr.Visible = true;
                mchalen.Visible = false;
            }
            else
            {
                mchaltr.Visible = false;
                mchalen.Visible = true;
            }
        }

        private void comboBoxEdit4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEdit4.Text =="Türkçe")
            {
                mmikrotr.Visible = true;
                mmikroen.Visible = false;
            }
            else
            {
                mmikrotr.Visible = false;
                mmikroen.Visible = true;
            }
        }

        string rmyol, rcyol, rsyol, rkyol;

        string parola;
        protected void parolaolustur()
        {
            char[] cr = "0123456789abcdefghijklmnopqrstuvwxyz".ToCharArray();
            string result = string.Empty;
            Random r = new Random();
            for (int i = 0; i < 6; i++)
            {
                parola += cr[r.Next(0, cr.Length - 1)].ToString();
            }
        }



        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog open = new OpenFileDialog();

                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                // open.InitialDirectory = "C:\\";
                open.InitialDirectory = path;
                open.Filter = "Fotoğraf (*.jpg)|*.jpg|Tüm Dosyalar(*.*)|*.*";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    rmikro = open.FileName;
                    // pictureEdit1.Image = new Bitmap(open.FileName);
                    simpleButton2.Text = "Seçildi";
                }
                parolaolustur();
                string isim = Path.GetFileName(rmikro);
                rmik = yeniID + "rm-"+parola + ".jpg";
                using (var client = new WebClient())
                {
                    string ftpUsername = "massgrup";
                    string ftpPassword = "!88n2ee5Q";
                    ftpfullpath = "ftp://" + "www.massgrup.com/httpdocs/mRoot/Foto" + "/" + rmik;
                    rmyol = "https://" + "www.massgrup.com/mRoot/Foto" + "/" + rmik;
                    client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                    client.UploadFile(ftpfullpath, rmikro);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oppss1: "+ex);
            }
        }

        private void gridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        private void uYeni_FormClosed(object sender, FormClosedEventArgs e)
        {
            mresim = null;
            cresim = null;
            sresim = null;
            kresim = null;
            kayit = null;

        }
        string yeniID;
        private void uYeni_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    if (kayit == "evet")
                    {
                        
                    }
                    else
                    {
                        if (MessageBox.Show("Kaydetmeden çıkmak istediğinizden emin misiniz?",
                                        "Exit?",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question) == DialogResult.No)
                        {
                            e.Cancel = true;
                        }
                        else
                        {
                            SqlCommand komutz = new SqlCommand("delete from rUGDListe where ID = '" + yeniID + "' ", bgl.baglanti());
                            komutz.ExecuteNonQuery();
                            bgl.baglanti().Close();
                        }
                    }
                    break;
            }
        }





    }
}
