using Microsoft.Extensions.DependencyInjection;
using RentACarAPP.Domain.Repository;
using RentACarAPP.Persistance.Repository;

namespace RentACarAPP.Persistance.Extensions
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepositoryRegistration(this IServiceCollection services)
        {

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IBrandRepository, BrandRepository>();

            return services;
        }
    }
}
