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

        public void Teklif()
        {
            TeklifUni teklif = new TeklifUni();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in teklif.Parameters)
            {
                p.Visible = false;
                teklif.bilgi();
                documentViewer1.DocumentSource = teklif;
                teklif.CreateDocument();
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

        public void ProformaGrup()
        {
            ProformaGrup hamveri = new ProformaGrup();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in hamveri.Parameters)
            {
                p.Visible = false;
                hamveri.bilgi2();
                documentViewer1.DocumentSource = hamveri;
                hamveri.CreateDocument();
            }
        }

        public void ProformaManuel()
        {
            ProformaManuel ham = new ProformaManuel();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in ham.Parameters)
            {
                p.Visible = false;
                ham.bilgi2();
                documentViewer1.DocumentSource = ham;
                ham.CreateDocument();
            }
        }

        public void ProformaYazdir()
        {
            Raporlar.ProformaFatura rapor = new Raporlar.ProformaFatura();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rapor.Parameters)
            {
                p.Visible = false;
                rapor.bilgi2();
                documentViewer1.DocumentSource = rapor;
                rapor.CreateDocument();
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

        public void UGDRCosmo()
        {
            Cosmoliz.UGD1 rapor = new Cosmoliz.UGD1();
            rapor.PrintingSystem.ContinuousPageNumbering = true;
            //  rapor.PrintingSystem.PageCount = true;
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
                Cosmoliz.UGD5 rapor5 = new Cosmoliz.UGD5();
                foreach (DevExpress.XtraReports.Parameters.Parameter p5 in rapor5.Parameters)
                {
                    p5.Visible = false;
                    rapor5.bilgi();
                    rapor5.CreateDocument();
                }
                rapor.Pages.AddRange(rapor2.Pages);
                rapor.Pages.AddRange(rapor3.Pages);
                rapor.Pages.AddRange(rapor4.Pages);
                rapor.Pages.AddRange(rapor5.Pages);

            }

            documentViewer1.DocumentSource = rapor;
        }

        public void UGDRKompass()
        {
            Kompass.UGD1 rapor = new Kompass.UGD1();
            rapor.PrintingSystem.ContinuousPageNumbering = true;
            //  rapor.PrintingSystem.PageCount = true;
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rapor.Parameters)
            {
                p.Visible = false;
                rapor.bilgi();
                rapor.Name = name;
                rapor.CreateDocument();

                Kompass.UGD2 rapor2 = new Kompass.UGD2();
                foreach (DevExpress.XtraReports.Parameters.Parameter p2 in rapor2.Parameters)
                {
                    p2.Visible = false;
                    rapor2.bilgi();
                    rapor2.CreateDocument();
                }
                Kompass.UGD3 rapor3 = new Kompass.UGD3();
                foreach (DevExpress.XtraReports.Parameters.Parameter p3 in rapor3.Parameters)
                {
                    p3.Visible = false;
                    rapor3.bilgi();
                    rapor3.CreateDocument();
                }
                Kompass.UGD4 rapor4 = new Kompass.UGD4();
                foreach (DevExpress.XtraReports.Parameters.Parameter p4 in rapor4.Parameters)
                {
                    p4.Visible = false;
                    rapor4.bilgi();
                    rapor4.CreateDocument();
                }
                Kompass.UGD5 rapor5 = new Kompass.UGD5();
                foreach (DevExpress.XtraReports.Parameters.Parameter p5 in rapor5.Parameters)
                {
                    p5.Visible = false;
                    rapor5.bilgi();
                    rapor5.CreateDocument();
                }
                rapor.Pages.AddRange(rapor2.Pages);
                rapor.Pages.AddRange(rapor3.Pages);
                rapor.Pages.AddRange(rapor4.Pages);
                rapor.Pages.AddRange(rapor5.Pages);

            }

            documentViewer1.DocumentSource = rapor;
        }


        public void UGDRKompassEn()
        {
            Kompass.Cpnp.UGD1 rapor = new Kompass.Cpnp.UGD1();
            rapor.PrintingSystem.ContinuousPageNumbering = true;
            //  rapor.PrintingSystem.PageCount = true;
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rapor.Parameters)
            {
                p.Visible = false;
                rapor.bilgi();
                rapor.Name = name;
                rapor.CreateDocument();

                Kompass.Cpnp.UGD2 rapor2 = new Kompass.Cpnp.UGD2();
                foreach (DevExpress.XtraReports.Parameters.Parameter p2 in rapor2.Parameters)
                {
                    p2.Visible = false;
                    rapor2.bilgi();
                    rapor2.CreateDocument();
                }
                Kompass.Cpnp.UGD3 rapor3 = new Kompass.Cpnp.UGD3();
                foreach (DevExpress.XtraReports.Parameters.Parameter p3 in rapor3.Parameters)
                {
                    p3.Visible = false;
                    rapor3.bilgi();
                    rapor3.CreateDocument();
                }
                Kompass.Cpnp.UGD4 rapor4 = new Kompass.Cpnp.UGD4();
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


        public void NewestTR()
        {
            Newest.Tr.UGD1 rapor = new Newest.Tr.UGD1();
            rapor.PrintingSystem.ContinuousPageNumbering = true;
            // rapor.PrintingSystem.PageCount = true;
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rapor.Parameters)
            {
                p.Visible = false;
                rapor.bilgi();
                rapor.Name = name;
                rapor.CreateDocument();

                Newest.Tr.UGD2 rapor2 = new Newest.Tr.UGD2();
                foreach (DevExpress.XtraReports.Parameters.Parameter p2 in rapor2.Parameters)
                {
                    p2.Visible = false;
                    rapor2.bilgi();
                    rapor2.CreateDocument();
                }
                Newest.Tr.UGD3 rapor3 = new Newest.Tr.UGD3();
                foreach (DevExpress.XtraReports.Parameters.Parameter p3 in rapor3.Parameters)
                {
                    p3.Visible = false;
                    rapor3.bilgi();
                    rapor3.CreateDocument();
                }
                Newest.Tr.UGD4 rapor4 = new Newest.Tr.UGD4();
                foreach (DevExpress.XtraReports.Parameters.Parameter p4 in rapor4.Parameters)
                {
                    p4.Visible = false;
                    rapor4.bilgi();
                    rapor4.CreateDocument();
                }
                Newest.Tr.UGD5 rapor5 = new Newest.Tr.UGD5();
                foreach (DevExpress.XtraReports.Parameters.Parameter p5 in rapor5.Parameters)
                {
                    p5.Visible = false;
                    rapor5.bilgi();
                    rapor5.CreateDocument();
                }
                rapor.Pages.AddRange(rapor2.Pages);
                rapor.Pages.AddRange(rapor3.Pages);
                rapor.Pages.AddRange(rapor4.Pages);
                rapor.Pages.AddRange(rapor5.Pages);

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

        public void CPNP()
        {
            Ozeco.Cpnp.UGD1 rapor = new Ozeco.Cpnp.UGD1();
            rapor.PrintingSystem.ContinuousPageNumbering = true;
            // rapor.PrintingSystem.PageCount = true;
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rapor.Parameters)
            {
                p.Visible = false;
                rapor.bilgi();
                rapor.Name = name;
                rapor.CreateDocument();

                Ozeco.Cpnp.UGD2 rapor2 = new Ozeco.Cpnp.UGD2();
                foreach (DevExpress.XtraReports.Parameters.Parameter p2 in rapor2.Parameters)
                {
                    p2.Visible = false;
                    rapor2.bilgi();
                    rapor2.CreateDocument();
                }
                Ozeco.Cpnp.UGD3 rapor3 = new Ozeco.Cpnp.UGD3();
                foreach (DevExpress.XtraReports.Parameters.Parameter p3 in rapor3.Parameters)
                {
                    p3.Visible = false;
                    rapor3.bilgi();
                    rapor3.CreateDocument();
                }
                Ozeco.Cpnp.UGD4 rapor4 = new Ozeco.Cpnp.UGD4();
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


        public void UGDEnCosmo()
        {
            Cosmoliz.Cpnp.UGD1 rapor = new Cosmoliz.Cpnp.UGD1();
            rapor.PrintingSystem.ContinuousPageNumbering = true;
            // rapor.PrintingSystem.PageCount = true;
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rapor.Parameters)
            {
                p.Visible = false;
                rapor.bilgi();
                rapor.Name = name;
                rapor.CreateDocument();

                Cosmoliz.Cpnp.UGD2 rapor2 = new Cosmoliz.Cpnp.UGD2();
                foreach (DevExpress.XtraReports.Parameters.Parameter p2 in rapor2.Parameters)
                {
                    p2.Visible = false;
                    rapor2.bilgi();
                    rapor2.CreateDocument();
                }
                Cosmoliz.Cpnp.UGD3 rapor3 = new Cosmoliz.Cpnp.UGD3();
                foreach (DevExpress.XtraReports.Parameters.Parameter p3 in rapor3.Parameters)
                {
                    p3.Visible = false;
                    rapor3.bilgi();
                    rapor3.CreateDocument();
                }
                Cosmoliz.Cpnp.UGD4 rapor4 = new Cosmoliz.Cpnp.UGD4();
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

        public void UTSEtiket2()
        {

            mROOT.Raporlar.Newest.UTSEtiket rapor = new mROOT.Raporlar.Newest.UTSEtiket();
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


        public void Dermo()
        {

            Raporlar.Test.Dermatological rapor = new Raporlar.Test.Dermatological();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rapor.Parameters)
            {
                p.Visible = false;
                rapor.bilgi();
                documentViewer1.DocumentSource = rapor;
                rapor.CreateDocument();
            }

        }

        public void CDermo()
        {

            Raporlar.Test.CDermatoloji rapor = new Raporlar.Test.CDermatoloji();
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

        public void Challenge()
        {

            Test.ReportCosmetic rapor = new Test.ReportCosmetic();
            rapor.PrintingSystem.ContinuousPageNumbering = true;
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rapor.Parameters)
            {
                p.Visible = false;
                rapor.bilgi();
                rapor.Name = name;
                rapor.CreateDocument();

                Test.ReportCosmetic3 rapor2 = new Test.ReportCosmetic3();
                foreach (DevExpress.XtraReports.Parameters.Parameter p2 in rapor2.Parameters)
                {
                    p2.Visible = false;
                    rapor2.bilgi();
                    rapor2.CreateDocument();
                }
                rapor.Pages.AddRange(rapor2.Pages);

            }

            documentViewer1.DocumentSource = rapor;
        }

        public void Stabilite()
        {
            Test.ReportCosmetic rapor = new Test.ReportCosmetic();
            rapor.PrintingSystem.ContinuousPageNumbering = true;
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rapor.Parameters)
            {
                p.Visible = false;
                rapor.bilgi();
                rapor.Name = name;
                rapor.CreateDocument();

                Test.Stabilityv2 rapor2 = new Test.Stabilityv2();
                foreach (DevExpress.XtraReports.Parameters.Parameter p2 in rapor2.Parameters)
                {
                    p2.Visible = false;
                    rapor2.bilgi();
                    rapor2.CreateDocument();
                }
                rapor.Pages.AddRange(rapor2.Pages);

            }

            documentViewer1.DocumentSource = rapor;
        }

        public void HizmetTakip()
        {
            HizmetTakip rapor = new HizmetTakip();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rapor.Parameters)
            {
               // p.Visible = false;
                rapor.bilgi();
                documentViewer1.DocumentSource = rapor;
                rapor.CreateDocument();
            }
        }

    }
}