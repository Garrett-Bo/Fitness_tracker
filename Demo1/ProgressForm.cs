using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;

namespace Demo1
{
    public partial class ProgressForm : Form
    {
        private string _username;
        private int _userId = -1;
        private ProgressLogic _logic;
        private Button btnGoalSetting;

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
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            LoadProgressData();
            LoadActivitiesLog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProgressData();
            LoadActivitiesLog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGoalSetting_Click(object sender, EventArgs e)
        {
            Goalsetting goalForm = new Goalsetting(_username);
            goalForm.Show();
            this.Hide();
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

                // Display goal status with motivational messages
                if (goalCalories <= 0)
                {
                    // No goal set
                    lblResult.Text = "📌 No Goal Set\n\nSet a goal to get started!";
                    lblResult.ForeColor = System.Drawing.Color.FromArgb(156, 39, 176); // Purple
                }
                else if (totalCalories >= goalCalories)
                {
                    // Goal achieved!
                    float exceeded = totalCalories - goalCalories;
                    lblResult.Text = $"🎉 Goal Achieved!\n\n✓ You burned {totalCalories:F0} kcal\n\nExtra: {exceeded:F0} kcal";
                    lblResult.ForeColor = System.Drawing.Color.LimeGreen;
                }
                else
                {
                    // In progress - show remaining calories and percentage
                    float remaining = goalCalories - totalCalories;
                    float percentage = (totalCalories / goalCalories) * 100;

                    // Motivational message based on progress
                    string motivation = "";
                    if (percentage >= 75)
                    {
                        motivation = "🔥 Almost there! Keep pushing!";
                    }
                    else if (percentage >= 50)
                    {
                        motivation = "💪 Halfway done! Keep going!";
                    }
                    else if (percentage >= 25)
                    {
                        motivation = "🚀 Great start! Try harder!";
                    }
                    else
                    {
                        motivation = "⚡ Let's go! Keep moving!";
                    }

                    lblResult.Text = $"⏳ In Progress\n\n{percentage:F0}% Complete\n{remaining:F0} kcal to go\n\n{motivation}";
                    lblResult.ForeColor = System.Drawing.Color.FromArgb(255, 152, 0); // Orange
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = "Database error: " + ex.Message;
            }
        }

        private void LoadActivitiesLog()
        {
            lvActivities.Items.Clear();
            lvActivities.Groups.Clear();
            lvActivities.Columns.Clear();

            // Add columns
            lvActivities.Columns.Add("Activity Type", 100);
            lvActivities.Columns.Add("Date", 120);
            lvActivities.Columns.Add("Metric1", 70);
            lvActivities.Columns.Add("Metric2", 70);
            lvActivities.Columns.Add("Metric3", 70);
            lvActivities.Columns.Add("Duration (h)", 80);
            lvActivities.Columns.Add("Weight (kg)", 90);
            lvActivities.Columns.Add("Calories", 80);

            var activities = _logic.GetActivities(_userId);

            if (activities.Count == 0)
            {
                ListViewItem emptyItem = new ListViewItem("No activities recorded");
                lvActivities.Items.Add(emptyItem);
                return;
            }

            // Simple list - sort by date descending
            var sorted = activities.OrderByDescending(a => a.Date);

            foreach (var act in sorted)
            {
                var item = new ListViewItem(new[]
                {
                    act.ActivityType,
                    act.Date.ToString("yyyy-MM-dd HH:mm"),
                    act.Metric1.ToString("F2"),
                    act.Metric2.ToString("F2"),
                    act.Metric3.ToString("F2"),
                    act.DurationHours.ToString("F2"),
                    act.WeightKg.ToString("F2"),
                    act.Calories.ToString("F2")
                });
                lvActivities.Items.Add(item);
            }
        }

        private void pnlCard_Paint(object sender, PaintEventArgs e)
        {
            // No custom painting logic required yet.
        }
    }
}
