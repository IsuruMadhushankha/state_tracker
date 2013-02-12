using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BMS.DBH.DbFunctions
{
    public class ManageEmployee
    {
        public void insertEmployee(string empId, string name, string address, string email, string contactNo)
        {
            DbConnect dbConnect = new DbConnect();
            SqlConnection con = dbConnect.getDbConnection();

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insertEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@empId", empId));
                cmd.Parameters.Add(new SqlParameter("@name", name));
                cmd.Parameters.Add(new SqlParameter("@address", address));
                cmd.Parameters.Add(new SqlParameter("@email", email));
                cmd.Parameters.Add(new SqlParameter("@contact", contactNo));
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
