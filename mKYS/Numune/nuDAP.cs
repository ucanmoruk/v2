﻿using DevExpress.DataAccess.Excel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using mKYS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mKYS
{
    public partial class nuDAP : Form
    {
        public nuDAP()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();
        private void btn_ac_Click(object sender, EventArgs e)
        {
            DialogResult Secim = new DialogResult();

            Secim = MessageBox.Show("Seçili hammaddeleri formülden kaldırmak istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Secim == DialogResult.Yes)
            {
                for (int i = 0; i < gridView2.SelectedRowsCount; i++)
                {
                    o1 = gridView2.GetSelectedRows()[i].ToString();
                    int y = Convert.ToInt32(o1);
                    id = gridView2.GetRowCellValue(y, "ID").ToString();
                    SqlCommand add2 = new SqlCommand(@"BEGIN TRANSACTION 
                   delete from rUGDFormül where ID = '" + id + "'; COMMIT TRANSACTION", bgl.baglanti());
                    add2.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }
            }
            
            detaybul();
        }

        string o1, id, INCI, Noael;
        private void btn_kontrol_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                o1 = gridView1.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(o1);
                id = gridView1.GetRowCellValue(y, "cosID").ToString();
                INCI = gridView1.GetRowCellValue(y, "INCIName").ToString();
                Noael = gridView1.GetRowCellValue(y, "NOAEL").ToString();
                SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                    "insert into rUGDFormül (UrunID, HammaddeID, INCIName, DaP, Noael) " +
                    "values (@o1,@o2,@o3, @o4, @o5);" +
                    "COMMIT TRANSACTION", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", uID);
                add2.Parameters.AddWithValue("@o2", id);
                add2.Parameters.AddWithValue("@o3", INCI);
                add2.Parameters.AddWithValue("@o4", 100);
                if(Noael == null || Noael == "")
                    add2.Parameters.AddWithValue("@o5", DBNull.Value);
                else
                    add2.Parameters.AddWithValue("@o5", Convert.ToInt32(Noael));
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();
            }

            detaybul();


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int ik = 0; ik <= gridView2.RowCount - 1; ik++)
                {

                    SqlCommand komutz = new SqlCommand("update rUGDFormül set Miktar=@o1, DaP = @o2, Noael=@o3 where ID = '" + gridView2.GetRowCellValue(ik, "ID").ToString() + "' ", bgl.baglanti());
                    komutz.Parameters.AddWithValue("@o1", Convert.ToDecimal(gridView2.GetRowCellValue(ik, "Miktar").ToString()));
                    komutz.Parameters.AddWithValue("@o2", Convert.ToDecimal(gridView2.GetRowCellValue(ik, "Dap").ToString()));
                    if(gridView2.GetRowCellValue(ik, "NOAEL").ToString()==null || gridView2.GetRowCellValue(ik, "NOAEL").ToString()=="")
                        komutz.Parameters.AddWithValue("@o3", DBNull.Value);
                    else
                        komutz.Parameters.AddWithValue("@o3", Convert.ToInt32(gridView2.GetRowCellValue(ik, "NOAEL").ToString()));
                    komutz.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }
                MessageBox.Show("Kaydetme işlemi başarılı!", "Ooppss!");
                this.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Üzülmeyin, yazılımcı tanıdık. Çözeriz! " + ex);
            }
        }

        decimal SED, MOS;
        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.Column.FieldName == "Miktar")
            {

                decimal miktar = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["Miktar"]).ToString());
                string noael = Convert.ToString(view.GetRowCellValue(e.RowHandle, view.Columns["NOAEL"]).ToString());
                if (noael == "" || noael == null)
                {
                    decimal dap = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["Dap"]).ToString());
                    decimal A = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["A"]).ToString());
                 //   decimal NOAEL = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["NOAEL"]).ToString());
                
                    SED = Math.Round(miktar * A * dap / 100 * 1 / 100, 4);
                    view.SetRowCellValue(e.RowHandle, view.Columns["SED"], SED);
                }
                else
                {
                    decimal dap = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["Dap"]).ToString());
                    decimal A = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["A"]).ToString());
                    decimal NOAEL = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["NOAEL"]).ToString());

                    SED = Math.Round(miktar * A * dap / 100 * 1/100, 4);
                    view.SetRowCellValue(e.RowHandle, view.Columns["SED"], SED);
                    if (SED == 0)
                    {

                    }
                    else
                    {
                        MOS = Math.Round(NOAEL / SED, 4);
                        view.SetRowCellValue(e.RowHandle, view.Columns["MOS"], MOS);
                    }
                    
                }

            }
            else if (e.Column.FieldName == "Dap")
            {
                decimal Dap = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["Dap"]).ToString());

                string noael = Convert.ToString(view.GetRowCellValue(e.RowHandle, view.Columns["NOAEL"]).ToString());
                if (noael == "" || noael == null)
                {
                    decimal miktar = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["Miktar"]).ToString());
                    decimal A = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["A"]).ToString());
                 //   decimal NOAEL = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["Dap"]).ToString());

                    SED = Math.Round(miktar * A * Dap / 100 * 1 / 100, 4);
                    view.SetRowCellValue(e.RowHandle, view.Columns["SED"], SED);
                }
                else
                {
                    decimal miktar = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["Miktar"]).ToString());
                    decimal A = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["A"]).ToString());
                    decimal NOAEL = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["NOAEL"]).ToString());

                    SED = Math.Round(miktar * A * Dap / 100 * 1 / 100, 4);
                    view.SetRowCellValue(e.RowHandle, view.Columns["SED"], SED);

                    //MOS = Math.Round(NOAEL / SED, 4);
                    //view.SetRowCellValue(e.RowHandle, view.Columns["MOS"], MOS);
                    if (SED == 0)
                    {

                    }
                    else
                    {
                        MOS = Math.Round(NOAEL / SED, 4);
                        view.SetRowCellValue(e.RowHandle, view.Columns["MOS"], MOS);
                    }
                }


            }
            else if (e.Column.FieldName =="NOAEL")
            {
                decimal Dap = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["Dap"]).ToString());

                string noael = Convert.ToString(view.GetRowCellValue(e.RowHandle, view.Columns["NOAEL"]).ToString());
                if (noael == "" || noael == null)
                {
                    decimal miktar = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["Miktar"]).ToString());
                    decimal A = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["A"]).ToString());
                    decimal NOAEL = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["NOAEL"]).ToString());

                    SED = Math.Round(miktar * A * Dap / 100 * 1 / 100, 4);
                    view.SetRowCellValue(e.RowHandle, view.Columns["SED"], SED);
                }
                else
                {
                    decimal miktar = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["Miktar"]).ToString());
                    decimal A = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["A"]).ToString());
                    decimal NOAEL = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["NOAEL"]).ToString());

                    SED = Math.Round(miktar * A * Dap / 100 * 1 / 100, 4);
                    view.SetRowCellValue(e.RowHandle, view.Columns["SED"], SED);

                    //MOS = Math.Round(NOAEL / SED, 4);
                    //view.SetRowCellValue(e.RowHandle, view.Columns["MOS"], MOS);
                    if (SED == 0)
                    {

                    }
                    else
                    {
                        MOS = Math.Round(NOAEL / SED, 4);
                        view.SetRowCellValue(e.RowHandle, view.Columns["MOS"], MOS);
                    }
                }
            }

          
        }

        public static string uID, rNo, gelis;
        private void uFormul_Load(object sender, EventArgs e)
        {
            detaybul();

            Text = rNo + " Numaralı Rapor Formülü";

        }
        private void gridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
           
           
        }

        private void gridView2_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "Miktar" || e.Column.FieldName == "Dap" || e.Column.FieldName == "A" || e.Column.FieldName == "NOAEL" || e.Column.FieldName == "SED" || e.Column.FieldName == "MOS")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void uFormul_FormClosing(object sender, FormClosingEventArgs e)
        {
            
          
        }
        private void uFormul_FormClosed(object sender, FormClosedEventArgs e)
        {
           
            gelis = null;
            rNo = null;
            uID = null;
        }
        void detaybul()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select f.INCIName, c.Cas,c.Regulation, f.Miktar, f.Dap, l.A, f.Noael as 'NOAEL', CAST(ROUND((f.Miktar*l.A*f.Dap/100*1/100),2) AS numeric(36,2)) as 'SED',
            CAST(ROUND((f.Noael / (f.Miktar*l.A*f.Dap/100*1/100)),2) AS numeric(36,2)) as 'MOS',
            c.ID as 'cosID', f.ID from rUGDFormül f 
            left join rCosing c on f.INCIName = c.INCIName 
			left join rUGDListe l on f.UrunID = l.RaporNo
			where f.UrunID = '" + uID+"' order by f.Miktar desc", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
            gridView2.Columns["cosID"].Visible = false;
            gridView2.Columns["ID"].Visible = false;
            this.gridView2.Columns[0].Width = 110;
            this.gridView2.Columns[1].Width = 70;
            this.gridView2.Columns[2].Width = 50;
            this.gridView2.Columns[3].Width = 50;
            this.gridView2.Columns[4].Width = 50;
            this.gridView2.Columns[5].Width = 50;
            this.gridView2.Columns[6].Width = 50;
            this.gridView2.Columns[7].Width = 50;
            this.gridView2.Columns[8].Width = 50;
            this.gridView2.Columns[8].OptionsColumn.AllowEdit = false;
            this.gridView2.Columns[8].AppearanceCell.BackColor = Color.LemonChiffon;
            this.gridView2.Columns[7].OptionsColumn.AllowEdit = false;
            this.gridView2.Columns[7].AppearanceCell.BackColor = Color.LemonChiffon;
            //this.gridView2.Columns[6].OptionsColumn.AllowEdit = false;
            //this.gridView2.Columns[6].AppearanceCell.BackColor = Color.LemonChiffon;
            this.gridView2.Columns[5].OptionsColumn.AllowEdit = false;
            this.gridView2.Columns[5].AppearanceCell.BackColor = Color.LemonChiffon;

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(@"select c.INCIName, r.Noael2 as 'NOAEL', c.Cas, c.Regulation, c.ID as 'cosID' from rHammadde r
                left join rCosing c on r.cID = c.ID 
                except select c.INCIName, r.Noael2 as 'NOAEL', c.Cas, c.Regulation, c.ID from rUGDFormül f 
                left join rCosing c on f.HammaddeID = c.ID 
                left join rHammadde r on c.ID = r. cID
                where f.UrunID = '" + uID + "' order by c.INCIName asc ", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;
            gridView1.Columns["cosID"].Visible = false;
            this.gridView1.Columns[0].Width = 120;
            this.gridView1.Columns[1].Width = 70;
            this.gridView1.Columns[2].Width = 50;
            this.gridView1.Columns[3].Width = 50;




        }
        
        private void btnexcel_Click(object sender, EventArgs e)
        {
            string path = "FormülListesi.xlsx";
            gridControl2.ExportToXlsx(path);
            Process.Start(path);

        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //temizle
            if (MessageBox.Show("Ürüne ait formülasyonu silmek mi istiyorsunuz?",
                                                "Temizle?",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question) == DialogResult.No)
            {

            }
            else
            {
                SqlCommand komutz = new SqlCommand("delete from rUGDFormül where UrunID = '" + uID + "' ", bgl.baglanti());
                komutz.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Silme işlemi başarılı, yeni formül ekleyebilirsiniz!", "Başarılı");
                detaybul();
            }
        }
    }
}
