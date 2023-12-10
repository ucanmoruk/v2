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

namespace mROOT._8.Spektrotek
{
    public partial class SStok : Form
    {
        public SStok()
        {
            InitializeComponent();
        }


        sqlbaglanti bgl = new sqlbaglanti();

        SStokListesi m = (SStokListesi)System.Windows.Forms.Application.OpenForms["SStokListesi"];

        public static string urunkod;

        private void SStok_Load(object sender, EventArgs e)
        {
            if (urunkod == "" || urunkod == null)
            {

            }
            else
            {
                detaybul();
                b_kaydet.Text = "Güncelle";
            }
        }


        private void b_kaydet_Click(object sender, EventArgs e)
        {
            if (b_kaydet.Text == "Güncelle")
            {
                guncelle();
                MessageBox.Show("Güncelleme başarılı!", "Oooppss!");
            }
            else
            {
                kaydet();
                MessageBox.Show("Kaydetme başarılı!", "Oooppss!");
                temizle();
            }

            if (Application.OpenForms["SStokListesi"] == null)
            {

            }
            else
            {
                m.listele();
            }

        }

        void detaybul()
        {
            SqlCommand komutID = new SqlCommand("Select * From SStokListe where ID= N'" + urunkod + "'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                t_kod.Text = drI["Kod"].ToString();
                t_ad.Text = drI["Ad"].ToString();
                t_barkod.Text = drI["Barkod"].ToString();
                t_stok.Text = drI["Stok"].ToString();
                c_kategori.Text = drI["Kategori"].ToString();
                tmarka.Text = drI["Marka"].ToString();
                c_miktar.Text = drI["Birim"].ToString();
                t_lot.Text = drI["Lot"].ToString();
                memoEdit1.Text = drI["Notlar"].ToString();
                tsatis.Text = drI["Satis"].ToString();
                tkdv.Text = drI["KDV"].ToString();
                tpara.Text = drI["ParaBirimi"].ToString();

            }
            bgl.baglanti().Close();
        }

        void kaydet()
        {
            SqlCommand add = new SqlCommand(@"insert into SStokListe (Kategori, Kod, Barkod, Ad, Marka, Stok, Birim, 
            Durum, Ekleyen, Tarih, Lot, Notlar, Satis, ParaBirimi, KDV)
            values (@a1, @a2, @a3, @a4, @a5, @a6, @a7, @a8, @a9, @a10, @a11, @a12, @a13, @a14, @a15)", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", c_kategori.Text);
            add.Parameters.AddWithValue("@a2", t_kod.Text);
            add.Parameters.AddWithValue("@a3", t_barkod.Text);
            add.Parameters.AddWithValue("@a4", t_ad.Text);
            add.Parameters.AddWithValue("@a5", tmarka.Text);
            if(t_stok.Text == "" || t_stok.Text == null)
              add.Parameters.AddWithValue("@a6", DBNull.Value);
            else
              add.Parameters.AddWithValue("@a6", Convert.ToDecimal(t_stok.Text));
            add.Parameters.AddWithValue("@a7", c_miktar.Text);
            add.Parameters.AddWithValue("@a8", "Aktif");
            add.Parameters.AddWithValue("@a9", Anasayfa.kullanici);
            add.Parameters.AddWithValue("@a10", DateTime.Now);
            add.Parameters.AddWithValue("@a11", t_lot.Text);
            add.Parameters.AddWithValue("@a12", memoEdit1.Text);
            if (tsatis.Text == "" || tsatis.Text == null)
                add.Parameters.AddWithValue("@a13", DBNull.Value);
            else
                add.Parameters.AddWithValue("@a13", Convert.ToDecimal(tsatis.Text));
            if (tpara.Text == "" || tpara.Text == null)
                add.Parameters.AddWithValue("@a14", DBNull.Value);
            else
                add.Parameters.AddWithValue("@a14", tpara.Text);
            if (tkdv.Text == "" || tkdv.Text == null)
                add.Parameters.AddWithValue("@a15", DBNull.Value);
            else
                add.Parameters.AddWithValue("@a15", Convert.ToDecimal(tkdv.Text));
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        void guncelle()
        {
            SqlCommand add = new SqlCommand(@"update SStokListe set 
            Kategori=@a1, Kod=@a2, Barkod=@a3, Ad=@a4, Marka=@a5, Stok=@a6, Birim=@a7, Ekleyen=@a9, 
            Tarih=@a10, Lot=@a11, Notlar=@a12, Satis=@a13, ParaBirimi=@a14, KDV=@a15 where ID = '"+urunkod+"' ", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", c_kategori.Text);
            add.Parameters.AddWithValue("@a2", t_kod.Text);
            add.Parameters.AddWithValue("@a3", t_barkod.Text);
            add.Parameters.AddWithValue("@a4", t_ad.Text);
            add.Parameters.AddWithValue("@a5", tmarka.Text);
            add.Parameters.AddWithValue("@a6", Convert.ToDecimal(t_stok.Text));
            add.Parameters.AddWithValue("@a7", c_miktar.Text);
            //add.Parameters.AddWithValue("@a8", "Aktif");
            add.Parameters.AddWithValue("@a9", Anasayfa.kullanici);
            add.Parameters.AddWithValue("@a10", DateTime.Now);
            add.Parameters.AddWithValue("@a11", t_lot.Text);
            add.Parameters.AddWithValue("@a12", memoEdit1.Text);
            add.Parameters.AddWithValue("@a13", Convert.ToDecimal(tsatis.Text));
            add.Parameters.AddWithValue("@a14", tpara.Text);
            add.Parameters.AddWithValue("@a15", Convert.ToDecimal(tkdv.Text));
            //if (String.IsNullOrEmpty(gridLookUpEdit2.EditValue.ToString()))
            //{
            //    add.Parameters.AddWithValue("@a10", 2);
            //}
            //else
            //{
            //    add.Parameters.AddWithValue("@a10", gridLookUpEdit2.EditValue);
            //}
            add.ExecuteNonQuery();
            bgl.baglanti().Close();

            logguncelle();
        }

