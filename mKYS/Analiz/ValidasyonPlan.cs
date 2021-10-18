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

namespace mKYS.Analiz
{
    public partial class ValidasyonPlan : Form
    {
        public ValidasyonPlan()
        {
            InitializeComponent();
        }


        sqlbaglanti bgl = new sqlbaglanti();

        void listele()
        {
            DataTable dt5 = new DataTable();
            SqlDataAdapter da5 = new SqlDataAdapter("select ID, Kod + ' ' + Ad as 'Analiz' from StokAnalizListesi where Durumu= 'Aktif'", bgl.baglanti());
            da5.Fill(dt5);
            gridLookUpEdit1.Properties.DataSource = dt5;
            gridLookUpEdit1.Properties.DisplayMember = "Analiz";
            gridLookUpEdit1.Properties.ValueMember = "ID";

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select ID, Ad + ' ' + Soyad as 'Personel' from StokKullanici where Durum= 'Aktif'", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView2.Columns["ID"].Visible = false;
        }

        void listele2()
        {
            DataTable dt6 = new DataTable();
            SqlDataAdapter da6 = new SqlDataAdapter("select Ad+ ' ' + Soyad as 'Personel' from StokKullanici where ID in (Select PersonelID from ValidasyonYetkili where AnalizID = '" + gridLookUpEdit1.EditValue + "' and Durum = 'Plan' )", bgl.baglanti());
            da6.Fill(dt6);
            gridControl3.DataSource = dt6;
        }

        int o2;
        void kontrol()
        {
            SqlCommand komut2 = new SqlCommand("Select Count(ID) from ValidasyonVeri where AnalizID = N'" + gridLookUpEdit1.EditValue + "' and Durum = 'Plan'", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                o2 = Convert.ToInt32(dr2[0]);
            }
            bgl.baglanti().Close();
        }

        void detaybul()
        {

            SqlCommand komutID = new SqlCommand("select d.Kod + ' ' + d.Ad as 'Metot', v.Tarih1, v.Tarih2,  v.Urun, v.Aciklama from  ValidasyonVeri v " +
                " inner join StokAnalizListesi s on v.AnalizID = s.ID inner join StokDKDListe d on s.Metot = d.ID where v.AnalizID= N'" + gridLookUpEdit1.EditValue + "' and v.Durumu = 'Planlandı'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                txt_kaynak.Text = drI[0].ToString();
                dateEdit1.EditValue = Convert.ToDateTime(drI[1].ToString());
                dateEdit2.EditValue = Convert.ToDateTime(drI[2].ToString());
                txt_urun.Text = drI[3].ToString();
                txt_aciklama.Text = drI[4].ToString();

            }
            bgl.baglanti().Close();
        }

        void temizle()
        {
            dateEdit1.EditValue = null;
            dateEdit2.EditValue = null;
            txt_urun.Text = null;
            txt_aciklama.Text = null;
            txt_kaynak.Text = null;
            gridControl3.DataSource = null;
            gridView6.Columns.Clear();
        }

        void ekleme()
        {
            if (dateEdit1.EditValue == null || dateEdit2.EditValue == null)
            {
                MessageBox.Show("Lütfen validasyon tarihlerini seçiniz!", "Ooopss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                kontrol();
                if (o2 == 0)
                {
                    SqlCommand add = new SqlCommand("insert into ValidasyonVeri (AnalizID, Urun, Tarih1, Tarih2, Aciklama, Durum, Durumu) values (@a1, @a2, @a3, @a4, @a10,@a11,@a12) ", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", gridLookUpEdit1.EditValue);
                    add.Parameters.AddWithValue("@a2", txt_urun.Text);
                    add.Parameters.AddWithValue("@a3", dateEdit1.EditValue);
                    add.Parameters.AddWithValue("@a4", dateEdit2.EditValue);
                    add.Parameters.AddWithValue("@a10", txt_aciklama.Text);
                    add.Parameters.AddWithValue("@a11", "Plan");
                    add.Parameters.AddWithValue("@a12", "Planlandı");
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    MessageBox.Show("Validasyon planı başarıyla oluşturulmuştur!", "Oooppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    DialogResult cikis = new DialogResult();
                    cikis = MessageBox.Show("Seçtiğiniz analizin validasyon planını güncellemek mi istiyorsunuz ?", "Ooppss!!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (cikis == DialogResult.Yes)
                    {
                        SqlCommand add = new SqlCommand("update ValidasyonVeri set Urun=@a1, Tarih1=@a2, Tarih2=@a3, Aciklama =@a4 where AnalizID = '" + gridLookUpEdit1.EditValue + "' and Durum = 'Plan' ", bgl.baglanti());
                        add.Parameters.AddWithValue("@a1", txt_urun.Text);
                        add.Parameters.AddWithValue("@a2", dateEdit1.EditValue);
                        add.Parameters.AddWithValue("@a3", dateEdit2.EditValue);
                        add.Parameters.AddWithValue("@a4", txt_aciklama.Text);
                        add.ExecuteNonQuery();
                        bgl.baglanti().Close();

                        MessageBox.Show("Başarıyla güncellenmiştir!", "Ooppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    }

                }

            }
        }

        void kaynakbul()
        {
            SqlCommand komutID = new SqlCommand("select Kod +' - '+ Ad as Metot from StokDKDListe where ID in (select Metot from StokAnalizListesi where ID = '"+gridLookUpEdit1.EditValue+"')", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                txt_kaynak.Text = drI[0].ToString();

            }
            bgl.baglanti().Close();
        }

        private void ValidasyonPlan_Load(object sender, EventArgs e)
        {
            listele();

        }

        private void gridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        private void gridLookUpEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GridLookUpEdit edit = sender as GridLookUpEdit;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                gridLookUpEdit1.EditValue = null;

            }
        }

        private void gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            kontrol();

            if (o2 == 0)
            {
                temizle();
                kaynakbul();
                btn_save.Text = "Kaydet";
            }
            else
            {
                temizle();
                detaybul();
                kaynakbul();
                listele2();
                btn_save.Text = "Güncelle";
            }
        }

        ValidasyonPlanListesi m = (ValidasyonPlanListesi)System.Windows.Forms.Application.OpenForms["ValidasyonPlanListesi"];

        private void btn_save_Click(object sender, EventArgs e)
        {
            ekleme();

            if (Application.OpenForms["ValidasyonPlanListesi"] == null)
            {

            }
            else
            {
                m.listele();
            }
        }

        string pID;
        private void btn_aktary_Click(object sender, EventArgs e)
        {
            SqlCommand ad = new SqlCommand("delete from ValidasyonYetkili where AnalizID = '" + gridLookUpEdit1.EditValue + "' and Durum = 'Plan' ", bgl.baglanti());
            ad.ExecuteNonQuery();
            bgl.baglanti().Close();

            if (gridLookUpEdit1.EditValue == null)
            {
                MessageBox.Show("Lütfen öncelikle analiz seçimi yapınız!", "Ooopss!", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);

            }
            else
            {
                for (int i = 0; i < gridView2.SelectedRowsCount; i++)
                {
                    int y = Convert.ToInt32(gridView2.GetSelectedRows()[i].ToString());
                    pID = gridView2.GetRowCellValue(y, "ID").ToString();
                    SqlCommand add = new SqlCommand("insert into ValidasyonYetkili (AnalizID, PersonelID, Durum) values (@a1, @a2, @a3) ", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", gridLookUpEdit1.EditValue);
                    add.Parameters.AddWithValue("@a2", pID);
                    add.Parameters.AddWithValue("@a3", "Plan");
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }
            }

     

            listele2();
        }
    }
}
