using mKYS;
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

namespace mROOT._2.Product
{
    public partial class WorkFatura : Form
    {
        public WorkFatura()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public static string wID;
        private void WorkFatura_Load(object sender, EventArgs e)
        {
            Text = wID + " Evrak No";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update rWorkList set FatNo=@r3, Odeme = @r1 where EvrakNo=@r2", bgl.baglanti());
            komut.Parameters.AddWithValue("@r1", "Ödeme Bekliyor");
            komut.Parameters.AddWithValue("@r2", wID);
            komut.Parameters.AddWithValue("@r3", txt_no.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            this.Close();
        }
    }
}
