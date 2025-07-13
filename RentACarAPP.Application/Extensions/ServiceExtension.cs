using Microsoft.Extensions.DependencyInjection;
using RentACarAPP.Application.Services;
using RentACarAPP.Contract.Services;

namespace RentACarAPP.Application.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));

            services.AddScoped<IBrandService, BrandService>();
            services.AddSingleton<ILogDataService, LogDataService>();
            return services;
        }
    }
}
