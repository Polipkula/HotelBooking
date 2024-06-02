using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HotelBookingApp.Models;
using HotelBookingApp.Repositories;

namespace HotelBookingApp.Forms
{
    public partial class UserDashboardForm : Form
    {
        private readonly int userId;
        private readonly BookingRepository bookingRepository;
        private readonly RoomRepository roomRepository;
        private readonly string connectionString;

        public UserDashboardForm(string connectionString, int userId)
        {
            this.connectionString = connectionString;
            this.userId = userId;
            bookingRepository = new BookingRepository(connectionString);
            roomRepository = new RoomRepository(connectionString);
            InitializeComponent();
            DisplayUnoccupiedRooms();
        }

        private void DisplayUnoccupiedRooms()
        {
            List<Room> unoccupiedRooms = roomRepository.GetUnoccupiedRooms().Distinct().ToList();
            listBoxRooms.DataSource = null; // Clear the data source
            listBoxRooms.Items.Clear(); // Ensure items are cleared
            listBoxRooms.DataSource = unoccupiedRooms;
            listBoxRooms.DisplayMember = "RoomNumber";
        }

        private void buttonBook_Click(object sender, EventArgs e)
        {
            if (listBoxRooms.SelectedItem != null)
            {
                Room selectedRoom = (Room)listBoxRooms.SelectedItem;

                using (BookingDetailsForm bookingDetailsForm = new BookingDetailsForm())
                {
                    if (bookingDetailsForm.ShowDialog() == DialogResult.OK)
                    {
                        string lastName = bookingDetailsForm.LastName;
                        DateTime checkOutDate = bookingDetailsForm.CheckOutDate;
                        double cost = bookingDetailsForm.Cost;

                        Booking newBooking = new Booking
                        {
                            RoomId = selectedRoom.RoomId,
                            CheckInDate = DateTime.Now.Date,
                            CheckOutDate = checkOutDate,
                            IsPaid = false,
                            LastName = lastName,
                            Cost = cost
                        };

                        // Perform booking
                        bool bookingSuccess = bookingRepository.BookRoom(newBooking);

                        if (bookingSuccess)
                        {
                            MessageBox.Show($"Room {selectedRoom.RoomNumber} booked successfully!");
                            // After booking, refresh the list of unoccupied rooms
                            DisplayUnoccupiedRooms();
                        }
                        else
                        {
                            MessageBox.Show("Failed to book the room. Please try again later.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a room to book.");
            }
        }
    }
}
