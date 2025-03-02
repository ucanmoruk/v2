﻿using DevExpress.XtraReports.UI;
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
using mKYS.Dokuman;
using mKYS.Talep;
using mKYS.Duyuru;

namespace mKYS
{
    public partial class Babasayfa : DevExpress.XtraBars.ToolbarForm.ToolbarForm
    {
        public Babasayfa()
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
            ys.Show();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StokEkle se = new StokEkle();
            se.Show();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StokDus sd = new StokDus();
            sd.Show();
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
            SqlCommand komut21 = new SqlCommand("Select * from RootKullanici where ID = N'" + kullanici + "' ", bgl.baglanti());
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
                 {
                ribbonPageGroup2.Visible = false;
                ribbonPageGroup6.Visible = false;
                }                
            else
            {
                ribbonPageGroup2.Visible = true;
                ribbonPageGroup6.Visible = true;
            }
               


            if (talep == 0 || talep.ToString() == null)
            {
                ribbonPageGroup5.Visible = false;
                ribbonPageGroup8.Visible = false;
            }
            else if (talep == 1)
            {
                ribbonPageGroup8.Visible = false;
                ribbonPageGroup5.Visible = true;
            }
            else if (talep == 2)
            {
                ribbonPageGroup5.Visible = true;
                ribbonPageGroup8.Visible = true;
                ribbonPageGroup17.Visible = true;
            }
            else if (talep == 3 )
            {
                ribbonPageGroup10.Visible = true;
                ribbonPageGroup27.Visible = true;
                ribbonPageGroup5.Visible = true;
                ribbonPageGroup8.Visible = true;
                ribbonPageGroup17.Visible = true;
            }
                

            if (egitim == 0 || egitim.ToString() == null)
                ribbonPageGroup23.Visible = false;
            else
                ribbonPageGroup23.Visible = true;

            if (firma == 0 || firma.ToString() == null)
                ribbonPageGroup7.Visible = false;
            else
                ribbonPageGroup7.Visible = true;


        }
    
        DuyuruListe kl;
        public static string kullanici;
        private void Anasayfa_Load(object sender, EventArgs e)
        {
            kullanicibul();
          //  firmabul();
         //   yetkibul();


            ribbonPageGroup25.AllowTextClipping = false;
            ribbonPageGroup26.AllowTextClipping = false;
            ribbonPageGroup9.AllowTextClipping = false;

            if (kl == null || kl.IsDisposed)
            {
                kl = new DuyuruListe();
                kl.MdiParent = this;
                kl.Show();
              //  barButtonItem59.Visibility = BarItemVisibility.Always;
            }

        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Sertifika f = new Sertifika();
            f.Show();
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
            Dokuman.DokumanYeni dy = new DokumanYeni();
            dy.Show();
        }

        Talep.MaaliyetEkle me;
        public void mekle()
        {
            if (me == null || me.IsDisposed)
            {
                me = new Talep.MaaliyetEkle();
                me.MdiParent = this;
                me.Show();
            }
        }

        public void eklemebuton()
        {
            if (btn_ekle.Visibility == BarItemVisibility.Never)
            {
                btn_ekle.Visibility = BarItemVisibility.Always;
                barButtonItem21.Enabled = false;
            }
            else
            {
                btn_ekle.Visibility = BarItemVisibility.Never;
                barButtonItem21.Enabled = true;
            }
        }

        YeniRecete yer;
        public void YeniRecete()
        {
            if (yer == null || yer.IsDisposed)
            {
                yer = new YeniRecete();
                yer.MdiParent = this;
                yer.Show();
            }
        }

