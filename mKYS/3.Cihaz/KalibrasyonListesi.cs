using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mKYS.Cihaz
{
    public partial class KalibrasyonListesi : Form
    {
        public KalibrasyonListesi()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt7 = new DataTable();
            //SqlDataAdapter da7 = new SqlDataAdapter(@"select i.ID, c.Kod, c.Ad as 'Cihaz Adı', i.Tur as 'İşlem Türü', a.KalTip as 'Kalibrasyon Tipi', 
            //i.Tarih1 as 'Kalibrasyon Tarihi', i.Tarih2 as 'Planlanan Tarih', 
            //case i.Finout when 'i' then k.Ad + ' ' +k.Soyad  when 'o' then t.Ad end as 'Son Uygulamayı Yapan',
            //c.ID as 'cID' from CihazListesi c 
            //left join CihazIslem i on c.ID = i.CihazID 
            //left join StokTedarikci t on i.FirmaID = t.ID 
            //left join StokKullanici k on i.PersonelID = k.ID 
            //left join CihazKalibrasyon a on c.ID = a.CihazID 
            //where c.Durumu = 'Kullanımda' and i.Durum ='Aktif' and i.Tur = 'Kalibrasyon' or i.Tur = 'Ara Kontrol'  order by c.Kod", bgl.baglanti());

            SqlDataAdapter da7 = new SqlDataAdapter(@"select distinct i.ID, i.CihazID as 'cID', l.Kod, l.Ad as 'Cihaz Adı',  i.Tur  as 'İşlem Türü', k.KalTip as 'Kalibrasyon Tipi', 
            i.Tarih1 as 'Kalibrasyon Tarihi', i.Tarih2 as 'Planlanan Tarihi' 
            , case i.Finout when 'i' then a.Ad + ' ' +a.Soyad  when 'o' then t.Ad end as 'Son Uygulamayı Yapan' 
            from RootCihazIslem i 
            inner join (select CihazID, Tur, MAX(Tarih1) as MaxDate from RootCihazIslem group by CihazID, Tur) i2 on i.CihazID = i2.CihazID and i.Tarih1 = i2.MaxDate
            inner join RootCihazKalibrasyon k on i.CihazID = k.CihazID
            inner join RootCihazListesi l on i.CihazID = l.ID
            left join RootTedarikci t on i.FirmaID = t.ID
            left join RootKullanici a on i.PersonelID = a.ID
            where l.Durumu = 'Kullanımda' and i.Durum ='Aktif' and i.Tur = 'Kalibrasyon' or i.Tur = 'Ara Kontrol'
            order by i.CihazID", bgl.baglanti());
            da7.Fill(dt7);
            gridControl1.DataSource = dt7;
            gridView1.Columns["ID"].Visible = false;
            gridView1.Columns["cID"].Visible = false;

            this.gridView1.Columns[2].Width = 30;
            this.gridView1.Columns[8].Width = 150;
        }


        private void KalibrasyonListesi_Load(object sender, EventArgs e)
        {
            listele();
          //  yetkibul();
        }

        private void KalibrasyonListesi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                listele();
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

        int yetki;
        void yetkibul()
        {
            SqlCommand komut21 = new SqlCommand("Select * from KaliteYetki where Gorev = N'" + Anasayfa.gorev + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                yetki = Convert.ToInt32(dr21["Cihaz"]);
            }
            bgl.baglanti().Close();

            if (yetki == 0 || yetki.ToString() == null)
            {
            }
            else
            {
                barButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }

        }

        string Tur, cID, kod, yol, ad, iID, kodad;

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SqlCommand komut21 = new SqlCommand("Select * from RootCihazIslem where ID = N'" + iID + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                yol = dr21["Path"].ToString();
                ad = dr21["Tur"].ToString() + " Belgesi";
            }
            bgl.baglanti().Close();

            if (yol == "" || yol == null)
            {
                MessageBox.Show("Bu işlem için henüz belge yüklenmemiştir!", "Ooopss!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                SertifikaGoruntule.ad = ad;
                SertifikaGoruntule.yol = yol;
                SertifikaGoruntule sg = new SertifikaGoruntule();
                sg.Show();

            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CihazHareket.gelis = "Güncelle";
            CihazHareket.tur = Tur;
            CihazHareket.cID = iID;
            CihazHareket ce = new CihazHareket();
            ce.Show();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string path = "KalibrasyonListesi.xlsx";
            gridControl1.ExportToXlsx(path);
            Process.Start(path);

        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
        //    string total = gridView1.GetRowCellValue(e.RowHandle, "Planlanan Tarih").ToString();
            //GridFormatRule gridFormatRule = new GridFormatRule();

            //FormatConditionRuleDataBar formatConditionRuleDataBar = new FormatConditionRuleDataBar();
            //gridFormatRule.Column = gridView1.Columns["Planlanan Tarih"];
            ////formatConditionRuleDataBar.PredefinedName = "Raspberry Data Bar";
            //formatConditionRuleDataBar.PredefinedName = "Orange Gradient";
            //gridFormatRule.Rule = formatConditionRuleDataBar;
            //gridView1.FormatRules.Add(gridFormatRule);




        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listele();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show(kodad + " cihazına ait " +Tur + " işlemini silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (Secim == DialogResult.Yes)
                {
                    // SqlCommand komutSil = new SqlCommand("delete from Firma where ID = @p1", bgl.baglanti());
                    SqlCommand komutSil = new SqlCommand("update RootCihazIslem set Durum=@a1 where ID = N'" + iID + "'", bgl.baglanti());
                    komutSil.Parameters.AddWithValue("@a1", "Pasif");
                    komutSil.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Silme işlemi başarılı!", "Oooppss!");
                    listele();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata2 : " + ex.Message);
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CihazEkle.cihazkod = "2";
            CihazEkle.cID = cID;
            CihazEkle.kodad = kodad;
            CihazEkle ce = new CihazEkle();
            ce.Show();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            Tur = dr["İşlem Türü"].ToString();
            cID = dr["cID"].ToString();
            kod = dr["Kod"].ToString();
            iID = dr["ID"].ToString();
            kodad = kod + ' ' + dr["Cihaz Adı"].ToString();      

        }
    }
}
