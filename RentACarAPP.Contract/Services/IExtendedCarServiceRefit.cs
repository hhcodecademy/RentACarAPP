using Refit;
using RentACarAPP.Contract.Dtos.External;

namespace RentACarAPP.Contract.Services
{
    public interface IExtendedCarServiceRefit
    {
        [Get("/cars/{id}")]
        Task<CarExternalDto> GetCarByIdAsync(int id);
        [Get("/cars")]
        Task<List<CarExternalDto>> GetAllCarsAsync();
        [Post("/cars")]
        Task<CarExternalDto> AddCarAsync(CarExternalDto carDto);
    }
}
