using System;
using System.Collections.Generic;
using DefaultFields;

namespace AccountActivate
{
    public class AccActivate
    {
       public static Boolean AccountActivate()
        {
            int cashDeposited;
            bool activate = true;
            Console.WriteLine("Deposit Amount: ");
            string amountToDeposit = Console.ReadLine();
            if (int.TryParse(amountToDeposit, out cashDeposited))
            {
                if (DefaultField.AccType == "c" && cashDeposited < 20000)
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
            if (DefaultField.AccType == "s")
            {
                activate = true;
            }
            return activate;
        }
    }
}
