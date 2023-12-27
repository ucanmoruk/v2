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
    public partial class uCosing : Form
    {
        public uCosing()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(@"select SUBSTRING(Link,60,69) as 'CosIng ID',
            INCIName, Cas, EC, Functions, Regulation, SCCS, SCCSLink, ID from rCosing 
            where Tur like '%Ingredient%' order by INCIName ", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.Columns["ID"].Visible = false;
            // gridView1.Columns["FirmaID"].Visible = false;

            RepositoryItemMemoEdit memo = new RepositoryItemMemoEdit();
            gridView1.Columns["Functions"].ColumnEdit = memo;
            gridView1.Columns["Functions"].ColumnEdit = new RepositoryItemMemoEdit();
            RepositoryItemMemoEdit mem2o = new RepositoryItemMemoEdit();
            gridView1.Columns["SCCS"].ColumnEdit = mem2o;
            gridView1.Columns["SCCS"].ColumnEdit = new RepositoryItemMemoEdit();
            RepositoryItemMemoEdit mem21o = new RepositoryItemMemoEdit();
            gridView1.Columns["SCCSLink"].ColumnEdit = mem21o;
            gridView1.Columns["SCCSLink"].ColumnEdit = new RepositoryItemMemoEdit();
        }

        void gridduzen()
        {
            this.gridView1.Columns[0].Width = 50;
            this.gridView1.Columns[1].Width = 170;
            this.gridView1.Columns[2].Width = 80;
            this.gridView1.Columns[3].Width = 80;
            this.gridView1.Columns[4].Width = 110;
            this.gridView1.Columns[5].Width = 50;
            this.gridView1.Columns[6].Width = 110;
            this.gridView1.Columns[7].Width = 110;

        }
        private void uCosing_Load(object sender, EventArgs e)
        {
            listele();
            gridduzen();
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);

            }
        }

        private void uCosing_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {

                listele();
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "CosIng ID" || e.Column.FieldName == "Regulation" )
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

        }
        string did;
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                did = dr["ID"].ToString();
                YeniHammadde.ID = did;
                YeniHammadde.gelis = "cosing";
                YeniHammadde sd = new YeniHammadde();
                sd.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata 1: " + ex);
            }
        }
    }
}
