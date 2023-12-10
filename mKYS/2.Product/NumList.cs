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
    public partial class NumList : Form
    {
        public NumList()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();


        public void listele()
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select n.Kabul , n.EvrakNo, n.RaporNo, k.Ad as 'Raporlama', l.Ad as 'Proje', n.NumAd as 'Numune', n.Durum, r.FaturaNo, r.Odeme as 'Fatura',
            n.ID from NKRDermatoloji n
            left join RootTedarikci k on n.RaporFirmaID = k.ID
            left join RootTedarikci l on n.ProjeFirmaID = l.ID
            left join NKRFatura f on  n.EvrakNo = f.EvrakNo
            left join RootFatura r on f.FaturaID = r.ID
            order by n.RaporNo desc ", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView3.Columns["ID"].Visible = false;

            this.gridView3.Columns[0].Width = 70;
            this.gridView3.Columns[1].Width = 70;
            this.gridView3.Columns[2].Width = 70;
            this.gridView3.Columns[3].Width = 200;
            this.gridView3.Columns[4].Width = 200;
            this.gridView3.Columns[5].Width = 150;
            this.gridView3.Columns[6].Width = 70;
            this.gridView3.Columns[7].Width = 70;
            this.gridView3.Columns[8].Width = 90;
        }

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
                NumYeni.rID = dr["ID"].ToString();
                NumYeni nd = new NumYeni();
                nd.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata1 : " + ex.Message);
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string path = "numunelistesi.xlsx";
            gridControl1.ExportToXlsx(path);
            Process.Start(path);

        }

        string id, nkrno, name;
        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {
                id = gridView3.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                nkrno = gridView3.GetRowCellValue(y, "RaporNo").ToString();
                mKYS.Raporlar.Dermatological.raporno = nkrno;
                name = gridView3.GetRowCellValue(y, "Numune").ToString();            
                mKYS.Raporlar.Dermatological report1 = new mKYS.Raporlar.Dermatological();
                report1.bilgi();
                report1.Name = nkrno + " - " + name;
                report1.CreateDocument();             
                report1.ShowPreviewDialog();

            }


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
                    SqlCommand komut = new SqlCommand("update NKRDermatoloji set Durum = @r1 where ID=@r2", bgl.baglanti());
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
                    SqlCommand komut = new SqlCommand("update NKRDermatoloji set Durum = @r1 where ID=@r2", bgl.baglanti());
                    komut.Parameters.AddWithValue("@r1", "Raporlandı");
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
                    SqlCommand komut = new SqlCommand("update NKRDermatoloji set Durum = @r1 where ID=@r2", bgl.baglanti());
                    komut.Parameters.AddWithValue("@r1", "Beklemede");
                    komut.Parameters.AddWithValue("@r2", nkrno);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    //   listele();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata 2:" + ex);
                }
            }

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
                    SqlCommand komut = new SqlCommand("update NKRDermatoloji set Durum = @r1 where ID=@r2", bgl.baglanti());
                    komut.Parameters.AddWithValue("@r1", "İptal");
                    komut.Parameters.AddWithValue("@r2", nkrno);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    //   listele();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata 2:" + ex);
                }
            }
        }

        private void barButtonItem31_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //fatura
            NumuneFatura.no = no;
            NumuneFatura nf = new NumuneFatura();
            nf.Show();
        }

        private void gridView3_RowStyle(object sender, RowStyleEventArgs e)
        {
         //  Tüm satırı renklendirmek istediğin zaman kullan
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {

                string Kategori = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Durum"]);
                string ODurum = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Fatura"]);
                if (Kategori == "Raporlandı" && ODurum == "Ödendi")
                {
                    e.Appearance.BackColor = Color.Green;
                    e.Appearance.BackColor2 = Color.LightGreen;
                    e.HighPriority = true;

                }
            }
        }

        private void gridView3_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            string hadi = gridView3.GetRowCellValue(e.RowHandle, "Durum").ToString();
            string adam = gridView3.GetRowCellValue(e.RowHandle, "Fatura").ToString();
            if (e.RowHandle > -1 && e.Column.FieldName == "Rapor Durumu" && hadi == "Rapor Hazır")
                e.Appearance.BackColor = Color.LightGreen;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Rapor Durumu" && hadi == "Raporlandı")
                e.Appearance.BackColor = Color.Green;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Fatura Durumu" && adam == "Ödendi")
                e.Appearance.BackColor = Color.Green;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Fatura Durumu" && adam == "Ödeme Bekliyor")
                e.Appearance.BackColor = Color.DarkOrange;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Fatura Durumu" && adam == "Fatura Kesilmedi")
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
            
            if (e.Column.FieldName == "RaporNo" || e.Column.FieldName == "Kabul" || e.Column.FieldName == "EvrakNo" || e.Column.FieldName == "Durum"  || e.Column.FieldName == "Fatura" || e.Column.FieldName =="FaturaNo" )
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
