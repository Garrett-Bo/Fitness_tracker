using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;

namespace fitness_tracker
{
    public partial class ProgressForm : Form
    {
        private string _username;
        private int _userId = -1;
        private ProgressLogic _logic;
        private Button btnGoalSetting;

        // Date filter controls
        private DateTimePicker dtpSelectedDate;
        private Label lblFilterLabel;
        private Button btnClearFilter;
        private Panel pnlFilter;

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

            // Set pnlContent to dock and fill
            pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlContent.AutoScroll = true;

            // Add date filter controls
            CreateDateFilterControls();

            // Center all components based on form width
            CenterAllComponents();

            LoadProgressData();
            LoadActivitiesLog();
        }

        private void CenterAllComponents()
        {
            // Get the content panel width
            int contentWidth = pnlContent.Width;

            // The ideal content width is 1100px (cards + spacing)
            int idealContentWidth = 1100;

            // Calculate the left offset to center content
            int offset = (contentWidth - idealContentWidth) / 2;

            // Ensure minimum offset of 0
            if (offset < 0) offset = 0;

            // Reposition stat cards with offset
            pnlCard1.Location = new System.Drawing.Point(175 + offset, 20);
            pnlCard2.Location = new System.Drawing.Point(500 + offset, 20);
            pnlCard3.Location = new System.Drawing.Point(825 + offset, 20);

            // Reposition refresh button with offset
            btnRefresh.Location = new System.Drawing.Point(450 + offset, 230);

            // Reposition filter panel with offset (1050px wide for proper display)
            pnlFilter.Location = new System.Drawing.Point(25 + offset, 280);
            pnlFilter.Size = new System.Drawing.Size(1050, 50);

            // Reposition activities table with offset (match filter panel width exactly)
            lvActivities.Location = new System.Drawing.Point(25 + offset, 340);
            lvActivities.Size = new System.Drawing.Size(1050, 280);
        }

        private void CreateDateFilterControls()
        {
            // Create a filter panel to hold all filter controls with better centering
            pnlFilter = new Panel();
            pnlFilter.Anchor = System.Windows.Forms.AnchorStyles.None;
            pnlFilter.BackColor = System.Drawing.Color.White;
            pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlFilter.Location = new System.Drawing.Point(50, 280);
            pnlFilter.Size = new System.Drawing.Size(1050, 50);

            // Label for filter
            lblFilterLabel = new Label();
            lblFilterLabel.Text = "📅 Filter by Date:";
            lblFilterLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblFilterLabel.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            lblFilterLabel.Location = new System.Drawing.Point(15, 12);
            lblFilterLabel.Size = new System.Drawing.Size(130, 25);
            lblFilterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // DateTimePicker for selecting date
            dtpSelectedDate = new DateTimePicker();
            dtpSelectedDate.Format = DateTimePickerFormat.Short;
            dtpSelectedDate.Value = DateTime.Today;
            dtpSelectedDate.Font = new System.Drawing.Font("Segoe UI", 11F);
            dtpSelectedDate.Location = new System.Drawing.Point(160, 10);
            dtpSelectedDate.Size = new System.Drawing.Size(150, 32);
            dtpSelectedDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            dtpSelectedDate.ValueChanged += DtpSelectedDate_ValueChanged;

            // Clear filter button
            btnClearFilter = new Button();
            btnClearFilter.Text = "Show All Activities";
            btnClearFilter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnClearFilter.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            btnClearFilter.ForeColor = System.Drawing.Color.White;
            btnClearFilter.Location = new System.Drawing.Point(330, 10);
            btnClearFilter.Size = new System.Drawing.Size(150, 32);
            btnClearFilter.FlatStyle = FlatStyle.Flat;
            btnClearFilter.FlatAppearance.BorderSize = 0;
            btnClearFilter.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnClearFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            btnClearFilter.Click += BtnClearFilter_Click;

            // Add controls to filter panel
            pnlFilter.Controls.Add(lblFilterLabel);
            pnlFilter.Controls.Add(dtpSelectedDate);
            pnlFilter.Controls.Add(btnClearFilter);

            // Add filter panel to content panel
            this.pnlContent.Controls.Add(pnlFilter);
            pnlFilter.BringToFront();
        }

