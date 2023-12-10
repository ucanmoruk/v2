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
using mKYS.Analiz;

namespace mKYS.Stok
{
    public partial class ReceteDus : Form
    {
        public ReceteDus()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        private void listele()
        {
            DataTable dt2 = new DataTable();
           // SqlDataAdapter da2 = new SqlDataAdapter("Select ID, Kod, Ad From RootUrunListesi where Durum = 'Aktif' and ID in (select distinct AnalizID from RootRecete) order by Kod ", bgl.baglanti());
            SqlDataAdapter da2 = new SqlDataAdapter("Select ID, Kod, Ad From RootUrunListesi where Durum = 'Aktif' order by Kod ", bgl.baglanti());
            da2.Fill(dt2);

            gridLookUpEdit1.Properties.DataSource = dt2;
            gridLookUpEdit1.Properties.DisplayMember = "Ad";
            gridLookUpEdit1.Properties.ValueMember = "ID";

            DataTable dt21 = new DataTable();
            SqlDataAdapter da21 = new SqlDataAdapter("Select ID, Birim From RootFirmaBirim where Durum=N'Aktif' and FirmaID = N'" + Anasayfa.firmaID + "'", bgl.baglanti());
            da21.Fill(dt21);

            gridLookUpEdit2.Properties.DataSource = dt21;
            gridLookUpEdit2.Properties.DisplayMember = "Birim";
            gridLookUpEdit2.Properties.ValueMember = "ID";
            gridLookUpEdit2.EditValue = Anasayfa.birimID;
        }

        void listele2()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select ID, Kod, Ad From RootUrunListesi where Durum = 'Aktif' and Miktar > 0 order by Kod ", bgl.baglanti());
            da2.Fill(dt2);

            gridLookUpEdit1.Properties.DataSource = dt2;
            gridLookUpEdit1.Properties.DisplayMember = "Ad";
            gridLookUpEdit1.Properties.ValueMember = "ID";

            DataTable dt21 = new DataTable();
            SqlDataAdapter da21 = new SqlDataAdapter("Select ID, Birim From RootFirmaBirim where Durum=N'Aktif' and FirmaID = N'" + Anasayfa.firmaID + "'", bgl.baglanti());
            da21.Fill(dt21);

            gridLookUpEdit2.Properties.DataSource = dt21;
            gridLookUpEdit2.Properties.DisplayMember = "Birim";
            gridLookUpEdit2.Properties.ValueMember = "ID";
            gridLookUpEdit2.EditValue = Anasayfa.birimID;
        }

        public static string gelis;
        private void ReceteDus_Load(object sender, EventArgs e)
        {
            Text = gelis;
            listele();

            if (gelis == "Üretim Bildirimi")
            {
                listele();
                btn_ok.Visible = true;
            }
            else
            {
                listele2();
                simpleButton1.Visible = true;
            }

        }

        private void gridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        AnalizListesi m = (AnalizListesi)System.Windows.Forms.Application.OpenForms["AnalizListesi"];
        StokListesi s = (StokListesi)System.Windows.Forms.Application.OpenForms["StokListesi"];

        double miktar, dusus, yenistok, adet, stokstok;
        string stokid, eskistok, sbirim;

        private void gridLookUpEdit2_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //satış
            if (dateEdit1.EditValue == null)
            {
                MessageBox.Show("Lütfen tarih seçiniz!..");
            }
            else
            {
                if (txtadet.Text == "")
                {
                    MessageBox.Show("Lütfen ürün sayısını belirtiniz!..");
                }
                else
                {
                    satis();
                    anastok();
                    if (Application.OpenForms["AnalizListesi"] == null)
                    {

                    }
                    else
                    {
                        m.listele();
                    }

                    MessageBox.Show("Bol satışlar, bol kazançlar!", "Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtadet.Text = null;
                    memoEdit1.Text = null;
                }

            }
        }

