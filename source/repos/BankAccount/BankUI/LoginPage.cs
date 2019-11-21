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
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Submit_Click(object sender, EventArgs e)
        {
            string usernameInput = username.Text;
            string passwordInput = password.Text;

            if(usernameInput == "")
            {
                MessageBox.Show("You didn't fill in your username");
            }
            else if (passwordInput == "")
            {
                MessageBox.Show("You didn't fill in your password");
            }
            else
            {
                try
                {
                    if (usernameInput[0] == 'a' && usernameInput[1] == 'd' && usernameInput[2] == 'm')
                    {
                        ConnectionString.Connectionstring.Open();
                        SqlCommand command = new SqlCommand($"SELECT AdminType, AdminId FROM Admin WHERE AdminUsername = '{usernameInput}' AND AdminPassword = {passwordInput}", ConnectionString.Connectionstring);
                        SqlDataReader result = command.ExecuteReader();
                        if (result.Read())
                        {
                            AdminDetails.adminType = result.GetValue(0).ToString();
                            AdminDetails.adminId = int.Parse(result.GetValue(1).ToString());

                            MessageBox.Show("Signed in");
                            AdminDashboard dashboard = new AdminDashboard();
                            dashboard.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Details is Incorrect");
                        }
                    }
                    else
                    {
                        ConnectionString.Connectionstring.Open();
                        SqlCommand command = new SqlCommand($"SELECT * FROM Customer WHERE CustomerAccountNumber = '{usernameInput}' AND CustomerPassword = {passwordInput}", ConnectionString.Connectionstring);
                        SqlDataReader result = command.ExecuteReader();
                        if (result.Read())
                        {
                            CustomerDetails.AccType = result.GetValue(8).ToString();
                            CustomerDetails.accountNum = result.GetValue(5).ToString();
                            CustomerDetails.adminId = int.Parse(result.GetValue(0).ToString());
                            CustomerDetails.Balance = int.Parse(result.GetValue(7).ToString());

                            MessageBox.Show("Signed in");
                            CustomerToDoPage toDoPage = new CustomerToDoPage();
                            toDoPage.Show();
                            this.Hide(); 
                            ConnectionString.Connectionstring.Close();
                        }
                        else
                        {
                            MessageBox.Show("Details is Incorrect");
                            ConnectionString.Connectionstring.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : Wrong details " + ex.ToString());
                }
            }
        }
    }
}
