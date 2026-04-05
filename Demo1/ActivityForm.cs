using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Demo1
{
    public partial class ActivityForm : Form
    {
        private string _username;
        private int _userId = -1;
        private ActivityLogic _logic;
        private System.Windows.Forms.Label lblResult = new System.Windows.Forms.Label();

        public ActivityForm(string username)
        {
            InitializeComponent();
            _username = username;
            _logic = new ActivityLogic(welcomeform.ConnectionString);
            this.Load += ActivityForm_Load;
            cmbActivityType.SelectedIndexChanged += cmbActivityType_SelectedIndexChanged;
            btnSaveActivity.Click += btnSaveActivity_Click;
            btnClose.Click += btnClose_Click;
        }

        private void ActivityForm_Load(object sender, EventArgs e)
        {
            cmbActivityType.Items.AddRange(new object[] { "Walking", "Running", "Swimming", "Cycling", "Gym", "Jump Rope" });
            cmbActivityType.SelectedIndex = 0;
            UpdateMetricLabels();
            try
            {
                var userId = _logic.GetUserId(_username);
                if (userId != null)
                {
                    _userId = userId.Value;
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
            if (cmbActivityType.SelectedIndex < 0)
                return;
            string activityType = cmbActivityType.SelectedItem.ToString();
            float metric1, metric2, metric3;
            if (!float.TryParse(txtMetric1.Text, out metric1) ||
                !float.TryParse(txtMetric2.Text, out metric2) ||
                !float.TryParse(txtMetric3.Text, out metric3))
            {
                lblResult.Text = "Please enter valid numbers for all metrics.";
                return;
            }
            string error;
            if (_logic.SaveActivity(_userId, activityType, metric1, metric2, metric3, out error))
            {
                lblResult.Text = "Activity saved!";
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
    }
}
