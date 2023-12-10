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
    public partial class AnalizDetay : Form
    {
        public AnalizDetay()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt2 = new DataTable();
            //  SqlDataAdapter da2 = new SqlDataAdapter("select r.StokKod as 'Kod', l.Ad, l.Miktar, l.Birim, l.Limit as 'Kritik Limit' from StokRecete r inner join StokListesi l on r.StokKod = l.Kod where r.AnalizKod = N'" + skod + "' order by r.StokKod", bgl.baglanti());
          //  SqlDataAdapter da2 = new SqlDataAdapter("select Kod, Ad, Miktar, Birim, Limit as 'Kritik Limit' from StokListesi where ID in (select StokID from StokRecete where AnalizID = '" + aID + "')", bgl.baglanti());
            SqlDataAdapter da2 = new SqlDataAdapter(@"select h.ID, b.Birim, h.Hareket, h.Tarih, h.Aciklama, CONVERT(nvarchar,REPLACE(h.Miktar,',',''))+' Adet' as 'Miktar',  
CONVERT(nvarchar,REPLACE(Fiyat,',',''))+' ₺' as 'Fiyat' from RootUrunHareket h
left join RootFirmaBirim b on h.BirimID = b.ID
where h.UrunID = '" + aID+"' and h.Durum = 'Aktif'", bgl.baglanti());

            da2.Fill(dt2);
            gridControl1.DataSource = dt2;
            gridView1.Columns["ID"].Visible = false;
            this.gridView1.Columns[1].Width = 75;
            this.gridView1.Columns[2].Width = 50;
            this.gridView1.Columns[3].Width = 50;
            this.gridView1.Columns[4].Width = 75;
            this.gridView1.Columns[5].Width = 50;
            this.gridView1.Columns[6].Width = 50;


        }

        int mID, bID;
        void detaybul()
        {

            SqlCommand komut21 = new SqlCommand("Select * from ValidasyonVeri where AnalizID = N'" + aID + "' and Durum = 'Aktif' or Durum = 'Ortak'", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                //urun.Text = dr21["Urun"].ToString();
                //date_basla.EditValue = Convert.ToDateTime(dr21["Tarih1"].ToString());
                //date_bit.EditValue = Convert.ToDateTime(dr21["Tarih2"].ToString());
                //birim.Text = dr21["Birim"].ToString();
                //lod.Text = dr21["Lod"].ToString();
                //loq.Text = dr21["Loq"].ToString();
                //gerikazanim.Text = dr21["GK"].ToString();
                //bel.Text = dr21["Bel"].ToString();

            }
            bgl.baglanti().Close();

            SqlCommand komut2 = new SqlCommand("Select * from  StokAnalizListesi where ID = N'" + aID + "' ", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
               // kod.Text = dr2["Kod"].ToString();
             //   ad.Text = dr2["Ad"].ToString();
                bID = Convert.ToInt32(dr2["Birim"].ToString());
                mID = Convert.ToInt32(dr2["Metot"].ToString());

                SqlCommand komut1 = new SqlCommand("Select * from  StokDKDListe where ID = N'" + mID + "' ", bgl.baglanti());
                SqlDataReader dr1 = komut1.ExecuteReader();
                while (dr1.Read())
                {
                    string kod = dr1["Kod"].ToString();
                    string ad = dr1["Ad"].ToString();
             //       metot.Text = kod + " " + ad;
                }
                bgl.baglanti().Close();

                SqlCommand komut11 = new SqlCommand(" select * from StokFirmaBirim where ID = '"+bID+"' ", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                 //   txt_birim.Text = dr11["Birim"].ToString();
                }
                bgl.baglanti().Close();

            }
            bgl.baglanti().Close();


        }
        public static string aID, skod, sad;

        string hID;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //focused
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            hID = dr["ID"].ToString();
            //  dmarka = dr["Açıklama"].ToString();
            //dlot = dr["Lot"].ToString();
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }
        }
        StokListesi m = (StokListesi)System.Windows.Forms.Application.OpenForms["StokListesi"];
        AnalizListesi a = (AnalizListesi)System.Windows.Forms.Application.OpenForms["AnalizListesi"];

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // işlemi sil - hID UretimID
            //  checksil();

            try
            {
                if (gridView1.SelectedRowsCount == 0)
                {
                    MessageBox.Show("Lütfen iptal etmek istediğiniz işlemi seçiniz!", "Oopppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    DialogResult Secim = new DialogResult();

                    Secim = MessageBox.Show("Bu işlemi iptal etmek istediğinizden emin misiniz ? Bu işlem ürün stoğu ve hammadde stok miktarını da etkileyecektir. ", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (Secim == DialogResult.Yes)
                    {

                        checksil();

                        MessageBox.Show("Güncelleme işlemi başarılı!", "Oppss!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                       
                        if (Application.OpenForms["StokListesi"] == null)
                        { }
                        else
                        {
                            m.listele();
                        }
                        if (Application.OpenForms["AnalizListesi"] == null)
                        { }
                        else
                        {
                            a.listele();
                        }

                        listele();

                    }

                }




            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata SD1 : " + ex.Message);
            }

        }

        string id;
        int stok;
        private void checksil()
        {
            // işlemi sil - hID UretimID

            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {

                id = gridView1.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                int haID = Convert.ToInt32(gridView1.GetRowCellValue(y, "ID").ToString());
                SqlCommand add = new SqlCommand("update RootUrunHareket set Durum=@o1 where ID= N'" + haID + "' ", bgl.baglanti());
                add.Parameters.AddWithValue("@o1", "Pasif");
                add.ExecuteNonQuery();
                bgl.baglanti().Close();

                SqlCommand adda2 = new SqlCommand("update RootStokHareket set Durum=@o1 where UretimID= N'" + haID + "' ", bgl.baglanti());
                adda2.Parameters.AddWithValue("@o1", "Pasif");
                adda2.ExecuteNonQuery();
                bgl.baglanti().Close();

            }

            stokhareket();
            anastok();
            


        }

        string stokid, stoktoplam, urunstok;
        float stogunstogu;
        void stokhareket()
        {
            SqlCommand komutID = new SqlCommand("select StokID from RootRecete where AnalizID = '" + aID + "'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
               stokid = drI[0].ToString();

                SqlCommand komutx = new SqlCommand("select SUM(Miktar) from RootStokHareket where StokID = '"+stokid+"' and Durum = N'Aktif'", bgl.baglanti());
                SqlDataReader drx = komutx.ExecuteReader();
                while (drx.Read())
                {
                    stoktoplam = drx[0].ToString();
                }
                bgl.baglanti().Close();
                stogunstogu = float.Parse(stoktoplam);

                SqlCommand add2 = new SqlCommand("update RootStokListesi set Miktar = @a1 where ID = N'" + stokid + "'", bgl.baglanti());
                add2.Parameters.AddWithValue("@a1", stogunstogu);
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();

            }
            bgl.baglanti().Close();

        }

        void anastok()
        {
            SqlCommand komutID = new SqlCommand("select SUM(Miktar) from RootUrunHareket where UrunID = '" + aID + "' and Durum = 'Aktif' ", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
              //  stok = Convert.ToInt32(drI[0].ToString());
                urunstok = drI[0].ToString();
            }
            bgl.baglanti().Close();

            if (urunstok == null || urunstok == "")
            {
                stok = 0;
            }
            else
            {
                stok = Convert.ToInt32(urunstok);
            }

            SqlCommand add = new SqlCommand("update RootUrunListesi set Miktar = @a1 where ID = N'" + aID + "'", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", stok);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        private void AnalizDetay_Load(object sender, EventArgs e)
        {
            listele();
           // detaybul();
            Text = skod + " - " + sad + " Ürün Detayları";

        }
    }
}