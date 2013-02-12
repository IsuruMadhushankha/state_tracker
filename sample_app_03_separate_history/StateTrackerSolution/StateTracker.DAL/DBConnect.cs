using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace StateTracker.DAL
{
    public class DBConnect
    {
        public SqlConnection makeConnection()
        {
            SqlConnection thiscon = new SqlConnection();
            thiscon.ConnectionString = ("Data Source=SENURA-PC\\SQLEXPRESS2;Initial Catalog=StateTrackedDB;Integrated Security=True");
            return thiscon;
        }
    }
}
