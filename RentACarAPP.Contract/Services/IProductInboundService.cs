using Refit;
using RentACarAPP.Contract.Dtos.External;

namespace RentACarAPP.Contract.Services
{
    public interface IProductInboundService
    {

        [Get("/products")]
        Task<Rootobject> GetAllProductsAsync();
    }
}
