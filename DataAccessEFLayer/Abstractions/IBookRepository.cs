using DataAccessEFLayer.Entities;

namespace DataAccessEFLayer.Abstractions
{
    public interface IBookRepository : IRepository<Book>
    {
        public Task<IEnumerable<Book>> GetBooksByTitleAsync(string name);
        public Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(int authorId);
        public Task<IEnumerable<Book>> GetByFilterAsync(BookRepoFilter filter);
    }
}
