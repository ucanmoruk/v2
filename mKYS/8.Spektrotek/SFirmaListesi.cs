﻿using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
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
using mKYS.Talep;

namespace mROOT._8.Spektrotek
{
    public partial class SFirmaListesi : Form
    {
        public SFirmaListesi()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt = new DataTable();
            //select Row_number() over(order by t.Tur) as 'No',
            SqlDataAdapter da = new SqlDataAdapter(@"select Tur2 as 'Kategori', Ad as 'Firma Adı', Adres, Tur, Yetkili, Telefon, Email, Web, VergiDairesi, VergiNo , Notlar, ID from RootTedarikci
            where Durum = 'Aktif' and Kimin = 'Spektrotek' order by Ad", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.Columns["ID"].Visible = false;
            this.gridView1.Columns[0].Width = 55;
            this.gridView1.Columns[1].Width = 125;
            this.gridView1.Columns[2].Width = 125;
            this.gridView1.Columns[3].Width = 55;
            this.gridView1.Columns[4].Width = 60;
            this.gridView1.Columns[5].Width = 50;
            this.gridView1.Columns[6].Width = 50;
            this.gridView1.Columns[7].Width = 50;
            this.gridView1.Columns[8].Width = 50;
            this.gridView1.Columns[9].Width = 50;
            this.gridView1.Columns[10].Width = 75;

            RepositoryItemMemoEdit memo = new RepositoryItemMemoEdit();
            gridView1.Columns["Notlar"].ColumnEdit = memo;
            //gridView1.Columns["Durum"].ColumnEdit = memo;
            gridView1.Columns["VergiNo"].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
          //  gridView1.Columns["Durum"].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
        }

        int yetki;
        void yetkibul()
        {
            //SqlCommand komut21 = new SqlCommand("Select * from KaliteYetki where Gorev = N'" + Anasayfa.gorev + "' ", bgl.baglanti());
            //SqlDataReader dr21 = komut21.ExecuteReader();
            //while (dr21.Read())
            //{
            //    yetki = Convert.ToInt32(dr21["Talep"]);
            //}
            //bgl.baglanti().Close();

            //if (yetki == 0 || yetki.ToString() == null)
            //{
            //    barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //}
            //else if (yetki == 1)
            //{
            //    barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //} 
            //else if (yetki == 2 || yetki == 3)
            //{
            //    barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //    barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //    barButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;                
            //    barButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //    barButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;       
            //}
              
        }

        private void TedarikciListesi_Load(object sender, EventArgs e)
        {
            listele();
           // yetkibul();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //değerlendirme formu yazdır

            mKYS.Raporlar.Tedarikci.firmaID = fID;
            using (mKYS.Raporlar.frmPrint frm = new mKYS.Raporlar.frmPrint())
            {
                frm.Tedarikci();
                frm.ShowDialog();
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string path = "FirmaListesi.xlsx";
            gridControl1.ExportToXlsx(path);
            Process.Start(path);
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listele();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show(firmad + " firmasını silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (Secim == DialogResult.Yes)
                {
                    // SqlCommand komutSil = new SqlCommand("delete from Firma where ID = @p1", bgl.baglanti());
                    SqlCommand komutSil = new SqlCommand("update RootTedarikci set Durum=@a1 where ID = N'" + fID + "' ", bgl.baglanti());
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

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }

        }

        private void TedarikciListesi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                listele();
            }
        }

        string firmad, durum, fID;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                firmad = dr["Firma Adı"].ToString();
              //  durum = dr["Çalışma Durumu"].ToString();
                fID = dr["ID"].ToString();

                //if (durum == "Pasif")
                //{
                //    barButtonItem6.Caption = "Firmayı Aktifleştir";
                //}
                //else
                //{

                //    barButtonItem6.Caption = "Firmayı Pasife Al";
                //}

            }
            catch (Exception Ex)
            {

                MessageBox.Show("Aradığınız kayıt bulunamadı!");
            }
           
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TedarikciEkle.firma = firmad;
            TedarikciEkle.fID = fID;
            TedarikciEkle te = new TedarikciEkle();
            te.Show();
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "No" || e.Column.FieldName == "Çalışma Durumu" || e.Column.FieldName == "Değerlendirme Tarihi" || e.Column.FieldName == "Puan" || e.Column.FieldName == "Durum")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            //GridView View = sender as GridView;
            //if (e.RowHandle >= 0)
            //{               
            //    string ODurum = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Çalışma Durumu"]);
            //    if (ODurum == "Pasif")
            //    {
            //        e.Appearance.BackColor = Color.IndianRed;
            //    }
            //}

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //TedarikciPuan.firma = firmad;
            //TedarikciPuan.fID = fID;
            //TedarikciPuan tp = new TedarikciPuan();
            //tp.Show();

            TedarikKabul.firma = firmad;
            TedarikKabul.fID = fID;
            TedarikKabul tk = new TedarikKabul();
            tk.Show();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            firmad = dr["Firma Adı"].ToString();
            fID = dr["ID"].ToString();

            TedarikciEkle.firma = firmad;
            TedarikciEkle.fID = fID;
            TedarikciEkle te = new TedarikciEkle();
            te.Show();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (durum == "Pasif")
            {
                SqlCommand komutSil = new SqlCommand("update RootTedarikci set Durumu=@a1 where ID = N'" + fID+ "' ", bgl.baglanti());
                komutSil.Parameters.AddWithValue("@a1", "Aktif");
                komutSil.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Firma başarılı şekilde aktifleştirilmiştir. " + "\n" + "Yeni firma için tedarikçi değerlendirmesi yapmayı unutmayınız!", "Oopppss!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {

                SqlCommand komutSil = new SqlCommand("update RootTedarikci set Durumu=@a1 where ID = N'" + fID + "' ", bgl.baglanti());
                komutSil.Parameters.AddWithValue("@a1", "Pasif");
                komutSil.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Firma başarılı şekilde pasifize edilmiştir." , "Oopppss!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                
            }
            listele();

        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //string durum = gridView1.GetRowCellValue(e.RowHandle, "Durum").ToString();
            //if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && durum == "Uygun Değil")
            //    e.Appearance.BackColor = Color.OrangeRed;

        }
    }
}
