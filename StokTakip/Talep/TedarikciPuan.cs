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

namespace StokTakip.Talep
{
    public partial class TedarikciPuan : Form
    {
        public TedarikciPuan()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public static string firma;
        private void TedarikciPuan_Load(object sender, EventArgs e)
        {
            txt_firma.Text = firma;
            txt_firma.Enabled = false;
            firmabul();
        }

        int puanv, firmaID;
        void firmabul()
        {
            SqlCommand komutID = new SqlCommand("Select * From StokTedarikci where Ad = '" + firma+ "' ", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                firmaID = Convert.ToInt32(drI["ID"].ToString());

            }
            bgl.baglanti().Close();

            SqlCommand komut = new SqlCommand("Select * From StokTedarikciPuan where FirmaID = '" + firmaID + "' ", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                puanv = Convert.ToInt32(dr["Puan"].ToString());

            }
            bgl.baglanti().Close();


        }


        TedarikciListesi m = (TedarikciListesi)System.Windows.Forms.Application.OpenForms["TedarikciListesi"];

        private void btn_ok_Click(object sender, EventArgs e)
        {
            DateTime tarih = DateTime.Now;

            if (puanv == 0 || puanv.ToString() == null)
            {
                SqlCommand add = new SqlCommand("insert StokTedarikciPuan (FirmaID, Puan, Tarih,Durum,PersonelID) values (@a1,@a2,@a3,@a4,@a5) ", bgl.baglanti());
                add.Parameters.AddWithValue("@a1", firmaID);
                add.Parameters.AddWithValue("@a2", Convert.ToDecimal(txt_puan.Text));
                add.Parameters.AddWithValue("@a3", tarih);
                add.Parameters.AddWithValue("@a4", combo_deger.Text);
                add.Parameters.AddWithValue("@a5", Anasayfa.kullanici);
                add.ExecuteNonQuery();
                bgl.baglanti().Close();
            }
            else
            {
                SqlCommand add = new SqlCommand("update StokTedarikciPuan set Puan=@a1, Tarih=@a2, Durum=@a3, PersonelID=@a4 where FirmaID = '" + firmaID + "' ", bgl.baglanti());
                add.Parameters.AddWithValue("@a1", Convert.ToDecimal(txt_puan.Text));
                add.Parameters.AddWithValue("@a2", tarih);
                add.Parameters.AddWithValue("@a3", combo_deger.Text);
                add.Parameters.AddWithValue("@a4", Anasayfa.kullanici);
                add.ExecuteNonQuery();
                bgl.baglanti().Close();

             }

            MessageBox.Show(firma + "firması için değerlendirme puanı başarı ile eklendi!", "Ooppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);



            if (Application.OpenForms["TedarikciListesi"] == null)
            { }
            else
            {
                m.listele();
            }
        }
    }
}
