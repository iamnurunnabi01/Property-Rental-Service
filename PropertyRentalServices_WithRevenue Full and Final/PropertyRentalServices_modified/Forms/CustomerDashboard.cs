using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using PropertyRentalServices.Database;
using PropertyRentalServices.Models;

namespace PropertyRentalServices.Forms
{
    public partial class CustomerDashboard : Form
    {
        private DataTable cartTable;

        public CustomerDashboard()
        {
            InitializeComponent();
            InitializeCart();
            LoadLocationsToCombo();
            LoadProperties();
            LoadMyBookings();
            LoadMyReviews();
        }

        private void BtnSearch_Click(object sender, EventArgs e) { LoadProperties(); }

        private void BtnResetFilter_Click(object sender, EventArgs e)
        {
            txtSearch.Clear(); txtMinPrice.Clear(); txtMaxPrice.Clear();
            cmbLocation.SelectedIndex = 0; cmbBedrooms.SelectedIndex = 0; cmbStatus.SelectedIndex = 0;
            LoadProperties();
        }

        private void BtnRemoveCart_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count > 0)
            {
                cartTable.Rows.RemoveAt(dgvCart.SelectedRows[0].Index);
                UpdateCartView();
            }
            else System.Windows.Forms.MessageBox.Show("Select a cart item to remove.", "Info");
        }

        private void BtnClearCart_Click(object sender, EventArgs e) { cartTable.Clear(); UpdateCartView(); }
        private void BtnRefreshBookings_Click(object sender, EventArgs e) { LoadMyBookings(); }
        private void BtnRefreshReviews_Click(object sender, EventArgs e) { LoadMyReviews(); }
        private void BtnLogout_Click(object sender, EventArgs e) { Logout(); }
        private void CustomerDashboard_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            // Do not call Application.Exit() here — logout shows LoginForm and this would kill it
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
            cmbLocation.Items.Clear();
            cmbLocation.Items.Add("All");
            DataTable dt = DBConnection.ExecuteQuery("SELECT DISTINCT Location FROM Property ORDER BY Location");
            foreach (DataRow row in dt.Rows)
                cmbLocation.Items.Add(row["Location"].ToString());
            cmbLocation.SelectedIndex = 0;
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

            lblCartTotal.Text = $"  Cart Total: ৳{total:N2}   ({cartTable.Rows.Count} item(s))";
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
            cmbBedrooms.Focus();
            cmbBedrooms.DroppedDown = true;
        }

        private void LblCartTotal_Click(object sender, EventArgs e)
        {
            if (cartTable == null || cartTable.Rows.Count == 0)
            {
                MessageBox.Show("Your cart is currently empty.\nBrowse properties and add them to your cart.",
                    "Cart Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            decimal total = 0;
            foreach (System.Data.DataRow r in cartTable.Rows)
                total += Convert.ToDecimal(r["TotalPrice"]);
            MessageBox.Show($"Cart Summary:\n\n{cartTable.Rows.Count} property/properties selected\nGrand Total: \u09F3{total:N2}\n\nClick Checkout to confirm your booking.",
                "Cart Total", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LblHeaderTitle_Click(object sender, EventArgs e)
        {
            LoadProperties();
            LoadMyBookings();
            LoadMyReviews();
            MessageBox.Show("Dashboard refreshed successfully.", "Refreshed",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LblLocation_Click(object sender, EventArgs e)
        {
            cmbLocation.Focus();
            cmbLocation.DroppedDown = true;
        }

        private void LblMaxPrice_Click(object sender, EventArgs e)
        {
            txtMaxPrice.Focus();
            txtMaxPrice.SelectAll();
        }

        private void LblMinPrice_Click(object sender, EventArgs e)
        {
            txtMinPrice.Focus();
            txtMinPrice.SelectAll();
        }

        private void LblSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Focus();
            txtSearch.SelectAll();
        }

        private void LblStatus_Click(object sender, EventArgs e)
        {
            cmbStatus.Focus();
            cmbStatus.DroppedDown = true;
        }

        private void TxtMaxPrice_Enter(object sender, EventArgs e)
        {
            txtMaxPrice.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            if (txtMaxPrice.Text == "0") txtMaxPrice.Clear();
        }

        private void TxtMaxPrice_TextChanged(object sender, EventArgs e)
        {
            bool valid = txtMaxPrice.Text.Length == 0 || (decimal.TryParse(txtMaxPrice.Text, out decimal mx) && mx >= 0);
            txtMaxPrice.BackColor = valid
                ? System.Drawing.Color.FromArgb(240, 248, 255)
                : System.Drawing.Color.FromArgb(255, 235, 235);
        }

        private void TxtMinPrice_Enter(object sender, EventArgs e)
        {
            txtMinPrice.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            if (txtMinPrice.Text == "0") txtMinPrice.Clear();
        }

        private void TxtMinPrice_TextChanged(object sender, EventArgs e)
        {
            bool valid = txtMinPrice.Text.Length == 0 || (decimal.TryParse(txtMinPrice.Text, out decimal mn) && mn >= 0);
            txtMinPrice.BackColor = valid
                ? System.Drawing.Color.FromArgb(240, 248, 255)
                : System.Drawing.Color.FromArgb(255, 235, 235);
        }

        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            txtSearch.BackColor = txtSearch.Text.Length > 0
                ? System.Drawing.Color.FromArgb(240, 248, 255)
                : System.Drawing.Color.White;
            if (txtSearch.Text.Length == 0)
                LoadProperties();
        }
        private void CmbLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void CmbBedrooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void CmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProperties();
        }

    }
}
