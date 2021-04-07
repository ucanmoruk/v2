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
    public partial class TalepYeni : Form
    {
        public TalepYeni()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        void listele()
        {
            //DataTable dt2 = new DataTable();
            //SqlDataAdapter da2 = new SqlDataAdapter("", bgl.baglanti());
            //da2.Fill(dt2);
            //gridControl1.DataSource = dt2;
        }

        private void TalepYeni_Load(object sender, EventArgs e)
        {
            listele();
        }

        string id, kod;
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (gridView2.SelectedRowsCount > 0)
            {
                for (int i = 0; i < gridView2.SelectedRowsCount; i++)
                {
                    id = gridView2.GetSelectedRows()[i].ToString();
                    int y = Convert.ToInt32(id);
                    kod = gridView2.GetRowCellValue(y, "Kod").ToString();
                    //SqlCommand komut2 = new SqlCommand("Select ID from Numune_Grup where Tur = N'" + kod + "' ", bgl.baglanti());
                    //SqlDataReader dr2 = komut2.ExecuteReader();
                    //while (dr2.Read())
                    //{
                    //    o2 = Convert.ToInt32(dr2["ID"]);
                    //}
                    //bgl.baglanti().Close();

                    SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                        "insert into TeklifDetay (TeklifNo, PaketID, BirimFiyat, FiyatBirim) " +
                        "values (@o1,@o2,@o3,@o4);" +
                        "COMMIT TRANSACTION", bgl.baglanti());
                    add2.Parameters.AddWithValue("@o1", 1);
                    add2.Parameters.AddWithValue("@o2", 1);
                    add2.Parameters.AddWithValue("@o3", 0);
                    add2.Parameters.AddWithValue("@o4", 1);
                    add2.ExecuteNonQuery();
                    bgl.baglanti().Close();

                }
            }
            else
            {
                MessageBox.Show("Lütfen seçim yapınız!", "Lütfen!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    for (int ik = 0; ik < gridView1.RowCount; ik++)
            //    {
            //        paketinadi = gridView1.GetRowCellValue(ik, "Paket Adı").ToString();
            //        SqlCommand komut21 = new SqlCommand("Select ID from Numune_Grup where Tur = N'" + paketinadi + "' and Grup = 'Özel'", bgl.baglanti());
            //        SqlDataReader dr21 = komut21.ExecuteReader();
            //        while (dr21.Read())
            //        {
            //            oppo2 = Convert.ToInt32(dr21["ID"]);
            //        }
            //        bgl.baglanti().Close();

            //        SqlCommand komutz = new SqlCommand("update TeklifDetay set BirimFiyat = @o1 , FiyatBirim = @o2, Aciklama = @o4 where PaketID = @o3 and TeklifNo = '" + txt_no.Text + "'", bgl.baglanti());
            //        komutz.Parameters.AddWithValue("@o1", Convert.ToDecimal(gridView1.GetRowCellValue(ik, "Birim Fiyat").ToString()));
            //        komutz.Parameters.AddWithValue("@o2", gridView1.GetRowCellValue(ik, "Kur Türü").ToString());
            //        komutz.Parameters.AddWithValue("@o3", oppo2);
            //        komutz.Parameters.AddWithValue("@o4", gridView1.GetRowCellValue(ik, "Açıklama").ToString());
            //        komutz.ExecuteNonQuery();
            //        bgl.baglanti().Close();
            //    }
            //    SqlCommand komutaz = new SqlCommand(" update TeklifListe set Durum = 'Aktif', ProjeID = N'" + projeID + "', Aciklama = N'" + txt_aciklama.Text + "' where TeklifNo = '" + txt_no.Text + "' ", bgl.baglanti());
            //    komutaz.ExecuteNonQuery();
            //    bgl.baglanti().Close();
            
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Hata 55: " + ex, "Lütfen!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //}
        }

        private void btn_Kaldir_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (gridView1.SelectedRowsCount > 0)
            //    {
            //        DialogResult Secim = new DialogResult();

            //        Secim = MessageBox.Show("Seçili maddeleri talep listenizden kaldırmak istediğinizden emin misiniz ?", "Emin misin!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            //        if (Secim == DialogResult.Yes)
            //        {
                       
            //                for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            //                {
            //                    id = gridView1.GetSelectedRows()[i].ToString();
            //                    int y = Convert.ToInt32(id);
            //                    kod = gridView1.GetRowCellValue(y, "Kod").ToString();
            //                    SqlCommand komut2 = new SqlCommand("select ID from Numune_Grup where Tur = '" + kod + "'", bgl.baglanti());
            //                    SqlDataReader dr2 = komut2.ExecuteReader();
            //                    while (dr2.Read())
            //                    {
            //                        oo2 = Convert.ToInt32(dr2["ID"]);
            //                    }
            //                    bgl.baglanti().Close();
            //                    SqlCommand add = new SqlCommand("delete from TeklifDetay where TeklifNo = @p1 and PaketID = @p2 ", bgl.baglanti());
            //                    add.Parameters.AddWithValue("@p1", txt_no.Text);
            //                    add.Parameters.AddWithValue("@p2", oo2);
            //                    add.ExecuteNonQuery();
            //                    bgl.baglanti().Close();
            //                }
                            
                        
                        
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Neyi mesela ?");
            //    }
            //    listele();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Tüh ya! Bak ne oldu: " + ex.Message);
            //}
        }
    }
}
