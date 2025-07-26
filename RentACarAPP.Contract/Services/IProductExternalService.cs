using RentACarAPP.Contract.Dtos.External;
using RentACarAPP.Domain.Entity;

namespace RentACarAPP.Contract.Services
{
    public interface IProductExternalService : IGenericService<Product, ProductInboundDto>
    {
        Task<List<Product>> GetAllProductsAsync();


    }
}
