﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;
using System.Diagnostics;

namespace mKYS
{
    public partial class HammaddeListesi_rp : Form
    {
        public HammaddeListesi_rp()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            if (Anasayfa.birimID == 1005)
            {
                DataTable dt2 = new DataTable();
                //SqlDataAdapter da2 = new SqlDataAdapter(@"select Mix, GenelAd, InciAd, CasNo, 
                //EcNo, Fonksiyon, Yonetmelik, Noael2 as 'Noael', Fizikokimya, Toksikoloji, Kaynak, ID from rHammadde
                //where Durum = N'Aktif' order by InciAd", bgl.baglanti());
                SqlDataAdapter da2 = new SqlDataAdapter(@"select h.GenelAd, c.INCIName, SUBSTRING(Link,60,69) as 'CosIng ID', c.Cas, h.Noael2, h.Fizikokimya, h.Toksikoloji, h.Kaynak, h.EkBilgi, c.ID from rHammadde h 
			    left join rCosing c on h.CID = c.ID  where h.Durum = 'Aktif'", bgl.baglanti());
                da2.Fill(dt2);
                gridControl1.DataSource = dt2;
            }
            else if(Anasayfa.birimID == 1006)
            {
                DataTable dt2 = new DataTable();
                //SqlDataAdapter da2 = new SqlDataAdapter(@"select Mix, GenelAd, InciAd, CasNo, 
                //EcNo, Fonksiyon, Yonetmelik, Noael2 as 'Noael', Fizikokimya, Toksikoloji, Kaynak, ID from rHammadde
                //where Durum = N'Aktif' order by InciAd", bgl.baglanti());
                SqlDataAdapter da2 = new SqlDataAdapter(@"select c.INCIName, SUBSTRING(Link,60,69) as 'CosIng ID', c.Cas, h.Noael2, 
                h.Fizikokimya, h.Toksikoloji, h.Kaynak, h.EkBilgi, c.ID from rkHammadde h 
                left join rCosing c on h.CID = c.ID  where h.Durum = 'Aktif'", bgl.baglanti());
                da2.Fill(dt2);
                gridControl1.DataSource = dt2;
            }
            else
            {
                DataTable dt2 = new DataTable();
                //SqlDataAdapter da2 = new SqlDataAdapter(@"select Mix, GenelAd, InciAd, CasNo, 
                //EcNo, Fonksiyon, Yonetmelik, Noael2 as 'Noael', Fizikokimya, Toksikoloji, Kaynak, ID from rHammadde
                //where Durum = N'Aktif' order by InciAd", bgl.baglanti());
                SqlDataAdapter da2 = new SqlDataAdapter(@"select h.GenelAd, c.INCIName, SUBSTRING(Link,60,69) as 'CosIng ID', c.Cas, h.Noael2, h.Fizikokimya, h.Toksikoloji, h.Kaynak, h.EkBilgi, c.ID from rHammadde h 
			    left join rCosing c on h.CID = c.ID  where h.Durum = 'Aktif'", bgl.baglanti());
                da2.Fill(dt2);
                gridControl1.DataSource = dt2;
            }

            

          //  gridView1.Columns["ID"].Visible = false;

           
            this.gridView1.Columns[0].Width = 120;
            this.gridView1.Columns[1].Width = 60;
            this.gridView1.Columns[2].Width = 80;
            this.gridView1.Columns[3].Width = 60;
            this.gridView1.Columns[4].Width = 100;
            this.gridView1.Columns[5].Width = 100;
            this.gridView1.Columns[6].Width = 90;
            this.gridView1.Columns[7].Width = 90;

        }


        private void StokListesi_Load(object sender, EventArgs e)
        {
            listele();
          //  yetkibul();
        }

        public static string kod, did;
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                //did = dr["ID"].ToString();
                //YeniHammadde.ID = did;
                //YeniHammadde sd = new YeniHammadde();
                //sd.Show();
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


        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //try
            //{
            //    DialogResult Secim = new DialogResult();

            //    Secim = MessageBox.Show(skod + " hammaddeyi silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            //    if (Secim == DialogResult.Yes)
            //    {
            //        if (Anasayfa.birimID == 1005)
            //        {
            //            // SqlCommand komutSil = new SqlCommand("delete from Firma where ID = @p1", bgl.baglanti());
            //            SqlCommand komutSil = new SqlCommand("update rHammadde set Durum=@a1 where cID = N'"+id+"'", bgl.baglanti());
            //            komutSil.Parameters.AddWithValue("@a1", "Pasif");
            //            komutSil.ExecuteNonQuery();
            //            bgl.baglanti().Close();
            //            MessageBox.Show("Silme işlemi gerçekleşmiştir.");
            //            listele();
            //        }
            //        else if(Anasayfa.birimID == 1006)
            //        {
            //            // SqlCommand komutSil = new SqlCommand("delete from Firma where ID = @p1", bgl.baglanti());
            //            SqlCommand komutSil = new SqlCommand("update rkHammadde set Durum=@a1 where cID = N'" + id + "'", bgl.baglanti());
            //            komutSil.Parameters.AddWithValue("@a1", "Pasif");
            //            komutSil.ExecuteNonQuery();
            //            bgl.baglanti().Close();
            //            MessageBox.Show("Silme işlemi gerçekleşmiştir.");
            //            listele();
            //        }
            //        else
            //        {
            //            // SqlCommand komutSil = new SqlCommand("delete from Firma where ID = @p1", bgl.baglanti());
            //            SqlCommand komutSil = new SqlCommand("update rHammadde set Durum=@a1 where cID = N'" + id + "'", bgl.baglanti());
            //            komutSil.Parameters.AddWithValue("@a1", "Pasif");
            //            komutSil.ExecuteNonQuery();
            //            bgl.baglanti().Close();
            //            MessageBox.Show("Silme işlemi gerçekleşmiştir.");
            //            listele();
            //        }



                    
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Hata2 : " + ex.Message);
            //}
        }

        private void StokListesi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                listele();
            }
        }

        string skod, id;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                skod = dr["INCIName"].ToString();
                id = dr["ID"].ToString();
             }
            catch (Exception)
            {
                MessageBox.Show("Aradığınız stok kaydı bulunamadı!", "Oopss!");
            }
          
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //try
            //{
            //    YeniHammadde.ID = id;
            //    YeniHammadde sd = new YeniHammadde();
            //    sd.Show();
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show("Hata SL2: " + ex);
            //}
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
  
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem4_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //stok hareketleri

            //StokHareket.urunkod = id;
            //StokHareket sd = new StokHareket();
            //sd.Show();
        }

        private void barButtonItem5_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // hammadde reçetesi

            //Stok.HammaddeUGDMix.hID = id;
            //Stok.HammaddeUGDMix hm = new Stok.HammaddeUGDMix();
            //hm.Show();

        }

        private void barButtonItem6_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //excel
            string path = "Hammadde.xlsx";
            gridControl1.ExportToXlsx(path);
            Process.Start(path);
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "Noael" || e.Column.FieldName == "CosIng ID")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
           

        }
    }
}
