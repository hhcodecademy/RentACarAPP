using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace RentACarAPP.Contract.Dtos
{
    public class FileUploadDto
    {
        public IFormFile Image { get; set; }
    }
}
