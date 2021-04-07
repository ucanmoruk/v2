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

        private void ekleme()
        {
            try
            {
                SqlCommand add = new SqlCommand("insert into StokListesi (Tur,Kod,Ad,AdEn,Cas,Ambalaj,Ozellik,Saklama,Limit,Birim,Durum) values (@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9,@a10,@a11)", bgl.baglanti());
                add.Parameters.AddWithValue("@a1", combo_tur.Text);
                add.Parameters.AddWithValue("@a2", txtkod.Text);
                add.Parameters.AddWithValue("@a3", txtad.Text);
                add.Parameters.AddWithValue("@a4", txtenad.Text);
                add.Parameters.AddWithValue("@a5", txtcas.Text);
                add.Parameters.AddWithValue("@a6", txtambalaj.Text);
                add.Parameters.AddWithValue("@a7", txtozellik.Text);
                add.Parameters.AddWithValue("@a8", txtsaklama.Text);
                add.Parameters.AddWithValue("@a9", txtlimit.Text);
                add.Parameters.AddWithValue("@a10", combobirim.Text);
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

        private void btnadd_Click(object sender, EventArgs e)
        {
            ekleme();
            MessageBox.Show("Stok girişiniz başarı ile tamamlanmıştır.","İşlem Başarılı",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            temizle();
        }
    }
}
