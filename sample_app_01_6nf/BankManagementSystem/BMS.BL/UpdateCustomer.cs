using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BMS.DBH.DbFunctions;
using BMS.CORE;

namespace BMS.BL
{
    public class UpdateCustomer
    {
        /// <summary>
        /// update the customer details 
        /// in the DB
        /// </summary>
        /// <param name="customer"></param>
        public void updateCustomer(Customer customer)
        {
            ManageCustomer mc = new ManageCustomer();
            mc.updateCustomer(customer);
        }
    }
}
