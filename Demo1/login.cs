using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Demo1
{
    public partial class login : Form
    {
        private LoginLogic _logic;
        public login()
        {
            InitializeComponent();
            _logic = new LoginLogic(welcomeform.ConnectionString);
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void login_Load(object sender, EventArgs e)
        {
            confirmbtn.Click += confirmbtn_Click;
            backbtn.LinkClicked += backbtn_LinkClicked;
        }
        private void backbtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            welcomeform welcomePage = new welcomeform();
            welcomePage.Show();
            this.Close();
        }
        private void confirmbtn_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text;
            string error;
            if (_logic.ValidateLogin(username, password, out error))
            {
                lblError.Text = string.Empty;
                Goalsetting goalForm = new Goalsetting(username);
                goalForm.Show();
                this.Hide();
            }
            else
            {
                lblError.Text = error;
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.FromArgb(229, 57, 53);
            }
        }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e) { }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !textBox2.UseSystemPasswordChar;
            btnShowPassword.Text = textBox2.UseSystemPasswordChar ? "Show" : "Hide";
        }

        private void btnShowPassword_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
        }

        private void btnShowPassword_MouseUp(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }
    }
}
