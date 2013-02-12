using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StateTracker.Core.DomainObjects
{
    public class Employee
    {
        // define properties for both getters and setters
        private string _empId = string.Empty;    
        public string EmpId
        {
            get { return _empId; }
            set { _empId = value; }
        }

        private string _name = string.Empty;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _address = string.Empty;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _contactNo = string.Empty;
        public string ContactNo
        {
            get { return _contactNo; }
            set { _contactNo = value; }
        }


    }
}
