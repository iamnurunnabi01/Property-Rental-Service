using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using PropertyRentalServices.Database;
using PropertyRentalServices.Models;

namespace PropertyRentalServices.Forms
{
    public partial class OwnerDashboard : Form
    {
        private int selectedPropertyId = -1;

        public OwnerDashboard()
        {
            InitializeComponent();
            cmbStatus.SelectedIndex = 0; // prevent null SelectedItem crash

            // Build earnings summary cards and wire up the label fields
            var card1 = BuildEarnCard("Total Revenue (৳)", "0", System.Drawing.Color.FromArgb(20, 130, 76), out lblEarnTotal);
            var card2 = BuildEarnCard("Admin Fee 10% (৳)", "0", System.Drawing.Color.FromArgb(180, 50, 50), out lblEarnDeduct);
            var card3 = BuildEarnCard("Your Net 90% (৳)", "0", System.Drawing.Color.FromArgb(30, 60, 114), out lblEarnNet);

            card1.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            card2.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);

            panelEarnSummary.Controls.Add(card1);
            panelEarnSummary.Controls.Add(card2);
            panelEarnSummary.Controls.Add(card3);



            LoadProperties();
            LoadEarnings();
            LoadOffers();
            RefreshStats();
        }

        private void RefreshStats()
        {
            panelStats.Controls.Clear();
            panelStats.Controls.Add(CreateStat("My Properties",      GetPropCount(),    System.Drawing.Color.FromArgb(30, 100, 200),  10));
            panelStats.Controls.Add(CreateStat("Confirmed Bookings",  GetBookingCount(), System.Drawing.Color.FromArgb(20, 150, 100), 205));
            panelStats.Controls.Add(CreateStat("Total Revenue (৳)",   GetTotalRent(),    System.Drawing.Color.FromArgb(200, 120, 20), 400));
            panelStats.Controls.Add(CreateStat("Revenue after 10% (৳)", GetOwnerRevenue(), System.Drawing.Color.FromArgb(60, 160, 80),  595));
        }

