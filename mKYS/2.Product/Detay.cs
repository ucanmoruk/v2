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

namespace mROOT._2.Product
{
    public partial class TeklifDetay : Form
    {
        public TeklifDetay()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();
        TeklifListe n = (TeklifListe)System.Windows.Forms.Application.OpenForms["TeklifListe"];

        public static double bfiyat = 0.0;
        private double indirim = 0.0;
        private double Euro = 0.0;
        private double Dolar = 0.0;
        private double GBP = 0.0;
        private DataSet dsDovizKur;

        private void Detay_Load(object sender, EventArgs e)
        {

            basla();
            DovizKur();

            if (detay == "" || detay == null)
            {
                maxteklifno();
                yeniteklif();
                txt_no.Text = Convert.ToString(maxevrak + 1);
                dateEdit1.EditValue = DateTime.Now;
                DateTime now = DateTime.Now;
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

        private void DovizKur()
        {
            dsDovizKur = new DataSet();
            dsDovizKur.ReadXml(@"https://www.tcmb.gov.tr/kurlar/today.xml");
            DataRow dr = dsDovizKur.Tables[1].Rows[0];
            Dolar = Convert.ToDouble(dr[6].ToString().Replace('.', ','));
            lbl_dolar.Text = "$ - Günlük DOLAR Efektif Satış Kuru: " + Dolar.ToString();

            dr = dsDovizKur.Tables[1].Rows[3];
            Euro = Convert.ToDouble(dr[6].ToString().Replace('.', ','));
            lbl_euro.Text = "€ - Günlük EURO Efektif Satış Kuru: " + Euro.ToString();

            dr = dsDovizKur.Tables[1].Rows[4];
            GBP = Convert.ToDouble(dr[6].ToString().Replace('.', ','));
            lbl_gpt.Text = "£ - Günlük GBP Efektif Satış Kuru: " + GBP.ToString();

        }

        void yeniteklif()
        {
            SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
             "insert into rTeklifListe (Tarih, Durum, GenelDurum) " +
             "values (@o2,@o3,@o4) SET @ID = SCOPE_IDENTITY() ;" +
             "COMMIT TRANSACTION", bgl.baglanti());
            add2.Parameters.AddWithValue("@o2", DateTime.Now);
            add2.Parameters.AddWithValue("@o3", "Pasif");
            add2.Parameters.AddWithValue("@o4", "Yeni Sipariş");
            add2.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
            add2.ExecuteNonQuery();
            tID = add2.Parameters["@ID"].Value.ToString();
            bgl.baglanti().Close();
        }

        void basla()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select Kategori, Kod, Marka, Seri+' '+Ad as 'Ad', Hacim, Fiyat, ID from RootUrunListesi where Durum = N'Aktif' order by Kategori asc", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
            gridView2.Columns["ID"].Visible = false;
            this.gridView2.Columns[0].Width = 45;
            this.gridView2.Columns[1].Width = 45;
            this.gridView2.Columns[2].Width = 55;
            this.gridView2.Columns[3].Width = 115;
            this.gridView2.Columns[4].Width = 40;
            this.gridView2.Columns[5].Width = 55;

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select ID, Ad from RootTedarikci where Durum = 'Aktif' order by Ad", bgl.baglanti());
            da2.Fill(dt2);
            gridLookUpEdit1.Properties.DataSource = dt2;
            gridLookUpEdit1.Properties.DisplayMember = "Ad";
            gridLookUpEdit1.Properties.ValueMember = "ID";

            DataTable dt12 = new DataTable();
            SqlDataAdapter da12 = new SqlDataAdapter("Select ID, Ad From RootKullanici where Durum= N'Aktif'", bgl.baglanti());
            da12.Fill(dt12);
            gridLookUpEdit2.Properties.DataSource = dt12;
            gridLookUpEdit2.Properties.DisplayMember = "Ad";
            gridLookUpEdit2.Properties.ValueMember = "ID";


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
            SqlCommand komutm = new SqlCommand("select max(TeklifNo) from rTeklifListe", bgl.baglanti());
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
                decimal fiyat = Convert.ToDecimal(gridView2.GetRowCellValue(y, "Fiyat").ToString());
                SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                    "insert into rTeklifDetay (UrunID, Durum, TeklifID, KDV, Fiyat) " +
                    "values (@o1,@o2,@o3, @o4, @o5);" +
                    "COMMIT TRANSACTION", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", o2);
                add2.Parameters.AddWithValue("@o2", "Pasif");
                add2.Parameters.AddWithValue("@o3", tID);
                add2.Parameters.AddWithValue("@o4", 20);
                add2.Parameters.AddWithValue("@o5", fiyat);
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();
            }

