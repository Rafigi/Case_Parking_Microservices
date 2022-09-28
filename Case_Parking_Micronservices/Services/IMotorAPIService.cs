using System.Threading.Tasks;
using Case_Parking_Microservices.Models;

namespace Case_Parking_Microservices.Services
{
    public interface IMotorAPIService
    {
        public Task<CarDescription> GetDescriptionAsync(string licensePlate);
    }
}
