using AutoMapper;
using FluentValidation;
using RentACarAPP.Contract.Services;
using RentACarAPP.Domain.Entity;
using RentACarAPP.Domain.Repository;

namespace RentACarAPP.Application.Services
{
    public class GenericService<TEntity, TDto> : IGenericService<TEntity, TDto>
   where TEntity : BaseEntity, new()
   where TDto : class
    {
        protected readonly IGenericRepository<TEntity> _repository;
        private readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        public GenericService(IGenericRepository<TEntity> repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var datas = await _repository.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<TDto>>(datas);
            return dtos;
        }

        public async Task<TDto> GetByIdAsync(int id)
        {
            var data = await _repository.GetByIdAsync(id);
            if (data == null)
            {
                return null;
            }
            var dto = _mapper.Map<TDto>(data);
            return dto;
        }

        public async Task<TDto> AddAsync(TDto dto)
        {
           
            var entity = _mapper.Map<TEntity>(dto);
            var addedData = await _repository.AddAsync(entity);
            var reponseDto = _mapper.Map<TDto>(addedData);
            await _unitOfWork.SaveChangesAsync();
            return reponseDto;
        }

        public async Task<TDto> UpdateAsync(TDto entity)
        {
            var data = _mapper.Map<TEntity>(entity);
            var updatedData = await _repository.UpdateAsync(data);
            var dto = _mapper.Map<TDto>(updatedData);
            await _unitOfWork.SaveChangesAsync();
            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
