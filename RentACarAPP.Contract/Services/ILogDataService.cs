using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACarAPP.Contract.Dtos;
using RentACarAPP.Domain.Entity;

namespace RentACarAPP.Contract.Services
{
    public interface ILogDataService
    {
        public Task AddAsync(LogDataDTO dto);
    }
}
