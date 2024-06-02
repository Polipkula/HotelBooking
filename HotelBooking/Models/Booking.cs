using System;

namespace HotelBookingApp.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public bool IsPaid { get; set; }
        public string LastName { get; set; }
        public double Cost { get; set; }
    }
}
