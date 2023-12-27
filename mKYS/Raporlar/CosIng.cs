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

            //SqlCommand komutID = new SqlCommand("select * from rCosing where INCIName in (select INCIName from rUGDFormül where UrunID = N'" + hID + "')", bgl.baglanti());
            //SqlDataReader drI = komutID.ExecuteReader();
            //while (drI.Read())
            //{
            //    link = drI["Link"].ToString();
            //    IWebDriver driver = new ChromeDriver();
            //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
                
            //    driver.Navigate().GoToUrl(link);
            //    IWebElement tur = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[2]/td[2]")));

            //    pDesc.Value = tur.Text;  
            //     driver.Quit();     
            // }
             
            //bgl.baglanti().Close();

        }


    }
}
