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
    public partial class TedarikciTur : Form
    {
        public TedarikciTur()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select Tur as 'Tedarikçi Türü', Limit as 'Limit Puan' from StokTedarikciTur ", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;
        }

        void ekleme()
        {
            SqlCommand add = new SqlCommand("insert into StokTedarikciTur(Tur,Limit) values (@o1,@o2)", bgl.baglanti());
            add.Parameters.AddWithValue("@o1", txt_tur.Text);
            add.Parameters.AddWithValue("@o2", txt_puan.Text);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            txt_puan.Text = "";
            txt_tur.Text = "";
        }

        void silme()
        {
            try
            {
                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show(tur + " kategorisini silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (Secim == DialogResult.Yes)
                {
                    SqlCommand komutSil = new SqlCommand("delete StokTedarikciTur where Tur = N'" + tur + "'", bgl.baglanti());
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

        void guncelle()
        {
            SqlCommand add = new SqlCommand("update StokTedarikciTur set Tur=@a1, Limit=@a2 where Tur='"+tur+"'", bgl.baglanti());
            add.Parameters.AddWithValue("@o1", txt_tur.Text);
            add.Parameters.AddWithValue("@o2", txt_puan.Text);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            txt_puan.Text = "";
            txt_tur.Text = "";
        }

        private void TedarikciTur_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            if (btn_ekle.Text == "Ekle")
            {
                ekleme();
            }
            else
            {
                guncelle();
            }
            listele();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            silme();
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }
        }

        string tur;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            tur = dr["Tedarikçi Türü"].ToString();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txt_tur.Text = dr["Tedarikçi Türü"].ToString();
            txt_puan.Text = dr["Limit Puan"].ToString();
            btn_ekle.Text = "Güncelle";
        }
    }
}
