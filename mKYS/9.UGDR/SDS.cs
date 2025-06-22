using mKYS;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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

namespace mROOT._9.UGDR
{
    public partial class SDS : Form
    {
        public SDS()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();


        private async void btnTehlikeKodlariniAl_Click(object sender, EventArgs e)
        {
            List<string> casNolar = new List<string>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["CasNo"].Value != null)
                {
                    string cas = row.Cells["CasNo"].Value.ToString().Trim();
                    if (!string.IsNullOrEmpty(cas))
                        casNolar.Add(cas);
                }
            }

            // Şimdi bu listeyi string olarak dışa aktarabiliriz
            string casListe = string.Join(",", casNolar);
            Clipboard.SetText(casListe); // Kopyala
            MessageBox.Show("CAS No'lar panoya kopyalandı. ChatGPT'ye yapıştırabilirsiniz.");
        }


        private void SDS_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(@"select Cas as 'CasNo' from rCosing where ID in (select HammaddeID from rUGDFormül where UrunID = 36217)", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            // Tehlike Kodları için yeni sütun ekleyelim
            if (!dataGridView1.Columns.Contains("TehlikeKodlari"))
            {
                dataGridView1.Columns.Add("TehlikeKodlari", "Tehlike Kodları");
            }
        }
    }
}
