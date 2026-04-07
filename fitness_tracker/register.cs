using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Linq;

namespace fitness_tracker
{
    public partial class register : Form
    {
        private RegisterLogic _logic;
        public register()
        {
            InitializeComponent();
            _logic = new RegisterLogic(welcomeform.ConnectionString);
            btnconfirmregister.Click += btnconfirmregister_Click; // Ensure always attached
            btnShowPassword.Click += btnShowPassword_Click;
            btnShowConfirmPassword.Click += btnShowConfirmPassword_Click;
        }
        private void label1_Click(object sender, EventArgs e) { }
        private void register_Load(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private bool ValidatePassword(string password)
        {
            bool hasUpper = false, hasLower = false, hasSpecialChar = false;
            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsLower(c)) hasLower = true;
                else if (!char.IsLetterOrDigit(c)) hasSpecialChar = true;
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
            if (!hasSpecialChar)
            {
                lblPasswordError.Text = "Password must contain at least one special character";
                return false;
            }
            lblPasswordError.Text = "";
            return true;
        }
        private void btnconfirmregister_Click(object sender, EventArgs e)
        {
            string username = inputusername.Text.Trim();
            string password = inputpassword.Text;
            lblPasswordError.Text = string.Empty;
            lblPasswordError.Visible = true;
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                lblPasswordError.Text = "Username and password required.";
                lblPasswordError.Visible = true;
                lblPasswordError.ForeColor = System.Drawing.Color.FromArgb(229, 57, 53);
                return;
            }
            if (!ValidatePassword(password)) return;
            string error;
            bool result = _logic.RegisterUser(username, password, out error);
            if (result)
            {
                MessageBox.Show("Registration successful! Navigating to Goalsetting...");
                Goalsetting goalForm = new Goalsetting(username);
                goalForm.Show();
                this.Hide();
            }
            else
            {
                lblPasswordError.Text = error;
                lblPasswordError.Visible = true;
                lblPasswordError.ForeColor = System.Drawing.Color.FromArgb(229, 57, 53);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void backbtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            welcomeform welcomePage = new welcomeform();
            welcomePage.Show();
            this.Close();
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            inputpassword.UseSystemPasswordChar = !inputpassword.UseSystemPasswordChar;
            btnShowPassword.Text = inputpassword.UseSystemPasswordChar ? "Show" : "Hide";
        }

        private void btnShowConfirmPassword_Click(object sender, EventArgs e)
        {
            inputconfirmpassword.UseSystemPasswordChar = !inputconfirmpassword.UseSystemPasswordChar;
            btnShowConfirmPassword.Text = inputconfirmpassword.UseSystemPasswordChar ? "Show" : "Hide";
        }
    }
}
