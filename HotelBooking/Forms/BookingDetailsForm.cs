using System;
using System.Windows.Forms;

namespace HotelBookingApp.Forms
{
    public partial class BookingDetailsForm : Form
    {
        public string LastName { get; private set; }
        public DateTime CheckOutDate { get; private set; }
        public double Cost { get; private set; }

        public BookingDetailsForm()
        {
            InitializeComponent();
        }

        private void buttonCalculateCost_Click(object sender, EventArgs e)
        {
            DateTime stayUntil = dateTimePickerStayUntil.Value;
            TimeSpan stayDuration = stayUntil - DateTime.Now;
            int stayDays = stayDuration.Days;
            if (stayDays < 0)
            {
                MessageBox.Show("Please select a valid date.");
                return;
            }
            double costPerDay = 100.0; // Example cost per day
            double totalCost = stayDays * costPerDay;
            textBoxCost.Text = totalCost.ToString("C");
        }

        private void buttonBook_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLastName.Text))
            {
                MessageBox.Show("Please enter a last name.");
                return;
            }

            LastName = textBoxLastName.Text;
            CheckOutDate = dateTimePickerStayUntil.Value;
            Cost = double.Parse(textBoxCost.Text, System.Globalization.NumberStyles.Currency);

            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
