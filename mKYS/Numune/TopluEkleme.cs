using DevExpress.DataAccess.Excel;
using DevExpress.XtraEditors;
using mKYS;
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

namespace mROOT.Numune
{
    public partial class TopluEkleme : Form
    {
        public TopluEkleme()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();
        NKR2 n = (NKR2)System.Windows.Forms.Application.OpenForms["NKR2"];
        int maxevrak, maxrapor, yenievrak, yenirapor, ykrID;
        string uygulama, A;

        private void TopluEkleme_Load(object sender, EventArgs e)
        {
            listele();
            gproje.EditValue = 20600;
        }

        void listele()
        {
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
        }

        private void btn_ac_Click(object sender, EventArgs e)
        {
            // hem seç hem aktar

            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Excel Dosyası |*.xlsx| Excel Dosyası|*.xls ";
            if (file.ShowDialog() == DialogResult.OK)
            {
                ExcelDataSource excel = new ExcelDataSource();
                excel.FileName = file.FileName;
                ExcelWorksheetSettings excelWorksheetSettings = new ExcelWorksheetSettings("Formül", "A1:AN100");
                excel.SourceOptions = new ExcelSourceOptions(excelWorksheetSettings);
                excel.SourceOptions = new CsvSourceOptions() { CellRange = "A1:AN100" };
                excel.SourceOptions.SkipEmptyRows = true;
                excel.SourceOptions.UseFirstRowAsHeader = true;
                excel.Fill();
                gridControl1.DataSource = excel;
            }

        }

        private void gfirma_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        private void gproje_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            // temizle

            if (MessageBox.Show("Sayfayı temizlemek istiyor musun?",
                                              "Temizle?",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question) == DialogResult.No)
            {

            }
            else
            {
                gridControl1.DataSource = null;
                gridView1.Columns.Clear();
            }
        }

