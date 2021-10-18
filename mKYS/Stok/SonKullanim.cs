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

namespace mKYS
{
    public partial class SonKullanim : Form
    {
        public SonKullanim()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select distinct l.Tur as 'Tür', l.Kod, l.Ad, l.Cas, l.Ambalaj, h.Marka, h.Lot, h.SKT, b.Birim from StokHareket h " +
                " left join StokListesi l on h.StokID = l.ID left join StokFirmaBirim b on h.BirimID = b.ID where h.Hareket = N'Giriş' and YEAR(h.SKT) > 2020 order by h.SKT asc", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;

        }

        private void SonKullanim_Load(object sender, EventArgs e)
        {
            listele();
        }
    }
}
