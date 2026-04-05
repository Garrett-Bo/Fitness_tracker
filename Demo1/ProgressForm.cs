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

        private void LoadActivitiesLog()
        {
            lvActivities.Items.Clear();
            lvActivities.Groups.Clear();
            var activities = _logic.GetActivities(_userId);
            // Group by activity type, then by year, month, day
            var grouped = activities
                .GroupBy(a => a.ActivityType)
                .OrderBy(g => g.Key);
            foreach (var typeGroup in grouped)
            {
                var typeGroupHeader = new ListViewGroup(typeGroup.Key, System.Windows.Forms.HorizontalAlignment.Left);
                lvActivities.Groups.Add(typeGroupHeader);
                var byYear = typeGroup.GroupBy(a => a.Date.Year).OrderByDescending(g => g.Key);
                foreach (var yearGroup in byYear)
                {
                    var yearHeader = new ListViewGroup($"{typeGroup.Key} - {yearGroup.Key}", System.Windows.Forms.HorizontalAlignment.Left);
                    lvActivities.Groups.Add(yearHeader);
                    var byMonth = yearGroup.GroupBy(a => a.Date.Month).OrderByDescending(g => g.Key);
                    foreach (var monthGroup in byMonth)
                    {
                        var monthHeader = new ListViewGroup($"{typeGroup.Key} - {yearGroup.Key}-{monthGroup.Key:D2}", System.Windows.Forms.HorizontalAlignment.Left);
                        lvActivities.Groups.Add(monthHeader);
                        var byDay = monthGroup.GroupBy(a => a.Date.Day).OrderByDescending(g => g.Key);
                        foreach (var dayGroup in byDay)
                        {
                            var dayHeader = new ListViewGroup($"{typeGroup.Key} - {yearGroup.Key}-{monthGroup.Key:D2}-{dayGroup.Key:D2}", System.Windows.Forms.HorizontalAlignment.Left);
                            lvActivities.Groups.Add(dayHeader);
                            foreach (var act in dayGroup)
                            {
                                var item = new ListViewItem(new[]
                                {
                                    act.ActivityType,
                                    act.Date.ToString("yyyy-MM-dd"),
                                    act.Metric1.ToString(),
                                    act.Metric2.ToString(),
                                    act.Metric3.ToString(),
                                    act.DurationHours.ToString("F2"),
                                    act.WeightKg.ToString("F2"),
                                    act.Calories.ToString("F2")
                                });
                                item.Group = dayHeader;
                                lvActivities.Items.Add(item);
                            }
                        }
                    }
                }
            }
        }
    }
}
