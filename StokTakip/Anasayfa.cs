using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Menu;
using System.Diagnostics;
using DevExpress.XtraBars;

namespace StokTakip
{
    public partial class Anasayfa : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Anasayfa()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();

        StokListesi sl;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (sl == null || sl.IsDisposed)
            {
                sl = new StokListesi();
                sl.MdiParent = this;
                sl.Show();
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            YeniStok ys = new YeniStok();
            ys.ShowDialog();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StokEkle se = new StokEkle();
            se.ShowDialog();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StokDus sd = new StokDus();
            sd.ShowDialog();
        }

        SonKullanim sk;
        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {       

            if (sk == null || sk.IsDisposed)
            {
                sk = new SonKullanim();
                sk.MdiParent = this;
                sk.Show();
            }
        }

        public static string ad, soyad, path, kpath, gorev, tamad;
        public static int firmaID, birimID;
        void kullanicibul()
        {
            SqlCommand komut21 = new SqlCommand("Select * from StokKullanici where ID = N'" + kullanici + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                birimID= Convert.ToInt32(dr21["BirimID"]);
                firmaID = Convert.ToInt32(dr21["FirmaID"]);
                ad = dr21["Ad"].ToString();
                soyad = dr21["Soyad"].ToString();
                gorev = dr21["Gorev"].ToString();
                lbl_kullanici.Text = ad + " " + soyad; 
                tamad = ad + " " + soyad;
            }
            bgl.baglanti().Close();         

        }

        void firmabul()
        {
            SqlCommand komut21 = new SqlCommand("Select * from StokFirma where ID = N'" + firmaID + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                path = dr21["SPath"].ToString();
                kpath = dr21["KPath"].ToString();
            }
            bgl.baglanti().Close();
        }

        int dokuman, analiz, cihaz, egitim, stok, talep, firma;
        void yetkibul()
        {
            SqlCommand komut21 = new SqlCommand("Select * from KaliteYetki where Gorev = N'" + gorev + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                dokuman = Convert.ToInt32(dr21["Dokuman"]);
                analiz = Convert.ToInt32(dr21["Analiz"]);
                cihaz = Convert.ToInt32(dr21["Cihaz"]);
                stok = Convert.ToInt32(dr21["Stok"]);
                talep = Convert.ToInt32(dr21["Talep"]);
                firma = Convert.ToInt32(dr21["Firma"]);
                egitim = Convert.ToInt32(dr21["Egitim"]);
            }
            bgl.baglanti().Close();

            if (dokuman == 0 || dokuman.ToString() == null)
            {
                ribbonPageGroup18.Visible = false;
                barButtonItem48.Visibility = BarItemVisibility.Never;
            }
            else
                ribbonPageGroup18.Visible = true;

            if (analiz == 0 || analiz.ToString() == null)
                ribbonPageGroup20.Visible = false;
            else
                ribbonPageGroup20.Visible = true;

            if (cihaz == 0 || cihaz.ToString() == null)
                ribbonPageGroup22.Visible = false;
            else
                ribbonPageGroup22.Visible = true;

            if (stok == 0 || stok.ToString() == null)
                ribbonPageGroup2.Visible = false;
            else
                ribbonPageGroup2.Visible = true;

            if (talep == 0 || talep.ToString() == null)
                ribbonPageGroup5.Visible = false;
            else
                ribbonPageGroup5.Visible = true;

            if (egitim == 0 || egitim.ToString() == null)
                ribbonPageGroup23.Visible = false;
            else
                ribbonPageGroup23.Visible = true;

            if (firma == 0 || firma.ToString() == null)
                ribbonPageGroup7.Visible = false;
            else
                ribbonPageGroup7.Visible = true;


        }
    
        void tanitim()
        {
            ribbonPage4.Visible = false;
            ribbonPage5.Visible = false;
            ribbonPage6.Visible = false;
            ribbonPage7.Visible = false;
            ribbonPageGroup6.Visible = false;
            ribbonPageGroup10.Visible = false;
            ribbonPageGroup17.Visible = false;


        }

