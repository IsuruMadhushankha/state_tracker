using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMS.CORE
{
    public class Customer
    {
        public string name { get; set; }
        public string address { get; set; }
        public string customerId { get; set; }
        public string contact { get; set; }
        public string email { get; set; }

        public Customer(string customerId, string name, string address, string email,string contact)
        {

            this.name = name;
            this.address = address;
            this.customerId = customerId;
            this.contact = contact;
            this.email = email;

        }
    }
}
