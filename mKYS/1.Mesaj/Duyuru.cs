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

namespace mKYS.Duyuru
{
    public partial class Duyuru : Form
    {
        public Duyuru()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();


        void bul()
        {
            SqlCommand komutID = new SqlCommand("Select Duyuru from RootMesaj where ID= N'" + duyID + "'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                txt_mesaj.Text = drI["Duyuru"].ToString();
            }
            bgl.baglanti().Close();
        }

        public static string duyID;
        private void Duyuru_Load(object sender, EventArgs e)
        {
            bul();
        }
    }
}