       // Karsilama kl;
        public static string kullanici;
        private void Anasayfa_Load(object sender, EventArgs e)
        {
            kullanicibul();
            firmabul();
            yetkibul();
            if (Giris.db == "2")
            {
                tanitim();
            }

            //if (kl == null || kl.IsDisposed)
            //{
            //    kl = new Karsilama();
            //    kl.MdiParent = this;
            //    kl.Show();
            //}

        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Sertifika f = new Sertifika();
            f.ShowDialog();
        }

        PersonelListesi pl;
        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (pl == null || pl.IsDisposed)
            {
                pl = new PersonelListesi();
                pl.MdiParent = this;
                pl.Show();
            }
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Personel p = new Personel();
            p.ShowDialog();
        }

        Dokuman.DokumanMaster dm;
        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dm == null || dm.IsDisposed)
            {
                dm = new Dokuman.DokumanMaster();
                dm.MdiParent = this;
                dm.Show();
            }
        }

        private void barButtonItem31_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Dokuman.DokumanEkle dm = new Dokuman.DokumanEkle();
            dm.ShowDialog();
        }

        Analiz.AnalizListesi anal;
        private void barButtonItem33_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (anal == null || anal.IsDisposed)
            {
                anal = new Analiz.AnalizListesi();
                anal.MdiParent = this;
                anal.Show();
            }
        }

        YeniRecete yr;
        public void YeniRecete()
        {
            if (yr == null || yr.IsDisposed)
            {
                yr = new YeniRecete();
                yr.MdiParent = this;
                yr.Show();
            }
        }


        
        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Stok.ReceteSec rec = new Stok.ReceteSec();
            rec.ShowDialog();
        }

        private void barButtonItem35_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Analiz.AnalizYeni any = new Analiz.AnalizYeni();
            any.Show();
        }

        Stok.ReceteListesi rel;
        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (rel == null || rel.IsDisposed)
            {
                rel = new Stok.ReceteListesi();
                rel.MdiParent = this;
                rel.Show();
            }
        }

        private void barButtonItem48_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Raporlar.Aciklama aci = new Raporlar.Aciklama();
            aci.Show();
        }

        private void barButtonItem47_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Raporlar.DokumanMaster.aciklama = "";
            using (Raporlar.frmPrint frm = new Raporlar.frmPrint())
            {
                frm.PrintInvoice();
                frm.ShowDialog();
            }
        }

        private Dokuman.DokumanMaster master; 
        public Anasayfa(Dokuman.DokumanMaster master)
        {
            InitializeComponent();
            this.master = master;
        }

        private void barButtonItem50_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //https://stackoverflow.com/questions/27503064/how-to-add-row-in-datagridview-from-another-form

            string path = "output.xlsx";
            master.gridControl1.ExportToXlsx(path);
            Process.Start(path);

        }

        private void barButtonItem46_ItemClick(object sender, ItemClickEventArgs e)
        {
            Dokuman.DKDEkle de = new Dokuman.DKDEkle();
            de.Show();
        }

        Dokuman.DKDListe del;
        private void barButtonItem45_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (del == null || del.IsDisposed)
            {
                del = new Dokuman.DKDListe();
                del.MdiParent = this;
                del.Show();
            }
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FirmaDetay fd = new FirmaDetay();
            fd.ShowDialog();
        }

        TalepListesi tal;
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tal == null || tal.IsDisposed)
            {
                tal = new TalepListesi();
                tal.MdiParent = this;
                tal.Show();
            }
        }

        TalepYeni ty;

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SertifikaIptal s = new SertifikaIptal();
            s.ShowDialog();
        }

        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Hide();
            Giris g = new Giris();
            g.ShowDialog();
        }

        private void Anasayfa_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void barButtonItem38_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Firma.YetkiListesi yl = new Firma.YetkiListesi();
            yl.ShowDialog();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ty == null || ty.IsDisposed)
            {
                ty = new TalepYeni();
                ty.MdiParent = this;
                ty.Show();
            }
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TalepKabul tk = new TalepKabul();
            tk.ShowDialog();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
