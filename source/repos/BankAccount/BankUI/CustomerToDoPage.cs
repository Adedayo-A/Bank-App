using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankUI
{
    public partial class CustomerToDoPage : Form
    {
        public CustomerToDoPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DepositForm depositForm = new DepositForm();
            depositForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WithdrawalForm withdrawForm = new WithdrawalForm();
            withdrawForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TransferForm transferAcc = new TransferForm();
            transferAcc.Show();
            this.Hide();
        }
    }
}
