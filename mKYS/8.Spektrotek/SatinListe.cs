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
    public partial class SatinListe : Form
    {
        public SatinListe()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();


        public void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(@"select l.TalepNo, k.Ad as 'Yetkili', s.Tarih, t.Ad as 'Tedarikci', s.Aciklama, s.Malzeme, s.Fiyat, 
            s.Stok, l.ID as 'ID' from SSatinAlim s 
            left join STalepListe l on s.TalepID = l.ID
            left join RootTedarikci t on s.TedarikciID = t.ID
            left join RootKullanici k on s.OlusturanID = k.ID
            where s.Durum = 'Aktif' order by TalepNo desc", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;

            gridView1.Columns["ID"].Visible = false;

            this.gridView1.Columns[0].Width = 50;
            this.gridView1.Columns[1].Width = 75;
            this.gridView1.Columns[2].Width = 60;
            this.gridView1.Columns[3].Width = 150;
            this.gridView1.Columns[4].Width = 75;
            this.gridView1.Columns[5].Width = 150;
            this.gridView1.Columns[6].Width = 60;
            this.gridView1.Columns[7].Width = 75;
        }

        private void SatinListe_Load(object sender, EventArgs e)
        {
            listele();
        }

        string talepID, talepNo;

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "TalepNo" || e.Column.FieldName == "Tarih" || e.Column.FieldName == "Fiyat" || e.Column.FieldName == "Stok")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listele();
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            talepID = dr["ID"].ToString();
            talepNo = dr["TalepNo"].ToString();

            SatinAlma.TalepID = talepID;
            SatinAlma.TalepNo = talepNo;
            SatinAlma sa = new SatinAlma();
            sa.Show();
        }
    }
}
