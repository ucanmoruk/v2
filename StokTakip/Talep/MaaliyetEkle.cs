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
    public partial class MaaliyetEkle : Form
    {
        public MaaliyetEkle()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;

        }

        public static string talepno;
        private void MaaliyetEkle_Load(object sender, EventArgs e)
        {
          listele();
        }
    }
}
