using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Demo1
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
            if (string.IsNullOrWhiteSpace(txtGoalCalories.Text))
            {
                lblResult.Text = "Please enter your goal calories.";
                return;
            }
            int goalCalories;
            if (!int.TryParse(txtGoalCalories.Text, out goalCalories) || goalCalories <= 0)
            {
                lblResult.Text = "Please enter a valid number for calories.";
                return;
            }
            string error;
            if (_logic.SaveGoal(_userId, goalCalories, out error))
            {
                lblResult.Text = "Goal saved!";
            }
            else
            {
                lblResult.Text = "Error: " + error;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnViewProgress_Click(object sender, EventArgs e)
        {
            ProgressForm progressForm = new ProgressForm(_username);
            progressForm.Show();
        }

        private void btnRecordActivity_Click(object sender, EventArgs e)
        {
            ActivityForm activityForm = new ActivityForm(_username);
            activityForm.Show();
        }
    }
}
