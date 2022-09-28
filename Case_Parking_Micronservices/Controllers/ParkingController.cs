using System.Collections.Generic;
using System.Threading.Tasks;
using Case_Parking_Microservices.DTOs;
using Case_Parking_Microservices.Models;
using Case_Parking_Microservices.Services;
using Microsoft.AspNetCore.Mvc;

namespace Case_Parking_Microservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        private readonly IParkingService _parkingService;
        private readonly IMotorAPIService _motorApiService;

        public ParkingController(IParkingService parkingService, IMotorAPIService motorApiService)
        {
            _parkingService = parkingService;
            _motorApiService = motorApiService;
        }
        /// <summary>
        /// Register your car, and select your stall and level.
        /// There exist 3 levels, with 15 stall on each level.
        /// </summary>
        /// <param name="parkingDto"></param>
        /// <returns></returns>
        [HttpPost("registerParking")]
        public async Task<string> RegisterParking([FromBody] ParkingDto parkingDto)
        {
            return await _parkingService.RegisterParking(parkingDto);
        }

        /// <summary>
        /// Check that your car is registered
        /// </summary>
        /// <param name="licensePlate"></param>
        /// <returns></returns>
        [HttpPost("IsCarRegistered/{licensePlate}")]

        public async Task<string> IsCarRegistered(string licensePlate)
        {
            return await _parkingService.IsCarRegistered(licensePlate);
        }

        /// <summary>
        /// Remove all registration by your License Plate
        /// </summary>
        /// <param name="licensePlate"></param>
        /// <returns></returns>
        [HttpDelete("deleteAllRegistrations/{licensePlate}")]
        public async Task<string> DeleteAllRegistrations(string licensePlate)
        {
            return await _parkingService.DeleteAllRegistrationByLicensePlate(licensePlate);
        }

        /// <summary>
        /// See All Available ParkingSpots;
        /// </summary>
        [HttpGet("SeeAllAvailableParkingSpots")]
        public async Task<List<ParkingSpot>> SeeAllAvailableParkingSpots()
        {
            return await _parkingService.SeeAllAvailableParkingSpots();
        }

        /// <summary>
        /// Look car description up, by license Plate
        /// </summary>
        /// <param name="licensePlate"></param>
        /// <returns></returns>
        [HttpGet("GetCarDescription/{licensePlate}")]
        public async Task<CarDescription> SeeAllAvailableParkingSpots(string licensePlate)
        {
            return await _motorApiService.GetDescriptionAsync(licensePlate);
        }
    }
}
