using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace StokTakip.Raporlar
{
    public partial class frmPrint : DevExpress.XtraEditors.XtraForm
    {
        public frmPrint()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void PrintInvoice()
        {

           Raporlar.DokumanMaster rapor = new Raporlar.DokumanMaster();       
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rapor.Parameters)
            {
                p.Visible = false;
                rapor.bilgi();
                documentViewer1.DocumentSource = rapor;
                rapor.CreateDocument();
            }
                   
        }
      



    }
}