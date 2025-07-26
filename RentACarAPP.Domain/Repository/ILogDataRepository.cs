using RentACarAPP.Domain.Entity;

namespace RentACarAPP.Domain.Repository
{
    public interface ILogDataRepository : IGenericRepository<LogData>
    {
        public Task AddAsync(LogData logData);
    }
}
