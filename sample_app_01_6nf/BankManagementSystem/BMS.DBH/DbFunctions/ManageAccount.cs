using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using BMS.CORE;

namespace BMS.DBH.DbFunctions
{
    public class ManageAccount
    {   
        /// <summary>
        /// insert details of the newly created
        /// account for first time
        /// </summary>
        /// <param name="accNo"></param>
        /// <param name="balance"></param>
        /// <param name="branchCode"></param>
        public void insertAccount(string accNo, string balance, string branchCode)
        {
            DbConnect dbConnect = new DbConnect();
            SqlConnection con = dbConnect.getDbConnection();
            
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insertAccount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@accNo",accNo));
                cmd.Parameters.Add(new SqlParameter("@balance", balance));
                cmd.Parameters.Add(new SqlParameter("@branchCode", branchCode));
                //SqlDataReader read = null;
                //read = cmd.ExecuteReader();
                //read.Read();
                //string name = Convert.ToString(read["name"]);
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

        /// <summary>
        /// input account no and
        /// current balance
        /// note: balnce should be calculated 
        /// in some where else before paas to
        /// this function
        /// </summary>
        /// <param name="accNo"></param>
        /// <param name="balance"></param>
        public void updateAccount(string accNo,string balance)
        {
            DbConnect dbConnect = new DbConnect();
            SqlConnection con = dbConnect.getDbConnection();

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("updateAccount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@accNo", accNo));
                cmd.Parameters.Add(new SqlParameter("@balance", balance));
                //SqlDataReader read = null;
                //read = cmd.ExecuteReader();
                //read.Read();
                //string name = Convert.ToString(read["name"]);
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

        /// <summary>
        /// To search the balance for the given time
        /// period 
        /// </summary>
        /// <param name="accNo"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        public List<BalanceObj> searchBalance(string accNo, string fromDateTime, string toDateTime)
        {
            DbConnect dbConnect = new DbConnect();
            SqlConnection con = dbConnect.getDbConnection();
            List<BalanceObj> balanceList = new List<BalanceObj>();

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("searchBalance", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@accNo", accNo));
                cmd.Parameters.Add(new SqlParameter("@fromDateTime", fromDateTime));
                cmd.Parameters.Add(new SqlParameter("@toDateTime", toDateTime));
                SqlDataReader read = null;
                read = cmd.ExecuteReader();
                    // to get top balance
                if (read.Read())
                {
                    BalanceObj bObj = new BalanceObj(read["name"].ToString(), read["time"].ToString());
                    balanceList.Add(bObj);
                }
                    // to get balances between t1 - t2
                read.NextResult();
                while (read.Read())
                {
                    BalanceObj bObj = new BalanceObj(read["name"].ToString(), read["time"].ToString());
                    balanceList.Add(bObj);
                }
                    // to get bottom balance
                read.NextResult();
                if (read.Read())
                {
                    BalanceObj bObj = new BalanceObj(read["name"].ToString(), read["time"].ToString());
                    balanceList.Add(bObj);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return balanceList;
        }

        /// <summary>
        /// inputs account number
        /// returns current balance of the 
        /// given account
        /// </summary>
        /// <param name="accNo"></param>
        /// <returns></returns>
        public string getCurrentBalance(string accNo)
        {
            DbConnect dbConnect = new DbConnect();
            SqlConnection con = dbConnect.getDbConnection();
            string current_balance = null;

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("getCurrentBalance", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@accNo", accNo));
                SqlDataReader read = null;
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    current_balance = read["balance"].ToString(); 
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return current_balance;
        }


        /// <summary>
        /// inputs particuler time
        /// returns balance corresponding to 
        /// that time
        /// </summary>
        /// <param name="accNo"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public string getBalanceForTime(string accNo,string time)
        {
            DbConnect dbConnect = new DbConnect();
            SqlConnection con = dbConnect.getDbConnection();
            string required_balance = null;

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("getBalnceForTime", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@accNo", accNo));
                cmd.Parameters.Add(new SqlParameter("@time", time));
                SqlDataReader read = null;
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    required_balance = read["balance"].ToString();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return required_balance;
        }

        /// <summary>
        /// delete an account, but 
        /// fake deleting change the isdelete attribute
        /// </summary>
        /// <param name="accNo"></param>
        /// <returns></returns>
        public Boolean deleteAccount(string accNo)
        {
            ManageBranch mb = new ManageBranch();
            string branchCode = mb.getCurrentBranchCode(accNo); 

            DbConnect dbConnect = new DbConnect();
            SqlConnection con = dbConnect.getDbConnection();

            try
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("deleteAccountBalance", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add(new SqlParameter("@accNo", accNo));
                cmd1.Parameters.Add(new SqlParameter("@currentBalance", getCurrentBalance(accNo)));
                cmd1.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("deleteAccountBranch", con);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Add(new SqlParameter("@accNo", accNo));
                cmd2.Parameters.Add(new SqlParameter("@currentBranch", branchCode));
                cmd2.ExecuteNonQuery();

                SqlCommand cmd3 = new SqlCommand("deleteAccountManagement", con);
                cmd3.CommandType = CommandType.StoredProcedure;
                cmd3.Parameters.Add(new SqlParameter("@accNo", accNo));
                //cmd3.Parameters.Add(new SqlParameter("@", customer.email));
                cmd3.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

            ManageCustomer mc = new ManageCustomer();
            string customerId = mc.getCustomrId(accNo);

            if (mc.getCustomerCount(customerId) == 1)
            {
                Customer customer = mc.getCustomerDetails(accNo);
                mc.deleteCustomer(customer);
            }

            
            //try
            //{
            //    con.Open();
            //    SqlCommand cmd1 = new SqlCommand("deleteCustomerName", con);
            //    cmd1.CommandType = CommandType.StoredProcedure;
            //    cmd1.Parameters.Add(new SqlParameter("@customerId", customer.customerId));
            //    cmd1.Parameters.Add(new SqlParameter("@name", customer.name));
            //    cmd1.ExecuteNonQuery();

            //    SqlCommand cmd2 = new SqlCommand("deleteCustomerAddress", con);
            //    cmd2.CommandType = CommandType.StoredProcedure;
            //    cmd2.Parameters.Add(new SqlParameter("@customerId", customer.customerId));
            //    cmd2.Parameters.Add(new SqlParameter("@currentAddress", customer.name));
            //    cmd2.ExecuteNonQuery();
                
            //    SqlCommand cmd3 = new SqlCommand("deleteCustomerEmail", con);
            //    cmd3.CommandType = CommandType.StoredProcedure;
            //    cmd3.Parameters.Add(new SqlParameter("@customerId", customer.customerId));
            //    cmd3.Parameters.Add(new SqlParameter("@currentEmail", customer.email));
            //    cmd3.ExecuteNonQuery();
                               
            //    SqlCommand cmd4 = new SqlCommand("deleteCustomerContact", con);
            //    cmd4.CommandType = CommandType.StoredProcedure;
            //    cmd4.Parameters.Add(new SqlParameter("@customerId", customer.customerId));
            //    cmd4.Parameters.Add(new SqlParameter("@currentContact", customer.contact));
            //    cmd4.ExecuteNonQuery();
                
            //}
            //catch (SqlException ex)
            //{
            //    throw ex;
            //}
            //finally
            //{
            //    con.Close();
            //}

            return true;    
        }


    }
}
