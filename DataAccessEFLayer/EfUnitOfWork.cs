using DataAccessEFLayer.Abstractions;

namespace DataAccessEFLayer.Repositories
{
    public class EfUnitOfWork(LibraryDbContext _db) : IUnitOfWork
    {
        public Task<int> SaveChangesAsync()
        {
            return _db.SaveChangesAsync();
        }
    }
}
