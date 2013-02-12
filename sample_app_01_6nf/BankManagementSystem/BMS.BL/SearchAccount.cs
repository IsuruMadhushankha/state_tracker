using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BMS.DBH.DbFunctions;
using BMS.CORE;

namespace BMS.BL
{
    public class SearchAccount
    {
        /// <summary>
        /// search balance of an account for 
        /// given time 
        /// </summary>
        /// <param name="accNo"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public string getBalanceForTime(string accNo, string time)
        {
            ManageAccount ma = new ManageAccount();
            string required_balance = ma.getBalanceForTime(accNo, time);
            return required_balance;
        }

        /// <summary>
        /// search transaction details
        /// of an account for given time period
        /// with credit | debit | time
        /// </summary>
        /// <param name="accNo"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public List<SearchObj> getCreditDebit(string accNo, string fromDateTime, string toDateTime)
        {
            ManageAccount ma = new ManageAccount();
            List<BalanceObj> balanceList = ma.searchBalance(accNo, fromDateTime, toDateTime);

            List<SearchObj> searchList = new List<SearchObj>();

            for (int i = 0; i < balanceList.Count()-1; i++)
            {
                int previous_balance = Convert.ToInt32(balanceList[i].balance);
                int current_balance = Convert.ToInt32(balanceList[i + 1].balance);

                if (previous_balance < current_balance)     // for credit
                {
                    string credit = (current_balance - previous_balance).ToString();
                    SearchObj sObj = new SearchObj(credit,"-",balanceList[i+1].time);
                    searchList.Add(sObj);
                }
                else if (previous_balance > current_balance)    // for debit
                {
                    string debit = (previous_balance - current_balance).ToString();
                    SearchObj sObj = new SearchObj("-", debit, balanceList[i + 1].time);
                    searchList.Add(sObj);
                }
            }

            return searchList;

        }
    }
}
