using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using PropertyRentalServices.Database;
using PropertyRentalServices.Models;

namespace PropertyRentalServices.Forms
{
    public class OwnerDashboard : Form
    {
        private TabControl tabControl;
        private DataGridView dgvProperties, dgvBookings, dgvOffers;
        private TextBox txtTitle, txtLocation, txtPrice, txtBedrooms, txtDescription;
        private ComboBox cmbStatus;
        private Button btnAdd, btnUpdate, btnDelete, btnClear;
        private int selectedPropertyId = -1;

        public OwnerDashboard()
        {
            InitializeComponents();
            LoadData();
        }

        private void InitializeComponents()
        {
            this.Text = "Owner Dashboard - Property Rental Services";
            this.Size = new Size(1200, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 248, 245);
            this.MinimumSize = new Size(1000, 600);

            // Header
            var header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = Color.FromArgb(20, 150, 120)
            };

            var lblTitle = new Label
            {
                Text = $"🏠  Owner Dashboard  |  Welcome, {SessionManager.UserName}",
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
                BackColor = Color.FromArgb(200, 80, 50),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Click += (s, e) => Logout();

            header.Controls.Add(lblTitle);
            header.Controls.Add(btnLogout);

            // Stats
            var panelStats = new Panel
            {
                Dock = DockStyle.Top,
                Height = 90,
                BackColor = Color.FromArgb(245, 248, 245),
                Padding = new Padding(10, 5, 10, 5)
            };

            string propCount = DBConnection.ExecuteScalar(
                "SELECT COUNT(*) FROM Property WHERE OwnerId=@Id",
                new SqlParameter[] { new SqlParameter("@Id", SessionManager.UserId) })?.ToString() ?? "0";

            string bookingCount = DBConnection.ExecuteScalar(
                @"SELECT COUNT(*) FROM Booking b JOIN Property p ON b.PropertyId=p.PropertyId
                  WHERE p.OwnerId=@Id AND b.Status='Confirmed'",
                new SqlParameter[] { new SqlParameter("@Id", SessionManager.UserId) })?.ToString() ?? "0";

            object totalRentObj = DBConnection.ExecuteScalar(
                @"SELECT ISNULL(SUM(b.TotalPrice),0) FROM Booking b
                  JOIN Property p ON b.PropertyId=p.PropertyId
                  WHERE p.OwnerId=@Id AND b.Status='Confirmed'",
                new SqlParameter[] { new SqlParameter("@Id", SessionManager.UserId) });
            decimal totalRent   = totalRentObj != null ? Convert.ToDecimal(totalRentObj) : 0m;
            decimal ownerRevenue = totalRent * 0.90m;   // owner keeps 90% after 10% admin deduction

            panelStats.Controls.Add(CreateStat("My Properties",       propCount,                                Color.FromArgb(20, 150, 120),  10));
            panelStats.Controls.Add(CreateStat("Confirmed Bookings",   bookingCount,                            Color.FromArgb(30,  60, 114), 210));
            panelStats.Controls.Add(CreateStat("Total Revenue (৳)",    totalRent.ToString("N0"),                Color.FromArgb(200, 100,   0), 410));
            panelStats.Controls.Add(CreateStat("Revenue after 10% (৳)", ownerRevenue.ToString("N0"),           Color.FromArgb(20,  130,  76), 610));

            // Main Tab
            tabControl = new TabControl
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10)
            };

            tabControl.TabPages.Add(CreatePropertyManagementTab());
            tabControl.TabPages.Add(CreateEarningsTab());
            tabControl.TabPages.Add(CreateOffersTab());

            var panelMain = new Panel { Dock = DockStyle.Fill, Padding = new Padding(10) };
            panelMain.Controls.Add(tabControl);

            this.Controls.Add(panelMain);
            this.Controls.Add(panelStats);
            this.Controls.Add(header);

            this.FormClosed += (s, e) => { SessionManager.Clear(); Application.Exit(); };
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

        private TabPage CreatePropertyManagementTab()
        {
            var tab = new TabPage("🏡  Manage Properties");
            tab.BackColor = Color.White;

            // Split: Left=Form, Right=Grid
            var splitContainer = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Vertical,
                SplitterDistance = 320,
                BackColor = Color.White
            };

