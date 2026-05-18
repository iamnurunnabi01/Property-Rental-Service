using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using PropertyRentalServices.Database;
using PropertyRentalServices.Models;

namespace PropertyRentalServices.Forms
{
    public partial class AdminDashboard : Form
    {
        // Runtime-built summary card labels (created in constructor via CreateSummaryCard)
        private System.Windows.Forms.Label lblTotalRentValue;
        private System.Windows.Forms.Label lblAdminShareValue;
        private System.Windows.Forms.Label lblTotalPaymentsValue;

        public AdminDashboard()
        {
            InitializeComponent();

            // Build revenue summary cards and wire up the label fields
            var card1 = CreateSummaryCard("Total Rent Collected (৳)", "0", System.Drawing.Color.FromArgb(20, 130, 76), out lblTotalRentValue);
            var card2 = CreateSummaryCard("Admin 10% Share (৳)", "0", System.Drawing.Color.FromArgb(30, 60, 114), out lblAdminShareValue);
            var card3 = CreateSummaryCard("Confirmed Payments", "0", System.Drawing.Color.FromArgb(180, 80, 0), out lblTotalPaymentsValue);

            card1.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            card2.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);

            panelRevenueSummary.Controls.Add(card1);
            panelRevenueSummary.Controls.Add(card2);
            panelRevenueSummary.Controls.Add(card3);

            // Wire click events after labels are created by CreateSummaryCard
            lblTotalRentValue.Click    += new System.EventHandler(LblTotalRentValue_Click);
            lblAdminShareValue.Click   += new System.EventHandler(LblAdminShareValue_Click);
            lblTotalPaymentsValue.Click += new System.EventHandler(LblTotalPaymentsValue_Click);

            LoadUsers();
            LoadProperties();
            LoadBookings();
            LoadReviews();
            LoadRevenue();
            RefreshStats();
        }

        private void RefreshStats()
        {
            panelStats.Controls.Clear();
            panelStats.Controls.Add(CreateStatCard("Total Users",   GetCount("Users"),    System.Drawing.Color.FromArgb(30, 100, 200),  10));
            panelStats.Controls.Add(CreateStatCard("Properties",    GetCount("Property"), System.Drawing.Color.FromArgb(20, 150, 100), 205));
            panelStats.Controls.Add(CreateStatCard("Bookings",      GetCount("Booking"),  System.Drawing.Color.FromArgb(200, 120, 20), 400));
            panelStats.Controls.Add(CreateStatCard("Revenue (৳)",  GetTotalRevenue(),    System.Drawing.Color.FromArgb(120, 40, 160), 595));
        }

        private void BtnRefreshUsers_Click(object sender, EventArgs e) { LoadUsers(); }
        private void BtnRefreshProperties_Click(object sender, EventArgs e) { LoadProperties(); }
        private void BtnRefreshBookings_Click(object sender, EventArgs e) { LoadBookings(); }
        private void BtnRefreshReviews_Click(object sender, EventArgs e) { LoadReviews(); }
        private void BtnRefreshRevenue_Click(object sender, EventArgs e) { LoadRevenue(); }
        private void BtnRefreshActualRevenue_Click(object sender, EventArgs e) { LoadActualRevenue(); }
        private void BtnLogout_Click(object sender, EventArgs e) { Logout(); }
        private void AdminDashboard_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            // Do not call Application.Exit() here — logout shows LoginForm and this would kill it
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







