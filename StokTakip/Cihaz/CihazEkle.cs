using DevExpress.XtraEditors;
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

namespace StokTakip.Cihaz
{
    public partial class CihazEkle : Form
    {
        public CihazEkle()
        {
            InitializeComponent();
        }

        private void gridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;

        }

        private void gridLookUpEdit3_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        private void gridLookUpEdit4_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        private void gridLookUpEdit2_Properties_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        private void gridLookUpEdit3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GridLookUpEdit edit = sender as GridLookUpEdit;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Close)
            {
                gridLookUpEdit3.EditValue = null;
            }

        }

        private void gridLookUpEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GridLookUpEdit edit = sender as GridLookUpEdit;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                gridLookUpEdit1.EditValue = null;

            }
        }

        private void gridLookUpEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GridLookUpEdit edit = sender as GridLookUpEdit;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                gridLookUpEdit2.EditValue = null;

            }

        }

        private void gridLookUpEdit4_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GridLookUpEdit edit = sender as GridLookUpEdit;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                gridLookUpEdit4.EditValue = null;

            }
        }

        private void tabPane1_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {
            if (tabPane1.SelectedPage == tabNavigationPage1)
            {
                Size = new Size(525, 417);
                this.CenterToScreen();
            }
            else
            {
                Size = new Size(977, 417);
                this.CenterToScreen();
            }
        }

        string tedarikciID, birimID, talimatID, kaynakID;
        private void gridLookUpEdit3_EditValueChanged(object sender, EventArgs e)
        {

            if (gridLookUpEdit3.EditValue == null)
                tedarikciID = null;
            else
                tedarikciID = gridLookUpEdit3.EditValue.ToString();


            if (gridLookUpEdit4.EditValue == null)
                talimatID = null;
            else
                talimatID = gridLookUpEdit4.EditValue.ToString();


            if (gridLookUpEdit1.EditValue == null)
                birimID = null;
            else
                birimID = gridLookUpEdit1.EditValue.ToString();

            if (gridLookUpEdit2.EditValue == null)
                kaynakID = null;
            else
                kaynakID = gridLookUpEdit2.EditValue.ToString();

        }

        sqlbaglanti bgl = new sqlbaglanti();

        void listele()
        {

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select ID, Birim from StokFirmaBirim where Durum= 'Aktif'", bgl.baglanti());
            da2.Fill(dt2);

            gridLookUpEdit1.Properties.DataSource = dt2;
            gridLookUpEdit1.Properties.DisplayMember = "Birim";
            gridLookUpEdit1.Properties.ValueMember = "ID";


            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID, Ad from StokTedarikci where Durum= 'Aktif'", bgl.baglanti());
            da.Fill(dt);

            gridLookUpEdit3.Properties.DataSource = dt;
            gridLookUpEdit3.Properties.DisplayMember = "Ad";
            gridLookUpEdit3.Properties.ValueMember = "ID";

            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("select ID, Kod, Ad from DokumanMaster where Tur = 'Kullanım Talimatı' and Durum = 'Aktif'", bgl.baglanti());
            da3.Fill(dt3);

            gridLookUpEdit4.Properties.DataSource = dt3;
            gridLookUpEdit4.Properties.DisplayMember = "Ad";
            gridLookUpEdit4.Properties.ValueMember = "ID";

            DataTable dt4 = new DataTable();
            SqlDataAdapter da4 = new SqlDataAdapter("Select ID, Kod, Ad from StokDKDListe where Durum= 'Aktif'", bgl.baglanti());
            da4.Fill(dt4);

            gridLookUpEdit2.Properties.DataSource = dt4;
            gridLookUpEdit2.Properties.DisplayMember = "Ad";
            gridLookUpEdit2.Properties.ValueMember = "ID";

            DataTable dt5 = new DataTable();
            SqlDataAdapter da5 = new SqlDataAdapter("select ID, Ad + ' ' + Soyad as 'Personel' from StokKullanici where Durum= 'Aktif'", bgl.baglanti());
            da5.Fill(dt5);
            gridControl1.DataSource = dt5;
            gridView2.Columns["ID"].Visible = false;

            DataTable dt6 = new DataTable();
            SqlDataAdapter da6 = new SqlDataAdapter("select ID, Kod, Ad from StokAnalizListesi where Durumu = 'Aktif'", bgl.baglanti());
            da6.Fill(dt6);
            gridControl2.DataSource = dt6;
            gridView3.Columns["ID"].Visible = false;
            gridView3.Columns["Kod"].Width = 20;

        }

        void listele2()
        {
            DataTable dt6 = new DataTable();
            SqlDataAdapter da6 = new SqlDataAdapter("select Ad+ ' ' + Soyad as 'Personel' from StokKullanici where ID in (Select PersonelID from CihazYetkili where CihazID = '"+lbl_ycID.Text+"' )", bgl.baglanti());
            da6.Fill(dt6);
            gridControl3.DataSource = dt6;
        }

        void listele3()
        {
            DataTable dt7 = new DataTable();
            SqlDataAdapter da7 = new SqlDataAdapter(" select Kod, Ad from StokAnalizListesi where ID in (Select AnalizID from CihazAnaliz where CihazID = '" + lbl_ycID.Text + "' )", bgl.baglanti());
            da7.Fill(dt7);
            gridControl4.DataSource = dt7;
            this.gridView1.Columns[0].Width = 30;
        }

        void detaybul()
        {
            if (cihazkod == "1")
            {
                // ichaz bilgileiri
                 
                //SqlCommand komutID = new SqlCommand("Select * From Cihaz where Ad= N'" + txt_ad.Text + "'", bgl.baglanti());
                //SqlDataReader drI = komutID.ExecuteReader();
                //while (drI.Read())
                //{
                //    ID = Convert.ToInt32(drI["ID"].ToString());
                //    ek = drI["Ek"].ToString();
                //}
                //bgl.baglanti().Close();

            }
            else if (cihazkod == "2")
            {
                // kal. bilgileri
            }
            else
            {
                // yetkili bilgileri
            }
        }


        public static string cihazkod, cID;
        private void CihazEkle_Load(object sender, EventArgs e)
        {
       

            if (cihazkod == "" || cihazkod == null)
            {
                listele();
                Size = new Size(525, 417);
                this.CenterToScreen();

            }
            else if (cihazkod == "1")
            {
                lbl_ycID.Text = cID;
                btn_ekle.Text = "Güncelle";
                listele();
                Size = new Size(525, 417);
                this.CenterToScreen();
                tabPane1.SelectedPage = tabNavigationPage1;
                tabNavigationPage2.PageVisible = false;
                tabNavigationPage4.PageVisible = false;
                detaybul();
            }
            else if (cihazkod == "2")
            {
                lbl_ycID.Text = cID;
                btn_kalkayit.Text = "Güncelle";
                listele();
                Size = new Size(977, 417);
                this.CenterToScreen();
                tabPane1.SelectedPage = tabNavigationPage2;
                tabNavigationPage1.PageVisible = false;
                tabNavigationPage4.PageVisible = false;
                detaybul();
            }
            else
            {
                lbl_ycID.Text = cID;
                listele2();
                listele3();
                Size = new Size(977, 417);
                this.CenterToScreen();
                tabPane1.SelectedPage = tabNavigationPage4;
                tabNavigationPage1.PageVisible = false;
                tabNavigationPage2.PageVisible = false;
                btn_yeni.Visible = false;
                detaybul();
            }
        }

        private void CihazEkle_FormClosed(object sender, FormClosedEventArgs e)
        {
            cihazkod = "";
        }

      
        void ekleme()
        {

            if (txt_kod.Text == null || txt_kod.Text == "")
            {
                MessageBox.Show("Lütfen cihaz kodunu giriniz!", "Oopss");
            }
            else
            {
                SqlCommand add = new SqlCommand(" insert into CihazListesi (Kod, Ad, Marka, Seri, FirmaID, BirimID, TalimatID, Tarih, Ozellik,Durumu,Durum) values (@a1, @a2, @a3, @a4, @a5, @a6,@a7,@a8,@a9,@a10,@a11) SET @ID = SCOPE_IDENTITY() ", bgl.baglanti());
                add.Parameters.AddWithValue("@a1", txt_kod.Text);
                add.Parameters.AddWithValue("@a2", txt_ad.Text);
                add.Parameters.AddWithValue("@a3", txt_marka.Text);
                add.Parameters.AddWithValue("@a4", txt_seri.Text);
                if (String.IsNullOrEmpty(tedarikciID))
                {
                    add.Parameters.AddWithValue("@a5", DBNull.Value);
                }
                else
                {
                    add.Parameters.AddWithValue("@a5", tedarikciID);
                }
                if (String.IsNullOrEmpty(birimID))
                {
                    add.Parameters.AddWithValue("@a6", DBNull.Value);
                }
                else
                {
                    add.Parameters.AddWithValue("@a6", birimID);
                }
                if (String.IsNullOrEmpty(talimatID))
                {
                    add.Parameters.AddWithValue("@a7", DBNull.Value);
                }
                else
                {
                    add.Parameters.AddWithValue("@a7", talimatID);
                }
                add.Parameters.AddWithValue("@a8", txt_tarih.Text);
                add.Parameters.AddWithValue("@a9", txt_ozellik.Text);
                add.Parameters.AddWithValue("@a10", combo_durum.Text);
                add.Parameters.AddWithValue("@a11", "Aktif");
                add.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                add.ExecuteNonQuery();
                lbl_ycID.Text = add.Parameters["@ID"].Value.ToString();
                bgl.baglanti().Close();

                DialogResult cikis = new DialogResult();
                cikis = MessageBox.Show("Cihaz ekleme işlemi başarılı!" + "\n" + "\n" + "Cihaz ile ilgili kalibrasyon, bakım gibi diğer özellikleri eklemek istiyor musunuz ?" + "\n" + "\n" + "Unutmayın bu özellikleri sonra da güncelleyebilirsiniz!", "Ooppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (cikis == DialogResult.Yes)
                { tabPane1.SelectedPage = tabNavigationPage2; }
                else
                { temizle(); }

            }
           
        }

        void eklekal()
        {
            SqlCommand add = new SqlCommand("insert into CihazKalibrasyon (CihazID, KalTip, KalSiklik, AraSiklik, Calisma,Kalibrasyon,Kaynak,KabulKriteri) values (@a1, @a2, @a3, @a4, @a5, @a6,@a7,@a8) ; " +
                " insert into CihazBakim (CihazID, PfSiklik, PfDetay, BakimSiklik,BakimDetay) values (@o1, @o2, @o3, @o4, @o5) ", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", lbl_ycID.Text);
            add.Parameters.AddWithValue("@a2", kal_tip.Text);
            add.Parameters.AddWithValue("@a3", kal_siklik.Text);
            add.Parameters.AddWithValue("@a4", ara_siklik.Text);
            add.Parameters.AddWithValue("@a5", kal_aralik.Text);
            add.Parameters.AddWithValue("@a6", kal_aralik.Text);
            if (String.IsNullOrEmpty(kaynakID))
            {
                add.Parameters.AddWithValue("@a7", DBNull.Value);
            }
            else
            {
                add.Parameters.AddWithValue("@a7", kaynakID);
            }
                
            add.Parameters.AddWithValue("@a8", kal_kabul.Text);
            add.Parameters.AddWithValue("@o1", lbl_ycID.Text);
            add.Parameters.AddWithValue("@o2", pf_siklik.Text);
            add.Parameters.AddWithValue("@o3", pf_detay.Text);
            add.Parameters.AddWithValue("@o4", bkm_siklik.Text);
            add.Parameters.AddWithValue("@o5", bkm_detay.Text);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        void temizle()
        {
            lbl_ycID.Text = "";
            txt_ad.Text = "";
            txt_kod.Text = "";
            txt_marka.Text = "";
            txt_ozellik.Text = "";
            txt_seri.Text = "";
            txt_tarih.Text = "";
            gridLookUpEdit1.EditValue = null;
            gridLookUpEdit3.EditValue = null;
            gridLookUpEdit4.EditValue = null;
            gridLookUpEdit2.EditValue = null;
            lbl_ycID.Text = "";
            kal_tip.Text = "";
            kal_siklik.Text = "";
            ara_siklik.Text = "";
            kal_aralik.Text = "";
            kal_aralik.Text = "";
            kal_kabul.Text = "";
            pf_siklik.Text = "";
            pf_detay.Text = "";
            bkm_detay.Text = "";
            bkm_siklik.Text = "";

        }

        string pID, aID;
        private void btn_aktary_Click(object sender, EventArgs e)
        {

            if (lbl_ycID.Text == "" || lbl_ycID.Text == null)
            {
                MessageBox.Show("Lütfen öncelikle 'Cihaz Bilgileri' sayfasından cihazın temel bilgilerini doldurarak kaydediniz!", "Ooopsss!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                SqlCommand ad = new SqlCommand("delete from CihazYetkili where CihazID = '" + lbl_ycID.Text + "' ", bgl.baglanti());
                ad.ExecuteNonQuery();
                bgl.baglanti().Close();

                for (int i = 0; i < gridView2.SelectedRowsCount; i++)
                {
                    int y = Convert.ToInt32(gridView2.GetSelectedRows()[i].ToString());
                    pID = gridView2.GetRowCellValue(y, "ID").ToString();
                    SqlCommand add = new SqlCommand("insert into CihazYetkili (CihazID, PersonelID) values (@a1, @a2) ", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", lbl_ycID.Text);
                    add.Parameters.AddWithValue("@a2", pID);
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }

                listele2();

            }



        }

        private void btn_yeni_Click(object sender, EventArgs e)
        {
            tabPane1.SelectedPage = tabNavigationPage1;
            temizle();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (lbl_ycID.Text == "" || lbl_ycID.Text == null)
            {
                MessageBox.Show("Lütfen öncelikle 'Cihaz Bilgileri' sayfasından cihazın temel bilgilerini doldurarak kaydediniz!", "Ooopsss!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                SqlCommand ad = new SqlCommand("delete from CihazAnaliz where CihazID = '" + lbl_ycID.Text + "' ", bgl.baglanti());
                ad.ExecuteNonQuery();
                bgl.baglanti().Close();

                for (int i = 0; i < gridView3.SelectedRowsCount; i++)
                {
                    int y = Convert.ToInt32(gridView3.GetSelectedRows()[i].ToString());
                    aID = gridView2.GetRowCellValue(y, "ID").ToString();
                    SqlCommand add = new SqlCommand("insert into CihazAnaliz (CihazID, AnalizID) values (@a1, @a2) ", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", lbl_ycID.Text);
                    add.Parameters.AddWithValue("@a2", aID);
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }

                listele3();
            }


          
        }

        CihazListesi m = (CihazListesi)System.Windows.Forms.Application.OpenForms["CihazListesi"];

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            try
            {
                ekleme();

                if (Application.OpenForms["CihazListesi"] == null)
                {

                }
                else
                {
                    m.listele();
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show("Hata CE 121: " + Ex);
            }          

        }

        private void btn_kalkayit_Click(object sender, EventArgs e)
        {
            if (lbl_ycID.Text == "" || lbl_ycID.Text == null)
            {
                MessageBox.Show("Lütfen öncelikle 'Cihaz Bilgileri' sayfasından cihazın temel bilgilerini doldurarak kaydediniz!", "Ooopsss!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                eklekal();
                tabPane1.SelectedPage = tabNavigationPage4;
            }
           

        }

   





    }
}
