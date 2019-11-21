using System;
using System.Collections.Generic;
using System.Text;
using Admin;

namespace CustomerSection
{
    public class ExistingCustomer
    {
       static List <NewCustomer> Accounts = new List<NewCustomer>();

        public static void Operations()
        {
            List<NewCustomer> Accounts = AdminCreate.AccountsLists;
            while (true)
            {
                Console.WriteLine("For Withdrawal press 1, for deposit press 2");
                string whatTodo = Console.ReadLine();
                if (whatTodo == "1")
                {
                    bool exist = false;
                    Console.WriteLine("Please provide your account name");
                    string nameprovided = Console.ReadLine();
                    foreach (NewCustomer account in Accounts)
                    {
                        if (account.AccName == nameprovided)
                        {
                            exist = true;
                            Console.WriteLine("Please enter your withdraw amount: ");
                            string ToWithdraw = Console.ReadLine();
                            int amtToWithdraw;
                            if (int.TryParse(ToWithdraw, out amtToWithdraw))
                            {
                                account.OpeningBalance -= amtToWithdraw;
                                if (account.OpeningBalance < 0)
                                {
                                    Console.WriteLine("You do not have the sufficient balance");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Please take your cash");
                                    Console.WriteLine($"Your account balance is {account.OpeningBalance}");
                                    Console.ReadLine();
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please enter a number");
                                break;
                            }
                        }
                    }
                    if(exist == false)
                    {
                        Console.WriteLine("The Account name provided isn't registered");
                        Console.ReadLine();
                        break;
                    }
                }
                else if (whatTodo == "2")
                {
                    bool exist = true;
                    Console.WriteLine("Please provide your account name");
                    string nameprovided = Console.ReadLine();
                    foreach (NewCustomer account in Accounts)
                    {
                        if (account.AccName == nameprovided)
                        {
                            exist = true;
                            Console.WriteLine("Please enter your deposit amount: ");
                            string ToDeposit = Console.ReadLine();
                            int amtToDeposit;
                            if (int.TryParse(ToDeposit, out amtToDeposit))
                            {
                                account.OpeningBalance += amtToDeposit;
                                Console.WriteLine("Deposit Successful");
                                Console.WriteLine($"Your account balance is {account.OpeningBalance}");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please enter a number");
                                break;
                            }
                        }
                    }
                    if (exist == false)
                    {
                        Console.WriteLine("The Account name provided isn't registered");
                        Console.ReadLine();
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("You entered a wrong option");
                }
            }
        }
    }
}
