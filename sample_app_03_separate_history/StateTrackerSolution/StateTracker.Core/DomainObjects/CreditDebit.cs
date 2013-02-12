using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StateTracker.Core.DomainObjects
{
    public class CreditDebit
    {
        private double _credit = 0;
        public double Credit
        {
            get { return _credit; }
            set { _credit = value; }
        }

        private double _debit = 0;
        public double Debit
        {
            get { return _debit; }
            set { _debit = value; }
        }

        private string _creatDate = string.Empty;
        public string CreateDate
        {
            get { return _creatDate; }
            set { _creatDate = value; }
        }

        private double _balance = 0;
        public double Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

    }
}
