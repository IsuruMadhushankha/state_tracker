using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StateTracker.DAL.DBCommand;
using StateTracker.Core.DomainObjects;

namespace StateTracker.BL.BLCode
{
    public class BranchBL
    {
        BranchSP bsp;

        // define get method for BranchSP class
        public void setBranchSP(BranchSP empSp)
        {
            BranchSP bsp = empSp;
        }

        // define set method for BranchSP class
        public BranchSP getBranchSP()
        {
            return bsp;
        }

        // define businesslogic for branch method
        public int addBranch(string branchCode, string address, string email, string conatacts, string managerId)
        {
            if (!String.IsNullOrEmpty(branchCode))
            {
                BranchSP branchOb = this.getBranchSP();
                return branchOb.addBranch(branchCode, address, conatacts, managerId);

            }

            return 0;
        }

        // define BL for get branch method
        public List<Branch> getBranch(string branchCode)
        {
            if (!String.IsNullOrEmpty(branchCode))
            {
                BranchSP branchOb = this.getBranchSP();
                return branchOb.getBranch(branchCode);

            }
            return null;
        }

        // define BL for update branch
        public int updateBranch(string branchCode, string address, string email, string conatacts, string managerId)
        {
            if (!String.IsNullOrEmpty(branchCode))
            {
                BranchSP branchOb = this.getBranchSP();
                return branchOb.updateBranch(branchCode, address, conatacts, managerId);

            }

            return 0;
        }


        //define BL for delete branch
        public int deleteBranch(string branchCode)
        {
            if (!String.IsNullOrEmpty(branchCode))
            {
                BranchSP branchOb = this.getBranchSP();
                return branchOb.deleteBranch(branchCode);

            }

            return 0;
        }

    }
}
