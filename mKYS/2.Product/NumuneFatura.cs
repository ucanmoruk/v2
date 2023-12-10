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
    public partial class NumuneFatura : Form
    {
        public NumuneFatura()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        WorkList h = (WorkList)System.Windows.Forms.Application.OpenForms["WorkList"];
        NumList n = (NumList)System.Windows.Forms.Application.OpenForms["NumList"];

        void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(@"select f.ID, f.FaturaNo, t.Ad, f.Toplam from RootFatura f 
            left join RootTedarikci t on f.Firma = t.ID", bgl.baglanti());
            da2.Fill(dt2);

            gridLookUpEdit1.Properties.DataSource = dt2;
            gridLookUpEdit1.Properties.DisplayMember = "Toplam";
            gridLookUpEdit1.Properties.ValueMember = "ID";
        }

        public static string no,gelis;
        private void NumuneFatura_Load(object sender, EventArgs e)
        {
            Text = no + " Evrak Numaralı Kayıtların Faturası";
            listele();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (gelis == "ÜGD")
            {
                SqlCommand komut = new SqlCommand("BEGIN TRANSACTION " +
                                   "update rWorkList set FaturaID = @a1 where ID = '"+no+"'; " +
                                   "COMMIT TRANSACTION", bgl.baglanti());
                komut.Parameters.AddWithValue("@a1", gridLookUpEdit1.EditValue);
              //  komut.Parameters.AddWithValue("@a2", no);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
            }
            else
            {
                SqlCommand komut = new SqlCommand("BEGIN TRANSACTION " +
                    "insert into NKRFatura (FaturaID, EvrakNo) values (@a1,@a2); " +
                    "COMMIT TRANSACTION", bgl.baglanti());
                komut.Parameters.AddWithValue("@a1", gridLookUpEdit1.EditValue);
                komut.Parameters.AddWithValue("@a2", no);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
           
            }

            if (Application.OpenForms["NumList"] == null)
            {

            }
            else
            {
                n.listele();
            }

            if (Application.OpenForms["WorkList"] == null)
            {

            }
            else
            {
                h.listele();
            }

            MessageBox.Show("Eşleştirme işlemi başarılı!", "Oopss", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            this.Close();

        }
    }
}
