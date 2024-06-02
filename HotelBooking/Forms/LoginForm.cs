using System;
using System.Windows.Forms;
using HotelBookingApp.Repositories;
using HotelBookingApp.Models;
using MySql.Data.MySqlClient;

namespace HotelBookingApp.Forms
{
    public partial class LoginForm : Form
    {
        private readonly UserRepository userRepository;
        private readonly string connectionString;

        public LoginForm(string connectionString)
        {
            this.connectionString = connectionString;
            userRepository = new UserRepository(connectionString);
            InitializeComponent();
            TestDatabaseConnection();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Authenticate user
            var user = userRepository.Authenticate(username, password);
            if (user != null)
            {
                if (user.IsAdmin)
                {
                    // Open admin panel
                    var adminPanelForm = new AdminPanelForm(connectionString);
                    adminPanelForm.Show();
                }
                else
                {
                    // Open user dashboard
                    var userDashboardForm = new UserDashboardForm(connectionString, user.Id);
                    userDashboardForm.Show();
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }

        private void BtnGuest_Click(object sender, EventArgs e)
        {
            // Open user dashboard without login
            var userDashboardForm = new UserDashboardForm(connectionString, -1); // Assuming -1 indicates a guest user
            userDashboardForm.Show();
        }

        private void TestDatabaseConnection()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MessageBox.Show("Database connection successful!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection failed: " + ex.Message);
            }
        }
    }
}
