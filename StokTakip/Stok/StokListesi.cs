using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace StokTakip
{
    public partial class StokListesi : Form
    {
        public StokListesi()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select sl.Tur as 'Tür', sl.Kod, sl.Ad, sl.AdEn as 'İngilizce', sl.Cas as 'Cas No', Ozellik, Ambalaj, Saklama as 'Saklama Koşulları',Limit as 'Kritik Limit', sl.Miktar as 'Stok Durumu', Birim from StokListesi sl where Durum = N'Aktif' order by Tur", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;

        }


        private void StokListesi_Load(object sender, EventArgs e)
        {
            listele();
            yetkibul();
        }

        public static string kod;
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                kod = dr["Kod"].ToString();
                StokDetay.urunkod = kod;

                StokDetay sd = new StokDetay();
                sd.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata 1: " + ex);
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

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listele();
        }

        int yetki;
        void yetkibul()
        {
            SqlCommand komut21 = new SqlCommand("Select * from KaliteYetki where Gorev = N'" + Anasayfa.gorev + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                yetki = Convert.ToInt32(dr21["Stok"]);
            }
            bgl.baglanti().Close();

            if (yetki == 0 || yetki.ToString() == null)
                barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            else
                barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show(skod + " stoğu silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (Secim == DialogResult.Yes)
                {
                    // SqlCommand komutSil = new SqlCommand("delete from Firma where ID = @p1", bgl.baglanti());
                    SqlCommand komutSil = new SqlCommand("update StokListesi set Durum=@a1 where Kod = N'"+skod+"'", bgl.baglanti());
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

        private void StokListesi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                listele();
            }
        }

        string skod;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                skod = dr["Kod"].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Aradığınız stok kaydı bulunamadı!", "Oopss!");
            }
          
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                StokDetay.urunkod = skod;
                StokDetay sd = new StokDetay();
                sd.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata SL2: " + ex);
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "Kritik Limit" || e.Column.FieldName == "Stok Durumu" || e.Column.FieldName == "Birim")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            string limit = gridView1.GetRowCellValue(e.RowHandle, "Kritik Limit").ToString();
            string stok = gridView1.GetRowCellValue(e.RowHandle, "Stok Durumu").ToString();

            if (limit == null || limit == "")
            {

            }
            else
            {
                if (e.RowHandle > -1 && e.Column.FieldName == "Stok Durumu" && Convert.ToDecimal(limit) > Convert.ToDecimal(stok))
                    e.Appearance.BackColor = Color.Red;
            }

        }
    }
}
