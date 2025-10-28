using DataAccessEFLayer.Entities;

namespace DataAccessEFLayer.Abstractions
{
    public interface IAuthorRepository : IRepository<Author>
    {
        public Task<IEnumerable<Author>> GetAuthorsByNameAsync(string name);
        public Task<Author?> GetAuthorByBookIdAsync(int bookId);

        public Task<IEnumerable<Author>> GetByFilterAsync(AuthorRepoFilter filter);
    }
}
