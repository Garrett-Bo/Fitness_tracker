using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Linq;

namespace Demo1
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void register_Load(object sender, EventArgs e)
        {
            // Attach the click event handler for the confirm button
            btnconfirmregister.Click += btnconfirmregister_Click;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        // Strict password validation function
        private bool ValidatePassword(string password)
        {
            // Rule 1: Password must be exactly 12 characters
            if (password.Length != 12)
            {
                lblPasswordError.Text = "Password must be exactly 12 characters";
                return false;
            }

            // Rule 2, 3, 4: Check for at least one uppercase, one lowercase, and one number
            bool hasUpper = false;
            bool hasLower = false;
            bool hasNumber = false;

            for (int i = 0; i < password.Length; i++)
            {
                char c = password[i];

                if (char.IsUpper(c))
                    hasUpper = true;
                else if (char.IsLower(c))
                    hasLower = true;
                else if (char.IsDigit(c))
                    hasNumber = true;
                else if (!char.IsLetterOrDigit(c))
                {
                    // Rule 6: Only letters and numbers allowed
                    lblPasswordError.Text = "Password can only contain letters and numbers";
                    return false;
                }

                // Rule 5: No spaces allowed
                if (char.IsWhiteSpace(c))
                {
                    lblPasswordError.Text = "Password cannot contain spaces";
                    return false;
                }
            }

            if (!hasUpper)
            {
                lblPasswordError.Text = "Password must contain at least one uppercase letter";
                return false;
            }
            if (!hasLower)
            {
                lblPasswordError.Text = "Password must contain at least one lowercase letter";
                return false;
            }
            if (!hasNumber)
            {
                lblPasswordError.Text = "Password must contain at least one number";
                return false;
            }

            // If all checks pass, password is valid
            lblPasswordError.Text = ""; // Clear any previous error
            return true;
        }

        // Register button logic for RegisterForm
        private void btnconfirmregister_Click(object sender, EventArgs e)
        {
            // Use the connection string from welcomeform
            string connectionString = welcomeform.ConnectionString;
            string username = inputusername.Text.Trim();
            string password = inputpassword.Text;
            string confirmPassword = inputconfirmpassword.Text;

            // Username: only letters and numbers
            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9]+$"))
            {
                lblMessage.Text = "Username must contain only letters and numbers.";
                return;
            }

            // Strict password validation
            if (!ValidatePassword(password))
            {
                // Error message is set in lblPasswordError
                return;
            }

            if (password != confirmPassword)
            {
                lblMessage.Text = "Passwords do not match.";
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Check if username exists
                    string checkQuery = "SELECT COUNT(*) FROM users WHERE name = @name";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@name", username);
                        int exists = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (exists > 0)
                        {
                            lblMessage.Text = "Username already exists.";
                            return;
                        }
                    }

                    // Insert new user
                    string insertQuery = "INSERT INTO users (name, password) VALUES (@name, @password)";
                    using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@name", username);
                        insertCmd.Parameters.AddWithValue("@password", password); // Hash in production
                        int result = insertCmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            lblMessage.Text = "Registration successful!";
                            // Navigate to Goalsetting form as the registered user
                            Goalsetting goalForm = new Goalsetting(username);
                            goalForm.Show();
                            this.Close();
                        }
                        else
                        {
                            lblMessage.Text = "Registration failed. Please try again.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Database error: " + ex.Message;
                }
            }
        }

        private void backbtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // 1. Create the Welcome Form
            welcomeform welcomepage = new welcomeform();

            // 2. Show the Welcome Form
            welcomepage.Show();

            // 3. Close this register form instead of hiding it
            // This prevents the "Ghost Process" / File Locked error you had earlier
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
