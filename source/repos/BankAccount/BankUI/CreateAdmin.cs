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
    public partial class CreateAdmin : Form
    {
        public CreateAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminDetails.firstName = firstName.Text;
            AdminDetails.lastName = lastName.Text;
            AdminDetails.email = email.Text;
            AdminDetails.password = password.Text;
            AdminDetails.username = username.Text;
            AdminDetails.adminType = "admin";
;
            string con = "Data Source=DESKTOP-GB3ICV4;Initial Catalog=BankApp;Integrated Security=True";
            System.Data.SqlClient.SqlConnection connection = new SqlConnection(con);
            string query = "insert into Admin values('" + AdminDetails.firstName + "', '" + AdminDetails.lastName + " ', '" + AdminDetails.email + "','" + AdminDetails.password + "', '" + AdminDetails.username + "', '" + AdminDetails.adminType + "')";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {

                connection.Open();
                int i = command.ExecuteNonQuery();
                if (i >= 0)
                {

                    MessageBox.Show("Admin added successfully");
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred during the write operation: " + ex.Message);
            }
        }

        private void CreateAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
