using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerSection;
using Admin;


namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("For Existing Account, enter 1, for New Account, enter 2");
                string inputEntered = Console.ReadLine();
                if(inputEntered == "1")
                {
                    ExistingCustomer.Operations();
                    //AdminCreate.RetrieveAccounts();
                    break;
                }
                else if(inputEntered == "2")
                {
                    AdminCreate.Login();
                    break;
                }
            }
        }
    }
}
