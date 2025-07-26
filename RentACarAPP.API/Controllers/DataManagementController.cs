using Microsoft.AspNetCore.Mvc;
using RentACarAPP.Contract.Services;

namespace RentACarAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataManagementController : ControllerBase
    {
        private readonly IProductExternalService _productExternalService;

        public DataManagementController(IProductExternalService productExternalService)
        {
            _productExternalService = productExternalService;
        }

        [HttpGet]
        public async Task<IActionResult> InitializeProducts()
        {
            try
            {
                var products = await _productExternalService.GetAllProductsAsync();
                if (products == null )
                {
                    return NotFound("No products found.");
                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving products: {ex.Message}");
            }
        }

    }
}
