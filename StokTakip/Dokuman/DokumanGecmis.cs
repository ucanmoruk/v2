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

namespace StokTakip.Dokuman
{
    public partial class DokumanGecmis : Form
    {
        public DokumanGecmis()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select RevNo, RevTarihi, Aciklama as 'Açıklama' from DokumanRev where Kod = '"+kod+"' and Durum = 'Aktif' order by RevNo asc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

            RepositoryItemMemoEdit memo = new RepositoryItemMemoEdit();
            gridView1.Columns["Açıklama"].ColumnEdit = memo;

            gridView1.Columns["Açıklama"].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
  

        }

        int yetki;
        void yetkibul()
        {
            SqlCommand komut21 = new SqlCommand("Select * from KaliteYetki where Gorev = N'" + Anasayfa.gorev + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                yetki = Convert.ToInt32(dr21["Dokuman"]);
            }
            bgl.baglanti().Close();

            if (yetki == 0 || yetki.ToString() == null)
            {
                barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
            {
                barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }

        }

        public static string kod;
        private void DokumanGecmis_Load(object sender, EventArgs e)
        {
            yetkibul();
            listele();

            this.gridView1.Columns[0].Width = 20;
            this.gridView1.Columns[1].Width = 50;
        }

        private void DokumanGecmis_FormClosing(object sender, FormClosingEventArgs e)
        {
            kod = "";
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult Secim = new DialogResult();

            Secim = MessageBox.Show(revino + "numaralı revizyonu silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (Secim == DialogResult.Yes)
            {
                SqlCommand add2 = new SqlCommand("update DokumanRev set Durum = @a1 where Kod = '" + kod + "' and RevNo = '" + revino + "'", bgl.baglanti());
                add2.Parameters.AddWithValue("@a1", "Pasif");
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();

                listele();

                string newLine = Environment.NewLine;
                MessageBox.Show("Silme işlemi gerçekleşmiştir." + newLine + "Ancak yaptığınız değişiklik doküman master listesine yansıtılmamıştır." + newLine + "Doküman master listesindeki revizyon bilgisini ayrıca güncelleminizi rica ederiz.");

                
            }


        }

        string revino;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            revino = dr["RevNo"].ToString();
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "RevNo" )
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

        }
    }
}
