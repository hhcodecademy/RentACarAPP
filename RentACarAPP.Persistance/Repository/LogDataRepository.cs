using RentACarAPP.Domain.Entity;
using RentACarAPP.Domain.Repository;
using RentACarAPP.Persistance.DBContext;

namespace RentACarAPP.Persistance.Repository
{
    public class LogDataRepository : GenericRepository<LogData>, ILogDataRepository
    {
        public LogDataRepository(RentACarDB context) : base(context)
        {
        }

        public async Task AddAsync(LogData logData)
        {
            await _context.Logs.AddAsync(logData);
            await _context.SaveChangesAsync();
        }
    }
}