           // hizmetlistele();
            tekliflistele();

        }

        void cikar()
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show("Seçili ürünleri kaldırmak istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Secim == DialogResult.Yes)
                {
                    for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                    {
                        id = gridView1.GetSelectedRows()[i].ToString();
                        int y = Convert.ToInt32(id);
                        o2 = gridView1.GetRowCellValue(y, "detayID").ToString();
                        SqlCommand add = new SqlCommand("delete from rTeklifDetay where ID = @p2 ", bgl.baglanti());
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
           // hizmetlistele();
        }

        void tekliflistele()
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select h.Kod, CONCAT(h.Marka, CASE 
            WHEN h.Seri IS NOT NULL AND h.Seri <> '' THEN CONCAT(' ', h.Seri)
            ELSE '' END, ' ',h.Ad, ' - ',h.Hacim) as 'Açıklama', d.Miktar as 'Adet', 
            d.Fiyat as 'BirimFiyat', d.KDV as 'KDV (%)', d.Tutar as 'Toplam (KDV Hariç)', d.ID as 'detayID', h.ID as 'NID'
            from rTeklifDetay d
            left join RootUrunListesi h on d.UrunID = h.ID
            where d.TeklifID = '" + tID + "' order by h.Kategori", bgl.baglanti());
            // da.SelectCommand.Parameters.AddWithValue("@a1", "0");
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.Columns["detayID"].Visible = false;
            gridView1.Columns["NID"].Visible = false;

            this.gridView1.Columns[0].Width = 50;
            this.gridView1.Columns[1].Width = 220;
            this.gridView1.Columns[2].Width = 50;
            this.gridView1.Columns[3].Width = 50;
            this.gridView1.Columns[4].Width = 50;
            this.gridView1.Columns[5].Width = 55;
            //this.gridView1.Columns[6].Width = 50;

            this.gridView1.Columns[5].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[5].AppearanceCell.BackColor = Color.LemonChiffon;

            //RepositoryItemComboBox riComboBox2 = new RepositoryItemComboBox();
            //riComboBox2.Items.Add("0");
            //riComboBox2.Items.Add("1");
            ////   riComboBox2.Items.Add("8");
            //riComboBox2.Items.Add("10");
            ////   riComboBox2.Items.Add("18");
            //riComboBox2.Items.Add("20");
            //gridControl1.RepositoryItems.Add(riComboBox2);
            //gridView1.Columns["KDV (%)"].ColumnEdit = riComboBox2;



        }

        void hizmetlistele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select Kategori, Kod, Marka, Seri+' '+Ad as 'Ad', Hacim, Fiyat, ID from RootUrunListesi where Durum = N'Aktif' order by Kategori asc", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
            gridView2.Columns["ID"].Visible = false;
            this.gridView2.Columns[0].Width = 45;
            this.gridView2.Columns[1].Width = 45;
            this.gridView2.Columns[2].Width = 55;
            this.gridView2.Columns[3].Width = 115;
            this.gridView2.Columns[4].Width = 40;
            this.gridView2.Columns[5].Width = 55;


            //DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter(@"select Kategori, Marka, Ad, Kod, ID from SStokListe where Durum = N'Aktif' 
            //except select Kategori, Marka, Ad, Kod, ID from SStokListe where ID in 
            //(select StokID from STeklifDetay where TeklifID = '" + tID + "') order by Ad asc", bgl.baglanti());
            //da.Fill(dt);
            //gridControl2.DataSource = dt;
            //gridView2.Columns["ID"].Visible = false;


            //this.gridView2.Columns[0].Width = 50;
            //this.gridView2.Columns[1].Width = 50;
            //this.gridView2.Columns[2].Width = 120;
            //this.gridView2.Columns[3].Width = 50;
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

            Secim = MessageBox.Show("Bu teklifi iptal etmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Secim == DialogResult.Yes)
            {
                SqlCommand komutz = new SqlCommand("update rTeklifListe set Durum=@o6 where ID = '" + tID + "'", bgl.baglanti());
                komutz.Parameters.AddWithValue("@o6", "Pasif");
                //   komutz.Parameters.AddWithValue("@o7", "İptal");
                komutz.ExecuteNonQuery();
                bgl.baglanti().Close();

            }

        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            ekle();

            //DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            //id = dr["ID"].ToString();

            //SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
            //    "insert into rTeklifDetay (UrunID, Durum, TeklifID) " +
            //    "values (@o1,@o2,@o3);" +
            //    "COMMIT TRANSACTION", bgl.baglanti());
            //add2.Parameters.AddWithValue("@o1", id);
            //add2.Parameters.AddWithValue("@o2", "Pasif");
            //add2.Parameters.AddWithValue("@o3", tID);
            //add2.ExecuteNonQuery();
            //bgl.baglanti().Close();

            //hizmetlistele();
            //tekliflistele();
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
            SqlCommand add = new SqlCommand("delete from rTeklifDetay where ID = @p2 ", bgl.baglanti());
            add.Parameters.AddWithValue("@p2", id);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
           // hizmetlistele();
            tekliflistele();
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

            //// Summary değerlerini güncelle
            //gridView1.UpdateTotalSummary();

            //// İlgili sütunun toplamını al
            //var summary = gridView1.Columns["Toplam (KDV Hariç)"].SummaryItem;
            //object totalValue = gridView1.Columns["Toplam (KDV Hariç)"].SummaryItem.SummaryValue;
            //t_total.Text = totalValue.ToString();

            //var summary2 = gridView1.Columns["KDV (%)"].SummaryItem;
            //object totalValue2 = gridView1.Columns["KDV (%)"].SummaryItem.SummaryValue;
            //t_kdv.Text = totalValue.ToString();


            ////var summary = gridView1.Columns["Toplam (KDV Hariç)"].SummaryItem;
            ////object totalValue = summary?.SummaryValue ?? 0;
            ////t_total.Text = Convert.ToDecimal(totalValue).ToString("N2");


            ////var summary2 = gridView1.Columns["KDV (%)"].SummaryItem;
            ////object totalValue2 = summary2?.SummaryValue ?? 0;
            ////t_kdv.Text = Convert.ToDecimal(totalValue2).ToString("N2");

            totalhesapla();

        }

        decimal gtotal, kdv,iskonto, glistetotal;

        private void gridView1_CellValueChanged_1(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
         

            
        }

        private void txt_iskonto_TextChanged(object sender, EventArgs e)
        {
            decimal iskontoOrani = 0;
            if (!decimal.TryParse(txt_iskonto.Text, out iskontoOrani)) iskontoOrani = 0;

            decimal kdvToplam = 0;
            decimal netToplam = 0;

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                // Orijinal tutarı al
                object orjTutarObj = gridView1.GetRowCellValue(i, "Toplam (KDV Hariç)");
                object kdvYuzdeObj = gridView1.GetRowCellValue(i, "KDV (%)");

                if (orjTutarObj != null && kdvYuzdeObj != null &&
                    decimal.TryParse(orjTutarObj.ToString(), out decimal orjTutar) &&
                    decimal.TryParse(kdvYuzdeObj.ToString(), out decimal kdvYuzde))
                {
                    // İskonto uygulanmış tutarı hesapla
                    decimal iskontoTutari = (orjTutar * iskontoOrani) / 100;
                    decimal indirimliTutar = orjTutar - iskontoTutari;

                    // KDV hesapla
                    decimal kdvTutari = (indirimliTutar * kdvYuzde) / 100;

                    // Toplamlara ekle
                    netToplam += indirimliTutar;
                    kdvToplam += kdvTutari;

                    // İstersen grid’e de yeni değerleri yazabilirsin (gösterim için)
                    // Örneğin: gridView1.SetRowCellValue(i, "Yeni Tutar", indirimliTutar);
                }
            }

            // Aratoplam ve genel toplam textbox'larına yaz
            decimal aratoplam = (netToplam * iskontoOrani) / (100 - iskontoOrani); // İsteğe bağlı
            decimal genelToplam = netToplam + kdvToplam;

            // t_total.Text = netToplam.ToString("N2");
            t_iskonto.Text = aratoplam.ToString("N2");
            t_aratop.Text = netToplam.ToString("N2");
            t_kdv.Text = kdvToplam.ToString("N2");
            t_genel.Text = genelToplam.ToString("N2");
       


        }

