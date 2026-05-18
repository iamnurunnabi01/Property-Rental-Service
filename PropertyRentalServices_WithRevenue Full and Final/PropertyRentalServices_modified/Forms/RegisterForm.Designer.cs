namespace PropertyRentalServices.Forms
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelLeft = new System.Windows.Forms.Panel();
            this.lblTagline = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(20, 150, 120);
            this.panelLeft.Controls.Add(this.lblBrand);
            this.panelLeft.Controls.Add(this.lblTagline);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(380, 600);
            this.panelLeft.TabIndex = 0;
            // 
            // lblTagline
            // 
            this.lblTagline.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTagline.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTagline.ForeColor = System.Drawing.Color.FromArgb(180, 240, 220);
            this.lblTagline.Height = 60;
            this.lblTagline.Name = "lblTagline";
            this.lblTagline.Size = new System.Drawing.Size(380, 60);
            this.lblTagline.TabIndex = 1;
            this.lblTagline.Text = "Register as Owner or Customer";
            this.lblTagline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBrand
            // 
            this.lblBrand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.White;
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(380, 540);
            this.lblBrand.TabIndex = 0;
            this.lblBrand.Text = "🏠\r\nJoin Us\r\nToday";
            this.lblBrand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.Controls.Add(this.lblTitle);
            this.panelRight.Controls.Add(this.lblSubtitle);
            this.panelRight.Controls.Add(this.lblName);
            this.panelRight.Controls.Add(this.txtName);
            this.panelRight.Controls.Add(this.lblEmail);
            this.panelRight.Controls.Add(this.txtEmail);
            this.panelRight.Controls.Add(this.lblPassword);
            this.panelRight.Controls.Add(this.txtPassword);
            this.panelRight.Controls.Add(this.lblConfirm);
            this.panelRight.Controls.Add(this.txtConfirm);
            this.panelRight.Controls.Add(this.lblRole);
            this.panelRight.Controls.Add(this.cmbRole);
            this.panelRight.Controls.Add(this.btnRegister);
            this.panelRight.Controls.Add(this.btnBack);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(380, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(520, 600);
            this.panelRight.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(20, 150, 120);
            this.lblTitle.Location = new System.Drawing.Point(50, 40);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Create Account";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitle.Location = new System.Drawing.Point(50, 80);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Fill in the details below";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblName.Location = new System.Drawing.Point(50, 120);
            this.lblName.Name = "lblName";
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Full Name";
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtName.Location = new System.Drawing.Point(50, 140);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(360, 30);
            this.txtName.TabIndex = 3;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblEmail.Location = new System.Drawing.Point(50, 190);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email Address";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtEmail.Location = new System.Drawing.Point(50, 210);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(360, 30);
            this.txtEmail.TabIndex = 5;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblPassword.Location = new System.Drawing.Point(50, 260);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPassword.Location = new System.Drawing.Point(50, 280);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(360, 30);
            this.txtPassword.TabIndex = 7;
            // 
            // lblConfirm
            // 
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblConfirm.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblConfirm.Location = new System.Drawing.Point(50, 330);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.TabIndex = 8;
            this.lblConfirm.Text = "Confirm Password";
            // 
            // txtConfirm
            // 
            this.txtConfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirm.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtConfirm.Location = new System.Drawing.Point(50, 350);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.PasswordChar = '●';
            this.txtConfirm.Size = new System.Drawing.Size(360, 30);
            this.txtConfirm.TabIndex = 9;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblRole.Location = new System.Drawing.Point(50, 400);
            this.lblRole.Name = "lblRole";
            this.lblRole.TabIndex = 10;
            this.lblRole.Text = "Register As";
            // 
            // cmbRole
            // 
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbRole.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbRole.Items.AddRange(new object[] { "Customer", "Owner" });
            this.cmbRole.Location = new System.Drawing.Point(50, 420);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(360, 30);
            this.cmbRole.TabIndex = 11;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(20, 150, 120);
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(50, 475);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(360, 45);
            this.btnRegister.TabIndex = 12;
            this.btnRegister.Text = "CREATE ACCOUNT";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.White;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(20, 150, 120);
            this.btnBack.Location = new System.Drawing.Point(50, 530);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(360, 35);
            this.btnBack.TabIndex = 13;
            this.btnBack.Text = "← Back to Login";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Property Rental Services - Register";
            this.lblBrand.Click += new System.EventHandler(this.LblBrand_Click);
            this.lblTagline.Click += new System.EventHandler(this.LblTagline_Click);
            this.lblTitle.Click += new System.EventHandler(this.LblTitle_Click);
            this.lblSubtitle.Click += new System.EventHandler(this.LblSubtitle_Click);
            this.lblName.Click += new System.EventHandler(this.LblName_Click);
            this.lblEmail.Click += new System.EventHandler(this.LblEmail_Click);
            this.lblPassword.Click += new System.EventHandler(this.LblPassword_Click);
            this.lblConfirm.Click += new System.EventHandler(this.LblConfirm_Click);
            this.lblRole.Click += new System.EventHandler(this.LblRole_Click);
            this.txtName.Enter += new System.EventHandler(this.TxtName_Enter);
            this.txtName.TextChanged += new System.EventHandler(this.TxtName_TextChanged);
            this.txtEmail.Enter += new System.EventHandler(this.TxtEmail_Enter);
            this.txtEmail.TextChanged += new System.EventHandler(this.TxtEmail_TextChanged);
            this.txtPassword.Enter += new System.EventHandler(this.TxtPassword_Enter);
            this.txtPassword.TextChanged += new System.EventHandler(this.TxtPassword_TextChanged);
            this.txtConfirm.Enter += new System.EventHandler(this.TxtConfirm_Enter);
            this.txtConfirm.TextChanged += new System.EventHandler(this.TxtConfirm_TextChanged);
            this.panelLeft.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.cmbRole.SelectedIndexChanged += new System.EventHandler(this.CmbRole_SelectedIndexChanged);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblTagline;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnBack;
    }
}
