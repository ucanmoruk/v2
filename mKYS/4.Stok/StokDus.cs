using DevExpress.XtraEditors;
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

namespace mKYS
{
    public partial class StokDus : Form
    {
        public StokDus()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        private void listele()
        {
            //SqlCommand komutID = new SqlCommand("Select * From StokListesi where Durum= N'Aktif'", bgl.baglanti());

            //SqlCommand komutID = new SqlCommand("Select * From StokListesi where ID in (select StokID from StokHareket where Durum= N'Aktif' and BirimID = '"+Anasayfa.birimID+"')", bgl.baglanti());
            //SqlDataReader drI = komutID.ExecuteReader();
            //while (drI.Read())
            //{
            //    combokod.Properties.Items.Add(drI["Kod"].ToString());
            //}
            //bgl.baglanti().Close();

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select ID, Kod, Ad From RootStokListesi where ID in (select StokID from RootStokHareket where Durum= N'Aktif' and BirimID = '" + Anasayfa.birimID + "')", bgl.baglanti());
            da2.Fill(dt2);
            gridLookUpEdit1.Properties.DataSource = dt2;
            gridLookUpEdit1.Properties.DisplayMember = "Kod";
            gridLookUpEdit1.Properties.ValueMember = "ID";
        }

        private void temizle()
        {
            combo_marka.Text = "";
            txtmiktar.Text = "";
            txtbirim.Text = "";
        }
                
        private void StokDus_Load(object sender, EventArgs e)
        {
            listele();

            DateTime tarih = DateTime.Now;
            dategiris.EditValue = tarih;
        }

        string stokid;
        string marka, lot, skt, marka2, lot2, skt2;

        private void combo_marka_SelectedIndexChanged(object sender, EventArgs e)
        {
            // marka bul
            if (combo_marka.Text == "")
            {

            }
            else
            {
                string[] result = combo_marka.Text.Split('/');
                marka2 = result[0].Trim(' ');
                lot2 = result[1].Trim(' ');
            }

        }

        private void combokod_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void cikarma()
        {
            //float f1 = float.Parse(txtmiktar.Text);
            //float f2 = f1 * -1;

            double f1 = Convert.ToDouble(txtmiktar.Text);
            double f2 = f1 * -1;

            SqlCommand add = new SqlCommand("insert into RootStokHareket (StokID, Marka,Lot,Miktar,Birim,Tarih,Hareket, BirimID, Durum) values (@a1,@a2,@a3,@a4,@a5,@a7,@a8,@a9,@a10)", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", stokid);
            add.Parameters.AddWithValue("@a2", marka2);
            add.Parameters.AddWithValue("@a3", lot2);
            add.Parameters.AddWithValue("@a4", f2);
            add.Parameters.AddWithValue("@a5", txtbirim.Text);
            add.Parameters.AddWithValue("@a7", dategiris.EditValue);
            add.Parameters.AddWithValue("@a8", "Çıkış");
            add.Parameters.AddWithValue("@a9", Anasayfa.birimID);
            add.Parameters.AddWithValue("@a10", "Aktif");
            add.ExecuteNonQuery();
            bgl.baglanti().Close();


        }

        private void gridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        private void gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            temizle();
            combo_marka.Properties.Items.Clear();
            SqlCommand komutID = new SqlCommand("Select * From RootStokListesi where ID = N'" + gridLookUpEdit1.EditValue + "'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {               
                txtbirim.Text = drI["Birim"].ToString();
            }
            bgl.baglanti().Close();

            SqlCommand komutD = new SqlCommand("select distinct Marka, Lot from RootStokHareket where StokID = '" + gridLookUpEdit1.EditValue+"' and BirimID = '" + Anasayfa.birimID + "' order by Marka", bgl.baglanti());
            SqlDataReader dr = komutD.ExecuteReader();
            while (dr.Read())
            {
                marka = dr["Marka"].ToString();
                lot = dr["Lot"].ToString();
                combo_marka.Properties.Items.Add(marka + " / " + lot);
            }
            bgl.baglanti().Close();

            if (gridLookUpEdit1.EditValue == null)
                stokid = null;
            else
                stokid = gridLookUpEdit1.EditValue.ToString();
        }

       // string stokk;
        double stok;
        private void anastok()
        {
           // SqlCommand komutID = new SqlCommand("select SUM(Miktar) from StokHareket where StokID in (select ID from StokListesi where  Kod = N'" + combokod.Text + "') ", bgl.baglanti());
            SqlCommand komutID = new SqlCommand("select SUM(Miktar) from RootStokHareket where StokID = '" + gridLookUpEdit1.EditValue+"' and Durum = 'Aktif'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                stok = Convert.ToDouble(drI[0].ToString());
            }
            bgl.baglanti().Close();
            //stok = float.Parse(stokk);
          //  stok = Convert.ToDouble(stokk);


            SqlCommand add = new SqlCommand("update RootStokListesi set Miktar = @a1 where ID = N'" + gridLookUpEdit1.EditValue+ "'", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", stok);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();

        }

        StokListesi m = (StokListesi)System.Windows.Forms.Application.OpenForms["StokListesi"];

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (combo_marka.Text == "")
            {
                MessageBox.Show("Lütfen marka ve lot seçimi yapınız. ");
            }
            else
            {
                cikarma();
                anastok();

                if (Application.OpenForms["StokListesi"] == null)
                {

                }
                else
                {
                    m.listele();
                }

                MessageBox.Show("Stoğunuz başarı ile güncellenmiştir!", "Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
   
        }
    }
}
