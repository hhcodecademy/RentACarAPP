using RentACarAPP.Contract.Dtos.Paging;
using RentACarAPP.Domain.Entity;

namespace RentACarAPP.Contract.Services
{
    public interface IGenericService<TEntity, TDto> where TEntity : BaseEntity, new() where TDto : class
    {
        Task<TDto> GetByIdAsync(int id);
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> AddAsync(TDto entity);
        Task<TDto> UpdateAsync(TDto entity);
        Task<bool> DeleteAsync(int id);
        Task<PageResponseDto<TDto>> GetAllPagedAsync(PagedOptionDTO option);
    }
}
