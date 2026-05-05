using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using PropertyRentalServices.Database;
using PropertyRentalServices.Models;

namespace PropertyRentalServices.Forms
{
    public class CustomerDashboard : Form
    {
        private TabControl tabControl;
        private DataGridView dgvProperties, dgvCart, dgvBookings, dgvReviews;
        private TextBox txtSearch;
        private ComboBox cmbLocation, cmbBedrooms, cmbStatus;
        private TextBox txtMinPrice, txtMaxPrice;
        private DataTable cartTable;

        public CustomerDashboard()
        {
            InitializeCart();
            InitializeComponents();
            LoadProperties();
            LoadMyBookings();
            LoadMyReviews();
        }

        private void InitializeCart()
        {
            cartTable = new DataTable();
            cartTable.Columns.Add("PropertyId", typeof(int));
            cartTable.Columns.Add("Title", typeof(string));
            cartTable.Columns.Add("Location", typeof(string));
            cartTable.Columns.Add("PricePerNight", typeof(decimal));
            cartTable.Columns.Add("StartDate", typeof(DateTime));
            cartTable.Columns.Add("EndDate", typeof(DateTime));
            cartTable.Columns.Add("Nights", typeof(int));
            cartTable.Columns.Add("TotalPrice", typeof(decimal));
        }

        private void InitializeComponents()
        {
            this.Text = "Customer Dashboard - Property Rental Services";
            this.Size = new Size(1200, 760);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 247, 252);
            this.MinimumSize = new Size(1000, 600);

