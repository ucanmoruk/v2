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

namespace StokTakip
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
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select Marka, Lot, SKT as 'Son Kullanım', Tarih as 'İşlem Tarihi', Miktar from StokHareket where StokID in (select ID from StokListesi where Kod = N'" + urunkod + "') ", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;


        }

        int urunid;
        string marka;
        public static string lot;
        private void detaybul()
        {
            try
            {
                txtkod.Text = urunkod;
                SqlCommand komutID = new SqlCommand("Select * From StokListesi where Kod= N'" + urunkod + "'", bgl.baglanti());
                SqlDataReader drI = komutID.ExecuteReader();
                while (drI.Read())
                {
                    urunid = Convert.ToInt32(drI["ID"]);
                    combo_tur.Text = drI["Tur"].ToString(); 
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

                SqlCommand komutD = new SqlCommand("select * from StokSertifika where StokID in (select ID from StokListesi where Kod = N'" + urunkod + "')", bgl.baglanti());
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
                MessageBox.Show("Hata 2: " + ex);
            }
        }

        private void detaybul2()
        {
            try
            {                
                SqlCommand komutID = new SqlCommand("Select * From StokListesi where Kod= N'" + txtkod.Text + "'", bgl.baglanti());
                SqlDataReader drI = komutID.ExecuteReader();
                while (drI.Read())
                {
                    combo_tur.Text = drI["Tur"].ToString();
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

                SqlCommand komutD = new SqlCommand("select * from StokHareket where StokID in (select ID from StokListesi where Kod = N'" + txtkod.Text + "')", bgl.baglanti());
                SqlDataReader dr = komutD.ExecuteReader();
                while (dr.Read())
                {
                    marka = dr["Marka"].ToString();
                    lot = dr["Lot"].ToString();
                    combo_marka.Properties.Items.Add(marka + " / " + lot);
                }
                bgl.baglanti().Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata 2: " + ex);
            }
        }


        public static string urunkod;

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand add = new SqlCommand("update StokListesi set Tur=@a1,Kod=@a2,Ad=@a3,AdEn=@a4,Cas=@a5,Ambalaj=@a6,Ozellik=@a7,Saklama=@a8,Limit=@a9,Birim=@a10 where ID = '"+urunid+"' ", bgl.baglanti());
                add.Parameters.AddWithValue("@a1", combo_tur.Text);
                add.Parameters.AddWithValue("@a2", txtkod.Text);
                add.Parameters.AddWithValue("@a3", txtad.Text);
                add.Parameters.AddWithValue("@a4", txtenad.Text);
                add.Parameters.AddWithValue("@a5", txtcas.Text);
                add.Parameters.AddWithValue("@a6", txtambalaj.Text);
                add.Parameters.AddWithValue("@a7", txtozellik.Text);
                add.Parameters.AddWithValue("@a8", txtsaklama.Text);
                add.Parameters.AddWithValue("@a9", txtlimit.Text);
                add.Parameters.AddWithValue("@a10", combobirim.Text);
                add.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Güncelleme Başarılı!", "Tebrikler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                combo_marka.Properties.Items.Clear();

                detaybul2();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata 3: "+ ex);
            }
        }

        private void btngoster_Click(object sender, EventArgs e)
        {
            //SertifikaGoruntule path = lot;
            SertifikaGoruntule.yol = lot;
            SertifikaGoruntule sg = new SertifikaGoruntule();
            sg.ShowDialog();
        }

        private void combo_marka_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komutD = new SqlCommand("select * from StokSertifika where Sertifika =N'"+combo_marka.Text+"' and StokID in (select ID from StokListesi where Kod = N'" + urunkod + "')", bgl.baglanti());
            SqlDataReader dr = komutD.ExecuteReader();
            while (dr.Read())
            {     
                lot = dr["Path"].ToString();

            }
            bgl.baglanti().Close();
        }

        private void StokDetay_Load(object sender, EventArgs e)
        {
            detaybul();
            listele();

            GridColumnSummaryItem item2 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Miktar", "Toplam={0}");
            gridView1.Columns["Miktar"].Summary.Add(item2);

        }

    }
}
