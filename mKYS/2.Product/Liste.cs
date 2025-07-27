using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
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

namespace mROOT._2.Product
{
    public partial class TeklifListe : Form
    {
        public TeklifListe()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(@"select t.TeklifNo as 'Sipariş No', t.Tur as 'Tür', t.Tarih, f.Ad as 'Firma', 
            k.Ad as 'Plasiyer', t.Toplam as 'Tutar', t.Parabirimi, t.GenelDurum as 'Sipariş Durumu', t.TeslimTarihi, t.FaturaNo, t.FaturaDurumu as 'Ödeme', t.ID from rTeklifListe t
            left join RootTedarikci f on t.FirmaID = f.ID
            left join RootKullanici k on t.YetkiliID = k.ID
            where t.Durum='Aktif' 
            order by ID desc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.Columns["ID"].Visible = false;
           // gridView1.Columns["FirmaID"].Visible = false;

            gridView1.Columns["Tutar"].Summary.Clear();
            GridColumnSummaryItem item2 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Tutar", "{0:N} ₺");
            gridView1.Columns["Tutar"].Summary.Add(item2);

            gridView1.Columns["Tutar"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns["Tutar"].DisplayFormat.FormatString = "n2"; // ya da "N2"

        }

        void gridduzen()
        {
            this.gridView1.Columns[0].Width = 50;
            this.gridView1.Columns[1].Width = 55;
            this.gridView1.Columns[2].Width = 55;
            this.gridView1.Columns[3].Width = 220;
            this.gridView1.Columns[4].Width = 75;
            this.gridView1.Columns[5].Width = 60;
            this.gridView1.Columns[6].Width = 30;
            this.gridView1.Columns[7].Width = 90;
            this.gridView1.Columns[8].Width = 50;

        }

        private void Liste_Load(object sender, EventArgs e)
        {
            listele();
            gridduzen();
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            string adam = gridView1.GetRowCellValue(e.RowHandle, "Sipariş Durumu").ToString();
            string odeme = gridView1.GetRowCellValue(e.RowHandle, "Ödeme").ToString();
            if (e.RowHandle > -1 && e.Column.FieldName == "Sipariş Durumu" && adam == "Gönderildi")
                e.Appearance.BackColor = Color.LightGreen;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Sipariş Durumu" && adam == "İptal")
                e.Appearance.BackColor = Color.PaleVioletRed;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Sipariş Durumu" && adam == "Teslim Edildi")
                e.Appearance.BackColor = Color.Green;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Sipariş Durumu" && adam == "Teklif İletildi")
                e.Appearance.BackColor = Color.BlueViolet;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Sipariş Durumu" && adam == "Hazırlanıyor")
                e.Appearance.BackColor = Color.Orchid;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Sipariş Durumu" && adam == "Yeni Sipariş")
                e.Appearance.BackColor = Color.Wheat;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Ödeme" && odeme == "Ödeme Bekliyor")
                e.Appearance.BackColor = Color.DarkOrange;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Ödeme" && odeme == "Ödendi")
                e.Appearance.BackColor = Color.Green;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Ödeme" && odeme == "Taksitli Ödeme")
                e.Appearance.BackColor = Color.HotPink;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Teklif Yazdır
            mKYS.Raporlar.SiparisFormu.tID = lID;

            using (mKYS.Raporlar.frmPrint frm = new mKYS.Raporlar.frmPrint())
            {
                frm.SiparisFormu();
                frm.ShowDialog();
            }
        }


        TeklifDetay fr6;
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //güncelle
            //Detay.detay = lID;
            //Detay d = new Detay();
            //d.Show();

            TeklifDetay.detay = lID;
            if (fr6 == null || fr6.IsDisposed)
            {
                fr6 = new TeklifDetay();
                fr6.MdiParent = Application.OpenForms.OfType<Anasayfa>().FirstOrDefault();
                fr6.Show();
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ödendi

            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {

                string id = gridView1.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                string o2;
                o2 = gridView1.GetRowCellValue(y, "ID").ToString();

                //       o2 = gridView3.GetRowCellValue(i, "ID").ToString();
                SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                    "update rTeklifListe set FaturaDurumu=@o1 where ID = @o3; " +
                    "COMMIT TRANSACTION", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", "Ödendi");
                add2.Parameters.AddWithValue("@o3", o2);
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();
            }

            listele();
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
            if (e.Column.FieldName == "Sipariş No" || e.Column.FieldName == "Tarih" || e.Column.FieldName == "TeslimTarihi" || e.Column.FieldName == "Plasiyer" || e.Column.FieldName == "FaturaNo" || e.Column.FieldName == "Tutar" || e.Column.FieldName == "Sipariş Durumu")
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
            // teslim edildi

            Teslim.sID = lID;
            Teslim.sNo = fNo;
            Teslim te = new Teslim();
            te.Show();

            //for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            //{

            //    string id = gridView1.GetSelectedRows()[i].ToString();
            //    int y = Convert.ToInt32(id);
            //    string o2;
            //    o2 = gridView1.GetRowCellValue(y, "ID").ToString();

            //    //       o2 = gridView3.GetRowCellValue(i, "ID").ToString();
            //    SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
            //        "update rTeklifListe set GenelDurum=@o1 where ID = @o3; " +
            //        "COMMIT TRANSACTION", bgl.baglanti());
            //    add2.Parameters.AddWithValue("@o1", "Teslim Edildi");
            //    add2.Parameters.AddWithValue("@o3", o2);
            //    add2.ExecuteNonQuery();
            //    bgl.baglanti().Close();
            //}

            //listele();

        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {    

            mROOT._8.Spektrotek.SFaturaNo.sipID = lID;
            mROOT._8.Spektrotek.SFaturaNo.sipno = fNo;
            mROOT._8.Spektrotek.SFaturaNo.siparis = "gm" ;

            _8.Spektrotek.SFaturaNo at = new _8.Spektrotek.SFaturaNo();
            at.Show();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //iptal
            DialogResult Secim = new DialogResult();

            Secim = MessageBox.Show("Seçili siparişler iptal mi edildi ? ", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (Secim == DialogResult.Yes)
            {
                for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                {

                    string id = gridView1.GetSelectedRows()[i].ToString();
                    int y = Convert.ToInt32(id);
                    string o2;
                    o2 = gridView1.GetRowCellValue(y, "ID").ToString();

                    //       o2 = gridView3.GetRowCellValue(i, "ID").ToString();
                    SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                        "update rTeklifListe set GenelDurum=@o1 where ID = @o3; " +
                        "COMMIT TRANSACTION", bgl.baglanti());
                    add2.Parameters.AddWithValue("@o1", "İptal");
                    add2.Parameters.AddWithValue("@o3", o2);
                    add2.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }

                listele();

            }
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            //  Tüm satırı renklendirmek istediğin zaman kullan
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {

                string ODurum = gridView1.GetRowCellValue(e.RowHandle, "Sipariş Durumu").ToString();
                string odeme = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Ödeme"]);
                if (ODurum == "Teslim Edildi" && odeme == "Ödendi")
                {
                    e.Appearance.BackColor = Color.Green;
                    e.Appearance.BackColor2 = Color.LightGreen;
                    e.HighPriority = true;

                }
                else if (ODurum == "İptal")
                {
                    e.Appearance.BackColor = Color.LightSalmon;
                    e.Appearance.BackColor2 = Color.MediumVioletRed;
                    e.HighPriority = true;
                }
              
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Taksitli Ödeme

            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {

                string id = gridView1.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                string o2;
                o2 = gridView1.GetRowCellValue(y, "ID").ToString();

                //       o2 = gridView3.GetRowCellValue(i, "ID").ToString();
                SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                    "update rTeklifListe set FaturaDurumu=@o1 where ID = @o3; " +
                    "COMMIT TRANSACTION", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", "Taksitli");
                add2.Parameters.AddWithValue("@o3", o2);
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();
            }

            listele();
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Üretim Formu

            mKYS.Raporlar.UretimFormu.tID = lID;

            using (mKYS.Raporlar.frmPrint frm = new mKYS.Raporlar.frmPrint())
            {
                frm.UretimFormu();
                frm.ShowDialog();
            }
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Fason Formu
            mKYS.Raporlar.FasonFormu.tID = lID;

            using (mKYS.Raporlar.frmPrint frm = new mKYS.Raporlar.frmPrint())
            {
                frm.FasonFormu();
                frm.ShowDialog();
            }
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //teklif iletildi

            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {

                string id = gridView1.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                string o2;
                o2 = gridView1.GetRowCellValue(y, "ID").ToString();

                //       o2 = gridView3.GetRowCellValue(i, "ID").ToString();
                SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                    "update rTeklifListe set GenelDurum=@o1 where ID = @o3; " +
                    "COMMIT TRANSACTION", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", "Teklif İletildi");
                add2.Parameters.AddWithValue("@o3", o2);
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();
            }

            listele();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //yolda

            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {

                string id = gridView1.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                string o2;
                o2 = gridView1.GetRowCellValue(y, "ID").ToString();

                //       o2 = gridView3.GetRowCellValue(i, "ID").ToString();
                SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                    "update rTeklifListe set GenelDurum=@o1 where ID = @o3; " +
                    "COMMIT TRANSACTION", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", "Gönderildi");
                add2.Parameters.AddWithValue("@o3", o2);
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();
            }

            listele();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //hazırlanıyor

            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {

                string id = gridView1.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                string o2;
                o2 = gridView1.GetRowCellValue(y, "ID").ToString();

                //       o2 = gridView3.GetRowCellValue(i, "ID").ToString();
                SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                    "update rTeklifListe set GenelDurum=@o1 where ID = @o3; " +
                    "COMMIT TRANSACTION", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", "Hazırlanıyor");
                add2.Parameters.AddWithValue("@o3", o2);
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();
            }

            listele();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            lID = dr["ID"].ToString();
            fNo = dr["Sipariş No"].ToString();
            //firID = dr["FirmaID"].ToString();
            //tutar = dr["Toplam Tutar"].ToString();
        }
    }
}
