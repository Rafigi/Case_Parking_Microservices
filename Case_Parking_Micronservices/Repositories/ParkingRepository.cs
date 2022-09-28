using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Case_Parking_Microservices.Data;
using Case_Parking_Microservices.Models;
using Microsoft.EntityFrameworkCore;

namespace Case_Parking_Microservices.Repositories
{
    public class ParkingRepository : IParkingRepository
    {
        private readonly DataContext _dataContext;

        public ParkingRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> DeleteAllRegistrationByLicensePlateAsync(string licensePlate)
        {
            var founded = await _dataContext.Parkings
                .Where(p => p.LicensePlate == licensePlate)
                .ToListAsync();

            _dataContext.RemoveRange(founded);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> IsCarRegistratedAsync(string licensePlate)
        {
            return await _dataContext.Parkings
                .AnyAsync(p => p.LicensePlate == licensePlate);
        }

        public async Task<List<ParkingSpot>> GetAllTakenParkingSpot()
        {
            return await _dataContext.Parkings.Select(p => new ParkingSpot()
            {
                Id = p.ParkingSpotId,
            }).ToListAsync();
        }

        public async Task<bool> RegisterParkingAsync(Parking parking)
        {
            // Simulate autoincrement in database.
            int? lastId = (await _dataContext.Parkings.OrderBy(p => p.ParkingId).LastOrDefaultAsync())?.ParkingId;
            if (lastId == null)
            {
                parking.ParkingId = 1;
            }
            else
            {
                parking.ParkingId = lastId.Value + 1;
            }
            await _dataContext.Parkings.AddAsync(parking);
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
