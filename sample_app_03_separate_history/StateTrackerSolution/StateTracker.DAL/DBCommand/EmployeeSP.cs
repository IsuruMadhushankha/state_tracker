using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using StateTracker.Core.DomainObjects;

namespace StateTracker.DAL.DBCommand
{
    public class EmployeeSP
    {
        // define sql connection variable
        SqlConnection dbcon; 

        // create db connection
        public void createConnection () {
           DBConnect db =  new DBConnect();
           dbcon = db.makeConnection();
        }
    
        // define insert employee function
        public int addEmployee(string empId, string name, string address, string email, string conatacts)
       {
           createConnection();
           try
           {
               dbcon.Open();
               SqlCommand cmd = new SqlCommand("addEmployee", dbcon);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@empId", empId);
               cmd.Parameters.AddWithValue("@name", name);
               cmd.Parameters.AddWithValue("@address", address);
               cmd.Parameters.AddWithValue("@email", email);
               cmd.ExecuteNonQuery();
               return 1;
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {
               dbcon.Close();
           }
       }
        //Define a function to add temporal record to seperate table
        public int addTempEmployee(string empId, string name, string address, string email, string conatacts, DateTime date)
        {
            createConnection();
            try
            {
                dbcon.Open();
                SqlCommand cmd = new SqlCommand("addTempEmployee", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empId", empId);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@created", date);
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbcon.Close();
            }
        }

        // define get employee from database
        public List<Employee> getEmployee(string empId)
        {
            createConnection();
            try
            {
                dbcon.Open();
                SqlCommand cmd = new SqlCommand("getEmployee", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@empId", empId));
                SqlDataReader reader = null;
                reader = cmd.ExecuteReader();
                List<Employee> empList = new List<Employee>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.EmpId = Convert.ToString(reader["empId"]);
                        employee.Name = Convert.ToString(reader["name"]);
                        employee.Address = Convert.ToString(reader["address"]);
                        employee.Email = Convert.ToString(reader["email"]);
                        empList.Add(employee);
                    }
                }

                return empList;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbcon.Close();
            }
        }

        // define function to update record in employee
        public int updateEmployee(string empId, string name, string address, string email, string conatacts)
        {
            createConnection();
            List<Employee> singleEmployee = new List<Employee>();
            singleEmployee = this.getEmployee(empId);
            this.addTempEmployee(Convert.ToString(singleEmployee[0].EmpId), Convert.ToString(singleEmployee[0].Name), Convert.ToString(singleEmployee[0].Address), Convert.ToString(singleEmployee[0].ContactNo), Convert.ToString(singleEmployee[0].ContactNo), DateTime.Now);

            try
            {
                dbcon.Open();
                SqlCommand cmd = new SqlCommand("updateEmployee", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@empId", empId));
                cmd.Parameters.Add(new SqlParameter("@name", name));
                cmd.Parameters.Add(new SqlParameter("@address", address));
                cmd.Parameters.Add(new SqlParameter("@email", email));
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbcon.Close();
            }
        }
       
        //define function to delete record in employee table
        public int deleteEmployee(string empId)
        {
            createConnection();
            List<Employee> singleEmployee = new List<Employee>();
            singleEmployee = this.getEmployee(empId);
            this.addTempEmployee(Convert.ToString(singleEmployee[0]), Convert.ToString(singleEmployee[1]), Convert.ToString(singleEmployee[2]), Convert.ToString(singleEmployee[3]), Convert.ToString(singleEmployee[4]), DateTime.Now);

            try
            {
                dbcon.Open();
                SqlCommand cmd = new SqlCommand("deleteEmployee", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@empId", empId));
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbcon.Close();
            }
        }

        // define a function to get temporal data in seperate table between two dates
        public List<Employee> getTempEmployee(string empId, DateTime startDate, DateTime endDate)
        {
            createConnection();
            try
            {
                dbcon.Open();
                SqlCommand cmd = new SqlCommand("getTempEmployee", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@empId", empId));
                cmd.Parameters.Add(new SqlParameter("@startDate", startDate));
                cmd.Parameters.Add(new SqlParameter("@endDate", endDate));
                SqlDataReader reader = null;
                reader = cmd.ExecuteReader();
                List<Employee> empList = new List<Employee>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.EmpId = Convert.ToString(reader["empId"]);
                        employee.Name = Convert.ToString(reader["name"]);
                        employee.Address = Convert.ToString(reader["address"]);
                        employee.Email = Convert.ToString(reader["email"]);
                        empList.Add(employee);
                    }
                }

                return empList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbcon.Close();
            }
        }

        // define function to count the number of records
        //public int countRecord(string empId)
        //{
        //    int count=0;
        //    try
        //    {
        //        dbcon.Open();
        //        SqlCommand cmd = new SqlCommand("getTempEmployee", dbcon);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlDataReader read = null;
        //        read = cmd.ExecuteReader();
        //        while (read.Read())
        //        {
        //             count = Convert.ToInt32(read["EMPREC"]);
        //        }
        //        return count;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        dbcon.Close();
        //    }
        //}
    
}

}
