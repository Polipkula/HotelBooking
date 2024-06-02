using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HotelBookingApp.Models;

namespace HotelBookingApp.Repositories
{
    public class BookingRepository
    {
        private readonly string connectionString;

        public BookingRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool BookRoom(Booking booking)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string bookingQuery = "INSERT INTO Bookings (RoomId, CheckInDate, CheckOutDate, IsPaid, LastName, Cost) VALUES (@RoomId, @CheckInDate, @CheckOutDate, @IsPaid, @LastName, @Cost)";
                string updateRoomStatusQuery = "UPDATE Rooms SET Status = 'Occupied', OccupiedUntil = @CheckOutDate WHERE RoomId = @RoomId";

                using (MySqlCommand bookingCommand = new MySqlCommand(bookingQuery, connection))
                using (MySqlCommand updateRoomStatusCommand = new MySqlCommand(updateRoomStatusQuery, connection))
                {
                    bookingCommand.Parameters.AddWithValue("@RoomId", booking.RoomId);
                    bookingCommand.Parameters.AddWithValue("@CheckInDate", booking.CheckInDate);
                    bookingCommand.Parameters.AddWithValue("@CheckOutDate", booking.CheckOutDate);
                    bookingCommand.Parameters.AddWithValue("@IsPaid", booking.IsPaid);
                    bookingCommand.Parameters.AddWithValue("@LastName", booking.LastName);
                    bookingCommand.Parameters.AddWithValue("@Cost", booking.Cost);

                    updateRoomStatusCommand.Parameters.AddWithValue("@RoomId", booking.RoomId);
                    updateRoomStatusCommand.Parameters.AddWithValue("@CheckOutDate", booking.CheckOutDate);

                    connection.Open();
                    MySqlTransaction transaction = connection.BeginTransaction();
                    bookingCommand.Transaction = transaction;
                    updateRoomStatusCommand.Transaction = transaction;

                    try
                    {
                        bookingCommand.ExecuteNonQuery();
                        updateRoomStatusCommand.ExecuteNonQuery();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public List<Booking> GetCurrentBookings()
        {
            List<Booking> bookings = new List<Booking>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT Id, RoomId, CheckInDate, CheckOutDate, IsPaid, LastName, Cost FROM Bookings WHERE CheckOutDate >= @CurrentDate";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CurrentDate", DateTime.Now.Date);

                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Booking booking = new Booking
                            {
                                Id = reader.GetInt32("Id"),
                                RoomId = reader.GetInt32("RoomId"),
                                CheckInDate = reader.GetDateTime("CheckInDate"),
                                CheckOutDate = reader.GetDateTime("CheckOutDate"),
                                IsPaid = reader.GetBoolean("IsPaid"),
                                LastName = reader.GetString("LastName"),
                                Cost = Convert.ToDouble(reader.GetDecimal("Cost"))
                            };
                            bookings.Add(booking);
                        }
                    }
                }
            }

            return bookings;
        }
    }
}
