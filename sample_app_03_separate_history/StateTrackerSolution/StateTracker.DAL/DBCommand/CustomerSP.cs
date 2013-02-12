using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using StateTracker.Core.DomainObjects;

namespace StateTracker.DAL.DBCommand
{
    /// <summary>
    /// This class will handle database connections in customer functions
    /// </summary>
    public class CustomerSP
    {
        // define sql connection variable
        SqlConnection dbcon;

        // create db connection
        public void createConnection()
        {
            DBConnect db = new DBConnect();
            dbcon = db.makeConnection();
        }

        // define insert customer function
        public int addCustomer(string customerId, string name, string address, string email, string contacts)
        {
            this.addTempCustomer(customerId, name, address, email, contacts, "create", DateTime.Now);
            createConnection();
            try
            {
                dbcon.Open();
                SqlCommand cmd = new SqlCommand("addCustomer", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@contactNo", contacts);
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
        public int addTempCustomer(string customerId, string name, string address, string email, string contacts, string state, DateTime date)
        {
            createConnection();
            try
            {
                dbcon.Open();
                SqlCommand cmd = new SqlCommand("addTempCustomer", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@contactNo", contacts);
                cmd.Parameters.AddWithValue("@state", state);
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
        public List<Customer> getCustomer(string customerId)
        {
            createConnection();
            try
            {
                dbcon.Open();
                SqlCommand cmd = new SqlCommand("getCustomer", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@customerId", customerId));
                SqlDataReader reader = null;
                reader = cmd.ExecuteReader();
                List<Customer> empList = new List<Customer>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Customer customer = new Customer();
                        customer.CustomerId = Convert.ToString(reader["customerId"]);
                        customer.Name = Convert.ToString(reader["name"]);
                        customer.Address = Convert.ToString(reader["address"]);
                        customer.Email = Convert.ToString(reader["email"]);
                        customer.ContactNo = Convert.ToString(reader["contactNo"]);
                        empList.Add(customer);
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
        public int updateCustomer(string customerId, string name, string address, string email, string contacts)
        {
            createConnection();
            List<Customer> singleCustomer = new List<Customer>();
            singleCustomer = this.getCustomer(customerId);
            this.addTempCustomer(Convert.ToString(singleCustomer[0].CustomerId), Convert.ToString(singleCustomer[0].Name), Convert.ToString(singleCustomer[0].Address), Convert.ToString(singleCustomer[0].Email), Convert.ToString(singleCustomer[0].ContactNo), "update", DateTime.Now);

            try
            {
                dbcon.Open();
                SqlCommand cmd = new SqlCommand("updateCustomer", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@customerId", customerId));
                cmd.Parameters.Add(new SqlParameter("@name", name));
                cmd.Parameters.Add(new SqlParameter("@address", address));
                cmd.Parameters.Add(new SqlParameter("@email", email));
                cmd.Parameters.Add(new SqlParameter("@contactNo", contacts));
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
        public int deleteCustomer(string customerId)
        {
            createConnection();
            List<Customer> singleCustomer = new List<Customer>();
            singleCustomer = this.getCustomer(customerId);
            this.addTempCustomer(Convert.ToString(singleCustomer[0].CustomerId), Convert.ToString(singleCustomer[0].Name), Convert.ToString(singleCustomer[0].Address), Convert.ToString(singleCustomer[0].Email), Convert.ToString(singleCustomer[0].ContactNo), "delete", DateTime.Now);

            try
            {
                dbcon.Open();
                SqlCommand cmd = new SqlCommand("deleteCustomer", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@customerId", customerId));
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
        public List<Customer> getTempCustomer(string customerId, DateTime startDate, DateTime endDate)
        {
            createConnection();
            try
            {
                dbcon.Open();
                SqlCommand cmd = new SqlCommand("getTempCustomer", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@customerId", customerId));
                cmd.Parameters.Add(new SqlParameter("@startDate", startDate));
                cmd.Parameters.Add(new SqlParameter("@endDate", endDate));
                SqlDataReader reader = null;
                reader = cmd.ExecuteReader();
                List<Customer> empList = new List<Customer>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Customer customer = new Customer();
                        customer.CustomerId = Convert.ToString(reader["empId"]);
                        customer.Name = Convert.ToString(reader["name"]);
                        customer.Address = Convert.ToString(reader["address"]);
                        customer.Email = Convert.ToString(reader["email"]);
                        customer.ContactNo = Convert.ToString(reader["contactNo"]);
                        empList.Add(customer);
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

        //check temp customer exisit
        public int checkTempCustomer(string customerId)
        {
            createConnection();
            try
            {
                dbcon.Open();
                SqlCommand cmd = new SqlCommand("checkTempCustomer", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@customerId", customerId));
                SqlDataReader reader = null;
                reader = cmd.ExecuteReader();
                reader.Read();
                return Convert.ToInt16(reader["has"]);


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

        public List<Customer> getCustomerHistory(string customerId, DateTime start, DateTime end)
        {
            createConnection();
            try
            {
                dbcon.Open();
                SqlCommand cmd = new SqlCommand("getCustomerHistory", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@customerId", customerId));
                cmd.Parameters.Add(new SqlParameter("@startDate", start));
                cmd.Parameters.Add(new SqlParameter("@endDate", end));
                SqlDataReader reader = null;
                reader = cmd.ExecuteReader();
                List<Customer> empList = new List<Customer>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Customer customer = new Customer();
                        customer.Name = Convert.ToString(reader["name"]);
                        customer.Address = Convert.ToString(reader["address"]);
                        customer.Email = Convert.ToString(reader["email"]);
                        customer.ContactNo = Convert.ToString(reader["contactNo"]);
                        customer.Status = Convert.ToString(reader["state"]);
                        customer.Created = Convert.ToString(reader["created"]);
                        empList.Add(customer);
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


    }
}
