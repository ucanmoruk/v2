using DevExpress.XtraEditors;
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

namespace mROOT._8.Spektrotek
{
    public partial class STalep : Form
    {
        public STalep()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();


        void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select ID, Ad from RootTedarikci where Kimin <> 'Root' and Durum = 'Aktif'", bgl.baglanti());
            da2.Fill(dt2);

            gridLookUpEdit1.Properties.DataSource = dt2;
            gridLookUpEdit1.Properties.DisplayMember = "Ad";
            gridLookUpEdit1.Properties.ValueMember = "ID";


            DataTable dat2 = new DataTable();
            SqlDataAdapter daa2 = new SqlDataAdapter("select ID, Ad from RootKullanici where (BirimID = 1003 or ID = 2) and Durum = N'Aktif'", bgl.baglanti());
            daa2.Fill(dat2);

            gridLookUpEdit2.Properties.DataSource = dat2;
            gridLookUpEdit2.Properties.DisplayMember = "Ad";
            gridLookUpEdit2.Properties.ValueMember = "ID";


        }
        public static string r1;
        int maxtalep;
        void max()
        {
            SqlCommand komutm = new SqlCommand("select MAX(TalepNo) from STalepListe", bgl.baglanti());
            SqlDataReader drm = komutm.ExecuteReader();
            while (drm.Read())
            {
                r1 = drm[0].ToString();
            }
            bgl.baglanti().Close();

            if (r1 == "" || r1 == null)
            {
                maxtalep = 1;
            }
            else
            {
                maxtalep = Convert.ToInt32(r1)+1;
            }
        }

        public static string talepID, gelis;
        private void STalep_Load(object sender, EventArgs e)
        {
            listele();
            max();
            if (talepID == null || talepID == "")
            {
                t_talepno.Text = maxtalep.ToString();
                combo_durum.Text = "Yeni Talep";
                dateEdit1.EditValue = DateTime.Now;
            }
            else
            {
                detaybul();
                b_kaydet.Text = "Güncelle";
                if (gelis == "Notlar" )
                {
                    xtraTabControl1.SelectedTabPage = xtraTabPage2;
                }
                else
                {
                    
                }
                
            }
        }

        STalepListe m = (STalepListe)System.Windows.Forms.Application.OpenForms["STalepListe"];

