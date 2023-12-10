using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Globalization;

namespace mKYS.Raporlar
{
    public partial class TeklifMS : DevExpress.XtraReports.UI.XtraReport
    {
        public TeklifMS()
        {
            InitializeComponent();
        }

        public static string tID;

        private double Euro = 0.0;
        private double Dolar = 0.0;
        private DataSet dsDovizKur;
        private void DovizKur()
        {
            dsDovizKur = new DataSet();
            dsDovizKur.ReadXml(@"https://www.tcmb.gov.tr/kurlar/today.xml");
            DataRow dr = dsDovizKur.Tables[1].Rows[0];
            Dolar = Convert.ToDouble(dr[3].ToString().Replace('.', ','));
            dr = dsDovizKur.Tables[1].Rows[3];
            Euro = Convert.ToDouble(dr[3].ToString().Replace('.', ','));

        }

        public void bilgi()
        {
            DovizKur();

            pTID.Value = tID;
            //pDolar.Value = Dolar;
            //pEuro.Value = Euro;
            xrLabel7.Text = "Dolar: " + Dolar + " Euro: " + Euro;
        }

        private void xrPageInfo1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //XRLabel label = sender as XRLabel;
            //CultureInfo culture = new CultureInfo("en-GB");
            //label.Text = String.Format(culture, "{0:d MMMM yyyy}", DateTime.Now);
        }
    }
}
