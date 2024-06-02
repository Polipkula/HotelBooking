using HotelBookingApp.Models;
using MySql.Data.MySqlClient;
using System;

namespace HotelBookingApp.Repositories
{
    public class UserRepository
    {
        private readonly string connectionString;

        public UserRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public User Authenticate(string username, string password)
        {
            User user = null;
            string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    user = new User
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Username = reader["Username"].ToString(),
                        Password = reader["Password"].ToString(),
                        IsAdmin = Convert.ToBoolean(reader["IsAdmin"])
                    };
                }
            }

            return user;
        }

        public void CreateUser(User user)
        {
            string query = "INSERT INTO Users (Username, Password, IsAdmin) VALUES (@Username, @Password, @IsAdmin)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void EnsureDefaultAdmin()
        {
            string query = "SELECT COUNT(*) FROM Users WHERE IsAdmin = 1";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                int adminCount = Convert.ToInt32(command.ExecuteScalar());

                if (adminCount == 0)
                {
                    // No admin user exists, create the default admin
                    CreateUser(new User
                    {
                        Username = "admin",
                        Password = "admin123", // You may want to hash this password
                        IsAdmin = true
                    });
                }
            }
        }
    }
}
