﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakip
{
    public partial class StokDus : Form
    {
        public StokDus()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        private void listele()
        {
            SqlCommand komutID = new SqlCommand("Select * From StokListesi where Durum= N'Aktif'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                combokod.Properties.Items.Add(drI["Kod"].ToString());
            }
            bgl.baglanti().Close();

        }

        private void temizle()
        {
            combo_marka.Text = "";
            txtmiktar.Text = "";
            txtbirim.Text = "";
        }
        
        private void StokDus_Load(object sender, EventArgs e)
        {
            listele();
            DateTime tarih = DateTime.Now;
            dategiris.EditValue = tarih;
        }

        int stokid;
        string marka, lot, skt, marka2, lot2, skt2;

        private void combo_marka_SelectedIndexChanged(object sender, EventArgs e)
        {
            // marka bul
            string[] result = combo_marka.Text.Split('/');
            marka2 = result[0].Trim(' ');
            lot2 = result[1].Trim(' ');
        }

        private void combokod_SelectedIndexChanged(object sender, EventArgs e)
        {
            temizle();

            SqlCommand komutID = new SqlCommand("Select * From StokListesi where Kod = N'" + combokod.Text + "'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                stokid = Convert.ToInt32(drI["ID"].ToString());
                txtbirim.Text = drI["Birim"].ToString();
            }
            bgl.baglanti().Close();

            SqlCommand komutD = new SqlCommand("select distinct Marka, Lot from StokHareket where StokID in (select ID from StokListesi where Kod = N'" + combokod.Text + "') order by Marka", bgl.baglanti());
            SqlDataReader dr = komutD.ExecuteReader();
            while (dr.Read())
            {
                marka = dr["Marka"].ToString();
                lot = dr["Lot"].ToString();
                combo_marka.Properties.Items.Add(marka + " / " + lot);
            }
            bgl.baglanti().Close();

        }

        private void cikarma()
        {
            float f1 = float.Parse(txtmiktar.Text);
            float f2 = f1 * -1;

            SqlCommand add = new SqlCommand("insert into StokHareket (StokID, Marka,Lot,Miktar,Birim,Tarih,Hareket) values (@a1,@a2,@a3,@a4,@a5,@a7,@a8)", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", stokid);
            add.Parameters.AddWithValue("@a2", marka2);
            add.Parameters.AddWithValue("@a3", lot2);
            add.Parameters.AddWithValue("@a4", f2);
            add.Parameters.AddWithValue("@a5", txtbirim.Text);
            add.Parameters.AddWithValue("@a7", dategiris.EditValue);
            add.Parameters.AddWithValue("@a8", "Çıkış");
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        string stokk;
        float stok;
        private void anastok()
        {
            SqlCommand komutID = new SqlCommand("select SUM(Miktar) from StokHareket where StokID in (select ID from StokListesi where  Kod = N'" + combokod.Text + "') ", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                stokk = drI[0].ToString();
            }
            bgl.baglanti().Close();
            stok = float.Parse(stokk);

            SqlCommand add = new SqlCommand("update StokListesi set Miktar = @a1 where Kod = N'" + combokod.Text + "'", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", stok);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (combo_marka.Text == "")
            {
                MessageBox.Show("Lütfen marka ve lot seçimi yapınız. ");
            }
            else
            {
                cikarma();
                anastok();
                MessageBox.Show("İşlem başarılı!", "Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
   
        }
    }
}