using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace StateTracker.DAL.DBCommand
{
    /// <summary>
    /// This class handles account and customer database connections
    /// </summary>
    public class AccManagementSP
    {
        // define sql connection variable
        SqlConnection dbcon;

        // create db connection
        public void createConnection()
        {
            DBConnect db = new DBConnect();
            dbcon = db.makeConnection();
        }

        // check weather customer exsist or not
        public int checkCustomer(string customerId)
        {
            int check = 0;
            createConnection();
            try
            {
                dbcon.Open();
                SqlCommand cmd = new SqlCommand("checkCustomer", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customerId", customerId);
                SqlDataReader reader = null;
                reader = cmd.ExecuteReader();
                
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        check = Convert.ToInt16(reader["Id"]);
                    }
                }

                return check;
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

        //check account exsist or not
        public int checkAccount(string accNo)
        {
            int check = 0;
            createConnection();
            try
            {
                dbcon.Open();
                SqlCommand cmd = new SqlCommand("checkAccount", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@accId", accNo);
                SqlDataReader reader = null;
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        check = Convert.ToInt16(reader["accId"]);
                    }
                }

                return check;
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

        // add customer account retion in account management
        public int addAccountManagement(string customerId, string accId)
        {
            createConnection();
            try
            {
                dbcon.Open();
                SqlCommand cmd = new SqlCommand("addAccountManagement", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@accNo", accId);
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

        // select customer for perticular account
        public List<string> selectCustomers(string accNo)
        {
            createConnection();
            List<string> customerList = new List<string>();

            try
            {
                dbcon.Open();
                SqlCommand cmd = new SqlCommand("selectCustomers", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@accNo", accNo);
                SqlDataReader reader = null;
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        customerList.Add(Convert.ToString(reader["custId"])); // add customerId into a list
                    }         
                }            
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbcon.Close();
            }
            return customerList;
        }


        // count number of account customer has
        public int countCustomerAccounts(string customerId)
        {
            
            try
            {
                dbcon.Open();
                SqlCommand cmd = new SqlCommand("customerAccounts", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@custId", customerId);
                SqlDataReader reader = null;
                reader = cmd.ExecuteReader();
                reader.Read();
                if (Convert.ToInt16(reader["NoCustomers"]) == 1)    // add customerId into a list
                {
                    return 1;
                }
                    return 0;
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

        // delete acc management row
        public int deleteAccManagement(string custId, string accId)
        {         
            this.addTempAccManagement(custId, accId, "delete");
            createConnection();
            try
            {
                dbcon.Open();
                SqlCommand cmd = new SqlCommand("deleteAccManagement", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@accId", accId));
                cmd.Parameters.Add(new SqlParameter("@custId", custId));
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
        
        // add temp acc management 
        public int addTempAccManagement(string custId, string accId, string state)
        {
            createConnection();
            try
            {
                dbcon.Open();
                SqlCommand cmd = new SqlCommand("addTempAccManagement", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@accId", accId);
                cmd.Parameters.AddWithValue("@custId", custId);
                cmd.Parameters.AddWithValue("@state", state);
                cmd.Parameters.AddWithValue("@created", DateTime.Now);
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

    }
}
