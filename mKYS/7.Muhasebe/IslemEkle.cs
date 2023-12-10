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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace mROOT._7.Muhasebe
{
    public partial class IslemEkle : Form
    {
        public IslemEkle()
        {
            InitializeComponent();
        }


        sqlbaglanti bgl = new sqlbaglanti();

        public static string iID;
        int t;
        private void IslemEkle_Load(object sender, EventArgs e)
        {
            DateTime tarih = DateTime.Now;
            dateEdit1.EditValue = tarih;

            if (iID == "" || iID == null)
            {
                firmalistele();
            }
            else
            {
                firmalistele();
                t = 1;
                listele();
                Text = "İşlem Güncelleme";
                btn_save.Text = "Güncelle";
                
            }

        }

        private void IslemEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            iID = null;
        }

        public void listele()
        {
            SqlCommand komutID = new SqlCommand("Select * From RootFatura where ID = N'" + iID + "'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                gridLookUpEdit1.EditValue = drI["Firma"].ToString();
                ctur.Text = drI["Tur"].ToString();
                ckategori.Text = drI["Kategori"].ToString();
                codeme.Text = drI["Odeme"].ToString();
                tfatura.Text = drI["FaturaNo"].ToString();
                ttoplam.Text = drI["Toplam"].ToString();
                tkdv.Text = drI["KDV"].ToString();
                ttutar.Text = drI["Tutar"].ToString();
                tbanka.Text = drI["Banka"].ToString();
                taciklama.Text = drI["Aciklama"].ToString();
                if (drI["Tarih"].ToString() == null || drI["Tarih"].ToString() == "")
                    dateEdit1.EditValue = null;
                else
                    dateEdit1.EditValue = Convert.ToDateTime(drI["Tarih"].ToString());

                if (drI["oTarih"].ToString() == null || drI["oTarih"].ToString() == "")
                    dateEdit2.EditValue = null;
                else
                    dateEdit2.EditValue = Convert.ToDateTime(drI["oTarih"].ToString());
            }
            bgl.baglanti().Close();
        }

        void firmalistele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select ID, Ad From RootTedarikci where Durum= N'Aktif'", bgl.baglanti());
            da2.Fill(dt2);
            gridLookUpEdit1.Properties.DataSource = dt2;
            gridLookUpEdit1.Properties.DisplayMember = "Ad";
            gridLookUpEdit1.Properties.ValueMember = "ID";
        }

        void kaydet()
        {
            SqlCommand add = new SqlCommand("insert into RootFatura (Tur, Kategori, Tarih, FaturaNo, Firma, Tutar, KDV, Toplam, Banka, Odeme, Aciklama, Durum,Kim, Nezaman, oTarih) values (@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9,@a10,@a11,@a12,@a13,@a14,@a15)", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", ctur.Text);
            add.Parameters.AddWithValue("@a2", ckategori.Text);
            add.Parameters.AddWithValue("@a3", dateEdit1.EditValue == null ? DBNull.Value : (object)dateEdit1.EditValue);
            add.Parameters.AddWithValue("@a4", tfatura.Text);
            add.Parameters.AddWithValue("@a5", gridLookUpEdit1.EditValue);
            add.Parameters.AddWithValue("@a6", Convert.ToDecimal(ttutar.Text));
            add.Parameters.AddWithValue("@a7", Convert.ToDecimal(tkdv.Text));
            add.Parameters.AddWithValue("@a8", Convert.ToDecimal(ttoplam.Text));
            add.Parameters.AddWithValue("@a9", tbanka.Text);
            add.Parameters.AddWithValue("@a10", codeme.Text);
            add.Parameters.AddWithValue("@a11", taciklama.Text);
            add.Parameters.AddWithValue("@a12", "Aktif");
            add.Parameters.AddWithValue("@a13", Anasayfa.kullanici);
            add.Parameters.AddWithValue("@a14", DateTime.Now);
            add.Parameters.AddWithValue("@a15", dateEdit2.EditValue == null ? DBNull.Value : (object)dateEdit2.EditValue );
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        void guncelle()
        {
            SqlCommand add = new SqlCommand("update RootFatura set Tur=@a1, Kategori=@a2, Tarih=@a3, FaturaNo=@a4, Firma=@a5, Tutar=@a6, KDV=@a7, Toplam=@a8, Banka=@a9, Odeme=@a10, Aciklama=@a11, Guncelleyen=@a12, Guncelleme=@a13, oTarih=@a14 where ID=N'" + iID + "'", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", ctur.Text);
            add.Parameters.AddWithValue("@a2", ckategori.Text);
            add.Parameters.AddWithValue("@a3", dateEdit1.EditValue == null ? DBNull.Value : (object)dateEdit1.EditValue);
            add.Parameters.AddWithValue("@a4", tfatura.Text);
            add.Parameters.AddWithValue("@a5", gridLookUpEdit1.EditValue);
            add.Parameters.AddWithValue("@a6", Convert.ToDecimal(ttutar.Text));
            add.Parameters.AddWithValue("@a7", Convert.ToDecimal(tkdv.Text));
            add.Parameters.AddWithValue("@a8", Convert.ToDecimal(ttoplam.Text));
            add.Parameters.AddWithValue("@a9", tbanka.Text);
            add.Parameters.AddWithValue("@a10", codeme.Text);
            add.Parameters.AddWithValue("@a11", taciklama.Text);
            add.Parameters.AddWithValue("@a12", Anasayfa.kullanici);
            add.Parameters.AddWithValue("@a13", DateTime.Now);
            add.Parameters.AddWithValue("@a14", dateEdit2.EditValue == null ? DBNull.Value : (object)dateEdit2.EditValue);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        IslemListesi m = (IslemListesi)System.Windows.Forms.Application.OpenForms["IslemListesi"];

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (btn_save.Text == "Güncelle")
            {
                guncelle();
                MessageBox.Show("Başarıyla güncellenmiştir!", "Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                kaydet();
                temizle();
                MessageBox.Show("Başarıyla eklenmiştir!", "Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


            if (Application.OpenForms["IslemListesi"] == null)
            {

            }
            else
            {
                m.listele();
            }
        }

        void temizle()
        {
            gridLookUpEdit1.EditValue = null;
            ctur.Text = "";
            ckategori.Text = "";
            codeme.Text = "";
            tfatura.Text = "";
            tbanka.Text = "";
            ttutar.Text = "";
            tkdv.Text = "";
            ttoplam.Text = "";
            taciklama.Text = "";

        }

        private void gridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        private void ttutar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)44)
            {
                e.Handled = true;
            }

        }

        private void tkdv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)44)
            {
                e.Handled = true;
            }
        }

        private void ttoplam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)44)
            {
                e.Handled = true;
            }
        }

        private void ttutar_TextChanged(object sender, EventArgs e)
        {
            if (t==1)
            {

            }
            else
            {
                if (ttutar.Text != "")
                {
                    decimal KDV = 0, Tutar = 0, Toplam = 0;
                    Tutar = Convert.ToDecimal(ttutar.Text);
                    KDV = Tutar * 18 / 100;
                    Toplam = Tutar + KDV;
                    tkdv.Text = Convert.ToString(KDV);
                    ttoplam.Text = Convert.ToString(Toplam);
                }
                if (ttutar.Text == "")
                {
                    tkdv.Text = "";
                    ttoplam.Text = "";
                }
            }

            t = 2;

        }
    }
}
