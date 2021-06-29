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

namespace StokTakip
{
    public partial class TalepDetay : Form
    {
        public TalepDetay()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select d.StokKod as 'Stok Kodu', l.Ad, d.Miktar,d.Birim, d.Marka, d.Ozellik, d.Durum from StokTalepDetay d " +
                "left join StokListesi l on d.StokKod = l.Kod where TalepNo = '"+TalepNo+"' ", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;
        }

        public static string TalepNo;
        private void TalepDetay_Load(object sender, EventArgs e)
        {
            listele();
            txt_no.Text = TalepNo;
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "Miktar" || e.Column.FieldName == "Birim")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void btn_yazdir_Click(object sender, EventArgs e)
        {
            string path = "output.xlsx";
            gridControl1.ExportToXlsx(path);
            Process.Start(path);

        }
    }
}