        TalepYeni tay;
        public void talepyeni()
        {
            if (tay == null || tay.IsDisposed)
            {
                tay = new TalepYeni();
                tay.MdiParent = this;
                tay.Show();
            }
        }
        
        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Stok.ReceteSec rec = new Stok.ReceteSec();
            rec.ShowDialog();
        }

        private void barButtonItem35_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Analiz.AnalizYeni any = new Analiz.AnalizYeni();
            //any.Show();
        }

      //  Stok.ReceteListesi rel;
        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (rel == null || rel.IsDisposed)
            //{
            //    rel = new Stok.ReceteListesi();
            //    rel.MdiParent = this;
            //    rel.Show();
            //}
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
        public Babasayfa(Dokuman.DokumanMaster master)
        {
            InitializeComponent();
            this.master = master;
        }

        private void barButtonItem50_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var mfrm = (DokumanMaster)Application.OpenForms["DokumanMaster"];
            if (mfrm != null)
                mfrm.excelaktar();

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
          //  btn_kontrol.Visibility = BarItemVisibility.Always;

        }

        public void gizle()
        {
            btn_kontrol.Visibility = BarItemVisibility.Never;
        }

        public void ogizle()
        {
            barButtonItem59.Visibility = BarItemVisibility.Never;
        }

        DKDListe m = (DKDListe)System.Windows.Forms.Application.OpenForms["DKDListe"];
        private void btn_kontrol_ItemClick(object sender, ItemClickEventArgs e)
        {
            var mfrm = (DKDListe)Application.OpenForms["DKDListe"];
            if (mfrm != null)
                mfrm.kontrolet();

        }



        private void barButtonItem51_ItemClick(object sender, ItemClickEventArgs e)
        {
            var mfrm = (DKDListe)Application.OpenForms["DKDListe"];
            if (mfrm != null)
                mfrm.excelaktar();
        }

     

        Talep.TedarikciListesi tl;
        private void barButtonItem30_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (tl == null || tl.IsDisposed)
            {
                tl = new Talep.TedarikciListesi();
                tl.MdiParent = this;
                tl.Show();
            }
        }

        private void barButtonItem53_ItemClick(object sender, ItemClickEventArgs e)
        {
            Talep.TedarikciEkle te = new Talep.TedarikciEkle();
            te.Show();
        }

        private void barButtonItem21_ItemClick(object sender, ItemClickEventArgs e)
        {
            Talep.TalepMaliyet.gelis = "Genel";
            TalepMaliyet me = new TalepMaliyet();
            me.Show();
        }

        private void btn_ekle_ItemClick(object sender, ItemClickEventArgs e)
        {
            //DialogResult cikis = new DialogResult();
            //cikis = MessageBox.Show("Teslim tarihi ve tedarikçi firma seçmediğiniz kayıtların kaydı yapılmayacaktır. Onaylıyor musunuz ?", "Uyarı", MessageBoxButtons.YesNo);
            //if (cikis == DialogResult.Yes)
            //{

            //    var mfrm = (MaaliyetEkle)Application.OpenForms["MaaliyetEkle"];
            //    if (mfrm != null)
            //        mfrm.kaydetme();

            //}

        }

        MaliyetListesi ml;
        private void barButtonItem20_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ml == null || ml.IsDisposed)
            {
                ml = new MaliyetListesi();
                ml.MdiParent = this;
                ml.Show();
            }
        }

        private void barButtonItem57_ItemClick(object sender, ItemClickEventArgs e)
        {
            Duyuru.DuyuruYeni dy = new Duyuru.DuyuruYeni();
            dy.ShowDialog();
        }

        Duyuru.DuyuruListe dul;
        private void barButtonItem56_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dul == null || dul.IsDisposed)
            {
                dul = new Duyuru.DuyuruListe();
                dul.MdiParent = this;
                dul.Show();
            }

           // barButtonItem59.Visibility = BarItemVisibility.Always;
        }

        private void barButtonItem59_ItemClick(object sender, ItemClickEventArgs e)
        {
            var mfrm = (DuyuruListe)Application.OpenForms["DuyuruListe"];
            if (mfrm != null)
                mfrm.okundu();
        }

        Duyuru.DuyuruEx dex;
        private void barButtonItem58_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dex == null || dex.IsDisposed)
            {
                dex = new DuyuruEx();
                dex.MdiParent = this;
                dex.Show();
            }
        }

        Duyurularim dum;
        private void barButtonItem60_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dum == null || dum.IsDisposed)
            {
                dum = new Duyurularim();
                dum.MdiParent = this;
                dum.Show();
            }
        }

        Cihaz.CihazListesi cl;
        private void barButtonItem28_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (cl == null || cl.IsDisposed)
            {
                cl = new Cihaz.CihazListesi();
                cl.MdiParent = this;
                cl.Show();
            }
        }

        Cihaz.KalibrasyonListesi kli;
        private void barButtonItem29_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (kli == null || kli.IsDisposed)
            {
                kli = new Cihaz.KalibrasyonListesi();
                kli.MdiParent = this;
                kli.Show();
            }
        }

        Cihaz.CMaliyetListe cml;
        private void barButtonItem61_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (cml == null || cml.IsDisposed)
            {
                cml = new Cihaz.CMaliyetListe();
                cml.MdiParent = this;
                cml.Show();
            }
        }

        private void barButtonItem62_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cihaz.CihazMaliyet cm = new Cihaz.CihazMaliyet();
            cm.Show();
        }

        Cihaz.KalibrasyonSartname ks;
        private void barButtonItem63_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ks == null || ks.IsDisposed)
            {
                ks = new Cihaz.KalibrasyonSartname();
                ks.MdiParent = this;
                ks.Show();
            }
        }


       // Analiz.ValidasyonListesi val;
        private void barButtonItem36_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (val == null || val.IsDisposed)
            //{
            //    val = new Analiz.ValidasyonListesi();
            //    val.MdiParent = this;
            //    val.Show();
            //}
        }

        private void barButtonItem65_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Analiz.YeniPlan ve = new Analiz.YeniPlan();
            //ve.Show();
        }

       // Analiz.YeniPlanListesi vpl;
        private void barButtonItem66_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (vpl == null || vpl.IsDisposed)
            //{
            //    vpl = new Analiz.YeniPlanListesi();
            //    vpl.MdiParent = this;
            //    vpl.Show();
            //}
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void barButtonItem27_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (Raporlar.frmPrint frm = new Raporlar.frmPrint())
            {
                frm.CihazListesi();
                frm.ShowDialog();
            }
        }

        private void barButtonItem34_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (Raporlar.frmPrint frm = new Raporlar.frmPrint())
            {
                frm.AnalizListesi();
                frm.ShowDialog();
            }
        }

        private void barButtonItem67_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (Raporlar.frmPrint frm = new Raporlar.frmPrint())
            {
                frm.PersonelListesi();
                frm.ShowDialog();
            }
        }

        Cihaz.BakimDetay de;
        private void barButtonItem68_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (de == null || de.IsDisposed)
            {
                de = new Cihaz.BakimDetay();
                de.MdiParent = this;
                de.Show();
            }
        }

        Analiz.AnalizListesi anal;
        private void barButtonItem69_ItemClick(object sender, ItemClickEventArgs e)
        {

            
            if (anal == null || anal.IsDisposed)
            {
                anal = new Analiz.AnalizListesi();
                anal.MdiParent = this;
                anal.Show();
            }
            
        }

        private void barButtonItem70_ItemClick(object sender, ItemClickEventArgs e)
        {
            Stok.ReceteDus rd = new Stok.ReceteDus();
            rd.Show();
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FirmaDetay fd = new FirmaDetay();
            fd.Show();
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
            Cihaz.CihazEkle ce = new Cihaz.CihazEkle();
            ce.Show();
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
            tk.Show();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
