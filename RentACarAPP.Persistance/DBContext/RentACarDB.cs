using Microsoft.EntityFrameworkCore;
using RentACarAPP.Domain.Entity;

namespace RentACarAPP.Persistance.DBContext
{
    public class RentACarDB : DbContext
    {
        public RentACarDB(DbContextOptions<RentACarDB> options) : base(options)
        {
        }

        // DbSet properties for your entities
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarDocument> Documents { get; set; }
        // Add other DbSets as needed
    }
}
