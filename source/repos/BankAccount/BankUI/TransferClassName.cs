using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankUI
{
    class TransferClassName
    {
        public static void Transfer(TextBox amount, string debitAccnumber, int receiversbalance, int sendersbalance, string acctype, string receiversAccnumber, string message)
        {
                WithdrawalC.Withdraw(amount, debitAccnumber, sendersbalance, acctype, message);  
                DepositC.Deposit(amount, receiversAccnumber, receiversbalance, message);
        }
    }
}
