using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Admin;
using System.Threading.Tasks;

namespace BankAccount
{
    public class BankAccount
    {
        public decimal OpeningBalance { get; set; }
        public string AccType { get; set; }
        public string AccName { get; set; }
        public Boolean AccountActivate()
        {
            int cashDeposited;
            bool activate = true;
            Console.WriteLine("Deposit Amount: ");
            string amountToDeposit = Console.ReadLine();
            if (int.TryParse(amountToDeposit, out cashDeposited))
            {
                if (AccType == "c" && cashDeposited < 20000)
                {
                    Console.WriteLine("You need to deposit at least 20000 to be able to successfully open a Current Account");
                    activate = false;
                    return activate;
                }
            }
            else
            {
                Console.WriteLine("You need to enter a number to deposit");
                return activate;
            }
            if (AccType == "s")
            {
                activate = true;
            }
            return activate;
        }
        public void CustomerUpdate (string email, int phoneNumber)
        {

        }
    }
}
