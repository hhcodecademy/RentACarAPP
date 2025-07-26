using Microsoft.AspNetCore.Http;

namespace RentACarAPP.Contract.Dtos
{
    public class FileUploadDto
    {
        public IFormFile Image { get; set; }
    }
}
