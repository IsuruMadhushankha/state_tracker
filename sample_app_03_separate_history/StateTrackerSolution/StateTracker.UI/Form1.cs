using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using StateTracker.BL.BLCode;

namespace StateTracker.UI
{
    public partial class FormBalanceHistory : Form
    {
        public FormBalanceHistory()
        {
            InitializeComponent();
        }

        private void buttonGetHistory_Click(object sender, EventArgs e)
        {
            //String accNo = textBoxAccNo.Text;
            String customerId = textBoxAccNo.Text;
            DateTime startDate = dateTimePickerStartDate.Value;
            DateTime endDate = dateTimePickerEndDate.Value;
            MainBL account = new MainBL();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //DataTable table = account.getCreditDebitHistory(accNo, startDate, endDate);
            DataTable table = account.getCustomerHistory(customerId, startDate, endDate);

            sw.Stop();
            dataGridView1.DataSource = table;
            //Writing Execution Time in label 
            string ExecutionTimeTaken = string.Format("Seconds :{0} \t Mili seconds :{1}", sw.Elapsed.Seconds, sw.Elapsed.TotalMilliseconds);

            executeTime.Text = ExecutionTimeTaken;
        }

        private void FormBalanceHistory_Load(object sender, EventArgs e)
        {

        }
    }
}
