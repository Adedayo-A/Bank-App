using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BankUI
{
    public partial class DepositForm : Form
    {
        public DepositForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string successMsg = $"Your deposit is successful";
            DepositC.Deposit(DepositAmount, CustomerDetails.accountNum, CustomerDetails.Balance, successMsg);
        }

        private void DepositForm_Load(object sender, EventArgs e)
        {

        }
    }
}
