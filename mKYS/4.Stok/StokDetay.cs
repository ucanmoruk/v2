using DevExpress.XtraGrid;
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
    public partial class StokDetay : Form
    {
        public StokDetay()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        private void listele()
        {
         //   DataTable dt2 = new DataTable();
         ////   SqlDataAdapter da2 = new SqlDataAdapter("select Marka, Lot, SKT as 'Son Kullanım', Tarih as 'İşlem Tarihi', Miktar from StokHareket where StokID in (select ID from StokListesi where Kod = N'" + urunkod + "') and BirimID = N'"+Anasayfa.birimID+ "' and Durum = N'Aktif'", bgl.baglanti());
         //   SqlDataAdapter da2 = new SqlDataAdapter("select ID, Marka, Lot, SKT as 'Son Kullanım', Tarih as 'İşlem Tarihi', CONVERT(nvarchar,REPLACE(Miktar,',',''))+' '+Birim as 'Miktar' from RootStokHareket where StokID  = N'" + urunkod + "' and BirimID = N'" + Anasayfa.birimID + "' and Durum = N'Aktif' order by Tarih desc", bgl.baglanti());
         //   da2.Fill(dt2);
         //   gridControl1.DataSource = dt2;
         //   gridView1.Columns["ID"].Visible = false;
        }

        private void listele2()
        {

        }

        int urunid;
        string marka;
        public static string lot;
        private void detaybul()
        {
            try
            {
                SqlCommand komutID = new SqlCommand("Select * From RootStokListesi where ID= N'" + urunkod + "'", bgl.baglanti());
                SqlDataReader drI = komutID.ExecuteReader();
                while (drI.Read())
                {
                    urunid = Convert.ToInt32(drI["ID"]);
                    txt_tur.Text = drI["Tur"].ToString(); 
                    combobirim.Text = drI["Birim"].ToString();
                    txtad.Text = drI["Ad"].ToString();
                    txtenad.Text = drI["AdEn"].ToString();
                    txtcas.Text = drI["Cas"].ToString();
                    txtambalaj.Text = drI["Ambalaj"].ToString();
                    txtlimit.Text = drI["Limit"].ToString();
                    txtsaklama.Text = drI["Saklama"].ToString();
                    txtozellik.Text = drI["Ozellik"].ToString();
                    txtkod.Text = drI["Kod"].ToString();
                    txtinci.Text = drI["AdInci"].ToString();

                }
                bgl.baglanti().Close();
               

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata 2: " + ex);
            }
        }

        private void detaybul2()
        {
            try
            {                
                SqlCommand komutID = new SqlCommand("Select * From RootStokListesi where ID= N'" + urunkod + "'", bgl.baglanti());
                SqlDataReader drI = komutID.ExecuteReader();
                while (drI.Read())
                {
                    txt_tur.Text = drI["Tur"].ToString();
                    combobirim.Text = drI["Birim"].ToString();
                    txtad.Text = drI["Ad"].ToString();
                    txtenad.Text = drI["AdEn"].ToString();
                    txtcas.Text = drI["Cas"].ToString();
                    txtambalaj.Text = drI["Ambalaj"].ToString();
                    txtlimit.Text = drI["Limit"].ToString();
                    txtsaklama.Text = drI["Saklama"].ToString();
                    txtozellik.Text = drI["Ozellik"].ToString();

                }
                bgl.baglanti().Close();

                SqlCommand komutD = new SqlCommand("select * from RootStokHareket where StokID = N'" + urunkod +  "' and BirimID = N'" + Anasayfa.birimID + "' ", bgl.baglanti());
                SqlDataReader dr = komutD.ExecuteReader();
                while (dr.Read())
                {
                    marka = dr["Sertifika"].ToString();
                    //  lot = dr["Path"].ToString();
                    // string s = dr["SKT"].ToString();
                    combo_marka.Properties.Items.Add(marka);
                }
                bgl.baglanti().Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata 3: " + ex);
            }
        }

        void sertbul()
        {
            //SqlCommand komutD = new SqlCommand("select * from RootStokSertifika where StokID = N'" + urunkod + "' and BirimID = N'" + Anasayfa.birimID + "' and Durum = N'Aktif' ", bgl.baglanti());
            //SqlDataReader dr = komutD.ExecuteReader();
            //while (dr.Read())
            //{
            //    marka = dr["Sertifika"].ToString();
            //    //  lot = dr["Path"].ToString();
            //    // string s = dr["SKT"].ToString();
            //    combo_marka.Properties.Items.Add(marka);
            //}
            //bgl.baglanti().Close();
        }

        void sertbul2()
        {
            //SqlCommand komutD = new SqlCommand("select * from RootStokSertifika where StokID  = N'" + urunkod + "' and Durum = N'Aktif' ", bgl.baglanti());
            //SqlDataReader dr = komutD.ExecuteReader();
            //while (dr.Read())
            //{
            //    marka = dr["Sertifika"].ToString();
            //    //  lot = dr["Path"].ToString();
            //    // string s = dr["SKT"].ToString();
            //    combo_marka.Properties.Items.Add(marka);
            //}
            //bgl.baglanti().Close();
        }

        public static string urunkod;
        StokListesi m = (StokListesi)System.Windows.Forms.Application.OpenForms["StokListesi"];
        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand add = new SqlCommand("update RootStokListesi set Tur=@a1,Kod=@a2,Ad=@a3,AdEn=@a4,Cas=@a5,Ambalaj=@a6,Ozellik=@a7,Saklama=@a8,Limit=@a9,Birim=@a10, AdInci=@a11 where ID = '" + urunid+"' ", bgl.baglanti());
                add.Parameters.AddWithValue("@a1", txt_tur.Text);
                add.Parameters.AddWithValue("@a2", txtkod.Text);
                add.Parameters.AddWithValue("@a3", txtad.Text);
                add.Parameters.AddWithValue("@a4", txtenad.Text);
                add.Parameters.AddWithValue("@a5", txtcas.Text);
                add.Parameters.AddWithValue("@a6", txtambalaj.Text);
                add.Parameters.AddWithValue("@a7", txtozellik.Text);
                add.Parameters.AddWithValue("@a8", txtsaklama.Text);
                add.Parameters.AddWithValue("@a9", Convert.ToDecimal(txtlimit.Text));
                add.Parameters.AddWithValue("@a10", combobirim.Text);
                add.Parameters.AddWithValue("@a11", txtinci.Text);
                add.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Güncelleme Başarılı!", "Tebrikler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                combo_marka.Properties.Items.Clear();

              //  detaybul2();

                if (Application.OpenForms["StokListesi"] == null)
                {

                }
                else
                {
                    m.listele();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata S4: "+ ex);
            }
        }

        private void btngoster_Click(object sender, EventArgs e)
        {

            if (combo_marka.Text == "")
            {
                MessageBox.Show("Lütfen sertifika seçiniz!","Oooppss!");
            }
            else
            {
                //SertifikaGoruntule path = lot;
                SertifikaGoruntule.yol = lot;
                SertifikaGoruntule sg = new SertifikaGoruntule();
                sg.Show();
            }
            
        }

        private void combo_marka_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komutD = new SqlCommand("select * from RootStokSertifika where Sertifika =N'" + combo_marka.Text+"' and StokID = N'" + urunkod + "'", bgl.baglanti());
            SqlDataReader dr = komutD.ExecuteReader();
            while (dr.Read())
            {     
                lot = dr["Path"].ToString();

            }
            bgl.baglanti().Close();
        }

        int yetki;
        void yetkibul()
        {
            SqlCommand komut21 = new SqlCommand("Select * from KaliteYetki where Gorev = N'" + Anasayfa.gorev + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                yetki = Convert.ToInt32(dr21["Stok"]);
            }
            bgl.baglanti().Close();

            if (yetki == 0 || yetki.ToString() == null)
                btnadd.Visible = false;
            else
                btnadd.Visible = true;
        }

        private void StokDetay_Load(object sender, EventArgs e)
        {
            detaybul();
            //  yetkibul();
         //   listele2();
     

        }

        string id, kod;
        int stokharID;
        string ensoncalisan;


     
        string stokk;
        float stok, f2;
  

     //   StokListesi m = (StokListesi)System.Windows.Forms.Application.OpenForms["StokListesi"];
        int stokhareketID;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
              

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata SD1 : " + ex.Message);
            }



        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }
        }

        private void StokDetay_FormClosing(object sender, FormClosingEventArgs e)
        {
            urunkod = "";
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Raporlar.KimyasalEtiket.sGelis = "Özel";
            //Raporlar.KimyasalEtiket.sID = hID;

            //using (Raporlar.frmPrint frm = new Raporlar.frmPrint())
            //{
            //    frm.KimyasalEtiket();
            //    frm.ShowDialog();
            //}
        }

        string dmiktar, dmarka, dlot, hID;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }
    }
}