        private void LoadAllData()
        {
            LoadUsers();
            LoadProperties();
            LoadBookings();
            LoadReviews();
            LoadRevenue();
            LoadActualRevenue();
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

        private Label lblActualTotalValue;
        private Label lblActualCountValue;

        private void LoadActualRevenue()
        {
            string sql = @"
                SELECT
                    b.BookingId                                             AS [Booking ID],
                    p.Title                                                 AS [Property],
                    u.Name                                                  AS [Customer],
                    CONVERT(VARCHAR(10), b.StartDate, 23)                   AS [Check-In],
                    CONVERT(VARCHAR(10), b.EndDate,   23)                   AS [Check-Out],
                    b.TotalPrice                                            AS [Total Rent (৳)],
                    CAST(b.TotalPrice * 0.10 AS DECIMAL(10,2))              AS [Admin Actual Revenue (৳)],
                    CONVERT(VARCHAR(16), b.BookedAt, 120)                   AS [Booked At]
                FROM Booking b
                JOIN Property p ON b.PropertyId = p.PropertyId
                JOIN Users    u ON b.CustomerId  = u.UserId
                WHERE b.Status = 'Confirmed'
                ORDER BY b.BookedAt DESC";

            var dt = DBConnection.ExecuteQuery(sql);
            dgvActualRevenue.DataSource = dt;

            // Highlight the admin revenue column
            if (dgvActualRevenue.Columns.Contains("Admin Actual Revenue (৳)"))
            {
                dgvActualRevenue.Columns["Admin Actual Revenue (৳)"].DefaultCellStyle.ForeColor = Color.FromArgb(30, 80, 180);
                dgvActualRevenue.Columns["Admin Actual Revenue (৳)"].DefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                dgvActualRevenue.Columns["Admin Actual Revenue (৳)"].DefaultCellStyle.BackColor = Color.FromArgb(235, 245, 255);
            }

            // Summary totals for the summary panel
            object totalObj = DBConnection.ExecuteScalar(
                "SELECT ISNULL(SUM(TotalPrice)*0.10,0) FROM Booking WHERE Status='Confirmed'");
            decimal actualTotal = totalObj != null ? Convert.ToDecimal(totalObj) : 0m;

            object countObj = DBConnection.ExecuteScalar(
                "SELECT COUNT(*) FROM Booking WHERE Status='Confirmed'");
            int bookingCount = countObj != null ? Convert.ToInt32(countObj) : 0;

            // Build or update summary cards
            panelActualRevSummary.Controls.Clear();
            panelActualRevSummary.Controls.Add(BuildActualRevCard(
                "Admin Actual Revenue (৳)", actualTotal.ToString("N0"),
                Color.FromArgb(30, 80, 180), 10));
            panelActualRevSummary.Controls.Add(BuildActualRevCard(
                "Confirmed Bookings", bookingCount.ToString(),
                Color.FromArgb(20, 130, 76), 210));
            panelActualRevSummary.Controls.Add(BuildActualRevCard(
                "Platform Share Rate", "10%",
                Color.FromArgb(150, 80, 0), 410));
        }

        private Panel BuildActualRevCard(string title, string value, Color color, int left)
        {
            var card = new Panel { Size = new Size(190, 72), Location = new Point(left, 8), BackColor = Color.White };
            card.Paint += (s, e) => e.Graphics.FillRectangle(new SolidBrush(color), 0, 0, 7, 72);
            card.Controls.Add(new Label { Text = title, Font = new Font("Segoe UI", 8.5f), ForeColor = Color.Gray, Location = new Point(14, 9), AutoSize = true });
            card.Controls.Add(new Label { Text = value, Font = new Font("Segoe UI", 16, FontStyle.Bold), ForeColor = color, Location = new Point(12, 28), AutoSize = true });
            return card;
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

        private void LblRevenueNote_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Revenue Summary:\n\n" +
                "\u2022 Total Revenue: Sum of all confirmed bookings\n" +
                "\u2022 Platform Fee (10%): Admin commission collected\n" +
                "\u2022 Owner Payouts (90%): Earnings distributed to property owners\n\n" +
                "Click Refresh to reload the latest figures.",
                "Revenue Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LblWelcome_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Welcome, {PropertyRentalServices.Models.SessionManager.UserName}!\n\n" +
                "You are logged in as Super Admin.\n" +
                "You have full access to manage users, properties, bookings, reviews, and revenue.",
                "Admin Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void LblTotalRentValue_Click(object sender, EventArgs e)
        {
            string val = lblTotalRentValue.Text;
            MessageBox.Show($"Total Revenue Collected: \u09F3{val}\n\nThis is the combined payment total for all confirmed bookings across the platform.",
                "Total Revenue", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LblAdminShareValue_Click(object sender, EventArgs e)
        {
            string val = lblAdminShareValue.Text;
            MessageBox.Show($"Admin Commission (10%): \u09F3{val}\n\nThis is the platform service fee deducted from each booking. It funds platform operations and support.",
                "Admin Share", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LblTotalPaymentsValue_Click(object sender, EventArgs e)
        {
            string val = lblTotalPaymentsValue.Text;
            MessageBox.Show($"Total Payments Processed: \u09F3{val}\n\nThis reflects the total number of payment transactions completed on the platform.",
                "Total Payments", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
