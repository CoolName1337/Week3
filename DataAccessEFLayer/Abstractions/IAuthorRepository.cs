using DataAccessEFLayer.Entities;

namespace DataAccessEFLayer.Abstractions
{
    public interface IAuthorRepository : IRepository<Author>
    {
        public IQueryable<Author> GetAuthorsByName(string name);
        public Task<Author?> GetAuthorByBookIdAsync(int bookId);
    }
}
