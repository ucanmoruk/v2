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
    public partial class StokHareket : Form
    {
        public StokHareket()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();
        

        private void listele2()
        {
            DataTable dt2 = new DataTable();
            //-- CONVERT(nvarchar,REPLACE(h.Miktar,',',''))+' '+h.Birim as 'Miktar' 
            SqlDataAdapter da2 = new SqlDataAdapter(@"select h.ID, f.Birim as 'Yer', CONCAT(h.Marka,' | ',h.Lot) as 'Açıklama', h.SKT as 'Son Kullanım', h.Tarih as 'İşlem Tarihi',
h.Miktar, h.Birim 
from RootStokHareket h
inner join RootFirmaBirim f on h.BirimID = f.ID
where h.StokID  = N'" + urunkod + "' and h.Durum = N'Aktif' order by h.Tarih desc", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;
            gridView1.Columns["ID"].Visible = false;

           // this.gridView1.Columns[6].Width = 100;
           // this.gridView1.Columns[7].Width = 35;
        }

        int urunid;
        string marka;
        public static string lot;


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
                //SqlCommand add = new SqlCommand("update RootStokListesi set Tur=@a1,Kod=@a2,Ad=@a3,AdEn=@a4,Cas=@a5,Ambalaj=@a6,Ozellik=@a7,Saklama=@a8,Limit=@a9,Birim=@a10, AdInci=@a11 where ID = '" + urunid+"' ", bgl.baglanti());
                //add.Parameters.AddWithValue("@a1", txt_tur.Text);
                //add.Parameters.AddWithValue("@a2", txtkod.Text);
                //add.Parameters.AddWithValue("@a3", txtad.Text);
                //add.Parameters.AddWithValue("@a4", txtenad.Text);
                //add.Parameters.AddWithValue("@a5", txtcas.Text);
                //add.Parameters.AddWithValue("@a6", txtambalaj.Text);
                //add.Parameters.AddWithValue("@a7", txtozellik.Text);
                //add.Parameters.AddWithValue("@a8", txtsaklama.Text);
                //add.Parameters.AddWithValue("@a9", Convert.ToDecimal(txtlimit.Text));
                //add.Parameters.AddWithValue("@a10", combobirim.Text);
                //add.Parameters.AddWithValue("@a11", txtinci.Text);
                //add.ExecuteNonQuery();
                //bgl.baglanti().Close();

                //MessageBox.Show("Güncelleme Başarılı!", "Tebrikler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                //combo_marka.Properties.Items.Clear();

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

            //if (combo_marka.Text == "")
            //{
            //    MessageBox.Show("Lütfen sertifika seçiniz!","Oooppss!");
            //}
            //else
            //{
            //    //SertifikaGoruntule path = lot;
            //    SertifikaGoruntule.yol = lot;
            //    SertifikaGoruntule sg = new SertifikaGoruntule();
            //    sg.Show();
            //}
            
        }

        private void combo_marka_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SqlCommand komutD = new SqlCommand("select * from RootStokSertifika where Sertifika =N'" + combo_marka.Text+"' and StokID = N'" + urunkod + "'", bgl.baglanti());
            //SqlDataReader dr = komutD.ExecuteReader();
            //while (dr.Read())
            //{     
            //    lot = dr["Path"].ToString();

            //}
            //bgl.baglanti().Close();
        }



        private void StokDetay_Load(object sender, EventArgs e)
        {

            listele2();
            
            GridColumnSummaryItem item2 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Miktar", "{0}");
            gridView1.Columns["Miktar"].Summary.Add(item2);

        }

        string id, kod;
        int stokharID;
        string ensoncalisan;


        string toplammiktar;
        private void checksil()
        {
            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {

                id = gridView1.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                int haID = Convert.ToInt32(gridView1.GetRowCellValue(y, "ID").ToString());
                SqlCommand add = new SqlCommand("update RootStokHareket set Durum=@o1 where ID= N'" + haID + "' ", bgl.baglanti());
                add.Parameters.AddWithValue("@o1", "Pasif");
                add.ExecuteNonQuery();
                bgl.baglanti().Close();
               // toplammiktar += Convert.ToInt32(gridView1.GetRowCellValue(y, "Miktar").ToString());
            }


            SqlCommand komutID = new SqlCommand("select SUM(Miktar) from RootStokHareket where StokID  = N'" + urunkod + "' and Durum = N'Aktif'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                stokk = drI[0].ToString();
            }
            bgl.baglanti().Close();
            stok = float.Parse(stokk);

            //float f1 = float.Parse(toplammiktar);
            //f2 = stok - f1;
            SqlCommand add2 = new SqlCommand("update RootStokListesi set Miktar = @a1 where ID = N'" + urunkod + "'", bgl.baglanti());
           // add2.Parameters.AddWithValue("@a1", f2);
            add2.Parameters.AddWithValue("@a1", stok);
            add2.ExecuteNonQuery();
            bgl.baglanti().Close();


        }

        string stokk;
        float stok, f2;
  

     //   StokListesi m = (StokListesi)System.Windows.Forms.Application.OpenForms["StokListesi"];
        int stokhareketID;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (gridView1.SelectedRowsCount == 0)
                {
                    MessageBox.Show("Lütfen iptal etmek istediğiniz işlemi seçiniz!", "Oopppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    DialogResult Secim = new DialogResult();

                    Secim = MessageBox.Show("Bu işlemi iptal etmek istediğinizden emin misiniz ? Bu işlem toplam stok miktarını da etkileyecektir. ", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (Secim == DialogResult.Yes)
                    {
                      
                        checksil();
                        
                        MessageBox.Show("Güncelleme işlemi başarılı!", "Oppss!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        listele2();

                        if (Application.OpenForms["StokListesi"] == null)
                        {

                        }
                        else
                        {
                            m.listele();
                        }
                    }

                }



                
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
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            hID = dr["ID"].ToString();
            dmiktar = dr["Miktar"].ToString();
          //  dmarka = dr["Açıklama"].ToString();
            //dlot = dr["Lot"].ToString();
        }
    }
}
