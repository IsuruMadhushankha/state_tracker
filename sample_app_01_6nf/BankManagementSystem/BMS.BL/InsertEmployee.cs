using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BMS.CORE;
using BMS.DBH.DbFunctions;

namespace BMS.BL
{
    public class InsertEmployee
    {
        public void insertEmployee(string empId,string name,string address,string email,string contactNo)
        {
            ManageEmployee me = new ManageEmployee();
            me.insertEmployee(empId, name, address, email, contactNo);
        }
    }
}
