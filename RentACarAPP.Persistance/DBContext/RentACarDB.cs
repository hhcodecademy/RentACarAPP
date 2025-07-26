using Microsoft.EntityFrameworkCore;
using RentACarAPP.Domain.Entity;

namespace RentACarAPP.Persistance.DBContext
{
    public class RentACarDB : DbContext
    {
        public RentACarDB(DbContextOptions<RentACarDB> options) : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarDocument> Documents { get; set; }
        public DbSet<LogData> Logs { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
