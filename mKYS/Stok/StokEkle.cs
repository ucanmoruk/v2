using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mKYS
{
    public partial class StokEkle : Form
    {
        public StokEkle()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        private void listele()
        {
            //SqlCommand komutID = new SqlCommand("Select * From StokListesi where Durum= N'Aktif'", bgl.baglanti());
            //SqlDataReader drI = komutID.ExecuteReader();
            //while (drI.Read())
            //{
            //    combokod.Properties.Items.Add(drI["Kod"].ToString());
            //}
            //bgl.baglanti().Close();

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select ID, Kod, Ad From StokListesi where Durum= N'Aktif'", bgl.baglanti());
            da2.Fill(dt2);
            gridLookUpEdit1.Properties.DataSource = dt2;
            gridLookUpEdit1.Properties.DisplayMember = "Kod";
            gridLookUpEdit1.Properties.ValueMember = "ID";
            if (talepkod == "" || talepkod == null)
            { }
            else
            { gridLookUpEdit1.EditValue = talepkod; }
                

            DataTable dt21 = new DataTable();
            SqlDataAdapter da21 = new SqlDataAdapter("Select ID, Birim From StokFirmaBirim where Durum=N'Aktif' and FirmaID = N'" + Anasayfa.firmaID + "'", bgl.baglanti());
            da21.Fill(dt21);

            gridLookUpEdit2.Properties.DataSource = dt21;
            gridLookUpEdit2.Properties.DisplayMember = "Birim";
            gridLookUpEdit2.Properties.ValueMember = "ID";
            gridLookUpEdit2.EditValue = Anasayfa.birimID;

        }

        //private void birimbul()
        //{
        //    SqlCommand komutID = new SqlCommand("Select * From StokFirmaBirim where Durum=N'Aktif' and FirmaID = N'" + Anasayfa.firmaID + "'", bgl.baglanti());
        //    SqlDataReader drI = komutID.ExecuteReader();
        //    while (drI.Read())
        //    {
        //        combo_birim.Properties.Items.Add(drI["Birim"].ToString());
        //    }
        //    bgl.baglanti().Close();
        //}

        private void kbirim()
        {
            SqlCommand komutID = new SqlCommand("Select * From StokFirmaBirim where ID = N'" + Anasayfa.birimID + "'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                //combo_birim.Text = drI["Birim"].ToString();
                gridLookUpEdit2.EditValue = drI["ID"].ToString();
            }
            bgl.baglanti().Close();
        }

        private void temizle()
        {
            txtmarka.Text = "";
            txtmiktar.Text = "";
            txtlot.Text = "";
            txtbirim.Text = "";
            dateskt.Text = "";
            gridLookUpEdit1.EditValue = null;
        }

        void detaybul()
        {
            SqlCommand komutID = new SqlCommand("Select ID, Birim From StokListesi where Kod = N'" + talepkod + "'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                //combo_birim.Text = drI["Birim"].ToString();
                gridLookUpEdit1.EditValue = drI["ID"].ToString();
                txtbirim.Text = drI["Birim"].ToString();
            }
            bgl.baglanti().Close();
       
        }

    
        private void parolaolustur()
        {
            char[] cr = "0123456789abcdefghijklmnopqrstuvwxyz".ToCharArray();
            string result = string.Empty;
            Random r = new Random();
            for (int i = 0; i < 6; i++)
            {
                parola += cr[r.Next(0, cr.Length - 1)].ToString();
            }
        }

        string yenisim, parola, sktarih;
        private void sertekle()
        {
            try
            {
                string isim = Path.GetFileName(name);
                if (isim == null)
                {
                    MessageBox.Show("Lütfen geçerli bir doküman seçiniz.");
                }
                else
                {
                    if (gridLookUpEdit1.EditValue == null || txtmarka.Text == "")
                    {
                        MessageBox.Show("Lütfen marka, lot veya skt tarihi belirtiniz!");
                    }
                    else
                    {
                        parolaolustur();
                        string path = gridLookUpEdit1.Text + "-" + txtmarka.Text + "-" + parola + ".pdf";
                        if (dateskt.Text == "")
                        {
                            DateTime tarih = DateTime.Now;
                            dateskt.EditValue = tarih;
                            yenisim = txtmarka.Text + "-" + txtlot.Text;
                        }
                        else
                        {
                            DateTime ptarih = DateTime.Parse(dateskt.Text);
                            string tarih = ptarih.ToShortDateString();
                            yenisim = txtmarka.Text + "-" + txtlot.Text + "-" + tarih;
                        }


                        //File.Copy(name, Path.Combine(@"C:\Users\X260\Desktop\denem", path), true);

                      //  File.Copy(name, Path.Combine(@"\\WDMyCloud\KYS_Uygulama\Belgelerim\Sertifikalar", path), true);
                        File.Copy(name, Path.Combine(@Anasayfa.path, path), true);
                        SqlCommand add = new SqlCommand("insert into StokSertifika (StokID, Sertifika, SKT, Path, BirimID, Durum) values (@a1,@a2,@a3,@a4, @a5, @a6)", bgl.baglanti());
                        add.Parameters.AddWithValue("@a1", gridLookUpEdit1.EditValue);
                        add.Parameters.AddWithValue("@a2", yenisim);
                        add.Parameters.AddWithValue("@a3", dateskt.EditValue);
                        add.Parameters.AddWithValue("@a4", path);
                        add.Parameters.AddWithValue("@a5", gridLookUpEdit1.EditValue);
                        add.Parameters.AddWithValue("@a6", "Aktif");
                        add.ExecuteNonQuery();
                        bgl.baglanti().Close();
                        btnsertifika.Enabled = true;
                    }


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ekleme()
        {
           // float f1 = float.Parse(txtmiktar.Text);
            double f1 = Convert.ToDouble(txtmiktar.Text);
            
            if (dateskt.EditValue == null)
            {
                sktarih = "1900-01-01";
            }
            else
            {
                sktarih = Convert.ToDateTime(dateskt.EditValue).ToString("yyyy-MM-dd");

            }

            SqlCommand add = new SqlCommand("insert into StokHareket (StokID, Marka,Lot,Miktar,Birim,SKT,Tarih,Hareket, BirimID, Durum) values (@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9,@a10)", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", gridLookUpEdit1.EditValue);
            add.Parameters.AddWithValue("@a2", txtmarka.Text);
            add.Parameters.AddWithValue("@a3", txtlot.Text);
            add.Parameters.AddWithValue("@a4", f1);
            add.Parameters.AddWithValue("@a5", txtbirim.Text);
            add.Parameters.AddWithValue("@a6", sktarih);
            add.Parameters.AddWithValue("@a7", dategiris.EditValue);
            add.Parameters.AddWithValue("@a8", "Giriş");
            add.Parameters.AddWithValue("@a9", gridLookUpEdit2.EditValue);
            add.Parameters.AddWithValue("@a10", "Aktif");
            add.ExecuteNonQuery();
            bgl.baglanti().Close();

            if (kontrol == "1")
            {
                sertekle();
            }

        }

        public static string talepkod, talepmiktar;
        private void StokEkle_Load(object sender, EventArgs e)
        {
            if (talepkod == "" || talepkod == null)
            {
                kontrol = "0";
               // birimbul();
              //  kbirim();
                listele();
                DateTime tarih = DateTime.Now;
                dategiris.EditValue = tarih;

            }
            else
            {
                kontrol = "0";               
             //   birimbul();
             //   kbirim();
                listele();
                detaybul();
                DateTime tarih = DateTime.Now;
                dategiris.EditValue = tarih;

              //  combokod.Text = talepkod;
                txtmiktar.Text = talepmiktar;

            }
           

        }

        int stokid;
        //private void combokod_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    temizle();

        //    SqlCommand komutID = new SqlCommand("Select * From StokListesi where Kod = N'"+combokod.Text+"'", bgl.baglanti());
        //    SqlDataReader drI = komutID.ExecuteReader();
        //    while (drI.Read())
        //    {
        //        stokid = Convert.ToInt32(drI["ID"].ToString());
        //        txtbirim.Text = drI["Birim"].ToString();
        //    }
        //    bgl.baglanti().Close();
        //}

        double stok;
        string stokk;
        private void anastok()
        {
            SqlCommand komutID = new SqlCommand("select SUM(Miktar) from StokHareket where StokID = '"+gridLookUpEdit1.EditValue+"' ", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
              //  stokk = drI[0].ToString();
                stok = Convert.ToDouble(drI[0].ToString());
            }
            bgl.baglanti().Close();
          //  stok = float.Parse(stokk);

            SqlCommand add = new SqlCommand("update StokListesi set Miktar = @a1 where ID = N'" + gridLookUpEdit1.EditValue + "'", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", stok);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();

        }

        StokListesi m = (StokListesi)System.Windows.Forms.Application.OpenForms["StokListesi"];

        private void btnadd_Click(object sender, EventArgs e)
        {
            ekleme();
            anastok();

            if (Application.OpenForms["StokListesi"] == null)
            {

            }
            else
            {
                m.listele();
            }

            MessageBox.Show("Stoğunuz güncellenmiştir!", "Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            temizle();

            if (talepkod == "" | talepkod == null)
            {

            }
            else
            {
                this.Close();
            }


        }

        string kontrol, name;

        private void StokEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            talepkod = null;
            talepmiktar = null;
        }

        private void gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            SqlCommand komutID = new SqlCommand("Select Birim From StokListesi where ID = N'" + gridLookUpEdit1.EditValue + "'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                txtbirim.Text = drI["Birim"].ToString();
            }
            bgl.baglanti().Close();
        }

        private void gridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        int birimID;
        //private void combo_birim_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    SqlCommand komutID = new SqlCommand("Select * From StokFirmaBirim where Birim = N'" + combo_birim.Text + "' and FirmaID = N'" + Anasayfa.firmaID + "'", bgl.baglanti());
        //    SqlDataReader drI = komutID.ExecuteReader();
        //    while (drI.Read())
        //    {
        //        birimID = Convert.ToInt32(drI["ID"].ToString());
        //    }
        //    bgl.baglanti().Close();
        //}

        private void btnsertifika_Click(object sender, EventArgs e)
        {
            Sertifika.skod = gridLookUpEdit1.EditValue.ToString();
            Sertifika s = new Sertifika();
            s.Show();

            //OpenFileDialog open = new OpenFileDialog();

            //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            ////To where your opendialog box get starting location. My initial directory location is desktop.
            //open.InitialDirectory = path;
            ////Your opendialog box title name.
            //open.Title = "Yüklemek istediğiniz dosyayı seçiniz.";
            ////which type file format you want to upload in database. just add them.
            //open.Filter = "Select Valid Document(*.pdf; *.doc; *.xlsx; *.html)|*.pdf; *.docx; *.xlsx; *.html";
            ////FilterIndex property represents the index of the filter currently selected in the file dialog box.
            //open.FilterIndex = 1;
            //try
            //{
            //    if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    {
            //        if (open.CheckFileExists)
            //        {
            //            name = System.IO.Path.GetFullPath(open.FileName);
            //            btnsertifika.Enabled = false;
            //            kontrol = "1";
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Lütfen dosya seçiniz.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}


        }
    }
}
