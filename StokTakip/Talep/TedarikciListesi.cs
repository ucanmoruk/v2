using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakip.Talep
{
    public partial class TedarikciListesi : Form
    {
        public TedarikciListesi()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(" select Row_number() over(order by t.Tur) as 'No', t.Tur as 'Kategori', t.Ad as 'Firma Adı', t.Adres, t.Yetkili, t.Telefon, t.Email, t.Faks, p.Tarih as 'Değerlendirme Tarihi', k.Ad + ' ' + k.Soyad as 'Değerlendiren', p.Puan, p.Durum from StokTedarikci t " +
                " left join StokTedarikciPuan p on t.ID = p.FirmaID   left join StokKullanici k on p.PersonelID = k.ID where t.Durum = 'Aktif' order by t.Tur asc ", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

            this.gridView1.Columns[0].Width = 20;
            this.gridView1.Columns[1].Width = 50;            
            this.gridView1.Columns[4].Width = 50;
            this.gridView1.Columns[5].Width = 50;
            this.gridView1.Columns[6].Width = 50;
            this.gridView1.Columns[7].Width = 50;
            this.gridView1.Columns[8].Width = 50;
            this.gridView1.Columns[10].Width = 30;
            this.gridView1.Columns[11].Width = 40;
        }

        int yetki;
        void yetkibul()
        {
            SqlCommand komut21 = new SqlCommand("Select * from KaliteYetki where Gorev = N'" + Anasayfa.gorev + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                yetki = Convert.ToInt32(dr21["Talep"]);
            }
            bgl.baglanti().Close();

            if (yetki == 0 || yetki.ToString() == null)
            {
                barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else if (yetki == 1)
            {
                barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            } 
            else if (yetki == 2 || yetki == 3)
            {
                barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
              
        }

        private void TedarikciListesi_Load(object sender, EventArgs e)
        {
            listele();
            yetkibul();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //değerlendirme formu yazdır
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string path = "TedarikciListesi.xlsx";
            gridControl1.ExportToXlsx(path);
            Process.Start(path);
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listele();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show(firmad + " firmasını silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (Secim == DialogResult.Yes)
                {
                    // SqlCommand komutSil = new SqlCommand("delete from Firma where ID = @p1", bgl.baglanti());
                    SqlCommand komutSil = new SqlCommand("update StokTedarikci set Durum=@a1 where Ad = N'" + firmad+ "' ", bgl.baglanti());
                    komutSil.Parameters.AddWithValue("@a1", "Pasif");
                    komutSil.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Silme işlemi gerçekleşmiştir.");
                    listele();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata 138 : " + ex.Message);
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

        private void TedarikciListesi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                listele();
            }
        }

        string firmad, kategori;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            firmad = dr["Firma Adı"].ToString();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TedarikciEkle.firma = firmad;

            TedarikciEkle te = new TedarikciEkle();
            te.Show();
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "No" || e.Column.FieldName == "Değerlendirme Tarihi" || e.Column.FieldName == "Puan" || e.Column.FieldName == "Durum")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TedarikciPuan.firma = firmad;

            TedarikciPuan tp = new TedarikciPuan();
            tp.Show();
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            string durum = gridView1.GetRowCellValue(e.RowHandle, "Durum").ToString();
            if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && durum == "Uygun Değil")
                e.Appearance.BackColor = Color.Red;

        }
    }
}
