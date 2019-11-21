using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Admin;

namespace BankUI
{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string con = "Data Source=DESKTOP-GB3ICV4;Initial Catalog=BankApp;Integrated Security=True";

            try
            {
                SqlConnection connection = new SqlConnection(con);
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT AdminFirstName, AdminLastName, AdminEmail FROM Admin", connection);
                SqlDataReader status = command.ExecuteReader();

                ArrayList al = new ArrayList();
                string newList = "";

                int counter = 0;
                while (status.Read())
                {
                    string fn = status.GetString(0);
                    string ln = status.GetString(1);
                    newList += fn + " " + ln+"\n";
                }
                MessageBox.Show("counter " + counter.ToString());

                foreach (var item in al)
                    newList += item + "\n";

                MessageBox.Show(newList);

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error :"+ ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginPage adminValidate = new LoginPage();
            adminValidate.Show();
            this.Hide();
        }

        private void existingCustomer(object sender, EventArgs e)
        {
            AdminCreate.Login();
        }
    }
}
