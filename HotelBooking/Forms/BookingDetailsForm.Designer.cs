namespace HotelBookingApp.Forms
{
    partial class BookingDetailsForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.labelLastName = new System.Windows.Forms.Label();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.labelStayDuration = new System.Windows.Forms.Label();
            this.dateTimePickerStayUntil = new System.Windows.Forms.DateTimePicker();
            this.labelCost = new System.Windows.Forms.Label();
            this.textBoxCost = new System.Windows.Forms.TextBox();
            this.buttonCalculateCost = new System.Windows.Forms.Button();
            this.buttonBook = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Location = new System.Drawing.Point(12, 9);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(61, 13);
            this.labelLastName.TabIndex = 0;
            this.labelLastName.Text = "Last Name:";
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(15, 25);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(200, 20);
            this.textBoxLastName.TabIndex = 1;
            // 
            // labelStayDuration
            // 
            this.labelStayDuration.AutoSize = true;
            this.labelStayDuration.Location = new System.Drawing.Point(12, 48);
            this.labelStayDuration.Name = "labelStayDuration";
            this.labelStayDuration.Size = new System.Drawing.Size(64, 13);
            this.labelStayDuration.TabIndex = 2;
            this.labelStayDuration.Text = "Stay Until:";
            // 
            // dateTimePickerStayUntil
            // 
            this.dateTimePickerStayUntil.Location = new System.Drawing.Point(15, 64);
            this.dateTimePickerStayUntil.Name = "dateTimePickerStayUntil";
            this.dateTimePickerStayUntil.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerStayUntil.TabIndex = 3;
            // 
            // labelCost
            // 
            this.labelCost.AutoSize = true;
            this.labelCost.Location = new System.Drawing.Point(12, 87);
            this.labelCost.Name = "labelCost";
            this.labelCost.Size = new System.Drawing.Size(34, 13);
            this.labelCost.TabIndex = 4;
            this.labelCost.Text = "Cost:";
            // 
            // textBoxCost
            // 
            this.textBoxCost.Location = new System.Drawing.Point(15, 103);
            this.textBoxCost.Name = "textBoxCost";
            this.textBoxCost.Size = new System.Drawing.Size(200, 20);
            this.textBoxCost.TabIndex = 5;
            // 
            // buttonCalculateCost
            // 
            this.buttonCalculateCost.Location = new System.Drawing.Point(15, 129);
            this.buttonCalculateCost.Name = "buttonCalculateCost";
            this.buttonCalculateCost.Size = new System.Drawing.Size(200, 23);
            this.buttonCalculateCost.TabIndex = 6;
            this.buttonCalculateCost.Text = "Calculate Cost";
            this.buttonCalculateCost.UseVisualStyleBackColor = true;
            this.buttonCalculateCost.Click += new System.EventHandler(this.buttonCalculateCost_Click);
            // 
            // buttonBook
            // 
            this.buttonBook.Location = new System.Drawing.Point(15, 158);
            this.buttonBook.Name = "buttonBook";
            this.buttonBook.Size = new System.Drawing.Size(200, 23);
            this.buttonBook.TabIndex = 7;
            this.buttonBook.Text = "Book";
            this.buttonBook.UseVisualStyleBackColor = true;
            this.buttonBook.Click += new System.EventHandler(this.buttonBook_Click);
            // 
            // BookingDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 191);
            this.Controls.Add(this.buttonBook);
            this.Controls.Add(this.buttonCalculateCost);
            this.Controls.Add(this.textBoxCost);
            this.Controls.Add(this.labelCost);
            this.Controls.Add(this.dateTimePickerStayUntil);
            this.Controls.Add(this.labelStayDuration);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.labelLastName);
            this.Name = "BookingDetailsForm";
            this.Text = "Booking Details";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.Label labelStayDuration;
        private System.Windows.Forms.DateTimePicker dateTimePickerStayUntil;
        private System.Windows.Forms.Label labelCost;
        private System.Windows.Forms.TextBox textBoxCost;
        private System.Windows.Forms.Button buttonCalculateCost;
        private System.Windows.Forms.Button buttonBook;
    }
}
