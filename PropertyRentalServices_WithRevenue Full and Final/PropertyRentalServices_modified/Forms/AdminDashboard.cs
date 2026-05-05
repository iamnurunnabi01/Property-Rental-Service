using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using PropertyRentalServices.Database;
using PropertyRentalServices.Models;

namespace PropertyRentalServices.Forms
{
    public class AdminDashboard : Form
    {
        private Panel panelSidebar, panelContent, panelHeader;
        private DataGridView dgvUsers, dgvProperties, dgvBookings, dgvReviews, dgvRevenue;
        private TabControl tabControl;
        private Label lblWelcome;
        private Label lblTotalRentValue, lblAdminShareValue, lblTotalPaymentsValue;

        public AdminDashboard()
        {
            InitializeComponents();
            LoadAllData();
        }

        private void InitializeComponents()
        {
            this.Text = "SuperAdmin Dashboard - Property Rental Services";
            this.Size = new Size(1200, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.MinimumSize = new Size(1000, 600);

            // Header
            panelHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = Color.FromArgb(30, 60, 114)
            };

            lblWelcome = new Label
            {
                Text = $"👑  SuperAdmin Panel  |  Welcome, {SessionManager.UserName}",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0)
            };

            var btnLogout = new Button
            {
                Text = "Logout",
                Dock = DockStyle.Right,
                Width = 100,
                BackColor = Color.FromArgb(200, 50, 50),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Click += (s, e) => Logout();

            panelHeader.Controls.Add(lblWelcome);
            panelHeader.Controls.Add(btnLogout);

            // Stats Row
            var panelStats = new Panel
            {
                Dock = DockStyle.Top,
                Height = 100,
                BackColor = Color.FromArgb(245, 247, 250),
                Padding = new Padding(10)
            };

            panelStats.Controls.Add(CreateStatCard("Total Users", GetCount("Users"), Color.FromArgb(30, 60, 114), 10));
            panelStats.Controls.Add(CreateStatCard("Properties", GetCount("Property"), Color.FromArgb(20, 150, 120), 210));
            panelStats.Controls.Add(CreateStatCard("Bookings", GetCount("Booking"), Color.FromArgb(255, 140, 0), 410));
            panelStats.Controls.Add(CreateStatCard("Revenue (৳)", GetTotalRevenue(), Color.FromArgb(150, 50, 200), 610));

            // Tab Control
            tabControl = new TabControl
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10),
                Margin = new Padding(10)
            };

            tabControl.TabPages.Add(CreateUsersTab());
            tabControl.TabPages.Add(CreatePropertiesTab());
            tabControl.TabPages.Add(CreateBookingsTab());
            tabControl.TabPages.Add(CreateReviewsTab());
            tabControl.TabPages.Add(CreateRevenueTab());

            panelContent = new Panel { Dock = DockStyle.Fill, Padding = new Padding(10) };
            panelContent.Controls.Add(tabControl);

            this.Controls.Add(panelContent);
            this.Controls.Add(panelStats);
            this.Controls.Add(panelHeader);

