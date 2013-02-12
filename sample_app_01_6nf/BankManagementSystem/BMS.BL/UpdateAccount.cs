using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BMS.DBH.DbFunctions;

namespace BMS.BL
{
    public class UpdateAccount
    {
        public UpdateAccount(String accNo, string amount, int type)
        {
                // type = 1 when credit
                // type = 2 when debit
            if (type == 1)
            {
                deposite(accNo, amount);
            }
            else if (type == 2)
            {
                withdraw(accNo, amount);
            }

        }

        public void deposite(string accNo, string amount)
        {
            ManageAccount ma = new ManageAccount();
            int current_balance = Convert.ToInt32(ma.getCurrentBalance(accNo));
            int credit = Convert.ToInt32(amount);
            int new_balance = current_balance + credit;
                // update the account balance
            ma.updateAccount(accNo, new_balance.ToString());
        }

        public void withdraw(string accNo, string amount)
        {
            ManageAccount ma = new ManageAccount();
            int current_balance = Convert.ToInt32(ma.getCurrentBalance(accNo));
            int debit = Convert.ToInt32(amount);
            int new_balance = current_balance - debit;
            // update the account balance
            ma.updateAccount(accNo, new_balance.ToString());
        }
    }
}
