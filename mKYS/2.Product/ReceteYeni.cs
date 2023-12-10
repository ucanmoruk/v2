using DevExpress.XtraEditors.Repository;
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
            SqlDataAdapter da12 = new SqlDataAdapter(@"select ID, Tur, Kod, Ad from RootStokListesi where Durum = 'Aktif'  
            except select l.ID, l.Tur, l.Kod, l.Ad from RootRecete r 
            inner join RootStokListesi l on r.StokID = l.ID 
            where r.AnalizID = '"+aID+"' order by Kod ", bgl.baglanti());
            da12.Fill(dt12);
            gridControl1.DataSource = dt12;
            gridView1.Columns["ID"].Visible = false;
        }

        string akod, aad;
        void detaybul()
        {
            SqlCommand komutID = new SqlCommand("Select * From RootUrunListesi where ID = N'" + aID + "'", bgl.baglanti());
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
            SqlDataAdapter da12 = new SqlDataAdapter(@"select l.ID, l.Tur, l.Kod, l.Ad, r.Alt, r.Ust, r.Tam, r.Birim from RootStokListesi l 
            left join RootRecete r on l.ID = r.StokID  where r.AnalizID = '" + aID+ "' and r.Durum =N'Aktif'  order by r.Alt desc, r.Tam desc", bgl.baglanti());
            da12.Fill(dt12);
            gridControl2.DataSource = dt12;
            gridView2.Columns["ID"].Visible = false;
            this.gridView2.Columns[1].Width = 40;
            this.gridView2.Columns[2].Width = 40;
            this.gridView2.Columns[3].Width = 90;
            this.gridView2.Columns[4].Width = 40;
            this.gridView2.Columns[5].Width = 40;
            this.gridView2.Columns[6].Width = 40;
            this.gridView2.Columns[7].Width = 40;

            RepositoryItemComboBox riComboBox = new RepositoryItemComboBox();
            riComboBox.Items.Add("%");
            riComboBox.Items.Add("Adet");
            gridControl2.RepositoryItems.Add(riComboBox);
            gridView2.Columns["Birim"].ColumnEdit = riComboBox;
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

                    SqlCommand add = new SqlCommand("insert into RootRecete (StokID, AnalizID, Durum) values (@a1,@a2,@a3) ", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", sID);
                    add.Parameters.AddWithValue("@a2", aID);
                    add.Parameters.AddWithValue("@a3", "Aktif");
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
                SqlCommand add = new SqlCommand("delete from RootRecete where StokID = '"+kod+"' and AnalizID = '"+aID+"'", bgl.baglanti());
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
            SqlCommand komutz = new SqlCommand("update RootRecete set Durum ='Pasif' where AnalizID =N'" + aID + "' ", bgl.baglanti());
            komutz.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        private void gridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "Birim")
            {
                //if (e.Value == null)
                e.DisplayText = "%";
            }
        }

        void yenikayit()
        {
      
            for (int ik = 0; ik < gridView2.RowCount; ik++)
            {
                string kod = gridView2.GetRowCellValue(ik, "ID").ToString();

                SqlCommand add = new SqlCommand("insert into RootRecete (StokID, AnalizID, Alt, Ust, Tam, Birim, Durum) values (@a1,@a2, @a3, @a4, @a5, @a6, @a7) ", bgl.baglanti());
                add.Parameters.AddWithValue("@a1", kod);
                add.Parameters.AddWithValue("@a2", aID);
                if (String.IsNullOrEmpty(gridView2.GetRowCellValue(ik, "Alt").ToString()))
                    add.Parameters.AddWithValue("@a3", "0");
                else
                    add.Parameters.AddWithValue("@a3", Convert.ToDecimal(gridView2.GetRowCellValue(ik, "Alt").ToString()));
                if (String.IsNullOrEmpty(gridView2.GetRowCellValue(ik, "Ust").ToString()))
                    add.Parameters.AddWithValue("@a4", "0");
                else
                    add.Parameters.AddWithValue("@a4", Convert.ToDecimal(gridView2.GetRowCellValue(ik, "Ust").ToString()));
                if (String.IsNullOrEmpty(gridView2.GetRowCellValue(ik, "Tam").ToString()))
                    add.Parameters.AddWithValue("@a5", "0");
                else
                    add.Parameters.AddWithValue("@a5", Convert.ToDecimal(gridView2.GetRowCellValue(ik, "Tam").ToString()));
                if (String.IsNullOrEmpty(gridView2.GetRowCellValue(ik, "Birim").ToString()))
                    add.Parameters.AddWithValue("@a6", "%");
                else
                    add.Parameters.AddWithValue("@a6", gridView2.GetRowCellValue(ik, "Birim").ToString());
                add.Parameters.AddWithValue("@a7", "Aktif");
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
