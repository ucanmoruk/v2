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

namespace mKYS
{
    public partial class TalepDetay : Form
    {
        public TalepDetay()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select d.StokKod as 'Stok Kodu', l.Ad, l.Cas as 'Cas No', d.Miktar,d.Birim, d.Marka, d.Ozellik, d.Durum, d.ID from StokTalepDetay d " +
                "left join StokListesi l on d.StokKod = l.Kod where TalepNo = '"+TalepNo+"' and d.Durumu = 'Aktif' order by d.StokKod", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;
            gridView1.Columns["ID"].Visible = false;

            this.gridView1.Columns[0].Width = 35;
            this.gridView1.Columns[1].Width = 75;
            this.gridView1.Columns[2].Width = 40;
            this.gridView1.Columns[3].Width = 35;
            this.gridView1.Columns[4].Width = 35;
            this.gridView1.Columns[5].Width = 40;
            this.gridView1.Columns[6].Width = 50;
            this.gridView1.Columns[7].Width = 50;
        }

        public static string TalepNo;
        private void TalepDetay_Load(object sender, EventArgs e)
        {
            listele();
            yetkibul();
            Text = TalepNo + " Numaralı Talep Detayları";
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "Miktar" || e.Column.FieldName == "Birim" || e.Column.FieldName == "Durum")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TalepKabul.gelentalep = "Kabul";
            TalepKabul.tID = tID;
            TalepKabul tk = new TalepKabul();
            tk.ShowDialog();

            listele();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TalepKabul.gelentalep = "Değerlendirme";
            TalepKabul.tID = tID;
            TalepKabul tk = new TalepKabul();
            tk.ShowDialog();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string path = "Talep Formu.xlsx";
            gridControl1.ExportToXlsx(path);
            Process.Start(path);
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
                
            }
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            string adam = gridView1.GetRowCellValue(e.RowHandle, "Durum").ToString();
            if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && adam == "Tamamlandı")
                e.Appearance.BackColor = Color.LightGreen;

        }

        public static string tID, durum;


        int yetki;
        void yetkibul()
        {
            SqlCommand komut21 = new SqlCommand("Select * from KaliteYetki where Gorev = N'" + Anasayfa.gorev + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                yetki = Convert.ToInt32(dr21["Talep"]);
            }
            bgl.baglanti().Close();
        }


        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //maliyet ekle
            Talep.TalepMaliyet.tID = tID;
            Talep.TalepMaliyet me = new Talep.TalepMaliyet();
            me.Show();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            durum = dr["Durum"].ToString();
            tID = dr["ID"].ToString();

            if (durum == "Tamamlandı")
            {
                barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                if (yetki == 3)
                    barButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                else
                    barButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
            {
                barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }
    }
}