        private void t_iskonto_EditValueChanged(object sender, EventArgs e)
        {
         
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void txt_iskonto_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void combo_para_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gridLookUpEdit2_QueryPopUp_1(object sender, CancelEventArgs e)
        {
            //ID
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        private void t_kdv_TextChanged(object sender, EventArgs e)
        {
            //KDV değişince
        }

        private void t_iskonto_TextChanged(object sender, EventArgs e)
        {
            decimal netToplam = 0;
            decimal iskontoTutari = 0;
            decimal kdvToplam = 0;
            decimal araToplam = 0;

            // Net toplamı oku
            decimal.TryParse(t_total.Text, out netToplam);

            // Girilen iskonto tutarını oku
            decimal.TryParse(t_iskonto.Text, out iskontoTutari);

            // Yeni net tutar = toplam - iskonto
            decimal indirimliNet = netToplam - iskontoTutari;

            // Grid'deki her satıra göre KDV hesapla
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                object satirTutarObj = gridView1.GetRowCellValue(i, "Toplam (KDV Hariç)");
                object kdvYuzdeObj = gridView1.GetRowCellValue(i, "KDV (%)");

                if (satirTutarObj != null && kdvYuzdeObj != null &&
                    decimal.TryParse(satirTutarObj.ToString(), out decimal satirTutar) &&
                    decimal.TryParse(kdvYuzdeObj.ToString(), out decimal kdvYuzde))
                {

                    // İlk önce toplamın sıfır olup olmadığını kontrol et
                    if (netToplam == 0)
                    {
                        // Bölme yapılmamalı, oran 0 kabul edilsin veya işlem atlanabilir
                        continue; // ya da oran = 0;
                    }


                    // Satırın toplam içindeki oranı
                    decimal oran = satirTutar / netToplam;

                    // Satıra düşen indirimli tutar
                    decimal satirIndirimliTutar = satirTutar - (iskontoTutari * oran);

                    // Yeni KDV hesapla
                    decimal kdv = (satirIndirimliTutar * kdvYuzde) / 100;
                    kdvToplam += kdv;
                    araToplam += satirIndirimliTutar;
                }
            }

            // Genel toplam = indirimli net + kdv
            decimal genelToplam = indirimliNet + kdvToplam;

            // Sonuçları textbox'lara yaz
            t_aratop.Text = araToplam.ToString("N2");
            t_kdv.Text = kdvToplam.ToString("N2");
            t_genel.Text = genelToplam.ToString("N2");
        }


        void totalhesapla()
        {
            decimal toplam = 0;
            decimal iskontoOrani = 0;
            decimal kdv = 0;
            decimal iskontoTutari = 0;
            decimal genelToplam = 0;
            decimal toplamNet = 0; //
            decimal toplamKdv = 0; //
            decimal aratoplam = 0;

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                var netObj = gridView1.GetRowCellValue(i, "Toplam (KDV Hariç)");
                var kdvObj = gridView1.GetRowCellValue(i, "KDV (%)");

                if (decimal.TryParse(Convert.ToString(netObj), out decimal net))
                    toplamNet += net;

                if (decimal.TryParse(Convert.ToString(kdvObj), out decimal kdv1))
                    toplamKdv += (net * kdv1) / 100;
            }

            t_total.Text = toplamNet.ToString("N2");
            t_kdv.Text = toplamKdv.ToString("N2");

            // Güvenli şekilde değerleri parse et
            decimal.TryParse(t_total.Text, out toplam);
            decimal.TryParse(txt_iskonto.Text, out iskontoOrani);
            decimal.TryParse(t_kdv.Text, out kdv);

            // İskonto tutarını hesapla
            iskontoTutari = (toplam * iskontoOrani) / 100;
            t_iskonto.Text = iskontoTutari.ToString("N2");

            // Genel toplam = Toplam - İskonto + KDV
            aratoplam = toplam - iskontoTutari;
            t_aratop.Text = aratoplam.ToString("N2");
            genelToplam = (toplam - iskontoTutari) + kdv;
            t_genel.Text = genelToplam.ToString("N2");





        }

