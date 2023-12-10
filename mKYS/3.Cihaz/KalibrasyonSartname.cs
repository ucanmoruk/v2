﻿using DevExpress.XtraEditors.Repository;
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

namespace mKYS.Cihaz
{
    public partial class KalibrasyonSartname : Form
    {
        public KalibrasyonSartname()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"Select c.CihazID, l.Kod, l.Ad, c.KalTip as 'Tür', c.KalSiklik as 'Sıklık', c.Calisma as 'Çalışma Aralığı',  
             c.Kalibrasyon as 'Kalibrasyon Aralığı', c.KabulKriteri as 'Kabul Kriteri' 
             from RootCihazKalibrasyon c 
             inner join RootCihazListesi l on c.CihazID = l.ID 
             where l.Durum = 'Aktif' and c.Durum = 'Aktif'  order by l.Kod", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

            gridView1.Columns["CihazID"].Visible = false;
            this.gridView1.Columns[1].Width = 40;
            this.gridView1.Columns[2].Width = 90;
            this.gridView1.Columns[3].Width = 40;
            this.gridView1.Columns[4].Width = 40;
            this.gridView1.Columns[5].Width = 50;
            this.gridView1.Columns[6].Width = 110;
            this.gridView1.Columns[7].Width = 110;
            //this.gridView1.Columns[8].Width = 110;
            RepositoryItemMemoEdit memo = new RepositoryItemMemoEdit();
            gridView1.Columns["Kalibrasyon Aralığı"].ColumnEdit = memo;
            gridView1.Columns["Kabul Kriteri"].ColumnEdit = memo;
       //     gridView1.Columns["Kaynak"].ColumnEdit = memo;

            gridView1.Columns["Kalibrasyon Aralığı"].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gridView1.Columns["Kabul Kriteri"].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
        //    gridView1.Columns["Kaynak"].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

        }

        int yetki;
        void yetkibul()
        {
            SqlCommand komut21 = new SqlCommand("Select * from KaliteYetki where Gorev = N'" + Anasayfa.gorev + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                yetki = Convert.ToInt32(dr21["Cihaz"]);
            }
            bgl.baglanti().Close();

            if (yetki == 0 || yetki.ToString() == null)
            {
                barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            }
            else if (yetki == 1)
            {
                barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else if (yetki == 2 || yetki == 3)
            {
                barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }

        }

        private void KalibrasyonSartname_Load(object sender, EventArgs e)
        {
            listele();
         //   yetkibul();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listele();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CihazEkle.cihazkod = "2";
            CihazEkle.kodad = kodad;
            CihazEkle.cID = cID;
            CihazEkle ce = new CihazEkle();
            ce.Show();
        }

        private void KalibrasyonSartname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                listele();
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

        string cID, kodad;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            cID= dr["CihazID"].ToString();
            kodad = dr["Kod"].ToString() + ' ' + dr["Ad"].ToString();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //sil

            DialogResult Secim = new DialogResult();

            Secim = MessageBox.Show(kodad + " cihazının kalibrasyon şartlarını silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (Secim == DialogResult.Yes)
            {
                SqlCommand komutSil = new SqlCommand("update RootCihazKalibrasyon set Durum=@a1 where CihazID = N'" + cID + "' ", bgl.baglanti());
                komutSil.Parameters.AddWithValue("@a1", "Pasif");
                komutSil.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Silme işlemi başarılı!", "Ooppss!");
                listele();
            }
            else
            {

            }
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string path = "KalibrasyonSartname.xlsx";
            gridControl1.ExportToXlsx(path);
            Process.Start(path);

        }
    }
}
