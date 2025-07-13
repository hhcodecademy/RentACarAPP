using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACarAPP.Domain.Entity;

namespace RentACarAPP.Domain.Repository
{
    public interface ILogDataRepository
    {
        public Task AddAsync(LogData logData);
    }
}