        private void gridLookUpEdit2_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

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
                        SqlCommand komutz = new SqlCommand(@"update rTeklifDetay set Miktar=@a1, Birim=@a2, Fiyat=@a3, KDV=@a4,
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
                    
                    SqlCommand komutaz = new SqlCommand(@"update rTeklifListe set TeklifNo=@a1, FirmaID=@a2, Tarih=@a3, 
                    YetkiliID=@a5, Toplam=@a6, TeklifNot=@a7, Durum=@a8, Iskonto=@a9, Parabirimi=@a10, KDV=@a11, IskontoOran=@a12, Tur=@a13 where ID = '" + tID + "' ", bgl.baglanti());
                    komutaz.Parameters.AddWithValue("@a1", Convert.ToInt32(txt_no.Text));
                    komutaz.Parameters.AddWithValue("@a2", gridLookUpEdit1.EditValue);
                    komutaz.Parameters.AddWithValue("@a3", dateEdit1.EditValue);
                    komutaz.Parameters.AddWithValue("@a5", gridLookUpEdit2.EditValue);
                    komutaz.Parameters.AddWithValue("@a6", Convert.ToDecimal(t_genel.Text));
                    komutaz.Parameters.AddWithValue("@a7", memoEdit1.Text);
                    komutaz.Parameters.AddWithValue("@a8", "Aktif");
                    komutaz.Parameters.AddWithValue("@a9", Convert.ToDecimal(t_iskonto.Text));
                    komutaz.Parameters.AddWithValue("@a10", combo_para.Text);
                    komutaz.Parameters.AddWithValue("@a11", Convert.ToDecimal(t_kdv.Text));
                    komutaz.Parameters.AddWithValue("@a12", Convert.ToDecimal(txt_iskonto.Text));
                    komutaz.Parameters.AddWithValue("@a13", c_tur.Text);
                    komutaz.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    if (Application.OpenForms["TeklifListe"] == null)
                    {

                    }
                    else
                    {
                        n.listele();
                    }


                    MessageBox.Show("Kaydetme işlemi başarılı. Sipariş formunuzun yazdırılması için bekleyiniz.");
                    

                    yazdir();
                    this.Close();
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata1 : " + ex);
            }

        

        }

