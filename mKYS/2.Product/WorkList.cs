using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Menu;
using System.Diagnostics;
using mKYS;
using mKYS.Raporlar;

namespace mROOT._2.Product
{
    public partial class WorkList : Form
    {
        public WorkList()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();


        public void listele()
        {
            if (gelis == "" || gelis == null)
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(@"select w.Tarih, w.Termin, w.EvrakNo, w.RaporNo, f.Ad, w.Urun, w.Kategori, 
                w.Hizmet, w.Proje, w.Notlar, w.Notlar2 as 'Proje Not', w.FatNo, w.Odeme, k.Ad as 'Takipçi', w.IsDurum, w.ID from rWorkList w
                left join RootFatura o on w.FaturaID = o.ID
                left join RootTedarikci f on w.FirmaID = f.ID
                left join RootKullanici k on w.PlasiyerID = k.ID
                where w.Durum = N'Aktif' order by w.RaporNo desc", bgl.baglanti());
                da.Fill(dt);
                gridControl1.DataSource = dt;
                gridView3.Columns["ID"].Visible = false;

                this.gridView3.Columns[0].Width = 70;
                this.gridView3.Columns[1].Width = 70;
                this.gridView3.Columns[2].Width = 70;
                this.gridView3.Columns[3].Width = 70;
                this.gridView3.Columns[4].Width = 150;
                this.gridView3.Columns[5].Width = 150;
                this.gridView3.Columns[6].Width = 70;
                this.gridView3.Columns[7].Width = 110;
                this.gridView3.Columns[8].Width = 70;
                this.gridView3.Columns[9].Width = 90;
                this.gridView3.Columns[10].Width = 90;
                this.gridView3.Columns[11].Width = 75;
                this.gridView3.Columns[12].Width = 70;
                this.gridView3.Columns[13].Width = 70;
                this.gridView3.Columns[14].Width = 70;
            }
            else if(gelis == "Ozeco")
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(@"select w.Tarih, w.Termin, w.EvrakNo, w.RaporNo, f.Ad, w.Urun, w.Kategori, 
                w.Hizmet, w.Proje, w.Notlar ,w.Notlar2 as 'Ozeco Not', w.FatNo, w.Odeme, k.Ad as 'Takipçi', w.IsDurum, w.ID from rWorkList w
                left join RootFatura o on w.FaturaID = o.ID
                left join RootTedarikci f on w.FirmaID = f.ID
                left join RootKullanici k on w.PlasiyerID = k.ID
                where w.Durum = N'Aktif' and Proje like '%Ozeco%' order by w.RaporNo desc", bgl.baglanti());
                da.Fill(dt);
                gridControl1.DataSource = dt;
                gridView3.Columns["ID"].Visible = false;

                this.gridView3.Columns[0].Width = 70;
                this.gridView3.Columns[1].Width = 70;
                this.gridView3.Columns[2].Width = 70;
                this.gridView3.Columns[3].Width = 70;
                this.gridView3.Columns[4].Width = 150;
                this.gridView3.Columns[5].Width = 150;
                this.gridView3.Columns[6].Width = 70;
                this.gridView3.Columns[7].Width = 110;
                this.gridView3.Columns[8].Width = 70;
                this.gridView3.Columns[9].Width = 90;
                this.gridView3.Columns[10].Width = 90;
                this.gridView3.Columns[11].Width = 75;
                this.gridView3.Columns[12].Width = 70;
                this.gridView3.Columns[13].Width = 70;
                this.gridView3.Columns[13].Width = 70;
            }
            else
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(@"select w.Tarih, w.Termin, w.EvrakNo, w.RaporNo, f.Ad, w.Urun, w.Kategori, 
                w.Hizmet, w.Proje, w.Notlar, w.Notlar2 as 'Kommass Not', w.FatNo, w.Odeme, k.Ad as 'Takipçi', w.IsDurum, w.ID from rWorkList w
                left join RootFatura o on w.FaturaID = o.ID
                left join RootTedarikci f on w.FirmaID = f.ID
                left join RootKullanici k on w.PlasiyerID = k.ID
                where w.Durum = N'Aktif' and Proje like '%Kommass%' order by w.RaporNo desc", bgl.baglanti());
                da.Fill(dt);
                gridControl1.DataSource = dt;
                gridView3.Columns["ID"].Visible = false;

                this.gridView3.Columns[0].Width = 70;
                this.gridView3.Columns[1].Width = 70;
                this.gridView3.Columns[2].Width = 70;
                this.gridView3.Columns[3].Width = 70;
                this.gridView3.Columns[4].Width = 150;
                this.gridView3.Columns[5].Width = 150;
                this.gridView3.Columns[6].Width = 70;
                this.gridView3.Columns[7].Width = 110;
                this.gridView3.Columns[8].Width = 70;
                this.gridView3.Columns[9].Width = 90;
                this.gridView3.Columns[10].Width = 90;
                this.gridView3.Columns[11].Width = 75;
                this.gridView3.Columns[12].Width = 70;
                this.gridView3.Columns[13].Width = 70;
                this.gridView3.Columns[13].Width = 70;
            }

           
        }

