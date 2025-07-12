using RentACarAPP.Contract.Dtos;
using RentACarAPP.Domain.Entity;

namespace RentACarAPP.Contract.Services
{
    public interface IBrandService : IGenericService<Brand, BrandDTO>
    {
        public Task<bool> UploadImgAsync(int id, string filePath);
        public Task<BrandResponseDto> GetByIdAsync(int id);
        public Task<IEnumerable<BrandResponseDto>> GetAllAsync();
    }
}
