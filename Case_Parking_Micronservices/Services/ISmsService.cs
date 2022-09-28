using System.Threading.Tasks;

namespace Case_Parking_Microservices.Services
{
    public interface ISmsService
    {
        public Task<bool> SendMessageAsync(string message);

    }
}
