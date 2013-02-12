using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StateTracker.Core.DomainObjects;
using System.Data;
using System.Data.SqlClient;

namespace StateTracker.DAL.DBCommand
{
    /// <summary>
    /// this class will handle all the database functions in account
    /// </summary>
    public class AccountSP
    {
        SqlConnection dbcon;

        // create db connection
        public void createConnection()
        {
            DBConnect db = new DBConnect();
            dbcon = db.makeConnection();
        }

        //create account management object
        AccManagementSP amSP = new AccManagementSP();

        // define insert employee function
        public int createAccount(string accNo, double balance, string branchId)
        {
                this.createTempAccount(accNo, branchId, balance, "create", DateTime.Now);
                createConnection();
                try
                {
                    dbcon.Open();
                    SqlCommand cmd = new SqlCommand("addAccount", dbcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accNo", accNo);
                    cmd.Parameters.AddWithValue("@balance", balance);
                    cmd.Parameters.AddWithValue("@branchId", branchId);
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
        public int createTempAccount(string accNo,string branchId, double balance, string state, DateTime date)
        {
            createConnection();

            try
            {
                dbcon.Open();
                SqlCommand cmd = new SqlCommand("addTempAccount", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@accNo", accNo);
                cmd.Parameters.AddWithValue("@branchId", branchId);
                cmd.Parameters.AddWithValue("@balance", balance);
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
        public List<Account> getAccountBalance(string accNo)
        {
            
                createConnection();
                try
                {
                    dbcon.Open();
                    SqlCommand cmd = new SqlCommand("getAccount", dbcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@accNo", accNo));
                    SqlDataReader reader = null;
                    reader = cmd.ExecuteReader();
                    List<Account> accList = new List<Account>();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Account account = new Account();
                            account.AccNo = Convert.ToString(reader["accNo"]);
                            account.Balance = Convert.ToDouble(reader["balance"]);
                            account.BranchId = Convert.ToString(reader["branchId"]);
                            accList.Add(account);
                        }
                    }

                    return accList;

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
        public int updateAccount(string accNo, double amount, bool credit)
        {
            createConnection();
            double total = 0;
            List<Account> singleAccount = new List<Account>();
            singleAccount = this.getAccountBalance(accNo);
            if (credit)
            {
                total = amount + Convert.ToDouble(singleAccount[0].Balance);
                this.createTempAccount(Convert.ToString(singleAccount[0].AccNo), Convert.ToString(singleAccount[0].BranchId), total, "update", DateTime.Now);
            }
            else
            {
                total = Convert.ToDouble(singleAccount[0].Balance) - amount;
                this.createTempAccount(Convert.ToString(singleAccount[0].AccNo), Convert.ToString(singleAccount[0].BranchId), total, "update", DateTime.Now);
            }

            try
            {
                dbcon.Open();
                SqlCommand cmd = new SqlCommand("updateAccount", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@accNo", accNo));
                cmd.Parameters.Add(new SqlParameter("@balance", total));
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
        public int deleteAccount(string accNo)
        {
            createConnection();
            List<Account> singleAccount = new List<Account>();
            singleAccount = this.getAccountBalance(accNo);
            this.createTempAccount(Convert.ToString(singleAccount[0].AccNo), Convert.ToString(singleAccount[0].BranchId), Convert.ToDouble(singleAccount[0].Balance), "delete", DateTime.Now);
           
            try
            {
                dbcon.Open();
                SqlCommand cmd = new SqlCommand("deleteAccount", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@accNo", accNo));
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
        public List<Account> getTempAccount(string accNo, DateTime startDate, DateTime endDate)
        {
            createConnection();

            try
            {
                dbcon.Open();
                SqlCommand cmd = new SqlCommand("getTempAccount", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@accNo", accNo));
                cmd.Parameters.Add(new SqlParameter("@startDate", startDate));
                cmd.Parameters.Add(new SqlParameter("@endDate", endDate));
                SqlDataReader reader = null;
                reader = cmd.ExecuteReader();
                List<Account> accList = new List<Account>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Account account = new Account();
                        account.AccNo = Convert.ToString(reader["accId"]);
                        account.Balance = Convert.ToDouble(reader["balance"]);
                        account.BranchId = Convert.ToString(reader["branchId"]);
                        accList.Add(account);
                    }
                }

                return accList;

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

        //Get balance by day
        public double getBalanceByDate(string accNo, DateTime date)
        {
                double balance;
                createConnection();
                try
                {
                    dbcon.Open();
                    SqlCommand cmd = new SqlCommand("getBalance", dbcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@accNo", accNo));
                    cmd.Parameters.Add(new SqlParameter("@datetime", date));
                    SqlDataReader reader = null;
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    balance = Convert.ToDouble(reader["balance"]);
                    return balance;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    dbcon.Close();
                }
           // }
           // return 0;
        }

        public int checkTempAccountHas(string accNo)
        {          
                createConnection();
                try
                {
                    dbcon.Open();
                    SqlCommand cmd = new SqlCommand("checkTemAccount", dbcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@accNo", accNo));
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

        public List<CreditDebit> getCreditDebitHistory(string accNo, DateTime start, DateTime end)
        {
             createConnection();
                try
                {
                    dbcon.Open();
                    SqlCommand cmd = new SqlCommand("getCreditDebit", dbcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@accNo", accNo));
                    cmd.Parameters.Add(new SqlParameter("@startDate", start));
                    cmd.Parameters.Add(new SqlParameter("@endDate", end));
                    SqlDataReader reader = null;
                    reader = cmd.ExecuteReader();
                    List<CreditDebit> accList = new List<CreditDebit>();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            CreditDebit account = new CreditDebit();
                            account.Balance = Convert.ToDouble(reader["balance"]);
                            account.CreateDate = Convert.ToString(reader["created"]);
                            accList.Add(account);
                        }
                    }

                    return accList;

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
