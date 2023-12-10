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

namespace mROOT._2.Product
{
    public partial class WorkNew : Form
    {
        public WorkNew()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        WorkList m = (WorkList)System.Windows.Forms.Application.OpenForms["WorkList"];

        void firmalistele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select ID, Ad from RootTedarikci where Durum = 'Aktif'", bgl.baglanti());
            da2.Fill(dt2);
            gridLookUpEdit1.Properties.DataSource = dt2;
            gridLookUpEdit1.Properties.DisplayMember = "Ad";
            gridLookUpEdit1.Properties.ValueMember = "ID";
        }

        void listele()
        {           

            SqlCommand komutID = new SqlCommand("Select * From rWorkList where ID= N'" + rID + "'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                combo_kat.Text = drI["Kategori"].ToString();
                txtev.Text = drI["EvrakNo"].ToString();
                txtis.Text = drI["RaporNo"].ToString();
                datenow.EditValue = Convert.ToDateTime(drI["Tarih"].ToString());
                datetermin.EditValue = Convert.ToDateTime(drI["Termin"].ToString());
                gridLookUpEdit1.EditValue = drI["FirmaId"].ToString();
                txturun.Text = drI["Urun"].ToString();
                txthizmet.Text = drI["Hizmet"].ToString();
                txt_not.Text = drI["Notlar"].ToString();

            }
            bgl.baglanti().Close();

        }

        string evrakno, raporno;
        int eno, rno;
        void maxevrak()
        {
            SqlCommand komutm = new SqlCommand("select MAX(EvrakNo) from rWorkList", bgl.baglanti());
            SqlDataReader drm = komutm.ExecuteReader();
            while (drm.Read())
            {
                evrakno = drm[0].ToString();
            }
            bgl.baglanti().Close();

            SqlCommand komutam = new SqlCommand("select MAX(RaporNo) from rWorkList", bgl.baglanti());
            SqlDataReader dram = komutam.ExecuteReader();
            while (dram.Read())
            {
                raporno = dram[0].ToString();
            }
            bgl.baglanti().Close();


            if (evrakno == "" || evrakno == null)
                eno = 1;
            else
                eno = Convert.ToInt32(evrakno) + 1;


            if (raporno == "" || raporno == null)
                rno = 1;
            else
                rno = Convert.ToInt32(raporno) + 1;
        }

        public static string rID;
        private void WorkNew_Load(object sender, EventArgs e)
        {
            firmalistele();

            if (rID == null || rID == "")
            {

                datenow.EditValue = DateTime.Now;
                maxevrak();
                txtev.Text = eno.ToString();
                txtis.Text = rno.ToString();
            }
            else
            {
                listele();
                btnadd.Text = "Güncelle";
            }
        }

        private void WorkNew_FormClosed(object sender, FormClosedEventArgs e)
        {
            rID = null;
        }

        void kaydet()
        {
            SqlCommand add = new SqlCommand(@"insert into rWorkList (Kategori, EvrakNo, RaporNo, Tarih, 
            Termin, FirmaID, Urun, Hizmet, Notlar, IsDurum, Durum)
            values (@a1, @a2, @a3, @a4, @a5, @a6, @a7, @a8, @a9, @a10, @a11) ", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", combo_kat.Text);
            add.Parameters.AddWithValue("@a2", txtev.Text);
            add.Parameters.AddWithValue("@a3", txtis.Text);
            add.Parameters.AddWithValue("@a4", datenow.EditValue);
            add.Parameters.AddWithValue("@a5", datetermin.EditValue);
            add.Parameters.AddWithValue("@a6", gridLookUpEdit1.EditValue);
            add.Parameters.AddWithValue("@a7", txturun.Text);
            add.Parameters.AddWithValue("@a8", txthizmet.Text);
            add.Parameters.AddWithValue("@a9", txt_not.Text);
            add.Parameters.AddWithValue("@a10", "Yeni İş");
            add.Parameters.AddWithValue("@a11","Aktif");
            add.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Kayıt işlemi başarılı!", "Oopppss!");
        }

        private void gridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        void guncelle()
        {
            SqlCommand add = new SqlCommand(@"update rWorkList set 
            Kategori=@a1, EvrakNo=@a2, RaporNo=@a3, Tarih=@a4, Termin=@a5, FirmaID=@a6, 
            Urun=@a7, Hizmet=@a8, Notlar=@a9            
            where ID = '" + rID + "' ", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", combo_kat.Text);
            add.Parameters.AddWithValue("@a2", txtev.Text);
            add.Parameters.AddWithValue("@a3", txtis.Text);
            add.Parameters.AddWithValue("@a4", datenow.EditValue);
            add.Parameters.AddWithValue("@a5", datetermin.EditValue);
            add.Parameters.AddWithValue("@a6", gridLookUpEdit1.EditValue);
            add.Parameters.AddWithValue("@a7", txturun.Text);
            add.Parameters.AddWithValue("@a8", txthizmet.Text);
            add.Parameters.AddWithValue("@a9", txt_not.Text);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Güncelleme işlemi başarılı!", "Oopppss!");
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (btnadd.Text == "Güncelle")
            {
                guncelle();
            }
            else
            {
                kaydet();

                DialogResult cikis = new DialogResult();
                cikis = MessageBox.Show("Yeni kayıt ?", "Ooppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (cikis == DialogResult.Yes)
                {
                    maxevrak();
                    txtis.Text = rno.ToString();

                }
                else
                { this.Close(); }
            }

            if (Application.OpenForms["WorkList"] == null)
            {

            }
            else
            {
                m.listele();
            }

        }
    }
}
