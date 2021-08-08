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

namespace StokTakip.Cihaz
{
    public partial class CMaliyetListe : Form
    {
        public CMaliyetListe()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt6 = new DataTable();
            SqlDataAdapter da6 = new SqlDataAdapter("select m.ID, l.Kod, l.Ad, l.Marka,  m.Aciklama as 'Açıklama', m.Tarih, m.Tl,m.Dolar, m.Euro, s.Ad as 'Firma' from CihazMaliyet m" +
                " left join CihazListesi l on m.CihazID = l.ID left join StokTedarikci s on m.FirmaID = s.ID where m.Durum = 'Aktif' " , bgl.baglanti());
            da6.Fill(dt6);
            gridControl1.DataSource = dt6;
            gridView1.Columns["ID"].Visible = false;

            gridView1.Columns[1].Width = 30;
            gridView1.Columns[6].Width = 40;
            gridView1.Columns[7].Width = 40;
            gridView1.Columns[8].Width = 40;
            gridView1.Columns[9].Width = 150;
        }

        private void CMaliyetListe_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult Secim = new DialogResult();

            Secim = MessageBox.Show(cAd + " cihazına ait maliyet bilgisini silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (Secim == DialogResult.Yes)
            {
                SqlCommand komutSil = new SqlCommand("update CihazMaliyet set Durum=@a1 where ID = N'" + mID + "' ", bgl.baglanti());
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

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listele();
        }

        private void CMaliyetListe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                listele();
            }
        }

        string mID, cAd;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            mID= dr["ID"].ToString();
            cAd = dr["Ad"].ToString();
        }
    }
}
