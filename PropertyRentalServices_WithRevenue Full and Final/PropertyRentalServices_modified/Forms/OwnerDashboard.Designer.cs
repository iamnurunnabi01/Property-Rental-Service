namespace PropertyRentalServices.Forms
{
    partial class OwnerDashboard
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
            this.panelStats = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabManage = new System.Windows.Forms.TabPage();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.formPanel = new System.Windows.Forms.Panel();
            this.btnPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtBedrooms = new System.Windows.Forms.TextBox();
            this.lblBedrooms = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvProperties = new System.Windows.Forms.DataGridView();
            this.tabEarnings = new System.Windows.Forms.TabPage();
            this.dgvBookings = new System.Windows.Forms.DataGridView();
            this.lblEarningsNote = new System.Windows.Forms.Label();
            this.panelEarnSummary = new System.Windows.Forms.Panel();
            this.toolbarEarnings = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRefreshEarnings = new System.Windows.Forms.Button();
            this.tabOffers = new System.Windows.Forms.TabPage();
            this.dgvOffers = new System.Windows.Forms.DataGridView();
            this.toolbarOffers = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddOffer = new System.Windows.Forms.Button();
            this.btnDeleteOffer = new System.Windows.Forms.Button();
            this.btnRefreshOffers = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabManage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.formPanel.SuspendLayout();
            this.btnPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProperties)).BeginInit();
            this.tabEarnings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).BeginInit();
            this.toolbarEarnings.SuspendLayout();
            this.tabOffers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOffers)).BeginInit();
            this.toolbarOffers.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(20, 150, 120);
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
            this.lblHeaderTitle.Text = "🏠  Owner Dashboard";
            this.lblHeaderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(200, 80, 50);
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
            this.panelStats.BackColor = System.Drawing.Color.FromArgb(245, 248, 245);
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStats.Height = 90;
            this.panelStats.Name = "panelStats";
            this.panelStats.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.panelStats.Size = new System.Drawing.Size(1200, 90);
            this.panelStats.TabIndex = 1;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.tabControl);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(10);
            this.panelMain.TabIndex = 2;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabManage);
            this.tabControl.Controls.Add(this.tabEarnings);
            this.tabControl.Controls.Add(this.tabOffers);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.TabIndex = 0;
            // 
            // tabManage
            // 
            this.tabManage.BackColor = System.Drawing.Color.White;
            this.tabManage.Controls.Add(this.splitContainer);
            this.tabManage.Name = "tabManage";
            this.tabManage.Text = "🏡  Manage Properties";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.splitContainer.SplitterDistance = 320;
            this.splitContainer.TabIndex = 0;
            // 
            // splitContainer.Panel1 (form)
            // 
            this.splitContainer.Panel1.Controls.Add(this.formPanel);
            // 
            // formPanel
            // 
            this.formPanel.BackColor = System.Drawing.Color.White;
            this.formPanel.Controls.Add(this.lblTitle);
            this.formPanel.Controls.Add(this.txtTitle);
            this.formPanel.Controls.Add(this.lblLocation);
            this.formPanel.Controls.Add(this.txtLocation);
            this.formPanel.Controls.Add(this.lblPrice);
            this.formPanel.Controls.Add(this.txtPrice);
            this.formPanel.Controls.Add(this.lblBedrooms);
            this.formPanel.Controls.Add(this.txtBedrooms);
            this.formPanel.Controls.Add(this.lblStatus);
            this.formPanel.Controls.Add(this.cmbStatus);
            this.formPanel.Controls.Add(this.lblDescription);
            this.formPanel.Controls.Add(this.txtDescription);
            this.formPanel.Controls.Add(this.btnPanel);
            this.formPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formPanel.Name = "formPanel";
            this.formPanel.Padding = new System.Windows.Forms.Padding(15);
            this.formPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblTitle.Location = new System.Drawing.Point(15, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Property Title";
            // 
            // txtTitle
            // 
            this.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTitle.Location = new System.Drawing.Point(15, 32);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(280, 28);
            this.txtTitle.TabIndex = 1;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLocation.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblLocation.Location = new System.Drawing.Point(15, 70);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.TabIndex = 2;
            this.lblLocation.Text = "Location";
            // 
            // txtLocation
            // 
            this.txtLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLocation.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLocation.Location = new System.Drawing.Point(15, 92);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(280, 28);
            this.txtLocation.TabIndex = 3;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblPrice.Location = new System.Drawing.Point(15, 130);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "Price per Night (৳)";
            // 
            // txtPrice
            // 
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrice.Location = new System.Drawing.Point(15, 152);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(280, 28);
            this.txtPrice.TabIndex = 5;
            // 
            // lblBedrooms
            // 
            this.lblBedrooms.AutoSize = true;
            this.lblBedrooms.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBedrooms.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblBedrooms.Location = new System.Drawing.Point(15, 190);
            this.lblBedrooms.Name = "lblBedrooms";
            this.lblBedrooms.TabIndex = 6;
            this.lblBedrooms.Text = "Bedrooms";
            // 
            // txtBedrooms
            // 
            this.txtBedrooms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBedrooms.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBedrooms.Location = new System.Drawing.Point(15, 212);
            this.txtBedrooms.Name = "txtBedrooms";
            this.txtBedrooms.Size = new System.Drawing.Size(280, 28);
            this.txtBedrooms.TabIndex = 7;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblStatus.Location = new System.Drawing.Point(15, 250);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStatus.Items.AddRange(new object[] { "Available", "Booked", "Unavailable" });
            this.cmbStatus.Location = new System.Drawing.Point(15, 272);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(280, 28);
            this.cmbStatus.TabIndex = 9;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblDescription.Location = new System.Drawing.Point(15, 310);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescription.Location = new System.Drawing.Point(15, 332);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(280, 70);
            this.txtDescription.TabIndex = 11;
            // 
            // btnPanel
            // 
            this.btnPanel.Controls.Add(this.btnAdd);
            this.btnPanel.Controls.Add(this.btnUpdate);
            this.btnPanel.Controls.Add(this.btnDelete);
            this.btnPanel.Controls.Add(this.btnClear);
            this.btnPanel.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.btnPanel.Location = new System.Drawing.Point(15, 412);
            this.btnPanel.Name = "btnPanel";
            this.btnPanel.Size = new System.Drawing.Size(290, 45);
            this.btnPanel.TabIndex = 12;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(20, 150, 120);
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.btnAdd.Size = new System.Drawing.Size(60, 34);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            this.btnAdd.Text = "➕ Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(30, 100, 200);
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.btnUpdate.Size = new System.Drawing.Size(76, 34);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            this.btnUpdate.Text = "✏️ Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(200, 50, 50);
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.btnDelete.Size = new System.Drawing.Size(72, 34);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            this.btnDelete.Text = "🗑 Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Gray;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Margin = new System.Windows.Forms.Padding(3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.btnClear.Size = new System.Drawing.Size(62, 34);
            this.btnClear.TabIndex = 3;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            this.btnClear.Text = "✖ Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.FlatAppearance.BorderSize = 0;
            // 
            // splitContainer.Panel2 (grid)
            // 
            this.splitContainer.Panel2.Controls.Add(this.dgvProperties);
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
            this.dgvProperties.TabIndex = 0;
            this.dgvProperties.SelectionChanged += new System.EventHandler(this.DgvProperties_SelectionChanged);
            this.dgvProperties.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(20, 150, 120);
            this.dgvProperties.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvProperties.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvProperties.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 255, 250);
            // 
            // tabEarnings
            // 
            this.tabEarnings.BackColor = System.Drawing.Color.White;
            this.tabEarnings.Controls.Add(this.dgvBookings);
            this.tabEarnings.Controls.Add(this.lblEarningsNote);
            this.tabEarnings.Controls.Add(this.panelEarnSummary);
            this.tabEarnings.Controls.Add(this.toolbarEarnings);
            this.tabEarnings.Name = "tabEarnings";
            this.tabEarnings.Text = "💰  Earnings";
            // 
            // toolbarEarnings
            // 
            this.toolbarEarnings.BackColor = System.Drawing.Color.FromArgb(255, 250, 240);
            this.toolbarEarnings.Controls.Add(this.btnRefreshEarnings);
            this.toolbarEarnings.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbarEarnings.Height = 50;
            this.toolbarEarnings.Name = "toolbarEarnings";
            this.toolbarEarnings.Padding = new System.Windows.Forms.Padding(5);
            this.toolbarEarnings.TabIndex = 0;
            // 
            // btnRefreshEarnings
            // 
            this.btnRefreshEarnings.BackColor = System.Drawing.Color.FromArgb(200, 100, 0);
            this.btnRefreshEarnings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshEarnings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshEarnings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefreshEarnings.ForeColor = System.Drawing.Color.White;
            this.btnRefreshEarnings.Margin = new System.Windows.Forms.Padding(5);
            this.btnRefreshEarnings.Name = "btnRefreshEarnings";
            this.btnRefreshEarnings.Size = new System.Drawing.Size(100, 36);
            this.btnRefreshEarnings.TabIndex = 0;
            this.btnRefreshEarnings.Click += new System.EventHandler(this.BtnRefreshEarnings_Click);
            this.btnRefreshEarnings.Text = "🔄 Refresh";
            this.btnRefreshEarnings.UseVisualStyleBackColor = false;
            this.btnRefreshEarnings.FlatAppearance.BorderSize = 0;
            // 
            // panelEarnSummary
            // 
            this.panelEarnSummary.BackColor = System.Drawing.Color.FromArgb(255, 252, 245);
            this.panelEarnSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEarnSummary.Height = 100;
            this.panelEarnSummary.Name = "panelEarnSummary";
            this.panelEarnSummary.Padding = new System.Windows.Forms.Padding(15, 8, 15, 8);
            this.panelEarnSummary.TabIndex = 1;
            // 
            // lblEarningsNote
            // 
            this.lblEarningsNote.BackColor = System.Drawing.Color.FromArgb(255, 253, 230);
            this.lblEarningsNote.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEarningsNote.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblEarningsNote.ForeColor = System.Drawing.Color.FromArgb(90, 90, 90);
            this.lblEarningsNote.Height = 28;
            this.lblEarningsNote.Name = "lblEarningsNote";
            this.lblEarningsNote.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblEarningsNote.TabIndex = 2;
            this.lblEarningsNote.Text = "ℹ  Admin platform fee is 10% of each confirmed booking. Your net revenue = Total Rent − 10%.";
            this.lblEarningsNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.dgvBookings.TabIndex = 3;
            this.dgvBookings.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(20, 150, 120);
            this.dgvBookings.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBookings.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvBookings.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 255, 250);
            // 
            // tabOffers
            // 
            this.tabOffers.BackColor = System.Drawing.Color.White;
            this.tabOffers.Controls.Add(this.dgvOffers);
            this.tabOffers.Controls.Add(this.toolbarOffers);
            this.tabOffers.Name = "tabOffers";
            this.tabOffers.Text = "🎁  My Offers";
            // 
            // toolbarOffers
            // 
            this.toolbarOffers.BackColor = System.Drawing.Color.FromArgb(250, 240, 255);
            this.toolbarOffers.Controls.Add(this.btnAddOffer);
            this.toolbarOffers.Controls.Add(this.btnDeleteOffer);
            this.toolbarOffers.Controls.Add(this.btnRefreshOffers);
            this.toolbarOffers.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbarOffers.Height = 50;
            this.toolbarOffers.Name = "toolbarOffers";
            this.toolbarOffers.Padding = new System.Windows.Forms.Padding(5);
            this.toolbarOffers.TabIndex = 0;
            // 
            // btnAddOffer
            // 
            this.btnAddOffer.BackColor = System.Drawing.Color.FromArgb(150, 50, 200);
            this.btnAddOffer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddOffer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddOffer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddOffer.ForeColor = System.Drawing.Color.White;
            this.btnAddOffer.Margin = new System.Windows.Forms.Padding(3);
            this.btnAddOffer.Name = "btnAddOffer";
            this.btnAddOffer.Size = new System.Drawing.Size(100, 34);
            this.btnAddOffer.TabIndex = 0;
            this.btnAddOffer.Click += new System.EventHandler(this.BtnAddOffer_Click);
            this.btnAddOffer.Text = "➕ Add Offer";
            this.btnAddOffer.UseVisualStyleBackColor = false;
            this.btnAddOffer.FlatAppearance.BorderSize = 0;
            // 
            // btnDeleteOffer
            // 
            this.btnDeleteOffer.BackColor = System.Drawing.Color.FromArgb(200, 50, 50);
            this.btnDeleteOffer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteOffer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteOffer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeleteOffer.ForeColor = System.Drawing.Color.White;
            this.btnDeleteOffer.Margin = new System.Windows.Forms.Padding(3);
            this.btnDeleteOffer.Name = "btnDeleteOffer";
            this.btnDeleteOffer.Size = new System.Drawing.Size(110, 34);
            this.btnDeleteOffer.TabIndex = 1;
            this.btnDeleteOffer.Click += new System.EventHandler(this.BtnDeleteOffer_Click);
            this.btnDeleteOffer.Text = "🗑 Delete Offer";
            this.btnDeleteOffer.UseVisualStyleBackColor = false;
            this.btnDeleteOffer.FlatAppearance.BorderSize = 0;
            // 
            // btnRefreshOffers
            // 
            this.btnRefreshOffers.BackColor = System.Drawing.Color.Gray;
            this.btnRefreshOffers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshOffers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshOffers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefreshOffers.ForeColor = System.Drawing.Color.White;
            this.btnRefreshOffers.Margin = new System.Windows.Forms.Padding(3);
            this.btnRefreshOffers.Name = "btnRefreshOffers";
            this.btnRefreshOffers.Size = new System.Drawing.Size(100, 34);
            this.btnRefreshOffers.TabIndex = 2;
            this.btnRefreshOffers.Click += new System.EventHandler(this.BtnRefreshOffers_Click);
            this.btnRefreshOffers.Text = "🔄 Refresh";
            this.btnRefreshOffers.UseVisualStyleBackColor = false;
            this.btnRefreshOffers.FlatAppearance.BorderSize = 0;
            // 
            // dgvOffers
            // 
            this.dgvOffers.AllowUserToAddRows = false;
            this.dgvOffers.AllowUserToDeleteRows = false;
            this.dgvOffers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOffers.BackgroundColor = System.Drawing.Color.White;
            this.dgvOffers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOffers.ColumnHeadersHeight = 38;
            this.dgvOffers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOffers.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvOffers.GridColor = System.Drawing.Color.FromArgb(230, 235, 245);
            this.dgvOffers.Name = "dgvOffers";
            this.dgvOffers.ReadOnly = true;
            this.dgvOffers.RowHeadersVisible = false;
            this.dgvOffers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOffers.TabIndex = 1;
            this.dgvOffers.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(20, 150, 120);
            this.dgvOffers.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvOffers.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvOffers.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 255, 250);
            // 
            // OwnerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 248, 245);
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.panelHeader);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "OwnerDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Owner Dashboard - Property Rental Services";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OwnerDashboard_FormClosed);
            this.panelHeader.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabManage.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.formPanel.ResumeLayout(false);
            this.formPanel.PerformLayout();
            this.btnPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProperties)).EndInit();
            this.tabEarnings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).EndInit();
            this.toolbarEarnings.ResumeLayout(false);
            this.tabOffers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOffers)).EndInit();
            this.toolbarOffers.ResumeLayout(false);
            this.lblBedrooms.Click += new System.EventHandler(this.LblBedrooms_Click);
            this.lblDescription.Click += new System.EventHandler(this.LblDescription_Click);
            this.lblEarningsNote.Click += new System.EventHandler(this.LblEarningsNote_Click);
            this.lblHeaderTitle.Click += new System.EventHandler(this.LblHeaderTitle_Click);
            this.lblLocation.Click += new System.EventHandler(this.LblLocation_Click);
            this.lblPrice.Click += new System.EventHandler(this.LblPrice_Click);
            this.lblStatus.Click += new System.EventHandler(this.LblStatus_Click);
            this.lblTitle.Click += new System.EventHandler(this.LblTitle_Click);
            this.txtBedrooms.Enter += new System.EventHandler(this.TxtBedrooms_Enter);
            this.txtBedrooms.TextChanged += new System.EventHandler(this.TxtBedrooms_TextChanged);
            this.txtDescription.Enter += new System.EventHandler(this.TxtDescription_Enter);
            this.txtDescription.TextChanged += new System.EventHandler(this.TxtDescription_TextChanged);
            this.txtLocation.Enter += new System.EventHandler(this.TxtLocation_Enter);
            this.txtLocation.TextChanged += new System.EventHandler(this.TxtLocation_TextChanged);
            this.txtPrice.Enter += new System.EventHandler(this.TxtPrice_Enter);
            this.txtPrice.TextChanged += new System.EventHandler(this.TxtPrice_TextChanged);
            this.txtTitle.Enter += new System.EventHandler(this.TxtTitle_Enter);
            this.txtTitle.TextChanged += new System.EventHandler(this.TxtTitle_TextChanged);
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.CmbStatus_SelectedIndexChanged);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabManage;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblBedrooms;
        private System.Windows.Forms.TextBox txtBedrooms;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.FlowLayoutPanel btnPanel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvProperties;
        private System.Windows.Forms.TabPage tabEarnings;
        private System.Windows.Forms.FlowLayoutPanel toolbarEarnings;
        private System.Windows.Forms.Button btnRefreshEarnings;
        private System.Windows.Forms.Panel panelEarnSummary;
        private System.Windows.Forms.Label lblEarningsNote;
        private System.Windows.Forms.DataGridView dgvBookings;
        private System.Windows.Forms.TabPage tabOffers;
        private System.Windows.Forms.FlowLayoutPanel toolbarOffers;
        private System.Windows.Forms.Button btnAddOffer;
        private System.Windows.Forms.Button btnDeleteOffer;
        private System.Windows.Forms.Button btnRefreshOffers;
        private System.Windows.Forms.DataGridView dgvOffers;
        // Earnings summary labels populated at runtime via BuildEarnCard
        private System.Windows.Forms.Label lblEarnTotal;
        private System.Windows.Forms.Label lblEarnDeduct;
        private System.Windows.Forms.Label lblEarnNet;
    }
}
