using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankUI
{
    class WithdrawalC
    {
        public static void Withdraw(TextBox amount, string accnumber, int balance, string acctype, string message)
        {
            string inputWithdraw = amount.Text;
            int withdrawAmt;
            bool success = int.TryParse(inputWithdraw, out withdrawAmt);
            if (success)
            {
                if (balance >= withdrawAmt && acctype == "savings")
                {
                    balance -= withdrawAmt;
                    MessageBox.Show("This is the new acc gotten2 " + balance.ToString());
                    string qry = String.Format("UPDATE Customer SET CustomerBalance = {0} WHERE CustomerAccountNumber='{1}'", balance, accnumber);
                    SqlCommand cmd = new SqlCommand(qry, ConnectionString.Connectionstring);
                    //cmd.Parameters.AddWithValue("@customerBal", CustomerDetails.openingBalance);
                    //cmd.Parameters.AddWithValue("@customerAcc", CustomerDetails.accountNum);
                    try
                    {
                        ConnectionString.Connectionstring.Open();
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
                        MessageBox.Show("The following error occurred during the write operation: " + ex.Message);
                    }
                    finally
                    {
                        ConnectionString.Connectionstring.Close();
                    }
                }
                else if (acctype == "current")
                {
                    if ((balance - withdrawAmt >= 20000))
                    {
                        balance -= withdrawAmt;
                        string qry = String.Format("UPDATE Customer SET CustomerBalance = {0} WHERE CustomerAccountNumber='{1}'", balance, accnumber);
                        SqlCommand cmd = new SqlCommand(qry, ConnectionString.Connectionstring);
                        //cmd.Parameters.AddWithValue("@customerBal", CustomerDetails.openingBalance);
                        //cmd.Parameters.AddWithValue("@customerAcc", CustomerDetails.accountNum);
                        try
                        {
                            ConnectionString.Connectionstring.Open();
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
                            MessageBox.Show("The following error occurred during the write operation: " + ex.Message);
                        }
                        finally
                        {
                            ConnectionString.Connectionstring.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("You cannot withdraw below 20000. There must be a minimum of 20000 in a Current Account");
                    }
                }
                else
                {
                    MessageBox.Show("You do not have enough cash to withdraw");
                }
            }
            else
            {
                MessageBox.Show("Please Enter an Amount");
            }
        }
    }

}
