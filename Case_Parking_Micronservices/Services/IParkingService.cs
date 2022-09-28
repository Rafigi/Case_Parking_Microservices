using System.Collections.Generic;
using System.Threading.Tasks;
using Case_Parking_Microservices.DTOs;
using Case_Parking_Microservices.Models;

namespace Case_Parking_Microservices.Services
{
    public interface IParkingService
    {
        public Task<string> RegisterParking(ParkingDto parkingDto);
        public Task<string> IsCarRegistered(string licensePlate);
        public Task<string> DeleteAllRegistrationByLicensePlate(string licenseplate);
        public Task<List<ParkingSpot>> SeeAllAvailableParkingSpots();
    }
}
