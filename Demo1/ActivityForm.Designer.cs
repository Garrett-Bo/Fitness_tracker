namespace Demo1
{
    partial class ActivityForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbActivityType;
        private System.Windows.Forms.TextBox txtMetric1;
        private System.Windows.Forms.TextBox txtMetric2;
        private System.Windows.Forms.TextBox txtMetric3;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Button btnSaveActivity;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblMetric1;
        private System.Windows.Forms.Label lblMetric2;
        private System.Windows.Forms.Label lblMetric3;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblActivityType;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblTitle;

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
            this.btnGoalSetting = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.btnSaveActivity = new System.Windows.Forms.Button();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.lblWeight = new System.Windows.Forms.Label();
            this.txtMetric3 = new System.Windows.Forms.TextBox();
            this.lblMetric3 = new System.Windows.Forms.Label();
            this.txtMetric2 = new System.Windows.Forms.TextBox();
            this.lblMetric2 = new System.Windows.Forms.Label();
            this.txtMetric1 = new System.Windows.Forms.TextBox();
            this.lblMetric1 = new System.Windows.Forms.Label();
            this.cmbActivityType = new System.Windows.Forms.ComboBox();
            this.lblActivityType = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.pnlHeader.Controls.Add(this.btnGoalSetting);
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(700, 90);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnGoalSetting
            // 
            this.btnGoalSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGoalSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnGoalSetting.FlatAppearance.BorderSize = 0;
            this.btnGoalSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoalSetting.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGoalSetting.ForeColor = System.Drawing.Color.White;
            this.btnGoalSetting.Location = new System.Drawing.Point(531, 10);
            this.btnGoalSetting.Name = "btnGoalSetting";
            this.btnGoalSetting.Size = new System.Drawing.Size(119, 30);
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
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(660, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(180, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(345, 46);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Record Your Activity";
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Controls.Add(this.btnSaveActivity);
            this.pnlContent.Controls.Add(this.txtWeight);
            this.pnlContent.Controls.Add(this.lblWeight);
            this.pnlContent.Controls.Add(this.txtMetric3);
            this.pnlContent.Controls.Add(this.lblMetric3);
            this.pnlContent.Controls.Add(this.txtMetric2);
            this.pnlContent.Controls.Add(this.lblMetric2);
            this.pnlContent.Controls.Add(this.txtMetric1);
            this.pnlContent.Controls.Add(this.lblMetric1);
            this.pnlContent.Controls.Add(this.cmbActivityType);
            this.pnlContent.Controls.Add(this.lblActivityType);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 90);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(700, 410);
            this.pnlContent.TabIndex = 1;
            // 
            // btnSaveActivity
            // 
            this.btnSaveActivity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnSaveActivity.FlatAppearance.BorderSize = 0;
            this.btnSaveActivity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveActivity.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSaveActivity.ForeColor = System.Drawing.Color.White;
            this.btnSaveActivity.Location = new System.Drawing.Point(280, 325);
            this.btnSaveActivity.Name = "btnSaveActivity";
            this.btnSaveActivity.Size = new System.Drawing.Size(320, 45);
            this.btnSaveActivity.TabIndex = 10;
            this.btnSaveActivity.Text = "Save Activity";
            this.btnSaveActivity.UseVisualStyleBackColor = false;
            // 
            // txtWeight
            // 
            this.txtWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWeight.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtWeight.Location = new System.Drawing.Point(280, 228);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(320, 30);
            this.txtWeight.TabIndex = 9;
            this.txtWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblWeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblWeight.Location = new System.Drawing.Point(80, 230);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(107, 23);
            this.lblWeight.TabIndex = 8;
            this.lblWeight.Text = "Weight (kg)";
            // 
            // txtMetric3
            // 
            this.txtMetric3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMetric3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMetric3.Location = new System.Drawing.Point(280, 178);
            this.txtMetric3.Name = "txtMetric3";
            this.txtMetric3.Size = new System.Drawing.Size(320, 30);
            this.txtMetric3.TabIndex = 7;
            this.txtMetric3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblMetric3
            // 
            this.lblMetric3.AutoSize = true;
            this.lblMetric3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMetric3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblMetric3.Location = new System.Drawing.Point(80, 180);
            this.lblMetric3.Name = "lblMetric3";
            this.lblMetric3.Size = new System.Drawing.Size(72, 23);
            this.lblMetric3.TabIndex = 6;
            this.lblMetric3.Text = "Metric3";
            // 
            // txtMetric2
            // 
            this.txtMetric2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMetric2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMetric2.Location = new System.Drawing.Point(280, 128);
            this.txtMetric2.Name = "txtMetric2";
            this.txtMetric2.Size = new System.Drawing.Size(320, 30);
            this.txtMetric2.TabIndex = 5;
            this.txtMetric2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblMetric2
            // 
            this.lblMetric2.AutoSize = true;
            this.lblMetric2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMetric2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblMetric2.Location = new System.Drawing.Point(80, 130);
            this.lblMetric2.Name = "lblMetric2";
            this.lblMetric2.Size = new System.Drawing.Size(72, 23);
            this.lblMetric2.TabIndex = 4;
            this.lblMetric2.Text = "Metric2";
            // 
            // txtMetric1
            // 
            this.txtMetric1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMetric1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMetric1.Location = new System.Drawing.Point(280, 78);
            this.txtMetric1.Name = "txtMetric1";
            this.txtMetric1.Size = new System.Drawing.Size(320, 30);
            this.txtMetric1.TabIndex = 3;
            this.txtMetric1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblMetric1
            // 
            this.lblMetric1.AutoSize = true;
            this.lblMetric1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMetric1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblMetric1.Location = new System.Drawing.Point(80, 80);
            this.lblMetric1.Name = "lblMetric1";
            this.lblMetric1.Size = new System.Drawing.Size(72, 23);
            this.lblMetric1.TabIndex = 2;
            this.lblMetric1.Text = "Metric1";
            // 
            // cmbActivityType
            // 
            this.cmbActivityType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActivityType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbActivityType.FormattingEnabled = true;
            this.cmbActivityType.Location = new System.Drawing.Point(280, 28);
            this.cmbActivityType.Name = "cmbActivityType";
            this.cmbActivityType.Size = new System.Drawing.Size(320, 31);
            this.cmbActivityType.TabIndex = 1;
            // 
            // lblActivityType
            // 
            this.lblActivityType.AutoSize = true;
            this.lblActivityType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblActivityType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblActivityType.Location = new System.Drawing.Point(80, 30);
            this.lblActivityType.Name = "lblActivityType";
            this.lblActivityType.Size = new System.Drawing.Size(115, 23);
            this.lblActivityType.TabIndex = 0;
            this.lblActivityType.Text = "Activity Type";
            // 
            // ActivityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ActivityForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fitness Tracker - Record Activity";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
