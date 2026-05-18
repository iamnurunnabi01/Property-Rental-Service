using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using PropertyRentalServices.Database;

namespace PropertyRentalServices.Forms
{
    public partial class ReviewForm : Form
    {
        private int propertyId, userId;
        private string propertyTitle;
        private int selectedRating = 5;

        public ReviewForm(int propId, string propTitle, int uid)
        {
            propertyId = propId;
            propertyTitle = propTitle;
            userId = uid;
            InitializeComponent();
            lblPropertyName.Text = "Property: " + propertyTitle;
            UpdateStars();
        }

        private void BtnStar_Click(object sender, EventArgs e)
        {
            selectedRating = (int)((System.Windows.Forms.Button)sender).Tag;
            UpdateStars();
        }



        private void UpdateStars()
        {
            var stars = new System.Windows.Forms.Button[] { btnStar1, btnStar2, btnStar3, btnStar4, btnStar5 };
            for (int i = 0; i < 5; i++)
            {
                stars[i].BackColor = i < selectedRating
                    ? System.Drawing.Color.FromArgb(255, 190, 0)
                    : System.Drawing.Color.FromArgb(220, 220, 220);
                stars[i].ForeColor = i < selectedRating ? System.Drawing.Color.White : System.Drawing.Color.Gray;
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

        private void LblPropertyName_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"You are writing a review for:\n{lblPropertyName.Text}\n\nRate the property using the stars and add your comment below.",
                "Property Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LblRatingPrompt_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Star Rating Guide:\n\n" +
                "\u2605 1 Star - Poor\n" +
                "\u2605\u2605 2 Stars - Fair\n" +
                "\u2605\u2605\u2605 3 Stars - Good\n" +
                "\u2605\u2605\u2605\u2605 4 Stars - Very Good\n" +
                "\u2605\u2605\u2605\u2605\u2605 5 Stars - Excellent\n\n" +
                "Click a star button to set your rating.",
                "Rating Guide", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LblCommentPrompt_Click(object sender, EventArgs e)
        {
            txtComment.Focus();
            if (txtComment.Text.Length == 0)
                MessageBox.Show("Share your experience: mention cleanliness, location, amenities, and value for money.",
                    "Comment Tip", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TxtComment_Enter(object sender, EventArgs e)
        {
            txtComment.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
        }

        private void TxtComment_TextChanged(object sender, EventArgs e)
        {
            int len = txtComment.Text.Trim().Length;
            txtComment.BackColor = len == 0
                ? System.Drawing.Color.FromArgb(240, 248, 255)
                : len < 10
                    ? System.Drawing.Color.FromArgb(255, 235, 235)
                    : System.Drawing.Color.FromArgb(235, 255, 235);
        }
    }

    public partial class ReviewViewForm : Form
    {
        private int propertyId;
        private string propertyTitle;

        public ReviewViewForm(int propId, string propTitle)
        {
            propertyId = propId;
            propertyTitle = propTitle;
            InitializeComponent();
            this.Text = $"Reviews - {propertyTitle}";
            lblHeaderTitle.Text = $"⭐  Reviews for: {propertyTitle}";
            LoadReviews();
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

        private void LblHeaderTitle_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Showing all reviews for:\n{this.Text.Replace("Reviews - ", "")}\n\nReviews are submitted by verified customers who completed a booking.",
                "Reviews Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
