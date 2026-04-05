using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Add this for MySQL support

namespace Demo1
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {
            // Attach the click event handler for the confirm button
            confirmbtn.Click += confirmbtn_Click;
            // Attach the click event handler for the back button
            backbtn.LinkClicked += backbtn_LinkClicked;
        }

        private void backbtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Show the welcome form and close the login form
            welcomeform welcomePage = new welcomeform();
            welcomePage.Show();
            this.Close();
        }

        // MySQL login logic
        private void confirmbtn_Click(object sender, EventArgs e)
        {
            string connectionString = welcomeform.ConnectionString;
            string username = textBox1.Text.Trim();
            string password = textBox2.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                lblError.Text = "Please enter both username and password.";
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM users WHERE name = @name AND password = @password";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", username);
                        cmd.Parameters.AddWithValue("@password", password); // Hash in production

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count > 0)
                        {
                            // Login successful, open goalsetting page
                            Goalsetting goalForm = new Goalsetting(username);
                            goalForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            lblError.Text = "Invalid username or password";
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = "Database error: " + ex.Message;
                }
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
