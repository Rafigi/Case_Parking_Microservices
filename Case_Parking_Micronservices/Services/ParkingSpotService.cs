using System.Collections.Generic;
using System.Linq;
using Case_Parking_Microservices.Data;
using Case_Parking_Microservices.Models;

namespace Case_Parking_Microservices.Services
{
    public class ParkingSpotService : IParkingSpotService
    {
        private readonly List<ParkingSpot> _parkingSpots;

        public ParkingSpotService()
        {
            _parkingSpots = MockDataFactory.CreateParkingSpotList();
        }

        public List<ParkingSpot> AllParkingSpots()
        {
            return _parkingSpots;
        }

        public int? GetParkingSpotId(int level, string stallNumber)
        {
            return _parkingSpots
                .FirstOrDefault(p => p.Level == level && p.StallNumber == stallNumber)
                ?.Id;
        }
    }
}
