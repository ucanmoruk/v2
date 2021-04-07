using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakip
{
    public partial class Personel : Form
    {
        public Personel()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();

        public static string update;
        private void Personel_Load(object sender, EventArgs e)
        {
            combobul();
            if (update == "")
            {
                personeldetay();
            }
            else
            {
                btn_ekle.Text = "Güncelle";
            }
        }

        void combobul()
        {

        }

        void personeldetay()
        {

        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {

        }
    }
}
