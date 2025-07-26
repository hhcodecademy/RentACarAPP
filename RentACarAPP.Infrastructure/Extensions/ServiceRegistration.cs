using Microsoft.Extensions.DependencyInjection;
using Refit;
using RentACarAPP.Contract.Services;
using RentACarAPP.Infrastructure.Services;

namespace RentACarAPP.Infrastructure.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddHttpClient<IExternalCarService, ExternalCarService>();
            services.AddRefitClient<IExtendedCarServiceRefit>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7269/api"));

            services.AddRefitClient<IProductInboundService>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://dummyjson.com");
            });


            return services;
        }

    }
}
