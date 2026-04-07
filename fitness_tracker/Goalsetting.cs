using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Linq;

namespace fitness_tracker
{
    public partial class Goalsetting : Form
    {
        private string _username;
        private int _userId = -1;
        private GoalsettingLogic _logic;

        public Goalsetting(string username)
        {
            InitializeComponent();
            _username = username;
            lblLoggedUser.Text = "Logged in as: " + _username;
            _logic = new GoalsettingLogic(welcomeform.ConnectionString);
            this.Load += Goalsetting_Load;
        }

        private void Goalsetting_Load(object sender, EventArgs e)
        {
            try
            {
                var userId = _logic.GetUserId(_username);
                if (userId == null)
                {
                    lblResult.Text = "User not found.";
                    return;
                }
                _userId = userId.Value;
                var goalCalories = _logic.GetOngoingGoalCalories(_userId);
                if (goalCalories != null)
                {
                    txtGoalCalories.Text = goalCalories.ToString();
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = "Database error: " + ex.Message;
            }
        }

        private void btnSaveGoal_Click(object sender, EventArgs e)
        {
            lblResult.Text = "";

            // Validate user ID
            if (_userId <= 0)
            {
                lblResult.Text = "Error: User not properly loaded. Please log in again.";
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Visible = true;
                return;
            }

            // Validate input is not empty
            if (string.IsNullOrWhiteSpace(txtGoalCalories.Text))
            {
                lblResult.Text = "Please enter your goal calories.";
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Visible = true;
                return;
            }

            // Parse and validate numeric input
            int goalCalories;
            if (!int.TryParse(txtGoalCalories.Text, out goalCalories))
            {
                lblResult.Text = "Please enter a valid number for calories.";
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Visible = true;
                return;
            }

            // Validate positive number
            if (goalCalories <= 0)
            {
                lblResult.Text = "Goal calories must be greater than 0.";
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Visible = true;
                return;
            }

            // Validate reasonable range (50 to 10000 calories)
            if (goalCalories < 50 || goalCalories > 10000)
            {
                lblResult.Text = "Goal should be between 50 and 10000 calories.";
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Visible = true;
                return;
            }

            // Save goal
            GoalResult result = _logic.SaveGoal(_userId, goalCalories);

            if (result.Success)
            {
                lblResult.Text = result.Message;
                lblResult.ForeColor = System.Drawing.Color.Green;
                lblResult.Visible = true;
            }
            else
            {
                lblResult.Text = result.Message;
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Visible = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Close all open forms
            foreach (System.Windows.Forms.Form form in System.Windows.Forms.Application.OpenForms.Cast<System.Windows.Forms.Form>().ToList())
            {
                if (form.Name != "welcomeform")
                {
                    form.Close();
                }
            }

            // Show the welcome form
            welcomeform welcomeForm = null;
            foreach (System.Windows.Forms.Form form in System.Windows.Forms.Application.OpenForms)
            {
                if (form.Name == "welcomeform")
                {
                    welcomeForm = (welcomeform)form;
                    break;
                }
            }

            if (welcomeForm != null)
            {
                welcomeForm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                welcomeForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                welcomeForm.Show();
                welcomeForm.BringToFront();
            }
            else
            {
                // If welcome form doesn't exist, create and show it
                welcomeForm = new welcomeform();
                welcomeForm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                welcomeForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                welcomeForm.Show();
            }
        }

        private void btnViewProgress_Click(object sender, EventArgs e)
        {
            ProgressForm progressForm = new ProgressForm(_username);
            progressForm.Show();
            this.Hide();
        }

        private void btnRecordActivity_Click(object sender, EventArgs e)
        {
            ActivityForm activityForm = new ActivityForm(_username);
            activityForm.Show();
            this.Hide();
        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
