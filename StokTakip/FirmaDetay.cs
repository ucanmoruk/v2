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

namespace StokTakip
{
    public partial class FirmaDetay : Form
    {
        public FirmaDetay()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();


        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SqlCommand add = new SqlCommand("update StokFirmaBirim set Durum=N'Pasif' where Birim = N'"+birim+"' and FirmaID = N'"+firmaID+"' ", bgl.baglanti());
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Silme işlemi başarılı!", "Oppss!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            listele();
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            SqlCommand add = new SqlCommand("update StokFirma set Path=N'"+txt_path.Text+"' where ID = N'" + firmaID + "' ", bgl.baglanti());
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Güncelleme işlemi başarılı!", "Oppss!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            listele();
            firmabul();
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }
        }

        string birim;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            birim = dr["Birim"].ToString();
        }

        int firmaID;
        void firmabul()
        {
            firmaID = Anasayfa.firmaID;
            SqlCommand komut21 = new SqlCommand("Select * from StokFirma where ID = N'" + firmaID + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                txt_ad.Text = dr21["FirmaAd"].ToString();
                txt_adres.Text = dr21["Adres"].ToString();
                txt_path.Text = dr21["Path"].ToString();
            }
            bgl.baglanti().Close();
        }

        void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select Birim from StokFirmaBirim where Durum = N'Aktif' order by Birim ", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            SqlCommand add = new SqlCommand("insert into StokFirmaBirim(FirmaID, Birim, Durum) values (@o1,@o2, @o3)", bgl.baglanti());
            add.Parameters.AddWithValue("@o1", firmaID);
            add.Parameters.AddWithValue("@o2", txt_birim.Text);
            add.Parameters.AddWithValue("@o3", "Aktif");
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ekleme işlemi başarılı!", "Oppss!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            listele();
        }

        private void FirmaDetay_Load(object sender, EventArgs e)
        {
            firmabul();
            listele();
        }
    }
}
