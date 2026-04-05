namespace Demo1
{
    partial class ProgressForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnGoalSetting = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblLoggedUser = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlCard3 = new System.Windows.Forms.Panel();
            this.lblStatusTitle = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.pnlCard2 = new System.Windows.Forms.Panel();
            this.lblGoalCaloriesTitle = new System.Windows.Forms.Label();
            this.lblGoalCalories = new System.Windows.Forms.Label();
            this.pnlCard1 = new System.Windows.Forms.Panel();
            this.lblTotalCaloriesTitle = new System.Windows.Forms.Label();
            this.lblTotalCalories = new System.Windows.Forms.Label();
            this.lvActivities = new System.Windows.Forms.ListView();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlCard3.SuspendLayout();
            this.pnlCard2.SuspendLayout();
            this.pnlCard1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.pnlHeader.Controls.Add(this.btnGoalSetting);
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.lblLoggedUser);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1100, 130);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnGoalSetting
            // 
            this.btnGoalSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGoalSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnGoalSetting.FlatAppearance.BorderSize = 0;
            this.btnGoalSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoalSetting.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGoalSetting.ForeColor = System.Drawing.Color.White;
            this.btnGoalSetting.Location = new System.Drawing.Point(911, 10);
            this.btnGoalSetting.Name = "btnGoalSetting";
            this.btnGoalSetting.Size = new System.Drawing.Size(139, 30);
            this.btnGoalSetting.TabIndex = 11;
            this.btnGoalSetting.Text = "My Goals";
            this.btnGoalSetting.UseVisualStyleBackColor = false;
            this.btnGoalSetting.Click += new System.EventHandler(this.btnGoalSetting_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1060, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblLoggedUser
            // 
            this.lblLoggedUser.AutoSize = true;
            this.lblLoggedUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLoggedUser.ForeColor = System.Drawing.Color.White;
            this.lblLoggedUser.Location = new System.Drawing.Point(30, 90);
            this.lblLoggedUser.Name = "lblLoggedUser";
            this.lblLoggedUser.Size = new System.Drawing.Size(116, 23);
            this.lblLoggedUser.TabIndex = 1;
            this.lblLoggedUser.Text = "Logged in as: ";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(200, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(545, 54);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Fitness Progress Dashboard";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlContent.Controls.Add(this.btnRefresh);
            this.pnlContent.Controls.Add(this.pnlCard3);
            this.pnlContent.Controls.Add(this.pnlCard2);
            this.pnlContent.Controls.Add(this.pnlCard1);
            this.pnlContent.Controls.Add(this.lvActivities);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 130);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1100, 520);
            this.pnlContent.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(447, 268);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(200, 45);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh Data";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlCard3
            // 
            this.pnlCard3.BackColor = System.Drawing.Color.White;
            this.pnlCard3.Controls.Add(this.lblStatusTitle);
            this.pnlCard3.Controls.Add(this.lblResult);
            this.pnlCard3.Location = new System.Drawing.Point(700, 20);
            this.pnlCard3.Name = "pnlCard3";
            this.pnlCard3.Size = new System.Drawing.Size(300, 230);
            this.pnlCard3.TabIndex = 4;
            this.pnlCard3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlCard3.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCard_Paint);
            // 
            // lblStatusTitle
            // 
            this.lblStatusTitle.BackColor = System.Drawing.Color.White;
            this.lblStatusTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblStatusTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.lblStatusTitle.Location = new System.Drawing.Point(0, 10);
            this.lblStatusTitle.Name = "lblStatusTitle";
            this.lblStatusTitle.Size = new System.Drawing.Size(300, 50);
            this.lblStatusTitle.TabIndex = 0;
            this.lblStatusTitle.Text = "Goal Status";
            this.lblStatusTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblResult
            // 
            this.lblResult.BackColor = System.Drawing.Color.White;
            this.lblResult.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.lblResult.Location = new System.Drawing.Point(10, 70);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(280, 120);
            this.lblResult.TabIndex = 1;
            this.lblResult.Text = "Loading...";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCard2
            // 
            this.pnlCard2.BackColor = System.Drawing.Color.White;
            this.pnlCard2.Controls.Add(this.lblGoalCaloriesTitle);
            this.pnlCard2.Controls.Add(this.lblGoalCalories);
            this.pnlCard2.Location = new System.Drawing.Point(400, 20);
            this.pnlCard2.Name = "pnlCard2";
            this.pnlCard2.Size = new System.Drawing.Size(300, 230);
            this.pnlCard2.TabIndex = 3;
            this.pnlCard2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlCard2.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCard_Paint);
            // 
            // lblGoalCaloriesTitle
            // 
            this.lblGoalCaloriesTitle.BackColor = System.Drawing.Color.White;
            this.lblGoalCaloriesTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblGoalCaloriesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.lblGoalCaloriesTitle.Location = new System.Drawing.Point(0, 10);
            this.lblGoalCaloriesTitle.Name = "lblGoalCaloriesTitle";
            this.lblGoalCaloriesTitle.Size = new System.Drawing.Size(300, 50);
            this.lblGoalCaloriesTitle.TabIndex = 0;
            this.lblGoalCaloriesTitle.Text = "Goal Calories";
            this.lblGoalCaloriesTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblGoalCalories
            // 
            this.lblGoalCalories.BackColor = System.Drawing.Color.White;
            this.lblGoalCalories.Font = new System.Drawing.Font("Segoe UI", 56F, System.Drawing.FontStyle.Bold);
            this.lblGoalCalories.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.lblGoalCalories.Location = new System.Drawing.Point(0, 70);
            this.lblGoalCalories.Name = "lblGoalCalories";
            this.lblGoalCalories.Size = new System.Drawing.Size(300, 130);
            this.lblGoalCalories.TabIndex = 1;
            this.lblGoalCalories.Text = "0";
            this.lblGoalCalories.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCard1
            // 
            this.pnlCard1.BackColor = System.Drawing.Color.White;
            this.pnlCard1.Controls.Add(this.lblTotalCaloriesTitle);
            this.pnlCard1.Controls.Add(this.lblTotalCalories);
            this.pnlCard1.Location = new System.Drawing.Point(100, 20);
            this.pnlCard1.Name = "pnlCard1";
            this.pnlCard1.Size = new System.Drawing.Size(300, 230);
            this.pnlCard1.TabIndex = 2;
            this.pnlCard1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlCard1.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCard_Paint);
            // 
            // lblTotalCaloriesTitle
            // 
            this.lblTotalCaloriesTitle.BackColor = System.Drawing.Color.White;
            this.lblTotalCaloriesTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalCaloriesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.lblTotalCaloriesTitle.Location = new System.Drawing.Point(-3, 20);
            this.lblTotalCaloriesTitle.Name = "lblTotalCaloriesTitle";
            this.lblTotalCaloriesTitle.Size = new System.Drawing.Size(300, 50);
            this.lblTotalCaloriesTitle.TabIndex = 0;
            this.lblTotalCaloriesTitle.Text = "Total Calories Burned";
            this.lblTotalCaloriesTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTotalCalories
            // 
            this.lblTotalCalories.BackColor = System.Drawing.Color.White;
            this.lblTotalCalories.Font = new System.Drawing.Font("Segoe UI", 56F, System.Drawing.FontStyle.Bold);
            this.lblTotalCalories.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.lblTotalCalories.Location = new System.Drawing.Point(0, 70);
            this.lblTotalCalories.Name = "lblTotalCalories";
            this.lblTotalCalories.Size = new System.Drawing.Size(300, 130);
            this.lblTotalCalories.TabIndex = 1;
            this.lblTotalCalories.Text = "0";
            this.lblTotalCalories.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvActivities
            // 
            this.lvActivities.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lvActivities.BackColor = System.Drawing.Color.White;
            this.lvActivities.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvActivities.FullRowSelect = true;
            this.lvActivities.GridLines = true;
            this.lvActivities.HideSelection = false;
            this.lvActivities.Location = new System.Drawing.Point(25, 340);
            this.lvActivities.Name = "lvActivities";
            this.lvActivities.Size = new System.Drawing.Size(1050, 280);
            this.lvActivities.TabIndex = 6;
            this.lvActivities.UseCompatibleStateImageBehavior = false;
            this.lvActivities.View = System.Windows.Forms.View.Details;
            this.lvActivities.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProgressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fitness Tracker - Progress";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlCard3.ResumeLayout(false);
            this.pnlCard2.ResumeLayout(false);
            this.pnlCard1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblLoggedUser;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlCard3;
        private System.Windows.Forms.Label lblStatusTitle;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Panel pnlCard2;
        private System.Windows.Forms.Label lblGoalCaloriesTitle;
        private System.Windows.Forms.Label lblGoalCalories;
        private System.Windows.Forms.Panel pnlCard1;
        private System.Windows.Forms.Label lblTotalCaloriesTitle;
        private System.Windows.Forms.Label lblTotalCalories;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView lvActivities;
    }
}
