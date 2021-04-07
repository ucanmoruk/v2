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
    public partial class PersonelListesi : Form
    {
        public PersonelListesi()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select Sira as 'No', Ad as 'Ad Soyad', Gorev as 'Görevi', Telefon, Email as 'E-Mail Adresi' from Kullanici where Sira is not null order by Sira", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;

            //lab. birimi de ekle
        }


        private void PersonelListesi_Load(object sender, EventArgs e)
        {
            //listele();
            //this.gridView1.Columns[0].Width = 20;
            //this.gridView1.Columns[1].Width = 150;
            //this.gridView1.Columns[2].Width = 150;
            //this.gridView1.Columns[3].Width = 90;
            //this.gridView1.Columns[4].Width = 250;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Personel.update = kkod;
            Personel p = new Personel();
            p.ShowDialog();

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show("Silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (Secim == DialogResult.Yes)
                {
                    SqlCommand komutSil = new SqlCommand("update Kullanici set Durum=@a1 where Sira = N'" + kkod + "'", bgl.baglanti());
                    komutSil.Parameters.AddWithValue("@a1", "Pasif");
                    komutSil.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Silme işlemi gerçekleşmiştir.");
                    listele();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata2 : " + ex.Message);
            }
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
        string kkod;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            kkod = dr["Sira"].ToString();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Personel.update = kkod;
            Personel p = new Personel();
            p.ShowDialog();

        }
    }
}
