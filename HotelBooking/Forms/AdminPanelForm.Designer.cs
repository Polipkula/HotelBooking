namespace HotelBookingApp.Forms
{
    partial class AdminPanelForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnCreateAdmin = new System.Windows.Forms.Button();
            this.txtNewAdminUsername = new System.Windows.Forms.TextBox();
            this.txtNewAdminPassword = new System.Windows.Forms.TextBox();
            this.lblNewAdminUsername = new System.Windows.Forms.Label();
            this.lblNewAdminPassword = new System.Windows.Forms.Label();
            this.lvRooms = new System.Windows.Forms.ListView();
            this.columnRoomNumber = new System.Windows.Forms.ColumnHeader();
            this.columnStatus = new System.Windows.Forms.ColumnHeader();
            this.columnOccupiedUntil = new System.Windows.Forms.ColumnHeader();
            this.columnOccupant = new System.Windows.Forms.ColumnHeader();
            this.btnRefreshRooms = new System.Windows.Forms.Button();
            this.cbRoomSelect = new System.Windows.Forms.ComboBox();
            this.cbStatusSelect = new System.Windows.Forms.ComboBox();
            this.cbDay = new System.Windows.Forms.ComboBox();
            this.cbMonth = new System.Windows.Forms.ComboBox();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.lblOccupiedUntil = new System.Windows.Forms.Label();
            this.btnChangeStatus = new System.Windows.Forms.Button();
            this.hiddenLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCreateAdmin
            // 
            this.btnCreateAdmin.Location = new System.Drawing.Point(110, 130);
            this.btnCreateAdmin.Name = "btnCreateAdmin";
            this.btnCreateAdmin.Size = new System.Drawing.Size(150, 23);
            this.btnCreateAdmin.TabIndex = 0;
            this.btnCreateAdmin.Text = "Create Admin User";
            this.btnCreateAdmin.UseVisualStyleBackColor = true;
            this.btnCreateAdmin.Click += new System.EventHandler(this.BtnCreateAdmin_Click);
            // 
            // txtNewAdminUsername
            // 
            this.txtNewAdminUsername.Location = new System.Drawing.Point(110, 50);
            this.txtNewAdminUsername.Name = "txtNewAdminUsername";
            this.txtNewAdminUsername.Size = new System.Drawing.Size(150, 20);
            this.txtNewAdminUsername.TabIndex = 1;
            // 
            // txtNewAdminPassword
            // 
            this.txtNewAdminPassword.Location = new System.Drawing.Point(110, 90);
            this.txtNewAdminPassword.Name = "txtNewAdminPassword";
            this.txtNewAdminPassword.PasswordChar = '*';
            this.txtNewAdminPassword.Size = new System.Drawing.Size(150, 20);
            this.txtNewAdminPassword.TabIndex = 2;
            // 
            // lblNewAdminUsername
            // 
            this.lblNewAdminUsername.AutoSize = true;
            this.lblNewAdminUsername.Location = new System.Drawing.Point(30, 53);
            this.lblNewAdminUsername.Name = "lblNewAdminUsername";
            this.lblNewAdminUsername.Size = new System.Drawing.Size(58, 13);
            this.lblNewAdminUsername.TabIndex = 3;
            this.lblNewAdminUsername.Text = "Username:";
            // 
            // lblNewAdminPassword
            // 
            this.lblNewAdminPassword.AutoSize = true;
            this.lblNewAdminPassword.Location = new System.Drawing.Point(30, 93);
            this.lblNewAdminPassword.Name = "lblNewAdminPassword";
            this.lblNewAdminPassword.Size = new System.Drawing.Size(56, 13);
            this.lblNewAdminPassword.TabIndex = 4;
            this.lblNewAdminPassword.Text = "Password:";
            // 
            // lvRooms
            // 
            this.lvRooms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnRoomNumber,
            this.columnStatus,
            this.columnOccupiedUntil,
            this.columnOccupant});
            this.lvRooms.FullRowSelect = true;
            this.lvRooms.GridLines = true;
            this.lvRooms.Location = new System.Drawing.Point(30, 170);
            this.lvRooms.Name = "lvRooms";
            this.lvRooms.Size = new System.Drawing.Size(500, 200);
            this.lvRooms.TabIndex = 5;
            this.lvRooms.UseCompatibleStateImageBehavior = false;
            this.lvRooms.View = System.Windows.Forms.View.Details;
            // 
            // columnRoomNumber
            // 
            this.columnRoomNumber.Text = "Room Number";
            this.columnRoomNumber.Width = 100;
            // 
            // columnStatus
            // 
            this.columnStatus.Text = "Status";
            this.columnStatus.Width = 100;
            // 
            // columnOccupiedUntil
            // 
            this.columnOccupiedUntil.Text = "Occupied Until";
            this.columnOccupiedUntil.Width = 100;
            // 
            // columnOccupant
            // 
            this.columnOccupant.Text = "Occupant";
            this.columnOccupant.Width = 150;
            // 
            // btnRefreshRooms
            // 
            this.btnRefreshRooms.Location = new System.Drawing.Point(250, 130);
            this.btnRefreshRooms.Name = "btnRefreshRooms";
            this.btnRefreshRooms.Size = new System.Drawing.Size(80, 23);
            this.btnRefreshRooms.TabIndex = 6;
            this.btnRefreshRooms.Text = "Refresh Rooms";
            this.btnRefreshRooms.UseVisualStyleBackColor = true;
            this.btnRefreshRooms.Click += new System.EventHandler(this.BtnRefreshRooms_Click);
            // 
            // cbRoomSelect
            // 
            this.cbRoomSelect.FormattingEnabled = true;
            this.cbRoomSelect.Location = new System.Drawing.Point(30, 380);
            this.cbRoomSelect.Name = "cbRoomSelect";
            this.cbRoomSelect.Size = new System.Drawing.Size(121, 21);
            this.cbRoomSelect.TabIndex = 7;
            // 
            // cbStatusSelect
            // 
            this.cbStatusSelect.FormattingEnabled = true;
            this.cbStatusSelect.Items.AddRange(new object[] {
            "Unoccupied",
            "Occupied",
            "Booked"});
            this.cbStatusSelect.Location = new System.Drawing.Point(160, 380);
            this.cbStatusSelect.Name = "cbStatusSelect";
            this.cbStatusSelect.Size = new System.Drawing.Size(121, 21);
            this.cbStatusSelect.TabIndex = 8;
            // 
            // cbDay
            // 
            this.cbDay.FormattingEnabled = true;
            this.cbDay.Location = new System.Drawing.Point(290, 380);
            this.cbDay.Name = "cbDay";
            this.cbDay.Size = new System.Drawing.Size(40, 21);
            this.cbDay.TabIndex = 9;
            // 
            // cbMonth
            // 
            this.cbMonth.FormattingEnabled = true;
            this.cbMonth.Location = new System.Drawing.Point(340, 380);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(40, 21);
            this.cbMonth.TabIndex = 10;
            // 
            // cbYear
            // 
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Location = new System.Drawing.Point(390, 380);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(60, 21);
            this.cbYear.TabIndex = 11;
            // 
            // lblOccupiedUntil
            // 
            this.lblOccupiedUntil.AutoSize = true;
            this.lblOccupiedUntil.Location = new System.Drawing.Point(290, 365);
            this.lblOccupiedUntil.Name = "lblOccupiedUntil";
            this.lblOccupiedUntil.Size = new System.Drawing.Size(79, 13);
            this.lblOccupiedUntil.TabIndex = 12;
            this.lblOccupiedUntil.Text = "Occupied Until:";
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.Location = new System.Drawing.Point(460, 379);
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Size = new System.Drawing.Size(100, 23);
            this.btnChangeStatus.TabIndex = 13;
            this.btnChangeStatus.Text = "Change Status";
            this.btnChangeStatus.UseVisualStyleBackColor = true;
            this.btnChangeStatus.Click += new System.EventHandler(this.BtnChangeStatus_Click);
            // 
            // hiddenLabel
            // 
            this.hiddenLabel.AutoSize = true;
            this.hiddenLabel.Location = new System.Drawing.Point(10, 10);
            this.hiddenLabel.Name = "hiddenLabel";
            this.hiddenLabel.Size = new System.Drawing.Size(0, 13);
            this.hiddenLabel.TabIndex = 14;
            this.hiddenLabel.Visible = false;
            // 
            // AdminPanelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 420);
            this.Controls.Add(this.hiddenLabel);
            this.Controls.Add(this.btnChangeStatus);
            this.Controls.Add(this.lblOccupiedUntil);
            this.Controls.Add(this.cbYear);
            this.Controls.Add(this.cbMonth);
            this.Controls.Add(this.cbDay);
            this.Controls.Add(this.cbStatusSelect);
            this.Controls.Add(this.cbRoomSelect);
            this.Controls.Add(this.btnRefreshRooms);
            this.Controls.Add(this.lvRooms);
            this.Controls.Add(this.lblNewAdminPassword);
            this.Controls.Add(this.lblNewAdminUsername);
            this.Controls.Add(this.txtNewAdminPassword);
            this.Controls.Add(this.txtNewAdminUsername);
            this.Controls.Add(this.btnCreateAdmin);
            this.Name = "AdminPanelForm";
            this.Text = "Admin Panel";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnCreateAdmin;
        private System.Windows.Forms.TextBox txtNewAdminUsername;
        private System.Windows.Forms.TextBox txtNewAdminPassword;
        private System.Windows.Forms.Label lblNewAdminUsername;
        private System.Windows.Forms.Label lblNewAdminPassword;
        private System.Windows.Forms.ListView lvRooms;
        private System.Windows.Forms.ColumnHeader columnRoomNumber;
        private System.Windows.Forms.ColumnHeader columnStatus;
        private System.Windows.Forms.ColumnHeader columnOccupiedUntil;
        private System.Windows.Forms.ColumnHeader columnOccupant;
        private System.Windows.Forms.Button btnRefreshRooms;
        private System.Windows.Forms.ComboBox cbRoomSelect;
        private System.Windows.Forms.ComboBox cbStatusSelect;
        private System.Windows.Forms.ComboBox cbDay;
        private System.Windows.Forms.ComboBox cbMonth;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.Label lblOccupiedUntil;
        private System.Windows.Forms.Button btnChangeStatus;
        private System.Windows.Forms.Label hiddenLabel;
    }
}
