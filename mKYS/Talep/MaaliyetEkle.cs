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

namespace mKYS.Talep
{
    public partial class MaaliyetEkle : Form
    {
        public MaaliyetEkle()
        {
            InitializeComponent();
            
        }

        sqlbaglanti bgl = new sqlbaglanti();

        void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(" select d.StokKod, l.Ad, d.Miktar, d.Birim, m.BirimFiyat, m.TL, m.Dolar, m.Euro, m.Tarih, t.Ad as 'Firma Adı' from StokTalepDetay d " +
                "inner join StokListesi l on d.StokKod = l.Kod  " +
                "left join  StokMaliyet m on d.StokKod = m.StokKod  left join StokTedarikci t on m.TedarikciID = t.ID " +
                " where d.TalepNo = '"+ talepno+ "' and t.Ad is null " +
                " order by d.StokKod asc", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;

            RepositoryItemComboBox riComboBox = new RepositoryItemComboBox();
            SqlCommand komut2 = new SqlCommand("select Ad from StokTedarikci where Durum = 'Aktif'", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                riComboBox.Items.Add(dr2[0]);
                gridControl1.RepositoryItems.Add(riComboBox);
                gridView1.Columns["Firma Adı"].ColumnEdit = riComboBox;
            }
            bgl.baglanti().Close();

            RepositoryItemDateEdit date = new RepositoryItemDateEdit();
            gridView1.Columns["Tarih"].ColumnEdit = date;

            this.gridView1.Columns[0].Width = 50;
            this.gridView1.Columns[1].Width = 150;
            this.gridView1.Columns[2].Width = 50;
            this.gridView1.Columns[3].Width = 50;
            this.gridView1.Columns[4].Width = 50;
            this.gridView1.Columns[5].Width = 50;
            this.gridView1.Columns[6].Width = 50;
            this.gridView1.Columns[7].Width = 50;
            this.gridView1.Columns[8].Width = 75;
            this.gridView1.Columns[9].Width = 150;
        }

        void listele2()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(" select d.StokKod, l.Ad, d.Miktar, d.Birim, m.BirimFiyat, m.TL, m.Dolar, m.Euro, m.Tarih, t.Ad as 'Firma Adı' from StokTalepDetay d " +
                "inner join StokListesi l on d.StokKod = l.Kod  " +
                "left join  StokMaliyet m on d.StokKod = m.StokKod  left join StokTedarikci t on m.TedarikciID = t.ID " +
                " where d.TalepNo = '" + talepno + "' and d.StokKod = '"+gelis+ "' order by d.StokKod asc", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;

            RepositoryItemComboBox riComboBox = new RepositoryItemComboBox();
            SqlCommand komut2 = new SqlCommand("select Ad from StokTedarikci where Durum = 'Aktif'", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                riComboBox.Items.Add(dr2[0]);
                gridControl1.RepositoryItems.Add(riComboBox);
                gridView1.Columns["Firma Adı"].ColumnEdit = riComboBox;
            }
            bgl.baglanti().Close();

            RepositoryItemDateEdit date = new RepositoryItemDateEdit();
            gridView1.Columns["Tarih"].ColumnEdit = date;

            this.gridView1.Columns[0].Width = 50;
            this.gridView1.Columns[1].Width = 150;
            this.gridView1.Columns[2].Width = 50;
            this.gridView1.Columns[3].Width = 50;
            this.gridView1.Columns[4].Width = 50;
            this.gridView1.Columns[5].Width = 50;
            this.gridView1.Columns[6].Width = 50;
            this.gridView1.Columns[7].Width = 50;
            this.gridView1.Columns[8].Width = 75;
            this.gridView1.Columns[9].Width = 150;
        }

        public void kayit()
        {
            var mfrm = (Anasayfa)Application.OpenForms["Anasayfa"];
            if (mfrm != null)
                mfrm.eklemebuton();
        }

