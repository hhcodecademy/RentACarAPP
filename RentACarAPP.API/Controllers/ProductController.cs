using Microsoft.AspNetCore.Mvc;
using RentACarAPP.Contract.Dtos;
using RentACarAPP.Contract.Dtos.Paging;
using RentACarAPP.Contract.Services;

namespace RentACarAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("/paged/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetPagedProducts(int pageNumber, int pageSize)
        {
            var option = new PagedOptionDTO
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            var products = await _productService.GetAllPagedAsync(option);
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductDTO productDto)
        {
            if (productDto == null)
            {
                return BadRequest("Product data is null");
            }
            var createdProduct = await _productService.AddAsync(productDto);
            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDTO productDto)
        {
            if (productDto == null)
            {
                return BadRequest("Product data is invalid");
            }
            var updatedProduct = await _productService.UpdateAsync(productDto);
            if (updatedProduct == null)
            {
                return NotFound();
            }
            return Ok(updatedProduct);
        }
    }
}