        void cikarma()
        {
 

            SqlCommand komutID = new SqlCommand("select * from RootRecete where AnalizID = '" + gridLookUpEdit1.EditValue + "' ", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                stokid = drI["StokID"].ToString();
                miktar = Convert.ToDouble(drI["Miktar"].ToString());
                adet = Convert.ToDouble(txtadet.Text);
                //  float adet = float.Parse(txtadet.Text);

                SqlCommand komutx = new SqlCommand("select Birim from RootStokListesi where ID = '" + stokid + "' ", bgl.baglanti());
                SqlDataReader drx = komutx.ExecuteReader();
                while (drx.Read())
                {
                    sbirim = drx[0].ToString();
                }
                bgl.baglanti().Close();


                if (miktar == 0)
                {

                }
                else
                {
                    dusus = miktar * adet * -1;
                    SqlCommand add2 = new SqlCommand("insert into RootStokHareket (StokID, Tarih, Hareket, BirimID, Durum, Marka, Miktar, Birim, UretimID) values (@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9)", bgl.baglanti());
                    add2.Parameters.AddWithValue("@a1", stokid);
                    add2.Parameters.AddWithValue("@a2", dateEdit1.EditValue);
                    add2.Parameters.AddWithValue("@a3", "Üretim");
                    add2.Parameters.AddWithValue("@a4", gridLookUpEdit2.EditValue);
                    add2.Parameters.AddWithValue("@a5", "Aktif");
                    add2.Parameters.AddWithValue("@a6", memoEdit1.Text);
                    add2.Parameters.AddWithValue("@a7", dusus);
                    add2.Parameters.AddWithValue("@a8", sbirim);                    
                    add2.Parameters.AddWithValue("@a9", uretimID);                    
                    add2.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    //ana stok listesini de güncelel 
                    SqlCommand komuta = new SqlCommand("select SUM(Miktar) from RootStokHareket where StokID = '" + stokid + "' ", bgl.baglanti());
                    SqlDataReader dra = komuta.ExecuteReader();
                    while (dra.Read())
                    {
                       stokstok = Convert.ToDouble(dra[0].ToString());
                    }
                    bgl.baglanti().Close();


                    SqlCommand add = new SqlCommand("update RootStokListesi set Miktar = @a1 where ID = N'" + stokid + "'", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", stokstok);
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();



                }


            }
            bgl.baglanti().Close();
            if (Application.OpenForms["StokListesi"] == null)
            {

            }
            else
            {
                s.listele();
            }
        }

        void satis()
        {
            satismiktar = Convert.ToInt32(txtadet.Text) * -1;

            SqlCommand add2 = new SqlCommand("insert into RootUrunHareket (UrunID, BirimID, Hareket, Miktar,Aciklama,Tarih, Durum, Fiyat) values (@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8)", bgl.baglanti());
            add2.Parameters.AddWithValue("@a1", gridLookUpEdit1.EditValue);
            add2.Parameters.AddWithValue("@a2", gridLookUpEdit2.EditValue);
            add2.Parameters.AddWithValue("@a3", "Satış");
            add2.Parameters.AddWithValue("@a4", satismiktar);
            add2.Parameters.AddWithValue("@a5", memoEdit1.Text);
            add2.Parameters.AddWithValue("@a6", dateEdit1.EditValue);
            add2.Parameters.AddWithValue("@a7", "Aktif");
            add2.Parameters.AddWithValue("@a8", Convert.ToDecimal(txt_fiyat.Text));
            add2.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        string uretimID;
        void uretim()
        {
            SqlCommand add2 = new SqlCommand("insert into RootUrunHareket (UrunID, BirimID, Hareket, Miktar,Aciklama,Tarih, Durum) values (@a1,@a2,@a3,@a4,@a5,@a6,@a7) SET @ID=SCOPE_IDENTITY() ", bgl.baglanti());
            add2.Parameters.AddWithValue("@a1", gridLookUpEdit1.EditValue);
            add2.Parameters.AddWithValue("@a2", gridLookUpEdit2.EditValue);
            add2.Parameters.AddWithValue("@a3", "Üretim");
            add2.Parameters.AddWithValue("@a4", txtadet.Text);
            add2.Parameters.AddWithValue("@a5", memoEdit1.Text);
            add2.Parameters.AddWithValue("@a6", dateEdit1.EditValue);
            add2.Parameters.AddWithValue("@a7", "Aktif");
            add2.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
            add2.ExecuteNonQuery();
            uretimID = add2.Parameters["@ID"].Value.ToString();
            bgl.baglanti().Close();


         //   SqlCommand komutID = new SqlCommand("select SUM(ID) from RootRecete where AnalizID = '" + gridLookUpEdit1.EditValue + "' ", bgl.baglanti());
         //   SqlDataReader drI = komutID.ExecuteReader();
         //   while (drI.Read())
         //   {
         //       urunrecete = Convert.ToInt32(drI[0].ToString());
         //   }
         //   bgl.baglanti().Close();

         //   if (urunrecete != 0)
         //   {


         //}
         //   else
         //   {
         //       MessageBox.Show("Bu ürün için reçete olmadığı için sadece ana stok güncellenmiştir", "Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         //   }
        }

        int stok, satismiktar, urunrecete;
        void anastok()
        {
            SqlCommand komutID = new SqlCommand("select SUM(Miktar) from RootUrunHareket where UrunID = '" + gridLookUpEdit1.EditValue + "' and Durum = 'Aktif' ", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                stok = Convert.ToInt32(drI[0].ToString());
            }
            bgl.baglanti().Close();

            SqlCommand add = new SqlCommand("update RootUrunListesi set Miktar = @a1 where ID = N'" + gridLookUpEdit1.EditValue + "'", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", stok);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            //üretim

            if (dateEdit1.EditValue == null)
            {
                MessageBox.Show("Lütfen tarih seçiniz!..");
            }
            else
            {
                if (txtadet.Text == "")
                {
                    MessageBox.Show("Lütfen ürün sayısını belirtiniz!..");
                }
                else
                {
                    uretim();
                    cikarma();
                    anastok();
                    if (Application.OpenForms["AnalizListesi"] == null)
                    {

                    }
                    else
                    {
                        m.listele();
                    }

                    txtadet.Text = null;
                    memoEdit1.Text = null;

                    MessageBox.Show("Stoklarınız başarıyla güncellenmiştir!", "Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

            }
        }


        private void txtadet_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
