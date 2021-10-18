using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mKYS.Dokuman
{
    public partial class DokumanGoruntule : Form
    {
        public DokumanGoruntule()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public static string yol, ad, path;

        private void DokumanGoruntule_FormClosing(object sender, FormClosingEventArgs e)
        {
            yol = "";
            Text = "";
        }

        private void DokumanGoruntule_Load(object sender, EventArgs e)
        {
            path = Path.Combine(Anasayfa.kpath, yol);
            axAcroPDF1.LoadFile(path);

            if(Text == "" || Text == null)
            { }
            else
            {
                Text = ad;
            }
               
        }
    }
}
