using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using BMS.DBH.DbFunctions;
using BMS.CORE;

namespace BMS.DBH.DbFunctions
{
    public class ManageBranch
    {
        public void insertBranch(string branchCode,string address , string contact,string managerId)
        {
            DbConnect dbConnect = new DbConnect();
            SqlConnection con = dbConnect.getDbConnection();

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insertBranch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@branchCode", branchCode));
                cmd.Parameters.Add(new SqlParameter("@address", address));
                cmd.Parameters.Add(new SqlParameter("@contact", contact));
                cmd.Parameters.Add(new SqlParameter("@managerId", managerId));
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
