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

        private void SertifikaGoruntule_Load(object sender, EventArgs e)
        {

            path = Path.Combine(@"\\WDMyCloud\KYS_Uygulama\Belgelerim\Sertifikalar", yol);
            axAcroPDF1.LoadFile(path);
        //    this.pdfViewer1.LoadDocument(path);
         //   MessageBox.Show(yol);

        }
    }
}
