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

namespace StokTakip
{
    public partial class SertifikaGoruntule : Form
    {
        public SertifikaGoruntule()
        {
            InitializeComponent();
        }

        public static string yol, path;

        private void SertifikaGoruntule_Load_1(object sender, EventArgs e)
        {
            path = Path.Combine(Anasayfa.path, yol);
            axAcroPDF1.LoadFile(path);
        }

        private void SertifikaGoruntule_Load(object sender, EventArgs e)
        {
          //  path = Path.Combine(@"\\WDMyCloud\KYS_Uygulama\Belgelerim\Sertifikalar", yol);
            //path = Path.Combine(Anasayfa.path, yol);
            //axAcroPDF1.LoadFile(path);
        //    this.pdfViewer1.LoadDocument(path);
         //   MessageBox.Show(yol);

        }
    }
}
