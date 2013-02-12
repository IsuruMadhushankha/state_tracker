using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BMS.CORE;
using BMS.DBH.DbFunctions;

namespace BMS.BL
{
    public class SearchCustomer
    {
        /// <summary>
        /// returns list of cuatomer objs for 
        /// given customerID and time period
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="fromDateTime"></param>
        /// <param name="ToDateTime"></param>
        /// <returns></returns>
        public List<Customer> searchCustomer(string customerId,string fromDateTime, string ToDateTime)
        {
            ManageCustomer mc = new ManageCustomer();
            List<Customer> customerList = mc.searchCustomer(customerId, fromDateTime, ToDateTime);
            return customerList;
        }
    }
}
