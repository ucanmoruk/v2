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
            SqlConnection baglan = new SqlConnection(@"Data Source=mssql04.trwww.com,1433; Initial Catalog = massgrup_root; persist Security Info = True; User ID = masslab; Password = 123qweASD_*");
            baglan.Open();
            return baglan;

            // !88n2ee5Q
        }
    }
}