        void logguncelle()
        {
            SqlCommand add = new SqlCommand(@"insert into SStokListesilog (Kategori, Kod, Barkod, Ad, Marka, Stok, Birim, 
            Durum, Lot, Notlar, Satis, ParaBirimi, KDV, Logtur, LogTarih, LogID)
            values (@a1, @a2, @a3, @a4, @a5, @a6, @a7, @a8, @a11, @a12, @a13, @a14, @a15, @a16,@a17,@a18)", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", c_kategori.Text);
            add.Parameters.AddWithValue("@a2", t_kod.Text);
            add.Parameters.AddWithValue("@a3", t_barkod.Text);
            add.Parameters.AddWithValue("@a4", t_ad.Text);
            add.Parameters.AddWithValue("@a5", tmarka.Text);
            add.Parameters.AddWithValue("@a6", Convert.ToDecimal(t_stok.Text));
            add.Parameters.AddWithValue("@a7", c_miktar.Text);
            add.Parameters.AddWithValue("@a8", "Aktif");
            //add.Parameters.AddWithValue("@a9", Anasayfa.kullanici);
            //add.Parameters.AddWithValue("@a10", DateTime.Now);
            add.Parameters.AddWithValue("@a11", t_lot.Text);
            add.Parameters.AddWithValue("@a12", memoEdit1.Text);
            add.Parameters.AddWithValue("@a13", Convert.ToDecimal(tsatis.Text));
            add.Parameters.AddWithValue("@a14", tpara.Text);
            add.Parameters.AddWithValue("@a15", Convert.ToDecimal(tkdv.Text));
            add.Parameters.AddWithValue("@a16", "Update");
            add.Parameters.AddWithValue("@a17", DateTime.Now);
            add.Parameters.AddWithValue("@a18", Anasayfa.kullanici);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        private void SStok_FormClosed(object sender, FormClosedEventArgs e)
        {
            urunkod = null;
        }

        void temizle()
        {
            t_kod.Text = "";
            t_barkod.Text = "";
            c_kategori.Text = "";
            tmarka.Text = "";
            t_ad.Text = "";
            t_stok.Text = "";
            t_lot.Text = "";
            c_miktar.Text = "";
            tsatis.Text = "";
            tpara.Text = "";
            tkdv.Text = "";
            memoEdit1.Text = "";
        }

        private void c_miktar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
