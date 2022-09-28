using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Case_Parking_Microservices.Common.SettingsModels;
using Case_Parking_Microservices.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Case_Parking_Microservices.Services
{
    public class SmsService : ISmsService
    {
        private readonly IOptions<SmsServiceSettings> _smsServiceOptions;
        private readonly IHttpClientFactory _httpClientFactory;

        public SmsService(IOptions<SmsServiceSettings> smsServiceOptions, IHttpClientFactory httpClientFactory)
        {
            _smsServiceOptions = smsServiceOptions;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<bool> SendMessageAsync(string message)
        {
            string url = _smsServiceOptions.Value.Url;
            string key = _smsServiceOptions.Value.Key;
            string phoneNumber = _smsServiceOptions.Value.PhoneNumber;

            using (var c = _httpClientFactory.CreateClient())
            {
                c.DefaultRequestHeaders.Accept.Clear();
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var sms = new SmsModel()
                {
                    key = int.Parse(key),
                    message = message,
                    receiver = phoneNumber
                };
                var jsonObject = JsonConvert.SerializeObject(sms);
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
