namespace PropertyRentalServices.Forms
{
    partial class CustomerDashboard
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
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabBrowse = new System.Windows.Forms.TabPage();
            this.dgvProperties = new System.Windows.Forms.DataGridView();
            this.panelBrowseActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.btnViewReviews = new System.Windows.Forms.Button();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.btnResetFilter = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtMaxPrice = new System.Windows.Forms.TextBox();
            this.lblMaxPrice = new System.Windows.Forms.Label();
            this.txtMinPrice = new System.Windows.Forms.TextBox();
            this.lblMinPrice = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbBedrooms = new System.Windows.Forms.ComboBox();
            this.lblBedrooms = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.tabCart = new System.Windows.Forms.TabPage();
            this.lblCartTotal = new System.Windows.Forms.Label();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.toolbarCart = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRemoveCart = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnClearCart = new System.Windows.Forms.Button();
            this.tabMyBookings = new System.Windows.Forms.TabPage();
            this.dgvBookings = new System.Windows.Forms.DataGridView();
            this.toolbarBookings = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRefreshBookings = new System.Windows.Forms.Button();
            this.btnAddReview = new System.Windows.Forms.Button();
            this.tabMyReviews = new System.Windows.Forms.TabPage();
            this.dgvReviews = new System.Windows.Forms.DataGridView();
            this.toolbarReviews = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRefreshReviews = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabBrowse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProperties)).BeginInit();
            this.panelBrowseActions.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.tabCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.toolbarCart.SuspendLayout();
            this.tabMyBookings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).BeginInit();
            this.toolbarBookings.SuspendLayout();
            this.tabMyReviews.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReviews)).BeginInit();
            this.toolbarReviews.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(30, 100, 200);
            this.panelHeader.Controls.Add(this.lblHeaderTitle);
            this.panelHeader.Controls.Add(this.btnLogout);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Height = 70;
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1200, 70);
            this.panelHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "🏠  Property Rental";
            this.lblHeaderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(200, 50, 50);
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 70);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.tabControl);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(8);
            this.panelMain.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabBrowse);
            this.tabControl.Controls.Add(this.tabCart);
            this.tabControl.Controls.Add(this.tabMyBookings);
            this.tabControl.Controls.Add(this.tabMyReviews);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.TabIndex = 0;
            // 
            // tabBrowse
            // 
            this.tabBrowse.BackColor = System.Drawing.Color.White;
            this.tabBrowse.Controls.Add(this.dgvProperties);
            this.tabBrowse.Controls.Add(this.panelBrowseActions);
            this.tabBrowse.Controls.Add(this.panelFilter);
            this.tabBrowse.Name = "tabBrowse";
            this.tabBrowse.Text = "🔍  Browse Properties";
            // 
            // panelFilter
            // 
            this.panelFilter.BackColor = System.Drawing.Color.FromArgb(235, 242, 255);
            this.panelFilter.Controls.Add(this.lblSearch);
            this.panelFilter.Controls.Add(this.txtSearch);
            this.panelFilter.Controls.Add(this.lblLocation);
            this.panelFilter.Controls.Add(this.cmbLocation);
            this.panelFilter.Controls.Add(this.lblBedrooms);
            this.panelFilter.Controls.Add(this.cmbBedrooms);
            this.panelFilter.Controls.Add(this.lblStatus);
            this.panelFilter.Controls.Add(this.cmbStatus);
            this.panelFilter.Controls.Add(this.lblMinPrice);
            this.panelFilter.Controls.Add(this.txtMinPrice);
            this.panelFilter.Controls.Add(this.lblMaxPrice);
            this.panelFilter.Controls.Add(this.txtMaxPrice);
            this.panelFilter.Controls.Add(this.btnSearch);
            this.panelFilter.Controls.Add(this.btnResetFilter);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Height = 110;
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.panelFilter.TabIndex = 0;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblSearch.Location = new System.Drawing.Point(10, 8);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(10, 28);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(160, 30);
            this.txtSearch.TabIndex = 1;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLocation.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblLocation.Location = new System.Drawing.Point(185, 8);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.TabIndex = 2;
            this.lblLocation.Text = "Location:";
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbLocation.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbLocation.Location = new System.Drawing.Point(185, 28);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(140, 28);
            this.cmbLocation.TabIndex = 3;
            // 
            // lblBedrooms
            // 
            this.lblBedrooms.AutoSize = true;
            this.lblBedrooms.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBedrooms.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblBedrooms.Location = new System.Drawing.Point(340, 8);
            this.lblBedrooms.Name = "lblBedrooms";
            this.lblBedrooms.TabIndex = 4;
            this.lblBedrooms.Text = "Bedrooms:";
            // 
            // cmbBedrooms
            // 
            this.cmbBedrooms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBedrooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBedrooms.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbBedrooms.Items.AddRange(new object[] { "Any", "1", "2", "3", "4", "5+" });
            this.cmbBedrooms.Location = new System.Drawing.Point(340, 28);
            this.cmbBedrooms.Name = "cmbBedrooms";
            this.cmbBedrooms.Size = new System.Drawing.Size(100, 28);
            this.cmbBedrooms.TabIndex = 5;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblStatus.Location = new System.Drawing.Point(455, 8);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Status:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStatus.Items.AddRange(new object[] { "All", "Available", "Booked", "Unavailable" });
            this.cmbStatus.Location = new System.Drawing.Point(455, 28);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(120, 28);
            this.cmbStatus.TabIndex = 7;
            // 
            // lblMinPrice
            // 
            this.lblMinPrice.AutoSize = true;
            this.lblMinPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMinPrice.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblMinPrice.Location = new System.Drawing.Point(590, 8);
            this.lblMinPrice.Name = "lblMinPrice";
            this.lblMinPrice.TabIndex = 8;
            this.lblMinPrice.Text = "Min Price (৳):";
            // 
            // txtMinPrice
            // 
            this.txtMinPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMinPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMinPrice.Location = new System.Drawing.Point(590, 28);
            this.txtMinPrice.Name = "txtMinPrice";
            this.txtMinPrice.Size = new System.Drawing.Size(90, 28);
            this.txtMinPrice.TabIndex = 9;
            // 
            // lblMaxPrice
            // 
            this.lblMaxPrice.AutoSize = true;
            this.lblMaxPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMaxPrice.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblMaxPrice.Location = new System.Drawing.Point(695, 8);
            this.lblMaxPrice.Name = "lblMaxPrice";
            this.lblMaxPrice.TabIndex = 10;
            this.lblMaxPrice.Text = "Max Price (৳):";
            // 
            // txtMaxPrice
            // 
            this.txtMaxPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaxPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaxPrice.Location = new System.Drawing.Point(695, 28);
            this.txtMaxPrice.Name = "txtMaxPrice";
            this.txtMaxPrice.Size = new System.Drawing.Size(90, 28);
            this.txtMaxPrice.TabIndex = 11;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(30, 100, 200);
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(800, 24);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 36);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            this.btnSearch.Text = "🔍 Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            // 
            // btnResetFilter
            // 
            this.btnResetFilter.BackColor = System.Drawing.Color.Gray;
            this.btnResetFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetFilter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnResetFilter.ForeColor = System.Drawing.Color.White;
            this.btnResetFilter.Location = new System.Drawing.Point(910, 24);
            this.btnResetFilter.Name = "btnResetFilter";
            this.btnResetFilter.Size = new System.Drawing.Size(80, 36);
            this.btnResetFilter.TabIndex = 13;
            this.btnResetFilter.Click += new System.EventHandler(this.BtnResetFilter_Click);
            this.btnResetFilter.Text = "↺ Reset";
            this.btnResetFilter.UseVisualStyleBackColor = false;
            this.btnResetFilter.FlatAppearance.BorderSize = 0;
            // 
            // panelBrowseActions
            // 
            this.panelBrowseActions.BackColor = System.Drawing.Color.FromArgb(245, 248, 255);
            this.panelBrowseActions.Controls.Add(this.btnAddToCart);
            this.panelBrowseActions.Controls.Add(this.btnViewReviews);
            this.panelBrowseActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBrowseActions.Height = 50;
            this.panelBrowseActions.Name = "panelBrowseActions";
            this.panelBrowseActions.Padding = new System.Windows.Forms.Padding(5);
            this.panelBrowseActions.TabIndex = 1;
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.BackColor = System.Drawing.Color.FromArgb(30, 100, 200);
            this.btnAddToCart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddToCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToCart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddToCart.ForeColor = System.Drawing.Color.White;
            this.btnAddToCart.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnAddToCart.Size = new System.Drawing.Size(120, 36);
            this.btnAddToCart.TabIndex = 0;
            this.btnAddToCart.Click += new System.EventHandler(this.BtnAddToCart_Click);
            this.btnAddToCart.Text = "🛒 Add to Cart";
            this.btnAddToCart.UseVisualStyleBackColor = false;
            this.btnAddToCart.FlatAppearance.BorderSize = 0;
            // 
            // btnViewReviews
            // 
            this.btnViewReviews.BackColor = System.Drawing.Color.FromArgb(255, 140, 0);
            this.btnViewReviews.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewReviews.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewReviews.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnViewReviews.ForeColor = System.Drawing.Color.White;
            this.btnViewReviews.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewReviews.Name = "btnViewReviews";
            this.btnViewReviews.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnViewReviews.Size = new System.Drawing.Size(130, 36);
            this.btnViewReviews.TabIndex = 1;
            this.btnViewReviews.Click += new System.EventHandler(this.BtnViewReviews_Click);
            this.btnViewReviews.Text = "⭐ View Reviews";
            this.btnViewReviews.UseVisualStyleBackColor = false;
            this.btnViewReviews.FlatAppearance.BorderSize = 0;
            // 
            // dgvProperties
            // 
            this.dgvProperties.AllowUserToAddRows = false;
            this.dgvProperties.AllowUserToDeleteRows = false;
            this.dgvProperties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProperties.BackgroundColor = System.Drawing.Color.White;
            this.dgvProperties.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProperties.ColumnHeadersHeight = 38;
            this.dgvProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProperties.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvProperties.GridColor = System.Drawing.Color.FromArgb(230, 235, 245);
            this.dgvProperties.Name = "dgvProperties";
            this.dgvProperties.ReadOnly = true;
            this.dgvProperties.RowHeadersVisible = false;
            this.dgvProperties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProperties.TabIndex = 2;
            this.dgvProperties.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 100, 200);
            this.dgvProperties.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvProperties.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvProperties.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 255);
            // 
            // tabCart
            // 
            this.tabCart.BackColor = System.Drawing.Color.White;
            this.tabCart.Controls.Add(this.dgvCart);
            this.tabCart.Controls.Add(this.lblCartTotal);
            this.tabCart.Controls.Add(this.toolbarCart);
            this.tabCart.Name = "tabCart";
            this.tabCart.Text = "🛒  Booking Cart";
            // 
            // toolbarCart
            // 
            this.toolbarCart.BackColor = System.Drawing.Color.FromArgb(240, 255, 245);
            this.toolbarCart.Controls.Add(this.btnRemoveCart);
            this.toolbarCart.Controls.Add(this.btnCheckout);
            this.toolbarCart.Controls.Add(this.btnClearCart);
            this.toolbarCart.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbarCart.Height = 50;
            this.toolbarCart.Name = "toolbarCart";
            this.toolbarCart.Padding = new System.Windows.Forms.Padding(5);
            this.toolbarCart.TabIndex = 0;
            // 
            // btnRemoveCart
            // 
            this.btnRemoveCart.BackColor = System.Drawing.Color.FromArgb(200, 50, 50);
            this.btnRemoveCart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveCart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRemoveCart.ForeColor = System.Drawing.Color.White;
            this.btnRemoveCart.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveCart.Name = "btnRemoveCart";
            this.btnRemoveCart.Size = new System.Drawing.Size(140, 36);
            this.btnRemoveCart.TabIndex = 0;
            this.btnRemoveCart.Click += new System.EventHandler(this.BtnRemoveCart_Click);
            this.btnRemoveCart.Text = "❌ Remove Selected";
            this.btnRemoveCart.UseVisualStyleBackColor = false;
            this.btnRemoveCart.FlatAppearance.BorderSize = 0;
            // 
            // btnCheckout
            // 
            this.btnCheckout.BackColor = System.Drawing.Color.FromArgb(20, 150, 80);
            this.btnCheckout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.Margin = new System.Windows.Forms.Padding(4);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(130, 36);
            this.btnCheckout.TabIndex = 1;
            this.btnCheckout.Click += new System.EventHandler(this.BtnCheckout_Click);
            this.btnCheckout.Text = "✅ Confirm & Pay";
            this.btnCheckout.UseVisualStyleBackColor = false;
            this.btnCheckout.FlatAppearance.BorderSize = 0;
            // 
            // btnClearCart
            // 
            this.btnClearCart.BackColor = System.Drawing.Color.Gray;
            this.btnClearCart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearCart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClearCart.ForeColor = System.Drawing.Color.White;
            this.btnClearCart.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearCart.Name = "btnClearCart";
            this.btnClearCart.Size = new System.Drawing.Size(100, 36);
            this.btnClearCart.TabIndex = 2;
            this.btnClearCart.Click += new System.EventHandler(this.BtnClearCart_Click);
            this.btnClearCart.Text = "🗑 Clear Cart";
            this.btnClearCart.UseVisualStyleBackColor = false;
            this.btnClearCart.FlatAppearance.BorderSize = 0;
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCart.BackgroundColor = System.Drawing.Color.White;
            this.dgvCart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCart.ColumnHeadersHeight = 38;
            this.dgvCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCart.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvCart.GridColor = System.Drawing.Color.FromArgb(230, 235, 245);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.TabIndex = 1;
            this.dgvCart.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(20, 150, 80);
            this.dgvCart.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCart.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvCart.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 255);
            // 
            // lblCartTotal
            // 
            this.lblCartTotal.BackColor = System.Drawing.Color.FromArgb(240, 255, 245);
            this.lblCartTotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCartTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCartTotal.ForeColor = System.Drawing.Color.FromArgb(20, 150, 80);
            this.lblCartTotal.Height = 40;
            this.lblCartTotal.Name = "lblCartTotal";
            this.lblCartTotal.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblCartTotal.TabIndex = 2;
            this.lblCartTotal.Text = "  Cart Total: ৳0.00   (0 item(s))";
            this.lblCartTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabMyBookings
            // 
            this.tabMyBookings.BackColor = System.Drawing.Color.White;
            this.tabMyBookings.Controls.Add(this.dgvBookings);
            this.tabMyBookings.Controls.Add(this.toolbarBookings);
            this.tabMyBookings.Name = "tabMyBookings";
            this.tabMyBookings.Text = "📋  My Bookings";
            // 
            // toolbarBookings
            // 
            this.toolbarBookings.BackColor = System.Drawing.Color.FromArgb(245, 250, 255);
            this.toolbarBookings.Controls.Add(this.btnRefreshBookings);
            this.toolbarBookings.Controls.Add(this.btnAddReview);
            this.toolbarBookings.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbarBookings.Height = 50;
            this.toolbarBookings.Name = "toolbarBookings";
            this.toolbarBookings.Padding = new System.Windows.Forms.Padding(5);
            this.toolbarBookings.TabIndex = 0;
            // 
            // btnRefreshBookings
            // 
            this.btnRefreshBookings.BackColor = System.Drawing.Color.FromArgb(30, 60, 114);
            this.btnRefreshBookings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshBookings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefreshBookings.ForeColor = System.Drawing.Color.White;
            this.btnRefreshBookings.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefreshBookings.Name = "btnRefreshBookings";
            this.btnRefreshBookings.Size = new System.Drawing.Size(100, 36);
            this.btnRefreshBookings.TabIndex = 0;
            this.btnRefreshBookings.Click += new System.EventHandler(this.BtnRefreshBookings_Click);
            this.btnRefreshBookings.Text = "🔄 Refresh";
            this.btnRefreshBookings.UseVisualStyleBackColor = false;
            this.btnRefreshBookings.FlatAppearance.BorderSize = 0;
            // 
            // btnAddReview
            // 
            this.btnAddReview.BackColor = System.Drawing.Color.FromArgb(255, 140, 0);
            this.btnAddReview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddReview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddReview.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddReview.ForeColor = System.Drawing.Color.White;
            this.btnAddReview.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddReview.Name = "btnAddReview";
            this.btnAddReview.Size = new System.Drawing.Size(110, 36);
            this.btnAddReview.TabIndex = 1;
            this.btnAddReview.Click += new System.EventHandler(this.BtnAddReview_Click);
            this.btnAddReview.Text = "⭐ Add Review";
            this.btnAddReview.UseVisualStyleBackColor = false;
            this.btnAddReview.FlatAppearance.BorderSize = 0;
            // 
            // dgvBookings
            // 
            this.dgvBookings.AllowUserToAddRows = false;
            this.dgvBookings.AllowUserToDeleteRows = false;
            this.dgvBookings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBookings.BackgroundColor = System.Drawing.Color.White;
            this.dgvBookings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBookings.ColumnHeadersHeight = 38;
            this.dgvBookings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBookings.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvBookings.GridColor = System.Drawing.Color.FromArgb(230, 235, 245);
            this.dgvBookings.Name = "dgvBookings";
            this.dgvBookings.ReadOnly = true;
            this.dgvBookings.RowHeadersVisible = false;
            this.dgvBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBookings.TabIndex = 1;
            this.dgvBookings.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 60, 114);
            this.dgvBookings.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBookings.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvBookings.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 255);
            // 
            // tabMyReviews
            // 
            this.tabMyReviews.BackColor = System.Drawing.Color.White;
            this.tabMyReviews.Controls.Add(this.dgvReviews);
            this.tabMyReviews.Controls.Add(this.toolbarReviews);
            this.tabMyReviews.Name = "tabMyReviews";
            this.tabMyReviews.Text = "⭐  My Reviews";
            // 
            // toolbarReviews
            // 
            this.toolbarReviews.BackColor = System.Drawing.Color.FromArgb(255, 250, 240);
            this.toolbarReviews.Controls.Add(this.btnRefreshReviews);
            this.toolbarReviews.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbarReviews.Height = 50;
            this.toolbarReviews.Name = "toolbarReviews";
            this.toolbarReviews.Padding = new System.Windows.Forms.Padding(5);
            this.toolbarReviews.TabIndex = 0;
            // 
            // btnRefreshReviews
            // 
            this.btnRefreshReviews.BackColor = System.Drawing.Color.FromArgb(255, 140, 0);
            this.btnRefreshReviews.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshReviews.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshReviews.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefreshReviews.ForeColor = System.Drawing.Color.White;
            this.btnRefreshReviews.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefreshReviews.Name = "btnRefreshReviews";
            this.btnRefreshReviews.Size = new System.Drawing.Size(100, 36);
            this.btnRefreshReviews.TabIndex = 0;
            this.btnRefreshReviews.Click += new System.EventHandler(this.BtnRefreshReviews_Click);
            this.btnRefreshReviews.Text = "🔄 Refresh";
            this.btnRefreshReviews.UseVisualStyleBackColor = false;
            this.btnRefreshReviews.FlatAppearance.BorderSize = 0;
            // 
            // dgvReviews
            // 
            this.dgvReviews.AllowUserToAddRows = false;
            this.dgvReviews.AllowUserToDeleteRows = false;
            this.dgvReviews.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReviews.BackgroundColor = System.Drawing.Color.White;
            this.dgvReviews.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReviews.ColumnHeadersHeight = 38;
            this.dgvReviews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReviews.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvReviews.GridColor = System.Drawing.Color.FromArgb(230, 235, 245);
            this.dgvReviews.Name = "dgvReviews";
            this.dgvReviews.ReadOnly = true;
            this.dgvReviews.RowHeadersVisible = false;
            this.dgvReviews.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReviews.TabIndex = 1;
            this.dgvReviews.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 140, 0);
            this.dgvReviews.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvReviews.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvReviews.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 255);
            // 
            // CustomerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 252);
            this.ClientSize = new System.Drawing.Size(1200, 760);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelHeader);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "CustomerDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Dashboard - Property Rental Services";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CustomerDashboard_FormClosed);
            this.panelHeader.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabBrowse.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProperties)).EndInit();
            this.panelBrowseActions.ResumeLayout(false);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.tabCart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.toolbarCart.ResumeLayout(false);
            this.tabMyBookings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).EndInit();
            this.toolbarBookings.ResumeLayout(false);
            this.tabMyReviews.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReviews)).EndInit();
            this.toolbarReviews.ResumeLayout(false);
            this.lblBedrooms.Click += new System.EventHandler(this.LblBedrooms_Click);
            this.lblCartTotal.Click += new System.EventHandler(this.LblCartTotal_Click);
            this.lblHeaderTitle.Click += new System.EventHandler(this.LblHeaderTitle_Click);
            this.lblLocation.Click += new System.EventHandler(this.LblLocation_Click);
            this.lblMaxPrice.Click += new System.EventHandler(this.LblMaxPrice_Click);
            this.lblMinPrice.Click += new System.EventHandler(this.LblMinPrice_Click);
            this.lblSearch.Click += new System.EventHandler(this.LblSearch_Click);
            this.lblStatus.Click += new System.EventHandler(this.LblStatus_Click);
            this.txtMaxPrice.Enter += new System.EventHandler(this.TxtMaxPrice_Enter);
            this.txtMaxPrice.TextChanged += new System.EventHandler(this.TxtMaxPrice_TextChanged);
            this.txtMinPrice.Enter += new System.EventHandler(this.TxtMinPrice_Enter);
            this.txtMinPrice.TextChanged += new System.EventHandler(this.TxtMinPrice_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.TxtSearch_Enter);
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            this.cmbLocation.SelectedIndexChanged += new System.EventHandler(this.CmbLocation_SelectedIndexChanged);
            this.cmbBedrooms.SelectedIndexChanged += new System.EventHandler(this.CmbBedrooms_SelectedIndexChanged);
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.CmbStatus_SelectedIndexChanged);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabBrowse;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label lblBedrooms;
        private System.Windows.Forms.ComboBox cmbBedrooms;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblMinPrice;
        private System.Windows.Forms.TextBox txtMinPrice;
        private System.Windows.Forms.Label lblMaxPrice;
        private System.Windows.Forms.TextBox txtMaxPrice;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnResetFilter;
        private System.Windows.Forms.FlowLayoutPanel panelBrowseActions;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.Button btnViewReviews;
        private System.Windows.Forms.DataGridView dgvProperties;
        private System.Windows.Forms.TabPage tabCart;
        private System.Windows.Forms.FlowLayoutPanel toolbarCart;
        private System.Windows.Forms.Button btnRemoveCart;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnClearCart;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Label lblCartTotal;
        private System.Windows.Forms.TabPage tabMyBookings;
        private System.Windows.Forms.FlowLayoutPanel toolbarBookings;
        private System.Windows.Forms.Button btnRefreshBookings;
        private System.Windows.Forms.Button btnAddReview;
        private System.Windows.Forms.DataGridView dgvBookings;
        private System.Windows.Forms.TabPage tabMyReviews;
        private System.Windows.Forms.FlowLayoutPanel toolbarReviews;
        private System.Windows.Forms.Button btnRefreshReviews;
        private System.Windows.Forms.DataGridView dgvReviews;
    }
}
