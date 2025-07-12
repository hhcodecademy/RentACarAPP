using Microsoft.EntityFrameworkCore;
using RentACarAPP.Domain.Entity;
using RentACarAPP.Domain.Repository;
using RentACarAPP.Persistance.DBContext;

namespace RentACarAPP.Persistance.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly RentACarDB _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(RentACarDB context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var addedEntity = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;


        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null || entity.IsDeleted)
            {
                return false;
            }
            entity.IsDeleted = true;
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            var entities = (await _dbSet.ToListAsync()).Where(x => !x.IsDeleted);
            return entities.AsQueryable();


        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            return entity;

        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }
            entity.UpdatedDate = DateTime.UtcNow;
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
