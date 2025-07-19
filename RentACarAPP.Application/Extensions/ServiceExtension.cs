using Microsoft.Extensions.DependencyInjection;
using RentACarAPP.Application.Services;
using RentACarAPP.Contract.Dtos;
using RentACarAPP.Contract.Services;
using RentACarAPP.Domain.Entity;

namespace RentACarAPP.Application.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));
            services.AddSingleton<IGenericService<LogData,LogDataDTO>, GenericService<LogData,LogDataDTO>>();
            services.AddScoped<ICarService, CarService>();
            

            services.AddScoped<IBrandService, BrandService>();
            //services.AddSingleton<ILogDataService, LogDataService>();
            return services;
        }
    }
}
