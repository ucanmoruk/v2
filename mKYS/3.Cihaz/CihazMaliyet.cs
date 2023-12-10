using DevExpress.XtraEditors;
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

namespace mKYS.Cihaz
{
    public partial class CihazMaliyet : Form
    {
        public CihazMaliyet()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID, Ad from RootTedarikci where Durum= 'Aktif'", bgl.baglanti());
            da.Fill(dt);

            gridLookUpEdit2.Properties.DataSource = dt;
            gridLookUpEdit2.Properties.DisplayMember = "Ad";
            gridLookUpEdit2.Properties.ValueMember = "ID";

            DataTable dt5 = new DataTable();
            SqlDataAdapter da5 = new SqlDataAdapter("select ID, Kod + ' ' + Ad as 'Cihaz' from RootCihazListesi where Durum= 'Aktif'", bgl.baglanti());
            da5.Fill(dt5);
            gridLookUpEdit1.Properties.DataSource = dt5;
            gridLookUpEdit1.Properties.DisplayMember = "Cihaz";
            gridLookUpEdit1.Properties.ValueMember = "ID";
        }

        private void CihazMaliyet_Load(object sender, EventArgs e)
        {
            listele();
        }

        CMaliyetListe m = (CMaliyetListe)System.Windows.Forms.Application.OpenForms["CMaliyetListe "];
        void ekleme()
        {
            SqlCommand add = new SqlCommand(" insert into RootCihazMaliyet (CihazID, FirmaID, Tarih, Aciklama, Tl, Dolar, Euro, Durum) values (@a1, @a2, @a3, @a4, @a5, @a6,@a7,@a8)", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", gridLookUpEdit1.EditValue);
            add.Parameters.AddWithValue("@a2", gridLookUpEdit2.EditValue);
            add.Parameters.AddWithValue("@a3", dateEdit1.EditValue);
            add.Parameters.AddWithValue("@a4", txt_aciklama.Text);
            add.Parameters.AddWithValue("@a5", txt_tl.Text);
            add.Parameters.AddWithValue("@a6", txt_dolar.Text);
            add.Parameters.AddWithValue("@a7", txt_euro.Text);
            add.Parameters.AddWithValue("@a8", "Aktif");
            add.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Maliyet başarıyla eklendi!", "Ooppss!");

            if (Application.OpenForms["CMaliyetListe"] == null)
            { }
            else
            { m.listele(); }

        }

        void temizle()
        {
            txt_aciklama.Text = "";
            txt_dolar.Text = "";
            txt_euro.Text = "";
            txt_tl.Text = "" ;
            gridLookUpEdit1.EditValue = null;
            gridLookUpEdit2.EditValue = null;
            dateEdit1.EditValue = null;
        }

        private void gridLookUpEdit2_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        private void gridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        private void gridLookUpEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GridLookUpEdit edit = sender as GridLookUpEdit;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                gridLookUpEdit1.EditValue = null;
            }
        }

        private void gridLookUpEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GridLookUpEdit edit = sender as GridLookUpEdit;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                gridLookUpEdit2.EditValue = null;
            }
        }


        private void btn_save_Click(object sender, EventArgs e)
        {
            ekleme();
            temizle();
        }

        private void txt_tl_Enter(object sender, EventArgs e)
        {
            if (txt_tl.Text == "₺")
            {
                txt_tl.Text = "";
            }

        }

        private void txt_tl_Leave(object sender, EventArgs e)
        {
            if (txt_tl.Text == "")
            {
                txt_tl.Text = "₺";
            }
        }

        private void txt_dolar_Enter(object sender, EventArgs e)
        {
            if (txt_dolar.Text == "$")
            {
                txt_dolar.Text = "";
            }
        }

        private void txt_dolar_Leave(object sender, EventArgs e)
        {
            if (txt_dolar.Text == "")
            {
                txt_dolar.Text = "$";
            }
        }

        private void txt_euro_Enter(object sender, EventArgs e)
        {
            if (txt_euro.Text == "€")
            {
                txt_euro.Text = "";
            }
        }

        private void txt_euro_Leave(object sender, EventArgs e)
        {
            if (txt_euro.Text == "")
            {
                txt_euro.Text = "€";
            }
        }
    }
}
