using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using StateTracker.DAL.DBCommand;
using StateTracker.Core;
using StateTracker.Core.DomainObjects;

namespace TestProject.DAL
{
    public class EmployeeBL
    {
        EmployeeSP esp;

        // define get method for EmployeeSP class
        public void setEmployeeSP(EmployeeSP empSp)
        {
            EmployeeSP esp = empSp;
        }

        // define set method for EmployeeSP class
        public EmployeeSP getEmployeeSP() 
        {
            return esp;
        }

        // define businesslogic for employee method
        public int addEmployee(string empId, string name, string address, string email, string conatacts)
        {
            if (!String.IsNullOrEmpty(empId))
            {
                EmployeeSP empOb = this.getEmployeeSP();
                return empOb.addEmployee(empId, name, address, email, conatacts);
                
            }

            return 0;          
        }

        // define BL for get employee method
        public List<Employee> getEmployee(string empId)
        {
            if (!String.IsNullOrEmpty(empId))
            {
                EmployeeSP empOb = this.getEmployeeSP();
                return empOb.getEmployee(empId);

            }
            return null;
        }

        // define BL for update employee
        public int updateEmployee(string empId, string name, string address, string email, string conatacts)
        {
            if (!String.IsNullOrEmpty(empId))
            {
                EmployeeSP empOb = this.getEmployeeSP();
                return empOb.updateEmployee(empId, name, address, email, conatacts);

            }

            return 0;
        }


        //define BL for delete employee
        public int deleteEmployee(string empId)
        {
            if (!String.IsNullOrEmpty(empId))
            {
                EmployeeSP empOb = this.getEmployeeSP();
                return empOb.deleteEmployee(empId);

            }

            return 0;
        }






    }
}
