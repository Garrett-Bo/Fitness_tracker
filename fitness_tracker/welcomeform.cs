using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace fitness_tracker
{
    public partial class welcomeform : Form
    {
        private static string conn = "server=localhost;user=root;password=root;database=fitness_db;";
        public static string ConnectionString => conn;
        private WelcomeLogic _logic;

        public welcomeform()
        {
            InitializeComponent();
            _logic = new WelcomeLogic(conn);
        }

        private void btnconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (_logic.TestConnection())
                {
                    MessageBox.Show("Connected Successfully!");
                }
                else
                {
                    MessageBox.Show("Connection failed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Create an instance of your login form
            login loginPage = new login();

            // 2. Show the login form
            loginPage.Show();

            // 3. Hide the current dashboard (Form1)
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // 1. Create an instance of the register form
            // Note: Make sure your file and class is named 'register'
            register registerPage = new register();

            // 2. Show the registration form
            registerPage.Show();

            // 3. Hide this main portal
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}