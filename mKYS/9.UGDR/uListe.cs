using DevExpress.XtraGrid;
using mKYS;
using mKYS.Raporlar;
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
    public partial class uListe : Form
    {
        public uListe()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(@"select l.Tarih, l.RaporNo as 'Rapor No' , l.Versiyon, t.Ad as 'Firma' , 
            l.Barkod, l.Urun, l.Miktar, l.Tip1 +' - '+g.UrunTipi as 'Ürün Tipi', l.A as 'A Değeri',
            l.RaporDurum as 'Durum', l.ID  from rUGDListe l 
            left join RootTedarikci t on l.FirmaID = t.ID
            left join rUGDTip g on l.Tip2 =g.ID 
            where l.Durum = 'Aktif' and l.BirimID = '" + Giris.birimID+"' order by l.ID desc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.Columns["ID"].Visible = false;
           // gridView1.Columns["FirmaID"].Visible = false;
        }

        void gridduzen()
        {
            this.gridView1.Columns[0].Width = 60;
            this.gridView1.Columns[1].Width = 40;
            this.gridView1.Columns[2].Width = 30;
            this.gridView1.Columns[3].Width = 200;
            this.gridView1.Columns[4].Width = 80;
            this.gridView1.Columns[5].Width = 170;
            this.gridView1.Columns[6].Width = 50;
            this.gridView1.Columns[7].Width = 110;
            this.gridView1.Columns[8].Width = 50;
            this.gridView1.Columns[9].Width = 90;

        }

        private void Liste_Load(object sender, EventArgs e)
        {
            listele();
            gridduzen();
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            string adam = gridView1.GetRowCellValue(e.RowHandle, "Durum").ToString();
            if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && adam == "Gönderildi")
                e.Appearance.BackColor = Color.LightGreen;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && adam == "Hazırlanıyor")
                e.Appearance.BackColor = Color.LightSalmon;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && adam == "Yeni")
                e.Appearance.BackColor = Color.WhiteSmoke;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && adam == "İptal")
                e.Appearance.BackColor = Color.OrangeRed;
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
                frmPrint.name = "UGDR - " + dosyadi;
                using (mKYS.Raporlar.frmPrint frm = new mKYS.Raporlar.frmPrint())
                {
                    frm.OzecoTr();
                    frm.ShowDialog();
                }
            }
            else if (Giris.birimID == "1006")
            {
                mKYS.Raporlar.UGD1.tID = lID;
                mKYS.Raporlar.UGD2.tID = lID;
                mKYS.Raporlar.UGD3.tID = lID;
                mKYS.Raporlar.UGD4.tID = lID;
                frmPrint.name = "UGDR - " + dosyadi;
                using (mKYS.Raporlar.frmPrint frm = new mKYS.Raporlar.frmPrint())
                {
                    frm.UGDR();
                    frm.ShowDialog();
                }
            }
            else
            {
                for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                {
                    id = gridView1.GetSelectedRows()[i].ToString();
                    int y = Convert.ToInt32(id);
                    listeID = gridView1.GetRowCellValue(y, "ID").ToString();

                    mKYS.Raporlar.UGD1.tID = listeID;
                    mKYS.Raporlar.UGD2.tID = listeID;
                    mKYS.Raporlar.UGD3.tID = listeID;
                    mKYS.Raporlar.UGD4.tID = listeID;
                    frmPrint.name = "UGDR - " + dosyadi;
                    using (mKYS.Raporlar.frmPrint frm = new mKYS.Raporlar.frmPrint())
                    {
                        frm.UGDR();
                        frm.ShowDialog();
                    }


                }

              


                //mKYS.Raporlar.Cosmoliz.UGD1.tID = lID;
                //mKYS.Raporlar.Cosmoliz.UGD2.tID = lID;
                //mKYS.Raporlar.Cosmoliz.UGD3.tID = lID;
                //mKYS.Raporlar.Cosmoliz.UGD4.tID = lID;
                //using (mKYS.Raporlar.frmPrint frm = new mKYS.Raporlar.frmPrint())
                //{
                //    frm.CosmolizTR();
                //    frm.ShowDialog();
                //}
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
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);

            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "Rapor No" || e.Column.FieldName == "A Değeri" || e.Column.FieldName == "Versiyon" || e.Column.FieldName == "Tarih" || e.Column.FieldName == "Miktar" || e.Column.FieldName == "Durum")
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
            // iptal
            DialogResult Secim = new DialogResult();

            Secim = MessageBox.Show(fNo + " numaralı rapor iptal mi edildi ? ", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (Secim == DialogResult.Yes)
            {
                SqlCommand komutSil = new SqlCommand("update rUGDListe set RaporDurum=@a1 where ID = @p1", bgl.baglanti());
                komutSil.Parameters.AddWithValue("@p1", lID);
                komutSil.Parameters.AddWithValue("@a1", "İptal");
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

        string id, listeID;
        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //gönderildi
            //SqlCommand komutSil = new SqlCommand("update rUGDListe set RaporDurum=@a1 where ID = @p1", bgl.baglanti());
            //komutSil.Parameters.AddWithValue("@p1", lID);
            //komutSil.Parameters.AddWithValue("@a1", "Gönderildi");
            //komutSil.ExecuteNonQuery();
            //bgl.baglanti().Close();
            //listele();
            ////DialogResult Secim = new DialogResult();

            ////Secim = MessageBox.Show(fNo + " numaralı faturada kısmi ödeme mevcut ? ", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            ////if (Secim == DialogResult.Yes)
            ////{
            ////    SqlCommand komutSil = new SqlCommand("update MSListe set GenelDurum=@a1 where ID = @p1", bgl.baglanti());
            ////    komutSil.Parameters.AddWithValue("@p1", lID);
            ////    komutSil.Parameters.AddWithValue("@a1", "Kısmı Ödeme");
            ////    komutSil.ExecuteNonQuery();
            ////    bgl.baglanti().Close();
            ////    listele();
            ////}

            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                id = gridView1.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                listeID = gridView1.GetRowCellValue(y, "ID").ToString();

                try
                {
                    SqlCommand komutSil = new SqlCommand("update rUGDListe set RaporDurum=@a1 where ID = @p1", bgl.baglanti());
                    komutSil.Parameters.AddWithValue("@p1", listeID);
                    komutSil.Parameters.AddWithValue("@a1", "Gönderildi");
                    komutSil.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata 11:" + ex);
                }
            }
            listele();
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
                frmPrint.name = "UGDR - " + dosyadi;
                using (mKYS.Raporlar.frmPrint frm = new mKYS.Raporlar.frmPrint())
                {
                    frm.OzecoEn();
                    frm.ShowDialog();
                }
            }
            else if (Giris.birimID == "1006")
            {
                mKYS.Raporlar.Eng.UGD1.tID = lID;
                mKYS.Raporlar.Eng.UGD2.tID = lID;
                mKYS.Raporlar.Eng.UGD3.tID = lID;
                mKYS.Raporlar.Eng.UGD4.tID = lID;
                frmPrint.name = "UGDR - " + dosyadi;
                using (mKYS.Raporlar.frmPrint frm = new mKYS.Raporlar.frmPrint())
                {
                    frm.UGDEn();
                    frm.ShowDialog();
                }

            }
            else
            {                                

                for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                {
                    id = gridView1.GetSelectedRows()[i].ToString();
                    int y = Convert.ToInt32(id);
                    listeID = gridView1.GetRowCellValue(y, "ID").ToString();

                    mKYS.Raporlar.Eng.UGD1.tID = listeID;
                    mKYS.Raporlar.Eng.UGD2.tID = listeID;
                    mKYS.Raporlar.Eng.UGD3.tID = listeID;
                    mKYS.Raporlar.Eng.UGD4.tID = listeID;
                    frmPrint.name = "UGDR - " + dosyadi;
                    using (mKYS.Raporlar.frmPrint frm = new mKYS.Raporlar.frmPrint())
                    {
                        frm.UGDR();
                        frm.ShowDialog();
                    }


                }
            }
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            uDAP.uID = lID;
            uDAP ua = new uDAP();
            ua.Show();
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //etiket yazdır
            mROOT.Raporlar.UTSEtiket.tID = lID;
            using (mKYS.Raporlar.frmPrint frm = new mKYS.Raporlar.frmPrint())
            {
                frm.UTSEtiket();
                frm.ShowDialog();
            }
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //sil   
            SqlCommand komutSil = new SqlCommand("update rUGDListe set Durum=@a1 where ID = @p1", bgl.baglanti());
            komutSil.Parameters.AddWithValue("@p1", lID);
            komutSil.Parameters.AddWithValue("@a1", "Pasif");
            komutSil.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ////hazırlanıypr
            //SqlCommand komutSil = new SqlCommand("update rUGDListe set RaporDurum=@a1 where ID = @p1", bgl.baglanti());
            //komutSil.Parameters.AddWithValue("@p1", lID);
            //komutSil.Parameters.AddWithValue("@a1", "Hazırlanıyor");
            //komutSil.ExecuteNonQuery();
            //bgl.baglanti().Close();
            //listele();
            ////DialogResult Secim = new DialogResult();

            ////Secim = MessageBox.Show(fNo + " numaralı teklif onaylandı mı ? ", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            ////if (Secim == DialogResult.Yes)
            ////{
            ////    SqlCommand komutSil = new SqlCommand("update STeklifListe set GenelDurum=@a1 where ID = @p1", bgl.baglanti());
            ////    komutSil.Parameters.AddWithValue("@p1", lID);
            ////    komutSil.Parameters.AddWithValue("@a1", "Onaylandı");
            ////    komutSil.ExecuteNonQuery();
            ////    bgl.baglanti().Close();
            ////    listele();
            ////}

            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                id = gridView1.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                listeID = gridView1.GetRowCellValue(y, "ID").ToString();

                try
                {
                    SqlCommand komutSil = new SqlCommand("update rUGDListe set RaporDurum=@a1 where ID = @p1", bgl.baglanti());
                    komutSil.Parameters.AddWithValue("@p1", listeID);
                    komutSil.Parameters.AddWithValue("@a1", "Hazırlanıyor");
                    komutSil.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata 11:" + ex);
                }
            }

            listele();
        }
        string rno, dosyadi;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            lID = dr["ID"].ToString();
            rno = dr["Rapor No"].ToString();
            //firID = dr["FirmaID"].ToString();
            //tutar = dr["Toplam Tutar"].ToString();
            dosyadi = dr["Urun"].ToString();
        }
    }
}
