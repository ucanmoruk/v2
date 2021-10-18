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

namespace mKYS
{
    public partial class YeniStok : Form
    {
        public YeniStok()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        private void temizle()
        {
            txtad.Text = "";
            txtambalaj.Text = "";
            txtcas.Text = "";
            txtenad.Text = "";  
            txtkod.Text = "";
            txtlimit.Text = "";
            txtozellik.Text = "";
            txtsaklama.Text = "";
            combobirim.Text = "";   
            combo_tur.Text = "";
        }

        int o2;
        private void kodkontrol()
        {
            SqlCommand komut2 = new SqlCommand("Select Count(ID) from StokListesi where Kod = N'" + txtkod.Text + "' ", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                o2 = Convert.ToInt32(dr2[0]);
            }
            bgl.baglanti().Close();

        }

        private void ekleme()
        {
            try
            {
                decimal limit;
                if (txtlimit.Text == "")
                {
                    limit = 0;
                }
                else
                {
                    limit = Convert.ToDecimal(txtlimit.Text);
                }

                SqlCommand add = new SqlCommand("insert into StokListesi (Tur,Kod,Ad,AdEn,Cas,Ambalaj,Ozellik,Saklama,Limit,Birim,Miktar,Durum) values (@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9,@a10,@a12,@a11)", bgl.baglanti());
                add.Parameters.AddWithValue("@a1", combo_tur.Text);
                add.Parameters.AddWithValue("@a2", txtkod.Text);
                add.Parameters.AddWithValue("@a3", txtad.Text);
                add.Parameters.AddWithValue("@a4", txtenad.Text);
                add.Parameters.AddWithValue("@a5", txtcas.Text);
                add.Parameters.AddWithValue("@a6", txtambalaj.Text);
                add.Parameters.AddWithValue("@a7", txtozellik.Text);
                add.Parameters.AddWithValue("@a8", txtsaklama.Text);
                add.Parameters.AddWithValue("@a9", limit);
                add.Parameters.AddWithValue("@a10", combobirim.Text);
                add.Parameters.AddWithValue("@a12", 0);
                add.Parameters.AddWithValue("@a11", "Aktif");
                add.ExecuteNonQuery();
                bgl.baglanti().Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata 1: "+ex);
            }
        }

        private void YeniStok_Load(object sender, EventArgs e)
        {

        }

        StokListesi m = (StokListesi)System.Windows.Forms.Application.OpenForms["StokListesi"];

        private void btnadd_Click(object sender, EventArgs e)
        {
            kodkontrol();
            if (o2 == 1)
            {
                MessageBox.Show("Bu kod daha önce kullanılmış. Lütfen farklı bir kod seçiniz.", "Kod Hatası", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                ekleme();
                MessageBox.Show("Stok girişiniz başarı ile tamamlanmıştır.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                temizle();
                if (Application.OpenForms["StokListesi"] == null)
                {

                }
                else
                {
                    m.listele();
                }
            }
 
        }
    }
}
