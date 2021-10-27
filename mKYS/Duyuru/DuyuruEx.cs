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
    public partial class DuyuruEx : Form
    {
        public DuyuruEx()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt2 = new DataTable();
            //SqlDataAdapter da2 = new SqlDataAdapter("select d.DuyuruID as 'ID', d.PersonelID, k.Ad + ' ' + k.Soyad as 'Mesaj Gönderen', d.Tarih as 'Okunma Tarihi', m.Konu, m.Duyuru from StokDuyuruDurum d " +
            //    "inner join StokDuyuru m on d.DuyuruID = m.ID inner join StokKullanici k on m.PersonelID = k.ID " +
            //    " where d.Durum = 'Okundu' and d.PersonelID = '" + Anasayfa.kullanici + "' order by d.Tarih desc", bgl.baglanti());

            SqlDataAdapter da2 = new SqlDataAdapter(@"select d.DuyuruID as 'ID', d.PersonelID, k.Ad + ' ' + k.Soyad as 'Mesaj Gönderen', d.Tarih as 'Okunma Tarihi', m.Konu, m.Duyuru from StokDuyuruDurum d 
            inner join StokDuyuru m on d.DuyuruID = m.ID 
            inner join StokKullanici k on m.PersonelID = k.ID 
            where d.Durum = 'Okundu' and d.PersonelID =  '" + Anasayfa.kullanici + "' order by d.Tarih desc", bgl.baglanti());


            da2.Fill(dt2);
            gridControl1.DataSource = dt2;

            gridView1.Columns["ID"].Visible = false;
            gridView1.Columns["PersonelID"].Visible = false;
            this.gridView1.Columns[2].Width = 40;
            this.gridView1.Columns[3].Width = 40;
            this.gridView1.Columns[4].Width = 50;
            this.gridView1.Columns[5].Width = 275;

            RepositoryItemMemoEdit memo = new RepositoryItemMemoEdit();
            gridView1.Columns["Duyuru"].ColumnEdit = memo;
            gridView1.Columns["Konu"].ColumnEdit = memo;
            gridView1.Columns["Duyuru"].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gridView1.Columns["Konu"].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

        }

        private void DuyuruEx_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void DuyuruEx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                listele();
            }
        }
    }
}
