namespace PropertyRentalServices.Forms
{
    partial class PaymentForm
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
            this.panelSummary = new System.Windows.Forms.Panel();
            this.lblSummaryInfo = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblMethodLabel = new System.Windows.Forms.Label();
            this.cmbMethod = new System.Windows.Forms.ComboBox();
            this.lblCardName = new System.Windows.Forms.Label();
            this.txtCardName = new System.Windows.Forms.TextBox();
            this.lblCardNumber = new System.Windows.Forms.Label();
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.panelExpiryCvv = new System.Windows.Forms.Panel();
            this.lblExpiry = new System.Windows.Forms.Label();
            this.txtExpiry = new System.Windows.Forms.TextBox();
            this.lblCvv = new System.Windows.Forms.Label();
            this.txtCVV = new System.Windows.Forms.TextBox();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelSummary.SuspendLayout();
            this.panelExpiryCvv.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(20, 150, 80);
            this.panelHeader.Controls.Add(this.lblHeaderTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Height = 70;
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(520, 70);
            this.panelHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "💳  Secure Payment";
            this.lblHeaderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelSummary
            // 
            this.panelSummary.BackColor = System.Drawing.Color.FromArgb(240, 255, 245);
            this.panelSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSummary.Controls.Add(this.lblSummaryInfo);
            this.panelSummary.Controls.Add(this.lblTotal);
            this.panelSummary.Location = new System.Drawing.Point(40, 90);
            this.panelSummary.Name = "panelSummary";
            this.panelSummary.Size = new System.Drawing.Size(420, 90);
            this.panelSummary.TabIndex = 1;
            // 
            // lblSummaryInfo
            // 
            this.lblSummaryInfo.AutoSize = true;
            this.lblSummaryInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSummaryInfo.ForeColor = System.Drawing.Color.FromArgb(20, 100, 60);
            this.lblSummaryInfo.Location = new System.Drawing.Point(10, 8);
            this.lblSummaryInfo.Name = "lblSummaryInfo";
            this.lblSummaryInfo.TabIndex = 0;
            this.lblSummaryInfo.Text = "📋 Booking Summary";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(20, 150, 80);
            this.lblTotal.Location = new System.Drawing.Point(10, 50);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Grand Total:  ৳0.00";
            // 
            // lblMethodLabel
            // 
            this.lblMethodLabel.AutoSize = true;
            this.lblMethodLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMethodLabel.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblMethodLabel.Location = new System.Drawing.Point(40, 200);
            this.lblMethodLabel.Name = "lblMethodLabel";
            this.lblMethodLabel.TabIndex = 2;
            this.lblMethodLabel.Text = "Payment Method";
            // 
            // cmbMethod
            // 
            this.cmbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMethod.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbMethod.Items.AddRange(new object[] {
                "Credit Card",
                "Debit Card",
                "Online Banking",
                "Mobile Banking (bKash)",
                "Cash on Arrival"});
            this.cmbMethod.Location = new System.Drawing.Point(40, 222);
            this.cmbMethod.Name = "cmbMethod";
            this.cmbMethod.Size = new System.Drawing.Size(420, 30);
            this.cmbMethod.TabIndex = 3;
            // 
            // lblCardName
            // 
            this.lblCardName.AutoSize = true;
            this.lblCardName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCardName.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblCardName.Location = new System.Drawing.Point(40, 267);
            this.lblCardName.Name = "lblCardName";
            this.lblCardName.TabIndex = 4;
            this.lblCardName.Text = "Cardholder Name";
            // 
            // txtCardName
            // 
            this.txtCardName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCardName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtCardName.Location = new System.Drawing.Point(40, 289);
            this.txtCardName.Name = "txtCardName";
            this.txtCardName.Size = new System.Drawing.Size(420, 30);
            this.txtCardName.TabIndex = 5;
            // 
            // lblCardNumber
            // 
            this.lblCardNumber.AutoSize = true;
            this.lblCardNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCardNumber.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblCardNumber.Location = new System.Drawing.Point(40, 334);
            this.lblCardNumber.Name = "lblCardNumber";
            this.lblCardNumber.TabIndex = 6;
            this.lblCardNumber.Text = "Card Number";
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCardNumber.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtCardNumber.Location = new System.Drawing.Point(40, 356);
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.Size = new System.Drawing.Size(420, 30);
            this.txtCardNumber.TabIndex = 7;
            // 
            // panelExpiryCvv
            // 
            this.panelExpiryCvv.Controls.Add(this.lblExpiry);
            this.panelExpiryCvv.Controls.Add(this.txtExpiry);
            this.panelExpiryCvv.Controls.Add(this.lblCvv);
            this.panelExpiryCvv.Controls.Add(this.txtCVV);
            this.panelExpiryCvv.Location = new System.Drawing.Point(40, 401);
            this.panelExpiryCvv.Name = "panelExpiryCvv";
            this.panelExpiryCvv.Size = new System.Drawing.Size(420, 65);
            this.panelExpiryCvv.TabIndex = 8;
            // 
            // lblExpiry
            // 
            this.lblExpiry.AutoSize = true;
            this.lblExpiry.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblExpiry.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblExpiry.Location = new System.Drawing.Point(0, 0);
            this.lblExpiry.Name = "lblExpiry";
            this.lblExpiry.TabIndex = 0;
            this.lblExpiry.Text = "Expiry (MM/YY)";
            // 
            // txtExpiry
            // 
            this.txtExpiry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExpiry.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtExpiry.Location = new System.Drawing.Point(0, 22);
            this.txtExpiry.Name = "txtExpiry";
            this.txtExpiry.Size = new System.Drawing.Size(190, 30);
            this.txtExpiry.TabIndex = 1;
            // 
            // lblCvv
            // 
            this.lblCvv.AutoSize = true;
            this.lblCvv.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCvv.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblCvv.Location = new System.Drawing.Point(210, 0);
            this.lblCvv.Name = "lblCvv";
            this.lblCvv.TabIndex = 2;
            this.lblCvv.Text = "CVV";
            // 
            // txtCVV
            // 
            this.txtCVV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCVV.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtCVV.Location = new System.Drawing.Point(210, 22);
            this.txtCVV.Name = "txtCVV";
            this.txtCVV.PasswordChar = '●';
            this.txtCVV.Size = new System.Drawing.Size(210, 30);
            this.txtCVV.TabIndex = 3;
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.FromArgb(20, 150, 80);
            this.btnPay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Location = new System.Drawing.Point(40, 480);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(420, 50);
            this.btnPay.TabIndex = 9;
            this.btnPay.Click += new System.EventHandler(this.BtnPay_Click);
            this.btnPay.Text = "✅  PAY";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.FlatAppearance.BorderSize = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.ForeColor = System.Drawing.Color.Gray;
            this.btnCancel.Location = new System.Drawing.Point(40, 538);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(420, 36);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(520, 590);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.panelExpiryCvv);
            this.Controls.Add(this.txtCardNumber);
            this.Controls.Add(this.lblCardNumber);
            this.Controls.Add(this.txtCardName);
            this.Controls.Add(this.lblCardName);
            this.Controls.Add(this.cmbMethod);
            this.Controls.Add(this.lblMethodLabel);
            this.Controls.Add(this.panelSummary);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Payment";
            this.panelHeader.ResumeLayout(false);
            this.panelSummary.ResumeLayout(false);
            this.panelSummary.PerformLayout();
            this.panelExpiryCvv.ResumeLayout(false);
            this.panelExpiryCvv.PerformLayout();
            this.lblCardName.Click += new System.EventHandler(this.LblCardName_Click);
            this.lblCardNumber.Click += new System.EventHandler(this.LblCardNumber_Click);
            this.lblCvv.Click += new System.EventHandler(this.LblCvv_Click);
            this.lblExpiry.Click += new System.EventHandler(this.LblExpiry_Click);
            this.lblHeaderTitle.Click += new System.EventHandler(this.LblHeaderTitle_Click);
            this.lblMethodLabel.Click += new System.EventHandler(this.LblMethodLabel_Click);
            this.lblSummaryInfo.Click += new System.EventHandler(this.LblSummaryInfo_Click);
            this.lblTotal.Click += new System.EventHandler(this.LblTotal_Click);
            this.txtCVV.Enter += new System.EventHandler(this.TxtCVV_Enter);
            this.txtCVV.TextChanged += new System.EventHandler(this.TxtCVV_TextChanged);
            this.txtCardName.Enter += new System.EventHandler(this.TxtCardName_Enter);
            this.txtCardName.TextChanged += new System.EventHandler(this.TxtCardName_TextChanged);
            this.txtCardNumber.Enter += new System.EventHandler(this.TxtCardNumber_Enter);
            this.txtCardNumber.TextChanged += new System.EventHandler(this.TxtCardNumber_TextChanged);
            this.txtExpiry.Enter += new System.EventHandler(this.TxtExpiry_Enter);
            this.txtExpiry.TextChanged += new System.EventHandler(this.TxtExpiry_TextChanged);
            this.cmbMethod.SelectedIndexChanged += new System.EventHandler(this.CmbMethod_SelectedIndexChanged);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Panel panelSummary;
        private System.Windows.Forms.Label lblSummaryInfo;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblMethodLabel;
        private System.Windows.Forms.ComboBox cmbMethod;
        private System.Windows.Forms.Label lblCardName;
        private System.Windows.Forms.TextBox txtCardName;
        private System.Windows.Forms.Label lblCardNumber;
        private System.Windows.Forms.TextBox txtCardNumber;
        private System.Windows.Forms.Panel panelExpiryCvv;
        private System.Windows.Forms.Label lblExpiry;
        private System.Windows.Forms.TextBox txtExpiry;
        private System.Windows.Forms.Label lblCvv;
        private System.Windows.Forms.TextBox txtCVV;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnCancel;
    }
}
