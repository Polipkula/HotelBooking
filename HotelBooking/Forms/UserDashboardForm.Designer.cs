// UserDashboardForm.Designer.cs
namespace HotelBookingApp.Forms
{
    partial class UserDashboardForm
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
            this.listBoxRooms = new System.Windows.Forms.ListBox();
            this.buttonBook = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxRooms
            // 
            this.listBoxRooms.FormattingEnabled = true;
            this.listBoxRooms.Location = new System.Drawing.Point(12, 12);
            this.listBoxRooms.Name = "listBoxRooms";
            this.listBoxRooms.Size = new System.Drawing.Size(150, 225);
            this.listBoxRooms.TabIndex = 0;
            // 
            // buttonBook
            // 
            this.buttonBook.Location = new System.Drawing.Point(168, 12);
            this.buttonBook.Name = "buttonBook";
            this.buttonBook.Size = new System.Drawing.Size(75, 23);
            this.buttonBook.TabIndex = 1;
            this.buttonBook.Text = "Book";
            this.buttonBook.UseVisualStyleBackColor = true;
            this.buttonBook.Click += new System.EventHandler(this.buttonBook_Click);
            // 
            // UserDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 251);
            this.Controls.Add(this.buttonBook);
            this.Controls.Add(this.listBoxRooms);
            this.Name = "UserDashboardForm";
            this.Text = "User Dashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxRooms;
        private System.Windows.Forms.Button buttonBook;
    }
}
