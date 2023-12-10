using DevExpress.XtraEditors;
using mKYS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mROOT._2.Product
{
    public partial class NumYeni : Form
    {
        NumList n = (NumList)System.Windows.Forms.Application.OpenForms["NumList"];

        public NumYeni()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();

        public void Firma()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select ID, Ad from RootTedarikci where Durum= 'Aktif'", bgl.baglanti());
            da2.Fill(dt2);

            gridrfirma.Properties.DataSource = dt2;
            gridrfirma.Properties.DisplayMember = "Ad";
            gridrfirma.Properties.ValueMember = "ID";

            DataTable dt22 = new DataTable();
            SqlDataAdapter da22 = new SqlDataAdapter("select ID, Ad from RootTedarikci where Durum= 'Aktif'", bgl.baglanti());
            da22.Fill(dt22);

            gridgfirma.Properties.DataSource = dt22;
            gridgfirma.Properties.DisplayMember = "Ad";
            gridgfirma.Properties.ValueMember = "ID";
        }



        public static int EvrakNo, maxevrak, e1;
        void Evrakmax()
        {
            SqlCommand komutm = new SqlCommand("select max(EvrakNo) from NKRDermatoloji", bgl.baglanti());
            SqlDataReader drm = komutm.ExecuteReader();
            while (drm.Read())
            {
                e1 = Convert.ToInt32(drm[0].ToString());
            }
            bgl.baglanti().Close();

            if (e1 == 0)
            {
                maxevrak = 0; 
            }
            else
            {
                maxevrak = e1;
            }
        }

        public static int maxrapor, r1;
        void RaporNoMax()
        {
            SqlCommand komutm = new SqlCommand("select MAX(RaporNo) from NKRDermatoloji", bgl.baglanti());
            SqlDataReader drm = komutm.ExecuteReader();
            while (drm.Read())
            {
                r1 = Convert.ToInt32(drm[0].ToString());
            }
            bgl.baglanti().Close();

            if (r1 == 0)
            {
                maxrapor = 0;
            }
            else
            {
                maxrapor = r1;
            }

        }


        public static string rID;
        private void NumuneKabul_Load(object sender, EventArgs e)
        {
            Firma();
            dateTime.EditValue = DateTime.Now;

            if (rID == "" || rID == null)
            {
                Evrakmax();
                RaporNoMax();
                txtEvrak.Text = (maxevrak + 1).ToString();
                txtRapor.Text = (maxrapor + 1).ToString();
            }
            else
            {
                kayit.Text = "Güncelle";
                detaybul();
            }
                      

        }

        void detaybul()
        {
            SqlCommand komutID = new SqlCommand("Select * From NKRDermatoloji where ID= N'" + rID + "'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                dateTime.EditValue = Convert.ToDateTime(drI["Kabul"].ToString());
                dateTest.EditValue = Convert.ToDateTime(drI["Tdate"].ToString());
                dateTermin.EditValue = Convert.ToDateTime(drI["Rdate"].ToString());
                txtEvrak.Text = drI["EvrakNo"].ToString();
                txtRapor.Text = drI["RaporNo"].ToString();
                gridrfirma.EditValue = drI["RaporFirmaID"].ToString();
                gridgfirma.EditValue = drI["ProjeFirmaID"].ToString();
                txtNumune.Text = drI["NumAd"].ToString();
                txtmarka.Text = drI["Marka"].ToString();
                txtgorunum.Text = drI["Appearance"].ToString();
                txtambalaj.Text = drI["Package"].ToString();
                txtmiktar.Text = drI["Amount"].ToString();
                txtlot.Text = drI["Lot"].ToString();
                txturetim.Text = drI["Uretim"].ToString();
                txtskt.Text = drI["SKT"].ToString();
                txtdetay.Text = drI["Aciklama"].ToString();
            }
            bgl.baglanti().Close();
        }

        void kaydet()
        {
            SqlCommand komut = new SqlCommand("BEGIN TRANSACTION " +
                        "insert into NKRDermatoloji (Kabul, Tdate, Rdate, EvrakNo, RaporNo, RaporFirmaID, ProjeFirmaID, NumAd, Marka, Appearance, Package, Amount, Lot, Uretim, SKT, Durum, Fatura, Aciklama) values (@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9,@a10,@a11,@a12,@a13,@a14,@a15,@a16, @a17, @a18); " +
                        "COMMIT TRANSACTION", bgl.baglanti());
            komut.Parameters.AddWithValue("@a1", dateTime.EditValue);
            komut.Parameters.AddWithValue("@a2", dateTest.EditValue);
            komut.Parameters.AddWithValue("@a3", dateTermin.EditValue);
            komut.Parameters.AddWithValue("@a4", txtEvrak.Text);
            komut.Parameters.AddWithValue("@a5", txtRapor.Text);
            komut.Parameters.AddWithValue("@a6", gridrfirma.EditValue);
            komut.Parameters.AddWithValue("@a7", gridgfirma.EditValue);
            komut.Parameters.AddWithValue("@a8", txtNumune.Text);
            komut.Parameters.AddWithValue("@a9", txtmarka.Text);
            komut.Parameters.AddWithValue("@a10", txtgorunum.Text);
            komut.Parameters.AddWithValue("@a11", txtambalaj.Text);
            komut.Parameters.AddWithValue("@a12", txtmiktar.Text);
            komut.Parameters.AddWithValue("@a13", txtlot.Text);
            komut.Parameters.AddWithValue("@a14", txturetim.Text);
            komut.Parameters.AddWithValue("@a15", txtskt.Text);
            komut.Parameters.AddWithValue("@a16", "Yeni Kayıt");
            komut.Parameters.AddWithValue("@a17", "Kesilmedi");
            komut.Parameters.AddWithValue("@a18", txtdetay.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();

        }

        private void NumYeni_FormClosed(object sender, FormClosedEventArgs e)
        {
            rID = null;
        }

        void guncelle()
        {
            SqlCommand komut = new SqlCommand(@"update NKRDermatoloji set 
            Kabul=@a1, Tdate=@a2, Rdate=@a3, EvrakNo=@a4, RaporNo=@a5, RaporFirmaID=@a6, ProjeFirmaID=@a7, 
            NumAd=@a8, Marka=@a9, Appearance=@a10, 
            Package=@a11, Amount=@a12, Lot=@a13, Uretim=@a14, SKT=@a15, Aciklama = @a16
            where ID = '" + rID + "'; ", bgl.baglanti());
            komut.Parameters.AddWithValue("@a1", dateTime.EditValue);
            komut.Parameters.AddWithValue("@a2", dateTest.EditValue);
            komut.Parameters.AddWithValue("@a3", dateTermin.EditValue);
            komut.Parameters.AddWithValue("@a4", txtEvrak.Text);
            komut.Parameters.AddWithValue("@a5", txtRapor.Text);
            komut.Parameters.AddWithValue("@a6", gridrfirma.EditValue);
            komut.Parameters.AddWithValue("@a7", gridgfirma.EditValue);
            komut.Parameters.AddWithValue("@a8", txtNumune.Text);
            komut.Parameters.AddWithValue("@a9", txtmarka.Text);
            komut.Parameters.AddWithValue("@a10", txtgorunum.Text);
            komut.Parameters.AddWithValue("@a11", txtambalaj.Text);
            komut.Parameters.AddWithValue("@a12", txtmiktar.Text);
            komut.Parameters.AddWithValue("@a13", txtlot.Text);
            komut.Parameters.AddWithValue("@a14", txturetim.Text);
            komut.Parameters.AddWithValue("@a15", txtskt.Text);
            komut.Parameters.AddWithValue("@a16", txtdetay.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Güncelleme işlemi başarılı!", "Oopss", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }


        private void kayit_Click(object sender, EventArgs e)
        {
            if (kayit.Text == "Güncelle")
            {
                guncelle();
            }
            else
            {
                kaydet();

                DialogResult cikis = new DialogResult();
                cikis = MessageBox.Show("Numune ekleme işlemi başarılı!" + "\n" + "\n" + "Yeni numune eklemek istiyor musunuz ?", "Ooppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (cikis == DialogResult.Yes)
                { temizle(); }
                else
                { this.Close(); }
            }


            if (Application.OpenForms["NumList"] == null)
            {

            }
            else
            {
                n.listele();
            }
        }


        void temizle()
        {
            RaporNoMax();
            txtRapor.Text = (maxrapor + 1).ToString();
        }



    


    }
}
