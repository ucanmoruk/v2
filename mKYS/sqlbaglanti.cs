using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace mKYS
{
    class sqlbaglanti
    {
        public SqlConnection baglanti()
        {
           // SqlConnection baglan = new SqlConnection(@"Data Source=mssql04.trwww.com,1433; Initial Catalog = massgrup_root; persist Security Info = True; User ID = masslab; Password = 123qweASD_*");
            SqlConnection baglan = new SqlConnection(@"Data Source=mssql04.trwww.com,1433; Initial Catalog = massgrup_root; persist Security Info = True; User ID = cosmoroot; Password = 3Y3s!52qw");
            baglan.Open();
            return baglan;

            // !88n2ee5Q
            // cosmo- 2T^5k3f0g
        }// FfU_Gw48@aseltk5
      
    }

    class sqlunique
    {
        public SqlConnection baglanti()
        {
            // SqlConnection baglan = new SqlConnection(@"Data Source=mssql04.trwww.com,1433; Initial Catalog = massgrup_root; persist Security Info = True; User ID = masslab; Password = 123qweASD_*");
            SqlConnection baglan = new SqlConnection(@"Data Source=mssql04.trwww.com,1433; Initial Catalog = massgrup_root; persist Security Info = True; User ID = cosmoroot; Password = 3Y3s!52qw");
            baglan.Open();
            return baglan;

        }
    }
}
