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
using mKYS.Talep;

namespace mKYS.Talep
{
    public partial class TalepMaliyet : Form
    {
        public TalepMaliyet()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();

        void listele()
        {
            SqlCommand komut2 = new SqlCommand("select ID, TalepNo from RootTalepListe where Aktif = 'Aktif' order by TalepNo", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                combo_no.Properties.Items.Add(dr2["TalepNo"]);
            }
            bgl.baglanti().Close();

        }

        void flistele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID, Ad from RootTedarikci where Durum= 'Aktif' order by Ad ", bgl.baglanti());
            da.Fill(dt);

            gridLookUpEdit2.Properties.DataSource = dt;
            gridLookUpEdit2.Properties.DisplayMember = "Ad";
            gridLookUpEdit2.Properties.ValueMember = "ID";
        }
           
        void detaybul()
        {
            flistele();

            SqlCommand komutID = new SqlCommand("Select * From RootTalepDetay where ID = '" + tID + "'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                combo_no.Text = drI["TalepNo"].ToString();
                gridLookUpEdit3.EditValue = drI["ID"].ToString();
                txt_stok.Text = drI["Miktar"].ToString();
                txt_birim.Text = drI["Birim"].ToString();
            }
            bgl.baglanti().Close();

            gridLookUpEdit3.Enabled = false;
            combo_no.Enabled = false;

            if (tkontrol == "0" || tkontrol == null)
            {

            }
            else
            {
                SqlCommand komutI = new SqlCommand("Select * From RootStokMaliyet where tID = '" + tID + "'", bgl.baglanti());
                SqlDataReader dr = komutI.ExecuteReader();
                while (dr.Read())
                {
                    gridLookUpEdit2.EditValue = dr["TedarikciID"].ToString();
                    txt_tl.Text = dr["TL"].ToString();
                    txt_dolar.Text = dr["Dolar"].ToString();
                    txt_euro.Text = dr["Euro"].ToString();
                    txt_tutar.Text = dr["Tutar"].ToString();
                    txt_stok.Text = dr["Miktar"].ToString();
                    txt_birim.Text = dr["Birim"].ToString();
                    dateEdit1.EditValue = dr["Tarih"];
                    btn_save.Text = "Güncelle";
                }
                bgl.baglanti().Close();
            }
        }

        string tkontrol;
        void kontrol()
        {
            SqlCommand komutID = new SqlCommand("Select count(ID) From RootStokMaliyet where tID = '" + tID + "'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                tkontrol = drI[0].ToString();
            }
            bgl.baglanti().Close();
        }


        public static string gelis, tID;
        private void CihazMaliyet_Load(object sender, EventArgs e)
        {          
            if (gelis == "" || gelis == null)
            {
                kontrol();
                detaybul();
                DateTime tarih = DateTime.Now;
                dateEdit1.EditValue = tarih;
               
            }
            else
            {
                DateTime tarih = DateTime.Now;
                dateEdit1.EditValue = tarih;
                listele();
                flistele();
            }

        }

        MaliyetListesi m = (MaliyetListesi)System.Windows.Forms.Application.OpenForms["MaliyetListesi"];

        string tl, dolar, euro, tutar;
        void cevir()
        {
            if ( txt_dolar.Text == "$")
            {
                dolar = "";
            }
            else
            {
                dolar = txt_dolar.Text;
            }

            if (txt_euro.Text == "" || txt_euro.Text == "€")
            {
                euro = "";
            }
            else
            {
                euro = txt_euro.Text;
            }

            if (txt_tl.Text == "" || txt_tl.Text == "₺")
            {
                tl = "";
            }
            else
            {
                tl = txt_tl.Text;
            }

            if (txt_tutar.Text == "" || txt_tutar.Text == "₺ (KDV Hariç)")
            {
                tutar = "";
            }
            else
            {
                tutar = txt_tutar.Text;
            }

        }

