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

namespace mKYS.Talep
{
    public partial class MaliyetListesi : Form
    {
        public MaliyetListesi()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(" select m.TalepNo, m.StokKod, l.Ad ,m.Tarih, d.Miktar, d.Birim, m.BirimFiyat, m.TL, m.Dolar,m.Euro , t.Ad as 'Tedarikçi' from StokMaliyet m  " +
                " inner join StokListesi l on m.StokKod = l.Kod " +
                " inner join StokTedarikci t on m.TedarikciID = t.ID " +
                " inner join StokTalepDetay d on m.StokKod = d.StokKod order by m.TalepNo desc", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;

            this.gridView1.Columns[0].Width = 30;
            this.gridView1.Columns[1].Width = 50;
            this.gridView1.Columns[2].Width = 150;
            this.gridView1.Columns[3].Width = 50;
            this.gridView1.Columns[4].Width = 50;
            this.gridView1.Columns[5].Width = 50;
            this.gridView1.Columns[6].Width = 50;
            this.gridView1.Columns[7].Width = 50;
            this.gridView1.Columns[8].Width = 50;
            this.gridView1.Columns[9].Width = 75;
            this.gridView1.Columns[10].Width = 150;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MaaliyetEkle.talepno = tlpno;
            MaaliyetEkle.gelis = kod;

            var mfrm = (Anasayfa)Application.OpenForms["Anasayfa"];
            if (mfrm != null)
                mfrm.mekle();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show(tlpno + " numaralı talepten "+kod+ "nolu stoğu silmek istediğinizden emin misiniz ? ", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (Secim == DialogResult.Yes)
                {
                    // SqlCommand komutSil = new SqlCommand("delete from Firma where ID = @p1", bgl.baglanti());
                    SqlCommand komutSil = new SqlCommand("update StokMaliyet set Durum=@a1 where StokKod = N'" + kod + "' and TalepNo='"+tlpno+"'", bgl.baglanti());
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

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "TalepNo" || e.Column.FieldName == "StokKod" || e.Column.FieldName == "Miktar" || e.Column.FieldName == "Birim" || e.Column.FieldName == "TL" || e.Column.FieldName == "Dolar" || e.Column.FieldName == "Euro" || e.Column.FieldName == "BirimFiyat")
            {
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
        }

        string kod, tlpno;

        private void MaliyetListesi_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                kod = dr["StokKod"].ToString();
                tlpno = dr["TalepNo"].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Aradığınız stok bulunamamıştır!", "Ooppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}