        private void btn_kontrol_Click(object sender, EventArgs e)
        {
            try
            {
                Evrakmax();
                RaporNoMax();

                SqlCommand komut42 = new SqlCommand(@"BEGIN TRANSACTION 
                    insert into Odeme(Odeme_Durumu, Evrak_No) values(@o1,@o2) ; 
                    COMMIT TRANSACTION", bgl.baglanti());
                komut42.Parameters.AddWithValue("@o1", "Fatura Kesilmedi");
                komut42.Parameters.AddWithValue("@o2", yenievrak);
                komut42.ExecuteNonQuery();
                bgl.baglanti().Close();

                for (int ik = 0; ik <= gridView1.RowCount - 1; ik++)
                {
                    int Donen = 0;

                    object not = gridView1.GetRowCellValue(ik, "Not");
                    object urunadi = gridView1.GetRowCellValue(ik, "Ürün Adı");
                    object stabilite = gridView1.GetRowCellValue(ik, "Stabilite");
                    object mikro = gridView1.GetRowCellValue(ik, "Mikro");
                    object mikroen = gridView1.GetRowCellValue(ik, "MikroEn");
                    object challenge = gridView1.GetRowCellValue(ik, "Challenge");
                    object challengeen = gridView1.GetRowCellValue(ik, "ChallenEn");
                    object stabiliteen = gridView1.GetRowCellValue(ik, "StabiliteEn");
                    object kullanim = gridView1.GetRowCellValue(ik, "Kullanım");
                    object ozellikler = gridView1.GetRowCellValue(ik, "Özellikler");
                    object uyarilar = gridView1.GetRowCellValue(ik, "Uyarılar");
                    object kullanimen = gridView1.GetRowCellValue(ik, "KullanımEn");
                    object uyarilaren = gridView1.GetRowCellValue(ik, "UyarilarEn");
                    object ozellikleren = gridView1.GetRowCellValue(ik, "ÖzelliklerEn");
                    object standart = gridView1.GetRowCellValue(ik, "Standart");
                    object miktar = gridView1.GetRowCellValue(ik, "Miktar");
                    object birim = gridView1.GetRowCellValue(ik, "Birim");
                    object lot = gridView1.GetRowCellValue(ik, "Lot");
                    object uretim = gridView1.GetRowCellValue(ik, "Üretim");
                    object SKT = gridView1.GetRowCellValue(ik, "SKT");
                    object urunen = gridView1.GetRowCellValue(ik, "Ürün Adı En");
                    object barkod = gridView1.GetRowCellValue(ik, "Barkod");
                    object tip = gridView1.GetRowCellValue(ik, "Ürün Tipi");
                    object tip2 = gridView1.GetRowCellValue(ik, "Ürün Grup ID");
                    object gorunum = gridView1.GetRowCellValue(ik, "Görünüm");
                    object gorunumen = gridView1.GetRowCellValue(ik, "GörünümEn");
                    object renk = gridView1.GetRowCellValue(ik, "Renk");
                    object renken = gridView1.GetRowCellValue(ik, "RenkEn");
                    object koku = gridView1.GetRowCellValue(ik, "Koku");
                    object kokuen = gridView1.GetRowCellValue(ik, "KokuEn");
                    object ph = gridView1.GetRowCellValue(ik, "pH");
                    object yogunluk = gridView1.GetRowCellValue(ik, "Yoğunluk");
                    object viskozite = gridView1.GetRowCellValue(ik, "Viskozite");
                    object kaynama = gridView1.GetRowCellValue(ik, "Kaynama");
                    object erime = gridView1.GetRowCellValue(ik, "Erime");
                    object suda = gridView1.GetRowCellValue(ik, "Suda");
                    object sudaen = gridView1.GetRowCellValue(ik, "SudaEn");
                    object diger = gridView1.GetRowCellValue(ik, "Diğer");
                    object digeren = gridView1.GetRowCellValue(ik, "DiğerEn");
                    object hizmetID = gridView1.GetRowCellValue(ik, "HizmetID");
                    object termin = gridView1.GetRowCellValue(ik, "Termin");
                    object hedef = gridView1.GetRowCellValue(ik, "Hedef");

                    SqlCommand komut22 = new SqlCommand("select * from rUGDTip where ID = N'" + tip2 + "' ", bgl.baglanti());
                    SqlDataReader dr22 = komut22.ExecuteReader();
                    while (dr22.Read())
                    {
                        uygulama = dr22["UygulamaBolgesi"].ToString();

                        if (dr22["ADegeri"].ToString() == null || dr22["ADegeri"].ToString() == "")
                        {
                            A = "";
                        }
                        else
                        {

                            A = dr22["ADegeri"].ToString();

                        }
                    }
                    bgl.baglanti().Close();

                    using (SqlConnection conn = bgl.baglanti())
                    {
                        SqlCommand komut12 = new SqlCommand(@"BEGIN TRANSACTION 
                        insert into NKR (Evrak_No,Numune_Adi,Tarih,Tur,Firma_ID,Rapor_Durumu,Aciklama,RaporNo,Revno,Durum) values 
                        (@n1,@n2,@n4,@n5,@n7,@n8,@n9,@n11,@n12,@n14) SET @ID = SCOPE_IDENTITY() ; 
                        COMMIT TRANSACTION", conn);
                        komut12.CommandTimeout = 120;
                        komut12.Parameters.AddWithValue("@n1", yenievrak);
                        komut12.Parameters.AddWithValue("@n2", urunadi ?? (object)DBNull.Value);
                        komut12.Parameters.AddWithValue("@n4", DateTime.Now);
                        komut12.Parameters.AddWithValue("@n5", "Kozmetik");
                        komut12.Parameters.AddWithValue("@n7", gfirma.EditValue);
                        komut12.Parameters.AddWithValue("@n8", "Rapor Beklemede");
                        komut12.Parameters.AddWithValue("@n9", not ?? (object)DBNull.Value);
                        komut12.Parameters.AddWithValue("@n11", yenirapor + ik);
                        komut12.Parameters.AddWithValue("@n12", 0);
                        komut12.Parameters.AddWithValue("@n14", "Aktif");
                        komut12.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        komut12.ExecuteNonQuery();
                        Donen = Convert.ToInt32(komut12.Parameters["@ID"].Value);
                        conn.Close();
                        ykrID = Donen;
                    }

                    using (SqlConnection conn = bgl.baglanti())
                    {                     

                        SqlCommand komut = new SqlCommand(@"BEGIN TRANSACTION 
                        insert into NumuneDetay(Miktar,SeriNo,UretimTarihi,SKT,RaporID,ProjeID,Birim) values(@a2,@a3,@a4,@a5,@a6,@a9,@a10); 
                        insert into Rapor_Durum(RaporNo, Durum, Tarih,TanimlayanID, RaporID) values (@c1,@c2, @c3,@c4,@c5); 
                        insert into rUGDListe(RaporNo,UrunEn, Barkod, Tip1, Tip2,Hedef,Uygulama,A,BirimID, Urun) values(@u0, @u1, @u2, @u3, @u4,@u6, @u5, @u7, @u8, @u9); 
                        insert into rUGDDetay (UrunID, Gorunum, Renk, Koku, pH, Kaynama, Erime, Yogunluk, Viskozite, Suda, Diger, KokuEn, GorunumEn, RenkEn, SudaEn, DigerEn ) values(@d1, @d2, @d3, @d4, @d5, @d6, @d7, @d8, @d9, @d10, @d11, @d13, @d14, @d15, @d16, @d17);
                        COMMIT TRANSACTION", conn);
                        komut.CommandTimeout = 120;
                        komut.Parameters.AddWithValue("@a2", miktar ?? (object)DBNull.Value);
                        komut.Parameters.AddWithValue("@a3", lot ?? (object)DBNull.Value);
                        komut.Parameters.AddWithValue("@a4", uretim ?? (object)DBNull.Value);
                        komut.Parameters.AddWithValue("@a5", SKT ?? (object)DBNull.Value);
                        komut.Parameters.AddWithValue("@a6", ykrID);
                        komut.Parameters.AddWithValue("@a9", (object)gproje.EditValue ?? DBNull.Value);
                        komut.Parameters.AddWithValue("@a10", birim ?? (object)DBNull.Value);
                        komut.Parameters.AddWithValue("@c1", yenirapor + ik);
                        komut.Parameters.AddWithValue("@c2", "Yeni Numune");
                        komut.Parameters.AddWithValue("@c3", DateTime.Now);
                        komut.Parameters.AddWithValue("@c4", Giris.kullaniciID);
                        komut.Parameters.AddWithValue("@c5", ykrID);
                        komut.Parameters.AddWithValue("@u0", ykrID);
                        komut.Parameters.AddWithValue("@u1", urunen ?? (object)DBNull.Value);
                        komut.Parameters.AddWithValue("@u2", barkod ?? (object)DBNull.Value);
                        komut.Parameters.AddWithValue("@u3", tip ?? (object)DBNull.Value);
                        komut.Parameters.AddWithValue("@u4", tip2 ?? (object)DBNull.Value);
                        komut.Parameters.AddWithValue("@u6", hedef ?? (object)DBNull.Value);
                        if (tip2 == null)
                        {
                            komut.Parameters.AddWithValue("@u5", DBNull.Value);
                            komut.Parameters.AddWithValue("@u7", DBNull.Value);
                        }
                        else
                        {
                            komut.Parameters.AddWithValue("@u5", uygulama);
                            komut.Parameters.AddWithValue("@u7", Convert.ToDecimal(A));
                        }
                        komut.Parameters.AddWithValue("@u8", 2);
                        komut.Parameters.AddWithValue("@u9", urunadi ?? (object)DBNull.Value);
                        komut.Parameters.AddWithValue("@d1", ykrID);
                        komut.Parameters.AddWithValue("@d2", gorunum ?? (object)DBNull.Value);
                        komut.Parameters.AddWithValue("@d3", renk ?? (object)DBNull.Value);
                        komut.Parameters.AddWithValue("@d4", koku ?? (object)DBNull.Value);
                        komut.Parameters.AddWithValue("@d5", ph ?? (object)DBNull.Value);
                        komut.Parameters.AddWithValue("@d6", kaynama ?? (object)DBNull.Value);
                        komut.Parameters.AddWithValue("@d7", erime ?? (object)DBNull.Value);
                        komut.Parameters.AddWithValue("@d8", yogunluk ?? (object)DBNull.Value);
                        komut.Parameters.AddWithValue("@d9", viskozite ?? (object)DBNull.Value);
                        komut.Parameters.AddWithValue("@d10", suda ?? (object)DBNull.Value);
                        komut.Parameters.AddWithValue("@d11", diger ?? (object)DBNull.Value);
                        komut.Parameters.AddWithValue("@d13", kokuen ?? (object)DBNull.Value);
                        komut.Parameters.AddWithValue("@d14", gorunumen ?? (object)DBNull.Value);
                        komut.Parameters.AddWithValue("@d15", renken ?? (object)DBNull.Value);
                        komut.Parameters.AddWithValue("@d16", sudaen ?? (object)DBNull.Value);
                        komut.Parameters.AddWithValue("@d17", digeren ?? (object)DBNull.Value);
                        komut.ExecuteNonQuery();
                        conn.Close();

                    }

                    using (SqlConnection conn = bgl.baglanti())
                    {

                        SqlCommand add2 = new SqlCommand(@"BEGIN TRANSACTION
                        insert into rUGDDetay2 (UrunID, Mikro, Challenge, Stabilite, MResim, CResim, SResim, StabiliteNot, MikroNot, MikroNotEn, ChallengeNot, ChallengeNotEn, StabiliteNotEn,
                        Kullanim, Ozellikler, Uyarilar, KullanimEn, UyarilarEn, Ozellikleren )
                        values (@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@o1,@o2,@o3,@o4,@o5,@o6,@o7,@o8,@o9,@o10,@o11) COMMIT TRANSACTION", conn);
                        add2.CommandTimeout = 120;
                        add2.Parameters.AddWithValue("@a1", ykrID);
                        add2.Parameters.AddWithValue("@a2", 1);
                        add2.Parameters.AddWithValue("@a3", 1);
                        add2.Parameters.AddWithValue("@a4", 1);
                        if (standart == null)
                        {
                            add2.Parameters.AddWithValue("@a5", DBNull.Value);
                            add2.Parameters.AddWithValue("@a6", DBNull.Value);
                            add2.Parameters.AddWithValue("@a7", DBNull.Value);
                        }
                        else
                        {
                            if (standart.ToString() == "Evet")
                            {
                                add2.Parameters.AddWithValue("@a5", "9274rm-opirbd.jpg");
                                add2.Parameters.AddWithValue("@a6", "9274rc-opirbdioll4x.jpg");
                                add2.Parameters.AddWithValue("@a7", "rs-nnt29j.jpg");
                            }
                            else
                            {
                                add2.Parameters.AddWithValue("@a5", DBNull.Value);
                                add2.Parameters.AddWithValue("@a6", DBNull.Value);
                                add2.Parameters.AddWithValue("@a7", DBNull.Value);
                            }
                        }
                        add2.Parameters.AddWithValue("@a8", stabilite ?? (object)DBNull.Value);
                        add2.Parameters.AddWithValue("@o1", mikro ?? (object)DBNull.Value);
                        add2.Parameters.AddWithValue("@o2", mikroen ?? (object)DBNull.Value);
                        add2.Parameters.AddWithValue("@o3", challenge ?? (object)DBNull.Value);
                        add2.Parameters.AddWithValue("@o4", challengeen ?? (object)DBNull.Value);
                        add2.Parameters.AddWithValue("@o5", stabiliteen ?? (object)DBNull.Value);
                        add2.Parameters.AddWithValue("@o6", kullanim ?? (object)DBNull.Value);
                        add2.Parameters.AddWithValue("@o7", ozellikler ?? (object)DBNull.Value);
                        add2.Parameters.AddWithValue("@o8", uyarilar ?? (object)DBNull.Value);
                        add2.Parameters.AddWithValue("@o9", kullanimen ?? (object)DBNull.Value);
                        add2.Parameters.AddWithValue("@o10", uyarilaren ?? (object)DBNull.Value);
                        add2.Parameters.AddWithValue("@o11", ozellikleren ?? (object)DBNull.Value);
                        add2.ExecuteNonQuery();
                        conn.Close();
                    }


                    

                    if (hizmetID == null)
                    {

                    }
                    else
                    {
                        using (SqlConnection conn = bgl.baglanti())
                        {

                            SqlCommand komut52 = new SqlCommand(@"BEGIN TRANSACTION 
                            insert into NumuneX1 (RaporID, AnalizID, x3ID, Termin, Durum,HizmetDurum) values 
                            (@n1,@n2,@n3,@n4,@n5,@n6)  ; 
                            COMMIT TRANSACTION", conn);
                            komut52.CommandTimeout = 120;
                            komut52.Parameters.AddWithValue("@n1", ykrID);
                            komut52.Parameters.AddWithValue("@n2", hizmetID ?? (object)DBNull.Value);
                            komut52.Parameters.AddWithValue("@n3", 5038);
                            if (termin == null)
                                komut52.Parameters.AddWithValue("@n4", DBNull.Value);
                            else
                                komut52.Parameters.AddWithValue("@n4", Convert.ToDateTime(termin));
                            komut52.Parameters.AddWithValue("@n5", "Aktif");
                            komut52.Parameters.AddWithValue("@n6", "YeniAnaliz");
                            komut52.ExecuteNonQuery();
                            conn.Close();
                        }

                       
                    }

                   

                }

                MessageBox.Show("Kayıt İşlemi Başarılı!" , "Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (Application.OpenForms["NKR2"] == null)
                {

                }
                else
                {
                    n.listele();
                }
                this.Close();
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata55: " + ex);
            }


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

            yenievrak = maxevrak + 1;

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

                yenirapor = maxrapor + 1;
            }
            bgl.baglanti().Close();

        }

        void evrakkayit()
        {
            




          
        }


    }
}
