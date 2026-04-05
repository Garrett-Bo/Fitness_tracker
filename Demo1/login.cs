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
                Goalsetting goalForm = new Goalsetting(username);
                goalForm.Show();
                this.Hide();
            }
            else
            {
                lblError.Text = error;
            }
        }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e) { }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
