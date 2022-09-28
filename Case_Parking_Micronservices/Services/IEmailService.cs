using System.Threading.Tasks;

namespace Case_Parking_Microservices.Services
{
    public interface IEmailService
    {
        public Task<bool> SendEmailAsync(string message);
    }
}
