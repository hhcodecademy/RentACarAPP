using RentACarAPP.Domain.Entity;

namespace RentACarAPP.Domain.Repository
{
    public interface IBrandRepository : IGenericRepository<Brand>
    {
        Task<bool> UploadImgAsync(int id, string filePath);
    }
}
