using RentACarAPP.Domain.Entity;
using RentACarAPP.Domain.Repository;
using RentACarAPP.Persistance.DBContext;

namespace RentACarAPP.Persistance.Repository
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(RentACarDB context) : base(context)
        {

        }

        public async Task<bool> UploadImgAsync(int id, string filePath)
        {
            var brand = await _context.Brands.FindAsync(id);

            if (brand == null)
            {
                return false;
            }
            brand.LogoUrl = filePath;
            _context.Brands.Update(brand);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
