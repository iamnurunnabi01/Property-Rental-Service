namespace PropertyRentalServices.Forms
{
    partial class AdminDashboard
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
            this.tabActualRevenue = new System.Windows.Forms.TabPage();
            this.toolbarActualRevenue = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRefreshActualRevenue = new System.Windows.Forms.Button();
            this.dgvActualRevenue = new System.Windows.Forms.DataGridView();
            this.lblActualRevenueNote = new System.Windows.Forms.Label();
            this.panelActualRevSummary = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panelStats = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.toolbarUsers = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRefreshUsers = new System.Windows.Forms.Button();
            this.btnDeleteOwner = new System.Windows.Forms.Button();
            this.tabProperties = new System.Windows.Forms.TabPage();
            this.dgvProperties = new System.Windows.Forms.DataGridView();
            this.toolbarProperties = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRefreshProperties = new System.Windows.Forms.Button();
            this.tabBookings = new System.Windows.Forms.TabPage();
            this.dgvBookings = new System.Windows.Forms.DataGridView();
            this.toolbarBookings = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRefreshBookings = new System.Windows.Forms.Button();
            this.tabReviews = new System.Windows.Forms.TabPage();
            this.dgvReviews = new System.Windows.Forms.DataGridView();
            this.toolbarReviews = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRefreshReviews = new System.Windows.Forms.Button();
            this.tabRevenue = new System.Windows.Forms.TabPage();
            this.dgvRevenue = new System.Windows.Forms.DataGridView();
            this.lblRevenueNote = new System.Windows.Forms.Label();
            this.panelRevenueSummary = new System.Windows.Forms.Panel();
            this.toolbarRevenue = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRefreshRevenue = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.toolbarUsers.SuspendLayout();
            this.tabProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProperties)).BeginInit();
            this.toolbarProperties.SuspendLayout();
            this.tabBookings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).BeginInit();
            this.toolbarBookings.SuspendLayout();
            this.tabReviews.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReviews)).BeginInit();
            this.toolbarReviews.SuspendLayout();
            this.tabRevenue.SuspendLayout();
            this.tabActualRevenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActualRevenue)).BeginInit();
            this.toolbarActualRevenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRevenue)).BeginInit();
            this.toolbarRevenue.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(30, 60, 114);
            this.panelHeader.Controls.Add(this.lblWelcome);
            this.panelHeader.Controls.Add(this.btnLogout);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Height = 70;
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1200, 70);
            this.panelHeader.TabIndex = 0;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "👑  SuperAdmin Panel";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // panelStats
            // 
            this.panelStats.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStats.Height = 100;
            this.panelStats.Name = "panelStats";
            this.panelStats.Padding = new System.Windows.Forms.Padding(10);
            this.panelStats.Size = new System.Drawing.Size(1200, 100);
            this.panelStats.TabIndex = 1;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.tabControl);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(10);
            this.panelContent.TabIndex = 2;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabUsers);
            this.tabControl.Controls.Add(this.tabProperties);
            this.tabControl.Controls.Add(this.tabBookings);
            this.tabControl.Controls.Add(this.tabReviews);
            this.tabControl.Controls.Add(this.tabRevenue);
            this.tabControl.Controls.Add(this.tabActualRevenue);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl.Margin = new System.Windows.Forms.Padding(10);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.TabIndex = 0;
            // 
            // tabUsers
            // 
            this.tabUsers.BackColor = System.Drawing.Color.White;
            this.tabUsers.Controls.Add(this.dgvUsers);
            this.tabUsers.Controls.Add(this.toolbarUsers);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Text = "👥  All Users";
            // 
            // toolbarUsers
            // 
            this.toolbarUsers.BackColor = System.Drawing.Color.FromArgb(240, 244, 255);
            this.toolbarUsers.Controls.Add(this.btnRefreshUsers);
            this.toolbarUsers.Controls.Add(this.btnDeleteOwner);
            this.toolbarUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbarUsers.Height = 50;
            this.toolbarUsers.Name = "toolbarUsers";
            this.toolbarUsers.Padding = new System.Windows.Forms.Padding(5);
            this.toolbarUsers.TabIndex = 0;
            // 
            // btnRefreshUsers
            // 
            this.btnRefreshUsers.BackColor = System.Drawing.Color.FromArgb(30, 60, 114);
            this.btnRefreshUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshUsers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefreshUsers.ForeColor = System.Drawing.Color.White;
            this.btnRefreshUsers.Margin = new System.Windows.Forms.Padding(5);
            this.btnRefreshUsers.Name = "btnRefreshUsers";
            this.btnRefreshUsers.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnRefreshUsers.Size = new System.Drawing.Size(100, 36);
            this.btnRefreshUsers.TabIndex = 0;
            this.btnRefreshUsers.Click += new System.EventHandler(this.BtnRefreshUsers_Click);
            this.btnRefreshUsers.Text = "🔄 Refresh";
            this.btnRefreshUsers.UseVisualStyleBackColor = false;
            this.btnRefreshUsers.FlatAppearance.BorderSize = 0;
            // 
            // btnDeleteOwner
            // 
            this.btnDeleteOwner.BackColor = System.Drawing.Color.FromArgb(200, 50, 50);
            this.btnDeleteOwner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteOwner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteOwner.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeleteOwner.ForeColor = System.Drawing.Color.White;
            this.btnDeleteOwner.Margin = new System.Windows.Forms.Padding(5);
            this.btnDeleteOwner.Name = "btnDeleteOwner";
            this.btnDeleteOwner.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnDeleteOwner.Size = new System.Drawing.Size(220, 36);
            this.btnDeleteOwner.TabIndex = 1;
            this.btnDeleteOwner.Click += new System.EventHandler(this.BtnDeleteOwner_Click);
            this.btnDeleteOwner.Text = "🗑 Delete Owner (Low Rating)";
            this.btnDeleteOwner.UseVisualStyleBackColor = false;
            this.btnDeleteOwner.FlatAppearance.BorderSize = 0;
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsers.ColumnHeadersHeight = 38;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvUsers.GridColor = System.Drawing.Color.FromArgb(230, 235, 245);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.TabIndex = 1;
            this.dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 60, 114);
            this.dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvUsers.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvUsers.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 255);
            // 
            // tabProperties
            // 
            this.tabProperties.BackColor = System.Drawing.Color.White;
            this.tabProperties.Controls.Add(this.dgvProperties);
            this.tabProperties.Controls.Add(this.toolbarProperties);
            this.tabProperties.Name = "tabProperties";
            this.tabProperties.Text = "🏠  All Properties";
            // 
            // toolbarProperties
            // 
            this.toolbarProperties.BackColor = System.Drawing.Color.FromArgb(240, 255, 248);
            this.toolbarProperties.Controls.Add(this.btnRefreshProperties);
            this.toolbarProperties.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbarProperties.Height = 50;
            this.toolbarProperties.Name = "toolbarProperties";
            this.toolbarProperties.Padding = new System.Windows.Forms.Padding(5);
            this.toolbarProperties.TabIndex = 0;
            // 
            // btnRefreshProperties
            // 
            this.btnRefreshProperties.BackColor = System.Drawing.Color.FromArgb(20, 150, 120);
            this.btnRefreshProperties.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshProperties.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshProperties.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefreshProperties.ForeColor = System.Drawing.Color.White;
            this.btnRefreshProperties.Margin = new System.Windows.Forms.Padding(5);
            this.btnRefreshProperties.Name = "btnRefreshProperties";
            this.btnRefreshProperties.Size = new System.Drawing.Size(100, 36);
            this.btnRefreshProperties.TabIndex = 0;
            this.btnRefreshProperties.Click += new System.EventHandler(this.BtnRefreshProperties_Click);
            this.btnRefreshProperties.Text = "🔄 Refresh";
            this.btnRefreshProperties.UseVisualStyleBackColor = false;
            this.btnRefreshProperties.FlatAppearance.BorderSize = 0;
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
            this.dgvProperties.TabIndex = 1;
            this.dgvProperties.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 60, 114);
            this.dgvProperties.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvProperties.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvProperties.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 255);
            // 
            // tabBookings
            // 
            this.tabBookings.BackColor = System.Drawing.Color.White;
            this.tabBookings.Controls.Add(this.dgvBookings);
            this.tabBookings.Controls.Add(this.toolbarBookings);
            this.tabBookings.Name = "tabBookings";
            this.tabBookings.Text = "📅  All Bookings";
            // 
            // toolbarBookings
            // 
            this.toolbarBookings.BackColor = System.Drawing.Color.FromArgb(255, 250, 240);
            this.toolbarBookings.Controls.Add(this.btnRefreshBookings);
            this.toolbarBookings.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbarBookings.Height = 50;
            this.toolbarBookings.Name = "toolbarBookings";
            this.toolbarBookings.Padding = new System.Windows.Forms.Padding(5);
            this.toolbarBookings.TabIndex = 0;
            // 
            // btnRefreshBookings
            // 
            this.btnRefreshBookings.BackColor = System.Drawing.Color.FromArgb(255, 140, 0);
            this.btnRefreshBookings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshBookings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefreshBookings.ForeColor = System.Drawing.Color.White;
            this.btnRefreshBookings.Margin = new System.Windows.Forms.Padding(5);
            this.btnRefreshBookings.Name = "btnRefreshBookings";
            this.btnRefreshBookings.Size = new System.Drawing.Size(100, 36);
            this.btnRefreshBookings.TabIndex = 0;
            this.btnRefreshBookings.Click += new System.EventHandler(this.BtnRefreshBookings_Click);
            this.btnRefreshBookings.Text = "🔄 Refresh";
            this.btnRefreshBookings.UseVisualStyleBackColor = false;
            this.btnRefreshBookings.FlatAppearance.BorderSize = 0;
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
            // tabReviews
            // 
            this.tabReviews.BackColor = System.Drawing.Color.White;
            this.tabReviews.Controls.Add(this.dgvReviews);
            this.tabReviews.Controls.Add(this.toolbarReviews);
            this.tabReviews.Name = "tabReviews";
            this.tabReviews.Text = "⭐  All Reviews";
            // 
            // toolbarReviews
            // 
            this.toolbarReviews.BackColor = System.Drawing.Color.FromArgb(250, 245, 255);
            this.toolbarReviews.Controls.Add(this.btnRefreshReviews);
            this.toolbarReviews.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbarReviews.Height = 50;
            this.toolbarReviews.Name = "toolbarReviews";
            this.toolbarReviews.Padding = new System.Windows.Forms.Padding(5);
            this.toolbarReviews.TabIndex = 0;
            // 
            // btnRefreshReviews
            // 
            this.btnRefreshReviews.BackColor = System.Drawing.Color.FromArgb(150, 50, 200);
            this.btnRefreshReviews.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshReviews.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshReviews.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefreshReviews.ForeColor = System.Drawing.Color.White;
            this.btnRefreshReviews.Margin = new System.Windows.Forms.Padding(5);
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
            this.dgvReviews.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 60, 114);
            this.dgvReviews.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvReviews.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvReviews.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 255);
            // 
            // tabRevenue
            // 
            this.tabRevenue.BackColor = System.Drawing.Color.White;
            this.tabRevenue.Controls.Add(this.dgvRevenue);
            this.tabRevenue.Controls.Add(this.lblRevenueNote);
            this.tabRevenue.Controls.Add(this.panelRevenueSummary);
            this.tabRevenue.Controls.Add(this.toolbarRevenue);
            this.tabRevenue.Name = "tabRevenue";
            this.tabRevenue.Text = "💰  Revenue (10%)";
            // 
            // toolbarRevenue
            // 
            this.toolbarRevenue.BackColor = System.Drawing.Color.FromArgb(240, 255, 245);
            this.toolbarRevenue.Controls.Add(this.btnRefreshRevenue);
            this.toolbarRevenue.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbarRevenue.Height = 50;
            this.toolbarRevenue.Name = "toolbarRevenue";
            this.toolbarRevenue.Padding = new System.Windows.Forms.Padding(5);
            this.toolbarRevenue.TabIndex = 0;
            // 
            // btnRefreshRevenue
            // 
            this.btnRefreshRevenue.BackColor = System.Drawing.Color.FromArgb(20, 150, 120);
            this.btnRefreshRevenue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshRevenue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshRevenue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefreshRevenue.ForeColor = System.Drawing.Color.White;
            this.btnRefreshRevenue.Margin = new System.Windows.Forms.Padding(5);
            this.btnRefreshRevenue.Name = "btnRefreshRevenue";
            this.btnRefreshRevenue.Size = new System.Drawing.Size(100, 36);
            this.btnRefreshRevenue.TabIndex = 0;
            this.btnRefreshRevenue.Click += new System.EventHandler(this.BtnRefreshRevenue_Click);
            this.btnRefreshRevenue.Text = "🔄 Refresh";
            this.btnRefreshRevenue.UseVisualStyleBackColor = false;
            this.btnRefreshRevenue.FlatAppearance.BorderSize = 0;
            // 
            // panelRevenueSummary
            // 
            this.panelRevenueSummary.BackColor = System.Drawing.Color.FromArgb(248, 255, 251);
            this.panelRevenueSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRevenueSummary.Height = 110;
            this.panelRevenueSummary.Name = "panelRevenueSummary";
            this.panelRevenueSummary.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.panelRevenueSummary.TabIndex = 1;
            // 
            // lblRevenueNote
            // 
            this.lblRevenueNote.BackColor = System.Drawing.Color.FromArgb(255, 253, 230);
            this.lblRevenueNote.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRevenueNote.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblRevenueNote.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblRevenueNote.Height = 30;
            this.lblRevenueNote.Name = "lblRevenueNote";
            this.lblRevenueNote.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblRevenueNote.TabIndex = 2;
            this.lblRevenueNote.Text = "ℹ  Admin earns 10% of each confirmed booking\'s rent. The table below shows per-booking breakdown.";
            this.lblRevenueNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvRevenue
            // 
            this.dgvRevenue.AllowUserToAddRows = false;
            this.dgvRevenue.AllowUserToDeleteRows = false;
            this.dgvRevenue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRevenue.BackgroundColor = System.Drawing.Color.White;
            this.dgvRevenue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRevenue.ColumnHeadersHeight = 38;
            this.dgvRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRevenue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvRevenue.GridColor = System.Drawing.Color.FromArgb(230, 235, 245);
            this.dgvRevenue.Name = "dgvRevenue";
            this.dgvRevenue.ReadOnly = true;
            this.dgvRevenue.RowHeadersVisible = false;
            this.dgvRevenue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRevenue.TabIndex = 3;
            this.dgvRevenue.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(20, 130, 76);
            this.dgvRevenue.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvRevenue.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvRevenue.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 255);
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.panelHeader);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            //
            // tabActualRevenue
            //
            this.tabActualRevenue.BackColor = System.Drawing.Color.White;
            this.tabActualRevenue.Controls.Add(this.dgvActualRevenue);
            this.tabActualRevenue.Controls.Add(this.lblActualRevenueNote);
            this.tabActualRevenue.Controls.Add(this.panelActualRevSummary);
            this.tabActualRevenue.Controls.Add(this.toolbarActualRevenue);
            this.tabActualRevenue.Name = "tabActualRevenue";
            this.tabActualRevenue.Text = "❤  Actual Revenue";
            //
            // toolbarActualRevenue
            //
            this.toolbarActualRevenue.BackColor = System.Drawing.Color.FromArgb(230, 245, 255);
            this.toolbarActualRevenue.Controls.Add(this.btnRefreshActualRevenue);
            this.toolbarActualRevenue.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbarActualRevenue.Height = 50;
            this.toolbarActualRevenue.Name = "toolbarActualRevenue";
            this.toolbarActualRevenue.Padding = new System.Windows.Forms.Padding(5);
            this.toolbarActualRevenue.TabIndex = 0;
            //
            // btnRefreshActualRevenue
            //
            this.btnRefreshActualRevenue.BackColor = System.Drawing.Color.FromArgb(30, 80, 180);
            this.btnRefreshActualRevenue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshActualRevenue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshActualRevenue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefreshActualRevenue.ForeColor = System.Drawing.Color.White;
            this.btnRefreshActualRevenue.Margin = new System.Windows.Forms.Padding(5);
            this.btnRefreshActualRevenue.Name = "btnRefreshActualRevenue";
            this.btnRefreshActualRevenue.Size = new System.Drawing.Size(110, 36);
            this.btnRefreshActualRevenue.TabIndex = 0;
            this.btnRefreshActualRevenue.Click += new System.EventHandler(this.BtnRefreshActualRevenue_Click);
            this.btnRefreshActualRevenue.Text = "Refresh";
            this.btnRefreshActualRevenue.UseVisualStyleBackColor = false;
            this.btnRefreshActualRevenue.FlatAppearance.BorderSize = 0;
            //
            // panelActualRevSummary
            //
            this.panelActualRevSummary.BackColor = System.Drawing.Color.FromArgb(235, 245, 255);
            this.panelActualRevSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelActualRevSummary.Height = 90;
            this.panelActualRevSummary.Name = "panelActualRevSummary";
            this.panelActualRevSummary.Padding = new System.Windows.Forms.Padding(15, 8, 15, 8);
            this.panelActualRevSummary.TabIndex = 1;
            //
            // lblActualRevenueNote
            //
            this.lblActualRevenueNote.BackColor = System.Drawing.Color.FromArgb(225, 240, 255);
            this.lblActualRevenueNote.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblActualRevenueNote.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblActualRevenueNote.ForeColor = System.Drawing.Color.FromArgb(30, 60, 130);
            this.lblActualRevenueNote.Height = 30;
            this.lblActualRevenueNote.Name = "lblActualRevenueNote";
            this.lblActualRevenueNote.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblActualRevenueNote.TabIndex = 2;
            this.lblActualRevenueNote.Text = "SuperAdmin actual earnings: 10% of every confirmed booking rent, broken down per booking.";
            this.lblActualRevenueNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // dgvActualRevenue
            //
            this.dgvActualRevenue.AllowUserToAddRows = false;
            this.dgvActualRevenue.AllowUserToDeleteRows = false;
            this.dgvActualRevenue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvActualRevenue.BackgroundColor = System.Drawing.Color.White;
            this.dgvActualRevenue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvActualRevenue.ColumnHeadersHeight = 38;
            this.dgvActualRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActualRevenue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvActualRevenue.GridColor = System.Drawing.Color.FromArgb(200, 220, 245);
            this.dgvActualRevenue.Name = "dgvActualRevenue";
            this.dgvActualRevenue.ReadOnly = true;
            this.dgvActualRevenue.RowHeadersVisible = false;
            this.dgvActualRevenue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActualRevenue.TabIndex = 3;
            this.dgvActualRevenue.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 80, 180);
            this.dgvActualRevenue.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvActualRevenue.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvActualRevenue.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 246, 255);
                        this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SuperAdmin Dashboard - Property Rental Services";
            this.panelHeader.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.toolbarUsers.ResumeLayout(false);
            this.tabProperties.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProperties)).EndInit();
            this.toolbarProperties.ResumeLayout(false);
            this.tabBookings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).EndInit();
            this.toolbarBookings.ResumeLayout(false);
            this.tabReviews.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReviews)).EndInit();
            this.toolbarReviews.ResumeLayout(false);
            this.tabRevenue.ResumeLayout(false);
            this.tabActualRevenue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActualRevenue)).EndInit();
            this.toolbarActualRevenue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRevenue)).EndInit();
            this.toolbarRevenue.ResumeLayout(false);
            this.lblRevenueNote.Click += new System.EventHandler(this.LblRevenueNote_Click);
            this.lblWelcome.Click += new System.EventHandler(this.LblWelcome_Click);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabPage tabActualRevenue;
        private System.Windows.Forms.FlowLayoutPanel toolbarActualRevenue;
        private System.Windows.Forms.Button btnRefreshActualRevenue;
        private System.Windows.Forms.DataGridView dgvActualRevenue;
        private System.Windows.Forms.Label lblActualRevenueNote;
        private System.Windows.Forms.Panel panelActualRevSummary;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabUsers;
        private System.Windows.Forms.FlowLayoutPanel toolbarUsers;
        private System.Windows.Forms.Button btnRefreshUsers;
        private System.Windows.Forms.Button btnDeleteOwner;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.TabPage tabProperties;
        private System.Windows.Forms.FlowLayoutPanel toolbarProperties;
        private System.Windows.Forms.Button btnRefreshProperties;
        private System.Windows.Forms.DataGridView dgvProperties;
        private System.Windows.Forms.TabPage tabBookings;
        private System.Windows.Forms.FlowLayoutPanel toolbarBookings;
        private System.Windows.Forms.Button btnRefreshBookings;
        private System.Windows.Forms.DataGridView dgvBookings;
        private System.Windows.Forms.TabPage tabReviews;
        private System.Windows.Forms.FlowLayoutPanel toolbarReviews;
        private System.Windows.Forms.Button btnRefreshReviews;
        private System.Windows.Forms.DataGridView dgvReviews;
        private System.Windows.Forms.TabPage tabRevenue;
        private System.Windows.Forms.FlowLayoutPanel toolbarRevenue;
        private System.Windows.Forms.Button btnRefreshRevenue;
        private System.Windows.Forms.Panel panelRevenueSummary;
        private System.Windows.Forms.Label lblRevenueNote;
        private System.Windows.Forms.DataGridView dgvRevenue;
    }
}
