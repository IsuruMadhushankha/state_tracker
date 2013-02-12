using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BMS.CORE;
using BMS.DBH.DbFunctions;

namespace BMS.BL
{
    public class StartAccount
    {
        public StartAccount(Customer customer,string accNo,string balance,string branchCode)
        {
            start_account(customer,accNo,balance,branchCode);
        }

            // customer should be set in from the details comming from the GUI
        public void start_account(Customer customer,string accNo,string balance, string branchCode)
        {
            ManageAccount ma = new ManageAccount();
            ma.insertAccount(accNo, balance, branchCode);
            ManageCustomer mc = new ManageCustomer();
            mc.insertCustomer(customer);
            
        }
    }
}
