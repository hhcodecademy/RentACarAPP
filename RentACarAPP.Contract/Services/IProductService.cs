using RentACarAPP.Contract.Dtos;
using RentACarAPP.Contract.Dtos.Paging;
using RentACarAPP.Domain.Entity;

namespace RentACarAPP.Contract.Services
{
    public interface IProductService : IGenericService<Product, ProductDTO>
    {
        Task<PagedProductDTO> GetAllPagedAsync(PagedOptionDTO option);
    }
}
