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

namespace StokTakip.Stok
{
    public partial class ReceteSec : Form
    {
        public ReceteSec()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        private void listele()
        {
            SqlCommand komutID = new SqlCommand("Select Kod From StokAnalizListesi where Durumu = N'Aktif' except select AnalizKod from StokRecete", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                combokod.Properties.Items.Add(drI["Kod"].ToString());
            }
            bgl.baglanti().Close();

        }

        public static string gelis;
        private void ReceteSec_Load(object sender, EventArgs e)
        {
            listele();
            
        }

        private void combokod_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komutID = new SqlCommand("Select * From StokAnalizListesi where Durumu= N'Aktif' and Kod = '"+combokod.Text+"'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                txt_kod.Text = drI["Ad"].ToString();
            }
            bgl.baglanti().Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            YeniRecete.UrunID = combokod.Text;
            YeniRecete.Ad = txt_kod.Text;

            this.Close();

            var mfrm = (Anasayfa)Application.OpenForms["Anasayfa"];
            if (mfrm != null)
                mfrm.YeniRecete();

           
        }
    }
}
