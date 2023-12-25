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

namespace mKYS.Raporlar
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

        public void KimyasalEtiket()
        {

            Raporlar.KimyasalEtiket etiket = new Raporlar.KimyasalEtiket();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in etiket.Parameters)
            {
                p.Visible = false;
                etiket.bilgi();
                documentViewer1.DocumentSource = etiket;
                etiket.CreateDocument();
            }

        }

        public void CihazEtiket()
        {

            Raporlar.CihazEtiket etiket = new Raporlar.CihazEtiket();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in etiket.Parameters)
            {
                p.Visible = false;
                etiket.bilgi();
                documentViewer1.DocumentSource = etiket;
                etiket.CreateDocument();
            }

        }

        public void CihazListesi()
        {

            Raporlar.DokumanCihaz etiket = new Raporlar.DokumanCihaz();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in etiket.Parameters)
            {
                p.Visible = false;
                etiket.bilgi();
                documentViewer1.DocumentSource = etiket;
                etiket.CreateDocument();
            }

        }

        public void Tedarikci()
        {

            Raporlar.Tedarikci etiket = new Raporlar.Tedarikci();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in etiket.Parameters)
            {
                p.Visible = false;
                etiket.bilgi();
                documentViewer1.DocumentSource = etiket;
                etiket.CreateDocument();
            }

        }

        public void PersonelListesi()
        {

            Raporlar.DokumanPersonel etiket = new Raporlar.DokumanPersonel();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in etiket.Parameters)
            {
                p.Visible = false;
                etiket.bilgi();
                documentViewer1.DocumentSource = etiket;
                etiket.CreateDocument();
            }

        }

        public void AnalizListesi()
        {

            Raporlar.DokumanAnaliz etiket = new Raporlar.DokumanAnaliz();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in etiket.Parameters)
            {
                p.Visible = false;
                etiket.bilgi();
                documentViewer1.DocumentSource = etiket;
                etiket.CreateDocument();
            }

        }

        public void UGDR()
        {
            UGD1 rapor = new UGD1();
            rapor.PrintingSystem.ContinuousPageNumbering = true;
          //  rapor.PrintingSystem.PageCount = true;
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rapor.Parameters)
            {
                p.Visible = false;
                rapor.bilgi();
             //   rapor.Name = name;
                rapor.CreateDocument();

                UGD2 rapor2 = new UGD2();
                foreach (DevExpress.XtraReports.Parameters.Parameter p2 in rapor2.Parameters)
                {
                    p2.Visible = false;
                    rapor2.bilgi();
                    rapor2.CreateDocument();
                }
                UGD3 rapor3 = new UGD3();
                foreach (DevExpress.XtraReports.Parameters.Parameter p3 in rapor3.Parameters)
                {
                    p3.Visible = false;
                    rapor3.bilgi();
                    rapor3.CreateDocument();
                }
                UGD4 rapor4 = new UGD4();
                foreach (DevExpress.XtraReports.Parameters.Parameter p4 in rapor4.Parameters)
                {
                    p4.Visible = false;
                    rapor4.bilgi();
                    rapor4.CreateDocument();
                }
                rapor.Pages.AddRange(rapor2.Pages);
                rapor.Pages.AddRange(rapor3.Pages);
                rapor.Pages.AddRange(rapor4.Pages);

            }
    
            documentViewer1.DocumentSource = rapor;
        }


        public void Dermatolojik()
        {

            Raporlar.Dermatological rapor = new Raporlar.Dermatological();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rapor.Parameters)
            {
                p.Visible = false;
                rapor.bilgi();
                documentViewer1.DocumentSource = rapor;
                rapor.CreateDocument();
            }

        }
        public void TeklifMS()
        {

            Raporlar.TeklifMS etiket = new Raporlar.TeklifMS();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in etiket.Parameters)
            {
                p.Visible = false;
                etiket.bilgi();
                documentViewer1.DocumentSource = etiket;
                etiket.CreateDocument();
            }

        }
    }
}