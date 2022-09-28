using System.Collections.Generic;
using Case_Parking_Microservices.Models;

namespace Case_Parking_Microservices.Data
{
    public static class MockDataFactory
    {
        public static List<ParkingSpot> CreateParkingSpotList()
        {
            List<ParkingSpot> parkingSpots = new List<ParkingSpot>();
            int id = 1;
            // Level
            for (int level = 0; level < 3; level++)
            {
                // Stalls
                for (int stallNumber = 1; stallNumber <= 15; stallNumber++)
                {
                    parkingSpots.Add(new ParkingSpot()
                    {
                        Id = id,
                        Level = level,
                        StallNumber = stallNumber.ToString()
                    });
                    id++;
                }
            }
            return parkingSpots;
        }
    }
}