        void yazdir()
        {
            if (c_tur.Text == "Satış")
            {
                mKYS.Raporlar.SiparisFormu.tID = tID;

                using (mKYS.Raporlar.frmPrint frm = new mKYS.Raporlar.frmPrint())
                {
                    frm.SiparisFormu();
                    frm.ShowDialog();
                }
            }
            else
            {
                mKYS.Raporlar.UretimFormu.tID = tID;
                mKYS.Raporlar.FasonFormu.tID = tID;

                using (mKYS.Raporlar.frmPrint frm = new mKYS.Raporlar.frmPrint())
                {
                    frm.fasonform();
                    frm.ShowDialog();
                }
            }
           

        }

        void detaybul()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select Kategori, Kod, Marka, Seri+' '+Ad as 'Ad', Hacim, Fiyat, ID from RootUrunListesi where Durum = N'Aktif' order by Ad asc", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
            gridView2.Columns["ID"].Visible = false;
            this.gridView2.Columns[0].Width = 45;
            this.gridView2.Columns[1].Width = 45;
            this.gridView2.Columns[2].Width = 55;
            this.gridView2.Columns[3].Width = 115;
            this.gridView2.Columns[4].Width = 40;
            this.gridView2.Columns[5].Width = 55;


            //DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter(@"select Kategori, Marka, Ad, Kod from SStokListe where Durum = N'Aktif' 
            //except select Kategori, Marka, Ad, Kod from SStokListe where ID in 
            //(select StokID from STeklifDetay where TeklifID = '" + detay + "') order by Ad asc", bgl.baglanti());
            //da.Fill(dt);
            //gridControl2.DataSource = dt;
            //gridView2.Columns["ID"].Visible = false;


