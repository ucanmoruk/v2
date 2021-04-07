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

namespace StokTakip
{
    public partial class Sertifika : Form
    {
        public Sertifika()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        private void listele()
        {
            SqlCommand komutID = new SqlCommand("Select * From StokListesi where Durum=N'Aktif'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                combokod.Properties.Items.Add(drI["Kod"].ToString());
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

        string yenisim, parola;
        private void ekleme()
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
                    if (combokod.Text == "" || txtmarka.Text == "")
                    {
                        MessageBox.Show("Lütfen marka, lot veya skt tarihi belirtiniz!");
                    }
                    else
                    {
                        parolaolustur();
                        string path = combokod.Text + "-" + txtmarka.Text + "-" + parola + ".pdf";
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


                        File.Copy(name, Path.Combine(@"\\WDMyCloud\KYS_Uygulama\Belgelerim\Sertifikalar", path), true);
                 
                        SqlCommand add = new SqlCommand("insert into StokSertifika (StokID, Sertifika, SKT, Path) values (@a1,@a2,@a3,@a4)", bgl.baglanti());
                        add.Parameters.AddWithValue("@a1", stokid);
                        add.Parameters.AddWithValue("@a2", yenisim);
                        add.Parameters.AddWithValue("@a3", dateskt.EditValue);
                        add.Parameters.AddWithValue("@a4", path);
                        add.ExecuteNonQuery();
                        bgl.baglanti().Close();


                        MessageBox.Show("Sertifika başarı ile yüklendi!", "Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        txtmarka.Text = "";
                        txtlot.Text = "";
                        dateskt.Text = "";
                        combokod.Text = "";
                        btnsertifika.Enabled = true;
                    }
                    

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Sertifika_Load(object sender, EventArgs e)
        {
            listele();
        }

        public static string name;
        private void btnsertifika_Click(object sender, EventArgs e)

        {
            OpenFileDialog open = new OpenFileDialog();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            //To where your opendialog box get starting location. My initial directory location is desktop.
            open.InitialDirectory = path;
            //Your opendialog box title name.
            open.Title = "Yüklemek istediğiniz dosyayı seçiniz.";
            //which type file format you want to upload in database. just add them.
            open.Filter = "Select Valid Document(*.pdf; *.doc; *.xlsx; *.html)|*.pdf; *.docx; *.xlsx; *.html";
            //FilterIndex property represents the index of the filter currently selected in the file dialog box.
            open.FilterIndex = 1;
            try
            {
                if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (open.CheckFileExists)
                    {
                        name = System.IO.Path.GetFullPath(open.FileName);
                        btnsertifika.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen dosya seçiniz.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int stokid;
        private void combokod_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komutID = new SqlCommand("Select * From StokListesi where Kod = N'" + combokod.Text + "'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                stokid = Convert.ToInt32(drI["ID"].ToString());
            }
            bgl.baglanti().Close();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            ekleme();
        }
    }
}
