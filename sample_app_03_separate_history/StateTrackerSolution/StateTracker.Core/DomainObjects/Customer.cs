using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StateTracker.Core.DomainObjects
{
    public class Customer
    {
        // define properties for both getters and setters
        private string _customerId = string.Empty;
        public string CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; }
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

        private string _status = string.Empty;
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private string _created = string.Empty;
        public string Created
        {
            get { return _created; }
            set { _created = value; }
        }
    }
}
