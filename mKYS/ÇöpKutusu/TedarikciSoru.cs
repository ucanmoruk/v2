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

namespace mKYS.Talep
{
    public partial class TedarikciSoru : Form
    {
        public TedarikciSoru()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        int turid;
        void turidbul()
        {
            SqlCommand komut2 = new SqlCommand("Select * from StokTedarikciTur where Tur = '"+combo_kategori.Text+"'", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {                
                turid = Convert.ToInt32(dr2["ID"].ToString());
            }
            bgl.baglanti().Close();
        }

        void katbul()
        {
            SqlCommand komut2 = new SqlCommand("Select * from StokTedarikciTur order by Tur", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                combo_kategori.Properties.Items.Add(dr2["Tur"]);
            }
            bgl.baglanti().Close();

        }

        void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select Soru, MaksPuan as 'Puan' from StokTedarikciSoru where TurID = '"+turid+"' and Durum = 'Aktif'", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;

            this.gridView1.Columns[1].Width = 30;
        }

        private void TedarikciSoru_Load(object sender, EventArgs e)
        {
            katbul();
        }

        private void combo_kategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            turidbul();
            listele();
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            if (combo_kategori.Text == "")
            {
                MessageBox.Show("Lütfen kategori seçiniz!", "Oooppsss!");
            }
            else
            {
                turidbul();
                SqlCommand add = new SqlCommand("insert into StokTedarikciSoru(TurID,Soru,MaksPuan,Durum) values (@o1,@o2,@o3,@o4)", bgl.baglanti());
                add.Parameters.AddWithValue("@o1", turid);
                add.Parameters.AddWithValue("@o2", txt_soru.Text);
                add.Parameters.AddWithValue("@o3", txt_puan.Text);
                add.Parameters.AddWithValue("@o4", "Aktif");
                add.ExecuteNonQuery();
                bgl.baglanti().Close();
                listele();
                txt_puan.Text = "";
                txt_soru.Text = "";
            }
           
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show(soru + " sorusunu silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (Secim == DialogResult.Yes)
                {
                    SqlCommand komutSil = new SqlCommand("update StokTedarikciSoru set Durum = @a1 where TurID = N'" + turid + "' and Soru = '"+soru+"'", bgl.baglanti());
                    komutSil.Parameters.AddWithValue("@a1","Pasif");
                    komutSil.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Silme işlemi gerçekleşmiştir.");
                    listele();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Ka2 : " + ex.Message);
            }
        }

        string soru;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr == null)
            {

            }
            else
            {
                soru = dr["Soru"].ToString();
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
    }
}
