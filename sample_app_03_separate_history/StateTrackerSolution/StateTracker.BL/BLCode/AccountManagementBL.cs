using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StateTracker.DAL.DBCommand;

namespace StateTracker.BL.BLCode
{
    /// <summary>
    /// This file will handle the relationship between account and customer
    /// </summary>
    public class AccountManagementBL
    {
        // create new account management object
        AccManagementSP acmOb = new AccManagementSP();  

        // define method to check customer exsist or not 
        public int checkCustomer(string customerId)
        {
            if (!String.IsNullOrEmpty(customerId))
            {
               return acmOb.checkCustomer(customerId);
            }
            return 0;
        }

        // define method to check if account exsist or not
        public int checkAccount(string accNo)
        {
            if (!String.IsNullOrEmpty(accNo))
            {
                return acmOb.checkAccount(accNo);
            }
            return 0;
        }

        // define method to  add customerId and accountId
        public int addAccountManagement(string customerId, string accNo)
        {
            if (!String.IsNullOrEmpty(customerId) && !String.IsNullOrEmpty(accNo))
            {
                return acmOb.addAccountManagement(customerId,accNo);
            }
            return 0;
        }

        // create method to delete relation
        public int deleteAccManagement(string customerId, string accNo)
        {
            if (!String.IsNullOrEmpty(customerId) && !String.IsNullOrEmpty(accNo))
            {
                return acmOb.deleteAccManagement(customerId, accNo);
            }
            return 0;
        }


    }
}
