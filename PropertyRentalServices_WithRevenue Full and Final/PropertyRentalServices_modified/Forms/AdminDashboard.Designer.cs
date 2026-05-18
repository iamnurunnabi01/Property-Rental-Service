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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvRevenue)).BeginInit();
            this.toolbarRevenue.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(114)))));
            this.panelHeader.Controls.Add(this.lblWelcome);
            this.panelHeader.Controls.Add(this.btnLogout);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1600, 86);
            this.panelHeader.TabIndex = 0;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(0, 0);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Padding = new System.Windows.Forms.Padding(27, 0, 0, 0);
            this.lblWelcome.Size = new System.Drawing.Size(1467, 86);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "👑  SuperAdmin Panel";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblWelcome.Click += new System.EventHandler(this.LblWelcome_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(1467, 0);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(133, 86);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // panelStats
            // 
            this.panelStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStats.Location = new System.Drawing.Point(0, 86);
            this.panelStats.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelStats.Name = "panelStats";
            this.panelStats.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.panelStats.Size = new System.Drawing.Size(1600, 123);
            this.panelStats.TabIndex = 1;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.tabControl);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 209);
            this.panelContent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.panelContent.Size = new System.Drawing.Size(1600, 714);
            this.panelContent.TabIndex = 2;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabUsers);
            this.tabControl.Controls.Add(this.tabProperties);
            this.tabControl.Controls.Add(this.tabBookings);
            this.tabControl.Controls.Add(this.tabReviews);
            this.tabControl.Controls.Add(this.tabRevenue);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl.Location = new System.Drawing.Point(13, 12);
            this.tabControl.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1574, 690);
            this.tabControl.TabIndex = 0;
            // 
            // tabUsers
            // 
            this.tabUsers.BackColor = System.Drawing.Color.White;
            this.tabUsers.Controls.Add(this.dgvUsers);
            this.tabUsers.Controls.Add(this.toolbarUsers);
            this.tabUsers.Location = new System.Drawing.Point(4, 32);
            this.tabUsers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Size = new System.Drawing.Size(1566, 654);
            this.tabUsers.TabIndex = 0;
            this.tabUsers.Text = "👥  All Users";
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.dgvUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(114)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUsers.ColumnHeadersHeight = 38;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvUsers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.dgvUsers.Location = new System.Drawing.Point(0, 62);
            this.dgvUsers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.RowHeadersWidth = 51;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(1566, 592);
            this.dgvUsers.TabIndex = 1;
            // 
            // toolbarUsers
            // 
            this.toolbarUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.toolbarUsers.Controls.Add(this.btnRefreshUsers);
            this.toolbarUsers.Controls.Add(this.btnDeleteOwner);
            this.toolbarUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbarUsers.Location = new System.Drawing.Point(0, 0);
            this.toolbarUsers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.toolbarUsers.Name = "toolbarUsers";
            this.toolbarUsers.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.toolbarUsers.Size = new System.Drawing.Size(1566, 62);
            this.toolbarUsers.TabIndex = 0;
            // 
            // btnRefreshUsers
            // 
            this.btnRefreshUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(114)))));
            this.btnRefreshUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshUsers.FlatAppearance.BorderSize = 0;
            this.btnRefreshUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshUsers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefreshUsers.ForeColor = System.Drawing.Color.White;
            this.btnRefreshUsers.Location = new System.Drawing.Point(14, 12);
            this.btnRefreshUsers.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnRefreshUsers.Name = "btnRefreshUsers";
            this.btnRefreshUsers.Padding = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.btnRefreshUsers.Size = new System.Drawing.Size(133, 44);
            this.btnRefreshUsers.TabIndex = 0;
            this.btnRefreshUsers.Text = "🔄 Refresh";
            this.btnRefreshUsers.UseVisualStyleBackColor = false;
            this.btnRefreshUsers.Click += new System.EventHandler(this.BtnRefreshUsers_Click);
            // 
            // btnDeleteOwner
            // 
            this.btnDeleteOwner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnDeleteOwner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteOwner.FlatAppearance.BorderSize = 0;
            this.btnDeleteOwner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteOwner.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeleteOwner.ForeColor = System.Drawing.Color.White;
            this.btnDeleteOwner.Location = new System.Drawing.Point(161, 12);
            this.btnDeleteOwner.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnDeleteOwner.Name = "btnDeleteOwner";
            this.btnDeleteOwner.Padding = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.btnDeleteOwner.Size = new System.Drawing.Size(293, 44);
            this.btnDeleteOwner.TabIndex = 1;
            this.btnDeleteOwner.Text = "🗑 Delete Owner (Low Rating)";
            this.btnDeleteOwner.UseVisualStyleBackColor = false;
            this.btnDeleteOwner.Click += new System.EventHandler(this.BtnDeleteOwner_Click);
            // 
            // tabProperties
            // 
            this.tabProperties.BackColor = System.Drawing.Color.White;
            this.tabProperties.Controls.Add(this.dgvProperties);
            this.tabProperties.Controls.Add(this.toolbarProperties);
            this.tabProperties.Location = new System.Drawing.Point(4, 32);
            this.tabProperties.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabProperties.Name = "tabProperties";
            this.tabProperties.Size = new System.Drawing.Size(259, 87);
            this.tabProperties.TabIndex = 1;
            this.tabProperties.Text = "🏠  All Properties";
            // 
            // dgvProperties
            // 
            this.dgvProperties.AllowUserToAddRows = false;
            this.dgvProperties.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.dgvProperties.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProperties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProperties.BackgroundColor = System.Drawing.Color.White;
            this.dgvProperties.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(114)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProperties.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvProperties.ColumnHeadersHeight = 38;
            this.dgvProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProperties.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvProperties.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.dgvProperties.Location = new System.Drawing.Point(0, 62);
            this.dgvProperties.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvProperties.Name = "dgvProperties";
            this.dgvProperties.ReadOnly = true;
            this.dgvProperties.RowHeadersVisible = false;
            this.dgvProperties.RowHeadersWidth = 51;
            this.dgvProperties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProperties.Size = new System.Drawing.Size(259, 25);
            this.dgvProperties.TabIndex = 1;
            // 
            // toolbarProperties
            // 
            this.toolbarProperties.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(248)))));
            this.toolbarProperties.Controls.Add(this.btnRefreshProperties);
            this.toolbarProperties.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbarProperties.Location = new System.Drawing.Point(0, 0);
            this.toolbarProperties.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.toolbarProperties.Name = "toolbarProperties";
            this.toolbarProperties.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.toolbarProperties.Size = new System.Drawing.Size(259, 62);
            this.toolbarProperties.TabIndex = 0;
            // 
            // btnRefreshProperties
            // 
            this.btnRefreshProperties.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            this.btnRefreshProperties.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshProperties.FlatAppearance.BorderSize = 0;
            this.btnRefreshProperties.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshProperties.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefreshProperties.ForeColor = System.Drawing.Color.White;
            this.btnRefreshProperties.Location = new System.Drawing.Point(14, 12);
            this.btnRefreshProperties.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnRefreshProperties.Name = "btnRefreshProperties";
            this.btnRefreshProperties.Size = new System.Drawing.Size(133, 44);
            this.btnRefreshProperties.TabIndex = 0;
            this.btnRefreshProperties.Text = "🔄 Refresh";
            this.btnRefreshProperties.UseVisualStyleBackColor = false;
            this.btnRefreshProperties.Click += new System.EventHandler(this.BtnRefreshProperties_Click);
            // 
            // tabBookings
            // 
            this.tabBookings.BackColor = System.Drawing.Color.White;
            this.tabBookings.Controls.Add(this.dgvBookings);
            this.tabBookings.Controls.Add(this.toolbarBookings);
            this.tabBookings.Location = new System.Drawing.Point(4, 32);
            this.tabBookings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabBookings.Name = "tabBookings";
            this.tabBookings.Size = new System.Drawing.Size(1566, 654);
            this.tabBookings.TabIndex = 2;
            this.tabBookings.Text = "📅  All Bookings";
            // 
            // dgvBookings
            // 
            this.dgvBookings.AllowUserToAddRows = false;
            this.dgvBookings.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.dgvBookings.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBookings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBookings.BackgroundColor = System.Drawing.Color.White;
            this.dgvBookings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(114)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBookings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBookings.ColumnHeadersHeight = 38;
            this.dgvBookings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBookings.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvBookings.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.dgvBookings.Location = new System.Drawing.Point(0, 62);
            this.dgvBookings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvBookings.Name = "dgvBookings";
            this.dgvBookings.ReadOnly = true;
            this.dgvBookings.RowHeadersVisible = false;
            this.dgvBookings.RowHeadersWidth = 51;
            this.dgvBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBookings.Size = new System.Drawing.Size(1566, 592);
            this.dgvBookings.TabIndex = 1;
            // 
            // toolbarBookings
            // 
            this.toolbarBookings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.toolbarBookings.Controls.Add(this.btnRefreshBookings);
            this.toolbarBookings.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbarBookings.Location = new System.Drawing.Point(0, 0);
            this.toolbarBookings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.toolbarBookings.Name = "toolbarBookings";
            this.toolbarBookings.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.toolbarBookings.Size = new System.Drawing.Size(1566, 62);
            this.toolbarBookings.TabIndex = 0;
            // 
            // btnRefreshBookings
            // 
            this.btnRefreshBookings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.btnRefreshBookings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshBookings.FlatAppearance.BorderSize = 0;
            this.btnRefreshBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshBookings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefreshBookings.ForeColor = System.Drawing.Color.White;
            this.btnRefreshBookings.Location = new System.Drawing.Point(14, 12);
            this.btnRefreshBookings.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnRefreshBookings.Name = "btnRefreshBookings";
            this.btnRefreshBookings.Size = new System.Drawing.Size(133, 44);
            this.btnRefreshBookings.TabIndex = 0;
            this.btnRefreshBookings.Text = "🔄 Refresh";
            this.btnRefreshBookings.UseVisualStyleBackColor = false;
            this.btnRefreshBookings.Click += new System.EventHandler(this.BtnRefreshBookings_Click);
            // 
            // tabReviews
            // 
            this.tabReviews.BackColor = System.Drawing.Color.White;
            this.tabReviews.Controls.Add(this.dgvReviews);
            this.tabReviews.Controls.Add(this.toolbarReviews);
            this.tabReviews.Location = new System.Drawing.Point(4, 32);
            this.tabReviews.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabReviews.Name = "tabReviews";
            this.tabReviews.Size = new System.Drawing.Size(259, 87);
            this.tabReviews.TabIndex = 3;
            this.tabReviews.Text = "⭐  All Reviews";
            // 
            // dgvReviews
            // 
            this.dgvReviews.AllowUserToAddRows = false;
            this.dgvReviews.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.dgvReviews.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvReviews.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReviews.BackgroundColor = System.Drawing.Color.White;
            this.dgvReviews.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(114)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReviews.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvReviews.ColumnHeadersHeight = 38;
            this.dgvReviews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReviews.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvReviews.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.dgvReviews.Location = new System.Drawing.Point(0, 62);
            this.dgvReviews.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvReviews.Name = "dgvReviews";
            this.dgvReviews.ReadOnly = true;
            this.dgvReviews.RowHeadersVisible = false;
            this.dgvReviews.RowHeadersWidth = 51;
            this.dgvReviews.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReviews.Size = new System.Drawing.Size(259, 25);
            this.dgvReviews.TabIndex = 1;
            // 
            // toolbarReviews
            // 
            this.toolbarReviews.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.toolbarReviews.Controls.Add(this.btnRefreshReviews);
            this.toolbarReviews.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbarReviews.Location = new System.Drawing.Point(0, 0);
            this.toolbarReviews.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.toolbarReviews.Name = "toolbarReviews";
            this.toolbarReviews.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.toolbarReviews.Size = new System.Drawing.Size(259, 62);
            this.toolbarReviews.TabIndex = 0;
            // 
            // btnRefreshReviews
            // 
            this.btnRefreshReviews.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(50)))), ((int)(((byte)(200)))));
            this.btnRefreshReviews.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshReviews.FlatAppearance.BorderSize = 0;
            this.btnRefreshReviews.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshReviews.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefreshReviews.ForeColor = System.Drawing.Color.White;
            this.btnRefreshReviews.Location = new System.Drawing.Point(14, 12);
            this.btnRefreshReviews.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnRefreshReviews.Name = "btnRefreshReviews";
            this.btnRefreshReviews.Size = new System.Drawing.Size(133, 44);
            this.btnRefreshReviews.TabIndex = 0;
            this.btnRefreshReviews.Text = "🔄 Refresh";
            this.btnRefreshReviews.UseVisualStyleBackColor = false;
            this.btnRefreshReviews.Click += new System.EventHandler(this.BtnRefreshReviews_Click);
            // 
            // tabRevenue
            // 
            this.tabRevenue.BackColor = System.Drawing.Color.White;
            this.tabRevenue.Controls.Add(this.dgvRevenue);
            this.tabRevenue.Controls.Add(this.lblRevenueNote);
            this.tabRevenue.Controls.Add(this.panelRevenueSummary);
            this.tabRevenue.Controls.Add(this.toolbarRevenue);
            this.tabRevenue.Location = new System.Drawing.Point(4, 32);
            this.tabRevenue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabRevenue.Name = "tabRevenue";
            this.tabRevenue.Size = new System.Drawing.Size(259, 87);
            this.tabRevenue.TabIndex = 4;
            this.tabRevenue.Text = "💰  Revenue (10%)";
            // 
            // dgvRevenue
            // 
            this.dgvRevenue.AllowUserToAddRows = false;
            this.dgvRevenue.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.dgvRevenue.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvRevenue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRevenue.BackgroundColor = System.Drawing.Color.White;
            this.dgvRevenue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(130)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRevenue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvRevenue.ColumnHeadersHeight = 38;
            this.dgvRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRevenue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvRevenue.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.dgvRevenue.Location = new System.Drawing.Point(0, 234);
            this.dgvRevenue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvRevenue.Name = "dgvRevenue";
            this.dgvRevenue.ReadOnly = true;
            this.dgvRevenue.RowHeadersVisible = false;
            this.dgvRevenue.RowHeadersWidth = 51;
            this.dgvRevenue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRevenue.Size = new System.Drawing.Size(259, 0);
            this.dgvRevenue.TabIndex = 3;
            // 
            // lblRevenueNote
            // 
            this.lblRevenueNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(230)))));
            this.lblRevenueNote.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRevenueNote.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblRevenueNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblRevenueNote.Location = new System.Drawing.Point(0, 197);
            this.lblRevenueNote.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRevenueNote.Name = "lblRevenueNote";
            this.lblRevenueNote.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.lblRevenueNote.Size = new System.Drawing.Size(259, 37);
            this.lblRevenueNote.TabIndex = 2;
            this.lblRevenueNote.Text = "ℹ  Admin earns 10% of each confirmed booking\'s rent. The table below shows per-bo" +
    "oking breakdown.";
            this.lblRevenueNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRevenueNote.Click += new System.EventHandler(this.LblRevenueNote_Click);
            // 
            // panelRevenueSummary
            // 
            this.panelRevenueSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(255)))), ((int)(((byte)(251)))));
            this.panelRevenueSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRevenueSummary.Location = new System.Drawing.Point(0, 62);
            this.panelRevenueSummary.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelRevenueSummary.Name = "panelRevenueSummary";
            this.panelRevenueSummary.Padding = new System.Windows.Forms.Padding(20, 12, 20, 12);
            this.panelRevenueSummary.Size = new System.Drawing.Size(259, 135);
            this.panelRevenueSummary.TabIndex = 1;
            // 
            // toolbarRevenue
            // 
            this.toolbarRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(245)))));
            this.toolbarRevenue.Controls.Add(this.btnRefreshRevenue);
            this.toolbarRevenue.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbarRevenue.Location = new System.Drawing.Point(0, 0);
            this.toolbarRevenue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.toolbarRevenue.Name = "toolbarRevenue";
            this.toolbarRevenue.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.toolbarRevenue.Size = new System.Drawing.Size(259, 62);
            this.toolbarRevenue.TabIndex = 0;
            // 
            // btnRefreshRevenue
            // 
            this.btnRefreshRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(150)))), ((int)(((byte)(120)))));
            this.btnRefreshRevenue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshRevenue.FlatAppearance.BorderSize = 0;
            this.btnRefreshRevenue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshRevenue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefreshRevenue.ForeColor = System.Drawing.Color.White;
            this.btnRefreshRevenue.Location = new System.Drawing.Point(14, 12);
            this.btnRefreshRevenue.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnRefreshRevenue.Name = "btnRefreshRevenue";
            this.btnRefreshRevenue.Size = new System.Drawing.Size(133, 44);
            this.btnRefreshRevenue.TabIndex = 0;
            this.btnRefreshRevenue.Text = "🔄 Refresh";
            this.btnRefreshRevenue.UseVisualStyleBackColor = false;
            this.btnRefreshRevenue.Click += new System.EventHandler(this.BtnRefreshRevenue_Click);
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1600, 923);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.panelHeader);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1327, 728);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvRevenue)).EndInit();
            this.toolbarRevenue.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

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
