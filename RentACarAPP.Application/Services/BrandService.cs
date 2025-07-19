using AutoMapper;
using RentACarAPP.Application.Exceptions;
using RentACarAPP.Application.Validotor;
using RentACarAPP.Contract.Dtos;
using RentACarAPP.Contract.Services;
using RentACarAPP.Domain.Entity;
using RentACarAPP.Domain.Repository;

namespace RentACarAPP.Application.Services
{
    public class BrandService : GenericService<Brand, BrandDTO>, IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BrandService(IBrandRepository repository, IMapper mapper, IUnitOfWork unitOfWork) : base(repository, mapper, unitOfWork)
        {
            _brandRepository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<BrandResponseDto>> GetAllAsync()
        {
            var brands = await _brandRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BrandResponseDto>>(brands);
        }

        public async Task<BrandResponseDto> GetByIdAsync(int id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);
            if (brand == null)
            {
                return null;
            }
            return _mapper.Map<BrandResponseDto>(brand);
        }


        public async Task<bool> UploadImgAsync(int id, string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new BadRequestException("File path cannot be null or empty.");
            }
            var brand = await _brandRepository.GetByIdAsync(id);
            if (brand == null)
            {
                throw new NotFoundException($"Brand with ID {id} not found.");
            }

            var isUploaded = await _brandRepository.UploadImgAsync(id, filePath);
            if (!isUploaded)
            {
                throw new Exception("Image upload failed.");
            }
            brand.LogoUrl = filePath;
            var updatedBrand = await _brandRepository.UpdateAsync(brand);
            return true;

        }
    }
}
