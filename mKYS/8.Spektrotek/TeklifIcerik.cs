using DevExpress.XtraGrid;
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
    public partial class TeklifIcerik : Form
    {
        public TeklifIcerik()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(@"select l.TeklifNo, l.Tarih, f.Ad, 
                s.Kategori,s.Marka, s.Kod, s.Ad,
                d.Miktar, d.Birim, d.Fiyat, l.ParaBirimi, d.Tutar as 'Toplam',
                l.ID from STeklifListe l 
                left join STeklifDetay d on l.ID = d.TeklifID
                left join RootTedarikci f on l.FirmaID = f.ID
                left join SStokListe s on d.StokID = s.ID
                where l.Durum = 'Aktif'
                order by l.ID desc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.Columns["ID"].Visible = false;


        }

        void gridduzen()
        {
            this.gridView1.Columns[0].Width = 50;
            this.gridView1.Columns[1].Width = 50;
            this.gridView1.Columns[2].Width = 150;
            this.gridView1.Columns[3].Width = 70;
            this.gridView1.Columns[4].Width = 70;
            this.gridView1.Columns[5].Width = 50;
            this.gridView1.Columns[6].Width = 150;
            this.gridView1.Columns[7].Width = 50;
            this.gridView1.Columns[8].Width = 50;
            this.gridView1.Columns[9].Width = 50;
            this.gridView1.Columns[10].Width = 50;
            this.gridView1.Columns[11].Width = 50;

        }

        public static string gelis;
        private void Liste_Load(object sender, EventArgs e)
        {
            listele();
            gridduzen();
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //string adam = gridView1.GetRowCellValue(e.RowHandle, "Durum").ToString();
            //if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && adam == "Raporlandı")
            //    e.Appearance.BackColor = Color.LightGreen;
            //else if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && adam == "Beklemede")
            //    e.Appearance.BackColor = Color.LightSalmon;
            //else if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && adam == "Yeni")
            //    e.Appearance.BackColor = Color.WhiteSmoke;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
       

            
          
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //yenile sayfası
            listele();
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            //if (e.HitInfo.InRow)
            //{
            //    var p2 = MousePosition;
            //    popupMenu1.ShowPopup(p2);

            //}
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "Miktar" || e.Column.FieldName == "Birim" || e.Column.FieldName == "Fiyat" || e.Column.FieldName == "ParaBirimi" || e.Column.FieldName == "Toplam" )
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void Liste_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {

                listele();
            }
        }

        string lID, fNo, firID, tutar;

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // ödeme bekliyor
         

        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //fatura 2 
            //mMacro.Raporlar.MSStarv2.unique = lID;

            //using (mKYS.Raporlar.frmPrint frm = new mKYS.Raporlar.frmPrint())
            //{
            //    frm.MSStar2();
            //    frm.ShowDialog();
            //}
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            mROOT.Raporlar.CosIng.hID = lID;
            using (mKYS.Raporlar.frmPrint frm = new mKYS.Raporlar.frmPrint())
            {
                frm.CosIng();
                frm.ShowDialog();
            }
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
   


        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //kısmi

        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           


        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

           
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }
        string rno;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
        
        }
    }
}
