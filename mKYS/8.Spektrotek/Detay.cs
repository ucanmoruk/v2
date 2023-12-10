using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
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
    public partial class Detay : Form
    {
        public Detay()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();
        Liste n = (Liste)System.Windows.Forms.Application.OpenForms["Liste"];

        private void Detay_Load(object sender, EventArgs e)
        {

            basla();

            if (detay == "" || detay == null)
            {
                maxteklifno();
                yeniteklif();
                txt_no.Text = Convert.ToString(maxevrak + 1);
                dateEdit1.EditValue = DateTime.Now;
                DateTime now = DateTime.Now;
                dateEdit2.EditValue = now.AddDays(7);
                btn_kaydet.Text = "Kaydet";
            }
            else
            {
                detaybul();
                tID = detay;
                btn_iptal.Visible = true;
                btn_kaydet.Text = "Güncelle";
            }

           

        }


        void yeniteklif()
        {
            SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
             "insert into STeklifListe (Tarih, Durum, GenelDurum) " +
             "values (@o2,@o3,@o4) SET @ID = SCOPE_IDENTITY() ;" +
             "COMMIT TRANSACTION", bgl.baglanti());
            add2.Parameters.AddWithValue("@o2", DateTime.Now);
            add2.Parameters.AddWithValue("@o3", "Pasif");
            add2.Parameters.AddWithValue("@o4", "Yeni Teklif");
            add2.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
            add2.ExecuteNonQuery();
            tID = add2.Parameters["@ID"].Value.ToString();
            bgl.baglanti().Close();
        }

        void basla()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select Kategori, Marka, Ad, Kod, ID from SStokListe where Durum = N'Aktif' order by Ad asc", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
            gridView2.Columns["ID"].Visible = false;
            this.gridView2.Columns[0].Width = 45;
            this.gridView2.Columns[1].Width = 45;
            this.gridView2.Columns[2].Width = 115;
            this.gridView2.Columns[3].Width = 45;

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select ID, Ad from RootTedarikci where Durum = 'Aktif' and Kimin = 'Spektrotek' order by Ad", bgl.baglanti());
            da2.Fill(dt2);
            gridLookUpEdit1.Properties.DataSource = dt2;
            gridLookUpEdit1.Properties.DisplayMember = "Ad";
            gridLookUpEdit1.Properties.ValueMember = "ID";


        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ekle();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cikar();
        }

        private void gridView2_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }
        }

        private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu2.ShowPopup(p2);
            }
        }

        public static string detay, tID;

        private void Detay_FormClosed(object sender, FormClosedEventArgs e)
        {
            detay = null;
            tID = null;
        }

        private void gridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        public static int maxevrak;
        string b;
        public void maxteklifno()
        {
            SqlCommand komutm = new SqlCommand("select max(TeklifNo) from STeklifListe", bgl.baglanti());
            SqlDataReader drm = komutm.ExecuteReader();
            while (drm.Read())
            {
                b = drm[0].ToString();
                if (b == "" || b == null)
                {
                    maxevrak = 0;
                }
                else
                {
                    maxevrak = Convert.ToInt32(b);
                }
                
            }
            bgl.baglanti().Close();
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "BirimFiyat" || e.Column.FieldName == "Adet" || e.Column.FieldName == "Toplam (KDV Hariç)" || e.Column.FieldName == "KDV(%)")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        string id, co2, o2;
        void ekle()
        {
            for (int i = 0; i < gridView2.SelectedRowsCount; i++)
            {
                id = gridView2.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                o2 = gridView2.GetRowCellValue(y, "ID").ToString();
                SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                    "insert into STeklifDetay (StokID, Durum, TeklifID) " +
                    "values (@o1,@o2,@o3);" +
                    "COMMIT TRANSACTION", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", o2);
                add2.Parameters.AddWithValue("@o2", "Pasif");
                add2.Parameters.AddWithValue("@o3", tID);
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();
            }

            hizmetlistele();
            tekliflistele();

        }

        void cikar()
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show("Seçili hizmetleri kaldırmak istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Secim == DialogResult.Yes)
                {
                    for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                    {
                        id = gridView1.GetSelectedRows()[i].ToString();
                        int y = Convert.ToInt32(id);
                        o2 = gridView1.GetRowCellValue(y, "detayID").ToString();
                        SqlCommand add = new SqlCommand("delete from STeklifDetay where ID = @p2 ", bgl.baglanti());
                        add.Parameters.AddWithValue("@p2", o2);
                        add.ExecuteNonQuery();
                        bgl.baglanti().Close();
                    }

                }
            }
            else
            {
                MessageBox.Show("Neyi mesela ?");
            }

            tekliflistele();
            hizmetlistele();
        }

        void tekliflistele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select h.Kod, CONCAT(h.Marka,' ',h.Ad) as 'Açıklama', d.Miktar as 'Adet', 
            d.Fiyat as 'BirimFiyat', d.KDV as 'KDV (%)', d.Tutar as 'Toplam (KDV Hariç)', d.ID as 'detayID', h.ID as 'NID'
            from STeklifDetay d
            left join SStokListe h on d.StokID = h.ID
            where d.TeklifID = '" + tID + "'", bgl.baglanti());
            // da.SelectCommand.Parameters.AddWithValue("@a1", "0");
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.Columns["detayID"].Visible = false;
            gridView1.Columns["NID"].Visible = false;

            this.gridView1.Columns[0].Width = 50;
            this.gridView1.Columns[1].Width = 120;
            this.gridView1.Columns[2].Width = 50;
            this.gridView1.Columns[3].Width = 50;
            this.gridView1.Columns[4].Width = 50;
            this.gridView1.Columns[5].Width = 55;
            //this.gridView1.Columns[6].Width = 50;

            this.gridView1.Columns[5].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[5].AppearanceCell.BackColor = Color.LemonChiffon;

            RepositoryItemComboBox riComboBox2 = new RepositoryItemComboBox();
            riComboBox2.Items.Add("0");
            riComboBox2.Items.Add("1");
            //   riComboBox2.Items.Add("8");
            riComboBox2.Items.Add("10");
            //   riComboBox2.Items.Add("18");
            riComboBox2.Items.Add("20");
            gridControl1.RepositoryItems.Add(riComboBox2);
            gridView1.Columns["KDV (%)"].ColumnEdit = riComboBox2;

        }

        void hizmetlistele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select Kategori, Marka, Ad, Kod, ID from SStokListe where Durum = N'Aktif' 
            except select Kategori, Marka, Ad, Kod, ID from SStokListe where ID in 
            (select StokID from STeklifDetay where TeklifID = '" + tID + "') order by Ad asc", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
            gridView2.Columns["ID"].Visible = false;


            this.gridView2.Columns[0].Width = 50;
            this.gridView2.Columns[1].Width = 50;
            this.gridView2.Columns[2].Width = 120;
            this.gridView2.Columns[3].Width = 50;
        }

        private void btn_iptal_Click(object sender, EventArgs e)
        {
            iptal();
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            if (btn_kaydet.Text == "Kaydet")
            {
                kaydet();
            }
            else
            {
                guncelle();
            }
        }

        void iptal()
        {

            DialogResult Secim = new DialogResult();

            Secim = MessageBox.Show("Seçili faturayı iptal etmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Secim == DialogResult.Yes)
            {
                SqlCommand komutz = new SqlCommand("update STeklifListe set  Durum=@o6 where ID = '" + tID + "'", bgl.baglanti());
                komutz.Parameters.AddWithValue("@o6", "Pasif");
                //   komutz.Parameters.AddWithValue("@o7", "İptal");
                komutz.ExecuteNonQuery();
                bgl.baglanti().Close();

            }

        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {

            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            id = dr["ID"].ToString();

            //    SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
            //        "insert into MSFatura (HizmetID, Durum, FatID) " +
            //        "values (@o1,@o2,@o3);" +
            //        "COMMIT TRANSACTION", bgl.baglanti());
            //    add2.Parameters.AddWithValue("@o1", id);
            //    add2.Parameters.AddWithValue("@o2", "Pasif");
            //    add2.Parameters.AddWithValue("@o3", tID);
            //    add2.ExecuteNonQuery();
            //    bgl.baglanti().Close();

            //id = gridView2.GetSelectedRows()[i].ToString();
            //int y = Convert.ToInt32(id);
            //o2 = gridView2.GetRowCellValue(y, "ID").ToString();
            SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                "insert into STeklifDetay (StokID, Durum, TeklifID) " +
                "values (@o1,@o2,@o3);" +
                "COMMIT TRANSACTION", bgl.baglanti());
            add2.Parameters.AddWithValue("@o1", id);
            add2.Parameters.AddWithValue("@o2", "Pasif");
            add2.Parameters.AddWithValue("@o3", tID);
            add2.ExecuteNonQuery();
            bgl.baglanti().Close();

            hizmetlistele();
            tekliflistele();
        }

        string notes;
        private void memoEdit1_TextChanged(object sender, EventArgs e)
        {
            notes = "1";
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //çıkar

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            id = dr["detayID"].ToString();
            SqlCommand add = new SqlCommand("delete from STeklifDetay where ID = @p2 ", bgl.baglanti());
            add.Parameters.AddWithValue("@p2", id);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
            hizmetlistele();
            tekliflistele();
        }



        void griddegisince()
        {
            //if (e.Column.FieldName == "KDV")
            //{
            //    //string adet = view.GetRowCellValue(e.RowHandle, view.Columns["BirimFiyat"]).ToString();

            //    // decimal bfiyat = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["BirimFiyat"]).ToString());
            //    decimal KDVoran = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["KDV"]).ToString());
            //    string KDVorans = Convert.ToString(KDVoran);

            //    string isk = Convert.ToString(view.GetRowCellValue(e.RowHandle, view.Columns["Iskonto"]).ToString());
            //    string kon = Convert.ToString(view.GetRowCellValue(e.RowHandle, view.Columns["Adet"]).ToString());
            //    string bfiy = Convert.ToString(view.GetRowCellValue(e.RowHandle, view.Columns["Fiyat"]).ToString());
            //    if (kon == "" || bfiy == "" || kon == null || bfiy == null || isk == "" || isk == null)
            //    {

            //    }
            //    else
            //    {
            //        decimal adet = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["Adet"]).ToString());
            //        decimal birimfiyat = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["Fiyat"]).ToString());
            //        decimal isko = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["Iskonto"]).ToString());

            //        decimal sonf = Math.Round(adet * birimfiyat, 2);
            //        view.SetRowCellValue(e.RowHandle, view.Columns["Tutar (KDVsiz)"], sonf);

            //        if (KDVorans == null || KDVorans == "" || KDVorans == "0")
            //        {
            //            kdvtutar = 0;
            //            if (isk == null || isk == ""|| isk == "0")
            //            {
            //                gtoplam = Math.Round(adet * birimfiyat, 2);
            //                //view.SetRowCellValue(e.RowHandle, view.Columns["KDVTutar"], 0);
            //            }
            //            else
            //            {
            //                decimal aratoplam = (100 - isko) / 100;
            //                gtoplam = Math.Round(adet * birimfiyat * aratoplam, 2);
            //            }

            //        }
            //        else
            //        {

            //            //decimal toplam = Math.Round(adet * birimfiyat , 2);
            //            //decimal sonf = Math.Round(kdv + toplam, 2);
            //            //view.SetRowCellValue(e.RowHandle, view.Columns["Toplam"], sonf);
            //            //view.SetRowCellValue(e.RowHandle, view.Columns["KDVTutar"], kdv);

            //            if (isk == null || isk == "" || isk == "0")
            //            {
            //                decimal kdv = Math.Round(adet * birimfiyat * KDVoran / 100, 2);
            //                gtoplam = Math.Round( (adet * birimfiyat)+kdv, 2);
            //                //view.SetRowCellValue(e.RowHandle, view.Columns["KDVTutar"], 0);
            //            }
            //            else
            //            {
            //                decimal aratoplam = (100 - isko) / 100;
            //                decimal kdv = Math.Round(adet * birimfiyat * aratoplam * KDVoran / 100, 2);                            
            //                gtoplam = Math.Round( (adet * birimfiyat * aratoplam)+kdv, 2);
            //            }

            //        }


            //    }


            //    //txt_aratoplam.Text = gridView1.Columns["Fiyat"].SummaryItem.SummaryValue.ToString();

            //}
            //else if(e.Column.FieldName == "Adet")
            //{
            //    decimal adet = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["Adet"]).ToString());

            //    string isk = Convert.ToString(view.GetRowCellValue(e.RowHandle, view.Columns["Iskonto"]).ToString());
            //    string kon = Convert.ToString(view.GetRowCellValue(e.RowHandle, view.Columns["KDV"]).ToString());
            //    string bfiy = Convert.ToString(view.GetRowCellValue(e.RowHandle, view.Columns["BirimFiyat"]).ToString());
            //    if (kon == "" || bfiy == "" || kon == null || bfiy == null || isk == "" || isk == null)
            //    {

            //    }
            //    else
            //    {
            //        decimal KDVoran = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["KDV"]).ToString());
            //        decimal birimfiyat = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["BirimFiyat"]).ToString());
            //        if (kon == null || kon == "" || kon == "0")
            //        {
            //            decimal sonf = Math.Round(adet * birimfiyat, 2);
            //            view.SetRowCellValue(e.RowHandle, view.Columns["Toplam"], sonf);
            //            view.SetRowCellValue(e.RowHandle, view.Columns["KDVTutar"], 0);
            //        }
            //        else
            //        {
            //            decimal kdv = Math.Round(adet * birimfiyat * KDVoran / 100, 2);
            //            decimal toplam = Math.Round(adet * birimfiyat, 2);
            //            decimal sonf = Math.Round(kdv + toplam, 2);
            //            view.SetRowCellValue(e.RowHandle, view.Columns["Toplam"], sonf);
            //            view.SetRowCellValue(e.RowHandle, view.Columns["KDVTutar"], kdv);
            //        }


            //    }

            //}
            //else if (e.Column.FieldName == "BirimFiyat")
            //{

            //    decimal bfiyat = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["BirimFiyat"]).ToString());

            //    string KDVorans = Convert.ToString(view.GetRowCellValue(e.RowHandle, view.Columns["KDV"]).ToString());
            //    string kon = Convert.ToString(view.GetRowCellValue(e.RowHandle, view.Columns["Adet"]).ToString());

            //    if (kon == "" || kon == null || KDVorans == "" || KDVorans == null)
            //    {

            //    }
            //    else
            //    {
            //        decimal adet = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["Adet"]).ToString());
            //        decimal KDVoran = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["KDV"]).ToString());

            //        if (KDVorans == null || KDVorans == "" || KDVorans == "0")
            //        {
            //            decimal sonf = Math.Round(adet * bfiyat, 2);
            //            view.SetRowCellValue(e.RowHandle, view.Columns["Toplam"], sonf);
            //            view.SetRowCellValue(e.RowHandle, view.Columns["KDVTutar"], 0);
            //        }
            //        else
            //        {
            //            decimal kdv = Math.Round(adet * bfiyat * KDVoran / 100, 2);
            //            decimal toplam = Math.Round(adet * bfiyat, 2);
            //            decimal sonf = Math.Round(kdv + toplam, 2);
            //            view.SetRowCellValue(e.RowHandle, view.Columns["Toplam"], sonf);
            //            view.SetRowCellValue(e.RowHandle, view.Columns["KDVTutar"], kdv);
            //        }


            //    }

            //}
            //else if (e.Column.FieldName == "İskonto")
            //{

            //    decimal bfiyat = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["BirimFiyat"]).ToString());

            //    string KDVorans = Convert.ToString(view.GetRowCellValue(e.RowHandle, view.Columns["KDV"]).ToString());
            //    string kon = Convert.ToString(view.GetRowCellValue(e.RowHandle, view.Columns["Adet"]).ToString());

            //    if (kon == "" || kon == null || KDVorans == "" || KDVorans == null)
            //    {

            //    }
            //    else
            //    {
            //        decimal adet = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["Adet"]).ToString());
            //        decimal KDVoran = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["KDV"]).ToString());

            //        if (KDVorans == null || KDVorans == "" || KDVorans == "0")
            //        {
            //            decimal sonf = Math.Round(adet * bfiyat, 2);
            //            view.SetRowCellValue(e.RowHandle, view.Columns["Toplam"], sonf);
            //            view.SetRowCellValue(e.RowHandle, view.Columns["KDVTutar"], 0);
            //        }
            //        else
            //        {
            //            decimal kdv = Math.Round(adet * bfiyat * KDVoran / 100, 2);
            //            decimal toplam = Math.Round(adet * bfiyat, 2);
            //            decimal sonf = Math.Round(kdv + toplam, 2);
            //            view.SetRowCellValue(e.RowHandle, view.Columns["Toplam"], sonf);
            //            view.SetRowCellValue(e.RowHandle, view.Columns["KDVTutar"], kdv);
            //        }


            //    }

            //}
        }


        decimal kdvtutar, gtoplam;
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.Column.FieldName == "BirimFiyat")
            {

                decimal birimfiyat = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["BirimFiyat"]).ToString());

                string adet = Convert.ToString(view.GetRowCellValue(e.RowHandle, view.Columns["Adet"]).ToString());
                if ( adet=="" || adet == null)
                {

                }
                else
                {
                    decimal adet2 = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["Adet"]).ToString());
                    gtoplam = Math.Round(adet2 * birimfiyat, 2);
                    view.SetRowCellValue(e.RowHandle, view.Columns["Toplam (KDV Hariç)"], gtoplam);

                }

            }
            else if (e.Column.FieldName == "Adet")
            {
                decimal adet2 = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["Adet"]).ToString());          
                string adet = Convert.ToString(view.GetRowCellValue(e.RowHandle, view.Columns["BirimFiyat"]).ToString());
                if (adet == "" || adet == null)
                {

                }
                else
                {
                    decimal birimfiyat = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["BirimFiyat"]).ToString());
                    gtoplam = Math.Round(adet2 * birimfiyat, 2);
                    view.SetRowCellValue(e.RowHandle, view.Columns["Toplam (KDV Hariç)"], gtoplam);
                }


            }

            gridView1.Columns["Toplam (KDV Hariç)"].Summary.Clear();
            GridColumnSummaryItem item = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Toplam", "{0:N}");
            gridView1.Columns["Toplam (KDV Hariç)"].Summary.Add(item);
        }

        decimal gtotal, kdv,iskonto, glistetotal;
        void kaydet()
        {

            try
            {

                if (gridLookUpEdit1.EditValue == null)
                {
                    MessageBox.Show("Lütfen firma seçiniz!");
                }
                else
                {
                    for (int ik = 0; ik < gridView1.RowCount; ik++)
                    {
                        co2 = gridView1.GetRowCellValue(ik, "detayID").ToString();
                        decimal bfiyat = Convert.ToDecimal(gridView1.GetRowCellValue(ik, "BirimFiyat").ToString());
                        string kdv2 = gridView1.GetRowCellValue(ik, "KDV (%)").ToString();
                        if (kdv2 == null || kdv2 == "")
                        {
                            kdv = 0;
                        }
                        else
                        {
                           kdv = Convert.ToDecimal(gridView1.GetRowCellValue(ik, "KDV (%)").ToString());
                        }
                        //string iskonto2 = gridView1.GetRowCellValue(ik, "Iskonto").ToString();
                        //if (iskonto2 == "" || iskonto2 == null)
                        //    iskonto = 0;
                        //else
                        //    iskonto = Convert.ToDecimal(gridView1.GetRowCellValue(ik, "Iskonto").ToString());

                      //  decimal kdvtutar = Convert.ToDecimal(gridView1.GetRowCellValue(ik, "KDVTutar").ToString());
                        int adet = Convert.ToInt32(gridView1.GetRowCellValue(ik, "Adet").ToString());
                        decimal total = Convert.ToDecimal(gridView1.GetRowCellValue(ik, "Toplam (KDV Hariç)").ToString());
                        decimal kdvtutar = Math.Round(total * kdv / 100, 2);
                        decimal geneltutar = total + kdvtutar;
                        SqlCommand komutz = new SqlCommand(@"update STeklifDetay set Miktar=@a1, Birim=@a2, Fiyat=@a3, KDV=@a4,
                        Tutar=@a5, KDVTutar=@a6, GTutar=@a7, Durum=@a8 where ID = '" + co2 + "'", bgl.baglanti());
                        komutz.Parameters.AddWithValue("@a1", adet);
                        komutz.Parameters.AddWithValue("@a2", "Adet");
                        komutz.Parameters.AddWithValue("@a3", bfiyat);
                        komutz.Parameters.AddWithValue("@a4", kdv);
                        komutz.Parameters.AddWithValue("@a5", total);
                        komutz.Parameters.AddWithValue("@a6", kdvtutar);
                        komutz.Parameters.AddWithValue("@a7", geneltutar);
                        komutz.Parameters.AddWithValue("@a8", "Aktif");
                        komutz.ExecuteNonQuery();
                        bgl.baglanti().Close();
                        gtotal += geneltutar;
                    }

                    if (txt_iskonto.Text == "0")
                    {
                        glistetotal = gtotal;
                    }
                    else
                    {
                        decimal isknto = 1 - (Convert.ToDecimal(txt_iskonto.Text) / 100);
                        glistetotal = gtotal * isknto;
                    }
                    
                    SqlCommand komutaz = new SqlCommand(@"update STeklifListe set TeklifNo=@a1, FirmaID=@a2, Tarih=@a3, Gecerlilik=@a4,
                    YetkiliID=@a5, Toplam=@a6, TeklifNot=@a7, Durum=@a8, Iskonto=@a9, Parabirimi=@a10 where ID = '" + tID + "' ", bgl.baglanti());
                    komutaz.Parameters.AddWithValue("@a1", txt_no.Text);
                    komutaz.Parameters.AddWithValue("@a2", gridLookUpEdit1.EditValue);
                    komutaz.Parameters.AddWithValue("@a3", dateEdit1.EditValue);
                    komutaz.Parameters.AddWithValue("@a4", dateEdit2.EditValue);
                    komutaz.Parameters.AddWithValue("@a5", Anasayfa.kullanici);
                    komutaz.Parameters.AddWithValue("@a6", glistetotal);
                    if (notes == "1")
                        komutaz.Parameters.AddWithValue("@a7", memoEdit1.Text);
                    else
                        komutaz.Parameters.AddWithValue("@a7", DBNull.Value);
                    komutaz.Parameters.AddWithValue("@a8", "Aktif");
                    komutaz.Parameters.AddWithValue("@a9", Convert.ToDecimal(txt_iskonto.Text));
                    komutaz.Parameters.AddWithValue("@a10", combo_para.Text);
                    komutaz.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    if (Application.OpenForms["Liste"] == null)
                    {

                    }
                    else
                    {
                        n.listele();
                    }


                    MessageBox.Show("Kaydetme işlemi başarılı. Teklifinizin yazdırılması için bekleyiniz.");
                    this.Close();

                    yazdir();
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata1 : " + ex);
            }

        

        }


        void yazdir()
        {
            mKYS.Raporlar.TeklifMS.tID = tID;

            using (mKYS.Raporlar.frmPrint frm = new mKYS.Raporlar.frmPrint())
            {
                frm.TeklifMS();
                frm.ShowDialog();
            }

        }

        void detaybul()
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select Kategori, Marka, Ad, Kod from SStokListe where Durum = N'Aktif' 
            except select Kategori, Marka, Ad, Kod from SStokListe where ID in 
            (select StokID from STeklifDetay where TeklifID = '" + detay + "') order by Ad asc", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
            gridView2.Columns["ID"].Visible = false;


            DataTable dx = new DataTable();
            SqlDataAdapter dax = new SqlDataAdapter(@"select h.Kod, CONCAT(h.Marka,' ',h.Ad) as 'Açıklama', d.Miktar as 'Adet', 
            d.Fiyat as 'BirimFiyat', d.KDV as 'KDV (%)', d.Tutar as 'Toplam (KDV Hariç)', d.ID as 'detayID', h.ID as 'NID'
            from STeklifDetay d
            left join SStokListe h on d.StokID = h.ID
            where d.TeklifID = '" + detay + "'", bgl.baglanti());
            dax.Fill(dx);
            gridControl1.DataSource = dx;
            gridView1.Columns["detayID"].Visible = false;
            gridView1.Columns["NID"].Visible = false;

            this.gridView1.Columns[0].Width = 50;
            this.gridView1.Columns[1].Width = 120;
            this.gridView1.Columns[2].Width = 50;
            this.gridView1.Columns[3].Width = 50;
            this.gridView1.Columns[4].Width = 50;
            this.gridView1.Columns[5].Width = 55;

            this.gridView1.Columns[5].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[5].AppearanceCell.BackColor = Color.LemonChiffon;

            GridColumnSummaryItem item = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Toplam", "{0:N}");
            gridView1.Columns["Toplam (KDV Hariç)"].Summary.Add(item);

            SqlCommand komut = new SqlCommand("select * from STeklifListe where ID = '" + detay + "'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                //combo_tur.Text = dr["TeklifTuru"].ToString();
                gridLookUpEdit1.EditValue = dr["FirmaID"].ToString();
                txt_no.Text = dr["TeklifNo"].ToString();
                dateEdit1.EditValue = Convert.ToDateTime(dr["Tarih"].ToString());
                dateEdit2.EditValue = Convert.ToDateTime(dr["Gecerlilik"].ToString());
                memoEdit1.Text = dr["TeklifNot"].ToString();
                combo_para.Text = dr["ParaBirimi"].ToString();
                txt_iskonto.Text = dr["Iskonto"].ToString();
            }
            bgl.baglanti().Close();

        }


        void guncelle()
        {
            try
            {

                if (gridLookUpEdit1.EditValue == null)
                {
                    MessageBox.Show("Lütfen firma seçiniz!");
                }
                else
                {
                    //for (int ik = 0; ik < gridView1.RowCount; ik++)
                    //{
                    //    co2 = gridView1.GetRowCellValue(ik, "detayID").ToString();
                    //    decimal bfiyat = Convert.ToDecimal(gridView1.GetRowCellValue(ik, "BirimFiyat").ToString());
                    //    string kdv2 = gridView1.GetRowCellValue(ik, "KDV").ToString();
                    //    if (kdv2 == null || kdv2 == "")
                    //    {
                    //        kdv = 0;
                    //    }
                    //    else
                    //    {
                    //        kdv = Convert.ToDecimal(gridView1.GetRowCellValue(ik, "KDV").ToString());
                    //    }
                    //    decimal kdvtutar = Convert.ToDecimal(gridView1.GetRowCellValue(ik, "KDVTutar").ToString());
                    //    int adet = Convert.ToInt32(gridView1.GetRowCellValue(ik, "Adet").ToString());
                    //    decimal total = Convert.ToDecimal(gridView1.GetRowCellValue(ik, "Toplam").ToString());
                    //    SqlCommand komutz = new SqlCommand("update MSFatura set  BirimFiyat = @o2, Adet = @o4, Toplam = @o5, Durum=@o6 , FatID = @o7, KDV = @o8, KDVTutar = @o9 where ID = '" + co2 + "' ", bgl.baglanti());
                    //    komutz.Parameters.AddWithValue("@o2", bfiyat);
                    //    komutz.Parameters.AddWithValue("@o4", adet);
                    //    komutz.Parameters.AddWithValue("@o5", total);
                    //    komutz.Parameters.AddWithValue("@o6", "Aktif");
                    //    komutz.Parameters.AddWithValue("@o7", tID);
                    //    komutz.Parameters.AddWithValue("@o8", kdv);
                    //    komutz.Parameters.AddWithValue("@o9", kdvtutar);
                    //    komutz.ExecuteNonQuery();
                    //    bgl.baglanti().Close();
                    //    gtotal += total;

                    //}


                    //SqlCommand komutaz = new SqlCommand(@"update MSListe set FirmaID = @a2, Tarih=@a3, Total=@a4 , FatNo = @a6, Notlar=@a7 where ID = '" + tID + "' ", bgl.baglanti());
                    //komutaz.Parameters.AddWithValue("@a2", gridLookUpEdit1.EditValue);
                    //komutaz.Parameters.AddWithValue("@a3", dateEdit1.EditValue);
                    //komutaz.Parameters.AddWithValue("@a4", gtotal);
                    //komutaz.Parameters.AddWithValue("@a6", txt_no.Text);
                    //komutaz.Parameters.AddWithValue("@a7", memoEdit1.Text);
                    //komutaz.ExecuteNonQuery();
                    //bgl.baglanti().Close();

                    for (int ik = 0; ik < gridView1.RowCount; ik++)
                    {
                        co2 = gridView1.GetRowCellValue(ik, "detayID").ToString();
                        decimal bfiyat = Convert.ToDecimal(gridView1.GetRowCellValue(ik, "BirimFiyat").ToString());
                        string kdv2 = gridView1.GetRowCellValue(ik, "KDV (%)").ToString();
                        if (kdv2 == null || kdv2 == "")
                        {
                            kdv = 0;
                        }
                        else
                        {
                            kdv = Convert.ToDecimal(gridView1.GetRowCellValue(ik, "KDV (%)").ToString());
                        }
                        int adet = Convert.ToInt32(gridView1.GetRowCellValue(ik, "Adet").ToString());
                        decimal total = Convert.ToDecimal(gridView1.GetRowCellValue(ik, "Toplam (KDV Hariç)").ToString());
                        decimal kdvtutar = Math.Round(total * kdv / 100, 2);
                        decimal geneltutar = total + kdvtutar;
                        SqlCommand komutz = new SqlCommand(@"update STeklifDetay set Miktar=@a1, Birim=@a2, Fiyat=@a3, KDV=@a4,
                        Tutar=@a5, KDVTutar=@a6, GTutar=@a7, Durum=@a8 where ID = '" + co2 + "'", bgl.baglanti());
                        komutz.Parameters.AddWithValue("@a1", adet);
                        komutz.Parameters.AddWithValue("@a2", "Adet");
                        komutz.Parameters.AddWithValue("@a3", bfiyat);
                        komutz.Parameters.AddWithValue("@a4", kdv);
                        komutz.Parameters.AddWithValue("@a5", total);
                        komutz.Parameters.AddWithValue("@a6", kdvtutar);
                        komutz.Parameters.AddWithValue("@a7", geneltutar);
                        komutz.Parameters.AddWithValue("@a8", "Aktif");
                        komutz.ExecuteNonQuery();
                        bgl.baglanti().Close();
                        gtotal += geneltutar;
                    }

                    if (txt_iskonto.Text == "0")
                    {
                        glistetotal = gtotal;
                    }
                    else
                    {
                        decimal isknto = 1 - (Convert.ToDecimal(txt_iskonto.Text) / 100);
                        glistetotal = gtotal * isknto;
                    }

                    SqlCommand komutaz = new SqlCommand(@"update STeklifListe set TeklifNo=@a1, FirmaID=@a2, Tarih=@a3, Gecerlilik=@a4,
                    YetkiliID=@a5, Toplam=@a6, TeklifNot=@a7, Durum=@a8, Iskonto=@a9, Parabirimi=@a10 where ID = '" + tID + "' ", bgl.baglanti());
                    komutaz.Parameters.AddWithValue("@a1", txt_no.Text);
                    komutaz.Parameters.AddWithValue("@a2", gridLookUpEdit1.EditValue);
                    komutaz.Parameters.AddWithValue("@a3", dateEdit1.EditValue);
                    komutaz.Parameters.AddWithValue("@a4", dateEdit2.EditValue);
                    komutaz.Parameters.AddWithValue("@a5", Anasayfa.kullanici);
                    komutaz.Parameters.AddWithValue("@a6", glistetotal);
                    if (notes == "1")
                        komutaz.Parameters.AddWithValue("@a7", memoEdit1.Text);
                    else
                        komutaz.Parameters.AddWithValue("@a7", DBNull.Value);
                    komutaz.Parameters.AddWithValue("@a8", "Aktif");
                    komutaz.Parameters.AddWithValue("@a9", Convert.ToDecimal(txt_iskonto.Text));
                    komutaz.Parameters.AddWithValue("@a10", combo_para.Text);
                    komutaz.ExecuteNonQuery();
                    bgl.baglanti().Close();


                    if (Application.OpenForms["Liste"] == null)
                    {

                    }
                    else
                    {
                        n.listele();
                    }

                    MessageBox.Show("Güncelleme işlemi başarılı. Teklifinizin yazdırılması için bekleyiniz.");
                    this.Close();

                    yazdir();
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata1 : " + ex);
            }

          
        }


    
    }
    
}
