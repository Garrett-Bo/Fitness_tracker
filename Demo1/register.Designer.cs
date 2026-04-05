namespace Demo1
{
    partial class register
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
            this.backbtn = new System.Windows.Forms.LinkLabel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblPasswordError = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnconfirmregister = new System.Windows.Forms.Button();
            this.inputconfirmpassword = new System.Windows.Forms.TextBox();
            this.txtconfirmpassword = new System.Windows.Forms.Label();
            this.inputpassword = new System.Windows.Forms.TextBox();
            this.txtpassword = new System.Windows.Forms.Label();
            this.inputusername = new System.Windows.Forms.TextBox();
            this.txtusername = new System.Windows.Forms.Label();
            this.btnShowPassword = new System.Windows.Forms.Button();
            this.btnShowConfirmPassword = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.backbtn);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(800, 100);
            this.pnlHeader.TabIndex = 12;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(760, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // backbtn
            // 
            this.backbtn.ActiveLinkColor = System.Drawing.Color.White;
            this.backbtn.AutoSize = true;
            this.backbtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.backbtn.ForeColor = System.Drawing.Color.White;
            this.backbtn.LinkColor = System.Drawing.Color.White;
            this.backbtn.Location = new System.Drawing.Point(15, 15);
            this.backbtn.Name = "backbtn";
            this.backbtn.Size = new System.Drawing.Size(180, 20);
            this.backbtn.TabIndex = 8;
            this.backbtn.TabStop = true;
            this.backbtn.Text = "← Go back to Welcome";
            this.backbtn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.backbtn_LinkClicked);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(250, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CREATE ACCOUNT";
            // 
            // pnlForm
            // 
            this.pnlForm.BackColor = System.Drawing.Color.White;
            this.pnlForm.Controls.Add(this.lblPasswordError);
            this.pnlForm.Controls.Add(this.lblMessage);
            this.pnlForm.Controls.Add(this.btnconfirmregister);
            this.pnlForm.Controls.Add(this.inputconfirmpassword);
            this.pnlForm.Controls.Add(this.txtconfirmpassword);
            this.pnlForm.Controls.Add(this.inputpassword);
            this.pnlForm.Controls.Add(this.txtpassword);
            this.pnlForm.Controls.Add(this.inputusername);
            this.pnlForm.Controls.Add(this.txtusername);
            this.pnlForm.Controls.Add(this.btnShowPassword);
            this.pnlForm.Controls.Add(this.btnShowConfirmPassword);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(0, 100);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(800, 450);
            this.pnlForm.TabIndex = 13;
            // 
            // txtusername
            // 
            this.txtusername.AutoSize = true;
            this.txtusername.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtusername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtusername.Location = new System.Drawing.Point(150, 60);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(115, 25);
            this.txtusername.TabIndex = 2;
            this.txtusername.Text = "Username";
            this.txtusername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // inputusername
            // 
            this.inputusername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputusername.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.inputusername.Location = new System.Drawing.Point(150, 95);
            this.inputusername.Name = "inputusername";
            this.inputusername.Size = new System.Drawing.Size(500, 32);
            this.inputusername.TabIndex = 3;
            this.inputusername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.inputusername.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtpassword
            // 
            this.txtpassword.AutoSize = true;
            this.txtpassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtpassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtpassword.Location = new System.Drawing.Point(150, 150);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(107, 25);
            this.txtpassword.TabIndex = 4;
            this.txtpassword.Text = "Password";
            // 
            // inputpassword
            // 
            this.inputpassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputpassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.inputpassword.Location = new System.Drawing.Point(150, 185);
            this.inputpassword.Name = "inputpassword";
            this.inputpassword.Size = new System.Drawing.Size(500, 32);
            this.inputpassword.TabIndex = 5;
            this.inputpassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.inputpassword.UseSystemPasswordChar = true;
            this.inputpassword.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // lblPasswordError
            // 
            this.lblPasswordError.AutoSize = true;
            this.lblPasswordError.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPasswordError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.lblPasswordError.Location = new System.Drawing.Point(150, 222);
            this.lblPasswordError.Name = "lblPasswordError";
            this.lblPasswordError.Size = new System.Drawing.Size(0, 20);
            this.lblPasswordError.TabIndex = 9;
            // 
            // txtconfirmpassword
            // 
            this.txtconfirmpassword.AutoSize = true;
            this.txtconfirmpassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtconfirmpassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtconfirmpassword.Location = new System.Drawing.Point(150, 240);
            this.txtconfirmpassword.Name = "txtconfirmpassword";
            this.txtconfirmpassword.Size = new System.Drawing.Size(153, 25);
            this.txtconfirmpassword.TabIndex = 6;
            this.txtconfirmpassword.Text = "Confirm Password";
            // 
            // inputconfirmpassword
            // 
            this.inputconfirmpassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputconfirmpassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.inputconfirmpassword.Location = new System.Drawing.Point(150, 275);
            this.inputconfirmpassword.Name = "inputconfirmpassword";
            this.inputconfirmpassword.Size = new System.Drawing.Size(500, 32);
            this.inputconfirmpassword.TabIndex = 7;
            this.inputconfirmpassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.inputconfirmpassword.UseSystemPasswordChar = true;
            this.inputconfirmpassword.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // btnconfirmregister
            // 
            this.btnconfirmregister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnconfirmregister.FlatAppearance.BorderSize = 0;
            this.btnconfirmregister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnconfirmregister.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnconfirmregister.ForeColor = System.Drawing.Color.White;
            this.btnconfirmregister.Location = new System.Drawing.Point(300, 340);
            this.btnconfirmregister.Name = "btnconfirmregister";
            this.btnconfirmregister.Size = new System.Drawing.Size(200, 45);
            this.btnconfirmregister.TabIndex = 1;
            this.btnconfirmregister.Text = "REGISTER";
            this.btnconfirmregister.UseVisualStyleBackColor = false;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.lblMessage.Location = new System.Drawing.Point(150, 390);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 23);
            this.lblMessage.TabIndex = 9;
            // 
            // btnShowPassword
            // 
            this.btnShowPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnShowPassword.Location = new System.Drawing.Point(650, 140);
            this.btnShowPassword.Name = "btnShowPassword";
            this.btnShowPassword.Size = new System.Drawing.Size(60, 32);
            this.btnShowPassword.TabIndex = 9;
            this.btnShowPassword.Text = "Show";
            this.btnShowPassword.UseVisualStyleBackColor = true;
            this.btnShowPassword.Click += new System.EventHandler(this.btnShowPassword_Click);
            // 
            // btnShowConfirmPassword
            // 
            this.btnShowConfirmPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnShowConfirmPassword.Location = new System.Drawing.Point(650, 220);
            this.btnShowConfirmPassword.Name = "btnShowConfirmPassword";
            this.btnShowConfirmPassword.Size = new System.Drawing.Size(60, 32);
            this.btnShowConfirmPassword.TabIndex = 10;
            this.btnShowConfirmPassword.Text = "Show";
            this.btnShowConfirmPassword.UseVisualStyleBackColor = true;
            this.btnShowConfirmPassword.Click += new System.EventHandler(this.btnShowConfirmPassword_Click);
            // 
            // register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fitness Tracker - Register";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.LinkLabel backbtn;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Button btnconfirmregister;
        private System.Windows.Forms.TextBox inputconfirmpassword;
        private System.Windows.Forms.Label txtconfirmpassword;
        private System.Windows.Forms.TextBox inputpassword;
        private System.Windows.Forms.Label txtpassword;
        private System.Windows.Forms.TextBox inputusername;
        private System.Windows.Forms.Label txtusername;
        private System.Windows.Forms.Label lblPasswordError;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnShowPassword;
        private System.Windows.Forms.Button btnShowConfirmPassword;
    }
}