using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StateTracker.Core.DomainObjects;
using StateTracker.DAL.DBCommand;

namespace StateTracker.BL.BLCode
{
    /// <summary>
    /// This class will handle customer business logic
    /// </summary>
    public class CustomerBL
    {
        CustomerSP custOb = new CustomerSP();   // create new Customer

        // define businesslogic for employee method
        public int addCustomer(string customerId, string name, string address, string email, string conatacts)
        {
            if (!String.IsNullOrEmpty(customerId))
            {
               return custOb.addCustomer(customerId, name, address, email, conatacts);
            }
            return 0;
        }

        // define BL for get employee method
        public List<Customer> getCustomer(string customerId)
        {
            if (!String.IsNullOrEmpty(customerId))
            {
                return custOb.getCustomer(customerId);
            }
            return null;
        }

        // define BL for update employee
        public int updateCustomer(string customerId, string name, string address, string email, string contacts)
        {
            if (!String.IsNullOrEmpty(customerId))
            {
                return custOb.updateCustomer(customerId, name, address, email, contacts);
            }
            return 0;
        }


        //define BL for delete employee
        public int deleteCustomer(string customerId)
        {
            if (!String.IsNullOrEmpty(customerId))
            {
                return custOb.deleteCustomer(customerId);
            }
            return 0;
        }

        // Define function to get CustomerHistory
        public List<Customer> getCustomerHistory(string customerId, DateTime start, DateTime end)
        {
            if (!String.IsNullOrEmpty(customerId))
            {
                return custOb.getCustomerHistory(customerId, start, end);
            }
            return null;
        }
    }
}
