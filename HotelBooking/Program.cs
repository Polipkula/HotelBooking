using System;
using System.Windows.Forms;
using HotelBookingApp.Forms;
using HotelBookingApp.Repositories;

namespace HotelBookingApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Set up your MySQL database connection string
            string connectionString = "Server=localhost;Database=hoteldb;User Id=root;Password=root;";

            // Ensure default admin user exists
            var userRepository = new UserRepository(connectionString);
            userRepository.EnsureDefaultAdmin();

            // Start the application by showing the login form
            Application.Run(new LoginForm(connectionString));
        }
    }
}
