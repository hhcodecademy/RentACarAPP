using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            return services;
        }

    }
}
