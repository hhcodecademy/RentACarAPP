using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACarAPP.Domain.Repository;
using RentACarAPP.Persistance.DBContext;

namespace RentACarAPP.Persistance.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RentACarDB _context;
        public UnitOfWork(RentACarDB context)
        {
            _context = context;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        
    }
}
