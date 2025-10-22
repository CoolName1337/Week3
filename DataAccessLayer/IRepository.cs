namespace DataAccessLayer
{
    public interface IRepository<T>
    {
        public Task<IEnumerable<T>?> GetAllAsync();
        public Task<T?> GetByIdAsync(int id);
        public Task CreateAsync(T obj);
        public Task UpdateAsync(T obj);
        public Task DeleteAsync(T obj);

    }
}