        private void b_kaydet_Click(object sender, EventArgs e)
        {
            if (b_kaydet.Text == "Kaydet")
            {
                kaydet();
 
                DialogResult cikis = new DialogResult();
                cikis = MessageBox.Show("Talep ile ilgili not eklemek ister misiniz ?", "Ooppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (cikis == DialogResult.Yes)
                { xtraTabControl1.SelectedTabPage = xtraTabPage2; }
                else
                { this.Close(); }
            }
            else if (b_kaydet.Text == "Güncelle")
            {
                guncelle();
                MessageBox.Show("Güncelleme işlemi başarılı", "Ooopss!", MessageBoxButtons.OK);
            }
            else
            {
                guncelle();
                xtraTabControl1.SelectedTabPage = xtraTabPage2;
            }
            if (Application.OpenForms["STalepListe"] == null)
            {

            }
            else
            {
                m.listele();
            }
        }


        void kaydet()
        {
            SqlCommand add = new SqlCommand(@"insert into STalepListe (TalepNo, Tarih, Onem, Durum, OlusturanID, GenelDurum, Kaynak, FirmaID, Mail, Kategori, Detay, Tur, AtananID, Distributor)
            values (@a1, @a2, @a3, @a4, @a5, @a6, @a7, @a8, @a9, @a10, @a11, @a12, @a13, @a14) SET @ID = SCOPE_IDENTITY()", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", t_talepno.Text);
            add.Parameters.AddWithValue("@a2", dateEdit1.EditValue);
            add.Parameters.AddWithValue("@a3", c_onem.Text);
            add.Parameters.AddWithValue("@a4", "Yeni Talep");
            add.Parameters.AddWithValue("@a5", Anasayfa.kullanici);
            add.Parameters.AddWithValue("@a6", "Aktif");
            add.Parameters.AddWithValue("@a7", t_kaynak.Text);      
            add.Parameters.AddWithValue("@a8", gridLookUpEdit1.EditValue);
            add.Parameters.AddWithValue("@a9", t_mail.Text);
            add.Parameters.AddWithValue("@a10", c_kategori.Text);
            add.Parameters.AddWithValue("@a11", m_detay.Text);
            add.Parameters.AddWithValue("@a12", combo_tur.Text);
            if (String.IsNullOrEmpty(gridLookUpEdit2.EditValue.ToString()))
            {
                add.Parameters.AddWithValue("@a13", 2);
            }
            else
            {
                add.Parameters.AddWithValue("@a13", gridLookUpEdit2.EditValue);
            }
            add.Parameters.AddWithValue("@a14", c_dist.Text);
            add.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
            add.ExecuteNonQuery();
            talepID = add.Parameters["@ID"].Value.ToString();
            bgl.baglanti().Close();

            logkayit();
        }

        void logkayit()
        {
            SqlCommand add = new SqlCommand(@"insert into STalepListeLog (TalepNo, Tarih, Onem, Durum, OlusturanID, GenelDurum, Kaynak, FirmaID, Mail, 
            Kategori, Detay, logtur, logKisiID, logTarih, Tur, AtananID, Distributor)
            values (@a1, @a2, @a3, @a4, @a5, @a6, @a7, @a8, @a9, @a10, @a11, @a12, @a13, @a14, @a15, @a16, @a17 )", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", t_talepno.Text);
            add.Parameters.AddWithValue("@a2", dateEdit1.EditValue);
            add.Parameters.AddWithValue("@a3", c_onem.Text);
            add.Parameters.AddWithValue("@a4", "Yeni Talep");
            add.Parameters.AddWithValue("@a5", Anasayfa.kullanici);
            add.Parameters.AddWithValue("@a6", "Aktif");
            add.Parameters.AddWithValue("@a7", t_kaynak.Text);
            add.Parameters.AddWithValue("@a8", gridLookUpEdit1.EditValue);
            add.Parameters.AddWithValue("@a9", t_mail.Text);
            add.Parameters.AddWithValue("@a10", c_kategori.Text);
            add.Parameters.AddWithValue("@a11", m_detay.Text);
            add.Parameters.AddWithValue("@a12", "Insert");
            add.Parameters.AddWithValue("@a13", Anasayfa.kullanici);
            add.Parameters.AddWithValue("@a14", DateTime.Now);
            add.Parameters.AddWithValue("@a15", combo_tur.Text);
            if (String.IsNullOrEmpty(gridLookUpEdit2.EditValue.ToString()))
            {
                add.Parameters.AddWithValue("@a16", 2);
            }
            else
            {
                add.Parameters.AddWithValue("@a16", gridLookUpEdit2.EditValue);
            }
            add.Parameters.AddWithValue("@a17", c_dist.Text);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        void guncelle()
        {
            SqlCommand add = new SqlCommand("update STalepListe set Onem=@a1, TalepNo=@a2, Kaynak=@a3, FirmaID=@a4, Mail=@a5, Kategori=@a6, Detay=@a7, Tarih=@a8, Tur=@a9, AtananID=@a10, Distributor=@a11  where ID = '" + talepID + "' ", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", c_onem.Text);
            add.Parameters.AddWithValue("@a2", t_talepno.Text);
            add.Parameters.AddWithValue("@a3", t_kaynak.Text);
            add.Parameters.AddWithValue("@a4", gridLookUpEdit1.EditValue);
            add.Parameters.AddWithValue("@a5", t_mail.Text);
            add.Parameters.AddWithValue("@a6", c_kategori.Text);
            add.Parameters.AddWithValue("@a7", m_detay.Text);
            add.Parameters.AddWithValue("@a8", dateEdit1.EditValue);
            add.Parameters.AddWithValue("@a9", combo_tur.Text);
            if (String.IsNullOrEmpty(gridLookUpEdit2.EditValue.ToString()))
            {
                add.Parameters.AddWithValue("@a10", 2);
            }
            else
            {
                add.Parameters.AddWithValue("@a10", gridLookUpEdit2.EditValue);
            }
            add.Parameters.AddWithValue("@a11", c_dist.Text);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();

            logguncelle();
        }

        void logguncelle()
        {
            SqlCommand add = new SqlCommand(@"insert into STalepListeLog (TalepNo, Tarih, Onem, Durum, OlusturanID, GenelDurum, Kaynak, FirmaID, Mail, 
            Kategori, Detay, logtur, logKisiID, logTarih, Tur, AtananID, Distributor)
            values (@a1, @a2, @a3, @a4, @a5, @a6, @a7, @a8, @a9, @a10, @a11, @a12, @a13, @a14, @a15, @a16, @a17)", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", t_talepno.Text);
            add.Parameters.AddWithValue("@a2", dateEdit1.EditValue);
            add.Parameters.AddWithValue("@a3", c_onem.Text);
            add.Parameters.AddWithValue("@a4", "Yeni Talep");
            add.Parameters.AddWithValue("@a5", Anasayfa.kullanici);
            add.Parameters.AddWithValue("@a6", "Aktif");
            add.Parameters.AddWithValue("@a7", t_kaynak.Text);
            add.Parameters.AddWithValue("@a8", gridLookUpEdit1.EditValue);
            add.Parameters.AddWithValue("@a9", t_mail.Text);
            add.Parameters.AddWithValue("@a10", c_kategori.Text);
            add.Parameters.AddWithValue("@a11", m_detay.Text);
            add.Parameters.AddWithValue("@a12", "Update");
            add.Parameters.AddWithValue("@a13", Anasayfa.kullanici);
            add.Parameters.AddWithValue("@a14", DateTime.Now);
            add.Parameters.AddWithValue("@a15", combo_tur.Text);
            if (String.IsNullOrEmpty(gridLookUpEdit2.EditValue.ToString()))
            {
                add.Parameters.AddWithValue("@a16", 2);
            }
            else
            {
                add.Parameters.AddWithValue("@a16", gridLookUpEdit2.EditValue);
            }
            add.Parameters.AddWithValue("@a17", c_dist.Text);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
        }
        
        void notlistele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(@"select n.Tarih, k.Ad, n.Notlar from STalepNot n
            left join RootKullanici k on n.YetkiliID = k.ID
            where TalepID = '" + talepID + "' order by Tarih desc", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;

            this.gridView1.Columns[0].Width = 50;
            this.gridView1.Columns[1].Width = 50;
            this.gridView1.Columns[2].Width = 170;
        }

        private void b_notekle_Click(object sender, EventArgs e)
        {
            //not ekle
            if (talepID == "" ||talepID == null)
            {
                MessageBox.Show("Lütfen önce talep seçin veya yeni talep oluşturun!", "Opps!", MessageBoxButtons.OK);
            }
            else
            {
                SqlCommand add = new SqlCommand(@"insert into STalepNot (TalepID, Notlar, Tarih, YetkiliID)
                 values (@a1, @a2, @a3, @a4)", bgl.baglanti());
                add.Parameters.AddWithValue("@a1", talepID);
                add.Parameters.AddWithValue("@a2", t_not.Text);
                add.Parameters.AddWithValue("@a3", DateTime.Now);
                add.Parameters.AddWithValue("@a4", Anasayfa.kullanici);
                add.ExecuteNonQuery();
                bgl.baglanti().Close();
                talepguncelle();
                notlistele();
            }
        }

        void detaybul()
        {
            SqlCommand komutID = new SqlCommand("Select * From STalepListe where ID= N'" + talepID + "'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                c_onem.Text = drI["Onem"].ToString();
                combo_durum.Text = drI["Durum"].ToString();
                t_talepno.Text = drI["TalepNo"].ToString();
                dateEdit1.EditValue = Convert.ToDateTime(drI["Tarih"].ToString());
                c_kategori.Text = drI["Kategori"].ToString();
                t_kaynak.Text = drI["Kaynak"].ToString();
                gridLookUpEdit1.EditValue = drI["FirmaID"].ToString();
                t_mail.Text = drI["Mail"].ToString();
                m_detay.Text = drI["Detay"].ToString();
                combo_tur.Text = drI["Tur"].ToString();
                gridLookUpEdit2.EditValue = drI["AtananID"].ToString();
                c_dist.Text = drI["Distributor"].ToString();
            }
            bgl.baglanti().Close();
            notlistele();
        }

        private void STalep_FormClosed(object sender, FormClosedEventArgs e)
        {
            talepID = null;
        }

        private void gridLookUpEdit2_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        private void gridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        void talepguncelle()
        {
            try
            {
                SqlCommand add2 = new SqlCommand("update STalepListe set Durum=@a1 where ID = '" + talepID + "' ", bgl.baglanti());
                add2.Parameters.AddWithValue("@a1", combo_durum.Text);
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();

                SqlCommand add = new SqlCommand(@"insert into STalepListeLog (TalepNo, Durum, logtur, logKisiID, logTarih)
                    values (@a1, @a2,  @a4, @a5, @a6)", bgl.baglanti());
                add.Parameters.AddWithValue("@a1", talepID);
                add.Parameters.AddWithValue("@a2", combo_durum.Text);
                add.Parameters.AddWithValue("@a4", "Not Eklendi");
                add.Parameters.AddWithValue("@a5", Anasayfa.kullanici);
                add.Parameters.AddWithValue("@a6", DateTime.Now);
                add.ExecuteNonQuery();
                bgl.baglanti().Close();

                listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata 2:" + ex);
            }
        }

    }
}