        void ekleme()
        {
           cevir();

            SqlCommand add = new SqlCommand(" insert into RootStokMaliyet (tID, TedarikciID, Tarih, Tutar, Tl, Dolar, Euro,Durum,Miktar,Birim) values" +
                " (@a1, @a2, @a3, @a4, @a5, @a6,@a7,@a8,@a9,@a10)", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", tID);
            add.Parameters.AddWithValue("@a2", firmaID);
            add.Parameters.AddWithValue("@a3", dateEdit1.EditValue);
            add.Parameters.AddWithValue("@a4", tutar);
            add.Parameters.AddWithValue("@a5", tl);
            add.Parameters.AddWithValue("@a6", dolar);
            add.Parameters.AddWithValue("@a7", euro);
            add.Parameters.AddWithValue("@a8", "Aktif");
            add.Parameters.AddWithValue("@a9", txt_stok.Text);
            add.Parameters.AddWithValue("@a10", txt_birim.Text);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Maliyet başarıyla eklendi!", "Ooppss!");

            if (Application.OpenForms["MaliyetListesi"] == null)
            { }
            else
            { m.listele(); }

        }

        void guncelle()
        {
            cevir();

            SqlCommand add = new SqlCommand(" update RootStokMaliyet set  TedarikciID=@a2, Tarih=@a3, Tutar=@a4, Tl=@a5, Dolar=@a6, Euro=@a7,Miktar=@a8,Birim=@a9 where tID = '" + tID+"'", bgl.baglanti());
            add.Parameters.AddWithValue("@a2", firmaID);
            add.Parameters.AddWithValue("@a3", dateEdit1.EditValue);
            add.Parameters.AddWithValue("@a4", tutar);
            add.Parameters.AddWithValue("@a5", tl);
            add.Parameters.AddWithValue("@a6", dolar);
            add.Parameters.AddWithValue("@a7", euro);
            add.Parameters.AddWithValue("@a8", txt_stok.Text);
            add.Parameters.AddWithValue("@a9", txt_birim.Text);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Güncelleme işlemi başarılı!", "Ooppss!");

            if (Application.OpenForms["MaliyetListesi"] == null)
            { }
            else
            { m.listele(); }
        }

        void temizle()
        {
            txt_dolar.Text = "$";
            txt_euro.Text = "€";
            txt_tl.Text = "₺";
            txt_tutar.Text = "₺ (KDV Hariç)";
            txt_stok.Text = "";
            txt_birim.Text = "";
            gridLookUpEdit2.EditValue = null;
            btn_save.Text = "Kaydet";
        }


        private void btn_save_Click(object sender, EventArgs e)
        {
            if (btn_save.Text == "Güncelle")
            {
                guncelle();
            }
            else
            {
                ekleme();
                temizle();
            }

        }

        private void gridLookUpEdit2_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        private void gridLookUpEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GridLookUpEdit edit = sender as GridLookUpEdit;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                gridLookUpEdit2.EditValue = null;
            }
        }

        private void gridLookUpEdit3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GridLookUpEdit edit = sender as GridLookUpEdit;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                gridLookUpEdit3.EditValue = null;
            }
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

        private void gridLookUpEdit3_QueryPopUp(object sender, CancelEventArgs e)
        {
            if (combo_no.Text == null || combo_no.EditValue == null || combo_no.Text == "")
            {
                MessageBox.Show("Lütfen önce talep kodu seçiniz!", "Ooppss!");
            }
            else
            {
                GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
                gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
            }

        }

        private void txt_tutar_Enter(object sender, EventArgs e)
        {
            if (txt_tutar.Text == "₺ (KDV Hariç)")
            {
                txt_tutar.Text = "";
            }
        }

        private void txt_tutar_Leave(object sender, EventArgs e)
        {
            if (txt_tutar.Text == "")
            {
                txt_tutar.Text = "₺ (KDV Hariç)";
            }
        }

        private void combo_no_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dt5 = new DataTable();
            SqlDataAdapter da5 = new SqlDataAdapter(@"SELECT d.ID, l.Kod + ' - ' +l.Ad as 'Sipariş'  from RootTalepDetay d 
            inner join RootStokListesi l on d.StokKod = l.Kod where d.Durumu = 'Aktif' and d.TalepNo = '" + combo_no.Text+"' order by d.TalepNo", bgl.baglanti());
            da5.Fill(dt5);
            gridLookUpEdit3.Properties.DataSource = dt5;
            gridLookUpEdit3.Properties.DisplayMember = "Sipariş";
            gridLookUpEdit3.Properties.ValueMember = "ID";


        }

        private void TalepMaliyet_FormClosed(object sender, FormClosedEventArgs e)
        {
            gelis = null;
            tID = null;
        }

        int firmaID;
        private void gridLookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            if (gridLookUpEdit2.EditValue == null)
            {
                firmaID = 1015;
            }
            else
            {
                firmaID = Convert.ToInt32(gridLookUpEdit2.EditValue);
            }
        }

        private void gridLookUpEdit3_EditValueChanged(object sender, EventArgs e)
        {
            if (combo_no.Text == null || combo_no.EditValue == null || combo_no.Text == "")
            {
                MessageBox.Show("Lütfen önce talep kodu seçiniz!", "Oooppss!");
            }
            else
            {
                temizle();

                SqlCommand komutID = new SqlCommand("Select * From RootTalepDetay where ID = '" + gridLookUpEdit3.EditValue + "'", bgl.baglanti());
                SqlDataReader drI = komutID.ExecuteReader();
                while (drI.Read())
                {
                    txt_stok.Text = drI["Miktar"].ToString();
                    txt_birim.Text = drI["Birim"].ToString();

                    SqlCommand komutaID = new SqlCommand("Select count(ID) From RootStokMaliyet where tID = '" + gridLookUpEdit3.EditValue + "'", bgl.baglanti());
                    SqlDataReader draI = komutaID.ExecuteReader();
                    while (draI.Read())
                    {
                        tkontrol = draI[0].ToString();
                    }
                    bgl.baglanti().Close();

                    if (tkontrol == "0" || tkontrol == null)
                    {

                    }
                    else
                    {
                        SqlCommand komutI = new SqlCommand("Select * From RootStokMaliyet where tID = '" + gridLookUpEdit3.EditValue + "'", bgl.baglanti());
                        SqlDataReader dr = komutI.ExecuteReader();
                        while (dr.Read())
                        {
                            gridLookUpEdit2.EditValue = dr["TedarikciID"].ToString();
                            txt_tl.Text = dr["TL"].ToString();
                            txt_dolar.Text = dr["Dolar"].ToString();
                            txt_euro.Text = dr["Euro"].ToString();
                            txt_tutar.Text = dr["Tutar"].ToString();
                            dateEdit1.EditValue = dr["Tarih"];
                            txt_stok.Text = dr["Miktar"].ToString();
                            txt_birim.Text = dr["Birim"].ToString();
                            btn_save.Text = "Güncelle";
                        }
                        bgl.baglanti().Close();


                    }

                }
                bgl.baglanti().Close();

                if (gridLookUpEdit3.Enabled == true && gridLookUpEdit3.EditValue != null)
                {
                    tID = gridLookUpEdit3.EditValue.ToString();
                }
           
            }


        }

    }
}
