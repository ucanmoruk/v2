﻿using DevExpress.XtraGrid.Views.Grid;
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

namespace mKYS.Dokuman
{
    public partial class DokumanMaster : Form
    {
        public DokumanMaster()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select Row_number() over(order by ID) as 'No', Tur as 'Tür', Kod, Ad as 'Doküman Adı', YayinTarihi as 'Yayın Tarihi', RevNo as 'Revizyon', RevTarihi as 'Rev. Tarihi', Durumu, ID from DokumanMaster where Durum = N'Aktif'", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.Columns["ID"].Visible = false;
        }

        int yetki;
        void yetkibul()
        {
            SqlCommand komut21 = new SqlCommand("Select * from KaliteYetki where Gorev = N'" + Anasayfa.gorev + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                yetki = Convert.ToInt32(dr21["Dokuman"]);
            }
            bgl.baglanti().Close();

            if (yetki == 0 || yetki.ToString() == null)
                {
                    barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    barButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    barButtonItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }                
            else
                {
                    //barButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    //barButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    //barButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
              
        }


        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listele();

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RevizyonYeni.gelis = "yeni";
            RevizyonYeni.dID = dID;
            RevizyonYeni ry = new RevizyonYeni();
            ry.Show();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show(kod + "dokümanını silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (Secim == DialogResult.Yes)
                {
                    // SqlCommand komutSil = new SqlCommand("delete from Firma where ID = @p1", bgl.baglanti());
                    SqlCommand komutSil = new SqlCommand("update DokumanMaster set Durum=@a1 where ıD = N'" + dID + "'", bgl.baglanti());
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

        private void DokumanMaster_Load(object sender, EventArgs e)
        {
            yetkibul();
            listele();
            this.gridView1.Columns[0].Width = 20;
            this.gridView1.Columns[1].Width = 70;
            this.gridView1.Columns[2].Width = 70;
            this.gridView1.Columns[3].Width = 200;
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);

                if (ydurum == "Yayından Kaldırıldı")
                {
                    barButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                else
                {
                    barButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }




            }

        }

        public static string kod, ad, durumu, dID , ydurum;

        string dyol, dadi;
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SqlCommand komut21 = new SqlCommand("Select * from DokumanMaster where ID = N'" + dID + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                dyol = dr21["Path"].ToString();
                dadi = dr21["Ad"].ToString();
            }
            bgl.baglanti().Close();

            if (dyol == "" || dyol == null)
            {
                MessageBox.Show("Bu doküman henüz sisteme yüklenmemiştir!" ,"Ooppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                DokumanGoruntule.yol = dyol;
                DokumanGoruntule.ad = dadi;
                DokumanGoruntule dg = new DokumanGoruntule();
                dg.Show();
            }


        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DokumanGecmis.kod = kod;
            DokumanGecmis.dID = dID;
            DokumanGecmis dg = new DokumanGecmis();
            dg.ShowDialog();
        }

        private void DokumanMaster_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                listele();
            }
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //string adam = gridView1.GetRowCellValue(e.RowHandle, "Durumu").ToString();
            //if (e.RowHandle > -1 && e.Column.FieldName == "Durumu" && adam == "Yayından Kaldırıldı")
            //    e.Appearance.BackColor = Color.IndianRed;
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "Yayın Tarihi" || e.Column.FieldName == "Revizyon" || e.Column.FieldName == "Rev. Tarihi" || e.Column.FieldName == "Durumu" || e.Column.FieldName == "No")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {

                string Kategori = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Durumu"]);
                if (Kategori == "Yayından Kaldırıldı" )
                {
                    e.Appearance.BackColor = Color.IndianRed;
                    e.HighPriority = true;

                }
            }
        }

        string dad;

        public void excelaktar()
        {
            string path = "DokumanMaster.xlsx";
            gridControl1.ExportToXlsx(path);
            Process.Start(path);
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DokumanYeni.gelis = "Güncelle";
            DokumanYeni.dID = dID;
            DokumanYeni dy = new DokumanYeni();
            dy.Show();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            excelaktar();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {            
            try
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                kod = dr["Kod"].ToString();
                dID = dr["ID"].ToString();
                ydurum = dr["Durumu"].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Aradığınız doküman bulunamamıştır!", "Ooppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            kod = dr["Kod"].ToString();
            dID = dr["ID"].ToString();

        }
    }
}
