using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakip.Cihaz
{
    public partial class CihazHareket : Form
    {
        public CihazHareket()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        void listele()
        {
            SqlCommand komutID = new SqlCommand("Select * From CihazListesi where ID= N'" + cID + "'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {

                txt_kod.Text = drI["Kod"].ToString(); 
                txt_ad.Text = drI["Ad"].ToString(); 
            }
            bgl.baglanti().Close();
        }

        void listele2()
        {
            if (comboBoxEdit1.Text == "Firma İçi")
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select ID, Ad + ' ' + Soyad as 'Ad' from StokKullanici where Durum= 'Aktif'", bgl.baglanti());
                da.Fill(dt);

                gridLookUpEdit1.Properties.DataSource = dt;
                gridLookUpEdit1.Properties.DisplayMember = "Ad";
                gridLookUpEdit1.Properties.ValueMember = "ID";
            }
            else
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select ID, Ad from StokTedarikci where Durum= 'Aktif'", bgl.baglanti());
                da.Fill(dt);

                gridLookUpEdit1.Properties.DataSource = dt;
                gridLookUpEdit1.Properties.DisplayMember = "Ad";
                gridLookUpEdit1.Properties.ValueMember = "ID";
            }
        }

        string CihazID, fin;
        void listele3()
        {
            txt_ad.Enabled = true;
            txt_kod.Enabled = true;

            SqlCommand komutID = new SqlCommand("Select * From CihazIslem where ID= N'" + cID + "'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                CihazID = drI["CihazID"].ToString();

                tarih_1.EditValue = drI["Tarih1"];

                if (drI["Tarih2"] == null)
                {
                }
                else
                {                 
                    tarih2.EditValue = drI["Tarih2"];
                }

                
                txt_durum.Text = drI["Aciklama"].ToString(); 
                fin = drI["Finout"].ToString();
               
                if (fin == "i")
                {
                    comboBoxEdit1.Text = "Firma İçi";
                    gridLookUpEdit1.EditValue = drI["PersonelID"].ToString();
                    listele2();
                }                   
                else if (fin == "o") 
                {
                    comboBoxEdit1.Text = "Firma Dışı";
                    gridLookUpEdit1.EditValue = drI["FirmaID"].ToString();
                    listele2();
                }
                else
                {
                    comboBoxEdit1.Text = "";
                    listele2();
                }
                       

            }
            bgl.baglanti().Close();

            SqlCommand komutI = new SqlCommand("Select * From CihazListesi where ID= N'" + CihazID + "'", bgl.baglanti());
            SqlDataReader dr = komutI.ExecuteReader();
            while (dr.Read())
            {
                txt_kod.Text = dr["Kod"].ToString();
                txt_ad.Text = dr["Ad"].ToString();

            }
            bgl.baglanti().Close();
        }


        private void tarih_1_EditValueChanged(object sender, EventArgs e)
        {
            if (tur == "Kalibrasyon")
            {
                tarih2.EditValue = tarih_1.DateTime.AddYears(1);
            }
            else if (tur == "Ara Kontrol")
            {
                tarih2.EditValue = tarih_1.DateTime.AddMonths(6);
            }

            
        }

        private void CihazHareket_FormClosed(object sender, FormClosedEventArgs e)
        {

            tur = "";
            cID = "";
            gelis = "";
            CihazID = "";
        }

        public static string name, yenisim, path;
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

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridLookUpEdit1.EditValue = null;
            gridLookUpEdit1.Properties.DataSource = null;
            gridLookUpEdit1.Properties.DisplayMember = null;
            gridLookUpEdit1.Properties.ValueMember = null;
            listele2();
        }

        private void gridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            if (comboBoxEdit1.Text == "" || comboBoxEdit1.Text == null)
            {

            }
            else
            {
                GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
                gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
            }
          
        }

        private void gridLookUpEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GridLookUpEdit edit = sender as GridLookUpEdit;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Close)
            {
                gridLookUpEdit1.EditValue = null;
            }
        }

        string fID;
        private void gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (gridLookUpEdit1.EditValue == null)
                fID = null;
            else
                fID = gridLookUpEdit1.EditValue.ToString();
        }

        void ekleme()
        {
            try
            {
                if (btnsertifika.Enabled == false)
                {
                    string isim = Path.GetFileName(name);
                    DateTime ptarih = DateTime.Parse(tarih_1.Text);
                    string tarih = ptarih.ToShortDateString();
                    path = "Kalibrasyon -" + txt_kod.Text + "-" + tarih + ".pdf";
                    //  yenisim = "Kalibrasyon -" + txt_kod.Text + "-" + tarih;
                    File.Copy(name, Path.Combine(@Anasayfa.path, path), true);

                }
                else
                {
                    path = null;
                }

                if (tarih_1.Text == "")
                {
                    MessageBox.Show("Lütfen işlem tarihi seçiniz!", "Ooppss!");
                }
                else
                {

                    //path'i kal. ID ile eşleştirip kaydet! .Eski sertifikaları da göster'

                    SqlCommand add = new SqlCommand(" insert into CihazIslem (CihazID, Tur, FirmaID, PersonelID, Tarih1, Tarih2, Aciklama, Path, Durum,Finout) values (@a1, @a2, @a3, @a4, @a5, @a6,@a7,@a8,@a9,@a10) ", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", cID);
                    add.Parameters.AddWithValue("@a2", tur);
                    if (String.IsNullOrEmpty(fID))
                    {
                        add.Parameters.AddWithValue("@a3", DBNull.Value);
                        add.Parameters.AddWithValue("@a4", DBNull.Value);
                    }
                    else
                    {
                        if (comboBoxEdit1.Text == "Firma İçi")
                        {
                            add.Parameters.AddWithValue("@a3", DBNull.Value);
                            add.Parameters.AddWithValue("@a4", gridLookUpEdit1.EditValue.ToString());
                        }
                        else
                        {
                            add.Parameters.AddWithValue("@a3", gridLookUpEdit1.EditValue.ToString());
                            add.Parameters.AddWithValue("@a4", DBNull.Value);
                        }
                    }
                    add.Parameters.AddWithValue("@a5", tarih_1.EditValue);
                    if (String.IsNullOrEmpty(tarih2.Text))
                    {
                        add.Parameters.AddWithValue("@a6", DBNull.Value);
                    }
                    else
                    {
                        add.Parameters.AddWithValue("@a6", tarih2.EditValue);
                    }
                    add.Parameters.AddWithValue("@a7", txt_durum.Text);
                    if (String.IsNullOrEmpty(path))
                    {
                        add.Parameters.AddWithValue("@a8", DBNull.Value);
                    }
                    else
                    {
                        add.Parameters.AddWithValue("@a8", path);
                    }

                    add.Parameters.AddWithValue("@a9", "Aktif");
                    if (comboBoxEdit1.Text == "Firma İçi")
                    {
                        add.Parameters.AddWithValue("@a10", "i");
                    }
                    else if (comboBoxEdit1.Text == "Firma Dışı")
                    {
                        add.Parameters.AddWithValue("@a10", "o");
                    }
                    else
                    {
                        add.Parameters.AddWithValue("@a10", DBNull.Value);
                    }
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    MessageBox.Show("Başarıyla kaydedildi!", "Ooppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    this.Close();


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata C112: " + ex);
            }


        }


        void guncelle()
        {
            try
            {
                if (btnsertifika.Enabled == false)
                {
                    string isim = Path.GetFileName(name);
                    DateTime ptarih = DateTime.Parse(tarih_1.Text);
                    string tarih = ptarih.ToShortDateString();
                    path = "Kalibrasyon -" + txt_kod.Text + "-" + tarih + ".pdf";
                    //  yenisim = "Kalibrasyon -" + txt_kod.Text + "-" + tarih;
                    File.Copy(name, Path.Combine(@Anasayfa.path, path), true);

                }
                else
                {
                    path = null;
                }

                if (tarih_1.Text == "")
                {
                    MessageBox.Show("Lütfen işlem tarihi seçiniz!", "Ooppss!");
                }
                else
                {

                    SqlCommand add = new SqlCommand(" update CihazIslem set FirmaID =@a1, PersonelID=@a2, Tarih1=@a3, Tarih2=@a4, Aciklama=@a5, Path=@a6, Finout=@a7 where ID = '"+cID+"' ", bgl.baglanti());

                    if (String.IsNullOrEmpty(fID))
                    {
                        add.Parameters.AddWithValue("@a1", DBNull.Value);
                        add.Parameters.AddWithValue("@a2", DBNull.Value);
                    }
                    else
                    {
                        if (comboBoxEdit1.Text == "Firma İçi")
                        {
                            add.Parameters.AddWithValue("@a1", DBNull.Value);
                            add.Parameters.AddWithValue("@a2", gridLookUpEdit1.EditValue.ToString());
                        }
                        else
                        {
                            add.Parameters.AddWithValue("@a1", gridLookUpEdit1.EditValue.ToString());
                            add.Parameters.AddWithValue("@a2", DBNull.Value);
                        }
                    }
                    add.Parameters.AddWithValue("@a3", tarih_1.EditValue);
                    if (String.IsNullOrEmpty(tarih2.Text))
                    {
                        add.Parameters.AddWithValue("@a4", DBNull.Value);
                    }
                    else
                    {
                        add.Parameters.AddWithValue("@a4", tarih2.EditValue);
                    }
                    add.Parameters.AddWithValue("@a5", txt_durum.Text);
                    if (String.IsNullOrEmpty(path))
                    {
                        add.Parameters.AddWithValue("@a6", DBNull.Value);
                    }
                    else
                    {
                        add.Parameters.AddWithValue("@a6", path);
                    }

                    if (comboBoxEdit1.Text == "Firma İçi")
                    {
                        add.Parameters.AddWithValue("@a7", "i");
                    }
                    else if (comboBoxEdit1.Text == "Firma Dışı")
                    {
                        add.Parameters.AddWithValue("@a7", "o");
                    }
                    else
                    {
                        add.Parameters.AddWithValue("@a7", DBNull.Value);
                    }
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    MessageBox.Show("Başarıyla güncellendi!", "Ooppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    this.Close();


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata C112: " + ex);
            }


        }
        CihazEkle m = (CihazEkle)System.Windows.Forms.Application.OpenForms["CihazEkle"];
        KalibrasyonListesi k = (KalibrasyonListesi)System.Windows.Forms.Application.OpenForms["KalibrasyonListesi"];
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (btn_save.Text == "Güncelle")
            {
                guncelle();
                if (Application.OpenForms["CihazEkle"] == null)
                { }
                else
                {
                    m.listele4();
                }

                if (Application.OpenForms["KalibrasyonListesi"] == null)
                { }
                else
                {
                    k.listele();
                }

            }
            else
            {
                ekleme();
            }
           
        }

        public static string cID, tur, gelis;
        private void CihazHareket_Load(object sender, EventArgs e)
        {
           

            if (gelis== "Güncelle")
            {
                if (tur == "Kalibrasyon")
                {
                    Text = "Cihaz Kalibrasyon Bilgisi";
                    btn_save.Text = "Güncelle";
                    listele3();
                }
                else if (tur == "Ara Kontrol")
                {
                    listele3();
                    Text = "Cihaz Ara Kontrol Bilgisi";
                    lbl_kal.Text = "Ara Kontrol Tarihi:";
                    lbl_skal.Text = "Sonraki Ara Kontrol Tarihi:";
                    lbl_yukle.Text = "Belge Yükle:";
                    lbl_yukle.Location = new Point(87, 221);
                    btnsertifika.Text = "Belge Seç";
                    btn_save.Text = "Güncelle";

                }
                else
                {
                    listele3();
                    Text = "Cihaz Bakım / Onarım Bilgisi";
                    lbl_degerlendirme.Text = "Açıklama:";
                    lbl_kal.Text = "Bakım / Onarım Tarihi:";
                    lbl_kal.Location = new Point(41, 87);
                    lbl_skal.Visible = false;
                    tarih2.Visible = false;
                    lbl_uygula.Location = new Point(90, 118);
                    comboBoxEdit1.Location = new Point(155, 115);
                    gridLookUpEdit1.Location = new Point(231, 115);
                    lbl_degerlendirme.Location = new Point(104, 148);
                    txt_durum.Location = new Point(155, 148);
                    lbl_yukle.Location = new Point(87, 186);
                    btnsertifika.Location = new Point(155, 183);
                    btn_save.Location = new Point(155, 221);
                    lbl_yukle.Text = "Belge Yükle:";
                    btnsertifika.Text = "Belge Seç";
                    btn_save.Text = "Güncelle";
                    this.Size = new Size(404, 348);

                }
            }
            else
            {
                listele();
                if (tur == "Kalibrasyon")
                {
                    Text = "Cihaz Kalibrasyon Bilgisi";
                }
                else if (tur == "Ara Kontrol")
                {
                    Text = "Cihaz Ara Kontrol Bilgisi";
                    lbl_kal.Text = "Ara Kontrol Tarihi:";
                    lbl_skal.Text = "Sonraki Ara Kontrol Tarihi:";
                    lbl_yukle.Text = "Belge Yükle:";
                    lbl_yukle.Location = new Point(87, 221);
                    btnsertifika.Text = "Belge Seç";

                }
                else
                {
                    Text = "Cihaz Bakım / Onarım Bilgisi";
                    lbl_degerlendirme.Text = "Açıklama:";
                    lbl_kal.Text = "Bakım / Onarım Tarihi:";
                    lbl_kal.Location = new Point(41, 87);
                    lbl_skal.Visible = false;
                    tarih2.Visible = false;
                    lbl_uygula.Location = new Point(90, 118);
                    comboBoxEdit1.Location = new Point(155, 115);
                    gridLookUpEdit1.Location = new Point(231, 115);
                    lbl_degerlendirme.Location = new Point(104, 148);
                    txt_durum.Location = new Point(155, 148);
                    lbl_yukle.Location = new Point(87, 186);
                    btnsertifika.Location = new Point(155, 183);
                    btn_save.Location = new Point(155, 221);
                    lbl_yukle.Text = "Belge Yükle:";
                    btnsertifika.Text = "Belge Seç";

                    this.Size = new Size(404, 348);

                }
            }


        }

    }
}
