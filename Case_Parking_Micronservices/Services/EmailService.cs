using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Case_Parking_Microservices.Common.SettingsModels;
using Case_Parking_Microservices.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Case_Parking_Microservices.Services
{
    public class EmailService : IEmailService
    {
        private readonly IOptions<EmailServiceSettings> _emailServiceOptions;
        private readonly IHttpClientFactory _httpClientFactory;

        public EmailService(IOptions<EmailServiceSettings> emailServiceOptions, IHttpClientFactory httpClientFactory)
        {
            _emailServiceOptions = emailServiceOptions;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> SendEmailAsync(string message)
        {
            string url = _emailServiceOptions.Value.EmailUrl;
            string receiver = _emailServiceOptions.Value.EmailReceiver;

            using (var c = _httpClientFactory.CreateClient())
            {
                c.DefaultRequestHeaders.Accept.Clear();
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Email email = new Email()
                {
                    subject = "Parking",
                    message = message,
                    receiver = receiver
                };
                var jsonObject = JsonConvert.SerializeObject(email);
                var t = new StringContent(jsonObject);
                var result = await c.PostAsync(url, t);
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
