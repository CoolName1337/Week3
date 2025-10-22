using DataAccessLayer.Models;

namespace BusinessLayer
{
    public interface IAuthorService
    {
        public Task<IEnumerable<Author>?> GetAllAsync();
        public Task<Author?> GetByIdAsync(int id);
        public Task CreateAsync(string name, DateTime dateOfBirth);
        public Task UpdateAsync(int id, string name, DateTime dateOfBirth);
        public Task DeleteAsync(int id);
    }
}
