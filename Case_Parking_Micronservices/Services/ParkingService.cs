using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Case_Parking_Microservices.DTOs;
using Case_Parking_Microservices.Helpers;
using Case_Parking_Microservices.Models;
using Case_Parking_Microservices.Repositories;

namespace Case_Parking_Microservices.Services
{
    public class ParkingService : IParkingService
    {
        private readonly IParkingRepository _parkingRepository;
        private readonly IParkingSpotService _parkingSpotService;
        private readonly ISmsService _smsService;
        private readonly IEmailService _emailService;

        public ParkingService(IParkingRepository parkingRepository, IParkingSpotService parkingSpotService, ISmsService smsService, IEmailService emailService)
        {
            _parkingRepository = parkingRepository;
            _parkingSpotService = parkingSpotService;
            _smsService = smsService;
            _emailService = emailService;
        }
        public async Task<string> DeleteAllRegistrationByLicensePlate(string licensePlate)
        {
            if (ParkingHelper.IsLicensePlateValid(licensePlate) == false)
                return "Your license Plate is not valid";

            if (await _parkingRepository.DeleteAllRegistrationByLicensePlateAsync(licensePlate))
            {
                string message = $"Your registration with license Plate {licensePlate}, has been deleted";
                bool isSent = await _smsService.SendMessageAsync(message);
                //bool isSent = await _emailService.SendEmailAsync(message);

                if (isSent)
                    return "Your license Plate has been delete from the system";
            }

            return "Something happen, the har are not register";
        }

        public async Task<List<ParkingSpot>> SeeAllAvailableParkingSpots()
        {
            var allTakenParkingSpots = await _parkingRepository.GetAllTakenParkingSpot();

            if (allTakenParkingSpots.Any() == false)
                return _parkingSpotService.AllParkingSpots();

            return _parkingSpotService
                .AllParkingSpots()
                .Where(p => allTakenParkingSpots.Any((ParkingSpot s) => s.Id != p.Id))
                .ToList();
        }

        public async Task<string> IsCarRegistered(string licensePlate)
        {
            if (ParkingHelper.IsLicensePlateValid(licensePlate) == false)
                return "Your license Plate is not valid";

            if (await _parkingRepository.IsCarRegistratedAsync(licensePlate))
                return "Your license Plate Is Registered";

            return "Something went wrong";
        }

        public async Task<string> RegisterParking(ParkingDto parkingDto)
        {
            int? parkingSpotId = _parkingSpotService.GetParkingSpotId(parkingDto.Level, parkingDto.StallNumber);
            if (parkingDto.IsLicensePlateValid() == false)
                return "Your license Plate is not valid";

            if (parkingSpotId.HasValue == false)
                return "None Parking spot exist, by the entered value!";

            Parking parking = new Parking()
            {
                ParkingId = 0,
                Email = parkingDto.Email,
                LicensePlate = parkingDto.LicensePlate,
                MobilNumber = parkingDto.MobilNumber,
                TimeStamp = DateTime.Now,
                ParkingSpotId = parkingSpotId.Value
            };

            bool hasBeenSuccessfullyRegister = await _parkingRepository.RegisterParkingAsync(parking);
            if (hasBeenSuccessfullyRegister)
            {
                string message = $"Your Car with license Plate {parking.LicensePlate}, has been register"
                bool isSent = await _smsService.SendMessageAsync(message);
                //bool isSent = await _emailService.SendEmailAsync(message);
                if (isSent)
                    return "Your car has been register";
            }

            return "Something happen, the car are not register";
        }
    }
}
