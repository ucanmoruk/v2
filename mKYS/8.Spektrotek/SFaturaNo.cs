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

namespace mROOT._8.Spektrotek
{
    public partial class SFaturaNo : Form
    {
        public SFaturaNo()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();
        STalepListe m = (STalepListe)System.Windows.Forms.Application.OpenForms["STalepListe"];

        public static string talepID, talepno;

        private void SFaturaNo_FormClosed(object sender, FormClosedEventArgs e)
        {
            talepID = null;
            talepno = null;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlCommand add2 = new SqlCommand("update STalepListe set FaturaNo=@a1 where ID = '" + talepID + "' ", bgl.baglanti());
            add2.Parameters.AddWithValue("@a1",textEdit1.Text);
            add2.ExecuteNonQuery();
            bgl.baglanti().Close();

            SqlCommand add = new SqlCommand(@"insert into STalepListeLog (TalepNo, FaturaNo, logtur, logKisiID, logTarih)
            values (@a1,  @a3, @a4, @a5, @a6)", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", talepno);
            add.Parameters.AddWithValue("@a3", textEdit1.Text);
            add.Parameters.AddWithValue("@a4", "Fatura No Eklendi");
            add.Parameters.AddWithValue("@a5", Anasayfa.kullanici);
            add.Parameters.AddWithValue("@a6", DateTime.Now);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();

            if (Application.OpenForms["STalepListe"] == null)
            {

            }
            else
            {
                m.listele();
            }

            this.Close();
        }

        private void SFaturaNo_Load(object sender, EventArgs e)
        {
            labelControl1.Text = talepno + " numaralı talep..";

            SqlCommand komutID = new SqlCommand("Select * From STalepListe where ID= N'" + talepID + "'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                textEdit1.Text = drI["FaturaNo"].ToString();
            }
            bgl.baglanti().Close();
        }
    }
}