            DataTable dx = new DataTable();
            SqlDataAdapter dax = new SqlDataAdapter(@"select h.Kod, CONCAT(h.Marka, CASE 
            WHEN h.Seri IS NOT NULL AND h.Seri <> '' THEN CONCAT(' ', h.Seri)
            ELSE '' END, ' ', h.Ad, '-',h.Hacim) as 'Açıklama', d.Miktar as 'Adet', 
            d.Fiyat as 'BirimFiyat', d.KDV as 'KDV (%)', d.Tutar as 'Toplam (KDV Hariç)', d.ID as 'detayID', h.ID as 'NID'
            from rTeklifDetay d
            left join RootUrunListesi h on d.UrunID = h.ID
            where d.TeklifID = '" + detay + "' order by h.Kategori", bgl.baglanti());
            dax.Fill(dx);
            gridControl1.DataSource = dx;
            gridView1.Columns["detayID"].Visible = false;
            gridView1.Columns["NID"].Visible = false;

            this.gridView1.Columns[0].Width = 50;
            this.gridView1.Columns[1].Width = 220;
            this.gridView1.Columns[2].Width = 50;
            this.gridView1.Columns[3].Width = 50;
            this.gridView1.Columns[4].Width = 50;
            this.gridView1.Columns[5].Width = 55;

            this.gridView1.Columns[5].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[5].AppearanceCell.BackColor = Color.LemonChiffon;

            GridColumnSummaryItem item = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Toplam", "{0:N}");
            gridView1.Columns["Toplam (KDV Hariç)"].Summary.Add(item);

            SqlCommand komut = new SqlCommand("select * from rTeklifListe where ID = '" + detay + "'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                //combo_tur.Text = dr["TeklifTuru"].ToString();
                gridLookUpEdit1.EditValue = dr["FirmaID"].ToString();
                gridLookUpEdit2.EditValue = dr["YetkiliID"].ToString();
                txt_no.Text = dr["TeklifNo"].ToString();
                dateEdit1.EditValue = Convert.ToDateTime(dr["Tarih"].ToString());
                memoEdit1.Text = dr["TeklifNot"].ToString();
                combo_para.Text = dr["ParaBirimi"].ToString();
                txt_iskonto.Text = dr["IskontoOran"].ToString();
                t_iskonto.Text = dr["Iskonto"].ToString();
                t_kdv.Text = dr["KDV"].ToString();
                c_tur.Text = dr["Tur"].ToString();
            }
            bgl.baglanti().Close();

            decimal kdvToplam = 0;
            decimal toplamNet = 0;
            decimal aratoplam = 0;

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                object toplamObj = gridView1.GetRowCellValue(i, "Toplam (KDV Hariç)");
               // object kdvYuzdeObj = gridView1.GetRowCellValue(i, "KDV (%)");

