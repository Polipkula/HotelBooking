using System;
using System.Windows.Forms;
using HotelBookingApp.Models;
using HotelBookingApp.Payment;
using HotelBookingApp.Repositories;

namespace HotelBookingApp.Forms
{
    public partial class PaymentForm : Form
    {
        private readonly string connectionString;
        private readonly Booking booking;

        public PaymentForm(string connectionString, Booking booking)
        {
            this.connectionString = connectionString;
            this.booking = booking;
            InitializeComponent();
        }

        private void BtnPay_Click(object sender, EventArgs e)
        {
            // Process payment
            PaymentGateway paymentGateway = new PaymentGateway();
            bool paymentSuccessful = paymentGateway.ProcessPayment(booking.RoomId); // Replace with actual amount

            if (paymentSuccessful)
            {
                // Update booking status to paid
                booking.IsPaid = true;
                BookingRepository bookingRepository = new BookingRepository(connectionString);
                bookingRepository.BookRoom(booking);

                MessageBox.Show("Payment successful!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Payment failed. Please try again.");
            }
        }
    }
}
