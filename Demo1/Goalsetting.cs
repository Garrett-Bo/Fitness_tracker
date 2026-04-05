using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Demo1
{
    public partial class Goalsetting : Form
    {
        private string _username;
        private int _userId = -1;

        // 1. Constructor that receives username
        public Goalsetting(string username)
        {
            InitializeComponent();
            _username = username;
            lblLoggedUser.Text = "Logged in as: " + _username;
            this.Load += Goalsetting_Load;
        }

        // Fetch ongoing goal data on form load
        private void Goalsetting_Load(object sender, EventArgs e)
        {
            string connectionString = welcomeform.ConnectionString;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    // Get user_id from users table
                    string getUserIdQuery = "SELECT id FROM users WHERE name = @username";
                    using (MySqlCommand cmd = new MySqlCommand(getUserIdQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", _username);
                        object result = cmd.ExecuteScalar();
                        if (result == null)
                        {
                            lblResult.Text = "User not found.";
                            return;
                        }
                        _userId = Convert.ToInt32(result);
                    }
                    // Check for ongoing goal and fetch its calories
                    string checkGoalQuery = "SELECT goal_calories FROM goals WHERE user_id = @userid AND status = 'ongoing'";
                    using (MySqlCommand cmd = new MySqlCommand(checkGoalQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@userid", _userId);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            txtGoalCalories.Text = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = "Database error: " + ex.Message;
            }
        }

        // 7. Full btnSaveGoal_Click method
        private void btnSaveGoal_Click(object sender, EventArgs e)
        {
            lblResult.Text = ""; // Clear previous result

            // 2. Validate input
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

            string connectionString = welcomeform.ConnectionString;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // 3. Get user_id from users table (if not already fetched)
                    if (_userId == -1)
                    {
                        string getUserIdQuery = "SELECT id FROM users WHERE name = @username";
                        using (MySqlCommand cmd = new MySqlCommand(getUserIdQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@username", _username);
                            object result = cmd.ExecuteScalar();
                            if (result == null)
                            {
                                lblResult.Text = "User not found.";
                                return;
                            }
                            _userId = Convert.ToInt32(result);
                        }
                    }

                    // 4. Check for ongoing goal
                    int ongoingGoalId = -1;
                    string checkGoalQuery = "SELECT id FROM goals WHERE user_id = @userid AND status = 'ongoing'";
                    using (MySqlCommand cmd = new MySqlCommand(checkGoalQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@userid", _userId);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            ongoingGoalId = Convert.ToInt32(result);
                        }
                    }

                    if (ongoingGoalId > 0)
                    {
                        // 5. UPDATE query
                        string updateQuery = "UPDATE goals SET goal_calories = @calories WHERE id = @goalid";
                        using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@calories", goalCalories);
                            cmd.Parameters.AddWithValue("@goalid", ongoingGoalId);
                            cmd.ExecuteNonQuery();
                        }
                        lblResult.Text = "Goal updated successfully";
                    }
                    else
                    {
                        // 6. INSERT query
                        string insertQuery = "INSERT INTO goals (user_id, goal_calories, status) VALUES (@userid, @calories, 'ongoing')";
                        using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@userid", _userId);
                            cmd.Parameters.AddWithValue("@calories", goalCalories);
                            cmd.ExecuteNonQuery();
                        }
                        lblResult.Text = "Goal saved successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = "Database error: " + ex.Message;
            }
        }

        private void btnRecordActivity_Click(object sender, EventArgs e)
        {
            ActivityForm activityForm = new ActivityForm(_username);
            activityForm.Show();
        }

        private void btnViewProgress_Click(object sender, EventArgs e)
        {
            ProgressForm progressForm = new ProgressForm(_username);
            progressForm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
