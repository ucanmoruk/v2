using DevExpress.XtraGrid;
using mKYS;
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

namespace mROOT._7.Muhasebe
{
    public partial class IslemListesi : Form
    {
        public IslemListesi()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        private void IslemListesi_Load(object sender, EventArgs e)
        {
            listele();
        }

        public void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select f.ID, f.Tarih, f.oTarih as 'Ödeme Tarihi', f.Tur, f.Kategori, f.FaturaNo, t.Ad, f.Tutar as 'Tutar (₺)', f.KDV as 'KDV (₺)', f.Toplam as 'Toplam (₺)', f.Banka, f.Odeme as 'Ödeme', f.Aciklama as 'Açıklama'  from RootFatura f 
            left join RootTedarikci t on f.Firma = t.ID
            order by f.Tarih desc ", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.Columns["ID"].Visible = false;
            //this.gridView1.Columns[0].Width = 35;
            this.gridView1.Columns[1].Width = 45;
            this.gridView1.Columns[2].Width = 45;
            this.gridView1.Columns[3].Width = 45;
            this.gridView1.Columns[4].Width = 75;
            this.gridView1.Columns[5].Width = 75;
            this.gridView1.Columns[6].Width = 100;
            this.gridView1.Columns[7].Width = 50;
            this.gridView1.Columns[8].Width = 50;
            this.gridView1.Columns[9].Width = 50;
            this.gridView1.Columns[10].Width = 75;
            this.gridView1.Columns[11].Width = 75;
            this.gridView1.Columns[12].Width = 100;

            GridGroupSummaryItem item = new GridGroupSummaryItem();
            item.FieldName = "Toplam (₺)";
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            item.DisplayFormat = "/ Toplam = {0:c2}";
            gridView1.GroupSummary.Add(item);
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }

        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                listele();
            }
        }

        string iID, tur;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                iID = dr["ID"].ToString();
                tur = dr["Tur"].ToString();

            }
            catch (Exception Ex)
            {

                MessageBox.Show("Aradığınız kayıt bulunamadı!");
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            iID = dr["ID"].ToString();

            IslemEkle.iID = iID;
            IslemEkle ie = new IslemEkle();
            ie.Show();
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "Tarih" || e.Column.FieldName == "Tur" || e.Column.FieldName == "Tutar" || e.Column.FieldName == "KDV" || e.Column.FieldName == "Toplam")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            string durum = gridView1.GetRowCellValue(e.RowHandle, "Ödeme").ToString();
            if (e.RowHandle > -1 && e.Column.FieldName == "Ödeme" && durum == "Ödeme Bekliyor")
                e.Appearance.BackColor = Color.OrangeRed;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Ödeme" && durum == "Ödendi")
                e.Appearance.BackColor = Color.LightGreen;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Ödeme" && durum == "Fatura Kesilecek")
                e.Appearance.BackColor = Color.LightSalmon;
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listele();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IslemEkle.iID = iID;
            IslemEkle ie = new IslemEkle();
            ie.Show();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string path = "GelirGider.xlsx";
            gridControl1.ExportToXlsx(path);
            Process.Start(path);
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show(iID +" "+tur + " işlemini silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (Secim == DialogResult.Yes)
                {
                    // SqlCommand komutSil = new SqlCommand("delete from Firma where ID = @p1", bgl.baglanti());
                    SqlCommand komutSil = new SqlCommand("update RootFatura set Durum=@a1 where ID = N'" + iID + "' ", bgl.baglanti());
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
    }
}
