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

namespace mROOT._9.UGDR
{
    public partial class RPList : Form
    {
        public RPList()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select ID, Ad from RootTedarikci where Durum = 'Aktif' order by Ad", bgl.baglanti());
            da2.Fill(dt2);
            gridLookUpEdit1.Properties.DataSource = dt2;
            gridLookUpEdit1.Properties.DisplayMember = "Ad";
            gridLookUpEdit1.Properties.ValueMember = "ID";
            gridLookUpEdit2.Properties.DataSource = dt2;
            gridLookUpEdit2.Properties.DisplayMember = "Ad";
            gridLookUpEdit2.Properties.ValueMember = "ID";
            gridLookUpEdit3.Properties.DataSource = dt2;
            gridLookUpEdit3.Properties.DisplayMember = "Ad";
            gridLookUpEdit3.Properties.ValueMember = "ID";
            gridLookUpEdit4.Properties.DataSource = dt2;
            gridLookUpEdit4.Properties.DisplayMember = "Ad";
            gridLookUpEdit4.Properties.ValueMember = "ID";
            gridLookUpEdit5.Properties.DataSource = dt2;
            gridLookUpEdit5.Properties.DisplayMember = "Ad";
            gridLookUpEdit5.Properties.ValueMember = "ID";
        }

        public static string uID, rNo;
        private void RPList_Load(object sender, EventArgs e)
        {
            listele();
            detaybul();
            Text = rNo + " Responsible Person List";
        }

        private void gridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        void detaybul()
        {
            SqlCommand komut2 = new SqlCommand("select * from rRPList where UrunID = '" + uID + "' ", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                gridLookUpEdit1.EditValue = dr2["TR"].ToString();
                gridLookUpEdit2.EditValue = dr2["EU"].ToString();
                gridLookUpEdit3.EditValue = dr2["UK"].ToString();
                gridLookUpEdit4.EditValue = dr2["US"].ToString();
                gridLookUpEdit5.EditValue = dr2["IL"].ToString();
            }
            bgl.baglanti().Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //kaydet

            SqlCommand add2 = new SqlCommand(@"BEGIN TRANSACTION
                    update rRPList set TR =@a1, EU=@a2, UK=@a3, IL=@a4, US=@a5 
                    where UrunID = '" + uID + "' COMMIT TRANSACTION", bgl.baglanti());
            add2.Parameters.AddWithValue("@a1", (object)gridLookUpEdit1.EditValue ?? DBNull.Value);
            add2.Parameters.AddWithValue("@a2", (object)gridLookUpEdit2.EditValue ?? DBNull.Value);
            add2.Parameters.AddWithValue("@a3", (object)gridLookUpEdit3.EditValue ?? DBNull.Value);
            add2.Parameters.AddWithValue("@a4", (object)gridLookUpEdit4.EditValue ?? DBNull.Value);
            add2.Parameters.AddWithValue("@a5", (object)gridLookUpEdit5.EditValue ?? DBNull.Value);
            add2.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Güncelleme başarılı", "Oooppss!!");
        }
    }
}
