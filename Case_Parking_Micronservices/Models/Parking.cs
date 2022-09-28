using System;

namespace Case_Parking_Microservices.Models
{
    public class Parking
    {
        public int ParkingId { get; set; }
        public string LicensePlate { get; set; }
        public DateTime TimeStamp { get; set; }
        public string MobilNumber { get; set; }
        public string Email { get; set; }
        public int ParkingSpotId { get; set; }
    }
}
