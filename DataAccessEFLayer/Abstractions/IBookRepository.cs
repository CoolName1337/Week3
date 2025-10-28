using DataAccessEFLayer.Entities;

namespace DataAccessEFLayer.Abstractions
{
    public interface IBookRepository : IRepository<Book>
    {
        public IQueryable<Book> GetBooksByTitle(string name);
        public IQueryable<Book> GetBooksByAuthorId(int authorId);
    }
}
