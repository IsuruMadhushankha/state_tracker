using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using StateTracker.BL.BLCode;
using StateTracker.Core.DomainObjects;
using StateTracker.DAL.DBCommand;
using System.Data;

namespace StateTracker.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormBalanceHistory());

            AccountBL abl = new AccountBL();
            AccountSP asp = new AccountSP();
            BranchSP bsp = new BranchSP();
            CustomerBL cbl = new CustomerBL();
            CustomerSP csp = new CustomerSP();
            MainBL mbl = new MainBL();
            AccManagementSP amsp = new AccManagementSP();
            AccountManagementBL ambl = new AccountManagementBL();

                     
            DateTime start = new DateTime(2013, 2, 11);
            DateTime end = new DateTime(2013, 2, 11);
            //List<Account> list = asp.getTempAccount("AC001", start, end);
            //int a = bsp.addBranch("BR002", "anuradhapura", "0776983725", "EM001");
            // int a = bsp.updateBranch("BR001", "cobo","","EM001");
            //int a = amsp.selectCustomers("AC001");
            //int a = cbl.deleteCustomer("CUST003");
            
                 
            // int a = mbl.createAccount("CUST013", "sakka", "adddsrs", "fas.cs@gss.ocm", "01273373873", "AC014", 500, "BR001");
            // int a = mbl.deleteAccount("AC007");
            // int a = mbl.updateAccount("AC001", 7000, false);
            // double a = mbl.getBalanceByDate("AC001", start); 
            // DataTable table = mbl.getCreditDebitHistory(accNo, startDate, endDate);
            // int a = mbl.updateCustomer("CUST003", "senura", "anu", "sen@gmaa.com", "034843733");
            // MessageBox.Show(a.ToString());

        }
    }
}