        private void BtnClear_Click(object sender, EventArgs e) { ClearForm(); }
        private void BtnLogout_Click(object sender, EventArgs e) { Logout(); }
        private void BtnRefreshEarnings_Click(object sender, EventArgs e) { LoadEarnings(); }
        private void BtnRefreshOffers_Click(object sender, EventArgs e) { LoadOffers(); }
        private void OwnerDashboard_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            // Do not call Application.Exit() here — logout shows LoginForm and this would kill it
        }



        private string GetPropCount()
        {
            object r = PropertyRentalServices.Database.DBConnection.ExecuteScalar(
                "SELECT COUNT(*) FROM Property WHERE OwnerId=@Id",
                new System.Data.SqlClient.SqlParameter[] { new System.Data.SqlClient.SqlParameter("@Id", SessionManager.UserId) });
            return r?.ToString() ?? "0";
        }

        private string GetBookingCount()
        {
            object r = PropertyRentalServices.Database.DBConnection.ExecuteScalar(
                @"SELECT COUNT(*) FROM Booking b JOIN Property p ON b.PropertyId=p.PropertyId
                  WHERE p.OwnerId=@Id AND b.Status='Confirmed'",
                new System.Data.SqlClient.SqlParameter[] { new System.Data.SqlClient.SqlParameter("@Id", SessionManager.UserId) });
            return r?.ToString() ?? "0";
        }

        private string GetTotalRent()
        {
            object r = PropertyRentalServices.Database.DBConnection.ExecuteScalar(
                @"SELECT ISNULL(SUM(b.TotalPrice),0) FROM Booking b
                  JOIN Property p ON b.PropertyId=p.PropertyId
                  WHERE p.OwnerId=@Id AND b.Status='Confirmed'",
                new System.Data.SqlClient.SqlParameter[] { new System.Data.SqlClient.SqlParameter("@Id", SessionManager.UserId) });
            return r != null ? Convert.ToDecimal(r).ToString("N0") : "0";
        }

        private string GetOwnerRevenue()
        {
            object r = PropertyRentalServices.Database.DBConnection.ExecuteScalar(
                @"SELECT ISNULL(SUM(b.TotalPrice),0) FROM Booking b
                  JOIN Property p ON b.PropertyId=p.PropertyId
                  WHERE p.OwnerId=@Id AND b.Status='Confirmed'",
                new System.Data.SqlClient.SqlParameter[] { new System.Data.SqlClient.SqlParameter("@Id", SessionManager.UserId) });
            decimal total = r != null ? Convert.ToDecimal(r) : 0m;
            return (total * 0.90m).ToString("N0");
        }


        private Panel CreateStat(string title, string value, Color color, int left)
        {
            var card = new Panel
            {
                Size = new Size(185, 72),
                Location = new Point(left, 8),
                BackColor = Color.White
            };
            card.Paint += (s, e) => e.Graphics.FillRectangle(new SolidBrush(color), 0, 0, 6, 72);

            card.Controls.Add(new Label { Text = title, Font = new Font("Segoe UI", 8.5f), ForeColor = Color.Gray, Location = new Point(14, 10), AutoSize = true });
            card.Controls.Add(new Label { Text = value, Font = new Font("Segoe UI", 16, FontStyle.Bold), ForeColor = color, Location = new Point(12, 28), AutoSize = true });
            return card;
        }



        // labels for the earnings summary cards

        private Panel BuildEarnCard(string title, string initialValue, Color color, out Label valueLabel)
        {
            var card = new Panel { Size = new Size(200, 76), BackColor = Color.White };
            card.Paint += (s, e) => e.Graphics.FillRectangle(new SolidBrush(color), 0, 0, 7, 76);

            var lbl = new Label { Text = title, Font = new Font("Segoe UI", 8.5f), ForeColor = Color.Gray, Location = new Point(15, 9), Size = new Size(178, 16) };
            var val = new Label { Text = initialValue, Font = new Font("Segoe UI", 17, FontStyle.Bold), ForeColor = color, Location = new Point(13, 28), Size = new Size(180, 34), AutoSize = false };

            card.Controls.Add(lbl);
            card.Controls.Add(val);
            // Allow double-click navigation in Visual Studio designer
            lbl.Click += (s, ev) => MessageBox.Show($"Earnings Card: {title}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            valueLabel = val;
            return card;
        }


        private void LoadData()
        {
            LoadProperties();
            LoadEarnings();
            LoadOffers();
        }

        private void LoadProperties()
        {
            string sql = @"SELECT PropertyId, Title, Location, Price, Bedrooms, Status, Description, CreatedAt
                           FROM Property WHERE OwnerId=@Id ORDER BY CreatedAt DESC";
            dgvProperties.DataSource = DBConnection.ExecuteQuery(sql,
                new SqlParameter[] { new SqlParameter("@Id", SessionManager.UserId) });
        }

        private void LoadEarnings()
        {
            string sql = @"
                SELECT
                    b.BookingId                                             AS [Booking ID],
                    p.Title                                                 AS [Property],
                    u.Name                                                  AS [Customer],
                    CONVERT(VARCHAR(10), b.StartDate, 23)                   AS [Start Date],
                    CONVERT(VARCHAR(10), b.EndDate,   23)                   AS [End Date],
                    b.TotalPrice                                            AS [Total Revenue (৳)],
                    CAST(b.TotalPrice * 0.10 AS DECIMAL(10,2))              AS [Admin 10% (৳)],
                    CAST(b.TotalPrice * 0.90 AS DECIMAL(10,2))              AS [Your Revenue 90% (৳)],
                    b.Status                                                AS [Status],
                    CONVERT(VARCHAR(16), b.BookedAt, 120)                   AS [Booked At]
                FROM Booking b
                JOIN Property p ON b.PropertyId = p.PropertyId
                JOIN Users    u ON b.CustomerId  = u.UserId
                WHERE p.OwnerId = @Id
                ORDER BY b.BookedAt DESC";

            dgvBookings.DataSource = DBConnection.ExecuteQuery(sql,
                new SqlParameter[] { new SqlParameter("@Id", SessionManager.UserId) });

            // Style the key columns
            if (dgvBookings.Columns.Contains("Admin 10% (৳)"))
            {
                dgvBookings.Columns["Admin 10% (৳)"].DefaultCellStyle.ForeColor    = Color.FromArgb(180, 50, 50);
                dgvBookings.Columns["Admin 10% (৳)"].DefaultCellStyle.Font         = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                dgvBookings.Columns["Admin 10% (৳)"].DefaultCellStyle.BackColor    = Color.FromArgb(255, 245, 245);
            }
            if (dgvBookings.Columns.Contains("Your Revenue 90% (৳)"))
            {
                dgvBookings.Columns["Your Revenue 90% (৳)"].DefaultCellStyle.ForeColor = Color.FromArgb(20, 130, 76);
                dgvBookings.Columns["Your Revenue 90% (৳)"].DefaultCellStyle.Font      = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                dgvBookings.Columns["Your Revenue 90% (৳)"].DefaultCellStyle.BackColor = Color.FromArgb(240, 255, 248);
            }

            // Update summary cards (confirmed bookings only)
            object totalObj = DBConnection.ExecuteScalar(
                @"SELECT ISNULL(SUM(b.TotalPrice),0) FROM Booking b
                  JOIN Property p ON b.PropertyId=p.PropertyId
                  WHERE p.OwnerId=@Id AND b.Status='Confirmed'",
                new SqlParameter[] { new SqlParameter("@Id", SessionManager.UserId) });

            decimal total  = totalObj != null ? Convert.ToDecimal(totalObj) : 0m;
            decimal deduct = total * 0.10m;
            decimal net    = total * 0.90m;

            if (lblEarnTotal  != null) lblEarnTotal.Text  = total.ToString("N0");
            if (lblEarnDeduct != null) lblEarnDeduct.Text = deduct.ToString("N0");
            if (lblEarnNet    != null) lblEarnNet.Text    = net.ToString("N0");
        }

        private void LoadOffers()
        {
            string sql = @"SELECT o.OfferId, p.Title AS Property, o.DiscountPercent,
                           o.StartDate, o.EndDate, o.Description
                           FROM Offer o JOIN Property p ON o.PropertyId=p.PropertyId
                           WHERE p.OwnerId=@Id ORDER BY o.StartDate DESC";
            dgvOffers.DataSource = DBConnection.ExecuteQuery(sql,
                new SqlParameter[] { new SqlParameter("@Id", SessionManager.UserId) });
        }

        private void DgvProperties_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProperties.SelectedRows.Count == 0) return;
            var row = dgvProperties.SelectedRows[0];
            selectedPropertyId = Convert.ToInt32(row.Cells["PropertyId"].Value);
            txtTitle.Text = row.Cells["Title"].Value?.ToString();
            txtLocation.Text = row.Cells["Location"].Value?.ToString();
            txtPrice.Text = row.Cells["Price"].Value?.ToString();
            txtBedrooms.Text = row.Cells["Bedrooms"].Value?.ToString();
            cmbStatus.SelectedItem = row.Cells["Status"].Value?.ToString();
            txtDescription.Text = row.Cells["Description"].Value?.ToString();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            string sql = @"INSERT INTO Property (OwnerId, Title, Location, Price, Bedrooms, Status, Description)
                           VALUES (@OwnerId, @Title, @Location, @Price, @Bedrooms, @Status, @Desc)";
            int result = DBConnection.ExecuteNonQuery(sql, GetParams());

            if (result > 0)
            {
                MessageBox.Show("Property added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadProperties();
                RefreshStats();
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedPropertyId <= 0)
            {
                MessageBox.Show("Please select a property to update.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!ValidateForm()) return;

            string sql = @"UPDATE Property SET Title=@Title, Location=@Location, Price=@Price,
                           Bedrooms=@Bedrooms, Status=@Status, Description=@Desc
                           WHERE PropertyId=@Id AND OwnerId=@OwnerId";

            var pars = GetParams();
            Array.Resize(ref pars, pars.Length + 1);
            pars[pars.Length - 1] = new SqlParameter("@Id", selectedPropertyId);

            int result = DBConnection.ExecuteNonQuery(sql, pars);
            if (result > 0)
            {
                MessageBox.Show("Property updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadProperties();
                RefreshStats();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (selectedPropertyId <= 0)
            {
                MessageBox.Show("Please select a property to delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Delete this property?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string sql = "DELETE FROM Property WHERE PropertyId=@Id AND OwnerId=@OwnerId";
                int result = DBConnection.ExecuteNonQuery(sql, new SqlParameter[]
                {
                    new SqlParameter("@Id", selectedPropertyId),
                    new SqlParameter("@OwnerId", SessionManager.UserId)
                });

                if (result > 0)
                {
                    MessageBox.Show("Property deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadProperties();
                }
            }
        }

        private void BtnAddOffer_Click(object sender, EventArgs e)
        {
            // Get owner's properties for dropdown
            string propSql = "SELECT PropertyId, Title FROM Property WHERE OwnerId=@Id";
            DataTable props = DBConnection.ExecuteQuery(propSql,
                new SqlParameter[] { new SqlParameter("@Id", SessionManager.UserId) });

            if (props.Rows.Count == 0)
            {
                MessageBox.Show("You have no properties to add offers for.", "Info");
                return;
            }

            var offerForm = new Form
            {
                Text = "Add Offer",
                Size = new Size(400, 380),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false
            };

            var cmbProp = new ComboBox { Location = new Point(20, 50), Size = new Size(340, 30), DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 10) };
            var propIdMap = new System.Collections.Generic.Dictionary<string, int>();
            foreach (DataRow row in props.Rows)
            {
                string title = row["Title"].ToString();
                int pid = Convert.ToInt32(row["PropertyId"]);
                cmbProp.Items.Add(title);
                if (!propIdMap.ContainsKey(title)) propIdMap[title] = pid;
            }
            cmbProp.SelectedIndex = 0;

            var txtDiscount = new TextBox { Location = new Point(20, 120), Size = new Size(340, 30), Font = new Font("Segoe UI", 10) };
            var dtpStart = new DateTimePicker { Location = new Point(20, 190), Size = new Size(160, 30), Format = DateTimePickerFormat.Short };
            var dtpEnd = new DateTimePicker { Location = new Point(200, 190), Size = new Size(160, 30), Format = DateTimePickerFormat.Short };
            var txtDesc = new TextBox { Location = new Point(20, 240), Size = new Size(340, 50), Multiline = true, Font = new Font("Segoe UI", 10) };

            var btnSave = new Button
            {
                Text = "Save Offer", Location = new Point(20, 305), Size = new Size(340, 38),
                BackColor = Color.FromArgb(150, 50, 200), ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10, FontStyle.Bold), Cursor = Cursors.Hand
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += (s2, e2) =>
            {
                if (!decimal.TryParse(txtDiscount.Text, out decimal discount) || discount <= 0 || discount > 100)
                {
                    MessageBox.Show("Enter valid discount (1-100).", "Error"); return;
                }
                string selectedTitle = cmbProp.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(selectedTitle) || !propIdMap.ContainsKey(selectedTitle)) { MessageBox.Show("Please select a property.", "Error"); return; }
                int propId = propIdMap[selectedTitle];

                string sql = "INSERT INTO Offer (PropertyId, DiscountPercent, StartDate, EndDate, Description) VALUES (@PropId, @Disc, @Start, @End, @Desc)";
                DBConnection.ExecuteNonQuery(sql, new SqlParameter[]
                {
                    new SqlParameter("@PropId", propId),
                    new SqlParameter("@Disc", discount),
                    new SqlParameter("@Start", dtpStart.Value.Date),
                    new SqlParameter("@End", dtpEnd.Value.Date),
                    new SqlParameter("@Desc", txtDesc.Text)
                });
                MessageBox.Show("Offer added!", "Success");
                offerForm.Close();
                LoadOffers();
            };

            offerForm.Controls.AddRange(new Control[]
            {
                new Label { Text = "Select Property:", Location = new Point(20, 25), AutoSize = true, Font = new Font("Segoe UI", 9, FontStyle.Bold) },
                cmbProp,
                new Label { Text = "Discount %:", Location = new Point(20, 97), AutoSize = true, Font = new Font("Segoe UI", 9, FontStyle.Bold) },
                txtDiscount,
                new Label { Text = "Start Date:", Location = new Point(20, 167), AutoSize = true, Font = new Font("Segoe UI", 9, FontStyle.Bold) },
                new Label { Text = "End Date:", Location = new Point(200, 167), AutoSize = true, Font = new Font("Segoe UI", 9, FontStyle.Bold) },
                dtpStart, dtpEnd,
                new Label { Text = "Description:", Location = new Point(20, 218), AutoSize = true, Font = new Font("Segoe UI", 9, FontStyle.Bold) },
                txtDesc, btnSave
            });

            offerForm.ShowDialog(this);
        }

        private void BtnDeleteOffer_Click(object sender, EventArgs e)
        {
            if (dgvOffers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an offer to delete.", "Info"); return;
            }

            int offerId = Convert.ToInt32(dgvOffers.SelectedRows[0].Cells["OfferId"].Value);
            if (MessageBox.Show("Delete this offer?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DBConnection.ExecuteNonQuery("DELETE FROM Offer WHERE OfferId=@Id",
                    new SqlParameter[] { new SqlParameter("@Id", offerId) });
                LoadOffers();
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtLocation.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) || string.IsNullOrWhiteSpace(txtBedrooms.Text))
            {
                MessageBox.Show("Please fill all required fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text, out _) || !int.TryParse(txtBedrooms.Text, out _))
            {
                MessageBox.Show("Price and Bedrooms must be valid numbers.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private SqlParameter[] GetParams()
        {
            return new SqlParameter[]
            {
                new SqlParameter("@OwnerId", SessionManager.UserId),
                new SqlParameter("@Title", txtTitle.Text.Trim()),
                new SqlParameter("@Location", txtLocation.Text.Trim()),
                new SqlParameter("@Price", decimal.Parse(txtPrice.Text)),
                new SqlParameter("@Bedrooms", int.Parse(txtBedrooms.Text)),
                new SqlParameter("@Status", cmbStatus.SelectedItem?.ToString() ?? "Available"),
                new SqlParameter("@Desc", txtDescription.Text.Trim())
            };
        }

        private void ClearForm()
        {
            selectedPropertyId = -1;
            txtTitle.Clear(); txtLocation.Clear(); txtPrice.Clear();
            txtBedrooms.Clear(); txtDescription.Clear();
            cmbStatus.SelectedIndex = 0;
        }





        private void Logout()
        {
            if (MessageBox.Show("Logout?", "Logout", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SessionManager.Clear();
                new LoginForm().Show();
                this.Close();
            }
        }

        private void LblBedrooms_Click(object sender, EventArgs e)
        {
            txtBedrooms.Focus();
            txtBedrooms.SelectAll();
        }

        private void LblDescription_Click(object sender, EventArgs e)
        {
            txtDescription.Focus();
            txtDescription.SelectAll();
        }

        private void LblEarningsNote_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Earnings Breakdown:\n\n" +
                "\u2022 Total Revenue: All confirmed booking payments\n" +
                "\u2022 Admin Fee (10%): Platform service charge\n" +
                "\u2022 Your Net (90%): Amount you receive after fees",
                "Earnings Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LblHeaderTitle_Click(object sender, EventArgs e)
        {
            LoadData();
            MessageBox.Show("Dashboard refreshed successfully.", "Refreshed",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LblLocation_Click(object sender, EventArgs e)
        {
            txtLocation.Focus();
            txtLocation.SelectAll();
        }

        private void LblPrice_Click(object sender, EventArgs e)
        {
            txtPrice.Focus();
            txtPrice.SelectAll();
        }

        private void LblStatus_Click(object sender, EventArgs e)
        {
            cmbStatus.Focus();
            cmbStatus.DroppedDown = true;
        }

        private void LblTitle_Click(object sender, EventArgs e)
        {
            txtTitle.Focus();
            txtTitle.SelectAll();
        }

        private void TxtBedrooms_Enter(object sender, EventArgs e)
        {
            txtBedrooms.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
        }

        private void TxtBedrooms_TextChanged(object sender, EventArgs e)
        {
            bool valid = int.TryParse(txtBedrooms.Text, out int val) && val > 0 && val <= 20;
            txtBedrooms.BackColor = (txtBedrooms.Text.Length == 0 || valid)
                ? System.Drawing.Color.FromArgb(240, 248, 255)
                : System.Drawing.Color.FromArgb(255, 235, 235);
        }

        private void TxtDescription_Enter(object sender, EventArgs e)
        {
            txtDescription.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
        }

        private void TxtDescription_TextChanged(object sender, EventArgs e)
        {
            int remaining = 500 - txtDescription.Text.Length;
            txtDescription.BackColor = remaining >= 0
                ? System.Drawing.Color.FromArgb(240, 248, 255)
                : System.Drawing.Color.FromArgb(255, 235, 235);
        }

        private void TxtLocation_Enter(object sender, EventArgs e)
        {
            txtLocation.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
        }

        private void TxtLocation_TextChanged(object sender, EventArgs e)
        {
            txtLocation.BackColor = txtLocation.Text.Trim().Length >= 3
                ? System.Drawing.Color.FromArgb(235, 255, 235)
                : System.Drawing.Color.FromArgb(240, 248, 255);
        }

        private void TxtPrice_Enter(object sender, EventArgs e)
        {
            txtPrice.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
        }

        private void TxtPrice_TextChanged(object sender, EventArgs e)
        {
            bool valid = decimal.TryParse(txtPrice.Text, out decimal val) && val > 0;
            txtPrice.BackColor = (txtPrice.Text.Length == 0 || valid)
                ? System.Drawing.Color.FromArgb(240, 248, 255)
                : System.Drawing.Color.FromArgb(255, 235, 235);
        }

        private void TxtTitle_Enter(object sender, EventArgs e)
        {
            txtTitle.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
        }

        private void TxtTitle_TextChanged(object sender, EventArgs e)
        {
            bool valid = txtTitle.Text.Trim().Length >= 3;
            txtTitle.BackColor = (txtTitle.Text.Length == 0 || valid)
                ? System.Drawing.Color.FromArgb(240, 248, 255)
                : System.Drawing.Color.FromArgb(255, 235, 235);
        }
        private void CmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Status changed — remind owner what each status means
            string selected = cmbStatus.SelectedItem?.ToString();
            if (selected == "Available")
                lblStatus.Text = "Status: Available (visible to customers for booking)";
            else if (selected == "Rented")
                lblStatus.Text = "Status: Rented (currently occupied — hidden from search)";
            else if (selected == "Maintenance")
                lblStatus.Text = "Status: Maintenance (temporarily unavailable)";
            else
                lblStatus.Text = "Status";
        }

        private void LblEarnTotal_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Total Revenue: \u09F3{lblEarnTotal.Text}\n\nThis is the combined confirmed booking income for all your properties.",
                "Total Revenue", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LblEarnDeduct_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Admin Fee (10%): \u09F3{lblEarnDeduct.Text}\n\nThis is the platform commission deducted from your total revenue.",
                "Admin Deduction", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LblEarnNet_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Your Net Earnings (90%): \u09F3{lblEarnNet.Text}\n\nThis is the amount you receive after the 10% admin fee is deducted.",
                "Net Earnings", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
