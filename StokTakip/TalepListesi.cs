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

namespace StokTakip
{
    public partial class TalepListesi : Form
    {
        public TalepListesi()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select l.TalepNo, l.Olusturma as 'Talep Tarihi', k.Ad + ' ' + k.Soyad as 'Talep Oluşturan', l.Durum, z.Ad + ' ' + z.Soyad as 'Değerlendiren', l.Onaylama as 'Değerlendirme Tarihi', b.Ad + ' ' + b.Soyad as 'İşleme Alan', l.Isleme as 'İşleme Alınma Tarihi' from StokTalepListe l " +
                "left join StokKullanici k on l.TalepEdenID= k.ID left join StokKullanici z on l.OnaylayanID = z.ID left join StokKullanici b on l.IsleyenID = b.ID " +
                "where l.Aktif <> N'Pasif' order by l.TalepNo desc", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TalepDetay.TalepNo = talepno;
            TalepDetay td = new TalepDetay();
            td.ShowDialog();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult Secim = new DialogResult();

            Secim = MessageBox.Show(talepno + " numaralı talebi işleme alıyorsunuz?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (Secim == DialogResult.Yes)
            {
                DateTime tarih = DateTime.Now;

                SqlCommand add2 = new SqlCommand("update StokTalepListe set IsleyenID=@o1, Isleme=@o2, Durum=@o3 where TalepNo = '" + talepno + "'", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", Anasayfa.kullanici);
                add2.Parameters.AddWithValue("@o2", tarih);
                add2.Parameters.AddWithValue("@o3", "İşleme Alındı");
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();

                listele();
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult Secim = new DialogResult();

            Secim = MessageBox.Show(talepno + " numaralı talebi iptal ediyorsunuz?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (Secim == DialogResult.Yes)
            {
                DateTime tarih = DateTime.Now;

                SqlCommand add2 = new SqlCommand("update StokTalepListe set Aktif=@o1 where TalepNo = '" + talepno + "'", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", "Pasif");
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();

                listele();
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult Secim = new DialogResult();

            Secim = MessageBox.Show(talepno + " numaralı talebi onaylıyorsunuz?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (Secim == DialogResult.Yes)
            {
                DateTime tarih = DateTime.Now;

                SqlCommand add2 = new SqlCommand("update StokTalepListe set OnaylayanID=@o1, Onaylama=@o2, Durum=@o3 where TalepNo = '"+talepno+"'", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", Anasayfa.kullanici);
                add2.Parameters.AddWithValue("@o2", tarih);
                add2.Parameters.AddWithValue("@o3", "Talep Onaylandı");
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();

                listele();
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            DialogResult Secim = new DialogResult();

            Secim = MessageBox.Show(talepno + " numaralı talebi reddediyorsunuz?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (Secim == DialogResult.Yes)
            {
                DateTime tarih = DateTime.Now;

                SqlCommand add2 = new SqlCommand("update StokTalepListe set OnaylayanID=@o1, Onaylama=@o2, Durum=@o3 where TalepNo = '" + talepno + "'", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", Anasayfa.kullanici);
                add2.Parameters.AddWithValue("@o2", tarih);
                add2.Parameters.AddWithValue("@o3", "Talep Reddedildi");
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();

                listele();
            }
        }

        private void TalepListesi_Load(object sender, EventArgs e)
        {
            listele();
            this.gridView1.Columns[0].Width = 30;
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "TalepNo" || e.Column.FieldName == "Talep Tarihi" || e.Column.FieldName == "Değerlendirme Tarihi" || e.Column.FieldName == "İşleme Alınma Tarihi" )
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }
        }

        string talepno;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            talepno = dr["TalepNo"].ToString();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            talepno = dr["TalepNo"].ToString();
            TalepDetay.TalepNo = talepno;
            TalepDetay td = new TalepDetay();
            td.ShowDialog();
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            string adam = gridView1.GetRowCellValue(e.RowHandle, "Durum").ToString();
            if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && adam == "Talep Oluşturuldu")
                e.Appearance.BackColor = Color.Salmon;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && adam == "Talep Reddedildi")
                e.Appearance.BackColor = Color.Red;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && adam == "Talep Onaylandı")
                e.Appearance.BackColor = Color.Turquoise;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && adam == "İşleme Alındı")
                e.Appearance.BackColor = Color.LightGreen;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && adam == "Tamamlandı")
                e.Appearance.BackColor = Color.Green;
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TalepKabul.TalepNo = talepno;
            TalepKabul tk = new TalepKabul();
            tk.ShowDialog();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            DialogResult Secim = new DialogResult();

            Secim = MessageBox.Show(talepno + " numaralı talebi tamamladınız mı?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (Secim == DialogResult.Yes)
            {
                DateTime tarih = DateTime.Now;

                SqlCommand add2 = new SqlCommand("update StokTalepListe set IsleyenID=@o1, Isleme=@o2, Durum=@o3 where TalepNo = '" + talepno + "'", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", Anasayfa.kullanici);
                add2.Parameters.AddWithValue("@o2", tarih);
                add2.Parameters.AddWithValue("@o3", "Tamamlandı");
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();

                listele();
            }
        }
    }
}
