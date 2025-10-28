
namespace DataAccessEFLayer.Abstractions
{
    public interface IRepository<T>
    {
        public IQueryable<T> Query();
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T?> GetByIdAsync(int id);
        public Task AddAsync(T obj);
        public void Update(T obj);
        public void Remove(T obj);

    }
}