            this.FormClosed += (s, e) =>
            {
                SessionManager.Clear();
                Application.Exit();
            };
        }

        private Panel CreateStatCard(string title, string value, Color color, int left)
        {
            var card = new Panel
            {
                Size = new Size(185, 80),
                Location = new Point(left, 10),
                BackColor = Color.White
            };
            card.Paint += (s, e) =>
            {
                e.Graphics.FillRectangle(new SolidBrush(color), 0, 0, 8, 80);
            };

            var lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                Location = new Point(18, 12),
                AutoSize = true
            };

            var lblValue = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = color,
                Location = new Point(15, 30),
                AutoSize = true
            };

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblValue);
            return card;
        }

        private string GetCount(string table)
        {
            object result = DBConnection.ExecuteScalar($"SELECT COUNT(*) FROM {table}");
            return result?.ToString() ?? "0";
        }

        private string GetTotalRevenue()
        {
            object result = DBConnection.ExecuteScalar("SELECT ISNULL(SUM(Amount),0) FROM Payment");
            return result != null ? Convert.ToDecimal(result).ToString("N0") : "0";
        }

        private TabPage CreateUsersTab()
        {
            var tab = new TabPage("👥  All Users");
            tab.BackColor = Color.White;

            var toolbar = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.FromArgb(240, 244, 255),
                Padding = new Padding(5)
            };

            var btnRefresh = MakeButton("🔄 Refresh", Color.FromArgb(30, 60, 114));
            btnRefresh.Click += (s, e) => LoadUsers();

            var btnDeleteOwner = MakeButton("🗑 Delete Owner (Low Rating)", Color.FromArgb(200, 50, 50));
            btnDeleteOwner.Click += BtnDeleteOwner_Click;

            toolbar.Controls.AddRange(new Control[] { btnRefresh, btnDeleteOwner });

            dgvUsers = CreateDGV();
            tab.Controls.Add(dgvUsers);
            tab.Controls.Add(toolbar);
            return tab;
        }

        private TabPage CreatePropertiesTab()
        {
            var tab = new TabPage("🏠  All Properties");
            tab.BackColor = Color.White;

            var toolbar = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.FromArgb(240, 255, 248),
                Padding = new Padding(5)
            };

            var btnRefresh = MakeButton("🔄 Refresh", Color.FromArgb(20, 150, 120));
            btnRefresh.Click += (s, e) => LoadProperties();

            toolbar.Controls.Add(btnRefresh);

            dgvProperties = CreateDGV();
            tab.Controls.Add(dgvProperties);
            tab.Controls.Add(toolbar);
            return tab;
        }

        private TabPage CreateBookingsTab()
        {
            var tab = new TabPage("📅  All Bookings");
            tab.BackColor = Color.White;

            var toolbar = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.FromArgb(255, 250, 240),
                Padding = new Padding(5)
            };

            var btnRefresh = MakeButton("🔄 Refresh", Color.FromArgb(255, 140, 0));
            btnRefresh.Click += (s, e) => LoadBookings();
            toolbar.Controls.Add(btnRefresh);

            dgvBookings = CreateDGV();
            tab.Controls.Add(dgvBookings);
            tab.Controls.Add(toolbar);
            return tab;
        }

        private TabPage CreateReviewsTab()
        {
            var tab = new TabPage("⭐  All Reviews");
            tab.BackColor = Color.White;

            var toolbar = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.FromArgb(250, 245, 255),
                Padding = new Padding(5)
            };

            var btnRefresh = MakeButton("🔄 Refresh", Color.FromArgb(150, 50, 200));
            btnRefresh.Click += (s, e) => LoadReviews();
            toolbar.Controls.Add(btnRefresh);

            dgvReviews = CreateDGV();
            tab.Controls.Add(dgvReviews);
            tab.Controls.Add(toolbar);
            return tab;
        }

        private DataGridView CreateDGV()
        {
            var dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                GridColor = Color.FromArgb(230, 235, 245),
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersVisible = false,
                Font = new Font("Segoe UI", 9.5f)
            };
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 60, 114);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 38;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 255);
            return dgv;
        }

        private Button MakeButton(string text, Color color)
        {
            var btn = new Button
            {
                Text = text,
                BackColor = color,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Height = 36,
                AutoSize = true,
                Padding = new Padding(8, 0, 8, 0),
                Cursor = Cursors.Hand,
                Margin = new Padding(5, 5, 5, 5)
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        private void LoadAllData()
        {
            LoadUsers();
            LoadProperties();
            LoadBookings();
            LoadReviews();
            LoadRevenue();
        }

        private void LoadUsers()
        {
            string sql = "SELECT UserId, Name, Email, Role, CreatedAt FROM Users ORDER BY CreatedAt DESC";
            dgvUsers.DataSource = DBConnection.ExecuteQuery(sql);
        }

        private void LoadProperties()
        {
            string sql = @"SELECT p.PropertyId, p.Title, p.Location, p.Price, p.Bedrooms, p.Status,
                           u.Name AS Owner, p.CreatedAt
                           FROM Property p JOIN Users u ON p.OwnerId=u.UserId
                           ORDER BY p.CreatedAt DESC";
            dgvProperties.DataSource = DBConnection.ExecuteQuery(sql);
        }

        private void LoadBookings()
        {
            string sql = @"SELECT b.BookingId, p.Title AS Property, u.Name AS Customer,
                           b.StartDate, b.EndDate, b.TotalPrice, b.Status, b.BookedAt
                           FROM Booking b
                           JOIN Property p ON b.PropertyId=p.PropertyId
                           JOIN Users u ON b.CustomerId=u.UserId
                           ORDER BY b.BookedAt DESC";
            dgvBookings.DataSource = DBConnection.ExecuteQuery(sql);
        }

        private void LoadReviews()
        {
            string sql = @"SELECT r.ReviewId, p.Title AS Property, u.Name AS Reviewer,
                           r.Rating, r.Comment, r.ReviewDate
                           FROM Review r
                           JOIN Property p ON r.PropertyId=p.PropertyId
                           JOIN Users u ON r.UserId=u.UserId
                           ORDER BY r.ReviewDate DESC";
            dgvReviews.DataSource = DBConnection.ExecuteQuery(sql);
        }

        private void BtnDeleteOwner_Click(object sender, EventArgs e)
        {
            // Find owners with avg rating < 2
            string sql = @"SELECT u.UserId, u.Name, u.Email,
                           AVG(CAST(r.Rating AS FLOAT)) AS AvgRating
                           FROM Users u
                           JOIN Property p ON u.UserId=p.OwnerId
                           JOIN Review r ON p.PropertyId=r.PropertyId
                           WHERE u.Role='Owner'
                           GROUP BY u.UserId, u.Name, u.Email
                           HAVING AVG(CAST(r.Rating AS FLOAT)) < 2";

            DataTable dt = DBConnection.ExecuteQuery(sql);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No owners with low ratings (below 2.0) found.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string ownerList = "";
            foreach (DataRow row in dt.Rows)
                ownerList += $"• {row["Name"]} ({row["Email"]}) - Avg Rating: {Convert.ToDouble(row["AvgRating"]):F1}\n";

            var result = MessageBox.Show(
                $"The following owners have low ratings:\n\n{ownerList}\nDelete all of them?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string deleteSql = "DELETE FROM Users WHERE UserId=@UserId";
                    DBConnection.ExecuteNonQuery(deleteSql,
                        new SqlParameter[] { new SqlParameter("@UserId", row["UserId"]) });
                }
                MessageBox.Show("Low-rated owners deleted successfully.", "Done",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAllData();
            }
        }

        private TabPage CreateRevenueTab()
        {
            var tab = new TabPage("💰  Revenue (10%)");
            tab.BackColor = Color.White;

            // ── toolbar ──────────────────────────────────────────────────────
            var toolbar = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.FromArgb(240, 255, 245),
                Padding = new Padding(5)
            };

            var btnRefresh = MakeButton("🔄 Refresh", Color.FromArgb(20, 150, 120));
            btnRefresh.Click += (s, e) => LoadRevenue();
            toolbar.Controls.Add(btnRefresh);

            // ── summary cards row ─────────────────────────────────────────────
            var panelSummary = new Panel
            {
                Dock = DockStyle.Top,
                Height = 110,
                BackColor = Color.FromArgb(248, 255, 251),
                Padding = new Padding(15, 10, 15, 10)
            };

            // Card: Total Rent Collected
            var cardTotalRent = CreateSummaryCard(
                "Total Rent Collected (৳)",
                "0",
                Color.FromArgb(30, 130, 76),
                out lblTotalRentValue);
            cardTotalRent.Location = new Point(15, 10);

            // Card: Admin 10% Share
            var cardAdminShare = CreateSummaryCard(
                "Admin Revenue @ 10% (৳)",
                "0",
                Color.FromArgb(22, 90, 170),
                out lblAdminShareValue);
            cardAdminShare.Location = new Point(230, 10);

            // Card: Total Payments Processed
            var cardPayments = CreateSummaryCard(
                "Total Payments Processed",
                "0",
                Color.FromArgb(180, 100, 10),
                out lblTotalPaymentsValue);
            cardPayments.Location = new Point(445, 10);

            panelSummary.Controls.Add(cardTotalRent);
            panelSummary.Controls.Add(cardAdminShare);
            panelSummary.Controls.Add(cardPayments);

            // ── note label ───────────────────────────────────────────────────
            var lblNote = new Label
            {
                Text = "ℹ  Admin earns 10% of each confirmed booking's rent. The table below shows per-booking breakdown.",
                Dock = DockStyle.Top,
                Height = 30,
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                ForeColor = Color.FromArgb(80, 80, 80),
                BackColor = Color.FromArgb(255, 253, 230),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(12, 0, 0, 0)
            };

            // ── data grid ────────────────────────────────────────────────────
            dgvRevenue = CreateDGV();
            dgvRevenue.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 130, 76);

            tab.Controls.Add(dgvRevenue);
            tab.Controls.Add(lblNote);
            tab.Controls.Add(panelSummary);
            tab.Controls.Add(toolbar);
            return tab;
        }

        /// <summary>Creates a small summary card and exposes its value label.</summary>
        private Panel CreateSummaryCard(string title, string initialValue, Color color, out Label valueLabel)
        {
            var card = new Panel
            {
                Size = new Size(200, 80),
                BackColor = Color.White
            };
            card.Paint += (s, e) =>
            {
                e.Graphics.FillRectangle(new SolidBrush(color), 0, 0, 8, 80);
            };

            var lTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 8.5f),
                ForeColor = Color.Gray,
                Location = new Point(16, 10),
                Size = new Size(178, 18)
            };

            var lValue = new Label
            {
                Text = initialValue,
                Font = new Font("Segoe UI", 17, FontStyle.Bold),
                ForeColor = color,
                Location = new Point(14, 30),
                Size = new Size(180, 36),
                AutoSize = false
            };

            card.Controls.Add(lTitle);
            card.Controls.Add(lValue);
            valueLabel = lValue;
            return card;
        }

        private void LoadRevenue()
        {
            // Per-booking breakdown with 10% admin share
            string sql = @"
                SELECT
                    b.BookingId                                         AS [Booking ID],
                    p.Title                                             AS [Property],
                    u.Name                                              AS [Customer],
                    CONVERT(VARCHAR(10), b.StartDate, 23)               AS [Start Date],
                    CONVERT(VARCHAR(10), b.EndDate,   23)               AS [End Date],
                    b.TotalPrice                                        AS [Total Rent (৳)],
                    CAST(b.TotalPrice * 0.10 AS DECIMAL(10,2))          AS [Admin 10% Share (৳)],
                    b.Status                                            AS [Booking Status],
                    CONVERT(VARCHAR(16), b.BookedAt, 120)               AS [Booked At]
                FROM Booking b
                JOIN Property p ON b.PropertyId = p.PropertyId
                JOIN Users    u ON b.CustomerId  = u.UserId
                WHERE b.Status = 'Confirmed'
                ORDER BY b.BookedAt DESC";

            var dt = DBConnection.ExecuteQuery(sql);
            dgvRevenue.DataSource = dt;

            // Colour the admin share column green
            if (dgvRevenue.Columns.Contains("Admin 10% Share (৳)"))
            {
                dgvRevenue.Columns["Admin 10% Share (৳)"].DefaultCellStyle.ForeColor =
                    Color.FromArgb(20, 130, 76);
                dgvRevenue.Columns["Admin 10% Share (৳)"].DefaultCellStyle.Font =
                    new Font("Segoe UI", 9.5f, FontStyle.Bold);
                dgvRevenue.Columns["Admin 10% Share (৳)"].DefaultCellStyle.BackColor =
                    Color.FromArgb(240, 255, 248);
            }

            // Update summary totals
            object totalRentObj = DBConnection.ExecuteScalar(
                "SELECT ISNULL(SUM(TotalPrice),0) FROM Booking WHERE Status='Confirmed'");
            decimal totalRent = totalRentObj != null ? Convert.ToDecimal(totalRentObj) : 0m;
            decimal adminShare = totalRent * 0.10m;

            object countObj = DBConnection.ExecuteScalar(
                "SELECT COUNT(*) FROM Booking WHERE Status='Confirmed'");
            int confirmedCount = countObj != null ? Convert.ToInt32(countObj) : 0;

            if (lblTotalRentValue  != null) lblTotalRentValue.Text  = totalRent.ToString("N0");
            if (lblAdminShareValue != null) lblAdminShareValue.Text  = adminShare.ToString("N0");
            if (lblTotalPaymentsValue != null) lblTotalPaymentsValue.Text = confirmedCount.ToString();
        }

        private void Logout()
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SessionManager.Clear();
                new LoginForm().Show();
                this.Close();
            }
        }
    }
}
