using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMS.CORE
{
    public class SearchObj
    {
        private string credit { get; set; }
        private string debit { get; set; }
        private string time { get; set; }

        public SearchObj(string credit, string debit, string time)
        {
            this.credit = credit;
            this.debit = debit;
            this.time = time;
        }
    }
}