        public static string gelis;
        private void NKR_Load(object sender, EventArgs e)
        {
            listele();

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listele();
        }

        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
                WorkNew.rID = dr["ID"].ToString();
                WorkNew nd = new WorkNew();
                nd.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata1 : " + ex.Message);
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string path = "iştakip.xlsx";
            gridControl1.ExportToXlsx(path);
            Process.Start(path);

        }

        string id, nkrno, name;
        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            //{
            //    id = gridView3.GetSelectedRows()[i].ToString();
            //    int y = Convert.ToInt32(id);
            //    nkrno = gridView3.GetRowCellValue(y, "RaporNo").ToString();
            //    mKYS.Raporlar.Dermatological.raporno = nkrno;
            //    name = gridView3.GetRowCellValue(y, "Numune").ToString();            
            //    mKYS.Raporlar.Dermatological report1 = new mKYS.Raporlar.Dermatological();
            //    report1.bilgi();
            //    report1.Name = nkrno + " - " + name;
            //    report1.CreateDocument();             
            //    report1.ShowPreviewDialog();

            //}
            //yazdırma

           
            

        }

        string nID;
        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {
                id = gridView3.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                nID = gridView3.GetRowCellValue(y, "ID").ToString();

                try
                {
                    SqlCommand komut = new SqlCommand("update rWorkList set IsDurum = @r1 where ID=@r2", bgl.baglanti());
                    komut.Parameters.AddWithValue("@r1", "Rapor Hazır");
                    komut.Parameters.AddWithValue("@r2", nID);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    //   listele();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata 2:" + ex);
                }
            }

            listele();


        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {
                id = gridView3.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                nID = gridView3.GetRowCellValue(y, "ID").ToString();

                try
                {
                    SqlCommand komut = new SqlCommand("update rWorkList set IsDurum = @r1 where ID=@r2", bgl.baglanti());
                    komut.Parameters.AddWithValue("@r1", "Gönderildi");
                    komut.Parameters.AddWithValue("@r2", nID);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    //   listele();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata 2:" + ex);
                }
            }
            listele();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {
                id = gridView3.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                nID = gridView3.GetRowCellValue(y, "ID").ToString();

                try
                {
                    SqlCommand komut = new SqlCommand("update rWorkList set IsDurum = @r1 where ID=@r2", bgl.baglanti());
                    komut.Parameters.AddWithValue("@r1", "Beklemede");
                    komut.Parameters.AddWithValue("@r2", nID);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    //   listele();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata 2:" + ex);
                }
            }
            listele();
        }

        private void barButtonItem30_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {
                id = gridView3.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                nID = gridView3.GetRowCellValue(y, "ID").ToString();

                try
                {
                    SqlCommand komut = new SqlCommand("update rWorkList set IsDurum = @r1 where ID=@r2", bgl.baglanti());
                    komut.Parameters.AddWithValue("@r1", "İptal");
                    komut.Parameters.AddWithValue("@r2", nID);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    //   listele();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata 2:" + ex);
                }
            }
            listele();
        }

        private void barButtonItem31_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //fatura
            //NumuneFatura.gelis = "ÜGD";
            //NumuneFatura.no = no;
            //NumuneFatura nf = new NumuneFatura();
            //nf.Show();

            //faturano
            WorkFatura.wID = no;
            WorkFatura wf = new WorkFatura();
            wf.Show();

        }

        private void gridView3_RowStyle(object sender, RowStyleEventArgs e)
        {
         //  Tüm satırı renklendirmek istediğin zaman kullan
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {

                string Kategori = View.GetRowCellDisplayText(e.RowHandle, View.Columns["IsDurum"]);
                string ODurum = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Odeme"]);
                if (Kategori == "Gönderildi" && ODurum == "Ödendi")
                {
                    e.Appearance.BackColor = Color.Green;
                    e.Appearance.BackColor2 = Color.LightGreen;
                    e.HighPriority = true;

                }
            }
        }

        private void gridView3_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            string hadi = gridView3.GetRowCellValue(e.RowHandle, "IsDurum").ToString();
            string adam = gridView3.GetRowCellValue(e.RowHandle, "Odeme").ToString();
            if (e.RowHandle > -1 && e.Column.FieldName == "IsDurum" && hadi == "Bekliyor")
                e.Appearance.BackColor = Color.LightGreen;
            else if (e.RowHandle > -1 && e.Column.FieldName == "IsDurum" && hadi == "Gönderildi")
                e.Appearance.BackColor = Color.Green;
            else if (e.RowHandle > -1 && e.Column.FieldName == "IsDurum" && hadi == "Laboratuvarda")
                e.Appearance.BackColor = Color.LightSalmon;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Odeme" && adam == "Ödendi")
                e.Appearance.BackColor = Color.Green;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Odeme" && adam == "Ödeme Bekliyor")
                e.Appearance.BackColor = Color.DarkOrange;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Odeme" && adam == "Fatura Kesilmedi")
                e.Appearance.BackColor = Color.IndianRed;

        }

        private void NKR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {

                listele();
            }
        

        }

        private void gridView3_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            
            if (e.Column.FieldName == "RaporNo" || e.Column.FieldName == "EvrakNo" || e.Column.FieldName == "Tarih" || e.Column.FieldName == "Termin"  || e.Column.FieldName == "FaturaNo" || e.Column.FieldName =="Odeme" || e.Column.FieldName == "IsDurum")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
          
        }

        private void gridView3_PopupMenuShowing_1(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                
                    var p2 = MousePosition;
                    popupMenu1.ShowPopup(p2);
                                           

            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {
                id = gridView3.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                nID = gridView3.GetRowCellValue(y, "ID").ToString();

                try
                {
                    SqlCommand komut = new SqlCommand("update rWorkList set IsDurum = @r1 where ID=@r2", bgl.baglanti());
                    komut.Parameters.AddWithValue("@r1", "Laboratuvarda");
                    komut.Parameters.AddWithValue("@r2", nID);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    //   listele();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata 2:" + ex);
                }
            }
            listele();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //beklemede
            SqlCommand komut = new SqlCommand("update rWorkList set Odeme = @r1 where EvrakNo=@r2", bgl.baglanti());
            komut.Parameters.AddWithValue("@r1", "Ödeme Bekliyor");
            komut.Parameters.AddWithValue("@r2", no);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //kısmi
            SqlCommand komut = new SqlCommand("update rWorkList set Odeme = @r1 where EvrakNo=@r2", bgl.baglanti());
            komut.Parameters.AddWithValue("@r1", "Kısmi");
            komut.Parameters.AddWithValue("@r2", no);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ödendi
            SqlCommand komut = new SqlCommand("update rWorkList set Odeme = @r1 where EvrakNo=@r2", bgl.baglanti());
            komut.Parameters.AddWithValue("@r1", "Ödendi");
            komut.Parameters.AddWithValue("@r2", no);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
        }
        
        string no;
        private void gridView3_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
                no = dr["EvrakNo"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata1 : " + ex.Message);
            }
        }
    }
}
