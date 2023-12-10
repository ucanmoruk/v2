using DevExpress.XtraEditors.Repository;
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

namespace mROOT._8.Spektrotek
{
    public partial class STalepListe : Form
    {
        public STalepListe()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        STalepListe m = (STalepListe)System.Windows.Forms.Application.OpenForms["STalepListe"];

        public void listele()
        {
            //if (Anasayfa.kullanici == "2004")
            //{
            //    DataTable dt2 = new DataTable();
            //    SqlDataAdapter da2 = new SqlDataAdapter(@"select s.Tarih, s.TalepNo, s.Onem, f.Ad as 'Firma',  s.Mail,  s.Kategori, s.Detay, s.Kaynak, o.Ad as 'Oluşturan',
            //    a.Ad as 'Atanan', s.Durum, s.ID from STalepListe s
            //    left join RootKullanici o on s.OlusturanID = o.ID
            //    left join RootKullanici a on s.AtananID = a.ID
            //    left join RootTedarikci f on s.FirmaID = f.ID 
            //    where o.ID = N'2004' or a.ID = N'2004'
            //    order by s.ID desc", bgl.baglanti());

            //    da2.Fill(dt2);
            //    gridControl1.DataSource = dt2;

            //    RepositoryItemMemoEdit memo = new RepositoryItemMemoEdit();
            //    gridView1.Columns["Detay"].ColumnEdit = memo;

            //}
            //else
            //{



            //}

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(@"select t.Onem, t.TalepNo, t.Tarih, f.Ad, t.Tur as 'Görüşme Türü', k.Ad as 'Plasiyer' , t.Kategori, 
            t.Durum, a.TeklifNo, t.FaturaNo, t.Odeme, t.ID from STalepListe t
            left join RootTedarikci f on t.FirmaID = f.ID
            left join RootKullanici k on t.AtananID = k.ID
            left join STeklifListe a on t.TeklifID = a.ID where t.GenelDurum = N'Aktif'
            order by t.ID desc", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;

            //RepositoryItemMemoEdit memo = new RepositoryItemMemoEdit();
            //gridView1.Columns["Detay"].ColumnEdit = memo;
            //gridView1.Columns["Detay"].ColumnEdit = new RepositoryItemMemoEdit();

            gridView1.Columns["ID"].Visible = false;

            this.gridView1.Columns[0].Width = 50;
            this.gridView1.Columns[1].Width = 40;
            this.gridView1.Columns[2].Width = 50;
            this.gridView1.Columns[3].Width = 170;
            this.gridView1.Columns[4].Width = 55;
            this.gridView1.Columns[5].Width = 65;
            this.gridView1.Columns[6].Width = 80;
            this.gridView1.Columns[7].Width = 60;
            this.gridView1.Columns[8].Width = 55;
            this.gridView1.Columns[9].Width = 55;
            this.gridView1.Columns[10].Width = 55;


            gridView1.Columns["TalepNo"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns["Onem"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //gridView1.Columns["Kategori"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns["Durum"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns["TeklifNo"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns["FaturaNo"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns["Plasiyer"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns["Odeme"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns["Görüşme Türü"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

        }

        private void STalepListe_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void STalepListe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                listele();
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listele();
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                if (gridView1.SelectedRowsCount > 0)
                {
                    //barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    barSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    barSubItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    //if (Anasayfa.kullanici == "2004")
                    //{
                    //    barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    //}
                    //else
                    //{
                    //    barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    //}
                    var p2 = MousePosition;
                    popupMenu1.ShowPopup(p2);
                }
                else
                {
                    //barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    //barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    barSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    barSubItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    var p2 = MousePosition;
                    popupMenu1.ShowPopup(p2);
                }
                //var p2 = MousePosition;
                //popupMenu1.ShowPopup(p2);
            }
        }

        string talepID, talepNo;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                talepID = dr["ID"].ToString();
                talepNo = dr["TalepNo"].ToString();

            }
            catch (Exception Ex)
            {

                MessageBox.Show("Aradığınız kayıt bulunamadı!");
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //atama 
            
            // fatura NO
            SFaturaNo.talepID = talepID;
            SFaturaNo.talepno = talepNo;
            SFaturaNo at = new SFaturaNo();
            at.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //talepgüncele
            STalep.talepID = talepID;
            STalep s = new STalep();
            s.Show();
        }

