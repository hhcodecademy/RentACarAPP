using AutoMapper;
using RentACarAPP.Contract.Dtos.External;
using RentACarAPP.Contract.Services;
using RentACarAPP.Domain.Entity;
using RentACarAPP.Domain.Repository;

namespace RentACarAPP.Application.Services
{
    public class ProductExternalService : GenericService<Product, ProductInboundDto>, IProductExternalService
    {
        private readonly IProductInboundService _productInboundService;


        public ProductExternalService(IProductInboundService productInboundService, IGenericRepository<Product> repository, IMapper mapper, IUnitOfWork unitOfWork)
            : base(repository, mapper, unitOfWork)
        {
            _productInboundService = productInboundService;
        }
        public async Task<List<Product>> GetAllProductsAsync()
        {
            var productRoot = await _productInboundService.GetAllProductsAsync();
            var productList = new List<Product>();
            foreach (var product in productRoot.Products)
            {
                var productEntity = _mapper.Map<Product>(product);
                await _repository.AddAsync(productEntity);
                productList.Add(productEntity);
                await _unitOfWork.SaveChangesAsync();
            }

            return productList;

        }
    }
}
