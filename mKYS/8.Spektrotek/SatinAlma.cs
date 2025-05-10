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
    public partial class SatinAlma : Form
    {
        public SatinAlma()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();
        SatinListe n = (SatinListe)System.Windows.Forms.Application.OpenForms["SatinListe"];

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select Malzeme, Fiyat, Stok from SSatinAlim where Durum='Aktif' and TalepID = '" + TalepID + "'", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            bgl.baglanti().Close();

            this.gridView1.Columns[0].Width = 175;
            this.gridView1.Columns[1].Width = 50;
            this.gridView1.Columns[2].Width = 50;

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select ID, Ad from RootTedarikci where Durum = 'Aktif' and Kimin = 'Spektrotek' order by Ad", bgl.baglanti());
            da2.Fill(dt2);
            gridLookUpEdit1.Properties.DataSource = dt2;
            gridLookUpEdit1.Properties.DisplayMember = "Ad";
            gridLookUpEdit1.Properties.ValueMember = "ID";
        }

        int sorgun;
        public static string TalepNo, TalepID;
        private void SatinAlma_Load(object sender, EventArgs e)
        {
            listele();
            dateEdit1.EditValue = DateTime.Now;
            Text = TalepNo + " Numaralı Talep İçin Satın Alma Detayları";
            if (TalepID == "" || TalepID == null)
            {

            }
            else
            {
                detaybul();
            }
        }

        void detaybul()
        {
            SqlCommand komut = new SqlCommand("select * from SSatinAlim where ID = '" + TalepID + "'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                //combo_tur.Text = dr["TeklifTuru"].ToString();
                gridLookUpEdit1.EditValue = dr["TedarikciID"].ToString();
                textEdit1.Text = dr["Aciklama"].ToString();
            }
            bgl.baglanti().Close();
        }

        void kaydet()
        {     
            for (int ik = 0; ik <= gridView1.RowCount - 2; ik++)
            {
                SqlCommand komutz = new SqlCommand(@"insert into SSatinAlim
                (TalepID, TedarikciID, OlusturanID, Tarih, Aciklama, Malzeme,Fiyat,Stok,Durum) 
                values (@a1, @a2, @a3, @a4, @a5, @a6, @a7, @a8, @a9)", bgl.baglanti());
                komutz.Parameters.AddWithValue("@a1", TalepID);
                komutz.Parameters.AddWithValue("@a2", gridLookUpEdit1.EditValue);
                komutz.Parameters.AddWithValue("@a3", Giris.kullaniciID);
                komutz.Parameters.AddWithValue("@a4", dateEdit1.EditValue);
                komutz.Parameters.AddWithValue("@a5", textEdit1.Text);
                komutz.Parameters.AddWithValue("@a6", gridView1.GetRowCellValue(ik, "Malzeme").ToString());
                komutz.Parameters.AddWithValue("@a7", gridView1.GetRowCellValue(ik, "Fiyat").ToString());
                komutz.Parameters.AddWithValue("@a8", gridView1.GetRowCellValue(ik, "Stok").ToString());
                komutz.Parameters.AddWithValue("@a9", "Aktif");
                komutz.ExecuteNonQuery();
                bgl.baglanti().Close();
            }
        }

        void eskisil()
        {
            SqlCommand komutz = new SqlCommand("delete from SSatinAlim where TalepID =N'" + TalepID + "' ", bgl.baglanti());
            komutz.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        private void btn_tanimla_Click(object sender, EventArgs e)
        {
            kaydetlog();
            eskisil();
            kaydet();
      
            if (Application.OpenForms["SatinListe"] == null)
            {

            }
            else
            {
                n.listele();
            }

            MessageBox.Show("Oppss! Kaydetme işlemi başarılı!" , "Ooppss", MessageBoxButtons.OK, MessageBoxIcon.Information);

            TalepID = null;
            TalepNo = null;

            this.Close();
        }

        private void gridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        private void SatinAlma_FormClosed(object sender, FormClosedEventArgs e)
        {
            TalepID = null;
        }

        void kaydetlog()
        {
            for (int ik = 0; ik <= gridView1.RowCount - 2; ik++)
            {
                SqlCommand komutz = new SqlCommand(@"insert into SSatinAlim_Log
                (TalepID, TedarikciID, OlusturanID, Tarih, Aciklama, Malzeme,Fiyat,Stok,Durum, Sebep, OlusturmaTarih) 
                values (@a1, @a2, @a3, @a4, @a5, @a6, @a7, @a8, @a9, @a10, @a11)", bgl.baglanti());
                komutz.Parameters.AddWithValue("@a1", TalepID);
                komutz.Parameters.AddWithValue("@a2", gridLookUpEdit1.EditValue);
                komutz.Parameters.AddWithValue("@a3", Giris.kullaniciID);
                komutz.Parameters.AddWithValue("@a4", dateEdit1.EditValue);
                komutz.Parameters.AddWithValue("@a5", textEdit1.Text);
                komutz.Parameters.AddWithValue("@a6", gridView1.GetRowCellValue(ik, "Malzeme").ToString().ToUpper());
                komutz.Parameters.AddWithValue("@a7", gridView1.GetRowCellValue(ik, "Fiyat").ToString().ToUpper());
                komutz.Parameters.AddWithValue("@a8", gridView1.GetRowCellValue(ik, "Stok").ToString().ToUpper());
                komutz.Parameters.AddWithValue("@a9", "Aktif");
                komutz.Parameters.AddWithValue("@a10", "insert");
                komutz.Parameters.AddWithValue("@a11", DateTime.Now);
                komutz.ExecuteNonQuery();
                bgl.baglanti().Close();
            }
        }
    }
}
