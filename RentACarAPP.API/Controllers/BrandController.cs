using Microsoft.AspNetCore.Mvc;
using RentACarAPP.Contract.Dtos;
using RentACarAPP.Contract.Dtos.Paging;
using RentACarAPP.Contract.Services;

namespace RentACarAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BrandController(IBrandService brandService, IWebHostEnvironment webHostEnvironment)
        {
            _brandService = brandService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> GetBrands()
        {

            var brands = await _brandService.GetAllAsync();
            return Ok(brands);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            var brand = await _brandService.GetByIdAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            return Ok(brand);
        }
        [HttpPost]
        public async Task<IActionResult> AddBrand([FromBody] BrandDTO brandDto)
        {
            if (brandDto == null)
            {
                return BadRequest("Brand data is null");
            }
            var createdBrand = await _brandService.AddAsync(brandDto);
            return CreatedAtAction(nameof(GetBrandById), new { id = createdBrand.Id }, createdBrand);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBrand([FromBody] BrandDTO brandDto)
        {
            if (brandDto == null)
            {
                return BadRequest("Brand data is invalid");
            }
            var updatedBrand = await _brandService.UpdateAsync(brandDto);
            if (updatedBrand == null)
            {
                return NotFound();
            }
            return Ok(updatedBrand);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var isDeleted = await _brandService.DeleteAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();

        }

        [HttpPost("upload-image/{id}")]
        public async Task<IActionResult> UploadImage(int id, FileUploadDto fileDto)
        {

            if (fileDto == null)
            {
                return BadRequest("File data is null");
            }
            var folder = _webHostEnvironment.WebRootPath + "/documents/brand/images";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            var fileName = $"{Guid.NewGuid()}_{fileDto.Image.FileName}";

            var filePath = Path.Combine(folder, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await fileDto.Image.CopyToAsync(stream);
            }


            var isUploaded = await _brandService.UploadImgAsync(id, fileName);
            if (!isUploaded)
            {
                return BadRequest("Image upload failed.");
            }

            return Ok();


        }
        [HttpGet("paged/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetPagedBrands(int pageNumber, int pageSize)
        {
            var option = new PagedOptionDTO
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            var brands = await _brandService.GetAllPagedAsync(option);
            return Ok(brands);
        }

        }
}
