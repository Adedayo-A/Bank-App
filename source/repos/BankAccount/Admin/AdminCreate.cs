using System;
using System.Collections.Generic;
using System.Text;

namespace Admin
{
    public class AdminCreate
    {
        public static List<NewCustomer> AccList = new List<NewCustomer>();
        Admin newAdmin = new Admin();
        int myAccNum;
        public static void Login()
        {
            Admin newAdmin = new Admin();
            Console.WriteLine("Please Enter your Username");
            string Username = Console.ReadLine();
            if(Username == newAdmin.Username)
            {
                Console.WriteLine("Please Enter your Password");
                string PasswordEntered = Console.ReadLine();
                if(PasswordEntered == newAdmin.Password)
                {
                    AccountActivate();
                }
                else
                {
                    Console.WriteLine("Your login details is incorrect");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Your login details is incorrect");
                Console.ReadKey();
            }
        }

        public static List<NewCustomer> RetrieveAccounts()
        {
            NewCustomer Acc1 = new NewCustomer();
            Acc1.AccName = "Adedayo";
            Acc1.AccType = "c";
            Acc1.OpeningBalance = 25000;
            AccList.Add(Acc1);

            NewCustomer Acc2 = new NewCustomer();
            Acc2.AccName = "Felix";
            Acc2.AccType = "s";
            Acc2.OpeningBalance = 3000;
            AccList.Add(Acc2);
            return AccList;
        }


        public static List<NewCustomer>AccountActivate()
        {
            NewCustomer myAcc = new NewCustomer();
            myAcc.AccInitialization();
            int cashDeposited;
            Console.WriteLine("Deposit Amount: ");
            string amountToDeposit = Console.ReadLine();
            if (int.TryParse(amountToDeposit, out cashDeposited))
            {
                if (myAcc.AccType == "c" && cashDeposited < 20000)
                {
                    Console.WriteLine("You need to deposit at least 20000 to be able to successfully open a Current Account");
                    return AccList;
                }
                else if(myAcc.AccType == "c" && cashDeposited >= 20000)
                {
                    AccList.Add(myAcc);
                    myAcc.OpeningBalance = cashDeposited;
                    foreach(NewCustomer acc in AccList)
                    {
                        Console.WriteLine(acc.AccName);
                        Console.WriteLine(acc.AccType);
                        Console.WriteLine(acc.OpeningBalance);
                        Console.ReadLine();
                    }
                    return AccList;
                }
                else if (myAcc.AccType == "s")
                {
                    AccList.Add(myAcc);
                    myAcc.OpeningBalance = cashDeposited;
                    foreach (NewCustomer acc in AccList)
                    {
                        Console.WriteLine(acc.AccName);
                        Console.WriteLine(acc.AccType);
                    }
                    Console.ReadKey();
                    return AccList;
                }
            }
            else
            {
                Console.WriteLine("You need to enter a number to deposit");
                return AccList;
            }
            return AccList;
        }
        public static List<NewCustomer> AccountsLists
        {
            get
            {
                return RetrieveAccounts();
            }
        }
    }
}
