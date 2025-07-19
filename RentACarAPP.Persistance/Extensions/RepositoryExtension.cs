using Microsoft.Extensions.DependencyInjection;
using RentACarAPP.Domain.Entity;
using RentACarAPP.Domain.Repository;
using RentACarAPP.Persistance.Repository;

namespace RentACarAPP.Persistance.Extensions
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepositoryRegistration(this IServiceCollection services)
        {

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddSingleton<IGenericRepository<LogData>, GenericRepository<LogData>>();

            //services.AddSingleton<ILogDataRepository, LogDataRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();  

            return services;
        }
    }
}
