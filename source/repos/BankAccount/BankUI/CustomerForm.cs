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
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerDetails.firstName = firstName.Text;
            CustomerDetails.lastName = lastName.Text;
            CustomerDetails.email = email.Text;
            CustomerDetails.password = password.Text;
            CustomerDetails.Balance = 0;
            
            if(savingAcc.Checked)
            {
                CustomerDetails.AccType = "savings";
            }
            else
            {
                CustomerDetails.AccType = "current";
            }
            string accNum = "00505";
            Random rnd = new Random();
            int myRandomNo = rnd.Next(10000, 99999);
            accNum += myRandomNo.ToString();

            CustomerDetails.accountNum = accNum;
            MessageBox.Show(accNum);

            //Pass values to Parameters
            string con = "Data Source=DESKTOP-GB3ICV4;Initial Catalog=BankApp;Integrated Security=True";
            System.Data.SqlClient.SqlConnection connection = new SqlConnection(con);
            string query = "INSERT INTO Customer VALUES(@firstName, @lastName, @email, @password, @accountNum, @adminId, @openingBalance, @AccType)";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@firstName", CustomerDetails.firstName);
            cmd.Parameters.AddWithValue("@lastName", CustomerDetails.lastName);
            cmd.Parameters.AddWithValue("@email", CustomerDetails.email);
            cmd.Parameters.AddWithValue("@password", CustomerDetails.password);
            cmd.Parameters.AddWithValue("@accountNum", CustomerDetails.accountNum);
            cmd.Parameters.AddWithValue("@adminId", AdminDetails.adminId);
            cmd.Parameters.AddWithValue("@openingBalance", CustomerDetails.Balance);
            cmd.Parameters.AddWithValue("@AccType", CustomerDetails.AccType);

            try
            {
                
                connection.Open();
                int i = cmd.ExecuteNonQuery();
                if (i >= 0)
                {

                    MessageBox.Show("Customer added successfully");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred during the write operation: " + ex.Message);
            }
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
