using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StateTracker.DAL.DBCommand;
using StateTracker.Core.DomainObjects;
using StateTracker.BL.BLCode;
using System.Data;

namespace StateTracker.BL.BLCode
{
    /// <summary>
    /// This class has all the main functions used in the application
    /// </summary>
    public class MainBL
    {
        CustomerBL cbl = new CustomerBL();
        CustomerSP csp = new CustomerSP();
        AccountSP asp = new AccountSP();
        AccountBL abl = new AccountBL();                   // create AccountBL object
        AccountManagementBL acmbl = new AccountManagementBL();
        
        public int createAccount(string customerId, string name, string address, string email, string conatacts, string accNo, double balance, string branchId)
        {
  
            //check if customerId and account number exsist
            if (!String.IsNullOrEmpty(customerId) && !String.IsNullOrEmpty(accNo))
            {
                // if both customer and account are new then add record 
                if (acmbl.checkCustomer(customerId) == 0 && csp.checkTempCustomer(customerId) == 0
                     && acmbl.checkAccount(accNo) == 0 && asp.checkTempAccountHas(accNo) == 0)
                {                 
                    cbl.addCustomer(customerId, name, address, email, conatacts);
                    abl.createAccount(accNo, balance, branchId);
                    acmbl.addAccountManagement(customerId, accNo);
                    return 1;
                }
                       
                return 0;
            }
            return 0;          
        }

        // define function to delete account and related customer with it
        public int deleteAccount(string accNo)
        {
            if (!String.IsNullOrEmpty(accNo) && acmbl.checkAccount(accNo) == 1)
            {
                List<String> accHoldersList = new List<string>();
                AccManagementSP acmOb = new AccManagementSP();
                accHoldersList = acmOb.selectCustomers(accNo);                       // get account holders into list
                foreach (string customerId in accHoldersList)
                {
                    int count = acmOb.countCustomerAccounts(customerId); // count the number of accout customer have
                    acmbl.deleteAccManagement(customerId, accNo);
                    if (count == 1)
                    {
                        cbl.deleteCustomer(customerId);
                    }
                }
                abl.deleteAccount(accNo);
                return 1;
            }
            return 0;
        }

        // update account with acc no, amount, and credit/debit
        public int updateAccount(string accNo, double amount, bool credit)
        {          
            if (!String.IsNullOrEmpty(accNo) && acmbl.checkAccount(accNo) == 1)
            {
                abl.updateAccount(accNo, amount, credit);
                return 1;
            }
            return 0;
        }

        // get account balance for perticular day
        public double getBalanceByDate(string accNo, DateTime date)
        {
            if (!String.IsNullOrEmpty(accNo) && asp.checkTempAccountHas(accNo) == 1) 
            {
                return abl.getBalanceByDate(accNo, date);
            }

            return 0;                
            
        }

        public DataTable getCreditDebitHistory(string accNo, DateTime startDate, DateTime endDate)
        {
            DataTable table = new DataTable();
            if (!String.IsNullOrEmpty(accNo) && asp.checkTempAccountHas(accNo) == 1)
            {
                table.Columns.Add("Credit", typeof(double));
                table.Columns.Add("Debit", typeof(double));
                table.Columns.Add("Date", typeof(DateTime));
                List<CreditDebit> cdList = new List<CreditDebit>();
                cdList = abl.getCreditDebitHistory(accNo, startDate, endDate);
                foreach(CreditDebit cd in cdList) 
                {
                    table.Rows.Add(cd.Credit, cd.Debit, cd.CreateDate);
                }
                return table;
            }
            return table;

        }

        // define function to update customer
        public int updateCustomer(string customerId, string name, string address, string email, string contacts)
        {
            if (!String.IsNullOrEmpty(customerId) && acmbl.checkCustomer(customerId) == 1)
            {
                return cbl.updateCustomer(customerId, name, address, email, contacts);
            }
            return 0;
        }

        // define function to get CustomerHistory
        public DataTable getCustomerHistory(string customerId, DateTime start, DateTime end)
        {
            DataTable table = new DataTable();
            if (!String.IsNullOrEmpty(customerId) && csp.checkTempCustomer(customerId) == 1)
            {
                table.Columns.Add("Name", typeof(string));
                table.Columns.Add("Address", typeof(string));
                table.Columns.Add("Email", typeof(string));
                table.Columns.Add("Contact No", typeof(string));
                table.Columns.Add("Status", typeof(string));
                table.Columns.Add("Created", typeof(DateTime));
                List<Customer> custList = new List<Customer>();
                custList =  cbl.getCustomerHistory(customerId, start, end);
                foreach (Customer cd in custList)
                {
                    table.Rows.Add(cd.Name, cd.Address, cd.Email, cd.ContactNo, cd.Status, cd.Created);
                }
                return table;
            }
            return table;
        }

    }
}