        private void DtpSelectedDate_ValueChanged(object sender, EventArgs e)
        {
            // Filter activities by selected date
            FilterActivitiesByDate(dtpSelectedDate.Value.Date);
        }

        private void BtnClearFilter_Click(object sender, EventArgs e)
        {
            // Show all activities
            dtpSelectedDate.Value = DateTime.Today;
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

            // Enable grouping
            lvActivities.ShowGroups = true;

            var activities = _logic.GetActivities(_userId);

            if (activities.Count == 0)
            {
                ListViewItem emptyItem = new ListViewItem("No activities recorded");
                lvActivities.Items.Add(emptyItem);
                return;
            }

            // Group by activity type, then by date
            var groupedByType = activities
                .GroupBy(a => a.ActivityType)
                .OrderBy(g => g.Key);

            foreach (var typeGroup in groupedByType)
            {
                // Create group for activity type
                string groupName = $"{typeGroup.Key} ({typeGroup.Count()} activities)";
                ListViewGroup mainGroup = new ListViewGroup(groupName);
                lvActivities.Groups.Add(mainGroup);

                // Sort activities within group by date (newest first)
                var sortedByDate = typeGroup.OrderByDescending(a => a.Date);

                // Get total calories for this activity type
                float typeTotalCalories = typeGroup.Sum(a => a.Calories);

                foreach (var act in sortedByDate)
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
                    item.Group = mainGroup;
                    lvActivities.Items.Add(item);
                }

                // Add summary item for the group
                var summaryItem = new ListViewItem(new[]
                {
                    $"--- {typeGroup.Key} Total ---",
                    "",
                    "",
                    "",
                    "",
                    typeGroup.Sum(a => a.DurationHours).ToString("F2"),
                    "",
                    typeTotalCalories.ToString("F2")
                });
                summaryItem.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
                summaryItem.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
                summaryItem.Group = mainGroup;
                lvActivities.Items.Add(summaryItem);
            }
        }

        // Add filtering method for future use
        private void FilterActivitiesByType(string activityType)
        {
            lvActivities.Items.Clear();
            lvActivities.Groups.Clear();

            var activities = _logic.GetActivities(_userId);

            if (activities.Count == 0)
            {
                ListViewItem emptyItem = new ListViewItem("No activities recorded");
                lvActivities.Items.Add(emptyItem);
                return;
            }

            // Filter by activity type
            var filtered = activities.Where(a => a.ActivityType == activityType).OrderByDescending(a => a.Date);

            if (filtered.Count() == 0)
            {
                ListViewItem emptyItem = new ListViewItem($"No {activityType} activities recorded");
                lvActivities.Items.Add(emptyItem);
                return;
            }

            // Create group
            string groupName = $"{activityType} ({filtered.Count()} activities)";
            ListViewGroup group = new ListViewGroup(groupName);
            lvActivities.Groups.Add(group);

            foreach (var act in filtered)
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
                item.Group = group;
                lvActivities.Items.Add(item);
            }
        }

        // Add filtering method by date range
        private void FilterActivitiesByDateRange(DateTime startDate, DateTime endDate)
        {
            lvActivities.Items.Clear();
            lvActivities.Groups.Clear();

            var activities = _logic.GetActivities(_userId);

            if (activities.Count == 0)
            {
                ListViewItem emptyItem = new ListViewItem("No activities recorded");
                lvActivities.Items.Add(emptyItem);
                return;
            }

            // Filter by date range
            var filtered = activities
                .Where(a => a.Date.Date >= startDate.Date && a.Date.Date <= endDate.Date)
                .OrderByDescending(a => a.Date);

            if (filtered.Count() == 0)
            {
                ListViewItem emptyItem = new ListViewItem("No activities in selected date range");
                lvActivities.Items.Add(emptyItem);
                return;
            }

            // Group by activity type within date range
            var groupedByType = filtered
                .GroupBy(a => a.ActivityType)
                .OrderBy(g => g.Key);

            foreach (var typeGroup in groupedByType)
            {
                string groupName = $"{typeGroup.Key} ({typeGroup.Count()} activities)";
                ListViewGroup mainGroup = new ListViewGroup(groupName);
                lvActivities.Groups.Add(mainGroup);

                var sortedByDate = typeGroup.OrderByDescending(a => a.Date);

                foreach (var act in sortedByDate)
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
                    item.Group = mainGroup;
                    lvActivities.Items.Add(item);
                }

                var summaryItem = new ListViewItem(new[]
                {
                    $"--- {typeGroup.Key} Total ---",
                    "",
                    "",
                    "",
                    "",
                    typeGroup.Sum(a => a.DurationHours).ToString("F2"),
                    "",
                    typeGroup.Sum(a => a.Calories).ToString("F2")
                });
                summaryItem.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
                summaryItem.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
                summaryItem.Group = mainGroup;
                lvActivities.Items.Add(summaryItem);
            }
        }

        // Filter activities by specific date
        private void FilterActivitiesByDate(DateTime selectedDate)
        {
            lvActivities.Items.Clear();
            lvActivities.Groups.Clear();

            var activities = _logic.GetActivities(_userId);

            if (activities.Count == 0)
            {
                ListViewItem emptyItem = new ListViewItem("No activities recorded");
                lvActivities.Items.Add(emptyItem);
                return;
            }

            // Filter by selected date
            var filtered = activities
                .Where(a => a.Date.Date == selectedDate.Date)
                .OrderByDescending(a => a.Date);

            if (filtered.Count() == 0)
            {
                ListViewItem emptyItem = new ListViewItem($"No activities on {selectedDate:yyyy-MM-dd}");
                lvActivities.Items.Add(emptyItem);
                return;
            }

            // Group by activity type for selected date
            var groupedByType = filtered
                .GroupBy(a => a.ActivityType)
                .OrderBy(g => g.Key);

            lvActivities.ShowGroups = true;

            // Display summary for selected date
            float totalCaloriesForDay = filtered.Sum(a => a.Calories);
            float totalDurationForDay = filtered.Sum(a => a.DurationHours);
            int totalActivitiesForDay = filtered.Count();

            // Add a header item showing the date summary
            ListViewGroup dateGroup = new ListViewGroup($"📅 {selectedDate:dddd, MMMM dd, yyyy} - Total: {totalActivitiesForDay} activities");
            lvActivities.Groups.Add(dateGroup);

            foreach (var typeGroup in groupedByType)
            {
                string groupName = $"{typeGroup.Key} ({typeGroup.Count()} activities)";
                ListViewGroup mainGroup = new ListViewGroup(groupName);
                lvActivities.Groups.Add(mainGroup);

                var sortedByTime = typeGroup.OrderByDescending(a => a.Date);

                foreach (var act in sortedByTime)
                {
                    var item = new ListViewItem(new[]
                    {
                        act.ActivityType,
                        act.Date.ToString("HH:mm"),
                        act.Metric1.ToString("F2"),
                        act.Metric2.ToString("F2"),
                        act.Metric3.ToString("F2"),
                        act.DurationHours.ToString("F2"),
                        act.WeightKg.ToString("F2"),
                        act.Calories.ToString("F2")
                    });
                    item.Group = mainGroup;
                    lvActivities.Items.Add(item);
                }

                // Add summary for this activity type
                var summaryItem = new ListViewItem(new[]
                {
                    $"--- {typeGroup.Key} Total ---",
                    "",
                    "",
                    "",
                    "",
                    typeGroup.Sum(a => a.DurationHours).ToString("F2"),
                    "",
                    typeGroup.Sum(a => a.Calories).ToString("F2")
                });
                summaryItem.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
                summaryItem.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
                summaryItem.Group = mainGroup;
                lvActivities.Items.Add(summaryItem);
            }

            // Add total summary for the day at the end
            var dayTotalItem = new ListViewItem(new[]
            {
                $"📅 Daily Total ({selectedDate:yyyy-MM-dd})",
                "",
                "",
                "",
                "",
                totalDurationForDay.ToString("F2"),
                "",
                totalCaloriesForDay.ToString("F2")
            });
            dayTotalItem.BackColor = System.Drawing.Color.FromArgb(200, 220, 255);
            dayTotalItem.ForeColor = System.Drawing.Color.FromArgb(0, 51, 102);
            dayTotalItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lvActivities.Items.Add(dayTotalItem);
        }

        private void pnlCard_Paint(object sender, PaintEventArgs e)
        {
            // No custom painting logic required yet.
        }
    }
}
