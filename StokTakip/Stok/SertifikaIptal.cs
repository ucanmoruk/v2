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
    public partial class SertifikaIptal : Form
    {
        public SertifikaIptal()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        void listele()
        {
            SqlCommand komutID = new SqlCommand("Select * From StokListesi where ID in (select StokID from StokHareket where Durum= N'Aktif' and BirimID = '" + Anasayfa.birimID + "')", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                combokod.Properties.Items.Add(drI["Kod"].ToString());
            }
            bgl.baglanti().Close();
        }

        void listele2()
        {
            SqlCommand komutID = new SqlCommand("Select * From StokListesi where ID in (select StokID from StokHareket where Durum= N'Aktif')", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                combokod.Properties.Items.Add(drI["Kod"].ToString());
            }
            bgl.baglanti().Close();
        }

        int yetki;
        void yetkibul()
        {
            SqlCommand komut21 = new SqlCommand("Select * from KaliteYetki where Gorev = N'" + Anasayfa.gorev + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                yetki = Convert.ToInt32(dr21["Stok"]);
            }
            bgl.baglanti().Close();


        }

        private void SertifikaIptal_Load(object sender, EventArgs e)
        {
            yetkibul();

            if (yetki == 0 || yetki.ToString() == null)
                listele();
            else
                listele2();
        }

        string marka;
        private void combokod_SelectedIndexChanged(object sender, EventArgs e)
        {

            combo_marka.Properties.Items.Clear();

            if (yetki == 0 || yetki.ToString() == null)
            {
                SqlCommand komutD = new SqlCommand("select  * from StokSertifika where StokID in (select ID from StokListesi where Kod = N'" + combokod.Text + "') and BirimID = '" + Anasayfa.birimID + "' and Durum = N'Aktif' ", bgl.baglanti());
                SqlDataReader dr = komutD.ExecuteReader();
                while (dr.Read())
                {
                    marka = dr["Sertifika"].ToString();
                    combo_marka.Properties.Items.Add(marka);
                }
                bgl.baglanti().Close();
            }
            else
            {
                SqlCommand komutD = new SqlCommand("select  * from StokSertifika where StokID in (select ID from StokListesi where Kod = N'" + combokod.Text + "') and Durum = N'Aktif' ", bgl.baglanti());
                SqlDataReader dr = komutD.ExecuteReader();
                while (dr.Read())
                {
                    marka = dr["Sertifika"].ToString();
                    combo_marka.Properties.Items.Add(marka);
                }
                bgl.baglanti().Close();

            }

               
        }

        string path;
        private void combo_marka_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komutD = new SqlCommand("select * from StokSertifika where Sertifika =N'" + combo_marka.Text + "' and StokID in (select ID from StokListesi where Kod = N'" + combokod.Text + "') ", bgl.baglanti());
            SqlDataReader dr = komutD.ExecuteReader();
            while (dr.Read())
            {
                path = dr["Path"].ToString();

            }
            bgl.baglanti().Close();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            SertifikaGoruntule.yol = path;
            SertifikaGoruntule sg = new SertifikaGoruntule();
            sg.Show();
        }

        private void btn_iptal_Click(object sender, EventArgs e)
        {

            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Bu sertifikayı silmek istediğinizden emin misiniz?", "Oooppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (cikis == DialogResult.Yes)
            {
                SqlCommand add2 = new SqlCommand("update StokSertifika set Durum= @a1 where Sertifika = N'" + combo_marka.Text + "' and Path = '" + path + "' and BirimID = '" + Anasayfa.birimID + "'", bgl.baglanti());
                add2.Parameters.AddWithValue("@a1", "Pasif");
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Sertifika başarıyla iptal edildi!", "Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                combokod.Text = "";
                combo_marka.Text = "";
            }
          

        }
    }
}
