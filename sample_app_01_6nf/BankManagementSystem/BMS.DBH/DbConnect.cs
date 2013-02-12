using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace BMS.DBH
{
    public class DbConnect
    {
        public SqlConnection getDbConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ("Data Source=ISURU-PC\\SQLEXPRESS2;Initial Catalog=BankDatabase6NF;Integrated Security=True");
            return con;
        }
    }
}