        private void barSubItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //durumgüncelle
        }

        string tID, tNo;
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //araştırılıyor

            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                int y = Convert.ToInt32(gridView1.GetSelectedRows()[i].ToString());
                tID = gridView1.GetRowCellValue(y, "ID").ToString();
                tNo = gridView1.GetRowCellValue(y, "TalepNo").ToString();
                try
                {
                    SqlCommand add2 = new SqlCommand("update STalepListe set Durum=@a1 where ID = '" + tID + "' ", bgl.baglanti());
                    add2.Parameters.AddWithValue("@a1", "Araştırılıyor");
                    add2.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    SqlCommand add = new SqlCommand(@"insert into STalepListeLog (TalepNo, Durum, logtur, logKisiID, logTarih)
                    values (@a1, @a2,  @a4, @a5, @a6)", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", tNo);
                    add.Parameters.AddWithValue("@a2", "Araştırılıyor");
                    add.Parameters.AddWithValue("@a4", "Durum");
                    add.Parameters.AddWithValue("@a5", Anasayfa.kullanici);
                    add.Parameters.AddWithValue("@a6", DateTime.Now);
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    listele();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata 2:" + ex);
                }
            }


          
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //teklifiletildi

            // teklifseç ??
            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                int y = Convert.ToInt32(gridView1.GetSelectedRows()[i].ToString());
                tID = gridView1.GetRowCellValue(y, "ID").ToString();
                tNo = gridView1.GetRowCellValue(y, "TalepNo").ToString();
                try
                {
                    SqlCommand add2 = new SqlCommand("update STalepListe set Durum=@a1 where ID = '" + tID + "' ", bgl.baglanti());
                    add2.Parameters.AddWithValue("@a1", "Teklif İletildi");
                    add2.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    SqlCommand add = new SqlCommand(@"insert into STalepListeLog (TalepNo, Durum, logtur, logKisiID, logTarih)
                    values (@a1, @a2,  @a4, @a5, @a6)", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", tNo);
                    add.Parameters.AddWithValue("@a2", "Teklif İletildi");
                    add.Parameters.AddWithValue("@a4", "Durum");
                    add.Parameters.AddWithValue("@a5", Anasayfa.kullanici);
                    add.Parameters.AddWithValue("@a6", DateTime.Now);
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    listele();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata 2:" + ex);
                }
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //olumsuz
            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                int y = Convert.ToInt32(gridView1.GetSelectedRows()[i].ToString());
                tID = gridView1.GetRowCellValue(y, "ID").ToString();
                tNo = gridView1.GetRowCellValue(y, "TalepNo").ToString();
                try
                {
                    SqlCommand add2 = new SqlCommand("update STalepListe set Durum=@a1 where ID = '" + tID + "' ", bgl.baglanti());
                    add2.Parameters.AddWithValue("@a1", "Olumsuz");
                    add2.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    SqlCommand add = new SqlCommand(@"insert into STalepListeLog (TalepNo, Durum, logtur, logKisiID, logTarih)
                    values (@a1, @a2,  @a4, @a5, @a6)", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", tNo);
                    add.Parameters.AddWithValue("@a2", "Olumsuz");
                    add.Parameters.AddWithValue("@a4", "Durum");
                    add.Parameters.AddWithValue("@a5", Anasayfa.kullanici);
                    add.Parameters.AddWithValue("@a6", DateTime.Now);
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    listele(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata 2:" + ex);
                }
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //sipariş
            // ödeme bekliyor ?? 
            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                int y = Convert.ToInt32(gridView1.GetSelectedRows()[i].ToString());
                tID = gridView1.GetRowCellValue(y, "ID").ToString();
                tNo = gridView1.GetRowCellValue(y, "TalepNo").ToString();
                try
                {
                    SqlCommand add2 = new SqlCommand("update STalepListe set Durum=@a1 where ID = '" + tID + "' ", bgl.baglanti());
                    add2.Parameters.AddWithValue("@a1", "Sipariş");
                    add2.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    SqlCommand add = new SqlCommand(@"insert into STalepListeLog (TalepNo, Durum, logtur, logKisiID, logTarih)
                    values (@a1, @a2,  @a4, @a5, @a6)", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", tNo);
                    add.Parameters.AddWithValue("@a2", "Sipariş");
                    add.Parameters.AddWithValue("@a4", "Durum");
                    add.Parameters.AddWithValue("@a5", Anasayfa.kullanici);
                    add.Parameters.AddWithValue("@a6", DateTime.Now);
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    listele();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata 2:" + ex);
                }
            }
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //tamamlandı
            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                int y = Convert.ToInt32(gridView1.GetSelectedRows()[i].ToString());
                tID = gridView1.GetRowCellValue(y, "ID").ToString();
                tNo = gridView1.GetRowCellValue(y, "TalepNo").ToString();
                try
                {
                    SqlCommand add2 = new SqlCommand("update STalepListe set Durum=@a1 where ID = '" + tID + "' ", bgl.baglanti());
                    add2.Parameters.AddWithValue("@a1", "Tamamlandı");
                    add2.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    SqlCommand add = new SqlCommand(@"insert into STalepListeLog (TalepNo, Durum, logtur, logKisiID, logTarih)
                    values (@a1, @a2,  @a4, @a5, @a6)", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", tNo);
                    add.Parameters.AddWithValue("@a2", "Tamamlandı");
                    add.Parameters.AddWithValue("@a4", "Durum");
                    add.Parameters.AddWithValue("@a5", Anasayfa.kullanici);
                    add.Parameters.AddWithValue("@a6", DateTime.Now);
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    listele();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata 2:" + ex);
                }
            }
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            //if (e.Column.FieldName == "TalepNo" || e.Column.FieldName == "Durumu")
            //    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //dobule click
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            talepID = dr["ID"].ToString();
            STalep.talepID = talepID;
            STalep s = new STalep();
            s.Show();

        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ödendi
            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                int y = Convert.ToInt32(gridView1.GetSelectedRows()[i].ToString());
                tID = gridView1.GetRowCellValue(y, "ID").ToString();
                tNo = gridView1.GetRowCellValue(y, "TalepNo").ToString();
                try
                {
                    SqlCommand add2 = new SqlCommand("update STalepListe set Odeme=@a1 where ID = '" + tID + "' ", bgl.baglanti());
                    add2.Parameters.AddWithValue("@a1", "Ödendi");
                    add2.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    SqlCommand add = new SqlCommand(@"insert into STalepListeLog (TalepNo, Odeme, logtur, logKisiID, logTarih)
                    values (@a1, @a2,  @a4, @a5, @a6)", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", tNo);
                    add.Parameters.AddWithValue("@a2", "Ödendi");
                    add.Parameters.AddWithValue("@a4", "Ödeme");
                    add.Parameters.AddWithValue("@a5", Anasayfa.kullanici);
                    add.Parameters.AddWithValue("@a6", DateTime.Now);
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    listele();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata 2:" + ex);
                }
            }
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ödeme bekliyor
            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                int y = Convert.ToInt32(gridView1.GetSelectedRows()[i].ToString());
                tID = gridView1.GetRowCellValue(y, "ID").ToString();
                tNo = gridView1.GetRowCellValue(y, "TalepNo").ToString();
                try
                {
                    SqlCommand add2 = new SqlCommand("update STalepListe set Odeme=@a1 where ID = '" + tID + "' ", bgl.baglanti());
                    add2.Parameters.AddWithValue("@a1", "Ödeme Bekliyor");
                    add2.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    SqlCommand add = new SqlCommand(@"insert into STalepListeLog (TalepNo, Odeme, logtur, logKisiID, logTarih)
                    values (@a1, @a2,  @a4, @a5, @a6)", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", tNo);
                    add.Parameters.AddWithValue("@a2", "Ödeme Bekliyor");
                    add.Parameters.AddWithValue("@a4", "Ödeme");
                    add.Parameters.AddWithValue("@a5", Anasayfa.kullanici);
                    add.Parameters.AddWithValue("@a6", DateTime.Now);
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    listele(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata 2:" + ex);
                }
            }
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //teklifseç
            STalepAtama.talepID = talepID;
            STalepAtama.talepNo = talepNo;
            STalepAtama at = new STalepAtama();
            at.Show();
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //satınalma
            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                int y = Convert.ToInt32(gridView1.GetSelectedRows()[i].ToString());
                tID = gridView1.GetRowCellValue(y, "ID").ToString();
                tNo = gridView1.GetRowCellValue(y, "TalepNo").ToString();
                try
                {
                    SqlCommand add2 = new SqlCommand("update STalepListe set Durum=@a1 where ID = '" + tID + "' ", bgl.baglanti());
                    add2.Parameters.AddWithValue("@a1", "Satın Alma");
                    add2.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    SqlCommand add = new SqlCommand(@"insert into STalepListeLog (TalepNo, Durum, logtur, logKisiID, logTarih)
                    values (@a1, @a2,  @a4, @a5, @a6)", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", tNo);
                    add.Parameters.AddWithValue("@a2", "Satın Alma");
                    add.Parameters.AddWithValue("@a4", "Durum");
                    add.Parameters.AddWithValue("@a5", Anasayfa.kullanici);
                    add.Parameters.AddWithValue("@a6", DateTime.Now);
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    listele();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata 2:" + ex);
                }
            }
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            //  Tüm satırı renklendirmek istediğin zaman kullan
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {

                string odeme = gridView1.GetRowCellValue(e.RowHandle, "Odeme").ToString();
                string ODurum = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Durum"]);
                if (ODurum == "Tamamlandı" && odeme =="Ödendi")
                {
                    e.Appearance.BackColor = Color.Green;
                    e.Appearance.BackColor2 = Color.LightGreen;
                    e.HighPriority = true;

                }
                else if (ODurum == "Olumsuz")
                {
                    e.Appearance.BackColor = Color.LightSalmon;
                    e.Appearance.BackColor2 = Color.MediumVioletRed;
                    e.HighPriority = true;
                }
            }
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            string onem = gridView1.GetRowCellValue(e.RowHandle, "Onem").ToString();
            string durum = gridView1.GetRowCellValue(e.RowHandle, "Durum").ToString();
            string odeme = gridView1.GetRowCellValue(e.RowHandle, "Odeme").ToString();
            if (e.RowHandle > -1 && e.Column.FieldName == "Onem" && onem == "Yüksek")
                e.Appearance.BackColor = Color.OrangeRed;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Onem" && onem == "Orta")
                e.Appearance.BackColor = Color.LightSalmon;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Odeme" && odeme == "Ödendi")
                e.Appearance.BackColor = Color.Green;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Odeme" && odeme == "Ödeme Bekliyor")
                e.Appearance.BackColor = Color.Orange;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && durum == "Araştırılıyor")
                e.Appearance.BackColor = Color.CornflowerBlue;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && durum == "Olumsuz")
                e.Appearance.BackColor = Color.MediumVioletRed;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && durum == "Sipariş")
                e.Appearance.BackColor = Color.LawnGreen;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && durum == "Satın Alma")
                e.Appearance.BackColor = Color.Green;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && durum == "Teklif İletildi")
                e.Appearance.BackColor = Color.LightSeaGreen;
        }
    }
}
