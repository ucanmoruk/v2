using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace StokTakip
{
    class sqlbaglanti
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=mssql10.trwww.com,1433; Initial Catalog = massgrup_mass; persist Security Info = True; User ID = masslab; Password = 123qweASD_*");
            baglan.Open();
            return baglan;



            //if (Giris.db == "1")
            //{
            //    SqlConnection baglan = new SqlConnection(@"Data Source=mssql10.trwww.com,1433; Initial Catalog = massgrup_mass; persist Security Info = True; User ID = masslab; Password = 123qweASD_*");
            //    baglan.Open();
            //    return baglan;
            //}
            //else
            //{
            //    //  SqlConnection baglan = new SqlConnection(@"Data Source=Oguzhan,1433; Initial Catalog = Stok; persist Security Info = True; User ID = sa; Password = 12344");
            //    SqlConnection baglan = new SqlConnection(@"Data Source=Oguzhan,1433; Initial Catalog = mass; persist Security Info = True; User ID = sa; Password = 12344");

            //    baglan.Open();
            //    return baglan;
            //}
            ////  SqlConnection baglan = new SqlConnection(@"Data Source=mssql10.trwww.com,1433; Initial Catalog = massgrup_mass; persist Security Info = True; User ID = masslab; Password = 123qweASD_*");


        }
    }
}
