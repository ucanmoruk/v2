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
    public partial class Teslim : Form
    {
        public Teslim()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();
        TeklifListe n = (TeklifListe)System.Windows.Forms.Application.OpenForms["TeklifListe"];

        public static string sID, sNo;
        private void Teslim_Load(object sender, EventArgs e)
        {
            dateEdit1.EditValue = DateTime.Now;
            Text = sNo + " No'lu Sipariş Teslim Tarihi";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlCommand komutaz = new SqlCommand(@"update rTeklifListe set TeslimTarihi=@a1, GenelDurum=@a2 where ID = '" + sID + "' ", bgl.baglanti());
            komutaz.Parameters.AddWithValue("@a1", dateEdit1.EditValue);
            komutaz.Parameters.AddWithValue("@a2", "Teslim Edildi");
            komutaz.ExecuteNonQuery();
            bgl.baglanti().Close();

            if (Application.OpenForms["TeklifListe"] == null)
            {

            }
            else
            {
                n.listele();
            }

            sID = null;
            sNo = null;

            this.Close();
        }
    }
}
