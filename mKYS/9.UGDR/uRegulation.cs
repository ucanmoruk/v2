﻿using DevExpress.XtraEditors.Repository;
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

namespace mROOT._9.UGDR
{
    public partial class uRegulation : Form
    {
        public uRegulation()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(@"select Num as 'Yönetmelik No', INCI as 'Bileşen', UrunTipi as 'Ürün Tipi',
            Maks as 'Maksimum Konsantrasyon', Diger, Etiket as 'Etiket Beyanı', ID
            from rUGDYonetmelik", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.Columns["ID"].Visible = false;
            // gridView1.Columns["FirmaID"].Visible = false;

            RepositoryItemMemoEdit memo = new RepositoryItemMemoEdit();
            gridView1.Columns["Bileşen"].ColumnEdit = memo;
            gridView1.Columns["Bileşen"].ColumnEdit = new RepositoryItemMemoEdit();
            RepositoryItemMemoEdit memo2 = new RepositoryItemMemoEdit();
            gridView1.Columns["Ürün Tipi"].ColumnEdit = memo2;
            gridView1.Columns["Ürün Tipi"].ColumnEdit = new RepositoryItemMemoEdit();
            RepositoryItemMemoEdit memo3 = new RepositoryItemMemoEdit();
            gridView1.Columns["Maksimum Konsantrasyon"].ColumnEdit = memo3;
            gridView1.Columns["Maksimum Konsantrasyon"].ColumnEdit = new RepositoryItemMemoEdit();
            RepositoryItemMemoEdit memo4 = new RepositoryItemMemoEdit();
            gridView1.Columns["Diger"].ColumnEdit = memo4;
            gridView1.Columns["Diger"].ColumnEdit = new RepositoryItemMemoEdit();
            RepositoryItemMemoEdit memo5 = new RepositoryItemMemoEdit();
            gridView1.Columns["Etiket Beyanı"].ColumnEdit = memo5;
            gridView1.Columns["Etiket Beyanı"].ColumnEdit = new RepositoryItemMemoEdit();
        }

        void gridduzen()
        {
            this.gridView1.Columns[0].Width = 70;
            this.gridView1.Columns[1].Width = 150;
            this.gridView1.Columns[2].Width = 150;
            this.gridView1.Columns[3].Width = 90;
            this.gridView1.Columns[4].Width = 150;
            this.gridView1.Columns[5].Width = 100;

        }

        private void Liste_Load(object sender, EventArgs e)
        {
            listele();
            gridduzen();
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //string adam = gridView1.GetRowCellValue(e.RowHandle, "Durum").ToString();
            //if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && adam == "Raporlandı")
            //    e.Appearance.BackColor = Color.LightGreen;
            //else if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && adam == "Beklemede")
            //    e.Appearance.BackColor = Color.LightSalmon;
            //else if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && adam == "Yeni")
            //    e.Appearance.BackColor = Color.WhiteSmoke;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Teklif Yazdır
           // mKYS.Raporlar.TeklifMS.tID = lID;
            //mKYS.Raporlar.UGD1.tID = lID;
            //mKYS.Raporlar.UGD2.tID = lID;
            //mKYS.Raporlar.UGD3.tID = lID;
            //mKYS.Raporlar.UGD4.tID = lID;
            //using (mKYS.Raporlar.frmPrint frm = new mKYS.Raporlar.frmPrint())
            //{
            //    frm.UGDR();
            //    frm.ShowDialog();
            //}
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //güncelle
            uYeni.detay = lID;
            uYeni d = new uYeni();
            d.Show();
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
            if (e.Column.FieldName == "Maksimum Konsantrasyon" || e.Column.FieldName == "Yönetmelik No")
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
          //  fNo = dr["TeklifNo"].ToString();
            //firID = dr["FirmaID"].ToString();
            //tutar = dr["Toplam Tutar"].ToString();
        }
    }
}
