using DevExpress.XtraGrid;
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

namespace mKYS
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
           // SqlDataAdapter da12 = new SqlDataAdapter("select ID, Tur, Kod, Ad from StokListesi where Durum = 'Aktif' order by Kod ", bgl.baglanti());
            SqlDataAdapter da12 = new SqlDataAdapter(@"select ID, Tur, Kod, Ad from StokListesi where Durum = 'Aktif'  
            except select l.ID, l.Tur, l.Kod, l.Ad from StokRecete r 
            inner join StokListesi l on r.StokID = l.ID 
            where AnalizID = '"+aID+"' order by Kod ", bgl.baglanti());
            da12.Fill(dt12);
            gridControl1.DataSource = dt12;
            gridView1.Columns["ID"].Visible = false;
        }

        string akod, aad;
        void detaybul()
        {
            SqlCommand komutID = new SqlCommand("Select * From StokAnalizListesi where ID = N'" + aID + "'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                akod = drI["Kod"].ToString();
                aad = drI["Ad"].ToString();
            }
            bgl.baglanti().Close();
        }
   
        void ekleme()
        {
            DataTable dt12 = new DataTable();
            SqlDataAdapter da12 = new SqlDataAdapter("select l.ID, l.Tur, l.Kod, l.Ad, r.Miktar as 'Kullanılan Miktar', l.Birim from StokListesi l " +
                "left join StokRecete r on l.ID = r.StokID  " +
                " where r.AnalizID = '"+aID+"'", bgl.baglanti());
            da12.Fill(dt12);
            gridControl2.DataSource = dt12;
            gridView2.Columns["ID"].Visible = false;
            this.gridView2.Columns[1].Width = 40;
            this.gridView2.Columns[2].Width = 40;
        }


        public static string  gelis, aID;
        private void YeniFormul_Load(object sender, EventArgs e)
        {
            listele();
            detaybul();
            Text = akod + " " + aad + " Reçete Oluşturma";

            this.gridView1.Columns[1].Width = 40;
            this.gridView1.Columns[2].Width = 40;
            

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
                string id, sID;

                for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                {
                    id = gridView1.GetSelectedRows()[i].ToString();
                    int y = Convert.ToInt32(id);
                    sID = gridView1.GetRowCellValue(y, "ID").ToString();

                    SqlCommand add = new SqlCommand("insert into StokRecete (StokID, AnalizID) values (@a1,@a2) ", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", sID);
                    add.Parameters.AddWithValue("@a2", aID);
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();       

                }

                ekleme();
                listele();

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
                kod = gridView2.GetRowCellValue(y, "ID").ToString();
                SqlCommand add = new SqlCommand("delete from StokRecete where StokID = '"+kod+"' and AnalizID = '"+aID+"'", bgl.baglanti());
                add.ExecuteNonQuery();
                bgl.baglanti().Close();
            }

            ekleme();
            listele();
          
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

            gelis = null;
            aID = null;

        }

        void eskisil()
        {
            SqlCommand komutz = new SqlCommand("delete from StokRecete where AnalizID =N'" + aID + "' ", bgl.baglanti());
            komutz.ExecuteNonQuery();
            bgl.baglanti().Close();
        }
        
        void yenikayit()
        {
      
            for (int ik = 0; ik < gridView2.RowCount; ik++)
            {
                string kod = gridView2.GetRowCellValue(ik, "ID").ToString();

                SqlCommand add = new SqlCommand("insert into StokRecete (StokID, AnalizID, Miktar) values (@a1,@a2, @a3) ", bgl.baglanti());
                add.Parameters.AddWithValue("@a1", kod);
                add.Parameters.AddWithValue("@a2", aID);
                add.Parameters.AddWithValue("@a3", gridView2.GetRowCellValue(ik, "Kullanılan Miktar"));
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
