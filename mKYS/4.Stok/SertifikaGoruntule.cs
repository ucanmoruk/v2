﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mKYS
{
    public partial class SertifikaGoruntule : Form
    {
        public SertifikaGoruntule()
        {
            InitializeComponent();
        }

        public static string yol, path, ad;

        private void SertifikaGoruntule_Load_1(object sender, EventArgs e)
        {
            path = Path.Combine(Anasayfa.path, yol);
            axAcroPDF1.LoadFile(path);

            if (Text == "" || Text == null)
            { }
            else
            {
                Text = ad;
            }
        }

        private void SertifikaGoruntule_FormClosing(object sender, FormClosingEventArgs e)
        {
            yol = null;
            Text =  null;
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
