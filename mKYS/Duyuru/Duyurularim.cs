using DevExpress.XtraEditors.Repository;
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

namespace mKYS.Duyuru
{
    public partial class Duyurularim : Form
    {
        public Duyurularim()
        {
            InitializeComponent();
        }


        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select d.ID,  d.Tarih as 'Mesaj Tarihi', d.Konu, d.Duyuru as 'Mesaj', k2.Ad + ' ' + k2.Soyad as 'Alıcı', m.Durum, m.Tarih as 'Okunma Tarihi' from StokDuyuru d " +
                " inner join StokKullanici k on d.PersonelID = k.ID inner join StokDuyuruDurum m on d.ID = m.DuyuruID inner join StokKullanici k2 on m.PersonelID = k2.ID " +
                " where d.PersonelID = '"+ Anasayfa.kullanici +"'order by d.ID desc", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;

            gridView1.Columns["ID"].Visible = false;

            this.gridView1.Columns[0].Width = 40;
            this.gridView1.Columns[1].Width = 50;
            this.gridView1.Columns[2].Width = 50;
            this.gridView1.Columns[4].Width = 50;
            this.gridView1.Columns[5].Width = 50;
            this.gridView1.Columns[6].Width = 50;

            //RepositoryItemMemoEdit memo = new RepositoryItemMemoEdit();
            //gridView1.Columns["Mesaj"].ColumnEdit = memo;
            //gridView1.Columns["Mesaj"].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;


        }

        private void Duyurularim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                listele();
            }
        }

        private void Duyurularim_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            Duyuru.duyID = dr["ID"].ToString();

            Duyuru d = new Duyuru();
            d.Show();
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "Mesaj Tarihi" || e.Column.FieldName == "Alıcı" || e.Column.FieldName == "Durum" || e.Column.FieldName == "Okunma Tarihi")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }
    }
}
