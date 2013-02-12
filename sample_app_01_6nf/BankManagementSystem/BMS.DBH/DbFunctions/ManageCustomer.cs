using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BMS.CORE;
using System.Data.SqlClient;
using System.Data;

namespace BMS.DBH.DbFunctions
{
    public class ManageCustomer
    {
        /// <summary>
        /// insert the customer details to the db 
        /// tables by calling to SP insertCustomer
        /// customer obj should be pass as input
        /// </summary>
        /// <param name="customer"></param>
        public void insertCustomer(Customer customer)
        {
            DbConnect dbConnect = new DbConnect();
            SqlConnection con = dbConnect.getDbConnection();
            
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insertCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@customerId", customer.customerId));
                cmd.Parameters.Add(new SqlParameter("@name", customer.name));
                cmd.Parameters.Add(new SqlParameter("@address", customer.address));
                cmd.Parameters.Add(new SqlParameter("@email", customer.email));
                cmd.Parameters.Add(new SqlParameter("@contact", customer.contact));
                cmd.Parameters.Add(new SqlParameter("@name", customer.name));
                //SqlDataReader read = null;
                //read = cmd.ExecuteReader();
                //read.Read();
                //string name = Convert.ToString(read["name"]);
                cmd.ExecuteNonQuery();
                //con.Close();
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
        /// update the customer data in db tables
        /// by calling several SPs
        /// </summary>
        /// <param name="customer"></param>
        public void updateCustomer(Customer customer)
        {
            DbConnect dbConnect = new DbConnect();
            SqlConnection con = dbConnect.getDbConnection();

            try{

                con.Open();
                SqlCommand cmd1 = new SqlCommand("updateCustomerName", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add(new SqlParameter("@customerId", customer.customerId));
                cmd1.Parameters.Add(new SqlParameter("@newName", customer.name));
                cmd1.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("updateCustomerAddress", con);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Add(new SqlParameter("@customerId", customer.customerId));
                cmd2.Parameters.Add(new SqlParameter("@newAddress", customer.address));
                cmd2.ExecuteNonQuery();

                SqlCommand cmd3 = new SqlCommand("updateCustomerEmail", con);
                cmd3.CommandType = CommandType.StoredProcedure;
                cmd3.Parameters.Add(new SqlParameter("@customerId", customer.customerId));
                cmd3.Parameters.Add(new SqlParameter("@newEmail", customer.email));
                cmd3.ExecuteNonQuery();

                SqlCommand cmd4 = new SqlCommand("updateCustomerContact", con);
                cmd4.CommandType = CommandType.StoredProcedure;
                cmd4.Parameters.Add(new SqlParameter("@customerId", customer.customerId));
                cmd4.Parameters.Add(new SqlParameter("@newContact", customer.contact));
                cmd4.ExecuteNonQuery();

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
        /// return the customer details for an one customer
        /// and a given time period as list of customer
        /// and customer Id
        /// stil not consder the isDeleted field
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public List<Customer> searchCustomer(string customerId,string fromDateTime,string toDateTime)
        {
            DbConnect dbConnect = new DbConnect();
            SqlConnection con = dbConnect.getDbConnection();
            List<Customer> customerList = new List<Customer>();

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("searchCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@customerId", customerId ));
                cmd.Parameters.Add(new SqlParameter("@fromDateTime", fromDateTime));
                cmd.Parameters.Add(new SqlParameter("@toDateTime", toDateTime));
                SqlDataReader read = null;
                read = cmd.ExecuteReader();
                int no_of_raws = getRawCount(read);

                while (read.Read())
                {
                    string customer_name = read["name"].ToString();
                    Customer customer = new Customer(customerId,customer_name,"","","");
                    customerList.Add(customer);
                }

                read.NextResult();
                int i=0;
                while (read.Read() && (i < customerList.Count))
                {
                    string customer_address = read["address"].ToString();
                    customerList[i].address = customer_address;
                    i++;
                }

                read.NextResult();
                int j = 0;
                while (read.Read() && (j < customerList.Count))
                {
                    string customer_email = read["email"].ToString();
                    customerList[j].email = customer_email;
                    j++;
                }

                read.NextResult();
                int k = 0;
                while (read.Read() && (k < customerList.Count))
                {
                    string customer_contact = read["contactNo"].ToString();
                    customerList[k].contact = customer_contact;
                    k++;
                }

                //for (int i = 0; i < no_of_raws; i++)
                //{


                //    // Customer customer = new Customer();
                //    string customer_name = null;
                //    string customer_address = null;
                //    string customer_email = null;
                //    string customer_cantact = null;
                //    if (read.Read())
                //    {
                //        customer_name = read["name"].ToString();
                //    }
                //    read.NextResult();  // to go address table
                //    if (read.Read())
                //    {
                //        customer_address = read["address"].ToString();
                //    }
                //    read.NextResult();  // to go email table
                //    if (read.Read())
                //    {
                //        customer_email = read["email"].ToString();
                //    }
                //    read.NextResult();  // to go contact table
                //    if (read.Read())
                //    {
                //        customer_cantact = read["contactNo"].ToString();
                //    }

                //    Customer customer = new Customer(customerId, customer_name, customer_address, customer_email, customer_cantact);
                //    customerList.Add(customer);
                //}
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return customerList;
        }

        /// <summary>
        /// get the numbser of raws 
        /// from the sql data reader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public int getRawCount(SqlDataReader reader)
        {

            DataTable dt = new DataTable();
            dt.Load(reader);
            int count = dt.Rows.Count;
            return count;

        }

        /// <summary>
        /// calling all customer related delete
        /// SPs for a givan customer
        /// </summary>
        /// <param name="customer"></param>
        public void deleteCustomer(Customer customer)
        {
            DbConnect dbConnect = new DbConnect();
            SqlConnection con = dbConnect.getDbConnection();

            try
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("deleteCustomerName", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add(new SqlParameter("@customerId", customer.customerId));
                cmd1.Parameters.Add(new SqlParameter("@name", customer.name));
                cmd1.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("deleteCustomerAddress", con);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Add(new SqlParameter("@customerId", customer.customerId));
                cmd2.Parameters.Add(new SqlParameter("@address", customer.address));
                cmd2.ExecuteNonQuery();

                SqlCommand cmd3 = new SqlCommand("deleteCustomerEmail", con);
                cmd3.CommandType = CommandType.StoredProcedure;
                cmd3.Parameters.Add(new SqlParameter("@customerId", customer.customerId));
                cmd3.Parameters.Add(new SqlParameter("@email", customer.email));
                cmd3.ExecuteNonQuery();

                SqlCommand cmd4 = new SqlCommand("deleteCustomerContact", con);
                cmd4.CommandType = CommandType.StoredProcedure;
                cmd4.Parameters.Add(new SqlParameter("@customerId", customer.customerId));
                cmd4.Parameters.Add(new SqlParameter("@contact", customer.contact));
                cmd4.ExecuteNonQuery();

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
