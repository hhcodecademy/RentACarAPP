namespace RentACarAPP.Domain.Repository
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Saves all changes made in this unit of work to the underlying database.
        /// </summary>
        /// <returns>The number of state entries written to the database.</returns>
        Task<int> SaveChangesAsync();
    }
}
