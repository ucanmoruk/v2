using DevExpress.XtraEditors.Repository;
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

namespace mKYS.Analiz
{
    public partial class UrunFormul : Form
    {
        public UrunFormul()
        {
            InitializeComponent();
        }


        sqlbaglanti bgl = new sqlbaglanti();

        public static string gelis, uID, kapama;

        void listele()
        {
            DataTable dt12 = new DataTable();
            SqlDataAdapter da12 = new SqlDataAdapter(@"select ID, Tur, Kod, Ad, Cas from RootStokListesi where Durum = 'Aktif'  
            except select l.ID, l.Tur, l.Kod, l.Ad, l.Cas from RootRecete r 
            inner join RootStokListesi l on r.StokID = l.ID 
            where r.AnalizID = '" + aID + "' order by Kod ", bgl.baglanti());
            da12.Fill(dt12);
            gridControl1.DataSource = dt12;
            gridView1.Columns["ID"].Visible = false;

            gridView1.Columns[1].Width = 60;
            gridView1.Columns[2].Width = 60;
            gridView1.Columns[3].Width = 120;
            gridView1.Columns[4].Width = 60;
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

        void listele2()
        {
            DataTable dt12 = new DataTable();
            SqlDataAdapter da12 = new SqlDataAdapter(@"select r.ID, l.Tur, l.Kod, l.Ad, r.Alt, r.Ust, r.Tam, r.Birim from RootStokListesi l 
            left join RootRecete r on l.ID = r.StokID  where r.AnalizID = '" + aID + "' and r.Durum =N'Aktif'  order by r.Alt desc, r.Tam desc", bgl.baglanti());
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

        void listeksik()
        {
            DataTable dt6 = new DataTable();
            SqlDataAdapter da6 = new SqlDataAdapter(@"select ID, Name as 'Etken Madde', CasNo from mrEtken where Durum = N'Aktif'  
            except select ID, Name as 'Etken Madde', CasNo from mrEtken
            where ID in (select EtkenID from mrRecete where UrunID = '" + uID + "') order by 'Etken Madde'", bgl.baglanti());
            da6.Fill(dt6);
            gridControl1.DataSource = dt6;
            gridView1.Columns["ID"].Visible = false;

            gridView1.Columns[1].Width = 90;
            gridView1.Columns[2].Width = 60;
        }

        public static string aID;
        private void UrunFormul_Load(object sender, EventArgs e)
        {
            kapama = "1";
            detaybul();
            Text = akod + " " + aad + " Reçetesi";

            listele();

            if (gelis == "Güncelle")
            {

                btn_save.Text = "Güncelle";
                listele2();
              //  listeksik();
            }
            else
            {
              //  listele();
            }
        }

        string id, o2;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ekle

            kapama = "0";
            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                id = gridView1.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                o2 = gridView1.GetRowCellValue(y, "ID").ToString();

                SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                  "insert into RootRecete (AnalizID, StokID, Durum) " +
                  "values (@o1,@o2, @o3);" +
                  "COMMIT TRANSACTION", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", aID);
                add2.Parameters.AddWithValue("@o2", o2);
                add2.Parameters.AddWithValue("@o3", "Aktif");
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();
            }
            listele2();
            listele();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //sil
            kapama = "0";
            if (gridView2.SelectedRowsCount > 0)
            {
                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show("Seçili etken maddeleri kaldırmak istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Secim == DialogResult.Yes)
                {

                    for (int i = 0; i < gridView2.SelectedRowsCount; i++)
                    {
                        id = gridView2.GetSelectedRows()[i].ToString();
                        int y = Convert.ToInt32(id);
                        o2 = gridView2.GetRowCellValue(y, "ID").ToString();
                        SqlCommand add = new SqlCommand("delete from RootRecete where AnalizID = @p1 and StokID = @p2 ", bgl.baglanti());
                        add.Parameters.AddWithValue("@p1", aID);
                        add.Parameters.AddWithValue("@p2", o2);
                        add.ExecuteNonQuery();
                        bgl.baglanti().Close();

                    }

                    listele2();
                    listele();
                }
            }
            else
            {
                MessageBox.Show("Lütfen seçim yapınız..");
            }
        }

        void guncelle()
        {
            try
            {

                for (int ik = 0; ik < gridView2.RowCount; ik++)
                {
                    //id = gridView1.GetSelectedRows()[ik].ToString();
                    //int y = Convert.ToInt32(id);
                    o2 = gridView2.GetRowCellValue(ik, "ID").ToString();
                    SqlCommand komutz = new SqlCommand("update RootRecete set Alt = @o1, Ust=@o2, Tam=@o3, Birim=@o4 where ID = '" + o2 + "' and AnalizID = '" + aID + "'  ", bgl.baglanti());
                    if (String.IsNullOrEmpty(gridView2.GetRowCellValue(ik, "Alt").ToString()))
                        komutz.Parameters.AddWithValue("@o1", "0");   
                    else
                        komutz.Parameters.AddWithValue("@o1", Convert.ToDecimal(gridView2.GetRowCellValue(ik, "Alt").ToString()));
                    if (String.IsNullOrEmpty(gridView2.GetRowCellValue(ik, "Ust").ToString()))
                        komutz.Parameters.AddWithValue("@o2", "0");
                    else
                        komutz.Parameters.AddWithValue("@o2", Convert.ToDecimal(gridView2.GetRowCellValue(ik, "Ust").ToString()));
                    if (String.IsNullOrEmpty(gridView2.GetRowCellValue(ik, "Tam").ToString()))
                        komutz.Parameters.AddWithValue("@o3", "0");
                    else
                        komutz.Parameters.AddWithValue("@o3", Convert.ToDecimal(gridView2.GetRowCellValue(ik, "Tam").ToString()));
                    if (String.IsNullOrEmpty(gridView2.GetRowCellValue(ik, "Birim").ToString()))
                        komutz.Parameters.AddWithValue("@o4", "%");
                    else
                        komutz.Parameters.AddWithValue("@o4", gridView2.GetRowCellValue(ik, "Birim").ToString());
                    komutz.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }


                MessageBox.Show("Güncelleme Başarılı!");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata1 : " + ex);
            }
        }

        void kaydet()
        {
            try
            {

                for (int ik = 0; ik < gridView2.RowCount; ik++)
                {
                    //id = gridView1.GetSelectedRows()[ik].ToString();
                    //int y = Convert.ToInt32(id);
                    o2 = gridView2.GetRowCellValue(ik, "ID").ToString();
                    SqlCommand komutz = new SqlCommand("update RootRecete set Alt = @o1, Ust=@o2, Tam=@o3, Birim=@o4 where ID = '" + o2 + "' and AnalizID = '" + aID + "'  ", bgl.baglanti());
                    //komutz.Parameters.AddWithValue("@o1", Convert.ToDecimal(gridView2.GetRowCellValue(ik, "Alt").ToString()));
                    //komutz.Parameters.AddWithValue("@o2", Convert.ToDecimal(gridView2.GetRowCellValue(ik, "Ust").ToString()));
                    //komutz.Parameters.AddWithValue("@o3", Convert.ToDecimal(gridView2.GetRowCellValue(ik, "Tam").ToString()));
                    if (String.IsNullOrEmpty(gridView2.GetRowCellValue(ik, "Alt").ToString()))
                        komutz.Parameters.AddWithValue("@o1", "0");
                    else
                        komutz.Parameters.AddWithValue("@o1", Convert.ToDecimal(gridView2.GetRowCellValue(ik, "Alt").ToString()));
                    if (String.IsNullOrEmpty(gridView2.GetRowCellValue(ik, "Ust").ToString()))
                        komutz.Parameters.AddWithValue("@o2", "0");
                    else
                        komutz.Parameters.AddWithValue("@o2", Convert.ToDecimal(gridView2.GetRowCellValue(ik, "Ust").ToString()));
                    if (String.IsNullOrEmpty(gridView2.GetRowCellValue(ik, "Tam").ToString()))
                        komutz.Parameters.AddWithValue("@o3", "0");
                    else
                        komutz.Parameters.AddWithValue("@o3", Convert.ToDecimal(gridView2.GetRowCellValue(ik, "Tam").ToString()));
                    if (String.IsNullOrEmpty(gridView2.GetRowCellValue(ik, "Birim").ToString()))
                        komutz.Parameters.AddWithValue("@o4", "%");
                    else
                        komutz.Parameters.AddWithValue("@o4", gridView2.GetRowCellValue(ik, "Birim").ToString());




                    komutz.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }



                MessageBox.Show("Kaydetme başarılı!");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata save1 : " + ex);
            }
        }

        private void gridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            //if (e.Column.FieldName == "Birim")
            //{
            //    //if (e.Value == null)
            //    e.DisplayText = "%";
            //}
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            //btn

            if (btn_save.Text == "Güncelle")
            {
                guncelle();
            }
            else
            {
                kaydet();
            }

            kapama = "1";
        }

        private void UrunFormul_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kapama == "1")
            {

            }
            else
            {
                DialogResult sonuc = MessageBox.Show("Kaydetmeden çıkmak istediğinizden emin misiniz ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (sonuc == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    //SqlCommand add = new SqlCommand("delete from mrMix where MixID = @p1 ", bgl.baglanti());
                    //add.Parameters.AddWithValue("@p1", hID);
                    //add.ExecuteNonQuery();
                    //bgl.baglanti().Close();

                }
            }

            gelis = null;
            uID = null;
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }
        }

        private void gridView2_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu2.ShowPopup(p2);
            }
        }
    }
}
