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

namespace mROOT._1.Mesaj
{
    public partial class BlogListe : Form
    {
        public BlogListe()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT ROW_NUMBER() OVER (ORDER BY Tarih DESC) AS No, Site, Tarih, Kategori, Baslik, OdakKelime, Durum, ID FROM Blog ORDER BY Tarih DESC", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.Columns["ID"].Visible = false;

            this.gridView1.Columns[0].Width = 30;
            this.gridView1.Columns[1].Width = 70;
            this.gridView1.Columns[2].Width = 70;
            this.gridView1.Columns[3].Width = 90;
            this.gridView1.Columns[4].Width = 250;
            this.gridView1.Columns[5].Width = 90;
            this.gridView1.Columns[6].Width = 80;

        }

        private void BlogListe_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //güncelle
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            int ID = Convert.ToInt32(dr["ID"].ToString());
            string durum = dr["Durum"].ToString();

            Wordpress.bID = ID;
            Wordpress.gelis = "Güncelle";
            Wordpress.durum = durum;

            Wordpress wp = new Wordpress();
            wp.Show();
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "Durum" || e.Column.FieldName == "Tarih" || e.Column.FieldName == "No")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            //  Tüm satırı renklendirmek istediğin zaman kullan
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {

                string ODurum = gridView1.GetRowCellValue(e.RowHandle, "Durum").ToString();
                if (ODurum == "Yayınlandı")
                {
                    e.Appearance.BackColor = Color.Green;
                    e.Appearance.BackColor2 = Color.LightGreen;
                    e.HighPriority = true;

                }
             
            }
        }

        private void BlogListe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                listele(); // Yenileme fonksiyonun
                e.Handled = true;
            }
        }
    }
}
