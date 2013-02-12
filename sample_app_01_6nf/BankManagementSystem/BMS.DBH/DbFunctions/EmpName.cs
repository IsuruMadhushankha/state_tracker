using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BMS.DBH.DbFunctions
{
    public class EmpName
    {
        public string getEmpName(string id)
        {

            DbConnect dbConnect = new DbConnect();
            SqlConnection con = dbConnect.getDbConnection();
            string empId="";
            con.Open();
            SqlCommand cmd = new SqlCommand("getEmpName", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@empId", id));
            SqlDataReader read = null;
            read = cmd.ExecuteReader();
            read.Read();
            string name = Convert.ToString(read["name"]);
            if (read.NextResult())
            {
                read.Read();
                empId = Convert.ToString(read["empId"]);
            }

            if (read.NextResult())
            {
                //read.Read();
                //string name2 = Convert.ToString(read["name"]);
                name = "^^^^^^^^^^^^^^^^^";
            }
            else
            {
                name = "*****************";
            }
            con.Close();
            return name;
            //return name;
        }
    }
}
