using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using PropertyRentalServices.Database;

namespace PropertyRentalServices.Forms
{
    public class PaymentForm : Form
    {
        private DataTable cartTable;
        private decimal grandTotal;
        private int customerId;
        private TextBox txtCardName, txtCardNumber, txtExpiry, txtCVV;
        private ComboBox cmbMethod;
        private Label lblTotal;

        public PaymentForm(DataTable cart, decimal total, int custId)
        {
            cartTable = cart;
            grandTotal = total;
            customerId = custId;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Payment";
            this.Size = new Size(520, 620);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.White;

            // Header
            var header = new Panel { Dock = DockStyle.Top, Height = 70, BackColor = Color.FromArgb(20, 150, 80) };
            header.Controls.Add(new Label
            {
                Text = "💳  Secure Payment",
                ForeColor = Color.White, Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter
            });

            int y = 90, x = 40, w = 420;

            // Order Summary
            var summaryBox = new Panel
            {
                Location = new Point(x, y), Size = new Size(w, 90),
                BackColor = Color.FromArgb(240, 255, 245),
                BorderStyle = BorderStyle.FixedSingle
            };
            summaryBox.Controls.Add(new Label
            {
                Text = $"📋 Booking Summary\n{cartTable.Rows.Count} property/properties",
                Location = new Point(10, 8), AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.FromArgb(20, 100, 60)
            });
            lblTotal = new Label
            {
                Text = $"Grand Total:  ৳{grandTotal:N2}",
                Location = new Point(10, 50), AutoSize = true,
                Font = new Font("Segoe UI", 14, FontStyle.Bold), ForeColor = Color.FromArgb(20, 150, 80)
            };
            summaryBox.Controls.Add(lblTotal);
            this.Controls.Add(summaryBox);
            y += 110;

            // Payment Method
            AddLabel("Payment Method", x, y); y += 22;
            cmbMethod = new ComboBox
            {
                Location = new Point(x, y), Size = new Size(w, 30),
                DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 11), FlatStyle = FlatStyle.Flat
            };
            cmbMethod.Items.AddRange(new object[] { "Credit Card", "Debit Card", "Online Banking", "Mobile Banking (bKash)", "Cash on Arrival" });
            cmbMethod.SelectedIndex = 0;
            this.Controls.Add(cmbMethod);
            y += 45;

            AddLabel("Cardholder Name", x, y); y += 22;
            txtCardName = MakeTB(x, y, w, "Full name on card"); y += 45;

            AddLabel("Card Number", x, y); y += 22;
            txtCardNumber = MakeTB(x, y, w, "XXXX XXXX XXXX XXXX"); y += 45;

            var expCvvPanel = new Panel { Location = new Point(x, y), Size = new Size(w, 70) };
            AddLabel("Expiry (MM/YY)", 0, 0, expCvvPanel); 
            txtExpiry = new TextBox { Location = new Point(0, 22), Size = new Size(190, 30), Font = new Font("Segoe UI", 11), BorderStyle = BorderStyle.FixedSingle };
            AddLabel("CVV", 210, 0, expCvvPanel);
            txtCVV = new TextBox { Location = new Point(210, 22), Size = new Size(210, 30), Font = new Font("Segoe UI", 11), BorderStyle = BorderStyle.FixedSingle, PasswordChar = '●' };
            expCvvPanel.Controls.AddRange(new Control[] { txtExpiry, txtCVV });
            this.Controls.Add(expCvvPanel);
            y += 75;

            var btnPay = new Button
            {
                Text = $"✅  PAY  ৳{grandTotal:N2}",
                Location = new Point(x, y), Size = new Size(w, 50),
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                BackColor = Color.FromArgb(20, 150, 80), ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand
            };
            btnPay.FlatAppearance.BorderSize = 0;
            btnPay.Click += BtnPay_Click;
            this.Controls.Add(btnPay);

            var btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(x, y + 58), Size = new Size(w, 36),
                Font = new Font("Segoe UI", 10),
                BackColor = Color.White, ForeColor = Color.Gray,
                FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderColor = Color.LightGray;
            btnCancel.Click += (s, e) => this.Close();
            this.Controls.Add(btnCancel);

            this.Controls.Add(header);
        }

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
    }
}
