using System.Collections.Generic;
using Case_Parking_Microservices.Models;

namespace Case_Parking_Microservices.Services
{
    public interface IParkingSpotService
    {
        public List<ParkingSpot> AllParkingSpots();
        int? GetParkingSpotId(int level, string stallNumber);
    }
}
