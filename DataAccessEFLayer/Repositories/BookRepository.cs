using DataAccessEFLayer.Entities;
using DataAccessEFLayer.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DataAccessEFLayer.Repositories
{
    public class BookRepository(LibraryDbContext _db) : IBookRepository
    {
        public IQueryable<Book> Query()
        {
            return _db.Books;
        }

        public async Task AddAsync(Book obj)
        {
            await _db.Books.AddAsync(obj);
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _db.Books.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksAfterYearAsync(int year)
        {
            return await _db.Books.AsNoTracking().Include(b => b.Author).Where(b => b.PublishedYear >= year).ToListAsync();
        }

        public IQueryable<Book> GetBooksByName(string name)
        {
            return _db.Books.AsNoTracking().Include(b => b.Author).Where(b=>b.Title.StartsWith(name));
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _db.Books.AsNoTracking().Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id);
        }

        public void Remove(Book obj)
        {
            _db.Books.Remove(obj);
        }

        public void Update(Book obj)
        {
            _db.Books.Update(obj);
        }

        public IQueryable<Book> GetBooksByTitle(string name)
        {
            return _db.Books.Where(b => b.Title.Contains(name));
        }

        public IQueryable<Book> GetBooksByAuthorId(int authorId)
        {
           return _db.Books.Where(b=>b.AuthorId == authorId);
        }
    }
}
