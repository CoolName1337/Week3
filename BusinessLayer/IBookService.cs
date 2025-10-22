using DataAccessLayer.Models;

namespace BusinessLayer
{
    public interface IBookService
    {
        public Task<IEnumerable<Book>?> GetAllAsync();
        public Task<Book?> GetByIdAsync(int id);
        public Task CreateAsync(string title, int publishedYear, int authorId);
        public Task UpdateAsync(int id, string title, int publishedYear, int authorId);
        public Task DeleteAsync(int id);
    }
}
