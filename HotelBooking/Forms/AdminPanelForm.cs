using System;
using System.Windows.Forms;
using HotelBookingApp.Repositories;
using HotelBookingApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace HotelBookingApp.Forms
{
    public partial class AdminPanelForm : Form
    {
        private readonly string connectionString;
        private readonly RoomRepository roomRepository;
        private readonly UserRepository userRepository;
        private readonly BookingRepository bookingRepository;

        public AdminPanelForm(string connectionString)
        {
            this.connectionString = connectionString;
            roomRepository = new RoomRepository(connectionString);
            userRepository = new UserRepository(connectionString);
            bookingRepository = new BookingRepository(connectionString);
            InitializeComponent();
            LoadRooms();
            PopulateRoomDropdown();
            PopulateDateDropdowns();
        }

        private void BtnCreateAdmin_Click(object sender, EventArgs e)
        {
            string username = txtNewAdminUsername.Text;
            string password = txtNewAdminPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            User adminUser = new User
            {
                Username = username,
                Password = password,
                IsAdmin = true
            };

            userRepository.CreateUser(adminUser);
            MessageBox.Show("Admin user created successfully!");
            hiddenLabel.Focus();
        }

        private void LoadRooms()
        {
            roomRepository.CheckAndUpdateRoomStatuses(); // Update room statuses based on current date
            List<Room> rooms = roomRepository.GetAllRooms();
            List<Booking> currentBookings = bookingRepository.GetCurrentBookings();

            lvRooms.Items.Clear();

            foreach (Room room in rooms)
            {
                var currentBooking = currentBookings.FirstOrDefault(b => b.RoomId == room.RoomId && b.CheckOutDate >= DateTime.Now);
                string occupantName = currentBooking != null ? currentBooking.LastName : "Unoccupied";

                ListViewItem item = new ListViewItem(room.RoomNumber);
                item.SubItems.Add(room.Status);
                item.SubItems.Add(room.OccupiedUntil?.ToString("yyyy-MM-dd") ?? "N/A");
                item.SubItems.Add(occupantName); // Add occupant name
                item.Tag = room;
                lvRooms.Items.Add(item);
            }
        }

        private void BtnRefreshRooms_Click(object sender, EventArgs e)
        {
            LoadRooms();
            PopulateRoomDropdown();
            hiddenLabel.Focus();
        }

        private void PopulateRoomDropdown()
        {
            cbRoomSelect.Items.Clear();
            List<Room> rooms = roomRepository.GetUnoccupiedRooms(); // Only get unoccupied rooms

            foreach (Room room in rooms)
            {
                cbRoomSelect.Items.Add(new ComboBoxItem { Text = room.RoomNumber, Value = room.RoomId });
            }

            if (cbRoomSelect.Items.Count > 0)
                cbRoomSelect.SelectedIndex = 0;
        }

        private void PopulateDateDropdowns()
        {
            // Populate days
            cbDay.Items.Clear();
            for (int day = 1; day <= 31; day++)
            {
                cbDay.Items.Add(day.ToString("D2"));
            }

            // Populate months
            cbMonth.Items.Clear();
            for (int month = 1; month <= 12; month++)
            {
                cbMonth.Items.Add(month.ToString("D2"));
            }

            // Populate years
            cbYear.Items.Clear();
            for (int year = DateTime.Now.Year; year <= DateTime.Now.Year + 10; year++)
            {
                cbYear.Items.Add(year.ToString());
            }
        }

        private void BtnChangeStatus_Click(object sender, EventArgs e)
        {
            if (cbRoomSelect.SelectedItem == null || cbStatusSelect.SelectedItem == null)
            {
                MessageBox.Show("Please select both a room and a status.");
                return;
            }

            ComboBoxItem selectedRoom = (ComboBoxItem)cbRoomSelect.SelectedItem;
            string newStatus = cbStatusSelect.SelectedItem.ToString();
            DateTime? occupiedUntil = null;

            if (newStatus == "Occupied" || newStatus == "Booked")
            {
                int day, month, year;
                if (int.TryParse(cbDay.SelectedItem?.ToString(), out day) &&
                    int.TryParse(cbMonth.SelectedItem?.ToString(), out month) &&
                    int.TryParse(cbYear.SelectedItem?.ToString(), out year))
                {
                    occupiedUntil = new DateTime(year, month, day);
                }
                else
                {
                    MessageBox.Show("Please select a valid date.");
                    return;
                }
            }

            roomRepository.UpdateRoomStatus(selectedRoom.Value, newStatus, occupiedUntil);
            MessageBox.Show("Room status updated successfully!");
            LoadRooms();
            hiddenLabel.Focus();
        }
    }

    public class ComboBoxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }
        public override string ToString()
        {
            return Text;
        }
    }
}
