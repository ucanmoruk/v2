using DevExpress.XtraGrid.Views.Grid;
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
    public partial class CihazListesi : Form
    {
        public CihazListesi()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        private void CihazListesi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                listele();
            }

        }
        private void btn_yenile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listele();
        }
        private void btn_kullanim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (btn_kullanim.Caption == "Kullanıma Al")
            {
                SqlCommand komutSil = new SqlCommand("update RootCihazListesi set Durumu=@a1 where ID = N'" + cID + "' ", bgl.baglanti());
                komutSil.Parameters.AddWithValue("@a1", "Kullanımda");
                komutSil.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Cihaz kullanıma alınmıştır! ", "Ooppss!");

            }
            else
            {
                SqlCommand komutSil = new SqlCommand("update RootCihazListesi set Durumu=@a1 where ID = N'" + cID + "' ", bgl.baglanti());
                komutSil.Parameters.AddWithValue("@a1", "Kullanım Dışı");
                komutSil.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Cihaz kullanım dışı bırakılmıştır! " + "\n" + "Yetkili kullanıcılara bilgi vermeyi unutmayınız!", "Ooppss!");
            }
            listele();

        }
        private void btn_sil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            DialogResult Secim = new DialogResult();

            Secim = MessageBox.Show(cad + " cihazını silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (Secim == DialogResult.Yes)
            {
                SqlCommand komutSil = new SqlCommand("update RootCihazListesi set Durum=@a1 where ID = N'" + cID + "' ", bgl.baglanti());
                komutSil.Parameters.AddWithValue("@a1", "Pasif");
                komutSil.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Cihaz silme işlemi başarılı!", "Ooppss!");
                listele();
            }
            else
            {

            }



        }
        private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);


                if (durumx == "Kullanım Dışı")
                {
                    btn_kullanim.Caption = "Kullanıma Al";
                }
                else
                {

                    btn_kullanim.Caption = "Kullanım Dışı";
                }
            }

        }

        string cID, cad,durumx, kodad;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                durumx = dr["Durumu"].ToString();
                cID = dr["ID"].ToString();
                cad = dr["Cihaz Adı"].ToString();
                kodad = dr["Cihaz Kodu"].ToString() + ' ' + cad;
            }
            catch (Exception)
            {
                // MessageBox.Show("Aradığınız cihaz bulunamadı!", "Oopss!");
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "Tarih" || e.Column.FieldName == "Durumu")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string ODurum = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Durumu"]);
                if (ODurum == "Kullanım Dışı")
                {
                    e.Appearance.BackColor = Color.IndianRed;
                }
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
                btn_sil.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btn_kullanim.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }

        }

        public void listele()
        {
            DataTable dt6 = new DataTable();
            SqlDataAdapter da6 = new SqlDataAdapter("select b.Birim, c.ID, c.Kod as 'Cihaz Kodu', c.Ad as 'Cihaz Adı', c.Marka as 'Marka / Model', c.Seri as 'Seri No' ," +
                "t.Ad as 'Tedarikçi Firma', c.Tarih, c.Durumu from RootCihazListesi c" +
                " inner join RootTedarikci t on c.FirmaID = t.ID inner join RootFirmaBirim b on c.BirimID = b.ID where c.Durum = 'Aktif' order by c.Kod ", bgl.baglanti());
            da6.Fill(dt6);
            gridControl1.DataSource = dt6;
            gridView1.Columns["ID"].Visible = false;

            gridView1.Columns[0].Width = 60;
            gridView1.Columns[2].Width = 35;
            gridView1.Columns[3].Width = 105;
            gridView1.Columns[4].Width = 50;
            gridView1.Columns[5].Width = 50;
            gridView1.Columns[6].Width = 100;

        }


        private void CihazListesi_Load(object sender, EventArgs e)
        {
            listele();
          //  yetkibul();
        }

        private void btn_sicil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CihazEkle.cihazkod = "sicil";
            CihazEkle.cID = cID;
            CihazEkle ce = new CihazEkle();
            ce.Show();
        }

        private void btn_chzbilgi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CihazEkle.cihazkod = "1";
            CihazEkle.cID = cID;
            CihazEkle ce = new CihazEkle();
            ce.Show();
        }

        private void btn_chzkal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //kal güncelle
            CihazEkle.cihazkod = "2";
            CihazEkle.kodad = kodad;
            CihazEkle.cID = cID;
            CihazEkle ce = new CihazEkle();
            ce.Show();
        }



        private void btn_chzanaliz_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CihazEkle.cihazkod = "3";
            CihazEkle.cID = cID;
            CihazEkle.kodad = kodad;
            CihazEkle ce = new CihazEkle();
            ce.Show();
        }



        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CihazHareket.tur = "Bakım";
            CihazHareket.cID = cID;
            CihazHareket ch = new CihazHareket();
            ch.Show();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CihazHareket.tur = "Onarım";
            CihazHareket.cID = cID;
            CihazHareket ch = new CihazHareket();
            ch.Show();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            using (Raporlar.frmPrint frm = new Raporlar.frmPrint())
            {
                frm.CihazEtiket();
                frm.ShowDialog();
            }
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CihazHareket.tur = "Diğer";
            CihazHareket.cID = cID;
            CihazHareket ch = new CihazHareket();
            ch.Show();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string path = "CihazListesi.xlsx";
            gridControl1.ExportToXlsx(path);
            Process.Start(path);

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CihazHareket.tur = "Kalibrasyon";
            CihazHareket.cID = cID;
            CihazHareket ch = new CihazHareket();
            ch.Show();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CihazHareket.tur = "Ara Kontrol";
            CihazHareket.cID = cID;
            CihazHareket ch = new CihazHareket();
            ch.Show();
        }
    }
}
