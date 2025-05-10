using ClosedXML.Excel;
using DevExpress.DataAccess.Excel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mKYS
{
    public partial class MalKabul : Form
    {
        NKR2 n = (NKR2)System.Windows.Forms.Application.OpenForms["NKR2"];
        sqlbaglanti bgl = new sqlbaglanti();

        public static string akredite, analizsayisi, id, o2, name, analiz, metod, kod, yenisim, ftpfullpath, yeniyol, rmikro, rmik, yeniID, parola, rmyol;
        public static int EvrakNo, maxevrak, maxrapor, firmaId, TurID, ykrID, mikrod, challenge, stabilite;
        string rchallenge, rchal, rcyol, rstabilite, rsta, rsyol;
        public static string rDurumu = "Rapor Beklemede";
        public static string fDurumu = "Fatura Kesilmedi";

        public MalKabul()
        {
            InitializeComponent();
        }

        private void NumuneKabul_Load(object sender, EventArgs e)
        {
            listele();
            dateTime.EditValue = DateTime.Now;
            gproje.EditValue = 20600;  
            Evrakmax();
            RaporNoMax();   
            evrak.Text = (maxevrak + 1).ToString();
            rapor.Text = (maxrapor + 1).ToString();           


        }

        public void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select ID, Aciklama from NumuneX3 where Durum = 'Aktif'", bgl.baglanti());
            da2.Fill(dt2);
            gridLookUpEdit1.Properties.DataSource = dt2;
            gridLookUpEdit1.Properties.DisplayMember = "Aciklama";
            gridLookUpEdit1.Properties.ValueMember = "ID";


            DataTable dt12 = new DataTable();
            SqlDataAdapter da12 = new SqlDataAdapter("select ID, Ad from RootTedarikci where Durum = 'Aktif' order by Ad", bgl.baglanti());
            da12.Fill(dt12);
            gfirma.Properties.DataSource = dt12;
            gfirma.Properties.DisplayMember = "Ad";
            gfirma.Properties.ValueMember = "ID";


            DataTable dt22 = new DataTable();
            SqlDataAdapter da22 = new SqlDataAdapter("select ID, Ad from RootTedarikci where Durum = 'Aktif' order by Ad", bgl.baglanti());
            da22.Fill(dt22);
            gproje.Properties.DataSource = dt22;
            gproje.Properties.DisplayMember = "Ad";
            gproje.Properties.ValueMember = "ID";

            DataTable dt32 = new DataTable();
            SqlDataAdapter da32 = new SqlDataAdapter("select ID, Kategori, UrunTipi from rUGDTip order by Kategori", bgl.baglanti());
            da32.Fill(dt32);
            gtip.Properties.DataSource = dt32;
            gtip.Properties.DisplayMember = "UrunTipi";
            gtip.Properties.ValueMember = "ID";

            ctur.Text = "Kozmetik";

            ctur.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("Select * from Numune_Grup where Grup = N'Özel' order by Tur", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                ctur.Properties.Items.Add(dr["Tur"]);
            }
            bgl.baglanti().Close();

            formullistele();
            hizmetlistele();

        }

        void formullistele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select f.INCIName, f.Miktar, c.Cas, c.EC, c.Functions, c.Regulation, r.Noael2 as 'Noael', c.ID as 'cosID', f.ID from rUGDFormül f 
                    left join rCosing c on f.INCIName = c.INCIName 
                    left join rHammadde r on c.ID = r.cID 
                    where f.UrunID = '" + ykrID + "' order by f.Miktar desc ", bgl.baglanti());
            da.Fill(dt);
            gridControl4.DataSource = dt;
            gridView6.Columns["cosID"].Visible = false;
            gridView6.Columns["ID"].Visible = false;
            RepositoryItemMemoEdit memo = new RepositoryItemMemoEdit();
            gridView6.Columns["Functions"].ColumnEdit = memo;
            gridView6.Columns["Functions"].ColumnEdit = new RepositoryItemMemoEdit();
            this.gridView6.Columns[0].Width = 110;
            this.gridView6.Columns[1].Width = 50;
            this.gridView6.Columns[2].Width = 80;
            this.gridView6.Columns[3].Width = 90;
            this.gridView6.Columns[4].Width = 90;
            this.gridView6.Columns[5].Width = 50;
            this.gridView6.Columns[6].Width = 50;
        }

        void hizmetlistele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(@"select l.Kod, l.Ad, l.Method, x.Termin, l.ID as 'aID', x.ID as 'xID' from NumuneX1 x
            left join StokAnalizListesi l on x.AnalizID = l.ID
            where x.RaporID = '" + ykrID + "' order by l.Kod", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;
            gridView3.Columns["aID"].Visible = false;
            gridView3.Columns["xID"].Visible = false;

            this.gridView3.Columns[0].Width = 35;
            this.gridView3.Columns[1].Width = 80;
            this.gridView3.Columns[2].Width = 45;
            this.gridView3.Columns[3].Width = 55;

            RepositoryItemDateEdit da = new RepositoryItemDateEdit();
            da.ShowToday = true;
            gridView3.Columns["Termin"].ColumnEdit = da;
        }
  
        void Evrakmax()
        {
            SqlCommand komutm = new SqlCommand("select max(evrak_no) from NKR", bgl.baglanti());
            SqlDataReader drm = komutm.ExecuteReader();
            while (drm.Read())
            {
                maxevrak = Convert.ToInt32(drm[0].ToString());
            }
            bgl.baglanti().Close();
        }

        void RaporNoMax()
        {
            SqlCommand komutm = new SqlCommand("select MAX(RaporNo) from NKR where Durum = 'Aktif' ", bgl.baglanti());
            SqlDataReader drm = komutm.ExecuteReader();
            while (drm.Read())
            {
                string rno = drm[0].ToString();

                if (rno == "" || rno == null)
                {
                    maxrapor = 240001;
                }
                else
                {
                    maxrapor = Convert.ToInt32(rno);
                }
            }
            bgl.baglanti().Close();
        }

        private void cdil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cdil.Text == "Türkçe")
            {
                urun.Visible = true;
                urunen.Visible = false;

                gorunumen.Visible = false;
                renken.Visible = false;
                kokuen.Visible = false;
                suen.Visible = false;
                digeren.Visible = false;
                renk.Visible = true;
                tgorunum.Visible = true;
                koku.Visible = true;
                diger.Visible = true;
                suda.Visible = true;


                mmikroen.Visible = false;
                mchalen.Visible = false;
                mstaen.Visible = false;

                mmikrotr.Visible = true;
                mchaltr.Visible = true;
                mstatr.Visible = true;
                mkul.Visible = true;
                mozel.Visible = true;
                muyar.Visible = true;
                mkulen.Visible = false;
                mozelen.Visible = false;
                muyaren.Visible = false;

            }
            else
            {
                urun.Visible = false;
                urunen.Visible = true;

                renk.Visible = false;
                tgorunum.Visible = false;
                koku.Visible = false;
                diger.Visible = false;
                suda.Visible = false;

                gorunumen.Visible = true;
                renken.Visible = true;
                kokuen.Visible = true;
                suen.Visible = true;
                digeren.Visible = true;

                mmikroen.Visible = true;
                mchalen.Visible = true;
                mstaen.Visible = true;

                mmikrotr.Visible = false;
                mchaltr.Visible = false;
                mstatr.Visible = false;

                mkul.Visible = false;
                mozel.Visible = false;
                muyar.Visible = false;
                mkulen.Visible = true;
                mozelen.Visible = true;
                muyaren.Visible = true;


            }
        }

        private void gfirma_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        private void gridLookUpEdit3_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        private void gproje_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        private void gtip_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
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
                rsta = yeniID + "rs-" + parola + ".jpg";
                using (var client = new WebClient())
                {
                    string ftpUsername = "massgrup";
                    string ftpPassword = "FfU_Gw48@aseltk5";
                    ftpfullpath = "ftp://" + "www.rootarge.com/httpdocs/mRoot/Foto" + "/" + rsta;
                    rsyol = "https://" + "www.rootarge.com/mRoot/Foto" + "/" + rsta;
                    client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                    client.UploadFile(ftpfullpath, rstabilite);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oppss3: " + ex);
            }
        }

        private void gtip_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("select * from rUGDTip where ID = '" + gtip.EditValue + "'", bgl.baglanti());
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["ADegeri"].ToString() == null || dr["ADegeri"].ToString() == "")
                    {
                        tAdegeri.Text = "";
                        //tUygulama.Text = "";
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
                    string ftpPassword = "FfU_Gw48@aseltk5";
                    ftpfullpath = "ftp://" + "www.rootarge.com/httpdocs/mRoot/Foto" + "/" + rchal;
                    rcyol = "https://" + "www.rootarge.com/mRoot/Foto" + "/" + rchal;
                    client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                    client.UploadFile(ftpfullpath, rchallenge);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oppss4: " + ex);

            }
        }

        private void gridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        private void gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //açıklama değişince listeleme

            analizler();

        }

        private void comboBoxEdit7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEdit7.Text == "Devam ediyor")
            {
                mmikrotr.Text = "Mikrobiyolojik çalışmalar devam etmektedir. Testler tamamlandığında tekrar değerlendirilecektir.";
                mmikroen.Text = "Microbiological studies are ongoing. Will be re-evaluated once tests are completed.";
            }
            else if (comboBoxEdit7.Text == "Tamamlandı")
            {
                mmikrotr.Text = "Son ürün için yapılan mikrobiyolojik analiz sonuçları ürün güvenlik dosyasında sunulmuştur. Sonuçlar mikrobiyolojik kalite kontrol limitlerine uygundur. Mikrobiyolojik kontaminasyon riski taşımamaktadır.";
                mmikroen.Text = "The results of the microbiological analysis for the final product are presented in the product safety file. The results comply with the microbiological quality control limits. There is no risk of microbiological contamination.";

            }
        }

        private void butonmik_Click(object sender, EventArgs e)
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
                    butonmik.Text = "Seçildi";
                }
                parolaolustur();
                string isim = Path.GetFileName(rmikro);
                rmik = yeniID + "rm-" + parola + ".jpg";
                using (var client = new WebClient())
                {
                    string ftpUsername = "massgrup";
                    string ftpPassword = "FfU_Gw48@aseltk5";
                    ftpfullpath = "ftp://" + "www.rootarge.com/httpdocs/mRoot/Foto" + "/" + rmik;
                    rmyol = "https://" + "www.rootarge.com/mRoot/Foto" + "/" + rmik;
                    client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                    client.UploadFile(ftpfullpath, rmikro);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oppss1: " + ex);
            }
        }

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

        private void comboBoxEdit3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEdit3.Text == "Devam ediyor")
            {
                mchaltr.Text = "Koruyucu etkinlik testi devam etmektedir. Testler tamamlandığında sonuçlar yeniden değerlendirilecektir.";
                mchalen.Text = "Preventive efficacy testing is ongoing. Results will be re-evaluated once testing is completed.";
            }
            else if (comboBoxEdit3.Text == "Tamamlandı")
            {
                mchaltr.Text = "Son ürün için yapılan koruyucu etkinlik test sonuçları ürün güvenlik dosyasında sunulmuştur. Sonuçlar uygun olarak değerlendirilmiştir.";
                mchalen.Text = "The preservative efficacy test results for the final product are presented in the product safety file. The results were evaluated as appropriate.";

            }
        }

        private void comboBoxEdit2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEdit2.Text == "Devam ediyor")
            {
                mstatr.Text = "Ürünün üretici tarafından öngörülen raf ömrü 24 aydır. Ürünün açıldıktan sonraki dayanıklılık süresi etikette 12 ay olarak belirtilmiştir." + "\r\n" + "Ürünle ilgili stabilite çalışmaları devam etmektedir. Testler tamamlandığında sonuçlar yeniden değerlendirilecektir.";
                mstaen.Text = "The shelf life of the product stipulated by the manufacturer is 24 months. The shelf life of the product after opening is stated as 12 months on the label." + "\r\n" + "Stability studies on the product are ongoing. Results will be re-evaluated once testing is completed.";
            }
            else if (comboBoxEdit2.Text == "Tamamlandı")
            {
                mstatr.Text = "Ürünün üretici tarafından öngörülen raf ömrü 24 aydır. Ürünün açıldıktan sonraki dayanıklılık süresi etikette 12 ay olarak belirtilmiştir.";
                mstaen.Text = "The shelf life of the product as specified by the manufacturer is 24 months. The shelf life of the product after opening is stated as 12 months on the label.";

            }
        }

        private void txtAdet_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtEvrak_KeyPress(object sender, KeyPressEventArgs e)
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

        private void durumekle()
        {
            DateTime tarih = DateTime.Now;
            SqlCommand add = new SqlCommand("insert into NumuneDurum (RaporNo, Durum, Kim) values (@o1, @o3,@o4) ; " +
                " insert into NumuneTeslim (RaporNo,Tarih, Durum, Kim) values (@o1, @o2, @o3,@o4)", bgl.baglanti());
            add.Parameters.AddWithValue("@o1", rapor.Text);
            add.Parameters.AddWithValue("@o2", tarih);
            add.Parameters.AddWithValue("@o3", "Numune Kabul Edildi");
            add.Parameters.AddWithValue("@o4", Giris.kullaniciID);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
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

            }
        }

        private void gridView2_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }
        }

        private void gridView3_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu2.ShowPopup(p2);
            }
        }

        private void btn_analizekle_Click(object sender, EventArgs e)
        {
            
            try
            {
                evrakkayit();
                durumekle();
                fotokaydet();
                formullistele();
                hizmetlistele();

                if (Application.OpenForms["NKR2"] == null)
                {

                }
                else
                {
                    n.listele();
                }

                labelControl5.Text = "Evrak / RaporNo / ID: " + evrak.Text + " / " + rapor.Text + " / " + ykrID ;

                tabPane1.SelectedPage = tabNavigationPage2;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Tüh ya! Bak ne oldu: " + ex.Message);
            }
           

        }

        void fotokaydet()
        {
            try
            {

                if (name == null || name == "")
                {

                }
                else
                {
                    string isim = Path.GetFileName(name);
                    yenisim = rapor.Text + " - " + isim;

                    using (var client = new WebClient())
                    {
                        string ftpUsername = "massgrup";
                        string ftpPassword = "FfU_Gw48@aseltk5";
                        ftpfullpath = "ftp://" + "www.rootarge.com/httpdocs/cosmo/Numune" + "/" + yenisim;
                        yeniyol = "http://" + "www.rootarge.com/cosmo/Numune" + "/" + yenisim;
                        client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                        client.UploadFile(ftpfullpath, name);
                    }

                    SqlCommand ekle = new SqlCommand("insert into Fotograf(RaporID,Path) values(@d1,@d2)", bgl.baglanti());
                    ekle.Parameters.AddWithValue("@d1", ykrID);
                    ekle.Parameters.AddWithValue("@d2", yenisim);
                    ekle.ExecuteNonQuery();
                    bgl.baglanti().Close();

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata 124134: " + ex);
            }
        }

        void evrakkayit()
        {

            int Donen = 0;

            SqlCommand komut12 = new SqlCommand(@"BEGIN TRANSACTION 
            insert into NKR (Evrak_No,Numune_Adi,Tarih,Tur,Firma_ID,Rapor_Durumu,Aciklama,RaporNo,Revno,Durum) values 
            (@n1,@n2,@n4,@n5,@n7,@n8,@n9,@n11,@n12,@n14) SET @ID = SCOPE_IDENTITY() ; 
            COMMIT TRANSACTION", bgl.baglanti());
            komut12.Parameters.AddWithValue("@n1", evrak.Text);
            komut12.Parameters.AddWithValue("@n2", urun.Text);
            komut12.Parameters.AddWithValue("@n4", dateTime.EditValue);
            komut12.Parameters.AddWithValue("@n5", ctur.Text);
            komut12.Parameters.AddWithValue("@n7", (object)gfirma.EditValue ?? DBNull.Value);
            komut12.Parameters.AddWithValue("@n8", rDurumu);
            komut12.Parameters.AddWithValue("@n9", not.Text);
            komut12.Parameters.AddWithValue("@n11", rapor.Text);
            komut12.Parameters.AddWithValue("@n12", ver.Text);
            komut12.Parameters.AddWithValue("@n14", "Aktif");
            komut12.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
            komut12.ExecuteNonQuery();
            Donen = Convert.ToInt32(komut12.Parameters["@ID"].Value);
            bgl.baglanti().Close();
            ykrID = Donen;

            SqlCommand komut = new SqlCommand(@"BEGIN TRANSACTION 
            insert into Odeme(Odeme_Durumu, Evrak_No) values(@o1,@o2); 
            insert into NumuneDetay(Miktar,SeriNo,UretimTarihi,SKT,RaporID,ProjeID,Birim) values(@a2,@a3,@a4,@a5,@a6,@a9,@a10); 
            insert into Rapor_Durum(RaporNo, Durum, Tarih,TanimlayanID, RaporID) values (@c1,@c2, @c3,@c4,@c5); 
            insert into rUGDListe(RaporNo,UrunEn, Barkod, Tip1, Tip2,Uygulama,Hedef,A,BirimID) values(@u0, @u1, @u2, @u3, @u4, @u5, @u6, @u7, @u8); 
            insert into rUGDDetay (UrunID, Gorunum, Renk, Koku, pH, Kaynama, Erime, Yogunluk, Viskozite, Suda, Diger, KokuEn, GorunumEn, RenkEn, SudaEn, DigerEn ) values(@d1, @d2, @d3, @d4, @d5, @d6, @d7, @d8, @d9, @d10, @d11, @d13, @d14, @d15, @d16, @d17);
            COMMIT TRANSACTION", bgl.baglanti());
            komut.Parameters.AddWithValue("@o1", fDurumu);
            komut.Parameters.AddWithValue("@o2", evrak.Text);
            komut.Parameters.AddWithValue("@a2", miktar.Text);
            komut.Parameters.AddWithValue("@a3", lot.Text);
            komut.Parameters.AddWithValue("@a4", uretim.Text);
            komut.Parameters.AddWithValue("@a5", skt.Text);
            komut.Parameters.AddWithValue("@a6", ykrID);
            komut.Parameters.AddWithValue("@a9", (object)gproje.EditValue ?? DBNull.Value);
            komut.Parameters.AddWithValue("@a10", cbirim.Text);
            komut.Parameters.AddWithValue("@c1", rapor.Text);
            komut.Parameters.AddWithValue("@c2", "Yeni Numune");
            komut.Parameters.AddWithValue("@c3", dateTime.EditValue);
            komut.Parameters.AddWithValue("@c4", Giris.kullaniciID);
            komut.Parameters.AddWithValue("@c5", ykrID);
            komut.Parameters.AddWithValue("@u0", ykrID);
            komut.Parameters.AddWithValue("@u1", urunen.Text);
            komut.Parameters.AddWithValue("@u2", barkod.Text);
            komut.Parameters.AddWithValue("@u3", ctip.Text);
            komut.Parameters.AddWithValue("@u4", (object)gtip.EditValue ?? DBNull.Value);
            komut.Parameters.AddWithValue("@u5", tUygulama.Text);
            komut.Parameters.AddWithValue("@u6", thedef.Text);
            if(tAdegeri.Text == "" | tAdegeri.Text == null)
                komut.Parameters.AddWithValue("@u7", DBNull.Value);
            else
               komut.Parameters.AddWithValue("@u7", Convert.ToDecimal(tAdegeri.Text));
            komut.Parameters.AddWithValue("@u8", 2);
            komut.Parameters.AddWithValue("@d1", ykrID);
            komut.Parameters.AddWithValue("@d2", tgorunum.Text);
            komut.Parameters.AddWithValue("@d3", renk.Text);
            komut.Parameters.AddWithValue("@d4", koku.Text);
            komut.Parameters.AddWithValue("@d5", ph.Text);
            komut.Parameters.AddWithValue("@d6", kaynama.Text);
            komut.Parameters.AddWithValue("@d7", erime.Text);
            komut.Parameters.AddWithValue("@d8", yogunluk.Text);
            komut.Parameters.AddWithValue("@d9", viskozite.Text);
            komut.Parameters.AddWithValue("@d10", suda.Text);
            komut.Parameters.AddWithValue("@d11", diger.Text);
            komut.Parameters.AddWithValue("@d13", kokuen.Text);
            komut.Parameters.AddWithValue("@d14", gorunumen.Text);
            komut.Parameters.AddWithValue("@d15", renken.Text);
            komut.Parameters.AddWithValue("@d16", suen.Text);
            komut.Parameters.AddWithValue("@d17", digeren.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();

            if (mikro.Checked == true)
                mikrod = 1;
            else
                mikrod = 0;
            if (chal.Checked == true)
                challenge = 1;
            else
                challenge = 0;
            if (stab.Checked == true)
                stabilite = 1;
            else
                stabilite = 0;
            if (Standart.Checked == true)
            {
                rmik = "9274rm-opirbd.jpg";
                rchal = "9274rc-opirbdioll4x.jpg" ;
                rsta = "rs-nnt29j.jpg";
            }

            SqlCommand add2 = new SqlCommand(@"BEGIN TRANSACTION
            insert into rUGDDetay2 (UrunID, Mikro, Challenge, Stabilite, MResim, CResim, SResim, StabiliteNot, MikroNot, MikroNotEn, ChallengeNot, ChallengeNotEn, StabiliteNotEn,
            Kullanim, Ozellikler, Uyarilar, KullanimEn, UyarilarEn, Ozellikleren )
            values (@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@o1,@o2,@o3,@o4,@o5,@o6,@o7,@o8,@o9,@o10,@o11) COMMIT TRANSACTION", bgl.baglanti());
            add2.Parameters.AddWithValue("@a1", ykrID);
            add2.Parameters.AddWithValue("@a2", mikrod);
            add2.Parameters.AddWithValue("@a3", challenge);
            add2.Parameters.AddWithValue("@a4", stabilite);
            add2.Parameters.AddWithValue("@a5", string.IsNullOrEmpty(rmik) ? (object)DBNull.Value : rmik);
            add2.Parameters.AddWithValue("@a6", string.IsNullOrEmpty(rchal) ? (object)DBNull.Value : rchal);
            add2.Parameters.AddWithValue("@a7", string.IsNullOrEmpty(rsta) ? (object)DBNull.Value : rsta);
            add2.Parameters.AddWithValue("@a8", mstatr.Text);
            add2.Parameters.AddWithValue("@o1", mmikrotr.Text);
            add2.Parameters.AddWithValue("@o2", mmikroen.Text);
            add2.Parameters.AddWithValue("@o3", mchaltr.Text);
            add2.Parameters.AddWithValue("@o4", mchalen.Text);
            add2.Parameters.AddWithValue("@o5", mstaen.Text);
            add2.Parameters.AddWithValue("@o6", mkul.Text);
            add2.Parameters.AddWithValue("@o7", mozel.Text);
            add2.Parameters.AddWithValue("@o8", muyar.Text);
            add2.Parameters.AddWithValue("@o9", mkulen.Text);
            add2.Parameters.AddWithValue("@o10", muyaren.Text);
            add2.Parameters.AddWithValue("@o11", mozelen.Text);
            add2.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        void analizler()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(@"select l.Kod, l.Ad, l.Method, l.ID as 'aID' from NumuneX4 x
            left join StokAnalizDetay d on x.AltAnalizID = d.ID
            left join StokAnalizListesi l on d.AnalizID = l.ID
            where d.Tur = 'Toplam' and x.X3ID = '" + gridLookUpEdit1.EditValue + "' except Select l.Kod, l.Ad, l.Method, l.ID as 'aID' from NumuneX4 x left join StokAnalizDetay d on x.AltAnalizID = d.ID left join StokAnalizListesi l on d.AnalizID = l.ID where l.ID in (select AnalizID from NumuneX1 where RaporID = '"+ykrID+"') order by l.Kod ", bgl.baglanti());
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;
            gridView2.Columns["aID"].Visible = false;
            if (dt2 != null)
            {
                this.gridView2.Columns[0].Width = 35;
                this.gridView2.Columns[1].Width = 80;
                this.gridView2.Columns[2].Width = 45;
            }
  

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //seçili analizleri ekle

            for (int i = 0; i < gridView2.SelectedRowsCount; i++)
            {
                id = gridView2.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                o2 = gridView2.GetRowCellValue(y, "aID").ToString();
                SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                    "insert into NumuneX1 (RaporID, AnalizID, x3ID) " +
                    "values (@o1,@o2, @o3);" +
                    "COMMIT TRANSACTION", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", ykrID);
                add2.Parameters.AddWithValue("@o2", o2);
                add2.Parameters.AddWithValue("@o3", gridLookUpEdit1.EditValue);
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();
            }

            analizler();
            hizmetlistele();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //seçili analizleri kaldır
            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {
                id = gridView3.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                o2 = gridView3.GetRowCellValue(y, "aID").ToString();
                SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                    "delete from NumuneX1 where AnalizID = @o2 and RaporID = @o1;" +
                    "COMMIT TRANSACTION", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", ykrID);
                add2.Parameters.AddWithValue("@o2", o2);
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();
            }

            analizler();
            hizmetlistele();
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView3.RowCount; i++)
                {                   
                    o2 = gridView3.GetRowCellValue(i, "xID").ToString();
                    SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                        "update NumuneX1 set Termin = @o1, Durum = @o2, HizmetDurum = @o3 where ID = @o4;" +
                        "COMMIT TRANSACTION", bgl.baglanti());
                    add2.Parameters.AddWithValue("@o1", Convert.ToDateTime(gridView3.GetRowCellValue(i, "Termin").ToString()));
                    add2.Parameters.AddWithValue("@o2", "Aktif");
                    add2.Parameters.AddWithValue("@o3", "Yeni Analiz");
                    add2.Parameters.AddWithValue("@o4", o2);
                    add2.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }

                labelControl13.Text = "Evrak / RaporNo / ID: " + evrak.Text + " / " + rapor.Text + " / " + ykrID;
                tabPane1.SelectedPage = tabNavigationPage3;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Tüh ya! Bak ne oldu 77: " + ex.Message);
            }

        }

        private void btn_ac_Click(object sender, EventArgs e)
        {
            //OpenFileDialog file = new OpenFileDialog();
            //file.Filter = "Excel Dosyası |*.xlsx| Excel Dosyası|*.xls ";
            //if (file.ShowDialog() == DialogResult.OK)
            //{
            //    ExcelDataSource excel = new ExcelDataSource();
            //    excel.FileName = file.FileName;
            //    ExcelWorksheetSettings excelWorksheetSettings = new ExcelWorksheetSettings("Formül", "A1:E250");
            //    //excel.SourceOptions = new ExcelSourceOptions(excelWorksheetSettings);
            //    //excel.SourceOptions = new CsvSourceOptions() { CellRange = "A1:E250" };
            //    //excel.SourceOptions.SkipEmptyRows = true;
            //    //excel.SourceOptions.UseFirstRowAsHeader = true;
            //    //excel.Fill();
            //    //gridControl3.DataSource = excel;

            //    excel.SourceOptions = new ExcelSourceOptions(excelWorksheetSettings)
            //    {
            //        SkipEmptyRows = true,
            //        UseFirstRowAsHeader = true
            //    };

            //    excel.Fill();

            //    DataTable fullData = (excel as IListSource).GetList() as DataTable;

            //    // Sadece A ve E sütunları: "INCI İsmi" ve "Üst Değer(%)"
            //    DataTable filteredTable = fullData.DefaultView.ToTable(false, "INCI İsmi", "Üst Değer(%)");

            //    gridControl3.DataSource = filteredTable;


            //}

            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Excel Dosyası |*.xlsx";
            if (file.ShowDialog() == DialogResult.OK)
            {
                DataTable table = new DataTable();
                table.Columns.Add("INCI İsmi");
                table.Columns.Add("Üst Değer(%)");

                using (var workbook = new XLWorkbook(file.FileName))
                {
                    var worksheet = workbook.Worksheet("Tablo");

                    // Satırları dolaş (1. satır başlık olduğu için 2. satırdan başla)
                    foreach (var row in worksheet.RangeUsed().RowsUsed().Skip(1))
                    {
                        var a = row.Cell(1).GetString(); // A sütunu (INCI İsmi)
                        var e2 = row.Cell(5).GetValue<string>(); // E sütunu (Üst Değer(%))
                        table.Rows.Add(a, e2);
                    }
                }

                gridControl3.DataSource = table;

            }
        }
        private void btn_kontrol_Click(object sender, EventArgs e)
        {
            try
            {
                for (int ik = 0; ik <= gridView5.RowCount - 1; ik++)
                {


                    SqlCommand komutz = new SqlCommand("insert into rUGDFormül (UrunID, INCIName, Miktar, DaP) values (@o1,@o2,@o3,@o4) ", bgl.baglanti());
                    komutz.Parameters.AddWithValue("@o1", ykrID);
                    komutz.Parameters.AddWithValue("@o2", gridView5.GetRowCellValue(ik, "INCI İsmi").ToString());
                    komutz.Parameters.AddWithValue("@o3", Convert.ToDecimal(gridView5.GetRowCellValue(ik, "Miktar").ToString(), CultureInfo.InvariantCulture));
                    komutz.Parameters.AddWithValue("@o4", 100);
                    komutz.ExecuteNonQuery();
                    bgl.baglanti().Close();

                }

                formullistele();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata55: " + ex);
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ürüne ait formülasyonu silmek mi istiyorsunuz?","Temizle?",   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {

            }
            else
            {
                SqlCommand komutz = new SqlCommand("delete from rUGDFormül where UrunID = '" + ykrID + "' ", bgl.baglanti());
                komutz.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Silme işlemi başarılı, yeni formül ekleyebilirsiniz!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                formullistele();
            }
        }

        private void btnexcel_Click(object sender, EventArgs e)
        {
            string path = "FormülListesi.xlsx";
            gridControl2.ExportToXlsx(path);
            Process.Start(path);
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView6.RowCount < 1)
                {
                    MessageBox.Show("Neyi kaydedeyim dostum ? ");
                }
                else
                {
                    for (int ik = 0; ik <= gridView6.RowCount - 1; ik++)
                    {
                        SqlCommand komutz = new SqlCommand("update rUGDFormül set  HammaddeID=@o2 , Miktar=@o3, Noael=@o4 where ID = '" + gridView6.GetRowCellValue(ik, "ID").ToString() + "' ", bgl.baglanti());
                        komutz.Parameters.AddWithValue("@o2", gridView6.GetRowCellValue(ik, "cosID").ToString());
                        komutz.Parameters.AddWithValue("@o3", Convert.ToDecimal(gridView6.GetRowCellValue(ik, "Miktar").ToString()));
                        if (gridView6.GetRowCellValue(ik, "Noael").ToString() == null || gridView6.GetRowCellValue(ik, "Noael").ToString() == "")
                            komutz.Parameters.AddWithValue("@o4", DBNull.Value);
                        else
                            komutz.Parameters.AddWithValue("@o4", Convert.ToInt32(gridView6.GetRowCellValue(ik, "Noael").ToString()));
                        komutz.ExecuteNonQuery();
                        bgl.baglanti().Close();
                    }

                    labelControl14.Visible = true;
                }
               
  
             


            }
            catch (Exception ex)
            {
                MessageBox.Show("Üzülmeyin, yazılımcı tanıdık. Çözeriz! " + ex);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //Kapat

            try
            {
                DialogResult cikis = new DialogResult();
                cikis = MessageBox.Show("Her şey tamam. Yeni ürün eklemek ister misin?", "Uyarı", MessageBoxButtons.YesNo);
                if (cikis == DialogResult.Yes)
                {
                    tabPane1.SelectedPage = tabNavigationPage1;
                    rapor.Text = "";
                    RaporNoMax();
                    int yenirap = maxrapor + 1;
                    rapor.Text = yenirap.ToString();
                    ykrID = 0;
                    urun.Text = null;
                    urunen.Text = null;
                    barkod.Text = null;
                    miktar.Text = null;
                    lot.Text = null;
                    uretim.Text = null;
                    skt.Text = null;
                    pictureEdit1.Image = null;
                    butonmik.Text = "Resim Seç";
                    butonchal.Text = "Resim Seç";
                    butonstab.Text = "Resim Seç";
                    rmik = null;
                    rchal = null;
                    rsta = null;
                    hizmetlistele();
                    analizler();
                    gridControl3.DataSource = null;
                    gridView5.Columns.Clear();
                    gridControl4.DataSource = null;
                    gridView6.Columns.Clear();
                    labelControl14.Visible = false;

                    labelControl5.Text = "Evrak / RaporNo / ID: " + evrak.Text + " / " + rapor.Text + " / " + ykrID;
                    labelControl13.Text = "Evrak / RaporNo / ID: " + evrak.Text + " / " + rapor.Text + " / " + ykrID;

                }

                if (cikis == DialogResult.No)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Üzülmeyin, yazılımcı tanıdık. Çözeriz! " + ex);
            }
        }

    }
}
