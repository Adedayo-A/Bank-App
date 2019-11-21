using System;
using System.Collections.Generic;
using System.Text;

namespace Admin
{
        public class NewCustomer
        {
            public int OpeningBalance { get; set; }
            public string AccType { get; set; }
            public string AccName { get; set; }
            private int initialAccNum = 001;
            public int AccountNum
            {
                get
                {
                    return initialAccNum;
                }
                set
                {
                    initialAccNum = initialAccNum += 1;
                    initialAccNum = value;
                }
            }
            

            public void AccInitialization()
            {
                Console.WriteLine("Please enter your account type: For Savings enter S, and Current enter C");
                string userAcc = Console.ReadLine();
                userAcc.ToLower();
                AccType = userAcc;
                Console.WriteLine("Please enter your account Name:");
                AccName = Console.ReadLine();
            }
        }

 }
