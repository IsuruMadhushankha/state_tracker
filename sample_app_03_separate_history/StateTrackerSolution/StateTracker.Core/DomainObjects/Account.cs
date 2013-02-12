using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StateTracker.Core.DomainObjects
{
    public class Account
    {
        private string _accNo = string.Empty;
        public string AccNo
        {
            get { return _accNo; }
            set { _accNo = value; }
        }

        private double _balance = 0;
        public double Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        private string _branchId = string.Empty;
        public string BranchId
        {
            get { return _branchId; }
            set { _branchId = value; }
        }

    }
}
