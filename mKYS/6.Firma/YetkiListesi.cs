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

namespace mKYS.Firma
{
    public partial class YetkiListesi : Form
    {
        public YetkiListesi()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        void gorevbul()
        {
            SqlCommand komutD = new SqlCommand("select Gorev from StokKullanici where Durum = N'Aktif'", bgl.baglanti());
            SqlDataReader dr = komutD.ExecuteReader();
            while (dr.Read())
            {
                combo_gorev.Properties.Items.Add(dr["Gorev"]);
            }
            bgl.baglanti().Close();
        }

        int gorevID;
        void gorevkontrol()
        {
            SqlCommand komutD = new SqlCommand("select Count(Gorev) from KaliteYetki where Gorev='" + combo_gorev.Text + "'", bgl.baglanti());
            SqlDataReader dr = komutD.ExecuteReader();
            while (dr.Read())
            {
                gorevID = Convert.ToInt32(dr[0]);
            }
            bgl.baglanti().Close();
        }

        void gorevdetay()
        {
            gorevkontrol();
            if (gorevID == 0 )
            {
                combo_analiz.SelectedIndex = -1;
                combo_dokuman.SelectedIndex = -1;
                combo_cihaz.SelectedIndex = -1;
                combo_egitim.SelectedIndex = -1;
                combo_firma.SelectedIndex= -1;
                combo_stok.SelectedIndex = -1;
                combo_talep.SelectedIndex = -1;
            }
            else
            {
                SqlCommand komut = new SqlCommand("select * from KaliteYetki where Gorev = N'"+combo_gorev.Text+"'", bgl.baglanti());
                SqlDataReader dr1 = komut.ExecuteReader();
                while (dr1.Read())
                {
                    combo_analiz.SelectedIndex =Convert.ToInt32(dr1["Analiz"].ToString());
                    combo_dokuman.SelectedIndex = Convert.ToInt32(dr1["Dokuman"].ToString());
                    combo_cihaz.SelectedIndex = Convert.ToInt32(dr1["Cihaz"].ToString());
                    combo_egitim.SelectedIndex = Convert.ToInt32(dr1["Egitim"].ToString());
                    combo_firma.SelectedIndex = Convert.ToInt32(dr1["Firma"].ToString());
                    combo_stok.SelectedIndex = Convert.ToInt32(dr1["stok"].ToString());
                    combo_talep.SelectedIndex = Convert.ToInt32(dr1["Talep"].ToString());
                }
                bgl.baglanti().Close();
            }
        }

        private void YetkiListesi_Load(object sender, EventArgs e)
        {
            gorevbul();
        }

        private void combo_gorev_SelectedIndexChanged(object sender, EventArgs e)
        {
            gorevkontrol();
            gorevdetay();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gorevkontrol();
            if (gorevID == 0)
            {
                SqlCommand add = new SqlCommand("insert into KaliteYetki " +
            " (Gorev, Dokuman, Analiz, Cihaz, Stok, Egitim, Talep,Firma) " +
            "values (@a1,@a2,@a3,@a4, @a5, @a6, @a7, @a8 ); ", bgl.baglanti());
                add.Parameters.AddWithValue("@a1", combo_gorev.Text);
                add.Parameters.AddWithValue("@a2", combo_dokuman.SelectedIndex);
                add.Parameters.AddWithValue("@a3", combo_analiz.SelectedIndex);
                add.Parameters.AddWithValue("@a4", combo_cihaz.SelectedIndex);
                add.Parameters.AddWithValue("@a5", combo_stok.SelectedIndex);
                add.Parameters.AddWithValue("@a6", combo_egitim.SelectedIndex);
                add.Parameters.AddWithValue("@a7", combo_talep.SelectedIndex);
                add.Parameters.AddWithValue("@a8", combo_firma.SelectedIndex);
                add.ExecuteNonQuery();
                bgl.baglanti().Close();

            }
            else
            {
                SqlCommand add = new SqlCommand("update KaliteYetki " +
          " set Dokuman=@a2, Analiz=@a3, Cihaz=@a4, Stok=@a5, Egitim=@a6, Talep=@a7,Firma=@a8 " +
          " where Gorev= N'"+combo_gorev.Text+"' ", bgl.baglanti());
                add.Parameters.AddWithValue("@a2", combo_dokuman.SelectedIndex);
                add.Parameters.AddWithValue("@a3", combo_analiz.SelectedIndex);
                add.Parameters.AddWithValue("@a4", combo_cihaz.SelectedIndex);
                add.Parameters.AddWithValue("@a5", combo_stok.SelectedIndex);
                add.Parameters.AddWithValue("@a6", combo_egitim.SelectedIndex);
                add.Parameters.AddWithValue("@a7", combo_talep.SelectedIndex);
                add.Parameters.AddWithValue("@a8", combo_firma.SelectedIndex);
                add.ExecuteNonQuery();
                bgl.baglanti().Close();

            }

            MessageBox.Show("Yetki ayarları başarıyla güncellendi!", "Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
