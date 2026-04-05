using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Demo1
{
    public partial class ProgressForm : Form
    {
        private string _username;
        private int _userId = -1;

        public ProgressForm(string username)
        {
            InitializeComponent();
            _username = username;
            lblLoggedUser.Text = "Logged in as: " + _username;
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
            string connectionString = welcomeform.ConnectionString;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // 1. Get user_id from users table
                    string getUserIdQuery = "SELECT id FROM users WHERE name = @username";
                    using (MySqlCommand cmd = new MySqlCommand(getUserIdQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", _username);
                        object result = cmd.ExecuteScalar();
                        if (result == null)
                        {
                            lblResult.Text = "User not found";
                            return;
                        }
                        _userId = Convert.ToInt32(result);
                    }

                    // 2. Get total calories burned from activities table
                    float totalCalories = 0;
                    string getTotalCaloriesQuery = "SELECT COALESCE(SUM(calories), 0) FROM activities WHERE user_id = @userid";
                    using (MySqlCommand cmd = new MySqlCommand(getTotalCaloriesQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@userid", _userId);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            totalCalories = Convert.ToSingle(result);
                        }
                    }
                    lblTotalCalories.Text = totalCalories.ToString("F1");

                    // 3. Get goal calories from goals table
                    float goalCalories = 0;
                    string getGoalCaloriesQuery = "SELECT goal_calories FROM goals WHERE user_id = @userid AND status = 'ongoing'";
                    using (MySqlCommand cmd = new MySqlCommand(getGoalCaloriesQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@userid", _userId);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            goalCalories = Convert.ToSingle(result);
                        }
                    }
                    lblGoalCalories.Text = goalCalories.ToString("F1");

                    // 4. Compare values and set status
                    if (goalCalories > 0 && totalCalories >= goalCalories)
                    {
                        lblResult.Text = "✓ Goal Achieved!";
                        lblResult.ForeColor = System.Drawing.Color.LimeGreen;
                    }
                    else if (goalCalories > 0)
                    {
                        float remaining = goalCalories - totalCalories;
                        lblResult.Text = remaining > 0 
                            ? $"In Progress\n\n{remaining:F0} kcal\nto go"
                            : "✓ Goal Achieved!";
                        lblResult.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        lblResult.Text = "Set a Goal\nto Track";
                        lblResult.ForeColor = System.Drawing.Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = "Error loading data";
                lblResult.ForeColor = System.Drawing.Color.White;
            }
        }
    }
}
