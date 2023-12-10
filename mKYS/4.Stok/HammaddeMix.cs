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
using mKYS.Stok;

namespace mKYS.Stok
{
    public partial class HammaddeMix : Form
    {
        public HammaddeMix()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public static string gelis, hID, kapama;

        void listele()
        {
            DataTable dt6 = new DataTable();
            SqlDataAdapter da6 = new SqlDataAdapter("select ID, Tur, Ad, Cas from RootStokListesi where Durum = N'Aktif' order by Tur", bgl.baglanti());
            da6.Fill(dt6);
            gridControl1.DataSource = dt6;
            gridView1.Columns["ID"].Visible = false;

            gridView1.Columns[1].Width = 60;
            gridView1.Columns[2].Width = 90;
            gridView1.Columns[3].Width = 60;
        }

        void listele2()
        {
            DataTable dt6 = new DataTable();
            SqlDataAdapter da6 = new SqlDataAdapter("select e.ID, e.Ad, e.Cas, m.Yuzde from RootStokListesi e left join mrMix m on e.ID = m.EtkenID where m.MixID ='" + hID + "'  order by Ad", bgl.baglanti());
            da6.Fill(dt6);
            gridControl2.DataSource = dt6;
            gridView2.Columns["ID"].Visible = false;

            gridView2.Columns[1].Width = 90;
            gridView2.Columns[2].Width = 60;
           // gridView2.Columns[3].Width = 50;
        }

        void listeksik()
        {
            DataTable dt6 = new DataTable();
            SqlDataAdapter da6 = new SqlDataAdapter(@"select ID, Tur, Ad, Cas from RootStokListesi where Durum = N'Aktif' 
            except select ID, Tur, Ad, Cas from RootStokListesi
            where ID in (select EtkenID from mrMix where MixID = '" + hID + "') order by Tur", bgl.baglanti());
            da6.Fill(dt6);
            gridControl1.DataSource = dt6;
            gridView1.Columns["ID"].Visible = false;

            gridView1.Columns[1].Width = 60;
            gridView1.Columns[2].Width = 90;
            gridView1.Columns[2].Width = 60;
        }

        int ko;
        string hadi;
        void kontrol()
        {
         
            SqlCommand komut2 = new SqlCommand("select count(ID) as 'No' from mrMix where MixID = N'" + hID + "'  ", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                ko = Convert.ToInt32(dr2["No"]);
            }
            bgl.baglanti().Close();

            if (ko == 0)
            {

            }
            else
            {
                gelis = "Güncelle";
            }

            SqlCommand komut32 = new SqlCommand("select Kod, Ad from RootStokListesi where ID = '" + hID + "'  ", bgl.baglanti());
            SqlDataReader dr32 = komut32.ExecuteReader();
            while (dr32.Read())
            {
                hadi = dr32["Kod"].ToString() + ' ' + dr32["Ad"].ToString();
            }
            bgl.baglanti().Close();
        }

        private void HammaddeMix_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kapama == "1")
            {

            }
            else
            {
                DialogResult sonuc = MessageBox.Show("Kaydetmeden çıkmak istediğinizden emin misiniz ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (sonuc == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    //SqlCommand add = new SqlCommand("delete from mrMix where MixID = @p1 ", bgl.baglanti());
                    //add.Parameters.AddWithValue("@p1", hID);
                    //add.ExecuteNonQuery();
                    //bgl.baglanti().Close();

                }
            }

            gelis = null;
            hID = null;

        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }
        }

        private void gridView2_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu2.ShowPopup(p2);
            }
        }

        string id, o2;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ekle
            kapama = "0";
            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                id = gridView1.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                o2 = gridView1.GetRowCellValue(y, "ID").ToString();

                SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                  "insert into mrMix (MixID, EtkenID, Durum) " +
                  "values (@o1,@o2, @o3);" +
                  "COMMIT TRANSACTION", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", hID);
                add2.Parameters.AddWithValue("@o2", o2);
                add2.Parameters.AddWithValue("@o3", "Pasif");
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();
            }
            listele2();
            listeksik();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //sil
            kapama = "0";
            if (gridView2.SelectedRowsCount > 0)
            {
                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show("Seçili etken maddeleri kaldırmak istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Secim == DialogResult.Yes)
                {

                    for (int i = 0; i < gridView2.SelectedRowsCount; i++)
                    {
                        id = gridView2.GetSelectedRows()[i].ToString();
                        int y = Convert.ToInt32(id);
                        o2 = gridView2.GetRowCellValue(y, "ID").ToString();
                        SqlCommand add = new SqlCommand("delete from mrMix where MixID = @p1 and EtkenID = @p2 ", bgl.baglanti());
                        add.Parameters.AddWithValue("@p1", hID);
                        add.Parameters.AddWithValue("@p2", o2);
                        add.ExecuteNonQuery();
                        bgl.baglanti().Close();

                    }

                    listele2();
                    listeksik();
                }
            }
            else
            {
                MessageBox.Show("Lütfen seçim yapınız..");
            }
        }

        void guncelle()
        {
            try
            {

                for (int ik = 0; ik < gridView2.RowCount; ik++)
                {
                    //id = gridView1.GetSelectedRows()[ik].ToString();
                    //int y = Convert.ToInt32(id);
                    o2 = gridView2.GetRowCellValue(ik, "ID").ToString();
                    SqlCommand komutz = new SqlCommand("update mrMix set Yuzde = @o1, Durum = @o2 where EtkenID = '" + o2 + "' and MixID = '" + hID + "'  ", bgl.baglanti());
                    komutz.Parameters.AddWithValue("@o1", Convert.ToDecimal(gridView2.GetRowCellValue(ik, "Yuzde").ToString()));
                    komutz.Parameters.AddWithValue("@o2", "Aktif");
                    komutz.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }


                MessageBox.Show("Güncelleme Başarılı!");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata1 : " + ex);
            }
        }

        void kaydet()
        {

            try
            {

                for (int ik = 0; ik < gridView2.RowCount; ik++)
                {
                    //id = gridView1.GetSelectedRows()[ik].ToString();
                    //int y = Convert.ToInt32(id);
                    o2 = gridView2.GetRowCellValue(ik, "ID").ToString();
                    SqlCommand komutz = new SqlCommand("update mrMix set Yuzde = @o1, Durum = @o3  where EtkenID = '" + o2 + "' and MixID = '" + hID + "'", bgl.baglanti());
                    komutz.Parameters.AddWithValue("@o1", Convert.ToDecimal(gridView2.GetRowCellValue(ik, "Yuzde").ToString()));
                    komutz.Parameters.AddWithValue("@o3", "Aktif");
                    komutz.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }
 


                MessageBox.Show("Kaydetme başarılı!");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata save1 : " + ex);
            }

        }


        private void btn_save_Click(object sender, EventArgs e)
        {
            //kaydet 
            if (btn_save.Text == "Güncelle")
            {
                guncelle();
            }
            else
            {
                kaydet();
            }

            kapama = "1";
        }

        private void HammaddeMix_Load(object sender, EventArgs e)
        {
            kapama = "1";

            kontrol();
            Text = hadi;

            if (gelis == "Güncelle")
            {
                btn_save.Text = "Güncelle";
                listele2();
                listeksik();
            }
            else
            {
                listele();
            }
        }
    }
}
