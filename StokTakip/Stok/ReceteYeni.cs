using DevExpress.XtraGrid;
using StokTakip;
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
    public partial class YeniRecete : Form
    {
        public YeniRecete()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();

     //   UrunEkle em = (UrunEkle)System.Windows.Forms.Application.OpenForms["UrunEkle"];

        void listele()
        {
            DataTable dt12 = new DataTable();
            SqlDataAdapter da12 = new SqlDataAdapter("select Tur, Kod, Ad from StokListesi where Durum = 'Aktif' order by Kod ", bgl.baglanti());
            da12.Fill(dt12);
            gridControl1.DataSource = dt12;
        }

   
        void ekleme()
        {
            DataTable dt12 = new DataTable();
            SqlDataAdapter da12 = new SqlDataAdapter("select Tur, Kod, Ad from StokListesi where Kod in (Select StokKod from StokRecete where AnalizKod = '"+lbl_ID.Text+"' ) ", bgl.baglanti());
            da12.Fill(dt12);
            gridControl2.DataSource = dt12;
            this.gridView2.Columns[0].Width = 30;
            this.gridView2.Columns[1].Width = 30;
        }


        public static string Ad, gelis, UrunID;
        private void YeniFormul_Load(object sender, EventArgs e)
        {
            lbl_recete.Text = Ad;
            lbl_ID.Text = UrunID;

            listele();

            this.gridView1.Columns[0].Width = 30;
            this.gridView1.Columns[1].Width = 30;
            

            if (gelis == "update")
            {
                ekleme();
                simpleButton3.Text = "Güncelle";              
            }
                            


            //GridColumnSummaryItem item2 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Miktar (mg)", "Toplam={0}");
            //GridColumnSummaryItem item1 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Kod", "Adet={0}");
            //gridView2.Columns["Miktar (mg)"].Summary.Add(item2);
            //gridView2.Columns["Kod"].Summary.Add(item1);

           
        }

        //ekleme işlemi için çalışacak
        int altid, sayim;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string id, kod;

                for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                {
                    id = gridView1.GetSelectedRows()[i].ToString();
                    int y = Convert.ToInt32(id);
                    kod = gridView1.GetRowCellValue(y, "Kod").ToString();

                    SqlCommand add = new SqlCommand("insert into StokRecete (StokKod, AnalizKod) values (@a1,@a2) ", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", kod);
                    add.Parameters.AddWithValue("@a2", lbl_ID.Text);
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();       

                }

                ekleme();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Ooppss!! Error 1011: " + ex);
            }


            
        }

        //çıkarma işlemi için çalışacak
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string id, kod;

            for (int i = 0; i < gridView2.SelectedRowsCount; i++)
            {
                id = gridView2.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                kod = gridView2.GetRowCellValue(y, "Kod").ToString();
                SqlCommand add = new SqlCommand("delete from StokRecete where StokKod = @a1 and AnalizKod= @a2 ", bgl.baglanti());
                add.Parameters.AddWithValue("@a1", kod);
                add.Parameters.AddWithValue("@a2", lbl_ID.Text);
                add.ExecuteNonQuery();
                bgl.baglanti().Close();
            }

            ekleme();
          
        }

        private void YeniRecete_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kapama == "1")
            {

            }
            else
            {
                DialogResult sonuc = MessageBox.Show("Reçetenizi kaydetmeden çıkmak istediğinizden emin misiniz ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (sonuc == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    if (simpleButton3.Text == "Güncelle")
                    {

                    }
                    else
                    {
                        eskisil();
                    }
                   
                    //this.Close();
                }
            }
        }

        void eskisil()
        {
            SqlCommand komutz = new SqlCommand("delete from StokRecete where AnalizKod =N'" + lbl_ID.Text + "' ", bgl.baglanti());
            komutz.ExecuteNonQuery();
            bgl.baglanti().Close();
        }
        
        void yenikayit()
        {
      
            for (int ik = 0; ik < gridView2.RowCount; ik++)
            {
                string kod = gridView2.GetRowCellValue(ik, "Kod").ToString();

                SqlCommand add = new SqlCommand("insert into StokRecete (StokKod, AnalizKod) values (@a1,@a2) ", bgl.baglanti());
                add.Parameters.AddWithValue("@a1", kod);
                add.Parameters.AddWithValue("@a2", lbl_ID.Text);
                add.ExecuteNonQuery();
                bgl.baglanti().Close();
 
            }

            
        }

        string kapama;
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {

            if (gelis == "update")
            {
                eskisil();
                yenikayit();
                MessageBox.Show("Güncelleme işlemi başarılı..", "Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                eskisil();
                yenikayit();
                MessageBox.Show("Reçete başarıyla oluşturuldu..", "Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

                kapama = "1";
                this.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata 1859:" + ex);
            }


        }


    }
}
