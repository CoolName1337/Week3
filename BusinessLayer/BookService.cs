using DataAccessLayer;
using DataAccessLayer.Models;

namespace BusinessLayer
{
    internal class BookService(IRepository<Book> repository) : IBookService
    {
        public async Task CreateAsync(string title, int publishedYear, int authorId)
        {
            var book = new Book { Title = title, PublishedYear = publishedYear, AuthorId = authorId };
            await repository.CreateAsync(book);
        }
        public async Task DeleteAsync(int id)
        {
            var res = await GetByIdAsync(id);
            await repository.DeleteAsync(res);
        }
        public async Task<IEnumerable<Book>?> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
        public async Task<Book?> GetByIdAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }
        public async Task UpdateAsync(int id, string title, int publishedYear, int authorId)
        {
            var res = await GetByIdAsync(id);

            res.Title = title;
            res.PublishedYear = publishedYear;
            res.AuthorId = authorId;

            await repository.UpdateAsync(res);
        }
    }
}
