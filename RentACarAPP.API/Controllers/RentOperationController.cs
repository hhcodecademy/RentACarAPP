using Microsoft.AspNetCore.Mvc;
using RentACarAPP.Contract.Services;

namespace RentACarAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentOperationController : ControllerBase
    {
        private readonly ICarService _carService;
        public RentOperationController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpGet("rent")]
        public async Task<IActionResult> RentACar(string name)
        {
            var result = await _carService.RentACarAsync(name);
            return Ok(result);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddCar(string name, int year)
        {
            var result = await _carService.AddCarAsync(name, year);
            return Ok(result);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var result = await _carService.GetAllCarsAsync();
            return Ok(result);
        }

    }
}
