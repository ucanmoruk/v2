using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakip.Talep
{
    public partial class MaliyetNo : Form
    {
        public MaliyetNo()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Talep.MaaliyetEkle.talepno = txt_no.Text;

            this.Close();

            //MaaliyetEkle me = new MaaliyetEkle();
            //me.Show();

            var mfrm = (Anasayfa)Application.OpenForms["Anasayfa"];
            if (mfrm != null)
                mfrm.mekle();

        }
    }
}
