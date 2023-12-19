using DevExpress.XtraEditors;
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
    public partial class STalepAtama : Form
    {
        public STalepAtama()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();
        STalepListe m = (STalepListe)System.Windows.Forms.Application.OpenForms["STalepListe"];


        void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(@"select t.ID, t.TeklifNo, f.Ad from STeklifListe t
            left join RootTedarikci f on t.FirmaID = f.ID 
            where t.Durum = 'Aktif' order by ID desc", bgl.baglanti());
            da2.Fill(dt2);
            gridLookUpEdit1.Properties.DataSource = dt2;
            gridLookUpEdit1.Properties.DisplayMember = "TeklifNo";
            gridLookUpEdit1.Properties.ValueMember = "ID";
        }

        public static string talepID, talepNo;
        private void STalepAtama_Load(object sender, EventArgs e)
        {
          
            labelControl1.Text = talepNo + " numaralı talep..";
            listele();
        }

        private void gridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        private void STalepAtama_FormClosed(object sender, FormClosedEventArgs e)
        {
            talepID = null;
            talepNo = null;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlCommand add2 = new SqlCommand("update STalepListe set TeklifID=@a1 where ID = '" + talepID + "' ", bgl.baglanti());
            add2.Parameters.AddWithValue("@a1", gridLookUpEdit1.EditValue);
            add2.ExecuteNonQuery();
            bgl.baglanti().Close();

            SqlCommand add = new SqlCommand(@"insert into STalepListeLog (TalepNo, TeklifID, logtur, logKisiID, logTarih)
            values (@a1,  @a3, @a4, @a5, @a6)", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", talepNo);
            add.Parameters.AddWithValue("@a3", gridLookUpEdit1.EditValue);
            add.Parameters.AddWithValue("@a4", "Teklif İletildi");
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
    }
}
