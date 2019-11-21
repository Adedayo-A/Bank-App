using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankUI
{
    public partial class TransferForm : Form
    {
        public TransferForm()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string receiversAccNum = ReceiversAcc.Text;
            MessageBox.Show(receiversAccNum);
            string query = String.Format("SELECT CustomerAccountNumber, CustomerBalance FROM Customer WHERE CustomerAccountNumber = '{0}'", receiversAccNum);
            SqlCommand command = new SqlCommand(query, ConnectionString.Connectionstring);
            try
            {
                ConnectionString.Connectionstring.Open();
                SqlDataReader result = command.ExecuteReader();
                if (result.Read())
                {
                    string successMsg = $"Your transfer is successful";
                    int receiversBal = int.Parse(result.GetValue(1).ToString());
                    ConnectionString.Connectionstring.Close();
                    TransferClassName.Transfer(TransferField, CustomerDetails.accountNum, receiversBal, CustomerDetails.Balance, CustomerDetails.AccType, receiversAccNum, successMsg);
                    //ConnectionString.Connectionstring.Close();
                }
                else
                {
                    MessageBox.Show("Receivers Account number is Invalid");
                    ConnectionString.Connectionstring.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred during the write operation in transfer form: " + ex.Message);
            }
            finally
            {
                ConnectionString.Connectionstring.Close();
            }
        }

        private void TransferForm_Load(object sender, EventArgs e)
        {
           
        }
    }
}
