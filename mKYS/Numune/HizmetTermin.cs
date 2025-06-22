using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Menu;
using mKYS.Musteri;
using mKYS.Numune;
using mKYS.Raporlar;
using System.Diagnostics;

namespace mKYS.Numune
{
    public partial class HizmetTermin : Form
    {
        public HizmetTermin()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();

        private void button_getir_Click(object sender, EventArgs e)
        {
            NumuneKabul f1 = new NumuneKabul();
            f1.Show();
        }


        public void listele()
        {
            if (Anasayfa.kullanici == "3")
            {
                DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(@"SELECT n.Evrak_No AS [Evrak No], n.RaporNo AS [Rapor No], 
                f.Ad AS Firma, p.Ad AS Proje, n.Numune_Adi AS Numune, l.Kod,
                l.Ad AS Hizmet, l.Method, n.Tarih AS Kabul, x.Termin, 
                x.HizmetDurum AS Durum, n.Rapor_Durumu AS Rapor, k.Ad AS Yetkili, x.ID, n.ID AS nID
                FROM dbo.NumuneX1 AS x LEFT OUTER JOIN
                 dbo.NKR AS n ON x.RaporID = n.ID LEFT OUTER JOIN
                 dbo.NumuneDetay AS d ON n.ID = d.RaporID LEFT OUTER JOIN
                 dbo.RootKullanici AS k ON x.Yetkili = k.ID LEFT OUTER JOIN
                 dbo.RootTedarikci AS f ON n.Firma_ID = f.ID LEFT OUTER JOIN
                 dbo.RootTedarikci AS p ON d.ProjeID = p.ID LEFT OUTER JOIN
                 dbo.StokAnalizListesi AS l ON x.AnalizID = l.ID
                 WHERE n.Durum = 'Aktif' and (x.HizmetDurum <> 'Tamamlandı' and x.HizmetDurum<> 'Reddedildi') and k.ID =3
                 ORDER BY x.Termin desc, nID DESC", bgl.baglanti());
                da.Fill(dt);
                gridControl1.DataSource = dt;
                gridView3.Columns["ID"].Visible = false;
                // gridView3.Columns["Firma"].Visible = false;
                gridView3.Columns["Proje"].Visible = false;
                gridView3.Columns["nID"].Visible = false;
                gridView3.Columns["Rapor"].Visible = false;
            }
            else if (Anasayfa.kullanici == "2009")
            {
                DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(@"SELECT n.Evrak_No AS [Evrak No], n.RaporNo AS [Rapor No], 
                f.Ad AS Firma, p.Ad AS Proje, n.Numune_Adi AS Numune, l.Kod,
                l.Ad AS Hizmet, l.Method, n.Tarih AS Kabul, x.Termin, 
                x.HizmetDurum AS Durum, n.Rapor_Durumu AS Rapor, k.Ad AS Yetkili, x.ID, n.ID AS nID
                FROM dbo.NumuneX1 AS x LEFT OUTER JOIN
                 dbo.NKR AS n ON x.RaporID = n.ID LEFT OUTER JOIN
                 dbo.NumuneDetay AS d ON n.ID = d.RaporID LEFT OUTER JOIN
                 dbo.RootKullanici AS k ON x.Yetkili = k.ID LEFT OUTER JOIN
                 dbo.RootTedarikci AS f ON n.Firma_ID = f.ID LEFT OUTER JOIN
                 dbo.RootTedarikci AS p ON d.ProjeID = p.ID LEFT OUTER JOIN
                 dbo.StokAnalizListesi AS l ON x.AnalizID = l.ID
                 WHERE n.Durum = 'Aktif' and (x.HizmetDurum <> 'Tamamlandı' and x.HizmetDurum<> 'Reddedildi') and k.ID =2009
                 ORDER BY x.Termin desc, nID DESC", bgl.baglanti());
                da.Fill(dt);
                gridControl1.DataSource = dt;
                gridView3.Columns["ID"].Visible = false;
                // gridView3.Columns["Firma"].Visible = false;
                gridView3.Columns["Proje"].Visible = false;
                gridView3.Columns["nID"].Visible = false;
                gridView3.Columns["Rapor"].Visible = false;
            }
            else
            {
                DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(@"SELECT n.Evrak_No AS [Evrak No], n.RaporNo AS [Rapor No], 
                f.Ad AS Firma, p.Ad AS Proje, n.Numune_Adi AS Numune, l.Kod,
                l.Ad AS Hizmet, l.Method, n.Tarih AS Kabul, x.Termin, 
                x.HizmetDurum AS Durum, n.Rapor_Durumu AS Rapor, k.Ad AS Yetkili, x.ID, n.ID AS nID
                FROM dbo.NumuneX1 AS x LEFT OUTER JOIN
                 dbo.NKR AS n ON x.RaporID = n.ID LEFT OUTER JOIN
                 dbo.NumuneDetay AS d ON n.ID = d.RaporID LEFT OUTER JOIN
                 dbo.RootKullanici AS k ON x.Yetkili = k.ID LEFT OUTER JOIN
                 dbo.RootTedarikci AS f ON n.Firma_ID = f.ID LEFT OUTER JOIN
                 dbo.RootTedarikci AS p ON d.ProjeID = p.ID LEFT OUTER JOIN
                 dbo.StokAnalizListesi AS l ON x.AnalizID = l.ID
                 WHERE n.Durum = 'Aktif' and (x.HizmetDurum <> 'Tamamlandı' and x.HizmetDurum<> 'Reddedildi')
                 ORDER BY x.Termin desc, nID DESC", bgl.baglanti());
                da.Fill(dt);
                gridControl1.DataSource = dt;
                gridView3.Columns["ID"].Visible = false;
                // gridView3.Columns["Firma"].Visible = false;
                gridView3.Columns["Proje"].Visible = false;
                gridView3.Columns["nID"].Visible = false;
                gridView3.Columns["Rapor"].Visible = false;
            }
            
            //date_baslangic.EditValue = date_basla.EditValue;
            //date_baslangic.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            //date_baslangic.Properties.Mask.EditMask = "yyyy-MM-dd";
            //date_baslangic.Properties.Mask.UseMaskAsDisplayFormat = true;

           
        }

    
        public static int boold;
        public static string bid;

        void gridduzen()
        {
            this.gridView3.Columns[0].Width = 50;
            this.gridView3.Columns[1].Width = 55;
            this.gridView3.Columns[2].Width = 100;
            //this.gridView3.Columns[3].Width = 180;
            this.gridView3.Columns[4].Width = 150; 
            this.gridView3.Columns[5].Width = 60;
            this.gridView3.Columns[6].Width = 150;
            this.gridView3.Columns[7].Width = 100;
            this.gridView3.Columns[8].Width = 60;
            this.gridView3.Columns[9].Width = 60;
            this.gridView3.Columns[10].Width = 60;
            this.gridView3.Columns[11].Width = 60;
            this.gridView3.Columns[12].Width = 60;

        }
        private void NKR_Load(object sender, EventArgs e)
        {         
            listele();
            gridduzen();        

        }


        private void gridView3_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }

        }

        private void gridView3_RowStyle(object sender, RowStyleEventArgs e)
        {
         //  Tüm satırı renklendirmek istediğin zaman kullan
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string ODurum = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Durum"]);
                if (ODurum == "Tamamlandı")
                {
                    e.Appearance.BackColor = Color.Green;
                    e.Appearance.BackColor2 = Color.LightGreen;
                    e.HighPriority = true;

                }
                else if (ODurum == "İşleme Alındı")
                {
                    e.Appearance.BackColor = Color.LightSalmon;
                    e.Appearance.BackColor2 = Color.Salmon;
                    e.HighPriority = true;
                }
              
            }
        }

