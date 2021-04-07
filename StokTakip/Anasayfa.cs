using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StokTakip
{
    public partial class Anasayfa : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

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

        private void Anasayfa_Load(object sender, EventArgs e)
        {

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

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TalepYeni ty = new TalepYeni();
            ty.ShowDialog();
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TalepKabul tk = new TalepKabul();
            tk.ShowDialog();
        }
    }
}
