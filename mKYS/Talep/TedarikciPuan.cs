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
    public partial class TedarikciPuan : Form
    {
        public TedarikciPuan()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public static string firma, fID;
        private void TedarikciPuan_Load(object sender, EventArgs e)
        {
            txt_firma.Text = firma;
            txt_firma.Enabled = false;
            firmabul();
        }

        decimal puanv;
        int firmaID;
        void firmabul()
        {
            //SqlCommand komutID = new SqlCommand("Select * From StokTedarikci where ID = '" + fID+ "' ", bgl.baglanti());
            //SqlDataReader drI = komutID.ExecuteReader();
            //while (drI.Read())
            //{
            //    firmaID = Convert.ToInt32(drI["ID"].ToString());

            //}
            //bgl.baglanti().Close();

            SqlCommand komut = new SqlCommand("Select * From StokTedarikciPuan where FirmaID = '" + fID + "' ", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                puanv = Convert.ToDecimal(dr["Puan"].ToString());

            }
            bgl.baglanti().Close();


        }


        TedarikciListesi m = (TedarikciListesi)System.Windows.Forms.Application.OpenForms["TedarikciListesi"];

        private void TedarikciPuan_FormClosed(object sender, FormClosedEventArgs e)
        {
            fID = null;
            firma = null;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            DateTime tarih = DateTime.Now;

            if (puanv == 0 || puanv.ToString() == null)
            {
                SqlCommand add = new SqlCommand("insert StokTedarikciPuan (FirmaID, Puan, Tarih,Durum,PersonelID, Aciklama) values (@a1,@a2,@a3,@a4,@a5,@a6) ", bgl.baglanti());
                add.Parameters.AddWithValue("@a1", fID);
                add.Parameters.AddWithValue("@a2", Convert.ToDecimal(txt_puan.Text));
                add.Parameters.AddWithValue("@a3", tarih);
                add.Parameters.AddWithValue("@a4", combo_deger.Text);
                add.Parameters.AddWithValue("@a5", Anasayfa.kullanici);
                add.Parameters.AddWithValue("@a6", txt_aciklama.Text);
                add.ExecuteNonQuery();
                bgl.baglanti().Close();
            }
            else
            {
                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show("Daha önceki değerlendirmeyi güncellemek mi istiyorsunuz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (Secim == DialogResult.Yes)
                {
                    SqlCommand add = new SqlCommand("update StokTedarikciPuan set Puan=@a1, Tarih=@a2, Durum=@a3, PersonelID=@a4, Aciklama=@a5 where FirmaID = '" + fID + "' ", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", Convert.ToDecimal(txt_puan.Text));
                    add.Parameters.AddWithValue("@a2", tarih);
                    add.Parameters.AddWithValue("@a3", combo_deger.Text);
                    add.Parameters.AddWithValue("@a4", Anasayfa.kullanici);
                    add.Parameters.AddWithValue("@a5", txt_aciklama.Text);
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }


                    

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
