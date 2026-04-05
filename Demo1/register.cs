using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Linq;

namespace Demo1
{
    public partial class register : Form
    {
        private RegisterLogic _logic;
        public register()
        {
            InitializeComponent();
            _logic = new RegisterLogic(welcomeform.ConnectionString);
        }
        private void label1_Click(object sender, EventArgs e) { }
        private void register_Load(object sender, EventArgs e)
        {
            btnconfirmregister.Click += btnconfirmregister_Click;
        }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private bool ValidatePassword(string password)
        {
            if (password.Length != 12)
            {
                lblPasswordError.Text = "Password must be exactly 12 characters";
                return false;
            }
            bool hasUpper = false, hasLower = false, hasNumber = false;
            for (int i = 0; i < password.Length; i++)
            {
                char c = password[i];
                if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsLower(c)) hasLower = true;
                else if (char.IsDigit(c)) hasNumber = true;
                else if (!char.IsLetterOrDigit(c))
                {
                    lblPasswordError.Text = "Password can only contain letters and numbers";
                    return false;
                }
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
            lblPasswordError.Text = "";
            return true;
        }
        private void btnconfirmregister_Click(object sender, EventArgs e)
        {
            string username = inputusername.Text.Trim();
            string password = inputpassword.Text;
            if (!ValidatePassword(password)) return;
            string error;
            if (_logic.RegisterUser(username, password, out error))
            {
                MessageBox.Show("Registration successful!");
                this.Close();
            }
            else
            {
                lblPasswordError.Text = error;
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
    }
}
