using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACarAPP.Domain.Entity;
using RentACarAPP.Domain.Repository;
using RentACarAPP.Persistance.DBContext;

namespace RentACarAPP.Persistance.Repository
{
    public class LogDataRepository : ILogDataRepository
    {
        private readonly RentACarDB _context;

        public LogDataRepository(RentACarDB context)
        {
            _context = context;
        }

        public async Task AddAsync(LogData logData)
        {
            await _context.Logs.AddAsync(logData);
            await _context.SaveChangesAsync();
        }
    }
}
