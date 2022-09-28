using Case_Parking_Microservices.Repositories;
using Case_Parking_Microservices.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Case_Parking_Microservices.Common.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void AddDependencyInjections(this IServiceCollection services)
        {
            services.AddScoped<IParkingService, ParkingService>();
            services.AddScoped<IParkingRepository, ParkingRepository>();
            services.AddSingleton<IParkingSpotService, ParkingSpotService>();
            services.AddScoped<IMotorAPIService, MotorAPIService>();
            services.AddScoped<ISmsService, SmsService>();
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}
