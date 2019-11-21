using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankUI
{
    class DepositC
    {
        public static void Deposit(TextBox amount, string accnumber, int balance, string message)
        {
            string userDepositAmt = amount.Text;
            int depositAmt;
            bool success = int.TryParse(userDepositAmt, out depositAmt);
            if (success)
            {
                balance += depositAmt;
                string qry = String.Format("UPDATE Customer SET CustomerBalance = {0} WHERE CustomerAccountNumber='{1}'", balance, accnumber);
                SqlConnection con = ConnectionString.Connectionstring;
                SqlCommand cmd = new SqlCommand(qry, con);
                try
                {
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show(message);
                    }
                    else
                    {
                        MessageBox.Show("Invalid Details");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The following error occurred during the write operation in deposit class: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Please enter a number");
            }
        }
    }        
}
