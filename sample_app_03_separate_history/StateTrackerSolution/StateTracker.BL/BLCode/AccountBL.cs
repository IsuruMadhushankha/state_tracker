using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StateTracker.DAL.DBCommand;
using StateTracker.Core.DomainObjects;

namespace StateTracker.BL.BLCode
{
    /// <summary>
    /// This class will handle all the account management logics
    /// </summary>
    public class AccountBL
    {

        AccountSP accOb = new AccountSP();

        // define businesslogic for employee method
        public int createAccount(string accNo, double balance, string branchId)
        {
            if (!String.IsNullOrEmpty(accNo))
            {
                return accOb.createAccount(accNo, balance, branchId);
            }
            return 0;
        }

        // define BL for get employee method
        public List<Account> getAccountBalance(string accNo)
        {
            if (!String.IsNullOrEmpty(accNo))
            {
                return accOb.getAccountBalance(accNo);
            }
            return null;
        }

        // define BL for update employee
        public int updateAccount(string accNo, double amount, bool credit)
        {
            List<Account> account = new List<Account>();
            if (!String.IsNullOrEmpty(accNo) && amount > 0)
            {                       
                    return accOb.updateAccount(accNo, amount, credit); 
            }

            return 0;
        }


        //define BL for delete employee
        public int deleteAccount(string accNo)
        {
            if (!String.IsNullOrEmpty(accNo))
            {
                return accOb.deleteAccount(accNo);
            }
            return 0;
        }

        //get balance by date
        public double getBalanceByDate(string accNo, DateTime date)
        {
            if (!String.IsNullOrEmpty(accNo))
            {
                return accOb.getBalanceByDate(accNo, date);
            }
            return 0;
        }

        public List<CreditDebit> getCreditDebitHistory(string accNo, DateTime start, DateTime end)
        {
            List<CreditDebit> cdResult = new List<CreditDebit>();  // Result credit debit list
            List<CreditDebit> cdList = new List<CreditDebit>(); // balance history
            CreditDebit cdOb1 = new CreditDebit(); // credit debit object
            cdList = accOb.getCreditDebitHistory(accNo, start, end);

                // if balance history has no vlaue
                if (cdList != null)
                {                 
                    cdOb1.Credit = cdList[0].Balance;    //set current balance as credit
                    cdOb1.CreateDate = cdList[0].CreateDate;
                    cdResult.Add(cdOb1);

                    if (cdList.Count > 1) // if one transaction is occured
                    {
                        for (int i = 0; i < cdList.Count-1; i++) // Loop through List with for
                        {
                            CreditDebit cdOb = new CreditDebit(); // credit debit object
                            if (cdList[i + 1].Balance - cdList[i].Balance > 0)
                            {
                                cdOb.Credit = cdList[i + 1].Balance - cdList[i].Balance;    //set current balance as debit
                                cdOb.Debit = 0;
                            }
                            else
                            {
                                cdOb.Debit = cdList[i].Balance - cdList[i + 1].Balance;
                                cdOb.Credit = 0;
                            }
                            cdOb.CreateDate = cdList[i+1].CreateDate;
                            cdResult.Add(cdOb);
                        }
                    }
                    return cdResult;
                }
            return cdResult;
        }

        



    }
}
