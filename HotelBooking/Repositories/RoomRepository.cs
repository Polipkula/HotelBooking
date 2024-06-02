using HotelBookingApp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace HotelBookingApp.Repositories
{
    public class RoomRepository
    {
        private readonly string connectionString;

        public RoomRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Room> GetAllRooms()
        {
            List<Room> rooms = new List<Room>();
            string query = "SELECT * FROM Rooms";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Room room = new Room
                        {
                            RoomId = Convert.ToInt32(reader["RoomId"]),
                            RoomNumber = reader["RoomNumber"].ToString(),
                            Status = reader["Status"].ToString(),
                            OccupiedUntil = reader["OccupiedUntil"] as DateTime?
                        };
                        rooms.Add(room);
                    }
                }
            }
            return rooms;
        }

        public void UpdateRoomStatus(int roomId, string status, DateTime? occupiedUntil = null)
        {
            string query = "UPDATE Rooms SET Status = @Status, OccupiedUntil = @OccupiedUntil WHERE RoomId = @RoomId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoomId", roomId);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@OccupiedUntil", (object)occupiedUntil ?? DBNull.Value);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void CheckAndUpdateRoomStatuses()
        {
            string query = "UPDATE Rooms SET Status = 'Unoccupied', OccupiedUntil = NULL WHERE Status IN ('Booked', 'Occupied') AND OccupiedUntil < CURDATE()";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Room> GetUnoccupiedRooms()
        {
            List<Room> unoccupiedRooms = new List<Room>();
            string query = "SELECT DISTINCT RoomId, RoomNumber, Status, OccupiedUntil FROM Rooms WHERE Status = 'Unoccupied'";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Room room = new Room
                        {
                            RoomId = Convert.ToInt32(reader["RoomId"]),
                            RoomNumber = reader["RoomNumber"].ToString(),
                            Status = reader["Status"].ToString(),
                            OccupiedUntil = reader.IsDBNull(reader.GetOrdinal("OccupiedUntil")) ? (DateTime?)null : reader.GetDateTime("OccupiedUntil")
                        };
                        unoccupiedRooms.Add(room);
                    }
                }
            }
            return unoccupiedRooms;
        }

    }
}
