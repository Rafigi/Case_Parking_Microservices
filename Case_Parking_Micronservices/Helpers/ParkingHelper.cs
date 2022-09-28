using Case_Parking_Microservices.DTOs;
using Case_Parking_Microservices.Models;

namespace Case_Parking_Microservices.Helpers
{
    public static class ParkingHelper
    {
        public static bool IsLicensePlateValid(string licensePlate) => ControlLicensePlate(licensePlate);
        public static bool IsLicensePlateValid(this ParkingDto parkingDto) => ControlLicensePlate(parkingDto.LicensePlate);
        public static bool IsLicensePlateValid(this Parking parking) => ControlLicensePlate(parking.LicensePlate);


        private static bool ControlLicensePlate(string licensePlate)
        {
            var licensePlateTrim = licensePlate.Trim();

            if (licensePlateTrim.Length != 7)
                return false;

            if (int.TryParse(licensePlateTrim.Substring(2, 2), out int output)
                && int.TryParse(licensePlateTrim.Substring(4, 3), out int output2))
                return true;

            return false;
        }
    }
}
