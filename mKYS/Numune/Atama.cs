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
using mKYS.Numune;
using DevExpress.XtraEditors;

namespace mROOT.Numune
{
    public partial class Atama : Form
    {
        public Atama()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        HizmetTermin n = (HizmetTermin)System.Windows.Forms.Application.OpenForms["HizmetTermin"];

        public static List<object> seciliDegerler = new List<object>();

        private void Atama_Load(object sender, EventArgs e)
        {
            listele();
        }

        void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select ID, Ad + ' ' + Soyad as 'Personel' from RootKullanici where Durum = 'Aktif' order by Personel", bgl.baglanti());
            da2.Fill(dt2);
            gridLookUpEdit1.Properties.DataSource = dt2;
            gridLookUpEdit1.Properties.DisplayMember = "Personel";
            gridLookUpEdit1.Properties.ValueMember = "ID";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < seciliDegerler.Count; i++)
            {
                SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                    "update NumuneX1 set HizmetDurum=@o1, Yetkili=@o2 where ID = @o3; " +
                    "COMMIT TRANSACTION", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", "Atama Yapıldı!");
                add2.Parameters.AddWithValue("@o2", gridLookUpEdit1.EditValue);
                add2.Parameters.AddWithValue("@o3", seciliDegerler[i]);
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();
            }

            if (Application.OpenForms["HizmetTermin"] == null)
            {

            }
            else
            {
                n.listele();
            }

            this.Close();

            
        }

        private void gridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }
    }
}
