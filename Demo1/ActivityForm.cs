using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Demo1
{
    public partial class ActivityForm : Form
    {
        private string _username;
        private int _userId = -1;

        public ActivityForm(string username)
        {
            InitializeComponent();
            _username = username;
            this.Load += ActivityForm_Load;
            cmbActivityType.SelectedIndexChanged += cmbActivityType_SelectedIndexChanged;
            btnSaveActivity.Click += btnSaveActivity_Click;
        }

        private void ActivityForm_Load(object sender, EventArgs e)
        {
            cmbActivityType.Items.AddRange(new object[] { "Walking", "Running", "Swimming", "Cycling", "Gym", "Jump Rope" });
            cmbActivityType.SelectedIndex = 0;
            UpdateMetricLabels();
            // Fetch user_id
            string connectionString = welcomeform.ConnectionString;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string getUserIdQuery = "SELECT id FROM users WHERE name = @username";
                    using (MySqlCommand cmd = new MySqlCommand(getUserIdQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", _username);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            _userId = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch { /* ignore for now */ }
        }

        private void cmbActivityType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateMetricLabels();
        }

        private void UpdateMetricLabels()
        {
            string activity = cmbActivityType.SelectedItem?.ToString() ?? "";
            switch (activity)
            {
                case "Walking":
                    lblMetric1.Text = "Distance (km)";
                    lblMetric2.Text = "Time (min)";
                    lblMetric3.Text = "Pace (min/km)";
                    break;
                case "Running":
                    lblMetric1.Text = "Distance (km)";
                    lblMetric2.Text = "Time (min)";
                    lblMetric3.Text = "Speed (km/h)";
                    break;
                case "Swimming":
                    lblMetric1.Text = "Laps";
                    lblMetric2.Text = "Time (min)";
                    lblMetric3.Text = "Pool Length (m)";
                    break;
                case "Cycling":
                    lblMetric1.Text = "Distance (km)";
                    lblMetric2.Text = "Time (min)";
                    lblMetric3.Text = "Speed (km/h)";
                    break;
                case "Gym":
                    lblMetric1.Text = "Sets";
                    lblMetric2.Text = "Reps";
                    lblMetric3.Text = "Weight (kg)";
                    break;
                case "Jump Rope":
                    lblMetric1.Text = "Jumps";
                    lblMetric2.Text = "Time (min)";
                    lblMetric3.Text = "Speed (jumps/min)";
                    break;
                default:
                    lblMetric1.Text = "Metric1";
                    lblMetric2.Text = "Metric2";
                    lblMetric3.Text = "Metric3";
                    break;
            }
        }

        private void btnSaveActivity_Click(object sender, EventArgs e)
        {
            // 1. Validate all inputs
            if (cmbActivityType.SelectedIndex < 0)
            {
                MessageBox.Show("Please select an activity type.");
                return;
            }
            if (!float.TryParse(txtMetric1.Text, out float metric1) ||
                !float.TryParse(txtMetric2.Text, out float metric2) ||
                !float.TryParse(txtMetric3.Text, out float metric3) ||
                !float.TryParse(txtWeight.Text, out float weight) || weight <= 0)
            {
                MessageBox.Show("Please enter valid numeric values for all metrics and weight.");
                return;
            }
            // 2. Convert time from minutes to hours
            float duration_hours = metric2 / 60f;
            // 3. Assign MET values
            string activity = cmbActivityType.SelectedItem.ToString();
            float met = 1f;
            switch (activity)
            {
                case "Walking": met = 3.5f; break;
                case "Running": met = 10f; break;
                case "Swimming": met = 8f; break;
                case "Cycling": met = 7f; break;
                case "Gym": met = 6f; break;
                case "Jump Rope": met = 12f; break;
            }
            // 4. Calculate calories
            float calories = met * weight * duration_hours;
            // 5. Insert into MySQL
            string connectionString = welcomeform.ConnectionString;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string insertQuery = "INSERT INTO activities (user_id, activity_type, metric1, metric2, metric3, duration_hours, weight_kg, calories) " +
                        "VALUES (@user_id, @activity_type, @metric1, @metric2, @metric3, @duration_hours, @weight_kg, @calories)";
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@user_id", _userId);
                        cmd.Parameters.AddWithValue("@activity_type", activity);
                        cmd.Parameters.AddWithValue("@metric1", metric1);
                        cmd.Parameters.AddWithValue("@metric2", metric2);
                        cmd.Parameters.AddWithValue("@metric3", metric3);
                        cmd.Parameters.AddWithValue("@duration_hours", duration_hours);
                        cmd.Parameters.AddWithValue("@weight_kg", weight);
                        cmd.Parameters.AddWithValue("@calories", calories);
                        cmd.ExecuteNonQuery();
                    }
                }
                // 6. Show MessageBox
                MessageBox.Show($"Calories burned: {calories:F2}\n(Formula: MET × weight_kg × duration_hours)\nAinsworth BE et al. 2011 Compendium of Physical Activities.");
                // 8. Clear inputs
                txtMetric1.Text = "";
                txtMetric2.Text = "";
                txtMetric3.Text = "";
                txtWeight.Text = "";
            }
            catch (Exception ex)
            {
                // 7. Handle DB errors
                MessageBox.Show("Database error: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
