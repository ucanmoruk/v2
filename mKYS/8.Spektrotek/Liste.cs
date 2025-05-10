using DevExpress.XtraGrid;
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
    public partial class Liste : Form
    {
        public Liste()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(@"select t.TeklifNo, t.Tarih, t.Gecerlilik, f.Ad, 
            k.Ad as 'Plasiyer', CONCAT(t.Toplam, ' ',t.Parabirimi) as 'Tutar', t.GenelDurum as 'Teklif Durumu', t.ID from STeklifListe t
            left join RootTedarikci f on t.FirmaID = f.ID
            left join RootKullanici k on t.YetkiliID = k.ID
            where t.Durum='Aktif' 
            order by ID desc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.Columns["ID"].Visible = false;
           // gridView1.Columns["FirmaID"].Visible = false;

            gridView1.Columns["Tutar"].Summary.Clear();
            GridColumnSummaryItem item2 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Toplam Tutar", "€{0:N}");
            gridView1.Columns["Tutar"].Summary.Add(item2);
        }

        void gridduzen()
        {
            this.gridView1.Columns[0].Width = 70;
            this.gridView1.Columns[1].Width = 70;
            this.gridView1.Columns[2].Width = 70;
            this.gridView1.Columns[3].Width = 200;
            this.gridView1.Columns[4].Width = 75;
            this.gridView1.Columns[5].Width = 80;
            this.gridView1.Columns[6].Width = 90;

        }

        private void Liste_Load(object sender, EventArgs e)
        {
            listele();
            gridduzen();
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            string adam = gridView1.GetRowCellValue(e.RowHandle, "Teklif Durumu").ToString();
            if (e.RowHandle > -1 && e.Column.FieldName == "Teklif Durumu" && adam == "Onaylandı")
                e.Appearance.BackColor = Color.LightGreen;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Teklif Durumu" && adam == "Reddedildi")
                e.Appearance.BackColor = Color.PaleVioletRed;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Teklif Durumu" && adam == "Yeni Teklif")
                e.Appearance.BackColor = Color.WhiteSmoke;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Teklif Yazdır
            mKYS.Raporlar.TeklifMS.tID = lID;

            using (mKYS.Raporlar.frmPrint frm = new mKYS.Raporlar.frmPrint())
            {
                frm.TeklifMS();
                frm.ShowDialog();
            }
        }


        Detay fr6;
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //güncelle
            //Detay.detay = lID;
            //Detay d = new Detay();
            //d.Show();

            Detay.detay = lID;
            if (fr6 == null || fr6.IsDisposed)
            {
                fr6 = new Detay();
                fr6.MdiParent = Application.OpenForms.OfType<Anasayfa>().FirstOrDefault();
                fr6.Show();
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ödendi

            DialogResult Secim = new DialogResult();

            Secim = MessageBox.Show(fNo + " numaralı fatura ödendi mi ? ", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (Secim == DialogResult.Yes)
            {
                SqlCommand komutSil = new SqlCommand("update MSListe set Durum=@a1 where ID = @p1", bgl.baglanti());
                komutSil.Parameters.AddWithValue("@p1", lID);
                komutSil.Parameters.AddWithValue("@a1", "Ödendi");
                komutSil.ExecuteNonQuery();
                bgl.baglanti().Close();
                

                //Odeme.mstar = lID;
                ////Odeme.fNo = fNo;
                ////Odeme.ftutar = tutar;
                ////Odeme.fID = firID;
                //Odeme od = new Odeme();
                //od.Show();

                //listele();
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //yenile sayfası
            listele();
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
            if (e.Column.FieldName == "TeklifNo" || e.Column.FieldName == "Tarih" || e.Column.FieldName == "Plasiyer" || e.Column.FieldName == "Gecerlilik" || e.Column.FieldName == "Tutar" || e.Column.FieldName == "Teklif Durumu")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void Liste_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {

                listele();
            }
        }

        string lID, fNo, firID, tutar;

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // ödeme bekliyor
            DialogResult Secim = new DialogResult();

            Secim = MessageBox.Show(fNo + " numaralı teklif red mi edildi ? ", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (Secim == DialogResult.Yes)
            {
                SqlCommand komutSil = new SqlCommand("update STeklifListe set GenelDurum=@a1 where ID = @p1", bgl.baglanti());
                komutSil.Parameters.AddWithValue("@p1", lID);
                komutSil.Parameters.AddWithValue("@a1", "Reddedildi");
                komutSil.ExecuteNonQuery();
                bgl.baglanti().Close();
                listele();
            }

        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //fatura 2 
            //mMacro.Raporlar.MSStarv2.unique = lID;

            //using (mKYS.Raporlar.frmPrint frm = new mKYS.Raporlar.frmPrint())
            //{
            //    frm.MSStar2();
            //    frm.ShowDialog();
            //}
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //kısmi

            DialogResult Secim = new DialogResult();

            Secim = MessageBox.Show(fNo + " numaralı faturada kısmi ödeme mevcut ? ", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (Secim == DialogResult.Yes)
            {
                SqlCommand komutSil = new SqlCommand("update MSListe set GenelDurum=@a1 where ID = @p1", bgl.baglanti());
                komutSil.Parameters.AddWithValue("@p1", lID);
                komutSil.Parameters.AddWithValue("@a1", "Kısmı Ödeme");
                komutSil.ExecuteNonQuery();
                bgl.baglanti().Close();
                listele();
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ödendi

            DialogResult Secim = new DialogResult();

            Secim = MessageBox.Show(fNo + " numaralı teklif onaylandı mı ? ", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (Secim == DialogResult.Yes)
            {
                SqlCommand komutSil = new SqlCommand("update STeklifListe set GenelDurum=@a1 where ID = @p1", bgl.baglanti());
                komutSil.Parameters.AddWithValue("@p1", lID);
                komutSil.Parameters.AddWithValue("@a1", "Onaylandı");
                komutSil.ExecuteNonQuery();
                bgl.baglanti().Close();
                listele();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            lID = dr["ID"].ToString();
            fNo = dr["TeklifNo"].ToString();
            //firID = dr["FirmaID"].ToString();
            //tutar = dr["Toplam Tutar"].ToString();
        }
    }
}
