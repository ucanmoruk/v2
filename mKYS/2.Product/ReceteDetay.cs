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

namespace mKYS.Stok
{
    public partial class ReceteDetay : Form
    {
        public ReceteDetay()
        {
            InitializeComponent();
        }


        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt2 = new DataTable();
         //   SqlDataAdapter da2 = new SqlDataAdapter("select r.StokKod as 'Kod', l.Ad, l.Miktar, l.Birim, l.Limit as 'Kritik Limit' from StokRecete r inner join StokListesi l on r.StokKod = l.Kod where r.AnalizKod = N'"+skod+"' order by r.StokKod", bgl.baglanti());
         //   SqlDataAdapter da2 = new SqlDataAdapter("select Kod, Ad, Miktar, Birim, Limit as 'Kritik Limit' from StokListesi where ID in (select StokID from StokRecete where AnalizID = '" + aID + "')", bgl.baglanti());
            SqlDataAdapter da2 = new SqlDataAdapter(@"select l.Kod, l.Ad, r.Alt, r.Ust, r.Tam, r.Birim from RootStokListesi l 
            left join RootRecete r on l.ID = r.StokID
            where r.AnalizID = '" + aID + "' order by r.Alt desc, r.Tam desc", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;

            SqlCommand komut2 = new SqlCommand("Select * from RootUrunListesi where ID = N'" + aID + "' ", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                skod = dr2["Kod"].ToString();
                sad = dr2["Ad"].ToString();
            }
            bgl.baglanti().Close();

        }

        int yetki;
        void yetkibul()
        {
            SqlCommand komut21 = new SqlCommand("Select * from KaliteYetki where Gorev = N'" + Anasayfa.gorev + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                yetki = Convert.ToInt32(dr21["Analiz"]);
            }
            bgl.baglanti().Close();

            if (yetki == 0 || yetki.ToString() == null)
            {
                panelControl2.Visible = false;
                Size = new Size(480, 371);
            }
            else
            {
                panelControl2.Visible = true;
            }

        }

        public static string aID, skod,sad;
        private void ReceteDetay_Load(object sender, EventArgs e)
        {
          //  yetkibul();
            listele();

            Text = skod + " - " + sad;

            this.gridView1.Columns[0].Width = 50;
            this.gridView1.Columns[1].Width = 100;
            this.gridView1.Columns[2].Width = 50;
            this.gridView1.Columns[3].Width = 50;
            this.gridView1.Columns[4].Width = 50;
            this.gridView1.Columns[5].Width = 50;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Analiz.UrunFormul.gelis = "Güncelle";
            Analiz.UrunFormul.aID = aID;

            var mfrm = (Anasayfa)Application.OpenForms["Anasayfa"];
            if (mfrm != null)
            mfrm.UrunFormul();

            this.Close();
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    DialogResult Secim = new DialogResult();

            //    Secim = MessageBox.Show(skod + " kodlu reçeteyi silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            //    if (Secim == DialogResult.Yes)
            //    {
            //        SqlCommand komutSil = new SqlCommand("delete from RootRecete where AnalizKod = N'" + skod + "'", bgl.baglanti());
            //        komutSil.ExecuteNonQuery();
            //        bgl.baglanti().Close();
            //        MessageBox.Show("Silme işlemi gerçekleşmiştir.");
            //        listele();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Hata 11003 : " + ex.Message);
            //}
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "Ust" || e.Column.FieldName == "Alt" || e.Column.FieldName == "Tam"  || e.Column.FieldName == "Birim")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }
    }
}