                if (toplamObj != null &&
                    decimal.TryParse(toplamObj.ToString(), out decimal toplam2))
                {
                    toplamNet += toplam2;
                }

                //if (toplamObj != null && kdvYuzdeObj != null &&
                //    decimal.TryParse(toplamObj.ToString(), out toplam2) &&
                //    decimal.TryParse(kdvYuzdeObj.ToString(), out decimal kdvYuzde))
                //{
                //    kdvToplam += (toplam2 * kdvYuzde) / 100;
                //}
            }

            t_total.Text = toplamNet.ToString("N2"); // Net tutarı
            // t_kdv.Text = kdvToplam.ToString("N2");     // KDV toplamı

            if (decimal.TryParse(t_total.Text, out decimal toplam) &&
            // decimal.TryParse(txt_iskonto.Text, out decimal iskonto) &&
             decimal.TryParse(t_iskonto.Text, out decimal iskonto) &&
             decimal.TryParse(t_kdv.Text, out decimal kdv))
            {
                //aratoplam = (toplam * iskonto) / 100;
                //t_iskonto.Text = aratoplam.ToString("N2");
                //decimal geneltoplam = (toplam - aratoplam) + kdv;
                //t_genel.Text = geneltoplam.ToString("N2");

                aratoplam = (toplam - iskonto);
                t_aratop.Text = aratoplam.ToString();
            }
            else
            {
                MessageBox.Show("Toplam veya İskonto değeri geçersiz!");
            }


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
                        SqlCommand komutz = new SqlCommand(@"update rTeklifDetay set Miktar=@a1, Birim=@a2, Fiyat=@a3, KDV=@a4,
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

                    SqlCommand komutaz = new SqlCommand(@"update rTeklifListe set TeklifNo=@a1, FirmaID=@a2, Tarih=@a3,
                    YetkiliID=@a5, Toplam=@a6, TeklifNot=@a7, Durum=@a8, Iskonto=@a9, Parabirimi=@a10, KDV=@a11, IskontoOran=@a12, Tur=@a13 where ID = '" + tID + "' ", bgl.baglanti());
                    komutaz.Parameters.AddWithValue("@a1", Convert.ToInt32(txt_no.Text));
                    komutaz.Parameters.AddWithValue("@a2", gridLookUpEdit1.EditValue);
                    komutaz.Parameters.AddWithValue("@a3", dateEdit1.EditValue);
                    komutaz.Parameters.AddWithValue("@a5", gridLookUpEdit2.EditValue);
                    komutaz.Parameters.AddWithValue("@a6", Convert.ToDecimal(t_genel.Text));
                    komutaz.Parameters.AddWithValue("@a7", memoEdit1.Text);
                    komutaz.Parameters.AddWithValue("@a8", "Aktif");
                    komutaz.Parameters.AddWithValue("@a9", Convert.ToDecimal(t_iskonto.Text));
                    komutaz.Parameters.AddWithValue("@a10", combo_para.Text);
                    komutaz.Parameters.AddWithValue("@a11", Convert.ToDecimal(t_kdv.Text));
                    komutaz.Parameters.AddWithValue("@a12", Convert.ToDecimal(txt_iskonto.Text));
                    komutaz.Parameters.AddWithValue("@a13", c_tur.Text);
                    komutaz.ExecuteNonQuery();
                    bgl.baglanti().Close();


                    if (Application.OpenForms["TeklifListe"] == null)
                    {

                    }
                    else
                    {
                        n.listele();
                    }

                    MessageBox.Show("Güncelleme işlemi başarılı. Sipariş formunun yazdırılması için bekleyiniz.");


                    //mKYS.Raporlar.SiparisFormu.tID = detay;

                    //using (mKYS.Raporlar.frmPrint frm = new mKYS.Raporlar.frmPrint())
                    //{
                    //    frm.SiparisFormu();
                    //    frm.ShowDialog();
                    //}
                    yazdir();

                    this.Close();
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata1 : " + ex);
            }

          


        }


    
    }
    
}
