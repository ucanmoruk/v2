using DevExpress.DataAccess.Excel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using mKYS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mROOT._9.UGDR
{
    public partial class uFormul : Form
    {
        public uFormul()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();
        private void btn_ac_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Excel Dosyası |*.xlsx| Excel Dosyası|*.xls ";
            if (file.ShowDialog() == DialogResult.OK)
            {             
                ExcelDataSource excel = new ExcelDataSource();
                excel.FileName = file.FileName;
                ExcelWorksheetSettings excelWorksheetSettings = new ExcelWorksheetSettings("Formül", "A1:B250");
                excel.SourceOptions = new ExcelSourceOptions(excelWorksheetSettings);
                excel.SourceOptions = new CsvSourceOptions() { CellRange = "A1:B250" };
                excel.SourceOptions.SkipEmptyRows = true;
                excel.SourceOptions.UseFirstRowAsHeader = true;
                excel.Fill();
                gridControl1.DataSource = excel;
            }

        }
        public static string uID, rNo, gelis;
        private void uFormul_Load(object sender, EventArgs e)
        {
            if (gelis == "Anasayfa" || uID == null || uID == "")
            {
                gridLookUpEdit1.Visible = true;
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(@"select RaporNo, Urun, ID from rUGDListe where BirimID = '"+Giris.birimID+ "' except select * from rUGDListe where ID in (select UrunID from rUGDFormül) order by RaporNo desc", bgl.baglanti());
                da2.Fill(dt2);
                gridLookUpEdit1.Properties.DataSource = dt2;
                gridLookUpEdit1.Properties.DisplayMember = "RaporNo";
                gridLookUpEdit1.Properties.ValueMember = "ID";
            }
            else
            {
                traporno.Visible = true;
                traporno.Text = rNo;
                detaybul();

            }

        }

        private void btn_kontrol_Click(object sender, EventArgs e)
        {
            for (int ik = 0; ik <= gridView1.RowCount - 1; ik++)
            {             
                SqlCommand komutz = new SqlCommand("insert into rUGDFormül (UrunID, INCIName, Miktar) values (@o1,@o2,@o3) ", bgl.baglanti());
                komutz.Parameters.AddWithValue("@o1", "0");
                komutz.Parameters.AddWithValue("@o2", gridView1.GetRowCellValue(ik, "INCI Name").ToString());
                komutz.Parameters.AddWithValue("@o3", Convert.ToDecimal(gridView1.GetRowCellValue(ik, "C (%)").ToString()));
                komutz.ExecuteNonQuery();
                bgl.baglanti().Close();
            }

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select f.INCIName, f.Miktar, c.Cas, c.EC, c.Functions, c.Regulation, c.ID as 'cosID', f.ID from rUGDFormül f 
            left join rCosing c on f.INCIName = c.INCIName where f.UrunID = '0' order by f.Miktar desc ", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
            gridView2.Columns["cosID"].Visible = false;
            gridView2.Columns["ID"].Visible = false;
            RepositoryItemMemoEdit memo = new RepositoryItemMemoEdit();
            gridView2.Columns["Functions"].ColumnEdit = memo;
            gridView2.Columns["Functions"].ColumnEdit = new RepositoryItemMemoEdit();
            this.gridView2.Columns[0].Width = 110;
            this.gridView2.Columns[1].Width = 50;
            this.gridView2.Columns[2].Width = 80;
            this.gridView2.Columns[3].Width = 90;
            this.gridView2.Columns[4].Width = 90;
            this.gridView2.Columns[5].Width = 50;


        }

        private void uFormul_FormClosed(object sender, FormClosedEventArgs e)
        {
            //DialogResult Secim = new DialogResult();

            //Secim = MessageBox.Show("Formülü kaydetmeden çıkmak istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            //if (Secim == DialogResult.Yes)
            //{
            //    SqlCommand komutz = new SqlCommand("delete from rUGDFormül where UrunID = '0' ", bgl.baglanti());
            //    komutz.ExecuteNonQuery();
            //    bgl.baglanti().Close();
            //}
            //else
            //{
            //    e.Cancel = true;
            //}



            rNo = null;
             uID = null;
        }
        string kayit;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (gelis == "Anasayfa")
                {
                    for (int ik = 0; ik <= gridView2.RowCount - 1; ik++)
                    {
                        SqlCommand komutz = new SqlCommand("update rUGDFormül set UrunID=@o1, HammaddeID=@o2 where ID = '" + gridView2.GetRowCellValue(ik, "ID").ToString() + "' ", bgl.baglanti());
                        komutz.Parameters.AddWithValue("@o1", gridLookUpEdit1.EditValue);
                        komutz.Parameters.AddWithValue("@o2", gridView2.GetRowCellValue(ik, "cosID").ToString());
                        komutz.ExecuteNonQuery();
                        bgl.baglanti().Close();
                    }
                    MessageBox.Show("Kaydetme işlemi başarılı!", "Ooppss!");
                    kayit = "evet";
                    this.Close();
                }
                else
                {
                    for (int ik = 0; ik <= gridView2.RowCount - 1; ik++)
                    {
                        SqlCommand komutz = new SqlCommand("update rUGDFormül set UrunID=@o1, HammaddeID=@o2 where ID = '" + gridView2.GetRowCellValue(ik, "ID").ToString() + "' ", bgl.baglanti());
                        komutz.Parameters.AddWithValue("@o1", uID);
                        komutz.Parameters.AddWithValue("@o2", gridView2.GetRowCellValue(ik, "cosID").ToString());
                        komutz.ExecuteNonQuery();
                        bgl.baglanti().Close();
                    }
                    MessageBox.Show("Kaydetme işlemi başarılı!", "Ooppss!");
                    kayit = "evet";
                    this.Close();
                }

               

            }
            catch (Exception ex)
            {
                MessageBox.Show("Üzülmeyin, yazılımcı tanıdık. Çözeriz! " + ex);
            }
        }

        private void gridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        private void uFormul_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    if (gelis=="Anasayfa")
                    {
                        if (kayit == "evet")
                        {

                        }
                        else
                        {
                            if (MessageBox.Show("Kaydetmeden çıkmak istediğinizden emin misiniz?",
                                               "Exit?",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question) == DialogResult.No)
                            {
                                e.Cancel = true;
                            }
                            else
                            {
                                SqlCommand komutz = new SqlCommand("delete from rUGDFormül where UrunID = '0' ", bgl.baglanti());
                                komutz.ExecuteNonQuery();
                                bgl.baglanti().Close();
                            }

                        }
                    }
                    else
                    {

                    }
                    
                 break;
            }
        }

        void detaybul()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select f.INCIName, f.Miktar, c.Cas, c.EC, c.Functions, c.Regulation, c.ID as 'cosID', f.ID from rUGDFormül f 
            left join rCosing c on f.INCIName = c.INCIName where f.UrunID = '"+uID+"' order by f.Miktar desc ", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
            gridView2.Columns["cosID"].Visible = false;
            gridView2.Columns["ID"].Visible = false;
            RepositoryItemMemoEdit memo = new RepositoryItemMemoEdit();
            gridView2.Columns["Functions"].ColumnEdit = memo;
            gridView2.Columns["Functions"].ColumnEdit = new RepositoryItemMemoEdit();
            this.gridView2.Columns[0].Width = 110;
            this.gridView2.Columns[1].Width = 50;
            this.gridView2.Columns[2].Width = 80;
            this.gridView2.Columns[3].Width = 90;
            this.gridView2.Columns[4].Width = 90;
            this.gridView2.Columns[5].Width = 50;
        }

    }
}
