using System;

namespace HotelBookingApp.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public string Status { get; set; }
        public DateTime? OccupiedUntil { get; set; }
    }
}
