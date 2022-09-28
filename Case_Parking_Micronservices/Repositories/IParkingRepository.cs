using System.Collections.Generic;
using System.Threading.Tasks;
using Case_Parking_Microservices.Models;

namespace Case_Parking_Microservices.Repositories
{
    public interface IParkingRepository
    {
        Task<bool> DeleteAllRegistrationByLicensePlateAsync(string licenseplate);
        Task<bool> RegisterParkingAsync(Parking parking);
        Task<bool> IsCarRegistratedAsync(string licenseplate);
        public Task<List<ParkingSpot>> GetAllTakenParkingSpot();
    }
}
