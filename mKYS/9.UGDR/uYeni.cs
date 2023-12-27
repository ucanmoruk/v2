using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mKYS;
using DevExpress.DataAccess.Excel;
using DevExpress.XtraGrid.Columns;

namespace mROOT._9.UGDR
{
    public partial class uYeni : Form
    {
        public uYeni()
        {
            InitializeComponent();
        }

        public static string detay;

        sqlbaglanti bgl = new sqlbaglanti();

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //OpenFileDialog file = new OpenFileDialog();
            //file.Filter = "Excel Dosyası |*.xlsx| Excel Dosyası|*.xls ";
            //if (file.ShowDialog()==DialogResult.OK)
            //{
            //    textEdit17.Text = file.FileName;
            //    ExcelDataSource excel = new ExcelDataSource();
            //    excel.FileName = textEdit17.Text;
            //    ExcelWorksheetSettings excelWorksheetSettings = new ExcelWorksheetSettings("Formül","A1:C100");
            //    excel.SourceOptions = new ExcelSourceOptions(excelWorksheetSettings);
            //    excel.SourceOptions = new CsvSourceOptions() { CellRange ="A1:C100" };
            //    excel.SourceOptions.SkipEmptyRows = true;
            //    excel.SourceOptions.UseFirstRowAsHeader = true;
            //    excel.Fill();
            //    gridControl1.DataSource = excel;      
            //}

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

            //for (int ik = 0; ik < gridView1.RowCount; ik++)
            //{
            //    string co2 = gridView1.GetRowCellValue(ik, "INCI Name").ToString();

            //    SqlCommand komut = new SqlCommand("select COUNT(ID) from rHammadde where InciAd = '" + co2 + "'", bgl.baglanti());
            //    SqlDataReader dr = komut.ExecuteReader();
            //    while (dr.Read())
            //    {
            //        //combo_tur.Text = dr["TeklifTuru"].ToString();
            //        string hammadde = dr[0].ToString();
            //        if (hammadde == "0")
            //        {
            //            gridView1.SetRowCellValue(ik, "Durum", "Ok");
            //        }
            //        else
            //        {
            //            gridView1.SetRowCellValue(ik,"Durum", "Yok");
            //        }
            //    }
            //    bgl.baglanti().Close();
            //}
        }

        private void uYeni_Load(object sender, EventArgs e)
        {
           
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {

        }
    }
}