            // Header
            var header = new Panel { Dock = DockStyle.Top, Height = 70, BackColor = Color.FromArgb(30, 100, 200) };
            var lblTitle = new Label
            {
                Text = $"🏠  Property Rental  |  Welcome, {SessionManager.UserName}",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0)
            };
            var btnLogout = new Button
            {
                Text = "Logout", Dock = DockStyle.Right, Width = 100,
                BackColor = Color.FromArgb(200, 50, 50), ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10, FontStyle.Bold), Cursor = Cursors.Hand
            };
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Click += (s, e) => Logout();
            header.Controls.Add(lblTitle);
            header.Controls.Add(btnLogout);

            tabControl = new TabControl { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 10) };
            tabControl.TabPages.Add(CreateBrowseTab());
            tabControl.TabPages.Add(CreateCartTab());
            tabControl.TabPages.Add(CreateMyBookingsTab());
            tabControl.TabPages.Add(CreateReviewsTab());

            var panelMain = new Panel { Dock = DockStyle.Fill, Padding = new Padding(8) };
            panelMain.Controls.Add(tabControl);
            this.Controls.Add(panelMain);
            this.Controls.Add(header);

            this.FormClosed += (s, e) => { SessionManager.Clear(); Application.Exit(); };
        }

        private TabPage CreateBrowseTab()
        {
            var tab = new TabPage("🔍  Browse Properties");
            tab.BackColor = Color.White;

            // Filter Panel
            var filterPanel = new Panel
            {
                Dock = DockStyle.Top, Height = 110,
                BackColor = Color.FromArgb(235, 242, 255),
                Padding = new Padding(10, 8, 10, 8)
            };

            int fx = 10, fy = 8;
            filterPanel.Controls.Add(MakeLabel("Search:", fx, fy));
            txtSearch = new TextBox { Location = new Point(fx, fy + 20), Size = new Size(160, 30), Font = new Font("Segoe UI", 10), BorderStyle = BorderStyle.FixedSingle };
            filterPanel.Controls.Add(txtSearch);

            fx += 175;
            filterPanel.Controls.Add(MakeLabel("Location:", fx, fy));
            cmbLocation = new ComboBox { Location = new Point(fx, fy + 20), Size = new Size(140, 30), DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 10), FlatStyle = FlatStyle.Flat };
            cmbLocation.Items.Add("All");
            LoadLocationsToCombo();
            cmbLocation.SelectedIndex = 0;
            filterPanel.Controls.Add(cmbLocation);

            fx += 155;
            filterPanel.Controls.Add(MakeLabel("Bedrooms:", fx, fy));
            cmbBedrooms = new ComboBox { Location = new Point(fx, fy + 20), Size = new Size(100, 30), DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 10), FlatStyle = FlatStyle.Flat };
            cmbBedrooms.Items.AddRange(new object[] { "Any", "1", "2", "3", "4", "5+" });
            cmbBedrooms.SelectedIndex = 0;
            filterPanel.Controls.Add(cmbBedrooms);

            fx += 115;
            filterPanel.Controls.Add(MakeLabel("Status:", fx, fy));
            cmbStatus = new ComboBox { Location = new Point(fx, fy + 20), Size = new Size(120, 30), DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 10), FlatStyle = FlatStyle.Flat };
            cmbStatus.Items.AddRange(new object[] { "All", "Available", "Booked", "Unavailable" });
            cmbStatus.SelectedIndex = 0;
            filterPanel.Controls.Add(cmbStatus);

            fx += 135;
            filterPanel.Controls.Add(MakeLabel("Min Price (৳):", fx, fy));
            txtMinPrice = new TextBox { Location = new Point(fx, fy + 20), Size = new Size(90, 30), Font = new Font("Segoe UI", 10), BorderStyle = BorderStyle.FixedSingle };
            filterPanel.Controls.Add(txtMinPrice);

            fx += 105;
            filterPanel.Controls.Add(MakeLabel("Max Price (৳):", fx, fy));
            txtMaxPrice = new TextBox { Location = new Point(fx, fy + 20), Size = new Size(90, 30), Font = new Font("Segoe UI", 10), BorderStyle = BorderStyle.FixedSingle };
            filterPanel.Controls.Add(txtMaxPrice);

            fx += 105;
            var btnSearch = new Button
            {
                Text = "🔍 Search", Location = new Point(fx, fy + 16), Size = new Size(100, 36),
                BackColor = Color.FromArgb(30, 100, 200), ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10, FontStyle.Bold), Cursor = Cursors.Hand
            };
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.Click += (s, e) => LoadProperties();
            filterPanel.Controls.Add(btnSearch);

            fx += 110;
            var btnReset = new Button
            {
                Text = "↺ Reset", Location = new Point(fx, fy + 16), Size = new Size(80, 36),
                BackColor = Color.Gray, ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10, FontStyle.Bold), Cursor = Cursors.Hand
            };
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.Click += (s, e) => { txtSearch.Clear(); txtMinPrice.Clear(); txtMaxPrice.Clear(); cmbLocation.SelectedIndex = 0; cmbBedrooms.SelectedIndex = 0; cmbStatus.SelectedIndex = 0; LoadProperties(); };
            filterPanel.Controls.Add(btnReset);

            // Action Buttons
            var actionPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top, Height = 50,
                BackColor = Color.FromArgb(245, 248, 255), Padding = new Padding(5)
            };

            var btnAddCart = MakeBtn("🛒 Add to Cart", Color.FromArgb(30, 100, 200));
            btnAddCart.Click += BtnAddToCart_Click;

            var btnViewReview = MakeBtn("⭐ View Reviews", Color.FromArgb(255, 140, 0));
            btnViewReview.Click += BtnViewReviews_Click;

            actionPanel.Controls.AddRange(new Control[] { btnAddCart, btnViewReview });

            dgvProperties = CreateDGV(Color.FromArgb(30, 100, 200));
            tab.Controls.Add(dgvProperties);
            tab.Controls.Add(actionPanel);
            tab.Controls.Add(filterPanel);
            return tab;
        }

        private TabPage CreateCartTab()
        {
            var tab = new TabPage("🛒  Booking Cart");
            tab.BackColor = Color.White;

            var toolbar = new FlowLayoutPanel
            {
                Dock = DockStyle.Top, Height = 50,
                BackColor = Color.FromArgb(240, 255, 245), Padding = new Padding(5)
            };

            var btnRemove = MakeBtn("❌ Remove Selected", Color.FromArgb(200, 50, 50));
            btnRemove.Click += (s, e) =>
            {
                if (dgvCart.SelectedRows.Count > 0)
                {
                    int idx = dgvCart.SelectedRows[0].Index;
                    cartTable.Rows.RemoveAt(idx);
                    UpdateCartView();
                }
                else MessageBox.Show("Select a cart item to remove.", "Info");
            };

            var btnCheckout = MakeBtn("✅ Confirm & Pay", Color.FromArgb(20, 150, 80));
            btnCheckout.Click += BtnCheckout_Click;

            var btnClearCart = MakeBtn("🗑 Clear Cart", Color.Gray);
            btnClearCart.Click += (s, e) => { cartTable.Rows.Clear(); UpdateCartView(); };

            toolbar.Controls.AddRange(new Control[] { btnRemove, btnCheckout, btnClearCart });

            dgvCart = CreateDGV(Color.FromArgb(20, 150, 80));

            var lblTotal = new Label
            {
                Dock = DockStyle.Bottom, Height = 40,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(20, 150, 80),
                TextAlign = ContentAlignment.MiddleRight,
                Padding = new Padding(0, 0, 20, 0),
                BackColor = Color.FromArgb(240, 255, 245)
            };
            lblTotal.Name = "lblCartTotal";

            tab.Controls.Add(dgvCart);
            tab.Controls.Add(lblTotal);
            tab.Controls.Add(toolbar);
            return tab;
        }

        private TabPage CreateMyBookingsTab()
        {
            var tab = new TabPage("📋  My Bookings");
            tab.BackColor = Color.White;

            var toolbar = new FlowLayoutPanel
            {
                Dock = DockStyle.Top, Height = 50,
                BackColor = Color.FromArgb(245, 250, 255), Padding = new Padding(5)
            };

            var btnRefresh = MakeBtn("🔄 Refresh", Color.FromArgb(30, 60, 114));
            btnRefresh.Click += (s, e) => LoadMyBookings();

            var btnAddReview = MakeBtn("⭐ Add Review", Color.FromArgb(255, 140, 0));
            btnAddReview.Click += BtnAddReview_Click;

            toolbar.Controls.AddRange(new Control[] { btnRefresh, btnAddReview });

            dgvBookings = CreateDGV(Color.FromArgb(30, 60, 114));
            tab.Controls.Add(dgvBookings);
            tab.Controls.Add(toolbar);
            return tab;
        }

        private TabPage CreateReviewsTab()
        {
            var tab = new TabPage("⭐  My Reviews");
            tab.BackColor = Color.White;

            var toolbar = new FlowLayoutPanel
            {
                Dock = DockStyle.Top, Height = 50,
                BackColor = Color.FromArgb(255, 250, 240), Padding = new Padding(5)
            };
            var btnRefresh = MakeBtn("🔄 Refresh", Color.FromArgb(255, 140, 0));
            btnRefresh.Click += (s, e) => LoadMyReviews();
            toolbar.Controls.Add(btnRefresh);

            dgvReviews = CreateDGV(Color.FromArgb(255, 140, 0));
            tab.Controls.Add(dgvReviews);
            tab.Controls.Add(toolbar);
            return tab;
        }

        private void LoadProperties()
        {
            string keyword = txtSearch.Text.Trim();
            string location = cmbLocation.SelectedItem?.ToString();
            string bedrooms = cmbBedrooms.SelectedItem?.ToString();
            string status = cmbStatus.SelectedItem?.ToString();
            decimal minPrice = decimal.TryParse(txtMinPrice.Text, out decimal mn) ? mn : 0;
            decimal maxPrice = decimal.TryParse(txtMaxPrice.Text, out decimal mx) ? mx : 999999;

            string sql = @"SELECT p.PropertyId, p.Title, p.Location, p.Price AS [Price/Night], p.Bedrooms,
                           p.Status, ISNULL(AVG(CAST(r.Rating AS FLOAT)),0) AS [Avg Rating],
                           COUNT(r.ReviewId) AS Reviews,
                           ISNULL((SELECT TOP 1 CAST(o.DiscountPercent AS VARCHAR)+'%'
                                   FROM Offer o WHERE o.PropertyId=p.PropertyId
                                   AND GETDATE() BETWEEN o.StartDate AND o.EndDate), 'No Offer') AS [Active Offer]
                           FROM Property p
                           LEFT JOIN Review r ON p.PropertyId=r.PropertyId
                           WHERE p.Price BETWEEN @Min AND @Max
                           AND (@Keyword='' OR p.Title LIKE @KW OR p.Location LIKE @KW)
                           AND (@Location='All' OR p.Location LIKE @LocationFilter)
                           AND (@Status='All' OR p.Status=@Status)
                           AND (@Bedrooms='Any' OR (@Bedrooms='5+' AND p.Bedrooms>=5) OR p.Bedrooms=@BedroomsVal)
                           GROUP BY p.PropertyId, p.Title, p.Location, p.Price, p.Bedrooms, p.Status
                           ORDER BY p.Price ASC";

            var pars = new SqlParameter[]
            {
                new SqlParameter("@Min", minPrice),
                new SqlParameter("@Max", maxPrice),
                new SqlParameter("@Keyword", keyword),
                new SqlParameter("@KW", "%" + keyword + "%"),
                new SqlParameter("@Location", string.IsNullOrEmpty(location) ? "All" : location),
                new SqlParameter("@LocationFilter", "%" + (location == "All" ? "" : location) + "%"),
                new SqlParameter("@Status", string.IsNullOrEmpty(status) ? "All" : status),
                new SqlParameter("@Bedrooms", bedrooms ?? "Any"),
                new SqlParameter("@BedroomsVal", int.TryParse(bedrooms, out int bv) ? bv : 0)
            };

            dgvProperties.DataSource = DBConnection.ExecuteQuery(sql, pars);
        }

        private void LoadLocationsToCombo()
        {
            DataTable dt = DBConnection.ExecuteQuery("SELECT DISTINCT Location FROM Property ORDER BY Location");
            foreach (DataRow row in dt.Rows)
                cmbLocation.Items.Add(row["Location"].ToString());
        }

        private void BtnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvProperties.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a property to add to cart.", "Info");
                return;
            }

            var row = dgvProperties.SelectedRows[0];
            string statusVal = row.Cells["Status"].Value?.ToString();
            if (statusVal != "Available")
            {
                MessageBox.Show("This property is not available for booking.", "Info");
                return;
            }

            int propId = Convert.ToInt32(row.Cells["PropertyId"].Value);

            // Check if already in cart
            foreach (DataRow cr in cartTable.Rows)
            {
                if (Convert.ToInt32(cr["PropertyId"]) == propId)
                {
                    MessageBox.Show("This property is already in your cart.", "Info");
                    return;
                }
            }

            // Date picker dialog
            var dateForm = new Form
            {
                Text = "Select Booking Dates",
                Size = new Size(380, 260),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                BackColor = Color.White
            };

            var dtpStart = new DateTimePicker { Location = new Point(20, 60), Size = new Size(320, 30), Format = DateTimePickerFormat.Short, MinDate = DateTime.Today };
            var dtpEnd = new DateTimePicker { Location = new Point(20, 130), Size = new Size(320, 30), Format = DateTimePickerFormat.Short, MinDate = DateTime.Today.AddDays(1), Value = DateTime.Today.AddDays(1) };

            var btnConfirm = new Button
            {
                Text = "Add to Cart", Location = new Point(20, 180), Size = new Size(320, 40),
                BackColor = Color.FromArgb(30, 100, 200), ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 11, FontStyle.Bold), Cursor = Cursors.Hand
            };
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.Click += (s2, e2) =>
            {
                if (dtpEnd.Value.Date <= dtpStart.Value.Date)
                {
                    MessageBox.Show("End date must be after start date.", "Validation"); return;
                }
                int nights = (dtpEnd.Value.Date - dtpStart.Value.Date).Days;
                decimal pricePerNight = Convert.ToDecimal(row.Cells["Price/Night"].Value);

                // Check active offer
                string offerSql = @"SELECT TOP 1 DiscountPercent FROM Offer
                                    WHERE PropertyId=@Id AND GETDATE() BETWEEN StartDate AND EndDate";
                object discObj = DBConnection.ExecuteScalar(offerSql,
                    new SqlParameter[] { new SqlParameter("@Id", propId) });
                decimal discount = discObj != null ? Convert.ToDecimal(discObj) : 0;
                decimal total = pricePerNight * nights * (1 - discount / 100);

                cartTable.Rows.Add(propId, row.Cells["Title"].Value?.ToString(),
                    row.Cells["Location"].Value?.ToString(), pricePerNight,
                    dtpStart.Value.Date, dtpEnd.Value.Date, nights, Math.Round(total, 2));

                UpdateCartView();
                dateForm.Close();

                if (discount > 0)
                    MessageBox.Show($"Added! {discount}% discount applied!\nTotal: ৳{total:N2}", "Cart Updated ✅");
                else
                    MessageBox.Show($"Added to cart!\nTotal: ৳{total:N2}", "Cart Updated ✅");
            };

            dateForm.Controls.AddRange(new Control[]
            {
                new Label { Text = "Check-in Date:", Location = new Point(20, 35), AutoSize = true, Font = new Font("Segoe UI", 9, FontStyle.Bold) },
                dtpStart,
                new Label { Text = "Check-out Date:", Location = new Point(20, 105), AutoSize = true, Font = new Font("Segoe UI", 9, FontStyle.Bold) },
                dtpEnd, btnConfirm
            });
            dateForm.ShowDialog(this);
        }

        private void UpdateCartView()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = cartTable;

            decimal total = 0;
            foreach (DataRow r in cartTable.Rows)
                total += Convert.ToDecimal(r["TotalPrice"]);

            var lblTotal = tabControl.TabPages[1].Controls["lblCartTotal"] as Label;
            if (lblTotal != null)
                lblTotal.Text = $"  Cart Total: ৳{total:N2}   ({cartTable.Rows.Count} item(s))";
        }

        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            if (cartTable.Rows.Count == 0)
            {
                MessageBox.Show("Your cart is empty.", "Info"); return;
            }

            decimal grandTotal = 0;
            foreach (DataRow r in cartTable.Rows)
                grandTotal += Convert.ToDecimal(r["TotalPrice"]);

            var result = MessageBox.Show(
                $"Confirm booking for {cartTable.Rows.Count} property/properties?\nGrand Total: ৳{grandTotal:N2}",
                "Confirm Booking", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            // Show payment form
            new PaymentForm(cartTable, grandTotal, SessionManager.UserId).ShowDialog(this);
            cartTable.Clear();
            UpdateCartView();
            LoadMyBookings();
        }

        private void BtnViewReviews_Click(object sender, EventArgs e)
        {
            if (dgvProperties.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a property to view reviews.", "Info"); return;
            }
            int propId = Convert.ToInt32(dgvProperties.SelectedRows[0].Cells["PropertyId"].Value);
            string propTitle = dgvProperties.SelectedRows[0].Cells["Title"].Value?.ToString();
            new ReviewViewForm(propId, propTitle).ShowDialog(this);
        }

        private void BtnAddReview_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a confirmed booking to review.", "Info"); return;
            }

            string status = dgvBookings.SelectedRows[0].Cells["Status"].Value?.ToString();
            if (status != "Confirmed")
            {
                MessageBox.Show("You can only review confirmed bookings.", "Info"); return;
            }

            int propId = Convert.ToInt32(dgvBookings.SelectedRows[0].Cells["PropertyId"].Value);
            string propTitle = dgvBookings.SelectedRows[0].Cells["Property"].Value?.ToString();
            new ReviewForm(propId, propTitle, SessionManager.UserId).ShowDialog(this);
            LoadMyReviews();
        }

        private void LoadMyBookings()
        {
            string sql = @"SELECT b.BookingId, b.PropertyId, p.Title AS Property, p.Location,
                           b.StartDate, b.EndDate, b.TotalPrice, b.Status, b.BookedAt
                           FROM Booking b
                           JOIN Property p ON b.PropertyId=p.PropertyId
                           WHERE b.CustomerId=@Id ORDER BY b.BookedAt DESC";
            dgvBookings.DataSource = DBConnection.ExecuteQuery(sql,
                new SqlParameter[] { new SqlParameter("@Id", SessionManager.UserId) });
        }

        private void LoadMyReviews()
        {
            string sql = @"SELECT r.ReviewId, p.Title AS Property, r.Rating, r.Comment, r.ReviewDate
                           FROM Review r JOIN Property p ON r.PropertyId=p.PropertyId
                           WHERE r.UserId=@Id ORDER BY r.ReviewDate DESC";
            dgvReviews.DataSource = DBConnection.ExecuteQuery(sql,
                new SqlParameter[] { new SqlParameter("@Id", SessionManager.UserId) });
        }

        private Label MakeLabel(string text, int x, int y) =>
            new Label { Text = text, Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60), Location = new Point(x, y), AutoSize = true };

        private Button MakeBtn(string text, Color color)
        {
            var btn = new Button
            {
                Text = text, BackColor = color, ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Height = 36, AutoSize = true, Padding = new Padding(8, 0, 8, 0),
                Cursor = Cursors.Hand, Margin = new Padding(4)
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        private DataGridView CreateDGV(Color headerColor)
        {
            var dgv = new DataGridView
            {
                Dock = DockStyle.Fill, ReadOnly = true, AllowUserToAddRows = false,
                AllowUserToDeleteRows = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White, BorderStyle = BorderStyle.None,
                GridColor = Color.FromArgb(230, 235, 245),
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersVisible = false, Font = new Font("Segoe UI", 9.5f)
            };
            dgv.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 38;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 255);
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
