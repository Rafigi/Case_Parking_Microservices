using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Case_Parking_Microservices.Common.Exceptions;
using Case_Parking_Microservices.Common.SettingsModels;
using Case_Parking_Microservices.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Case_Parking_Microservices.Services
{
    public class MotorAPIService : IMotorAPIService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOptions<MotorApiSettings> _motorApiSettings;

        public MotorAPIService(IHttpClientFactory httpClientFactory, IOptions<MotorApiSettings> motorApiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _motorApiSettings = motorApiSettings;
        }

        public async Task<CarDescription> GetDescriptionAsync(string licensePlate)
        {
            string url = $"https://v1.motorapi.dk/vehicles/{licensePlate}";
            string key = _motorApiSettings.Value.MotorApiKey;

            using (var c = _httpClientFactory.CreateClient())
            {
                c.DefaultRequestHeaders.Accept.Clear();
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                c.DefaultRequestHeaders.Add("x-auth-token", key);
                var result = await c.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var content = result.Content.ReadAsStringAsync().Result;
                    CarType? car = JsonConvert.DeserializeObject<CarType>(content);

                    if (car != null)
                    {
                        return new()
                        {
                            Make = car.make,
                            Model = car.model,
                            Variant = car.variant
                        };
                    }

                    return CarDescription.NONE;

                }

                if (result.StatusCode == HttpStatusCode.NotFound)
                {
                    return CarDescription.NONE;
                }
                else
                {
                    throw new MotorApiException(result.StatusCode, result.Content);
                }
            }

        }
    }
}
