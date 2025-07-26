using RentACarAPP.Contract.Dtos.External;
using RentACarAPP.Contract.Services;

namespace RentACarAPP.Application.Services
{
    public class CarService : ICarService
    {
        private readonly IExtendedCarServiceRefit _externalCarService;

        public CarService(IExtendedCarServiceRefit externalCarService)
        {
            _externalCarService = externalCarService;
        }

        public async Task<string> AddCarAsync(string name, int year)
        {
            var carDto = new CarExternalDto
            {
                Model = name,
                Year = year
            };
            var addedCar = await _externalCarService.AddCarAsync(carDto);
            return addedCar != null
                ? $"Car {addedCar.Model} added successfully with Id: {addedCar.Id}."
                : "Failed to add the car.";
        }

        public async Task<string> RentACarAsync(string name)
        {
            var cars = await _externalCarService.GetAllCarsAsync();
            if (cars == null || !cars.Any())
            {
                return "No cars available for rent.";
            }
            var car = cars.FirstOrDefault(c => c.Model.Equals(name, StringComparison.OrdinalIgnoreCase));
            return car != null
                ? $"Car {car.Model} is available for rent."
                : $"Car {name} is not available for rent.";
        }

        public async Task<List<CarExternalDto>> GetAllCarsAsync()
        {
            var cars = await _externalCarService.GetAllCarsAsync();
            var carList = cars ?? new List<CarExternalDto>();
            return carList;
        }
    }
}
