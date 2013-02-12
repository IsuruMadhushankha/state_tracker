using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMS.CORE
{
    public class BalanceObj
    {
        public string balance { get; set; }
        public string time { get; set; }

        public BalanceObj(string balance, string time)
        {
            this.balance = balance;
            this.time = time;
        }
    }
}
