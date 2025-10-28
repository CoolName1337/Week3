
namespace DataAccessLayer.Repositories
{
    public interface IRepository<T>
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task<T> CreateAsync(T obj);
        public Task<T> UpdateAsync(T obj);
        public Task DeleteAsync(T obj);

    }
}
