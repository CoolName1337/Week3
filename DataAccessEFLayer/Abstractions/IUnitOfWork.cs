
namespace DataAccessEFLayer.Abstractions
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
