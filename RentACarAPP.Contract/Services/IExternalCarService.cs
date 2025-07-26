using RentACarAPP.Contract.Dtos.External;

namespace RentACarAPP.Contract.Services
{
    public interface IExternalCarService
    {
        Task<CarExternalDto> GetCarByIdAsync(int id);
        Task<List<CarExternalDto>> GetAllCarsAsync();
        Task<CarExternalDto> AddCarAsync(CarExternalDto carDto);
    }
}
