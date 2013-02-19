using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BMS.DBH.DbFunctions;
using BMS.BL;

namespace BMS.Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            //EmpName empName = new EmpName();

            //Console.WriteLine(empName.getEmpName("002"));
            ////Console.Read();

            //List<int> list = new List<int>();
            //list.Add(1);
            //list.Add(2);

            //Console.WriteLine(list[0]);
            //Console.Read();
            //========================================================
            Console.WriteLine("Function 01- InsertBranch()");
            InsertBranch ib = new InsertBranch();
            string branchCode = "fake_bc_1";
            string address = "fake_addr_1";
            string contact = "fake_contact";
            string managerId = "fake_mng_id";
            ib.insertBranch(branchCode,address,contact,managerId);
            Console.Read();
            //========================================================
            Console.WriteLine("Function 02- InsertEmployee()");
            InsertEmployee ie = new InsertEmployee();
            string empId = "fake_emp_id";
            string empName = "fake_emp_name";
            string empAddress = "fake_emp_addr";
            string empEmail = "fake_emp_email";
            string[] contactNos = {"fake_contact_no1","fake_contact_no2","fake_contact_no3"};
            ie.insertEmployee(empId,empName,empAddress,empEmail,contactNos);
            Console.Read();
            //=========================================================

        }
    }
}
