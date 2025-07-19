using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using RentACarAPP.Contract.Dtos.External;
using RentACarAPP.Contract.Services;

namespace RentACarAPP.Infrastructure.Services
{
    public class ExternalCarService : IExternalCarService
    {
        private readonly HttpClient _httpClient;

        public ExternalCarService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CarExternalDto> AddCarAsync(CarExternalDto carDto)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7269/api/Cars", carDto);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<CarExternalDto>();
            }
            else
            {
                throw new Exception("Failed to add car.");
            }

        }

        public async Task<List<CarExternalDto>> GetAllCarsAsync()
        {
            var datas = await _httpClient.GetFromJsonAsync<List<CarExternalDto>>("https://localhost:7269/api/Cars");
            if (datas == null || !datas.Any())
            {
                throw new Exception("No cars found.");
            }
            return datas;
        }

        public Task<CarExternalDto> GetCarByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
