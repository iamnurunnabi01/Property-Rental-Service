using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using PropertyRentalServices.Database;

namespace PropertyRentalServices.Forms
{
    public partial class PaymentForm : Form
    {
        private DataTable cartTable;
        private decimal grandTotal;
        private int customerId;

        public PaymentForm(DataTable cart, decimal total, int custId)
        {
            cartTable = cart;
            grandTotal = total;
            customerId = custId;
            InitializeComponent();
            lblTotal.Text = "Grand Total:  ৳" + grandTotal.ToString("N2");
            if (cmbMethod.Items.Count > 0)
                cmbMethod.SelectedIndex = 0;
        }

        private void BtnCancel_Click(object sender, EventArgs e) { this.Close(); }



        private void AddLabel(string text, int x, int y, Control parent = null)
        {
            var lbl = new Label
            {
                Text = text, Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 60, 60), Location = new Point(x, y), AutoSize = true
            };
            (parent ?? this).Controls.Add(lbl);
        }

        private TextBox MakeTB(int x, int y, int w, string ph)
        {
            var tb = new TextBox
            {
                Location = new Point(x, y), Size = new Size(w, 30),
                Font = new Font("Segoe UI", 11), BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(tb);
            return tb;
        }

        private void BtnPay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCardName.Text) ||
                string.IsNullOrWhiteSpace(txtCardNumber.Text) ||
                string.IsNullOrWhiteSpace(txtExpiry.Text) ||
                string.IsNullOrWhiteSpace(txtCVV.Text))
            {
                MessageBox.Show("Please fill all payment details.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    var tran = conn.BeginTransaction();

                    try
                    {
                        foreach (DataRow item in cartTable.Rows)
                        {
                            int propId = Convert.ToInt32(item["PropertyId"]);
                            DateTime start = Convert.ToDateTime(item["StartDate"]);
                            DateTime end = Convert.ToDateTime(item["EndDate"]);
                            decimal total = Convert.ToDecimal(item["TotalPrice"]);

                            // Insert Booking
                            string bookSql = @"INSERT INTO Booking (PropertyId, CustomerId, StartDate, EndDate, TotalPrice, Status)
                                               OUTPUT INSERTED.BookingId
                                               VALUES (@PropId, @CustId, @Start, @End, @Total, 'Confirmed')";
                            var bookCmd = new SqlCommand(bookSql, conn, tran);
                            bookCmd.Parameters.AddRange(new SqlParameter[]
                            {
                                new SqlParameter("@PropId", propId),
                                new SqlParameter("@CustId", customerId),
                                new SqlParameter("@Start", start),
                                new SqlParameter("@End", end),
                                new SqlParameter("@Total", total)
                            });
                            int bookingId = Convert.ToInt32(bookCmd.ExecuteScalar());

                            // Insert Payment
                            string paySql = @"INSERT INTO Payment (BookingId, Amount, Method)
                                              VALUES (@BId, @Amt, @Method)";
                            var payCmd = new SqlCommand(paySql, conn, tran);
                            payCmd.Parameters.AddRange(new SqlParameter[]
                            {
                                new SqlParameter("@BId", bookingId),
                                new SqlParameter("@Amt", total),
                                new SqlParameter("@Method", cmbMethod.SelectedItem?.ToString())
                            });
                            payCmd.ExecuteNonQuery();

                            // Update property status
                            string updateSql = "UPDATE Property SET Status='Booked' WHERE PropertyId=@PId";
                            var updCmd = new SqlCommand(updateSql, conn, tran);
                            updCmd.Parameters.Add(new SqlParameter("@PId", propId));
                            updCmd.ExecuteNonQuery();
                        }

                        tran.Commit();

                        MessageBox.Show(
                            $"🎉 Payment Successful!\n\nAmount Paid: ৳{grandTotal:N2}\nMethod: {cmbMethod.SelectedItem}\n\nYour booking is confirmed!",
                            "Payment Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Payment failed: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LblCardName_Click(object sender, EventArgs e)
        {
            txtCardName.Focus();
            txtCardName.SelectAll();
        }

        private void LblCardNumber_Click(object sender, EventArgs e)
        {
            txtCardNumber.Focus();
            txtCardNumber.SelectAll();
        }

        private void LblCvv_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CVV is the 3-digit security code on the back of your card.\n(4 digits for Amex, printed on the front)",
                "CVV Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtCVV.Focus();
        }

        private void LblExpiry_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter expiry date in MM/YY format.\nExample: 09/27",
                "Expiry Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtExpiry.Focus();
        }

        private void LblHeaderTitle_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Secure Payment\n\nAll transactions are encrypted and processed securely.\nYour card details are not stored.",
                "Payment Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LblMethodLabel_Click(object sender, EventArgs e)
        {
            cmbMethod.Focus();
            cmbMethod.DroppedDown = true;
        }

        private void LblSummaryInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Booking summary shows all properties you are about to book.\nPlease review before completing payment.",
                "Summary Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LblTotal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Grand Total includes all selected properties.\nNo hidden charges apply.",
                "Total Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TxtCVV_Enter(object sender, EventArgs e)
        {
            txtCVV.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
        }

        private void TxtCVV_TextChanged(object sender, EventArgs e)
        {
            bool valid = System.Text.RegularExpressions.Regex.IsMatch(txtCVV.Text, @"^\d{3,4}$");
            txtCVV.BackColor = (txtCVV.Text.Length == 0 || valid)
                ? System.Drawing.Color.FromArgb(240, 248, 255)
                : System.Drawing.Color.FromArgb(255, 235, 235);
        }

        private void TxtCardName_Enter(object sender, EventArgs e)
        {
            txtCardName.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
        }

        private void TxtCardName_TextChanged(object sender, EventArgs e)
        {
            bool valid = txtCardName.Text.Trim().Length >= 3;
            txtCardName.BackColor = (txtCardName.Text.Length == 0 || valid)
                ? System.Drawing.Color.FromArgb(240, 248, 255)
                : System.Drawing.Color.FromArgb(255, 235, 235);
        }

        private void TxtCardNumber_Enter(object sender, EventArgs e)
        {
            txtCardNumber.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
        }

        private void TxtCardNumber_TextChanged(object sender, EventArgs e)
        {
            string digits = System.Text.RegularExpressions.Regex.Replace(txtCardNumber.Text, @"\D", "");
            bool valid = digits.Length == 16;
            txtCardNumber.BackColor = (txtCardNumber.Text.Length == 0 || valid)
                ? System.Drawing.Color.FromArgb(240, 248, 255)
                : System.Drawing.Color.FromArgb(255, 235, 235);
        }

        private void TxtExpiry_Enter(object sender, EventArgs e)
        {
            txtExpiry.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
        }

        private void TxtExpiry_TextChanged(object sender, EventArgs e)
        {
            bool valid = System.Text.RegularExpressions.Regex.IsMatch(txtExpiry.Text, @"^(0[1-9]|1[0-2])\/\d{2}$");
            txtExpiry.BackColor = (txtExpiry.Text.Length == 0 || valid)
                ? System.Drawing.Color.FromArgb(240, 248, 255)
                : System.Drawing.Color.FromArgb(255, 235, 235);
        }
        private void CmbMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            string method = cmbMethod.SelectedItem?.ToString();
            bool isCard = (method == "Credit Card" || method == "Debit Card");
            // Show/hide card fields based on selected payment method
            bool hasTxtFields = txtCardName != null;
            if (hasTxtFields)
            {
                txtCardName.Enabled    = isCard;
                txtCardNumber.Enabled  = isCard;
                txtExpiry.Enabled      = isCard;
                txtCVV.Enabled         = isCard;
                txtCardName.BackColor  = isCard ? System.Drawing.Color.White : System.Drawing.Color.FromArgb(240, 240, 240);
                txtCardNumber.BackColor = isCard ? System.Drawing.Color.White : System.Drawing.Color.FromArgb(240, 240, 240);
                txtExpiry.BackColor    = isCard ? System.Drawing.Color.White : System.Drawing.Color.FromArgb(240, 240, 240);
                txtCVV.BackColor       = isCard ? System.Drawing.Color.White : System.Drawing.Color.FromArgb(240, 240, 240);
            }
            if (!isCard && method != null)
                MessageBox.Show($"Selected: {method}\n\nNo card details required for this payment method. Click Pay to complete your booking.",
                    "Payment Method", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
