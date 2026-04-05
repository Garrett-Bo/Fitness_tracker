using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Demo1
{
    public partial class ProgressForm : Form
    {
        private string _username;
        private int _userId = -1;
        private ProgressLogic _logic;

        public ProgressForm(string username)
        {
            InitializeComponent();
            _username = username;
            lblLoggedUser.Text = "Logged in as: " + _username;
            _logic = new ProgressLogic(welcomeform.ConnectionString);
            this.Load += ProgressForm_Load;
            btnRefresh.Click += btnRefresh_Click;
            btnClose.Click += btnClose_Click;
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
            LoadProgressData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProgressData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadProgressData()
        {
            try
            {
                var userId = _logic.GetUserId(_username);
                if (userId == null)
                {
                    lblResult.Text = "User not found";
                    return;
                }
                _userId = userId.Value;
                float totalCalories = _logic.GetTotalCalories(_userId);
                lblTotalCalories.Text = totalCalories.ToString("F1");
                float goalCalories = _logic.GetGoalCalories(_userId);
                lblGoalCalories.Text = goalCalories.ToString("F1");
                if (goalCalories > 0 && totalCalories >= goalCalories)
                {
                    lblResult.Text = "\u2713 Goal Achieved!";
                    lblResult.ForeColor = System.Drawing.Color.LimeGreen;
                }
                else if (goalCalories > 0)
                {
                    float remaining = goalCalories - totalCalories;
                    lblResult.Text = remaining > 0 
                        ? $"In Progress\n\n{remaining:F0} kcal\nto go"
                        : "\u2713 Goal Achieved!";
                    lblResult.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    lblResult.Text = "No goal set.";
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = "Database error: " + ex.Message;
            }
        }
    }
}
