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

namespace mKYS.Dokuman
{
    public partial class RevizyonYeni : Form
    {
        public RevizyonYeni()
        {
            InitializeComponent();
        }


        sqlbaglanti bgl = new sqlbaglanti();

        public void detaybul()
        {
            SqlCommand komutID = new SqlCommand("Select * From DokumanMaster where ID = '" + dID + "'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                txt_ad.Text = drI["Kod"].ToString() +" - " + drI["Ad"].ToString();
            }
            bgl.baglanti().Close();
        }

        public void rdetaybul()
        {
            SqlCommand komutID = new SqlCommand("Select * From DokumanMaster where ID in (select DokumanID from DokumanRev where ID = '" + rID + "') ", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                txt_ad.Text = drI["Kod"].ToString() + " - " + drI["Ad"].ToString();
            }
            bgl.baglanti().Close();


            SqlCommand komutD = new SqlCommand("Select * From DokumanRev where ID = '" + rID + "'", bgl.baglanti());
            SqlDataReader dr = komutD.ExecuteReader();
            while (dr.Read())
            {
                txt_rev.Text = dr["RevNo"].ToString();
                date_rev.Text = dr["RevTarihi"].ToString();
                txt_madde.Text = dr["Madde"].ToString();
                txt_aciklama.Text = dr["Aciklama"].ToString();
                gridLookUpEdit1.EditValue = dr["PersonelID"].ToString();
            }
            bgl.baglanti().Close();

        }

        public void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select ID, Ad + ' ' + Soyad as 'Personel' from StokKullanici order by Ad", bgl.baglanti());
            da2.Fill(dt2);

            gridLookUpEdit1.Properties.DataSource = dt2;
            gridLookUpEdit1.Properties.DisplayMember = "Personel";
            gridLookUpEdit1.Properties.ValueMember = "ID";
        }

        public static string gelis, dID, rID, pID, revdurum;

        private void RevizyonYeni_Load(object sender, EventArgs e)
        {
            listele();        

            if (gelis == "yeni")
            {
                detaybul();
            }
            else
            {
                rdetaybul();
                btn_yukle.Text = "Güncelle";
            }
        }

        private void gridLookUpEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GridLookUpEdit edit = sender as GridLookUpEdit;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                gridLookUpEdit1.EditValue = null;

            }
        }

        private void gridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        private void gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (gridLookUpEdit1.EditValue == null)
                pID = null;
            else
                pID = gridLookUpEdit1.EditValue.ToString();
        }

        private void RevizyonYeni_FormClosing(object sender, FormClosingEventArgs e)
        {
            gelis = null;
            dID = null;
            rID = null;
        }

        private void txt_rev_KeyPress(object sender, KeyPressEventArgs e)
        {
            // e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)44)
            // text'e sadece sayıların girmesi,geri silme tuşu(ascii kodu:08),virgül(ascii kodu:44) karakterinin girilmesini sağlar.
            //del tuşununda aktif olmasını isterseniz del ascıı kodu:127
            //
            {
                e.Handled = true;
            }
        }

        DokumanGecmis m = (DokumanGecmis)System.Windows.Forms.Application.OpenForms["DokumanGecmis"];

        private void btn_yukle_Click(object sender, EventArgs e)
        {
            if (btn_yukle.Text == "Güncelle")
            {
                guncelle();
            }
            else
            {
                ekleme();

                txt_aciklama.Text = "";
                txt_madde.Text = "";
                txt_rev.Text = "";
                date_rev.Text = "";
                gridLookUpEdit1.EditValue = null;
            }

            if (Application.OpenForms["DokumanGecmis"] == null)
            { }
            else
            {
                m.listele();
            }
        }
        
        void guncelle()
        {
            if (date_rev.Text == "" || date_rev.Text == null)
                revdurum = "--.--.--";
            else
                revdurum = date_rev.Text.ToString();

            SqlCommand add = new SqlCommand("update DokumanRev set RevNo=@a1, RevTarihi=@a2, Madde=@a3, Aciklama=@a4, PersonelID=@a5 where ID = '"+rID+"'", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", txt_rev.Text);
            add.Parameters.AddWithValue("@a2", revdurum);
            add.Parameters.AddWithValue("@a3", txt_madde.Text);
            add.Parameters.AddWithValue("@a4", txt_aciklama.Text);
            add.Parameters.AddWithValue("@a5", pID);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Revizyon bilgisi başarılı bir şekilde güncellendi!", "Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        void ekleme()
        {
            if (date_rev.Text == "" || date_rev.Text == null)
                revdurum = "--.--.--";
            else
                revdurum = date_rev.Text.ToString();

            SqlCommand add = new SqlCommand("insert into DokumanRev (DokumanID, RevNo, RevTarihi, Madde, Aciklama, PersonelID, Durum) values (@a1,@a2,@a3,@a4, @a5, @a6, @a7)", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", dID);
            add.Parameters.AddWithValue("@a2", txt_rev.Text);
            add.Parameters.AddWithValue("@a3", revdurum);
            add.Parameters.AddWithValue("@a4", txt_madde.Text);
            add.Parameters.AddWithValue("@a5", txt_aciklama.Text);
            add.Parameters.AddWithValue("@a6", pID);
            add.Parameters.AddWithValue("@a7", "Aktif");
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
            
            MessageBox.Show("Revizyon bilgisi başarılı bir şekilde eklendi!", "Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
