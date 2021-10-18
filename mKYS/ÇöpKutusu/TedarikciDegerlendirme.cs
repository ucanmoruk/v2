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

namespace mKYS.Talep
{
    public partial class TedarikciDegerlendirme : Form
    {
        public TedarikciDegerlendirme()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select s.Soru, d.Puan from StokTedarikciDegerlendirme d inner join StokTedarikciSoru s on d.SoruID = s.Soru where d.FirmaID='"+firmaid+"'", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;

            this.gridView1.Columns[1].Width = 30;
        }

        void firmabul()
        {
            SqlCommand komut2 = new SqlCommand("select * from StokTedarikci where Ad = '"+firma+"'" , bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            { 
                firmaid = Convert.ToInt32(dr2["ID"]);
                turid = Convert.ToInt32(dr2["Tur"]);

            }
            bgl.baglanti().Close();

            SqlCommand komut = new SqlCommand("Select * from StokTedarikciTur where ID = '"+turid+"'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txt_kategori.Text = dr["Tur"].ToString();
                txt_puan.Text = dr["Limit"].ToString();
            }
            bgl.baglanti().Close();
        }

        void firmasec()
        {
            SqlCommand komut2 = new SqlCommand("select * from StokTedarikci where Ad = '" + firma + "'", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                combo_firma.Properties.Items.Add(dr2["Ad"]);

            }
            bgl.baglanti().Close();

          
        }

        public static string firma;
        private void TedarikciDegerlendirme_Load(object sender, EventArgs e)
        {           

            if (firma == "" || firma == null)
            {
                firmasec();
                listele();
            }
            else
            {
                combo_firma.Text = firma;
                firmabul();
                listele();
            }

            GridColumnSummaryItem item2 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Puan", "Toplam={0}");
            gridView1.Columns["Puan"].Summary.Add(item2);
        }

        int firmaid, turid;

        private void TedarikciDegerlendirme_FormClosing(object sender, FormClosingEventArgs e)
        {
            firma = "";
        }

        void eskisil()
        {
            SqlCommand komutz = new SqlCommand("delete from StokTedarikciDegerlendirme where FirmaID =N'" + firmaid + "' ", bgl.baglanti());
            komutz.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        int soruid, total;
        void yenikayit()
        {
            DateTime tarih = DateTime.Now;

            for (int ik = 0; ik <= gridView1.RowCount - 2; ik++)
            {
                string soru, puan;
                soru = gridView1.GetRowCellValue(ik, "Soru").ToString();
                puan = gridView1.GetRowCellValue(ik, "Puan").ToString();

                SqlCommand komut2 = new SqlCommand("select * from StokTedarikciSoru where Soru = '" + soru + "' and TurID = '"+turid+"'", bgl.baglanti());
                SqlDataReader dr2 = komut2.ExecuteReader();
                while (dr2.Read())
                {
                    soruid = Convert.ToInt32(dr2["ID"]);

                }
                bgl.baglanti().Close();

                SqlCommand komutz = new SqlCommand("insert into StokTedarikciDegerlendirme (FirmaID, SoruID, Puan) values (@o1,@o2,@o3)", bgl.baglanti());
                komutz.Parameters.AddWithValue("@o1", firmaid);
                komutz.Parameters.AddWithValue("@o2", soruid);
                komutz.Parameters.AddWithValue("@o3", Convert.ToDecimal(puan));
                komutz.ExecuteNonQuery();
                bgl.baglanti().Close();

            }

            SqlCommand komut = new SqlCommand("select Sum(Puan) from StokTedarikciDegerlendirme where FirmaID = '" + firmaid + "'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                total = Convert.ToInt32(dr[0]);

            }
            bgl.baglanti().Close();

            SqlCommand komutaz = new SqlCommand("insert into StokTedarikciPuan (FirmaID, Puan, Tarih) values (@o1,@o2,@o3)", bgl.baglanti());
            komutaz.Parameters.AddWithValue("@o1", firmaid);
            komutaz.Parameters.AddWithValue("@o2", Convert.ToDecimal(total));
            komutaz.Parameters.AddWithValue("@o3", tarih);
            komutaz.ExecuteNonQuery();
            bgl.baglanti().Close();

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (combo_firma.Text == "")
                {
                    MessageBox.Show("Lütfen değerlendirmek istediğiniz firmayı seçiniz!");
                }
                else
                {
                    DialogResult Secim = new DialogResult();

                    Secim = MessageBox.Show(combo_firma.Text + " firmasını değerlendirmek istiyor musunuz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (Secim == DialogResult.Yes)
                    {
                        eskisil();
                        yenikayit();
                        if (total > Convert.ToInt32(txt_puan.Text))
                        {
                            MessageBox.Show("Toplam puan limit puan değerinden daha fazla olduğu için tedarikçi değerlendirme işlemi başarılı olarak sonuçlanmıştır!", "Ooppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        }
                        else
                        {
                            MessageBox.Show("Toplam puan limit puan değerinden daha düşük olduğu için tedarikçi değerlendirme işlemi olumsuz olarak sonuçlanmıştır!", "Ooppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        }
                        listele();
                    }
                    else
                    {
                        MessageBox.Show("İyi günler dilerim.", "Ooppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    }

                }  
           
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata 138 : " + ex.Message);
            }
        }

        private void combo_firma_SelectedIndexChanged(object sender, EventArgs e)
        {
            firma = combo_firma.Text;
            firmabul();
            listele();
        }
    }
}
