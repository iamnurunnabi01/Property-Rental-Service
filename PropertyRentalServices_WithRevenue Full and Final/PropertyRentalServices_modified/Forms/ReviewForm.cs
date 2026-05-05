using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using PropertyRentalServices.Database;

namespace PropertyRentalServices.Forms
{
    public class ReviewForm : Form
    {
        private int propertyId, userId;
        private string propertyTitle;
        private NumericUpDown numRating;
        private TextBox txtComment;
        private Button[] starButtons = new Button[5];
        private int selectedRating = 5;

        public ReviewForm(int propId, string propTitle, int uid)
        {
            propertyId = propId;
            propertyTitle = propTitle;
            userId = uid;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Write a Review";
            this.Size = new Size(460, 420);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.White;

            var header = new Panel { Dock = DockStyle.Top, Height = 65, BackColor = Color.FromArgb(255, 140, 0) };
            header.Controls.Add(new Label
            {
                Text = "⭐  Write a Review",
                ForeColor = Color.White, Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter
            });

            int y = 80, x = 30, w = 390;

            Controls.Add(new Label
            {
                Text = $"Property: {propertyTitle}",
                Location = new Point(x, y), AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 60, 60)
            });
            y += 35;

            Controls.Add(new Label
            {
                Text = "Your Rating:",
                Location = new Point(x, y), AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = Color.Gray
            });
            y += 25;

            // Star rating buttons
            var starPanel = new Panel { Location = new Point(x, y), Size = new Size(280, 45) };
            for (int i = 0; i < 5; i++)
            {
                int starIdx = i + 1;
                starButtons[i] = new Button
                {
                    Text = "★", Location = new Point(i * 52, 0), Size = new Size(48, 40),
                    Font = new Font("Segoe UI", 18), FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(255, 200, 0), ForeColor = Color.White,
                    Cursor = Cursors.Hand, Tag = starIdx
                };
                starButtons[i].FlatAppearance.BorderSize = 0;
                starButtons[i].Click += (s, e) =>
                {
                    selectedRating = (int)((Button)s).Tag;
                    UpdateStars();
                };
                starPanel.Controls.Add(starButtons[i]);
            }
            Controls.Add(starPanel);
            y += 55;

            Controls.Add(new Label
            {
                Text = "Your Comment:",
                Location = new Point(x, y), AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = Color.Gray
            });
            y += 22;

            txtComment = new TextBox
            {
                Location = new Point(x, y), Size = new Size(w, 100),
                Multiline = true, Font = new Font("Segoe UI", 10),
                BorderStyle = BorderStyle.FixedSingle,

            };
            Controls.Add(txtComment);
            y += 115;

            var btnSubmit = new Button
            {
                Text = "✅  Submit Review",
                Location = new Point(x, y), Size = new Size(w, 44),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                BackColor = Color.FromArgb(255, 140, 0), ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand
            };
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.Click += BtnSubmit_Click;
            Controls.Add(btnSubmit);

            Controls.Add(header);
            UpdateStars();
        }

        private void UpdateStars()
        {
            for (int i = 0; i < 5; i++)
            {
                starButtons[i].BackColor = i < selectedRating
                    ? Color.FromArgb(255, 190, 0)
                    : Color.FromArgb(220, 220, 220);
                starButtons[i].ForeColor = i < selectedRating ? Color.White : Color.Gray;
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtComment.Text))
            {
                MessageBox.Show("Please write a comment.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if already reviewed
            string checkSql = "SELECT COUNT(*) FROM Review WHERE PropertyId=@PId AND UserId=@UId";
            object count = DBConnection.ExecuteScalar(checkSql, new SqlParameter[]
            {
                new SqlParameter("@PId", propertyId),
                new SqlParameter("@UId", userId)
            });

            if (Convert.ToInt32(count) > 0)
            {
                MessageBox.Show("You have already reviewed this property.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sql = @"INSERT INTO Review (PropertyId, UserId, Rating, Comment)
                           VALUES (@PropId, @UserId, @Rating, @Comment)";

            int result = DBConnection.ExecuteNonQuery(sql, new SqlParameter[]
            {
                new SqlParameter("@PropId", propertyId),
                new SqlParameter("@UserId", userId),
                new SqlParameter("@Rating", selectedRating),
                new SqlParameter("@Comment", txtComment.Text.Trim())
            });

            if (result > 0)
            {
                MessageBox.Show("Review submitted! Thank you.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }

    public class ReviewViewForm : Form
    {
        private int propertyId;
        private string propertyTitle;

        public ReviewViewForm(int propId, string propTitle)
        {
            propertyId = propId;
            propertyTitle = propTitle;
            InitializeComponents();
            LoadReviews();
        }

        private DataGridView dgv;

        private void InitializeComponents()
        {
            this.Text = $"Reviews - {propertyTitle}";
            this.Size = new Size(700, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;

            var header = new Panel { Dock = DockStyle.Top, Height = 65, BackColor = Color.FromArgb(255, 140, 0) };
            header.Controls.Add(new Label
            {
                Text = $"⭐  Reviews for: {propertyTitle}",
                ForeColor = Color.White, Font = new Font("Segoe UI", 13, FontStyle.Bold),
                Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter
            });

            dgv = new DataGridView
            {
                Dock = DockStyle.Fill, ReadOnly = true, AllowUserToAddRows = false,
                AllowUserToDeleteRows = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White, BorderStyle = BorderStyle.None,
                GridColor = Color.FromArgb(230, 235, 245),
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersVisible = false, Font = new Font("Segoe UI", 9.5f)
            };
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 140, 0);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 38;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 252, 240);

            this.Controls.Add(dgv);
            this.Controls.Add(header);
        }

        private void LoadReviews()
        {
            string sql = @"SELECT u.Name AS Reviewer, r.Rating,
                           REPLICATE('★', r.Rating) + REPLICATE('☆', 5-r.Rating) AS Stars,
                           r.Comment, r.ReviewDate
                           FROM Review r JOIN Users u ON r.UserId=u.UserId
                           WHERE r.PropertyId=@Id ORDER BY r.ReviewDate DESC";
            dgv.DataSource = DBConnection.ExecuteQuery(sql,
                new SqlParameter[] { new SqlParameter("@Id", propertyId) });

            // Avg rating label
            object avg = DBConnection.ExecuteScalar(
                "SELECT AVG(CAST(Rating AS FLOAT)) FROM Review WHERE PropertyId=@Id",
                new SqlParameter[] { new SqlParameter("@Id", propertyId) });

            if (avg != null && avg != DBNull.Value)
            {
                var lbl = new Label
                {
                    Dock = DockStyle.Bottom, Height = 40,
                    Text = $"  Average Rating: {Convert.ToDouble(avg):F1} / 5.0   ({dgv.Rows.Count} reviews)",
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    ForeColor = Color.FromArgb(255, 140, 0),
                    BackColor = Color.FromArgb(255, 250, 240),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(10, 0, 0, 0)
                };
                this.Controls.Add(lbl);
            }
        }
    }
}
