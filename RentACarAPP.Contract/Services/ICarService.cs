using RentACarAPP.Contract.Dtos.External;

namespace RentACarAPP.Contract.Services
{
    public interface ICarService
    {
        Task<string> RentACarAsync(string name);
        Task<string> AddCarAsync(string name, int year);
        Task<List<CarExternalDto>> GetAllCarsAsync();
    }
}
