using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BMS.DBH.DbFunctions;

namespace BMS.Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            EmpName empName = new EmpName();

            Console.WriteLine(empName.getEmpName("002"));
            //Console.Read();

            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);

            Console.WriteLine(list[0]);
            Console.Read();
        }
    }
}
