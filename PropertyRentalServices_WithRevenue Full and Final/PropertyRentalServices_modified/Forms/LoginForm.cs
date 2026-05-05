using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using PropertyRentalServices.Database;
using PropertyRentalServices.Models;

namespace PropertyRentalServices.Forms
{
    public class LoginForm : Form
    {
        private Panel panelLeft, panelRight;
        private Label lblTitle, lblSubtitle, lblEmail, lblPassword, lblBrand;
        private TextBox txtEmail, txtPassword;
        private Button btnLogin, btnRegister;
        private CheckBox chkShowPassword;
        private PictureBox picLogo;

        public LoginForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Property Rental Services - Login";
            this.Size = new Size(900, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.White;

            // Left Panel - Branding
            panelLeft = new Panel
            {
                Dock = DockStyle.Left,
                Width = 380,
                BackColor = Color.FromArgb(30, 60, 114)
            };

            lblBrand = new Label
            {
                Text = "🏠\r\nProperty\r\nRental\r\nServices",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            var lblTagline = new Label
            {
                Text = "Find your perfect rental property",
                ForeColor = Color.FromArgb(180, 210, 255),
                Font = new Font("Segoe UI", 11),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Bottom,
                Height = 60
            };

            panelLeft.Controls.Add(lblBrand);
            panelLeft.Controls.Add(lblTagline);

            // Right Panel - Login Form
            panelRight = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(50, 30, 50, 30)
            };

            lblTitle = new Label
            {
                Text = "Welcome Back",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 60, 114),
                Location = new Point(50, 60),
                AutoSize = true
            };

            lblSubtitle = new Label
            {
                Text = "Sign in to your account",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray,
                Location = new Point(50, 95),
                AutoSize = true
            };

            lblEmail = new Label
            {
                Text = "Email Address",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 60, 60),
                Location = new Point(50, 150),
                AutoSize = true
            };

            txtEmail = new TextBox
            {
                Location = new Point(50, 170),
                Size = new Size(360, 35),
                Font = new Font("Segoe UI", 11),
                BorderStyle = BorderStyle.FixedSingle,

            };

            lblPassword = new Label
            {
                Text = "Password",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 60, 60),
                Location = new Point(50, 220),
                AutoSize = true
            };

            txtPassword = new TextBox
            {
                Location = new Point(50, 240),
                Size = new Size(360, 35),
                Font = new Font("Segoe UI", 11),
                BorderStyle = BorderStyle.FixedSingle,
                PasswordChar = '●',

            };

            chkShowPassword = new CheckBox
            {
                Text = "Show password",
                Location = new Point(50, 282),
                AutoSize = true,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray
            };
            chkShowPassword.CheckedChanged += (s, e) =>
                txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '●';

            btnLogin = new Button
            {
                Text = "SIGN IN",
                Location = new Point(50, 330),
                Size = new Size(360, 45),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                BackColor = Color.FromArgb(30, 60, 114),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Click += BtnLogin_Click;

            var lblOr = new Label
            {
                Text = "─────────── or ───────────",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.LightGray,
                Location = new Point(50, 390),
                AutoSize = true
            };

            btnRegister = new Button
            {
                Text = "Create New Account",
                Location = new Point(50, 420),
                Size = new Size(360, 42),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(30, 60, 114),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnRegister.FlatAppearance.BorderColor = Color.FromArgb(30, 60, 114);
            btnRegister.FlatAppearance.BorderSize = 2;
            btnRegister.Click += (s, e) =>
            {
                new RegisterForm().ShowDialog();
            };

            panelRight.Controls.AddRange(new Control[]
            {
                lblTitle, lblSubtitle, lblEmail, txtEmail,
                lblPassword, txtPassword, chkShowPassword,
                btnLogin, lblOr, btnRegister
            });

            this.Controls.Add(panelRight);
            this.Controls.Add(panelLeft);

            this.KeyPreview = true;
            this.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) BtnLogin_Click(s, e); };
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both email and password.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sql = "SELECT UserId, Name, Email, Role FROM Users WHERE Email=@Email AND Password=@Password";
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@Email", email),
                    new SqlParameter("@Password", password)
                };

                DataTable dt = DBConnection.ExecuteQuery(sql, parameters);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Invalid email or password.", "Login Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    return;
                }

                DataRow row = dt.Rows[0];
                SessionManager.UserId = Convert.ToInt32(row["UserId"]);
                SessionManager.UserName = row["Name"].ToString();
                SessionManager.UserEmail = row["Email"].ToString();
                SessionManager.UserRole = row["Role"].ToString();

                this.Hide();

                switch (SessionManager.UserRole)
                {
                    case "SuperAdmin":
                        new AdminDashboard().Show();
                        break;
                    case "Owner":
                        new OwnerDashboard().Show();
                        break;
                    case "Customer":
                        new CustomerDashboard().Show();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
