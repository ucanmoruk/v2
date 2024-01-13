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
    public partial class uCopy : Form
    {
        public uCopy()
        {
            InitializeComponent();
        }

        public static string detay;

        sqlbaglanti bgl = new sqlbaglanti();
        uListe n = (uListe)System.Windows.Forms.Application.OpenForms["uListe"];

        public static string uID, gelis, formuldahil;
        private void uYeni_Load(object sender, EventArgs e)
        {
            if (gelis=="copy")
            {
                hosgeldin();
            }
            else
            {
                
            }
            listele();
            detaybul();
            
        }

         void hosgeldin()
         {
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

            if (formuldahil == "evet")
            {
                SqlCommand komut2 = new SqlCommand("select * from rUGDformül where UrunID = '"+uID+"'", bgl.baglanti());
                SqlDataReader dr2 = komut2.ExecuteReader();
                while (dr2.Read())
                {
                    string HammaddeID = dr2["HammaddeID"].ToString();
                    string INCIName = dr2["INCIName"].ToString();
                    decimal miktar = Convert.ToDecimal(dr2["Miktar"].ToString());

                    SqlCommand add12 = new SqlCommand(@"BEGIN TRANSACTION insert into rUGDformül (UrunID, HammaddeID, INCIName, Miktar)
                    values (@o2,@o3,@o4, @o5) ; COMMIT TRANSACTION" , bgl.baglanti());
                    add12.Parameters.AddWithValue("@o2", yeniID);
                    add12.Parameters.AddWithValue("@o3", HammaddeID);
                    add12.Parameters.AddWithValue("@o4", INCIName);
                    add12.Parameters.AddWithValue("@o5", miktar);
                    add12.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }
                bgl.baglanti().Close();
            }


        }
        string mchal, msta;
        void detaybul()
        {
            SqlCommand komut = new SqlCommand("select * from rUGDListe where ID = '" + uID + "' ", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                if (gelis!="copy")
                    traporno.Text = dr["RaporNo"].ToString();
                if (gelis != "copy")
                    dateEdit1.EditValue = Convert.ToDateTime(dr["Tarih"].ToString());
                else
                    dateEdit1.EditValue = DateTime.Now;
               gridLookUpEdit1.EditValue = dr["FirmaID"].ToString();
               tverno.Text = dr["Versiyon"].ToString();
               turun.Text = dr["Urun"].ToString();
               tbarkod.Text = dr["Barkod"].ToString();
               tmiktar.Text = dr["Miktar"].ToString();
               ctip.Text = dr["Tip1"].ToString();
               gridLookUpEdit2.EditValue = dr["Tip2"].ToString();
               tUygulama.Text = dr["Uygulama"].ToString();
               thedef.Text = dr["Hedef"].ToString();
               tAdegeri.Text = dr["A"].ToString();            
            }
            bgl.baglanti().Close();

            SqlCommand komut2 = new SqlCommand("select * from rUGDDetay where UrunID = '" + uID + "' ", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                tgorunum.Text = dr2["Gorunum"].ToString();
                trenk.Text = dr2["Renk"].ToString();
                tkoku.Text = dr2["Koku"].ToString();
                tph.Text = dr2["pH"].ToString();
                tkaynama.Text = dr2["Kaynama"].ToString();
                terime.Text = dr2["Erime"].ToString();
                tyogunluk.Text = dr2["Yogunluk"].ToString();
                tviskozite.Text = dr2["Viskozite"].ToString();
                tsuda.Text = dr2["Suda"].ToString();
                tdiger.Text = dr2["Diger"].ToString();
            }
            bgl.baglanti().Close();

            SqlCommand komut3 = new SqlCommand("select * from rUGDDetay2 where UrunID = '" + uID + "' ", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                string mikro = dr3["Mikro"].ToString();
                rmik  = dr3["MResim"].ToString();
                string challenge = dr3["Challenge"].ToString();
                rchal= dr3["CResim"].ToString();
                string stabilite = dr3["Stabilite"].ToString();
                rsta = dr3["SResim"].ToString();
                memoEdit1.Text = dr3["StabiliteNot"].ToString();
                memoEdit2.Text = dr3["Kullanim"].ToString();
                memoEdit3.Text = dr3["Ozellikler"].ToString();
                memoEdit4.Text = dr3["Uyarilar"].ToString();
                rkut = dr3["Kutu"].ToString();

                if (rmik != null)
                    simpleButton2.Text = "Seçili";
                if (rchal != null)
                    butonchal.Text = "Seçili";
                if (rsta != null)
                    butonstab.Text = "Seçili";
                if (rkut != null)
                    butonetiket.Text = "Seçili";

                if (mikro == "True")
                    checkEdit1.Checked = true;
                else
                    checkEdit1.Checked = false;
                if (challenge == "True")
                    checkEdit2.Checked = true;
                else
                    checkEdit2.Checked = false;
                if (stabilite == "True")
                    checkEdit3.Checked = true;
                else
                    checkEdit3.Checked = false;

            }
            bgl.baglanti().Close();




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

        private void Next_Click(object sender, EventArgs e)
        {
            try
            {
                if (gelis == "copy")
                {
                    SqlCommand add2 = new SqlCommand(@"BEGIN TRANSACTION
                 update rUGDListe set Versiyon=@a1, Tarih=@a2, FirmaID=@a3, Urun=@a4, Barkod=@a5, Miktar=@a6, 
                 Tip1=@a7, Tip2=@a8, Uygulama=@a9, Hedef=@a10, A=@a11 where ID = '" + yeniID + "' COMMIT TRANSACTION", bgl.baglanti());
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
                    add2.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }
                else
                {
                    SqlCommand add2 = new SqlCommand(@"BEGIN TRANSACTION
                 update rUGDListe set Versiyon=@a1, Tarih=@a2, FirmaID=@a3, Urun=@a4, Barkod=@a5, Miktar=@a6, 
                 Tip1=@a7, Tip2=@a8, Uygulama=@a9, Hedef=@a10, A=@a11 where ID = '" + uID + "' COMMIT TRANSACTION", bgl.baglanti());
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
                    add2.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }
                xtraTabControl1.SelectedTabPage = xtraTabPage2;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata1: "+ ex);
            }
            
        }

        private void next2_Click(object sender, EventArgs e)
        {
            try
            {
                if (gelis =="copy")
                {

                    SqlCommand add2 = new SqlCommand(@"BEGIN TRANSACTION
                insert into rUGDDetay (UrunID, Gorunum, Renk, Koku, pH, Kaynama, Erime, Yogunluk, Viskozite, Suda, Diger, Durum)
                values (@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9,@a10,@a11,@a12) COMMIT TRANSACTION", bgl.baglanti());
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
                    add2.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }
                else
                {

                    SqlCommand add2 = new SqlCommand(@"BEGIN TRANSACTION
                    update rUGDDetay set Gorunum =@a2, Renk=@a3, Koku=@a4, pH=@a5, Kaynama=@a6, Erime=@a7, 
                    Yogunluk=@a8, Viskozite=@a9, Suda=@a10, Diger=@a11 where UrunID = '"+uID+"' COMMIT TRANSACTION", bgl.baglanti());
                   // add2.Parameters.AddWithValue("@a1", yeniID);
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
                    add2.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }

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

                if (gelis == "copy")
                {
                    SqlCommand add2 = new SqlCommand(@"BEGIN TRANSACTION
                     insert into rUGDDetay2 (UrunID, Mikro, Challenge, Stabilite, MResim, CResim, SResim, StabiliteNot, Durum)
                    values (@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9) COMMIT TRANSACTION", bgl.baglanti());
                    add2.Parameters.AddWithValue("@a1", yeniID);
                    add2.Parameters.AddWithValue("@a2", mikro);
                    add2.Parameters.AddWithValue("@a3", challenge);
                    add2.Parameters.AddWithValue("@a4", stabilite);
                    add2.Parameters.AddWithValue("@a5", string.IsNullOrEmpty(rmik) ? (object)DBNull.Value : rmik);
                    add2.Parameters.AddWithValue("@a6", string.IsNullOrEmpty(rchal) ? (object)DBNull.Value : rchal);
                    add2.Parameters.AddWithValue("@a7", string.IsNullOrEmpty(rsta) ? (object)DBNull.Value : rsta);
                    add2.Parameters.AddWithValue("@a8", memoEdit1.Text);
                    add2.Parameters.AddWithValue("@a9", "Pasif");
                    add2.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }
                else
                {
                    SqlCommand add2 = new SqlCommand(@"BEGIN TRANSACTION
                    update rUGDDetay2 set Mikro=@a2, Challenge=@a3, Stabilite=@a4, MResim=@a5, CResim=@a6, SResim=@a7, StabiliteNot=@a8 where UrunID='"+uID+"' COMMIT TRANSACTION", bgl.baglanti());
                    add2.Parameters.AddWithValue("@a2", mikro);
                    add2.Parameters.AddWithValue("@a3", challenge);
                    add2.Parameters.AddWithValue("@a4", stabilite);
                    add2.Parameters.AddWithValue("@a5", string.IsNullOrEmpty(rmik) ? (object)DBNull.Value : rmik);
                    add2.Parameters.AddWithValue("@a6", string.IsNullOrEmpty(rchal) ? (object)DBNull.Value : rchal);
                    add2.Parameters.AddWithValue("@a7", string.IsNullOrEmpty(rsta) ? (object)DBNull.Value : rsta);
                    add2.Parameters.AddWithValue("@a8", memoEdit1.Text);
                    add2.ExecuteNonQuery();
                    bgl.baglanti().Close();

                }
                xtraTabControl1.SelectedTabPage = xtraTabPage4;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata3: " + ex);
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (gelis == "copy")
            {
                kaydet();
            }
            else
            {                
                guncelle();
            }
        }

                       
        string kayit;
        void kaydet()
        {
            //rUGDListe durum aktif güncelle

            SqlCommand add2 = new SqlCommand(@"BEGIN TRANSACTION
            update rUGDDetay2 set Kullanim=@a1, Ozellikler=@a2, Uyarilar=@a3, Kutu=@a4, Durum=@a5 where UrunID = '" + yeniID + "' ;" +
            "update rUGDListe set Durum=@a6 where ID = '"+yeniID+"' ;" +
            "update rUGDDetay set Durum=@a7 where UrunID = '" + yeniID + "' COMMIT TRANSACTION", bgl.baglanti());
            add2.Parameters.AddWithValue("@a1", memoEdit2.Text);
            add2.Parameters.AddWithValue("@a2", memoEdit3.Text);
            add2.Parameters.AddWithValue("@a3", memoEdit4.Text);
            add2.Parameters.AddWithValue("@a4", string.IsNullOrEmpty(rkut) ? (object)DBNull.Value : rkut);
            add2.Parameters.AddWithValue("@a5", "Aktif");
            add2.Parameters.AddWithValue("@a6", "Aktif");
            add2.Parameters.AddWithValue("@a7", "Aktif");
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
            Secim = MessageBox.Show("Kayıt başarılı! Yeni temiz bir sayfa ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Secim == DialogResult.Yes)
            {
                hosgeldin();
                xtraTabControl1.SelectedTabPage = xtraTabPage1;

            }
            else
            {
                this.Close();
            }




        }
  
        void guncelle()
        {
            //rUGDListe durum aktif güncelle

            SqlCommand add2 = new SqlCommand(@"BEGIN TRANSACTION
            update rUGDDetay2 set Kullanim=@a1, Ozellikler=@a2, Uyarilar=@a3, Kutu=@a4 where UrunID = '" + uID + "' ; COMMIT TRANSACTION", bgl.baglanti());
            add2.Parameters.AddWithValue("@a1", memoEdit2.Text);
            add2.Parameters.AddWithValue("@a2", memoEdit3.Text);
            add2.Parameters.AddWithValue("@a3", memoEdit4.Text);
            add2.Parameters.AddWithValue("@a4", string.IsNullOrEmpty(rkut) ? (object)DBNull.Value : rkut);
            //add2.Parameters.AddWithValue("@a5", "Aktif");
            //add2.Parameters.AddWithValue("@a6", "Aktif");
            //add2.Parameters.AddWithValue("@a7", "Aktif");
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

            MessageBox.Show("Güncelleme başarılı", "Oooppss!!");
           
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
                parolaolustur();
                if (gelis == "copy")
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

                    string isim = Path.GetFileName(rchallenge);
                    rchal = yeniID + "rc-"+parola + ".jpg";
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
                else
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

                    string isim = Path.GetFileName(rchallenge);
                    rchal = uID + "rc-"+parola + ".jpg";
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
                parolaolustur();
                if (gelis == "copy")
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
                else
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

                    string isim = Path.GetFileName(rstabilite);
                    rsta = uID + "rs-"+parola + ".jpg";
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
                parolaolustur();
                if (gelis == "copy")
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
                else
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

                    string isim = Path.GetFileName(rkutu);
                    rkut = uID + "rk-"+parola + ".jpg";
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

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oppss2: " + ex);
            }
        }

        string rmik, rchal, rsta, rkut, ftpfullpath;
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
                parolaolustur();
                if (gelis == "copy")
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

                    string isim = Path.GetFileName(rmikro);
                    rmik = yeniID + "rm-" +parola + ".jpg";
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
                else
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

                    string isim = Path.GetFileName(rmikro);
                    rmik = uID + "rm-" + parola + ".jpg";
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
            gelis = null;
            uID = null;
            formuldahil = null;

        }
        string yeniID;
        private void uYeni_FormClosing(object sender, FormClosingEventArgs e)
        {
            //switch (e.CloseReason)
            //{
            //    case CloseReason.UserClosing:
            //        if (kayit == "evet")
            //        {
                        
            //        }
            //        else
            //        {
            //            if (MessageBox.Show("Kaydetmeden çıkmak istediğinizden emin misiniz?",
            //                            "Exit?",
            //                            MessageBoxButtons.YesNo,
            //                            MessageBoxIcon.Question) == DialogResult.No)
            //            {
            //                e.Cancel = true;
            //            }
            //            else
            //            {
            //                SqlCommand komutz = new SqlCommand("delete from rUGDListe where ID = '" + yeniID + "' ", bgl.baglanti());
            //                komutz.ExecuteNonQuery();
            //                bgl.baglanti().Close();
            //            }
            //        }
            //        break;
            //}
        }

  


    }
}
