using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using PropertyRentalServices.Database;

namespace PropertyRentalServices.Forms
{
    public partial class RegisterForm : Form
    {

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void LblBrand_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Property Rental Services\nCreate your account to start browsing or listing properties.",
                "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LblTagline_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Join thousands of property owners and renters on our platform.",
                "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LblTitle_Click(object sender, EventArgs e)
        {
            txtName.Focus();
        }

        private void LblSubtitle_Click(object sender, EventArgs e)
        {
            txtName.Focus();
        }

        private void LblName_Click(object sender, EventArgs e)
        {
            txtName.Focus();
            txtName.SelectAll();
        }

        private void LblEmail_Click(object sender, EventArgs e)
        {
            txtEmail.Focus();
            txtEmail.SelectAll();
        }

        private void LblPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Focus();
            txtPassword.SelectAll();
        }

        private void LblConfirm_Click(object sender, EventArgs e)
        {
            txtConfirm.Focus();
            txtConfirm.SelectAll();
        }

        private void LblRole_Click(object sender, EventArgs e)
        {
            cmbRole.Focus();
            cmbRole.DroppedDown = true;
        }

        private void TxtName_Enter(object sender, EventArgs e)
        {
            txtName.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            bool valid = txtName.Text.Trim().Length >= 2;
            txtName.BackColor = (txtName.Text.Length == 0 || valid)
                ? System.Drawing.Color.FromArgb(240, 248, 255)
                : System.Drawing.Color.FromArgb(255, 235, 235);
        }

        private void TxtEmail_Enter(object sender, EventArgs e)
        {
            txtEmail.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
        }

        private void TxtEmail_TextChanged(object sender, EventArgs e)
        {
            bool valid = txtEmail.Text.Contains("@") && txtEmail.Text.Contains(".");
            txtEmail.BackColor = (txtEmail.Text.Length == 0 || valid)
                ? System.Drawing.Color.FromArgb(240, 248, 255)
                : System.Drawing.Color.FromArgb(255, 235, 235);
        }

        private void TxtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            string pwd = txtPassword.Text;
            if (pwd.Length == 0)
                txtPassword.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            else if (pwd.Length < 6)
                txtPassword.BackColor = System.Drawing.Color.FromArgb(255, 235, 235);
            else
                txtPassword.BackColor = System.Drawing.Color.FromArgb(235, 255, 235);

            // Live confirm match check
            if (txtConfirm.Text.Length > 0)
                txtConfirm.BackColor = (txtConfirm.Text == pwd)
                    ? System.Drawing.Color.FromArgb(235, 255, 235)
                    : System.Drawing.Color.FromArgb(255, 235, 235);
        }

        private void TxtConfirm_Enter(object sender, EventArgs e)
        {
            txtConfirm.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
        }

        private void TxtConfirm_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirm.Text.Length == 0)
                txtConfirm.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            else
                txtConfirm.BackColor = (txtConfirm.Text == txtPassword.Text)
                    ? System.Drawing.Color.FromArgb(235, 255, 235)
                    : System.Drawing.Color.FromArgb(255, 235, 235);
        }
        private void CmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cmbRole.SelectedItem?.ToString();
            if (selected == "Owner")
                MessageBox.Show("Owner Account: You will be able to list properties, manage bookings, and track earnings.",
                    "Role Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (selected == "Customer")
                MessageBox.Show("Customer Account: You will be able to browse properties, book stays, and leave reviews.",
                    "Role Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