        public static string talepno, gelis;
        private void MaaliyetEkle_Load(object sender, EventArgs e)
        {
            
            if (talepno == "" || talepno == null)
            {
                MessageBox.Show(talepno+" numaralı talep bulunamamıştır!");
            }
            else
            {
                if (gelis == "" || gelis == null)
                {
                    listele();
                    Text = talepno + " No'lu Talep Maaliyet Bilgileri";
                    kayit();
                }
                else
                {
                    listele2();
                    Text = talepno + " No'lu Talep Maaliyet Bilgileri";
                    kayit();
                }
               
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "StokKod" || e.Column.FieldName == "Miktar" || e.Column.FieldName == "Birim" || e.Column.FieldName == "TL" || e.Column.FieldName == "Dolar" || e.Column.FieldName == "Euro" || e.Column.FieldName == "BirimFiyat")
            {
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
        }

        public void eskisil()
        {
            SqlCommand add = new SqlCommand("delete from StokMaliyet where TalepNo = @p1 and StokKod = @p2 ", bgl.baglanti());
            add.Parameters.AddWithValue("@p1", talepno);
            add.Parameters.AddWithValue("@p2", gelis);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();

        }

        MaliyetListesi m = (MaliyetListesi)System.Windows.Forms.Application.OpenForms["MaliyetListesi"];

        string firmaadi, mtarih, xtarih;
        int firmaid;
        decimal xbirimfiyat, xtl, xdolar, xeuro;

        void kayital()
        {
            for (int ik = 0; ik < gridView1.RowCount; ik++)
            {

                firmaadi = gridView1.GetRowCellValue(ik, "Firma Adı").ToString();
                if (firmaadi == "" || firmaadi == null)
                {

                }
                else
                {
                    SqlCommand komut21 = new SqlCommand("Select ID from StokTedarikci where Ad = N'" + firmaadi + "' ", bgl.baglanti());
                    SqlDataReader dr21 = komut21.ExecuteReader();
                    while (dr21.Read())
                    {
                        firmaid = Convert.ToInt32(dr21["ID"]);
                    }
                    bgl.baglanti().Close();

                    mtarih = gridView1.GetRowCellValue(ik, "Tarih").ToString();
                    if (mtarih == "" || mtarih == null)
                    {
                        //  MessageBox.Show("Lütfen teslimat tarihini seçiniz!" , "Oopps!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {

                        xtarih = Convert.ToDateTime(mtarih).ToString("yyyy-MM-dd");
                        string dolar = gridView1.GetRowCellValue(ik, "Dolar").ToString();
                        string euro = gridView1.GetRowCellValue(ik, "Euro").ToString();
                        string tl = gridView1.GetRowCellValue(ik, "TL").ToString();
                        string birimfiyat = gridView1.GetRowCellValue(ik, "BirimFiyat").ToString();

                        //if (birimfiyat == "" || birimfiyat == null)
                        //    xbirimfiyat = 0;
                        //else
                        //    xbirimfiyat = Convert.ToDecimal(birimfiyat);

                        if (dolar == "" || dolar == null)
                            xdolar = 0;
                        else
                            xdolar = Convert.ToDecimal(dolar);

                        if (tl == "" || tl == null)
                            xtl = 0;
                        else
                            xtl = Convert.ToDecimal(tl);

                        if (euro == "" || euro == null)
                            xeuro = 0;
                        else
                            xeuro = Convert.ToDecimal(euro);

                        SqlCommand komutz = new SqlCommand("insert into StokMaliyet (TedarikciID, TalepNo, StokKod, Durum, Tarih, BirimFiyat, Tl, Dolar, Euro) values (@a1, @a2, @a3, @a9, @a4,@a5, @a6, @a7, @a8)", bgl.baglanti());
                        komutz.Parameters.AddWithValue("@a1", firmaid);
                        komutz.Parameters.AddWithValue("@a2", talepno);
                        komutz.Parameters.AddWithValue("@a3", gridView1.GetRowCellValue(ik, "StokKod").ToString());
                        komutz.Parameters.AddWithValue("@a4", xtarih);
                        komutz.Parameters.AddWithValue("@a5", birimfiyat);
                        komutz.Parameters.AddWithValue("@a6", xtl);
                        komutz.Parameters.AddWithValue("@a7", xdolar);
                        komutz.Parameters.AddWithValue("@a8", xeuro);
                        komutz.Parameters.AddWithValue("@a9", "Aktif");
                        komutz.ExecuteNonQuery();
                        bgl.baglanti().Close();
                    }

                }





            }
        }

        public void kaydetme()
        {

            if (gelis == "" || gelis == null)
            {
                kayital();
            }
            else
            {
                eskisil();
                kayital();
            }            
            
            MessageBox.Show("Maaliyet listesi başarıyla güncellenmiştir! İyi günler dilerim.", "Oopppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            if (Application.OpenForms["MaliyetListesi"] == null)
            {

            }
            else
            {
                m.listele();
            }

            this.Close();


        }

        private void MaaliyetEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            kayit();
            talepno = "";
            gelis = "";
        }
    }
}
