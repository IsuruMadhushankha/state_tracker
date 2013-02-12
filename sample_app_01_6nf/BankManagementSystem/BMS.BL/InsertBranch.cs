using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BMS.CORE;
using BMS.DBH.DbFunctions;

namespace BMS.BL
{
    public class InsertBranch
    {
        /// <summary>
        /// insert details of the branch
        /// to the database tables
        /// </summary>
        /// <param name="branchCode"></param>
        /// <param name="address"></param>
        /// <param name="contact"></param>
        /// <param name="managerId"></param>
        public void insertBranch(string branchCode,string address,string contact, string managerId)
        {
            ManageBranch mb = new ManageBranch();
            mb.insertBranch(branchCode, address, contact, managerId);
        }
    }
}
