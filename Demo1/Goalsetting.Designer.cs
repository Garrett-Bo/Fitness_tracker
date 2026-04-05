namespace Demo1
{
    partial class Goalsetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.btnClose = new System.Windows.Forms.Button();
            this.lblLoggedUser = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnViewProgress = new System.Windows.Forms.Button();
            this.btnRecordActivity = new System.Windows.Forms.Button();
            this.btnSaveGoal = new System.Windows.Forms.Button();
            this.txtGoalCalories = new System.Windows.Forms.TextBox();
            this.lblGoalText = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.lblLoggedUser);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 120);
            this.pnlHeader.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(860, 10);
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
            this.lblLoggedUser.Location = new System.Drawing.Point(12, 9);
            this.lblLoggedUser.Name = "lblLoggedUser";
            this.lblLoggedUser.Size = new System.Drawing.Size(116, 23);
            this.lblLoggedUser.TabIndex = 2;
            this.lblLoggedUser.Text = "Logged in as: ";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(330, 32);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(256, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Set Your Goal";
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Controls.Add(this.lblResult);
            this.pnlContent.Controls.Add(this.btnViewProgress);
            this.pnlContent.Controls.Add(this.btnRecordActivity);
            this.pnlContent.Controls.Add(this.btnSaveGoal);
            this.pnlContent.Controls.Add(this.txtGoalCalories);
            this.pnlContent.Controls.Add(this.lblGoalText);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 120);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(900, 350);
            this.pnlContent.TabIndex = 4;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.lblResult.Location = new System.Drawing.Point(180, 200);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 23);
            this.lblResult.TabIndex = 5;
            // 
            // btnViewProgress
            // 
            this.btnViewProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(39)))), ((int)(((byte)(176)))));
            this.btnViewProgress.FlatAppearance.BorderSize = 0;
            this.btnViewProgress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewProgress.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnViewProgress.ForeColor = System.Drawing.Color.White;
            this.btnViewProgress.Location = new System.Drawing.Point(659, 188);
            this.btnViewProgress.Name = "btnViewProgress";
            this.btnViewProgress.Size = new System.Drawing.Size(160, 45);
            this.btnViewProgress.TabIndex = 7;
            this.btnViewProgress.Text = "View Progress";
            this.btnViewProgress.UseVisualStyleBackColor = false;
            this.btnViewProgress.Click += new System.EventHandler(this.btnViewProgress_Click);
            // 
            // btnRecordActivity
            // 
            this.btnRecordActivity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnRecordActivity.FlatAppearance.BorderSize = 0;
            this.btnRecordActivity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecordActivity.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRecordActivity.ForeColor = System.Drawing.Color.White;
            this.btnRecordActivity.Location = new System.Drawing.Point(370, 188);
            this.btnRecordActivity.Name = "btnRecordActivity";
            this.btnRecordActivity.Size = new System.Drawing.Size(160, 45);
            this.btnRecordActivity.TabIndex = 6;
            this.btnRecordActivity.Text = "Record Activity";
            this.btnRecordActivity.UseVisualStyleBackColor = false;
            this.btnRecordActivity.Click += new System.EventHandler(this.btnRecordActivity_Click);
            // 
            // btnSaveGoal
            // 
            this.btnSaveGoal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnSaveGoal.FlatAppearance.BorderSize = 0;
            this.btnSaveGoal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveGoal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSaveGoal.ForeColor = System.Drawing.Color.White;
            this.btnSaveGoal.Location = new System.Drawing.Point(73, 188);
            this.btnSaveGoal.Name = "btnSaveGoal";
            this.btnSaveGoal.Size = new System.Drawing.Size(160, 45);
            this.btnSaveGoal.TabIndex = 4;
            this.btnSaveGoal.Text = "Save Goal";
            this.btnSaveGoal.UseVisualStyleBackColor = false;
            this.btnSaveGoal.Click += new System.EventHandler(this.btnSaveGoal_Click);
            // 
            // txtGoalCalories
            // 
            this.txtGoalCalories.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGoalCalories.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtGoalCalories.Location = new System.Drawing.Point(401, 70);
            this.txtGoalCalories.Name = "txtGoalCalories";
            this.txtGoalCalories.Size = new System.Drawing.Size(250, 34);
            this.txtGoalCalories.TabIndex = 3;
            this.txtGoalCalories.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblGoalText
            // 
            this.lblGoalText.AutoSize = true;
            this.lblGoalText.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblGoalText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblGoalText.Location = new System.Drawing.Point(181, 75);
            this.lblGoalText.Name = "lblGoalText";
            this.lblGoalText.Size = new System.Drawing.Size(187, 25);
            this.lblGoalText.TabIndex = 1;
            this.lblGoalText.Text = "Goal Calories (kcal):";
            this.lblGoalText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Goalsetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(900, 470);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Goalsetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fitness Tracker - Goal Setting";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblLoggedUser;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblGoalText;
        private System.Windows.Forms.TextBox txtGoalCalories;
        private System.Windows.Forms.Button btnSaveGoal;
        private System.Windows.Forms.Button btnRecordActivity;
        private System.Windows.Forms.Button btnViewProgress;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnClose;
    }
}