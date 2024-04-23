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
using mROOT.Raporlar;
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

        public static string name;
        public void UGDR()
        {
            UGD1 rapor = new UGD1();
            rapor.PrintingSystem.ContinuousPageNumbering = true;
          //  rapor.PrintingSystem.PageCount = true;
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rapor.Parameters)
            {
                p.Visible = false;
                rapor.bilgi();
                rapor.Name = name;
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

        public void OzecoTr()
        {
            Ozeco.Tr.UGD1 rapor = new Ozeco.Tr.UGD1();
            rapor.PrintingSystem.ContinuousPageNumbering = true;
           // rapor.PrintingSystem.PageCount = true;
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rapor.Parameters)
            {
                p.Visible = false;
                rapor.bilgi();
                rapor.Name = name;
                rapor.CreateDocument();

                Ozeco.Tr.UGD2 rapor2 = new Ozeco.Tr.UGD2();
                foreach (DevExpress.XtraReports.Parameters.Parameter p2 in rapor2.Parameters)
                {
                    p2.Visible = false;
                    rapor2.bilgi();
                    rapor2.CreateDocument();
                }
                Ozeco.Tr.UGD3 rapor3 = new Ozeco.Tr.UGD3();
                foreach (DevExpress.XtraReports.Parameters.Parameter p3 in rapor3.Parameters)
                {
                    p3.Visible = false;
                    rapor3.bilgi();
                    rapor3.CreateDocument();
                }
                Ozeco.Tr.UGD4 rapor4 = new Ozeco.Tr.UGD4();
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
        public void CosmolizTR()
        {
            Cosmoliz.UGD1 rapor = new Cosmoliz.UGD1();
            rapor.PrintingSystem.ContinuousPageNumbering = true;
            // rapor.PrintingSystem.PageCount = true;
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rapor.Parameters)
            {
                p.Visible = false;
                rapor.bilgi();
                rapor.Name = name;
                rapor.CreateDocument();

                Cosmoliz.UGD2 rapor2 = new Cosmoliz.UGD2();
                foreach (DevExpress.XtraReports.Parameters.Parameter p2 in rapor2.Parameters)
                {
                    p2.Visible = false;
                    rapor2.bilgi();
                    rapor2.CreateDocument();
                }
                Cosmoliz.UGD3 rapor3 = new Cosmoliz.UGD3();
                foreach (DevExpress.XtraReports.Parameters.Parameter p3 in rapor3.Parameters)
                {
                    p3.Visible = false;
                    rapor3.bilgi();
                    rapor3.CreateDocument();
                }
                Cosmoliz.UGD4 rapor4 = new Cosmoliz.UGD4();
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

        public void OzecoEn()
        {
            Ozeco.En.UGD1 rapor = new Ozeco.En.UGD1();
            rapor.PrintingSystem.ContinuousPageNumbering = true;
            // rapor.PrintingSystem.PageCount = true;
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rapor.Parameters)
            {
                p.Visible = false;
                rapor.bilgi();
                rapor.Name = name;
                rapor.CreateDocument();

                Ozeco.En.UGD2 rapor2 = new Ozeco.En.UGD2();
                foreach (DevExpress.XtraReports.Parameters.Parameter p2 in rapor2.Parameters)
                {
                    p2.Visible = false;
                    rapor2.bilgi();
                    rapor2.CreateDocument();
                }
                Ozeco.En.UGD3 rapor3 = new Ozeco.En.UGD3();
                foreach (DevExpress.XtraReports.Parameters.Parameter p3 in rapor3.Parameters)
                {
                    p3.Visible = false;
                    rapor3.bilgi();
                    rapor3.CreateDocument();
                }
                Ozeco.En.UGD4 rapor4 = new Ozeco.En.UGD4();
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
        public void UGDEn()
        {
            Eng.UGD1 rapor = new Eng.UGD1();
            rapor.PrintingSystem.ContinuousPageNumbering = true;
            // rapor.PrintingSystem.PageCount = true;
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rapor.Parameters)
            {
                p.Visible = false;
                rapor.bilgi();
                rapor.Name = name;
                rapor.CreateDocument();

                Eng.UGD2 rapor2 = new Eng.UGD2();
                foreach (DevExpress.XtraReports.Parameters.Parameter p2 in rapor2.Parameters)
                {
                    p2.Visible = false;
                    rapor2.bilgi();
                    rapor2.CreateDocument();
                }
                Eng.UGD3 rapor3 = new Eng.UGD3();
                foreach (DevExpress.XtraReports.Parameters.Parameter p3 in rapor3.Parameters)
                {
                    p3.Visible = false;
                    rapor3.bilgi();
                    rapor3.CreateDocument();
                }
                Eng.UGD4 rapor4 = new Eng.UGD4();
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
        public void CosIng()
        {

            mROOT.Raporlar.CosIng rapor = new mROOT.Raporlar.CosIng();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rapor.Parameters)
            {
                p.Visible = false;
                rapor.bilgi();
                documentViewer1.DocumentSource = rapor;
                rapor.CreateDocument();
            }

        }
        public void UTSEtiket()
        {

            mROOT.Raporlar.UTSEtiket rapor = new mROOT.Raporlar.UTSEtiket();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rapor.Parameters)
            {
                p.Visible = false;
                rapor.bilgi();
                documentViewer1.DocumentSource = rapor;
                rapor.CreateDocument();
            }

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