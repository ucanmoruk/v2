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

namespace mKYS
{
    public partial class PersonelListesi : Form
    {
        public PersonelListesi()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select k.Ad, k.Soyad, b.Birim, k.Gorev, k.Email, k.Telefon from RootKullanici k inner join RootFirmaBirim b on k.BirimID = b.ID where k.Durum = N'Aktif' order by k.Ad", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;
        }

        int yetki;
        void yetkibul()
        {
            SqlCommand komut21 = new SqlCommand("Select * from KaliteYetki where Gorev = N'" + Anasayfa.gorev + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                yetki = Convert.ToInt32(dr21["Firma"]);
            }
            bgl.baglanti().Close();

            if (yetki == 0 || yetki.ToString() == null)
                barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            else
                barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        private void PersonelListesi_Load(object sender, EventArgs e)
        {
            listele();
           // yetkibul();
        }

        void kbul()
        {
            SqlCommand komut21 = new SqlCommand("Select * from RootKullanici where Ad = N'" + ad + "' and Soyad = N'" + soyad + "' and FirmaID = '" + Anasayfa.firmaID + "'", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                kkod = Convert.ToInt32(dr21["ID"].ToString());
            }
            bgl.baglanti().Close();
        }

        public static int kkod;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            kbul();
            Personel.update = kkod.ToString();
            Personel p = new Personel();
            p.ShowDialog();

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show(ad + " " + soyad + " Kişisini silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (Secim == DialogResult.Yes)
                {
                    SqlCommand komutSil = new SqlCommand("update RootKullanici set Durum=@a1 where Ad = N'" + ad + "' and Soyad = N'"+soyad+"'", bgl.baglanti());
                    komutSil.Parameters.AddWithValue("@a1", "Pasif");
                    komutSil.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Silme işlemi gerçekleşmiştir.");
                    listele();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata2 : " + ex.Message);
            }
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }
        }
        string ad, soyad;

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            ad = dr["Ad"].ToString();
            soyad = dr["Soyad"].ToString();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            kbul();
            Personel.update = kkod.ToString();
            Personel p = new Personel();
            p.ShowDialog();

        }
    }
}
