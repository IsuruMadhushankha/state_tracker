using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using StateTracker.Core.DomainObjects;

namespace StateTracker.DAL.DBCommand
{
    public class BranchSP
    {
        // define sql connection variable
        SqlConnection dbcon;

        // create db connection
        public void createConnection()
        {
            DBConnect db = new DBConnect();
            dbcon = db.makeConnection();
        }

        // define insert branch function
        public int addBranch(string branchCode,string address, string conatacts, string managerId)
        {
            createConnection();

            try
            {
                dbcon.Open();
                SqlCommand cmd = new SqlCommand("addBranch", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@branchCode", branchCode);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@contactNo", conatacts);
                cmd.Parameters.AddWithValue("@managerId", managerId);
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
        public int addTempBranch(string branchCode, string address, string conatacts,string managerId, DateTime date)
        {
            createConnection();
            try
            {
                dbcon.Open();
                SqlCommand cmd = new SqlCommand("addTempBranch", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@branchCode", branchCode);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@contactNo", conatacts);
                cmd.Parameters.AddWithValue("@managerId", managerId);
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

        // define get branch from database
        public List<Branch> getBranch(string branchCode)
        {

            createConnection();
            try
            {
                dbcon.Open();
                SqlCommand cmd = new SqlCommand("getBranch", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@branchCode", branchCode));
                SqlDataReader reader = null;
                reader = cmd.ExecuteReader();
                List<Branch> empList = new List<Branch>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Branch branch = new Branch();
                        branch.BranchCode = Convert.ToString(reader["branchCode"]);
                        branch.Address = Convert.ToString(reader["address"]);
                        branch.ContactNo = Convert.ToString(reader["contactNo"]);
                        branch.ManagerId = Convert.ToString(reader["managerId"]);
                        empList.Add(branch);
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

        // define function to update record in branch
        public int updateBranch(string branchCode, string address, string contacts,  string managerId)
        {
            createConnection();
            List<Branch> singleBranch = new List<Branch>();
            singleBranch = this.getBranch(branchCode);
            this.addTempBranch(Convert.ToString(singleBranch[0].BranchCode), Convert.ToString(singleBranch[0].Address), Convert.ToString(singleBranch[0].ContactNo), Convert.ToString(singleBranch[0].ManagerId), DateTime.Now);

            try
            {
                dbcon.Open();
                SqlCommand cmd = new SqlCommand("updateBranch", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@branchCode", branchCode));
                cmd.Parameters.Add(new SqlParameter("@address", address));
                cmd.Parameters.Add(new SqlParameter("@contactNo", contacts));
                cmd.Parameters.Add(new SqlParameter("@managerId", managerId));
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

        //define function to delete record in branch table
        public int deleteBranch(string branchCode)
        {
            createConnection();
            List<Branch> singleBranch = new List<Branch>();
            singleBranch = this.getBranch(branchCode);
            this.addTempBranch(Convert.ToString(singleBranch[0]), Convert.ToString(singleBranch[1]), Convert.ToString(singleBranch[2]), Convert.ToString(singleBranch[3]), DateTime.Now);

            try
            {
                dbcon.Open();
                SqlCommand cmd = new SqlCommand("deleteBranch", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@branchCode", branchCode));
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
        public List<Branch> getTempBranch(string branchCode, DateTime startDate, DateTime endDate)
        {
            createConnection();

            try
            {
                dbcon.Open();
                SqlCommand cmd = new SqlCommand("getTempBranch", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@branchCode", branchCode));
                cmd.Parameters.Add(new SqlParameter("@startDate", startDate));
                cmd.Parameters.Add(new SqlParameter("@endDate", endDate));
                SqlDataReader reader = null;
                reader = cmd.ExecuteReader();
                List<Branch> empList = new List<Branch>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Branch branch = new Branch();
                        branch.BranchCode = Convert.ToString(reader["branchCode"]);
                        branch.Address = Convert.ToString(reader["address"]);
                        branch.ContactNo = Convert.ToString(reader["contactNo"]);
                        branch.ManagerId = Convert.ToString(reader["managerId"]);
                        empList.Add(branch);
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
