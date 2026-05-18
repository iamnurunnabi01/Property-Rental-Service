namespace PropertyRentalServices.Forms
{
    // ─────────────────────────────────────────────────────────────────────────
    // ReviewForm  –  write a new review (star rating + comment)
    // ─────────────────────────────────────────────────────────────────────────
    partial class ReviewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblPropertyName = new System.Windows.Forms.Label();
            this.lblRatingPrompt = new System.Windows.Forms.Label();
            this.panelStars = new System.Windows.Forms.Panel();
            this.btnStar1 = new System.Windows.Forms.Button();
            this.btnStar2 = new System.Windows.Forms.Button();
            this.btnStar3 = new System.Windows.Forms.Button();
            this.btnStar4 = new System.Windows.Forms.Button();
            this.btnStar5 = new System.Windows.Forms.Button();
            this.lblCommentPrompt = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelStars.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.panelHeader.Controls.Add(this.lblHeaderTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(613, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(0, 0);
            this.lblHeaderTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(613, 80);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "⭐  Write a Review";
            this.lblHeaderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHeaderTitle.Click += new System.EventHandler(this.lblHeaderTitle_Click);
            // 
            // lblPropertyName
            // 
            this.lblPropertyName.AutoSize = true;
            this.lblPropertyName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPropertyName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblPropertyName.Location = new System.Drawing.Point(40, 98);
            this.lblPropertyName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPropertyName.Name = "lblPropertyName";
            this.lblPropertyName.Size = new System.Drawing.Size(85, 23);
            this.lblPropertyName.TabIndex = 1;
            this.lblPropertyName.Text = "Property:";
            this.lblPropertyName.Click += new System.EventHandler(this.LblPropertyName_Click);
            // 
            // lblRatingPrompt
            // 
            this.lblRatingPrompt.AutoSize = true;
            this.lblRatingPrompt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRatingPrompt.ForeColor = System.Drawing.Color.Gray;
            this.lblRatingPrompt.Location = new System.Drawing.Point(40, 142);
            this.lblRatingPrompt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRatingPrompt.Name = "lblRatingPrompt";
            this.lblRatingPrompt.Size = new System.Drawing.Size(95, 20);
            this.lblRatingPrompt.TabIndex = 2;
            this.lblRatingPrompt.Text = "Your Rating:";
            this.lblRatingPrompt.Click += new System.EventHandler(this.LblRatingPrompt_Click);
            // 
            // panelStars
            // 
            this.panelStars.Controls.Add(this.btnStar1);
            this.panelStars.Controls.Add(this.btnStar2);
            this.panelStars.Controls.Add(this.btnStar3);
            this.panelStars.Controls.Add(this.btnStar4);
            this.panelStars.Controls.Add(this.btnStar5);
            this.panelStars.Location = new System.Drawing.Point(40, 172);
            this.panelStars.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelStars.Name = "panelStars";
            this.panelStars.Size = new System.Drawing.Size(373, 55);
            this.panelStars.TabIndex = 3;
            // 
            // btnStar1
            // 
            this.btnStar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(0)))));
            this.btnStar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStar1.FlatAppearance.BorderSize = 0;
            this.btnStar1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStar1.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.btnStar1.ForeColor = System.Drawing.Color.White;
            this.btnStar1.Location = new System.Drawing.Point(0, 0);
            this.btnStar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStar1.Name = "btnStar1";
            this.btnStar1.Size = new System.Drawing.Size(64, 49);
            this.btnStar1.TabIndex = 0;
            this.btnStar1.Tag = 1;
            this.btnStar1.Text = "★";
            this.btnStar1.UseVisualStyleBackColor = false;
            this.btnStar1.Click += new System.EventHandler(this.BtnStar_Click);
            // 
            // btnStar2
            // 
            this.btnStar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(0)))));
            this.btnStar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStar2.FlatAppearance.BorderSize = 0;
            this.btnStar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStar2.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.btnStar2.ForeColor = System.Drawing.Color.White;
            this.btnStar2.Location = new System.Drawing.Point(69, 0);
            this.btnStar2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStar2.Name = "btnStar2";
            this.btnStar2.Size = new System.Drawing.Size(64, 49);
            this.btnStar2.TabIndex = 1;
            this.btnStar2.Tag = 2;
            this.btnStar2.Text = "★";
            this.btnStar2.UseVisualStyleBackColor = false;
            this.btnStar2.Click += new System.EventHandler(this.BtnStar_Click);
            // 
            // btnStar3
            // 
            this.btnStar3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(0)))));
            this.btnStar3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStar3.FlatAppearance.BorderSize = 0;
            this.btnStar3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStar3.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.btnStar3.ForeColor = System.Drawing.Color.White;
            this.btnStar3.Location = new System.Drawing.Point(139, 0);
            this.btnStar3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStar3.Name = "btnStar3";
            this.btnStar3.Size = new System.Drawing.Size(64, 49);
            this.btnStar3.TabIndex = 2;
            this.btnStar3.Tag = 3;
            this.btnStar3.Text = "★";
            this.btnStar3.UseVisualStyleBackColor = false;
            this.btnStar3.Click += new System.EventHandler(this.BtnStar_Click);
            // 
            // btnStar4
            // 
            this.btnStar4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(0)))));
            this.btnStar4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStar4.FlatAppearance.BorderSize = 0;
            this.btnStar4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStar4.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.btnStar4.ForeColor = System.Drawing.Color.White;
            this.btnStar4.Location = new System.Drawing.Point(208, 0);
            this.btnStar4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStar4.Name = "btnStar4";
            this.btnStar4.Size = new System.Drawing.Size(64, 49);
            this.btnStar4.TabIndex = 3;
            this.btnStar4.Tag = 4;
            this.btnStar4.Text = "★";
            this.btnStar4.UseVisualStyleBackColor = false;
            this.btnStar4.Click += new System.EventHandler(this.BtnStar_Click);
            // 
            // btnStar5
            // 
            this.btnStar5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(0)))));
            this.btnStar5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStar5.FlatAppearance.BorderSize = 0;
            this.btnStar5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStar5.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.btnStar5.ForeColor = System.Drawing.Color.White;
            this.btnStar5.Location = new System.Drawing.Point(277, 0);
            this.btnStar5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStar5.Name = "btnStar5";
            this.btnStar5.Size = new System.Drawing.Size(64, 49);
            this.btnStar5.TabIndex = 4;
            this.btnStar5.Tag = 5;
            this.btnStar5.Text = "★";
            this.btnStar5.UseVisualStyleBackColor = false;
            this.btnStar5.Click += new System.EventHandler(this.BtnStar_Click);
            // 
            // lblCommentPrompt
            // 
            this.lblCommentPrompt.AutoSize = true;
            this.lblCommentPrompt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCommentPrompt.ForeColor = System.Drawing.Color.Gray;
            this.lblCommentPrompt.Location = new System.Drawing.Point(40, 242);
            this.lblCommentPrompt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCommentPrompt.Name = "lblCommentPrompt";
            this.lblCommentPrompt.Size = new System.Drawing.Size(118, 20);
            this.lblCommentPrompt.TabIndex = 4;
            this.lblCommentPrompt.Text = "Your Comment:";
            this.lblCommentPrompt.Click += new System.EventHandler(this.LblCommentPrompt_Click);
            // 
            // txtComment
            // 
            this.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComment.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtComment.Location = new System.Drawing.Point(40, 270);
            this.txtComment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(519, 123);
            this.txtComment.TabIndex = 5;
            this.txtComment.TextChanged += new System.EventHandler(this.TxtComment_TextChanged);
            this.txtComment.Enter += new System.EventHandler(this.TxtComment_Enter);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(40, 411);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(520, 54);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "✅  Submit Review";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // ReviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(613, 492);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.lblCommentPrompt);
            this.Controls.Add(this.panelStars);
            this.Controls.Add(this.lblRatingPrompt);
            this.Controls.Add(this.lblPropertyName);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "ReviewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Write a Review";
            this.panelHeader.ResumeLayout(false);
            this.panelStars.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblPropertyName;
        private System.Windows.Forms.Label lblRatingPrompt;
        private System.Windows.Forms.Panel panelStars;
        private System.Windows.Forms.Button btnStar1;
        private System.Windows.Forms.Button btnStar2;
        private System.Windows.Forms.Button btnStar3;
        private System.Windows.Forms.Button btnStar4;
        private System.Windows.Forms.Button btnStar5;
        private System.Windows.Forms.Label lblCommentPrompt;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnSubmit;
    }


    // ─────────────────────────────────────────────────────────────────────────
    // ReviewViewForm  –  read-only grid of reviews for a selected property
    // ─────────────────────────────────────────────────────────────────────────
    partial class ReviewViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(255, 140, 0);
            this.panelHeader.Controls.Add(this.lblHeaderTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Height = 65;
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(700, 65);
            this.panelHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "⭐  Property Reviews";
            this.lblHeaderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.ColumnHeadersHeight = 38;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgv.GridColor = System.Drawing.Color.FromArgb(230, 235, 245);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.TabIndex = 1;
            this.dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 140, 0);
            this.dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 252, 240);
            // 
            // ReviewViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.panelHeader);
            this.Name = "ReviewViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Property Reviews";
            this.lblHeaderTitle.Click += new System.EventHandler(this.LblHeaderTitle_Click);
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.DataGridView dgv;
    }
}