            // Left Form
            var formPanel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(15), BackColor = Color.White };

            int y = 10;
            formPanel.Controls.Add(MakeLabel("Property Title", 0, y)); y += 22;
            txtTitle = MakeTB(0, y, 280, "e.g. Cozy 2BHK Apartment"); y += 38;

            formPanel.Controls.Add(MakeLabel("Location", 0, y)); y += 22;
            txtLocation = MakeTB(0, y, 280, "e.g. Dhaka, Gulshan"); y += 38;

            formPanel.Controls.Add(MakeLabel("Price per Night (৳)", 0, y)); y += 22;
            txtPrice = MakeTB(0, y, 280, "e.g. 5000"); y += 38;

            formPanel.Controls.Add(MakeLabel("Bedrooms", 0, y)); y += 22;
            txtBedrooms = MakeTB(0, y, 280, "e.g. 2"); y += 38;

            formPanel.Controls.Add(MakeLabel("Status", 0, y)); y += 22;
            cmbStatus = new ComboBox
            {
                Location = new Point(0, y), Size = new Size(280, 30),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10), FlatStyle = FlatStyle.Flat
            };
            cmbStatus.Items.AddRange(new object[] { "Available", "Booked", "Unavailable" });
            cmbStatus.SelectedIndex = 0;
            y += 38;

            formPanel.Controls.Add(MakeLabel("Description", 0, y)); y += 22;
            txtDescription = new TextBox
            {
                Location = new Point(0, y), Size = new Size(280, 70),
                Multiline = true, Font = new Font("Segoe UI", 10),
                BorderStyle = BorderStyle.FixedSingle,

            };
            y += 80;

            // Buttons
            var btnPanel = new FlowLayoutPanel
            {
                Location = new Point(0, y), Size = new Size(290, 45),
                FlowDirection = FlowDirection.LeftToRight
            };

            btnAdd = MakeBtn("➕ Add", Color.FromArgb(20, 150, 120));
            btnAdd.Click += BtnAdd_Click;

            btnUpdate = MakeBtn("✏️ Update", Color.FromArgb(30, 100, 200));
            btnUpdate.Click += BtnUpdate_Click;

            btnDelete = MakeBtn("🗑 Delete", Color.FromArgb(200, 50, 50));
            btnDelete.Click += BtnDelete_Click;

            btnClear = MakeBtn("✖ Clear", Color.Gray);
            btnClear.Click += (s, e) => ClearForm();

            btnPanel.Controls.AddRange(new Control[] { btnAdd, btnUpdate, btnDelete, btnClear });

            formPanel.Controls.AddRange(new Control[]
            { txtTitle, txtLocation, txtPrice, txtBedrooms, cmbStatus, txtDescription, btnPanel });

            // Right Grid
            dgvProperties = CreateDGV();
            dgvProperties.SelectionChanged += DgvProperties_SelectionChanged;

            splitContainer.Panel1.Controls.Add(formPanel);
            splitContainer.Panel2.Controls.Add(dgvProperties);

            tab.Controls.Add(splitContainer);
            return tab;
        }

        private TabPage CreateEarningsTab()
        {
            var tab = new TabPage("💰  Earnings");
            tab.BackColor = Color.White;

            // ── toolbar ──────────────────────────────────────────────────────
            var toolbar = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.FromArgb(255, 250, 240),
                Padding = new Padding(5)
            };

            var btnRefresh = MakeBtn("🔄 Refresh", Color.FromArgb(200, 100, 0));
            btnRefresh.Click += (s, e) => LoadEarnings();
            toolbar.Controls.Add(btnRefresh);

            // ── summary panel ─────────────────────────────────────────────────
            var panelEarnSummary = new Panel
            {
                Dock = DockStyle.Top,
                Height = 100,
                BackColor = Color.FromArgb(255, 252, 245),
                Padding = new Padding(15, 8, 15, 8)
            };

            // card 1 — Total Revenue
            var cardTotal = BuildEarnCard(
                "Total Revenue (৳)",
                "0",
                Color.FromArgb(200, 100, 0),
                out lblEarnTotal);
            cardTotal.Location = new Point(15, 8);

            // card 2 — Admin Deduction
            var cardDeduct = BuildEarnCard(
                "Admin Deduction 10% (৳)",
                "0",
                Color.FromArgb(180, 50, 50),
                out lblEarnDeduct);
            cardDeduct.Location = new Point(230, 8);

            // card 3 — Your Revenue
            var cardNet = BuildEarnCard(
                "Your Revenue 90% (৳)",
                "0",
                Color.FromArgb(20, 130, 76),
                out lblEarnNet);
            cardNet.Location = new Point(445, 8);

            panelEarnSummary.Controls.Add(cardTotal);
            panelEarnSummary.Controls.Add(cardDeduct);
            panelEarnSummary.Controls.Add(cardNet);

            // ── note ─────────────────────────────────────────────────────────
            var lblNote = new Label
            {
                Text = "ℹ  Admin platform fee is 10% of each confirmed booking. Your net revenue = Total Rent − 10%.",
                Dock = DockStyle.Top,
                Height = 28,
                Font = new Font("Segoe UI", 8.5f, FontStyle.Italic),
                ForeColor = Color.FromArgb(90, 90, 90),
                BackColor = Color.FromArgb(255, 253, 230),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(12, 0, 0, 0)
            };

            dgvBookings = CreateDGV();

            tab.Controls.Add(dgvBookings);
            tab.Controls.Add(lblNote);
            tab.Controls.Add(panelEarnSummary);
            tab.Controls.Add(toolbar);
            return tab;
        }

        // labels for the earnings summary cards
        private Label lblEarnTotal, lblEarnDeduct, lblEarnNet;

        private Panel BuildEarnCard(string title, string initialValue, Color color, out Label valueLabel)
        {
            var card = new Panel { Size = new Size(200, 76), BackColor = Color.White };
            card.Paint += (s, e) => e.Graphics.FillRectangle(new SolidBrush(color), 0, 0, 7, 76);

            var lbl = new Label { Text = title, Font = new Font("Segoe UI", 8.5f), ForeColor = Color.Gray, Location = new Point(15, 9), Size = new Size(178, 16) };
            var val = new Label { Text = initialValue, Font = new Font("Segoe UI", 17, FontStyle.Bold), ForeColor = color, Location = new Point(13, 28), Size = new Size(180, 34), AutoSize = false };

            card.Controls.Add(lbl);
            card.Controls.Add(val);
            valueLabel = val;
            return card;
        }

        private TabPage CreateOffersTab()
        {
            var tab = new TabPage("🎁  My Offers");
            tab.BackColor = Color.White;

            dgvOffers = CreateDGV();

            var toolbar = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.FromArgb(250, 240, 255),
                Padding = new Padding(5)
            };

            var btnAddOffer = MakeBtn("➕ Add Offer", Color.FromArgb(150, 50, 200));
            btnAddOffer.Click += BtnAddOffer_Click;

            var btnDeleteOffer = MakeBtn("🗑 Delete Offer", Color.FromArgb(200, 50, 50));
            btnDeleteOffer.Click += BtnDeleteOffer_Click;

            var btnRefresh = MakeBtn("🔄 Refresh", Color.Gray);
            btnRefresh.Click += (s, e) => LoadOffers();

            toolbar.Controls.AddRange(new Control[] { btnAddOffer, btnDeleteOffer, btnRefresh });

            tab.Controls.Add(dgvOffers);
            tab.Controls.Add(toolbar);
            return tab;
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
                new SqlParameter("@Status", cmbStatus.SelectedItem.ToString()),
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

        private Label MakeLabel(string text, int x, int y) =>
            new Label { Text = text, Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60), Location = new Point(x, y), AutoSize = true };

        private TextBox MakeTB(int x, int y, int w, string ph) =>
            new TextBox { Location = new Point(x, y), Size = new Size(w, 30), Font = new Font("Segoe UI", 10), BorderStyle = BorderStyle.FixedSingle };

        private Button MakeBtn(string text, Color color)
        {
            var btn = new Button
            {
                Text = text, BackColor = color, ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Height = 34, AutoSize = true, Padding = new Padding(6, 0, 6, 0),
                Cursor = Cursors.Hand, Margin = new Padding(3)
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        private DataGridView CreateDGV()
        {
            var dgv = new DataGridView
            {
                Dock = DockStyle.Fill, ReadOnly = true, AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White, BorderStyle = BorderStyle.None,
                GridColor = Color.FromArgb(230, 235, 245),
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersVisible = false, Font = new Font("Segoe UI", 9.5f)
            };
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 150, 120);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 38;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 255, 250);
            return dgv;
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
    }
}
