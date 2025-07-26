using AutoMapper;
using RentACarAPP.Contract.Dtos;
using RentACarAPP.Contract.Dtos.Paging;
using RentACarAPP.Contract.Services;
using RentACarAPP.Domain.Entity;
using RentACarAPP.Domain.Repository;

namespace RentACarAPP.Application.Services
{
    public class ProductService(
        IGenericRepository<Product> repository,
        IMapper mapper,
        IUnitOfWork unitOfWork)

        : GenericService<Product, ProductDTO>(repository, mapper, unitOfWork), IProductService
    {

        public async Task<PagedProductDTO> GetAllPagedAsync(PagedOptionDTO option)
        {
            var query = await _repository.GetAllAsync();
            var totalCount = query.Count();
            var items = query
                .Skip((option.PageNumber - 1) * option.PageSize)
                .Take(option.PageSize)
                .ToList();
            var pagedDto= new PagedProductDTO
            {
                TotalCount = totalCount,
                PageNumber = option.PageNumber,
                PageSize = items.Count,
                TotalPages = (int)Math.Ceiling((double)totalCount / option.PageSize),
                Products = _mapper.Map<List<ProductDTO>>(items)
            };
            return pagedDto;
        }
    }

}
