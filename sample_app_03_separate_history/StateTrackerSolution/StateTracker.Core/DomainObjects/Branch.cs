using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StateTracker.Core.DomainObjects
{
    public class Branch
    {
        private string _branchCode = string.Empty;
        public string BranchCode
        {
            get { return _branchCode; }
            set { _branchCode = value; }
        }

        private string _address = string.Empty;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _contactNo = string.Empty;
        public string ContactNo
        {
            get { return _contactNo; }
            set { _contactNo = value; }
        }

        private string _managerId = string.Empty;
        public string ManagerId
        {
            get { return _managerId; }
            set { _managerId = value; }
        }

    }
}
