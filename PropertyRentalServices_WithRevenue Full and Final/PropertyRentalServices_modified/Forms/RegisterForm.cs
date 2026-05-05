using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using PropertyRentalServices.Database;

namespace PropertyRentalServices.Forms
{
    public class RegisterForm : Form
    {
        private TextBox txtName, txtEmail, txtPassword, txtConfirm;
        private ComboBox cmbRole;
        private Button btnRegister, btnBack;
        private Panel panelLeft, panelRight;

        public RegisterForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Property Rental Services - Register";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.White;

            // Left branding panel
            panelLeft = new Panel
            {
                Dock = DockStyle.Left,
                Width = 380,
                BackColor = Color.FromArgb(20, 150, 120)
            };

            var lblBrand = new Label
            {
                Text = "🏠\r\nJoin Us\r\nToday",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            var lblTagline = new Label
            {
                Text = "Register as Owner or Customer",
                ForeColor = Color.FromArgb(180, 240, 220),
                Font = new Font("Segoe UI", 11),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Bottom,
                Height = 60
            };

            panelLeft.Controls.Add(lblBrand);
            panelLeft.Controls.Add(lblTagline);

            // Right panel
            panelRight = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            int y = 40;
            int x = 50;
            int w = 360;

            var lblTitle = new Label
            {
                Text = "Create Account",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.FromArgb(20, 150, 120),
                Location = new Point(x, y), AutoSize = true
            };

            y += 40;
            var lblSub = new Label
            {
                Text = "Fill in the details below",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray,
                Location = new Point(x, y), AutoSize = true
            };

            y += 40;
            panelRight.Controls.Add(MakeLabel("Full Name", x, y));
            y += 20;
            txtName = MakeTextBox(x, y, w, "Your full name");

            y += 50;
            panelRight.Controls.Add(MakeLabel("Email Address", x, y));
            y += 20;
            txtEmail = MakeTextBox(x, y, w, "email@example.com");

            y += 50;
            panelRight.Controls.Add(MakeLabel("Password", x, y));
            y += 20;
            txtPassword = MakeTextBox(x, y, w, "Enter password", true);

            y += 50;
            panelRight.Controls.Add(MakeLabel("Confirm Password", x, y));
            y += 20;
            txtConfirm = MakeTextBox(x, y, w, "Repeat password", true);

            y += 50;
            panelRight.Controls.Add(MakeLabel("Register As", x, y));
            y += 20;
            cmbRole = new ComboBox
            {
                Location = new Point(x, y),
                Size = new Size(w, 35),
                Font = new Font("Segoe UI", 11),
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle = FlatStyle.Flat
            };
            cmbRole.Items.AddRange(new object[] { "Customer", "Owner" });
            cmbRole.SelectedIndex = 0;

            y += 55;
            btnRegister = new Button
            {
                Text = "CREATE ACCOUNT",
                Location = new Point(x, y),
                Size = new Size(w, 45),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                BackColor = Color.FromArgb(20, 150, 120),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.Click += BtnRegister_Click;

            y += 55;
            btnBack = new Button
            {
                Text = "← Back to Login",
                Location = new Point(x, y),
                Size = new Size(w, 35),
                Font = new Font("Segoe UI", 10),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(20, 150, 120),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Click += (s, e) => this.Close();

            panelRight.Controls.AddRange(new Control[]
            {
                lblTitle, lblSub, txtName, txtEmail,
                txtPassword, txtConfirm, cmbRole,
                btnRegister, btnBack
            });

            this.Controls.Add(panelRight);
            this.Controls.Add(panelLeft);
        }

        private Label MakeLabel(string text, int x, int y)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 60, 60),
                Location = new Point(x, y),
                AutoSize = true
            };
        }

        private TextBox MakeTextBox(int x, int y, int w, string placeholder, bool isPassword = false)
        {
            var tb = new TextBox
            {
                Location = new Point(x, y),
                Size = new Size(w, 35),
                Font = new Font("Segoe UI", 11),
                BorderStyle = BorderStyle.FixedSingle,
            };
            if (isPassword) tb.PasswordChar = '●';
            return tb;
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirm = txtConfirm.Text.Trim();
            string role = cmbRole.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirm))
            {
                MessageBox.Show("All fields are required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirm)
            {
                MessageBox.Show("Passwords do not match.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check email exists
            string checkSql = "SELECT COUNT(*) FROM Users WHERE Email=@Email";
            object count = DBConnection.ExecuteScalar(checkSql,
                new SqlParameter[] { new SqlParameter("@Email", email) });

            if (Convert.ToInt32(count) > 0)
            {
                MessageBox.Show("This email is already registered.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string sql = "INSERT INTO Users (Name, Email, Password, Role) VALUES (@Name, @Email, @Password, @Role)";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", name),
                new SqlParameter("@Email", email),
                new SqlParameter("@Password", password),
                new SqlParameter("@Role", role)
            };

            int result = DBConnection.ExecuteNonQuery(sql, parameters);

            if (result > 0)
            {
                MessageBox.Show("Registration successful! You can now login.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