        private void gridView3_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            string adam = gridView3.GetRowCellValue(e.RowHandle, "Durum").ToString();
            if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && adam == "Atama Yapıldı!")
                e.Appearance.BackColor = Color.PaleVioletRed;

        }

        private void NKR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {

                listele();
            }

        }
      

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listele();
        }

        public static string raporno, raporID, durum, x1ID;
            
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //DataRow dr = gridView3.GetDataRow(gridView1.FocusedRowHandle);
                //raporno = dr["Rapor No"].ToString();
                //raporID = dr["nID"].ToString();
                //Numune.TanimDetay.raporID = raporID;
                //Numune.TanimDetay td = new Numune.TanimDetay();
                //td.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata 5: " + ex);
            }


        }


        private void gridView3_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            
            if (e.Column.FieldName == "Evrak No" || e.Column.FieldName == "Rapor No" || e.Column.FieldName == "Kabul" || e.Column.FieldName == "Termin"  || e.Column.FieldName == "Durum" || e.Column.FieldName =="Rapor" || e.Column.FieldName == "Yetkili")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
          
        }
        string evrakno;
        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
                raporno = dr["Rapor No"].ToString();
                raporID = dr["nID"].ToString();
                x1ID = dr["ID"].ToString();
                evrakno = dr["Evrak No"].ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hatasız kul olmaz.." + ex);
            }

        }


        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            Numune.Mix2.raporID = raporID;
            Numune.Mix2.raporno = raporno;
            Numune.Mix2 m = new Numune.Mix2();
            m.Show();
        }

        private void barButtonItem2_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // işleme alındı

            //SqlCommand komutSil = new SqlCommand("update NumuneX1 set HizmetDurum=@a1, Yetkili=@a2 where ID = @p1", bgl.baglanti());
            //komutSil.Parameters.AddWithValue("@p1", x1ID);
            //komutSil.Parameters.AddWithValue("@a1", "İşleme Alındı");
            //komutSil.Parameters.AddWithValue("@a2", Giris.kullaniciID);
            //komutSil.ExecuteNonQuery();
            //bgl.baglanti().Close();
            


            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {

                string id = gridView3.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);           
                string o2;
                o2 = gridView3.GetRowCellValue(y, "ID").ToString();

         //       o2 = gridView3.GetRowCellValue(i, "ID").ToString();
                SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                    "update NumuneX1 set HizmetDurum=@o1, Yetkili=@o2 where ID = @o3; " +
                    "COMMIT TRANSACTION", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", "İşleme Alındı");
                add2.Parameters.AddWithValue("@o2", Giris.kullaniciID);
                add2.Parameters.AddWithValue("@o3", o2);
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();
            }

            listele();

        }

        public List<object> seciliDegerler = new List<object>();

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //atama yap
            seciliDegerler.Clear();
            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {

                string id = gridView3.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                string o2;
                o2 = gridView3.GetRowCellValue(y, "ID").ToString();


                var deger = gridView3.GetRowCellValue(y, "ID").ToString();
                seciliDegerler.Add(deger);


                ////string o2;
                ////o2 = gridView3.GetRowCellValue(i, "ID").ToString();
                //SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                //    "update NumuneX1 set HizmetDurum=@o1 where ID = @o3; " +
                //    "COMMIT TRANSACTION", bgl.baglanti());
                //add2.Parameters.AddWithValue("@o1", "Tamamlandı");
                //add2.Parameters.AddWithValue("@o3", o2);
                //add2.ExecuteNonQuery();
                //bgl.baglanti().Close();
            }

           
            mROOT.Numune.Atama at = new mROOT.Numune.Atama();
            mROOT.Numune.Atama.seciliDegerler = seciliDegerler;
            at.Show();


        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //red

            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {

                string id = gridView3.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                string o2;
                o2 = gridView3.GetRowCellValue(y, "ID").ToString();
                //string o2;
                //o2 = gridView3.GetRowCellValue(i, "ID").ToString();
                SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                    "update NumuneX1 set HizmetDurum=@o1 where ID = @o3; " +
                    "COMMIT TRANSACTION", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", "Reddedildi");
                add2.Parameters.AddWithValue("@o3", o2);
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();
            }



            listele();
        }

        public List<object> seciliyazdir = new List<object>();
        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //yazdir

            //seciliyazdir.Clear();
            //for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            //{

            //    string id = gridView3.GetSelectedRows()[i].ToString();
            //    int y = Convert.ToInt32(id);
            //    string o2;
            //    o2 = gridView3.GetRowCellValue(y, "nID").ToString();


            //    var deger = gridView3.GetRowCellValue(y, "ID").ToString();
            //    seciliyazdir.Add(deger);

            //}

            //mROOT.Raporlar.HizmetTakip.seciliyazdir = seciliyazdir;
            //using (Raporlar.frmPrint frm = new Raporlar.frmPrint())
            //{
            //    frm.HizmetTakip();
            //    frm.ShowDialog();
            //}


            IsTakip.tID = evrakno;
            using (Raporlar.frmPrint frm = new Raporlar.frmPrint())
            {
                frm.IsTakip();
                frm.ShowDialog();
            }

        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Anasayfa.kullanici == "3")
            {
               
            }
            else
            {
                string path = "iştakiplistesi.xlsx";
                gridControl1.ExportToXlsx(path);
                Process.Start(path);
            }
           
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // gizle göster 

            if (Anasayfa.kullanici == "3")
            {
                DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(@"SELECT n.Evrak_No AS [Evrak No], n.RaporNo AS [Rapor No], 
                f.Ad AS Firma, p.Ad AS Proje, n.Numune_Adi AS Numune, l.Kod,
                l.Ad AS Hizmet, l.Method, n.Tarih AS Kabul, x.Termin, 
                x.HizmetDurum AS Durum, n.Rapor_Durumu AS Rapor, k.Ad AS Yetkili, x.ID, n.ID AS nID
                FROM dbo.NumuneX1 AS x LEFT OUTER JOIN
                 dbo.NKR AS n ON x.RaporID = n.ID LEFT OUTER JOIN
                 dbo.NumuneDetay AS d ON n.ID = d.RaporID LEFT OUTER JOIN
                 dbo.RootKullanici AS k ON x.Yetkili = k.ID LEFT OUTER JOIN
                 dbo.RootTedarikci AS f ON n.Firma_ID = f.ID LEFT OUTER JOIN
                 dbo.RootTedarikci AS p ON d.ProjeID = p.ID LEFT OUTER JOIN
                 dbo.StokAnalizListesi AS l ON x.AnalizID = l.ID
                 WHERE n.Durum = 'Aktif' and k.ID =3
                 ORDER BY x.Termin desc, nID DESC", bgl.baglanti());
                da.Fill(dt);
                gridControl1.DataSource = dt;
                gridView3.Columns["ID"].Visible = false;
                // gridView3.Columns["Firma"].Visible = false;
                gridView3.Columns["Proje"].Visible = false;
                gridView3.Columns["nID"].Visible = false;
                gridView3.Columns["Rapor"].Visible = false;
            }
            else if (Anasayfa.kullanici == "2009")
            {
                DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(@"SELECT n.Evrak_No AS [Evrak No], n.RaporNo AS [Rapor No], 
                f.Ad AS Firma, p.Ad AS Proje, n.Numune_Adi AS Numune, l.Kod,
                l.Ad AS Hizmet, l.Method, n.Tarih AS Kabul, x.Termin, 
                x.HizmetDurum AS Durum, n.Rapor_Durumu AS Rapor, k.Ad AS Yetkili, x.ID, n.ID AS nID
                FROM dbo.NumuneX1 AS x LEFT OUTER JOIN
                 dbo.NKR AS n ON x.RaporID = n.ID LEFT OUTER JOIN
                 dbo.NumuneDetay AS d ON n.ID = d.RaporID LEFT OUTER JOIN
                 dbo.RootKullanici AS k ON x.Yetkili = k.ID LEFT OUTER JOIN
                 dbo.RootTedarikci AS f ON n.Firma_ID = f.ID LEFT OUTER JOIN
                 dbo.RootTedarikci AS p ON d.ProjeID = p.ID LEFT OUTER JOIN
                 dbo.StokAnalizListesi AS l ON x.AnalizID = l.ID
                 WHERE n.Durum = 'Aktif' and k.ID =2009
                 ORDER BY x.Termin desc, nID DESC", bgl.baglanti());
                da.Fill(dt);
                gridControl1.DataSource = dt;
                gridView3.Columns["ID"].Visible = false;
                // gridView3.Columns["Firma"].Visible = false;
                gridView3.Columns["Proje"].Visible = false;
                gridView3.Columns["nID"].Visible = false;
                gridView3.Columns["Rapor"].Visible = false;
            }
            else
            {
                DataTable dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(@"SELECT n.Evrak_No AS [Evrak No], n.RaporNo AS [Rapor No], 
                f.Ad AS Firma, p.Ad AS Proje, n.Numune_Adi AS Numune, l.Kod,
                l.Ad AS Hizmet, l.Method, n.Tarih AS Kabul, x.Termin, 
                x.HizmetDurum AS Durum, n.Rapor_Durumu AS Rapor, k.Ad AS Yetkili, x.ID, n.ID AS nID
                FROM dbo.NumuneX1 AS x LEFT OUTER JOIN
                 dbo.NKR AS n ON x.RaporID = n.ID LEFT OUTER JOIN
                 dbo.NumuneDetay AS d ON n.ID = d.RaporID LEFT OUTER JOIN
                 dbo.RootKullanici AS k ON x.Yetkili = k.ID LEFT OUTER JOIN
                 dbo.RootTedarikci AS f ON n.Firma_ID = f.ID LEFT OUTER JOIN
                 dbo.RootTedarikci AS p ON d.ProjeID = p.ID LEFT OUTER JOIN
                 dbo.StokAnalizListesi AS l ON x.AnalizID = l.ID
                 WHERE (n.Durum = 'Aktif')
                 ORDER BY x.Termin asc, nID DESC", bgl.baglanti());
                da.Fill(dt);
                gridControl1.DataSource = dt;
                gridView3.Columns["ID"].Visible = false;
                // gridView3.Columns["Firma"].Visible = false;
                gridView3.Columns["Proje"].Visible = false;
                gridView3.Columns["nID"].Visible = false;
                gridView3.Columns["Rapor"].Visible = false;
            }



            

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        MalKabulGuncelle fr6;
        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Numune Detayı raporID
            MalKabulGuncelle.raporno = raporno;
            MalKabulGuncelle.raporID = Convert.ToString(raporID);
            if (fr6 == null || fr6.IsDisposed)
            {
                fr6 = new MalKabulGuncelle();
                fr6.MdiParent = Application.OpenForms.OfType<Anasayfa>().FirstOrDefault();
                fr6.Show();
            }
        }

        string id, name;
        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //UGDR TR
            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {
                id = gridView3.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                string nID = gridView3.GetRowCellValue(y, "nID").ToString();
                name = gridView3.GetRowCellValue(y, "Numune").ToString();
                frmPrint.name = "ÜGDR - " + name;

                mKYS.Raporlar.Newest.Tr.UGD1.tID = nID;
                mKYS.Raporlar.Newest.Tr.UGD2.tID = nID;
                mKYS.Raporlar.Newest.Tr.UGD3.tID = nID;
                mKYS.Raporlar.Newest.Tr.UGD4.tID = nID;
                using (Raporlar.frmPrint frm = new Raporlar.frmPrint())
                {
                    frm.NewestTR();
                    frm.ShowDialog();
                }


            }
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //etiket
            mROOT.Raporlar.Newest.UTSEtiket.tID = Convert.ToString(raporID);
            using (mKYS.Raporlar.frmPrint frm = new mKYS.Raporlar.frmPrint())
            {
                frm.UTSEtiket2();
                frm.ShowDialog();
            }

        }
        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Dap Güncelle
            nuDAP.rNo = raporno;
            nuDAP.uID = Convert.ToString(raporID);
            nuDAP dap = new nuDAP();
            dap.Show();

        }
        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ekozm

        }
        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //challenge

        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //stabilite

        }



        private void gridView3_DoubleClick(object sender, EventArgs e)
        {

        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // tamamlandı

            //SqlCommand komutSil = new SqlCommand("update NumuneX1 set HizmetDurum=@a1 where ID = @p1", bgl.baglanti());
            //komutSil.Parameters.AddWithValue("@p1", x1ID);
            //komutSil.Parameters.AddWithValue("@a1", "Tamamlandı");
            //komutSil.ExecuteNonQuery();
            //bgl.baglanti().Close();


            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {

                string id = gridView3.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                string o2;
                o2 = gridView3.GetRowCellValue(y, "ID").ToString();
                //string o2;
                //o2 = gridView3.GetRowCellValue(i, "ID").ToString();
                SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                    "update NumuneX1 set HizmetDurum=@o1 where ID = @o3; " +
                    "COMMIT TRANSACTION", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", "Tamamlandı");
                add2.Parameters.AddWithValue("@o3", o2);
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();
            }



            listele();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {            
            Numune.SonucListesi.raporID = raporID;
            Numune.SonucListesi.raporNo = raporno;

            Numune.SonucListesi sl = new Numune.SonucListesi();
            sl.Show();

            
        }

        private void BarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TanimDetay.raporno = raporno;
            Numune.TanimDetay.raporID = raporID;
            Numune.TanimDetay td = new Numune.TanimDetay();
            td.Show();
        }

    }
}
