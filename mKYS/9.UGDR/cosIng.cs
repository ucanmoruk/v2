using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mKYS;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace mROOT._9.UGDR
{
    public partial class cosIng : Form
    {
        public cosIng()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();
        static void cosng(string[] args)
        {
            // ChromeDriver'ın yolunu belirtin (eğer sistem yollarına eklenmediyse)
            IWebDriver driver = new ChromeDriver(@"C:\Users\X260\Downloads\chromedriver");

            // Bir web sayfasını açın
            driver.Navigate().GoToUrl("https://ec.europa.eu/growth/tools-databases/cosing/details/31884");

            // İşlemlerinizi burada gerçekleştirin...

            // Tarayıcıyı kapatın
            driver.Quit();
        }
        string sccslink; string allLinksCombined;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            IWebDriver driver = new ChromeDriver();
            try
            {

               
                SqlCommand komut = new SqlCommand("select Link from rCosing", bgl.baglanti());
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    string link = dr[0].ToString();
                    driver.Navigate().GoToUrl(link);
                    IList<IWebElement> elements = driver.FindElements(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[1]/td[2]"));
                    if (elements.Count > 0)
                    {
                        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                        IWebElement name = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[1]/td[2]")));
                        IWebElement cas = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[3]/td[2]")));
                        IWebElement ec = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[4]/td[2]")));
                        IWebElement regulation = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[6]/td[2]")));
                        IWebElement func = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[7]/td[2]/ul")));
                        IWebElement sccs = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[8]/td[2]")));
                        IWebElement sccsli = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[8]/td[2]")));
                        if (sccsli.Text == "" || sccsli.Text == null)
                        {
                            sccslink = null;
                        }
                        else
                        {
                            List<string> allLinks = new List<string>();
                            IList<IWebElement> linkElements = driver.FindElements(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[8]/td[2]/ul/li/a"));
                            foreach (IWebElement linkElement in linkElements)
                            {
                                string href = linkElement.GetAttribute("href");
                                allLinks.Add(href);
                                allLinksCombined = String.Join("\n", allLinks);


                            }
                        }
                        SqlCommand komutz = new SqlCommand("update rCosing set INCIName =@a1, Cas=@a2, EC=@a3, Functions=@a4, Regulation=@a5, SCCS=@a6, SCCSLink=@a7 where Link = '" + link + "'", bgl.baglanti());
                        komutz.Parameters.AddWithValue("@a1", name.Text);
                        komutz.Parameters.AddWithValue("@a2", cas.Text);
                        komutz.Parameters.AddWithValue("@a3", ec.Text);
                        komutz.Parameters.AddWithValue("@a4", func.Text);
                        komutz.Parameters.AddWithValue("@a5", regulation.Text);
                        komutz.Parameters.AddWithValue("@a6", sccs.Text);
                        komutz.Parameters.AddWithValue("@a7", allLinksCombined);
                        komutz.ExecuteNonQuery();
                        bgl.baglanti().Close();

                    }
                    else
                    {

                    }










                    //IWebElement name = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[1]/td[2]")));
                    //IWebElement cas = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[3]/td[2]")));
                    //IWebElement ec = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[4]/td[2]")));
                    //IWebElement regulation = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[6]/td[2]")));
                    //IWebElement func = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[7]/td[2]/ul")));
                    //IWebElement sccs = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[8]/td[2]")));
                    //IWebElement sccsli = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[8]/td[2]")));
                    //if (sccsli.Text =="" || sccsli.Text == null)
                    //{
                    //    sccslink = sccsli.Text;
                    //}
                    //else
                    //{
                    //    //IWebElement linkElement = driver.FindElement(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[8]/td[2]/ul/li/a"));
                    //    //string href = linkElement.GetAttribute("href");
                    //    //sccs = href;
                    //    List<string> allLinks = new List<string>();
                    //    IList<IWebElement> linkElements = driver.FindElements(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[8]/td[2]/ul/li/a"));           
                    //    foreach (IWebElement linkElement in linkElements)
                    //    {
                    //        string href = linkElement.GetAttribute("href");
                    //        allLinks.Add(href);
                    //        allLinksCombined = String.Join("\n", allLinks);


                    //    }
                    //}


                }
                bgl.baglanti().Close();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                driver.Quit();
                MessageBox.Show("İşlem Başarılı!");
            }

           
            
        }

        private void cosIng_Load(object sender, EventArgs e)
        {
            //cosng(); 
            SqlCommand komut = new SqlCommand("select * from rCosing where ID = 4", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                memoEdit1.Text = dr["Functions"].ToString();
                memoEdit2.Text = dr["SCCSLink"].ToString();
              
            }
            bgl.baglanti().Close();

        }
        string ana,link;

        private void button1_Click(object sender, EventArgs e)
        {
            insert();
        }
        //31364
        void insert()
        {
            IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            for (int i = 37532; i < 40000; i++)
            {
                try
                {
                    link = "https://ec.europa.eu/growth/tools-databases/cosing/details/" + i;
                    driver.Navigate().GoToUrl(link);
                    IWebElement tur = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='ecl-main-content']/div/ng-component/h1")));
                    IWebElement name = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[1]/td[2]")));
                    IWebElement cas = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[3]/td[2]")));
                    IWebElement ec = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[4]/td[2]")));
                    IWebElement regulation = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[6]/td[2]")));
                    IWebElement func = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[7]/td[2]/ul")));
                    IWebElement sccs = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[8]/td[2]")));
                    IWebElement sccsli = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[8]/td[2]")));
                    if (sccsli.Text == "" || sccsli.Text == null)
                    {
                        sccslink = null; allLinksCombined = null;
                    }
                    else
                    {
                        List<string> allLinks = new List<string>();
                        IList<IWebElement> linkElements = driver.FindElements(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[8]/td[2]/ul/li/a"));
                        foreach (IWebElement linkElement in linkElements)
                        {
                            string href = linkElement.GetAttribute("href");
                            allLinks.Add(href);
                            allLinksCombined = String.Join("\n", allLinks);
                        }
                    }
                    SqlCommand komutz = new SqlCommand(@"insert into rCosing (Link, INCIName, Cas, EC, Functions, Regulation, SCCS, SCCSLink, Tur) values 
                            (@a1, @a2, @a3, @a4, @a5, @a6, @a7, @a8, @a9) ", bgl.baglanti());
                    komutz.Parameters.AddWithValue("@a1", link);
                    komutz.Parameters.AddWithValue("@a2", name.Text);
                    komutz.Parameters.AddWithValue("@a3", cas.Text);
                    komutz.Parameters.AddWithValue("@a4", ec.Text);
                    komutz.Parameters.AddWithValue("@a5", func.Text);
                    komutz.Parameters.AddWithValue("@a6", regulation.Text);
                    komutz.Parameters.AddWithValue("@a7", sccs.Text);
                    if (allLinksCombined == null)
                        komutz.Parameters.AddWithValue("@a8", DBNull.Value);
                    else
                        komutz.Parameters.AddWithValue("@a8", allLinksCombined);
                    komutz.Parameters.AddWithValue("@a9", tur.Text);
                    komutz.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }
                catch (Exception ex)
                {
                    SqlCommand komutz = new SqlCommand(@"insert into rCosingHata (Detay, Hata, Tarih) values 
                            (@a1, @a2, @a3) ", bgl.baglanti());
                    komutz.Parameters.AddWithValue("@a1", i);
                    komutz.Parameters.AddWithValue("@a2", ex.Message);
                    komutz.Parameters.AddWithValue("@a3", DateTime.Now);
                    komutz.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    continue;
                }

               


            }
            driver.Quit();
            MessageBox.Show("İşlem Başarılı!");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            for (int i = 31922; i < 31365; i++)
            {
                
                    link = "https://ec.europa.eu/growth/tools-databases/cosing/details/" + i;
                    driver.Navigate().GoToUrl(link);
                    IWebElement tur = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='ecl-main-content']/div/ng-component/h1")));
                    IWebElement name = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[1]/td[2]")));
                    IWebElement cas = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[3]/td[2]")));
                    IWebElement ec = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[4]/td[2]")));
                    IWebElement regulation = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[6]/td[2]")));
                    IWebElement func = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[7]/td[2]/ul")));
                    IWebElement sccs = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[8]/td[2]")));
                    IWebElement sccsli = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[8]/td[2]")));
                    if (sccsli.Text == "" || sccsli.Text == null)
                    {
                        sccslink = null; allLinksCombined = null;
                    }
                    else
                    {
                        List<string> allLinks = new List<string>();
                        IList<IWebElement> linkElements = driver.FindElements(By.XPath("//*[@id='ecl-main-content']/div/ng-component/table/tbody/tr[8]/td[2]/ul/li/a"));
                        foreach (IWebElement linkElement in linkElements)
                        {
                            string href = linkElement.GetAttribute("href");
                            allLinks.Add(href);
                            allLinksCombined = String.Join("\n", allLinks);
                        }
                    }
                    SqlCommand komutz = new SqlCommand(@"insert into rCosing (Link, INCIName, Cas, EC, Functions, Regulation, SCCS, SCCSLink, Tur) values 
                            (@a1, @a2, @a3, @a4, @a5, @a6, @a7, @a8, @a9) ", bgl.baglanti());
                    komutz.Parameters.AddWithValue("@a1", link);
                    komutz.Parameters.AddWithValue("@a2", name.Text);
                    komutz.Parameters.AddWithValue("@a3", cas.Text);
                    komutz.Parameters.AddWithValue("@a4", ec.Text);
                    komutz.Parameters.AddWithValue("@a5", func.Text);
                    komutz.Parameters.AddWithValue("@a6", regulation.Text);
                    komutz.Parameters.AddWithValue("@a7", sccs.Text);
                    if(allLinksCombined == null)
                    komutz.Parameters.AddWithValue("@a8", DBNull.Value);
                    else
                    komutz.Parameters.AddWithValue("@a8", allLinksCombined);
                    komutz.Parameters.AddWithValue("@a9", tur.Text);
                    komutz.ExecuteNonQuery();
                    bgl.baglanti().Close();
              




            }
            driver.Quit();
            MessageBox.Show("İşlem Başarılı!");
        }

        string ok;
  
    }
}
