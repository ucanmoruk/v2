using mKYS;
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

namespace mROOT._9.UGDR
{
    public partial class ürünfotoları : Form
    {
        public ürünfotoları()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        string m, c, s, k;
        private void ürünfotoları_Load(object sender, EventArgs e)
        {
            SqlCommand komut12 = new SqlCommand(@"select * from rUGDDetay2 where UrunID = '52' ", bgl.baglanti());
            SqlDataReader dr12 = komut12.ExecuteReader();
            while (dr12.Read())
            {
                m = dr12["MResim"].ToString();
                c = dr12["CResim"].ToString();
                s = dr12["Sresim"].ToString();
                k = dr12["Kutu"].ToString();
            }
            bgl.baglanti().Close();


            string res1 = @"http://" + "www.massgrup.com/mRoot/Foto" + "/" + m;
            //var request = WebRequest.Create(res1);
            //using (var response = request.GetResponse())
            //using (var stream = response.GetResponseStream())
            //{ pictureEdit1.Image = Bitmap.FromStream(stream); }
            pictureEdit2.EditValue = @"http://" + "www.massgrup.com/mRoot/Foto" + "/" + c ;
            pictureEdit3.EditValue = @"http://" + "www.massgrup.com/mRoot/Foto" + "/" + s ;
            pictureEdit4.EditValue = @"http://" + "www.massgrup.com/mRoot/Foto" + "/" + k ;
        }
    }
}
