using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using mKYS;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.Windows.Forms;
using SeleniumExtras.WaitHelpers;

namespace mROOT.Raporlar
{
    public partial class CosIng : DevExpress.XtraReports.UI.XtraReport
    {
        public CosIng()
        {
            InitializeComponent();
        }
        public static string hID; string link;
        sqlbaglanti bgl = new sqlbaglanti();
        public void bilgi()
        {
            pID.Value = hID;

        }


    }
}
