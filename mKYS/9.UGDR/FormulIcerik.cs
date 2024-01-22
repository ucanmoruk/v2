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
    public partial class FormulIcerik : Form
    {
        public FormulIcerik()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            if (gelis == null || gelis == "")
            {
                DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(@"select l.RaporNo, t.Ad, l.Urun, f.INCIName, f.Miktar, f.DaP, l.A, f.Noael  from rUGDListe l
                left join RootTedarikci t on l.FirmaID = t.ID
                left join rUGDFormül f on l.ID = f.UrunID
                where l.Durum = 'Aktif' order by RaporNo desc", bgl.baglanti());
                da.Fill(dt);
                gridControl1.DataSource = dt;
                // gridView1.Columns["ID"].Visible = false;
                // gridView1.Columns["FirmaID"].Visible = false;
            }
            else
            {
                DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(@"select l.RaporNo, t.Ad, l.Urun, f.INCIName, f.Miktar, f.DaP, l.A, f.Noael  from rUGDListe l
                left join RootTedarikci t on l.FirmaID = t.ID
                left join rUGDFormül f on l.ID = f.UrunID
                where l.Durum = 'Aktif' and l.BirimID = '" + Giris.birimID + "' order by RaporNo desc", bgl.baglanti());
                da.Fill(dt);
                gridControl1.DataSource = dt;
                //gridView1.Columns["ID"].Visible = false;
                // gridView1.Columns["FirmaID"].Visible = false;
            }



        }

        void gridduzen()
        {
            this.gridView1.Columns[0].Width = 50;
            this.gridView1.Columns[1].Width = 150;
            this.gridView1.Columns[2].Width = 150;
            this.gridView1.Columns[3].Width = 120;
            this.gridView1.Columns[4].Width = 70;
            this.gridView1.Columns[5].Width = 70;
            this.gridView1.Columns[6].Width = 70;
            this.gridView1.Columns[7].Width = 70;

        }

        public static string gelis;
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

            if (Giris.birimID == "1005")
            {
                mKYS.Raporlar.Ozeco.Tr.UGD1.tID = lID;
                mKYS.Raporlar.Ozeco.Tr.UGD2.tID = lID;
                mKYS.Raporlar.Ozeco.Tr.UGD3.tID = lID;
                mKYS.Raporlar.Ozeco.Tr.UGD4.tID = lID;
                using (mKYS.Raporlar.frmPrint frm = new mKYS.Raporlar.frmPrint())
                {
                    frm.OzecoTr();
                    frm.ShowDialog();
                }
            }
            else
            {

                //mKYS.Raporlar.Ozeco.Tr.UGD1.tID = lID;
                //mKYS.Raporlar.Ozeco.Tr.UGD2.tID = lID;
                //mKYS.Raporlar.Ozeco.Tr.UGD3.tID = lID;
                //mKYS.Raporlar.Ozeco.Tr.UGD4.tID = lID;
                //using (mKYS.Raporlar.frmPrint frm = new mKYS.Raporlar.frmPrint())
                //{
                //    frm.OzecoTr();
                //    frm.ShowDialog();
                //}


                mKYS.Raporlar.UGD1.tID = lID;
                mKYS.Raporlar.UGD2.tID = lID;
                mKYS.Raporlar.UGD3.tID = lID;
                mKYS.Raporlar.UGD4.tID = lID;
                using (mKYS.Raporlar.frmPrint frm = new mKYS.Raporlar.frmPrint())
                {
                    frm.UGDR();
                    frm.ShowDialog();
                }
            }


            
          
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //güncelle
            OzuCopy.gelis = "guncelleme";
            OzuCopy.uID = lID;
            OzuCopy d = new OzuCopy();
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
            //if (e.HitInfo.InRow)
            //{
            //    var p2 = MousePosition;
            //    popupMenu1.ShowPopup(p2);

            //}
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "RaporNo" || e.Column.FieldName == "DaP" || e.Column.FieldName == "Tarih" || e.Column.FieldName == "Miktar" || e.Column.FieldName == "A" || e.Column.FieldName == "Noael")
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

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            mROOT.Raporlar.CosIng.hID = lID;
            using (mKYS.Raporlar.frmPrint frm = new mKYS.Raporlar.frmPrint())
            {
                frm.CosIng();
                frm.ShowDialog();
            }
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //formül ekle
            uFormul.rNo = rno;
            uFormul.uID = lID;
            uFormul nf = new uFormul();
            nf.Show();


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

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Ürün bilgilerini formülle birlikte mi kopyalamak istiyorsunuz ?",
                                               "Ürün Kopyalama?",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question) == DialogResult.Yes)
            {
                OzuCopy.formuldahil = "evet";
            }
            else
            {

            }
            //güncelle
            OzuCopy.gelis = "copy";
            OzuCopy.uID = lID;
            OzuCopy d = new OzuCopy();
            d.Show();


        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (Giris.birimID == "1005")
            {
                mKYS.Raporlar.Ozeco.En.UGD1.tID = lID;
                mKYS.Raporlar.Ozeco.En.UGD2.tID = lID;
                mKYS.Raporlar.Ozeco.En.UGD3.tID = lID;
                mKYS.Raporlar.Ozeco.En.UGD4.tID = lID;
                using (mKYS.Raporlar.frmPrint frm = new mKYS.Raporlar.frmPrint())
                {
                    frm.OzecoEn();
                    frm.ShowDialog();
                }
            }
            else
            {

                mKYS.Raporlar.Ozeco.En.UGD1.tID = lID;
                mKYS.Raporlar.Ozeco.En.UGD2.tID = lID;
                mKYS.Raporlar.Ozeco.En.UGD3.tID = lID;
                mKYS.Raporlar.Ozeco.En.UGD4.tID = lID;
                using (mKYS.Raporlar.frmPrint frm = new mKYS.Raporlar.frmPrint())
                {
                    frm.OzecoEn();
                    frm.ShowDialog();
                }


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
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            uDAP.uID = lID;
            uDAP ua = new uDAP();
            ua.Show();
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
        string rno;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            //lID = dr["ID"].ToString();
            //rno = dr["Rapor No"].ToString();
            //firID = dr["FirmaID"].ToString();
            //tutar = dr["Toplam Tutar"].ToString();
        }
    }
}
