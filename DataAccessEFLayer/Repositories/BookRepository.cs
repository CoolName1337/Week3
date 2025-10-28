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

        public async Task<IEnumerable<Book>> GetBooksByTitleAsync(string name)
        {
            return await _db.Books.AsNoTracking().Where(b => b.Title.Contains(name)).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(int authorId)
        {
            return await _db.Books.AsNoTracking().Where(b => b.AuthorId == authorId).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetByFilterAsync(BookRepoFilter filter)
        {
            var q = _db.Books.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.BookTitle))
                q = q.Where(b => b.Title.Contains(filter.BookTitle));

            if (filter.AuthorId is int id)
                q = q.Where(b => b.AuthorId == id);

            if (!string.IsNullOrWhiteSpace(filter.AuthorName))
                q = q.Include(b => b.Author).Where(b => b.Author.Name.Contains(filter.AuthorName));

            if (filter.PublishedAfter is int publishedfter)
                q = q.Where(b => b.PublishedYear > publishedfter);

            return await q.AsNoTracking().ToListAsync();
        }
    }
}
